using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Module_Accounts_Transactions_Debit_Note : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    string Sid = string.Empty;
    int Cid = 0;
    int Fyid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            con = new SqlConnection(connStr);

            Sid = Session["username"].ToString();
            Cid = Convert.ToInt32(Session["compid"]);
            Fyid = Convert.ToInt32(Session["finyear"]);

            if (!IsPostBack)
            {
                this.fillgrid();
            }

            string val = "";
            string sql = fun.select("*", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");
            SqlCommand cmdsql = new SqlCommand(sql, con);
            SqlDataAdapter dasql = new SqlDataAdapter(cmdsql);
            DataSet dssql = new DataSet();
            dasql.Fill(dssql);
            if (dssql.Tables[0].Rows.Count > 0)
            {
                val = ((DropDownList)GridView1.FooterRow.FindControl("DrpList2")).SelectedValue;
            }
            else
            {
                val = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpList3")).SelectedValue;
            }

            Session["val1"] = val;
        }
         catch (Exception er) { }
    }

    public void fillgrid()
    {
        try
        {
            con.Open();
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DebitNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Types", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SCE", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Refrence", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Particulars", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("typ", typeof(string)));

            string sql = fun.select("*", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");

            SqlCommand cmdsql = new SqlCommand(sql, con);
            SqlDataAdapter dasql = new SqlDataAdapter(cmdsql);
            DataSet dssql = new DataSet();
            dasql.Fill(dssql);

            DataRow dr;

            for (int d = 0; d < dssql.Tables[0].Rows.Count; d++)
            {
                dr = dt.NewRow();

                dr[0] = dssql.Tables[0].Rows[d]["Id"].ToString();
                dr[1] = dssql.Tables[0].Rows[d]["Date"].ToString();
                dr[2] = dssql.Tables[0].Rows[d]["DebitNo"].ToString();

                string sql2 = fun.select("*", "tblACC_DebitType", "Id='" + dssql.Tables[0].Rows[d]["Types"].ToString() + "'");
                SqlCommand cmdsql2 = new SqlCommand(sql2, con);
                SqlDataAdapter dasql2 = new SqlDataAdapter(cmdsql2);
                DataSet dssql2 = new DataSet();
                dasql2.Fill(dssql2);

                dr[3] = dssql2.Tables[0].Rows[0]["Description"].ToString();
                dr[4] = fun.EmpCustSupplierNames(Convert.ToInt32(dssql.Tables[0].Rows[d]["Types"].ToString()), dssql.Tables[0].Rows[d]["SCE"].ToString(), Cid);
                dr[5] = dssql.Tables[0].Rows[d]["Refrence"].ToString();
                dr[6] = dssql.Tables[0].Rows[d]["Particulars"].ToString();
                dr[7] = dssql.Tables[0].Rows[d]["Amount"].ToString();
                dr[8] = dssql.Tables[0].Rows[d]["Types"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();

        }
        catch (Exception er) { }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       try
        {
            string sysDate = fun.getCurrDate();
            string sysTime = fun.getCurrTime();

            if (e.CommandName == "Add")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string date = ((TextBox)row.FindControl("txtDate2")).Text;
                int typ = Convert.ToInt32(((DropDownList)row.FindControl("DrpList2")).SelectedValue);
                string defor = fun.getCode(((TextBox)row.FindControl("txtDebitto2")).Text);
                string refr = ((TextBox)row.FindControl("txtReference2")).Text;
                string part = ((TextBox)row.FindControl("txtParticulars2")).Text;
                string amt = ((TextBox)row.FindControl("txtAmt2")).Text;

                string Strpvevno = fun.select("DebitNo", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId='" + Fyid + "' order by DebitNo desc");

                SqlCommand cmdpvevno = new SqlCommand(Strpvevno, con);
                SqlDataAdapter DApvevno = new SqlDataAdapter(cmdpvevno);
                DataSet DSpvevno = new DataSet();
                DApvevno.Fill(DSpvevno, "tblACC_DebitNote");
                string PVEVNo = "";

                if (DSpvevno.Tables[0].Rows.Count > 0)
                {
                    PVEVNo = (Convert.ToInt32(DSpvevno.Tables[0].Rows[0]["DebitNo"]) + 1).ToString("D4");
                }
                else
                {
                    PVEVNo = "0001";
                }


                int EmpSupId = fun.chkEmpCustSupplierCode(defor, typ, Cid);
                 if (EmpSupId == 1 && ((DropDownList)row.FindControl("DrpList2")).SelectedValue != "0" && ((TextBox)row.FindControl("txtDebitto2")).Text != "" && ((TextBox)row.FindControl("txtDate2")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtDate2")).Text) == true && amt != "" && fun.NumberValidationQty(amt) == true)
                 {
                     string SqlInsert = fun.insert("tblACC_DebitNote", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,DebitNo,SCE,Amount,Refrence,Particulars,Types", "'" + sysDate + "','" + sysTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + date + "','" + PVEVNo + "','" + defor + "','" + Convert.ToDouble(decimal.Parse(amt).ToString("N2")) + "','" + refr + "','" + part + "','" + typ + "'");
                    SqlCommand cmd = new SqlCommand(SqlInsert, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid data entry.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }

                
            }

            if (e.CommandName == "Add1")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string date = ((TextBox)row.FindControl("txtDate3")).Text;
                int typ =Convert.ToInt32( ((DropDownList)row.FindControl("DrpList3")).SelectedValue);
                string defor = fun.getCode(((TextBox)row.FindControl("TxtSCE")).Text);
                string refr = ((TextBox)row.FindControl("TxtRefrence")).Text;
                string part = ((TextBox)row.FindControl("TxtParticulars")).Text;
                string amt = ((TextBox)row.FindControl("txtAmt3")).Text;

                string Strpvevno = fun.select("DebitNo", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId='" + Fyid + "' order by DebitNo desc");

                SqlCommand cmdpvevno = new SqlCommand(Strpvevno, con);
                SqlDataAdapter DApvevno = new SqlDataAdapter(cmdpvevno);
                DataSet DSpvevno = new DataSet();
                DApvevno.Fill(DSpvevno);
                string PVEVNo = "";
                             
                if (DSpvevno.Tables[0].Rows.Count > 0)
                {
                    PVEVNo = (Convert.ToInt32(DSpvevno.Tables[0].Rows[0]["DebitNo"]) + 1).ToString("D4");
                }
                else
                {
                    PVEVNo = "0001";
                }

                int EmpSupId = fun.chkEmpCustSupplierCode(defor, typ, Cid);

                if (EmpSupId == 1 && ((DropDownList)row.FindControl("DrpList3")).SelectedValue != "0" && ((TextBox)row.FindControl("TxtSCE")).Text != "" && ((TextBox)row.FindControl("txtDate3")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtDate3")).Text) == true && amt != "" && fun.NumberValidationQty(amt) == true)
                {
                    string SqlInsert = fun.insert("tblACC_DebitNote", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,DebitNo,SCE,Amount,Refrence,Particulars,Types", "'" + sysDate + "','" + sysTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + date + "','" + PVEVNo + "','" + defor + "','" + Convert.ToDouble(decimal.Parse(amt).ToString("N2")) + "','" + refr + "','" + part + "','" + typ + "'");
                    SqlCommand cmd = new SqlCommand(SqlInsert, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid data entry.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }

            }
        }

    catch (Exception er) { }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;

            this.fillgrid();
        }
        catch (Exception er) { }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.fillgrid();
            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
           ((DropDownList)row.FindControl("DrpList1")).SelectedValue = ((Label)row.FindControl("lblType1")).Text;
        }
        catch (Exception er) { }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string date = ((TextBox)row.FindControl("txtDate1")).Text;
            int typ =Convert.ToInt32( ((DropDownList)row.FindControl("DrpList1")).SelectedValue);
            string defor = fun.getCode(((TextBox)row.FindControl("txtDebitto1")).Text);
            string refr = ((TextBox)row.FindControl("txtReference1")).Text;
            string part = ((TextBox)row.FindControl("txtParticulars1")).Text;
            string amt = ((TextBox)row.FindControl("txtAmt1")).Text;
            int EmpSupId = fun.chkEmpCustSupplierCode(defor, typ, Cid);
            if (EmpSupId == 1 && ((DropDownList)row.FindControl("DrpList1")).SelectedValue != "0" && ((TextBox)row.FindControl("txtDebitto1")).Text != "" && ((TextBox)row.FindControl("txtDate1")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtDate1")).Text) == true && amt != "" && fun.NumberValidationQty(amt) == true)
            {
                string sql1 = fun.update("tblACC_DebitNote", "Date='" + date + "',SCE='" + defor + "',Amount='" + Convert.ToDouble(decimal.Parse(amt).ToString("N2")) + "',Refrence='" + refr + "',Particulars='" + part + "',Types='" + typ + "'", "Id=" + id1 + " And CompId='" + Cid + "'");
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

                GridView1.EditIndex = -1;
                this.fillgrid();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        catch (Exception s)
        {
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_DebitNote", "Id='" + id + "' And CompId='" + Cid + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception er) { }

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.fillgrid();
    }

    protected void DrpList1_SelectedIndexChanged(object sender, EventArgs e)
    {        
       DropDownList x = (DropDownList)sender;
       GridViewRow grv = (GridViewRow)x.NamingContainer;
       ((TextBox)grv.FindControl("txtDebitto1")).Text = "";
       string a = x.SelectedValue;
       Session["valE1"] = a;
       
    }

    protected void DrpList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtSCE")).Text = "";
    }

    protected void DrpList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)GridView1.FooterRow.FindControl("txtDebitto2")).Text = "";
    }    

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();

        string cmdStr = "";

        string val = HttpContext.Current.Session["Val1"].ToString();

        switch (val)
        {   
               case "1":
                cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' Order by EmployeeName");
                break;            
                 case "2":
                cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' Order by CustomerName");
                break;
                case "3":
                cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' Order by SupplierName");
                break;
        }     

        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds);
        con.Close();

        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }    

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql2(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();

        string cmdStr = "";

        string val = HttpContext.Current.Session["ValE1"].ToString();

        switch (val)
        {
            case "1":
                cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' Order by EmployeeName");
                break;
            case "2":
                cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' Order by CustomerName");
                break;
            case "3":
                cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' Order by SupplierName");
                break;
        }

        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds);
        con.Close();

        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }


}




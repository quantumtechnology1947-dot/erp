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

public partial class Module_Accounts_Transactions_BillBooking_Authorize : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SupId = "";
    string PONo = "";
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            con = new SqlConnection(connStr);

            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);

            if (!Page.IsPostBack)
            {                
                this.loadData(SupId, PONo);
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void loadData(string spid, string pono)
    {
        try
        {
            
            DataTable dt = new DataTable();


            con.Open();
            string x = "";
            if (DropDownList1.SelectedValue == "2")
            {
                if (Txtfield.Text != "")
                {
                    x = " And PVEVNo='" + Txtfield.Text + "'";
                }
            }
            string y = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtSupplier.Text != "")
                {
                    string Sid = fun.getCode(txtSupplier.Text);
                    y = " And SupplierId='" + Sid + "'";
                }
            }

            if (DropDownList1.SelectedValue == "0")
            {
                Txtfield.Visible = false;
                txtSupplier.Visible = false;
            }
            //else if(DropDownList1.SelectedValue != "Select")
            //{
            //    Txtfield.Enabled = true;
            //}

            string m = string.Empty;

            if (ViewAll.Checked == true)
            {
                m = "";
            }
            else
            {
                m = "And Authorize='0'";
            }

            string StrSql = fun.select("Id  , SysDate , SysTime  , SessionId , CompId , FinYearId, PVEVNo, SupplierId , BillNo, BillDate , CENVATEntryNo, CENVATEntryDate, OtherCharges, OtherChaDesc, Narration , DebitAmt , DiscountType, Discount ,Authorize,AuthorizeBy,AuthorizeDate,AuthorizeTime", "tblACC_BillBooking_Master", "  FinYearId<='" + FinYearId + "'  And CompId='" + CompId + "'" + x + y + m + "Order by Id Desc");

            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataReader DSSql = cmdSql.ExecuteReader();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PODate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CkAuth", typeof(Boolean)));
            dt.Columns.Add(new System.Data.DataColumn("By", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));

            DataRow dr;
            while (DSSql.Read())
            {
                dr = dt.NewRow();
                
                {
                    int FinYr = Convert.ToInt32(DSSql["FinYearId"]);
                    string SysDt = fun.FromDateDMY(DSSql["SysDate"].ToString());

                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + FinYr + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataReader DSFin = cmdFinYr.ExecuteReader();
                    DSFin.Read();

                    string sqlSup = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + DSSql["SupplierId"].ToString() + "'");

                    SqlCommand cmdSupId = new SqlCommand(sqlSup, con);
                    SqlDataReader DSSupId = cmdSupId.ExecuteReader();
                    DSSupId.Read();

                    string z = "";
                    if (DropDownList1.SelectedValue == "3")
                    {
                        if (Txtfield.Text != "")
                        {
                            z = " And PONo='" + Txtfield.Text + "'";
                        }
                    }                                       

                    dr[0] = DSSql["Id"].ToString();
                    dr[1] = DSSql["FinYearId"].ToString();

                    if (DSFin.HasRows==true)
                    {
                        dr[2] = DSFin["FinYear"].ToString();
                    }

                    dr[3] = DSSql["PVEVNo"].ToString();
                    dr[4] = SysDt;

                    dr[7] = DSSql["SupplierId"].ToString();

                    if (DSSupId.HasRows == true)
                    {
                        dr[8] = DSSupId["SupplierName"].ToString() + " [" + DSSql["SupplierId"].ToString() + "]";
                    }

                    if (Convert.ToInt32(DSSql["Authorize"]) == 1)
                    {
                        dr[9] = true;
                    }
                    else
                    {
                        dr[9] = false;
                    }

                    if (DSSql["AuthorizeBy"] != DBNull.Value)
                    {
                        string sqlEmp = fun.select("Title+' '+EmployeeName As Name", "tblHR_OfficeStaff", "EmpId='" + DSSql["AuthorizeBy"].ToString() + "' AND CompId='" + CompId + "'");
                        
                        SqlCommand cmdEmp = new SqlCommand(sqlEmp, con);
                        SqlDataReader DSEmp = cmdEmp.ExecuteReader();
                        DSEmp.Read();

                        dr[10] = DSEmp["Name"].ToString();

                        dr[11] = fun.FromDateDMY(DSSql["AuthorizeDate"].ToString());
                        dr[12] = DSSql["AuthorizeTime"].ToString();
                    }

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }

            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();

        }
        catch (Exception et)
        {

        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_master");
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



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "1")
        {
            Txtfield.Visible = false;
            txtSupplier.Visible = true;
            txtSupplier.Text = "";
            this.loadData(SupId, PONo);
        }
        if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" )
        {
            Txtfield.Visible = true;
            txtSupplier.Visible = false;
            Txtfield.Text = "";
            this.loadData(SupId, PONo);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       try
        {
            string Spid = "";
            string No = "";
            Spid = fun.getCode(txtSupplier.Text);
            No = Txtfield.Text;
            this.loadData(Spid, No);
        }
        catch (Exception ex) { }

    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.loadData(SupId, PONo);

        }
        catch (Exception ex) { }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void CkAuth_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            bool status = chkStatus.Checked;
            string Id = ((Label)row.FindControl("lblId")).Text;
            string CurrDate = fun.getCurrDate();
            string CurrTime = fun.getCurrTime();

            int x = 0;
            string y = string.Empty;
            string z = string.Empty;
            string p = string.Empty;

            switch (status)
            {
                case true:
                    x = 1;
                    y = "AuthorizeBy = '"+sId+"'";
                    z = "AuthorizeDate = '" + CurrDate + "'";
                    p = "AuthorizeTime = '" + CurrTime + "'";
                    break;
                case false:
                    x = 0;
                    y = "AuthorizeBy=null";
                    z = "AuthorizeDate=null";
                    p = "AuthorizeTime=null";
                    break;
            }

            string StrSql = fun.update("tblACC_BillBooking_Master", "Authorize='" + x + "',"+y+","+z+"," + p + "", "Id='" + Id + "'");
           
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            cmdSql.ExecuteNonQuery();
           
            con.Close();

            Page.Response.Redirect(Page.Request.Url.ToString(),true);
        }
        catch (Exception et)
        {

        }
    }

}

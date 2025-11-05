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

public partial class Module_Accounts_Transactions_IOU_PaymentReceipt : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";
    string CDate = "";
    string CTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            if (!Page.IsPostBack)
            {
                this.BindDataGrid();
                this.NED();
                this.BindDataGrid_Receipt();
                this.NED1();

            }
        }

        catch (Exception ex)
        {
        }

    }

    public void NED()
    {
        try
        {
            foreach (GridViewRow grv in GridView2.Rows)
            {

                int id1 = Convert.ToInt32(((Label)grv.FindControl("Label1")).Text);
                string str1 = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And Id='" + id1 + "'");
                SqlCommand cmdCustWo1 = new SqlCommand(str1, con);
                SqlDataAdapter daCustWo1 = new SqlDataAdapter(cmdCustWo1);
                DataSet DSCustWo1 = new DataSet();
                daCustWo1.Fill(DSCustWo1);
                if (DSCustWo1.Tables[0].Rows.Count > 0)
                {
                    if (DSCustWo1.Tables[0].Rows[0]["Authorize"].ToString() == "1" && DSCustWo1.Tables[0].Rows[0]["Authorize"] != DBNull.Value)
                    {
                        ((CheckBox)grv.FindControl("CheckBox1")).Enabled = false;
                        ((CheckBox)grv.FindControl("CheckBox1")).Checked = true;
                        ((LinkButton)grv.FindControl("LinkButton4")).Visible = false;
                    }

                    else
                    {

                        ((CheckBox)grv.FindControl("CheckBox1")).Enabled = true;
                        ((CheckBox)grv.FindControl("CheckBox1")).Checked = false;
                        ((LinkButton)grv.FindControl("LinkButton4")).Visible = true;
                    }

                }

            }
        }
        catch (Exception ex) { }

    }
    public void NED1()
    {
        try
        {
            foreach (GridViewRow grv in GridView1.Rows)
            {

                int IdR = Convert.ToInt32(((Label)grv.FindControl("lblIdR")).Text);
                string str1 = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And Id='" + IdR + "'");
                SqlCommand cmdCustWo1 = new SqlCommand(str1, con);
                SqlDataAdapter daCustWo1 = new SqlDataAdapter(cmdCustWo1);
                DataSet DSCustWo1 = new DataSet();
                daCustWo1.Fill(DSCustWo1);

                if (DSCustWo1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToDouble(DSCustWo1.Tables[0].Rows[0]["Recieved"].ToString()) == 1 && DSCustWo1.Tables[0].Rows[0]["Recieved"] != DBNull.Value)
                    {
                        ((TextBox)grv.FindControl("txtRecivedAmtR")).Visible = false;
                        ((Button)grv.FindControl("btnAddReceipt")).Enabled = false;
                        ((TextBox)grv.FindControl("txtReceiptDate")).Visible = false;
                        ((LinkButton)grv.FindControl("LinkButton4")).Visible = true;
                        ((LinkButton)grv.FindControl("LinkButton1")).Visible = true;
                        ((Label)grv.FindControl("lblRecivedAmtR")).Visible = true;

                    }

                    else
                    {
                        ((TextBox)grv.FindControl("txtRecivedAmtR")).Visible = true;
                        ((Button)grv.FindControl("btnAddReceipt")).Visible = true;
                        ((Button)grv.FindControl("btnAddReceipt")).Enabled = true;
                        ((Label)grv.FindControl("lblRecivedAmtR")).Visible = false;
                        ((TextBox)grv.FindControl("txtReceiptDate")).Visible = true;
                        ((LinkButton)grv.FindControl("LinkButton4")).Visible = false;
                        ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;

                    }
                }

            }
        }

        catch (Exception ex) { }
    }

    public void BindDataGrid()
    {
        try
        {

            DataTable dt = new DataTable();
            con.Open();
            string str = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'And Recieved='0' Order by Id Desc");
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("PaymentDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ReasonId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Reason", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Narration", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Authorized", typeof(int)));
            DataRow dr;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();
                dr[0] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();
                dr[1] = fun.FromDateDMY(DSCustWo.Tables[0].Rows[i]["PaymentDate"].ToString());

                string strEmp = fun.select("Title+'.'+EmployeeName+ ' ['+ EmpId +']' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND EmpId='" + DSCustWo.Tables[0].Rows[i]["EmpId"] + "'");

                SqlCommand cmdEmp = new SqlCommand(strEmp, con);
                SqlDataAdapter daEmp = new SqlDataAdapter(cmdEmp);
                DataSet DSEmp = new DataSet();
                daEmp.Fill(DSEmp);
                if (DSEmp.Tables[0].Rows.Count > 0)
                {
                    dr[2] = DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                }
                dr[3] = Convert.ToDouble(decimal.Parse(DSCustWo.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
                dr[4] = DSCustWo.Tables[0].Rows[i]["Reason"].ToString();

                string stryr = fun.select("Terms", "tblACC_IOU_Reasons", "Id='" + DSCustWo.Tables[0].Rows[i]["Reason"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[5] = DSyr.Tables[0].Rows[0]["Terms"].ToString();
                }
                dr[6] = DSCustWo.Tables[0].Rows[i]["Narration"].ToString();

                dr[7] = DSCustWo.Tables[0].Rows[i]["Authorize"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();
        }

        catch (Exception ex)
        { }
    }


    public void BindDataGrid_Receipt()
    {
        try
        {

            DataTable dt = new DataTable();
            con.Open();
            string str = fun.select("*", "tblACC_IOU_Master", " Authorize='1' And FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' Order by Id Desc");
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);

            dt.Columns.Add(new System.Data.DataColumn("IdR", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("PaymentDateR", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("EmpNameR", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmountR", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ReasonIdR", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("ReasonR", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("NarrationR", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedR", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("RecivedAmtR", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ReceiptDateR", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DIdR", typeof(int)));
            DataRow dr;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();
                dr[0] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();
                dr[1] = fun.FromDateDMY(DSCustWo.Tables[0].Rows[i]["SysDate"].ToString());

                string strEmp = fun.select("Title+'.'+EmployeeName+ '['+ EmpId +' ]' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND EmpId='" + DSCustWo.Tables[0].Rows[i]["EmpId"] + "'");

                SqlCommand cmdEmp = new SqlCommand(strEmp, con);
                SqlDataAdapter daEmp = new SqlDataAdapter(cmdEmp);
                DataSet DSEmp = new DataSet();
                daEmp.Fill(DSEmp);
                if (DSEmp.Tables[0].Rows.Count > 0)
                {
                    dr[2] = DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                }

                dr[3] = Convert.ToDouble(decimal.Parse(DSCustWo.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
                dr[4] = DSCustWo.Tables[0].Rows[i]["Reason"].ToString();
                string stryr = fun.select("Terms", "tblACC_IOU_Reasons", "Id='" + DSCustWo.Tables[0].Rows[i]["Reason"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[5] = DSyr.Tables[0].Rows[0]["Terms"].ToString();
                }

                dr[6] = DSCustWo.Tables[0].Rows[i]["Narration"].ToString();
                dr[7] = DSCustWo.Tables[0].Rows[i]["Authorize"].ToString();

                string strReceipt = fun.select("*", "tblACC_IOU_Receipt", " MId='" + DSCustWo.Tables[0].Rows[i]["Id"].ToString() + "' And FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
                SqlCommand cmdReceipt = new SqlCommand(strReceipt, con);
                SqlDataAdapter DAReceipt = new SqlDataAdapter(cmdReceipt);
                DataSet DSReceipt = new DataSet();
                DAReceipt.Fill(DSReceipt);
                if (DSReceipt.Tables[0].Rows.Count > 0)
                {
                    dr[8] = Convert.ToDouble(decimal.Parse(DSReceipt.Tables[0].Rows[0]["RecievedAmount"].ToString()).ToString("N3"));
                    dr[9] = fun.FromDate(DSReceipt.Tables[0].Rows[0]["ReceiptDate"].ToString());
                    dr[10] = Convert.ToInt32(DSReceipt.Tables[0].Rows[0]["Id"]);
                }
                else
                {
                    dr[8] = 0;
                    dr[9] = "";
                    dr[10] = 0;

                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        catch (Exception ex)
        { }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
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
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView2.PageIndex = e.NewPageIndex;
        //GridView2.EditIndex = -1;
        //this.BindDataGrid();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        this.BindDataGrid();
        this.NED();

    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView2.EditIndex = e.NewEditIndex;
            this.BindDataGrid();
            int index = GridView2.EditIndex;
            GridViewRow grv = GridView2.Rows[index];
            string labelLoc = ((Label)grv.FindControl("lblReason2")).Text;
            ((DropDownList)grv.FindControl("DrpReason2")).SelectedValue = labelLoc.ToString();

            int labelAuth = Convert.ToInt32(((Label)grv.FindControl("lblAuth")).Text);
            if (labelAuth == 1)
            {
                ((CheckBox)grv.FindControl("CheckBox2")).Checked = true;
                ((CheckBox)grv.FindControl("CheckBox1")).Visible = false;
            }
            else
            {
                ((CheckBox)grv.FindControl("CheckBox2")).Checked = false;
                ((CheckBox)grv.FindControl("CheckBox1")).Visible = false;
            }
            this.NED();
            this.BindDataGrid_Receipt();
            this.NED1();
        }
        catch (Exception ex)
        { }
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index1 = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[index1];
            int id1 = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            string EmpName = fun.getCode(((Label)row.FindControl("lblEmpName")).Text);


            double Amount = 0;
            if (((TextBox)row.FindControl("TextBox2")).Text != "")
            {
                Amount = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TextBox2")).Text).ToString("N3"));
            }
            int Reason = Convert.ToInt32(((DropDownList)row.FindControl("DrpReason2")).SelectedValue);
            string Narration = ((TextBox)row.FindControl("TextBox4")).Text;
            int x = 0;
            if (((CheckBox)row.FindControl("CheckBox2")).Checked == true)
            {
                x = 1;
            }

            if (fun.NumberValidationQty(Amount.ToString()) == true && ((TextBox)row.FindControl("TextBox2")).Text != "")
            {

                if (Amount != 0)
                {

                    string sql1 = fun.update("tblACC_IOU_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',EmpId='" + EmpName + "',Amount='" + Amount + "',Reason='" + Reason + "',Narration='" + Narration + "',AuthorizedDate='" + CDate + "',AuthorizedTime='" + CTime + "',AuthorizedBy='" + sId + "',Authorize='" + x + "'", "Id='" + id1 + "'");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    GridView2.EditIndex = -1;
                    this.BindDataGrid();
                    this.NED();
                    this.BindDataGrid_Receipt();
                    this.NED1();
                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Insert Valid Amount.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_IOU_Master WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.BindDataGrid();
            this.NED();

        }
        catch (Exception er) { }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

        try
        {
            CheckBox x = (CheckBox)sender;
            GridViewRow grv = (GridViewRow)x.NamingContainer;
            int id1 = Convert.ToInt32(((Label)grv.FindControl("Label1")).Text);
            double CashINHand = fun.getCashClBalAmt("=", fun.getCurrDate(), CompId, FinYearId);
            double Amount = Convert.ToDouble(((Label)grv.FindControl("lblAmt")).Text);
            if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
            {
                if (Math.Round((CashINHand - Amount), 2) > 0)
                {
                    string sql1 = fun.update("tblACC_IOU_Master", "AuthorizedDate='" + CDate + "',AuthorizedTime='" + CTime + "',AuthorizedBy='" + sId + "',Authorize='1'", "Id='" + id1 + "'");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    this.BindDataGrid();
                    this.NED();
                    this.BindDataGrid_Receipt();
                    this.NED1();
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Insufficient Cash";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }

        }
        catch (Exception er) { }
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        this.BindDataGrid_Receipt();
        this.NED1();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindDataGrid_Receipt();
        this.NED1();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {

                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int MId = Convert.ToInt32(((Label)row.FindControl("lblIdR")).Text);
                double Amt = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblAmountR")).Text).ToString("N3"));

                double RecivedAmt = 0;
                if (((TextBox)row.FindControl("txtRecivedAmtR")).Text != "")
                {
                    RecivedAmt = Convert.ToDouble(((TextBox)row.FindControl("txtRecivedAmtR")).Text);
                }
                string Date = fun.FromDate(((TextBox)row.FindControl("txtReceiptDate")).Text);

                if (((TextBox)row.FindControl("txtRecivedAmtR")).Text != "")
                {
                    if (((TextBox)row.FindControl("txtRecivedAmtR")).Text != "" && fun.NumberValidationQty(RecivedAmt.ToString()) == true)
                    {

                        if ((Amt - RecivedAmt) >= 0)
                        {
                            if (((TextBox)row.FindControl("txtReceiptDate")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtReceiptDate")).Text) == true)
                            {

                                string cmdstr = fun.insert("tblACC_IOU_Receipt", "MId,SysDate,SysTime,SessionId,CompId,FinYearId,ReceiptDate,RecievedAmount", "'" + MId + "','" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + Date + "','" + RecivedAmt + "'");
                                SqlCommand cmd = new SqlCommand(cmdstr, con);

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                string sql4 = fun.update("tblACC_IOU_Master", "Recieved='1'", "Id='" + MId + "'");
                                SqlCommand cmd4 = new SqlCommand(sql4, con);
                                con.Open();
                                cmd4.ExecuteNonQuery();
                                con.Close();

                                this.BindDataGrid_Receipt();
                                this.NED1();
                                this.BindDataGrid();
                                this.NED();

                            }
                            else
                            {
                                string mystring = string.Empty;
                                mystring = "Invalid Date.";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                            }


                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Amount exceeds limit.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }

                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Incorrect Input.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Blank input not allowed.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }

            }


            if (e.CommandName == "del")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int MId = Convert.ToInt32(((Label)row.FindControl("lblIdR")).Text);
                int DIdR = Convert.ToInt32(((Label)row.FindControl("lblDIdR")).Text);

                SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_IOU_Receipt WHERE Id=" + DIdR + " And CompId='" + CompId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string sql5 = fun.update("tblACC_IOU_Master", "Recieved='0'", "Id='" + MId + "' And CompId='" + CompId + "'");
                SqlCommand cmd5 = new SqlCommand(sql5, con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();

                this.BindDataGrid_Receipt();
                this.NED1();
                this.BindDataGrid();
                this.NED();
            }

        }
        catch (Exception ex)
        { }
    }



    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindDataGrid_Receipt();
            this.NED1();
        }
        catch (Exception ex)
        { }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            double Amt = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblAmountR")).Text).ToString("N3"));

            double RecivedAmt = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtRecivedAmtR1")).Text).ToString("N3"));
            string Date = fun.FromDate(((TextBox)row.FindControl("txtReceiptDate1")).Text);


            if (((TextBox)row.FindControl("txtRecivedAmtR1")).Text != "")
            {
                if (((TextBox)row.FindControl("txtRecivedAmtR1")).Text != "" && fun.NumberValidationQty(RecivedAmt.ToString()) == true)
                {

                    if ((Amt - RecivedAmt) >= 0)
                    {
                        if (((TextBox)row.FindControl("txtReceiptDate1")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtReceiptDate1")).Text) == true)
                        {

                            string sql1 = fun.update("tblACC_IOU_Receipt", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',ReceiptDate='" + Date + "',RecievedAmount='" + RecivedAmt + "'", "MId='" + id1 + "'");
                            SqlCommand cmd1 = new SqlCommand(sql1, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            GridView1.EditIndex = -1;
                            this.BindDataGrid_Receipt();
                            this.NED1();
                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Invalid Date.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Amount exceeds limit.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }

                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Incorrect Input.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Blank input not allowed.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }

        }
        catch (Exception ex)
        {
        }
    }
}

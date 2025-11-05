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

public partial class Module_Accounts_Transactions_Advice : System.Web.UI.Page
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


                SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd1 = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Creditor_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                this.FillGrid_Other();
                this.FillGrid_Creditors_Temp();
                this.FillGrid_Salary();
                this.FillGrid_Creditors();
                this.dropdownCompany(DrpTypes);
                this.Loaddata();


            }
        }
       catch (Exception ex)
        {
        }
    }

    public void GetValidate()
    {
        try
        {
            foreach (GridViewRow grv in GridView4.Rows)
            {
                if (((CheckBox)grv.FindControl("ck")).Checked == true)
                {


                    ((RequiredFieldValidator)grv.FindControl("Req16")).Visible = true;
                    ((RequiredFieldValidator)grv.FindControl("ReqBillAgainst")).Visible = true;
                }
                else
                {

                    ((RequiredFieldValidator)grv.FindControl("Req16")).Visible = false;
                    ((RequiredFieldValidator)grv.FindControl("ReqBillAgainst")).Visible = false;
                }
            }
        }

        catch (Exception ex) { }

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            string PayTo = fun.getCode(TextBox1.Text);
            string cmdStr = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_Advice_Payment_Master");
            string ADNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                ADNo = bvno.ToString("D4");
            }
            else
            {
                ADNo = "0001";
            }
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, Convert.ToInt32(drptype.SelectedValue), CompId);

            string sql5 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='1'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId == 1 && TextBox1.Text != "" && txtDDNo.Text != "" && txtPayAt.Text != "" && textChequeDate.Text != "" && fun.DateValidation(textChequeDate.Text) == true && drptype.SelectedValue != "0")
                {
                    string StrBVPMaster = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + ADNo + "','1','" + PayTo + "','" + txtDDNo.Text + "','" + fun.FromDate(textChequeDate.Text) + "','" + txtPayAt.Text + "','" + DropDownList1.SelectedValue + "','" + Convert.ToInt32(drptype.SelectedValue) + "'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + ADNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_Advice_Payment_Details", "MId ,ProformaInvNo ,InvDate,PONo,Particular,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["ProformaInvNo"].ToString() + "','" + fun.FromDate(DS5.Tables[0].Rows[p]["InvDate"].ToString()) + "','" + DS5.Tables[0].Rows[p]["PONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='1'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
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
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Records are not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex) { }

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
        int CodeType = Convert.ToInt32(HttpContext.Current.Session["codetype1"]);

        switch (CodeType)
        {
            case 1:
                {
                    string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' Order By EmployeeName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "tblHR_OfficeStaff");
                }
                break;

            case 2:
                {
                    string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' Order By CustomerName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "SD_Cust_master");
                }
                break;

            case 3:
                {
                    string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' Order By SupplierName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "tblMM_Supplier_master");
                }
                break;

        }

        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 15)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ProformaInvNo = "";
            string InvDate = "";
            string PONo = "";
            double Amount = 0;
            string Particular = "";

            if (e.CommandName == "Add")
            {

                if (((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text != "")
                {
                    ProformaInvNo = ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Text;
                    InvDate = ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Text;
                    PONo = ((TextBox)GridView1.FooterRow.FindControl("txtPoNoFoot")).Text;
                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView1.FooterRow.FindControl("txtParticularsFoot")).Text;
                    SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
                    SqlDataSource2.InsertParameters["SessionId"].DefaultValue = sId;
                    SqlDataSource2.InsertParameters["ProformaInvNo"].DefaultValue = ProformaInvNo;
                    SqlDataSource2.InsertParameters["InvDate"].DefaultValue = InvDate;
                    SqlDataSource2.InsertParameters["PONo"].DefaultValue = PONo;
                    SqlDataSource2.InsertParameters["Amount"].DefaultValue = Amount.ToString();
                    SqlDataSource2.InsertParameters["Particular"].DefaultValue = Particular;
                    SqlDataSource2.InsertParameters["Types"].DefaultValue = "1";
                    SqlDataSource2.Insert();
                }
            }
            if (e.CommandName == "Add1")
            {

                if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text != "")
                {
                    ProformaInvNo = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Text;
                    InvDate = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Text;
                    PONo = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPo")).Text;
                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtparticul")).Text;

                    SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
                    SqlDataSource2.InsertParameters["SessionId"].DefaultValue = sId;
                    SqlDataSource2.InsertParameters["ProformaInvNo"].DefaultValue = ProformaInvNo;
                    SqlDataSource2.InsertParameters["InvDate"].DefaultValue = InvDate;
                    SqlDataSource2.InsertParameters["PONo"].DefaultValue = PONo;
                    SqlDataSource2.InsertParameters["Amount"].DefaultValue = Amount.ToString();
                    SqlDataSource2.InsertParameters["Particular"].DefaultValue = Particular;
                    SqlDataSource2.InsertParameters["Types"].DefaultValue = "1";
                    SqlDataSource2.Insert();

                }
            }
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string ProformaInvNo = "";
            string InvDate = "";
            string PONo = "";
            double Amount = 0;
            string Particular = "";
            if (((TextBox)row.FindControl("txtAmount")).Text != "" && ((TextBox)row.FindControl("txtAmount")).Text != "0" && fun.NumberValidationQty(((TextBox)row.FindControl("txtAmount")).Text) == true)
            {
                ProformaInvNo = ((TextBox)row.FindControl("txtProforInvNo")).Text;
                Amount = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N3"));
                InvDate = ((TextBox)row.FindControl("textDate")).Text;
                PONo = ((TextBox)row.FindControl("txtPoNo")).Text;
                Particular = ((TextBox)row.FindControl("txtParticulars")).Text;
                SqlDataSource2.UpdateParameters["CompId"].DefaultValue = CompId.ToString();
                SqlDataSource2.UpdateParameters["SessionId"].DefaultValue = sId;
                SqlDataSource2.UpdateParameters["ProformaInvNo"].DefaultValue = ProformaInvNo;
                SqlDataSource2.UpdateParameters["InvDate"].DefaultValue = InvDate;
                SqlDataSource2.UpdateParameters["PONo"].DefaultValue = PONo;
                SqlDataSource2.UpdateParameters["Amount"].DefaultValue = Amount.ToString();
                SqlDataSource2.UpdateParameters["Particular"].DefaultValue = Particular;
                SqlDataSource2.Update();

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();

        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {

            double Amount = 0;
            string Particular = "";

            if (e.CommandName == "Add")
            {

                if (((TextBox)GridView2.FooterRow.FindControl("txtAmountFoot")).Text != "")
                {

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView2.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView2.FooterRow.FindControl("txtParticularsFoot")).Text;
                    string StrAddSal = fun.insert("tblACC_Advice_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + Amount + "','" + Particular + "','" + CompId + "','" + sId + "','2'");
                    SqlCommand cmd11 = new SqlCommand(StrAddSal, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Salary();
                }
            }
            if (e.CommandName == "Add1")
            {

                if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAmt")).Text != "")
                {

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtparticul")).Text;

                    string StrAddSal = fun.insert("tblACC_Advice_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + Amount + "','" + Particular + "','" + CompId + "','" + sId + "','2'");
                    SqlCommand cmd11 = new SqlCommand(StrAddSal, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Salary();

                }
            }
        }
        catch (Exception ex) { }

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index1 = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[index1];
            int id1 = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            double Amount = 0;
            string Particular = "";
            if (((TextBox)row.FindControl("txtAmount")).Text != "" && ((TextBox)row.FindControl("txtAmount")).Text != "0" && fun.NumberValidationQty(((TextBox)row.FindControl("txtAmount")).Text) == true)
            {
                Amount = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N3"));
                Particular = ((TextBox)row.FindControl("txtParticulars")).Text;
                string StrUpdateSal = fun.update("tblACC_Advice_Payment_Temp", "Amount='" + Amount + "', Particular='" + Particular + "',CompId='" + CompId + "',SessionId='" + sId + "'", "Id='" + id1 + "'");
                SqlCommand cmd11 = new SqlCommand(StrUpdateSal, con);
                con.Open();
                cmd11.ExecuteNonQuery();
                con.Close();
                GridView2.EditIndex = -1;
                this.FillGrid_Salary();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();

        }
    }

    protected void btnProceed_Sal_Click(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            string PayTo = fun.getCode(txtPayTo_Sal.Text);
            string cmdStr = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_Advice_Payment_Master");
            string ADNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                ADNo = bvno.ToString("D4");
            }
            else
            {
                ADNo = "0001";
            }
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, 1, CompId);
            string sql5 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='2'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId == 1 && TxtChequeNo_Sal.Text != "" && TxtChequeDate_Sal.Text != "" && txtPayAt_Sal.Text != "" && txtPayTo_Sal.Text != "" && fun.DateValidation(TxtChequeDate_Sal.Text) == true)
                {
                    string StrBVPMaster = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + ADNo + "','2','" + PayTo + "','" + TxtChequeNo_Sal.Text + "','" + fun.FromDate(TxtChequeDate_Sal.Text) + "','" + txtPayAt_Sal.Text + "','" + DropDownList2.SelectedValue + "','1'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + ADNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_Advice_Payment_Details", "MId,Particular,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='2'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
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
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Records are not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex) { }


    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {

            double Amount = 0;
            string Particular = "";
            string withinGr = "";
            string WONO = "";
            int BGGroup = 1;
            if (e.CommandName == "Add")
            {

                int u = 0;
                if (((RadioButtonList)GridView3.FooterRow.FindControl("RadioButtonWONoGroupF")).SelectedValue == "0")
                {

                    if (fun.CheckValidWONo(((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text, CompId, FinYearId) == true && ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text != "")
                    {
                        WONO = ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text;
                    }
                    else
                    {
                        u++;
                    }
                }
                else
                {

                    BGGroup = Convert.ToInt32(((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).SelectedValue);
                }

                if (((TextBox)GridView3.FooterRow.FindControl("txtAmountFoot")).Text != "" && ((TextBox)GridView3.FooterRow.FindControl("txtwithingrFt")).Text != "" && u == 0)
                {

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView3.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
                    withinGr = ((TextBox)GridView3.FooterRow.FindControl("txtwithingrFt")).Text;
                    Particular = ((TextBox)GridView3.FooterRow.FindControl("txtParticularsFoot")).Text;
                    string StrBVP_Temp = fun.insert("tblACC_Advice_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + Amount + "','" + Particular + "','" + WONO + "','" + BGGroup + "','" + withinGr + "'");
                    SqlCommand cmd11 = new SqlCommand(StrBVP_Temp, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Other();
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Invalid WONo.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            if (e.CommandName == "Add1")
            {
                int u = 0;
                if (((RadioButtonList)GridView3.Controls[0].Controls[0].FindControl("RadioButtonWONoGroup")).SelectedValue == "0")
                {
                    if (fun.CheckValidWONo(((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text, CompId, FinYearId) == true && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text != "")
                    {
                        WONO = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text;
                    }
                    else
                    {
                        u++;
                    }

                }
                else
                {

                    BGGroup = Convert.ToInt32(((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).SelectedValue);
                }
                if (((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text != "" && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text != "" && u == 0)
                {

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtparticul")).Text;
                    withinGr = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text;
                    string StrBVP_Temp = fun.insert("tblACC_Advice_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + Amount + "','" + Particular + "','" + WONO + "','" + BGGroup + "','" + withinGr + "'");
                    SqlCommand cmd11 = new SqlCommand(StrBVP_Temp, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Other();
                }
            }
        }
        catch (Exception ex) { }
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            int index1 = GridView3.EditIndex;
            GridViewRow row = GridView3.Rows[index1];
            int id1 = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            double Amount = 0;
            string Particular = "";
            string withinGr = "";
            string WONO = "";
            int BGGroup = 1;
            int u = 0;
            if (((RadioButtonList)row.FindControl("RadioButtonWONoGroupE")).SelectedValue == "0")
            {


                if (((TextBox)row.FindControl("txtWONoE")).Text != "")
                {
                    if (fun.CheckValidWONo(((TextBox)row.FindControl("txtWONoE")).Text, CompId, FinYearId) == true)
                    {
                        WONO = ((TextBox)row.FindControl("txtWONoE")).Text;
                    }
                    else
                    {
                        u++;

                    }

                }
                else
                {
                    u++;

                }

            }
            else
            {

                BGGroup = Convert.ToInt32(((DropDownList)row.FindControl("drpGroupE")).SelectedValue);
            }

            if (((TextBox)row.FindControl("txtAmount")).Text != "" && ((TextBox)row.FindControl("txtwithGr")).Text != "" && u == 0)
            {
                Amount = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N3"));
                Particular = ((TextBox)row.FindControl("txtParticulars")).Text;
                withinGr = ((TextBox)row.FindControl("txtwithGr")).Text;
                string UpdateCommand = "UPDATE [tblACC_Advice_Payment_Temp] SET [Amount] = '" + Amount + "', [Particular] = '" + Particular + "', [CompId] ='" + CompId + "', [SessionId] ='" + sId + "',[WONo]='" + WONO + "' ,[BG]='" + BGGroup + "',[WithinGroup]='" + withinGr + "' WHERE [Id] = '" + id1 + "'";
                SqlCommand cmd11 = new SqlCommand(UpdateCommand, con);
                con.Open();
                cmd11.ExecuteNonQuery();
                con.Close();
                GridView3.EditIndex = -1;
                this.FillGrid_Other();
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Invalid Input.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }


        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();

        }
    }
    protected void RadioButtonWONoGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((RadioButtonList)GridView3.Controls[0].Controls[0].FindControl("RadioButtonWONoGroup")).SelectedValue == "0")
        {
            ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Visible = true;
            ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).Visible = false;
        }
        else
        {
            ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Visible = false;
            ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).Visible = true;
        }

    }
    protected void btnProceed_Oth_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            string PayTo = fun.getCode(txtPayTo_Others.Text);
            string cmdStr = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string ADNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                ADNo = bvno.ToString("D4");
            }
            else
            {
                ADNo = "0001";
            }
            int CodeType = Convert.ToInt32(drptypeOther.SelectedValue);
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, CodeType, CompId);
            string sql5 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='3'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId == 1 && txtChqNo.Text != "" && txtChq_Date.Text != "" && txtpayAt_oth.Text != "" && txtPayTo_Others.Text != "" && fun.DateValidation(txtChq_Date.Text) == true && CodeType != 0)
                {
                    string StrBVPMaster = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + ADNo + "','3','" + PayTo + "','" + txtChqNo.Text + "','" + fun.FromDate(txtChq_Date.Text) + "','" + txtpayAt_oth.Text + "','" + DropDownList3.SelectedValue + "','" + CodeType + "'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + ADNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_Advice_Payment_Details", "MId,Particular,Amount,WONo,BG,WithinGroup", "'" + MId + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "','" + DS5.Tables[0].Rows[p]["WONo"].ToString() + "','" + Convert.ToInt32(DS5.Tables[0].Rows[p]["BG"].ToString()) + "','" + DS5.Tables[0].Rows[p]["WithinGroup"].ToString() + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='3'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Other();
                    txtPayTo_Others.Text = string.Empty;
                    txtChqNo.Text = string.Empty;
                    txtpayAt_oth.Text = string.Empty;
                    txtChq_Date.Text = string.Empty;

                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid data entry.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Records are not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex) { }


    }
    protected void RadioButtonWONoGroupF_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((RadioButtonList)GridView3.FooterRow.FindControl("RadioButtonWONoGroupF")).SelectedValue == "0")
        {
            ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Visible = true;
            ((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).Visible = false;
        }
        else
        {
            ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Visible = false;
            ((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).Visible = true;
        }


    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView3.EditIndex = e.NewEditIndex;
            this.FillGrid_Other();
            int index = GridView3.EditIndex;
            GridViewRow grv = GridView3.Rows[index];
            int id = Convert.ToInt32(((Label)grv.FindControl("lblIdE")).Text);
            string sql5 = fun.select("BG,WONo", "tblACC_Advice_Payment_Temp", "Id='" + id + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);
            if (DS5.Tables[0].Rows.Count > 0)
            {
                if (DS5.Tables[0].Rows[0]["WONo"].ToString() != "" && DS5.Tables[0].Rows[0]["WONo"] != DBNull.Value)
                {
                    ((RadioButtonList)grv.FindControl("RadioButtonWONoGroupE")).SelectedValue = "0";

                    ((TextBox)grv.FindControl("txtWONoE")).Text = DS5.Tables[0].Rows[0]["WONo"].ToString();

                }
                else
                {
                    ((RadioButtonList)grv.FindControl("RadioButtonWONoGroupE")).SelectedValue = "1";
                    ((DropDownList)grv.FindControl("drpGroupE")).Visible = true;
                    ((TextBox)grv.FindControl("txtWONoE")).Visible = false;
                    ((DropDownList)grv.FindControl("drpGroupE")).SelectedValue = DS5.Tables[0].Rows[0]["BG"].ToString();

                }
            }
        }
        catch (Exception ex)
        { }

    }
    protected void RadioButtonWONoGroupE_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButtonList x = (RadioButtonList)sender;
            GridViewRow grv = (GridViewRow)x.NamingContainer;
            if (((RadioButtonList)grv.FindControl("RadioButtonWONoGroupE")).SelectedValue == "0")
            {
                ((TextBox)grv.FindControl("txtWONoE")).Visible = true;
                ((DropDownList)grv.FindControl("drpGroupE")).Visible = false;
            }
            else
            {
                ((TextBox)grv.FindControl("txtWONoE")).Visible = false;
                ((DropDownList)grv.FindControl("drpGroupE")).Visible = true;
            }
        }

        catch (Exception ex)
        { }

    }
    public void FillGrid_Other()
    {
        try
        {

            DataTable dt = new DataTable();
            string str = "SELECT [tblACC_Advice_Payment_Temp].Id,Amount,Particular, (Case When WONo!='' then WONo Else 'NA' END)As WONo, [BusinessGroup].Symbol As BG,WithinGroup FROM [tblACC_BankVoucher_Payment_Temp] Inner Join [BusinessGroup] on [tblACC_BankVoucher_Payment_Temp].BG=[BusinessGroup].Id And ([SessionId] ='" + sId + "') AND ([CompId] ='" + CompId + "') And ([Types]=3)";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            GridView3.DataSource = DSCustWo;
            GridView3.DataBind();
            foreach (GridViewRow grv in GridView3.Rows)
            {

                string wono1 = ((Label)grv.FindControl("lblWONo")).Text;
                string bg = ((Label)grv.FindControl("lblBG")).Text;
                if (wono1 != "NA" && bg != "NA")
                {

                    ((RadioButtonList)grv.FindControl("RadioButtonWONoGroup1")).SelectedValue = "0";

                }
                else if (wono1 == "NA")
                {
                    ((RadioButtonList)grv.FindControl("RadioButtonWONoGroup1")).SelectedValue = "1";

                }
            }

        }

        catch (Exception ex)
        { }


    }


    public void FillGrid_Salary()
    {
        try
        {

            DataTable dt = new DataTable();

            string str = "SELECT * FROM tblACC_Advice_Payment_Temp WHERE SessionId ='" + sId + "'AND CompId = '" + CompId + "' And Types=2";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            GridView2.DataSource = DSCustWo;
            GridView2.DataBind();

        }

        catch (Exception ex)
        { }


    }

    public void FillGrid_Creditors()
    {
        try
        {

            DataTable dt = new DataTable();
            string GetSupCode = fun.getCode(txtPayTo_Credit.Text);
            string str = "SELECT tblACC_BillBooking_Master.PVEVNo, tblACC_BillBooking_Master.BillNo,tblACC_BillBooking_Master.Id ,tblACC_BillBooking_Master.BillDate,tblMM_PO_Master.PONo, tblACC_BillBooking_Details.GQNId, tblACC_BillBooking_Details.GSNId FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId =tblACC_BillBooking_Master.Id INNER JOIN tblMM_PO_Master ON tblACC_BillBooking_Master.POId = tblMM_PO_Master.Id And tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "'";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);

            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new System.Data.DataColumn("ActAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("PaidAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("BalAmt", typeof(double)));
            DataRow dr;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();

                dr[0] = DSCustWo.Tables[0].Rows[i]["PVEVNo"].ToString();
                double ActAmt = 0;
                if (Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["GQNId"]) != 0)
                {
                    string StrGQNQty = "SELECT tblQc_MaterialQuality_Details.AcceptedQty FROM         tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id And tblQc_MaterialQuality_Details.MId='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["GQNId"]) + "' ";
                    SqlCommand cmd = new SqlCommand(StrGQNQty, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    da.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        ActAmt = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[0][0].ToString()).ToString("N3"));

                    }


                }

                if (Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["GSNId"]) != 0)
                {
                    string StrGSNQty = "SELECT tblinv_MaterialServiceNote_Details.ReceivedQty FROM         tblinv_MaterialServiceNote_Details INNER JOIN tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id And tblinv_MaterialServiceNote_Details.MId='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["GSNId"]) + "' ";
                    SqlCommand cmd = new SqlCommand(StrGSNQty, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    da.Fill(DS);
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        ActAmt = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[0][0].ToString()).ToString("N3"));
                    }

                }

                dr[1] = DSCustWo.Tables[0].Rows[i]["BillNo"].ToString();
                dr[2] = fun.FromDateDMY(DSCustWo.Tables[0].Rows[i]["BillDate"].ToString());
                dr[5] = ActAmt;
                dr[3] = DSCustWo.Tables[0].Rows[i]["PONo"].ToString();
                dr[4] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();

                string sqlAmt = fun.select("Sum(Amount)As Amt", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND PVEVNO='" + DSCustWo.Tables[0].Rows[i]["Id"].ToString() + "'");
                SqlCommand cmd5 = new SqlCommand(sqlAmt, con);
                SqlDataAdapter dastk5 = new SqlDataAdapter(cmd5);
                DataSet dsstk5 = new DataSet();
                dastk5.Fill(dsstk5);
                if (dsstk5.Tables[0].Rows.Count > 0 && dsstk5.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                {
                    dr[6] = Convert.ToDouble(decimal.Parse((dsstk5.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));

                }
                else
                {
                    dr[6] = 0;
                }

                double DtlsAmt = 0;
                string sqlAmt2 = " Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.PVEVNO='" + DSCustWo.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type=4";
                SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                SqlDataAdapter dastk6 = new SqlDataAdapter(cmd6);
                DataSet dsstk6 = new DataSet();
                dastk6.Fill(dsstk6);
                if (dsstk6.Tables[0].Rows.Count > 0 && dsstk6.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                {
                    DtlsAmt = Convert.ToDouble(decimal.Parse((dsstk6.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));

                }

                dr[7] = (ActAmt - (Convert.ToDouble(dr[6]) + DtlsAmt));
                if ((ActAmt - (Convert.ToDouble(dr[6]) + DtlsAmt)) > 0)
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView4.DataSource = dt;
            GridView4.DataBind();
            this.GetValidate();
        }

        catch (Exception ex)
        { }


    }

    public void FillGrid_Creditors_Temp()
    {
        try
        {

            DataTable dt = new DataTable();

            string str = fun.select("*", "tblACC_Advice_Payment_Creditor_Temp", "SessionId='" + sId + "' And CompId='" + CompId + "'");
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new System.Data.DataColumn("BillAgainst", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ActAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("BalAmt", typeof(double)));
            DataRow dr;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();
                double ActAmt = 0;
                double PaidAmt = 0;

                string str2 = "SELECT tblACC_BillBooking_Master.PVEVNo,tblACC_BillBooking_Details.GQNId, tblACC_BillBooking_Details.GSNId FROM tblACC_BillBooking_Master INNER JOIN tblACC_BillBooking_Details ON tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId And tblACC_BillBooking_Master.Id='" + DSCustWo.Tables[0].Rows[i]["PVEVNO"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(str2, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                da.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DS.Tables[0].Rows[0]["PVEVNo"].ToString();


                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["GQNId"]) != 0)
                    {
                        string StrGQNQty = "SELECT tblQc_MaterialQuality_Details.AcceptedQty FROM         tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id And tblQc_MaterialQuality_Details.MId='" + Convert.ToInt32(DS.Tables[0].Rows[0]["GQNId"]) + "' ";
                        SqlCommand cmd1 = new SqlCommand(StrGQNQty, con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet DS1 = new DataSet();
                        da1.Fill(DS1);

                        if (DS1.Tables[0].Rows.Count > 0)
                        {
                            ActAmt = Convert.ToDouble(decimal.Parse(DS1.Tables[0].Rows[0][0].ToString()).ToString("N3"));

                        }


                    }

                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["GSNId"]) != 0)
                    {
                        string StrGSNQty = "SELECT tblinv_MaterialServiceNote_Details.ReceivedQty FROM         tblinv_MaterialServiceNote_Details INNER JOIN tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id And tblinv_MaterialServiceNote_Details.MId='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["GSNId"]) + "' ";
                        SqlCommand cmd1 = new SqlCommand(StrGSNQty, con);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet DS1 = new DataSet();
                        da1.Fill(DS1);
                        if (DS1.Tables[0].Rows.Count > 0)
                        {
                            ActAmt = Convert.ToDouble(decimal.Parse(DS1.Tables[0].Rows[0][0].ToString()).ToString("N3"));
                        }
                    }

                    string sqlAmt = fun.select("Sum(Amount)As Amt", "tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND PVEVNO='" + DSCustWo.Tables[0].Rows[i]["PVEVNo"].ToString() + "'");
                    SqlCommand cmd5 = new SqlCommand(sqlAmt, con);
                    SqlDataAdapter dastk5 = new SqlDataAdapter(cmd5);
                    DataSet dsstk5 = new DataSet();
                    dastk5.Fill(dsstk5);
                    if (dsstk5.Tables[0].Rows.Count > 0 && dsstk5.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                    {
                        PaidAmt = Convert.ToDouble(decimal.Parse((dsstk5.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));

                    }


                }

                double DtlsAmt = 0;
                string sqlAmt2 = " Select Sum(Amount)As Amt from tblACC_Advice_Payment_Details inner join tblACC_Advice_Payment_Master on tblACC_Advice_Payment_Details.MId=tblACC_Advice_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_Advice_Payment_Details.PVEVNO='" + DSCustWo.Tables[0].Rows[i]["PVEVNO"].ToString() + "' And tblACC_Advice_Payment_Master.Type=4";
                SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                SqlDataAdapter dastk6 = new SqlDataAdapter(cmd6);
                DataSet dsstk6 = new DataSet();
                dastk6.Fill(dsstk6);
                if (dsstk6.Tables[0].Rows.Count > 0 && dsstk6.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                {
                    DtlsAmt = Convert.ToDouble(decimal.Parse((dsstk6.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));

                }
                dr[1] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();
                dr[2] = DSCustWo.Tables[0].Rows[i]["BillAgainst"].ToString();
                dr[3] = Convert.ToDouble(DSCustWo.Tables[0].Rows[i]["Amount"].ToString());
                dr[4] = ActAmt;
                dr[5] = (ActAmt - (PaidAmt + DtlsAmt));
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView5.DataSource = dt;
            GridView5.DataBind();
        }

        catch (Exception ex)
        { }

    }

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillGrid_Other();
        }
        catch (Exception er) { }
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView3.EditIndex = -1;
            this.FillGrid_Other();
        }
        catch (Exception er) { }
    }
    protected void btnProceed_Creditor_Click(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            string PayTo = fun.getCode(txtPayTo_Credit.Text);
            string cmdStr = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string ADNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                ADNo = bvno.ToString("D4");
            }
            else
            {
                ADNo = "0001";
            }

            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, 3, CompId);
            string sql5 = fun.select("*", "tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId == 1 && txtPayTo_Credit.Text != "" && txtChequeNo_Credit.Text != "" && txtPayAt_Credit.Text != "" && txtChequeDate_Credit.Text != "" && fun.DateValidation(txtChequeDate_Credit.Text) == true)
                {
                    string StrBVPMaster = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + ADNo + "','4','" + PayTo + "','" + txtChequeNo_Credit.Text + "','" + fun.FromDate(txtChequeDate_Credit.Text) + "','" + txtPayAt_Credit.Text + "','" + DropDownList4.SelectedValue + "','3'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + ADNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_Advice_Payment_Details", "MId ,PVEVNO ,BillAgainst,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["PVEVNO"].ToString() + "','" + DS5.Tables[0].Rows[p]["BillAgainst"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N3")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
                    con.Close();
                    this.FillGrid_Creditors();
                    this.FillGrid_Creditors_Temp();
                    txtPayTo_Credit.Text = string.Empty;
                    txtChequeNo_Credit.Text = string.Empty;
                    txtPayAt_Credit.Text = string.Empty;
                    txtChequeDate_Credit.Text = string.Empty;


                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid data entry.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Records are not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex) { }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            this.FillGrid_Creditors();
            btnSearch.Visible = false;
            txtPayTo_Credit.Enabled = false;
            btnRefresh.Visible = true;
            Panel5.Visible = true;
            this.FillGrid_Creditors_Temp();
        }
        catch(Exception)
        {
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.FillGrid_Creditors();
        btnSearch.Visible = true;
        txtPayTo_Credit.Enabled = true;
        txtPayTo_Credit.Text = "";
        btnRefresh.Visible = false;
        Panel5.Visible = false;
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] Sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr2 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'");
        SqlDataAdapter da2 = new SqlDataAdapter(cmdStr2, con);
        da2.Fill(ds, "tblMM_Supplier_master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 15)
                //    break;
            }

        }

        Array.Sort(main);
        return main;
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] Sql2(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr2 = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'");
        SqlDataAdapter da2 = new SqlDataAdapter(cmdStr2, con);
        da2.Fill(ds, "tblHR_OfficeStaff");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 15)
                //    break;
            }

        }

        Array.Sort(main);
        return main;
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();

        try
        {
            if (e.CommandName == "AddToTemp")
            {


                int y = 0;
                int x = 0;
                int k = 0;
                foreach (GridViewRow grv in GridView4.Rows)
                {
                    if (((CheckBox)grv.FindControl("ck")).Checked == true)
                    {
                        x++;
                        if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("txtBill_Against")).Text != "" && ((TextBox)grv.FindControl("txtAmount")).Text != "" && fun.NumberValidationQty(((TextBox)grv.FindControl("txtAmount")).Text) == true && Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text) != 0)
                        {
                            double Amount = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtAmount")).Text).ToString("N3"));
                            double BalAmt = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblBalAmt")).Text).ToString("N3"));


                            if (BalAmt >= Amount)
                            {
                                y++;
                            }

                        }
                    }
                }

                if (x == y && y > 0)
                {



                    foreach (GridViewRow grv in GridView4.Rows)
                    {
                        if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("txtBill_Against")).Text != "" && ((TextBox)grv.FindControl("txtAmount")).Text != "" && fun.NumberValidationQty(((TextBox)grv.FindControl("txtAmount")).Text) == true)
                        {

                            double Amount = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtAmount")).Text).ToString("N3"));
                            double BalAmt = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblBalAmt")).Text).ToString("N3"));
                            string BillAgainst = ((TextBox)grv.FindControl("txtBill_Against")).Text;
                            int PVEVNo = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                            if (BalAmt >= Amount)
                            {

                                SqlCommand exeme2 = new SqlCommand(fun.insert("tblACC_Advice_Payment_Creditor_Temp", "CompId,SessionId,PVEVNO,BillAgainst,Amount", "'" + CompId + "','" + sId + "','" + PVEVNo + "','" + BillAgainst + "','" + Amount + "'"), con);
                                exeme2.ExecuteNonQuery();
                                k++;

                            }

                        }
                    }
                }

                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid input data.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }

                if (k > 0)
                {
                    this.FillGrid_Creditors();
                    this.FillGrid_Creditors_Temp();
                }

            }



        }
        catch (Exception ex) { }
        finally
        { con.Close(); }
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView5.PageIndex = e.NewPageIndex;
        this.FillGrid_Creditors_Temp();
    }
    protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView5.EditIndex = e.NewEditIndex;
        this.FillGrid_Creditors_Temp();
    }
    protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView5.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Creditor_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillGrid_Creditors_Temp();
        }
        catch (Exception er) { }
    }
    protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView5.EditIndex = -1;
            this.FillGrid_Creditors_Temp();
        }
        catch (Exception er) { }
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql3(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        int CodeType = Convert.ToInt32(HttpContext.Current.Session["codetype"]);

        switch (CodeType)
        {
            case 1:
                {
                    string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' Order By EmployeeName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "tblHR_OfficeStaff");
                }
                break;

            case 2:
                {
                    string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' Order By CustomerName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "SD_Cust_master");
                }
                break;

            case 3:
                {
                    string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' Order By SupplierName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "tblMM_Supplier_master");
                }
                break;

        }

        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 15)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }


    protected void drptype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Session["codetype"] = drptype.SelectedValue;
        TextBox1.Text = string.Empty;
    }
    protected void drptypeOther_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codetype1"] = drptypeOther.SelectedValue;
        txtPayTo_Others.Text = string.Empty;
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillGrid_Salary();
        }
        catch (Exception er) { }
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.FillGrid_Salary();
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView2.EditIndex = -1;
            this.FillGrid_Salary();
        }
        catch (Exception er) { }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.FillGrid_Salary();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        this.FillGrid_Other();
    }

    public void dropdownCompany(DropDownList dpdlCompany)
    {
        try
        {
            DataSet DS = new DataSet();
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string cmdStr = fun.select1("Id,Description", "tblACC_ReceiptAgainst");
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "tblACC_ReceiptAgainst");
            dpdlCompany.DataSource = DS.Tables[0];
            dpdlCompany.DataTextField = "Description";
            dpdlCompany.DataValueField = "Id";
            dpdlCompany.DataBind();
            dpdlCompany.Items.Insert(0, "Select");
        }
        catch (Exception ex) { }

    }

    public void Loaddata()
    {
       try
        {

            DataTable dt = new DataTable();
            string StrSql = fun.select("*", "tblACC_Advice_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'");
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            DataSet DSSql = new DataSet();
            daSql.Fill(DSSql);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ADRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Types", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ReceivedFrom", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("InvoiceNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeReceivedBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BankName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BankAccNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeClearanceDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Narration", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));

            DataRow dr;
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (DSSql.Tables[0].Rows.Count > 0)
                {

                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSSql.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);
                    dr[0] = DSSql.Tables[0].Rows[i]["Id"].ToString();
                    if (DSFin.Tables[0].Rows.Count > 0)
                    {
                        dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                    }
                    dr[2] = DSSql.Tables[0].Rows[i]["ADRNo"].ToString();

                    string Sqltyp = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + DSSql.Tables[0].Rows[i]["Types"].ToString() + "'");
                    SqlCommand cmdtyp = new SqlCommand(Sqltyp, con);
                    SqlDataAdapter datyp = new SqlDataAdapter(cmdtyp);
                    DataSet DStyp = new DataSet();
                    datyp.Fill(DStyp);
                    if (DStyp.Tables[0].Rows.Count > 0)
                    {
                        dr[3] = DStyp.Tables[0].Rows[0]["Description"].ToString();
                    }
                    dr[4] = DSSql.Tables[0].Rows[i]["ReceivedFrom"].ToString();
                    dr[5] = DSSql.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    dr[6] = DSSql.Tables[0].Rows[i]["ChequeNo"].ToString();
                    dr[7] = fun.FromDateDMY(DSSql.Tables[0].Rows[i]["ChequeDate"].ToString());
                    dr[8] = fun.EmpCustSupplierNames(1, DSSql.Tables[0].Rows[i]["ChequeReceivedBy"].ToString(), CompId);
                    dr[9] = DSSql.Tables[0].Rows[i]["BankName"].ToString();
                    dr[10] = DSSql.Tables[0].Rows[i]["BankAccNo"].ToString();
                    dr[11] = fun.FromDateDMY(DSSql.Tables[0].Rows[i]["ChequeClearanceDate"].ToString());
                    dr[12] = (DSSql.Tables[0].Rows[i]["Narration"].ToString());
                    dr[13] = Convert.ToDouble(DSSql.Tables[0].Rows[i]["Amount"]);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            GridView6.DataSource = dt;
            GridView6.DataBind();
        }
        catch (Exception ex) { }

    }
    protected void TxtSubmit_Click(object sender, EventArgs e)
    {

        try
        {


            string Strpvevno = fun.select("ADRNo", "tblACC_Advice_Received_Masters", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by ADRNo desc");

            SqlCommand cmdpvevno = new SqlCommand(Strpvevno, con);
            SqlDataAdapter DApvevno = new SqlDataAdapter(cmdpvevno);
            DataSet DSpvevno = new DataSet();
            DApvevno.Fill(DSpvevno, "tblACC_Advice_Received_Masters");
            string PVEVNo = "";

            if (DSpvevno.Tables[0].Rows.Count > 0)
            {
                PVEVNo = (Convert.ToInt32(DSpvevno.Tables[0].Rows[0]["ADRNo"]) + 1).ToString("D4");
            }
            else
            {
                PVEVNo = "0001";
            }
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string ReceivedBy = fun.getCode(TxtReceived.Text);

            int EmpSupId = fun.chkEmpCustSupplierCode(ReceivedBy, 1, CompId);


            con.Open();
          if (EmpSupId == 1 && fun.DateValidation(TxtChequeDate.Text) == true && fun.DateValidation(TxtClearanceDate.Text) == true && fun.NumberValidationQty(TxtAmount.Text) == true && DrpTypes.SelectedValue != "0")
            {
                string sqlbill = fun.insert("tblACC_Advice_Received_Masters", "SysDate,SysTime,SessionId,CompId,FinYearId, ADRNo, Types , ReceivedFrom  ,InvoiceNo , ChequeNo, ChequeDate, ChequeReceivedBy, BankName, BankAccNo , ChequeClearanceDate , Narration, Amount ", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + PVEVNo + "','" + DrpTypes.SelectedValue + "','" + TxtFrom.Text + "','" + TxtInvoiceNo.Text + "','" + TxtChequeNo.Text + "','" + fun.FromDate(TxtChequeDate.Text) + "','" + ReceivedBy + "','" + TxtBank.Text + "','" + TxtBankAccNo.Text + "','" + fun.FromDate(TxtClearanceDate.Text) + "','" + TxtNarration.Text + "','" + Convert.ToDouble(decimal.Parse((TxtAmount.Text).ToString()).ToString("N2")) + "'");
                SqlCommand cmdbill = new SqlCommand(sqlbill, con);
                cmdbill.ExecuteNonQuery();
                con.Close();
                //Response.Write(sqlbill);
                TxtChequeDate.Text = string.Empty;
                TxtClearanceDate.Text = string.Empty;
                TxtAmount.Text = string.Empty;
                TxtNarration.Text = string.Empty;
                TxtBank.Text = string.Empty;
                TxtReceived.Text = string.Empty;
                TxtFrom.Text = string.Empty;
                TxtBankAccNo.Text = string.Empty;
                TxtInvoiceNo.Text = string.Empty;
                TxtChequeNo.Text = string.Empty;
                DrpTypes.SelectedIndex = 0;
                this.Loaddata();
            }
          else
          {

              string mystring = string.Empty;
              mystring = "Input data is invalid.";
              ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);

          }

        }

        catch (Exception ex)
        {

        }
    }
    protected void DrpTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpTypes.SelectedValue == "5")
        {
            TxtInvoiceNo.Visible = false;

        }
        else
        {
            TxtInvoiceNo.Visible = true;
        }

    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            try
            { 
                con.Open();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Id = ((Label)row.FindControl("lblId")).Text;
                string Str = fun.delete("tblACC_Advice_Received_Masters", " Id='" + Id + "'");
                SqlCommand cmd = new SqlCommand(Str, con);
                cmd.ExecuteNonQuery();
                this.Loaddata();
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }


    }
}

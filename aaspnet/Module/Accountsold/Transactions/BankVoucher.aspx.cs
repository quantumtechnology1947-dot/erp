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
using System.Collections.Generic;

public partial class Module_Accounts_Transactions_BankVoucher : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";
    string CDate = "";
    string CTime = "";
    string GetSupCode ="";
    double actamt = 0;
    double balamt = 0;
    int bankAdvId = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            connStr = fun.Connection();
            GetSupCode = fun.getCode(txtPayTo_Credit.Text);
            con = new SqlConnection(connStr);
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();           
            if (!Page.IsPostBack)
            {
                
                string cmdStr = fun.select1("Particulars,Id ", "tblACC_PaidType");
                SqlCommand cmdt = new SqlCommand(cmdStr, con);
                SqlDataAdapter DAt = new SqlDataAdapter(cmdt);
                DataSet DSt = new DataSet();
                DAt.Fill(DSt);
                DrpPaid.DataSource = DSt;
                DrpPaid.DataTextField = "Particulars";
                DrpPaid.DataValueField = "Id";
                DrpPaid.DataBind();
                DrpPaid.Items.Insert(0, "Select");
                DrpPaid_Adv.DataSource = DSt;
                DrpPaid_Adv.DataTextField = "Particulars";
                DrpPaid_Adv.DataValueField = "Id";
                DrpPaid_Adv.DataBind();
                DrpPaid_Adv.Items.Insert(0, "Select");
                lblgetbal.Text = "0";                
                SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Creditor_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                this.FillGrid_Other();
                this.FillGrid_Creditors_Temp();
                this.FillGrid_Salary();
                this.FillGrid_Creditors();
                this.dropdownCompany(DrpTypes);
                this.FillGridTemp_Adv();
            }
           
        }
        catch (Exception ex)
        {
        }
    }

    public void FillGridTemp_Adv()
    {
        try
        {

            DataTable dt = new DataTable();
            string str = "SELECT * FROM [tblACC_BankVoucher_Payment_Temp] WHERE (([SessionId] ='"+sId+"') AND ([CompId] ='"+CompId+"') And ([Types]=1)) order by Id Desc";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            GridView1.DataSource = DSCustWo;
            GridView1.DataBind();
            this.EnableDisable();
        }

        catch (Exception ex)
        { }
    

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
            string cmdStr = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string BVPNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                BVPNo = bvno.ToString("D4");
            }
            else
            {
                BVPNo = "0001";
            }
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, Convert.ToInt32(drptype.SelectedValue), CompId);

            string sql5 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" +sId + "' And Types='1'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                string paidtype = string.Empty;
                Lblsupid_Adv.Text = fun.getCode(TextBox1.Text); 
                if (Lblsupid_Adv.Text != string.Empty && DrpPaid_Adv.SelectedValue == "Select")
                {
                    paidtype = Lblsupid_Adv.Text;
                   
                }
                else if (DrpPaid_Adv.SelectedValue != "Select")
                {

                    paidtype = DrpPaid_Adv.SelectedValue;
                    
                }


              
                string Nameoncheque = "";
                if (Rdbtncheck_Adv.Checked == true)
                {
                    if (txtNameOnchq_Adv.Text != "")
                    {
                        Nameoncheque = txtNameOnchq_Adv.Text;
                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        myStringVariable = "please fill the textbox name on cheque .";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                    }

                }
                else if (Rdbtncheck1_Adv.Checked == true)
                {
                    Nameoncheque = "";
                }


                if (EmpSupId == 1 && TextBox1.Text != "" && txtDDNo.Text != ""  && textChequeDate.Text != "" && fun.DateValidation(textChequeDate.Text) == true && drptype.SelectedValue!="0")
                {
                    string StrBVPMaster = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAtCountry,PayAtState,PayAtCity,Bank,ECSType,AddAmt,TransactionType,PaidType,NameOnCheque", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + BVPNo + "','1','" + PayTo + "','" + txtDDNo.Text + "','" + fun.FromDate(textChequeDate.Text) + "','" + DDListNewRegdCountry_Adv.SelectedValue + "','" + DDListNewRegdState_Adv.SelectedValue + "','" + DDListNewRegdCity_Adv.SelectedValue + "','" + DropDownList1.SelectedValue + "','" + Convert.ToInt32(drptype.SelectedValue) + "','" + Txtaddcharg_Adv.Text + "','" + Rdbtncrtrtype_Adv.SelectedValue + "','"+paidtype+"','"+Nameoncheque+"'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + BVPNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_BankVoucher_Payment_Details", "MId ,ProformaInvNo ,InvDate,PONo,Particular,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["ProformaInvNo"].ToString() + "','" + fun.FromDate(DS5.Tables[0].Rows[p]["InvDate"].ToString()) + "','" + DS5.Tables[0].Rows[p]["PONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='1'");
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
            double Amount = 0;
            string Particular = "";
            if (e.CommandName == "Add")
            {

                if (((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text != "")
                {
                    ProformaInvNo = ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Text;
                    InvDate = ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Text;
                    string PO = string.Empty;
                    CheckBoxList ckb = ((CheckBoxList)GridView1.FooterRow.FindControl("CBLPOList2"));
                    foreach (ListItem listitem in ckb.Items)
                    {
                        if (listitem.Selected)
                        {
                            PO += listitem.Text + ",";
                        }
                    }

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView1.FooterRow.FindControl("txtParticularsFoot")).Text;
                    SqlCommand exeme2 = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo,InvDate,PONo,Amount,Particular,SessionId,CompId,Types", "'" + ProformaInvNo + "','" + InvDate + "','" + PO + "','" + Amount + "','" + Particular + "','" + sId + "','" + CompId + "',1"), con);
                    con.Open();
                    exeme2.ExecuteNonQuery();
                    con.Close();
                    this.FillGridTemp_Adv();


                }

            }
            if (e.CommandName == "Add1")
            {

                if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text != "")
                {
                    ProformaInvNo = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Text;
                    InvDate = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Text;
                    string PO = string.Empty;
                    CheckBoxList ckb = ((CheckBoxList)GridView1.Controls[0].Controls[0].FindControl("CBLPOList"));
                    foreach (ListItem listitem in ckb.Items)
                    {
                        if (listitem.Selected)
                        {
                            PO += listitem.Text + ",";
                        }
                    }

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtparticul")).Text;
                    SqlCommand exeme2 = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo,InvDate,PONo,Amount,Particular,SessionId,CompId,Types", "'" + ProformaInvNo + "','" + InvDate + "','" + PO + "','" + Amount + "','" + Particular + "','" + sId + "','" + CompId + "',1"), con);
                    con.Open();
                    exeme2.ExecuteNonQuery();
                    con.Close();
                    this.FillGridTemp_Adv();

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
                SqlCommand exeme2 = new SqlCommand(fun.update("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo='"+ProformaInvNo+"',InvDate='"+InvDate+"',PONo='"+PONo+"',Amount='"+Amount+"',Particular='"+Particular+"',SessionId='"+sId+"'","Id='"+id1+"'"), con);
                con.Open();
                exeme2.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                this.FillGridTemp_Adv();               
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
                    string StrAddSal = fun.insert("tblACC_BankVoucher_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + Amount + "','" + Particular + "','" + CompId + "','" + sId + "','2'");
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

                    string StrAddSal = fun.insert("tblACC_BankVoucher_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + Amount + "','" + Particular + "','" + CompId + "','" + sId + "','2'");
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
                string StrUpdateSal = fun.update("tblACC_BankVoucher_Payment_Temp", "Amount='"+Amount+"', Particular='"+Particular+"',CompId='"+CompId+"',SessionId='"+sId+"'", "Id='"+id1+"'");
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
            string cmdStr = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string BVPNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                BVPNo = bvno.ToString("D4");
            }
            else
            {
                BVPNo = "0001";
            }
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, 1, CompId);
            string sql5 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='2'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId==1 && TxtChequeNo_Sal.Text != "" && TxtChequeDate_Sal.Text != "" && txtPayAt_Sal.Text != "" && txtPayTo_Sal.Text != "" && fun.DateValidation(TxtChequeDate_Sal.Text) == true)
                {
                    string StrBVPMaster = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + BVPNo + "','2','" + PayTo + "','" + TxtChequeNo_Sal.Text + "','" + fun.FromDate(TxtChequeDate_Sal.Text) + "','" + txtPayAt_Sal.Text + "','" + DropDownList2.SelectedValue + "','1'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + BVPNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_BankVoucher_Payment_Details", "MId,Particular,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='2'");
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
                if (((RadioButtonList)GridView3.FooterRow.FindControl("RadioButtonWONoGroupF")).SelectedValue == "0" )
                {

                    if (fun.CheckValidWONo(((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text, CompId, FinYearId) == true &&  ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text != "")
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
                    string StrBVP_Temp = fun.insert("tblACC_BankVoucher_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + Amount + "','" + Particular + "','" + WONO + "','" + BGGroup + "','" + withinGr + "'");
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
                if (((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text != "" && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text != "" && u==0)
                {

                    Amount = Convert.ToDouble(decimal.Parse(((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
                    Particular = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtparticul")).Text;
                    withinGr = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text;
                    string StrBVP_Temp = fun.insert("tblACC_BankVoucher_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + Amount + "','" + Particular + "','" + WONO + "','" + BGGroup + "','" + withinGr + "'");
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
            string WONO ="";
            int BGGroup = 1;
            int u = 0;
            if (((RadioButtonList)row.FindControl("RadioButtonWONoGroupE")).SelectedValue == "0" )
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
                string UpdateCommand = "UPDATE [tblACC_BankVoucher_Payment_Temp] SET [Amount] = '"+Amount+"', [Particular] = '"+Particular+"', [CompId] ='"+CompId+"', [SessionId] ='"+sId+"',[WONo]='"+WONO+"' ,[BG]='"+BGGroup+"',[WithinGroup]='"+withinGr+"' WHERE [Id] = '"+id1+"'";
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
            string cmdStr = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string BVPNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                BVPNo = bvno.ToString("D4");
            }
            else
            {
                BVPNo = "0001";
            }
            int CodeType = Convert.ToInt32(drptypeOther.SelectedValue);
            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, CodeType, CompId);
            string sql5 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='3'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                if (EmpSupId == 1 && txtChqNo.Text != "" && txtChq_Date.Text != "" && txtpayAt_oth.Text != "" && txtPayTo_Others.Text != "" && fun.DateValidation(txtChq_Date.Text) == true && CodeType!=0)
                {
                    string StrBVPMaster = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + BVPNo + "','3','" + PayTo + "','" + txtChqNo.Text + "','" + fun.FromDate(txtChq_Date.Text) + "','" + txtpayAt_oth.Text + "','" + DropDownList3.SelectedValue + "','"+CodeType+"'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + BVPNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_BankVoucher_Payment_Details", "MId,Particular,Amount,WONo,BG,WithinGroup", "'" + MId + "','" + DS5.Tables[0].Rows[p]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "','" + DS5.Tables[0].Rows[p]["WONo"].ToString() + "','" + Convert.ToInt32(DS5.Tables[0].Rows[p]["BG"].ToString()) + "','" + DS5.Tables[0].Rows[p]["WithinGroup"].ToString() + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='3'");
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
            string sql5 = fun.select("BG,WONo", "tblACC_BankVoucher_Payment_Temp", "Id='" + id + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);
            if (DS5.Tables[0].Rows.Count > 0)
            {
                if (DS5.Tables[0].Rows[0]["WONo"].ToString() != "" && DS5.Tables[0].Rows[0]["WONo"]!=DBNull.Value)
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
            string str = "SELECT [tblACC_BankVoucher_Payment_Temp].Id,Amount,Particular, (Case When WONo!='' then WONo Else 'NA' END)As WONo, [BusinessGroup].Symbol As BG,WithinGroup FROM [tblACC_BankVoucher_Payment_Temp] Inner Join [BusinessGroup] on [tblACC_BankVoucher_Payment_Temp].BG=[BusinessGroup].Id And ([SessionId] ='"+sId+"') AND ([CompId] ='"+CompId+"') And ([Types]=3)";
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
            string str = "SELECT * FROM tblACC_BankVoucher_Payment_Temp WHERE SessionId ='"+sId+"'AND CompId = '"+CompId+"' And Types=2";
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
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
       
        try
        {
            
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();           
            con.Open();
           
            {
                 string sId = Session["username"].ToString();
                int FinYearId = Convert.ToInt32(Session["finyear"]);
                int CompId = Convert.ToInt32(Session["compid"]);              
                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//0
                dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));//1
                dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));//2
                dt.Columns.Add(new System.Data.DataColumn("BillNo", typeof(string)));//3
                dt.Columns.Add(new System.Data.DataColumn("BillDate", typeof(string)));//4                
                dt.Columns.Add(new System.Data.DataColumn("ActAmt", typeof(double)));//5
                dt.Columns.Add(new System.Data.DataColumn("PaidAmt", typeof(double)));//7
                dt.Columns.Add(new System.Data.DataColumn("BalAmt", typeof(string)));//8               

                string StrSql_M = fun.select("tblACC_BillBooking_Master.Id ,tblACC_BillBooking_Master.SessionId ,tblACC_BillBooking_Master.AuthorizeBy,tblACC_BillBooking_Master.AuthorizeDate, tblACC_BillBooking_Master.SysDate , tblACC_BillBooking_Master.SysTime  , tblACC_BillBooking_Master.SessionId, tblACC_BillBooking_Master.CompId , tblACC_BillBooking_Master.FinYearId, tblACC_BillBooking_Master.PVEVNo, tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.BillNo, tblACC_BillBooking_Master.BillDate , tblACC_BillBooking_Master.CENVATEntryNo, tblACC_BillBooking_Master.CENVATEntryDate, tblACC_BillBooking_Master.OtherCharges, tblACC_BillBooking_Master.OtherChaDesc, tblACC_BillBooking_Master.Narration , tblACC_BillBooking_Master.DebitAmt , tblACC_BillBooking_Master.DiscountType, tblACC_BillBooking_Master.Discount", "tblACC_BillBooking_Master", "tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "' And tblACC_BillBooking_Master.CompId='" + CompId + "' And tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' ");
                SqlCommand cmdSql_M = new SqlCommand(StrSql_M, con);
                SqlDataAdapter daSql_M = new SqlDataAdapter(cmdSql_M);
                DataSet DSSql_M = new DataSet();
                daSql_M.Fill(DSSql_M);
                DataSet BillBook = new DataSet();
                
                for (int i2 = 0; i2 < DSSql_M.Tables[0].Rows.Count; i2++)
                {   
                    DataRow dr;
                    dr = dt.NewRow();

                    string StrSql = fun.select(" tblACC_BillBooking_Details.PODId, tblACC_BillBooking_Details.GQNId,tblACC_BillBooking_Details.GSNId, tblACC_BillBooking_Details.ItemId,tblACC_BillBooking_Details.PFAmt,tblACC_BillBooking_Details.ExStBasicInPer ,tblACC_BillBooking_Details.ExStEducessInPer ,tblACC_BillBooking_Details.ExStShecessInPer,tblACC_BillBooking_Details.ExStBasic ,tblACC_BillBooking_Details.ExStEducess ,tblACC_BillBooking_Details.ExStShecess ,tblACC_BillBooking_Details.CustomDuty ,tblACC_BillBooking_Details.VAT ,tblACC_BillBooking_Details.CST ,tblACC_BillBooking_Details.Freight ,tblACC_BillBooking_Details.TarrifNo,tblACC_BillBooking_Details.DebitType,tblACC_BillBooking_Details.DebitValue,tblACC_BillBooking_Details.BCDValue,tblACC_BillBooking_Details.EdCessOnCDValue,tblACC_BillBooking_Details.SHEDCessValue", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", "tblACC_BillBooking_Master.CompId='" + CompId + "' And tblACC_BillBooking_Details.MId='" + DSSql_M.Tables[0].Rows[i2]["Id"] + "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "'");
                    SqlCommand cmdSql = new SqlCommand(StrSql, con);
                    SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
                    DataSet DSSql = new DataSet();
                    daSql.Fill(DSSql);   
                
                    string PONOGroup = string.Empty;
                    //List<int> listPO = new List<int>();
                    double CalCulatedAmt = 0;

                    

                    for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
                    {   
                                        
                        double Discount = 0;                        
                        double PfAmt = 0;
                        double freight = 0;
                        double ExStBasic = 0;
                        double ExStEducess = 0;
                        double ExStShecess = 0;
                        double VAT = 0;
                        double CST = 0;
                        double Amt = 0;
                        double Rate = 0;
                        double AccQty = 0;
                        double BCD = 0;
                        double EdCessOnCD = 0;
                        double SHEDCess = 0;
               
                            string StrSql11 = fun.select("tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + DSSql.Tables[0].Rows[i]["PODId"].ToString() + "' AND   tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + CompId + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
                            SqlCommand cmdPo11 = new SqlCommand(StrSql11, con);
                            SqlDataAdapter DAPo11 = new SqlDataAdapter(cmdPo11);
                            DataSet DSSql11 = new DataSet();
                            DAPo11.Fill(DSSql11);

                            if (DSSql11.Tables[0].Rows.Count > 0)
                            {
                                Rate = Convert.ToDouble(decimal.Parse((DSSql11.Tables[0].Rows[0]["Rate"]).ToString()).ToString("N2"));
                                Discount = Convert.ToDouble(decimal.Parse((DSSql11.Tables[0].Rows[0]["Discount"]).ToString()).ToString("N2"));
                                
                            }

                            if (DSSql.Tables[0].Rows[i]["GQNId"].ToString() != "0")
                            {
                                string Strgqn = fun.select("Sum(tblQc_MaterialQuality_Details.AcceptedQty) As AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + DSSql.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
                                SqlCommand cmdgqn = new SqlCommand(Strgqn, con);
                                SqlDataAdapter dagqn = new SqlDataAdapter(cmdgqn);
                                DataSet DSgqn = new DataSet();
                                dagqn.Fill(DSgqn);
                                
                                if (DSgqn.Tables[0].Rows.Count > 0)
                                {  
                                    AccQty = Convert.ToDouble(DSgqn.Tables[0].Rows[0]["AcceptedQty"]);
                                    Amt = ((Rate - (Rate * Discount) / 100) * AccQty);
                                    
                                }                               

                            }
                            else if (DSSql.Tables[0].Rows[i]["GSNId"].ToString() != "0")
                            {
                                string Strgsn = fun.select("Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As ReceivedQty ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + DSSql.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");

                                SqlCommand cmdgsn = new SqlCommand(Strgsn, con);
                                SqlDataAdapter dagsn = new SqlDataAdapter(cmdgsn);
                                DataSet DSgsn = new DataSet();
                                dagsn.Fill(DSgsn);
                                if (DSgsn.Tables[0].Rows.Count > 0)
                                { 
                                    AccQty = Convert.ToDouble(DSgsn.Tables[0].Rows[0]["ReceivedQty"]);
                                    Amt = ((Rate - (Rate * Discount) / 100) * AccQty);
                                    
                                }
                                
                            }                           
                                PfAmt = Convert.ToDouble(DSSql.Tables[0].Rows[i]["PFAmt"]);                           
                                ExStBasic = Convert.ToDouble(DSSql.Tables[0].Rows[i]["ExStBasic"]);
                                ExStEducess = Convert.ToDouble(DSSql.Tables[0].Rows[i]["ExStEducess"]);
                                ExStShecess = Convert.ToDouble(DSSql.Tables[0].Rows[i]["ExStShecess"]);                          
                                VAT= Convert.ToDouble(DSSql.Tables[0].Rows[i]["VAT"]);
                                CST = Convert.ToDouble(DSSql.Tables[0].Rows[i]["CST"]);
                                freight= Convert.ToDouble(DSSql.Tables[0].Rows[i]["Freight"]); 

                            string Strpo = fun.select("distinct(tblMM_PO_Master.PONo)", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + CompId + "' And tblMM_PO_Details.Id='" + DSSql.Tables[0].Rows[i]["PODId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
                            SqlCommand cmdpo = new SqlCommand(Strpo, con);
                            SqlDataAdapter dapo = new SqlDataAdapter(cmdpo);
                            DataSet DSpo = new DataSet();
                            dapo.Fill(DSpo);
                            if (DSpo.Tables[0].Rows.Count > 0)
                            {
                                PONOGroup += DSpo.Tables[0].Rows[0][0].ToString()+", "; 

                                //listPO.Add(DSpo.Tables[0].Rows[0][0].ToString()+',');
                            }                            

                            double DebitAmt = Convert.ToDouble(DSSql_M.Tables[0].Rows[i2]["DebitAmt"]);
                            double CalBasicAmt = 0;
                            
                            switch (Convert.ToInt32(DSSql_M.Tables[0].Rows[i2]["DiscountType"]))
                            {
                                case 0:
                                    CalBasicAmt = Amt - DebitAmt;
                                    break;
                                case 1:
                                    CalBasicAmt = Amt - (Amt * DebitAmt / 100);
                                    break;
                                case 2:
                                    CalBasicAmt = Amt;
                                    break;
                            }
                            
                            BCD = Convert.ToDouble(DSSql.Tables[0].Rows[i]["BCDValue"]);
                            EdCessOnCD = Convert.ToDouble(DSSql.Tables[0].Rows[i]["EdCessOnCDValue"]);
                            SHEDCess = Convert.ToDouble(DSSql.Tables[0].Rows[i]["SHEDCessValue"]);   

                            CalCulatedAmt += CalBasicAmt + PfAmt + VAT + CST + freight + ExStShecess + ExStEducess + ExStBasic+BCD+EdCessOnCD+SHEDCess;                                               
                    }

                    dr[0] = DSSql_M.Tables[0].Rows[i2]["Id"].ToString();
                    dr[1] = DSSql_M.Tables[0].Rows[i2]["PVEVNo"].ToString();
                    dr[2] = PONOGroup;
                    actamt += CalCulatedAmt;
                    //List<string> listPO2= new List<string>();

                    //listPO2 = fun.removeDuplicates(listPO);
                    //for (int a = 0; a < listPO2.Count;a++ )
                    //{
                    //    PONOGroup += listPO2[a];
                    //}

                    //dr[2] = PONOGroup;
                    dr[3] = DSSql_M.Tables[0].Rows[i2]["BillNo"].ToString();
                    dr[4] = fun.FromDateDMY(DSSql_M.Tables[0].Rows[i2]["BillDate"].ToString());
                    dr[5] = CalCulatedAmt;
                    double DtlsAmtTemp = 0;
                    string sqlAmt = fun.select("Sum(Amount)As Amt", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND PVEVNO='" + DSSql_M.Tables[0].Rows[i2]["Id"].ToString() + "'");
                    SqlCommand cmd5 = new SqlCommand(sqlAmt, con);
                    SqlDataAdapter dastk5 = new SqlDataAdapter(cmd5);
                    DataSet dsstk5 = new DataSet();
                    dastk5.Fill(dsstk5);

                    if (dsstk5.Tables[0].Rows.Count > 0 && dsstk5.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                    {
                        DtlsAmtTemp = Convert.ToDouble(decimal.Parse((dsstk5.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));
                        
                    }
                    else
                    {
                        dr[6] = 0;
                    }

                    double DtlsAmt = 0;
                    string sqlAmt2 = " Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.PVEVNO='" + DSSql_M.Tables[0].Rows[i2]["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type=4";
                    SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                    SqlDataAdapter dastk6 = new SqlDataAdapter(cmd6);
                    DataSet dsstk6 = new DataSet();
                    dastk6.Fill(dsstk6);
                    if (dsstk6.Tables[0].Rows.Count > 0 && dsstk6.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                    {
                        DtlsAmt = Convert.ToDouble(decimal.Parse((dsstk6.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));

                    }

                    dr[6] = Math.Round(((DtlsAmtTemp + DtlsAmt)), 5); 
                    double BAlAmt=0;
                    BAlAmt=Math.Round((CalCulatedAmt - (DtlsAmtTemp + DtlsAmt)),5);
                    dr[7] = BAlAmt;
                    balamt += BAlAmt;
                    if (BAlAmt > 0)
                    {
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }  
                GridView4.DataSource = dt;
                GridView4.DataBind();
                this.GetValidate();                
            }
            
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
            con.Dispose();
        }

    } 
   
    public void FillGrid_Creditors_Temp()
    {
      try
        {           

            string str = fun.select("tblACC_BankVoucher_Payment_Creditor_Temp.Id,BillAgainst,Amount,tblACC_BillBooking_Master.PVEVNo", "tblACC_BankVoucher_Payment_Creditor_Temp,tblACC_BillBooking_Master", "tblACC_BankVoucher_Payment_Creditor_Temp.SessionId='" + sId + "' And tblACC_BankVoucher_Payment_Creditor_Temp.CompId='" + CompId + "' And tblACC_BankVoucher_Payment_Creditor_Temp.PVEVNo=tblACC_BillBooking_Master.Id");
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            GridView5.DataSource = DSCustWo;
            GridView5.DataBind();
        }

        catch (Exception ex)
        { }

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillGridTemp_Adv();
        }
        catch (Exception er) { }
    }

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
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
            string cmdStr = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_BankVoucher_Payment_Master");
            string BVPNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int bvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                BVPNo = bvno.ToString("D4");
            }
            else
            {
                BVPNo = "0001";
            }

            int EmpSupId = fun.chkEmpCustSupplierCode(PayTo, 3, CompId);
            string sql5 = fun.select("*", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0||Convert.ToDouble(txtPayment.Text)>0)
            {
                double OpeningQty = 0;
                double PaidAmt = 0;
                double PayAmount = 0;
                string paidtype = "";
                OpeningQty = Convert.ToDouble(lblgetbal.Text);
                PaidAmt = fun.getTotPay(CompId, GetSupCode, FinYearId);
                PayAmount = Convert.ToDouble(txtPayment.Text);

                if (Lblsupid.Text != string.Empty && DrpPaid.SelectedValue=="Select")
                {
                    paidtype = Lblsupid.Text;
                }
                else if (DrpPaid.SelectedValue != "Select")
                {

                    paidtype = DrpPaid.SelectedValue;
                }


                string Nameoncheque = "";


                if (Rdbtncheck.Checked == true)
                {
                    if (Txtnameoncheque.Text != "")
                    {
                        Nameoncheque = Txtnameoncheque.Text;
                    }
                   
                }
               
                if (EmpSupId == 1 && txtPayTo_Credit.Text != "" && txtChequeNo_Credit.Text != "" && txtChequeDate_Credit.Text != "" && fun.DateValidation(txtChequeDate_Credit.Text) == true && OpeningQty >=(PaidAmt+PayAmount)  )
                {

                    string StrBVPMaster = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,Bank,ECSType,PayAtCountry,PayAtState,PayAtCity,PayAmt,AddAmt,TransactionType,PaidType,NameOnCheque", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + BVPNo + "','4','" + PayTo + "','" + txtChequeNo_Credit.Text + "','" + fun.FromDate(txtChequeDate_Credit.Text) + "','" + DropDownList4.SelectedValue + "','3','" + Convert.ToInt32(DDListNewRegdCountry.SelectedValue) + "','" + Convert.ToInt32(DDListNewRegdState.SelectedValue) + "','" + Convert.ToInt32(DDListNewRegdCity.SelectedValue) + "','" + Convert.ToDouble(txtPayment.Text) + "','" + Txtaddcharges.Text + "','" + Rdbtncrtrtype.SelectedValue + "','" + paidtype + "','"+Nameoncheque+"'");
                    SqlCommand cmd11 = new SqlCommand(StrBVPMaster, con);
                    con.Open();
                  
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + BVPNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {
                        string StrCVPDetails = fun.insert("tblACC_BankVoucher_Payment_Details", "MId ,PVEVNO ,BillAgainst,Amount", "'" + MId + "','" + DS5.Tables[0].Rows[p]["PVEVNO"].ToString() + "','" + DS5.Tables[0].Rows[p]["BillAgainst"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N3")) + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
                    con.Close(); 
                    GetSupCode = string.Empty;
                    this.FillGrid_Creditors();
                    this.FillGrid_Creditors_Temp();
                    txtPayTo_Credit.Text = string.Empty;
                    txtChequeNo_Credit.Text = string.Empty;
                    txtChequeDate_Credit.Text = string.Empty;
                    txtPayment.Text = "0";
                    lblPaid.Text = "0";
                    lblgetbal.Text = "0";

                    
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

        
      Lblsupid.Text=  fun.getCode(txtPayTo_Credit.Text);
       
        string strCredit = "SELECT tblACC_Creditors_Master.OpeningAmt FROM tblACC_Creditors_Master where tblACC_Creditors_Master.SupplierId ='" + GetSupCode + "' And tblACC_Creditors_Master.CompId='" + CompId + "' And tblACC_Creditors_Master.FinYearId<='"+FinYearId+"'";
        SqlCommand cmdCredit = new SqlCommand(strCredit, con);
        SqlDataAdapter DACredit = new SqlDataAdapter(cmdCredit);
        DataSet DSCredit = new DataSet();
        DACredit.Fill(DSCredit);
        double OpeningAmt = 0;
        double closingAmt = 0;
        if (DSCredit.Tables[0].Rows.Count > 0 && DSCredit.Tables[0].Rows[0][0] != DBNull.Value)
        {
            OpeningAmt = Convert.ToDouble(DSCredit.Tables[0].Rows[0]["OpeningAmt"]);
            lblgetbal.Text = OpeningAmt.ToString();
        }
        else
        {
            lblgetbal.Text = OpeningAmt.ToString();
        }
        lblPaid.Text = fun.getTotPay(CompId,GetSupCode,FinYearId).ToString();
        closingAmt = OpeningAmt - fun.getTotPay(CompId, GetSupCode, FinYearId);
        lblClosingAmt.Text = (OpeningAmt - fun.getTotPay(CompId, GetSupCode, FinYearId)).ToString();
        this.FillGrid_Creditors();
        btnSearch.Visible = false;
        txtPayTo_Credit.Enabled = false;
        btnRefresh.Visible = true;
        Panel5.Visible = true;
        this.FillGrid_Creditors_Temp();
        totActAmt.Text = (OpeningAmt  + actamt).ToString();
        totbalAmt.Text = (closingAmt + balamt).ToString();

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Lblsupid.Text = string.Empty;
        this.FillGrid_Creditors();
        btnSearch.Visible = true;
        txtPayTo_Credit.Enabled = true;
        txtPayTo_Credit.Text = "";
        btnRefresh.Visible = false;
        lblgetbal.Text = "0";
        lblPaid.Text = "0";
        lblPayamt.Text = "0";
        Panel5.Visible = false;   
        totActAmt.Text = "0";
        totbalAmt.Text = "0";  
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
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Creditor_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();            
            this.FillGrid_Creditors_Temp();
            FillGrid_Creditors();
            if (GridView5.Rows.Count > 0)
            {
                TabContainer3.ActiveTabIndex = 1;
            }
            else
            {
                TabContainer3.ActiveTabIndex = 0;
            }
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
        int CodeType = 0;
        if (contextKey == "key2")
        {
            CodeType = Convert.ToInt32(HttpContext.Current.Session["codetype"]);
        }
        else
        {
            CodeType = Convert.ToInt32(HttpContext.Current.Session["codetype2"]);
        }

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

        if (drptype.SelectedValue == "3")
        {
            BtnSearch_Adv.Visible = true;
        }
        else
        {
            BtnSearch_Adv.Visible = false;
        }

        this.EnableDisable();
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
            SqlCommand cmd = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + id + " And CompId='" + CompId + "'", con);
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

    protected void TxtSubmit_Click(object sender, EventArgs e)
    {

        try
        {

            string OnWoNo = "";
            string OnDept = "";
            int u = 0;

            if (rdwono.Checked == true && txtwono.Text != "")
            {
                if (fun.CheckValidWONo(txtwono.Text, CompId, FinYearId) == true)
                {
                    OnWoNo = txtwono.Text;
                    u = 1;
                }
            }

            if (rddept.Checked == true)
            {
                OnDept = drpdept.SelectedValue.ToString();
                u = 1;
            }

            if (rddept.Checked == true)
            {
                txtwono.Text = "";
            }

            string Strpvevno = fun.select("BVRNo", "tblACC_BankVoucher_Received_Masters", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by BVRNo desc");

            SqlCommand cmdpvevno = new SqlCommand(Strpvevno, con);
            SqlDataAdapter DApvevno = new SqlDataAdapter(cmdpvevno);
            DataSet DSpvevno = new DataSet();
            DApvevno.Fill(DSpvevno, "tblACC_BankVoucher_Received_Masters");
            string PVEVNo = "";

            if (DSpvevno.Tables[0].Rows.Count > 0)
            {
                PVEVNo = (Convert.ToInt32(DSpvevno.Tables[0].Rows[0]["BVRNo"]) + 1).ToString("D4");
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

            string receivedfrom = "";
            if (drptypeReceipt.SelectedValue != "0" && drptypeReceipt.SelectedValue == "4")
            {

                receivedfrom = TxtFrom.Text;

            }

            else
            {
                receivedfrom = fun.getCode(TxtFrom.Text);
            }

            if (u == 1)
            {
                if (EmpSupId == 1 && fun.DateValidation(TxtChequeDate.Text) == true && fun.DateValidation(TxtClearanceDate.Text) == true && fun.NumberValidationQty(TxtAmount.Text) == true && DrpTypes.SelectedValue != "0" && drptypeReceipt.SelectedValue != "0")
                {
                    string sqlbill = fun.insert("tblACC_BankVoucher_Received_Masters", "SysDate,SysTime,SessionId,CompId,FinYearId, BVRNo, Types, ReceiveType , ReceivedFrom  ,InvoiceNo , ChequeNo, ChequeDate, ChequeReceivedBy, BankName, BankAccNo , ChequeClearanceDate , Narration, Amount,DrawnAt,TransactionType,WONo,BGGroup ", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + PVEVNo + "','" + DrpTypes.SelectedValue + "','" + drptypeReceipt.SelectedValue + "','" + receivedfrom + "','" + TxtInvoiceNo.Text + "','" + TxtChequeNo.Text + "','" + fun.FromDate(TxtChequeDate.Text) + "','" + ReceivedBy + "','" + TxtBank.Text + "','" + TxtBankAccNo.Text + "','" + fun.FromDate(TxtClearanceDate.Text) + "','" + TxtNarration.Text + "','" + Convert.ToDouble(decimal.Parse((TxtAmount.Text).ToString()).ToString("N2")) + "','" + DrpBankName.SelectedValue + "','" + Rdbtncrtrtype_Rec.SelectedValue + "','" + OnWoNo + "','" + OnDept + "'");
                    SqlCommand cmdbill = new SqlCommand(sqlbill, con);
                    cmdbill.ExecuteNonQuery();
                    con.Close();
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
                    txtwono.Text = "";
                }
                else
                {

                    string mystring = string.Empty;
                    mystring = "Input data is invalid.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);

                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "WONo or Dept is not found!";
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
            TxtInvoiceNo.Visible =true;
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
                string Str = fun.delete("tblACC_BankVoucher_Received_Masters", " Id='" + Id + "'");
                SqlCommand cmd = new SqlCommand(Str, con);
                cmd.ExecuteNonQuery();                
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }


    }

    protected void DDListNewRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
        fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
    }
    protected void DDListNewRegdState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
    }


    protected void DDListNewRegdCountry_Adv_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListNewRegdState_Adv, DDListNewRegdCity_Adv, DDListNewRegdCountry_Adv);
        fun.dropdownCity(DDListNewRegdCity_Adv, DDListNewRegdState_Adv);
    }
    protected void DDListNewRegdState_Adv_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListNewRegdCity_Adv, DDListNewRegdState_Adv);
    }

    protected void drptypeReceipt_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codetype2"] = drptypeReceipt.SelectedValue;
        TxtFrom.Text = string.Empty;
    }
    protected void btnAddTemp_Click(object sender, EventArgs e)
    {


        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();

        try
        {
            
                int y = 0;
                int x = 0;
                int k = 0;
                double totActAmt1 = 0;
                double totBalAmt1 = 0;

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
                            totActAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblActAmt")).Text);
                            totBalAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblBalAmt")).Text);

                            string BillAgainst = ((TextBox)grv.FindControl("txtBill_Against")).Text;
                            int PVEVNo = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                            if (BalAmt >= Amount)
                            {

                                SqlCommand exeme2 = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Creditor_Temp", "CompId,SessionId,PVEVNO,BillAgainst,Amount", "'" + CompId + "','" + sId + "','" + PVEVNo + "','" + BillAgainst + "','" + Amount + "'"), con);
                                exeme2.ExecuteNonQuery();
                                k++;


                                totActAmt.Text = Math.Round(totActAmt1 + Convert.ToDouble(lblgetbal.Text), 2).ToString();
                                totbalAmt.Text = Math.Round(totBalAmt1 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();

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
                    //totActAmt.Text ="0";
                    //totbalAmt.Text = "0";
                } 
        }
        catch (Exception ex) { }
        finally
        { con.Close(); }

    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double totActAmt1 = 0;
        double totBalAmt1 = 0;
        double paidAmt1 = 0;
        double totalpaidAmt1 = 0;
        foreach (GridViewRow grv in GridView4.Rows)
        {
            
                totActAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblActAmt")).Text);
                totBalAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblBalAmt")).Text);
                    if (((CheckBox)grv.FindControl("ck")).Checked == true)
                    {

                if (((TextBox)grv.FindControl("txtAmount")).Text != "" && Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text)>0)
                {
                paidAmt1 += Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text);
                }

            }
           
        }
       
        totActAmt.Text = Math.Round(totActAmt1 + Convert.ToDouble(lblgetbal.Text), 2).ToString();      
        totbalAmt.Text = Math.Round(totBalAmt1 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();
        totalpaidAmt1 = Convert.ToDouble(txtPayment.Text) + paidAmt1;
        lblPayamt.Text = totalpaidAmt1.ToString();
        


    }

    protected void ck_CheckedChanged(object sender, EventArgs e)
    {
        double totActAmt1 = 0;
        double totBalAmt1 = 0;
        double paidAmt1 = 0;
        double totalpaidAmt1 = 0;
        foreach (GridViewRow grv in GridView4.Rows)
        {
            totActAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblActAmt")).Text);
                totBalAmt1 += Convert.ToDouble(((Label)grv.FindControl("lblBalAmt")).Text);


                if (((CheckBox)grv.FindControl("ck")).Checked == true)
                {
              
                if (((TextBox)grv.FindControl("txtAmount")).Text != "" && Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text) > 0)
                {
                    paidAmt1 += Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text);
                }

            }


        }

        totActAmt.Text = Math.Round(totActAmt1 + Convert.ToDouble(lblgetbal.Text), 2).ToString();
        totbalAmt.Text = Math.Round(totBalAmt1 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();
        totalpaidAmt1 = Convert.ToDouble(txtPayment.Text) + paidAmt1;
        lblPayamt.Text = totalpaidAmt1.ToString();
        
    
    }

    protected void Rdbtncheck_CheckedChanged(object sender, EventArgs e)
    {
        if (Rdbtncheck.Checked == true)
        {
           
            DrpPaid.Enabled = false;
            Txtnameoncheque.Enabled = true;

        }
    }
    protected void Rdbtncheck1_CheckedChanged(object sender, EventArgs e)
    {
        if (Rdbtncheck1.Checked == true)
        {
           
            DrpPaid.Enabled = true;
            Txtnameoncheque.Enabled = false;
            Txtnameoncheque.Text = string.Empty;

        }
    }

    protected void Rdbtncheck_Adv_CheckedChanged(object sender, EventArgs e)
    {
        if (Rdbtncheck_Adv.Checked == true)
        {

            DrpPaid_Adv.Enabled = false;
            txtNameOnchq_Adv.Enabled = true;

        }
    }
    protected void Rdbtncheck1_Adv_CheckedChanged(object sender, EventArgs e)
    {
        if (Rdbtncheck1_Adv.Checked == true)
        {

            DrpPaid_Adv.Enabled = true;
            txtNameOnchq_Adv.Enabled = false;
            txtNameOnchq_Adv.Text = string.Empty;

        }
    }
    protected void BtnSearch_Adv_Click(object sender, EventArgs e)
    {
        string SupCode=fun.getCode(TextBox1.Text);       
       
        SqlDataSourcePOList.SelectParameters["SupplierId"].DefaultValue= SupCode;        
    }

    public void EnableDisable()
    {
       
        if(drptype.SelectedValue=="0")
        {
            GridView1.Visible = false; 
        }
        else if (drptype.SelectedValue == "3")
        {
             GridView1.Visible = true;
             if (GridView1.Rows.Count == 0)
             {
                 ((Panel)GridView1.Controls[0].Controls[0].FindControl("Panel2")).Visible = true;
                 ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Enabled = true;
                 ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Enabled = true;
             }
             else
             {
                 ((Panel)GridView1.FooterRow.FindControl("Panel21")).Visible = true;
                 ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Enabled = true;
                 ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Enabled = true;
             }
             
        }
        else if (drptype.SelectedValue == "1" || drptype.SelectedValue == "2")
        {
            GridView1.Visible = true;
            if (GridView1.Rows.Count == 0)
            {
                ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Enabled = false;
                ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Enabled = false;
                ((Panel)GridView1.Controls[0].Controls[0].FindControl("Panel2")).Visible = false;
            }
            else
            {
                ((Panel)GridView1.FooterRow.FindControl("Panel21")).Visible = false;
                ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Enabled = false;
                ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Enabled = false;
            }
          
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            this.FillGridTemp_Adv();
        }
        catch (Exception er) { }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.FillGridTemp_Adv();
            int index = GridView1.EditIndex;
            GridViewRow grv = GridView1.Rows[index];
            int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
            DataSet ds = new DataSet();
            con.Open();
            string cmdStr2 = fun.select("ProformaInvNo,InvDate,PONo", "tblACC_BankVoucher_Payment_Temp", "Id='" + id + "'");
            SqlDataAdapter da2 = new SqlDataAdapter(cmdStr2, con);
            da2.Fill(ds, "tblACC_BankVoucher_Payment_Temp");
            con.Close();
            if (ds.Tables[0].Rows[0][0].ToString() != "" && ds.Tables[0].Rows[0][1].ToString() != "" && ds.Tables[0].Rows[0][2].ToString() != "")
            {
                ((TextBox)grv.FindControl("txtPoNo")).Enabled = true;
                ((TextBox)grv.FindControl("txtProforInvNo")).Enabled = true;
                ((TextBox)grv.FindControl("textDate")).Enabled = true;
            }
            else
            {
                ((TextBox)grv.FindControl("txtPoNo")).Enabled = false;
                ((TextBox)grv.FindControl("txtProforInvNo")).Enabled = false;
                ((TextBox)grv.FindControl("textDate")).Enabled = false;
            }
        }
        catch(Exception ex)
        {
        }
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bankAdvId =Convert.ToInt32( DropDownList1.SelectedValue);
        Session["bankAdvId1"] = bankAdvId;
        txtDDNo.Text = string.Empty;
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        bankAdvId = Convert.ToInt32(DropDownList4.SelectedValue);
        Session["bankAdvId1"] = bankAdvId;
        txtChequeNo_Credit.Text = string.Empty;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        bankAdvId = Convert.ToInt32(DropDownList2.SelectedValue);
        Session["bankAdvId1"] = bankAdvId;
        txtChequeNo_Credit.Text = string.Empty;
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        bankAdvId = Convert.ToInt32(DropDownList3.SelectedValue);
        Session["bankAdvId1"] = bankAdvId;
        txtChequeNo_Credit.Text = string.Empty;
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList1(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();

        SqlConnection con = new SqlConnection(connStr);

        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        int Bankid = Convert.ToInt32(HttpContext.Current.Session["bankAdvId1"]);
        string Str = fun.select("StartNo,(EndNo-StartNo)As range", "tblACC_ChequeNo", " BankId='" + Bankid + "'");
        SqlCommand cmd = new SqlCommand(Str, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        int qty = 0;
        string[] main = new string[0];
        for (int i = 0; i <= Convert.ToInt32(ds.Tables[0].Rows[0]["Range"]); i++)
        {
            qty = Convert.ToInt32(ds.Tables[0].Rows[0]["StartNo"]) + i;
            string Sql = fun.select("ChequeNo", "tblACC_BankVoucher_Payment_Master", " CompId='" + CompId + "' And Bank='" + Bankid + "' And  ChequeNo='"+qty+"'");
            SqlCommand cmd2 = new SqlCommand(Sql, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);


                if ( ds2.Tables[0].Rows.Count==0)
                {
                    if (qty.ToString().ToLower().StartsWith(prefixText.ToLower()))
                    {
                        Array.Resize(ref main, main.Length + 1);  
                        main[main.Length - 1] = qty.ToString();
                      
                    }
                }

            
        }
        Array.Sort(main);
        return main;
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[]   Getbank(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select1("Id,Bank", "tblACC_BankReceived_Master");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
               

        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() ;
                //if (main.Length == 15)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }
    
    protected void rddept_CheckedChanged(object sender, EventArgs e)
    {
        txtwono.Text = "";
    }
    protected void rdwono_CheckedChanged(object sender, EventArgs e)
    {
        drpdept.SelectedValue = "1";
    }
}

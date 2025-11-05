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

public partial class Module_Accounts_Transactions_CashVoucher_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    string SId = "";
    int CompId = 0;
    int FinYearId = 0;
    string wono = "";
    string wono1 = "";
     string CDate ="";
     string CTime = "";
     string str = "";
     SqlConnection con ;
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            str = fun.Connection();
            con = new SqlConnection(str);

            if (!IsPostBack)
            {
                this.AcHead();
                this.WONoGroup();
                this.AcHeadR();
                this.WONoGroupR();
                this.FillData();
                this.FillDataRec();
                txtNewCustomerName.Visible = false;
                txtNewCustomerNameRA.Visible = false;
                txtNewCustomerNameRB.Visible = false;

                con.Open();
                string Str = fun.delete("tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
                SqlCommand cmd = new SqlCommand(Str, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
       catch (Exception ex)
        {
        }

            
    }

    //--------------------------------------------------Payment------------------------------------------

    protected void btnPaymentAdd_Click(object sender, EventArgs e)
    {        
        con.Open();
        string WOno = "NA";
        string BGGroup = "1";
        int u = 0;
        int BudgetCode = 0;
        double BalBudgetAmount = 0;
        if (RadioButtonWONoGroup.SelectedValue.ToString() == "0" && txtWONo.Text != "")
        {
            if (fun.CheckValidWONo(txtWONo.Text, CompId, FinYearId) == true)
            {
                WOno = txtWONo.Text;

                if (drpBudgetcode.SelectedItem.Text != "Select")
                {
                    BudgetCode = Convert.ToInt32(drpBudgetcode.SelectedValue);
                    BalBudgetAmount = calbalbud.TotBalBudget_WONO(BudgetCode, CompId, FinYearId, WOno,1);
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Please select BudgetCode!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }

            }
            else
            {
                u++;
            }
        }
        if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
        {
            BGGroup = drpGroup.SelectedValue.ToString();
            BalBudgetAmount = calbalbud.TotBalBudget_BG(Convert.ToInt32(drpGroup.SelectedValue), CompId, FinYearId,1);
            BudgetCode = 0;
        }

        string Sql = fun.select("Sum(Amount) As Amt", "tblACC_CashVoucher_Payment_Temp", "SessionId='" + SId + "'  ");
        SqlCommand Cmd = new SqlCommand(Sql, con);
        SqlDataAdapter Da = new SqlDataAdapter(Cmd);
        DataSet Ds = new DataSet();
        Da.Fill(Ds);
        double Amt = 0;
        if (Ds.Tables[0].Rows[0][0] != DBNull.Value)
        {
            Amt = Convert.ToDouble(Ds.Tables[0].Rows[0][0]);

        }
        string Sql2 = fun.select("Amount", "tblACC_CashAmtLimit", " Active='1'");
        SqlCommand Cmd2 = new SqlCommand(Sql2, con);
        SqlDataAdapter Da2 = new SqlDataAdapter(Cmd2);
        DataSet Ds2 = new DataSet();
        Da2.Fill(Ds2);
        double LimitAmt = 0;
        DataSet ds = new DataSet();
        LimitAmt = Convert.ToDouble(Ds2.Tables[0].Rows[0][0]);
        double txtAmt = Convert.ToDouble(txtAmount.Text);
        string pvevno = "";
        int x = 0;
        pvevno = txtPVEVNO.Text;
        if (txtPVEVNO.Text != "")
        {

            string sql = fun.select("Id", "tblACC_BillBooking_Master", "CompId='" + CompId + "' And  FinYearId='" + FinYearId + "'   And PVEVNo='" + txtPVEVNO.Text + "'     ");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                x = 1;
            }
            else
            {
                x = 0;
            }


        }

        else
        {
            x = 1;
        }
        if (x == 1)
        {

            if (BalBudgetAmount >= (Amt + txtAmt))
            {
                if (LimitAmt >= (Amt + txtAmt))
                {
                    if (u == 0 && txtBillNo.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) == true && txtParticulars.Text != "" && txtAmount.Text != "" && txtAmount.Text != "0" && fun.NumberValidationQty(txtAmount.Text) == true)
                    {
                        string StrPAdd = fun.insert("tblACC_CashVoucher_Payment_Temp", "CompId,SessionId,BillNo,BillDate,PONo,PODate,Particulars,WONo,BGGroup,AcHead,Amount,BudgetCode,PVEVNo", "'" + CompId + "','" + SId + "','" + txtBillNo.Text + "','" + fun.FromDate(textBillDate.Text) + "','" + txtPONo.Text + "','" + fun.FromDate(textPODate.Text) + "','" + txtParticulars.Text + "','" + WOno + "','" + Convert.ToInt32(BGGroup) + "','" + drpAcHead.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtAmount.Text).ToString("N2")) + "','" + BudgetCode + "','" + pvevno + "'");
                        SqlCommand cmdPAdd = new SqlCommand(StrPAdd, con);
                        cmdPAdd.ExecuteNonQuery();
                        con.Close();
                        this.FillData();
                        txtBillNo.Text = "";
                        textBillDate.Text = "";
                        txtPONo.Text = "";
                        textPODate.Text = "";
                        txtParticulars.Text = "";
                        txtAmount.Text = "";
                        txtWONo.Text = "";
                        txtPVEVNO.Text = "";
                        RadioButtonWONoGroup.SelectedValue = "0";
                        RadioButtonAcHead.SelectedValue = "0";
                        this.WONoGroup();
                        this.AcHead();
                        TabContainer1.ActiveTabIndex = 0;
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Invalid input data";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }

                else
                {
                    string mystring = string.Empty;
                    mystring = "Cash voucher Amt exceeds The Cash Limit!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Amt exceeds the balanced budget Amt!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }

        }
        else
        {
            string mystring = string.Empty;
            mystring = "Enter correct PVEV No.!";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
        }


    }

    //protected void btnPaymentAdd_Click(object sender, EventArgs e)
    //{
    //    str = fun.Connection();
    //    con = new SqlConnection(str);

    //    con.Open();
    //    string WOno = "NA";
    //    string BGGroup = "1";
    //    int u = 0;


    //    int BudgetCode = 0;
    //    if (RadioButtonWONoGroup.SelectedValue.ToString() == "0" && txtWONo.Text != "")
    //    {
    //        if (fun.CheckValidWONo(txtWONo.Text, CompId, FinYearId) == true)
    //        {
    //            WOno = txtWONo.Text;
    //            if (drpBudgetcode.SelectedItem.Text != "Select")
    //            {
    //                BudgetCode = Convert.ToInt32(drpBudgetcode.SelectedValue);
    //            }
    //            else
    //            {
    //                string mystring = string.Empty;
    //                mystring = "Please select BudgetCode!";
    //                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
    //            }

    //        }
    //        else
    //        {
    //            u++;              
    //        }
    //    }       
    //    if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
    //    {
    //        BGGroup = drpGroup.SelectedValue.ToString();
    //        BudgetCode = 0;
    //    }

    //    string Sql = fun.select("Sum(Amount) As Amt", "tblACC_CashVoucher_Payment_Temp", "SessionId='" + SId + "'  ");
    //    SqlCommand Cmd = new SqlCommand(Sql,con);
    //    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
    //    DataSet Ds = new DataSet();
    //    Da.Fill(Ds);
    //    double Amt = 0;
    //    if (Ds.Tables[0].Rows[0][0] != DBNull.Value)
    //    {
    //        Amt = Convert.ToDouble(Ds.Tables[0].Rows[0][0]);

    //    }
    //    string Sql2 = fun.select("Amount", "tblACC_CashAmtLimit", " Active='1'");
    //    SqlCommand Cmd2 = new SqlCommand(Sql2, con);
    //    SqlDataAdapter Da2 = new SqlDataAdapter(Cmd2);
    //    DataSet Ds2 = new DataSet();
    //    Da2.Fill(Ds2);
    //    double LimitAmt = 0;
    //    DataSet ds = new DataSet();
    //   LimitAmt = Convert.ToDouble(Ds2.Tables[0].Rows[0][0]);

    //    double txtAmt=Convert.ToDouble(txtAmount.Text);

    //    string pvevno = "";
    //    int x = 0;
    //    pvevno = txtPVEVNO.Text;
    //    if (txtPVEVNO.Text != "")
    //    {

    //        string sql = fun.select("Id", "tblACC_BillBooking_Master", "CompId='" + CompId + "' And  FinYearId='" + FinYearId + "'   And PVEVNo='" + txtPVEVNO.Text + "'     ");
    //        SqlCommand cmd = new SqlCommand(sql, con);
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);

    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            x = 1;
    //        }
    //        else
    //        {
    //            x = 0;
    //        }


    //    }

    //    else
    //    {
    //        x = 1;
    //    }
    //    if (x == 1  )
    //    {

    //        if (LimitAmt >= (Amt + txtAmt))
    //        {
    //            if (u == 0 && txtBillNo.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) == true && txtParticulars.Text != "" && txtAmount.Text != "" && fun.NumberValidationQty(txtAmount.Text) == true)
    //            {
    //                string StrPAdd = fun.insert("tblACC_CashVoucher_Payment_Temp", "CompId,SessionId,BillNo,BillDate,PONo,PODate,Particulars,WONo,BGGroup,AcHead,Amount,BudgetCode,PVEVNo", "'" + CompId + "','" + SId + "','" + txtBillNo.Text + "','" + fun.FromDate(textBillDate.Text) + "','" + txtPONo.Text + "','" + fun.FromDate(textPODate.Text) + "','" + txtParticulars.Text + "','" + WOno + "','" + Convert.ToInt32(BGGroup) + "','" + drpAcHead.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtAmount.Text).ToString("N2")) + "','" + BudgetCode + "','" + pvevno + "'");

    //                SqlCommand cmdPAdd = new SqlCommand(StrPAdd, con);
    //                cmdPAdd.ExecuteNonQuery();
    //                con.Close();
    //                this.FillData();
    //                txtBillNo.Text = "";
    //                textBillDate.Text = "";
    //                txtPONo.Text = "";
    //                textPODate.Text = "";
    //                txtParticulars.Text = "";
    //                txtAmount.Text = "";
    //                txtWONo.Text = "";
    //                txtPVEVNO.Text = "";
    //                RadioButtonWONoGroup.SelectedValue = "0";
    //                RadioButtonAcHead.SelectedValue = "0";
    //                this.WONoGroup();
    //                this.AcHead();
    //                TabContainer1.ActiveTabIndex = 0;
    //            }
    //            else
    //            {
    //                string mystring = string.Empty;
    //                mystring = "Invalid input data";
    //                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
    //            }
    //        }

    //        else
    //        {
    //            string mystring = string.Empty;
    //            mystring = "Cash voucher Amt exceeds The Cash Limit!";
    //            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
    //        }

    //    }
    //    else
    //    {
    //        string mystring = string.Empty;
    //        mystring = "Enter correct PVEV No.!";
    //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
    //    }
       
 
    //}




    public void WONoGroup()
    {
        
        try
        {
            if (RadioButtonWONoGroup.SelectedValue.ToString() == "0")
            {
                wono = txtWONo.Text;
                drpGroup.Visible = false;
                txtWONo.Visible = true;
                RequiredFieldtxtWONo.Visible= true;
                drpBudgetcode.Visible = true;
                LBlBudget.Visible = true;
                ///
                string cmdStrGroup = fun.select1("Description+'['+Symbol+']'  As Description,Id ", " tblMIS_BudgetCode");
                SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                DataSet DSGroup = new DataSet();
                DAGroup.Fill(DSGroup, "tblMIS_BudgetCode");
                drpBudgetcode.DataSource = DSGroup;
                drpBudgetcode.DataTextField = "Description";
                drpBudgetcode.DataValueField = "Id";
                drpBudgetcode.DataBind();
                drpBudgetcode.Items.Insert(0,"Select");


            }
            if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
            {
                LBlBudget.Visible = false;
                drpBudgetcode.Visible = false;
                drpGroup.Visible = true;
                txtWONo.Visible = false;
                txtWONo.Text = "";
                RequiredFieldtxtWONo.Visible = false;               
                string cmdStrGroup = fun.select1("Symbol,Id ", " BusinessGroup");
                SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                DataSet DSGroup = new DataSet();
                DAGroup.Fill(DSGroup, "BusinessGroup");
                drpGroup.DataSource = DSGroup;
                drpGroup.DataTextField = "Symbol";
                drpGroup.DataValueField = "Id";
                drpGroup.DataBind();
            }
        }
         catch (Exception ex) { }
    }
    public void AcHead()
    {
       
        try
        {
            string x = "";
            if (RadioButtonAcHead.SelectedValue.ToString() =="0")
            {
                x = "Labour";
            }

            if (RadioButtonAcHead.SelectedValue.ToString() == "1")
            {
                x = "With Material";              
            }

            if (RadioButtonAcHead.SelectedValue.ToString() == "2")
            {
                x = "Expenses";
            }

            if (RadioButtonAcHead.SelectedValue.ToString() == "3")
            {
                x = "Service Provider";
            }

            string cmdStrLabour = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + x + "'");
            SqlCommand cmdLabour = new SqlCommand(cmdStrLabour, con);
            SqlDataAdapter DALabour = new SqlDataAdapter(cmdLabour);
            
            DataSet DSLabour = new DataSet();
            DALabour.Fill(DSLabour, "AccHead");
            drpAcHead.DataSource = DSLabour;
            drpAcHead.DataTextField = "Head";
            drpAcHead.DataValueField = "Id";
            drpAcHead.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void RadioButtonAcHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.AcHead();
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void RadioButtonWONoGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.WONoGroup();
        TabContainer1.ActiveTabIndex = 0;
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
    
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql1(string prefixText, int count, string contextKey)
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

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql2(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        int CodeType = Convert.ToInt32(HttpContext.Current.Session["codetype2"]);


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

    protected void btnPayProceed_Click(object sender, EventArgs e)
    {
       try
        {
           
            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            string EmpSupCode = fun.getCode(txtNewCustomerName.Text);
            string cmdStr = fun.select("CVPNo", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_CashVoucher_Payment_Master");
            string CVPNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int cvno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                CVPNo = cvno.ToString("D4");
            }
            else
            {
                CVPNo = "0001";
            }

            string sql5 = fun.select("*", "tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {
                int CodeType = Convert.ToInt32(ddlCodeType.SelectedValue);

                int EmpSupId = fun.chkEmpCustSupplierCode(EmpSupCode, CodeType, CompId);
                if (EmpSupId == 1 && txtNewCustomerName.Text != "" && txtPaidTo.Text != "" && ddlCodeType.SelectedValue!="0")
                {
                    string StrCVPMaster = fun.insert("tblACC_CashVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CVPNo,PaidTo,ReceivedBy,CodeType", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + CVPNo + "','" + txtPaidTo.Text + "','" + EmpSupCode + "','"+CodeType+"'");
                    SqlCommand cmd11 = new SqlCommand(StrCVPMaster, con);
                    con.Open();
                    cmd11.ExecuteNonQuery();
                    con.Close();

                    string sqlMId = fun.select("Id", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "' AND CVPNo='" + CVPNo + "' Order By Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    DAMId.Fill(DSMId);
                    string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                    for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                    {

                        string StrCVPDetails = fun.insert("tblACC_CashVoucher_Payment_Details", "MId ,BillNo ,BillDate,PONo,PODate ,Particulars,WONo,BGGroup ,AcHead ,Amount,BudgetCode,PVEVNo", "'" + MId + "','" + DS5.Tables[0].Rows[p]["BillNo"].ToString() + "','" + DS5.Tables[0].Rows[p]["BillDate"].ToString() + "','" + DS5.Tables[0].Rows[p]["PONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["PODate"].ToString() + "','" + DS5.Tables[0].Rows[p]["Particulars"].ToString() + "','" + DS5.Tables[0].Rows[p]["WONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["BGGroup"] + "','" + DS5.Tables[0].Rows[p]["AcHead"] + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Amount"].ToString()).ToString("N2")) + "','" + DS5.Tables[0].Rows[p]["BudgetCode"].ToString() + "','" + DS5.Tables[0].Rows[p]["PVEVNo"].ToString() + "'");
                        SqlCommand cmd15 = new SqlCommand(StrCVPDetails, con);
                        con.Open();
                        cmd15.ExecuteNonQuery();
                        con.Close();
                    }
                    string delsql = fun.delete("tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
                    SqlCommand cmd12 = new SqlCommand(delsql, con);
                    con.Open();
                    cmd12.ExecuteNonQuery();
                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    TabContainer1.ActiveTabIndex = 0;
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
      catch(Exception ex){}
    }
    public void FillData()
    {
       try
        {
           
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("SessionId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PODate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Particulars", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BGGroup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            DataRow dr;

            string sql = "SELECT tblACC_CashVoucher_Payment_Temp.PVEVNo,tblACC_CashVoucher_Payment_Temp.BudgetCode, [tblACC_CashVoucher_Payment_Temp].[Id],[tblACC_CashVoucher_Payment_Temp].[CompId],[tblACC_CashVoucher_Payment_Temp].[SessionId] ,[tblACC_CashVoucher_Payment_Temp].[BillNo],[tblACC_CashVoucher_Payment_Temp].[PONo],[tblACC_CashVoucher_Payment_Temp].[BillDate],tblACC_CashVoucher_Payment_Temp.PODate,[tblACC_CashVoucher_Payment_Temp].[Particulars],[tblACC_CashVoucher_Payment_Temp].[WONo] ,[BusinessGroup].[Symbol] AS [BGGroup], '['+AccHead.Symbol+'] '+AccHead.Description AS AcHead,[Amount]FROM [tblACC_CashVoucher_Payment_Temp]inner join [AccHead] on [tblACC_CashVoucher_Payment_Temp].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on [tblACC_CashVoucher_Payment_Temp].[BGGroup]=[BusinessGroup].[Id]      AND [tblACC_CashVoucher_Payment_Temp].[SessionId]='" + SId + "'  Order by [tblACC_CashVoucher_Payment_Temp].[Id] Desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
            
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();
                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["CompId"].ToString();
                dr[2] = DS.Tables[0].Rows[p]["SessionId"].ToString();
                dr[3] = DS.Tables[0].Rows[p]["BillNo"].ToString();
                dr[4] =fun.FromDateDMY( DS.Tables[0].Rows[p]["BillDate"].ToString());
                if (DS.Tables[0].Rows[p]["PONo"] != DBNull.Value  )
                {
                    dr[5] = DS.Tables[0].Rows[p]["PONo"].ToString();
                }
                if(DS.Tables[0].Rows[p]["PODate"] != DBNull.Value)
                {
                    dr[6] =fun.FromDateDMY( DS.Tables[0].Rows[p]["PODate"].ToString());

                }
                else
                {
                    dr[5] = "NA";
                    dr[6] = "NA";
                }
                dr[7] = DS.Tables[0].Rows[p]["Particulars"].ToString();
                dr[8] = DS.Tables[0].Rows[p]["WONo"].ToString();
                dr[9] = DS.Tables[0].Rows[p]["BGGroup"].ToString();
                dr[10] = DS.Tables[0].Rows[p]["AcHead"].ToString();
                dr[11] = DS.Tables[0].Rows[p]["Amount"].ToString();
                dr[13] = DS.Tables[0].Rows[p]["PVEVNo"].ToString();
          if (Convert.ToInt32(DS.Tables[0].Rows[p]["BudgetCode"]) != 0)
                {
                string sql1 = fun.select("tblMIS_BudgetCode.Description+'['+tblMIS_BudgetCode.Symbol+']'  As Description "," tblMIS_BudgetCode","Id='"+Convert.ToDouble(DS.Tables[0].Rows[p]["BudgetCode"])+"'");

                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                da1.Fill(DS1);
                
                    dr[12] = DS1.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                    dr[12] = "NA";
                }

              
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
     catch (Exception ess)
        { }
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            try
            {
               
                con.Open();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Id = ((Label)row.FindControl("lblId")).Text;

                string Str = fun.delete("tblACC_CashVoucher_Payment_Temp", "Id='" + Id + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'");
                SqlCommand cmd = new SqlCommand(Str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.FillData();
            }
            catch(Exception ex){}
        }
    }

    //--------------------------------------------------Receipt------------------------------------------

    protected void btnReceiptProceed_Click(object sender, EventArgs e)
    {
        try
        {
           
            DataSet DS = new DataSet();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();

            string cmdStr = fun.select("CVRNo", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblACC_CashVoucher_Receipt_Master");
            string CVRNo;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int cvrno = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                CVRNo = cvrno.ToString("D4");
            }
            else
            {
                CVRNo = "0001";
            }

            string CashRecAgainstCode = fun.getCode(txtNewCustomerNameRA.Text);       
            int CodeTypeRA = Convert.ToInt32(ddlCodeTypeRA.SelectedValue);
            int EmpSupIdRA = fun.chkEmpCustSupplierCode(CashRecAgainstCode, CodeTypeRA, CompId);

            string CashRecByCode = fun.getCode(txtNewCustomerNameRB.Text);
            int CodeTypeRB = Convert.ToInt32(ddlCodeTypeRB.SelectedValue);
            int EmpSupIdRB = fun.chkEmpCustSupplierCode(CashRecByCode, CodeTypeRB, CompId);

            string WOno = "NA";
            string BGGroup = "1";
            int u = 0;
            int BudgetCode=0;
            if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "0" && txtWONoRec.Text != "")
            {
                if (fun.CheckValidWONo(txtWONoRec.Text, CompId, FinYearId) == true)
                {
                    WOno = txtWONoRec.Text;
                    BudgetCode=Convert.ToInt32(drpBudgetcode1.SelectedValue);
                }
                else
                {
                    u++;
                }
            }
            if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "1")
            {
                BGGroup = drpGroupRec.SelectedValue.ToString();
            }

            if (EmpSupIdRA == 1 && EmpSupIdRB == 1 && u == 0 && txtAmountRec.Text != "" && txtOthers.Text != "" && txtNewCustomerNameRA.Text != "" && txtNewCustomerNameRB.Text != "" && fun.NumberValidationQty(txtAmountRec.Text) == true)
            {
                string StrCVRMaster = fun.insert("tblACC_CashVoucher_Receipt_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CVRNo,CashReceivedAgainst,CashReceivedBy,WONo,BGGroup,AcHead,Amount,Others,CodeTypeRA,CodeTypeRB,BudgetCode", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + CVRNo + "','" + CashRecAgainstCode + "','" + CashRecByCode + "','" + WOno + "','" + Convert.ToInt32(BGGroup) + "','" + drpAcHeadRec.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtAmountRec.Text).ToString("N2")) + "','" + txtOthers.Text + "','" + CodeTypeRA + "','" + CodeTypeRB + "','"+BudgetCode+"'");
                SqlCommand cmd11 = new SqlCommand(StrCVRMaster, con);
                con.Open();
                cmd11.ExecuteNonQuery();
                con.Close();
                this.FillDataRec();
                txtAmountRec.Text = "";
                txtOthers.Text = "";
                txtNewCustomerNameRA.Text = "";
                txtNewCustomerNameRB.Text = "";
                txtWONoRec.Text = "";
                RadioButtonWONoGroupRec.SelectedValue = "0";
                RadioButtonAcHeadRec.SelectedValue = "0";
                this.WONoGroupR();
                this.AcHeadR();
                TabContainer1.ActiveTabIndex = 1;
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Entered WO No is not valid!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch(Exception ex)
        {
        }
    }
    public void WONoGroupR()
    {
       
        try
        {
            if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "0")
            {
                wono1 = txtWONoRec.Text;
                drpGroupRec.Visible = false;
                txtWONoRec.Visible = true;
                RequiredFieldtxtWONoRec.Visible = true;
                drpBudgetcode1.Visible = true;
                LblBudget1.Visible = true;
                string cmdStrGroup = fun.select1("Description+'['+Symbol+']'  As Description,Id ", " tblMIS_BudgetCode");
                SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                DataSet DSGroup = new DataSet();
                DAGroup.Fill(DSGroup, "tblMIS_BudgetCode");
                drpBudgetcode1.DataSource = DSGroup;
                drpBudgetcode1.DataTextField = "Description";
                drpBudgetcode1.DataValueField = "Id";
                drpBudgetcode1.DataBind();
                drpBudgetcode1.Items.Insert(0, "Select");


            }
            if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "1")
            {
                drpBudgetcode1.Visible = false;
                LblBudget1.Visible = false;
                drpGroupRec.Visible = true;
                txtWONoRec.Visible = false;
                txtWONoRec.Text = "";
                RequiredFieldtxtWONoRec.Visible = false;
                string cmdStrGroup = fun.select1("Symbol,Id ", " BusinessGroup");
                SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                DataSet DSGroup = new DataSet();
                DAGroup.Fill(DSGroup, "BusinessGroup");
                drpGroupRec.DataSource = DSGroup;
                drpGroupRec.DataTextField = "Symbol";
                drpGroupRec.DataValueField = "Id";
                drpGroupRec.DataBind();
            }
        }
      catch (Exception ex) { }
    }
    public void AcHeadR()
    {
       
      try
        {
            string x = "";
            if (RadioButtonAcHeadRec.SelectedValue.ToString() == "0")
            {
                x = "Labour";
            }

            if (RadioButtonAcHeadRec.SelectedValue.ToString() == "1")
            {
                x = "With Material";
            }
            if (RadioButtonAcHeadRec.SelectedValue.ToString() == "2")
            {
                x = "Expenses";
            }

            if (RadioButtonAcHeadRec.SelectedValue.ToString() == "3")
            {
                x = "Service Provider";
            }

            string cmdStrLabour = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + x + "'");
            SqlCommand cmdLabour = new SqlCommand(cmdStrLabour, con);
            SqlDataAdapter DALabour = new SqlDataAdapter(cmdLabour);
            DataSet DSLabour = new DataSet();
            DALabour.Fill(DSLabour, "AccHead");
            drpAcHeadRec.DataSource = DSLabour;
            drpAcHeadRec.DataTextField = "Head";
            drpAcHeadRec.DataValueField = "Id";
            drpAcHeadRec.DataBind();           
        }
      catch (Exception ex) { }
    }
    protected void RadioButtonWONoGroupRec_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.WONoGroupR();
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void RadioButtonAcHeadRec_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.AcHeadR();
        TabContainer1.ActiveTabIndex = 1;
    }
    public void FillDataRec()
    {
        try
        {
           
            con.Open();
            DataTable dt = new DataTable();
          
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SessionId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("CVRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedAgainst", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BGGroup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Others", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CodeTypeRA", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("CodeTypeRB", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));
            DataRow dr;

            string sql = "SELECT tblACC_CashVoucher_Receipt_Master.BudgetCode,[tblACC_CashVoucher_Receipt_Master].[Id],REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblACC_CashVoucher_Receipt_Master].[SysDate] , CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate] ) + 1, 2) + '-' + LEFT([tblACC_CashVoucher_Receipt_Master].[SysDate],CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate]) - 1) + '-' + RIGHT([tblACC_CashVoucher_Receipt_Master].[SysDate], CHARINDEX('-', REVERSE([tblACC_CashVoucher_Receipt_Master].[SysDate])) - 1)), 103), '/', '-') AS  [SysDate],[tblACC_CashVoucher_Receipt_Master].[SysTime],[tblACC_CashVoucher_Receipt_Master].[CompId],[tblACC_CashVoucher_Receipt_Master].[FinYearId],[tblACC_CashVoucher_Receipt_Master].[SessionId],[tblACC_CashVoucher_Receipt_Master].[CVRNo],[tblACC_CashVoucher_Receipt_Master].[CashReceivedAgainst],[tblACC_CashVoucher_Receipt_Master].[CashReceivedBy],[tblACC_CashVoucher_Receipt_Master].[WONo],[BusinessGroup].[Symbol] AS [BGGroup],'['+AccHead.Symbol+'] '+AccHead.Description AS [AcHead],[tblACC_CashVoucher_Receipt_Master].[Amount],[tblACC_CashVoucher_Receipt_Master].[Others],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRA],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRB] FROM [tblACC_CashVoucher_Receipt_Master]inner join [AccHead] on [tblACC_CashVoucher_Receipt_Master].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on[tblACC_CashVoucher_Receipt_Master].[BGGroup]=[BusinessGroup].[Id] Order by [tblACC_CashVoucher_Receipt_Master].[Id] Desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {       
                dr = dt.NewRow();
                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["SysDate"].ToString();
                dr[2] = DS.Tables[0].Rows[p]["SessionId"].ToString();
                dr[3] = DS.Tables[0].Rows[p]["SessionId"].ToString();
                dr[4] = DS.Tables[0].Rows[p]["CompId"].ToString();
                dr[5] = DS.Tables[0].Rows[p]["FinYearId"].ToString();
                dr[6] = DS.Tables[0].Rows[p]["CVRNo"].ToString();

                dr[7] =  fun.EmpCustSupplierNames(Convert.ToInt32(DS.Tables[0].Rows[p]["CodeTypeRA"].ToString()), DS.Tables[0].Rows[p]["CashReceivedAgainst"].ToString(),CompId);
                dr[8] = fun.EmpCustSupplierNames(Convert.ToInt32(DS.Tables[0].Rows[p]["CodeTypeRB"].ToString()), DS.Tables[0].Rows[p]["CashReceivedBy"].ToString(),CompId);

                dr[9] = DS.Tables[0].Rows[p]["WONo"].ToString();
                dr[10] = DS.Tables[0].Rows[p]["BGGroup"].ToString();
                dr[11] = DS.Tables[0].Rows[p]["AcHead"].ToString();
                dr[12] = DS.Tables[0].Rows[p]["Amount"].ToString();
                dr[13] = DS.Tables[0].Rows[p]["Others"].ToString();


                if (Convert.ToInt32(DS.Tables[0].Rows[p]["BudgetCode"]) != 0)
                {
                    string sql1 = fun.select("tblMIS_BudgetCode.Description+'['+tblMIS_BudgetCode.Symbol+']'  As Description ", " tblMIS_BudgetCode", "Id='" + Convert.ToDouble(DS.Tables[0].Rows[p]["BudgetCode"]) + "'");

                  
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet DS1 = new DataSet();
                    da1.Fill(DS1);
                   dr[16] = DS1.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                   dr[16] = "NA";
                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        catch (Exception ess)
        { }
    }

    protected void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codetype"] = ddlCodeType.SelectedValue;        
        if (ddlCodeType.SelectedValue == "0")
        {
            txtNewCustomerName.Visible = false;
            txtNewCustomerName.Text = "";
        }
        else
        {
            txtNewCustomerName.Visible = true;
            txtNewCustomerName.Text = "";
        }
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlCodeTypeRA_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codetype1"] = ddlCodeTypeRA.SelectedValue;
        if (ddlCodeTypeRA.SelectedValue == "0")
        {
            txtNewCustomerNameRA.Visible = false;
            txtNewCustomerNameRA.Text = "";
        }
        else
        {
            txtNewCustomerNameRA.Visible = true;
            txtNewCustomerNameRA.Text = "";
        }
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void ddlCodeTypeRB_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codetype2"] = ddlCodeTypeRB.SelectedValue;
        if (ddlCodeTypeRB.SelectedValue == "0")
        {
            txtNewCustomerNameRB.Visible = false;
            txtNewCustomerNameRB.Text = "";
        }
        else
        {
            txtNewCustomerNameRB.Visible = true;
            txtNewCustomerNameRB.Text = "";
        }
        TabContainer1.ActiveTabIndex = 1;
    }
}




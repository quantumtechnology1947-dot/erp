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

public partial class Module_HR_Transactions_Salary_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    int MonthId = 4;
    string connStr = string.Empty;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            txtDate.Attributes.Add("readonly", "readonly");
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            if (!String.IsNullOrEmpty(Request.QueryString["MonthId"]))
            {
                MonthId = Convert.ToInt32(Request.QueryString["MonthId"]);
            }
            if (!IsPostBack)
            {
                ddlMonth.Items.Clear();
                fun.GetMonth(ddlMonth, CompId, FinYearId);
                ddlMonth.SelectedValue = MonthId.ToString();
            }
            if (RadioButtonList1.SelectedValue == "7" || RadioButtonList1.SelectedValue == "8")
            {
                ddlMonth.Visible = false;
            }
            else
            {
                ddlMonth.Visible = true;
            }
       
            this.loaddata();

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
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND ResignationDate=''");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {


            con.Open();
            string EmpId = string.Empty;
            EmpId = fun.getCode(TxtEmpSearch.Text);
            string MonthId = string.Empty;
            MonthId = ddlMonth.SelectedValue;
            string EType = string.Empty;
            string RadioBValue = RadioButtonList1.SelectedValue;

            string BGGroupId = string.Empty;
            BGGroupId = ddlBGGroup.SelectedValue;


            switch (RadioBValue)
            {
                // Salary Slip
                case "0":
                    if (EmpId != string.Empty && MonthId != string.Empty)
                    {

                        string StrEmp = fun.select("BGGroup", "tblHR_OfficeStaff", "EmpId='" + EmpId + "'");
                        SqlDataAdapter DAEmp = new SqlDataAdapter(StrEmp, con);
                        DataSet DSEmp = new DataSet();
                        DAEmp.Fill(DSEmp, "tblHR_OfficeStaff");
                        if (DSEmp.Tables[0].Rows.Count > 0 && DSEmp.Tables[0].Rows[0]["BGGroup"].ToString() == BGGroupId || BGGroupId == "1")
                        {
                            string getRandomKey = fun.GetRandomAlphaNumeric();

                            string StrLeave = fun.select("Count(*) As Cnt", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + EmpId + "' AND tblHR_Salary_Master.FMonth='" + MonthId + "'");
                            SqlCommand cmdLeave = new SqlCommand(StrLeave, con);                           
                            SqlDataReader rdr = cmdLeave.ExecuteReader();
                            rdr.Read();
                            if (rdr.HasRows == true)
                            {
                                if (Convert.ToDouble(rdr[0]) > 0)
                                {
                                    Response.Redirect("Salary_Print_Details.aspx?EmpId=" + EmpId + "&MonthId=" + MonthId + "&Key=" + getRandomKey + "&BackURL=1&ModId=12&SubModId=133");
                                }
                                else
                                {
                                    string mystring = string.Empty;
                                    mystring = "No Record Found!";
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                                }
                            }
                          
                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Invalid BG Group for this employee";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Invalid Employee Name.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }

                    break;

                // Salary Slip of All Employees
                case "1":
                    if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        Response.Redirect("Salary_Print_ALL.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                // On Cash Report
                case "2":

                    if (MonthId != "")
                    {
                        EType = "2";
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        Response.Redirect("Salary_Neha.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                // Over Time Report
                case "3":
                    if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        Response.Redirect("Salary_Neha_OverTimes.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                // SAPL Summary Report
                case "4":
                    if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        EType = "1";
                        Response.Redirect("Salary_SAPL_Neha_Summary.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                // Neha Summary Report     
                case "5":
                    if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        EType = "2";
                        Response.Redirect("Salary_SAPL_Neha_Summary.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                // Bank Statement
                case "6":

                    string ChequeNo = txtChequeNo.Text;
                    string ChequeDate = txtDate.Text;
                    string BankId = ddlBankName.SelectedValue;
                    string EmpDirect = ddlEmpOrDirect.SelectedValue;

                    if (MonthId != string.Empty && ChequeNo != string.Empty && ChequeDate != string.Empty && fun.DateValidation(ChequeDate) == true)
                    {
                        EType = "2";
                        Response.Redirect("Salary_BankStatement_Check.aspx?ChequeNo=" + ChequeNo + "&ChequeDate=" + ChequeDate + "&BankId=" + BankId + "&EmpDirect=" + EmpDirect + "&BGGroupId=" + BGGroupId + "&MonthId=" + MonthId + "&ModId=12&SubModId=133");
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Invalid Cheque No. or Date.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                    break;

                // All_Month_Summary_Report

                case "7":
                    // if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        EType = "1";
                        Response.Redirect("All_Month_Summary_Report.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;


                // Consolidated_Summary_Report

                case "8":
                    // if (MonthId != "")
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        EType = "1";
                        Response.Redirect("Consolidated_Summary_Report.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;

                case "9":
                    {
                        string getRandomKey = fun.GetRandomAlphaNumeric();
                        EType = "1";
                        Response.Redirect("Salary_SAPL_Summary.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&ModId=12&SubModId=133");
                    }
                    break;
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


    public void loaddata()
    {
        try
        {

            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));//0
            dt.Columns.Add(new System.Data.DataColumn("ChequeNoDate", typeof(string)));//1
            dt.Columns.Add(new System.Data.DataColumn("BankName", typeof(string)));//2          
            dt.Columns.Add(new System.Data.DataColumn("TransNo", typeof(string)));//3
            dt.Columns.Add(new System.Data.DataColumn("BankId", typeof(string)));//4
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(string)));//5

            DataRow dr;

            string StrEmpSal = fun.select("ChequeNo,ChequeNoDate,BankId,EmpDirect,TransNo", "tblHR_Salary_Master", "FMonth ='" + ddlMonth.SelectedValue + "' AND CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND ReleaseFlag='1' Group By ChequeNo,ChequeNoDate,BankId,EmpDirect,TransNo");

            SqlCommand cmdEmpSal = new SqlCommand(StrEmpSal, con);
            SqlDataAdapter daEmpSal = new SqlDataAdapter(cmdEmpSal);
            DataSet DSEmpSal = new DataSet();
            daEmpSal.Fill(DSEmpSal);

            for (int i = 0; i < DSEmpSal.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = DSEmpSal.Tables[0].Rows[i]["ChequeNo"].ToString();
                dr[1] = fun.FromDate(DSEmpSal.Tables[0].Rows[i]["ChequeNoDate"].ToString());


                string strBankName = fun.select("Name", "tblACC_Bank", "Id='" + Convert.ToInt32(DSEmpSal.Tables[0].Rows[i]["BankId"]) + "'");
                SqlCommand cmdBankName = new SqlCommand(strBankName, con);
                SqlDataAdapter DABankName = new SqlDataAdapter(cmdBankName);
                DataSet DSBankName = new DataSet();
                DABankName.Fill(DSBankName, "tblACC_Bank");

                if (DSBankName.Tables[0].Rows.Count > 0)
                {
                    dr[2] = DSBankName.Tables[0].Rows[0]["Name"].ToString();
                }
                dr[3] = DSEmpSal.Tables[0].Rows[i]["TransNo"].ToString();
                dr[4] = DSEmpSal.Tables[0].Rows[i]["BankId"].ToString();
                dr[5] = DSEmpSal.Tables[0].Rows[i]["EmpDirect"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        catch (Exception ex) { }
        finally
        {
            con.Close();
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
         this.loaddata();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            string MonthId = ddlMonth.SelectedValue;
            string BGGroupId = ddlBGGroup.SelectedValue;

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string ChequeNo = ((Label)row.FindControl("lblChequeNo")).Text;
            string ChequeDate = ((Label)row.FindControl("lblChequeNoDate")).Text;
            string BankId = ((Label)row.FindControl("lblBankId")).Text;
            string EmpDirect = ((Label)row.FindControl("lblType")).Text;
            string TransNo = ((Label)row.FindControl("lblTransNo")).Text;

            if (e.CommandName == "Sel")
            {
                Response.Redirect("Salary_BankStatement_CheckEdit.aspx?TransNo=" + TransNo + "&MonthId=" + MonthId + "&ModId=12&SubModId=133");

            }
            if (e.CommandName == "Print")
            {
                string getRandomKey = fun.GetRandomAlphaNumeric();

                Response.Redirect("Salary_BankStatement.aspx?ChequeNo=" + ChequeNo + "&ChequeDate=" + ChequeDate + "&BankId=" + BankId + "&EmpDirect=" + EmpDirect + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "&MonthId=" + MonthId + "&TransNo=" + TransNo + "&ModId=12&SubModId=133");

            }

        }
        catch (Exception ex)
        {
            
        }


    }
}

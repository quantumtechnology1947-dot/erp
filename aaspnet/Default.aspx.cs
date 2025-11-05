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
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net.Mail;
public partial class _Default : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    string connStr = string.Empty;
    SqlConnection conn;
    int CompId = 0;
    string SId = "";
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = fun.Connection();
        conn = new SqlConnection(connStr);
        SId = Session["username"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        if (!IsPostBack)
        {
            ddlMonth.Items.Clear();
            fun.GetMonth(ddlMonth, CompId, FinYearId);
            string CurrDate = DateTime.Now.Month.ToString();
            ddlMonth.SelectedValue = CurrDate;
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        // string cmdStr = fun.insert("tbl_PO_terms", "Terms", "'" + TextBox1.Text + "'");
        // SqlCommand cmd = new SqlCommand(cmdStr, con);
        // con.Open();
        // //cmd.ExecuteNonQuery();        
        // string StrSql = fun.select1("Terms", " tbl_PO_terms");
        // SqlCommand Cmdgrid = new SqlCommand(StrSql, con);
        // SqlDataReader rdr = Cmdgrid.ExecuteReader();
        // StringBuilder sb = new StringBuilder();
        // while (rdr.Read())
        // {
        //     if (rdr.HasRows)
        //     {                               
        //         sb.AppendLine(rdr[0].ToString());

        //     }
        // }

        // Label2.Text = sb.ToString().Replace(Environment.NewLine, "<br />");
        //// Label2.Text = sb.ToString().Replace(Environment.NewLine, Environment.NewLine);

        // con.Close();

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        try
        {
            conn.Open();
            string MonthId = string.Empty;
            MonthId = ddlMonth.SelectedValue;
            string getRandomKey = fun.GetRandomAlphaNumeric();
            string StrLeave = fun.select("Count(*) As Cnt", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + SId + "' AND tblHR_Salary_Master.FMonth='" + MonthId + "'");
            SqlCommand cmdLeave = new SqlCommand(StrLeave, conn);
            SqlDataReader rdr = cmdLeave.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows == true)
            {
                if (Convert.ToDouble(rdr[0]) > 0)
                {
                    Response.Redirect("~/Module/SysSupport/Salary_Print_Details.aspx?EmpId=" + SId + "&MonthId=" + MonthId + "&Key=" + getRandomKey + "&BackURL=0&ModId=12&SubModId=133");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "No Record Found!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
    }



    protected void material(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=82");
    }

    protected void Proforma(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=104");
    }

    protected void Sales(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Reports/Sales_Register.aspx?ModId=11&SubModId=");
    }

    protected void Sal(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=83");
    }

    protected void CGST(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=83");
    }

    protected void INV(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/SalesInvoice_Dashboard.aspx?ModId=11&SubModId=51");
    }

    protected void sgst(object sender,EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=84");
    }

    protected void reg(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Reports/Purchase_Reprt.aspx?ModId=11&SubModId=");
    }

    protected void ser(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/ServiceTaxInvoice_Dashboard.aspx?ModId=11&SubModId=52");
    }

    protected void fr(object sender,EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/PendingForInvoice_Print.aspx?ModId=11&SubModId=");
    }

    protected void Octroi(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=85");
    }

    protected void Contra(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=109");
    }

    protected void PVEV(object sender, EventArgs e)
    {
        Response.Redirect("~//Module/Accounts/Reports/Search.aspx?ModId=11&SubModId=");
        
    }

    protected void Packing(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=86");
       
    }

    protected void Debit(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=110");
       
    }

    protected void Cash(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Reports/Cash_Bank_Register.aspx?ModId=11&SubModId=");

    }

    protected void Freight(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=87");
   }

    protected void Note(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=111");
  }
    protected void Excisable(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=88");
    }

    protected void Receipt(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=112");
    }

    protected void Warrenty(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=89");
    }

    protected void Booking(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=62");
    }

    protected void Payment(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=90");
    }

    protected void Authorize(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=120");
    }

    protected void Type(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=105");
    }

    protected void Voucher(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=113");
    }
    protected void Reasons(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=106");
    }

    protected void Reas(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=114");
    }
    protected void R1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=107");
    }

    protected void R2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=119");
    }

    protected void R3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=108");
    }

    protected void R4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=126");
    }

    protected void R5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=123");
    }

    protected void R6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=135");
    }

    protected void R7(object sender, EventArgs e)
    {
        Response.Redirect("~//Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=125");
    }

    protected void R8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/BankReconciliation_New.aspx?ModId=11&SubModId=s");
    }

    protected void R9(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/PaidType.aspx?ModId=11&SubModId=");
    }

    protected void R10(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=138");
    }

    protected void R11(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Cheque_series.aspx?ModId=11&SubModId=");
    }

    protected void R12(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/BalanceSheet.aspx?ModId=11&SubModId=138");
    }

    protected void R13(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/TDS_Code.aspx?ModId=11&SubModId=");
    }
    protected void R14(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Asset.aspx?ModId=11&SubModId=140");
    }

    protected void Ro15(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=140");
    }

    protected void R16(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/ACC_LoanMaster.aspx?ModId=11&SubModId=");
    }

    protected void Rs17(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=143");
    }

    protected void Rm18(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Capital.aspx?ModId=11&SubModId=");
    }

    protected void R19(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Masters/Dashboard.aspx?ModId=11&SubModId=144");
    }

    //////////////////////////////////////////Design////////////////////////////////

    protected void D1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Masters/Dashboard.aspx?ModId=3&SubModId=19");
    }

    protected void D2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Transactions/Dashboard_BOM.aspx?ModId=3&SubModId=26");
    }

    protected void D3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Reports/ItemHistory_BOM.aspx?ModId=3&");
    }

    protected void D4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Masters/Dashboard.aspx?ModId=3&SubModId=21");
    }

    protected void D5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Transactions/Dashboard_Slido.aspx?ModId=3&SubModId=131");
    }

    protected void D6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Masters/Unit_Master.aspx?ModId=3&SubModId=76");
    }

    protected void D7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Transactions/ECN_WO.aspx?ModId=3&SubModId=137");
    }

    protected void D8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Masters/Dashboard.aspx?ModId=3&SubModId=122");
    }

    ////////////////////////////////////Project Management/////////////////////////////

    protected void PM2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/OnsiteAttendance_DashBoard.aspx?ModId=7&SubModId=115");
    }

    protected void PM3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary.aspx?ModId=7");
    }

    protected void PM4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/ProjectPlanning_Status.aspx?ModId=7&SubModId=115");
    }

    protected void PM5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Dashboard.aspx?ModId=7&SubModId=117");
    }

    protected void PM6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Dashboard.aspx?ModId=7&SubModId=116");
    }

    protected void PM7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Dashboard.aspx?ModId=7&SubModId=127");
    }

    protected void PM8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/ForCustomers.aspx?ModId=7&SubModId=");
    }

    //////////////////////////////////////////MIS////////////////////////////////////


    protected void MIS1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Transactions/Menu.aspx?ModId=14&SubModId=");
    }

    protected void MIS2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/SalesDistribution.aspx?ModId=14&SubModId=");
    }

    protected void MIS3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/PurchaseReport.aspx?ModId=14&SubModId=");
    }

    protected void MIS4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/SalesReport.aspx?ModId=14&SubModId=");
    }

    protected void MIS5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/ServiceTaxReport.aspx?ModId=14&SubModId=");
    }

    protected void MIS6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/BOMCosting.aspx?ModId=14&SubModId=");
    }

    protected void MIS7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/Excise_VAT_CST_Compute.aspx?ModId=14&SubModId=");
    }


 
    
    
    protected void MIS8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Reports/QA_POwise.aspx?ModId=14&Key='xyz'&SubModId=");
    }

    
    
    //////////////////////////////////////////////MR////////////////////////////////////

    protected void MR1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MROffice/Transactions/MROffice.aspx?ModId=13&SubModId=130");
    }


    
    
    
    ////////////////////////////////////////////////HR/////////////////////////////

    protected void HR1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=91");
    }

    protected void HR2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/NewsandNotices_New.aspx?ModId=12&SubModId=29");
    }

    protected void HR3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Reports/MultipleReports.aspx?ModId=12");
    }

    protected void HR4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=92");
    }

    protected void HR5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=25");
    }

    protected void HR7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=93");
    }

    protected void HR8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=24");
    }

    protected void HR9(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=94");
    }

    protected void Hr10(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=50");
    }

    protected void HR11(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=95");
    }

    protected void HR12(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=101");
    }

    protected void HR13(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=96");
    }

    protected void HR14(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/AuthorizeGatePass.aspx?ModId=12&SubModId=103");
    }

    protected void HR15(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=97");
    }

    protected void HR16(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=124");
    }

    protected void HR17(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=103");
    }

    protected void HR18(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=129");
    }

    protected void HR19(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/HolidayMaster.aspx");
    }

    protected void HR20(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Transactions/Dashboard.aspx?ModId=12&SubModId=133");
    }

    protected void HR21(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/PF_Slab.aspx");
    }

    protected void HR22(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/HR/Masters/Dashboard.aspx?ModId=12&SubModId=134");
    }
  
    
    
    ///////////////////////////////MM./////////////////////////////////

    protected void MM1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=77");
    }

    protected void MM2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/Dashboard.aspx?ModId=6&SubModId=61");
    }

    protected void MM3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Reports/RateRegister.aspx?ModId=6&SubModId=");
    }

    protected void MM4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=78");
    }

    protected void MM5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PR_Dashboard.aspx?ModId=6&SubModId=34");
    }

    protected void MM6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Reports/RateLockUnlock.aspx?ModId=6&SubModId=");
    }


    protected void MM7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=79");
    }

    protected void MM8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_Dashboard.aspx?ModId=6&SubModId=31");
    }

    protected void MM9(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Reports/VendorRating.aspx?ModId=6&SubModId=");
    }

    protected void MM10(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=80");
    }

    protected void MM11(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_Check_Dashboard.aspx?ModId=6&SubModId=58");
    }

    protected void MM12(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Reports/MaterialForecasting.aspx?ModId=6&SubModId=");
    }

    protected void MM13(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=22");
    }

    protected void MM14(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_Approve_Dashboard.aspx?ModId=6&SubModId=59");
    }

    protected void MM15(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Reports/InwardOutwardRegister.aspx?ModId=6&SubModId=");
    }

    protected void MM16(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Masters/Dashboard.aspx?ModId=6&SubModId=139");
    }

   

    protected void MM18(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PO_Dashboard.aspx?ModId=6&SubModId=35");
    }

    protected void MM19(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PO_Check_Dashboard.aspx?ModId=6&SubModId=55");
    }

    protected void MM20(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PO_Approve_Dashboard.aspx?ModId=6&SubModId=56");
    }

    protected void MM21(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PO_Authorize_Dashboard.aspx?ModId=6&SubModId=57");
    }


    protected void HeadPO_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/PO_Head_Approve_Dashboard.aspx?ModId=6&SubModId=146");
    }


    //////////////////////////////////////Project Planning/////////////////////////////////////

    protected void PP1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialPlanning/Masters/Dashboard.aspx?ModId=4&SubModId=28");
    }

    protected void PP2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialPlanning/Transactions/Dashboard.aspx?ModId=4&SubModId=33");
    }

   
    
    ////////////////////////////////////Inventory//////////////////////////////////////////////////


    protected void IV1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Masters/Dashboard.aspx?ModId=9&SubModId=18");
    }

    protected void IV2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/Inward_DashBoard.aspx?ModId=9&SubModId=37");
    }

    protected void IV3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/StockLedger.aspx?ModId=9");
    }


    protected void IV4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Masters/AutoWIS_Time_Set.aspx?ModId=9&SubModId=");
    }

    protected void IV5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/RecievedReciept_Dashboard.aspx?ModId=9&SubModId=38");
    }

    protected void IV6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/Stock_Statement.aspx?ModId=9");
    }

    protected void IV7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/ServiceNote_Dashboard.aspx?ModId=9&SubModId=39");
    }

    protected void IV8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/WorkOrder_Issue.aspx?ModId=9");
    }

    protected void IV9(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/MaterialRequisitionSlip_Dashboard.aspx?ModId=9&SubModId=40");
    }

    protected void IV10(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/ABCAnalysis.aspx?ModId=9");
    }

    protected void IV11(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/MaterialIssueNote_Dashboard.aspx?ModId=9&SubModId=41");
    }

    protected void IV12(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/Moving_NonMoving_Items.aspx?ModId=9");
    }

    protected void IV13(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/MaterialReturnNote_Dashboard.aspx?ModId=9&SubModId=48");
    }

    protected void IV14(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/InwardOutwardRegister.aspx?ModId=9");
    }

    protected void IV15(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/Dashboard.aspx?ModId=9&SubModId=81");
    }

    protected void IV16(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Reports/Search.aspx?ModId=9");
    }

    protected void IV17(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/Dashboard.aspx?ModId=9&SubModId=53");
    }

    protected void IV18(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/Dashboard.aspx?ModId=9&SubModId=118");
    }

    protected void IV19(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/Dashboard.aspx?ModId=9&SubModId=121");
    }

    protected void IV20(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/ClosingStock.aspx?ModId=&SubModId=");
    }




    protected void IV21(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/GatePass.aspx?ModId=&SubModId=");
    }

    
    
    /////////////////////////////////////////////////QC///////////////////////////////////////////

    protected void QC1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Transactions/QualityNote_Dashboard.aspx?ModId=10&SubModId=46");
    }

    protected void QC2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Reports/GoodsRejection_GRN.aspx?ModId=10&SubModId=");
    }

    protected void QC3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Transactions/MaterialReturnNote_Dashboard.aspx?ModId=10&SubModId=49");
    }

    protected void QC4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Reports/ScrapMaterial_Report.aspx?ModId=10&SubModId=");
    }

    protected void QC5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Transactions/Dashboard.aspx?ModId=10&SubModId=128");
    }


    protected void QC6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/QualityControl/Reports/ScrapMaterial_Report.aspx?ModId=10&SubModId=");
    }


 
    
    
    
    /////////////////////////////////////////Sales/////////////////////////

    protected void S1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Masters/Dashboard.aspx?ModId=2&SubModId=7");
    }

    protected void S2(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/CustEnquiry_Dashboard.aspx?ModId=2&SubModId=10");
    }

    protected void S3(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Masters/Dashboard.aspx?ModId=2&SubModId=74");
    }

    protected void S4(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Quotation_Dashboard.aspx?ModId=2&SubModId=63");
    }

    protected void S5(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Masters/WO_Category_Dashboard.aspx?ModId=2 &SubModId=71");
    }

    protected void S6(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Quotation_Check_Dashboard.aspx?ModId=2&SubModId=64");
    }

    protected void S7(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Masters/Dashboard.aspx?ModId=2&SubModId=75");
    }

    protected void S8(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Quotation_Approve_Dashboard.aspx?ModId=2&SubModId=65");
    }

    protected void S9(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Quotation_Authorize_Dashboard.aspx?ModId=2&SubModId=66");
    }


    protected void S10(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Dashboard.aspx?ModId=2&SubModId=11");
    }

    protected void S11(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Dashboard.aspx?ModId=2&SubModId=13");
    }

    protected void S12(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/WORelease_Dashbord.aspx?ModId=2&SubModId=15");
    }

    protected void S13(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/WorkOrder_Dispatch_Dashbord.aspx?ModId=2&SubModId=54");
    }
    protected void S14(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Dispatch_Gunrail_Dashbord.aspx?ModId=2&SubModId=132");
    }
    protected void S15(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/SalesDistribution/Transactions/Dashboard.aspx?ModId=2&SubModId=73");
    }

 
    
    //////////////////////////////////Chatroom////////////////////////////////////

    protected void Chatroom1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Chatting/Chatroom.aspx?roomId=1");
    }

    
    /////////////////////////////////////Gate Pass////////////////////////////

    protected void Gate(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Scheduler/GatePass_New.aspx");
    }
   
 
     
    
    ///////////////////////////////////IOU//////////////////

    protected void IOU1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Scheduler/IOU.aspx");
    }

  
    
    
    
    ///////////////////////////////////////////Myshedule////////////////////

    protected void Schedual1(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Scheduler/Scheduling.aspx");
    }

    protected void Meeting(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Scheduler/Project Meeting.aspx");
    }


}

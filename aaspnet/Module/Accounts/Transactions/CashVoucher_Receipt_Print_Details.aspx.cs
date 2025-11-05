
using System;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Module_Accounts_Transactions_CashVoucher_Receipt_Print_Details : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    private ReportDocument report = new ReportDocument();
    int cId = 0;
    string Key = string.Empty;
    int CVRId = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        string connStr1 = fun.Connection();
        SqlConnection myConnection = new SqlConnection(connStr1);
        myConnection.Open();
        cId = Convert.ToInt32(Session["compid"]);
        Key = Request.QueryString["Key"].ToString();
        CVRId = Convert.ToInt32(Request.QueryString["CVRId"]);
        try
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

                string selectQuery = "SELECT tblACC_CashVoucher_Receipt_Master.BudgetCode,[tblACC_CashVoucher_Receipt_Master].[Id],REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblACC_CashVoucher_Receipt_Master].[SysDate] , CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate] ) + 1, 2) + '-' + LEFT([tblACC_CashVoucher_Receipt_Master].[SysDate],CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate]) - 1) + '-' + RIGHT([tblACC_CashVoucher_Receipt_Master].[SysDate], CHARINDEX('-', REVERSE([tblACC_CashVoucher_Receipt_Master].[SysDate])) - 1)), 103), '/', '-') AS  [SysDate],[tblACC_CashVoucher_Receipt_Master].[SysTime],[tblACC_CashVoucher_Receipt_Master].[CompId],[tblACC_CashVoucher_Receipt_Master].[FinYearId],[tblACC_CashVoucher_Receipt_Master].[SessionId],[tblACC_CashVoucher_Receipt_Master].[CVRNo],[tblACC_CashVoucher_Receipt_Master].[CashReceivedAgainst],[tblACC_CashVoucher_Receipt_Master].[CashReceivedBy],[tblACC_CashVoucher_Receipt_Master].[WONo],[BusinessGroup].[Symbol] AS [BGGroup],AccHead.Symbol AS [AcHead],[tblACC_CashVoucher_Receipt_Master].[Amount],[tblACC_CashVoucher_Receipt_Master].[Others],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRA],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRB] FROM [tblACC_CashVoucher_Receipt_Master]inner join [AccHead] on [tblACC_CashVoucher_Receipt_Master].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on[tblACC_CashVoucher_Receipt_Master].[BGGroup]=[BusinessGroup].[Id] AND [tblACC_CashVoucher_Receipt_Master].[Id]='" + CVRId + "' Order by [tblACC_CashVoucher_Receipt_Master].[Id] Desc";

                SqlCommand myCommand = new SqlCommand(selectQuery, myConnection);
                SqlDataAdapter ad = new SqlDataAdapter(myCommand);
                DataSet DS = new DataSet();
                ad.Fill(DS);

                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//0
                dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));//1
                dt.Columns.Add(new System.Data.DataColumn("CVRNo", typeof(string)));//2
                dt.Columns.Add(new System.Data.DataColumn("CashReceivedAgainst", typeof(string)));//3
                dt.Columns.Add(new System.Data.DataColumn("CashReceivedBy", typeof(string)));//4
                dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));//5
                dt.Columns.Add(new System.Data.DataColumn("BGGroup", typeof(string)));//6
                dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));//7
                dt.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));//8
                dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));//9
                dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));//10
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//11

                DataRow dr;
               // for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
                if (DS.Tables[0].Rows.Count>0)
                {
                    dr = dt.NewRow();
                    dr[0] = DS.Tables[0].Rows[0]["Id"].ToString();
                    dr[1] = DS.Tables[0].Rows[0]["SysDate"].ToString();
                    dr[2] = DS.Tables[0].Rows[0]["CVRNo"].ToString();

                    int typesRa = 0;
                    string TRa = string.Empty;
                    typesRa = Convert.ToInt32(DS.Tables[0].Rows[0]["CodeTypeRA"].ToString());
                    if (typesRa == 1)
                    {
                        TRa = "Employee";
                    }
                    else if (typesRa == 2)
                    {
                        TRa = "Customer";
                    }
                    else if (typesRa == 3)
                    {
                        TRa = "Supplier";
                    }

                    dr[3] = fun.EmpCustSupplierNames(Convert.ToInt32(DS.Tables[0].Rows[0]["CodeTypeRA"].ToString()), DS.Tables[0].Rows[0]["CashReceivedAgainst"].ToString(), cId)+" ( "+TRa.ToUpper()+" ) ";

                    int typesRb = 0;
                    string TRb = string.Empty;
                    typesRb = Convert.ToInt32(DS.Tables[0].Rows[0]["CodeTypeRB"].ToString());
                    if (typesRb == 1)
                    {
                        TRb = "Employee";
                    }
                    else if (typesRb == 2)
                    {
                        TRb = "Customer";
                    }
                    else if (typesRb == 3)
                    {
                        TRb = "Supplier";
                    }

                    dr[4] = fun.EmpCustSupplierNames(Convert.ToInt32(DS.Tables[0].Rows[0]["CodeTypeRB"].ToString()), DS.Tables[0].Rows[0]["CashReceivedBy"].ToString(), cId) + " ( " + TRb.ToUpper() + " ) ";

                    dr[5] = DS.Tables[0].Rows[0]["WONo"].ToString();
                    dr[6] = DS.Tables[0].Rows[0]["BGGroup"].ToString();
                    dr[7] = DS.Tables[0].Rows[0]["AcHead"].ToString();

                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["BudgetCode"]) != 0)
                    {
                        string sql1 = fun.select("Symbol", " tblMIS_BudgetCode", "Id='" + Convert.ToDouble(DS.Tables[0].Rows[0]["BudgetCode"]) + "'");


                        SqlCommand cmd1 = new SqlCommand(sql1, myConnection);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet DS1 = new DataSet();
                        da1.Fill(DS1);
                        dr[8] = DS1.Tables[0].Rows[0]["Symbol"].ToString();
                    }
                    else
                    {
                        dr[8] = "NA";
                    }
                    dr[9] = DS.Tables[0].Rows[0]["Amount"].ToString();
                    dr[10] = DS.Tables[0].Rows[0]["Others"].ToString();
                    dr[11] = DS.Tables[0].Rows[0]["CompId"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

                DataSet xsdds = new CashVoucher_Receipt();
                xsdds.Tables[0].Merge(dt);
                xsdds.AcceptChanges();
                report = new ReportDocument();
                report.Load(Server.MapPath("~/Module/Accounts/Reports/CashVoucher_Receipt.rpt"));
                report.SetDataSource(xsdds);

                // For Address
                string Address = fun.CompAdd(cId);
                report.SetParameterValue("Address", Address);
                CrystalReportViewer1.ReportSource = report;
                Session[Key] = report;

            }
            else
            {
                ReportDocument doc = (ReportDocument)Session[Key];
                CrystalReportViewer1.ReportSource = doc;
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            myConnection.Close();
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        report.Close();
        report.Dispose();
        GC.Collect();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        report = new ReportDocument();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/CashVoucher_Print.aspx?ModId=11&SubModId=113");
    }
  
}


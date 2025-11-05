using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_CashVoucher_Receipt_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int cId;

	private string Key = string.Empty;

	private int CVRId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		cId = Convert.ToInt32(Session["compid"]);
		Key = base.Request.QueryString["Key"].ToString();
		CVRId = Convert.ToInt32(base.Request.QueryString["CVRId"]);
		try
		{
			if (!base.IsPostBack)
			{
				DataTable dataTable = new DataTable();
				string cmdText = "SELECT tblACC_CashVoucher_Receipt_Master.BudgetCode,[tblACC_CashVoucher_Receipt_Master].[Id],REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblACC_CashVoucher_Receipt_Master].[SysDate] , CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate] ) + 1, 2) + '-' + LEFT([tblACC_CashVoucher_Receipt_Master].[SysDate],CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate]) - 1) + '-' + RIGHT([tblACC_CashVoucher_Receipt_Master].[SysDate], CHARINDEX('-', REVERSE([tblACC_CashVoucher_Receipt_Master].[SysDate])) - 1)), 103), '/', '-') AS  [SysDate],[tblACC_CashVoucher_Receipt_Master].[SysTime],[tblACC_CashVoucher_Receipt_Master].[CompId],[tblACC_CashVoucher_Receipt_Master].[FinYearId],[tblACC_CashVoucher_Receipt_Master].[SessionId],[tblACC_CashVoucher_Receipt_Master].[CVRNo],[tblACC_CashVoucher_Receipt_Master].[CashReceivedAgainst],[tblACC_CashVoucher_Receipt_Master].[CashReceivedBy],[tblACC_CashVoucher_Receipt_Master].[WONo],[BusinessGroup].[Symbol] AS [BGGroup],AccHead.Symbol AS [AcHead],[tblACC_CashVoucher_Receipt_Master].[Amount],[tblACC_CashVoucher_Receipt_Master].[Others],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRA],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRB] FROM [tblACC_CashVoucher_Receipt_Master]inner join [AccHead] on [tblACC_CashVoucher_Receipt_Master].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on[tblACC_CashVoucher_Receipt_Master].[BGGroup]=[BusinessGroup].[Id] AND [tblACC_CashVoucher_Receipt_Master].[Id]='" + CVRId + "' Order by [tblACC_CashVoucher_Receipt_Master].[Id] Desc";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CVRNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CashReceivedAgainst", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CashReceivedBy", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[0]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["CVRNo"].ToString();
					int num = 0;
					string text = string.Empty;
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["CodeTypeRA"].ToString()))
					{
					case 1:
						text = "Employee";
						break;
					case 2:
						text = "Customer";
						break;
					case 3:
						text = "Supplier";
						break;
					}
					dataRow[3] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["CodeTypeRA"].ToString()), dataSet.Tables[0].Rows[0]["CashReceivedAgainst"].ToString(), cId) + " ( " + text.ToUpper() + " ) ";
					int num2 = 0;
					string text2 = string.Empty;
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["CodeTypeRB"].ToString()))
					{
					case 1:
						text2 = "Employee";
						break;
					case 2:
						text2 = "Customer";
						break;
					case 3:
						text2 = "Supplier";
						break;
					}
					dataRow[4] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["CodeTypeRB"].ToString()), dataSet.Tables[0].Rows[0]["CashReceivedBy"].ToString(), cId) + " ( " + text2.ToUpper() + " ) ";
					dataRow[5] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[0]["BGGroup"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[0]["AcHead"].ToString();
					if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["BudgetCode"]) != 0)
					{
						string cmdText2 = fun.select("Symbol", " tblMIS_BudgetCode", "Id='" + Convert.ToDouble(dataSet.Tables[0].Rows[0]["BudgetCode"]) + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						dataRow[8] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
					}
					else
					{
						dataRow[8] = "NA";
					}
					dataRow[9] = dataSet.Tables[0].Rows[0]["Amount"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["Others"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[0]["CompId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet3 = new CashVoucher_Receipt();
				dataSet3.Tables[0].Merge(dataTable);
				dataSet3.AcceptChanges();
				report = new ReportDocument();
				report.Load(base.Server.MapPath("~/Module/Accounts/Reports/CashVoucher_Receipt.rpt"));
				report.SetDataSource(dataSet3);
				string text3 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/CashVoucher_Print.aspx?ModId=11&SubModId=113");
	}
}

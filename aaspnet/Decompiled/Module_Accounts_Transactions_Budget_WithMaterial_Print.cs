using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_Budget_WithMaterial_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string text = base.Request.QueryString["Id"];
		try
		{
			SqlCommand selectCommand = new SqlCommand("Select   tblACC_Budget_Transactions.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Transactions.SysDate , CHARINDEX('-',tblACC_Budget_Transactions.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', tblACC_Budget_Transactions.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Transactions.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Transactions.SysTime,tblACC_Budget_Transactions.BudgetCode,  AccHead.Description+'-'+ AccHead.Symbol  AS Description,tblACC_Budget_Transactions.Amount  from  AccHead ,tblACC_Budget_Transactions where tblACC_Budget_Transactions.BudgetCode=AccHead.Id  and  AccHead.Id='" + text + "'", connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text2 = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
			string text3 = dataSet.Tables[0].Rows[0]["SysTime"].ToString();
			string text4 = dataSet.Tables[0].Rows[0]["Description"].ToString();
			string text5 = dataSet.Tables[0].Rows[0]["Amount"].ToString();
			string text6 = base.Server.MapPath("Budger_Labour_Print.rpt.rpt");
			report.Load(text6);
			report.SetDataSource(dataSet);
			report.SetParameterValue("BudgetCode", (object)text);
			report.SetParameterValue("SysDate", (object)text2);
			report.SetParameterValue("SysTime", (object)text3);
			report.SetParameterValue("Description", (object)text4);
			report.SetParameterValue("Amount", (object)text5);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
		}
		catch (Exception)
		{
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
}

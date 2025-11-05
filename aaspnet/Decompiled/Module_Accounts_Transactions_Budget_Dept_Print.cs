using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_Budget_Dept_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(base.Request.QueryString["DeptId"]);
		string cmdText = fun.select("AccHead.Description,AccHead.Symbol,AccHead.Abbrivation,tblACC_Budget_Dept.Amount ,tblHR_Departments.Description As DeptName", "AccHead,tblACC_Budget_Dept,tblHR_Departments", "AccHead.Id=tblACC_Budget_Dept.AccId and AccHead.Category='Labour' and tblACC_Budget_Dept.DeptId=tblHR_Departments.Id and tblACC_Budget_Dept.DeptId='" + num + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		DataSet dataSet2 = new BudgetDept();
		sqlDataAdapter.Fill(dataSet);
		dataSet2.Tables[0].Merge(dataSet.Tables[0]);
		dataSet2.AcceptChanges();
		string text = base.Server.MapPath("~/Module/MIS/Transactions/Reports/Budget_Dept.rpt");
		report.Load(text);
		report.SetDataSource(dataSet2);
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
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

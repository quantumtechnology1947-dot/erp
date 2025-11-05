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

public class Module_HR_Transactions_MobilePrint : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string mth = "";

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				Key = base.Request.QueryString["Key"].ToString();
				mth = base.Request.QueryString["Months"].ToString();
				DDLMonth();
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	public void DDLMonth()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		try
		{
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("LimitAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BillAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Value", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			string cmdText = "SELECT  tblHR_OfficeStaff.CompId , tblHR_OfficeStaff.EmpId, tblHR_OfficeStaff.EmployeeName,tblHR_CoporateMobileNo.MobileNo,   tblHR_CoporateMobileNo.LimitAmt, tblHR_MobileBill.BillAmt, tblExciseser_Master.Value  FROM    tblHR_OfficeStaff INNER JOIN      tblHR_CoporateMobileNo ON tblHR_OfficeStaff.MobileNo = tblHR_CoporateMobileNo.Id INNER JOIN  tblHR_MobileBill ON tblHR_OfficeStaff.EmpId = tblHR_MobileBill.EmpId INNER JOIN tblExciseser_Master ON tblHR_MobileBill.Taxes = tblExciseser_Master.Id   And tblHR_OfficeStaff.CompId='" + num + "' And tblHR_MobileBill.FinYearId ='" + num2 + "'And BillMonth=  '" + mth + "' ";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet2 = new MobileBill();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Merge(dataSet.Tables[0]);
			dataSet2.Tables[0].Merge(dataTable);
			dataSet2.AcceptChanges();
			string text = base.Server.MapPath("~/Module/HR/Transactions/Reports/MobileBill.rpt");
			report.Load(text);
			string text2 = fun.CompAdd(num);
			report.SetParameterValue("CompAdd", (object)text2);
			report.SetDataSource(dataSet2);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
			Session[Key] = report;
		}
		catch (Exception)
		{
		}
		finally
		{
			dataSet.Clear();
			dataSet.Dispose();
			dataTable.Clear();
			dataTable.Dispose();
			sqlConnection.Close();
			sqlConnection.Dispose();
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

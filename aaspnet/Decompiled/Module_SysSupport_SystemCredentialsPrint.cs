using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_SysSupport_SystemCredentialsPrint : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel4;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private int Id;

	private string sId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		Key = base.Request.QueryString["Key"].ToString();
		Id = Convert.ToInt32(base.Request.QueryString["Id"]);
		con.Open();
		try
		{
			if (!base.IsPostBack)
			{
				string cmdText = "SELECT tblSystemCredentials.Id, tblSystemCredentials.CompId, REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblSystemCredentials.SysDate, CHARINDEX('-',tblSystemCredentials.SysDate) + 1, 2) + '-' + LEFT(tblSystemCredentials.SysDate, CHARINDEX('-', tblSystemCredentials.SysDate) - 1)+ '-' + RIGHT(tblSystemCredentials.SysDate, CHARINDEX('-', REVERSE(tblSystemCredentials.SysDate)) - 1)), 103), '/', '-') AS SysDate, tblSystemCredentials.SysPwd,tblSystemCredentials.ERPPwd, tblSystemCredentials.EmailId, tblSystemCredentials.EmailPwd, tblHR_OfficeStaff.EmpId,tblHR_OfficeStaff.Title + '. ' + tblHR_OfficeStaff.EmployeeName AS EmployeeName, tblHR_Designation.Type AS Designation,tblHR_Departments.Description AS Department, vw_tblHR_OfficeStaff.Title + '. ' + vw_tblHR_OfficeStaff.EmployeeName AS HOD FROM tblSystemCredentials INNER JOIN tblHR_OfficeStaff ON tblSystemCredentials.MId = tblHR_OfficeStaff.UserID INNER JOIN tblHR_Designation ON tblHR_OfficeStaff.Designation = tblHR_Designation.Id INNER JOIN tblHR_Departments ON tblHR_OfficeStaff.Department = tblHR_Departments.Id  INNER JOIN vw_tblHR_OfficeStaff ON tblHR_OfficeStaff.DeptHead = vw_tblHR_OfficeStaff.UserID where tblSystemCredentials.Id = '" + Id + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataSet dataSet2 = new AuthorityAuthorization();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.AcceptChanges();
				report = new ReportDocument();
				report.Load(base.Server.MapPath("~/Module/SysSupport/AuthorityAuthorizationForm.rpt"));
				report.SetDataSource(dataSet2);
				string text = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text);
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
			con.Close();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
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

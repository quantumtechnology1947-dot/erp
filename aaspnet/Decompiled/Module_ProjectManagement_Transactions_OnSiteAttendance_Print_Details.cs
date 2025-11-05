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

public class Module_ProjectManagement_Transactions_OnSiteAttendance_Print_Details : Page, IRequiresSessionState
{
	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt = new ReportDocument();

	private string z = "";

	private string p = "";

	private string q = "";

	private string m = "";

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			m = base.Request.QueryString["m"].ToString();
			p = base.Request.QueryString["p"].ToString();
			q = base.Request.QueryString["q"].ToString();
			z = base.Request.QueryString["z"].ToString();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetOnSiteEmp_Print", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@m", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@q", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@m"].Value = m;
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = z;
			sqlDataAdapter.SelectCommand.Parameters["@p"].Value = p;
			sqlDataAdapter.SelectCommand.Parameters["@q"].Value = q;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			DataSet dataSet = new DataSet();
			new OnSiteAttendance();
			sqlDataAdapter.Fill(dataSet);
			DataSet dataSet2 = new OnSiteAttendance();
			dataSet2.Tables[0].Merge(dataSet.Tables[0]);
			dataSet2.AcceptChanges();
			cryRpt = new ReportDocument();
			cryRpt.Load(base.Server.MapPath("~/Module/ProjectManagement/Reports/OnSiteAttendance.rpt"));
			cryRpt.SetDataSource(dataSet2);
			string text = fun.CompAdd(CompId);
			cryRpt.SetParameterValue("Address", (object)text);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}
}

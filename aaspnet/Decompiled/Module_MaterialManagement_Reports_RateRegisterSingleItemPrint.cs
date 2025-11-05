using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Reports_RateRegisterSingleItemPrint : Page, IRequiresSessionState
{
	private int CompId;

	private int ItemId;

	private clsFunctions fun = new clsFunctions();

	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected HtmlForm Form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		try
		{
			CompId = Convert.ToInt32(base.Request.QueryString["CompId"].ToString());
			ItemId = Convert.ToInt32(base.Request.QueryString["ItemId"].ToString());
			DataSet dataSource = fun.RateRegister(ItemId, CompId);
			ReportDocument val = new ReportDocument();
			val = new ReportDocument();
			val.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/RateRegSingleItem.rpt"));
			val.SetDataSource(dataSource);
			string text = fun.CompAdd(CompId);
			val.SetParameterValue("Address", (object)text);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = val;
		}
		catch (Exception)
		{
		}
	}
}

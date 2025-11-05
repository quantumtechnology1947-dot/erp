using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;

public class Module_HR_Transactions_MobileBills_Print : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected HtmlGenericControl myframe;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			try
			{
				new DataSet();
				int compId = Convert.ToInt32(Session["compid"]);
				int finYearId = Convert.ToInt32(Session["finyear"]);
				fun.GetMonth(DropDownList1, compId, finYearId);
			}
			catch (Exception)
			{
			}
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedItem.Text != "Select")
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			myframe.Attributes.Add("Src", "MobilePrint.aspx?months=" + DropDownList1.SelectedValue + "&Key=" + randomAlphaNumeric + "&ModId=12&SubModId=50");
		}
	}
}

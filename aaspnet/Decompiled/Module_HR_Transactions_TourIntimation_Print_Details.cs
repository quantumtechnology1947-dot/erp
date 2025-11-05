using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_TourIntimation_Print_Details : Page, IRequiresSessionState
{
	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TourIntimation_Print.aspx?ModId=12&SubModId=124");
	}
}

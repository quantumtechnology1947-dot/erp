using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Transactions_Menu : Page, IRequiresSessionState
{
	protected HyperLink HyperLink1;

	protected HyperLink HyperLink2;

	protected HyperLink HyperLink5;

	protected HyperLink HyperLink4;

	protected HyperLink HyperLink3;

	protected HyperLink HyperLink6;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		HyperLink6.NavigateUrl = "~/Module/MIS/Transactions/HrsBudgetSummary.aspx?ModId=14&Key=" + randomAlphaNumeric;
	}
}

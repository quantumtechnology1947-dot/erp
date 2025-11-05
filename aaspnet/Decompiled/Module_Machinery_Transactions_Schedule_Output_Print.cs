using System;
using System.Web.SessionState;
using System.Web.UI;
using ASP;

public class Module_Machinery_Transactions_Schedule_Output_Print : Page, IRequiresSessionState
{
	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

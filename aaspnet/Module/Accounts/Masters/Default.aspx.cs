using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Default : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

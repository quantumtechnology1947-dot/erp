using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class AdminLogin : Page, IRequiresSessionState
{
	protected System.Web.UI.WebControls.Login Login1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
	{
	}
}

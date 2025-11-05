using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Default : Page, IRequiresSessionState
{
	protected HyperLink HyperLink1;

	protected HyperLink HyperLink2;

	protected HyperLink HyperLink3;

	protected HyperLink HyperLink4;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

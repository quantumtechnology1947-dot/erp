using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class _controls_alphalinks : UserControl
{
	protected Repeater __theAlphalink;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

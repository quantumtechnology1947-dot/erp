using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;

public class Flowchart_Flowchart : Page, IRequiresSessionState
{
	protected HtmlGenericControl Iframe1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = base.Request.QueryString["Id"].ToString();
		Iframe1.Attributes.Add("src", "ShowPage.aspx?Id=" + text);
	}
}

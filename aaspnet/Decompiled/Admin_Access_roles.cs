using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_roles : Page, IRequiresSessionState
{
	protected TextBox NewRole;

	protected Button Button2;

	protected Button btnCancel;

	protected GridView UserRoles;

	protected Panel Panel1;

	protected HtmlGenericControl ConfirmationMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/SysSupport/SysConfig/config.aspx");
	}
}

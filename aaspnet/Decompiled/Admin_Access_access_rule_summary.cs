using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_access_rule_summary : Page, IRequiresSessionState
{
	protected DropDownList UserRoles;

	protected DropDownList UserList;

	protected TreeView FolderTree;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FolderTree.ExpandDepth = 2;
		}
		catch (Exception)
		{
		}
	}
}

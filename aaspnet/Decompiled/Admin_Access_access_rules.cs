using System;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_access_rules : Page, IRequiresSessionState
{
	private const string VirtualImageRoot = "~/";

	private string selectedFolderName = "";

	protected TreeView FolderTree;

	protected HtmlGenericControl TitleOne;

	protected GridView RulesGrid;

	protected HtmlGenericControl TitleTwo;

	protected RadioButton ActionDeny;

	protected RadioButton ActionAllow;

	protected RadioButton ApplyRole;

	protected DropDownList UserRoles;

	protected RadioButton ApplyUser;

	protected DropDownList UserList;

	protected RadioButton ApplyAllUsers;

	protected RadioButton ApplyAnonUser;

	protected Button Button4;

	protected Literal RuleCreationError;

	protected Panel SecurityInfoSection;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			PopulateTree();
			FolderTree.ExpandDepth = 2;
		}
	}

	private void PopulateTree()
	{
		DirectoryInfo folder = new DirectoryInfo(base.Server.MapPath("~/"));
		TreeNode child = AddNodeAndDescendents(folder, null);
		FolderTree.Nodes.Add(child);
		try
		{
			FolderTree.SelectedNode.ImageUrl = "/Simple/i/target.gif";
		}
		catch
		{
		}
	}

	private TreeNode AddNodeAndDescendents(DirectoryInfo folder, TreeNode parentNode)
	{
		TreeNode treeNode = new TreeNode(value: (parentNode != null) ? (parentNode.Value + folder.Name + "/") : "~/", text: folder.Name);
		treeNode.Selected = folder.Name == selectedFolderName.ToString();
		DirectoryInfo[] directories = folder.GetDirectories();
		DirectoryInfo[] array = directories;
		foreach (DirectoryInfo directoryInfo in array)
		{
			if (directoryInfo.Name != "_controls" && directoryInfo.Name != "App_Data" && directoryInfo.Name != "Admin" && directoryInfo.Name != "Css" && directoryInfo.Name != "App_Code" && directoryInfo.Name != "BackUp" && directoryInfo.Name != "Bin" && directoryInfo.Name != "DB" && directoryInfo.Name != "Controls" && directoryInfo.Name != "images" && directoryInfo.Name != "Javascript" && directoryInfo.Name != "SysConfig" && directoryInfo.Name != "Source")
			{
				TreeNode child = AddNodeAndDescendents(directoryInfo, treeNode);
				treeNode.ChildNodes.Add(child);
			}
		}
		return treeNode;
	}
}

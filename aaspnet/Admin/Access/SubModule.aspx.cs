using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_SubModule : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected Label Label2;

	protected DropDownList DrpModName;

	protected SqlDataSource SqlDataSource1;

	protected Label Label3;

	protected DropDownList DrpType;

	protected Label Label4;

	protected TextBox TxtSubModuleName;

	protected Label Label5;

	protected TextBox TxtLinkPage;

	protected Button Button1;

	protected Button Button2;

	protected GridView GridView2;

	protected SqlDataSource LocalSqlServer;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.insert("tblSubModule_Master", "ModId,MTR,SUbModName,DashBoardPage", "'" + DrpModName.SelectedValue + "','" + DrpType.SelectedValue + "','" + TxtSubModuleName.Text + "','" + TxtLinkPage.Text + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("../Menu.aspx");
	}
}

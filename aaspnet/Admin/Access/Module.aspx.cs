using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_Module : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected Label Label2;

	protected TextBox TxtModuleName;

	protected Label Label3;

	protected TextBox TxtLinkPage;

	protected Button btnSave;

	protected Button Button1;

	protected GridView GridView2;

	protected SqlDataSource LocalSqlServer;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.insert("tblModule_Master", "ModName,DashBoardPage", "'" + TxtModuleName.Text + "','" + TxtLinkPage.Text + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("../Menu.aspx");
	}
}

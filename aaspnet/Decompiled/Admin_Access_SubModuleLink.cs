using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_SubModuleLink : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected Label Label2;

	protected DropDownList DrpSubModuleName;

	protected SqlDataSource SqlDataSource1;

	protected Label Label3;

	protected DropDownList DrpAccess;

	protected Label Label4;

	protected TextBox TxtLinkPage;

	protected Button BtnSave;

	protected Button Button1;

	protected GridView GridView2;

	protected SqlDataSource LocalSqlServer;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void BtnSave_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.insert("tblSubModLink_Master", "SubModId,Access,LinkPage", "'" + DrpSubModuleName.SelectedValue + "','" + DrpAccess.SelectedValue + "','" + TxtLinkPage.Text + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
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

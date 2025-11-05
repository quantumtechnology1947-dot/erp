using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_edit_user : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string username = "";

	protected CheckBoxList UserRoles;

	protected Panel Panel1;

	protected CheckBox CheckBox1;

	protected ObjectDataSource MemberData;

	protected DetailsView UserInfo;

	protected Button Button1;

	protected Button Button3;

	protected Button Button2;

	protected Literal UserUpdateMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			username = base.Request.QueryString["username"];
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("UserId", "aspnet_Users", "UserName='" + username + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			string cmdText2 = fun.select("IsLockedOut", "aspnet_Membership", "UserId='" + dataSet.Tables[0].Rows[0]["UserId"].ToString() + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (dataSet2.Tables[0].Rows[0]["IsLockedOut"].ToString() == "True")
				{
					Button1.Visible = true;
				}
				else
				{
					Button3.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void UnlockUser(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("UserId", "aspnet_Users", "UserName='" + username + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.update("aspnet_Membership", "IsLockedOut='false'", " UserId='" + dataSet.Tables[0].Rows[0]["UserId"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void LockUser(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("UserId", "aspnet_Users", "UserName='" + username + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.update("aspnet_Membership", "IsLockedOut='True'", " UserId='" + dataSet.Tables[0].Rows[0]["UserId"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

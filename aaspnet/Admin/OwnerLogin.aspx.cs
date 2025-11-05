using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using EnCryptDecrypt;

public class Admin_OwnerLogin : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox txtUserName;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected Label Label3;

	protected TextBox txtPassword;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			string cmdText = fun.select("Ownerpassword", "aspnet_Users", "UserName='" + txtUserName.Text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "aspnet_Users");
			string cipherString = dataSet.Tables[0].Rows[0][0].ToString();
			string text = CryptorEngine.Decrypt(cipherString, useHashing: true);
			if (text == txtPassword.Text)
			{
				Page.Response.Redirect("~/Admin/Menu.aspx");
			}
			else
			{
				Page.Response.Redirect("~/Admin/OwnerLogin.aspx");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}
}

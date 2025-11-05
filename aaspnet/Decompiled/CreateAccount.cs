using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class CreateAccount : Page, IRequiresSessionState
{
	protected Label Label3;

	protected Label Label2;

	protected DropDownList DropDownList1;

	protected Label Label4;

	protected DropDownList DropDownList2;

	protected CreateUserWizard CreateUserWizard1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CreateUserWizard1.Enabled = false;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (!base.IsPostBack)
			{
				fun.dropdownCompany(DropDownList1);
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

	protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string text = CreateUserWizard1.UserName.ToString();
		string cmdText = clsFunctions2.update("aspnet_Users", "CompId='" + DropDownList1.SelectedValue + "',FinYearId='" + DropDownList2.SelectedValue + "'", "UserName='" + text + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
	{
		if (base.IsPostBack)
		{
			fun.dropdownFinYear(DropDownList2, DropDownList1);
		}
	}
}

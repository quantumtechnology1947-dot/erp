using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Admin_Access_add_user : Page, IRequiresSessionState
{
	protected Label Label3;

	protected Label Label2;

	protected DropDownList DropDownList1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected Label Label1;

	protected DropDownList DropDownList2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected DropDownList drpEmpName;

	protected CreateUserWizardStep CreateUserWizardStep1;

	protected CreateUserWizard CreateUserWizard1;

	protected Label lblmsg;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (!base.IsPostBack)
			{
				fun.dropdownCompany(DropDownList1);
				DropDownList1.SelectedIndex = 1;
				DropDownList2.Enabled = true;
				fun.dropdownFinYear(DropDownList2, DropDownList1);
				DropDownList2.SelectedIndex = 1;
				Employees();
				string cmdText = fun.select("LicenceNos", "tblCompany_master", "CompId='" + DropDownList1.SelectedValue + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				int num = Convert.ToInt32(sqlDataReader["LicenceNos"].ToString());
				string cmdText2 = fun.select("UserName", "aspnet_Users", "CompId='" + DropDownList1.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "aspnet_Users");
				int num2 = Convert.ToInt32(dataSet.Tables[0].Rows.Count);
				if (num2 >= num)
				{
					CreateUserWizard1.Enabled = false;
					lblmsg.Text = "Licence limitations are exceed!";
				}
				else
				{
					CreateUserWizard1.Enabled = true;
					lblmsg.Text = " ";
				}
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
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownList1.SelectedItem.Text != "Select")
			{
				sqlConnection.Open();
				string text = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName")).Text;
				string cmdText = fun.update("aspnet_Users", "CompId='" + DropDownList1.SelectedValue + "', FinYearId='" + DropDownList2.SelectedValue + "'", "UserName='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (DropDownList1.SelectedItem.Text != "Select")
			{
				if (base.IsPostBack)
				{
					DropDownList2.Enabled = true;
					fun.dropdownFinYear(DropDownList2, DropDownList1);
				}
			}
			else
			{
				DropDownList2.Enabled = false;
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

	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		Employees();
	}

	public void Employees()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			if (DropDownList2.SelectedItem.Text != "Select")
			{
				string cmdText = fun.select("tblHR_OfficeStaff.EmployeeName + ' ['+tblHR_OfficeStaff.EmpId+' ]'As EmpName,tblHR_OfficeStaff.EmpId", "tblHR_OfficeStaff", "tblHR_OfficeStaff.CompId='" + DropDownList1.SelectedValue + "'And tblHR_OfficeStaff.EmpId Not In(select aspnet_Users.UserName from aspnet_Users where aspnet_Users.CompId='" + DropDownList1.SelectedValue + "') Order by tblHR_OfficeStaff.EmployeeName ASC");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				drpEmpName.DataSource = dataSet.Tables[0];
				drpEmpName.DataTextField = "EmpName";
				drpEmpName.DataValueField = "EmpId";
				drpEmpName.DataBind();
				drpEmpName.Items.Insert(0, "Select");
			}
			else
			{
				drpEmpName.Items.Clear();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void drpEmpName_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			TextBox textBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
			TextBox textBox2 = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email");
			TextBox textBox3 = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password");
			textBox.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			string cmdText = fun.select("ErpSysmail", "tblCompany_master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text = dataSet.Tables[0].Rows[0]["ErpSysmail"].ToString();
			textBox2.Text = text;
			string text2 = drpEmpName.SelectedValue.ToString();
			textBox.Text = text2;
		}
		catch (Exception)
		{
		}
	}
}

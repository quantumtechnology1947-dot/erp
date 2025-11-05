using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Login : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label Label1;

	protected Label lblBirthDay;

	protected System.Web.UI.WebControls.Login Login1;

	protected LinkButton LinkButton2;

	protected HyperLink HyperLink2;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("*", "tblCompany_master", "DefaultComp=1");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			Label1.Text = sqlDataReader["CompanyName"].ToString();
			GridView1.DataSource = FetchAllImagesInfo();
			GridView1.DataBind();
			Convert.ToInt32(sqlDataReader["DefaultComp"]);
			HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
			if (browser.Browser != "Firefox")
			{
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Your browser is not compatible to run ERP, \\n\\n Browser Type: " + browser.Browser + "\\n\\n Version: " + browser.Version + "\\n\\n Support Javascript: " + browser.JavaScript + "\\n\\n Support Css: " + browser.SupportsCss + "\\n\\n Use Mozilla Firefox 12.0 or above only.'); window.close();", addScriptTags: true);
			}
			else
			{
				DropDownList dropDownList = (DropDownList)Login1.FindControl("DropDownList1");
				DropDownList dropDownList2 = (DropDownList)Login1.FindControl("DptYear");
				if (!base.IsPostBack)
				{
					fun.dropdownCompany(dropDownList);
					DropDownList dropDownList3 = (DropDownList)Login1.FindControl("DropDownList1");
					dropDownList3.SelectedIndex = 1;
					fun.dropdownFinYear(dropDownList2, dropDownList);
					dropDownList2.SelectedIndex = 1;
					TextBox textBox = (TextBox)Login1.FindControl("UserName");
					textBox.Focus();
				}
			}
			string[] array = fun.getCurrDate().Split('-');
			string cmdText2 = fun.select("Title+'. '+EmployeeName as name,DateOfBirth", "tblHR_OfficeStaff", "CompId='" + sqlDataReader["CompId"].ToString() + "' AND DateOfBirth like '%-" + array[1] + "-%'   And ResignationDate ='' Order by DATEPART(DAY,DateOfBirth) ASC");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			string text = string.Empty;
			while (sqlDataReader2.Read())
			{
				string[] array2 = sqlDataReader2["DateOfBirth"].ToString().Split('-');
				string text2 = text;
				text = text2 + "[" + array2[2] + "] " + sqlDataReader2["name"].ToString() + "<br>";
			}
			lblBirthDay.Text = text;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void LoginButton_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			string empty = string.Empty;
			empty = "C:\\Windows\\winxd07.txt";
			if (File.Exists(empty))
			{
				using (StreamReader streamReader = new StreamReader(empty, Encoding.UTF8))
				{
					text = streamReader.ReadToEnd();
				}
				if (text != "")
				{
					if (DateTime.Parse(fun.getCurrDate()) > DateTime.Parse(text.Trim()))
					{
						base.Response.Redirect("Login.aspx");
						return;
					}
					DropDownList dropDownList = (DropDownList)Login1.FindControl("DropDownList1");
					DropDownList dropDownList2 = (DropDownList)Login1.FindControl("DptYear");
					HttpSessionState session = HttpContext.Current.Session;
					Session["username"] = Login1.UserName.ToString();
					Session["compid"] = dropDownList.SelectedValue;
					Session["finyear"] = dropDownList2.SelectedValue;
					Session["sid"] = session.SessionID;
					string cmdText = fun.select("UserId", "aspnet_Users", "UserName='" + Login1.UserName.ToString() + "' And CompId='" + dropDownList.SelectedValue + "' ");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					sqlDataReader.Read();
					if (sqlDataReader.HasRows)
					{
						string cmdText2 = fun.select("IsLockedOut", "aspnet_Membership", "UserId='" + sqlDataReader[0].ToString() + "' ");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						sqlDataReader2.Read();
						if (sqlDataReader2.HasRows && sqlDataReader2[0].ToString() == "True")
						{
							string empty2 = string.Empty;
							empty2 = "User is Locked, contact to Administrator.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
						string cmdText3 = fun.select("CustId,Id", "tblPM_ForCustomer_Master", "EmpId='" + Login1.UserName.ToString() + "' ");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows)
						{
							base.Response.Redirect("~/Customers/Dashboard.aspx?CustId=" + sqlDataReader3[0].ToString() + "&Id=" + sqlDataReader3[1].ToString());
						}
					}
				}
				else
				{
					base.Response.Redirect("login.aspx");
				}
			}
			else
			{
				base.Response.Redirect("login.aspx");
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

	public DataTable FetchAllImagesInfo()
	{
		string selectCommandText = fun.select("*", "tblCompany_master", "DefaultComp=1");
		string connectionString = fun.Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		return dataTable;
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		DropDownList dpdlFinCompId = (DropDownList)Login1.FindControl("DropDownList1");
		DropDownList dropDownList = (DropDownList)Login1.FindControl("DptYear");
		fun.dropdownFinYear(dropDownList, dpdlFinCompId);
		dropDownList.Focus();
	}

	protected void Login1_LoggedIn(object sender, EventArgs e)
	{
		LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
		User user = linqChatDataContext.User.Where((User u) => u.EmpId == Login1.UserName).SingleOrDefault();
		if (user != null)
		{
			Session["ChatUserID"] = user.UserID;
			Session["ChatUsername"] = user.EmpId;
		}
	}

	protected void DptYear_SelectedIndexChanged(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)Login1.FindControl("UserName");
		textBox.Focus();
	}
}

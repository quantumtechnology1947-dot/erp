using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Admin_Access_AccessModule : Page, IRequiresSessionState
{
	protected DropDownList DrpCompany;

	protected DropDownList DrpFinYear;

	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Button BtnView;

	protected Label Label2;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string co = "";

	private string id = "";

	private int FyId;

	private int A;

	private int compid;

	private int fyid;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			FyId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["A"]))
			{
				A = Convert.ToInt32(base.Request.QueryString["A"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["CompId"]))
			{
				compid = Convert.ToInt32(base.Request.QueryString["CompId"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FYId"]))
			{
				fyid = Convert.ToInt32(base.Request.QueryString["FYId"]);
			}
			if (!base.IsPostBack)
			{
				fun.dropdownCompany(DrpCompany);
				DrpCompany.SelectedIndex = 1;
				fillFinDrp(FyId);
				DrpFinYear.SelectedIndex = 1;
				if (A != 0)
				{
					DrpCompany.SelectedValue = compid.ToString();
					DrpFinYear.SelectedValue = fyid.ToString();
					fillFinDrp(fyid);
					BtnView.Visible = true;
					DrpField.Visible = true;
					TxtMrs.Visible = true;
					TxtEmpName.Visible = true;
					Button1.Visible = true;
					TxtMrs.Visible = false;
				}
				binddata(co, id);
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

	public void fillFinDrp(int FinId)
	{
		try
		{
			if (DrpCompany.SelectedIndex != 0)
			{
				DataSet dataSet = new DataSet();
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select("FinYear,FinYearId", "tblFinancial_master", "FinYearId='" + FinId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				DrpFinYear.DataSource = dataSet.Tables["tblFinancial_master"];
				DrpFinYear.DataTextField = "FinYear";
				DrpFinYear.DataValueField = "FinYearId";
				DrpFinYear.DataBind();
			}
			else
			{
				DrpFinYear.Items.Clear();
			}
			DrpFinYear.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCompany_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fillFinDrp(FyId);
			DrpFinYear.SelectedIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void DrpFinYear_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		new SqlConnection(connectionString);
		new DataSet();
		try
		{
			if (DrpFinYear.SelectedValue.ToString() != "Select")
			{
				if (base.IsPostBack)
				{
					binddata(co, id);
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
				{
					Label2.Text = base.Request.QueryString["msg"].ToString();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void binddata(string Search, string EmpId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string text = "";
			string text2 = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				text2 = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				TxtMrs.Visible = true;
				TxtEmpName.Visible = false;
			}
			if (DrpField.SelectedValue == "1")
			{
				if (TxtMrs.Text != "")
				{
					string cmdText = fun.select("Id", "tblHR_Departments", "Symbol like '%" + TxtMrs.Text + "%'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					sqlDataReader.Read();
					text = " AND Department='" + sqlDataReader["Id"].ToString() + "'";
				}
			}
			else if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				string cmdText2 = fun.select("Id", "BusinessGroup", "Symbol like '%" + TxtMrs.Text + "%'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				while (sqlDataReader2.Read())
				{
					text = " AND BGGroup='" + sqlDataReader2["Id"].ToString() + "'";
				}
			}
			DataTable dataTable = new DataTable();
			string cmdText3 = fun.select("UserID,BGGroup,Designation,EmpId,Title + '. ' + EmployeeName As EmployeeName,FinYearId,JoiningDate,Department,MobileNo", "tblHR_OfficeStaff", "CompId='" + CompId + "'And ResignationDate='' And FinYearId<='" + FyId + "'" + text2 + text + "   Order by UserID Desc");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UserId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGgroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("JoiningDate", typeof(string)));
			while (sqlDataReader3.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				fun.FromDateDMY(sqlDataReader3["JoiningDate"].ToString());
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", sqlDataReader3["FinyearId"], "'"));
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				while (sqlDataReader4.Read())
				{
					dataRow[1] = sqlDataReader4["FinYear"].ToString();
				}
				string cmdText5 = fun.select("Description AS DeptName", "tblHR_Departments", string.Concat("Id='", sqlDataReader3["Department"], "'"));
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				while (sqlDataReader5.Read())
				{
					dataRow[4] = sqlDataReader5["DeptName"].ToString();
				}
				string cmdText6 = fun.select("Symbol AS BGgroup", "BusinessGroup", string.Concat("Id='", sqlDataReader3["BGGroup"], "'"));
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				while (sqlDataReader6.Read())
				{
					dataRow[5] = sqlDataReader6["BGgroup"].ToString();
				}
				string cmdText7 = fun.select("Symbol + '-' + Type AS Designation", "tblHR_Designation", string.Concat("Id='", sqlDataReader3["Designation"], "'"));
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				while (sqlDataReader7.Read())
				{
					dataRow[6] = sqlDataReader7["Designation"].ToString();
				}
				string value = fun.FromDateDMY(sqlDataReader3["JoiningDate"].ToString());
				dataRow[0] = sqlDataReader3["EmpId"].ToString();
				dataRow[2] = sqlDataReader3["UserId"].ToString();
				dataRow[3] = sqlDataReader3["EmployeeName"].ToString();
				string cmdText8 = fun.select("MobileNo", "tblHR_CoporateMobileNo", string.Concat("Id='", sqlDataReader3["MobileNo"], "'"));
				SqlCommand sqlCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				while (sqlDataReader8.Read())
				{
					dataRow[7] = sqlDataReader8["MobileNo"].ToString();
				}
				dataRow[8] = value;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtEmpName.Text);
			binddata(TxtMrs.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpField.SelectedValue == "0")
		{
			TxtMrs.Visible = false;
			TxtEmpName.Visible = true;
			TxtEmpName.Text = "";
			binddata(co, id);
		}
		else
		{
			TxtMrs.Visible = true;
			TxtMrs.Text = "";
			TxtEmpName.Visible = false;
			binddata(co, id);
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' And ResignationDate=''");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
				if (array.Length == 10)
				{
					break;
				}
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			if (!(e.CommandName == "Select"))
			{
				return;
			}
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			text = ((Label)gridViewRow.FindControl("lblEmpId")).Text;
			text2 = ((DropDownList)gridViewRow.FindControl("DrpModule")).SelectedValue;
			text3 = DrpCompany.SelectedValue;
			text4 = DrpFinYear.SelectedValue;
			if (text3 != "Select")
			{
				if (text4 != "Select")
				{
					if (text2 != "0")
					{
						base.Response.Redirect("AccessModule_Details.aspx?EmpId=" + text + "&modid=" + text2 + "&CompId=" + text3 + "&FYId=" + text4);
					}
					else
					{
						string empty = string.Empty;
						empty = "Please select module name.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Please select Financial Year.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Please select Company name.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnView_Click(object sender, EventArgs e)
	{
		string selectedValue = DrpCompany.SelectedValue;
		string selectedValue2 = DrpFinYear.SelectedValue;
		if (selectedValue != "Select")
		{
			if (selectedValue2 != "Select")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("AcessReport.aspx?cid=" + selectedValue + "&fyid=" + selectedValue2 + "&Key=" + randomAlphaNumeric);
			}
			else
			{
				string empty = string.Empty;
				empty = "Please select Financial Year.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		else
		{
			string empty2 = string.Empty;
			empty2 = "Please select Company name.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
		}
	}

	protected void GridView2_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			binddata(co, id);
		}
		catch (Exception)
		{
		}
	}
}

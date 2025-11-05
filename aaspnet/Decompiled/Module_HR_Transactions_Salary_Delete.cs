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

public class Module_HR_Transactions_Salary_Delete : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Label Label2;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string co = "";

	private string id = "";

	private string FyId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			Label2.Text = "";
			if (!base.IsPostBack)
			{
				TxtMrs.Visible = false;
				binddata(co, id);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label2.Text = base.Request.QueryString["msg"].ToString();
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
		sqlConnection.Open();
		try
		{
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
					string cmdText = fun.select("Id", "tblHR_Departments", "Description='" + TxtMrs.Text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					sqlDataReader.Read();
					text = " AND Department='" + sqlDataReader["Id"].ToString() + "'";
				}
			}
			else if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				string cmdText2 = fun.select("Id", "BusinessGroup", "Symbol='" + TxtMrs.Text + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				text = " AND BGGroup='" + sqlDataReader2["Id"].ToString() + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText3 = fun.select("UserID,BGGroup,Designation,EmpId,Title + '. ' + EmployeeName As EmployeeName,FinYearId,JoiningDate,Department,MobileNo,ResignationDate", "tblHR_OfficeStaff", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text2 + text + " AND ResignationDate='' AND UserID!='1' Order by UserID Desc");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UserId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGgroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			while (sqlDataReader3.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				fun.FromDateDMY(sqlDataReader3["JoiningDate"].ToString());
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", sqlDataReader3["FinyearId"], "'"));
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				dataRow[1] = sqlDataReader4["FinYear"].ToString();
				string cmdText5 = fun.select("Description AS DeptName", "tblHR_Departments", string.Concat("Id='", sqlDataReader3["Department"], "'"));
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				dataRow[4] = sqlDataReader5["DeptName"].ToString();
				string cmdText6 = fun.select("Symbol AS BGgroup", "BusinessGroup", string.Concat("Id='", sqlDataReader3["BGGroup"], "'"));
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				dataRow[5] = sqlDataReader6["BGgroup"].ToString();
				string cmdText7 = fun.select("Symbol + '-' + Type AS Designation", "tblHR_Designation", string.Concat("Id='", sqlDataReader3["Designation"], "'"));
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				dataRow[6] = sqlDataReader7["Designation"].ToString();
				dataRow[0] = sqlDataReader3["EmpId"].ToString();
				dataRow[2] = sqlDataReader3["UserId"].ToString();
				dataRow[3] = sqlDataReader3["EmployeeName"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
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
		string text = "";
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' And ResignationDate='" + text + "'");
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
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		binddata(co, id);
	}
}

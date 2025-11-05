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

public class Module_HR_Transactions_Salary_Edit : Page, IRequiresSessionState
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
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					text = " AND Department='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'";
				}
			}
			else if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				string cmdText2 = fun.select("Id", "BusinessGroup", "Symbol='" + TxtMrs.Text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					text = " AND BGGroup='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "'";
				}
			}
			DataTable dataTable = new DataTable();
			string cmdText3 = fun.select("UserID,BGGroup,Designation,EmpId,Title + '. ' + EmployeeName As EmployeeName,FinYearId,JoiningDate,Department,MobileNo,ResignationDate", "tblHR_OfficeStaff", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text2 + text + " AND ResignationDate='' AND UserID!='1' Order by UserID Desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UserId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGgroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["JoiningDate"].ToString());
					string cmdText4 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet3.Tables[0].Rows[i]["FinyearId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
					}
					string cmdText5 = fun.select("Description AS DeptName", "tblHR_Departments", string.Concat("Id='", dataSet3.Tables[0].Rows[i]["Department"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet5.Tables[0].Rows[0]["DeptName"].ToString();
					}
					string cmdText6 = fun.select("Symbol AS BGgroup", "BusinessGroup", string.Concat("Id='", dataSet3.Tables[0].Rows[i]["BGGroup"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet6.Tables[0].Rows[0]["BGgroup"].ToString();
					}
					string cmdText7 = fun.select("Symbol + '-' + Type AS Designation", "tblHR_Designation", string.Concat("Id='", dataSet3.Tables[0].Rows[i]["Designation"], "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet7.Tables[0].Rows[0]["Designation"].ToString();
					}
					dataRow[0] = dataSet3.Tables[0].Rows[i]["EmpId"].ToString();
					dataRow[2] = dataSet3.Tables[0].Rows[i]["UserId"].ToString();
					dataRow[3] = dataSet3.Tables[0].Rows[i]["EmployeeName"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
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

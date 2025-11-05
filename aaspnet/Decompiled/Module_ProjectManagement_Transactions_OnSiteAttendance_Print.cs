using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_OnSiteAttendance_Print : Page, IRequiresSessionState
{
	protected DropDownList DropDownList2;

	protected DropDownList DropDownList1;

	protected TextBox txtFromDate;

	protected CalendarExtender txtFromDate_CalendarExtender;

	protected TextBox txtToDate;

	protected CalendarExtender txtToDate_CalendarExtender;

	protected TextBox txtEmpCode;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected DropDownList DrpBGGroup;

	protected Button BtnSearch;

	protected HtmlGenericControl Iframe1;

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			txtFromDate.Attributes.Add("readonly", "readonly");
			txtToDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				dropdownFinYear(DropDownList2, CompId);
				dropdownFinYear(DrpBGGroup);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList2.SelectedValue.ToString() != "Select")
			{
				string cmdText = fun.select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + DropDownList2.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "Financial");
				List<string> list = new List<string>();
				list = fun.MonthRange(dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString(), dataSet.Tables[0].Rows[0]["FinYearTo"].ToString());
				int num = 4;
				DropDownList1.Items.Clear();
				DropDownList1.Items.Add(new ListItem("Select", "0"));
				for (int i = 0; i < 9; i++)
				{
					DropDownList1.Items.Add(new ListItem(list[i], num.ToString()));
					num++;
				}
				DropDownList1.Items.Add(new ListItem("January", "1"));
				DropDownList1.Items.Add(new ListItem("February", "2"));
				DropDownList1.Items.Add(new ListItem("March", "3"));
			}
			else
			{
				DropDownList1.Items.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public void dropdownFinYear(DropDownList dpdlFinYear, int CompId)
	{
		try
		{
			if (CompId.ToString() != "Select")
			{
				DataSet dataSet = new DataSet();
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select("*", "tblFinancial_master", "CompId='" + CompId + "'order by FinYearId Desc ");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				dpdlFinYear.DataSource = dataSet.Tables[0];
				dpdlFinYear.DataTextField = "FinYear";
				dpdlFinYear.DataValueField = "FinYearId";
				dpdlFinYear.DataBind();
				dpdlFinYear.Items.Insert(0, "Select");
			}
			else
			{
				dpdlFinYear.Items.Clear();
				dpdlFinYear.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	public void dropdownFinYear(DropDownList dpdlFinYear)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select1("*", "BusinessGroup");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "BusinessGroup");
			dpdlFinYear.DataSource = dataSet.Tables[0];
			dpdlFinYear.DataTextField = "Symbol";
			dpdlFinYear.DataValueField = "Id";
			dpdlFinYear.DataBind();
			dpdlFinYear.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql3(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		if (DropDownList2.SelectedValue.ToString() != "Select" && DropDownList1.SelectedValue.ToString() != "Select")
		{
			num2 = Convert.ToInt32(DropDownList1.SelectedValue);
			num = Convert.ToInt32(DropDownList2.SelectedValue);
			text4 = " And tblOnSiteAttendance_Master.OnSiteDate like '%-" + num2.ToString("D2") + "-%' And tblOnSiteAttendance_Master.FinYearId=" + num;
		}
		if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
		{
			text = " And tblOnSiteAttendance_Master.OnSiteDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
		}
		if (txtEmpCode.Text != string.Empty)
		{
			text2 = " And tblOnSiteAttendance_Master.EmpId='" + fun.getCode(txtEmpCode.Text) + "' ";
		}
		if (DrpBGGroup.SelectedValue.ToString() != "Select")
		{
			text3 = " And tblHR_OfficeStaff.BGGroup='" + DrpBGGroup.SelectedValue + "' ";
		}
		Iframe1.Attributes.Add("src", "OnSiteAttendance_Print_Details.aspx?m=" + text4 + "&z=" + text + "&p=" + text2 + "&q=" + text3);
	}
}

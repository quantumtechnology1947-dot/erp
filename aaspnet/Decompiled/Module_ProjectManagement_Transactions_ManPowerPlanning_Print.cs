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

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string bgid = "0";

	private string EmpId = "";

	private string m = "0";

	protected DropDownList ddlSelectBG_WONo;

	protected TextBox TxtWONo;

	protected DropDownList DrpCategory;

	protected DropDownList DrpMonths;

	protected DropDownList Drptype;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button BtnSearch;

	protected HtmlGenericControl Iframe1;

	protected SqlDataSource SqlBGGroup;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			Txtfromdate.Attributes.Add("readonly", "readonly");
			TxtTodate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Financial");
				List<string> list = new List<string>();
				list = fun.MonthRange(dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString(), dataSet.Tables[0].Rows[0]["FinYearTo"].ToString());
				int num = 4;
				DrpMonths.Items.Clear();
				DrpMonths.Items.Add(new ListItem("Select", "0"));
				for (int i = 0; i <= 8; i++)
				{
					DrpMonths.Items.Add(new ListItem(list[i], num.ToString()));
					num++;
				}
				DrpMonths.Items.Add(new ListItem("January", "1"));
				DrpMonths.Items.Add(new ListItem("February", "2"));
				DrpMonths.Items.Add(new ListItem("March", "3"));
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			if (TxtEmpName.Text != "")
			{
				text = " AND tblPM_ManPowerPlanning.EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			string text2 = "";
			int num = 0;
			if (DrpMonths.SelectedValue != "0")
			{
				text2 = " AND tblPM_ManPowerPlanning.Date Like '%-" + Convert.ToInt32(DrpMonths.SelectedValue).ToString("D2") + "-%'";
			}
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (ddlSelectBG_WONo.SelectedValue == "1" && DrpCategory.SelectedValue != "1")
			{
				text3 = " AND tblHR_OfficeStaff.BGGroup='" + DrpCategory.SelectedValue + "'";
			}
			if (ddlSelectBG_WONo.SelectedValue == "2" && TxtWONo.Text != "")
			{
				text4 = " AND tblPM_ManPowerPlanning.WONo='" + TxtWONo.Text + "'";
			}
			string text5 = "";
			if (Drptype.SelectedValue != "0")
			{
				text5 = " AND tblPM_ManPowerPlanning.Types='" + Drptype.SelectedValue + "'";
			}
			string text6 = "";
			if (Txtfromdate.Text != "" && TxtTodate.Text != "")
			{
				text6 = "  And tblPM_ManPowerPlanning.Date between  '" + fun.FromDate(Txtfromdate.Text) + "' And '" + fun.FromDate(TxtTodate.Text) + "' ";
			}
			if ((ddlSelectBG_WONo.SelectedValue == "1" && DrpCategory.SelectedValue == "1") || (ddlSelectBG_WONo.SelectedValue == "2" && TxtWONo.Text == ""))
			{
				string text7 = " Department.";
				if (ddlSelectBG_WONo.SelectedValue == "2")
				{
					text7 = " WONo.";
				}
				string empty = string.Empty;
				empty = "Please Select" + text7;
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				return;
			}
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			Iframe1.Attributes.Add("Src", "ManPowerPlanning_Print_Details.aspx?x=" + text + "&y=" + text3 + "&w=" + text4 + "&z=" + text2 + "&r=" + text5 + "&Date=" + text6 + "&Key=" + randomAlphaNumeric);
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
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

	protected void ddlSelectBG_WONo_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlSelectBG_WONo.SelectedValue == "0")
		{
			DrpCategory.Visible = false;
			TxtWONo.Visible = false;
			TxtWONo.Text = string.Empty;
			DrpCategory.SelectedValue = "1";
		}
		if (ddlSelectBG_WONo.SelectedValue == "1")
		{
			DrpCategory.Visible = true;
			TxtWONo.Visible = false;
			TxtWONo.Text = string.Empty;
		}
		if (ddlSelectBG_WONo.SelectedValue == "2")
		{
			TxtWONo.Visible = true;
			DrpCategory.Visible = false;
			DrpCategory.SelectedValue = "1";
		}
	}
}

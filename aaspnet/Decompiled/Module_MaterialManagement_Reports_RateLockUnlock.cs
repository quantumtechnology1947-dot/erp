using System;
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

public class Module_MaterialManagement_Reports_RateLockUnlock : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private string Cat = "Select";

	private string Type = "";

	private string SerCod = "0";

	private string SerItem = "0";

	private string fdate = "0";

	private string tdate = "0";

	private string LockBy = "0";

	private int CompId;

	private int FinYearId;

	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RequiredFieldValidator ReqFrDate;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected RequiredFieldValidator ReqTODate;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button btnSearch;

	protected HtmlGenericControl Iframe1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DrpType.SelectedValue != "Select")
			{
				if (DrpType.SelectedValue == "Category")
				{
					Type = "Category";
					Cat = DrpCategory1.SelectedValue;
					SerCod = DrpSearchCode.SelectedValue;
					if (DrpSearchCode.SelectedValue != "Select")
					{
						SerItem = txtSearchItemCode.Text;
					}
				}
				else if (DrpType.SelectedValue == "WOItems")
				{
					Type = "WOItems";
					Cat = "Select";
					SerCod = DrpSearchCode.SelectedValue;
					if (DrpSearchCode.SelectedValue != "Select")
					{
						SerItem = txtSearchItemCode.Text;
					}
				}
				if (Txtfromdate.Text != "" && fun.DateValidation(Txtfromdate.Text))
				{
					fdate = fun.FromDate(Txtfromdate.Text);
				}
				if (TxtTodate.Text != "" && fun.DateValidation(TxtTodate.Text))
				{
					tdate = fun.FromDate(TxtTodate.Text);
				}
				if (TxtEmpName.Text != "")
				{
					LockBy = fun.getCode(TxtEmpName.Text);
				}
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				Iframe1.Attributes.Add("src", "RateLockUnlock_Details.aspx?category=" + Cat + "&SearchCode=" + SerCod + "&FDate=" + fdate + "&TDate=" + tdate + "&LockedBy=" + LockBy + "&SearchItemCode=" + SerItem + "&loc=" + DrpSearchCode.SelectedItem.Text + "&Type=" + Type + "&Key=" + randomAlphaNumeric);
			}
			else
			{
				string empty = string.Empty;
				empty = "Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (DrpType.SelectedValue)
		{
		case "Category":
		{
			DrpSearchCode.Visible = true;
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
			DrpCategory1.Visible = true;
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = fun.select("CId,Symbol+'-'+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			DrpCategory1.DataSource = dataSet.Tables["tblDG_Category_Master"];
			DrpCategory1.DataTextField = "Category";
			DrpCategory1.DataValueField = "CId";
			DrpCategory1.DataBind();
			DrpCategory1.Items.Insert(0, "Select");
			DrpCategory1.ClearSelection();
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
			DrpSearchCode.SelectedIndex = 0;
			break;
		}
		case "WOItems":
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
			DrpSearchCode.Visible = true;
			DrpCategory1.Visible = false;
			DrpCategory1.Items.Clear();
			DrpCategory1.Items.Insert(0, "Select");
			DrpSearchCode.SelectedIndex = 0;
			break;
		case "Select":
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			break;
		}
	}

	protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory1.SelectedValue != "Select")
			{
				DrpSearchCode.SelectedIndex = 0;
				txtSearchItemCode.Text = "";
				_ = DrpCategory1.SelectedValue;
				_ = DrpSearchCode.SelectedValue;
				_ = txtSearchItemCode.Text;
			}
			else
			{
				DrpSearchCode.SelectedIndex = 0;
				txtSearchItemCode.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		_ = DrpSearchCode.SelectedValue;
		_ = DrpCategory1.SelectedValue;
		_ = txtSearchItemCode.Text;
		txtSearchItemCode.Text = "";
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
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
}

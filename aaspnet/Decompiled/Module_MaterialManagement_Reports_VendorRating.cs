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

public class Module_MaterialManagement_Reports_VendorRating : Page, IRequiresSessionState
{
	protected TextBox TxtFromDate1;

	protected CalendarExtender TxtFromDate_CalendarExtender1;

	protected RequiredFieldValidator ReqFromDt1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtToDate1;

	protected CalendarExtender TxtToDate_CalendarExtender1;

	protected RequiredFieldValidator ReqCate2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected Button BtnSearch;

	protected TabPanel Overallrating;

	protected TextBox TxtFromDate;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected TextBox TxtToDate;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected Label lblMessage;

	protected DropDownList DrpType;

	protected Label Label3;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Button1;

	protected GridView SearchGridView1;

	protected HiddenField hfSearchText;

	protected HiddenField hfSort;

	protected TabPanel SupplierWise;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string FyId = "";

	private int CId;

	private string fd1 = "";

	private string td1 = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CId = Convert.ToInt32(Session["compid"]);
			FyId = Session["finyear"].ToString();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + CId + "' And FinYearId='" + FyId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				fd1 = fun.FromDateDMY(dataSet.Tables[0].Rows[0][0].ToString());
				td1 = fun.FromDateDMY(dataSet.Tables[0].Rows[0][1].ToString());
			}
			if (!Page.IsPostBack)
			{
				BindData(SupId);
				TxtFromDate.Text = fd1;
				TxtToDate.Text = fun.FromDateDMY(fun.getCurrDate());
				TxtFromDate1.Text = fd1;
				TxtToDate1.Text = fun.FromDateDMY(fun.getCurrDate());
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindData(SupId);
		}
		catch (Exception)
		{
		}
	}

	public void BindData(string spid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string text = "";
			if (spid != "")
			{
				text = " And SupplierId='" + spid + "'";
			}
			string cmdText = "Select SupplierName,SupplierId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblMM_Supplier_master.SysDate, CHARINDEX('-', tblMM_Supplier_master.SysDate) + 1, 2) + '-' + LEFT(tblMM_Supplier_master.SysDate,CHARINDEX('-', tblMM_Supplier_master.SysDate) - 1) + '-' + RIGHT(tblMM_Supplier_master.SysDate, CHARINDEX('-', REVERSE(tblMM_Supplier_master.SysDate)) - 1)), 103), '/', '-')AS SysDate,FinYear,EmployeeName from tblMM_Supplier_master inner join tblFinancial_master on tblMM_Supplier_master.FinYearId=tblFinancial_master.FinYearId inner join tblHR_OfficeStaff on tblMM_Supplier_master.SessionId=tblHR_OfficeStaff.EmpId And tblMM_Supplier_master.CompId='" + CId + "' And tblMM_Supplier_master.FinYearId<='" + FyId + "'" + text;
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SearchGridView1.DataSource = dataSet;
			SearchGridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void Search_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtSearchValue.Text);
			BindData(code);
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
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

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string code = fun.getCode(TxtSearchValue.Text);
		BindData(code);
	}

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = TxtFromDate.Text;
			string text2 = TxtToDate.Text;
			string text3 = ((Label)gridViewRow.FindControl("LblCode")).Text;
			string selectedValue = DrpType.SelectedValue;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			base.Response.Redirect("VendorRating_Print.aspx?SupCode=" + text3 + "&FD=" + text + "&TD=" + text2 + "&Val=" + selectedValue + "&Key=" + randomAlphaNumeric);
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		string text = TxtFromDate1.Text;
		string text2 = TxtToDate1.Text;
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		base.Response.Redirect("OverallRating.aspx?FD=" + text + "&TD=" + text2 + "&Key=" + randomAlphaNumeric);
	}
}

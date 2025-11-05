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

public class Module_MaterialManagement_Masters_SupplierMaster_Print : Page, IRequiresSessionState
{
	protected Label Label3;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Search;

	protected Button btnPrintAll;

	protected GridView SearchGridView1;

	protected HiddenField hfSearchText;

	protected HiddenField hfSort;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string FyId = "";

	private int CId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CId = Convert.ToInt32(Session["compid"]);
			FyId = Session["finyear"].ToString();
			if (!Page.IsPostBack)
			{
				BindData(SupId);
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

	[ScriptMethod]
	[WebMethod]
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

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblSupId")).Text;
			base.Response.Redirect("~/Module/MaterialManagement/Masters/SupplierMaster_Print_Details.aspx?SupplierId=" + text + "&ModId=6&SubModId=22&Key=" + randomAlphaNumeric);
		}
	}

	protected void btnPrintAll_Click(object sender, EventArgs e)
	{
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		base.Response.Redirect("~/Module/MaterialManagement/Masters/Supplier_Details_Print_All.aspx?ModId=6&SubModId=22&Key=" + randomAlphaNumeric);
	}
}

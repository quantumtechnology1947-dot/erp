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

public class Module_Design_Transactions_TPL_Design_CopyWo : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string WoNoDest = "";

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int pid;

	private int childid;

	protected DropDownList DropDownList1;

	protected ScriptManager ScriptManager1;

	protected TextBox txtSearchCustomer;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Button1;

	protected Button Button2;

	protected Label lblasslymsg;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			WoNoDest = base.Request.QueryString["WONoDest"].ToString();
			pid = Convert.ToInt32(base.Request.QueryString["DestPId"]);
			childid = Convert.ToInt32(base.Request.QueryString["DestCId"]);
			lblasslymsg.Text = "";
			if (base.Request.QueryString["msg"] != "")
			{
				lblasslymsg.Text = base.Request.QueryString["msg"];
			}
			if (!Page.IsPostBack)
			{
				string text = fun.revDate("SD_Cust_WorkOrder_Master.SysDate", "SysDate");
				string odr = " Order by SD_Cust_WorkOrder_Master.Id Desc";
				string text2 = "";
				text2 = ((!(DropDownList1.SelectedValue == "SD_Cust_Master.CustomerId")) ? txtSearchCustomer.Text : fun.getCode(TxtSearchValue.Text));
				fun.BindDataCustIMaster("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + CompId + " AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' AND tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId ", SearchGridView1, DropDownList1.SelectedValue, text2, odr);
				for (int i = 0; i < SearchGridView1.Rows.Count; i++)
				{
					SearchGridView1.Rows[i].Cells[6].Text = "<a href=TPL_Design_Copy_Tree.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&DestPId=" + pid + "&DestCId=" + childid + "&ModId=3&SubModId=23>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
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

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			string text = fun.revDate("SD_Cust_WorkOrder_Master.SysDate", "SysDate");
			string odr = " Order by SD_Cust_WorkOrder_Master.Id Desc";
			string text2 = "";
			text2 = ((!(DropDownList1.SelectedValue == "SD_Cust_Master.CustomerId")) ? txtSearchCustomer.Text : fun.getCode(TxtSearchValue.Text));
			fun.BindDataCustIMaster("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + CompId + " AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' AND tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId ", SearchGridView1, DropDownList1.SelectedValue, text2, odr);
			for (int i = 0; i < SearchGridView1.Rows.Count; i++)
			{
				SearchGridView1.Rows[i].Cells[6].Text = "<a href=TPL_Design_Copy_Tree.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&DestPId=" + pid + "&DestCId=" + childid + "&ModId=3&SubModId=23>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearchWo_Click(object sender, EventArgs e)
	{
		try
		{
			string text = fun.revDate("SD_Cust_WorkOrder_Master.SysDate", "SysDate");
			string odr = " Order by SD_Cust_WorkOrder_Master.Id Desc";
			string text2 = "";
			text2 = ((!(DropDownList1.SelectedValue == "SD_Cust_Master.CustomerId")) ? txtSearchCustomer.Text : fun.getCode(TxtSearchValue.Text));
			fun.BindDataCustIMaster("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + CompId + " AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' AND tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId ", SearchGridView1, DropDownList1.SelectedValue, text2, odr);
			for (int i = 0; i < SearchGridView1.Rows.Count; i++)
			{
				SearchGridView1.Rows[i].Cells[6].Text = "<a href=TPL_Design_Copy_Tree.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&DestPId=" + pid + "&DestCId=" + childid + "&ModId=3&SubModId=23>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		Page.ClientScript.RegisterClientScriptBlock(GetType(), "myUniqueKey", "self.parent.location='TPL_Design_WO_TreeView.aspx?WONo=" + WoNoDest + "&ModId=3&SubModId=23';", addScriptTags: true);
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = fun.revDate("SD_Cust_WorkOrder_Master.SysDate", "SysDate");
			string odr = " Order by SD_Cust_WorkOrder_Master.Id Desc";
			if (DropDownList1.SelectedValue == "SD_Cust_Master.CustomerId")
			{
				txtSearchCustomer.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				string code = fun.getCode(TxtSearchValue.Text);
				fun.BindDataCustIMaster("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + CompId + " AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' AND tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId ", SearchGridView1, DropDownList1.SelectedValue, code, odr);
			}
			if (DropDownList1.SelectedValue == "SD_Cust_WorkOrder_Master.EnqId" || DropDownList1.SelectedValue == "SD_Cust_WorkOrder_Master.WONo" || DropDownList1.SelectedValue == "SD_Cust_WorkOrder_Master.PONo" || DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
				txtSearchCustomer.Text = "";
				fun.BindDataCustIMaster("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + CompId + " AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' AND tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId ", SearchGridView1, DropDownList1.SelectedValue, txtSearchCustomer.Text, odr);
			}
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
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

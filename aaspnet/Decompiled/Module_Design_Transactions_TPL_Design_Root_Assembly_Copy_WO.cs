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

public class Module_Design_Transactions_TPL_Design_Root_Assembly_Copy_WO : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtSearchCustomer;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	private clsFunctions fun = new clsFunctions();

	private string WoNoDest = "";

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string CId2 = "";

	private string Eid = "";

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
			if (!Page.IsPostBack)
			{
				BindDataCust(CId2, Eid);
				for (int i = 0; i < SearchGridView1.Rows.Count; i++)
				{
					SearchGridView1.Rows[i].Cells[6].Text = "<a href='TPL_Design_Root_Assembly_Copy_Grid.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&ModId=3&SubModId=23'>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
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
			BindDataCust(CId2, Eid);
			for (int i = 0; i < SearchGridView1.Rows.Count; i++)
			{
				SearchGridView1.Rows[i].Cells[6].Text = "<a href='TPL_Design_Root_Assembly_Copy_Grid.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&ModId=3&SubModId=23'>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + WoNoDest + "&ModId=3&SubModId=23");
	}

	protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtSearchCustomer.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(CId2, Eid);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
				txtSearchCustomer.Text = "";
				BindDataCust(CId2, Eid);
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
			BindDataCust(CId2, Eid);
			for (int i = 0; i < SearchGridView1.Rows.Count; i++)
			{
				SearchGridView1.Rows[i].Cells[6].Text = "<a href='TPL_Design_Root_Assembly_Copy_Grid.aspx?WONoSrc=" + SearchGridView1.Rows[i].Cells[6].Text + "&WONoDest=" + WoNoDest + "&ModId=3&SubModId=23'>" + SearchGridView1.Rows[i].Cells[6].Text + "</a>";
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "1" && txtSearchCustomer.Text != "")
			{
				text = " AND EnqId='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtSearchCustomer.Text != "")
			{
				text = " AND PONo='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtSearchCustomer.Text != "")
			{
				text = " AND WONo='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text2 = " AND CustomerId='" + code + "'";
			}
			string cmdText = fun.select("EnqId,CustomerId,WONo,PONo,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", " FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'" + text + text2 + "Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", " FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat(" FinYearId<='", FinYearId, "' AND CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					}
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0]["CustomerId"].ToString();
					}
					dataRow[3] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
			sqlConnection.Close();
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

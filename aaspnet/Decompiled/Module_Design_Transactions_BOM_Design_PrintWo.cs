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

public class Module_Design_Transactions_BOM_Design_PrintWo : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string CId2 = "";

	private string Eid = "";

	private int h;

	protected DropDownList DropDownList1;

	protected TextBox txtSearchCustomer;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	protected Panel Panel1;

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
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				BindDataCust(CId2, Eid, h);
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
		SearchGridView1.PageIndex = e.NewPageIndex;
		try
		{
			BindDataCust(CId2, Eid, h);
		}
		catch (Exception)
		{
		}
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
				BindDataCust(CId2, Eid, h);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
				txtSearchCustomer.Text = "";
				BindDataCust(CId2, Eid, h);
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
			BindDataCust(CId2, Eid, h);
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID, int C)
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
				text2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string text3 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				text3 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			string cmdText = fun.select("SD_Cust_WorkOrder_Master.Id,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo,SD_Cust_WorkOrder_Master.SessionId,SD_Cust_WorkOrder_Master.FinYearId, SD_Cust_WorkOrder_Master.SysDate  As WODate ", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "'And SD_Cust_WorkOrder_Master.CompId='" + CompId + "'" + text + text2 + text3 + "Order by WONo ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("UpToDate", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("SysDate  As BOMDate", "tblDG_BOM_Master", " FinYearId<='" + FinYearId + "'AND CompId='" + CompId + "'  AND  WONo='" + dataSet.Tables[0].Rows[i]["WONo"].ToString() + "'  order by SysDate Asc");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["BOMDate"].ToString());
					}
					string cmdText3 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", " FinYearId<='" + FinYearId + "'AND CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					string cmdText5 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("FinYearId<='", FinYearId, "'And CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
					}
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString();
						dataRow[2] = dataSet3.Tables[0].Rows[0]["CustomerId"].ToString();
					}
					dataRow[4] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["WODate"].ToString());
					dataRow[7] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataRow[8] = fun.FromDateDMY(fun.getCurrDate());
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
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

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				if (((TextBox)gridViewRow.FindControl("TxtBOMDate")).Text != "" && ((TextBox)gridViewRow.FindControl("TxtUptoDate")).Text != "")
				{
					Convert.ToInt32(((Label)gridViewRow.FindControl("LblId")).Text);
					string text = ((Label)gridViewRow.FindControl("LblWONo")).Text;
					string text2 = ((TextBox)gridViewRow.FindControl("TxtBOMDate")).Text;
					string text3 = ((TextBox)gridViewRow.FindControl("TxtUptoDate")).Text;
					base.Response.Redirect("BOM_Design_Print_Tree.aspx?WONo=" + text + "&SD=" + text2 + "&TD=" + text3 + "&ModId=3&SubModId=26");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			BindDataCust(CId2, Eid, c);
		}
		else
		{
			BindDataCust(CId2, Eid, h);
		}
	}
}

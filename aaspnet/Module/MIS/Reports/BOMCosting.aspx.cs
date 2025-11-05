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

public class Module_MIS_Reports_BOMCosting : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtSearchCustomer;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId2 = "";

	private string Eid = "";

	private string sId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
				BindDataCust(CId2, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		try
		{
			BindDataCust(CId2, Eid);
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
			string cmdText = fun.select("EnqId,CustomerId,WONo,PONo,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", " FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'" + text + text2 + "Order by WONo ASC");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select(" ItemId,WONo,PId,CId,Qty,Id,AmdNo", "tblDG_BOM_Master", string.Concat("WONo='", sqlDataReader["WONO"], "' And CompId='", CompId, "' And FinYearId<='", FinYearId, "' Order By Id ASC"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2.HasRows)
				{
					dataRow[8] = Convert.ToInt32(sqlDataReader2["PId"]);
					dataRow[9] = Convert.ToInt32(sqlDataReader2["CId"]);
					string cmdText3 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", string.Concat("CompId='", CompId, "' AND FinYearId<='", FinYearId, "'  AND  CustomerId='", sqlDataReader["CustomerId"], "'"));
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					string cmdText4 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", sqlDataReader["FinYearId"], "'"));
					SqlCommand selectCommand = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet.Tables[0].Rows[0]["FinYear"].ToString();
					}
					while (sqlDataReader3.Read())
					{
						dataRow[1] = sqlDataReader3["CustomerName"];
						dataRow[2] = sqlDataReader3["CustomerId"];
					}
					dataRow[3] = sqlDataReader["PONo"];
					dataRow[4] = sqlDataReader["WONo"];
					dataRow[5] = sqlDataReader["EnqId"];
					dataRow[6] = sqlDataReader["SysDate"];
					string cmdText5 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND FinYearId<='", FinYearId, "' AND EmpId='", sqlDataReader["SessionId"], "'"));
					SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					while (sqlDataReader4.Read())
					{
						dataRow[7] = sqlDataReader4["EmployeeName"];
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

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((LinkButton)gridViewRow.FindControl("LinkButton1")).Text;
				_ = ((Label)gridViewRow.FindControl("LblPId")).Text;
				_ = ((Label)gridViewRow.FindControl("LblCId")).Text;
				int num = Convert.ToInt32(((RadioButtonList)gridViewRow.FindControl("RadRate")).SelectedValue);
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("BOMCosting_Report.aspx?WONo=" + text + "&PId=&CId=&RadVal=" + num + "&Key=" + randomAlphaNumeric + "&ModId=14&SubModId=");
			}
		}
		catch (Exception)
		{
		}
	}
}

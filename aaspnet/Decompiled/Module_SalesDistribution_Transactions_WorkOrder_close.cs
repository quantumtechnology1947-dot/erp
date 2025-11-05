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

public class Module_SalesDistribution_Transactions_WorkOrder_close : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CId = "";

	private string Eid = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid);
			}
			string cmdText = fun.delete("SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			foreach (GridViewRow row in SearchGridView1.Rows)
			{
				string text = ((Label)row.FindControl("LblId")).Text;
				string cmdText2 = fun.select("CloseOpen", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "' And Id='" + text + "'  ");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				int num = 0;
				while (sqlDataReader.Read())
				{
					if (Convert.ToInt32(sqlDataReader["CloseOpen"]) == 0)
					{
						((LinkButton)row.FindControl("btnOpen")).Visible = false;
						((LinkButton)row.FindControl("BtnClosed")).Visible = true;
					}
					else
					{
						((LinkButton)row.FindControl("btnOpen")).Visible = true;
						((LinkButton)row.FindControl("BtnClosed")).Visible = false;
					}
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			DataTable dataTable = new DataTable();
			string text = "";
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				text = " AND EnqId='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtEnqId.Text != "")
			{
				text = " AND PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtEnqId.Text != "")
			{
				text = " AND WONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text2 = " AND CustomerId='" + code + "'";
			}
			string cmdText = fun.select("Id,CloseOpen,EnqId,CustomerId,WONo,PONo,POId,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'" + text + text2 + "Order by WONo ASC");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Option", typeof(string)));
			while (sqlDataReader.Read())
			{
				string text3 = "";
				int num = 0;
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + sqlDataReader["CustomerId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				while (sqlDataReader3.Read())
				{
					dataRow[0] = sqlDataReader3["FinYear"].ToString();
				}
				while (sqlDataReader2.Read())
				{
					dataRow[1] = sqlDataReader2["CustomerName"].ToString();
					dataRow[2] = sqlDataReader2["CustomerId"].ToString();
				}
				dataRow[3] = sqlDataReader["PONo"].ToString();
				dataRow[4] = sqlDataReader["WONo"].ToString();
				dataRow[5] = sqlDataReader["EnqId"].ToString();
				dataRow[6] = sqlDataReader["SysDate"].ToString();
				dataRow[8] = sqlDataReader["POId"].ToString();
				string cmdText4 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + sqlDataReader["SessionId"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				while (sqlDataReader4.Read())
				{
					dataRow[7] = sqlDataReader4["EmployeeName"].ToString();
				}
				dataRow[9] = Convert.ToInt32(sqlDataReader["Id"]);
				text3 = ((Convert.ToInt32(sqlDataReader["CloseOpen"]) != 0) ? "Close" : "Open");
				dataRow[10] = text3;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
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
			BindDataCust(CId, Eid);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			txtEnqId.Visible = false;
			TxtSearchValue.Visible = true;
			TxtSearchValue.Text = "";
			BindDataCust(CId, Eid);
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
		{
			txtEnqId.Visible = true;
			TxtSearchValue.Visible = false;
			txtEnqId.Text = "";
			BindDataCust(CId, Eid);
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
		try
		{
			con.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("LblId")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtremarks")).Text;
			if (e.CommandName == "Open")
			{
				if (text2 != "")
				{
					string cmdText = fun.update("SD_Cust_WorkOrder_Master", "SysDate='" + currDate + "' ,SysTime='" + currTime + "',SessionId='" + sId + "' , CloseOpen='0',Remarks='" + text2 + "'", "Id='" + text + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Enter reason for wo open.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Close")
			{
				if (text2 != "")
				{
					string cmdText2 = fun.update("SD_Cust_WorkOrder_Master", "SysDate='" + currDate + "' ,SysTime='" + currTime + "',SessionId='" + sId + "' , CloseOpen='1',Remarks='" + text2 + "'", "Id='" + text + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Enter reason for wo close.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

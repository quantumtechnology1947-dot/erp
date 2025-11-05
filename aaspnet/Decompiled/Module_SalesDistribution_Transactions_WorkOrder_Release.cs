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

public class Module_SalesDistribution_Transactions_WorkOrder_Release : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CId = "";

	private string Eid = "";

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected Label Label2;

	protected GridView GridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Label2.Text = "";
			if (base.Request.QueryString["msg"] != "")
			{
				Label2.Text = base.Request.QueryString["msg"];
			}
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
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

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
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
			string cmdText = fun.select("Id,EnqId,CustomerId,WONo,PONo,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", "FinYearId<='" + num + "' AND CloseOpen='0'  AND CompId='" + num2 + "'" + text + text2 + "Order by WONo ASC");
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
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + num2 + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", num2, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
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
					dataRow[8] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			sqlConnection.Close();
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
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "Select" || DropDownList1.SelectedValue == "3")
		{
			txtEnqId.Visible = true;
			TxtSearchValue.Visible = false;
			txtEnqId.Text = "";
			BindDataCust(CId, Eid);
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

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}

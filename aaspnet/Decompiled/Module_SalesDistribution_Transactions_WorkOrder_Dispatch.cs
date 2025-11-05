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

public class Module_SalesDistribution_Transactions_WorkOrder_Dispatch : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected Label Label2;

	protected GridView SearchGridView1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CId = "";

	private string Eid = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			Label2.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label2.Text = base.Request.QueryString["msg"];
			}
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sqlConnection.Open();
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid);
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
				text = " AND SD_Cust_WorkOrder_Release.WONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			if (DropDownList1.SelectedValue == "2" && txtEnqId.Text != "")
			{
				text = " AND SD_Cust_WorkOrder_Release.WRNo='" + txtEnqId.Text + "'";
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string cmdText = "select Distinct SD_Cust_WorkOrder_Release.WRNo,SD_Cust_WorkOrder_Release.WONo,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Release.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Release.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Release.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Release.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Release.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Release.SysDate)) - 1)), 103), '/', '-')AS SysDate,SD_Cust_WorkOrder_Master.CustomerId,FinYear,CustomerName,Title+'.'+EmployeeName As EmpLoyeeName,(SELECT SUM(SD_Cust_WorkOrder_Products_Details.Qty) FROM  SD_Cust_WorkOrder_Master INNER JOIN SD_Cust_WorkOrder_Products_Details ON SD_Cust_WorkOrder_Master.Id = SD_Cust_WorkOrder_Products_Details.MId GROUP BY SD_Cust_WorkOrder_Master.WONo Having SD_Cust_WorkOrder_Master.WONo=SD_Cust_WorkOrder_Release.WONo ) As WOQty,(SELECT SUM(SD_Cust_WorkOrder_Dispatch.DispatchQty) FROM SD_Cust_WorkOrder_Release INNER JOIN SD_Cust_WorkOrder_Dispatch ON SD_Cust_WorkOrder_Release.Id = SD_Cust_WorkOrder_Dispatch.WRId GROUP BY SD_Cust_WorkOrder_Release.WONo having SD_Cust_WorkOrder_Release.WONo=SD_Cust_WorkOrder_Master.WONo) As DAQty from SD_Cust_WorkOrder_Release,SD_Cust_WorkOrder_Master,SD_Cust_Master,tblFinancial_master,tblHR_OfficeStaff where SD_Cust_WorkOrder_Release.FinYearId<='" + num + "' AND SD_Cust_WorkOrder_Release.WONo=SD_Cust_WorkOrder_Master.WONo  And SD_Cust_WorkOrder_Master.CloseOpen=0 And SD_Cust_Master.CustomerId=SD_Cust_WorkOrder_Master.CustomerId And tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Release.FinYearId And tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Release.SessionId  AND SD_Cust_WorkOrder_Release.CompId='" + num2 + "'" + text + text2 + " Order by SD_Cust_WorkOrder_Release.WONo ASC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			while (sqlDataReader.Read())
			{
				double num3 = 0.0;
				double num4 = 0.0;
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["FinYear"].ToString();
				dataRow[1] = sqlDataReader["CustomerName"].ToString();
				dataRow[2] = sqlDataReader["CustomerId"].ToString();
				dataRow[3] = sqlDataReader["WRNo"].ToString();
				dataRow[4] = sqlDataReader["WONo"].ToString();
				dataRow[5] = sqlDataReader["SysDate"].ToString();
				dataRow[6] = sqlDataReader["EmployeeName"].ToString();
				if (sqlDataReader["DAQty"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(sqlDataReader["DAQty"]);
				}
				num4 = Convert.ToDouble(sqlDataReader["WOQty"]);
				if (Math.Round(num4 - num3, 3) > 0.0)
				{
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtEnqId.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(CId, Eid);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
				txtEnqId.Text = "";
				BindDataCust(CId, Eid);
			}
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

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

public class Module_SalesDistribution_Transactions_CustPO_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CId = "";

	private string Eid = "";

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected Label Label2;

	protected GridView SearchGridView1;

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
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid);
			}
			Label2.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label2.Text = base.Request.QueryString["msg"].ToString();
			}
			sqlConnection.Open();
			string cmdText = fun.delete("SD_Cust_PO_Details_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
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
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				text = " AND CustomerId='" + fun.getCode(TxtSearchValue.Text) + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				text = " AND EnqId='" + txtEnqId.Text + "'";
			}
			string cmdText = fun.select("Flag,EnqId,FinYearId ,CustomerName,CustomerId,SessionId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_Enquiry_Master.SysDate,CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_Enquiry_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_Enquiry_Master", "CustomerId!='' AND FinYearId<='" + num + "' AND CompId='" + num2 + "'" + text + "Order by EnqId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = fun.select("CloseOpen", "SD_Cust_WorkOrder_Master", "FinYearId<='" + num + "' AND CompId='" + num2 + "'  And EnqId='" + dataSet.Tables[0].Rows[i]["EnqId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				int num3 = 0;
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					num3 = ((Convert.ToInt32(dataSet2.Tables[0].Rows[0]["CloseOpen"]) != 0) ? 1 : 0);
				}
				if (num3 == 0)
				{
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
					dataRow[1] = dataSet.Tables[0].Rows[i]["CustomerName"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["CustomerId"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			txtEnqId.Visible = false;
			TxtSearchValue.Visible = true;
			TxtSearchValue.Text = "";
			BindDataCust(CId, Eid);
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select")
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
}

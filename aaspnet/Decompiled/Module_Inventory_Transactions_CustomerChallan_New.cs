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

public class Module_Inventory_Transactions_CustomerChallan_New : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Search;

	protected GridView SearchGridView1;

	protected GridView GridView1;

	protected HtmlGenericControl Up;

	private clsFunctions fun = new clsFunctions();

	private string CId = "";

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
			if (!Page.IsPostBack)
			{
				BindDataCust(CId);
			}
			Up.Visible = true;
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
			BindDataCust(CId);
		}
		catch (Exception)
		{
		}
	}

	protected void Search_Click(object sender, EventArgs e)
	{
		try
		{
			if (TxtSearchValue.Text != "")
			{
				BindDataCust(TxtSearchValue.Text);
			}
			else
			{
				BindDataCust(CId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid)
	{
		try
		{
			con.Open();
			string value = "";
			if (TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				value = " AND CustomerId='" + code + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCustomer", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CustId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CustId"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SearchGridView1.DataSource = dataSet;
			SearchGridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			if (!string.IsNullOrEmpty(ViewState["CustId"].ToString()))
			{
				text = ViewState["CustId"].ToString();
			}
			string cmdText = fun.select("Id,EnqId,TaskProjectTitle,CustomerId,WONo,PONo,POId,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "' AND CloseOpen='0'  And  CustomerId='" + text + "' AND CompId='" + CompId + "' Order by Id Desc ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[1] = dataSet.Tables[0].Rows[i]["TaskProjectTitle"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["POId"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
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
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblCustomerId")).Text;
				ViewState["CustId"] = text;
				LoadData();
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
			LoadData();
		}
		catch (Exception)
		{
		}
	}
}

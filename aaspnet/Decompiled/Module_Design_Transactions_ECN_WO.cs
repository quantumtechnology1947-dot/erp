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

public class Module_Design_Transactions_ECN_WO : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CId = "";

	private string Eid = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	private int h;

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected GridView SearchGridView1;

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
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid, h);
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
			BindDataCust(CId, Eid, h);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text, h);
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID, int C)
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				text = " AND WONo='" + txtEnqId.Text + "'";
			}
			string text2 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				text2 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string text3 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text3 = " AND CustomerId='" + code + "'";
			}
			string cmdText = fun.select("Id,EnqId,TaskProjectTitle,CustomerId,WONo,SessionId,FinYearId,SysDate", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "'  And WONo in(Select Distinct (WONo) from tblDG_ECN_Master where Flag=0)  AND CloseOpen='0' AND CompId='" + CompId + "'" + text + text3 + text2 + "Order by WONo ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
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
					dataRow[3] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["TaskProjectTitle"].ToString();
					dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			txtEnqId.Visible = false;
			TxtSearchValue.Visible = true;
			TxtSearchValue.Text = "";
			BindDataCust(CId, Eid, h);
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
		{
			txtEnqId.Visible = true;
			TxtSearchValue.Visible = false;
			txtEnqId.Text = "";
			BindDataCust(CId, Eid, h);
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

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			BindDataCust(CId, Eid, c);
		}
		else
		{
			BindDataCust(CId, Eid, h);
		}
	}
}

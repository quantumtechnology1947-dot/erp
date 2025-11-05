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

public class Module_Accounts_Transactions_CashVoucher_Print : Page, IRequiresSessionState
{
	protected Label lblPaidToSearch;

	protected TextBox txtPaidto;

	protected Button Button1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView1;

	protected TabPanel TabPanel1;

	protected Label Label2;

	protected TextBox TxtCashRecAgainst;

	protected Button btnCashRecAgainst;

	protected AutoCompleteExtender AutoCompleteExtender2;

	protected GridView GridView2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string PaidTo = "";

	private string CashRecAgainst = "";

	private string str = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				FillData(PaidTo);
				FillDataRec(CashRecAgainst);
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillData(string paidto)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CVPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CodeType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Receivedby", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId ", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			string text = "";
			text = ((!(txtPaidto.Text != "")) ? "" : (" And PaidTo like'%" + paidto + "%'"));
			string cmdText = fun.select("*", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "'" + text + " order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["CVPNo"].ToString();
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'  AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
				}
				dataRow[3] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["PaidTo"].ToString();
				int num = 0;
				num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeType"].ToString());
				string cmdText3 = "";
				switch (num)
				{
				case 1:
					dataRow[5] = "Employee";
					cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
					break;
				case 2:
					dataRow[5] = "Customer";
					cmdText3 = fun.select("CustomerName+'[ '+CustomerId+']'  As EmpName", "SD_Cust_master", string.Concat("CompId='", CompId, "' AND CustomerId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
					break;
				case 3:
					dataRow[5] = "Supplier";
					cmdText3 = fun.select("SupplierName+'[ '+SupplierId+']'  As  EmpName", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' AND SupplierId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
					break;
				}
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[6] = dataSet3.Tables[0].Rows[0]["EmpName"].ToString();
				string cmdText4 = fun.select("Sum(Amount)As Amount", "tblACC_CashVoucher_Payment_Details", "MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = dataSet4.Tables[0].Rows[0]["Amount"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
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
			PaidTo = txtPaidto.Text;
			FillData(PaidTo);
			TabContainer1.ActiveTabIndex = 0;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			try
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("CashVoucher_Payment_Print_Details.aspx?CVPId=" + text + "&ModId=11&SubModId=113&Key=" + randomAlphaNumeric);
			}
			catch (Exception)
			{
			}
		}
	}

	public void FillDataRec(string Cash_recAgainst)
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CVRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedAgainst", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedAgainstType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedByType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			string text = "";
			text = ((!(TxtCashRecAgainst.Text != "")) ? "" : (" And CashReceivedAgainst like'%" + Cash_recAgainst + "%'"));
			string cmdText = fun.select("*", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "'" + text + " order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["CVRNo"].ToString();
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'  AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
				}
				dataRow[3] = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[4] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRA"].ToString()), dataSet.Tables[0].Rows[i]["CashReceivedAgainst"].ToString(), CompId);
				int num = 0;
				switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRA"].ToString()))
				{
				case 1:
					dataRow[5] = "Employee";
					break;
				case 2:
					dataRow[5] = "Customer";
					break;
				case 3:
					dataRow[5] = "Supplier";
					break;
				}
				dataRow[6] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRB"].ToString()), dataSet.Tables[0].Rows[i]["CashReceivedBy"].ToString(), CompId);
				int num2 = 0;
				switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRB"].ToString()))
				{
				case 1:
					dataRow[7] = "Employee";
					break;
				case 2:
					dataRow[7] = "Customer";
					break;
				case 3:
					dataRow[7] = "Supplier";
					break;
				}
				dataRow[8] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			CashRecAgainst = fun.getCode(TxtCashRecAgainst.Text);
			FillDataRec(CashRecAgainst);
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel_R")
		{
			try
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId_R")).Text;
				base.Response.Redirect("CashVoucher_Receipt_Print_Details.aspx?CVRId=" + text + "&ModId=11&SubModId=113&Key=" + randomAlphaNumeric);
			}
			catch (Exception)
			{
			}
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("Distinct PaidTo", "tblACC_CashVoucher_Payment_Master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblACC_CashVoucher_Payment_Master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[0].ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql1(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = "Select EmployeeName+'['+EmpId+']' AS AllName  from tblHR_OfficeStaff where CompId='" + num + "' union select CustomerName+'['+CustomerId+']' AS AllName from SD_Cust_master where CompId='" + num + "' union select SupplierName+'['+SupplierId+']' AS AllName from tblMM_Supplier_master where CompId='" + num + "'";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet);
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[0].ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			PaidTo = txtPaidto.Text;
			FillData(PaidTo);
		}
		catch (Exception)
		{
		}
	}

	protected void btnCashRecAgainst_Click(object sender, EventArgs e)
	{
		try
		{
			CashRecAgainst = fun.getCode(TxtCashRecAgainst.Text);
			FillDataRec(CashRecAgainst);
		}
		catch (Exception)
		{
		}
	}
}

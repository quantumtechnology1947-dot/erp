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

public class Module_Accounts_Transactions_SundryCreditors_Details : Page, IRequiresSessionState
{
	protected Label lblOf;

	protected TextBox TextBox1;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected Button btn_Search;

	protected Button Button2;

	protected Button Button1;

	protected GridView GridView1;

	protected Label Label3;

	protected Label lblTotal;

	protected Label Label4;

	protected Label lblTotal1;

	protected Label Label5;

	protected Label lblTotal2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = string.Empty;

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = string.Empty;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string GetCategory = string.Empty;

	private double CreditTotal;

	private double OpeningAmt;

	private double DebitTotal;

	private double ClosingTotal;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			GetCategory = base.Request.QueryString["lnkFor"];
			lblOf.Text = GetCategory;
			if (!Page.IsPostBack)
			{
				FillGrid_Creditors();
				lblTotal.Text = CreditTotal.ToString();
				lblTotal1.Text = DebitTotal.ToString();
				lblTotal2.Text = (CreditTotal - DebitTotal).ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "LnkBtn")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string empty = string.Empty;
				empty = ((Label)gridViewRow.FindControl("lblSupId")).Text;
				base.Response.Redirect("SundryCreditors_InDetailList.aspx?SupId=" + empty + "&ModId=11&SubModId=135&Key=" + randomAlphaNumeric + "&lnkFor=" + GetCategory);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=135");
	}

	public void FillGrid_Creditors()
	{
		try
		{
			_ = string.Empty;
			if (TextBox1.Text != string.Empty)
			{
				_ = " And tblMM_Supplier_master.SupplierId='" + fun.getCode(TextBox1.Text) + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("SupId,SupplierId,SupplierName+' ['+SupplierId+']' AS SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' order by SupplierId Asc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BookBillAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PaymentAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ClosingAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["SupId"].ToString();
				dataRow[1] = sqlDataReader["SupplierName"].ToString();
				string cmdText2 = fun.select("OpeningAmt", "tblACC_Creditors_Master", "SupplierId='" + sqlDataReader["SupplierId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				double num = 0.0;
				if (sqlDataReader2.HasRows && sqlDataReader2["OpeningAmt"] != DBNull.Value)
				{
					num = Math.Round(Convert.ToDouble(sqlDataReader2["OpeningAmt"]), 2);
				}
				double num2 = 0.0;
				num2 = fun.FillGrid_CreditorsBookedBill(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), GetCategory);
				dataRow[3] = Math.Round(num2, 2);
				double num3 = 0.0;
				num3 = fun.FillGrid_CreditorsPayment(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), 0, GetCategory);
				double num4 = 0.0;
				num4 = fun.FillGrid_CreditorsCashPayment(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), 0, GetCategory);
				dataRow[4] = Math.Round(num3 + num4, 2);
				dataRow[6] = sqlDataReader["SupplierId"].ToString();
				if (num2 > 0.0)
				{
					CreditTotal += Math.Round(num2 + num, 2);
					DebitTotal += Math.Round(num3 + num4, 2);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			ViewState["ToExport"] = dataTable;
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			FillGrid_Creditors();
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql3(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		int num2 = 0;
		switch ((contextKey == "key2") ? 1 : 2)
		{
		case 1:
		{
			string selectCommandText2 = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order By CustomerName ASC");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			break;
		}
		case 2:
		{
			string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "' Order By SupplierName ASC");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
			break;
		}
		}
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

	protected void btn_Search_Click(object sender, EventArgs e)
	{
		FillGrid_Creditors();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SundryCreditors.aspx?ModId=&SubModId=");
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable = (DataTable)ViewState["ToExport"];
		ExportToExcel exportToExcel = new ExportToExcel();
		exportToExcel.ExportDataToExcel(dataTable, "Ledger Extracts.");
	}
}

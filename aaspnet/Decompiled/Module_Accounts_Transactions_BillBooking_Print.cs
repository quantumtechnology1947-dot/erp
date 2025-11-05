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

public class Module_Accounts_Transactions_BillBooking_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string PONo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected TextBox Txtfield;

	protected Button Button1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView2;

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
				Txtfield.Visible = false;
				loadData(SupId, PONo);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string spid, string pono)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			sqlConnection.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "2" && Txtfield.Text != "")
			{
				text = " And PVEVNo='" + Txtfield.Text + "'";
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "1" && txtSupplier.Text != "")
			{
				string code = fun.getCode(txtSupplier.Text);
				text2 = " And SupplierId='" + code + "'";
			}
			if (DropDownList1.SelectedValue == "0")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
			}
			string cmdText = fun.select("Id  , SysDate , SysTime  , SessionId , CompId , FinYearId, PVEVNo, SupplierId , BillNo, BillDate , CENVATEntryNo, CENVATEntryDate, OtherCharges, OtherChaDesc, Narration , DebitAmt , DiscountType, Discount ,Authorize,AuthorizeBy,AuthorizeDate,AuthorizeTime", "tblACC_BillBooking_Master", "  FinYearId<='" + FinYearId + "'  And CompId='" + CompId + "'" + text + text2 + " Order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("By", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Key", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num = Convert.ToInt32(sqlDataReader["FinYearId"].ToString());
				string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				string cmdText2 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + sqlDataReader["SupplierId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
				{
					_ = " And PONo='" + Txtfield.Text + "'";
				}
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader["FinYearId"].ToString();
				string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3.HasRows)
				{
					dataRow[2] = sqlDataReader3["FinYear"].ToString();
				}
				dataRow[3] = sqlDataReader["PVEVNo"].ToString();
				dataRow[4] = value;
				dataRow[7] = sqlDataReader["SupplierId"].ToString();
				if (sqlDataReader2.HasRows)
				{
					dataRow[8] = sqlDataReader2["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				}
				if (sqlDataReader["AuthorizeBy"] != DBNull.Value)
				{
					string cmdText4 = fun.select("Title+' '+EmployeeName As Name", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["AuthorizeBy"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					dataRow[9] = sqlDataReader4["Name"].ToString();
					dataRow[10] = fun.FromDateDMY(sqlDataReader["AuthorizeDate"].ToString());
					dataRow[11] = sqlDataReader["AuthorizeTime"].ToString();
				}
				dataRow[12] = randomAlphaNumeric;
				dataRow[13] = sqlDataReader["BillNo"].ToString();
				dataRow[14] = fun.FromDateDMY(sqlDataReader["BillDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "1")
		{
			Txtfield.Visible = false;
			txtSupplier.Visible = true;
			txtSupplier.Text = "";
			loadData(SupId, PONo);
		}
		if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "0")
		{
			Txtfield.Visible = true;
			txtSupplier.Visible = false;
			Txtfield.Text = "";
			loadData(SupId, PONo);
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			text = fun.getCode(txtSupplier.Text);
			text2 = Txtfield.Text;
			loadData(text, text2);
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
			loadData(SupId, PONo);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}
}

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

public class Module_Accounts_Transactions_BillBooking_Edit : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected TextBox Txtfield;

	protected Button Button1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string PONo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
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

	public void loadData(string spid, string pono)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
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
		string cmdText = fun.select("Id,FinYearId,PVEVNo,SysDate, BillNo, BillDate ,SupplierId", "tblACC_BillBooking_Master", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "'" + text + text2 + " Order by Id Desc");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
		dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
		dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
		dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
		dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
		dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
		dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
		dataTable.Columns.Add(new DataColumn("PVEVDate", typeof(string)));
		dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
		dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
		while (sqlDataReader.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int num = Convert.ToInt32(sqlDataReader["FinYearId"]);
			string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
			string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			string cmdText3 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + sqlDataReader["SupplierId"].ToString() + "'");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			sqlDataReader3.Read();
			if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
			{
				_ = " And tblMM_PO_Master.PONo='" + Txtfield.Text + "'";
			}
			dataRow[0] = sqlDataReader["Id"].ToString();
			dataRow[1] = sqlDataReader["FinYearId"].ToString();
			dataRow[2] = sqlDataReader2["FinYear"].ToString();
			dataRow[6] = sqlDataReader["SupplierId"].ToString();
			dataRow[5] = sqlDataReader3["SupplierName"].ToString() + " [" + sqlDataReader[0].ToString() + "]";
			dataRow[7] = sqlDataReader["PVEVNo"].ToString();
			dataRow[8] = value;
			dataRow[9] = sqlDataReader["BillNo"].ToString();
			dataRow[10] = fun.FromDateDMY(sqlDataReader["BillDate"].ToString());
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
		}
		GridView2.DataSource = dataTable;
		GridView2.DataBind();
		sqlConnection.Close();
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
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
		catch (Exception)
		{
		}
	}
}

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

public class Module_Accounts_Transactions_BillBooking_Authorize : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string PONo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private SqlConnection con;

	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected TextBox Txtfield;

	protected CheckBox ViewAll;

	protected Button Button1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
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
			DataTable dataTable = new DataTable();
			con.Open();
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
				Txtfield.Visible = false;
				txtSupplier.Visible = false;
			}
			string empty = string.Empty;
			empty = ((!ViewAll.Checked) ? "And Authorize='0'" : "");
			string cmdText = fun.select("Id  , SysDate , SysTime  , SessionId , CompId , FinYearId, PVEVNo, SupplierId , BillNo, BillDate , CENVATEntryNo, CENVATEntryDate, OtherCharges, OtherChaDesc, Narration , DebitAmt , DiscountType, Discount ,Authorize,AuthorizeBy,AuthorizeDate,AuthorizeTime", "tblACC_BillBooking_Master", "  FinYearId<='" + FinYearId + "'  And CompId='" + CompId + "'" + text + text2 + empty + "Order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
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
			dataTable.Columns.Add(new DataColumn("CkAuth", typeof(bool)));
			dataTable.Columns.Add(new DataColumn("By", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num = Convert.ToInt32(sqlDataReader["FinYearId"]);
				string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				string cmdText3 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + sqlDataReader["SupplierId"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
				{
					_ = " And PONo='" + Txtfield.Text + "'";
				}
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader["FinYearId"].ToString();
				if (sqlDataReader2.HasRows)
				{
					dataRow[2] = sqlDataReader2["FinYear"].ToString();
				}
				dataRow[3] = sqlDataReader["PVEVNo"].ToString();
				dataRow[4] = value;
				dataRow[7] = sqlDataReader["SupplierId"].ToString();
				if (sqlDataReader3.HasRows)
				{
					dataRow[8] = sqlDataReader3["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				}
				if (Convert.ToInt32(sqlDataReader["Authorize"]) == 1)
				{
					dataRow[9] = true;
				}
				else
				{
					dataRow[9] = false;
				}
				if (sqlDataReader["AuthorizeBy"] != DBNull.Value)
				{
					string cmdText4 = fun.select("Title+' '+EmployeeName As Name", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["AuthorizeBy"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					dataRow[10] = sqlDataReader4["Name"].ToString();
					dataRow[11] = fun.FromDateDMY(sqlDataReader["AuthorizeDate"].ToString());
					dataRow[12] = sqlDataReader["AuthorizeTime"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			con.Close();
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
		if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3")
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

	protected void CkAuth_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			bool flag = checkBox.Checked;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = 0;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			switch (flag)
			{
			case true:
				num = 1;
				text2 = "AuthorizeBy = '" + sId + "'";
				text3 = "AuthorizeDate = '" + currDate + "'";
				text4 = "AuthorizeTime = '" + currTime + "'";
				break;
			case false:
				num = 0;
				text2 = "AuthorizeBy=null";
				text3 = "AuthorizeDate=null";
				text4 = "AuthorizeTime=null";
				break;
			}
			string cmdText = fun.update("tblACC_BillBooking_Master", "Authorize='" + num + "'," + text2 + "," + text3 + "," + text4, "Id='" + text + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

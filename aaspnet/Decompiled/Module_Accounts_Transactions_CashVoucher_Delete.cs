using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_CashVoucher_Delete : Page, IRequiresSessionState
{
	protected Label lblCVP_NO;

	protected TextBox txtcvp_No;

	protected Button btnSearch;

	protected GridView GridView1;

	protected TabPanel TabPanel1;

	protected Label lblCVRNo;

	protected TextBox txtCVR_No;

	protected Button btnSearch1;

	protected GridView GridView2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string str = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		str = fun.Connection();
		con = new SqlConnection(str);
		if (!base.IsPostBack)
		{
			FillData();
			FillDataRec();
		}
	}

	public void FillData()
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
			if (txtcvp_No.Text != "")
			{
				text = " And CVPNo='" + txtcvp_No.Text + "'";
			}
			string cmdText = fun.select("*", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "'" + text + "  order by Id Desc");
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
			FillData();
			TabContainer1.ActiveTabIndex = 0;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				base.Response.Redirect("CashVoucher_Delete_Details.aspx?Id=" + num + "&ModId=11&SubModId=113");
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillDataRec()
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
			if (txtCVR_No.Text != "")
			{
				text = " And CVRNo='" + txtCVR_No.Text + "'";
			}
			string cmdText = fun.select("*", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "'" + text + "  order by Id Desc");
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
			FillDataRec();
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
				fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId_R")).Text;
				con.Open();
				string cmdText = fun.delete("tblACC_CashVoucher_Receipt_Master", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillDataRec();
				TabContainer1.ActiveTabIndex = 1;
			}
			catch (Exception)
			{
			}
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		FillData();
	}

	protected void btnSearch1_Click(object sender, EventArgs e)
	{
		FillDataRec();
	}
}

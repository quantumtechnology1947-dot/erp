using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_Advice_Delete : Page, IRequiresSessionState
{
	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel Add;

	protected GridView GridView6;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				FillGrid_Creditors();
				Loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_Advice_Payment_Details", "MId='" + num + "'"), con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			string cmdText = fun.select("*", "tblACC_Advice_Payment_Details", "MId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				SqlCommand sqlCommand2 = new SqlCommand(fun.delete("tblACC_Advice_Payment_Master", "Id='" + num + "'"), con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
			}
			FillGrid_Creditors();
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Creditors()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT * FROM tblACC_Advice_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' Order By Id desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ADNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOfVoucher", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bank", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["ADNo"].ToString();
				switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Type"]))
				{
				case 1:
					dataRow[1] = "Advance";
					break;
				case 2:
					dataRow[1] = "Salary";
					break;
				case 3:
					dataRow[1] = "Others";
					break;
				case 4:
					dataRow[1] = "Creditors";
					break;
				}
				dataRow[2] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["ECSType"].ToString()), dataSet.Tables[0].Rows[i]["PayTo"].ToString(), CompId);
				dataRow[3] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["ChequeNo"].ToString();
				double num = 0.0;
				string cmdText2 = "Select Sum(Amount)As Amt from tblACC_Advice_Payment_Details inner join tblACC_Advice_Payment_Master on tblACC_Advice_Payment_Details.MId=tblACC_Advice_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_Advice_Payment_Details.MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_Advice_Payment_Master.Type='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Type"]) + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				dataRow[6] = num;
				string cmdText3 = "Select Name from tblACC_Bank inner join tblACC_Advice_Payment_Master on tblACC_Bank.Id=tblACC_Advice_Payment_Master.Bank And tblACC_Advice_Payment_Master.CompId='" + CompId + "'";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
				{
					dataRow[7] = dataSet3.Tables[0].Rows[0]["Name"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		FillGrid_Creditors();
	}

	protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Del")
		{
			try
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblIdR")).Text;
				string cmdText = fun.delete("tblACC_Advice_Received_Masters", " Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				Loaddata();
				con.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	public void Loaddata()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("*", "tblACC_Advice_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ADRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Types", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReceivedFrom", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeReceivedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankAccNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeClearanceDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Narration", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
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
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[2] = dataSet.Tables[0].Rows[i]["ADRNo"].ToString();
					string cmdText3 = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + dataSet.Tables[0].Rows[i]["Types"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet3.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[4] = dataSet.Tables[0].Rows[i]["ReceivedFrom"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ChequeNo"].ToString();
					dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeDate"].ToString());
					dataRow[8] = fun.EmpCustSupplierNames(1, dataSet.Tables[0].Rows[i]["ChequeReceivedBy"].ToString(), CompId);
					dataRow[9] = dataSet.Tables[0].Rows[i]["BankName"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["BankAccNo"].ToString();
					dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeClearanceDate"].ToString());
					dataRow[12] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
					dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView6.DataSource = dataTable;
			GridView6.DataBind();
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_BankVoucher_Delete : Page, IRequiresSessionState
{
	protected Label lblBVP_NO;

	protected TextBox txtbvp_No;

	protected Button btnSearch;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel Add;

	protected Label lblbvrNo;

	protected TextBox txtbvr_No;

	protected Button btnSearch1;

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
			con.Open();
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
		finally
		{
			con.Close();
		}
	}

	protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_BankVoucher_Payment_Details", "MId='" + num + "'"), con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			string cmdText = fun.select("*", "tblACC_BankVoucher_Payment_Details", "MId='" + num + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
			sqlDataReader.Read();
			if (!sqlDataReader.HasRows)
			{
				SqlCommand sqlCommand3 = new SqlCommand(fun.delete("tblACC_BankVoucher_Payment_Master", "Id='" + num + "'"), con);
				sqlCommand3.ExecuteNonQuery();
			}
			FillGrid_Creditors();
			con.Close();
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
			string text = "";
			if (txtbvp_No.Text != "")
			{
				text = " And BVPNo='" + txtbvp_No.Text + "'";
			}
			string cmdText = "SELECT * FROM tblACC_BankVoucher_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'" + text + " Order By Id desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("BVPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOfVoucher", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bank", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["BVPNo"].ToString();
				switch (Convert.ToInt32(sqlDataReader["Type"]))
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
				dataRow[2] = fun.EmpCustSupplierNames(Convert.ToInt32(sqlDataReader["ECSType"].ToString()), sqlDataReader["PayTo"].ToString(), CompId);
				dataRow[3] = sqlDataReader["Id"].ToString();
				dataRow[5] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				dataRow[4] = sqlDataReader["ChequeNo"].ToString();
				double num = 0.0;
				string cmdText2 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + sqlDataReader["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type='" + Convert.ToInt32(sqlDataReader["Type"]) + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2["Amt"] != DBNull.Value)
				{
					num = Convert.ToDouble(sqlDataReader2["Amt"]);
				}
				double num2 = 0.0;
				num2 = Convert.ToDouble(sqlDataReader["PayAmt"]);
				dataRow[6] = num + num2;
				string cmdText3 = fun.select("Name", "tblACC_Bank", "Id='" + sqlDataReader["Bank"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3[0] != DBNull.Value)
				{
					dataRow[7] = sqlDataReader3["Name"].ToString();
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
		con.Open();
		FillGrid_Creditors();
		con.Close();
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
				string cmdText = fun.delete("tblACC_BankVoucher_Received_Masters", " Id='" + text + "'");
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
			string text = "";
			if (txtbvr_No.Text != "")
			{
				text = " And BVRNo='" + txtbvr_No.Text + "'";
			}
			string cmdText = fun.select("*", "tblACC_BankVoucher_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'" + text + " Order By Id desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BVRNo", typeof(string)));
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
			dataTable.Columns.Add(new DataColumn("WONoBG", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = sqlDataReader["Id"].ToString();
				if (sqlDataReader2["FinYear"] != DBNull.Value)
				{
					dataRow[1] = sqlDataReader2["FinYear"].ToString();
				}
				dataRow[2] = sqlDataReader["BVRNo"].ToString();
				string cmdText3 = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + sqlDataReader["Types"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3["Description"] != DBNull.Value)
				{
					dataRow[3] = sqlDataReader3["Description"].ToString();
				}
				dataRow[4] = sqlDataReader["ReceivedFrom"].ToString();
				string text2 = sqlDataReader["InvoiceNo"].ToString();
				string text3 = "";
				text3 = text2.Replace(",", ", ");
				dataRow[5] = text3;
				dataRow[6] = sqlDataReader["ChequeNo"].ToString();
				dataRow[7] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				dataRow[8] = fun.EmpCustSupplierNames(1, sqlDataReader["ChequeReceivedBy"].ToString(), CompId);
				dataRow[9] = sqlDataReader["BankName"].ToString();
				dataRow[10] = sqlDataReader["BankAccNo"].ToString();
				dataRow[11] = fun.FromDateDMY(sqlDataReader["ChequeClearanceDate"].ToString());
				dataRow[12] = sqlDataReader["Narration"].ToString();
				dataRow[13] = Convert.ToDouble(sqlDataReader["Amount"]);
				string value = "";
				if (sqlDataReader["WONo"] != DBNull.Value && sqlDataReader["BGGroup"] != DBNull.Value)
				{
					if (sqlDataReader["WONo"] == "")
					{
						string cmdText4 = fun.select("Id,Symbol", "BusinessGroup", "Id='" + sqlDataReader["BGGroup"].ToString() + "'");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
						SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						sqlDataReader4.Read();
						if (sqlDataReader4["Symbol"] != DBNull.Value)
						{
							value = sqlDataReader4["Symbol"].ToString();
						}
					}
					else
					{
						value = sqlDataReader["WONo"].ToString();
					}
				}
				dataRow[14] = value;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView6.DataSource = dataTable;
			GridView6.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		con.Open();
		FillGrid_Creditors();
		con.Close();
	}

	protected void btnSearch1_Click(object sender, EventArgs e)
	{
		con.Open();
		Loaddata();
		con.Close();
	}
}

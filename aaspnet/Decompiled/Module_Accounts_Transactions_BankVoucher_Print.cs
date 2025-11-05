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

public class Module_Accounts_Transactions_BankVoucher_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string PaidTo = "";

	private string ReceivedFrom = "";

	protected Label lblPaidToSearch;

	protected TextBox txtPaidto;

	protected Button btnSearch;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel Add;

	protected Label Label3;

	protected TextBox txtReceivedFrom;

	protected Button btnSearchReceivedFrom;

	protected AutoCompleteExtender AutoCompleteExtender2;

	protected GridView GridView6;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

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
				FillGrid_Creditors(PaidTo);
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

	public void FillGrid_Creditors(string paidto)
	{
		try
		{
			string text = "";
			text = ((!(txtPaidto.Text != "")) ? "" : (" And PayTo like'%" + paidto + "%'"));
			string cmdText = "SELECT Id,BVPNo,Type,NameOnCheque,PaidType,ECSType,PayTo,ChequeDate,ChequeNo,PayAmt,AddAmt,Bank FROM tblACC_BankVoucher_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'" + text + " Order By Id desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("BVPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOfVoucher", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bank", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PayAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AddAmt", typeof(double)));
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
				string value;
				if (sqlDataReader["NameOnCheque"].ToString() == "" || sqlDataReader["NameOnCheque"] == DBNull.Value)
				{
					if (int.TryParse(sqlDataReader["PaidType"].ToString(), out var _))
					{
						string text2 = fun.ECSNames(Convert.ToInt32(sqlDataReader["ECSType"].ToString()), sqlDataReader["PayTo"].ToString(), CompId);
						string cmdText2 = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(sqlDataReader["PaidType"]) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
						sqlDataReader2.Read();
						value = sqlDataReader2["Particulars"].ToString() + " - " + text2;
					}
					else
					{
						value = fun.ECSNames(Convert.ToInt32(sqlDataReader["ECSType"].ToString()), sqlDataReader["PayTo"].ToString(), CompId);
					}
				}
				else
				{
					value = sqlDataReader["NameOnCheque"].ToString();
				}
				dataRow[2] = value;
				dataRow[3] = sqlDataReader["Id"].ToString();
				dataRow[5] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				dataRow[4] = sqlDataReader["ChequeNo"].ToString();
				double num = 0.0;
				string cmdText3 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + sqlDataReader["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type='" + Convert.ToInt32(sqlDataReader["Type"]) + "'";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader(CommandBehavior.CloseConnection);
				sqlDataReader3.Read();
				if (sqlDataReader3["Amt"] != DBNull.Value)
				{
					num = Convert.ToDouble(sqlDataReader3["Amt"].ToString());
				}
				double num2 = 0.0;
				num2 = Convert.ToDouble(sqlDataReader["PayAmt"]);
				dataRow[6] = num;
				dataRow[8] = num2;
				double num3 = 0.0;
				if (sqlDataReader["AddAmt"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(sqlDataReader["AddAmt"]);
				}
				dataRow[9] = num3;
				string cmdText4 = fun.select("Name", "tblACC_Bank", "Id='" + sqlDataReader["Bank"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader(CommandBehavior.CloseConnection);
				sqlDataReader4.Read();
				if (sqlDataReader4["Name"] != DBNull.Value)
				{
					dataRow[7] = sqlDataReader4["Name"].ToString();
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
		PaidTo = fun.getCode(txtPaidto.Text);
		FillGrid_Creditors(PaidTo);
		con.Close();
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("BankVoucher_Print_Details.aspx?Id=" + num + "&ModId=11&SubModId=114&Key=" + randomAlphaNumeric);
			}
			if (e.CommandName == "Adv")
			{
				base.Response.Redirect("BankVoucher_Advice_print.aspx?Id=" + num + "&ModId=11&SubModId=114&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	public void Loaddata(string receivedfrom)
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			text = ((!(txtReceivedFrom.Text != "")) ? "" : ((!(fun.getCode(txtReceivedFrom.Text) != string.Empty)) ? (" And ReceivedFrom like'%" + txtReceivedFrom.Text + "%'") : (" And ReceivedFrom like'%" + receivedfrom + "%'")));
			string cmdText = fun.select("*", "tblACC_BankVoucher_Received_Masters", "FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'" + text + " order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
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
				if (sqlDataReader2["FinYear"] != DBNull.Value)
				{
					dataRow[1] = sqlDataReader2["FinYear"].ToString();
				}
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[2] = sqlDataReader["BVRNo"].ToString();
				string cmdText3 = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + sqlDataReader["Types"].ToString() + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader(CommandBehavior.CloseConnection);
				sqlDataReader3.Read();
				if (sqlDataReader3["Description"] != DBNull.Value)
				{
					dataRow[3] = sqlDataReader3["Description"].ToString();
				}
				int num = Convert.ToInt32(sqlDataReader["ReceiveType"]);
				string text2 = "";
				if (num == 4)
				{
					text2 = sqlDataReader["ReceivedFrom"].ToString();
				}
				else
				{
					string cmdText4 = "";
					switch (num)
					{
					case 1:
						cmdText4 = fun.select("EmployeeName+' ['+EmpId+ ' ]'", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' And EmpId='", sqlDataReader["ReceivedFrom"], "'   Order By EmployeeName ASC"));
						break;
					case 2:
						cmdText4 = fun.select("CustomerName+' ['+CustomerId+']'", "SD_Cust_master", string.Concat("CompId='", CompId, "'And CustomerId='", sqlDataReader["ReceivedFrom"], "' Order By CustomerName ASC"));
						break;
					case 3:
						cmdText4 = fun.select("SupplierName+' ['+SupplierId+']'", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "'And SupplierId='", sqlDataReader["ReceivedFrom"], "' Order By SupplierName ASC"));
						break;
					}
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader(CommandBehavior.CloseConnection);
					sqlDataReader4.Read();
					text2 = sqlDataReader4[0].ToString();
				}
				dataRow[4] = text2;
				string text3 = sqlDataReader["InvoiceNo"].ToString();
				string text4 = "";
				text4 = text3.Replace(",", ", ");
				dataRow[5] = text4;
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
					if (sqlDataReader["WONo"].ToString() == "")
					{
						string cmdText5 = fun.select("Id,Symbol", "BusinessGroup", "Id='" + sqlDataReader["BGGroup"].ToString() + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
						SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
						sqlDataReader5.Read();
						if (sqlDataReader5["Symbol"] != DBNull.Value)
						{
							value = sqlDataReader5["Symbol"].ToString();
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = "Select EmployeeName+'['+EmpId+']' AS AllName  from tblHR_OfficeStaff where CompId='" + num + "' union select CustomerName+'['+CustomerId+']' AS AllName from SD_Cust_master where CompId='" + num + "' union select SupplierName+'['+SupplierId+']' AS AllName from tblMM_Supplier_master where CompId='" + num + "'";
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

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			PaidTo = fun.getCode(txtPaidto.Text);
			FillGrid_Creditors(PaidTo);
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void btnSearchReceivedFrom_Click(object sender, EventArgs e)
	{
		try
		{
			ReceivedFrom = fun.getCode(txtReceivedFrom.Text);
			Loaddata(ReceivedFrom);
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		try
		{
			if (TabContainer1.ActiveTabIndex == 0)
			{
				FillGrid_Creditors(PaidTo);
			}
			else if (TabContainer1.ActiveTabIndex == 1)
			{
				Loaddata(ReceivedFrom);
			}
		}
		catch (Exception)
		{
		}
	}
}

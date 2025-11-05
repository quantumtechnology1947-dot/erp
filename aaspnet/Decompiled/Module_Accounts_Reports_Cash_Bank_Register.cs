using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Reports_Cash_Bank_Register : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox txtFD;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator5;

	protected CalendarExtender txtFD_CalendarExtender;

	protected Label Label3;

	protected TextBox txtTo;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected CalendarExtender txtTo_CalendarExtender;

	protected DropDownList DropDownList3;

	protected Button Button1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FyId;

	private ReportDocument cryRpt;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			if (!base.IsPostBack)
			{
				DateTime now = DateTime.Now;
				txtFD.Text = now.Date.ToShortDateString().Replace('/', '-');
				txtTo.Text = now.Date.ToShortDateString().Replace('/', '-');
				FillGrid();
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void FillGrid()
	{
		try
		{
			con.Open();
			new List<string>();
			string cmdText = fun.select1("Id,Name", "tblACC_Bank order by OrdNo Asc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader dataSource = sqlCommand.ExecuteReader();
			DropDownList3.DataSource = dataSource;
			DropDownList3.DataTextField = "Name";
			DropDownList3.DataValueField = "Id";
			DropDownList3.DataBind();
			DropDownList3.Items.Insert(0, "Select");
			DropDownList3.Items.Insert(7, "IOU");
			DropDownList3.Items.Insert(8, "Contra");
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		//IL_0cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Expected O, but got Unknown
		try
		{
			((Control)(object)CrystalReportViewer1).Visible = true;
			con.Open();
			FyId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			string empty = string.Empty;
			string empty2 = string.Empty;
			int num = 0;
			empty = fun.FromDate(txtFD.Text);
			empty2 = fun.FromDate(txtTo.Text);
			num = Convert.ToInt32(DropDownList3.SelectedIndex);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Op", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Debit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TransType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Credit", typeof(double)));
			switch (num)
			{
			case 0:
				((Control)(object)CrystalReportViewer1).Visible = false;
				break;
			case 1:
			{
				double num2 = 0.0;
				num2 = getCashEntryAmt("<", empty, CompId, FyId);
				SqlDataReader cashPayCurrentBalAmt = getCashPayCurrentBalAmt(empty, empty2, CompId, FyId);
				while (cashPayCurrentBalAmt.Read())
				{
					DataRow dataRow2 = dataTable.NewRow();
					dataRow2[0] = fun.FromDate(cashPayCurrentBalAmt["SysDate"].ToString());
					string cmdText3 = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + cashPayCurrentBalAmt["ReceivedBy"].ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					dataRow2[1] = sqlDataReader3["Name"].ToString();
					dataRow2[2] = "Payment";
					dataRow2[3] = cashPayCurrentBalAmt["CVPNo"].ToString();
					dataRow2[4] = num2;
					dataRow2[5] = 0;
					dataRow2[6] = 1;
					dataRow2[7] = CompId;
					dataRow2[8] = cashPayCurrentBalAmt["PaidTo"].ToString();
					dataRow2[9] = Convert.ToDouble(cashPayCurrentBalAmt["Amount"].ToString());
					dataTable.Rows.Add(dataRow2);
					dataTable.AcceptChanges();
				}
				SqlDataReader cashRecCurrentBalAmt = getCashRecCurrentBalAmt(empty, empty2, CompId, FyId);
				while (cashRecCurrentBalAmt.Read())
				{
					DataRow dataRow3 = dataTable.NewRow();
					dataRow3[0] = fun.FromDate(cashRecCurrentBalAmt["SysDate"].ToString());
					string cmdText4 = string.Empty;
					switch (Convert.ToInt32(cashRecCurrentBalAmt["CodeTypeRB"].ToString()))
					{
					case 1:
						cmdText4 = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + cashRecCurrentBalAmt["CashReceivedBy"].ToString() + "'");
						break;
					case 2:
						cmdText4 = fun.select("CustomerName + '['+ CustomerId +']' as Name", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + cashRecCurrentBalAmt["CashReceivedBy"].ToString() + "'");
						break;
					case 3:
						cmdText4 = fun.select("SupplierName + '['+ SupplierId +']' as Name", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + cashRecCurrentBalAmt["CashReceivedBy"].ToString() + "'");
						break;
					}
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					string cmdText5 = string.Empty;
					switch (Convert.ToInt32(cashRecCurrentBalAmt["CodeTypeRA"].ToString()))
					{
					case 1:
						cmdText5 = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + cashRecCurrentBalAmt["CashReceivedAgainst"].ToString() + "'");
						break;
					case 2:
						cmdText5 = fun.select("CustomerName + '['+ CustomerId +']' as Name", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + cashRecCurrentBalAmt["CashReceivedAgainst"].ToString() + "'");
						break;
					case 3:
						cmdText5 = fun.select("SupplierName + '['+ SupplierId +']' as Name", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + cashRecCurrentBalAmt["CashReceivedAgainst"].ToString() + "'");
						break;
					}
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					dataRow3[1] = sqlDataReader5["Name"].ToString();
					dataRow3[2] = "Receipt";
					dataRow3[3] = cashRecCurrentBalAmt["CVRNo"].ToString();
					dataRow3[5] = Convert.ToDouble(cashRecCurrentBalAmt["Amount"].ToString());
					dataRow3[6] = 1;
					dataRow3[7] = CompId;
					dataRow3[8] = sqlDataReader4["Name"].ToString();
					dataRow3[9] = 0;
					dataTable.Rows.Add(dataRow3);
					dataTable.AcceptChanges();
				}
				break;
			}
			case 2:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 2);
				break;
			case 3:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 3);
				break;
			case 4:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 4);
				break;
			case 5:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 5);
				break;
			case 6:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 6);
				break;
			case 7:
			{
				SqlDataReader iOUPayCurrentBalAmt = getIOUPayCurrentBalAmt(empty, empty2, CompId, FyId);
				while (iOUPayCurrentBalAmt.Read())
				{
					DataRow dataRow4 = dataTable.NewRow();
					dataRow4[0] = fun.FromDate(iOUPayCurrentBalAmt["PaymentDate"].ToString());
					string cmdText6 = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + iOUPayCurrentBalAmt["EmpId"].ToString() + "'");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					dataRow4[1] = sqlDataReader6["Name"].ToString();
					dataRow4[2] = "IOU";
					dataRow4[3] = iOUPayCurrentBalAmt["Id"].ToString();
					dataRow4[6] = 7;
					dataRow4[7] = CompId;
					dataRow4[8] = iOUPayCurrentBalAmt["Narration"].ToString();
					dataRow4[9] = Convert.ToDouble(iOUPayCurrentBalAmt["Amount"].ToString());
					dataTable.Rows.Add(dataRow4);
					dataTable.AcceptChanges();
				}
				break;
			}
			case 8:
			{
				SqlDataReader contraCurrentBalAmt = getContraCurrentBalAmt(empty, empty2, CompId, FyId);
				while (contraCurrentBalAmt.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = fun.FromDate(contraCurrentBalAmt["Date"].ToString());
					string cmdText = fun.select("*", "tblACC_Bank", "Id='" + contraCurrentBalAmt["Dr"].ToString() + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					sqlDataReader.Read();
					string cmdText2 = fun.select("*", "tblACC_Bank", "Id='" + contraCurrentBalAmt["Cr"].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					dataRow[1] = sqlDataReader["Name"].ToString();
					dataRow[2] = "Contra";
					dataRow[3] = contraCurrentBalAmt["Id"].ToString();
					dataRow[6] = 8;
					dataRow[7] = CompId;
					dataRow[8] = sqlDataReader2["Name"].ToString();
					if (contraCurrentBalAmt["Cr"].ToString() == "4" || contraCurrentBalAmt["Dr"].ToString() != "4")
					{
						dataRow[9] = Convert.ToDouble(contraCurrentBalAmt["Amount"].ToString());
					}
					else
					{
						dataRow[5] = Convert.ToDouble(contraCurrentBalAmt["Amount"].ToString());
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				break;
			}
			case 9:
				dataTable = getBankPayRecCurrentAmt(empty, empty2, CompId, FyId, Convert.ToInt32(DropDownList3.SelectedValue), 9);
				break;
			}
			if (dataTable.Rows.Count > 0)
			{
				DataSet dataSet = new Cash_Bank_Register();
				dataSet.Tables[0].Merge(dataTable);
				dataSet.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/Cash_Bank_Register.rpt"));
				cryRpt.SetDataSource(dataSet);
				string text = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session["ReportDocument"] = cryRpt;
			}
			else
			{
				((Control)(object)CrystalReportViewer1).Visible = false;
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

	public double getCashEntryAmt(string CField, string Date, int CompId, int FyId)
	{
		double num = 0.0;
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("sum(Amt) as sum_cash", "tblACC_CashAmt_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_CashAmt_Master");
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				num = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
			}
			return Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2"));
		}
		catch (Exception)
		{
		}
		return Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2"));
	}

	public double getCashPayOPBalAmt(string CField, string Date, int CompId, int FyId)
	{
		double result = 0.0;
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("sum(tblACC_CashVoucher_Payment_Details.Amount) as sum_cvpay", "tblACC_CashVoucher_Payment_Master,tblACC_CashVoucher_Payment_Details", "tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Payment_Master.Id=tblACC_CashVoucher_Payment_Details.MId AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Payment_Master.SysDate" + CField + "'" + Date + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader["sum_cvpay"] != DBNull.Value)
			{
				result = Convert.ToDouble(sqlDataReader["sum_cvpay"].ToString());
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public SqlDataReader getCashPayCurrentBalAmt(string FD, string TD, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.select("tblACC_CashVoucher_Payment_Master.CVPNo,tblACC_CashVoucher_Payment_Master.PaidTo,tblACC_CashVoucher_Payment_Master.ReceivedBy,tblACC_CashVoucher_Payment_Master.SysDate,tblACC_CashVoucher_Payment_Details.Particulars,tblACC_CashVoucher_Payment_Details.Amount", "tblACC_CashVoucher_Payment_Master,tblACC_CashVoucher_Payment_Details", "tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Payment_Master.Id=tblACC_CashVoucher_Payment_Details.MId AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Payment_Master.SysDate Between '" + FD + "' AND '" + TD + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		return sqlCommand.ExecuteReader();
	}

	public SqlDataReader getCashRecCurrentBalAmt(string FD, string TD, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.select("*", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate Between '" + FD + "' AND '" + TD + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		return sqlCommand.ExecuteReader();
	}

	public SqlDataReader getContraCurrentBalAmt(string FD, string TD, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.select("*", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date Between '" + FD + "' AND '" + TD + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		return sqlCommand.ExecuteReader();
	}

	public double getIOUPayOpBalAmt(string CField, string Date, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double num = 0.0;
		string cmdText = fun.select("sum(Amount) as sum_iou", "tblACC_IOU_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "' AND Authorize='1'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		sqlDataReader.Read();
		return Convert.ToDouble(sqlDataReader["sum_iou"].ToString());
	}

	public SqlDataReader getIOUPayCurrentBalAmt(string FD, string TD, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.select("*", "tblACC_IOU_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND AuthorizedDate Between '" + FD + "' AND '" + TD + "' AND Authorize='1'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		return sqlCommand.ExecuteReader();
	}

	public double getIOURecOpBalAmt(string CField, string Date, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double num = 0.0;
		string cmdText = fun.select("sum(tblACC_IOU_Receipt.RecievedAmount) as sum_iourec", "tblACC_IOU_Master,tblACC_IOU_Receipt", "tblACC_IOU_Master.CompId='" + CompId + "' AND tblACC_IOU_Receipt.FinYearId<='" + FyId + "' AND tblACC_IOU_Receipt.ReceiptDate" + CField + "'" + Date + "' AND tblACC_IOU_Master.Id=tblACC_IOU_Receipt.MId");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		sqlDataReader.Read();
		return Convert.ToDouble(sqlDataReader["sum_iourec"]);
	}

	public SqlDataReader getIOURecCurrentBalAmt(string FD, string TD, int CompId, int FyId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = fun.select("sum(tblACC_IOU_Receipt.RecievedAmount) as sum_iourec", "tblACC_IOU_Master,tblACC_IOU_Receipt", "tblACC_IOU_Master.CompId='" + CompId + "' AND tblACC_IOU_Receipt.FinYearId<='" + FyId + "' AND tblACC_IOU_Receipt.ReceiptDate Between '" + FD + "' AND '" + TD + "' AND tblACC_IOU_Master.Id=tblACC_IOU_Receipt.MId");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		return sqlCommand.ExecuteReader();
	}

	public double getBankEntryAmt(string CField, string Date, int CompId, int FyId, int BankId)
	{
		double result = 0.0;
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("sum(Amt) as sum_bank", "tblACC_BankAmt_Master", " BankId='" + BankId + "'And CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			result = Math.Round(Convert.ToDouble(decimal.Parse(sqlDataReader["sum_bank"].ToString()).ToString("N2")), 5);
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public DataTable getBankPayRecCurrentAmt(string FD, string TD, int CompId, int FyId, int BKId, int TransType)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Op", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Debit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TransType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Credit", typeof(double)));
			string empty = string.Empty;
			empty = fun.select("Id,BVPNo,ECSType,PayTo,PayAmt,ChequeDate", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND ChequeDate Between '" + FD + "' AND '" + TD + "' AND Bank='" + BKId + "'");
			SqlCommand sqlCommand = new SqlCommand(empty, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				string cmdText = string.Empty;
				switch (sqlDataReader["ECSType"].ToString())
				{
				case "1":
					cmdText = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + sqlDataReader["PayTo"].ToString() + "'");
					break;
				case "2":
					cmdText = fun.select("CustomerName + '['+ CustomerId +']' as Name", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + sqlDataReader["PayTo"].ToString() + "'");
					break;
				case "3":
					cmdText = fun.select("SupplierName + '['+ SupplierId +']' as Name", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + sqlDataReader["PayTo"].ToString() + "'");
					break;
				}
				SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[1] = sqlDataReader2["Name"].ToString();
				dataRow[2] = "Payment";
				dataRow[3] = sqlDataReader["BVPNo"].ToString();
				dataRow[6] = TransType;
				dataRow[7] = CompId;
				string cmdText2 = fun.select("*", "tblACC_Bank", "Id='" + BKId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				dataRow[8] = sqlDataReader3["Name"].ToString();
				double num = 0.0;
				double num2 = 0.0;
				num = Convert.ToDouble(sqlDataReader["PayAmt"].ToString());
				string empty2 = string.Empty;
				empty2 = fun.select("Sum(Amount) as Sum_Amt", "tblACC_BankVoucher_Payment_Details", "MId='" + sqlDataReader["Id"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(empty2, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				if (sqlDataReader4["Sum_Amt"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(sqlDataReader4["Sum_Amt"]);
				}
				dataRow[9] = num + num2;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			string empty3 = string.Empty;
			empty3 = fun.select("*", "tblACC_BankVoucher_Received_Masters", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND ChequeClearanceDate Between '" + FD + "' AND '" + TD + "' AND DrawnAt='" + BKId + "'");
			SqlCommand sqlCommand5 = new SqlCommand(empty3, sqlConnection);
			SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
			while (sqlDataReader5.Read())
			{
				DataRow dataRow2 = dataTable.NewRow();
				dataRow2[0] = fun.FromDateDMY(sqlDataReader5["ChequeClearanceDate"].ToString());
				string cmdText3 = string.Empty;
				switch (sqlDataReader5["ReceiveType"].ToString())
				{
				case "1":
					cmdText3 = fun.select("EmployeeName + '['+ EmpId +']' as Name", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + sqlDataReader5["ReceivedFrom"].ToString() + "'");
					break;
				case "2":
					cmdText3 = fun.select("CustomerName + '['+ CustomerId +']' as Name", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + sqlDataReader5["ReceivedFrom"].ToString() + "'");
					break;
				case "3":
					cmdText3 = fun.select("SupplierName + '['+ SupplierId +']' as Name", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + sqlDataReader5["ReceivedFrom"].ToString() + "'");
					break;
				}
				SqlCommand sqlCommand6 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				string cmdText4 = fun.select("*", "tblACC_Bank", "Id='" + sqlDataReader5["DrawnAt"].ToString() + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				dataRow2[1] = sqlDataReader7["Name"].ToString();
				dataRow2[2] = "Receipt";
				dataRow2[3] = sqlDataReader5["BVRNo"].ToString();
				dataRow2[5] = Convert.ToDouble(sqlDataReader5["Amount"]);
				dataRow2[6] = TransType;
				dataRow2[7] = CompId;
				dataRow2[8] = sqlDataReader5["BankName"].ToString();
				dataTable.Rows.Add(dataRow2);
				dataTable.AcceptChanges();
			}
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}
}

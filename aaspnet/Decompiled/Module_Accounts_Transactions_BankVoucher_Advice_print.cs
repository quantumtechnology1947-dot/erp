using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_BankVoucher_Advice_print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt2 = new ReportDocument();

	private SqlConnection con;

	private string connStr = "";

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private int Id;

	private int getKey;

	private string key = string.Empty;

	private string SupId = string.Empty;

	private string lnkFor = string.Empty;

	protected CrystalReportViewer CrystalReportViewer2;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel2;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_130c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1316: Expected O, but got Unknown
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			getKey = Convert.ToInt32(base.Request.QueryString["getKey"]);
			if (base.Request.QueryString["Key"] != null)
			{
				key = base.Request.QueryString["Key"].ToString();
			}
			if (base.Request.QueryString["SupId"] != null)
			{
				SupId = base.Request.QueryString["SupId"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Id"]))
			{
				Id = Convert.ToInt32(base.Request.QueryString["Id"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["lnkFor"]))
			{
				lnkFor = base.Request.QueryString["lnkFor"].ToString();
			}
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT * FROM tblACC_BankVoucher_Payment_Master where CompId='" + CompId + "' And Id='" + Id + "' And FinYearId<='" + FinYearId + "' Order By Id desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BVPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeECS", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ECS", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particular", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PayAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AddAmt", typeof(double)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = "SELECT * FROM tblACC_BankVoucher_Payment_Details INNER JOIN tblACC_BankVoucher_Payment_Master ON tblACC_BankVoucher_Payment_Details.MId =tblACC_BankVoucher_Payment_Master.Id And tblACC_BankVoucher_Payment_Master.Id='" + Id + "' ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow[5] = dataSet.Tables[0].Rows[0]["BVPNo"].ToString();
						dataRow[14] = Convert.ToDouble(dataSet.Tables[0].Rows[0]["PayAmt"]);
						dataRow[15] = Convert.ToDouble(dataSet.Tables[0].Rows[0]["AddAmt"]);
						switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Type"]))
						{
						case 1:
							dataRow[8] = "-";
							dataRow[11] = dataSet2.Tables[0].Rows[i]["ProformaInvNo"].ToString();
							dataRow[13] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["InvDate"].ToString());
							break;
						case 2:
							dataRow[8] = "-";
							dataRow[11] = "-";
							dataRow[13] = "-";
							break;
						case 3:
							dataRow[8] = "-";
							dataRow[11] = "-";
							dataRow[13] = "-";
							break;
						case 4:
						{
							string value = "";
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								string cmdText3 = "SELECT tblACC_BillBooking_Master.BillNo FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId =tblACC_BillBooking_Master.Id And tblACC_BillBooking_Master.Id='" + dataSet2.Tables[0].Rows[i]["PVEVNO"].ToString() + "' ";
								SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
								DataSet dataSet3 = new DataSet();
								sqlDataAdapter3.Fill(dataSet3);
								if (dataSet3.Tables[0].Rows.Count > 0)
								{
									value = dataSet3.Tables[0].Rows[0][0].ToString();
								}
							}
							dataRow[8] = value;
							dataRow[11] = "-";
							dataRow[13] = "-";
							break;
						}
						}
						int num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"]);
						string selectCommandText = "";
						switch (num)
						{
						case 1:
							dataRow[9] = "Employee Code : ";
							selectCommandText = fun.select("EmpId", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' And EmpId='", dataSet.Tables[0].Rows[0]["PayTo"], "'   Order By EmployeeName ASC"));
							break;
						case 2:
							dataRow[9] = "Customer Code :";
							selectCommandText = fun.select("CustomerId", "SD_Cust_master", string.Concat("CompId='", CompId, "'And CustomerId='", dataSet.Tables[0].Rows[0]["PayTo"], "' Order By CustomerName ASC"));
							break;
						case 3:
							dataRow[9] = "Supplier Code :";
							selectCommandText = fun.select("SupplierId", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "'And SupplierId='", dataSet.Tables[0].Rows[0]["PayTo"], "' Order By SupplierName ASC"));
							break;
						}
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, con);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						dataRow[10] = dataSet4.Tables[0].Rows[0][0].ToString();
						string text;
						if (dataSet.Tables[0].Rows[0]["NameOnCheque"] != DBNull.Value && dataSet.Tables[0].Rows[0]["NameOnCheque"].ToString() != "")
						{
							text = dataSet.Tables[0].Rows[0]["NameOnCheque"].ToString();
						}
						if (int.TryParse(dataSet.Tables[0].Rows[0]["PaidType"].ToString(), out var _))
						{
							string cmdText4 = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PaidType"]) + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							text = dataSet5.Tables[0].Rows[0]["Particulars"].ToString();
						}
						else
						{
							text = fun.ECSNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
						}
						dataRow[0] = text;
						dataRow[0] = text;
						dataRow[1] = CompId;
						dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ChequeDate"].ToString());
						dataRow[6] = dataSet.Tables[0].Rows[0]["ChequeNo"].ToString();
						double num2 = 0.0;
						num2 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
						dataRow[3] = num2;
						dataRow[4] = fun.ECSAddress(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
						dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
						if (dataSet2.Tables[0].Rows[i]["Particular"] != DBNull.Value)
						{
							dataRow[12] = dataSet2.Tables[0].Rows[i]["Particular"].ToString();
						}
						else
						{
							dataRow[12] = "-";
						}
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				else
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[5] = dataSet.Tables[0].Rows[0]["BVPNo"].ToString();
					dataRow[14] = 0;
					dataRow[15] = 0;
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Type"]))
					{
					case 1:
						dataRow[8] = "-";
						dataRow[11] = "-";
						dataRow[13] = "-";
						break;
					case 2:
						dataRow[8] = "-";
						dataRow[11] = "-";
						dataRow[13] = "-";
						break;
					case 3:
						dataRow[8] = "-";
						dataRow[11] = "-";
						dataRow[13] = "-";
						break;
					case 4:
						dataRow[8] = "-";
						dataRow[11] = "-";
						dataRow[13] = "-";
						break;
					}
					int num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"]);
					string selectCommandText2 = "";
					switch (num3)
					{
					case 1:
						dataRow[9] = "Employee Code : ";
						selectCommandText2 = fun.select("EmpId", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' And EmpId='", dataSet.Tables[0].Rows[0]["PayTo"], "'   Order By EmployeeName ASC"));
						break;
					case 2:
						dataRow[9] = "Customer Code :";
						selectCommandText2 = fun.select("CustomerId", "SD_Cust_master", string.Concat("CompId='", CompId, "'And CustomerId='", dataSet.Tables[0].Rows[0]["PayTo"], "' Order By CustomerName ASC"));
						break;
					case 3:
						dataRow[9] = "Supplier Code :";
						selectCommandText2 = fun.select("SupplierId", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "'And SupplierId='", dataSet.Tables[0].Rows[0]["PayTo"], "' Order By SupplierName ASC"));
						break;
					}
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText2, con);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					dataRow[10] = dataSet6.Tables[0].Rows[0][0].ToString();
					string value2 = fun.ECSNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
					dataRow[0] = value2;
					dataRow[1] = CompId;
					dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ChequeDate"].ToString());
					dataRow[6] = dataSet.Tables[0].Rows[0]["ChequeNo"].ToString();
					double num4 = 0.0;
					num4 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["PayAmt"]);
					dataRow[3] = num4;
					dataRow[4] = fun.ECSAddress(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
					dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[12] = "-";
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			DataSet dataSet7 = new BankVoucher();
			dataSet7.Tables[0].Merge(dataTable);
			dataSet7.AcceptChanges();
			cryRpt2 = new ReportDocument();
			cryRpt2.Load(base.Server.MapPath("~/Module/Accounts/Reports/BankVoucher_Payment_Advice.rpt"));
			cryRpt2.SetDataSource(dataSet7);
			string text2 = fun.CompAdd(CompId);
			cryRpt2.SetParameterValue("CompAdd", (object)text2);
			((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = cryRpt2;
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			switch (getKey)
			{
			case 0:
				base.Response.Redirect("~/Module/Accounts/Transactions/BankVoucher_print.aspx?ModId=11&SubModId=114");
				break;
			case 1:
				base.Response.Redirect("CreditorsDebitors_InDetailList.aspx?SupId=" + SupId + "&ModId=11&SubModId=135&Key=" + key);
				break;
			case 2:
				base.Response.Redirect("SundryCreditors_InDetailList.aspx?SupId=" + SupId + "&ModId=11&SubModId=135&Key=" + key + "&lnkFor=" + lnkFor);
				break;
			}
		}
		catch (Exception)
		{
		}
	}
}

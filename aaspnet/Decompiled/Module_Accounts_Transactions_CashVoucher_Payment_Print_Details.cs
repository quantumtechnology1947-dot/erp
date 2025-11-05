using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_CashVoucher_Payment_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int cId;

	private string Key = string.Empty;

	private int CVPId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Expected O, but got Unknown
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		cId = Convert.ToInt32(Session["compid"]);
		Key = base.Request.QueryString["Key"].ToString();
		CVPId = Convert.ToInt32(base.Request.QueryString["CVPId"]);
		try
		{
			if (!base.IsPostBack)
			{
				DataTable dataTable = new DataTable();
				string cmdText = fun.select("tblACC_CashVoucher_Payment_Master.Id, tblACC_CashVoucher_Payment_Master.SysDate,tblACC_CashVoucher_Payment_Master.CompId,tblACC_CashVoucher_Payment_Master.CVPNo,tblACC_CashVoucher_Payment_Master.PaidTo,tblACC_CashVoucher_Payment_Master.ReceivedBy,tblACC_CashVoucher_Payment_Master.CodeType,tblACC_CashVoucher_Payment_Details.BillNo,tblACC_CashVoucher_Payment_Details.BillDate,tblACC_CashVoucher_Payment_Details.PONo,tblACC_CashVoucher_Payment_Details.PODate,tblACC_CashVoucher_Payment_Details.Particulars,tblACC_CashVoucher_Payment_Details.WONo,tblACC_CashVoucher_Payment_Details.BGGroup,tblACC_CashVoucher_Payment_Details.AcHead,tblACC_CashVoucher_Payment_Details.Amount,tblACC_CashVoucher_Payment_Details.BudgetCode,tblACC_CashVoucher_Payment_Details.PVEVNo", "tblACC_CashVoucher_Payment_Master, tblACC_CashVoucher_Payment_Details", "tblACC_CashVoucher_Payment_Details.MId=tblACC_CashVoucher_Payment_Master.Id AND tblACC_CashVoucher_Payment_Master.Id='" + CVPId + "' AND tblACC_CashVoucher_Payment_Master.CompId='" + cId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CVPNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ReceivedBy", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow[1] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
					dataRow[2] = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[3] = dataSet.Tables[0].Rows[i]["CVPNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["PaidTo"].ToString();
					int num = 0;
					string text = string.Empty;
					num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeType"].ToString());
					string cmdText2 = "";
					switch (num)
					{
					case 1:
						text = "Employee";
						cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", cId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
						break;
					case 2:
						text = "Customer";
						cmdText2 = fun.select("CustomerName+'[ '+CustomerId+']'  As EmpName", "SD_Cust_master", string.Concat("CompId='", cId, "' AND CustomerId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
						break;
					case 3:
						text = "Supplier";
						cmdText2 = fun.select("SupplierName+'[ '+SupplierId+']'  As  EmpName", "tblMM_Supplier_master", string.Concat("CompId='", cId, "' AND SupplierId='", dataSet.Tables[0].Rows[i]["Receivedby"], "'"));
						break;
					}
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[5] = dataSet2.Tables[0].Rows[0]["EmpName"].ToString() + " [ " + text + " ]";
					dataRow[6] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
					dataRow[7] = fun.FromDate(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
					dataRow[8] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[9] = fun.FromDate(dataSet.Tables[0].Rows[i]["PODate"].ToString());
					dataRow[10] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					string value = "NA";
					string value2 = "NA";
					string value3 = "NA";
					string cmdText3 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["BGGroup"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "BusinessGroup");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
					string cmdText4 = fun.select("Symbol", "tblMIS_BudgetCode", "Id='" + dataSet.Tables[0].Rows[i]["BudgetCode"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblMIS_BudgetCode");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
					}
					string cmdText5 = fun.select("Symbol", " AccHead ", "Id='" + dataSet.Tables[0].Rows[i]["AcHead"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "AccHead");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						value3 = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
					}
					dataRow[12] = value;
					dataRow[13] = value2;
					dataRow[14] = value3;
					dataRow[15] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
					dataRow[16] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"].ToString());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet6 = new CashVoucher_Payment();
				dataSet6.Tables[0].Merge(dataTable);
				dataSet6.AcceptChanges();
				report = new ReportDocument();
				report.Load(base.Server.MapPath("~/Module/Accounts/Reports/CashVoucher_Payment.rpt"));
				report.SetDataSource(dataSet6);
				string text2 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/CashVoucher_Print.aspx?ModId=11&SubModId=113");
	}
}

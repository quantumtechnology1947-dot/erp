using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_BankVoucher_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private int Id;

	private ReportDocument cryRpt = new ReportDocument();

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Expected O, but got Unknown
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		Key = base.Request.QueryString["Key"].ToString();
		try
		{
			if (!base.IsPostBack)
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				sId = Session["username"].ToString();
				if (!string.IsNullOrEmpty(base.Request.QueryString["Id"]))
				{
					Id = Convert.ToInt32(base.Request.QueryString["Id"]);
				}
				DataTable dataTable = new DataTable();
				string cmdText = fun.select("*", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' And Id='" + Id + "' And FinYearId<='" + FinYearId + "' Order By Id desc");
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
				dataTable.Columns.Add(new DataColumn("D1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("D2", typeof(string)));
				dataTable.Columns.Add(new DataColumn("M1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("M2", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Y1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Y2", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Y3", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Y4", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AddAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TransactionType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("PaidType", typeof(string)));
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					string value;
					if (dataSet.Tables[0].Rows[0]["NameOnCheque"].ToString() == "" || dataSet.Tables[0].Rows[0]["NameOnCheque"] == DBNull.Value)
					{
						if (int.TryParse(dataSet.Tables[0].Rows[0]["PaidType"].ToString(), out var _))
						{
							string cmdText2 = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PaidType"]) + "'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							value = dataSet2.Tables[0].Rows[0]["Particulars"].ToString();
						}
						else
						{
							value = fun.ECSNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
						}
					}
					else
					{
						value = dataSet.Tables[0].Rows[0]["NameOnCheque"].ToString();
					}
					dataRow[0] = value;
					dataRow[1] = CompId;
					string cmdText3 = "SELECT * FROM tblACC_BankVoucher_Payment_Details INNER JOIN tblACC_BankVoucher_Payment_Master ON tblACC_BankVoucher_Payment_Details.MId =tblACC_BankVoucher_Payment_Master.Id And tblACC_BankVoucher_Payment_Master.Id='" + Id + "' ";
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					double num = 0.0;
					for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
					{
						num += Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
					}
					dataRow[10] = dataSet.Tables[0].Rows[0]["PayTo"].ToString();
					string text = Regex.Replace(fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ChequeDate"].ToString()), "[^0-9a-zA-Z]+", "");
					if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Bank"]) == 1 || Convert.ToInt32(dataSet.Tables[0].Rows[0]["Bank"]) == 2 || Convert.ToInt32(dataSet.Tables[0].Rows[0]["Bank"]) == 5)
					{
						dataRow[14] = text.Substring(0, 1);
						dataRow[15] = text.Substring(1, 1);
						dataRow[16] = text.Substring(2, 1);
						dataRow[17] = text.Substring(3, 1);
						dataRow[18] = text.Substring(4, 1);
						dataRow[19] = text.Substring(5, 1);
						dataRow[20] = text.Substring(6, 1);
						dataRow[21] = text.Substring(7, 1);
					}
					else if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Bank"]) == 3)
					{
						dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ChequeDate"].ToString());
					}
					double num2 = 0.0;
					double num3 = 0.0;
					num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["PayAmt"]);
					num3 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["AddAmt"]);
					if (int.TryParse(dataSet.Tables[0].Rows[0]["PaidType"].ToString(), out var _))
					{
						dataRow[3] = num + num2 + num3;
					}
					else
					{
						dataRow[3] = num + num2;
					}
					dataRow[4] = fun.ECSAddress(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet4 = new BankVoucher();
				dataSet4.Tables[0].Merge(dataTable);
				dataSet4.AcceptChanges();
				cryRpt = new ReportDocument();
				switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Bank"]))
				{
				case 1:
					cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/BankVoucher_Payment_Dena_Print.rpt"));
					break;
				case 2:
					cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/BankVoucher_Payment_Dena_Print.rpt"));
					break;
				case 3:
					cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/BankVoucher_Payment_Axis_Print.rpt"));
					break;
				case 5:
					cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/BankVoucher_Payment_IDBI_Print.rpt"));
					break;
				}
				cryRpt.SetDataSource(dataSet4);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				CrystalReportViewer1.DisplayGroupTree = false;
				CrystalReportViewer1.DisplayToolbar = true;
				CrystalReportViewer1.EnableDrillDown = false;
				CrystalReportViewer1.SeparatePages = true;
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
			con.Close();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/BankVoucher_print.aspx?ModId=11&SubModId=114");
	}

	protected void CrystalReportViewer1_Load(object sender, EventArgs e)
	{
	}

	protected void CrystalReportViewer1_Init(object sender, EventArgs e)
	{
	}
}

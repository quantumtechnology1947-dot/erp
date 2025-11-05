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

public class Module_Accounts_Transactions_Advice_Print_Advice : Page, IRequiresSessionState
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

	protected CrystalReportViewer CrystalReportViewer2;

	protected CrystalReportSource CrystalReportSource2;

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

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Expected O, but got Unknown
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Expected O, but got Unknown
		try
		{
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				sId = Session["username"].ToString();
				if (!string.IsNullOrEmpty(base.Request.QueryString["Id"]))
				{
					Id = Convert.ToInt32(base.Request.QueryString["Id"]);
				}
				DataTable dataTable = new DataTable();
				string cmdText = "SELECT * FROM tblACC_Advice_Payment_Master where CompId='" + CompId + "' And Id='" + Id + "' And FinYearId<='" + FinYearId + "' Order By Id desc";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ADNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TypeECS", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ECS", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InvDate", typeof(string)));
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = "SELECT * FROM tblACC_Advice_Payment_Details INNER JOIN tblACC_Advice_Payment_Master ON tblACC_Advice_Payment_Details.MId =tblACC_Advice_Payment_Master.Id And tblACC_Advice_Payment_Master.Id='" + Id + "' ";
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow[5] = dataSet.Tables[0].Rows[0]["ADNo"].ToString();
						dataRow[12] = dataSet2.Tables[0].Rows[0]["Particular"].ToString();
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
								string cmdText3 = "SELECT tblACC_BillBooking_Master.BillNo FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId =tblACC_BillBooking_Master.Id And tblACC_BillBooking_Master.Id='" + dataSet2.Tables[0].Rows[i][0].ToString() + "' ";
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
						switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"]))
						{
						case 1:
							dataRow[9] = "Employee Code";
							break;
						case 2:
							dataRow[9] = "Customer Code";
							break;
						case 3:
							dataRow[9] = "Supplier Code";
							break;
						}
						string value2 = fun.ECSNames(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
						dataRow[0] = value2;
						dataRow[1] = CompId;
						dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ChequeDate"].ToString());
						dataRow[6] = dataSet.Tables[0].Rows[0]["ChequeNo"].ToString();
						double num = 0.0;
						num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
						dataRow[3] = num;
						dataRow[4] = fun.ECSAddress(Convert.ToInt32(dataSet.Tables[0].Rows[0]["ECSType"].ToString()), dataSet.Tables[0].Rows[0]["PayTo"].ToString(), CompId);
						dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
						dataRow[10] = dataSet.Tables[0].Rows[0]["PayTo"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				DataSet dataSet4 = new Advice();
				dataSet4.Tables[0].Merge(dataTable);
				dataSet4.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/Advice_Print_Advice.rpt"));
				cryRpt.SetDataSource(dataSet4);
				string text = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				CrystalReportViewer2.DisplayGroupTree = false;
				CrystalReportViewer2.DisplayToolbar = true;
				CrystalReportViewer2.EnableDrillDown = false;
				CrystalReportViewer2.SeparatePages = true;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer2).Dispose();
		CrystalReportViewer2 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Advice_print.aspx?ModId=11&SubModId=119");
	}

	protected void CrystalReportViewer1_Load(object sender, EventArgs e)
	{
	}

	protected void CrystalReportViewer1_Init(object sender, EventArgs e)
	{
	}
}

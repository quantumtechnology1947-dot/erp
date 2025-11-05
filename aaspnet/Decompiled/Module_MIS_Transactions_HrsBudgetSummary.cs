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

public class Module_MIS_Transactions_HrsBudgetSummary : Page, IRequiresSessionState
{
	protected Button Button1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string Key = string.Empty;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private Cal_Used_Hours CUS = new Cal_Used_Hours();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0f94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9b: Expected O, but got Unknown
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ProjectTitle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MDesign", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MAssly", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MCert", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTrials", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MIC", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MDisp", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTryOut", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DDesign", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DAssly", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DCert", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DTrials", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DIC", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DDisp", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DTryOut", typeof(double)));
				dataTable.Columns.Add(new DataColumn("HyrLink", typeof(string)));
				string cmdText = fun.select("Distinct WONo,CompId", "tblPM_ManPowerPlanning", "CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = sqlDataReader["WONo"].ToString();
					dataRow[1] = Convert.ToInt32(sqlDataReader["CompId"]);
					string cmdText2 = string.Concat("SELECT SD_Cust_WorkOrder_Master.TaskProjectTitle FROM tblPM_ManPowerPlanning INNER JOIN SD_Cust_WorkOrder_Master ON tblPM_ManPowerPlanning.WONo = SD_Cust_WorkOrder_Master.WONo AND SD_Cust_WorkOrder_Master.WONo='", sqlDataReader["WONo"], "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					dataRow[2] = sqlDataReader2["TaskProjectTitle"].ToString();
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 1) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 1) > 0.0)
					{
						dataRow[3] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 1) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 1) * 100.0;
					}
					else
					{
						dataRow[3] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 2) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 2) > 0.0)
					{
						dataRow[4] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 2) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 2) * 100.0;
					}
					else
					{
						dataRow[4] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 3) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 3) > 0.0)
					{
						dataRow[5] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 3) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 3) * 100.0;
					}
					else
					{
						dataRow[5] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 4) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 4) > 0.0)
					{
						dataRow[6] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 4) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 4) * 100.0;
					}
					else
					{
						dataRow[6] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 5) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 5) > 0.0)
					{
						dataRow[7] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 5) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 5) * 100.0;
					}
					else
					{
						dataRow[7] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 6) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 6) > 0.0)
					{
						dataRow[8] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 6) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 6) * 100.0;
					}
					else
					{
						dataRow[8] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 7) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 7) > 0.0)
					{
						dataRow[9] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 7) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 2, 7) * 100.0;
					}
					else
					{
						dataRow[9] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 8) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 8) > 0.0)
					{
						dataRow[10] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 8) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 8) * 100.0;
					}
					else
					{
						dataRow[10] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 9) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 9) > 0.0)
					{
						dataRow[11] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 9) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 9) * 100.0;
					}
					else
					{
						dataRow[11] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 10) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 10) > 0.0)
					{
						dataRow[12] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 10) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 10) * 100.0;
					}
					else
					{
						dataRow[12] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 11) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 11) > 0.0)
					{
						dataRow[13] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 11) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 11) * 100.0;
					}
					else
					{
						dataRow[13] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 12) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 12) > 0.0)
					{
						dataRow[14] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 12) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 12) * 100.0;
					}
					else
					{
						dataRow[14] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 13) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 13) > 0.0)
					{
						dataRow[15] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 13) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 13) * 100.0;
					}
					else
					{
						dataRow[15] = 0;
					}
					if (CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 14) > 0.0 && CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 14) > 0.0)
					{
						dataRow[16] = CUS.GetTotalUtilizeHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 14) / CUS.GetTotalAllocatedHrs_WONo(sqlDataReader["WONo"].ToString(), 3, 14) * 100.0;
					}
					else
					{
						dataRow[16] = 0;
					}
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					dataRow[17] = "HrsBudgetSummary_Equip.aspx?ModId=14&&SubModId=&wono=" + sqlDataReader["WONo"].ToString() + "&Key=" + randomAlphaNumeric + "&PKey=" + Key;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet = new HrsBudgetSummary();
				dataSet.Tables[0].Merge(dataTable);
				dataSet.AcceptChanges();
				string text = base.Server.MapPath("~/Module/MIS/Transactions/Reports/HrsBudgetSummary.rpt");
				report.Load(text);
				report.SetDataSource(dataSet);
				string text2 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				sqlConnection.Close();
			}
			else
			{
				Key = base.Request.QueryString["Key"].ToString();
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Menu.aspx?ModId=14&SubModId=");
	}
}

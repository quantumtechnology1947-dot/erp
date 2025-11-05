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

public class Module_MIS_Transactions_HrsBudgetSummary_Equip : Page, IRequiresSessionState
{
	protected Button Button1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	private int CompId;

	private int FinYearId;

	private string SId = string.Empty;

	private string WONo = string.Empty;

	private string Key = string.Empty;

	private string PKey = string.Empty;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private Cal_Used_Hours CUS = new Cal_Used_Hours();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1673: Unknown result type (might be due to invalid IL or missing references)
		//IL_167a: Expected O, but got Unknown
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			WONo = base.Request.QueryString["wono"];
			Key = base.Request.QueryString["Key"].ToString();
			PKey = base.Request.QueryString["PKey"].ToString();
			if (!base.IsPostBack)
			{
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProjectTitle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EquipNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MDBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MDUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MABHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MAUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MCBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MCUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MDIBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MDIUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MIBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MIUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTRBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MTRUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EDBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EDUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EABHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EAUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ECBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ECUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ETBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ETUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EDIBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EDIUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EIBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EIUHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ETRBHrs", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ETRUHrs", typeof(double)));
				string cmdText = fun.select("TaskProjectTitle", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND WONo='" + WONo + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				string cmdText2 = "SELECT tblDG_BOM_Master.ItemId,tblDG_Item_Master.ItemCode, tblDG_Item_Master.ManfDesc FROM  tblDG_BOM_Master INNER JOIN tblDG_Item_Master ON tblDG_BOM_Master.ItemId = tblDG_Item_Master.Id AND tblDG_BOM_Master.WONo='" + WONo + "' AND tblDG_BOM_Master.PId='0'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = CompId;
					dataRow[1] = WONo;
					dataRow[2] = sqlDataReader["TaskProjectTitle"].ToString();
					dataRow[3] = sqlDataReader2["ItemCode"].ToString();
					dataRow[4] = sqlDataReader2["ManfDesc"].ToString();
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 1)) > 0.0)
					{
						dataRow[5] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 1));
					}
					else
					{
						dataRow[5] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 1)) > 0.0)
					{
						dataRow[6] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 1));
					}
					else
					{
						dataRow[6] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 2)) > 0.0)
					{
						dataRow[7] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 2));
					}
					else
					{
						dataRow[7] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 2)) > 0.0)
					{
						dataRow[8] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 2));
					}
					else
					{
						dataRow[8] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 3)) > 0.0)
					{
						dataRow[9] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 3));
					}
					else
					{
						dataRow[9] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 3)) > 0.0)
					{
						dataRow[10] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 3));
					}
					else
					{
						dataRow[10] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 4)) > 0.0)
					{
						dataRow[11] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 4));
					}
					else
					{
						dataRow[11] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 4)) > 0.0)
					{
						dataRow[12] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 4));
					}
					else
					{
						dataRow[12] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 5)) > 0.0)
					{
						dataRow[13] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 5));
					}
					else
					{
						dataRow[13] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 5)) > 0.0)
					{
						dataRow[14] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 5));
					}
					else
					{
						dataRow[14] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 6)) > 0.0)
					{
						dataRow[15] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 6));
					}
					else
					{
						dataRow[15] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 6)) > 0.0)
					{
						dataRow[16] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 6));
					}
					else
					{
						dataRow[16] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 7)) > 0.0)
					{
						dataRow[17] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 7));
					}
					else
					{
						dataRow[17] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 7)) > 0.0)
					{
						dataRow[18] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 2, 7));
					}
					else
					{
						dataRow[18] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 8)) > 0.0)
					{
						dataRow[19] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 8));
					}
					else
					{
						dataRow[19] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 8)) > 0.0)
					{
						dataRow[20] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 8));
					}
					else
					{
						dataRow[20] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 9)) > 0.0)
					{
						dataRow[21] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 9));
					}
					else
					{
						dataRow[21] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 9)) > 0.0)
					{
						dataRow[22] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 9));
					}
					else
					{
						dataRow[22] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 10)) > 0.0)
					{
						dataRow[23] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 10));
					}
					else
					{
						dataRow[23] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 10)) > 0.0)
					{
						dataRow[24] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 10));
					}
					else
					{
						dataRow[24] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 11)) > 0.0)
					{
						dataRow[25] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 11));
					}
					else
					{
						dataRow[25] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 11)) > 0.0)
					{
						dataRow[26] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 11));
					}
					else
					{
						dataRow[26] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 12)) > 0.0)
					{
						dataRow[27] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 12));
					}
					else
					{
						dataRow[27] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 12)) > 0.0)
					{
						dataRow[28] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 12));
					}
					else
					{
						dataRow[28] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 13)) > 0.0)
					{
						dataRow[29] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 13));
					}
					else
					{
						dataRow[29] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 13)) > 0.0)
					{
						dataRow[30] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 13));
					}
					else
					{
						dataRow[30] = 0;
					}
					if (Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 14)) > 0.0)
					{
						dataRow[31] = Convert.ToDouble(CUS.AllocatedHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 14));
					}
					else
					{
						dataRow[31] = 0;
					}
					if (Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 14)) > 0.0)
					{
						dataRow[32] = Convert.ToDouble(CUS.UtilizeHrs_WONo(CompId, WONo, Convert.ToInt32(sqlDataReader2["ItemId"]), 3, 14));
					}
					else
					{
						dataRow[32] = 0;
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet = new HrsBudgetSummary_Equip();
				dataSet.Tables[0].Merge(dataTable);
				dataSet.AcceptChanges();
				string text = base.Server.MapPath("~/Module/MIS/Transactions/Reports/HrsBudgetSummary_Equip.rpt");
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
		base.Response.Redirect("HrsBudgetSummary.aspx?ModId=14&SubModId=&Key=" + PKey);
	}
}

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private ReportDocument cryRpt = new ReportDocument();

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private string Id = "";

	private string x = "";

	private string y = "";

	private string z = "";

	private string r = "";

	private string date = "";

	private string Key = string.Empty;

	private string w = string.Empty;

	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Expected O, but got Unknown
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected O, but got Unknown
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			Key = base.Request.QueryString["Key"].ToString();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			x = base.Request.QueryString["x"].ToString();
			y = base.Request.QueryString["y"].ToString();
			w = base.Request.QueryString["w"].ToString();
			z = base.Request.QueryString["z"].ToString();
			r = base.Request.QueryString["r"].ToString();
			date = base.Request.QueryString["Date"].ToString();
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			if (!base.IsPostBack)
			{
				con.Open();
				dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Types", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable2.Columns.Add(new DataColumn("EquipNo", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Cate", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("SubCate", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Planned", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Actual", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Hrs", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("MId", typeof(int)));
				string cmdText = fun.select("*", "tblPM_ManPowerPlanning", " CompId='" + CompId + "'" + x + w + z + r + date + " Order by Date ASC");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = "SELECT OfferId,Title+'. '+EmployeeName As EmpName, tblHR_Designation.Type FROM tblHR_OfficeStaff INNER JOIN tblHR_Designation ON tblHR_OfficeStaff.Designation = tblHR_Designation.Id AND tblHR_OfficeStaff.EmpId='" + sqlDataReader["EmpId"].ToString() + "'" + y;
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					dataRow[0] = sqlDataReader2["EmpName"].ToString();
					dataRow[1] = sqlDataReader["EmpId"].ToString();
					dataRow[2] = sqlDataReader2["Type"].ToString();
					dataRow[3] = fun.FromDateDMY(sqlDataReader["Date"].ToString());
					string text = "";
					text = ((sqlDataReader["WONo"] == DBNull.Value || !(sqlDataReader["WONo"].ToString() != "")) ? "NA" : sqlDataReader["WONo"].ToString());
					dataRow[4] = text;
					string cmdText3 = fun.select("Symbol", "BusinessGroup", string.Concat("Id='", sqlDataReader["Dept"], "'"));
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					string text2 = "";
					text2 = ((!sqlDataReader3.HasRows) ? "NA" : sqlDataReader3["Symbol"].ToString());
					dataRow[5] = text2;
					switch (Convert.ToInt32(sqlDataReader["Types"]))
					{
					case 1:
						dataRow[6] = "Present";
						break;
					case 2:
						dataRow[6] = "Absent";
						break;
					case 3:
						dataRow[6] = "Onsite";
						break;
					case 4:
						dataRow[6] = "PL";
						break;
					}
					dataRow[7] = Convert.ToInt32(sqlDataReader["Id"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
					string cmdText4 = string.Concat("SELECT  tblPM_ManPowerPlanning_Details.EquipId,tblPM_ManPowerPlanning_Details.PlannedDesc,tblPM_ManPowerPlanning_Details.ActualDesc,tblPM_ManPowerPlanning_Details.Hour,tblPM_ManPowerPlanning_Details.MId,tblMIS_BudgetHrs_Field_Category.Category, tblMIS_BudgetHrs_Field_SubCategory.SubCategory FROM  tblPM_ManPowerPlanning_Details INNER JOIN tblMIS_BudgetHrs_Field_Category ON tblPM_ManPowerPlanning_Details.Category = tblMIS_BudgetHrs_Field_Category.Id INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblPM_ManPowerPlanning_Details.SubCategory = tblMIS_BudgetHrs_Field_SubCategory.Id AND tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId AND tblPM_ManPowerPlanning_Details.MId='", sqlDataReader["Id"], "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					while (sqlDataReader4.Read())
					{
						DataRow dataRow2 = dataTable2.NewRow();
						string cmdText5 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", sqlDataReader4["EquipId"], "'"));
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
						SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
						sqlDataReader5.Read();
						dataRow2[0] = sqlDataReader5["ItemCode"].ToString();
						dataRow2[1] = sqlDataReader5["ManfDesc"].ToString();
						dataRow2[2] = sqlDataReader4["Category"].ToString();
						dataRow2[3] = sqlDataReader4["SubCategory"].ToString();
						dataRow2[4] = sqlDataReader4["PlannedDesc"].ToString();
						dataRow2[5] = sqlDataReader4["ActualDesc"].ToString();
						dataRow2[6] = Convert.ToDouble(sqlDataReader4["Hour"]);
						dataRow2[7] = Convert.ToInt32(sqlDataReader4["MId"]);
						dataTable2.Rows.Add(dataRow2);
						dataTable2.AcceptChanges();
					}
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet2 = new ManPlan();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.Tables[1].Merge(dataTable2);
				dataSet2.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/ProjectManagement/Transactions/Reports/ManPowerPlanning.rpt"));
				cryRpt.SetDataSource(dataSet2);
				string text3 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
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
}

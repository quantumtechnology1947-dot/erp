using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Print_Details1 : Page, IRequiresSessionState
{
	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Button btnCancel;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private ReportDocument cryRpt = new ReportDocument();

	private string connStr = "";

	private string Id = "";

	private string Key = string.Empty;

	private string w = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Expected O, but got Unknown
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		try
		{
			Id = base.Request.QueryString["Id"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
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
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TotHours", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Hours", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AmendmentNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ActualDesc", typeof(string)));
				string cmdText = fun.select("*", "tblPM_ManPowerPlanning_Amd", "MId='" + Id + "' Order by Id Desc");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("Title,EmployeeName,Designation,OfferId", "tblHR_OfficeStaff", "  tblHR_OfficeStaff.EmpId='" + sqlDataReader["EmpId"].ToString() + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
						dataRow[1] = sqlDataReader["EmpId"].ToString();
						string cmdText3 = fun.select("tblHR_Designation.Symbol+ '-' + tblHR_Designation.Type AS Designation", "tblHR_Designation", " tblHR_Designation.Id='" + dataSet2.Tables[0].Rows[0]["Designation"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						dataRow[2] = dataSet3.Tables[0].Rows[0]["Designation"].ToString();
						dataRow[3] = fun.FromDateDMY(sqlDataReader["Date"].ToString());
						string text = fun.FromDateDMY(sqlDataReader["Date"].ToString());
						string[] array = text.Split('-');
						string value = array[1];
						string value2 = array[2];
						int month = Convert.ToInt32(value);
						int year = Convert.ToInt32(value2);
						double num5 = DateTime.DaysInMonth(year, month);
						string text2 = "";
						text2 = ((sqlDataReader["WONo"] == DBNull.Value || !(sqlDataReader["WONo"].ToString() != "")) ? "NA" : sqlDataReader["WONo"].ToString());
						dataRow[4] = text2;
						string cmdText4 = fun.select("Symbol", "BusinessGroup", string.Concat("Id='", sqlDataReader["Dept"], "'"));
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4);
						string text3 = "";
						text3 = ((dataSet4.Tables[0].Rows.Count <= 0) ? "NA" : dataSet4.Tables[0].Rows[0]["Symbol"].ToString());
						dataRow[5] = text3;
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
						dataRow[7] = sqlDataReader["Description"].ToString();
						if (sqlDataReader["Hours"] != DBNull.Value)
						{
							dataRow[8] = Math.Round(Convert.ToDouble(sqlDataReader["Hours"]), 2);
							num2 = Convert.ToDouble(sqlDataReader["Hours"]);
						}
						else
						{
							dataRow[8] = 0;
						}
						num3 = num / (num5 * num4);
						dataRow[9] = sqlDataReader["Id"].ToString();
						dataRow[10] = sqlDataReader["CompId"].ToString();
						dataRow[11] = num3;
						dataRow[12] = num3 * num2;
						if (sqlDataReader["AmendmentNo"].ToString() != "0")
						{
							dataRow[13] = sqlDataReader["AmendmentNo"].ToString();
						}
						else
						{
							dataRow[13] = " 0 ";
						}
						dataRow[14] = sqlDataReader["ActualDesc"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet5 = new ManPlan();
				dataSet5.Tables[0].Merge(dataSet.Tables[0]);
				dataSet5.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/ProjectManagement/Transactions/Reports/ManPowerPlanning1.rpt"));
				cryRpt.SetDataSource(dataSet5);
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
		finally
		{
			dataSet.Clear();
			dataSet.Dispose();
			dataTable.Clear();
			dataTable.Dispose();
			con.Close();
			con.Dispose();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/ManPowerPlanning_Print_Details.aspx?x= &y= &w= &z= &r= &Date= &Key=" + randomAlphaNumeric);
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

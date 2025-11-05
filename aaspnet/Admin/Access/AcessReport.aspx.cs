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

public class Admin_Access_AcessReport : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected CrystalReportSource CrystalReportSource1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string CompId = "";

	private string FyId = "";

	private ReportDocument crystalRpt = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				sqlConnection.Open();
				CompId = base.Request.QueryString["cid"].ToString();
				FyId = base.Request.QueryString["fyid"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				string cmdText = fun.select("Id,SysDate,SysTime ,SessionId ,CompId , FinYearId ,EmpId , ModId , SubModId , AccessType , Access ", "tblAccess_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND EmpId!='Sapl0001'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Department", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Desination", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompanyEmail", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExtNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ModName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SubModName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AccessType", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Access", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				DataRow dataRow = dataTable.NewRow();
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("EmployeeName,Department,Designation,ContactNo,CompanyEmail,ExtensionNo", "tblHR_OfficeStaff", "EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' and ResignationDate=''");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					SqlCommand selectCommand3 = new SqlCommand(fun.select("Description As Department ", "tblHR_Departments", "Id='" + dataSet3.Tables[0].Rows[0]["Department"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet4.Tables[0].Rows[0]["Department"].ToString();
					}
					SqlCommand selectCommand4 = new SqlCommand(fun.select("Type As Desination", "tblHR_Designation", "Id='" + dataSet3.Tables[0].Rows[0]["Designation"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet5.Tables[0].Rows[0]["Desination"].ToString();
					}
					SqlCommand selectCommand5 = new SqlCommand(fun.select("ExtNo", "tblHR_IntercomExt", "Id='" + dataSet3.Tables[0].Rows[0]["ExtensionNo"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[8] = dataSet6.Tables[0].Rows[0]["ExtNo"].ToString();
					}
					SqlCommand selectCommand6 = new SqlCommand(fun.select("ModName", "tblModule_Master", "ModId='" + dataSet2.Tables[0].Rows[i]["ModId"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet7.Tables[0].Rows[0]["ModName"].ToString();
					}
					SqlCommand selectCommand7 = new SqlCommand(fun.select("SubModName,MTR as Type", "tblSubModule_Master", "SubModId='" + dataSet2.Tables[0].Rows[i]["SubModId"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter7.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = dataSet8.Tables[0].Rows[0]["SubModName"].ToString();
					}
					SqlCommand selectCommand8 = new SqlCommand(fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet2.Tables[0].Rows[i]["FinYearId"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter8.Fill(dataSet9);
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					dataRow[1] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					dataRow[2] = dataSet9.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[3] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
					dataRow[6] = dataSet3.Tables[0].Rows[0]["ContactNo"].ToString();
					dataRow[7] = dataSet3.Tables[0].Rows[0]["CompanyEmail"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						string text = dataSet2.Tables[0].Rows[i]["AccessType"].ToString();
						string value = "";
						switch (text)
						{
						case "1":
							value = "New";
							break;
						case "2":
							value = "Edit";
							break;
						case "3":
							value = "Delete";
							break;
						case "4":
							value = "Print";
							break;
						}
						dataRow[11] = value;
					}
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						string text2 = dataSet2.Tables[0].Rows[i]["Access"].ToString();
						string value2 = "";
						switch (text2)
						{
						case "1":
							value2 = "Yes";
							break;
						case "2":
							value2 = "Yes";
							break;
						case "3":
							value2 = "Yes";
							break;
						case "4":
							value2 = "Yes";
							break;
						case "0":
							value2 = "No";
							break;
						}
						dataRow[12] = value2;
					}
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						string text3 = dataSet8.Tables[0].Rows[0]["Type"].ToString();
						string value3 = "";
						switch (text3)
						{
						case "1":
							value3 = "Master";
							break;
						case "2":
							value3 = "Transaction";
							break;
						case "3":
							value3 = "Report";
							break;
						}
						dataRow[13] = value3;
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataView defaultView = dataTable.DefaultView;
				defaultView.Sort = "EmployeeName ASC";
				DataTable table = defaultView.ToTable();
				dataSet.Tables.Add(table);
				dataSet.AcceptChanges();
				DataSet dataSet10 = new AdminAccess();
				dataSet10.Tables[0].Merge(dataSet.Tables[0]);
				dataSet10.AcceptChanges();
				string text4 = base.Server.MapPath("~/Admin/Access/AccessReports.rpt");
				crystalRpt.Load(text4);
				crystalRpt.SetDataSource(dataSet10);
				string text5 = fun.CompAdd(Convert.ToInt32(CompId));
				crystalRpt.SetParameterValue("CompAdd", (object)text5);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = crystalRpt;
				Session[Key] = crystalRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataSet.Clear();
				dataSet.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		crystalRpt = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AccessModule.aspx?");
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		crystalRpt.Close();
		((Component)(object)crystalRpt).Dispose();
		GC.Collect();
	}
}

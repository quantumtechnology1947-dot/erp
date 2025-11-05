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

public class Module_HR_Transactions_GatePass_Print_Details : Page, IRequiresSessionState
{
	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string SId = "";

	private string z = "";

	private string p = "";

	private string q = "";

	private string FDate = "";

	private string TDate = "";

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1109: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		try
		{
			SId = Session["username"].ToString();
			DataSet dataSet2 = new DataSet();
			CompId = Convert.ToInt32(Session["compid"]);
			z = base.Request.QueryString["z"].ToString();
			p = base.Request.QueryString["p"].ToString();
			q = base.Request.QueryString["q"].ToString();
			FDate = base.Request.QueryString["FDate"].ToString();
			TDate = base.Request.QueryString["TDate"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("tblGate_Pass.SessionId,tblGate_Pass.CompId,tblGate_Pass.SysDate,tblGate_Pass.Authorize,tblGate_Pass.EmpId As SelfEId,tblGate_Pass.Id,tblGate_Pass.FinYearId,tblGate_Pass.GPNo,tblGate_Pass.Authorize,tblGate_Pass.AuthorizedBy,tblGate_Pass.AuthorizeDate,tblGate_Pass.AuthorizeTime,tblGatePass_Details.FromDate,tblGatePass_Details.TypeOf,tblGatePass_Details.FromTime,tblGatePass_Details.ToTime,tblGatePass_Details.Type,tblGatePass_Details.TypeFor,tblGatePass_Details.Reason,tblGatePass_Details.Feedback,tblGatePass_Details.Id As DId,tblGatePass_Details.EmpId As OtherEId,tblGatePass_Details.Place,tblGatePass_Details.ContactPerson,tblGatePass_Details.ContactNo", "tblGate_Pass,tblGatePass_Details", "tblGate_Pass.Id=tblGatePass_Details.MId  AND  tblGate_Pass.CompId='" + CompId + "'  " + z + p + q + " order by tblGate_Pass.Id");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GPNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AuthorizedBy", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AuthorizeDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AuthorizeTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Feedback", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SelfEId", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Authorize", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Place", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Empother", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable.NewRow();
						string value = "";
						string value2 = "";
						string value3 = "";
						string value4 = "";
						string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
						dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
						dataRow[2] = dataSet.Tables[0].Rows[i]["GPNo"].ToString();
						dataRow[3] = fun.FromDate(dataSet.Tables[0].Rows[i]["FromDate"].ToString());
						dataRow[4] = dataSet.Tables[0].Rows[i]["FromTime"].ToString();
						dataRow[5] = dataSet.Tables[0].Rows[i]["ToTime"].ToString();
						if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
						{
							value4 = "WONo :" + dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
						}
						else if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
						{
							value4 = "Enquiry :" + dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
						}
						else if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "3")
						{
							value4 = dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
						}
						dataRow[7] = value4;
						dataRow[8] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
						string cmdText3 = fun.select("*", "tblGatePass_Reason", "Id='" + dataSet.Tables[0].Rows[i]["Type"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4);
						dataRow[6] = dataSet4.Tables[0].Rows[0]["Reason"].ToString();
						if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Authorize"]) == 1)
						{
							string cmdText4 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["AuthorizedBy"].ToString() + "'And CompId='" + CompId + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter4.Fill(dataSet5);
							value = dataSet5.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
							value2 = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["AuthorizeDate"].ToString());
							value3 = dataSet.Tables[0].Rows[i]["AuthorizeTime"].ToString();
						}
						dataRow[9] = value;
						dataRow[10] = value2;
						dataRow[11] = value3;
						if (dataSet.Tables[0].Rows[i]["Feedback"] != DBNull.Value)
						{
							dataSet.Tables[0].Rows[i]["Feedback"].ToString();
						}
						dataRow[12] = dataSet.Tables[0].Rows[i]["Feedback"].ToString();
						dataRow[13] = dataSet.Tables[0].Rows[i]["DId"].ToString();
						string text = "";
						string text2 = "";
						string value5 = "";
						if (dataSet.Tables[0].Rows[i]["SelfEId"] != DBNull.Value)
						{
							string cmdText5 = fun.select("Title,EmployeeName,EmpId,Symbol", "tblHR_OfficeStaff,BusinessGroup", "EmpId='" + dataSet.Tables[0].Rows[i]["SelfEId"].ToString() + "'And CompId='" + CompId + "' And tblHR_OfficeStaff.BGGroup=BusinessGroup.Id ");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter5.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								text = dataSet6.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet6.Tables[0].Rows[0]["EmployeeName"].ToString() + ",";
								value5 = dataSet6.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
						else
						{
							string cmdText6 = fun.select("Title,EmployeeName,EmpId,Symbol", "tblHR_OfficeStaff,BusinessGroup", "EmpId='" + dataSet.Tables[0].Rows[i]["OtherEId"].ToString() + "'And CompId='" + CompId + "'And tblHR_OfficeStaff.BGGroup=BusinessGroup.Id ");
							SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter6.Fill(dataSet7);
							if (dataSet7.Tables[0].Rows.Count > 0)
							{
								text2 = dataSet7.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet7.Tables[0].Rows[0]["EmployeeName"].ToString() + ",";
								value5 = dataSet7.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
						dataRow[14] = text + text2;
						dataRow[15] = dataSet.Tables[0].Rows[i]["Authorize"].ToString();
						dataRow[16] = dataSet.Tables[0].Rows[i]["Place"].ToString();
						dataRow[17] = dataSet.Tables[0].Rows[i]["ContactPerson"].ToString();
						dataRow[18] = dataSet.Tables[0].Rows[i]["ContactNo"].ToString();
						string cmdText7 = fun.select("Title,EmployeeName,EmpId", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["Sessionid"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter7.Fill(dataSet8);
						dataRow[19] = dataSet8.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet8.Tables[0].Rows[0]["EmployeeName"].ToString();
						dataRow[20] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
						dataRow[21] = value5;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet9 = new GatePassPrint();
				dataSet9.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet9.AcceptChanges();
				string text3 = base.Server.MapPath("~/Module/HR/Transactions/Reports/GatePass.rpt");
				report.Load(text3);
				report.SetDataSource(dataSet9);
				report.SetParameterValue("FDate", (object)FDate);
				report.SetParameterValue("TDate", (object)TDate);
				string text4 = fun.CompAdd(CompId);
				report.SetParameterValue("CompAdd", (object)text4);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
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
			sqlConnection.Close();
			sqlConnection.Dispose();
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
}

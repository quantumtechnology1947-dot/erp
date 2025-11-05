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

public class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Print_Report : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string Id = "";

	private int WOId;

	private string WONo = "";

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd9: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		try
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WOId"]))
			{
				WOId = Convert.ToInt32(base.Request.QueryString["WOId"].ToString());
			}
			SId = Session["username"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			Id = base.Request.QueryString["Id"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("tblPM_MaterialCreditNote_Master.SessionId, tblPM_MaterialCreditNote_Master.CompId,tblPM_MaterialCreditNote_Master.Id ,tblPM_MaterialCreditNote_Master.SysDate,tblPM_MaterialCreditNote_Master.MCNNo,tblPM_MaterialCreditNote_Details.PId,tblPM_MaterialCreditNote_Details.CId,tblPM_MaterialCreditNote_Details.MCNQty,tblPM_MaterialCreditNote_Details.Id As DId", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", "tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Master.WONo='" + WONo + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "'   AND tblPM_MaterialCreditNote_Master.Id='" + Id + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				string text = "";
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MCNQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MCNNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MCNDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("QAQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					double num = 0.0;
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					Convert.ToInt32(dataSet2.Tables[0].Rows[i]["PId"]);
					Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]);
					string cmdText2 = fun.select("QAQty", "tblQc_AuthorizedMCN", " FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And  MCNId='" + dataSet2.Tables[0].Rows[i]["Id"].ToString() + "' AND MCNDId='" + dataSet2.Tables[0].Rows[i]["DId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["QAQty"].ToString()).ToString("N3"));
					}
					string cmdText3 = fun.select("*", "tblDG_BOM_Master", "WONo='" + WONo + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And  PId='" + dataSet2.Tables[0].Rows[i]["PId"].ToString() + "' AND CId='" + dataSet2.Tables[0].Rows[i]["CId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
					string cmdText4 = fun.select("*", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[0]["ItemId"]) + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5, "tblDG_Item_Master");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						if (dataSet5.Tables[0].Rows[0]["CId"] != DBNull.Value)
						{
							dataRow[1] = dataSet5.Tables[0].Rows[0]["ItemCode"].ToString();
						}
						else
						{
							dataRow[1] = dataSet5.Tables[0].Rows[0]["PartNo"].ToString();
						}
						dataRow[2] = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText5 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["UOMBasic"]) + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6, "Unit_Master");
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							dataRow[3] = dataSet6.Tables[0].Rows[0]["Symbol"].ToString();
						}
					}
					dataRow[5] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["MCNQty"]);
					dataRow[6] = dataSet2.Tables[0].Rows[i]["MCNNo"].ToString();
					dataRow[7] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[8] = num;
					dataRow[9] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["CompId"]);
					string cmdText6 = fun.select(" Title,EmployeeName ", " tblHR_OfficeStaff ", " EmpId='" + dataSet2.Tables[0].Rows[i]["SessionId"].ToString() + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7, "tblHR_OfficeStaff");
					text = dataSet7.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet7.Tables[0].Rows[0]["EmployeeName"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet8 = new MCN();
				dataSet8.Tables[0].Merge(dataSet.Tables[0]);
				dataSet8.AcceptChanges();
				string text2 = base.Server.MapPath("~/Module/ProjectManagement/Transactions/Reports/MaterialCreditNote.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet8);
				string text3 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text3);
				report.SetParameterValue("WONo", (object)WONo);
				string text4 = "";
				string text5 = "";
				string cmdText7 = fun.select("TaskProjectTitle,CustomerId", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND WONo='" + WONo + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter7.Fill(dataSet9);
				if (dataSet9.Tables[0].Rows.Count > 0)
				{
					text5 = dataSet9.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
					string cmdText8 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet9.Tables[0].Rows[0]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter8.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						text4 = dataSet10.Tables[0].Rows[0]["CustomerName"].ToString() + " [ " + dataSet10.Tables[0].Rows[0]["CustomerId"].ToString() + " ]";
					}
					report.SetParameterValue("Customer", (object)text4);
					report.SetParameterValue("Project", (object)text5);
					report.SetParameterValue("EMPName", (object)text);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					Session[Key] = report;
				}
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

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_Print_Details.aspx?WONo=" + WONo + "&WOId=" + WOId + "&ModId=7&SubModId=127");
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

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

public class Module_Inventory_Reports_WorkOrder_Shortage_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button2;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private DataTable DT = new DataTable();

	public string WONo = "";

	private int CompId;

	private int FinYearId;

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Expected O, but got Unknown
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		WONo = base.Request.QueryString["wono"].ToString();
		Key = base.Request.QueryString["Key"].ToString();
		DataSet dataSet = new DataSet();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		if (!base.IsPostBack)
		{
			try
			{
				if (base.Request.QueryString["wono"] != "")
				{
					string cmdText = "select Distinct tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode from tblDG_BOM_Master,tblDG_Item_Master,Unit_Master where Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.WONo='" + WONo + "' And tblDG_BOM_Master.CompId='" + CompId + "'";
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
					DT.Columns.Add("ItemCode", typeof(string));
					DT.Columns.Add("ManfDesc", typeof(string));
					DT.Columns.Add("UOM", typeof(string));
					DT.Columns.Add("Qty", typeof(double));
					DT.Columns.Add("WONo", typeof(string));
					DT.Columns.Add("CompId", typeof(int));
					DT.Columns.Add("IssueQty", typeof(double));
					DT.Columns.Add("Rate", typeof(double));
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = DT.NewRow();
						dataRow[0] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
						dataRow[1] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
						dataRow[2] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
						double num = fun.AllComponentBOMQty(CompId, WONo, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId);
						dataRow[3] = num;
						dataRow[4] = WONo;
						dataRow[5] = CompId;
						double num2 = 0.0;
						num2 = Math.Round(num - fun.CalWISQty(CompId.ToString(), WONo, dataSet.Tables[0].Rows[i]["ItemId"].ToString()), 5);
						dataRow[6] = num2;
						double num3 = 0.0;
						string cmdText2 = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", string.Concat("CompId='", CompId, "'And ItemId='", dataSet.Tables[0].Rows[i]["ItemId"], "'"));
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["rate"] != DBNull.Value)
						{
							num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["rate"]);
						}
						dataRow[7] = num3;
						if (num2 > 0.0)
						{
							DT.Rows.Add(dataRow);
							DT.AcceptChanges();
						}
					}
					string company = fun.getCompany(CompId);
					string text = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string text2 = base.Server.MapPath("~/Module/Inventory/Reports/WorkOrder_Shortage.rpt");
					report.Load(text2);
					report.SetDataSource(DT);
					report.SetParameterValue("Company", (object)company);
					report.SetParameterValue("Address", (object)text);
					report.SetParameterValue("Title", (object)projectTitle);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					Session[Key] = report;
				}
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
				DT.Clear();
				DT.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
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
		base.Response.Redirect("WorkOrder_Issue.aspx");
	}
}

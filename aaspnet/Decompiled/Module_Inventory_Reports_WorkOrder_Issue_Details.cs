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

public class Module_Inventory_Reports_WorkOrder_Issue_Details : Page, IRequiresSessionState
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
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		if (!base.IsPostBack)
		{
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				if (base.Request.QueryString["wono"] != "")
				{
					WONo = base.Request.QueryString["wono"].ToString();
					DT.Columns.Add("ItemCode", typeof(string));
					DT.Columns.Add("ManfDesc", typeof(string));
					DT.Columns.Add("UOM", typeof(string));
					DT.Columns.Add("Qty", typeof(double));
					DT.Columns.Add("WONo", typeof(string));
					DT.Columns.Add("CompId", typeof(int));
					DT.Columns.Add("IssueQty", typeof(double));
					DT.Columns.Add("Rate", typeof(double));
					SqlCommand sqlCommand = new SqlCommand("WIS_WONo_Wise", sqlConnection);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@CompId", CompId);
					sqlCommand.Parameters.AddWithValue("@WONo", WONo);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						DataRow dataRow = DT.NewRow();
						dataRow[0] = sqlDataReader["ItemCode"].ToString();
						dataRow[1] = sqlDataReader["ManfDesc"].ToString();
						dataRow[2] = sqlDataReader["UOMBasic"].ToString();
						double num = fun.AllComponentBOMQty(CompId, WONo, sqlDataReader["ItemId"].ToString(), FinYearId);
						dataRow[3] = num;
						dataRow[4] = WONo;
						dataRow[5] = CompId;
						dataRow[6] = fun.CalWISQty(CompId.ToString(), WONo, sqlDataReader["ItemId"].ToString());
						double num2 = 0.0;
						string cmdText = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", string.Concat("CompId='", CompId, "'And ItemId='", sqlDataReader["ItemId"], "'"));
						SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["rate"] != DBNull.Value)
						{
							num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["rate"]);
						}
						dataRow[7] = num2;
						DT.Rows.Add(dataRow);
						DT.AcceptChanges();
					}
					sqlDataReader.Close();
					string company = fun.getCompany(CompId);
					string text = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string text2 = base.Server.MapPath("~/Module/Inventory/Reports/WorkOrder_Issue.rpt");
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
				DT.Clear();
				DT.Dispose();
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

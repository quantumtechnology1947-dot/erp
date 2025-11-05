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

public class Module_Inventory_Transactions_WISWONO_Print_ : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string x = "";

	private string z = "";

	private string FDate = "";

	private string TDate = "";

	private string Key = string.Empty;

	private double OverHeads;

	private ReportDocument report = new ReportDocument();

	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void prints()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		try
		{
			sqlConnection.Open();
			x = base.Request.QueryString["x"].ToString();
			z = base.Request.QueryString["z"].ToString();
			OverHeads = Convert.ToDouble(base.Request.QueryString["OverHeads"].ToString());
			FDate = base.Request.QueryString["FDate"].ToString();
			TDate = base.Request.QueryString["TDate"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WISNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("IssuedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TaskTargetTryOut_FDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskTargetTryOut_TDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskTargetDespach_FDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskTargetDespach_TDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskProjectLeader", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			string cmdText = fun.select("ItemCode,Description,UOM,StockQty,Sum(WISQty) AS WISQty,ItemId,SysDate,WISNo,WONo,WOId", "View_WIP_Final", " FinYearId<=" + FinYearId + x + z + " group by ItemCode,Description,UOM,StockQty,ItemId,SysDate,WISNo,WONo,WOId order by WISNo Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				string empty = string.Empty;
				empty = fun.select("Id", "tblACC_SalesInvoice_Master", "WONo like '" + sqlDataReader["WoId"].ToString() + ",'");
				SqlCommand sqlCommand2 = new SqlCommand(empty, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				DataRow dataRow = dataTable.NewRow();
				text4 = sqlDataReader["WONo"].ToString();
				num2 = Convert.ToDouble(sqlDataReader["WISQty"]);
				num = fun.AllComponentBOMQty(CompId, text4, sqlDataReader["ItemId"].ToString(), FinYearId);
				text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
				text2 = sqlDataReader["Description"].ToString();
				text3 = sqlDataReader["UOM"].ToString();
				SqlCommand sqlCommand3 = new SqlCommand(string.Concat("Select MAX(dbo.tblMM_Rate_Register.Rate - dbo.tblMM_Rate_Register.Rate * (dbo.tblMM_Rate_Register.Discount / 100)) AS rate from tblMM_Rate_Register where ItemId='", sqlDataReader["ItemId"], "'"), sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3["rate"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(sqlDataReader3["rate"]) + Convert.ToDouble(sqlDataReader3["rate"]) * (OverHeads / 100.0);
				}
				dataRow[0] = text;
				dataRow[1] = text2;
				dataRow[2] = text3;
				dataRow[3] = sqlDataReader["WISNo"].ToString();
				dataRow[4] = num;
				dataRow[5] = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
				dataRow[7] = CompId;
				dataRow[14] = fun.FromDate(sqlDataReader["SysDate"].ToString());
				dataRow[15] = text4;
				dataRow[16] = sqlDataReader["StockQty"].ToString();
				dataRow[17] = num3;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			string text5 = base.Server.MapPath("~/Module/Inventory/Transactions/Reports/WONOWISe.rpt");
			report.Load(text5);
			report.SetDataSource(dataTable);
			string company = fun.getCompany(CompId);
			report.SetParameterValue("Company", (object)company);
			string text6 = fun.CompAdd(CompId);
			report.SetParameterValue("Address", (object)text6);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
			Session[Key] = report;
		}
		catch (Exception)
		{
		}
		finally
		{
			dataTable.Clear();
			dataTable.Dispose();
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			prints();
			return;
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
}

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

public class Module_Machinery_Transactions_PMBM_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private ReportDocument report = new ReportDocument();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int itemId;

	private int PMBMId;

	private int MachineId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				string value = base.Request.QueryString["PMBMId"];
				PMBMId = Convert.ToInt32(value);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				string cmdText = fun.select("MachineId", "tblMS_PMBM_Master", "Id='" + PMBMId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					MachineId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["MachineId"]);
				}
				string cmdText2 = fun.select("*", "tblMS_PMBM_Master", " MachineId='" + MachineId + "'  AND Id ='" + PMBMId + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("MachineId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("PMBM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("NameOfAgency", typeof(string)));
				dataTable.Columns.Add(new DataColumn("NameOfEngineer", typeof(string)));
				dataTable.Columns.Add(new DataColumn("NextPMDueOn", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Model", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Make", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Capacity", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MachineCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString());
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[2] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CompId"]);
					dataRow[3] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["MachineId"].ToString());
					if (dataSet.Tables[0].Rows[0]["PMBM"].ToString() == "0")
					{
						dataRow[4] = "Preventive";
					}
					else
					{
						dataRow[4] = "Breckdown";
					}
					dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["FromDate"].ToString());
					dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ToDate"].ToString());
					dataRow[7] = dataSet.Tables[0].Rows[0]["FromTime"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[0]["ToTime"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["NameOfAgency"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["NameOfEngineer"].ToString();
					dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["NextPMDueOn"].ToString());
					dataRow[12] = dataSet.Tables[0].Rows[0]["Remarks"].ToString();
					string cmdText3 = fun.select("ItemId", "tblMS_Master", "Id='" + MachineId + "'AND CompId='" + CompId + "' ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						itemId = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["ItemId"]);
					}
					string cmdText4 = fun.select("*", "tblMS_Master", " ItemId='" + itemId + "'AND Id='" + MachineId + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[13] = dataSet4.Tables[0].Rows[0]["Model"].ToString();
						dataRow[14] = dataSet4.Tables[0].Rows[0]["Make"].ToString();
						dataRow[15] = dataSet4.Tables[0].Rows[0]["Capacity"].ToString();
						dataRow[16] = dataSet4.Tables[0].Rows[0]["Location"].ToString();
					}
					string cmdText5 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic, tblDG_Item_Master.ItemCode ", " tblDG_Category_Master,tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.Id='" + itemId + "' AND tblDG_Item_Master.CompId='" + CompId + "'  ");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[17] = dataSet5.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[18] = dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString();
						dataRow[19] = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
				DataSet dataSet6 = new PMBM();
				dataSet6.Tables[0].Merge(dataTable);
				string text = base.Server.MapPath("~/Module/Machinery/Transactions/Reports/PMBM.rpt");
				report.Load(text);
				report.SetDataSource(dataSet6);
				string text2 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
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
				con.Close();
				con.Dispose();
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

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Transactions/PMBM_Print.aspx?ModId=15&SubModId=68");
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

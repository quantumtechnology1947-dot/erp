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

public class Module_MaterialPlanning_Transactions_Planning_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string PLNo = "";

	private string MId = "";

	private string wono = "";

	private string PLDate = "";

	private string PRNo = "";

	private string PRDate = "";

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f79: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(base.Request.QueryString["FinYearId"].ToString());
				PLNo = base.Request.QueryString["plno"].ToString();
				MId = base.Request.QueryString["MId"].ToString();
				wono = base.Request.QueryString["WONo"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				sqlConnection.Open();
				string cmdText = "SELECT tblMM_PR_Master.PRNo, tblMM_PR_Master.SysDate FROM tblMP_Material_Master INNER JOIN                     tblMM_PR_Master ON tblMP_Material_Master.Id = tblMM_PR_Master.PLNId And tblMM_PR_Master.PLNId ='" + MId + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					PRNo = dataSet2.Tables[0].Rows[0][0].ToString();
					PRDate = fun.FromDateDMY(dataSet2.Tables[0].Rows[0][1].ToString());
				}
				dataTable.Columns.Add(new DataColumn("PLDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PLNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DelDateFinish", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("FinishQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ItemCodeRMPR", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PLNType", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
				string value = "";
				string cmdText2 = "SELECT tblMP_Material_Master.SysDate,tblMP_Material_Detail.ItemId,tblMP_Material_Detail.Id,tblMP_Material_Detail.RM,tblMP_Material_Detail.PRO,tblMP_Material_Detail.FIN FROM tblMP_Material_Master,tblMP_Material_Detail where tblMP_Material_Master.Id=tblMP_Material_Detail.Mid And  tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId=" + CompId + " And  tblMP_Material_Master.Id='" + MId + "'  and tblMP_Material_Master.PLNo='" + PLNo + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter2.Fill(dataSet3);
				for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
				{
					PLDate = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["SysDate"].ToString());
					string cmdText3 = "";
					if (dataSet3.Tables[0].Rows[i]["FIN"].ToString() == "1")
					{
						cmdText3 = "SELECT  tblMP_Material_Master.SysDate,tblMP_Material_Finish.DelDate,tblMP_Material_Finish.Discount,tblMP_Material_Finish.Rate, tblMP_Material_Finish.Qty, tblMP_Material_Finish.ItemId, tblMP_Material_Finish.SupplierId, tblMP_Material_Detail.ItemId AS Expr1 FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.PLNo='" + PLNo + "' AND tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Finish.DMid='" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "' ";
						value = "Finish";
					}
					if (dataSet3.Tables[0].Rows[i]["RM"].ToString() == "1")
					{
						cmdText3 = "SELECT tblMP_Material_Master.SysDate,tblMP_Material_RawMaterial.DelDate,tblMP_Material_RawMaterial.Discount, tblMP_Material_RawMaterial.Rate, tblMP_Material_RawMaterial.Qty, tblMP_Material_RawMaterial.SupplierId,tblMP_Material_RawMaterial.ItemId, tblMP_Material_Detail.ItemId AS Expr1 FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_RawMaterial ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId=" + CompId + "  and tblMP_Material_Master.PLNo='" + PLNo + "'And tblMP_Material_RawMaterial.DMid='" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "'";
						value = "RM";
					}
					if (dataSet3.Tables[0].Rows[i]["PRO"].ToString() == "1")
					{
						cmdText3 = "SELECT tblMP_Material_Master.SysDate,tblMP_Material_Process.Discount,tblMP_Material_Process.DelDate, tblMP_Material_Process.Rate, tblMP_Material_Process.Qty, tblMP_Material_Process.SupplierId,tblMP_Material_Process.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid and tblMP_Material_Master.PLNo='" + PLNo + "' And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId=" + CompId + " And tblMP_Material_Process.DMid='" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "'";
						value = "Process";
					}
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
					{
						DataRow dataRow = dataTable.NewRow();
						if (dataSet4.Tables[0].Rows.Count <= 0)
						{
							continue;
						}
						string cmdText4 = fun.select("SupplierName,SupplierId", "tblMM_Supplier_master", "SupplierId='" + dataSet4.Tables[0].Rows[j]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						string cmdText5 = fun.select("ItemCode,UOMBasic,ManfDesc", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[j]["ItemId"].ToString() + "' ");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6);
						string cmdText6 = fun.select("Id,Symbol ", "Unit_Master", "Id='" + dataSet6.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter6.Fill(dataSet7);
						dataRow[0] = fun.FromDateDMY(dataSet4.Tables[0].Rows[j]["SysDate"].ToString());
						dataRow[1] = PLNo;
						if (dataSet6.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows.Count > 0)
						{
							if (dataSet5.Tables[0].Rows[0]["SupplierName"] != DBNull.Value && dataSet4.Tables[0].Rows[j]["DelDate"] != DBNull.Value)
							{
								dataRow[10] = dataSet6.Tables[0].Rows[0]["ItemCode"].ToString();
							}
							else
							{
								dataRow[10] = "";
							}
							if (dataSet5.Tables[0].Rows[0]["SupplierName"] != DBNull.Value && dataSet4.Tables[0].Rows[j]["DelDate"] != DBNull.Value)
							{
								dataRow[4] = dataSet6.Tables[0].Rows[0]["ManfDesc"].ToString();
							}
							else
							{
								dataRow[4] = "";
							}
						}
						if (dataSet7.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows.Count > 0)
						{
							if (dataSet5.Tables[0].Rows[0]["SupplierName"] != DBNull.Value && dataSet4.Tables[0].Rows[j]["DelDate"] != DBNull.Value)
							{
								dataRow[3] = dataSet7.Tables[0].Rows[0]["Symbol"].ToString();
							}
							else
							{
								dataRow[3] = "";
							}
						}
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet5.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet5.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
						}
						dataRow[6] = fun.FromDateDMY(dataSet4.Tables[0].Rows[j]["DelDate"].ToString());
						dataRow[8] = Convert.ToDouble(dataSet4.Tables[0].Rows[j]["Qty"].ToString());
						dataRow[9] = Convert.ToDouble(dataSet4.Tables[0].Rows[j]["Rate"].ToString());
						dataRow[7] = Convert.ToInt32(CompId);
						string cmdText7 = fun.select("ItemCode", "tblDG_Item_Master", "Id='" + dataSet3.Tables[0].Rows[i]["ItemId"].ToString() + "' ");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter7.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet8.Tables[0].Rows[0][0].ToString();
						}
						double num = fun.AllComponentBOMQty(CompId, wono, dataSet3.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId);
						dataRow[11] = num;
						dataRow[12] = value;
						dataRow[13] = Convert.ToDouble(dataSet4.Tables[0].Rows[j]["Discount"].ToString());
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet9 = new PlanPrint();
				dataSet9.Tables[0].Merge(dataSet.Tables[0]);
				dataSet9.AcceptChanges();
				string text = base.Server.MapPath("~/Module/MaterialPlanning/Reports/PlanningPrint.rpt");
				report.Load(text);
				report.SetDataSource(dataSet9);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				string text2 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text2);
				report.SetParameterValue("PlanNo", (object)PLNo);
				report.SetParameterValue("PLDate", (object)PLDate);
				report.SetParameterValue("WONo", (object)wono);
				report.SetParameterValue("PRNo", (object)PRNo);
				report.SetParameterValue("PRDate", (object)PRDate);
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

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MaterialPlanning/Transactions/Planning_Print.aspx?ModId=4&SubModId=33");
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

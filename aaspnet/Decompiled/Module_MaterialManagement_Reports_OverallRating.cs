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

public class Module_MaterialManagement_Reports_OverallRating : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource VendorRating;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private int Item;

	private string SId = "";

	private string SupplId = "";

	private string Fd = "";

	private string Td = "";

	private string Category = "";

	private string x = "";

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_10fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1102: Expected O, but got Unknown
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		SId = Session["username"].ToString();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SupplId = base.Request.QueryString["SupCode"];
		Fd = base.Request.QueryString["FD"];
		Td = base.Request.QueryString["TD"];
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			try
			{
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("NormalAccQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DeviatedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SegregatedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RejectedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Delrate", typeof(double)));
				dataTable.Columns.Add(new DataColumn("OverallRating", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Rating", typeof(double)));
				string text = "";
				string text2 = "";
				string text3 = "";
				string cmdText = fun.select(" Distinct(SupplierId)", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId   order by SupplierId ASC   ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					double num = 0.0;
					double num2 = 0.0;
					string cmdText2 = fun.select(" count(tblMM_SPR_Details.ItemId) As Counts", "tblMM_SPR_Details", " tblMM_SPR_Details.SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Counts"]);
					}
					string cmdText3 = fun.select(" count(tblMM_PR_Details.ItemId) As Counts", "tblMM_PR_Details", " tblMM_PR_Details.SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						num2 = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["Counts"]);
					}
					string cmdText4 = "Select tblMM_PO_Master.Id, tblMM_PO_Master.PRSPRFlag, tblMM_PO_Master.SupplierId, tblMM_PO_Details.PONo, tblMM_PO_Details.PRNo, tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo, tblMM_PO_Details.SPRId from tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId And  tblMM_PO_Master.CompId='" + CompId + "'     And tblMM_PO_Master.SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "' And tblMM_PO_Details.DelDate  between '" + fun.FromDate(Fd) + "' And '" + fun.FromDate(Td) + "'  ";
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
					{
						string cmdText5 = "  SELECT   tblMM_PO_Master.CompId,  tblMM_SPR_Details.ItemId, tblMM_PO_Details.DelDate, tblMM_PO_Details.Qty, tblQc_MaterialQuality_Details.DeviatedQty,tblQc_MaterialQuality_Details.SegregatedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.NormalAccQty,tblQc_MaterialQuality_Master.SysDate,tblMM_PO_Master.SupplierId FROM         tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN  tblInv_Inward_Master INNER JOIN   tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId INNER JOIN       tblMM_PO_Master INNER JOIN    tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId INNER JOIN   tblMM_SPR_Details INNER JOIN  tblMM_SPR_Master ON tblMM_SPR_Details.MId = tblMM_SPR_Master.Id ON tblMM_PO_Details.SPRId = tblMM_SPR_Details.Id INNER JOIN   tblMM_Supplier_master ON tblMM_SPR_Details.SupplierId = tblMM_Supplier_master.SupplierId AND      tblMM_PO_Master.SupplierId = tblMM_Supplier_master.SupplierId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id ON                       tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId AND tblinv_MaterialReceived_Master.GINId = tblInv_Inward_Master.Id INNER JOIN  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId ON  tblinv_MaterialReceived_Details.Id = tblQc_MaterialQuality_Details.GRRId  And tblMM_PO_Master.SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'    ";
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						double num3 = 0.0;
						double num4 = 0.0;
						double num5 = 0.0;
						double num6 = 0.0;
						double num7 = 0.0;
						double num8 = 0.0;
						double num9 = 0.0;
						DateTime dateTime = default(DateTime);
						DateTime dateTime2 = default(DateTime);
						TimeSpan timeSpan = default(TimeSpan);
						DateTime dateTime3 = default(DateTime);
						double num10 = 0.0;
						double num11 = 0.0;
						for (int j = 0; j < dataSet5.Tables[0].Rows.Count; j++)
						{
							num3 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["Qty"].ToString()).ToString("N3"));
							num4 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["NormalAccQty"].ToString()).ToString("N3"));
							num5 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["DeviatedQty"].ToString()).ToString("N3"));
							num6 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["SegregatedQty"].ToString()).ToString("N3"));
							num7 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["RejectedQty"].ToString()).ToString("N3"));
							dataRow[4] = num4;
							dataRow[5] = num5;
							dataRow[6] = num6;
							num10 += Convert.ToDouble(decimal.Parse(((num4 * 1.0 + num5 * 0.7 + num6 * 0.5) * 100.0 / num3).ToString()).ToString("N3"));
							dateTime2 = Convert.ToDateTime(dataSet5.Tables[0].Rows[j]["SysDate"].ToString());
							dataRow[7] = num7;
							dateTime = Convert.ToDateTime(dataSet5.Tables[0].Rows[j]["DelDate"].ToString());
							num9 = Convert.ToDouble(Math.Round((dateTime - dateTime2).TotalDays * 1.1, 0));
							dateTime3 = dateTime2.AddDays(num9);
							num8 = ((!(dateTime3 >= dateTime)) ? (num8 + 0.0) : (num8 + 100.0));
							dataRow[10] = num8 / num;
							dataRow[0] = "122232";
							dataRow[1] = "klkkl";
							dataRow[2] = "55";
							dataRow[3] = 5;
							dataRow[9] = Convert.ToInt32(dataSet5.Tables[0].Rows[j]["CompId"]);
							num11 = Convert.ToDouble(decimal.Parse((num10 * 0.6 + num8 * 0.4).ToString()).ToString("N3"));
							dataRow[11] = Convert.ToDouble(decimal.Parse((num11 / num).ToString()).ToString("N3"));
							dataRow[12] = Math.Round(num10 / num);
						}
						dataRow[8] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
					else if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText6 = "  SELECT   tblMM_PO_Master.CompId,  tblMM_PR_Details.ItemId, tblMM_PO_Details.DelDate, tblMM_PO_Details.Qty, tblQc_MaterialQuality_Details.DeviatedQty,tblQc_MaterialQuality_Details.SegregatedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.NormalAccQty,tblQc_MaterialQuality_Master.SysDate,tblMM_PO_Master.SupplierId FROM         tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN  tblInv_Inward_Master INNER JOIN   tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId INNER JOIN       tblMM_PO_Master INNER JOIN    tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId INNER JOIN   tblMM_PR_Details INNER JOIN  tblMM_PR_Master ON tblMM_PR_Details.MId = tblMM_PR_Master.Id ON tblMM_PO_Details.PRId = tblMM_PR_Details.Id INNER JOIN   tblMM_Supplier_master ON tblMM_PR_Details.SupplierId = tblMM_Supplier_master.SupplierId AND      tblMM_PO_Master.SupplierId = tblMM_Supplier_master.SupplierId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id ON                       tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId AND tblinv_MaterialReceived_Master.GINId = tblInv_Inward_Master.Id INNER JOIN  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId ON  tblinv_MaterialReceived_Details.Id = tblQc_MaterialQuality_Details.GRRId  And tblMM_PO_Master.SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'     ";
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						double num12 = 0.0;
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						double num16 = 0.0;
						double num17 = 0.0;
						double num18 = 0.0;
						DateTime dateTime4 = default(DateTime);
						DateTime dateTime5 = default(DateTime);
						TimeSpan timeSpan2 = default(TimeSpan);
						DateTime dateTime6 = default(DateTime);
						double num19 = 0.0;
						double num20 = 0.0;
						for (int k = 0; k < dataSet6.Tables[0].Rows.Count; k++)
						{
							num12 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[k]["Qty"].ToString()).ToString("N3"));
							num13 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[k]["NormalAccQty"].ToString()).ToString("N3"));
							num14 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[k]["DeviatedQty"].ToString()).ToString("N3"));
							num15 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[k]["SegregatedQty"].ToString()).ToString("N3"));
							num16 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[k]["RejectedQty"].ToString()).ToString("N3"));
							dataRow[4] = num13;
							dataRow[5] = num14;
							dataRow[6] = num15;
							num19 += Convert.ToDouble(decimal.Parse(((num13 * 1.0 + num14 * 0.7 + num15 * 0.5) * 100.0 / num12).ToString()).ToString("N3"));
							dateTime5 = Convert.ToDateTime(dataSet6.Tables[0].Rows[k]["SysDate"].ToString());
							dataRow[7] = num16;
							dateTime4 = Convert.ToDateTime(dataSet6.Tables[0].Rows[k]["DelDate"].ToString());
							num18 = Convert.ToDouble(Math.Round((dateTime4 - dateTime5).TotalDays * 1.1, 0));
							dateTime6 = dateTime5.AddDays(num18);
							num17 = ((!(dateTime6 >= dateTime4)) ? (num17 + 0.0) : (num17 + 100.0));
							dataRow[10] = num17 / num2;
							dataRow[0] = "122232";
							dataRow[1] = "klkkl";
							dataRow[2] = "55";
							dataRow[3] = 5;
							dataRow[9] = Convert.ToInt32(dataSet6.Tables[0].Rows[k]["CompId"]);
							num20 = Convert.ToDouble(decimal.Parse((num19 * 0.6 + num17 * 0.4).ToString()).ToString("N3"));
							dataRow[11] = Convert.ToDouble(decimal.Parse((num20 / num2).ToString()).ToString("N3"));
							dataRow[12] = Math.Round(num19 / num2);
						}
						dataRow[8] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				DataSet dataSet7 = new VendorRating();
				dataSet7.Tables[0].Merge(dataTable);
				dataSet7.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/OverallRating.rpt"));
				cryRpt.SetDataSource(dataSet7);
				string text4 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text4);
				cryRpt.SetParameterValue("ManfDesc", (object)text2);
				cryRpt.SetParameterValue("ItemCode", (object)text);
				cryRpt.SetParameterValue("UOM", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
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
		cryRpt = new ReportDocument();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("VendorRating.aspx");
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

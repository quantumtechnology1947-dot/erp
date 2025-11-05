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

public class Module_Inventory_Transactions_GoodsServiceNote_SN_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected CrystalReportSource CrystalReportSource1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt = new ReportDocument();

	private string poNo = "";

	private string GINNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string GSNNo = "";

	private string connStr = "";

	private SqlConnection con;

	private string MId = "";

	private string GINId = "";

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_117f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			try
			{
				GSNNo = base.Request.QueryString["GSNNo"].ToString();
				GINNo = base.Request.QueryString["GINNo"].ToString();
				poNo = base.Request.QueryString["PONo"].ToString();
				FyId = base.Request.QueryString["FyId"].ToString();
				sId = Session["username"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				MId = base.Request.QueryString["Id"].ToString();
				GINId = base.Request.QueryString["GINId"].ToString();
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				string cmdText = fun.select("tblinv_MaterialServiceNote_Details.Id,tblinv_MaterialServiceNote_Details.POId,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo='" + GSNNo + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				con.Open();
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("InvQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("TotRecedQty", typeof(string)));
				string value = "";
				string value2 = "";
				string value3 = "";
				string text = "";
				string text2 = "";
				int num = 0;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + GINId + "' AND tblInv_Inward_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					text = dataSet3.Tables[0].Rows[0]["ChallanNo"].ToString();
					text2 = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["ChallanDate"].ToString());
					string cmdText3 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.SupplierId,tblMM_PO_Master.FinYearId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo='" + dataSet3.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND  tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.Id='" + dataSet3.Tables[0].Rows[0]["POId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					SupplierNo = dataSet4.Tables[0].Rows[0]["SupplierId"].ToString();
					if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText4 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet4.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet4.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							string cmdText5 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet5.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter5.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ItemId"].ToString()));
								value2 = dataSet6.Tables[0].Rows[0]["ManfDesc"].ToString();
								string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet6.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
								DataSet dataSet7 = new DataSet();
								sqlDataAdapter6.Fill(dataSet7);
								if (dataSet7.Tables[0].Rows.Count > 0)
								{
									value3 = dataSet7.Tables[0].Rows[0][0].ToString();
								}
							}
						}
					}
					else if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
					{
						string cmdText7 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet4.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet4.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter7.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							string cmdText8 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet8.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter8.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["ItemId"].ToString()));
								value2 = dataSet9.Tables[0].Rows[0]["ManfDesc"].ToString();
								string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet9.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
								DataSet dataSet10 = new DataSet();
								sqlDataAdapter9.Fill(dataSet10);
								if (dataSet10.Tables[0].Rows.Count > 0)
								{
									value3 = dataSet10.Tables[0].Rows[0][0].ToString();
								}
							}
						}
					}
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow[1] = value;
					dataRow[2] = value2;
					dataRow[3] = value3;
					if (dataSet4.Tables[0].Rows[0]["Qty"].ToString() == "")
					{
						dataRow[4] = "0";
					}
					else
					{
						dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
					}
					if (dataSet3.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
					{
						dataRow[5] = "0";
					}
					else
					{
						dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
					}
					if (dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")
					{
						dataRow[6] = "0";
					}
					else
					{
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString()).ToString("N3"));
					}
					dataRow[7] = CompId;
					num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]);
					dataRow[8] = num;
					string cmdText10 = fun.select("sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'  AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "'");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter10.Fill(dataSet11);
					if (dataSet11.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
					{
						dataRow[9] = decimal.Parse(dataSet11.Tables[0].Rows[0]["sum_ReceivedQty"].ToString()).ToString("N3");
					}
					else
					{
						dataRow[9] = "0";
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet12 = new GSN();
				dataSet12.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet12.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/GoodsServiceNote.rpt"));
				cryRpt.SetDataSource(dataSet12);
				string cmdText11 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "'");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, con);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter11.Fill(dataSet13);
				if (dataSet13.Tables[0].Rows.Count > 0)
				{
					string text3 = dataSet13.Tables[0].Rows[0][0].ToString();
					cryRpt.SetParameterValue("SupplierName", (object)text3);
				}
				cryRpt.SetParameterValue("ChallanNo", (object)text);
				cryRpt.SetParameterValue("ChallanDate", (object)text2);
				cryRpt.SetParameterValue("GSNNO", (object)GSNNo);
				cryRpt.SetParameterValue("GINNO", (object)GINNo);
				string text4 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text4);
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
				dataSet.Dispose();
				dataTable.Dispose();
				dataSet2.Dispose();
				con.Close();
				con.Dispose();
			}
		}
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsServiceNote_SN_Print.aspx?ModId=9&SubModId=39");
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Inventory_Transactions_GoodsRejection_GRN_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt = new ReportDocument();

	private string poNo = "";

	private string GINNo = "";

	private string GQNNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string GRRNo = "";

	private string Id = "";

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected CrystalReportSource CrystalReportSource1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1390: Unknown result type (might be due to invalid IL or missing references)
		//IL_1397: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			try
			{
				GRRNo = base.Request.QueryString["GRRNo"].ToString();
				GINNo = base.Request.QueryString["GINNo"].ToString();
				poNo = base.Request.QueryString["PONo"].ToString();
				FyId = base.Request.QueryString["FyId"].ToString();
				sId = Session["username"].ToString();
				Id = base.Request.QueryString["Id"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				string cmdText = fun.select("Id,FinYearId,GQNNo,GRRNo,SysDate", "tblQc_MaterialQuality_Master", "CompId='" + CompId + "' And Id='" + Id + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblQc_MaterialQuality_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					GQNNo = dataSet.Tables[0].Rows[0]["GQNNo"].ToString();
				}
				string cmdText2 = fun.select("tblQc_MaterialQuality_Details.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.RejectionReason,tblQc_MaterialQuality_Details.Remarks,tblQc_MaterialQuality_Master.GRRNo,tblQc_MaterialQuality_Master.GRRId,tblQc_MaterialQuality_Details.GRRId as DGRRId,tblQc_MaterialQuality_Master.FinYearId", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id='" + Id + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId  AND tblQc_MaterialQuality_Details.RejectedQty > 0");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
				dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("InvQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RejReason", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RejectedQty", typeof(double)));
				string text = "";
				string text2 = "";
				string text3 = "";
				DataSet dataSet3 = new DataSet();
				string text4 = "";
				string text5 = "";
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText3 = fun.select("tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId,tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Details.POId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.Id='" + dataSet2.Tables[0].Rows[i]["GRRId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.Id='" + dataSet2.Tables[0].Rows[i]["DGRRId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					string cmdText4 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblInv_Inward_Details.ReceivedQty", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + dataSet4.Tables[0].Rows[0]["GINId"].ToString() + "' AND tblInv_Inward_Details.POId='" + dataSet4.Tables[0].Rows[0]["POId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5);
					text4 = dataSet5.Tables[0].Rows[0]["ChallanNo"].ToString();
					text5 = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["ChallanDate"].ToString());
					if (dataSet5.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					string cmdText5 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId,tblMM_PO_Master.SupplierId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet5.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.Id='" + dataSet5.Tables[0].Rows[0]["POId"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					SupplierNo = dataSet6.Tables[0].Rows[0]["SupplierId"].ToString();
					if (dataSet6.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText6 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + dataSet6.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet6.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter6.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0)
						{
							string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet7.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter7.Fill(dataSet8);
							if (dataSet8.Tables[0].Rows.Count > 0)
							{
								text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet7.Tables[0].Rows[0]["ItemId"].ToString()));
								text3 = dataSet8.Tables[0].Rows[0]["ManfDesc"].ToString();
								string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet8.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
								DataSet dataSet9 = new DataSet();
								sqlDataAdapter8.Fill(dataSet9);
								if (dataSet9.Tables[0].Rows.Count > 0)
								{
									text2 = dataSet9.Tables[0].Rows[0][0].ToString();
								}
							}
						}
					}
					else if (dataSet6.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
					{
						string cmdText9 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + dataSet6.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet6.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
						SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet10 = new DataSet();
						sqlDataAdapter9.Fill(dataSet10);
						if (dataSet10.Tables[0].Rows.Count > 0)
						{
							string cmdText10 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet10.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
							DataSet dataSet11 = new DataSet();
							sqlDataAdapter10.Fill(dataSet11);
							if (dataSet11.Tables[0].Rows.Count > 0)
							{
								text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["ItemId"].ToString()));
								text3 = dataSet11.Tables[0].Rows[0]["ManfDesc"].ToString();
								string cmdText11 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet11.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
								SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
								DataSet dataSet12 = new DataSet();
								sqlDataAdapter11.Fill(dataSet12);
								if (dataSet12.Tables[0].Rows.Count > 0)
								{
									text2 = dataSet12.Tables[0].Rows[0][0].ToString();
								}
							}
						}
					}
					if (dataSet6.Tables[0].Rows[0]["Qty"].ToString() == "")
					{
						dataRow[4] = "0";
					}
					else
					{
						dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
					}
					if (dataSet5.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
					{
						dataRow[5] = "0";
					}
					else
					{
						dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
					}
					if (dataSet4.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
					{
						dataRow[6] = "0";
					}
					else
					{
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
					}
					if (dataSet2.Tables[0].Rows[i]["AcceptedQty"].ToString() == "")
					{
						dataRow[8] = "0";
					}
					else
					{
						dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["AcceptedQty"].ToString()).ToString("N3"));
					}
					string cmdText12 = fun.select("Symbol", "tblQc_Rejection_Reason", "Id='" + dataSet2.Tables[0].Rows[i]["RejectionReason"].ToString() + "'");
					SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					DataSet dataSet13 = new DataSet();
					sqlDataAdapter12.Fill(dataSet13);
					if (dataSet13.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet13.Tables[0].Rows[0]["Symbol"].ToString();
					}
					dataRow[10] = dataSet2.Tables[0].Rows[i]["Remarks"].ToString();
					if (dataSet2.Tables[0].Rows[i]["RejectedQty"].ToString() == "0")
					{
						dataRow[11] = "0";
					}
					else
					{
						dataRow[11] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["RejectedQty"].ToString()).ToString("N3"));
					}
					dataRow[7] = CompId;
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					dataRow[1] = text.ToString();
					dataRow[2] = text3.ToString();
					dataRow[3] = text2.ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet3.Tables.Add(dataTable);
				DataSet dataSet14 = new GRN();
				dataSet14.Tables[0].Merge(dataSet3.Tables[0]);
				dataSet14.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/QualityControl/Transactions/Reports/GRN.rpt"));
				cryRpt.SetDataSource(dataSet14);
				string cmdText13 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet15 = new DataSet();
				sqlDataAdapter13.Fill(dataSet15);
				string text6 = "";
				text6 = dataSet15.Tables[0].Rows[0][0].ToString();
				cryRpt.SetParameterValue("SupplierName", (object)text6);
				cryRpt.SetParameterValue("ChallanNo", (object)text4);
				cryRpt.SetParameterValue("ChallanDate", (object)text5);
				cryRpt.SetParameterValue("GRRNO", (object)GRRNo);
				cryRpt.SetParameterValue("GINNO", (object)GINNo);
				cryRpt.SetParameterValue("GQNNO", (object)GQNNo);
				string text7 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text7);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session["ReportDocument"] = cryRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsRejection_GRN.aspx?ModId=10&SubModId=");
	}
}

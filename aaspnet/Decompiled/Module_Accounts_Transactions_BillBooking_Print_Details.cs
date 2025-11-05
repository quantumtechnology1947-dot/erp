using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_BillBooking_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private int Mid;

	private string address = "";

	private ReportDocument cryRpt = new ReportDocument();

	private string Type = "";

	private string Payterms = "";

	private int pageFlag;

	private string sessKey = string.Empty;

	private string key = string.Empty;

	private string SupId = string.Empty;

	private string lnkFor = string.Empty;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected TabPanel View;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected TabPanel Annexures;

	protected TabContainer TabContainer1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_33a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ab: Expected O, but got Unknown
		//IL_3037: Unknown result type (might be due to invalid IL or missing references)
		//IL_3041: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			DataSet dataSet = new DataSet();
			sqlConnection.Open();
			if (!base.IsPostBack)
			{
				sId = Session["username"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				Mid = Convert.ToInt32(base.Request.QueryString["Id"]);
				string cmdText = fun.select("tblACC_BillBooking_Master.Id ,tblACC_BillBooking_Master.TDSCode,tblACC_BillBooking_Master.SessionId ,tblACC_BillBooking_Master.AuthorizeBy,tblACC_BillBooking_Master.AuthorizeDate, tblACC_BillBooking_Master.SysDate , tblACC_BillBooking_Master.SysTime  , tblACC_BillBooking_Master.SessionId, tblACC_BillBooking_Master.CompId , tblACC_BillBooking_Master.FinYearId, tblACC_BillBooking_Master.PVEVNo, tblACC_BillBooking_Master.SupplierId , tblACC_BillBooking_Details.PODId, tblACC_BillBooking_Master.BillNo, tblACC_BillBooking_Master.BillDate , tblACC_BillBooking_Master.CENVATEntryNo, tblACC_BillBooking_Master.CENVATEntryDate, tblACC_BillBooking_Master.OtherCharges, tblACC_BillBooking_Master.OtherChaDesc, tblACC_BillBooking_Master.Narration , tblACC_BillBooking_Master.DebitAmt , tblACC_BillBooking_Master.DiscountType, tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Details.GQNId,tblACC_BillBooking_Details.GSNId, tblACC_BillBooking_Details.ItemId,tblACC_BillBooking_Details.PFAmt,tblACC_BillBooking_Details.ExStBasicInPer ,tblACC_BillBooking_Details.ExStEducessInPer ,tblACC_BillBooking_Details.ExStShecessInPer,tblACC_BillBooking_Details.ExStBasic ,tblACC_BillBooking_Details.ExStEducess ,tblACC_BillBooking_Details.ExStShecess ,tblACC_BillBooking_Details.CustomDuty ,tblACC_BillBooking_Details.VAT ,tblACC_BillBooking_Details.CST ,tblACC_BillBooking_Details.Freight ,tblACC_BillBooking_Details.TarrifNo,tblACC_BillBooking_Details.DebitType,tblACC_BillBooking_Details.DebitValue,tblACC_BillBooking_Details.BCDOpt,tblACC_BillBooking_Details.BCD,tblACC_BillBooking_Details.BCDValue,tblACC_BillBooking_Details.ValueForCVD,tblACC_BillBooking_Details.ValueForEdCessCD,tblACC_BillBooking_Details.EdCessOnCDOpt,tblACC_BillBooking_Details.EdCessOnCD,tblACC_BillBooking_Details.EdCessOnCDValue,tblACC_BillBooking_Details.SHEDCessOpt,tblACC_BillBooking_Details.SHEDCess,tblACC_BillBooking_Details.SHEDCessValue,tblACC_BillBooking_Details.TotDuty,tblACC_BillBooking_Details.TotDutyEDSHED,tblACC_BillBooking_Details.Insurance,tblACC_BillBooking_Details.ValueWithDuty", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", "tblACC_BillBooking_Master.CompId='" + CompId + "'  And tblACC_BillBooking_Master.Id='" + Mid + "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Descr", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExStBasicInPer", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExStEducessInPer", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExStShecessInPer", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExStBasic", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExStEducess", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExStShecess", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CustomDuty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("VAT", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CST", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TarrifNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
				dataTable.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
				dataTable.Columns.Add(new DataColumn("OtherChaDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Narration", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DebitAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DiscountType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CENVATEntryNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CENVATEntryDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AccHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WODept", typeof(string)));
				dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PORate", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Disc", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AccQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFTerm", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExciseTerm", typeof(string)));
				dataTable.Columns.Add(new DataColumn("VATTerm", typeof(string)));
				dataTable.Columns.Add(new DataColumn("IsVATCST", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DebitType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("DebitValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFid", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ExciseId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("VATCSTid", typeof(int)));
				dataTable.Columns.Add(new DataColumn("BasicAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("BCDOpt", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BCD", typeof(double)));
				dataTable.Columns.Add(new DataColumn("BCDValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ValueForCVD", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ValueForEdCessCD", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EdCessOnCDOpt", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EdCessOnCD", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EdCessOnCDValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SHEDCessOpt", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SHEDCess", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SHEDCessValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TotDuty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TotDutyEDSHED", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Insurance", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ValueWithDuty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SectionNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TDSPerCentage", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PaymentRange", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TDSCode", typeof(int)));
				dataTable.Columns.Add(new DataColumn("BookedBillTotal", typeof(double)));
				DataSet dataSet2 = new DataSet();
				string text = string.Empty;
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						double num = 0.0;
						double num2 = 0.0;
						double num3 = 0.0;
						string value = "";
						string value2 = "";
						text = text + "'" + dataSet.Tables[0].Rows[i]["PODId"].ToString() + "',";
						string cmdText2 = fun.select("tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["PODId"].ToString() + "' AND   tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + CompId + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							num3 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
							num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
							if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
							{
								string cmdText3 = fun.select("tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet3.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet3.Tables[0].Rows[0]["PRId"].ToString() + "'");
								SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
								SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
								DataSet dataSet4 = new DataSet();
								sqlDataAdapter3.Fill(dataSet4);
								if (dataSet4.Tables[0].Rows.Count > 0)
								{
									string cmdText4 = fun.select("Symbol AS AccHead", "AccHead", "Id ='" + dataSet4.Tables[0].Rows[0]["AHId"].ToString() + "' ");
									SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
									SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
									DataSet dataSet5 = new DataSet();
									sqlDataAdapter4.Fill(dataSet5);
									if (dataSet5.Tables[0].Rows.Count > 0)
									{
										value2 = dataSet5.Tables[0].Rows[0]["AccHead"].ToString();
									}
									value = dataSet4.Tables[0].Rows[0]["WONo"].ToString();
								}
							}
							else if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
							{
								string cmdText5 = fun.select("tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet3.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet3.Tables[0].Rows[0]["SPRId"].ToString() + "'");
								SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
								DataSet dataSet6 = new DataSet();
								sqlDataAdapter5.Fill(dataSet6);
								if (dataSet6.Tables[0].Rows.Count > 0)
								{
									string cmdText6 = fun.select("Symbol AS AccHead", "AccHead", "Id ='" + dataSet6.Tables[0].Rows[0]["AHId"].ToString() + "' ");
									SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
									SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
									DataSet dataSet7 = new DataSet();
									sqlDataAdapter6.Fill(dataSet7);
									if (dataSet7.Tables[0].Rows.Count > 0)
									{
										value2 = dataSet7.Tables[0].Rows[0]["AccHead"].ToString();
									}
									if (dataSet6.Tables[0].Rows[0]["DeptId"].ToString() == "0")
									{
										value = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
									}
									else
									{
										string cmdText7 = fun.select("Symbol AS Dept", "tblHR_Departments", "Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
										SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
										SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
										DataSet dataSet8 = new DataSet();
										sqlDataAdapter7.Fill(dataSet8);
										if (dataSet8.Tables[0].Rows.Count > 0)
										{
											value = dataSet8.Tables[0].Rows[0]["Dept"].ToString();
										}
									}
								}
							}
							string cmdText8 = fun.select("Terms,Id", "tblPacking_Master", "Id='" + dataSet3.Tables[0].Rows[0]["PF"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter8.Fill(dataSet9, "tblPacking_Master");
							dataRow[43] = dataSet9.Tables[0].Rows[0]["Terms"].ToString();
							dataRow[49] = Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Id"]);
							string cmdText9 = fun.select("Terms,Id", "tblExciseser_Master", "Id='" + dataSet3.Tables[0].Rows[0]["ExST"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet10 = new DataSet();
							sqlDataAdapter9.Fill(dataSet10, "tblExciseser_Master");
							dataRow[44] = dataSet10.Tables[0].Rows[0]["Terms"].ToString();
							dataRow[50] = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["Id"]);
							string cmdText10 = fun.select("Terms,IsVAT,IsCST,Id", "tblVAT_Master", "Id='" + dataSet3.Tables[0].Rows[0]["VAT"].ToString() + "'");
							SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
							DataSet dataSet11 = new DataSet();
							sqlDataAdapter10.Fill(dataSet11, "tblVAT_Master");
							dataRow[45] = dataSet11.Tables[0].Rows[0]["Terms"].ToString();
							dataRow[51] = Convert.ToInt32(dataSet11.Tables[0].Rows[0]["Id"]);
							if (dataSet11.Tables[0].Rows[0]["IsVAT"].ToString() == "1")
							{
								dataRow[46] = "VAT";
							}
							else if (dataSet11.Tables[0].Rows[0]["IsCST"].ToString() == "1")
							{
								dataRow[46] = "CST";
							}
							if (dataSet11.Tables[0].Rows[0]["IsVAT"].ToString() == "0" && dataSet11.Tables[0].Rows[0]["IsCST"].ToString() == "0")
							{
								dataRow[46] = "VAT/CST";
							}
						}
						if (dataSet.Tables[0].Rows[i]["GQNId"].ToString() != "0")
						{
							string cmdText11 = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + dataSet.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
							SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
							SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
							DataSet dataSet12 = new DataSet();
							sqlDataAdapter11.Fill(dataSet12);
							if (dataSet12.Tables[0].Rows.Count > 0)
							{
								dataRow[1] = dataSet12.Tables[0].Rows[0]["GQNNo"].ToString();
								double num4 = 0.0;
								num4 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["AcceptedQty"]);
								num2 = (num3 - num3 * num / 100.0) * num4;
								dataRow[42] = num4;
							}
							else
							{
								dataRow[1] = "";
							}
						}
						else if (dataSet.Tables[0].Rows[i]["GSNId"].ToString() != "0")
						{
							string cmdText12 = fun.select("tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + dataSet.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
							SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
							SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
							DataSet dataSet13 = new DataSet();
							sqlDataAdapter12.Fill(dataSet13);
							if (dataSet13.Tables[0].Rows.Count > 0)
							{
								dataRow[1] = dataSet13.Tables[0].Rows[0]["GSNNo"].ToString();
								double num5 = 0.0;
								num5 = Convert.ToDouble(dataSet13.Tables[0].Rows[0]["ReceivedQty"]);
								num2 = (num3 - num3 * num / 100.0) * num5;
								dataRow[42] = num5;
							}
							else
							{
								dataRow[1] = "";
							}
						}
						dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
						string cmdText13 = fun.select("ItemCode,ManfDesc As Descr,UOMBasic ", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
						SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
						SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
						DataSet dataSet14 = new DataSet();
						sqlDataAdapter13.Fill(dataSet14);
						if (dataSet14.Tables[0].Rows.Count > 0)
						{
							dataRow[3] = dataSet14.Tables[0].Rows[0]["ItemCode"].ToString();
							dataRow[4] = dataSet14.Tables[0].Rows[0]["Descr"].ToString();
							string cmdText14 = fun.select("Symbol As UOM ", "Unit_Master", "Id='" + dataSet14.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
							SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
							SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
							DataSet dataSet15 = new DataSet();
							sqlDataAdapter14.Fill(dataSet15);
							if (dataSet15.Tables[0].Rows.Count > 0)
							{
								dataRow[5] = dataSet15.Tables[0].Rows[0][0].ToString();
							}
						}
						dataRow[6] = num2;
						dataRow[7] = dataSet.Tables[0].Rows[i]["PFAmt"].ToString();
						dataRow[8] = dataSet.Tables[0].Rows[i]["ExStBasicInPer"].ToString();
						dataRow[9] = dataSet.Tables[0].Rows[i]["ExStEducessInPer"].ToString();
						dataRow[10] = dataSet.Tables[0].Rows[i]["ExStShecessInPer"].ToString();
						dataRow[11] = dataSet.Tables[0].Rows[i]["ExStBasic"].ToString();
						dataRow[12] = dataSet.Tables[0].Rows[i]["ExStEducess"].ToString();
						dataRow[13] = dataSet.Tables[0].Rows[i]["ExStShecess"].ToString();
						dataRow[14] = dataSet.Tables[0].Rows[i]["CustomDuty"].ToString();
						dataRow[15] = dataSet.Tables[0].Rows[i]["VAT"].ToString();
						dataRow[16] = dataSet.Tables[0].Rows[i]["CST"].ToString();
						dataRow[17] = dataSet.Tables[0].Rows[i]["Freight"].ToString();
						dataRow[18] = dataSet.Tables[0].Rows[i]["TarrifNo"].ToString();
						string cmdText15 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' And CompId='" + CompId + "'");
						SqlCommand selectCommand15 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
						DataSet dataSet16 = new DataSet();
						sqlDataAdapter15.Fill(dataSet16);
						dataRow[19] = dataSet16.Tables[0].Rows[0]["FinYear"].ToString();
						dataRow[20] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
						dataRow[21] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
						string cmdText16 = fun.select("tblMM_PO_Master.PONo,tblMM_PO_Master.PaymentTerms,tblMM_PO_Master.SysDate As PODate", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + CompId + "' And tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["PODId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
						SqlCommand selectCommand16 = new SqlCommand(cmdText16, sqlConnection);
						SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
						DataSet dataSet17 = new DataSet();
						sqlDataAdapter16.Fill(dataSet17);
						if (dataSet17.Tables[0].Rows.Count > 0)
						{
							dataRow[22] = dataSet17.Tables[0].Rows[0]["PONo"].ToString();
							dataRow[23] = fun.FromDateDMY(dataSet17.Tables[0].Rows[0]["PODate"].ToString());
						}
						string cmdText17 = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand17 = new SqlCommand(cmdText17, sqlConnection);
						SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
						DataSet dataSet18 = new DataSet();
						sqlDataAdapter17.Fill(dataSet18);
						string input = string.Empty;
						if (dataSet18.Tables[0].Rows.Count > 0)
						{
							dataRow[24] = dataSet18.Tables[0].Rows[0]["SupplierName"].ToString();
							string cmdText18 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet18.Tables[0].Rows[0]["RegdCountry"], "'"));
							SqlCommand selectCommand18 = new SqlCommand(cmdText18, sqlConnection);
							SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
							DataSet dataSet19 = new DataSet();
							sqlDataAdapter18.Fill(dataSet19, "tblCountry");
							string cmdText19 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet18.Tables[0].Rows[0]["RegdState"], "'"));
							SqlCommand selectCommand19 = new SqlCommand(cmdText19, sqlConnection);
							SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
							DataSet dataSet20 = new DataSet();
							sqlDataAdapter19.Fill(dataSet20, "tblState");
							string cmdText20 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet18.Tables[0].Rows[0]["RegdCity"], "'"));
							SqlCommand selectCommand20 = new SqlCommand(cmdText20, sqlConnection);
							SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
							DataSet dataSet21 = new DataSet();
							sqlDataAdapter20.Fill(dataSet21, "tblcity");
							address = dataSet18.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + dataSet21.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet20.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet19.Tables[0].Rows[0]["CountryName"].ToString() + ".\n" + dataSet18.Tables[0].Rows[0]["RegdPinNo"].ToString() + ".\n";
							input = dataSet18.Tables[0].Rows[0]["PanNo"].ToString();
						}
						string cmdText21 = fun.select("Terms", "tblPayment_Master", "Id='" + dataSet17.Tables[0].Rows[0]["PaymentTerms"].ToString() + "'");
						SqlCommand selectCommand21 = new SqlCommand(cmdText21, sqlConnection);
						SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
						DataSet dataSet22 = new DataSet();
						sqlDataAdapter21.Fill(dataSet22);
						Payterms = dataSet22.Tables[0].Rows[0]["Terms"].ToString();
						dataRow[25] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
						dataRow[26] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
						dataRow[27] = dataSet.Tables[0].Rows[i]["OtherCharges"].ToString();
						dataRow[28] = dataSet.Tables[0].Rows[i]["OtherChaDesc"].ToString();
						dataRow[29] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
						double num6 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["DebitAmt"]);
						dataRow[30] = num6;
						dataRow[31] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DiscountType"]);
						double num7 = 0.0;
						switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["DiscountType"]))
						{
						case 0:
							num7 = num2 - num6;
							break;
						case 1:
							num7 = num2 - num2 * num6 / 100.0;
							break;
						case 2:
							num7 = num2;
							break;
						}
						dataRow[52] = num7;
						int num8 = 0;
						switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["DiscountType"]))
						{
						case 0:
							Type = "In Amt";
							break;
						case 1:
							Type = "In Percent";
							break;
						}
						dataRow[32] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
						dataRow[33] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
						dataRow[34] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
						dataRow[35] = dataSet.Tables[0].Rows[i]["CENVATEntryNo"].ToString();
						dataRow[36] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CENVATEntryDate"].ToString());
						dataRow[37] = value2;
						dataRow[38] = value;
						dataRow[39] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
						dataRow[40] = num3;
						dataRow[41] = num;
						dataRow[47] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["DebitType"]);
						dataRow[48] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["DebitValue"]);
						if (dataSet.Tables[0].Rows[i]["BCDOpt"].ToString() == "1")
						{
							dataRow[53] = "Amt";
						}
						else if (dataSet.Tables[0].Rows[i]["BCDOpt"].ToString() == "2")
						{
							dataRow[53] = "%";
						}
						dataRow[54] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["BCD"]);
						dataRow[55] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["BCDValue"]);
						dataRow[56] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["ValueForCVD"]);
						dataRow[57] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["ValueForEdCessCD"]);
						if (dataSet.Tables[0].Rows[i]["EdCessOnCDOpt"].ToString() == "1")
						{
							dataRow[58] = "Amt";
						}
						else if (dataSet.Tables[0].Rows[i]["EdCessOnCDOpt"].ToString() == "2")
						{
							dataRow[58] = "%";
						}
						dataRow[59] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["EdCessOnCD"]);
						dataRow[60] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["EdCessOnCDValue"]);
						if (dataSet.Tables[0].Rows[i]["SHEDCessOpt"].ToString() == "1")
						{
							dataRow[61] = "Amt";
						}
						else if (dataSet.Tables[0].Rows[i]["SHEDCessOpt"].ToString() == "2")
						{
							dataRow[61] = "%";
						}
						dataRow[62] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["SHEDCess"]);
						dataRow[63] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["SHEDCessValue"]);
						dataRow[64] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["TotDuty"]);
						dataRow[65] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["TotDutyEDSHED"]);
						dataRow[66] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Insurance"]);
						dataRow[67] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["ValueWithDuty"]);
						string cmdText22 = fun.select("*", "tblACC_TDSCode_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["TDSCode"]) + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText22, sqlConnection);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						sqlDataReader.Read();
						double num9 = 0.0;
						if (sqlDataReader.HasRows)
						{
							dataRow[68] = sqlDataReader["SectionNo"].ToString();
							Regex regex = new Regex("^[a-zA-Z0-9 ]*$");
							if (regex.IsMatch(input))
							{
								dataRow[69] = Convert.ToInt32(sqlDataReader["Others"].ToString());
							}
							else
							{
								dataRow[69] = Convert.ToInt32(sqlDataReader["WithOutPAN"].ToString());
							}
							num9 = Convert.ToDouble(sqlDataReader["PaymentRange"].ToString());
						}
						dataRow[70] = num9;
						dataRow[71] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["TDSCode"]);
						dataRow[72] = fun.Check_TDSAmt(CompId, FinYearId, SupId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["TDSCode"]));
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataTable2.Columns.Add(new DataColumn("Basic", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("PF", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("PFAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("ExSerTax", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("ExSerAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("EDU", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("SHE", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("VATCST", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("VATCSTAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("Freight", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("Total", typeof(double)));
				var enumerable = from p in dataTable.AsEnumerable()
					group p by new
					{
						y = p.Field<int>("PFid"),
						x = p.Field<int>("ExciseId"),
						z = p.Field<int>("VATCSTid")
					} into grp
					let row1 = grp.First()
					select new
					{
						PF = row1.Field<string>("PFTerm"),
						ExSerTax = row1.Field<string>("ExciseTerm"),
						VATCST = row1.Field<string>("VATTerm"),
						Basic = grp.Sum((DataRow r) => r.Field<double>("Amt")),
						PFAmt = grp.Sum((DataRow r) => r.Field<double>("PFAmt")),
						ExSerBasic = grp.Sum((DataRow r) => r.Field<double>("ExStBasic")),
						EDU = grp.Sum((DataRow r) => r.Field<double>("ExStEducess")),
						SHE = grp.Sum((DataRow r) => r.Field<double>("ExStShecess")),
						VAT = grp.Sum((DataRow r) => r.Field<double>("VAT")),
						CST = grp.Sum((DataRow r) => r.Field<double>("CST")),
						Freight = grp.Sum((DataRow r) => r.Field<double>("Freight"))
					};
				foreach (var item in enumerable)
				{
					DataRow dataRow2 = dataTable2.NewRow();
					dataRow2[0] = item.Basic;
					dataRow2[1] = item.PF;
					dataRow2[2] = item.PFAmt;
					dataRow2[3] = item.ExSerTax;
					dataRow2[4] = item.ExSerBasic;
					dataRow2[5] = item.EDU;
					dataRow2[6] = item.SHE;
					dataRow2[7] = item.VATCST;
					dataRow2[8] = item.VAT + item.CST;
					dataRow2[9] = item.Freight;
					dataRow2[10] = item.Basic + item.PFAmt + item.ExSerBasic + item.EDU + item.SHE + item.VAT + item.CST + item.Freight;
					dataTable2.Rows.Add(dataRow2);
					dataTable2.AcceptChanges();
				}
				dataSet2.Tables.Add(dataTable);
				dataSet2.Tables.Add(dataTable2);
				dataSet2.AcceptChanges();
				DataSet dataSet23 = new BillBooking();
				dataSet23.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet23.Tables[1].Merge(dataSet2.Tables[1]);
				dataSet23.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/BillBooking.rpt"));
				cryRpt.SetDataSource(dataSet23);
				cryRpt.SetParameterValue("address", (object)address);
				cryRpt.SetParameterValue("Type", (object)Type);
				cryRpt.SetParameterValue("Terms", (object)Payterms);
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				string cmdText23 = fun.select("Title+' '+EmployeeName As Name", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[0]["SessionId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand22 = new SqlCommand(cmdText23, sqlConnection);
				SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
				DataSet dataSet24 = new DataSet();
				sqlDataAdapter22.Fill(dataSet24);
				if (dataSet24.Tables[0].Rows.Count > 0)
				{
					text2 = dataSet24.Tables[0].Rows[0]["Name"].ToString();
					text3 = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
				}
				string text5 = string.Empty;
				string cmdText24 = fun.select("Title+' '+EmployeeName As Name", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[0]["AuthorizeBy"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand23 = new SqlCommand(cmdText24, sqlConnection);
				SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
				DataSet dataSet25 = new DataSet();
				sqlDataAdapter23.Fill(dataSet25);
				if (dataSet25.Tables[0].Rows.Count > 0)
				{
					text5 = dataSet25.Tables[0].Rows[0]["Name"].ToString();
					text4 = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["AuthorizeDate"].ToString());
				}
				cryRpt.SetParameterValue("PreparedBy", (object)text2);
				cryRpt.SetParameterValue("PreparedDate", (object)text3);
				cryRpt.SetParameterValue("AuthorizeBy", (object)text5);
				cryRpt.SetParameterValue("AuthorizeDate", (object)text4);
				string text6 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text6);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[sessKey] = cryRpt;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[sessKey];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		pageFlag = Convert.ToInt32(base.Request.QueryString["f"]);
		if (!string.IsNullOrEmpty(base.Request.QueryString["Key"]))
		{
			key = base.Request.QueryString["Key"].ToString();
		}
		if (!string.IsNullOrEmpty(base.Request.QueryString["SupId"]))
		{
			SupId = base.Request.QueryString["SupId"].ToString();
		}
		if (!string.IsNullOrEmpty(base.Request.QueryString["lnkFor"]))
		{
			lnkFor = base.Request.QueryString["lnkFor"].ToString();
		}
		cryRpt = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		switch (pageFlag)
		{
		case 1:
			base.Response.Redirect("BillBooking_Print.aspx?ModId=11&SubModId=62");
			break;
		case 2:
			base.Response.Redirect("BillBooking_Authorize.aspx?ModId=11&SubModId=62");
			break;
		case 3:
			base.Response.Redirect("CreditorsDebitors_InDetailList.aspx?SupId=" + SupId + "&ModId=11&SubModId=135&Key=" + key);
			break;
		case 4:
			base.Response.Redirect("SundryCreditors_InDetailList.aspx?SupId=" + SupId + "&ModId=11&SubModId=135&Key=" + key + "&lnkFor=" + lnkFor);
			break;
		}
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

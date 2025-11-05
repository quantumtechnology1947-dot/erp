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

public class Module_Inventory_Transactions_GoodsInwardNote_GIN_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btncancel;

	protected Panel Panel2;

	private string ChNo = "";

	private string GINNo = "";

	private string ChDt = "";

	private string fyid = "";

	private int CompId;

	private string Sid = "";

	private string supId = "";

	private string GINId = "";

	private string SessionFyId = "";

	private clsFunctions fun = new clsFunctions();

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1838: Unknown result type (might be due to invalid IL or missing references)
		//IL_183f: Expected O, but got Unknown
		//IL_13c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			try
			{
				GINId = base.Request.QueryString["Id"].ToString();
				ChNo = base.Request.QueryString["ChNo"].ToString();
				fyid = base.Request.QueryString["fyid"].ToString();
				SessionFyId = Session["finyear"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				Sid = Session["username"].ToString();
				GINNo = base.Request.QueryString["GINo"].ToString();
				ChDt = fun.FromDateDMY(base.Request.QueryString["ChDt"].ToString());
				string cmdText = fun.select("FinYearId", "tblFinancial_master", " FinYear='" + fyid + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				string cmdText2 = fun.select("tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Master.GateEntryNo,tblInv_Inward_Master.GDate,tblInv_Inward_Master.GTime,tblInv_Inward_Master.ModeofTransport,tblInv_Inward_Master.VehicleNo,tblInv_Inward_Master.PONo,tblInv_Inward_Details.Id,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.Qty,tblInv_Inward_Details.ReceivedQty as sum_ReceivedQty,tblInv_Inward_Details.POId,tblInv_Inward_Details.ACategoyId,tblInv_Inward_Details.ASubCategoyId", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.FinYearId<='" + SessionFyId + "' AND tblInv_Inward_Details.GINId='" + GINId + "'  AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				DataTable dataTable = new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("poqty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ChallanQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GateEntryNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ModeofTransport", typeof(string)));
				dataTable.Columns.Add(new DataColumn("VehicleNo", typeof(string)));
				DataSet dataSet3 = new DataSet();
				string value = "";
				string value2 = "";
				string value3 = "";
				double num = 0.0;
				double num2 = 0.0;
				string text = string.Empty;
				string text2 = string.Empty;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText3 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId,tblMM_PO_Master.SupplierId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet2.Tables[0].Rows[i]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.FinYearId<='" + dataSet2.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + dataSet2.Tables[0].Rows[i]["CompId"].ToString() + "' AND tblMM_PO_Details.Id='" + dataSet2.Tables[0].Rows[i]["POId"].ToString() + "'  AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					supId = dataSet4.Tables[0].Rows[0]["SupplierId"].ToString();
					if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText4 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet4.Tables[0].Rows[0]["PRNo"].ToString() + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet4.Tables[0].Rows[0]["PRId"].ToString() + "' And tblMM_PR_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							text = dataSet5.Tables[0].Rows[0]["WONo"].ToString();
							string cmdText5 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", " CompId='" + CompId + "' AND Id='" + dataSet5.Tables[0].Rows[0]["ItemId"].ToString() + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter5.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ItemId"].ToString()));
								value3 = dataSet6.Tables[0].Rows[0]["ManfDesc"].ToString();
								string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet6.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
								DataSet dataSet7 = new DataSet();
								sqlDataAdapter6.Fill(dataSet7);
								if (dataSet7.Tables[0].Rows.Count > 0)
								{
									value2 = dataSet7.Tables[0].Rows[0][0].ToString();
								}
								Convert.ToInt32(dataSet5.Tables[0].Rows[0]["AHId"]);
							}
						}
					}
					else if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
					{
						string cmdText7 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet4.Tables[0].Rows[0]["SPRNo"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet4.Tables[0].Rows[0]["SPRId"].ToString() + "' And tblMM_SPR_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter7.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							string cmdText8 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet8.Tables[0].Rows[0]["ItemId"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter8.Fill(dataSet9);
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["ItemId"].ToString()));
							value3 = dataSet9.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet9.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet10 = new DataSet();
							sqlDataAdapter9.Fill(dataSet10);
							value2 = dataSet10.Tables[0].Rows[0][0].ToString();
							Convert.ToInt32(dataSet8.Tables[0].Rows[0]["AHId"]);
							if (dataSet8.Tables[0].Rows[0]["WONo"] != DBNull.Value && dataSet8.Tables[0].Rows[0]["WONo"].ToString() != string.Empty)
							{
								text = dataSet8.Tables[0].Rows[0]["WONo"].ToString();
							}
							else
							{
								string cmdText10 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet8.Tables[0].Rows[0]["DeptId"].ToString() + "'");
								SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
								DataSet dataSet11 = new DataSet();
								sqlDataAdapter10.Fill(dataSet11);
								if (dataSet11.Tables[0].Rows.Count > 0)
								{
									text2 = dataSet11.Tables[0].Rows[0]["Symbol"].ToString();
								}
							}
						}
					}
					dataRow[0] = value;
					dataRow[1] = value3;
					dataRow[2] = value2;
					num = ((dataSet4.Tables[0].Rows[0]["Qty"] != DBNull.Value) ? Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : 0.0);
					dataRow[3] = dataSet2.Tables[0].Rows[i]["Id"].ToString();
					dataRow[4] = num;
					num2 = ((!(dataSet2.Tables[0].Rows[i]["sum_ReceivedQty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["sum_ReceivedQty"].ToString()).ToString("N3")) : 0.0);
					dataRow[5] = num2;
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
					dataRow[7] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					dataRow[8] = dataSet2.Tables[0].Rows[i]["GateEntryNo"].ToString();
					dataRow[9] = fun.FromDate(dataSet2.Tables[0].Rows[i]["GDate"].ToString());
					dataRow[10] = dataSet2.Tables[0].Rows[i]["GTime"].ToString();
					dataRow[11] = dataSet2.Tables[0].Rows[i]["ModeofTransport"].ToString();
					dataRow[12] = dataSet2.Tables[0].Rows[i]["VehicleNo"].ToString();
					string cmdText11 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet2.Tables[0].Rows[i]["CompId"], "' And FinYearId='", dataSet2.Tables[0].Rows[i]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter11.Fill(dataSet12, "Financial");
					if (dataSet12.Tables[0].Rows.Count > 0)
					{
						string fDY = dataSet12.Tables[0].Rows[0]["FinYearFrom"].ToString();
						string text3 = fun.FromDateYear(fDY);
						string text4 = text3.Substring(2);
						string tDY = dataSet12.Tables[0].Rows[0]["FinYearTo"].ToString();
						string text5 = fun.ToDateYear(tDY);
						string text6 = text5.Substring(2);
						_ = text4 + text6;
					}
					_ = string.Empty;
					if (dataSet2.Tables[0].Rows[i]["ACategoyId"].ToString() != "0" && dataSet2.Tables[0].Rows[i]["ACategoyId"] != DBNull.Value)
					{
						string cmdText12 = "select Abbrivation from tblACC_Asset_Category where Id='" + dataSet2.Tables[0].Rows[i]["ACategoyId"].ToString() + "'";
						SqlCommand sqlCommand = new SqlCommand(cmdText12, sqlConnection);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							if (sqlDataReader.HasRows)
							{
								sqlDataReader["Abbrivation"].ToString();
							}
						}
					}
					_ = string.Empty;
					if (dataSet2.Tables[0].Rows[i]["ASubCategoyId"].ToString() != "0" && dataSet2.Tables[0].Rows[i]["ASubCategoyId"] != DBNull.Value)
					{
						string cmdText13 = "select Abbrivation from tblACC_Asset_SubCategory where Id='" + dataSet2.Tables[0].Rows[i]["ASubCategoyId"].ToString() + "'";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText13, sqlConnection);
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						while (sqlDataReader2.Read())
						{
							if (sqlDataReader2.HasRows)
							{
								sqlDataReader2["Abbrivation"].ToString();
							}
						}
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet3.Tables.Add(dataTable);
				dataSet3.AcceptChanges();
				DataSet dataSet13 = new GIN();
				dataSet13.Tables[0].Merge(dataSet3.Tables[0]);
				dataSet13.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/GIN_Print.rpt"));
				cryRpt.SetDataSource(dataSet13);
				string cmdText14 = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + supId + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand12 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter12.Fill(dataSet14);
				if (dataSet14.Tables[0].Rows.Count > 0)
				{
					string text7 = dataSet14.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet14.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
					cryRpt.SetParameterValue("SupplierName", (object)text7);
					string text8 = dataSet14.Tables[0].Rows[0]["RegdAddress"].ToString();
					string cmdText15 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet14.Tables[0].Rows[0]["RegdCountry"], "'"));
					string cmdText16 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet14.Tables[0].Rows[0]["RegdState"], "'"));
					string cmdText17 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet14.Tables[0].Rows[0]["RegdCity"], "'"));
					SqlCommand selectCommand13 = new SqlCommand(cmdText15, sqlConnection);
					SqlCommand selectCommand14 = new SqlCommand(cmdText16, sqlConnection);
					SqlCommand selectCommand15 = new SqlCommand(cmdText17, sqlConnection);
					SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
					SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
					SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
					DataSet dataSet15 = new DataSet();
					DataSet dataSet16 = new DataSet();
					DataSet dataSet17 = new DataSet();
					sqlDataAdapter13.Fill(dataSet15, "tblCountry");
					sqlDataAdapter14.Fill(dataSet16, "tblState");
					sqlDataAdapter15.Fill(dataSet17, "tblcity");
					string text9 = text8 + ", " + dataSet17.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet16.Tables[0].Rows[0]["StateName"].ToString() + ", " + dataSet15.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("SupplierAdd", (object)text9);
				}
				string text10 = fun.FromDateDMY(ChDt);
				cryRpt.SetParameterValue("ChallanDate", (object)text10);
				cryRpt.SetParameterValue("GINNO", (object)GINNo);
				cryRpt.SetParameterValue("ChallanNo", (object)ChNo);
				cryRpt.SetParameterValue("WONO", (object)text);
				cryRpt.SetParameterValue("Dept", (object)text2);
				string text11 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text11);
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

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/GoodsInwardNote_GIN_Print.aspx?ModId=9&SubModId=37", endResponse: false);
	}
}

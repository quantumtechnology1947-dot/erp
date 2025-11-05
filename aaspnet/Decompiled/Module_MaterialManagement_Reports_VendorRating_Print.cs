using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Reports_VendorRating_Print : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource VendorRating;

	protected Panel plnOR;

	protected TabPanel ORTab;

	protected CrystalReportViewer CrystalReportViewer2;

	protected CrystalReportSource VendorRatingQual;

	protected Panel Panel1;

	protected TabPanel TabPanel2;

	protected CrystalReportViewer CrystalReportViewer3;

	protected CrystalReportSource VendorRatingDelv;

	protected Panel Panel2;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

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
		//IL_1e51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e58: Expected O, but got Unknown
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		SId = Session["username"].ToString();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SupplId = base.Request.QueryString["SupCode"];
		Fd = base.Request.QueryString["FD"];
		Td = base.Request.QueryString["TD"];
		Key = base.Request.QueryString["Key"].ToString();
		switch (base.Request.QueryString["Val"])
		{
		case "Select":
			x = "";
			break;
		case "WOItems":
			x = " And CId is NULL";
			break;
		case "BoughtOut":
			x = " And CId is not NULL";
			break;
		}
		if (!base.IsPostBack)
		{
			DataSet dataSet = new DataSet();
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
				double num = 0.0;
				string cmdText = "Select tblMM_PO_Master.Id, tblMM_PO_Master.PRSPRFlag, tblMM_PO_Master.SupplierId, tblMM_PO_Details.PONo, tblMM_PO_Details.PRNo, tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo, tblMM_PO_Details.SPRId from tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId And  tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.SupplierId='" + SupplId + "'And tblMM_PO_Master.Authorize=1  And tblMM_PO_Details.DelDate  between '" + fun.FromDate(Fd) + "' And '" + fun.FromDate(Td) + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					DateTime dateTime = default(DateTime);
					DateTime dateTime2 = default(DateTime);
					TimeSpan timeSpan = default(TimeSpan);
					DateTime dateTime3 = default(DateTime);
					int num9 = 0;
					double num10 = 0.0;
					double num11 = 0.0;
					if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.Id,tblMM_PR_Master.PRNo", "tblMM_PR_Master,tblMM_PR_Details", string.Concat(" tblMM_PR_Details.Id='", dataSet.Tables[0].Rows[i]["PRId"], "' AND tblMM_PR_Master.CompId='", CompId, "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.FinYearId='", FinYearId, "' "));
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
						{
							DataRow dataRow = dataTable.NewRow();
							string text4 = "";
							text4 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", " CompId='" + CompId + "' And Id='" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "' " + x);
							SqlCommand selectCommand3 = new SqlCommand(text4, sqlConnection);
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter3.Fill(dataSet3);
							if (dataSet3.Tables[0].Rows.Count <= 0)
							{
								continue;
							}
							text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"].ToString()));
							text2 = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
							SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet4 = new DataSet();
							sqlDataAdapter4.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								text3 = dataSet4.Tables[0].Rows[0][0].ToString();
							}
							string cmdText4 = fun.select("tblMM_PO_Master.PONo,tblMM_PO_Master.SupplierId,tblMM_PO_Details.Id,tblMM_PO_Details.DelDate ", "tblMM_PO_Details,tblMM_PO_Master", " tblMM_PO_Master.SupplierId='" + SupplId + "'AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.PRId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[j]["Id"]) + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							for (int k = 0; k < dataSet5.Tables[0].Rows.Count; k++)
							{
								num9 = Convert.ToInt32(dataSet5.Tables[0].Rows[k]["Id"]);
								SupplId = dataSet5.Tables[0].Rows[k]["SupplierId"].ToString();
								string cmdText5 = fun.select("tblInv_Inward_Master.GINNo,tblInv_Inward_Master.Id", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Details.POId='" + Convert.ToInt32(dataSet5.Tables[0].Rows[k]["Id"]) + "' AND tblInv_Inward_Master.PONo='" + dataSet5.Tables[0].Rows[k]["PONo"].ToString() + "'");
								SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
								DataSet dataSet6 = new DataSet();
								sqlDataAdapter6.Fill(dataSet6);
								for (int l = 0; l < dataSet6.Tables[0].Rows.Count; l++)
								{
									string cmdText6 = fun.select("tblinv_MaterialReceived_Master.GRRNo,tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Details.ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + dataSet6.Tables[0].Rows[l]["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + num9 + "'");
									SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
									SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
									DataSet dataSet7 = new DataSet();
									sqlDataAdapter7.Fill(dataSet7);
									for (int m = 0; m < dataSet7.Tables[0].Rows.Count; m++)
									{
										num2 = Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[m]["ReceivedQty"].ToString()).ToString("N3"));
										string cmdText7 = fun.select("tblQc_MaterialQuality_Details.DeviatedQty,tblQc_MaterialQuality_Details.SegregatedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.NormalAccQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Master.SysDate", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", string.Concat("tblQc_MaterialQuality_Master.CompId='", CompId, "'  AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND  tblQc_MaterialQuality_Details.GRRId='", dataSet7.Tables[0].Rows[m]["Id"], "' "));
										SqlCommand selectCommand8 = new SqlCommand(cmdText7, sqlConnection);
										SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
										DataSet dataSet8 = new DataSet();
										sqlDataAdapter8.Fill(dataSet8);
										for (int n = 0; n < dataSet8.Tables[0].Rows.Count; n++)
										{
											num3 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[n]["NormalAccQty"].ToString()).ToString("N3"));
											num4 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[n]["DeviatedQty"].ToString()).ToString("N3"));
											num5 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[n]["SegregatedQty"].ToString()).ToString("N3"));
											num6 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[n]["RejectedQty"].ToString()).ToString("N3"));
											dataRow[4] = num3;
											dataRow[5] = num4;
											dataRow[6] = num5;
											num10 = Convert.ToDouble(decimal.Parse(((num3 * 1.0 + num4 * 0.7 + num5 * 0.5) * 100.0 / num2).ToString()).ToString("N3"));
											dateTime2 = Convert.ToDateTime(dataSet8.Tables[0].Rows[n]["SysDate"].ToString());
											dataRow[7] = num6;
										}
									}
								}
								dataRow[8] = SupplId.ToString();
								dateTime = Convert.ToDateTime(dataSet5.Tables[0].Rows[k]["DelDate"].ToString());
								num8 = Convert.ToDouble(Math.Round((dateTime - dateTime2).TotalDays * 1.1, 0));
								dateTime3 = dateTime2.AddDays(num8);
								num7 = ((!(dateTime3 >= dateTime)) ? 0.0 : 100.0);
								dataRow[10] = num7;
							}
							dataRow[0] = text;
							dataRow[1] = text2;
							dataRow[2] = text3;
							dataRow[3] = num2;
							dataRow[9] = CompId;
							num11 = Math.Round(num10 * 0.6 + num7 * 0.4);
							dataRow[11] = Math.Round(num11);
							dataRow[12] = Math.Round(num10);
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
					else
					{
						if (!(dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "1"))
						{
							continue;
						}
						string cmdText8 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.Id,tblMM_SPR_Master.SPRNo", "tblMM_SPR_Master,tblMM_SPR_Details", string.Concat("tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='", CompId, "' And tblMM_SPR_Details.Id='", dataSet.Tables[0].Rows[i]["SPRId"], "'  And tblMM_SPR_Master.FinYearId='", FinYearId, "' "));
						SqlCommand selectCommand9 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9);
						for (int num12 = 0; num12 < dataSet9.Tables[0].Rows.Count; num12++)
						{
							DataRow dataRow = dataTable.NewRow();
							string text5 = "";
							text5 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", " CompId='" + CompId + "' And Id='" + dataSet9.Tables[0].Rows[num12]["ItemId"].ToString() + "'    " + x);
							SqlCommand selectCommand10 = new SqlCommand(text5, sqlConnection);
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
							DataSet dataSet10 = new DataSet();
							sqlDataAdapter10.Fill(dataSet10);
							if (dataSet10.Tables[0].Rows.Count <= 0)
							{
								continue;
							}
							text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["Id"].ToString()));
							text2 = dataSet10.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet10.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
							SqlCommand selectCommand11 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
							DataSet dataSet11 = new DataSet();
							sqlDataAdapter11.Fill(dataSet11);
							if (dataSet11.Tables[0].Rows.Count > 0)
							{
								text3 = dataSet11.Tables[0].Rows[0][0].ToString();
							}
							string cmdText10 = fun.select(" count(tblMM_PO_Master.SupplierId)", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PO_Master.SupplierId='" + SupplId + "'  Group by tblMM_PO_Master.SupplierId ");
							SqlCommand selectCommand12 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
							DataSet dataSet12 = new DataSet();
							sqlDataAdapter12.Fill(dataSet12);
							if (dataSet12.Tables[0].Rows.Count > 0)
							{
								num = dataSet12.Tables[0].Rows.Count;
							}
							string cmdText11 = fun.select("tblMM_PO_Master.PONo,tblMM_PO_Master.SupplierId,tblMM_PO_Details.Id ,tblMM_PO_Details.DelDate", "tblMM_PO_Details,tblMM_PO_Master", " tblMM_PO_Master.SupplierId='" + SupplId + "'AND  tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.SPRId='" + Convert.ToInt32(dataSet9.Tables[0].Rows[num12]["Id"]) + "' ");
							SqlCommand selectCommand13 = new SqlCommand(cmdText11, sqlConnection);
							SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
							DataSet dataSet13 = new DataSet();
							sqlDataAdapter13.Fill(dataSet13);
							for (int num13 = 0; num13 < dataSet13.Tables[0].Rows.Count; num13++)
							{
								num9 = Convert.ToInt32(dataSet13.Tables[0].Rows[num13]["Id"]);
								SupplId = dataSet13.Tables[0].Rows[num13]["SupplierId"].ToString();
								string cmdText12 = fun.select("tblInv_Inward_Master.GINNo,tblInv_Inward_Master.Id", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Details.POId='" + Convert.ToInt32(dataSet13.Tables[0].Rows[num13]["Id"]) + "' AND tblInv_Inward_Master.PONo='" + dataSet13.Tables[0].Rows[num13]["PONo"].ToString() + "'");
								SqlCommand selectCommand14 = new SqlCommand(cmdText12, sqlConnection);
								SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
								DataSet dataSet14 = new DataSet();
								sqlDataAdapter14.Fill(dataSet14);
								for (int num14 = 0; num14 < dataSet14.Tables[0].Rows.Count; num14++)
								{
									string cmdText13 = fun.select("tblinv_MaterialReceived_Master.GRRNo,tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Details.ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + dataSet14.Tables[0].Rows[num14]["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + num9 + "'");
									SqlCommand selectCommand15 = new SqlCommand(cmdText13, sqlConnection);
									SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
									DataSet dataSet15 = new DataSet();
									sqlDataAdapter15.Fill(dataSet15);
									for (int num15 = 0; num15 < dataSet15.Tables[0].Rows.Count; num15++)
									{
										num2 = Convert.ToDouble(decimal.Parse(dataSet15.Tables[0].Rows[num15]["ReceivedQty"].ToString()).ToString("N3"));
										string cmdText14 = fun.select(" tblQc_MaterialQuality_Details.DeviatedQty,tblQc_MaterialQuality_Details.SegregatedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.NormalAccQty,tblQc_MaterialQuality_Master.SysDate", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", string.Concat("tblQc_MaterialQuality_Master.CompId='", CompId, "'  AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.GRRId='", dataSet15.Tables[0].Rows[num15]["Id"], "'  "));
										SqlCommand selectCommand16 = new SqlCommand(cmdText14, sqlConnection);
										SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
										DataSet dataSet16 = new DataSet();
										sqlDataAdapter16.Fill(dataSet16);
										for (int num16 = 0; num16 < dataSet16.Tables[0].Rows.Count; num16++)
										{
											num3 = Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[num16]["NormalAccQty"].ToString()).ToString("N3"));
											num4 = Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[num16]["DeviatedQty"].ToString()).ToString("N3"));
											num5 = Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[num16]["SegregatedQty"].ToString()).ToString("N3"));
											num6 = Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[num16]["RejectedQty"].ToString()).ToString("N3"));
											dataRow[4] = num3;
											dataRow[5] = num4;
											dataRow[6] = num5;
											dataRow[7] = num6;
											num10 = Convert.ToDouble(decimal.Parse(((num3 * 1.0 + num4 * 0.7 + num5 * 0.5) * 100.0 / num2).ToString()).ToString("N3"));
											dateTime2 = Convert.ToDateTime(dataSet16.Tables[0].Rows[num16]["SysDate"].ToString());
										}
									}
								}
								dataRow[8] = SupplId.ToString();
								dateTime = Convert.ToDateTime(dataSet13.Tables[0].Rows[num13]["DelDate"].ToString());
								num8 = Convert.ToDouble(Math.Round((dateTime - dateTime2).TotalDays * 1.1, 0));
								dateTime3 = dateTime2.AddDays(num8);
								num7 = ((!(dateTime3 >= dateTime)) ? 0.0 : 100.0);
								dataRow[10] = num7;
							}
							dataRow[0] = text;
							dataRow[1] = text2;
							dataRow[2] = text3;
							dataRow[3] = num2;
							dataRow[9] = CompId;
							num11 = Convert.ToDouble(decimal.Parse((num10 * 0.6 + num7 * 0.4).ToString()).ToString("N3"));
							dataRow[11] = Convert.ToDouble(decimal.Parse((num11 / num).ToString()).ToString("N3"));
							dataRow[12] = Convert.ToDouble(decimal.Parse(num10.ToString()).ToString("N3"));
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
				DataSet dataSet17 = new VendorRating();
				dataSet17.Tables[0].Merge(dataTable);
				dataSet17.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/VendorRating.rpt"));
				cryRpt.SetDataSource(dataSet17);
				string text6 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text6);
				cryRpt.SetParameterValue("ManfDesc", (object)text2);
				cryRpt.SetParameterValue("ItemCode", (object)text);
				cryRpt.SetParameterValue("UOM", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				string cmdText15 = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_master", "SupplierId='" + SupplId + "' And CompId='" + CompId + "'");
				DataSet dataSet18 = new DataSet();
				SqlCommand selectCommand17 = new SqlCommand(cmdText15, sqlConnection);
				SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
				sqlDataAdapter17.Fill(dataSet18, "tblMM_Supplier_master");
				string cmdText16 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet18.Tables[0].Rows[0]["RegdCountry"], "'"));
				string cmdText17 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet18.Tables[0].Rows[0]["RegdState"], "'"));
				string cmdText18 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet18.Tables[0].Rows[0]["RegdCity"], "'"));
				SqlCommand selectCommand18 = new SqlCommand(cmdText16, sqlConnection);
				SqlCommand selectCommand19 = new SqlCommand(cmdText17, sqlConnection);
				SqlCommand selectCommand20 = new SqlCommand(cmdText18, sqlConnection);
				SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
				SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
				SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
				DataSet dataSet19 = new DataSet();
				DataSet dataSet20 = new DataSet();
				DataSet dataSet21 = new DataSet();
				sqlDataAdapter18.Fill(dataSet19, "tblCountry");
				sqlDataAdapter19.Fill(dataSet20, "tblState");
				sqlDataAdapter20.Fill(dataSet21, "tblcity");
				string text7 = dataSet18.Tables[0].Rows[0]["RegdAddress"].ToString() + "," + dataSet21.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet20.Tables[0].Rows[0]["StateName"].ToString() + "," + dataSet19.Tables[0].Rows[0]["CountryName"].ToString() + "." + dataSet18.Tables[0].Rows[0]["RegdPinNo"].ToString() + ".";
				cryRpt.SetParameterValue("SupplierAddress", (object)text7);
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

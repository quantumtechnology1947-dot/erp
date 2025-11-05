using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_AssetRegister_Report : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt = new ReportDocument();

	private string Cat = "";

	private string SubCat = "";

	private string Key = "";

	private int FinYearId;

	private int CompId;

	protected Label Label1;

	protected Panel Panel1;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Expected O, but got Unknown
		//IL_0bc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Cat = base.Request.QueryString["CAT"].ToString();
			SubCat = base.Request.QueryString["SCAT"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			if (Cat == "0" && SubCat == "0")
			{
				Panel1.Visible = true;
				((Control)(object)CrystalReportViewer1).Visible = false;
			}
			else
			{
				Panel1.Visible = false;
			}
			if (!base.IsPostBack)
			{
				sqlConnection.Open();
				string text = "";
				text = ((!(base.Request.QueryString["CAT"].ToString() != "") || !(base.Request.QueryString["SCAT"].ToString() != "")) ? "" : (" AND tblACC_Asset_Register.ACategoyId='" + Cat + "' AND tblACC_Asset_Register.ASubCategoyId='" + SubCat + "'"));
				DataTable dataTable = new DataTable();
				string cmdText = fun.select("tblACC_Asset_Register.Id,tblACC_Asset_Register.CompId,tblACC_Asset_Register.FinYearId, tblACC_Asset_Register.MId AS GQNId,tblQc_MaterialQuality_Details.GQNNo,tblQc_MaterialQuality_Details.GRRId,substring(tblFinancial_master.FinYearFrom,3,2)+'-'+substring( tblFinancial_master.FinYearTo,3,2)+'/'+tblACC_Asset_Category.Abbrivation +'/'+tblACC_Asset_SubCategory.Abbrivation +'/'+ tblACC_Asset_Register.AssetNo AS  AssetNo, tblQc_MaterialQuality_Master.GRRId,tblQc_MaterialQuality_Details.GRRId as DGRRId,tblinv_MaterialReceived_Master.GINId,tblinv_MaterialReceived_Details.POId ", " tblACC_Asset_Register, tblQc_MaterialQuality_Details,tblACC_Asset_Category,tblACC_Asset_SubCategory,tblFinancial_master,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details ", "tblACC_Asset_Register.CompId='" + CompId + "' AND tblACC_Asset_Register.FinYearId='" + FinYearId + "' AND tblACC_Asset_Register.DId=tblQc_MaterialQuality_Details.Id AND  tblACC_Asset_Register.ACategoyId=tblACC_Asset_Category.Id AND tblACC_Asset_Register.ASubCategoyId = tblACC_Asset_SubCategory.Id AND tblACC_Asset_Register.FinYearId=tblFinancial_master.FinYearId AND tblACC_Asset_Register.MId=tblQc_MaterialQuality_Master.Id AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId AND tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId" + text);
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AssetNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				DataSet dataSet2 = new DataSet();
				string value = "";
				string value2 = "";
				string value3 = "";
				string value4 = "";
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString());
					string cmdText2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId,tblMM_PO_Master.SupplierId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
						{
							string cmdText3 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + dataSet3.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet3.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							DataSet dataSet4 = new DataSet();
							sqlDataAdapter3.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								string cmdText4 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
								SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
								DataSet dataSet5 = new DataSet();
								sqlDataAdapter4.Fill(dataSet5);
								if (dataSet5.Tables[0].Rows.Count > 0)
								{
									value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["ItemId"].ToString()));
									value2 = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
									string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
									SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
									SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
									DataSet dataSet6 = new DataSet();
									sqlDataAdapter5.Fill(dataSet6);
									if (dataSet6.Tables[0].Rows.Count > 0)
									{
										value3 = dataSet6.Tables[0].Rows[0][0].ToString();
									}
									value4 = dataSet3.Tables[0].Rows[0]["PONo"].ToString();
								}
							}
						}
						else if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
						{
							string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + dataSet3.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet3.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
							SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter6.Fill(dataSet7);
							if (dataSet7.Tables[0].Rows.Count > 0)
							{
								string cmdText7 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet7.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
								SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
								SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
								DataSet dataSet8 = new DataSet();
								sqlDataAdapter7.Fill(dataSet8);
								if (dataSet8.Tables[0].Rows.Count > 0)
								{
									value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet7.Tables[0].Rows[0]["ItemId"].ToString()));
									value2 = dataSet8.Tables[0].Rows[0]["ManfDesc"].ToString();
									string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet8.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
									SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
									SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
									DataSet dataSet9 = new DataSet();
									sqlDataAdapter8.Fill(dataSet9);
									if (dataSet9.Tables[0].Rows.Count > 0)
									{
										value3 = dataSet9.Tables[0].Rows[0][0].ToString();
									}
									value4 = dataSet3.Tables[0].Rows[0]["PONo"].ToString();
								}
							}
						}
						dataRow[1] = value;
						dataRow[2] = value2;
						dataRow[3] = value3;
						dataRow[4] = dataSet.Tables[0].Rows[i]["GQNNo"].ToString();
						dataRow[5] = dataSet.Tables[0].Rows[i]["AssetNo"].ToString();
						dataRow[6] = value4;
						dataRow[7] = Convert.ToInt32(CompId);
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet10 = new AssetRegister();
				dataSet10.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet10.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/AssetRegister.rpt"));
				cryRpt.SetDataSource(dataSet10);
				string text2 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
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
}

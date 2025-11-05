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

public class Module_Inventory_Reports_GoodsRejection_GRN_Print : Page, IRequiresSessionState
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

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected CrystalReportSource CrystalReportSource1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0f62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f69: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
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
				Key = base.Request.QueryString["Key"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				string cmdText = fun.select("Id,FinYearId,GQNNo,GRRNo,SysDate", "tblQc_MaterialQuality_Master", "CompId='" + CompId + "' And Id='" + Id + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				if (sqlDataReader.HasRows)
				{
					GQNNo = sqlDataReader["GQNNo"].ToString();
				}
				string cmdText2 = fun.select("tblQc_MaterialQuality_Details.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.RejectionReason,tblQc_MaterialQuality_Details.Remarks,tblQc_MaterialQuality_Master.GRRNo,tblQc_MaterialQuality_Master.GRRId,tblQc_MaterialQuality_Details.GRRId as DGRRId,tblQc_MaterialQuality_Master.FinYearId", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id='" + Id + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId  AND tblQc_MaterialQuality_Details.RejectedQty > 0");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Desc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
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
				string text4 = "";
				string text5 = "";
				while (sqlDataReader2.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText3 = fun.select("tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId,tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Details.POId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.Id='" + sqlDataReader2["GRRId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.Id='" + sqlDataReader2["DGRRId"].ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					if (!sqlDataReader3.HasRows)
					{
						continue;
					}
					string cmdText4 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblInv_Inward_Details.ReceivedQty", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + sqlDataReader3["GINId"].ToString() + "' AND tblInv_Inward_Details.POId='" + sqlDataReader3["POId"].ToString() + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					text4 = sqlDataReader4["ChallanNo"].ToString();
					text5 = fun.FromDateDMY(sqlDataReader4["ChallanDate"].ToString());
					if (!sqlDataReader4.HasRows)
					{
						continue;
					}
					string cmdText5 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId,tblMM_PO_Master.SupplierId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + sqlDataReader4["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.Id='" + sqlDataReader4["POId"].ToString() + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (!sqlDataReader5.HasRows)
					{
						continue;
					}
					SupplierNo = sqlDataReader5["SupplierId"].ToString();
					if (sqlDataReader5["PRSPRFlag"].ToString() == "0")
					{
						string cmdText6 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + sqlDataReader5["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + sqlDataReader5["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
						sqlDataReader6.Read();
						if (sqlDataReader6.HasRows)
						{
							string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader6["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
							SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
							sqlDataReader7.Read();
							if (sqlDataReader7.HasRows)
							{
								text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader6["ItemId"].ToString()));
								text2 = sqlDataReader7["ManfDesc"].ToString();
								string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader7["UOMBasic"].ToString() + "'");
								SqlCommand sqlCommand8 = new SqlCommand(cmdText8, sqlConnection);
								SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
								sqlDataReader8.Read();
								if (sqlDataReader8.HasRows)
								{
									text3 = sqlDataReader8[0].ToString();
								}
							}
						}
					}
					else if (sqlDataReader5["PRSPRFlag"].ToString() == "1")
					{
						string cmdText9 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + sqlDataReader5["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + sqlDataReader5["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
						SqlCommand sqlCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
						sqlDataReader9.Read();
						if (sqlDataReader9.HasRows)
						{
							string cmdText10 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader9["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand sqlCommand10 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
							sqlDataReader10.Read();
							if (sqlDataReader10.HasRows)
							{
								text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader9["ItemId"].ToString()));
								text2 = sqlDataReader10["ManfDesc"].ToString();
								string cmdText11 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader10["UOMBasic"].ToString() + "'");
								SqlCommand sqlCommand11 = new SqlCommand(cmdText11, sqlConnection);
								SqlDataReader sqlDataReader11 = sqlCommand11.ExecuteReader();
								sqlDataReader11.Read();
								if (sqlDataReader11.HasRows)
								{
									text3 = sqlDataReader11[0].ToString();
								}
							}
						}
					}
					if (sqlDataReader5["Qty"].ToString() == "")
					{
						dataRow[4] = "0";
					}
					else
					{
						dataRow[4] = Convert.ToDouble(decimal.Parse(sqlDataReader5["Qty"].ToString()).ToString("N3"));
					}
					if (sqlDataReader4["ReceivedQty"].ToString() == "")
					{
						dataRow[5] = "0";
					}
					else
					{
						dataRow[5] = Convert.ToDouble(decimal.Parse(sqlDataReader4["ReceivedQty"].ToString()).ToString("N3"));
					}
					if (sqlDataReader3["ReceivedQty"].ToString() == "")
					{
						dataRow[6] = "0";
					}
					else
					{
						dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader3["ReceivedQty"].ToString()).ToString("N3"));
					}
					if (sqlDataReader2["AcceptedQty"].ToString() == "")
					{
						dataRow[8] = "0";
					}
					else
					{
						dataRow[8] = Convert.ToDouble(decimal.Parse(sqlDataReader2["AcceptedQty"].ToString()).ToString("N3"));
					}
					string cmdText12 = fun.select("Symbol+'-'+Description as Reason", "tblQc_Rejection_Reason", "Id='" + sqlDataReader2["RejectionReason"].ToString() + "'");
					SqlCommand sqlCommand12 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataReader sqlDataReader12 = sqlCommand12.ExecuteReader();
					sqlDataReader12.Read();
					if (sqlDataReader12.HasRows)
					{
						dataRow[9] = sqlDataReader12["Reason"].ToString();
					}
					dataRow[10] = sqlDataReader2["Remarks"].ToString();
					if (sqlDataReader2["RejectedQty"].ToString() == "0")
					{
						dataRow[11] = "0";
					}
					else
					{
						dataRow[11] = Convert.ToDouble(decimal.Parse(sqlDataReader2["RejectedQty"].ToString()).ToString("N3"));
					}
					dataRow[7] = CompId;
					dataRow[0] = Convert.ToInt32(sqlDataReader2["Id"]);
					dataRow[1] = text.ToString();
					dataRow[2] = text2.ToString();
					dataRow[3] = text3.ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet2 = new GRN();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/QualityControl/Reports/GRN.rpt"));
				cryRpt.SetDataSource(dataSet2);
				string cmdText13 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataReader sqlDataReader13 = sqlCommand13.ExecuteReader();
				sqlDataReader13.Read();
				string empty = string.Empty;
				empty = sqlDataReader13[0].ToString();
				cryRpt.SetParameterValue("SupplierName", (object)empty);
				cryRpt.SetParameterValue("ChallanNo", (object)text4);
				cryRpt.SetParameterValue("ChallanDate", (object)text5);
				cryRpt.SetParameterValue("GRRNO", (object)GRRNo);
				cryRpt.SetParameterValue("GINNO", (object)GINNo);
				cryRpt.SetParameterValue("GQNNO", (object)GQNNo);
				string text6 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text6);
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsRejection_GRN.aspx?ModId=10&SubModId=");
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

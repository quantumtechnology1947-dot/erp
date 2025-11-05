using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Inventory_Transactions_TotalIssueAndShortage_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private DataTable dt = new DataTable();

	private DataRow DR;

	public string WONo = "";

	private int CompId;

	private int FinYearId;

	private int Status;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			try
			{
				if (base.Request.QueryString["wono"] != "")
				{
					Status = Convert.ToInt32(base.Request.QueryString["status"].ToString());
					WONo = base.Request.QueryString["wono"].ToString();
					CompId = Convert.ToInt32(Session["compid"]);
					FinYearId = Convert.ToInt32(Session["finyear"]);
					string text = "";
					text = fun.select("CId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='0'");
					string connectionString = fun.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					SqlCommand selectCommand = new SqlCommand(text, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
					dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
					dt.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
					dt.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
					dt.Columns.Add(new DataColumn("BOMQty", typeof(double)));
					dt.Columns.Add(new DataColumn("IssuedQty", typeof(double)));
					dt.Columns.Add(new DataColumn("ShortageQty", typeof(double)));
					dt.Columns.Add("AC", typeof(string));
					dt.Columns.Add(new DataColumn("Rate", typeof(double)));
					dt.Columns.Add(new DataColumn("Amount", typeof(double)));
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						getPrintnode(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]), WONo, CompId);
					}
					DataTable dataTable = (DataTable)ViewState["myDT"];
					string company = fun.getCompany(CompId);
					string text2 = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string cmdText = fun.select("TaskProjectLeader,TaskTargetTryOut_FDate,TaskTargetTryOut_TDate,TaskTargetDespach_FDate,TaskTargetDespach_TDate", "SD_Cust_WorkOrder_Master", " WONo='" + WONo + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "SD_Cust_WorkOrder_Master");
					string text3 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
					string text4 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
					string text5 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
					string text6 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
					string text7 = dataSet2.Tables[0].Rows[0]["TaskProjectLeader"].ToString();
					if (dataTable.Rows.Count > 0)
					{
						((Control)(object)CrystalReportViewer1).Visible = true;
						DataView dataView = new DataView();
						dataView = dataTable.DefaultView;
						dataView.Sort = "ItemCode";
						string text8 = base.Server.MapPath("~/Module/Inventory/Transactions/Reports/TotalIssueAndShortage.rpt");
						report.Load(text8);
						report.SetDataSource((IEnumerable)dataView);
						report.SetParameterValue("Company", (object)company);
						report.SetParameterValue("Address", (object)text2);
						report.SetParameterValue("Title", (object)projectTitle);
						report.SetParameterValue("WONo", (object)WONo);
						report.SetParameterValue("TryOut_FDate", (object)text3);
						report.SetParameterValue("TryOut_TDate", (object)text4);
						report.SetParameterValue("Despach_FDate", (object)text5);
						report.SetParameterValue("Despach_TDate", (object)text6);
						report.SetParameterValue("ProjectLeader", (object)text7);
						((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
						((Control)(object)CrystalReportViewer1).EnableViewState = true;
						Session[Key] = report;
					}
					else
					{
						((Control)(object)CrystalReportViewer1).Visible = false;
					}
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		try
		{
			WONo = base.Request.QueryString["wono"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			Status = Convert.ToInt32(base.Request.QueryString["status"].ToString());
			report = new ReportDocument();
		}
		catch (Exception)
		{
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	public void getPrintnode(int node, string wono, int compid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataSet dataSet2 = new DataSet();
		DataSet dataSet3 = new DataSet();
		DataSet dataSet4 = new DataSet();
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.CId='" + node + "' And tblDG_BOM_Master.WONo='" + WONo + "'And tblDG_BOM_Master.CompId='" + CompId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet2);
			double num = 0.0;
			DR = dt.NewRow();
			DR[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString()));
			DR[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
			DR[2] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
			num = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["PId"]), node, 1.0, CompId, FinYearId).ToString()).ToString("N3"));
			DR[3] = num;
			string cmdText2 = fun.select("sum(tblInv_WIS_Details.IssuedQty) As Sum_IssuedQty", "tblInv_WIS_Details,tblInv_WIS_Master", " tblInv_WIS_Master.WONO='" + WONo + "'  And tblInv_WIS_Details.MId=tblInv_WIS_Master.Id And tblInv_WIS_Master.CompId='" + CompId + "' And  tblInv_WIS_Details.PId='" + dataSet2.Tables[0].Rows[0]["PId"].ToString() + "'   And tblInv_WIS_Details.CId='" + dataSet2.Tables[0].Rows[0]["CId"].ToString() + "' ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet);
			double num2 = 0.0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				if (dataSet.Tables[0].Rows[i][0] != DBNull.Value)
				{
					num2 += Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i][0].ToString()).ToString("N3"));
				}
			}
			DR[4] = num2;
			DR[5] = Convert.ToDouble(decimal.Parse((num - num2).ToString()).ToString("N3"));
			DR[6] = "A";
			string cmdText3 = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", "CompId='" + CompId + "'And ItemId='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3, "tblMM_Rate_Register");
			double num3 = 0.0;
			double num4 = 0.0;
			if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
			{
				num3 = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["rate"]);
				num4 = Convert.ToDouble(decimal.Parse((num2 * num3).ToString()).ToString("N2"));
			}
			DR[7] = num3;
			DR[8] = num4;
			if (num2 > 0.0)
			{
				dt.Rows.Add(DR);
			}
			string cmdText4 = fun.select("tblDG_Item_Master.Id,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.PId='" + node + "' And tblDG_BOM_Master.WONo='" + wono + "'And tblDG_BOM_Master.CompId='" + CompId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id ");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			sqlDataAdapter4.Fill(dataSet4);
			for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
			{
				DR = dt.NewRow();
				double num5 = 0.0;
				DR[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet4.Tables[0].Rows[j]["Id"].ToString()));
				DR[1] = dataSet4.Tables[0].Rows[j]["ManfDesc"].ToString();
				DR[2] = dataSet4.Tables[0].Rows[j]["Symbol"].ToString();
				num5 = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet4.Tables[0].Rows[j]["PId"]), Convert.ToInt32(dataSet4.Tables[0].Rows[j]["CId"]), 1.0, CompId, FinYearId).ToString()).ToString("N3"));
				DR[3] = num5;
				string cmdText5 = fun.select("sum(tblInv_WIS_Details.IssuedQty) As Sum_IssuedQty", "tblInv_WIS_Details,tblInv_WIS_Master", " tblInv_WIS_Master.WONO='" + WONo + "'  And tblInv_WIS_Details.MId=tblInv_WIS_Master.Id And tblInv_WIS_Master.CompId='" + CompId + "' And  tblInv_WIS_Details.PId='" + dataSet4.Tables[0].Rows[j]["PId"].ToString() + "' AND tblInv_WIS_Master.FinYearId<='" + FinYearId + "' And tblInv_WIS_Details.CId='" + dataSet4.Tables[0].Rows[j]["CId"].ToString() + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				double num6 = 0.0;
				for (int k = 0; k < dataSet5.Tables[0].Rows.Count; k++)
				{
					if (dataSet5.Tables[0].Rows[k][0] != DBNull.Value)
					{
						num6 += Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[k][0].ToString()).ToString("N3"));
					}
				}
				DR[4] = num6;
				DR[5] = Convert.ToDouble(decimal.Parse((num5 - num6).ToString()).ToString("N3"));
				DR[6] = "C";
				string cmdText6 = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", "CompId='" + CompId + "'And ItemId='" + dataSet4.Tables[0].Rows[j]["Id"].ToString() + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6, "tblMM_Rate_Register");
				double num7 = 0.0;
				double num8 = 0.0;
				if (dataSet6.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num7 = Convert.ToDouble(dataSet6.Tables[0].Rows[0]["rate"]);
					num8 = Convert.ToDouble(decimal.Parse((num6 * num7).ToString()).ToString("N2"));
				}
				DR[7] = num7;
				DR[8] = num8;
				if (num6 > 0.0)
				{
					dt.Rows.Add(DR);
				}
				DataSet dataSet7 = new DataSet();
				string cmdText7 = fun.select("tblDG_BOM_Master.CId", "tblDG_BOM_Master", string.Concat("tblDG_BOM_Master.PId=", dataSet4.Tables[0].Rows[j]["CId"], "And tblDG_BOM_Master.WONo='", WONo, "'And tblDG_BOM_Master.CompId='", CompId, "'"));
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					for (int l = 0; l < dataSet7.Tables[0].Rows.Count; l++)
					{
						getPrintnode(Convert.ToInt32(dataSet7.Tables[0].Rows[l]["CId"]), wono, compid);
					}
				}
			}
			dt.AcceptChanges();
			ViewState["myDT"] = dt;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
			sqlConnection.Dispose();
			dt.Dispose();
			dataSet4.Dispose();
			dataSet2.Dispose();
			dataSet3.Dispose();
			dataSet.Dispose();
		}
	}

	private void DataSet()
	{
		throw new NotImplementedException();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		switch (Status)
		{
		case 0:
			base.Response.Redirect("WIS_Dry_Actual_Run.aspx?WONo=" + WONo + "&ModId=9&SubModId=53");
			break;
		case 1:
			base.Response.Redirect("WIS_ActualRun_Print.aspx?WONo=" + WONo + "&ModId=9&SubModId=53");
			break;
		}
	}
}

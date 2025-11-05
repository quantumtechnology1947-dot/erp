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

public class Module_MIS_Reports_BOMCosting_Report : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private DataTable DT = new DataTable();

	private DataRow DR;

	private string WONo = "";

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string StartDate = "";

	private string UpToDate = "";

	private string Key = string.Empty;

	private int RadVal;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			if (base.Request.QueryString["wono"] != "")
			{
				WONo = base.Request.QueryString["wono"].ToString();
			}
			RadVal = Convert.ToInt32(base.Request.QueryString["RadVal"].ToString());
			try
			{
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				if (base.Request.QueryString["wono"] != "")
				{
					WONo = base.Request.QueryString["wono"].ToString();
					string text = "";
					if (base.Request.QueryString["PId"] != "" && base.Request.QueryString["CId"] != "")
					{
						int num = Convert.ToInt32(base.Request.QueryString["PId"].ToString());
						int num2 = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
						text = fun.select("CId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND CId='" + num2 + "' AND PId='" + num + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
					}
					else
					{
						text = fun.select("CId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='0'AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
					}
					SqlCommand selectCommand = new SqlCommand(text, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
					DT.Columns.Add("ItemCode", typeof(string));
					DT.Columns.Add("ManfDesc", typeof(string));
					DT.Columns.Add("UOM", typeof(string));
					DT.Columns.Add("Qty", typeof(double));
					DT.Columns.Add("BOMQty", typeof(double));
					DT.Columns.Add("WONo", typeof(string));
					DT.Columns.Add("CompId", typeof(int));
					DT.Columns.Add("AC", typeof(string));
					DT.Columns.Add("StartDate", typeof(string));
					DT.Columns.Add("Rate", typeof(double));
					DT.Columns.Add("Amount", typeof(double));
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						getPrintnode(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]), WONo, CompId);
					}
					DataTable dataSource = (DataTable)ViewState["myDT"];
					string company = fun.getCompany(CompId);
					string text2 = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string text3 = base.Server.MapPath("~/Module/MIS/Reports/BOM_Print_ALL.rpt");
					report.Load(text3);
					report.SetDataSource(dataSource);
					report.SetParameterValue("Company", (object)company);
					report.SetParameterValue("Address", (object)text2);
					report.SetParameterValue("Title", (object)projectTitle);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					((Control)(object)CrystalReportViewer1).EnableViewState = true;
					Session[Key] = report;
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		try
		{
			if (base.Request.QueryString["wono"] != "")
			{
				WONo = base.Request.QueryString["wono"].ToString();
			}
			report = new ReportDocument();
			RadVal = Convert.ToInt32(base.Request.QueryString["RadVal"].ToString());
		}
		catch (Exception)
		{
		}
	}

	public void getPrintnode(int node, string wono, int compid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			int num = Convert.ToInt32(Session["finyear"]);
			sqlConnection.Open();
			string cmdText = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.Id,tblDG_BOM_Master.SysDate,tblDG_BOM_Master.Qty,tblDG_BOM_Master.PId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.CId='" + node + "' And tblDG_BOM_Master.WONo='" + wono + "'  And tblDG_BOM_Master.CompId='" + compid + "' AND tblDG_BOM_Master.FinYearId<='" + num + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id;");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DR = DT.NewRow();
			DR[0] = fun.GetItemCode_PartNo(compid, Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString()));
			DR[1] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
			DR[2] = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
			DR[3] = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Qty"]);
			DR[4] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), node, 1.0, compid, num));
			DR[5] = wono;
			DR[6] = Convert.ToInt32(compid);
			DR[7] = "A";
			DR[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
			double num2 = 0.0;
			string field = "";
			string text = "";
			switch (RadVal)
			{
			case 0:
				field = " max(Rate-(Rate*(Discount/100))) As rate ";
				break;
			case 1:
				field = " min(Rate-(Rate*(Discount/100))) As rate ";
				break;
			case 2:
				field = " avg(Rate-(Rate*(Discount/100))) As rate ";
				break;
			case 3:
				field = " Rate-(Rate*(Discount/100)) As rate ";
				text = " Order by Id Desc ";
				break;
			}
			string cmdText2 = fun.select(field, "tblMM_Rate_Register", "CompId='" + compid + "'And ItemId='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'" + text);
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblMM_Rate_Register");
			if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
			{
				num2 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0][0].ToString()).ToString("N2"));
			}
			DR[9] = num2;
			DR[10] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), node, 1.0, compid, num)) * num2;
			DT.Rows.Add(DR);
			string cmdText3 = fun.select("tblDG_Item_Master.Id,tblDG_BOM_Master.CId,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.SysDate,tblDG_BOM_Master.PId,tblDG_BOM_Master.Qty,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.PId='" + node + "' And tblDG_BOM_Master.WONo='" + wono + "' And tblDG_BOM_Master.CompId='" + compid + "'AND tblDG_BOM_Master.FinYearId<='" + num + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
			{
				DR = DT.NewRow();
				DR[0] = fun.GetItemCode_PartNo(compid, Convert.ToInt32(dataSet3.Tables[0].Rows[i]["Id"].ToString()));
				DR[1] = dataSet3.Tables[0].Rows[i]["ManfDesc"].ToString();
				DR[2] = dataSet3.Tables[0].Rows[i]["Symbol"].ToString();
				DR[3] = Convert.ToDouble(dataSet3.Tables[0].Rows[i]["Qty"]);
				DR[4] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet3.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet3.Tables[0].Rows[i]["CId"]), 1.0, compid, num));
				DR[5] = wono;
				DR[6] = Convert.ToInt32(compid);
				DR[7] = "C";
				DR[8] = fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["SysDate"].ToString());
				double num3 = 0.0;
				string field2 = "";
				string text2 = "";
				switch (RadVal)
				{
				case 0:
					field2 = " max(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 1:
					field2 = " min(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 2:
					field2 = " avg(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 3:
					field2 = " Rate-(Rate*(Discount/100)) As rate ";
					text2 = " Order by Id Desc ";
					break;
				}
				string cmdText4 = fun.select(field2, "tblMM_Rate_Register", "CompId='" + compid + "'And ItemId='" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "'" + text2);
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblMM_Rate_Register");
				if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0][0].ToString()).ToString("N2"));
				}
				DR[9] = num3;
				DR[10] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet3.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet3.Tables[0].Rows[i]["CId"]), 1.0, compid, num)) * num3;
				DT.Rows.Add(DR);
				DataSet dataSet5 = new DataSet();
				string cmdText5 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty,tblDG_BOM_Master.SysDate,tblDG_BOM_Master.CId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", string.Concat("tblDG_BOM_Master.PId=", dataSet3.Tables[0].Rows[i]["CId"], "And tblDG_BOM_Master.WONo='", wono, "'  And tblDG_BOM_Master.CompId='", compid, "'AND tblDG_BOM_Master.FinYearId<='", num, "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet5.Tables[0].Rows.Count; j++)
					{
						getPrintnode(Convert.ToInt32(dataSet5.Tables[0].Rows[j]["CId"]), wono, compid);
					}
				}
			}
			DT.AcceptChanges();
			ViewState["myDT"] = DT;
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOMCosting.aspx?ModId=14&SubModId=");
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

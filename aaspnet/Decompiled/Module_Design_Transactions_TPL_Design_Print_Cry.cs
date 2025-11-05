using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Design_Transactions_TPL_Design_Print_Cry : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private DataRow DR;

	private DataTable DT = new DataTable();

	public string WONo = "";

	private int CompId;

	private int FinYearId;

	private string sql = "";

	private string StartDate = "";

	private string UpToDate = "";

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				if (!string.IsNullOrEmpty(base.Request.QueryString["SD"]))
				{
					StartDate = base.Request.QueryString["SD"].ToString();
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["TD"]))
				{
					UpToDate = base.Request.QueryString["TD"].ToString();
				}
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				if (base.Request.QueryString["wono"] != "")
				{
					WONo = base.Request.QueryString["wono"].ToString();
					if (base.Request.QueryString["PId"] != "" && base.Request.QueryString["CId"] != "")
					{
						int num = Convert.ToInt32(base.Request.QueryString["PId"].ToString());
						int num2 = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
						sql = fun.select("CId", "tblDG_TPL_Master", "WONo='" + WONo + "' AND PId='" + num + "' AND CId='" + num2 + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' ");
					}
					else
					{
						sql = fun.select("CId", "tblDG_TPL_Master", "WONo='" + WONo + "' AND PId='0' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
					}
					SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
					DT.Columns.Add("ItemCode", typeof(string));
					DT.Columns.Add("ManfDesc", typeof(string));
					DT.Columns.Add("UOM", typeof(string));
					DT.Columns.Add("Qty", typeof(double));
					DT.Columns.Add("TPLQty", typeof(double));
					DT.Columns.Add("WONo", typeof(string));
					DT.Columns.Add("CompId", typeof(int));
					DT.Columns.Add("AC", typeof(string));
					DT.Columns.Add("StartDate", typeof(string));
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						getPrintnode(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]), WONo, CompId, FinYearId);
					}
					DataTable dataSource = (DataTable)ViewState["myDT"];
					string company = fun.getCompany(CompId);
					string text = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string text2 = base.Server.MapPath("~/Module/Design/Transactions/Reports/TPL_Print_ALL.rpt");
					report.Load(text2);
					report.SetDataSource(dataSource);
					report.SetParameterValue("Company", (object)company);
					report.SetParameterValue("Address", (object)text);
					report.SetParameterValue("Title", (object)projectTitle);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					((Control)(object)CrystalReportViewer1).EnableViewState = true;
					Session["ReportDocument"] = report;
				}
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

	public void getPrintnode(int node, string wono, int compid, int FinId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			sqlConnection.Open();
			string cmdText = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_TPL_Master.SysDate,tblDG_TPL_Master.Qty,tblDG_TPL_Master.PId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_TPL_Master,tblDG_Item_Master,Unit_Master", "tblDG_TPL_Master.CId='" + node + "' And tblDG_TPL_Master.WONo='" + wono + "'And tblDG_TPL_Master.SysDate between '" + fun.FromDate(StartDate) + "' and '" + fun.FromDate(UpToDate) + "'  And tblDG_TPL_Master.CompId='" + CompId + "' AND tblDG_TPL_Master.FinYearId<='" + FinYearId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DR = DT.NewRow();
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["CId"] != DBNull.Value)
				{
					DR[0] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				}
				else
				{
					DR[0] = dataSet.Tables[0].Rows[0]["PartNo"].ToString();
				}
				DR[1] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				DR[2] = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
				DR[3] = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Qty"]);
				DR[4] = Convert.ToDouble(fun.RecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), node, 1.0, CompId, FinId));
				DR[5] = wono;
				DR[6] = Convert.ToInt32(CompId);
				DR[7] = "A";
				DR[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
			}
			DT.Rows.Add(DR);
			string cmdText2 = fun.select("tblDG_TPL_Master.CId,tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId As CatId,tblDG_TPL_Master.SysDate,tblDG_TPL_Master.PId,tblDG_TPL_Master.Qty,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_TPL_Master,tblDG_Item_Master,Unit_Master", "tblDG_TPL_Master.PId='" + node + "' And tblDG_TPL_Master.WONo='" + wono + "'And tblDG_TPL_Master.SysDate between '" + fun.FromDate(StartDate) + "'and '" + fun.FromDate(UpToDate) + "' And tblDG_TPL_Master.CompId='" + CompId + "'AND tblDG_TPL_Master.FinYearId<='" + FinYearId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DR = DT.NewRow();
				if (dataSet2.Tables[0].Rows[i]["CId"] != DBNull.Value)
				{
					DR[0] = dataSet2.Tables[0].Rows[i]["ItemCode"].ToString();
				}
				else
				{
					DR[0] = dataSet2.Tables[0].Rows[i]["PartNo"].ToString();
				}
				DR[1] = dataSet2.Tables[0].Rows[i]["ManfDesc"].ToString();
				DR[2] = dataSet2.Tables[0].Rows[i]["Symbol"].ToString();
				DR[3] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Qty"]);
				DR[4] = Convert.ToDouble(fun.RecurQty(wono, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]), 1.0, CompId, FinId));
				DR[5] = wono;
				DR[6] = Convert.ToInt32(CompId);
				DR[7] = "C";
				DR[8] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["SysDate"].ToString());
				DT.Rows.Add(DR);
				DataSet dataSet3 = new DataSet();
				string cmdText3 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId As CatId,tblDG_TPL_Master.Qty,tblDG_TPL_Master.SysDate,tblDG_TPL_Master.CId,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_TPL_Master,tblDG_Item_Master,Unit_Master", string.Concat("tblDG_TPL_Master.PId=", dataSet2.Tables[0].Rows[i]["CId"], "And tblDG_TPL_Master.WONo='", wono, "' And tblDG_TPL_Master.SysDate between '", fun.FromDate(StartDate), "' and '", fun.FromDate(UpToDate), "' And tblDG_TPL_Master.CompId='", CompId, "'AND tblDG_TPL_Master.FinYearId<='", FinYearId, "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id AND tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						getPrintnode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wono, compid, FinId);
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
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_Print_Tree.aspx?WONo=" + WONo + "&SD=" + StartDate + "&TD=" + UpToDate + "&ModId=3&SubModId=23");
	}
}

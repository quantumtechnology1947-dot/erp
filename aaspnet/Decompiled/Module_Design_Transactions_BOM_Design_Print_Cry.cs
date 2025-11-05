using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Design_Transactions_BOM_Design_Print_Cry : Page, IRequiresSessionState
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

	private int drpVal;

	private string connStr = string.Empty;

	private string Key = string.Empty;

	private SqlConnection con;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			DataSet dataSet3 = new DataSet();
			DataSet dataSet4 = new DataSet();
			try
			{
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				con.Open();
				Key = base.Request.QueryString["Key"].ToString();
				if (!string.IsNullOrEmpty(base.Request.QueryString["SD"]))
				{
					StartDate = base.Request.QueryString["SD"].ToString();
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["TD"]))
				{
					UpToDate = base.Request.QueryString["TD"].ToString();
				}
				if (base.Request.QueryString["DrpVal"] != "")
				{
					drpVal = Convert.ToInt32(base.Request.QueryString["DrpVal"]);
				}
				if (base.Request.QueryString["wono"] != "")
				{
					WONo = base.Request.QueryString["wono"].ToString();
					string text = "";
					if (base.Request.QueryString["PId"] != "" && base.Request.QueryString["CId"] != "")
					{
						int num = Convert.ToInt32(base.Request.QueryString["PId"].ToString());
						int num2 = Convert.ToInt32(base.Request.QueryString["CId"].ToString());
						text = fun.select("CId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='" + num + "' AND CId='" + num2 + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
					}
					else
					{
						text = fun.select("CId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='0' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
					}
					SqlCommand selectCommand = new SqlCommand(text, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet2, "tblDG_BOM_Master");
					DT.Columns.Add("ItemCode", typeof(string));
					DT.Columns.Add("ManfDesc", typeof(string));
					DT.Columns.Add("UOM", typeof(string));
					DT.Columns.Add("Qty", typeof(double));
					DT.Columns.Add("BOMQty", typeof(double));
					DT.Columns.Add("WONo", typeof(string));
					DT.Columns.Add("CompId", typeof(int));
					DT.Columns.Add("AC", typeof(string));
					DT.Columns.Add("StartDate", typeof(string));
					DT.Columns.Add(new DataColumn("Revision", typeof(string)));
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						dataTable = ((drpVal != 0) ? GetDataTable(drpVal) : getPrintnode(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]), WONo, CompId));
					}
					string company = fun.getCompany(CompId);
					string text2 = fun.CompAdd(CompId);
					string projectTitle = fun.getProjectTitle(WONo);
					string cmdText = "SELECT tblDG_Gunrail_Pitch_Master.WONo, tblDG_Gunrail_Pitch_Master.Pitch,(Case When Type =0 then 'Swivel' Else 'Fixed' END)As Type, tblDG_Gunrail_LongRail.Length as LongrailLength ,tblDG_Gunrail_LongRail.No As LongrailNo FROM tblDG_Gunrail_Pitch_Master INNER JOIN tblDG_Gunrail_LongRail ON tblDG_Gunrail_Pitch_Master.Id = tblDG_Gunrail_LongRail.MId And tblDG_Gunrail_Pitch_Master.WONo='" + WONo + "' And tblDG_Gunrail_Pitch_Master.CompId='" + CompId + "'";
					SqlCommand selectCommand2 = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet3);
					string cmdText2 = "SELECT tblDG_Gunrail_Pitch_Master.WONo, tblDG_Gunrail_Pitch_Master.Pitch,(Case When Type =0 then 'Swivel' Else 'Fixed' END)As Type, tblDG_Gunrail_CrossRail.Length AS CrossrailLength, tblDG_Gunrail_CrossRail.No AS CrossrailNo FROM tblDG_Gunrail_Pitch_Master INNER JOIN tblDG_Gunrail_CrossRail ON tblDG_Gunrail_Pitch_Master.Id = tblDG_Gunrail_CrossRail.MId And tblDG_Gunrail_Pitch_Master.WONo='" + WONo + "' And tblDG_Gunrail_Pitch_Master.CompId='" + CompId + "'";
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet4);
					dataSet3.Merge(dataSet4);
					string cmdText3 = "SELECT tblDG_Gunrail_Pitch_Dispatch_Master.WONo, tblDG_Gunrail_Pitch_Dispatch_Master.Pitch,(Case When Type =0 then 'Swivel' Else 'Fixed' END)As Type, tblDG_Gunrail_LongRail_Dispatch.Length as LongrailLength ,tblDG_Gunrail_LongRail_Dispatch.No As LongrailNo   FROM tblDG_Gunrail_Pitch_Dispatch_Master INNER JOIN tblDG_Gunrail_LongRail_Dispatch ON tblDG_Gunrail_Pitch_Dispatch_Master.Id = tblDG_Gunrail_LongRail_Dispatch.MId And tblDG_Gunrail_Pitch_Dispatch_Master.WONo='" + WONo + "' And tblDG_Gunrail_Pitch_Dispatch_Master.CompId='" + CompId + "'";
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					sqlDataAdapter4.Fill(dataSet);
					string cmdText4 = "SELECT tblDG_Gunrail_Pitch_Dispatch_Master.WONo, tblDG_Gunrail_Pitch_Dispatch_Master.Pitch,(Case When Type =0 then 'Swivel' Else 'Fixed' END)As Type, tblDG_Gunrail_CrossRail_Dispatch.Length AS CrossrailLength, tblDG_Gunrail_CrossRail_Dispatch.No AS CrossrailNo FROM tblDG_Gunrail_Pitch_Dispatch_Master INNER JOIN tblDG_Gunrail_CrossRail_Dispatch ON tblDG_Gunrail_Pitch_Dispatch_Master.Id = tblDG_Gunrail_CrossRail_Dispatch.MId And tblDG_Gunrail_Pitch_Dispatch_Master.WONo='" + WONo + "' And tblDG_Gunrail_Pitch_Dispatch_Master.CompId='" + CompId + "'";
					SqlCommand selectCommand5 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					dataSet.Merge(dataSet5);
					string text3 = base.Server.MapPath("~/Module/Design/Transactions/Reports/BOM_Print_ALL.rpt");
					report.Load(text3);
					DataSet dataSet6 = new BOM();
					dataSet6.Tables[0].Merge(dataTable);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataSet6.Tables[1].Merge(dataSet3.Tables[0]);
					}
					else if (dataSet.Tables[0].Rows.Count > 0)
					{
						dataSet6.Tables[1].Merge(dataSet.Tables[0]);
					}
					dataSet6.AcceptChanges();
					report.SetDataSource(dataSet6);
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
			finally
			{
				con.Close();
				con.Dispose();
				DT.Clear();
				DT.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				dataSet.Clear();
				dataSet.Dispose();
				dataSet3.Clear();
				dataSet3.Dispose();
				dataSet2.Clear();
				dataSet2.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		if (!string.IsNullOrEmpty(base.Request.QueryString["SD"]))
		{
			StartDate = base.Request.QueryString["SD"].ToString();
		}
		if (!string.IsNullOrEmpty(base.Request.QueryString["TD"]))
		{
			UpToDate = base.Request.QueryString["TD"].ToString();
		}
		if (base.Request.QueryString["wono"] != "")
		{
			WONo = base.Request.QueryString["wono"].ToString();
		}
		if (base.Request.QueryString["DrpVal"] != "")
		{
			drpVal = Convert.ToInt32(base.Request.QueryString["DrpVal"]);
		}
		report = new ReportDocument();
	}

	public DataTable GetDataTable(int drpValue)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		try
		{
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("AC", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StartDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			string value = string.Empty;
			switch (drpValue)
			{
			case 2:
				value = "And tblDG_Item_Master.CId is null";
				break;
			case 1:
				value = "And tblDG_Item_Master.CId is not null";
				break;
			}
			sqlDataAdapter = new SqlDataAdapter("Get_BOM_DateWise", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = WONo;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@ItemCId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@ItemCId"].Value = value;
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemCat"] != DBNull.Value)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				}
				else
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["PartNo"].ToString();
				}
				dataRow[1] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[3] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"]);
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(WONo, Convert.ToInt32(dataSet.Tables[0].Rows[i][2]), Convert.ToInt32(dataSet.Tables[0].Rows[i][3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[4] = decimal.Parse(num.ToString()).ToString("N3");
				dataRow[5] = WONo;
				dataRow[6] = CompId;
				dataRow[7] = "";
				dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[9] = dataSet.Tables[0].Rows[i]["Revision"].ToString();
				list.Clear();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
		}
		catch (Exception)
		{
			dataSet.Clear();
			dataSet.Dispose();
			dataTable.Dispose();
		}
		dataTable.DefaultView.Sort = "ItemCode ASC";
		return dataTable.DefaultView.ToTable(true);
	}

	public DataTable getPrintnode(int node, string wono, int compid)
	{
		new DataSet();
		DataSet dataSet = new DataSet();
		DataSet dataSet2 = new DataSet();
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Get_BOM_Print", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wono;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CId"].Value = node;
			sqlDataAdapter.Fill(dataSet2, "tblDG_BOM_Master");
			DR = DT.NewRow();
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				DR[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString()));
				DR[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				DR[2] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				DR[3] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Qty"]);
				DR[4] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["PId"]), node, 1.0, CompId, FinYearId));
				DR[5] = wono;
				DR[6] = Convert.ToInt32(CompId);
				DR[7] = "A";
				DR[8] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["SysDate"].ToString());
				DR[9] = dataSet2.Tables[0].Rows[0]["Revision"].ToString();
				DT.Rows.Add(DR);
			}
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("Get_BOM_Print2", con);
			sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@WONo"].Value = wono;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@CId"].Value = node;
			sqlDataAdapter2.Fill(dataSet, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DR = DT.NewRow();
				DR[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString()));
				DR[1] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				DR[2] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				DR[3] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"]);
				DR[4] = Convert.ToDouble(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]), 1.0, CompId, FinYearId));
				DR[5] = wono;
				DR[6] = Convert.ToInt32(CompId);
				DR[7] = "C";
				DR[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				DR[9] = dataSet.Tables[0].Rows[i]["Revision"].ToString();
				DT.Rows.Add(DR);
				DataSet dataSet3 = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("Get_BOM_Print2", con);
				sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@WONo"].Value = wono;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CId"].Value = dataSet.Tables[0].Rows[i]["CId"];
				sqlDataAdapter3.Fill(dataSet3, "tblDG_BOM_Master");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						getPrintnode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wono, compid);
					}
				}
			}
			DT.AcceptChanges();
		}
		catch (Exception)
		{
		}
		finally
		{
			dataSet2.Clear();
			dataSet2.Dispose();
			dataSet.Clear();
			dataSet.Dispose();
			DT.Dispose();
		}
		return DT;
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_Print_Tree.aspx?WONo=" + WONo + "&SD=" + StartDate + "&TD=" + UpToDate + "&ModId=3&SubModId=26");
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

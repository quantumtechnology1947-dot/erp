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

public class Module_Inventory_Transactions_WIS_View_TransWise_print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string connStr = "";

	private SqlConnection con;

	private string WISNO = "";

	private string WISId = "";

	private string wono = "";

	private int CompId;

	private ReportDocument report = new ReportDocument();

	private int FinYearId;

	private int Status;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acf: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		DataTable dataTable = new DataTable();
		if (!base.IsPostBack)
		{
			try
			{
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				con.Open();
				WISNO = base.Request.QueryString["WISNo"].ToString();
				WISId = base.Request.QueryString["WISId"].ToString();
				wono = base.Request.QueryString["wn"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Status = Convert.ToInt32(base.Request.QueryString["status"]);
				string cmdText = fun.select("Distinct tblInv_WIS_Details.ItemId,tblInv_WIS_Master.SessionId,tblInv_WIS_Master.SysDate", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.Id='" + WISId + "' AND tblInv_WIS_Master.Id=tblInv_WIS_Details.MId");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WISNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("IssuedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("TaskTargetTryOut_FDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskTargetTryOut_TDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskTargetDespach_FDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskTargetDespach_TDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskProjectLeader", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
				string value = "";
				string value2 = "";
				string value3 = "";
				while (sqlDataReader.Read())
				{
					double num = 0.0;
					double num2 = 0.0;
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("PId,CId,IssuedQty", "tblInv_WIS_Details", "MId='" + WISId + "' AND ItemId='" + sqlDataReader["ItemId"].ToString() + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						num2 += Convert.ToDouble(dataSet.Tables[0].Rows[i]["IssuedQty"]);
					}
					num = fun.AllComponentBOMQty(CompId, wono, sqlDataReader["ItemId"].ToString(), FinYearId);
					string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + sqlDataReader["ItemId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
						value2 = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							value3 = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
						}
					}
					string cmdText5 = fun.select("Title+'. '+EmployeeName As GenBy", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", sqlDataReader["SessionId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					string cmdText6 = fun.select("TaskTargetTryOut_FDate,TaskTargetTryOut_TDate,TaskTargetDespach_FDate,TaskTargetDespach_TDate,TaskProjectTitle,TaskProjectLeader", "SD_Cust_WorkOrder_Master", "WONo='" + wono + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "SD_Cust_WorkOrder_Master");
					dataRow[0] = value;
					dataRow[1] = value2;
					dataRow[2] = value3;
					dataRow[3] = WISNO;
					dataRow[4] = num;
					dataRow[5] = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet4.Tables[0].Rows[0]["GenBy"].ToString();
					}
					dataRow[7] = CompId;
					dataRow[8] = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
					dataRow[9] = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
					dataRow[10] = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
					dataRow[11] = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
					dataRow[12] = dataSet5.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
					dataRow[13] = dataSet5.Tables[0].Rows[0]["TaskProjectLeader"].ToString();
					dataRow[14] = fun.FromDate(sqlDataReader["SysDate"].ToString());
					dataRow[15] = wono;
					dataRow[16] = dataSet2.Tables[0].Rows[0]["StockQty"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataView defaultView = dataTable.DefaultView;
				defaultView.Sort = "ItemCode";
				string text = base.Server.MapPath("~/Module/Inventory/Transactions/Reports/TransactionwiseWIS.rpt");
				report.Load(text);
				report.SetDataSource((IEnumerable)defaultView);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				string text2 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataTable.Clear();
				dataTable.Dispose();
				con.Close();
				con.Dispose();
			}
		}
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		try
		{
			WISNO = base.Request.QueryString["WISNo"].ToString();
			WISId = base.Request.QueryString["WISId"].ToString();
			wono = base.Request.QueryString["wn"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			Status = Convert.ToInt32(base.Request.QueryString["status"]);
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

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/WIS_View_TransWise.aspx?WONo=" + wono + "&ModId=9&SubModId=53&status=" + Status);
	}
}

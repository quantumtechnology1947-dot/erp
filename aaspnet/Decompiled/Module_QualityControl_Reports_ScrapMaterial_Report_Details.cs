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

public class Module_QualityControl_Reports_ScrapMaterial_Report_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string MRNNo = "";

	private string MRQNNo = "";

	private int FyId;

	private int CompId;

	private string ScrNo = "";

	private string sId = "";

	private int FinYearId;

	private ReportDocument cryRpt = new ReportDocument();

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e5: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		if (!base.IsPostBack)
		{
			try
			{
				sId = Session["username"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				MRNNo = base.Request.QueryString["MRNNo"].ToString();
				MRQNNo = base.Request.QueryString["MRQNNo"].ToString();
				FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
				CompId = Convert.ToInt32(Session["compid"]);
				ScrNo = base.Request.QueryString["ScrapNo"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				string cmdText = fun.select("*", "tblQC_Scrapregister", "FinYearId<='" + FinYearId + "' And CompId='" + CompId + "' And ScrapNo='" + ScrNo + "' ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RetQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ScrapNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
					SqlCommand sqlCommand2 = new SqlCommand(fun.select("tblQc_MaterialReturnQuality_Details.Id,tblQc_MaterialReturnQuality_Details.MRNId,tblQc_MaterialReturnQuality_Details.MRQNNo,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblQc_MaterialReturnQuality_Master.MRNId as MSId", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id='" + sqlDataReader["MRQNId"].ToString() + "' AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "'"), sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (sqlDataReader2.HasRows)
					{
						SqlCommand sqlCommand3 = new SqlCommand(fun.select("tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Details.Id='" + Convert.ToInt32(sqlDataReader2["MRNId"]) + "' AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId"), sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows)
						{
							SqlCommand sqlCommand4 = new SqlCommand(fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(sqlDataReader3["ItemId"]) + "' AND  CompId='" + CompId + "' "), sqlConnection);
							SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
							sqlDataReader4.Read();
							if (sqlDataReader4.HasRows)
							{
								SqlCommand sqlCommand5 = new SqlCommand(fun.select("Symbol As UOMBasic", "Unit_Master", "Id='" + Convert.ToInt32(sqlDataReader4["UOMBasic"]) + "'"), sqlConnection);
								SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
								sqlDataReader5.Read();
								dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader3["ItemId"].ToString()));
								dataRow[2] = sqlDataReader4["ManfDesc"].ToString();
								if (sqlDataReader5.HasRows)
								{
									dataRow[3] = sqlDataReader5["UOMBasic"].ToString();
								}
								if (sqlDataReader3["DeptId"].ToString() == "0")
								{
									dataRow[4] = "NA";
									dataRow[5] = sqlDataReader3["WONo"].ToString();
								}
								else
								{
									string cmdText2 = fun.select("Symbol", "tblHR_Departments", "Id='" + Convert.ToInt32(sqlDataReader3["DeptId"]) + "'");
									SqlCommand sqlCommand6 = new SqlCommand(cmdText2, sqlConnection);
									SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
									sqlDataReader6.Read();
									if (sqlDataReader6.HasRows)
									{
										dataRow[4] = sqlDataReader6["Symbol"].ToString();
										dataRow[5] = "NA";
									}
								}
								string cmdText3 = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as AcceptedQty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + sqlDataReader2["MRNId"].ToString() + "' AND tblQc_MaterialReturnQuality_Master.MRNId='" + sqlDataReader2["MSId"].ToString() + "'");
								SqlCommand sqlCommand7 = new SqlCommand(cmdText3, sqlConnection);
								SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
								sqlDataReader7.Read();
								if (sqlDataReader7["AcceptedQty"] != DBNull.Value)
								{
									dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader7["AcceptedQty"].ToString()).ToString("N3"));
								}
								else
								{
									dataRow[10] = "0";
								}
								dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader3["RetQty"].ToString()).ToString("N3"));
								dataRow[8] = sqlDataReader3["Remarks"].ToString();
								dataRow[9] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
								dataRow[10] = sqlDataReader["ScrapNo"].ToString();
								dataRow[11] = Convert.ToInt32(sqlDataReader["CompId"]);
								dataRow[12] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
								dataTable.Rows.Add(dataRow);
								dataTable.AcceptChanges();
							}
						}
					}
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet2 = new Scrap();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/QualityControl/Reports/ScrapReport.rpt"));
				cryRpt.SetDataSource(dataSet2);
				((Control)(object)CrystalReportSource1).DataBind();
				string text = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text);
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
		base.Response.Redirect("ScrapMaterial_Report.aspx?ModId=10&SubModId=");
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

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

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MINNo = "";

	private string MRSNo = "";

	private int FyId;

	private int CompId;

	private ReportDocument cryRpt = new ReportDocument();

	private string MId = "";

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b15: Expected O, but got Unknown
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			try
			{
				MId = base.Request.QueryString["Id"].ToString();
				MINNo = base.Request.QueryString["MINNo"].ToString();
				MRSNo = base.Request.QueryString["MRSNo"].ToString();
				FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
				CompId = Convert.ToInt32(Session["compid"]);
				SqlCommand sqlCommand = new SqlCommand(fun.select("tblInv_MaterialIssue_Details.Id,tblInv_MaterialIssue_Details.MRSId,tblInv_MaterialIssue_Master.MRSId as MMId,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master", "tblInv_MaterialIssue_Master.Id='" + MId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "'"), sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("IssueQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
					SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", string.Concat("tblInv_MaterialRequisition_Details.Id='", Convert.ToInt32(sqlDataReader["MRSId"]), "' AND tblInv_MaterialRequisition_Master.CompId='", CompId, "' AND tblInv_MaterialRequisition_Master.Id='", sqlDataReader["MMId"], "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId")), sqlConnection);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						SqlCommand selectCommand2 = new SqlCommand(fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]) + "' AND  CompId='" + CompId + "'"), sqlConnection);
						DataSet dataSet3 = new DataSet();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						sqlDataAdapter2.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet3.Tables[0].Rows[0]["UOMBasic"]) + "'"), sqlConnection);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							sqlDataAdapter3.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								dataRow[3] = dataSet4.Tables[0].Rows[0]["UOM"].ToString();
							}
							dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"].ToString()));
							dataRow[2] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
						}
						if (dataSet2.Tables[0].Rows[0]["DeptId"].ToString() == "1")
						{
							dataRow[4] = "NA";
							dataRow[5] = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
						}
						else if (dataSet2.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
						{
							string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["DeptId"]) + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText, sqlConnection);
							DataSet dataSet5 = new DataSet();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet5);
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								dataRow[4] = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
								dataRow[5] = "NA";
							}
						}
						else
						{
							dataRow[5] = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
							dataRow[4] = "NA";
						}
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
						dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["IssueQty"].ToString()).ToString("N3"));
						dataRow[8] = dataSet2.Tables[0].Rows[0]["Remarks"].ToString();
						dataRow[9] = CompId;
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet6 = new MIN();
				dataSet6.Tables[0].Merge(dataSet.Tables[0]);
				dataSet6.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/MIN_Print.rpt"));
				cryRpt.SetDataSource(dataSet6);
				string cmdText2 = fun.select("SessionId,SysDate", "tblInv_MaterialIssue_Master", "Id='" + MId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter5.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					string text = fun.FromDateDMY(dataSet7.Tables[0].Rows[0]["SysDate"].ToString());
					cryRpt.SetParameterValue("MINDate", (object)text);
				}
				string cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet7.Tables[0].Rows[0]["SessionId"], "'"));
				SqlCommand selectCommand6 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter6.Fill(dataSet8);
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					string text2 = dataSet8.Tables[0].Rows[0]["EmpName"].ToString();
					cryRpt.SetParameterValue("GenBy", (object)text2);
				}
				cryRpt.SetParameterValue("MINNo", (object)MINNo);
				cryRpt.SetParameterValue("MRSNo", (object)MRSNo);
				string text3 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text3);
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
				dataTable.Clear();
				dataTable.Dispose();
				DS.Clear();
				DS.Dispose();
				dataSet.Clear();
				dataSet.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
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

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialIssueNote_MIN_Print.aspx?ModId=9&SubModId=41");
	}
}

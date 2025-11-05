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

public class Module_Inventory_Transactions_MaterialRequisitionSlip_MRS_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRSNo = "";

	private string FyId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	private ReportDocument cryRpt = new ReportDocument();

	private string MId = "";

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			MRSNo = base.Request.QueryString["MRSNo"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = base.Request.QueryString["FyId"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			MId = base.Request.QueryString["Id"].ToString();
			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			try
			{
				SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.MRSNo,tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Master.Id='" + MId + "' AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.CompId='" + CompId + "' "), con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("MRSNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]);
					dataRow[1] = DS.Tables[0].Rows[i]["MRSNo"].ToString();
					SqlCommand selectCommand2 = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"]) + "' AND CompId='" + CompId + "'"), con);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'"), con);
						DataSet dataSet3 = new DataSet();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						sqlDataAdapter3.Fill(dataSet3);
						dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"].ToString()));
						dataRow[3] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet3.Tables[0].Rows[0]["UOM"].ToString();
						}
					}
					if (DS.Tables[0].Rows[i]["DeptId"].ToString() == "1")
					{
						dataRow[5] = "NA";
						dataRow[6] = DS.Tables[0].Rows[i]["WONo"].ToString();
					}
					else if (DS.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
					{
						string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + DS.Tables[0].Rows[i]["DeptId"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText, con);
						DataSet dataSet4 = new DataSet();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							dataRow[6] = "NA";
						}
					}
					else
					{
						dataRow[6] = DS.Tables[0].Rows[0]["WONo"].ToString();
						dataRow[5] = "NA";
					}
					dataRow[7] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
					dataRow[8] = DS.Tables[0].Rows[i]["Remarks"].ToString();
					dataRow[9] = CompId;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet5 = new MRS();
				dataSet5.Tables[0].Merge(dataSet.Tables[0]);
				dataSet5.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/MRS_Print.rpt"));
				cryRpt.SetDataSource(dataSet5);
				string cmdText2 = fun.select("SessionId,SysDate", "tblInv_MaterialRequisition_Master", "Id='" + MId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter5.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					string text = fun.FromDateDMY(dataSet6.Tables[0].Rows[0]["SysDate"].ToString());
					cryRpt.SetParameterValue("MRSDate", (object)text);
				}
				string cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet6.Tables[0].Rows[0]["SessionId"], "'"));
				SqlCommand selectCommand6 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter6.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					string text2 = dataSet7.Tables[0].Rows[0]["EmpName"].ToString();
					cryRpt.SetParameterValue("GenBy", (object)text2);
				}
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
				con.Close();
				con.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				DS.Clear();
				DS.Dispose();
				dataSet.Clear();
				dataSet.Dispose();
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialRequisitionSlip_MRS_Print.aspx?FyId=4&ModId=9&SubModId=40");
	}
}

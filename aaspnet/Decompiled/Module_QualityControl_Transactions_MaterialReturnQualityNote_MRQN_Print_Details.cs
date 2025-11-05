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

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt = new ReportDocument();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string MRQNNo = "";

	private int FyId;

	private int CompId;

	private string MId = "";

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_08c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			DataSet dataSet = new DataSet();
			try
			{
				MRNNo = base.Request.QueryString["MRNNo"].ToString();
				MRQNNo = base.Request.QueryString["MRQNNo"].ToString();
				FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
				CompId = Convert.ToInt32(Session["compid"]);
				MId = base.Request.QueryString["Id"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				SqlCommand sqlCommand = new SqlCommand(fun.select("tblQc_MaterialReturnQuality_Details.Id,tblQc_MaterialReturnQuality_Details.MRNId,tblQc_MaterialReturnQuality_Details.MRQNNo,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblQc_MaterialReturnQuality_Master.MRNId as MSId", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id='" + MId + "' AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "'"), sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RetQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(sqlDataReader["Id"].ToString());
					SqlCommand sqlCommand2 = new SqlCommand(fun.select("tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Details.Id='" + Convert.ToInt32(sqlDataReader["MRNId"]) + "' AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId"), sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (!sqlDataReader2.HasRows)
					{
						continue;
					}
					SqlCommand sqlCommand3 = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(sqlDataReader2["ItemId"]) + "' AND  CompId='" + CompId + "' "), sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					if (!sqlDataReader3.HasRows)
					{
						continue;
					}
					SqlCommand sqlCommand4 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(sqlDataReader3["UOMBasic"]) + "'"), sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader2["ItemId"].ToString()));
					dataRow[2] = sqlDataReader3["ManfDesc"].ToString();
					if (sqlDataReader4.HasRows)
					{
						dataRow[3] = sqlDataReader4["UOM"].ToString();
					}
					if (sqlDataReader2["DeptId"].ToString() == "0")
					{
						dataRow[4] = "NA";
						dataRow[5] = sqlDataReader2["WONo"].ToString();
					}
					else
					{
						string cmdText = fun.select("Symbol", "tblHR_Departments", "Id='" + Convert.ToInt32(sqlDataReader2["DeptId"]) + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText, sqlConnection);
						SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
						sqlDataReader5.Read();
						if (sqlDataReader5.HasRows)
						{
							dataRow[4] = sqlDataReader5["Symbol"].ToString();
							dataRow[5] = "NA";
						}
					}
					dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader2["RetQty"].ToString()).ToString("N3"));
					dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["AcceptedQty"].ToString()).ToString("N3"));
					dataRow[8] = sqlDataReader2["Remarks"].ToString();
					dataRow[9] = CompId;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet2 = new MRS();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/QualityControl/Transactions/Reports/MRQN_Print.rpt"));
				cryRpt.SetDataSource(dataSet2);
				string cmdText2 = fun.select("SessionId,SysDate", "tblQc_MaterialReturnQuality_Master", "Id='" + MId + "' AND CompId='" + CompId + "' ");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6.HasRows)
				{
					string text = fun.FromDateDMY(sqlDataReader6["SysDate"].ToString());
					cryRpt.SetParameterValue("MRQNDate", (object)text);
				}
				string cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", sqlDataReader6["SessionId"], "'"));
				SqlCommand sqlCommand7 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				if (sqlDataReader7.HasRows)
				{
					string text2 = sqlDataReader7["EmpName"].ToString();
					cryRpt.SetParameterValue("GenBy", (object)text2);
				}
				string text3 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text3);
				cryRpt.SetParameterValue("MRNNo", (object)MRNNo);
				cryRpt.SetParameterValue("MRQNNo", (object)MRQNNo);
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
		base.Response.Redirect("MaterialReturnQualityNote_MRQN_Print.aspx?ModId=10&SubModId=49");
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

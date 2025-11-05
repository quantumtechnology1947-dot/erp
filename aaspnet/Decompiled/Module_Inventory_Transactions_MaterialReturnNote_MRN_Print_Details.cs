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

public class Module_Inventory_Transactions_MaterialReturnNote_MRN_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string FyId = "";

	private int CompId;

	private string MId = "";

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
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Expected O, but got Unknown
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Expected O, but got Unknown
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
				MRNNo = base.Request.QueryString["MRNNo"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FyId = base.Request.QueryString["FyId"].ToString();
				SqlCommand sqlCommand = new SqlCommand(fun.select("tblInv_MaterialReturn_Details.Id,tblInv_MaterialReturn_Details.MRNNo,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Master.Id='" + MId + "' AND tblInv_MaterialReturn_Master.MRNNo=tblInv_MaterialReturn_Details.MRNNo AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'"), sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("MRNNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RetQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
					dataRow[1] = sqlDataReader["MRNNo"].ToString();
					SqlCommand selectCommand = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(sqlDataReader["ItemId"]) + "' AND CompId='" + CompId + "'"), sqlConnection);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						SqlCommand selectCommand2 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'"), sqlConnection);
						DataSet dataSet3 = new DataSet();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						sqlDataAdapter2.Fill(dataSet3);
						dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
						dataRow[3] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet3.Tables[0].Rows[0]["UOM"].ToString();
						}
					}
					if (sqlDataReader["DeptId"].ToString() == "1")
					{
						dataRow[5] = "NA";
						dataRow[6] = sqlDataReader["WONo"].ToString();
					}
					else
					{
						string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + Convert.ToInt32(sqlDataReader["DeptId"]) + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText, sqlConnection);
						DataSet dataSet4 = new DataSet();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						sqlDataAdapter3.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							dataRow[6] = "NA";
						}
					}
					dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["RetQty"].ToString()).ToString("N3"));
					dataRow[8] = sqlDataReader["Remarks"].ToString();
					dataRow[9] = CompId;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				DataSet dataSet5 = new MRS();
				dataSet5.Tables[0].Merge(dataSet.Tables[0]);
				dataSet5.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/MRN_Print.rpt"));
				cryRpt.SetDataSource(dataSet5);
				string cmdText2 = fun.select("SessionId,SysDate", "tblInv_MaterialReturn_Master", "Id='" + MId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter4.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					string text = fun.FromDateDMY(dataSet6.Tables[0].Rows[0]["SysDate"].ToString());
					cryRpt.SetParameterValue("MRNDate", (object)text);
				}
				string cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet6.Tables[0].Rows[0]["SessionId"], "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter5.Fill(dataSet7);
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
				dataTable.Clear();
				dataTable.Dispose();
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialReturnNote_MRN_Print.aspx?MRNNo=" + MRNNo + "&ModId=9&SubModId=48");
	}
}

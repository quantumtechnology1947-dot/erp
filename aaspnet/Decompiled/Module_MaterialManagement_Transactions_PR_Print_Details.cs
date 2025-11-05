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

public class Module_MaterialManagement_Transactions_PR_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int cId;

	private string MId = "";

	private string Key = string.Empty;

	private string regdate = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!base.IsPostBack)
			{
				cId = Convert.ToInt32(Session["compid"]);
				sqlConnection.Open();
				string text = base.Request.QueryString["PRNo"].ToString();
				MId = base.Request.QueryString["Id"].ToString();
				string cmdText = fun.select("tblMM_PR_Details.SupplierId,tblDG_Item_Master.Id,tblDG_Item_Master.ItemCode,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As Uom,tblMM_PR_Details.DelDate,tblMM_PR_Details.Qty,tblMM_PR_Details.Rate,tblMM_Supplier_master.SupplierName,tblMM_PR_Master.WONo,tblMM_PR_Master.SysDate,tblMM_PR_Master.PRNo,AccHead.Symbol As AcHead,tblMM_PR_Details.Remarks,tblMM_PR_Details.Discount", "tblMM_PR_Master,tblHR_OfficeStaff,tblMM_PR_Details,AccHead,tblCompany_master,tblDG_Item_Master,tblMM_Supplier_master,Unit_Master", "tblMM_PR_Master.PRNo='" + text + "'And tblMM_PR_Master.CompId='" + cId + "' And tblDG_Item_Master.Id=tblMM_PR_Details.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Details.SupplierId=tblMM_Supplier_master.SupplierId And tblMM_PR_Details.AHId=AccHead.Id And tblMM_PR_Master.CompId=tblCompany_master.CompId And tblMM_PR_Master.SessionId=tblHR_OfficeStaff.EmpId AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.MId='" + MId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UomPurch", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SPRQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Intender", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					string text2 = " ";
					dataRow[0] = fun.GetItemCode_PartNo(cId, Convert.ToInt32(sqlDataReader["Id"].ToString()));
					dataRow[1] = sqlDataReader["ManfDesc"].ToString();
					dataRow[2] = sqlDataReader["Uom"].ToString();
					dataRow[3] = fun.FromDateDMY(sqlDataReader["DelDate"].ToString());
					dataRow[4] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					dataRow[5] = Convert.ToDouble(sqlDataReader["Rate"]);
					if (sqlDataReader["WONo"].ToString() != "")
					{
						dataRow[6] = sqlDataReader["WONo"].ToString();
						string cmdText2 = fun.select("TaskProjectTitle", "SD_Cust_WorkOrder_Master", "CompId='" + cId + "'  And WONo='" + sqlDataReader["WONo"].ToString() + "'");
						SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						text2 = dataSet.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
						dataRow[12] = text2;
					}
					else
					{
						dataRow[6] = "NA";
					}
					dataRow[7] = sqlDataReader["SupplierName"].ToString() + " [ " + sqlDataReader["SupplierId"].ToString() + " ]";
					dataRow[8] = sqlDataReader["AcHead"].ToString();
					dataRow[9] = sqlDataReader["Remarks"].ToString();
					dataRow[10] = cId;
					dataRow[11] = sqlDataReader["Title"].ToString() + "." + sqlDataReader["EmployeeName"].ToString();
					dataRow[13] = Convert.ToDouble(sqlDataReader["Discount"]);
					regdate = sqlDataReader["SysDate"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet2 = new PRPrint();
				dataSet2.Tables[0].Merge(dataTable);
				string text3 = base.Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/PR.rpt");
				report.Load(text3);
				report.SetDataSource(dataSet2);
				string text4 = fun.FromDate(regdate);
				report.SetParameterValue("RegDate", (object)text4);
				report.SetParameterValue("PRNo", (object)text);
				string company = fun.getCompany(cId);
				report.SetParameterValue("Company", (object)company);
				string text5 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text5);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PR_Print.aspx?ModId=6&SubModId=34");
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

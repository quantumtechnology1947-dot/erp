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

public class Module_MaterialManagement_Transactions_SPR_View_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string parentpage = "";

	private string MId = "";

	private int cId;

	private string Key = string.Empty;

	private int FyId;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e27: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			Key = base.Request.QueryString["Key"].ToString();
			sqlConnection.Open();
			try
			{
				parentpage = base.Request.QueryString["parentpage"].ToString();
				MId = base.Request.QueryString["Id"].ToString();
				cId = Convert.ToInt32(Session["compid"]);
				FyId = Convert.ToInt32(Session["finyear"]);
				string text = base.Request.QueryString["SPRNo"].ToString();
				string cmdText = fun.select("tblMM_SPR_Details.Discount,tblDG_Item_Master.ItemCode,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As Uom,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.Qty,tblMM_SPR_Details.Rate,tblMM_Supplier_master.SupplierName,tblMM_SPR_Details.WONo,tblMM_SPR_Master.SysDate,tblMM_SPR_Master.CheckedBy,tblMM_SPR_Master.ApprovedBy,tblMM_SPR_Master.AuthorizedBy,tblMM_SPR_Master.CheckedDate,tblMM_SPR_Master.ApproveDate,tblMM_SPR_Master.AuthorizeDate,tblMM_SPR_Master.SPRNo,AccHead.Symbol As AcHead,tblMM_SPR_Details.Remarks,tblMM_SPR_Details.DeptId", " tblMM_SPR_Master,tblHR_OfficeStaff,tblMM_SPR_Details,AccHead,tblCompany_master,tblDG_Item_Master,tblMM_Supplier_master,Unit_Master", "tblMM_SPR_Master.SPRNo='" + text + "'And tblMM_SPR_Master.CompId='" + cId + "' And tblDG_Item_Master.Id=tblMM_SPR_Details.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Details.SupplierId=tblMM_Supplier_master.SupplierId And tblMM_SPR_Details.AHId=AccHead.Id  And tblMM_SPR_Master.CompId=tblCompany_master.CompId And tblMM_SPR_Master.SessionId=tblHR_OfficeStaff.EmpId AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.MId='" + MId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UomPurch", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SPRQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DeptName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Intender", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["Uom"].ToString();
					dataRow[3] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["DelDate"].ToString());
					dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
					dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
					string cmdText2 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["DeptId"].ToString() + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					string text2 = string.Empty;
					while (sqlDataReader.Read())
					{
						text2 = sqlDataReader["Symbol"].ToString();
					}
					if (dataSet.Tables[0].Rows[i]["WONo"].ToString() != "")
					{
						dataRow[6] = "WONo - " + dataSet.Tables[0].Rows[i]["WONo"].ToString();
					}
					else
					{
						dataRow[6] = "BG Group - " + text2;
					}
					dataRow[7] = dataSet.Tables[0].Rows[i]["SupplierName"].ToString();
					dataRow[8] = text2;
					dataRow[9] = dataSet.Tables[0].Rows[i]["AcHead"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
					dataRow[11] = cId;
					dataRow[12] = dataSet.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
					dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Discount"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet2 = new SPRPrint();
				dataSet2.Tables[0].Merge(dataTable);
				string text3 = base.Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/SPR.rpt");
				report.Load(text3);
				report.SetDataSource(dataSet2);
				string fD = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
				string text4 = fun.FromDate(fD);
				report.SetParameterValue("RegDate", (object)text4);
				string text5 = dataSet.Tables[0].Rows[0]["CheckedBy"].ToString();
				string text6 = dataSet.Tables[0].Rows[0]["ApprovedBy"].ToString();
				string text7 = dataSet.Tables[0].Rows[0]["AuthorizedBy"].ToString();
				string text8 = "";
				if (dataSet.Tables[0].Rows[0]["CheckedBy"] != DBNull.Value)
				{
					string cmdText3 = fun.select(" Title,EmployeeName ", " tblHR_OfficeStaff ", " EmpId='" + text5 + "'And CompId='" + cId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3, "tblHR_OfficeStaff");
					text8 = dataSet3.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				else
				{
					text8 = " ";
				}
				string text9 = "";
				if (dataSet.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value)
				{
					string cmdText4 = fun.select("Title,EmployeeName ", "tblHR_OfficeStaff  ", " EmpId='" + text6 + "'And CompId='" + cId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4, "tblHR_OfficeStaff");
					text9 = dataSet4.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				else
				{
					text9 = " ";
				}
				string text10 = "";
				if (dataSet.Tables[0].Rows[0]["AuthorizedBy"] != DBNull.Value)
				{
					string cmdText5 = fun.select(" Title,EmployeeName ", " tblHR_OfficeStaff ", " EmpId='" + text7 + "'And CompId='" + cId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5, "tblHR_OfficeStaff");
					text10 = dataSet5.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				else
				{
					text10 = " ";
				}
				report.SetParameterValue("CheckedBy", (object)text8);
				report.SetParameterValue("ApprovedBy", (object)text9);
				report.SetParameterValue("AuthorizedBy", (object)text10);
				string text11 = "";
				if (dataSet.Tables[0].Rows[0]["CheckedDate"] != DBNull.Value)
				{
					string fD2 = dataSet.Tables[0].Rows[0]["CheckedDate"].ToString();
					text11 = fun.FromDate(fD2);
				}
				else
				{
					text11 = "";
				}
				string text12 = "";
				if (dataSet.Tables[0].Rows[0]["ApproveDate"] != DBNull.Value)
				{
					string fD3 = dataSet.Tables[0].Rows[0]["ApproveDate"].ToString();
					text12 = fun.FromDate(fD3);
				}
				else
				{
					text12 = "";
				}
				string text13 = "";
				if (dataSet.Tables[0].Rows[0]["AuthorizeDate"] != DBNull.Value)
				{
					string fD4 = dataSet.Tables[0].Rows[0]["AuthorizeDate"].ToString();
					text13 = fun.FromDate(fD4);
				}
				else
				{
					text13 = "";
				}
				report.SetParameterValue("SPRNO", (object)text);
				report.SetParameterValue("CheckedDate", (object)text11);
				report.SetParameterValue("ApproveDate", (object)text12);
				report.SetParameterValue("AuthorizeDate", (object)text13);
				string company = fun.getCompany(cId);
				report.SetParameterValue("Company", (object)company);
				string text14 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text14);
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
		report = new ReportDocument();
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		parentpage = base.Request.QueryString["parentpage"].ToString();
		base.Response.Redirect(parentpage + "?ModId=6&SubModId=31");
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

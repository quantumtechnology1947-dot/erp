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

public class Module_MaterialManagement_Transactions_SPR_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string f = "";

	private string MId = "";

	private int cId;

	private int FyId;

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee0: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataSet dataSet = new SPRPrint();
			DataTable dataTable = new DataTable();
			try
			{
				cId = Convert.ToInt32(Session["compid"]);
				FyId = Convert.ToInt32(Session["finyear"]);
				MId = base.Request.QueryString["Id"];
				Key = base.Request.QueryString["Key"].ToString();
				string text = base.Request.QueryString["SPRNo"].ToString();
				string cmdText = fun.select("tblMM_SPR_Details.SupplierId,tblMM_SPR_Details.Discount,tblDG_Item_Master.Id,tblMM_SPR_Details.DeptId,tblDG_Item_Master.ItemCode,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As Uom,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.Qty,tblMM_SPR_Details.Rate,tblMM_Supplier_master.SupplierName,tblMM_SPR_Details.WONo,tblMM_SPR_Master.SysDate,tblMM_SPR_Master.CheckedBy,tblMM_SPR_Master.ApprovedBy,tblMM_SPR_Master.AuthorizedBy,tblMM_SPR_Master.CheckedDate,tblMM_SPR_Master.ApproveDate,tblMM_SPR_Master.AuthorizeDate,tblMM_SPR_Master.SPRNo,AccHead.Symbol As AcHead,tblMM_SPR_Details.Remarks", " tblMM_SPR_Master,tblHR_OfficeStaff,tblMM_SPR_Details,AccHead,tblCompany_master,tblDG_Item_Master,tblMM_Supplier_master,Unit_Master", "tblMM_SPR_Master.SPRNo='" + text + "'And tblMM_SPR_Master.CompId='" + cId + "' And tblDG_Item_Master.Id=tblMM_SPR_Details.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Details.SupplierId=tblMM_Supplier_master.SupplierId And tblMM_SPR_Details.AHId=AccHead.Id And tblMM_SPR_Master.CompId=tblCompany_master.CompId And tblMM_SPR_Master.SessionId=tblHR_OfficeStaff.EmpId AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.MId='" + MId + "' AND tblMM_SPR_Master.FinYearId<='" + FyId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
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
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = fun.GetItemCode_PartNo(cId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"].ToString()));
					dataRow[1] = dataSet2.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[2] = dataSet2.Tables[0].Rows[i]["Uom"].ToString();
					dataRow[3] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["DelDate"].ToString());
					dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
					dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
					if (dataSet2.Tables[0].Rows[i]["WONo"].ToString() != "" && Convert.ToInt32(dataSet2.Tables[0].Rows[i]["DeptId"]) == 0)
					{
						dataRow[6] = "WONo - " + dataSet2.Tables[0].Rows[i]["WONo"].ToString();
					}
					else
					{
						string cmdText2 = fun.select("Symbol As Dept", "BusinessGroup", "Id='" + dataSet2.Tables[0].Rows[i]["DeptId"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3, "BusinessGroup");
						dataRow[6] = "BG Group - " + dataSet3.Tables[0].Rows[0]["Dept"].ToString();
						dataRow[8] = dataSet3.Tables[0].Rows[0]["Dept"].ToString();
					}
					dataRow[7] = dataSet2.Tables[0].Rows[i]["SupplierName"].ToString() + " [ " + dataSet2.Tables[0].Rows[i]["SupplierId"].ToString() + " ]";
					dataRow[9] = dataSet2.Tables[0].Rows[i]["AcHead"].ToString();
					dataRow[10] = dataSet2.Tables[0].Rows[i]["Remarks"].ToString();
					dataRow[11] = cId;
					dataRow[12] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString();
					dataRow[13] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Discount"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables[0].Merge(dataTable);
				string text2 = base.Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/SPR.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet);
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string fD = dataSet2.Tables[0].Rows[0]["SysDate"].ToString();
					string text9 = fun.FromDate(fD);
					report.SetParameterValue("RegDate", (object)text9);
					string text10 = dataSet2.Tables[0].Rows[0]["CheckedBy"].ToString();
					string text11 = dataSet2.Tables[0].Rows[0]["ApprovedBy"].ToString();
					string text12 = dataSet2.Tables[0].Rows[0]["AuthorizedBy"].ToString();
					if (dataSet2.Tables[0].Rows[0]["CheckedBy"] != DBNull.Value)
					{
						string cmdText3 = fun.select(" Title,EmployeeName ", " tblHR_OfficeStaff ", " EmpId='" + text10 + "'And CompId='" + cId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4, "tblHR_OfficeStaff");
						text4 = dataSet4.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					else
					{
						text4 = " ";
					}
					if (dataSet2.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value)
					{
						string cmdText4 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff ", "  EmpId='" + text11 + "'And CompId='" + cId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5, "tblHR_OfficeStaff");
						text5 = dataSet5.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					else
					{
						text5 = " ";
					}
					if (dataSet2.Tables[0].Rows[0]["AuthorizedBy"] != DBNull.Value)
					{
						string cmdText5 = fun.select("Title,EmployeeName ", "tblHR_OfficeStaff", "EmpId='" + text12 + "'And CompId='" + cId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6, "tblHR_OfficeStaff");
						text6 = dataSet6.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet6.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					else
					{
						text6 = " ";
					}
					report.SetParameterValue("CheckedBy", (object)text4);
					report.SetParameterValue("ApprovedBy", (object)text5);
					report.SetParameterValue("AuthorizedBy", (object)text6);
					if (dataSet2.Tables[0].Rows[0]["CheckedDate"] != DBNull.Value)
					{
						string fD2 = dataSet2.Tables[0].Rows[0]["CheckedDate"].ToString();
						text3 = fun.FromDate(fD2);
					}
					else
					{
						text3 = "";
					}
					if (dataSet2.Tables[0].Rows[0]["ApproveDate"] != DBNull.Value)
					{
						string fD3 = dataSet2.Tables[0].Rows[0]["ApproveDate"].ToString();
						text7 = fun.FromDate(fD3);
					}
					else
					{
						text7 = "";
					}
					if (dataSet2.Tables[0].Rows[0]["AuthorizeDate"] != DBNull.Value)
					{
						string fD4 = dataSet2.Tables[0].Rows[0]["AuthorizeDate"].ToString();
						text8 = fun.FromDate(fD4);
					}
					else
					{
						text8 = "";
					}
				}
				report.SetParameterValue("SPRNO", (object)text);
				report.SetParameterValue("CheckedDate", (object)text3);
				report.SetParameterValue("ApproveDate", (object)text7);
				report.SetParameterValue("AuthorizeDate", (object)text8);
				string company = fun.getCompany(cId);
				report.SetParameterValue("Company", (object)company);
				string text13 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text13);
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
		f = base.Request.QueryString["f"].ToString();
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		string url = "";
		switch (f)
		{
		case "1":
			url = "SPR_Dashboard.aspx?ModId=6&SubModId=31";
			break;
		case "2":
			url = "SPR_Print.aspx?ModId=6&SubModId=31";
			break;
		}
		base.Response.Redirect(url);
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

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

public class Module_SalesDistribution_Reports_WorkOrder_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string strcustId = "";

	private string strenqId = "";

	private string strpoId = "";

	private string poId = "";

	private string Id = "";

	private int CId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCl;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e98: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			try
			{
				strcustId = base.Request.QueryString["CustomerId"].ToString();
				strenqId = base.Request.QueryString["EnqId"].ToString();
				strpoId = base.Request.QueryString["PONo"].ToString();
				poId = base.Request.QueryString["POId"].ToString();
				Id = base.Request.QueryString["Id"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				CId = Convert.ToInt32(Session["compid"]);
				string cmdText = fun.select("*", "SD_Cust_WorkOrder_Master", "POId='" + poId + "'AND PONo='" + strpoId + "' And EnqId='" + strenqId + "'And Id='" + Id + "'And CustomerId='" + strcustId + "'And CompId='" + CId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Master");
				string text = base.Server.MapPath("~/Module/SalesDistribution/Transactions/Reports/CustWo.rpt");
				report.Load(text);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					int cityid = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShippingCity"]);
					string city = fun.getCity(cityid, 1);
					int stateid = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShippingState"]);
					string state = fun.getState(stateid, 1);
					int cntid = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ShippingCountry"]);
					string country = fun.getCountry(cntid, 1);
					string fD = dataSet.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString();
					string text2 = fun.FromDateDMY(fD);
					string fD2 = dataSet.Tables[0].Rows[0]["TaskTargetDAP_FDate"].ToString();
					string text3 = fun.FromDateDMY(fD2);
					string tD = dataSet.Tables[0].Rows[0]["TaskTargetDAP_TDate"].ToString();
					string text4 = fun.ToDateDMY(tD);
					string fD3 = dataSet.Tables[0].Rows[0]["TaskDesignFinalization_FDate"].ToString();
					string text5 = fun.FromDateDMY(fD3);
					string tD2 = dataSet.Tables[0].Rows[0]["TaskDesignFinalization_TDate"].ToString();
					string text6 = fun.ToDateDMY(tD2);
					string fD4 = dataSet.Tables[0].Rows[0]["TaskTargetManufg_FDate"].ToString();
					string text7 = fun.FromDateDMY(fD4);
					string tD3 = dataSet.Tables[0].Rows[0]["TaskTargetManufg_TDate"].ToString();
					string text8 = fun.ToDateDMY(tD3);
					string fD5 = dataSet.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString();
					string text9 = fun.FromDateDMY(fD5);
					string tD4 = dataSet.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString();
					string text10 = fun.ToDateDMY(tD4);
					string fD6 = dataSet.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString();
					string text11 = fun.FromDateDMY(fD6);
					string tD5 = dataSet.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString();
					string text12 = fun.ToDateDMY(tD5);
					string fD7 = dataSet.Tables[0].Rows[0]["TaskTargetInstalation_FDate"].ToString();
					string text13 = fun.FromDateDMY(fD7);
					string tD6 = dataSet.Tables[0].Rows[0]["TaskTargetInstalation_TDate"].ToString();
					string text14 = fun.ToDateDMY(tD6);
					string fD8 = dataSet.Tables[0].Rows[0]["TaskTargetAssembly_FDate"].ToString();
					string text15 = fun.FromDateDMY(fD8);
					string tD7 = dataSet.Tables[0].Rows[0]["TaskTargetAssembly_TDate"].ToString();
					string text16 = fun.ToDateDMY(tD7);
					string fD9 = dataSet.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString();
					string text17 = fun.FromDateDMY(fD9);
					string tD8 = dataSet.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString();
					string text18 = fun.ToDateDMY(tD8);
					string text19 = fun.ToDateDMY(dataSet.Tables[0].Rows[0]["ManufMaterialDate"].ToString());
					string text20 = fun.ToDateDMY(dataSet.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());
					report.SetParameterValue("shipcity", (object)city);
					report.SetParameterValue("shipstate", (object)state);
					report.SetParameterValue("shipcountry", (object)country);
					report.SetParameterValue("TaskWorkOrderDate", (object)text2);
					report.SetParameterValue("TaskTargetDAP_FDate", (object)text3);
					report.SetParameterValue("TaskTargetDAP_TDate", (object)text4);
					report.SetParameterValue("TaskDesignFinalization_FDate", (object)text5);
					report.SetParameterValue("TaskDesignFinalization_TDate", (object)text6);
					report.SetParameterValue("TaskTargetManufg_FDate", (object)text7);
					report.SetParameterValue("TaskTargetManufg_TDate", (object)text8);
					report.SetParameterValue("TaskTargetTryOut_FDate", (object)text9);
					report.SetParameterValue("TaskTargetTryOut_TDate", (object)text10);
					report.SetParameterValue("TaskTargetDespach_FDate", (object)text11);
					report.SetParameterValue("TaskTargetDespach_TDate", (object)text12);
					report.SetParameterValue("TaskTargetInstalation_FDate", (object)text13);
					report.SetParameterValue("TaskTargetInstalation_TDate", (object)text14);
					report.SetParameterValue("TaskTargetAssembly_FDate", (object)text15);
					report.SetParameterValue("TaskTargetAssembly_TDate", (object)text16);
					report.SetParameterValue("TaskCustInspection_FDate", (object)text17);
					report.SetParameterValue("TaskCustInspection_TDate", (object)text18);
					report.SetParameterValue("ManufMaterialDate", (object)text19);
					report.SetParameterValue("BoughtoutMaterialDate", (object)text20);
					SqlCommand selectCommand2 = new SqlCommand(fun.select("Symbol+' - '+CName as Category", "tblSD_WO_Category", "CId='" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblSD_WO_Category");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						report.SetParameterValue("ec", (object)dataSet2.Tables[0].Rows[0]["Category"].ToString());
					}
					else
					{
						report.SetParameterValue("ec", (object)"NA");
					}
					string cmdText2 = fun.select("tblMM_Buyer_Master.Id,tblMM_Buyer_Master.Category+Convert(Varchar,tblMM_Buyer_Master.Nos)+' - '+tblHR_OfficeStaff.EmployeeName+' ['+tblMM_Buyer_Master.EmpId+' ]' As Buyer", "tblMM_Buyer_Master,tblHR_OfficeStaff", "tblMM_Buyer_Master.EmpId=tblHR_OfficeStaff.EmpId AND tblMM_Buyer_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["Buyer"].ToString()) + "' ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "tblMM_Buyer_Master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						report.SetParameterValue("Buyer", (object)dataSet3.Tables[0].Rows[0]["Buyer"].ToString());
					}
					else
					{
						report.SetParameterValue("Buyer", (object)"NA");
					}
					SqlCommand selectCommand4 = new SqlCommand(fun.select("Symbol+' - '+SCName as SubCategory", "tblSD_WO_SubCategory", "SCId='" + dataSet.Tables[0].Rows[0]["SCId"].ToString() + "'"), sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblSD_WO_Category");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						report.SetParameterValue("Sub", (object)dataSet4.Tables[0].Rows[0]["SubCategory"].ToString());
					}
					else
					{
						report.SetParameterValue("Sub", (object)"NA");
					}
					string text21 = fun.CompAdd(CId);
					report.SetParameterValue("Address", (object)text21);
					string company = fun.getCompany(CId);
					report.SetParameterValue("Company", (object)company);
					report.SetParameterValue("PONo", (object)strpoId);
					string text22 = "";
					if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["InstractionPrimerPainting"]) == 1)
					{
						text22 += "Primer Painting,";
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["InstractionPainting"]) == 1)
					{
						text22 += " Painting,";
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["InstractionSelfCertRept"]) == 1)
					{
						text22 += " Self Certification Report ";
					}
					text22 += dataSet.Tables[0].Rows[0]["InstractionOther"].ToString();
					report.SetParameterValue("instruction", (object)text22);
				}
				string cmdText3 = fun.select("ItemCode,Description,Qty ", "SD_Cust_WorkOrder_Products_Details", "MId='" + Id + "'And CompId='" + CId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "SD_Cust_WorkOrder_Products_Details");
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Quantity", typeof(string)));
				for (int i = 0; i < dataSet5.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet5.Tables[0].Rows[i][0].ToString();
					dataRow[1] = dataSet5.Tables[0].Rows[i][1].ToString();
					dataRow[2] = dataSet5.Tables[0].Rows[i][2].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("WorkOrder_Print.aspx?ModId=2&SubModId=13");
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

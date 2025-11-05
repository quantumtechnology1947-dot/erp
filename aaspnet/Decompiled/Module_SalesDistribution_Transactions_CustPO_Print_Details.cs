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

public class Module_SalesDistribution_Transactions_CustPO_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string connStr1 = "";

	private SqlConnection myConnection;

	private ReportDocument report = new ReportDocument();

	private string regdate = "";

	private string PODate = "";

	private string prdate = "";

	private string PORecDate = "";

	private string RegCity = "";

	private string RegState = "";

	private string RegCountry = "";

	private string WorkCity = "";

	private string WorkState = "";

	private string WorkCountry = "";

	private string DelCity = "";

	private string DelState = "";

	private string DelCountry = "";

	private string custId = "";

	private string regcity = "";

	private string regstate = "";

	private string regcountry = "";

	private string workcity = "";

	private string workstate = "";

	private string workcountry = "";

	private string delcity = "";

	private string delstate = "";

	private string delcountry = "";

	private string POId = "";

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7b: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr1 = fun.Connection();
			myConnection = new SqlConnection(connStr1);
			myConnection.Open();
			try
			{
				string text = "";
				if (!string.IsNullOrEmpty(base.Request.QueryString["PONo"]))
				{
					text = base.Request.QueryString["PONo"].ToString();
				}
				string text2 = "";
				if (!string.IsNullOrEmpty(base.Request.QueryString["EnqId"]))
				{
					text2 = base.Request.QueryString["EnqId"].ToString();
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["POId"]))
				{
					POId = base.Request.QueryString["POId"].ToString();
				}
				Key = base.Request.QueryString["Key"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				string cmdText = fun.select("*", " SD_Cust_PO_Master", "PONo='" + text + "' And EnqId='" + text2 + "' And CompId='" + CompId + "' AND POId='" + POId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, myConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_PO_Master");
				string text3 = base.Server.MapPath("~/Module/SalesDistribution/Transactions/Reports/CustPO.rpt");
				report.Load(text3);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					custId = dataSet.Tables[0].Rows[0]["CustomerId"].ToString();
					regdate = dataSet.Tables[0].Rows[0]["PODate"].ToString();
					PODate = fun.FromDateDMY(regdate);
					prdate = dataSet.Tables[0].Rows[0]["POReceivedDate"].ToString();
					PORecDate = fun.FromDate(prdate);
				}
				string cmdText2 = fun.select("*", "SD_Cust_master", "CustomerId='" + custId + "' And CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, myConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					RegCity = dataSet2.Tables[0].Rows[0]["RegdCity"].ToString();
					RegState = dataSet2.Tables[0].Rows[0]["RegdState"].ToString();
					RegCountry = dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString();
					WorkCity = dataSet2.Tables[0].Rows[0]["WorkCity"].ToString();
					WorkState = dataSet2.Tables[0].Rows[0]["WorkState"].ToString();
					WorkCountry = dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString();
					DelCity = dataSet2.Tables[0].Rows[0]["MaterialDelCity"].ToString();
					DelState = dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString();
					DelCountry = dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
				}
				string cmdText3 = fun.select("CityName", "tblCity", "CityId='" + RegCity + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, myConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = fun.select("StateName", "tblState", "SId='" + RegState + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, myConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string cmdText5 = fun.select("CountryName", "tblCountry", "CId='" + RegCountry + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, myConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					regcity = dataSet3.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					regstate = dataSet4.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					regcountry = dataSet5.Tables[0].Rows[0]["CountryName"].ToString();
				}
				string cmdText6 = fun.select("CityName", "tblCity", "CityId='" + WorkCity + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, myConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				string cmdText7 = fun.select("StateName", "tblState", "SId='" + WorkState + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, myConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				string cmdText8 = fun.select("CountryName", "tblCountry", "CId='" + WorkCountry + "'");
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, myConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					workcity = dataSet6.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					workstate = dataSet7.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					workcountry = dataSet8.Tables[0].Rows[0]["CountryName"].ToString();
				}
				string cmdText9 = fun.select("CityName", "tblCity", "CityId='" + DelCity + "' ");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, myConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				string cmdText10 = fun.select("StateName", "tblState", "SId='" + DelState + "' ");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, myConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				string cmdText11 = fun.select("CountryName", "tblCountry", "CId='" + DelCountry + "' ");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, myConnection);
				new SqlDataAdapter(selectCommand11);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter8.Fill(dataSet11);
				if (dataSet9.Tables[0].Rows.Count > 0)
				{
					delcity = dataSet9.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					delstate = dataSet10.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					delcountry = dataSet11.Tables[0].Rows[0]["CountryName"].ToString();
				}
				string text4 = "";
				string cmdText12 = fun.select("QuotationNo", " SD_Cust_Quotation_Master", "Id='" + dataSet.Tables[0].Rows[0]["QuotationNo"].ToString() + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand12 = new SqlCommand(cmdText12, myConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter11.Fill(dataSet12, "SD_Cust_Quotation_Master");
				text4 = ((dataSet12.Tables[0].Rows.Count <= 0) ? "NA" : dataSet12.Tables[0].Rows[0]["QuotationNo"].ToString());
				report.SetParameterValue("QuotNo", (object)text4);
				report.SetParameterValue("RegCity", (object)regcity);
				report.SetParameterValue("RegState", (object)regstate);
				report.SetParameterValue("RegCountry", (object)regcountry);
				report.SetParameterValue("WrkCity", (object)workcity);
				report.SetParameterValue("WrkState", (object)workstate);
				report.SetParameterValue("WrkCountry", (object)workcountry);
				report.SetParameterValue("DelCity", (object)delcity);
				report.SetParameterValue("DelState", (object)delstate);
				report.SetParameterValue("DelCountry", (object)delcountry);
				report.SetParameterValue("PODate", (object)PODate);
				report.SetParameterValue("PORecDate", (object)PORecDate);
				string text5 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text5);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				((Control)(object)CrystalReportViewer1).EnableViewState = true;
				Session[Key] = report;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				myConnection.Close();
				myConnection.Dispose();
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
		base.Response.Redirect("CustPO_Print.aspx?ModId=2&SubModId=11");
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

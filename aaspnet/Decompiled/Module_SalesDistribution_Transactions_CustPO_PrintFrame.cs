using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_SalesDistribution_Transactions_CustPO_PrintFrame : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string connStr1 = "";

	private SqlConnection myConnection;

	private ReportDocument report = new ReportDocument();

	private string custId = "";

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

	private string regcity = "";

	private string regstate = "";

	private string regcountry = "";

	private string workcity = "";

	private string workstate = "";

	private string workcountry = "";

	private string delcity = "";

	private string delstate = "";

	private string delcountry = "";

	private string strcustId = "";

	private string strenqId = "";

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a77: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr1 = fun.Connection();
			myConnection = new SqlConnection(connStr1);
			try
			{
				myConnection.Open();
				CompId = Convert.ToInt32(Session["compid"]);
				strcustId = base.Request.QueryString["PONo"].ToString();
				strenqId = base.Request.QueryString["EnqId"].ToString();
				string cmdText = "SELECT *  FROM SD_Cust_PO_Master WHERE PONo='" + strcustId + "' And EnqId='" + strenqId + "' And CompId='" + CompId + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, myConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_PO_Master");
				string text = base.Server.MapPath("~/Module/SalesDistribution/Transactions/Reports/CustPO.rpt");
				report.Load(text);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					custId = dataSet.Tables[0].Rows[0]["CustomerId"].ToString();
					regdate = dataSet.Tables[0].Rows[0]["PODate"].ToString();
					PODate = fun.FromDateDMY(regdate);
					prdate = dataSet.Tables[0].Rows[0]["POReceivedDate"].ToString();
					PORecDate = fun.FromDate(prdate);
				}
				string cmdText2 = "SELECT *  FROM SD_Cust_master WHERE EnqId='" + strenqId + "'And CompId='" + CompId + "' ";
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
				string cmdText3 = "SELECT CityName FROM tblCity WHERE CityId='" + RegCity + "' ";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, myConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = "SELECT StateName FROM tblState WHERE SId='" + RegState + "' ";
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, myConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string cmdText5 = "SELECT CountryName FROM tblCountry WHERE CId='" + RegCountry + "' ";
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
				string cmdText6 = "SELECT CityName FROM tblCity WHERE CityId='" + WorkCity + "' ";
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, myConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				string cmdText7 = "SELECT StateName FROM tblState WHERE SId='" + WorkState + "' ";
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, myConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				string cmdText8 = "SELECT CountryName FROM tblCountry WHERE CId='" + WorkCountry + "' ";
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
				string cmdText9 = "SELECT CityName FROM tblCity WHERE CityId='" + DelCity + "' ";
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, myConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				string cmdText10 = "SELECT StateName FROM tblState WHERE SId='" + DelState + "' ";
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, myConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				string cmdText11 = "SELECT CountryName FROM tblCountry WHERE CId='" + DelCountry + "' ";
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
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session["ReportDocument"] = report;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				myConnection.Close();
			}
		}
		ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

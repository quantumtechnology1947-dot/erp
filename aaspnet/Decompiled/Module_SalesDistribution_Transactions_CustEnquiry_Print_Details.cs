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

public class Module_SalesDistribution_Transactions_CustEnquiry_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int CompId;

	private string connStr1 = "";

	private SqlConnection myConnection;

	private string regdate = "";

	private string RegDate = "";

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

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr1 = fun.Connection();
			myConnection = new SqlConnection(connStr1);
			myConnection.Open();
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				Key = base.Request.QueryString["Key"].ToString();
				base.Request.QueryString["CustomerId"].ToString();
				string text = base.Request.QueryString["EnqId"].ToString();
				string cmdText = fun.select("*", "SD_Cust_Enquiry_Master", "EnqId='" + text + "'And CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, myConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_Enquiry_Master");
				string text2 = base.Server.MapPath("~/Module/SalesDistribution/Transactions/Reports/CustEnquiry.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					regdate = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
					RegDate = fun.FromDateDMY(regdate);
					RegCity = dataSet.Tables[0].Rows[0]["RegdCity"].ToString();
					RegState = dataSet.Tables[0].Rows[0]["RegdState"].ToString();
					RegCountry = dataSet.Tables[0].Rows[0]["RegdCountry"].ToString();
					WorkCity = dataSet.Tables[0].Rows[0]["WorkCity"].ToString();
					WorkState = dataSet.Tables[0].Rows[0]["WorkState"].ToString();
					WorkCountry = dataSet.Tables[0].Rows[0]["WorkCountry"].ToString();
					DelCity = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
					DelState = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
					DelCountry = dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
				}
				string cmdText2 = fun.select("CityName", "tblCity", "CityId='" + RegCity + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, myConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("StateName", "tblState", "SId='" + RegState + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, myConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = fun.select("CountryName", "tblCountry", "CId='" + RegCountry + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, myConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					regcity = dataSet2.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					regstate = dataSet3.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					regcountry = dataSet4.Tables[0].Rows[0]["CountryName"].ToString();
				}
				string cmdText5 = fun.select("CityName", "tblCity", "CityId='" + WorkCity + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, myConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				string cmdText6 = fun.select("StateName", "tblState", "SId='" + WorkState + "' ");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, myConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				string cmdText7 = fun.select("CountryName", "tblCountry", "CId='" + WorkCountry + "' ");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, myConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					workcity = dataSet5.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					workstate = dataSet6.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					workcountry = dataSet7.Tables[0].Rows[0]["CountryName"].ToString();
				}
				string cmdText8 = fun.select("CityName", "tblCity", "CityId='" + DelCity + "' ");
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, myConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				string cmdText9 = fun.select("StateName", "tblState", "SId='" + DelState + "' ");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, myConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				string cmdText10 = fun.select("CountryName", "tblCountry", "CId='" + DelCountry + "' ");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, myConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					delcity = dataSet8.Tables[0].Rows[0]["CityName"].ToString();
				}
				if (dataSet9.Tables[0].Rows.Count > 0)
				{
					delstate = dataSet9.Tables[0].Rows[0]["StateName"].ToString();
				}
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					delcountry = dataSet10.Tables[0].Rows[0]["CountryName"].ToString();
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
				report.SetParameterValue("RegDate", (object)RegDate);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				string text3 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				((Control)(object)CrystalReportViewer1).DataBind();
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
		base.Response.Redirect("CustEnquiry_Print.aspx?ModId=2&SubModId=10");
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

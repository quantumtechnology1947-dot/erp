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

public class Module_SalesDistribution_Masters_CustomerMaster_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int cId;

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			try
			{
				cId = Convert.ToInt32(Session["compid"]);
				Key = base.Request.QueryString["Key"].ToString();
				string text = base.Request.QueryString["CustomerId"].ToString();
				string cmdText = "SELECT *  FROM SD_Cust_master WHERE CustomerId='" + text + "'And CompId='" + cId + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
				string text2 = base.Server.MapPath("~/Module/SalesDistribution/Masters/Reports/CustPrint.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet);
				string fD = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
				string text3 = fun.FromDateDMY(fD);
				string text4 = dataSet.Tables[0].Rows[0]["RegdCity"].ToString();
				string text5 = dataSet.Tables[0].Rows[0]["RegdState"].ToString();
				string text6 = dataSet.Tables[0].Rows[0]["RegdCountry"].ToString();
				string text7 = dataSet.Tables[0].Rows[0]["WorkCity"].ToString();
				string text8 = dataSet.Tables[0].Rows[0]["WorkState"].ToString();
				string text9 = dataSet.Tables[0].Rows[0]["WorkCountry"].ToString();
				string text10 = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				string text11 = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				string text12 = dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
				string cmdText2 = "SELECT CityName FROM tblCity WHERE CityId='" + text4 + "' ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = "SELECT StateName FROM tblState WHERE SId='" + text5 + "' ";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = "SELECT CountryName FROM tblCountry WHERE CId='" + text6 + "' ";
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string text13 = dataSet2.Tables[0].Rows[0]["CityName"].ToString();
				string text14 = dataSet3.Tables[0].Rows[0]["StateName"].ToString();
				string text15 = dataSet4.Tables[0].Rows[0]["CountryName"].ToString();
				string cmdText5 = "SELECT CityName FROM tblCity WHERE CityId='" + text7 + "' ";
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				string cmdText6 = "SELECT StateName FROM tblState WHERE SId='" + text8 + "' ";
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				string cmdText7 = "SELECT CountryName FROM tblCountry WHERE CId='" + text9 + "' ";
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				string text16 = dataSet5.Tables[0].Rows[0]["CityName"].ToString();
				string text17 = dataSet6.Tables[0].Rows[0]["StateName"].ToString();
				string text18 = dataSet7.Tables[0].Rows[0]["CountryName"].ToString();
				string cmdText8 = "SELECT CityName FROM tblCity WHERE CityId='" + text10 + "' ";
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				string cmdText9 = "SELECT StateName FROM tblState WHERE SId='" + text11 + "' ";
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				string cmdText10 = "SELECT CountryName FROM tblCountry WHERE CId='" + text12 + "' ";
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				string text19 = dataSet8.Tables[0].Rows[0]["CityName"].ToString();
				string text20 = dataSet9.Tables[0].Rows[0]["StateName"].ToString();
				string text21 = dataSet10.Tables[0].Rows[0]["CountryName"].ToString();
				report.SetParameterValue("RegCity", (object)text13);
				report.SetParameterValue("RegState", (object)text14);
				report.SetParameterValue("RegCountry", (object)text15);
				report.SetParameterValue("WrkCity", (object)text16);
				report.SetParameterValue("WrkState", (object)text17);
				report.SetParameterValue("WrkCountry", (object)text18);
				report.SetParameterValue("DelCity", (object)text19);
				report.SetParameterValue("DelState", (object)text20);
				report.SetParameterValue("DelCountry", (object)text21);
				report.SetParameterValue("RegDate", (object)text3);
				string company = fun.getCompany(cId);
				report.SetParameterValue("Company", (object)company);
				string text22 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text22);
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerMaster_Print.aspx?ModId=2&SubModId=7");
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

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

public class Module_SalesDistribution_Transactions_Quotation_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string connStr1 = "";

	private SqlConnection myConnection;

	private ReportDocument report = new ReportDocument();

	private string QuotationDate = "";

	private string ParentPage = "";

	private string RegCity = "";

	private string RegState = "";

	private string RegCountry = "";

	private string custId = "";

	private int Id;

	private string QuoteNo = "";

	private int FYId;

	private string RegAddress = "";

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a03: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr1 = fun.Connection();
			myConnection = new SqlConnection(connStr1);
			try
			{
				FYId = Convert.ToInt32(Session["finyear"]);
				if (!string.IsNullOrEmpty(base.Request.QueryString["QuotationNo"]))
				{
					QuoteNo = base.Request.QueryString["QuotationNo"].ToString();
				}
				Key = base.Request.QueryString["Key"].ToString();
				string text = "";
				if (!string.IsNullOrEmpty(base.Request.QueryString["EnqId"]))
				{
					text = base.Request.QueryString["EnqId"].ToString();
				}
				Id = Convert.ToInt32(base.Request.QueryString["Id"].ToString());
				CompId = Convert.ToInt32(Session["compid"]);
				myConnection.Open();
				string cmdText = fun.select("*", " SD_Cust_Quotation_Master", "QuotationNo='" + QuoteNo + "' And EnqId='" + text + "' And CompId='" + CompId + "' AND Id='" + Id + "'   ");
				SqlCommand selectCommand = new SqlCommand(cmdText, myConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_Quotation_Master");
				string text2 = base.Server.MapPath("~/Module/SalesDistribution/Transactions/Reports/Quotation.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					custId = dataSet.Tables[0].Rows[0]["CustomerId"].ToString();
					QuotationDate = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
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
				report.SetParameterValue("QuotationDate", (object)QuotationDate);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				string text3 = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DueDate"].ToString());
				report.SetParameterValue("DueDate", (object)text3);
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string cmdText6 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND EmpId='", dataSet.Tables[0].Rows[0]["CheckedBy"], "'"));
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, myConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					text4 = dataSet6.Tables[0].Rows[0][0].ToString();
				}
				string cmdText7 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND EmpId='", dataSet.Tables[0].Rows[0]["ApprovedBy"], "'"));
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, myConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					text5 = dataSet7.Tables[0].Rows[0][0].ToString();
				}
				string cmdText8 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND EmpId='", dataSet.Tables[0].Rows[0]["AuthorizedBy"], "'"));
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, myConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					text6 = dataSet8.Tables[0].Rows[0][0].ToString();
				}
				RegAddress = dataSet2.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + dataSet3.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet4.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet5.Tables[0].Rows[0]["CountryName"].ToString() + ".\n" + dataSet2.Tables[0].Rows[0]["RegdPinNo"].ToString() + "\n";
				report.SetParameterValue("RegAddress", (object)RegAddress);
				report.SetParameterValue("QuatCheck", (object)text4);
				report.SetParameterValue("QuatApprove", (object)text5);
				report.SetParameterValue("QuatAuth", (object)text6);
				string text7 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text7);
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
		if (!string.IsNullOrEmpty(base.Request.QueryString["parentpage"]))
		{
			ParentPage = base.Request.QueryString["parentpage"].ToString();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		if (ParentPage == "1")
		{
			base.Response.Redirect("Quotation_Check.aspx?ModId=2&SubModId=64");
		}
		else if (ParentPage == "2")
		{
			base.Response.Redirect("Quotation_Print.aspx?ModId=2&SubModId=63");
		}
		else if (ParentPage == "3")
		{
			base.Response.Redirect("Quotation_Approve.aspx?ModId=2&SubModId=65");
		}
		else if (ParentPage == "4")
		{
			base.Response.Redirect("Quotation_Authorize.aspx?ModId=2&SubModId=66");
		}
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

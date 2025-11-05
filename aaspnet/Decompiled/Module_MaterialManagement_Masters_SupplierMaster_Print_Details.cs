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

public class Module_MaterialManagement_Masters_SupplierMaster_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int cId;

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3b: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!base.IsPostBack)
			{
				sqlConnection.Open();
				cId = Convert.ToInt32(Session["compid"]);
				string text = base.Request.QueryString["SupplierId"].ToString();
				string cmdText = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + text + "'And CompId='" + cId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
				string text2 = base.Server.MapPath("../Reports/SupplierPrintReport.rpt");
				report.Load(text2);
				report.SetDataSource(dataSet);
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					return;
				}
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
				string text13 = dataSet.Tables[0].Rows[0]["ServiceCoverage"].ToString();
				string text14 = dataSet.Tables[0].Rows[0]["PF"].ToString();
				string text15 = dataSet.Tables[0].Rows[0]["ExST"].ToString();
				string text16 = dataSet.Tables[0].Rows[0]["VAT"].ToString();
				string text17 = "";
				DataSet dataSet2 = new DataSet();
				string cmdText2 = fun.select1("*", "tblMM_Supplier_BusinessType");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblMM_Supplier_BusinessType");
				string text18 = dataSet.Tables[0].Rows[0]["BusinessType"].ToString();
				string[] array = text18.Split(',');
				foreach (string text19 in array)
				{
					if (text19 != "")
					{
						int index = Convert.ToInt32(text19);
						text17 = string.Concat(text17, dataSet2.Tables[0].Rows[index]["Type"], ",".ToString());
					}
				}
				string text20 = string.Empty;
				string cmdText3 = fun.select1("*", "tblMM_Supplier_BusinessNature");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblMM_Supplier_BusinessNature");
				string text21 = dataSet.Tables[0].Rows[0]["BusinessNature"].ToString();
				string[] array2 = text21.Split(',');
				foreach (string text22 in array2)
				{
					if (text22 != "")
					{
						int index2 = Convert.ToInt32(text22);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							text20 = string.Concat(text20, dataSet3.Tables[0].Rows[index2]["Nature"], ",".ToString());
						}
					}
				}
				string cmdText4 = fun.select("Type", "tblMM_Supplier_ServiceCoverage", "Id='" + text13 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				string text23 = "";
				if (sqlDataReader.HasRows)
				{
					text23 = sqlDataReader["Type"].ToString();
				}
				string text24 = "";
				text24 = ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["ModVatApplicable"]) <= 0) ? "No" : "Yes");
				string text25 = "";
				text25 = ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["ModVatInvoice"]) <= 0) ? "No" : "Yes");
				string cmdText5 = fun.select("CityName", "tblCity", "CityId='" + text4 + "' ");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				string text26 = "";
				if (sqlDataReader2.HasRows)
				{
					text26 = sqlDataReader2["CityName"].ToString();
				}
				string cmdText6 = fun.select("StateName", "tblState", "SId='" + text5 + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				string text27 = "";
				if (sqlDataReader3.HasRows)
				{
					text27 = sqlDataReader3["StateName"].ToString();
				}
				string cmdText7 = fun.select("CountryName", "tblCountry", "CId='" + text6 + "' ");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				string text28 = "";
				if (sqlDataReader4.HasRows)
				{
					text28 = sqlDataReader4["CountryName"].ToString();
				}
				string cmdText8 = fun.select("CityName", "tblCity", "CityId='" + text7 + "' ");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				string text29 = "";
				if (sqlDataReader5.HasRows)
				{
					text29 = sqlDataReader5["CityName"].ToString();
				}
				string cmdText9 = fun.select("StateName", "tblState", "SId='" + text8 + "' ");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				string text30 = "";
				if (sqlDataReader6.HasRows)
				{
					text30 = sqlDataReader6["StateName"].ToString();
				}
				string cmdText10 = fun.select("CountryName", "tblCountry", "CId='" + text9 + "' ");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				string text31 = "";
				if (sqlDataReader7.HasRows)
				{
					text31 = sqlDataReader7["CountryName"].ToString();
				}
				string cmdText11 = fun.select("CityName", "tblCity", "CityId='" + text10 + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				string text32 = string.Empty;
				if (sqlDataReader8.HasRows)
				{
					text32 = sqlDataReader8["CityName"].ToString();
				}
				string cmdText12 = fun.select("StateName", "tblState", "SId='" + text11 + "'");
				SqlCommand sqlCommand9 = new SqlCommand(cmdText12, sqlConnection);
				SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
				sqlDataReader9.Read();
				string text33 = string.Empty;
				if (sqlDataReader9.HasRows)
				{
					text33 = sqlDataReader9["StateName"].ToString();
				}
				string cmdText13 = fun.select("CountryName", "tblCountry", "CId='" + text12 + "'");
				SqlCommand sqlCommand10 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
				sqlDataReader10.Read();
				string text34 = string.Empty;
				if (sqlDataReader10.HasRows)
				{
					text34 = sqlDataReader10["CountryName"].ToString();
				}
				report.SetParameterValue("RegCity", (object)text26);
				report.SetParameterValue("RegState", (object)text27);
				report.SetParameterValue("RegCountry", (object)text28);
				report.SetParameterValue("WrkCity", (object)text29);
				report.SetParameterValue("WrkState", (object)text30);
				report.SetParameterValue("WrkCountry", (object)text31);
				report.SetParameterValue("DelCity", (object)text32);
				report.SetParameterValue("DelState", (object)text33);
				report.SetParameterValue("DelCountry", (object)text34);
				report.SetParameterValue("RegDate", (object)text3);
				string company = fun.getCompany(cId);
				report.SetParameterValue("Company", (object)company);
				string text35 = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text35);
				report.SetParameterValue("ModVatApplicable", (object)text24);
				report.SetParameterValue("ModVatInvoice", (object)text25);
				report.SetParameterValue("BusinessType", (object)text17);
				report.SetParameterValue("BusinessNature", (object)text20);
				report.SetParameterValue("ServiceCoverage", (object)text23);
				report.SetParameterValue("VAT", (object)text23);
				string cmdText14 = fun.select("Terms", "tblPacking_Master", "Id='" + text14 + "'");
				SqlCommand sqlCommand11 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataReader sqlDataReader11 = sqlCommand11.ExecuteReader();
				sqlDataReader11.Read();
				string text36 = string.Empty;
				if (sqlDataReader11.HasRows)
				{
					text36 = sqlDataReader11["Terms"].ToString();
				}
				report.SetParameterValue("PF", (object)text36);
				string cmdText15 = fun.select("Terms", "tblExciseser_Master", "Id='" + text15 + "'");
				SqlCommand sqlCommand12 = new SqlCommand(cmdText15, sqlConnection);
				SqlDataReader sqlDataReader12 = sqlCommand12.ExecuteReader();
				sqlDataReader12.Read();
				string text37 = string.Empty;
				if (sqlDataReader12.HasRows)
				{
					text37 = sqlDataReader12["Terms"].ToString();
				}
				report.SetParameterValue("ExST", (object)text37);
				string cmdText16 = fun.select("Terms", "tblVAT_Master", "Id='" + text16 + "'");
				SqlCommand sqlCommand13 = new SqlCommand(cmdText16, sqlConnection);
				SqlDataReader sqlDataReader13 = sqlCommand13.ExecuteReader();
				sqlDataReader13.Read();
				string text38 = string.Empty;
				if (sqlDataReader13.HasRows)
				{
					text38 = sqlDataReader13["Terms"].ToString();
				}
				report.SetParameterValue("VAT", (object)text38);
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

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SupplierMaster_Print.aspx?ModId=6&SubModId=22");
	}
}

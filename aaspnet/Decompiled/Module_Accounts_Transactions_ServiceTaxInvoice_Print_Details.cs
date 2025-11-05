using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_ServiceTaxInvoice_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string invId = "";

	private string CCode = "";

	private string InvNo = "";

	private string PrintType = "";

	private ReportDocument cryRpt = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac2: Expected O, but got Unknown
		//IL_10d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!base.IsPostBack)
			{
				Key = base.Request.QueryString["Key"].ToString();
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
				sqlConnection.Open();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				invId = fun.Decrypt(base.Request.QueryString["invid"].ToString());
				InvNo = fun.Decrypt(base.Request.QueryString["InvNo"]);
				CCode = fun.Decrypt(base.Request.QueryString["cid"].ToString());
				PrintType = fun.Decrypt(base.Request.QueryString["PT"].ToString());
				string cmdText = fun.select("*", "tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' AND InvoiceNo='" + InvNo + "' AND Id='" + invId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DateOfIssueInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("TimeOfIssueInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DutyRate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CustomerCategory", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_cotper", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_ph", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_email", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_ecc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_tin", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_mob", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_fax", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Buyer_vat", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_cotper", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_ph", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_email", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_ecc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_tin", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_mob", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_fax", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cong_vat", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AddType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("AddAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DeductionType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Deduction", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ServiceTax", typeof(int)));
				dataTable.Columns.Add(new DataColumn("TaxableServices", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
				DataSet dataSet2 = new DataSet();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet.Tables[0].Rows[0]["Id"].ToString();
						dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
						dataRow[2] = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString();
						dataRow[3] = dataSet.Tables[0].Rows[0]["PONo"].ToString();
						string text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
						string[] array = text.Split(',');
						string text2 = "";
						for (int j = 0; j < array.Length - 1; j++)
						{
							string cmdText2 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[j] + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter2.Fill(dataSet3);
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								text2 = text2 + dataSet3.Tables[0].Rows[0][0].ToString() + ",";
							}
						}
						dataRow[4] = text2;
						dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
						dataRow[6] = dataSet.Tables[0].Rows[0]["CompId"].ToString();
						dataRow[7] = dataSet.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
						dataRow[8] = dataSet.Tables[0].Rows[0]["DutyRate"].ToString();
						dataRow[9] = dataSet.Tables[0].Rows[0]["CustomerCode"].ToString();
						string cmdText3 = fun.select("Description", "tblACC_Service_Category", string.Concat("Id='", dataSet.Tables[0].Rows[0]["CustomerCategory"], "'"));
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[10] = dataSet4.Tables[0].Rows[0]["Description"].ToString();
						}
						dataRow[11] = dataSet.Tables[0].Rows[0]["Buyer_name"].ToString();
						dataRow[12] = dataSet.Tables[0].Rows[0]["Buyer_cotper"].ToString();
						dataRow[13] = dataSet.Tables[0].Rows[0]["Buyer_ph"].ToString();
						dataRow[14] = dataSet.Tables[0].Rows[0]["Buyer_email"].ToString();
						dataRow[15] = dataSet.Tables[0].Rows[0]["Buyer_ecc"].ToString();
						dataRow[16] = dataSet.Tables[0].Rows[0]["Buyer_tin"].ToString();
						dataRow[17] = dataSet.Tables[0].Rows[0]["Buyer_mob"].ToString();
						dataRow[18] = dataSet.Tables[0].Rows[0]["Buyer_fax"].ToString();
						dataRow[19] = dataSet.Tables[0].Rows[0]["Buyer_vat"].ToString();
						dataRow[20] = dataSet.Tables[0].Rows[0]["Cong_name"].ToString();
						dataRow[21] = dataSet.Tables[0].Rows[0]["Cong_cotper"].ToString();
						dataRow[22] = dataSet.Tables[0].Rows[0]["Cong_ph"].ToString();
						dataRow[23] = dataSet.Tables[0].Rows[0]["Cong_email"].ToString();
						dataRow[24] = dataSet.Tables[0].Rows[0]["Cong_ecc"].ToString();
						dataRow[25] = dataSet.Tables[0].Rows[0]["Cong_tin"].ToString();
						dataRow[26] = dataSet.Tables[0].Rows[0]["Cong_mob"].ToString();
						dataRow[27] = dataSet.Tables[0].Rows[0]["Cong_fax"].ToString();
						dataRow[28] = dataSet.Tables[0].Rows[0]["Cong_vat"].ToString();
						dataRow[29] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["AddType"].ToString());
						dataRow[30] = dataSet.Tables[0].Rows[0]["AddAmt"].ToString();
						dataRow[31] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DeductionType"].ToString());
						dataRow[32] = dataSet.Tables[0].Rows[0]["Deduction"].ToString();
						dataRow[33] = dataSet.Tables[0].Rows[0]["ServiceTax"].ToString();
						string cmdText4 = fun.select("Description", "tblACC_TaxableServices", string.Concat("Id='", dataSet.Tables[0].Rows[0]["TaxableServices"], "'"));
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							dataRow[34] = dataSet5.Tables[0].Rows[0]["Description"].ToString();
						}
						string cmdText5 = fun.select("SysDate As PODate", "SD_Cust_PO_Master", string.Concat("POId='", dataSet.Tables[0].Rows[0]["POId"], "' And CompId='", CompId, "'"));
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6);
						dataRow[35] = fun.FromDateDMY(dataSet6.Tables[0].Rows[0]["PODate"].ToString());
						dataRow[36] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["POId"]);
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet7 = new SerTaxInvoice();
				dataSet7.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet7.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/ServiceTaxInvoice.rpt"));
				cryRpt.SetDataSource(dataSet7);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText6 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[0]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[0]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					sqlDataAdapter6.Fill(DS, "Financial");
					string text3 = "";
					if (DS.Tables[0].Rows.Count > 0)
					{
						string fDY = DS.Tables[0].Rows[0]["FinYearFrom"].ToString();
						string text4 = fun.FromDateYear(fDY);
						string text5 = text4.Substring(2);
						string tDY = DS.Tables[0].Rows[0]["FinYearTo"].ToString();
						string text6 = fun.ToDateYear(tDY);
						string text7 = text6.Substring(2);
						text3 = text5 + text7;
						string text8 = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString() + "/" + text3;
						cryRpt.SetParameterValue("InvoiceNo", (object)text8);
					}
					string text9 = dataSet.Tables[0].Rows[0]["Buyer_add"].ToString();
					string cmdText7 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Buyer_country"], "'"));
					string cmdText8 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Buyer_state"], "'"));
					string cmdText9 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Buyer_city"], "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet8 = new DataSet();
					DataSet dataSet9 = new DataSet();
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter7.Fill(dataSet8, "tblCountry");
					sqlDataAdapter8.Fill(dataSet9, "tblState");
					sqlDataAdapter9.Fill(dataSet10, "tblcity");
					string text10 = text9 + ",\n" + dataSet10.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet9.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet8.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Buyer_Address", (object)text10);
					string text11 = dataSet.Tables[0].Rows[0]["Cong_add"].ToString();
					string cmdText10 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Cong_country"], "'"));
					string cmdText11 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Cong_state"], "'"));
					string cmdText12 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Cong_city"], "'"));
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
					SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					DataSet dataSet11 = new DataSet();
					DataSet dataSet12 = new DataSet();
					DataSet dataSet13 = new DataSet();
					sqlDataAdapter10.Fill(dataSet11, "tblCountry");
					sqlDataAdapter11.Fill(dataSet12, "tblState");
					sqlDataAdapter12.Fill(dataSet13, "tblcity");
					string text12 = text11 + ",\n" + dataSet13.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet12.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet11.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Consignee_Address", (object)text12);
					string cmdText13 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
					SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
					SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
					DataSet dataSet14 = new DataSet();
					sqlDataAdapter13.Fill(dataSet14, "tblCompany_master");
					string text13 = dataSet14.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + fun.getCity(Convert.ToInt32(dataSet14.Tables[0].Rows[0]["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(dataSet14.Tables[0].Rows[0]["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(dataSet14.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dataSet14.Tables[0].Rows[0]["RegdPinCode"].ToString() + ".\nPh No.-" + dataSet14.Tables[0].Rows[0]["RegdContactNo"].ToString() + ",  Fax No.-" + dataSet14.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "\nEmail No.-" + dataSet14.Tables[0].Rows[0]["RegdEmail"].ToString();
					cryRpt.SetParameterValue("Address", (object)text13);
					string fD = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
					string s = fun.FromDateMDY(fD);
					DateTime dt = DateTime.Parse(s);
					string text14 = fun.DateToText(dt, includeTime: false, isUK: true);
					string timeSel = dataSet.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
					string text15 = fun.TimeToText(timeSel);
					cryRpt.SetParameterValue("wordsIss", (object)text14);
					cryRpt.SetParameterValue("wordsIssTime", (object)text15);
				}
				cryRpt.SetParameterValue("PrintType", (object)PrintType);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
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
		cryRpt = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Print.aspx?ModId=11&SubModId=52");
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}
}

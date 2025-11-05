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

public class Module_Accounts_Transactions_SalesInvoice_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string InvId = "";

	private string WN = "";

	private string CCode = "";

	private string InvNo = "";

	private string PrintType = "";

	private ReportDocument cryRpt = new ReportDocument();

	private string Key = string.Empty;

	private string Key1 = string.Empty;

	private int Type;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_27a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a9: Expected O, but got Unknown
		//IL_1929: Unknown result type (might be due to invalid IL or missing references)
		//IL_1933: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		Key = base.Request.QueryString["Key"].ToString();
		try
		{
			if (!base.IsPostBack)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
				string empty = string.Empty;
				sqlConnection.Open();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				InvId = base.Request.QueryString["InvId"].ToString();
				InvNo = base.Request.QueryString["InvNo"];
				CCode = base.Request.QueryString["cid"].ToString();
				PrintType = base.Request.QueryString["PT"].ToString();
				SqlCommand selectCommand = new SqlCommand(fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "'  And InvoiceNo='" + InvNo + "' And Id='" + InvId + "'"), sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InvoiceMode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DateOfIssueInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DateOfRemoval", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TimeOfIssueInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TimeOfRemoval", typeof(string)));
				dataTable.Columns.Add(new DataColumn("NatureOfRemoval", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Commodity", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TariffHeading", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ModeOfTransport", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RRGCNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("VehiRegNo", typeof(string)));
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
				dataTable.Columns.Add(new DataColumn("PFType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("PF", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CENVAT", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SED", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AED", typeof(double)));
				dataTable.Columns.Add(new DataColumn("VAT", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SelectedCST", typeof(int)));
				dataTable.Columns.Add(new DataColumn("CST", typeof(double)));
				dataTable.Columns.Add(new DataColumn("FreightType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
				dataTable.Columns.Add(new DataColumn("InsuranceType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Insurance", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AEDType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SEDType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("OtherAmt", typeof(double)));
				DataSet dataSet2 = new DataSet();
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[0]["Id"].ToString();
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[2] = dataSet.Tables[0].Rows[0]["CompId"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[0]["PONo"].ToString();
					WN = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					string[] array = WN.Split(',');
					string text = "";
					for (int i = 0; i < array.Length - 1; i++)
					{
						string cmdText = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[i] + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							text = text + dataSet3.Tables[0].Rows[0][0].ToString() + ",";
						}
					}
					dataRow[5] = text;
					dataRow[6] = dataSet.Tables[0].Rows[0]["InvoiceMode"].ToString();
					dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
					dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfRemoval"].ToString());
					dataRow[9] = dataSet.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["TimeOfRemoval"].ToString();
					string cmdText2 = fun.select("Description", "tblACC_Removable_Nature", string.Concat("Id='", dataSet.Tables[0].Rows[0]["NatureOfRemoval"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[11] = dataSet4.Tables[0].Rows[0]["Description"].ToString();
					}
					string cmdText3 = fun.select("*", "tblExciseCommodity_Master", string.Concat("Id='", dataSet.Tables[0].Rows[0]["Commodity"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[12] = dataSet5.Tables[0].Rows[0]["Terms"].ToString();
						dataRow[13] = dataSet5.Tables[0].Rows[0]["ChapHead"].ToString();
					}
					string cmdText4 = fun.select("Description", "tblACC_TransportMode", string.Concat("Id='", dataSet.Tables[0].Rows[0]["ModeOfTransport"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[14] = dataSet6.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[15] = dataSet.Tables[0].Rows[0]["RRGCNo"].ToString();
					dataRow[16] = dataSet.Tables[0].Rows[0]["VehiRegNo"].ToString();
					dataRow[17] = dataSet.Tables[0].Rows[0]["DutyRate"].ToString();
					dataRow[18] = dataSet.Tables[0].Rows[0]["CustomerCode"].ToString();
					string cmdText5 = fun.select("Description", "tblACC_Service_Category", string.Concat("Id='", dataSet.Tables[0].Rows[0]["CustomerCategory"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[19] = dataSet7.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[20] = dataSet.Tables[0].Rows[0]["Buyer_name"].ToString();
					dataRow[21] = dataSet.Tables[0].Rows[0]["Buyer_cotper"].ToString();
					dataRow[22] = dataSet.Tables[0].Rows[0]["Buyer_ph"].ToString();
					dataRow[23] = dataSet.Tables[0].Rows[0]["Buyer_email"].ToString();
					dataRow[24] = dataSet.Tables[0].Rows[0]["Buyer_ecc"].ToString();
					dataRow[25] = dataSet.Tables[0].Rows[0]["Buyer_tin"].ToString();
					dataRow[26] = dataSet.Tables[0].Rows[0]["Buyer_mob"].ToString();
					dataRow[27] = dataSet.Tables[0].Rows[0]["Buyer_fax"].ToString();
					dataRow[28] = dataSet.Tables[0].Rows[0]["Buyer_vat"].ToString();
					dataRow[29] = dataSet.Tables[0].Rows[0]["Cong_name"].ToString();
					dataRow[30] = dataSet.Tables[0].Rows[0]["Cong_cotper"].ToString();
					dataRow[31] = dataSet.Tables[0].Rows[0]["Cong_ph"].ToString();
					dataRow[32] = dataSet.Tables[0].Rows[0]["Cong_email"].ToString();
					dataRow[33] = dataSet.Tables[0].Rows[0]["Cong_ecc"].ToString();
					dataRow[34] = dataSet.Tables[0].Rows[0]["Cong_tin"].ToString();
					dataRow[35] = dataSet.Tables[0].Rows[0]["Cong_mob"].ToString();
					dataRow[36] = dataSet.Tables[0].Rows[0]["Cong_fax"].ToString();
					dataRow[37] = dataSet.Tables[0].Rows[0]["Cong_vat"].ToString();
					dataRow[38] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["AddType"].ToString());
					dataRow[39] = dataSet.Tables[0].Rows[0]["AddAmt"].ToString();
					dataRow[40] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DeductionType"].ToString());
					dataRow[41] = dataSet.Tables[0].Rows[0]["Deduction"].ToString();
					dataRow[42] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PFType"].ToString());
					dataRow[43] = dataSet.Tables[0].Rows[0]["PF"].ToString();
					dataRow[44] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CENVAT"].ToString());
					dataRow[45] = dataSet.Tables[0].Rows[0]["SED"].ToString();
					dataRow[46] = dataSet.Tables[0].Rows[0]["AED"].ToString();
					dataRow[47] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["VAT"].ToString());
					dataRow[48] = dataSet.Tables[0].Rows[0]["SelectedCST"].ToString();
					dataRow[49] = dataSet.Tables[0].Rows[0]["CST"].ToString();
					dataRow[50] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FreightType"].ToString());
					dataRow[51] = dataSet.Tables[0].Rows[0]["Freight"].ToString();
					dataRow[52] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["InsuranceType"].ToString());
					dataRow[53] = dataSet.Tables[0].Rows[0]["Insurance"].ToString();
					string cmdText6 = fun.select("PODate", "SD_Cust_PO_Master", string.Concat("POId='", dataSet.Tables[0].Rows[0]["POId"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter7.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						dataRow[54] = fun.FromDateDMY(dataSet8.Tables[0].Rows[0]["PODate"].ToString());
					}
					dataRow[55] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["AEDType"].ToString());
					dataRow[56] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SEDType"].ToString());
					dataRow[57] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["POId"]);
					double num = 0.0;
					if (dataSet.Tables[0].Rows[0]["OtherAmt"] != DBNull.Value)
					{
						num = Convert.ToDouble(dataSet.Tables[0].Rows[0]["OtherAmt"]);
					}
					dataRow[58] = num;
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet9 = new SalesInvoice();
				dataSet9.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet9.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/SalesInvoice.rpt"));
				cryRpt.SetDataSource(dataSet9);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText7 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[0]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[0]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand8 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					sqlDataAdapter8.Fill(DS, "Financial");
					string text2 = "";
					if (DS.Tables[0].Rows.Count > 0)
					{
						string fDY = DS.Tables[0].Rows[0]["FinYearFrom"].ToString();
						string text3 = fun.FromDateYear(fDY);
						string text4 = text3.Substring(2);
						string tDY = DS.Tables[0].Rows[0]["FinYearTo"].ToString();
						string text5 = fun.ToDateYear(tDY);
						string text6 = text5.Substring(2);
						text2 = text4 + text6;
						string text7 = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString() + "/" + text2;
						cryRpt.SetParameterValue("InvoiceNo", (object)text7);
					}
					string text8 = dataSet.Tables[0].Rows[0]["Buyer_add"].ToString();
					string cmdText8 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Buyer_country"], "'"));
					string cmdText9 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Buyer_state"], "'"));
					string cmdText10 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Buyer_city"], "'"));
					SqlCommand selectCommand9 = new SqlCommand(cmdText8, sqlConnection);
					SqlCommand selectCommand10 = new SqlCommand(cmdText9, sqlConnection);
					SqlCommand selectCommand11 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet10 = new DataSet();
					DataSet dataSet11 = new DataSet();
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter9.Fill(dataSet10, "tblCountry");
					sqlDataAdapter10.Fill(dataSet11, "tblState");
					sqlDataAdapter11.Fill(dataSet12, "tblcity");
					string text9 = text8 + ",\n" + dataSet12.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet11.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet10.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Buyer_Address", (object)text9);
					string text10 = dataSet.Tables[0].Rows[0]["Cong_add"].ToString();
					string cmdText11 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Cong_country"], "'"));
					string cmdText12 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Cong_state"], "'"));
					string cmdText13 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Cong_city"], "'"));
					SqlCommand selectCommand12 = new SqlCommand(cmdText11, sqlConnection);
					SqlCommand selectCommand13 = new SqlCommand(cmdText12, sqlConnection);
					SqlCommand selectCommand14 = new SqlCommand(cmdText13, sqlConnection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
					SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
					DataSet dataSet13 = new DataSet();
					DataSet dataSet14 = new DataSet();
					DataSet dataSet15 = new DataSet();
					sqlDataAdapter12.Fill(dataSet13, "tblCountry");
					sqlDataAdapter13.Fill(dataSet14, "tblState");
					sqlDataAdapter14.Fill(dataSet15, "tblcity");
					string text11 = text10 + ",\n" + dataSet15.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet14.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet13.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Consignee_Address", (object)text11);
					string cmdText14 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
					SqlCommand selectCommand15 = new SqlCommand(cmdText14, sqlConnection);
					SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
					DataSet dataSet16 = new DataSet();
					sqlDataAdapter15.Fill(dataSet16, "tblCompany_master");
					string text12 = dataSet16.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + fun.getCity(Convert.ToInt32(dataSet16.Tables[0].Rows[0]["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(dataSet16.Tables[0].Rows[0]["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(dataSet16.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dataSet16.Tables[0].Rows[0]["RegdPinCode"].ToString() + ".\nPh No.-" + dataSet16.Tables[0].Rows[0]["RegdContactNo"].ToString() + ",  Fax No.-" + dataSet16.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "\nEmail No.-" + dataSet16.Tables[0].Rows[0]["RegdEmail"].ToString();
					cryRpt.SetParameterValue("Address", (object)text12);
					int num2 = 0;
					double num3 = 0.0;
					double num4 = 0.0;
					string text13 = "";
					string text14 = "";
					string text15 = "";
					string text16 = "";
					string text17 = "";
					string text18 = "";
					text18 = ((!(dataSet.Tables[0].Rows[0]["FreightType"].ToString() == "0")) ? "Per(%)" : "Amt(Rs)");
					if (dataSet.Tables[0].Rows[0]["InvoiceMode"].ToString() == "2")
					{
						text13 = "Freight";
						text14 = "VAT";
						string cmdText15 = fun.select("Terms,Value", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[0]["VAT"].ToString() + "'");
						SqlCommand selectCommand16 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
						DataSet dataSet17 = new DataSet();
						sqlDataAdapter16.Fill(dataSet17, "tblVAT_Master");
						if (dataSet17.Tables[0].Rows.Count > 0)
						{
							text15 = Convert.ToString(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Freight"].ToString())) + "   " + text18;
							text16 = dataSet17.Tables[0].Rows[0]["Terms"].ToString();
							num4 = Convert.ToDouble(dataSet17.Tables[0].Rows[0]["Value"].ToString());
						}
					}
					else if (dataSet.Tables[0].Rows[0]["InvoiceMode"].ToString() == "3")
					{
						text13 = "CST";
						text14 = "Freight";
						text17 = ((!(dataSet.Tables[0].Rows[0]["SelectedCST"].ToString() == "0")) ? "Without C Form" : "With C Form");
						text16 = dataSet.Tables[0].Rows[0]["Freight"].ToString() + "  " + text18;
						string cmdText16 = fun.select("Terms,Value", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[0]["CST"].ToString() + "'");
						SqlCommand selectCommand17 = new SqlCommand(cmdText16, sqlConnection);
						SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
						DataSet dataSet18 = new DataSet();
						sqlDataAdapter17.Fill(dataSet18, "tblVAT_Master");
						text15 = dataSet18.Tables[0].Rows[0]["Terms"].ToString() + " " + text17;
						num4 = Convert.ToDouble(dataSet18.Tables[0].Rows[0]["Value"].ToString());
					}
					num3 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Freight"].ToString());
					num2 = ((!(dataSet.Tables[0].Rows[0]["FreightType"].ToString() == "0")) ? 1 : 0);
					cryRpt.SetParameterValue("x", (object)text13);
					cryRpt.SetParameterValue("y", (object)text14);
					cryRpt.SetParameterValue("m", (object)text15);
					cryRpt.SetParameterValue("n", (object)text16);
					cryRpt.SetParameterValue("F", (object)num3);
					cryRpt.SetParameterValue("V", (object)num4);
					cryRpt.SetParameterValue("z", (object)num2);
					string fD = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfRemoval"].ToString());
					string s = fun.FromDateMDY(fD);
					DateTime dt = DateTime.Parse(s);
					empty = fun.DateToText(dt, includeTime: false, isUK: true);
					string timeSel = dataSet.Tables[0].Rows[0]["TimeOfRemoval"].ToString();
					string text19 = fun.TimeToText(timeSel);
					cryRpt.SetParameterValue("wordsRem", (object)empty);
					cryRpt.SetParameterValue("wordsRemTime", (object)text19);
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
		Type = Convert.ToInt32(base.Request.QueryString["T"]);
		Key1 = base.Request.QueryString["K"].ToString();
		CCode = base.Request.QueryString["cid"].ToString();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		switch (Type)
		{
		case 0:
			base.Response.Redirect("SalesInvoice_Print.aspx?ModId=11&SubModId=51");
			break;
		case 1:
			base.Response.Redirect("~/Module/Accounts/Transactions/Acc_Sundry_Details.aspx?CustId=" + CCode + "&ModId=11&SubModId=&Key=" + Key1);
			break;
		}
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

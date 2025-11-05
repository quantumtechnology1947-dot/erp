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

public class Module_Accounts_Transactions_ProformaInvoice_Print_Details : Page, IRequiresSessionState
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

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_17e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ec: Expected O, but got Unknown
		//IL_0ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb0: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		if (!base.IsPostBack)
		{
			Key = base.Request.QueryString["Key"].ToString();
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
			_ = string.Empty;
			sqlConnection.Open();
			try
			{
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				InvId = base.Request.QueryString["InvId"].ToString();
				InvNo = base.Request.QueryString["InvNo"];
				CCode = base.Request.QueryString["cid"].ToString();
				PrintType = base.Request.QueryString["PT"].ToString();
				string cmdText = fun.select("*", "tblACC_ProformaInvoice_Master", "CompId='" + CompId + "'  And InvoiceNo='" + InvNo + "' And Id='" + InvId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
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
				dataTable.Columns.Add(new DataColumn("TimeOfIssueInvoice", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
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
				dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
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
						string cmdText2 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[i] + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
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
					dataRow[8] = dataSet.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["CustomerCode"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["Buyer_name"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[0]["Buyer_cotper"].ToString();
					dataRow[12] = dataSet.Tables[0].Rows[0]["Buyer_ph"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[0]["Buyer_email"].ToString();
					dataRow[14] = dataSet.Tables[0].Rows[0]["Buyer_ecc"].ToString();
					dataRow[15] = dataSet.Tables[0].Rows[0]["Buyer_tin"].ToString();
					dataRow[16] = dataSet.Tables[0].Rows[0]["Buyer_mob"].ToString();
					dataRow[17] = dataSet.Tables[0].Rows[0]["Buyer_fax"].ToString();
					dataRow[18] = dataSet.Tables[0].Rows[0]["Buyer_vat"].ToString();
					dataRow[19] = dataSet.Tables[0].Rows[0]["Cong_name"].ToString();
					dataRow[20] = dataSet.Tables[0].Rows[0]["Cong_cotper"].ToString();
					dataRow[21] = dataSet.Tables[0].Rows[0]["Cong_ph"].ToString();
					dataRow[22] = dataSet.Tables[0].Rows[0]["Cong_email"].ToString();
					dataRow[23] = dataSet.Tables[0].Rows[0]["Cong_ecc"].ToString();
					dataRow[24] = dataSet.Tables[0].Rows[0]["Cong_tin"].ToString();
					dataRow[25] = dataSet.Tables[0].Rows[0]["Cong_mob"].ToString();
					dataRow[26] = dataSet.Tables[0].Rows[0]["Cong_fax"].ToString();
					dataRow[27] = dataSet.Tables[0].Rows[0]["Cong_vat"].ToString();
					dataRow[28] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["AddType"].ToString());
					dataRow[29] = dataSet.Tables[0].Rows[0]["AddAmt"].ToString();
					dataRow[30] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DeductionType"].ToString());
					dataRow[31] = dataSet.Tables[0].Rows[0]["Deduction"].ToString();
					string cmdText3 = fun.select("SysDate As PODate", "SD_Cust_PO_Master", string.Concat("POId='", dataSet.Tables[0].Rows[0]["POId"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[32] = fun.FromDateDMY(dataSet4.Tables[0].Rows[0]["PODate"].ToString());
					}
					dataRow[33] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["POId"]);
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
				dataSet2.Tables.Add(dataTable);
				DataSet dataSet5 = new ProformaInvoice();
				dataSet5.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet5.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/ProformaInvoice.rpt"));
				cryRpt.SetDataSource(dataSet5);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText4 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[0]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[0]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					sqlDataAdapter4.Fill(DS, "Financial");
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
					string cmdText5 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Buyer_country"], "'"));
					string cmdText6 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Buyer_state"], "'"));
					string cmdText7 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Buyer_city"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet6 = new DataSet();
					DataSet dataSet7 = new DataSet();
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6, "tblCountry");
					sqlDataAdapter6.Fill(dataSet7, "tblState");
					sqlDataAdapter7.Fill(dataSet8, "tblcity");
					string text9 = text8 + ",\n" + dataSet8.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet7.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet6.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Buyer_Address", (object)text9);
					string text10 = dataSet.Tables[0].Rows[0]["Cong_add"].ToString();
					string cmdText8 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["Cong_country"], "'"));
					string cmdText9 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["Cong_state"], "'"));
					string cmdText10 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["Cong_city"], "'"));
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet9 = new DataSet();
					DataSet dataSet10 = new DataSet();
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter8.Fill(dataSet9, "tblCountry");
					sqlDataAdapter9.Fill(dataSet10, "tblState");
					sqlDataAdapter10.Fill(dataSet11, "tblcity");
					string text11 = text10 + ",\n" + dataSet11.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet10.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet9.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					cryRpt.SetParameterValue("Consignee_Address", (object)text11);
					string cmdText11 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
					SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter11.Fill(dataSet12, "tblCompany_master");
					string text12 = dataSet12.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + fun.getCity(Convert.ToInt32(dataSet12.Tables[0].Rows[0]["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(dataSet12.Tables[0].Rows[0]["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(dataSet12.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dataSet12.Tables[0].Rows[0]["RegdPinCode"].ToString() + ".\nPh No.-" + dataSet12.Tables[0].Rows[0]["RegdContactNo"].ToString() + ",  Fax No.-" + dataSet12.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "\nEmail No.-" + dataSet12.Tables[0].Rows[0]["RegdEmail"].ToString();
					cryRpt.SetParameterValue("Address", (object)text12);
				}
				cryRpt.SetParameterValue("PrintType", (object)PrintType);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				sqlConnection.Close();
			}
		}
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProformaInvoice_Print.aspx?ModId=11&SubModId=104");
	}
}

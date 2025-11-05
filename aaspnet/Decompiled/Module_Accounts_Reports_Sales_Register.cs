using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Reports_Sales_Register : Page, IRequiresSessionState
{
	protected Label lblFrmDt;

	protected TextBox TxtChequeDate;

	protected CalendarExtender TxtChequeDate_CalendarExtender;

	protected RequiredFieldValidator ReqChequeDate;

	protected RegularExpressionValidator RegBillDate0;

	protected Label lblToDt;

	protected TextBox TxtClearanceDate;

	protected CalendarExtender TxtClearanceDate_CalendarExtender;

	protected RequiredFieldValidator ReqClearanceDate;

	protected RegularExpressionValidator RegBillDate;

	protected Button BtnView;

	protected CompareValidator CompareValidator1;

	protected Label lblsalemsg;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected TabPanel Add;

	protected TextBox TxtExFrDate;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected TextBox txtExToDt;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected Button btnExcise;

	protected CompareValidator CompareValidator3;

	protected Label lblexcisemsg;

	protected CrystalReportSource CrystalReportSource3;

	protected CrystalReportViewer CrystalReportViewer3;

	protected Panel Panel3;

	protected TabPanel TabPanel1;

	protected TextBox TxtFromDate;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected RequiredFieldValidator ReqFromDt;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox TxtToDate;

	protected CalendarExtender TxtToDate_CalendarExtender;

	protected RequiredFieldValidator ReqCate2;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button Btnsearch;

	protected CompareValidator CompareValidator2;

	protected Label lblvatcstmsg;

	protected CrystalReportSource CrystalReportSource2;

	protected CrystalReportViewer CrystalReportViewer2;

	protected Panel Panel2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string WN = "";

	private ReportDocument cryRpt = new ReportDocument();

	private ReportDocument cryRpt2 = new ReportDocument();

	private ReportDocument cryRpt3 = new ReportDocument();

	private string connStr = string.Empty;

	private string wordsRem = string.Empty;

	private SqlConnection con;

	private string FrDt = string.Empty;

	private string ToDt = string.Empty;

	private string FrExDt = string.Empty;

	private string ToExDt = string.Empty;

	private string Fdate = string.Empty;

	private string Tdate = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				View();
				View2();
				View3();
				return;
			}
			ReportDocument reportSource = (ReportDocument)Session["test1"];
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			ReportDocument reportSource2 = (ReportDocument)Session["test2"];
			((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource2;
			ReportDocument reportSource3 = (ReportDocument)Session["test3"];
			((CrystalReportViewerBase)CrystalReportViewer3).ReportSource = reportSource3;
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		cryRpt = new ReportDocument();
		cryRpt2 = new ReportDocument();
		cryRpt3 = new ReportDocument();
		if (!base.IsPostBack)
		{
			string text = fun.FirstDateInCurrMonth().Date.ToShortDateString().Replace('/', '-');
			string text2 = fun.LastDateInCurrMonth().Date.ToShortDateString().Replace('/', '-');
			TxtExFrDate.Text = text;
			txtExToDt.Text = text2;
			TxtFromDate.Text = text;
			TxtToDate.Text = text2;
			TxtChequeDate.Text = text;
			TxtClearanceDate.Text = text2;
		}
	}

	public void View()
	{
		//IL_1082: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Expected O, but got Unknown
		DataSet dataSet = new DataSet();
		try
		{
			con.Open();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "' And DateOfIssueInvoice Between '" + fun.FromDate(TxtChequeDate.Text) + "' And '" + fun.FromDate(TxtClearanceDate.Text) + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Commodity", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TarrifNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MFG", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CLR", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CLO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AssValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CENVAT", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Sn", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Edu", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Excise", typeof(double)));
			dataTable.Columns.Add(new DataColumn("She", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VATCST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("OtherAmt", typeof(double)));
			int num = 1;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = "Select sum (ReqQty) as Qty,Unit,sum ((ReqQty*AmtInPer/100)*Rate) as Amt from tblACC_SalesInvoice_Details  where  MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'group by unit ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				int num2 = 0;
				int num3 = 0;
				num3 = dataSet2.Tables[0].Rows.Count;
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
					string cmdText3 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[i]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(DS, "Financial");
					string text = "";
					if (DS.Tables[0].Rows.Count > 0)
					{
						string fDY = DS.Tables[0].Rows[0]["FinYearFrom"].ToString();
						string text2 = fun.FromDateYear(fDY);
						string text3 = text2.Substring(2);
						string tDY = DS.Tables[0].Rows[0]["FinYearTo"].ToString();
						string text4 = fun.ToDateYear(tDY);
						string text5 = text4.Substring(2);
						text = text3 + text5;
						string value = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString() + "/" + text;
						dataRow[4] = value;
						if (num2 == 0)
						{
							dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
							dataRow[14] = num;
							num++;
							string cmdText4 = fun.select("*", "tblExciseCommodity_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Commodity"], "'"));
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter4.Fill(dataSet3);
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								dataRow[3] = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
								dataRow[5] = dataSet3.Tables[0].Rows[0]["ChapHead"].ToString();
							}
						}
						else
						{
							dataRow[1] = "";
							dataRow[14] = 0;
							dataRow[3] = "";
						}
						num2++;
					}
					string cmdText5 = fun.select("Symbol", "Unit_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[j]["Unit"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter5.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet4.Tables[0].Rows[0]["Symbol"];
					}
					dataRow[7] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					dataRow[8] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					dataRow[9] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]) - Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					num4 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Amt"]);
					dataRow[10] = num4;
					num5 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["PFType"]) != 0) ? (num4 * Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]) / 100.0) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]));
					num6 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["FreightType"]) != 0) ? (num4 * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]) / 100.0) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]));
					double num7 = 0.0;
					num7 = num5 / (double)num3;
					dataRow[11] = num7;
					string cmdText6 = fun.select("*", "tblExciseser_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["CENVAT"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter6.Fill(dataSet5);
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					num12 = num4 + num7;
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						num8 = num12 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]) / 100.0;
						num9 = num12 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["AccessableValue"]) / 100.0;
						num10 = num9 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["EDUCess"]) / 100.0;
						num11 = num9 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["SHECess"]) / 100.0;
					}
					dataRow[12] = num9;
					double num13 = 0.0;
					num13 = num6 / (double)num3;
					dataRow[13] = num13;
					dataRow[15] = num10;
					dataRow[16] = num8;
					dataRow[17] = num11;
					double num14 = 0.0;
					double num15 = 0.0;
					num14 = num12 + num8;
					if (dataSet.Tables[0].Rows[i]["VAT"].ToString() != "0")
					{
						string cmdText7 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["VAT"].ToString() + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter7.Fill(dataSet6, "tblVAT_Master");
						num15 = (num14 + num13) * Convert.ToDouble(dataSet6.Tables[0].Rows[0]["Value"]) / 100.0;
					}
					else if (dataSet.Tables[0].Rows[i]["CST"].ToString() != "0")
					{
						string cmdText8 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["CST"].ToString() + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter8.Fill(dataSet7, "tblVAT_Master");
						num15 = num14 * Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Value"]) / 100.0 + num13;
					}
					else if (dataSet.Tables[0].Rows[i]["CST"].ToString() == "0" && dataSet.Tables[0].Rows[i]["VAT"].ToString() == "0")
					{
						num15 = num14 + num13;
					}
					dataRow[18] = num15;
					double num16 = 0.0;
					if (dataSet.Tables[0].Rows[i]["OtherAmt"] != DBNull.Value)
					{
						num16 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["OtherAmt"]);
					}
					dataRow[20] = num16;
					dataRow[19] = num12 + num8 + num13 + num15 + num16;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer1).Visible = true;
				DataSet dataSet8 = new SalesExcise();
				dataSet8.Tables[0].Merge(dataTable);
				dataSet8.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/SalesExise_Print.rpt"));
				cryRpt.SetDataSource(dataSet8);
				string text6 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text6);
				FrDt = TxtChequeDate.Text;
				ToDt = TxtClearanceDate.Text;
				cryRpt.SetParameterValue("FrDt", (object)FrDt);
				cryRpt.SetParameterValue("ToDt", (object)ToDt);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session["test1"] = cryRpt;
				lblsalemsg.Visible = false;
			}
			else
			{
				((Control)(object)CrystalReportViewer1).Visible = false;
				lblsalemsg.Visible = true;
				lblsalemsg.Text = "No record found";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void View2()
	{
		//IL_156a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1574: Expected O, but got Unknown
		_ = string.Empty;
		con.Open();
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Fdate = TxtFromDate.Text;
			Tdate = TxtToDate.Text;
			SqlCommand selectCommand = new SqlCommand(fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "'  And DateOfIssueInvoice between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'  "), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExciseTerms", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExciseValues", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PFType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AccessableValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("EDUCess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SHECess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FreightType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VATCSTTerms", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VATCST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("ExciseTerms", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("ExciseValues", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("PFType", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("PF", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("AccessableValue", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("EDUCess", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("SHECess", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("FreightType", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("VATCSTTerms", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("VATCST", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("TotAmt", typeof(double)));
			DataSet dataSet2 = new DataSet();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					double num18 = 0.0;
					double num19 = 0.0;
					DataRow dataRow = dataTable.NewRow();
					DataRow dataRow2 = dataTable2.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow2[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow2[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[2] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
					dataRow2[2] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
					dataRow[3] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow2[3] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["CustomerCode"].ToString();
					dataRow2[4] = dataSet.Tables[0].Rows[i]["CustomerCode"].ToString();
					string cmdText = fun.select("CustomerName+' ['+CustomerId+' ]' As CustomerName ", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerCode"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString();
						dataRow2[5] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString();
					}
					string cmdText2 = fun.select("Sum((ReqQty*Rate)) As Total", "tblACC_SalesInvoice_Details", "MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					dataRow[6] = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
					dataRow2[6] = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
					string cmdText3 = fun.select("*", "tblExciseser_Master", "Id='" + dataSet.Tables[0].Rows[i]["CENVAT"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5);
					dataRow[7] = dataSet5.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[8] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]);
					dataRow2[7] = dataSet5.Tables[0].Rows[0]["Terms"].ToString();
					dataRow2[8] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]);
					dataRow[11] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["AccessableValue"]);
					dataRow[12] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["EDUCess"]);
					dataRow[13] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["SHECess"]);
					dataRow[9] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["PFType"]);
					dataRow[10] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]);
					dataRow[14] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FreightType"]);
					dataRow[15] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]);
					dataRow2[11] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["AccessableValue"]);
					dataRow2[12] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["EDUCess"]);
					dataRow2[13] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["SHECess"]);
					dataRow2[9] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["PFType"]);
					dataRow2[10] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]);
					dataRow2[14] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FreightType"]);
					dataRow2[15] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]);
					num8 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
					num9 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["PFType"]) != 0) ? (num8 * (Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]) / 100.0)) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]));
					num16 = num8 + num9;
					num10 = num16 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]) / 100.0;
					num11 = num16 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["AccessableValue"]) / 100.0;
					num12 = num11 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["EDUCess"]) / 100.0;
					num13 = num11 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["SHECess"]) / 100.0;
					num17 = num16 + num10;
					num14 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["FreightType"]) != 0) ? (num17 * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]) / 100.0) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]));
					if (dataSet.Tables[0].Rows[i]["VAT"].ToString() != "0")
					{
						num3 += Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
						num4 += num10;
						num5 += num11;
						num6 += num12;
						num7 += num13;
						string cmdText4 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["VAT"].ToString() + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6, "tblVAT_Master");
						dataRow[16] = dataSet6.Tables[0].Rows[0]["Value"].ToString() + "%";
						num18 = num17 + num14;
						num15 = num18 * Convert.ToDouble(dataSet6.Tables[0].Rows[0]["Value"]) / 100.0;
						dataRow[17] = num15;
						num += num15;
						num19 = num18 + num15;
						dataRow[18] = num19;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
					else if (dataSet.Tables[0].Rows[i]["CST"].ToString() != "0")
					{
						num3 += Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
						num4 += num10;
						num5 += num11;
						num6 += num12;
						num7 += num13;
						string cmdText5 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["CST"].ToString() + "'");
						SqlCommand selectCommand6 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter6.Fill(dataSet7, "tblVAT_Master");
						dataRow2[16] = dataSet7.Tables[0].Rows[0]["Value"].ToString() + "%";
						num15 = num17 * Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Value"]) / 100.0;
						num19 = num17 + num15 + num14;
						dataRow2[17] = num15;
						num2 += num15;
						dataRow2[18] = num19;
						dataTable2.Rows.Add(dataRow2);
						dataTable2.AcceptChanges();
					}
				}
			}
			dataSet2.Tables.Add(dataTable);
			dataSet2.Tables.Add(dataTable2);
			DataSet dataSet8 = new Vat_Sales();
			dataSet8.Tables[0].Merge(dataSet2.Tables[0]);
			dataSet8.Tables[1].Merge(dataSet2.Tables[1]);
			dataSet8.AcceptChanges();
			if (dataSet8.Tables[0].Rows.Count > 0 || dataSet8.Tables[1].Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer2).Visible = true;
				cryRpt2 = new ReportDocument();
				cryRpt2.Load(base.Server.MapPath("~/Module/Accounts/Reports/Sales_Vat.rpt"));
				cryRpt2.SetDataSource(dataSet8);
				string text = fun.CompAdd(CompId);
				cryRpt2.SetParameterValue("Address", (object)text);
				cryRpt2.SetParameterValue("FDate", (object)Fdate);
				cryRpt2.SetParameterValue("TDate", (object)Tdate);
				cryRpt2.SetParameterValue("BasicTotal", (object)Math.Round(num3));
				cryRpt2.SetParameterValue("ExciseTotal", (object)Math.Round(num4));
				cryRpt2.SetParameterValue("VATTotal", (object)Math.Round(num));
				cryRpt2.SetParameterValue("CSTTotal", (object)Math.Round(num2));
				cryRpt2.SetParameterValue("ACCtotal", (object)Math.Round(num5));
				cryRpt2.SetParameterValue("EDUTotal", (object)Math.Round(num6));
				cryRpt2.SetParameterValue("SHETotal", (object)Math.Round(num7));
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = cryRpt2;
				Session["test2"] = cryRpt2;
				lblvatcstmsg.Visible = false;
			}
			else
			{
				lblvatcstmsg.Visible = true;
				lblvatcstmsg.Text = "No record found";
				((Control)(object)CrystalReportViewer2).Visible = false;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void BtnView_Click(object sender, EventArgs e)
	{
		View();
	}

	protected void Btnsearch_Click(object sender, EventArgs e)
	{
		if (fun.DateValidation(TxtFromDate.Text) && fun.DateValidation(TxtToDate.Text))
		{
			View2();
		}
	}

	public void View3()
	{
		//IL_0fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdf: Expected O, but got Unknown
		try
		{
			con.Open();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "' And  tblACC_SalesInvoice_Master.DateOfIssueInvoice Between '" + fun.FromDate(TxtExFrDate.Text) + "' And '" + fun.FromDate(txtExToDt.Text) + "' order by tblACC_SalesInvoice_Master.Id ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Commodity", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CETSHNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MFG", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CLR", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CLO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AssValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BasicAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CENVAT", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Sn", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Edu", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Excise", typeof(double)));
			dataTable.Columns.Add(new DataColumn("She", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VATCST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("s", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CommodityId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("UOMId", typeof(int)));
			int num = 1;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = "Select (ReqQty) as Qty,unit,((ReqQty*AmtInPer/100)*Rate) as Amt from tblACC_SalesInvoice_Details where tblACC_SalesInvoice_Details.MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				int num2 = 0;
				num2 = dataSet2.Tables[0].Rows.Count;
				int num3 = 0;
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					string value = string.Empty;
					string value2 = string.Empty;
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = CompId;
					string cmdText3 = fun.select("*", "tblExciseCommodity_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Commodity"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
						value2 = dataSet3.Tables[0].Rows[0]["ChapHead"].ToString();
					}
					dataRow[1] = value;
					dataRow[2] = value2;
					string cmdText4 = fun.select("Symbol", "Unit_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[j]["unit"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet4.Tables[0].Rows[0]["Symbol"];
					}
					dataRow[4] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					dataRow[5] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					dataRow[6] = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]) - Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Qty"]);
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Amt"]);
					num6 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["PFType"]) != 0) ? (num5 * Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]) / 100.0) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["PF"]));
					num7 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["FreightType"]) != 0) ? (num5 * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]) / 100.0) : Convert.ToDouble(dataSet.Tables[0].Rows[i]["Freight"]));
					double num13 = 0.0;
					num13 = num6 / (double)num2;
					num12 = num5 + num13;
					string cmdText5 = fun.select("*", "tblExciseser_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["CENVAT"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						num8 = num12 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]) / 100.0;
						num9 = num12 * (Convert.ToDouble(dataSet5.Tables[0].Rows[0]["AccessableValue"]) / 100.0);
						num10 = num9 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["EDUCess"]) / 100.0;
						num11 = num9 * Convert.ToDouble(dataSet5.Tables[0].Rows[0]["SHECess"]) / 100.0;
					}
					dataRow[7] = num5;
					dataRow[8] = num13;
					dataRow[9] = num9;
					dataRow[10] = num9;
					double num14 = 0.0;
					num14 = num7 / (double)num2;
					dataRow[11] = num14;
					string cmdText6 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[i]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"].ToString(), "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					sqlDataAdapter6.Fill(DS, "Financial");
					if (DS.Tables[0].Rows.Count > 0)
					{
						if (num3 == 0)
						{
							dataRow[12] = num;
							num++;
						}
						else
						{
							dataRow[12] = 0;
						}
						num3++;
					}
					dataRow[13] = num10;
					dataRow[14] = num8;
					dataRow[15] = num11;
					double num15 = 0.0;
					double num16 = 0.0;
					num15 = num12 + num8;
					if (dataSet.Tables[0].Rows[i]["VAT"].ToString() != "0")
					{
						string cmdText7 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["VAT"].ToString() + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter7.Fill(dataSet6, "tblVAT_Master");
						num16 = (num15 + num14) * Convert.ToDouble(dataSet6.Tables[0].Rows[0]["Value"]) / 100.0;
					}
					else if (dataSet.Tables[0].Rows[i]["CST"].ToString() != "0")
					{
						string cmdText8 = fun.select("*", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["CST"].ToString() + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter8.Fill(dataSet7, "tblVAT_Master");
						num16 = num15 * Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Value"]) / 100.0 + num14;
					}
					else if (dataSet.Tables[0].Rows[i]["CST"].ToString() == "0" && dataSet.Tables[0].Rows[i]["VAT"].ToString() == "0")
					{
						num16 = num15 + num14;
					}
					dataRow[16] = num16;
					dataRow[17] = num12 + num10 + num11;
					dataRow[18] = num4;
					dataRow[19] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Commodity"]);
					dataRow[20] = Convert.ToInt32(dataSet2.Tables[0].Rows[j]["unit"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer3).Visible = true;
				DataSet dataSet8 = new SalesExcise();
				var varlist = from row in dataTable.AsEnumerable()
					group row by new
					{
						y = row.Field<int>("CommodityId"),
						x = row.Field<int>("UOMId")
					} into grp
					let row1 = grp.First()
					select new
					{
						CompId = row1.Field<int>("CompId"),
						Commodity = row1.Field<string>("Commodity"),
						CETSHNo = row1.Field<string>("CETSHNo"),
						UOM = row1.Field<string>("UOM"),
						MFG = grp.Sum((DataRow r) => r.Field<double>("MFG")),
						CLR = grp.Sum((DataRow r) => r.Field<double>("CLR")),
						CLO = grp.Sum((DataRow r) => r.Field<double>("CLO")),
						AssValue = grp.Sum((DataRow r) => r.Field<double>("AssValue")),
						PF = grp.Sum((DataRow r) => r.Field<double>("PF")),
						CENVAT = grp.Sum((DataRow r) => r.Field<double>("CENVAT")),
						Freight = grp.Sum((DataRow r) => r.Field<double>("Freight")),
						Sn = row1.Field<int>("Sn"),
						Edu = grp.Sum((DataRow r) => r.Field<double>("Edu")),
						Excise = row1.Field<double>("Excise"),
						She = grp.Sum((DataRow r) => r.Field<double>("She")),
						VATCST = grp.Sum((DataRow r) => r.Field<double>("VATCST")),
						Total = grp.Sum((DataRow r) => r.Field<double>("Total")),
						BasicAmt = grp.Sum((DataRow r) => r.Field<double>("BasicAmt")),
						s = row1.Field<double>("s")
					};
				DataTable table = LINQToDataTable(varlist);
				dataSet8.Tables[1].Merge(table);
				dataSet8.AcceptChanges();
				cryRpt3 = new ReportDocument();
				cryRpt3.Load(base.Server.MapPath("~/Module/Accounts/Reports/SalesEx_Print.rpt"));
				cryRpt3.SetDataSource(dataSet8);
				string text = fun.CompAdd(CompId);
				cryRpt3.SetParameterValue("Address", (object)text);
				FrExDt = TxtExFrDate.Text;
				ToExDt = txtExToDt.Text;
				cryRpt3.SetParameterValue("FrExDt", (object)FrExDt);
				cryRpt3.SetParameterValue("ToExDt", (object)ToExDt);
				((CrystalReportViewerBase)CrystalReportViewer3).ReportSource = cryRpt3;
				Session["test3"] = cryRpt3;
				lblexcisemsg.Visible = false;
			}
			else
			{
				((Control)(object)CrystalReportViewer3).Visible = false;
				lblexcisemsg.Visible = true;
				lblexcisemsg.Text = "No record found";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
	{
		DataTable dataTable = new DataTable();
		PropertyInfo[] array = null;
		if (varlist == null)
		{
			return dataTable;
		}
		foreach (T item in varlist)
		{
			if (array == null)
			{
				array = item.GetType().GetProperties();
				PropertyInfo[] array2 = array;
				foreach (PropertyInfo propertyInfo in array2)
				{
					Type type = propertyInfo.PropertyType;
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						type = type.GetGenericArguments()[0];
					}
					dataTable.Columns.Add(new DataColumn(propertyInfo.Name, type));
				}
			}
			DataRow dataRow = dataTable.NewRow();
			PropertyInfo[] array3 = array;
			foreach (PropertyInfo propertyInfo2 in array3)
			{
				dataRow[propertyInfo2.Name] = ((propertyInfo2.GetValue(item, null) == null) ? DBNull.Value : propertyInfo2.GetValue(item, null));
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	protected void btnExcise_Click(object sender, EventArgs e)
	{
		View3();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		GC.Collect();
	}
}

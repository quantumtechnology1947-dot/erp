using System;
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

public class Module_Accounts_Reports_Vat_Register : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string Fdate = "";

	private string Tdate = "";

	private ReportDocument cryRpt = new ReportDocument();

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_170b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1712: Expected O, but got Unknown
		//IL_1576: Unknown result type (might be due to invalid IL or missing references)
		//IL_1580: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
			_ = string.Empty;
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			try
			{
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				Fdate = base.Request.QueryString["FD"].ToString();
				Tdate = base.Request.QueryString["TD"].ToString();
				SqlCommand selectCommand = new SqlCommand(fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "'  And SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' "), sqlConnection);
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
						string cmdText = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerCode"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString();
							dataRow2[5] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString();
						}
						string cmdText2 = fun.select("Sum((Qty*Rate)) As Total", "tblACC_SalesInvoice_Details", "MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4);
						dataRow[6] = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
						dataRow2[6] = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Total"]);
						string cmdText3 = fun.select("*", "tblExciseser_Master", "Id='" + dataSet.Tables[0].Rows[i]["CENVAT"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
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
							SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
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
							SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
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
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/Sales_Vat.rpt"));
				cryRpt.SetDataSource(dataSet8);
				string text = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text);
				cryRpt.SetParameterValue("FDate", (object)Fdate);
				cryRpt.SetParameterValue("TDate", (object)Tdate);
				cryRpt.SetParameterValue("BasicTotal", (object)Math.Round(num3));
				cryRpt.SetParameterValue("ExciseTotal", (object)Math.Round(num4));
				cryRpt.SetParameterValue("VATTotal", (object)Math.Round(num));
				cryRpt.SetParameterValue("CSTTotal", (object)Math.Round(num2));
				cryRpt.SetParameterValue("ACCtotal", (object)Math.Round(num5));
				cryRpt.SetParameterValue("EDUTotal", (object)Math.Round(num6));
				cryRpt.SetParameterValue("SHETotal", (object)Math.Round(num7));
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session["ReportDocument"] = cryRpt;
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
		ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	private void If(bool p)
	{
		throw new NotImplementedException();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Sales_Register.aspx");
	}
}

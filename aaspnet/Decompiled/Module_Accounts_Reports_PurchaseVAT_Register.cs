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

public class Module_Accounts_Reports_PurchaseVAT_Register : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string Fdate = string.Empty;

	private string Tdate = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1776: Unknown result type (might be due to invalid IL or missing references)
		//IL_177d: Expected O, but got Unknown
		//IL_1660: Unknown result type (might be due to invalid IL or missing references)
		//IL_166a: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (!base.IsPostBack)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
				_ = string.Empty;
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				Fdate = base.Request.QueryString["FD"].ToString();
				Tdate = base.Request.QueryString["TD"].ToString();
				SqlCommand selectCommand = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblQc_MaterialQuality_Details.AcceptedQty) as qty,sum(tblQc_MaterialQuality_Details.AcceptedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId", sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BasicAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFTerms", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PF", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExciseValues", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExciseAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EDUCess", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EDUValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SHECess", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SHEValue", typeof(double)));
				dataTable.Columns.Add(new DataColumn("VATCSTTerms", typeof(string)));
				dataTable.Columns.Add(new DataColumn("VATCSTAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("FreightAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TotAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExciseBasic", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ExBasicAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable2.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("BasicAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("PFTerms", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("PF", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("ExciseValues", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("ExciseAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("EDUCess", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("EDUValue", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("SHECess", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("SHEValue", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("VATCSTTerms", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("VATCSTAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("FreightAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("TotAmt", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("ExciseBasic", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("ExBasicAmt", typeof(double)));
				DataSet dataSet2 = new DataSet();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable.NewRow();
						DataRow dataRow2 = dataTable2.NewRow();
						dataRow[0] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
						dataRow2[0] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
						dataRow[1] = CompId.ToString();
						dataRow2[1] = CompId.ToString();
						string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'  AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString() + " [" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "]";
							dataRow2[2] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString() + " [" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "]";
						}
						dataRow[3] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["amt"]);
						dataRow2[3] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["amt"]);
						string cmdText2 = fun.select("Value", "tblPacking_Master", "Id='" + dataSet.Tables[0].Rows[i]["PF"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4);
						dataRow[4] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
						dataRow2[4] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
						dataRow[5] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["pfamt"]);
						dataRow2[5] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["pfamt"]);
						string cmdText3 = fun.select("Value,AccessableValue,EDUCess,SHECess", "tblExciseser_Master", "Id='" + dataSet.Tables[0].Rows[i]["ExST"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						dataRow[6] = dataSet5.Tables[0].Rows[0]["Value"].ToString();
						dataRow2[6] = dataSet5.Tables[0].Rows[0]["Value"].ToString();
						dataRow[7] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]);
						dataRow2[7] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]);
						dataRow[8] = dataSet5.Tables[0].Rows[0]["EDUCess"].ToString();
						dataRow2[8] = dataSet5.Tables[0].Rows[0]["EDUCess"].ToString();
						dataRow[9] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]);
						dataRow2[9] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]);
						dataRow[10] = dataSet5.Tables[0].Rows[0]["SHECess"].ToString();
						dataRow2[10] = dataSet5.Tables[0].Rows[0]["SHECess"].ToString();
						dataRow[11] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]);
						dataRow2[11] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]);
						string cmdText4 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + dataSet.Tables[0].Rows[i]["VAT"].ToString() + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6);
						dataRow[12] = dataSet6.Tables[0].Rows[0]["Value"].ToString();
						dataRow2[12] = dataSet6.Tables[0].Rows[0]["Value"].ToString();
						double num5 = 0.0;
						if (dataSet6.Tables[0].Rows[0]["IsVAT"].ToString() == "1")
						{
							dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
							dataRow2[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
							num5 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
						}
						else if (dataSet6.Tables[0].Rows[0]["IsCST"].ToString() == "1")
						{
							dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["cst"]);
							dataRow2[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["cst"]);
							num5 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["cst"]);
						}
						else if (dataSet6.Tables[0].Rows[0]["IsVAT"].ToString() == "0" && dataSet6.Tables[0].Rows[0]["IsCST"].ToString() == "0")
						{
							dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
							dataRow2[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
							num5 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["vat1"]);
						}
						dataRow[14] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["fr"]);
						dataRow2[14] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["fr"]);
						dataRow[15] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]) + num5 + Convert.ToDouble(dataSet.Tables[0].Rows[i]["fr"]);
						num3 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]) + num5 + Convert.ToDouble(dataSet.Tables[0].Rows[i]["fr"]);
						dataRow2[15] = num3;
						num4 += Convert.ToDouble(dataSet.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet.Tables[0].Rows[i]["she"]);
						dataRow[16] = dataSet5.Tables[0].Rows[0]["AccessableValue"].ToString();
						dataRow2[16] = dataSet5.Tables[0].Rows[0]["AccessableValue"].ToString();
						dataRow[17] = dataSet.Tables[0].Rows[i]["eduBasic"].ToString();
						dataRow2[17] = dataSet.Tables[0].Rows[i]["eduBasic"].ToString();
						if (dataSet6.Tables[0].Rows[0]["IsCST"].ToString() == "0")
						{
							num += num3;
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
						else
						{
							num2 += num3;
							dataTable2.Rows.Add(dataRow2);
							dataTable2.AcceptChanges();
						}
					}
				}
				DataTable groupedBy = fun.GetGroupedBy(dataTable, "VATCSTTerms,VATCSTAmt", "VATCSTTerms", "Sum");
				string text = string.Empty;
				for (int j = 0; j < groupedBy.Rows.Count; j++)
				{
					string text2 = text;
					text = text2 + "@ " + groupedBy.Rows[j][0].ToString() + "    Amt: " + groupedBy.Rows[j][1].ToString() + ",  ";
				}
				dataSet2.Tables.Add(dataTable);
				dataSet2.Tables.Add(dataTable2);
				DataSet dataSet7 = new Vat_Purchase();
				dataSet7.Tables[0].Merge(dataSet2.Tables[0]);
				dataSet7.Tables[1].Merge(dataSet2.Tables[1]);
				dataSet7.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/Purchase.rpt"));
				cryRpt.SetDataSource(dataSet7);
				string text3 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text3);
				cryRpt.SetParameterValue("FDate", (object)Fdate);
				cryRpt.SetParameterValue("TDate", (object)Tdate);
				cryRpt.SetParameterValue("VATGrossTotal", (object)num);
				cryRpt.SetParameterValue("CSTGrossTotal", (object)num2);
				cryRpt.SetParameterValue("TotalExcise", (object)num4);
				cryRpt.SetParameterValue("MAHPurchase", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session["ReportDocument"] = cryRpt;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
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

	private void If(bool p)
	{
		throw new NotImplementedException();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Purchase_Reprt.aspx?ModId=11&SubModId=");
	}
}

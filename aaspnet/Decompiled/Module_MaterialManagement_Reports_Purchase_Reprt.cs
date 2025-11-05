using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Reports_Purchase_Reprt : Page, IRequiresSessionState
{
	protected TextBox TextBox3;

	protected CalendarExtender CalendarExtender3;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected RegularExpressionValidator RegularExpressionValidator5;

	protected TextBox TextBox4;

	protected CalendarExtender CalendarExtender4;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected RegularExpressionValidator RegularExpressionValidator6;

	protected Button Btnsearch1;

	protected CompareValidator CompareValidator3;

	protected Label Label2;

	protected CrystalReportSource CrystalReportSource3;

	protected CrystalReportViewer CrystalReportViewer3;

	protected Panel Panel2;

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

	protected CompareValidator CompareValidator1;

	protected Label lblsalemsg;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected TabPanel TabPanel2;

	protected TextBox TextBox1;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected TextBox TextBox2;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected Button Btnsearch2;

	protected CompareValidator CompareValidator2;

	protected Label Label1;

	protected CrystalReportSource CrystalReportSource2;

	protected CrystalReportViewer CrystalReportViewer2;

	protected Panel Panel1;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string Fdate = string.Empty;

	private string Tdate = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	private ReportDocument cryRpt2 = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		try
		{
			if (!base.IsPostBack)
			{
				string text = fun.FirstDateInCurrMonth().Date.ToShortDateString().Replace('/', '-');
				TxtFromDate.Text = text;
				string text2 = fun.LastDateInCurrMonth().Date.ToShortDateString().Replace('/', '-');
				TxtToDate.Text = text2;
				TextBox1.Text = text;
				TextBox2.Text = text2;
				TextBox3.Text = text;
				TextBox4.Text = text2;
				cryrpt_create2();
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session["ReportDocument"];
				ReportDocument reportSource2 = (ReportDocument)Session["ReportDocument2"];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource;
				((CrystalReportViewerBase)CrystalReportViewer3).ReportSource = reportSource2;
			}
		}
		catch (Exception)
		{
		}
	}

	public void cryrpt_create(int flag)
	{
		//IL_117e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1188: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			_ = string.Empty;
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SqlCommand sqlCommand;
			if (flag == 0)
			{
				Fdate = TxtFromDate.Text;
				Tdate = TxtToDate.Text;
				sqlCommand = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblQc_MaterialQuality_Details.AcceptedQty) as qty,sum(tblQc_MaterialQuality_Details.AcceptedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", sqlConnection);
			}
			else
			{
				Fdate = TextBox1.Text;
				Tdate = TextBox2.Text;
				sqlCommand = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as qty,sum(tblinv_MaterialServiceNote_Details.ReceivedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblinv_MaterialServiceNote_Details ON tblACC_BillBooking_Details.GSNId = tblinv_MaterialServiceNote_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", sqlConnection);
			}
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
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
			DataSet dataSet = new DataSet();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow[0] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow2[0] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[1] = CompId.ToString();
				dataRow2[1] = CompId.ToString();
				dataRow[2] = sqlDataReader["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				dataRow2[2] = sqlDataReader["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				dataRow[3] = Convert.ToDouble(sqlDataReader["amt"]);
				dataRow2[3] = Convert.ToDouble(sqlDataReader["amt"]);
				string cmdText = fun.select("Value", "tblPacking_Master", "Id='" + sqlDataReader["PF"].ToString() + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				dataRow[4] = dataSet2.Tables[0].Rows[0]["Value"].ToString();
				dataRow2[4] = dataSet2.Tables[0].Rows[0]["Value"].ToString();
				dataRow[5] = Convert.ToDouble(sqlDataReader["pfamt"]);
				dataRow2[5] = Convert.ToDouble(sqlDataReader["pfamt"]);
				string cmdText2 = fun.select("Value,AccessableValue,EDUCess,SHECess", "tblExciseser_Master", "Id='" + sqlDataReader["ExST"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter2.Fill(dataSet3);
				dataRow[6] = dataSet3.Tables[0].Rows[0]["Value"].ToString();
				dataRow2[6] = dataSet3.Tables[0].Rows[0]["Value"].ToString();
				dataRow[7] = Convert.ToDouble(sqlDataReader["exba"]) + Convert.ToDouble(sqlDataReader["edu"]) + Convert.ToDouble(sqlDataReader["she"]);
				dataRow2[7] = Convert.ToDouble(sqlDataReader["exba"]) + Convert.ToDouble(sqlDataReader["edu"]) + Convert.ToDouble(sqlDataReader["she"]);
				dataRow[8] = dataSet3.Tables[0].Rows[0]["EDUCess"].ToString();
				dataRow2[8] = dataSet3.Tables[0].Rows[0]["EDUCess"].ToString();
				dataRow[9] = Convert.ToDouble(sqlDataReader["edu"]);
				dataRow2[9] = Convert.ToDouble(sqlDataReader["edu"]);
				dataRow[10] = dataSet3.Tables[0].Rows[0]["SHECess"].ToString();
				dataRow2[10] = dataSet3.Tables[0].Rows[0]["SHECess"].ToString();
				dataRow[11] = Convert.ToDouble(sqlDataReader["she"]);
				dataRow2[11] = Convert.ToDouble(sqlDataReader["she"]);
				string cmdText3 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + sqlDataReader["VAT"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter3.Fill(dataSet4);
				dataRow[12] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
				dataRow2[12] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
				double num5 = 0.0;
				if (dataSet4.Tables[0].Rows[0]["IsVAT"].ToString() == "1")
				{
					dataRow[13] = Convert.ToDouble(sqlDataReader["vat1"]);
					dataRow2[13] = Convert.ToDouble(sqlDataReader["vat1"]);
					num5 = Convert.ToDouble(sqlDataReader["vat1"]);
				}
				else if (dataSet4.Tables[0].Rows[0]["IsCST"].ToString() == "1")
				{
					dataRow[13] = Convert.ToDouble(sqlDataReader["cst"]);
					dataRow2[13] = Convert.ToDouble(sqlDataReader["cst"]);
					num5 = Convert.ToDouble(sqlDataReader["cst"]);
				}
				else if (dataSet4.Tables[0].Rows[0]["IsVAT"].ToString() == "0" && dataSet4.Tables[0].Rows[0]["IsCST"].ToString() == "0")
				{
					dataRow[13] = Convert.ToDouble(sqlDataReader["vat1"]);
					dataRow2[13] = Convert.ToDouble(sqlDataReader["vat1"]);
					num5 = Convert.ToDouble(sqlDataReader["vat1"]);
				}
				dataRow[14] = Convert.ToDouble(sqlDataReader["fr"]);
				dataRow2[14] = Convert.ToDouble(sqlDataReader["fr"]);
				dataRow[15] = Convert.ToDouble(sqlDataReader["amt"]) + Convert.ToDouble(sqlDataReader["pfamt"]) + Convert.ToDouble(sqlDataReader["exba"]) + Convert.ToDouble(sqlDataReader["edu"]) + Convert.ToDouble(sqlDataReader["she"]) + num5 + Convert.ToDouble(sqlDataReader["fr"]);
				num3 = Convert.ToDouble(sqlDataReader["amt"]) + Convert.ToDouble(sqlDataReader["pfamt"]) + Convert.ToDouble(sqlDataReader["exba"]) + Convert.ToDouble(sqlDataReader["edu"]) + Convert.ToDouble(sqlDataReader["she"]) + num5 + Convert.ToDouble(sqlDataReader["fr"]);
				dataRow2[15] = num3;
				num4 += Convert.ToDouble(sqlDataReader["exba"]) + Convert.ToDouble(sqlDataReader["edu"]) + Convert.ToDouble(sqlDataReader["she"]);
				dataRow[16] = dataSet3.Tables[0].Rows[0]["AccessableValue"].ToString();
				dataRow2[16] = dataSet3.Tables[0].Rows[0]["AccessableValue"].ToString();
				dataRow[17] = sqlDataReader["eduBasic"].ToString();
				dataRow2[17] = sqlDataReader["eduBasic"].ToString();
				if (dataSet4.Tables[0].Rows[0]["IsCST"].ToString() == "0")
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
			DataTable groupedBy = fun.GetGroupedBy(dataTable, "VATCSTTerms,VATCSTAmt", "VATCSTTerms", "Sum");
			string text = string.Empty;
			for (int i = 0; i < groupedBy.Rows.Count; i++)
			{
				string text2 = text;
				text = text2 + "@ " + groupedBy.Rows[i][0].ToString() + "    Amt: " + groupedBy.Rows[i][1].ToString() + ",  ";
			}
			if (dataTable.Rows.Count > 0 || dataTable2.Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer1).Visible = true;
				((Control)(object)CrystalReportViewer2).Visible = true;
				lblsalemsg.Visible = false;
				Label1.Visible = false;
				dataSet.Tables.Add(dataTable);
				dataSet.Tables.Add(dataTable2);
				DataSet dataSet5 = new Vat_Purchase();
				dataSet5.Tables[0].Merge(dataSet.Tables[0]);
				dataSet5.Tables[1].Merge(dataSet.Tables[1]);
				dataSet5.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/Purchase.rpt"));
				cryRpt.SetDataSource(dataSet5);
				string text3 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text3);
				cryRpt.SetParameterValue("FDate", (object)Fdate);
				cryRpt.SetParameterValue("TDate", (object)Tdate);
				cryRpt.SetParameterValue("VATGrossTotal", (object)num);
				cryRpt.SetParameterValue("CSTGrossTotal", (object)num2);
				cryRpt.SetParameterValue("TotalExcise", (object)num4);
				cryRpt.SetParameterValue("MAHPurchase", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = cryRpt;
				Session["ReportDocument"] = cryRpt;
			}
			else
			{
				lblsalemsg.Visible = true;
				lblsalemsg.Text = "No record found!";
				Label1.Visible = true;
				Label1.Text = "No record found!";
				((Control)(object)CrystalReportViewer1).Visible = false;
				((Control)(object)CrystalReportViewer2).Visible = false;
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

	public void cryrpt_create2()
	{
		//IL_123b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		try
		{
			_ = string.Empty;
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Fdate = TextBox3.Text;
			Tdate = TextBox4.Text;
			SqlCommand selectCommand = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblQc_MaterialQuality_Details.AcceptedQty) as qty,sum(tblQc_MaterialQuality_Details.AcceptedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SqlCommand selectCommand2 = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as qty,sum(tblinv_MaterialServiceNote_Details.ReceivedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblinv_MaterialServiceNote_Details ON tblACC_BillBooking_Details.GSNId = tblinv_MaterialServiceNote_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			dataSet2.Tables[0].Merge(dataSet.Tables[0]);
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
			DataSet dataSet3 = new DataSet();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow[0] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow2[0] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[1] = CompId.ToString();
				dataRow2[1] = CompId.ToString();
				dataRow[2] = dataSet2.Tables[0].Rows[i]["SupplierName"].ToString() + " [" + dataSet2.Tables[0].Rows[i]["SupplierId"].ToString() + "]";
				dataRow2[2] = dataSet2.Tables[0].Rows[i]["SupplierName"].ToString() + " [" + dataSet2.Tables[0].Rows[i]["SupplierId"].ToString() + "]";
				dataRow[3] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["amt"]);
				dataRow2[3] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["amt"]);
				string cmdText = fun.select("Value", "tblPacking_Master", "Id='" + dataSet2.Tables[0].Rows[i]["PF"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter3.Fill(dataSet4);
				dataRow[4] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
				dataRow2[4] = dataSet4.Tables[0].Rows[0]["Value"].ToString();
				dataRow[5] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["pfamt"]);
				dataRow2[5] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["pfamt"]);
				string cmdText2 = fun.select("Value,AccessableValue,EDUCess,SHECess", "tblExciseser_Master", "Id='" + dataSet2.Tables[0].Rows[i]["ExST"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter4.Fill(dataSet5);
				dataRow[6] = dataSet5.Tables[0].Rows[0]["Value"].ToString();
				dataRow2[6] = dataSet5.Tables[0].Rows[0]["Value"].ToString();
				dataRow[7] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				dataRow2[7] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				dataRow[8] = dataSet5.Tables[0].Rows[0]["EDUCess"].ToString();
				dataRow2[8] = dataSet5.Tables[0].Rows[0]["EDUCess"].ToString();
				dataRow[9] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]);
				dataRow2[9] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]);
				dataRow[10] = dataSet5.Tables[0].Rows[0]["SHECess"].ToString();
				dataRow2[10] = dataSet5.Tables[0].Rows[0]["SHECess"].ToString();
				dataRow[11] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				dataRow2[11] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				string cmdText3 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + dataSet2.Tables[0].Rows[i]["VAT"].ToString() + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter5.Fill(dataSet6);
				dataRow[15] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				dataRow2[15] = num3;
				num4 += Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				dataRow[16] = dataSet5.Tables[0].Rows[0]["AccessableValue"].ToString();
				dataRow2[16] = dataSet5.Tables[0].Rows[0]["AccessableValue"].ToString();
				dataRow[17] = dataSet2.Tables[0].Rows[i]["eduBasic"].ToString();
				dataRow2[17] = dataSet2.Tables[0].Rows[i]["eduBasic"].ToString();
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
			DataTable groupedBy = fun.GetGroupedBy(dataTable, "VATCSTTerms,VATCSTAmt", "VATCSTTerms", "Sum");
			string text = string.Empty;
			for (int j = 0; j < groupedBy.Rows.Count; j++)
			{
				string text2 = text;
				text = text2 + "@ " + groupedBy.Rows[j][0].ToString() + "    Amt: " + groupedBy.Rows[j][1].ToString() + ",  ";
			}
			if (dataTable.Rows.Count > 0 || dataTable2.Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer3).Visible = true;
				Label2.Visible = false;
				dataSet3.Tables.Add(dataTable);
				dataSet3.Tables.Add(dataTable2);
				DataSet dataSet7 = new Vat_Purchase();
				dataSet7.Tables[0].Merge(dataSet3.Tables[0]);
				dataSet7.Tables[1].Merge(dataSet3.Tables[1]);
				dataSet7.AcceptChanges();
				cryRpt2 = new ReportDocument();
				cryRpt2.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/Purchase_Excise.rpt"));
				cryRpt2.SetDataSource(dataSet7);
				string text3 = fun.CompAdd(CompId);
				cryRpt2.SetParameterValue("Address", (object)text3);
				cryRpt2.SetParameterValue("FDate", (object)Fdate);
				cryRpt2.SetParameterValue("TDate", (object)Tdate);
				cryRpt2.SetParameterValue("VATGrossTotal", (object)num);
				cryRpt2.SetParameterValue("CSTGrossTotal", (object)num2);
				cryRpt2.SetParameterValue("TotalExcise", (object)num4);
				cryRpt2.SetParameterValue("MAHPurchase", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer3).ReportSource = cryRpt2;
				Session["ReportDocument2"] = cryRpt2;
			}
			else
			{
				Label2.Visible = true;
				Label2.Text = "No record found!";
				((Control)(object)CrystalReportViewer3).Visible = false;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
			dataTable.Dispose();
			dataTable2.Dispose();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		cryRpt = new ReportDocument();
		cryRpt2 = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		GC.Collect();
	}

	public DateTime LastDateInCurrMonth()
	{
		DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		return dateTime.AddMonths(1).AddDays(-1.0);
	}

	protected void Btnsearch_Click(object sender, EventArgs e)
	{
		cryrpt_create(0);
	}

	protected void Btnsearch2_Click(object sender, EventArgs e)
	{
		cryrpt_create(1);
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			cryrpt_create(0);
		}
		else if (TabContainer1.ActiveTabIndex == 2)
		{
			cryrpt_create(1);
		}
		else
		{
			cryrpt_create2();
		}
	}

	protected void Btnsearch1_Click(object sender, EventArgs e)
	{
		cryrpt_create2();
	}
}

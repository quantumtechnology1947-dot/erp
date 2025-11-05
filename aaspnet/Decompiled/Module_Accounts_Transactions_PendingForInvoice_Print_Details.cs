using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_PendingForInvoice_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	private string connStr = "";

	private SqlConnection con;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt;

	private int CompId;

	private int FinYearId;

	private string WONo = "";

	private string CustCode = "";

	private int val;

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9d: Expected O, but got Unknown
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			Key = base.Request.QueryString["Key"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			WONo = base.Request.QueryString["W"].ToString();
			val = Convert.ToInt32(base.Request.QueryString["Val"].ToString());
			if (!base.IsPostBack)
			{
				DataSet dataSet = new DataSet();
				DataTable dataTable = new DataTable();
				new DataSet();
				if (!string.IsNullOrEmpty(base.Request.QueryString["C"]))
				{
					CustCode = "AND SD_Cust_master.CustomerId='" + base.Request.QueryString["C"].ToString() + "'";
				}
				else
				{
					CustCode = "";
				}
				DataTable dataTable2 = new DataTable();
				dataTable2.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Description", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Qty", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("InvoiceQty", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("PendingInvoiceQty", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Rate", typeof(double)));
				dataTable2.Columns.Add(new DataColumn("Discount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				string cmdText = "";
				if (val == 0)
				{
					cmdText = "SELECT  Distinct(SD_Cust_master.CustomerId),SD_Cust_master.CustomerName FROM SD_Cust_master inner join SD_Cust_PO_Master on SD_Cust_master.CustomerId=SD_Cust_PO_Master.CustomerId  inner join SD_Cust_WorkOrder_Master on SD_Cust_PO_Master.POId=SD_Cust_WorkOrder_Master.POId And SD_Cust_master.CompId='" + CompId + "'";
				}
				else if (val == 1)
				{
					cmdText = "SELECT  Distinct(SD_Cust_master.CustomerId),SD_Cust_master.CustomerName FROM SD_Cust_master inner join SD_Cust_PO_Master on SD_Cust_master.CustomerId=SD_Cust_PO_Master.CustomerId And SD_Cust_master.CompId='" + CompId + "'" + CustCode;
				}
				else if (val == 2)
				{
					cmdText = " SELECT  Distinct(SD_Cust_master.CustomerId),SD_Cust_master.CustomerName FROM SD_Cust_master inner join SD_Cust_PO_Master on SD_Cust_master.CustomerId=SD_Cust_PO_Master.CustomerId  inner join SD_Cust_WorkOrder_Master on SD_Cust_PO_Master.POId=SD_Cust_WorkOrder_Master.POId And SD_Cust_master.CompId='" + CompId + "' And SD_Cust_WorkOrder_Master.WONo='" + WONo + "'";
				}
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				double num = 0.0;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					int num2 = 0;
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet2.Tables[0].Rows[i][0].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[i][1].ToString() + " [ " + dataSet2.Tables[0].Rows[i][0].ToString() + " ]";
					dataRow[2] = CompId;
					string text = "";
					text = ((!(WONo == string.Empty) || !(WONo == "")) ? ("SELECT SD_Cust_PO_Master.POId,SD_Cust_PO_Master.CustomerId,SD_Cust_PO_Master.PONo,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate,SD_Cust_PO_Details.Discount FROM SD_Cust_PO_Master,SD_Cust_PO_Details,SD_Cust_WorkOrder_Master WHERE SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And SD_Cust_PO_Master.POId=SD_Cust_WorkOrder_Master.POId And SD_Cust_PO_Master.CustomerId=SD_Cust_WorkOrder_Master.CustomerId  And SD_Cust_PO_Master.CustomerId='" + dataSet2.Tables[0].Rows[i][0].ToString() + "' And SD_Cust_WorkOrder_Master.WONo='" + WONo + "' ") : ("SELECT SD_Cust_PO_Master.POId,SD_Cust_PO_Master.CustomerId,SD_Cust_PO_Master.PONo,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate,SD_Cust_PO_Details.Discount FROM SD_Cust_PO_Master,SD_Cust_PO_Details WHERE SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId And SD_Cust_PO_Master.CustomerId='" + dataSet2.Tables[0].Rows[i][0].ToString() + "' "));
					SqlCommand selectCommand2 = new SqlCommand(text, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						DataRow dataRow2 = dataTable2.NewRow();
						string cmdText2 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "CustomerId='" + dataSet3.Tables[0].Rows[j]["CustomerId"].ToString() + "' And CompId='" + CompId + "' And POId='" + dataSet3.Tables[0].Rows[j]["POId"].ToString() + "'");
						DataSet dataSet4 = new DataSet();
						SqlCommand selectCommand3 = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						sqlDataAdapter3.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow2[0] = dataSet4.Tables[0].Rows[0]["WONo"].ToString();
						}
						dataRow2[1] = dataSet3.Tables[0].Rows[j]["PONo"].ToString();
						dataRow2[2] = dataSet3.Tables[0].Rows[j]["Id"].ToString();
						dataRow2[3] = dataSet3.Tables[0].Rows[j]["ItemDesc"].ToString();
						string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[j]["Unit"].ToString() + "' ");
						SqlCommand selectCommand4 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							dataRow2[4] = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
						}
						double num3 = 0.0;
						double num4 = 0.0;
						double num5 = 0.0;
						double num6 = 0.0;
						num3 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[j]["TotalQty"].ToString()).ToString("N3"));
						dataRow2[5] = num3;
						string cmdText4 = fun.select("Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' And tblACC_SalesInvoice_Details.ItemId='" + dataSet3.Tables[0].Rows[j]["Id"].ToString() + "'  Group By tblACC_SalesInvoice_Details.ItemId");
						SqlCommand selectCommand5 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter5.Fill(dataSet6);
						double num7 = 0.0;
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							num7 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
						}
						num4 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[j]["TotalQty"].ToString()).ToString("N3")) - num7;
						dataRow2[6] = num7;
						dataRow2[7] = num4;
						dataRow2[8] = dataSet3.Tables[0].Rows[j]["CustomerId"].ToString();
						num5 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[j]["Rate"].ToString()).ToString("N2"));
						num6 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[j]["Discount"].ToString()).ToString("N2"));
						num += num4 * num5 - num4 * num5 * num6 / 100.0;
						dataRow2[9] = num5;
						dataRow2[10] = num6;
						if (num4 > 0.0)
						{
							dataTable2.Rows.Add(dataRow2);
							dataTable2.AcceptChanges();
							num2++;
						}
					}
					if (num2 > 0)
					{
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				dataSet.Tables.Add(dataTable2);
				dataSet.Tables.Add(dataTable);
				DataSet dataSet7 = new PendingInvQty();
				dataSet7.Tables[0].Merge(dataSet.Tables[0]);
				dataSet7.Tables[1].Merge(dataSet.Tables[1]);
				dataSet7.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/PendingForInvoice.rpt"));
				cryRpt.SetDataSource(dataSet7);
				string text2 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text2);
				cryRpt.SetParameterValue("TotAmount", (object)num);
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
}

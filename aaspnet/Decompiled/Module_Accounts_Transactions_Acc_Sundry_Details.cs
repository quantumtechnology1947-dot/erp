using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_Acc_Sundry_Details : Page, IRequiresSessionState
{
	private ACC_CurrentAssets ACA = new ACC_CurrentAssets();

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CustCode = string.Empty;

	private ReportDocument rpt = new ReportDocument();

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Key = base.Request.QueryString["Key"].ToString();
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		try
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["CustId"]))
			{
				CustCode = base.Request.QueryString["CustId"].ToString();
			}
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				DataSet dataSet = new Acc_Sundry_Dr();
				dataSet.Tables[0].Merge(TotInvQty2(CompId, FinYearId, CustCode));
				dataSet.AcceptChanges();
				rpt = new ReportDocument();
				rpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/Acc_Sundry_Dr_Details.rpt"));
				rpt.SetDataSource(dataSet);
				string text = fun.CompAdd(CompId);
				rpt.SetParameterValue("CompAdd", (object)text);
				double num = 0.0;
				num = Math.Round(fun.DebitorsOpeningBal(CompId, CustCode), 2);
				rpt.SetParameterValue("OpBal", (object)num);
				double num2 = 0.0;
				num2 = Math.Round(fun.getDebitorCredit(CompId, FinYearId, CustCode), 2);
				rpt.SetParameterValue("CreditBal", (object)num2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = rpt;
				Session[Key] = rpt;
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

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		GC.Collect();
	}

	public DataTable TotInvQty2(int CompId, int FinId, string CustCode)
	{
		DataTable dataTable = new DataTable();
		try
		{
			con.Open();
			string cmdText = fun.select("CustomerName+'['+CustomerId+']' As Customer, CustomerId", "SD_Cust_master", "CompId='" + CompId + "' AND FinYearId<='" + FinId + "' AND CustomerId='" + CustCode + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("CustName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CustCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Credit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Path", typeof(string)));
			while (sqlDataReader.Read())
			{
				string cmdText2 = string.Concat("select Id,InvoiceNo,OtherAmt from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					string cmdText3 = string.Concat("select sum(case when Unit_Master.EffectOnInvoice=1 then (ReqQty*(AmtInPer/100)*Rate) Else (ReqQty*Rate) End) As Amt from tblACC_SalesInvoice_Details inner join tblACC_SalesInvoice_Master on tblACC_SalesInvoice_Master.Id=tblACC_SalesInvoice_Details.MId inner join  Unit_Master on tblACC_SalesInvoice_Details.Unit=Unit_Master.Id And tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "' And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "' ");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					num3 += Convert.ToDouble(sqlDataReader3["Amt"]);
					string cmdText4 = string.Concat("select Sum(case when AddType=0 then AddAmt Else ((", num3, " *AddAmt)/100)End) As AddAmt from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "' ");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					num6 = Convert.ToDouble(sqlDataReader4["AddAmt"]);
					num4 += num3 + num6;
					string cmdText5 = string.Concat("select Sum(case when DeductionType=0 then Deduction Else ((", num4, " *Deduction)/100)End) As deduct from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "' ");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					num5 = Convert.ToDouble(sqlDataReader5["deduct"]);
					num7 += num4 - num5;
					string cmdText6 = string.Concat("select Sum(case when PFType=0 then PF Else ((", num7, " *PF)/100)End) As pf from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "'");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					num8 = Convert.ToDouble(sqlDataReader6["pf"]);
					num10 += num7 + num8;
					string cmdText7 = string.Concat("select Sum((", num10, ")*((tblExciseser_Master.AccessableValue)/100) + ((", num10, ")*((tblExciseser_Master.AccessableValue)/100)*tblExciseser_Master.EDUCess/100)+((", num10, ")*((tblExciseser_Master.AccessableValue)/100)*tblExciseser_Master.SHECess/100)) As Ex from  tblACC_SalesInvoice_Master inner join tblExciseser_Master on tblExciseser_Master.Id=tblACC_SalesInvoice_Master.CENVAT where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "'");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
					SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
					sqlDataReader7.Read();
					num9 = Convert.ToDouble(sqlDataReader7["Ex"]);
					num11 += num10 + num9;
					string cmdText8 = string.Concat("select FreightType,Freight,InvoiceMode,CST,VAT from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "'");
					SqlCommand sqlCommand8 = new SqlCommand(cmdText8, con);
					SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
					while (sqlDataReader8.Read())
					{
						double num17 = Convert.ToDouble(sqlDataReader8["Freight"].ToString());
						double num18 = 0.0;
						if (sqlDataReader8["InvoiceMode"].ToString() == "2")
						{
							num13 = ((!(sqlDataReader8["FreightType"].ToString() == "0")) ? (num11 * (num17 / 100.0)) : num17);
							string cmdText9 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader8["VAT"].ToString() + "'");
							SqlCommand sqlCommand9 = new SqlCommand(cmdText9, con);
							SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
							while (sqlDataReader9.Read())
							{
								num18 = Convert.ToDouble(sqlDataReader9["Value"]);
							}
							num14 = (num11 + num13) * (num18 / 100.0);
						}
						else if (sqlDataReader8["InvoiceMode"].ToString() == "3")
						{
							string cmdText10 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader8["CST"].ToString() + "'");
							SqlCommand sqlCommand10 = new SqlCommand(cmdText10, con);
							SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
							while (sqlDataReader10.Read())
							{
								num18 = Convert.ToDouble(sqlDataReader10["Value"]);
							}
							num13 = num11 * (num18 / 100.0);
							num14 = ((!(sqlDataReader8["FreightType"].ToString() == "0")) ? ((num11 + num13) * (num17 / 100.0)) : num17);
						}
					}
					num12 += num11 + num13;
					num15 += num12 + num14;
					string cmdText11 = string.Concat("select Sum(case when InsuranceType=0 then Insurance Else ((", num15, " *Insurance)/100)End) As Insurance from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'And tblACC_SalesInvoice_Master.InvoiceNo='", sqlDataReader2["InvoiceNo"], "'");
					SqlCommand sqlCommand11 = new SqlCommand(cmdText11, con);
					SqlDataReader sqlDataReader11 = sqlCommand11.ExecuteReader();
					sqlDataReader11.Read();
					num16 = Convert.ToDouble(sqlDataReader11["Insurance"]);
					if (sqlDataReader2["OtherAmt"] != DBNull.Value)
					{
						num2 = Math.Round(Convert.ToDouble(sqlDataReader2["OtherAmt"]), 2);
					}
					num += num15 + num16 + num2;
					dataRow[0] = sqlDataReader["Customer"];
					dataRow[1] = Math.Round(num, 2);
					dataRow[2] = sqlDataReader["CustomerId"];
					dataRow[3] = sqlDataReader2["InvoiceNo"];
					dataRow[4] = CompId;
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					dataRow[6] = string.Concat("/erp/Module/Accounts/Transactions/SalesInvoice_Print_Details.aspx?InvNo=", sqlDataReader2["InvoiceNo"], "&InvId=", sqlDataReader2["Id"], "&cid=", sqlDataReader["CustomerId"], "&PT=ORIGINAL FOR BUYER&ModId=11&SubModId=51&Key=", randomAlphaNumeric, "&K=", Key, "&T=1");
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return dataTable;
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Acc_Sundry_CustList.aspx");
	}
}

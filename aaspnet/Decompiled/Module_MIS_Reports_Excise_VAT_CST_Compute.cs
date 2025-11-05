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

public class Module_MIS_Reports_Excise_VAT_CST_Compute : Page, IRequiresSessionState
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

	protected GridView GridView1;

	protected CrystalReportSource CrystalReportSource3;

	protected CrystalReportViewer CrystalReportViewer3;

	protected Panel Panel2;

	protected TabPanel TabPanel1;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument cryRpt2 = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		try
		{
			if (!base.IsPostBack)
			{
				string text = FirstDateInLastMonth().Date.ToShortDateString().Replace('/', '-');
				string text2 = LastDateInLastMonth().Date.ToShortDateString().Replace('/', '-');
				TextBox3.Text = text;
				TextBox4.Text = text2;
				cryrpt_create2();
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session["ReportDocument2"];
				((CrystalReportViewerBase)CrystalReportViewer3).ReportSource = reportSource;
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
		cryRpt2 = new ReportDocument();
	}

	protected void Btnsearch1_Click(object sender, EventArgs e)
	{
		cryrpt_create2();
	}

	public void cryrpt_create2()
	{
		//IL_12de: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e8: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		DataTable dataTable3 = new DataTable();
		DataTable dataTable4 = new DataTable();
		DataTable dataTable5 = new DataTable();
		DataTable dataTable6 = new DataTable();
		DataTable dataTable7 = new DataTable();
		DataTable dataTable8 = new DataTable();
		DataTable dataTable9 = new DataTable();
		DataTable dataTable10 = new DataTable();
		DataTable dataTable11 = new DataTable();
		DataTable dataTable12 = new DataTable();
		try
		{
			_ = string.Empty;
			Convert.ToInt32(Session["finyear"]);
			int num = Convert.ToInt32(Session["compid"]);
			string text = TextBox3.Text;
			string text2 = TextBox4.Text;
			SqlCommand selectCommand = new SqlCommand("SELECT sum(tblACC_BillBooking_Details.ExStBasic)as exba,sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,tblMM_PO_Details.VAT,tblMM_PO_Details.ExST FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id  INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id AND tblMM_PO_Master.SupplierId!='S0098' And  tblACC_BillBooking_Master.CompId='" + num + "'  AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(text) + "' And '" + fun.FromDate(text2) + "' Group by tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Details.MId", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SqlCommand selectCommand2 = new SqlCommand("SELECT sum(tblACC_BillBooking_Details.ExStBasic)as exba,sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblinv_MaterialServiceNote_Details ON tblACC_BillBooking_Details.GSNId =tblinv_MaterialServiceNote_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId =tblMM_PO_Details.Id  INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id AND tblMM_PO_Master.SupplierId!='S0098' And  tblACC_BillBooking_Master.CompId='" + num + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(text) + "'  And '" + fun.FromDate(text2) + "' Group by tblMM_PO_Details.ExST,tblMM_PO_Details.VAT, tblACC_BillBooking_Details.MId", sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			dataSet2.Tables[0].Merge(dataSet.Tables[0]);
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("VATerms", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VATAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("CSTTerms", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("CSTAmt", typeof(double)));
			dataTable3.Columns.Add(new DataColumn("ExciseTerm", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("ExBasicAmt", typeof(double)));
			dataTable4.Columns.Add(new DataColumn("VATTerm", typeof(string)));
			dataTable4.Columns.Add(new DataColumn("Amt", typeof(double)));
			dataTable5.Columns.Add(new DataColumn("CSTTerm", typeof(string)));
			dataTable5.Columns.Add(new DataColumn("CSTAmt", typeof(double)));
			dataTable6.Columns.Add(new DataColumn("EXTerm", typeof(string)));
			dataTable6.Columns.Add(new DataColumn("EXAmt", typeof(double)));
			new DataSet();
			double num2 = 0.0;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				double num3 = 0.0;
				double num4 = 0.0;
				DataRow dataRow = dataTable.NewRow();
				DataRow dataRow2 = dataTable2.NewRow();
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow[0] = num;
				double num5 = 0.0;
				string cmdText = fun.select("Terms,Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + dataSet2.Tables[0].Rows[i]["VAT"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows[0]["IsVAT"].ToString() == "1")
				{
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["vat1"]);
				}
				else if (dataSet3.Tables[0].Rows[0]["IsCST"].ToString() == "1")
				{
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["cst"]);
				}
				else if (dataSet3.Tables[0].Rows[0]["IsVAT"].ToString() == "0" && dataSet3.Tables[0].Rows[0]["IsCST"].ToString() == "0")
				{
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["vat1"]);
				}
				num3 = num5;
				num4 = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["she"]);
				string cmdText2 = fun.select("Terms", "tblExciseser_Master", "Id='" + dataSet2.Tables[0].Rows[i]["ExST"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow3[0] = dataSet4.Tables[0].Rows[0]["Terms"].ToString();
					dataRow3[1] = num4;
					dataTable3.Rows.Add(dataRow3);
					dataTable3.AcceptChanges();
				}
				if (dataSet3.Tables[0].Rows[0]["IsCST"].ToString() == "0")
				{
					dataRow[1] = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[2] = num3;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				else
				{
					dataRow2[0] = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
					dataRow2[1] = num3;
					dataTable2.Rows.Add(dataRow2);
					dataTable2.AcceptChanges();
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				var varlist = from row in dataTable.AsEnumerable()
					group row by new
					{
						y = row.Field<string>("VATerms")
					} into grp
					let row1 = grp.First()
					select new
					{
						CompId = row1.Field<int>("CompId"),
						VATerms = row1.Field<string>("VATerms"),
						VATAmt = grp.Sum((DataRow r) => r.Field<double>("VATAmt"))
					};
				dataTable7 = LINQToDataTable(varlist);
			}
			if (dataTable2.Rows.Count > 0)
			{
				var varlist2 = from row2 in dataTable2.AsEnumerable()
					group row2 by new
					{
						y = row2.Field<string>("CSTTerms")
					} into grp2
					let row12 = grp2.First()
					select new
					{
						CSTerms = row12.Field<string>("CSTTerms"),
						CSTAmt = grp2.Sum((DataRow r) => r.Field<double>("CSTAmt"))
					};
				dataTable8 = LINQToDataTable(varlist2);
			}
			if (dataTable3.Rows.Count > 0)
			{
				var varlist3 = from row2 in dataTable3.AsEnumerable()
					group row2 by new
					{
						y = row2.Field<string>("ExciseTerm")
					} into grp2
					let row12 = grp2.First()
					select new
					{
						ExciseTerm = row12.Field<string>("ExciseTerm"),
						ExBasicAmt = grp2.Sum((DataRow r) => r.Field<double>("ExBasicAmt"))
					};
				dataTable9 = LINQToDataTable(varlist3);
			}
			string cmdText3 = "Select ((ReqQty*AmtInPer/100)*Rate) as Amt,PFType,PF,FreightType,Freight,CENVAT,CST,VAT from tblACC_SalesInvoice_Details,tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id And CompId='" + num + "' And  tblACC_SalesInvoice_Master.DateOfIssueInvoice Between '" + fun.FromDate(text) + "' And '" + fun.FromDate(text2) + "' order by tblACC_SalesInvoice_Master.Id ";
			SqlCommand selectCommand5 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			int num6 = 0;
			num6 = dataSet5.Tables[0].Rows.Count;
			for (int num7 = 0; num7 < dataSet5.Tables[0].Rows.Count; num7++)
			{
				DataRow dataRow4 = dataTable4.NewRow();
				DataRow dataRow5 = dataTable5.NewRow();
				DataRow dataRow6 = dataTable6.NewRow();
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				num8 = Convert.ToDouble(dataSet5.Tables[0].Rows[num7]["Amt"]);
				num9 = ((Convert.ToInt32(dataSet5.Tables[0].Rows[num7]["PFType"]) != 0) ? (num8 * Convert.ToDouble(dataSet5.Tables[0].Rows[num7]["PF"]) / 100.0) : Convert.ToDouble(dataSet5.Tables[0].Rows[num7]["PF"]));
				num10 = ((Convert.ToInt32(dataSet5.Tables[0].Rows[num7]["FreightType"]) != 0) ? (num8 * Convert.ToDouble(dataSet5.Tables[0].Rows[num7]["Freight"]) / 100.0) : Convert.ToDouble(dataSet5.Tables[0].Rows[num7]["Freight"]));
				double num13 = 0.0;
				num13 = num9 / (double)num6;
				num12 = num8 + num13;
				string cmdText4 = fun.select("*", "tblExciseser_Master", string.Concat("Id='", dataSet5.Tables[0].Rows[num7]["CENVAT"], "'"));
				SqlCommand selectCommand6 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					num11 = num12 * Convert.ToDouble(dataSet6.Tables[0].Rows[0]["Value"]) / 100.0;
					dataRow6[0] = dataSet6.Tables[0].Rows[0]["Terms"].ToString();
					dataRow6[1] = num11;
					dataTable6.Rows.Add(dataRow6);
					dataTable6.AcceptChanges();
				}
				double num14 = 0.0;
				num14 = num10 / (double)num6;
				double num15 = 0.0;
				double num16 = 0.0;
				num15 = num12 + num11;
				if (dataSet5.Tables[0].Rows[num7]["VAT"].ToString() != "0")
				{
					string cmdText5 = fun.select("Value,Terms", "tblVAT_Master", "Id='" + dataSet5.Tables[0].Rows[num7]["VAT"].ToString() + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7, "tblVAT_Master");
					num16 = (num15 + num14) * Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Value"]) / 100.0;
					num2 += Math.Round(num16, 2);
					dataRow4[0] = dataSet7.Tables[0].Rows[0]["Terms"].ToString();
					dataRow4[1] = Math.Round(num16, 2);
					dataTable4.Rows.Add(dataRow4);
					dataTable4.AcceptChanges();
				}
				else if (dataSet5.Tables[0].Rows[num7]["CST"].ToString() != "0")
				{
					string cmdText6 = fun.select("*", "tblVAT_Master", "Id='" + dataSet5.Tables[0].Rows[num7]["CST"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8, "tblVAT_Master");
					num16 = num15 * Convert.ToDouble(dataSet8.Tables[0].Rows[0]["Value"]) / 100.0 + num14;
					dataRow5[0] = dataSet8.Tables[0].Rows[0]["Terms"].ToString();
					dataRow5[1] = num16;
					dataTable5.Rows.Add(dataRow5);
					dataTable5.AcceptChanges();
				}
			}
			if (dataTable4.Rows.Count > 0)
			{
				var varlist4 = from row in dataTable4.AsEnumerable()
					group row by new
					{
						y = row.Field<string>("VATTerm")
					} into grp
					let row1 = grp.First()
					select new
					{
						VatTerm = row1.Field<string>("VATTerm"),
						Amt = grp.Sum((DataRow r) => r.Field<double>("Amt"))
					};
				dataTable10 = LINQToDataTable(varlist4);
			}
			if (dataTable5.Rows.Count > 0)
			{
				var varlist5 = from row in dataTable5.AsEnumerable()
					group row by new
					{
						y = row.Field<string>("CSTTerm")
					} into grp
					let row1 = grp.First()
					select new
					{
						CSTTerm = row1.Field<string>("CSTTerm"),
						CSTAmt = grp.Sum((DataRow r) => r.Field<double>("CSTAmt"))
					};
				dataTable11 = LINQToDataTable(varlist5);
			}
			if (dataTable6.Rows.Count > 0)
			{
				var varlist6 = from row in dataTable6.AsEnumerable()
					group row by new
					{
						y = row.Field<string>("EXTerm")
					} into grp
					let row1 = grp.First()
					select new
					{
						EXTerm = row1.Field<string>("EXTerm"),
						EXAmt = grp.Sum((DataRow r) => r.Field<double>("EXAmt"))
					};
				dataTable12 = LINQToDataTable(varlist6);
			}
			if (dataTable7.Rows.Count > 0 || dataTable8.Rows.Count > 0 || dataTable9.Rows.Count > 0 || dataTable10.Rows.Count > 0 || dataTable11.Rows.Count > 0 || dataTable12.Rows.Count > 0)
			{
				((Control)(object)CrystalReportViewer3).Visible = true;
				Label2.Visible = false;
				DataSet dataSet9 = new EX_VAT_CST_Compute();
				dataSet9.Tables[0].Merge(dataTable7);
				dataSet9.Tables[1].Merge(dataTable8);
				dataSet9.Tables[2].Merge(dataTable9);
				dataSet9.Tables[3].Merge(dataTable10);
				dataSet9.Tables[4].Merge(dataTable11);
				dataSet9.Tables[5].Merge(dataTable12);
				cryRpt2 = new ReportDocument();
				cryRpt2.Load(base.Server.MapPath("~/Module/MIS/Reports/Ex_Vat_CST_Computation.rpt"));
				cryRpt2.SetDataSource(dataSet9);
				string text3 = fun.CompAdd(num);
				cryRpt2.SetParameterValue("Address", (object)text3);
				cryRpt2.SetParameterValue("FDate", (object)text);
				cryRpt2.SetParameterValue("TDate", (object)text2);
				cryRpt2.SetParameterValue("VATGrossTotal", (object)num2);
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
			sqlConnection.Dispose();
			dataTable.Dispose();
			dataTable2.Dispose();
			dataTable3.Dispose();
			dataTable4.Dispose();
			dataTable5.Dispose();
			dataTable6.Dispose();
			dataTable7.Dispose();
			dataTable8.Dispose();
			dataTable9.Dispose();
			dataTable10.Dispose();
			dataTable11.Dispose();
			dataTable12.Dispose();
			GC.Collect();
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

	public DateTime FirstDateInLastMonth()
	{
		return new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
	}

	public DateTime LastDateInLastMonth()
	{
		DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
		return dateTime.AddMonths(1).AddDays(-1.0);
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer3).Dispose();
		CrystalReportViewer3 = null;
		GC.Collect();
	}
}

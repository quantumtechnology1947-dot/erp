using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class WO_Budget_BudgetCodeWise
{
	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt CBBA = new CalBalBudgetAmt();

	private string connStr = "";

	private SqlConnection con;

	public WO_Budget_BudgetCodeWise()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public DataTable FillDataTableToExport(int CompId, int FinYearId, string x, string y, string z, string l)
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable.Columns.Add(new DataColumn("Sr No", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Project Title", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Mech.Mfg[M]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Mech.Bought[MB]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Elec.Mfg[E]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Elec.Bought[EB]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Labour Charges[L]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Transportation[T]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Conveyance[C]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Site Expences[S]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Others[O]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Consultancy[CO]", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PO Basic", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Tax", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PO Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Tot.Balance", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MKT PO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("INV Amt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bank Receipt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bal", typeof(double)));
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("POBasicAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("POTaxAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("POTotalAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("TotBudgetAssined", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("BalBudget", typeof(double)));
			con.Open();
			string cmdText = "select Id,CustomerId,TaskProjectTitle,WONo,FinYear from SD_Cust_WorkOrder_Master inner join tblFinancial_master on SD_Cust_WorkOrder_Master.FinYearId=tblFinancial_master.FinYearId  And SD_Cust_WorkOrder_Master.FinYearId<=" + FinYearId + " And SD_Cust_WorkOrder_Master.CloseOpen=0 And SD_Cust_WorkOrder_Master.CompId=" + CompId + l + x + y + z + " Order by SD_Cust_WorkOrder_Master.WONo ASC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			int num = 1;
			while (sqlDataReader.Read())
			{
				if (!sqlDataReader.HasRows)
				{
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = num++;
				dataRow[1] = sqlDataReader["FinYear"].ToString();
				dataRow[2] = sqlDataReader["WONo"].ToString();
				dataRow[3] = sqlDataReader["TaskProjectTitle"].ToString();
				string cmdText2 = "SELECT Id FROM tblMIS_BudgetCode";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				int num2 = 5;
				while (sqlDataReader2.Read())
				{
					if (sqlDataReader2.HasRows)
					{
						DataTable dataTable3 = new DataTable();
						dataTable3 = CBBA.TotBudget_WONO_1(Convert.ToInt32(sqlDataReader2["Id"]), CompId, FinYearId, sqlDataReader["WONo"].ToString(), 0);
						dataTable2.Rows.Add(dataTable3.Rows[0]["WONo"], dataTable3.Rows[0]["POBasicAmt"], dataTable3.Rows[0]["POTaxAmt"], dataTable3.Rows[0]["POTotalAmt"], dataTable3.Rows[0]["TotBudgetAssined"], dataTable3.Rows[0]["BalBudget"]);
						dataRow[num2] = Convert.ToDouble(dataTable3.Rows[0]["TotBudgetAssined"]);
					}
					num2++;
				}
				if (dataTable2.Rows.Count > 0)
				{
					var source = from row in dataTable2.AsEnumerable()
						group row by new
						{
							y = row.Field<string>("WONo")
						} into grp
						select new
						{
							Total1 = grp.Sum((DataRow r) => r.Field<double>("POBasicAmt")),
							Total2 = grp.Sum((DataRow r) => r.Field<double>("POTaxAmt")),
							Total3 = grp.Sum((DataRow r) => r.Field<double>("POTotalAmt")),
							Total4 = grp.Sum((DataRow r) => r.Field<double>("TotBudgetAssined")),
							Total5 = grp.Sum((DataRow r) => r.Field<double>("BalBudget"))
						};
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					foreach (var item in source.ToList())
					{
						num3 = Convert.ToDouble(item.Total1);
						num4 = Convert.ToDouble(item.Total2);
						num5 = Convert.ToDouble(item.Total3);
						num6 = Convert.ToDouble(item.Total4);
						num7 = Convert.ToDouble(item.Total5);
					}
					dataRow[4] = num6;
					dataRow[15] = num3;
					dataRow[16] = num4;
					dataRow[17] = num5;
					dataRow[18] = num7;
					dataRow[19] = 0;
					string text = "";
					text = sqlDataReader["CustomerId"].ToString();
					string text2 = "";
					text2 = sqlDataReader["Id"].ToString() + ",";
					double num8 = 0.0;
					num8 = TotInvAmt(text, text2);
					dataRow[20] = num8;
					double num9 = 0.0;
					string cmdText3 = fun.select("Sum(Amount) AS Amount ", "tblACC_BankVoucher_Received_Masters", string.Concat("WONo='", sqlDataReader["WONo"], "'"));
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					if (sqlDataReader3.HasRows && sqlDataReader3["Amount"] != DBNull.Value)
					{
						num9 = Math.Round(Convert.ToDouble(sqlDataReader3["Amount"]), 2);
					}
					dataRow[21] = num9;
					dataRow[22] = 0;
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
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

	public double TotInvAmt(string CustCode, string WONo)
	{
		double num = 0.0;
		try
		{
			string cmdText = "select Id from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='" + CustCode + "' AND tblACC_SalesInvoice_Master.WONo='" + WONo + "' ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
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
				string cmdText2 = string.Concat("select sum(case when Unit_Master.EffectOnInvoice=1 then (ReqQty*(AmtInPer/100)*Rate) Else (ReqQty*Rate) End) As Amt from tblACC_SalesInvoice_Details inner join tblACC_SalesInvoice_Master on tblACC_SalesInvoice_Master.Id=tblACC_SalesInvoice_Details.MId inner join  Unit_Master on tblACC_SalesInvoice_Details.Unit=Unit_Master.Id And tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "' And tblACC_SalesInvoice_Master.Id=", sqlDataReader["Id"], " ");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				num2 += Convert.ToDouble(sqlDataReader2["Amt"]);
				string cmdText3 = string.Concat("select Sum(case when AddType=0 then AddAmt Else ((", num2, " *AddAmt)/100)End) As AddAmt from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				num5 = Convert.ToDouble(sqlDataReader3["AddAmt"]);
				num3 += num2 + num5;
				string cmdText4 = string.Concat("select Sum(case when DeductionType=0 then Deduction Else ((", num3, " *Deduction)/100)End) As deduct from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "' ");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				num4 = Convert.ToDouble(sqlDataReader4["deduct"]);
				num6 += num3 - num4;
				string cmdText5 = string.Concat("select Sum(case when PFType=0 then PF Else ((", num6, " *PF)/100)End) As pf from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				num7 = Convert.ToDouble(sqlDataReader5["pf"]);
				num9 += num6 + num7;
				string cmdText6 = string.Concat("select Sum((", num9, ")*((tblExciseser_Master.AccessableValue)/100) + ((", num9, ")*((tblExciseser_Master.AccessableValue)/100)*tblExciseser_Master.EDUCess/100)+((", num9, ")*((tblExciseser_Master.AccessableValue)/100)*tblExciseser_Master.SHECess/100)) As Ex from  tblACC_SalesInvoice_Master inner join tblExciseser_Master on tblExciseser_Master.Id=tblACC_SalesInvoice_Master.CENVAT where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				num8 = Convert.ToDouble(sqlDataReader6["Ex"]);
				num10 += num9 + num8;
				string cmdText7 = string.Concat("select FreightType,Freight,InvoiceMode,CST,VAT from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				while (sqlDataReader7.Read())
				{
					double num16 = Convert.ToDouble(sqlDataReader7["Freight"].ToString());
					double num17 = 0.0;
					if (sqlDataReader7["InvoiceMode"].ToString() == "2")
					{
						num12 = ((!(sqlDataReader7["FreightType"].ToString() == "0")) ? (num10 * (num16 / 100.0)) : num16);
						string cmdText8 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader7["VAT"].ToString() + "'");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText8, con);
						SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
						while (sqlDataReader8.Read())
						{
							num17 = Convert.ToDouble(sqlDataReader8["Value"]);
						}
						num13 = (num10 + num12) * (num17 / 100.0);
					}
					else if (sqlDataReader7["InvoiceMode"].ToString() == "3")
					{
						string cmdText9 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader7["CST"].ToString() + "'");
						SqlCommand sqlCommand9 = new SqlCommand(cmdText9, con);
						SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
						while (sqlDataReader9.Read())
						{
							num17 = Convert.ToDouble(sqlDataReader9["Value"]);
						}
						num12 = num10 * (num17 / 100.0);
						num13 = ((!(sqlDataReader7["FreightType"].ToString() == "0")) ? ((num10 + num12) * (num16 / 100.0)) : num16);
					}
				}
				num11 += num10 + num12;
				num14 += num11 + num13;
				string cmdText10 = string.Concat("select Sum(case when InsuranceType=0 then Insurance Else ((", num14, " *Insurance)/100)End) As Insurance from  tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", CustCode, "'And tblACC_SalesInvoice_Master.Id='", sqlDataReader["Id"], "'");
				SqlCommand sqlCommand10 = new SqlCommand(cmdText10, con);
				SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
				sqlDataReader10.Read();
				num15 = Convert.ToDouble(sqlDataReader10["Insurance"]);
				num += num14 + num15;
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}
}

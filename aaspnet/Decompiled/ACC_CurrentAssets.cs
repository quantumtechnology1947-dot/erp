using System;
using System.Data;
using System.Data.SqlClient;

public class ACC_CurrentAssets
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	public ACC_CurrentAssets()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public DataTable TotInvQty2(int CompId, int FinId, string CustId)
	{
		DataTable dataTable = new DataTable();
		con.Open();
		string text = string.Empty;
		if (CustId != "")
		{
			text = " AND CustomerId='" + CustId + "'";
		}
		string cmdText = fun.select("CustomerName+'['+CustomerId+']' As Customer, CustomerId", "SD_Cust_master", "CompId='" + CompId + "' AND FinYearId<='" + FinId + "'" + text);
		SqlCommand sqlCommand = new SqlCommand(cmdText, con);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		dataTable.Columns.Add(new DataColumn("CustName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("TotAmt", typeof(double)));
		dataTable.Columns.Add(new DataColumn("CustCode", typeof(string)));
		dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
		dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
		while (sqlDataReader.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			double num = 0.0;
			string cmdText2 = string.Concat("select InvoiceNo,OtherAmt from tblACC_SalesInvoice_Master where tblACC_SalesInvoice_Master.CustomerCode='", sqlDataReader["CustomerId"], "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			while (sqlDataReader2.Read())
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
				dataRow[3] = sqlDataReader2["InvoiceNo"];
			}
			dataRow[0] = sqlDataReader["Customer"].ToString();
			dataRow[1] = Math.Round(num, 2);
			dataRow[2] = sqlDataReader["CustomerId"].ToString();
			dataRow[4] = CompId;
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
		}
		con.Close();
		return dataTable;
	}

	public double TotLoanLiability(int CompId, int FinId)
	{
		double result = 0.0;
		try
		{
			con.Open();
			string cmdText = "Select Sum(CreditAmt) As loan from tblAcc_LoanDetails inner join tblAcc_LoanMaster on tblAcc_LoanDetails.MId=tblAcc_LoanMaster.Id And CompId=" + CompId + " AND FinYearId<='" + FinId + "'  ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			result = Convert.ToDouble(sqlDataReader["loan"]);
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return result;
	}

	public double TotCapitalGoods(int CompId, int FinId)
	{
		double result = 0.0;
		try
		{
			con.Open();
			string cmdText = "Select Sum(CreditAmt) As capital from tblACC_Capital_Details inner join tblACC_Capital_Master on tblACC_Capital_Details.MId=tblACC_Capital_Master.Id And CompId=" + CompId + " AND FinYearId<='" + FinId + "'  ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			result = Convert.ToDouble(sqlDataReader["capital"]);
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return result;
	}
}

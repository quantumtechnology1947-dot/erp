using System;
using System.Data;
using System.Data.SqlClient;

public class CalBalBudgetAmt
{
	private clsFunctions fun = new clsFunctions();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private string connStr = "";

	private SqlConnection con;

	public CalBalBudgetAmt()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public double TotBalBudget_BG(int BGId, int CompId, int FinYearId, int Flag)
	{
		double result = 0.0;
		try
		{
			con.Open();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			string cmdText = "select Sum(Amount) As Budget from tblACC_Budget_Dept where BGId='" + BGId + "' And CompId=" + CompId + " And FinYearId<=" + FinYearId + " group by  BGId ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				num = Math.Round(Convert.ToDouble(sqlDataReader["Budget"].ToString()), 2);
			}
			if (Flag == 0)
			{
				num2 = PBM.getTotal_PO_Budget_Amt(CompId, BGId, 1, 1, "0", BGId, 1, FinYearId);
				num5 = PBM.getTotal_PO_Budget_Amt(CompId, BGId, 1, 1, "0", BGId, 2, FinYearId);
			}
			else
			{
				num2 = fun.getTotal_PO_Budget_Amt(CompId, BGId, 1, 1, "0", BGId, 1);
				num5 = fun.getTotal_PO_Budget_Amt(CompId, BGId, 1, 1, "0", BGId, 2);
			}
			string cmdText2 = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt, tblACC_CashVoucher_Payment_Details.BGGroup FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.BGGroup='" + BGId + "' And tblACC_CashVoucher_Payment_Master.CompId=" + CompId + " And tblACC_CashVoucher_Payment_Master.FinYearId<=" + FinYearId + " GROUP BY tblACC_CashVoucher_Payment_Details.BGGroup";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			if (sqlDataReader2.HasRows)
			{
				num3 = Convert.ToDouble(sqlDataReader2[0]);
			}
			string cmdText3 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt, tblACC_CashVoucher_Receipt_Master.BGGroup,  tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.BGGroup='" + BGId + "' And CompId=" + CompId + " And FinYearId<=" + FinYearId + " GROUP BY tblACC_CashVoucher_Receipt_Master.BGGroup, tblACC_CashVoucher_Receipt_Master.WONo";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			sqlDataReader3.Read();
			if (sqlDataReader3.HasRows)
			{
				num4 = Convert.ToDouble(sqlDataReader3[0]);
			}
			result = Math.Round(num - (num2 + num5 + num3), 2) + num4;
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

	public double TotBalBudget_WONO(int AccId, int CompId, int FinYearId, string WoNo, int Flag)
	{
		double result = 0.0;
		try
		{
			con.Open();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double value = 0.0;
			double value2 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			string cmdText = "select Sum(Amount) As Budget from tblACC_Budget_WO where BudgetCodeId='" + AccId + "'   and  WONo='" + WoNo + "' And CompId=" + CompId + " And FinYearId<=" + FinYearId + "  group by  BudgetCodeId ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				num = Math.Round(Convert.ToDouble(sqlDataReader["Budget"].ToString()), 2);
			}
			if (Flag == 0)
			{
				num3 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 1, FinYearId);
				num2 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 1, FinYearId);
				num5 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 2, FinYearId);
				num4 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 2, FinYearId);
			}
			else
			{
				num3 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 1);
				num2 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 1);
				num5 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 2);
				num4 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 2);
			}
			string cmdText2 = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt  ,tblACC_CashVoucher_Payment_Details.WONo FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.WONo='" + WoNo + "' And tblACC_CashVoucher_Payment_Master.FinYearId <=" + FinYearId + "  And tblACC_CashVoucher_Payment_Details.BudgetCode='" + AccId + "' GROUP BY tblACC_CashVoucher_Payment_Details.BudgetCode, tblACC_CashVoucher_Payment_Details.WONo";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			if (sqlDataReader2.HasRows)
			{
				value = Convert.ToDouble(sqlDataReader2[0]);
			}
			string cmdText3 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt,   tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.WONo='" + WoNo + "' And tblACC_CashVoucher_Receipt_Master.FinYearId <=" + FinYearId + "  And     tblACC_CashVoucher_Receipt_Master.BudgetCode='" + AccId + "' GROUP BY tblACC_CashVoucher_Receipt_Master.BudgetCode, tblACC_CashVoucher_Receipt_Master.WONo";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			sqlDataReader3.Read();
			if (sqlDataReader3.HasRows)
			{
				value2 = Convert.ToDouble(sqlDataReader3[0]);
			}
			result = Math.Round(num - (Math.Round(num3 + num2, 2) + Math.Round(num5 + num4, 2) + Math.Round(value, 2)), 2) + Math.Round(value2, 2);
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

	public DataTable TotBudget_WONO_1(int AccId, int CompId, int FinYearId, string WoNo, int Flag)
	{
		DataTable dataTable = new DataTable();
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double value = 0.0;
			double value2 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			num7 = FinYearId - 1;
			double num8 = 0.0;
			num8 = TotBalBudget_WONO(AccId, CompId, num7, WoNo, 0);
			con.Open();
			string cmdText = "select Sum(Amount) As Budget from tblACC_Budget_WO where BudgetCodeId='" + AccId + "'   and  WONo='" + WoNo + "' And CompId=" + CompId + " And FinYearId=" + FinYearId + "  group by  BudgetCodeId ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			num = ((!sqlDataReader.HasRows) ? num8 : Math.Round(Convert.ToDouble(sqlDataReader["Budget"]) + num8, 2));
			if (Flag == 0)
			{
				num4 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 1, FinYearId);
				num3 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 1, FinYearId);
				num6 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 2, FinYearId);
				num5 = PBM.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 2, FinYearId);
			}
			else
			{
				num4 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 1);
				num3 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 1);
				num6 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 0, 1, WoNo, 0, 2);
				num5 = fun.getTotal_PO_Budget_Amt(CompId, AccId, 1, 1, WoNo, 0, 2);
			}
			string cmdText2 = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt  ,tblACC_CashVoucher_Payment_Details.WONo FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.WONo='" + WoNo + "' And tblACC_CashVoucher_Payment_Master.FinYearId =" + FinYearId + "  And tblACC_CashVoucher_Payment_Details.BudgetCode='" + AccId + "' GROUP BY tblACC_CashVoucher_Payment_Details.BudgetCode, tblACC_CashVoucher_Payment_Details.WONo";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			if (sqlDataReader2.HasRows)
			{
				value = Convert.ToDouble(sqlDataReader2[0]);
			}
			string cmdText3 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt,   tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.WONo='" + WoNo + "' And tblACC_CashVoucher_Receipt_Master.FinYearId =" + FinYearId + "  And     tblACC_CashVoucher_Receipt_Master.BudgetCode='" + AccId + "' GROUP BY tblACC_CashVoucher_Receipt_Master.BudgetCode, tblACC_CashVoucher_Receipt_Master.WONo";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			sqlDataReader3.Read();
			if (sqlDataReader3.HasRows)
			{
				value2 = Convert.ToDouble(sqlDataReader3[0]);
			}
			num2 = Math.Round(num - (Math.Round(num4 + num3, 2) + Math.Round(num6 + num5, 2) + Math.Round(value, 2)), 2) + Math.Round(value2, 2);
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POBasicAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POTaxAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POTotalAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotBudgetAssined", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BalBudget", typeof(double)));
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = WoNo;
			dataRow[1] = Math.Round(num4 + num3, 2);
			dataRow[2] = Math.Round(num6 + num5, 2);
			dataRow[3] = Math.Round(num4 + num3 + num6 + num5, 2);
			dataRow[4] = num;
			dataRow[5] = num2;
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
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
}

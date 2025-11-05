using System;
using System.Data.SqlClient;

public class PO_Budget_Amt
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	public PO_Budget_Amt()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public double getTotal_PO_Budget_Amt(int compid, int accid, int prspr, int wodept, string wono, int dept, int BasicTax, int FinYearId)
	{
		con.Open();
		double num = 0.0;
		try
		{
			if (prspr == 0)
			{
				string text = "";
				if (wodept == 1)
				{
					text = " AND tblMM_PR_Master.WONo='" + wono + "'";
				}
				string cmdText = "SELECT tblMM_PO_Details.Qty, tblMM_PO_Details.Rate, tblMM_PO_Details.Discount, tblVAT_Master.Value As VAT,tblExciseser_Master.Value AS Excise, tblPacking_Master.Value AS PF FROM tblMM_PR_Details INNER JOIN tblMM_PR_Master ON tblMM_PR_Details.MId = tblMM_PR_Master.Id INNER JOIN tblMM_PO_Details INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN tblVAT_Master ON tblMM_PO_Details.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_PO_Details.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_PO_Details.PF = tblPacking_Master.Id And tblMM_PO_Master.FinYearId='" + FinYearId + "' And tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Details.BudgetCode='" + accid + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "'" + text + " ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					if (BasicTax == 0)
					{
						num += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")));
					}
					if (BasicTax == 1)
					{
						num += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")));
					}
					if (BasicTax == 2)
					{
						double pf = Convert.ToDouble(decimal.Parse(sqlDataReader["PF"].ToString()).ToString("N3"));
						double exser = Convert.ToDouble(decimal.Parse(sqlDataReader["Excise"].ToString()).ToString("N3"));
						double vat = Convert.ToDouble(decimal.Parse(sqlDataReader["VAT"].ToString()).ToString("N3"));
						num += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")), pf, exser, vat);
					}
					if (BasicTax == 3)
					{
						double num2 = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")));
						double num3 = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")));
						num += num2 + num3;
					}
				}
			}
			if (prspr == 1)
			{
				string text2 = "";
				string text3 = "";
				if (wodept == 1)
				{
					if (dept == 0)
					{
						text2 = " AND tblMM_PO_Details.BudgetCode='" + accid + "'";
						text3 = " AND tblMM_SPR_Details.WONo='" + wono + "'";
					}
					else
					{
						text2 = " AND tblMM_PO_Details.BudgetCode='0'";
						text3 = " AND tblMM_SPR_Details.DeptId='" + dept + "'";
					}
				}
				string cmdText2 = "SELECT tblMM_PO_Details.Qty, tblMM_PO_Details.Rate, tblMM_PO_Details.Discount,  tblVAT_Master.Value As VAT,tblExciseser_Master.Value AS Excise, tblPacking_Master.Value AS PF FROM tblMM_SPR_Details INNER JOIN tblMM_SPR_Master ON tblMM_SPR_Details.MId = tblMM_SPR_Master.Id INNER JOIN tblMM_PO_Details INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id ON tblMM_SPR_Details.Id = tblMM_PO_Details.SPRId INNER JOIN tblVAT_Master ON tblMM_PO_Details.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_PO_Details.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_PO_Details.PF = tblPacking_Master.Id And tblMM_PO_Master.CompId='" + compid + "' And tblMM_PO_Master.FinYearId ='" + FinYearId + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "'" + text3 + text2 + " ";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					if (BasicTax == 0)
					{
						num += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")));
					}
					if (BasicTax == 1)
					{
						num += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")));
					}
					if (BasicTax == 2)
					{
						double pf2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["PF"].ToString()).ToString("N3"));
						double exser2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["Excise"].ToString()).ToString("N3"));
						double vat2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["VAT"].ToString()).ToString("N3"));
						num += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")), pf2, exser2, vat2);
					}
					if (BasicTax == 3)
					{
						double num4 = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")));
						double num5 = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")));
						num += num4 + num5;
					}
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}
}

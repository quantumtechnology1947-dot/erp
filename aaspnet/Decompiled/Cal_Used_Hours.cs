using System;
using System.Data.SqlClient;
using System.Linq;

public class Cal_Used_Hours
{
	private clsFunctions fun = new clsFunctions();

	private TimeBudget_DeptDataContext TBDC = new TimeBudget_DeptDataContext();

	private SqlConnection con;

	private string connStr = "";

	public Cal_Used_Hours()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public string TotFillPart(int Grade, string WONo, int Dept, int CompId, int FinYearId, int flag)
	{
		double num = 0.0;
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = ((flag != 0) ? ("select Sum(Hours) As ConsumedHrs from tblPM_ManPowerPlanning_Temp INNER JOIN tblHR_OfficeStaff ON tblPM_ManPowerPlanning_Temp.EmpId = tblHR_OfficeStaff.EmpId And tblPM_ManPowerPlanning_Temp.CompId=" + CompId + " And tblPM_ManPowerPlanning.FinYearId<=" + FinYearId + " And Grade=" + Grade + " And WONo='" + WONo + "'And Dept=" + Dept + " group by Grade") : ("select Sum(Hours) As ConsumedHrs  from tblPM_ManPowerPlanning INNER JOIN tblHR_OfficeStaff ON tblPM_ManPowerPlanning.EmpId = tblHR_OfficeStaff.EmpId And tblPM_ManPowerPlanning.CompId=" + CompId + " And tblPM_ManPowerPlanning.FinYearId<=" + FinYearId + " And Grade=" + Grade + " And WONo='" + WONo + "'And Dept=" + Dept + " group by Grade"));
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num = Convert.ToDouble(sqlDataReader["ConsumedHrs"]);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return num.ToString("####0.00");
	}

	public double BalanceHours(int Grade, int Dept, int CompId, int FinYearId, int Case)
	{
		double num = 0.0;
		string empty = string.Empty;
		double num2 = 0.0;
		double num3 = 0.0;
		var source = from row in TBDC.GetTable<tblACC_Budget_Dept_Time>()
			where row.BGGroup == (int?)Dept && row.BudgetCodeId == (int?)Grade && row.CompId == (int?)CompId && row.FinYearId <= (int?)FinYearId
			group row by new
			{
				y = row.BudgetCodeId
			} into grp
			select new
			{
				Total = grp.Sum((tblACC_Budget_Dept_Time r) => r.Hour)
			};
		double num4 = 0.0;
		foreach (var item in source.ToList())
		{
			num4 = Convert.ToDouble(item.Total);
		}
		num3 = num4;
		num2 = Convert.ToDouble(TotFillPart(Grade, empty, Dept, CompId, FinYearId, 0));
		num = Math.Round(num3 - num2, 2);
		double result = 0.0;
		switch (Case)
		{
		case 0:
			result = num3;
			break;
		case 1:
			result = num2;
			break;
		case 2:
			result = num;
			break;
		}
		return result;
	}

	public double BalanceHours_WONO(int Grade, string WONo, int CompId, int FinYearId, int Case)
	{
		double num = 0.0;
		int dept = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		var source = from row in TBDC.GetTable<tblACC_Budget_WO_Time>()
			where row.WONo == WONo && row.BudgetCodeId == (int?)Grade && row.CompId == (int?)CompId && row.FinYearId == (int?)FinYearId
			group row by new
			{
				y = row.BudgetCodeId
			} into grp
			select new
			{
				Total = grp.Sum((tblACC_Budget_WO_Time r) => r.Hour)
			};
		double num4 = 0.0;
		foreach (var item in source.ToList())
		{
			num4 = Convert.ToDouble(item.Total);
		}
		num3 = num4;
		num2 = Convert.ToDouble(TotFillPart(Grade, WONo, dept, CompId, FinYearId, 0));
		num = Math.Round(num3 - num2, 2);
		double result = 0.0;
		switch (Case)
		{
		case 0:
			result = num3;
			break;
		case 1:
			result = num2;
			break;
		case 2:
			result = num;
			break;
		}
		return result;
	}

	public string UtilizeHrs_WONo(int CompId, string WONo, int EquipId, int Category, int SubCategory)
	{
		double num = 0.0;
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = "SELECT Sum(tblPM_ManPowerPlanning_Details.Hour) As CutilizedHrs FROM tblPM_ManPowerPlanning INNER JOIN tblPM_ManPowerPlanning_Details ON tblPM_ManPowerPlanning.Id = tblPM_ManPowerPlanning_Details.MId AND tblPM_ManPowerPlanning_Details.Category='" + Category + "' AND tblPM_ManPowerPlanning_Details.SubCategory='" + SubCategory + "' AND tblPM_ManPowerPlanning_Details.EquipId='" + EquipId + "' AND tblPM_ManPowerPlanning.WONo='" + WONo + "' Group By tblPM_ManPowerPlanning_Details.EquipId";
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num = Convert.ToDouble(sqlDataReader["CutilizedHrs"]);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return num.ToString("####0.00");
	}

	public string AllocatedHrs_WONo(int CompId, string WONo, int EquipId, int Category, int SubCategory)
	{
		double num = 0.0;
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = fun.select("Sum(Hour) As AllocatedHrs", "tblACC_Budget_WO_Time", "HrsBudgetCat='" + Category + "' AND HrsBudgetSubCat='" + SubCategory + "' AND EquipId='" + EquipId + "' AND WONo='" + WONo + "' Group By EquipId");
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num = Convert.ToDouble(sqlDataReader["AllocatedHrs"]);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return num.ToString("####0.00");
	}

	public double GetTotalAllocatedHrs_WONo(string wono, int Cate, int SubCate)
	{
		double result = 0.0;
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = fun.select("Sum(Hour) As THrs", "tblACC_Budget_WO_Time", "WONo='" + wono + "'  AND HrsBudgetCat='" + Cate + "' AND HrsBudgetSubCat='" + SubCate + "'");
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows && sqlDataReader["THrs"] != DBNull.Value)
			{
				result = Convert.ToDouble(sqlDataReader["THrs"]);
			}
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

	public double GetTotalUtilizeHrs_WONo(string wono, int Cate, int SubCate)
	{
		double result = 0.0;
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = "SELECT Sum(tblPM_ManPowerPlanning_Details.Hour) As UtilizedHrs FROM tblPM_ManPowerPlanning INNER JOIN tblPM_ManPowerPlanning_Details ON tblPM_ManPowerPlanning.Id = tblPM_ManPowerPlanning_Details.MId AND tblPM_ManPowerPlanning_Details.Category='" + Cate + "' AND tblPM_ManPowerPlanning_Details.SubCategory='" + SubCate + "' AND tblPM_ManPowerPlanning.WONo='" + wono + "'";
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows && sqlDataReader["UtilizedHrs"] != DBNull.Value)
			{
				result = Convert.ToDouble(sqlDataReader["UtilizedHrs"]);
			}
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

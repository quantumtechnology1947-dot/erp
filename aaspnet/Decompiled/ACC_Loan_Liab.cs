using System;
using System.Data;
using System.Data.SqlClient;

public class ACC_Loan_Liab
{
	private clsFunctions fun = new clsFunctions();

	private DataTable dt = new DataTable();

	private SqlConnection con;

	private string connStr = "";

	private DataRow dr;

	public ACC_Loan_Liab()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		dt.Columns.Add(new DataColumn("Id", typeof(int)));
		dt.Columns.Add(new DataColumn("Particulars", typeof(string)));
		dt.Columns.Add(new DataColumn("TotCrAmt", typeof(double)));
		dt.Columns.Add(new DataColumn("TotDrAmt", typeof(double)));
	}

	public DataTable TotFillPart(string StrSql)
	{
		try
		{
			con.Open();
			SqlCommand sqlCommand = new SqlCommand(StrSql, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sqlDataReader["Id"].ToString();
				dr[1] = sqlDataReader["Particulars"].ToString();
				dr[2] = Math.Round(Convert.ToDouble(sqlDataReader["loan"]), 2);
				dr[3] = 0;
				dt.Rows.Add(dr);
				dt.AcceptChanges();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return dt;
	}

	public DataTable TotFillPart(int CompId, int FinId, int MId)
	{
		try
		{
			con.Open();
			string cmdText = "select CreditAmt As loan,tblAcc_LoanDetails.Particulars,tblAcc_LoanDetails.Id from tblAcc_LoanDetails inner join tblAcc_LoanMaster on tblAcc_LoanMaster.Id=tblAcc_LoanDetails.MId And CompId=" + CompId + " AND FinYearId<=" + FinId + " And MId=" + MId;
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				dr = dt.NewRow();
				dr[1] = sqlDataReader["Particulars"].ToString();
				dr[2] = Math.Round(Convert.ToDouble(sqlDataReader["loan"]), 2);
				dr[3] = 0;
				dr[0] = Convert.ToInt32(sqlDataReader["Id"]);
				dr[4] = CompId;
				dt.Rows.Add(dr);
				dt.AcceptChanges();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
		return dt;
	}
}

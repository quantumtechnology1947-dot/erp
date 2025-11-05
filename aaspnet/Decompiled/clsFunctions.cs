using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using MKB.TimePicker;
using Telerik.Web.UI;

public class clsFunctions
{
	private string z1 = string.Empty;

	private List<string> listBom = new List<string>();

	private double Y = 1.0;

	private double s = 1.0;

	private double k = 1.0;

	private List<double> list = new List<double>();

	private double z = 1.0;

	private List<double> list1 = new List<double>();

	private List<int> BomAssmbly = new List<int>();

	private List<int> Assmbly = new List<int>();

	private List<int> AssmblyTPL = new List<int>();

	private List<int> BOMId = new List<int>();

	private List<int> componant = new List<int>();

	private List<int> RootAssmbly = new List<int>();

	private List<int> listk = new List<int>();

	public static string UploadsFolder => ConfigurationManager.AppSettings.Get("UploadsFolder");

	public static string GetRandomAlphanumericString(int length)
	{
		return GetRandomString(length, "0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ@#$%");
	}

	public static string GetRandomString(int length, IEnumerable<char> characterSet)
	{
		if (length < 0)
		{
			throw new ArgumentException("length must not be negative", "length");
		}
		if (length > 268435455)
		{
			throw new ArgumentException("length is too big", "length");
		}
		if (characterSet == null)
		{
			throw new ArgumentNullException("characterSet");
		}
		char[] array = characterSet.Distinct().ToArray();
		if (array.Length == 0)
		{
			throw new ArgumentException("characterSet must not be empty", "characterSet");
		}
		byte[] array2 = new byte[length * 8];
		new RNGCryptoServiceProvider().GetBytes(array2);
		char[] array3 = new char[length];
		for (int i = 0; i < length; i++)
		{
			ulong num = BitConverter.ToUInt64(array2, i * 8);
			array3[i] = array[num % (uint)array.Length];
		}
		return new string(array3);
	}

	public string EmpCustSupplierNames(int ct, string code, int CompId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		new DataSet();
		string result = "";
		switch (ct)
		{
		case 1:
		{
			string cmdText4 = select("EmployeeName+'[ '+EmpId+' ]' AS EmployeeName ", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + code + "' ");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
			sqlDataReader4.Read();
			result = sqlDataReader4["EmployeeName"].ToString();
			break;
		}
		case 2:
		{
			string cmdText3 = select("CustomerName+'[ '+CustomerId+' ]' AS CustomerName", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + code + "'");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			sqlDataReader3.Read();
			result = sqlDataReader3["CustomerName"].ToString();
			break;
		}
		case 3:
		{
			string cmdText2 = select("SupplierName+'[ '+SupplierId+' ]' AS SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + code + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			result = sqlDataReader2["SupplierName"].ToString();
			break;
		}
		case 4:
		{
			string cmdText = select("Name", "tblACC_Bank", "Id='" + code + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			result = sqlDataReader["Name"].ToString();
			break;
		}
		}
		sqlConnection.Close();
		return result;
	}

	public double DebitorsOpeningBal(int CompId, string CustomerId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string text = string.Empty;
		if (CustomerId != "")
		{
			text = " AND CustomerId='" + CustomerId + "'";
		}
		string cmdText = select("Sum(OpeningAmt) as Sum_OPAmt", "tblACC_Debitors_Master", "CompId='" + CompId + "'" + text);
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		sqlDataReader.Read();
		double result = 0.0;
		if (sqlDataReader.HasRows && sqlDataReader["Sum_OPAmt"] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(sqlDataReader["Sum_OPAmt"]), 2);
		}
		return result;
	}

	public double getDebitorCredit(int CompId, int FinYearId, string CustId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double result = 0.0;
		try
		{
			string text = string.Empty;
			if (CustId != "")
			{
				text = " AND ReceivedFrom='" + CustId + "'";
			}
			string cmdText = select("Sum(Amount) As Sum_Amt", "tblACC_BankVoucher_Received_Masters", "FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "' AND ReceiveType='2' " + text);
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				result = Convert.ToDouble(sqlDataReader["Sum_Amt"].ToString());
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public double ClStk()
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double result = 0.0;
		try
		{
			string cmdText = select1("*", "tblInv_ClosingStck Order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				result = Convert.ToDouble(sqlDataReader["ClStock"].ToString());
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public double Check_TDSAmt(int CompId, int FinYearId, string GetSupCode, int TDSCode)
	{
		double num = 0.0;
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PVEVId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DiscountType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("DebitAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotalBookedBill", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DTSort", typeof(DateTime)));
			string empty = string.Empty;
			empty = "select (Case When GQNId !=0 then (Select Sum(tblQc_MaterialQuality_Details.AcceptedQty) from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) +PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.PVEVNo from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "' And tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' And tblACC_BillBooking_Master.TDSCode='" + TDSCode + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId";
			SqlCommand sqlCommand = new SqlCommand(empty, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (sqlDataReader["TotalBookedBill"] != DBNull.Value)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[1] = Convert.ToInt32(sqlDataReader["PVEVId"]);
					dataRow[2] = Convert.ToDouble(sqlDataReader["Discount"]);
					dataRow[3] = Convert.ToInt32(sqlDataReader["DiscountType"]);
					dataRow[4] = Convert.ToDouble(sqlDataReader["DebitAmt"]);
					dataRow[5] = Convert.ToDouble(sqlDataReader["OtherCharges"]);
					dataRow[6] = Convert.ToDouble(sqlDataReader["TotalBookedBill"]);
					dataRow[7] = sqlDataReader["PVEVNo"].ToString();
					dataRow[8] = Convert.ToDateTime(sqlDataReader["SysDate"].ToString());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			var enumerable = from x in dataTable.AsEnumerable()
				group x by new
				{
					y = x.Field<int>("PVEVId")
				} into grp
				let row1 = grp.First()
				select new
				{
					SysDate = row1.Field<string>("SysDate"),
					PVEVNo = row1.Field<string>("PVEVNo"),
					PVEVId = row1.Field<int>("PVEVId"),
					Discount = row1.Field<double>("Discount"),
					DiscountType = row1.Field<int>("DiscountType"),
					DebitAmt = row1.Field<double>("DebitAmt"),
					OtherCharges = row1.Field<double>("OtherCharges"),
					TotalBookedBill = grp.Sum((DataRow r) => r.Field<double>("TotalBookedBill")),
					DTSort = row1.Field<DateTime>("DTSort")
				};
			double num2 = 0.0;
			foreach (var item in enumerable)
			{
				num2 = item.TotalBookedBill + item.OtherCharges;
				if (item.DiscountType == 0)
				{
					num2 -= item.Discount;
				}
				else if (item.DiscountType == 1)
				{
					num2 -= num2 * item.Discount / 100.0;
				}
				num += num2 - item.DebitAmt;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return Math.Round(num, 2);
	}

	public double FillGrid_Creditors(int CompId, int FinYearId, int x, string Category)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string cmdText = select("SupplierId,SupplierName+' ['+SupplierId+']' AS SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' order by SupplierId Asc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				string cmdText2 = select("OpeningAmt", "tblACC_Creditors_Master", "SupplierId='" + sqlDataReader["SupplierId"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				double num6 = 0.0;
				if (sqlDataReader2.HasRows && sqlDataReader2["OpeningAmt"] != DBNull.Value)
				{
					num6 = Math.Round(Convert.ToDouble(sqlDataReader2["OpeningAmt"]), 2);
					num += num6;
				}
				double num7 = 0.0;
				num7 = FillGrid_CreditorsBookedBill(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), Category);
				num4 += num7;
				double num8 = 0.0;
				num8 = FillGrid_CreditorsPayment(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), 0, Category);
				num2 += num8;
				double num9 = 0.0;
				num9 = FillGrid_CreditorsCashPayment(CompId, FinYearId, sqlDataReader["SupplierId"].ToString(), 0, Category);
				num3 += num9;
				double num10 = 0.0;
				num10 = Math.Round(num6 + num7 - (num8 + num9), 2);
				num5 += num10;
			}
			switch (x)
			{
			case 1:
				result = Math.Round(num, 2);
				break;
			case 2:
				result = Math.Round(num4, 2);
				break;
			case 3:
				result = Math.Round(num2, 2);
				break;
			case 4:
				result = Math.Round(num5, 2);
				break;
			case 5:
				result = Math.Round(num3, 2);
				break;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public double FillGrid_CreditorsBookedBill(int CompId, int FinYearId, string GetSupCode, string Category)
	{
		double num = 0.0;
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PVEVId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DiscountType", typeof(int)));
			dataTable.Columns.Add(new DataColumn("DebitAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotalBookedBill", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DTSort", typeof(DateTime)));
			string text = string.Empty;
			if (GetSupCode != string.Empty)
			{
				text = " And tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "'";
			}
			string empty = string.Empty;
			empty = ((!(Category == string.Empty)) ? ("select (Case When GQNId !=0 then (Case when tblMM_PO_Details.PRId Is not null then(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_PR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_SPR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) Else (Case when tblMM_PO_Details.PRId Is not null then(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_PR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_SPR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) End)+PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.PVEVNo from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "'" + text + " And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId") : ("select (Case When GQNId !=0 then (Select Sum(tblQc_MaterialQuality_Details.AcceptedQty) from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) +PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.PVEVNo from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "'" + text + " And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId"));
			SqlCommand sqlCommand = new SqlCommand(empty, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (sqlDataReader["TotalBookedBill"] != DBNull.Value)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[1] = Convert.ToInt32(sqlDataReader["PVEVId"]);
					dataRow[2] = Convert.ToDouble(sqlDataReader["Discount"]);
					dataRow[3] = Convert.ToInt32(sqlDataReader["DiscountType"]);
					dataRow[4] = Convert.ToDouble(sqlDataReader["DebitAmt"]);
					dataRow[5] = Convert.ToDouble(sqlDataReader["OtherCharges"]);
					dataRow[6] = Convert.ToDouble(sqlDataReader["TotalBookedBill"]);
					dataRow[7] = sqlDataReader["PVEVNo"].ToString();
					dataRow[8] = Convert.ToDateTime(sqlDataReader["SysDate"].ToString());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			var enumerable = from x in dataTable.AsEnumerable()
				group x by new
				{
					y = x.Field<int>("PVEVId")
				} into grp
				let row1 = grp.First()
				select new
				{
					SysDate = row1.Field<string>("SysDate"),
					PVEVNo = row1.Field<string>("PVEVNo"),
					PVEVId = row1.Field<int>("PVEVId"),
					Discount = row1.Field<double>("Discount"),
					DiscountType = row1.Field<int>("DiscountType"),
					DebitAmt = row1.Field<double>("DebitAmt"),
					OtherCharges = row1.Field<double>("OtherCharges"),
					TotalBookedBill = grp.Sum((DataRow r) => r.Field<double>("TotalBookedBill")),
					DTSort = row1.Field<DateTime>("DTSort")
				};
			double num2 = 0.0;
			foreach (var item in enumerable)
			{
				num2 = item.TotalBookedBill + item.OtherCharges;
				if (item.DiscountType == 0)
				{
					num2 -= item.Discount;
				}
				else if (item.DiscountType == 1)
				{
					num2 -= num2 * item.Discount / 100.0;
				}
				num += num2 - item.DebitAmt;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return Math.Round(num, 2);
	}

	public double FillGrid_CreditorsPayment(int CompId, int FinYearId, string GetSupCode, int PayId, string AccHeadCat)
	{
		double num = 0.0;
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			if (AccHeadCat != "")
			{
				text = " AND AccHead.Category='" + AccHeadCat + "'";
			}
			if (GetSupCode != "")
			{
				text2 = " AND tblACC_BankVoucher_Payment_Master.PayTo='" + GetSupCode + "'";
			}
			if (PayId != 0)
			{
				text3 = " AND tblACC_BankVoucher_Payment_Master.Id='" + PayId + "'";
			}
			double value = 0.0;
			string cmdText = "SELECT  Sum(tblACC_BankVoucher_Payment_Details.Amount+tblACC_BankVoucher_Payment_Master.PayAmt) as Sum_Amt FROM tblACC_BillBooking_Master INNER JOIN tblACC_BillBooking_Details ON tblACC_BillBooking_Master.Id =  tblACC_BillBooking_Details.MId INNER JOIN tblACC_BankVoucher_Payment_Master INNER JOIN tblACC_BankVoucher_Payment_Details ON tblACC_BankVoucher_Payment_Master.Id = tblACC_BankVoucher_Payment_Details.MId ON tblACC_BillBooking_Master.Id = tblACC_BankVoucher_Payment_Details.PVEVNO INNER JOIN AccHead ON tblACC_BillBooking_Master.AHId = AccHead.Id  AND tblACC_BillBooking_Master.AHId !=0 " + text + text2 + text3 + " AND tblACC_BankVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Master.FinYearId<='" + FinYearId + "' AND tblACC_BankVoucher_Payment_Master.Type='4'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows && sqlDataReader["Sum_Amt"] != DBNull.Value)
			{
				value = Math.Round(Convert.ToDouble(sqlDataReader["Sum_Amt"].ToString()), 2);
			}
			num += Math.Round(value, 2);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return num;
	}

	public double FillGrid_CreditorsCashPayment(int CompId, int FinYearId, string GetSupCode, int PayId, string AccHeadCat)
	{
		double num = 0.0;
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			if (AccHeadCat != "")
			{
				text = " AND AccHead.Category='" + AccHeadCat + "'";
			}
			if (GetSupCode != "")
			{
				text2 = " AND tblACC_CashVoucher_Payment_Master.ReceivedBy='" + GetSupCode + "'";
			}
			if (PayId != 0)
			{
				text3 = " AND tblACC_CashVoucher_Payment_Master.Id='" + PayId + "'";
			}
			double value = 0.0;
			string cmdText = "SELECT Sum(tblACC_CashVoucher_Payment_Details.Amount) as Sum_Amt FROM tblACC_CashVoucher_Payment_Details INNER JOIN tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id INNER JOIN AccHead ON tblACC_CashVoucher_Payment_Details.AcHead = AccHead.Id AND tblACC_CashVoucher_Payment_Details.AcHead !=0 " + text + text2 + text3 + " AND tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FinYearId + "'INNER JOIN tblMM_Supplier_master ON tblACC_CashVoucher_Payment_Master.ReceivedBy = tblMM_Supplier_master.SupplierId";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows && sqlDataReader["Sum_Amt"] != DBNull.Value)
			{
				value = Math.Round(Convert.ToDouble(sqlDataReader["Sum_Amt"].ToString()), 2);
			}
			num += Math.Round(value, 2);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return num;
	}

	public double getTotPay(int CompId, string GetSupCode, int FinYearId)
	{
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "SELECT Sum(tblACC_BankVoucher_Payment_Master.PayAmt) As Payment FROM tblACC_BankVoucher_Payment_Master where tblACC_BankVoucher_Payment_Master.PayTo ='" + GetSupCode + "' And tblACC_BankVoucher_Payment_Master.CompId='" + CompId + "' And tblACC_BankVoucher_Payment_Master.FinYearId<='" + FinYearId + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
			}
		}
		catch
		{
		}
		return result;
	}

	public List<int> removeDuplicates(List<int> inputList)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<int> list = new List<int>();
		foreach (int input in inputList)
		{
			if (!dictionary.ContainsKey(input))
			{
				dictionary.Add(input, 0);
				list.Add(input);
			}
		}
		return list;
	}

	public string GetRandomAlphaNumeric()
	{
		return Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
	}

	public List<string> BOMTree_Search(string WONo, int Pid, int Cid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			string cmdText = select("ItemId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='" + Pid + "'And CId='" + Cid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			z1 = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
			listBom.Add(z1);
			if (Pid > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
				int pid = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]);
				BOMTree_Search(WONo, pid, Pid);
			}
			if (Pid == 0)
			{
				DataSet dataSet3 = new DataSet();
				string cmdText3 = select("ItemId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND  PId=0");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3, "tblDG_BOM_Master");
				z1 = dataSet3.Tables[0].Rows[0]["ItemId"].ToString();
				listBom.Add(z1);
			}
		}
		catch (Exception)
		{
		}
		return listBom;
	}

	public double getTotal_PO_Budget_Amt(int compid, int accid, int prspr, int wodept, string wono, int dept, int BasicTax)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
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
				string cmdText = "SELECT tblMM_PO_Details.Qty, tblMM_PO_Details.Rate, tblMM_PO_Details.Discount, tblVAT_Master.Value As VAT,tblExciseser_Master.Value AS Excise, tblPacking_Master.Value AS PF FROM tblMM_PR_Details INNER JOIN tblMM_PR_Master ON tblMM_PR_Details.MId = tblMM_PR_Master.Id INNER JOIN tblMM_PO_Details INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN tblVAT_Master ON tblMM_PO_Details.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_PO_Details.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_PO_Details.PF = tblPacking_Master.Id And tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Details.BudgetCode='" + accid + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "'" + text + " ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					if (BasicTax == 0)
					{
						num += CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")));
					}
					if (BasicTax == 1)
					{
						num += CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")));
					}
					if (BasicTax == 2)
					{
						double pf = Convert.ToDouble(decimal.Parse(sqlDataReader["PF"].ToString()).ToString("N3"));
						double exser = Convert.ToDouble(decimal.Parse(sqlDataReader["Excise"].ToString()).ToString("N3"));
						double vat = Convert.ToDouble(decimal.Parse(sqlDataReader["VAT"].ToString()).ToString("N3"));
						num += CalTaxAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")), pf, exser, vat);
					}
					if (BasicTax == 3)
					{
						double num2 = CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")));
						double num3 = CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2")));
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
				string cmdText2 = "SELECT tblMM_PO_Details.Qty, tblMM_PO_Details.Rate, tblMM_PO_Details.Discount,  tblVAT_Master.Value As VAT,tblExciseser_Master.Value AS Excise, tblPacking_Master.Value AS PF FROM tblMM_SPR_Details INNER JOIN tblMM_SPR_Master ON tblMM_SPR_Details.MId = tblMM_SPR_Master.Id INNER JOIN tblMM_PO_Details INNER JOIN tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id ON tblMM_SPR_Details.Id = tblMM_PO_Details.SPRId INNER JOIN tblVAT_Master ON tblMM_PO_Details.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_PO_Details.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_PO_Details.PF = tblPacking_Master.Id And tblMM_PO_Master.CompId='" + compid + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "'" + text3 + text2 + " ";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					if (BasicTax == 0)
					{
						num += CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")));
					}
					if (BasicTax == 1)
					{
						num += CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")));
					}
					if (BasicTax == 2)
					{
						double pf2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["PF"].ToString()).ToString("N3"));
						double exser2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["Excise"].ToString()).ToString("N3"));
						double vat2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["VAT"].ToString()).ToString("N3"));
						num += CalTaxAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")), pf2, exser2, vat2);
					}
					if (BasicTax == 3)
					{
						double num4 = CalBasicAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")));
						double num5 = CalDiscAmt(Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2")));
						num += num4 + num5;
					}
				}
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}

	public double GQNQTY_PO(int CompId, int PoId, int ItemId, int Flag)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = string.Empty;
			switch (Flag)
			{
			case 0:
				cmdText = "SELECT Sum(tblQc_MaterialQuality_Details.AcceptedQty)FROM tblQc_MaterialQuality_Details INNER JOIN               tblinv_MaterialReceived_Details ON tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id INNER JOIN                    tblMM_PO_Details ON tblinv_MaterialReceived_Details.POId = tblMM_PO_Details.Id INNER JOIN tblMM_PR_Details ON tblMM_PO_Details.PRId = tblMM_PR_Details.Id and tblMM_PR_Details.ItemId='" + ItemId + "' And tblinv_MaterialReceived_Details.POId='" + PoId + "'";
				break;
			case 1:
				cmdText = "SELECT  Sum(tblQc_MaterialQuality_Details.AcceptedQty)FROM tblQc_MaterialQuality_Details INNER JOIN                     tblinv_MaterialReceived_Details ON tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id INNER JOIN                     tblMM_PO_Details ON tblinv_MaterialReceived_Details.POId = tblMM_PO_Details.Id INNER JOIN tblMM_SPR_Details ON tblMM_PO_Details.SPRId = tblMM_SPR_Details.Id and tblMM_SPR_Details.ItemId='" + ItemId + "' And tblinv_MaterialReceived_Details.POId='" + PoId + "'";
				break;
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (sqlDataReader[0] != DBNull.Value)
				{
					result = Math.Round(Convert.ToDouble(sqlDataReader[0]), 3);
				}
			}
			sqlConnection.Close();
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double GQN_Reject_QTY_PO(int CompId, int PoId, int ItemId, int Flag)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = string.Empty;
			switch (Flag)
			{
			case 0:
				cmdText = "SELECT Sum(tblQc_MaterialQuality_Details.RejectedQty)FROM tblQc_MaterialQuality_Details INNER JOIN               tblinv_MaterialReceived_Details ON tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id INNER JOIN                    tblMM_PO_Details ON tblinv_MaterialReceived_Details.POId = tblMM_PO_Details.Id INNER JOIN tblMM_PR_Details ON tblMM_PO_Details.PRId = tblMM_PR_Details.Id and tblMM_PR_Details.ItemId='" + ItemId + "' And tblinv_MaterialReceived_Details.POId='" + PoId + "'";
				break;
			case 1:
				cmdText = "SELECT  Sum(tblQc_MaterialQuality_Details.RejectedQty)FROM tblQc_MaterialQuality_Details INNER JOIN                     tblinv_MaterialReceived_Details ON tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id INNER JOIN                     tblMM_PO_Details ON tblinv_MaterialReceived_Details.POId = tblMM_PO_Details.Id INNER JOIN tblMM_SPR_Details ON tblMM_PO_Details.SPRId = tblMM_SPR_Details.Id and tblMM_SPR_Details.ItemId='" + ItemId + "' And tblinv_MaterialReceived_Details.POId='" + PoId + "'";
				break;
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (sqlDataReader[0] != DBNull.Value)
				{
					result = Math.Round(Convert.ToDouble(sqlDataReader[0]), 3);
				}
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double GINQTY_PO(int CompId, int PoId, int ItemId, int Flag)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = string.Empty;
			switch (Flag)
			{
			case 0:
				cmdText = "SELECT sum(tblInv_Inward_Details.ReceivedQty) as sum_ReceivedQty FROM tblInv_Inward_Details INNER JOIN tblMM_PO_Details on tblMM_PO_Details.Id= tblInv_Inward_Details.POId inner join tblMM_PR_Details on  tblMM_PR_Details.Id = tblMM_PO_Details.PRId And tblMM_PR_Details.ItemId ='" + ItemId + "'And tblInv_Inward_Details.POId='" + PoId + "'";
				break;
			case 1:
				cmdText = "SELECT sum(tblInv_Inward_Details.ReceivedQty) as sum_ReceivedQty FROM tblInv_Inward_Details INNER JOIN tblMM_PO_Details on tblMM_PO_Details.Id= tblInv_Inward_Details.POId inner join tblMM_SPR_Details on  tblMM_SPR_Details.Id = tblMM_PO_Details.SPRId And tblMM_SPR_Details.ItemId ='" + ItemId + "' And tblInv_Inward_Details.POId='" + PoId + "'";
				break;
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				if (sqlDataReader[0] != DBNull.Value)
				{
					result = Math.Round(Convert.ToDouble(sqlDataReader[0]), 3);
				}
			}
			sqlConnection.Close();
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double GSN_QTY_PO(int CompId, int PoId, int ItemId, int Flag)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = string.Empty;
			switch (Flag)
			{
			case 0:
				cmdText = "SELECT GSNQty from view_Cal_Sum_GSN_PR where ItemId='" + ItemId + "'And CompId='" + CompId + "'And POId='" + PoId + "'";
				break;
			case 1:
				cmdText = "SELECT GSNQty from view_Cal_Sum_GSN_SPR where ItemId='" + ItemId + "'And CompId='" + CompId + "'And POId='" + PoId + "'";
				break;
			}
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public int WorkingDays(int FinYearId, int Mth)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("Days", "tblHR_WorkingDays", "MonthId='" + Mth + "' AND FinYearId='" + FinYearId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
		}
		return 0;
	}

	public int GetHoliday(int mth, int CompId, int FinYearId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("*", "tblHR_Holiday_Master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblHR_Holiday_Master");
		int num = 0;
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			string text = dataSet.Tables[0].Rows[i]["HDate"].ToString();
			string[] array = text.Split('-');
			int num2 = Convert.ToInt32(array[1]);
			if (num2 == mth)
			{
				num++;
			}
		}
		return num;
	}

	public double OTRate(double Gross, double OTHrs, double DutyHrs, double WorkDays)
	{
		double num = 0.0;
		return Gross / WorkDays / DutyHrs;
	}

	public double OTAmt(double OTRate, double TotalHrs)
	{
		return Math.Round(TotalHrs * OTRate);
	}

	public double MobileBillDetails(string EmpId, int FyId, int CompId, int Mth, int Case)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		string cmdText = select("*", "tblHR_OfficeStaff", "CompId='" + CompId + "' and EmpId='" + EmpId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		string cmdText2 = select("Id,MobileNo,LimitAmt", "tblHR_CoporateMobileNo", "Id='" + dataSet.Tables[0].Rows[0]["MobileNo"].ToString() + "'");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2, "tblHR_CoporateMobileNo");
		if (dataSet2.Tables[0].Rows.Count > 0)
		{
			num2 = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["LimitAmt"]);
			string cmdText3 = select("BillAmt,Taxes", "tblHR_MobileBill", "CompId='" + CompId + "' And FinYearId='" + FyId + "' And EmpId='" + EmpId + "' And BillMonth='" + Mth + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3, "tblHR_CoporateMobileNo");
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				num = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["BillAmt"]);
				string cmdText4 = select("*", "tblExciseser_Master", "Id='" + dataSet3.Tables[0].Rows[0]["Taxes"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				DataSet dataSet4 = new DataSet();
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				sqlDataAdapter4.Fill(dataSet4, "tblExciseser_Master");
				double num4 = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num4 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["Value"].ToString());
				}
				double num5 = num - num * num4 / (num4 + 100.0);
				if (num5 - num2 > 0.0)
				{
					num3 = Math.Round(num5 - num2);
				}
			}
		}
		double result = 0.0;
		switch (Case)
		{
		case 1:
			result = num;
			break;
		case 2:
			result = num2;
			break;
		case 3:
			result = num3;
			break;
		}
		return result;
	}

	public int CountSundays(int year, int month)
	{
		DateTime dateTime = new DateTime(year, month, 1);
		DateTime dateTime2 = dateTime.AddDays(28.0);
		DateTime dateTime3 = dateTime.AddDays(29.0);
		DateTime dateTime4 = dateTime.AddDays(30.0);
		if ((dateTime2.Month == month && dateTime2.DayOfWeek == DayOfWeek.Sunday) || (dateTime3.Month == month && dateTime3.DayOfWeek == DayOfWeek.Sunday) || (dateTime4.Month == month && dateTime4.DayOfWeek == DayOfWeek.Sunday))
		{
			return 5;
		}
		return 4;
	}

	public int SalYrs(int FinYearId, int Month, int CompId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		int num = 0;
		string cmdText = select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Financial");
		string text = dataSet.Tables[0].Rows[0]["FinYear"].ToString();
		string[] array = text.Split('-');
		string value = array[0];
		string value2 = array[1];
		if (Month == 1 || Month == 2 || Month == 3)
		{
			return Convert.ToInt32(value2);
		}
		return Convert.ToInt32(value);
	}

	public void GetMonth(DropDownList ddlMonth, int CompId, int FinYearId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Financial");
		List<string> list = new List<string>();
		list.Clear();
		list = MonthRange(dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString(), dataSet.Tables[0].Rows[0]["FinYearTo"].ToString());
		int num = 4;
		int num2 = 1;
		for (int i = 0; i < list.Count; i++)
		{
			if (i != 9 && i != 10 && i != 11)
			{
				ddlMonth.Items.Add(new ListItem(list[i], num.ToString()));
				num++;
			}
			else
			{
				ddlMonth.Items.Add(new ListItem(list[i], num2.ToString()));
				num2++;
			}
		}
	}

	public void CopyGunRailToWO(int node, string wonodest, int CompId, string SessionId, int FinYearId, int destpid, int destcid, double TCColumn, double TLongRow_with_coloumn, double TLongRow_no_coloumn, double SumLongRailColumn, double TCrossRow, double TLongRow)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("*", "tblDG_GUNRAIL_BOM_Master", " CId='" + node + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_GUNRAIL_BOM_Master");
			double num2 = 0.0;
			num2 = ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 1) ? Convert.ToDouble(decimal.Parse((TCColumn * 2.0).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 16) ? Convert.ToDouble(decimal.Parse((TCColumn * 2.0).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 21) ? Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 31) ? Convert.ToDouble(decimal.Parse(TLongRow_with_coloumn.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 35) ? Convert.ToDouble(decimal.Parse(TLongRow_no_coloumn.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 40) ? Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 46) ? Convert.ToDouble(decimal.Parse((TLongRow_with_coloumn + TLongRow_no_coloumn).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 55) ? Convert.ToDouble(decimal.Parse(((SumLongRailColumn + TCColumn) * 2.0).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 60) ? Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) != 74) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : Convert.ToDouble(decimal.Parse((TCrossRow + TLongRow).ToString()).ToString("N3"))))))))))));
			int bOMCId = getBOMCId(wonodest, CompId, FinYearId);
			string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "'," + CompId + "," + FinYearId + ",'" + SessionId.ToString() + "','" + destpid + "','" + bOMCId + "','" + wonodest + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "','" + num2 + "','" + dataSet.Tables[0].Rows[0]["EquipmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["UnitNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PartNo"].ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("*", "tblDG_GUNRAIL_BOM_Master", "PId=" + node);
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_GUNRAIL_BOM_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				double num3 = 0.0;
				if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 1)
				{
					num3 = Convert.ToDouble(decimal.Parse((TCColumn * 2.0).ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 16)
				{
					num3 = Convert.ToDouble(decimal.Parse((TCColumn * 2.0).ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 21)
				{
					num3 = Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 31)
				{
					num3 = Convert.ToDouble(decimal.Parse(TLongRow_with_coloumn.ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 35)
				{
					num3 = Convert.ToDouble(decimal.Parse(TLongRow_no_coloumn.ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 40)
				{
					num3 = Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 46)
				{
					num3 = Convert.ToDouble(decimal.Parse((TLongRow_with_coloumn + TLongRow_no_coloumn).ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 55)
				{
					num3 = Convert.ToDouble(decimal.Parse(((SumLongRailColumn + TCColumn) * 2.0).ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]) == 60)
				{
					num3 = Convert.ToDouble(decimal.Parse(TCColumn.ToString()).ToString("N3"));
				}
				else if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 74)
				{
					num2 = Convert.ToDouble(decimal.Parse((TCrossRow + TLongRow).ToString()).ToString("N3"));
				}
				else
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				}
				int bOMCId2 = getBOMCId(wonodest, CompId, FinYearId);
				string cmdText4 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SessionId.ToString() + "','" + bOMCId + "','" + bOMCId2 + "','" + wonodest + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]) + "','" + num3 + "','" + dataSet2.Tables[0].Rows[i]["EquipmentNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["UnitNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["PartNo"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText5 = select("*", "tblDG_GUNRAIL_BOM_Master", string.Concat("PId='", dataSet2.Tables[0].Rows[i]["CId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = bOMCId2;
						CopyGunRailToWO(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonodest, CompId, SessionId, FinYearId, num, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), TCColumn, TLongRow_with_coloumn, TLongRow_no_coloumn, SumLongRailColumn, TCrossRow, TLongRow);
					}
				}
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

	public void CopyGunRailToWO_Dispatch(int node, string wonodest, int CompId, string SessionId, int FinYearId, int destpid, int destcid, double TCColumn1, double TLongRow_with_coloumn1, double TLongRow_no_coloumn1, double SumLongRailColumn1, double TCrossRow, double TLongRow)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			sqlConnection.Open();
			string cmdText = select("*", "tblDG_GUNRAIL_BOM_Master", " CId='" + node + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_GUNRAIL_BOM_Master");
			double num = 0.0;
			num = ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 1) ? Convert.ToDouble(decimal.Parse((TCColumn1 * 2.0).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 21) ? Convert.ToDouble(decimal.Parse(TCColumn1.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 31) ? Convert.ToDouble(decimal.Parse(TLongRow_with_coloumn1.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 35) ? Convert.ToDouble(decimal.Parse(TLongRow_no_coloumn1.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 40) ? Convert.ToDouble(decimal.Parse(TCColumn1.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 55) ? Convert.ToDouble(decimal.Parse(((SumLongRailColumn1 + TCColumn1) * 2.0).ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) == 60) ? Convert.ToDouble(decimal.Parse(TCColumn1.ToString()).ToString("N3")) : ((Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) != 74) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : Convert.ToDouble(decimal.Parse((TCrossRow + TLongRow).ToString()).ToString("N3"))))))))));
			int bOMCId = getBOMCId(wonodest, CompId, FinYearId);
			string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "'," + CompId + "," + FinYearId + ",'" + SessionId.ToString() + "','" + destpid + "','" + bOMCId + "','" + wonodest + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "','" + num + "','" + dataSet.Tables[0].Rows[0]["EquipmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["UnitNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PartNo"].ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public double get(double len)
	{
		double num = Math.Truncate(len);
		double num2 = 0.0;
		if (len > num)
		{
			return num + 1.0;
		}
		return num;
	}

	public double ShortDateTime(string FD, string FT)
	{
		double result = 0.0;
		try
		{
			result = Convert.ToDateTime(FD + " " + FT).Ticks;
		}
		catch (Exception)
		{
		}
		return result;
	}

	public DateTime FirstDateInCurrMonth()
	{
		return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
	}

	public DateTime LastDateInCurrMonth()
	{
		DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		return dateTime.AddMonths(1).AddDays(-1.0);
	}

	public DataTable GetGroupedBy(DataTable dt, string columnNamesInDt, string groupByColumnNames, string typeOfCalculation)
	{
		if (columnNamesInDt == string.Empty || groupByColumnNames == string.Empty)
		{
			return dt;
		}
		DataTable dataTable = dt.DefaultView.ToTable(true, groupByColumnNames);
		string[] array = columnNamesInDt.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != groupByColumnNames)
			{
				dataTable.Columns.Add(array[i]);
			}
		}
		for (int j = 0; j < dataTable.Rows.Count; j++)
		{
			for (int k = 0; k < array.Length; k++)
			{
				if (array[k] != groupByColumnNames)
				{
					dataTable.Rows[j][k] = dt.Compute(typeOfCalculation + "(" + array[k] + ")", groupByColumnNames + " = '" + dataTable.Rows[j][groupByColumnNames].ToString() + "'");
				}
			}
		}
		return dataTable;
	}

	public int chkEmpCode(string code, int CompId)
	{
		string connectionString = Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			string selectCommandText = select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + code + "' ");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		}
		catch (Exception)
		{
		}
		if (code != "")
		{
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				return 1;
			}
			return 0;
		}
		return 0;
	}

	public double getCashEntryAmt(string CField, string Date, int CompId, int FyId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		string cmdText = select("sum(Amt) as sum_cash", "tblACC_CashAmt_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblACC_CashAmt_Master");
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		return Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2"));
	}

	public double getCashOpBalAmt(string CField, string Date, int CompId, int FyId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		num = getCashEntryAmt("<", getCurrDate(), CompId, FyId);
		double num2 = 0.0;
		string cmdText = select("sum(Amount) as sum_iou", "tblACC_IOU_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "' AND Authorize='1'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblACC_IOU_Master");
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		double num3 = 0.0;
		string cmdText2 = select("sum(tblACC_IOU_Receipt.RecievedAmount) as sum_iourec", "tblACC_IOU_Master,tblACC_IOU_Receipt", "tblACC_IOU_Master.CompId='" + CompId + "' AND tblACC_IOU_Receipt.FinYearId<='" + FyId + "' AND tblACC_IOU_Receipt.ReceiptDate" + CField + "'" + Date + "' AND tblACC_IOU_Master.Id=tblACC_IOU_Receipt.MId");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2);
		if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
		}
		double num4 = 0.0;
		string cmdText3 = select("sum(tblACC_CashVoucher_Payment_Details.Amount) as sum_cvpay", "tblACC_CashVoucher_Payment_Master,tblACC_CashVoucher_Payment_Details", "tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Payment_Master.Id=tblACC_CashVoucher_Payment_Details.MId AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Payment_Master.SysDate" + CField + "'" + Date + "' ");
		SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
		SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
		DataSet dataSet3 = new DataSet();
		sqlDataAdapter3.Fill(dataSet3);
		if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num4 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
		}
		double num5 = 0.0;
		string cmdText4 = select("sum(tblACC_CashVoucher_Receipt_Master.Amount) as sum_cvrec", "tblACC_CashVoucher_Receipt_Master", "tblACC_CashVoucher_Receipt_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Receipt_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Receipt_Master.SysDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
		SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
		DataSet dataSet4 = new DataSet();
		sqlDataAdapter4.Fill(dataSet4, "tblACC_CashVoucher_Receipt_Master");
		if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num5 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][0]);
		}
		double num6 = 0.0;
		string cmdText5 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Cr='4'");
		SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
		SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
		DataSet dataSet5 = new DataSet();
		sqlDataAdapter5.Fill(dataSet5, "tblACC_Contra_Entry");
		if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num6 = Convert.ToDouble(dataSet5.Tables[0].Rows[0][0]);
		}
		double num7 = 0.0;
		string cmdText6 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Dr='4'");
		SqlCommand selectCommand6 = new SqlCommand(cmdText6, connection);
		SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
		DataSet dataSet6 = new DataSet();
		sqlDataAdapter6.Fill(dataSet6, "tblACC_Contra_Entry");
		if (dataSet6.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num7 = Convert.ToDouble(dataSet6.Tables[0].Rows[0][0]);
		}
		double num8 = 0.0;
		string cmdText7 = "SELECT SUM(tblACC_TourAdvance_Details.Amount) as SUM_Amt FROM  tblACC_TourIntimation_Master INNER JOIN tblACC_TourAdvance_Details ON tblACC_TourIntimation_Master.Id = tblACC_TourAdvance_Details.MId AND tblACC_TourIntimation_Master.FinYearId<='" + FyId + "' AND tblACC_TourIntimation_Master.SysDate" + CField + "'" + Date + "' Group By tblACC_TourAdvance_Details.MId";
		SqlCommand selectCommand7 = new SqlCommand(cmdText7, connection);
		SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
		DataSet dataSet7 = new DataSet();
		sqlDataAdapter7.Fill(dataSet7);
		if (dataSet7.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num8 = Convert.ToDouble(dataSet7.Tables[0].Rows[0]["SUM_Amt"]);
		}
		double num9 = 0.0;
		string cmdText8 = "SELECT SUM(tblACC_TourAdvance.Amount) as SUM_Amt FROM  tblACC_TourIntimation_Master INNER JOIN tblACC_TourAdvance ON tblACC_TourIntimation_Master.Id = tblACC_TourAdvance.MId AND tblACC_TourIntimation_Master.FinYearId<='" + FyId + "' AND tblACC_TourIntimation_Master.SysDate" + CField + "'" + Date + "' Group By tblACC_TourAdvance.MId";
		SqlCommand selectCommand8 = new SqlCommand(cmdText8, connection);
		SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
		DataSet dataSet8 = new DataSet();
		sqlDataAdapter8.Fill(dataSet8);
		if (dataSet8.Tables[0].Rows.Count > 0 && dataSet8.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num9 = Convert.ToDouble(dataSet8.Tables[0].Rows[0]["SUM_Amt"]);
		}
		double num10 = 0.0;
		return Math.Round(Convert.ToDouble(decimal.Parse((num + num3 + num5 + num7 - (num6 + num2 + num4 + num8 + num9)).ToString()).ToString("N2")), 5);
	}

	public double getCashClBalAmt(string CField, string Date, int CompId, int FyId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		num = getCashOpBalAmt("<", Date, CompId, FyId);
		double num2 = 0.0;
		string cmdText = select("sum(Amount) as sum_iou", "tblACC_IOU_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "' AND Authorize='1'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblACC_IOU_Master");
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		double num3 = 0.0;
		string cmdText2 = select("sum(tblACC_IOU_Receipt.RecievedAmount) as sum_iourec", "tblACC_IOU_Master,tblACC_IOU_Receipt", "tblACC_IOU_Master.CompId='" + CompId + "' AND tblACC_IOU_Receipt.FinYearId<='" + FyId + "' AND tblACC_IOU_Receipt.ReceiptDate" + CField + "'" + Date + "' AND tblACC_IOU_Master.Id=tblACC_IOU_Receipt.MId");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2);
		if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
		}
		double num4 = 0.0;
		string cmdText3 = select("sum(tblACC_CashVoucher_Payment_Details.Amount) as sum_cvpay", "tblACC_CashVoucher_Payment_Master,tblACC_CashVoucher_Payment_Details", "tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Payment_Master.Id=tblACC_CashVoucher_Payment_Details.MId  AND tblACC_CashVoucher_Payment_Master.SysDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
		SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
		DataSet dataSet3 = new DataSet();
		sqlDataAdapter3.Fill(dataSet3);
		if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num4 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
		}
		double num5 = 0.0;
		string cmdText4 = select("sum(tblACC_CashVoucher_Receipt_Master.Amount) as sum_cvrec", "tblACC_CashVoucher_Receipt_Master", "tblACC_CashVoucher_Receipt_Master.CompId='" + CompId + "' AND tblACC_CashVoucher_Receipt_Master.FinYearId<='" + FyId + "' AND tblACC_CashVoucher_Receipt_Master.SysDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
		SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
		DataSet dataSet4 = new DataSet();
		sqlDataAdapter4.Fill(dataSet4, "tblACC_CashVoucher_Receipt_Master");
		if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num5 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][0]);
		}
		double num6 = 0.0;
		string cmdText5 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Cr='4'");
		SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
		SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
		DataSet dataSet5 = new DataSet();
		sqlDataAdapter5.Fill(dataSet5, "tblACC_Contra_Entry");
		if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num6 = Convert.ToDouble(dataSet5.Tables[0].Rows[0][0]);
		}
		double num7 = 0.0;
		string cmdText6 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Dr='4'");
		SqlCommand selectCommand6 = new SqlCommand(cmdText6, connection);
		SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
		DataSet dataSet6 = new DataSet();
		sqlDataAdapter6.Fill(dataSet6, "tblACC_Contra_Entry");
		if (dataSet6.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num7 = Convert.ToDouble(dataSet6.Tables[0].Rows[0][0]);
		}
		double num8 = 0.0;
		double num9 = 0.0;
		num9 = getCashEntryAmt("=", getCurrDate(), CompId, FyId);
		double num10 = 0.0;
		string cmdText7 = "SELECT SUM(tblACC_TourAdvance_Details.Amount) as SUM_Amt FROM  tblACC_TourIntimation_Master INNER JOIN tblACC_TourAdvance_Details ON tblACC_TourIntimation_Master.Id = tblACC_TourAdvance_Details.MId AND tblACC_TourIntimation_Master.FinYearId<='" + FyId + "' AND tblACC_TourIntimation_Master.SysDate" + CField + "'" + Date + "'  Group By tblACC_TourAdvance_Details.MId";
		SqlCommand selectCommand7 = new SqlCommand(cmdText7, connection);
		SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
		DataSet dataSet7 = new DataSet();
		sqlDataAdapter7.Fill(dataSet7);
		if (dataSet7.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num10 = Convert.ToDouble(dataSet7.Tables[0].Rows[0]["SUM_Amt"]);
		}
		double num11 = 0.0;
		string cmdText8 = "SELECT SUM(tblACC_TourAdvance.Amount) as SUM_Amt FROM  tblACC_TourIntimation_Master INNER JOIN tblACC_TourAdvance ON tblACC_TourIntimation_Master.Id = tblACC_TourAdvance.MId AND tblACC_TourIntimation_Master.FinYearId<='" + FyId + "' AND tblACC_TourIntimation_Master.SysDate" + CField + "'" + Date + "'  Group By tblACC_TourAdvance.MId";
		SqlCommand selectCommand8 = new SqlCommand(cmdText8, connection);
		SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
		DataSet dataSet8 = new DataSet();
		sqlDataAdapter8.Fill(dataSet8);
		if (dataSet8.Tables[0].Rows.Count > 0 && dataSet8.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num11 = Convert.ToDouble(dataSet8.Tables[0].Rows[0]["SUM_Amt"]);
		}
		return Math.Round(Convert.ToDouble(decimal.Parse((num + num3 + num5 + num7 + num9 - (num6 + num2 + num4 + num10 + num11)).ToString()).ToString("N2")), 5);
	}

	public double getBankEntryAmt(string CField, string Date, int CompId, int FyId, int BankId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double result = 0.0;
		string cmdText = select("sum(Amt) as sum_bank", "tblACC_BankAmt_Master", " BankId='" + BankId + "'And CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND SysDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblACC_BankAmt_Master");
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N2")), 5);
		}
		return result;
	}

	public double getBankOpBalAmt(string CField, string Date, int CompId, int FyId, int BankId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		num = getBankEntryAmt("<", getCurrDate(), CompId, FyId, BankId);
		double num2 = 0.0;
		string cmdText = select("sum(tblACC_BankVoucher_Payment_Details.Amount) as sum_bvpay", "tblACC_BankVoucher_Payment_Master,tblACC_BankVoucher_Payment_Details,tblACC_BankRecanciliation", "tblACC_BankVoucher_Payment_Master.Bank='" + BankId + "' And tblACC_BankVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Master.Id=tblACC_BankVoucher_Payment_Details.MId AND tblACC_BankVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_BankVoucher_Payment_Master.Id =tblACC_BankRecanciliation.BVPId  AND tblACC_BankRecanciliation.BankDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		double num3 = 0.0;
		string cmdText2 = select("sum(tblACC_BankVoucher_Received_Masters.Amount) as sum_cvrec", "tblACC_BankVoucher_Received_Masters", "tblACC_BankVoucher_Received_Masters.CompId='" + CompId + "'AND tblACC_BankVoucher_Received_Masters.DrawnAt='" + BankId + "' AND tblACC_BankVoucher_Received_Masters.FinYearId<='" + FyId + "' AND tblACC_BankVoucher_Received_Masters.ChequeClearanceDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2, "tblACC_BankVoucher_Received_Masters");
		if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
		}
		double num4 = 0.0;
		string cmdText3 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Cr!='4' And Cr='" + BankId + "'");
		SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
		SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
		DataSet dataSet3 = new DataSet();
		sqlDataAdapter3.Fill(dataSet3, "tblACC_Contra_Entry");
		if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num4 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
		}
		double num5 = 0.0;
		string cmdText4 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Dr!='4' And Dr='" + BankId + "'");
		SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
		SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
		DataSet dataSet4 = new DataSet();
		sqlDataAdapter4.Fill(dataSet4, "tblACC_Contra_Entry");
		if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num5 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][0]);
		}
		return Math.Round(Convert.ToDouble(decimal.Parse((num + num3 + num5 - (num2 + num4)).ToString()).ToString("N2")), 5);
	}

	public double getBankClBalAmt(string CField, string Date, int CompId, int FyId, int BankId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		double num = 0.0;
		num = getBankOpBalAmt("<", getCurrDate(), CompId, FyId, BankId);
		double num2 = 0.0;
		string cmdText = select("sum(tblACC_BankVoucher_Payment_Details.Amount) as sum_bvpay", "tblACC_BankVoucher_Payment_Master,tblACC_BankVoucher_Payment_Details,tblACC_BankRecanciliation", "tblACC_BankVoucher_Payment_Master.Bank='" + BankId + "' And tblACC_BankVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Master.Id=tblACC_BankVoucher_Payment_Details.MId AND tblACC_BankVoucher_Payment_Master.FinYearId<='" + FyId + "' AND tblACC_BankVoucher_Payment_Master.Id =tblACC_BankRecanciliation.BVPId AND tblACC_BankRecanciliation.BankDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		double num3 = 0.0;
		string cmdText2 = select("sum(tblACC_BankVoucher_Received_Masters.Amount) as sum_cvrec", "tblACC_BankVoucher_Received_Masters", "tblACC_BankVoucher_Received_Masters.CompId='" + CompId + "'AND tblACC_BankVoucher_Received_Masters.DrawnAt='" + BankId + "' AND tblACC_BankVoucher_Received_Masters.FinYearId<='" + FyId + "' AND tblACC_BankVoucher_Received_Masters.ChequeClearanceDate" + CField + "'" + Date + "'");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2, "tblACC_BankVoucher_Received_Masters");
		if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
		}
		double num4 = 0.0;
		string cmdText3 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Cr!='4' And Cr='" + BankId + "'");
		SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
		SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
		DataSet dataSet3 = new DataSet();
		sqlDataAdapter3.Fill(dataSet3, "tblACC_Contra_Entry");
		if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num4 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
		}
		double num5 = 0.0;
		string cmdText4 = select("sum(Amount) as sum_contra", "tblACC_Contra_Entry", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' AND Date" + CField + "'" + Date + "' AND Dr!='4'And Dr='" + BankId + "'");
		SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
		SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
		DataSet dataSet4 = new DataSet();
		sqlDataAdapter4.Fill(dataSet4, "tblACC_Contra_Entry");
		if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num5 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][0]);
		}
		double num6 = 0.0;
		num6 = getBankEntryAmt("=", getCurrDate(), CompId, FyId, BankId);
		return Math.Round(Convert.ToDouble(decimal.Parse((num + num3 + num5 + num6 - (num4 + num2)).ToString()).ToString("N2")), 5);
	}

	public double Offer_Cal(double gamt, int opt, int z, int typ)
	{
		double num = 0.0;
		double num2 = 0.0;
		num2 = Convert.ToDouble(decimal.Parse((gamt * 30.0 / 100.0).ToString()).ToString("N2"));
		double num3 = 0.0;
		num3 = Convert.ToDouble(decimal.Parse((gamt * 20.0 / 100.0).ToString()).ToString("N2"));
		Convert.ToDouble(decimal.Parse((num2 + num3).ToString()).ToString("N2"));
		switch (opt)
		{
		case 1:
			switch (z)
			{
			case 1:
				num = num2;
				break;
			case 2:
				num = num2 * 12.0;
				break;
			}
			break;
		case 2:
			switch (z)
			{
			case 1:
				num = num3;
				break;
			case 2:
				num = num3 * 12.0;
				break;
			}
			break;
		case 3:
			switch (z)
			{
			case 1:
				num = gamt * 20.0 / 100.0;
				break;
			case 2:
				num = gamt * 20.0 / 100.0 * 12.0;
				break;
			}
			break;
		case 4:
			switch (z)
			{
			case 1:
				num = gamt * 20.0 / 100.0;
				break;
			case 2:
				num = gamt * 20.0 / 100.0 * 12.0;
				break;
			}
			break;
		case 5:
			switch (z)
			{
			case 1:
				num = gamt * 5.0 / 100.0;
				break;
			case 2:
				num = gamt * 5.0 / 100.0 * 12.0;
				break;
			}
			break;
		case 6:
			switch (z)
			{
			case 1:
				num = gamt * 5.0 / 100.0;
				break;
			case 2:
				num = gamt * 5.0 / 100.0 * 12.0;
				break;
			}
			break;
		case 7:
			switch (typ)
			{
			case 1:
				num = gamt * 10.0 / 100.0;
				break;
			case 2:
				num = gamt * 5.0 / 100.0;
				break;
			}
			break;
		case 8:
			switch (typ)
			{
			case 1:
				num = gamt * 20.0 / 100.0;
				break;
			case 2:
				num = gamt * 15.0 / 100.0;
				break;
			}
			break;
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")), 5);
	}

	public double Pf_Cal(double gamt, int typ, double val)
	{
		double num = 0.0;
		switch (typ)
		{
		case 1:
			num = gamt * val / 100.0;
			break;
		case 2:
			num = gamt * val / 100.0;
			break;
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")));
	}

	public double PTax_Cal(double gamt, string mth)
	{
		double result = 0.0;
		if (gamt > 5000.0 && gamt <= 10000.0)
		{
			result = 175.0;
		}
		else if (gamt > 10000.0)
		{
			result = ((!(mth == "02")) ? 200.0 : 300.0);
		}
		return result;
	}

	public double Bonus_Cal(double gamt, int x)
	{
		double num = 0.0;
		num = ((!(gamt > 6000.0)) ? gamt : 6000.0);
		if (x == 1)
		{
			num /= 12.0;
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")), 5);
	}

	public double Gratuity_Cal(double gamt, int x, int emptyp)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		num2 = Offer_Cal(gamt, 1, 1, emptyp);
		num3 = Offer_Cal(gamt, 2, 1, emptyp);
		num = (num2 + num3) / 26.0 * 15.0;
		if (x == 1)
		{
			num /= 12.0;
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")), 5);
	}

	public double Offer_Emp_Cal(int offerId, int opt, int z, int typ)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double num = 0.0;
		try
		{
			string cmdText = select("salary", "tblHR_Offer_Master", "offerId='" + offerId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			double num2 = 0.0;
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0]["salary"].ToString());
			double num3 = 0.0;
			num3 = Convert.ToDouble(decimal.Parse((num2 * 30.0 / 100.0).ToString()).ToString("N2"));
			double num4 = 0.0;
			num4 = Convert.ToDouble(decimal.Parse((num2 * 20.0 / 100.0).ToString()).ToString("N2"));
			Convert.ToDouble(decimal.Parse((num3 + num4).ToString()).ToString("N2"));
			switch (opt)
			{
			case 1:
				switch (z)
				{
				case 1:
					num = num3;
					break;
				case 2:
					num = num3 * 12.0;
					break;
				}
				break;
			case 2:
				switch (z)
				{
				case 1:
					num = num4;
					break;
				case 2:
					num = num4 * 12.0;
					break;
				}
				break;
			case 3:
				switch (z)
				{
				case 1:
					num = num2 * 20.0 / 100.0;
					break;
				case 2:
					num = num2 * 20.0 / 100.0 * 12.0;
					break;
				}
				break;
			case 4:
				switch (z)
				{
				case 1:
					num = num2 * 20.0 / 100.0;
					break;
				case 2:
					num = num2 * 20.0 / 100.0 * 12.0;
					break;
				}
				break;
			case 5:
				switch (z)
				{
				case 1:
					num = num2 * 5.0 / 100.0;
					break;
				case 2:
					num = num2 * 5.0 / 100.0 * 12.0;
					break;
				}
				break;
			case 6:
				switch (z)
				{
				case 1:
					num = num2 * 5.0 / 100.0;
					break;
				case 2:
					num = num2 * 5.0 / 100.0 * 12.0;
					break;
				}
				break;
			case 7:
				switch (typ)
				{
				case 1:
					num = num2 * 10.0 / 100.0;
					break;
				case 2:
					num = num2 * 5.0 / 100.0;
					break;
				}
				break;
			case 8:
				switch (typ)
				{
				case 1:
					num = num2 * 20.0 / 100.0;
					break;
				case 2:
					num = num2 * 15.0 / 100.0;
					break;
				}
				break;
			}
			sqlConnection.Open();
		}
		catch (Exception)
		{
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")), 5);
	}

	public double Gratuity_Emp_Cal(int offerId, int x, int emptyp)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		try
		{
			num2 = Offer_Emp_Cal(offerId, 1, 1, emptyp);
			num3 = Offer_Emp_Cal(offerId, 2, 1, emptyp);
			num = (num2 + num3) / 26.0 * 15.0;
			if (x == 1)
			{
				num /= 12.0;
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N2")), 5);
	}

	public string ECSNames(int ct, string code, int CompId)
	{
		string connectionString = Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string result = "";
		switch (ct)
		{
		case 1:
		{
			string selectCommandText3 = select("EmployeeName AS EmployeeName ", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + code + "' ");
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection);
			sqlDataAdapter3.Fill(dataSet, "tblHR_OfficeStaff");
			result = dataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
			break;
		}
		case 2:
		{
			string selectCommandText2 = select("CustomerName AS CustomerName", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + code + "'");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			result = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
			break;
		}
		case 3:
		{
			string selectCommandText = select("SupplierName AS SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + code + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
			result = dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
			break;
		}
		}
		return result;
	}

	public string ECSAddress(int ct, string code, int CompId)
	{
		string connectionString = Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string result = "";
		switch (ct)
		{
		case 1:
		{
			string selectCommandText3 = select("PermanentAddress AS Adress ", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + code + "' ");
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection);
			sqlDataAdapter3.Fill(dataSet, "tblHR_OfficeStaff");
			result = dataSet.Tables[0].Rows[0]["Adress"].ToString();
			break;
		}
		case 2:
		{
			string selectCommandText2 = select("RegdAddress AS Adrerss", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + code + "'");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			result = dataSet.Tables[0].Rows[0]["Adrerss"].ToString();
			break;
		}
		case 3:
		{
			string selectCommandText = select("RegdAddress AS Adrerss", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + code + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
			result = dataSet.Tables[0].Rows[0]["Adrerss"].ToString();
			break;
		}
		}
		return result;
	}

	public string firstchar(string s)
	{
		return char.ToUpper(s[0]) + s.Substring(1);
	}

	public byte[] ImageToBinary(string imagePath)
	{
		FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, (int)fileStream.Length);
		fileStream.Close();
		return array;
	}

	public double CalWISQty(string compid, string wono, string itemid)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("sum(IssuedQty)As WisQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.Id=tblInv_WIS_Details.MId AND tblInv_WIS_Details.ItemId='" + itemid + "' And tblInv_WIS_Master.WONo='" + wono + "' And tblInv_WIS_Master.CompId='" + compid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["WisQty"] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["WisQty"].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string ExciseCommodity(int excomid)
	{
		DataSet dataSet = new DataSet();
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = select("ChapHead", "tblExciseCommodity_Master", "Id='" + excomid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblExciseCommodity_Master");
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		return dataSet.Tables[0].Rows[0]["ChapHead"].ToString();
	}

	public double CalPRQty(int compid, string wono, int itemid)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("sum(Qty)As PRQty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.ItemId='" + itemid + "' And tblMM_PR_Master.WONo='" + wono + "' And tblMM_PR_Master.CompId='" + compid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["PRQty"] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["PRQty"].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string WOmfgdate(string wono, int compid, int finid)
	{
		string result = "";
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("SD_Cust_WorkOrder_Master.ManufMaterialDate", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Master.WONo='" + wono + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finid + "'And SD_Cust_WorkOrder_Master.CompId='" + compid + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText, connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["ManufMaterialDate"] != DBNull.Value)
			{
				result = FromDateDMY(dataSet.Tables[0].Rows[0]["ManufMaterialDate"].ToString());
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double AllComponentBOMQty(int CompId, string wono, string itemid, int finId)
	{
		double num = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string cmdText = select("PId,CId", "tblDG_BOM_Master", "tblDG_BOM_Master.WONo='" + wono + "'and tblDG_BOM_Master.ItemId='" + Convert.ToInt32(itemid) + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + finId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num += BOMRecurQty(wono, Convert.ToInt32(sqlDataReader["PId"]), Convert.ToInt32(sqlDataReader["CId"]), 1.0, CompId, finId);
			}
			return Math.Round(num, 5);
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 5);
	}

	public double AllComponentBOMQty_WoNo_wise(int CompId, string wono, int finId)
	{
		double num = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string cmdText = select("PId,CId", "tblDG_BOM_Master", "tblDG_BOM_Master.WONo='" + wono + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + finId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num += BOMRecurQty(wono, Convert.ToInt32(sqlDataReader["PId"]), Convert.ToInt32(sqlDataReader["CId"]), 1.0, CompId, finId);
			}
			return Math.Round(num, 5);
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 5);
	}

	public double BOMRecurQty(string WONo, int Pid, int Cid, double p, int compid, int finid)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = select("Qty", "tblDG_BOM_Master", " WONo='" + WONo + "' AND PId='" + Pid + "'AND CId='" + Cid + "'And tblDG_BOM_Master.CompId='" + compid + "'AND tblDG_BOM_Master.FinYearId<='" + finid + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				p *= Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
			}
			if (Pid > 0)
			{
				string cmdText2 = select("PId,Qty", "tblDG_BOM_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'And tblDG_BOM_Master.CompId='" + compid + "'AND tblDG_BOM_Master.FinYearId<='" + finid + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2.HasRows)
				{
					p *= Convert.ToDouble(decimal.Parse(sqlDataReader2[1].ToString()).ToString("N3"));
				}
				int num = Convert.ToInt32(sqlDataReader2[0]);
				if (num > 0)
				{
					string cmdText3 = select("PId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND CId='" + num + "'And tblDG_BOM_Master.CompId='" + compid + "'AND tblDG_BOM_Master.FinYearId<='" + finid + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					if (sqlDataReader3.HasRows)
					{
						int pid = Convert.ToInt32(sqlDataReader3[0]);
						return Math.Round(BOMRecurQty(WONo, pid, num, p, compid, finid), 5);
					}
				}
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		return Math.Round(p, 5);
	}

	public void MP_Tree1(string wono, int CompId, RadGrid GridView2, int finid, string param)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("BOMQty", typeof(string));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PRQty", typeof(string));
			dataTable.Columns.Add("WISQty", typeof(string));
			dataTable.Columns.Add("GQNQty", typeof(string));
			string cmdText = select("Distinct ItemId", " tblDG_BOM_Master", "WONo='" + wono + "'and  CompId='" + CompId + "'And FinYearId<='" + finid + "' And ECNFlag=0 AND CId not in (Select PId from tblDG_BOM_Master where WONo='" + wono + "'and  CompId='" + CompId + "'And FinYearId<='" + finid + "')   ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", " tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'" + param);
				DataSet dataSet2 = new DataSet();
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = select("tblDG_Item_Master.Process,tblDG_Item_Master.ItemCode", " tblDG_Item_Master", " tblDG_Item_Master.PartNo='" + dataSet2.Tables[0].Rows[0]["PartNo"].ToString() + "' And CompId='" + CompId + "' " + param + " And tblDG_Item_Master.Process is not  null");
				DataSet dataSet3 = new DataSet();
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				string text = "";
				for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
				{
					text = text + "/" + dataSet3.Tables[0].Rows[j]["Process"].ToString();
				}
				if (dataSet2.Tables[0].Rows[0]["CId"] == DBNull.Value)
				{
					dataRow[0] = dataSet2.Tables[0].Rows[0]["PartNo"].ToString() + text;
				}
				else
				{
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
				}
				dataRow[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				dataRow[2] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
				string cmdText4 = select(" Sum(tblDG_BOM_Master.Qty) as UnitQty", "tblDG_BOM_Master", "tblDG_BOM_Master.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' and tblDG_BOM_Master.WONo='" + wono + "'and  tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + finid + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					dataRow[3] = num;
				}
				double num2 = AllComponentBOMQty(CompId, wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), finid);
				dataRow[4] = num2;
				dataRow[7] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				double num3 = 0.0;
				num3 = CalPRQty(CompId, wono, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]));
				dataRow[8] = num3.ToString();
				double num4 = 0.0;
				num4 = CalWISQty(CompId.ToString(), wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString());
				dataRow[9] = num4.ToString();
				double num5 = 0.0;
				num5 = GQNQTY(CompId, wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString());
				dataRow[10] = num5.ToString();
				string cmdText5 = select("tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.Id", "tblDG_Item_Master", "tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					if (dataSet5.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet5.Tables[0].Rows[0]["FileName"] != DBNull.Value)
					{
						dataRow[5] = "View";
					}
					else
					{
						dataRow[5] = "";
					}
					if (dataSet5.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet5.Tables[0].Rows[0]["AttName"] != DBNull.Value)
					{
						dataRow[6] = "View";
					}
					else
					{
						dataRow[6] = "";
					}
				}
				if (num2 - num3 - num4 + num5 > 0.0)
				{
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public string GetItemCode_PartNo(int compid, int itemid)
	{
		string result = "";
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("ItemCode,PartNo,CId,Process", "tblDG_Item_Master", "CompId='" + compid + "' AND Id='" + itemid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["CId"] != DBNull.Value)
				{
					result = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				}
				else if (dataSet.Tables[0].Rows[0]["Process"].ToString() != "0" && dataSet.Tables[0].Rows[0]["Process"] != DBNull.Value)
				{
					string cmdText2 = select("Symbol", "tblPln_Process_Master", "Id='" + dataSet.Tables[0].Rows[0]["Process"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						result = dataSet.Tables[0].Rows[0]["PartNo"].ToString() + dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				else
				{
					result = dataSet.Tables[0].Rows[0]["PartNo"].ToString();
				}
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double RMQty(string itemId, string wono, int CompId, string tblname)
	{
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "SELECT Sum(" + tblname + ".Qty) as Quantity FROM tblMP_Material_Master INNER JOIN tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN  " + tblname + " ON tblMP_Material_Detail.Id = " + tblname + ".DMid And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId='" + CompId + "' And tblMP_Material_Detail.ItemId='" + itemId + "'";
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0][0]), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double RMQty_Temp(string itemId, string tblname)
	{
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "SELECT Sum(" + tblname + ".Qty) as Quantity FROM tblMP_Material_Detail_Temp," + tblname + " where tblMP_Material_Detail_Temp.Id=" + tblname + ".DMid  And tblMP_Material_Detail_Temp.ItemId='" + itemId + "'";
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double RMQty_PR(string itemId, string wono, int CompId, string tblname)
	{
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "SELECT Sum(" + tblname + ".Qty) as Quantity FROM tblMM_PR_Master," + tblname + " where  tblMM_PR_Master.Id = tblMM_PR_Details.Mid And tblMM_PR_Master.WONo='" + wono + "' And tblMM_PR_Master.CompId='" + CompId + "' And tblMM_PR_Details.ItemId='" + itemId + "'";
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double RMQty_PR_Temp(string itemId, string sessionId, int CompId, string tblname)
	{
		double result = 0.0;
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "SELECT Sum(" + tblname + ".Qty) as Quantity FROM " + tblname + " where " + tblname + ".SessionId='" + sessionId + "' And " + tblname + ".CompId='" + CompId + "' And " + tblname + ".ItemId='" + itemId + "'";
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double GQNQTY(int CompId, string wono, string ItemId)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo=tblMM_PO_Details.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='0' And tblMM_PR_Master.CompId='" + CompId + "' And tblMM_PR_Master.WONo='" + wono + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public double GINQTY(int CompId, string wono, string ItemId)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("Sum(tblinv_MaterialReceived_Details.ReceivedQty)As Sum_GIN_Qty", "tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo=tblMM_PO_Details.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='0' And tblMM_PR_Master.CompId='" + CompId + "' And tblMM_PR_Master.WONo='" + wono + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public void TimeSelectorDatabase1(string TimeSelectorDatabase, TimeSelector TimeSelector1)
	{
		char[] separator = new char[2] { ':', ' ' };
		string[] array = TimeSelectorDatabase.Split(separator);
		string text = array[3];
		int hour = Convert.ToInt32(array[0]);
		int minute = Convert.ToInt32(array[1]) + 1;
		int second = Convert.ToInt32(array[2]);
		string text2 = text;
		if (text2 == "AM")
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.AM);
		}
		else
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.PM);
		}
	}

	public void TimeSelectorDatabase2(string TimeSelectorDatabase, TimeSelector TimeSelector1)
	{
		char[] separator = new char[2] { ':', ' ' };
		string[] array = TimeSelectorDatabase.Split(separator);
		string text = array[3];
		int hour = Convert.ToInt32(array[0]);
		int minute = Convert.ToInt32(array[1]) - 1;
		int second = Convert.ToInt32(array[2]);
		string text2 = text;
		if (text2 == "AM")
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.AM);
		}
		else
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.PM);
		}
	}

	public void TimeSelectorDatabase(string TimeSelectorDatabase, TimeSelector TimeSelector1)
	{
		char[] separator = new char[2] { ':', ' ' };
		string[] array = TimeSelectorDatabase.Split(separator);
		string text = array[3];
		int hour = Convert.ToInt32(array[0]);
		int minute = Convert.ToInt32(array[1]);
		int second = Convert.ToInt32(array[2]);
		string text2 = text;
		if (text2 == "AM")
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.AM);
		}
		else
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.PM);
		}
	}

	public void TimeSelectorDatabase3(string TimeSelectorDatabase, TimeSelector TimeSelector1)
	{
		char[] separator = new char[2] { ':', ' ' };
		string[] array = TimeSelectorDatabase.Split(separator);
		string text = array[3];
		int hour = Convert.ToInt32(array[0]) + 2;
		int minute = Convert.ToInt32(array[1]);
		int second = Convert.ToInt32(array[2]);
		string text2 = text;
		if (text2 == "AM")
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.AM);
		}
		else
		{
			TimeSelector1.SetTime(hour, minute, second, MKB.TimePicker.TimeSelector.AmPmSpec.PM);
		}
	}

	public bool NumberValidationQty(string strSp)
	{
		try
		{
			if (strSp.ToString() != "")
			{
				string pattern = "^\\d{1,15}(\\.\\d{0,3})?$";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(strSp))
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public bool CheckValidWONo(string WONo, int CompId, int FinYearId)
	{
		try
		{
			if (WONo.ToString() != "")
			{
				string connectionString = Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = select("WONo", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' And WONo='" + WONo + "' And FinYearId <='" + FinYearId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public DataSet RateRegister(int ItemId, int CompId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new RateRegSingleItem();
		sqlConnection.Open();
		try
		{
			string cmdText = select("*", "tblMM_Rate_Register", "CompId='" + CompId + "' AND ItemId='" + ItemId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet2 = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet2);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PackFwd", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Exst", typeof(string)));
			dataTable.Columns.Add(new DataColumn("IndirectCost", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DirectCost", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			DataSet dataSet3 = new DataSet();
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", string.Concat(" CompId='", CompId, "' AND Id='", dataSet2.Tables[0].Rows[i]["ItemId"], "'"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter2.Fill(dataSet4);
					dataRow[0] = dataSet4.Tables[0].Rows[0]["Id"];
					dataRow[1] = dataSet4.Tables[0].Rows[0]["ItemCode"];
					dataRow[2] = dataSet4.Tables[0].Rows[0]["ManfDesc"];
					string cmdText3 = select("Symbol", "Unit_Master", string.Concat("Id='", dataSet4.Tables[0].Rows[0]["UOMBasic"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter3.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet5.Tables[0].Rows[0]["Symbol"];
					}
					string cmdText4 = select("FinYear", "tblFinancial_master", string.Concat("CompId='", CompId, "' AND FinYearId='", dataSet2.Tables[0].Rows[i]["FinYearId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter4.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet6.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[5] = dataSet2.Tables[0].Rows[i]["PONo"];
					dataRow[6] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Rate"]);
					dataRow[7] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Discount"]);
					string cmdText5 = select("Terms", "tblPacking_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[i]["PF"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter5.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[8] = dataSet7.Tables[0].Rows[0]["Terms"];
					}
					string cmdText6 = select("Terms", "tblExciseser_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[i]["ExST"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter6.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet8.Tables[0].Rows[0]["Terms"];
					}
					string cmdText7 = select("Terms", "tblVAT_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[i]["VAT"], "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter7.Fill(dataSet9);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = dataSet9.Tables[0].Rows[0]["Terms"];
					}
					dataRow[11] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["IndirectCost"]);
					dataRow[12] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["DirectCost"]);
					dataRow[13] = CompId;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet3.Tables.Add(dataTable);
				dataSet3.AcceptChanges();
				dataSet.Tables[0].Merge(dataSet3.Tables[0]);
				dataSet.AcceptChanges();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return dataSet;
	}

	public void TimeSelector(int H, int M, int S, string TM, TimeSelector TimeSelector1)
	{
		if (TM == "AM")
		{
			TimeSelector1.SetTime(H, M, S, MKB.TimePicker.TimeSelector.AmPmSpec.AM);
		}
		else
		{
			TimeSelector1.SetTime(H, M, S, MKB.TimePicker.TimeSelector.AmPmSpec.PM);
		}
	}

	public double CalMINQty(string compid, string wono, string itemid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("sum(IssueQty)As MinQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialIssue_Details.MINNo=tblInv_MaterialIssue_Master.MINNo And tblInv_MaterialRequisition_Details.MRSNo=tblInv_MaterialRequisition_Master.MRSNo and tblInv_MaterialRequisition_Details.ItemId='" + itemid + "' And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialIssue_Master.MRSNo =tblInv_MaterialRequisition_Details.MRSNo And tblInv_MaterialRequisition_Details.WONo='" + wono + "' And tblInv_MaterialIssue_Master.CompId='" + compid + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public string FromDateMDY(string FD)
	{
		string result = "";
		try
		{
			string[] array = FD.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			result = text2 + "-" + text + "-" + text3;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string DateToText(DateTime dt, bool includeTime, bool isUK)
	{
		string[] array = new string[31]
		{
			"First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth",
			"Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth", "Sixteenth", "Seventeenth", "Eighteenth", "Nineteenth", "Twentieth",
			"Twenty First", "Twenty Second", "Twenty Third", "Twenty Fourth", "Twenty Fifth", "Twenty Sixth", "Twenty Seventh", "Twenty Eighth", "Twenty Ninth", "Thirtieth",
			"Thirty First"
		};
		int day = dt.Day;
		int month = dt.Month;
		int year = dt.Year;
		DateTime dateTime = new DateTime(1, month, 1);
		string text = ((!isUK) ? (array[day - 1] + " " + dateTime.ToString("MMMM") + " " + NumberToText(year, isUK: false)) : ("The " + array[day - 1] + " of " + dateTime.ToString("MMMM") + " " + NumberToText(year, isUK: true)));
		if (includeTime)
		{
			int num = dt.Hour;
			int minute = dt.Minute;
			string text2 = "AM";
			if (num >= 12)
			{
				text2 = "PM";
				num -= 12;
			}
			if (num == 0)
			{
				num = 12;
			}
			string text3 = NumberToText(num, isUK: false);
			if (minute > 0)
			{
				text3 = text3 + " " + NumberToText(minute, isUK: false);
			}
			text3 = text3 + " " + text2;
			text = text + ", " + text3;
		}
		return text;
	}

	public string TimeToText(string TimeSel)
	{
		string text = "";
		try
		{
			char[] separator = new char[2] { ':', ' ' };
			string[] array = TimeSel.Split(separator);
			_ = array[3];
			int num = Convert.ToInt32(array[0]);
			int num2 = Convert.ToInt32(array[1]);
			string text2 = array[3].ToString();
			int number = num;
			int num3 = num2;
			text = NumberToText(number, isUK: false);
			if (num3 > 0)
			{
				text = text + " " + NumberToText(num3, isUK: false);
			}
			text = text + " " + text2;
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public static string NumberToText(int number, bool isUK)
	{
		if (number == 0)
		{
			return "Zero";
		}
		string text = (isUK ? "and " : "");
		if (number == int.MinValue)
		{
			return "Minus Two Billion One Hundred " + text + "Forty Seven Million Four Hundred " + text + "Eighty Three Thousand Six Hundred " + text + "Forty Eight";
		}
		int[] array = new int[4];
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (number < 0)
		{
			stringBuilder.Append("Minus ");
			number = -number;
		}
		string[] array2 = new string[10] { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
		string[] array3 = new string[10] { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
		string[] array4 = new string[8] { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
		string[] array5 = new string[3] { "Thousand ", "Million ", "Billion " };
		array[0] = number % 1000;
		array[1] = number / 1000;
		array[2] = number / 1000000;
		array[1] -= 1000 * array[2];
		array[3] = number / 1000000000;
		array[2] -= 1000 * array[3];
		for (int num2 = 3; num2 > 0; num2--)
		{
			if (array[num2] != 0)
			{
				num = num2;
				break;
			}
		}
		for (int num3 = num; num3 >= 0; num3--)
		{
			if (array[num3] != 0)
			{
				int num4 = array[num3] % 10;
				int num5 = array[num3] / 10;
				int num6 = array[num3] / 100;
				num5 -= 10 * num6;
				if (num6 > 0)
				{
					stringBuilder.Append(array2[num6] + "Hundred ");
				}
				if (num4 > 0 || num5 > 0)
				{
					if (num6 > 0 || num3 < num)
					{
						stringBuilder.Append(text);
					}
					switch (num5)
					{
					case 0:
						stringBuilder.Append(array2[num4]);
						break;
					case 1:
						stringBuilder.Append(array3[num4]);
						break;
					default:
						stringBuilder.Append(array4[num5 - 2] + array2[num4]);
						break;
					}
				}
				if (num3 != 0)
				{
					stringBuilder.Append(array5[num3 - 1]);
				}
			}
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public double GSN_SPRQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("Sum(tblinv_MaterialServiceNote_Details.ReceivedQty)As Sum_GSN_Qty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master   ", " tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.Id=tblMM_PO_Details.MId  And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo And tblMM_SPR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='1' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "'And tblinv_MaterialServiceNote_Master.SysDate between '" + FromDate(FrmDate) + "' And '" + FromDate(TDate) + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public double GSN_PRQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("Sum(tblinv_MaterialServiceNote_Details.ReceivedQty)As Sum_GSN_Qty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PO_Details.PRNo=tblMM_PR_Master.PRNo And  tblMM_PR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='0' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' And tblinv_MaterialServiceNote_Master.SysDate between '" + FromDate(FrmDate) + "' And '" + FromDate(TDate) + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public double GQN_SPRQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		double result = 0.0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master", " tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And  tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId  And tblMM_PO_Master.Id=tblMM_PO_Details.MId  And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo And tblMM_SPR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='1' And tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.SysDate between '" + FromDate(FrmDate) + "' And '" + FromDate(TDate) + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public double GQN_PRQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", " tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo=tblMM_PO_Details.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId='" + ItemId + "' And tblMM_PO_Master.PRSPRFlag='0' And tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.SysDate between '" + FromDate(FrmDate) + "' And '" + FromDate(TDate) + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public double MRQN_QTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_MRQNQty", "tblInv_MaterialReturn_Master,tblInv_MaterialReturn_Details,tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", " tblQc_MaterialReturnQuality_Master.Id= tblQc_MaterialReturnQuality_Details.MId  AND  tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId  AND tblInv_MaterialReturn_Master.Id=tblQc_MaterialReturnQuality_Master.MRNId AND tblInv_MaterialReturn_Master.MRNNo=tblQc_MaterialReturnQuality_Master.MRNNo AND tblInv_MaterialReturn_Details.Id=tblQc_MaterialReturnQuality_Details.MRNId AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id AND tblInv_MaterialReturn_Details.ItemId='" + ItemId + "' AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.SysDate between '" + FromDate(FrmDate) + "' AND '" + FromDate(TDate) + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public double MCNQA_QTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = "SELECT sum(tblQc_AuthorizedMCN.QAQty) as sum_MCNQA_QTY FROM tblPM_MaterialCreditNote_Details INNER JOIN tblPM_MaterialCreditNote_Master ON tblPM_MaterialCreditNote_Details.MId = tblPM_MaterialCreditNote_Master.Id INNER JOIN tblQc_AuthorizedMCN ON tblPM_MaterialCreditNote_Details.Id = tblQc_AuthorizedMCN.MCNDId AND  tblPM_MaterialCreditNote_Details.MId = tblQc_AuthorizedMCN.MCNId INNER JOIN  tblDG_BOM_Master ON tblPM_MaterialCreditNote_Master.WONo = tblDG_BOM_Master.WONo AND tblPM_MaterialCreditNote_Details.PId = tblDG_BOM_Master.PId AND tblPM_MaterialCreditNote_Details.CId = tblDG_BOM_Master.CId AND tblQc_AuthorizedMCN.CompId='" + CompId + "' AND tblQc_AuthorizedMCN.SysDate  between '" + FromDate(FrmDate) + "' And '" + FromDate(TDate) + "' AND tblDG_BOM_Master.ItemId='" + ItemId + "'";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public double MIN_IssuQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("sum(tblInv_MaterialIssue_Details.IssueQty) as sum_IssuQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialIssue_Master.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId AND tblInv_MaterialRequisition_Details.Id= tblInv_MaterialIssue_Details.MRSId AND tblInv_MaterialRequisition_Details.ItemId='" + ItemId + "' AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.SysDate between '" + FromDate(FrmDate) + "' AND '" + FromDate(TDate) + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public double WIS_IssuQTY(int CompId, string FrmDate, string TDate, string ItemId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("sum(IssuedQty)As WisQty", "tblInv_WIS_Master,tblInv_WIS_Details", " tblInv_WIS_Details.ItemId='" + ItemId + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Master.SysDate between '" + FromDate(FrmDate) + "' AND '" + FromDate(TDate) + "' AND tblInv_WIS_Master.Id=tblInv_WIS_Details.MId ");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double result = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3")), 5);
		}
		return result;
	}

	public int ItemCodeLimit(int CompId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("ItemCodeLimit", "tblCompany_master", "CompId='" + CompId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		int result = 0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			result = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
		}
		return result;
	}

	public string Encrypt(string val)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(val);
		byte[] inArray = ProtectedData.Protect(bytes, new byte[0], DataProtectionScope.LocalMachine);
		return Convert.ToBase64String(inArray);
	}

	public string Decrypt(string val)
	{
		byte[] encryptedData = Convert.FromBase64String(val);
		byte[] bytes = ProtectedData.Unprotect(encryptedData, new byte[0], DataProtectionScope.LocalMachine);
		return Encoding.UTF8.GetString(bytes);
	}

	public bool EmailValidation(string strEmail)
	{
		try
		{
			if (strEmail.ToString() != "")
			{
				string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(strEmail))
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public bool DateValidation(string strDate)
	{
		try
		{
			if (strDate.ToString() != "")
			{
				string pattern = "^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(strDate))
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public bool SpecialCarValidation(string strSp)
	{
		try
		{
			if (strSp.ToString() != "")
			{
				string pattern = "^[0-9a-zA-Z]*[-._()]*[#&%@*=+;:<>?]+$";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(strSp))
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public bool NumberValidation(string strSp)
	{
		try
		{
			if (strSp.ToString() != "")
			{
				string pattern = "^[0-9]\\d*(\\.\\d+)?$";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(strSp))
				{
					return true;
				}
				return false;
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public string Connection()
	{
		ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LocalSqlServer"];
		return connectionStringSettings.ConnectionString;
	}

	public string select(string field, string tbl, string whr)
	{
		return "select " + field + " from " + tbl + " where " + whr;
	}

	public string select1(string field, string tbl)
	{
		return "select " + field + " from " + tbl;
	}

	public string insert(string tbl, string field, string value)
	{
		return "insert into " + tbl + " (" + field + ") Values (" + value + ")";
	}

	public string update(string tbl, string fieldval, string whr)
	{
		return "update " + tbl + " set " + fieldval + " Where " + whr;
	}

	public string delete(string tbl, string whr)
	{
		return "delete from " + tbl + " where " + whr;
	}

	public void dropdownCompany(DropDownList dpdlCompany)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("SUBSTRING(CompanyName,0,27)+'....' as CompName,CompId ", "tblCompany_master");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "company");
			dpdlCompany.DataSource = dataSet.Tables["company"];
			dpdlCompany.DataTextField = "CompName";
			dpdlCompany.DataValueField = "CompId";
			dpdlCompany.DataBind();
			dpdlCompany.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCategory(DropDownList dpdlCategory)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("*", "Category_master");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "category");
			dpdlCategory.DataSource = dataSet.Tables["category"];
			dpdlCategory.DataTextField = "Name";
			dpdlCategory.DataValueField = "Id";
			dpdlCategory.DataBind();
			dpdlCategory.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCategoryBYId(DropDownList dpdlCategory, string whr)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("*", "Category_master", whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "category");
			dpdlCategory.DataSource = dataSet.Tables["category"];
			dpdlCategory.DataTextField = "Name";
			dpdlCategory.DataValueField = "Id";
			dpdlCategory.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void dropdownBG(DropDownList dpdlBG)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("Symbol As name,Id ", "BusinessGroup");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Business");
			dpdlBG.DataSource = dataSet.Tables["Business"];
			dpdlBG.DataTextField = "name";
			dpdlBG.DataValueField = "Id";
			dpdlBG.DataBind();
			dpdlBG.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void dropdownBuyer(DropDownList DDLBuyer)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("tblMM_Buyer_Master.Id,tblMM_Buyer_Master.Category+Convert(Varchar,tblMM_Buyer_Master.Nos)+'-'+tblHR_OfficeStaff.EmployeeName+' ['+tblMM_Buyer_Master.EmpId+' ]' As Buyer", "tblMM_Buyer_Master,tblHR_OfficeStaff", "tblMM_Buyer_Master.EmpId=tblHR_OfficeStaff.EmpId AND tblMM_Buyer_Master.Id!=0 ");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblMM_Buyer_Master");
			DDLBuyer.DataSource = dataSet.Tables["tblMM_Buyer_Master"];
			DDLBuyer.DataTextField = "Buyer";
			DDLBuyer.DataValueField = "Id";
			DDLBuyer.DataBind();
			DDLBuyer.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void dropdownBGId(DropDownList dpdlBG, string whr)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select("Symbol As name,Id ", "BusinessGroup", whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Business");
			dpdlBG.DataSource = dataSet.Tables["Business"];
			dpdlBG.DataTextField = "name";
			dpdlBG.DataValueField = "Id";
			dpdlBG.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void dropdownUnit(DropDownList dpdlunit)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("Symbol,Id", "Unit_Master");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "unit");
			dpdlunit.DataSource = dataSet.Tables["unit"];
			dpdlunit.DataTextField = "Symbol";
			dpdlunit.DataValueField = "Id";
			dpdlunit.DataBind();
			dpdlunit.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void dropdownFinYear(DropDownList dpdlFinYear, DropDownList dpdlFinCompId)
	{
		try
		{
			if (dpdlFinCompId.SelectedValue.ToString() != "Select")
			{
				DataSet dataSet = new DataSet();
				string connectionString = Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = select("*", "tblFinancial_master", "CompId='" + dpdlFinCompId.SelectedValue + "'order by FinYearId Desc ");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				dpdlFinYear.DataSource = dataSet.Tables[0];
				dpdlFinYear.DataTextField = "FinYear";
				dpdlFinYear.DataValueField = "FinYearId";
				dpdlFinYear.DataBind();
				dpdlFinYear.Items.Insert(0, "Select");
			}
			else
			{
				dpdlFinYear.Items.Clear();
				dpdlFinYear.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	public string getCurrDate()
	{
		return DateTime.Now.ToString("yyyy-MM-dd");
	}

	public string getCurrTime()
	{
		return DateTime.Now.ToString("T");
	}

	public string FromDate(string FD)
	{
		string result = "";
		try
		{
			string[] array = FD.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			result = text3 + "-" + text2 + "-" + text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string ToDate(string TD)
	{
		string result = "";
		try
		{
			string[] array = TD.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			result = text3 + "-" + text2 + "-" + text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string FromDateDMY(string FD)
	{
		string result = "";
		try
		{
			string[] array = FD.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			result = text3 + "-" + text2 + "-" + text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string ToDateDMY(string TD)
	{
		string result = "";
		try
		{
			string[] array = TD.Split('-');
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			result = text3 + "-" + text2 + "-" + text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string FromDateYear(string FDY)
	{
		string result = "";
		try
		{
			string[] array = FDY.Split('-');
			string text = array[0];
			_ = array[1];
			_ = array[2];
			result = text + "-";
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string ToDateYear(string TDY)
	{
		string result = "";
		try
		{
			string[] array = TDY.Split('-');
			string text = array[0];
			_ = array[1];
			_ = array[2];
			result = text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string fYear(string fyear)
	{
		string result = "";
		try
		{
			string[] array = fyear.Split('-');
			_ = array[0];
			_ = array[1];
			string text = array[2];
			result = text + "-";
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public string tYear(string tyear)
	{
		string result = "";
		try
		{
			string[] array = tyear.Split('-');
			_ = array[0];
			_ = array[1];
			string text = array[2];
			result = text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public void dropdownCountry(DropDownList dpdlCountry, DropDownList dpdlState)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select1("*", "tblcountry");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblcountry");
			dpdlCountry.DataSource = dataSet.Tables["tblcountry"];
			dpdlCountry.DataTextField = "CountryName";
			dpdlCountry.DataValueField = "CId";
			dpdlCountry.DataBind();
			dpdlCountry.Items.Insert(0, "Select");
			dpdlState.ClearSelection();
		}
		catch (Exception)
		{
		}
	}

	public string getCity(int cityid, int field)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = select("*", "tblCity", "CityId='" + cityid + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblCity");
		return dataSet.Tables[0].Rows[0][field].ToString();
	}

	public string getState(int stateid, int field)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = select("*", "tblState", "SId='" + stateid + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblState");
		return dataSet.Tables[0].Rows[0][field].ToString();
	}

	public string getCountry(int cntid, int field)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = select("*", "tblCountry", "CId='" + cntid + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblCountry");
		return dataSet.Tables[0].Rows[0][field].ToString();
	}

	public void dropdownCountrybyId(DropDownList dpdlCountry, DropDownList dpdlState, string whr)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("* ", "tblcountry", whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblcountry");
			dpdlCountry.DataSource = dataSet.Tables["tblcountry"];
			dpdlCountry.DataTextField = "CountryName";
			dpdlCountry.DataValueField = "CId";
			dpdlCountry.DataBind();
			dpdlCountry.Items.Insert(0, "Select");
			dpdlState.ClearSelection();
		}
		catch (Exception)
		{
		}
	}

	public void dropdownState(DropDownList dpdlState, DropDownList dpdlCity, DropDownList dpdlCountry)
	{
		try
		{
			if (dpdlCountry.SelectedValue.ToString() != "Select")
			{
				string connectionString = Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DataSet dataSet = new DataSet();
				string cmdText = select("SUBSTRING(StateName,0,15)+'....' as StateName,SId", "tblState", "CId='" + dpdlCountry.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblstate");
				dpdlState.DataSource = dataSet.Tables["tblState"];
				dpdlState.DataTextField = "StateName";
				dpdlState.DataValueField = "SId";
				dpdlState.DataBind();
				dpdlState.Items.Insert(0, "Select");
				dpdlCity.ClearSelection();
			}
			else
			{
				dpdlState.Items.Clear();
				dpdlState.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	public void dropdownStatebyId(DropDownList dpdlState, string whr)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("*", "tblState", whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblstate");
			ListItem listItem = new ListItem();
			listItem.Text = dataSet.Tables[0].Rows[0]["StateName"].ToString();
			listItem.Value = dataSet.Tables[0].Rows[0]["SId"].ToString();
			dpdlState.Items.Add(listItem);
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCity(DropDownList dpdlCity, DropDownList dpdlState)
	{
		try
		{
			if (dpdlState.SelectedValue.ToString() != "Select")
			{
				string connectionString = Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DataSet dataSet = new DataSet();
				string cmdText = select("SUBSTRING(CityName,0,15)+'....' as CityName,CityId ", "tblCity", "SId='" + dpdlState.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblCity");
				dpdlCity.DataSource = dataSet.Tables["tblCity"];
				dpdlCity.DataTextField = "CityName";
				dpdlCity.DataValueField = "CityId";
				dpdlCity.DataBind();
				dpdlCity.Items.Insert(0, "Select");
			}
			else
			{
				dpdlCity.Items.Clear();
				dpdlCity.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCitybyId(DropDownList dpdlCity, string whr)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("*", "tblCity", whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblCity");
			ListItem listItem = new ListItem();
			listItem.Text = dataSet.Tables[0].Rows[0]["CityName"].ToString();
			listItem.Value = dataSet.Tables[0].Rows[0]["CityId"].ToString();
			dpdlCity.Items.Add(listItem);
		}
		catch (Exception)
		{
		}
	}

	public string link(string pagename, string LinkName)
	{
		return "<a href='" + pagename + "' style=color:#FFFFFF>" + LinkName + "</a>";
	}

	public int[] AcessMaster(int CompId, int FinYearId, string EmpId, int ModId, int SubModID)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = select("*", "tblAccess_Master", "CompId=" + CompId + "and FinYearId=" + FinYearId + "and EmpId='" + EmpId.ToString() + "'and ModId=" + ModId + "and SubModId=" + SubModID);
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblAccess_Master");
		int[] array = new int[dataSet.Tables[0].Rows.Count];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			array[i] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Access"]);
		}
		return array;
	}

	public string getCustChar(string a)
	{
		string text = a.Trim();
		return text.Substring(0, 1);
	}

	public string getCode(string code)
	{
		string[] array = new string[0];
		try
		{
			string[] array2 = code.Split('[');
			array = array2[1].Split(']');
			return array[0];
		}
		catch (Exception)
		{
		}
		return "";
	}

	public string getWOChar(string a)
	{
		string text = a.Trim();
		return text.Substring(0, 1);
	}

	public string getWO(string a)
	{
		string text = a.Trim();
		return text.Substring(2);
	}

	public string SPRNoCodeFY(string SPRNC)
	{
		string text = "Z";
		string text2 = SPRNC.Trim();
		string text3 = text2.Substring(2, 2);
		return text + text3;
	}

	public void BindDataCust1(string tblName, string tblfield, string whr, GridView SearchGridView, string drpvalue, string hfSearchTextValue)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			if (hfSearchTextValue != "")
			{
				dataSet.Clear();
				string text2 = text;
				text = text2 + " AND " + drpvalue + " like '" + hfSearchTextValue + "%'";
				SqlCommand selectCommand2 = new SqlCommand(text, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet, tblName);
			}
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
			SearchGridView.PageIndex = 0;
			SearchGridView.DataBind();
		}
		finally
		{
			if (SearchGridView.Rows.Count > 0)
			{
				SearchGridView.SelectedIndex = 0;
			}
		}
	}

	public void BindDataCust(string tblName, string tblfield, string whr, GridView SearchGridView, string drpvalue, string hfSearchTextValue)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			if (hfSearchTextValue != "")
			{
				dataSet.Clear();
				string text2 = text;
				text = text2 + " AND " + drpvalue + " like '" + hfSearchTextValue + "%'";
				SqlCommand selectCommand2 = new SqlCommand(text, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet, tblName);
			}
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public string revDate(string fld, string binname)
	{
		return "REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(" + fld + ", CHARINDEX('-', " + fld + ") + 1, 2) + '-' + LEFT(" + fld + ",CHARINDEX('-', " + fld + ") - 1) + '-' + RIGHT(" + fld + ", CHARINDEX('-', REVERSE(" + fld + ")) - 1)), 103), '/', '-')AS " + binname;
	}

	public string TranNo(string tblname, string fieldname, int compid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = select(fieldname, tblname, "CompId=" + compid + " Order by " + fieldname + " Desc");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return (Convert.ToInt32(dataSet.Tables[0].Rows[0][0]) + 1).ToString("D4");
		}
		return "0001";
	}

	public string CompAdd(int cid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string result = "";
		try
		{
			sqlConnection.Open();
			string cmdText = select("*", "tblCompany_master", "CompId='" + cid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblCompany_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0].Rows[0]["RegdAddress"].ToString() + " " + getCity(Convert.ToInt32(dataSet.Tables[0].Rows[0]["RegdCity"]), 1) + " " + getState(Convert.ToInt32(dataSet.Tables[0].Rows[0]["RegdState"]), 1) + " " + getCountry(Convert.ToInt32(dataSet.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dataSet.Tables[0].Rows[0]["RegdPinCode"].ToString() + " Ph No.-" + dataSet.Tables[0].Rows[0]["RegdContactNo"].ToString() + " Fax No.-" + dataSet.Tables[0].Rows[0]["RegdFaxNo"].ToString() + " Email No.-" + dataSet.Tables[0].Rows[0]["RegdEmail"].ToString();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public string CompPlantAdd(int cid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string result = "";
		try
		{
			sqlConnection.Open();
			string cmdText = select("*", "tblCompany_master", "CompId='" + cid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblCompany_master");
			result = dataSet.Tables[0].Rows[0]["PlantAddress"].ToString() + " " + getCity(Convert.ToInt32(dataSet.Tables[0].Rows[0]["PlantCity"]), 1) + " " + getState(Convert.ToInt32(dataSet.Tables[0].Rows[0]["PlantState"]), 1) + " " + getCountry(Convert.ToInt32(dataSet.Tables[0].Rows[0]["PlantCountry"]), 1) + " PIN No.-" + dataSet.Tables[0].Rows[0]["PlantPinCode"].ToString() + " Ph No.-" + dataSet.Tables[0].Rows[0]["PlantContactNo"].ToString() + " Fax No.-" + dataSet.Tables[0].Rows[0]["PlantFaxNo"].ToString() + " Email No.-" + dataSet.Tables[0].Rows[0]["PlantEmail"].ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public string getProjectTitle(string wono)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string result = "";
		try
		{
			sqlConnection.Open();
			string cmdText = select("TaskProjectTitle", "SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Master");
			result = dataSet.Tables[0].Rows[0][0].ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public string getCompany(int CId)
	{
		string result = "";
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("CompanyName", "tblCompany_master", "CompId='" + CId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblCompany_master");
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			result = dataSet.Tables[0].Rows[0]["CompanyName"].ToString();
		}
		return result;
	}

	public void EmptyGridFix(GridView grdView)
	{
		if (grdView.Rows.Count == 0 && grdView.DataSource != null)
		{
			DataTable dataTable = null;
			if (grdView.DataSource is DataSet)
			{
				dataTable = ((DataSet)grdView.DataSource).Tables[0].Clone();
			}
			else if (grdView.DataSource is DataTable)
			{
				dataTable = ((DataTable)grdView.DataSource).Clone();
			}
			if (dataTable == null)
			{
				return;
			}
			dataTable.Rows.Add(dataTable.NewRow());
			grdView.DataSource = dataTable;
			grdView.DataBind();
			grdView.Rows[0].Visible = false;
			grdView.Rows[0].Controls.Clear();
		}
		if (grdView.Rows.Count != 1 || grdView.DataSource != null)
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < grdView.Rows[0].Cells.Count; i++)
		{
			if (grdView.Rows[0].Cells[i].Text != string.Empty)
			{
				flag = false;
			}
		}
		if (flag)
		{
			grdView.Rows[0].Visible = false;
			grdView.Rows[0].Controls.Clear();
		}
	}

	public void TotOfModule(string tblName, string tblfield, string whr, GridView SearchGridView)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
			SearchGridView.PageIndex = 0;
			SearchGridView.DataBind();
		}
		finally
		{
			if (SearchGridView.Rows.Count > 0)
			{
				SearchGridView.SelectedIndex = 0;
			}
		}
	}

	public int SetLimit(int scid, int limit, int Cid)
	{
		int result = 0;
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("Symbol", "tblDG_SubCategory_Master", "SCId='" + scid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_SubCategory_Master");
			result = ((Cid == 0) ? (limit - 2) : ((dataSet.Tables[0].Rows.Count <= 0) ? (limit - 3) : (limit - 5)));
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public int SetBomItemLimit(int limit, int wolen)
	{
		int num = 0;
		return limit - (wolen + 3);
	}

	public string createItemCode(int cid, int scid, string pno, string rev, string pro)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = "Select Symbol from tblDG_Category_Master where CId='" + cid + "'";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
		string text = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
		DataSet dataSet2 = new DataSet();
		string cmdText2 = "Select Symbol from tblDG_SubCategory_Master where SCId='" + scid + "'";
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		sqlDataAdapter2.Fill(dataSet2, "tblDG_Category_Master");
		string text2 = "";
		text2 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "" : ((scid != 0) ? dataSet2.Tables[0].Rows[0]["Symbol"].ToString() : "00"));
		DataSet dataSet3 = new DataSet();
		string cmdText3 = "Select Symbol from tblPln_Process_Master where Id='" + pro + "'";
		SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
		SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
		sqlDataAdapter3.Fill(dataSet3, "tblDG_Category_Master");
		string text3 = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
		return text + text2 + pno + rev + text3;
	}

	public void drpunit(DropDownList dpdlunit)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("Symbol,Id ", "Unit_Master");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "unit");
			dpdlunit.DataSource = dataSet.Tables["unit"];
			dpdlunit.DataTextField = "Symbol";
			dpdlunit.DataValueField = "Id";
			dpdlunit.DataBind();
			dpdlunit.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void drpLocat(DropDownList dpdplace)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand selectCommand = new SqlCommand("Select LocationLabel+'-'+LocationNo as Location,Id from tblDG_Location_Master WHERE Id !=0", connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Location_Master");
			dpdplace.DataSource = dataSet.Tables["tblDG_Location_Master"];
			dpdplace.DataTextField = "Location";
			dpdplace.DataValueField = "Id";
			dpdplace.DataBind();
			dpdplace.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void drpDesignCategory(DropDownList DrpCategory, DropDownList DrpSubCategory)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand("Select CId,Symbol+' - '+CName As CatName From tblDG_Category_Master", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			DrpCategory.DataSource = dataSet.Tables["tblDG_Category_Master"];
			DrpCategory.DataTextField = "CatName";
			DrpCategory.DataValueField = "CId";
			DrpCategory.DataBind();
			DrpCategory.Items.Insert(0, "Select Category");
			DrpSubCategory.Items.Insert(0, "Select SubCategory");
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void drpCategoryOnly(DropDownList DrpCategory)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand("Select CId,Symbol+' - '+CName As CatName From tblDG_Category_Master", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			DrpCategory.DataSource = dataSet.Tables["tblDG_Category_Master"];
			DrpCategory.DataTextField = "CatName";
			DrpCategory.DataValueField = "CId";
			DrpCategory.DataBind();
			DrpCategory.Items.Insert(0, "Select Category");
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public double RecurQty(string WONo, int Pid, int Cid, double Y, int CompId, int FinId)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("Qty", "tblDG_TPL_Master", " WONo='" + WONo + "' AND PId='" + Pid + "'AND CId='" + Cid + "'AND CompId='" + CompId + "'AND FinYearId<='" + FinId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			Y *= Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
			if (Pid > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId,Qty", "tblDG_TPL_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'AND CompId='" + CompId + "'AND FinYearId<='" + FinId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
				Y *= Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0][1].ToString()).ToString("N3"));
				int num = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]);
				if (num > 0)
				{
					DataSet dataSet3 = new DataSet();
					string cmdText3 = select("PId", "tblDG_TPL_Master", "WONo='" + WONo + "' AND CId='" + num + "'AND CompId='" + CompId + "'AND FinYearId<='" + FinId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3, "tblDG_TPL_Master");
					int pid = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0]);
					return Math.Round(RecurQty(WONo, pid, num, Y, CompId, FinId), 5);
				}
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(Y, 5);
	}

	public double TPLRecurQty(string WONo, int Pid, int Cid, double s, int compid, int finid)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = select("Qty", "tblDG_TPL_Master", " WONo='" + WONo + "' AND PId='" + Pid + "'AND CId='" + Cid + "'And CompId='" + compid + "'AND FinYearId<='" + finid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			s *= Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
			if (Pid > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId,Qty", "tblDG_TPL_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'And CompId='" + compid + "'AND FinYearId<='" + finid + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
				s *= Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0][1].ToString()).ToString("N3"));
				int num = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]);
				if (num > 0)
				{
					DataSet dataSet3 = new DataSet();
					string cmdText3 = select("PId", "tblDG_TPL_Master", "WONo='" + WONo + "' AND CId='" + num + "'And CompId='" + compid + "'AND FinYearId<='" + finid + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3, "tblDG_TPL_Master");
					int pid = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0]);
					return Math.Round(TPLRecurQty(WONo, pid, num, s, compid, finid), 5);
				}
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(s, 5);
	}

	public List<double> TreeQty(string WONo, int Pid, int Cid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			string cmdText = select("Qty", "tblDG_TPL_Master", "WONo='" + WONo + "' AND PId='" + Pid + "'And CId='" + Cid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			k = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
			list.Add(k);
			if (Pid > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId", "tblDG_TPL_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
				int pid = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]);
				TreeQty(WONo, pid, Pid);
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public List<double> BOMTreeQty(string WONo, int Pid, int Cid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			string cmdText = select("Qty", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='" + Pid + "'And CId='" + Cid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			z = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
			list1.Add(z);
			if (Pid > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId", "tblDG_BOM_Master", "WONo='" + WONo + "' AND CId='" + Pid + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
				int pid = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0]);
				BOMTreeQty(WONo, pid, Pid);
			}
		}
		catch (Exception)
		{
		}
		return list1;
	}

	public void fillGrid(string sql, GridView grid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand(sql, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			grid.DataSource = dataSet;
			grid.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public string createAssemblyCode(int cid, string pno, int rev, int CompId, int finid)
	{
		string result = "";
		try
		{
			int num = 0;
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = "Select Symbol from tblDG_Category_Master where CId='" + cid + "' AND CompId='" + CompId + "'AND FinYearId<='" + finid + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			string text = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
			if (rev == 0)
			{
				rev = 0;
			}
			result = text + pno + rev + num;
		}
		catch (Exception)
		{
		}
		return result;
	}

	public void binddropdwn(string sql, GridView GridView2, int Compid)
	{
		string connectionString = Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("Location", typeof(string));
			dataTable.Columns.Add("Qty", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = GetItemCode_PartNo(Compid, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString()));
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
				int num = 0;
				if (dataSet.Tables[0].Rows[i]["Location"] != DBNull.Value && dataSet.Tables[0].Rows[i]["Location"].ToString() != "")
				{
					num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Location"]);
					string cmdText = "Select LocationLabel+'-'+LocationNo As Loc from tblDG_Location_Master where Id='" + num + "'";
					SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						if (dataSet2.Tables[0].Rows[0]["Loc"] != DBNull.Value && dataSet2.Tables[0].Rows[0]["Loc"].ToString() != "")
						{
							dataRow[4] = dataSet2.Tables[0].Rows[0]["Loc"].ToString();
						}
						else
						{
							dataRow[4] = "NA";
						}
					}
					else
					{
						dataRow[4] = "NA";
					}
					dataRow[5] = decimal.Parse(dataSet.Tables[0].Rows[i]["StockQty"].ToString()).ToString("N3");
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public int getTPLCId(string wono, int CompId, int FinId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = "Select CId from tblDG_TPL_Master Where WONo='" + wono + "' AND CompId='" + CompId + "' AND FinYearId<='" + FinId + "' Order by CId Desc";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
		int num = 0;
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) + 1;
		}
		return 1;
	}

	public int getBOMCId(string wono, int CompId, int FinId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		string cmdText = "Select CId from tblDG_BOM_Master Where WONo='" + wono + "'AND CompId='" + CompId + "' AND FinYearId<='" + FinId + "' Order by CId Desc";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
		int num = 0;
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) + 1;
		}
		return 1;
	}

	public string getOpeningDate(int compid, int finid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		SqlCommand selectCommand = new SqlCommand(select("FinYearFrom", "tblFinancial_master", "CompId='" + compid + "' AND FinYearId='" + finid + "'"), connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
		string result = "";
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			result = FromDateDMY(dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString());
		}
		return result;
	}

	public bool InsertUpdateData(SqlCommand cmd)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		cmd.CommandType = CommandType.Text;
		cmd.Connection = sqlConnection;
		try
		{
			sqlConnection.Open();
			cmd.ExecuteNonQuery();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public DataTable GetData(SqlCommand cmd)
	{
		DataTable dataTable = new DataTable();
		string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		cmd.CommandType = CommandType.Text;
		cmd.Connection = sqlConnection;
		try
		{
			sqlConnection.Open();
			sqlDataAdapter.SelectCommand = cmd;
			sqlDataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch
		{
			return null;
		}
	}

	public void getnode(int node, string wonosrc, string wonodest, int compid, string sesid, int finyrid, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "CId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid);
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			int tPLCId = getTPLCId(wonodest, compid, finyrid);
			string cmdText2 = insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH,ConvertToBOM", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "',", compid, ",", finyrid, ",'", sesid.ToString(), "','", num, "','", tPLCId, "','", wonodest, "','", Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")), "','", dataSet.Tables[0].Rows[0]["Weldments"], "','", dataSet.Tables[0].Rows[0]["LH"], "','", dataSet.Tables[0].Rows[0]["RH"], "','1'"));
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid);
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int tPLCId2 = getTPLCId(wonodest, compid, finyrid);
				string cmdText4 = insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH,ConvertToBOM", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "','", compid, "','", finyrid, "','", sesid.ToString(), "','", tPLCId, "','", tPLCId2, "','", wonodest, "','", Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")), "','", dataSet2.Tables[0].Rows[i]["Weldments"], "','", dataSet2.Tables[0].Rows[i]["LH"], "','", dataSet2.Tables[0].Rows[i]["RH"], "','1'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				string cmdText5 = update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wonodest + "' And  CompId='" + compid + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText6 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", string.Concat("WONo='", wonosrc, "'And CompId=", compid, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = tPLCId2;
						getnode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, compid, sesid, finyrid, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), num);
					}
				}
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

	public void getBOMnode(int node, string wonosrc, string wonodest, int compid, string sesid, int finyrid, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("*", "tblDG_BOM_Master", "CId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid + " And FinYearId<='" + finyrid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			int bOMCId = getBOMCId(wonodest, compid, finyrid);
			string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "'," + compid + "," + finyrid + ",'" + sesid.ToString() + "','" + num + "','" + bOMCId + "','" + wonodest + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) + "','" + dataSet.Tables[0].Rows[0]["EquipmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["UnitNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PartNo"].ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("*", "tblDG_BOM_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId='" + compid + "' And FinYearId<='" + finyrid + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int bOMCId2 = getBOMCId(wonodest, compid, finyrid);
				string cmdText4 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + compid + "','" + finyrid + "','" + sesid.ToString() + "','" + bOMCId + "','" + bOMCId2 + "','" + wonodest + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "','" + dataSet2.Tables[0].Rows[i]["EquipmentNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["UnitNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["PartNo"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText5 = select("*", "tblDG_BOM_Master", string.Concat("WONo='", wonosrc, "'And CompId=", compid, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'And FinYearId<='", finyrid, "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = bOMCId2;
						getBOMnode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, compid, sesid, finyrid, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), num);
					}
				}
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

	public void getRootNode(int node, string wonosrc, string wonodest, int compid, string sesid, int finyrid, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "CId='" + node + "' And WONo='" + wonosrc + "'And CompId=" + compid + "And FinYearId<='" + finyrid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			int tPLCId = getTPLCId(wonodest, compid, finyrid);
			string cmdText2 = insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH,ConvertToBOM", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "',", compid, ",", finyrid, ",'", sesid.ToString(), "','", destpid, "','", tPLCId, "','", wonodest, "','", Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")), "','", dataSet.Tables[0].Rows[0]["Weldments"], "','", dataSet.Tables[0].Rows[0]["LH"], "','", dataSet.Tables[0].Rows[0]["RH"], "','1'"));
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid + "And FinYearId<='" + finyrid + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int tPLCId2 = getTPLCId(wonodest, compid, finyrid);
				string cmdText4 = insert("tblDG_TPL_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH,ConvertToBOM", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "','", compid, "','", finyrid, "','", sesid.ToString(), "','", tPLCId, "','", tPLCId2, "','", wonodest, "','", Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")), "','", dataSet2.Tables[0].Rows[i]["Weldments"], "','", dataSet2.Tables[0].Rows[i]["LH"], "','", dataSet2.Tables[0].Rows[i]["RH"], "','1'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText5 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", string.Concat("WONo='", wonosrc, "'And CompId=", compid, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'And FinYearId<='", finyrid, "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = tPLCId2;
						getRootNode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, compid, sesid, finyrid, num, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]));
					}
				}
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

	public void getBOMRootNode(int node, string wonosrc, string wonodest, int CompId, string SessionId, int FinYearId, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("*", "tblDG_BOM_Master", "CId='" + node + "' And WONo='" + wonosrc + "'And CompId=" + CompId + "And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			int bOMCId = getBOMCId(wonodest, CompId, FinYearId);
			string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "'," + CompId + "," + FinYearId + ",'" + SessionId.ToString() + "','" + destpid + "','" + bOMCId + "','" + wonodest + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) + "','" + dataSet.Tables[0].Rows[0]["EquipmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["UnitNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PartNo"].ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("*", "tblDG_BOM_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId=" + CompId + "And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int bOMCId2 = getBOMCId(wonodest, CompId, FinYearId);
				string cmdText4 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,EquipmentNo,UnitNo,PartNo", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SessionId.ToString() + "','" + bOMCId + "','" + bOMCId2 + "','" + wonodest + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "','" + dataSet2.Tables[0].Rows[i]["EquipmentNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["UnitNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["PartNo"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText5 = select("*", "tblDG_BOM_Master", string.Concat("WONo='", wonosrc, "'And CompId=", CompId, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'And FinYearId<='", FinYearId, "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = bOMCId2;
						getBOMRootNode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, CompId, SessionId, FinYearId, num, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]));
					}
				}
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

	public void getTPLRootNode(int node, string wonosrc, string wonodest, int CompId, string SessionId, int FinYearId, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "CId='" + node + "' And WONo='" + wonosrc + "'And CompId=" + CompId + "And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			int bOMCId = getBOMCId(wonodest, CompId, FinYearId);
			string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "',", CompId, ",", FinYearId, ",'", SessionId.ToString(), "','", destpid, "','", bOMCId, "','", wonodest, "','", Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")), "','", dataSet.Tables[0].Rows[0]["Weldments"], "','", dataSet.Tables[0].Rows[0]["LH"], "','", dataSet.Tables[0].Rows[0]["RH"], "'"));
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId=" + CompId + "And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int bOMCId2 = getBOMCId(wonodest, CompId, FinYearId);
				string cmdText4 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "','", CompId, "','", FinYearId, "','", SessionId.ToString(), "','", bOMCId, "','", bOMCId2, "','", wonodest, "','", Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]), "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")), "','", dataSet2.Tables[0].Rows[i]["Weldments"], "','", dataSet2.Tables[0].Rows[i]["LH"], "','", dataSet2.Tables[0].Rows[i]["RH"], "'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText5 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", "tblDG_TPL_Master", string.Concat("WONo='", wonosrc, "'And CompId=", CompId, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'And FinYearId<='", FinYearId, "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = bOMCId2;
						getTPLRootNode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, CompId, SessionId, FinYearId, num, Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]));
					}
				}
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

	public List<int> getBOMDelNode(int node, string wono, int CompId, string SessionId, int Id, string tblName)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = 0;
		try
		{
			new DataSet();
			sqlConnection.Open();
			string cmdText = select("Id,PId,CId,ItemId,Qty", tblName ?? "", "CId=" + node + "And WONo='" + wono + "'And CompId=" + CompId + " And Id='" + Id + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				string cmdText2 = select("Id,PId,CId,ItemId,Qty", tblName ?? "", string.Concat("WONo='", wono, "'And CompId=", CompId, " AND PId='", dataSet.Tables[0].Rows[i]["CId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					getBOMDelNode(Convert.ToInt32(dataSet2.Tables[0].Rows[j]["CId"]), wono, CompId, SessionId, Convert.ToInt32(dataSet2.Tables[0].Rows[j]["Id"]), tblName);
				}
				BomAssmbly.Add(Convert.ToInt32(num));
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return BomAssmbly;
	}

	public List<string> MonthRange(string StartDate, string EndDate)
	{
		List<string> list = new List<string>();
		try
		{
			string[] array = StartDate.Split('-');
			string[] array2 = EndDate.Split('-');
			DateTime dateTime = new DateTime(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), Convert.ToInt32(array[2]));
			DateTime dateTime2 = new DateTime(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]), Convert.ToInt32(array2[2]));
			if (dateTime2 >= dateTime)
			{
				int[] array3 = new int[13]
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10, 11, 12
				};
				_ = dateTime2 - dateTime;
				int num = dateTime2.Month - dateTime.Month + 12 * (dateTime2.Year - dateTime.Year) - ((dateTime2.Day < dateTime.Day) ? 1 : 0);
				int num2 = 0;
				for (int i = 0; i < num + 1; i++)
				{
					int num3 = dateTime.Month + i;
					if (num3 <= 12)
					{
						list.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(array3[num3]));
						continue;
					}
					num2++;
					list.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(array3[num2]));
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public void BindMobBill(string tblName, string tblfield, string whr, GridView SearchGridView, string drpvalue, string hfSearchTextValue)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			if (hfSearchTextValue != "")
			{
				dataSet.Clear();
				string text2 = text;
				text = text2 + " AND " + drpvalue + " like '%" + hfSearchTextValue + "%'";
				SqlCommand selectCommand2 = new SqlCommand(text, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet, tblName);
			}
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void AcHead(DropDownList DropDownList1, int y)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (y == 1)
			{
				text = "Labour";
			}
			if (y == 2)
			{
				text = "With Material";
			}
			if (y == 3)
			{
				text = "Expenses";
			}
			if (y == 4)
			{
				text = "Service Provider";
			}
			string cmdText = "SELECT '['+Symbol+'] '+Description AS Head,Id FROM AccHead WHERE Category='" + text + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			DropDownList1.DataSource = dataSet;
			DropDownList1.DataTextField = "Head";
			DropDownList1.DataValueField = "Id";
			DropDownList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void AcHead(DropDownList DropDownList1, RadioButton RbtnLabour, RadioButton RbtnWithMaterial, RadioButton RbtnExpenses, RadioButton RbtnSerProvider)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (RbtnLabour.Checked)
			{
				text = "Labour";
			}
			if (RbtnWithMaterial.Checked)
			{
				text = "With Material";
			}
			if (RbtnExpenses.Checked)
			{
				text = "Expenses";
			}
			if (RbtnSerProvider.Checked)
			{
				text = "Service Provider";
			}
			string cmdText = "SELECT '['+Symbol+'] '+Description AS Head,Id FROM AccHead WHERE Category='" + text + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			DropDownList1.DataSource = dataSet;
			DropDownList1.DataTextField = "Head";
			DropDownList1.DataValueField = "Id";
			DropDownList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public int chkSupplierCode(string code)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand(select("*", "tblMM_Supplier_master", "SupplierId='" + code + "'"), connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
		}
		catch (Exception)
		{
		}
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return 1;
		}
		return 0;
	}

	public int chkCustomerCode(string code)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand(select("*", "SD_Cust_master", "CustomerId='" + code + "'"), connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
		}
		catch (Exception)
		{
		}
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return 1;
		}
		return 0;
	}

	public int chkEmpCustSupplierCode(string code, int codetype, int CompId)
	{
		string connectionString = Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			switch (codetype)
			{
			case 1:
			{
				string selectCommandText3 = select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + code + "' ");
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection);
				sqlDataAdapter3.Fill(dataSet, "tblHR_OfficeStaff");
				break;
			}
			case 2:
			{
				string selectCommandText2 = select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + code + "'");
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection);
				sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
				break;
			}
			case 3:
			{
				string selectCommandText = select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + code + "'");
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
				break;
			}
			}
		}
		catch (Exception)
		{
		}
		if (code != "" && codetype != 0)
		{
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				return 1;
			}
			return 0;
		}
		return 0;
	}

	public int chkItemId(int itid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand(select("*", "tblMM_SPR_Temp", "ItemId='" + itid + "'"), connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblMM_SPR_Temp");
		}
		catch (Exception)
		{
		}
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return 1;
		}
		return 0;
	}

	public void MP_Tree(string wono, int CompId, DropDownList ddlCategory, GridView GridView2, int finid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!(ddlCategory.SelectedItem.Text != "Select Category"))
			{
				return;
			}
			List<int> list = new List<int>();
			list = TreeAssembly(wono, CompId);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("AssemblyNo", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("BOMQty", typeof(string));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PId", typeof(int));
			dataTable.Columns.Add("CId", typeof(int));
			for (int i = 0; i < list.Count; i++)
			{
				DataSet dataSet = new DataSet();
				if (list.Count <= 0)
				{
					continue;
				}
				string cmdText = select("tblDG_Item_Master.Id,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Category_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + wono + "'and tblDG_Item_Master.CId='" + ddlCategory.SelectedValue + "' and  tblDG_BOM_Master.Id='" + Convert.ToInt32(list[i]) + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + finid + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = select("*", "tblMP_Material_Master", "PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]) + "' AND CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]) + "' AND CompId='" + CompId + "' AND WONo='" + wono + "' ");
				DataSet dataSet2 = new DataSet();
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText3 = select("tblDG_Item_Master.ItemCode", "tblDG_BOM_Master,tblDG_Item_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]) + "' AND tblDG_Item_Master.CompId='" + CompId + "'");
					DataSet dataSet3 = new DataSet();
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[0] = "";
					}
					dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[0]["Qty"].ToString();
					double num = Convert.ToDouble(decimal.Parse(BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]), 1.0, CompId, finid).ToString()).ToString("N3"));
					dataRow[5] = num;
					dataRow[6] = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[0]["PId"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[0]["CId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public double ComponentBOMQty(int CompId, string wono, string itemid, int finId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty as UnitQty", "tblDG_BOM_Master,tblDG_Category_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + wono + "'and tblDG_Item_Master.Id='" + Convert.ToInt32(itemid) + "' And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + finId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double num = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = select("*", "tblMP_Material_Master", "PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "' AND CompId='" + CompId + "'and WONo='" + wono + "'AND FinYearId<='" + finId + "' AND ItemId='" + Convert.ToInt32(itemid) + "'");
				DataSet dataSet2 = new DataSet();
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = select("tblMP_Material_RawMaterial.ItemId", "tblMP_Material_Master,tblMP_Material_RawMaterial", "tblMP_Material_RawMaterial.PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND tblMP_Material_RawMaterial.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "' AND tblMP_Material_RawMaterial.ItemId='" + Convert.ToInt32(itemid) + "' AND tblMP_Material_Master.CompId='" + CompId + "' And FinYearId<='" + finId + "' AND tblMP_Material_RawMaterial.PLNo=tblMP_Material_Master.PLNo AND tblMP_Material_Master.WONo='" + wono + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = select("CId", "tblMP_Material_Master", "CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND CompId='" + CompId + "'and WONo='" + wono + "'And FinYearId<='" + finId + "'");
				DataSet dataSet4 = new DataSet();
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				sqlDataAdapter4.Fill(dataSet4);
				string cmdText5 = select("tblMP_Material_RawMaterial.CId", "tblMP_Material_Master,tblMP_Material_RawMaterial", "tblMP_Material_RawMaterial.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND tblMP_Material_Master.CompId='" + CompId + "' AND tblMP_Material_RawMaterial.PLNo=tblMP_Material_Master.PLNo AND tblMP_Material_Master.WONo='" + wono + "'And tblMP_Material_Master.FinYearId<='" + finId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet2.Tables[0].Rows.Count == 0 && dataSet3.Tables[0].Rows.Count == 0 && dataSet4.Tables[0].Rows.Count == 0 && dataSet5.Tables[0].Rows.Count == 0)
				{
					num += BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]), 1.0, CompId, finId);
				}
			}
		}
		return Math.Round(num, 5);
	}

	public List<int> TreeAssembly(string wono, int Compid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			string cmdText = select("PId", "tblDG_BOM_Master", "WONo='" + wono + "'And CompId='" + Compid + "'And PId!=0 Group By PId");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = select("Id", "tblDG_BOM_Master", " WONo='" + wono + "' And CompId='" + Compid + "' And CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
					Assmbly.Add(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]));
				}
			}
		}
		catch (Exception)
		{
		}
		return Assmbly;
	}

	public List<int> TPLTree(string wono, string pid, string cid, int Compid, int FinId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			string cmdText = select("PId", "tblDG_TPL_Master", "WONo='" + wono + "' AND CompId='" + Compid + "'And FinYearId='" + FinId + "'And PId='" + pid + "' Group By PId");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = select("Id", "tblDG_TPL_Master", "WONo='" + wono + "' AND CompId='" + Compid + "'And FinYearId='" + FinId + "' And CId='" + Convert.ToInt32(pid) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_TPL_Master");
					AssmblyTPL.Add(Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]));
				}
			}
		}
		catch (Exception)
		{
		}
		return AssmblyTPL;
	}

	public List<int> BOMTree(string wono, string pid, string cid, int Compid, int finId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			string cmdText = select("PId", "tblDG_BOM_Master", "WONo='" + wono + "' AND CompId='" + Compid + "'AND tblDG_BOM_Master.FinYearId<='" + finId + "'And PId='" + pid + "' Group By PId");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = select("Id", "tblDG_BOM_Master", "WONo='" + wono + "' AND CompId='" + Compid + "'AND tblDG_BOM_Master.FinYearId<='" + finId + "'And CId='" + Convert.ToInt32(pid) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						BOMId.Add(Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]));
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return BOMId;
	}

	public List<int> TreeComponant(string wono, int Compid)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			string cmdText = select("CId", "tblDG_BOM_Master", "WONo='" + wono + "'And CompId='" + Compid + "'And CId Not In(Select PId from tblDG_BOM_Master where WONo='" + wono + "'And CompId='" + Compid + "'Group By PId)");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = select("ItemId", "tblDG_BOM_Master", " WONo='" + wono + "' And CompId='" + Compid + "' And CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "' Group By ItemId");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
					componant.Add(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]));
				}
			}
		}
		catch (Exception)
		{
		}
		return componant;
	}

	public void getcategory(DropDownList dpdlBG)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("(CName+' [ '+Symbol+' ]')As name,CId ", "tblDG_Category_Master");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			dpdlBG.DataSource = dataSet.Tables["tblDG_Category_Master"];
			dpdlBG.DataTextField = "name";
			dpdlBG.DataValueField = "CId";
			dpdlBG.DataBind();
			dpdlBG.Items.Insert(0, "Select Category");
		}
		catch (Exception)
		{
		}
	}

	public void ComponentBOM_Consolidated_Items_RM(int CompId, string wono, string plno, string itemid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty as UnitQty", "tblDG_BOM_Master,tblDG_Category_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + wono + "'and tblDG_Item_Master.Id='" + Convert.ToInt32(itemid) + "' And tblDG_BOM_Master.CompId='" + CompId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			string cmdText2 = select("*", "tblMP_Material_Master", "PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "' AND CompId='" + CompId + "'and WONo='" + wono + "' AND ItemId='" + Convert.ToInt32(itemid) + "'");
			DataSet dataSet2 = new DataSet();
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2);
			string cmdText3 = select("tblMP_Material_RawMaterial.ItemId", "tblMP_Material_Master,tblMP_Material_RawMaterial", "tblMP_Material_RawMaterial.PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND tblMP_Material_RawMaterial.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "' AND tblMP_Material_RawMaterial.ItemId='" + Convert.ToInt32(itemid) + "' AND tblMP_Material_Master.CompId='" + CompId + "' AND tblMP_Material_RawMaterial.PLNo=tblMP_Material_Master.PLNo AND tblMP_Material_Master.WONo='" + wono + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			string cmdText4 = select("CId", "tblMP_Material_Master", "CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND CompId='" + CompId + "'and WONo='" + wono + "'");
			DataSet dataSet4 = new DataSet();
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			sqlDataAdapter4.Fill(dataSet4);
			string cmdText5 = select("tblMP_Material_RawMaterial.CId", "tblMP_Material_Master,tblMP_Material_RawMaterial", "tblMP_Material_RawMaterial.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]) + "' AND tblMP_Material_Master.CompId='" + CompId + "' AND tblMP_Material_RawMaterial.PLNo=tblMP_Material_Master.PLNo AND tblMP_Material_Master.WONo='" + wono + "'");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			if (dataSet2.Tables[0].Rows.Count == 0 && dataSet3.Tables[0].Rows.Count == 0 && dataSet4.Tables[0].Rows.Count == 0 && dataSet5.Tables[0].Rows.Count == 0)
			{
				string cmdText6 = insert("tblMP_Material_RawMaterial", "PLNo,PId,CId,ItemId", string.Concat("'", plno, "','", dataSet.Tables[0].Rows[i]["PId"], "','", dataSet.Tables[0].Rows[i]["CId"], "','", dataSet.Tables[0].Rows[i]["ItemId"].ToString(), "'"));
				SqlCommand sqlCommand = new SqlCommand(cmdText6, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
		}
	}

	public string getSupplierName(string SupplierId, int CompId)
	{
		string connectionString = Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string cmdText = select("SupplierName+' ['+SupplierId+']' as Supl", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + SupplierId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			return dataSet.Tables[0].Rows[0]["Supl"].ToString();
		}
		return "";
	}

	public double CalBasicAmt(double qty, double rate)
	{
		return Math.Round(qty * rate, 2);
	}

	public double CalDiscAmt(double qty, double rate, double disc)
	{
		return Math.Round(qty * rate - qty * rate * disc / 100.0, 2);
	}

	public double CalTaxAmt(double qty, double rate, double disc, double pf, double exser, double vat)
	{
		double num = qty * rate - qty * rate * disc / 100.0;
		double num2 = num + pf;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		num3 = num2 + num2 * exser / 100.0;
		num4 = num2 * exser / 100.0;
		_ = num3 * vat / 100.0;
		num5 = num3 * vat / 100.0;
		return Math.Round(num4 + num5, 2);
	}

	public double CalTotAmt(double qty, double rate, double disc, double pf, double exser, double vat)
	{
		double num = qty * rate - qty * rate * disc / 100.0;
		double num2 = num + pf;
		double num3 = 0.0;
		num3 = ((!(exser > 0.0)) ? num2 : (num2 + num2 * exser / 100.0));
		double num4 = 0.0;
		num4 = ((!(vat > 0.0)) ? num3 : (num3 + num3 * vat / 100.0));
		return Math.Round(num4, 2);
	}

	public void drpDept(DropDownList dpdlunit)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = select1("Symbol,Id,Description", "tblHR_Departments");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblHR_Departments");
			dpdlunit.DataSource = dataSet.Tables[0];
			dpdlunit.DataTextField = "Description";
			dpdlunit.DataValueField = "Id";
			dpdlunit.DataBind();
			dpdlunit.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public double getBudget(int AccId, int CId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		double result = 0.0;
		try
		{
			sqlConnection.Open();
			string cmdText = "Select Sum(Amount) As BalBudget from  tblACC_Budget_Transactions where CompId='" + CId + "'  and BudgetCode='" + AccId + "' group by  BudgetCode ";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, " tblACC_Budget_Transactions");
			string cmdText2 = "select Sum(Amount) As Budget from tblACC_Budget_Dept where  CompId='" + CId + "'  and AccId='" + AccId + "'";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblACC_Budget_Dept");
			string cmdText3 = "select Sum(Amount) As Budget from tblACC_Budget_WO where CompId='" + CId + "'  and AccId='" + AccId + "'";
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3, "tblACC_Budget_WO");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				double num = 0.0;
				if (dataSet2.Tables[0].Rows[0]["Budget"] != DBNull.Value)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2"));
				}
				double num2 = 0.0;
				if (dataSet3.Tables[0].Rows[0]["Budget"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2"));
				}
				result = ((!(num > 0.0) && !(num2 > 0.0)) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2")) : (Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2")) - (num + num2)));
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public double getTotalAllowBudget_By_AccId(int AccId, int CId, int Type, string category)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		double result = 0.0;
		string cmdText = "";
		try
		{
			switch (Type)
			{
			case 1:
				cmdText = select("Sum(tblACC_Budget_Dept.Amount) AS  Budget", "tblACC_Budget_Dept,AccHead", "tblACC_Budget_Dept.CompId='" + CId + "'  AND  tblACC_Budget_Dept.AccId='" + AccId + "' AND AccHead.Category='" + category + "' AND tblACC_Budget_Dept.AccId=AccHead.Id");
				break;
			case 2:
				cmdText = select("Sum(tblACC_Budget_WO.Amount) AS  Budget", "tblACC_Budget_WO,AccHead", "tblACC_Budget_WO.CompId='" + CId + "'  AND tblACC_Budget_WO.AccId='" + AccId + "'  AND  AccHead.Category='" + category + "' AND AND tblACC_Budget_WO.AccId=AccHead.Id");
				break;
			}
			sqlConnection.Open();
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Budget"] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2")), 5);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public double getAllowBudget_By_AccId(int AccId, int CId, int Type, string getfor)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		double result = 0.0;
		string cmdText = "";
		try
		{
			switch (Type)
			{
			case 1:
				cmdText = select("Sum(tblACC_Budget_Dept.Amount) AS  Budget", "tblACC_Budget_Dept,AccHead,tblHR_Departments", "tblACC_Budget_Dept.CompId='" + CId + "'  AND  tblACC_Budget_Dept.AccId='" + AccId + "' AND tblACC_Budget_Dept.DeptId ='" + getfor + "' AND tblACC_Budget_Dept.DeptId=tblHR_Departments.Id AND tblACC_Budget_Dept.AccId=AccHead.Id");
				break;
			case 2:
				cmdText = select("Sum(tblACC_Budget_WO.Amount) AS  Budget", "tblACC_Budget_WO,AccHead", "tblACC_Budget_WO.CompId='" + CId + "'  AND tblACC_Budget_WO.AccId='" + AccId + "'  AND tblACC_Budget_WO.WONo  ='" + getfor + "' AND  tblACC_Budget_WO.AccId=AccHead.Id ");
				break;
			}
			sqlConnection.Open();
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["Budget"] != DBNull.Value)
			{
				result = Math.Round(Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Budget"].ToString()).ToString("N2")), 5);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return result;
	}

	public void SearchData(DropDownList drp1, DropDownList drp2, DropDownList drpsearch, TextBox txt, GridView drd, int compid, int FinYearId)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		try
		{
			if (drp1.SelectedValue != "Select Category")
			{
				text = "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master";
				text2 = "tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category , tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode";
				text3 = " tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase and  tblDG_Item_Master.CId='" + drp1.SelectedValue + "'And tblDG_Item_Master.CompId='" + compid + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
			}
			else
			{
				text = "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master";
				text2 = "tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category  ,tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode";
				text3 = " tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase and tblDG_Item_Master.CompId='" + compid + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
			}
			if (drp2.SelectedValue != "Select SubCategory")
			{
				text += ",tblDG_SubCategory_Master";
				text2 += ",tblDG_SubCategory_Master.Symbol+'-'+tblDG_SubCategory_Master.SCName as SubCategory";
				text3 = text3 + " AND tblDG_Item_Master.SCId=tblDG_SubCategory_Master.SCId AND tblDG_Item_Master.SCId='" + drp2.SelectedValue + "'";
			}
			else
			{
				text = text ?? "";
				text2 = text2 ?? "";
				text3 = text3 ?? "";
			}
			BindGridData(text, text2, text3, drd, drpsearch.SelectedValue, txt.Text, compid, FinYearId);
		}
		catch (Exception)
		{
		}
	}

	public void FillgridviewMRS(string sd, string A, string B, string s, int CompId, GridView grv, TextBox txtSearchItemCode, DropDownList DropDownList3, string Sid)
	{
		try
		{
			string text = "";
			string text2 = "";
			if (sd != "Select Category")
			{
				string text3 = "";
				if (A != "Select SubCategory")
				{
					text3 = "  And tblDG_Item_Master.SCId='" + A + "'";
				}
				text2 = " AND  tblDG_Item_Master.CId='" + sd + "'";
				string text4 = "";
				txtSearchItemCode.Visible = true;
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.PurchDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.PurchDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.Location")
					{
						txtSearchItemCode.Visible = false;
						DropDownList3.Visible = true;
						text4 = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
					}
				}
				text = select("tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category , tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode", "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase" + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + CompId + "'");
			}
			else
			{
				text = select("tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category , tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode", "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase AND tblDG_Item_Master.CompId='" + CompId + "'");
			}
			BindGridMRSData(text, grv, CompId, Sid);
		}
		catch (Exception)
		{
		}
	}

	public void BindGridMRSData(string sql, GridView SearchGridView, int CompId, string sId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblName");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				dataSet.Tables[0].Rows.Add(dataSet.Tables[0].NewRow());
			}
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCategory", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PartNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurchase", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinOrderQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinStockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Absolute", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpenBalDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningBalQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMConFact", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText = select("ItemId", "tblinv_MaterialRequisition_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND ItemId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["Category"].ToString();
					string cmdText2 = select("tblDG_SubCategory_Master.SCId,'['+tblDG_SubCategory_Master.Symbol+']-'+tblDG_SubCategory_Master.SCName as SubCatName", "tblDG_SubCategory_Master,tblDG_Item_Master", "tblDG_SubCategory_Master.SCId=tblDG_Item_Master.SCId AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet3.Tables[0].Rows[0]["SubCatName"].ToString();
					}
					dataRow[3] = dataSet.Tables[0].Rows[i]["PartNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["Revision"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["Process"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[i]["PurchDesc"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["UOMPurchase"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[i]["MinOrderQty"].ToString();
					dataRow[12] = dataSet.Tables[0].Rows[i]["MinStockQty"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[i]["StockQty"].ToString();
					string cmdText3 = select("tblDG_Location_Master.LocationLabel+LocationNo as LocatName", "tblDG_Location_Master,tblDG_Item_Master", "tblDG_Location_Master.Id=tblDG_Item_Master.Location AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[14] = dataSet4.Tables[0].Rows[0]["LocatName"].ToString();
					}
					dataRow[15] = dataSet.Tables[0].Rows[i]["Absolute"].ToString();
					dataRow[16] = dataSet.Tables[0].Rows[i]["OpenBalDate"].ToString();
					dataRow[17] = dataSet.Tables[0].Rows[i]["OpeningBalQty"].ToString();
					dataRow[18] = dataSet.Tables[0].Rows[i]["UOMConFact"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView.DataSource = dataTable;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void FillgridviewMRN(string sd, string A, string B, string s, int compid, GridView grv, TextBox txtSearchItemCode, DropDownList DropDownList3, string Sid)
	{
		try
		{
			string text = "";
			string text2 = "";
			if (sd != "Select Category")
			{
				string text3 = "";
				if (A != "Select SubCategory")
				{
					text3 = "  And tblDG_Item_Master.SCId='" + A + "'";
				}
				text2 = " AND  tblDG_Item_Master.CId='" + sd + "'";
				string text4 = "";
				txtSearchItemCode.Visible = true;
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.PurchDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.PurchDesc Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.Location")
					{
						txtSearchItemCode.Visible = false;
						DropDownList3.Visible = true;
						text4 = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
					}
				}
				text = select("tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category , tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode", "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase" + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + compid + "'");
			}
			else
			{
				text = select("tblDG_Item_Master.Id,tblDG_Category_Master.Symbol+'-'+ tblDG_Category_Master.CName as Category , tblDG_Item_Master.PartNo,tblDG_Item_Master.Revision ,tblDG_Item_Master.Process,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc ,Unit_Master.Symbol As UOMBasic,vw_Unit_Master.Symbol As UOMPurchase,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact, tblDG_Item_Master.ItemCode", "tblDG_Category_Master,tblDG_Item_Master,Unit_Master,vw_Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase AND tblDG_Item_Master.CompId='" + compid + "'");
			}
			BindGridMRNData(text, grv, compid, Sid);
		}
		catch (Exception)
		{
		}
	}

	public void BindGridMRNData(string sql, GridView SearchGridView, int CompId, string sId)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(sql, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblName");
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCategory", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PartNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurchase", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinOrderQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinStockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Absolute", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpenBalDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningBalQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMConFact", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText = select("ItemId", "tblinv_MaterialReturn_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND ItemId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["Category"].ToString();
					string cmdText2 = select("tblDG_SubCategory_Master.SCId,'['+tblDG_SubCategory_Master.Symbol+']-'+tblDG_SubCategory_Master.SCName as SubCatName", "tblDG_SubCategory_Master,tblDG_Item_Master", "tblDG_SubCategory_Master.SCId=tblDG_Item_Master.SCId AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet3.Tables[0].Rows[0]["SubCatName"].ToString();
					}
					dataRow[3] = dataSet.Tables[0].Rows[i]["PartNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["Revision"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["Process"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[i]["PurchDesc"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["UOMPurchase"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[i]["MinOrderQty"].ToString();
					dataRow[12] = dataSet.Tables[0].Rows[i]["MinStockQty"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[i]["StockQty"].ToString();
					string cmdText3 = select("tblDG_Location_Master.LocationLabel+LocationNo as LocatName", "tblDG_Location_Master,tblDG_Item_Master", "tblDG_Location_Master.Id=tblDG_Item_Master.Location AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, connection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[14] = dataSet4.Tables[0].Rows[0]["LocatName"].ToString();
					}
					dataRow[15] = dataSet.Tables[0].Rows[i]["Absolute"].ToString();
					dataRow[16] = dataSet.Tables[0].Rows[i]["OpenBalDate"].ToString();
					dataRow[17] = dataSet.Tables[0].Rows[i]["OpeningBalQty"].ToString();
					dataRow[18] = dataSet.Tables[0].Rows[i]["UOMConFact"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView.DataSource = dataTable;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
			SearchGridView.PageIndex = 0;
			SearchGridView.DataBind();
		}
		finally
		{
			if (SearchGridView.Rows.Count > 0)
			{
				SearchGridView.SelectedIndex = 0;
			}
		}
	}

	public void BindGridData(string tblName, string tblfield, string whr, GridView SearchGridView, string drpvalue, string hfSearchTextValue, int compid, int finId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			if (hfSearchTextValue != "")
			{
				dataSet.Clear();
				string text2 = text;
				text = text2 + " AND " + drpvalue + " like '" + hfSearchTextValue + "%'";
				SqlCommand selectCommand2 = new SqlCommand(text, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet, tblName);
			}
			else
			{
				dataSet.Clear();
				SqlCommand selectCommand3 = new SqlCommand(text, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet, tblName);
			}
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(MappingType)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCategory", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PartNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurchase", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinOrderQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinStockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Absolute", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpenBalDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningBalQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMConFact", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Category"].ToString();
				string cmdText = select("tblDG_SubCategory_Master.SCId,'['+tblDG_SubCategory_Master.Symbol+']-'+tblDG_SubCategory_Master.SCName as SubCatName", "tblDG_SubCategory_Master,tblDG_Item_Master", "tblDG_SubCategory_Master.SCId=tblDG_Item_Master.SCId AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'And tblDG_Item_Master.CompId='" + compid + "' And tblDG_Item_Master.FinYearId<='" + finId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter4.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["SubCatName"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["PartNo"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Revision"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["Process"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["PurchDesc"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["UOMPurchase"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["MinOrderQty"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["MinStockQty"].ToString();
				dataRow[13] = dataSet.Tables[0].Rows[i]["StockQty"].ToString();
				string cmdText2 = select("tblDG_Location_Master.LocationLabel+LocationNo as LocatName", "tblDG_Location_Master,tblDG_Item_Master", "tblDG_Location_Master.Id=tblDG_Item_Master.Location AND tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblDG_Item_Master.CompId='" + compid + "'And tblDG_Item_Master.FinYearId<='" + finId + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter5.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[14] = dataSet3.Tables[0].Rows[0]["LocatName"].ToString();
				}
				else
				{
					dataRow[14] = "NA";
				}
				dataRow[15] = dataSet.Tables[0].Rows[i]["Absolute"].ToString();
				dataRow[16] = dataSet.Tables[0].Rows[i]["OpenBalDate"].ToString();
				dataRow[17] = dataSet.Tables[0].Rows[i]["OpeningBalQty"].ToString();
				dataRow[18] = dataSet.Tables[0].Rows[i]["UOMConFact"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			SearchGridView.DataSource = dataTable;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void ItemHistory_BOM(string wono, string pid, string cid, int CompId, GridView GridView2, double qty, int finId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			List<int> list = new List<int>();
			list = BOMTree(wono, pid, cid, CompId, finId);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("AssemblyNo", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("BOMQty", typeof(string));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PId", typeof(int));
			dataTable.Columns.Add("CId", typeof(int));
			dataTable.Columns.Add("WONo", typeof(string));
			dataTable.Columns.Add("Date", typeof(string));
			dataTable.Columns.Add("Time", typeof(string));
			dataTable.Columns.Add("Id", typeof(string));
			for (int i = 0; i < list.Count; i++)
			{
				DataSet dataSet = new DataSet();
				if (list.Count <= 0)
				{
					continue;
				}
				string cmdText = select("tblDG_Item_Master.Id,tblDG_BOM_Master.WONo,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_BOM_Master.SysDate , CHARINDEX('-',tblDG_BOM_Master.SysDate ) + 1, 2) + '-' + LEFT(tblDG_BOM_Master.SysDate,CHARINDEX('-',tblDG_BOM_Master.SysDate) - 1) + '-' + RIGHT(tblDG_BOM_Master.SysDate, CHARINDEX('-', REVERSE(tblDG_BOM_Master.SysDate)) - 1)), 103), '/', '-') AS  Date ,tblDG_BOM_Master.SysTime As Time", " tblDG_BOM_Master,tblDG_Category_Master,tblDG_Item_Master,Unit_Master", "Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and  tblDG_BOM_Master.Id='" + Convert.ToInt32(list[i]) + "' And tblDG_BOM_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + finId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = select("tblDG_Item_Master.ItemCode", "tblDG_BOM_Master,tblDG_Item_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]) + "'And tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + finId + "'");
					DataSet dataSet2 = new DataSet();
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[0] = "NA";
					}
					dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					dataRow[4] = decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
					dataRow[5] = decimal.Parse((qty * BOMRecurQty(dataSet.Tables[0].Rows[0]["WONo"].ToString(), Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]), 1.0, CompId, finId)).ToString()).ToString("N3");
					dataRow[6] = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[0]["PId"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[0]["CId"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["Date"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[0]["Time"].ToString();
					dataRow[12] = dataSet.Tables[0].Rows[0]["Id"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void ItemHistory_TPL(string wono, string pid, string cid, int CompId, GridView GridView2, double qty, int FinId)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			List<int> list = new List<int>();
			list = TPLTree(wono, pid, cid, CompId, FinId);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("AssemblyNo", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("PurchDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("TPLQty", typeof(string));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PId", typeof(int));
			dataTable.Columns.Add("CId", typeof(int));
			dataTable.Columns.Add("WONo", typeof(string));
			dataTable.Columns.Add("UOMPurchase", typeof(string));
			dataTable.Columns.Add("Date", typeof(string));
			dataTable.Columns.Add("Time", typeof(string));
			dataTable.Columns.Add("Id", typeof(string));
			for (int i = 0; i < list.Count; i++)
			{
				string cmdText = select("tblDG_Item_Master.Id,tblDG_TPL_Master.WONo,tblDG_TPL_Master.PId,tblDG_TPL_Master.CId,tblDG_TPL_Master.ItemId,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.PurchDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_TPL_Master.Qty,vw_Unit_Master.Symbol As UOMPurchase,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_TPL_Master.SysDate , CHARINDEX('-',tblDG_TPL_Master.SysDate ) + 1, 2) + '-' + LEFT(tblDG_TPL_Master.SysDate,CHARINDEX('-',tblDG_TPL_Master.SysDate) - 1) + '-' + RIGHT(tblDG_TPL_Master.SysDate, CHARINDEX('-', REVERSE(tblDG_TPL_Master.SysDate)) - 1)), 103), '/', '-') AS  Date ,tblDG_TPL_Master.SysTime As Time", "vw_Unit_Master, tblDG_TPL_Master,tblDG_Category_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId and Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_TPL_Master.ItemId and  tblDG_TPL_Master.Id='" + Convert.ToInt32(list[i]) + "' And tblDG_TPL_Master.CompId='" + CompId + "' AND tblDG_TPL_Master.FinYearId<='" + FinId + "'  AND  vw_Unit_Master.Id=tblDG_Item_Master.UOMPurchase");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = select("tblDG_Item_Master.ItemCode", "tblDG_TPL_Master,tblDG_Item_Master", "tblDG_Item_Master.Id=tblDG_TPL_Master.ItemId AND tblDG_TPL_Master.CId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]) + "'And tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinId + "'");
					DataSet dataSet2 = new DataSet();
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[0] = "NA";
					}
					dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[0]["PurchDesc"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					dataRow[5] = decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
					dataRow[6] = decimal.Parse((qty * TPLRecurQty(dataSet.Tables[0].Rows[0]["WONo"].ToString(), Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]), 1.0, CompId, FinId)).ToString()).ToString("N3");
					dataRow[7] = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[0]["PId"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["CId"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					dataRow[11] = dataSet.Tables[0].Rows[0]["UOMPurchase"].ToString();
					dataRow[12] = dataSet.Tables[0].Rows[0]["Date"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[0]["Time"].ToString();
					dataRow[14] = dataSet.Tables[0].Rows[0]["Id"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void StkAdjLog(int CompId, int FinYearId, string SessionId, int TransType, string TransNo, int ItemId, double Qty)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			string cmdText = select("LogNo", "tblInvQc_StockAdjLog", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by LogNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblInvQc_StockAdjLog");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand(insert("tblInvQc_StockAdjLog", "SysDate,SysTime,CompId,FinYearId,SessionId,LogNo,TransType,TransNo,ItemId,Qty", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + SessionId + "','" + text + "','" + TransType + "','" + TransNo + "','" + ItemId + "','" + Qty + "'"), sqlConnection);
			SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Transaction = sqlTransaction;
			sqlCommand.ExecuteNonQuery();
			sqlTransaction.Commit();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCustIMaster(string tblName, string tblfield, string whr, GridView SearchGridView, string drpvalue, string hfSearchTextValue, string odr)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			dataSet.Clear();
			if (hfSearchTextValue != "")
			{
				string text2 = text;
				text = text2 + " AND " + drpvalue + " ='" + hfSearchTextValue + "'" + odr;
			}
			else
			{
				text += odr;
			}
			SqlCommand selectCommand2 = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet, tblName);
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void BindData(string tblName, string tblfield, string whr, GridView SearchGridView, string hfSearchTextValue, string odr)
	{
		try
		{
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string text = select(tblfield, tblName, whr);
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, tblName);
			dataSet.Clear();
			if (hfSearchTextValue != "")
			{
				string text2 = text;
				text = text2 + "  like '" + hfSearchTextValue + "%'" + odr;
			}
			else
			{
				text += odr;
			}
			SqlCommand selectCommand2 = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet, tblName);
			SearchGridView.DataSource = dataSet;
			SearchGridView.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void getBomnode(int node, string wonosrc, string wonodest, int compid, string sesid, int finyrid, int destpid, int destcid)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			string currDate = getCurrDate();
			string currTime = getCurrTime();
			int num = destcid;
			sqlConnection.Open();
			string cmdText = select("PId,CId,ItemId,Qty", "tblDG_BOM_Master", "CId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid);
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			int bOMCId = getBOMCId(wonodest, compid, finyrid);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty", "'" + currDate.ToString() + "','" + currTime.ToString() + "'," + compid + "," + finyrid + ",'" + sesid.ToString() + "','" + num + "','" + bOMCId + "','" + wonodest + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
			string cmdText3 = select("PId,CId,ItemId,Qty", "tblDG_BOM_Master", "PId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid);
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				int bOMCId2 = getBOMCId(wonodest, compid, finyrid);
				string cmdText4 = insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PId,CId,WONo,ItemId,Qty,Weldments,LH,RH", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + compid + "','" + finyrid + "','" + sesid.ToString() + "','" + bOMCId + "','" + bOMCId2 + "','" + wonodest + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["ItemId"]) + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				string cmdText5 = update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wonodest + "' And  CompId='" + compid + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				DataSet dataSet3 = new DataSet();
				string cmdText6 = select("PId,CId,ItemId,Qty", "tblDG_BOM_Master", string.Concat("WONo='", wonosrc, "'And CompId=", compid, " AND PId='", dataSet2.Tables[0].Rows[i]["CId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
					{
						num = bOMCId2;
						getBomnode(Convert.ToInt32(dataSet3.Tables[0].Rows[j]["CId"]), wonosrc, wonodest, compid, sesid, finyrid, destpid, destcid);
					}
				}
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

	public void filldrp(DropDownList dl, int design, int id)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "SELECT  tblHR_OfficeStaff.UserID,  tblHR_OfficeStaff.EmployeeName FROM tblHR_Designation INNER JOIN tblHR_OfficeStaff ON tblHR_Designation.Id = tblHR_OfficeStaff.Designation WHERE tblHR_OfficeStaff.Designation =tblHR_Designation.Id AND tblHR_OfficeStaff.Designation=" + design + " AND tblHR_OfficeStaff.UserID!=" + id;
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			dl.DataSource = dataSet.Tables[0];
			dl.DataTextField = "EmployeeName";
			dl.DataValueField = "UserID";
			dl.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void depthead(DropDownList dl, int id)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "SELECT  tblHR_OfficeStaff.UserID,  tblHR_OfficeStaff.EmployeeName FROM tblHR_Designation INNER JOIN tblHR_OfficeStaff ON tblHR_Designation.Id = tblHR_OfficeStaff.Designation WHERE tblHR_OfficeStaff.Designation =tblHR_Designation.Id  AND tblHR_OfficeStaff.UserID!=" + id;
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			dl.DataSource = dataSet.Tables[0];
			dl.DataTextField = "EmployeeName";
			dl.DataValueField = "UserID";
			dl.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void filldrpDirector(DropDownList DrpDirectorName, int id)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "SELECT tblHR_OfficeStaff.UserID, tblHR_OfficeStaff.EmployeeName FROM tblHR_Designation INNER JOIN tblHR_OfficeStaff ON tblHR_Designation.Id = tblHR_OfficeStaff.Designation WHERE (tblHR_OfficeStaff.Designation =tblHR_Designation.Id )AND (tblHR_OfficeStaff.Designation='2'OR tblHR_OfficeStaff.Designation='3') AND tblHR_OfficeStaff.UserId!=" + id;
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DrpDirectorName.DataSource = dataSet.Tables[0];
			DrpDirectorName.DataTextField = "EmployeeName";
			DrpDirectorName.DataValueField = "UserID";
			DrpDirectorName.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void filldrp1(DropDownList dl, int design)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "SELECT  tblHR_OfficeStaff.UserID,  tblHR_OfficeStaff.EmployeeName FROM tblHR_Designation INNER JOIN tblHR_OfficeStaff ON tblHR_Designation.Id = tblHR_OfficeStaff.Designation WHERE tblHR_OfficeStaff.Designation =tblHR_Designation.Id AND tblHR_OfficeStaff.Designation=" + design + " ";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			dl.DataSource = dataSet.Tables[0];
			dl.DataTextField = "EmployeeName";
			dl.DataValueField = "UserID";
			dl.DataBind();
			dl.Items.Insert(0, "Not Applicable");
		}
		catch (Exception)
		{
		}
	}

	public void filldrpDirector1(DropDownList DrpDirectorName)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "SELECT tblHR_OfficeStaff.UserID, tblHR_OfficeStaff.EmployeeName FROM tblHR_Designation INNER JOIN tblHR_OfficeStaff ON tblHR_Designation.Id = tblHR_OfficeStaff.Designation WHERE (tblHR_OfficeStaff.Designation =tblHR_Designation.Id )AND (tblHR_OfficeStaff.Designation='2'OR tblHR_OfficeStaff.Designation='3')";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DrpDirectorName.DataSource = dataSet.Tables[0];
			DrpDirectorName.DataTextField = "EmployeeName";
			DrpDirectorName.DataValueField = "UserID";
			DrpDirectorName.DataBind();
			DrpDirectorName.Items.Insert(0, "Not Applicable");
		}
		catch (Exception)
		{
		}
	}

	public List<int> getTPLBOMRootnode(int node, string wonosrc, int compid, string sesid, int finyrid, string tblName)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = 0;
		try
		{
			new DataSet();
			sqlConnection.Open();
			string cmdText = select("PId,CId,ItemId,Qty,Weldments,LH,RH", tblName ?? "", "CId=" + node + "And WONo='" + wonosrc + "'And CompId=" + compid);
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]);
				DataSet dataSet2 = new DataSet();
				string cmdText2 = select("PId,CId,ItemId,Qty,Weldments,LH,RH", tblName ?? "", string.Concat("WONo='", wonosrc, "'And CompId=", compid, " AND CId='", dataSet.Tables[0].Rows[0]["PId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					num = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						getTPLBOMRootnode(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]), wonosrc, compid, sesid, finyrid, tblName);
					}
					RootAssmbly.Add(Convert.ToInt32(num));
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return RootAssmbly;
	}

	public List<int> CalBOMTreeQty(int CompId, string WONo, int Pid, int Cid)
	{
		string connectionString = Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		try
		{
			if (Pid > 0)
			{
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_BOM_PID_CIDWise", selectConnection);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = WONo;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@PId"].Value = Pid;
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				listk.Add(Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]));
				listk.Add(Pid);
				CalBOMTreeQty(CompId, WONo, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Cid);
			}
		}
		catch (Exception)
		{
		}
		return listk;
	}

	public void WIS_Material(string WONo2, string ItemId2, int CompId, int FinYearId, string sId, string CDate, string CTime)
	{
		string connectionString = Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string text = "";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_WISNo", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["WISNo"].ToString()) + 1).ToString("D4"));
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GQN_BOM_Details", sqlConnection);
			sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@WONo"].Value = WONo2;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@ItemId"].Value = ItemId2;
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 1;
			int num4 = 0;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataSet dataSet3 = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetSchTime_Item_Details", sqlConnection);
				sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@Id"].Value = dataSet2.Tables[0].Rows[i][0].ToString();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				double num5 = 1.0;
				List<double> list = new List<double>();
				list = BOMTreeQty(WONo2, Convert.ToInt32(dataSet2.Tables[0].Rows[i][2]), Convert.ToInt32(dataSet2.Tables[0].Rows[i][3]));
				for (int j = 0; j < list.Count; j++)
				{
					num5 *= list[j];
				}
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
				sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@WONo"].Value = WONo2;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@ItemId"].Value = dataSet2.Tables[0].Rows[i]["ItemId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@PId"].Value = dataSet2.Tables[0].Rows[i]["PId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CId"].Value = dataSet2.Tables[0].Rows[i]["CId"].ToString();
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num6 = 0.0;
				if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet4.Tables[0].Rows.Count > 0)
				{
					num6 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				if (num5 >= 0.0)
				{
					num = Convert.ToDouble(decimal.Parse((num5 - num6).ToString()).ToString("N3"));
				}
				if (dataSet2.Tables[0].Rows[i]["PId"].ToString() == "0")
				{
					num2 = num;
				}
				if (dataSet2.Tables[0].Rows[i]["PId"].ToString() != "0")
				{
					List<int> list2 = new List<int>();
					list2 = CalBOMTreeQty(CompId, WONo2, Convert.ToInt32(dataSet2.Tables[0].Rows[i][2]), Convert.ToInt32(dataSet2.Tables[0].Rows[i][3]));
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					List<int> list3 = new List<int>();
					List<int> list4 = new List<int>();
					for (int num10 = list2.Count; num10 > 0; num10--)
					{
						if (list2.Count > 2)
						{
							list4.Add(list2[num10 - 1]);
						}
						else
						{
							list3.Add(list2[num7]);
							num7++;
						}
					}
					double num11 = 1.0;
					for (int k = 0; k < list3.Count; k++)
					{
						num9 = list3[k++];
						num8 = list3[k];
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
						sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@WONo"].Value = WONo2;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
						sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@WONo"].Value = WONo2;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@ItemId"].Value = dataSet5.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						double num12 = 0.0;
						if (dataSet6.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet6.Tables[0].Rows.Count > 0)
						{
							num12 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						num11 = num11 * Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num12;
					}
					for (int l = 0; l < list4.Count; l++)
					{
						num8 = list4[l++];
						num9 = list4[l];
						double num13 = 1.0;
						List<double> list5 = new List<double>();
						list5 = BOMTreeQty(WONo2, num9, num8);
						for (int m = 0; m < list5.Count; m++)
						{
							num13 *= list5[m];
						}
						list5.Clear();
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
						sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@WONo"].Value = WONo2;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7, "tblDG_BOM_Master");
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
						sqlDataAdapter8.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@WONo"].Value = WONo2;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@ItemId"].Value = dataSet7.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						double num14 = 0.0;
						if (dataSet8.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet8.Tables[0].Rows.Count > 0)
						{
							num14 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						if (num13 >= 0.0)
						{
							num11 = num11 * Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num14;
						}
					}
					num2 = ((!(num11 > 0.0)) ? 0.0 : Convert.ToDouble(decimal.Parse((num11 * Convert.ToDouble(dataSet2.Tables[0].Rows[i][4]) - num6).ToString()).ToString("N3")));
					double num15 = 0.0;
					double num16 = 0.0;
					if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) >= 0.0)
					{
						if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")))
						{
							num15 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
							num16 = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
						}
						else if (Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
						{
							num15 = 0.0;
							num16 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
						}
					}
					if (num16 > 0.0)
					{
						if (num3 == 1)
						{
							string cmdText = insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + WONo2 + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							string cmdText2 = select1("Id", "tblInv_WIS_Master Order By Id Desc");
							SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9, "tblDG_Item_Master");
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								num4 = Convert.ToInt32(dataSet9.Tables[0].Rows[0][0]);
								num3 = 0;
							}
						}
						string cmdText3 = insert("tblInv_WIS_Details", "WISNo,PId,CId,ItemId,IssuedQty,MId", string.Concat("'", text, "','", dataSet2.Tables[0].Rows[i][2], "','", dataSet2.Tables[0].Rows[i][3], "','", dataSet2.Tables[0].Rows[i]["ItemId"].ToString(), "','", num16.ToString(), "','", num4, "'"));
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand2.ExecuteNonQuery();
						string cmdText4 = update("tblDG_Item_Master", "StockQty='" + num15 + "'", "CompId='" + CompId + "' AND Id='" + dataSet2.Tables[0].Rows[i]["ItemId"].ToString() + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
					}
					num11 = 0.0;
					list2.Clear();
				}
				list.Clear();
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
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

public class TotalTdsDeduct
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	public TotalTdsDeduct()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public double Check_TDSAmt(int CompId, int FinYearId, string GetSupCode)
	{
		double num = 0.0;
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			string empty = string.Empty;
			empty = "select (Case When GQNId !=0 then (Select Sum(tblQc_MaterialQuality_Details.AcceptedQty) from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) +PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.TDSCode,tblACC_BillBooking_Master.Id as PVEVId from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "' And tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId='" + FinYearId + "'  And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId";
			SqlCommand sqlCommand = new SqlCommand(empty, con);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			dataTable.Load(reader);
			var enumerable = from x in dataTable.AsEnumerable()
				group x by new
				{
					y = x.Field<int>("PVEVId")
				} into grp
				let row1 = grp.First()
				select new
				{
					Discount = row1.Field<double>("Discount"),
					DiscountType = row1.Field<int>("DiscountType"),
					DebitAmt = row1.Field<double>("DebitAmt"),
					OtherCharges = row1.Field<double>("OtherCharges"),
					TotalBookedBill = grp.Sum((DataRow r) => r.Field<double?>("TotalBookedBill")),
					TDSCode = row1.Field<int>("TDSCode")
				};
			double num2 = 0.0;
			string cmdText = fun.select("PanNo", "tblMM_Supplier_master", "SupplierId='" + GetSupCode + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
			sqlDataReader.Read();
			Regex regex = new Regex("^[a-zA-Z0-9 ]*$");
			foreach (var item in enumerable)
			{
				double num3 = 0.0;
				double num4 = 0.0;
				num3 = Convert.ToDouble(item.TotalBookedBill) + item.OtherCharges;
				if (item.DiscountType == 0)
				{
					num3 -= item.Discount;
				}
				else if (item.DiscountType == 1)
				{
					num3 -= num3 * item.Discount / 100.0;
				}
				num4 = num3 - item.DebitAmt;
				num2 += num4;
				string cmdText2 = fun.select("PaymentRange,Others,WithOutPAN", "tblACC_TDSCode_Master", "Id='" + item.TDSCode + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2.HasRows && num2 >= Convert.ToDouble(sqlDataReader2["PaymentRange"]))
				{
					int num5 = 0;
					num5 = ((!regex.IsMatch(sqlDataReader["PANNo"].ToString())) ? Convert.ToInt32(sqlDataReader2["WithOutPAN"]) : Convert.ToInt32(sqlDataReader2["Others"]));
					num += num4 * (double)num5 / 100.0;
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
		return Math.Round(num, 2);
	}
}

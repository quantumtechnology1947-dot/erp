using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Accounts_Transactions_CreditorsDebitors_InDetailView : Page, IRequiresSessionState
{
	protected HtmlHead Head1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private ReportDocument cryRpt = new ReportDocument();

	private int CompId;

	private int FinYearId;

	private string SId = string.Empty;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string connStr = string.Empty;

	private string SupId = string.Empty;

	private string Key = string.Empty;

	private string DTFrm = string.Empty;

	private string DTTo = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			SupId = Session["SupId"].ToString();
			Key = Session["Key"].ToString();
			DTFrm = Session["DtFrm"].ToString();
			DTTo = Session["DtTo"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				FillReport(SupId, DTFrm, DTTo);
				return;
			}
			ReportDocument reportSource = (ReportDocument)Session[Key];
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void FillReport(string SupplierId, string FromDate, string ToDate)
	{
		try
		{
			string cmdText = fun.select("OpeningAmt", "tblACC_Creditors_Master", "SupplierId='" + SupId + "' And CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			double num = 0.0;
			if (sqlDataReader.HasRows)
			{
				num = Math.Round(Convert.ToDouble(sqlDataReader["OpeningAmt"]), 2);
			}
			double num2 = 0.0;
			if (DTFrm != "")
			{
				string empty = string.Empty;
				empty = fun.select("(Case When GQNId !=0 then (Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End)+PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.PVEVNo", " tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master", "tblACC_BillBooking_Master.CompId='" + CompId + "' AND tblACC_BillBooking_Master.SupplierId='" + SupId + "' AND tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' AND tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblACC_BillBooking_Master.SysDate < '" + DTFrm + "'");
				SqlCommand sqlCommand2 = new SqlCommand(empty, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("PVEVId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DiscountType", typeof(int)));
				dataTable.Columns.Add(new DataColumn("DebitAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TotalBookedBill", typeof(double)));
				while (sqlDataReader2.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(sqlDataReader2["PVEVId"]);
					dataRow[1] = Convert.ToDouble(sqlDataReader2["Discount"]);
					dataRow[2] = Convert.ToInt32(sqlDataReader2["DiscountType"]);
					dataRow[3] = Convert.ToDouble(sqlDataReader2["DebitAmt"]);
					dataRow[4] = Convert.ToDouble(sqlDataReader2["OtherCharges"]);
					dataRow[5] = Convert.ToDouble(sqlDataReader2["TotalBookedBill"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				var enumerable = from x2 in dataTable.AsEnumerable()
					group x2 by new
					{
						y2 = x2.Field<int>("PVEVId")
					} into grp2
					let row2 = grp2.First()
					select new
					{
						PVEVId = row2.Field<int>("PVEVId"),
						Discount = row2.Field<double>("Discount"),
						DiscountType = row2.Field<int>("DiscountType"),
						DebitAmt = row2.Field<double>("DebitAmt"),
						OtherCharges = row2.Field<double>("OtherCharges"),
						TotalBookedBill = grp2.Sum((DataRow r2) => r2.Field<double>("TotalBookedBill"))
					};
				foreach (var item in enumerable)
				{
					double num3 = 0.0;
					num3 = item.TotalBookedBill + item.OtherCharges;
					if (item.DiscountType == 0)
					{
						num3 -= item.Discount;
					}
					else if (item.DiscountType == 1)
					{
						num3 -= num3 * item.Discount / 100.0;
					}
					num3 -= item.DebitAmt;
					num2 += num3;
				}
			}
			string text = string.Empty;
			string text2 = string.Empty;
			if (FromDate != "" && ToDate != "" && Convert.ToDateTime(FromDate) <= Convert.ToDateTime(ToDate))
			{
				text = " AND tblACC_BillBooking_Master.SysDate Between '" + FromDate + "' AND '" + ToDate + "'";
				text2 = " AND tblACC_BankVoucher_Payment_Master.SysDate Between '" + FromDate + "' AND '" + ToDate + "'";
			}
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("PVEVId", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("DiscountType", typeof(int)));
			dataTable2.Columns.Add(new DataColumn("DebitAmt", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("TotalBookedBill", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("DTSort", typeof(DateTime)));
			string empty2 = string.Empty;
			empty2 = fun.select("(Case When GQNId !=0 then (Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End)+PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.PVEVNo", " tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master", "tblACC_BillBooking_Master.CompId='" + CompId + "' AND tblACC_BillBooking_Master.SupplierId='" + SupId + "' AND tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' AND tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId " + text + ";");
			SqlCommand sqlCommand3 = new SqlCommand(empty2, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			while (sqlDataReader3.Read())
			{
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow2[0] = fun.FromDateDMY(sqlDataReader3["SysDate"].ToString());
				dataRow2[1] = Convert.ToInt32(sqlDataReader3["PVEVId"]);
				dataRow2[2] = Convert.ToDouble(sqlDataReader3["Discount"]);
				dataRow2[3] = Convert.ToInt32(sqlDataReader3["DiscountType"]);
				dataRow2[4] = Convert.ToDouble(sqlDataReader3["DebitAmt"]);
				dataRow2[5] = Convert.ToDouble(sqlDataReader3["OtherCharges"]);
				dataRow2[6] = Convert.ToDouble(sqlDataReader3["TotalBookedBill"]);
				dataRow2[7] = sqlDataReader3["PVEVNo"].ToString();
				dataRow2[8] = Convert.ToDateTime(sqlDataReader3["SysDate"].ToString());
				dataTable2.Rows.Add(dataRow2);
				dataTable2.AcceptChanges();
			}
			var enumerable2 = from x in dataTable2.AsEnumerable()
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
			DataTable dataTable3 = new DataTable();
			dataTable3.Columns.Add(new DataColumn("VchDate", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable3.Columns.Add(new DataColumn("VchNo", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("VchType", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("Credit", typeof(double)));
			dataTable3.Columns.Add(new DataColumn("Debit", typeof(double)));
			dataTable3.Columns.Add(new DataColumn("OtherCharges", typeof(double)));
			dataTable3.Columns.Add(new DataColumn("VchLinkData", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("DTSort", typeof(DateTime)));
			foreach (var item2 in enumerable2)
			{
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow3[0] = item2.SysDate;
				dataRow3[1] = CompId;
				dataRow3[2] = item2.PVEVNo;
				dataRow3[3] = "Purchase";
				dataRow3[4] = "";
				double num4 = 0.0;
				num4 = item2.TotalBookedBill + item2.OtherCharges;
				if (item2.DiscountType == 0)
				{
					num4 -= item2.Discount;
				}
				else if (item2.DiscountType == 1)
				{
					num4 -= num4 * item2.Discount / 100.0;
				}
				num4 -= item2.DebitAmt;
				dataRow3[5] = num4;
				dataRow3[6] = 0;
				dataRow3[8] = "BillBooking_Print_Details.aspx?Id=" + item2.PVEVId + "&Key=" + Key + "&f=3&ModId=11&SubModId=62&SupId=" + SupId;
				dataRow3[9] = Convert.ToDateTime(fun.FromDateDMY(item2.SysDate));
				dataTable3.Rows.Add(dataRow3);
				dataTable3.AcceptChanges();
			}
			string cmdText2 = fun.select("*", " tblACC_BankVoucher_Payment_Master ", " CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND PayTo='" + SupId + "'" + text2);
			SqlCommand sqlCommand4 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
			while (sqlDataReader4.Read())
			{
				double num5 = 0.0;
				string cmdText3 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + sqlDataReader4["Id"].ToString() + "'";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				if (sqlDataReader5.HasRows && sqlDataReader5["Amt"] != DBNull.Value)
				{
					num5 = Convert.ToDouble(decimal.Parse(sqlDataReader5["Amt"].ToString()).ToString("N3"));
				}
				double num6 = 0.0;
				num6 = Convert.ToDouble(sqlDataReader4["PayAmt"]);
				DataRow dataRow4 = dataTable3.NewRow();
				dataRow4[0] = fun.FromDateDMY(sqlDataReader4["SysDate"].ToString());
				dataRow4[1] = CompId;
				dataRow4[2] = sqlDataReader4["BVPNo"].ToString();
				dataRow4[3] = "Payment";
				dataRow4[4] = "";
				dataRow4[5] = 0;
				dataRow4[6] = Math.Round(num5 + num6, 2);
				dataRow4[8] = "BankVoucher_Advice_print.aspx?Id=" + sqlDataReader4["Id"].ToString() + "&ModId=11&SubModId=114&Key=" + Key + "&SupId=" + SupId + "&getKey=1";
				dataRow4[9] = Convert.ToDateTime(sqlDataReader4["SysDate"].ToString());
				dataTable3.Rows.Add(dataRow4);
				dataTable3.AcceptChanges();
			}
			dataTable3.DefaultView.Sort = "DTSort,VchNo ASC";
			dataTable3 = dataTable3.DefaultView.ToTable();
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(dataTable3);
			dataSet.AcceptChanges();
			DataSet dataSet2 = new CrDrDetails();
			dataSet2.Tables[0].Merge(dataSet.Tables[0]);
			dataSet2.AcceptChanges();
			cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/CreditorsDebitors_InDetailList.rpt"));
			cryRpt.SetDataSource(dataSet2);
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			empty4 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupId + "'");
			SqlCommand sqlCommand6 = new SqlCommand(empty4, con);
			SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
			sqlDataReader6.Read();
			empty3 = sqlDataReader6["SupplierName"].ToString() + " [" + SupId + "]";
			cryRpt.SetParameterValue("SupplierName", (object)empty3);
			string cmdText4 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
			SqlCommand sqlCommand7 = new SqlCommand(cmdText4, con);
			SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
			sqlDataReader7.Read();
			string empty5 = string.Empty;
			empty5 = sqlDataReader7["RegdAddress"].ToString() + "," + fun.getCity(Convert.ToInt32(sqlDataReader7["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(sqlDataReader7["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(sqlDataReader7["RegdCountry"]), 1) + "PIN No.-" + sqlDataReader7["RegdPinCode"].ToString() + ".\nPh No.-" + sqlDataReader7["RegdContactNo"].ToString() + ",  Fax No.-" + sqlDataReader7["RegdFaxNo"].ToString() + ",Email No.-" + sqlDataReader7["RegdEmail"].ToString();
			cryRpt.SetParameterValue("Address", (object)empty5);
			cryRpt.SetParameterValue("OpBal", (object)(num + num2));
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
			Session[Key] = cryRpt;
		}
		catch (Exception)
		{
		}
	}

	protected void CrystalReportViewer1_Load(object sender, EventArgs e)
	{
	}

	protected void CrystalReportViewer1_Init(object sender, EventArgs e)
	{
	}
}

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

public class Module_Accounts_Transactions_CreditorsDebitors_SundryCreditors_InDetailView : Page, IRequiresSessionState
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

	private string GetCategory = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
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
			GetCategory = base.Request.QueryString["lnkFor"];
			if (!base.IsPostBack)
			{
				FillReport(CompId, FinYearId, SupId, DTFrm, DTTo, GetCategory);
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

	public void FillReport(int CompId, int FinYearId, string SupplierId, string FromDate, string ToDate, string Category)
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
			string text = string.Empty;
			if (SupplierId != string.Empty)
			{
				text = " And tblACC_BillBooking_Master.SupplierId='" + SupplierId + "'";
			}
			double num2 = 0.0;
			if (DTFrm != "")
			{
				string empty = string.Empty;
				empty = "select (Case When GQNId !=0 then (Case when tblMM_PO_Details.PRId Is not null then(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_PR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_SPR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) Else (Case when tblMM_PO_Details.PRId Is not null then(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_PR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_SPR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) End)+PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.PVEVNo from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "'" + text + " And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' AND tblACC_BillBooking_Master.SysDate < '" + DTFrm + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId";
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
					if (sqlDataReader2["TotalBookedBill"] != DBNull.Value)
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
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (FromDate != "" && ToDate != "" && Convert.ToDateTime(FromDate) <= Convert.ToDateTime(ToDate))
			{
				text2 = " AND tblACC_BillBooking_Master.SysDate Between '" + FromDate + "' AND '" + ToDate + "'";
				text3 = " AND tblACC_BankVoucher_Payment_Master.SysDate Between '" + FromDate + "' AND '" + ToDate + "'";
				text4 = " AND tblACC_CashVoucher_Payment_Master.SysDate Between '" + FromDate + "' AND '" + ToDate + "'";
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
			dataTable2.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("Perticulars", typeof(string)));
			string empty2 = string.Empty;
			empty2 = "select (Case When GQNId !=0 then (Case when tblMM_PO_Details.PRId Is not null then(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_PR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblQc_MaterialQuality_Details.AcceptedQty from tblQc_MaterialQuality_Details,tblMM_SPR_Details,AccHead where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId  AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) Else (Case when tblMM_PO_Details.PRId Is not null then(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_PR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.PRId=tblMM_PR_Details.Id AND tblMM_PR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)else(Select tblinv_MaterialServiceNote_Details.ReceivedQty As AcceptedQty from tblinv_MaterialServiceNote_Details,tblMM_SPR_Details,AccHead where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId AND tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id AND tblMM_SPR_Details.AHId=AccHead.Id And AccHead.Category='" + Category + "')*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) End)+PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.Id as PVEVId,tblACC_BillBooking_Master.PVEVNo,tblACC_BillBooking_Master.BillDate,tblACC_BillBooking_Master.BillNo,tblMM_PO_Details.VAT AS Perticulars from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "'" + text + " And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId " + text2;
			SqlCommand sqlCommand3 = new SqlCommand(empty2, con);
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			while (sqlDataReader3.Read())
			{
				if (sqlDataReader3["TotalBookedBill"] != DBNull.Value)
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
					dataRow2[9] = sqlDataReader3["BillNo"].ToString();
					dataRow2[10] = fun.FromDate(sqlDataReader3["BillDate"].ToString());
					dataRow2[11] = sqlDataReader3["Perticulars"].ToString();
					dataTable2.Rows.Add(dataRow2);
					dataTable2.AcceptChanges();
				}
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
					DTSort = row1.Field<DateTime>("DTSort"),
					BillNo = row1.Field<string>("BillNo"),
					BillDate = row1.Field<string>("BillDate"),
					Perticulars = row1.Field<string>("Perticulars")
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
			dataTable3.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable3.Columns.Add(new DataColumn("Perticulars", typeof(string)));
			foreach (var item2 in enumerable2)
			{
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow3[0] = item2.SysDate;
				dataRow3[1] = CompId;
				dataRow3[2] = item2.PVEVNo;
				dataRow3[3] = "Purchase";
				string cmdText2 = fun.select("Terms", "tblVAT_Master", "Id='" + item2.Perticulars + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				dataRow3[4] = sqlDataReader4["Terms"].ToString();
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
				dataRow3[8] = "BillBooking_Print_Details.aspx?Id=" + item2.PVEVId + "&Key=" + Key + "&f=4&ModId=11&SubModId=62&SupId=" + SupId + "&lnkFor=" + GetCategory;
				dataRow3[9] = Convert.ToDateTime(fun.FromDateDMY(item2.SysDate));
				dataRow3[10] = item2.BillNo;
				dataRow3[11] = item2.BillDate;
				dataTable3.Rows.Add(dataRow3);
				dataTable3.AcceptChanges();
			}
			string cmdText3 = "SELECT Sum(tblACC_BankVoucher_Payment_Details.Amount+tblACC_BankVoucher_Payment_Master.PayAmt) as Amt,tblACC_BankVoucher_Payment_Master.SysDate,tblACC_BankVoucher_Payment_Master.BVPNo,tblACC_BankVoucher_Payment_Master.Id,tblACC_BankVoucher_Payment_Master.Bank,tblACC_BankVoucher_Payment_Master.ChequeNo,tblACC_BankVoucher_Payment_Master.ChequeDate FROM tblACC_BillBooking_Master INNER JOIN tblACC_BillBooking_Details ON tblACC_BillBooking_Master.Id = tblACC_BillBooking_Details.MId INNER JOIN tblACC_BankVoucher_Payment_Master INNER JOIN tblACC_BankVoucher_Payment_Details ON tblACC_BankVoucher_Payment_Master.Id = tblACC_BankVoucher_Payment_Details.MId ON tblACC_BillBooking_Master.Id = tblACC_BankVoucher_Payment_Details.PVEVNO INNER JOIN AccHead ON tblACC_BillBooking_Master.AHId = AccHead.Id  AND tblACC_BillBooking_Master.AHId !=0 AND AccHead.Category='" + Category + "' AND tblACC_BankVoucher_Payment_Master.PayTo='" + SupId + "' AND tblACC_BankVoucher_Payment_Master.CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Master.FinYearId<='" + FinYearId + "'" + text3 + " AND tblACC_BankVoucher_Payment_Master.Type='4' Group by tblACC_BankVoucher_Payment_Master.Id,tblACC_BankVoucher_Payment_Master.SysDate,tblACC_BankVoucher_Payment_Master.BVPNo,tblACC_BankVoucher_Payment_Master.ChequeNo,tblACC_BankVoucher_Payment_Master.ChequeDate,tblACC_BankVoucher_Payment_Master.Bank";
			SqlCommand sqlCommand5 = new SqlCommand(cmdText3, con);
			SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
			while (sqlDataReader5.Read())
			{
				double num5 = 0.0;
				num5 = Convert.ToDouble(decimal.Parse(sqlDataReader5["Amt"].ToString()).ToString("N3"));
				DataRow dataRow4 = dataTable3.NewRow();
				dataRow4[0] = fun.FromDateDMY(sqlDataReader5["SysDate"].ToString());
				dataRow4[1] = CompId;
				dataRow4[2] = sqlDataReader5["BVPNo"].ToString();
				dataRow4[3] = "Payment";
				string cmdText4 = fun.select("Name", "tblACC_Bank", "Id='" + sqlDataReader5["Bank"].ToString() + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				dataRow4[4] = sqlDataReader6["Name"].ToString() + ", Chq. No- " + sqlDataReader5["ChequeNo"].ToString() + ", Chq. Dt- " + fun.FromDateDMY(sqlDataReader5["ChequeDate"].ToString());
				dataRow4[6] = Math.Round(num5, 2);
				dataRow4[8] = "BankVoucher_Advice_print.aspx?Id=" + sqlDataReader5["Id"].ToString() + "&ModId=11&SubModId=114&Key=" + Key + "&SupId=" + SupId + "&getKey=2&lnkFor=" + GetCategory;
				dataRow4[9] = Convert.ToDateTime(sqlDataReader5["SysDate"].ToString());
				dataTable3.Rows.Add(dataRow4);
				dataTable3.AcceptChanges();
			}
			string text5 = string.Empty;
			string text6 = string.Empty;
			if (Category != "")
			{
				text5 = " AND AccHead.Category='" + Category + "'";
			}
			if (SupId != "")
			{
				text6 = " AND tblACC_CashVoucher_Payment_Master.ReceivedBy='" + SupId + "'";
			}
			string cmdText5 = "SELECT tblACC_CashVoucher_Payment_Details.Particulars,tblACC_CashVoucher_Payment_Master.CVPNo,tblACC_CashVoucher_Payment_Master.SysDate,Sum(tblACC_CashVoucher_Payment_Details.Amount) As Sum_Amt FROM tblACC_CashVoucher_Payment_Details INNER JOIN tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id INNER JOIN AccHead ON tblACC_CashVoucher_Payment_Details.AcHead = AccHead.Id AND tblACC_CashVoucher_Payment_Details.AcHead !=0 " + text5 + text6 + " AND tblACC_CashVoucher_Payment_Master.CompId='" + CompId + "' " + text4 + " AND tblACC_CashVoucher_Payment_Master.FinYearId<='" + FinYearId + "' INNER JOIN tblMM_Supplier_master ON tblACC_CashVoucher_Payment_Master.ReceivedBy = tblMM_Supplier_master.SupplierId Group by tblACC_CashVoucher_Payment_Master.CVPNo,tblACC_CashVoucher_Payment_Master.SysDate,tblACC_CashVoucher_Payment_Details.Particulars";
			SqlCommand sqlCommand7 = new SqlCommand(cmdText5, con);
			SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
			while (sqlDataReader7.Read())
			{
				DataRow dataRow5 = dataTable3.NewRow();
				double num6 = 0.0;
				num6 = Math.Round(Convert.ToDouble(sqlDataReader7["Sum_Amt"].ToString()), 2);
				dataRow5[0] = fun.FromDateDMY(sqlDataReader7["SysDate"].ToString());
				dataRow5[1] = CompId;
				dataRow5[2] = sqlDataReader7["CVPNo"].ToString();
				dataRow5[3] = "Cash Payment";
				dataRow5[4] = sqlDataReader7["Particulars"].ToString();
				dataRow5[6] = Math.Round(num6, 2);
				dataRow5[9] = Convert.ToDateTime(sqlDataReader7["SysDate"].ToString());
				dataTable3.Rows.Add(dataRow5);
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
			cryRpt.Load(base.Server.MapPath("~/Module/Accounts/Reports/SundryCreditors_InDetailList.rpt"));
			cryRpt.SetDataSource(dataSet2);
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			empty4 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupId + "'");
			SqlCommand sqlCommand8 = new SqlCommand(empty4, con);
			SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
			sqlDataReader8.Read();
			empty3 = sqlDataReader8["SupplierName"].ToString() + " [" + SupId + "]";
			cryRpt.SetParameterValue("SupplierName", (object)empty3);
			string cmdText6 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
			SqlCommand sqlCommand9 = new SqlCommand(cmdText6, con);
			SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
			sqlDataReader9.Read();
			string empty5 = string.Empty;
			empty5 = sqlDataReader9["RegdAddress"].ToString() + "," + fun.getCity(Convert.ToInt32(sqlDataReader9["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(sqlDataReader9["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(sqlDataReader9["RegdCountry"]), 1) + "PIN No.-" + sqlDataReader9["RegdPinCode"].ToString() + ".\nPh No.-" + sqlDataReader9["RegdContactNo"].ToString() + ",  Fax No.-" + sqlDataReader9["RegdFaxNo"].ToString() + ",Email No.-" + sqlDataReader9["RegdEmail"].ToString();
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_HR_Transactions_Salary_SAPL_Neha_Summary : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int CompId;

	private int FinYearId;

	private int MonthId;

	private int EType;

	private int BGGroupId;

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_2640: Unknown result type (might be due to invalid IL or missing references)
		//IL_2647: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				BGGroupId = Convert.ToInt32(base.Request.QueryString["BGGroupId"]);
				MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				if (!string.IsNullOrEmpty(base.Request.QueryString["EType"]))
				{
					EType = Convert.ToInt32(base.Request.QueryString["EType"]);
				}
				int year = fun.SalYrs(FinYearId, MonthId, CompId);
				dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Month", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Year", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Grade", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Basic", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DA", typeof(double)));
				dataTable.Columns.Add(new DataColumn("HRA", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Conveyance", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Education", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Medical", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SundayP", typeof(double)));
				dataTable.Columns.Add(new DataColumn("GrossTotal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AttendanceBonus", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SpecialAllowance", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ExGratia", typeof(double)));
				dataTable.Columns.Add(new DataColumn("TravellingAllowance", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Miscellaneous", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
				dataTable.Columns.Add(new DataColumn("NetPay", typeof(double)));
				dataTable.Columns.Add(new DataColumn("WorkingDays", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PreasentDays", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AbsentDays", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Sunday", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Holiday", typeof(double)));
				dataTable.Columns.Add(new DataColumn("LateIn", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Coff", typeof(double)));
				dataTable.Columns.Add(new DataColumn("HalfDays", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PL", typeof(double)));
				dataTable.Columns.Add(new DataColumn("LWP", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFofEmployee", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PTax\u200e", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PersonalLoanInstall\u200e", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MobileBill", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Miscellaneous2", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Total2", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EmpACNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BasicCal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("DACal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("HRACal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ConveyanceCal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("EducationCal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("MedicalCal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("GrossTotalCal", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AttBonusType", typeof(double)));
				dataTable.Columns.Add(new DataColumn("AttBonusAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("PFNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PANNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Path", typeof(string)));
				sqlConnection.Open();
				string empty = string.Empty;
				empty = ((BGGroupId != 1) ? fun.select("tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.FMonth ='" + MonthId + "'AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "' AND tblHR_OfficeStaff.BGGroup ='" + BGGroupId + "' ") : fun.select("tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.FMonth ='" + MonthId + "'AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "' "));
				SqlCommand selectCommand = new SqlCommand(empty, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string value = "";
					string value2 = "";
					string value3 = "";
					string value4 = "";
					double num = 0.0;
					num = DateTime.DaysInMonth(FinYearId, MonthId);
					dataRow[0] = dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString();
					dataRow[1] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					dataRow[2] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString();
					string cmdText = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3, "Financial");
					string text = "";
					string text2 = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					string[] array = text2.Split('-');
					string text3 = array[0];
					string text4 = array[1];
					text = ((MonthId != 1 && MonthId != 2 && (MonthId != 3 || MonthId == 0)) ? text3 : text4);
					dataRow[3] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthId);
					dataRow[4] = text;
					string cmdText2 = fun.select("Symbol AS Dept", "tblHR_Departments", "Id='" + dataSet2.Tables[0].Rows[i]["Department"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4, "tblHR_Departments");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value = dataSet4.Tables[0].Rows[0]["Dept"].ToString();
					}
					string cmdText3 = fun.select("Type+' [ '+Symbol+' ]' AS Designation", "tblHR_Designation", "Id='" + dataSet2.Tables[0].Rows[i]["Designation"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter4.Fill(dataSet5, "tblHR_Designation");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet5.Tables[0].Rows[0]["Designation"].ToString();
					}
					string cmdText4 = fun.select("Symbol AS Grade", "tblHR_Grade", "Id='" + dataSet2.Tables[0].Rows[i]["Grade"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6, "tblHR_Grade");
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						value4 = dataSet6.Tables[0].Rows[0]["Grade"].ToString();
					}
					dataRow[5] = value;
					dataRow[6] = value2;
					dataRow[8] = value4;
					dataRow[51] = dataSet2.Tables[0].Rows[i]["PFNo"];
					dataRow[52] = dataSet2.Tables[0].Rows[i]["PANNo"];
					int num2 = 0;
					string cmdText5 = fun.select("Increment", "tblHR_Offer_Master", "OfferId ='" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						num2 = Convert.ToInt32(dataSet7.Tables[0].Rows[0]["Increment"]);
					}
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					dataRow[53] = "/erp/Module/HR/Transactions/OfferLetter_Print_Details.aspx?OfferId=" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "&T=2&Key=" + randomAlphaNumeric + "&Key1=" + Key + "&EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Increment=" + num2 + "&ModId=12&SubModId=25";
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					string cmdText6 = fun.select("Increment", "tblHR_Salary_Master", "EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' AND FMonth='" + MonthId + "' AND FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter7.Fill(dataSet8, "tblHR_Salary_Master");
					string cmdText7 = fun.select("Increment", "tblHR_Offer_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter8.Fill(dataSet9);
					string empty2 = string.Empty;
					empty2 = ((Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Increment"])) ? fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,Id", "tblHR_Increment_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "' AND Increment='" + dataSet8.Tables[0].Rows[0]["Increment"].ToString() + "'") : fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'"));
					SqlCommand selectCommand9 = new SqlCommand(empty2, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter9.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						num9 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["Salary"]);
						num3 = fun.Offer_Cal(num9, 1, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["StaffType"]));
						num4 = fun.Offer_Cal(num9, 2, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num5 = fun.Offer_Cal(num9, 3, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num6 = fun.Offer_Cal(num9, 4, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num7 = fun.Offer_Cal(num9, 5, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num8 = fun.Offer_Cal(num9, 6, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						dataRow[9] = num3;
						dataRow[10] = num4;
						dataRow[11] = num5;
						dataRow[12] = num6;
						dataRow[13] = num7;
						dataRow[14] = num8;
						dataRow[16] = num9.ToString();
						string cmdText8 = fun.select("Description", "tblHR_EmpType", "Id='" + dataSet10.Tables[0].Rows[0]["StaffType"].ToString() + "'");
						SqlCommand selectCommand10 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
						DataSet dataSet11 = new DataSet();
						sqlDataAdapter10.Fill(dataSet11, "tblHR_EmpType");
						if (dataSet11.Tables[0].Rows.Count > 0)
						{
							if (Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]) == 1)
							{
								value3 = "SAPL - " + dataSet11.Tables[0].Rows[0]["Description"].ToString();
							}
							else if (Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]) == 2)
							{
								value3 = "NEHA - " + dataSet11.Tables[0].Rows[0]["Description"].ToString();
							}
						}
						dataRow[7] = value3;
						double num11 = 0.0;
						double num12 = 0.0;
						double num13 = 0.0;
						double num14 = 0.0;
						double num15 = 0.0;
						double num16 = 0.0;
						double num17 = 0.0;
						double num18 = 0.0;
						double num19 = 0.0;
						double num20 = 0.0;
						double num21 = 0.0;
						double num22 = 0.0;
						double num23 = 0.0;
						double num24 = 0.0;
						double num25 = 0.0;
						double num26 = 0.0;
						double num27 = 0.0;
						double num28 = 0.0;
						double num29 = 0.0;
						int num30 = 0;
						double num31 = 0.0;
						double num32 = 0.0;
						double num33 = 0.0;
						double num34 = 0.0;
						double num35 = 0.0;
						double num36 = 0.0;
						double num37 = 0.0;
						double num38 = 0.0;
						double num39 = 0.0;
						double num40 = 0.0;
						double num41 = 0.0;
						double num42 = 0.0;
						double num43 = 0.0;
						double num44 = 0.0;
						double num45 = 0.0;
						double num46 = 0.0;
						double num47 = 0.0;
						double num48 = 0.0;
						double num49 = 0.0;
						double num50 = 0.0;
						string cmdText9 = fun.select("tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Remarks1,tblHR_Salary_Details.Deduction,tblHR_Salary_Details.Remarks2", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' AND tblHR_Salary_Master.FMonth='" + MonthId + "'");
						SqlCommand selectCommand11 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
						DataSet dataSet12 = new DataSet();
						sqlDataAdapter11.Fill(dataSet12);
						if (dataSet12.Tables[0].Rows.Count > 0)
						{
							num40 = fun.WorkingDays(FinYearId, MonthId);
							num14 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							num15 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							num16 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							num17 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							num18 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							num19 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							num20 = fun.CountSundays(year, MonthId);
							num21 = fun.GetHoliday(MonthId, CompId, FinYearId);
							num32 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer1"]);
							num33 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer2"]);
							num34 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["ExGratia"]);
							num44 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["VehicleAllowance"]);
							num45 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Addition"]);
							num46 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Deduction"]);
							num11 = num - (num15 - (num16 + num17));
							num12 = num14 + num19 + num18;
							num13 = num - num11;
							num22 = Math.Round(num3 * num11 / num);
							num23 = Math.Round(num4 * num11 / num);
							num24 = Math.Round(num5 * num11 / num);
							num25 = Math.Round(num6 * num11 / num);
							num26 = Math.Round(num7 * num11 / num);
							num27 = Math.Round(num8 * num11 / num);
							num28 = Math.Round(num22 + num23 + num24 + num25 + num26 + num27);
							num10 = fun.Pf_Cal(num28, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["PFEmployee"]));
							num29 = num10;
							num35 = Math.Round(num34 * num11 / num);
							num49 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Installment"]);
							num50 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["MobileExeAmt"]);
							string empty3 = string.Empty;
							empty3 = ((Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Increment"])) ? fun.select("Qty,Amount,IncludesIn", "tblHR_Increment_Accessories", "MId='" + dataSet10.Tables[0].Rows[0]["Id"].ToString() + "'") : fun.select("Qty,Amount,IncludesIn", "tblHR_Offer_Accessories", "MId='" + dataSet10.Tables[0].Rows[0]["OfferId"].ToString() + "'"));
							SqlCommand selectCommand12 = new SqlCommand(empty3, sqlConnection);
							SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
							DataSet dataSet13 = new DataSet();
							sqlDataAdapter12.Fill(dataSet13);
							for (int j = 0; j < dataSet13.Tables[0].Rows.Count; j++)
							{
								switch (dataSet13.Tables[0].Rows[j]["IncludesIn"].ToString())
								{
								case "1":
									num42 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "2":
									num41 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "3":
									num43 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								}
							}
							if (dataSet10.Tables[0].Rows[0]["OverTime"].ToString() == "2")
							{
								double num51 = 0.0;
								string cmdText10 = fun.select("Hours", "tblHR_OTHour", "Id='" + dataSet10.Tables[0].Rows[0]["OTHrs"].ToString() + "'");
								SqlCommand selectCommand13 = new SqlCommand(cmdText10, sqlConnection);
								SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
								DataSet dataSet14 = new DataSet();
								sqlDataAdapter13.Fill(dataSet14, "tblHR_OTHour");
								string cmdText11 = fun.select("Hours", "tblHR_DutyHour", "Id='" + dataSet10.Tables[0].Rows[0]["DutyHrs"].ToString() + "'");
								SqlCommand selectCommand14 = new SqlCommand(cmdText11, sqlConnection);
								SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
								DataSet dataSet15 = new DataSet();
								sqlDataAdapter14.Fill(dataSet15, "tblHR_DutyHour");
								num51 = fun.OTRate(num9, Convert.ToDouble(dataSet14.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet15.Tables[0].Rows[0]["Hours"]), num);
								num36 = Math.Round(fun.OTAmt(num51, Convert.ToDouble(dataSet12.Tables[0].Rows[0]["OverTimeHrs"])));
							}
							if (num12 >= num - (num21 + num20 + 2.0) && num12 < num + 2.0 - (num21 + num20))
							{
								num30 = 1;
								num31 = Math.Round(num9 * num32 / 100.0);
							}
							else if (num12 >= num + 2.0 - (num21 + num20))
							{
								num30 = 2;
								num31 = Math.Round(num9 * num33 / 100.0);
							}
							num38 = Math.Round(num44 + num41 + num43 + num36 + num45);
							num37 = fun.PTax_Cal(num28 + num31 + num41 + num43 + num35 + num44 + num45 + num36, MonthId.ToString("D2"));
							num39 = num46;
							num48 = Math.Round(num29 + num37 + num49 + num50 + num39);
							num47 = num28 + num31 + num35 + num38;
							dataRow[15] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							dataRow[19] = num35;
							dataRow[21] = num38;
							dataRow[24] = num40.ToString();
							dataRow[25] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							dataRow[26] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							dataRow[27] = num20;
							dataRow[28] = num21.ToString();
							dataRow[29] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["LateIn"]);
							dataRow[30] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							dataRow[31] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							dataRow[32] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							dataRow[33] = num13;
							dataRow[34] = num29;
							dataRow[35] = num37;
							dataRow[36] = num49;
							dataRow[37] = num50;
							dataRow[38] = num39;
							dataRow[42] = num22;
							dataRow[43] = num23;
							dataRow[44] = num24;
							dataRow[45] = num25;
							dataRow[46] = num26;
							dataRow[47] = num27;
							dataRow[48] = num28;
							dataRow[49] = num30;
							dataRow[50] = num31;
							dataRow[22] = Math.Round(num47);
							dataRow[39] = Math.Round(num48);
							dataRow[23] = Math.Round(num47 - num48);
						}
					}
					dataRow[40] = dataSet2.Tables[0].Rows[i]["BankAccountNo"].ToString();
					dataRow[41] = fun.FromDateDMY(fun.getCurrDate());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				dataSet.AcceptChanges();
				DataSet dataSet16 = new OfferLetter();
				dataSet16.Tables[0].Merge(dataSet.Tables[0]);
				dataSet16.AcceptChanges();
				string text5 = base.Server.MapPath("~/Module/HR/Transactions/Reports/Salary_SAPL_Neha_Summary.rpt");
				report.Load(text5);
				report.SetDataSource(dataSet16);
				string text6 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text6);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataSet.Clear();
				dataSet.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
		MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Salary_Print.aspx?MonthId=" + MonthId + "&ModId=12&SubModId=133");
	}
}

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

public class Module_HR_Transactions_All_Month_Summary_Report : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DSa = new DataSet();

	private ReportDocument report = new ReportDocument();

	private int CompId;

	private int FinYearId;

	private int MonthId;

	private int EType;

	private int BGGroupId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_2a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a9d: Expected O, but got Unknown
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
				dataTable.Columns.Add(new DataColumn("SN", typeof(int)));
				sqlConnection.Open();
				string empty = string.Empty;
				empty = ((BGGroupId != 1) ? fun.select("tblHR_Salary_Master.FMonth,tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "' AND tblHR_OfficeStaff.BGGroup ='" + BGGroupId + "'  Order by tblHR_Salary_Master.EmpId Asc") : fun.select("tblHR_Salary_Master.FMonth,tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "' Order by tblHR_Salary_Master.EmpId Asc"));
				SqlCommand selectCommand = new SqlCommand(empty, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				int num = 1;
				int num2 = 0;
				int num3 = 0;
				string text = string.Empty;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					num3 = fun.SalYrs(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]), CompId);
					DataRow dataRow = dataTable.NewRow();
					string value = "";
					string value2 = "";
					string value3 = "";
					string value4 = "";
					double num4 = 0.0;
					num4 = DateTime.DaysInMonth(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
					dataRow[0] = dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString();
					dataRow[1] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					if (dataSet2.Tables[0].Rows.Count == 1)
					{
						text = dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString();
					}
					string cmdText = fun.select("Symbol AS Dept", "tblHR_Departments", "Id='" + dataSet2.Tables[0].Rows[i]["Department"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3, "tblHR_Departments");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = dataSet3.Tables[0].Rows[0]["Dept"].ToString();
					}
					if (dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString() == text)
					{
						if (num2 == 0)
						{
							dataRow[54] = num;
							dataRow[2] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString() + " [" + dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString() + "]";
							dataRow[5] = value;
							num++;
						}
						else
						{
							dataRow[54] = 0;
							dataRow[2] = "";
							dataRow[5] = "";
						}
						num2++;
					}
					else
					{
						num2 = 0;
						if (num2 == 0)
						{
							dataRow[54] = num;
							dataRow[2] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString() + " [" + dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString() + "]";
							dataRow[5] = value;
							num++;
						}
						else
						{
							dataRow[54] = 0;
							dataRow[2] = "";
							dataRow[5] = "";
						}
						num2++;
					}
					text = dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString();
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4, "Financial");
					string text2 = "";
					string text3 = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
					string[] array = text3.Split('-');
					string text4 = array[0];
					string text5 = array[1];
					text2 = ((Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 1 && Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 2 && (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 3 || Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) == 0)) ? text4 : text5);
					dataRow[3] = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
					dataRow[4] = text2;
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
					dataRow[6] = value2;
					dataRow[8] = value4;
					dataRow[51] = dataSet2.Tables[0].Rows[i]["PFNo"];
					dataRow[52] = dataSet2.Tables[0].Rows[i]["PANNo"];
					int num5 = 0;
					string cmdText5 = fun.select("Increment", "tblHR_Offer_Master", "OfferId ='" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						num5 = Convert.ToInt32(dataSet7.Tables[0].Rows[0]["Increment"]);
					}
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					dataRow[53] = "/erp/Module/HR/Transactions/OfferLetter_Print_Details.aspx?OfferId=" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "&T=3&Key=" + randomAlphaNumeric + "&Key1=" + Key + "&EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Increment=" + num5 + "&ModId=12&SubModId=25";
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					string cmdText6 = fun.select("Increment", "tblHR_Salary_Master", "EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' AND FMonth='" + dataSet2.Tables[0].Rows[i]["FMonth"].ToString() + "' AND FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter7.Fill(dataSet8);
					string cmdText7 = fun.select("Increment", "tblHR_Offer_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter8.Fill(dataSet9);
					string empty2 = string.Empty;
					int num14 = 0;
					int num15 = 0;
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						num14 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Increment"]);
					}
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						num15 = Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Increment"]);
					}
					empty2 = ((num14 != num15) ? fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,Id", "tblHR_Increment_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "' AND Increment='" + dataSet8.Tables[0].Rows[0]["Increment"].ToString() + "'") : fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'"));
					SqlCommand selectCommand9 = new SqlCommand(empty2, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter9.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						num12 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["Salary"]);
						num6 = fun.Offer_Cal(num12, 1, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["StaffType"]));
						num7 = fun.Offer_Cal(num12, 2, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num8 = fun.Offer_Cal(num12, 3, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num9 = fun.Offer_Cal(num12, 4, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num10 = fun.Offer_Cal(num12, 5, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num11 = fun.Offer_Cal(num12, 6, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						dataRow[9] = num6;
						dataRow[10] = num7;
						dataRow[11] = num8;
						dataRow[12] = num9;
						dataRow[13] = num10;
						dataRow[14] = num11;
						dataRow[16] = num12.ToString();
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
						double num30 = 0.0;
						double num31 = 0.0;
						double num32 = 0.0;
						double num33 = 0.0;
						double num34 = 0.0;
						int num35 = 0;
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
						double num51 = 0.0;
						double num52 = 0.0;
						double num53 = 0.0;
						double num54 = 0.0;
						double num55 = 0.0;
						string cmdText9 = fun.select("tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Remarks1,tblHR_Salary_Details.Deduction,tblHR_Salary_Details.Remarks2", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' AND tblHR_Salary_Master.FMonth='" + dataSet2.Tables[0].Rows[i]["FMonth"].ToString() + "'");
						SqlCommand selectCommand11 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
						DataSet dataSet12 = new DataSet();
						sqlDataAdapter11.Fill(dataSet12);
						if (dataSet12.Tables[0].Rows.Count > 0)
						{
							num45 = fun.WorkingDays(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
							num19 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							num20 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							num21 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							num22 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							num23 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							num24 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							num25 = fun.CountSundays(num3, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
							num26 = fun.GetHoliday(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]), CompId, FinYearId);
							num37 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer1"]);
							num38 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer2"]);
							num39 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["ExGratia"]);
							num49 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["VehicleAllowance"]);
							num50 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Addition"]);
							num51 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Deduction"]);
							num16 = num4 - (num20 - (num21 + num22));
							num17 = num19 + num24 + num23;
							num18 = num4 - num16;
							num27 = Math.Round(num6 * num16 / num4);
							num28 = Math.Round(num7 * num16 / num4);
							num29 = Math.Round(num8 * num16 / num4);
							num30 = Math.Round(num9 * num16 / num4);
							num31 = Math.Round(num10 * num16 / num4);
							num32 = Math.Round(num11 * num16 / num4);
							num33 = Math.Round(num27 + num28 + num29 + num30 + num31 + num32);
							num13 = fun.Pf_Cal(num33, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["PFEmployee"]));
							num34 = num13;
							num40 = Math.Round(num39 * num16 / num4);
							num54 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Installment"]);
							num55 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["MobileExeAmt"]);
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
									num47 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "2":
									num46 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "3":
									num48 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								}
							}
							if (dataSet10.Tables[0].Rows[0]["OverTime"].ToString() == "2")
							{
								double num56 = 0.0;
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
								num56 = fun.OTRate(num12, Convert.ToDouble(dataSet14.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet15.Tables[0].Rows[0]["Hours"]), num4);
								num41 = Math.Round(fun.OTAmt(num56, Convert.ToDouble(dataSet12.Tables[0].Rows[0]["OverTimeHrs"])));
							}
							if (num17 >= num4 - (num26 + num25 + 2.0) && num17 < num4 + 2.0 - (num26 + num25))
							{
								num35 = 1;
								num36 = Math.Round(num12 * num37 / 100.0);
							}
							else if (num17 >= num4 + 2.0 - (num26 + num25))
							{
								num35 = 2;
								num36 = Math.Round(num12 * num38 / 100.0);
							}
							num43 = Math.Round(num49 + num46 + num48 + num41 + num50);
							num42 = fun.PTax_Cal(num33 + num36 + num46 + num48 + num40 + num49 + num50 + num41, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]).ToString("D2"));
							num44 = num51;
							num53 = Math.Round(num34 + num42 + num54 + num55 + num44);
							num52 = num33 + num36 + num40 + num43;
							dataRow[15] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							dataRow[19] = num40;
							dataRow[21] = num43;
							dataRow[24] = num45.ToString();
							dataRow[25] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							dataRow[26] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							dataRow[27] = num25;
							dataRow[28] = num26.ToString();
							dataRow[29] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["LateIn"]);
							dataRow[30] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							dataRow[31] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							dataRow[32] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							dataRow[33] = num18;
							dataRow[34] = num34;
							dataRow[35] = num42;
							dataRow[36] = num54;
							dataRow[37] = num55;
							dataRow[38] = num44;
							dataRow[42] = num27;
							dataRow[43] = num28;
							dataRow[44] = num29;
							dataRow[45] = num30;
							dataRow[46] = num31;
							dataRow[47] = num32;
							dataRow[48] = num33;
							dataRow[49] = num35;
							dataRow[50] = num36;
							dataRow[22] = Math.Round(num52);
							dataRow[39] = Math.Round(num53);
							dataRow[23] = Math.Round(num52 - num53);
						}
					}
					dataRow[40] = dataSet2.Tables[0].Rows[i]["BankAccountNo"].ToString();
					dataRow[41] = fun.FromDateDMY(fun.getCurrDate());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				dataSet.AcceptChanges();
				DataSet dataSet16 = new Yearly_Salary();
				dataSet16.Tables[0].Merge(dataSet.Tables[0]);
				dataSet16.AcceptChanges();
				string text6 = base.Server.MapPath("~/Module/HR/Transactions/Reports/All_Month_Summary_Report.rpt");
				report.Load(text6);
				report.SetDataSource(dataSet16);
				string text7 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text7);
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

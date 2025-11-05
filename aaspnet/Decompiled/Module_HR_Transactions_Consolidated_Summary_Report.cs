using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_HR_Transactions_Consolidated_Summary_Report : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected GridView GridView1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DSa = new DataSet();

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
		//IL_2bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bff: Expected O, but got Unknown
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
				empty = ((BGGroupId != 1) ? fun.select("tblHR_Salary_Master.FMonth,tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "' AND tblHR_OfficeStaff.BGGroup ='" + BGGroupId + "'  Order by tblHR_Salary_Master.EmpId Asc") : fun.select("tblHR_Salary_Master.FMonth,tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo,tblHR_OfficeStaff.OfferId", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='" + EType + "'  Order by tblHR_Salary_Master.EmpId Asc"));
				SqlCommand selectCommand = new SqlCommand(empty, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2);
				int num = 1;
				int num2 = 0;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					num2 = fun.SalYrs(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]), CompId);
					DataRow dataRow = dataTable.NewRow();
					string value = "";
					string value2 = "";
					string value3 = "";
					string value4 = "";
					double num3 = 0.0;
					num3 = DateTime.DaysInMonth(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
					dataRow[0] = dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString();
					dataRow[1] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					string cmdText = fun.select("Symbol AS Dept", "tblHR_Departments", "Id='" + dataSet2.Tables[0].Rows[i]["Department"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3, "tblHR_Departments");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = dataSet3.Tables[0].Rows[0]["Dept"].ToString();
					}
					dataRow[2] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString() + " [" + dataSet2.Tables[0].Rows[i]["StaffEmpId"].ToString() + "]";
					dataRow[5] = value;
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4, "Financial");
					string text = "";
					string text2 = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
					string[] array = text2.Split('-');
					string text3 = array[0];
					string text4 = array[1];
					text = ((Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 1 && Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 2 && (Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) != 3 || Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]) == 0)) ? text3 : text4);
					dataRow[3] = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
					dataRow[4] = text;
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
					int num4 = 0;
					string cmdText5 = fun.select("Increment", "tblHR_Offer_Master", "OfferId ='" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						num4 = Convert.ToInt32(dataSet7.Tables[0].Rows[0]["Increment"]);
					}
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					dataRow[53] = "/erp/Module/HR/Transactions/OfferLetter_Print_Details.aspx?OfferId=" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["OfferId"]) + "&T=4&Key=" + randomAlphaNumeric + "&Key1=" + Key + "&EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Increment=" + num4 + "&ModId=12&SubModId=25";
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
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
					int num13 = 0;
					int num14 = 0;
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						num13 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Increment"]);
					}
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						num14 = Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Increment"]);
					}
					empty2 = ((num13 != num14) ? fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,Id", "tblHR_Increment_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "' AND Increment='" + dataSet8.Tables[0].Rows[0]["Increment"].ToString() + "'") : fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + dataSet2.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'"));
					SqlCommand selectCommand9 = new SqlCommand(empty2, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter9.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						num11 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["Salary"]);
						num5 = fun.Offer_Cal(num11, 1, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["StaffType"]));
						num6 = fun.Offer_Cal(num11, 2, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num7 = fun.Offer_Cal(num11, 3, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num8 = fun.Offer_Cal(num11, 4, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num9 = fun.Offer_Cal(num11, 5, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						num10 = fun.Offer_Cal(num11, 6, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["TypeOf"]));
						dataRow[9] = num5;
						dataRow[10] = num6;
						dataRow[11] = num7;
						dataRow[12] = num8;
						dataRow[13] = num9;
						dataRow[14] = num10;
						dataRow[16] = num11.ToString();
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
						double num30 = 0.0;
						double num31 = 0.0;
						double num32 = 0.0;
						double num33 = 0.0;
						int num34 = 0;
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
						double num51 = 0.0;
						double num52 = 0.0;
						double num53 = 0.0;
						double num54 = 0.0;
						string cmdText9 = fun.select("tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Remarks1,tblHR_Salary_Details.Deduction,tblHR_Salary_Details.Remarks2", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' AND tblHR_Salary_Master.FMonth='" + dataSet2.Tables[0].Rows[i]["FMonth"].ToString() + "'");
						SqlCommand selectCommand11 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
						DataSet dataSet12 = new DataSet();
						sqlDataAdapter11.Fill(dataSet12);
						if (dataSet12.Tables[0].Rows.Count > 0)
						{
							num44 = fun.WorkingDays(FinYearId, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
							num18 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							num19 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							num20 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							num21 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							num22 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							num23 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							num24 = fun.CountSundays(num2, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]));
							num25 = fun.GetHoliday(Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]), CompId, FinYearId);
							num36 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer1"]);
							num37 = Convert.ToInt32(dataSet10.Tables[0].Rows[0]["AttBonusPer2"]);
							if (dataSet10.Tables[0].Rows[0]["ExGratia"] != DBNull.Value)
							{
								num38 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["ExGratia"]);
							}
							if (dataSet10.Tables[0].Rows[0]["VehicleAllowance"] != DBNull.Value)
							{
								num48 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["VehicleAllowance"]);
							}
							if (dataSet12.Tables[0].Rows[0]["Addition"] != DBNull.Value)
							{
								num49 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Addition"]);
							}
							if (dataSet12.Tables[0].Rows[0]["Deduction"] != DBNull.Value)
							{
								num50 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Deduction"]);
							}
							num15 = num3 - (num19 - (num20 + num21));
							num16 = num18 + num23 + num22;
							num17 = num3 - num15;
							num26 = Math.Round(num5 * num15 / num3);
							num27 = Math.Round(num6 * num15 / num3);
							num28 = Math.Round(num7 * num15 / num3);
							num29 = Math.Round(num8 * num15 / num3);
							num30 = Math.Round(num9 * num15 / num3);
							num31 = Math.Round(num10 * num15 / num3);
							num32 = Math.Round(num26 + num27 + num28 + num29 + num30 + num31);
							num12 = fun.Pf_Cal(num32, 1, Convert.ToInt32(dataSet10.Tables[0].Rows[0]["PFEmployee"]));
							num33 = num12;
							num39 = Math.Round(num38 * num15 / num3);
							if (dataSet12.Tables[0].Rows[0]["Installment"] != DBNull.Value)
							{
								num53 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Installment"]);
							}
							if (dataSet12.Tables[0].Rows[0]["MobileExeAmt"] != DBNull.Value)
							{
								num54 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["MobileExeAmt"]);
							}
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
									num46 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "2":
									num45 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								case "3":
									num47 += Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet13.Tables[0].Rows[j]["Amount"]);
									break;
								}
							}
							if (dataSet10.Tables[0].Rows[0]["OverTime"].ToString() == "2")
							{
								double num55 = 0.0;
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
								num55 = fun.OTRate(num11, Convert.ToDouble(dataSet14.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet15.Tables[0].Rows[0]["Hours"]), num3);
								num40 = Math.Round(fun.OTAmt(num55, Convert.ToDouble(dataSet12.Tables[0].Rows[0]["OverTimeHrs"])));
							}
							if (num16 >= num3 - (num25 + num24 + 2.0) && num16 < num3 + 2.0 - (num25 + num24))
							{
								num34 = 1;
								num35 = Math.Round(num11 * num36 / 100.0);
							}
							else if (num16 >= num3 + 2.0 - (num25 + num24))
							{
								num34 = 2;
								num35 = Math.Round(num11 * num37 / 100.0);
							}
							num42 = Math.Round(num48 + num45 + num47 + num40 + num49);
							num41 = fun.PTax_Cal(num32 + num35 + num45 + num47 + num39 + num48 + num49 + num40, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FMonth"]).ToString("D2"));
							num43 = num50;
							num52 = Math.Round(num33 + num41 + num53 + num54 + num43);
							num51 = num32 + num35 + num39 + num42;
							if (dataSet12.Tables[0].Rows[0]["Sunday"] != DBNull.Value)
							{
								dataRow[15] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Sunday"]);
							}
							else
							{
								dataRow[15] = 0;
							}
							dataRow[19] = num39;
							dataRow[21] = num42;
							dataRow[24] = num44.ToString();
							if (dataSet12.Tables[0].Rows[0]["Present"] != DBNull.Value)
							{
								dataRow[25] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Present"]);
							}
							else
							{
								dataRow[25] = 0;
							}
							if (dataSet12.Tables[0].Rows[0]["Absent"] != DBNull.Value)
							{
								dataRow[26] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Absent"]);
							}
							else
							{
								dataRow[26] = 0;
							}
							dataRow[27] = num24;
							dataRow[28] = num25.ToString();
							if (dataSet12.Tables[0].Rows[0]["LateIn"] != DBNull.Value)
							{
								dataRow[29] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["LateIn"]);
							}
							else
							{
								dataRow[29] = 0;
							}
							if (dataSet12.Tables[0].Rows[0]["Coff"] != DBNull.Value)
							{
								dataRow[30] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Coff"]);
							}
							else
							{
								dataRow[30] = 0;
							}
							if (dataSet12.Tables[0].Rows[0]["HalfDay"] != DBNull.Value)
							{
								dataRow[31] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["HalfDay"]);
							}
							else
							{
								dataRow[31] = 0;
							}
							if (dataSet12.Tables[0].Rows[0]["PL"] != DBNull.Value)
							{
								dataRow[32] = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["PL"]);
							}
							else
							{
								dataRow[32] = 0;
							}
							dataRow[33] = num17;
							dataRow[34] = num33;
							dataRow[35] = num41;
							dataRow[36] = num53;
							dataRow[37] = num54;
							dataRow[38] = num43;
							dataRow[42] = num26;
							dataRow[43] = num27;
							dataRow[44] = num28;
							dataRow[45] = num29;
							dataRow[46] = num30;
							dataRow[47] = num31;
							dataRow[48] = num32;
							dataRow[49] = num34;
							dataRow[50] = num35;
							dataRow[22] = Math.Round(num51);
							dataRow[39] = Math.Round(num52);
							dataRow[23] = Math.Round(num51 - num52);
							dataRow[17] = 0;
							dataRow[18] = 0;
							dataRow[20] = 0;
						}
					}
					dataRow[40] = dataSet2.Tables[0].Rows[i]["BankAccountNo"].ToString();
					dataRow[41] = fun.FromDateDMY(fun.getCurrDate());
					dataRow[54] = num;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				var varlist = from row in dataTable.AsEnumerable()
					group row by new
					{
						y = row.Field<string>("EmpId")
					} into grp
					let row1 = grp.First()
					select new
					{
						EmpId = row1.Field<string>("EmpId"),
						CompId = row1.Field<int>("CompId"),
						EmployeeName = row1.Field<string>("EmployeeName"),
						Month = row1.Field<string>("Month"),
						Year = row1.Field<string>("Year"),
						Dept = row1.Field<string>("Dept"),
						Designation = row1.Field<string>("Designation"),
						Status = row1.Field<string>("Status"),
						Grade = row1.Field<string>("Grade"),
						Basic = row1.Field<double>("Basic"),
						DA = row1.Field<double>("DA"),
						HRA = row1.Field<double>("HRA"),
						Conveyance = row1.Field<double>("Conveyance"),
						Education = row1.Field<double>("Education"),
						Medical = row1.Field<double>("Medical"),
						SundayP = row1.Field<double>("SundayP"),
						GrossTotal = row1.Field<double>("GrossTotal"),
						AttendanceBonus = row1.Field<double>("AttendanceBonus"),
						SpecialAllowance = row1.Field<double>("SpecialAllowance"),
						ExGratia = grp.Sum((DataRow r) => r.Field<double>("ExGratia")),
						TravellingAllowance = row1.Field<double>("TravellingAllowance"),
						Miscellaneous = grp.Sum((DataRow r) => r.Field<double>("Miscellaneous")),
						Total = grp.Sum((DataRow r) => r.Field<double>("Total")),
						NetPay = grp.Sum((DataRow r) => r.Field<double>("NetPay")),
						WorkingDays = row1.Field<double>("WorkingDays"),
						PreasentDays = row1.Field<double>("PreasentDays"),
						AbsentDays = row1.Field<double>("AbsentDays"),
						Sunday = row1.Field<double>("Sunday"),
						Holiday = row1.Field<double>("Holiday"),
						LateIn = row1.Field<double>("LateIn"),
						Coff = row1.Field<double>("Coff"),
						HalfDays = row1.Field<double>("HalfDays"),
						PL = row1.Field<double>("PL"),
						LWP = row1.Field<double>("LWP"),
						PFofEmployee = grp.Sum((DataRow r) => r.Field<double>("PFofEmployee")),
						PTax = grp.Sum((DataRow r) => r.Field<double>("PTax\u200e")),
						PersonalLoanInstall = grp.Sum((DataRow r) => r.Field<double>("PersonalLoanInstall\u200e")),
						MobileBill = grp.Sum((DataRow r) => r.Field<double>("MobileBill")),
						Miscellaneous2 = grp.Sum((DataRow r) => r.Field<double>("Miscellaneous2")),
						Total2 = grp.Sum((DataRow r) => r.Field<double>("Total2")),
						EmpACNo = row1.Field<string>("EmpACNo"),
						Date = row1.Field<string>("Date"),
						BasicCal = grp.Sum((DataRow r) => r.Field<double>("BasicCal")),
						DACal = grp.Sum((DataRow r) => r.Field<double>("DACal")),
						HRACal = grp.Sum((DataRow r) => r.Field<double>("HRACal")),
						ConveyanceCal = grp.Sum((DataRow r) => r.Field<double>("ConveyanceCal")),
						EducationCal = grp.Sum((DataRow r) => r.Field<double>("EducationCal")),
						MedicalCal = grp.Sum((DataRow r) => r.Field<double>("MedicalCal")),
						GrossTotalCal = grp.Sum((DataRow r) => r.Field<double>("GrossTotalCal")),
						AttBonusType = row1.Field<double>("AttBonusType"),
						AttBonusAmt = grp.Sum((DataRow r) => r.Field<double>("AttBonusAmt")),
						PFNo = row1.Field<string>("PFNo"),
						PANNo = row1.Field<string>("PANNo"),
						Path = row1.Field<string>("Path"),
						SN = row1.Field<int>("SN")
					};
				DataTable table = LINQToDataTable(varlist);
				DataSet dataSet16 = new Yearly_Salary();
				dataSet16.Tables[0].Merge(table);
				dataSet16.AcceptChanges();
				string text5 = base.Server.MapPath("~/Module/HR/Transactions/Reports/Consolidated_Summary_Report.rpt");
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

	public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
	{
		DataTable dataTable = new DataTable();
		PropertyInfo[] array = null;
		if (varlist == null)
		{
			return dataTable;
		}
		foreach (T item in varlist)
		{
			if (array == null)
			{
				array = item.GetType().GetProperties();
				PropertyInfo[] array2 = array;
				foreach (PropertyInfo propertyInfo in array2)
				{
					Type type = propertyInfo.PropertyType;
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						type = type.GetGenericArguments()[0];
					}
					dataTable.Columns.Add(new DataColumn(propertyInfo.Name, type));
				}
			}
			DataRow dataRow = dataTable.NewRow();
			PropertyInfo[] array3 = array;
			foreach (PropertyInfo propertyInfo2 in array3)
			{
				dataRow[propertyInfo2.Name] = ((propertyInfo2.GetValue(item, null) == null) ? DBNull.Value : propertyInfo2.GetValue(item, null));
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
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

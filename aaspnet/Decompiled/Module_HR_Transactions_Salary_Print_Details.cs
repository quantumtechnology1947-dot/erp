using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_HR_Transactions_Salary_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private ReportDocument report = new ReportDocument();

	private int CompId;

	private int FinYearId;

	private string EmpId = "";

	private int MonthId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_229e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a5: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				EmpId = base.Request.QueryString["EmpId"].ToString();
				MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
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
				sqlConnection.Open();
				string cmdText = fun.select("UserID,CompId,OfferId,EmpId,Title,EmployeeName,SwapCardNo,Department,BGGroup,DirectorsName,DeptHead,Designation,Grade,MobileNo,BankAccountNo,PFNo,PANNo", "tblHR_OfficeStaff", "CompId='" + CompId + "'  And EmpId='" + EmpId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS);
				string value = "";
				string value2 = "";
				string value3 = "";
				string value4 = "";
				double num = 0.0;
				if (DS.Tables[0].Rows.Count > 0)
				{
					num = DateTime.DaysInMonth(FinYearId, MonthId);
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = EmpId;
					dataRow[1] = Convert.ToInt32(DS.Tables[0].Rows[0]["CompId"]);
					dataRow[2] = DS.Tables[0].Rows[0]["Title"].ToString() + "." + DS.Tables[0].Rows[0]["EmployeeName"].ToString();
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "Financial");
					string text = "";
					string text2 = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					string[] array = text2.Split('-');
					string text3 = array[0];
					string text4 = array[1];
					text = ((MonthId != 1 && MonthId != 2 && (MonthId != 3 || MonthId == 0)) ? text3 : text4);
					dataRow[3] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthId);
					dataRow[4] = text;
					string cmdText3 = fun.select("Description+' [ '+Symbol+' ]' AS Dept", "tblHR_Departments", "Id='" + DS.Tables[0].Rows[0]["Department"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "tblHR_Departments");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = dataSet3.Tables[0].Rows[0]["Dept"].ToString();
					}
					string cmdText4 = fun.select("Type+' [ '+Symbol+' ]' AS Designation", "tblHR_Designation", "Id='" + DS.Tables[0].Rows[0]["Designation"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblHR_Designation");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet4.Tables[0].Rows[0]["Designation"].ToString();
					}
					string cmdText5 = fun.select("Symbol AS Grade", "tblHR_Grade", "Id='" + DS.Tables[0].Rows[0]["Grade"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblHR_Grade");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						value4 = dataSet5.Tables[0].Rows[0]["Grade"].ToString();
					}
					dataRow[5] = value;
					dataRow[6] = value2;
					dataRow[8] = value4;
					dataRow[51] = DS.Tables[0].Rows[0]["PFNo"];
					dataRow[52] = DS.Tables[0].Rows[0]["PANNo"];
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					string cmdText6 = fun.select("Increment", "tblHR_Salary_Master", "EmpId='" + EmpId + "' AND FMonth='" + MonthId + "' AND FinYearId='" + FinYearId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6, "tblHR_Salary_Master");
					string cmdText7 = fun.select("Increment", "tblHR_Offer_Master", "OfferId='" + DS.Tables[0].Rows[0]["OfferId"].ToString() + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					string empty = string.Empty;
					empty = ((Convert.ToInt32(dataSet6.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet7.Tables[0].Rows[0]["Increment"])) ? fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,Id", "tblHR_Increment_Master", "OfferId='" + DS.Tables[0].Rows[0]["OfferId"].ToString() + "' AND Increment='" + dataSet6.Tables[0].Rows[0]["Increment"].ToString() + "'") : fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + DS.Tables[0].Rows[0]["OfferId"].ToString() + "'"));
					SqlCommand selectCommand8 = new SqlCommand(empty, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						num8 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Salary"]);
						num2 = fun.Offer_Cal(num8, 1, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["StaffType"]));
						num3 = fun.Offer_Cal(num8, 2, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]));
						num4 = fun.Offer_Cal(num8, 3, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]));
						num5 = fun.Offer_Cal(num8, 4, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]));
						num6 = fun.Offer_Cal(num8, 5, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]));
						num7 = fun.Offer_Cal(num8, 6, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]));
						dataRow[9] = num2;
						dataRow[10] = num3;
						dataRow[11] = num4;
						dataRow[12] = num5;
						dataRow[13] = num6;
						dataRow[14] = num7;
						dataRow[16] = num8.ToString();
						string cmdText8 = fun.select("Description", "tblHR_EmpType", "Id='" + dataSet8.Tables[0].Rows[0]["StaffType"].ToString() + "'");
						SqlCommand selectCommand9 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9, "tblHR_EmpType");
						if (dataSet9.Tables[0].Rows.Count > 0)
						{
							if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]) == 1)
							{
								value3 = "SAPL - " + dataSet9.Tables[0].Rows[0]["Description"].ToString();
							}
							else if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]) == 2)
							{
								value3 = "NEHA - " + dataSet9.Tables[0].Rows[0]["Description"].ToString();
							}
						}
						dataRow[7] = value3;
						double num10 = 0.0;
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
						int num29 = 0;
						double num30 = 0.0;
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
						string cmdText9 = fun.select("tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Remarks1,tblHR_Salary_Details.Deduction,tblHR_Salary_Details.Remarks2", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + EmpId + "' AND tblHR_Salary_Master.FMonth='" + MonthId + "'");
						SqlCommand selectCommand10 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
						DataSet dataSet10 = new DataSet();
						sqlDataAdapter10.Fill(dataSet10);
						if (dataSet10.Tables[0].Rows.Count > 0)
						{
							num39 = fun.WorkingDays(FinYearId, MonthId);
							num13 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Present"]);
							num14 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Absent"]);
							num15 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["PL"]);
							num16 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Coff"]);
							num17 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["HalfDay"]);
							num18 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Sunday"]);
							num19 = fun.CountSundays(year, MonthId);
							num20 = fun.GetHoliday(MonthId, CompId, FinYearId);
							num31 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["AttBonusPer1"]);
							num32 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["AttBonusPer2"]);
							num33 = Convert.ToDouble(dataSet8.Tables[0].Rows[0]["ExGratia"]);
							num43 = Convert.ToDouble(dataSet8.Tables[0].Rows[0]["VehicleAllowance"]);
							num44 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Addition"]);
							num45 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Deduction"]);
							num10 = num - (num14 - (num15 + num16));
							num11 = num13 + num18 + num17;
							num12 = num - num10;
							num21 = Math.Round(num2 * num10 / num);
							num22 = Math.Round(num3 * num10 / num);
							num23 = Math.Round(num4 * num10 / num);
							num24 = Math.Round(num5 * num10 / num);
							num25 = Math.Round(num6 * num10 / num);
							num26 = Math.Round(num7 * num10 / num);
							num27 = Math.Round(num21 + num22 + num23 + num24 + num25 + num26);
							num9 = fun.Pf_Cal(num27, 1, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["PFEmployee"]));
							num28 = num9;
							num34 = Math.Round(num33 * num10 / num);
							num48 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Installment"]);
							num49 = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["MobileExeAmt"]);
							string empty2 = string.Empty;
							empty2 = ((Convert.ToInt32(dataSet6.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet7.Tables[0].Rows[0]["Increment"])) ? fun.select("Qty,Amount,IncludesIn", "tblHR_Increment_Accessories", "MId='" + dataSet8.Tables[0].Rows[0]["Id"].ToString() + "'") : fun.select("Qty,Amount,IncludesIn", "tblHR_Offer_Accessories", "MId='" + dataSet8.Tables[0].Rows[0]["OfferId"].ToString() + "'"));
							SqlCommand selectCommand11 = new SqlCommand(empty2, sqlConnection);
							SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
							DataSet dataSet11 = new DataSet();
							sqlDataAdapter11.Fill(dataSet11);
							for (int i = 0; i < dataSet11.Tables[0].Rows.Count; i++)
							{
								switch (dataSet11.Tables[0].Rows[i]["IncludesIn"].ToString())
								{
								case "1":
									num41 += Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Amount"]);
									break;
								case "2":
									num40 += Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Amount"]);
									break;
								case "3":
									num42 += Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet11.Tables[0].Rows[i]["Amount"]);
									break;
								}
							}
							if (dataSet8.Tables[0].Rows[0]["OverTime"].ToString() == "2")
							{
								double num50 = 0.0;
								string cmdText10 = fun.select("Hours", "tblHR_OTHour", "Id='" + dataSet8.Tables[0].Rows[0]["OTHrs"].ToString() + "'");
								SqlCommand selectCommand12 = new SqlCommand(cmdText10, sqlConnection);
								SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
								DataSet dataSet12 = new DataSet();
								sqlDataAdapter12.Fill(dataSet12, "tblHR_OTHour");
								string cmdText11 = fun.select("Hours", "tblHR_DutyHour", "Id='" + dataSet8.Tables[0].Rows[0]["DutyHrs"].ToString() + "'");
								SqlCommand selectCommand13 = new SqlCommand(cmdText11, sqlConnection);
								SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
								DataSet dataSet13 = new DataSet();
								sqlDataAdapter13.Fill(dataSet13, "tblHR_DutyHour");
								num50 = fun.OTRate(num8, Convert.ToDouble(dataSet12.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet13.Tables[0].Rows[0]["Hours"]), num);
								num35 = Math.Round(fun.OTAmt(num50, Convert.ToDouble(dataSet10.Tables[0].Rows[0]["OverTimeHrs"])));
							}
							if (num11 >= num - (num20 + num19 + 2.0) && num11 < num + 2.0 - (num20 + num19))
							{
								num29 = 1;
								num30 = Math.Round(num8 * num31 / 100.0);
							}
							else if (num11 >= num + 2.0 - (num20 + num19))
							{
								num29 = 2;
								num30 = Math.Round(num8 * num32 / 100.0);
							}
							num37 = Math.Round(num43 + num40 + num42 + num35 + num44);
							num36 = fun.PTax_Cal(num27 + num30 + num40 + num42 + num34 + num43 + num44 + num35, MonthId.ToString("D2"));
							num38 = num45;
							num47 = Math.Round(num28 + num36 + num48 + num49 + num38);
							num46 = num27 + num30 + num34 + num37;
							dataRow[15] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Sunday"]);
							dataRow[19] = num34;
							dataRow[21] = num37;
							dataRow[24] = num39.ToString();
							dataRow[25] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Present"]);
							dataRow[26] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Absent"]);
							dataRow[27] = num19;
							dataRow[28] = num20.ToString();
							dataRow[29] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["LateIn"]);
							dataRow[30] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Coff"]);
							dataRow[31] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["HalfDay"]);
							dataRow[32] = Convert.ToDouble(dataSet10.Tables[0].Rows[0]["PL"]);
							dataRow[33] = num12;
							dataRow[34] = num28;
							dataRow[35] = num36;
							dataRow[36] = num48;
							dataRow[37] = num49;
							dataRow[38] = num38;
							dataRow[42] = num21;
							dataRow[43] = num22;
							dataRow[44] = num23;
							dataRow[45] = num24;
							dataRow[46] = num25;
							dataRow[47] = num26;
							dataRow[48] = num27;
							dataRow[49] = num29;
							dataRow[50] = num30;
							dataRow[22] = Math.Round(num46);
							dataRow[39] = Math.Round(num47);
							dataRow[23] = Math.Round(num46 - num47);
						}
					}
					dataRow[40] = DS.Tables[0].Rows[0]["BankAccountNo"].ToString();
					dataRow[41] = fun.FromDateDMY(fun.getCurrDate());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				dataSet.AcceptChanges();
				DataSet dataSet14 = new OfferLetter();
				dataSet14.Tables[0].Merge(dataSet.Tables[0]);
				dataSet14.AcceptChanges();
				string text5 = base.Server.MapPath("~/Module/HR/Transactions/Reports/Salary.rpt");
				report.Load(text5);
				report.SetDataSource(dataSet14);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				return;
			}
			catch (Exception)
			{
				return;
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
		try
		{
			string empty = string.Empty;
			empty = base.Request.QueryString["BackURL"].ToString();
			if (empty == "1")
			{
				base.Response.Redirect("Salary_Print.aspx?MonthId=" + MonthId + "&ModId=12&SubModId=133");
			}
			else if (empty == "0")
			{
				base.Response.Redirect("~/Default.aspx");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}
}

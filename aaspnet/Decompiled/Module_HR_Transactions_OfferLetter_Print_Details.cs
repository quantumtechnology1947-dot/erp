using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_HR_Transactions_OfferLetter_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer2;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS4 = new DataSet();

	private ReportDocument report = new ReportDocument();

	private ReportDocument increreport = new ReportDocument();

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private int OfferId;

	private string Key = string.Empty;

	private string Key1 = string.Empty;

	private int Increment;

	private int Type;

	private int EType;

	private int MonthId;

	private int BGGroupId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_5801: Unknown result type (might be due to invalid IL or missing references)
		//IL_5808: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			DataSet dataSet3 = new DataSet();
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			DataTable dataTable3 = new DataTable();
			DataTable dataTable4 = new DataTable();
			new DataTable();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			try
			{
				OfferId = Convert.ToInt32(base.Request.QueryString["OfferId"]);
				Increment = Convert.ToInt32(base.Request.QueryString["Increment"]);
				SId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				string text = "";
				string text2 = "";
				string cmdText = fun.select("Increment", "tblHR_Offer_Master", "OfferId ='" + OfferId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter.Fill(dataSet4);
				int num = 0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num = Convert.ToInt32(dataSet4.Tables[0].Rows[0][0]);
				}
				if (Increment == 0)
				{
					double num2 = 0.0;
					text = ((num <= 0) ? fun.select("OfferId,SysDate ,CompId,Title,EmployeeName,StaffType ,TypeOf,salary,DutyHrs,OTHrs,OverTime,ContactNo,EmailId,InterviewedBy ,AuthorizedBy,ReferenceBy,Designation ,ExGratia ,VehicleAllowance ,LTA,Loyalty ,PaidLeaves,Remarks,HeaderText,FooterText,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + OfferId + "' AND CompId='" + CompId + "'") : fun.select("Id,OfferId,SysDate ,CompId,Title,EmployeeName,StaffType ,TypeOf,salary,DutyHrs,OTHrs,OverTime,ContactNo,EmailId,InterviewedBy ,AuthorizedBy,ReferenceBy,Designation ,ExGratia ,VehicleAllowance ,LTA,Loyalty ,PaidLeaves,Remarks,HeaderText,FooterText,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,IncrementForTheYear,EffectFrom", "tblHR_Increment_Master", "OfferId='" + OfferId + "' AND CompId='" + CompId + "' AND Increment='0'"));
					SqlCommand selectCommand2 = new SqlCommand(text, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(DS);
					dataTable.Columns.Add(new DataColumn("OfferId", typeof(int)));
					dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
					dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
					dataTable.Columns.Add(new DataColumn("StaffType", typeof(string)));
					dataTable.Columns.Add(new DataColumn("TypeOf", typeof(int)));
					dataTable.Columns.Add(new DataColumn("salary", typeof(double)));
					dataTable.Columns.Add(new DataColumn("DutyHrs", typeof(string)));
					dataTable.Columns.Add(new DataColumn("OTHrs", typeof(string)));
					dataTable.Columns.Add(new DataColumn("OverTime", typeof(string)));
					dataTable.Columns.Add(new DataColumn("InterviewedBy", typeof(string)));
					dataTable.Columns.Add(new DataColumn("AuthorizedBy", typeof(string)));
					dataTable.Columns.Add(new DataColumn("ReferenceBy", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
					dataTable.Columns.Add(new DataColumn("ExGratia", typeof(double)));
					dataTable.Columns.Add(new DataColumn("VehicleAllowance", typeof(double)));
					dataTable.Columns.Add(new DataColumn("LTA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Loyalty", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PaidLeaves", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
					dataTable.Columns.Add(new DataColumn("HeaderText", typeof(string)));
					dataTable.Columns.Add(new DataColumn("FooterText", typeof(string)));
					dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
					dataTable.Columns.Add(new DataColumn("PerMonth", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PerMonthA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Basic", typeof(double)));
					dataTable.Columns.Add(new DataColumn("BasicA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("DA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("DAA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("HRA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("HRAA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Conveyance", typeof(double)));
					dataTable.Columns.Add(new DataColumn("ConveyanceA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Education", typeof(double)));
					dataTable.Columns.Add(new DataColumn("EducationA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("MedicalAllowance", typeof(double)));
					dataTable.Columns.Add(new DataColumn("MedicalAllowanceA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("AttendanceBonus", typeof(double)));
					dataTable.Columns.Add(new DataColumn("AttendanceBonusA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("ExGratiaA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("TakeHomeINR", typeof(double)));
					dataTable.Columns.Add(new DataColumn("TakeHomeWithAttend1", typeof(double)));
					dataTable.Columns.Add(new DataColumn("TakeHomeWithAttend2", typeof(double)));
					dataTable.Columns.Add(new DataColumn("LoyaltyBenefitA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("LTAA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PFE", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PFEA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PFC", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PFCA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Bonus", typeof(double)));
					dataTable.Columns.Add(new DataColumn("BonusA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("Gratuity", typeof(double)));
					dataTable.Columns.Add(new DataColumn("GratuityA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("VehicleAllowanceA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINR", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINRA", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINRwithAttendBonus1", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINRwithAttendBonus1A", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINRwithAttendBonus2", typeof(double)));
					dataTable.Columns.Add(new DataColumn("CTCinINRwithAttendBonus2A", typeof(double)));
					dataTable.Columns.Add(new DataColumn("AttBonPer", typeof(string)));
					dataTable.Columns.Add(new DataColumn("AttBonPer2", typeof(string)));
					dataTable.Columns.Add(new DataColumn("AttendanceBonus2", typeof(double)));
					dataTable.Columns.Add(new DataColumn("AttendanceBonusB", typeof(double)));
					dataTable.Columns.Add(new DataColumn("PFEmployee", typeof(string)));
					dataTable.Columns.Add(new DataColumn("PFCompany", typeof(string)));
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[0]["OfferId"]);
					dataRow[1] = Convert.ToInt32(DS.Tables[0].Rows[0]["CompId"]);
					dataRow[2] = DS.Tables[0].Rows[0]["Title"].ToString() + " " + DS.Tables[0].Rows[0]["EmployeeName"].ToString();
					dataRow[3] = DS.Tables[0].Rows[0]["StaffType"].ToString();
					dataRow[4] = DS.Tables[0].Rows[0]["TypeOf"].ToString();
					num2 = Convert.ToInt32(DS.Tables[0].Rows[0]["salary"]);
					dataRow[5] = num2;
					dataRow[6] = DS.Tables[0].Rows[0]["DutyHrs"].ToString();
					dataRow[7] = DS.Tables[0].Rows[0]["OTHrs"].ToString();
					dataRow[8] = DS.Tables[0].Rows[0]["OverTime"].ToString();
					string cmdText2 = fun.select("Title+'. '+EmployeeName As InterviewedBy", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS.Tables[0].Rows[0]["InterviewedBy"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter3.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet5.Tables[0].Rows[0]["InterviewedBy"].ToString();
					}
					string cmdText3 = fun.select("Title+'. '+EmployeeName As AuthorizedBy", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND EmpId='" + DS.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter4.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = dataSet6.Tables[0].Rows[0]["AuthorizedBy"].ToString();
					}
					dataRow[11] = DS.Tables[0].Rows[0]["ReferenceBy"].ToString();
					string cmdText4 = fun.select("Type", "tblHR_Designation", "Id='" + Convert.ToInt32(DS.Tables[0].Rows[0]["Designation"]) + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter5.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[12] = " ''" + dataSet7.Tables[0].Rows[0]["Type"].ToString() + "'' ";
					}
					dataRow[13] = Convert.ToDouble(DS.Tables[0].Rows[0]["ExGratia"]);
					dataRow[14] = Convert.ToDouble(DS.Tables[0].Rows[0]["VehicleAllowance"]);
					dataRow[15] = Convert.ToDouble(DS.Tables[0].Rows[0]["LTA"]);
					dataRow[16] = Convert.ToDouble(DS.Tables[0].Rows[0]["Loyalty"]);
					dataRow[17] = Convert.ToDouble(DS.Tables[0].Rows[0]["PaidLeaves"]);
					dataRow[18] = DS.Tables[0].Rows[0]["Remarks"].ToString();
					dataRow[19] = DS.Tables[0].Rows[0]["HeaderText"].ToString();
					dataRow[20] = DS.Tables[0].Rows[0]["FooterText"].ToString();
					dataRow[21] = fun.FromDate(DS.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[22] = num2;
					dataRow[23] = num2 * 12.0;
					dataRow[24] = fun.Offer_Cal(num2, 1, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["StaffType"]));
					dataRow[25] = fun.Offer_Cal(num2, 1, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["StaffType"]));
					dataRow[26] = fun.Offer_Cal(num2, 2, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[27] = fun.Offer_Cal(num2, 2, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[28] = fun.Offer_Cal(num2, 3, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[29] = fun.Offer_Cal(num2, 3, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[30] = fun.Offer_Cal(num2, 4, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[31] = fun.Offer_Cal(num2, 4, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[32] = fun.Offer_Cal(num2, 5, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[33] = fun.Offer_Cal(num2, 5, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[34] = fun.Offer_Cal(num2, 6, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					dataRow[35] = fun.Offer_Cal(num2, 6, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					if (DS.Tables[0].Rows[0]["StaffType"].ToString() != "5")
					{
						num3 = num2 * Convert.ToDouble(DS.Tables[0].Rows[0]["AttBonusPer1"]) / 100.0;
						num4 = num2 * Convert.ToDouble(DS.Tables[0].Rows[0]["AttBonusPer2"]) / 100.0;
						dataRow[36] = num3;
						dataRow[37] = num3 * 12.0;
						num5 = fun.Pf_Cal(num2, 1, Convert.ToDouble(DS.Tables[0].Rows[0]["PFEmployee"]));
						dataRow[44] = num5;
						dataRow[45] = num5 * 12.0;
						num6 = fun.Pf_Cal(num2, 2, Convert.ToDouble(DS.Tables[0].Rows[0]["PFCompany"]));
						dataRow[46] = num6.ToString();
						dataRow[47] = num6 * 12.0;
						num7 = fun.PTax_Cal(num2 + Convert.ToDouble(DS.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(DS.Tables[0].Rows[0]["ExGratia"]), "0");
						dataRow[50] = fun.Gratuity_Cal(num2, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
						num8 = fun.Gratuity_Cal(num2, 1, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
						dataRow[51] = fun.Gratuity_Cal(num2, 2, Convert.ToInt32(DS.Tables[0].Rows[0]["TypeOf"]));
						dataRow[59] = DS.Tables[0].Rows[0]["AttBonusPer1"].ToString();
						dataRow[60] = DS.Tables[0].Rows[0]["AttBonusPer2"].ToString();
						dataRow[61] = num4;
						dataRow[62] = num4 * 12.0;
						dataRow[63] = DS.Tables[0].Rows[0]["PFEmployee"].ToString();
						dataRow[64] = DS.Tables[0].Rows[0]["PFCompany"].ToString();
					}
					else
					{
						dataRow[36] = 0;
						dataRow[37] = 0;
						dataRow[44] = 0;
						dataRow[45] = 0;
						dataRow[46] = 0;
						dataRow[47] = 0;
						dataRow[50] = 0;
						dataRow[51] = 0;
					}
					dataRow[38] = Convert.ToDouble(DS.Tables[0].Rows[0]["ExGratia"]) * 12.0;
					dataRow[42] = Convert.ToDouble(DS.Tables[0].Rows[0]["Loyalty"]) * 12.0;
					dataRow[43] = Convert.ToDouble(DS.Tables[0].Rows[0]["LTA"]) * 12.0;
					dataRow[48] = DS.Tables[0].Rows[0]["Bonus"].ToString();
					dataRow[49] = Convert.ToDouble(DS.Tables[0].Rows[0]["Bonus"]) * 12.0;
					dataRow[52] = Convert.ToDouble(DS.Tables[0].Rows[0]["VehicleAllowance"]) * 12.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					string cmdText5 = fun.select("*", "tblHR_Offer_Accessories", "MId='" + OfferId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter6.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet8.Tables[0].Rows.Count; i++)
						{
							switch (dataSet8.Tables[0].Rows[i]["IncludesIn"].ToString())
							{
							case "1":
								num9 += Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Amount"]);
								break;
							case "2":
								num10 += Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Amount"]);
								break;
							case "3":
								num11 += Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet8.Tables[0].Rows[i]["Amount"]);
								break;
							}
						}
					}
					double num12 = 0.0;
					num12 = Math.Round(num2 + Convert.ToDouble(DS.Tables[0].Rows[0]["ExGratia"]) + num10 + num11 - (num5 + num7));
					dataRow[39] = Convert.ToDouble(decimal.Parse(num12.ToString()).ToString("N2"));
					double num13 = 0.0;
					dataRow[40] = Convert.ToDouble(decimal.Parse(Math.Round(num12 + num3).ToString()).ToString("N2"));
					double num14 = 0.0;
					dataRow[41] = Convert.ToDouble(decimal.Parse(Math.Round(num12 + num4).ToString()).ToString("N2"));
					double num15 = 0.0;
					num15 = Math.Round(num2 + Convert.ToDouble(DS.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(DS.Tables[0].Rows[0]["Loyalty"]) + Convert.ToDouble(DS.Tables[0].Rows[0]["LTA"]) + num8 + num6 + Convert.ToDouble(DS.Tables[0].Rows[0]["ExGratia"])) + num9 + num11;
					dataRow[53] = Convert.ToDouble(decimal.Parse(num15.ToString()).ToString("N2"));
					dataRow[54] = Convert.ToDouble(decimal.Parse(Math.Round(num15 * 12.0).ToString()).ToString("N2"));
					double num16 = 0.0;
					num16 = Math.Round(num15 + num3);
					dataRow[55] = decimal.Parse(num16.ToString()).ToString("N2");
					dataRow[56] = decimal.Parse(Math.Round(num16 * 12.0).ToString()).ToString("N2");
					double num17 = 0.0;
					num17 = Math.Round(num15 + num4);
					dataRow[57] = decimal.Parse(num17.ToString()).ToString("N2");
					dataRow[58] = decimal.Parse(Math.Round(num17 * 12.0).ToString()).ToString("N2");
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
					if (Increment == num)
					{
						dataTable2.Columns.Add(new DataColumn("Access_Perticulars", typeof(string)));
						dataTable2.Columns.Add(new DataColumn("Access_Amount", typeof(double)));
						string cmdText6 = fun.select("*", "tblHR_Offer_Accessories", "MId='" + OfferId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter7.Fill(dataSet9);
						for (int j = 0; j < dataSet9.Tables[0].Rows.Count; j++)
						{
							DataRow dataRow2 = dataTable2.NewRow();
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								dataRow2[0] = dataSet9.Tables[0].Rows[j]["Perticulars"].ToString();
								dataRow2[1] = Convert.ToDouble(dataSet9.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet9.Tables[0].Rows[j]["Amount"]);
							}
							dataTable2.Rows.Add(dataRow2);
							dataTable2.AcceptChanges();
						}
					}
					dataSet.Tables.Add(dataTable);
					dataSet.Tables.Add(dataTable2);
					dataSet.AcceptChanges();
					DataSet dataSet10 = new OfferLetter();
					dataSet10.Tables[0].Merge(dataSet.Tables[0]);
					dataSet10.Tables[1].Merge(dataSet.Tables[1]);
					dataSet10.AcceptChanges();
					string text3 = base.Server.MapPath("~/Module/HR/Transactions/Reports/OfferLetter.rpt");
					report.Load(text3);
					report.SetDataSource(dataSet10);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					Session[Key] = report;
					((Control)(object)CrystalReportViewer2).Visible = false;
					((Control)(object)CrystalReportViewer1).Visible = true;
					return;
				}
				double num18 = 0.0;
				text = ((Increment != num) ? fun.select("Id,OfferId,SysDate ,CompId,Title,EmployeeName,StaffType ,TypeOf,salary,DutyHrs,OTHrs,OverTime,ContactNo,EmailId,InterviewedBy ,AuthorizedBy,ReferenceBy,Designation ,ExGratia ,VehicleAllowance ,LTA,Loyalty ,PaidLeaves,Remarks,HeaderText,FooterText,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,IncrementForTheYear,EffectFrom", "tblHR_Increment_Master", "OfferId='" + OfferId + "' AND CompId='" + CompId + "' AND Increment='" + Increment + "'") : fun.select("OfferId,SysDate ,CompId,Title,EmployeeName,StaffType ,TypeOf,salary,DutyHrs,OTHrs,OverTime,ContactNo,EmailId,InterviewedBy ,AuthorizedBy,ReferenceBy,Designation ,ExGratia ,VehicleAllowance ,LTA,Loyalty ,PaidLeaves,Remarks,HeaderText,FooterText,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,IncrementForTheYear,EffectFrom", "tblHR_Offer_Master", "OfferId='" + OfferId + "' AND CompId='" + CompId + "'"));
				SqlCommand selectCommand8 = new SqlCommand(text, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				sqlDataAdapter8.Fill(DS4);
				int num19 = 0;
				num19 = Convert.ToInt32(DS4.Tables[0].Rows[0]["Increment"]) - 1;
				text2 = fun.select("Id,OfferId,SysDate ,CompId,Title,EmployeeName,StaffType ,TypeOf,salary,DutyHrs,OTHrs,OverTime,ContactNo,EmailId,InterviewedBy ,AuthorizedBy,ReferenceBy,Designation ,ExGratia ,VehicleAllowance ,LTA,Loyalty ,PaidLeaves,Remarks,HeaderText,FooterText,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,IncrementForTheYear,EffectFrom", "tblHR_Increment_Master", "OfferId='" + OfferId + "' AND CompId='" + CompId + "' AND Increment='" + num19 + "'");
				SqlCommand selectCommand9 = new SqlCommand(text2, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				sqlDataAdapter9.Fill(dataSet2);
				dataTable3.Columns.Add(new DataColumn("OfferId", typeof(int)));
				dataTable3.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable3.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("StaffType", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("TypeOf", typeof(int)));
				dataTable3.Columns.Add(new DataColumn("salary", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("DutyHrs", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("OTHrs", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("OverTime", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("InterviewedBy", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("AuthorizedBy", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("ReferenceBy", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("Designation", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("ExGratia", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("VehicleAllowance", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("LTA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Loyalty", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PaidLeaves", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Remarks", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("HeaderText", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("FooterText", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("PerMonth", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PerMonthA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Basic", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("BasicA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("DA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("DAA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("HRA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("HRAA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Conveyance", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("ConveyanceA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Education", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("EducationA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("MedicalAllowance", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("MedicalAllowanceA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonus", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonusA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("ExGratiaA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeINR", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeWithAttend1", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeWithAttend2", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("LoyaltyBenefitA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("LTAA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFE", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFEA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFC", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFCA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Bonus", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("BonusA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Gratuity", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("GratuityA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("VehicleAllowanceA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINR", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRA", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus1", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus1A", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus2", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus2A", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttBonPer", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("AttBonPer2", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonus2", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonusB", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFEmployee", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("PFCompany", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("IncrementForTheYear", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("EffectFrom", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("OFYear*", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("Grade*", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("GradeI*", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("Designation*", typeof(string)));
				dataTable3.Columns.Add(new DataColumn("ExGratia*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("VehicleAllowance*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("LTA*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Loyalty*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PerMonth*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Basic*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("DA*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("HRA*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Conveyance*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Education*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("MedicalAllowance*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonus*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("AttendanceBonus2*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeINR*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeWithAttend1*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("TakeHomeWithAttend2*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFE*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("PFC*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Bonus*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Gratuity*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINR*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus1*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("CTCinINRwithAttendBonus2*", typeof(double)));
				dataTable3.Columns.Add(new DataColumn("Id", typeof(int)));
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow3[0] = Convert.ToInt32(DS4.Tables[0].Rows[0]["OfferId"]);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow3[94] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]);
				}
				dataRow3[1] = Convert.ToInt32(DS4.Tables[0].Rows[0]["CompId"]);
				dataRow3[2] = DS4.Tables[0].Rows[0]["Title"].ToString() + " " + DS4.Tables[0].Rows[0]["EmployeeName"].ToString();
				dataRow3[3] = DS4.Tables[0].Rows[0]["StaffType"].ToString();
				dataRow3[4] = DS4.Tables[0].Rows[0]["TypeOf"].ToString();
				num18 = Convert.ToInt32(DS4.Tables[0].Rows[0]["salary"]);
				dataRow3[5] = num18;
				dataRow3[6] = DS4.Tables[0].Rows[0]["DutyHrs"].ToString();
				dataRow3[7] = DS4.Tables[0].Rows[0]["OTHrs"].ToString();
				dataRow3[8] = DS4.Tables[0].Rows[0]["OverTime"].ToString();
				string cmdText7 = fun.select("Title+'. '+EmployeeName As InterviewedBy", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS4.Tables[0].Rows[0]["InterviewedBy"].ToString() + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter10.Fill(dataSet11);
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					dataRow3[9] = dataSet11.Tables[0].Rows[0]["InterviewedBy"].ToString();
				}
				string cmdText8 = fun.select("Title+'. '+EmployeeName As AuthorizedBy", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND EmpId='" + DS4.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "'");
				SqlCommand selectCommand11 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter11.Fill(dataSet12);
				if (dataSet12.Tables[0].Rows.Count > 0)
				{
					dataRow3[10] = dataSet12.Tables[0].Rows[0]["AuthorizedBy"].ToString();
				}
				dataRow3[11] = DS4.Tables[0].Rows[0]["ReferenceBy"].ToString();
				string cmdText9 = fun.select("Type", "tblHR_Designation", "Id='" + Convert.ToInt32(DS4.Tables[0].Rows[0]["Designation"]) + "'");
				SqlCommand selectCommand12 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter12.Fill(dataSet13);
				if (dataSet13.Tables[0].Rows.Count > 0)
				{
					dataRow3[12] = dataSet13.Tables[0].Rows[0]["Type"].ToString();
				}
				dataRow3[13] = Convert.ToDouble(DS4.Tables[0].Rows[0]["ExGratia"]);
				dataRow3[14] = Convert.ToDouble(DS4.Tables[0].Rows[0]["VehicleAllowance"]);
				dataRow3[15] = Convert.ToDouble(DS4.Tables[0].Rows[0]["LTA"]);
				dataRow3[16] = Convert.ToDouble(DS4.Tables[0].Rows[0]["Loyalty"]);
				dataRow3[17] = Convert.ToDouble(DS4.Tables[0].Rows[0]["PaidLeaves"]);
				dataRow3[18] = DS4.Tables[0].Rows[0]["Remarks"].ToString();
				dataRow3[19] = DS4.Tables[0].Rows[0]["HeaderText"].ToString();
				dataRow3[20] = DS4.Tables[0].Rows[0]["FooterText"].ToString();
				dataRow3[21] = fun.FromDate(DS4.Tables[0].Rows[0]["SysDate"].ToString());
				dataRow3[22] = num18;
				dataRow3[23] = num18 * 12.0;
				dataRow3[24] = fun.Offer_Cal(num18, 1, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["StaffType"]));
				dataRow3[25] = fun.Offer_Cal(num18, 1, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["StaffType"]));
				dataRow3[26] = fun.Offer_Cal(num18, 2, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[27] = fun.Offer_Cal(num18, 2, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[28] = fun.Offer_Cal(num18, 3, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[29] = fun.Offer_Cal(num18, 3, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[30] = fun.Offer_Cal(num18, 4, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[31] = fun.Offer_Cal(num18, 4, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[32] = fun.Offer_Cal(num18, 5, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[33] = fun.Offer_Cal(num18, 5, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[34] = fun.Offer_Cal(num18, 6, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[35] = fun.Offer_Cal(num18, 6, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
				double num20 = 0.0;
				double num21 = 0.0;
				double num22 = 0.0;
				double num23 = 0.0;
				double num24 = 0.0;
				double num25 = 0.0;
				if (DS4.Tables[0].Rows[0]["StaffType"].ToString() != "5")
				{
					num20 = num18 * Convert.ToDouble(DS4.Tables[0].Rows[0]["AttBonusPer1"]) / 100.0;
					num21 = num18 * Convert.ToDouble(DS4.Tables[0].Rows[0]["AttBonusPer2"]) / 100.0;
					dataRow3[36] = num20;
					dataRow3[37] = num20 * 12.0;
					num22 = fun.Pf_Cal(num18, 1, Convert.ToDouble(DS4.Tables[0].Rows[0]["PFEmployee"]));
					dataRow3[44] = num22;
					dataRow3[45] = num22 * 12.0;
					num23 = fun.Pf_Cal(num18, 2, Convert.ToDouble(DS4.Tables[0].Rows[0]["PFCompany"]));
					dataRow3[46] = num23.ToString();
					dataRow3[47] = num23 * 12.0;
					num24 = fun.PTax_Cal(num18 + Convert.ToDouble(DS4.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(DS4.Tables[0].Rows[0]["ExGratia"]), "0");
					dataRow3[50] = fun.Gratuity_Cal(num18, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
					num25 = fun.Gratuity_Cal(num18, 1, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
					dataRow3[51] = fun.Gratuity_Cal(num18, 2, Convert.ToInt32(DS4.Tables[0].Rows[0]["TypeOf"]));
					dataRow3[59] = DS4.Tables[0].Rows[0]["AttBonusPer1"].ToString();
					dataRow3[60] = DS4.Tables[0].Rows[0]["AttBonusPer2"].ToString();
					dataRow3[61] = num21;
					dataRow3[62] = num21 * 12.0;
					dataRow3[63] = DS4.Tables[0].Rows[0]["PFEmployee"].ToString();
					dataRow3[64] = DS4.Tables[0].Rows[0]["PFCompany"].ToString();
				}
				else
				{
					dataRow3[36] = 0;
					dataRow3[37] = 0;
					dataRow3[44] = 0;
					dataRow3[45] = 0;
					dataRow3[46] = 0;
					dataRow3[47] = 0;
					dataRow3[50] = 0;
					dataRow3[51] = 0;
				}
				dataRow3[38] = Convert.ToDouble(DS4.Tables[0].Rows[0]["ExGratia"]) * 12.0;
				dataRow3[42] = Convert.ToDouble(DS4.Tables[0].Rows[0]["Loyalty"]) * 12.0;
				dataRow3[43] = Convert.ToDouble(DS4.Tables[0].Rows[0]["LTA"]) * 12.0;
				dataRow3[48] = DS4.Tables[0].Rows[0]["Bonus"].ToString();
				dataRow3[49] = Convert.ToDouble(DS4.Tables[0].Rows[0]["Bonus"]) * 12.0;
				dataRow3[52] = Convert.ToDouble(DS4.Tables[0].Rows[0]["VehicleAllowance"]) * 12.0;
				double num26 = 0.0;
				double num27 = 0.0;
				double num28 = 0.0;
				string cmdText10 = fun.select("*", "tblHR_Offer_Accessories", "MId='" + Convert.ToInt32(DS4.Tables[0].Rows[0]["OfferId"]) + "'");
				SqlCommand selectCommand13 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter13.Fill(dataSet14);
				if (dataSet14.Tables[0].Rows.Count > 0)
				{
					for (int k = 0; k < dataSet14.Tables[0].Rows.Count; k++)
					{
						switch (dataSet14.Tables[0].Rows[k]["IncludesIn"].ToString())
						{
						case "1":
							num26 += Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Qty"]) * Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Amount"]);
							break;
						case "2":
							num27 += Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Qty"]) * Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Amount"]);
							break;
						case "3":
							num28 += Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Qty"]) * Convert.ToDouble(dataSet14.Tables[0].Rows[k]["Amount"]);
							break;
						}
					}
				}
				double num29 = 0.0;
				num29 = Math.Round(num18 + Convert.ToDouble(DS4.Tables[0].Rows[0]["ExGratia"]) + num27 + num28 - (num22 + num24));
				dataRow3[39] = Convert.ToDouble(decimal.Parse(num29.ToString()).ToString("N2"));
				double num30 = 0.0;
				dataRow3[40] = Convert.ToDouble(decimal.Parse(Math.Round(num29 + num20).ToString()).ToString("N2"));
				double num31 = 0.0;
				dataRow3[41] = Convert.ToDouble(decimal.Parse(Math.Round(num29 + num21).ToString()).ToString("N2"));
				double num32 = 0.0;
				num32 = Math.Round(num18 + Convert.ToDouble(DS4.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(DS4.Tables[0].Rows[0]["Loyalty"]) + Convert.ToDouble(DS4.Tables[0].Rows[0]["LTA"]) + num25 + num23 + Convert.ToDouble(DS4.Tables[0].Rows[0]["ExGratia"])) + num26 + num28;
				dataRow3[53] = Convert.ToDouble(decimal.Parse(num32.ToString()).ToString("N2"));
				dataRow3[54] = Convert.ToDouble(decimal.Parse(Math.Round(num32 * 12.0).ToString()).ToString("N2"));
				double num33 = 0.0;
				num33 = Math.Round(num32 + num20);
				dataRow3[55] = decimal.Parse(num33.ToString()).ToString("N2");
				dataRow3[56] = decimal.Parse(Math.Round(num33 * 12.0).ToString()).ToString("N2");
				double num34 = 0.0;
				num34 = Math.Round(num32 + num21);
				dataRow3[57] = decimal.Parse(num34.ToString()).ToString("N2");
				dataRow3[58] = decimal.Parse(Math.Round(num34 * 12.0).ToString()).ToString("N2");
				dataRow3[65] = DS4.Tables[0].Rows[0]["IncrementForTheYear"].ToString();
				dataRow3[66] = DS4.Tables[0].Rows[0]["EffectFrom"].ToString();
				double num35 = 0.0;
				string cmdText11 = fun.select("Grade,FinYearId", "tblHR_OfficeStaff", "OfferId='" + OfferId + "'");
				SqlCommand selectCommand14 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				DataSet dataSet15 = new DataSet();
				sqlDataAdapter14.Fill(dataSet15);
				if (dataSet15.Tables[0].Rows.Count > 0)
				{
					string cmdText12 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet15.Tables[0].Rows[0]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand15 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
					DataSet dataSet16 = new DataSet();
					sqlDataAdapter15.Fill(dataSet16);
					if (dataSet16.Tables[0].Rows.Count > 0)
					{
						dataRow3[67] = dataSet16.Tables[0].Rows[0]["FinYear"].ToString();
					}
					string cmdText13 = fun.select("Symbol", "tblHR_Grade", "Id='" + dataSet15.Tables[0].Rows[0]["Grade"].ToString() + "'");
					SqlCommand selectCommand16 = new SqlCommand(cmdText13, sqlConnection);
					SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
					DataSet dataSet17 = new DataSet();
					sqlDataAdapter16.Fill(dataSet17);
					if (dataSet17.Tables[0].Rows.Count > 0)
					{
						dataRow3[68] = dataSet17.Tables[0].Rows[0]["Symbol"].ToString();
					}
					dataRow3[69] = "GradeI*";
				}
				string cmdText14 = fun.select("Type", "tblHR_Designation", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Designation"]) + "'");
				SqlCommand selectCommand17 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
				DataSet dataSet18 = new DataSet();
				sqlDataAdapter17.Fill(dataSet18);
				if (dataSet18.Tables[0].Rows.Count > 0)
				{
					dataRow3[70] = dataSet18.Tables[0].Rows[0]["Type"].ToString();
				}
				dataRow3[71] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["ExGratia"]);
				dataRow3[72] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["VehicleAllowance"]);
				dataRow3[73] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["LTA"]);
				dataRow3[74] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Loyalty"]);
				num35 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["salary"]);
				dataRow3[75] = num35;
				dataRow3[76] = fun.Offer_Cal(num35, 1, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["StaffType"]));
				dataRow3[77] = fun.Offer_Cal(num35, 2, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[78] = fun.Offer_Cal(num35, 3, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[79] = fun.Offer_Cal(num35, 4, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[80] = fun.Offer_Cal(num35, 5, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
				dataRow3[81] = fun.Offer_Cal(num35, 6, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
				double num36 = 0.0;
				double num37 = 0.0;
				double num38 = 0.0;
				double num39 = 0.0;
				double num40 = 0.0;
				double num41 = 0.0;
				if (dataSet2.Tables[0].Rows[0]["StaffType"].ToString() != "5")
				{
					num36 = num35 * Convert.ToDouble(dataSet2.Tables[0].Rows[0]["AttBonusPer1"]) / 100.0;
					num37 = num35 * Convert.ToDouble(dataSet2.Tables[0].Rows[0]["AttBonusPer2"]) / 100.0;
					dataRow3[82] = num36;
					num38 = fun.Pf_Cal(num35, 1, Convert.ToDouble(dataSet2.Tables[0].Rows[0]["PFEmployee"]));
					dataRow3[87] = num38;
					num39 = fun.Pf_Cal(num35, 2, Convert.ToDouble(dataSet2.Tables[0].Rows[0]["PFCompany"]));
					dataRow3[88] = num39.ToString();
					num40 = fun.PTax_Cal(num35 + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["ExGratia"]), "0");
					dataRow3[90] = fun.Gratuity_Cal(num35, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
					num41 = fun.Gratuity_Cal(num35, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["TypeOf"]));
					dataRow3[83] = num37;
				}
				else
				{
					dataRow3[82] = 0;
					dataRow3[87] = 0;
					dataRow3[88] = 0;
					dataRow3[90] = 0;
				}
				dataRow3[89] = dataSet2.Tables[0].Rows[0]["Bonus"].ToString();
				double num42 = 0.0;
				double num43 = 0.0;
				double num44 = 0.0;
				string cmdText15 = fun.select("*", "tblHR_Increment_Accessories", "MId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]) + "'");
				SqlCommand selectCommand18 = new SqlCommand(cmdText15, sqlConnection);
				SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
				DataSet dataSet19 = new DataSet();
				sqlDataAdapter18.Fill(dataSet19);
				if (dataSet19.Tables[0].Rows.Count > 0)
				{
					for (int l = 0; l < dataSet19.Tables[0].Rows.Count; l++)
					{
						switch (dataSet19.Tables[0].Rows[l]["IncludesIn"].ToString())
						{
						case "1":
							num26 += Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Qty"]) * Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Amount"]);
							break;
						case "2":
							num27 += Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Qty"]) * Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Amount"]);
							break;
						case "3":
							num28 += Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Qty"]) * Convert.ToDouble(dataSet19.Tables[0].Rows[l]["Amount"]);
							break;
						}
					}
				}
				double num45 = 0.0;
				num45 = Math.Round(num35 + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["ExGratia"]) + num43 + num44 - (num38 + num40));
				dataRow3[84] = Convert.ToDouble(decimal.Parse(num45.ToString()).ToString("N2"));
				double num46 = 0.0;
				dataRow3[85] = Convert.ToDouble(decimal.Parse(Math.Round(num45 + num36).ToString()).ToString("N2"));
				double num47 = 0.0;
				dataRow3[86] = Convert.ToDouble(decimal.Parse(Math.Round(num45 + num37).ToString()).ToString("N2"));
				double num48 = 0.0;
				num48 = Math.Round(num35 + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Bonus"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Loyalty"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["LTA"]) + num41 + num39 + Convert.ToDouble(dataSet2.Tables[0].Rows[0]["ExGratia"])) + num42 + num44;
				dataRow3[91] = Convert.ToDouble(decimal.Parse(num48.ToString()).ToString("N2"));
				double num49 = 0.0;
				dataRow3[92] = decimal.Parse(Math.Round(num48 + num36).ToString()).ToString("N2");
				double num50 = 0.0;
				dataRow3[93] = decimal.Parse(Math.Round(num48 + num37).ToString()).ToString("N2");
				dataTable3.Rows.Add(dataRow3);
				dataTable3.AcceptChanges();
				dataTable4.Columns.Add(new DataColumn("Access_Perticulars", typeof(string)));
				dataTable4.Columns.Add(new DataColumn("Access_Amount", typeof(double)));
				string text4 = "";
				text4 = ((Increment != num) ? fun.select("Perticulars,(Qty*Amount)As Amount", "tblHR_Increment_Accessories", string.Concat("OfferMId='", dataSet2.Tables[0].Rows[0]["OfferId"], "'  And MId='", dataSet2.Tables[0].Rows[0]["Id"], "' ")) : fun.select("Perticulars,(Qty*Amount)As Amount", "tblHR_Offer_Accessories", string.Concat("MId='", DS4.Tables[0].Rows[0]["OfferId"], "'")));
				SqlCommand selectCommand19 = new SqlCommand(text4, sqlConnection);
				SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
				DataSet dataSet20 = new DataSet();
				sqlDataAdapter19.Fill(dataSet20);
				for (int m = 0; m < dataSet20.Tables[0].Rows.Count; m++)
				{
					DataRow dataRow4 = dataTable4.NewRow();
					if (dataSet20.Tables[0].Rows.Count > 0)
					{
						dataRow4[0] = dataSet20.Tables[0].Rows[m]["Perticulars"].ToString();
						dataRow4[1] = Convert.ToDouble(dataSet20.Tables[0].Rows[m]["Amount"]);
					}
					dataTable4.Rows.Add(dataRow4);
					dataTable4.AcceptChanges();
				}
				dataSet3.Tables.Add(dataTable3);
				dataSet3.Tables.Add(dataTable4);
				dataSet3.AcceptChanges();
				DataSet dataSet21 = new IncrementLetter();
				dataSet21.Tables[0].Merge(dataSet3.Tables[0]);
				dataSet21.Tables[1].Merge(dataSet3.Tables[1]);
				dataSet21.AcceptChanges();
				string text5 = base.Server.MapPath("~/Module/HR/Transactions/Reports/IncrementLetter.rpt");
				increreport.Load(text5);
				increreport.SetDataSource(dataSet21);
				((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = increreport;
				Session[Key] = increreport;
				((Control)(object)CrystalReportViewer2).Visible = true;
				((Control)(object)CrystalReportViewer1).Visible = false;
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
				dataSet2.Clear();
				dataSet2.Dispose();
				dataSet3.Clear();
				dataSet3.Dispose();
				dataTable3.Clear();
				dataTable3.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
		((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		try
		{
			increreport = new ReportDocument();
			report = new ReportDocument();
			Type = Convert.ToInt32(base.Request.QueryString["T"]);
			EType = Convert.ToInt32(base.Request.QueryString["EType"]);
			MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
			BGGroupId = Convert.ToInt32(base.Request.QueryString["BGGroupId"]);
			Key1 = base.Request.QueryString["Key1"];
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		switch (Type)
		{
		case 1:
			base.Response.Redirect("~/Module/HR/Transactions/OfferLetter_Print.aspx?ModId=12&SubModId=25");
			break;
		case 2:
			base.Response.Redirect("~/Module/HR/Transactions/Salary_SAPL_Neha_Summary.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + Key1 + "&ModId=12&SubModId=133");
			break;
		case 3:
			base.Response.Redirect("~/Module/HR/Transactions/All_Month_Summary_Report.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + Key1 + "&ModId=12&SubModId=133");
			break;
		case 4:
			base.Response.Redirect("~/Module/HR/Transactions/Consolidated_Summary_Report.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + Key1 + "&ModId=12&SubModId=133");
			break;
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		((Control)(object)CrystalReportViewer2).Dispose();
		CrystalReportViewer2 = null;
		increreport.Close();
		((Component)(object)increreport).Dispose();
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}
}

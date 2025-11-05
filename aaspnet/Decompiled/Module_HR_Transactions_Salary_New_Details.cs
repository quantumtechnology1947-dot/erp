using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_Salary_New_Details : Page, IRequiresSessionState
{
	protected DropDownList ddlMonth;

	protected Label lblDaysM;

	protected Label lblSunM;

	protected Label lblHolidayM;

	protected Label lblWDayM;

	protected Image Image1;

	protected Label lblNameOfEmployee;

	protected TextBox txtPresent;

	protected RequiredFieldValidator ReqtxtPresent;

	protected RegularExpressionValidator RegtxtPresent;

	protected Label lblBLoan;

	protected Label lblBalance;

	protected Label lblSCNo;

	protected TextBox txtAbsent;

	protected RequiredFieldValidator ReqtxtAbsent;

	protected RegularExpressionValidator RegtxtAbsent;

	protected TextBox txtInstallment;

	protected RequiredFieldValidator ReqtxtInstallment;

	protected RegularExpressionValidator RegtxtInstallment;

	protected Label lblDept;

	protected TextBox txtLateIn;

	protected RequiredFieldValidator ReqtxtLateIn;

	protected RegularExpressionValidator RegtxtLateIn;

	protected Label lblLimit;

	protected Label lblBill;

	protected TextBox txtMobExeAmt;

	protected RequiredFieldValidator ReqtxtMobExeAmt;

	protected RegularExpressionValidator RegtxtMobExeAmt;

	protected TextBox txtHalfDay;

	protected RequiredFieldValidator ReqtxtHalfDay;

	protected RegularExpressionValidator RegtxtHalfDay;

	protected TextBox txtAddition;

	protected RequiredFieldValidator ReqtxtAddition;

	protected RegularExpressionValidator RegtxtAddition;

	protected Label lblDesig;

	protected TextBox txtSunday;

	protected RequiredFieldValidator ReqtxtSunday;

	protected RegularExpressionValidator RegtxtSunday;

	protected TextBox txtRemarks1;

	protected Label lblGrade;

	protected TextBox txtCoff;

	protected RequiredFieldValidator ReqtxtCoff;

	protected RegularExpressionValidator RegtxtCoff;

	protected Label lblStatus;

	protected TextBox txtPL;

	protected RequiredFieldValidator ReqtxtPL;

	protected RegularExpressionValidator RegtxtPL;

	protected TextBox txtDeduction;

	protected RequiredFieldValidator ReqtxtDeduction;

	protected RegularExpressionValidator RegtxtDeduction;

	protected Label lblDutyHrs;

	protected TextBox txtOverTimeHrs;

	protected RequiredFieldValidator ReqtxtOverTimeHrs;

	protected RegularExpressionValidator RegtxtOverTimeHrs;

	protected TextBox txtRemarks2;

	protected Label lblEOTHrs;

	protected Label lblOverTimeRate;

	protected Label lblACNo;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Label lblPFNo;

	protected Label lblPANNo;

	protected Label lblEmail;

	protected HiddenField HFInc;

	protected Label lblMobNo;

	protected Button btnProceed;

	protected Button btnCancel;

	private SqlConnection con;

	private clsFunctions fun = new clsFunctions();

	private string MonthId = "";

	private string EId = "";

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string constr = "";

	private int CountSun;

	private int NoOfDays;

	private int OfferId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			constr = fun.Connection();
			con = new SqlConnection(constr);
			EId = base.Request.QueryString["EmpId"];
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			con.Open();
			if (!base.IsPostBack)
			{
				fun.GetMonth(ddlMonth, CompId, FinYearId);
				string text = "";
				text = ddlMonth.SelectedValue;
				int num = Convert.ToInt32(ddlMonth.SelectedValue);
				int year = fun.SalYrs(FinYearId, num, CompId);
				CountSun = fun.CountSundays(year, num);
				lblSunM.Text = CountSun.ToString();
				NoOfDays = DateTime.DaysInMonth(year, num);
				lblDaysM.Text = NoOfDays.ToString();
				lblHolidayM.Text = fun.GetHoliday(num, CompId, FinYearId).ToString();
				lblWDayM.Text = fun.WorkingDays(FinYearId, num).ToString();
				if (fun.WorkingDays(FinYearId, num) == 0)
				{
					btnProceed.Visible = false;
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Working days is not found for selected month.');", addScriptTags: true);
				}
				else
				{
					btnProceed.Visible = true;
				}
				lblBill.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 1).ToString();
				lblLimit.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 2).ToString();
				txtMobExeAmt.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 3).ToString();
				SalaryData(text);
				FillAccegrid(OfferId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			text = ddlMonth.SelectedValue;
			int num = Convert.ToInt32(ddlMonth.SelectedValue);
			int year = fun.SalYrs(FinYearId, num, CompId);
			CountSun = fun.CountSundays(year, num);
			lblSunM.Text = CountSun.ToString();
			NoOfDays = DateTime.DaysInMonth(year, num);
			lblDaysM.Text = NoOfDays.ToString();
			lblHolidayM.Text = fun.GetHoliday(num, CompId, FinYearId).ToString();
			lblWDayM.Text = fun.WorkingDays(FinYearId, num).ToString();
			if (fun.WorkingDays(FinYearId, num) == 0)
			{
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Working days is not found for selected month.');", addScriptTags: true);
				btnProceed.Visible = false;
			}
			else
			{
				btnProceed.Visible = true;
			}
			lblBill.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 1).ToString();
			lblLimit.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 2).ToString();
			txtMobExeAmt.Text = fun.MobileBillDetails(EId, FinYearId, CompId, num, 3).ToString();
			SalaryData(text);
			FillAccegrid(OfferId);
			string cmdText = fun.select("*", "tblHR_Salary_Master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "' AND EmpId='" + EId + "' AND FMonth='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblHR_Salary_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Salary for the selected month is already found.');", addScriptTags: true);
				btnProceed.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public void SalaryData(string MonthId)
	{
		try
		{
			string cmdText = fun.select("UserID,EmpId,OfferId,FinYearId,CompId,Title,EmployeeName,SwapCardNo,Department,Designation,Grade,MobileNo,CompanyEmail,BankAccountNo,PFNo,PANNo,PhotoData,PhotoFileName", "tblHR_OfficeStaff", "CompId='" + CompId + "'  and EmpId='" + EId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			OfferId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["OfferId"]);
			string cmdText2 = fun.select("MobileNo", "tblHR_CoporateMobileNo", "Id='" + dataSet.Tables[0].Rows[0]["MobileNo"].ToString() + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblHR_CoporateMobileNo");
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblMobNo.Text = dataSet2.Tables[0].Rows[0]["MobileNo"].ToString();
			}
			if (dataSet.Tables[0].Rows[0]["PhotoData"] != DBNull.Value && dataSet.Tables[0].Rows[0]["PhotoFileName"].ToString() != "")
			{
				Image1.ImageUrl = $"~/Handler1.ashx?EmpId={EId}&CompId={CompId}";
			}
			else
			{
				Image1.ImageUrl = "~/images/User.jpg";
			}
			string cmdText3 = fun.select("Title+'.'+' '+EmployeeName  as Name", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[0]["EmpId"].ToString() + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				lblNameOfEmployee.Text = dataSet3.Tables[0].Rows[0]["Name"].ToString() + " [" + dataSet.Tables[0].Rows[0]["EmpId"].ToString() + "]";
			}
			string cmdText4 = fun.select("SwapCardNo", "tblHR_SwapCard", "Id='" + dataSet.Tables[0].Rows[0]["SwapCardNo"].ToString() + "'");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4, "tblHR_SwapCard");
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				lblSCNo.Text = dataSet4.Tables[0].Rows[0]["SwapCardNo"].ToString();
			}
			string cmdText5 = fun.select("Description+' [ '+Symbol+' ]' AS Dept", "tblHR_Departments", "Id='" + dataSet.Tables[0].Rows[0]["Department"].ToString() + "'");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5, "tblHR_Departments");
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				lblDept.Text = dataSet5.Tables[0].Rows[0]["Dept"].ToString();
			}
			string cmdText6 = fun.select("Type+' [ '+Symbol+' ]' AS Designation", "tblHR_Designation", "Id='" + dataSet.Tables[0].Rows[0]["Designation"].ToString() + "'");
			SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
			DataSet dataSet6 = new DataSet();
			sqlDataAdapter6.Fill(dataSet6, "tblHR_Designation");
			if (dataSet6.Tables[0].Rows.Count > 0)
			{
				lblDesig.Text = dataSet6.Tables[0].Rows[0]["Designation"].ToString();
			}
			string cmdText7 = fun.select("Symbol AS Grade", "tblHR_Grade", "Id='" + dataSet.Tables[0].Rows[0]["Grade"].ToString() + "'");
			SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
			DataSet dataSet7 = new DataSet();
			sqlDataAdapter7.Fill(dataSet7, "tblHR_Grade");
			if (dataSet7.Tables[0].Rows.Count > 0)
			{
				lblGrade.Text = dataSet7.Tables[0].Rows[0]["Grade"].ToString();
			}
			lblACNo.Text = dataSet.Tables[0].Rows[0]["BankAccountNo"].ToString();
			lblPFNo.Text = dataSet.Tables[0].Rows[0]["PFNo"].ToString();
			lblPANNo.Text = dataSet.Tables[0].Rows[0]["PANNo"].ToString();
			lblEmail.Text = dataSet.Tables[0].Rows[0]["CompanyEmail"].ToString();
			string cmdText8 = fun.select("StaffType,TypeOf,DutyHrs,OTHrs,salary,OverTime,Increment", "tblHR_Offer_Master", "OfferId='" + dataSet.Tables[0].Rows[0]["OfferId"].ToString() + "'");
			SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
			DataSet dataSet8 = new DataSet();
			sqlDataAdapter8.Fill(dataSet8, "tblHR_Offer_Master");
			if (dataSet8.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			HFInc.Value = dataSet8.Tables[0].Rows[0]["Increment"].ToString();
			string cmdText9 = fun.select("Description", "tblHR_EmpType", "Id='" + dataSet8.Tables[0].Rows[0]["StaffType"].ToString() + "'");
			SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
			SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
			DataSet dataSet9 = new DataSet();
			sqlDataAdapter9.Fill(dataSet9, "tblHR_EmpType");
			if (dataSet9.Tables[0].Rows.Count > 0)
			{
				string text = "";
				if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]) == 1)
				{
					text = "SAPL - " + dataSet9.Tables[0].Rows[0]["Description"].ToString();
				}
				else if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["TypeOf"]) == 2)
				{
					text = "NEHA - " + dataSet9.Tables[0].Rows[0]["Description"].ToString();
				}
				lblStatus.Text = text;
			}
			string cmdText10 = fun.select("Hours", "tblHR_DutyHour", "Id='" + dataSet8.Tables[0].Rows[0]["DutyHrs"].ToString() + "'");
			SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
			SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
			DataSet dataSet10 = new DataSet();
			sqlDataAdapter10.Fill(dataSet10, "tblHR_DutyHour");
			if (dataSet10.Tables[0].Rows.Count > 0)
			{
				lblDutyHrs.Text = dataSet10.Tables[0].Rows[0]["Hours"].ToString();
			}
			string cmdText11 = fun.select("Hours", "tblHR_OTHour", "Id='" + dataSet8.Tables[0].Rows[0]["OTHrs"].ToString() + "'");
			SqlCommand selectCommand11 = new SqlCommand(cmdText11, con);
			SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
			DataSet dataSet11 = new DataSet();
			sqlDataAdapter11.Fill(dataSet11, "tblHR_OTHour");
			if (dataSet11.Tables[0].Rows.Count > 0)
			{
				lblEOTHrs.Text = dataSet11.Tables[0].Rows[0]["Hours"].ToString();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			string cmdText12 = fun.select("Sum(Amount) as LoanAmt,Sum(Installment) as InstAmt", "tblHR_BankLoan", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' And EmpId='" + EId + "'");
			SqlCommand selectCommand12 = new SqlCommand(cmdText12, con);
			SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
			DataSet dataSet12 = new DataSet();
			sqlDataAdapter12.Fill(dataSet12);
			if (dataSet12.Tables[0].Rows.Count > 0 && dataSet12.Tables[0].Rows[0]["LoanAmt"] != DBNull.Value && dataSet12.Tables[0].Rows[0]["InstAmt"] != DBNull.Value)
			{
				num = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["LoanAmt"]);
				num2 = Convert.ToDouble(dataSet12.Tables[0].Rows[0]["InstAmt"]);
			}
			string cmdText13 = fun.select("Sum(tblHR_Salary_Details.Installment) as Installment", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Master.Id= tblHR_Salary_Details.MId And tblHR_Salary_Master.CompId='" + CompId + "' And tblHR_Salary_Master.FinYearId<='" + FinYearId + "' And tblHR_Salary_Master.EmpId='" + EId + "'");
			SqlCommand selectCommand13 = new SqlCommand(cmdText13, con);
			SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
			DataSet dataSet13 = new DataSet();
			sqlDataAdapter13.Fill(dataSet13);
			if (dataSet13.Tables[0].Rows.Count > 0 && dataSet13.Tables[0].Rows[0]["Installment"] != DBNull.Value)
			{
				num3 = Convert.ToDouble(dataSet13.Tables[0].Rows[0]["Installment"]);
			}
			lblBLoan.Text = num.ToString();
			if (num - num3 > 0.0)
			{
				txtInstallment.Text = num2.ToString();
			}
			else
			{
				txtInstallment.Text = "0";
			}
			lblBalance.Text = num3.ToString();
			string cmdText14 = fun.select("Description", "tblHR_OverTime", "Id='" + dataSet8.Tables[0].Rows[0]["OverTime"].ToString() + "'");
			SqlCommand selectCommand14 = new SqlCommand(cmdText14, con);
			SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
			DataSet dataSet14 = new DataSet();
			sqlDataAdapter14.Fill(dataSet14, "tblHR_OverTime");
			string text2 = "";
			if (dataSet14.Tables[0].Rows.Count > 0)
			{
				if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["OverTime"]) == 2)
				{
					double num4 = 0.0;
					text2 = Math.Round(fun.OTRate(Convert.ToDouble(dataSet8.Tables[0].Rows[0]["salary"]), Convert.ToDouble(dataSet11.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet10.Tables[0].Rows[0]["Hours"].ToString()), NoOfDays), 2).ToString();
				}
				else
				{
					text2 = dataSet14.Tables[0].Rows[0]["Description"].ToString();
				}
			}
			lblOverTimeRate.Text = text2;
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("Salary_New.aspx?ModId=12&SubModId=133");
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			if (ddlMonth.SelectedValue != "0")
			{
				string cmdText = fun.insert("tblHR_Salary_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId ,FMonth,Increment", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + EId + "','" + ddlMonth.SelectedValue + "','" + Convert.ToInt32(HFInc.Value) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("Id", "tblHR_Salary_Master", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' order by Id DESC");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblHR_Salary_Master");
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					return;
				}
				if (txtPresent.Text != "" && fun.NumberValidationQty(txtPresent.Text) && txtAbsent.Text != "" && fun.NumberValidationQty(txtAbsent.Text) && txtLateIn.Text != "" && fun.NumberValidationQty(txtLateIn.Text) && txtHalfDay.Text != "" && fun.NumberValidationQty(txtHalfDay.Text) && txtSunday.Text != "" && fun.NumberValidationQty(txtSunday.Text) && txtCoff.Text != "" && fun.NumberValidationQty(txtCoff.Text) && txtPL.Text != "" && fun.NumberValidationQty(txtPL.Text) && txtOverTimeHrs.Text != "" && fun.NumberValidationQty(txtOverTimeHrs.Text) && txtInstallment.Text != "" && fun.NumberValidationQty(txtInstallment.Text) && txtMobExeAmt.Text != "" && fun.NumberValidationQty(txtMobExeAmt.Text) && txtAddition.Text != "" && fun.NumberValidationQty(txtAddition.Text) && txtDeduction.Text != "" && fun.NumberValidationQty(txtDeduction.Text))
				{
					double num = 0.0;
					if (fun.NumberValidationQty(lblOverTimeRate.Text))
					{
						num = Convert.ToDouble(lblOverTimeRate.Text);
					}
					string cmdText3 = fun.insert("tblHR_Salary_Details", "MId,Present,Absent,LateIn,HalfDay,Sunday,Coff,PL,OverTimeHrs, OverTimeRate,Installment,MobileExeAmt,Addition,Remarks1,Deduction ,Remarks2", "'" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]) + "','" + Convert.ToDouble(txtPresent.Text) + "','" + Convert.ToDouble(txtAbsent.Text) + "','" + Convert.ToDouble(txtLateIn.Text) + "','" + Convert.ToDouble(txtHalfDay.Text) + "','" + Convert.ToDouble(txtSunday.Text) + "','" + Convert.ToDouble(txtCoff.Text) + "','" + Convert.ToDouble(txtPL.Text) + "','" + Convert.ToDouble(txtOverTimeHrs.Text) + "','" + num + "','" + Convert.ToDouble(txtInstallment.Text) + "','" + Convert.ToDouble(txtMobExeAmt.Text) + "','" + Convert.ToDouble(txtAddition.Text) + "','" + txtRemarks1.Text + "','" + Convert.ToDouble(txtDeduction.Text) + "','" + txtRemarks2.Text + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("Salary_New.aspx?ModId=12&SubModId=133");
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Please Select Month";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillAccegrid(int OfferId)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			new DataTable();
			string cmdText = fun.select("[Id],[MId],[Perticulars],[Qty],[Amount],Round(([Qty]*[Amount]),2)As Total,IncludesIn", "tblHR_Offer_Accessories", "MId='" + OfferId + "' Order by Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				string text = ((Label)row.FindControl("lblIncludesInId")).Text;
				string cmdText2 = fun.select("*", "tblHR_IncludesIn", "Id='" + text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				((Label)row.FindControl("lblIncludesIn")).Text = dataSet2.Tables[0].Rows[0]["IncludesIn"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}
}

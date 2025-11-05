using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_Salary_BankStatement_Check : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private int MonthId = 4;

	private string ChequeNo = "";

	private string ChequeDate = "";

	private int BankId;

	private string EmpDirect = "";

	private int BGGroupId;

	protected CheckBox chkAll;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button btnSubmit;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			BGGroupId = Convert.ToInt32(base.Request.QueryString["BGGroupId"]);
			MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["ChequeNo"]))
			{
				ChequeNo = base.Request.QueryString["ChequeNo"];
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["ChequeDate"]))
			{
				ChequeDate = base.Request.QueryString["ChequeDate"];
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["BankId"]))
			{
				BankId = Convert.ToInt32(base.Request.QueryString["BankId"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["EmpDirect"]))
			{
				EmpDirect = base.Request.QueryString["EmpDirect"];
			}
			if (!Page.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			int year = fun.SalYrs(FinYearId, MonthId, CompId);
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Month", typeof(string)));
			dataTable.Columns.Add(new DataColumn("NetPay", typeof(double)));
			dataTable.Columns.Add(new DataColumn("EmpACNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			new DataSet();
			sqlConnection.Open();
			string empty = string.Empty;
			string text = string.Empty;
			switch (EmpDirect)
			{
			case "0":
				text = "AND tblHR_OfficeStaff.Designation Not In('2','3','4','6','13')";
				break;
			case "1":
				text = "AND tblHR_OfficeStaff.Designation In('2','3','4','6','13')";
				break;
			}
			empty = ((BGGroupId != 1) ? fun.select("tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.FMonth ='" + MonthId + "'AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='1' AND tblHR_Salary_Master.ReleaseFlag='0' AND tblHR_OfficeStaff.BGGroup ='" + BGGroupId + "'" + text) : fun.select("tblHR_Salary_Master.EmpId,tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.OfferId As StaffOfferId,tblHR_OfficeStaff.EmpId As StaffEmpId, tblHR_OfficeStaff.FinYearId ,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.BankAccountNo,tblHR_OfficeStaff.PFNo,tblHR_OfficeStaff.PANNo", "tblHR_Offer_Master,tblHR_OfficeStaff,tblHR_Salary_Master", "tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId = tblHR_Salary_Master.EmpId AND tblHR_Salary_Master.FMonth ='" + MonthId + "'AND tblHR_Salary_Master.CompId ='" + CompId + "' AND tblHR_Salary_Master.FinYearId ='" + FinYearId + "' AND tblHR_Offer_Master.TypeOf='1' AND tblHR_Salary_Master.ReleaseFlag='0'" + text));
			SqlCommand selectCommand = new SqlCommand(empty, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				double num = 0.0;
				num = DateTime.DaysInMonth(FinYearId, MonthId);
				dataRow[0] = dataSet.Tables[0].Rows[i]["StaffEmpId"].ToString();
				dataRow[1] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
				dataRow[2] = dataSet.Tables[0].Rows[i]["Title"].ToString() + ". " + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
				dataRow[3] = MonthId;
				dataRow[6] = FinYearId;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				string cmdText = fun.select("Increment", "tblHR_Salary_Master", "EmpId='" + dataSet.Tables[0].Rows[i]["EmpId"].ToString() + "' AND FMonth='" + MonthId + "' AND FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblHR_Salary_Master");
				string cmdText2 = fun.select("Increment", "tblHR_Offer_Master", "OfferId='" + dataSet.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string empty2 = string.Empty;
				empty2 = ((Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Increment"])) ? fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment,Id", "tblHR_Increment_Master", "OfferId='" + dataSet.Tables[0].Rows[i]["StaffOfferId"].ToString() + "' AND Increment='" + dataSet2.Tables[0].Rows[0]["Increment"].ToString() + "'") : fun.select("OfferId,StaffType,TypeOf,salary,DutyHrs,OTHrs,OverTime,Designation,ExGratia,VehicleAllowance,LTA,Loyalty,PaidLeaves,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,Increment", "tblHR_Offer_Master", "OfferId='" + dataSet.Tables[0].Rows[i]["StaffOfferId"].ToString() + "'"));
				SqlCommand selectCommand4 = new SqlCommand(empty2, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num8 = Convert.ToInt32(dataSet4.Tables[0].Rows[0]["Salary"]);
					num2 = fun.Offer_Cal(num8, 1, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["StaffType"]));
					num3 = fun.Offer_Cal(num8, 2, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["TypeOf"]));
					num4 = fun.Offer_Cal(num8, 3, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["TypeOf"]));
					num5 = fun.Offer_Cal(num8, 4, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["TypeOf"]));
					num6 = fun.Offer_Cal(num8, 5, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["TypeOf"]));
					num7 = fun.Offer_Cal(num8, 6, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["TypeOf"]));
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
					double num29 = 0.0;
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
					string cmdText3 = fun.select("tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Remarks1,tblHR_Salary_Details.Deduction,tblHR_Salary_Details.Remarks2", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + dataSet.Tables[0].Rows[i]["EmpId"].ToString() + "' AND tblHR_Salary_Master.FMonth='" + MonthId + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						fun.WorkingDays(FinYearId, MonthId);
						num12 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Present"]);
						num13 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Absent"]);
						num14 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["PL"]);
						num15 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Coff"]);
						num16 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["HalfDay"]);
						num17 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Sunday"]);
						num18 = fun.CountSundays(year, MonthId);
						num19 = fun.GetHoliday(MonthId, CompId, FinYearId);
						num29 = Convert.ToInt32(dataSet4.Tables[0].Rows[0]["AttBonusPer1"]);
						num30 = Convert.ToInt32(dataSet4.Tables[0].Rows[0]["AttBonusPer2"]);
						num31 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["ExGratia"]);
						num40 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["VehicleAllowance"]);
						num41 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Addition"]);
						num42 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Deduction"]);
						num10 = num - (num13 - (num14 + num15));
						num11 = num12 + num17 + num16;
						num20 = Math.Round(num2 * num10 / num);
						num21 = Math.Round(num3 * num10 / num);
						num22 = Math.Round(num4 * num10 / num);
						num23 = Math.Round(num5 * num10 / num);
						num24 = Math.Round(num6 * num10 / num);
						num25 = Math.Round(num7 * num10 / num);
						num26 = Math.Round(num20 + num21 + num22 + num23 + num24 + num25);
						num9 = fun.Pf_Cal(num26, 1, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["PFEmployee"]));
						num27 = num9;
						num32 = Math.Round(num31 * num10 / num);
						num45 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Installment"]);
						num46 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["MobileExeAmt"]);
						string empty3 = string.Empty;
						empty3 = ((Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Increment"]) != Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Increment"])) ? fun.select("Qty,Amount,IncludesIn", "tblHR_Increment_Accessories", "MId='" + dataSet4.Tables[0].Rows[0]["Id"].ToString() + "'") : fun.select("Qty,Amount,IncludesIn", "tblHR_Offer_Accessories", "MId='" + dataSet4.Tables[0].Rows[0]["OfferId"].ToString() + "'"));
						SqlCommand selectCommand6 = new SqlCommand(empty3, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						for (int j = 0; j < dataSet6.Tables[0].Rows.Count; j++)
						{
							switch (dataSet6.Tables[0].Rows[j]["IncludesIn"].ToString())
							{
							case "1":
								num38 += Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Amount"]);
								break;
							case "2":
								num37 += Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Amount"]);
								break;
							case "3":
								num39 += Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet6.Tables[0].Rows[j]["Amount"]);
								break;
							}
						}
						if (dataSet4.Tables[0].Rows[0]["OverTime"].ToString() == "2")
						{
							double num47 = 0.0;
							string cmdText4 = fun.select("Hours", "tblHR_OTHour", "Id='" + dataSet4.Tables[0].Rows[0]["OTHrs"].ToString() + "'");
							SqlCommand selectCommand7 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter7.Fill(dataSet7, "tblHR_OTHour");
							string cmdText5 = fun.select("Hours", "tblHR_DutyHour", "Id='" + dataSet4.Tables[0].Rows[0]["DutyHrs"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter8.Fill(dataSet8, "tblHR_DutyHour");
							num47 = fun.OTRate(num8, Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Hours"]), Convert.ToDouble(dataSet8.Tables[0].Rows[0]["Hours"]), num);
							num33 = Math.Round(fun.OTAmt(num47, Convert.ToDouble(dataSet5.Tables[0].Rows[0]["OverTimeHrs"])));
						}
						if (num11 >= num - (num19 + num18 + 2.0) && num11 < num + 2.0 - (num19 + num18))
						{
							num28 = Math.Round(num8 * num29 / 100.0);
						}
						else if (num11 >= num + 2.0 - (num19 + num18))
						{
							num28 = Math.Round(num8 * num30 / 100.0);
						}
						num35 = Math.Round(num40 + num37 + num39 + num33 + num41);
						num34 = fun.PTax_Cal(num26 + num28 + num37 + num39 + num32 + num40 + num41 + num33, MonthId.ToString("D2"));
						num36 = num42;
						num44 = Math.Round(num27 + num34 + num45 + num46 + num36);
						num43 = num26 + num28 + num32 + num35;
						dataRow[4] = Math.Round(num43 - num44);
					}
				}
				dataRow[5] = dataSet.Tables[0].Rows[i]["BankAccountNo"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Salary_Print.aspx?MonthId=" + MonthId + "&ModId=12&SubModId=133");
	}

	protected void chkAll_CheckedChanged(object sender, EventArgs e)
	{
		if (chkAll.Checked)
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				((CheckBox)row.FindControl("CheckBox1")).Checked = true;
			}
			return;
		}
		foreach (GridViewRow row2 in GridView2.Rows)
		{
			((CheckBox)row2.FindControl("CheckBox1")).Checked = false;
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("TransNo", "tblHR_Salary_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by TransNo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblHR_Salary_Master");
			int num = 0;
			num = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0][0] == DBNull.Value) ? 1 : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1));
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					string text = ((Label)row.FindControl("lblEmpId")).Text;
					int num2 = Convert.ToInt16(((Label)row.FindControl("lblCompId")).Text);
					int num3 = Convert.ToInt16(((Label)row.FindControl("lblFinYearId")).Text);
					int num4 = Convert.ToInt16(((Label)row.FindControl("lblMonth")).Text);
					string cmdText2 = fun.update("tblHR_Salary_Master", "ReleaseFlag='1',ChequeNo='" + ChequeNo + "',ChequeNoDate='" + fun.FromDate(ChequeDate) + "',BankId='" + BankId + "',EmpDirect='" + EmpDirect + "',TransNo='" + num + "'", " CompId='" + num2 + "'  And  FinYearId='" + num3 + "' And  EmpId='" + text + "' And  FMonth='" + num4 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
			}
			sqlConnection.Close();
			loaddata();
		}
		catch (Exception)
		{
		}
	}
}

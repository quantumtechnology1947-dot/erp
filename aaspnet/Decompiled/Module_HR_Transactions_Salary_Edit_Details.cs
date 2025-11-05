using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_Salary_Edit_Details : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string EmpId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			EmpId = base.Request.QueryString["EmpId"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				binddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void binddata()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Month", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DaysOfMonth", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Holidays", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MonthSunday", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WorkingDays", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Present", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Absent", typeof(string)));
			dataTable.Columns.Add(new DataColumn("LateIn", typeof(string)));
			dataTable.Columns.Add(new DataColumn("HalfDay", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Sunday", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Coff", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PL", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OverTimeHrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OverTimeRate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankLoan", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Installment", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MobileExeAmt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Addition", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Deduction", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Mon", typeof(int)));
			string cmdText = fun.select("tblHR_Salary_Master.EmpId,tblHR_Salary_Details.Id,tblHR_Salary_Details.MId,tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Deduction,tblHR_Salary_Master.FMonth", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + EmpId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = fun.select("tblHR_Offer_Master.salary,tblHR_Offer_Master.DutyHrs,tblHR_Offer_Master.OTHrs", "tblHR_Offer_Master,tblHR_OfficeStaff", "tblHR_Offer_Master.OfferId=tblHR_OfficeStaff.OfferId AND tblHR_OfficeStaff.EmpId='" + dataSet.Tables[0].Rows[i]["EmpId"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				int num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FMonth"]);
				int year = fun.SalYrs(FinYearId, num, CompId);
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(dataSet.Tables[0].Rows[i]["FMonth"]));
				dataRow[2] = DateTime.DaysInMonth(year, num);
				dataRow[3] = fun.GetHoliday(num, CompId, FinYearId).ToString();
				dataRow[4] = fun.CountSundays(year, num);
				dataRow[5] = fun.WorkingDays(FinYearId, num).ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Present"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Absent"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["LateIn"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["HalfDay"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["Sunday"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["Coff"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["PL"].ToString();
				dataRow[13] = dataSet.Tables[0].Rows[i]["OverTimeHrs"].ToString();
				dataRow[14] = dataSet.Tables[0].Rows[i]["OverTimeRate"].ToString();
				double num2 = 0.0;
				string cmdText3 = fun.select("Sum(Amount) as LoanAmt", "tblHR_BankLoan", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' And EmpId='" + EmpId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["LoanAmt"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["LoanAmt"]);
				}
				dataRow[15] = num2;
				dataRow[16] = dataSet.Tables[0].Rows[i]["Installment"].ToString();
				dataRow[17] = dataSet.Tables[0].Rows[i]["MobileExeAmt"].ToString();
				dataRow[18] = dataSet.Tables[0].Rows[i]["Addition"].ToString();
				dataRow[19] = dataSet.Tables[0].Rows[i]["Deduction"].ToString();
				dataRow[20] = dataSet.Tables[0].Rows[i]["MId"].ToString();
				dataRow[21] = dataSet.Tables[0].Rows[i]["FMonth"].ToString();
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			binddata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = "";
				string text2 = "";
				string text3 = "";
				text = ((Label)gridViewRow.FindControl("lblId")).Text;
				text2 = ((Label)gridViewRow.FindControl("lblMId")).Text;
				text3 = ((Label)gridViewRow.FindControl("lblMon")).Text;
				if (text != "" && text2 != "" && text3 != "" && EmpId != "")
				{
					base.Response.Redirect("Salary_Edit_Details_Emp.aspx?DId=" + text + "&MId=" + text2 + "&Mon=" + text3 + "&EmpId=" + EmpId + "&ModId=12&SubModId=133");
				}
			}
		}
		catch (Exception)
		{
		}
		sqlConnection.Close();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Salary_Edit.aspx?ModId=12&SubModId=133");
	}
}

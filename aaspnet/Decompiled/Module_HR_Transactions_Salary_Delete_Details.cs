using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_Salary_Delete_Details : Page, IRequiresSessionState
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
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
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
			string cmdText = fun.select("tblHR_Salary_Details.Id,tblHR_Salary_Details.MId,tblHR_Salary_Details.Present,tblHR_Salary_Details.Absent,tblHR_Salary_Details.LateIn,tblHR_Salary_Details.HalfDay,tblHR_Salary_Details.Sunday,tblHR_Salary_Details.Coff,tblHR_Salary_Details.PL,tblHR_Salary_Details.OverTimeHrs,tblHR_Salary_Details.OverTimeRate,tblHR_Salary_Details.Installment,tblHR_Salary_Details.MobileExeAmt,tblHR_Salary_Details.Addition,tblHR_Salary_Details.Deduction,tblHR_Salary_Master.FMonth", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + EmpId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				int num = Convert.ToInt32(sqlDataReader["FMonth"]);
				int year = fun.SalYrs(FinYearId, num, CompId);
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(sqlDataReader["FMonth"]));
				dataRow[2] = DateTime.DaysInMonth(year, num);
				dataRow[3] = fun.GetHoliday(num, CompId, FinYearId).ToString();
				dataRow[4] = fun.CountSundays(year, num);
				dataRow[5] = fun.WorkingDays(FinYearId, num).ToString();
				dataRow[6] = sqlDataReader["Present"].ToString();
				dataRow[7] = sqlDataReader["Absent"].ToString();
				dataRow[8] = sqlDataReader["LateIn"].ToString();
				dataRow[9] = sqlDataReader["HalfDay"].ToString();
				dataRow[10] = sqlDataReader["Sunday"].ToString();
				dataRow[11] = sqlDataReader["Coff"].ToString();
				dataRow[12] = sqlDataReader["PL"].ToString();
				dataRow[13] = sqlDataReader["OverTimeHrs"].ToString();
				dataRow[14] = sqlDataReader["OverTimeRate"].ToString();
				double num2 = 0.0;
				string cmdText2 = fun.select("Sum(Amount) as LoanAmt", "tblHR_BankLoan", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' And EmpId='" + EmpId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				while (sqlDataReader2.Read())
				{
					if (Convert.ToDouble(sqlDataReader2["LoanAmt"]) > 0.0 && sqlDataReader2["LoanAmt"] != DBNull.Value)
					{
						num2 = Convert.ToDouble(sqlDataReader2["LoanAmt"]);
					}
				}
				dataRow[15] = num2;
				dataRow[16] = sqlDataReader["Installment"].ToString();
				dataRow[17] = sqlDataReader["MobileExeAmt"].ToString();
				dataRow[18] = sqlDataReader["Addition"].ToString();
				dataRow[19] = sqlDataReader["Deduction"].ToString();
				dataRow[20] = sqlDataReader["MId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
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
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblMId")).Text;
				string cmdText = fun.delete("tblHR_Salary_Details", "MId='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.delete("tblHR_Salary_Master", "Id='" + text + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				binddata();
			}
		}
		catch (Exception)
		{
		}
		sqlConnection.Close();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Salary_Delete.aspx?ModId=12&SubModId=133");
	}
}

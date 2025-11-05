using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class _Default : Page, IRequiresSessionState
{
	protected Label lblSalary;

	protected Label Label3;

	protected DropDownList ddlMonth;

	protected Button btnProceed;

	protected Label Label2;

	protected TextBox TextBox1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = string.Empty;

	private SqlConnection conn;

	private int CompId;

	private string SId = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		connStr = fun.Connection();
		conn = new SqlConnection(connStr);
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		if (!base.IsPostBack)
		{
			ddlMonth.Items.Clear();
			fun.GetMonth(ddlMonth, CompId, FinYearId);
			string selectedValue = DateTime.Now.Month.ToString();
			ddlMonth.SelectedValue = selectedValue;
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
	}

	protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			conn.Open();
			string empty = string.Empty;
			empty = ddlMonth.SelectedValue;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			string cmdText = fun.select("Count(*) As Cnt", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + SId + "' AND tblHR_Salary_Master.FMonth='" + empty + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				if (Convert.ToDouble(sqlDataReader[0]) > 0.0)
				{
					base.Response.Redirect("~/Module/SysSupport/Salary_Print_Details.aspx?EmpId=" + SId + "&MonthId=" + empty + "&Key=" + randomAlphaNumeric + "&BackURL=0&ModId=12&SubModId=133");
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "No Record Found!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			conn.Close();
		}
	}
}

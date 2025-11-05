using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_TourVoucher_Print_Details : Page, IRequiresSessionState
{
	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	private int id;

	private int TIMid;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			TIMid = Convert.ToInt32(base.Request.QueryString["TIMId"]);
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TourVoucher_Print.aspx?ModId=11&SubModId=126");
	}
}

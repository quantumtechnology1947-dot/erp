using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_CurrentLiabilities : Page, IRequiresSessionState
{
	protected Label Label5;

	protected Label Label2;

	protected Label Label3;

	protected Label Label4;

	protected LinkButton LinkButton1;

	protected Label lblDeb_SuCr;

	protected Label lblCrd_SuCr;

	protected Label Label6;

	protected Label lblDeb_SuCr0;

	protected Label lblCrd_SuCr0;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				lblDeb_SuCr.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "")).ToString();
				lblDeb_SuCr0.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "")).ToString();
				lblCrd_SuCr.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 1, "") + fun.FillGrid_Creditors(CompId, FinYearId, 2, "")).ToString();
				lblCrd_SuCr0.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 1, "") + fun.FillGrid_Creditors(CompId, FinYearId, 2, "")).ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/BalanceSheet.aspx?ModId=&SubModId=");
	}
}

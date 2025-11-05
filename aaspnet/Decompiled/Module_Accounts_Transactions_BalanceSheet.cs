using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_BalanceSheet : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private ACC_CurrentAssets acc = new ACC_CurrentAssets();

	protected Label Label2;

	protected LinkButton LinkButton2;

	protected Label Amt_CapitalGood;

	protected LinkButton LinkButton3;

	protected Label Amt_LoanLiability;

	protected LinkButton LinkButton1;

	protected Label Amt_CurrentLiab;

	protected LinkButton LinkButton4;

	protected LinkButton LinkButton5;

	protected LinkButton LinkButton6;

	protected Label Label4;

	protected Label Amt_CurrentLiab0;

	protected Label Label3;

	protected LinkButton LinkButton7;

	protected LinkButton LinkButton8;

	protected LinkButton LinkButton9;

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
			double num = 0.0;
			if (!Page.IsPostBack)
			{
				num = fun.FillGrid_Creditors(CompId, FinYearId, 4, "");
				Amt_CurrentLiab.Text = num.ToString();
				Amt_CurrentLiab0.Text = num.ToString();
				Amt_LoanLiability.Text = acc.TotLoanLiability(CompId, FinYearId).ToString();
				Amt_CapitalGood.Text = acc.TotCapitalGoods(CompId, FinYearId).ToString();
			}
		}
		catch (Exception)
		{
		}
	}
}

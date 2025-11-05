using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Acc_Bal_CurrAssets : Page, IRequiresSessionState
{
	protected Label Label2;

	protected LinkButton LnkClosingStk;

	protected Label lblClStock;

	protected LinkButton LnkDeposit;

	protected LinkButton LnkLnA;

	protected LinkButton lnkSundry;

	protected Label lblSD_dr;

	protected Label lblSD_cr;

	protected LinkButton LnkCash;

	protected LinkButton lnkBAcc;

	protected LinkButton lnkBWTA;

	protected LinkButton lnkPE;

	protected LinkButton lnkAI;

	protected LinkButton lnkTDSRFS;

	protected Label Label4;

	protected Label Amt_CurrentLiab0;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			ACC_CurrentAssets aCC_CurrentAssets = new ACC_CurrentAssets();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblClStock.Text = fun.ClStk().ToString();
			double num = 0.0;
			num = fun.DebitorsOpeningBal(CompId, "");
			double num2 = 0.0;
			num2 = Convert.ToDouble(aCC_CurrentAssets.TotInvQty2(CompId, FinYearId, "").Compute("Sum(TotAmt)", ""));
			lblSD_dr.Text = (num2 + num).ToString();
			lblSD_cr.Text = fun.getDebitorCredit(CompId, FinYearId, "").ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}

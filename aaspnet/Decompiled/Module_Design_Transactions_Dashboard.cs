using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using ASP;

public class Module_Design_Transactions_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int FinYear;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_SPR_Clearance : Page, IRequiresSessionState
{
	protected RadioButton RadioButton2;

	protected TextBox TextBox1;

	protected RadioButton RadioButton1;

	protected Button Button1;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}
}

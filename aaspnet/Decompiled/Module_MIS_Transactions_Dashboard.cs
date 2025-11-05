using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MIS_Transactions_Dashboard : Page, IRequiresSessionState
{
	protected GridView GridView3;

	protected SqlDataSource LocalSqlServer0;

	protected Label Label1;

	protected TabPanel TabPanel1;

	protected GridView GridView2;

	protected SqlDataSource LocalSqlServer;

	protected Label lblMessage;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
	}

	protected void GridView3_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
	}

	protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}

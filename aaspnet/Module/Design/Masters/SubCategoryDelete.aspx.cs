using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_SubCategoryDelete : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationDelete();");
		}
	}
}

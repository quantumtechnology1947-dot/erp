using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_SubCategoryEdit : Page, IRequiresSessionState
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

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Update")
		{
			int index = Convert.ToInt32(e.CommandArgument);
			GridViewRow gridViewRow = GridView1.Rows[index];
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddCategory1");
			string selectedValue = dropDownList.SelectedValue;
			string defaultValue = selectedValue;
			LocalSqlServer.UpdateParameters["CId"].DefaultValue = defaultValue;
			LocalSqlServer.Update();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
		}
	}
}

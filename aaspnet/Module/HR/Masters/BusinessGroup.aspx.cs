using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_BusinessGroup : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected Label lblMessage;

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

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Add")
		{
			string text = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
			string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtsymbol")).Text;
			string text3 = ((TextBox)GridView1.FooterRow.FindControl("txtincharge")).Text;
			if (text != "" && text2 != "" && text3 != "")
			{
				LocalSqlServer.InsertParameters["Name"].DefaultValue = text;
				LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2;
				LocalSqlServer.InsertParameters["Incharge"].DefaultValue = text3;
				LocalSqlServer.Insert();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
	}

	protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
	{
		lblMessage.Text = "Record Inserted";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}
}

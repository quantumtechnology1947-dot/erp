using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_ClosingStock : Page, IRequiresSessionState
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
		lblMessage.Text = "Record Updated.";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtFrom")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtTo")).Text;
				string text3 = ((TextBox)GridView1.FooterRow.FindControl("txtClStk")).Text;
				if (text != "" && text2 != "" && text3 != "")
				{
					LocalSqlServer.InsertParameters["FromDt"].DefaultValue = text;
					LocalSqlServer.InsertParameters["ToDt"].DefaultValue = text2;
					LocalSqlServer.InsertParameters["Stock"].DefaultValue = text3;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtFrom")).Text;
				string text5 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTo")).Text;
				string text6 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtClStk")).Text;
				if (text4 != "" && text5 != "" && text6 != "")
				{
					LocalSqlServer.InsertParameters["FromDt"].DefaultValue = text4;
					LocalSqlServer.InsertParameters["ToDt"].DefaultValue = text5;
					LocalSqlServer.InsertParameters["Stock"].DefaultValue = text6;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
			if (GridView1.Rows.Count == 0)
			{
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtFrom")).Attributes.Add("readonly", "readonly");
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTo")).Attributes.Add("readonly", "readonly");
			}
			else
			{
				((TextBox)GridView1.FooterRow.FindControl("txtFrom")).Attributes.Add("readonly", "readonly");
				((TextBox)GridView1.FooterRow.FindControl("txtTo")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}
}

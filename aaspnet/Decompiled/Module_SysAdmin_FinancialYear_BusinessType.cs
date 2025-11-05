using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_FinancialYear_BusinessType : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtBusinessType")).Text;
				if (text != "")
				{
					SqlDataSource1.InsertParameters["Type"].DefaultValue = text;
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtBusinessType")).Text;
				if (text2 != "")
				{
					SqlDataSource1.InsertParameters["Type"].DefaultValue = text2;
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
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

using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_SwapCard_No : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label Label2;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Label2.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtSwapCardNo")).Text;
				if (text != "")
				{
					SqlDataSource1.InsertParameters["SwapCardNo"].DefaultValue = text;
					SqlDataSource1.Insert();
					Label2.Text = "Record inserted.";
				}
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSwapCardNo")).Text;
				if (text2 != "")
				{
					SqlDataSource1.InsertParameters["SwapCardNo"].DefaultValue = text2;
					SqlDataSource1.Insert();
					Label2.Text = "Record inserted.";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		Label2.Text = "Record deleted.";
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		Label2.Text = "Record updated.";
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
		}
		catch (Exception)
		{
		}
	}
}

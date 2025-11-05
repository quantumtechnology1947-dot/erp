using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_ItemRevision : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Label lblmsg;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblmsg.Text = "";
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string defaultValue = Session["compid"].ToString();
			string defaultValue2 = Session["finyear"].ToString();
			string defaultValue3 = Session["username"].ToString();
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView2.FooterRow.FindControl("txtTypes")).Text;
				SqlDataSource1.InsertParameters["Types"].DefaultValue = text;
				SqlDataSource1.InsertParameters["sysdate"].DefaultValue = currDate;
				SqlDataSource1.InsertParameters["systime"].DefaultValue = currTime;
				SqlDataSource1.InsertParameters["compid"].DefaultValue = defaultValue;
				SqlDataSource1.InsertParameters["finyearid"].DefaultValue = defaultValue2;
				SqlDataSource1.InsertParameters["sessionid"].DefaultValue = defaultValue3;
				if (text != "")
				{
					SqlDataSource1.Insert();
					lblmsg.Text = "Record Inserted.";
				}
			}
			if (e.CommandName == "Update")
			{
				SqlDataSource1.UpdateParameters["sysdate"].DefaultValue = currDate;
				SqlDataSource1.UpdateParameters["systime"].DefaultValue = currTime;
				SqlDataSource1.UpdateParameters["compid"].DefaultValue = defaultValue;
				SqlDataSource1.UpdateParameters["finyearid"].DefaultValue = defaultValue2;
				SqlDataSource1.UpdateParameters["sessionid"].DefaultValue = defaultValue3;
				SqlDataSource1.Update();
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTypes")).Text;
				SqlDataSource1.InsertParameters["Types"].DefaultValue = text2;
				SqlDataSource1.InsertParameters["sysdate"].DefaultValue = currDate;
				SqlDataSource1.InsertParameters["systime"].DefaultValue = currTime;
				SqlDataSource1.InsertParameters["compid"].DefaultValue = defaultValue;
				SqlDataSource1.InsertParameters["finyearid"].DefaultValue = defaultValue2;
				SqlDataSource1.InsertParameters["sessionid"].DefaultValue = defaultValue3;
				if (text2 != "")
				{
					SqlDataSource1.Insert();
					lblmsg.Text = "Record Inserted.";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblmsg.Text = "Record Updated.";
	}

	protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblmsg.Text = "Record Deleted.";
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

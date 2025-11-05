using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_IntercomExtNo : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label Label2;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Label2.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Add")
		{
			string text = ((TextBox)GridView1.FooterRow.FindControl("txtExtNo")).Text;
			string selectedValue = ((DropDownList)GridView1.FooterRow.FindControl("ddDepartment")).SelectedValue;
			if (text != "" && selectedValue != "")
			{
				SqlDataSource1.InsertParameters["ExtNo"].DefaultValue = text;
				SqlDataSource1.InsertParameters["Department"].DefaultValue = selectedValue;
				SqlDataSource1.Insert();
				Label2.Text = "Record inserted.";
			}
		}
		if (e.CommandName == "Add1")
		{
			string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtExtNo")).Text;
			string selectedValue2 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddDepartment")).SelectedValue;
			if (text2 != "" && selectedValue2 != "")
			{
				SqlDataSource1.InsertParameters["ExtNo"].DefaultValue = text2;
				SqlDataSource1.InsertParameters["Department"].DefaultValue = selectedValue2;
				SqlDataSource1.Insert();
				Label2.Text = "Record inserted.";
			}
		}
		if (e.CommandName == "Update")
		{
			int index = Convert.ToInt32(e.CommandArgument);
			GridViewRow gridViewRow = GridView1.Rows[index];
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddDepartment0");
			string text3 = ((TextBox)GridView1.FooterRow.FindControl("txtExtNo")).Text;
			SqlDataSource1.UpdateParameters["ExtNo"].DefaultValue = text3;
			SqlDataSource1.UpdateParameters["Department"].DefaultValue = dropDownList.SelectedValue;
			SqlDataSource1.Update();
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

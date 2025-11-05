using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Masters_ItemLocation_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

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
			int index = Convert.ToInt32(e.CommandArgument);
			GridViewRow gridViewRow = GridView1.Rows[index];
			if (e.CommandName == "Update")
			{
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("lblLc0");
				string selectedValue = dropDownList.SelectedValue;
				string text = ((TextBox)gridViewRow.FindControl("lblLcNo0")).Text;
				string text2 = ((TextBox)gridViewRow.FindControl("lblLcDesc")).Text;
				if (text != "" && text2 != "" && selectedValue != "Select")
				{
					SqlDataSource1.UpdateParameters["LocationLabel"].DefaultValue = selectedValue;
					SqlDataSource1.UpdateParameters["LocationNo"].DefaultValue = text;
					SqlDataSource1.UpdateParameters["Description"].DefaultValue = text2;
					SqlDataSource1.UpdateParameters["SysDate"].DefaultValue = currDate;
					SqlDataSource1.UpdateParameters["SysTime"].DefaultValue = currTime;
					SqlDataSource1.Update();
					lblMessage.Text = "Record Updated.";
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
		}
		catch (Exception)
		{
		}
	}
}

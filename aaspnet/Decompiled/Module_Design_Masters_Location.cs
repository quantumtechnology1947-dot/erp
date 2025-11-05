using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_Location : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (e.CommandName == "Add")
			{
				string selectedValue = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList1")).SelectedValue;
				string text = ((TextBox)GridView1.FooterRow.FindControl("TextBox1")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text;
				if (text != "" && text2 != "" && selectedValue != "Select")
				{
					SqlDataSource1.InsertParameters["LocationLabel"].DefaultValue = selectedValue;
					SqlDataSource1.InsertParameters["LocationNo"].DefaultValue = text;
					SqlDataSource1.InsertParameters["Description"].DefaultValue = text2;
					SqlDataSource1.InsertParameters["SysDate"].DefaultValue = currDate;
					SqlDataSource1.InsertParameters["SysTime"].DefaultValue = currTime;
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
			if (e.CommandName == "Add1")
			{
				string selectedValue2 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList1")).SelectedValue;
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox1")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox2")).Text;
				if (text3 != "" && text4 != "" && selectedValue2 != "Select")
				{
					SqlDataSource1.InsertParameters["LocationLabel"].DefaultValue = selectedValue2;
					SqlDataSource1.InsertParameters["LocationNo"].DefaultValue = text3;
					SqlDataSource1.InsertParameters["Description"].DefaultValue = text4;
					SqlDataSource1.InsertParameters["SysDate"].DefaultValue = currDate;
					SqlDataSource1.InsertParameters["SysTime"].DefaultValue = currTime;
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

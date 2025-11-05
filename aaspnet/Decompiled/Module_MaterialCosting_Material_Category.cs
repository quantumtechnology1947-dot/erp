using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialCosting_Material_Category : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

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
		try
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string defaultValue = Session["username"].ToString();
			string defaultValue2 = Session["compid"].ToString();
			string defaultValue3 = Session["finyear"].ToString();
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtMaterial")).Text;
				string selectedValue = ((DropDownList)GridView1.FooterRow.FindControl("ddUnit")).SelectedValue;
				if (text != "")
				{
					LocalSqlServer.InsertParameters["SySDate"].DefaultValue = currDate;
					LocalSqlServer.InsertParameters["SysTime"].DefaultValue = currTime;
					LocalSqlServer.InsertParameters["CompId"].DefaultValue = defaultValue2;
					LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = defaultValue3;
					LocalSqlServer.InsertParameters["SessionId"].DefaultValue = defaultValue;
					LocalSqlServer.InsertParameters["Material"].DefaultValue = text;
					LocalSqlServer.InsertParameters["Unit"].DefaultValue = selectedValue;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
			if (e.CommandName == "Update")
			{
				int index = Convert.ToInt32(e.CommandArgument);
				GridViewRow gridViewRow = GridView1.Rows[index];
				DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddUnit1");
				string selectedValue2 = dropDownList.SelectedValue;
				string defaultValue4 = selectedValue2;
				string text2 = ((TextBox)gridViewRow.FindControl("txtMaterial1")).Text;
				if (text2 != "")
				{
					LocalSqlServer.UpdateParameters["SySDate"].DefaultValue = currDate;
					LocalSqlServer.UpdateParameters["SysTime"].DefaultValue = currTime;
					LocalSqlServer.UpdateParameters["CompId"].DefaultValue = defaultValue2;
					LocalSqlServer.UpdateParameters["FinYearId"].DefaultValue = defaultValue3;
					LocalSqlServer.UpdateParameters["SessionId"].DefaultValue = defaultValue;
					LocalSqlServer.UpdateParameters["Unit"].DefaultValue = defaultValue4;
					LocalSqlServer.UpdateParameters["Material"].DefaultValue = text2;
					LocalSqlServer.Update();
				}
			}
			if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtMaterial")).Text;
				string selectedValue3 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddUnit")).SelectedValue;
				if (text3 != "")
				{
					LocalSqlServer.InsertParameters["SySDate"].DefaultValue = currDate;
					LocalSqlServer.InsertParameters["SysTime"].DefaultValue = currTime;
					LocalSqlServer.InsertParameters["CompId"].DefaultValue = defaultValue2;
					LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = defaultValue3;
					LocalSqlServer.InsertParameters["SessionId"].DefaultValue = defaultValue;
					LocalSqlServer.InsertParameters["Material"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Unit"].DefaultValue = selectedValue3;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted";
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

using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialCosting_Material_Edit : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

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
		string connectionString = fun.Connection();
		new SqlConnection(connectionString);
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		try
		{
			string defaultValue = Session["username"].ToString();
			string defaultValue2 = Session["compid"].ToString();
			string defaultValue3 = Session["finyear"].ToString();
			if (e.CommandName == "Update")
			{
				int index = Convert.ToInt32(e.CommandArgument);
				GridViewRow gridViewRow = GridView1.Rows[index];
				string text = ((TextBox)gridViewRow.FindControl("TxtDate")).Text;
				string text2 = ((TextBox)gridViewRow.FindControl("txtLiveCost")).Text;
				if (text != "" && text2 != "")
				{
					LocalSqlServer.UpdateParameters["SySDate"].DefaultValue = currDate;
					LocalSqlServer.UpdateParameters["SysTime"].DefaultValue = currTime;
					LocalSqlServer.UpdateParameters["CompId"].DefaultValue = defaultValue2;
					LocalSqlServer.UpdateParameters["FinYearId"].DefaultValue = defaultValue3;
					LocalSqlServer.UpdateParameters["SessionId"].DefaultValue = defaultValue;
					LocalSqlServer.UpdateParameters["EffDate"].DefaultValue = text;
					LocalSqlServer.UpdateParameters["LiveCost"].DefaultValue = text2;
					LocalSqlServer.Update();
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
		}
		catch (Exception)
		{
		}
	}
}

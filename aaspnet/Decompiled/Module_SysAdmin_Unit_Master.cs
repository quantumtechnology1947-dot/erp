using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_Unit_Master : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

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
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtUnitName")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtAbb")).Text;
				int num = 0;
				if (((CheckBox)GridView1.FooterRow.FindControl("txtEffInv")).Checked)
				{
					num = 1;
				}
				if (text != "" && text2 != "")
				{
					LocalSqlServer.InsertParameters["UnitName"].DefaultValue = text;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2;
					LocalSqlServer.InsertParameters["EffInv"].DefaultValue = num.ToString();
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtUnitName")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbb")).Text;
				int num2 = 0;
				if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("txtEffInv0")).Checked)
				{
					num2 = 1;
				}
				if (text3 != "" && text4 != "")
				{
					LocalSqlServer.InsertParameters["UnitName"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text4;
					LocalSqlServer.InsertParameters["EffInv"].DefaultValue = num2.ToString();
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
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		int editIndex = GridView1.EditIndex;
		GridViewRow gridViewRow = GridView1.Rows[editIndex];
		Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
		string text = ((TextBox)gridViewRow.FindControl("lblUnitName0")).Text;
		string text2 = ((TextBox)gridViewRow.FindControl("lblAbbrivation0")).Text;
		int num = 0;
		if (((CheckBox)gridViewRow.FindControl("txtEffInv00")).Checked)
		{
			num = 1;
		}
		if (text != "" && text2 != "")
		{
			LocalSqlServer.UpdateParameters["UnitName"].DefaultValue = text;
			LocalSqlServer.UpdateParameters["Symbol"].DefaultValue = text2;
			LocalSqlServer.UpdateParameters["EffInv"].DefaultValue = num.ToString();
			LocalSqlServer.Update();
		}
	}
}

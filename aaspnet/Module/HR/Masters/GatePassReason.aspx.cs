using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_GatePassReason : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

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
		SqlDataSource1.Update();
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Add")
		{
			string text = ((TextBox)GridView1.FooterRow.FindControl("txtDescription2")).Text;
			if (text != "")
			{
				SqlDataSource1.InsertParameters["Reason"].DefaultValue = text;
				SqlDataSource1.Insert();
				lblMessage.Text = "Record Inserted";
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		if (e.CommandName == "Add1")
		{
			string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDescription3")).Text;
			if (text2 != "")
			{
				SqlDataSource1.InsertParameters["Reason"].DefaultValue = text2;
				SqlDataSource1.Insert();
				lblMessage.Text = "Record Inserted";
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
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
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((Label)row.FindControl("lblId")).Text == "19" || ((Label)row.FindControl("lblId")).Text == "33")
				{
					LinkButton linkButton3 = (LinkButton)row.Cells[1].Controls[0];
					LinkButton linkButton4 = (LinkButton)row.Cells[0].Controls[0];
					linkButton3.Visible = false;
					linkButton4.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtDescription1")).Text;
			if (text != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblGatePass_Reason SET  Reason = '" + text + "' WHERE Id ='" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
	}
}

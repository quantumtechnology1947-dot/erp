using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Transaction_BudgetHrsFields : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected GridView GridView2;

	protected Label lblMessage1;

	protected SqlDataSource SqlDataSource11;

	protected SqlDataSource SqlDataSource2;

	protected Button btnCancel1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		lblMessage1.Text = "";
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
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtCategory")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol")).Text;
				if (text != "" && text2 != "")
				{
					LocalSqlServer.InsertParameters["Category"].DefaultValue = text;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCate")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
				if (text3 != "" && text4 != "")
				{
					LocalSqlServer.InsertParameters["Category"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text4;
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
		try
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtCategory0")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtSymbol0")).Text;
			if (text != "" && text2 != "")
			{
				LocalSqlServer.UpdateParameters["Category"].DefaultValue = text;
				LocalSqlServer.UpdateParameters["Symbol"].DefaultValue = text;
				LocalSqlServer.Update();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			if (e.CommandName == "Add_sb")
			{
				string selectedValue = ((DropDownList)GridView2.FooterRow.FindControl("ddCategory_sb")).SelectedValue;
				string text = ((TextBox)GridView2.FooterRow.FindControl("txtSubCategory_sb0")).Text;
				string text2 = ((TextBox)GridView2.FooterRow.FindControl("txtSymbol0")).Text;
				if (selectedValue != "1")
				{
					if (text != "")
					{
						SqlDataSource11.InsertParameters["MId"].DefaultValue = selectedValue;
						SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = text;
						SqlDataSource11.InsertParameters["Symbol"].DefaultValue = text2;
						SqlDataSource11.Insert();
						lblMessage1.Text = "Record Inserted.";
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					string empty = string.Empty;
					empty = "Please select category.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				if (!(e.CommandName == "Add_sb1"))
				{
					return;
				}
				string selectedValue2 = ((DropDownList)GridView2.Controls[0].Controls[0].FindControl("ddCategory_sb1")).SelectedValue;
				string text3 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtCate_sb1")).Text;
				string text4 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtSymbol1")).Text;
				if (selectedValue2 != "1")
				{
					if (text3 != "")
					{
						SqlDataSource11.InsertParameters["MId"].DefaultValue = selectedValue2;
						SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = text3;
						SqlDataSource11.InsertParameters["Symbol"].DefaultValue = text4;
						SqlDataSource11.Insert();
						lblMessage1.Text = "Record Inserted.";
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Please select category.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage1.Text = "Record Deleted.";
	}

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage1.Text = "Record Updated.";
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string selectedValue = ((DropDownList)gridViewRow.FindControl("ddCategory_sbe")).SelectedValue;
			string text = ((TextBox)gridViewRow.FindControl("txtSubCategory_sb")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtSymbol")).Text;
			if (selectedValue != "1")
			{
				if (text != "")
				{
					SqlDataSource11.UpdateParameters["MId"].DefaultValue = selectedValue;
					SqlDataSource11.UpdateParameters["SubCategory"].DefaultValue = text;
					SqlDataSource11.UpdateParameters["SubSymbol"].DefaultValue = text2;
					SqlDataSource11.Update();
				}
			}
			else
			{
				e.Cancel = true;
				string empty = string.Empty;
				empty = "Please select category.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
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

	protected void btnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Menu.aspx?ModId=14&SubModId=");
	}
}

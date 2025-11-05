using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Masters_Asset : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected GridView GridView2;

	protected Label lblMessage1;

	protected SqlDataSource SqlDataSource11;

	protected SqlDataSource SqlDataSource2;

	protected TabPanel TabPanel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

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
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtCategory")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtAbbrivation")).Text.ToUpper();
				if (text != "" && text2 != "")
				{
					string cmdText = fun.select("Abbrivation", "tblACC_Asset_Category", " Abbrivation='" + text2 + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						LocalSqlServer.InsertParameters["Category"].DefaultValue = text;
						LocalSqlServer.InsertParameters["Abbrivation"].DefaultValue = text2;
						LocalSqlServer.Insert();
						lblMessage.Text = "Record Inserted.";
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Category Abbrivation is already used.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCate")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbb")).Text.ToUpper();
				if (text3 != "" && text4 != "")
				{
					LocalSqlServer.InsertParameters["Category"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Abbrivation"].DefaultValue = text4;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			SqlConnection connection = new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtCategory0")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtAbbrivation0")).Text.ToUpper();
			if (text != "" && text2 != "")
			{
				string cmdText = fun.select("Abbrivation", "tblACC_Asset_Category", " Abbrivation='" + text2 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					LocalSqlServer.UpdateParameters["Category"].DefaultValue = text;
					LocalSqlServer.UpdateParameters["Abbrivation"].DefaultValue = text2;
					LocalSqlServer.Update();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Category Abbrivation is already used.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
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
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "Add_sb")
			{
				string selectedValue = ((DropDownList)GridView2.FooterRow.FindControl("ddCategory_sb")).SelectedValue;
				string text = ((TextBox)GridView2.FooterRow.FindControl("txtSubCategory_sb0")).Text;
				string text2 = ((TextBox)GridView2.FooterRow.FindControl("txtAbbrivation_sb0")).Text.ToUpper();
				if (selectedValue != "1")
				{
					if (text != "" && text2 != "")
					{
						string cmdText = fun.select("Abbrivation", "tblACC_Asset_SubCategory", " Abbrivation='" + text2 + "'");
						SqlCommand selectCommand = new SqlCommand(cmdText, connection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						if (dataSet.Tables[0].Rows.Count == 0)
						{
							SqlDataSource11.InsertParameters["MId"].DefaultValue = selectedValue;
							SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = text;
							SqlDataSource11.InsertParameters["Abbrivation"].DefaultValue = text2;
							SqlDataSource11.Insert();
							lblMessage1.Text = "Record Inserted.";
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
						else
						{
							string empty = string.Empty;
							empty = "Subcategory Abbrivation is already used.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Please select category.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
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
				string text4 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAbb_sb1")).Text.ToUpper();
				if (selectedValue2 != "1")
				{
					if (text3 != "" && text4 != "")
					{
						SqlDataSource11.InsertParameters["MId"].DefaultValue = selectedValue2;
						SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = text3;
						SqlDataSource11.InsertParameters["Abbrivation"].DefaultValue = text4;
						SqlDataSource11.Insert();
						lblMessage1.Text = "Record Inserted.";
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Please select category.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
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
			SqlConnection connection = new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string selectedValue = ((DropDownList)gridViewRow.FindControl("ddCategory_sbe")).SelectedValue;
			string text = ((TextBox)gridViewRow.FindControl("txtSubCategory_sb")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtAbbrivation_sb")).Text.ToUpper();
			if (selectedValue != "1")
			{
				if (text != "" && text2 != "")
				{
					string cmdText = fun.select("Abbrivation", "tblACC_Asset_SubCategory", " Abbrivation='" + text2 + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						SqlDataSource11.UpdateParameters["MId"].DefaultValue = selectedValue;
						SqlDataSource11.UpdateParameters["SubCategory"].DefaultValue = text;
						SqlDataSource11.UpdateParameters["Abbrivation"].DefaultValue = text2;
						SqlDataSource11.Update();
					}
					else
					{
						string empty = string.Empty;
						empty = "Subcategory Abbrivation is already used.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			else
			{
				e.Cancel = true;
				string empty2 = string.Empty;
				empty2 = "Please select category.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
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
}

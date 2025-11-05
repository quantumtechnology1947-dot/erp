using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Currency : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				loadata();
			}
			lblMessage.Text = "";
		}
		catch (Exception)
		{
		}
	}

	public void getCnt()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			foreach (GridViewRow row in GridView1.Rows)
			{
				string text = ((Label)row.FindControl("lblId")).Text;
				string cmdText = fun.select("Country", "tblACC_Currency_Master", "Id='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_Currency_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					((DropDownList)row.FindControl("DrpCountry")).SelectedValue = dataSet.Tables[0].Rows[0][0].ToString();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadata()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string text = "";
			text = fun.select1("*", "tblACC_Currency_Master Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			getCnt();
		}
		catch (Exception)
		{
		}
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
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpCountry2")).SelectedValue);
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtName2")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol2")).Text;
				if (text != "" && text2 != "")
				{
					string connectionString = fun.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					string cmdText = fun.insert("tblACC_Currency_Master", "Country,Name,Symbol", "'" + num + "','" + text + "','" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				int num2 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCountry3")).SelectedValue);
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName3")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol3")).Text;
				if (text3 != "" && text4 != "")
				{
					string connectionString2 = fun.Connection();
					SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
					sqlConnection2.Open();
					string cmdText2 = fun.insert("tblACC_Currency_Master", "Country,Name,Symbol", "'" + num2 + "','" + text3 + "','" + text4 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection2);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection2.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
	{
		lblMessage.Text = "Record Inserted";
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

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			loadata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			loadata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			string text = ((TextBox)gridViewRow.FindControl("txtName1")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtSymbol1")).Text;
			int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpCountry1")).SelectedValue);
			if (text != "" && text2 != "")
			{
				int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.update("tblACC_Currency_Master", "Country='" + num + "' ,Name='" + text + "',Symbol='" + text2 + "'", "Id='" + num2 + "' ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}
}

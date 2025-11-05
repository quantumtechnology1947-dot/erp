using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_State : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

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
				string text = ((Label)row.FindControl("lblID")).Text;
				string cmdText = fun.select("CId", "tblState", "SId='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblState");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					((DropDownList)row.FindControl("DrpCountry")).SelectedValue = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblCity", "SId='" + text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblCity");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("btndel")).Visible = false;
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
			text = fun.select1("*", "tblState Order By SId Desc");
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
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
				if (text != "")
				{
					string connectionString = fun.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					string cmdText = fun.insert("tblState", "CId,StateName", "'" + num + "','" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				int num2 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCountry2")).SelectedValue);
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName")).Text;
				if (text2 != "")
				{
					string connectionString2 = fun.Connection();
					SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
					sqlConnection2.Open();
					string cmdText2 = fun.insert("tblState", "CId,StateName", "'" + num2 + "','" + text2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection2);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection2.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblID")).Text);
				string connectionString3 = fun.Connection();
				SqlConnection sqlConnection3 = new SqlConnection(connectionString3);
				sqlConnection3.Open();
				string cmdText3 = fun.delete("tblState", "SId='" + num3 + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection3);
				sqlCommand3.ExecuteNonQuery();
				sqlConnection3.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			string text = ((TextBox)gridViewRow.FindControl("lblName0")).Text;
			int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpCountry1")).SelectedValue);
			if (text != "")
			{
				int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblID")).Text);
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.update("tblState", "CId='" + num + "' ,StateName='" + text + "'", "SId='" + num2 + "' ");
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

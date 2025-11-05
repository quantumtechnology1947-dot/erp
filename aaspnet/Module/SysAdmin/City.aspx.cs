using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_City : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int q;

	protected DropDownList DrpCountry;

	protected DropDownList Drpstate;

	protected GridView GridView1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select1("*", "tblCountry");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "country");
				DrpCountry.DataSource = dataSet.Tables["country"];
				DrpCountry.DataTextField = "CountryName";
				DrpCountry.DataValueField = "CId";
				DrpCountry.DataBind();
				DrpCountry.Items.Insert(0, "Select");
				Drpstate.Items.Insert(0, "Select");
				loadata(q);
			}
			lblMessage.Text = "";
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (DrpCountry.SelectedValue != "Select")
			{
				string cmdText = fun.select("*", "tblState", "CId='" + DrpCountry.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "state");
				Drpstate.DataSource = dataSet.Tables["state"];
				Drpstate.DataTextField = "StateName";
				Drpstate.DataValueField = "SId";
				Drpstate.DataBind();
				Drpstate.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Drpstate_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (Drpstate.SelectedItem.Text != "Select")
			{
				loadata(Convert.ToInt32(Drpstate.SelectedValue));
			}
			else
			{
				loadata(q);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadata(int p)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string text = "";
			text = ((p == 0) ? fun.select1("*", "tblCity Order By CityId Desc") : fun.select("*", "tblCity", "SId='" + p + "'Order By CityId Desc"));
			SqlCommand selectCommand = new SqlCommand(text, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
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

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			if (Drpstate.SelectedItem.Text != "Select")
			{
				loadata(Convert.ToInt32(Drpstate.SelectedValue));
			}
			else
			{
				loadata(q);
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
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			string text = ((TextBox)gridViewRow.FindControl("txtName1")).Text;
			if (text != "" && Drpstate.SelectedItem.Text != "Select")
			{
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblID")).Text);
				int num2 = Convert.ToInt32(Drpstate.SelectedValue);
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.update("tblCity", "SId='" + num2 + "' ,CityName='" + text + "'", "CityId='" + num + "' ");
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
				if (text != "" && Drpstate.SelectedItem.Text != "Select")
				{
					string connectionString = fun.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					int num = Convert.ToInt32(Drpstate.SelectedValue);
					sqlConnection.Open();
					string cmdText = fun.insert("tblCity", "SId,CityName", "'" + num + "','" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName")).Text;
				if (text2 != "" && Drpstate.SelectedItem.Text != "Select")
				{
					string connectionString2 = fun.Connection();
					SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
					int num2 = Convert.ToInt32(Drpstate.SelectedValue);
					sqlConnection2.Open();
					string cmdText2 = fun.insert("tblCity", "SId,CityName", "'" + num2 + "','" + text2 + "'");
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
				string cmdText3 = fun.delete("tblCity", "CityId='" + num3 + "' ");
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			if (Drpstate.SelectedItem.Text != "Select")
			{
				loadata(Convert.ToInt32(Drpstate.SelectedValue));
			}
			else
			{
				loadata(q);
			}
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
			if (Drpstate.SelectedItem.Text != "Select")
			{
				loadata(Convert.ToInt32(Drpstate.SelectedValue));
			}
			else
			{
				loadata(q);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}
}

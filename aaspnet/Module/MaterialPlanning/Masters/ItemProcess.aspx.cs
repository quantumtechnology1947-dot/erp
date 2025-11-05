using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialPlanning_Masters_ItemProcess : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource2;

	protected Label lblmsg;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("Id, ProcessName, Symbol", "tblPln_Process_Master", "Id!='0'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ProcessName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["ProcessName"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtProcessName1")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol1")).Text;
				if (text != "" && text2 != "")
				{
					sqlConnection.Open();
					string cmdText = fun.insert("tblPln_Process_Master", "ProcessName,Symbol", "'" + text + "','" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
				if (text3 != "" && text4 != "")
				{
					sqlConnection.Open();
					string cmdText2 = fun.insert("tblPln_Process_Master", "ProcessName,Symbol", "'" + text3 + "','" + text4 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string cmdText3 = fun.delete("tblPln_Process_Master", "Id='" + num + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				sqlConnection.Open();
				sqlCommand3.ExecuteNonQuery();
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
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			LoadData();
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
			LoadData();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			string cmdText = fun.select("UOMBasic", "tblPln_Process_Master", "Id='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((DropDownList)gridViewRow.FindControl("DDLBasic")).SelectedValue = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
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
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtPName")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtSymbol")).Text;
			if (text != "" && text2 != "")
			{
				sqlConnection.Open();
				string cmdText = fun.update("tblPln_Process_Master", "ProcessName='" + text + "',Symbol='" + text2 + "'", "Id='" + num + "'");
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

	protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
	}
}

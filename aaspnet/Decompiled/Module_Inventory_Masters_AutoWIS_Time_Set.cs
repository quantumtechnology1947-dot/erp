using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using MKB.TimePicker;

public class Module_Inventory_Masters_AutoWIS_Time_Set : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string connStr = "";

	private SqlConnection con;

	private string x = string.Empty;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			lblMessage.Text = "";
			if (!base.IsPostBack)
			{
				FillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAutoWIS_Time", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			x = dataSet.Tables[0].Rows[0]["TimeAuto"].ToString();
			fun.TimeSelectorDatabase3(x, (TimeSelector)GridView1.FooterRow.FindControl("TimeSelFoot"));
		}
		catch (Exception)
		{
		}
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
		string empty = string.Empty;
		if (e.CommandName == "Add")
		{
			string text = ((TimeSelector)GridView1.FooterRow.FindControl("TimeSelFoot")).Hour.ToString("D2") + ":" + ((TimeSelector)GridView1.FooterRow.FindControl("TimeSelFoot")).Minute.ToString("D2") + ":" + ((TimeSelector)GridView1.FooterRow.FindControl("TimeSelFoot")).Second.ToString("D2") + " " + ((TimeSelector)GridView1.FooterRow.FindControl("TimeSelFoot")).AmPm;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAutoWIS_Time", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			empty = dataSet.Tables[0].Rows[0]["TimeAuto"].ToString();
			DateTime value = Convert.ToDateTime(empty);
			DateTime dateTime = Convert.ToDateTime(text);
			if (text != "" && dateTime.Subtract(value).Hours >= 2)
			{
				string cmdText = fun.insert("tblinv_AutoWIS_TimeSchedule", "TimeAuto, CompId, FinYearId,TimeToOrder", "'" + text + "','" + CompId + "','" + FinYearId + "','" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				lblMessage.Text = "Record Inserted";
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid data";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		if (e.CommandName == "Add1")
		{
			string text2 = ((TimeSelector)GridView1.Controls[0].Controls[0].FindControl("TimeSelEmpty")).Hour.ToString("D2") + ":" + ((TimeSelector)GridView1.Controls[0].Controls[0].FindControl("TimeSelEmpty")).Minute.ToString("D2") + ":" + ((TimeSelector)GridView1.Controls[0].Controls[0].FindControl("TimeSelEmpty")).Second.ToString("D2") + " " + ((TimeSelector)GridView1.Controls[0].Controls[0].FindControl("TimeSelEmpty")).AmPm;
			if (text2 != "")
			{
				string cmdText2 = fun.insert("tblinv_AutoWIS_TimeSchedule", "TimeAuto, CompId, FinYearId,TimeToOrder", "'" + text2 + "','" + CompId + "','" + FinYearId + "','" + text2 + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
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
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TimeSelector)gridViewRow.FindControl("TimeSelEdit")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelEdit")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelEdit")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("TimeSelEdit")).AmPm;
			if (text != "")
			{
				string cmdText = fun.update("tblinv_AutoWIS_TimeSchedule", "TimeAuto='" + text + "',TimeToOrder='" + text + "'", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			FillGrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView1.EditIndex = e.NewEditIndex;
		FillGrid();
		int editIndex = GridView1.EditIndex;
		GridViewRow gridViewRow = GridView1.Rows[editIndex];
		Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
		if (((Label)gridViewRow.FindControl("lblTimeAutoE")).Text != string.Empty)
		{
			fun.TimeSelectorDatabase(((Label)gridViewRow.FindControl("lblTimeAutoE")).Text, (TimeSelector)gridViewRow.FindControl("TimeSelEdit"));
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblinv_AutoWIS_TimeSchedule WHERE Id=" + num, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

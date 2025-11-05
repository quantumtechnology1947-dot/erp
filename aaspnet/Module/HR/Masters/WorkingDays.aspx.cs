using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_WorkingDays : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource3;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblMessage.Text = "";
			if (!Page.IsPostBack)
			{
				FillGrid();
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
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DptYear")).SelectedValue);
				int num2 = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("ddlMonth")).SelectedValue);
				double num3 = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtDays")).Text);
				if (((TextBox)GridView1.FooterRow.FindControl("txtDays")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.FooterRow.FindControl("txtDays")).Text))
				{
					string selectCommandText = fun.select("CompId,FinYearId,MonthId", "tblHR_WorkingDays", "CompId='" + CompId + "' AND FinYearId='" + num + "' AND MonthId='" + num2 + "' ");
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblHR_WorkingDays");
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						string cmdText = fun.insert("tblHR_WorkingDays", "CompId,FinYearId,MonthId,Days", "'" + CompId + "','" + num + "','" + num2 + "','" + num3 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						con.Open();
						sqlCommand.ExecuteNonQuery();
						con.Close();
						FillGrid();
						lblMessage.Text = "Record Inserted";
					}
					else
					{
						string empty = string.Empty;
						empty = "Month is allrady exist.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			else if (e.CommandName == "Add1")
			{
				int num4 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DptYear2")).SelectedValue);
				int num5 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddlMonth2")).SelectedValue);
				double num6 = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDays2")).Text);
				if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDays2")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDays2")).Text))
				{
					string cmdText2 = fun.insert("tblHR_WorkingDays", "CompId,FinYearId,MonthId,Days", "'" + CompId + "','" + num4 + "','" + num5 + "','" + num6 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillGrid();
					lblMessage.Text = "Record Inserted";
				}
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
			double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtDays1")).Text);
			if (((TextBox)gridViewRow.FindControl("txtDays1")).Text != "" && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtDays1")).Text))
			{
				string cmdText = "UPDATE [tblHR_WorkingDays] SET [Days] ='" + num2 + "' WHERE [Id] = '" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView1.EditIndex = -1;
				FillGrid();
				lblMessage.Text = "Record Updated";
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
			FillGrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			string text = ((Label)gridViewRow.FindControl("lblDays1")).Text;
			((TextBox)gridViewRow.FindControl("txtDays1")).Text = text;
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			string cmdText = fun.select("[tblHR_WorkingDays].[MonthId] as [MonthId] ,[tblHR_WorkingDays].[Id],[tblFinancial_master].[FinYearId] as [FinYearId] ,[tblFinancial_master].[FinYear] as [FinYear] ,[tblHR_WorkingDays].[Days]", "[tblHR_WorkingDays],[tblFinancial_master]", " [tblHR_WorkingDays].[FinYearId]=[tblFinancial_master].[FinYearId] And [tblHR_WorkingDays].[CompId]='" + CompId + "' AND [tblHR_WorkingDays].[FinYearId]<='" + FinYearId + "' ORDER BY [tblHR_WorkingDays].[Id] DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			if (GridView1.Rows.Count == 0)
			{
				fun.GetMonth((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddlMonth2"), CompId, FinYearId);
			}
			else
			{
				fun.GetMonth((DropDownList)GridView1.FooterRow.FindControl("ddlMonth"), CompId, FinYearId);
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				int month = Convert.ToInt32(((Label)row.FindControl("lblMonthId")).Text);
				((Label)row.FindControl("lblMonthId")).Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblHR_WorkingDays WHERE Id=" + num, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid();
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
}

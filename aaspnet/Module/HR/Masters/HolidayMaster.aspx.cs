using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_HolidayMaster : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string sId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		sId = Session["username"].ToString();
		CDate = fun.getCurrDate();
		CTime = fun.getCurrTime();
		lblMessage.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtTitle0")).Text;
				string text2 = fun.FromDate(((TextBox)GridView1.FooterRow.FindControl("TxtDate0")).Text);
				if (text != "" && text2 != "")
				{
					SqlDataSource1.InsertParameters["Title"].DefaultValue = text;
					SqlDataSource1.InsertParameters["HDate"].DefaultValue = text2;
					SqlDataSource1.InsertParameters["SysDate"].DefaultValue = CDate;
					SqlDataSource1.InsertParameters["SysTime"].DefaultValue = CTime;
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTitle1")).Text;
				string text4 = fun.FromDate(((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtDate1")).Text);
				if (text3 != "" && text4 != "")
				{
					SqlDataSource1.InsertParameters["Title"].DefaultValue = text3;
					SqlDataSource1.InsertParameters["HDate"].DefaultValue = text4;
					SqlDataSource1.InsertParameters["SysDate"].DefaultValue = CDate;
					SqlDataSource1.InsertParameters["SysTime"].DefaultValue = CTime;
					SqlDataSource1.Insert();
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
			if (GridView1.Rows.Count == 0)
			{
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtDate1")).Attributes.Add("readonly", "readonly");
				return;
			}
			((TextBox)GridView1.FooterRow.FindControl("TxtDate0")).Attributes.Add("readonly", "readonly");
			GridViewRow gridViewRow = GridView1.Rows[GridView1.EditIndex];
			((TextBox)gridViewRow.FindControl("TxtDate")).Attributes.Add("readonly", "readonly");
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
			string text = ((TextBox)gridViewRow.FindControl("TxtTitle")).Text;
			string defaultValue = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtDate")).Text);
			SqlDataSource1.UpdateParameters["SysDate"].DefaultValue = CDate;
			SqlDataSource1.UpdateParameters["SysTime"].DefaultValue = CTime;
			SqlDataSource1.UpdateParameters["Title"].DefaultValue = text;
			SqlDataSource1.UpdateParameters["HDate"].DefaultValue = defaultValue;
			SqlDataSource1.Update();
			lblMessage.Text = "Record Inserted";
		}
		catch (Exception)
		{
		}
	}
}

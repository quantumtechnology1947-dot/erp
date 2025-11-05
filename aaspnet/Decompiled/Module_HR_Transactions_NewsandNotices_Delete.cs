using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_NewsandNotices_Delete : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(Session["compid"]);
		int num2 = Convert.ToInt32(Session["finyear"]);
		if (!(e.CommandName == "Del"))
		{
			return;
		}
		sqlConnection.Open();
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblHR_News_Notices", "CompId='" + num + "' AND FinYearId<='" + num2 + "' AND Id='" + num3 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
			linkButton.Attributes.Add("onclick", "return confirmationDelete();");
		}
	}
}

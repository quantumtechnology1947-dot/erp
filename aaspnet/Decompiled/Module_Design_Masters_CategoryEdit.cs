using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_CategoryEdit : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	private clsFunctions fun = new clsFunctions();

	private string compid = "";

	private string finyrsid = "";

	private string sessionid = "";

	private string connStr = "";

	private SqlConnection con;

	private int s;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
			compid = Session["compid"].ToString();
			finyrsid = Session["finyear"].ToString();
			sessionid = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		if (s > 0)
		{
			lblMessage.Text = "Record Updated.";
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Update")
			{
				int index = Convert.ToInt32(e.CommandArgument);
				GridViewRow gridViewRow = GridView1.Rows[index];
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("Label1")).Text);
				string text = ((TextBox)gridViewRow.FindControl("txtCate")).Text;
				LocalSqlServer.UpdateParameters["CId2"].DefaultValue = num.ToString();
				LocalSqlServer.UpdateParameters["CName2"].DefaultValue = text.ToString();
				LocalSqlServer.Update();
				s++;
			}
		}
		catch (Exception)
		{
		}
	}
}

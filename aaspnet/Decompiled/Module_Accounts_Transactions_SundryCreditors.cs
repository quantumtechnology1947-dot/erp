using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_SundryCreditors : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			if (Page.IsPostBack)
			{
				return;
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				_ = string.Empty;
				double num5 = 0.0;
				num5 = fun.FillGrid_Creditors(CompId, FinYearId, 2, ((LinkButton)row.FindControl("lblCategory")).Text);
				((Label)row.FindControl("lblCredit")).Text = num5.ToString();
				num2 += num5;
				double num6 = 0.0;
				num6 = fun.FillGrid_Creditors(CompId, FinYearId, 3, ((LinkButton)row.FindControl("lblCategory")).Text) + fun.FillGrid_Creditors(CompId, FinYearId, 5, ((LinkButton)row.FindControl("lblCategory")).Text);
				((Label)row.FindControl("lblDebit")).Text = num6.ToString();
				num3 += num6;
			}
			num = fun.FillGrid_Creditors(CompId, FinYearId, 1, "");
			((Label)GridView1.FooterRow.FindControl("OpTotal")).Text = num.ToString();
			((Label)GridView1.FooterRow.FindControl("CrTotal")).Text = num2.ToString();
			num4 = fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "");
			((Label)GridView1.FooterRow.FindControl("DrTotal")).Text = num4.ToString();
			((Label)GridView1.FooterRow.FindControl("Clbal")).Text = (num + num2 - num4).ToString();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/CurrentLiabilities.aspx?ModId=&SubModId=");
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "gotoPage")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			base.Response.Redirect("SundryCreditors_Details.aspx?ModId=&SubModId=&lnkFor=" + ((LinkButton)gridViewRow.FindControl("lblCategory")).Text);
		}
	}
}

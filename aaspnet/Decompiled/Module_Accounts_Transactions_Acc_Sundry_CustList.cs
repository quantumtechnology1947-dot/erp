using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Acc_Sundry_CustList : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ACC_CurrentAssets ACA = new ACC_CurrentAssets();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			DataTable dataSource = ACA.TotInvQty2(CompId, FinYearId, "");
			GridView1.DataSource = dataSource;
			GridView1.DataBind();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				num2 += Convert.ToDouble(((Label)row.FindControl("lblDrAmt")).Text);
				double num4 = 0.0;
				num4 = Math.Round(fun.getDebitorCredit(CompId, FinYearId, ((Label)row.FindControl("lblCustCode")).Text), 2);
				((Label)row.FindControl("lblCrAmt")).Text = num4.ToString();
				num3 += num4;
				double num5 = 0.0;
				num5 = fun.DebitorsOpeningBal(CompId, ((Label)row.FindControl("lblCustCode")).Text);
				((Label)row.FindControl("lblOpAmt")).Text = num5.ToString();
				num += num5;
			}
			((Label)GridView1.FooterRow.FindControl("TotOP")).Text = num.ToString();
			((Label)GridView1.FooterRow.FindControl("TotDebit")).Text = num2.ToString();
			((Label)GridView1.FooterRow.FindControl("TotCredit")).Text = num3.ToString();
		}
		catch
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblCustCode")).Text;
			base.Response.Redirect("Acc_Sundry_Details.aspx?CustId=" + text + "&ModId=11&SubModId=&Key=" + randomAlphaNumeric);
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Acc_Bal_CurrAssets.aspx??ModId=11&SubModId=");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}

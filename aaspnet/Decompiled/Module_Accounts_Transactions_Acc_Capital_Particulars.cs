using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Acc_Capital_Particulars : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private ACC_Loan_Liab ACA = new ACC_Loan_Liab();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		sId = Session["username"].ToString();
		if (!base.IsPostBack)
		{
			string strSql = "select Sum(CreditAmt) As loan,tblACC_Capital_Master.Particulars,tblACC_Capital_Master.Id from tblACC_Capital_Details inner join tblACC_Capital_Master on tblACC_Capital_Master.Id=tblACC_Capital_Details.MId And CompId=" + CompId + " AND FinYearId<=" + FinYearId + " group by tblACC_Capital_Master.Particulars,tblACC_Capital_Master.Id";
			DataTable dataTable = ACA.TotFillPart(strSql);
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			double num = 0.0;
			double num2 = 0.0;
			if (dataTable.Rows.Count > 0)
			{
				num2 = Convert.ToDouble(dataTable.Compute("Sum(TotCrAmt)", ""));
				num = Convert.ToDouble(dataTable.Compute("Sum(TotDrAmt)", ""));
				((Label)GridView1.FooterRow.FindControl("TotDebit")).Text = num.ToString();
				((Label)GridView1.FooterRow.FindControl("TotCredit")).Text = num2.ToString();
			}
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			fun.GetRandomAlphaNumeric();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			base.Response.Redirect("Acc_Capital_Part_Details.aspx?MId=" + text + "&ModId=11&SubModId=");
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/BalanceSheet.aspx??ModId=11&SubModId=");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}

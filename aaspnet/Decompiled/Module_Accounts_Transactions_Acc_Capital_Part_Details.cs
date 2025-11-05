using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Acc_Capital_Part_Details : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private ACC_Loan_Liab ACA = new ACC_Loan_Liab();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int MId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			if (!string.IsNullOrEmpty(base.Request.QueryString["MId"]))
			{
				MId = Convert.ToInt32(base.Request.QueryString["MId"]);
			}
			if (!base.IsPostBack)
			{
				string strSql = "select CreditAmt As loan,tblACC_Capital_Details.Particulars,tblACC_Capital_Details.Id from tblACC_Capital_Details inner join tblACC_Capital_Master on tblACC_Capital_Master.Id=tblACC_Capital_Details.MId And CompId=" + CompId + " AND FinYearId<=" + FinYearId + " And MId=" + MId;
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
		catch
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Acc_Capital_Particulars.aspx??ModId=11&SubModId=");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}

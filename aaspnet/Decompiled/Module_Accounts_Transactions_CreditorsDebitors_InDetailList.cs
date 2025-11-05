using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;

public class Module_Accounts_Transactions_CreditorsDebitors_InDetailList : Page, IRequiresSessionState
{
	protected Label Label5;

	protected TextBox txtFrmDt;

	protected CalendarExtender txtFrmDt_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator5;

	protected Label Label6;

	protected TextBox txtToDt;

	protected CalendarExtender txtToDt_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button btnSearch;

	protected Button btnCancel;

	protected HtmlGenericControl ifrm;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private ReportDocument cryRpt = new ReportDocument();

	private int CompId;

	private int FinYearId;

	private string SId = string.Empty;

	private string connStr = string.Empty;

	private string SupId = string.Empty;

	private string Key = string.Empty;

	private string DTFrm = string.Empty;

	private string DTTo = string.Empty;

	private string DtFrm = string.Empty;

	private string DtTo = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			SupId = base.Request.QueryString["SupId"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			Session["SupId"] = SupId;
			Session["Key"] = Key;
			Session["DtFrm"] = DtFrm;
			Session["DtTo"] = DtTo;
			ifrm.Attributes.Add("src", "CreditorsDebitors_InDetailView.aspx");
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtFrmDt.Text != "" && txtToDt.Text != "" && fun.DateValidation(txtFrmDt.Text) && fun.DateValidation(txtToDt.Text) && Convert.ToDateTime(fun.FromDate(txtFrmDt.Text)) <= Convert.ToDateTime(fun.FromDate(txtToDt.Text)))
			{
				DtFrm = fun.FromDate(txtFrmDt.Text);
				DtTo = fun.FromDate(txtToDt.Text);
				Session["SupId"] = SupId;
				Session["Key"] = Key;
				Session["DtFrm"] = DtFrm;
				Session["DtTo"] = DtTo;
				ifrm.Attributes.Add("src", "CreditorsDebitors_InDetailView.aspx");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/CreditorsDebitors.aspx?ModId=11&SubModId=135");
	}
}

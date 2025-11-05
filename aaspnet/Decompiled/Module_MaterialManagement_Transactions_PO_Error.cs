using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_Error : Page, IRequiresSessionState
{
	private string SupCode = string.Empty;

	private string PRSPR = string.Empty;

	protected GridView GridView2;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["Code"]))
			{
				SupCode = base.Request.QueryString["Code"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["PRSPR"]))
			{
				PRSPR = base.Request.QueryString["PRSPR"].ToString();
			}
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
		GridView2.DataSource = Session["X"];
		GridView2.DataBind();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		if (PRSPR == "0")
		{
			base.Response.Redirect("PO_PR_Items.aspx?ModId=6&SubModId=35&Code=" + SupCode);
		}
		else
		{
			base.Response.Redirect("PO_SPR_Items.aspx?ModId=6&SubModId=35&Code=" + SupCode);
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		FillGrid();
	}
}

using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private string PoNo = "";

	private string MId = "";

	private string AmdNo = "";

	private string Key = string.Empty;

	protected HtmlGenericControl myiframe;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			PoNo = base.Request.QueryString["pono"].ToString();
			SupCode = base.Request.QueryString["Code"].ToString();
			MId = base.Request.QueryString["mid"].ToString();
			AmdNo = base.Request.QueryString["AmdNo"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			myiframe.Attributes.Add("src", "PO_PR_Print_Page.aspx?ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&mid=" + MId + "&AmdNo=" + AmdNo + "&Key=" + Key);
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_Print.aspx?mid=" + MId + "&Code=" + SupCode + "&ModId=6&SubModId=35");
	}
}

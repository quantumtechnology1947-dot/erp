using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_SPR_View_Print_Details : Page, IRequiresSessionState
{
	protected Button Cancel;

	protected HtmlGenericControl myifram;

	private string SupCode = "";

	private string PoNo = "";

	private string parentPage = "";

	private string MId = "";

	private string AmdNo = "";

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			PoNo = base.Request.QueryString["pono"].ToString();
			SupCode = base.Request.QueryString["Code"].ToString();
			parentPage = base.Request.QueryString["parentPage"].ToString();
			MId = base.Request.QueryString["mid"].ToString();
			AmdNo = base.Request.QueryString["AmdNo"].ToString();
			Key = base.Request.QueryString["Key"].ToString();
			myifram.Attributes.Add("src", "PO_SPR_Print_Page.aspx?mid=" + MId + "&ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + Key);
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(parentPage + "?Code=" + SupCode + "&ModId=6&SubModId=35");
	}
}

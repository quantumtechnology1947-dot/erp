using System;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_PR_View_Print_Details : Page, IRequiresSessionState
{
	private string SupCode = "";

	private string PoNo = "";

	private string parentPage = "";

	private string MId = "";

	private string AmdNo = string.Empty;

	private string SwithctTo = "";

	private string Key = string.Empty;

	private string Trans = string.Empty;

	protected Button Cancel;

	protected HtmlGenericControl myiframe;

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
			Trans = base.Request.QueryString["Trans"].ToString();
			if (!string.IsNullOrEmpty(base.Request.QueryString["Swto"]))
			{
				SwithctTo = base.Request.QueryString["Swto"].ToString();
			}
			myiframe.Attributes.Add("src", "PO_PR_Print_Page.aspx?mid=" + MId + "&ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + Key);
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(parentPage + "?Code=" + SupCode + "&SwitchTo=" + SwithctTo + "&Trans=" + Trans + "&ModId=6&SubModId=35");
	}
}

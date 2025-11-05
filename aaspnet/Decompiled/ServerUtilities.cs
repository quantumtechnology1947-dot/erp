using System.Web.Script.Services;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ServerUtilities : WebService
{
	[WebMethod(EnableSession = true)]
	[ScriptMethod]
	public void SetTabIndex(int index)
	{
		base.Session["TabIndex"] = index.ToString();
	}
}

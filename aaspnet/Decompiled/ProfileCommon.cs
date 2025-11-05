using System.Collections;
using System.Web.Profile;

public class ProfileCommon : ProfileBase
{
	public virtual ArrayList erp
	{
		get
		{
			return (ArrayList)GetPropertyValue("erp");
		}
		set
		{
			SetPropertyValue("erp", value);
		}
	}

	public virtual ProfileCommon GetProfile(string username)
	{
		return (ProfileCommon)ProfileBase.Create(username);
	}
}

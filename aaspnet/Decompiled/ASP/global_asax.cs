using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASP;

[CompilerGlobalScope]
public class global_asax : HttpApplication
{
	private static bool __initialized;

	protected ProfileCommon Profile => (ProfileCommon)base.Context.Profile;

	private void Application_Start(object sender, EventArgs e)
	{
	}

	private void Application_End(object sender, EventArgs e)
	{
	}

	private void Application_Error(object sender, EventArgs e)
	{
	}

	private void Session_Start(object sender, EventArgs e)
	{
	}

	private void Session_End(object sender, EventArgs e)
	{
	}

	[DebuggerNonUserCode]
	public global_asax()
	{
		if (!__initialized)
		{
			__initialized = true;
		}
	}
}

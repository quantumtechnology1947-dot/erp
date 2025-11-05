using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;

public class Download : Page, IRequiresSessionState
{
	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			string text = base.Request.QueryString.Get("Id");
			string tbl = base.Request.QueryString.Get("tbl");
			string fd = base.Request.QueryString.Get("qfd");
			string fn = base.Request.QueryString.Get("qfn");
			string ct = base.Request.QueryString.Get("qct");
			string cmdText = fun.select("*", tbl, "Id='" + text + "'");
			SqlCommand cmd = new SqlCommand(cmdText);
			DataTable data = fun.GetData(cmd);
			if (data != null)
			{
				download(data, fd, fn, ct);
			}
		}
		catch (Exception)
		{
		}
	}

	private void download(DataTable dt, string fd, string fn, string ct)
	{
		try
		{
			byte[] buffer = (byte[])dt.Rows[0][fd];
			base.Response.Buffer = true;
			base.Response.Charset = "";
			base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			base.Response.ContentType = dt.Rows[0][ct].ToString();
			base.Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0][fn].ToString());
			base.Response.BinaryWrite(buffer);
			base.Response.Flush();
			base.Response.End();
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_PopUpNews : Page, IRequiresSessionState
{
	protected Label lblTitle;

	protected Label lbldate;

	protected Label lblTime;

	protected Label lblMsg;

	protected Panel Panel1;

	protected Button Button1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			int num = 0;
			Convert.ToInt32(Session["compid"]);
			if (base.Request.QueryString["Id"] != null && base.Request.QueryString["Id"] != "")
			{
				num = Convert.ToInt32(base.Request.QueryString["Id"]);
				string cmdText = fun.select("*", "tblHR_News_Notices", "Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				lbldate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
				lblTime.Text = dataSet.Tables[0].Rows[0]["SysTime"].ToString();
				lblMsg.Text = dataSet.Tables[0].Rows[0]["InDetails"].ToString();
				lblTitle.Text = dataSet.Tables[0].Rows[0]["Title"].ToString();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Write("<script language=javascript> window.close()</script>");
		base.Response.End();
	}
}

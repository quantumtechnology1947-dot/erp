using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class MasterPage : System.Web.UI.MasterPage
{
	protected ContentPlaceHolder head;

	protected HtmlLink Link1;

	protected GridView GridView1;

	protected Label Label1;

	protected Label lblFinYrs;

	protected ContentPlaceHolder cp3;

	protected Label New;

	protected Label Edit;

	protected Label Delete;

	protected Label Print;

	protected LoginStatus LoginStatus1;

	protected ContentPlaceHolder cp1;

	protected Label lblEmpName;

	protected Image Image1;

	protected ContentPlaceHolder cp2;

	protected Label lblModName;

	protected ScriptManager ScriptManager;

	protected ContentPlaceHolder MainContent;

	protected TreeView TreeView1;

	protected SiteMapDataSource SiteMapDataSource1;

	protected RadSlidingPane Menu;

	protected ContentPlaceHolder ContentPlaceHolder2;

	protected TreeView TreeView2;

	protected SiteMapDataSource SiteMapDataSource2;

	protected RadSlidingPane Help;

	protected RadSlidingZone SlidingZone1;

	protected RadPane Radpane1;

	protected RadSplitBar Radsplitbar3;

	protected ContentPlaceHolder ContentPlaceHolder3;

	protected RadPane topPane;

	protected RadSplitBar RadSplitbar2;

	protected ContentPlaceHolder ContentPlaceHolder4;

	protected RadPane contentPane;

	protected RadSplitter RadSplitter3;

	protected RadPane RadPane2;

	protected RadSplitter RadSplitter1;

	protected HtmlForm form2;

	private clsFunctions fun = new clsFunctions();

	private string ServerIp = "";

	protected string dypath = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public string PageToSentAfterSessionTimeOut
	{
		get
		{
			string host = HttpContext.Current.Request.Url.Host;
			IPAddress[] hostAddresses = Dns.GetHostAddresses(host);
			return "http://" + hostAddresses[0].ToString() + "/newerp";
		}
	}

	public int SessionTimeOutWithin => base.Session.Timeout;

	protected override void OnPreRender(EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			base.OnPreRender(e);
			int num = Convert.ToInt32(base.Session["compid"]);
			Convert.ToString(base.Session["username"]);
			sqlConnection.Open();
			string cmdText = fun.select("ServerIp", "tblCompany_master", "CompId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblCompany_master");
			ServerIp = dataSet.Tables[0].Rows[0][0].ToString();
			head.Controls.Add(new LiteralControl(string.Format("<meta http-equiv='refresh'content='{0};url={1}'>", SessionTimeOutWithin * 60, PageToSentAfterSessionTimeOut, ServerIp)));
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void initNotify(string StrSplash)
	{
		if (!base.IsPostBack)
		{
			base.Response.Write($"<script type='text/javascript' src='Javascript/loadingNotifier.js'></script>\r\n              <script language='javascript' type='text/javascript'>\r\n              initLoader('{StrSplash}');\r\n              </script>");
			base.Response.Flush();
		}
	}

	public void Notify(string strPercent, string strMessage)
	{
		if (!base.IsPostBack)
		{
			base.Response.Write($"<script language='javascript' type='text/javascript'>setProgress({strPercent},'{strMessage}'); </script>");
			base.Response.Flush();
		}
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		if (Context.Session == null || !base.Session.IsNewSession)
		{
			return;
		}
		HttpCookie httpCookie = base.Request.Cookies["ASP.NET_SessionId"];
		if (httpCookie != null)
		{
			string value = httpCookie.Value;
			if (value != string.Empty)
			{
				base.Response.Redirect("~/Login.aspx");
			}
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		New.Visible = false;
		Edit.Visible = false;
		Print.Visible = false;
		Delete.Visible = false;
		int compId = Convert.ToInt32(base.Session["compid"]);
		int num = Convert.ToInt32(base.Session["finyear"]);
		string text = Convert.ToString(base.Session["username"]);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			lblFinYrs.Text = dataSet.Tables[0].Rows[0][0].ToString();
			int num2 = 0;
			int num3 = 0;
			num2 = ((base.Request.QueryString["ModId"] != "") ? Convert.ToInt32(base.Request.QueryString["ModId"]) : 0);
			num3 = ((base.Request.QueryString["SubModId"] != "") ? Convert.ToInt32(base.Request.QueryString["SubModId"]) : 0);
			if (num2 > 0)
			{
				string cmdText2 = fun.select("ModName", "tblModule_Master", "ModId='" + num2 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblModule_Master");
				lblModName.Text = dataSet2.Tables[0].Rows[0]["ModName"].ToString();
			}
			int[] array = fun.AcessMaster(compId, num, text, num2, num3);
			for (int i = 0; i < array.Count(); i++)
			{
				DataSet dataSet3 = new DataSet();
				string cmdText3 = fun.select("LinkPage", "tblSubModLink_Master", "SubModId=" + num3 + "and Access=" + array[i]);
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3, "tblSubModLink_Master");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					string text2 = Convert.ToString(dataSet3.Tables[0].Rows[0]["LinkPage"]);
					if (array[i] == 1)
					{
						New.Visible = true;
						New.Text = fun.link(text2 + "?ModId=" + num2 + "&SubModId=" + num3, "New");
					}
					if (array[i] == 2)
					{
						Edit.Visible = true;
						Edit.Text = fun.link(text2 + "?ModId=" + num2 + "&SubModId=" + num3, "Edit");
					}
					if (array[i] == 3)
					{
						Delete.Visible = true;
						Delete.Text = fun.link(text2 + "?ModId=" + num2 + "&SubModId=" + num3, "Delete");
					}
					if (array[i] == 4)
					{
						Print.Visible = true;
						Print.Text = fun.link(text2 + "?ModId=" + num2 + "&SubModId=" + num3, "Print");
					}
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		try
		{
			sqlConnection.Open();
			dypath = TemplateSourceDirectory;
			Page.ClientScript.RegisterClientScriptInclude(GetType(), "jscript", ResolveClientUrl("~/Javascript/JScript.js"));
			DataSet dataSet4 = new DataSet();
			DataSet dataSet5 = new DataSet();
			string cmdText4 = fun.select("*", "tblCompany_master", "DefaultComp=1");
			string cmdText5 = fun.select("EmployeeName", "tblHR_OfficeStaff", "EmpId='" + text + "'");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			sqlDataAdapter4.Fill(dataSet4, "tblCompany_master");
			sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
			Label1.Text = dataSet4.Tables[0].Rows[0]["CompanyName"].ToString();
			lblEmpName.Text = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString() + " [" + text + "]";
			base.Session["EmpName"] = lblEmpName.Text;
			GridView1.DataSource = dataSet4;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
	{
		try
		{
			LinqChatDataContext linqChatDataContext = new LinqChatDataContext();
			LoggedInUser entity = linqChatDataContext.LoggedInUsers.Where((LoggedInUser l) => l.UserID == Convert.ToInt32(Session["ChatUserID"])).SingleOrDefault();
			linqChatDataContext.LoggedInUsers.DeleteOnSubmit(entity);
			linqChatDataContext.SubmitChanges();
			base.Session.RemoveAll();
			base.Session.Abandon();
		}
		catch (Exception)
		{
		}
	}
}

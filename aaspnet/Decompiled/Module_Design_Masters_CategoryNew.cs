using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_CategoryNew : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sysdate = "";

	private string systime = "";

	private string compid = "";

	private string finyrsid = "";

	private string sessionid = "";

	private string connStr = "";

	private SqlConnection con;

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		sysdate = fun.getCurrDate();
		systime = fun.getCurrTime();
		compid = Session["compid"].ToString();
		finyrsid = Session["finyear"].ToString();
		sessionid = Session["username"].ToString();
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Add")
		{
			string text = ((TextBox)GridView1.FooterRow.FindControl("txtCName")).Text;
			string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtAbb")).Text;
			string text3 = "";
			if (text != "" && text2 != "")
			{
				string cmdText = fun.select("Symbol", "tblDG_Category_Master", "Symbol='" + text2 + "'And CompId='" + compid + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					LocalSqlServer.InsertParameters["SysDate"].DefaultValue = sysdate;
					LocalSqlServer.InsertParameters["SysTime"].DefaultValue = systime;
					LocalSqlServer.InsertParameters["CompId"].DefaultValue = compid;
					LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = finyrsid;
					LocalSqlServer.InsertParameters["SessinId"].DefaultValue = sessionid;
					LocalSqlServer.InsertParameters["CName"].DefaultValue = text;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2.ToUpper();
					text3 = ((!((CheckBox)GridView1.FooterRow.FindControl("CheckBox1")).Checked) ? "0" : "1");
					LocalSqlServer.InsertParameters["HasSubCat"].DefaultValue = text3;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
				else
				{
					_ = string.Empty;
					string text4 = "Category is already exists.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text4 + "');", addScriptTags: true);
				}
			}
		}
		else
		{
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string text5 = "";
			string text6 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCName")).Text;
			string text7 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbb")).Text;
			if (text6 != "" && text7 != "")
			{
				string cmdText2 = fun.select("Symbol", "tblDG_Category_Master", "Symbol='" + text7 + "'And CompId='" + compid + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					LocalSqlServer.InsertParameters["SysDate"].DefaultValue = sysdate;
					LocalSqlServer.InsertParameters["SysTime"].DefaultValue = systime;
					LocalSqlServer.InsertParameters["CompId"].DefaultValue = compid;
					LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = finyrsid;
					LocalSqlServer.InsertParameters["SessinId"].DefaultValue = sessionid;
					LocalSqlServer.InsertParameters["CName"].DefaultValue = text6;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text7.ToUpper();
					text5 = ((!((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox1")).Checked) ? "0" : "1");
					LocalSqlServer.InsertParameters["HasSubCat"].DefaultValue = text5;
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
				else
				{
					_ = string.Empty;
					string text8 = "Category is already exists.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text8 + "');", addScriptTags: true);
				}
			}
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void G(object sender, GridViewPageEventArgs e)
	{
	}
}

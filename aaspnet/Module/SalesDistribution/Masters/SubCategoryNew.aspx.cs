using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_SubCategoryNew : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("ddCategory")).SelectedValue);
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtSCName")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol")).Text;
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string defaultValue = Session["username"].ToString();
				int num2 = Convert.ToInt32(Session["compid"]);
				int num3 = Convert.ToInt32(Session["finyear"]);
				string cmdText = fun.select("Symbol", "tblSD_WO_SubCategory", "CompId='" + num2 + "' And CId='" + num + "' AND  Symbol='" + text2 + "'And FinYearId<='" + num3 + "' Order by CId desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					if (text != "" && text2 != "")
					{
						LocalSqlServer.InsertParameters["SysDate"].DefaultValue = currDate.ToString();
						LocalSqlServer.InsertParameters["SysTime"].DefaultValue = currTime;
						LocalSqlServer.InsertParameters["CompId"].DefaultValue = num2.ToString();
						LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = num3.ToString();
						LocalSqlServer.InsertParameters["SessionId"].DefaultValue = defaultValue;
						LocalSqlServer.InsertParameters["CId"].DefaultValue = num.ToString();
						LocalSqlServer.InsertParameters["SCName"].DefaultValue = text;
						LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2.ToUpper();
						LocalSqlServer.Insert();
						lblMessage.Text = "Record Inserted.";
					}
				}
				else
				{
					string empty = string.Empty;
					empty = "SubCategory symbol is already used.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else if (e.CommandName == "Add1")
			{
				int num4 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddCategory")).SelectedValue);
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSCName")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
				string currDate2 = fun.getCurrDate();
				string currTime2 = fun.getCurrTime();
				string defaultValue2 = Session["username"].ToString();
				int num5 = Convert.ToInt32(Session["compid"]);
				int num6 = Convert.ToInt32(Session["finyear"]);
				if (text3 != "" && text4 != "")
				{
					LocalSqlServer.InsertParameters["SysDate"].DefaultValue = currDate2.ToString();
					LocalSqlServer.InsertParameters["SysTime"].DefaultValue = currTime2;
					LocalSqlServer.InsertParameters["CompId"].DefaultValue = num5.ToString();
					LocalSqlServer.InsertParameters["FinYearId"].DefaultValue = num6.ToString();
					LocalSqlServer.InsertParameters["SessionId"].DefaultValue = defaultValue2;
					LocalSqlServer.InsertParameters["CId"].DefaultValue = num4.ToString();
					LocalSqlServer.InsertParameters["SCName"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text4.ToUpper();
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted.";
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

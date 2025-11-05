using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_Budget_Dist_Dept : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected ScriptManager ScriptManager1;

	protected UpdatePanel up;

	protected TabPanel TabPanel1;

	protected GridView GridView2;

	protected SqlDataSource LocalSqlServer0;

	protected UpdatePanel UpdatePanel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		_ = base.IsPostBack;
		TabContainer1.OnClientActiveTabChanged = "OnChanged";
		TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(base.Request.QueryString["id"]);
			int num3 = 0;
			if (e.CommandName == "Insert")
			{
				sqlConnection.Open();
				foreach (GridViewRow row in GridView1.Rows)
				{
					if (((CheckBox)row.FindControl("CheckBox1")).Checked)
					{
						num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						double num4 = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text);
						if (num4 > 0.0)
						{
							string cmdText = "Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,DeptId,AccId,Amount  ) VALUES  ('" + currDate + "','" + currTime + "','" + CompId + "','" + num + "','" + text + "','" + num2 + "','" + num3 + "','" + num4 + "')";
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
					}
				}
			}
			if (e.CommandName == "export")
			{
				base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dept_Print.aspx?ModId=14");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(base.Request.QueryString["id"]);
			int num3 = 0;
			if (e.CommandName == "Insert")
			{
				sqlConnection.Open();
				foreach (GridViewRow row in GridView2.Rows)
				{
					if (((CheckBox)row.FindControl("CheckBox2")).Checked)
					{
						num3 = Convert.ToInt32(((Label)row.FindControl("lblId0")).Text);
						double num4 = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount0")).Text);
						if (num4 > 0.0)
						{
							string cmdText = "Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,DeptId,AccId,Amount  ) VALUES  ('" + currDate + "','" + currTime + "','" + CompId + "','" + num + "','" + text + "','" + num2 + "','" + num3 + "','" + num4 + "')";
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
					}
				}
			}
			if (e.CommandName == "export")
			{
				base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dept_Print.aspx?ModId=14");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((TextBox)row.FindControl("TxtAmount")).Visible = true;
					((Label)row.FindControl("lblAmount")).Visible = false;
					GridView1.Visible = true;
					GridView2.Visible = true;
				}
				else
				{
					((Label)row.FindControl("lblAmount")).Visible = true;
					((TextBox)row.FindControl("TxtAmount")).Visible = false;
					GridView1.Visible = true;
					GridView2.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					((Label)row.FindControl("lblAmount0")).Visible = false;
					((TextBox)row.FindControl("TxtAmount0")).Visible = true;
					GridView1.Visible = true;
					GridView2.Visible = true;
				}
				else
				{
					((Label)row.FindControl("lblAmount0")).Visible = true;
					((TextBox)row.FindControl("TxtAmount0")).Visible = false;
					GridView1.Visible = true;
					GridView2.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}
}

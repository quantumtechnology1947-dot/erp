using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_Dist_Dept_Details : Page, IRequiresSessionState
{
	protected Label Label5;

	protected Label lbldept;

	protected Label Label2;

	protected Label lblCode;

	protected Label Label4;

	protected Label lblDesc;

	protected GridView GridView2;

	protected Label lblMessage;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		lblMessage.Text = "";
		if (base.IsPostBack)
		{
			return;
		}
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		string text = "";
		try
		{
			text = base.Request.QueryString["Id"];
			string text2 = base.Request.QueryString["DeptId"];
			string cmdText = "Select Description from tblHR_Departments where Id='" + text2 + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			lbldept.Text = dataSet.Tables[0].Rows[0]["Description"].ToString();
			string cmdText2 = "Select tblACC_Budget_Dept.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept.SysDate , CHARINDEX('-',tblACC_Budget_Dept.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', tblACC_Budget_Dept.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept.SysTime,AccHead.Description,AccHead.Symbol,tblACC_Budget_Dept.Amount from  tblACC_Budget_Dept ,AccHead where   AccHead.Id=tblACC_Budget_Dept.AccId and tblACC_Budget_Dept.DeptId='" + text2 + "'  and tblACC_Budget_Dept.AccId='" + text + "' ";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			GridView2.DataSource = dataSet2;
			GridView2.DataBind();
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblDesc.Text = dataSet2.Tables[0].Rows[0]["Description"].ToString();
				lblCode.Text = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
			}
		}
		catch (Exception)
		{
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
			if (e.CommandName == "Update")
			{
				sqlConnection.Open();
				foreach (GridViewRow row in GridView2.Rows)
				{
					if (((CheckBox)row.FindControl("CheckBox1")).Checked)
					{
						Convert.ToInt32(base.Request.QueryString["Id"]);
						double num2 = Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text), 2);
						int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						if (num2 > 0.0)
						{
							string cmdText = "Update   tblACC_Budget_Dept  set SysDate='" + currDate + "'  ,SysTime='" + currTime + "',CompId='" + CompId + "',FinYearId='" + num + "',SessionId='" + text + "'  ,Amount='" + num2 + "'  where Id='" + num3 + "' ";
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							lblMessage.Text = "Record Updated";
						}
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "cancel")
			{
				try
				{
					string text2 = base.Request.QueryString["DeptId"];
					base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Dept.aspx?id=" + text2 + "&ModId=14");
				}
				catch (Exception)
				{
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
			if (!(e.CommandName == "Deletes"))
			{
				return;
			}
			sqlConnection.Open();
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				if (((CheckBox)row2.FindControl("CheckBox1")).Checked)
				{
					int num4 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					string cmdText2 = " Delete from tblACC_Budget_Dept where  Id='" + num4 + "'";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					lblMessage.Text = "Record Deleted";
				}
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((TextBox)row.FindControl("TxtAmount")).Visible = true;
					((Label)row.FindControl("lblAmount")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblAmount")).Visible = true;
					((TextBox)row.FindControl("TxtAmount")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

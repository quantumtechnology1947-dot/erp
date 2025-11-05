using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Transactions_Budget_Dist_Dept_Details : Page, IRequiresSessionState
{
	protected Label Label5;

	protected Label lbldept;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnUpdate;

	protected Button BtnDelete;

	protected Button btnCancel;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		lblMessage.Text = "";
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			_ = base.Request.QueryString["Id"];
			string text = base.Request.QueryString["BGId"];
			if (!base.IsPostBack)
			{
				string cmdText = "Select Name from BusinessGroup where Id='" + text + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				lbldept.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
				string cmdText2 = "Select tblACC_Budget_Dept.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept.SysDate , CHARINDEX('-',tblACC_Budget_Dept.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', tblACC_Budget_Dept.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept.SysTime,BusinessGroup.Name,BusinessGroup.Symbol,tblACC_Budget_Dept.Amount from  tblACC_Budget_Dept ,BusinessGroup where   BusinessGroup.Id=tblACC_Budget_Dept.BGId and tblACC_Budget_Dept.BGId='" + text + "' and tblACC_Budget_Dept.FinYearId=" + FinYearId + "  ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					GridView2.DataSource = dataSet2;
					GridView2.DataBind();
				}
				else
				{
					base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist.aspx?ModId=14");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
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

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
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
		catch (Exception)
		{
		}
	}

	protected void BtnDelete_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string cmdText = " Delete from tblACC_Budget_Dept where  Id='" + num + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					lblMessage.Text = "Record Deleted";
				}
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			_ = base.Request.QueryString["BGId"];
			base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist.aspx?ModId=14");
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}

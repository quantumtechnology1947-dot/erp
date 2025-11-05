using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_WithMaterial_Details : Page, IRequiresSessionState
{
	protected Label Label2;

	protected Label lblCode;

	protected Label Label4;

	protected Label lblDesc;

	protected GridView GridView2;

	protected Label lblMessage;

	protected Button BtnExport;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		CompId = Convert.ToInt32(Session["compid"]);
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				string text = base.Request.QueryString["Id"];
				lblCode.Text = text;
				SqlCommand selectCommand = new SqlCommand("Select   tblACC_Budget_Transactions.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Transactions.SysDate , CHARINDEX('-',tblACC_Budget_Transactions.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', tblACC_Budget_Transactions.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Transactions.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Transactions.SysTime,tblACC_Budget_Transactions.BudgetCode,  AccHead.Description+'-'+ AccHead.Symbol  AS Description,tblACC_Budget_Transactions.Amount  from  AccHead ,tblACC_Budget_Transactions where tblACC_Budget_Transactions.BudgetCode=AccHead.Id  and  AccHead.Id='" + text + "'", connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
				lblDesc.Text = dataSet.Tables[0].Rows[0]["Description"].ToString();
			}
			catch (Exception)
			{
			}
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
						double num2 = Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text), 2);
						int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						if (num2 > 0.0)
						{
							string cmdText = "Update   tblACC_Budget_Transactions  set SysDate='" + currDate + "'  ,SysTime='" + currTime + "',CompId='" + CompId + "',FinYearId='" + num + "',SessionId='" + text + "'  ,Amount='" + num2 + "'  where Id='" + num3 + "' ";
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							lblMessage.Text = "Record Updated";
						}
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
					string cmdText2 = " Delete from tblACC_Budget_Transactions where  Id='" + num4 + "'";
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

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		lblMessage.Text = "Record Updated";
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

	protected void BtnExport_Click(object sender, EventArgs e)
	{
		try
		{
			string text = base.Request.QueryString["Id"];
			base.Response.Redirect("~/Module/MIS/Transactions/Budget_WithMaterial_Print.aspx?Id=" + text);
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MIS/Transactions/Dashboard.aspx?ModId=14");
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

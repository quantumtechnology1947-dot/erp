using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_WONo_Details : Page, IRequiresSessionState
{
	protected Label Label5;

	protected Label lblWONo;

	protected Label Label2;

	protected Label lblCode;

	protected Label Label4;

	protected Label lblDesc;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnUpdate;

	protected Button BtnDelete;

	protected Button BtnCancel;

	protected Label lblMessage;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinId = Convert.ToInt32(Session["finyear"]);
		lblMessage.Text = "";
		if (!base.IsPostBack)
		{
			FillGrid();
		}
	}

	public void FillGrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string text = base.Request.QueryString["Id"];
			string text2 = base.Request.QueryString["WONo"];
			lblWONo.Text = text2;
			string cmdText = "Select tblACC_Budget_WO.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_WO.SysDate , CHARINDEX('-',tblACC_Budget_WO.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_WO.SysDate , CHARINDEX('-', tblACC_Budget_WO.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_WO.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_WO.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_WO.SysTime,  tblMIS_BudgetCode.Description,tblMIS_BudgetCode.Symbol,tblACC_Budget_WO.Amount  from  tblACC_Budget_WO ,tblMIS_BudgetCode where   tblMIS_BudgetCode.Id=tblACC_Budget_WO.BudgetCodeId and tblACC_Budget_WO.WONo='" + text2 + "'and tblACC_Budget_WO.FinYearId=" + FinId + "  and tblACC_Budget_WO.BudgetCodeId='" + text + "' order by Id Desc ";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
			}
			else
			{
				base.Response.Redirect("~/Module/MIS/Transactions/Budget_WONo.aspx?WONo=" + text2);
			}
			lblDesc.Text = dataSet.Tables[0].Rows[0]["Description"].ToString();
			lblCode.Text = dataSet.Tables[0].Rows[0]["Symbol"].ToString() + text2;
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
					int num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					Convert.ToInt32(base.Request.QueryString["Id"]);
					double num3 = Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text), 2);
					if (num3 > 0.0)
					{
						string cmdText = "Update   tblACC_Budget_WO  set SysDate='" + currDate + "'  ,SysTime='" + currTime + "',CompId='" + CompId + "',FinYearId='" + num + "',SessionId='" + text + "'  ,Amount='" + num3 + "'  where Id='" + num2 + "' ";
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
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void BtnDelete_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string cmdText = " Delete from tblACC_Budget_WO where  Id='" + num + "'";
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
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		string text = base.Request.QueryString["WONo"];
		base.Response.Redirect("~/Module/MIS/Transactions/Budget_WONo.aspx?WONo=" + text);
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			FillGrid();
		}
		catch (Exception)
		{
		}
	}
}

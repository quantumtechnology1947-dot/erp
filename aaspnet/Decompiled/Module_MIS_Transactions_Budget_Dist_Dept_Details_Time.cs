using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Transactions_Budget_Dist_Dept_Details_Time : Page, IRequiresSessionState
{
	protected Label Label5;

	protected Label lbldept;

	protected Label Label2;

	protected Label lblCode;

	protected Label lblThr;

	protected Label lblTotalHr;

	protected Label lblUhr;

	protected Label lblUsedHr;

	protected Label lblBhr;

	protected Label lblBalHr;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnUpdate;

	protected Button btnCancel;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private int CompId;

	private int FinYearId;

	private string Code = string.Empty;

	private int BGId;

	private double TotalHr;

	private double UsedHr;

	private double BalHr;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string sId = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		sId = Session["username"].ToString();
		Code = base.Request.QueryString["Id"];
		BGId = Convert.ToInt32(base.Request.QueryString["BGId"]);
		lblMessage.Text = "";
		if (!base.IsPostBack)
		{
			FillGrid();
		}
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		int num = 0;
		num = FinYearId - 1;
		double num2 = 0.0;
		num2 = calbalbud.TotBalBudget_BG(BGId, CompId, num, 0);
		string cmdText = "select Sum(Hour) As Hour from tblACC_Budget_Dept_Time where BudgetCodeId='" + Code + "'  and  BGGroup='" + BGId + "' And FinYearId=" + FinYearId + "  group by  BudgetCodeId ";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblACC_Budget_Dept_Time");
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			TotalHr = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Hour"]) + num2, 2);
		}
		else
		{
			TotalHr = num2;
		}
		UsedHr = Math.Round(Convert.ToDouble(CUH.TotFillPart(Convert.ToInt32(Code), "", BGId, CompId, FinYearId, 0)), 2);
		BalHr = Math.Round(TotalHr - UsedHr, 2);
		lblTotalHr.Text = TotalHr.ToString();
		lblUsedHr.Text = UsedHr.ToString();
		lblBalHr.Text = BalHr.ToString();
	}

	public void FillGrid()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = "Select Name,Symbol from BusinessGroup where Id='" + BGId + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			lbldept.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
			string cmdText2 = "Select tblACC_Budget_Dept_Time.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-',tblACC_Budget_Dept_Time.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-', tblACC_Budget_Dept_Time.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept_Time.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept_Time.SysTime, tblHR_Grade.Description,tblHR_Grade.Symbol,tblACC_Budget_Dept_Time.Hour from  tblACC_Budget_Dept_Time ,tblHR_Grade where tblHR_Grade.Id=tblACC_Budget_Dept_Time.BudgetCodeId and tblACC_Budget_Dept_Time.BGGroup='" + BGId + "'  and tblACC_Budget_Dept_Time.BudgetCodeId='" + Code + "' order by Id Desc ";
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
				base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?ModId=14");
			}
			lblCode.Text = dataSet2.Tables[0].Rows[0]["Symbol"].ToString() + dataSet.Tables[0].Rows[0]["Symbol"].ToString();
		}
		catch (Exception)
		{
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

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			sqlConnection.Open();
			double num = 0.0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num += Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text), 2);
				}
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num += Math.Round(Convert.ToDouble(((Label)row.FindControl("lblAmount")).Text), 2);
				}
			}
			double num2 = 0.0;
			num2 = Math.Round(num - UsedHr, 2);
			int num3 = 0;
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				if (!((CheckBox)row2.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				double num4 = Math.Round(Convert.ToDouble(((TextBox)row2.FindControl("TxtAmount")).Text), 2);
				int num5 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
				if (num4 > 0.0)
				{
					if (num2 >= 0.0)
					{
						string cmdText = "Update tblACC_Budget_Dept_Time  set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "' ,Hour='" + num4 + "'  where Id='" + num5 + "' ";
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						lblMessage.Text = "Record Updated";
						num3++;
					}
					else
					{
						string empty = string.Empty;
						empty = "Only " + BalHr + " hours are Balanced";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			if (num3 > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			string text = base.Request.QueryString["BGId"];
			base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?BGId=" + text + "&ModId=14");
		}
		catch (Exception)
		{
		}
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TxtAmount")).Text);
				if (BalHr >= num2)
				{
					string cmdText = "Delete from tblACC_Budget_Dept_Time where  Id='" + num + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "You can not delete this record, Because  hours are " + BalHr + " only.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_Budget_Dist_Time : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected Panel Panel2;

	protected Button btnCancel1;

	protected Label lblBG;

	protected Label lblBGGroup;

	protected Label HField;

	protected GridView GridView1;

	protected Panel Panel1;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

	protected Button BtnInsert;

	protected Button BtnExport;

	protected Button btnCancel;

	protected TabPanel TabPanel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private int CompId;

	private string SId = "";

	private int FinYearId;

	private string BGid = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		CompId = Convert.ToInt32(Session["compid"]);
		SId = Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		if (!string.IsNullOrEmpty(base.Request.QueryString["BGId"]))
		{
			BGid = base.Request.QueryString["BGId"].ToString();
		}
		if (!base.IsPostBack && BGid != "")
		{
			string cmdText = "Select Name,Symbol from BusinessGroup where Id='" + BGid + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			lblBGGroup.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
			HField.Text = BGid;
			ViewState["BGSymbol"] = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
			FillGrid();
			btnCancel1.Visible = false;
		}
		TabContainer1.OnClientActiveTabChanged = "OnChanged";
		TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
	}

	public void FillGrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
		dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
		string cmdText = fun.select("Id,Description AS Name,Symbol", "tblHR_Grade", "Id!=1");
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		GridView1.DataSource = dataSet.Tables[0];
		GridView1.DataBind();
		if (GridView1.Rows.Count > 0)
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText2 = fun.select("Symbol", "tblHR_Grade", "Id='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				((Label)row.FindControl("LblBudgetCode")).Text = dataSet2.Tables[0].Rows[0]["Symbol"].ToString() + ViewState["BGSymbol"].ToString();
			}
		}
		lblBG.Visible = true;
		lblBGGroup.Visible = true;
		CalculateBalAmt();
		BtnInsert.Visible = true;
		BtnExport.Visible = true;
		btnCancel.Visible = true;
	}

	public void CalculateBalAmt()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			int num = 0;
			num = FinYearId - 1;
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Sr No", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget Hour", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Used Hour", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bal Hour", typeof(double)));
			int num2 = 1;
			foreach (GridViewRow row in GridView1.Rows)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = num2++;
				dataRow[1] = ((Label)row.FindControl("lblSymbol")).Text;
				dataRow[2] = ((Label)row.FindControl("LblBudgetCode")).Text;
				int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				double num4 = 0.0;
				double num5 = 0.0;
				num5 = calbalbud.TotBalBudget_BG(num3, CompId, num, 0);
				string cmdText = "select Sum(Hour) As Hour from tblACC_Budget_Dept_Time where BudgetCodeId='" + num3 + "'  and  BGGroup='" + HField.Text + "' And FinYearId<=" + FinYearId + "  group by  BudgetCodeId ";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_Budget_Dept_Time");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num4 = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Hour"]) + num5, 2);
					((HyperLink)row.FindControl("HyperLink1")).Visible = true;
				}
				else
				{
					num4 = num5;
					((HyperLink)row.FindControl("HyperLink1")).Visible = false;
				}
				double num6 = 0.0;
				num6 = Math.Round(Convert.ToDouble(CUH.TotFillPart(num3, "", Convert.ToInt32(HField.Text), CompId, FinYearId, 0)), 2);
				double num7 = 0.0;
				num7 = Math.Round(num4 - num6, 2);
				((Label)row.FindControl("lblHour")).Text = num4.ToString();
				((Label)row.FindControl("LblUsedHour")).Text = num6.ToString();
				((Label)row.FindControl("LblBalHour")).Text = num7.ToString();
				dataRow[3] = Math.Round(num4, 2);
				dataRow[4] = num6.ToString();
				dataRow[5] = num7.ToString();
				((HyperLink)row.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details_Time.aspx?BGId=" + HField.Text + "&Id=" + num3 + "&ModId=14";
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			ViewState["dtList"] = dataTable;
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
					((TextBox)row.FindControl("TxtHour")).Visible = true;
					((Label)row.FindControl("lblHour")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblHour")).Visible = true;
					((TextBox)row.FindControl("TxtHour")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?BGId=&ModId=14");
	}

	protected void btnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Menu.aspx?ModId=14&SubModId=");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void BtnInsert_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = 0;
			sqlConnection.Open();
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					double num2 = Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtHour")).Text), 2);
					if (num2 > 0.0)
					{
						string cmdText = "Insert into  tblACC_Budget_Dept_Time (SysDate,SysTime,CompId,FinYearId,SessionId,BGGroup,BudgetCodeId,Hour) VALUES  ('" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + HField.Text + "','" + num + "','" + num2 + "')";
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
					}
				}
			}
			FillGrid();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void BtnExport_Click(object sender, EventArgs e)
	{
		try
		{
			ExportToExcel exportToExcel = new ExportToExcel();
			exportToExcel.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_BG");
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			lblBGGroup.Text = ((Label)gridViewRow.FindControl("lblDesc")).Text;
			HField.Text = ((Label)gridViewRow.FindControl("lblId")).Text;
			ViewState["BGSymbol"] = ((Label)gridViewRow.FindControl("lblSymbol")).Text;
			FillGrid();
			btnCancel1.Visible = false;
		}
	}
}

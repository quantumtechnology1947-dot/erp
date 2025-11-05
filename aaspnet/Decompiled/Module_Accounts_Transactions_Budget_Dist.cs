using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_Budget_Dist : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Panel Panel1;

	protected SqlDataSource LocalSqlServer;

	protected Button BtnInsert;

	protected Button BtnExport;

	protected Button btnCancel;

	protected TabPanel TabPanel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private int CompId;

	private string SId = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		SId = Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		if (!base.IsPostBack)
		{
			CalculateBalAmt();
		}
		TabContainer1.OnClientActiveTabChanged = "OnChanged";
		TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
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
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Sr No", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PO Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Cash Pay Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Cash Rec. Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Tax", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bal Budget Amount", typeof(double)));
			int num8 = 1;
			foreach (GridViewRow row in GridView1.Rows)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = num8++;
				dataRow[1] = ((Label)row.FindControl("lblDesc")).Text;
				dataRow[2] = ((Label)row.FindControl("lblSymbol")).Text;
				int num9 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				((HyperLink)row.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details.aspx?BGId=" + num9 + "&ModId=14";
				double num10 = 0.0;
				double num11 = 0.0;
				num11 = calbalbud.TotBalBudget_BG(num9, CompId, num, 0);
				string cmdText = "select Sum(Amount) As Budget from tblACC_Budget_Dept where BGId='" + num9 + "' And FinYearId=" + FinYearId + "  group by  BGId ";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_Budget_Dept");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num10 = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Budget"]) + num11, 2);
					((HyperLink)row.FindControl("HyperLink1")).Visible = true;
				}
				else
				{
					num10 = num11;
					((HyperLink)row.FindControl("HyperLink1")).Visible = false;
				}
				((Label)row.FindControl("lblAmount")).Text = num10.ToString();
				dataRow[3] = Math.Round(num10, 2);
				num2 += Math.Round(num10, 2);
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = 0.0;
				num12 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 1, 1, "0", num9, 1, FinYearId);
				((Label)row.FindControl("lblPO")).Text = Convert.ToString(Math.Round(num12, 2));
				dataRow[4] = Math.Round(num12, 2);
				num3 += Math.Round(num12, 2);
				double num15 = 0.0;
				num15 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 1, 1, "0", num9, 2, FinYearId);
				((Label)row.FindControl("lblTax")).Text = Convert.ToString(Math.Round(num15, 2));
				string cmdText2 = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt, tblACC_CashVoucher_Payment_Details.BGGroup FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.BGGroup='" + num9 + "' And tblACC_CashVoucher_Payment_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Payment_Details.BGGroup";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					num13 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
				}
				((Label)row.FindControl("lblCashPay")).Text = Convert.ToString(Math.Round(num13, 2));
				num4 += Math.Round(num13, 2);
				string cmdText3 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt, tblACC_CashVoucher_Receipt_Master.BGGroup,  tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.BGGroup='" + num9 + "'And tblACC_CashVoucher_Receipt_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Receipt_Master.BGGroup, tblACC_CashVoucher_Receipt_Master.WONo";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					num14 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
				}
				((Label)row.FindControl("lblCashRec")).Text = Convert.ToString(Math.Round(num14, 2));
				num5 += Math.Round(num14, 2);
				dataRow[7] = Math.Round(num15, 2);
				num6 += Math.Round(num15, 2);
				dataRow[5] = Math.Round(num13, 2);
				dataRow[6] = Math.Round(num14, 2);
				double num16 = 0.0;
				num16 = Math.Round(num10 - (num12 + num15 + num13), 2) + num14;
				dataRow[8] = Math.Round(num16, 2);
				num7 += Math.Round(num16, 2);
				((Label)row.FindControl("lblBudget")).Text = num16.ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			ViewState["dtList"] = dataTable;
			((Label)GridView1.FooterRow.FindControl("TotBudgetAmt")).Text = num2.ToString();
			((Label)GridView1.FooterRow.FindControl("TotPOAmt")).Text = num3.ToString();
			((Label)GridView1.FooterRow.FindControl("TotCashPay")).Text = num4.ToString();
			((Label)GridView1.FooterRow.FindControl("TotCashRec")).Text = num5.ToString();
			((Label)GridView1.FooterRow.FindControl("TotTaxAmt")).Text = num6.ToString();
			((Label)GridView1.FooterRow.FindControl("TotBalBudgetAmt")).Text = num7.ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
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
				}
				else
				{
					((Label)row.FindControl("lblAmount")).Visible = true;
					((TextBox)row.FindControl("TxtAmount")).Visible = false;
					GridView1.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
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
					double num2 = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text);
					if (num2 > 0.0)
					{
						string cmdText = "Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,BGId,Amount  ) VALUES  ('" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + num + "','" + num2 + "')";
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
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
}

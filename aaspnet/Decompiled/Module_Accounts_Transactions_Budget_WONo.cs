using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_WONo : Page, IRequiresSessionState
{
	protected HtmlHead Head1;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button BtnInsert;

	protected Button BtnExport;

	protected Button Button1;

	protected SqlDataSource LocalSqlServer;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private string connStr = string.Empty;

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string wono = string.Empty;

	private string sId = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void CalculateBalAmt()
	{
		try
		{
			string text = base.Request.QueryString["WONo"].ToString();
			con.Open();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			int num6 = 0;
			double num7 = 0.0;
			num6 = FinYearId - 1;
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Sr No", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget Code", typeof(string)));
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
				dataRow[3] = ((Label)row.FindControl("LblBudgetCode")).Text;
				int num9 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				double value = 0.0;
				double value2 = 0.0;
				double num10 = 0.0;
				double num11 = 0.0;
				num11 = calbalbud.TotBalBudget_WONO(num9, CompId, num6, text, 0);
				string cmdText = "select Sum(Amount) As Budget from tblACC_Budget_WO where BudgetCodeId='" + num9 + "'   and  WONo='" + text + "' And FinYearId=" + FinYearId + " group by  BudgetCodeId ";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_Budget_WO");
				((HyperLink)row.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_WONo_Details.aspx?WONo=" + text + "&Id=" + num9 + "&ModId=14";
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
				double num12 = 0.0;
				double num13 = 0.0;
				num12 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 0, 1, text, 0, 1, FinYearId);
				num13 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 1, 1, text, 0, 1, FinYearId);
				((Label)row.FindControl("lblPO")).Text = Convert.ToString(Math.Round(num12 + num13, 2));
				num += Math.Round(num12 + num13, 2);
				double num14 = 0.0;
				double num15 = 0.0;
				num14 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 0, 1, text, 0, 2, FinYearId);
				num15 = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)row.FindControl("lblId")).Text), 1, 1, text, 0, 2, FinYearId);
				((Label)row.FindControl("lblTax")).Text = Convert.ToString(Math.Round(num14 + num15, 2));
				num2 += Math.Round(num14 + num15, 2);
				string cmdText2 = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt  ,tblACC_CashVoucher_Payment_Details.WONo FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.WONo='" + text + "' And tblACC_CashVoucher_Payment_Master.FinYearId=" + FinYearId + "  And     tblACC_CashVoucher_Payment_Details.BudgetCode='" + num9 + "'      GROUP BY tblACC_CashVoucher_Payment_Details.BudgetCode, tblACC_CashVoucher_Payment_Details.WONo";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					value = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
					num3 += Math.Round(value, 2);
				}
				((Label)row.FindControl("lblCashPay")).Text = Convert.ToString(Math.Round(value, 2));
				string cmdText3 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt,   tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.WONo='" + text + "'   And     tblACC_CashVoucher_Receipt_Master.BudgetCode='" + num9 + "' And tblACC_CashVoucher_Receipt_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Receipt_Master.BudgetCode, tblACC_CashVoucher_Receipt_Master.WONo";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					value2 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
					num4 += Math.Round(value2, 2);
				}
				((Label)row.FindControl("lblCashRec")).Text = Convert.ToString(Math.Round(value2, 2));
				num7 += Math.Round(num10, 2);
				dataRow[4] = Math.Round(num10, 2);
				dataRow[5] = Math.Round(num12 + num13, 2);
				dataRow[6] = Math.Round(value, 2);
				dataRow[8] = Math.Round(num14 + num15, 2);
				dataRow[7] = Math.Round(value2, 2);
				double num16 = 0.0;
				num16 = Math.Round(Convert.ToDouble(((Label)row.FindControl("lblAmount")).Text) - (Math.Round(num12 + num13, 2) + Math.Round(num14 + num15, 2) + Math.Round(value, 2)), 2) + Math.Round(value2, 2);
				((Label)row.FindControl("lblBudget")).Text = num16.ToString();
				dataRow[9] = Math.Round(num16, 2);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
				num5 += Math.Round(Convert.ToDouble(((Label)row.FindControl("lblAmount")).Text) - (Math.Round(num12 + num13, 2) + Math.Round(num14 + num15, 2) + Math.Round(value, 2)), 2) + Math.Round(value2, 2);
			}
			ViewState["dtList"] = dataTable;
			((Label)GridView1.FooterRow.FindControl("lblTotalBudAmt")).Text = num7.ToString();
			((Label)GridView1.FooterRow.FindControl("lblPO1")).Text = num.ToString();
			((Label)GridView1.FooterRow.FindControl("lblTax1")).Text = num2.ToString();
			((Label)GridView1.FooterRow.FindControl("lblBudget1")).Text = num5.ToString();
			((Label)GridView1.FooterRow.FindControl("lblCashPay1")).Text = num3.ToString();
			((Label)GridView1.FooterRow.FindControl("lblCashRec1")).Text = num4.ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		CDate = fun.getCurrDate();
		CTime = fun.getCurrTime();
		wono = base.Request.QueryString["WONo"].ToString();
		sId = Session["username"].ToString();
		try
		{
			CalculateBalAmt();
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.select("Symbol", "tblMIS_BudgetCode", "Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string text = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
				string text2 = text + wono;
				((Label)row.FindControl("LblBudgetCode")).Text = text2;
			}
		}
		catch (Exception)
		{
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Budget_Dist_WONo.aspx?ModId=14");
	}

	protected void BtnInsert_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					double num2 = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text);
					if (num2 > 0.0)
					{
						string cmdText = "Insert into  tblACC_Budget_WO (SysDate,SysTime,CompId,FinYearId,SessionId,WONo,BudgetCodeId,Amount  ) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + num + "','" + num2 + "')";
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
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
			con.Close();
		}
	}

	protected void BtnExport_Click(object sender, EventArgs e)
	{
		try
		{
			ExportToExcel exportToExcel = new ExportToExcel();
			exportToExcel.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_WONO");
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}
}

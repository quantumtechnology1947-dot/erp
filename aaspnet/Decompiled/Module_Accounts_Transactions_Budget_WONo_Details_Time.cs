using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_WONo_Details_Time : Page, IRequiresSessionState
{
	protected Label lblwn;

	protected Label lblWONo;

	protected Label Label6;

	protected Label lblCate;

	protected Label Label4;

	protected Label lblEquipNo;

	protected Label Label7;

	protected Label lblSubCate;

	protected Label Label5;

	protected Label lblDesc;

	protected Label lblThr;

	protected Label lblTotalHr;

	protected Label lblUhr;

	protected Label lblUsedHr;

	protected Label lblBhr;

	protected Label lblBalHr;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnUpdate;

	protected Button BtnCancel;

	protected Label lblMessage;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private int CompId;

	private int FinYearId;

	private string Id = string.Empty;

	private string wono = string.Empty;

	private double TotalHr;

	private double UsedHr;

	private double BalHr;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string sId = string.Empty;

	private string AllocHrs = string.Empty;

	private string UtilHrs = string.Empty;

	private string BalHrs = string.Empty;

	private string EquipId = string.Empty;

	private string CatId = string.Empty;

	private string SubCatId = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		sId = Session["username"].ToString();
		wono = base.Request.QueryString["WONo"];
		EquipId = base.Request.QueryString["Eqid"];
		AllocHrs = base.Request.QueryString["AllocHrs"];
		UtilHrs = base.Request.QueryString["UtilHrs"];
		BalHrs = base.Request.QueryString["BalHrs"];
		CatId = base.Request.QueryString["Cat"];
		SubCatId = base.Request.QueryString["SubCat"];
		lblWONo.Text = wono;
		lblMessage.Text = "";
		lblTotalHr.Text = AllocHrs.ToString();
		lblUsedHr.Text = UtilHrs.ToString();
		lblBalHr.Text = BalHrs.ToString();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!base.IsPostBack)
			{
				FillGrid();
			}
			sqlConnection.Open();
			string cmdText = "SELECT tblMIS_BudgetHrs_Field_SubCategory.SubCategory, tblMIS_BudgetHrs_Field_Category.Category, tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc FROM tblMIS_BudgetHrs_Field_Category INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId INNER JOIN  tblACC_Budget_WO_Time ON tblMIS_BudgetHrs_Field_SubCategory.Id = tblACC_Budget_WO_Time.HrsBudgetSubCat AND tblMIS_BudgetHrs_Field_Category.Id = tblACC_Budget_WO_Time.HrsBudgetCat INNER JOIN tblDG_Item_Master ON tblACC_Budget_WO_Time.EquipId = tblDG_Item_Master.Id AND tblACC_Budget_WO_Time.WONo='" + wono + "' AND tblACC_Budget_WO_Time.HrsBudgetCat='" + CatId + "' AND tblACC_Budget_WO_Time.HrsBudgetSubCat='" + SubCatId + "' AND tblACC_Budget_WO_Time.EquipId='" + EquipId + "'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			lblEquipNo.Text = sqlDataReader["ItemCode"].ToString();
			lblDesc.Text = sqlDataReader["ManfDesc"].ToString();
			lblCate.Text = sqlDataReader["Category"].ToString();
			lblSubCate.Text = sqlDataReader["SubCategory"].ToString();
		}
		catch (Exception)
		{
			sqlConnection.Close();
		}
	}

	public void FillGrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = "Select Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(SysDate , CHARINDEX('-',SysDate ) + 1, 2) + '-' + LEFT (SysDate , CHARINDEX('-', SysDate ) - 1) + '-' + RIGHT (SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_WO_Time.SysDate )) - 1)), 103), '/', '-') AS SysDate,SysTime, Hour  from  tblACC_Budget_WO_Time where WONo='" + wono + "' AND HrsBudgetCat='" + CatId + "' AND HrsBudgetSubCat='" + SubCatId + "' AND EquipId='" + EquipId + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
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
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					double num = 0.0;
					num = Math.Round(Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text), 2);
					int num2 = 0;
					num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string cmdText = "Update tblACC_Budget_WO_Time set SysDate='" + CDate + "', SysTime='" + CTime + "',SessionId='" + sId + "' ,Hour='" + num + "' where Id='" + num2 + "' ";
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
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
		base.Response.Redirect("~/Module/MIS/Transactions/Budget_WONo_Time.aspx?WONo=" + text);
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
				string cmdText = fun.delete("tblACC_Budget_WO_Time", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("*", "tblACC_Budget_WO_Time", "WONo='" + wono + "' AND HrsBudgetCat='" + CatId + "' AND HrsBudgetSubCat='" + SubCatId + "' AND EquipId='" + EquipId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				sqlDataReader.Read();
				if (sqlDataReader.HasRows)
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					base.Response.Redirect("~/Module/MIS/Transactions/Budget_WONo_Time.aspx?WONo=" + wono + "&ModId=14");
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
	}
}

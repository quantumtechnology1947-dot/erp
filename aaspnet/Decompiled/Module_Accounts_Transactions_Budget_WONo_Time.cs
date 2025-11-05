using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Budget_WONo_Time : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private PO_Budget_Amt PBM = new PO_Budget_Amt();

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private string connStr = string.Empty;

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	private string wono = string.Empty;

	private string sId = string.Empty;

	protected HtmlHead Head1;

	protected Label lblWoNo;

	protected Label Label1;

	protected Label Label2;

	protected Label Label3;

	protected Label Label4;

	protected DropDownList drpEqNo;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList drpCat;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected DropDownList drpSubCat;

	protected TextBox txtHrs;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected CompareValidator CompareValidator1;

	protected Button btnAdd;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button BtnInsert;

	protected Button BtnExport;

	protected Button Button1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

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
			lblWoNo.Text = wono;
			if (!base.IsPostBack)
			{
				FillEquDrp(wono, CompId.ToString());
				CalculateBalAmt();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				((HyperLink)row.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_WONo_Details_Time.aspx?WONo=" + wono + "&AllocHrs=" + ((Label)row.FindControl("lblHour")).Text + "&UtilHrs=" + ((Label)row.FindControl("LblUsedHour")).Text + "&BalHrs=" + ((Label)row.FindControl("LblBalHour")).Text + "&Eqid=" + ((Label)row.FindControl("lblEquipId")).Text + "&Cat=" + ((Label)row.FindControl("lblCatId")).Text + "&SubCat=" + ((Label)row.FindControl("lblSubCatId")).Text + "&ModId=14";
			}
		}
		catch (Exception)
		{
		}
	}

	public void CalculateBalAmt()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Equipment No", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Sub Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Budget Hrs", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Utilized Hrs", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bal Hrs", typeof(double)));
			dataTable.Columns.Add(new DataColumn("EquipId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CatId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCatId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Finish", typeof(double)));
			string cmdText = fun.select("Distinct EquipId,HrsBudgetCat,HrsBudgetSubCat", "tblACC_Budget_WO_Time", "WONo='" + wono + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = string.Concat("SELECT tblMIS_BudgetHrs_Field_SubCategory.Id as scid,tblMIS_BudgetHrs_Field_SubCategory.SubCategory, tblMIS_BudgetHrs_Field_Category.Category,tblMIS_BudgetHrs_Field_Category.Id as cid, tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc FROM tblMIS_BudgetHrs_Field_Category INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId INNER JOIN  tblACC_Budget_WO_Time ON tblMIS_BudgetHrs_Field_SubCategory.Id = tblACC_Budget_WO_Time.HrsBudgetSubCat AND tblMIS_BudgetHrs_Field_Category.Id = tblACC_Budget_WO_Time.HrsBudgetCat INNER JOIN tblDG_Item_Master ON tblACC_Budget_WO_Time.EquipId = tblDG_Item_Master.Id AND tblACC_Budget_WO_Time.WONo='", wono, "' AND tblACC_Budget_WO_Time.HrsBudgetCat='", sqlDataReader["HrsBudgetCat"], "' AND tblACC_Budget_WO_Time.HrsBudgetSubCat='", sqlDataReader["HrsBudgetSubCat"], "' AND tblACC_Budget_WO_Time.EquipId='", sqlDataReader["EquipId"], "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = sqlDataReader2["ItemCode"];
				dataRow[1] = sqlDataReader2["ManfDesc"];
				dataRow[2] = sqlDataReader2["Category"];
				dataRow[3] = sqlDataReader2["SubCategory"];
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				num = Math.Round(Convert.ToDouble(CUH.AllocatedHrs_WONo(CompId, wono, Convert.ToInt32(sqlDataReader["EquipId"]), Convert.ToInt32(sqlDataReader2["Cid"]), Convert.ToInt32(sqlDataReader2["SCid"]))), 2);
				num2 = Math.Round(Convert.ToDouble(CUH.UtilizeHrs_WONo(CompId, wono, Convert.ToInt32(sqlDataReader["EquipId"]), Convert.ToInt32(sqlDataReader2["Cid"]), Convert.ToInt32(sqlDataReader2["SCid"]))), 2);
				num3 = Math.Round(num - num2, 2);
				dataRow[4] = num.ToString();
				dataRow[5] = num2.ToString();
				dataRow[6] = num3.ToString();
				dataRow[7] = sqlDataReader["EquipId"];
				dataRow[8] = sqlDataReader["HrsBudgetCat"];
				dataRow[9] = sqlDataReader["HrsBudgetSubCat"];
				dataRow[10] = Math.Round(num2 * 100.0 / num, 2);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
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
		base.Response.Redirect("Budget_Dist_WONo_Time.aspx?ModId=14");
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
					double num = 0.0;
					num = Convert.ToDouble(((TextBox)row.FindControl("TxtHour")).Text);
					if (num > 0.0)
					{
						string cmdText = fun.insert("tblACC_Budget_WO_Time", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,EquipId,HrsBudgetCat,HrsBudgetSubCat,Hour", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + ((Label)row.FindControl("lblEquipId")).Text + "','" + ((Label)row.FindControl("lblCatId")).Text + "','" + ((Label)row.FindControl("lblSubCatId")).Text + "','" + num + "'");
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

	protected void drpCat_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpCat.SelectedValue != "1")
			{
				new SqlCommand();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HrsBudgetSubCategory", con);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CatId", SqlDbType.Int));
				sqlDataAdapter.SelectCommand.Parameters["@CatId"].Value = drpCat.SelectedValue;
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				drpSubCat.DataSource = dataSet;
				drpSubCat.DataTextField = "SubCategory";
				drpSubCat.DataValueField = "Id";
				drpSubCat.DataBind();
			}
			else
			{
				drpSubCat.Items.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string cmdText = fun.select("*", "tblACC_Budget_WO_Time", "EquipId='" + drpEqNo.SelectedValue + "' AND WONo='" + wono + "' AND HrsBudgetCat='" + drpCat.SelectedValue + "' AND HrsBudgetSubCat='" + drpSubCat.SelectedValue + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (!sqlDataReader.HasRows)
			{
				string cmdText2 = "Insert into tblACC_Budget_WO_Time (SysDate,SysTime,CompId,FinYearId,SessionId,WONo,EquipId,HrsBudgetCat,HrsBudgetSubCat,Hour) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + Convert.ToInt32(drpEqNo.SelectedValue) + "','" + Convert.ToInt32(drpCat.SelectedValue) + "','" + Convert.ToInt32(drpSubCat.SelectedValue) + "','" + Convert.ToDouble(txtHrs.Text) + "')";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "Budget Hrs is already allocated for selected Category & Sub-Category.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void drpEqNo_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (drpEqNo.SelectedValue != "Select")
		{
			FillCatDrp();
		}
		else
		{
			drpCat.Items.Clear();
		}
	}

	public void FillCatDrp()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HrsBudgetCategory", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			drpCat.DataSource = dataSet;
			drpCat.DataTextField = "Category";
			drpCat.DataValueField = "Id";
			drpCat.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void FillEquDrp(string wonosrc, string CompId)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HrsBudgetBOMEquipment", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			drpEqNo.DataSource = dataSet;
			drpEqNo.DataTextField = "EqDesc";
			drpEqNo.DataValueField = "ItemId";
			drpEqNo.DataBind();
			drpEqNo.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}
}

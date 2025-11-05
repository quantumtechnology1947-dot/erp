using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Delete : Page, IRequiresSessionState
{
	protected DropDownList ddlSelectBG_WONo;

	protected TextBox TxtWONo;

	protected DropDownList DrpCategory;

	protected DropDownList DrpMonths;

	protected DropDownList Drptype;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button BtnSearch;

	protected SqlDataSource SqlBGGroup;

	protected GridView GridView2;

	protected Panel Panel1;

	protected GridView GridView3;

	protected Panel Panel2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string bgid = "0";

	private string EmpId = "";

	private string m = "0";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			con.Open();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			getDetailGrid(text);
			ViewState["Id"] = text;
			con.Close();
		}
	}

	public void getDetailGrid(string id)
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("EquipNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Cate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Planned", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Actual", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Hrs", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MId", typeof(int)));
			string cmdText = "SELECT  tblPM_ManPowerPlanning_Details.EquipId,tblPM_ManPowerPlanning_Details.PlannedDesc,tblPM_ManPowerPlanning_Details.ActualDesc,tblPM_ManPowerPlanning_Details.Hour,tblPM_ManPowerPlanning_Details.Id,tblPM_ManPowerPlanning_Details.MId,tblMIS_BudgetHrs_Field_Category.Category, tblMIS_BudgetHrs_Field_SubCategory.SubCategory FROM  tblPM_ManPowerPlanning_Details INNER JOIN tblMIS_BudgetHrs_Field_Category ON tblPM_ManPowerPlanning_Details.Category = tblMIS_BudgetHrs_Field_Category.Id INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblPM_ManPowerPlanning_Details.SubCategory = tblMIS_BudgetHrs_Field_SubCategory.Id AND tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId AND tblPM_ManPowerPlanning_Details.MId='" + id + "'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", sqlDataReader["EquipId"], "'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = sqlDataReader2["ItemCode"].ToString();
				dataRow[1] = sqlDataReader2["ManfDesc"].ToString();
				dataRow[2] = sqlDataReader["Category"].ToString();
				dataRow[3] = sqlDataReader["SubCategory"].ToString();
				dataRow[4] = sqlDataReader["PlannedDesc"].ToString();
				dataRow[5] = sqlDataReader["ActualDesc"].ToString();
				dataRow[6] = Convert.ToDouble(sqlDataReader["Hour"]);
				dataRow[7] = Convert.ToInt32(sqlDataReader["Id"]);
				dataRow[8] = Convert.ToInt32(sqlDataReader["MId"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			Txtfromdate.Attributes.Add("readonly", "readonly");
			TxtTodate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Financial");
				List<string> list = new List<string>();
				list = fun.MonthRange(dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString(), dataSet.Tables[0].Rows[0]["FinYearTo"].ToString());
				int num = 4;
				DrpMonths.Items.Clear();
				DrpMonths.Items.Add(new ListItem("Select", "0"));
				for (int i = 0; i <= 8; i++)
				{
					DrpMonths.Items.Add(new ListItem(list[i], num.ToString()));
					num++;
				}
				DrpMonths.Items.Add(new ListItem("January", "1"));
				DrpMonths.Items.Add(new ListItem("February", "2"));
				DrpMonths.Items.Add(new ListItem("March", "3"));
			}
		}
		catch (Exception)
		{
		}
	}

	public void getMasterGrid()
	{
		try
		{
			string text = "";
			if (TxtEmpName.Text != "")
			{
				text = " AND tblPM_ManPowerPlanning.EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			string text2 = "";
			int num = 0;
			if (DrpMonths.SelectedValue != "0")
			{
				text2 = " AND tblPM_ManPowerPlanning.Date Like '%-" + Convert.ToInt32(DrpMonths.SelectedValue).ToString("D2") + "-%'";
			}
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (ddlSelectBG_WONo.SelectedValue == "1" && DrpCategory.SelectedValue != "1")
			{
				text3 = " AND tblHR_OfficeStaff.BGGroup='" + DrpCategory.SelectedValue + "'";
			}
			if (ddlSelectBG_WONo.SelectedValue == "2" && TxtWONo.Text != "")
			{
				text4 = " AND tblPM_ManPowerPlanning.WONo='" + TxtWONo.Text + "'";
			}
			string text5 = "";
			if (Drptype.SelectedValue != "0")
			{
				text5 = " AND tblPM_ManPowerPlanning.Types='" + Drptype.SelectedValue + "'";
			}
			string text6 = "";
			if (Txtfromdate.Text != "" && TxtTodate.Text != "")
			{
				text6 = "  And tblPM_ManPowerPlanning.Date between  '" + fun.FromDate(Txtfromdate.Text) + "' And '" + fun.FromDate(TxtTodate.Text) + "' ";
			}
			if ((ddlSelectBG_WONo.SelectedValue == "1" && DrpCategory.SelectedValue == "1") || (ddlSelectBG_WONo.SelectedValue == "2" && TxtWONo.Text == ""))
			{
				string text7 = " BG.";
				if (ddlSelectBG_WONo.SelectedValue == "2")
				{
					text7 = " WONo.";
				}
				string empty = string.Empty;
				empty = "Please Select" + text7;
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				return;
			}
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Types", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			string cmdText = fun.select("*", "tblPM_ManPowerPlanning", " CompId='" + CompId + "'" + text + text4 + text2 + text5 + text6 + " Order by Date ASC");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = "SELECT OfferId,Title+'. '+EmployeeName As EmpName, tblHR_Designation.Symbol FROM tblHR_OfficeStaff INNER JOIN tblHR_Designation ON tblHR_OfficeStaff.Designation = tblHR_Designation.Id AND tblHR_OfficeStaff.EmpId='" + sqlDataReader["EmpId"].ToString() + "'" + text3;
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = sqlDataReader2["EmpName"].ToString();
				dataRow[1] = sqlDataReader["EmpId"].ToString();
				dataRow[2] = sqlDataReader2["Symbol"].ToString();
				dataRow[3] = fun.FromDateDMY(sqlDataReader["Date"].ToString());
				string text8 = "";
				text8 = ((sqlDataReader["WONo"] == DBNull.Value || !(sqlDataReader["WONo"].ToString() != "")) ? "NA" : sqlDataReader["WONo"].ToString());
				dataRow[4] = text8;
				string cmdText3 = fun.select("Symbol", "BusinessGroup", string.Concat("Id='", sqlDataReader["Dept"], "'"));
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				string text9 = "";
				text9 = ((!sqlDataReader3.HasRows) ? "NA" : sqlDataReader3["Symbol"].ToString());
				dataRow[5] = text9;
				switch (Convert.ToInt32(sqlDataReader["Types"]))
				{
				case 1:
					dataRow[6] = "Present";
					break;
				case 2:
					dataRow[6] = "Absent";
					break;
				case 3:
					dataRow[6] = "Onsite";
					break;
				case 4:
					dataRow[6] = "PL";
					break;
				}
				dataRow[7] = Convert.ToInt32(sqlDataReader["Id"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		con.Open();
		getMasterGrid();
		con.Close();
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void ddlSelectBG_WONo_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlSelectBG_WONo.SelectedValue == "0")
		{
			DrpCategory.Visible = false;
			TxtWONo.Visible = false;
			TxtWONo.Text = string.Empty;
			DrpCategory.SelectedValue = "1";
		}
		if (ddlSelectBG_WONo.SelectedValue == "1")
		{
			DrpCategory.Visible = true;
			TxtWONo.Visible = false;
			TxtWONo.Text = string.Empty;
		}
		if (ddlSelectBG_WONo.SelectedValue == "2")
		{
			TxtWONo.Visible = true;
			DrpCategory.Visible = false;
			DrpCategory.SelectedValue = "1";
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblMId")).Text;
				string cmdText = fun.delete("tblPM_ManPowerPlanning_Details", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("*", "tblPM_ManPowerPlanning_Details", "MId='" + text2 + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					string cmdText3 = fun.delete("tblPM_ManPowerPlanning", "Id='" + text2 + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					sqlCommand3.ExecuteNonQuery();
				}
				if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
				{
					getDetailGrid(ViewState["Id"].ToString());
					getMasterGrid();
				}
				con.Close();
			}
		}
		catch (Exception)
		{
		}
	}
}

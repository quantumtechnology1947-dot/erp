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

public class Module_ProjectManagement_Transactions_ManPowerPlanning_Edit : Page, IRequiresSessionState
{
	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string bgid = "0";

	private string EmpId = "";

	private string m = "0";

	public static string Id = "0";

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

	protected Button btnUpdate;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

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
				getMasterGrid();
				Id = "0";
				getDetailGrid(Id);
				GetValidate();
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

	public void getDetailGrid(string id)
	{
		try
		{
			con.Open();
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
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EquipId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Cat", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SubCat", typeof(int)));
			string cmdText = "SELECT  tblPM_ManPowerPlanning_Details.EquipId,tblPM_ManPowerPlanning_Details.Category As CatId,tblPM_ManPowerPlanning_Details.SubCategory As SubCatId,tblPM_ManPowerPlanning_Details.PlannedDesc,tblPM_ManPowerPlanning_Details.ActualDesc,tblPM_ManPowerPlanning_Details.Hour,tblPM_ManPowerPlanning_Details.Id,tblPM_ManPowerPlanning_Details.MId,tblMIS_BudgetHrs_Field_Category.Category, tblMIS_BudgetHrs_Field_SubCategory.SubCategory FROM  tblPM_ManPowerPlanning_Details INNER JOIN tblMIS_BudgetHrs_Field_Category ON tblPM_ManPowerPlanning_Details.Category = tblMIS_BudgetHrs_Field_Category.Id INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblPM_ManPowerPlanning_Details.SubCategory = tblMIS_BudgetHrs_Field_SubCategory.Id AND tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId AND tblPM_ManPowerPlanning_Details.MId='" + id + "'";
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
				string cmdText3 = fun.select("WONo", "tblPM_ManPowerPlanning", string.Concat("Id='", sqlDataReader["MId"], "'"));
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				dataRow[9] = sqlDataReader3["WONo"].ToString();
				dataRow[10] = Convert.ToInt32(sqlDataReader["EquipId"]);
				dataRow[11] = Convert.ToInt32(sqlDataReader["CatId"]);
				dataRow[12] = Convert.ToInt32(sqlDataReader["SubCatId"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			getDetailGrid(text);
			ViewState["Id"] = text;
			Id = ViewState["Id"].ToString();
			GetValidate();
			btnUpdate.Visible = true;
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		con.Open();
		getMasterGrid();
		con.Close();
		getDetailGrid("0");
		btnUpdate.Visible = false;
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

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("ck")).Checked)
			{
				((TextBox)gridViewRow.FindControl("TxtPlanned")).Visible = true;
				((Label)gridViewRow.FindControl("lblPlanned")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqPlanned")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtActual")).Visible = true;
				((Label)gridViewRow.FindControl("lblActual")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqActual")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtHrs")).Visible = true;
				((Label)gridViewRow.FindControl("lblHrs")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqHrs")).Visible = true;
				((RegularExpressionValidator)gridViewRow.FindControl("RegHrs")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtPlanned")).Text = ((Label)gridViewRow.FindControl("lblPlanned")).Text;
				((TextBox)gridViewRow.FindControl("TxtActual")).Text = ((Label)gridViewRow.FindControl("lblActual")).Text;
				((TextBox)gridViewRow.FindControl("TxtHrs")).Text = ((Label)gridViewRow.FindControl("lblHrs")).Text;
			}
			else if (!((CheckBox)gridViewRow.FindControl("ck")).Checked)
			{
				((TextBox)gridViewRow.FindControl("TxtPlanned")).Visible = false;
				((Label)gridViewRow.FindControl("lblPlanned")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqPlanned")).Visible = false;
				((TextBox)gridViewRow.FindControl("TxtActual")).Visible = false;
				((Label)gridViewRow.FindControl("lblActual")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqActual")).Visible = false;
				((Label)gridViewRow.FindControl("lblHrs")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtHrs")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqHrs")).Visible = false;
				((RegularExpressionValidator)gridViewRow.FindControl("RegHrs")).Visible = false;
				((TextBox)gridViewRow.FindControl("TxtPlanned")).Text = string.Empty;
				((TextBox)gridViewRow.FindControl("TxtActual")).Text = string.Empty;
				((TextBox)gridViewRow.FindControl("TxtHrs")).Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView3.Rows)
		{
			if (((CheckBox)row.FindControl("ck")).Checked)
			{
				((TextBox)row.FindControl("TxtPlanned")).Visible = true;
				((Label)row.FindControl("lblPlanned")).Visible = false;
				((RequiredFieldValidator)row.FindControl("ReqPlanned")).Visible = true;
				((TextBox)row.FindControl("TxtActual")).Visible = true;
				((Label)row.FindControl("lblActual")).Visible = false;
				((RequiredFieldValidator)row.FindControl("ReqActual")).Visible = true;
				((TextBox)row.FindControl("TxtHrs")).Visible = true;
				((Label)row.FindControl("lblHrs")).Visible = false;
				((RequiredFieldValidator)row.FindControl("ReqHrs")).Visible = true;
				((RegularExpressionValidator)row.FindControl("RegHrs")).Visible = true;
			}
			else
			{
				((TextBox)row.FindControl("TxtPlanned")).Visible = false;
				((Label)row.FindControl("lblPlanned")).Visible = true;
				((RequiredFieldValidator)row.FindControl("ReqPlanned")).Visible = false;
				((TextBox)row.FindControl("TxtActual")).Visible = false;
				((Label)row.FindControl("lblActual")).Visible = true;
				((RequiredFieldValidator)row.FindControl("ReqActual")).Visible = false;
				((Label)row.FindControl("lblHrs")).Visible = true;
				((TextBox)row.FindControl("TxtHrs")).Visible = false;
				((RequiredFieldValidator)row.FindControl("ReqHrs")).Visible = false;
				((RegularExpressionValidator)row.FindControl("RegHrs")).Visible = false;
			}
		}
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			double num = 0.0;
			string empty = string.Empty;
			string empty2 = string.Empty;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			double num5 = 0.0;
			_ = string.Empty;
			_ = string.Empty;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			con.Open();
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				num7++;
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("TxtPlanned")).Text != "" && ((TextBox)row.FindControl("TxtActual")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("TxtHrs")).Text) && ((TextBox)row.FindControl("TxtHrs")).Text != "")
				{
					num5 = Convert.ToDouble(((TextBox)row.FindControl("TxtHrs")).Text);
					_ = ((TextBox)row.FindControl("TxtActual")).Text;
					_ = ((TextBox)row.FindControl("TxtPlanned")).Text;
					if (num5 > 0.0 && num5 <= Convert.ToDouble(((Label)row.FindControl("lblHrs")).Text))
					{
						num6++;
					}
				}
			}
			if (num7 == num6 && num6 > 0)
			{
				int num9 = 1;
				foreach (GridViewRow row2 in GridView3.Rows)
				{
					if (!((CheckBox)row2.FindControl("ck")).Checked || !(((TextBox)row2.FindControl("TxtPlanned")).Text != "") || !(((TextBox)row2.FindControl("TxtActual")).Text != "") || !fun.NumberValidationQty(((TextBox)row2.FindControl("TxtHrs")).Text) || !(((TextBox)row2.FindControl("TxtHrs")).Text != "") || Convert.ToInt32(((Label)row2.FindControl("lblMId")).Text) == 0)
					{
						continue;
					}
					num = Convert.ToDouble(((TextBox)row2.FindControl("TxtHrs")).Text);
					empty = ((TextBox)row2.FindControl("TxtActual")).Text;
					empty2 = ((TextBox)row2.FindControl("TxtPlanned")).Text;
					num2 = Convert.ToInt32(((Label)row2.FindControl("lblMId")).Text);
					num3 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					if (!(num > 0.0) || !(num <= Convert.ToDouble(((Label)row2.FindControl("lblHrs")).Text)))
					{
						continue;
					}
					if (num9 == 1)
					{
						string cmdText = fun.select("Id ,SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,Date,WONo,Dept,Types,AmendmentNo", "tblPM_ManPowerPlanning", "Id='" + num2 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							string cmdText2 = fun.insert("tblPM_ManPowerPlanning_Amd", "MId,SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,Date,WONo,Dept,Types,AmendmentNo", "'" + num2 + "','" + sqlDataReader["SysDate"].ToString() + "','" + sqlDataReader["SysTime"].ToString() + "','" + sqlDataReader["SessionId"].ToString() + "','" + sqlDataReader["CompId"].ToString() + "','" + sqlDataReader["FinYearId"].ToString() + "','" + sqlDataReader["EmpId"].ToString() + "','" + sqlDataReader["Date"].ToString() + "','" + sqlDataReader["WONo"].ToString() + "','" + sqlDataReader["Dept"].ToString() + "','" + Convert.ToInt32(sqlDataReader["Types"]) + "','" + Convert.ToInt32(sqlDataReader["AmendmentNo"]) + "'");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
							sqlCommand2.ExecuteNonQuery();
							num9 = 0;
							string cmdText3 = fun.select("Id", "tblPM_ManPowerPlanning_Amd", "CompId='" + CompId + "' Order by Id desc");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
							SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
							while (sqlDataReader2.Read())
							{
								if (sqlDataReader2.HasRows)
								{
									num4 = Convert.ToInt32(sqlDataReader2["Id"].ToString());
								}
							}
							int num10 = 0;
							num10 = ((Convert.ToInt32(sqlDataReader["AmendmentNo"]) <= 0) ? 1 : (Convert.ToInt32(sqlDataReader["AmendmentNo"].ToString()) + 1));
							string cmdText4 = fun.update("tblPM_ManPowerPlanning", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',AmendmentNo='" + num10 + "'", " Id='" + num2 + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
							sqlCommand4.ExecuteNonQuery();
						}
					}
					string cmdText5 = fun.select("Id,MId,EquipId,Category,SubCategory ,PlannedDesc ,ActualDesc ,Hour", "tblPM_ManPowerPlanning_Details", "Id='" + num3 + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
					SqlDataReader sqlDataReader3 = sqlCommand5.ExecuteReader();
					while (sqlDataReader3.Read())
					{
						string cmdText6 = fun.insert("tblPM_ManPowerPlanning_Details_Amd", "MId,DMId,EquipId,Category,SubCategory ,PlannedDesc ,ActualDesc ,Hour", "'" + num4 + "','" + sqlDataReader3["Id"].ToString() + "','" + sqlDataReader3["EquipId"].ToString() + "','" + sqlDataReader3["Category"].ToString() + "','" + sqlDataReader3["SubCategory"].ToString() + "','" + sqlDataReader3["PlannedDesc"].ToString() + "','" + sqlDataReader3["ActualDesc"].ToString() + "','" + Convert.ToDouble(sqlDataReader3["Hour"].ToString()) + "'");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
						sqlCommand6.ExecuteNonQuery();
					}
					string cmdText7 = fun.update("tblPM_ManPowerPlanning_Details", "PlannedDesc='" + empty2 + "' ,ActualDesc='" + empty + "',Hour='" + num + "'", "Id='" + num3 + "'");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
					sqlCommand7.ExecuteNonQuery();
					num8++;
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Invalid data input .";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty3 + "');", addScriptTags: true);
			}
			con.Close();
			if (num8 <= 0)
			{
				return;
			}
			getDetailGrid(num2.ToString());
			foreach (GridViewRow row3 in GridView3.Rows)
			{
				((CheckBox)row3.FindControl("ck")).Checked = false;
			}
			GetValidate();
		}
		catch (Exception)
		{
		}
	}
}

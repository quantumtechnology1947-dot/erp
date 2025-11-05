using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_ManPowerPlanning : Page, IRequiresSessionState
{
	protected Label Label2;

	protected DropDownList DrpCategory;

	protected RequiredFieldValidator ReqBGgroup;

	protected GridView GridView1;

	protected SqlDataSource SqlBGGroup;

	protected Panel Panel1;

	protected TabPanel Planning;

	protected Label Label3;

	protected Label lblEmpName;

	protected Label lblEmpId;

	protected Label Label4;

	protected Label lblDesig;

	protected Label lbldrp;

	protected Label lblWODept;

	protected Label lblWODeptId;

	protected Label lblBGId;

	protected Label Label5;

	protected Label lblDOB;

	protected Label Label7;

	protected Label lblStatus;

	protected Label lblStatusId;

	protected GridView GridView3;

	protected Panel Panel3;

	protected Button btnSelect;

	protected SqlDataSource SqlCategory;

	protected TabPanel TabPanel1;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string bgid = "0";

	private Cal_Used_Hours CUH = new Cal_Used_Hours();

	private string empid = string.Empty;

	private string dt = string.Empty;

	private string drpwonodept = string.Empty;

	private string Drptype = string.Empty;

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
			if (!base.IsPostBack)
			{
				LoadData(bgid);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData(string BGId)
	{
		try
		{
			string selectedValue = DrpCategory.SelectedValue;
			string text = "";
			if (DrpCategory.SelectedValue != "1")
			{
				text = " AND tblHR_OfficeStaff.BGGroup='" + selectedValue + "'";
			}
			string cmdText = fun.select("tblHR_OfficeStaff.EmpId As Id,tblHR_OfficeStaff.EmployeeName,tblHR_Designation.Type AS Designation", "tblHR_OfficeStaff,tblHR_Designation", " tblHR_Designation.Id=tblHR_OfficeStaff.Designation And tblHR_OfficeStaff.CompId='" + CompId + "' AND tblHR_OfficeStaff.ResignationDate=''" + text);
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			SqlDataReader dataSource = sqlCommand.ExecuteReader();
			GridView1.DataSource = dataSource;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				((TextBox)row.FindControl("TxtDate")).Attributes.Add("readonly", "readonly");
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData(DrpCategory.SelectedValue);
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (!(e.CommandName == "add"))
		{
			return;
		}
		con.Open();
		GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
		empid = ((Label)gridViewRow.FindControl("lblId")).Text;
		lblEmpId.Text = empid;
		dt = ((TextBox)gridViewRow.FindControl("TxtDate")).Text;
		drpwonodept = ((DropDownList)gridViewRow.FindControl("Drpwodept")).SelectedValue;
		lblWODeptId.Text = drpwonodept;
		Drptype = ((DropDownList)gridViewRow.FindControl("Drptype")).SelectedItem.Text;
		lblStatusId.Text = ((DropDownList)gridViewRow.FindControl("Drptype")).SelectedValue;
		if (dt != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("TxtDate")).Text))
		{
			string cmdText = fun.select("EmployeeName,Designation", "tblHR_OfficeStaff", "EmpId='" + empid + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			string cmdText2 = fun.select("Type", "tblHR_Designation", string.Concat("Id='", sqlDataReader["Designation"], "'"));
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			sqlDataReader2.Read();
			string text = string.Empty;
			string empty = string.Empty;
			int num = 1;
			if (drpwonodept == "1")
			{
				empty = "WO No";
				if (((TextBox)gridViewRow.FindControl("TxtWONo")).Text != "")
				{
					text = ((TextBox)gridViewRow.FindControl("TxtWONo")).Text;
					num = 1;
				}
				else
				{
					num = 0;
					string empty2 = string.Empty;
					empty2 = "Enter valid data to proceed.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				num = 1;
				empty = "BG";
				string cmdText3 = fun.select("Symbol", "BusinessGroup", "Id='" + ((DropDownList)gridViewRow.FindControl("DrpDepartment")).SelectedValue + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				lblBGId.Text = ((DropDownList)gridViewRow.FindControl("DrpDepartment")).SelectedValue;
				text = sqlDataReader3["Symbol"].ToString();
			}
			if (num == 1)
			{
				lbldrp.Text = empty;
				lblEmpName.Text = sqlDataReader["EmployeeName"].ToString();
				lblDesig.Text = sqlDataReader2["Type"].ToString();
				lblDOB.Text = dt;
				lblWODept.Text = text;
				lblStatus.Text = Drptype;
				FillEquDrp(text, CompId.ToString());
				TabContainer1.ActiveTabIndex = 1;
			}
		}
		else
		{
			string empty3 = string.Empty;
			empty3 = "Enter valid data to proceed.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
		}
		con.Close();
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		LoadData(DrpCategory.SelectedValue);
	}

	protected void Drpwodept_SelectedIndexChanged(object sender, EventArgs e)
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((DropDownList)row.FindControl("Drpwodept")).SelectedValue == "2")
			{
				((DropDownList)row.FindControl("DrpDepartment")).Visible = true;
				((TextBox)row.FindControl("TxtWONo")).Visible = false;
			}
			else
			{
				((DropDownList)row.FindControl("DrpDepartment")).Visible = false;
				((TextBox)row.FindControl("TxtWONo")).Visible = true;
			}
		}
	}

	public void FillEquDrp(string wonosrc, string CompId)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HrsBudgetBOMEquipNo", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView3.DataSource = dataSet;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void drpCat_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)sender;
			GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;
			if (((DropDownList)gridViewRow.FindControl("drpCat")).SelectedValue != "1")
			{
				new SqlCommand();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HrsBudgetSubCategory", con);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CatId", SqlDbType.Int));
				sqlDataAdapter.SelectCommand.Parameters["@CatId"].Value = ((DropDownList)gridViewRow.FindControl("drpCat")).SelectedValue;
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				((DropDownList)gridViewRow.FindControl("drpSubCat")).DataSource = dataSet;
				((DropDownList)gridViewRow.FindControl("drpSubCat")).DataTextField = "SubCategory";
				((DropDownList)gridViewRow.FindControl("drpSubCat")).DataValueField = "Id";
				((DropDownList)gridViewRow.FindControl("drpSubCat")).DataBind();
			}
			else
			{
				((DropDownList)gridViewRow.FindControl("drpSubCat")).Items.Clear();
			}
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("ChkSelect")).Checked)
			{
				((DropDownList)gridViewRow.FindControl("drpCat")).Enabled = true;
				((DropDownList)gridViewRow.FindControl("drpSubCat")).Enabled = true;
				return;
			}
			((DropDownList)gridViewRow.FindControl("drpSubCat")).Items.Clear();
			((DropDownList)gridViewRow.FindControl("drpCat")).SelectedIndex = 0;
			((DropDownList)gridViewRow.FindControl("drpCat")).Enabled = false;
			((DropDownList)gridViewRow.FindControl("drpSubCat")).Enabled = false;
		}
		catch (Exception)
		{
		}
	}

	protected void btnSelect_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = lblWODept.Text;
			string text2 = lblBGId.Text;
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (!((CheckBox)row.FindControl("ChkSelect")).Checked)
				{
					continue;
				}
				if (((DropDownList)row.FindControl("drpCat")).SelectedValue != "1")
				{
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					num3 = Convert.ToDouble(CUH.AllocatedHrs_WONo(CompId, text, Convert.ToInt32(((Label)row.FindControl("lblEquipId")).Text), Convert.ToInt32(((DropDownList)row.FindControl("drpCat")).SelectedValue), Convert.ToInt32(((DropDownList)row.FindControl("drpSubCat")).SelectedValue)));
					num4 = Convert.ToDouble(CUH.UtilizeHrs_WONo(CompId, text, Convert.ToInt32(((Label)row.FindControl("lblEquipId")).Text), Convert.ToInt32(((DropDownList)row.FindControl("drpCat")).SelectedValue), Convert.ToInt32(((DropDownList)row.FindControl("drpSubCat")).SelectedValue)));
					num5 = Math.Round(num3 - num4, 2);
					if (num5 > 0.0 && num5 >= Convert.ToDouble(((TextBox)row.FindControl("txtHrs")).Text))
					{
						num2++;
					}
					else
					{
						num++;
					}
				}
				else
				{
					num++;
				}
			}
			if (num2 > 0)
			{
				string cmdText = fun.insert("tblPM_ManPowerPlanning", "SysDate,SysTime,FinYearId,SessionId,CompId,EmpId, Date,WONo,Dept,Types", "'" + currDate + "','" + currTime + "','" + FinYearId + "','" + SId + "','" + CompId + "','" + lblEmpId.Text + "','" + fun.FromDate(lblDOB.Text) + "','" + text + "','" + text2 + "','" + lblStatusId.Text + "'");
				con.Open();
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText2 = fun.select1("Id", "tblPM_ManPowerPlanning Order by Id DESC");
				con.Open();
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				sqlDataReader.Read();
				foreach (GridViewRow row2 in GridView3.Rows)
				{
					if (((CheckBox)row2.FindControl("ChkSelect")).Checked && ((DropDownList)row2.FindControl("drpCat")).SelectedValue != "1" && !string.IsNullOrEmpty(((TextBox)row2.FindControl("txtHrs")).Text) && fun.NumberValidation(((TextBox)row2.FindControl("txtHrs")).Text))
					{
						string cmdText3 = fun.insert("tblPM_ManPowerPlanning_Details", "MId,EquipId,Category,SubCategory,PlannedDesc,ActualDesc,Hour", "'" + Convert.ToInt32(sqlDataReader["Id"]) + "','" + ((Label)row2.FindControl("lblEquipId")).Text + "','" + ((DropDownList)row2.FindControl("drpCat")).SelectedValue + "','" + ((DropDownList)row2.FindControl("drpSubCat")).SelectedValue + "','" + ((TextBox)row2.FindControl("txtPlanned")).Text + "','" + ((TextBox)row2.FindControl("txtActual")).Text + "','" + ((TextBox)row2.FindControl("txtHrs")).Text + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
						sqlCommand3.ExecuteNonQuery();
					}
				}
				con.Close();
			}
			if (num > 0)
			{
				string empty = string.Empty;
				empty = "Enter valid data to proceed or check assigned/balance Hrs budget.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			else
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

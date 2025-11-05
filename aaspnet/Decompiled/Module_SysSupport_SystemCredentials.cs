using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;

public class Module_SysSupport_SystemCredentials : Page, IRequiresSessionState
{
	protected TextBox txtName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label Label4;

	protected Label lblempId;

	protected Label lblDate;

	protected Label lbl_Date;

	protected Label sysUserName;

	protected Label txtSysName;

	protected Label SysPass;

	protected TextBox txtSysPassword;

	protected RequiredFieldValidator ReqSysPass;

	protected Label erpUserName;

	protected Label txterpName;

	protected Label erpPass;

	protected Label txterpPassword;

	protected Label erpUserName0;

	protected TextBox txtemailName;

	protected RequiredFieldValidator ReqemailName;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Label erpPass0;

	protected Label txtemailPassword;

	protected Button btn_Save;

	protected Panel Panel1;

	protected TabPanel TabPanel1;

	protected TextBox txtName1;

	protected AutoCompleteExtender TxtEmpName1_AutoCompleteExtender;

	protected Button btnSearch1;

	protected Button btnExport;

	protected GridView GridView2;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected TabPanel TabPanel2;

	protected HtmlGenericControl Iframe1;

	protected Button BtnCancel1;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			lblMessage.Text = "";
			TabPanel3.Visible = false;
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtName.Text);
			SqlDataSource1.FilterParameters[0].DefaultValue = code;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			if (e.CommandName == "sel")
			{
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblUID")).Text);
				ViewState["MId"] = num;
				string text = gridViewRow.Cells[3].Text;
				string text2 = ((LinkButton)gridViewRow.FindControl("lnkId")).Text;
				string text3 = gridViewRow.Cells[4].Text;
				lblempId.Text = text + ' ' + '[' + text2 + ']';
				lbl_Date.Text = fun.FromDateDMY(CDate);
				txterpName.Text = text2;
				txtSysName.Text = text2;
				txtemailName.Text = text3;
				txterpPassword.Text = clsFunctions.GetRandomAlphanumericString(9);
				txtemailPassword.Text = txterpPassword.Text;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btn_Save_Click(object sender, EventArgs e)
	{
		try
		{
			if (lblempId.Text != "" && !string.IsNullOrEmpty(lblempId.Text))
			{
				string cmdText = fun.insert("tblSystemCredentials", "MId, SysDate,SysTime,SessionId,CompId,FinYearId,SysPwd,ERPPwd,EmailId,EmailPwd", "'" + Convert.ToInt32(ViewState["MId"].ToString()) + "','" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + txtSysPassword.Text + "','" + txterpPassword.Text + "','" + txtemailName.Text + "','" + txtemailPassword.Text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				string cmdText2 = fun.update("tblHR_OfficeStaff", "CompanyEmail='" + txtemailName.Text + "'", "UserId='" + Convert.ToInt32(ViewState["MId"].ToString()) + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "Please Select EmpId.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated.";
	}

	protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
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
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string selectCommandText = fun.select("MId", "tblSystemCredentials", "Id='" + num + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
			string text = ((TextBox)gridViewRow.FindControl("lblSysPwd0")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("lblERPPwd0")).Text;
			string text3 = ((TextBox)gridViewRow.FindControl("lblEmailId0")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("lblEmailPwd0")).Text;
			if (text != "" && text2 != "" && text3 != "" && text4 != "")
			{
				LocalSqlServer.UpdateParameters["SysPwd"].DefaultValue = text;
				LocalSqlServer.UpdateParameters["ERPPwd"].DefaultValue = text2;
				LocalSqlServer.UpdateParameters["EmailId"].DefaultValue = text3;
				LocalSqlServer.UpdateParameters["EmailPwd"].DefaultValue = text4;
				LocalSqlServer.Update();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText = fun.update("tblHR_OfficeStaff", "CompanyEmail='" + text3 + "'", "UserId='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["MId"].ToString()) + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch1_Click(object sender, EventArgs e)
	{
		string code = fun.getCode(txtName1.Text);
		LocalSqlServer.FilterParameters[0].DefaultValue = code;
	}

	protected void btnPrint_Click(object sender, EventArgs e)
	{
		try
		{
			DataView dataView = (DataView)LocalSqlServer.Select(DataSourceSelectArguments.Empty);
			DataTable dataTable = dataView.ToTable();
			dataTable.Columns["SysDate"].ColumnName = "Date";
			dataTable.Columns["Employee"].ColumnName = "Employee Name";
			dataTable.Columns["SysPwd"].ColumnName = "System Password";
			dataTable.Columns["ERPPwd"].ColumnName = "ERP Password";
			dataTable.Columns["EmailId"].ColumnName = "Email Id";
			dataTable.Columns["EmailPwd"].ColumnName = "Email Password";
			dataTable.Columns.Remove("Id");
			if (dataTable.Rows.Count == 0)
			{
				throw new Exception("No Records to Export");
			}
			DataView defaultView = dataTable.DefaultView;
			defaultView.Sort = "EmpId ASC ";
			dataTable = defaultView.ToTable();
			ExportToExcel exportToExcel = new ExportToExcel();
			exportToExcel.ExportDataToExcel(dataTable, "Staff_Details");
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
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

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		try
		{
			if (TabContainer1.ActiveTabIndex == 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				TabPanel3.Visible = false;
			}
			if (TabContainer1.ActiveTabIndex == 1)
			{
				TabPanel3.Visible = false;
			}
			if (TabContainer1.ActiveTabIndex == 2)
			{
				TabPanel1.Visible = true;
				TabPanel2.Visible = true;
				TabPanel3.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "print")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				TabPanel3.Visible = true;
				TabPanel1.Visible = true;
				TabPanel2.Visible = true;
				TabContainer1.ActiveTabIndex = 2;
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblID")).Text);
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				Iframe1.Attributes.Add("src", "SystemCredentialsPrint.aspx?Id=" + num + "&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel1_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 1;
		TabPanel3.Visible = false;
	}
}

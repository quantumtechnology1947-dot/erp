using System;
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

public class Module_HR_Transactions_Salary_Print : Page, IRequiresSessionState
{
	protected Label Label4;

	protected DropDownList ddlMonth;

	protected Label lblBGGroup;

	protected DropDownList ddlBGGroup;

	protected RadioButtonList RadioButtonList1;

	protected TextBox TxtEmpSearch;

	protected AutoCompleteExtender TxtEmpSearch_AutoCompleteExtender;

	protected Label Label2;

	protected TextBox txtChequeNo;

	protected Label Label3;

	protected TextBox txtDate;

	protected CalendarExtender txtDate_CalendarExtender;

	protected RegularExpressionValidator RegtxtDate;

	protected DropDownList ddlBankName;

	protected DropDownList ddlEmpOrDirect;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource1;

	protected Button btnProceed;

	protected GridView GridView2;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private int MonthId = 4;

	private string connStr = string.Empty;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			txtDate.Attributes.Add("readonly", "readonly");
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!string.IsNullOrEmpty(base.Request.QueryString["MonthId"]))
			{
				MonthId = Convert.ToInt32(base.Request.QueryString["MonthId"]);
			}
			if (!base.IsPostBack)
			{
				ddlMonth.Items.Clear();
				fun.GetMonth(ddlMonth, CompId, FinYearId);
				ddlMonth.SelectedValue = MonthId.ToString();
			}
			if (RadioButtonList1.SelectedValue == "7" || RadioButtonList1.SelectedValue == "8")
			{
				ddlMonth.Visible = false;
			}
			else
			{
				ddlMonth.Visible = true;
			}
			loaddata();
		}
		catch (Exception)
		{
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
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' AND ResignationDate=''");
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string empty = string.Empty;
			empty = fun.getCode(TxtEmpSearch.Text);
			string empty2 = string.Empty;
			empty2 = ddlMonth.SelectedValue;
			string empty3 = string.Empty;
			string selectedValue = RadioButtonList1.SelectedValue;
			string empty4 = string.Empty;
			empty4 = ddlBGGroup.SelectedValue;
			switch (selectedValue)
			{
			case "0":
				if (empty != string.Empty && empty2 != string.Empty)
				{
					string selectCommandText = fun.select("BGGroup", "tblHR_OfficeStaff", "EmpId='" + empty + "'");
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
					if ((dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["BGGroup"].ToString() == empty4) || empty4 == "1")
					{
						string randomAlphaNumeric4 = fun.GetRandomAlphaNumeric();
						string cmdText = fun.select("Count(*) As Cnt", "tblHR_Salary_Details,tblHR_Salary_Master", "tblHR_Salary_Details.MId=tblHR_Salary_Master.Id AND tblHR_Salary_Master.CompId='" + CompId + "' AND tblHR_Salary_Master.FinYearId='" + FinYearId + "' AND tblHR_Salary_Master.EmpId='" + empty + "' AND tblHR_Salary_Master.FMonth='" + empty2 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						sqlDataReader.Read();
						if (sqlDataReader.HasRows)
						{
							if (Convert.ToDouble(sqlDataReader[0]) > 0.0)
							{
								base.Response.Redirect("Salary_Print_Details.aspx?EmpId=" + empty + "&MonthId=" + empty2 + "&Key=" + randomAlphaNumeric4 + "&BackURL=1&ModId=12&SubModId=133");
							}
							else
							{
								string empty6 = string.Empty;
								empty6 = "No Record Found!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty6 + "');", addScriptTags: true);
							}
						}
					}
					else
					{
						string empty7 = string.Empty;
						empty7 = "Invalid BG Group for this employee";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty7 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty8 = string.Empty;
					empty8 = "Invalid Employee Name.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty8 + "');", addScriptTags: true);
				}
				break;
			case "1":
				if (empty2 != "")
				{
					string randomAlphaNumeric6 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("Salary_Print_ALL.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric6 + "&ModId=12&SubModId=133");
				}
				break;
			case "2":
				if (empty2 != "")
				{
					empty3 = "2";
					string randomAlphaNumeric7 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("Salary_Neha.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric7 + "&ModId=12&SubModId=133");
				}
				break;
			case "3":
				if (empty2 != "")
				{
					string randomAlphaNumeric5 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("Salary_Neha_OverTimes.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric5 + "&ModId=12&SubModId=133");
				}
				break;
			case "4":
				if (empty2 != "")
				{
					string randomAlphaNumeric3 = fun.GetRandomAlphaNumeric();
					empty3 = "1";
					base.Response.Redirect("Salary_SAPL_Neha_Summary.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric3 + "&ModId=12&SubModId=133");
				}
				break;
			case "5":
				if (empty2 != "")
				{
					string randomAlphaNumeric8 = fun.GetRandomAlphaNumeric();
					empty3 = "2";
					base.Response.Redirect("Salary_SAPL_Neha_Summary.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric8 + "&ModId=12&SubModId=133");
				}
				break;
			case "6":
			{
				string text = txtChequeNo.Text;
				string text2 = txtDate.Text;
				string selectedValue2 = ddlBankName.SelectedValue;
				string selectedValue3 = ddlEmpOrDirect.SelectedValue;
				if (empty2 != string.Empty && text != string.Empty && text2 != string.Empty && fun.DateValidation(text2))
				{
					empty3 = "2";
					base.Response.Redirect("Salary_BankStatement_Check.aspx?ChequeNo=" + text + "&ChequeDate=" + text2 + "&BankId=" + selectedValue2 + "&EmpDirect=" + selectedValue3 + "&BGGroupId=" + empty4 + "&MonthId=" + empty2 + "&ModId=12&SubModId=133");
				}
				else
				{
					string empty5 = string.Empty;
					empty5 = "Invalid Cheque No. or Date.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
				}
				break;
			}
			case "7":
			{
				string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
				empty3 = "1";
				base.Response.Redirect("All_Month_Summary_Report.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric2 + "&ModId=12&SubModId=133");
				break;
			}
			case "8":
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				empty3 = "1";
				base.Response.Redirect("Consolidated_Summary_Report.aspx?EType=" + empty3 + "&MonthId=" + empty2 + "&BGGroupId=" + empty4 + "&Key=" + randomAlphaNumeric + "&ModId=12&SubModId=133");
				break;
			}
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

	public void loaddata()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeNoDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TransNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			string cmdText = fun.select("ChequeNo,ChequeNoDate,BankId,EmpDirect,TransNo", "tblHR_Salary_Master", "FMonth ='" + ddlMonth.SelectedValue + "' AND CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND ReleaseFlag='1' Group By ChequeNo,ChequeNoDate,BankId,EmpDirect,TransNo");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["ChequeNo"].ToString();
				dataRow[1] = fun.FromDate(dataSet.Tables[0].Rows[i]["ChequeNoDate"].ToString());
				string cmdText2 = fun.select("Name", "tblACC_Bank", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["BankId"]) + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblACC_Bank");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["Name"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["TransNo"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["BankId"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["EmpDirect"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
	{
		loaddata();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string selectedValue = ddlMonth.SelectedValue;
			string selectedValue2 = ddlBGGroup.SelectedValue;
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblChequeNo")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblChequeNoDate")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblBankId")).Text;
			string text4 = ((Label)gridViewRow.FindControl("lblType")).Text;
			string text5 = ((Label)gridViewRow.FindControl("lblTransNo")).Text;
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("Salary_BankStatement_CheckEdit.aspx?TransNo=" + text5 + "&MonthId=" + selectedValue + "&ModId=12&SubModId=133");
			}
			if (e.CommandName == "Print")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("Salary_BankStatement.aspx?ChequeNo=" + text + "&ChequeDate=" + text2 + "&BankId=" + text3 + "&EmpDirect=" + text4 + "&BGGroupId=" + selectedValue2 + "&Key=" + randomAlphaNumeric + "&MonthId=" + selectedValue + "&TransNo=" + text5 + "&ModId=12&SubModId=133");
			}
		}
		catch (Exception)
		{
		}
	}
}

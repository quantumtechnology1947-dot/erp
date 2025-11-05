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

public class Module_HR_Transactions_BankLoan : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Label Label2;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnSubmit;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string co = "";

	private string id = "";

	private string FyId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			Label2.Text = "";
			if (!base.IsPostBack)
			{
				TxtMrs.Visible = false;
				binddata(co, id);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label2.Text = base.Request.QueryString["msg"].ToString();
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				((TextBox)row.FindControl("TextFromDate")).Attributes.Add("readonly", "readonly");
				((TextBox)row.FindControl("TextToDate")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}

	public void binddata(string Search, string EmpId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			string text2 = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				text2 = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				TxtMrs.Visible = true;
				TxtEmpName.Visible = false;
			}
			else if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				string cmdText = fun.select("Id", "BusinessGroup", "Symbol='" + TxtMrs.Text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					text = " AND BGGroup='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'";
				}
			}
			DataTable dataTable = new DataTable();
			string cmdText2 = fun.select("UserID,BGGroup,Designation,EmpId,Title + '. ' + EmployeeName As EmployeeName,FinYearId,JoiningDate,Department,MobileNo,ResignationDate", "tblHR_OfficeStaff", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text2 + text + " AND ResignationDate='' AND UserID!='1' Order by UserID Desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGgroup", typeof(string)));
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("Symbol AS BGgroup", "BusinessGroup", string.Concat("Id='", dataSet2.Tables[0].Rows[i]["BGGroup"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet3.Tables[0].Rows[0]["BGgroup"].ToString();
					}
					dataRow[0] = dataSet2.Tables[0].Rows[i]["EmpId"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtEmpName.Text);
			binddata(TxtMrs.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpField.SelectedValue == "0")
		{
			TxtMrs.Visible = false;
			TxtEmpName.Visible = true;
			TxtEmpName.Text = "";
			binddata(co, id);
		}
		else
		{
			TxtMrs.Visible = true;
			TxtMrs.Text = "";
			TxtEmpName.Visible = false;
			binddata(co, id);
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

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		binddata(co, id);
	}

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req3")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req4")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req5")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req6")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req3")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req4")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req5")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req6")).Visible = false;
			}
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked)
			{
				((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req2")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req3")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req4")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req5")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req6")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req2")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req3")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("Req4")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("Req5")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("Req6")).Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
			int num3 = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num3++;
					if (((CheckBox)row.FindControl("CheckBox1")).Checked && fun.NumberValidationQty(((TextBox)row.FindControl("TextAmount")).Text) && fun.NumberValidationQty(((TextBox)row.FindControl("TextInstallment")).Text) && ((TextBox)row.FindControl("TextBank")).Text != "" && ((TextBox)row.FindControl("TextBranch")).Text != "" && ((TextBox)row.FindControl("TextFromDate")).Text != "" && ((TextBox)row.FindControl("TextToDate")).Text != "")
					{
						Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TextAmount")).Text.ToString()).ToString("N3"));
						Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TextInstallment")).Text.ToString()).ToString("N3"));
					}
				}
			}
			if (num3 > 0)
			{
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked)
					{
						double num4 = 0.0;
						double num5 = 0.0;
						if (((CheckBox)row2.FindControl("CheckBox1")).Checked && fun.NumberValidationQty(((TextBox)row2.FindControl("TextAmount")).Text) && fun.NumberValidationQty(((TextBox)row2.FindControl("TextInstallment")).Text) && ((TextBox)row2.FindControl("TextBank")).Text != "" && ((TextBox)row2.FindControl("TextBranch")).Text != "" && ((TextBox)row2.FindControl("TextFromDate")).Text != "" && ((TextBox)row2.FindControl("TextToDate")).Text != "")
						{
							num4 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TextAmount")).Text.ToString()).ToString("N3"));
							num5 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TextInstallment")).Text.ToString()).ToString("N3"));
							string text2 = ((Label)row2.FindControl("lblEmpId")).Text;
							string text3 = ((TextBox)row2.FindControl("TextBank")).Text;
							string text4 = ((TextBox)row2.FindControl("TextBranch")).Text;
							string text5 = ((TextBox)row2.FindControl("TextFromDate")).Text;
							string text6 = ((TextBox)row2.FindControl("TextToDate")).Text;
							string cmdText = fun.insert("tblHR_BankLoan", "SysDate,SysTime,CompId,FinYearId,SessionId,EmpId,BankName,Branch,Amount,Installment,fromDate,ToDate", "'" + currDate + "','" + currTime + "','" + num2 + "','" + num + "','" + text + "','" + text2 + "','" + text3 + "','" + text4 + "','" + num4 + "','" + num5 + "','" + fun.FromDate(text5) + "','" + fun.FromDate(text6) + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
						}
					}
				}
				base.Response.Redirect("BankLoan.aspx?&ModId=12&SubModId=129");
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

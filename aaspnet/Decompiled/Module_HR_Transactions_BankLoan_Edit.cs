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

public class Module_HR_Transactions_BankLoan_Edit : Page, IRequiresSessionState
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
				binddata(id);
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

	public void binddata(string EmpId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				text = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("*", "tblHR_BankLoan", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text + "   Order by EmpId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Branch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Installment", typeof(double)));
			dataTable.Columns.Add(new DataColumn("fromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["EmpId"].ToString();
					string cmdText2 = fun.select("Title + '. ' + EmployeeName As EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[i]["EmpId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[2] = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["BankName"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["Branch"].ToString();
					dataRow[5] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
					dataRow[6] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Installment"]);
					dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["fromDate"].ToString());
					dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ToDate"].ToString());
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
			binddata(code);
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
			binddata(id);
		}
		else
		{
			TxtMrs.Visible = true;
			TxtMrs.Text = "";
			TxtEmpName.Visible = false;
			binddata(id);
		}
	}

	[WebMethod]
	[ScriptMethod]
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
		binddata(id);
	}

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = false;
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
				((TextBox)gridViewRow.FindControl("TextBank")).Enabled = true;
				((TextBox)gridViewRow.FindControl("TextBranch")).Enabled = true;
				((TextBox)gridViewRow.FindControl("TextAmount")).Enabled = true;
				((TextBox)gridViewRow.FindControl("TextInstallment")).Enabled = true;
				((TextBox)gridViewRow.FindControl("TextFromDate")).Enabled = true;
				((TextBox)gridViewRow.FindControl("TextToDate")).Enabled = true;
			}
			else
			{
				((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req2")).Visible = true;
				((TextBox)gridViewRow.FindControl("TextBank")).Enabled = false;
				((TextBox)gridViewRow.FindControl("TextBranch")).Enabled = false;
				((TextBox)gridViewRow.FindControl("TextAmount")).Enabled = false;
				((TextBox)gridViewRow.FindControl("TextInstallment")).Enabled = false;
				((TextBox)gridViewRow.FindControl("TextFromDate")).Enabled = false;
				((TextBox)gridViewRow.FindControl("TextToDate")).Enabled = false;
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
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
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
							string text2 = ((Label)row2.FindControl("lblId")).Text;
							string text3 = ((Label)row2.FindControl("lblEmpId")).Text;
							string text4 = ((TextBox)row2.FindControl("TextBank")).Text;
							string text5 = ((TextBox)row2.FindControl("TextBranch")).Text;
							string text6 = ((TextBox)row2.FindControl("TextFromDate")).Text;
							string text7 = ((TextBox)row2.FindControl("TextToDate")).Text;
							string cmdText = fun.update("tblHR_BankLoan", "SysDate='" + currDate + "',SysTime='" + currTime + "',CompId='" + num2 + "',FinYearId='" + num + "',SessionId='" + text + "',EmpId='" + text3 + "',BankName='" + text4 + "',Branch='" + text5 + "',Amount='" + num4 + "',Installment='" + num5 + "',fromDate='" + fun.FromDate(text6) + "',ToDate='" + fun.FromDate(text7) + "'", "Id='" + text2 + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
						}
					}
				}
				base.Response.Redirect("BankLoan_Edit.aspx?ModId=12&SubModId=129");
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

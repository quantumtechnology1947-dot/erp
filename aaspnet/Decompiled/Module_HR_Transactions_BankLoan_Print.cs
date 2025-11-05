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

public class Module_HR_Transactions_BankLoan_Print : Page, IRequiresSessionState
{
	protected Label Label3;

	protected RadioButtonList RadioButtonList1;

	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Label Label2;

	protected GridView GridView2;

	protected Panel Panel1;

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

	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioButtonList1.SelectedValue == "0")
		{
			Panel1.Visible = true;
			return;
		}
		Panel1.Visible = true;
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		string text = "";
		base.Response.Redirect("BankLoan_Print_Details.aspx?EmpId=" + text + "&Key=" + randomAlphaNumeric + "&ModId=12&SubModId=129");
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		new SqlConnection(connectionString);
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				string text = ((Label)gridViewRow.FindControl("lblEmpId")).Text;
				base.Response.Redirect("BankLoan_Print_Details.aspx?EmpId=" + text + "&Key=" + randomAlphaNumeric + "&ModId=12&SubModId=129");
			}
		}
		catch (Exception)
		{
		}
	}
}

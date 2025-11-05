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

public class Module_HR_Transactions_OfferLetter_Edit : Page, IRequiresSessionState
{
	protected TextBox TextBox1;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string FyId = "";

	private string y = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				binddata(y);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void binddata(string EmpName)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOf", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DutyHrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GrossSal", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
			string text = "";
			if (TextBox1.Text != "")
			{
				text = "And EmployeeName='" + EmpName + "' ";
			}
			string cmdText = fun.select("*", "tblHR_Offer_Master", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text + " Order by OfferId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["OfferId"];
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
					{
						dataRow[2] = "SAPL";
					}
					else if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
					{
						dataRow[2] = "NEHA";
					}
					string cmdText2 = fun.select("*", "tblHR_EmpType", "Id='" + dataSet.Tables[0].Rows[i]["StaffType"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblHR_EmpType");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[4] = dataSet.Tables[0].Rows[i]["Title"].ToString() + " " + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
					string cmdText3 = fun.select("Type AS Designation", "tblHR_Designation", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Designation"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "tblHR_Designation");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["Designation"].ToString();
					}
					string cmdText4 = fun.select("Hours", "tblHR_DutyHour", string.Concat("Id='", dataSet.Tables[0].Rows[i]["DutyHrs"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblHR_DutyHour");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet4.Tables[0].Rows[0]["Hours"];
					}
					string cmdText5 = fun.select("EmployeeName", "tblHR_OfficeStaff", string.Concat("EmpId='", dataSet.Tables[0].Rows[i]["InterviewedBy"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataRow[8] = dataSet.Tables[0].Rows[i]["ContactNo"];
					dataRow[9] = dataSet.Tables[0].Rows[i]["salary"];
					string cmdText6 = fun.select("*", "tblHR_OfficeStaff", string.Concat("OfferId='", dataSet.Tables[0].Rows[i]["OfferId"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6, "tblHR_OfficeStaff");
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = "Confirm";
					}
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

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			binddata(y);
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
		string selectCommandText = clsFunctions2.select("EmployeeName", "tblHR_Offer_Master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[0].ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = 0;
			string empty = string.Empty;
			empty = ((Label)gridViewRow.FindControl("lblId")).Text;
			if (e.CommandName == "Select")
			{
				num = 0;
				base.Response.Redirect("~/Module/HR/Transactions/OfferLetter_Edit_Details.aspx?offid=" + empty + "&OI=" + num + "&ModId=12&SubModId=25");
			}
			if (e.CommandName == "Increment")
			{
				num = 1;
				base.Response.Redirect("~/Module/HR/Transactions/OfferLetter_Edit_Details.aspx?offid=" + empty + "&OI=" + num + "&ModId=12&SubModId=25");
			}
		}
		catch (Exception)
		{
		}
		sqlConnection.Close();
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		if (TextBox1.Text != "")
		{
			binddata(TextBox1.Text);
		}
	}
}

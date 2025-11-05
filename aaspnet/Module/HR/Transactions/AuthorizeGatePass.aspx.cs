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

public class Module_HR_Transactions_AuthorizeGatePass : Page, IRequiresSessionState
{
	protected TextBox txtFromDate;

	protected CalendarExtender txtFromDate_CalendarExtender;

	protected TextBox txtToDate;

	protected CalendarExtender txtToDate_CalendarExtender;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Button Check;

	protected GridView GridView2;

	protected Panel Panel1;

	protected GridView GridView3;

	protected Panel Panel2;

	protected HtmlGenericControl Up;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string emp = "";

	private string CDate = "";

	private string CTime = "";

	private string FyId = "";

	private string d = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			sId = fun.firstchar(Session["username"].ToString());
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			FyId = Session["finyear"].ToString();
			txtFromDate.Attributes.Add("readonly", "readonly");
			txtToDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string dT = "";
				if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
				{
					dT = " And tblGate_Pass.SySDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
				}
				loaddata(emp, dT);
			}
			Up.Visible = true;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		loaddata(emp, d);
	}

	public void loaddata(string empid, string DT)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string text = "";
			if (txtEmpName.Text != "")
			{
				text = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			string text2 = "";
			if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
			{
				text2 = " And tblGate_Pass.SySDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
			}
			string cmdText = fun.select("*", "tblGate_Pass", "  Authorize='0'  And CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text2 + text + "  Order By Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string empty = string.Empty;
				string empty2 = string.Empty;
				int num = 0;
				int num2 = 0;
				if (sqlDataReader["EmpId"] != DBNull.Value)
				{
					empty = fun.select("EmpId,DeptHead", "tblHR_OfficeStaff", " CompId='" + CompId + "' And FinYearId<='" + FyId + "' AND EmpId ='" + sqlDataReader["EmpId"].ToString() + "'");
					num = 1;
				}
				else
				{
					empty = fun.select("EmpId", "tblHR_OfficeStaff", "CompId='" + CompId + "' And FinYearId<='" + FyId + "' And  EmpId ='" + sqlDataReader["SessionId"].ToString() + "'");
					num2 = 1;
				}
				SqlCommand sqlCommand2 = new SqlCommand(empty, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (!sqlDataReader2.HasRows)
				{
					continue;
				}
				int num3 = 0;
				if (sId == "Sapl0001" || sId == "Sapl0002" || sId == "Sapl0003" || sId == "Sapl0205")
				{
					num3 = 1;
				}
				else
				{
					if (num == 1)
					{
						empty2 = fun.select("EmpId", "tblHR_OfficeStaff", "UserID='" + sqlDataReader2["DeptHead"].ToString() + "'");
						SqlCommand sqlCommand3 = new SqlCommand(empty2, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows && sqlDataReader3["EmpId"].ToString() == sId)
						{
							num3 = 1;
						}
					}
					if (num2 == 1 && sqlDataReader["SessionId"].ToString() == sId)
					{
						num3 = 1;
					}
				}
				if (num3 != 1)
				{
					continue;
				}
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader4["FinYear"].ToString();
				string cmdText3 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["EmpId"].ToString() + "'And CompId='" + CompId + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				if (sqlDataReader5.HasRows)
				{
					dataRow[2] = sqlDataReader5["Title"].ToString() + ". " + sqlDataReader5["EmployeeName"].ToString();
				}
				else
				{
					string cmdText4 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["SessionId"].ToString() + "'And CompId='" + CompId + "'");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					if (sqlDataReader6.HasRows)
					{
						dataRow[2] = sqlDataReader6["Title"].ToString() + ". " + sqlDataReader6["EmployeeName"].ToString();
					}
				}
				if (Convert.ToInt32(sqlDataReader["Authorize"]) == 1)
				{
					dataRow[3] = fun.FromDateDMY(sqlDataReader["AuthorizeDate"].ToString());
				}
				dataRow[4] = sqlDataReader["GPNo"].ToString();
				dataRow[5] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((Label)row.FindControl("lblcheck")).Text != "")
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CK");
					checkBox.Visible = false;
				}
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
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				ViewState["Id"] = num;
				FillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			int num = 0;
			if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
			{
				num = Convert.ToInt32(ViewState["Id"]);
			}
			string cmdText = fun.select("*", "tblGatePass_Details", "MId='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Place", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOf", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = fun.FromDate(sqlDataReader["FromDate"].ToString());
				dataRow[2] = sqlDataReader["FromTime"].ToString();
				dataRow[3] = sqlDataReader["ToTime"].ToString();
				dataRow[4] = sqlDataReader["Place"].ToString();
				dataRow[5] = sqlDataReader["ContactPerson"].ToString();
				dataRow[6] = sqlDataReader["ContactNo"].ToString();
				dataRow[7] = sqlDataReader["Reason"].ToString();
				string cmdText2 = fun.select("*", "tblGatePass_Reason", "Id='" + sqlDataReader["Type"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[8] = sqlDataReader2["Reason"].ToString();
				string value = "";
				if (sqlDataReader["TypeOf"].ToString() == "1")
				{
					value = "WONo";
				}
				if (sqlDataReader["TypeOf"].ToString() == "2")
				{
					value = "Enquiry";
				}
				if (sqlDataReader["TypeOf"].ToString() == "3")
				{
					value = "Others";
				}
				dataRow[9] = value;
				dataRow[10] = sqlDataReader["TypeFor"].ToString();
				if (sqlDataReader["EmpId"] != DBNull.Value)
				{
					string cmdText3 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["EmpId"].ToString() + "'And CompId='" + CompId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					dataRow[11] = sqlDataReader3["Title"].ToString() + ". " + sqlDataReader3["EmployeeName"].ToString();
				}
				else
				{
					string cmdText4 = fun.select("EmpId", "tblGate_Pass", "Id='" + num + "'And CompId='" + CompId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					string cmdText5 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader4["EmpId"].ToString() + "'And CompId='" + CompId + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					dataRow[11] = sqlDataReader5["Title"].ToString() + ". " + sqlDataReader5["EmployeeName"].ToString();
				}
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string dT = "";
			if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
			{
				dT = " And tblGate_Pass.SySDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
			}
			string empid = "";
			if (txtEmpName.Text != "")
			{
				empid = " AND EmpId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			loaddata(empid, dT);
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
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
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

	protected void Check_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("CK");
				if (checkBox.Checked)
				{
					string connectionString = fun.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					string text = ((Label)row.FindControl("lblId")).Text;
					string cmdText = fun.update("tblGate_Pass", "Authorize='1',AuthorizedBy='" + sId + "',AuthorizeDate='" + CDate + "',AuthorizeTime='" + CTime + "'", "CompId='" + CompId + "' AND Id='" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					num++;
				}
			}
			if (num > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				return;
			}
			string empty = string.Empty;
			empty = "No record is found to checked.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		FillGrid();
	}

	protected void GridView3_RowCommand1(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				sqlConnection.Open();
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				int num = 0;
				if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
				{
					num = Convert.ToInt32(ViewState["Id"]);
				}
				SqlCommand sqlCommand = new SqlCommand(fun.delete("tblGatePass_Details", " Id=" + text + "    "), sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText = fun.select("*", "tblGatePass_Details", "MId='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				sqlDataReader.Read();
				if (!sqlDataReader.HasRows)
				{
					SqlCommand sqlCommand3 = new SqlCommand(fun.delete("tblGate_Pass", " Id=" + num + "    "), sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

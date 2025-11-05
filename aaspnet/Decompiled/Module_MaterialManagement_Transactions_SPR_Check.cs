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

public class Module_MaterialManagement_Transactions_SPR_Check : Page, IRequiresSessionState
{
	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtSprNo;

	protected Button Button1;

	protected Button Check;

	protected GridView GridView2;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string spr = "";

	private string emp = "";

	private string CDate = "";

	private string CTime = "";

	private string FyId = "";

	private string parentPage = "SPR_Check.aspx";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				txtSprNo.Visible = false;
				makegrid(spr, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		makegrid(spr, emp);
	}

	public void makegrid(string sprno, string empid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SPRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CheckedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ApprovedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			CompId = Convert.ToInt32(Session["compid"]);
			string text = "";
			if (drpfield.SelectedValue == "1" && txtSprNo.Text != "")
			{
				text = " AND SPRNo='" + txtSprNo.Text + "'";
			}
			string text2 = "";
			if (drpfield.SelectedValue == "0" && txtEmpName.Text != "")
			{
				text2 = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			string cmdText = fun.select("*", "tblMM_SPR_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + text + text2 + " AND Checked='0' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "'  And EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["SPRNo"].ToString();
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[2] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
					dataRow[3] = dataSet2.Tables[0].Rows[0]["EmpName"].ToString();
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Checked"]) == 1)
					{
						dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CheckedDate"].ToString());
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Approve"]) == 1)
					{
						dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ApproveDate"].ToString());
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Authorize"]) == 1)
					{
						dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["AuthorizeDate"].ToString());
					}
					dataRow[7] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND  CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[8] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
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
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "view")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_View_Print.aspx?ModId=6&SubModId=31&Id=" + ((Label)gridViewRow.FindControl("lblId")).Text + "&SPRNo=" + ((Label)gridViewRow.FindControl("lblsprno")).Text + "&Key=" + randomAlphaNumeric + "&parentpage=" + parentPage);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		makegrid(txtSprNo.Text, txtEmpName.Text);
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "1")
			{
				txtSprNo.Visible = true;
				txtSprNo.Text = "";
				txtEmpName.Visible = false;
				makegrid(spr, emp);
			}
			else
			{
				txtSprNo.Visible = false;
				txtEmpName.Visible = true;
				txtEmpName.Text = "";
				makegrid(spr, emp);
			}
		}
		catch (Exception)
		{
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
					string text = ((Label)row.FindControl("lblsprno")).Text;
					string text2 = ((Label)row.FindControl("lblId")).Text;
					string cmdText = fun.update("tblMM_SPR_Master", "Checked='1',CheckedBy='" + sId + "',CheckedDate='" + CDate + "',CheckedTime='" + CTime + "'", "CompId='" + CompId + "' AND SPRNo='" + text + "' AND Id='" + text2 + "'");
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
}

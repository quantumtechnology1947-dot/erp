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

public class Module_MaterialManagement_Transactions_SPR_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string spr = "";

	private string emp = "";

	private string FyId = "";

	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtSprNo;

	protected Button btnSearch;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				LoadData(spr, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData(string SprNo, string empid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SPRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
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
			string cmdText = fun.select("Id,SessionId,SPRNo,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblMM_SPR_Master.SysDate, CHARINDEX('-', tblMM_SPR_Master.SysDate) + 1, 2) + '-' + LEFT(tblMM_SPR_Master.SysDate,CHARINDEX('-', tblMM_SPR_Master.SysDate) - 1) + '-' + RIGHT(tblMM_SPR_Master.SysDate, CHARINDEX('-', REVERSE(tblMM_SPR_Master.SysDate)) - 1)), 103), '/', '-') AS SysDate,SysTime AS Time", "tblMM_SPR_Master", "   FinYearId<='" + FyId + "' And CompId='" + CompId + "'" + text + text2 + " Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["SPRNo"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["Time"].ToString();
					dataRow[3] = dataSet2.Tables[0].Rows[0]["EmpName"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'  AND CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (drpfield.SelectedValue == "1")
		{
			txtSprNo.Visible = true;
			txtSprNo.Text = "";
			txtEmpName.Visible = false;
			LoadData(spr, emp);
		}
		else
		{
			txtSprNo.Visible = false;
			txtEmpName.Visible = true;
			txtEmpName.Text = "";
			LoadData(spr, emp);
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		LoadData(txtSprNo.Text, txtEmpName.Text);
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadData(spr, emp);
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
}

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

public class Module_HR_Transactions_OfficeStaff_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string co = "";

	private string id = "";

	private string FyId = "";

	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Button btnExportToExcel;

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
				TxtMrs.Visible = false;
				binddata(co, id);
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
			sqlConnection.Open();
			string value = "";
			string value2 = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				value2 = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				TxtMrs.Visible = true;
				TxtEmpName.Visible = false;
			}
			if (DrpField.SelectedValue == "1")
			{
				if (TxtMrs.Text != "")
				{
					string cmdText = fun.select("Id", "tblHR_Departments", "Description='" + TxtMrs.Text + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					value = " AND Department='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'";
				}
			}
			else if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				string cmdText2 = fun.select("Id", "BusinessGroup", "Symbol='" + TxtMrs.Text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					value = " AND BGGroup='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "'";
				}
			}
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("Sp_Staff_Grid_Print", sqlConnection);
			sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter3.SelectCommand.Parameters["@FinId"].Value = FyId;
			sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter3.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter3.SelectCommand.Parameters["@y"].Value = value2;
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			ViewState["dtList"] = dataSet3.Tables[0];
			GridView2.DataSource = dataSet3;
			GridView2.DataBind();
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblEmpId")).Text;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			string text2 = "1";
			base.Response.Redirect("~/Module/HR/Transactions/OfficeStaff_Print_Details.aspx?EmpId=" + text + "&ModId=12&SubModId=24&PagePrev=" + text2 + "&Key=" + randomAlphaNumeric);
		}
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		binddata(co, id);
	}

	protected void btnExportToExcel_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
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
}

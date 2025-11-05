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

public class Module_MaterialManagement_Transactions_PO_Delete : Page, IRequiresSessionState
{
	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected Button btnCancel;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private int CompId;

	private string po = "";

	private string emp = "";

	private string FyId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SupCode = base.Request.QueryString["Code"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				LoadData(po, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData(string poNo, string empid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			string text = "";
			if (drpfield.SelectedValue == "1" && txtpoNo.Text != "")
			{
				text = " AND PONo='" + txtpoNo.Text + "'";
			}
			string text2 = "";
			if (drpfield.SelectedValue == "0" && txtEmpName.Text != "")
			{
				text2 = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			string cmdText = fun.select("Id,PONo,FinYearId,SysDate,SysTime,SessionId,AmendmentNo", "tblMM_PO_Master", "SupplierId='" + SupCode + "' AND FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + text + text2 + " Order By PONo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName AS GenBy", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					string value = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[1] = value;
					dataRow[2] = dataSet.Tables[0].Rows[i]["AmendmentNo"].ToString();
					dataRow[3] = dataSet2.Tables[0].Rows[0]["GenBy"].ToString();
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[4] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["Id"].ToString();
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
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadData(po, emp);
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblpono")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string cmdText = fun.select("PRSPRFlag", "tblMM_PO_Master", "SupplierId='" + SupCode + "' And tblMM_PO_Master.PONo='" + text + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				base.Response.Redirect("PO_Delete_Details.aspx?mid=" + text2 + "&pono=" + text + "&Code=" + SupCode + "&ModId=6&SubModId=35");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_Delete_Supplier.aspx?ModId=6&SubModId=35");
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (drpfield.SelectedValue == "1")
		{
			txtpoNo.Visible = true;
			txtpoNo.Text = "";
			txtEmpName.Visible = false;
			LoadData(po, emp);
		}
		else
		{
			txtpoNo.Visible = false;
			txtEmpName.Visible = true;
			txtEmpName.Text = "";
			LoadData(po, emp);
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		LoadData(txtpoNo.Text, txtEmpName.Text);
	}

	protected void GridView2_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadData(po, emp);
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
}

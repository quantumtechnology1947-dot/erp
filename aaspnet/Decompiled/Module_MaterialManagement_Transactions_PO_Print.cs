using System;
using System.Collections.Generic;
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

public class Module_MaterialManagement_Transactions_PO_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private int CompId;

	private string po = "";

	private string emp = "";

	private string FyId = "";

	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected Button btnCancel;

	protected GridView GridView2;

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
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
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
			string cmdText = fun.select("tblMM_PO_Master.Id,tblMM_PO_Master.FileName,tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Master.SysTime,tblMM_PO_Master.SessionId,tblMM_PO_Master.AmendmentNo", "tblMM_PO_Master", "tblMM_PO_Master.SupplierId='" + SupCode + "' AND FinYearId<='" + FyId + "' AND tblMM_PO_Master.CompId='" + CompId + "' " + text + text2 + " Order By tblMM_PO_Master.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblHR_OfficeStaff.Title+'. '+EmployeeName AS GenBy", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "' AND CompId='" + CompId + "'");
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
					dataRow[4] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
					dataRow[5] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["FileName"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text3 = ((Label)row.FindControl("lblId")).Text;
				string cmdText4 = fun.select("AmendmentNo", "tblMM_PO_Master", "Id ='" + text3 + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				List<string> list = new List<string>();
				for (int num = Convert.ToInt32(dataSet4.Tables[0].Rows[0][0]); num >= 0; num--)
				{
					list.Add(num.ToString());
				}
				((DropDownList)row.FindControl("AmdDropDown")).DataSource = list;
				((DropDownList)row.FindControl("AmdDropDown")).DataBind();
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
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblpono")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
			string value = ((DropDownList)gridViewRow.FindControl("AmdDropDown")).SelectedItem.Value;
			if (e.CommandName == "sel")
			{
				string cmdText = fun.select("PRSPRFlag", "tblMM_PO_Master", "Id=" + text2 + " ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows[0][0].ToString() == "0")
				{
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_Print_Details.aspx?mid=" + text2 + "&pono=" + text + "&Code=" + SupCode + "&AmdNo=" + value + "&Key=" + randomAlphaNumeric + "&ModId=6&SubModId=35");
				}
				else
				{
					string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_SPR_Print_Details.aspx?mid=" + text2 + "&pono=" + text + "&Code=" + SupCode + "&AmdNo=" + value + "&Key=" + randomAlphaNumeric2 + "&ModId=6&SubModId=35");
				}
			}
			if (e.CommandName == "Download")
			{
				string cmdText2 = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + text + "' AND Id='" + text2 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows[0]["FileName"] == DBNull.Value || dataSet2.Tables[0].Rows[0]["FileName"].ToString() == "")
				{
					((LinkButton)gridViewRow.FindControl("LinkBtnDownload")).Visible = false;
					return;
				}
				((LinkButton)gridViewRow.FindControl("LinkBtnDownload")).Visible = true;
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "&tbl=tblMM_PO_Master&qfd=FileData&qfn=fileName&qct=ContentType");
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
		base.Response.Redirect("PO_Print_Supplier.aspx?ModId=6&SubModId=35");
	}

	protected void GridView2_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadData(po, emp);
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

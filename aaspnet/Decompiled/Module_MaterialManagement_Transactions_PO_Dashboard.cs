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

public class Module_MaterialManagement_Transactions_PO_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string spr = "";

	private string supcode = "";

	private string FyId = "";

	private string parentPage = "PO_Dashboard.aspx";

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				txtPONo.Visible = false;
				makegrid(spr, supcode);
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.delete("tblMM_PR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.delete("tblMM_SPR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public void makegrid(string sprno, string supcode)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CheckedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ApprovedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Sup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmendmentNo", typeof(string)));
			CompId = Convert.ToInt32(Session["compid"]);
			string text = "";
			if (drpfield.SelectedValue == "1" && txtPONo.Text != "")
			{
				text = "AND PONo='" + txtPONo.Text + "'";
			}
			string cmdText = fun.select("*", "tblMM_PO_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + text + " AND Authorize='0' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName,EmpId", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string text2 = "";
				text2 = ((!(drpfield.SelectedValue == "0")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : ((!(txtSupplier.Text != "")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : (" AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'")));
				string cmdText3 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + text2);
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[0] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[2] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet2.Tables[0].Rows[0]["EmpName"].ToString();
				}
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
				dataRow[8] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				dataRow[10] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["AmendmentNo"].ToString();
				if (dataSet.Tables[0].Rows[i]["SupplierId"].ToString() == dataSet3.Tables[0].Rows[0]["SupplierId"].ToString())
				{
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (!(e.CommandName == "view"))
			{
				return;
			}
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblsprno")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblsupcode")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblId")).Text;
			string text4 = ((Label)gridViewRow.FindControl("lblAmendmentNo")).Text;
			string cmdText = fun.select("PRSPRFlag", "tblMM_PO_Master", "Id='" + text3 + "' AND FinYearId<='" + FyId + "' AND SupplierId='" + text2 + "' And PONo='" + text + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0][0].ToString() == "0")
				{
					string empty = string.Empty;
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_PR_View_Print_Details.aspx?mid=" + text3 + "&pono=" + text + "&Code=" + text2 + "&AmdNo=" + text4 + "&Key=" + randomAlphaNumeric + "&Trans=" + empty + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
				else
				{
					string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_SPR_View_Print_Details.aspx?mid=" + text3 + "&pono=" + text + "&Code=" + text2 + "&AmdNo=" + text4 + "&Key=" + randomAlphaNumeric2 + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (drpfield.SelectedValue == "1")
		{
			txtPONo.Visible = true;
			txtPONo.Text = "";
			txtSupplier.Visible = false;
			makegrid(spr, supcode);
		}
		if (drpfield.SelectedValue == "0")
		{
			txtSupplier.Visible = true;
			txtSupplier.Text = "";
			txtPONo.Visible = false;
			makegrid(spr, supcode);
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		makegrid(txtPONo.Text, txtSupplier.Text);
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList2(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void GridView2_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			makegrid(spr, supcode);
		}
		catch (Exception)
		{
		}
	}
}

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

public class Module_HR_Reports_MultipleReports : Page, IRequiresSessionState
{
	protected DropDownList DrpCriteria;

	protected DropDownList DrpSubCriteria;

	protected DropDownList DrpSearch;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtSearch;

	protected Button btnSearch;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string dp1 = "";

	private string dp2 = "";

	private string tx = "";

	private string U = "";

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				DrpSubCriteria.Items.Clear();
				DrpSubCriteria.Items.Insert(0, "Select");
				binddropdwn(dp1, dp2, tx);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			binddropdwn(dp1, dp2, tx);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DrpSearch.SelectedValue == "1")
			{
				binddropdwn(DrpCriteria.SelectedValue, DrpSubCriteria.SelectedValue, txtEmpName.Text);
			}
			else
			{
				binddropdwn(DrpCriteria.SelectedValue, DrpSubCriteria.SelectedValue, txtSearch.Text);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCriteria_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			if (DrpCriteria.SelectedItem.Text == "Department")
			{
				string cmdText = fun.select1("tblHR_Departments.Id,tblHR_Departments.Symbol + '-' +tblHR_Departments.Description AS DeptName ", "tblHR_Departments ");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblHR_Departments");
				DrpSubCriteria.DataSource = dataSet.Tables["tblHR_Departments"];
				DrpSubCriteria.DataTextField = "DeptName";
				DrpSubCriteria.DataValueField = "Id";
				DrpSubCriteria.DataBind();
				DrpSubCriteria.Items.Insert(0, "Select");
			}
			if (DrpCriteria.SelectedItem.Text == "Grade")
			{
				string cmdText2 = fun.select1("Id,Symbol", "tblHR_Grade");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblHR_Grade");
				DrpSubCriteria.DataSource = dataSet2.Tables["tblHR_Grade"];
				DrpSubCriteria.DataTextField = "Symbol";
				DrpSubCriteria.DataValueField = "Id";
				DrpSubCriteria.DataBind();
				DrpSubCriteria.Items.Insert(0, "Select");
			}
			if (DrpCriteria.SelectedItem.Text == "Designation")
			{
				string cmdText3 = fun.select1("tblHR_Designation.Id,tblHR_Designation.Symbol+'-'+tblHR_Designation.Type  As designation", "tblHR_Designation");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblHR_Designation");
				DrpSubCriteria.DataSource = dataSet3.Tables["tblHR_Designation"];
				DrpSubCriteria.DataTextField = "designation";
				DrpSubCriteria.DataValueField = "Id";
				DrpSubCriteria.DataBind();
				DrpSubCriteria.Items.Insert(0, "Select");
			}
			if (DrpCriteria.SelectedItem.Text == "BusinessGroup")
			{
				string cmdText4 = fun.select1("Id,Symbol", "BusinessGroup");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "BusinessGroup");
				DrpSubCriteria.DataSource = dataSet4.Tables["BusinessGroup"];
				DrpSubCriteria.DataTextField = "Symbol";
				DrpSubCriteria.DataValueField = "Id";
				DrpSubCriteria.DataBind();
				DrpSubCriteria.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpSubCriteria_SelectedIndexChanged(object sender, EventArgs e)
	{
		binddropdwn(DrpCriteria.SelectedValue, DrpSubCriteria.SelectedValue, tx);
	}

	public void binddropdwn(string drp1, string drp2, string Txvalue)
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (DrpCriteria.SelectedItem.Text == "Department")
			{
				text = "AND Department=" + drp2;
			}
			string text2 = "";
			if (DrpCriteria.SelectedItem.Text == "BusinessGroup")
			{
				text2 = "AND BGGroup='" + drp2 + "'";
			}
			string text3 = "";
			if (DrpCriteria.SelectedItem.Text == "Grade")
			{
				text3 = " AND Grade=" + drp2;
			}
			string text4 = "";
			if (DrpCriteria.SelectedItem.Text == "Designation")
			{
				text4 = " AND Designation=" + drp2;
			}
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			if (DrpCriteria.SelectedValue == "Select")
			{
				if (DrpSearch.SelectedValue == "0" && txtSearch.Text != "")
				{
					text5 = " AND EmpId='" + Txvalue + "'";
				}
				if (DrpSearch.SelectedValue == "1" && txtEmpName.Text != "")
				{
					text6 = " And  EmpId='" + fun.getCode(txtEmpName.Text) + "'";
				}
				if (DrpSearch.SelectedValue == "2" && txtSearch.Text != "")
				{
					text7 = "Gender='" + Txvalue + "'";
				}
				text8 = ((!(DrpSearch.SelectedItem.Text == "Resigned")) ? " And  ResignationDate=''" : " And  ResignationDate!=''");
			}
			if (DrpCriteria.SelectedValue != "Select")
			{
				if (DrpSearch.SelectedItem.Text == "EmpId" && txtSearch.Text != "")
				{
					text5 = " And  EmpId='" + Txvalue + "'";
				}
				if (DrpSearch.SelectedItem.Text == "EmployeeName" && txtEmpName.Text != "")
				{
					text6 = " And  EmpId='" + fun.getCode(txtEmpName.Text) + "'";
				}
				if (DrpSearch.SelectedItem.Text == "Gender" && txtSearch.Text != "")
				{
					text7 = " And  Gender='" + Txvalue + "'";
				}
				text8 = ((!(DrpSearch.SelectedItem.Text == "Resigned")) ? " And  ResignationDate=''" : " And  ResignationDate!=''");
			}
			string text9 = "Order By UserID Desc";
			string text10 = "CompId='" + CompId + "'";
			string text11 = "And FinYearId<='" + FinYearId + "'";
			string cmdText = fun.select("FinYearId,EmpId,Gender,Department,BGGroup,Designation,SwapCardNo,Grade,Title + ' ' +EmployeeName as EmpName,MobileNo,Gender,EmailId1,EmailId2,JoiningDate,ResignationDate", "tblHR_OfficeStaff", " UserID!='1' AND " + text10 + text11 + text + text2 + text3 + text4 + text7 + text6 + text5 + text8 + text9);
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Grade", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Gender", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmailId1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmailId2", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SwapCardNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("JoiningDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ResignationDate", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = fun.select("Id,Symbol AS DeptName", "tblHR_Departments", "Id='" + dataSet.Tables[0].Rows[i]["Department"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("Symbol AS BGGroup ", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["BGGroup"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[5] = dataSet3.Tables[0].Rows[0]["BGGroup"].ToString();
				}
				string cmdText4 = fun.select(" Symbol + '-' + Type AS Designation", "tblHR_Designation", "Id='" + dataSet.Tables[0].Rows[i]["Designation"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet4.Tables[0].Rows[0]["Designation"].ToString();
				}
				if (DrpSearch.SelectedValue == "3" && txtSearch.Text != "")
				{
					U = " And  MobileNo='" + Txvalue + "'";
				}
				string cmdText5 = fun.select("MobileNo", "tblHR_CoporateMobileNo", "Id='" + dataSet.Tables[0].Rows[i]["MobileNo"].ToString() + "'" + U);
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				dataRow[7] = dataSet5.Tables[0].Rows[0]["MobileNo"].ToString();
				string text12 = "";
				if (DrpSearch.SelectedValue == "4" && txtSearch.Text != "")
				{
					text12 = " And SwapCardNo='" + Txvalue + "'";
				}
				string cmdText6 = fun.select("Id,SwapCardNo", "tblHR_SwapCard", string.Concat("Id='", dataSet.Tables[0].Rows[i]["SwapCardNo"], "'", text12));
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = dataSet6.Tables[0].Rows[0]["SwapCardNo"].ToString();
					string cmdText7 = fun.select("Symbol As Grade", "tblHR_Grade", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Grade"], "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet7.Tables[0].Rows[0]["Grade"].ToString();
						dataRow[0] = dataSet.Tables[0].Rows[i]["EmpId"].ToString();
						dataRow[1] = dataSet.Tables[0].Rows[i]["EmpName"].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0]["DeptName"].ToString();
						dataRow[6] = dataSet.Tables[0].Rows[i]["Gender"].ToString();
						dataRow[8] = dataSet.Tables[0].Rows[i]["EmailId1"].ToString();
						dataRow[9] = dataSet.Tables[0].Rows[i]["EmailId2"].ToString();
						string cmdText8 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						dataRow[11] = dataSet8.Tables[0].Rows[0]["FinYear"].ToString();
						dataRow[12] = fun.FromDate(dataSet.Tables[0].Rows[i]["JoiningDate"].ToString());
						dataRow[13] = fun.FromDate(dataSet.Tables[0].Rows[i]["ResignationDate"].ToString());
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
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

	protected void DrpSearch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpSearch.SelectedValue == "1")
		{
			txtEmpName.Visible = true;
			txtSearch.Visible = false;
			binddropdwn(dp1, dp2, txtEmpName.Text);
			txtSearch.Text = "";
		}
		else
		{
			txtEmpName.Visible = false;
			txtSearch.Visible = true;
			binddropdwn(dp1, dp2, tx);
			txtSearch.Text = "";
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblEmpId")).Text;
			string text2 = "2";
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			base.Response.Redirect("~/Module/HR/Transactions/OfficeStaff_Print_Details.aspx?EmpId=" + text + "&ModId=12&SubModId=&PagePrev=" + text2 + "&Key=" + randomAlphaNumeric);
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

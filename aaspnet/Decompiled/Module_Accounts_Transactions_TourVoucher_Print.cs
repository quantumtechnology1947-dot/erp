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

public class Module_Accounts_Transactions_TourVoucher_Print : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected DropDownList drpGroup;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FyId;

	private string co = "";

	private string id = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Convert.ToInt32(Session["finyear"].ToString());
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				TxtMrs.Visible = false;
				drpGroup.Visible = false;
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
			string text = "";
			string text2 = "";
			string text3 = "";
			if (DrpField.SelectedValue == "1" && TxtEmpName.Text != "")
			{
				text2 = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				TxtMrs.Visible = true;
				TxtEmpName.Visible = false;
			}
			if (DrpField.SelectedValue == "0" && TxtMrs.Text != "")
			{
				text = " AND TINo='" + TxtMrs.Text + "'";
			}
			if (DrpField.SelectedValue == "2" && TxtMrs.Text != "")
			{
				text = " AND WONo='" + TxtMrs.Text + "'";
			}
			if (DrpField.SelectedValue == "3")
			{
				text = " AND BGGroupId='" + drpGroup.SelectedValue + "'";
			}
			if (DrpField.SelectedValue == "4" && TxtMrs.Text != "")
			{
				text = " AND ProjectName like '%" + TxtMrs.Text + "%'";
			}
			if (DrpField.SelectedValue == "5" && TxtMrs.Text != "")
			{
				text3 = " AND TVNo ='" + TxtMrs.Text + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("*", "tblACC_TourVoucher_Master", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text3 + " Order by Id Desc ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGgroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ProjectName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PlaceOfTour", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TourStartDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TourEndDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TINo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TIMId", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["TVNo"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["TIMId"].ToString();
				string cmdText2 = fun.select("*", "tblACC_TourIntimation_Master", "Id='" + dataSet.Tables[0].Rows[i]["TIMId"].ToString() + "' AND CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text2 + text + " Order by Id Desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				dataRow[1] = dataSet2.Tables[0].Rows[0]["EmpId"].ToString();
				string cmdText3 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet2.Tables[0].Rows[0]["FinyearId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
				}
				string selectCommandText = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FyId, "' AND EmpId='", dataSet2.Tables[0].Rows[0]["EmpId"], "'"));
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, sqlConnection);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblHR_OfficeStaff");
				dataRow[3] = dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
				if (dataSet2.Tables[0].Rows[0]["BGGroupId"].ToString() != "1")
				{
					string cmdText4 = fun.select("Symbol AS BGgroup", "BusinessGroup", "Id='" + dataSet2.Tables[0].Rows[0]["BGGroupId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet5.Tables[0].Rows[0]["BGgroup"].ToString();
						dataRow[4] = "NA";
					}
				}
				else
				{
					dataRow[5] = "NA";
					dataRow[4] = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
				}
				dataRow[6] = dataSet2.Tables[0].Rows[0]["ProjectName"].ToString();
				string cmdText5 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet2.Tables[0].Rows[0]["PlaceOfTourCity"], "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				string cmdText6 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet2.Tables[0].Rows[0]["PlaceOfTourState"], "' "));
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				string cmdText7 = fun.select("CountryName", "tblCountry", string.Concat("CId='", dataSet2.Tables[0].Rows[0]["PlaceOfTourCountry"], "' "));
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				string value = "";
				if (dataSet6.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows.Count > 0 && dataSet8.Tables[0].Rows.Count > 0)
				{
					value = dataSet8.Tables[0].Rows[0]["CountryName"].ToString() + ", " + dataSet7.Tables[0].Rows[0]["StateName"].ToString() + ", " + dataSet6.Tables[0].Rows[0]["CityName"].ToString();
				}
				dataRow[7] = value;
				dataRow[8] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TourStartDate"].ToString());
				dataRow[9] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TourEndDate"].ToString());
				dataRow[11] = dataSet2.Tables[0].Rows[0]["TINo"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
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
			binddata(TxtMrs.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (DrpField.SelectedValue == "Select")
			{
				drpGroup.Visible = false;
				TxtMrs.Visible = true;
				TxtMrs.Text = "";
				TxtEmpName.Visible = false;
				binddata(co, id);
			}
			if (DrpField.SelectedValue == "1")
			{
				drpGroup.Visible = false;
				TxtMrs.Visible = false;
				TxtEmpName.Visible = true;
				TxtEmpName.Text = "";
				binddata(co, id);
			}
			if (DrpField.SelectedValue == "0" || DrpField.SelectedValue == "2" || DrpField.SelectedValue == "4" || DrpField.SelectedValue == "5")
			{
				drpGroup.Visible = false;
				TxtMrs.Visible = true;
				TxtMrs.Text = "";
				TxtEmpName.Visible = false;
				binddata(co, id);
			}
			if (DrpField.SelectedValue == "3")
			{
				TxtMrs.Visible = false;
				TxtMrs.Text = "";
				TxtEmpName.Visible = false;
				drpGroup.Visible = true;
				string cmdText = fun.select1("Symbol,Id ", " BusinessGroup");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BusinessGroup");
				drpGroup.DataSource = dataSet;
				drpGroup.DataTextField = "Symbol";
				drpGroup.DataValueField = "Id";
				drpGroup.DataBind();
				binddata(co, id);
			}
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
				if (array.Length == 10)
				{
					break;
				}
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblTIMId")).Text);
				base.Response.Redirect("TourVoucher_Print_Details.aspx?Id=" + num + "&TIMId=" + num2 + "&ModId=11&SubModId=126&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		binddata(co, id);
	}
}

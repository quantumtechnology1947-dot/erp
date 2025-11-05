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

public class Module_SalesDistribution_Masters_CustomerMaster_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string CId = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	protected Label Label2;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button Search;

	protected GridView SearchGridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				BindDataCust(CId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindDataCust(CId);
		}
		catch (Exception)
		{
		}
	}

	protected void Search_Click(object sender, EventArgs e)
	{
		try
		{
			if (TxtSearchValue.Text != "")
			{
				BindDataCust(TxtSearchValue.Text);
			}
			else
			{
				BindDataCust(CId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid)
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			if (TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text = " AND CustomerId='" + code + "' ";
			}
			string cmdText = fun.select("RegdAddress,RegdCountry,RegdState,RegdCity,CustomerId,SalesId,CustomerName,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_master.SysDate, CHARINDEX('-', SD_Cust_master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_master.SysDate,CHARINDEX('-', SD_Cust_master.SysDate) - 1) + '-' + RIGHT(SD_Cust_master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_master", "FinYearId<=" + FinYearId + " AND CompId='" + CompId + "'" + text + " Order By SalesId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[1] = dataSet.Tables[0].Rows[i]["CustomerName"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["CustomerId"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					string text2 = dataSet.Tables[0].Rows[i]["RegdAddress"].ToString();
					string cmdText4 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[i]["RegdCountry"], "'"));
					string cmdText5 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[i]["RegdState"], "'"));
					string cmdText6 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[i]["RegdCity"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet4 = new DataSet();
					DataSet dataSet5 = new DataSet();
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblCountry");
					sqlDataAdapter5.Fill(dataSet5, "tblState");
					sqlDataAdapter6.Fill(dataSet6, "tblcity");
					string value = text2 + ",\n" + dataSet6.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet5.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet4.Tables[0].Rows[0]["CountryName"].ToString() + ".";
					dataRow[5] = value;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

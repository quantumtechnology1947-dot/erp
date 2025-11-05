using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_ReleaseWIS_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string wono = "";

	protected GridView GridView2;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		FinYearId = Convert.ToInt32(Session["finyear"]);
		try
		{
			CompId = Convert.ToInt32(base.Request.QueryString["cid"]);
			wono = base.Request.QueryString["wn"].ToString();
			SId = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				loadgrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand(fun.select("Id,CompId ,WONo,FinYearId,WONo,ReleaseSysDate,ReleaseSysTime,ReleaseBy", "tblInv_WORelease_WIS", "CompId='" + CompId + "' And WONO='" + wono + "' Order by Id Desc"), connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseSysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseSysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					string cmdText = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[3] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ReleaseSysDate"].ToString());
					dataRow[4] = dataSet.Tables[0].Rows[0]["ReleaseSysTime"].ToString();
					if (dataSet.Tables[0].Rows[i]["ReleaseBy"] != DBNull.Value)
					{
						string cmdText2 = fun.select("tblHR_OfficeStaff.Title+'. '+tblHR_OfficeStaff.EmployeeName AS GenBy", "tblHR_OfficeStaff", "tblHR_OfficeStaff.EmpId='" + dataSet.Tables[0].Rows[i]["ReleaseBy"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText2, connection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet3.Tables[0].Rows[0]["GenBy"].ToString();
						}
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		loadgrid();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ReleaseWIS.aspx?ModId=9");
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_Output_Edit : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox TxtSearchValue;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		SId = Session["username"].ToString();
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		if (!base.IsPostBack)
		{
			binddata();
		}
	}

	public void binddata()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (DrpField.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				text = " AND tblMS_JobShedule_Master.JobNo='" + TxtSearchValue.Text + "'";
			}
			if (DrpField.SelectedValue == "1" && TxtSearchValue.Text != "")
			{
				text = " AND tblMS_JobShedule_Master.WONo='" + TxtSearchValue.Text + "'";
			}
			if (DrpField.SelectedValue == "2" && TxtSearchValue.Text != "")
			{
				text = " AND tblDG_Item_Master.ItemCode like '%" + TxtSearchValue.Text + "%'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("tblMS_JobShedule_Master.Id,tblMS_JobShedule_Master.SessionId,tblMS_JobShedule_Master.JobNo,tblMS_JobShedule_Master.ItemId,tblMS_JobShedule_Master.SysDate,tblMS_JobShedule_Master.FinYearId,tblMS_JobShedule_Master.WONo,tblDG_Item_Master.ItemCode", "tblMS_JobShedule_Master,tblDG_Item_Master", " tblMS_JobShedule_Master.CompId='" + CompId + "'And tblMS_JobShedule_Master.ItemId=tblDG_Item_Master.Id And tblMS_JobShedule_Master.Id In (select MId from tblMS_JobCompletion)And tblMS_JobShedule_Master.FinYearId<='" + FinYearId + "'" + text + " Order by tblMS_JobShedule_Master.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("JobNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet.Tables[0].Rows[i]["FinyearId"], "'"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[2] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["JobNo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
					dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string cmdText3 = fun.select("Title+'. '+EmployeeName AS GenBy", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet3.Tables[0].Rows[0]["GenBy"].ToString();
					}
					dataRow[7] = dataSet.Tables[0].Rows[i]["FinyearId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		binddata();
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		binddata();
	}

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblWONo")).Text;
				base.Response.Redirect("schedule_Output_Edit_Details.aspx?id=" + text + "&wono=" + text2 + "&ModId=15&SubModId=70");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}

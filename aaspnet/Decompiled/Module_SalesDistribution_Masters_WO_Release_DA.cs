using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_WO_Release_DA : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button btnsubmit;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		string connectionString = fun.Connection();
		con = new SqlConnection(connectionString);
		try
		{
			if (base.IsPostBack)
			{
				return;
			}
			fillGrid();
			foreach (GridViewRow row in GridView2.Rows)
			{
				con.Open();
				string text = ((Label)row.FindControl("EmpNo")).Text;
				string cmdText = fun.select("WR,DA", "tblHR_OfficeStaff", "CompId='" + CompId + "' And ResignationDate='' AND EmployeeName!='ERP' AND EmpId='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows[0]["WR"].ToString() == "1")
				{
					((CheckBox)row.FindControl("chkrelease")).Checked = true;
				}
				else
				{
					((CheckBox)row.FindControl("chkrelease")).Checked = false;
				}
				if (dataSet.Tables[0].Rows[0]["DA"].ToString() == "1")
				{
					((CheckBox)row.FindControl("chkdispatch")).Checked = true;
				}
				else
				{
					((CheckBox)row.FindControl("chkdispatch")).Checked = false;
				}
				con.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid()
	{
		con.Open();
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("EmpId,Title,EmployeeName,Department,WR,DA", "tblHR_OfficeStaff", "CompId='" + CompId + "' And ResignationDate='' AND EmployeeName!='ERP' And UserID !='1'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("EmpName", typeof(string));
			dataTable.Columns.Add("Dept", typeof(string));
			dataTable.Columns.Add("EmpNo", typeof(string));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Title"].ToString() + "." + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
					string cmdText2 = fun.select("Symbol", "tblHR_Departments", "Id='" + dataSet.Tables[0].Rows[i]["Department"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[1] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["EmpId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillGrid();
	}

	protected void btnsubmit_Click(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("EmpNo")).Text;
				string text2 = ((!((CheckBox)row.FindControl("chkrelease")).Checked) ? "0" : "1");
				string text3 = ((!((CheckBox)row.FindControl("chkdispatch")).Checked) ? "0" : "1");
				string cmdText = fun.update("tblHR_OfficeStaff", "WR='" + text2 + "',DA='" + text3 + "'", "CompId='" + CompId + "' AND EmpId='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Print_Details : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected Label lblProjectTitle;

	protected Label lblCustName;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int WOId;

	private string WONo = "";

	private string connStr = string.Empty;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WOId"]))
			{
				WOId = Convert.ToInt32(base.Request.QueryString["WOId"].ToString());
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			lblWono.Text = WONo;
			string cmdText = fun.select("TaskProjectTitle,CustomerId", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND Id='" + WOId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblProjectTitle.Text = dataSet.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
				string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[0]["CustomerId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					lblCustName.Text = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString() + " [ " + dataSet2.Tables[0].Rows[0]["CustomerId"].ToString() + " ]";
				}
			}
			if (!Page.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string cmdText = fun.select("*", "tblPM_MaterialCreditNote_Master", "tblPM_MaterialCreditNote_Master.WONo='" + WONo + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MCNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MCNDate", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["MCNNo"].ToString();
				dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loaddata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Print")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("MaterialCreditNote_MCN_Print_Report.aspx?Id=" + num + "&WONo=" + WONo + "&WoId=" + WOId + "&Key=" + randomAlphaNumeric + "&ModId=7&SubModId=127");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_Print.aspx?ModId=7&SubModId=127");
	}
}

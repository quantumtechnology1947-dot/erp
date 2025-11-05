using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_SubCategoryDelete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			lblMessage.Text = "";
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				int num = Convert.ToInt32(((Label)row.FindControl("LblCId")).Text);
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblSCId")).Text);
				string cmdText = "SELECT SD_Cust_WorkOrder_Master.SCId FROM  SD_Cust_WorkOrder_Master where  SD_Cust_WorkOrder_Master.CompId='" + CompId + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' And SD_Cust_WorkOrder_Master.CId='" + num + "' And SD_Cust_WorkOrder_Master.SCId='" + num2 + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LinkButton linkButton2 = (LinkButton)row.Cells[1].Controls[0];
					linkButton2.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

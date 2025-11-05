using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_CategoryDelete : Page, IRequiresSessionState
{
	private int compid;

	private int finyrsid;

	private string sessionid = "";

	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		compid = Convert.ToInt32(Session["compid"].ToString());
		finyrsid = Convert.ToInt32(Session["finyear"].ToString());
		sessionid = Session["username"].ToString();
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("Label1")).Text);
				string cmdText = "SELECT SD_Cust_WorkOrder_Master.CId FROM  SD_Cust_WorkOrder_Master where  SD_Cust_WorkOrder_Master.CompId='" + compid + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finyrsid + "' And SD_Cust_WorkOrder_Master.CId='" + num + "'";
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

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
	}
}

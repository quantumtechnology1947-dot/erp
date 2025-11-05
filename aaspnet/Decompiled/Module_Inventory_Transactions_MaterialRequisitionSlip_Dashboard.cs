using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using ASP;

public class Module_Inventory_Transactions_MaterialRequisitionSlip_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.delete("tblinv_MaterialRequisition_Temp", "CompId='" + CompId + "'And SessionId='" + sId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}
}

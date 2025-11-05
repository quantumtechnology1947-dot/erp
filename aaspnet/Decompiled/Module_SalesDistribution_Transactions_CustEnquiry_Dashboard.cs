using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using ASP;

public class Module_SalesDistribution_Transactions_CustEnquiry_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			int num = Convert.ToInt32(Session["compid"]);
			string text = Session["username"].ToString();
			int num2 = Convert.ToInt32(Session["finyear"]);
			string cmdText = fun.delete("tblFile_Attachment", "CompId ='" + num + "' AND FinYearId ='" + num2 + "' AND SessionId = '" + text + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}
}

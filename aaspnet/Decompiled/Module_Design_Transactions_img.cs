using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;

public class Module_Design_Transactions_img : Page, IRequiresSessionState
{
	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string cmdText = "select Image from tblDG_Item_Master where Id=60";
		SqlCommand sqlCommand = new SqlCommand(cmdText);
		new SqlDataAdapter(sqlCommand);
		DataTable data = GetData(sqlCommand);
		if (data != null)
		{
			byte[] buffer = (byte[])data.Rows[0]["Image"];
			base.Response.Buffer = true;
			base.Response.Charset = "";
			base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			base.Response.BinaryWrite(buffer);
			base.Response.Flush();
			base.Response.End();
		}
	}

	private DataTable GetData(SqlCommand cmd)
	{
		DataTable dataTable = new DataTable();
		string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		cmd.CommandType = CommandType.Text;
		cmd.Connection = sqlConnection;
		try
		{
			sqlConnection.Open();
			sqlDataAdapter.SelectCommand = cmd;
			sqlDataAdapter.Fill(dataTable);
			return dataTable;
		}
		catch
		{
			return null;
		}
		finally
		{
			sqlConnection.Close();
			sqlDataAdapter.Dispose();
			sqlConnection.Dispose();
		}
	}
}

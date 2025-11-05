using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_NewsandNotices_Edit : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		int num = Convert.ToInt32(Session["compid"]);
		Convert.ToInt32(Session["finyear"]);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("Id, Title, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(FromDate, CHARINDEX('-', FromDate) + 1, 2) + '-' + LEFT (FromDate, CHARINDEX('-', FromDate) - 1) + '-' + RIGHT (FromDate, CHARINDEX('-', REVERSE(FromDate)) - 1)), 103), '/', '-') AS FromDate, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(ToDate, CHARINDEX('-', ToDate) + 1, 2) + '-' + LEFT (ToDate, CHARINDEX('-', ToDate) - 1) + '-' + RIGHT (ToDate, CHARINDEX('-', REVERSE(ToDate)) - 1)), 103), '/', '-') AS ToDate, FileName ,FinYearId", "tblHR_News_Notices", "CompId='" + num + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblHR_MobileBill");
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Title", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FinYearId"]);
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num2 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["Title"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["FromDate"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["ToDate"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["FileName"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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

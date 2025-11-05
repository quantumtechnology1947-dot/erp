using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FyId;

	protected GridView GridView2;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				FillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select1("Id,Name", "tblACC_Bank order by OrdNo Asc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Trans", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ClAmt", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Name"].ToString();
				if (dataSet.Tables[0].Rows[i]["Name"].ToString() == "Cash")
				{
					dataRow[2] = fun.getCashOpBalAmt("<", fun.getCurrDate(), CompId, FyId).ToString();
					dataRow[3] = fun.getCashClBalAmt("=", fun.getCurrDate(), CompId, FyId).ToString();
				}
				else
				{
					dataRow[2] = fun.getBankOpBalAmt("<", fun.getCurrDate(), CompId, FyId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"])).ToString();
					dataRow[3] = fun.getBankClBalAmt("=", fun.getCurrDate(), CompId, FyId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"])).ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}
}

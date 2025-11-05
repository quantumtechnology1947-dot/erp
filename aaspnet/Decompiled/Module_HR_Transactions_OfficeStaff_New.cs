using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_OfficeStaff_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected Label lblmsg;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblmsg.Text = "";
			if (base.Request.QueryString["msg"] != null)
			{
				lblmsg.Text = base.Request.QueryString["msg"].ToString();
			}
			FillDatagrid();
		}
		catch (Exception)
		{
		}
	}

	public void FillDatagrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand("SELECT OfferId,EmployeeName,StaffType FROM [tblHR_Offer_Master] Where OfferId not in (select OfferId from [tblHR_OfficeStaff]) Order By OfferId Desc", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("OfferId", typeof(int));
			dataTable.Columns.Add("EmployeeName", typeof(string));
			dataTable.Columns.Add("StaffType", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["OfferId"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
				if (dataSet.Tables[0].Rows[i]["StaffType"].ToString() == "1")
				{
					dataRow[2] = "Office Staff";
				}
				else
				{
					dataRow[2] = "Contract Staff";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillDatagrid();
	}
}

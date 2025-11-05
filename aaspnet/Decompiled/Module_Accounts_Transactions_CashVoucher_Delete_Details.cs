using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_CashVoucher_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private int id;

	private string str = "";

	private SqlConnection con;

	private double tamt;

	protected GridView GridView1;

	protected Button btncancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		str = fun.Connection();
		con = new SqlConnection(str);
		id = Convert.ToInt32(base.Request.QueryString["Id"]);
		if (!base.IsPostBack)
		{
			FillData();
		}
		((Label)GridView1.FooterRow.FindControl("LblTotalAmt")).Text = "Total - " + tamt;
	}

	public void FillData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			string cmdText = fun.select("*", "tblACC_CashVoucher_Payment_Details", "MId='" + id + "'  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
				dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
				if (dataSet.Tables[0].Rows[i]["PONo"] != DBNull.Value)
				{
					dataRow[3] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["PODate"].ToString());
				}
				dataRow[5] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
				if (dataSet.Tables[0].Rows[i]["WONo"] != DBNull.Value)
				{
					dataRow[6] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				}
				if (dataSet.Tables[0].Rows[i]["BGGroup"] != DBNull.Value)
				{
					string cmdText2 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["BGGroup"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet2.Tables[0].Rows[0]["Dept"].ToString();
					}
				}
				string cmdText3 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["AcHead"]) + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[8] = dataSet3.Tables[0].Rows[0]["Head"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				tamt += Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
				dataRow[10] = dataSet.Tables[0].Rows[i]["BudgetCode"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				con.Open();
				string cmdText = fun.delete("tblACC_CashVoucher_Payment_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("Id", "tblACC_CashVoucher_Payment_Details", "MId='" + id + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblACC_CashVoucher_Payment_Master", "  Id='" + id + "' AND CompId='" + CompId + "' ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("CashVoucher_Delete.aspx?ModId=11&SubModId=113");
				}
				con.Close();
				FillData();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillData();
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CashVoucher_Delete.aspx?ModId=11&SubModId=113");
	}
}

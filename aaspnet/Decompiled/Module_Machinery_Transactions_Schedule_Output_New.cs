using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_Output_New : Page, IRequiresSessionState
{
	protected DropDownList DrpWONO;

	protected Label lblCustomer;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int FinYearId;

	private string WONO = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string cmdText = "delete tblMS_JobCompletion_Temp";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			if (!base.IsPostBack)
			{
				string cmdText2 = fun.select("EnqId,CustomerId,WONo,PONo,POId", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'Order by Id Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DrpWONO.DataSource = dataSet.Tables[0];
					DrpWONO.DataTextField = "WONo";
					DrpWONO.DataValueField = "WONo";
					DrpWONO.DataBind();
					DrpWONO.Items.Insert(0, "Select");
				}
				else
				{
					DrpWONO.Items.Insert(0, "Select");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpWONO_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!(DrpWONO.SelectedItem.Text != "Select"))
		{
			return;
		}
		WONO = DrpWONO.SelectedValue;
		string cmdText = fun.select("CustomerId", "SD_Cust_WorkOrder_Master", " WONo='" + WONO + "'And FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'Order by Id Desc");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			string cmdText2 = fun.select("CustomerName", "SD_Cust_master", " CustomerId='" + dataSet.Tables[0].Rows[0][0].ToString() + "'And FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblCustomer.Text = dataSet2.Tables[0].Rows[0][0].ToString();
			}
		}
		fillgrid();
	}

	public void fillgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(Session["compid"]);
		List<int> list = new List<int>();
		list = fun.TreeAssembly(WONO, num);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
		dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
		dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
		for (int i = 0; i < list.Count; i++)
		{
			if (list.Count > 0)
			{
				string cmdText = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.ItemId in (select ItemId from tblMS_JobShedule_Master where Id in (select MId from tblMS_JobSchedule_Details)) and tblDG_BOM_Master.WONo='" + WONO + "'and  tblDG_BOM_Master.Id='" + Convert.ToInt32(list[i]) + "' And tblDG_BOM_Master.CompId='" + num + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]);
					dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					dataRow[4] = fun.BOMRecurQty(WONO, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]), 1.0, num, FinYearId);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
		}
		GridView2.DataSource = dataTable;
		GridView2.DataBind();
		sqlConnection.Close();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "move")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string selectedValue = DrpWONO.SelectedValue;
				string text = ((Label)gridViewRow.FindControl("lblItemId")).Text;
				if (text != "")
				{
					base.Response.Redirect("Schedule_Output_New_Details.aspx?WONo=" + selectedValue + "&Item=" + text + "&ModId=15&SubModId=70");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string WONo = "";

	private int FinYearId;

	private string SId = "";

	protected Label lblWoNo;

	protected GridView GridView2;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			int num = Convert.ToInt32(Session["compid"]);
			lblWoNo.Text = WONo;
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				fillgrid();
			}
			string cmdText = fun.delete("tblMS_JobSchedule_Details_Temp", "CompId='" + num + "' AND SessionId='" + SId + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(Session["compid"]);
		List<int> list = new List<int>();
		list = fun.TreeAssembly(WONo, num);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
		dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
		dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
		dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
		for (int i = 0; i < list.Count; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			string cmdText = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.Id,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_BOM_Master.Id='" + list[i] + "' and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + WONo + "'  And tblDG_BOM_Master.CompId='" + num + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'Order By tblDG_BOM_Master.PId ASC ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]);
				dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
				dataRow[4] = fun.BOMRecurQty(WONo, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]), 1.0, num, FinYearId);
				dataRow[5] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
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
				int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpType")).SelectedValue);
				string text = ((Label)gridViewRow.FindControl("lblItemId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				if (text != "" && num == 0)
				{
					base.Response.Redirect("Schedule_New_Items.aspx?WONo=" + WONo + "&Item=" + text + "&Type=" + num + "&ModId=15&SubModId=69");
				}
				else if (text != "" && text2 != "" && num == 1)
				{
					base.Response.Redirect("Schedule_New_Items_BySplit.aspx?WONo=" + WONo + "&Item=" + text + "&Type=" + num + "&Id=" + text2 + "&ModId=15&SubModId=69");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Schedule_New.aspx?&ModId=15&SubModId=69");
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillgrid();
	}
}

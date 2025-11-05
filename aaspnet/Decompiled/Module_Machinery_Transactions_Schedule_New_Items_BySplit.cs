using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_New_Items_BySplit : Page, IRequiresSessionState
{
	protected Label lblWoNo;

	protected GridView GridView2;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int Id;

	private string SId = "";

	private int itemId;

	private string WONo = "";

	private int FinYearId;

	private string Type = "";

	private List<int> componantBySplit = new List<int>();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Type"]))
			{
				Type = base.Request.QueryString["Type"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Item"]))
			{
				itemId = Convert.ToInt32(base.Request.QueryString["Item"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Id"]))
			{
				Id = Convert.ToInt32(base.Request.QueryString["Id"]);
			}
			CompId = Convert.ToInt32(Session["compid"]);
			lblWoNo.Text = WONo;
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				fillgrid();
			}
			string cmdText = fun.delete("tblMS_JobSchedule_Details_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		con.Open();
		int num = Convert.ToInt32(Session["compid"]);
		List<int> list = new List<int>();
		list = TreeComponantBySplit(WONo, num, Id);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
		dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
		dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
		dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
		for (int i = 0; i < list.Count; i++)
		{
			if (list.Count <= 0)
			{
				continue;
			}
			string cmdText = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.Id,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + WONo + "' and  tblDG_BOM_Master.Id='" + Convert.ToInt32(list[i]) + "' And tblDG_BOM_Master.CompId='" + num + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'And tblDG_BOM_Master.CId Not In(Select tblDG_BOM_Master.PId from tblDG_BOM_Master where tblDG_BOM_Master.WONo='" + WONo + "'And tblDG_BOM_Master.CompId='" + num + "'Group By tblDG_BOM_Master.PId) ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
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
				List<double> list2 = new List<double>();
				list2 = fun.BOMTreeQty(WONo, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]));
				double num2 = 1.0;
				for (int j = 0; j < list2.Count; j++)
				{
					num2 *= list2[j];
				}
				dataRow[4] = num2;
				dataRow[5] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
		}
		GridView2.DataSource = dataTable;
		GridView2.DataBind();
		con.Close();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "move")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(Type);
				string text = ((Label)gridViewRow.FindControl("lblItemId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				if (text != "" && num == 1)
				{
					base.Response.Redirect("Schedule_New_Items.aspx?WONo=" + WONo + "&Item=" + text + "&Type=" + num + "&Id=" + text2 + "&ModId=15&SubModId=69");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Schedule_New_Details.aspx?WONo=" + WONo + "&ModId=15&SubModId=69");
	}

	public List<int> TreeComponantBySplit(string wono, int Compid, int Id)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			string cmdText = fun.select("CId", "tblDG_BOM_Master", "WONo='" + wono + "' And Id='" + Id + "'And CompId='" + Compid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = fun.select("Id", "tblDG_BOM_Master", " WONo='" + wono + "' And CompId='" + Compid + "' And PId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
					for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
					{
						componantBySplit.Add(Convert.ToInt32(dataSet2.Tables[0].Rows[j]["Id"]));
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return componantBySplit;
	}
}

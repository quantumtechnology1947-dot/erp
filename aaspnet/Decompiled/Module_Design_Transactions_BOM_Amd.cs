using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_BOM_Amd : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string WONo = "";

	private string ItemId = "";

	private string BOMId = "";

	protected Label lblWONo;

	protected GridView GridView2;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			ItemId = base.Request.QueryString["ItemId"].ToString();
			WONo = base.Request.QueryString["WONo"].ToString();
			BOMId = base.Request.QueryString["Id"].ToString();
			lblWONo.Text = WONo;
			if (!base.IsPostBack)
			{
				BindDataCust();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void BindDataCust()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			string cmdText = fun.select("*", "tblDG_BOM_Amd", "FinYearId<='" + FinYearId + "' And CompId='" + CompId + "' And BOMId='" + BOMId + "' And WONo='" + WONo + "' And ItemId='" + ItemId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("AmdBy", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = fun.select("ItemCode,UOMBasic,ManfDesc", "tblDG_Item_Master", " FinYearId<='" + FinYearId + "'AND CompId='" + CompId + "'  AND  Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					if (dataSet.Tables[0].Rows[i]["Description"].ToString() != string.Empty)
					{
						dataRow[5] = dataSet.Tables[0].Rows[i]["Description"].ToString();
					}
					else
					{
						dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					if (dataSet.Tables[0].Rows[i]["UOM"].ToString() != string.Empty)
					{
						string cmdText3 = fun.select("Symbol", "Unit_Master", "  Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
						}
					}
					else
					{
						string cmdText4 = fun.select("Symbol", "Unit_Master", "  Id='" + dataSet.Tables[0].Rows[i]["UOM"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[6] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
						}
					}
				}
				string cmdText5 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("FinYearId<='", FinYearId, "'And CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[0] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[1] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["AmdNo"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[9] = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.EditIndex = e.NewPageIndex;
		BindDataCust();
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + WONo + "&ModId=3&SubModId=26");
	}
}

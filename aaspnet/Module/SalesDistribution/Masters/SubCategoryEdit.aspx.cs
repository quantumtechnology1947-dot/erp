using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_SubCategoryEdit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				lblMessage.Text = "";
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("tblSD_WO_SubCategory.SCId,tblSD_WO_SubCategory.CId,tblSD_WO_SubCategory.SCName,tblSD_WO_SubCategory.Symbol,tblSD_WO_Category.Symbol AS CSymbol,tblSD_WO_Category.CName ", "tblSD_WO_SubCategory,tblSD_WO_Category", "tblSD_WO_SubCategory.CId= tblSD_WO_Category.CId And tblSD_WO_SubCategory.CompId='" + CompId + "' AND tblSD_WO_SubCategory.FinYearId<='" + FinYearId + "' Order By SCId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("CatName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SCName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SCId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["CSymbol"].ToString() + "-" + dataSet.Tables[0].Rows[i]["CName"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["SCName"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[3] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["SCId"]);
				dataRow[4] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]);
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			loaddata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			loaddata();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			string text = ((Label)gridViewRow.FindControl("lblCId2")).Text;
			((DropDownList)gridViewRow.FindControl("DrpCategory")).SelectedValue = text;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblSCId0")).Text);
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpCategory")).SelectedValue);
			string text = ((TextBox)gridViewRow.FindControl("TextBox1")).Text;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = "SELECT SD_Cust_WorkOrder_Master.SCId FROM  SD_Cust_WorkOrder_Master where  SD_Cust_WorkOrder_Master.CompId='" + CompId + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' And SD_Cust_WorkOrder_Master.CId='" + num2 + "' And SD_Cust_WorkOrder_Master.SCId='" + num + "' ";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				SqlCommand sqlCommand = new SqlCommand(fun.update("tblSD_WO_SubCategory", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + SId + "' ,CId='" + num2 + "',SCName='" + text + "'", " SCId='" + num + "'  And  CompId='" + CompId + "'"), sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				GridView1.EditIndex = -1;
				loaddata();
			}
			else
			{
				string empty = string.Empty;
				empty = "You canot edit this record,it is being used.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			GridView1.EditIndex = -1;
			loaddata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record updated sucessfully.";
	}
}

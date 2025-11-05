using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_CategoryEdit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sysdate = "";

	private string systime = "";

	private string compid = "";

	private string finyrsid = "";

	private string sessionid = "";

	protected GridView GridView1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
			sysdate = fun.getCurrDate();
			systime = fun.getCurrTime();
			compid = Session["compid"].ToString();
			finyrsid = Session["finyear"].ToString();
			sessionid = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				fillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("HasSubCat", typeof(string)));
			string cmdText = fun.select("*", "tblSD_WO_Category", "CompId='" + compid + "' AND FinYearId<='" + finyrsid + "' Order by CId desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"].ToString());
				dataRow[1] = dataSet.Tables[0].Rows[i]["CName"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				if (dataSet.Tables[0].Rows[i]["HasSubCat"].ToString() == "1")
				{
					dataRow[3] = "Yes";
				}
				else
				{
					dataRow[3] = "No";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
		}
		foreach (GridViewRow row in GridView1.Rows)
		{
			int num = Convert.ToInt32(((Label)row.FindControl("Label1")).Text);
			string cmdText = "SELECT SD_Cust_WorkOrder_Master.CId FROM  SD_Cust_WorkOrder_Master where  SD_Cust_WorkOrder_Master.CompId='" + compid + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finyrsid + "' And SD_Cust_WorkOrder_Master.CId='" + num + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				LinkButton linkButton2 = (LinkButton)row.Cells[1].Controls[0];
				linkButton2.Visible = false;
			}
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated.";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (!(e.CommandName == "Update"))
		{
			return;
		}
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string text = "";
			int index = Convert.ToInt32(e.CommandArgument);
			GridViewRow gridViewRow = GridView1.Rows[index];
			string text2 = ((TextBox)gridViewRow.FindControl("txtCate")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblsubcatNo")).Text;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblCid")).Text);
			text = ((!((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked) ? "0" : "1");
			int num2 = 0;
			if (text3 == "Yes")
			{
				string cmdText = "SELECT  tblSD_WO_SubCategory.SCId FROM tblSD_WO_SubCategory INNER JOIN tblSD_WO_Category ON tblSD_WO_SubCategory.CId = tblSD_WO_Category.CId And tblSD_WO_Category.CId='" + num + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				num2 = dataSet.Tables[0].Rows.Count;
			}
			if (num2 == 0)
			{
				string cmdText2 = fun.update("tblSD_WO_Category", " CName='" + text2 + "',HasSubCat='" + text + "'", "CId = '" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(base.Request.Url.ToString(), endResponse: true);
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

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			fillGrid();
			int index = Convert.ToInt32(GridView1.EditIndex);
			GridViewRow gridViewRow = GridView1.Rows[index];
			if (((Label)gridViewRow.FindControl("lblsubcatNo")).Text == "Yes")
			{
				((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		fillGrid();
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		fillGrid();
	}
}

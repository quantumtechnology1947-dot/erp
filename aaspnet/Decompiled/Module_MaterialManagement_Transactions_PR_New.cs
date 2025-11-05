using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PR_New : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox TxtWONo;

	protected DropDownList DDLTaskWOType;

	protected Button Button1;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FyId;

	private string w = "";

	private int h;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			string cmdText = fun.delete("tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			if (!base.IsPostBack)
			{
				string cmdText2 = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				con.Close();
				getItemTot(w, h);
			}
		}
		catch (Exception)
		{
		}
	}

	public void getItemTot(string wo, int c)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Release", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Run", typeof(string)));
			string text = "";
			if (TxtWONo.Text != "")
			{
				text = " And WONo='" + TxtWONo.Text + "'";
			}
			string text2 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				text2 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			string cmdText = fun.select("WONo,TaskProjectTitle,ReleaseWIS,DryActualRun", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND CloseOpen='0'" + text + text2 + " Order by WONo");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["TaskProjectTitle"].ToString();
				if (dataSet.Tables[0].Rows[i]["ReleaseWIS"].ToString() == "1")
				{
					dataRow[2] = "Released";
				}
				else if (dataSet.Tables[0].Rows[i]["DryActualRun"].ToString() == "1")
				{
					dataRow[2] = "Stop";
				}
				else
				{
					dataRow[2] = "Not Release";
				}
				if (dataSet.Tables[0].Rows[i]["DryActualRun"].ToString() == "1")
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
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((Label)row.FindControl("lblrun")).Text == "No")
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
				}
				else if (((Label)row.FindControl("lblrel")).Text == "Released")
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = true;
				}
				else
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
				}
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Select")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = "";
			text = ((Label)gridViewRow.FindControl("lblwono")).Text;
			base.Response.Redirect("~/Module/MaterialManagement/Transactions/PR_New_Details.aspx?WONo=" + text + "&ModId=6&SubModId=34");
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			getItemTot(w, c);
		}
		else
		{
			getItemTot(w, h);
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		getItemTot(TxtWONo.Text, h);
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((Label)row.FindControl("lblrun")).Text == "No")
			{
				((LinkButton)row.FindControl("LinkButton1")).Visible = false;
			}
			else if (((Label)row.FindControl("lblrel")).Text == "Released")
			{
				((LinkButton)row.FindControl("LinkButton1")).Visible = true;
			}
			else
			{
				((LinkButton)row.FindControl("LinkButton1")).Visible = false;
			}
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		getItemTot(w, h);
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_ReleaseWIS : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string Wo = "";

	private int h;

	protected DropDownList DrpWOType;

	protected TextBox TxtWONo;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DrpWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DrpWOType.DataTextField = "Category";
				DrpWOType.DataValueField = "CId";
				DrpWOType.DataBind();
				DrpWOType.Items.Insert(0, "WO Category");
				loadgrid(Wo, h);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid(string WO, int C)
	{
		try
		{
			con.Open();
			string text = "";
			if (TxtWONo.Text != "")
			{
				text = " AND WONo='" + WO + "'";
			}
			string text2 = "";
			if (DrpWOType.SelectedValue != "WO Category")
			{
				text2 = " AND CId='" + Convert.ToInt32(DrpWOType.SelectedValue) + "'";
			}
			SqlCommand sqlCommand = new SqlCommand(fun.select("Id,SysDate ,WONo,TaskProjectTitle,ReleaseWIS", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND CloseOpen='0' " + text2 + text + "  Order by WONo ASC"), con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PrjTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleaseWIS", typeof(string)));
			dataTable.Columns.Add(new DataColumn("counts", typeof(int)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[2] = sqlDataReader["WONo"].ToString();
				dataRow[3] = sqlDataReader["TaskProjectTitle"].ToString();
				SqlCommand selectCommand = new SqlCommand(fun.select("ReleaseSysDate,ReleaseSysTime,ReleaseBy", "tblInv_WORelease_WIS", "CompId='" + CompId + "' AND WONo='" + sqlDataReader["WONo"].ToString() + "' Order by Id Desc"), con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ReleaseSysDate"].ToString());
					dataRow[5] = dataSet.Tables[0].Rows[0]["ReleaseSysTime"].ToString();
					if (dataSet.Tables[0].Rows[0]["ReleaseBy"] != DBNull.Value)
					{
						string cmdText = fun.select("tblHR_OfficeStaff.Title+'. '+tblHR_OfficeStaff.EmployeeName AS GenBy", "tblHR_OfficeStaff", "tblHR_OfficeStaff.EmpId='" + dataSet.Tables[0].Rows[0]["ReleaseBy"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							dataRow[6] = dataSet2.Tables[0].Rows[0]["GenBy"].ToString();
						}
					}
				}
				dataRow[7] = sqlDataReader["ReleaseWIS"].ToString();
				string cmdText2 = fun.select("Count(WONo) As counts", "tblInv_WORelease_WIS", "WONo='" + sqlDataReader["WONo"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["counts"]);
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				_ = ((Label)row.FindControl("lblId")).Text;
				string text3 = ((Label)row.FindControl("lblrelwis")).Text;
				if (text3 != "0")
				{
					((Button)row.FindControl("btnstop")).Visible = true;
					((Button)row.FindControl("btnRelease")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string text = "";
		string text2 = "";
		con.Open();
		try
		{
			if (e.CommandName == "add")
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				text = ((Label)gridViewRow.FindControl("lblId")).Text;
				text2 = ((Label)gridViewRow.FindControl("lblwono")).Text;
				SqlCommand sqlCommand = new SqlCommand(fun.update("SD_Cust_WorkOrder_Master", "ReleaseWIS='1'", "CompId='" + CompId + "' AND Id='" + text + "'"), con);
				sqlCommand.ExecuteNonQuery();
				SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblInv_WORelease_WIS", "CompId,FinYearId,WONo,ReleaseSysDate,ReleaseSysTime,ReleaseBy", "'" + CompId + "','" + FinYearId + "','" + text2 + "','" + CDate + "','" + CTime + "','" + SId + "'"), con);
				sqlCommand2.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "stp")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				text = ((Label)gridViewRow2.FindControl("lblId")).Text;
				SqlCommand sqlCommand3 = new SqlCommand(fun.update("SD_Cust_WorkOrder_Master", "ReleaseWIS='0'", "CompId='" + CompId + "' AND Id='" + text + "'"), con);
				sqlCommand3.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow3 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				text2 = ((Label)gridViewRow3.FindControl("lblwono")).Text;
				base.Response.Redirect("ReleaseWIS_Details.aspx?wn=" + text2 + "&cid=" + CompId);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		loadgrid(Wo, h);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loadgrid(TxtWONo.Text, h);
	}

	protected void DrpWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DrpWOType.SelectedValue);
			loadgrid(Wo, c);
		}
		else
		{
			loadgrid(Wo, h);
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_CategoryNew : Page, IRequiresSessionState
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtCName")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtAbb")).Text;
				string text3 = "";
				if (text != "" && text2 != "")
				{
					text3 = ((!((CheckBox)GridView1.FooterRow.FindControl("CheckBox1")).Checked) ? "0" : "1");
					string cmdText = fun.select("Symbol", "tblSD_WO_Category", "CompId='" + compid + "' And Symbol='" + text2 + "' AND FinYearId<='" + finyrsid + "' Order by CId desc");
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						string cmdText2 = fun.insert("tblSD_WO_Category", "SysDate,SysTime,CompId,FinYearId,SessionId,CName, Symbol,HasSubCat", "'" + sysdate + "','" + systime + "','" + compid + "','" + finyrsid + "','" + sessionid + "','" + text + "','" + text2.ToUpper() + "','" + text3 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
						sqlConnection.Open();
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
						Page.Response.Redirect(base.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Category symbol is already used.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string text4 = "";
			string text5 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCName")).Text;
			string text6 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbb")).Text;
			if (text5 != "" && text6 != "")
			{
				text4 = ((!((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox1")).Checked) ? "0" : "1");
				string cmdText3 = fun.select("Symbol", "tblSD_WO_Category", "CompId='" + compid + "' And Symbol='" + text6 + "' AND FinYearId<='" + finyrsid + "' Order by CId desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					string cmdText4 = fun.insert("tblSD_WO_Category", "SysDate,SysTime,CompId,FinYearId,SessionId,CName, Symbol,HasSubCat", "'" + sysdate + "','" + systime + "','" + compid + "','" + finyrsid + "','" + sessionid + "','" + text5 + "','" + text6.ToUpper() + "','" + text4 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
					sqlConnection.Open();
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(base.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Category symbol is already used.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillGrid();
	}
}

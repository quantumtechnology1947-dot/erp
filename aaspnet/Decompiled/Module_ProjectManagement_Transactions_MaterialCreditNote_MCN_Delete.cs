using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Delete : Page, IRequiresSessionState
{
	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected Button Button1;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	private string sid = "";

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sid = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			new DataSet();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string text = "";
			if (drpfield.SelectedValue == "0" && txtSupplier.Text != "")
			{
				string code = fun.getCode(txtSupplier.Text);
				text = " AND CustomerId='" + code + "'";
			}
			string text2 = "";
			if (drpfield.SelectedValue == "1" && txtPONo.Text != "")
			{
				text2 = " AND WONo='" + txtPONo.Text + "'";
			}
			if (drpfield.SelectedValue == "2" && txtPONo.Text != "")
			{
				text2 = " AND TaskProjectTitle Like '%" + txtPONo.Text + "%'";
			}
			string cmdText = fun.select("*", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND CloseOpen='0'" + text + text2 + " Order by WONo ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("WOId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["TaskProjectTitle"].ToString();
				string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString();
					dataRow[4] = dataSet2.Tables[0].Rows[0]["CustomerId"].ToString();
				}
				dataRow[5] = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
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

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0")
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loaddata();
			}
			if (drpfield.SelectedValue == "1" || drpfield.SelectedValue == "2")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loaddata();
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		loaddata();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblWOId")).Text;
			string text2 = ((LinkButton)gridViewRow.FindControl("lbtnWONo")).Text;
			base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_Delete_Details.aspx?WOId=" + text + "&WONo=" + text2 + "&ModId=7&SubModId=127");
		}
	}
}

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

public class Module_Accounts_Transactions_SalesInvoice_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId = "";

	private string WN = "";

	protected DropDownList DropDownList1;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected GridView GridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		try
		{
			if (!Page.IsPostBack)
			{
				txtpoNo.Visible = false;
				bindgrid(CId, WN);
			}
		}
		catch (Exception)
		{
		}
	}

	public void bindgrid(string Cid, string wn)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		try
		{
			sqlConnection.Open();
			if (DropDownList1.SelectedValue == "Select")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
			}
			string text = "";
			if (DropDownList1.SelectedValue == "0" && txtCustName.Text != "")
			{
				string code = fun.getCode(txtCustName.Text);
				text = " AND CustomerCode='" + code + "'";
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "2" && txtpoNo.Text != "")
			{
				text2 = " AND PONo='" + txtpoNo.Text + "'";
			}
			string text3 = "";
			if (DropDownList1.SelectedValue == "3" && txtpoNo.Text != "")
			{
				text3 = " AND InvoiceNo='" + txtpoNo.Text + "'";
			}
			string cmdText = fun.select("Id,FinYearId,SysDate,InvoiceNo,WONo,PONo,CustomerCode", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'" + text + text2 + text3 + " Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InVoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string cmdText3 = fun.select("CustomerName,CustomerId", "SD_Cust_master", string.Concat("CustomerId='", dataSet.Tables[0].Rows[i]["CustomerCode"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow[3] = value;
					dataRow[4] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString() + "[" + dataSet3.Tables[0].Rows[0]["CustomerId"].ToString() + "]";
					WN = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					string[] array = WN.Split(',');
					string text4 = "";
					for (int j = 0; j < array.Length - 1; j++)
					{
						string cmdText4 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[j] + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							text4 = text4 + dataSet4.Tables[0].Rows[0][0].ToString() + ",";
						}
					}
					dataRow[5] = text4;
					dataRow[6] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[7] = dataSet3.Tables[0].Rows[0]["CustomerId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			try
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblInVoiceNo")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblCustId")).Text;
				base.Response.Redirect("SalesInvoice_Delete_Details.aspx?InvNo=" + base.Server.UrlEncode(fun.Encrypt(text)) + "&InvId=" + base.Server.UrlEncode(fun.Encrypt(text2)) + "&cid=" + base.Server.UrlEncode(fun.Encrypt(text3)) + "&ModId=11&SubModId=51");
			}
			catch (Exception)
			{
			}
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		bindgrid(CId, WN);
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			bindgrid(txtCustName.Text, txtpoNo.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtpoNo.Visible = false;
				txtCustName.Visible = true;
				txtCustName.Text = "";
				bindgrid(CId, WN);
			}
			if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
				txtpoNo.Text = "";
				bindgrid(CId, WN);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
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
}

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

public class Module_Accounts_Transactions_SalesInvoice_New : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected GridView GridView1;

	protected SqlDataSource Sqltype;

	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId = "";

	private string WN = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
				txtpoNo.Visible = false;
				bindgrid(CId, WN);
				getWONOInDRP();
			}
		}
		catch (Exception)
		{
		}
	}

	public void getWONOInDRP()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		foreach (GridViewRow row in GridView1.Rows)
		{
			ListBox listBox = (ListBox)row.FindControl("ListBox1");
			string text = ((Label)row.FindControl("lblPOId")).Text;
			listBox.SelectionMode = ListSelectionMode.Multiple;
			string cmdText = fun.select("WONo+'-'+TaskProjectTitle As WoProjectTitle,Id", "SD_Cust_WorkOrder_Master", "POId= '" + text + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				listBox.DataSource = dataSet.Tables[0];
				listBox.DataTextField = "WoProjectTitle";
				listBox.DataValueField = "Id";
				listBox.DataBind();
			}
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
			string text = "";
			if (DropDownList1.SelectedValue == "Select")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "1" && txtpoNo.Text != "")
			{
				text2 = " AND SD_Cust_PO_Master.PONO='" + txtpoNo.Text + "'";
			}
			if (DropDownList1.SelectedValue == "0" && txtCustName.Text != "")
			{
				string code = fun.getCode(txtCustName.Text);
				text = " AND SD_Cust_PO_Master.CustomerId='" + code + "'";
			}
			string cmdText = fun.select("SD_Cust_PO_Master.SysDate,SD_Cust_PO_Master.POId,SD_Cust_PO_Master.PONo,SD_Cust_PO_Master.CustomerId,SD_Cust_PO_Master.PODate,SD_Cust_PO_Master.FinYearId", "SD_Cust_PO_Master", "SD_Cust_PO_Master.CompId='" + CompId + "' And SD_Cust_PO_Master.FinYearId<='" + FinYearId + "'" + text2 + " " + text + " Order By POId Desc ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(string)));
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
					string cmdText3 = fun.select("CustomerName,CustomerId", "SD_Cust_master", string.Concat("CustomerId='", dataSet.Tables[0].Rows[i]["CustomerId"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Id", "SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId AND SD_Cust_PO_Master.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND SD_Cust_PO_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					int num = 0;
					for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
					{
						double num2 = 0.0;
						double num3 = 0.0;
						double num4 = 0.0;
						num4 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[j]["TotalQty"].ToString()).ToString("N3"));
						string cmdText5 = fun.select(" Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details,SD_Cust_PO_Master,SD_Cust_PO_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And tblACC_SalesInvoice_Details.ItemId=SD_Cust_PO_Details.Id ANd tblACC_SalesInvoice_Master.POId=SD_Cust_PO_Master.POId  AND tblACC_SalesInvoice_Master.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblACC_SalesInvoice_Details.ItemId='" + dataSet4.Tables[0].Rows[j]["Id"].ToString() + "' Group By tblACC_SalesInvoice_Details.ItemId ");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["ReqQty"] != DBNull.Value)
						{
							num2 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
						}
						num3 = num4 - num2;
						if (num3 > 0.0)
						{
							num++;
						}
					}
					if (num > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
						dataRow[1] = dataSet3.Tables[0].Rows[0]["CustomerName"].ToString() + "[" + dataSet3.Tables[0].Rows[0]["CustomerId"].ToString() + "]";
						dataRow[2] = value;
						dataRow[3] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
						dataRow[4] = dataSet3.Tables[0].Rows[0]["CustomerId"].ToString();
						dataRow[5] = dataSet.Tables[0].Rows[i]["POId"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			getWONOInDRP();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblPONo")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblPOId")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblDate")).Text;
				string text4 = ((Label)gridViewRow.FindControl("hfWOno")).Text;
				int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("drp1")).SelectedValue);
				string text5 = ((Label)gridViewRow.FindControl("lblCustId")).Text;
				if (num != 1 && text4 != "")
				{
					base.Response.Redirect("SalesInvoice_New_Details.aspx?poid=" + base.Server.UrlEncode(fun.Encrypt(text2)) + "&wn=" + base.Server.UrlEncode(fun.Encrypt(text4)) + "&pn=" + base.Server.UrlEncode(fun.Encrypt(text)) + "&date=" + base.Server.UrlEncode(fun.Encrypt(text3)) + "&ty=" + base.Server.UrlEncode(fun.Encrypt(num.ToString())) + "&cid=" + base.Server.UrlEncode(fun.Encrypt(text5)) + "&ModId=11&SubModId=51");
				}
				else
				{
					string empty = string.Empty;
					empty = "Select WONo and Type.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		bindgrid(CId, WN);
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
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select")
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

	[WebMethod]
	[ScriptMethod]
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

	protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		foreach (GridViewRow row in GridView1.Rows)
		{
			ListBox listBox = (ListBox)row.FindControl("ListBox1");
			TextBox textBox = (TextBox)row.FindControl("TxtPF");
			Label label = (Label)row.FindControl("hfWOno");
			string text3 = "";
			for (int i = 0; i < listBox.Items.Count; i++)
			{
				if (!listBox.Items[i].Selected)
				{
					continue;
				}
				text = listBox.Items[i].Text;
				string[] array = text.Split('-');
				for (int j = 0; j < array.Length; j++)
				{
					if (j % 2 == 0)
					{
						text3 = text3 + array[j] + ",";
					}
				}
				text2 = text2 + listBox.Items[i].Value + ",";
			}
			textBox.Text = text3;
			label.Text = text2;
		}
	}
}

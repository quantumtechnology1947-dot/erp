using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_ProformaInvoice_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string InvId = "";

	private string CCode = "";

	private string InvNo = "";

	protected GridView GridView1;

	protected Panel Panel2;

	protected Panel Panel1;

	protected Button Btngoods;

	protected Button ButtonCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		InvId = fun.Decrypt(base.Request.QueryString["InvId"].ToString());
		InvNo = fun.Decrypt(base.Request.QueryString["InvNo"]);
		CCode = fun.Decrypt(base.Request.QueryString["cid"].ToString());
		sId = Session["username"].ToString();
		if (!base.IsPostBack)
		{
			LoadData();
		}
	}

	public void LoadData()
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
		dataTable.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Qty", typeof(float)));
		dataTable.Columns.Add(new DataColumn("ReqQty", typeof(float)));
		dataTable.Columns.Add(new DataColumn("AmtInPer", typeof(float)));
		dataTable.Columns.Add(new DataColumn("Rate", typeof(float)));
		dataTable.Columns.Add(new DataColumn("RmnQty", typeof(float)));
		dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Unit", typeof(int)));
		string cmdText = fun.select("tblACC_ProformaInvoice_Details.Id,tblACC_ProformaInvoice_Master.POId,tblACC_ProformaInvoice_Details.ItemId,tblACC_ProformaInvoice_Details.InvoiceNo,tblACC_ProformaInvoice_Details.ItemId,tblACC_ProformaInvoice_Details.Unit,tblACC_ProformaInvoice_Details.Qty,tblACC_ProformaInvoice_Details.ReqQty,tblACC_ProformaInvoice_Details.AmtInPer,tblACC_ProformaInvoice_Details.Rate", "tblACC_ProformaInvoice_Details,tblACC_ProformaInvoice_Master", " tblACC_ProformaInvoice_Master.Id=tblACC_ProformaInvoice_Details.MId AND tblACC_ProformaInvoice_Master.Id='" + InvId + "' AND tblACC_ProformaInvoice_Master.CompId='" + CompId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("SD_Cust_PO_Details.ItemDesc", "SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'AND SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ItemDesc"].ToString();
				}
				string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				double num = 0.0;
				double num2 = 0.0;
				string cmdText4 = fun.select("Sum(tblACC_ProformaInvoice_Details.ReqQty) as ReqQty", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "'   And tblACC_ProformaInvoice_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'AND tblACC_ProformaInvoice_Master.Id='" + InvId + "'  Group By tblACC_ProformaInvoice_Details.ItemId");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num3 = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
				}
				num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				num2 = num - num3;
				dataRow[3] = num;
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["AmtInPer"].ToString()).ToString("N2"));
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				dataRow[7] = num2;
				dataRow[8] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["Unit"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
		}
		GridView1.DataSource = dataTable;
		GridView1.DataBind();
	}

	protected void Btngoods_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblACC_ProformaInvoice_Details", "Id='" + num + "' AND MId='" + InvId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
		}
		string cmdText2 = fun.select("*", "tblACC_ProformaInvoice_Details", "InvoiceNo='" + InvNo + "' AND MId='" + InvId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count == 0)
		{
			string cmdText3 = fun.delete("tblACC_ProformaInvoice_Master", "CompId='" + CompId + "'  And InvoiceNo='" + InvNo + "' And Id='" + InvId + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
			sqlCommand2.ExecuteNonQuery();
			base.Response.Redirect("ProformaInvoice_Delete.aspx?ModId=11&SubModId=104");
		}
		else
		{
			base.Response.Redirect("ProformaInvoice_Delete_Details.aspx?InvNo=" + base.Server.UrlEncode(fun.Encrypt(InvNo)) + "&InvId=" + base.Server.UrlEncode(fun.Encrypt(InvId)) + "&cid=" + base.Server.UrlEncode(fun.Encrypt(CCode)) + "&ModId=11&SubModId=104");
		}
		sqlConnection.Close();
	}

	protected void ButtonCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProformaInvoice_Delete.aspx?ModId=11&SubModId=104");
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}
}

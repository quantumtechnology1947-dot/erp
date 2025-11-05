using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_ServiceTaxInvoice_Delete_Dtails : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string invId = "";

	private string CCode = "";

	private string InvNo = "";

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button Btngoods;

	protected Button ButtonCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			invId = fun.Decrypt(base.Request.QueryString["invid"].ToString());
			InvNo = fun.Decrypt(base.Request.QueryString["InvNo"].ToString());
			CCode = fun.Decrypt(base.Request.QueryString["cid"].ToString());
			if (!base.IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
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
			string cmdText = fun.select("tblACC_ServiceTaxInvoice_Details.Id,tblACC_ServiceTaxInvoice_Details.InvoiceNo,tblACC_ServiceTaxInvoice_Details.ItemId,tblACC_ServiceTaxInvoice_Details.Unit,tblACC_ServiceTaxInvoice_Details.Qty,tblACC_ServiceTaxInvoice_Details.ReqQty,tblACC_ServiceTaxInvoice_Details.AmtInPer,tblACC_ServiceTaxInvoice_Details.Rate,tblACC_ServiceTaxInvoice_Master.POId", "tblACC_ServiceTaxInvoice_Details,tblACC_ServiceTaxInvoice_Master", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id AND tblACC_ServiceTaxInvoice_Master.Id= '" + invId + "' AND tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'");
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
					string cmdText2 = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", string.Concat(" SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='", CompId, "' AND SD_Cust_PO_Master.POId='", dataSet.Tables[0].Rows[i]["POId"], "'AND SD_Cust_PO_Details.Id='", dataSet.Tables[0].Rows[i]["ItemId"], "'"));
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
					string cmdText4 = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "' And tblACC_ServiceTaxInvoice_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND tblACC_ServiceTaxInvoice_Master.Id='" + invId + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
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
		catch (Exception)
		{
		}
	}

	protected void Btngoods_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string cmdText = fun.delete("tblACC_ServiceTaxInvoice_Details", "Id='" + num + "'AND MId='" + invId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
			}
			string cmdText2 = fun.select("InvoiceNo", "tblACC_ServiceTaxInvoice_Details", "InvoiceNo='" + InvNo + "' AND MId='" + invId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				string cmdText3 = fun.delete("tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' And InvoiceNo='" + InvNo + "'AND Id='" + invId + "' ");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				base.Response.Redirect("ServiceTaxInvoice_Delete.aspx?ModId=11&SubModId=52");
			}
			else
			{
				base.Response.Redirect("ServiceTaxInvoice_Delete_Details.aspx?InvNo=" + base.Server.UrlEncode(fun.Encrypt(InvNo)) + "&invid=" + base.Server.UrlEncode(fun.Encrypt(invId)) + "&cid=" + base.Server.UrlEncode(fun.Encrypt(CCode)) + "&ModId=11&SubModId=52");
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

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void ButtonCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Delete.aspx?ModId=11&SubModId=52");
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

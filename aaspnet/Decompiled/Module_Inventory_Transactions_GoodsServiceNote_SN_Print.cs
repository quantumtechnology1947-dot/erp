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

public class Module_Inventory_Transactions_GoodsServiceNote_SN_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string SupId = "";

	private string connStr = "";

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender1;

	protected Button btnSearch;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				loadData(SupId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string spid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			string cmdText = fun.select("Id,FinYearId,GSNNo,GINNo,GINId,SysDate", "tblinv_MaterialServiceNote_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChNO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChDT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("GINId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				int num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FinYearId"]);
				string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate", "tblInv_Inward_Master,tblInv_Inward_Details", "tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.Id='" + dataSet.Tables[0].Rows[i]["GINId"].ToString() + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string text = "";
				if (spid != "")
				{
					text = " And tblMM_PO_Master.SupplierId='" + spid + "'";
				}
				if (dataSet3.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText4 = fun.select("tblMM_PO_Master.SupplierId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo='" + dataSet3.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Details.Id='" + dataSet3.Tables[0].Rows[0]["POId"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "'" + text + " AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					string cmdText5 = fun.select("SupplierName+' ['+SupplierId+']'", "tblMM_Supplier_master", "CompId='" + CompId + "' AND  SupplierId='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					dataRow[0] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[2] = dataSet.Tables[0].Rows[i]["GSNNo"].ToString();
					dataRow[3] = value;
					dataRow[4] = dataSet.Tables[0].Rows[i]["GINNo"].ToString();
					dataRow[5] = dataSet3.Tables[0].Rows[0]["PONo"].ToString();
					dataRow[6] = dataSet4.Tables[0].Rows[0]["SupplierId"].ToString();
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet5.Tables[0].Rows[0][0].ToString();
					}
					dataRow[8] = dataSet3.Tables[0].Rows[0]["ChallanNo"].ToString();
					dataRow[9] = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["ChallanDate"].ToString());
					dataRow[10] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
					dataRow[11] = dataSet.Tables[0].Rows[i]["GINId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
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
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsupId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblGsn")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text6 = ((Label)gridViewRow.FindControl("lblGinId")).Text;
				string text7 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GoodsServiceNote_SN_Print_Details.aspx?Id=" + text7 + "&SupId=" + text + "&GSNNo=" + text2 + "&GINNo=" + text3 + "&GINId=" + text6 + "&PONo=" + text4 + "&FyId=" + text5 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=39");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			loadData(SupId);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtSupplier.Text);
			loadData(code);
		}
		catch (Exception)
		{
		}
	}
}

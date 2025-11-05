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

public class Module_MaterialManagement_Transactions_PO_Print_Supplier : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private int CompId;

	private string FyId = "";

	protected TextBox txtSearchSupplier;

	protected AutoCompleteExtender txtSearchSupplier_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView GridView5;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				LoadData(SupCode);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData(string supcode)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("POCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POSupplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POItems", typeof(int)));
			string text = "";
			if (supcode != "")
			{
				text = " AND SupplierId='" + SupCode + "'";
			}
			string cmdText = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + text + "Order by SupId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["SupplierName"].ToString();
				string cmdText2 = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "' AND FinYearId<='" + FyId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[2] = dataSet2.Tables[0].Rows.Count;
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView5.DataSource = dataTable;
			GridView5.DataBind();
			sqlConnection.Close();
			foreach (GridViewRow row in GridView5.Rows)
			{
				if (((Label)row.FindControl("lblpoitems")).Text == "0")
				{
					((LinkButton)row.FindControl("lnkbutton")).Visible = false;
				}
				else
				{
					((LinkButton)row.FindControl("lnkbutton")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblpocode")).Text;
				base.Response.Redirect("PO_Print.aspx?Code=" + text + "&ModId=6&SubModId=35");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView5.PageIndex = e.NewPageIndex;
		LoadData(SupCode);
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			SupCode = fun.getCode(txtSearchSupplier.Text);
			LoadData(SupCode);
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
}

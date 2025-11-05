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

public class Module_Inventory_Transactions_GoodsServiceNote_SN_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string sId = "";

	private string connStr = string.Empty;

	private SqlConnection con;

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
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				loadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData()
	{
		DataTable dataTable = new DataTable();
		try
		{
			con.Open();
			string code = fun.getCode(txtSupplier.Text);
			string value = "";
			if (code != string.Empty)
			{
				value = " And tblMM_Supplier_master.SupplierId='" + code + "'";
			}
			SqlCommand sqlCommand = new SqlCommand("Sp_GSN_New", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters["@CompId"].Value = CompId;
			sqlCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlCommand.Parameters["@FinId"].Value = FinYearId;
			sqlCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlCommand.Parameters["@x"].Value = value;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChNO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChDT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num = Convert.ToInt32(sqlDataReader["FinYearId"]);
				string value2 = fun.FromDateDMY(sqlDataReader["GINDate"].ToString());
				int num2 = 0;
				int num3 = 0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				if (sqlDataReader["GINQty"] != DBNull.Value)
				{
					num6 = Convert.ToDouble(sqlDataReader["GINQty"]);
					if (num6 > 0.0)
					{
						num2++;
					}
				}
				if (sqlDataReader["GSNQty"] != DBNull.Value)
				{
					num5 = Convert.ToDouble(sqlDataReader["GSNQty"]);
				}
				num4 = Math.Round(num6 - num5, 3);
				if (num4 > 0.0)
				{
					num3++;
				}
				if (num2 > 0 && num3 > 0)
				{
					dataRow[0] = sqlDataReader["PONo"].ToString();
					dataRow[1] = sqlDataReader["FinYear"].ToString();
					dataRow[2] = sqlDataReader["GINNo"].ToString();
					dataRow[3] = value2;
					dataRow[4] = sqlDataReader["SupplierName"].ToString();
					dataRow[5] = sqlDataReader["Id"].ToString();
					dataRow[6] = sqlDataReader["ChallanNo"].ToString();
					dataRow[7] = fun.FromDateDMY(sqlDataReader["ChallanDate"].ToString());
					dataRow[8] = sqlDataReader["SupplierId"].ToString();
					dataRow[9] = num;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlDataReader.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			con.Dispose();
			dataTable.Dispose();
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		loadData();
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
				string text2 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("GoodsServiceNote_SN_New_Details.aspx?Id=" + text5 + "&SupId=" + text + "&GINNo=" + text2 + "&PONo=" + text3 + "&FyId=" + text4 + "&ModId=9&SubModId=39");
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
			loadData();
		}
		catch (Exception)
		{
		}
	}
}

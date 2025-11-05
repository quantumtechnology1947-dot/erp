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

public class Module_MaterialManagement_Transactions_PO_New : Page, IRequiresSessionState
{
	protected TextBox txtSupplierPR;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected Button Button1;

	protected GridView GridView2;

	protected TabPanel PR;

	protected TextBox txtSearchSupplier;

	protected AutoCompleteExtender txtSearchSupplier_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView GridView5;

	protected TabPanel SPR;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string SupCode = "";

	private string FinYearId = "";

	private string constr = string.Empty;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		constr = fun.Connection();
		con = new SqlConnection(constr);
		try
		{
			string text = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				string cmdText = fun.delete("tblMM_PR_Po_Temp", "CompId='" + CompId + "' AND SessionId='" + text + "' or  SessionId=''   ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.delete("tblMM_SPR_Po_Temp", "CompId='" + CompId + "' AND SessionId='" + text + "'   or  SessionId='' ");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				LoadPR(SupCode);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData(string supcode)
	{
		try
		{
			DataTable dataTable = new DataTable();
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}
			string value = string.Empty;
			if (supcode != "")
			{
				value = " AND tblMM_Supplier_master.SupplierId='" + SupCode + "'";
			}
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "GetSupplier_PO_SPR";
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Connection = con;
			SqlParameter sqlParameter = new SqlParameter("@SupId", SqlDbType.VarChar, 50);
			sqlParameter.Value = value;
			SqlParameter sqlParameter2 = new SqlParameter("@CompId", SqlDbType.VarChar, 20);
			sqlParameter2.Value = CompId;
			SqlParameter sqlParameter3 = new SqlParameter("@FinId", SqlDbType.VarChar, 20);
			sqlParameter3.Value = FinYearId;
			sqlCommand.Parameters.Add(sqlParameter);
			sqlCommand.Parameters.Add(sqlParameter2);
			sqlCommand.Parameters.Add(sqlParameter3);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			dataTable.Load(reader);
			GridView5.DataSource = dataTable.DefaultView;
			GridView5.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void LoadPR(string supcode)
	{
		try
		{
			DataTable dataTable = new DataTable();
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}
			string value = string.Empty;
			if (supcode != "")
			{
				value = " AND tblMM_Supplier_master.SupplierId='" + SupCode + "'";
			}
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "GetSupplier_PO_PR";
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Connection = con;
			SqlParameter sqlParameter = new SqlParameter("@SupId", SqlDbType.VarChar, 50);
			sqlParameter.Value = value;
			SqlParameter sqlParameter2 = new SqlParameter("@CompId", SqlDbType.VarChar, 20);
			sqlParameter2.Value = CompId;
			SqlParameter sqlParameter3 = new SqlParameter("@FinId", SqlDbType.VarChar, 20);
			sqlParameter3.Value = FinYearId;
			sqlCommand.Parameters.Add(sqlParameter);
			sqlCommand.Parameters.Add(sqlParameter2);
			sqlCommand.Parameters.Add(sqlParameter3);
			SqlDataReader reader = sqlCommand.ExecuteReader();
			dataTable.Load(reader);
			GridView2.DataSource = dataTable.DefaultView;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsprcode")).Text;
				base.Response.Redirect("PO_SPR_Items.aspx?Code=" + text + "&ModId=6&SubModId=35");
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "selme")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblcode")).Text;
				base.Response.Redirect("PO_PR_Items.aspx?Code=" + text + "&ModId=6&SubModId=35");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			SupCode = fun.getCode(txtSupplierPR.Text);
			LoadPR(SupCode);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadPR(SupCode);
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void TabContainer1_ActiveTabChanged1(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			LoadData(SupCode);
		}
		else
		{
			LoadPR(SupCode);
		}
	}
}

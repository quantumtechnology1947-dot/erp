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

public class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int FinYearId;

	private int CompId;

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
			con.Open();
			string value = "";
			if (txtSupplier.Text != "")
			{
				spid = fun.getCode(txtSupplier.Text);
				value = " And tblMM_PO_Master.SupplierId='" + spid + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_GRR_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
			con.Close();
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
				_ = ((Label)gridViewRow.FindControl("lblsupId")).Text;
				string text = ((Label)gridViewRow.FindControl("lblGrrNo")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblGinId")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text6 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GoodsReceivedReceipt_GRR_Print_Details.aspx?Id=" + text6 + "&GRRNo=" + text + "&GINNo=" + text2 + "&GINId=" + text3 + "&PONo=" + text4 + "&FyId=" + text5 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=38");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		string text = "";
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			if (txtSupplier.Text != "")
			{
				text = fun.getCode(txtSupplier.Text);
				loadData(text);
			}
			else
			{
				loadData(SupId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		string text = "";
		try
		{
			if (txtSupplier.Text != "")
			{
				text = fun.getCode(txtSupplier.Text);
				loadData(text);
			}
			else
			{
				loadData(SupId);
			}
		}
		catch (Exception)
		{
		}
	}
}

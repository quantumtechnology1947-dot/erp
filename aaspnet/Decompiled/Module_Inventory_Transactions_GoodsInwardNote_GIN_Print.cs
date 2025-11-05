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

public class Module_Inventory_Transactions_GoodsInwardNote_GIN_Print : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string supplierid = "";

	private string FyId = "";

	private string PONo = "";

	private string m = string.Empty;

	private string k = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Session["finyear"].ToString();
			if (txtSupplier.Text != "")
			{
				supplierid = fun.getCode(txtSupplier.Text);
			}
			else if (txtEnqId.Text != "")
			{
				PONo = txtEnqId.Text;
			}
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				loadData(supplierid, PONo);
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			txtEnqId.Visible = false;
			txtSupplier.Visible = true;
			txtEnqId.Text = "";
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2")
		{
			txtEnqId.Visible = true;
			txtSupplier.Visible = false;
			txtSupplier.Text = "";
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtSupplier.Text != "")
			{
				supplierid = fun.getCode(txtSupplier.Text);
			}
			if (supplierid == "")
			{
				k = "";
			}
			else
			{
				k = "1";
			}
			if (DropDownList1.SelectedValue == "1")
			{
				if (txtEnqId.Text != "")
				{
					m = "1";
				}
			}
			else if (DropDownList1.SelectedValue == "2")
			{
				if (txtEnqId.Text != "")
				{
					m = "2";
				}
			}
			else
			{
				m = "";
			}
			PONo = txtEnqId.Text;
			loadData(supplierid, PONo);
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string SupId, string PoNo)
	{
		try
		{
			con.Open();
			string value = "";
			string value2 = "";
			if (m == "1")
			{
				value = " AND tblInv_Inward_Master.PONo='" + PONo + "'";
			}
			if (m == "2")
			{
				value = " AND tblInv_Inward_Master.GINNo='" + PONo + "'";
			}
			if (k == "1")
			{
				value2 = " AND tblMM_PO_Master.SupplierId='" + supplierid + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_GIN_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FyId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblFin")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblchno")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblchdt")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GoodsInwardNote_GIN_Print_Details.aspx?ModId=9&SubModId=37&Id=" + text5 + "&GINo=" + text2 + "&ChNo=" + text3 + "&ChDt=" + text4 + "&fyid=" + text + "&Key=" + randomAlphaNumeric);
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
			if (supplierid == "")
			{
				k = "";
			}
			else
			{
				k = "1";
			}
			if (DropDownList1.SelectedValue == "1")
			{
				if (txtEnqId.Text != "")
				{
					m = "1";
				}
			}
			else if (DropDownList1.SelectedValue == "2")
			{
				if (txtEnqId.Text != "")
				{
					m = "2";
				}
			}
			else
			{
				m = "";
			}
			if (txtSupplier.Text != "")
			{
				supplierid = fun.getCode(txtSupplier.Text);
			}
			else
			{
				PONo = txtEnqId.Text;
			}
			GridView2.PageIndex = e.NewPageIndex;
			loadData(supplierid, PONo);
		}
		catch (Exception)
		{
		}
	}
}

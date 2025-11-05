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

public class Module_Inventory_Transactions_GoodsInwardNote_GIN_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string j = "";

	private string supplierid = "";

	private string CompId = "";

	private string FyId = "";

	private string PONo = "";

	private string m = "";

	private string connStr = string.Empty;

	private SqlConnection con;

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Session["compid"].ToString();
			FyId = Session["finyear"].ToString();
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				loadData(j, m);
			}
		}
		catch (Exception)
		{
		}
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string po = "";
			string supId = "";
			string text = "";
			if (DropDownList1.SelectedValue == "1")
			{
				po = " AND tblInv_Inward_Master.PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2")
			{
				po = " AND tblInv_Inward_Master.GINNo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "0" && txtSupplier.Text != "")
			{
				text = fun.getCode(txtSupplier.Text);
				supId = " AND tblMM_PO_Master.SupplierId='" + text + "'";
			}
			loadData(supId, po);
		}
		catch (Exception)
		{
		}
	}

	public void disableEdit()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblId")).Text;
				string cmdText = fun.select("GINId", "tblinv_MaterialReceived_Master", "CompId='" + CompId + "' AND GINId='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				new DataTable();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgrr")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgrr")).Visible = true;
				}
				string cmdText2 = fun.select("GINId", "tblinv_MaterialServiceNote_Master", "CompId='" + CompId + "' AND GINId='" + text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgsn")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgsn")).Visible = true;
				}
				if (dataSet.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string SupId, string Po)
	{
		try
		{
			con.Open();
			string value = "";
			string value2 = "";
			string text = "";
			if (DropDownList1.SelectedValue == "1")
			{
				value = " AND tblInv_Inward_Master.PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2")
			{
				value = " AND tblInv_Inward_Master.GINNo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "0" && txtSupplier.Text != "")
			{
				text = fun.getCode(txtSupplier.Text);
				value2 = " AND tblMM_PO_Master.SupplierId='" + text + "'";
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
			disableEdit();
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
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblId")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblFin")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblGin")).Text;
			string text4 = ((Label)gridViewRow.FindControl("lblchno")).Text;
			string text5 = ((Label)gridViewRow.FindControl("lblchdt")).Text;
			string text6 = ((Label)gridViewRow.FindControl("lblpo")).Text;
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			if (e.CommandName == "sel")
			{
				base.Response.Redirect("GoodsInwardNote_GIN_Edit_Details.aspx?ModId=9&SubModId=37&Id=" + text + "&GNo=" + text3 + "&ChNo=" + text4 + "&ChDt=" + text5 + "&fyid=" + text2 + "&SupId=" + supplierid + "&PoNo=" + text6 + " ");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView2.EditIndex = e.NewEditIndex;
			loadData(j, m);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("TxtChNo")).Text;
			string text2 = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtChDt")).Text);
			if (text != "0" && text != "" && text2 != "")
			{
				string cmdText = fun.update("tblInv_Inward_Master", "ChallanNo='" + text + "', ChallanDate='" + text2 + "'", "Id=" + num + " AND CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlConnection.Open();
				int num2 = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				if (num2 == 1)
				{
					string empty = string.Empty;
					empty = "Record is updated successfully.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				GridView2.EditIndex = -1;
				loadData(j, m);
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Please enter Challan No Or Challan Date.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView2.EditIndex = -1;
			loadData(j, m);
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
			loadData(j, m);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			disableEdit();
		}
		catch (Exception)
		{
		}
	}
}

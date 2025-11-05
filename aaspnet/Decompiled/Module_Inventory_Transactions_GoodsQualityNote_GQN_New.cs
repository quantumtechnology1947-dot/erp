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

public class Module_Inventory_Transactions_GoodsQualityNote_GQN_New : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender1;

	protected TextBox Txtfield;

	protected Button btnSearch;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string grrno = "";

	private int FinYearId;

	private int CompId;

	private string sId = "";

	private string connStr = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				Txtfield.Visible = false;
				loadData(SupId, grrno);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string spid, string gid)
	{
		DataTable dataTable = new DataTable();
		try
		{
			con.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "1" && Txtfield.Text != "")
			{
				text = " And GRRNo='" + Txtfield.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "2" && Txtfield.Text != "")
			{
				text2 = " And tblInv_Inward_Master.PONo='" + Txtfield.Text + "'";
			}
			string text3 = "";
			if (spid != "")
			{
				text3 = " And tblMM_PO_Master.SupplierId='" + spid + "'";
			}
			string cmdText = fun.select("tblinv_MaterialReceived_Master.Id,tblinv_MaterialReceived_Master.FinYearId,tblinv_MaterialReceived_Master.GRRNo,tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId,tblinv_MaterialReceived_Master.SysDate,FinYear,tblInv_Inward_Master.PONo,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblMM_Supplier_master.SupplierName,tblMM_Supplier_master.SupplierId,(SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty)FROM tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id AND tblQc_MaterialQuality_Master.GRRId=tblinv_MaterialReceived_Master.Id) AS GQNQty,(SELECT SUM(tblQc_MaterialQuality_Details.RejectedQty)FROM tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id AND tblQc_MaterialQuality_Master.GRRId=tblinv_MaterialReceived_Master.Id) AS RegQty,(select sum(tblinv_MaterialReceived_Details.ReceivedQty) as sum_ReceivedQty from tblinv_MaterialReceived_Details where tblinv_MaterialReceived_Details.MId=tblinv_MaterialReceived_Master.Id) As GRRQty ", "tblinv_MaterialReceived_Master,tblFinancial_master,tblInv_Inward_Master,tblMM_PO_Master,tblMM_Supplier_master", "tblinv_MaterialReceived_Master.FinYearId<='" + FinYearId + "' And tblFinancial_master.FinYearId=tblinv_MaterialReceived_Master.FinYearId And tblInv_Inward_Master.POMId=tblMM_PO_Master.Id And tblMM_PO_Master.SupplierId=tblMM_Supplier_master.SupplierId  AND tblInv_Inward_Master.Id=tblinv_MaterialReceived_Master.GINId  AND tblinv_MaterialReceived_Master.CompId='" + CompId + "'" + text + text3 + text2 + " Order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChNO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChDT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINId", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[0] = sqlDataReader["FinYearId"].ToString();
				dataRow[1] = sqlDataReader["FinYear"].ToString();
				dataRow[2] = sqlDataReader["GRRNo"].ToString();
				dataRow[3] = value;
				dataRow[4] = sqlDataReader["GINNo"].ToString();
				dataRow[5] = sqlDataReader["PONo"].ToString();
				dataRow[6] = sqlDataReader["SupplierId"].ToString();
				dataRow[7] = sqlDataReader["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				dataRow[8] = sqlDataReader["ChallanNo"].ToString();
				dataRow[9] = fun.FromDateDMY(sqlDataReader["ChallanDate"].ToString());
				dataRow[10] = sqlDataReader["Id"].ToString();
				dataRow[11] = sqlDataReader["GINId"].ToString();
				double num = 0.0;
				if (sqlDataReader["GRRQty"] != DBNull.Value)
				{
					num = Convert.ToDouble(sqlDataReader["GRRQty"]);
				}
				double num2 = 0.0;
				if (sqlDataReader["GQNQty"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(sqlDataReader["GQNQty"]) + Convert.ToDouble(sqlDataReader["RegQty"]);
				}
				if (Math.Round(num - num2, 3) > 0.0)
				{
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
			dataTable.Clear();
			dataTable.Dispose();
			GridView2.Dispose();
			GC.Collect();
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsupId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblGrrNo")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblGinId")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text6 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text7 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("GoodsQualityNote_GQN_New_Details.aspx?Id=" + text7 + "&SupId=" + text + "&GRRNo=" + text2 + "&GINNo=" + text3 + "&GINId=" + text4 + "&PONo=" + text5 + "&FyId=" + text6 + "&ModId=10&SubModId=46");
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
			loadData(SupId, grrno);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			text = fun.getCode(txtSupplier.Text);
			text2 = Txtfield.Text;
			loadData(text, text2);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				Txtfield.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loadData(SupId, grrno);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "Select")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
				Txtfield.Text = "";
				loadData(SupId, grrno);
			}
		}
		catch (Exception)
		{
		}
	}
}

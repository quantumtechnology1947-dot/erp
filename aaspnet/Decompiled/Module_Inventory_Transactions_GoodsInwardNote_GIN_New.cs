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

public class Module_Inventory_Transactions_GoodsInwardNote_GIN_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sid = "";

	private string j = "";

	private int FinYearId;

	private int CompId;

	private string FyId = "";

	private string PONo = "";

	private string m = string.Empty;

	private string connStr = "";

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
			FyId = Session["finyear"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (txtSupplier.Text != "")
			{
				sid = fun.getCode(txtSupplier.Text);
			}
			else if (txtEnqId.Text != "")
			{
				PONo = txtEnqId.Text;
			}
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				LoadData(sid, PONo);
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				((TextBox)row.FindControl("TxtChallanDate")).Attributes.Add("readonly", "readonly");
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
		if (DropDownList1.SelectedValue == "1")
		{
			txtEnqId.Visible = true;
			txtSupplier.Visible = false;
			txtSupplier.Text = "";
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		LoadData(sid, PONo);
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

	public void LoadData(string supId, string po)
	{
		try
		{
			string value = "";
			if (supId != "")
			{
				value = " AND tblMM_PO_Master.SupplierId='" + supId + "'";
			}
			string value2 = "";
			if (po != string.Empty)
			{
				value2 = " AND tblMM_PO_Master.PONo='" + po + "'";
			}
			SqlCommand sqlCommand = new SqlCommand("GetGIN_New", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters["@CompId"].Value = CompId;
			sqlCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlCommand.Parameters["@FinYearId"].Value = FinYearId;
			sqlCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlCommand.Parameters["@x"].Value = value;
			sqlCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlCommand.Parameters["@y"].Value = value2;
			con.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			double num = 0.0;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num2 = 0;
				int num3 = 0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				num4 = Convert.ToDouble(sqlDataReader["POQty"]);
				if (sqlDataReader["GQNQty"] != DBNull.Value)
				{
					num5 = Convert.ToDouble(sqlDataReader["GQNQty"]);
				}
				if (sqlDataReader["RejQty"] != DBNull.Value)
				{
					num6 = Convert.ToDouble(sqlDataReader["RejQty"]);
				}
				if (sqlDataReader["InvQty"] != DBNull.Value)
				{
					num7 = Convert.ToDouble(sqlDataReader["InvQty"]);
				}
				if (num4 > 0.0)
				{
					num = Math.Round(num4 - num5, 3);
					if (num > 0.0 && Math.Round(num4 - num7 + num6, 5) > 0.0)
					{
						num2++;
					}
				}
				else
				{
					num3++;
				}
				if (num2 > 0 || num3 > 0)
				{
					dataRow[0] = sqlDataReader["Id"].ToString();
					dataRow[1] = sqlDataReader["FinYearId"].ToString();
					dataRow[2] = sqlDataReader["FinYear"].ToString();
					dataRow[3] = sqlDataReader["PONo"].ToString();
					dataRow[4] = sqlDataReader["PODate"].ToString();
					dataRow[5] = sqlDataReader["Supplier"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			GC.Collect();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblFinYearId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblPONo")).Text;
				string text3 = ((TextBox)gridViewRow.FindControl("txtChallanNo")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblId")).Text;
				if (text3 == "" || ((TextBox)gridViewRow.FindControl("TxtChallanDate")).Text == "" || text3 == "0")
				{
					string empty = string.Empty;
					empty = "Please enter challan Date Or challan No";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				else if (fun.DateValidation(((TextBox)gridViewRow.FindControl("TxtChallanDate")).Text) && ((TextBox)gridViewRow.FindControl("TxtChallanDate")).Text != "")
				{
					string text5 = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtChallanDate")).Text);
					base.Response.Redirect("GoodsInwardNote_GIN_New_PO_Details.aspx?ModId=9&SubModId=37&mid=" + text4 + "&PoNo=" + text2 + "&ChNo=" + text3 + "&ChDt=" + text5 + "&fyid=" + text + "&SID=" + sid, endResponse: false);
				}
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
			LoadData(sid, PONo);
		}
		catch (Exception)
		{
		}
	}
}

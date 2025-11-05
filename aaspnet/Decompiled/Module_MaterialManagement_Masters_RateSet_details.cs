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

public class Module_MaterialManagement_Masters_RateSet_details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SupCode = "";

	private int CId;

	private int ItemId;

	private int FyId;

	private string Key = string.Empty;

	protected Label Label1;

	protected TextBox txtSearchSupplier;

	protected AutoCompleteExtender txtSearchSupplier_AutoCompleteExtender;

	protected Button btnSearch;

	protected Button Btncancel;

	protected Label lblMessage;

	protected GridView GridView2;

	protected Button BtnSubmit;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CId = Convert.ToInt32(Session["compid"]);
			ItemId = Convert.ToInt32(base.Request.QueryString["ItemId"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				loadData(SupCode, ItemId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtSearchSupplier.Text != "")
			{
				SupCode = fun.getCode(txtSearchSupplier.Text);
				if (SupCode != "")
				{
					loadData(SupCode, ItemId);
					return;
				}
				string empty = string.Empty;
				empty = "Invalid data input";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			else
			{
				loadData(SupCode, ItemId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		try
		{
			base.Response.Redirect("Rateset.aspx?ModId=6&SubModId=139");
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string SupCode, int itemid)
	{
		try
		{
			DataTable dataTable = new DataTable();
			string text = "";
			string text2 = "";
			if (SupCode != "")
			{
				text = "And tblMM_Supplier_master.SupplierId ='" + SupCode + "'";
			}
			if (itemid != 0)
			{
				text2 = "And tblMM_Rate_Register.ItemId ='" + itemid + "'";
			}
			string cmdText = "SELECT tblMM_Rate_Register.Flag, tblMM_Rate_Register.Id,tblMM_Rate_Register.ItemId,tblMM_Rate_Register.POId,tblMM_Rate_Register.Rate,tblMM_Rate_Register.Discount,tblMM_Rate_Register.IndirectCost,tblMM_Rate_Register.DirectCost,tblMM_Rate_Register.CompId,tblDG_Item_Master.ManfDesc, Unit_Master.Symbol, tblFinancial_master.FinYear, tblPacking_Master.Terms,tblExciseser_Master.Terms AS Expr1, tblVAT_Master.Terms AS Expr2 FROM  tblDG_Item_Master INNER JOIN tblMM_Rate_Register ON tblDG_Item_Master.Id = tblMM_Rate_Register.ItemId INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id INNER JOIN tblFinancial_master ON tblMM_Rate_Register.FinYearId = tblFinancial_master.FinYearId INNER JOIN tblPacking_Master ON tblMM_Rate_Register.PF = tblPacking_Master.Id INNER JOIN tblExciseser_Master ON tblMM_Rate_Register.ExST = tblExciseser_Master.Id INNER JOIN tblVAT_Master ON tblMM_Rate_Register.VAT = tblVAT_Master.Id  AND tblMM_Rate_Register.CompId='" + CId + "' AND tblMM_Rate_Register.FinYearId<='" + FyId + "'" + text + text2;
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Excise", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Flag", typeof(int)));
			new DataSet();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString());
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataRow[2] = fun.GetItemCode_PartNo(CId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
				dataRow[3] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["FinYear"].ToString();
				string cmdText2 = fun.select("PONo,SupplierId", "tblMM_PO_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]) + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				_ = string.Empty;
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[6] = dataSet2.Tables[0].Rows[0]["PONo"].ToString();
					string cmdText3 = fun.select("SupplierName,RegdCountry", "tblMM_Supplier_master", "SupplierId='" + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + "' And CompId='" + CId + "'");
					DataSet dataSet3 = new DataSet();
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3, "tblMM_Supplier_master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString() + '[' + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + ']';
					}
				}
				dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
				dataRow[9] = dataSet.Tables[0].Rows[i]["Expr1"];
				dataRow[11] = dataSet.Tables[0].Rows[i]["Expr2"];
				dataRow[12] = dataSet.Tables[0].Rows[i]["Terms"];
				dataRow[14] = dataSet.Tables[0].Rows[i]["Flag"];
				double num = 0.0;
				dataRow[13] = Convert.ToDouble(decimal.Parse(Convert.ToDouble(Convert.ToDouble(dataSet.Tables[0].Rows[i]["Rate"]) - Convert.ToDouble(dataSet.Tables[0].Rows[i]["Rate"]) * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Discount"]) / 100.0).ToString()).ToString("N2"));
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblFlag")).Text);
				if (num2 == 1)
				{
					RadioButton radioButton = (RadioButton)row.FindControl("RadioButton1");
					radioButton.Checked = true;
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
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

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			loadData(SupCode, ItemId);
		}
		catch (Exception)
		{
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		GC.Collect();
	}

	protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((RadioButton)row.FindControl("RadioButton1")).Checked)
				{
					string text = ((Label)row.FindControl("lblId")).Text;
					string text2 = ((Label)row.FindControl("lblItemId")).Text;
					clsFunctions clsFunctions2 = new clsFunctions();
					string connectionString = clsFunctions2.Connection();
					SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					string cmdText = clsFunctions2.update("tblMM_Rate_Register", "Flag='0'", "ItemId='" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText2 = clsFunctions2.update("tblMM_Rate_Register", "Flag='1'", "Id='" + text + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
				}
			}
			lblMessage.Text = "Minimum rate is Set.";
		}
		catch (Exception)
		{
		}
	}
}

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

public class Module_Inventory_Reports_GoodsRejection_GRN : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string GqrNo = "";

	protected DropDownList DropDownList1;

	protected TextBox Txtfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender1;

	protected Button btnSearch;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			Txtfield.Visible = false;
			loadData(SupId, GqrNo);
		}
	}

	public void loadData(string spid, string gqrn)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string text = "";
			if (DropDownList1.SelectedValue == "1" && Txtfield.Text != "")
			{
				text = " And GQNNo='" + Txtfield.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
			}
			string cmdText = fun.select("Id,FinYearId,GQNNo,GRRNo,SysDate,GRRId", "tblQc_MaterialQuality_Master", "FinYearId<='" + num + "' AND CompId='" + num2 + "'" + text + " Order by Id Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChNO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChDT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			string text2 = "";
			string text3 = "";
			string text4 = "";
			while (sqlDataReader.Read())
			{
				string cmdText2 = fun.select("tblQc_MaterialQuality_Details.RejectedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Details.MId='" + sqlDataReader["Id"].ToString() + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				int num3 = 0;
				while (sqlDataReader2.Read())
				{
					if (Convert.ToDouble(decimal.Parse(sqlDataReader2["RejectedQty"].ToString()).ToString("N3")) > 0.0)
					{
						num3++;
					}
				}
				if (num3 <= 0)
				{
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				if (!sqlDataReader.HasRows)
				{
					continue;
				}
				if (DropDownList1.SelectedValue == "2" && Txtfield.Text != "")
				{
					text3 = " And tblinv_MaterialReceived_Master.GRRNo='" + Txtfield.Text + "'";
				}
				string cmdText3 = fun.select("tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + num2 + "' AND tblinv_MaterialReceived_Master.Id='" + sqlDataReader["GRRId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId" + text3);
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				int num4 = Convert.ToInt32(sqlDataReader["FinYearId"]);
				string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num4 + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
				{
					text2 = " And tblInv_Inward_Master.PONo='" + Txtfield.Text + "'";
				}
				if (!sqlDataReader3.HasRows)
				{
					continue;
				}
				string cmdText5 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + num2 + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + sqlDataReader3["GINId"].ToString() + "'" + text2);
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				if (DropDownList1.SelectedValue == "0" && spid != "")
				{
					text4 = " And tblMM_PO_Master.SupplierId='" + spid + "'";
				}
				if (!sqlDataReader5.HasRows)
				{
					continue;
				}
				string cmdText6 = fun.select("tblMM_PO_Master.SupplierId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.Id='" + sqlDataReader5["POId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + num2 + "'" + text4);
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6.HasRows)
				{
					string cmdText7 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + sqlDataReader6[0].ToString() + "' AND CompId='" + num2 + "'");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
					sqlDataReader7.Read();
					dataRow[0] = sqlDataReader["FinYearId"].ToString();
					if (sqlDataReader4.HasRows)
					{
						dataRow[1] = sqlDataReader4["FinYear"].ToString();
					}
					dataRow[2] = sqlDataReader["GQNNo"].ToString();
					dataRow[3] = value;
					dataRow[4] = sqlDataReader["GRRNo"].ToString();
					dataRow[5] = sqlDataReader3["GINNo"].ToString();
					dataRow[6] = sqlDataReader5["PONo"].ToString();
					dataRow[7] = sqlDataReader6["SupplierId"].ToString();
					if (sqlDataReader7.HasRows)
					{
						dataRow[8] = sqlDataReader7["SupplierName"].ToString() + " [" + sqlDataReader6[0].ToString() + "]";
					}
					dataRow[9] = sqlDataReader5["ChallanNo"].ToString();
					dataRow[10] = fun.FromDateDMY(sqlDataReader5["ChallanDate"].ToString());
					dataRow[11] = sqlDataReader["Id"].ToString();
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

	[WebMethod]
	[ScriptMethod]
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
				string text4 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text6 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GoodsRejection_GRN_Print_Details.aspx?Id=" + text6 + "&SupId=" + text + "&GRRNo=" + text2 + "&GINNo=" + text3 + "&PONo=" + text4 + "&FyId=" + text5 + "&Key=" + randomAlphaNumeric + "&ModId=10&SubModId=");
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
			loadData(SupId, GqrNo);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		text = fun.getCode(txtSupplier.Text);
		text2 = Txtfield.Text;
		loadData(text, text2);
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			Txtfield.Visible = false;
			txtSupplier.Visible = true;
			txtSupplier.Text = "";
			loadData(SupId, GqrNo);
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3")
		{
			Txtfield.Visible = true;
			txtSupplier.Visible = false;
			Txtfield.Text = "";
			loadData(SupId, GqrNo);
		}
	}
}

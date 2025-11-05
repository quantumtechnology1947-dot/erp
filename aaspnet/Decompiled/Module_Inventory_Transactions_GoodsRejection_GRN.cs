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

public class Module_Inventory_Transactions_GoodsRejection_GRN : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox Txtfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender1;

	protected Button btnSearch;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string GqrNo = "";

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
			DataTable dataTable = new DataTable();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
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
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
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
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = fun.select("tblQc_MaterialQuality_Details.RejectedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Details.MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				int num3 = 0;
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					if (Convert.ToDouble(dataSet2.Tables[0].Rows[j]["RejectedQty"]) > 0.0)
					{
						num3++;
					}
				}
				if (num3 > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						if (DropDownList1.SelectedValue == "2" && Txtfield.Text != "")
						{
							text3 = " And tblinv_MaterialReceived_Master.GRRNo='" + Txtfield.Text + "'";
						}
						string cmdText3 = fun.select("tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + num2 + "' AND tblinv_MaterialReceived_Master.Id='" + dataSet.Tables[0].Rows[i]["GRRId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId" + text3);
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3, "tblinv_MaterialReceived_Master");
						int num4 = Convert.ToInt32(dataSet.Tables[0].Rows[i]["FinYearId"]);
						string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
						string cmdText4 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + num4 + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
						{
							text2 = " And tblInv_Inward_Master.PONo='" + Txtfield.Text + "'";
						}
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							string cmdText5 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate", "tblInv_Inward_Master,tblInv_Inward_Details", "CompId='" + num2 + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + dataSet3.Tables[0].Rows[0]["GINId"].ToString() + "'" + text2);
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							if (DropDownList1.SelectedValue == "0" && spid != "")
							{
								text4 = " And tblMM_PO_Master.SupplierId='" + spid + "'";
							}
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								string cmdText6 = fun.select("tblMM_PO_Master.SupplierId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.Id='" + dataSet5.Tables[0].Rows[0]["POId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + num2 + "'" + text4);
								SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
								DataSet dataSet6 = new DataSet();
								sqlDataAdapter6.Fill(dataSet6);
								if (dataSet6.Tables[0].Rows.Count > 0)
								{
									string cmdText7 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + dataSet6.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + num2 + "'");
									SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
									SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
									DataSet dataSet7 = new DataSet();
									sqlDataAdapter7.Fill(dataSet7);
									dataRow[0] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
									if (dataSet4.Tables[0].Rows.Count > 0)
									{
										dataRow[1] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
									}
									dataRow[2] = dataSet.Tables[0].Rows[i]["GQNNo"].ToString();
									dataRow[3] = value;
									dataRow[4] = dataSet.Tables[0].Rows[i]["GRRNo"].ToString();
									dataRow[5] = dataSet3.Tables[0].Rows[0]["GINNo"].ToString();
									dataRow[6] = dataSet5.Tables[0].Rows[0]["PONo"].ToString();
									dataRow[7] = dataSet6.Tables[0].Rows[0]["SupplierId"].ToString();
									if (dataSet7.Tables[0].Rows.Count > 0)
									{
										dataRow[8] = dataSet7.Tables[0].Rows[0]["SupplierName"].ToString() + " [" + dataSet6.Tables[0].Rows[0][0].ToString() + "]";
									}
									dataRow[9] = dataSet5.Tables[0].Rows[0]["ChallanNo"].ToString();
									dataRow[10] = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["ChallanDate"].ToString());
									dataRow[11] = dataSet.Tables[0].Rows[i]["Id"].ToString();
									dataTable.Rows.Add(dataRow);
									dataTable.AcceptChanges();
								}
							}
						}
					}
				}
				GridView2.DataSource = dataTable;
				GridView2.DataBind();
				sqlConnection.Close();
			}
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
				base.Response.Redirect("GoodsRejection_GRN_Print_Details.aspx?Id=" + text6 + "&SupId=" + text + "&GRRNo=" + text2 + "&GINNo=" + text3 + "&PONo=" + text4 + "&FyId=" + text5 + "&ModId=10&SubModId=");
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

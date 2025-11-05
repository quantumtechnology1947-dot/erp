using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_BillBooking_ItemGrid : Page, IRequiresSessionState
{
	protected DropDownList DropSearchBy;

	protected TextBox txtSearchValue;

	protected DropDownList DropACHeadGqn;

	protected Button btnGQNSearch;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Label lblTotal;

	protected Label lblGqnTotal;

	protected TabPanel TabPanel1;

	protected DropDownList DropSearchByGSN;

	protected TextBox txtSearchValueGSN;

	protected DropDownList DropACHeadGsn;

	protected Button btnGQNSearchGSN;

	protected GridView GridView1;

	protected Panel Panel2;

	protected Label lblGSNTotal;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected ScriptManager ScriptManager1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private string PId = "";

	private string SupplierNo = "";

	private double FGT;

	private int FyId;

	private double GQNTotalAmount;

	private double GSNTotalAmount;

	private int DrpValue;

	private string TxtValue = string.Empty;

	private int ST;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			SupplierNo = base.Request.QueryString["SUPId"].ToString();
			FGT = Convert.ToDouble(decimal.Parse(base.Request.QueryString["FGT"]).ToString("N3"));
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(base.Request.QueryString["FyId"].ToString());
			ST = Convert.ToInt32(base.Request.QueryString["ST"]);
			sqlConnection.Open();
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", "AccHead ", "Id!=0");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "AccHead");
				DropACHeadGqn.DataSource = dataSet;
				DropACHeadGqn.DataTextField = "Head";
				DropACHeadGqn.DataValueField = "Id";
				DropACHeadGqn.DataBind();
				DropACHeadGqn.Items.Insert(0, "Select");
				string cmdText2 = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", "AccHead ", "Id!=0");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "AccHead");
				DropACHeadGsn.DataSource = dataSet2;
				DropACHeadGsn.DataTextField = "Head";
				DropACHeadGsn.DataValueField = "Id";
				DropACHeadGsn.DataBind();
				DropACHeadGsn.Items.Insert(0, "Select");
				loadDataGQN(DrpValue, TxtValue);
				loadDataGSN(DrpValue, TxtValue);
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				GQNTotalAmount += Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblGQNAmt")).Text).ToString("N3"));
			}
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				GSNTotalAmount += Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblGSNAmt")).Text).ToString("N3"));
			}
			lblGqnTotal.Text = GQNTotalAmount.ToString();
			lblGSNTotal.Text = GSNTotalAmount.ToString();
		}
		catch (Exception)
		{
		}
	}

	public void loadDataGQN(int DrpValue, string TxtValue)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			int num = 0;
			switch (DrpValue)
			{
			case 1:
				text = " AND tblInv_Inward_Master.ChallanNo like '" + TxtValue + "%'";
				break;
			case 2:
				text = " AND tblQc_MaterialQuality_Master.GQNNo='" + TxtValue + "'";
				break;
			case 3:
				text = " AND tblMM_PO_Master.PONo='" + TxtValue + "'";
				break;
			case 4:
				text2 = " AND tblDG_Item_Master.ItemCode like '" + TxtValue + "%'";
				break;
			case 5:
				text2 = " AND tblDG_Item_Master.ManfDesc like '%" + TxtValue + "%'";
				break;
			case 6:
			{
				if (DropACHeadGqn.SelectedValue != "Select")
				{
					num = 1;
					break;
				}
				string empty = string.Empty;
				empty = "Please select AC Head.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				break;
			}
			}
			string cmdText = fun.select("tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Details.Id,tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.Id As GQNId,tblQc_MaterialQuality_Master.GQNNo", "tblMM_PO_Details,tblMM_PO_Master,tblInv_Inward_Details,tblInv_Inward_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblMM_Supplier_master", "tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblMM_PO_Master.PONo=tblInv_Inward_Master.PONo AND tblInv_Inward_Details.POId=tblMM_PO_Details.Id AND tblInv_Inward_Master.GINNo=tblinv_MaterialReceived_Master.GINNo AND tblInv_Inward_Master.Id=tblinv_MaterialReceived_Master.GINId AND tblInv_Inward_Details.POId=tblinv_MaterialReceived_Details.POId AND tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId AND tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNO AND tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId AND tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblMM_Supplier_master.SupplierId=tblMM_PO_Master.SupplierId AND  tblMM_Supplier_master.SupplierId='" + SupplierNo + "' AND tblMM_PO_Master.FinYearId<='" + FyId + "' " + text);
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("ChallanNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChallanDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ACHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ACId", typeof(int)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string text3 = "";
				int num2 = 0;
				if (sqlDataReader["PRSPRFlag"].ToString() == "0")
				{
					string text4 = "";
					if (num == 1)
					{
						text4 = " AND tblMM_PR_Details.AHId='" + TxtValue + "'";
					}
					string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + sqlDataReader["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + sqlDataReader["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'" + text4);
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (sqlDataReader2.HasRows)
					{
						string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader2["ItemId"].ToString() + "' AND CompId='" + CompId + "'" + text2);
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows)
						{
							value = sqlDataReader3["ItemCode"].ToString();
							value2 = sqlDataReader3["ManfDesc"].ToString();
							string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader3["UOMBasic"].ToString() + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
							sqlDataReader4.Read();
							value3 = sqlDataReader4[0].ToString();
							text3 = sqlDataReader2["ItemId"].ToString();
							num2 = Convert.ToInt32(sqlDataReader2["AHId"].ToString());
							string cmdText5 = fun.select("Symbol", " AccHead ", "Id='" + sqlDataReader2["AHId"].ToString() + "'");
							SqlCommand selectCommand = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
							DataSet dataSet = new DataSet();
							sqlDataAdapter.Fill(dataSet);
							if (dataSet.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
					}
				}
				else if (sqlDataReader["PRSPRFlag"].ToString() == "1")
				{
					string text5 = "";
					if (num == 1)
					{
						text5 = " AND tblMM_SPR_Details.AHId='" + TxtValue + "'";
					}
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + sqlDataReader["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + sqlDataReader["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'" + text5);
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows)
					{
						string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader5["ItemId"].ToString() + "'" + text2);
						SqlCommand sqlCommand6 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
						sqlDataReader6.Read();
						if (sqlDataReader6.HasRows)
						{
							value = sqlDataReader6["ItemCode"].ToString();
							value2 = sqlDataReader6["ManfDesc"].ToString();
							string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader6["UOMBasic"].ToString() + "' ");
							SqlCommand sqlCommand7 = new SqlCommand(cmdText8, sqlConnection);
							SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
							sqlDataReader7.Read();
							value3 = sqlDataReader7[0].ToString();
							text3 = sqlDataReader5["ItemId"].ToString();
							num2 = Convert.ToInt32(sqlDataReader5["AHId"].ToString());
							string cmdText9 = fun.select("Symbol", " AccHead ", "Id='" + sqlDataReader5["AHId"].ToString() + "'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
					}
				}
				string cmdText10 = fun.select("GQNId", "tblACC_BillBooking_Details_Temp", "ItemId='" + text3 + "' AND GQNId='" + sqlDataReader["GQNId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				string cmdText11 = fun.select("tblACC_BillBooking_Details.GQNId", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", " tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Details.ItemId='" + text3 + "' AND tblACC_BillBooking_Details.GQNId='" + sqlDataReader["GQNId"].ToString() + "' AND tblACC_BillBooking_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand9 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
				sqlDataReader9.Read();
				if (!sqlDataReader8.HasRows && !sqlDataReader9.HasRows && text3 != "")
				{
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					num3 = Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2"));
					num4 = Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2"));
					num5 = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(sqlDataReader["AcceptedQty"].ToString()).ToString("N3"));
					dataRow[0] = sqlDataReader["ChallanNo"].ToString();
					dataRow[1] = fun.FromDateDMY(sqlDataReader["ChallanDate"].ToString());
					dataRow[2] = value;
					dataRow[3] = value2;
					dataRow[4] = value3;
					dataRow[5] = value4;
					dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2"));
					dataRow[8] = Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2"));
					num7 = Convert.ToDouble(decimal.Parse(((num3 - num3 * num4 / 100.0) * num6).ToString()).ToString("N2"));
					num8 = Convert.ToDouble(decimal.Parse(((num3 - num3 * num4 / 100.0) * num5).ToString()).ToString("N2"));
					dataRow[9] = sqlDataReader["GQNNo"].ToString();
					dataRow[10] = num8;
					dataRow[11] = Convert.ToDouble(decimal.Parse(sqlDataReader["AcceptedQty"].ToString()).ToString("N3"));
					dataRow[12] = num7;
					dataRow[13] = sqlDataReader["GQNId"].ToString();
					dataRow[14] = sqlDataReader["Id"].ToString();
					string cmdText12 = fun.select("*", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand10 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
					sqlDataReader10.Read();
					dataRow[15] = sqlDataReader10["FinYear"].ToString();
					dataRow[16] = sqlDataReader["PONo"].ToString();
					dataRow[17] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[18] = num2;
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
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			loadDataGQN(DrpValue, TxtValue);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = "0";
				string text2 = ((Label)gridViewRow.FindControl("lblgqnId")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblPoId")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblGQNAmt")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblAcptQty")).Text;
				double num = 0.0;
				string text6 = "0";
				int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblACId")).Text);
				string cmdText = fun.select("ACHead", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0 || (dataSet.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0]["ACHead"]) == num2))
				{
					base.Response.Redirect("BillBooking_Item_Details.aspx?SUPId=" + SupplierNo + "&GSNQty=" + text6 + "&GSNAmt=" + num + "&FGT=" + FGT + "&PoId=" + text3 + "&GQNAmt=" + text4 + "&GQNQty=" + text5 + "&GQNId=" + text2 + "&GSNId=" + text + "&FYId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
				}
				else
				{
					string empty = string.Empty;
					empty = "AC Head is not match.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadDataGSN(int DrpValue, string TxtValue)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			int num = 0;
			switch (DrpValue)
			{
			case 1:
				text = " AND tblInv_Inward_Master.ChallanNo like '" + TxtValue + "%'";
				break;
			case 2:
				text = " AND tblinv_MaterialServiceNote_Master.GSNNo='" + TxtValue + "'";
				break;
			case 3:
				text = " AND tblMM_PO_Master.PONo='" + TxtValue + "'";
				break;
			case 4:
				text2 = " AND tblDG_Item_Master.ItemCode like '" + TxtValue + "%'";
				break;
			case 5:
				text2 = " AND tblDG_Item_Master.ManfDesc like '%" + TxtValue + "%'";
				break;
			case 6:
			{
				if (DropACHeadGsn.SelectedValue != "Select")
				{
					num = 1;
					break;
				}
				string empty = string.Empty;
				empty = "Please select AC Head.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				break;
			}
			}
			string cmdText = fun.select("tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Details.Id,tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.Id As GSNId", "tblMM_PO_Details,tblMM_PO_Master,tblInv_Inward_Details,tblInv_Inward_Master,tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblMM_Supplier_master", "tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblinv_MaterialServiceNote_Master.Id =tblinv_MaterialServiceNote_Details.MId AND tblMM_PO_Master.PONo=tblInv_Inward_Master.PONo AND tblInv_Inward_Details.POId=tblMM_PO_Details.Id AND tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId AND tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo AND tblInv_Inward_Details.POId=tblinv_MaterialServiceNote_Details.POId AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblMM_Supplier_master.SupplierId=tblMM_PO_Master.SupplierId AND  tblMM_Supplier_master.SupplierId='" + SupplierNo + "' AND tblMM_PO_Master.FinYearId<='" + FyId + "'" + text);
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("ChallanNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChallanDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ACHead1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReceivedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GSNAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GSNId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYrs1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ACId1", typeof(int)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string text3 = "";
				int num2 = 0;
				if (sqlDataReader["PRSPRFlag"].ToString() == "0")
				{
					string text4 = "";
					if (num == 1)
					{
						text4 = " AND tblMM_PR_Details.AHId='" + TxtValue + "'";
					}
					string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + sqlDataReader["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + sqlDataReader["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'" + text4);
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (sqlDataReader2.HasRows)
					{
						string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader2["ItemId"].ToString() + "' AND CompId='" + CompId + "'" + text2);
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows)
						{
							value = sqlDataReader3["ItemCode"].ToString();
							value2 = sqlDataReader3["ManfDesc"].ToString();
							string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader3["UOMBasic"].ToString() + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
							sqlDataReader4.Read();
							value3 = sqlDataReader4[0].ToString();
							text3 = sqlDataReader2["ItemId"].ToString();
							num2 = Convert.ToInt32(sqlDataReader2["AHId"].ToString());
							string cmdText5 = fun.select("Symbol", " AccHead ", "Id='" + sqlDataReader2["AHId"].ToString() + "'");
							SqlCommand selectCommand = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
							DataSet dataSet = new DataSet();
							sqlDataAdapter.Fill(dataSet);
							if (dataSet.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
					}
				}
				else if (sqlDataReader["PRSPRFlag"].ToString() == "1")
				{
					string text5 = "";
					if (num == 1)
					{
						text5 = " AND tblMM_SPR_Details.AHId='" + TxtValue + "'";
					}
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + sqlDataReader["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + sqlDataReader["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'" + text5);
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows)
					{
						string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader5["ItemId"].ToString() + "'" + text2);
						SqlCommand sqlCommand6 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
						sqlDataReader6.Read();
						if (sqlDataReader6.HasRows)
						{
							value = sqlDataReader6["ItemCode"].ToString();
							value2 = sqlDataReader6["ManfDesc"].ToString();
							string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader6["UOMBasic"].ToString() + "' ");
							SqlCommand sqlCommand7 = new SqlCommand(cmdText8, sqlConnection);
							SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
							sqlDataReader7.Read();
							value3 = sqlDataReader7[0].ToString();
							text3 = sqlDataReader5["ItemId"].ToString();
							num2 = Convert.ToInt32(sqlDataReader5["AHId"].ToString());
							string cmdText9 = fun.select("Symbol", " AccHead ", "Id='" + sqlDataReader5["AHId"].ToString() + "'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
					}
				}
				string cmdText10 = fun.select("GSNId", "tblACC_BillBooking_Details_Temp", "ItemId='" + text3 + "' AND GSNId='" + sqlDataReader["GSNId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				string cmdText11 = fun.select("tblACC_BillBooking_Details.GSNId", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", " tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Details.ItemId='" + text3 + "' AND tblACC_BillBooking_Details.GSNId='" + sqlDataReader["GSNId"].ToString() + "' AND tblACC_BillBooking_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand9 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
				sqlDataReader9.Read();
				if (!sqlDataReader8.HasRows && !sqlDataReader9.HasRows && text3 != "")
				{
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					num3 = Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2"));
					num4 = Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2"));
					num5 = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(sqlDataReader["ReceivedQty"].ToString()).ToString("N3"));
					dataRow[0] = sqlDataReader["ChallanNo"].ToString();
					dataRow[1] = fun.FromDateDMY(sqlDataReader["ChallanDate"].ToString());
					dataRow[2] = value;
					dataRow[3] = value2;
					dataRow[4] = value3;
					dataRow[5] = value4;
					dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2"));
					dataRow[8] = Convert.ToDouble(decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2"));
					num7 = Convert.ToDouble(decimal.Parse(((num3 - num3 * num4 / 100.0) * num6).ToString()).ToString("N2"));
					num8 = Convert.ToDouble(decimal.Parse(((num3 - num3 * num4 / 100.0) * num5).ToString()).ToString("N2"));
					dataRow[9] = sqlDataReader["GSNNo"].ToString();
					dataRow[10] = num8;
					dataRow[11] = Convert.ToDouble(decimal.Parse(sqlDataReader["ReceivedQty"].ToString()).ToString("N3"));
					dataRow[12] = num7;
					dataRow[13] = sqlDataReader["GSNId"].ToString();
					dataRow[14] = sqlDataReader["Id"].ToString();
					string cmdText12 = fun.select("*", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand10 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
					sqlDataReader10.Read();
					dataRow[15] = sqlDataReader10["FinYear"].ToString();
					dataRow[16] = sqlDataReader["PONo"].ToString();
					dataRow[17] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[18] = num2;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = "0";
				string text2 = ((Label)gridViewRow.FindControl("lblgsnId")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text4 = decimal.Parse(((Label)gridViewRow.FindControl("lblGSNAmt")).Text.ToString()).ToString("N2");
				string text5 = ((Label)gridViewRow.FindControl("lblAcptQty0")).Text;
				double num = 0.0;
				string text6 = "0";
				int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblACId1")).Text);
				string cmdText = fun.select("ACHead", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0 || (dataSet.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0]["ACHead"]) == num2))
				{
					base.Response.Redirect("BillBooking_Item_Details.aspx?SUPId=" + SupplierNo + "&FGT=" + FGT + "&PoId=" + text3 + "&GQNQty=" + text6 + "&GQNAmt=" + num + "&GSNQty=" + text5 + "&GSNAmt=" + text4 + "&GSNId=" + text2 + "&GQNId=" + text + "&FYId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
				}
				else
				{
					string empty = string.Empty;
					empty = "AC Head is not match.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void btnGQNSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DropSearchBy.SelectedValue == "6")
			{
				DrpValue = Convert.ToInt32(DropSearchBy.SelectedValue);
				TxtValue = DropACHeadGqn.SelectedValue.ToString();
			}
			else
			{
				DrpValue = Convert.ToInt32(DropSearchBy.SelectedValue);
				TxtValue = txtSearchValue.Text;
			}
			loadDataGQN(DrpValue, TxtValue);
		}
		catch (Exception)
		{
		}
	}

	protected void btnGSNSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DropSearchByGSN.SelectedValue == "6")
			{
				DrpValue = Convert.ToInt32(DropSearchByGSN.SelectedValue);
				TxtValue = DropACHeadGsn.SelectedValue.ToString();
			}
			else
			{
				DrpValue = Convert.ToInt32(DropSearchByGSN.SelectedValue);
				TxtValue = txtSearchValueGSN.Text;
			}
			loadDataGSN(DrpValue, TxtValue);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadDataGSN(DrpValue, TxtValue);
		}
		catch (Exception)
		{
		}
	}

	protected void DropSearchBy_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropSearchBy.SelectedValue == "6")
		{
			DropACHeadGqn.Visible = true;
		}
		else
		{
			DropACHeadGqn.Visible = false;
		}
		if (DropSearchBy.SelectedValue != "6" && DropSearchBy.SelectedValue != "0")
		{
			txtSearchValue.Text = "";
			txtSearchValue.Visible = true;
			DropACHeadGqn.SelectedValue = "Select";
		}
		else
		{
			txtSearchValue.Visible = false;
			txtSearchValue.Text = "";
		}
	}

	protected void DropSearchByGSN_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropSearchByGSN.SelectedValue == "6")
		{
			DropACHeadGsn.Visible = true;
		}
		else
		{
			DropACHeadGsn.Visible = false;
		}
		if (DropSearchByGSN.SelectedValue != "6" && DropSearchByGSN.SelectedValue != "0")
		{
			txtSearchValueGSN.Text = "";
			txtSearchValueGSN.Visible = true;
			DropACHeadGsn.SelectedValue = "Select";
		}
		else
		{
			txtSearchValueGSN.Visible = false;
			txtSearchValueGSN.Text = "";
		}
		TabContainer1.ActiveTabIndex = 1;
	}
}

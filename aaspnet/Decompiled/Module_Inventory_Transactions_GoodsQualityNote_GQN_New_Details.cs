using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_GoodsQualityNote_GQN_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string poNo = "";

	private string GINNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string CDate = "";

	private string CTime = "";

	private string GRRNo = "";

	private string Id = "";

	private string GINId = "";

	protected Label lblGrr;

	protected Label lblGIn;

	protected Label lblChNo;

	protected Label lblDate;

	protected Label lblSupplier;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			Id = base.Request.QueryString["Id"].ToString();
			GINId = base.Request.QueryString["GINId"].ToString();
			GRRNo = base.Request.QueryString["GRRNo"].ToString();
			GINNo = base.Request.QueryString["GINNo"].ToString();
			SupplierNo = base.Request.QueryString["SupId"].ToString();
			poNo = base.Request.QueryString["PONo"].ToString();
			FyId = base.Request.QueryString["FyId"].ToString();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			GetValidate();
			if (!Page.IsPostBack)
			{
				lblGrr.Text = GRRNo;
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "Id='" + GINId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					lblChNo.Text = dataSet2.Tables[0].Rows[0]["ChallanNo"].ToString();
					lblDate.Text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["ChallanDate"].ToString());
				}
				loadData();
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				CompId = Convert.ToInt32(Session["compid"]);
				string text = ((Label)row.FindControl("lblId")).Text;
				string cmdText3 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.RejectionReason,tblQc_MaterialQuality_Details.Remarks,tblQc_MaterialQuality_Details.SN,tblQc_MaterialQuality_Details.PN", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.GRRId='" + text + "' AND tblQc_MaterialQuality_Master.GRRId='" + Id + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["AcceptedQty"] != DBNull.Value)
				{
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void loadData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sId = Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Details.POId,tblinv_MaterialReceived_Details.ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.Id='" + Id + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId   ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RecedQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RejReason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PN", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RejectedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DeviatedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SegregatedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("NormalAccQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CatId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCatId", typeof(string)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string value5 = "";
			string value6 = "";
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId,tblInv_Inward_Details.ACategoyId,tblInv_Inward_Details.ASubCategoyId", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + GINId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet2.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId  AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText4 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet3.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet3.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						string cmdText5 = fun.select("Id,ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							if (dataSet5.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet5.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[19] = "View";
							}
							else
							{
								dataRow[19] = "";
							}
							if (dataSet5.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet5.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[20] = "View";
							}
							else
							{
								dataRow[20] = "";
							}
							value4 = dataSet5.Tables[0].Rows[0]["Id"].ToString();
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet6.Tables[0].Rows[0][0].ToString();
							}
							value6 = dataSet4.Tables[0].Rows[0]["WONo"].ToString();
						}
						value5 = dataSet4.Tables[0].Rows[0]["AHId"].ToString();
					}
				}
				else if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText7 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet3.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet3.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "'  AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						string cmdText8 = fun.select("Id,ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet7.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							if (dataSet8.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet8.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[19] = "View";
							}
							else
							{
								dataRow[19] = "";
							}
							if (dataSet8.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet8.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[20] = "View";
							}
							else
							{
								dataRow[20] = "";
							}
							value4 = dataSet8.Tables[0].Rows[0]["Id"].ToString();
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet7.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet8.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet8.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet9.Tables[0].Rows[0][0].ToString();
							}
							if (!string.IsNullOrEmpty(dataSet7.Tables[0].Rows[0]["WONo"].ToString()))
							{
								value6 = dataSet7.Tables[0].Rows[0]["WONo"].ToString();
							}
							else
							{
								string cmdText10 = fun.select("Symbol AS Dept", "BusinessGroup", string.Concat("Id='", dataSet7.Tables[0].Rows[0]["DeptId"], "'"));
								SqlCommand sqlCommand = new SqlCommand(cmdText10, sqlConnection);
								SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
								sqlDataReader.Read();
								value6 = sqlDataReader[0].ToString();
							}
						}
						value5 = dataSet7.Tables[0].Rows[0]["AHId"].ToString();
					}
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = value;
				dataRow[2] = value2;
				dataRow[3] = value3;
				if (dataSet3.Tables[0].Rows[0]["Qty"].ToString() == "")
				{
					dataRow[4] = "0";
				}
				else
				{
					dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
				}
				if (dataSet2.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
				{
					dataRow[5] = "0";
				}
				else
				{
					dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
				}
				if (dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")
				{
					dataRow[6] = "0";
				}
				else
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString()).ToString("N3"));
				}
				dataRow[8] = value4;
				dataRow[9] = value5;
				dataRow[10] = value6;
				string cmdText11 = fun.select("tblQc_MaterialQuality_Details.DeviatedQty,tblQc_MaterialQuality_Details.SegregatedQty,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.RejectionReason,tblQc_MaterialQuality_Details.Remarks,tblQc_MaterialQuality_Details.SN,tblQc_MaterialQuality_Details.PN,tblQc_MaterialQuality_Details.NormalAccQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.GRRId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' AND tblQc_MaterialQuality_Master.GRRId='" + Id + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["AcceptedQty"].ToString()).ToString("N3"));
					string cmdText12 = fun.select("Symbol", "tblQc_Rejection_Reason", "Id='" + dataSet10.Tables[0].Rows[0]["RejectionReason"].ToString() + "'");
					SqlCommand selectCommand11 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter11.Fill(dataSet11);
					dataRow[11] = dataSet11.Tables[0].Rows[0]["Symbol"].ToString();
					dataRow[12] = dataSet10.Tables[0].Rows[0]["SN"].ToString();
					dataRow[13] = dataSet10.Tables[0].Rows[0]["PN"].ToString();
					dataRow[14] = dataSet10.Tables[0].Rows[0]["Remarks"].ToString();
					dataRow[15] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["RejectedQty"].ToString()).ToString("N3"));
					dataRow[16] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["DeviatedQty"].ToString()).ToString("N3"));
					dataRow[17] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["SegregatedQty"].ToString()).ToString("N3"));
					dataRow[18] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["NormalAccQty"].ToString()).ToString("N3"));
				}
				dataRow[21] = dataSet2.Tables[0].Rows[0]["ACategoyId"].ToString();
				dataRow[22] = dataSet2.Tables[0].Rows[0]["ASubCategoyId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (e.CommandName == "Ins")
			{
				sId = Session["username"].ToString();
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				CDate = fun.getCurrDate();
				CTime = fun.getCurrTime();
				string cmdText = fun.select("GQNNo", "tblQc_MaterialQuality_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GQNNo desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblQc_MaterialQuality_Master");
				string text = "";
				text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				string cmdText2 = fun.select("MRSNo", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRSNo Desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblInv_MaterialRequisition_Master");
				string text2 = "";
				text2 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				string cmdText3 = fun.select("MINNo", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by MINNo Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblInv_MaterialIssue_Master");
				string text3 = "";
				text3 = ((dataSet3.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				string cmdText4 = fun.select("MRNNo", "tblInv_MaterialReturn_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRNNo Desc");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblInv_MaterialReturn_Master");
				string text4 = "";
				text4 = ((dataSet4.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet4.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				string cmdText5 = fun.select("MRQNNo", "tblQc_MaterialReturnQuality_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRQNNo Desc");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "tblQc_MaterialReturnQuality_Master");
				string text5 = "";
				text5 = ((dataSet5.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet5.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (GridViewRow row in GridView2.Rows)
				{
					if (!((CheckBox)row.FindControl("ck")).Checked)
					{
						continue;
					}
					num2++;
					if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtNormalAccQty")).Text != "" && ((TextBox)row.FindControl("txtDeviatedQty")).Text != "" && ((TextBox)row.FindControl("txtSegregatedQty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtNormalAccQty")).Text) && fun.NumberValidationQty(((TextBox)row.FindControl("txtDeviatedQty")).Text) && fun.NumberValidationQty(((TextBox)row.FindControl("txtSegregatedQty")).Text))
					{
						double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtDeviatedQty")).Text.ToString()).ToString("N3"));
						double num5 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtSegregatedQty")).Text.ToString()).ToString("N3"));
						double num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtNormalAccQty")).Text.ToString()).ToString("N3"));
						_ = ((Label)row.FindControl("lblId")).Text;
						_ = ((DropDownList)row.FindControl("drprejreason")).SelectedValue;
						_ = ((TextBox)row.FindControl("txtRemarks")).Text;
						double num7 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblRecedqty")).Text.ToString()).ToString("N3"));
						_ = ((Label)row.FindControl("lblitemid")).Text;
						_ = ((TextBox)row.FindControl("txtSN")).Text;
						_ = ((TextBox)row.FindControl("txtPN")).Text;
						double num8 = 0.0;
						num8 = num4 + num5 + num6;
						if (num7 >= num8)
						{
							num++;
						}
					}
				}
				if (num2 == num && num > 0)
				{
					int num9 = 1;
					int num10 = 1;
					int num11 = 1;
					int num12 = 1;
					int num13 = 1;
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					string text11 = "";
					int num14 = 0;
					string text12 = string.Empty;
					DataTable dataTable = new DataTable();
					dataTable.Columns.Add(new DataColumn("SRNo", typeof(int)));
					dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
					dataTable.Columns.Add(new DataColumn("InitialStock", typeof(string)));
					dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
					int num15 = 0;
					string value = string.Empty;
					string value2 = string.Empty;
					_ = string.Empty;
					string value3 = string.Empty;
					string value4 = string.Empty;
					foreach (GridViewRow row2 in GridView2.Rows)
					{
						if (!((CheckBox)row2.FindControl("ck")).Checked || !(((TextBox)row2.FindControl("txtNormalAccQty")).Text != "") || !(((TextBox)row2.FindControl("txtDeviatedQty")).Text != "") || !(((TextBox)row2.FindControl("txtSegregatedQty")).Text != "") || !fun.NumberValidationQty(((TextBox)row2.FindControl("txtNormalAccQty")).Text) || !fun.NumberValidationQty(((TextBox)row2.FindControl("txtDeviatedQty")).Text) || !fun.NumberValidationQty(((TextBox)row2.FindControl("txtSegregatedQty")).Text))
						{
							continue;
						}
						DataRow dataRow = dataTable.NewRow();
						double num16 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtDeviatedQty")).Text.ToString()).ToString("N3"));
						double num17 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtSegregatedQty")).Text.ToString()).ToString("N3"));
						double num18 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtNormalAccQty")).Text.ToString()).ToString("N3"));
						string text13 = ((Label)row2.FindControl("lblId")).Text;
						string selectedValue = ((DropDownList)row2.FindControl("drprejreason")).SelectedValue;
						string text14 = ((TextBox)row2.FindControl("txtRemarks")).Text;
						double num19 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblRecedqty")).Text.ToString()).ToString("N3"));
						string text15 = ((Label)row2.FindControl("lblitemid")).Text;
						string text16 = ((Label)row2.FindControl("lblahid")).Text;
						string text17 = ((TextBox)row2.FindControl("txtSN")).Text;
						string text18 = ((TextBox)row2.FindControl("txtPN")).Text;
						double num20 = 0.0;
						num20 = num16 + num17 + num18;
						string text19 = ((Label)row2.FindControl("lblWONo")).Text;
						string text20 = "";
						if (num19 >= num20)
						{
							double num21 = 0.0;
							double num22 = 0.0;
							num21 = Math.Round(num19 - num20, 3);
							if (num9 == 1)
							{
								SqlCommand sqlCommand = new SqlCommand(fun.insert("tblQc_MaterialQuality_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,GQNNo,GRRNo,GRRId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + GRRNo + "','" + Id + "'"), sqlConnection);
								sqlCommand.ExecuteNonQuery();
								num9 = 0;
								string cmdText6 = fun.select("Id", "tblQc_MaterialQuality_Master", "CompId='" + CompId + "' Order by Id desc");
								SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
								DataSet dataSet6 = new DataSet();
								sqlDataAdapter6.Fill(dataSet6, "tblQc_MaterialQuality_Master");
								text10 = dataSet6.Tables[0].Rows[0]["Id"].ToString();
							}
							SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblQc_MaterialQuality_Details", "MId,GQNNo,GRRId,NormalAccQty,RejectedQty,RejectionReason,SN,PN,Remarks,DeviatedQty,SegregatedQty,AcceptedQty", "'" + text10 + "','" + text + "','" + text13 + "','" + num18 + "','" + num21 + "','" + selectedValue + "','" + text17 + "','" + text18 + "','" + text14 + "','" + num16 + "','" + num17 + "','" + num20 + "'"), sqlConnection);
							sqlCommand2.ExecuteNonQuery();
							string cmdText7 = fun.select("Id", "tblQc_MaterialQuality_Details", "MId='" + text10 + "' Order by Id desc");
							SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter7.Fill(dataSet7, "tblQc_MaterialQuality_Details");
							text20 = dataSet7.Tables[0].Rows[0]["Id"].ToString();
							if (text16 == "33")
							{
								string empty = string.Empty;
								int num23 = 0;
								int num24 = 0;
								num23 = Convert.ToInt32(((Label)row2.FindControl("lblCatId")).Text);
								num24 = Convert.ToInt32(((Label)row2.FindControl("lblSubCatId")).Text);
								string cmdText8 = fun.select("AssetNo", "tblACC_Asset_Register", "ACategoyId='" + num23 + "' And ASubCategoyId='" + num24 + "' Order by Id Desc");
								SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
								DataSet dataSet8 = new DataSet();
								sqlDataAdapter8.Fill(dataSet8, "tblInv_Inward_Master");
								empty = ((dataSet8.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["AssetNo"].ToString()) + 1).ToString("D4"));
								for (int i = 1; (double)i <= num20; i++)
								{
									string cmdText9 = fun.insert("tblACC_Asset_Register", "SysDate,SysTime,SessionId,CompId,FinYearId,MId,DId,ACategoyId ,ASubCategoyId,AssetNo", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text10 + "','" + text20 + "','" + num23 + "','" + num24 + "','" + empty + "'");
									SqlCommand sqlCommand3 = new SqlCommand(cmdText9, sqlConnection);
									sqlCommand3.ExecuteNonQuery();
									empty = (Convert.ToInt32(empty) + 1).ToString("D4");
									base.Response.Write("Hi");
								}
							}
							string cmdText10 = fun.select("StockQty,Process,ItemCode,ManfDesc", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + text15 + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								num22 = Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + num20;
								string cmdText11 = fun.update("tblDG_Item_Master", "StockQty='" + num22 + "'", "CompId='" + CompId + "' AND Id='" + text15 + "'");
								SqlCommand sqlCommand4 = new SqlCommand(cmdText11, sqlConnection);
								sqlCommand4.ExecuteNonQuery();
								string empty2 = string.Empty;
								string empty3 = string.Empty;
								int num25 = 0;
								if (Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Process"]) == 0)
								{
									string cmdText12 = fun.select("ReleaseWIS", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND WONo='" + text19 + "'");
									SqlCommand selectCommand10 = new SqlCommand(cmdText12, sqlConnection);
									SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
									DataSet dataSet10 = new DataSet();
									sqlDataAdapter10.Fill(dataSet10);
									if (dataSet10.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet10.Tables[0].Rows[0][0]) == 1 && text19 != "")
									{
										SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter("GQN_BOM_Details", sqlConnection);
										sqlDataAdapter11.SelectCommand.CommandType = CommandType.StoredProcedure;
										sqlDataAdapter11.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
										sqlDataAdapter11.SelectCommand.Parameters["@CompId"].Value = CompId;
										sqlDataAdapter11.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
										sqlDataAdapter11.SelectCommand.Parameters["@WONo"].Value = text19;
										sqlDataAdapter11.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
										sqlDataAdapter11.SelectCommand.Parameters["@ItemId"].Value = text15;
										DataSet dataSet11 = new DataSet();
										sqlDataAdapter11.Fill(dataSet11, "tblDG_BOM_Master");
										double num26 = 0.0;
										double num27 = 0.0;
										for (int j = 0; j < dataSet11.Tables[0].Rows.Count; j++)
										{
											DataSet dataSet12 = new DataSet();
											SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter("GetSchTime_Item_Details", sqlConnection);
											sqlDataAdapter12.SelectCommand.CommandType = CommandType.StoredProcedure;
											sqlDataAdapter12.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
											sqlDataAdapter12.SelectCommand.Parameters["@CompId"].Value = CompId;
											sqlDataAdapter12.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
											sqlDataAdapter12.SelectCommand.Parameters["@Id"].Value = dataSet11.Tables[0].Rows[j][0].ToString();
											sqlDataAdapter12.Fill(dataSet12, "tblDG_Item_Master");
											double num28 = 1.0;
											List<double> list = new List<double>();
											list = fun.BOMTreeQty(text19, Convert.ToInt32(dataSet11.Tables[0].Rows[j][2]), Convert.ToInt32(dataSet11.Tables[0].Rows[j][3]));
											for (int k = 0; k < list.Count; k++)
											{
												num28 *= list[k];
											}
											SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
											sqlDataAdapter13.SelectCommand.CommandType = CommandType.StoredProcedure;
											sqlDataAdapter13.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
											sqlDataAdapter13.SelectCommand.Parameters["@CompId"].Value = CompId;
											sqlDataAdapter13.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
											sqlDataAdapter13.SelectCommand.Parameters["@WONo"].Value = text19;
											sqlDataAdapter13.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
											sqlDataAdapter13.SelectCommand.Parameters["@ItemId"].Value = dataSet11.Tables[0].Rows[j]["ItemId"].ToString();
											sqlDataAdapter13.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
											sqlDataAdapter13.SelectCommand.Parameters["@PId"].Value = dataSet11.Tables[0].Rows[j]["PId"].ToString();
											sqlDataAdapter13.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
											sqlDataAdapter13.SelectCommand.Parameters["@CId"].Value = dataSet11.Tables[0].Rows[j]["CId"].ToString();
											DataSet dataSet13 = new DataSet();
											sqlDataAdapter13.Fill(dataSet13);
											double num29 = 0.0;
											if (dataSet13.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet13.Tables[0].Rows.Count > 0)
											{
												num29 = Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
											}
											double num30 = Math.Round(num28 - num29, 5);
											if (num28 >= 0.0)
											{
												num26 = Convert.ToDouble(decimal.Parse(num30.ToString()).ToString("N3"));
											}
											if (dataSet11.Tables[0].Rows[j]["PId"].ToString() == "0")
											{
												num27 = num26;
											}
											if (dataSet11.Tables[0].Rows[j]["PId"].ToString() != "0")
											{
												List<int> list2 = new List<int>();
												list2 = fun.CalBOMTreeQty(CompId, text19, Convert.ToInt32(dataSet11.Tables[0].Rows[j][2]), Convert.ToInt32(dataSet11.Tables[0].Rows[j][3]));
												int num31 = 0;
												int num32 = 0;
												int num33 = 0;
												List<int> list3 = new List<int>();
												List<int> list4 = new List<int>();
												for (int num34 = list2.Count; num34 > 0; num34--)
												{
													if (list2.Count > 2)
													{
														list4.Add(list2[num34 - 1]);
													}
													else
													{
														list3.Add(list2[num31]);
														num31++;
													}
												}
												double num35 = 1.0;
												for (int l = 0; l < list3.Count; l++)
												{
													num33 = list3[l++];
													num32 = list3[l];
													SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
													sqlDataAdapter14.SelectCommand.CommandType = CommandType.StoredProcedure;
													sqlDataAdapter14.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
													sqlDataAdapter14.SelectCommand.Parameters["@CompId"].Value = CompId;
													sqlDataAdapter14.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
													sqlDataAdapter14.SelectCommand.Parameters["@WONo"].Value = text19;
													sqlDataAdapter14.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
													sqlDataAdapter14.SelectCommand.Parameters["@PId"].Value = num33;
													sqlDataAdapter14.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
													sqlDataAdapter14.SelectCommand.Parameters["@CId"].Value = num32;
													DataSet dataSet14 = new DataSet();
													sqlDataAdapter14.Fill(dataSet14);
													SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
													sqlDataAdapter15.SelectCommand.CommandType = CommandType.StoredProcedure;
													sqlDataAdapter15.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
													sqlDataAdapter15.SelectCommand.Parameters["@CompId"].Value = CompId;
													sqlDataAdapter15.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
													sqlDataAdapter15.SelectCommand.Parameters["@WONo"].Value = text19;
													sqlDataAdapter15.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
													sqlDataAdapter15.SelectCommand.Parameters["@ItemId"].Value = dataSet14.Tables[0].Rows[0]["ItemId"].ToString();
													sqlDataAdapter15.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
													sqlDataAdapter15.SelectCommand.Parameters["@PId"].Value = num33;
													sqlDataAdapter15.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
													sqlDataAdapter15.SelectCommand.Parameters["@CId"].Value = num32;
													DataSet dataSet15 = new DataSet();
													sqlDataAdapter15.Fill(dataSet15);
													double num36 = 0.0;
													if (dataSet15.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet15.Tables[0].Rows.Count > 0)
													{
														num36 = Convert.ToDouble(decimal.Parse(dataSet15.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
													}
													num35 = num35 * Convert.ToDouble(decimal.Parse(dataSet14.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num36;
												}
												for (int m = 0; m < list4.Count; m++)
												{
													num32 = list4[m++];
													num33 = list4[m];
													double num37 = 1.0;
													List<double> list5 = new List<double>();
													list5 = fun.BOMTreeQty(text19, num33, num32);
													for (int n = 0; n < list5.Count; n++)
													{
														num37 *= list5[n];
													}
													list5.Clear();
													SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
													sqlDataAdapter16.SelectCommand.CommandType = CommandType.StoredProcedure;
													sqlDataAdapter16.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
													sqlDataAdapter16.SelectCommand.Parameters["@CompId"].Value = CompId;
													sqlDataAdapter16.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
													sqlDataAdapter16.SelectCommand.Parameters["@WONo"].Value = text19;
													sqlDataAdapter16.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
													sqlDataAdapter16.SelectCommand.Parameters["@PId"].Value = num33;
													sqlDataAdapter16.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
													sqlDataAdapter16.SelectCommand.Parameters["@CId"].Value = num32;
													DataSet dataSet16 = new DataSet();
													sqlDataAdapter16.Fill(dataSet16, "tblDG_BOM_Master");
													SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
													sqlDataAdapter17.SelectCommand.CommandType = CommandType.StoredProcedure;
													sqlDataAdapter17.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
													sqlDataAdapter17.SelectCommand.Parameters["@CompId"].Value = CompId;
													sqlDataAdapter17.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
													sqlDataAdapter17.SelectCommand.Parameters["@WONo"].Value = text19;
													sqlDataAdapter17.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
													sqlDataAdapter17.SelectCommand.Parameters["@ItemId"].Value = dataSet16.Tables[0].Rows[0]["ItemId"].ToString();
													sqlDataAdapter17.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
													sqlDataAdapter17.SelectCommand.Parameters["@PId"].Value = num33;
													sqlDataAdapter17.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
													sqlDataAdapter17.SelectCommand.Parameters["@CId"].Value = num32;
													DataSet dataSet17 = new DataSet();
													sqlDataAdapter17.Fill(dataSet17);
													double num38 = 0.0;
													if (dataSet17.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet17.Tables[0].Rows.Count > 0)
													{
														num38 = Convert.ToDouble(decimal.Parse(dataSet17.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
													}
													if (num37 >= 0.0)
													{
														num35 = num35 * Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num38;
													}
												}
												if (num35 > 0.0)
												{
													double num39 = 0.0;
													double num40 = 0.0;
													double num41 = 0.0;
													double num42 = 0.0;
													num41 = Convert.ToDouble(decimal.Parse(dataSet11.Tables[0].Rows[j][4].ToString()).ToString("N3"));
													num40 = Convert.ToDouble(decimal.Parse((num35 * num41).ToString()).ToString("N3"));
													num42 = Convert.ToDouble(decimal.Parse(num29.ToString()).ToString("N3"));
													num39 = num40 - num42;
													num27 = ((!(num39 > 0.0)) ? 0.0 : num39);
												}
												else
												{
													num27 = 0.0;
												}
												double num43 = 0.0;
												double num44 = 0.0;
												if (Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && Convert.ToDouble(decimal.Parse(num27.ToString()).ToString("N3")) >= 0.0)
												{
													if (Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(num27.ToString()).ToString("N3")))
													{
														num43 = Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(num27.ToString()).ToString("N3"));
														num44 = Convert.ToDouble(decimal.Parse(num27.ToString()).ToString("N3"));
													}
													else if (Convert.ToDouble(decimal.Parse(num27.ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
													{
														num43 = 0.0;
														num44 = Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
													}
												}
												if (num44 > 0.0)
												{
													if (text19 != text12)
													{
														SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter("GetSchTime_WISNo", sqlConnection);
														sqlDataAdapter18.SelectCommand.CommandType = CommandType.StoredProcedure;
														sqlDataAdapter18.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
														sqlDataAdapter18.SelectCommand.Parameters["@CompId"].Value = CompId;
														sqlDataAdapter18.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
														sqlDataAdapter18.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
														DataSet dataSet18 = new DataSet();
														sqlDataAdapter18.Fill(dataSet18);
														text11 = ((dataSet18.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet18.Tables[0].Rows[0]["WISNo"].ToString()) + 1).ToString("D4"));
														string cmdText13 = fun.insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text11 + "','" + text19 + "'");
														SqlCommand sqlCommand5 = new SqlCommand(cmdText13, sqlConnection);
														sqlCommand5.ExecuteNonQuery();
														string cmdText14 = fun.select1("Id", "tblInv_WIS_Master Order By Id Desc");
														SqlCommand selectCommand11 = new SqlCommand(cmdText14, sqlConnection);
														SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand11);
														DataSet dataSet19 = new DataSet();
														sqlDataAdapter19.Fill(dataSet19, "tblDG_Item_Master");
														if (dataSet19.Tables[0].Rows.Count > 0)
														{
															num14 = Convert.ToInt32(dataSet19.Tables[0].Rows[0][0]);
														}
													}
													string cmdText15 = fun.insert("tblInv_WIS_Details", "WISNo,PId,CId,ItemId,IssuedQty,MId", string.Concat("'", text11, "','", dataSet11.Tables[0].Rows[j][2], "','", dataSet11.Tables[0].Rows[j][3], "','", dataSet11.Tables[0].Rows[j]["ItemId"].ToString(), "','", num44.ToString(), "','", num14, "'"));
													SqlCommand sqlCommand6 = new SqlCommand(cmdText15, sqlConnection);
													sqlCommand6.ExecuteNonQuery();
													string cmdText16 = fun.update("tblDG_Item_Master", "StockQty='" + num43 + "'", "CompId='" + CompId + "' AND Id='" + dataSet11.Tables[0].Rows[j]["ItemId"].ToString() + "'");
													SqlCommand sqlCommand7 = new SqlCommand(cmdText16, sqlConnection);
													sqlCommand7.ExecuteNonQuery();
													text12 = text19;
													num15++;
													value = dataSet9.Tables[0].Rows[0]["ItemCode"].ToString();
													value2 = dataSet9.Tables[0].Rows[0]["ManfDesc"].ToString();
													value3 = num43.ToString();
													value4 = dataSet9.Tables[0].Rows[0]["StockQty"].ToString();
												}
												num35 = 0.0;
												list2.Clear();
											}
											list.Clear();
										}
									}
								}
								else if (Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Process"]) == 2 && text19 != string.Empty && num22 > 0.0)
								{
									empty2 = dataSet9.Tables[0].Rows[0]["ItemCode"].ToString();
									empty3 = empty2.Remove(empty2.Length - 1, 1) + "0";
									string cmdText17 = fun.select("Id,StockQty,ItemCode,ManfDesc", "tblDG_Item_Master", "CompId='" + CompId + "' AND ItemCode='" + empty3 + "'");
									SqlCommand selectCommand12 = new SqlCommand(cmdText17, sqlConnection);
									SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand12);
									DataSet dataSet20 = new DataSet();
									sqlDataAdapter20.Fill(dataSet20);
									if (dataSet20.Tables[0].Rows.Count > 0)
									{
										num25 = Convert.ToInt32(dataSet20.Tables[0].Rows[0]["Id"]);
										Convert.ToDouble(decimal.Parse(dataSet20.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
										if (num10 == 1)
										{
											string cmdText18 = "Insert into tblInv_MaterialRequisition_Master(SysDate,SysTime,CompId,FinYearId,SessionId,MRSNo) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text2 + "')";
											SqlCommand sqlCommand8 = new SqlCommand(cmdText18, sqlConnection);
											sqlCommand8.ExecuteNonQuery();
											num10 = 0;
											string cmdText19 = fun.select("Id", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' Order by Id desc");
											SqlCommand selectCommand13 = new SqlCommand(cmdText19, sqlConnection);
											SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand13);
											DataSet dataSet21 = new DataSet();
											sqlDataAdapter21.Fill(dataSet21, "tblInv_MaterialRequisition_Master");
											text6 = dataSet21.Tables[0].Rows[0]["Id"].ToString();
										}
										string cmdText20 = "Insert into tblInv_MaterialRequisition_Details(MId,MRSNo,ItemId,WONo,DeptId,ReqQty,Remarks) VALUES  ('" + text6 + "','" + text2 + "','" + text15 + "','" + text19 + "','1','" + Convert.ToDouble(decimal.Parse(num22.ToString()).ToString("N3")) + "','-')";
										SqlCommand sqlCommand9 = new SqlCommand(cmdText20, sqlConnection);
										sqlCommand9.ExecuteNonQuery();
										string cmdText21 = fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.ReqQty", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialRequisition_Master.CompId='" + CompId + "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id='" + text6 + "'And tblInv_MaterialRequisition_Details.ItemId='" + text15 + "'");
										SqlCommand selectCommand14 = new SqlCommand(cmdText21, sqlConnection);
										SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand14);
										DataSet dataSet22 = new DataSet();
										new DataTable();
										sqlDataAdapter22.Fill(dataSet22);
										double num45 = 0.0;
										double num46 = 0.0;
										for (int num47 = 0; num47 < dataSet22.Tables[0].Rows.Count; num47++)
										{
											if (num12 == 1)
											{
												string cmdText22 = fun.insert("tblInv_MaterialIssue_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MINNo,MRSNo,MRSId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text3 + "','" + text2 + "','" + text6 + "'");
												SqlCommand sqlCommand10 = new SqlCommand(cmdText22, sqlConnection);
												sqlCommand10.ExecuteNonQuery();
												num12 = 0;
												string cmdText23 = fun.select("Id", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' Order by Id Desc");
												SqlCommand selectCommand15 = new SqlCommand(cmdText23, sqlConnection);
												SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand15);
												DataSet dataSet23 = new DataSet();
												sqlDataAdapter23.Fill(dataSet23);
												text7 = dataSet23.Tables[0].Rows[0]["Id"].ToString();
											}
											double num48 = 0.0;
											string cmdText24 = fun.select("sum(tblInv_MaterialIssue_Details.IssueQty) as sum_IssuedQty", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details", "tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Details.MRSId='" + dataSet22.Tables[0].Rows[num47]["Id"].ToString() + "'");
											SqlCommand selectCommand16 = new SqlCommand(cmdText24, sqlConnection);
											SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand16);
											DataSet dataSet24 = new DataSet();
											sqlDataAdapter24.Fill(dataSet24);
											if (dataSet24.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value)
											{
												num48 = Convert.ToDouble(decimal.Parse(dataSet24.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
											}
											num45 = Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[num47]["ReqQty"].ToString()).ToString("N3"));
											if (num22 >= num45)
											{
												num46 = num22 - num45;
												num48 = num45;
											}
											else
											{
												num46 = 0.0;
												num48 = num22;
											}
											string cmdText25 = fun.insert("tblInv_MaterialIssue_Details", "MId,MINNo,MRSId,IssueQty", "'" + text7 + "','" + text3 + "','" + dataSet22.Tables[0].Rows[num47]["Id"].ToString() + "','" + num48 + "'");
											SqlCommand sqlCommand11 = new SqlCommand(cmdText25, sqlConnection);
											sqlCommand11.ExecuteNonQuery();
											string cmdText26 = fun.update("tblDG_Item_Master", "StockQty='" + num46 + "'", "CompId='" + CompId + "' AND Id='" + text15 + "'");
											SqlCommand sqlCommand12 = new SqlCommand(cmdText26, sqlConnection);
											sqlCommand12.ExecuteNonQuery();
										}
										if (num11 == 1)
										{
											string cmdText27 = "Insert into tblInv_MaterialReturn_Master(SysDate,SysTime,CompId,FinYearId,SessionId,MRNNo) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text4 + "')";
											SqlCommand sqlCommand13 = new SqlCommand(cmdText27, sqlConnection);
											sqlCommand13.ExecuteNonQuery();
											num11 = 0;
											string cmdText28 = fun.select("Id", "tblInv_MaterialReturn_Master", "CompId='" + CompId + "' Order by Id desc");
											SqlCommand selectCommand17 = new SqlCommand(cmdText28, sqlConnection);
											SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand17);
											DataSet dataSet25 = new DataSet();
											sqlDataAdapter25.Fill(dataSet25, "tblInv_MaterialReturn_Master");
											text8 = dataSet25.Tables[0].Rows[0]["Id"].ToString();
										}
										string cmdText29 = "Insert into tblInv_MaterialReturn_Details(MId,MRNNo,ItemId,DeptId,WONo,RetQty,Remarks) VALUES  ('" + text8 + "','" + text4 + "','" + num25 + "','1','" + text19 + "','" + num22 + "','-')";
										SqlCommand sqlCommand14 = new SqlCommand(cmdText29, sqlConnection);
										sqlCommand14.ExecuteNonQuery();
										double num49 = 0.0;
										string cmdText30 = fun.select("tblInv_MaterialReturn_Details.Id,tblInv_MaterialReturn_Master.MRNNo,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Master,tblInv_MaterialReturn_Details", "tblInv_MaterialReturn_Master.CompId='" + CompId + "' AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.Id='" + text8 + "' And tblInv_MaterialReturn_Details.ItemId='" + num25 + "'");
										SqlCommand selectCommand18 = new SqlCommand(cmdText30, sqlConnection);
										SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand18);
										DataSet dataSet26 = new DataSet();
										sqlDataAdapter26.Fill(dataSet26);
										for (int num50 = 0; num50 < dataSet26.Tables[0].Rows.Count; num50++)
										{
											double num51 = 0.0;
											double num52 = 0.0;
											double num53 = 0.0;
											double num54 = 0.0;
											num52 = Convert.ToDouble(decimal.Parse(dataSet26.Tables[0].Rows[num50]["RetQty"].ToString()).ToString("N3"));
											num51 = num52;
											string cmdText31 = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_AcceptedQty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + dataSet26.Tables[0].Rows[num50]["Id"].ToString() + "'");
											SqlCommand selectCommand19 = new SqlCommand(cmdText31, sqlConnection);
											SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand19);
											DataSet dataSet27 = new DataSet();
											sqlDataAdapter27.Fill(dataSet27);
											if (dataSet27.Tables[0].Rows[0]["sum_AcceptedQty"] != DBNull.Value)
											{
												num54 = Convert.ToDouble(decimal.Parse(dataSet27.Tables[0].Rows[0]["sum_AcceptedQty"].ToString()).ToString("N3"));
											}
											num53 = num52 - num54;
											if (!(num51 > 0.0) || !fun.NumberValidationQty(num51.ToString()) || !(num53 >= num51))
											{
												continue;
											}
											if (num13 == 1)
											{
												string cmdText32 = fun.insert("tblQc_MaterialReturnQuality_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MRQNNo,MRNNo,MRNId", string.Concat("'", CDate, "','", CTime, "','", CompId, "','", FinYearId, "','", sId, "','", text5, "','", dataSet26.Tables[0].Rows[num50]["MRNNo"], "','", text8, "'"));
												SqlCommand sqlCommand15 = new SqlCommand(cmdText32, sqlConnection);
												sqlCommand15.ExecuteNonQuery();
												num13 = 0;
												string cmdText33 = fun.select("Id", "tblQc_MaterialReturnQuality_Master", "CompId='" + CompId + "' Order by Id Desc");
												SqlCommand selectCommand20 = new SqlCommand(cmdText33, sqlConnection);
												SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(selectCommand20);
												DataSet dataSet28 = new DataSet();
												sqlDataAdapter28.Fill(dataSet28, "tblQc_MaterialReturnQuality_Master");
												text9 = dataSet28.Tables[0].Rows[0]["Id"].ToString();
											}
											string cmdText34 = fun.insert("tblQc_MaterialReturnQuality_Details", "MId,MRQNNo,MRNId,AcceptedQty", string.Concat("'", text9, "','", text5, "','", dataSet26.Tables[0].Rows[num50]["Id"], "','", num51, "'"));
											SqlCommand sqlCommand16 = new SqlCommand(cmdText34, sqlConnection);
											sqlCommand16.ExecuteNonQuery();
											string cmdText35 = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + num25 + "'");
											SqlCommand selectCommand21 = new SqlCommand(cmdText35, sqlConnection);
											SqlDataAdapter sqlDataAdapter29 = new SqlDataAdapter(selectCommand21);
											DataSet dataSet29 = new DataSet();
											sqlDataAdapter29.Fill(dataSet29);
											if (dataSet29.Tables[0].Rows.Count > 0)
											{
												num49 = Convert.ToDouble(decimal.Parse(dataSet29.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + num51;
											}
											string cmdText36 = fun.update("tblDG_Item_Master", "StockQty='" + num49 + "'", "CompId='" + CompId + "' AND Id='" + num25 + "'");
											SqlCommand sqlCommand17 = new SqlCommand(cmdText36, sqlConnection);
											sqlCommand17.ExecuteNonQuery();
											string cmdText37 = fun.select("ReleaseWIS", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND WONo='" + text19 + "'");
											SqlCommand selectCommand22 = new SqlCommand(cmdText37, sqlConnection);
											SqlDataAdapter sqlDataAdapter30 = new SqlDataAdapter(selectCommand22);
											DataSet dataSet30 = new DataSet();
											sqlDataAdapter30.Fill(dataSet30);
											if (dataSet30.Tables[0].Rows.Count <= 0 || Convert.ToInt32(dataSet30.Tables[0].Rows[0][0]) != 1 || !(text19 != ""))
											{
												continue;
											}
											SqlDataAdapter sqlDataAdapter31 = new SqlDataAdapter("GQN_BOM_Details", sqlConnection);
											sqlDataAdapter31.SelectCommand.CommandType = CommandType.StoredProcedure;
											sqlDataAdapter31.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
											sqlDataAdapter31.SelectCommand.Parameters["@CompId"].Value = CompId;
											sqlDataAdapter31.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
											sqlDataAdapter31.SelectCommand.Parameters["@WONo"].Value = text19;
											sqlDataAdapter31.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
											sqlDataAdapter31.SelectCommand.Parameters["@ItemId"].Value = num25.ToString();
											DataSet dataSet31 = new DataSet();
											sqlDataAdapter31.Fill(dataSet31, "tblDG_BOM_Master");
											double num55 = 0.0;
											double num56 = 0.0;
											for (int num57 = 0; num57 < dataSet31.Tables[0].Rows.Count; num57++)
											{
												DataSet dataSet32 = new DataSet();
												SqlDataAdapter sqlDataAdapter32 = new SqlDataAdapter("GetSchTime_Item_Details", sqlConnection);
												sqlDataAdapter32.SelectCommand.CommandType = CommandType.StoredProcedure;
												sqlDataAdapter32.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
												sqlDataAdapter32.SelectCommand.Parameters["@CompId"].Value = CompId;
												sqlDataAdapter32.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
												sqlDataAdapter32.SelectCommand.Parameters["@Id"].Value = dataSet31.Tables[0].Rows[num57][0].ToString();
												sqlDataAdapter32.Fill(dataSet32, "tblDG_Item_Master");
												double num58 = 1.0;
												List<double> list6 = new List<double>();
												list6 = fun.BOMTreeQty(text19, Convert.ToInt32(dataSet31.Tables[0].Rows[num57][2]), Convert.ToInt32(dataSet31.Tables[0].Rows[num57][3]));
												for (int num59 = 0; num59 < list6.Count; num59++)
												{
													num58 *= list6[num59];
												}
												SqlDataAdapter sqlDataAdapter33 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
												sqlDataAdapter33.SelectCommand.CommandType = CommandType.StoredProcedure;
												sqlDataAdapter33.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
												sqlDataAdapter33.SelectCommand.Parameters["@CompId"].Value = CompId;
												sqlDataAdapter33.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
												sqlDataAdapter33.SelectCommand.Parameters["@WONo"].Value = text19;
												sqlDataAdapter33.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
												sqlDataAdapter33.SelectCommand.Parameters["@ItemId"].Value = dataSet31.Tables[0].Rows[num57]["ItemId"].ToString();
												sqlDataAdapter33.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
												sqlDataAdapter33.SelectCommand.Parameters["@PId"].Value = dataSet31.Tables[0].Rows[num57]["PId"].ToString();
												sqlDataAdapter33.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
												sqlDataAdapter33.SelectCommand.Parameters["@CId"].Value = dataSet31.Tables[0].Rows[num57]["CId"].ToString();
												DataSet dataSet33 = new DataSet();
												sqlDataAdapter33.Fill(dataSet33);
												double num60 = 0.0;
												if (dataSet33.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet33.Tables[0].Rows.Count > 0)
												{
													num60 = Convert.ToDouble(decimal.Parse(dataSet33.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
												}
												if (num58 >= 0.0)
												{
													num55 = Convert.ToDouble(decimal.Parse((num58 - num60).ToString()).ToString("N3"));
												}
												if (dataSet31.Tables[0].Rows[num57]["PId"].ToString() == "0")
												{
													num56 = num55;
												}
												if (dataSet31.Tables[0].Rows[num57]["PId"].ToString() != "0")
												{
													List<int> list7 = new List<int>();
													list7 = fun.CalBOMTreeQty(CompId, text19, Convert.ToInt32(dataSet31.Tables[0].Rows[num57][2]), Convert.ToInt32(dataSet31.Tables[0].Rows[num57][3]));
													int num61 = 0;
													int num62 = 0;
													int num63 = 0;
													List<int> list8 = new List<int>();
													List<int> list9 = new List<int>();
													for (int num64 = list7.Count; num64 > 0; num64--)
													{
														if (list7.Count > 2)
														{
															list9.Add(list7[num64 - 1]);
														}
														else
														{
															list8.Add(list7[num61]);
															num61++;
														}
													}
													double num65 = 1.0;
													for (int num66 = 0; num66 < list8.Count; num66++)
													{
														num63 = list8[num66++];
														num62 = list8[num66];
														SqlDataAdapter sqlDataAdapter34 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
														sqlDataAdapter34.SelectCommand.CommandType = CommandType.StoredProcedure;
														sqlDataAdapter34.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
														sqlDataAdapter34.SelectCommand.Parameters["@CompId"].Value = CompId;
														sqlDataAdapter34.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
														sqlDataAdapter34.SelectCommand.Parameters["@WONo"].Value = text19;
														sqlDataAdapter34.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
														sqlDataAdapter34.SelectCommand.Parameters["@PId"].Value = num63;
														sqlDataAdapter34.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
														sqlDataAdapter34.SelectCommand.Parameters["@CId"].Value = num62;
														DataSet dataSet34 = new DataSet();
														sqlDataAdapter34.Fill(dataSet34);
														SqlDataAdapter sqlDataAdapter35 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
														sqlDataAdapter35.SelectCommand.CommandType = CommandType.StoredProcedure;
														sqlDataAdapter35.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
														sqlDataAdapter35.SelectCommand.Parameters["@CompId"].Value = CompId;
														sqlDataAdapter35.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
														sqlDataAdapter35.SelectCommand.Parameters["@WONo"].Value = text19;
														sqlDataAdapter35.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
														sqlDataAdapter35.SelectCommand.Parameters["@ItemId"].Value = dataSet34.Tables[0].Rows[0]["ItemId"].ToString();
														sqlDataAdapter35.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
														sqlDataAdapter35.SelectCommand.Parameters["@PId"].Value = num63;
														sqlDataAdapter35.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
														sqlDataAdapter35.SelectCommand.Parameters["@CId"].Value = num62;
														DataSet dataSet35 = new DataSet();
														sqlDataAdapter35.Fill(dataSet35);
														double num67 = 0.0;
														if (dataSet35.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet35.Tables[0].Rows.Count > 0)
														{
															num67 = Convert.ToDouble(decimal.Parse(dataSet35.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
														}
														num65 = num65 * Convert.ToDouble(decimal.Parse(dataSet34.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num67;
													}
													for (int num68 = 0; num68 < list9.Count; num68++)
													{
														num62 = list9[num68++];
														num63 = list9[num68];
														double num69 = 1.0;
														List<double> list10 = new List<double>();
														list10 = fun.BOMTreeQty(text19, num63, num62);
														for (int num70 = 0; num70 < list10.Count; num70++)
														{
															num69 *= list10[num70];
														}
														list10.Clear();
														SqlDataAdapter sqlDataAdapter36 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", sqlConnection);
														sqlDataAdapter36.SelectCommand.CommandType = CommandType.StoredProcedure;
														sqlDataAdapter36.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
														sqlDataAdapter36.SelectCommand.Parameters["@CompId"].Value = CompId;
														sqlDataAdapter36.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
														sqlDataAdapter36.SelectCommand.Parameters["@WONo"].Value = text19;
														sqlDataAdapter36.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
														sqlDataAdapter36.SelectCommand.Parameters["@PId"].Value = num63;
														sqlDataAdapter36.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
														sqlDataAdapter36.SelectCommand.Parameters["@CId"].Value = num62;
														DataSet dataSet36 = new DataSet();
														sqlDataAdapter36.Fill(dataSet36, "tblDG_BOM_Master");
														SqlDataAdapter sqlDataAdapter37 = new SqlDataAdapter("GetSchTime_TWIS_Qty", sqlConnection);
														sqlDataAdapter37.SelectCommand.CommandType = CommandType.StoredProcedure;
														sqlDataAdapter37.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
														sqlDataAdapter37.SelectCommand.Parameters["@CompId"].Value = CompId;
														sqlDataAdapter37.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
														sqlDataAdapter37.SelectCommand.Parameters["@WONo"].Value = text19;
														sqlDataAdapter37.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
														sqlDataAdapter37.SelectCommand.Parameters["@ItemId"].Value = dataSet36.Tables[0].Rows[0]["ItemId"].ToString();
														sqlDataAdapter37.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
														sqlDataAdapter37.SelectCommand.Parameters["@PId"].Value = num63;
														sqlDataAdapter37.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
														sqlDataAdapter37.SelectCommand.Parameters["@CId"].Value = num62;
														DataSet dataSet37 = new DataSet();
														sqlDataAdapter37.Fill(dataSet37);
														double num71 = 0.0;
														if (dataSet37.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet37.Tables[0].Rows.Count > 0)
														{
															num71 = Convert.ToDouble(decimal.Parse(dataSet37.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
														}
														if (num69 >= 0.0)
														{
															num65 = num65 * Convert.ToDouble(decimal.Parse(dataSet36.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num71;
														}
													}
													num56 = ((!(num65 > 0.0)) ? 0.0 : Convert.ToDouble(decimal.Parse((num65 * Convert.ToDouble(dataSet31.Tables[0].Rows[num57][4]) - num60).ToString()).ToString("N3")));
													double num72 = 0.0;
													double num73 = 0.0;
													if (Convert.ToDouble(decimal.Parse(dataSet32.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && Convert.ToDouble(decimal.Parse(num56.ToString()).ToString("N3")) >= 0.0)
													{
														if (Convert.ToDouble(decimal.Parse(dataSet32.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(num56.ToString()).ToString("N3")))
														{
															num72 = Convert.ToDouble(decimal.Parse(dataSet32.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(num56.ToString()).ToString("N3"));
															num73 = Convert.ToDouble(decimal.Parse(num56.ToString()).ToString("N3"));
														}
														else if (Convert.ToDouble(decimal.Parse(num56.ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(dataSet32.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
														{
															num72 = 0.0;
															num73 = Convert.ToDouble(decimal.Parse(dataSet32.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
														}
													}
													if (num73 > 0.0)
													{
														if (text19 != text12)
														{
															SqlDataAdapter sqlDataAdapter38 = new SqlDataAdapter("GetSchTime_WISNo", sqlConnection);
															sqlDataAdapter38.SelectCommand.CommandType = CommandType.StoredProcedure;
															sqlDataAdapter38.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
															sqlDataAdapter38.SelectCommand.Parameters["@CompId"].Value = CompId;
															sqlDataAdapter38.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
															sqlDataAdapter38.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
															DataSet dataSet38 = new DataSet();
															sqlDataAdapter38.Fill(dataSet38);
															text11 = ((dataSet38.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet38.Tables[0].Rows[0]["WISNo"].ToString()) + 1).ToString("D4"));
															string cmdText38 = fun.insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text11 + "','" + text19 + "'");
															SqlCommand sqlCommand18 = new SqlCommand(cmdText38, sqlConnection);
															sqlCommand18.ExecuteNonQuery();
															string cmdText39 = fun.select1("Id", "tblInv_WIS_Master Order By Id Desc");
															SqlCommand selectCommand23 = new SqlCommand(cmdText39, sqlConnection);
															SqlDataAdapter sqlDataAdapter39 = new SqlDataAdapter(selectCommand23);
															DataSet dataSet39 = new DataSet();
															sqlDataAdapter39.Fill(dataSet39, "tblDG_Item_Master");
															if (dataSet39.Tables[0].Rows.Count > 0)
															{
																num14 = Convert.ToInt32(dataSet39.Tables[0].Rows[0][0]);
															}
														}
														string cmdText40 = fun.insert("tblInv_WIS_Details", "WISNo,PId,CId,ItemId,IssuedQty,MId", string.Concat("'", text11, "','", dataSet31.Tables[0].Rows[num57][2], "','", dataSet31.Tables[0].Rows[num57][3], "','", dataSet31.Tables[0].Rows[num57]["ItemId"].ToString(), "','", num73.ToString(), "','", num14, "'"));
														SqlCommand sqlCommand19 = new SqlCommand(cmdText40, sqlConnection);
														sqlCommand19.ExecuteNonQuery();
														string cmdText41 = fun.update("tblDG_Item_Master", "StockQty='" + num72 + "'", "CompId='" + CompId + "' AND Id='" + dataSet31.Tables[0].Rows[num57]["ItemId"].ToString() + "'");
														SqlCommand sqlCommand20 = new SqlCommand(cmdText41, sqlConnection);
														sqlCommand20.ExecuteNonQuery();
														text12 = text19;
														num15++;
														value = dataSet20.Tables[0].Rows[0]["ItemCode"].ToString();
														value2 = dataSet20.Tables[0].Rows[0]["ManfDesc"].ToString();
														value3 = num72.ToString();
														value4 = dataSet9.Tables[0].Rows[0]["StockQty"].ToString();
													}
													num65 = 0.0;
													list7.Clear();
												}
												list6.Clear();
											}
										}
									}
								}
							}
							num3++;
						}
						dataRow[0] = num15;
						dataRow[1] = value;
						dataRow[2] = value2;
						dataRow[3] = value4;
						dataRow[4] = value3;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
					if (dataTable.Rows.Count > 0 && num15 != 0)
					{
						MailMessage mailMessage = new MailMessage();
						string text21 = "<table width='100%' border='1' style='font-size:10pt'>";
						text21 += "<tr>";
						for (int num74 = 0; num74 < dataTable.Columns.Count; num74++)
						{
							string text22 = string.Empty;
							if (dataTable.Columns[num74].ColumnName == "ItemCode")
							{
								text22 = "width='15%'";
							}
							string text23 = text21;
							text21 = text23 + "<td align='center'" + text22 + ">" + dataTable.Columns[num74].ColumnName + "</td>";
						}
						text21 += "</tr>";
						for (int num75 = 0; num75 < dataTable.Rows.Count; num75++)
						{
							text21 += "<tr>";
							for (int num76 = 0; num76 < dataTable.Columns.Count; num76++)
							{
								text21 = text21 + "<td>" + dataTable.Rows[num75][num76].ToString() + "</td>";
							}
							text21 += "</tr>";
						}
						text21 += "</table>";
						string text24 = "";
						string cmdText42 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
						SqlCommand selectCommand24 = new SqlCommand(cmdText42, sqlConnection);
						SqlDataAdapter sqlDataAdapter40 = new SqlDataAdapter(selectCommand24);
						DataSet dataSet40 = new DataSet();
						sqlDataAdapter40.Fill(dataSet40);
						if (dataSet40.Tables[0].Rows.Count > 0)
						{
							SmtpMail.SmtpServer = dataSet40.Tables[0].Rows[0]["MailServerIp"].ToString();
							text24 = dataSet40.Tables[0].Rows[0]["ErpSysmail"].ToString();
						}
						mailMessage.From = text24;
						mailMessage.To = "ashish.mahindre@synergytechs.com";
						mailMessage.Bcc = "ashish.mahindre@synergytechs.com";
						mailMessage.Subject = "WIS Trace";
						mailMessage.Body = "Work Order No: " + text12 + "<br><br>" + text21 + "<br><br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
						mailMessage.BodyFormat = MailFormat.Html;
					}
				}
				else
				{
					string empty4 = string.Empty;
					empty4 = "Invalid input data.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
				}
				if (num3 > 0)
				{
					base.Response.Redirect("GoodsQualityNote_GQN_New.aspx?ModId=10&SubModId=46");
				}
			}
			if (e.CommandName == "downloadImg")
			{
				foreach (GridViewRow row3 in GridView2.Rows)
				{
					int num77 = Convert.ToInt32(((Label)row3.FindControl("lblItemId")).Text);
					base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num77 + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
				}
			}
			if (e.CommandName == "downloadSpec")
			{
				foreach (GridViewRow row4 in GridView2.Rows)
				{
					int num78 = Convert.ToInt32(((Label)row4.FindControl("lblItemId")).Text);
					base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num78 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
				}
			}
			if (e.CommandName == "Cancel")
			{
				base.Response.Redirect("GoodsQualityNote_GQN_New.aspx?ModId=10&SubModId=46");
			}
			Thread.Sleep(1000);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			GetValidate();
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((TextBox)row.FindControl("txtDeviatedQty")).Visible = true;
					((TextBox)row.FindControl("txtSegregatedQty")).Visible = true;
					((TextBox)row.FindControl("txtNormalAccQty")).Visible = true;
					((DropDownList)row.FindControl("drprejreason")).Visible = true;
					((TextBox)row.FindControl("txtRemarks")).Visible = true;
					((Label)row.FindControl("lblaccpQty")).Visible = false;
					if (((TextBox)row.FindControl("txtNormalAccQty")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("ReqNormalQty")).Visible = true;
						((RegularExpressionValidator)row.FindControl("RegNormalQty")).Visible = true;
					}
					if (((TextBox)row.FindControl("txtDeviatedQty")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("ReqDeviatedQty")).Visible = true;
						((RegularExpressionValidator)row.FindControl("RegularExpressionValidator2")).Visible = true;
					}
					if (((TextBox)row.FindControl("txtSegregatedQty")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("ReqSegregatedQty")).Visible = true;
						((RegularExpressionValidator)row.FindControl("RegularExpressionValidator3")).Visible = true;
					}
					if (((Label)row.FindControl("lblahid")).Text == "42")
					{
						((TextBox)row.FindControl("txtSN")).Visible = true;
						if (((TextBox)row.FindControl("txtSN")).Visible)
						{
							((RequiredFieldValidator)row.FindControl("ReqSn")).Visible = true;
						}
						else if (!((TextBox)row.FindControl("txtSN")).Visible)
						{
							((RequiredFieldValidator)row.FindControl("ReqSn")).Visible = false;
						}
						((TextBox)row.FindControl("txtPN")).Visible = true;
						if (((TextBox)row.FindControl("txtPN")).Visible)
						{
							((RequiredFieldValidator)row.FindControl("ReqPn")).Visible = true;
						}
						else if (!((TextBox)row.FindControl("txtPN")).Visible)
						{
							((RequiredFieldValidator)row.FindControl("ReqPn")).Visible = false;
						}
					}
				}
				else
				{
					((TextBox)row.FindControl("txtDeviatedQty")).Visible = false;
					((TextBox)row.FindControl("txtSegregatedQty")).Visible = false;
					((TextBox)row.FindControl("txtNormalAccQty")).Visible = false;
					((DropDownList)row.FindControl("drprejreason")).Visible = false;
					((TextBox)row.FindControl("txtRemarks")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqNormalQty")).Visible = false;
					((RegularExpressionValidator)row.FindControl("RegNormalQty")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqDeviatedQty")).Visible = false;
					((RegularExpressionValidator)row.FindControl("RegularExpressionValidator2")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqSegregatedQty")).Visible = false;
					((RegularExpressionValidator)row.FindControl("RegularExpressionValidator3")).Visible = false;
					((Label)row.FindControl("lblaccpQty")).Visible = true;
					if (((Label)row.FindControl("lblahid")).Text != "42")
					{
						((TextBox)row.FindControl("txtSN")).Visible = false;
						((TextBox)row.FindControl("txtPN")).Visible = false;
					}
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
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsQualityNote_GQN_New.aspx?ModId=10&SubModId=46");
	}
}

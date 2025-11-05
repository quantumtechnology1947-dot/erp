using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_QualityControl_Transactions_GoodsQualityNote_GQN_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string poNo = "";

	private string GINNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string GRRNo = "";

	private string GQNNo = "";

	protected Label lblGQn;

	protected Label lblGrr;

	protected Label lblGIn;

	protected Label lblChNo;

	protected Label lblDate;

	protected Label lblSupplier;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			GQNNo = base.Request.QueryString["GQNNo"].ToString();
			GRRNo = base.Request.QueryString["GRRNo"].ToString();
			GINNo = base.Request.QueryString["GINNo"].ToString();
			SupplierNo = base.Request.QueryString["SUPId"].ToString();
			poNo = base.Request.QueryString["PONo"].ToString();
			FyId = base.Request.QueryString["FyId"].ToString();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
			if (!Page.IsPostBack)
			{
				lblGQn.Text = GQNNo;
				lblGrr.Text = GRRNo;
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "GINNo='" + GINNo + "' AND CompId='" + CompId + "' AND FinYearId='" + FyId + "'");
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
		}
		catch (Exception)
		{
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
			string cmdText = fun.select("tblQc_MaterialQuality_Details.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.RejectedQty,tblQc_MaterialQuality_Details.RejectionReason,tblQc_MaterialQuality_Details.Remarks,tblQc_MaterialQuality_Master.GRRNo,tblQc_MaterialQuality_Master.GRRId,tblQc_MaterialQuality_Details.GRRId as DGRRId,tblQc_MaterialQuality_Master.FinYearId", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("InvQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejReason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RejectionReason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("sn", typeof(string)));
			dataTable.Columns.Add(new DataColumn("pn", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			int num = 0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblinv_MaterialReceived_Master.GINNo,tblinv_MaterialReceived_Master.GINId,tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Details.POId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.Id='" + dataSet.Tables[0].Rows[i]["GRRId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.Id='" + dataSet.Tables[0].Rows[i]["DGRRId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Details.POId='" + dataSet2.Tables[0].Rows[0]["POId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText4 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet3.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.FinYearId='" + dataSet3.Tables[0].Rows[0]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.Id='" + dataSet2.Tables[0].Rows[0]["POId"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText5 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet4.Tables[0].Rows[0]["PRNo"].ToString() + "'AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + dataSet4.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.FinYearId='" + dataSet3.Tables[0].Rows[0]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						string cmdText6 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet5.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							if (dataSet6.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet6.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[15] = "View";
							}
							else
							{
								dataRow[15] = "";
							}
							if (dataSet6.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet6.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[16] = "View";
							}
							else
							{
								dataRow[16] = "";
							}
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet6.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText7 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet6.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter7.Fill(dataSet7);
							if (dataSet7.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet7.Tables[0].Rows[0][0].ToString();
							}
							value4 = dataSet5.Tables[0].Rows[0]["AHId"].ToString();
							num = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ItemId"]);
						}
					}
				}
				else if (dataSet4.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText8 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet4.Tables[0].Rows[0]["SPRNo"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + dataSet4.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.FinYearId='" + dataSet3.Tables[0].Rows[0]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8);
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						string cmdText9 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet8.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9);
						if (dataSet9.Tables[0].Rows.Count > 0)
						{
							if (dataSet9.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet9.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[15] = "View";
							}
							else
							{
								dataRow[15] = "";
							}
							if (dataSet9.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet9.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[16] = "View";
							}
							else
							{
								dataRow[16] = "";
							}
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet8.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet9.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText10 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet9.Tables[0].Rows[0]["UOMBasic"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
							DataSet dataSet10 = new DataSet();
							sqlDataAdapter10.Fill(dataSet10);
							if (dataSet10.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet10.Tables[0].Rows[0][0].ToString();
							}
						}
						value4 = dataSet8.Tables[0].Rows[0]["AHId"].ToString();
						num = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["ItemId"]);
					}
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = value;
				dataRow[2] = value2;
				dataRow[3] = value3;
				if (dataSet4.Tables[0].Rows[0]["Qty"].ToString() == "")
				{
					dataRow[4] = "0";
				}
				else
				{
					dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
				}
				if (dataSet3.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
				{
					dataRow[5] = "0";
				}
				else
				{
					dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
				}
				if (dataSet2.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")
				{
					dataRow[6] = "0";
				}
				else
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["ReceivedQty"].ToString()).ToString("N3"));
				}
				if (dataSet.Tables[0].Rows[i]["AcceptedQty"].ToString() == "")
				{
					dataRow[7] = "0";
				}
				else
				{
					dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["AcceptedQty"].ToString()).ToString("N3"));
				}
				string cmdText11 = fun.select("Symbol", "tblQc_Rejection_Reason", "Id='" + dataSet.Tables[0].Rows[i]["RejectionReason"].ToString() + "'");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter11.Fill(dataSet11);
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = dataSet11.Tables[0].Rows[0]["Symbol"].ToString();
				}
				dataRow[9] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["RejectionReason"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["SN"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["PN"].ToString();
				dataRow[13] = value4;
				dataRow[14] = num;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
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

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView2.EditIndex = -1;
			loadData();
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
			loadData();
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			((DropDownList)gridViewRow.FindControl("drprejreason")).Visible = true;
			string selectedValue = ((Label)gridViewRow.FindControl("lblRejectionReason")).Text.ToString();
			((DropDownList)gridViewRow.FindControl("drprejreason")).SelectedValue = selectedValue;
			if (((Label)gridViewRow.FindControl("lblahid")).Text == "42")
			{
				((TextBox)gridViewRow.FindControl("txtSN")).Visible = true;
				if (((TextBox)gridViewRow.FindControl("txtSN")).Visible)
				{
					((RequiredFieldValidator)gridViewRow.FindControl("ReqSn")).Visible = true;
				}
				((TextBox)gridViewRow.FindControl("txtPN")).Visible = true;
				if (((TextBox)gridViewRow.FindControl("txtPN")).Visible)
				{
					((RequiredFieldValidator)gridViewRow.FindControl("ReqPn")).Visible = true;
				}
			}
			else
			{
				((TextBox)gridViewRow.FindControl("txtSN")).Visible = false;
				if (!((TextBox)gridViewRow.FindControl("txtSN")).Visible)
				{
					((RequiredFieldValidator)gridViewRow.FindControl("ReqSn")).Visible = false;
				}
				((TextBox)gridViewRow.FindControl("txtPN")).Visible = false;
				if (!((TextBox)gridViewRow.FindControl("txtPN")).Visible)
				{
					((RequiredFieldValidator)gridViewRow.FindControl("ReqPn")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TxtaccpQty")).Text.ToString()).ToString("N3"));
			double num4 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblaccpQty1")).Text.ToString()).ToString("N3"));
			string selectedValue = ((DropDownList)gridViewRow.FindControl("drprejreason")).SelectedValue;
			string text2 = ((TextBox)gridViewRow.FindControl("Txtremarks")).Text.ToString();
			string text3 = ((TextBox)gridViewRow.FindControl("txtSN")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("txtPN")).Text;
			double num5 = 0.0;
			sqlConnection.Open();
			if (!(num4 >= num3))
			{
				return;
			}
			double num6 = num4 - num3;
			string cmdText = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + num2 + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				double num7 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
				if (num7 >= num6)
				{
					string cmdText2 = fun.update("tblQc_MaterialQuality_Master", "SysDate='" + currDate + "' ,SysTime='" + currTime + "',SessionId='" + text + "'", " CompId='" + CompId + "' AND  FinYearId='" + FyId + "' AND GQNNo='" + GQNNo + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText3 = fun.update("tblQc_MaterialQuality_Details", "AcceptedQty='" + num3 + "',RejectionReason='" + selectedValue + "' ,Remarks='" + text2 + "',SN='" + text3 + "',PN='" + text4 + "'", "Id='" + num + "' AND GQNNo='" + GQNNo + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					num5 = num7 - num6;
					string cmdText4 = fun.update("tblDG_Item_Master", "StockQty='" + num5 + "'", "CompId='" + CompId + "' AND Id='" + num2 + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					GridView2.EditIndex = -1;
					loadData();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsQualityNote_GQN_Edit.aspx?ModId=10&SubModId=46");
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
		}
	}
}

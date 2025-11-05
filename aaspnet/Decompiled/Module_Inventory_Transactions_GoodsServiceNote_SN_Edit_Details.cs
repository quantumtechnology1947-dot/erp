using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_GoodsServiceNote_SN_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string poNo = "";

	private string GINNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string GSNNo = "";

	private string connStr = "";

	private string MId = "";

	private string GINId = "";

	protected Label lblGsn;

	protected Label lblGIn;

	protected Label lblChNo;

	protected Label lblDate;

	protected Label lblSupplier;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView2;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			GSNNo = base.Request.QueryString["GSNNo"].ToString();
			GINNo = base.Request.QueryString["GINNo"].ToString();
			SupplierNo = base.Request.QueryString["SupId"].ToString();
			poNo = base.Request.QueryString["PONo"].ToString();
			FyId = base.Request.QueryString["FyId"].ToString();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"].ToString();
			GINId = base.Request.QueryString["GINId"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			if (!Page.IsPostBack)
			{
				lblGsn.Text = GSNNo;
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + SupplierNo + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "Id='" + GINId + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
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
		finally
		{
			con.Close();
		}
	}

	public void loadData()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("tblinv_MaterialServiceNote_Details.Id,tblinv_MaterialServiceNote_Details.POId,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo='" + GSNNo + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("InvQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotRecedQty", typeof(double)));
			string value = "";
			string value2 = "";
			string value3 = "";
			int num = 0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.Id='" + GINId + "' AND tblInv_Inward_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo='" + dataSet2.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND  tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.Id='" + dataSet2.Tables[0].Rows[0]["POId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
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
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						string cmdText5 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet6.Tables[0].Rows[0][0].ToString();
							}
						}
					}
				}
				else if (dataSet3.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText7 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet3.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet3.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						string cmdText8 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet7.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet7.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet8.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet8.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet9.Tables[0].Rows[0][0].ToString();
							}
						}
					}
				}
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
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
				num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]);
				dataRow[7] = num;
				string cmdText10 = fun.select("sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'  AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
				{
					dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[8] = "0";
				}
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
			con.Close();
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
		base.Response.Redirect("GoodsServiceNote_SN_Edit.aspx?ModId=9&SubModId=39");
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
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TxtRecedQty")).Text.ToString()).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblRecedqty1")).Text.ToString()).ToString("N3"));
			Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
			con.Open();
			if (num2 <= num3 && fun.NumberValidationQty(num2.ToString()))
			{
				string cmdText = fun.update("tblinv_MaterialServiceNote_Master", "SysDate='" + currDate + "' ,SysTime='" + currTime + "',SessionId='" + sId + "'", "Id='" + MId + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.update("tblinv_MaterialServiceNote_Details", "ReceivedQty='" + num2 + "'", "Id='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.ExecuteNonQuery();
				GridView2.EditIndex = -1;
				loadData();
				con.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				double num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
				double num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblRecedqty")).Text.ToString()).ToString("N3"));
				if (num <= num2)
				{
					((LinkButton)row.Cells[0].Controls[0]).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

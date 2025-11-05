using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Delete_Details : Page, IRequiresSessionState
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

	private string GRRNo = "";

	private string connStr = "";

	private string MId = "";

	private string GINId = "";

	protected Label lblGrr;

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
			GRRNo = base.Request.QueryString["GRRNo"].ToString();
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
				lblGrr.Text = GRRNo;
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "'AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "Id='" + GINId + "' AND CompId='" + CompId + "' AND FinYearId='" + FyId + "'");
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
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblId")).Text;
				((LinkButton)row.FindControl("LinkButton1")).Attributes.Add("onclick", "return confirmation();");
				string cmdText3 = fun.select("tblinv_MaterialReceived_Details.Id", "tblinv_MaterialReceived_Master,tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.CompId ='" + CompId + "' AND tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId AND tblQc_MaterialQuality_Details.GRRId='" + text + "' AND tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
					((Label)row.FindControl("lblgqn")).Visible = true;
				}
				else
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = true;
					((Label)row.FindControl("lblgqn")).Visible = false;
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

	public void loadData()
	{
		DataTable dataTable = new DataTable();
		try
		{
			string cmdText = fun.select("tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Master.Id as MasterId,tblinv_MaterialReceived_Details.POId,tblinv_MaterialReceived_Details.ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.Id='" + MId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
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
			dataTable.Columns.Add(new DataColumn("TotRecedQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
			string value = "";
			string value2 = "";
			string value3 = "";
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
						string cmdText5 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet4.Tables[0].Rows[0]["ItemId"].ToString()));
							value3 = dataSet5.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6);
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								value2 = dataSet6.Tables[0].Rows[0][0].ToString();
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
							value3 = dataSet8.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText9 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet8.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								value2 = dataSet9.Tables[0].Rows[0][0].ToString();
							}
						}
					}
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = value;
				dataRow[2] = value3;
				dataRow[3] = value2;
				if (dataSet3.Tables[0].Rows[0]["Qty"].ToString() == "")
				{
					dataRow[4] = "0";
				}
				else
				{
					dataRow[4] = decimal.Parse(dataSet3.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
				}
				if (dataSet2.Tables[0].Rows[0]["ReceivedQty"].ToString() == "")
				{
					dataRow[5] = "0";
				}
				else
				{
					dataRow[5] = decimal.Parse(dataSet2.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3");
				}
				if (dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")
				{
					dataRow[6] = "0";
				}
				else
				{
					dataRow[6] = decimal.Parse(dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString()).ToString("N3");
				}
				dataRow[8] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]);
				string cmdText10 = fun.select("sum(ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.GINId='" + GINId + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
				{
					dataRow[7] = decimal.Parse(dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"].ToString()).ToString("N3");
				}
				else
				{
					dataRow[7] = "0";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			con.Close();
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
			con.Open();
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblinv_MaterialReceived_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("tblinv_MaterialReceived_Details.Id", "tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master", "tblinv_MaterialReceived_Details.GRRNo='" + GRRNo + "' And tblinv_MaterialReceived_Master.GRRNo= tblinv_MaterialReceived_Details.GRRNo And tblinv_MaterialReceived_Master.Id= tblinv_MaterialReceived_Details.MId and tblinv_MaterialReceived_Master.Id='" + MId + "' and tblinv_MaterialReceived_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblinv_MaterialReceived_Master", "CompId='" + CompId + "' and Id='" + MId + "' and GRRNo='" + GRRNo + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("GoodsReceivedReceipt_GRR_Delete.aspx?SID=" + SupplierNo + "&ModId=9&SubModId=38");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
		base.Response.Redirect("GoodsReceivedReceipt_GRR_Delete.aspx?ModId=9&SubModId=38");
	}
}

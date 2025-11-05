using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_GoodsInwardNote_GIN_Delete_Details : Page, IRequiresSessionState
{
	private string ChNo = "";

	private string GINNo = "";

	private string ChDt = "";

	private string fyid = "";

	private int CompId;

	private string Sid = "";

	private string j = "";

	private int FyId;

	private string supId = "";

	private string GINId = "";

	private string SessionFyId = "";

	private string connStr = "";

	private SqlConnection con;

	private clsFunctions fun = new clsFunctions();

	protected Label Label1;

	protected Label Lblgnno;

	protected Label Label4;

	protected Label LblChallanDate;

	protected Label Label3;

	protected Label lblChallanNo;

	protected Label LblWODept;

	protected Label LblWONo;

	protected Label TxtGateentryNo;

	protected Label TxtGDate;

	protected Label lbltime;

	protected Label TxtModeoftransport;

	protected Label TxtVehicleNo;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		connStr = fun.Connection();
		new DataSet();
		con = new SqlConnection(connStr);
		con.Open();
		try
		{
			SessionFyId = Session["finyear"].ToString();
			GINId = base.Request.QueryString["Id"].ToString();
			supId = base.Request.QueryString["SupId"].ToString();
			lblChallanNo.Text = base.Request.QueryString["ChNo"].ToString();
			ChNo = base.Request.QueryString["ChNo"].ToString();
			fyid = base.Request.QueryString["fyid"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			Sid = Session["username"].ToString();
			Lblgnno.Text = base.Request.QueryString["GNo"].ToString();
			GINNo = base.Request.QueryString["GNo"].ToString();
			LblChallanDate.Text = base.Request.QueryString["ChDt"].ToString();
			ChDt = LblChallanDate.Text;
			string cmdText = fun.select("FinYearId", "tblFinancial_master", " FinYear='" + fyid + "' AND CompId ='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				FyId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
			}
			if (!Page.IsPostBack)
			{
				loadData();
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", " Id='" + GINId + "' And   FinYearId<='" + FyId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				TxtGateentryNo.Text = dataSet2.Tables[0].Rows[0]["GateEntryNo"].ToString();
				TxtGDate.Text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["GDate"].ToString());
				string text = dataSet2.Tables[0].Rows[0]["GTime"].ToString();
				lbltime.Text = text;
				TxtModeoftransport.Text = dataSet2.Tables[0].Rows[0]["ModeofTransport"].ToString();
				TxtVehicleNo.Text = dataSet2.Tables[0].Rows[0]["VehicleNo"].ToString();
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

	public void disableEdit()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				_ = ((Label)row.FindControl("lblId")).Text;
				int num = Convert.ToInt32(((Label)row.FindControl("lblPOId")).Text);
				string cmdText = fun.select("tblinv_MaterialReceived_Details.Id", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + GINId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				new DataTable();
				sqlDataAdapter.Fill(dataSet);
				string cmdText2 = fun.select("tblinv_MaterialServiceNote_Details.Id", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "' AND tblinv_MaterialServiceNote_Details.POId='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgrr")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgrr")).Visible = true;
				}
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgsn")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgsn")).Visible = true;
				}
				if (dataSet.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("LinkDel")).Visible = false;
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			con.Open();
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblInv_Inward_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("tblInv_Inward_Details.Id", "tblInv_Inward_Details,tblInv_Inward_Master", " tblInv_Inward_Details.GINNo='" + GINNo + "' And tblInv_Inward_Master.GINNo= tblInv_Inward_Details.GINNo And tblInv_Inward_Master.Id= tblInv_Inward_Details.GINId and tblInv_Inward_Master.FinYearId='" + FyId + "' AND tblInv_Inward_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblInv_Inward_Details");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblInv_Inward_Master", "CompId='" + CompId + "' and FinYearId='" + FyId + "' and GINNo='" + GINNo + "' ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("GoodsInwardNote_GIN_Delete.aspx?ModId=9&SubModId=37");
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

	public void loadData()
	{
		try
		{
			string cmdText = fun.select("tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Master.PONo,tblInv_Inward_Details.Id,tblInv_Inward_Details.ACategoyId,tblInv_Inward_Details.ASubCategoyId,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.Qty,tblInv_Inward_Details.ReceivedQty as sum_ReceivedQty,tblInv_Inward_Details.POId", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.FinYearId<='" + SessionFyId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Details.GINId='" + GINId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("poqty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RecedQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChallanQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
			string value = "";
			string value2 = "";
			string value3 = "";
			double num = 0.0;
			double num2 = 0.0;
			string text = string.Empty;
			string text2 = string.Empty;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet.Tables[0].Rows[i]["PONo"].ToString() + "' AND tblMM_PO_Master.FinYearId <='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + dataSet.Tables[0].Rows[i]["CompId"].ToString() + "' AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText3 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet2.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet2.Tables[0].Rows[0]["PRId"].ToString() + "' And tblMM_PR_Master.CompId='" + CompId + "' and tblMM_PR_Master.FinYearId<='" + FyId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						string cmdText4 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet3.Tables[0].Rows[0]["ItemId"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							text = dataSet3.Tables[0].Rows[0]["WONo"].ToString();
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet3.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet4.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet4.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet5.Tables[0].Rows[0][0].ToString();
							}
							Convert.ToInt32(dataSet3.Tables[0].Rows[0]["AHId"]);
						}
					}
				}
				else if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet2.Tables[0].Rows[0]["SPRNo"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet2.Tables[0].Rows[0]["SPRId"].ToString() + "' And tblMM_SPR_Master.CompId='" + CompId + "' and tblMM_SPR_Master.FinYearId<='" + FyId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0)
						{
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
							value2 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter8.Fill(dataSet8);
							if (dataSet8.Tables[0].Rows.Count > 0)
							{
								value3 = dataSet8.Tables[0].Rows[0][0].ToString();
							}
							Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]);
							if (dataSet6.Tables[0].Rows[0]["WONo"] != DBNull.Value && dataSet6.Tables[0].Rows[0]["WONo"].ToString() != string.Empty)
							{
								text = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
							}
							else
							{
								string cmdText9 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet6.Tables[0].Rows[0]["DeptId"].ToString() + "'");
								SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
								DataSet dataSet9 = new DataSet();
								sqlDataAdapter9.Fill(dataSet9);
								if (dataSet9.Tables[0].Rows.Count > 0)
								{
									text2 = dataSet9.Tables[0].Rows[0]["Symbol"].ToString();
								}
							}
						}
					}
				}
				if (text != "")
				{
					LblWODept.Text = "WONO";
					LblWONo.Text = text;
				}
				else
				{
					LblWODept.Text = "Bussiness Group";
					LblWONo.Text = text2;
				}
				dataRow[0] = value;
				dataRow[1] = value2;
				dataRow[2] = value3;
				num = ((dataSet2.Tables[0].Rows[0]["Qty"] != DBNull.Value) ? Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : 0.0);
				dataRow[3] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[4] = num;
				num2 = ((!(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString()).ToString("N3")) : 0.0);
				dataRow[5] = num2;
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]);
				string cmdText10 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", string.Concat("CompId='", dataSet.Tables[0].Rows[i]["CompId"], "' And FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"].ToString(), "'"));
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10, "Financial");
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					string fDY = dataSet10.Tables[0].Rows[0]["FinYearFrom"].ToString();
					string text3 = fun.FromDateYear(fDY);
					string text4 = text3.Substring(2);
					string tDY = dataSet10.Tables[0].Rows[0]["FinYearTo"].ToString();
					string text5 = fun.ToDateYear(tDY);
					string text6 = text5.Substring(2);
					_ = text4 + text6;
				}
				_ = string.Empty;
				if (dataSet.Tables[0].Rows[i]["ACategoyId"].ToString() != "0" && dataSet.Tables[0].Rows[i]["ACategoyId"] != DBNull.Value)
				{
					string cmdText11 = "select Abbrivation from tblACC_Asset_Category where Id='" + dataSet.Tables[0].Rows[i]["ACategoyId"].ToString() + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText11, con);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						if (sqlDataReader.HasRows)
						{
							sqlDataReader["Abbrivation"].ToString();
						}
					}
				}
				_ = string.Empty;
				if (dataSet.Tables[0].Rows[i]["ASubCategoyId"].ToString() != "0" && dataSet.Tables[0].Rows[i]["ASubCategoyId"] != DBNull.Value)
				{
					string cmdText12 = "select Abbrivation from tblACC_Asset_SubCategory where Id='" + dataSet.Tables[0].Rows[i]["ASubCategoyId"].ToString() + "'";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText12, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						if (sqlDataReader2.HasRows)
						{
							sqlDataReader2["Abbrivation"].ToString();
						}
					}
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			disableEdit();
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
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/GoodsInwardNote_GIN_Delete.aspx?ModId=9&SubModId=37", endResponse: false);
	}
}

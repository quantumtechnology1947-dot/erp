using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_GoodsServiceNote_SN_New_Details : Page, IRequiresSessionState
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

	private string CDate = "";

	private string CTime = "";

	private string connStr = "";

	private string GINId = "";

	protected Label lblGIn;

	protected Label lblChNo;

	protected Label lblDate;

	protected Label lblSupplier;

	protected TextBox txtTaxInvoice;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtDate;

	protected CalendarExtender txtDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator25;

	protected GridView GridView2;

	protected Button btnInsert;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			GINNo = base.Request.QueryString["GINNo"].ToString();
			SupplierNo = base.Request.QueryString["SupId"].ToString();
			poNo = base.Request.QueryString["PONo"].ToString();
			FyId = base.Request.QueryString["FyId"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			GINId = base.Request.QueryString["Id"].ToString();
			txtDate.Attributes.Add("readonly", "readonly");
			con.Open();
			if (!Page.IsPostBack)
			{
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "Id='" + GINId + "'  AND CompId='" + CompId + "'");
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
				double num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
				double num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
				if (num - num2 == 0.0)
				{
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqrecQty")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqrecQty")).Visible = false;
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
			string cmdText = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.GINNo,tblInv_Inward_Master.Id,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty as sum_ReceivedQty,tblInv_Inward_Details.POId,PRSPRFlag,(select sum(ReceivedQty) from tblinv_MaterialServiceNote_Details inner join tblinv_MaterialServiceNote_Master on tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblinv_MaterialServiceNote_Master.GINId=tblInv_Inward_Master.Id And tblinv_MaterialServiceNote_Details.POId=tblInv_Inward_Details.POId ) As GSNQty", "tblInv_Inward_Master,tblInv_Inward_Details,tblMM_PO_Master", "tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.CompId='" + CompId + "'And tblMM_PO_Master.Id=tblInv_Inward_Master.POMId AND tblInv_Inward_Master.Id='" + GINId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("InvQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotRecQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotRemainQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("wono", typeof(string)));
			double num = 0.0;
			double num2 = 0.0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText2 = fun.select("ItemCode,ManfDesc,Unit_Master.Symbol As UOM,Category,tblMM_PO_Details.Id,ItemId,tblMM_PR_Master.WONo,,tblMM_PO_Details.Qty", "tblMM_PR_Details,tblMM_PR_Master,AccHead,tblMM_PO_Details,tblDG_Item_Master,Unit_Master", "tblMM_PR_Details.Id=tblMM_PO_Details.PRId And tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' And tblMM_PR_Details.AHId=AccHead.Id AND tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblDG_Item_Master.Id=tblMM_PR_Details.ItemId And Unit_Master.Id=tblDG_Item_Master.UOMBasic");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						if (sqlDataReader["Category"].ToString() == "Labour" || sqlDataReader["Category"].ToString() == "Expenses" || sqlDataReader["Category"].ToString() == "Service Provider")
						{
							double num3 = 0.0;
							if (dataSet.Tables[0].Rows[i]["GSNQty"] != DBNull.Value)
							{
								num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["GSNQty"].ToString()).ToString("N3"));
							}
							dataRow[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
							dataRow[1] = sqlDataReader["ManfDesc"].ToString();
							dataRow[2] = sqlDataReader["UOM"].ToString();
							dataRow[5] = dataSet.Tables[0].Rows[i]["POId"].ToString();
							dataRow[6] = num3;
							if (sqlDataReader["Qty"] != DBNull.Value)
							{
								num = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
							}
							dataRow[3] = num;
							if (dataSet.Tables[0].Rows[i]["sum_ReceivedQty"] != DBNull.Value)
							{
								num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString()).ToString("N3"));
							}
							dataRow[4] = num2;
							dataRow[7] = sqlDataReader["ItemId"].ToString();
							dataRow[8] = Math.Round(num2 - num3, 3);
							dataRow[9] = sqlDataReader["WONo"].ToString();
						}
					}
					sqlDataReader.Close();
				}
				else if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText3 = fun.select("ItemCode,ManfDesc,Unit_Master.Symbol As UOM,Category,tblMM_PO_Details.Id,ItemId,tblMM_SPR_Details.WONo,tblMM_PO_Details.Qty", "tblMM_SPR_Details,AccHead,tblMM_PO_Details,tblDG_Item_Master,Unit_Master", "tblMM_SPR_Details.Id=tblMM_PO_Details.SPRId And tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' And tblMM_SPR_Details.AHId=AccHead.Id  And tblDG_Item_Master.Id=tblMM_SPR_Details.ItemId And Unit_Master.Id=tblDG_Item_Master.UOMBasic");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						if (sqlDataReader2["Category"].ToString() == "Labour" || sqlDataReader2["Category"].ToString() == "Expenses" || sqlDataReader2["Category"].ToString() == "Service Provider")
						{
							dataRow[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader2["ItemId"].ToString()));
							dataRow[1] = sqlDataReader2["ManfDesc"].ToString();
							dataRow[2] = sqlDataReader2["UOM"].ToString();
							dataRow[5] = dataSet.Tables[0].Rows[i]["POId"].ToString();
							double num4 = 0.0;
							if (dataSet.Tables[0].Rows[i]["GSNQty"] != DBNull.Value)
							{
								num4 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["GSNQty"].ToString()).ToString("N3"));
							}
							dataRow[6] = num4;
							if (sqlDataReader2["Qty"] != DBNull.Value)
							{
								num = Convert.ToDouble(decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3"));
							}
							dataRow[3] = num;
							if (dataSet.Tables[0].Rows[i]["sum_ReceivedQty"] != DBNull.Value)
							{
								num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString()).ToString("N3"));
							}
							dataRow[4] = num2;
							dataRow[7] = sqlDataReader2["ItemId"].ToString();
							dataRow[8] = Math.Round(num2 - num4, 3);
							dataRow[9] = sqlDataReader2["WONo"].ToString();
						}
					}
					sqlDataReader2.Close();
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

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("ck")).Checked)
			{
				((TextBox)gridViewRow.FindControl("txtrecQty")).Visible = true;
				((TextBox)gridViewRow.FindControl("txtrecQty")).Text = ((Label)gridViewRow.FindControl("lblrecevdqty")).Text;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqrecQty")).Visible = true;
			}
			else
			{
				((TextBox)gridViewRow.FindControl("txtrecQty")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqrecQty")).Visible = false;
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
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				double num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text).ToString("N3"));
				double num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbltotrecevdqty")).Text).ToString("N3"));
				if (num - num2 == 0.0)
				{
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsServiceNote_SN_New.aspx?ModId=9&SubModId=39");
	}

	protected void btnInsert_Click(object sender, EventArgs e)
	{
		try
		{
			GINNo = lblGIn.Text;
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			con.Open();
			string cmdText = fun.select("GSNNo", "tblinv_MaterialServiceNote_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GSNNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblinv_MaterialServiceNote_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("MRSNo", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRSNo Desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblInv_MaterialRequisition_Master");
			string text2 = "";
			text2 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText3 = fun.select("MINNo", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by MINNo Desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3, "tblInv_MaterialIssue_Master");
			string text3 = "";
			text3 = ((dataSet3.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string text4 = "";
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				num3++;
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtrecQty")).Text != "" && txtTaxInvoice.Text != "" && txtDate.Text != "" && fun.DateValidation(txtDate.Text))
				{
					num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtrecQty")).Text.ToString()).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
					if (num4 > 0.0 && num4 <= num5 - num6 && fun.NumberValidationQty(num4.ToString()))
					{
						num2++;
					}
				}
			}
			if (num3 == num2 && num2 > 0)
			{
				int num7 = 1;
				int num8 = 1;
				int num9 = 1;
				string text5 = "";
				string text6 = "";
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (!((CheckBox)row2.FindControl("ck")).Checked || !(((TextBox)row2.FindControl("txtrecQty")).Text != "") || !(txtTaxInvoice.Text != "") || !(txtDate.Text != "") || !fun.DateValidation(txtDate.Text))
					{
						continue;
					}
					double num10 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtrecQty")).Text.ToString()).ToString("N3"));
					double num11 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
					double num12 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
					string text7 = ((Label)row2.FindControl("lblItemId")).Text;
					string text8 = ((Label)row2.FindControl("lblWONo")).Text;
					int num13 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					if (!(num10 > 0.0) || !(num10 <= Math.Round(num11 - num12, 3)) || !fun.NumberValidationQty(num10.ToString()))
					{
						continue;
					}
					if (num7 == 1)
					{
						SqlCommand sqlCommand = new SqlCommand(fun.insert("tblinv_MaterialServiceNote_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,GSNNo,GINNo,GINId,TaxInvoiceNo,TaxInvoiceDate", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + GINNo + "','" + GINId + "','" + txtTaxInvoice.Text + "','" + fun.FromDate(txtDate.Text) + "'"), con);
						sqlCommand.ExecuteNonQuery();
						num7 = 0;
						string cmdText4 = fun.select("Id", "tblinv_MaterialServiceNote_Master", "CompId='" + CompId + "' Order by Id desc");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4, "tblinv_MaterialServiceNote_Master");
						text4 = dataSet4.Tables[0].Rows[0]["Id"].ToString();
					}
					SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblinv_MaterialServiceNote_Details", "MId,GSNNo,POId,ReceivedQty", "'" + text4 + "','" + text + "','" + num13 + "','" + num10 + "'"), con);
					sqlCommand2.ExecuteNonQuery();
					string cmdText5 = fun.select("StockQty,Process,ItemCode", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + text7 + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						double num14 = 0.0;
						num14 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["StockQty"]) + num10;
						string cmdText6 = fun.update("tblDG_Item_Master", "StockQty='" + num14 + "'", "CompId='" + CompId + "' AND Id='" + text7 + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
						sqlCommand3.ExecuteNonQuery();
						string cmdText7 = fun.select("ReleaseWIS", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND WONo='" + text8 + "'");
						SqlCommand selectCommand6 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet6.Tables[0].Rows[0][0]) == 1 && text8 != "" && num14 > 0.0)
						{
							if (num8 == 1)
							{
								string cmdText8 = "Insert into tblInv_MaterialRequisition_Master(SysDate,SysTime,CompId,FinYearId,SessionId,MRSNo) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text2 + "')";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText8, con);
								sqlCommand4.ExecuteNonQuery();
								num8 = 0;
								string cmdText9 = fun.select("Id", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' Order by Id desc");
								SqlCommand selectCommand7 = new SqlCommand(cmdText9, con);
								SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
								DataSet dataSet7 = new DataSet();
								sqlDataAdapter7.Fill(dataSet7, "tblInv_MaterialRequisition_Master");
								text5 = dataSet7.Tables[0].Rows[0]["Id"].ToString();
							}
							string cmdText10 = "Insert into tblInv_MaterialRequisition_Details(MId,MRSNo,ItemId,WONo,DeptId,ReqQty,Remarks) VALUES  ('" + text5 + "','" + text2 + "','" + text7 + "','" + text8 + "','1','" + Convert.ToDouble(decimal.Parse(num14.ToString()).ToString("N3")) + "','-')";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText10, con);
							sqlCommand5.ExecuteNonQuery();
							string cmdText11 = fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.ReqQty", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialRequisition_Master.CompId='" + CompId + "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id='" + text5 + "'And tblInv_MaterialRequisition_Details.ItemId='" + text7 + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText11, con);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet8 = new DataSet();
							new DataTable();
							sqlDataAdapter8.Fill(dataSet8);
							for (int i = 0; i < dataSet8.Tables[0].Rows.Count; i++)
							{
								double num15 = 0.0;
								double num16 = 0.0;
								double num17 = 0.0;
								if (num9 == 1)
								{
									string cmdText12 = fun.insert("tblInv_MaterialIssue_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MINNo,MRSNo,MRSId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text3 + "','" + text2 + "','" + text5 + "'");
									SqlCommand sqlCommand6 = new SqlCommand(cmdText12, con);
									sqlCommand6.ExecuteNonQuery();
									num9 = 0;
									string cmdText13 = fun.select("Id", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' Order by Id Desc");
									SqlCommand selectCommand9 = new SqlCommand(cmdText13, con);
									SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
									DataSet dataSet9 = new DataSet();
									sqlDataAdapter9.Fill(dataSet9);
									text6 = dataSet9.Tables[0].Rows[0]["Id"].ToString();
								}
								string cmdText14 = fun.select("sum(tblInv_MaterialIssue_Details.IssueQty) as sum_IssuedQty", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details", "tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Details.MRSId='" + dataSet8.Tables[0].Rows[i]["Id"].ToString() + "'");
								SqlCommand selectCommand10 = new SqlCommand(cmdText14, con);
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
								DataSet dataSet10 = new DataSet();
								sqlDataAdapter10.Fill(dataSet10);
								if (dataSet10.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value)
								{
									num17 = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
								}
								num15 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
								if (num14 >= num15)
								{
									num16 = num14 - num15;
									num17 = num15;
								}
								else
								{
									num16 = 0.0;
									num17 = num14;
								}
								string cmdText15 = fun.insert("tblInv_MaterialIssue_Details", "MId,MINNo,MRSId,IssueQty", "'" + text6 + "','" + text3 + "','" + dataSet8.Tables[0].Rows[i]["Id"].ToString() + "','" + num17 + "'");
								SqlCommand sqlCommand7 = new SqlCommand(cmdText15, con);
								sqlCommand7.ExecuteNonQuery();
								string cmdText16 = fun.update("tblDG_Item_Master", "StockQty='" + num16 + "'", "CompId='" + CompId + "' AND Id='" + text7 + "'");
								SqlCommand sqlCommand8 = new SqlCommand(cmdText16, con);
								sqlCommand8.ExecuteNonQuery();
							}
						}
					}
					num++;
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid data input .";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			Session.Remove("CHECKED_ITEMS_GSN");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}

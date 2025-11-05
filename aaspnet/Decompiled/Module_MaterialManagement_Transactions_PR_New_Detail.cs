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
using Telerik.Web.UI;

public class Module_MaterialManagement_Transactions_PR_New_Detail : Page, IRequiresSessionState
{
	private string wono = "";

	private int CompId;

	private string SId = "";

	private int fyid;

	private string WomfDate = "";

	private string SupplierName = string.Empty;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	protected Label lblWono;

	protected RadSkinManager QsfSkinManager;

	protected RadGrid RadGrid1;

	protected Button RadButton1;

	protected Button RadButton2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			wono = base.Request.QueryString["WONo"].ToString();
			fyid = Convert.ToInt32(Session["finyear"]);
			lblWono.Text = wono;
			WomfDate = WOmfgdate(wono, CompId, fyid);
			if (!Page.IsPostBack)
			{
				MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null");
				FillFIN();
			}
			foreach (GridDataItem item in RadGrid1.Items)
			{
				GridView gridView = (GridView)item.FindControl("GridView5");
				foreach (GridViewRow row in gridView.Rows)
				{
					((TextBox)row.FindControl("txtFinDeliDate")).Attributes.Add("readonly", "readonly");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void MP_Tree1(string wono, int CompId, RadGrid GridView2, int finid, string param)
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("BOMQty", typeof(string));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PRQty", typeof(string));
			dataTable.Columns.Add("WISQty", typeof(string));
			dataTable.Columns.Add("GQNQty", typeof(string));
			string cmdText = "select Distinct ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,(SELECT sum(IssuedQty)FROM tblInv_WIS_Details inner join tblInv_WIS_Master on tblInv_WIS_Master.Id=tblInv_WIS_Details.MId And tblInv_WIS_Details.ItemId=tblDG_Item_Master.Id And tblInv_WIS_Master.WONo='" + wono + "')As WISQty,(SELECT sum(Qty) FROM tblMM_PR_Details inner join tblMM_PR_Master on tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id And tblMM_PR_Master.WONo='" + wono + "')As PRQty,(select Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty from tblQc_MaterialQuality_Details,tblinv_MaterialReceived_Details,tblMM_PO_Details,tblMM_PR_Details,tblMM_PR_Master where tblQc_MaterialQuality_Details.GRRId=tblinv_MaterialReceived_Details.Id And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id  And tblMM_PR_Master.Id=tblMM_PR_Details.MId  And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id  And tblMM_PR_Master.WONo='" + wono + "') As GQNQty from tblDG_BOM_Master,tblDG_Item_Master,Unit_Master where WONo='" + wono + "'" + param + " And Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.CompId='" + CompId + "' And tblDG_BOM_Master.FinYearId<='" + finid + "' And ECNFlag=0 AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + wono + "' and CompId='" + CompId + "' And FinYearId<='" + finid + "')";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["ItemCode"].ToString();
				dataRow[1] = sqlDataReader["ManfDesc"].ToString();
				dataRow[2] = sqlDataReader["UOMBasic"].ToString();
				double num = 0.0;
				dataRow[3] = num;
				double num2 = 0.0;
				num2 = fun.AllComponentBOMQty(CompId, wono, sqlDataReader["ItemId"].ToString(), finid);
				dataRow[4] = num2;
				dataRow[7] = sqlDataReader["ItemId"].ToString();
				double num3 = 0.0;
				if (sqlDataReader["PRQty"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(sqlDataReader["PRQty"]);
				}
				dataRow[8] = num3.ToString();
				double num4 = 0.0;
				if (sqlDataReader["WISQty"] != DBNull.Value)
				{
					num4 = Convert.ToDouble(sqlDataReader["WISQty"]);
				}
				dataRow[9] = num4.ToString();
				double num5 = 0.0;
				if (sqlDataReader["GQNQty"] != DBNull.Value)
				{
					num5 = Convert.ToDouble(sqlDataReader["GQNQty"]);
				}
				dataRow[10] = num5.ToString();
				if (sqlDataReader["FileName"].ToString() != "" && sqlDataReader["FileName"] != DBNull.Value)
				{
					dataRow[5] = "View";
				}
				else
				{
					dataRow[5] = "";
				}
				if (sqlDataReader["AttName"].ToString() != "" && sqlDataReader["AttName"] != DBNull.Value)
				{
					dataRow[6] = "View";
				}
				else
				{
					dataRow[6] = "";
				}
				if (Math.Round(num2 - num3 - num4 + num5, 3) > 0.0)
				{
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlDataReader.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public string WOmfgdate(string wono, int compid, int finid)
	{
		string result = "";
		try
		{
			string cmdText = fun.select("SD_Cust_WorkOrder_Master.BoughtoutMaterialDate", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Master.WONo='" + wono + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finid + "'And SD_Cust_WorkOrder_Master.CompId='" + compid + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["BoughtoutMaterialDate"] != DBNull.Value)
			{
				result = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	protected void RadGrid1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
	{
	}

	public void FillFIN()
	{
		try
		{
			foreach (GridDataItem item in RadGrid1.Items)
			{
				string text = ((Label)item.FindControl("lblItemId")).Text;
				double num = Convert.ToDouble(decimal.Parse(((Label)item.FindControl("lblbomqty")).Text).ToString("N3"));
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				num3 = fun.RMQty_PR(text, wono, CompId, "tblMM_PR_Details");
				num4 = fun.RMQty_PR_Temp(text, SId, CompId, "tblMM_PLN_PR_Temp");
				num2 = fun.CalWISQty(CompId.ToString(), wono, text.ToString());
				num5 = fun.GQNQTY(CompId, wono, text.ToString());
				double num6 = 0.0;
				double num7 = 0.0;
				string cmdText = fun.select("Discount,Rate,(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + text + "' And CompId='" + CompId + "' order by DisRate Asc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num7 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N2"));
					num6 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][1].ToString()).ToString("N2"));
				}
				string cmdText2 = fun.select("*", "tblMM_PLN_PR_Temp", "ItemId='" + text + "' And SessionId='" + SId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					DataTable dataTable = new DataTable();
					DataRow dataRow = null;
					dataTable.Columns.Add(new DataColumn("Column111", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Column211", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Column311", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Column411", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Id11", typeof(string)));
					dataTable.Columns.Add(new DataColumn("SessionId", typeof(string)));
					dataTable.Columns.Add(new DataColumn("Column511", typeof(string)));
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						dataRow = dataTable.NewRow();
						string cmdText3 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + dataSet2.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow["Column111"] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString();
						}
						dataRow["Column211"] = dataSet2.Tables[0].Rows[i]["Qty"].ToString();
						dataRow["Column311"] = dataSet2.Tables[0].Rows[i]["Rate"].ToString();
						dataRow["Column411"] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["DelDate"].ToString());
						dataRow["Id11"] = dataSet2.Tables[0].Rows[i]["Id"].ToString();
						dataRow["SessionId"] = dataSet2.Tables[0].Rows[i]["SessionId"].ToString();
						dataRow["Column511"] = dataSet2.Tables[0].Rows[i]["Discount"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
					DataSet dataSet4 = new DataSet();
					dataSet4.Tables.Add(dataTable);
					DataTable dataTable2 = new DataTable();
					DataRow dataRow2 = null;
					dataTable2.Columns.Add(new DataColumn("Column111", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column211", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column311", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column411", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Id11", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("SessionId", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column511", typeof(string)));
					dataRow2 = dataTable2.NewRow();
					dataRow2["Column111"] = string.Empty;
					dataRow2["Column211"] = string.Empty;
					dataRow2["Column311"] = string.Empty;
					dataRow2["Column411"] = string.Empty;
					dataRow2["Id11"] = string.Empty;
					dataRow2["SessionId"] = string.Empty;
					dataRow2["Column511"] = string.Empty;
					dataTable2.Rows.Add(dataRow2);
					DataSet dataSet5 = new DataSet();
					dataSet5.Tables.Add(dataTable2);
					dataSet4.Merge(dataSet5);
					((GridView)item.FindControl("GridView5")).DataSource = dataSet4;
					((GridView)item.FindControl("GridView5")).DataBind();
					GridView gridView = (GridView)item.FindControl("GridView5");
					GridViewRow gridViewRow = gridView.Rows[gridView.Rows.Count - 1];
					if (Math.Round(num - num3 - num4 - num2 + num5, 5) == 0.0)
					{
						gridView.Rows[gridView.Rows.Count - 1].Visible = false;
					}
					((ImageButton)gridViewRow.FindControl("ImageButton3")).Visible = false;
					dataSet4.Clear();
					CheckBox checkBox = gridView.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
					checkBox.Checked = true;
					if (!checkBox.Checked)
					{
						continue;
					}
					foreach (GridViewRow row in gridView.Rows)
					{
						((TextBox)row.FindControl("txtQtyFin")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtQtyFin")).Enabled = true;
						((TextBox)row.FindControl("txtFinRate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtFinRate")).Enabled = true;
						((TextBox)row.FindControl("txtDiscount")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtDiscount")).Enabled = true;
						((TextBox)row.FindControl("txtSupplierFin")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtSupplierFin")).Enabled = true;
						((TextBox)row.FindControl("txtFinDeliDate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Enabled = true;
					}
					((TextBox)gridViewRow.FindControl("txtQtyFin")).Text = Math.Round(num - num3 - num4 - num2 + num5, 5).ToString();
					((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Text = WomfDate;
					((TextBox)gridViewRow.FindControl("txtFinRate")).Text = num6.ToString();
					((TextBox)gridViewRow.FindControl("txtDiscount")).Text = num7.ToString();
				}
				else
				{
					DataTable dataTable3 = new DataTable();
					DataRow dataRow3 = null;
					dataTable3.Columns.Add(new DataColumn("Column111", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("Column211", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("Column311", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("Column411", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("Id11", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("SessionId", typeof(string)));
					dataTable3.Columns.Add(new DataColumn("Column511", typeof(string)));
					dataRow3 = dataTable3.NewRow();
					dataRow3["Column111"] = string.Empty;
					dataRow3["Column211"] = string.Empty;
					dataRow3["Column311"] = string.Empty;
					dataRow3["Column411"] = string.Empty;
					dataRow3["Id11"] = string.Empty;
					dataRow3["SessionId"] = string.Empty;
					dataRow3["Column511"] = string.Empty;
					dataTable3.Rows.Add(dataRow3);
					DataSet dataSet6 = new DataSet();
					dataSet6.Tables.Add(dataTable3);
					((GridView)item.FindControl("GridView5")).DataSource = dataSet6;
					((GridView)item.FindControl("GridView5")).DataBind();
					GridView gridView2 = (GridView)item.FindControl("GridView5");
					GridViewRow gridViewRow3 = gridView2.Rows[gridView2.Rows.Count - 1];
					((ImageButton)gridViewRow3.FindControl("ImageButton3")).Visible = false;
					CheckBox checkBox2 = gridView2.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
					if (checkBox2.Checked)
					{
						((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text = decimal.Parse((num - num3 - num2 + num5).ToString()).ToString("N3");
						((TextBox)gridViewRow3.FindControl("txtFinDeliDate")).Text = WomfDate;
						((TextBox)gridViewRow3.FindControl("txtFinRate")).Text = decimal.Parse(num6.ToString()).ToString("N2");
						((TextBox)gridViewRow3.FindControl("txtDiscount")).Text = decimal.Parse(num7.ToString()).ToString("N2");
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			RadGrid1.CurrentPageIndex = 0;
			RadGrid1.ClientSettings.Scrolling.ScrollLeft = "390";
			GridViewRow gridViewRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblFinId")).Text;
			_ = ((Label)gridViewRow.FindControl("lblFinDMid")).Text;
			if (e.CommandName == "FinDelete")
			{
				string cmdText = fun.delete("tblMM_PLN_PR_Temp", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillFIN();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
	{
		try
		{
			GridDataItem gridDataItem = (GridDataItem)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridDataItem.FindControl("lblItemId")).Text;
			double num = Convert.ToDouble(decimal.Parse(((Label)gridDataItem.FindControl("lblbomqty")).Text).ToString("N3"));
			GridView gridView = (GridView)gridDataItem.FindControl("GridView5");
			CheckBox checkBox = gridView.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
			if (e.CommandName == "viewImg")
			{
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + text + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
			}
			if (e.CommandName == "viewSpec")
			{
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + text + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
			if (!(e.CommandName == "TempAdd"))
			{
				return;
			}
			string text2 = "";
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			string text3 = "";
			double num5 = 0.0;
			int num6 = 0;
			double num7 = 0.0;
			string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + text + "' And CompId='" + CompId + "'   ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
			{
				num7 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
			}
			else
			{
				string cmdText2 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + text + "' And CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num7 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
			}
			GridViewRow gridViewRow = gridView.Rows[gridView.Rows.Count - 1];
			if (checkBox.Checked && ((TextBox)gridViewRow.FindControl("txtQtyFin")).Text != "" && ((TextBox)gridViewRow.FindControl("txtQtyFin")).Text != "0" && ((TextBox)gridViewRow.FindControl("txtSupplierFin")).Text != "" && ((TextBox)gridViewRow.FindControl("txtFinRate")).Text != "")
			{
				RadGrid1.CurrentPageIndex = 0;
				RadGrid1.ClientSettings.Scrolling.ScrollLeft = "390";
				_ = ((TextBox)gridViewRow.FindControl("txtSupplierFin")).Text;
				text2 = fun.getCode(((TextBox)gridViewRow.FindControl("txtSupplierFin")).Text);
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQtyFin")).Text).ToString("N3"));
				num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtFinRate")).Text).ToString("N2"));
				text3 = fun.FromDateDMY(((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Text);
				_ = ((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Text;
				num4 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtDiscount")).Text);
				num5 = Convert.ToDouble(decimal.Parse((num3 - num3 * num4 / 100.0).ToString()).ToString("N2"));
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				double num11 = 0.0;
				num9 = fun.RMQty_PR(text, wono, CompId, "tblMM_PR_Details");
				num10 = fun.RMQty_PR_Temp(text, SId, CompId, "tblMM_PLN_PR_Temp");
				num8 = fun.CalWISQty(CompId.ToString(), wono, text.ToString());
				num11 = fun.GQNQTY(CompId, wono, text.ToString());
				string cmdText3 = fun.select("*", "tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SupplierId='" + text2 + "' And DelDate='" + text3 + "' AND ItemId='" + text + "' AND SessionId='" + SId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count == 0)
				{
					if (Math.Round(num - num2 - num9 - num10 - num8 + num11, 5) == 0.0)
					{
						if (num5 > 0.0)
						{
							if (num7 > 0.0)
							{
								double num12 = 0.0;
								num12 = Convert.ToDouble(decimal.Parse((num7 - num5).ToString()).ToString("N2"));
								if (num12 >= 0.0)
								{
									Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
								}
								else
								{
									string cmdText4 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");
									SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
									SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
									DataSet dataSet4 = new DataSet();
									sqlDataAdapter4.Fill(dataSet4);
									if (dataSet4.Tables[0].Rows.Count > 0)
									{
										Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
									}
									else
									{
										string empty = string.Empty;
										empty = "Entered rate is not acceptable!";
										base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
									}
								}
							}
							else
							{
								Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
							}
							FillFIN();
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
					else if (Math.Round(num - num2 - num9 - num10 - num8 + num11, 5) >= 0.0)
					{
						if (num5 > 0.0)
						{
							if (num7 > 0.0)
							{
								double num13 = 0.0;
								num13 = Convert.ToDouble(decimal.Parse((num7 - num5).ToString()).ToString("N2"));
								if (num13 >= 0.0)
								{
									Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
								}
								else
								{
									string cmdText5 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");
									SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
									SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
									DataSet dataSet5 = new DataSet();
									sqlDataAdapter5.Fill(dataSet5);
									if (dataSet5.Tables[0].Rows.Count > 0)
									{
										Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
									}
									else
									{
										string empty3 = string.Empty;
										empty3 = "Entered rate is not acceptable!";
										base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
									}
								}
							}
							else
							{
								Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(text), text2, num2, num3, text3, num4);
							}
							FillFIN();
						}
						else
						{
							string empty4 = string.Empty;
							empty4 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					num6++;
				}
			}
			if (num6 > 0)
			{
				string empty5 = string.Empty;
				empty5 = "Invalid data entry ";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
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

	protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			RadGrid1.CurrentPageIndex = 0;
			RadGrid1.ClientSettings.Scrolling.ScrollLeft = "385";
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			int index = gridViewRow.RowIndex + 1;
			GridView gridView = (GridView)gridViewRow.NamingContainer;
			TextBox textBox = gridView.Rows[index].FindControl("txtSupplierFin") as TextBox;
			TextBox textBox2 = gridView.Rows[index].FindControl("txtQtyFin") as TextBox;
			TextBox textBox3 = gridView.Rows[index].FindControl("txtFinDeliDate") as TextBox;
			TextBox textBox4 = gridView.Rows[index].FindControl("txtFinRate") as TextBox;
			TextBox textBox5 = gridView.Rows[index].FindControl("txtDiscount") as TextBox;
			GridDataItem gridDataItem = (GridDataItem)gridView.NamingContainer;
			RadGrid radGrid = (RadGrid)gridView.Parent.Parent.Parent.Parent.Parent;
			int dataSetIndex = gridDataItem.DataSetIndex;
			Label label = radGrid.Items[dataSetIndex].FindControl("lblItemId") as Label;
			Label label2 = radGrid.Items[dataSetIndex].FindControl("lblbomqty") as Label;
			int num = Convert.ToInt32(label.Text);
			double num2 = Convert.ToDouble(label2.Text);
			double num3 = 0.0;
			double num4 = 0.0;
			if (checkBox.Checked)
			{
				string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + num + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
					num4 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
				}
				else
				{
					string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + num + "' And CompId='" + CompId + "'  order by DisRate Asc ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
						num4 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					}
				}
				if (textBox2.Text == "" && textBox3.Text == "")
				{
					textBox2.Text = (num2 - fun.RMQty_PR(num.ToString(), wono, CompId, "tblMM_PR_Details") - fun.CalWISQty(CompId.ToString(), wono, num.ToString()) + fun.GQNQTY(CompId, wono, num.ToString())).ToString();
					textBox3.Text = WomfDate;
					textBox4.Text = num3.ToString();
					textBox5.Text = num4.ToString();
				}
			}
			else
			{
				textBox.Text = string.Empty;
				textBox2.Text = string.Empty;
				textBox3.Text = string.Empty;
				textBox4.Text = string.Empty;
				textBox5.Text = string.Empty;
				string cmdText3 = fun.select("*", "tblMM_PLN_PR_Temp", "ItemId='" + num + "' AND SessionId='" + SId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					string cmdText4 = fun.delete("tblMM_PLN_PR_Temp", "SessionId='" + SId + "' And ItemId='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText4, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillFIN();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadButton2_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34");
	}

	protected void RadButton1_Click(object sender, EventArgs e)
	{
		try
		{
			double num = 0.0;
			string cmdText = fun.select("*", "tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblMM_PLN_PR_Temp");
			int num2 = 0;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("PRNo", "tblMM_PR_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' order by PRNo desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblMM_PR_Master");
				string text = "";
				text = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					num = Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), fyid).ToString()).ToString("N3"));
					string cmdText3 = fun.select("sum(Qty) as FIN_Qty", "tblMM_PLN_PR_Temp", "ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0 && num - Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["FIN_Qty"].ToString()).ToString("N3")) >= 0.0)
					{
						num2++;
					}
				}
				if (num2 < 0)
				{
					string empty = string.Empty;
					empty = "Invalid data entry found.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				else
				{
					int num3 = 1;
					int num4 = 0;
					DataSet dataSet4 = new DataSet();
					for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
					{
						if (num3 == 1)
						{
							SqlCommand sqlCommand = new SqlCommand(fun.insert("tblMM_PR_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WONo,PRNo", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + wono + "','" + text + "'"), con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							string cmdText4 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' order by Id desc");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet4, "tblMM_PR_Master");
							num3 = 0;
						}
						num4 = Convert.ToInt32(dataSet4.Tables[0].Rows[0]["Id"].ToString());
						SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblMM_PR_Details", "MId,PRNo,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Discount", "'" + num4 + "','" + text + "','" + dataSet.Tables[0].Rows[j]["ItemId"].ToString() + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[j]["Qty"].ToString()) + "','" + dataSet.Tables[0].Rows[j]["SupplierId"].ToString() + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[j]["Rate"].ToString()) + "','28','" + dataSet.Tables[0].Rows[j]["DelDate"].ToString() + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[j]["Discount"].ToString()) + "'"), con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
				}
				Page.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34&msg=" + text);
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid data entry found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void Insfun(string tbl, int compid, string SId, int itemId, string SupId, double Qty, double Rate, string DelDate, double Discount)
	{
		string cmdText = fun.insert(tbl, "CompId,SessionId,ItemId,SupplierId,Qty,Rate,DelDate,Discount", compid + ",'" + SId + "'," + itemId + ",'" + SupId + "','" + Qty + "','" + Rate + "','" + DelDate + "','" + Discount + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, con);
		con.Open();
		sqlCommand.ExecuteNonQuery();
		con.Close();
	}
}

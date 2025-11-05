using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using Telerik.Web.UI;

public class Module_Inventory_Transactions_WIS_ActualRun_Assembly : Page, IRequiresSessionState
{
	protected UpdateProgress UpdateProgress;

	protected ModalPopupExtender modalPopup;

	protected Label Label2;

	protected CheckBox CheckBox1;

	protected Button Button1;

	protected Button Button2;

	protected Button btnCancel;

	protected Label lblmsg;

	protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

	protected UpdatePanel pnlData;

	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	public string wonosrc = "";

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string ConnString = string.Empty;

	private SqlConnection conn;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			ConnString = fun.Connection();
			conn = new SqlConnection(ConnString);
			CompId = Convert.ToInt32(Session["compid"]);
			wonosrc = base.Request.QueryString["WONo"].ToString();
			lblmsg.Text = "";
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (base.Request.QueryString["msg"] != "")
			{
				lblmsg.Text = base.Request.QueryString["msg"];
			}
			if (!Page.IsPostBack)
			{
				RadTreeList1.DataSource = GetDataTable();
				RadTreeList1.DataBind();
				RadTreeList1.ExpandAllItems();
				CheckBox1.Checked = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public DataTable GetDataTable()
	{
		DataTable dataTable = new DataTable();
		try
		{
			conn.Open();
			Label2.Text = wonosrc;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_BOM_Details_Assembly", conn);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOM Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Weld", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Stock Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Tot. WIS Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dry Run Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Balance BOM Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("After Stock Qty", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = dataSet.Tables[0].Rows[i][4];
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetSchTime_Item_Details", conn);
				sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter2.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
				sqlDataAdapter2.SelectCommand.Parameters["@Id"].Value = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				dataRow[4] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i][0].ToString()));
				dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, conn);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
				dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[8] = Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3"));
				dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
				sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@WONo"].Value = wonosrc;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@ItemId"].Value = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@PId"].Value = dataSet.Tables[0].Rows[i]["PId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CId"].Value = dataSet.Tables[0].Rows[i]["CId"].ToString();
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num2 = 0.0;
				double num3 = 0.0;
				if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet4.Tables[0].Rows.Count > 0)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
					dataRow[11] = num2;
				}
				else
				{
					dataRow[11] = 0;
				}
				if (num >= 0.0)
				{
					num3 = Convert.ToDouble(decimal.Parse((num - num2).ToString()).ToString("N3"));
				}
				double num4 = 0.0;
				double num5 = 0.0;
				if (Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && num3 >= 0.0)
				{
					if (Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= num3)
					{
						num4 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - num3;
						num5 = num3;
					}
					else if (num3 >= Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
					{
						num4 = 0.0;
						num5 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					}
				}
				if (Convert.ToDouble(decimal.Parse((num - (num2 + num5)).ToString()).ToString("N3")) >= 0.0)
				{
					dataRow[13] = Convert.ToDouble(decimal.Parse((num - (num2 + num5)).ToString()).ToString("N3"));
				}
				else
				{
					dataRow[13] = 0;
				}
				dataRow[12] = num5;
				dataRow[14] = num4;
				list.Clear();
				dataTable.Rows.Add(dataRow);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			conn.Close();
		}
		return dataTable;
	}

	protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
	{
		if (e.CommandName == "ExpandCollapse")
		{
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
		}
	}

	protected void RadTreeList1_PageIndexChanged(object source, TreeListPageChangedEventArgs e)
	{
		RadTreeList1.CurrentPageIndex = e.NewPageIndex;
		RadTreeList1.DataSource = GetDataTable();
		RadTreeList1.DataBind();
	}

	protected void RadTreeList1_PageSizeChanged(object source, TreeListPageSizeChangedEventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable();
		RadTreeList1.DataBind();
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (RadTreeList1.SelectedItems.Count > 0)
		{
			_ = RadTreeList1.SelectedItems[0]["WONo"].Text;
			Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
			Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
		}
	}

	protected void RadTreeList1_AutoGeneratedColumnCreated(object sender, TreeListAutoGeneratedColumnCreatedEventArgs e)
	{
		if (e.Column.HeaderText == "ItemId")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "PId")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "CId")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "ECN")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "WONo")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "Item Code")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(360);
		}
		if (e.Column.HeaderText == "Unit Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(60);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "BOM Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "UOM")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(40);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Weld")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(40);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "Tot. WIS Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "Stock Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(60);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "Dry Run Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "After Stock Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "Balance BOM Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
			RadTreeList1.ExpandAllItems();
		}
		else
		{
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
			RadTreeList1.CollapseAllItems();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/WIS_Dry_Actual_Run.aspx?ModId=9&SubModId=53");
	}

	protected void ImageButton1_Click(object sender, EventArgs e)
	{
	}

	public void WIS_RootAssly()
	{
		try
		{
			conn.Open();
			string text = "";
			int num = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_WISNo", conn);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["WISNo"].ToString()) + 1).ToString("D4"));
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetSchTime_BOM_Details_Assembly", conn);
			sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@WONo"].Value = wonosrc;
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			int num2 = 1;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataSet dataSet3 = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetSchTime_Item_Details", conn);
				sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@Id"].Value = dataSet2.Tables[0].Rows[i]["ItemId"].ToString();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				if (dataSet3.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CId"]));
				double num3 = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num3 *= list[j];
				}
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
				sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@WONo"].Value = wonosrc;
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@ItemId"].Value = dataSet2.Tables[0].Rows[i]["ItemId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@PId"].Value = dataSet2.Tables[0].Rows[i]["PId"].ToString();
				sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
				sqlDataAdapter4.SelectCommand.Parameters["@CId"].Value = dataSet2.Tables[0].Rows[i]["CId"].ToString();
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num4 = 0.0;
				double num5 = 0.0;
				if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet4.Tables[0].Rows.Count > 0)
				{
					num4 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				if (num3 >= 0.0)
				{
					num5 = Convert.ToDouble(decimal.Parse((num3 - num4).ToString()).ToString("N3"));
				}
				double num6 = 0.0;
				double num7 = 0.0;
				if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && num5 >= 0.0)
				{
					if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= num5)
					{
						num6 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - num5;
						num7 = num5;
					}
					else if (num5 >= Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
					{
						num6 = 0.0;
						num7 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					}
				}
				if (num7 > 0.0)
				{
					if (num2 == 1)
					{
						string cmdText = fun.insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + wonosrc + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
						sqlCommand.ExecuteNonQuery();
						num2 = 0;
						string cmdText2 = fun.select1("Id", "tblInv_WIS_Master Order By Id Desc");
						SqlCommand selectCommand = new SqlCommand(cmdText2, conn);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							num = Convert.ToInt32(dataSet5.Tables[0].Rows[0][0]);
						}
					}
					string cmdText3 = fun.insert("tblInv_WIS_Details", "WISNo,MId,PId,CId,ItemId,IssuedQty", "'" + text + "','" + num + "','" + dataSet2.Tables[0].Rows[i]["PId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["CId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ItemId"].ToString() + "','" + num7.ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, conn);
					sqlCommand2.ExecuteNonQuery();
					string cmdText4 = fun.update("tblDG_Item_Master", "StockQty='" + num6 + "'", "CompId='" + CompId + "' AND Id='" + dataSet2.Tables[0].Rows[i]["ItemId"].ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, conn);
					sqlCommand3.ExecuteNonQuery();
				}
				list.Clear();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			conn.Close();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			WIS_RootAssly();
			string cmdText = fun.update("SD_Cust_WorkOrder_Master", "DryActualRun='1'", "WONo='" + wonosrc + "' AND CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
			conn.Open();
			sqlCommand.ExecuteNonQuery();
			conn.Close();
			Thread.Sleep(1000);
			base.Response.Redirect("WIS_ActualRun_Assembly.aspx?WONo=" + wonosrc + "&ModId=9&SubModId=53&msg=WIS process is completed.");
		}
		catch (Exception)
		{
		}
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Material.aspx?WONo=" + wonosrc + "&ModId=9&SubModId=53");
	}
}

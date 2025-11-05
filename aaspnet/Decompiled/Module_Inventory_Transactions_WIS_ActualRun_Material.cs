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

public class Module_Inventory_Transactions_WIS_ActualRun_Material : Page, IRequiresSessionState
{
	protected UpdateProgress UpdateProgress;

	protected ModalPopupExtender modalPopup;

	protected Label Label2;

	protected CheckBox CheckBox1;

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

	private List<int> listk = new List<int>();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			wonosrc = base.Request.QueryString["WONo"].ToString();
			lblmsg.Text = "";
			ConnString = fun.Connection();
			conn = new SqlConnection(ConnString);
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
		Label2.Text = wonosrc;
		try
		{
			conn.Open();
			SqlDataReader sqlDataReader = null;
			SqlCommand sqlCommand = new SqlCommand("GetSchTime_BOM_Details", conn);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.AddWithValue("@CompId", SqlDbType.VarChar);
			sqlCommand.Parameters["@CompId"].Value = CompId;
			sqlCommand.Parameters.AddWithValue("@WONo", DbType.String);
			sqlCommand.Parameters["@WONo"].Value = wonosrc;
			sqlDataReader = sqlCommand.ExecuteReader();
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
			dataTable.Columns.Add(new DataColumn("Balance BOM Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dry Run Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("After Stock Qty", typeof(string)));
			double num = 0.0;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader[0];
				dataRow[1] = sqlDataReader[1].ToString();
				dataRow[2] = sqlDataReader[2];
				dataRow[3] = sqlDataReader[3];
				dataRow[7] = Convert.ToDouble(sqlDataReader[4]);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_Item_Details", conn);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = sqlDataReader["ItemId"].ToString();
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblDG_Item_Master");
				dataRow[4] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader[0].ToString()));
				dataRow[5] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["UOMBasic"]) + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, conn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "Unit_Master");
				dataRow[6] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				double num2 = 1.0;
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				for (int i = 0; i < list.Count; i++)
				{
					num2 *= list[i];
				}
				dataRow[8] = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
				dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
				sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@WONo"].Value = wonosrc;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@ItemId"].Value = sqlDataReader["ItemId"].ToString();
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@PId"].Value = sqlDataReader["PId"].ToString();
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CId"].Value = sqlDataReader["CId"].ToString();
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				double num3 = 0.0;
				if (dataSet3.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet3.Tables[0].Rows[0]["sum_IssuedQty"].ToString() != "" && dataSet3.Tables[0].Rows.Count > 0)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
					dataRow[11] = num3;
				}
				else
				{
					dataRow[11] = 0;
				}
				if (num2 >= 0.0)
				{
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					num5 = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(num3.ToString()).ToString("N3"));
					num4 = num5 - num6;
					num = num4;
				}
				if (sqlDataReader["PId"].ToString() == "0")
				{
					dataRow[12] = Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3"));
				}
				if (sqlDataReader["PId"].ToString() != "0")
				{
					List<int> list2 = new List<int>();
					list2 = CalBOMTreeQty(CompId, wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					List<int> list3 = new List<int>();
					List<int> list4 = new List<int>();
					for (int num10 = list2.Count; num10 > 0; num10--)
					{
						if (list2.Count > 2)
						{
							list4.Add(list2[num10 - 1]);
						}
						else
						{
							list3.Add(list2[num7]);
							num7++;
						}
					}
					double num11 = 1.0;
					for (int j = 0; j < list3.Count; j++)
					{
						num9 = list3[j++];
						num8 = list3[j];
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", conn);
						sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter4.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter4.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter4.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter4.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter4.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
						sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@ItemId"].Value = dataSet4.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						double num12 = 0.0;
						if (dataSet5.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet5.Tables[0].Rows.Count > 0)
						{
							num12 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						num11 = num11 * Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num12;
					}
					for (int k = 0; k < list4.Count; k++)
					{
						num8 = list4[k++];
						num9 = list4[k];
						double num13 = 1.0;
						List<double> list5 = new List<double>();
						list5 = fun.BOMTreeQty(wonosrc, num9, num8);
						for (int l = 0; l < list5.Count; l++)
						{
							num13 *= list5[l];
						}
						list5.Clear();
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", conn);
						sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
						sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@ItemId"].Value = dataSet6.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@PId"].Value = num9;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CId"].Value = num8;
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						double num14 = 0.0;
						if (dataSet7.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet7.Tables[0].Rows.Count > 0)
						{
							num14 = Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						if (num13 >= 0.0)
						{
							num11 = num11 * Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num14;
						}
					}
					if (num11 > 0.0)
					{
						double num15 = 0.0;
						double num16 = 0.0;
						double num17 = 0.0;
						double num18 = 0.0;
						num17 = Convert.ToDouble(decimal.Parse(sqlDataReader[4].ToString()).ToString("N3"));
						num16 = Convert.ToDouble(decimal.Parse((num11 * num17).ToString()).ToString("N3"));
						num18 = Convert.ToDouble(decimal.Parse(num3.ToString()).ToString("N3"));
						num15 = num16 - num18;
						if (num15 >= 0.0)
						{
							dataRow[12] = num15;
						}
						else
						{
							dataRow[12] = 0;
						}
					}
					else
					{
						dataRow[12] = 0;
					}
					double num19 = 0.0;
					double num20 = 0.0;
					double num21 = 0.0;
					num21 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					double num22 = 0.0;
					num22 = Convert.ToDouble(dataRow[12]);
					if (num21 >= 0.0 && num22 >= 0.0)
					{
						if (num21 >= num22)
						{
							num19 = num21 - num22;
							num20 = num22;
						}
						else if (num22 >= num21)
						{
							num19 = 0.0;
							num20 = num21;
						}
					}
					dataRow[13] = num20;
					dataRow[14] = num19;
					num11 = 0.0;
					list2.Clear();
				}
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

	public List<int> CalBOMTreeQty(int CompId, string WONo, int Pid, int Cid)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			if (Pid > 0)
			{
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("PId", "tblDG_BOM_Master", "CompId='" + CompId + "' AND WONo='" + WONo + "' AND CId='" + Pid + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				listk.Add(Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]));
				listk.Add(Pid);
				CalBOMTreeQty(CompId, WONo, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Cid);
			}
		}
		catch (Exception)
		{
		}
		return listk;
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
		base.Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Assembly.aspx?WONo=" + wonosrc + "&ModId=9&SubModId=53");
	}

	protected void ImageButton1_Click(object sender, EventArgs e)
	{
	}

	public void WIS_Material()
	{
		try
		{
			conn.Open();
			string text = "";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSchTime_WISNo", conn);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["WISNo"].ToString()) + 1).ToString("D4"));
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetSchTime_BOM_Details", conn);
			sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter2.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter2.SelectCommand.Parameters["@WONo"].Value = wonosrc;
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_BOM_Master");
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 1;
			int num4 = 0;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataSet dataSet3 = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetSchTime_Item_Details", conn);
				sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter3.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
				sqlDataAdapter3.SelectCommand.Parameters["@Id"].Value = dataSet2.Tables[0].Rows[i][0].ToString();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				double num5 = 1.0;
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataSet2.Tables[0].Rows[i][2]), Convert.ToInt32(dataSet2.Tables[0].Rows[i][3]));
				for (int j = 0; j < list.Count; j++)
				{
					num5 *= list[j];
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
				double num6 = 0.0;
				if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet4.Tables[0].Rows.Count > 0)
				{
					num6 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				double num7 = Math.Round(num5 - num6, 5);
				if (num5 >= 0.0)
				{
					num = Convert.ToDouble(decimal.Parse(num7.ToString()).ToString("N3"));
				}
				if (dataSet2.Tables[0].Rows[i]["PId"].ToString() == "0")
				{
					num2 = num;
				}
				if (dataSet2.Tables[0].Rows[i]["PId"].ToString() != "0")
				{
					List<int> list2 = new List<int>();
					list2 = fun.CalBOMTreeQty(CompId, wonosrc, Convert.ToInt32(dataSet2.Tables[0].Rows[i][2]), Convert.ToInt32(dataSet2.Tables[0].Rows[i][3]));
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					List<int> list3 = new List<int>();
					List<int> list4 = new List<int>();
					for (int num11 = list2.Count; num11 > 0; num11--)
					{
						if (list2.Count > 2)
						{
							list4.Add(list2[num11 - 1]);
						}
						else
						{
							list3.Add(list2[num8]);
							num8++;
						}
					}
					double num12 = 1.0;
					for (int k = 0; k < list3.Count; k++)
					{
						num10 = list3[k++];
						num9 = list3[k];
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", conn);
						sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@PId"].Value = num10;
						sqlDataAdapter5.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter5.SelectCommand.Parameters["@CId"].Value = num9;
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
						sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@ItemId"].Value = dataSet5.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@PId"].Value = num10;
						sqlDataAdapter6.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter6.SelectCommand.Parameters["@CId"].Value = num9;
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						double num13 = 0.0;
						if (dataSet6.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet6.Tables[0].Rows.Count > 0)
						{
							num13 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						num12 = num12 * Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num13;
					}
					for (int l = 0; l < list4.Count; l++)
					{
						num9 = list4[l++];
						num10 = list4[l];
						double num14 = 1.0;
						List<double> list5 = new List<double>();
						list5 = fun.BOMTreeQty(wonosrc, num10, num9);
						for (int m = 0; m < list5.Count; m++)
						{
							num14 *= list5[m];
						}
						list5.Clear();
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetSchTime_BOM_PCIDWise", conn);
						sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@PId"].Value = num10;
						sqlDataAdapter7.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter7.SelectCommand.Parameters["@CId"].Value = num9;
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7, "tblDG_BOM_Master");
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
						sqlDataAdapter8.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@CompId"].Value = CompId;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@WONo"].Value = wonosrc;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@ItemId"].Value = dataSet7.Tables[0].Rows[0]["ItemId"].ToString();
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@PId"].Value = num10;
						sqlDataAdapter8.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
						sqlDataAdapter8.SelectCommand.Parameters["@CId"].Value = num9;
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						double num15 = 0.0;
						if (dataSet8.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet8.Tables[0].Rows.Count > 0)
						{
							num15 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
						}
						if (num14 >= 0.0)
						{
							num12 = num12 * Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) - num15;
						}
					}
					if (num12 > 0.0)
					{
						double num16 = 0.0;
						double num17 = 0.0;
						double num18 = 0.0;
						double num19 = 0.0;
						num18 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i][4].ToString()).ToString("N3"));
						num17 = Convert.ToDouble(decimal.Parse((num12 * num18).ToString()).ToString("N3"));
						num19 = Convert.ToDouble(decimal.Parse(num6.ToString()).ToString("N3"));
						num16 = num17 - num19;
						num2 = ((!(num16 > 0.0)) ? 0.0 : num16);
					}
					else
					{
						num2 = 0.0;
					}
					double num20 = 0.0;
					double num21 = 0.0;
					if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) >= 0.0)
					{
						if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")))
						{
							num20 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
							num21 = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
						}
						else if (Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) >= Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
						{
							num20 = 0.0;
							num21 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
						}
					}
					if (num21 > 0.0)
					{
						if (num3 == 1)
						{
							string cmdText = fun.insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + wonosrc + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
							sqlCommand.ExecuteNonQuery();
							string cmdText2 = fun.select1("Id", "tblInv_WIS_Master Order By Id Desc");
							SqlCommand selectCommand = new SqlCommand(cmdText2, conn);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9, "tblDG_Item_Master");
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								num4 = Convert.ToInt32(dataSet9.Tables[0].Rows[0][0]);
								num3 = 0;
							}
						}
						string cmdText3 = fun.insert("tblInv_WIS_Details", "WISNo,PId,CId,ItemId,IssuedQty,MId", string.Concat("'", text, "','", dataSet2.Tables[0].Rows[i][2], "','", dataSet2.Tables[0].Rows[i][3], "','", dataSet2.Tables[0].Rows[i]["ItemId"].ToString(), "','", num21.ToString(), "','", num4, "'"));
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, conn);
						sqlCommand2.ExecuteNonQuery();
						string cmdText4 = fun.update("tblDG_Item_Master", "StockQty='" + num20 + "'", "CompId='" + CompId + "' AND Id='" + dataSet2.Tables[0].Rows[i]["ItemId"].ToString() + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText4, conn);
						sqlCommand3.ExecuteNonQuery();
					}
					num12 = 0.0;
					list2.Clear();
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

	protected void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			WIS_Material();
			string cmdText = fun.update("SD_Cust_WorkOrder_Master", "DryActualRun='1'", "WONo='" + wonosrc + "' AND CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
			conn.Open();
			sqlCommand.ExecuteNonQuery();
			conn.Close();
			Thread.Sleep(1000);
			base.Response.Redirect("WIS_ActualRun_Material.aspx?WONo=" + wonosrc + "&ModId=9&SubModId=53&msg=WIS process is completed.");
		}
		catch (Exception)
		{
		}
	}
}

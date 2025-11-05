using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Reports_Search_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string _connStr = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

	private int flag;

	private int flag2;

	private string FirstCond = string.Empty;

	private string Supcode = string.Empty;

	private string Itemcode = string.Empty;

	private string ACHead = string.Empty;

	private int CompId;

	private string WONo = string.Empty;

	private string FromDate = string.Empty;

	private string ToDate = string.Empty;

	private string StrDate = string.Empty;

	private string FileName = string.Empty;

	protected CheckBox checkAll;

	protected Label lblGIN;

	protected CheckBoxList chkFields;

	protected Panel Panel2;

	protected Button btnSub;

	protected Button btnExport;

	protected Button btnCancel;

	protected GridView GridView1;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["RAd"]))
			{
				flag = Convert.ToInt32(base.Request.QueryString["RAd"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["RAd2"]))
			{
				flag2 = Convert.ToInt32(base.Request.QueryString["RAd2"]);
			}
			if (flag2 == 1)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]))
				{
					switch (Convert.ToInt32(base.Request.QueryString["type"]))
					{
					case 1:
						FirstCond = " And GQNNo='" + base.Request.QueryString["No"].ToString() + "'";
						break;
					case 3:
						FirstCond = " And PONo='" + base.Request.QueryString["No"].ToString() + "'";
						break;
					case 4:
						FirstCond = " And PVEVNo='" + base.Request.QueryString["No"].ToString() + "'";
						break;
					}
				}
			}
			else if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]))
			{
				switch (Convert.ToInt32(base.Request.QueryString["type"]))
				{
				case 2:
					FirstCond = " And GSNNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 3:
					FirstCond = " And PONo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 4:
					FirstCond = " And PVEVNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FDate"]) && !string.IsNullOrEmpty(base.Request.QueryString["TDate"]))
			{
				FromDate = fun.FromDate(base.Request.QueryString["FDate"]);
				ToDate = fun.FromDate(base.Request.QueryString["TDate"]);
				StrDate = " And PVEVDate between '" + FromDate + "' And '" + ToDate + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["SupId"]))
			{
				Supcode = " And Code='" + base.Request.QueryString["SupId"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Code"]))
			{
				Itemcode = " And ItemCode='" + base.Request.QueryString["Code"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = " And WONo='" + base.Request.QueryString["WONo"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["accval"]) && Convert.ToInt32(base.Request.QueryString["accval"]) != 0)
			{
				string text = string.Empty;
				using (SqlConnection connection = new SqlConnection(_connStr))
				{
					string cmdText = fun.select("Symbol", "AccHead", "Id='" + base.Request.QueryString["accval"] + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						text = dataSet.Tables[0].Rows[0][0].ToString();
					}
				}
				ACHead = " And ACHead='" + text + "'";
			}
			if (!base.IsPostBack)
			{
				BindTableColumns();
				chkFields.Items[0].Selected = true;
				chkFields.Items[1].Selected = true;
				chkFields.Items[2].Selected = true;
				chkFields.Items[3].Selected = true;
				chkFields.Items[4].Selected = true;
			}
			if (flag == 0)
			{
				for (int i = 15; i <= 42; i++)
				{
					chkFields.Items[i].Attributes.Add("style", "display:none;");
				}
			}
			chkFields.Items[45].Attributes.Add("style", "display:none;");
			chkFields.Items[46].Attributes.Add("style", "display:none;");
		}
		catch (Exception)
		{
		}
	}

	protected void ShowGrid(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (ListItem item in chkFields.Items)
			{
				if (item.Selected)
				{
					BoundField boundField = new BoundField();
					boundField.DataField = item.Value;
					boundField.HeaderText = item.Text;
					GridView1.Columns.Add(boundField);
					num++;
				}
			}
			if (num > 0)
			{
				GetData();
			}
		}
		catch (Exception)
		{
		}
	}

	private void BindTableColumns()
	{
		try
		{
			DataTable dataTable = new DataTable();
			using SqlConnection connection = new SqlConnection(_connStr);
			using (SqlCommand sqlCommand = new SqlCommand("sp_columns", connection))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				if (flag2 == 1)
				{
					sqlCommand.Parameters.AddWithValue("@table_name", "View_PVEVNo_Item");
				}
				else
				{
					sqlCommand.Parameters.AddWithValue("@table_name", "View_PVEVNo_Item_GSN");
				}
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			if (dataTable.Rows.Count > 0)
			{
				chkFields.DataSource = dataTable;
				chkFields.DataBind();
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Stock Qty";
				chkFields.Items[5].Text = "PO No";
				chkFields.Items[6].Text = "PO Date";
				chkFields.Items[7].Text = "WO No";
				chkFields.Items[11].Text = "Supplier Name";
				if (flag2 == 1)
				{
					chkFields.Items[12].Text = "GQN No";
					chkFields.Items[13].Text = "GQN Date";
				}
				else
				{
					chkFields.Items[12].Text = "GSN No";
					chkFields.Items[13].Text = "GSN Date";
				}
				chkFields.Items[14].Text = "Accepted Qty";
				chkFields.Items[15].Text = "PVEV NO";
				chkFields.Items[16].Text = "PVEV Date";
				chkFields.Items[17].Text = "BILL No";
				chkFields.Items[18].Text = "BILL Date";
				chkFields.Items[19].Text = "CEN/VAT Entry No";
				chkFields.Items[20].Text = "CEN/VAT Entry Date";
				chkFields.Items[21].Text = "Other Charges";
				chkFields.Items[22].Text = "Other Charges Desc.";
				chkFields.Items[24].Text = "Debit Amount";
				chkFields.Items[25].Text = "Discount Type";
				chkFields.Items[26].Text = "Discount";
				chkFields.Items[27].Text = "Gen. By";
				chkFields.Items[29].Text = "Authorized Date";
				chkFields.Items[30].Text = "Authorized By";
				chkFields.Items[31].Text = "PF Amount";
				chkFields.Items[32].Text = "ExSt Basic In %";
				chkFields.Items[33].Text = "ExSt Basic";
				chkFields.Items[34].Text = "ExSt Educess In %";
				chkFields.Items[35].Text = "ExSt Educess";
				chkFields.Items[36].Text = "ExSt Shecess In %";
				chkFields.Items[37].Text = "ExSt Shecess";
				chkFields.Items[38].Text = "Custom Duty";
				chkFields.Items[42].Text = "Tarrif No";
				chkFields.Items[43].Text = "Ac Head";
				chkFields.Items[44].Text = "Challan No";
			}
		}
		catch (Exception)
		{
		}
	}

	private void GetData()
	{
		try
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(_connStr))
			{
				sqlConnection.Open();
				string text = "";
				string text2 = string.Empty;
				if (flag2 == 1)
				{
					Hashtable hashtable = myhash(0);
					foreach (ListItem item in chkFields.Items)
					{
						if (item.Selected)
						{
							text2 += hashtable[item.Value];
						}
					}
					text = ((flag != 1) ? ("SELECT " + text2 + " FROM View_PVEVNo_Item_Pending where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate) : ("SELECT " + text2 + " FROM View_PVEVNo_Item where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate));
				}
				else
				{
					Hashtable hashtable2 = myhash(1);
					foreach (ListItem item2 in chkFields.Items)
					{
						if (item2.Selected)
						{
							text2 += hashtable2[item2.Value];
						}
					}
					text = ((flag != 1) ? ("SELECT Distinct " + text2 + " FROM View_PVEVNo_Item_GSN where PVEVNo is null And CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate + " group by ItemCode,Description,UOM,StockQty,PONo,PODate,WONO,Qty,Rate,Discount,SupplierName,GSNNo,GSNDate,AcceptedQty,ACHead order by SrNo Asc  ") : ("SELECT " + text2 + " FROM View_PVEVNo_Item_GSN where PVEVNo is not null And CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate));
				}
				using (SqlCommand sqlCommand = new SqlCommand(text, sqlConnection))
				{
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						dataTable.Load(sqlDataReader);
					}
				}
				sqlConnection.Close();
			}
			if (dataTable.Rows.Count > 0)
			{
				GridView1.DataSource = dataTable;
				GridView1.DataBind();
				ViewState["dtList"] = dataTable;
			}
			else
			{
				string empty = string.Empty;
				empty = "No Records to Dispaly.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void checkAll_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (checkAll.Checked)
			{
				foreach (ListItem item in chkFields.Items)
				{
					if (item.Value != "CompId" && item.Value != "Code")
					{
						item.Selected = true;
					}
				}
			}
			else
			{
				foreach (ListItem item2 in chkFields.Items)
				{
					if (item2.Value != "SrNo" && item2.Value != "ItemCode" && item2.Value != "Description" && item2.Value != "UOM" && item2.Value != "StockQty")
					{
						item2.Selected = false;
					}
				}
			}
			if (flag == 0)
			{
				for (int i = 15; i <= 42; i++)
				{
					chkFields.Items[i].Selected = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnExport_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			if (chkFields.Items[0].Selected)
			{
				dataTable.Columns["SrNo"].ColumnName = "Sr No";
			}
			if (chkFields.Items[1].Selected)
			{
				dataTable.Columns["ItemCode"].ColumnName = "Item Code";
			}
			if (chkFields.Items[4].Selected)
			{
				dataTable.Columns["StockQty"].ColumnName = "Stock Qty";
			}
			if (chkFields.Items[5].Selected)
			{
				dataTable.Columns["PONo"].ColumnName = "PO No";
			}
			if (chkFields.Items[6].Selected)
			{
				dataTable.Columns["PODate"].ColumnName = "PO Date";
			}
			if (chkFields.Items[7].Selected)
			{
				dataTable.Columns["WONo"].ColumnName = "WO No";
			}
			if (chkFields.Items[11].Selected)
			{
				dataTable.Columns["SupplierName"].ColumnName = "Supplier Name";
			}
			if (flag2 == 1)
			{
				if (chkFields.Items[12].Selected)
				{
					dataTable.Columns["GQNNo"].ColumnName = "GQN No";
				}
				if (chkFields.Items[13].Selected)
				{
					dataTable.Columns["GQNDate"].ColumnName = "GQN Date";
				}
			}
			else
			{
				if (chkFields.Items[12].Selected)
				{
					dataTable.Columns["GSNNo"].ColumnName = "GSN No";
				}
				if (chkFields.Items[13].Selected)
				{
					dataTable.Columns["GSNDate"].ColumnName = "GSN Date";
				}
			}
			if (chkFields.Items[14].Selected)
			{
				dataTable.Columns["AcceptedQty"].ColumnName = "Accepted Qty";
			}
			if (chkFields.Items[15].Selected)
			{
				dataTable.Columns["PVEVNO"].ColumnName = "PVEV NO";
			}
			if (chkFields.Items[16].Selected)
			{
				dataTable.Columns["PVEVDate"].ColumnName = "PVEV Date";
			}
			if (chkFields.Items[17].Selected)
			{
				dataTable.Columns["BillNo"].ColumnName = "Bill No";
			}
			if (chkFields.Items[18].Selected)
			{
				dataTable.Columns["BillDate"].ColumnName = "Bill Date";
			}
			if (chkFields.Items[19].Selected)
			{
				dataTable.Columns["CENVATEntryNo"].ColumnName = "CEN/VAT Entry No";
			}
			if (chkFields.Items[20].Selected)
			{
				dataTable.Columns["CENVATEntryDate"].ColumnName = "CEN/VAT Entry Date";
			}
			if (chkFields.Items[21].Selected)
			{
				dataTable.Columns["OtherCharges"].ColumnName = "Other Charges";
			}
			if (chkFields.Items[22].Selected)
			{
				dataTable.Columns["OtherChaDesc"].ColumnName = "Other Charges Desc.";
			}
			if (chkFields.Items[24].Selected)
			{
				dataTable.Columns["DebitAmt"].ColumnName = "Debit Amount";
			}
			if (chkFields.Items[25].Selected)
			{
				dataTable.Columns["DiscountType"].ColumnName = "Discount Type";
			}
			if (chkFields.Items[26].Selected)
			{
				dataTable.Columns["PVEVDiscount"].ColumnName = "PVEV Discount";
			}
			if (chkFields.Items[27].Selected)
			{
				dataTable.Columns["EmpName"].ColumnName = "Gen. By";
			}
			if (chkFields.Items[29].Selected)
			{
				dataTable.Columns["AuthorizeDate"].ColumnName = "Authorized Date";
			}
			if (chkFields.Items[30].Selected)
			{
				dataTable.Columns["AuthorizeBy"].ColumnName = "Authorized By";
			}
			if (chkFields.Items[31].Selected)
			{
				dataTable.Columns["PFAmt"].ColumnName = "PF Amount";
			}
			if (chkFields.Items[32].Selected)
			{
				dataTable.Columns["ExStBasicInPer"].ColumnName = "ExSt Basic In %";
			}
			if (chkFields.Items[33].Selected)
			{
				dataTable.Columns["ExStBasic"].ColumnName = "ExSt Basic";
			}
			if (chkFields.Items[34].Selected)
			{
				dataTable.Columns["ExStEducessInPer"].ColumnName = "ExSt Educess In %";
			}
			if (chkFields.Items[35].Selected)
			{
				dataTable.Columns["ExStEducess"].ColumnName = "ExSt Educess";
			}
			if (chkFields.Items[36].Selected)
			{
				dataTable.Columns["ExStShecessInPer"].ColumnName = "ExSt Shecess In %";
			}
			if (chkFields.Items[37].Selected)
			{
				dataTable.Columns["ExStShecess"].ColumnName = "ExSt Shecess";
			}
			if (chkFields.Items[38].Selected)
			{
				dataTable.Columns["CustomDuty"].ColumnName = "Custom Duty";
			}
			if (chkFields.Items[41].Selected)
			{
				dataTable.Columns["TarrifNo"].ColumnName = "Tarrif No";
			}
			if (chkFields.Items[42].Selected)
			{
				dataTable.Columns["ACHead"].ColumnName = "Ac Head";
			}
			if (flag == 1)
			{
				FileName = "PVEV_Completed";
			}
			else
			{
				FileName = "PVEV_Pending";
			}
			ExportToExcel exportToExcel = new ExportToExcel();
			exportToExcel.ExportDataToExcel(dataTable, FileName);
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Search.aspx");
	}

	public Hashtable myhash(int flag)
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("SrNo", "ROW_NUMBER() OVER (ORDER BY ItemCode) AS SrNo");
		hashtable.Add("ItemCode", ",ItemCode");
		hashtable.Add("Description", ",Description");
		hashtable.Add("UOM", ",UOM");
		hashtable.Add("StockQty", ",StockQty");
		hashtable.Add("PONo", ",PONo");
		hashtable.Add("PODate", ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(PODate, CHARINDEX('-', PODate) + 1, 2) + '-' + LEFT(PODate, CHARINDEX('-', PODate) - 1) + '-' + RIGHT(PODate, CHARINDEX('-',REVERSE(PODate)) - 1)), 103), '/', '-') AS PODate");
		hashtable.Add("WONO", ",WONO");
		hashtable.Add("Qty", ",Qty");
		hashtable.Add("Rate", ",Rate");
		hashtable.Add("Discount", ",Discount");
		hashtable.Add("SupplierName", ",SupplierName");
		if (flag == 0)
		{
			hashtable.Add("GQNNo", ",GQNNo");
		}
		else
		{
			hashtable.Add("GSNNo", ",GSNNo");
		}
		if (flag == 0)
		{
			hashtable.Add("GQNDate", ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(GQNDate, CHARINDEX('-', GQNDate) + 1, 2) + '-' + LEFT(GQNDate, CHARINDEX('-', GQNDate) - 1) + '-' + RIGHT(GQNDate, CHARINDEX('-',REVERSE(GQNDate)) - 1)), 103), '/', '-') AS GQNDate");
		}
		else
		{
			hashtable.Add("GSNDate", ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(GSNDate, CHARINDEX('-', GSNDate) + 1, 2) + '-' + LEFT(GSNDate, CHARINDEX('-', GSNDate) - 1) + '-' + RIGHT(GSNDate, CHARINDEX('-',REVERSE(GSNDate)) - 1)), 103), '/', '-') AS GSNDate");
		}
		hashtable.Add("AcceptedQty", ",AcceptedQty");
		hashtable.Add("PVEVNo", ",PVEVNo");
		hashtable.Add("PVEVDate", ",(CASE WHEN PVEVDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(PVEVDate, CHARINDEX('-', PVEVDate)+ 1, 2) + '-' + LEFT(PVEVDate, CHARINDEX('-', PVEVDate) - 1)+ '-' + RIGHT(PVEVDate, CHARINDEX('-', REVERSE(PVEVDate)) - 1)), 103), '/', '-')) END) AS PVEVDate");
		hashtable.Add("BillNo", ",BillNo");
		hashtable.Add("BillDate", ",(CASE WHEN BillDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(BillDate, CHARINDEX('-', BillDate)+ 1, 2) + '-' + LEFT(BillDate, CHARINDEX('-', BillDate) - 1)+ '-' + RIGHT(BillDate, CHARINDEX('-', REVERSE(BillDate)) - 1)), 103), '/', '-')) END) AS BillDate");
		hashtable.Add("CENVATEntryNo", ",CENVATEntryNo");
		hashtable.Add("CENVATEntryDate", ",(CASE WHEN CENVATEntryDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(CENVATEntryDate, CHARINDEX('-', CENVATEntryDate)+ 1, 2) + '-' + LEFT(CENVATEntryDate, CHARINDEX('-', CENVATEntryDate) - 1)+ '-' + RIGHT(CENVATEntryDate, CHARINDEX('-', REVERSE(CENVATEntryDate)) - 1)), 103), '/', '-')) END) AS CENVATEntryDate");
		hashtable.Add("OtherCharges", ",OtherCharges");
		hashtable.Add("OtherChaDesc", ",OtherChaDesc");
		hashtable.Add("Narration", ",Narration ");
		hashtable.Add("DebitAmt", ",DebitAmt");
		hashtable.Add("DiscountType", ",DiscountType");
		hashtable.Add("PVEVDiscount", ",PVEVDiscount ");
		hashtable.Add("EmpName", ",EmpName");
		hashtable.Add("Authorize", ",(CASE WHEN Authorize IS NULL THEN '' ELSE (CASE WHEN Authorize=0 THEN '' ELSE 'Yes' END) END) AS Authorize");
		hashtable.Add("AuthorizeDate", ",(CASE WHEN AuthorizeDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(AuthorizeDate, CHARINDEX('-', AuthorizeDate)+ 1, 2) + '-' + LEFT(AuthorizeDate, CHARINDEX('-', AuthorizeDate) - 1)+ '-' + RIGHT(AuthorizeDate, CHARINDEX('-', REVERSE(AuthorizeDate)) - 1)), 103), '/', '-')) END) AS AuthorizeDate");
		hashtable.Add("AuthorizeBy", ",AuthorizeBy");
		hashtable.Add("PFAmt", ",PFAmt");
		hashtable.Add("ExStBasicInPer", ",ExStBasicInPer");
		hashtable.Add("ExStBasic", ",ExStBasic");
		hashtable.Add("ExStEducessInPer", ",ExStEducessInPer");
		hashtable.Add("ExStEducess", ",ExStEducess");
		hashtable.Add("ExStShecessInPer", ",ExStShecessInPer");
		hashtable.Add("ExStShecess", ",ExStShecess");
		hashtable.Add("CustomDuty", ",CustomDuty");
		hashtable.Add("VAT", ",VAT");
		hashtable.Add("CST", ",CST");
		hashtable.Add("Freight", ",Freight");
		hashtable.Add("TarrifNo", ",TarrifNo");
		hashtable.Add("ACHead", ",ACHead");
		hashtable.Add("ChallanNo", ",ChallanNo");
		return hashtable;
	}
}

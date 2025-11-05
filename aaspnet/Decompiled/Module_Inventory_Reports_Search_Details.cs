using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Reports_Search_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string _connStr = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

	private int flag;

	private string FirstCond = string.Empty;

	private string Supcode = string.Empty;

	private string Itemcode = string.Empty;

	private string ACHead = string.Empty;

	private int CompId;

	private string WONo = string.Empty;

	private string FromDate = string.Empty;

	private string ToDate = string.Empty;

	private string StrDate = string.Empty;

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
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]))
			{
				switch (Convert.ToInt32(base.Request.QueryString["type"]))
				{
				case 1:
					FirstCond = " And GINNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 2:
					FirstCond = " And GRRNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 3:
					FirstCond = " And GQNNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 4:
					FirstCond = " And GSNNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 5:
					FirstCond = " And PONo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FDate"]) && !string.IsNullOrEmpty(base.Request.QueryString["TDate"]))
			{
				FromDate = fun.FromDate(base.Request.QueryString["FDate"]);
				ToDate = fun.FromDate(base.Request.QueryString["TDate"]);
				if (flag == 0)
				{
					StrDate = " And Date between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 1)
				{
					StrDate = " And GINDate between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 2)
				{
					StrDate = " And GRRDate between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 3)
				{
					StrDate = " And GQNDate between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 4)
				{
					StrDate = " And GSNDate between '" + FromDate + "' And '" + ToDate + "'";
				}
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
			if (flag != 4)
			{
				chkFields.Items[40].Attributes.Add("style", "display:none;");
				chkFields.Items[41].Attributes.Add("style", "display:none;");
				chkFields.Items[42].Attributes.Add("style", "display:none;");
			}
			else
			{
				chkFields.Items[36].Attributes.Add("style", "display:none;");
				chkFields.Items[37].Attributes.Add("style", "display:none;");
			}
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
		DataTable dataTable = new DataTable();
		using SqlConnection connection = new SqlConnection(_connStr);
		if (flag != 4)
		{
			using (SqlCommand sqlCommand = new SqlCommand("sp_columns", connection))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@table_name", "View_PO_PR_SPR_GIN");
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			if (dataTable.Rows.Count > 0)
			{
				chkFields.DataSource = dataTable;
				chkFields.DataBind();
			}
			chkFields.Items[0].Text = "Sr No";
			chkFields.Items[1].Text = "Item Code";
			chkFields.Items[4].Text = "Stock Qty";
			chkFields.Items[5].Text = "PR No";
			chkFields.Items[6].Text = "PR Date";
			chkFields.Items[7].Text = "PR Qty";
			chkFields.Items[8].Text = "SPR No";
			chkFields.Items[9].Text = "SPR Date";
			chkFields.Items[10].Text = "SPR Qty";
			chkFields.Items[11].Text = "PO NO";
			chkFields.Items[12].Text = "PO Date";
			chkFields.Items[13].Text = "WO No";
			chkFields.Items[14].Text = "PO Qty";
			chkFields.Items[17].Text = "Supplier Name";
			chkFields.Items[18].Text = "Del. Date";
			chkFields.Items[20].Text = "Authorized By";
			chkFields.Items[21].Text = "Authorized Date";
			chkFields.Items[22].Text = "Authorized Time";
			chkFields.Items[23].Text = "GIN No";
			chkFields.Items[24].Text = "GIN. Date";
			chkFields.Items[25].Text = "Challan No";
			chkFields.Items[26].Text = "Challan Date";
			chkFields.Items[27].Text = "Gate Entery No";
			chkFields.Items[28].Text = "Mode of Transport";
			chkFields.Items[29].Text = "Vehicle No";
			chkFields.Items[30].Text = "Challan Qty";
			chkFields.Items[31].Text = "GIN Qty";
			chkFields.Items[32].Text = "GRR No";
			chkFields.Items[33].Text = "GRR Date";
			chkFields.Items[34].Text = "GRR Qty";
			chkFields.Items[35].Text = "GQN No";
			chkFields.Items[36].Text = "GQN Date";
			chkFields.Items[37].Text = "Accepted Qty";
			chkFields.Items[38].Text = "Rejected Qty";
			chkFields.Items[39].Text = "Ac Head";
			return;
		}
		using (SqlCommand sqlCommand2 = new SqlCommand("sp_columns", connection))
		{
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.AddWithValue("@table_name", "View_PO_PR_SPR_GSN");
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		if (dataTable.Rows.Count > 0)
		{
			chkFields.DataSource = dataTable;
			chkFields.DataBind();
		}
		chkFields.Items[0].Text = "Sr No";
		chkFields.Items[1].Text = "Item Code";
		chkFields.Items[4].Text = "Stock Qty";
		chkFields.Items[5].Text = "PR No";
		chkFields.Items[6].Text = "PR Date";
		chkFields.Items[7].Text = "PR Qty";
		chkFields.Items[8].Text = "SPR No";
		chkFields.Items[9].Text = "SPR Date";
		chkFields.Items[10].Text = "SPR Qty";
		chkFields.Items[11].Text = "PO NO";
		chkFields.Items[12].Text = "PO Date";
		chkFields.Items[13].Text = "WO No";
		chkFields.Items[14].Text = "PO Qty";
		chkFields.Items[17].Text = "Supplier Name";
		chkFields.Items[18].Text = "Del. Date";
		chkFields.Items[20].Text = "Authorized By";
		chkFields.Items[21].Text = "Authorized Date";
		chkFields.Items[22].Text = "Authorized Time";
		chkFields.Items[23].Text = "GIN No";
		chkFields.Items[24].Text = "GIN. Date";
		chkFields.Items[25].Text = "Challan No";
		chkFields.Items[26].Text = "Challan Date";
		chkFields.Items[27].Text = "Gate Entery No";
		chkFields.Items[28].Text = "Mode of Transport";
		chkFields.Items[29].Text = "Vehicle No";
		chkFields.Items[30].Text = "Challan Qty";
		chkFields.Items[31].Text = "GIN Qty";
		chkFields.Items[32].Text = "Ac Head";
		chkFields.Items[33].Text = "GSN No";
		chkFields.Items[34].Text = "GSN Date";
		chkFields.Items[35].Text = "GSN Qty";
	}

	private void GetData()
	{
		try
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection connection = new SqlConnection(_connStr))
			{
				string text = "";
				string text2 = string.Empty;
				int num = 0;
				if (flag != 4)
				{
					for (int i = 23; i < chkFields.Items.Count; i++)
					{
						if (chkFields.Items[i].Selected)
						{
							num++;
						}
					}
					if (chkFields.Items[0].Selected)
					{
						text2 = "ROW_NUMBER() OVER (ORDER BY ItemCode) AS SrNo";
					}
					if (chkFields.Items[1].Selected)
					{
						text2 += ",ItemCode";
					}
					if (chkFields.Items[2].Selected)
					{
						text2 += ",Description";
					}
					if (chkFields.Items[3].Selected)
					{
						text2 += ",UOM";
					}
					if (chkFields.Items[4].Selected)
					{
						text2 += ",StockQty";
					}
					if (chkFields.Items[5].Selected)
					{
						text2 += ",PRNo";
					}
					if (chkFields.Items[6].Selected)
					{
						text2 += ",PRDate";
					}
					if (chkFields.Items[7].Selected)
					{
						text2 += ",PRQty";
					}
					if (chkFields.Items[8].Selected)
					{
						text2 += ",SPRNo";
					}
					if (chkFields.Items[9].Selected)
					{
						text2 += ",SPRDate";
					}
					if (chkFields.Items[10].Selected)
					{
						text2 += ",SPRQty";
					}
					if (chkFields.Items[11].Selected)
					{
						text2 += ",PONo";
					}
					if (chkFields.Items[12].Selected)
					{
						text2 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(Date, CHARINDEX('-', Date) + 1, 2) + '-' + LEFT(Date, CHARINDEX('-', Date) - 1) + '-' + RIGHT(Date, CHARINDEX('-',REVERSE(Date)) - 1)), 103), '/', '-') AS Date";
					}
					if (chkFields.Items[13].Selected)
					{
						text2 += ",WONo";
					}
					if (chkFields.Items[14].Selected)
					{
						text2 += ",Qty";
					}
					if (chkFields.Items[15].Selected)
					{
						text2 += ",Rate";
					}
					if (chkFields.Items[16].Selected)
					{
						text2 += ",Discount";
					}
					if (chkFields.Items[17].Selected)
					{
						text2 += ",SupplierName";
					}
					if (chkFields.Items[18].Selected)
					{
						text2 += ",DelDate";
					}
					if (chkFields.Items[19].Selected)
					{
						text2 += ",Authorized";
					}
					if (chkFields.Items[20].Selected)
					{
						text2 += ",AuthorizedBy";
					}
					if (chkFields.Items[21].Selected)
					{
						text2 += ",AuthorizeDate";
					}
					if (chkFields.Items[22].Selected)
					{
						text2 += ",AuthorizeTime";
					}
					if (chkFields.Items[23].Selected)
					{
						text2 += ",GINNo";
					}
					if (chkFields.Items[24].Selected)
					{
						text2 += ",(CASE WHEN dbo.View_PO_PR_SPR_GIN.GINDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(View_PO_PR_SPR_GIN.GINDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GINDate)+ 1, 2) + '-' + LEFT(View_PO_PR_SPR_GIN.GINDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GINDate) - 1)+ '-' + RIGHT(View_PO_PR_SPR_GIN.GINDate, CHARINDEX('-', REVERSE(View_PO_PR_SPR_GIN.GINDate)) - 1)), 103), '/', '-')) END) AS GINDate";
					}
					if (chkFields.Items[25].Selected)
					{
						text2 += ",ChallanNo";
					}
					if (chkFields.Items[26].Selected)
					{
						text2 += ",(CASE WHEN dbo.View_PO_PR_SPR_GIN.ChallanDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(View_PO_PR_SPR_GIN.ChallanDate, CHARINDEX('-', View_PO_PR_SPR_GIN.ChallanDate)+ 1, 2) + '-' + LEFT(View_PO_PR_SPR_GIN.ChallanDate, CHARINDEX('-', View_PO_PR_SPR_GIN.ChallanDate) - 1)+ '-' + RIGHT(View_PO_PR_SPR_GIN.ChallanDate, CHARINDEX('-', REVERSE(View_PO_PR_SPR_GIN.ChallanDate)) - 1)), 103), '/', '-')) END) AS ChallanDate";
					}
					if (chkFields.Items[27].Selected)
					{
						text2 += ",GateEntryNo";
					}
					if (chkFields.Items[28].Selected)
					{
						text2 += ",ModeofTransport";
					}
					if (chkFields.Items[29].Selected)
					{
						text2 += ",VehicleNo";
					}
					if (chkFields.Items[30].Selected)
					{
						text2 += ",ChallanQty";
					}
					if (chkFields.Items[31].Selected)
					{
						text2 += ",GINQty";
					}
					if (chkFields.Items[32].Selected)
					{
						text2 += ",GRRNo";
					}
					if (chkFields.Items[33].Selected)
					{
						text2 += ",(CASE WHEN dbo.View_PO_PR_SPR_GIN.GRRDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(View_PO_PR_SPR_GIN.GRRDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GRRDate)+ 1, 2) + '-' + LEFT(View_PO_PR_SPR_GIN.GRRDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GRRDate) - 1)+ '-' + RIGHT(View_PO_PR_SPR_GIN.GRRDate, CHARINDEX('-', REVERSE(View_PO_PR_SPR_GIN.GRRDate)) - 1)), 103), '/', '-')) END) AS GRRDate";
					}
					if (chkFields.Items[34].Selected)
					{
						text2 += ",GRRQty";
					}
					if (chkFields.Items[35].Selected)
					{
						text2 += ",GQNNo";
					}
					if (chkFields.Items[36].Selected)
					{
						text2 += ",(CASE WHEN dbo.View_PO_PR_SPR_GIN.GQNDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(View_PO_PR_SPR_GIN.GQNDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GQNDate)+ 1, 2) + '-' + LEFT(View_PO_PR_SPR_GIN.GQNDate, CHARINDEX('-', View_PO_PR_SPR_GIN.GQNDate) - 1)+ '-' + RIGHT(View_PO_PR_SPR_GIN.GQNDate, CHARINDEX('-', REVERSE(View_PO_PR_SPR_GIN.GQNDate)) - 1)), 103), '/', '-')) END) AS GQNDate";
					}
					if (chkFields.Items[37].Selected)
					{
						text2 += ",AcceptedQty";
					}
					if (chkFields.Items[38].Selected)
					{
						text2 += ",RejectedQty";
					}
					if (chkFields.Items[39].Selected)
					{
						text2 += ",ACHead";
					}
					text = ((!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]) && base.Request.QueryString["type"] == "5" && num == 0 && flag >= 0 && StrDate == "") ? ("SELECT " + text2 + " FROM View_PO_PR_SPR_Item where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate) : ((!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]) && base.Request.QueryString["type"] != "5" && base.Request.QueryString["type"] != "0" && num == 0 && flag >= 0 && StrDate == "") ? ("SELECT " + text2 + " FROM View_PO_PR_SPR_GIN where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate + " ") : ((num != 0 || flag < 0 || !(StrDate == "")) ? ("SELECT " + text2 + " FROM View_PO_PR_SPR_GIN where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate) : ("SELECT " + text2 + " FROM View_PO_PR_SPR_Item where CompId='" + CompId + "'" + Supcode + ACHead + WONo + Itemcode + StrDate))));
				}
				else
				{
					for (int j = 23; j < chkFields.Items.Count; j++)
					{
						if (chkFields.Items[j].Selected)
						{
							num++;
						}
					}
					if (chkFields.Items[0].Selected)
					{
						text2 = "ROW_NUMBER() OVER (ORDER BY ItemCode) AS SrNo";
					}
					if (chkFields.Items[1].Selected)
					{
						text2 += ",ItemCode";
					}
					if (chkFields.Items[2].Selected)
					{
						text2 += ",Description";
					}
					if (chkFields.Items[3].Selected)
					{
						text2 += ",UOM";
					}
					if (chkFields.Items[4].Selected)
					{
						text2 += ",StockQty";
					}
					if (chkFields.Items[5].Selected)
					{
						text2 += ",PRNo";
					}
					if (chkFields.Items[6].Selected)
					{
						text2 += ",PRDate";
					}
					if (chkFields.Items[7].Selected)
					{
						text2 += ",PRQty";
					}
					if (chkFields.Items[8].Selected)
					{
						text2 += ",SPRNo";
					}
					if (chkFields.Items[9].Selected)
					{
						text2 += ",SPRDate";
					}
					if (chkFields.Items[10].Selected)
					{
						text2 += ",SPRQty";
					}
					if (chkFields.Items[11].Selected)
					{
						text2 += ",PONo";
					}
					if (chkFields.Items[12].Selected)
					{
						text2 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(Date, CHARINDEX('-', Date) + 1, 2) + '-' + LEFT(Date, CHARINDEX('-', Date) - 1) + '-' + RIGHT(Date, CHARINDEX('-',REVERSE(Date)) - 1)), 103), '/', '-') AS Date";
					}
					if (chkFields.Items[13].Selected)
					{
						text2 += ",WONo";
					}
					if (chkFields.Items[14].Selected)
					{
						text2 += ",Qty";
					}
					if (chkFields.Items[15].Selected)
					{
						text2 += ",Rate";
					}
					if (chkFields.Items[16].Selected)
					{
						text2 += ",Discount";
					}
					if (chkFields.Items[17].Selected)
					{
						text2 += ",SupplierName";
					}
					if (chkFields.Items[18].Selected)
					{
						text2 += ",DelDate";
					}
					if (chkFields.Items[19].Selected)
					{
						text2 += ",Authorized";
					}
					if (chkFields.Items[20].Selected)
					{
						text2 += ",AuthorizedBy";
					}
					if (chkFields.Items[21].Selected)
					{
						text2 += ",AuthorizeDate";
					}
					if (chkFields.Items[22].Selected)
					{
						text2 += ",AuthorizeTime";
					}
					if (chkFields.Items[23].Selected)
					{
						text2 += ",GINNo";
					}
					if (chkFields.Items[24].Selected)
					{
						text2 += ",(CASE WHEN GINDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(GINDate, CHARINDEX('-',GINDate)+ 1, 2) + '-' + LEFT(GINDate, CHARINDEX('-',GINDate) - 1)+ '-' + RIGHT(GINDate, CHARINDEX('-', REVERSE(GINDate)) - 1)), 103), '/', '-')) END) AS GINDate";
					}
					if (chkFields.Items[25].Selected)
					{
						text2 += ",ChallanNo";
					}
					if (chkFields.Items[26].Selected)
					{
						text2 += ",(CASE WHEN ChallanDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(ChallanDate, CHARINDEX('-',ChallanDate)+ 1, 2) + '-' + LEFT(ChallanDate, CHARINDEX('-',ChallanDate) - 1)+ '-' + RIGHT(ChallanDate, CHARINDEX('-', REVERSE(ChallanDate)) - 1)), 103), '/', '-')) END) AS ChallanDate";
					}
					if (chkFields.Items[27].Selected)
					{
						text2 += ",GateEntryNo";
					}
					if (chkFields.Items[28].Selected)
					{
						text2 += ",ModeofTransport";
					}
					if (chkFields.Items[29].Selected)
					{
						text2 += ",VehicleNo";
					}
					if (chkFields.Items[30].Selected)
					{
						text2 += ",ChallanQty";
					}
					if (chkFields.Items[31].Selected)
					{
						text2 += ",GINQty";
					}
					if (chkFields.Items[32].Selected)
					{
						text2 += ",ACHead";
					}
					if (num != 0)
					{
						if (chkFields.Items[33].Selected)
						{
							text2 += ",GSNNo";
						}
						if (chkFields.Items[34].Selected)
						{
							text2 += ",(CASE WHEN GSNDate IS NULL THEN '' ELSE(REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(GSNDate, CHARINDEX('-',GSNDate)+ 1, 2) + '-' + LEFT(GSNDate, CHARINDEX('-',GSNDate) - 1)+ '-' + RIGHT(GSNDate, CHARINDEX('-', REVERSE(GSNDate)) - 1)), 103), '/', '-')) END) AS GSNDate";
						}
						if (chkFields.Items[35].Selected)
						{
							text2 += ",GSNQty";
						}
					}
					text = ((!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]) && base.Request.QueryString["type"] == "4" && num == 0 && flag == 4 && StrDate == "") ? ("SELECT " + text2 + " FROM View_PO_PR_SPR_GSN where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate + " ") : ((num != 0 || flag != 4 || !(StrDate == "")) ? ("SELECT " + text2 + " FROM View_PO_PR_SPR_GSN where CompId='" + CompId + "'" + FirstCond + Supcode + ACHead + WONo + Itemcode + StrDate) : ("SELECT " + text2 + " FROM View_PO_PR_SPR_Item where CompId='" + CompId + "'" + Supcode + ACHead + WONo + Itemcode + StrDate)));
				}
				using SqlCommand selectCommand = new SqlCommand(text, connection);
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataTable);
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
					if (item.Value != "CompId" && item.Value != "AHId" && item.Value != "Code")
					{
						item.Selected = true;
					}
				}
				return;
			}
			foreach (ListItem item2 in chkFields.Items)
			{
				if (item2.Value != "SrNo" && item2.Value != "ItemCode" && item2.Value != "Description" && item2.Value != "UOM" && item2.Value != "StockQty")
				{
					item2.Selected = false;
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
			if (flag != 4)
			{
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
					dataTable.Columns["PRNo"].ColumnName = "PR No";
				}
				if (chkFields.Items[6].Selected)
				{
					dataTable.Columns["PRDate"].ColumnName = "PR Date";
				}
				if (chkFields.Items[7].Selected)
				{
					dataTable.Columns["PRQty"].ColumnName = "PR Qty";
				}
				if (chkFields.Items[8].Selected)
				{
					dataTable.Columns["SPRNo"].ColumnName = "SPR No";
				}
				if (chkFields.Items[9].Selected)
				{
					dataTable.Columns["SPRDate"].ColumnName = "SPR Date";
				}
				if (chkFields.Items[10].Selected)
				{
					dataTable.Columns["SPRQty"].ColumnName = "SPR Qty";
				}
				if (chkFields.Items[11].Selected)
				{
					dataTable.Columns["PONO"].ColumnName = "PO NO";
				}
				if (chkFields.Items[12].Selected)
				{
					dataTable.Columns["Date"].ColumnName = "PO Date";
				}
				if (chkFields.Items[13].Selected)
				{
					dataTable.Columns["WONo"].ColumnName = "WO No";
				}
				if (chkFields.Items[14].Selected)
				{
					dataTable.Columns["Qty"].ColumnName = "PO Qty";
				}
				if (chkFields.Items[17].Selected)
				{
					dataTable.Columns["SupplierName"].ColumnName = "Supplier Name";
				}
				if (chkFields.Items[18].Selected)
				{
					dataTable.Columns["DelDate"].ColumnName = "Del. Date";
				}
				if (chkFields.Items[20].Selected)
				{
					dataTable.Columns["AuthorizedBy"].ColumnName = "Authorized By";
				}
				if (chkFields.Items[21].Selected)
				{
					dataTable.Columns["AuthorizeDate"].ColumnName = "Authorized Date";
				}
				if (chkFields.Items[22].Selected)
				{
					dataTable.Columns["AuthorizeTime"].ColumnName = "Authorized Time";
				}
				if (chkFields.Items[23].Selected)
				{
					dataTable.Columns["GINNo"].ColumnName = "GIN No";
				}
				if (chkFields.Items[24].Selected)
				{
					dataTable.Columns["GINDate"].ColumnName = "GIN. Date";
				}
				if (chkFields.Items[25].Selected)
				{
					dataTable.Columns["ChallanNo"].ColumnName = "Challan No";
				}
				if (chkFields.Items[26].Selected)
				{
					dataTable.Columns["ChallanDate"].ColumnName = "Challan Date";
				}
				if (chkFields.Items[27].Selected)
				{
					dataTable.Columns["GateEntryNo"].ColumnName = "Gate Entry No";
				}
				if (chkFields.Items[28].Selected)
				{
					dataTable.Columns["ModeofTransport"].ColumnName = "Mode of Transport";
				}
				if (chkFields.Items[29].Selected)
				{
					dataTable.Columns["VehicleNo"].ColumnName = "Vehicle No";
				}
				if (chkFields.Items[30].Selected)
				{
					dataTable.Columns["ChallanQty"].ColumnName = "Challan Qty";
				}
				if (chkFields.Items[31].Selected)
				{
					dataTable.Columns["GINQty"].ColumnName = "GIN Qty";
				}
				if (chkFields.Items[32].Selected)
				{
					dataTable.Columns["GRRNo"].ColumnName = "GRR No";
				}
				if (chkFields.Items[33].Selected)
				{
					dataTable.Columns["GRRDate"].ColumnName = "GRR Date";
				}
				if (chkFields.Items[34].Selected)
				{
					dataTable.Columns["GRRQty"].ColumnName = "GRR Qty";
				}
				if (chkFields.Items[35].Selected)
				{
					dataTable.Columns["GQNNo"].ColumnName = "GQN No";
				}
				if (chkFields.Items[36].Selected)
				{
					dataTable.Columns["GQNDate"].ColumnName = "GQN Date";
				}
				if (chkFields.Items[37].Selected)
				{
					dataTable.Columns["AcceptedQty"].ColumnName = "Accepted Qty";
				}
				if (chkFields.Items[38].Selected)
				{
					dataTable.Columns["RejectedQty"].ColumnName = "Rejected Qty";
				}
				if (chkFields.Items[39].Selected)
				{
					dataTable.Columns["AcHead"].ColumnName = "Ac Head";
				}
			}
			else
			{
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
					dataTable.Columns["PRNo"].ColumnName = "PR No";
				}
				if (chkFields.Items[6].Selected)
				{
					dataTable.Columns["PRDate"].ColumnName = "PR Date";
				}
				if (chkFields.Items[7].Selected)
				{
					dataTable.Columns["PRQty"].ColumnName = "PR Qty";
				}
				if (chkFields.Items[8].Selected)
				{
					dataTable.Columns["SPRNo"].ColumnName = "SPR No";
				}
				if (chkFields.Items[9].Selected)
				{
					dataTable.Columns["SPRDate"].ColumnName = "SPR Date";
				}
				if (chkFields.Items[10].Selected)
				{
					dataTable.Columns["SPRQty"].ColumnName = "SPR Qty";
				}
				if (chkFields.Items[11].Selected)
				{
					dataTable.Columns["PONO"].ColumnName = "PO NO";
				}
				if (chkFields.Items[12].Selected)
				{
					dataTable.Columns["Date"].ColumnName = "PO Date";
				}
				if (chkFields.Items[13].Selected)
				{
					dataTable.Columns["WONo"].ColumnName = "WO No";
				}
				if (chkFields.Items[14].Selected)
				{
					dataTable.Columns["Qty"].ColumnName = "PO Qty";
				}
				if (chkFields.Items[17].Selected)
				{
					dataTable.Columns["SupplierName"].ColumnName = "Supplier Name";
				}
				if (chkFields.Items[18].Selected)
				{
					dataTable.Columns["DelDate"].ColumnName = "Del. Date";
				}
				if (chkFields.Items[20].Selected)
				{
					dataTable.Columns["AuthorizedBy"].ColumnName = "Authorized By";
				}
				if (chkFields.Items[21].Selected)
				{
					dataTable.Columns["AuthorizeDate"].ColumnName = "Authorized Date";
				}
				if (chkFields.Items[22].Selected)
				{
					dataTable.Columns["AuthorizeTime"].ColumnName = "Authorized Time";
				}
				if (chkFields.Items[23].Selected)
				{
					dataTable.Columns["GINNo"].ColumnName = "GIN No";
				}
				if (chkFields.Items[24].Selected)
				{
					dataTable.Columns["GINDate"].ColumnName = "GIN. Date";
				}
				if (chkFields.Items[25].Selected)
				{
					dataTable.Columns["ChallanNo"].ColumnName = "Challan No";
				}
				if (chkFields.Items[26].Selected)
				{
					dataTable.Columns["ChallanDate"].ColumnName = "Challan Date";
				}
				if (chkFields.Items[27].Selected)
				{
					dataTable.Columns["GateEntryNo"].ColumnName = "Gate Entry No";
				}
				if (chkFields.Items[28].Selected)
				{
					dataTable.Columns["ModeofTransport"].ColumnName = "Mode of Transport";
				}
				if (chkFields.Items[29].Selected)
				{
					dataTable.Columns["VehicleNo"].ColumnName = "Vehicle No";
				}
				if (chkFields.Items[30].Selected)
				{
					dataTable.Columns["ChallanQty"].ColumnName = "Challan Qty";
				}
				if (chkFields.Items[31].Selected)
				{
					dataTable.Columns["GINQty"].ColumnName = "GIN Qty";
				}
				if (chkFields.Items[32].Selected)
				{
					dataTable.Columns["AcHead"].ColumnName = "Ac Head";
				}
				if (chkFields.Items[33].Selected)
				{
					dataTable.Columns["GSNNo"].ColumnName = "GSN No";
				}
				if (chkFields.Items[34].Selected)
				{
					dataTable.Columns["GSNDate"].ColumnName = "GSN Date";
				}
				if (chkFields.Items[35].Selected)
				{
					dataTable.Columns["GSNQty"].ColumnName = "GSN Qty";
				}
			}
			string text = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".xls";
			FileInfo fileInfo = new FileInfo(text);
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			DataGrid dataGrid = new DataGrid();
			dataGrid.DataSource = dataTable;
			dataGrid.DataBind();
			dataGrid.RenderControl(writer);
			string path = text.Substring(0, text.LastIndexOf("\\"));
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			StreamWriter streamWriter = new StreamWriter(text, append: true);
			stringWriter.ToString().Normalize();
			streamWriter.Write(stringWriter.ToString());
			streamWriter.Flush();
			streamWriter.Close();
			WriteAttachment(fileInfo.Name, "application/vnd.ms-excel", stringWriter.ToString());
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	public static void WriteAttachment(string FileName, string FileType, string content)
	{
		try
		{
			HttpResponse response = HttpContext.Current.Response;
			response.ClearHeaders();
			response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
			response.ContentType = FileType;
			response.Write(content);
			response.End();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Reports/Search.aspx");
	}
}

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

public class Module_MaterialManagement_Reports_SearchViewField : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string _connStr = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

	private int flag;

	private string FirstCond = string.Empty;

	private string Supcode = string.Empty;

	private string Itemcode = string.Empty;

	private string ExciseSerTax = string.Empty;

	private string ACHead = string.Empty;

	private int CompId;

	private string WONo = string.Empty;

	private string FromDate = string.Empty;

	private string ToDate = string.Empty;

	private string StrDate = string.Empty;

	private string POCompletePending = string.Empty;

	protected CheckBox checkAll;

	protected Label lblPOPRSPR;

	protected CheckBoxList chkFields;

	protected Panel Panel2;

	protected Label lblSPR;

	protected CheckBoxList chkFields3;

	protected Panel Panel3;

	protected Label lblPR;

	protected CheckBoxList chkFields2;

	protected Panel Panel4;

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
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["No"]))
			{
				switch (Convert.ToInt32(base.Request.QueryString["type"]))
				{
				case 1:
					FirstCond = " And PONo='" + base.Request.QueryString["No"].ToString() + "' ";
					break;
				case 2:
					FirstCond = " And PRNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 3:
					FirstCond = " And SPRNo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 4:
					FirstCond = " And WONo='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 5:
					FirstCond = " And ItemCode='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				case 6:
					FirstCond = " And Code='" + base.Request.QueryString["No"].ToString() + "'";
					break;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["RAd"]))
			{
				flag = Convert.ToInt32(base.Request.QueryString["RAd"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FDate"]) && !string.IsNullOrEmpty(base.Request.QueryString["TDate"]))
			{
				FromDate = fun.FromDate(base.Request.QueryString["FDate"]);
				ToDate = fun.FromDate(base.Request.QueryString["TDate"]);
				if (flag == 1)
				{
					StrDate = " And Date between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 2)
				{
					StrDate = " And Date between '" + FromDate + "' And '" + ToDate + "'";
				}
				if (flag == 3)
				{
					StrDate = " And Date between '" + FromDate + "' And '" + ToDate + "'";
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
			if (!string.IsNullOrEmpty(base.Request.QueryString["EX"]) && Convert.ToInt32(base.Request.QueryString["EX"]) != 1)
			{
				ExciseSerTax = " And ExST='" + base.Request.QueryString["EX"].ToString() + "'";
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
			}
			if (flag == 1)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["Status"]))
				{
					if (base.Request.QueryString["Status"] == "0")
					{
						POCompletePending = " And PONo not in (Select PONo from tblInv_Inward_Master where CompId=" + CompId + ")";
					}
					else if (base.Request.QueryString["Status"] == "1")
					{
						POCompletePending = " And PONo in (Select PONo from tblInv_Inward_Master where CompId=" + CompId + ")";
					}
				}
				lblPOPRSPR.Text = "PO";
				lblPR.Text = "PR";
				lblSPR.Text = "SPR";
				chkFields.Items[45].Attributes.Add("style", "display:none;");
				chkFields.Items[46].Attributes.Add("style", "display:none;");
				chkFields.Items[44].Attributes.Add("style", "display:none;");
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Stock Qty";
				chkFields.Items[6].Text = "PO No";
				chkFields.Items[7].Text = "WO NO";
				chkFields.Items[8].Text = "Amd No";
				chkFields.Items[9].Text = "Supplier Name";
				chkFields.Items[13].Text = "Amount";
				chkFields.Items[14].Text = "Del. Date";
				chkFields.Items[17].Text = "Checked By";
				chkFields.Items[18].Text = "Checked Date";
				chkFields.Items[19].Text = "Checked Time";
				chkFields.Items[21].Text = "Approved By";
				chkFields.Items[22].Text = "Approved Date";
				chkFields.Items[23].Text = "Approved Time";
				chkFields.Items[25].Text = "Authorized By";
				chkFields.Items[26].Text = "Authorized Date";
				chkFields.Items[27].Text = "Authorized Time";
				chkFields.Items[29].Text = "Reference Date";
				chkFields.Items[30].Text = "Ref. Desc";
				chkFields.Items[33].Text = "Ship To";
				chkFields.Items[38].Text = "Payment Terms";
				chkFields.Items[39].Text = "Add. Desc";
				chkFields.Items[40].Text = "Excise/Ser.Tax";
				chkFields.Items[43].Text = "Ac Head";
				chkFields2.Items[0].Text = "PR No";
				chkFields2.Items[1].Text = "Date";
				chkFields2.Items[2].Text = "WO No";
				chkFields2.Items[3].Text = "Supplier Name";
				chkFields2.Items[4].Text = "Qty";
				chkFields2.Items[5].Text = "Rate";
				chkFields2.Items[6].Text = "Discount";
				chkFields2.Items[7].Text = "Amount";
				chkFields2.Items[8].Text = "Ac Head";
				chkFields2.Items[9].Text = "Del. Date";
				chkFields2.Items[10].Text = "Remarks";
				chkFields3.Items[0].Text = "SPR No";
				chkFields3.Items[1].Text = "Date";
				chkFields3.Items[2].Text = "WO No";
				chkFields3.Items[3].Text = "Supplier Name";
				chkFields3.Items[4].Text = "Qty";
				chkFields3.Items[5].Text = "Rate";
				chkFields3.Items[6].Text = "Discount";
				chkFields3.Items[7].Text = "Amount";
				chkFields3.Items[8].Text = "Ac Head";
				chkFields3.Items[9].Text = "Del. Date";
				chkFields3.Items[10].Text = "Remarks";
				chkFields3.Items[11].Text = "BG";
				chkFields3.Items[12].Text = "Checked";
				chkFields3.Items[13].Text = "Checked By";
				chkFields3.Items[14].Text = "Checked Date";
				chkFields3.Items[15].Text = "Checked Time";
				chkFields3.Items[16].Text = "Approved";
				chkFields3.Items[17].Text = "Approved By";
				chkFields3.Items[18].Text = "Approved Date";
				chkFields3.Items[19].Text = "Approved Time";
				chkFields3.Items[20].Text = "Authorized";
				chkFields3.Items[21].Text = "Authorized By";
				chkFields3.Items[22].Text = "Authorized Date";
				chkFields3.Items[23].Text = "Authorized Time";
			}
			else if (flag == 2)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["Status"]))
				{
					if (base.Request.QueryString["Status"] == "0")
					{
						POCompletePending = " And PRNo  not in (Select tblMM_PO_Details.PRNo from tblMM_PO_Details inner join tblMM_PO_Master  on tblMM_PO_Details.MId=tblMM_PO_Master.Id  And tblMM_PO_Details.PRNo is not null And  tblMM_PO_Master.CompId=" + CompId + ")";
					}
					else if (base.Request.QueryString["Status"] == "1")
					{
						POCompletePending = " And PRNo in (Select tblMM_PO_Details.PRNo from tblMM_PO_Details inner join tblMM_PO_Master  on tblMM_PO_Details.MId=tblMM_PO_Master.Id  And tblMM_PO_Details.PRNo is not null And  tblMM_PO_Master.CompId=" + CompId + ")";
					}
				}
				lblPOPRSPR.Text = "PR";
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Stock Qty";
				chkFields.Items[6].Text = "WO NO";
				chkFields.Items[7].Text = "PR No";
				chkFields.Items[8].Text = "PLN No";
				chkFields.Items[9].Text = "Supplier Name";
				chkFields.Items[13].Text = "Amount";
				chkFields.Items[14].Text = "Ac Head";
				chkFields.Items[15].Text = "Del. Date";
				chkFields.Items[17].Attributes.Add("style", "display:none;");
				Panel3.Visible = false;
				Panel4.Visible = false;
			}
			else
			{
				if (flag != 3)
				{
					return;
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["Status"]))
				{
					if (base.Request.QueryString["Status"] == "0")
					{
						POCompletePending = " And SPRNo  not in (Select tblMM_PO_Details.SPRNo from tblMM_PO_Details inner join tblMM_PO_Master  on tblMM_PO_Details.MId=tblMM_PO_Master.Id  And tblMM_PO_Details.SPRNo is not null And  tblMM_PO_Master.CompId=" + CompId + ")";
					}
					else if (base.Request.QueryString["Status"] == "1")
					{
						POCompletePending = " And SPRNo in (Select tblMM_PO_Details.SPRNo from tblMM_PO_Details inner join tblMM_PO_Master  on tblMM_PO_Details.MId=tblMM_PO_Master.Id  And tblMM_PO_Details.SPRNo is not null And  tblMM_PO_Master.CompId=" + CompId + ")";
					}
				}
				lblPOPRSPR.Text = "SPR";
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Stock Qty";
				chkFields.Items[6].Text = "SPR No";
				chkFields.Items[7].Text = "WO NO";
				chkFields.Items[8].Text = "Supplier Name";
				chkFields.Items[12].Text = "Amount";
				chkFields.Items[13].Text = "Ac Head";
				chkFields.Items[14].Text = "Del. Date";
				chkFields.Items[18].Text = "Checked By";
				chkFields.Items[19].Text = "Checked Date";
				chkFields.Items[20].Text = "Checked Time";
				chkFields.Items[22].Text = "Approved By";
				chkFields.Items[23].Text = "Approved Date";
				chkFields.Items[24].Text = "Approved Time";
				chkFields.Items[26].Text = "Authorized By";
				chkFields.Items[27].Text = "Authorized Date";
				chkFields.Items[28].Text = "Authorized Time";
				chkFields.Items[29].Attributes.Add("style", "display:none;");
				Panel3.Visible = false;
				Panel4.Visible = false;
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
			if (flag == 1)
			{
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
				foreach (ListItem item2 in chkFields2.Items)
				{
					if (item2.Selected)
					{
						BoundField boundField2 = new BoundField();
						boundField2.DataField = item2.Value;
						if (item2.Text == "Date")
						{
							boundField2.HeaderText = "PR Date";
						}
						else if (item2.Text == "WO No")
						{
							boundField2.HeaderText = "PR WONo";
						}
						else if (item2.Text == "Supplier Name")
						{
							boundField2.HeaderText = "PR Supplier Name";
						}
						else if (item2.Text == "Qty")
						{
							boundField2.HeaderText = "PR Qty";
						}
						else if (item2.Text == "Rate")
						{
							boundField2.HeaderText = "PR Rate";
						}
						else if (item2.Text == "Discount")
						{
							boundField2.HeaderText = "PR Discount";
						}
						else if (item2.Text == "Ac Head")
						{
							boundField2.HeaderText = "PR Ac Head";
						}
						else if (item2.Text == "Del. Date")
						{
							boundField2.HeaderText = "PR Del. Date";
						}
						else if (item2.Text == "Remarks")
						{
							boundField2.HeaderText = "PR Remarks";
						}
						else
						{
							boundField2.HeaderText = item2.Text;
						}
						GridView1.Columns.Add(boundField2);
						num++;
					}
				}
				foreach (ListItem item3 in chkFields3.Items)
				{
					if (item3.Selected)
					{
						BoundField boundField3 = new BoundField();
						boundField3.DataField = item3.Value;
						if (item3.Text == "Date")
						{
							boundField3.HeaderText = "SPR Date";
						}
						else if (item3.Text == "WO No")
						{
							boundField3.HeaderText = "SPR WONo";
						}
						else if (item3.Text == "Supplier Name")
						{
							boundField3.HeaderText = "SPR Supplier Name";
						}
						else if (item3.Text == "Qty")
						{
							boundField3.HeaderText = "SPR Qty";
						}
						else if (item3.Text == "Rate")
						{
							boundField3.HeaderText = "SPR Rate";
						}
						else if (item3.Text == "Discount")
						{
							boundField3.HeaderText = "SPR Discount";
						}
						else if (item3.Text == "Amount")
						{
							boundField3.HeaderText = "SPR Amount";
						}
						else if (item3.Text == "Ac Head")
						{
							boundField3.HeaderText = "SPR Ac Head";
						}
						else if (item3.Text == "Del. Date")
						{
							boundField3.HeaderText = "SPR Del. Date";
						}
						else if (item3.Text == "Remarks")
						{
							boundField3.HeaderText = "SPR Remarks";
						}
						else if (item3.Text == "BG")
						{
							boundField3.HeaderText = "SPR BG";
						}
						else if (item3.Text == "Checked")
						{
							boundField3.HeaderText = "SPR Checked";
						}
						else if (item3.Text == "Checked By")
						{
							boundField3.HeaderText = "SPR Checked By";
						}
						else if (item3.Text == "Checked Date")
						{
							boundField3.HeaderText = "SPR Checked Date";
						}
						else if (item3.Text == "Checked Time")
						{
							boundField3.HeaderText = "SPR Checked Time";
						}
						else if (item3.Text == "Approved")
						{
							boundField3.HeaderText = "SPR Approved";
						}
						else if (item3.Text == "Approved By")
						{
							boundField3.HeaderText = "SPR Approved By";
						}
						else if (item3.Text == "Approved Date")
						{
							boundField3.HeaderText = "SPR Approved Date";
						}
						else if (item3.Text == "Approved Time")
						{
							boundField3.HeaderText = "SPR Approved Time";
						}
						else if (item3.Text == "Authorized")
						{
							boundField3.HeaderText = "SPR Authorized";
						}
						else if (item3.Text == "Authorized By")
						{
							boundField3.HeaderText = "SPR Authorized By";
						}
						else if (item3.Text == "Authorized Date")
						{
							boundField3.HeaderText = "SPR Authorized Date";
						}
						else if (item3.Text == "Authorized Time")
						{
							boundField3.HeaderText = "SPR Authorized Time";
						}
						else
						{
							boundField3.HeaderText = item3.Text;
						}
						GridView1.Columns.Add(boundField3);
						num++;
					}
				}
			}
			else if (flag == 2)
			{
				foreach (ListItem item4 in chkFields.Items)
				{
					if (item4.Selected)
					{
						BoundField boundField4 = new BoundField();
						boundField4.DataField = item4.Value;
						boundField4.HeaderText = item4.Text;
						GridView1.Columns.Add(boundField4);
						num++;
					}
				}
			}
			else
			{
				foreach (ListItem item5 in chkFields.Items)
				{
					if (item5.Selected)
					{
						BoundField boundField5 = new BoundField();
						boundField5.DataField = item5.Value;
						boundField5.HeaderText = item5.Text;
						GridView1.Columns.Add(boundField5);
						num++;
					}
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
			DataTable dataTable2 = new DataTable();
			DataTable dataTable3 = new DataTable();
			using SqlConnection connection = new SqlConnection(_connStr);
			if (flag != 1)
			{
				using (SqlCommand sqlCommand = new SqlCommand("sp_columns", connection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;
					if (flag == 2)
					{
						sqlCommand.Parameters.AddWithValue("@table_name", "View_PR_Item");
					}
					else if (flag == 3)
					{
						sqlCommand.Parameters.AddWithValue("@table_name", "View_SPR_Item");
					}
					using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					sqlDataAdapter.Fill(dataTable);
				}
				if (dataTable.Rows.Count > 0)
				{
					chkFields.DataSource = dataTable;
					chkFields.DataBind();
				}
				return;
			}
			using (SqlCommand sqlCommand2 = new SqlCommand("sp_columns", connection))
			{
				sqlCommand2.CommandType = CommandType.StoredProcedure;
				sqlCommand2.Parameters.AddWithValue("@table_name", "View_PO_Item");
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				sqlDataAdapter2.Fill(dataTable);
			}
			if (dataTable.Rows.Count > 0)
			{
				chkFields.DataSource = dataTable;
				chkFields.DataBind();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand("sp_columns", connection))
			{
				sqlCommand3.CommandType = CommandType.StoredProcedure;
				sqlCommand3.Parameters.AddWithValue("@table_name", "View_PR_Check");
				using SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				sqlDataAdapter3.Fill(dataTable2);
			}
			if (dataTable2.Rows.Count > 0)
			{
				chkFields2.DataSource = dataTable2;
				chkFields2.DataBind();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand("sp_columns", connection))
			{
				sqlCommand4.CommandType = CommandType.StoredProcedure;
				sqlCommand4.Parameters.AddWithValue("@table_name", "View_SPR_Check");
				using SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				sqlDataAdapter4.Fill(dataTable3);
			}
			if (dataTable2.Rows.Count > 0)
			{
				chkFields3.DataSource = dataTable3;
				chkFields3.DataBind();
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
			using (SqlConnection connection = new SqlConnection(_connStr))
			{
				string cmdText = "";
				if (flag == 2)
				{
					string text = string.Empty;
					if (chkFields.Items[0].Selected)
					{
						text = "ROW_NUMBER() OVER (ORDER BY ItemCode) AS SrNo";
					}
					if (chkFields.Items[1].Selected)
					{
						text += ",ItemCode";
					}
					if (chkFields.Items[2].Selected)
					{
						text += ",Description";
					}
					if (chkFields.Items[3].Selected)
					{
						text += ",UOM";
					}
					if (chkFields.Items[4].Selected)
					{
						text += ",StockQty";
					}
					if (chkFields.Items[5].Selected)
					{
						text += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(Date, CHARINDEX('-', Date) + 1, 2) + '-' + LEFT(Date, CHARINDEX('-', Date) - 1) + '-' + RIGHT(Date, CHARINDEX('-',REVERSE(Date)) - 1)), 103), '/', '-') AS Date";
					}
					if (chkFields.Items[6].Selected)
					{
						text += ",WONo";
					}
					if (chkFields.Items[7].Selected)
					{
						text += ",PRNo";
					}
					if (chkFields.Items[8].Selected)
					{
						text += ",PLNo";
					}
					if (chkFields.Items[9].Selected)
					{
						text += ",SupplierName";
					}
					if (chkFields.Items[10].Selected)
					{
						text += ",Qty";
					}
					if (chkFields.Items[11].Selected)
					{
						text += ",Rate";
					}
					if (chkFields.Items[12].Selected)
					{
						text += ",Discount";
					}
					if (chkFields.Items[13].Selected)
					{
						text += ",PR_Amount";
					}
					if (chkFields.Items[14].Selected)
					{
						text += ",AcHead";
					}
					if (chkFields.Items[15].Selected)
					{
						text += ",DelDate";
					}
					if (chkFields.Items[16].Selected)
					{
						text += ",Remarks";
					}
					cmdText = "SELECT " + text + " FROM View_PR_Item where CompId='" + CompId + "'" + FirstCond + Supcode + ExciseSerTax + ACHead + WONo + Itemcode + StrDate + POCompletePending;
				}
				else if (flag == 3)
				{
					string text2 = string.Empty;
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
						text2 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(Date, CHARINDEX('-', Date) + 1, 2) + '-' + LEFT(Date, CHARINDEX('-', Date) - 1) + '-' + RIGHT(Date, CHARINDEX('-',REVERSE(Date)) - 1)), 103), '/', '-') AS Date";
					}
					if (chkFields.Items[6].Selected)
					{
						text2 += ",SPRNo";
					}
					if (chkFields.Items[7].Selected)
					{
						text2 += ",WONo";
					}
					if (chkFields.Items[8].Selected)
					{
						text2 += ",SupplierName";
					}
					if (chkFields.Items[9].Selected)
					{
						text2 += ",Qty";
					}
					if (chkFields.Items[10].Selected)
					{
						text2 += ",Rate";
					}
					if (chkFields.Items[11].Selected)
					{
						text2 += ",Discount";
					}
					if (chkFields.Items[12].Selected)
					{
						text2 += ",SPR_Amount";
					}
					if (chkFields.Items[13].Selected)
					{
						text2 += ",AcHead";
					}
					if (chkFields.Items[14].Selected)
					{
						text2 += ",DelDate";
					}
					if (chkFields.Items[15].Selected)
					{
						text2 += ",Remarks";
					}
					if (chkFields.Items[16].Selected)
					{
						text2 += ",BG";
					}
					if (chkFields.Items[17].Selected)
					{
						text2 += ",Checked";
					}
					if (chkFields.Items[18].Selected)
					{
						text2 += ",CheckedBy";
					}
					if (chkFields.Items[19].Selected)
					{
						text2 += ",CheckedDate";
					}
					if (chkFields.Items[20].Selected)
					{
						text2 += ",CheckedTime";
					}
					if (chkFields.Items[21].Selected)
					{
						text2 += ",Approved";
					}
					if (chkFields.Items[22].Selected)
					{
						text2 += ",ApprovedBy";
					}
					if (chkFields.Items[23].Selected)
					{
						text2 += ",ApproveDate";
					}
					if (chkFields.Items[24].Selected)
					{
						text2 += ",ApproveTime";
					}
					if (chkFields.Items[25].Selected)
					{
						text2 += ",Authorized";
					}
					if (chkFields.Items[26].Selected)
					{
						text2 += ",AuthorizedBy";
					}
					if (chkFields.Items[27].Selected)
					{
						text2 += ",AuthorizeDate";
					}
					if (chkFields.Items[28].Selected)
					{
						text2 += ",AuthorizeTime";
					}
					cmdText = "SELECT " + text2 + " FROM View_SPR_Item where CompId='" + CompId + "'" + FirstCond + Supcode + ExciseSerTax + ACHead + WONo + Itemcode + StrDate + POCompletePending;
				}
				else if (flag == 1)
				{
					string text3 = string.Empty;
					if (chkFields.Items[0].Selected)
					{
						text3 = "ROW_NUMBER() OVER (ORDER BY ItemCode) AS SrNo";
					}
					if (chkFields.Items[1].Selected)
					{
						text3 += ",ItemCode";
					}
					if (chkFields.Items[2].Selected)
					{
						text3 += ",Description";
					}
					if (chkFields.Items[3].Selected)
					{
						text3 += ",UOM";
					}
					if (chkFields.Items[4].Selected)
					{
						text3 += ",StockQty";
					}
					if (chkFields.Items[5].Selected)
					{
						text3 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(Date, CHARINDEX('-', Date) + 1, 2) + '-' + LEFT(Date, CHARINDEX('-', Date) - 1) + '-' + RIGHT(Date, CHARINDEX('-',REVERSE(Date)) - 1)), 103), '/', '-') AS Date";
					}
					if (chkFields.Items[6].Selected)
					{
						text3 += ",PONo";
					}
					if (chkFields.Items[7].Selected)
					{
						text3 += ",WONO";
					}
					if (chkFields.Items[8].Selected)
					{
						text3 += ",AmdNo";
					}
					if (chkFields.Items[9].Selected)
					{
						text3 += ",SupplierName";
					}
					if (chkFields.Items[10].Selected)
					{
						text3 += ",Qty";
					}
					if (chkFields.Items[11].Selected)
					{
						text3 += ",Rate";
					}
					if (chkFields.Items[12].Selected)
					{
						text3 += ",Discount";
					}
					if (chkFields.Items[13].Selected)
					{
						text3 += ",PO_Amount";
					}
					if (chkFields.Items[14].Selected)
					{
						text3 += ",DelDate";
					}
					if (chkFields.Items[15].Selected)
					{
						text3 += ",Remarks";
					}
					if (chkFields.Items[16].Selected)
					{
						text3 += ",Checked";
					}
					if (chkFields.Items[17].Selected)
					{
						text3 += ",CheckedBy";
					}
					if (chkFields.Items[18].Selected)
					{
						text3 += ",CheckedDate";
					}
					if (chkFields.Items[19].Selected)
					{
						text3 += ",CheckedTime";
					}
					if (chkFields.Items[20].Selected)
					{
						text3 += ",Approved";
					}
					if (chkFields.Items[21].Selected)
					{
						text3 += ",ApprovedBy";
					}
					if (chkFields.Items[22].Selected)
					{
						text3 += ",ApproveDate";
					}
					if (chkFields.Items[23].Selected)
					{
						text3 += ",ApproveTime";
					}
					if (chkFields.Items[24].Selected)
					{
						text3 += ",Authorized";
					}
					if (chkFields.Items[25].Selected)
					{
						text3 += ",AuthorizedBy";
					}
					if (chkFields.Items[26].Selected)
					{
						text3 += ",AuthorizeDate";
					}
					if (chkFields.Items[27].Selected)
					{
						text3 += ",AuthorizeTime";
					}
					if (chkFields.Items[28].Selected)
					{
						text3 += ",Reference";
					}
					if (chkFields.Items[29].Selected)
					{
						text3 += ",ReferenceDate";
					}
					if (chkFields.Items[30].Selected)
					{
						text3 += ",RefDesc";
					}
					if (chkFields.Items[31].Selected)
					{
						text3 += ",MOD";
					}
					if (chkFields.Items[32].Selected)
					{
						text3 += ",Inspection";
					}
					if (chkFields.Items[33].Selected)
					{
						text3 += ",ShipTo";
					}
					if (chkFields.Items[34].Selected)
					{
						text3 += ",Warrenty";
					}
					if (chkFields.Items[35].Selected)
					{
						text3 += ",Freight";
					}
					if (chkFields.Items[36].Selected)
					{
						text3 += ",Octri";
					}
					if (chkFields.Items[37].Selected)
					{
						text3 += ",Insurance";
					}
					if (chkFields.Items[38].Selected)
					{
						text3 += ",PaymentTerms";
					}
					if (chkFields.Items[39].Selected)
					{
						text3 += ",AddDesc";
					}
					if (chkFields.Items[40].Selected)
					{
						text3 += ",ExciseSerTax";
					}
					if (chkFields.Items[41].Selected)
					{
						text3 += ",VAT";
					}
					if (chkFields.Items[42].Selected)
					{
						text3 += ",PF";
					}
					if (chkFields.Items[43].Selected)
					{
						text3 += ",ACHead";
					}
					if (chkFields3.Items[0].Selected)
					{
						text3 += ",SPRNo";
					}
					if (chkFields3.Items[1].Selected)
					{
						text3 += ",SPRDate";
					}
					if (chkFields3.Items[2].Selected)
					{
						text3 += ",SPRWO";
					}
					if (chkFields3.Items[3].Selected)
					{
						text3 += ",SPRSupplier";
					}
					if (chkFields3.Items[4].Selected)
					{
						text3 += ",SPRQty";
					}
					if (chkFields3.Items[5].Selected)
					{
						text3 += ",SPRRate";
					}
					if (chkFields3.Items[6].Selected)
					{
						text3 += ",SPRDiscount";
					}
					if (chkFields3.Items[7].Selected)
					{
						text3 += ",SPRAmount";
					}
					if (chkFields3.Items[8].Selected)
					{
						text3 += ",SPRACHead";
					}
					if (chkFields3.Items[9].Selected)
					{
						text3 += ",SPRDelDate";
					}
					if (chkFields3.Items[10].Selected)
					{
						text3 += ",SPRRemarks";
					}
					if (chkFields3.Items[11].Selected)
					{
						text3 += ",SPRBGGroup";
					}
					if (chkFields3.Items[12].Selected)
					{
						text3 += ",SPRChecked";
					}
					if (chkFields3.Items[13].Selected)
					{
						text3 += ",SPRCheckedBy";
					}
					if (chkFields3.Items[14].Selected)
					{
						text3 += ",SPRCheckDate";
					}
					if (chkFields3.Items[15].Selected)
					{
						text3 += ",SPRCheckTime";
					}
					if (chkFields3.Items[16].Selected)
					{
						text3 += ",SPRApproved";
					}
					if (chkFields3.Items[17].Selected)
					{
						text3 += ",SPRApprovedBy";
					}
					if (chkFields3.Items[18].Selected)
					{
						text3 += ",SPRApproveDate";
					}
					if (chkFields3.Items[19].Selected)
					{
						text3 += ",SPRApproveTime";
					}
					if (chkFields3.Items[20].Selected)
					{
						text3 += ",SPRAuthorized";
					}
					if (chkFields3.Items[21].Selected)
					{
						text3 += ",SPRAuthorizedBy";
					}
					if (chkFields3.Items[22].Selected)
					{
						text3 += ",SPRAuthorizeDate";
					}
					if (chkFields3.Items[23].Selected)
					{
						text3 += ",SPRAuthorizeTime";
					}
					if (chkFields2.Items[0].Selected)
					{
						text3 += ",PRNo";
					}
					if (chkFields2.Items[1].Selected)
					{
						text3 += ",PRDate";
					}
					if (chkFields2.Items[2].Selected)
					{
						text3 += ",PRWO";
					}
					if (chkFields2.Items[3].Selected)
					{
						text3 += ",PRSupplier";
					}
					if (chkFields2.Items[4].Selected)
					{
						text3 += ",PRQty";
					}
					if (chkFields2.Items[5].Selected)
					{
						text3 += ",PRRate";
					}
					if (chkFields2.Items[6].Selected)
					{
						text3 += ",PRDiscount";
					}
					if (chkFields2.Items[7].Selected)
					{
						text3 += ",PRAmount";
					}
					if (chkFields2.Items[8].Selected)
					{
						text3 += ",PRACHead";
					}
					if (chkFields2.Items[9].Selected)
					{
						text3 += ",PRDelDate";
					}
					if (chkFields2.Items[10].Selected)
					{
						text3 += ",PRRemarks";
					}
					cmdText = "SELECT " + text3 + " FROM View_PO_PR_SPR_Item where CompId='" + CompId + "'" + FirstCond + Supcode + ExciseSerTax + ACHead + WONo + Itemcode + StrDate + POCompletePending;
				}
				using SqlCommand selectCommand = new SqlCommand(cmdText, connection);
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
			if (flag == 1)
			{
				if (checkAll.Checked)
				{
					foreach (ListItem item in chkFields.Items)
					{
						if (item.Value != "CompId" && item.Value != "ExST" && item.Value != "Code")
						{
							item.Selected = true;
						}
					}
					foreach (ListItem item2 in chkFields2.Items)
					{
						item2.Selected = true;
					}
					{
						foreach (ListItem item3 in chkFields3.Items)
						{
							item3.Selected = true;
						}
						return;
					}
				}
				foreach (ListItem item4 in chkFields.Items)
				{
					item4.Selected = false;
				}
				foreach (ListItem item5 in chkFields2.Items)
				{
					item5.Selected = false;
				}
				{
					foreach (ListItem item6 in chkFields3.Items)
					{
						item6.Selected = false;
					}
					return;
				}
			}
			if (checkAll.Checked)
			{
				foreach (ListItem item7 in chkFields.Items)
				{
					if (item7.Value != "CompId")
					{
						item7.Selected = true;
					}
				}
				return;
			}
			foreach (ListItem item8 in chkFields.Items)
			{
				item8.Selected = false;
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
		base.Response.Redirect("~/Module/MaterialManagement/Reports/Search.aspx");
	}
}

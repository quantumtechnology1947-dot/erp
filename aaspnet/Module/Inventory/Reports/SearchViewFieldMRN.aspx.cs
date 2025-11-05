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

public class Module_Inventory_Reports_SearchViewFieldMRN : Page, IRequiresSessionState
{
	protected CheckBox checkAll;

	protected Label lblMRN;

	protected CheckBoxList chkFields;

	protected Panel Panel2;

	protected Label lblMRQN;

	protected CheckBoxList chkFields3;

	protected Panel Panel3;

	protected Button btnSub;

	protected Button btnExport;

	protected Button btnCancel;

	protected GridView GridView1;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	private string _connStr = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

	private int flag;

	private int CompId;

	private string FirstCond = string.Empty;

	private string EmpId = string.Empty;

	private string Itemcode = string.Empty;

	private string BGGroup = string.Empty;

	private string WONo = string.Empty;

	private string FromDate = string.Empty;

	private string ToDate = string.Empty;

	private string StrDate = string.Empty;

	private string POCompletePending = string.Empty;

	private int GetPORate;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["MRNType"]) && !string.IsNullOrEmpty(base.Request.QueryString["MRNno"]))
			{
				switch (Convert.ToInt32(base.Request.QueryString["MRNType"]))
				{
				case 1:
					FirstCond = " And MRNNo='" + base.Request.QueryString["MRNno"].ToString() + "' ";
					break;
				case 2:
					FirstCond = " And MRQNNo='" + base.Request.QueryString["MRNno"].ToString() + "'";
					break;
				case 3:
					FirstCond = " ";
					break;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["ICode"]))
			{
				Itemcode = " And ItemCode='" + base.Request.QueryString["ICode"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["MRNType"]))
			{
				flag = Convert.ToInt32(base.Request.QueryString["MRNType"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FDateMRN"]) && !string.IsNullOrEmpty(base.Request.QueryString["TDateMRN"]))
			{
				FromDate = fun.FromDate(base.Request.QueryString["FDateMRN"]);
				ToDate = fun.FromDate(base.Request.QueryString["TDateMRN"]);
				switch (Convert.ToInt32(base.Request.QueryString["Rbtn"]))
				{
				case 1:
					StrDate = " And MRNDate between '" + FromDate + "' And '" + ToDate + "'";
					break;
				case 2:
					StrDate = " And MRQNDate between '" + FromDate + "' And '" + ToDate + "'";
					break;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["EmpidMRN"]))
			{
				EmpId = " And EmpId='" + base.Request.QueryString["EmpidMRN"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["BGGroupMRN"]))
			{
				BGGroup = " And BGId='" + base.Request.QueryString["BGGroupMRN"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONoMRN"]))
			{
				WONo = " And WONo='" + base.Request.QueryString["WONoMRN"].ToString() + "'";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["GetPORate"]))
			{
				GetPORate = Convert.ToInt32(base.Request.QueryString["GetPORate"]);
			}
			if (!base.IsPostBack)
			{
				BindTableColumns();
			}
			if (flag == 1 || flag == 3)
			{
				lblMRN.Text = "MRN";
				lblMRQN.Text = "MRQN";
				chkFields.Items[0].Selected = true;
				chkFields.Items[1].Selected = true;
				chkFields.Items[2].Selected = true;
				chkFields.Items[3].Selected = true;
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Date";
				chkFields.Items[5].Text = "MRN No";
				chkFields.Items[6].Text = "BG Group";
				chkFields.Items[7].Text = "WO No";
				chkFields.Items[8].Text = "Ret Qty";
				chkFields.Items[9].Text = "Remarks";
				chkFields.Items[10].Text = "Gen. By";
				chkFields.Items[11].Text = "Rate";
				chkFields3.Items[0].Text = "Date";
				chkFields3.Items[1].Text = "MRQN No";
				chkFields3.Items[2].Text = "Acept Qty";
				chkFields3.Items[3].Text = "Rej Qty";
				chkFields3.Items[4].Text = "Gen. By";
				chkFields3.Items[5].Text = "Rate";
			}
			if (flag == 2)
			{
				lblMRN.Text = "MRQN";
				lblMRQN.Text = "MRN";
				chkFields.Items[0].Selected = true;
				chkFields.Items[1].Selected = true;
				chkFields.Items[2].Selected = true;
				chkFields.Items[3].Selected = true;
				chkFields.Items[0].Text = "Sr No";
				chkFields.Items[1].Text = "Item Code";
				chkFields.Items[4].Text = "Date";
				chkFields.Items[5].Text = "MRQN No";
				chkFields.Items[6].Text = "Acept Qty";
				chkFields.Items[7].Text = "Rej Qty";
				chkFields.Items[8].Text = "Generated By";
				chkFields.Items[9].Text = "Rate";
				chkFields3.Items[0].Text = "Date";
				chkFields3.Items[1].Text = "MRN No";
				chkFields3.Items[2].Text = "BG Group";
				chkFields3.Items[3].Text = "WO No";
				chkFields3.Items[4].Text = "Ret Qty";
				chkFields3.Items[6].Text = "Remarks";
				chkFields3.Items[5].Text = "Rate";
				chkFields3.Items[7].Text = "Generated By";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ShowGrid(object sender, EventArgs e)
	{
		int num = 0;
		if (flag == 1 || flag == 3)
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
			foreach (ListItem item2 in chkFields3.Items)
			{
				if (item2.Selected)
				{
					BoundField boundField2 = new BoundField();
					boundField2.DataField = item2.Value;
					boundField2.HeaderText = item2.Text;
					GridView1.Columns.Add(boundField2);
					num++;
				}
			}
			if (num > 0)
			{
				GetData();
			}
		}
		if (flag != 2)
		{
			return;
		}
		foreach (ListItem item3 in chkFields.Items)
		{
			if (item3.Selected)
			{
				BoundField boundField3 = new BoundField();
				boundField3.DataField = item3.Value;
				boundField3.HeaderText = item3.Text;
				GridView1.Columns.Add(boundField3);
				num++;
			}
		}
		foreach (ListItem item4 in chkFields3.Items)
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
		if (num > 0)
		{
			GetData();
		}
	}

	private void BindTableColumns()
	{
		try
		{
			DataTable dataTable = new DataTable();
			DataTable dataTable2 = new DataTable();
			using SqlConnection connection = new SqlConnection(_connStr);
			if (flag == 1 || flag == 3)
			{
				using (SqlCommand sqlCommand = new SqlCommand("sp_columns", connection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@table_name", "View_MRN_Item");
					using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					sqlDataAdapter.Fill(dataTable);
				}
				if (dataTable.Rows.Count > 0)
				{
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					dataTable.Rows.RemoveAt(11);
					if (GetPORate == 1)
					{
						dataTable.Rows.RemoveAt(12);
						dataTable.Rows.RemoveAt(12);
						dataTable.Rows.RemoveAt(12);
					}
					else if (GetPORate == 2)
					{
						dataTable.Rows.RemoveAt(11);
						dataTable.Rows.RemoveAt(12);
						dataTable.Rows.RemoveAt(12);
					}
					else if (GetPORate == 3)
					{
						dataTable.Rows.RemoveAt(11);
						dataTable.Rows.RemoveAt(11);
						dataTable.Rows.RemoveAt(12);
					}
					else if (GetPORate == 4)
					{
						dataTable.Rows.RemoveAt(11);
						dataTable.Rows.RemoveAt(11);
						dataTable.Rows.RemoveAt(11);
					}
					dataTable.AcceptChanges();
					chkFields.DataSource = dataTable;
					chkFields.DataBind();
					chkFields.Items.Add("Amount");
				}
				using (SqlCommand sqlCommand2 = new SqlCommand("sp_columns", connection))
				{
					sqlCommand2.CommandType = CommandType.StoredProcedure;
					sqlCommand2.Parameters.AddWithValue("@table_name", "View_MRN_Item");
					using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					sqlDataAdapter2.Fill(dataTable2);
				}
				if (dataTable2.Rows.Count > 0)
				{
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					dataTable2.Rows.RemoveAt(0);
					if (GetPORate == 1)
					{
						dataTable2.Rows.RemoveAt(6);
						dataTable2.Rows.RemoveAt(6);
						dataTable2.Rows.RemoveAt(6);
					}
					else if (GetPORate == 2)
					{
						dataTable2.Rows.RemoveAt(5);
						dataTable2.Rows.RemoveAt(6);
						dataTable2.Rows.RemoveAt(6);
					}
					else if (GetPORate == 3)
					{
						dataTable2.Rows.RemoveAt(5);
						dataTable2.Rows.RemoveAt(5);
						dataTable2.Rows.RemoveAt(6);
					}
					else if (GetPORate == 4)
					{
						dataTable2.Rows.RemoveAt(5);
						dataTable2.Rows.RemoveAt(5);
						dataTable2.Rows.RemoveAt(5);
					}
					dataTable2.AcceptChanges();
					chkFields3.DataSource = dataTable2;
					chkFields3.DataBind();
					chkFields3.Items.Add("MRQNAmount");
				}
			}
			if (flag != 2)
			{
				return;
			}
			using (SqlCommand sqlCommand3 = new SqlCommand("sp_columns", connection))
			{
				sqlCommand3.CommandType = CommandType.StoredProcedure;
				sqlCommand3.Parameters.AddWithValue("@table_name", "View_MRQN_Item");
				using SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				sqlDataAdapter3.Fill(dataTable);
			}
			if (dataTable.Rows.Count > 0)
			{
				dataTable.Rows.RemoveAt(9);
				dataTable.Rows.RemoveAt(9);
				dataTable.Rows.RemoveAt(9);
				dataTable.Rows.RemoveAt(9);
				dataTable.Rows.RemoveAt(9);
				if (GetPORate == 1)
				{
					dataTable.Rows.RemoveAt(10);
					dataTable.Rows.RemoveAt(10);
					dataTable.Rows.RemoveAt(10);
				}
				else if (GetPORate == 2)
				{
					dataTable.Rows.RemoveAt(9);
					dataTable.Rows.RemoveAt(10);
					dataTable.Rows.RemoveAt(10);
				}
				else if (GetPORate == 3)
				{
					dataTable.Rows.RemoveAt(9);
					dataTable.Rows.RemoveAt(9);
					dataTable.Rows.RemoveAt(10);
				}
				else if (GetPORate == 4)
				{
					dataTable.Rows.RemoveAt(9);
					dataTable.Rows.RemoveAt(9);
					dataTable.Rows.RemoveAt(9);
				}
				dataTable.Rows.RemoveAt(10);
				dataTable.Rows.RemoveAt(10);
				dataTable.Rows.RemoveAt(10);
				dataTable.Rows.RemoveAt(10);
				dataTable.Rows.RemoveAt(10);
				dataTable.AcceptChanges();
				chkFields.DataSource = dataTable;
				chkFields.DataBind();
				chkFields.Items.Add("Amount");
			}
			using (SqlCommand sqlCommand4 = new SqlCommand("sp_columns", connection))
			{
				sqlCommand4.CommandType = CommandType.StoredProcedure;
				sqlCommand4.Parameters.AddWithValue("@table_name", "View_MRQN_Item");
				using SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				sqlDataAdapter4.Fill(dataTable2);
			}
			if (dataTable2.Rows.Count > 0)
			{
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				dataTable2.Rows.RemoveAt(0);
				if (GetPORate == 1)
				{
					dataTable2.Rows.RemoveAt(6);
					dataTable2.Rows.RemoveAt(6);
					dataTable2.Rows.RemoveAt(6);
				}
				else if (GetPORate == 2)
				{
					dataTable2.Rows.RemoveAt(5);
					dataTable2.Rows.RemoveAt(6);
					dataTable2.Rows.RemoveAt(6);
				}
				else if (GetPORate == 3)
				{
					dataTable2.Rows.RemoveAt(5);
					dataTable2.Rows.RemoveAt(5);
					dataTable2.Rows.RemoveAt(6);
				}
				else if (GetPORate == 4)
				{
					dataTable2.Rows.RemoveAt(5);
					dataTable2.Rows.RemoveAt(5);
					dataTable2.Rows.RemoveAt(5);
				}
				dataTable2.Rows.RemoveAt(8);
				dataTable2.Rows.RemoveAt(8);
				dataTable2.Rows.RemoveAt(8);
				dataTable2.AcceptChanges();
				chkFields3.DataSource = dataTable2;
				chkFields3.DataBind();
				chkFields3.Items.Add("MRNAmount");
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
				if (flag == 1 || flag == 3)
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
						text += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(MRNDate, CHARINDEX('-', MRNDate) + 1, 2) + '-' + LEFT(MRNDate, CHARINDEX('-', MRNDate) - 1) + '-' + RIGHT(MRNDate, CHARINDEX('-',REVERSE(MRNDate)) - 1)), 103), '/', '-') AS MRNDate";
					}
					if (chkFields.Items[5].Selected)
					{
						text += ",MRNNo";
					}
					if (chkFields.Items[6].Selected)
					{
						text += ",BGGroup";
					}
					if (chkFields.Items[7].Selected)
					{
						text += ",WONo";
					}
					if (chkFields.Items[8].Selected)
					{
						text += ",RetQty";
					}
					if (chkFields.Items[11].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text += ",rate_MAX";
							break;
						case 2:
							text += ",rate_MIN";
							break;
						case 3:
							text += ",rate_avg";
							break;
						case 4:
							text += ",rate_Actual";
							break;
						}
					}
					if (chkFields.Items[12].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text += ",rate_MAX*RetQty As Amount";
							break;
						case 2:
							text += ",rate_MIN*RetQty As Amount";
							break;
						case 3:
							text += ",rate_avg*RetQty As Amount";
							break;
						case 4:
							text += ",rate_Actual*RetQty As Amount";
							break;
						}
					}
					if (chkFields.Items[9].Selected)
					{
						text += ",Remarks";
					}
					if (chkFields.Items[10].Selected)
					{
						text += ",GenBy";
					}
					if (chkFields3.Items[0].Selected)
					{
						text += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(MRQNDate, CHARINDEX('-', MRQNDate) + 1, 2) + '-' + LEFT(MRQNDate, CHARINDEX('-', MRQNDate) - 1) + '-' + RIGHT(MRQNDate, CHARINDEX('-',REVERSE(MRQNDate)) - 1)), 103), '/', '-') AS MRQNDate";
					}
					if (chkFields3.Items[1].Selected)
					{
						text += ",MRQNNo";
					}
					if (chkFields3.Items[2].Selected)
					{
						text += ",AcceptedQty";
					}
					if (chkFields3.Items[5].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text += ",rate_MAX As MRQNRate";
							break;
						case 2:
							text += ",rate_MIN As MRQNRate";
							break;
						case 3:
							text += ",rate_avg As MRQNRate";
							break;
						case 4:
							text += ",rate_Actual As MRQNRate";
							break;
						}
					}
					if (chkFields3.Items[6].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text += ",rate_MAX*AcceptedQty As MRQNAmount";
							break;
						case 2:
							text += ",rate_MIN*AcceptedQty As MRQNAmount";
							break;
						case 3:
							text += ",rate_avg*AcceptedQty As MRQNAmount";
							break;
						case 4:
							text += ",rate_Actual*AcceptedQty As MRQNAmount";
							break;
						}
					}
					if (chkFields3.Items[3].Selected)
					{
						text += ",RejectedQty";
					}
					if (chkFields3.Items[4].Selected)
					{
						text += ",GenBy2";
					}
					cmdText = "SELECT " + text + " FROM View_MRN_Item where CompId='" + CompId + "'" + FirstCond + Itemcode + EmpId + WONo + BGGroup + StrDate;
				}
				if (flag == 2)
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
						text2 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(MRQNDate, CHARINDEX('-', MRQNDate) + 1, 2) + '-' + LEFT(MRQNDate, CHARINDEX('-', MRQNDate) - 1) + '-' + RIGHT(MRQNDate, CHARINDEX('-',REVERSE(MRQNDate)) - 1)), 103), '/', '-') AS MRQNDate";
					}
					if (chkFields.Items[5].Selected)
					{
						text2 += ",MRQNNo";
					}
					if (chkFields.Items[6].Selected)
					{
						text2 += ",AcceptedQty";
					}
					if (chkFields.Items[7].Selected)
					{
						text2 += ",RejectedQty";
					}
					if (chkFields.Items[8].Selected)
					{
						text2 += ",EmpName";
					}
					if (chkFields.Items[9].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text2 += ",rate_MAX";
							break;
						case 2:
							text2 += ",rate_MIN";
							break;
						case 3:
							text2 += ",rate_avg";
							break;
						case 4:
							text2 += ",rate_Actual";
							break;
						}
					}
					if (chkFields.Items[10].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text2 += ",rate_MAX*AcceptedQty As Amount";
							break;
						case 2:
							text2 += ",rate_MIN*AcceptedQty As Amount";
							break;
						case 3:
							text2 += ",rate_avg*AcceptedQty As Amount";
							break;
						case 4:
							text2 += ",rate_Actual*AcceptedQty As Amount";
							break;
						}
					}
					if (chkFields3.Items[0].Selected)
					{
						text2 += ",REPLACE(CONVERT(varchar,CONVERT(datetime, SUBSTRING(MRNDate, CHARINDEX('-', MRNDate) + 1, 2) + '-' + LEFT(MRNDate, CHARINDEX('-', MRNDate) - 1) + '-' + RIGHT(MRNDate, CHARINDEX('-',REVERSE(MRNDate)) - 1)), 103), '/', '-') AS MRNDate";
					}
					if (chkFields3.Items[1].Selected)
					{
						text2 += ",MRNNo";
					}
					if (chkFields3.Items[2].Selected)
					{
						text2 += ",BGGroup";
					}
					if (chkFields3.Items[3].Selected)
					{
						text2 += ",WONo";
					}
					if (chkFields3.Items[4].Selected)
					{
						text2 += ",RetQty";
					}
					if (chkFields3.Items[6].Selected)
					{
						text2 += ",Remarks";
					}
					if (chkFields3.Items[7].Selected)
					{
						text2 += ",EmpName2";
					}
					if (chkFields3.Items[5].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text2 += ",rate_MAX";
							break;
						case 2:
							text2 += ",rate_MIN";
							break;
						case 3:
							text2 += ",rate_avg";
							break;
						case 4:
							text2 += ",rate_Actual";
							break;
						}
					}
					if (chkFields3.Items[8].Selected)
					{
						switch (GetPORate)
						{
						case 1:
							text2 += ",rate_MAX*RetQty As MRNAmount";
							break;
						case 2:
							text2 += ",rate_MIN*RetQty As MRNAmount";
							break;
						case 3:
							text2 += ",rate_avg*RetQty As MRNAmount";
							break;
						case 4:
							text2 += ",rate_Actual*RetQty As MRNAmount";
							break;
						}
					}
					cmdText = "SELECT " + text2 + " FROM View_MRQN_Item where CompId='" + CompId + "'" + FirstCond + Itemcode + EmpId + WONo + BGGroup + StrDate;
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
			if (flag == 1 || flag == 3)
			{
				if (checkAll.Checked)
				{
					foreach (ListItem item in chkFields.Items)
					{
						if (item.Value != "CompId" && item.Value != "BGId" && item.Value != "EmpId" && item.Value != "MRQNDate" && item.Value != "MRQNNo" && item.Value != "MRQNQty" && item.Value != "AcceptedQty" && item.Value != "RejectedQty" && item.Value != "GenBy2")
						{
							item.Selected = true;
						}
					}
					foreach (ListItem item2 in chkFields3.Items)
					{
						if (item2.Value != "CompId" && item2.Value != "BGId" && item2.Value != "EmpId")
						{
							item2.Selected = true;
						}
					}
				}
				else
				{
					foreach (ListItem item3 in chkFields.Items)
					{
						item3.Selected = false;
					}
					foreach (ListItem item4 in chkFields3.Items)
					{
						item4.Selected = false;
					}
				}
			}
			if (flag != 2)
			{
				return;
			}
			if (checkAll.Checked)
			{
				foreach (ListItem item5 in chkFields.Items)
				{
					if (item5.Value != "CompId" && item5.Value != "BGId" && item5.Value != "EmpId" && item5.Value != "MRNDate" && item5.Value != "MRNNo" && item5.Value != "BGGroup" && item5.Value != "WONo" && item5.Value != "RetQty" && item5.Value != "Remarks" && item5.Value != "EmpName2")
					{
						item5.Selected = true;
					}
				}
				{
					foreach (ListItem item6 in chkFields3.Items)
					{
						if (item6.Value != "CompId" && item6.Value != "BGId" && item6.Value != "EmpId")
						{
							item6.Selected = true;
						}
					}
					return;
				}
			}
			foreach (ListItem item7 in chkFields.Items)
			{
				item7.Selected = false;
			}
			foreach (ListItem item8 in chkFields3.Items)
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
			if (flag == 1 || flag == 3)
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
					dataTable.Columns["MRNDate"].ColumnName = "Date";
				}
				if (chkFields.Items[5].Selected)
				{
					dataTable.Columns["MRNNo"].ColumnName = "MRN No";
				}
				if (chkFields.Items[6].Selected)
				{
					dataTable.Columns["BGGroup"].ColumnName = "BG Group";
				}
				if (chkFields.Items[8].Selected)
				{
					dataTable.Columns["RetQty"].ColumnName = "Return Qty";
				}
				if (chkFields.Items[10].Selected)
				{
					dataTable.Columns["GenBy"].ColumnName = "Generated By";
				}
				if (chkFields.Items[11].Selected)
				{
					switch (GetPORate)
					{
					case 1:
						dataTable.Columns["rate_MAX"].ColumnName = "MRN Rate";
						break;
					case 2:
						dataTable.Columns["rate_MIN"].ColumnName = "MRN Rate";
						break;
					case 3:
						dataTable.Columns["rate_avg"].ColumnName = "MRN Rate";
						break;
					case 4:
						dataTable.Columns["rate_Actual"].ColumnName = "MRN Rate";
						break;
					}
					dataTable.Columns["Amount"].ColumnName = "MRN Amount";
				}
				if (chkFields3.Items[0].Selected)
				{
					dataTable.Columns["MRQNDate"].ColumnName = "MRQN Date";
				}
				if (chkFields3.Items[1].Selected)
				{
					dataTable.Columns["MRQNNo"].ColumnName = "MRQN No";
				}
				if (chkFields3.Items[2].Selected)
				{
					dataTable.Columns["AcceptedQty"].ColumnName = "Accepted Qty";
				}
				if (chkFields3.Items[3].Selected)
				{
					dataTable.Columns["RejectedQty"].ColumnName = "Rejected Qty";
				}
				if (chkFields3.Items[4].Selected)
				{
					dataTable.Columns["GenBy2"].ColumnName = "MRQN Generated By";
				}
				if (chkFields3.Items[5].Selected)
				{
					switch (GetPORate)
					{
					case 1:
						dataTable.Columns["MRQNRate"].ColumnName = "MRQN Rate";
						break;
					case 2:
						dataTable.Columns["MRQNRate"].ColumnName = "MRQN Rate";
						break;
					case 3:
						dataTable.Columns["MRQNRate"].ColumnName = "MRQN Rate";
						break;
					case 4:
						dataTable.Columns["MRQNRate"].ColumnName = "MRQN Rate";
						break;
					}
				}
				if (chkFields3.Items[6].Selected)
				{
					dataTable.Columns["MRQNAmount"].ColumnName = "MRQN Amount";
				}
			}
			else if (flag == 2)
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
					dataTable.Columns["MRQNDate"].ColumnName = "Date";
				}
				if (chkFields.Items[5].Selected)
				{
					dataTable.Columns["MRQNNo"].ColumnName = "MRQN No";
				}
				if (chkFields.Items[6].Selected)
				{
					dataTable.Columns["AcceptedQty"].ColumnName = "Accepted Qty";
				}
				if (chkFields.Items[7].Selected)
				{
					dataTable.Columns["RejectedQty"].ColumnName = "Rejected Qty";
				}
				if (chkFields.Items[8].Selected)
				{
					dataTable.Columns["EmpName"].ColumnName = "Generated By";
				}
				if (chkFields.Items[9].Selected)
				{
					switch (GetPORate)
					{
					case 1:
						dataTable.Columns["rate_MAX"].ColumnName = "Rate";
						break;
					case 2:
						dataTable.Columns["rate_MIN"].ColumnName = "Rate";
						break;
					case 3:
						dataTable.Columns["rate_avg"].ColumnName = "Rate";
						break;
					case 4:
						dataTable.Columns["rate_Actual"].ColumnName = "Rate";
						break;
					}
				}
				if (chkFields3.Items[0].Selected)
				{
					dataTable.Columns["MRNDate"].ColumnName = "MRN Date";
				}
				if (chkFields3.Items[1].Selected)
				{
					dataTable.Columns["MRNNo"].ColumnName = "MRN No";
				}
				if (chkFields3.Items[2].Selected)
				{
					dataTable.Columns["BGGroup"].ColumnName = "BG Group";
				}
				if (chkFields3.Items[3].Selected)
				{
					dataTable.Columns["WONo"].ColumnName = "WO No";
				}
				if (chkFields3.Items[4].Selected)
				{
					dataTable.Columns["RetQty"].ColumnName = "Ret Qty";
				}
				if (chkFields3.Items[7].Selected)
				{
					dataTable.Columns["EmpName2"].ColumnName = "MRN Generated By";
				}
				if (chkFields3.Items[5].Selected)
				{
					switch (GetPORate)
					{
					case 1:
						dataTable.Columns["rate_MAX1"].ColumnName = "MRN Rate";
						break;
					case 2:
						dataTable.Columns["rate_MIN1"].ColumnName = "MRN Rate";
						break;
					case 3:
						dataTable.Columns["rate_avg1"].ColumnName = "MRN Rate";
						break;
					case 4:
						dataTable.Columns["rate_Actual1"].ColumnName = "MRN Rate";
						break;
					}
				}
				if (chkFields3.Items[8].Selected)
				{
					dataTable.Columns["MRNAmount"].ColumnName = "MRN Amount";
				}
			}
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
		base.Response.Redirect("~/Module/Inventory/Reports/Search.aspx");
	}
}

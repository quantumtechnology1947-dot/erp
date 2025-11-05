using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_BOM_Design_WO_TreeView_Delete : Page, IRequiresSessionState
{
	protected Label Label2;

	protected DropDownList DropDownList1;

	protected Label lblMsg;

	protected CheckBox CheckBox1;

	protected Button btnDel;

	protected Button Button1;

	protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string ConnString = "";

	private SqlConnection conn;

	private string woQueryStr = "";

	private List<int> BomAssmbly = new List<int>();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public DataTable GetDataTable(int drpValue)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		Label2.Text = woQueryStr;
		try
		{
			conn.Open();
			string cmdText = fun.delete("tblDG_BOMItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
			sqlCommand.ExecuteNonQuery();
			string empty = string.Empty;
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOM Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			if (drpValue == 1)
			{
				string empty2 = string.Empty;
				empty = fun.select("PId,tblDG_BOM_Master.CId", "tblDG_BOM_Master,tblDG_Item_Master", "WONo='" + woQueryStr + "'And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'And tblDG_Item_Master.CId Is not null Order By PId ASC");
				sqlDataAdapter.SelectCommand = new SqlCommand(empty, conn);
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				List<string> list = new List<string>();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					list = fun.BOMTree_Search(woQueryStr, Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]));
				}
				for (int j = 0; j < list.Count; j++)
				{
					DataRow dataRow = dataTable.NewRow();
					empty2 = fun.select("ItemId,ItemCode,UOMBasic,tblDG_Item_Master.PartNo,ManfDesc,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.Id,tblDG_BOM_Master.Revision", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(list[j]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + woQueryStr + "'");
					SqlCommand selectCommand = new SqlCommand(empty2, conn);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemId"];
						dataRow[1] = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0]["PId"];
						dataRow[3] = dataSet2.Tables[0].Rows[0]["CId"];
						dataRow[7] = decimal.Parse(dataSet2.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
						if (dataSet2.Tables[0].Rows[0]["CId"] != DBNull.Value)
						{
							dataRow[4] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
						}
						else
						{
							dataRow[4] = dataSet2.Tables[0].Rows[0]["PartNo"].ToString();
						}
						dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText2 = fun.select("Symbol", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, conn);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
						}
						List<double> list2 = new List<double>();
						list2 = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
						double num = 1.0;
						for (int k = 0; k < list2.Count; k++)
						{
							num *= list2[k];
						}
						dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
						dataRow[9] = dataSet2.Tables[0].Rows[0]["Id"].ToString();
						dataRow[10] = dataSet2.Tables[0].Rows[0]["Revision"].ToString();
						list2.Clear();
						dataTable.Rows.Add(dataRow);
					}
				}
			}
			else
			{
				string text = string.Empty;
				if (drpValue == 2)
				{
					text = "And tblDG_Item_Master.CId is null";
				}
				empty = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_Item_Master.CId As Cat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,UOMBasic,Symbol,tblDG_BOM_Master.Id,tblDG_BOM_Master.Revision", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And WONo='" + woQueryStr + "'And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'" + text + "  Order By PId ASC");
				sqlDataAdapter.SelectCommand = new SqlCommand(empty, conn);
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[l][0];
					dataRow[1] = dataSet.Tables[0].Rows[l][1].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[l][2];
					dataRow[3] = dataSet.Tables[0].Rows[l][3];
					dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[l][4].ToString()).ToString("N3");
					if (dataSet.Tables[0].Rows[l]["Cat"] != DBNull.Value)
					{
						dataRow[4] = dataSet.Tables[0].Rows[l]["ItemCode"].ToString();
					}
					else
					{
						dataRow[4] = dataSet.Tables[0].Rows[l]["PartNo"].ToString();
					}
					dataRow[5] = dataSet.Tables[0].Rows[l]["ManfDesc"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[l]["Symbol"].ToString();
					List<double> list3 = new List<double>();
					list3 = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
					double num2 = 1.0;
					for (int m = 0; m < list3.Count; m++)
					{
						num2 *= list3[m];
					}
					dataRow[8] = decimal.Parse(num2.ToString()).ToString("N3");
					dataRow[9] = dataSet.Tables[0].Rows[l]["Id"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[l]["Revision"].ToString();
					list3.Clear();
					dataTable.Rows.Add(dataRow);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			conn.Close();
			GC.Collect();
		}
		dataTable.DefaultView.Sort = "Item Code ASC";
		return dataTable.DefaultView.ToTable(true);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			woQueryStr = base.Request.QueryString["WONo"].ToString();
			ConnString = fun.Connection();
			conn = new SqlConnection(ConnString);
			if (!base.IsPostBack)
			{
				RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
				RadTreeList1.DataBind();
				RadTreeList1.ExpandAllItems();
				CheckBox1.Checked = true;
				DataBind();
				DisableCk();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
	{
		if (e.CommandName == "ExpandCollapse")
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			DisableCk();
		}
	}

	protected void RadTreeList1_PageIndexChanged(object source, TreeListPageChangedEventArgs e)
	{
		RadTreeList1.CurrentPageIndex = e.NewPageIndex;
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
		DisableCk();
	}

	protected void RadTreeList1_PageSizeChanged(object source, TreeListPageSizeChangedEventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
		DisableCk();
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
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
		if (e.Column.HeaderText == "Id")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "Item Code")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(420);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Unit Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "BOM Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "UOM")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(60);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Revision")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			RadTreeList1.ExpandAllItems();
			DisableCk();
		}
		else
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			RadTreeList1.CollapseAllItems();
			DisableCk();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_Delete.aspx?ModId=3&SubModId=26");
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		try
		{
			if (RadTreeList1.SelectedItems.Count > 0)
			{
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				int node = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
				string text = RadTreeList1.SelectedItems[0]["WONo"].Text;
				int id = Convert.ToInt32(RadTreeList1.SelectedItems[0]["Id"].Text);
				List<int> list = new List<int>();
				list = fun.getBOMDelNode(node, text, CompId, SId, id, "tblDG_BOM_Master");
				for (int i = 0; i < list.Count; i++)
				{
					string cmdText = fun.delete("tblDG_BOM_Master", "WONo='" + text + "' AND Id='" + list[i] + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				string cmdText2 = fun.select("WONo", "tblDG_BOM_Master", "WONo='" + text + "'And CompId=" + CompId + "And FinYearId=" + FinYearId);
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.select("Id", "tblDG_Gunrail_Pitch_Master", "WONo='" + text + "'And CompId=" + CompId + "And FinYearId=" + FinYearId);
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						string cmdText4 = fun.delete("tblDG_Gunrail_LongRail", string.Concat("MId='", dataSet2.Tables[0].Rows[0][0], "'"));
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
						string cmdText5 = fun.delete("tblDG_Gunrail_CrossRail", string.Concat("MId='", dataSet2.Tables[0].Rows[0][0], "'"));
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand3.ExecuteNonQuery();
						sqlConnection.Close();
						string cmdText6 = fun.delete("tblDG_Gunrail_Pitch_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[0][0], "'"));
						SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
						sqlConnection.Open();
						sqlCommand4.ExecuteNonQuery();
						sqlConnection.Close();
					}
					else
					{
						string cmdText7 = fun.select("Id", "tblDG_Gunrail_Pitch_Dispatch_Master", "WONo='" + text + "'And CompId=" + CompId + "And FinYearId=" + FinYearId);
						SqlCommand selectCommand3 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							string cmdText8 = fun.delete("tblDG_Gunrail_LongRail_Dispatch", string.Concat("MId='", dataSet3.Tables[0].Rows[0][0], "'"));
							SqlCommand sqlCommand5 = new SqlCommand(cmdText8, sqlConnection);
							sqlConnection.Open();
							sqlCommand5.ExecuteNonQuery();
							sqlConnection.Close();
							string cmdText9 = fun.delete("tblDG_Gunrail_CrossRail_Dispatch", string.Concat("MId='", dataSet3.Tables[0].Rows[0][0], "'"));
							SqlCommand sqlCommand6 = new SqlCommand(cmdText9, sqlConnection);
							sqlConnection.Open();
							sqlCommand6.ExecuteNonQuery();
							sqlConnection.Close();
							string cmdText10 = fun.delete("tblDG_Gunrail_Pitch_Dispatch_Master", string.Concat("Id='", dataSet3.Tables[0].Rows[0][0], "'"));
							SqlCommand sqlCommand7 = new SqlCommand(cmdText10, sqlConnection);
							sqlConnection.Open();
							sqlCommand7.ExecuteNonQuery();
							sqlConnection.Close();
						}
					}
					base.Response.Redirect("BOM_Design_Delete.aspx?ModId=3&SubModId=26");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Please select Node to Delete.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public List<int> getBOMDelNode(int node, string wono, int CompId, int Id, string tblName)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int value = 0;
		try
		{
			new DataSet();
			sqlConnection.Open();
			string cmdText = fun.select("Id,PId,CId,ItemId,Qty", tblName ?? "", "CId=" + node + "And WONo='" + wono + "'And CompId=" + CompId + " And ItemId='" + Id + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = fun.select("Id,PId,CId,ItemId,Qty", tblName ?? "", string.Concat("WONo='", wono, "'And CompId=", CompId, " AND CId='", dataSet.Tables[0].Rows[i]["PId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					value = Convert.ToInt32(dataSet2.Tables[0].Rows[j]["ItemId"]);
					getBOMDelNode(Convert.ToInt32(dataSet2.Tables[0].Rows[j]["CId"]), wono, CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[j]["ItemId"]), tblName);
				}
				BomAssmbly.Add(Convert.ToInt32(value));
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return BomAssmbly;
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
		DisableCk();
	}

	public void DisableCk()
	{
		try
		{
			List<int> list = new List<int>();
			foreach (TreeListDataItem item in RadTreeList1.Items)
			{
				int num = Convert.ToInt32(item["ItemId"].Text);
				Convert.ToInt32(item["Id"].Text);
				int node = Convert.ToInt32(item["CId"].Text);
				string text = item["WONo"].Text;
				string cmdText = fun.select("tblMM_PR_Details.ItemId", "tblMM_PR_Details,tblMM_PR_Master", "  tblMM_PR_Master.Id=tblMM_PR_Details.MId And      tblMM_PR_Master.WONo='" + text + "'And tblMM_PR_Master.CompId=" + CompId + "And tblMM_PR_Master.FinYearId=" + FinYearId + "  And tblMM_PR_Details.ItemId='" + num + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, conn);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string cmdText2 = fun.select("tblInv_WIS_Details.ItemId", "tblInv_WIS_Master,tblInv_WIS_Details", "  tblInv_WIS_Master.Id=tblInv_WIS_Details.MId And      tblInv_WIS_Master.WONo='" + text + "'And tblInv_WIS_Master.CompId=" + CompId + "And tblInv_WIS_Master.FinYearId=" + FinYearId + "  And  tblInv_WIS_Details.ItemId='" + num + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, conn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("tblMP_Material_Detail.ItemId", "tblMP_Material_Detail,tblMP_Material_Master", "  tblMP_Material_Master.Id=tblMP_Material_Detail.MId And tblMP_Material_Master.WONo='" + text + "'And tblMP_Material_Master.CompId=" + CompId + "And tblMP_Material_Master.FinYearId=" + FinYearId + "  And tblMP_Material_Detail.ItemId='" + num + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, conn);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0 || dataSet3.Tables[0].Rows.Count > 0)
				{
					item["ck"].Enabled = false;
					list = getBOMDelNode(node, text, CompId, num, "tblDG_BOM_Master");
				}
			}
			foreach (TreeListDataItem item2 in RadTreeList1.Items)
			{
				int num2 = Convert.ToInt32(item2["ItemId"].Text);
				for (int i = 0; i < list.Count; i++)
				{
					if (num2 == list[i])
					{
						item2["ck"].Enabled = false;
					}
				}
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
}

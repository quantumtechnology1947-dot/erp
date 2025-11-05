using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_BOM_Design_WO_TreeView_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string ConnString = "";

	private SqlConnection conn;

	private string woQueryStr = "";

	protected Label Label2;

	protected DropDownList DropDownList1;

	protected Label lblMsg;

	protected CheckBox CheckBox1;

	protected Button Button1;

	protected RadTreeList RadTreeList1;

	protected Panel Panel1;

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
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("uploadImg", typeof(string)));
			dataTable.Columns.Add(new DataColumn("uploadSpec", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(string)));
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
					empty2 = fun.select("ItemId,ItemCode,UOMBasic,FileName,AttName,tblDG_Item_Master.PartNo,ManfDesc,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.Id,AmdNo,tblDG_BOM_Master.Revision", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(list[j]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + woQueryStr + "'");
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
						if (dataSet2.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet2.Tables[0].Rows[0]["FileName"] != DBNull.Value)
						{
							dataRow[9] = "View";
							dataRow[11] = "";
						}
						else
						{
							dataRow[9] = "";
							dataRow[11] = "Upload";
						}
						if (dataSet2.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet2.Tables[0].Rows[0]["AttName"] != DBNull.Value)
						{
							dataRow[10] = "View";
							dataRow[12] = "";
						}
						else
						{
							dataRow[10] = "";
							dataRow[12] = "Upload";
						}
						List<double> list2 = new List<double>();
						list2 = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
						double num = 1.0;
						for (int k = 0; k < list2.Count; k++)
						{
							num *= list2[k];
						}
						dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
						dataRow[13] = dataSet2.Tables[0].Rows[0]["Id"].ToString();
						dataRow[14] = dataSet2.Tables[0].Rows[0]["AmdNo"].ToString();
						dataRow[15] = dataSet2.Tables[0].Rows[0]["Revision"];
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
				empty = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_Item_Master.CId As Cat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,UOMBasic,FileName,AttName,Symbol,tblDG_BOM_Master.Id,AmdNo,tblDG_BOM_Master.Revision", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And WONo='" + woQueryStr + "'And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'" + text + "  Order By PId ASC");
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
					if (dataSet.Tables[0].Rows[l]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[l]["FileName"] != DBNull.Value)
					{
						dataRow[9] = "View";
						dataRow[11] = "";
					}
					else
					{
						dataRow[9] = "";
						dataRow[11] = "Upload";
					}
					if (dataSet.Tables[0].Rows[l]["AttName"].ToString() != "" && dataSet.Tables[0].Rows[l]["AttName"] != DBNull.Value)
					{
						dataRow[10] = "View";
						dataRow[12] = "";
					}
					else
					{
						dataRow[10] = "";
						dataRow[12] = "Upload";
					}
					dataRow[13] = dataSet.Tables[0].Rows[l]["Id"].ToString();
					dataRow[14] = dataSet.Tables[0].Rows[l]["AmdNo"].ToString();
					dataRow[15] = dataSet.Tables[0].Rows[l]["Revision"];
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
		}
	}

	protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
	{
		if (e.CommandName == "ExpandCollapse")
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
		}
		if (e.CommandName == "Sel")
		{
			TreeListDataItem treeListDataItem = e.Item as TreeListDataItem;
			string text = ((Label)treeListDataItem.FindControl("lblWONo")).Text;
			int num = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblPId")).Text);
			int num2 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblCId")).Text);
			int num3 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblItemId")).Text);
			int num4 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblId")).Text);
			string text2 = "BOM_Design_WO_TreeView_Edit.aspx";
			if (num == 0)
			{
				base.Response.Redirect("~/Module/Design/Transactions/BOM_Design_Assembly_Edit.aspx?Id=" + num4 + "&CId=" + num2 + "&WONo=" + text + "&ItemId=" + num3 + "&PgUrl=" + text2 + "&ModId=3&SubModId=26");
			}
			else
			{
				base.Response.Redirect("BOM_Design_Item_Edit.aspx?Id=" + num4 + "&CId=" + num2 + "&WONo=" + text + "&ItemId=" + num3 + "&PgUrl=" + text2 + "&ModId=3&SubModId=26");
			}
		}
		else
		{
			string empty = string.Empty;
			empty = "This is Standard Item.It can not be modify.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		if (e.CommandName == "downloadImg")
		{
			TreeListDataItem treeListDataItem2 = e.Item as TreeListDataItem;
			int num5 = Convert.ToInt32(((Label)treeListDataItem2.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num5 + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
		}
		if (e.CommandName == "uploadImg")
		{
			TreeListDataItem treeListDataItem3 = e.Item as TreeListDataItem;
			string text3 = ((Label)treeListDataItem3.FindControl("lblWONo")).Text;
			int num6 = Convert.ToInt32(((Label)treeListDataItem3.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/BOM_UploadDrw.aspx?WONo=" + text3 + "&Id=" + num6 + "&img=0");
		}
		if (e.CommandName == "downloadSpec")
		{
			TreeListDataItem treeListDataItem4 = e.Item as TreeListDataItem;
			int num7 = Convert.ToInt32(((Label)treeListDataItem4.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num7 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
		}
		if (e.CommandName == "uploadSpec")
		{
			TreeListDataItem treeListDataItem5 = e.Item as TreeListDataItem;
			string text4 = ((Label)treeListDataItem5.FindControl("lblWONo")).Text;
			int num8 = Convert.ToInt32(((Label)treeListDataItem5.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/BOM_UploadDrw.aspx?WONo=" + text4 + "&Id=" + num8 + "&img=1");
		}
		if (e.CommandName == "Amd")
		{
			TreeListDataItem treeListDataItem6 = e.Item as TreeListDataItem;
			string text5 = ((Label)treeListDataItem6.FindControl("lblWONo")).Text;
			int num9 = Convert.ToInt32(((Label)treeListDataItem6.FindControl("lblItemId")).Text);
			int num10 = Convert.ToInt32(((Label)treeListDataItem6.FindControl("lblId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/BOM_Amd.aspx?WONo=" + text5 + "&Id=" + num10 + "&ItemId=" + num9);
		}
	}

	protected void RadTreeList1_PageIndexChanged(object source, TreeListPageChangedEventArgs e)
	{
		RadTreeList1.CurrentPageIndex = e.NewPageIndex;
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
	}

	protected void RadTreeList1_PageSizeChanged(object source, TreeListPageSizeChangedEventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
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
		if (e.Column.HeaderText == "AmdNo")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "Item Code")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Amd No")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(300);
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
		if (e.Column.HeaderText == "FileName")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "AttName")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "uploadImg")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "uploadSpec")
		{
			e.Column.Visible = false;
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			RadTreeList1.ExpandAllItems();
		}
		else
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			RadTreeList1.CollapseAllItems();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_WO_Grid_Update.aspx?ModId=3&SubModId=26");
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_TPL_Design_WO_TreeView_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string SId = "";

	private int FinId;

	private string ConnString = "";

	private SqlConnection conn;

	protected Label Label2;

	protected Label lblMsg;

	protected CheckBox CheckBox1;

	protected Button Button1;

	protected RadTreeList RadTreeList1;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public DataTable GetDataTable()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		string text = base.Request.QueryString["WONo"].ToString();
		Label2.Text = text;
		try
		{
			conn.Open();
			lblMsg.Text = "";
			if (base.Request.QueryString["msg"] != null)
			{
				lblMsg.Text = base.Request.QueryString["msg"].ToString();
			}
			string cmdText = fun.delete("tblDG_TPLItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, conn);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = fun.select("ItemId,WONo,PId,CId,Qty,Id,AmdNo", "tblDG_TPL_Master ", "WONo='" + text + "'AND CompId='" + CompId + "'And FinYearId<='" + FinId + "' Order By PId ASC");
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText2, conn);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TPL Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("uploadImg", typeof(string)));
			dataTable.Columns.Add(new DataColumn("uploadSpec", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[i][4].ToString()).ToString("N3");
				string cmdText3 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "'AND CompId='", CompId, "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText3, conn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					if (dataSet2.Tables[0].Rows[0]["CId"] != DBNull.Value)
					{
						dataRow[4] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[4] = dataSet2.Tables[0].Rows[0]["PartNo"].ToString();
					}
					dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText4 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText4, conn);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				List<double> list = new List<double>();
				list = fun.TreeQty(text, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
				string cmdText5 = fun.select("tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.Id", "tblDG_Item_Master", string.Concat("tblDG_Item_Master.Id='", dataSet.Tables[0].Rows[i][0], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText5, conn);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					if (dataSet4.Tables[0].Rows[0]["FileName"] != "" && dataSet4.Tables[0].Rows[0]["FileName"] != DBNull.Value)
					{
						dataRow[9] = "View";
						dataRow[11] = "";
					}
					else
					{
						dataRow[9] = "";
						dataRow[11] = "Upload";
					}
					if (dataSet4.Tables[0].Rows[0]["AttName"] != "" && dataSet4.Tables[0].Rows[0]["AttName"] != DBNull.Value)
					{
						dataRow[10] = "View";
						dataRow[12] = "";
					}
					else
					{
						dataRow[10] = "";
						dataRow[12] = "Upload";
					}
				}
				dataRow[13] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[14] = dataSet.Tables[0].Rows[i]["AmdNo"].ToString();
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

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			ConnString = fun.Connection();
			conn = new SqlConnection(ConnString);
			if (!base.IsPostBack)
			{
				RadTreeList1.DataSource = GetDataTable();
				RadTreeList1.DataBind();
				RadTreeList1.ExpandAllItems();
				CheckBox1.Checked = true;
				DataBind();
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
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
		}
		if (e.CommandName == "Sel")
		{
			TreeListDataItem treeListDataItem = e.Item as TreeListDataItem;
			string text = ((Label)treeListDataItem.FindControl("lblWONo")).Text;
			Convert.ToInt32(((Label)treeListDataItem.FindControl("lblPId")).Text);
			int num = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblCId")).Text);
			int num2 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblItemId")).Text);
			int num3 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblId")).Text);
			string text2 = "TPL_Design_WO_TreeView.aspx";
			string cmdText = fun.select("*", "tblDG_TPL_Master", " PId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, conn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				base.Response.Redirect("TPL_Design_Item_Edit.aspx?Id=" + num3 + "&CId=" + num + "&WONo=" + text + "&ItemId=" + num2 + "&PgUrl=" + text2 + "&ModId=3&SubModId=23");
			}
			else
			{
				string empty = string.Empty;
				empty = "Assembly item can not be modify.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		if (e.CommandName == "downloadImg")
		{
			TreeListDataItem treeListDataItem2 = e.Item as TreeListDataItem;
			int num4 = Convert.ToInt32(((Label)treeListDataItem2.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num4 + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
		}
		if (e.CommandName == "downloadSpec")
		{
			TreeListDataItem treeListDataItem3 = e.Item as TreeListDataItem;
			int num5 = Convert.ToInt32(((Label)treeListDataItem3.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num5 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
		}
		if (e.CommandName == "uploadImg")
		{
			TreeListDataItem treeListDataItem4 = e.Item as TreeListDataItem;
			string text3 = ((Label)treeListDataItem4.FindControl("lblWONo")).Text;
			int num6 = Convert.ToInt32(((Label)treeListDataItem4.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/UploadDrw.aspx?WONo=" + text3 + "&Id=" + num6 + "&img=0");
		}
		if (e.CommandName == "uploadSpec")
		{
			TreeListDataItem treeListDataItem5 = e.Item as TreeListDataItem;
			string text4 = ((Label)treeListDataItem5.FindControl("lblWONo")).Text;
			int num7 = Convert.ToInt32(((Label)treeListDataItem5.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/UploadDrw.aspx?WONo=" + text4 + "&Id=" + num7 + "&img=1");
		}
		if (e.CommandName == "Amd")
		{
			TreeListDataItem treeListDataItem6 = e.Item as TreeListDataItem;
			string text5 = ((Label)treeListDataItem6.FindControl("lblWONo")).Text;
			int num8 = Convert.ToInt32(((Label)treeListDataItem6.FindControl("lblItemId")).Text);
			int num9 = Convert.ToInt32(((Label)treeListDataItem6.FindControl("lblId")).Text);
			base.Response.Redirect("~/Module/Design/Transactions/TPL_Amd.aspx?WONo=" + text5 + "&Id=" + num9 + "&ItemId=" + num8);
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
			e.Column.HeaderStyle.Width = Unit.Pixel(150);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(340);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Unit Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "TPL Qty")
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
		if (e.Column.HeaderText == "Amd No")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "AmdNo")
		{
			e.Column.Visible = false;
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_Grid_Update.aspx?ModId=3&SubModId=23");
	}
}

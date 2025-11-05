using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_BOM_Design_Print_Tree : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	public string wonosrc = "";

	public string wonodest = "";

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private string StartDate = "";

	private string UpToDate = "";

	private string connStr = string.Empty;

	private SqlConnection conn;

	private string getRandomKey = string.Empty;

	protected Label Label2;

	protected DropDownList DropDownList1;

	protected CheckBox CheckBox1;

	protected Button btnCancel;

	protected Label lblasslymsg;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			conn = new SqlConnection(connStr);
			lblasslymsg.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				wonosrc = base.Request.QueryString["WONo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["SD"]))
			{
				StartDate = base.Request.QueryString["SD"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["TD"]))
			{
				UpToDate = base.Request.QueryString["TD"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				lblasslymsg.Text = base.Request.QueryString["msg"];
			}
			if (!Page.IsPostBack)
			{
				getRandomKey = fun.GetRandomAlphaNumeric();
				RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
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

	public DataTable GetDataTable(int drpValue)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		Label2.Text = wonosrc;
		try
		{
			conn.Open();
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UnitQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Download", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DownloadSpec", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EntryDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Entered by", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Revision", typeof(string)));
			if (drpValue == 1)
			{
				string empty = string.Empty;
				string cmdText = fun.select("PId,tblDG_BOM_Master.CId", "tblDG_BOM_Master,tblDG_Item_Master", "WONo='" + wonosrc + "'And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'And tblDG_Item_Master.CId Is not null And tblDG_BOM_Master.SysDate between '" + fun.FromDate(StartDate) + "' and '" + fun.FromDate(UpToDate) + "' Order By PId ASC");
				sqlDataAdapter.SelectCommand = new SqlCommand(cmdText, conn);
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				List<string> list = new List<string>();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					list = fun.BOMTree_Search(wonosrc, Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]));
				}
				for (int j = 0; j < list.Count; j++)
				{
					DataRow dataRow = dataTable.NewRow();
					empty = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.SysDate,Title+'.'+EmployeeName As EmpLoyeeName,tblDG_Item_Master.CId As ItemCat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,FileName,AttName,Symbol,tblDG_Item_Master.Revision", "tblDG_Item_Master,tblDG_BOM_Master,tblHR_OfficeStaff,Unit_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(list[j]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblHR_OfficeStaff.EmpId=tblDG_BOM_Master.SessionId And Unit_Master.Id=tblDG_Item_Master.UOMBasic And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + wonosrc + "'");
					SqlCommand selectCommand = new SqlCommand(empty, conn);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0][0];
						dataRow[1] = dataSet2.Tables[0].Rows[0][1].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0][2];
						dataRow[3] = dataSet2.Tables[0].Rows[0][3];
						dataRow[7] = decimal.Parse(dataSet2.Tables[0].Rows[0][4].ToString()).ToString("N3");
						if (dataSet2.Tables[0].Rows[0]["ItemCat"] != DBNull.Value)
						{
							dataRow[4] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
						}
						else
						{
							dataRow[4] = dataSet2.Tables[0].Rows[0]["PartNo"].ToString();
						}
						dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						dataRow[6] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
						if (!string.IsNullOrEmpty(dataSet2.Tables[0].Rows[0]["FileName"].ToString()))
						{
							dataRow[9] = "View";
						}
						if (!string.IsNullOrEmpty(dataSet2.Tables[0].Rows[0]["AttName"].ToString()))
						{
							dataRow[10] = "View";
						}
						List<double> list2 = new List<double>();
						list2 = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
						double num = 1.0;
						for (int k = 0; k < list2.Count; k++)
						{
							num *= list2[k];
						}
						dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
						dataRow[11] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["SysDate"].ToString());
						dataRow[12] = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
						dataRow[13] = dataSet2.Tables[0].Rows[0]["Revision"].ToString();
						list2.Clear();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			else
			{
				string value = string.Empty;
				if (drpValue == 2)
				{
					value = "And tblDG_Item_Master.CId is null";
				}
				sqlDataAdapter = new SqlDataAdapter("Get_BOM_DateWise", conn);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@ItemCId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@ItemCId"].Value = value;
				sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
				for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[l][0];
					dataRow[1] = dataSet.Tables[0].Rows[l][1].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[l][2];
					dataRow[3] = dataSet.Tables[0].Rows[l][3];
					dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[l][4].ToString()).ToString("N3");
					if (dataSet.Tables[0].Rows[l]["ItemCat"] != DBNull.Value)
					{
						dataRow[4] = dataSet.Tables[0].Rows[l]["ItemCode"].ToString();
					}
					else
					{
						dataRow[4] = dataSet.Tables[0].Rows[l]["PartNo"].ToString();
					}
					dataRow[5] = dataSet.Tables[0].Rows[l]["ManfDesc"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[l]["Symbol"].ToString();
					if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[l]["FileName"].ToString()))
					{
						dataRow[9] = "View";
					}
					if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[l]["AttName"].ToString()))
					{
						dataRow[10] = "View";
					}
					List<double> list3 = new List<double>();
					list3 = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
					double num2 = 1.0;
					for (int m = 0; m < list3.Count; m++)
					{
						num2 *= list3[m];
					}
					dataRow[8] = decimal.Parse(num2.ToString()).ToString("N3");
					dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[l]["SysDate"].ToString());
					dataRow[12] = dataSet.Tables[0].Rows[l]["EmployeeName"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[l]["Revision"].ToString();
					list3.Clear();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
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
		dataTable.DefaultView.Sort = "Item Code ASC";
		return dataTable.DefaultView.ToTable(true);
	}

	protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
	{
		if (e.CommandName == "ExpandCollapse")
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
		}
		if (e.Item is TreeListDataItem)
		{
			TreeListDataItem treeListDataItem = e.Item as TreeListDataItem;
			if (e.CommandName == "Download")
			{
				int num = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=fileName&qct=ContentType");
			}
			if (e.CommandName == "DownloadSpec")
			{
				int num2 = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
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

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (RadTreeList1.SelectedItems.Count > 0)
		{
			string text = RadTreeList1.SelectedItems[0]["WONo"].Text;
			int num = Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
			int num2 = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
			base.Response.Redirect("~/Module/Design/Transactions/BOM_Design_Print_Cry.aspx?WONo=" + text + "&PId=" + num + "&CId=" + num2 + "&SD=" + StartDate + "&TD=" + UpToDate + "&DrpVal=" + Convert.ToInt32(DropDownList1.SelectedValue) + "&Key=" + getRandomKey + "&ModId=3&SubModId=26");
		}
	}

	protected void RadTreeList1_AutoGeneratedColumnCreated(object sender, TreeListAutoGeneratedColumnCreatedEventArgs e)
	{
		if (e.Column.HeaderText == "ItemId")
		{
			e.Column.Visible = false;
		}
		if (e.Column.HeaderText == "EntryDate")
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
			e.Column.HeaderStyle.Width = Unit.Pixel(90);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(300);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "UnitQty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "BOMQty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "UOM")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(60);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Entry Date")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(100);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Entered by")
		{
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Justify;
		}
		if (e.Column.HeaderText == "Download")
		{
			e.Column.Visible = false;
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "DownloadSpec")
		{
			e.Column.Visible = false;
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Revision")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(70);
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
		}
		else
		{
			RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
			RadTreeList1.DataBind();
			RadTreeList1.CollapseAllItems();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_PrintWo.aspx?ModId=3&SubModId=26");
	}

	protected void ImageButton1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Design/Transactions/BOM_Design_Print_Cry.aspx?wono=" + wonosrc + "&PId=&CId=&SD=" + StartDate + "&TD=" + UpToDate + "&DrpVal=" + Convert.ToInt32(DropDownList1.SelectedValue) + "&Key=" + getRandomKey + "&ModId=3&SubModId=26");
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
		RadTreeList1.DataBind();
	}
}

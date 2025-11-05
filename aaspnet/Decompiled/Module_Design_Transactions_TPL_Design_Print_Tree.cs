using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_TPL_Design_Print_Tree : Page, IRequiresSessionState
{
	protected Label Label2;

	protected CheckBox CheckBox1;

	protected Button btnCancel;

	protected Label lblasslymsg;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

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

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			wonosrc = base.Request.QueryString["WONo"].ToString();
			lblasslymsg.Text = "";
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (base.Request.QueryString["msg"] != "")
			{
				lblasslymsg.Text = base.Request.QueryString["msg"];
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["SD"]))
			{
				StartDate = base.Request.QueryString["SD"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["TD"]))
			{
				UpToDate = base.Request.QueryString["TD"].ToString();
			}
			if (!Page.IsPostBack)
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

	public DataTable GetDataTable()
	{
		string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		Label2.Text = wonosrc;
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("ItemId,WONo,PId,CId,Qty,SessionId,SysDate ", "tblDG_TPL_Master", "WONo='" + wonosrc + "'AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'And SysDate between '" + fun.FromDate(StartDate) + "' and '" + fun.FromDate(UpToDate) + "' Order By PId ASC");
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText, sqlConnection);
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
			dataTable.Columns.Add(new DataColumn("EntryDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Entered by", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[i][4].ToString()).ToString("N3");
				string cmdText2 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "'And CompId='", CompId, "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
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
					string cmdText3 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				List<double> list = new List<double>();
				list = fun.TreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
				string cmdText4 = fun.select("tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.Id", "tblDG_Item_Master", string.Concat("tblDG_Item_Master.Id='", dataSet.Tables[0].Rows[i][0], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					if (dataSet4.Tables[0].Rows[0]["FileName"] != "" && dataSet4.Tables[0].Rows[0]["FileName"] != DBNull.Value)
					{
						dataRow[9] = "View";
					}
					else
					{
						dataRow[9] = "";
					}
					if (dataSet4.Tables[0].Rows[0]["AttName"] != "" && dataSet4.Tables[0].Rows[0]["AttName"] != DBNull.Value)
					{
						dataRow[10] = "View";
					}
					else
					{
						dataRow[10] = "";
					}
				}
				dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				string cmdText5 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[12] = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
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
			sqlConnection.Close();
		}
		return dataTable;
	}

	protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "ExpandCollapse")
			{
				RadTreeList1.DataSource = GetDataTable();
				RadTreeList1.DataBind();
			}
			if (e.CommandName == "downloadImg")
			{
				TreeListDataItem treeListDataItem = e.Item as TreeListDataItem;
				int num = Convert.ToInt32(((Label)treeListDataItem.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
			}
			if (e.CommandName == "downloadSpec")
			{
				TreeListDataItem treeListDataItem2 = e.Item as TreeListDataItem;
				int num2 = Convert.ToInt32(((Label)treeListDataItem2.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadTreeList1_PageIndexChanged(object source, TreeListPageChangedEventArgs e)
	{
		try
		{
			RadTreeList1.CurrentPageIndex = e.NewPageIndex;
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void RadTreeList1_PageSizeChanged(object source, TreeListPageSizeChangedEventArgs e)
	{
		try
		{
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (RadTreeList1.SelectedItems.Count > 0)
		{
			string text = RadTreeList1.SelectedItems[0]["WONo"].Text;
			int num = Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
			int num2 = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
			base.Response.Redirect("~/Module/Design/Transactions/TPL_Design_Print_Cry.aspx?WONo=" + text + "&PId=" + num + "&CId=" + num2 + "&SD=" + StartDate + "&TD=" + UpToDate + "&ModId=3&SubModId=23");
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
			e.Column.HeaderStyle.Width = Unit.Pixel(120);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Description")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(310);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
		}
		if (e.Column.HeaderText == "Unit Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "TPL Qty")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(80);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "UOM")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(50);
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
		if (e.Column.HeaderText == "EntryDate")
		{
			e.Column.Visible = false;
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
		base.Response.Redirect("TPL_Design_PrintWo.aspx?ModId=3&SubModId=23");
	}

	protected void ImageButton1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Design/Transactions/TPL_Design_Print_Cry.aspx?wono=" + wonosrc + "&PId=&CId=&SD=" + StartDate + "&TD=" + UpToDate + "&ModId=3&SubModId=23");
	}
}

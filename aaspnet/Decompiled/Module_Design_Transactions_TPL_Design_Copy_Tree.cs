using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Design_Transactions_TPL_Design_Copy_Tree : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	public string wonosrc = "";

	public string wonodest = "";

	protected Label Label2;

	protected CheckBox CheckBox1;

	protected Label lblasslymsg;

	protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

	protected ScriptManager ScriptManager1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			wonosrc = base.Request.QueryString["WONoSrc"].ToString();
			wonodest = base.Request.QueryString["WONoDest"].ToString();
			pid = Convert.ToInt32(base.Request.QueryString["DestPId"]);
			cid = Convert.ToInt32(base.Request.QueryString["DestCId"]);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
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
			string cmdText = fun.select("ItemId,WONo,PId,CId,Qty,Weldments,LH,RH ", "tblDG_TPL_Master", "WONo='" + wonosrc + "' AND CompId=" + CompId + " AND FinYearId<='" + FinYearId + "' Order By PId ASC");
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText, sqlConnection);
			sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Manf Desc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TPL Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Weld", typeof(string)));
			dataTable.Columns.Add(new DataColumn("LH", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RH", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[i][4].ToString()).ToString("N3");
				string cmdText2 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "'AND CompId=", CompId, " AND FinYearId<='", FinYearId, "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				dataRow[4] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
				dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText3 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				List<double> list = new List<double>();
				list = fun.TreeQty(wonosrc, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
				dataRow[9] = dataSet.Tables[0].Rows[i]["Weldments"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["LH"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["RH"].ToString();
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
		}
		catch (Exception)
		{
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
		if (e.Column.HeaderText == "Item Code")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(150);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
		}
		if (e.Column.HeaderText == "Manf Desc")
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
		if (e.Column.HeaderText == "Weld")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(40);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "LH")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(40);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
		if (e.Column.HeaderText == "RH")
		{
			e.Column.HeaderStyle.Width = Unit.Pixel(40);
			e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
		}
	}

	protected void btnCopy_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			num = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
			if (cid == num)
			{
				base.Response.Redirect("TPL_Design_CopyWo.aspx?WONoSrc=" + wonosrc + "&WONoDest=" + wonodest + "&DestPId=" + pid + "&DestCId=" + cid + "&ModId=3&SubModId=23&msg=Selection of Assly/Item is incorrect.");
			}
			else
			{
				fun.getnode(num, wonosrc, wonodest, CompId, sId, FinYearId, pid, cid);
				base.Response.Redirect("TPL_Design_CopyWo.aspx?WONoSrc=" + wonosrc + "&WONoDest=" + wonodest + "&DestPId=" + pid + "&DestCId=" + cid + "&ModId=3&SubModId=23&msg=TPL is Copied sucessfuly in WONo:" + wonodest + " from WONo:" + wonosrc + ".");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_CopyWo.aspx?WONoSrc=" + wonosrc + "&WONoDest=" + wonodest + "&DestPId=" + pid + "&DestCId=" + cid);
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
}

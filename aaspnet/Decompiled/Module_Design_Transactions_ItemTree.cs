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

public class Module_Design_Transactions_ItemTree : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string woQueryStr = "";

	private int CompId;

	private int FinYearId;

	private string SId = "";

	protected Label Label2;

	protected Label lblmsg;

	protected CheckBox CheckBox1;

	protected Button btnCopy;

	protected Button Button1;

	protected RadTreeList RadTreeList1;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public DataTable GetDataTable()
	{
		string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		woQueryStr = base.Request.QueryString["WONo"].ToString();
		Label2.Text = woQueryStr;
		sqlConnection.Open();
		string cmdText = fun.delete("tblDG_TPLItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		sqlCommand.ExecuteNonQuery();
		string cmdText2 = fun.select("*", "tblDG_TPL_Master", "WONo='" + woQueryStr + "'AND CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' Order By PId ASC");
		sqlDataAdapter.SelectCommand = new SqlCommand(cmdText2, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblDG_TPL_Master");
		sqlDataAdapter.SelectCommand = new SqlCommand(cmdText2, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
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
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = dataSet.Tables[0].Rows[i][0];
			dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
			dataRow[2] = dataSet.Tables[0].Rows[i][2];
			dataRow[3] = dataSet.Tables[0].Rows[i][3];
			dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[i][4].ToString()).ToString("N3");
			string cmdText3 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "' And CompId='", CompId, "'And FinYearId<='", FinYearId, "'"));
			SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
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
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[6] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
			}
			List<double> list = new List<double>();
			list = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
			double num = 1.0;
			for (int j = 0; j < list.Count; j++)
			{
				num *= list[j];
			}
			dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
			string cmdText5 = fun.select("tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.Id", "tblDG_Item_Master", string.Concat("tblDG_Item_Master.Id='", dataSet.Tables[0].Rows[i][0], "'"));
			SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
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
			list.Clear();
			dataTable.Rows.Add(dataRow);
		}
		sqlConnection.Close();
		return dataTable;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		woQueryStr = base.Request.QueryString["WONo"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		SId = Session["username"].ToString();
		if (base.Request.QueryString["Msg"] != "")
		{
			lblmsg.Text = base.Request.QueryString["Msg"];
		}
		if (!base.IsPostBack)
		{
			RadTreeList1.DataSource = GetDataTable();
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
			RadTreeList1.DataSource = GetDataTable();
			RadTreeList1.DataBind();
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

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (RadTreeList1.SelectedItems.Count > 0)
		{
			string text = RadTreeList1.SelectedItems[0]["WONo"].Text;
			int num = Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
			int num2 = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
			string text2 = RadTreeList1.SelectedItems[0]["ItemId"].Text;
			base.Response.Redirect("WoItems.aspx?WONo=" + text + "&ItemId=" + text2 + "&PId=" + num + "&CId=" + num2 + "&ModId=3&SubModId=23");
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
		base.Response.Redirect("TPL_Design_WO_Grid.aspx?ModId=3&SubModId=23");
	}

	protected void btnCopy_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_Root_Assembly_Copy_WO.aspx?WONoDest=" + woQueryStr + "&ModId=3&SubModId=23");
	}
}

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

public class Module_Design_Transactions_TPL_Design_WO_TreeView_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	public int CompId;

	public string SId = "";

	public int FinYearId;

	protected Label Label2;

	protected Label lblMsg;

	protected CheckBox CheckBox1;

	protected Button btnDel;

	protected Button Button1;

	protected RadAjaxLoadingPanel RadAjaxLoadingPanel1;

	protected RadTreeList RadTreeList1;

	protected RadAjaxPanel RadAjaxPanel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public DataTable GetDataTable()
	{
		string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		string text = base.Request.QueryString["WONo"].ToString();
		Label2.Text = text;
		try
		{
			sqlConnection.Open();
			lblMsg.Text = "";
			if (base.Request.QueryString["msg"] != null)
			{
				lblMsg.Text = base.Request.QueryString["msg"].ToString();
			}
			string cmdText = fun.delete("tblDG_TPLItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = fun.select("ItemId,WONo,PId,CId,Qty,Id ", " tblDG_TPL_Master", "WONo='" + text + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' Order By PId ASC");
			sqlDataAdapter.SelectCommand = new SqlCommand(cmdText2, sqlConnection);
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
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = decimal.Parse(dataSet.Tables[0].Rows[i][4].ToString()).ToString("N3");
				string cmdText3 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "'And CompId='", CompId, "'"));
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
				list = fun.TreeQty(text, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num = 1.0;
				for (int j = 0; j < list.Count; j++)
				{
					num *= list[j];
				}
				dataRow[8] = decimal.Parse(num.ToString()).ToString("N3");
				dataRow[9] = dataSet.Tables[0].Rows[i]["Id"].ToString();
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

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
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
	}

	protected void RadTreeList1_AutoGeneratedColumnCreated(object sender, TreeListAutoGeneratedColumnCreatedEventArgs e)
	{
		try
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
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
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
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_Delete.aspx?ModId=3&SubModId=23");
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
				list = fun.getBOMDelNode(node, text, CompId, SId, id, "tblDG_TPL_Master");
				for (int i = 0; i < list.Count; i++)
				{
					string cmdText = fun.delete("tblDG_TPL_Master", "WONo='" + text + "' AND Id='" + list[i] + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_SPR_Edit_Details : Page, IRequiresSessionState
{
	protected GridView GridView3;

	protected Panel Panel1;

	protected Button btncancel;

	private clsFunctions fun = new clsFunctions();

	private string str = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private string SPRNo = "";

	private string MId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SPRNo = base.Request.QueryString["SPRNo"];
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"];
			if (!base.IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableEdit()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		foreach (GridViewRow row in GridView3.Rows)
		{
			string text = ((Label)row.FindControl("lblId")).Text;
			string cmdText = fun.select("tblMM_PO_Details.Id", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.SPRNo='" + SPRNo + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.SPRId='" + text + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((LinkButton)row.FindControl("linkBtn")).Visible = false;
				((Label)row.FindControl("lblDel")).Visible = true;
			}
			else
			{
				((LinkButton)row.FindControl("linkBtn")).Visible = true;
				((Label)row.FindControl("lblDel")).Visible = false;
			}
		}
	}

	public void LoadData()
	{
		str = fun.Connection();
		con = new SqlConnection(str);
		con.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SPRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(string)));
			string cmdText = fun.select("tblMM_SPR_Details.Discount,tblMM_SPR_Details.Id,tblMM_SPR_Master.SPRNo,tblMM_SPR_Details.ItemId,tblMM_SPR_Details.Qty,tblMM_SPR_Details.Rate,tblMM_SPR_Details.SupplierId,tblMM_SPR_Details.AHId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.Remarks", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + SPRNo + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo  AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.MId='" + MId + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["SPRNo"].ToString();
				string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
				dataRow[10] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[11] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				string cmdText4 = fun.select("SupplierName", "tblMM_Supplier_master", string.Concat("SupplierId ='", dataSet.Tables[0].Rows[i]["SupplierId"], "' AND CompId='", CompId, "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				dataRow[2] = dataSet4.Tables[0].Rows[0]["SupplierName"].ToString();
				string cmdText5 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["AHId"]) + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[3] = dataSet5.Tables[0].Rows[0]["Head"].ToString();
				if (dataSet.Tables[0].Rows[i]["WONo"] != DBNull.Value && dataSet.Tables[0].Rows[i]["WONo"].ToString() != "")
				{
					dataRow[4] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				}
				else
				{
					dataRow[4] = "NA";
				}
				string cmdText6 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["DeptId"]) + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					dataRow[5] = dataSet6.Tables[0].Rows[0]["Dept"].ToString();
				}
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				dataRow[8] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["Discount"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			disableEdit();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		LoadData();
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "edt")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string sPRNo = SPRNo;
				base.Response.Redirect("SPR_Edit_Details_Item.aspx?recId=" + num + "&Id=" + MId + "&SPRNo=" + sPRNo + "&ModId=6&SubModId=31");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SPR_Edit.aspx?ModId=6&SubModId=31");
	}
}

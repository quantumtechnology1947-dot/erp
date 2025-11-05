using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PR_Details_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string PRNo = "";

	private string MId = "";

	private string str = "";

	private SqlConnection con;

	protected GridView GridView3;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			PRNo = base.Request.QueryString["PRNo"];
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableDelete()
	{
		foreach (GridViewRow row in GridView3.Rows)
		{
			string text = ((Label)row.FindControl("lblid")).Text;
			string cmdText = fun.select("tblMM_PO_Details.Id", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.PRNo='" + PRNo + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.PRId='" + text + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((LinkButton)row.FindControl("Btndel")).Visible = false;
				((Label)row.FindControl("lblDel")).Visible = true;
			}
			else
			{
				((LinkButton)row.FindControl("Btndel")).Visible = true;
				((Label)row.FindControl("lblDel")).Visible = false;
			}
		}
	}

	public void LoadData()
	{
		con.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AccHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			string cmdText = fun.select("tblMM_PR_Master.PRNo,tblMM_PR_Details.ItemId,tblMM_PR_Details.Discount,tblMM_PR_Details.SupplierId,tblMM_PR_Details.AHId,tblMM_PR_Master.WONo,tblMM_PR_Details.Qty,tblMM_PR_Details.Rate,tblMM_PR_Details.Remarks,tblMM_PR_Details.Id", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + PRNo + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.MId='" + MId + "' AND tblMM_PR_Master.CompId='" + CompId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["PRNo"].ToString();
				string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[2] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id ='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[3] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				string cmdText4 = fun.select("Symbol AS Head", "AccHead", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["AHId"]) + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet4.Tables[0].Rows[0]["Head"].ToString();
				}
				dataRow[5] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				dataRow[8] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText5 = fun.select("tblMM_Supplier_master.SupplierName", "tblMM_Supplier_master,tblMM_PR_Details", string.Concat("tblMM_Supplier_master.SupplierId ='", dataSet.Tables[0].Rows[i]["SupplierId"], "' AND tblMM_Supplier_master.SupplierId=tblMM_PR_Details.SupplierId AND tblMM_PR_Details.PRNo='", dataSet.Tables[0].Rows[i]["PRNo"], "' AND tblMM_Supplier_master.CompId='", CompId, "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = dataSet5.Tables[0].Rows[0]["SupplierName"].ToString();
				}
				dataRow[11] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			disableDelete();
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
		if (!(e.CommandName == "del"))
		{
			return;
		}
		GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
		try
		{
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblid")).Text);
			string cmdText = fun.delete("tblMM_PR_Details", "PRNo='" + PRNo + "' AND Id='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			string cmdText2 = fun.select("*", "tblMM_PR_Details", "PRNo='" + PRNo + "' AND MId='" + MId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				string cmdText3 = fun.delete("tblMM_PR_Master", "PRNo='" + PRNo + "' AND CompId='" + CompId + "' AND Id='" + MId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				base.Response.Redirect("PR_Delete.aspx?ModId=6&SubModId=34");
			}
			else
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PR_Delete.aspx?ModId=6&SubModId=34");
	}
}

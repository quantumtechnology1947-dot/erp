using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialRequisitionSlip_MRS_Delete_Details : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRSNo = "";

	private string FyId = "";

	private int CompId;

	private string connStr = "";

	private string MId = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MRSNo = base.Request.QueryString["MRSNo"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = base.Request.QueryString["FyId"].ToString();
			MId = base.Request.QueryString["Id"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				LoadData();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.select("tblInv_MaterialRequisition_Details.Id", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id =tblInv_MaterialIssue_Master.MRSId AND tblInv_MaterialRequisition_Master.CompId ='" + CompId + "' AND tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId AND tblInv_MaterialRequisition_Details.Id='" + num + "' And tblInv_MaterialIssue_Master.MRSNo='" + MRSNo + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
					((Label)row.FindControl("lblmin")).Visible = true;
				}
				else
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = true;
					((Label)row.FindControl("lblmin")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		try
		{
			con.Open();
			SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.MRSNo,tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Master.Id='" + MId + "' AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.CompId='" + CompId + "' "), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MRSNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]);
				dataRow[1] = DS.Tables[0].Rows[i]["MRSNo"].ToString();
				SqlCommand selectCommand2 = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"]) + "' AND CompId='" + CompId + "'"), con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["UOMBasic"]) + "'"), con);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet2);
					dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[3] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet2.Tables[0].Rows[0]["UOM"].ToString();
					}
				}
				if (DS.Tables[0].Rows[i]["DeptId"].ToString() == "1")
				{
					dataRow[5] = "NA";
					dataRow[6] = DS.Tables[0].Rows[i]["WONo"].ToString();
				}
				else if (DS.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
				{
					string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + DS.Tables[0].Rows[i]["DeptId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText, con);
					DataSet dataSet3 = new DataSet();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					sqlDataAdapter4.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
						dataRow[6] = "NA";
					}
				}
				else
				{
					dataRow[6] = DS.Tables[0].Rows[0]["WONo"].ToString();
					dataRow[5] = "NA";
				}
				dataRow[7] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[8] = DS.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[0]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			con.Open();
			if (e.CommandName == "Del")
			{
				CompId = Convert.ToInt32(Session["compid"]);
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblInv_MaterialRequisition_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.MRSNo,tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Master.Id='" + MId + "' AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblInv_MaterialRequisition_Master", "CompId='" + CompId + "'  and Id='" + MId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("MaterialRequisitionSlip_MRS_Delete.aspx?ModId=9&SubModId=40");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialRequisitionSlip_MRS_Delete.aspx?ModId=9&SubModId=40");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		LoadData();
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private SqlConnection con;

	private string MINNo = "";

	private string MRSNo = "";

	private int FyId;

	private int CompId;

	private string sId = "";

	private string connStr = "";

	private string MId = "";

	protected GridView GridView1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MId = base.Request.QueryString["Id"].ToString();
			MINNo = base.Request.QueryString["MINNo"].ToString();
			MRSNo = base.Request.QueryString["MRSNo"].ToString();
			FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			LoadData();
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
			SqlCommand sqlCommand = new SqlCommand(fun.select("tblInv_MaterialIssue_Details.Id,tblInv_MaterialIssue_Details.MRSId,tblInv_MaterialIssue_Master.MRSId as MMId,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master", "tblInv_MaterialIssue_Master.Id='" + MId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "'"), con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("IssueQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
				SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", string.Concat("tblInv_MaterialRequisition_Details.Id='", Convert.ToInt32(sqlDataReader["MRSId"]), "' AND tblInv_MaterialRequisition_Master.CompId='", CompId, "' AND tblInv_MaterialRequisition_Master.Id='", sqlDataReader["MMId"], "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId")), con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SqlCommand selectCommand2 = new SqlCommand(fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "' AND  CompId='" + CompId + "'"), con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'"), con);
						DataSet dataSet3 = new DataSet();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[3] = dataSet3.Tables[0].Rows[0]["UOM"].ToString();
						}
						dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"].ToString()));
						dataRow[2] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					if (dataSet.Tables[0].Rows[0]["DeptId"].ToString() == "1")
					{
						dataRow[4] = "NA";
						dataRow[5] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					}
					else if (dataSet.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
					{
						string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["DeptId"]) + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText, con);
						DataSet dataSet4 = new DataSet();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							dataRow[5] = "NA";
						}
					}
					else
					{
						dataRow[5] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
						dataRow[4] = "NA";
					}
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
					dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader["IssueQty"].ToString()).ToString("N3"));
					dataRow[8] = dataSet.Tables[0].Rows[0]["Remarks"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
				}
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
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string text = ((Label)gridViewRow.FindControl("lblItemId")).Text;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				string cmdText = fun.select("StockQty", "tblDG_Item_Master", "Id='" + text + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				num3 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblIssueQty")).Text).ToString("N3"));
				num4 = num2 + num3;
				fun.StkAdjLog(CompId, FyId, sId, 2, MINNo, Convert.ToInt32(text), num3);
				string cmdText2 = fun.delete("tblInv_MaterialIssue_Details", "Id='" + num + "' AND MId='" + MId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText3 = fun.update("tblDG_Item_Master", "StockQty='" + num4 + "'", "Id='" + text + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
				sqlCommand2.ExecuteNonQuery();
				string cmdText4 = fun.select("tblInv_MaterialIssue_Details.Id", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details", "tblInv_MaterialIssue_Master.Id='" + MId + "' AND tblInv_MaterialIssue_Details.MId= tblInv_MaterialIssue_Master.Id AND tblInv_MaterialIssue_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					string cmdText5 = fun.delete("tblInv_MaterialIssue_Master", "CompId='" + CompId + "'  and Id='" + MId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
					sqlCommand3.ExecuteNonQuery();
					con.Close();
					base.Response.Redirect("MaterialIssueNote_MIN_Delete.aspx?MINNo=" + MINNo + "&ModId=9&SubModId=41");
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

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialIssueNote_MIN_Delete.aspx?ModId=9&SubModId=41");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			LoadData();
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectSummary_ProjectSummary_Details : Page, IRequiresSessionState
{
	protected Label lblWo;

	protected Button BtnCancel;

	protected Chart Chart1;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private string wono = "";

	private int CompId;

	private int FinYearId;

	private string ConnString = "";

	private SqlConnection conn;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		ConnString = fun.Connection();
		conn = new SqlConnection(ConnString);
		if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
		{
			lblWo.Text = base.Request.QueryString["WONo"].ToString();
			wono = base.Request.QueryString["WONo"].ToString();
		}
		GetDataTable();
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		try
		{
			conn.Open();
			string cmdText = fun.select("ItemId,PId,CId", "tblDG_BOM_Master", "WONo='" + wono + "' AND PId='0' AND CompId=" + CompId + " Order By CId DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, conn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			dataTable.Columns.Add(new DataColumn("ct", typeof(string)));
			dataTable.Columns.Add(new DataColumn("id", typeof(string)));
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				DataRow dataRow = dataTable.NewRow();
				sqlDataAdapter.SelectCommand = new SqlCommand(fun.select("ItemCode", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i][0].ToString() + "' AND CompId=" + CompId), conn);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter.Fill(dataSet2, "tblDG_Item_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					int pid = Convert.ToInt32(dataSet.Tables[0].Rows[i][1]);
					int cid = Convert.ToInt32(dataSet.Tables[0].Rows[i][2]);
					num2 = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, pid, cid, 1.0, CompId, FinYearId).ToString()).ToString("N3"));
					string cmdText2 = fun.select("sum(tblInv_WIS_Details.IssuedQty) as sum_IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.WISNo=tblInv_WIS_Details.WISNo AND tblInv_WIS_Master.WONo='" + wono + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND tblInv_WIS_Details.PId='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "' AND tblInv_WIS_Details.CId='" + dataSet.Tables[0].Rows[i]["CId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, conn);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet3.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
					}
					string cmdText3 = fun.select("tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SessionId ,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", " tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialRequisition_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.WONo='" + wono + "'   ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, conn);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter3.Fill(dataSet4);
					double num4 = 0.0;
					for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
					{
						num4 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[j]["IssueQty"].ToString()).ToString("N3"));
					}
					dataRow[1] = Convert.ToDouble(decimal.Parse(((num + num4) * 100.0 / num2).ToString()).ToString("N3")).ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			Chart1.Series[0].YValueMembers = dataTable.Columns[1].ToString();
			Chart1.Series[0].XValueMember = dataTable.Columns[0].ToString();
			Chart1.DataSource = dataTable;
			Chart1.DataBind();
			Chart1.Visible = true;
		}
		catch (Exception)
		{
		}
	}

	public void GetDataTable()
	{
		DataTable dataTable = new DataTable();
		DataSet dataSet = new DataSet();
		conn.Open();
		CompId = Convert.ToInt32(Session["compid"]);
		try
		{
			string cmdText = fun.select("ItemId,WONo,PId,CId,Qty,Weldments", "tblDG_BOM_Master", "WONo='" + wono + "' AND PId='0' Order By PId ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, conn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_BOM_Master");
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UnitQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Weld", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotWISQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DryRunQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BalanceBOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AfterStockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Progress", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i][0];
				dataRow[1] = dataSet.Tables[0].Rows[i][1].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i][2];
				dataRow[3] = dataSet.Tables[0].Rows[i][3];
				dataRow[7] = dataSet.Tables[0].Rows[i][4];
				string cmdText2 = fun.select("tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SessionId ,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", " tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialRequisition_Details.ItemId='" + dataSet.Tables[0].Rows[i][0].ToString() + "' And tblInv_MaterialRequisition_Details.WONo='" + wono + "'   ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, conn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				double num = 0.0;
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[j]["IssueQty"].ToString()).ToString("N3"));
				}
				string cmdText3 = fun.select("*", "tblDG_Item_Master", string.Concat("Id='", dataRow[0], "' AND CompId=", CompId));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, conn);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				dataRow[4] = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
				dataRow[5] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText4 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet3.Tables[0].Rows[0]["UOMBasic"]) + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, conn);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblDG_Item_Master");
				dataRow[6] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(wono, Convert.ToInt32(dataRow[2]), Convert.ToInt32(dataRow[3]));
				double num2 = 1.0;
				for (int k = 0; k < list.Count; k++)
				{
					num2 *= list[k];
				}
				double num3 = 0.0;
				num3 = Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3"));
				dataRow[8] = num3;
				dataRow[9] = dataSet.Tables[0].Rows[i]["Weldments"].ToString();
				dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
				string cmdText5 = fun.select("sum(tblInv_WIS_Details.IssuedQty) as sum_IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.WISNo=tblInv_WIS_Details.WISNo AND tblInv_WIS_Master.WONo='" + wono + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND tblInv_WIS_Details.PId='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "' AND tblInv_WIS_Details.CId='" + dataSet.Tables[0].Rows[i]["CId"].ToString() + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, conn);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				if (dataSet5.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet5.Tables[0].Rows.Count > 0)
				{
					num4 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				num6 = Convert.ToDouble(decimal.Parse(((num4 + num) * 100.0 / num3).ToString()).ToString("N3"));
				if (dataSet5.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[11] = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
					num4 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[11] = 0;
				}
				if (!(num2 >= 0.0))
				{
					continue;
				}
				num5 = Convert.ToDouble(decimal.Parse((num2 - num4).ToString()).ToString("N3"));
				double num7 = 0.0;
				double num8 = 0.0;
				if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0.0 && num5 >= 0.0)
				{
					if (Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= num5)
					{
						num7 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - num5;
						num8 = num5;
					}
					else if (num5 >= Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
					{
						num7 = 0.0;
						num8 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					}
				}
				if (Convert.ToDouble(decimal.Parse((num2 - (num4 + num8)).ToString()).ToString("N3")) >= 0.0)
				{
					dataRow[13] = Convert.ToDouble(decimal.Parse((num2 - (num4 + num8 + num)).ToString()).ToString("N3"));
				}
				else
				{
					dataRow[13] = 0;
				}
				dataRow[13] = Convert.ToDouble(decimal.Parse((num2 - (num4 + num8 + num)).ToString()).ToString("N3"));
				dataRow[12] = Convert.ToDouble(decimal.Parse(num8.ToString()).ToString("N3"));
				dataRow[14] = Convert.ToDouble(decimal.Parse(num7.ToString()).ToString("N3"));
				dataRow[15] = Convert.ToDouble(decimal.Parse(num6.ToString()).ToString("N3"));
				list.Clear();
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
			conn.Close();
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			string text = ((Label)gridViewRow.FindControl("lblWONo")).Text;
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblPId")).Text);
			int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblCId")).Text);
			base.Response.Redirect("~/Module/ProjectManagement/Reports/Componant_Details.aspx?Id=" + num + "&PID=" + num2 + "&CID=" + num3 + "&WONO=" + text + "&ModId=&SubModId=");
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary.aspx?ModId=7");
	}
}

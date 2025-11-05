using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_Edit_Details_PO_Grid : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private string po = "";

	private string MId = "";

	private int CompId;

	protected GridView GridView2;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SupCode = base.Request.QueryString["Code"].ToString();
			po = base.Request.QueryString["pono"];
			MId = base.Request.QueryString["mid"].ToString();
			if (!base.IsPostBack)
			{
				LoadSPRData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadSPRData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Discount,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Master.PRSPRFlag", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + po + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + MId + "'And tblMM_PO_Details.Id not in (select POId from tblMM_PO_Amd_Temp) AND tblMM_PO_Master.CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExST", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Disc", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				string value = "";
				string value2 = "";
				string value3 = "";
				string value4 = "";
				string value5 = "";
				string value6 = "";
				if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet.Tables[0].Rows[i]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + dataSet.Tables[0].Rows[i]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[0]["ItemId"].ToString() + "'  AND CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"].ToString()));
						value2 = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						value3 = dataSet4.Tables[0].Rows[0][0].ToString();
					}
					value4 = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
					value5 = "NA";
					string cmdText5 = fun.select("AccHead.Symbol AS Head", "AccHead", "AccHead.Id ='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["AHId"]) + "' ");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					value6 = dataSet5.Tables[0].Rows[0]["Head"].ToString();
				}
				else if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[i]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[i]["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'  ");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "' And CompId='" + CompId + "' ");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
						value2 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						value3 = dataSet8.Tables[0].Rows[0][0].ToString();
					}
					if (dataSet6.Tables[0].Rows[0]["DeptId"].ToString() == "0")
					{
						value4 = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
						value5 = "NA";
					}
					else
					{
						string cmdText9 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
						SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9);
						if (dataSet9.Tables[0].Rows.Count > 0)
						{
							value5 = dataSet9.Tables[0].Rows[0]["Dept"].ToString();
							value4 = "NA";
						}
					}
					string cmdText10 = fun.select("AccHead.Symbol AS Head", "AccHead", "AccHead.Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]) + "' ");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						value6 = dataSet10.Tables[0].Rows[0]["Head"].ToString();
					}
				}
				dataRow[1] = value;
				dataRow[2] = value2;
				dataRow[3] = value3;
				dataRow[9] = value4;
				dataRow[10] = value5;
				dataRow[11] = value6;
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				string cmdText11 = fun.select("tblPacking_Master.Terms As PF", "tblPacking_Master", "tblPacking_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PF"]) + "' ");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter11.Fill(dataSet11);
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					dataRow[6] = dataSet11.Tables[0].Rows[0]["PF"].ToString();
				}
				string cmdText12 = fun.select("tblExciseser_Master.Terms As ExST", "tblExciseser_Master", "tblExciseser_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ExST"]) + "' ");
				SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
				SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter12.Fill(dataSet12);
				if (dataSet12.Tables[0].Rows.Count > 0)
				{
					dataRow[7] = dataSet12.Tables[0].Rows[0]["ExST"].ToString();
				}
				string cmdText13 = fun.select("tblVAT_Master.Terms As VAT", "tblVAT_Master", "tblVAT_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["VAT"]) + "' ");
				SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter13.Fill(dataSet13);
				if (dataSet13.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = dataSet13.Tables[0].Rows[0]["VAT"].ToString();
				}
				dataRow[12] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[13] = decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N3");
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadSPRData();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblPONo")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("PO_Edit_Details_PO_Select.aspx?mid=" + MId + "&pono=" + text + "&poid=" + text2 + "&Code=" + SupCode);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}

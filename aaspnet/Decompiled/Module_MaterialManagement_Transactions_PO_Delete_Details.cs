using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private string po = "";

	private string MId = "";

	private string CompId = "";

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SupCode = base.Request.QueryString["Code"].ToString();
			po = base.Request.QueryString["pono"];
			MId = base.Request.QueryString["mid"].ToString();
			CompId = Session["compid"].ToString();
			if (!base.IsPostBack)
			{
				LoadSPRData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableDelete()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		foreach (GridViewRow row in GridView2.Rows)
		{
			string text = ((Label)row.FindControl("lblId")).Text;
			string cmdText = fun.select("tblInv_Inward_Details.Id", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.PONo='" + po + "'  and tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo and tblInv_Inward_Details.POId='" + text + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.CompId='" + CompId + "'And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((LinkButton)row.FindControl("lnkButton")).Visible = false;
				((Label)row.FindControl("lblDel")).Visible = true;
			}
			else
			{
				((LinkButton)row.FindControl("lnkButton")).Visible = true;
				((Label)row.FindControl("lblDel")).Visible = false;
			}
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
			string cmdText = fun.select("tblMM_PO_Master.FinYearId,tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Master.PRSPRFlag", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + po + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + MId + "' AND tblMM_PO_Master.CompId='" + CompId + "'");
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
			dataTable.Columns.Add(new DataColumn("FinId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				string value = "";
				string value2 = "";
				string value3 = "";
				string text = "";
				string value4 = "";
				string value5 = "";
				if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.PRNo='" + dataSet.Tables[0].Rows[i]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + dataSet.Tables[0].Rows[i]["PRId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(Convert.ToInt32(CompId), Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"].ToString()));
						value2 = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						value3 = dataSet4.Tables[0].Rows[0][0].ToString();
					}
					text = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
					value4 = "NA";
					string cmdText5 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["AHId"]) + "' ");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					value5 = dataSet5.Tables[0].Rows[0]["Head"].ToString();
				}
				else if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[i]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[i]["SPRId"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(Convert.ToInt32(CompId), Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
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
						text = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
						value4 = "NA";
					}
					else
					{
						string cmdText9 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
						SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet9 = new DataSet();
						sqlDataAdapter9.Fill(dataSet9);
						value4 = dataSet9.Tables[0].Rows[0]["Dept"].ToString();
						text = "NA";
					}
					string cmdText10 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]) + "' ");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					value5 = dataSet10.Tables[0].Rows[0]["Head"].ToString();
				}
				dataRow[1] = value;
				dataRow[2] = value2;
				dataRow[3] = value3;
				if (text != "")
				{
					dataRow[9] = text;
				}
				else
				{
					dataRow[9] = "NA";
				}
				dataRow[10] = value4;
				dataRow[11] = value5;
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N3"));
				string cmdText11 = fun.select("tblPacking_Master.Terms As PF", "tblPacking_Master", "tblPacking_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PF"]) + "' ");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter11.Fill(dataSet11);
				dataRow[6] = dataSet11.Tables[0].Rows[0]["PF"].ToString();
				string cmdText12 = fun.select("tblExciseser_Master.Terms As ExST", "tblExciseser_Master", "tblExciseser_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ExST"]) + "' ");
				SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
				SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter12.Fill(dataSet12);
				dataRow[7] = dataSet12.Tables[0].Rows[0]["ExST"].ToString();
				string cmdText13 = fun.select("tblVAT_Master.Terms As VAT", "tblVAT_Master", "tblVAT_Master.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["VAT"]) + "' ");
				SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter13.Fill(dataSet13);
				dataRow[8] = dataSet13.Tables[0].Rows[0]["VAT"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[13] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
				dataRow[14] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			disableDelete();
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
		if (!(e.CommandName == "Del"))
		{
			return;
		}
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblpono")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
			string cmdText = fun.delete("tblMM_PO_Details", "PONo='" + text + "' And Id='" + text2 + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = fun.select("tblMM_PO_Details.Id", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + text + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + MId + "' AND tblMM_PO_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				string cmdText3 = fun.select("Id", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + text + "' AND FinYearId='" + text3 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				DataSet dataSet2 = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText4 = fun.delete("tblMM_PO_Amd_Details", "PONo='" + text + "' AND MId='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				string cmdText5 = fun.delete("tblMM_PO_Amd_Master", "CompId='" + CompId + "' AND PONo='" + text + "' AND FinYearId='" + text3 + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				string cmdText6 = fun.delete("tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + text + "' AND Id='" + MId + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
				sqlCommand4.ExecuteNonQuery();
				string cmdText7 = fun.delete("tblMM_Rate_Register", "CompId='" + CompId + "' AND FinYearId='" + text3 + "' AND POId='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "' AND PONo='" + text + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText7, sqlConnection);
				sqlCommand5.ExecuteNonQuery();
				base.Response.Redirect("PO_Delete.aspx?Code=" + SupCode + "&ModId=6&SubModId=35");
			}
			LoadSPRData();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_Delete.aspx?Code=" + SupCode + "&ModId=6&SubModId=35");
	}
}

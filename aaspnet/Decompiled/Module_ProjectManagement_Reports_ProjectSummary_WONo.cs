using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Reports_ProjectSummary_WONo : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnExport;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string sId = "";

	private int CompId;

	private string connStr = "";

	private int FinYearId;

	private int h;

	private SqlConnection con;

	private string WONo = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			WONo = Session["Wono"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				loaddata(h);
			}
		}
		catch (Exception)
		{
		}
	}

	public double AllComponentBOMQty(int CompId, string wono, int finId, int ItemId)
	{
		double num = 0.0;
		string cmdText = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId", "tblDG_BOM_Master", " tblDG_BOM_Master.ItemId='" + ItemId + "'  And  tblDG_BOM_Master.WONo='" + wono + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + finId + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, con);
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.Default);
		while (sqlDataReader.Read())
		{
			num += fun.BOMRecurQty(wono, Convert.ToInt32(sqlDataReader["PId"]), Convert.ToInt32(sqlDataReader["CId"]), 1.0, CompId, finId);
		}
		return Math.Round(num, 5);
	}

	public void loaddata(int c)
	{
		try
		{
			string[] array = WONo.Split(',');
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaskProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BOM_MFG_Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("WISQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("WISMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POBQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POMQtyF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POMQtyA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POMQtyO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GRRBQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GRRMQtyF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GRRMQtyA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GRRMQtyO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GRRQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNMQtyF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNMQtyA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNMQtyO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GQNMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejBQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejQtyF", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejQtyA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejQtyO", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RejMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ShortBQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ShortMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("QABQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("QAMQty", typeof(double)));
			for (int i = 0; i < array.Length - 1; i++)
			{
				string cmdText = "SELECT SD_Cust_WorkOrder_Master.WONo, tblDG_Item_Master.UOMBasic, Unit_Master.Symbol, SD_Cust_WorkOrder_Master.CustomerId, SD_Cust_WorkOrder_Master.TaskProjectTitle,SD_Cust_master.CustomerName FROM tblDG_BOM_Master INNER JOIN tblDG_Item_Master ON tblDG_BOM_Master.ItemId = tblDG_Item_Master.Id INNER JOIN SD_Cust_WorkOrder_Master ON tblDG_BOM_Master.WONo = SD_Cust_WorkOrder_Master.WONo INNER JOIN      SD_Cust_master ON SD_Cust_WorkOrder_Master.CustomerId = SD_Cust_master.CustomerId INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id WHERE SD_Cust_WorkOrder_Master.FinYearId<='" + FinYearId + "' And SD_Cust_WorkOrder_Master.CompId='" + CompId + "' AND CloseOpen='0'And SD_Cust_WorkOrder_Master.WONo='" + array[i].ToString() + "' GROUP BY tblDG_Item_Master.UOMBasic, SD_Cust_WorkOrder_Master.WONo,SD_Cust_WorkOrder_Master.CustomerId, SD_Cust_WorkOrder_Master.TaskProjectTitle,SD_Cust_master.CustomerName,Unit_Master.Symbol order by SD_Cust_WorkOrder_Master.WONo Asc";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[4] = sqlDataReader["Symbol"].ToString();
					dataRow[0] = sqlDataReader["WONo"].ToString();
					dataRow[3] = sqlDataReader["CustomerId"].ToString();
					dataRow[1] = sqlDataReader["TaskProjectTitle"].ToString();
					dataRow[2] = sqlDataReader["CustomerName"].ToString();
					double num = 0.0;
					string cmdText2 = string.Concat("SELECT Distinct(ItemId)from tblDG_BOM_Master,tblDG_Item_Master where tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And  WONo='", sqlDataReader["WONo"].ToString(), "'And  tblDG_Item_Master.CId is Not Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						if (sqlDataReader2.HasRows)
						{
							num += Convert.ToDouble(AllComponentBOMQty(CompId, sqlDataReader["WONo"].ToString(), FinYearId, Convert.ToInt32(sqlDataReader2["ItemId"])));
						}
					}
					dataRow[5] = num;
					double num2 = 0.0;
					string cmdText3 = string.Concat("SELECT Distinct(ItemId)from tblDG_BOM_Master,tblDG_Item_Master where tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And  WONo='", sqlDataReader["WONo"].ToString(), "'And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "'     And tblDG_BOM_Master.CId not in (Select tblDG_BOM_Master.PId from tblDG_BOM_Master where tblDG_BOM_Master.WONo='", sqlDataReader["WONo"].ToString(), "'and  tblDG_BOM_Master.CompId='", CompId, "')  ");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					while (sqlDataReader3.Read())
					{
						if (sqlDataReader3.HasRows)
						{
							num2 += Convert.ToDouble(AllComponentBOMQty(CompId, sqlDataReader["WONo"].ToString(), FinYearId, Convert.ToInt32(sqlDataReader3["ItemId"])));
						}
					}
					dataRow[6] = num2;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					string cmdText4 = string.Concat("SELECT sum(tblMM_PO_Details.Qty) As PRQty FROM  tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN  tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is Not Null  And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' And tblMM_PR_Master.WONo='", sqlDataReader["WONo"].ToString(), "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					if (sqlDataReader4["PRQty"] != DBNull.Value)
					{
						num4 = Convert.ToDouble(sqlDataReader4["PRQty"]);
					}
					num5 = num4 + num3;
					dataRow[9] = num5;
					double num6 = 0.0;
					string cmdText5 = string.Concat(" SELECT SUM(tblMM_PO_Details.Qty) AS POQty FROM         tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN   tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN   tblMM_PO_Master INNER JOIN  tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN   tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN                      tblMP_Material_RawMaterial ON tblMM_PR_Details.ItemId = tblMP_Material_RawMaterial.ItemId AND tblDG_Item_Master.CId IS NULL AND               tblDG_Item_Master.UOMBasic = '", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  ON tblMP_Material_Master.Id = tblMM_PR_Master.PLNId AND   tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5["POQty"] != DBNull.Value)
					{
						num6 = Convert.ToDouble(sqlDataReader5["POQty"]);
					}
					dataRow[11] = num6;
					double num7 = 0.0;
					string cmdText6 = string.Concat("SELECT  Sum(tblMM_PO_Details.Qty) As POQty  FROM tblMM_PR_Details INNER JOIN tblMM_PR_Master ON tblMM_PR_Details.MId = tblMM_PR_Master.Id INNER JOIN     tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid ON tblMM_PR_Master.PLNId = tblMP_Material_Master.Id AND tblMM_PR_Details.ItemId = tblMP_Material_Finish.ItemId INNER JOIN tblMM_PO_Details ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN     tblMM_PO_Master ON tblMM_PO_Details.MId = tblMM_PO_Master.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And tblDG_Item_Master.CId is  Null  And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "'   AND tblMP_Material_Master.WONo ='", sqlDataReader["WONo"].ToString(), "' ");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					if (sqlDataReader6["POQty"] != DBNull.Value)
					{
						num7 = Convert.ToDouble(sqlDataReader6["POQty"]);
					}
					dataRow[10] = num7;
					double num8 = 0.0;
					string cmdText7 = string.Concat("SELECT SUM(tblMM_PO_Details.Qty) AS POQty FROM  tblMP_Material_Master INNER JOIN       tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN  tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_Process ON tblMM_PR_Details.ItemId = tblMP_Material_Process.ItemId AND tblDG_Item_Master.CId IS NULL AND tblDG_Item_Master.UOMBasic = '", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid AND    tblMP_Material_Master.Id = tblMM_PR_Master.PLNId");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
					SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
					sqlDataReader7.Read();
					if (sqlDataReader7["POQty"] != DBNull.Value)
					{
						num8 = Convert.ToDouble(sqlDataReader7["POQty"]);
					}
					dataRow[12] = num8 + num7;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					string cmdText8 = string.Concat("SELECT sum(tblMM_PO_Details.Qty) As PRQty FROM  tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN  tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is  Null  And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' And tblMM_PR_Master.WONo='", sqlDataReader["WONo"].ToString(), "'");
					SqlCommand sqlCommand8 = new SqlCommand(cmdText8, con);
					SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
					sqlDataReader8.Read();
					if (sqlDataReader8["PRQty"] != DBNull.Value)
					{
						num10 = Convert.ToDouble(sqlDataReader8["PRQty"]);
					}
					num11 = num10 + num9;
					dataRow[13] = num11;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					string cmdText9 = string.Concat("SELECT SUM(tblinv_MaterialReceived_Details.ReceivedQty) AS GRRQty FROM tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is not Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId  ");
					SqlCommand sqlCommand9 = new SqlCommand(cmdText9, con);
					SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
					sqlDataReader9.Read();
					if (sqlDataReader9["GRRQty"] != DBNull.Value)
					{
						num12 = Convert.ToDouble(sqlDataReader9["GRRQty"]);
					}
					num14 = num12 + num13;
					dataRow[14] = num14;
					double num15 = 0.0;
					string cmdText10 = string.Concat("SELECT SUM(tblinv_MaterialReceived_Details.ReceivedQty) AS Qty FROM tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_RawMaterial ON tblMM_PR_Details.ItemId = tblMP_Material_RawMaterial.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ");
					SqlCommand sqlCommand10 = new SqlCommand(cmdText10, con);
					SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
					sqlDataReader10.Read();
					if (sqlDataReader10["Qty"] != DBNull.Value)
					{
						num15 = Convert.ToDouble(sqlDataReader10["Qty"]);
					}
					dataRow[16] = num15;
					double num16 = 0.0;
					string cmdText11 = string.Concat("SELECT SUM(tblinv_MaterialReceived_Details.ReceivedQty) AS Qty FROM   tblMP_Material_Master INNER JOIN       tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_Process ON tblMM_PR_Details.ItemId = tblMP_Material_Process.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId  ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid AND                 tblMP_Material_Master.Id = tblMM_PR_Master.PLNId ");
					SqlCommand sqlCommand11 = new SqlCommand(cmdText11, con);
					SqlDataReader sqlDataReader11 = sqlCommand11.ExecuteReader();
					sqlDataReader11.Read();
					if (sqlDataReader11["Qty"] != DBNull.Value)
					{
						num16 = Convert.ToDouble(sqlDataReader11["Qty"]);
					}
					dataRow[17] = num16;
					double num17 = 0.0;
					string cmdText12 = string.Concat("SELECT SUM(tblinv_MaterialReceived_Details.ReceivedQty) AS Qty FROM  tblMP_Material_Master INNER JOIN       tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_Finish ON tblMM_PR_Details.ItemId = tblMP_Material_Finish.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId   ON  tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND                 tblMP_Material_Master.Id = tblMM_PR_Master.PLNId ");
					SqlCommand sqlCommand12 = new SqlCommand(cmdText12, con);
					SqlDataReader sqlDataReader12 = sqlCommand12.ExecuteReader();
					sqlDataReader12.Read();
					if (sqlDataReader12["Qty"] != DBNull.Value)
					{
						num17 = Convert.ToDouble(sqlDataReader12["Qty"]);
					}
					dataRow[15] = num17;
					double num18 = 0.0;
					double num19 = 0.0;
					double num20 = 0.0;
					string cmdText13 = string.Concat("SELECT SUM(tblinv_MaterialReceived_Details.ReceivedQty) AS GRRQty FROM tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId = tblinv_MaterialReceived_Master.Id INNER JOIN tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo = '", sqlDataReader["WONo"].ToString(), "' AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ");
					SqlCommand sqlCommand13 = new SqlCommand(cmdText13, con);
					SqlDataReader sqlDataReader13 = sqlCommand13.ExecuteReader();
					sqlDataReader13.Read();
					if (sqlDataReader13["GRRQty"] != DBNull.Value)
					{
						num18 = Convert.ToDouble(sqlDataReader13["GRRQty"]);
					}
					num20 = num18 + num19;
					dataRow[18] = num20;
					double num21 = 0.0;
					double num22 = 0.0;
					double num23 = 0.0;
					double num24 = 0.0;
					double num25 = 0.0;
					double num26 = 0.0;
					string cmdText14 = string.Concat("SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty) AS GQNQty,SUM(tblQc_MaterialQuality_Details.RejectedQty) As RejectedQty  FROM tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN tblinv_MaterialReceived_Details INNER JOIN    tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId= tblinv_MaterialReceived_Master.Id INNER JOIN   tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN  tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is not Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON  tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON   tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id ");
					SqlCommand sqlCommand14 = new SqlCommand(cmdText14, con);
					SqlDataReader sqlDataReader14 = sqlCommand14.ExecuteReader();
					sqlDataReader14.Read();
					if (sqlDataReader14["RejectedQty"] != DBNull.Value)
					{
						num24 = Convert.ToDouble(sqlDataReader14["RejectedQty"]);
					}
					if (sqlDataReader14["GQNQty"] != DBNull.Value)
					{
						num21 = Convert.ToDouble(sqlDataReader14["GQNQty"]);
					}
					num23 = num21 + num22;
					num26 = num24 + num25;
					dataRow[19] = num23;
					double num27 = 0.0;
					double num28 = 0.0;
					double num29 = 0.0;
					double num30 = 0.0;
					double num31 = 0.0;
					double num32 = 0.0;
					string cmdText15 = string.Concat("SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty) AS GQNQty,SUM(tblQc_MaterialQuality_Details.RejectedQty) As RejectedQty FROM tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN tblinv_MaterialReceived_Details INNER JOIN    tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId= tblinv_MaterialReceived_Master.Id INNER JOIN   tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN  tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON  tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON   tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id ");
					SqlCommand sqlCommand15 = new SqlCommand(cmdText15, con);
					SqlDataReader sqlDataReader15 = sqlCommand15.ExecuteReader();
					sqlDataReader15.Read();
					if (sqlDataReader15["GQNQty"] != DBNull.Value)
					{
						num27 = Convert.ToDouble(sqlDataReader15["GQNQty"]);
					}
					if (sqlDataReader15["RejectedQty"] != DBNull.Value)
					{
						num30 = Convert.ToDouble(sqlDataReader15["RejectedQty"]);
					}
					num32 = num30 + num31;
					num29 = num27 + num28;
					double num33 = 0.0;
					double num34 = 0.0;
					string cmdText16 = string.Concat("SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty) AS Qty,   SUM(tblQc_MaterialQuality_Details.RejectedQty) As RejectedQty FROM  tblMP_Material_Master INNER JOIN  tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId= tblinv_MaterialReceived_Master.Id INNER JOIN   tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN  tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_RawMaterial ON tblMM_PR_Details.ItemId = tblMP_Material_RawMaterial.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON  tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id  ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid AND     tblMP_Material_Master.Id = tblMM_PR_Master.PLNId  ");
					SqlCommand sqlCommand16 = new SqlCommand(cmdText16, con);
					SqlDataReader sqlDataReader16 = sqlCommand16.ExecuteReader();
					sqlDataReader16.Read();
					if (sqlDataReader16["Qty"] != DBNull.Value)
					{
						num33 = Convert.ToDouble(sqlDataReader16["Qty"]);
					}
					if (sqlDataReader16["RejectedQty"] != DBNull.Value)
					{
						num34 = Convert.ToDouble(sqlDataReader16["RejectedQty"]);
					}
					dataRow[21] = num33;
					dataRow[26] = num34;
					double num35 = 0.0;
					double num36 = 0.0;
					string cmdText17 = string.Concat("SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty) AS Qty,SUM(tblQc_MaterialQuality_Details.RejectedQty) As RejectedQty FROM   tblMP_Material_Master INNER JOIN  tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId= tblinv_MaterialReceived_Master.Id INNER JOIN   tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN  tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_Process ON tblMM_PR_Details.ItemId = tblMP_Material_Process.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON  tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id   ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid AND     tblMP_Material_Master.Id = tblMM_PR_Master.PLNId  ");
					SqlCommand sqlCommand17 = new SqlCommand(cmdText17, con);
					SqlDataReader sqlDataReader17 = sqlCommand17.ExecuteReader();
					sqlDataReader17.Read();
					if (sqlDataReader17["Qty"] != DBNull.Value)
					{
						num35 = Convert.ToDouble(sqlDataReader17["Qty"]);
					}
					if (sqlDataReader17["RejectedQty"] != DBNull.Value)
					{
						num36 = Convert.ToDouble(sqlDataReader17["RejectedQty"]);
					}
					dataRow[27] = num36;
					dataRow[22] = num35;
					double num37 = 0.0;
					double num38 = 0.0;
					string cmdText18 = string.Concat("SELECT SUM(tblQc_MaterialQuality_Details.AcceptedQty) AS Qty,SUM(tblQc_MaterialQuality_Details.RejectedQty) As RejectedQty FROM  tblMP_Material_Master INNER JOIN  tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN   tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN tblinv_MaterialReceived_Details INNER JOIN tblinv_MaterialReceived_Master ON tblinv_MaterialReceived_Details.MId= tblinv_MaterialReceived_Master.Id INNER JOIN   tblInv_Inward_Details INNER JOIN tblInv_Inward_Master ON tblInv_Inward_Details.GINId = tblInv_Inward_Master.Id INNER JOIN  tblMM_PR_Master INNER JOIN  tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId INNER JOIN  tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId ON tblMM_PR_Details.Id = tblMM_PO_Details.PRId ON tblInv_Inward_Details.POId = tblMM_PO_Details.Id  INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblMM_PR_Details.ItemId INNER JOIN tblMP_Material_Finish ON tblMM_PR_Details.ItemId = tblMP_Material_Finish.ItemId And  tblDG_Item_Master.CId is Null And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "' AND tblMM_PR_Master.WONo ='", sqlDataReader["WONo"].ToString(), "'  AND tblInv_Inward_Master.PONo = tblMM_PO_Master.PONo ON  tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND     tblMP_Material_Master.Id = tblMM_PR_Master.PLNId  ");
					SqlCommand sqlCommand18 = new SqlCommand(cmdText18, con);
					SqlDataReader sqlDataReader18 = sqlCommand18.ExecuteReader();
					sqlDataReader18.Read();
					if (sqlDataReader18["Qty"] != DBNull.Value)
					{
						num37 = Convert.ToDouble(sqlDataReader18["Qty"]);
					}
					if (sqlDataReader18["RejectedQty"] != DBNull.Value)
					{
						num38 = Convert.ToDouble(sqlDataReader18["RejectedQty"]);
					}
					dataRow[25] = num38;
					dataRow[20] = num37;
					dataRow[23] = num29;
					dataRow[24] = num26;
					dataRow[28] = num32;
					double num39 = 0.0;
					string cmdText19 = string.Concat("SELECT Sum(tblInv_WIS_Details.IssuedQty) As WISQty FROM  tblInv_WIS_Master INNER JOIN                       tblInv_WIS_Details ON tblInv_WIS_Master.Id = tblInv_WIS_Details.MId INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblInv_WIS_Details.ItemId And  tblDG_Item_Master.CId is Not Null   And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "'  And tblInv_WIS_Master.WONo='", sqlDataReader["WONo"].ToString(), "'");
					SqlCommand sqlCommand19 = new SqlCommand(cmdText19, con);
					SqlDataReader sqlDataReader19 = sqlCommand19.ExecuteReader();
					sqlDataReader19.Read();
					if (sqlDataReader19["WISQty"] != DBNull.Value)
					{
						num39 = Convert.ToDouble(sqlDataReader19["WISQty"]);
					}
					dataRow[7] = num39;
					double num40 = 0.0;
					string cmdText20 = string.Concat("SELECT Sum(tblInv_WIS_Details.IssuedQty) As WISQty FROM  tblInv_WIS_Master INNER JOIN                       tblInv_WIS_Details ON tblInv_WIS_Master.Id = tblInv_WIS_Details.MId INNER JOIN  tblDG_Item_Master ON tblDG_Item_Master.Id = tblInv_WIS_Details.ItemId And  tblDG_Item_Master.CId is Null   And tblDG_Item_Master.UOMBasic='", sqlDataReader["UOMBasic"], "'  And tblInv_WIS_Master.WONo='", sqlDataReader["WONo"].ToString(), "'");
					SqlCommand sqlCommand20 = new SqlCommand(cmdText20, con);
					SqlDataReader sqlDataReader20 = sqlCommand20.ExecuteReader();
					sqlDataReader20.Read();
					if (sqlDataReader20["WISQty"] != DBNull.Value)
					{
						num40 = Convert.ToDouble(sqlDataReader20["WISQty"]);
					}
					dataRow[8] = num40;
					dataRow[29] = Math.Round(num - num39, 3);
					dataRow[30] = Math.Round(num2 - num40, 3);
					dataRow[31] = Math.Round(num14 - (num23 + num26), 3);
					dataRow[32] = Math.Round(num20 - (num29 + num32), 3);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			ViewState["dtList"] = dataTable;
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		loaddata(h);
	}

	protected void btnExpor_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
			dataTable.Columns[0].ColumnName = "WO No";
			dataTable.Columns[1].ColumnName = "Project Title";
			dataTable.Columns[2].ColumnName = "Customer Name";
			dataTable.Columns[3].ColumnName = "Customer Code";
			dataTable.Columns[4].ColumnName = "UOM";
			dataTable.Columns[5].ColumnName = "BOM [B]";
			dataTable.Columns[6].ColumnName = "BOM [M]";
			dataTable.Columns[7].ColumnName = "WIS [B]";
			dataTable.Columns[8].ColumnName = "WIS [M]";
			dataTable.Columns[9].ColumnName = "PO [B]";
			dataTable.Columns[10].ColumnName = "PO [F]";
			dataTable.Columns[11].ColumnName = "PO [A]";
			dataTable.Columns[12].ColumnName = "PO [O]";
			dataTable.Columns[13].ColumnName = "PO [M]";
			dataTable.Columns[14].ColumnName = "GRR [B]";
			dataTable.Columns[15].ColumnName = "GRR [F]";
			dataTable.Columns[16].ColumnName = "GRR [A]";
			dataTable.Columns[17].ColumnName = "GRR [O]";
			dataTable.Columns[18].ColumnName = "GRR [M]";
			dataTable.Columns[19].ColumnName = "GQN [B]";
			dataTable.Columns[20].ColumnName = "GQN [F]";
			dataTable.Columns[21].ColumnName = "GQN [A]";
			dataTable.Columns[22].ColumnName = "GQN [O]";
			dataTable.Columns[23].ColumnName = "GQN [M]";
			dataTable.Columns[24].ColumnName = "Rej [B]";
			dataTable.Columns[25].ColumnName = "Rej [F]";
			dataTable.Columns[26].ColumnName = "Rej [A]";
			dataTable.Columns[27].ColumnName = "Rej [O]";
			dataTable.Columns[28].ColumnName = "Rej [M]";
			dataTable.Columns[29].ColumnName = "Short [B]";
			dataTable.Columns[30].ColumnName = "Short [M]";
			dataTable.Columns[31].ColumnName = "QA [B]";
			dataTable.Columns[32].ColumnName = "QA [M]";
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			string text = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".xls";
			FileInfo fileInfo = new FileInfo(text);
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			DataGrid dataGrid = new DataGrid();
			dataGrid.DataSource = dataTable;
			dataGrid.DataBind();
			dataGrid.RenderControl(writer);
			string path = text.Substring(0, text.LastIndexOf("\\"));
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			StreamWriter streamWriter = new StreamWriter(text, append: true);
			stringWriter.ToString().Normalize();
			streamWriter.Write(stringWriter.ToString());
			streamWriter.Flush();
			streamWriter.Close();
			WriteAttachment(fileInfo.Name, "application/vnd.ms-excel", stringWriter.ToString());
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	public static void WriteAttachment(string FileName, string FileType, string content)
	{
		try
		{
			HttpResponse response = HttpContext.Current.Response;
			response.ClearHeaders();
			response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
			response.ContentType = FileType;
			response.Write(content);
			response.End();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCance_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProjectSummary.aspx?ModId=7");
	}

	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.Header)
			{
				_ = (GridView)sender;
				GridViewRow gridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
				TableCell tableCell = new TableCell();
				tableCell.Text = " ";
				tableCell.ColumnSpan = 6;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				gridViewRow.BackColor = Color.LightGray;
				tableCell.BackColor = Color.White;
				tableCell = new TableCell();
				tableCell.Text = "BOM Qty";
				tableCell.ColumnSpan = 2;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "WIS Qty";
				tableCell.ColumnSpan = 2;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "Short Qty";
				tableCell.ColumnSpan = 2;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "PO Qty";
				tableCell.ColumnSpan = 4;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "GRR Qty";
				tableCell.ColumnSpan = 4;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "GQN Qty";
				tableCell.ColumnSpan = 4;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "Rej Qty";
				tableCell.ColumnSpan = 4;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				tableCell = new TableCell();
				tableCell.Text = "QA Qty";
				tableCell.ColumnSpan = 2;
				tableCell.Font.Bold = true;
				tableCell.HorizontalAlign = HorizontalAlign.Center;
				gridViewRow.Cells.Add(tableCell);
				GridView1.Controls[0].Controls.AddAt(0, gridViewRow);
			}
		}
		catch (Exception)
		{
		}
	}
}

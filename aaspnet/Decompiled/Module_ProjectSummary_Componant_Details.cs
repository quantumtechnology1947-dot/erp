using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_ProjectSummary_Componant_Details : Page, IRequiresSessionState
{
	protected Label Label2;

	protected Button btnCancel;

	protected RadTreeList RadTreeList1;

	protected Panel Panel1;

	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	public int ItemId;

	public string wonosrc = "";

	public string wonodest = "";

	private int CompId;

	private string sId = "";

	private int FinYearId;

	private DataTable DT = new DataTable();

	private DataRow DR;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONO"]))
			{
				wonosrc = base.Request.QueryString["WONO"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["PID"]))
			{
				pid = Convert.ToInt32(base.Request.QueryString["PID"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["CID"]))
			{
				cid = Convert.ToInt32(base.Request.QueryString["CID"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Id"]))
			{
				ItemId = Convert.ToInt32(base.Request.QueryString["Id"]);
			}
			Label2.Text = wonosrc;
			if (!Page.IsPostBack)
			{
				getColoumn();
				RadTreeList1.DataSource = getPrintnode(cid, wonosrc, CompId);
				RadTreeList1.DataBind();
				RadTreeList1.ExpandAllItems();
				DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	public void getColoumn()
	{
		DT.Columns.Add("PId", typeof(int));
		DT.Columns.Add("CId", typeof(int));
		DT.Columns.Add("ItemId", typeof(int));
		DT.Columns.Add(new DataColumn("WONo", typeof(string)));
		DT.Columns.Add(new DataColumn("ItemCode", typeof(string)));
		DT.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
		DT.Columns.Add(new DataColumn("UOM", typeof(string)));
		DT.Columns.Add(new DataColumn("UnitQty", typeof(double)));
		DT.Columns.Add(new DataColumn("BOMQty", typeof(string)));
		DT.Columns.Add(new DataColumn("Weld", typeof(string)));
		DT.Columns.Add(new DataColumn("LH", typeof(string)));
		DT.Columns.Add(new DataColumn("RH", typeof(string)));
		DT.Columns.Add(new DataColumn("PLNo", typeof(string)));
		DT.Columns.Add(new DataColumn("PLDate", typeof(string)));
		DT.Columns.Add(new DataColumn("PLGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("PLId", typeof(string)));
		DT.Columns.Add(new DataColumn("PRNo", typeof(string)));
		DT.Columns.Add(new DataColumn("PRDate", typeof(string)));
		DT.Columns.Add(new DataColumn("PRGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("PRSupplier", typeof(string)));
		DT.Columns.Add(new DataColumn("PRQty", typeof(string)));
		DT.Columns.Add(new DataColumn("PRId", typeof(string)));
		DT.Columns.Add(new DataColumn("PONo", typeof(string)));
		DT.Columns.Add(new DataColumn("PODate", typeof(string)));
		DT.Columns.Add(new DataColumn("POGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("POSupplier", typeof(string)));
		DT.Columns.Add(new DataColumn("POQty", typeof(string)));
		DT.Columns.Add(new DataColumn("POId", typeof(string)));
		DT.Columns.Add(new DataColumn("POCheckDt", typeof(string)));
		DT.Columns.Add(new DataColumn("POApproveDt", typeof(string)));
		DT.Columns.Add(new DataColumn("POAuthDt", typeof(string)));
		DT.Columns.Add(new DataColumn("GINNo", typeof(string)));
		DT.Columns.Add(new DataColumn("GINDate", typeof(string)));
		DT.Columns.Add(new DataColumn("GINGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("GINQty", typeof(string)));
		DT.Columns.Add(new DataColumn("GINId", typeof(string)));
		DT.Columns.Add(new DataColumn("GRRNo", typeof(string)));
		DT.Columns.Add(new DataColumn("GRRDate", typeof(string)));
		DT.Columns.Add(new DataColumn("GRRGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("GRRQty", typeof(string)));
		DT.Columns.Add(new DataColumn("GRRId", typeof(string)));
		DT.Columns.Add(new DataColumn("GQNNo", typeof(string)));
		DT.Columns.Add(new DataColumn("GQNDate", typeof(string)));
		DT.Columns.Add(new DataColumn("GQNGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("GQNQty", typeof(string)));
		DT.Columns.Add(new DataColumn("GQNId", typeof(string)));
		DT.Columns.Add(new DataColumn("GSNNo", typeof(string)));
		DT.Columns.Add(new DataColumn("GSNDate", typeof(string)));
		DT.Columns.Add(new DataColumn("GSNGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("GSNQty", typeof(string)));
		DT.Columns.Add(new DataColumn("GSNId", typeof(string)));
		DT.Columns.Add(new DataColumn("WISNo", typeof(string)));
		DT.Columns.Add(new DataColumn("WISDate", typeof(string)));
		DT.Columns.Add(new DataColumn("WISGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("WISQty", typeof(string)));
		DT.Columns.Add(new DataColumn("ShortageQty", typeof(double)));
		DT.Columns.Add(new DataColumn("Progress", typeof(string)));
		DT.Columns.Add(new DataColumn("MINNo", typeof(string)));
		DT.Columns.Add(new DataColumn("MINDate", typeof(string)));
		DT.Columns.Add(new DataColumn("MINGenBy", typeof(string)));
		DT.Columns.Add(new DataColumn("MINQty", typeof(string)));
	}

	public DataTable getPrintnode(int node, string wono, int compid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			new DataSet();
			sqlConnection.Open();
			string cmdText = fun.select("tblDG_BOM_Master.ItemId,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.Weldments,tblDG_BOM_Master.LH,tblDG_BOM_Master.RH,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.CId='" + node + "' And tblDG_BOM_Master.WONo='" + wonosrc + "'And tblDG_BOM_Master.CompId='" + CompId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DR = DT.NewRow();
			DR[0] = dataSet.Tables[0].Rows[0]["PId"].ToString();
			DR[1] = dataSet.Tables[0].Rows[0]["CId"].ToString();
			DR[2] = dataSet.Tables[0].Rows[0]["ItemId"].ToString();
			DR[3] = wono;
			DR[4] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
			DR[5] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
			DR[6] = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
			DR[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
			DR[8] = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), node, 1.0, CompId, FinYearId).ToString()).ToString("N3"));
			DR[9] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Weldments"]);
			DR[10] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LH"]);
			DR[11] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RH"]);
			string cmdText2 = fun.select("tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SessionId ,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", " tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialRequisition_Details.ItemId='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.WONo='" + wono + "'   ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			double num = 0.0;
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				string cmdText3 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet2.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				DataRow dR;
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					(dR = DR)[59] = string.Concat(dR[59], dataSet3.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
				}
				(dR = DR)[57] = string.Concat(dR[57], dataSet2.Tables[0].Rows[i]["MINNo"].ToString(), "<br>");
				(dR = DR)[58] = string.Concat(dR[58], fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["SysDate"].ToString()), "<br>");
				(dR = DR)[60] = string.Concat(dR[60], dataSet2.Tables[0].Rows[i]["IssueQty"].ToString(), "<br>");
				num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["IssueQty"].ToString()).ToString("N3"));
			}
			double num2 = 0.0;
			double num3 = 0.0;
			num3 = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), node, 1.0, CompId, FinYearId).ToString()).ToString("N3"));
			double num4 = 0.0;
			string cmdText4 = fun.select("sum(tblInv_WIS_Details.IssuedQty) as sum_IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.Id=tblInv_WIS_Details.MId AND tblInv_WIS_Master.WONo='" + wonosrc + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Details.ItemId='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "' AND tblInv_WIS_Details.PId='" + dataSet.Tables[0].Rows[0]["PId"].ToString() + "' AND tblInv_WIS_Details.CId='" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "'");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet4.Tables[0].Rows.Count > 0)
			{
				num4 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0][0].ToString()).ToString("N3"));
			}
			num2 = num3 - (num4 + num);
			DR[55] = num2;
			double num5 = 0.0;
			num5 = Math.Round((num4 + num) * 100.0 / num3, 2);
			DR[56] = num5;
			string cmdText5 = fun.select("tblInv_WIS_Details.IssuedQty,tblInv_WIS_Master.SessionId,tblInv_WIS_Master.SysDate,tblInv_WIS_Details.WISNo,tblInv_WIS_Master.Id", "tblInv_WIS_Details,tblInv_WIS_Master", " tblInv_WIS_Details.ItemId='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "' AND tblInv_WIS_Master.WONo='" + wonosrc + "' AND tblInv_WIS_Details.PId='" + dataSet.Tables[0].Rows[0]["PId"].ToString() + "' And tblInv_WIS_Details.CId='" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "' and tblInv_WIS_Master.CompId='" + CompId + "' And tblInv_WIS_Details.MId=tblInv_WIS_Master.Id ");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			for (int j = 0; j < dataSet5.Tables[0].Rows.Count; j++)
			{
				string cmdText6 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet5.Tables[0].Rows[j]["SessionId"], "'"));
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				DataRow dR;
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					(dR = DR)[53] = string.Concat(dR[53], dataSet6.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
				}
				(dR = DR)[51] = string.Concat(dR[51], dataSet5.Tables[0].Rows[j]["WISNo"].ToString(), "<br>");
				(dR = DR)[52] = string.Concat(dR[52], fun.FromDateDMY(dataSet5.Tables[0].Rows[j]["SysDate"].ToString()), "<br>");
				(dR = DR)[54] = string.Concat(dR[54], Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[j]["IssuedQty"].ToString()).ToString("N3")), "<br>");
			}
			string cmdText7 = fun.select("Id,SysDate,PLNo,SessionId,SupplierId,CompDate,ItemId,Type", "tblMP_Material_Master", "ItemId='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "'AND CompId='" + CompId + "' AND PId='" + pid + "' AND CId='" + cid + "'");
			SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
			DataSet dataSet7 = new DataSet();
			sqlDataAdapter7.Fill(dataSet7);
			for (int k = 0; k < dataSet7.Tables[0].Rows.Count; k++)
			{
				if (dataSet7.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText8 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet7.Tables[0].Rows[k]["SessionId"], "'"));
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				DataRow dR;
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					(dR = DR)[14] = string.Concat(dR[14], dataSet8.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
				}
				(dR = DR)[12] = string.Concat(dR[12], dataSet7.Tables[0].Rows[k]["PLNo"].ToString(), "<br>");
				(dR = DR)[13] = string.Concat(dR[13], fun.FromDateDMY(dataSet7.Tables[0].Rows[k]["SysDate"].ToString()), "<br>");
				(dR = DR)[15] = string.Concat(dR[15], dataSet7.Tables[0].Rows[k]["Id"].ToString(), "<br>");
				string cmdText9 = fun.select("tblMM_PR_Details.Qty,tblMM_PR_Details.SupplierId,tblMM_PR_Master.PRNo,tblMM_PR_Details.Id,tblMM_PR_Master.SysDate,tblMM_PR_Master.SessionId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.ItemId='" + dataSet7.Tables[0].Rows[k]["ItemId"].ToString() + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.WONo='" + wonosrc + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.PId='" + pid + "' AND tblMM_PR_Details.CId='" + cid + "'");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				for (int l = 0; l < dataSet9.Tables[0].Rows.Count; l++)
				{
					if (dataSet9.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					string cmdText10 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet9.Tables[0].Rows[l]["SessionId"], "'"));
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						(dR = DR)[18] = string.Concat(dR[18], dataSet10.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
					}
					(dR = DR)[16] = string.Concat(dR[16], dataSet9.Tables[0].Rows[l]["PRNo"].ToString(), "<br>");
					(dR = DR)[17] = string.Concat(dR[17], fun.FromDateDMY(dataSet9.Tables[0].Rows[l]["SysDate"].ToString()), "<br>");
					string cmdText11 = fun.select("SupplierName", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' AND SupplierId='", dataSet9.Tables[0].Rows[l]["SupplierId"], "'"));
					SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter11.Fill(dataSet11);
					if (dataSet11.Tables[0].Rows.Count > 0)
					{
						(dR = DR)[19] = string.Concat(dR[19], dataSet11.Tables[0].Rows[l]["SupplierName"].ToString(), "<br>");
					}
					(dR = DR)[20] = string.Concat(dR[20], dataSet9.Tables[0].Rows[l]["Qty"].ToString(), "<br>");
					(dR = DR)[21] = string.Concat(dR[21], dataSet9.Tables[0].Rows[l]["Id"].ToString(), "<br>");
					string cmdText12 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.Qty,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Master.SupplierId,tblMM_PO_Master.SessionId,tblMM_PO_Master.CheckedDate,tblMM_PO_Master.ApproveDate,tblMM_PO_Master.AuthorizeDate", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.PRId='" + dataSet9.Tables[0].Rows[l]["Id"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
					SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter12.Fill(dataSet12);
					for (int m = 0; m < dataSet12.Tables[0].Rows.Count; m++)
					{
						if (dataSet12.Tables[0].Rows.Count <= 0)
						{
							continue;
						}
						string cmdText13 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet12.Tables[0].Rows[m]["SessionId"], "'"));
						SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
						SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
						DataSet dataSet13 = new DataSet();
						sqlDataAdapter13.Fill(dataSet13);
						if (dataSet13.Tables[0].Rows.Count > 0)
						{
							(dR = DR)[24] = string.Concat(dR[24], dataSet13.Tables[0].Rows[m]["EmpLoyeeName"].ToString(), "<br>");
						}
						(dR = DR)[22] = string.Concat(dR[22], dataSet12.Tables[0].Rows[m]["PONo"].ToString(), "<br>");
						(dR = DR)[23] = string.Concat(dR[23], fun.FromDateDMY(dataSet12.Tables[0].Rows[m]["SysDate"].ToString()), "<br>");
						string cmdText14 = fun.select("SupplierName", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' AND SupplierId='", dataSet12.Tables[0].Rows[m]["SupplierId"], "'"));
						SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
						new SqlDataAdapter(selectCommand14);
						new DataSet();
						sqlDataAdapter11.Fill(dataSet13);
						if (dataSet11.Tables[0].Rows.Count > 0)
						{
							(dR = DR)[25] = string.Concat(dR[25], dataSet11.Tables[0].Rows[0]["SupplierName"].ToString(), "<br>");
						}
						(dR = DR)[26] = string.Concat(dR[26], dataSet12.Tables[0].Rows[m]["Qty"].ToString(), "<br>");
						(dR = DR)[27] = string.Concat(dR[27], dataSet12.Tables[0].Rows[m]["Id"].ToString(), "<br>");
						(dR = DR)[28] = string.Concat(dR[28], fun.FromDateDMY(dataSet12.Tables[0].Rows[m]["CheckedDate"].ToString()), "<br>");
						(dR = DR)[29] = string.Concat(dR[29], fun.FromDateDMY(dataSet12.Tables[0].Rows[m]["ApproveDate"].ToString()), "<br>");
						(dR = DR)[30] = string.Concat(dR[30], fun.FromDateDMY(dataSet12.Tables[0].Rows[m]["AuthorizeDate"].ToString()), "<br>");
						string cmdText15 = fun.select("tblInv_Inward_Master.GINNo,tblInv_Inward_Master.Id,tblInv_Inward_Master.SysDate,tblInv_Inward_Master.Sessionid,tblInv_Inward_Details.ReceivedQty", "tblInv_Inward_Master,tblInv_Inward_Details", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.PONo='" + dataSet12.Tables[0].Rows[m]["PONo"].ToString() + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Details.POId='" + dataSet12.Tables[0].Rows[m]["Id"].ToString() + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
						SqlCommand selectCommand15 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand15);
						DataSet dataSet14 = new DataSet();
						sqlDataAdapter14.Fill(dataSet14);
						for (int n = 0; n < dataSet14.Tables[0].Rows.Count; n++)
						{
							if (dataSet14.Tables[0].Rows.Count <= 0)
							{
								continue;
							}
							string cmdText16 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet14.Tables[0].Rows[n]["SessionId"], "'"));
							SqlCommand selectCommand16 = new SqlCommand(cmdText16, sqlConnection);
							SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand16);
							DataSet dataSet15 = new DataSet();
							sqlDataAdapter15.Fill(dataSet15);
							if (dataSet15.Tables[0].Rows.Count > 0)
							{
								(dR = DR)[33] = string.Concat(dR[33], dataSet15.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
							}
							(dR = DR)[31] = string.Concat(dR[31], dataSet14.Tables[0].Rows[n]["GINNo"].ToString(), "<br>");
							(dR = DR)[32] = string.Concat(dR[32], fun.FromDateDMY(dataSet14.Tables[0].Rows[n]["SysDate"].ToString()), "<br>");
							(dR = DR)[34] = string.Concat(dR[34], dataSet14.Tables[0].Rows[n]["ReceivedQty"].ToString(), "<br>");
							(dR = DR)[35] = string.Concat(dR[35], dataSet14.Tables[0].Rows[n]["Id"].ToString(), "<br>");
							string cmdText17 = fun.select("tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SessionId,tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.GSNNo", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", " tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.CompId ='" + CompId + "'AND tblinv_MaterialServiceNote_Master.GINId='" + dataSet14.Tables[0].Rows[n]["Id"].ToString() + "' AND tblinv_MaterialServiceNote_Master.GINNo='" + dataSet14.Tables[0].Rows[n]["GINNo"].ToString() + "' ");
							SqlCommand selectCommand17 = new SqlCommand(cmdText17, sqlConnection);
							SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand17);
							DataSet dataSet16 = new DataSet();
							sqlDataAdapter16.Fill(dataSet16);
							for (int num6 = 0; num6 < dataSet16.Tables[0].Rows.Count; num6++)
							{
								if (dataSet16.Tables[0].Rows.Count > 0)
								{
									string cmdText18 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet16.Tables[0].Rows[num6]["SessionId"], "'"));
									SqlCommand selectCommand18 = new SqlCommand(cmdText18, sqlConnection);
									SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand18);
									DataSet dataSet17 = new DataSet();
									sqlDataAdapter17.Fill(dataSet17);
									if (dataSet17.Tables[0].Rows.Count > 0)
									{
										(dR = DR)[48] = string.Concat(dR[48], dataSet17.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
									}
									(dR = DR)[46] = string.Concat(dR[46], dataSet16.Tables[0].Rows[num6]["GSNNo"].ToString(), "<br>");
									(dR = DR)[47] = string.Concat(dR[47], fun.FromDateDMY(dataSet16.Tables[0].Rows[num6]["SysDate"].ToString()), "<br>");
									(dR = DR)[49] = string.Concat(dR[49], dataSet16.Tables[0].Rows[num6]["ReceivedQty"].ToString(), "<br>");
									(dR = DR)[50] = string.Concat(dR[50], dataSet16.Tables[0].Rows[num6]["Id"].ToString(), "<br>");
								}
							}
							string cmdText19 = fun.select("tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Master.SessionId,tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Master.SysDate,tblinv_MaterialReceived_Master.GRRNo", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", " tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.CompId ='" + CompId + "'AND tblinv_MaterialReceived_Master.GINId='" + dataSet14.Tables[0].Rows[n]["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.GINNo='" + dataSet14.Tables[0].Rows[n]["GINNo"].ToString() + "' ");
							SqlCommand selectCommand19 = new SqlCommand(cmdText19, sqlConnection);
							SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand19);
							DataSet dataSet18 = new DataSet();
							sqlDataAdapter18.Fill(dataSet18);
							for (int num7 = 0; num7 < dataSet18.Tables[0].Rows.Count; num7++)
							{
								if (dataSet18.Tables[0].Rows.Count <= 0)
								{
									continue;
								}
								string cmdText20 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet18.Tables[0].Rows[num7]["SessionId"], "'"));
								SqlCommand selectCommand20 = new SqlCommand(cmdText20, sqlConnection);
								SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand20);
								DataSet dataSet19 = new DataSet();
								sqlDataAdapter19.Fill(dataSet19);
								if (dataSet19.Tables[0].Rows.Count > 0)
								{
									(dR = DR)[38] = string.Concat(dR[38], dataSet19.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
								}
								(dR = DR)[36] = string.Concat(dR[36], dataSet18.Tables[0].Rows[num7]["GRRNo"].ToString(), "<br>");
								(dR = DR)[37] = string.Concat(dR[37], fun.FromDateDMY(dataSet18.Tables[0].Rows[num7]["SysDate"].ToString()), "<br>");
								(dR = DR)[39] = string.Concat(dR[39], dataSet18.Tables[0].Rows[num7]["ReceivedQty"].ToString(), "<br>");
								(dR = DR)[40] = string.Concat(dR[40], dataSet18.Tables[0].Rows[num7]["Id"].ToString(), "<br>");
								string cmdText21 = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SessionId", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.GRRId='" + dataSet18.Tables[0].Rows[num7]["Id"].ToString() + "' AND tblQc_MaterialQuality_Master.GRRNo='" + dataSet18.Tables[0].Rows[num7]["GRRNo"].ToString() + "'");
								SqlCommand selectCommand21 = new SqlCommand(cmdText21, sqlConnection);
								SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand21);
								DataSet dataSet20 = new DataSet();
								sqlDataAdapter20.Fill(dataSet20);
								for (int num8 = 0; num8 < dataSet20.Tables[0].Rows.Count; num8++)
								{
									if (dataSet20.Tables[0].Rows.Count > 0)
									{
										string cmdText22 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet20.Tables[0].Rows[num8]["SessionId"], "'"));
										SqlCommand selectCommand22 = new SqlCommand(cmdText22, sqlConnection);
										SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand22);
										DataSet dataSet21 = new DataSet();
										sqlDataAdapter21.Fill(dataSet21);
										if (dataSet21.Tables[0].Rows.Count > 0)
										{
											(dR = DR)[43] = string.Concat(dR[43], dataSet21.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
										}
										(dR = DR)[41] = string.Concat(dR[41], dataSet20.Tables[0].Rows[num8]["GQNNo"].ToString(), "<br>");
										(dR = DR)[42] = string.Concat(dR[42], fun.FromDateDMY(dataSet20.Tables[0].Rows[num8]["SysDate"].ToString()), "<br>");
										(dR = DR)[44] = string.Concat(dR[44], dataSet20.Tables[0].Rows[num8]["AcceptedQty"].ToString(), "<br>");
										(dR = DR)[45] = string.Concat(dR[45], dataSet20.Tables[0].Rows[num8]["Id"].ToString(), "<br>");
									}
								}
							}
						}
					}
				}
			}
			DT.Rows.Add(DR);
			string cmdText23 = fun.select("tblDG_BOM_Master.ItemId,tblDG_BOM_Master.CId,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.PId,tblDG_BOM_Master.Qty,tblDG_BOM_Master.Weldments,tblDG_BOM_Master.LH,tblDG_BOM_Master.RH,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_BOM_Master.PId='" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "' And tblDG_BOM_Master.WONo='" + wonosrc + "'And tblDG_BOM_Master.CompId='" + CompId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id");
			SqlCommand selectCommand23 = new SqlCommand(cmdText23, sqlConnection);
			SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand23);
			DataSet dataSet22 = new DataSet();
			sqlDataAdapter22.Fill(dataSet22);
			for (int num9 = 0; num9 < dataSet22.Tables[0].Rows.Count; num9++)
			{
				DR = DT.NewRow();
				DR[0] = dataSet22.Tables[0].Rows[num9]["PId"].ToString();
				DR[1] = dataSet22.Tables[0].Rows[num9]["CId"].ToString();
				DR[2] = dataSet22.Tables[0].Rows[num9]["ItemId"].ToString();
				DR[3] = wono;
				DR[4] = dataSet22.Tables[0].Rows[num9]["ItemCode"].ToString();
				DR[5] = dataSet22.Tables[0].Rows[num9]["ManfDesc"].ToString();
				DR[6] = dataSet22.Tables[0].Rows[num9]["Symbol"].ToString();
				DR[7] = Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[num9]["Qty"].ToString()).ToString("N3"));
				DR[8] = Convert.ToDouble(decimal.Parse(fun.BOMRecurQty(wono, Convert.ToInt32(dataSet22.Tables[0].Rows[num9]["PId"]), Convert.ToInt32(dataSet22.Tables[0].Rows[num9]["CId"]), 1.0, CompId, FinYearId).ToString()).ToString("N3"));
				DR[9] = Convert.ToInt32(dataSet22.Tables[0].Rows[num9]["Weldments"]);
				DR[10] = Convert.ToInt32(dataSet22.Tables[0].Rows[num9]["LH"]);
				DR[11] = Convert.ToInt32(dataSet22.Tables[0].Rows[num9]["RH"]);
				string cmdText24 = fun.select("tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SessionId ,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", " tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialRequisition_Details.ItemId='" + dataSet22.Tables[0].Rows[num9]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.WONo='" + wono + "'   ");
				SqlCommand selectCommand24 = new SqlCommand(cmdText24, sqlConnection);
				SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand24);
				DataSet dataSet23 = new DataSet();
				sqlDataAdapter23.Fill(dataSet23);
				double num10 = 0.0;
				for (int num11 = 0; num11 < dataSet23.Tables[0].Rows.Count; num11++)
				{
					string cmdText25 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet23.Tables[0].Rows[num11]["SessionId"], "'"));
					SqlCommand selectCommand25 = new SqlCommand(cmdText25, sqlConnection);
					SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand25);
					DataSet dataSet24 = new DataSet();
					sqlDataAdapter24.Fill(dataSet24);
					DataRow dR;
					if (dataSet24.Tables[0].Rows.Count > 0)
					{
						(dR = DR)[59] = string.Concat(dR[59], dataSet24.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
					}
					(dR = DR)[57] = string.Concat(dR[57], dataSet23.Tables[0].Rows[num11]["MINNo"].ToString(), "<br>");
					(dR = DR)[58] = string.Concat(dR[58], fun.FromDateDMY(dataSet23.Tables[0].Rows[num11]["SysDate"].ToString()), "<br>");
					(dR = DR)[60] = string.Concat(dR[60], dataSet23.Tables[0].Rows[num11]["IssueQty"].ToString(), "<br>");
					num10 = Convert.ToDouble(decimal.Parse(dataSet23.Tables[0].Rows[num11]["IssueQty"].ToString()).ToString("N3"));
				}
				double num12 = 0.0;
				num12 = Convert.ToDouble(DR[8]);
				double num13 = 0.0;
				string cmdText26 = fun.select("sum(tblInv_WIS_Details.IssuedQty) as sum_IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.Id=tblInv_WIS_Details.MId AND tblInv_WIS_Master.WONo='" + wonosrc + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Details.ItemId='" + dataSet22.Tables[0].Rows[num9]["ItemId"].ToString() + "' AND tblInv_WIS_Details.PId='" + dataSet22.Tables[0].Rows[num9]["PId"].ToString() + "' AND tblInv_WIS_Details.CId='" + dataSet22.Tables[0].Rows[num9]["CId"].ToString() + "'");
				SqlCommand selectCommand26 = new SqlCommand(cmdText26, sqlConnection);
				SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand26);
				DataSet dataSet25 = new DataSet();
				sqlDataAdapter25.Fill(dataSet25);
				if (dataSet25.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && dataSet25.Tables[0].Rows.Count > 0)
				{
					num13 = Convert.ToDouble(decimal.Parse(dataSet25.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				double num14 = 0.0;
				num14 = Convert.ToDouble(decimal.Parse((num12 - num13 + num10).ToString()).ToString("N3"));
				DR[55] = num14;
				double num15 = 0.0;
				num15 = Convert.ToDouble(decimal.Parse(((num13 + num10) * 100.0 / num12).ToString()).ToString("N3"));
				DR[56] = num15;
				string cmdText27 = fun.select("tblInv_WIS_Details.IssuedQty,tblInv_WIS_Master.SessionId,tblInv_WIS_Master.SysDate,tblInv_WIS_Details.WISNo,tblInv_WIS_Master.Id", "tblInv_WIS_Details,tblInv_WIS_Master", " tblInv_WIS_Details.ItemId='" + dataSet22.Tables[0].Rows[num9]["ItemId"].ToString() + "' AND tblInv_WIS_Master.WONo='" + wonosrc + "' AND tblInv_WIS_Details.CId='" + dataSet22.Tables[0].Rows[num9]["CId"].ToString() + "'  And tblInv_WIS_Details.MId=tblInv_WIS_Master.Id  AND tblInv_WIS_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand27 = new SqlCommand(cmdText27, sqlConnection);
				SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand27);
				DataSet dataSet26 = new DataSet();
				sqlDataAdapter26.Fill(dataSet26);
				for (int num16 = 0; num16 < dataSet26.Tables[0].Rows.Count; num16++)
				{
					string cmdText28 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet26.Tables[0].Rows[num16]["SessionId"], "'"));
					SqlCommand selectCommand28 = new SqlCommand(cmdText28, sqlConnection);
					SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand28);
					DataSet dataSet27 = new DataSet();
					sqlDataAdapter27.Fill(dataSet27);
					DataRow dR;
					if (dataSet27.Tables[0].Rows.Count > 0)
					{
						(dR = DR)[53] = string.Concat(dR[53], dataSet27.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
					}
					(dR = DR)[51] = string.Concat(dR[51], dataSet26.Tables[0].Rows[num16]["WISNo"].ToString(), "<br>");
					(dR = DR)[52] = string.Concat(dR[52], fun.FromDateDMY(dataSet26.Tables[0].Rows[num16]["SysDate"].ToString()), "<br>");
					(dR = DR)[54] = string.Concat(dR[54], dataSet26.Tables[0].Rows[num16]["IssuedQty"].ToString(), "<br>");
				}
				string cmdText29 = fun.select("Id,SysDate,PLNo,SessionId,SupplierId,CompDate,ItemId,Type", "tblMP_Material_Master", "ItemId='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "'AND CompId='" + CompId + "' AND PId='" + pid + "' AND CId='" + cid + "'");
				SqlCommand selectCommand29 = new SqlCommand(cmdText29, sqlConnection);
				SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(selectCommand29);
				DataSet dataSet28 = new DataSet();
				sqlDataAdapter28.Fill(dataSet28);
				string text = "";
				int num17 = 0;
				if (dataSet28.Tables[0].Rows[0]["Type"].ToString() == "0")
				{
					text = fun.select("Id,SysDate,PLNo,SessionId,SupplierId,CompDate,ItemId", "tblMP_Material_Master", "ItemId='" + dataSet22.Tables[0].Rows[num9]["ItemId"].ToString() + "' AND CId='" + dataSet22.Tables[0].Rows[num9]["CId"].ToString() + "'AND CompId='" + CompId + "'");
					num17 = 1;
				}
				else
				{
					text = fun.select("*", "tblMP_Material_RawMaterial,tblMP_Material_Master", "tblMP_Material_RawMaterial.ItemId='" + dataSet22.Tables[0].Rows[num9]["ItemId"].ToString() + "' AND tblMP_Material_RawMaterial.CId='" + dataSet22.Tables[0].Rows[num9]["CId"].ToString() + "'AND tblMP_Material_Master.CompId='" + CompId + "' AND tblMP_Material_Master.Id=tblMP_Material_RawMaterial.MId");
				}
				SqlCommand selectCommand30 = new SqlCommand(text, sqlConnection);
				SqlDataAdapter sqlDataAdapter29 = new SqlDataAdapter(selectCommand30);
				DataSet dataSet29 = new DataSet();
				sqlDataAdapter29.Fill(dataSet29);
				for (int num18 = 0; num18 < dataSet29.Tables[0].Rows.Count; num18++)
				{
					if (dataSet29.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					if (num17 == 1)
					{
						string cmdText30 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet29.Tables[0].Rows[num18]["SessionId"], "'"));
						SqlCommand selectCommand31 = new SqlCommand(cmdText30, sqlConnection);
						SqlDataAdapter sqlDataAdapter30 = new SqlDataAdapter(selectCommand31);
						DataSet dataSet30 = new DataSet();
						sqlDataAdapter30.Fill(dataSet30);
						DataRow dR;
						if (dataSet30.Tables[0].Rows.Count > 0)
						{
							(dR = DR)[14] = string.Concat(dR[14], dataSet30.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
						}
						(dR = DR)[12] = string.Concat(dR[12], dataSet29.Tables[0].Rows[num18]["PLNo"].ToString(), "<br>");
						(dR = DR)[13] = string.Concat(dR[13], fun.FromDateDMY(dataSet29.Tables[0].Rows[num18]["SysDate"].ToString()), "<br>");
						(dR = DR)[15] = string.Concat(dR[15], dataSet29.Tables[0].Rows[num18]["Id"].ToString(), "<br>");
					}
					string cmdText31 = fun.select("tblMM_PR_Details.Qty,tblMM_PR_Details.SupplierId,tblMM_PR_Master.PRNo,tblMM_PR_Details.Id,tblMM_PR_Master.SysDate,tblMM_PR_Master.SessionId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.ItemId='" + dataSet29.Tables[0].Rows[num18]["ItemId"].ToString() + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.WONo='" + wonosrc + "' AND tblMM_PR_Master.CompId='" + CompId + "'AND CId='" + dataSet22.Tables[0].Rows[num9]["CId"].ToString() + "'");
					SqlCommand selectCommand32 = new SqlCommand(cmdText31, sqlConnection);
					SqlDataAdapter sqlDataAdapter31 = new SqlDataAdapter(selectCommand32);
					DataSet dataSet31 = new DataSet();
					sqlDataAdapter31.Fill(dataSet31);
					for (int num19 = 0; num19 < dataSet31.Tables[0].Rows.Count; num19++)
					{
						if (dataSet31.Tables[0].Rows.Count <= 0)
						{
							continue;
						}
						string cmdText32 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet31.Tables[0].Rows[num19]["SessionId"], "'"));
						SqlCommand selectCommand33 = new SqlCommand(cmdText32, sqlConnection);
						SqlDataAdapter sqlDataAdapter32 = new SqlDataAdapter(selectCommand33);
						DataSet dataSet32 = new DataSet();
						sqlDataAdapter32.Fill(dataSet32);
						DataRow dR;
						if (dataSet32.Tables[0].Rows.Count > 0)
						{
							(dR = DR)[18] = string.Concat(dR[18], dataSet32.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
						}
						(dR = DR)[16] = string.Concat(dR[16], dataSet31.Tables[0].Rows[num19]["PRNo"].ToString(), "<br>");
						(dR = DR)[17] = string.Concat(dR[17], fun.FromDateDMY(dataSet31.Tables[0].Rows[num19]["SysDate"].ToString()), "<br>");
						string cmdText33 = fun.select("SupplierName", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' AND SupplierId='", dataSet31.Tables[0].Rows[num19]["SupplierId"], "'"));
						SqlCommand selectCommand34 = new SqlCommand(cmdText33, sqlConnection);
						SqlDataAdapter sqlDataAdapter33 = new SqlDataAdapter(selectCommand34);
						DataSet dataSet33 = new DataSet();
						sqlDataAdapter33.Fill(dataSet33);
						if (dataSet33.Tables[0].Rows.Count > 0)
						{
							(dR = DR)[19] = string.Concat(dR[19], dataSet33.Tables[0].Rows[0]["SupplierName"].ToString(), "<br>");
						}
						(dR = DR)[20] = string.Concat(dR[20], dataSet31.Tables[0].Rows[num19]["Qty"].ToString(), "<br>");
						(dR = DR)[21] = string.Concat(dR[21], dataSet31.Tables[0].Rows[num19]["Id"].ToString(), "<br>");
						string cmdText34 = fun.select("tblMM_PO_Master.Id,tblMM_PO_Details.Qty,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Master.SupplierId,tblMM_PO_Master.SessionId,tblMM_PO_Master.CheckedDate,tblMM_PO_Master.ApproveDate,tblMM_PO_Master.AuthorizeDate", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.PRId='" + dataSet31.Tables[0].Rows[num19]["Id"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
						SqlCommand selectCommand35 = new SqlCommand(cmdText34, sqlConnection);
						SqlDataAdapter sqlDataAdapter34 = new SqlDataAdapter(selectCommand35);
						DataSet dataSet34 = new DataSet();
						sqlDataAdapter34.Fill(dataSet34);
						for (int num20 = 0; num20 < dataSet34.Tables[0].Rows.Count; num20++)
						{
							if (dataSet34.Tables[0].Rows.Count <= 0)
							{
								continue;
							}
							string cmdText35 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet34.Tables[0].Rows[num20]["SessionId"], "'"));
							SqlCommand selectCommand36 = new SqlCommand(cmdText35, sqlConnection);
							SqlDataAdapter sqlDataAdapter35 = new SqlDataAdapter(selectCommand36);
							DataSet dataSet35 = new DataSet();
							sqlDataAdapter35.Fill(dataSet35);
							if (dataSet35.Tables[0].Rows.Count > 0)
							{
								(dR = DR)[24] = string.Concat(dR[24], dataSet35.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
							}
							(dR = DR)[22] = string.Concat(dR[22], dataSet34.Tables[0].Rows[num20]["PONo"].ToString(), "<br>");
							(dR = DR)[23] = string.Concat(dR[23], fun.FromDateDMY(dataSet34.Tables[0].Rows[num20]["SysDate"].ToString()), "<br>");
							string cmdText36 = fun.select("SupplierName", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' AND SupplierId='", dataSet34.Tables[0].Rows[num20]["SupplierId"], "'"));
							SqlCommand selectCommand37 = new SqlCommand(cmdText36, sqlConnection);
							new SqlDataAdapter(selectCommand37);
							new DataSet();
							sqlDataAdapter33.Fill(dataSet35);
							if (dataSet33.Tables[0].Rows.Count > 0)
							{
								(dR = DR)[25] = string.Concat(dR[25], dataSet33.Tables[0].Rows[0]["SupplierName"].ToString(), "<br>");
							}
							(dR = DR)[26] = string.Concat(dR[26], dataSet34.Tables[0].Rows[num20]["Qty"].ToString(), "<br>");
							(dR = DR)[27] = string.Concat(dR[27], dataSet34.Tables[0].Rows[num20]["Id"].ToString(), "<br>");
							(dR = DR)[28] = string.Concat(dR[28], fun.FromDateDMY(dataSet34.Tables[0].Rows[num20]["CheckedDate"].ToString()), "<br>");
							(dR = DR)[29] = string.Concat(dR[29], fun.FromDateDMY(dataSet34.Tables[0].Rows[num20]["ApproveDate"].ToString()), "<br>");
							(dR = DR)[30] = string.Concat(dR[30], fun.FromDateDMY(dataSet34.Tables[0].Rows[num20]["AuthorizeDate"].ToString()), "<br>");
							string cmdText37 = fun.select("tblInv_Inward_Master.GINNo,tblInv_Inward_Master.Id,tblInv_Inward_Master.SysDate,tblInv_Inward_Master.Sessionid,tblInv_Inward_Details.ReceivedQty", "tblInv_Inward_Master,tblInv_Inward_Details", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.PONo='" + dataSet34.Tables[0].Rows[num20]["PONo"].ToString() + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Details.POId='" + dataSet34.Tables[0].Rows[num20]["Id"].ToString() + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
							SqlCommand selectCommand38 = new SqlCommand(cmdText37, sqlConnection);
							SqlDataAdapter sqlDataAdapter36 = new SqlDataAdapter(selectCommand38);
							DataSet dataSet36 = new DataSet();
							sqlDataAdapter36.Fill(dataSet36);
							for (int num21 = 0; num21 < dataSet36.Tables[0].Rows.Count; num21++)
							{
								if (dataSet36.Tables[0].Rows.Count <= 0)
								{
									continue;
								}
								string cmdText38 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet36.Tables[0].Rows[num21]["SessionId"], "'"));
								SqlCommand selectCommand39 = new SqlCommand(cmdText38, sqlConnection);
								SqlDataAdapter sqlDataAdapter37 = new SqlDataAdapter(selectCommand39);
								DataSet dataSet37 = new DataSet();
								sqlDataAdapter37.Fill(dataSet37);
								if (dataSet37.Tables[0].Rows.Count > 0)
								{
									(dR = DR)[33] = string.Concat(dR[33], dataSet37.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
								}
								(dR = DR)[31] = string.Concat(dR[31], dataSet36.Tables[0].Rows[num21]["GINNo"].ToString(), "<br>");
								(dR = DR)[32] = string.Concat(dR[32], fun.FromDateDMY(dataSet36.Tables[0].Rows[num21]["SysDate"].ToString()), "<br>");
								(dR = DR)[34] = string.Concat(dR[34], dataSet36.Tables[0].Rows[num21]["ReceivedQty"].ToString(), "<br>");
								(dR = DR)[35] = string.Concat(dR[35], dataSet36.Tables[0].Rows[num21]["Id"].ToString(), "<br>");
								string cmdText39 = fun.select("tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SessionId,tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.GSNNo", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", " tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.CompId ='" + CompId + "'AND tblinv_MaterialServiceNote_Master.GINId='" + dataSet36.Tables[0].Rows[num21]["Id"].ToString() + "' AND tblinv_MaterialServiceNote_Master.GINNo='" + dataSet36.Tables[0].Rows[num21]["GINNo"].ToString() + "' ");
								SqlCommand selectCommand40 = new SqlCommand(cmdText39, sqlConnection);
								SqlDataAdapter sqlDataAdapter38 = new SqlDataAdapter(selectCommand40);
								DataSet dataSet38 = new DataSet();
								sqlDataAdapter38.Fill(dataSet38);
								for (int num22 = 0; num22 < dataSet38.Tables[0].Rows.Count; num22++)
								{
									if (dataSet38.Tables[0].Rows.Count > 0)
									{
										string cmdText40 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet38.Tables[0].Rows[num22]["SessionId"], "'"));
										SqlCommand selectCommand41 = new SqlCommand(cmdText40, sqlConnection);
										SqlDataAdapter sqlDataAdapter39 = new SqlDataAdapter(selectCommand41);
										DataSet dataSet39 = new DataSet();
										sqlDataAdapter39.Fill(dataSet39);
										if (dataSet39.Tables[0].Rows.Count > 0)
										{
											(dR = DR)[48] = string.Concat(dR[48], dataSet39.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
										}
										(dR = DR)[46] = string.Concat(dR[46], dataSet38.Tables[0].Rows[num22]["GSNNo"].ToString(), "<br>");
										(dR = DR)[47] = string.Concat(dR[47], fun.FromDateDMY(dataSet38.Tables[0].Rows[num22]["SysDate"].ToString()), "<br>");
										(dR = DR)[49] = string.Concat(dR[49], dataSet38.Tables[0].Rows[num22]["ReceivedQty"].ToString(), "<br>");
										(dR = DR)[50] = string.Concat(dR[50], dataSet38.Tables[0].Rows[num22]["Id"].ToString(), "<br>");
									}
								}
								string cmdText41 = fun.select("tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Master.SessionId,tblinv_MaterialReceived_Details.Id,tblinv_MaterialReceived_Master.SysDate,tblinv_MaterialReceived_Master.GRRNo", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", " tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.CompId ='" + CompId + "'AND tblinv_MaterialReceived_Master.GINId='" + dataSet36.Tables[0].Rows[num21]["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.GINNo='" + dataSet36.Tables[0].Rows[num21]["GINNo"].ToString() + "' ");
								SqlCommand selectCommand42 = new SqlCommand(cmdText41, sqlConnection);
								SqlDataAdapter sqlDataAdapter40 = new SqlDataAdapter(selectCommand42);
								DataSet dataSet40 = new DataSet();
								sqlDataAdapter40.Fill(dataSet40);
								for (int num23 = 0; num23 < dataSet40.Tables[0].Rows.Count; num23++)
								{
									if (dataSet40.Tables[0].Rows.Count <= 0)
									{
										continue;
									}
									string cmdText42 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet40.Tables[0].Rows[num23]["SessionId"], "'"));
									SqlCommand selectCommand43 = new SqlCommand(cmdText42, sqlConnection);
									SqlDataAdapter sqlDataAdapter41 = new SqlDataAdapter(selectCommand43);
									DataSet dataSet41 = new DataSet();
									sqlDataAdapter41.Fill(dataSet41);
									if (dataSet41.Tables[0].Rows.Count > 0)
									{
										(dR = DR)[38] = string.Concat(dR[38], dataSet41.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
									}
									(dR = DR)[36] = string.Concat(dR[36], dataSet40.Tables[0].Rows[num23]["GRRNo"].ToString(), "<br>");
									(dR = DR)[37] = string.Concat(dR[37], fun.FromDateDMY(dataSet40.Tables[0].Rows[num23]["SysDate"].ToString()), "<br>");
									(dR = DR)[39] = string.Concat(dR[39], dataSet40.Tables[0].Rows[num23]["ReceivedQty"].ToString(), "<br>");
									(dR = DR)[40] = string.Concat(dR[40], dataSet40.Tables[0].Rows[num23]["Id"].ToString(), "<br>");
									string cmdText43 = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SessionId", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.GRRId='" + dataSet40.Tables[0].Rows[num23]["Id"].ToString() + "' AND tblQc_MaterialQuality_Master.GRRNo='" + dataSet40.Tables[0].Rows[num23]["GRRNo"].ToString() + "'");
									SqlCommand selectCommand44 = new SqlCommand(cmdText43, sqlConnection);
									SqlDataAdapter sqlDataAdapter42 = new SqlDataAdapter(selectCommand44);
									DataSet dataSet42 = new DataSet();
									sqlDataAdapter42.Fill(dataSet42);
									for (int num24 = 0; num24 < dataSet42.Tables[0].Rows.Count; num24++)
									{
										if (dataSet42.Tables[0].Rows.Count > 0)
										{
											string cmdText44 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet42.Tables[0].Rows[num24]["SessionId"], "'"));
											SqlCommand selectCommand45 = new SqlCommand(cmdText44, sqlConnection);
											SqlDataAdapter sqlDataAdapter43 = new SqlDataAdapter(selectCommand45);
											DataSet dataSet43 = new DataSet();
											sqlDataAdapter43.Fill(dataSet43);
											if (dataSet43.Tables[0].Rows.Count > 0)
											{
												(dR = DR)[43] = string.Concat(dR[43], dataSet43.Tables[0].Rows[0]["EmpLoyeeName"].ToString(), "<br>");
											}
											(dR = DR)[41] = string.Concat(dR[41], dataSet42.Tables[0].Rows[num24]["GQNNo"].ToString(), "<br>");
											(dR = DR)[42] = string.Concat(dR[42], fun.FromDateDMY(dataSet42.Tables[0].Rows[num24]["SysDate"].ToString()), "<br>");
											(dR = DR)[44] = string.Concat(dR[44], dataSet42.Tables[0].Rows[num24]["AcceptedQty"].ToString(), "<br>");
											(dR = DR)[45] = string.Concat(dR[45], dataSet42.Tables[0].Rows[num24]["Id"].ToString(), "<br>");
										}
									}
								}
							}
						}
					}
				}
				DT.Rows.Add(DR);
				DataSet dataSet44 = new DataSet();
				string cmdText45 = fun.select("tblDG_BOM_Master.ItemId,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty,tblDG_BOM_Master.CId,tblDG_BOM_Master.Weldments,tblDG_BOM_Master.LH,tblDG_BOM_Master.RH,Unit_Master.Symbol,tblDG_Item_Master.ManfDesc", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", string.Concat("tblDG_BOM_Master.PId=", dataSet22.Tables[0].Rows[num9]["CId"], "And tblDG_BOM_Master.WONo='", wonosrc, "'And tblDG_BOM_Master.CompId='", CompId, "'AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id"));
				SqlCommand selectCommand46 = new SqlCommand(cmdText45, sqlConnection);
				SqlDataAdapter sqlDataAdapter44 = new SqlDataAdapter(selectCommand46);
				sqlDataAdapter44.Fill(dataSet44);
				if (dataSet44.Tables[0].Rows.Count > 0)
				{
					for (int num25 = 0; num25 < dataSet44.Tables[0].Rows.Count; num25++)
					{
						getPrintnode(Convert.ToInt32(dataSet44.Tables[0].Rows[num25]["CId"]), wonosrc, CompId);
					}
				}
			}
			DT.AcceptChanges();
			return DT;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		return DT;
	}

	protected void RadTreeList1_PageIndexChanged(object source, TreeListPageChangedEventArgs e)
	{
		RadTreeList1.CurrentPageIndex = e.NewPageIndex;
		getColoumn();
		RadTreeList1.DataSource = getPrintnode(cid, wonosrc, CompId);
		RadTreeList1.DataBind();
	}

	protected void RadTreeList1_PageSizeChanged(object source, TreeListPageSizeChangedEventArgs e)
	{
		getColoumn();
		RadTreeList1.DataSource = getPrintnode(cid, wonosrc, CompId);
		RadTreeList1.DataBind();
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProjectSummary_Details.aspx?WONo=" + wonosrc + "&ModId=&SubModId=");
	}

	protected void RadTreeList1_ItemCommand1(object sender, TreeListCommandEventArgs e)
	{
		if (e.CommandName == "ExpandCollapse")
		{
			getColoumn();
			RadTreeList1.DataSource = getPrintnode(cid, wonosrc, CompId);
			RadTreeList1.DataBind();
		}
	}
}

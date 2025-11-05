using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Inventory_Transactions_StockLedger_Print : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string Fdate = "";

	private string Tdate = "";

	private string ItemCode = "";

	private int Id;

	private string unit = "";

	private string desc = "";

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_45f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_45fe: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataSet dataSet2 = new DataSet();
			DataTable dataTable = new DataTable();
			DataSet dataSet3 = new DataSet();
			DataSet dataSet4 = new DataSet();
			DataSet dataSet5 = new DataSet();
			DataSet dataSet6 = new DataSet();
			DataSet dataSet7 = new DataSet();
			DataSet dataSet8 = new DataSet();
			DataSet dataSet9 = new DataSet();
			DataSet dataSet10 = new DataSet();
			DataSet dataSet11 = new DataSet();
			DataSet dataSet12 = new DataSet();
			DataSet dataSet13 = new DataSet();
			try
			{
				sqlConnection.Open();
				double num = 0.0;
				double num2 = 0.0;
				Id = Convert.ToInt32(base.Request.QueryString["Id"]);
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				Fdate = base.Request.QueryString["Fdate"].ToString();
				Tdate = base.Request.QueryString["Tdate"].ToString();
				string cmdText = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + Id + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				ItemCode = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				desc = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				string cmdText2 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				unit = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
				dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("IssueQty", typeof(double)));
				dataTable.Columns.Add(new DataColumn("for", typeof(string)));
				dataTable.Columns.Add(new DataColumn("to", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("seconds", typeof(double)));
				dataTable.Columns.Add(new DataColumn("SortDateTime", typeof(string)));
				string cmdText3 = fun.select("tblQc_MaterialReturnQuality_Master.SysDate ,tblInv_MaterialReturn_Master.MRNNo, tblQc_MaterialReturnQuality_Master.MRQNNo,tblQc_MaterialReturnQuality_Master.SysTime,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblInv_MaterialReturn_Master.SessionId,tblQc_MaterialReturnQuality_Master.SessionId AS session,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo ", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master,tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "  tblQc_MaterialReturnQuality_Master.MRQNNo= tblQc_MaterialReturnQuality_Details.MRQNNo AND tblQc_MaterialReturnQuality_Master.Id= tblQc_MaterialReturnQuality_Details.MId  AND  tblInv_MaterialReturn_Master.MRNNo=tblInv_MaterialReturn_Details.MRNNo  AND  tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId  AND tblInv_MaterialReturn_Master.Id=tblQc_MaterialReturnQuality_Master.MRNId AND tblInv_MaterialReturn_Master.MRNNo=tblQc_MaterialReturnQuality_Master.MRNNo AND tblInv_MaterialReturn_Details.Id=tblQc_MaterialReturnQuality_Details.MRNId AND tblInv_MaterialReturn_Details.ItemId='" + Id + "'   AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  And tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' And tblQc_MaterialReturnQuality_Master.SysDate  between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText4 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet3.Tables[0].Rows[i]["SessionId"], "'"));
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet14 = new DataSet();
						sqlDataAdapter4.Fill(dataSet14);
						if (dataSet14.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet14.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText5 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet3.Tables[0].Rows[i]["session"], "'"));
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet15 = new DataSet();
						sqlDataAdapter5.Fill(dataSet15);
						if (dataSet15.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet15.Tables[0].Rows[0]["EmpName"].ToString();
						}
						string cmdText6 = fun.select("Symbol  As Dept ", "tblHR_Departments", string.Concat(" Id='", dataSet3.Tables[0].Rows[i]["DeptId"], "'"));
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet16 = new DataSet();
						sqlDataAdapter6.Fill(dataSet16);
						string text = dataSet3.Tables[0].Rows[i]["MRNNo"].ToString();
						string text2 = dataSet3.Tables[0].Rows[i]["MRQNNo"].ToString();
						dataRow[0] = fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["SysDate"].ToString());
						dataRow[1] = dataSet3.Tables[0].Rows[i]["SysTime"].ToString();
						if (dataSet3.Tables[0].Rows[i]["AcceptedQty"] != DBNull.Value)
						{
							dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["AcceptedQty"].ToString()).ToString("N3"));
						}
						else
						{
							dataRow[3] = 0;
						}
						if (dataSet16.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet16.Tables[0].Rows[0]["Dept"].ToString();
						}
						if (dataSet3.Tables[0].Rows[i]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet3.Tables[0].Rows[i]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "MRN No[" + text + "]";
						dataRow[8] = "MRQN No[" + text2 + "]";
						dataRow[6] = 0;
						dataRow[10] = CompId;
						dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet3.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet3.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet3.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet3.Tables[0].Rows[i]["SysDate"].ToString(), dataSet3.Tables[0].Rows[i]["SysTime"].ToString());
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				string cmdText7 = "SELECT tblPM_MaterialCreditNote_Details.MCNQty, tblQc_AuthorizedMCN.QAQty, tblQc_AuthorizedMCN.SysDate,tblQc_AuthorizedMCN.SysTime,tblPM_MaterialCreditNote_Master.SessionId AS TransBy, tblQc_AuthorizedMCN.SessionId AS ProcBy, tblPM_MaterialCreditNote_Master.WONo,tblPM_MaterialCreditNote_Master.MCNNo FROM tblPM_MaterialCreditNote_Details INNER JOIN tblPM_MaterialCreditNote_Master ON tblPM_MaterialCreditNote_Details.MId = tblPM_MaterialCreditNote_Master.Id INNER JOIN tblQc_AuthorizedMCN ON tblPM_MaterialCreditNote_Details.Id = tblQc_AuthorizedMCN.MCNDId AND  tblPM_MaterialCreditNote_Details.MId = tblQc_AuthorizedMCN.MCNId INNER JOIN  tblDG_BOM_Master ON tblPM_MaterialCreditNote_Master.WONo = tblDG_BOM_Master.WONo AND tblPM_MaterialCreditNote_Details.PId = tblDG_BOM_Master.PId AND tblPM_MaterialCreditNote_Details.CId = tblDG_BOM_Master.CId AND tblQc_AuthorizedMCN.CompId='" + CompId + "' AND tblQc_AuthorizedMCN.SysDate  between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' AND tblDG_BOM_Master.ItemId='" + Id + "'";
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				sqlDataAdapter7.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText8 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet4.Tables[0].Rows[j]["TransBy"], "'"));
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet17 = new DataSet();
						sqlDataAdapter8.Fill(dataSet17);
						if (dataSet17.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet17.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText9 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet4.Tables[0].Rows[j]["ProcBy"], "'"));
						SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet18 = new DataSet();
						sqlDataAdapter9.Fill(dataSet18);
						if (dataSet18.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet18.Tables[0].Rows[0]["EmpName"].ToString();
						}
						string text3 = dataSet4.Tables[0].Rows[j]["MCNNo"].ToString();
						dataRow[0] = fun.FromDateDMY(dataSet4.Tables[0].Rows[j]["SysDate"].ToString());
						dataRow[1] = dataSet4.Tables[0].Rows[j]["SysTime"].ToString();
						dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[j]["QAQty"].ToString()).ToString("N3"));
						dataRow[4] = "NA";
						dataRow[5] = dataSet4.Tables[0].Rows[j]["WONo"].ToString();
						dataRow[7] = "MCN No[" + text3 + "]";
						dataRow[8] = "MCN No[" + text3 + "]";
						dataRow[10] = CompId;
						dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet4.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet4.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet4.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet4.Tables[0].Rows[j]["SysDate"].ToString(), dataSet4.Tables[0].Rows[j]["SysTime"].ToString());
						dataRow[6] = 0;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				string cmdText10 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty,tblMM_SPR_Details.DeptId,tblMM_PO_Master.PONo,tblMM_SPR_Details.WONo, tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SysTime,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Master.SessionId,tblMM_PO_Master.SessionId As  session , tblMM_SPR_Details.AHId ", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master", "tblQc_MaterialQuality_Master.GQNNo=tblQc_MaterialQuality_Details.GQNNo And tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And  tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId  And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo   And tblMM_SPR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='1'      And tblQc_MaterialQuality_Master.CompId='" + CompId + "' And tblQc_MaterialQuality_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				sqlDataAdapter10.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					for (int k = 0; k < dataSet5.Tables[0].Rows.Count; k++)
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText11 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet5.Tables[0].Rows[k]["session"], "'"));
						SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
						SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
						DataSet dataSet19 = new DataSet();
						sqlDataAdapter11.Fill(dataSet19);
						if (dataSet19.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet19.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText12 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND  EmpId='", dataSet5.Tables[0].Rows[k]["SessionId"], "'"));
						SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
						SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
						DataSet dataSet20 = new DataSet();
						sqlDataAdapter12.Fill(dataSet20);
						string cmdText13 = fun.select("Symbol  As Dept ", "tblHR_Departments", string.Concat(" Id='", dataSet5.Tables[0].Rows[k]["DeptId"], "'"));
						SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
						SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
						DataSet dataSet21 = new DataSet();
						sqlDataAdapter13.Fill(dataSet21);
						if (dataSet5.Tables[0].Rows[k]["AcceptedQty"] != DBNull.Value)
						{
							dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[k]["AcceptedQty"].ToString()).ToString("N3"));
						}
						else
						{
							dataRow[3] = 0;
						}
						string text4 = dataSet5.Tables[0].Rows[k]["GQNNo"].ToString();
						string text5 = dataSet5.Tables[0].Rows[k]["PONo"].ToString();
						string value = fun.FromDateDMY(dataSet5.Tables[0].Rows[k]["SysDate"].ToString());
						dataRow[0] = value;
						dataRow[1] = dataSet5.Tables[0].Rows[k]["SysTime"].ToString();
						if (dataSet20.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet20.Tables[0].Rows[0]["EmpName"].ToString();
						}
						if (dataSet21.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet21.Tables[0].Rows[0]["Dept"].ToString();
						}
						if (dataSet5.Tables[0].Rows[k]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet5.Tables[0].Rows[k]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text5 + "]";
						dataRow[8] = "GQN No[" + text4 + "]";
						dataRow[10] = CompId;
						dataRow[6] = 0;
						dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet5.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet5.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet5.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet5.Tables[0].Rows[k]["SysDate"].ToString(), dataSet5.Tables[0].Rows[k]["SysTime"].ToString());
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				string cmdText14 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty,tblMM_PR_Master.WONo,tblQc_MaterialQuality_Master.GQNNo,tblMM_PO_Master.PONo,tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SysTime,tblQc_MaterialQuality_Master.SessionId,tblMM_PO_Master.SessionId As  session,tblMM_PR_Details.AHId ", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblQc_MaterialQuality_Master.GQNNo=tblQc_MaterialQuality_Details.GQNNo AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo=tblMM_PO_Details.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='0' And tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				sqlDataAdapter14.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					for (int l = 0; l < dataSet6.Tables[0].Rows.Count; l++)
					{
						DataRow dataRow = dataTable.NewRow();
						if (dataSet6.Tables[0].Rows[l]["AcceptedQty"] != DBNull.Value)
						{
							dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[l]["AcceptedQty"].ToString()).ToString("N3"));
						}
						else
						{
							dataRow[3] = 0;
						}
						string cmdText15 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet6.Tables[0].Rows[l]["session"], "'"));
						SqlCommand selectCommand15 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
						DataSet dataSet22 = new DataSet();
						sqlDataAdapter15.Fill(dataSet22);
						if (dataSet22.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet22.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText16 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet6.Tables[0].Rows[l]["SessionId"], "'"));
						SqlCommand selectCommand16 = new SqlCommand(cmdText16, sqlConnection);
						SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
						DataSet dataSet23 = new DataSet();
						sqlDataAdapter16.Fill(dataSet23);
						string text6 = dataSet6.Tables[0].Rows[l]["GQNNo"].ToString();
						string text7 = dataSet6.Tables[0].Rows[l]["PONo"].ToString();
						string value2 = fun.FromDateDMY(dataSet6.Tables[0].Rows[l]["SysDate"].ToString());
						dataRow[0] = value2;
						dataRow[1] = dataSet6.Tables[0].Rows[l]["SysTime"].ToString();
						if (dataSet23.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet23.Tables[0].Rows[0]["EmpName"].ToString();
						}
						if (dataSet6.Tables[0].Rows[l]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet6.Tables[0].Rows[l]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text7 + "]";
						dataRow[8] = "GQN No[" + text6 + "]";
						dataRow[10] = CompId;
						dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet6.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet6.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet6.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet6.Tables[0].Rows[l]["SysDate"].ToString(), dataSet6.Tables[0].Rows[l]["SysTime"].ToString());
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				string cmdText17 = fun.select(" tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.SysTime,tblinv_MaterialServiceNote_Master.SessionId,tblMM_SPR_Details.DeptId,tblMM_PO_Master.PONo,tblMM_SPR_Details.WONo, tblMM_PO_Master.SessionId As session  , tblMM_SPR_Details.AHId ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master   ", "tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo And tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo And tblMM_SPR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='1' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "'And tblinv_MaterialServiceNote_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' ");
				SqlCommand selectCommand17 = new SqlCommand(cmdText17, sqlConnection);
				SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
				sqlDataAdapter17.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					for (int m = 0; m < dataSet7.Tables[0].Rows.Count; m++)
					{
						string cmdText18 = fun.select("*", "AccHead", "Id='" + dataSet7.Tables[0].Rows[m]["AHId"].ToString() + "'  ");
						SqlCommand selectCommand18 = new SqlCommand(cmdText18, sqlConnection);
						SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
						DataSet dataSet24 = new DataSet();
						sqlDataAdapter18.Fill(dataSet24);
						if (dataSet24.Tables[0].Rows.Count > 0 && dataSet24.Tables[0].Rows[0]["Category"].ToString() == "Labour")
						{
							DataRow dataRow = dataTable.NewRow();
							string cmdText19 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet7.Tables[0].Rows[m]["session"], "'"));
							SqlCommand selectCommand19 = new SqlCommand(cmdText19, sqlConnection);
							SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
							DataSet dataSet25 = new DataSet();
							sqlDataAdapter19.Fill(dataSet25);
							if (dataSet25.Tables[0].Rows.Count > 0)
							{
								dataRow[9] = dataSet25.Tables[0].Rows[0]["EName"].ToString();
							}
							string cmdText20 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet7.Tables[0].Rows[m]["SessionId"], "'"));
							SqlCommand selectCommand20 = new SqlCommand(cmdText20, sqlConnection);
							SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
							DataSet dataSet26 = new DataSet();
							sqlDataAdapter20.Fill(dataSet26);
							string cmdText21 = fun.select("Symbol  As Dept ", "tblHR_Departments", string.Concat(" Id='", dataSet7.Tables[0].Rows[m]["DeptId"], "'"));
							SqlCommand selectCommand21 = new SqlCommand(cmdText21, sqlConnection);
							SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
							DataSet dataSet27 = new DataSet();
							sqlDataAdapter21.Fill(dataSet27);
							num = ((dataSet7.Tables[0].Rows[m]["ReceivedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[m]["ReceivedQty"].ToString()).ToString("N3")));
							string text8 = dataSet7.Tables[0].Rows[m]["GSNNo"].ToString();
							string text9 = dataSet7.Tables[0].Rows[m]["PONo"].ToString();
							string value3 = fun.FromDateDMY(dataSet7.Tables[0].Rows[m]["SysDate"].ToString());
							dataRow[0] = value3;
							dataRow[1] = dataSet7.Tables[0].Rows[m]["SysTime"].ToString();
							if (dataSet26.Tables[0].Rows.Count > 0)
							{
								dataRow[2] = dataSet26.Tables[0].Rows[0]["EmpName"].ToString();
							}
							dataRow[3] = num;
							if (dataSet27.Tables[0].Rows.Count > 0)
							{
								dataRow[4] = dataSet27.Tables[0].Rows[0]["Dept"].ToString();
							}
							if (dataSet7.Tables[0].Rows[m]["WONo"].ToString() != "")
							{
								dataRow[5] = dataSet7.Tables[0].Rows[m]["WONo"].ToString();
							}
							else
							{
								dataRow[5] = "NA";
							}
							dataRow[7] = "PO No[" + text9 + "]";
							dataRow[8] = "GSN No[" + text8 + "]";
							dataRow[10] = CompId;
							dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet7.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet7.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet7.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%s"));
							dataRow[6] = 0;
							dataRow[12] = fun.ShortDateTime(dataSet7.Tables[0].Rows[m]["SysDate"].ToString(), dataSet7.Tables[0].Rows[m]["SysTime"].ToString());
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
				string cmdText22 = fun.select("tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.SysTime,tblinv_MaterialServiceNote_Master.SessionId,tblMM_PR_Master.WONo,tblMM_PO_Master.PONo,tblMM_PO_Master.SessionId As  session,tblMM_PR_Details.AHId ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo And tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PO_Details.PRNo=tblMM_PR_Master.PRNo And      tblMM_PR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='0' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "'And tblinv_MaterialServiceNote_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand22 = new SqlCommand(cmdText22, sqlConnection);
				SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
				sqlDataAdapter22.Fill(dataSet9);
				if (dataSet9.Tables[0].Rows.Count > 0)
				{
					for (int n = 0; n < dataSet9.Tables[0].Rows.Count; n++)
					{
						string cmdText23 = fun.select("*", "AccHead", "Id='" + dataSet9.Tables[0].Rows[n]["AHId"].ToString() + "'  ");
						SqlCommand selectCommand23 = new SqlCommand(cmdText23, sqlConnection);
						SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
						DataSet dataSet28 = new DataSet();
						sqlDataAdapter23.Fill(dataSet28);
						if (dataSet28.Tables[0].Rows.Count > 0 && dataSet28.Tables[0].Rows[0]["Category"].ToString() == "Labour")
						{
							DataRow dataRow = dataTable.NewRow();
							num2 = ((dataSet9.Tables[0].Rows[n]["ReceivedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[n]["ReceivedQty"].ToString()).ToString("N3")));
							string cmdText24 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet9.Tables[0].Rows[n]["session"], "'"));
							SqlCommand selectCommand24 = new SqlCommand(cmdText24, sqlConnection);
							SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand24);
							DataSet dataSet29 = new DataSet();
							sqlDataAdapter24.Fill(dataSet29);
							if (dataSet29.Tables[0].Rows.Count > 0)
							{
								dataRow[9] = dataSet29.Tables[0].Rows[0]["EName"].ToString();
							}
							string cmdText25 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet9.Tables[0].Rows[n]["SessionId"], "'"));
							SqlCommand selectCommand25 = new SqlCommand(cmdText25, sqlConnection);
							SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand25);
							DataSet dataSet30 = new DataSet();
							sqlDataAdapter25.Fill(dataSet30);
							string text10 = dataSet9.Tables[0].Rows[n]["GSNNo"].ToString();
							string text11 = dataSet9.Tables[0].Rows[n]["PONo"].ToString();
							string value4 = fun.FromDateDMY(dataSet9.Tables[0].Rows[n]["SysDate"].ToString());
							dataRow[0] = value4;
							dataRow[1] = dataSet9.Tables[0].Rows[n]["SysTime"].ToString();
							if (dataSet30.Tables[0].Rows.Count > 0)
							{
								dataRow[2] = dataSet30.Tables[0].Rows[0]["EmpName"].ToString();
							}
							dataRow[3] = num2;
							if (dataSet9.Tables[0].Rows[n]["WONo"].ToString() != "")
							{
								dataRow[5] = dataSet9.Tables[0].Rows[n]["WONo"].ToString();
							}
							else
							{
								dataRow[5] = "NA";
							}
							dataRow[7] = "PO No[" + text11 + "]";
							dataRow[8] = "GSN No[" + text10 + "]";
							dataRow[10] = CompId;
							dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet9.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet9.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet9.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%s"));
							dataRow[12] = fun.ShortDateTime(dataSet9.Tables[0].Rows[n]["SysDate"].ToString(), dataSet9.Tables[0].Rows[n]["SysTime"].ToString());
							dataRow[6] = 0;
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
				string cmdText26 = fun.select("tblInv_MaterialIssue_Details.IssueQty,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SysTime, tblInv_MaterialIssue_Master.SessionId,tblInv_MaterialRequisition_Master.SessionId As Session,tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialRequisition_Master.MRSNo,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialIssue_Master.MINNo=tblInv_MaterialIssue_Details.MINNo AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialIssue_Master.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId AND tblInv_MaterialRequisition_Details.Id= tblInv_MaterialIssue_Details.MRSId AND tblInv_MaterialRequisition_Details.ItemId='" + Id + "' AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.SysDate between '" + fun.FromDate(Fdate) + "' AND '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand26 = new SqlCommand(cmdText26, sqlConnection);
				SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand26);
				sqlDataAdapter26.Fill(dataSet8);
				for (int num3 = 0; num3 < dataSet8.Tables[0].Rows.Count; num3++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText27 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet8.Tables[0].Rows[num3]["SessionId"], "'"));
					SqlCommand selectCommand27 = new SqlCommand(cmdText27, sqlConnection);
					SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand27);
					DataSet dataSet31 = new DataSet();
					sqlDataAdapter27.Fill(dataSet31);
					string cmdText28 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet8.Tables[0].Rows[num3]["SessionId"], "'"));
					SqlCommand selectCommand28 = new SqlCommand(cmdText28, sqlConnection);
					SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(selectCommand28);
					DataSet dataSet32 = new DataSet();
					sqlDataAdapter28.Fill(dataSet32);
					string cmdText29 = fun.select("Symbol  As Dept ", "tblHR_Departments", string.Concat(" Id='", dataSet8.Tables[0].Rows[num3]["DeptId"], "'"));
					SqlCommand selectCommand29 = new SqlCommand(cmdText29, sqlConnection);
					SqlDataAdapter sqlDataAdapter29 = new SqlDataAdapter(selectCommand29);
					DataSet dataSet33 = new DataSet();
					sqlDataAdapter29.Fill(dataSet33);
					string value5 = fun.FromDateDMY(dataSet8.Tables[0].Rows[num3]["SysDate"].ToString());
					string text12 = dataSet8.Tables[0].Rows[num3]["MRSNo"].ToString();
					string text13 = dataSet8.Tables[0].Rows[num3]["MINNo"].ToString();
					dataRow[0] = value5;
					dataRow[1] = dataSet8.Tables[0].Rows[num3]["SysTime"].ToString();
					if (dataSet32.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet32.Tables[0].Rows[0]["EmpName"].ToString();
					}
					if (dataSet33.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet33.Tables[0].Rows[0]["Dept"].ToString();
					}
					if (dataSet8.Tables[0].Rows[num3]["WONo"].ToString() != "")
					{
						dataRow[5] = dataSet8.Tables[0].Rows[num3]["WONo"].ToString();
					}
					else
					{
						dataRow[5] = "NA";
					}
					if (dataSet8.Tables[0].Rows[num3]["IssueQty"] != DBNull.Value && dataSet8.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[num3]["IssueQty"].ToString()).ToString("N3"));
					}
					else
					{
						dataRow[6] = 0;
					}
					dataRow[7] = "MRS No[" + text12 + "]";
					dataRow[8] = "MIN No[" + text13 + "]";
					if (dataSet31.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet31.Tables[0].Rows[0]["EName"].ToString();
					}
					dataRow[10] = CompId;
					dataRow[3] = 0;
					dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet8.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet8.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet8.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%s"));
					dataRow[12] = fun.ShortDateTime(dataSet8.Tables[0].Rows[num3]["SysDate"].ToString(), dataSet8.Tables[0].Rows[num3]["SysTime"].ToString());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				string cmdText30 = fun.select("tblInv_WIS_Master.SysDate,tblInv_WIS_Master.SysTime, tblInv_WIS_Master.SessionId,tblInv_WIS_Master.WISNo,tblInv_WIS_Master.WONo,tblInv_WIS_Details.PId,tblInv_WIS_Details.CId,tblInv_WIS_Details.ItemId,tblInv_WIS_Details.IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.WISNo=tblInv_WIS_Details.WISNo   AND tblInv_WIS_Details.ItemId='" + Id + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Master.SysDate between '" + fun.FromDate(Fdate) + "' AND '" + fun.FromDate(Tdate) + "'");
				SqlCommand selectCommand30 = new SqlCommand(cmdText30, sqlConnection);
				SqlDataAdapter sqlDataAdapter30 = new SqlDataAdapter(selectCommand30);
				sqlDataAdapter30.Fill(dataSet10);
				for (int num4 = 0; num4 < dataSet10.Tables[0].Rows.Count; num4++)
				{
					DataRow dataRow = dataTable.NewRow();
					string text14 = "";
					text14 = fun.FromDateDMY(dataSet10.Tables[0].Rows[num4]["SysDate"].ToString());
					string text15 = "";
					text15 = dataSet10.Tables[0].Rows[num4]["WISNo"].ToString();
					dataRow[0] = text14;
					dataRow[1] = dataSet10.Tables[0].Rows[num4]["SysTime"].ToString();
					string cmdText31 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet10.Tables[0].Rows[num4]["SessionId"], "'"));
					SqlCommand selectCommand31 = new SqlCommand(cmdText31, sqlConnection);
					SqlDataAdapter sqlDataAdapter31 = new SqlDataAdapter(selectCommand31);
					DataSet dataSet34 = new DataSet();
					sqlDataAdapter31.Fill(dataSet34);
					if (dataSet34.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet34.Tables[0].Rows[0]["EName"].ToString();
						dataRow[9] = dataSet34.Tables[0].Rows[0]["EName"].ToString();
					}
					if (dataSet10.Tables[0].Rows[num4]["WONo"].ToString() != "")
					{
						dataRow[5] = dataSet10.Tables[0].Rows[num4]["WONo"].ToString();
					}
					else
					{
						dataRow[5] = "NA";
					}
					if (dataSet10.Tables[0].Rows[num4]["IssuedQty"] != DBNull.Value)
					{
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[num4]["IssuedQty"].ToString()).ToString("N3"));
					}
					else
					{
						dataRow[6] = 0;
					}
					dataRow[7] = "WIS No[" + text15 + "]";
					dataRow[11] = Convert.ToDouble(DateTime.Parse(dataSet10.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%H")) * 60.0 * 60.0 * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet10.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%m")) * 60.0 + Convert.ToDouble(DateTime.Parse(dataSet10.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%s"));
					dataRow[4] = "NA";
					dataRow[10] = CompId;
					dataRow[12] = fun.ShortDateTime(dataSet10.Tables[0].Rows[num4]["SysDate"].ToString(), dataSet10.Tables[0].Rows[num4]["SysTime"].ToString());
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				if (dataTable.Rows.Count > 0)
				{
					DataView defaultView = dataTable.DefaultView;
					defaultView.Sort = "SortDateTime DESC ";
					dataTable = defaultView.ToTable();
				}
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				string text16 = "";
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = 0.0;
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = 0.0;
				double num20 = 0.0;
				double num21 = 0.0;
				double num22 = 0.0;
				num11 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num12 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num13 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num22 = Convert.ToDouble(decimal.Parse(fun.MCNQA_QTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num14 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num15 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num19 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				num20 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
				string cmdText32 = fun.select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand32 = new SqlCommand(cmdText32, sqlConnection);
				SqlDataAdapter sqlDataAdapter32 = new SqlDataAdapter(selectCommand32);
				sqlDataAdapter32.Fill(dataSet11, "tblFinancial_master");
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					text16 = dataSet11.Tables[0].Rows[0][0].ToString();
				}
				if (Convert.ToDateTime(text16) == Convert.ToDateTime(fun.FromDate(Fdate)))
				{
					string cmdText33 = fun.select("OpeningBalQty", "tblDG_Item_Master", "Id='" + Id + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand33 = new SqlCommand(cmdText33, sqlConnection);
					SqlDataAdapter sqlDataAdapter33 = new SqlDataAdapter(selectCommand33);
					sqlDataAdapter33.Fill(dataSet12);
					if (dataSet12.Tables[0].Rows.Count > 0)
					{
						num5 = Convert.ToDouble(decimal.Parse(dataSet12.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					num6 = Math.Round(num5 + num11 + num12 + num13 + num22 + num19 + num20 - (num14 + num15), 5);
				}
				else if (Convert.ToDateTime(fun.FromDate(Fdate)) > Convert.ToDateTime(text16))
				{
					double num23 = 0.0;
					string cmdText34 = fun.select("OpeningBalQty", "tblDG_Item_Master", "Id='" + Id + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand34 = new SqlCommand(cmdText34, sqlConnection);
					SqlDataAdapter sqlDataAdapter34 = new SqlDataAdapter(selectCommand34);
					sqlDataAdapter34.Fill(dataSet13);
					if (dataSet13.Tables[0].Rows.Count > 0)
					{
						num23 = Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					string text17 = fun.FromDate(Convert.ToDateTime(fun.FromDate(Fdate)).AddDays(-1.0).ToShortDateString()
						.Replace("/", "-"));
					string[] array = text17.Split('-');
					string text18 = Convert.ToDouble(array[2]).ToString("D2") + "-" + Convert.ToDouble(array[1]).ToString("D2") + "-" + array[0];
					num7 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num8 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num9 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num21 = Convert.ToDouble(decimal.Parse(fun.MCNQA_QTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num10 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num16 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num17 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num18 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num5 = num23 + num7 + num8 + num9 + num21 + num18 + num17 - (num10 + num16);
					num6 = Math.Round(num5 + (num11 + num12 + num13 + num22 + num20 + num19) - (num14 + num15), 5);
				}
				string text19 = base.Server.MapPath("~/Module/Inventory/Reports/Stock_Ledger.rpt");
				cryRpt.Load(text19);
				cryRpt.SetDataSource(dataTable);
				string text20 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text20);
				cryRpt.SetParameterValue("Fdate", (object)Fdate);
				cryRpt.SetParameterValue("Tdate", (object)Tdate);
				cryRpt.SetParameterValue("OpenQty", (object)num5);
				cryRpt.SetParameterValue("ClosingQty", (object)num6);
				cryRpt.SetParameterValue("ItemCode", (object)ItemCode);
				cryRpt.SetParameterValue("Desc", (object)desc);
				cryRpt.SetParameterValue("Unit", (object)unit);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataSet.Dispose();
				dataSet2.Dispose();
				dataTable.Dispose();
				dataSet3.Dispose();
				dataSet4.Dispose();
				dataSet5.Dispose();
				dataSet6.Dispose();
				dataSet7.Dispose();
				dataSet8.Dispose();
				dataSet9.Dispose();
				dataSet10.Dispose();
				dataSet11.Dispose();
				dataSet12.Dispose();
				dataSet13.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("StockLedger.aspx?ModId=9");
	}
}

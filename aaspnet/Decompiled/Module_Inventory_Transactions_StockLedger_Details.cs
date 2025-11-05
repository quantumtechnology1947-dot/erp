using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_StockLedger_Details : Page, IRequiresSessionState
{
	protected Label Lblitem;

	protected Label LblUnit;

	protected LinkButton btnlnkImg;

	protected LinkButton btnlnkSpec;

	protected Label LblDesc;

	protected Label LblFromDate;

	protected Label LblToDate;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Label lbl1;

	protected Label lblopeningQty;

	protected Label lblRqty;

	protected Label lblIqty;

	protected Label lbl2;

	protected Label lblclosingQty;

	protected Button BtnPrint;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string Fdate = "";

	private string Tdate = "";

	private int Id;

	private int FinAcc;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			double num = 0.0;
			double num2 = 0.0;
			Id = Convert.ToInt32(base.Request.QueryString["Id"]);
			Fdate = base.Request.QueryString["FD"].ToString();
			Tdate = base.Request.QueryString["TD"].ToString();
			string cmdText = fun.select("FinYearId", "tblFinancial_master", "CompId='" + CompId + "'Order By FinYearId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				FinAcc = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
			}
			string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "FinYearId<='" + FinYearId + "'AND CompId='" + CompId + "' AND Id='" + Id + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			Lblitem.Text = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
			LblDesc.Text = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
			if (dataSet2.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet2.Tables[0].Rows[0]["FileName"] != DBNull.Value)
			{
				btnlnkImg.Text = "View";
			}
			else
			{
				btnlnkImg.Text = "";
			}
			if (dataSet2.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet2.Tables[0].Rows[0]["AttName"] != DBNull.Value)
			{
				btnlnkSpec.Text = "View";
			}
			else
			{
				btnlnkSpec.Text = "";
			}
			string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			LblUnit.Text = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
			LblFromDate.Text = Fdate;
			LblToDate.Text = Tdate;
			DataTable dataTable = new DataTable();
			string cmdText4 = fun.select("tblQc_MaterialReturnQuality_Master.SysDate ,tblInv_MaterialReturn_Master.MRNNo, tblQc_MaterialReturnQuality_Master.MRQNNo,tblQc_MaterialReturnQuality_Master.SysTime,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblInv_MaterialReturn_Master.SessionId,tblQc_MaterialReturnQuality_Master.SessionId AS session,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo ", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master,tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblQc_MaterialReturnQuality_Master.MRQNNo= tblQc_MaterialReturnQuality_Details.MRQNNo AND tblQc_MaterialReturnQuality_Master.Id= tblQc_MaterialReturnQuality_Details.MId  AND  tblInv_MaterialReturn_Master.MRNNo=tblInv_MaterialReturn_Details.MRNNo  AND  tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId  AND tblInv_MaterialReturn_Master.Id=tblQc_MaterialReturnQuality_Master.MRNId AND tblInv_MaterialReturn_Master.MRNNo=tblQc_MaterialReturnQuality_Master.MRNNo AND tblInv_MaterialReturn_Details.Id=tblQc_MaterialReturnQuality_Details.MRNId AND tblInv_MaterialReturn_Details.ItemId='" + Id + "'AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  And tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' And tblQc_MaterialReturnQuality_Master.SysDate  between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
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
			dataTable.Columns.Add(new DataColumn("Sum", typeof(string)));
			dataTable.Columns.Add(new DataColumn("seconds", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SortDateTime", typeof(string)));
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet4.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText5 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet4.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet5.Tables[0].Rows[0]["EName"].ToString();
					}
					string cmdText6 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet4.Tables[0].Rows[i]["session"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, connection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet6.Tables[0].Rows[0]["EmpName"].ToString();
					}
					string cmdText7 = fun.select("Symbol  As Dept ", "BusinessGroup", string.Concat(" Id='", dataSet4.Tables[0].Rows[i]["DeptId"], "'"));
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, connection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					string text = dataSet4.Tables[0].Rows[i]["MRNNo"].ToString();
					string text2 = dataSet4.Tables[0].Rows[i]["MRQNNo"].ToString();
					dataRow[0] = fun.FromDateDMY(dataSet4.Tables[0].Rows[i]["SysDate"].ToString());
					dataRow[1] = dataSet4.Tables[0].Rows[i]["SysTime"].ToString();
					if (dataSet4.Tables[0].Rows[i]["AcceptedQty"] != DBNull.Value)
					{
						dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[i]["AcceptedQty"].ToString()).ToString("N3"));
					}
					else
					{
						dataRow[3] = 0;
					}
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet7.Tables[0].Rows[0]["Dept"].ToString();
					}
					if (dataSet4.Tables[0].Rows[i]["WONo"].ToString() != "")
					{
						dataRow[5] = dataSet4.Tables[0].Rows[i]["WONo"].ToString();
					}
					else
					{
						dataRow[5] = "NA";
					}
					dataRow[7] = "MRN No[" + text + "]";
					dataRow[8] = "MRQN No[" + text2 + "]";
					dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet4.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet4.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet4.Tables[0].Rows[i]["SysTime"].ToString()).ToString("%s"));
					dataRow[12] = fun.ShortDateTime(dataSet4.Tables[0].Rows[i]["SysDate"].ToString(), dataSet4.Tables[0].Rows[i]["SysTime"].ToString());
					dataRow[6] = 0;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			string cmdText8 = "SELECT tblPM_MaterialCreditNote_Details.MCNQty, tblQc_AuthorizedMCN.QAQty, tblQc_AuthorizedMCN.SysDate,tblQc_AuthorizedMCN.SysTime,tblPM_MaterialCreditNote_Master.SessionId AS TransBy, tblQc_AuthorizedMCN.SessionId AS ProcBy, tblPM_MaterialCreditNote_Master.WONo,tblPM_MaterialCreditNote_Master.MCNNo FROM tblPM_MaterialCreditNote_Details INNER JOIN tblPM_MaterialCreditNote_Master ON tblPM_MaterialCreditNote_Details.MId = tblPM_MaterialCreditNote_Master.Id INNER JOIN tblQc_AuthorizedMCN ON tblPM_MaterialCreditNote_Details.Id = tblQc_AuthorizedMCN.MCNDId AND  tblPM_MaterialCreditNote_Details.MId = tblQc_AuthorizedMCN.MCNId INNER JOIN  tblDG_BOM_Master ON tblPM_MaterialCreditNote_Master.WONo = tblDG_BOM_Master.WONo AND tblPM_MaterialCreditNote_Details.PId = tblDG_BOM_Master.PId AND tblPM_MaterialCreditNote_Details.CId = tblDG_BOM_Master.CId AND tblQc_AuthorizedMCN.CompId='" + CompId + "' AND tblQc_AuthorizedMCN.SysDate  between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' AND tblDG_BOM_Master.ItemId='" + Id + "'";
			SqlCommand selectCommand8 = new SqlCommand(cmdText8, connection);
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
			DataSet dataSet8 = new DataSet();
			sqlDataAdapter8.Fill(dataSet8);
			if (dataSet8.Tables[0].Rows.Count > 0)
			{
				for (int j = 0; j < dataSet8.Tables[0].Rows.Count; j++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText9 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet8.Tables[0].Rows[j]["TransBy"], "'"));
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, connection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter9.Fill(dataSet9);
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet9.Tables[0].Rows[0]["EName"].ToString();
					}
					string cmdText10 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet8.Tables[0].Rows[j]["ProcBy"], "'"));
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, connection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet10.Tables[0].Rows[0]["EmpName"].ToString();
					}
					string text3 = dataSet8.Tables[0].Rows[j]["MCNNo"].ToString();
					dataRow[0] = fun.FromDateDMY(dataSet8.Tables[0].Rows[j]["SysDate"].ToString());
					dataRow[1] = dataSet8.Tables[0].Rows[j]["SysTime"].ToString();
					dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[j]["QAQty"].ToString()).ToString("N3"));
					dataRow[4] = "NA";
					dataRow[5] = dataSet8.Tables[0].Rows[j]["WONo"].ToString();
					dataRow[7] = "MCN No[" + text3 + "]";
					dataRow[8] = "MCN No[" + text3 + "]";
					dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet8.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet8.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet8.Tables[0].Rows[j]["SysTime"].ToString()).ToString("%s"));
					dataRow[12] = fun.ShortDateTime(dataSet8.Tables[0].Rows[j]["SysDate"].ToString(), dataSet8.Tables[0].Rows[j]["SysTime"].ToString());
					dataRow[6] = 0;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			string cmdText11 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty,tblMM_SPR_Details.DeptId,tblMM_PO_Master.PONo,tblMM_SPR_Details.WONo, tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SysTime,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Master.SessionId,tblMM_PO_Master.SessionId As  session , tblMM_SPR_Details.AHId ", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master", "tblQc_MaterialQuality_Master.GQNNo=tblQc_MaterialQuality_Details.GQNNo And tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And  tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId  And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo   And tblMM_SPR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='1'      And tblQc_MaterialQuality_Master.CompId='" + CompId + "' And tblQc_MaterialQuality_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand11 = new SqlCommand(cmdText11, connection);
			SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
			DataSet dataSet11 = new DataSet();
			sqlDataAdapter11.Fill(dataSet11);
			if (dataSet11.Tables[0].Rows.Count > 0)
			{
				for (int k = 0; k < dataSet11.Tables[0].Rows.Count; k++)
				{
					string cmdText12 = fun.select("*", "AccHead", "Id='" + dataSet11.Tables[0].Rows[k]["AHId"].ToString() + "'  ");
					SqlCommand selectCommand12 = new SqlCommand(cmdText12, connection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter12.Fill(dataSet12);
					if (dataSet12.Tables[0].Rows.Count > 0 && dataSet12.Tables[0].Rows[0]["Category"].ToString() == "With Material")
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText13 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet11.Tables[0].Rows[k]["session"], "'"));
						SqlCommand selectCommand13 = new SqlCommand(cmdText13, connection);
						SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
						DataSet dataSet13 = new DataSet();
						sqlDataAdapter13.Fill(dataSet13);
						if (dataSet13.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet13.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText14 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet11.Tables[0].Rows[k]["SessionId"], "'"));
						SqlCommand selectCommand14 = new SqlCommand(cmdText14, connection);
						SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
						DataSet dataSet14 = new DataSet();
						sqlDataAdapter14.Fill(dataSet14);
						string cmdText15 = fun.select("Symbol  As Dept ", "BusinessGroup", string.Concat(" Id='", dataSet11.Tables[0].Rows[k]["DeptId"], "'"));
						SqlCommand selectCommand15 = new SqlCommand(cmdText15, connection);
						SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
						DataSet dataSet15 = new DataSet();
						sqlDataAdapter15.Fill(dataSet15);
						num = ((dataSet11.Tables[0].Rows[k]["AcceptedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet11.Tables[0].Rows[k]["AcceptedQty"].ToString()).ToString("N3")));
						string text4 = dataSet11.Tables[0].Rows[k]["GQNNo"].ToString();
						string text5 = dataSet11.Tables[0].Rows[k]["PONo"].ToString();
						string value = fun.FromDateDMY(dataSet11.Tables[0].Rows[k]["SysDate"].ToString());
						dataRow[0] = value;
						dataRow[1] = dataSet11.Tables[0].Rows[k]["SysTime"].ToString();
						if (dataSet14.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet14.Tables[0].Rows[0]["EmpName"].ToString();
						}
						dataRow[3] = num;
						if (dataSet15.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet15.Tables[0].Rows[0]["Dept"].ToString();
						}
						if (dataSet11.Tables[0].Rows[k]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet11.Tables[0].Rows[k]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text5 + "]";
						dataRow[8] = "GQN No[" + text4 + "]";
						dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet11.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet11.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet11.Tables[0].Rows[k]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet11.Tables[0].Rows[k]["SysDate"].ToString(), dataSet11.Tables[0].Rows[k]["SysTime"].ToString());
						dataRow[6] = 0;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			string cmdText16 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty,tblMM_PR_Master.WONo,tblQc_MaterialQuality_Master.GQNNo,tblMM_PO_Master.PONo,tblQc_MaterialQuality_Master.SysDate,tblQc_MaterialQuality_Master.SysTime,tblQc_MaterialQuality_Master.SessionId,tblMM_PO_Master.SessionId As  session,tblMM_PR_Details.AHId ", "tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblQc_MaterialQuality_Master.GQNNo=tblQc_MaterialQuality_Details.GQNNo AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo And tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId And tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNo And tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId And tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo=tblMM_PO_Details.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='0' And tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand16 = new SqlCommand(cmdText16, connection);
			SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
			DataSet dataSet16 = new DataSet();
			sqlDataAdapter16.Fill(dataSet16);
			if (dataSet16.Tables[0].Rows.Count > 0)
			{
				for (int l = 0; l < dataSet16.Tables[0].Rows.Count; l++)
				{
					string cmdText17 = fun.select("*", "AccHead", "Id='" + dataSet16.Tables[0].Rows[l]["AHId"].ToString() + "'");
					SqlCommand selectCommand17 = new SqlCommand(cmdText17, connection);
					SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
					DataSet dataSet17 = new DataSet();
					sqlDataAdapter17.Fill(dataSet17, "AccHead");
					if (dataSet17.Tables[0].Rows.Count > 0 && dataSet17.Tables[0].Rows[0]["Category"].ToString() == "With Material")
					{
						DataRow dataRow = dataTable.NewRow();
						num2 = ((dataSet16.Tables[0].Rows[l]["AcceptedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[l]["AcceptedQty"].ToString()).ToString("N3")));
						string cmdText18 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet16.Tables[0].Rows[l]["session"], "'"));
						SqlCommand selectCommand18 = new SqlCommand(cmdText18, connection);
						SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
						DataSet dataSet18 = new DataSet();
						sqlDataAdapter18.Fill(dataSet18);
						if (dataSet18.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet18.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText19 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet16.Tables[0].Rows[l]["SessionId"], "'"));
						SqlCommand selectCommand19 = new SqlCommand(cmdText19, connection);
						SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
						DataSet dataSet19 = new DataSet();
						sqlDataAdapter19.Fill(dataSet19);
						string text6 = dataSet16.Tables[0].Rows[l]["GQNNo"].ToString();
						string text7 = dataSet16.Tables[0].Rows[l]["PONo"].ToString();
						string value2 = fun.FromDateDMY(dataSet16.Tables[0].Rows[l]["SysDate"].ToString());
						dataRow[0] = value2;
						dataRow[1] = dataSet16.Tables[0].Rows[l]["SysTime"].ToString();
						if (dataSet19.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet19.Tables[0].Rows[0]["EmpName"].ToString();
						}
						dataRow[3] = num2;
						if (dataSet16.Tables[0].Rows[l]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet16.Tables[0].Rows[l]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text7 + "]";
						dataRow[8] = "GQN No[" + text6 + "]";
						dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet16.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet16.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet16.Tables[0].Rows[l]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet16.Tables[0].Rows[l]["SysDate"].ToString(), dataSet16.Tables[0].Rows[l]["SysTime"].ToString());
						dataRow[6] = 0;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			string cmdText20 = fun.select(" tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.SysTime,tblinv_MaterialServiceNote_Master.SessionId,tblMM_SPR_Details.DeptId,tblMM_PO_Master.PONo,tblMM_SPR_Details.WONo, tblMM_PO_Master.SessionId As session  , tblMM_SPR_Details.AHId ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_SPR_Details,tblMM_SPR_Master   ", "tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo And tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Master.SPRNo And tblMM_SPR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='1' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "'And tblinv_MaterialServiceNote_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' ");
			SqlCommand selectCommand20 = new SqlCommand(cmdText20, connection);
			SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
			DataSet dataSet20 = new DataSet();
			sqlDataAdapter20.Fill(dataSet20);
			if (dataSet20.Tables[0].Rows.Count > 0)
			{
				for (int m = 0; m < dataSet20.Tables[0].Rows.Count; m++)
				{
					string cmdText21 = fun.select("*", "AccHead", "Id='" + dataSet20.Tables[0].Rows[m]["AHId"].ToString() + "'");
					SqlCommand selectCommand21 = new SqlCommand(cmdText21, connection);
					SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
					DataSet dataSet21 = new DataSet();
					sqlDataAdapter21.Fill(dataSet21);
					if (dataSet21.Tables[0].Rows.Count > 0 && dataSet21.Tables[0].Rows[0]["Category"].ToString() == "Labour")
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText22 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet20.Tables[0].Rows[m]["session"], "'"));
						SqlCommand selectCommand22 = new SqlCommand(cmdText22, connection);
						SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
						DataSet dataSet22 = new DataSet();
						sqlDataAdapter22.Fill(dataSet22);
						if (dataSet22.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet22.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText23 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet20.Tables[0].Rows[m]["SessionId"], "'"));
						SqlCommand selectCommand23 = new SqlCommand(cmdText23, connection);
						SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
						DataSet dataSet23 = new DataSet();
						sqlDataAdapter23.Fill(dataSet23);
						string cmdText24 = fun.select("Symbol  As Dept ", "BusinessGroup", string.Concat(" Id='", dataSet20.Tables[0].Rows[m]["DeptId"], "'"));
						SqlCommand selectCommand24 = new SqlCommand(cmdText24, connection);
						SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand24);
						DataSet dataSet24 = new DataSet();
						sqlDataAdapter24.Fill(dataSet24);
						num = ((dataSet20.Tables[0].Rows[m]["ReceivedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet20.Tables[0].Rows[m]["ReceivedQty"].ToString()).ToString("N3")));
						string text8 = dataSet20.Tables[0].Rows[m]["GSNNo"].ToString();
						string text9 = dataSet20.Tables[0].Rows[m]["PONo"].ToString();
						string value3 = fun.FromDateDMY(dataSet20.Tables[0].Rows[m]["SysDate"].ToString());
						dataRow[0] = value3;
						dataRow[1] = dataSet20.Tables[0].Rows[m]["SysTime"].ToString();
						if (dataSet23.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet23.Tables[0].Rows[0]["EmpName"].ToString();
						}
						dataRow[3] = num;
						if (dataSet24.Tables[0].Rows.Count > 0)
						{
							dataRow[4] = dataSet24.Tables[0].Rows[0]["Dept"].ToString();
						}
						if (dataSet20.Tables[0].Rows[m]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet20.Tables[0].Rows[m]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text9 + "]";
						dataRow[8] = "GSN No[" + text8 + "]";
						dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet20.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet20.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet20.Tables[0].Rows[m]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet20.Tables[0].Rows[m]["SysDate"].ToString(), dataSet20.Tables[0].Rows[m]["SysTime"].ToString());
						dataRow[6] = 0;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			string cmdText25 = fun.select("tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.SysDate,tblinv_MaterialServiceNote_Master.SysTime,tblinv_MaterialServiceNote_Master.SessionId,tblMM_PR_Master.WONo,tblMM_PO_Master.PONo,tblMM_PO_Master.SessionId As  session,tblMM_PR_Details.AHId ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblInv_Inward_Master ,tblInv_Inward_Details,tblMM_PO_Details,tblMM_PO_Master,tblMM_PR_Details,tblMM_PR_Master", "tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo And tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId And tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo And tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId And tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId And tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo And tblInv_Inward_Details.POId= tblinv_MaterialServiceNote_Details.POId And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Master.Id=tblMM_PO_Details.MId And tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblinv_MaterialServiceNote_Details.POId=tblMM_PO_Details.Id And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PO_Details.PRNo=tblMM_PR_Master.PRNo And      tblMM_PR_Details.ItemId='" + Id + "' And tblMM_PO_Master.PRSPRFlag='0' And tblinv_MaterialServiceNote_Master.CompId='" + CompId + "'And tblinv_MaterialServiceNote_Master.SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand25 = new SqlCommand(cmdText25, connection);
			SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand25);
			DataSet dataSet25 = new DataSet();
			sqlDataAdapter25.Fill(dataSet25);
			if (dataSet25.Tables[0].Rows.Count > 0)
			{
				for (int n = 0; n < dataSet25.Tables[0].Rows.Count; n++)
				{
					string cmdText26 = fun.select("*", "AccHead", "Id='" + dataSet25.Tables[0].Rows[n]["AHId"].ToString() + "'  ");
					SqlCommand selectCommand26 = new SqlCommand(cmdText26, connection);
					SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand26);
					DataSet dataSet26 = new DataSet();
					sqlDataAdapter26.Fill(dataSet26, "AccHead");
					if (dataSet26.Tables[0].Rows.Count > 0 && dataSet26.Tables[0].Rows[0]["Category"].ToString() == "Labour")
					{
						DataRow dataRow = dataTable.NewRow();
						num2 = ((dataSet25.Tables[0].Rows[n]["ReceivedQty"] == DBNull.Value) ? 0.0 : Convert.ToDouble(decimal.Parse(dataSet25.Tables[0].Rows[n]["ReceivedQty"].ToString()).ToString("N3")));
						string cmdText27 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet25.Tables[0].Rows[n]["session"], "'"));
						SqlCommand selectCommand27 = new SqlCommand(cmdText27, connection);
						SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand27);
						DataSet dataSet27 = new DataSet();
						sqlDataAdapter27.Fill(dataSet27);
						if (dataSet27.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet27.Tables[0].Rows[0]["EName"].ToString();
						}
						string cmdText28 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet25.Tables[0].Rows[n]["SessionId"], "'"));
						SqlCommand selectCommand28 = new SqlCommand(cmdText28, connection);
						SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(selectCommand28);
						DataSet dataSet28 = new DataSet();
						sqlDataAdapter28.Fill(dataSet28);
						string text10 = dataSet25.Tables[0].Rows[n]["GSNNo"].ToString();
						string text11 = dataSet25.Tables[0].Rows[n]["PONo"].ToString();
						string value4 = fun.FromDateDMY(dataSet25.Tables[0].Rows[n]["SysDate"].ToString());
						dataRow[0] = value4;
						dataRow[1] = dataSet25.Tables[0].Rows[n]["SysTime"].ToString();
						if (dataSet28.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet28.Tables[0].Rows[0]["EmpName"].ToString();
						}
						dataRow[3] = num2;
						if (dataSet25.Tables[0].Rows[n]["WONo"].ToString() != "")
						{
							dataRow[5] = dataSet25.Tables[0].Rows[n]["WONo"].ToString();
						}
						else
						{
							dataRow[5] = "NA";
						}
						dataRow[7] = "PO No[" + text11 + "]";
						dataRow[8] = "GSN No[" + text10 + "]";
						dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet25.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet25.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet25.Tables[0].Rows[n]["SysTime"].ToString()).ToString("%s"));
						dataRow[12] = fun.ShortDateTime(dataSet25.Tables[0].Rows[n]["SysDate"].ToString(), dataSet25.Tables[0].Rows[n]["SysTime"].ToString());
						dataRow[6] = 0;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			string cmdText29 = fun.select("tblInv_MaterialIssue_Details.IssueQty,tblInv_MaterialIssue_Master.SysDate,tblInv_MaterialIssue_Master.SysTime, tblInv_MaterialIssue_Master.SessionId,tblInv_MaterialRequisition_Master.SessionId As Session,tblInv_MaterialIssue_Master.MINNo,tblInv_MaterialRequisition_Master.MRSNo,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialIssue_Master.MINNo=tblInv_MaterialIssue_Details.MINNo AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialIssue_Master.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialIssue_Master.MRSId AND tblInv_MaterialRequisition_Details.Id= tblInv_MaterialIssue_Details.MRSId AND tblInv_MaterialRequisition_Details.ItemId='" + Id + "' AND tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.SysDate between '" + fun.FromDate(Fdate) + "' AND '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand29 = new SqlCommand(cmdText29, connection);
			SqlDataAdapter sqlDataAdapter29 = new SqlDataAdapter(selectCommand29);
			DataSet dataSet29 = new DataSet();
			sqlDataAdapter29.Fill(dataSet29);
			for (int num3 = 0; num3 < dataSet29.Tables[0].Rows.Count; num3++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText30 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet29.Tables[0].Rows[num3]["Session"], "'"));
				SqlCommand selectCommand30 = new SqlCommand(cmdText30, connection);
				SqlDataAdapter sqlDataAdapter30 = new SqlDataAdapter(selectCommand30);
				DataSet dataSet30 = new DataSet();
				sqlDataAdapter30.Fill(dataSet30);
				string cmdText31 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet29.Tables[0].Rows[num3]["SessionId"], "'"));
				SqlCommand selectCommand31 = new SqlCommand(cmdText31, connection);
				SqlDataAdapter sqlDataAdapter31 = new SqlDataAdapter(selectCommand31);
				DataSet dataSet31 = new DataSet();
				sqlDataAdapter31.Fill(dataSet31);
				string cmdText32 = fun.select("Symbol  As Dept ", "BusinessGroup", string.Concat(" Id='", dataSet29.Tables[0].Rows[num3]["DeptId"], "'"));
				SqlCommand selectCommand32 = new SqlCommand(cmdText32, connection);
				SqlDataAdapter sqlDataAdapter32 = new SqlDataAdapter(selectCommand32);
				DataSet dataSet32 = new DataSet();
				sqlDataAdapter32.Fill(dataSet32);
				string value5 = fun.FromDateDMY(dataSet29.Tables[0].Rows[num3]["SysDate"].ToString());
				string text12 = dataSet29.Tables[0].Rows[num3]["MRSNo"].ToString();
				string text13 = dataSet29.Tables[0].Rows[num3]["MINNo"].ToString();
				dataRow[0] = value5;
				dataRow[1] = dataSet29.Tables[0].Rows[num3]["SysTime"].ToString();
				if (dataSet31.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet31.Tables[0].Rows[0]["EmpName"].ToString();
				}
				if (dataSet32.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet32.Tables[0].Rows[0]["Dept"].ToString();
				}
				if (dataSet29.Tables[0].Rows[num3]["WONo"].ToString() != "")
				{
					dataRow[5] = dataSet29.Tables[0].Rows[num3]["WONo"].ToString();
				}
				else
				{
					dataRow[5] = "NA";
				}
				if (dataSet29.Tables[0].Rows[num3]["IssueQty"] != DBNull.Value)
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet29.Tables[0].Rows[num3]["IssueQty"].ToString()).ToString());
				}
				else
				{
					dataRow[6] = 0;
				}
				dataRow[7] = "MRS No[" + text12 + "]";
				dataRow[8] = "MIN No[" + text13 + "]";
				if (dataSet30.Tables[0].Rows.Count > 0)
				{
					dataRow[9] = dataSet30.Tables[0].Rows[0]["EName"].ToString();
				}
				dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet29.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet29.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet29.Tables[0].Rows[num3]["SysTime"].ToString()).ToString("%s"));
				dataRow[12] = fun.ShortDateTime(dataSet29.Tables[0].Rows[num3]["SysDate"].ToString(), dataSet29.Tables[0].Rows[num3]["SysTime"].ToString());
				dataRow[3] = 0;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			string cmdText33 = fun.select("tblInv_WIS_Master.SysDate,tblInv_WIS_Master.SysTime, tblInv_WIS_Master.SessionId,tblInv_WIS_Master.WISNo,tblInv_WIS_Master.WONo,tblInv_WIS_Details.PId,tblInv_WIS_Details.CId,tblInv_WIS_Details.ItemId,tblInv_WIS_Details.IssuedQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.Id=tblInv_WIS_Details.MId  AND tblInv_WIS_Details.ItemId='" + Id + "' AND tblInv_WIS_Master.CompId='" + CompId + "' AND tblInv_WIS_Master.SysDate between '" + fun.FromDate(Fdate) + "' AND '" + fun.FromDate(Tdate) + "'");
			SqlCommand selectCommand33 = new SqlCommand(cmdText33, connection);
			SqlDataAdapter sqlDataAdapter33 = new SqlDataAdapter(selectCommand33);
			DataSet dataSet33 = new DataSet();
			sqlDataAdapter33.Fill(dataSet33);
			for (int num4 = 0; num4 < dataSet33.Tables[0].Rows.Count; num4++)
			{
				DataRow dataRow = dataTable.NewRow();
				string text14 = "";
				text14 = fun.FromDateDMY(dataSet33.Tables[0].Rows[num4]["SysDate"].ToString());
				string text15 = "";
				text15 = dataSet33.Tables[0].Rows[num4]["WISNo"].ToString();
				dataRow[0] = text14;
				dataRow[1] = dataSet33.Tables[0].Rows[num4]["SysTime"].ToString();
				string cmdText34 = fun.select("Title+'. '+EmployeeName As EName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet33.Tables[0].Rows[num4]["SessionId"], "'"));
				SqlCommand selectCommand34 = new SqlCommand(cmdText34, connection);
				SqlDataAdapter sqlDataAdapter34 = new SqlDataAdapter(selectCommand34);
				DataSet dataSet34 = new DataSet();
				sqlDataAdapter34.Fill(dataSet34);
				if (dataSet34.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet34.Tables[0].Rows[0]["EName"].ToString();
					dataRow[9] = dataSet34.Tables[0].Rows[0]["EName"].ToString();
				}
				if (dataSet33.Tables[0].Rows[num4]["WONo"].ToString() != "")
				{
					dataRow[5] = dataSet33.Tables[0].Rows[num4]["WONo"].ToString();
				}
				else
				{
					dataRow[5] = "NA";
				}
				if (dataSet33.Tables[0].Rows[num4]["IssuedQty"] != DBNull.Value)
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet33.Tables[0].Rows[num4]["IssuedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[6] = 0;
				}
				dataRow[7] = "WIS No[" + text15 + "]";
				dataRow[11] = Convert.ToInt32(DateTime.Parse(dataSet33.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%H")) * 60 * 60 * 60 + Convert.ToInt32(DateTime.Parse(dataSet33.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%m")) * 60 + Convert.ToInt32(DateTime.Parse(dataSet33.Tables[0].Rows[num4]["SysTime"].ToString()).ToString("%s"));
				dataRow[4] = "NA";
				dataRow[12] = fun.ShortDateTime(dataSet33.Tables[0].Rows[num4]["SysDate"].ToString(), dataSet33.Tables[0].Rows[num4]["SysTime"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			if (dataTable.Rows.Count > 0)
			{
				DataView defaultView = dataTable.DefaultView;
				defaultView.Sort = "SortDateTime DESC ";
				dataTable = defaultView.ToTable();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			double num5 = 0.0;
			double num6 = 0.0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((Label)row.FindControl("lblAcceptedQty")).Text != "")
				{
					num5 += Convert.ToDouble(((Label)row.FindControl("lblAcceptedQty")).Text);
				}
				if (((Label)row.FindControl("lblIssueQty")).Text != "")
				{
					num6 += Convert.ToDouble(((Label)row.FindControl("lblIssueQty")).Text);
				}
			}
			lblRqty.Text = num5.ToString();
			lblIqty.Text = num6.ToString();
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			string text16 = "";
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			double num24 = 0.0;
			double num25 = 0.0;
			num17 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num18 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num19 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num25 = Convert.ToDouble(decimal.Parse(fun.MCNQA_QTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num20 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num21 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num22 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			num23 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, Fdate, Tdate, Id.ToString()).ToString()).ToString("N3"));
			if (FinAcc == FinYearId)
			{
				string cmdText35 = fun.select("FinYearFrom, FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand35 = new SqlCommand(cmdText35, connection);
				SqlDataAdapter sqlDataAdapter35 = new SqlDataAdapter(selectCommand35);
				DataSet dataSet35 = new DataSet();
				sqlDataAdapter35.Fill(dataSet35, "tblFinancial_master");
				if (dataSet35.Tables[0].Rows.Count > 0)
				{
					text16 = dataSet35.Tables[0].Rows[0][0].ToString();
				}
				if (Convert.ToDateTime(text16) == Convert.ToDateTime(fun.FromDate(Fdate)))
				{
					string cmdText36 = fun.select("OpeningBalQty", "tblDG_Item_Master", "FinYearId<='" + FinYearId + "'AND Id='" + Id + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand36 = new SqlCommand(cmdText36, connection);
					SqlDataAdapter sqlDataAdapter36 = new SqlDataAdapter(selectCommand36);
					DataSet dataSet36 = new DataSet();
					sqlDataAdapter36.Fill(dataSet36);
					if (dataSet36.Tables[0].Rows.Count > 0)
					{
						num7 = Convert.ToDouble(decimal.Parse(dataSet36.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					num8 = Math.Round(num7 + num17 + num18 + num19 + num25 + num22 + num23 - (num20 + num21), 5);
				}
				else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(text16) || Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
				{
					string cmdText37 = fun.select("OpeningBalQty", "tblDG_Item_Master", "FinYearId<='" + FinYearId + "'AND Id='" + Id + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand37 = new SqlCommand(cmdText37, connection);
					SqlDataAdapter sqlDataAdapter37 = new SqlDataAdapter(selectCommand37);
					DataSet dataSet37 = new DataSet();
					sqlDataAdapter37.Fill(dataSet37);
					if (dataSet37.Tables[0].Rows.Count > 0)
					{
						num16 = Convert.ToDouble(decimal.Parse(dataSet37.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					string text17 = fun.FromDate(Convert.ToDateTime(fun.FromDate(Fdate)).AddDays(-1.0).ToShortDateString()
						.Replace("/", "-"));
					string[] array = text17.Split('-');
					string text18 = Convert.ToInt32(array[2]).ToString("D2") + "-" + Convert.ToInt32(array[1]).ToString("D2") + "-" + array[0];
					num9 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num10 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num13 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num24 = Convert.ToDouble(decimal.Parse(fun.MCNQA_QTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num11 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num12 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num14 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num15 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, fun.FromDateDMY(text16), text18.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num7 = num16 + num9 + num10 + num13 + num24 + num12 + num11 - (num14 + num15);
					num8 = Math.Round(num7 + (num17 + num18 + num19 + num25 + num23 + num22) - (num20 + num21), 5);
				}
			}
			else
			{
				string cmdText38 = fun.select("OpeningQty,OpeningDate", "tblDG_Item_Master_Clone", "ItemId='" + Id + "'And CompId='" + CompId + "'AND FinYearId='" + FinYearId + "'");
				SqlCommand selectCommand38 = new SqlCommand(cmdText38, connection);
				SqlDataAdapter sqlDataAdapter38 = new SqlDataAdapter(selectCommand38);
				DataSet dataSet38 = new DataSet();
				sqlDataAdapter38.Fill(dataSet38);
				if (Convert.ToDateTime(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()) == Convert.ToDateTime(fun.FromDate(Fdate)))
				{
					if (dataSet38.Tables[0].Rows.Count > 0)
					{
						num7 = Convert.ToDouble(decimal.Parse(dataSet38.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					num8 = Math.Round(num7 + num17 + num18 + num19 + num22 + num23 - (num20 + num21), 5);
				}
				else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()) || Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
				{
					if (dataSet38.Tables[0].Rows.Count > 0)
					{
						num16 = Convert.ToDouble(decimal.Parse(dataSet38.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					string text19 = fun.FromDate(Convert.ToDateTime(fun.FromDate(Fdate)).AddDays(-1.0).ToShortDateString()
						.Replace("/", "-"));
					string[] array2 = text19.Split('-');
					string text20 = Convert.ToInt32(array2[1]).ToString("D2") + "-" + array2[0] + "-" + Convert.ToInt32(array2[2]).ToString("D2");
					num9 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num10 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num13 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num24 = Convert.ToDouble(decimal.Parse(fun.MCNQA_QTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num11 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num12 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num14 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num15 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, fun.FromDateDMY(dataSet38.Tables[0].Rows[0]["OpeningDate"].ToString()), text20.ToString(), Id.ToString()).ToString()).ToString("N3"));
					num7 = num16;
					num8 = Math.Round(num7 + (num17 + num18 + num19 + num25 + num23 + num22) - (num20 + num21), 5);
				}
			}
			lblopeningQty.Text = Convert.ToString(num7);
			lblclosingQty.Text = Convert.ToString(num8);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("StockLedger.aspx?ModId=9");
	}

	protected void BtnPrint_Click(object sender, EventArgs e)
	{
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		base.Response.Redirect("StockLedger_Print.aspx?ModId=9&Id=" + Id + "&Fdate=" + Fdate + "&Tdate=" + Tdate + "&Key=" + randomAlphaNumeric);
	}

	protected void btnlnkImg_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + Id + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
	}

	protected void btnlnkSpec_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + Id + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
	}
}

using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Transactions_PO_PR_Print_Page : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private string SupCode = "";

	private string PoNo = "";

	private int cId;

	private string MId = "";

	private int Country;

	private int AmdNo;

	private int DBAmdNo;

	private string Key = string.Empty;

	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				MId = base.Request.QueryString["mid"].ToString();
				cId = Convert.ToInt32(Session["compid"]);
				PoNo = base.Request.QueryString["pono"].ToString();
				SupCode = base.Request.QueryString["Code"].ToString();
				AmdNo = Convert.ToInt32(base.Request.QueryString["AmdNo"].ToString());
				Key = base.Request.QueryString["Key"].ToString();
				loaddata();
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	public void loaddata()
	{
		//IL_299c: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a6: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		try
		{
			DataSet dataSet2 = new DataSet();
			int num = 0;
			string cmdText = "";
			string text = "";
			string cmdText2 = fun.select("AmendmentNo", "tblMM_PO_Master", "Id ='" + MId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				DBAmdNo = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0]);
				cmdText = ((AmdNo != DBAmdNo) ? fun.select("tblMM_PO_Amd_Master.Id,tblMM_PO_Amd_Details.PODId As PODId,tblMM_PO_Amd_Master.Insurance,tblMM_PO_Amd_Master.AuthorizeDate,tblMM_PO_Amd_Master.ApproveDate,tblMM_PO_Amd_Master.SysDate,tblMM_PO_Amd_Master.CheckedDate,tblMM_PO_Amd_Master.ReferenceDate,tblMM_PO_Amd_Master.CheckedBy,tblMM_PO_Amd_Master.ApprovedBy,tblMM_PO_Amd_Master.AuthorizedBy,tblMM_PO_Amd_Master.Id,tblMM_PO_Amd_Master.PONo,tblMM_PO_Amd_Master.ModeOfDispatch,tblMM_PO_Amd_Master.Inspection,tblMM_PO_Amd_Master.Remarks,tblMM_PO_Amd_Master.ShipTo,tblMM_PO_Amd_Master.Reference,tblMM_PO_Amd_Master.ReferenceDesc,tblMM_PO_Amd_Master.AmendmentNo,tblMM_PO_Amd_Details.Qty,tblMM_PO_Amd_Details.Rate,tblMM_PO_Amd_Details.Discount,tblMM_PO_Amd_Details.DelDate,tblMM_PO_Amd_Master.SupplierId,tblMM_PO_Amd_Master.Freight,tblMM_PO_Amd_Master.Octroi,tblMM_PO_Amd_Master.Warrenty,tblMM_PO_Amd_Master.PaymentTerms,tblMM_PO_Amd_Details.PF,tblMM_PO_Amd_Details.ExST,tblMM_PO_Amd_Details.VAT,tblMM_PO_Amd_Details.PRId,tblMM_PO_Amd_Details.BudgetCode,tblMM_PO_Amd_Details.AddDesc,TC", "tblMM_PO_Amd_Master,tblMM_PO_Amd_Details ", " tblMM_PO_Amd_Master.Id=tblMM_PO_Amd_Details.MId And tblMM_PO_Amd_Master.CompId='" + cId + "' AND tblMM_PO_Amd_Master.POId='" + MId + "' AND tblMM_PO_Amd_Master.AmendmentNo='" + AmdNo + "'") : fun.select("tblMM_PO_Details.Id As PODId,tblMM_PO_Master.Insurance,tblMM_PO_Master.AuthorizeDate,tblMM_PO_Master.ApproveDate,tblMM_PO_Master.SysDate,tblMM_PO_Master.CheckedDate,tblMM_PO_Master.ReferenceDate,tblMM_PO_Master.CheckedBy,tblMM_PO_Master.ApprovedBy,tblMM_PO_Master.AuthorizedBy,tblMM_PO_Master.Id,tblMM_PO_Master.PONo,tblMM_PO_Master.ModeOfDispatch,tblMM_PO_Master.Inspection,tblMM_PO_Master.Remarks,tblMM_PO_Master.ShipTo,tblMM_PO_Master.Reference,tblMM_PO_Master.ReferenceDesc,tblMM_PO_Master.AmendmentNo,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.DelDate,tblMM_PO_Master.SupplierId,tblMM_PO_Master.Freight,tblMM_PO_Master.Octroi,tblMM_PO_Master.Warrenty,tblMM_PO_Master.PaymentTerms,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Details.PRId,tblMM_PO_Details.BudgetCode,tblMM_PO_Details.AddDesc,TC", "tblMM_PO_Master,tblMM_PO_Details ", " tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + MId + "' And tblMM_PO_Master.CompId='" + cId + "' AND tblMM_PO_Master.Id='" + MId + "'"));
				if (AmdNo - 1 >= 0)
				{
					text = fun.select("tblMM_PO_Amd_Master.Id,tblMM_PO_Amd_Master.Insurance,tblMM_PO_Amd_Master.AuthorizeDate,tblMM_PO_Amd_Master.ApproveDate,tblMM_PO_Amd_Master.SysDate,tblMM_PO_Amd_Master.CheckedDate,tblMM_PO_Amd_Master.ReferenceDate,tblMM_PO_Amd_Master.CheckedBy,tblMM_PO_Amd_Master.ApprovedBy,tblMM_PO_Amd_Master.AuthorizedBy,tblMM_PO_Amd_Master.Id,tblMM_PO_Amd_Master.PONo,tblMM_PO_Amd_Master.ModeOfDispatch,tblMM_PO_Amd_Master.Inspection,tblMM_PO_Amd_Master.Remarks,tblMM_PO_Amd_Master.ShipTo,tblMM_PO_Amd_Master.Reference,tblMM_PO_Amd_Master.ReferenceDesc,tblMM_PO_Amd_Master.AmendmentNo,tblMM_PO_Amd_Master.SupplierId,tblMM_PO_Amd_Master.Freight,tblMM_PO_Amd_Master.Octroi,tblMM_PO_Amd_Master.Warrenty,tblMM_PO_Amd_Master.PaymentTerms,TC", "tblMM_PO_Amd_Master", "tblMM_PO_Amd_Master.CompId='" + cId + "' AND tblMM_PO_Amd_Master.POId='" + MId + "' AND tblMM_PO_Amd_Master.AmendmentNo='" + (AmdNo - 1) + "'");
					SqlCommand selectCommand2 = new SqlCommand(text, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2);
					num = 1;
				}
			}
			SqlCommand selectCommand3 = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter3.Fill(dataSet4);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(int)));
			dataTable.Columns.Add(new DataColumn("RefDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ModeOfDispatch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Inspection", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ShipTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SuplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("manfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OctriTerm", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OctriValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PackagingTerm", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PackagingValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PaymentTerm", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExciseTerm", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExciseValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VatTerm", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VatValue", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Warranty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Fright", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RefPODesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Indentor", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Insurance", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SuplierName*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VenderCode*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RefDate*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RefDesc*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RefPODesc*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PackagingValue*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExciseValue*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VatValue*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DelDate*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaymentTerm*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ModeOfDispatch*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Inspection*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OctriValue*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Warranty*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Fright*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Insurance*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ShipTo*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BudgetCode*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AddDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AddDesc*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty*", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TC*", typeof(string)));
			string value = "";
			string value2 = "";
			string value3 = "";
			if (dataSet4.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < dataSet4.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText3 = fun.select("RefDesc", "tblMM_PO_Reference", "Id='" + dataSet4.Tables[0].Rows[i]["Reference"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter4.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[7] = dataSet5.Tables[0].Rows[0][0].ToString();
				}
				dataRow[0] = dataSet4.Tables[0].Rows[i]["Id"];
				dataRow[1] = dataSet4.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[2] = dataSet4.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[3] = dataSet4.Tables[0].Rows[i]["Rate"].ToString();
				dataRow[4] = dataSet4.Tables[0].Rows[i]["Discount"].ToString();
				dataRow[5] = dataSet4.Tables[0].Rows[i]["DelDate"].ToString();
				dataRow[6] = dataSet4.Tables[0].Rows[i]["AmendmentNo"].ToString();
				dataRow[8] = dataSet4.Tables[0].Rows[i]["ModeOfDispatch"].ToString();
				dataRow[9] = dataSet4.Tables[0].Rows[i]["Inspection"].ToString();
				dataRow[10] = dataSet4.Tables[0].Rows[i]["ShipTo"].ToString();
				dataRow[11] = dataSet4.Tables[0].Rows[i]["Remarks"].ToString();
				string cmdText4 = fun.select("tblMM_PR_Master.SessionId AS Indentor,tblMM_PR_Details.PRNo,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId,tblMM_PR_Details.ItemId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Details.Id='" + dataSet4.Tables[0].Rows[i]["PRId"].ToString() + "' And tblMM_PR_Master.Id=tblMM_PR_Details.MId ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter5.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					dataRow[12] = dataSet6.Tables[0].Rows[0]["PRNo"].ToString();
					string cmdText5 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet6.Tables[0].Rows[0]["Indentor"].ToString() + "'And CompId='" + cId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter6.Fill(dataSet7, "tblHR_OfficeStaff");
					dataRow[35] = dataSet7.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet7.Tables[0].Rows[0]["EmployeeName"].ToString();
					if (dataSet6.Tables[0].Rows[0]["WONo"] != DBNull.Value)
					{
						dataRow[13] = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
						string cmdText6 = fun.select("*", "tblMIS_BudgetCode", "Id='" + dataSet4.Tables[0].Rows[i]["BudgetCode"].ToString() + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter7.Fill(dataSet8);
						if (dataSet8.Tables[0].Rows.Count > 0)
						{
							dataRow[36] = dataSet8.Tables[0].Rows[0]["Symbol"].ToString() + dataRow[13];
						}
					}
					else
					{
						dataRow[13] = "";
						dataRow[36] = "";
					}
					string cmdText7 = fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter8.Fill(dataSet9);
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(cId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
						value3 = dataSet9.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet9.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand9 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet10 = new DataSet();
						sqlDataAdapter9.Fill(dataSet10);
						if (dataSet10.Tables[0].Rows.Count > 0)
						{
							value2 = dataSet10.Tables[0].Rows[0][0].ToString();
						}
					}
					string cmdText9 = fun.select("Symbol", "AccHead", "Id='" + dataSet6.Tables[0].Rows[0]["AHId"].ToString() + "'");
					SqlCommand selectCommand10 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter10.Fill(dataSet11);
					if (dataSet11.Tables[0].Rows.Count > 0)
					{
						dataRow[22] = dataSet11.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				dataRow[14] = cId;
				dataRow[19] = value;
				dataRow[20] = value3;
				dataRow[21] = value2;
				string cmdText10 = fun.select("SupplierId,SupplierName,ContactPerson,ContactNo,Email,RegdCountry", "tblMM_Supplier_master", "SupplierId='" + dataSet4.Tables[0].Rows[i]["SupplierId"].ToString() + "' AND CompId='" + cId + "'");
				SqlCommand selectCommand11 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter11.Fill(dataSet12);
				if (dataSet12.Tables[0].Rows.Count > 0)
				{
					Country = Convert.ToInt32(dataSet12.Tables[0].Rows[0]["RegdCountry"]);
					string cmdText11 = fun.select("Symbol", "tblCountry", "CId='" + dataSet12.Tables[0].Rows[0]["RegdCountry"].ToString() + "' ");
					DataSet dataSet13 = new DataSet();
					SqlCommand selectCommand12 = new SqlCommand(cmdText11, sqlConnection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					sqlDataAdapter12.Fill(dataSet13, "tblCountry");
					dataRow[39] = dataSet13.Tables[0].Rows[0]["Symbol"].ToString();
					dataRow[15] = dataSet12.Tables[0].Rows[0]["SupplierName"].ToString();
					dataRow[16] = dataSet12.Tables[0].Rows[0]["ContactPerson"].ToString();
					dataRow[18] = dataSet12.Tables[0].Rows[0]["ContactNo"].ToString();
					dataRow[17] = dataSet12.Tables[0].Rows[0]["Email"].ToString();
					dataRow[37] = dataSet12.Tables[0].Rows[0]["SupplierId"].ToString();
				}
				string cmdText12 = fun.select("Terms,Value", "tblPacking_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["PF"]) + "'");
				SqlCommand selectCommand13 = new SqlCommand(cmdText12, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter13.Fill(dataSet14);
				if (dataSet14.Tables[0].Rows.Count > 0)
				{
					dataRow[25] = dataSet14.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[26] = Convert.ToDouble(dataSet14.Tables[0].Rows[0]["Value"]);
				}
				string cmdText13 = fun.select("Terms,Value", "tblVAT_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["VAT"]) + "'");
				SqlCommand selectCommand14 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				DataSet dataSet15 = new DataSet();
				sqlDataAdapter14.Fill(dataSet15);
				if (dataSet15.Tables[0].Rows.Count > 0)
				{
					dataRow[30] = dataSet15.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[31] = Convert.ToDouble(dataSet15.Tables[0].Rows[0]["Value"]);
				}
				string cmdText14 = fun.select("Terms,Value", "tblExciseser_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["ExST"]) + "'");
				SqlCommand selectCommand15 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
				DataSet dataSet16 = new DataSet();
				sqlDataAdapter15.Fill(dataSet16);
				if (dataSet16.Tables[0].Rows.Count > 0)
				{
					dataRow[28] = dataSet16.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[29] = Convert.ToDouble(dataSet16.Tables[0].Rows[0]["Value"]);
				}
				string cmdText15 = fun.select("Terms,Value", "tblOctroi_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["Octroi"]) + "'");
				SqlCommand selectCommand16 = new SqlCommand(cmdText15, sqlConnection);
				SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
				DataSet dataSet17 = new DataSet();
				sqlDataAdapter16.Fill(dataSet17);
				if (dataSet17.Tables[0].Rows.Count > 0)
				{
					dataRow[23] = dataSet17.Tables[0].Rows[0]["Terms"].ToString();
					dataRow[24] = Convert.ToDouble(dataSet17.Tables[0].Rows[0]["Value"]);
				}
				string cmdText16 = fun.select("Terms", "tblPayment_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["PaymentTerms"]) + "'");
				SqlCommand selectCommand17 = new SqlCommand(cmdText16, sqlConnection);
				SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
				DataSet dataSet18 = new DataSet();
				sqlDataAdapter17.Fill(dataSet18);
				if (dataSet18.Tables[0].Rows.Count > 0)
				{
					dataRow[27] = dataSet18.Tables[0].Rows[0]["Terms"].ToString();
				}
				string cmdText17 = fun.select("Terms", "tblWarrenty_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["Warrenty"]) + "'");
				SqlCommand selectCommand18 = new SqlCommand(cmdText17, sqlConnection);
				SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
				DataSet dataSet19 = new DataSet();
				sqlDataAdapter18.Fill(dataSet19);
				if (dataSet19.Tables[0].Rows.Count > 0)
				{
					dataRow[32] = dataSet19.Tables[0].Rows[0]["Terms"].ToString();
				}
				string cmdText18 = fun.select("Terms", "tblFreight_Master", "Id='" + Convert.ToInt32(dataSet4.Tables[0].Rows[i]["Freight"]) + "'");
				SqlCommand selectCommand19 = new SqlCommand(cmdText18, sqlConnection);
				SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
				DataSet dataSet20 = new DataSet();
				sqlDataAdapter19.Fill(dataSet20);
				if (dataSet20.Tables[0].Rows.Count > 0)
				{
					dataRow[33] = dataSet20.Tables[0].Rows[0]["Terms"].ToString();
				}
				dataRow[34] = dataSet4.Tables[0].Rows[i]["ReferenceDesc"].ToString();
				dataRow[38] = dataSet4.Tables[0].Rows[i]["Insurance"].ToString();
				if (num == 1)
				{
					string cmdText19 = fun.select("tblMM_PO_Amd_Details.PODId,tblMM_PO_Amd_Details.Qty,tblMM_PO_Amd_Details.Rate,tblMM_PO_Amd_Details.Discount,tblMM_PO_Amd_Details.DelDate,tblMM_PO_Amd_Details.PF,tblMM_PO_Amd_Details.ExST,tblMM_PO_Amd_Details.VAT,tblMM_PO_Amd_Details.PRId,tblMM_PO_Amd_Details.BudgetCode,tblMM_PO_Amd_Details.AddDesc", "tblMM_PO_Amd_Details", "tblMM_PO_Amd_Details.MId='" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "' AND tblMM_PO_Amd_Details.PODId='" + dataSet4.Tables[0].Rows[i]["PODId"].ToString() + "'");
					SqlCommand selectCommand20 = new SqlCommand(cmdText19, sqlConnection);
					SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
					DataSet dataSet21 = new DataSet();
					sqlDataAdapter20.Fill(dataSet21);
					if (dataSet21.Tables[0].Rows.Count > 0)
					{
						if (dataSet4.Tables[0].Rows[i]["SupplierId"].ToString() == dataSet2.Tables[0].Rows[0]["SupplierId"].ToString())
						{
							dataRow[40] = "";
						}
						else
						{
							dataRow[40] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["SupplierId"].ToString() == dataSet2.Tables[0].Rows[0]["SupplierId"].ToString())
						{
							dataRow[41] = "";
						}
						else
						{
							dataRow[41] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["ReferenceDate"].ToString() == dataSet2.Tables[0].Rows[0]["ReferenceDate"].ToString())
						{
							dataRow[42] = "";
						}
						else
						{
							dataRow[42] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Reference"].ToString() == dataSet2.Tables[0].Rows[0]["Reference"].ToString())
						{
							dataRow[43] = "";
						}
						else
						{
							dataRow[43] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["ReferenceDesc"].ToString() == dataSet2.Tables[0].Rows[0]["ReferenceDesc"].ToString())
						{
							dataRow[44] = "";
						}
						else
						{
							dataRow[44] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Rate"].ToString() == dataSet21.Tables[0].Rows[0]["Rate"].ToString())
						{
							dataRow[45] = "";
						}
						else
						{
							dataRow[45] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Discount"].ToString() == dataSet21.Tables[0].Rows[0]["Discount"].ToString())
						{
							dataRow[46] = "";
						}
						else
						{
							dataRow[46] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["PF"].ToString() == dataSet21.Tables[0].Rows[0]["PF"].ToString())
						{
							dataRow[47] = "";
						}
						else
						{
							dataRow[47] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["ExST"].ToString() == dataSet21.Tables[0].Rows[0]["ExST"].ToString())
						{
							dataRow[48] = "";
						}
						else
						{
							dataRow[48] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["VAT"].ToString() == dataSet21.Tables[0].Rows[0]["VAT"].ToString())
						{
							dataRow[49] = "";
						}
						else
						{
							dataRow[49] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["DelDate"].ToString() == dataSet21.Tables[0].Rows[0]["DelDate"].ToString())
						{
							dataRow[50] = "";
						}
						else
						{
							dataRow[50] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["PaymentTerms"].ToString() == dataSet2.Tables[0].Rows[0]["PaymentTerms"].ToString())
						{
							dataRow[51] = "";
						}
						else
						{
							dataRow[51] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["ModeOfDispatch"].ToString() == dataSet2.Tables[0].Rows[0]["ModeOfDispatch"].ToString())
						{
							dataRow[52] = "";
						}
						else
						{
							dataRow[52] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Inspection"].ToString() == dataSet2.Tables[0].Rows[0]["Inspection"].ToString())
						{
							dataRow[53] = "";
						}
						else
						{
							dataRow[53] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Octroi"].ToString() == dataSet2.Tables[0].Rows[0]["Octroi"].ToString())
						{
							dataRow[54] = "";
						}
						else
						{
							dataRow[54] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Warrenty"].ToString() == dataSet2.Tables[0].Rows[0]["Warrenty"].ToString())
						{
							dataRow[55] = "";
						}
						else
						{
							dataRow[55] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Freight"].ToString() == dataSet2.Tables[0].Rows[0]["Freight"].ToString())
						{
							dataRow[56] = "";
						}
						else
						{
							dataRow[56] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Insurance"].ToString() == dataSet2.Tables[0].Rows[0]["Insurance"].ToString())
						{
							dataRow[57] = "";
						}
						else
						{
							dataRow[57] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["ShipTo"].ToString() == dataSet2.Tables[0].Rows[0]["ShipTo"].ToString())
						{
							dataRow[58] = "";
						}
						else
						{
							dataRow[58] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Remarks"].ToString() == dataSet2.Tables[0].Rows[0]["Remarks"].ToString())
						{
							dataRow[59] = "";
						}
						else
						{
							dataRow[59] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["BudgetCode"].ToString() == dataSet21.Tables[0].Rows[0]["BudgetCode"].ToString())
						{
							dataRow[60] = "";
						}
						else
						{
							dataRow[60] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["AddDesc"].ToString() == dataSet21.Tables[0].Rows[0]["AddDesc"].ToString())
						{
							dataRow[62] = "";
						}
						else
						{
							dataRow[62] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["Qty"].ToString() == dataSet21.Tables[0].Rows[0]["Qty"].ToString())
						{
							dataRow[63] = "";
						}
						else
						{
							dataRow[63] = "*";
						}
						if (dataSet4.Tables[0].Rows[i]["TC"].ToString() == dataSet2.Tables[0].Rows[0]["TC"].ToString())
						{
							dataRow[64] = "";
						}
						else
						{
							dataRow[64] = "*";
						}
					}
				}
				if (dataSet4.Tables[0].Rows[i]["AddDesc"] != DBNull.Value && dataSet4.Tables[0].Rows[i]["AddDesc"].ToString() != "")
				{
					dataRow[61] = dataSet4.Tables[0].Rows[i]["AddDesc"].ToString();
				}
				else
				{
					dataRow[61] = "";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			dataSet.Tables.Add(dataTable);
			DataSet dataSet22 = new PO_PR();
			dataSet22.Tables[0].Merge(dataSet.Tables[0]);
			dataSet22.AcceptChanges();
			report = new ReportDocument();
			if (Country == 1)
			{
				report.Load(base.Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/PO.rpt"));
			}
			else
			{
				report.Load(base.Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/PO_Import.rpt"));
			}
			report.SetDataSource(dataSet22);
			string cmdText20 = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_master", "SupplierId='" + SupCode + "' And CompId='" + cId + "'");
			DataSet dataSet23 = new DataSet();
			SqlCommand selectCommand21 = new SqlCommand(cmdText20, sqlConnection);
			SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
			sqlDataAdapter21.Fill(dataSet23, "tblMM_Supplier_master");
			string cmdText21 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet23.Tables[0].Rows[0]["RegdCountry"], "'"));
			string cmdText22 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet23.Tables[0].Rows[0]["RegdState"], "'"));
			string cmdText23 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet23.Tables[0].Rows[0]["RegdCity"], "'"));
			SqlCommand selectCommand22 = new SqlCommand(cmdText21, sqlConnection);
			SqlCommand selectCommand23 = new SqlCommand(cmdText22, sqlConnection);
			SqlCommand selectCommand24 = new SqlCommand(cmdText23, sqlConnection);
			SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
			SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
			SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand24);
			DataSet dataSet24 = new DataSet();
			DataSet dataSet25 = new DataSet();
			DataSet dataSet26 = new DataSet();
			sqlDataAdapter22.Fill(dataSet24, "tblCountry");
			sqlDataAdapter23.Fill(dataSet25, "tblState");
			sqlDataAdapter24.Fill(dataSet26, "tblcity");
			string text2 = dataSet23.Tables[0].Rows[0]["RegdAddress"].ToString() + "," + dataSet26.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet25.Tables[0].Rows[0]["StateName"].ToString() + "," + dataSet24.Tables[0].Rows[0]["CountryName"].ToString() + "." + dataSet23.Tables[0].Rows[0]["RegdPinNo"].ToString() + ".";
			report.SetParameterValue("SupplierAddress", (object)text2);
			string fD = dataSet4.Tables[0].Rows[0]["SysDate"].ToString();
			string text3 = fun.FromDateDMY(fD);
			report.SetParameterValue("RegDate", (object)text3);
			string fD2 = dataSet4.Tables[0].Rows[0]["ReferenceDate"].ToString();
			string text4 = fun.FromDateDMY(fD2);
			report.SetParameterValue("RefDate", (object)text4);
			string text5 = dataSet4.Tables[0].Rows[0]["CheckedBy"].ToString();
			string text6 = dataSet4.Tables[0].Rows[0]["ApprovedBy"].ToString();
			string text7 = dataSet4.Tables[0].Rows[0]["AuthorizedBy"].ToString();
			string text8 = "";
			if (dataSet4.Tables[0].Rows[0]["CheckedBy"] != DBNull.Value && dataSet4.Tables[0].Rows[0]["CheckedBy"] != "")
			{
				string cmdText24 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + text5 + "'And CompId='" + cId + "'");
				SqlCommand selectCommand25 = new SqlCommand(cmdText24, sqlConnection);
				SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand25);
				DataSet dataSet27 = new DataSet();
				sqlDataAdapter25.Fill(dataSet27, "tblHR_OfficeStaff");
				text8 = dataSet27.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet27.Tables[0].Rows[0]["EmployeeName"].ToString();
			}
			else
			{
				text8 = " ";
			}
			string text9 = "";
			if (dataSet4.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value && dataSet4.Tables[0].Rows[0]["ApprovedBy"] != "")
			{
				string cmdText25 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + text6 + "'And CompId='" + cId + "'");
				SqlCommand selectCommand26 = new SqlCommand(cmdText25, sqlConnection);
				SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand26);
				DataSet dataSet28 = new DataSet();
				sqlDataAdapter26.Fill(dataSet28, "tblHR_OfficeStaff");
				text9 = dataSet28.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet28.Tables[0].Rows[0]["EmployeeName"].ToString();
			}
			else
			{
				text9 = " ";
			}
			string text10 = "";
			if (dataSet4.Tables[0].Rows[0]["AuthorizedBy"] != DBNull.Value && dataSet4.Tables[0].Rows[0]["AuthorizedBy"] != "")
			{
				string cmdText26 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + text7 + "'And CompId='" + cId + "'");
				SqlCommand selectCommand27 = new SqlCommand(cmdText26, sqlConnection);
				SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand27);
				DataSet dataSet29 = new DataSet();
				sqlDataAdapter27.Fill(dataSet29, "tblHR_OfficeStaff");
				text10 = dataSet29.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet29.Tables[0].Rows[0]["EmployeeName"].ToString();
			}
			else
			{
				text10 = " ";
			}
			report.SetParameterValue("CheckedBy", (object)text8);
			report.SetParameterValue("ApprovedBy", (object)text9);
			report.SetParameterValue("AuthorizedBy", (object)text10);
			string text11 = "";
			if (dataSet4.Tables[0].Rows[0]["CheckedDate"] != DBNull.Value)
			{
				string fD3 = dataSet4.Tables[0].Rows[0]["CheckedDate"].ToString();
				text11 = fun.FromDate(fD3);
			}
			else
			{
				text11 = "";
			}
			string text12 = "";
			if (dataSet4.Tables[0].Rows[0]["ApproveDate"] != DBNull.Value)
			{
				string fD4 = dataSet4.Tables[0].Rows[0]["ApproveDate"].ToString();
				text12 = fun.FromDate(fD4);
			}
			else
			{
				text12 = "";
			}
			string text13 = "";
			if (dataSet4.Tables[0].Rows[0]["AuthorizeDate"] != DBNull.Value)
			{
				string fD5 = dataSet4.Tables[0].Rows[0]["AuthorizeDate"].ToString();
				text13 = fun.FromDate(fD5);
			}
			else
			{
				text13 = "";
			}
			report.SetParameterValue("CheckedDate", (object)text11);
			report.SetParameterValue("ApproveDate", (object)text12);
			report.SetParameterValue("AuthorizeDate", (object)text13);
			string text14 = fun.CompAdd(cId);
			report.SetParameterValue("Address", (object)text14);
			StringBuilder stringBuilder = new StringBuilder();
			string text15 = "";
			if (dataSet4.Tables[0].Rows[0]["TC"] != DBNull.Value)
			{
				stringBuilder.AppendLine(dataSet4.Tables[0].Rows[0]["TC"].ToString());
				text15 = stringBuilder.ToString().Replace(Environment.NewLine, Environment.NewLine);
			}
			else
			{
				text15 = "";
			}
			report.SetParameterValue("TC", (object)text15);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
			Session[Key] = report;
		}
		catch (Exception)
		{
		}
		finally
		{
			dataSet.Clear();
			dataSet.Dispose();
			dataTable.Clear();
			dataTable.Dispose();
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}
}

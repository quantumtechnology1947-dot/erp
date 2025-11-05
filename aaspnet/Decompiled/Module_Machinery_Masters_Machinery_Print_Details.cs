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

public class Module_Machinery_Masters_Machinery_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private ReportDocument report = new ReportDocument();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int itemId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				string value = base.Request.QueryString["Id"];
				itemId = Convert.ToInt32(value);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				con.Open();
				string cmdText = fun.select("*", "tblMS_Master", " ItemId='" + itemId + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'  ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Make", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Model", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Capacity", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PurchaseDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Cost", typeof(double)));
				dataTable.Columns.Add(new DataColumn("WarrantyExpiryDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("LifeDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ReceivedDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Insurance", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InsuranceExpiryDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Puttouse", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Incharge", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PMDays", typeof(string)));
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString());
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["SysDate"].ToString());
					dataRow[2] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CompId"]);
					string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master,vw_Unit_Master", " tblDG_Item_Master.Id='" + itemId + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[4] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
						dataRow[5] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					dataRow[6] = dataSet.Tables[0].Rows[0]["Make"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[0]["Model"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[0]["Capacity"].ToString();
					dataRow[9] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["PurchaseDate"].ToString());
					string value2 = "";
					string cmdText3 = fun.select("SupplierName +' ['+SupplierId+']'", "tblMM_Supplier_master", "CompId='" + CompId + "' And SupplierId='" + dataSet.Tables[0].Rows[0]["SupplierName"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					DataSet dataSet3 = new DataSet();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3, "tblMM_Supplier_master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet3.Tables[0].Rows[0][0].ToString();
					}
					dataRow[10] = value2;
					dataRow[11] = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Cost"].ToString());
					dataRow[12] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["WarrantyExpiryDate"].ToString());
					dataRow[13] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["LifeDate"].ToString());
					dataRow[14] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["ReceivedDate"].ToString());
					string text = "";
					text = ((!(dataSet.Tables[0].Rows[0]["Insurance"].ToString() == "0")) ? "Yes" : "No");
					dataRow[15] = text;
					string text2 = "";
					text2 = ((!(dataSet.Tables[0].Rows[0]["InsuranceExpiryDate"].ToString() != "")) ? "NA" : fun.FromDateDMY(dataSet.Tables[0].Rows[0]["InsuranceExpiryDate"].ToString()));
					dataRow[16] = text2;
					dataRow[17] = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["Puttouse"].ToString());
					string value3 = "";
					string cmdText4 = fun.select("EmployeeName+' ['+EmpId+']' ", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[0]["Incharge"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					DataSet dataSet4 = new DataSet();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					sqlDataAdapter4.Fill(dataSet4, "tblHR_OfficeStaff");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value3 = dataSet4.Tables[0].Rows[0][0].ToString();
					}
					dataRow[18] = value3;
					dataRow[19] = dataSet.Tables[0].Rows[0]["Location"].ToString();
					dataRow[20] = dataSet.Tables[0].Rows[0]["PMDays"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
					DataSet dataSet5 = new Machinery();
					dataSet5.Tables[0].Merge(dataTable);
					string text3 = base.Server.MapPath("~/Module/Machinery/Masters/Reports/Machinery.rpt");
					report.Load(text3);
					report.SetDataSource(dataSet5);
					string text4 = fun.CompAdd(CompId);
					report.SetParameterValue("Address", (object)text4);
					((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
					Session[Key] = report;
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataSet.Clear();
				dataSet.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				con.Close();
				con.Dispose();
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

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Machinery_Print.aspx?ModId=&SubModId=");
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

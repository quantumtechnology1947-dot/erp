using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Inventory_Transactions_CustomerChallan_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string supid = "";

	private string str = "";

	private SqlConnection con;

	private int id;

	private string GenBy = "";

	private string DelivTo = "";

	private string DelAdd = "";

	private string Person = "";

	private string ContactNo = "";

	private string GenBy1 = "";

	private string DelivTo1 = "";

	private string DelAdd1 = "";

	private string Person1 = "";

	private string ContactNo1 = "";

	private ReportDocument cryRpt = new ReportDocument();

	private ReportDocument cryRpt2 = new ReportDocument();

	private string Key = string.Empty;

	private string Key1 = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Btncancel;

	protected Panel Panel2;

	protected TabPanel Add;

	protected CrystalReportViewer CrystalReportViewer2;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel4;

	protected Button BtnCancel1;

	protected Panel Panel3;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			Key = base.Request.QueryString["Key"].ToString();
			Key1 = base.Request.QueryString["Key1"].ToString();
			if (!base.IsPostBack)
			{
				fillGrid();
				LoadGrid();
				return;
			}
			Key = base.Request.QueryString["Key"].ToString();
			ReportDocument reportSource = (ReportDocument)Session[Key];
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			Key1 = base.Request.QueryString["Key1"].ToString();
			ReportDocument reportSource2 = (ReportDocument)Session[Key1];
			((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource2;
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		cryRpt = new ReportDocument();
		cryRpt2 = new ReportDocument();
	}

	public void fillGrid()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = "select tblInv_Customer_Challan_Master.CompId,tblInv_Customer_Challan_Master.CustomerId,tblInv_Customer_Challan_Master.SessionId,tblInv_Customer_Challan_Master.SysTime,tblInv_Customer_Challan_Details.Id, tblInv_Customer_Challan_Master.WONo,tblInv_Customer_Challan_Master.CCNo,   tblInv_Customer_Challan_Details.ChallanQty,  tblDG_Item_Master.ItemCode, tblDG_Item_Master.ManfDesc, Unit_Master.Symbol,tblInv_Customer_Challan_Master.SysDate As CCDate FROM         tblDG_Item_Master INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id INNER JOIN                       tblInv_Customer_Challan_Details ON tblDG_Item_Master.Id = tblInv_Customer_Challan_Details.ItemId INNER JOIN                       tblInv_Customer_Challan_Master ON tblInv_Customer_Challan_Details.MId = tblInv_Customer_Challan_Master.Id AND tblInv_Customer_Challan_Master.CompId='" + CompId + "' AND tblInv_Customer_Challan_Details.MId='" + id + "' ";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CCNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CCDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChallanQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			DataSet dataSet2 = new DataSet();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["CCNo"].ToString();
				dataRow[3] = fun.FromDate(dataSet.Tables[0].Rows[i]["CCDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["ChallanQty"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			dataSet2.Tables.Add(dataTable);
			dataSet2.AcceptChanges();
			DataSet dataSet3 = new CustChallan();
			dataSet3.Tables[0].Merge(dataSet2.Tables[0]);
			dataSet3.AcceptChanges();
			cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/CustomerChallan.rpt"));
			cryRpt.SetDataSource(dataSet3);
			string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[0]["SessionId"], "'"));
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter2.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				GenBy = dataSet4.Tables[0].Rows[0]["EmpName"].ToString();
			}
			string selectCommandText = fun.select("CustomerName+'['+CustomerId+']' As CustName,RegdAddress,ContactPerson,ContactNo", "SD_Cust_master", string.Concat("CompId='", CompId, "' And CustomerId='", dataSet.Tables[0].Rows[0]["CustomerId"], "' "));
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter3.Fill(dataSet5, "SD_Cust_master");
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				DelivTo = dataSet5.Tables[0].Rows[0]["CustName"].ToString();
				DelAdd = dataSet5.Tables[0].Rows[0]["RegdAddress"].ToString();
				Person = dataSet5.Tables[0].Rows[0]["ContactPerson"].ToString();
				ContactNo = dataSet5.Tables[0].Rows[0]["ContactNo"].ToString();
			}
			string text = fun.CompAdd(CompId);
			cryRpt.SetParameterValue("Address", (object)text);
			cryRpt.SetParameterValue("GenBy", (object)GenBy);
			cryRpt.SetParameterValue("DelivTo", (object)DelivTo);
			cryRpt.SetParameterValue("DelAdd", (object)DelAdd);
			cryRpt.SetParameterValue("Person", (object)Person);
			cryRpt.SetParameterValue("ContactNo", (object)ContactNo);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
			Session[Key] = cryRpt;
		}
		catch (Exception)
		{
		}
	}

	public void LoadGrid()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT  tblInv_Customer_Challan_Clear.SysDate,tblInv_Customer_Challan_Clear.CompId,tblInv_Customer_Challan_Clear.SysTime,tblDG_Item_Master.ManfDesc ,tblDG_Item_Master.ItemCode,Unit_Master.Symbol,tblInv_Customer_Challan_Details.ItemId,tblInv_Customer_Challan_Master.WONo,tblInv_Customer_Challan_Master.CCNo,tblInv_Customer_Challan_Master.CustomerId,tblInv_Customer_Challan_Details.ChallanQty,tblInv_Customer_Challan_Clear.Id,tblInv_Customer_Challan_Clear.DId,tblInv_Customer_Challan_Clear.ClearQty ,tblInv_Customer_Challan_Clear.CompId,tblInv_Customer_Challan_Clear.SessionId,tblInv_Customer_Challan_Clear.SysTime FROM  tblDG_Item_Master  INNER JOIN    tblInv_Customer_Challan_Details On       tblInv_Customer_Challan_Details.ItemId = tblDG_Item_Master.Id  INNER JOIN tblInv_Customer_Challan_Clear ON tblInv_Customer_Challan_Clear.DId= tblInv_Customer_Challan_Details.Id  INNER JOIN Unit_Master ON  Unit_Master.Id=tblDG_Item_Master.UOMBasic INNER JOIN tblInv_Customer_Challan_Master ON tblInv_Customer_Challan_Master.Id = tblInv_Customer_Challan_Details.MId  AND tblInv_Customer_Challan_Clear.CompId='" + CompId + "' AND tblInv_Customer_Challan_Master.Id='" + id + "' And tblInv_Customer_Challan_Clear.FinYearId<='" + fyid + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CCNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChallanQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ClearQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			DataSet dataSet2 = new DataSet();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["CCNo"].ToString();
				dataRow[3] = fun.FromDate(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["ChallanQty"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["ClearQty"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			dataSet2.Tables.Add(dataTable);
			dataSet2.AcceptChanges();
			DataSet dataSet3 = new CustClear();
			dataSet3.Tables[0].Merge(dataSet2.Tables[0]);
			dataSet3.AcceptChanges();
			cryRpt2.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/CustomerChallan_Clear.rpt"));
			cryRpt2.SetDataSource(dataSet3);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[0]["SessionId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter2.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					GenBy1 = dataSet4.Tables[0].Rows[0]["EmpName"].ToString();
				}
				string selectCommandText = fun.select("CustomerName+'['+CustomerId+']' As CustName,RegdAddress,ContactPerson,ContactNo", "SD_Cust_master", string.Concat("CompId='", CompId, "' And CustomerId='", dataSet.Tables[0].Rows[0]["CustomerId"], "' "));
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter3.Fill(dataSet5, "SD_Cust_master");
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					DelivTo1 = dataSet5.Tables[0].Rows[0]["CustName"].ToString();
					DelAdd1 = dataSet5.Tables[0].Rows[0]["RegdAddress"].ToString();
					Person1 = dataSet5.Tables[0].Rows[0]["ContactPerson"].ToString();
					ContactNo1 = dataSet5.Tables[0].Rows[0]["ContactNo"].ToString();
				}
			}
			string text = fun.CompAdd(CompId);
			cryRpt2.SetParameterValue("Address", (object)text);
			cryRpt2.SetParameterValue("GenBy", (object)GenBy1);
			cryRpt2.SetParameterValue("DelivTo", (object)DelivTo1);
			cryRpt2.SetParameterValue("DelAdd", (object)DelAdd1);
			cryRpt2.SetParameterValue("Person", (object)Person1);
			cryRpt2.SetParameterValue("ContactNo", (object)ContactNo1);
			((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = cryRpt2;
			Session[Key1] = cryRpt2;
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Print.aspx?ModId=9&SubModId=121");
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Print.aspx?ModId=9&SubModId=121");
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		((Control)(object)CrystalReportViewer2).Dispose();
		CrystalReportViewer2 = null;
		cryRpt2.Close();
		((Component)(object)cryRpt2).Dispose();
		GC.Collect();
	}
}

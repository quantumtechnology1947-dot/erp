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

public class Module_Inventory_Transactions_SupplierChallan_Print_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string supid = "";

	private string str = "";

	private SqlConnection con;

	private int id;

	private int PType;

	private string DelivTo = "";

	private string DelAdd = "";

	private string Person = "";

	private string ContactNo = "";

	private string VehicleNo = "";

	private string Transporter = "";

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
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			Key = base.Request.QueryString["Key"].ToString();
			Key1 = base.Request.QueryString["Key1"].ToString();
			PType = Convert.ToInt32(base.Request.QueryString["T"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				fyid = Convert.ToInt32(Session["finyear"]);
				sId = Session["username"].ToString();
				id = Convert.ToInt32(base.Request.QueryString["Id"]);
				fillGrid();
				LoadGrid();
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
		Key1 = base.Request.QueryString["Key1"].ToString();
		ReportDocument reportSource2 = (ReportDocument)Session[Key1];
		((CrystalReportViewerBase)CrystalReportViewer2).ReportSource = reportSource2;
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
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetChallan_Details", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataColumn column = new DataColumn("Rate", typeof(double));
			dataSet.Tables[0].Columns.Add(column);
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				double num = 0.0;
				string cmdText = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", string.Concat("CompId='", CompId, "'And ItemId='", row.ItemArray[19], "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				DataSet dataSet2 = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["rate"] != DBNull.Value)
				{
					num = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["rate"]);
				}
				row["Rate"] = num;
			}
			DataSet dataSet3 = new SupplierChallan();
			dataSet3.Tables[0].Merge(dataSet.Tables[0]);
			dataSet3.AcceptChanges();
			cryRpt = new ReportDocument();
			cryRpt.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/SupplierChallan.rpt"));
			cryRpt.SetDataSource(dataSet3);
			string selectCommandText = fun.select("SupplierName+'['+SupplierId+']' As SupName,MaterialDelAddress,ContactPerson,ContactNo", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' And SupplierId='", dataSet.Tables[0].Rows[0]["SupplierId"], "' "));
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter3.Fill(dataSet4, "tblMM_Supplier_master");
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				DelivTo = dataSet4.Tables[0].Rows[0]["SupName"].ToString();
				DelAdd = dataSet4.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				Person = dataSet4.Tables[0].Rows[0]["ContactPerson"].ToString();
				ContactNo = dataSet4.Tables[0].Rows[0]["ContactNo"].ToString();
			}
			string text = string.Empty;
			switch (PType)
			{
			case 0:
				text = "ORIGINAL";
				break;
			case 1:
				text = "DUPLICATE";
				break;
			case 2:
				text = "TRIPLICATE";
				break;
			case 3:
				text = "ACKNOWLEDGEMENT";
				break;
			}
			string cmdText2 = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter4.Fill(dataSet5, "tblCompany_master");
			string text2 = dataSet5.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + fun.getCity(Convert.ToInt32(dataSet5.Tables[0].Rows[0]["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(dataSet5.Tables[0].Rows[0]["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(dataSet5.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dataSet5.Tables[0].Rows[0]["RegdPinCode"].ToString() + ".\nPh No.-" + dataSet5.Tables[0].Rows[0]["RegdContactNo"].ToString() + ",  Fax No.-" + dataSet5.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "\nEmail No.-" + dataSet5.Tables[0].Rows[0]["RegdEmail"].ToString();
			cryRpt.SetParameterValue("Address", (object)text2);
			cryRpt.SetParameterValue("DelivTo", (object)DelivTo);
			cryRpt.SetParameterValue("DelAdd", (object)DelAdd);
			cryRpt.SetParameterValue("Person", (object)Person);
			cryRpt.SetParameterValue("ContactNo", (object)ContactNo);
			cryRpt.SetParameterValue("PtintType", (object)text);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
			Session[Key] = cryRpt;
		}
		catch (Exception)
		{
		}
	}

	public void LoadGrid()
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSup_Challan_Clear_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataSet dataSet2 = new Challan_Clear();
			dataSet2.Tables[0].Merge(dataSet.Tables[0]);
			dataSet2.AcceptChanges();
			cryRpt2 = new ReportDocument();
			cryRpt2.Load(base.Server.MapPath("~/Module/Inventory/Transactions/Reports/Challan_Clear.rpt"));
			cryRpt2.SetDataSource(dataSet2);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[0]["SessionId"], "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter2.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					GenBy1 = dataSet3.Tables[0].Rows[0]["EmpName"].ToString();
				}
				string selectCommandText = fun.select("SupplierName+'['+SupplierId+']' As SupName,MaterialDelAddress,ContactPerson,ContactNo", "tblMM_Supplier_master", string.Concat("CompId='", CompId, "' And SupplierId='", dataSet.Tables[0].Rows[0]["SupplierId"], "' "));
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter3.Fill(dataSet4, "tblMM_Supplier_master");
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					DelivTo1 = dataSet4.Tables[0].Rows[0]["SupName"].ToString();
					DelAdd1 = dataSet4.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
					Person1 = dataSet4.Tables[0].Rows[0]["ContactPerson"].ToString();
					ContactNo1 = dataSet4.Tables[0].Rows[0]["ContactNo"].ToString();
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
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_Print.aspx?ModId=9&SubModId=118");
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_Print.aspx?ModId=9&SubModId=118");
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

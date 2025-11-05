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

public class Module_MaterialManagement_Masters_Supplier_Details_Print_All : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private ReportDocument report = new ReportDocument();

	private int cId;

	private string Key = string.Empty;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		cId = Convert.ToInt32(Session["compid"]);
		Key = base.Request.QueryString["Key"].ToString();
		try
		{
			if (!base.IsPostBack)
			{
				DataTable dataTable = new DataTable();
				string cmdText = fun.select("*", "tblMM_Supplier_master", " CompId='" + cId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
				dataTable.Columns.Add(new DataColumn("SupId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RegdAdd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["SupId"]);
					dataRow[1] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
					dataRow[2] = dataSet.Tables[0].Rows[i]["SupplierName"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
					string cmdText2 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[i]["RegdCountry"], "'"));
					string cmdText3 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[i]["RegdState"], "'"));
					string cmdText4 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[i]["RegdCity"], "'"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet2 = new DataSet();
					DataSet dataSet3 = new DataSet();
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblCountry");
					sqlDataAdapter3.Fill(dataSet3, "tblState");
					sqlDataAdapter4.Fill(dataSet4, "tblcity");
					string value = dataSet.Tables[0].Rows[i]["RegdAddress"].ToString() + ", " + dataSet4.Tables[0].Rows[0]["CityName"].ToString() + ", " + dataSet3.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + dataSet2.Tables[0].Rows[0]["CountryName"].ToString() + " - " + dataSet.Tables[0].Rows[i]["RegdPinNo"].ToString() + ".";
					dataRow[4] = value;
					dataRow[5] = dataSet.Tables[0].Rows[i]["ContactPerson"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ContactNo"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["Email"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet5 = new AllSupplierPrint();
				dataSet5.Tables[0].Merge(dataTable);
				dataSet5.AcceptChanges();
				report = new ReportDocument();
				report.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/SupplierPrintReportAll.rpt"));
				report.SetDataSource(dataSet5);
				string text = fun.CompAdd(cId);
				report.SetParameterValue("Address", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
			}
			else
			{
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
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

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SupplierMaster_Print.aspx?ModId=6&SubModId=22");
	}
}

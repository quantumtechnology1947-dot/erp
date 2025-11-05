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

public class Module_HR_Transactions_BankLoan_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string Empid = "";

	private string FyId = "";

	private string id = "";

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				FyId = Session["finyear"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				Key = base.Request.QueryString["Key"].ToString();
				Empid = base.Request.QueryString["EmpId"].ToString();
				binddata(id);
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

	public void binddata(string EmpId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		DataTable dataTable = new DataTable();
		DataSet dataSet2 = new DataSet();
		try
		{
			string text = "";
			if (Empid != "")
			{
				text = "And EmpId='" + Empid + "'";
			}
			string cmdText = fun.select("*", "tblHR_BankLoan", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text + "   Order by EmpId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet2);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Branch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Installment", typeof(double)));
			dataTable.Columns.Add(new DataColumn("fromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					dataRow[1] = dataSet2.Tables[0].Rows[i]["EmpId"].ToString();
					string cmdText2 = fun.select("Title + '. ' + EmployeeName As EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter2.Fill(dataSet3);
					dataRow[2] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
					dataRow[3] = dataSet2.Tables[0].Rows[i]["BankName"].ToString();
					dataRow[4] = dataSet2.Tables[0].Rows[i]["Branch"].ToString();
					dataRow[5] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Amount"]);
					dataRow[6] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Installment"]);
					dataRow[7] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["fromDate"].ToString());
					dataRow[8] = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["ToDate"].ToString());
					dataRow[9] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			dataSet.Tables.Add(dataTable);
			dataSet.AcceptChanges();
			DataSet dataSet4 = new BankLoan();
			dataSet4.Tables[0].Merge(dataSet.Tables[0]);
			dataSet4.AcceptChanges();
			string text2 = base.Server.MapPath("~/Module/HR/Transactions/Reports/BankLoan.rpt");
			report.Load(text2);
			report.SetDataSource(dataSet4);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
			string text3 = fun.CompAdd(CompId);
			report.SetParameterValue("Address", (object)text3);
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
			dataSet2.Clear();
			dataSet2.Dispose();
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		try
		{
			base.Response.Redirect("BankLoan_Print.aspx?ModId=12&SubModId=129");
		}
		catch (Exception)
		{
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

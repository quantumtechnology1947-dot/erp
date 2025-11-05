using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Reports_SalesDistribution : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinId;

	protected GridView GridView1;

	protected Chart Chart1;

	protected GridView SearchGridView1;

	protected Chart Chart2;

	protected GridView GridView2;

	protected Chart Chart3;

	protected GridView GridView3;

	protected Chart Chart4;

	protected UpdatePanel UpdatePanel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		FinId = Convert.ToInt32(Session["finyear"]);
		if (!Page.IsPostBack)
		{
			Enquirygrid();
			POgrid();
			WOgrid();
			DAgrid();
			drawgraph();
		}
	}

	public void WOgrid()
	{
		string text = fun.revDate("SD_Cust_WorkOrder_Master.SysDate", "SysDate");
		int num = Convert.ToInt32(Session["compid"]);
		fun.TotOfModule("SD_Cust_WorkOrder_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", " tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_WorkOrder_Master.PONo,SD_Cust_WorkOrder_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Master.WONo," + text, "tblHR_OfficeStaff.EmpId=SD_Cust_WorkOrder_Master.SessionId AND SD_Cust_WorkOrder_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + num + " AND  SD_Cust_WorkOrder_Master.FinYearId='" + FinId + "'And tblFinancial_master.FinYearId=SD_Cust_WorkOrder_Master.FinYearId Order by SD_Cust_WorkOrder_Master.Id Desc", GridView2);
	}

	public void Enquirygrid()
	{
		int num = Convert.ToInt32(Session["compid"]);
		fun.TotOfModule("SD_Cust_Enquiry_Master,tblHR_OfficeStaff,tblFinancial_master", "tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_Enquiry_Master.EnqId, SD_Cust_Enquiry_Master.CustomerName,SD_Cust_Enquiry_Master.POStatus,SD_Cust_Enquiry_Master.CustomerId,SD_Cust_Enquiry_Master.SessionId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_Enquiry_Master.SysDate,CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_Enquiry_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "  SD_Cust_Enquiry_Master.FinYearId='" + FinId + "' And tblHR_OfficeStaff.EmpId=SD_Cust_Enquiry_Master.SessionId AND SD_Cust_Enquiry_Master.CompId=" + num + " AND tblFinancial_master.FinYearId=SD_Cust_Enquiry_Master.FinYearId Order by SD_Cust_Enquiry_Master.EnqId Desc", GridView1);
	}

	public void POgrid()
	{
		int num = Convert.ToInt32(Session["compid"]);
		fun.TotOfModule("SD_Cust_PO_Master,SD_Cust_Master,tblHR_OfficeStaff,tblFinancial_master", "tblFinancial_master.FinYear,tblHR_OfficeStaff.EmployeeName,SD_Cust_PO_Master.PONo,SD_Cust_PO_Master.POId,SD_Cust_PO_Master.EnqId, SD_Cust_Master.CustomerName,SD_Cust_PO_Master.CustomerId,SD_Cust_PO_Master.SessionId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_PO_Master.SysDate, CHARINDEX('-', SD_Cust_PO_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_PO_Master.SysDate,CHARINDEX('-', SD_Cust_PO_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_PO_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_PO_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "tblHR_OfficeStaff.EmpId=SD_Cust_PO_Master.SessionId AND SD_Cust_PO_Master.CustomerId=SD_Cust_Master.CustomerId AND SD_Cust_PO_Master.CompId=" + num + " AND SD_Cust_PO_Master.FinYearId='" + FinId + "' And  tblFinancial_master.FinYearId=SD_Cust_PO_Master.FinYearId Order by SD_Cust_PO_Master.POId Desc", SearchGridView1);
	}

	public void DAgrid()
	{
		int num = Convert.ToInt32(Session["compid"]);
		fun.TotOfModule("SD_Cust_WorkOrder_Master,SD_Cust_WorkOrder_Release,SD_Cust_WorkOrder_Dispatch,SD_Cust_Master", "SD_Cust_WorkOrder_Master.WONo,SD_Cust_WorkOrder_Master.CustomerId,SD_Cust_WorkOrder_Release.WRNo,SD_Cust_Master.CustomerName,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Dispatch.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Dispatch.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Dispatch.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Dispatch.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Dispatch.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Dispatch.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Dispatch.WRNo=SD_Cust_WorkOrder_Release.WRNo AND SD_Cust_WorkOrder_Master.WONo=SD_Cust_WorkOrder_Release.WONo AND SD_Cust_Master.CustomerId = SD_Cust_WorkOrder_Master.CustomerId AND SD_Cust_WorkOrder_Master.CompId=" + num + " And SD_Cust_WorkOrder_Dispatch.FinYearId='" + FinId + "'  And SD_Cust_WorkOrder_Release.ItemId=SD_Cust_WorkOrder_Dispatch.ItemId Order by SD_Cust_WorkOrder_Dispatch.Id Desc", GridView3);
	}

	public void drawgraph()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string cmdText = "Select FinYear from tblfinancial_master Where FinYearId='" + num + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			Chart1.Series[0].ChartType = SeriesChartType.Column;
			Chart1.Series[0]["DrawingStyle"] = "Cylinder";
			Chart1.Series[0]["PointWidth"] = "0.7";
			Chart1.Series[0].IsValueShownAsLabel = true;
			Chart1.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
			Chart1.ChartAreas[0].BackColor = Color.PaleGreen;
			Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
			Chart1.ChartAreas[0].Area3DStyle.PointDepth = 100;
			Chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
			Chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;
			DataTable dataTable = new DataTable();
			new DataTable();
			dataTable.Columns.Add(new DataColumn("ct", typeof(string)));
			string[] array = new string[12]
			{
				"04", "05", "06", "07", "08", "09", "10", "11", "12", "01",
				"02", "03"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string cmdText2 = "Select count(*) as count_enq from sd_cust_enquiry_master Where SysDate like '%-" + array[i] + "-%' AND FinYearId='" + num + "' AND CompId='" + num2 + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet2.Tables[0].Rows[0][0].ToString();
				dataTable.Rows.Add(dataRow);
			}
			Chart1.ChartAreas[0].AxisX.Interval = 1.0;
			Chart1.ChartAreas[0].AxisY.Title = "Total No. of Enquiries";
			Chart1.Series[0].YValueMembers = dataTable.Columns[0].ToString();
			Chart1.DataSource = dataTable;
			Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8f);
			Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(2.0, 0.1, "APR");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(4.0, 0.1, "MAY");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(6.0, 0.1, "JUN");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(8.0, 0.1, "JUL");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(10.0, 0.1, "AUG");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(12.0, 0.1, "SEP");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(14.0, 0.1, "OCT");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(16.0, 0.1, "NOV");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(18.0, 0.1, "DEC");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(20.0, 0.1, "JAN");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(22.0, 0.1, "FEB");
			Chart1.ChartAreas[0].AxisX.CustomLabels.Add(24.0, 0.1, "MAR");
			Chart1.DataBind();
			Chart1.Visible = true;
			Chart2.Series[0].ChartType = SeriesChartType.Column;
			Chart2.Series[0]["DrawingStyle"] = "Cylinder";
			Chart2.Series[0]["PointWidth"] = "0.7";
			Chart2.Series[0].IsValueShownAsLabel = true;
			Chart2.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
			Chart2.ChartAreas[0].BackColor = Color.PapayaWhip;
			Chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
			Chart2.ChartAreas[0].Area3DStyle.PointDepth = 100;
			Chart2.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
			Chart2.ChartAreas[0].AxisY.IsStartedFromZero = true;
			DataTable dataTable2 = new DataTable();
			new DataTable();
			dataTable2.Columns.Add(new DataColumn("po", typeof(string)));
			string[] array2 = new string[12]
			{
				"04", "05", "06", "07", "08", "09", "10", "11", "12", "01",
				"02", "03"
			};
			for (int j = 0; j < array.Length; j++)
			{
				string cmdText3 = "Select count(*) as count_po from SD_Cust_PO_Master Where SysDate like '%-" + array2[j] + "-%'AND FinYearId='" + num + "' AND CompId='" + num2 + "'";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow2[0] = dataSet3.Tables[0].Rows[0][0].ToString();
				dataTable2.Rows.Add(dataRow2);
			}
			Chart2.ChartAreas[0].AxisX.Interval = 1.0;
			Chart2.ChartAreas[0].AxisY.Title = "Total No. of PO";
			Chart2.Series[0].YValueMembers = dataTable2.Columns[0].ToString();
			Chart2.DataSource = dataTable2;
			Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8f);
			Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(2.0, 0.1, "APR");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(4.0, 0.1, "MAY");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(6.0, 0.1, "JUN");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(8.0, 0.1, "JUL");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(10.0, 0.1, "AUG");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(12.0, 0.1, "SEP");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(14.0, 0.1, "OCT");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(16.0, 0.1, "NOV");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(18.0, 0.1, "DEC");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(20.0, 0.1, "JAN");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(22.0, 0.1, "FEB");
			Chart2.ChartAreas[0].AxisX.CustomLabels.Add(24.0, 0.1, "MAR");
			Chart2.DataBind();
			Chart2.Visible = true;
			Chart3.Series[0].ChartType = SeriesChartType.Column;
			Chart3.Series[0]["DrawingStyle"] = "Cylinder";
			Chart3.Series[0]["PointWidth"] = "0.7";
			Chart3.Series[0].IsValueShownAsLabel = true;
			Chart3.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
			Chart3.ChartAreas[0].BackColor = Color.PaleTurquoise;
			Chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
			Chart3.ChartAreas[0].Area3DStyle.PointDepth = 100;
			Chart3.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
			Chart3.ChartAreas[0].AxisY.IsStartedFromZero = true;
			DataTable dataTable3 = new DataTable();
			new DataTable();
			dataTable3.Columns.Add(new DataColumn("wo", typeof(string)));
			string[] array3 = new string[12]
			{
				"04", "05", "06", "07", "08", "09", "10", "11", "12", "01",
				"02", "03"
			};
			for (int k = 0; k < array.Length; k++)
			{
				string cmdText4 = "Select count(*) as count_wo from SD_Cust_WorkOrder_Master Where SysDate like '%-" + array3[k] + "-%'AND FinYearId='" + num + "' AND CompId='" + num2 + "'";
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				DataRow dataRow3 = dataTable3.NewRow();
				dataRow3[0] = dataSet4.Tables[0].Rows[0][0].ToString();
				dataTable3.Rows.Add(dataRow3);
			}
			Chart3.ChartAreas[0].AxisX.Interval = 1.0;
			Chart3.ChartAreas[0].AxisY.Title = "Total No. of Work Order";
			Chart3.Series[0].YValueMembers = dataTable3.Columns[0].ToString();
			Chart3.DataSource = dataTable3;
			Chart3.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8f);
			Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(2.0, 0.1, "APR");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(4.0, 0.1, "MAY");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(6.0, 0.1, "JUN");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(8.0, 0.1, "JUL");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(10.0, 0.1, "AUG");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(12.0, 0.1, "SEP");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(14.0, 0.1, "OCT");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(16.0, 0.1, "NOV");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(18.0, 0.1, "DEC");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(20.0, 0.1, "JAN");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(22.0, 0.1, "FEB");
			Chart3.ChartAreas[0].AxisX.CustomLabels.Add(24.0, 0.1, "MAR");
			Chart3.DataBind();
			Chart3.Visible = true;
			Chart4.Series[0].ChartType = SeriesChartType.Column;
			Chart4.Series[0]["DrawingStyle"] = "Cylinder";
			Chart4.Series[0]["PointWidth"] = "0.7";
			Chart4.Series[0].IsValueShownAsLabel = true;
			Chart4.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
			Chart4.ChartAreas[0].BackColor = Color.LightSalmon;
			Chart4.ChartAreas[0].Area3DStyle.Enable3D = true;
			Chart4.ChartAreas[0].Area3DStyle.PointDepth = 100;
			Chart4.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
			Chart4.ChartAreas[0].AxisY.IsStartedFromZero = true;
			DataTable dataTable4 = new DataTable();
			new DataTable();
			dataTable4.Columns.Add(new DataColumn("da", typeof(string)));
			string[] array4 = new string[12]
			{
				"04", "05", "06", "07", "08", "09", "10", "11", "12", "01",
				"02", "03"
			};
			for (int l = 0; l < array.Length; l++)
			{
				string cmdText5 = "Select count(*) as count_da from SD_Cust_WorkOrder_Dispatch Where SysDate like '%-" + array4[l] + "-%'AND FinYearId='" + num + "' AND CompId='" + num2 + "'";
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				DataRow dataRow4 = dataTable4.NewRow();
				dataRow4[0] = dataSet5.Tables[0].Rows[0][0].ToString();
				dataTable4.Rows.Add(dataRow4);
			}
			Chart4.ChartAreas[0].AxisX.Interval = 1.0;
			Chart4.ChartAreas[0].AxisY.Title = "Total No. of Dispatch";
			Chart4.Series[0].YValueMembers = dataTable4.Columns[0].ToString();
			Chart4.DataSource = dataTable4;
			Chart4.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8f);
			Chart4.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(2.0, 0.1, "APR");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(4.0, 0.1, "MAY");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(6.0, 0.1, "JUN");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(8.0, 0.1, "JUL");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(10.0, 0.1, "AUG");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(12.0, 0.1, "SEP");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(14.0, 0.1, "OCT");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(16.0, 0.1, "NOV");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(18.0, 0.1, "DEC");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(20.0, 0.1, "JAN");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(22.0, 0.1, "FEB");
			Chart4.ChartAreas[0].AxisX.CustomLabels.Add(24.0, 0.1, "MAR");
			Chart4.DataBind();
			Chart4.Visible = true;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		Enquirygrid();
		drawgraph();
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		POgrid();
		drawgraph();
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		WOgrid();
		drawgraph();
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		DAgrid();
		drawgraph();
	}
}

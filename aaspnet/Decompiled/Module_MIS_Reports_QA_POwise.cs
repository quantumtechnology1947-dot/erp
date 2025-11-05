using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MIS_Reports_QA_POwise : Page, IRequiresSessionState
{
	protected CrystalReportSource CrystalReportSource1;

	protected CrystalReportViewer CrystalReportViewer1;

	protected Panel Panel1;

	protected TabPanel TabPanel1;

	protected Label lblSup;

	protected TextBox txtSupplier;

	protected Button btnSearch;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected Chart Chart1;

	protected UpdatePanel UpdatePanel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string connStr = string.Empty;

	private SqlConnection con;

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		try
		{
			Key = base.Request.QueryString["Key"].ToString();
			if (!base.IsPostBack)
			{
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CompId = Convert.ToInt32(Session["compid"]);
				con.Open();
				string cmdText = "Select ROW_NUMBER() OVER(ORDER BY Id)AS SrNo,Id,PONo,tblMM_Supplier_master.SupplierName+'['+ tblMM_Supplier_master.SupplierId+']' As Supplier,PRSPRFlag from tblMM_PO_Master inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblMM_PO_Master.SupplierId And tblMM_PO_Master.FinyearId=" + FinYearId + " order by Id ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SrNo", typeof(long)));
				while (sqlDataReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = sqlDataReader["Id"];
					dataRow[1] = sqlDataReader["PONo"].ToString();
					dataRow[2] = sqlDataReader["Supplier"].ToString();
					dataRow[3] = CompId;
					dataRow[4] = Convert.ToInt64(sqlDataReader["SrNo"]);
					string cmdText2 = string.Empty;
					if (sqlDataReader["PRSPRFlag"].ToString() == "0")
					{
						cmdText2 = "select ROW_NUMBER()OVER (ORDER BY ItemCode)AS SrNo,AH,ItemCode,Description,UOM,POQty,MId,AccQty,AccNo,PvevQty,PvevNo from View_QA_PR where MId='" + sqlDataReader["Id"].ToString() + "' ";
					}
					else if (sqlDataReader["PRSPRFlag"].ToString() == "1")
					{
						cmdText2 = "select ROW_NUMBER()OVER (ORDER BY ItemCode)AS SrNo,AH,ItemCode,Description,UOM,POQty,MId,AccQty,AccNo,PvevQty,PvevNo from View_QA_SPR where MId='" + sqlDataReader["Id"].ToString() + "' ";
					}
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					SqlDataReader reader = sqlCommand2.ExecuteReader();
					dataTable2.Load(reader);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet = new QA_POWise();
				dataSet.Tables[0].Merge(dataTable);
				dataSet.Tables[1].Merge(dataTable2);
				dataSet.AcceptChanges();
				string text = base.Server.MapPath("~/Module/MIS/Reports/QA_POWise_Print.rpt");
				report.Load(text);
				report.SetDataSource(dataSet);
				string company = fun.getCompany(CompId);
				report.SetParameterValue("Company", (object)company);
				string text2 = fun.CompAdd(CompId);
				report.SetParameterValue("Address", (object)text2);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				con.Close();
			}
			else
			{
				Key = base.Request.QueryString["Key"].ToString();
				ReportDocument reportSource = (ReportDocument)Session[Key];
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		Key = base.Request.QueryString["Key"].ToString();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}

	public void drawgraph()
	{
		try
		{
			DataTable dataTable = new DataTable();
			Chart1.ChartAreas[0].BackColor = Color.LightGoldenrodYellow;
			Chart1.ChartAreas[0].Area3DStyle.PointDepth = 100;
			Chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 100;
			Chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;
			Chart1.ChartAreas[0].AxisX.Interval = 1.0;
			string cmdText = "Select FinYear from tblfinancial_master Where FinYearId='" + FinYearId + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				Chart1.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
			}
			string text = "";
			if (!(txtSupplier.Text != ""))
			{
				return;
			}
			text = " AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'";
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable2.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("GQNQty", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("GSNQty", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("PVEVQty", typeof(double)));
			string cmdText2 = "SELECT UOM,Sum([POQty]) As POQty FROM [dbo].[View_QA_PR] where FinYearId=" + FinYearId + text + "   group by  UOM union All SELECT UOM,Sum([POQty]) As POQty FROM [dbo].[View_QA_SPR] where FinYearId=" + FinYearId + text + "  group by  UOM";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			DataSet dataSet2 = new DataSet();
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2);
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable2.NewRow();
				dataRow[0] = dataSet2.Tables[0].Rows[i]["UOM"].ToString();
				dataRow[1] = Math.Round(Convert.ToDouble(dataSet2.Tables[0].Rows[i]["POQty"]), 2);
				dataRow[2] = 0;
				dataRow[3] = 0;
				dataRow[4] = 0;
				dataTable2.Rows.Add(dataRow);
				dataTable2.AcceptChanges();
			}
			string cmdText3 = "SELECT UOM,Sum([GQNQty]) As GQNQty  FROM View_GQN_UOM_Graph where FinYearId=" + FinYearId + " " + text + " group by UOM";
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			DataSet dataSet3 = new DataSet();
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3);
			for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
			{
				DataRow dataRow = dataTable2.NewRow();
				dataRow[0] = dataSet3.Tables[0].Rows[j]["UOM"].ToString();
				dataRow[1] = 0;
				dataRow[2] = Math.Round(Convert.ToDouble(dataSet3.Tables[0].Rows[j]["GQNQty"]), 2);
				dataRow[3] = 0;
				dataRow[4] = 0;
				dataTable2.Rows.Add(dataRow);
				dataTable2.AcceptChanges();
			}
			string cmdText4 = "SELECT UOM,Sum([GSNQty]) As GSNQty  FROM View_GSN_UOM_Graph where FinYearId=" + FinYearId + " " + text + " group by UOM";
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			DataSet dataSet4 = new DataSet();
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			sqlDataAdapter4.Fill(dataSet4);
			for (int k = 0; k < dataSet4.Tables[0].Rows.Count; k++)
			{
				DataRow dataRow = dataTable2.NewRow();
				dataRow[0] = dataSet4.Tables[0].Rows[k]["UOM"].ToString();
				dataRow[1] = 0;
				dataRow[2] = 0;
				dataRow[3] = Math.Round(Convert.ToDouble(dataSet4.Tables[0].Rows[k]["GSNQty"]), 2);
				dataRow[4] = 0;
				dataTable2.Rows.Add(dataRow);
				dataTable2.AcceptChanges();
			}
			string cmdText5 = "SELECT UOM,Sum([PvevQty]) As PvevQty  FROM View_PVEV_UOM_Graph where FinYearId=" + FinYearId + " " + text + " group by UOM";
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			DataSet dataSet5 = new DataSet();
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			sqlDataAdapter5.Fill(dataSet5);
			for (int l = 0; l < dataSet5.Tables[0].Rows.Count; l++)
			{
				DataRow dataRow = dataTable2.NewRow();
				dataRow[0] = dataSet5.Tables[0].Rows[l]["UOM"].ToString();
				dataRow[1] = 0;
				dataRow[2] = 0;
				dataRow[3] = 0;
				dataRow[4] = Math.Round(Convert.ToDouble(dataSet5.Tables[0].Rows[l]["PvevQty"]), 2);
				dataTable2.Rows.Add(dataRow);
				dataTable2.AcceptChanges();
			}
			var varlist = from row in dataTable2.AsEnumerable()
				group row by new
				{
					x = row.Field<string>("UOM")
				} into grp
				let row1 = grp.First()
				select new
				{
					UOM = row1.Field<string>("UOM"),
					PO = grp.Sum((DataRow r) => r.Field<double>("POQty")),
					GQN = grp.Sum((DataRow r) => r.Field<double>("GQNQty")),
					GSN = grp.Sum((DataRow r) => r.Field<double>("GSNQty")),
					PVEV = grp.Sum((DataRow r) => r.Field<double>("PVevQty"))
				};
			dataTable = LINQToDataTable(varlist);
			string[] array = new string[dataTable.Rows.Count];
			double[] array2 = new double[dataTable.Rows.Count];
			double[] array3 = new double[dataTable.Rows.Count];
			double[] array4 = new double[dataTable.Rows.Count];
			double[] array5 = new double[dataTable.Rows.Count];
			for (int num = 0; num < dataTable.Rows.Count; num++)
			{
				array[num] = dataTable.Rows[num]["UOM"].ToString();
				array2[num] = Convert.ToDouble(dataTable.Rows[num][1]);
				if (dataTable.Rows[num][2] != DBNull.Value)
				{
					array3[num] = Convert.ToDouble(dataTable.Rows[num][2]);
				}
				else
				{
					array3[num] = 0.0;
				}
				if (dataTable.Rows[num][3] != DBNull.Value)
				{
					array4[num] = Convert.ToDouble(dataTable.Rows[num][3]);
				}
				else
				{
					array4[num] = 0.0;
				}
				if (dataTable.Rows[num][4] != DBNull.Value)
				{
					array5[num] = Convert.ToDouble(dataTable.Rows[num][4]);
				}
				else
				{
					array5[num] = 0.0;
				}
			}
			Chart1.Series[0].Points.DataBindXY(array, array2);
			Chart1.Series[1].Points.DataBindXY(array, array3);
			Chart1.Series[2].Points.DataBindXY(array, array4);
			Chart1.Series[3].Points.DataBindXY(array, array5);
		}
		catch (Exception)
		{
		}
	}

	public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
	{
		DataTable dataTable = new DataTable();
		PropertyInfo[] array = null;
		if (varlist == null)
		{
			return dataTable;
		}
		foreach (T item in varlist)
		{
			if (array == null)
			{
				array = item.GetType().GetProperties();
				PropertyInfo[] array2 = array;
				foreach (PropertyInfo propertyInfo in array2)
				{
					Type type = propertyInfo.PropertyType;
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						type = type.GetGenericArguments()[0];
					}
					dataTable.Columns.Add(new DataColumn(propertyInfo.Name, type));
				}
			}
			DataRow dataRow = dataTable.NewRow();
			PropertyInfo[] array3 = array;
			foreach (PropertyInfo propertyInfo2 in array3)
			{
				dataRow[propertyInfo2.Name] = ((propertyInfo2.GetValue(item, null) == null) ? DBNull.Value : propertyInfo2.GetValue(item, null));
			}
			dataTable.Rows.Add(dataRow);
		}
		return dataTable;
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList2(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		drawgraph();
	}
}

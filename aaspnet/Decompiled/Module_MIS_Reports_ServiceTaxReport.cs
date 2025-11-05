using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MIS_Reports_ServiceTaxReport : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId = "";

	private string WN = "";

	private double Amount;

	protected DropDownList DropDownList1;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Chart Chart2;

	protected Label lblturn;

	protected Chart Chart1;

	protected Label lbltaxturn;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		try
		{
			if (!Page.IsPostBack)
			{
				txtpoNo.Visible = false;
			}
			bindgrid(CId, WN);
			drawgraph();
			drawgraphBasic();
		}
		catch (Exception)
		{
		}
	}

	public string Monthly(string FD)
	{
		string result = "";
		try
		{
			string[] array = FD.Split('-');
			_ = array[0];
			string text = array[1];
			_ = array[2];
			result = text;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public void bindgrid(string Cid, string wn)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		try
		{
			sqlConnection.Open();
			if (DropDownList1.SelectedValue == "Select")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
			}
			string text = "";
			if (DropDownList1.SelectedValue == "0" && txtCustName.Text != "")
			{
				string code = fun.getCode(txtCustName.Text);
				text = " AND CustomerCode='" + code + "'";
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "1" && txtpoNo.Text != "")
			{
				text2 = " AND InvoiceNo='" + txtpoNo.Text + "'";
			}
			string cmdText = fun.select("Id,FinYearId,SysDate,InvoiceNo,WONo,PONo,CustomerCode,InvoiceNo,AddType,AddAmt,DeductionType,Deduction,ServiceTax,TaxableServices", "tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'" + text + text2 + " Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InVoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MISMonth", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BAmount", typeof(double)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("sum ((ReqQty*AmtInPer/100)*Rate) as Amt", " tblACC_ServiceTaxInvoice_Details", string.Concat(" InvoiceNo='", dataSet.Tables[0].Rows[i]["InvoiceNo"], "'"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					double num = Math.Round(Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Amt"]), 2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string value2 = Monthly(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string cmdText4 = fun.select("CustomerName,CustomerId", "SD_Cust_master", string.Concat("CustomerId='", dataSet.Tables[0].Rows[i]["CustomerCode"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					double num2 = 0.0;
					double num3 = 0.0;
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["AddAmt"].ToString()).ToString("N2"));
					num2 = ((Convert.ToInt32(dataSet.Tables[0].Rows[i]["AddType"]) != 0) ? (num + num * num3 / 100.0) : (num + num3));
					int num4 = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DeductionType"]);
					double num5 = 0.0;
					num5 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Deduction"].ToString()).ToString("N2"));
					double num6 = 0.0;
					num6 = ((num4 != 0) ? (num2 - num2 * num5 / 100.0) : (num2 - num5));
					int num7 = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ServiceTax"]);
					string cmdText5 = fun.select("Id  , Terms, Value ,AccessableValue , EDUCess, SHECess, Live, LiveSerTax ", "tblExciseser_Master", "Id='" + num7 + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					double num8 = 0.0;
					num8 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["Value"]);
					Amount = Math.Round(num6 + num6 * num8 / 100.0, 2);
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow[3] = value;
					dataRow[4] = dataSet4.Tables[0].Rows[0]["CustomerName"].ToString() + "[" + dataSet4.Tables[0].Rows[0]["CustomerId"].ToString() + "]";
					dataRow[5] = dataSet4.Tables[0].Rows[0]["CustomerId"].ToString();
					dataRow[6] = Amount;
					dataRow[7] = value2;
					dataRow[8] = num;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		bindgrid(CId, WN);
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			bindgrid(txtCustName.Text, txtpoNo.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtpoNo.Visible = false;
				txtCustName.Visible = true;
				txtCustName.Text = "";
				bindgrid(CId, WN);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
				txtpoNo.Text = "";
				bindgrid(CId, WN);
			}
		}
		catch (Exception)
		{
		}
	}

	public void drawgraph()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(Session["finyear"]);
		Convert.ToInt32(Session["compid"]);
		string cmdText = "Select FinYear from tblfinancial_master Where FinYearId='" + num + "'";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		Chart1.Series[0].ChartType = SeriesChartType.Column;
		Chart1.Series[0]["DrawingStyle"] = "Cylinder";
		Chart1.Series[0]["PointWidth"] = "0.3";
		Chart1.Series[0].IsValueShownAsLabel = true;
		Chart1.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
		Chart1.ChartAreas[0].BackColor = Color.LightGreen;
		Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
		Chart1.ChartAreas[0].Area3DStyle.PointDepth = 250;
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
		double num2 = 0.0;
		for (int i = 0; i < array.Length; i++)
		{
			double num3 = 0.0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((Label)row.FindControl("lblMISMonth")).Text == array[i])
				{
					num3 += Convert.ToDouble(((Label)row.FindControl("lblAmt")).Text);
				}
			}
			num2 += num3;
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = num3;
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
		}
		lbltaxturn.Text = "Total ServiceTax Tax Sales : " + num2;
		Chart1.ChartAreas[0].AxisX.Interval = 1.0;
		Chart1.ChartAreas[0].AxisY.Title = "Amount in  Rs.";
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
	}

	public void drawgraphBasic()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(Session["finyear"]);
		Convert.ToInt32(Session["compid"]);
		string cmdText = "Select FinYear from tblfinancial_master Where FinYearId='" + num + "'";
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		Chart2.Series[0].ChartType = SeriesChartType.Column;
		Chart2.Series[0]["DrawingStyle"] = "Cylinder";
		Chart2.Series[0]["PointWidth"] = "0.3";
		Chart2.Series[0].IsValueShownAsLabel = true;
		Chart2.ChartAreas[0].AxisX.Title = "Fin. Year  " + dataSet.Tables[0].Rows[0][0].ToString();
		Chart2.ChartAreas[0].BackColor = Color.LightGreen;
		Chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
		Chart2.ChartAreas[0].Area3DStyle.PointDepth = 250;
		Chart2.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
		Chart2.ChartAreas[0].AxisY.IsStartedFromZero = true;
		DataTable dataTable = new DataTable();
		new DataTable();
		dataTable.Columns.Add(new DataColumn("ct", typeof(string)));
		string[] array = new string[12]
		{
			"04", "05", "06", "07", "08", "09", "10", "11", "12", "01",
			"02", "03"
		};
		double num2 = 0.0;
		for (int i = 0; i < array.Length; i++)
		{
			double num3 = 0.0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((Label)row.FindControl("lblMISMonth")).Text == array[i])
				{
					num3 += Convert.ToDouble(((Label)row.FindControl("lblBAmt")).Text);
				}
			}
			num2 += num3;
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = num3;
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
		}
		lblturn.Text = "Total ServiceTax Basic Sales : " + num2;
		Chart2.ChartAreas[0].AxisX.Interval = 1.0;
		Chart2.ChartAreas[0].AxisY.Title = "Amount in  Rs.";
		Chart2.Series[0].YValueMembers = dataTable.Columns[0].ToString();
		Chart2.DataSource = dataTable;
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
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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
}

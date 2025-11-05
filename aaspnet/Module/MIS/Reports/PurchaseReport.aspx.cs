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

public class Module_MIS_Reports_PurchaseReport : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId = "";

	private string WN = "";

	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected TextBox txtpoNo;

	protected Button Button1;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Chart Chart2;

	protected Label lblturn;

	protected Chart Chart1;

	protected Label lblTaxturn;

	protected UpdatePanel UpdatePanel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
				txtpoNo.Visible = false;
				Drpcheckchange();
				bindgrid(CId, WN);
			}
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
			if (DropDownList1.SelectedValue == "0")
			{
				txtpoNo.Visible = true;
				txtSupplier.Visible = false;
			}
			string text = "";
			if (DropDownList1.SelectedValue == "1" && txtSupplier.Text != "")
			{
				string code = fun.getCode(txtSupplier.Text);
				text = " AND SupplierId ='" + code + "'";
			}
			string text2 = "";
			if (DropDownList1.SelectedValue == "2" && txtpoNo.Text != "")
			{
				text2 = " AND PONo='" + txtpoNo.Text + "'";
			}
			string cmdText = fun.select("Id,FinYearId,SysDate,PONo,SupplierId", "tblMM_PO_Master", "CompId='" + CompId + "' And Authorize='1' And FinYearId='" + FinYearId + "'" + text + text2 + " Order by Id Desc ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POMonth", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BAmount", typeof(double)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("sum( (Rate*Qty) -(rate*Discount)/100) as Total", " tblMM_PO_Details", string.Concat(" PONo='", dataSet.Tables[0].Rows[i]["PONo"], "'group by PONo"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					double num = Math.Round(Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Total"]), 2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string value2 = Monthly(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					string cmdText4 = fun.select("SupplierName,SupplierId", "tblMM_Supplier_master", string.Concat("SupplierId='", dataSet.Tables[0].Rows[i]["SupplierId"], "' And CompId='", CompId, "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					string cmdText5 = fun.select("PF,ExST,VAT", " tblMM_PO_Details", string.Concat(" PONo='", dataSet.Tables[0].Rows[i]["PONo"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					int num2 = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["PF"]);
					int num3 = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ExST"]);
					int num4 = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["VAT"]);
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					string cmdText6 = fun.select("Value", "tblPacking_Master", "Id='" + num2 + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					num7 = Convert.ToDouble(dataSet6.Tables[0].Rows[0]["Value"]);
					num8 = num * num7 / 100.0;
					string cmdText7 = fun.select("Id,Terms,Value,AccessableValue,EDUCess,SHECess,Live,LiveSerTax", "tblExciseser_Master", "Id='" + num3 + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					num6 = Convert.ToDouble(dataSet7.Tables[0].Rows[0]["Value"]);
					double num9 = (num + num8) * num6 / 100.0;
					double num10 = 0.0;
					string cmdText8 = fun.select("Id  , Terms, Value ", "tblVAT_Master", "Id='" + num4 + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8);
					num5 = Convert.ToDouble(dataSet8.Tables[0].Rows[0]["Value"]);
					num10 = (num + num8 + num9) * num5 / 100.0;
					double value3 = num + num8 + num9 + num10;
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[3] = value;
					dataRow[4] = dataSet4.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet4.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
					dataRow[5] = dataSet4.Tables[0].Rows[0]["SupplierId"].ToString();
					dataRow[6] = Math.Round(value3, 2);
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
				if (((Label)row.FindControl("lblPOMonth")).Text == array[i])
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
		lblTaxturn.Text = "Total Tax. Purchase Amt. : " + num2;
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

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		SqlConnection sqlConnection = new SqlConnection(connectionString);
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		bindgrid(CId, WN);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			bindgrid(txtSupplier.Text, txtpoNo.Text);
			drawgraph();
			drawgraphBasic();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		Drpcheckchange();
	}

	public void Drpcheckchange()
	{
		if (DropDownList1.SelectedValue == "1")
		{
			txtpoNo.Visible = false;
			txtSupplier.Visible = true;
			txtSupplier.Text = "";
		}
		if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "0")
		{
			txtpoNo.Visible = true;
			txtSupplier.Visible = false;
			txtpoNo.Text = "";
		}
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
				if (((Label)row.FindControl("lblPOMonth")).Text == array[i])
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
		lblturn.Text = "Total Basic Purchase Amt. : " + num2;
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
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Reports_InwardOutwardRegister : Page, IRequiresSessionState
{
	protected Label Label2;

	protected TextBox TxtFromDt;

	protected CalendarExtender TxtFromDt_CalendarExtender;

	protected RegularExpressionValidator ReqTDate;

	protected Label Label4;

	protected TextBox TxtToDt;

	protected CalendarExtender CalendarExtender1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button Button1;

	protected Label Label5;

	protected Label Label1;

	protected Label Label3;

	protected GridView GridView1;

	protected Panel Panel1;

	protected GridView GridView2;

	protected Panel Panel2;

	protected GridView GridView3;

	protected Panel Panel3;

	protected Label Label6;

	protected Label lblGINTot;

	protected Label Label8;

	protected Label lblGRRTot;

	protected Label Label7;

	protected Label lblGSNTot;

	protected TabPanel TabPanel1;

	protected GridView GridView4;

	protected Panel Panel4;

	protected GridView GridView5;

	protected Panel Panel5;

	protected Label Label9;

	protected Label lblMRSTot;

	protected Label Label10;

	protected Label lblMINTot;

	protected TabPanel TabPanel2;

	protected GridView GridView6;

	protected Panel Panel6;

	protected Label Label11;

	protected Label lblWISTot;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string Fdt = string.Empty;

	private string Tdt = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				Fdt = fun.FromDateDMY(fun.getCurrDate());
				Tdt = fun.FromDateDMY(fun.getCurrDate());
				TxtFromDt.Text = Fdt;
				TxtToDt.Text = Tdt;
			}
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			lblGINTot.Text = "0";
			lblGSNTot.Text = "0";
			calc();
		}
		catch (Exception)
		{
		}
	}

	public void calc()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable = getMRSDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView4.DataSource = dataTable;
			GridView4.DataBind();
			object obj = dataTable.Compute("Sum(MRSAmt)", "");
			if (obj.ToString() != "")
			{
				lblMRSTot.Text = Math.Round(Convert.ToDouble(obj.ToString()), 2).ToString();
			}
			else
			{
				lblMRSTot.Text = "0";
			}
			DataTable dataTable2 = new DataTable();
			dataTable2 = getMINDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView5.DataSource = dataTable2;
			GridView5.DataBind();
			object obj2 = dataTable2.Compute("Sum(MINAmt)", "");
			if (obj2.ToString() != "")
			{
				lblMINTot.Text = Math.Round(Convert.ToDouble(obj2.ToString()), 2).ToString();
			}
			else
			{
				lblMINTot.Text = "0";
			}
			DataTable dataTable3 = new DataTable();
			dataTable3 = getWISDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView6.DataSource = dataTable3;
			GridView6.DataBind();
			object obj3 = dataTable3.Compute("Sum(WISAmt)", "");
			if (obj3.ToString() != "")
			{
				lblWISTot.Text = Math.Round(Convert.ToDouble(obj3.ToString()), 2).ToString();
			}
			else
			{
				lblWISTot.Text = "0";
			}
			DataTable dataTable4 = new DataTable();
			dataTable4 = getGINDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView1.DataSource = dataTable4;
			GridView1.DataBind();
			object obj4 = dataTable4.Compute("Sum(GINAmt)", "");
			if (obj4.ToString() != "")
			{
				lblGINTot.Text = Math.Round(Convert.ToDouble(obj4.ToString()), 2).ToString();
			}
			else
			{
				lblGINTot.Text = "0";
			}
			DataTable dataTable5 = new DataTable();
			dataTable5 = getGRRDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView2.DataSource = dataTable5;
			GridView2.DataBind();
			object obj5 = dataTable5.Compute("Sum(GRRAmt)", "");
			if (obj5.ToString() != "")
			{
				lblGRRTot.Text = Math.Round(Convert.ToDouble(obj5.ToString()), 2).ToString();
			}
			else
			{
				lblGRRTot.Text = "0";
			}
			DataTable dataTable6 = new DataTable();
			dataTable6 = getGSNDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView3.DataSource = dataTable6;
			GridView3.DataBind();
			object obj6 = dataTable6.Compute("Sum(GSNAmt)", "");
			if (obj6.ToString() != "")
			{
				lblGSNTot.Text = Math.Round(Convert.ToDouble(obj6.ToString()), 2).ToString();
			}
			else
			{
				lblGSNTot.Text = "0";
			}
		}
		catch (Exception)
		{
		}
	}

	public DataTable getMRSDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("MRSNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRSAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "SELECT  MRSNo,Sum(Amt) As Amt,SysDate FROM View_MRS_InOutReg WHERE SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearid='" + FinYearId + "' Group by MRSNo,SysDate Order by MRSNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["MRSNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	public DataTable getMINDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("MINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MINAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "select  MINNo,Sum(Amt) As Amt,SysDate FROM View_MIN_InOutReg_Details WHERE SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearId='" + FinYearId + "' Group by MINNo,SysDate Order by MINNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["MINNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	public DataTable getWISDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("WISNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WISAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "select  WISNo,Sum(Amt) As Amt,SysDate FROM View_WIS_InOutReg WHERE SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearId='" + FinYearId + "' Group by WISNo,SysDate Order by WISNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["WISNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	public DataTable getGINDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "select GINNo,Sum(Amt) As Amt,GINDate FROM View_GIN_InOutReg_Details WHERE GINDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearId='" + FinYearId + "' Group by GINNo,GINDate Order by GINNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["GINNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["GINDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	public DataTable getGRRDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("GRRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "select GRRNo,Sum(Amt) As Amt,GRRDate FROM View_GRR_InOutReg_Details WHERE GRRDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearId='" + FinYearId + "' Group by GRRNo,GRRDate Order by GRRNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["GRRNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["GRRDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	public DataTable getGSNDetails(string fdt, string tdt)
	{
		DataTable dataTable = new DataTable();
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GSNAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "select GSNNo,Sum(Amt) As Amt,GSNDate FROM View_GSN_InOutReg_Details WHERE GSNDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' AND FinYearId='" + FinYearId + "' Group by GSNNo,GSNDate Order by GSNNo DESC";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["GSNNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["GSNDate"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			sqlConnection.Close();
			return dataTable;
		}
		catch (Exception)
		{
			return dataTable;
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		calc();
	}
}

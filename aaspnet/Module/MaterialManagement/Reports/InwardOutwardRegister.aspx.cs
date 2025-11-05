using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Reports_InwardOutwardRegister : Page, IRequiresSessionState
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

	protected Label Label6;

	protected Label Label7;

	protected GridView GridView2;

	protected Panel Panel1;

	protected GridView GridView3;

	protected Panel Panel2;

	protected GridView GridView4;

	protected Panel Panel3;

	protected Label Label8;

	protected Label lblPRTot;

	protected Label Label9;

	protected Label lblSPRTot;

	protected Label Label10;

	protected Label lblPOTot;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private DataTable dtPR = new DataTable();

	private DataTable dtSPR = new DataTable();

	private DataTable dtPO = new DataTable();

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
			lblPRTot.Text = "0";
			lblSPRTot.Text = "0";
			calc();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		calc();
	}

	public void calc()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable = getPRDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			object obj = dataTable.Compute("Sum(PRAmt)", "");
			if (obj.ToString() != "")
			{
				lblPRTot.Text = Math.Round(Convert.ToDouble(obj.ToString()), 2).ToString();
			}
			else
			{
				lblPRTot.Text = "0";
			}
			DataTable dataTable2 = new DataTable();
			dataTable2 = getSPRDetails(TxtFromDt.Text, TxtToDt.Text);
			GridView3.DataSource = dataTable2;
			GridView3.DataBind();
			object obj2 = dataTable2.Compute("Sum(SPRAmt)", "");
			if (obj2.ToString() != "")
			{
				lblSPRTot.Text = Math.Round(Convert.ToDouble(obj2.ToString()), 2).ToString();
			}
			else
			{
				lblSPRTot.Text = "0";
			}
			DataTable dataTable3 = new DataTable();
			dataTable3 = getPODetails(TxtFromDt.Text, TxtToDt.Text);
			GridView4.DataSource = dataTable3;
			GridView4.DataBind();
			object obj3 = dataTable3.Compute("Sum(POAmt)", "");
			if (obj3.ToString() != "")
			{
				lblPOTot.Text = Math.Round(Convert.ToDouble(obj3.ToString()), 2).ToString();
			}
			else
			{
				lblPOTot.Text = "0";
			}
		}
		catch (Exception)
		{
		}
	}

	public DataTable getPRDetails(string fdt, string tdt)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dtPR.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dtPR.Columns.Add(new DataColumn("PRAmt", typeof(double)));
			dtPR.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "SELECT tblMM_PR_Master.SysDate,tblMM_PR_Master.PRNo, Sum((tblMM_PR_Details.Qty * (tblMM_PR_Details.Rate -(tblMM_PR_Details.Rate*tblMM_PR_Details.Discount/100)))) As Amt FROM tblMM_PR_Details INNER JOIN tblMM_PR_Master ON tblMM_PR_Details.MId = tblMM_PR_Master.Id AND tblMM_PR_Master.FinYearId='" + FinYearId + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' Group by tblMM_PR_Master.PRNo,tblMM_PR_Master.SysDate Order by tblMM_PR_Master.SysDate Desc;";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dtPR.NewRow();
				dataRow[0] = sqlDataReader["PRNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dtPR.Rows.Add(dataRow);
				dtPR.AcceptChanges();
			}
			sqlConnection.Close();
			return dtPR;
		}
		catch (Exception)
		{
		}
		return dtPR;
	}

	public DataTable getSPRDetails(string fdt, string tdt)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dtSPR.Columns.Add(new DataColumn("SPRNo", typeof(string)));
			dtSPR.Columns.Add(new DataColumn("SPRAmt", typeof(double)));
			dtSPR.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "SELECT tblMM_SPR_Master.SysDate,tblMM_SPR_Master.SPRNo, Sum((tblMM_SPR_Details.Qty * (tblMM_SPR_Details.Rate -(tblMM_SPR_Details.Rate*tblMM_SPR_Details.Discount/100)))) As Amt FROM tblMM_SPR_Details INNER JOIN tblMM_SPR_Master ON tblMM_SPR_Details.MId = tblMM_SPR_Master.Id AND tblMM_SPR_Master.FinYearId='" + FinYearId + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' Group by tblMM_SPR_Master.SPRNo,tblMM_SPR_Master.SysDate Order by tblMM_SPR_Master.SysDate Desc;";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dtSPR.NewRow();
				dataRow[0] = sqlDataReader["SPRNo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dtSPR.Rows.Add(dataRow);
				dtSPR.AcceptChanges();
			}
			sqlConnection.Close();
			return dtSPR;
		}
		catch (Exception)
		{
		}
		return dtSPR;
	}

	public DataTable getPODetails(string fdt, string tdt)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			dtPO.Columns.Add(new DataColumn("PONo", typeof(string)));
			dtPO.Columns.Add(new DataColumn("POAmt", typeof(double)));
			dtPO.Columns.Add(new DataColumn("RDate", typeof(string)));
			string cmdText = "SELECT tblMM_PO_Master.SysDate, tblMM_PO_Master.PONo,Sum((tblMM_PO_Details.Qty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100)))) As Amt  FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId AND tblMM_PO_Master.FinYearId='" + FinYearId + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.SysDate between '" + fun.FromDate(fdt) + "' AND '" + fun.FromDate(tdt) + "' Group by tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate Order by tblMM_PO_Master.SysDate Desc;";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dtPO.NewRow();
				dataRow[0] = sqlDataReader["PONo"].ToString();
				if (sqlDataReader["Amt"].ToString() != "")
				{
					dataRow[1] = Math.Round(Convert.ToDouble(sqlDataReader["Amt"].ToString()), 2).ToString();
				}
				else
				{
					dataRow[1] = "0";
				}
				dataRow[2] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dtPO.Rows.Add(dataRow);
				dtPO.AcceptChanges();
			}
			sqlConnection.Close();
			return dtPO;
		}
		catch (Exception)
		{
		}
		return dtPO;
	}
}

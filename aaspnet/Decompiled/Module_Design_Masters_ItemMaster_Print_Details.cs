using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_Design_Masters_ItemMaster_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected HtmlForm form1;

	private string Category = "";

	private string SearchCode = "";

	private string SearchItemCode = "";

	private string DrpTypeVal = "";

	private string DrpLocVal = "";

	private DataSet DS = new DataSet();

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FYId;

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				Category = base.Request.QueryString["category"].ToString();
				SearchCode = base.Request.QueryString["SearchCode"].ToString();
				SearchItemCode = base.Request.QueryString["SearchItemCode"].ToString();
				DrpTypeVal = base.Request.QueryString["DrpTypeVal"].ToString();
				DrpLocVal = base.Request.QueryString["DrplocationVal"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				FYId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				Fillgrid(Category, SearchCode, SearchItemCode, DrpTypeVal);
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
		cryRpt = new ReportDocument();
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}

	public void Fillgrid(string sd, string B, string s, string drptype)
	{
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataSet dataSet = new DataSet();
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			if (!(drptype != "Select"))
			{
				return;
			}
			if (drptype == "Category")
			{
				if (sd != "Select")
				{
					value = " AND tblDG_Item_Master.CId='" + sd + "'";
					if (B != "Select")
					{
						if (B == "tblDG_Item_Master.ItemCode")
						{
							value2 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
						}
						if (B == "tblDG_Item_Master.ManfDesc")
						{
							value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
						}
						if (B == "tblDG_Item_Master.Location" && DrpLocVal != "Select")
						{
							value2 = " And tblDG_Item_Master.Location='" + DrpLocVal + "'";
						}
					}
					value3 = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FYId + "'";
				}
				else if (sd == "Select" && B == "Select" && s != string.Empty)
				{
					value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
				}
			}
			else if (drptype != "Select" && drptype == "WOItems")
			{
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						value2 = " And tblDG_Item_Master.ItemCode Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				else if (B == "Select" && s != string.Empty)
				{
					value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
				}
			}
			new SqlCommand();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAllItem", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@startIndex"].Value = sd;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@pageSize"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@startIndex1"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@pageSize1"].Value = value3;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@drpType"].Value = drptype;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@drpCode"].Value = B;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value4;
			sqlDataAdapter.Fill(dataSet);
			cryRpt = new ReportDocument();
			cryRpt.Load(base.Server.MapPath("~/Module/Design/Reports/ItemMaster.rpt"));
			cryRpt.SetDataSource(dataSet.Tables[0]);
			string company = fun.getCompany(CompId);
			cryRpt.SetParameterValue("Company", (object)company);
			string text = fun.CompAdd(CompId);
			cryRpt.SetParameterValue("Address", (object)text);
			((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
			Session[Key] = cryRpt;
		}
		catch (Exception)
		{
		}
		finally
		{
			dataSet.Clear();
			dataSet.Dispose();
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}
}

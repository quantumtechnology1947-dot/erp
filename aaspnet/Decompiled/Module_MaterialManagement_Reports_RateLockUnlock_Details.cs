using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Reports_RateLockUnlock_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string Cat = "";

	private string CWType = "";

	private string SearchCode = "";

	private string SearchItemCode = "";

	private string FDate = "";

	private string TDate = "";

	private string LockBy = "";

	private int CompId;

	private string Loc = "";

	private int FinYearId;

	private DataSet DS = new DataSet();

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Expected O, but got Unknown
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				Cat = base.Request.QueryString["category"].ToString();
				CWType = base.Request.QueryString["Type"].ToString();
				SearchCode = base.Request.QueryString["SearchCode"].ToString();
				SearchItemCode = base.Request.QueryString["SearchItemCode"].ToString();
				Loc = base.Request.QueryString["loc"].ToString();
				FDate = base.Request.QueryString["FDate"].ToString();
				TDate = base.Request.QueryString["TDate"].ToString();
				LockBy = base.Request.QueryString["LockedBy"].ToString();
				Key = base.Request.QueryString["Key"].ToString();
				string value = "";
				string value2 = "";
				string value3 = "";
				string value4 = "";
				string value5 = "";
				if (!(CWType != "Select"))
				{
					return;
				}
				if (CWType == "Category")
				{
					if (Cat != "Select")
					{
						value = " AND tblDG_Item_Master.CId='" + Cat + "'";
						if (SearchCode != "0")
						{
							if (SearchCode == "1")
							{
								value2 = " And tblDG_Item_Master.ItemCode Like '" + SearchItemCode + "%'";
							}
							if (SearchCode == "2")
							{
								value2 = " And tblDG_Item_Master.ManfDesc Like '%" + SearchItemCode + "%'";
							}
						}
						value3 = " And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
						if (LockBy != "0")
						{
							value4 = " And tblMM_RateLockUnLock_Master.SessionId='" + LockBy + "' ";
						}
						if (FDate != "0" && TDate != "0")
						{
							value5 = " And tblMM_RateLockUnLock_Master.SysDate between '" + FDate + "'    and '" + TDate + "'  ";
						}
					}
				}
				else if (CWType != "Select" && CWType == "WOItems")
				{
					if (SearchCode != "0")
					{
						if (SearchCode == "1")
						{
							value2 = " And tblDG_Item_Master.ItemCode Like '%" + SearchItemCode + "%'";
						}
						if (SearchCode == "2")
						{
							value2 = " And tblDG_Item_Master.ManfDesc Like '%" + SearchItemCode + "%'";
						}
					}
					if (LockBy != "0")
					{
						value4 = " And tblMM_RateLockUnLock_Master.SessionId='" + LockBy + "' ";
					}
					if (FDate != "0" && TDate != "0")
					{
						value5 = " And tblMM_RateLockUnLock_Master.SysDate between '" + FDate + "'    and '" + TDate + "'  ";
					}
					value3 = " And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
				}
				new SqlCommand();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetRateLockUnlockPrint", sqlConnection);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex"].Value = Cat;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize"].Value = value;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex1"].Value = value2;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize1"].Value = value3;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpType"].Value = CWType;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpCode"].Value = SearchCode;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@SessionId", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@SessionId"].Value = value4;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Sysdate", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@Sysdate"].Value = value5;
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataSet dataSet2 = new RateLockUnlock();
				dataSet2.Tables[0].Merge(dataSet.Tables[0]);
				dataSet2.AcceptChanges();
				cryRpt = new ReportDocument();
				cryRpt.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/RateLockUnlock.rpt"));
				cryRpt.SetDataSource(dataSet2);
				string text = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("Address", (object)text);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				DS.Clear();
				DS.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
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
}

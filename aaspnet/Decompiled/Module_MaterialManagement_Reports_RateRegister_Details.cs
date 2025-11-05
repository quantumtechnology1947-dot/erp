using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_MaterialManagement_Reports_RateRegister_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SupCode = "";

	private int CId;

	private int ItemId;

	private int FyId;

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	protected Label Label1;

	protected TextBox txtSearchSupplier;

	protected AutoCompleteExtender txtSearchSupplier_AutoCompleteExtender;

	protected Button btnSearch;

	protected Button Btncancel;

	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			try
			{
				connStr = fun.Connection();
				con = new SqlConnection(connStr);
				CId = Convert.ToInt32(Session["compid"]);
				ItemId = Convert.ToInt32(base.Request.QueryString["ItemId"]);
				FyId = Convert.ToInt32(Session["finyear"]);
				Key = base.Request.QueryString["Key"].ToString();
				loadData(SupCode, ItemId);
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

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtSearchSupplier.Text != "")
			{
				SupCode = fun.getCode(txtSearchSupplier.Text);
				if (SupCode != "")
				{
					((Control)(object)CrystalReportViewer1).Visible = true;
					loadData(SupCode, ItemId);
					return;
				}
				((Control)(object)CrystalReportViewer1).Visible = false;
				string empty = string.Empty;
				empty = "Invalid data input";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			else
			{
				((Control)(object)CrystalReportViewer1).Visible = true;
				loadData(SupCode, ItemId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		try
		{
			base.Response.Redirect("RateRegister.aspx");
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string SupCode, int itemid)
	{
		try
		{
			DataTable dataTable = new DataTable();
			string text = "";
			string text2 = "";
			if (SupCode != "")
			{
				text = "And tblMM_Supplier_master.SupplierId ='" + SupCode + "'";
			}
			if (itemid != 0)
			{
				text2 = "And tblMM_Rate_Register.ItemId ='" + itemid + "'";
			}
			string cmdText = "SELECT  tblMM_Rate_Register.Id,tblMM_Rate_Register.ItemId,tblMM_Rate_Register.POId,tblMM_Rate_Register.Rate,tblMM_Rate_Register.Discount,tblMM_Rate_Register.IndirectCost,tblMM_Rate_Register.DirectCost,tblMM_Rate_Register.CompId,tblDG_Item_Master.ManfDesc, Unit_Master.Symbol, tblFinancial_master.FinYear, tblPacking_Master.Terms,tblExciseser_Master.Terms AS Expr1, tblVAT_Master.Terms AS Expr2 FROM  tblDG_Item_Master INNER JOIN tblMM_Rate_Register ON tblDG_Item_Master.Id = tblMM_Rate_Register.ItemId INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id INNER JOIN tblFinancial_master ON tblMM_Rate_Register.FinYearId = tblFinancial_master.FinYearId INNER JOIN tblPacking_Master ON tblMM_Rate_Register.PF = tblPacking_Master.Id INNER JOIN tblExciseser_Master ON tblMM_Rate_Register.ExST = tblExciseser_Master.Id INNER JOIN tblVAT_Master ON tblMM_Rate_Register.VAT = tblVAT_Master.Id  AND tblMM_Rate_Register.CompId='" + CId + "' AND tblMM_Rate_Register.FinYearId<='" + FyId + "'" + text + text2;
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Excise", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("IndirectCost", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DirectCost", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			new DataSet();
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"].ToString());
					dataRow[1] = fun.GetItemCode_PartNo(CId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["FinYear"].ToString();
					string cmdText2 = fun.select("PONo,SupplierId", "tblMM_PO_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string value = string.Empty;
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet2.Tables[0].Rows[0]["PONo"].ToString();
						dataRow[10] = dataSet2.Tables[0].Rows[0]["SupplierId"].ToString();
						string cmdText3 = fun.select("SupplierName,RegdCountry", "tblMM_Supplier_master", "SupplierId='" + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + "' And CompId='" + CId + "'");
						DataSet dataSet3 = new DataSet();
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						sqlDataAdapter3.Fill(dataSet3, "tblMM_Supplier_master");
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[9] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString() + '[' + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + ']';
							string cmdText4 = fun.select("Symbol", "tblCountry", "CId='" + dataSet3.Tables[0].Rows[0]["RegdCountry"].ToString() + "' ");
							DataSet dataSet4 = new DataSet();
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet4, "tblCountry");
							if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]) != 0)
							{
								value = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
					}
					else
					{
						string cmdText5 = fun.select("Symbol", "tblCountry", "CId='" + CId + "' ");
						DataSet dataSet5 = new DataSet();
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						sqlDataAdapter5.Fill(dataSet5, "tblCountry");
						value = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
					}
					dataRow[17] = value;
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
					dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
					dataRow[11] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["IndirectCost"].ToString()).ToString("N2"));
					dataRow[12] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["DirectCost"].ToString()).ToString("N2"));
					dataRow[8] = dataSet.Tables[0].Rows[i]["Expr1"].ToString();
					dataRow[13] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"].ToString());
					dataRow[14] = dataSet.Tables[0].Rows[i]["Expr2"];
					dataRow[15] = dataSet.Tables[0].Rows[i]["Terms"];
					double num = 0.0;
					dataRow[16] = Convert.ToDouble(decimal.Parse(Convert.ToDouble(Convert.ToDouble(dataSet.Tables[0].Rows[i]["Rate"]) - Convert.ToDouble(dataSet.Tables[0].Rows[i]["Rate"]) * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Discount"]) / 100.0).ToString()).ToString("N2"));
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				DataSet dataSet6 = new RateRegister();
				dataSet6.Tables[0].Merge(dataTable);
				dataSet6.AcceptChanges();
				cryRpt.Load(base.Server.MapPath("~/Module/MaterialManagement/Reports/RateRegister.rpt"));
				cryRpt.SetDataSource(dataSet6);
				string text3 = fun.CompAdd(CId);
				cryRpt.SetParameterValue("Address", (object)text3);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
			}
			else
			{
				((Control)(object)CrystalReportViewer1).Visible = false;
				string text4 = "1";
				base.Response.Redirect("RateRegister.aspx?MSG=" + text4);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
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

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		cryRpt.Close();
		((Component)(object)cryRpt).Dispose();
		GC.Collect();
	}
}

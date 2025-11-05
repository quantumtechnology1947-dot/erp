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

public class Module_Inventory_Transactions_Stock_Statement_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string Fdate = string.Empty;

	private string Tdate = string.Empty;

	private string CID = string.Empty;

	private int RadVal;

	private int FinYearId;

	private int FinAcc;

	private string Openingdate = string.Empty;

	private double rtuy;

	private double BalQty;

	private double TotGetRateAmt;

	private string p = string.Empty;

	private string r = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	private DataSet Stock = new DataSet();

	private string connStr = "";

	private SqlConnection con;

	private string Key = string.Empty;

	private double OverHeads;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_0fe7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fee: Expected O, but got Unknown
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		con.Open();
		DataTable dataTable = new DataTable();
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["Cid"]))
			{
				CID = base.Request.QueryString["Cid"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["p"]))
			{
				p = base.Request.QueryString["p"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["r"]))
			{
				r = base.Request.QueryString["r"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["FDate"]))
			{
				Fdate = base.Request.QueryString["FDate"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["TDate"]))
			{
				Tdate = base.Request.QueryString["TDate"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["OpeningDt"]))
			{
				Openingdate = fun.FromDateDMY(base.Request.QueryString["OpeningDt"].ToString());
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["RadVal"]))
			{
				RadVal = Convert.ToInt32(base.Request.QueryString["RadVal"].ToString());
			}
			OverHeads = Convert.ToDouble(base.Request.QueryString["OverHeads"].ToString());
			Key = base.Request.QueryString["Key"].ToString();
			string cmdText = fun.select("FinYearId", "tblFinancial_master", "CompId='" + CompId + "'Order By FinYearId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				FinAcc = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
			}
			string text = fun.FromDate(Convert.ToDateTime(fun.FromDate(Fdate)).AddDays(-1.0).ToShortDateString()
				.Replace("/", "-"));
			string[] array = text.Split('-');
			string fD = Convert.ToInt32(array[1]).ToString("D2") + "-" + Convert.ToInt32(array[2]).ToString("D2") + "-" + Convert.ToInt32(array[0]).ToString("D2");
			if (!base.IsPostBack)
			{
				string value = "";
				string value2 = "";
				switch (RadVal)
				{
				case 0:
					value = " max(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 1:
					value = " min(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 2:
					value = " avg(Rate-(Rate*(Discount/100))) As rate ";
					break;
				case 3:
					value = " Top 1 Rate-(Rate*(Discount/100)) As rate ";
					value2 = " Order by Id Desc";
					break;
				case 4:
					value = " Top 1 Rate-(Rate*(Discount/100)) As rate ";
					value2 = " Order by Id Desc";
					break;
				}
				SqlDataReader sqlDataReader = null;
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SubCategory", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
				dataTable.Columns.Add(new DataColumn("GQNQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ISSUEQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("OPENINGQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CLOSINGQTY", typeof(double)));
				dataTable.Columns.Add(new DataColumn("RateReg", typeof(double)));
				dataTable.Columns.Add(new DataColumn("ActAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
				SqlCommand sqlCommand = new SqlCommand("Get_Stock_Report", con);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add(new SqlParameter("@x1", SqlDbType.VarChar));
				sqlCommand.Parameters["@x1"].Value = value;
				sqlCommand.Parameters.Add(new SqlParameter("@y1", SqlDbType.VarChar));
				sqlCommand.Parameters["@y1"].Value = value2;
				sqlCommand.Parameters.Add(new SqlParameter("@OpeningDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@OpeningDate"].Value = fun.FromDate(Openingdate);
				sqlCommand.Parameters.Add(new SqlParameter("@FDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@FDate"].Value = fun.FromDate(Fdate);
				sqlCommand.Parameters.Add(new SqlParameter("@TDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@TDate"].Value = fun.FromDate(Tdate);
				sqlCommand.Parameters.Add(new SqlParameter("@str1", SqlDbType.VarChar));
				sqlCommand.Parameters["@str1"].Value = fun.FromDate(fD);
				sqlCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
				sqlCommand.Parameters["@x"].Value = CID;
				sqlCommand.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar));
				sqlCommand.Parameters["@p"].Value = p;
				sqlCommand.Parameters.Add(new SqlParameter("@r", SqlDbType.VarChar));
				sqlCommand.Parameters["@r"].Value = r;
				sqlCommand.CommandTimeout = 0;
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					double num = 0.0;
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = (int)sqlDataReader["Id"];
					dataRow[3] = sqlDataReader["ItemCode"].ToString();
					dataRow[4] = sqlDataReader["Description"].ToString();
					dataRow[5] = sqlDataReader["UOM"].ToString();
					dataRow[6] = CompId;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					string text2 = sqlDataReader["Id"].ToString();
					if (sqlDataReader["INQty"] != DBNull.Value)
					{
						num = Math.Round(Convert.ToDouble(sqlDataReader["INQty"]), 2);
						dataRow[7] = num;
					}
					else
					{
						dataRow[7] = num;
					}
					if (sqlDataReader["WIPQty"] != DBNull.Value)
					{
						num4 = Math.Round(Convert.ToDouble(sqlDataReader["WIPQty"]), 2);
						dataRow[8] = num4;
					}
					else
					{
						dataRow[8] = num4;
					}
					dataRow[13] = sqlDataReader["StockQty"].ToString();
					if (FinAcc == FinYearId)
					{
						if (Convert.ToDateTime(Openingdate) == Convert.ToDateTime(fun.FromDate(Fdate)))
						{
							num2 = Convert.ToDouble(sqlDataReader["OpeningBalQty"]);
						}
						else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(Openingdate) && Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
						{
							double num5 = 0.0;
							double num6 = 0.0;
							if (sqlDataReader["PrvINQty"] != DBNull.Value)
							{
								num6 = Math.Round(Convert.ToDouble(sqlDataReader["PrvINQty"]), 2);
							}
							if (sqlDataReader["PrevWIPQty"] != DBNull.Value)
							{
								num5 = Math.Round(Convert.ToDouble(sqlDataReader["PrevWIPQty"]), 2);
							}
							double num7 = 0.0;
							num7 = Convert.ToDouble(sqlDataReader["OpeningBalQty"]);
							num2 = Math.Round(num7 + num6 - num5, 5);
						}
						num3 = Math.Round(num2 + num - num4, 5);
					}
					else
					{
						string cmdText2 = fun.select("OpeningQty,OpeningDate", "tblDG_Item_Master_Clone", "ItemId='" + text2 + "' And CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
						SqlDataReader sqlDataReader2 = null;
						sqlDataReader2 = sqlCommand2.ExecuteReader();
						while (sqlDataReader2.Read())
						{
							if (Convert.ToDateTime(sqlDataReader2["OpeningDate"]) == Convert.ToDateTime(fun.FromDate(Fdate)))
							{
								num2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["OpeningQty"].ToString()).ToString("N3"));
							}
							else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(sqlDataReader2["OpeningDate"]) && Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
							{
								double num8 = 0.0;
								num8 = Convert.ToDouble(sqlDataReader2["OpeningQty"]);
								double num9 = 0.0;
								double num10 = 0.0;
								if (sqlDataReader["PrvINQty"] != DBNull.Value)
								{
									num10 = Math.Round(Convert.ToDouble(sqlDataReader["PrvINQty"]), 2);
								}
								if (sqlDataReader["PrevWIPQty"] != DBNull.Value)
								{
									num9 = Math.Round(Convert.ToDouble(sqlDataReader["PrevWIPQty"]), 2);
								}
								num2 = Math.Round(num8 + num10 - num9, 5);
							}
							num3 = Math.Round(num2 + num - num4, 5);
						}
					}
					if (num3 > 0.0)
					{
						double num11 = 0.0;
						if (sqlDataReader["rate"] != DBNull.Value)
						{
							double num12 = 0.0;
							num12 = Convert.ToDouble(sqlDataReader["rate"]);
							num11 = num12 + num12 * OverHeads / 100.0;
						}
						dataRow[9] = num2;
						dataRow[10] = num3;
						double num13 = 0.0;
						rtuy = 0.0;
						TotGetRateAmt = 0.0;
						if (RadVal == 0 || RadVal == 1 || RadVal == 2 || RadVal == 3)
						{
							dataRow[11] = num11;
							dataRow[12] = num11 * num3;
						}
						else
						{
							num13 = ActualAmt(CompId, FinYearId, text2, num3);
							double num14 = 0.0;
							num14 = ((!(num13 > 0.0)) ? 0.0 : (num13 / num3));
							dataRow[11] = num14;
							dataRow[12] = num13;
						}
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				DataSet dataSet2 = new Stock_Statement();
				dataSet2.Tables[0].Merge(dataTable);
				dataSet2.AcceptChanges();
				string text3 = base.Server.MapPath("~/Module/Inventory/Reports/Stock_Statement.rpt");
				cryRpt.Load(text3);
				cryRpt.SetDataSource(dataSet2);
				string text4 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text4);
				cryRpt.SetParameterValue("Fdate", (object)Fdate);
				cryRpt.SetParameterValue("Tdate", (object)Tdate);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = cryRpt;
				Session[Key] = cryRpt;
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
		finally
		{
			Stock.Clear();
			Stock.Dispose();
			dataTable.Clear();
			dataTable.Dispose();
			con.Close();
			con.Dispose();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		cryRpt = new ReportDocument();
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
	}

	public double ActualAmt(int CompId, int finid, string itemid, double clqty)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		BalQty = clqty;
		string cmdText = fun.select("(Rate-(Rate*(Discount/100))) As rate1,ItemId,CompId,PONo,FinYearId,POId,AmendmentNo,SPRId,PRId", "tblMM_Rate_Register", " CompId='" + CompId + "'  And FinYearId='" + finid + "' And ItemId='" + itemid + "' Order By Id Desc ");
		SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
		double num = 0.0;
		SqlDataReader sqlDataReader = null;
		sqlDataReader = sqlCommand.ExecuteReader();
		while (sqlDataReader.Read())
		{
			num = Convert.ToDouble(sqlDataReader["rate1"]);
			if (!(BalQty > 0.0))
			{
				continue;
			}
			string text = "";
			text = ((sqlDataReader["SPRId"] == DBNull.Value) ? fun.select("tblMM_PO_Details.Id,tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo", "tblMM_PO_Details,tblMM_PO_Master", " tblMM_PO_Master.PONo='" + sqlDataReader["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Details.MId=tblMM_PO_Master.Id AND tblMM_PO_Master.CompId='" + CompId + "' AND  tblMM_PO_Master.AmendmentNo='" + sqlDataReader["AmendmentNo"].ToString() + "' AND  tblMM_PO_Master.Id='" + sqlDataReader["POId"].ToString() + "'  AND tblMM_PO_Master.FinYearId='" + sqlDataReader["FinYearId"].ToString() + "' AND tblMM_PO_Details.PRId='" + sqlDataReader["PRId"].ToString() + "' ") : fun.select("tblMM_PO_Details.Id,tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo", "tblMM_PO_Details,tblMM_PO_Master", " tblMM_PO_Master.PONo='" + sqlDataReader["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PO_Details.MId=tblMM_PO_Master.Id AND tblMM_PO_Master.CompId='" + CompId + "' AND  tblMM_PO_Master.AmendmentNo='" + sqlDataReader["AmendmentNo"].ToString() + "' AND  tblMM_PO_Master.Id='" + sqlDataReader["POId"].ToString() + "'  AND tblMM_PO_Master.FinYearId='" + sqlDataReader["FinYearId"].ToString() + "' AND tblMM_PO_Details.SPRId='" + sqlDataReader["SPRId"].ToString() + "' "));
			SqlCommand sqlCommand2 = new SqlCommand(text, sqlConnection);
			SqlDataReader sqlDataReader2 = null;
			sqlDataReader2 = sqlCommand2.ExecuteReader();
			while (sqlDataReader2.Read())
			{
				rtuy = 0.0;
				string cmdText2 = fun.select("tblInv_Inward_Master.Id,tblInv_Inward_Details.Id As GId,tblInv_Inward_Details.POId ", "tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.PONo='" + sqlDataReader2["PONo"].ToString() + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Details.POId='" + sqlDataReader2["Id"].ToString() + "' And tblInv_Inward_Master.FinYearId='" + sqlDataReader2["FinYearId"].ToString() + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader3 = null;
				sqlDataReader3 = sqlCommand3.ExecuteReader();
				while (sqlDataReader3.Read())
				{
					string cmdText3 = fun.select("tblinv_MaterialReceived_Master.Id,tblinv_MaterialReceived_Details.ReceivedQty,tblinv_MaterialReceived_Details.Id As DId", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + sqlDataReader3["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + sqlDataReader3["POId"].ToString() + "' ");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader4 = null;
					sqlDataReader4 = sqlCommand4.ExecuteReader();
					while (sqlDataReader4.Read())
					{
						string cmdText4 = fun.select("tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.CompId='" + CompId + "' And tblQc_MaterialQuality_Master.Id= tblQc_MaterialQuality_Details.MId   And tblQc_MaterialQuality_Master.GRRId='" + sqlDataReader4["Id"].ToString() + "' And tblQc_MaterialQuality_Details.GRRId='" + sqlDataReader4["DId"].ToString() + "' ");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataReader sqlDataReader5 = null;
						sqlDataReader5 = sqlCommand5.ExecuteReader();
						while (sqlDataReader5.Read())
						{
							if (sqlDataReader5["AcceptedQty"] != DBNull.Value)
							{
								rtuy += Convert.ToDouble(decimal.Parse(sqlDataReader5["AcceptedQty"].ToString()).ToString("N3"));
							}
						}
					}
				}
			}
			if (BalQty >= rtuy)
			{
				BalQty -= rtuy;
				TotGetRateAmt += num * rtuy;
			}
			else
			{
				TotGetRateAmt += num * BalQty;
				BalQty = 0.0;
			}
		}
		if (finid > 0 && BalQty > 0.0)
		{
			ActualAmt(CompId, finid - 1, itemid, BalQty);
		}
		sqlConnection.Close();
		return TotGetRateAmt;
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Stock_Statement.aspx?ModId=9");
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

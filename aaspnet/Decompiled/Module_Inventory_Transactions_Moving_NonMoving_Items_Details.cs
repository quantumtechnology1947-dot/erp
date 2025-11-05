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

public class Module_Inventory_Transactions_Moving_NonMoving_Items_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource1;

	protected Panel Panel1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string Fdate = "";

	private string Tdate = "";

	private int CID;

	private int SCId;

	private int RadVal;

	private int FinYearId;

	private int FinAcc;

	private string Openingdate = "";

	private string RPTHeader = "";

	private string RadMovingItemVal = "";

	private ReportDocument cryRpt = new ReportDocument();

	private DataSet Moving_NonMoving = new DataSet();

	private string Key = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_17a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ae: Expected O, but got Unknown
		Key = base.Request.QueryString["Key"].ToString();
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			DataSet dataSet2 = new DataSet();
			try
			{
				sqlConnection.Open();
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CID = Convert.ToInt32(fun.Decrypt(base.Request.QueryString["Cid"].ToString()));
				RadMovingItemVal = base.Request.QueryString["RPTHeader"].ToString();
				if (RadMovingItemVal == "0")
				{
					RPTHeader = "Moving Items";
				}
				else
				{
					RPTHeader = "Non-Moving Items";
				}
				string text = "";
				Fdate = fun.Decrypt(base.Request.QueryString["FDate"].ToString());
				Tdate = fun.Decrypt(base.Request.QueryString["TDate"].ToString());
				Openingdate = fun.Decrypt(base.Request.QueryString["OpeningDt"].ToString());
				RadVal = Convert.ToInt32(fun.Decrypt(base.Request.QueryString["RadVal"].ToString()));
				string text2 = "";
				text2 = ((CID == 0) ? "" : (" AND CId='" + CID + "'"));
				string cmdText = fun.select("FinYearId", "tblFinancial_master", "CompId='" + CompId + "'Order By FinYearId Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					FinAcc = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
				}
				text = fun.select("Id,ItemCode,ManfDesc,OpeningBalQty,CId,UOMBasic", "tblDG_Item_Master", "FinYearId<='" + FinYearId + "'AND CompId='" + CompId + "'" + text2);
				SqlCommand selectCommand2 = new SqlCommand(text, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
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
				DataRow dataRow = dataTable.NewRow();
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					double num = 0.0;
					dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("Symbol as Category ", "tblDG_Category_Master", string.Concat("CId='", dataSet2.Tables[0].Rows[i]["CId"], "' AND CompId='", CompId, "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText3 = fun.select("Symbol As UOM ", "Unit_Master", string.Concat("Id='", dataSet2.Tables[0].Rows[i]["UOMBasic"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					dataRow[3] = dataSet2.Tables[0].Rows[i]["ItemCode"];
					dataRow[4] = dataSet2.Tables[0].Rows[i]["ManfDesc"];
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet3.Tables[0].Rows[0]["Category"];
					}
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet4.Tables[0].Rows[0]["UOM"];
					}
					dataRow[6] = CompId;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					string text3 = dataSet2.Tables[0].Rows[i]["Id"].ToString();
					num2 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num3 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num4 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num = Convert.ToDouble(decimal.Parse((num2 + num3 + num4 + num5 + num6).ToString()).ToString("N3"));
					dataRow[7] = num;
					double num7 = 0.0;
					double num8 = 0.0;
					num7 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					num8 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, Fdate, Tdate, text3).ToString()).ToString("N3"));
					dataRow[8] = num7 + num8;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					double num18 = 0.0;
					if (FinAcc == FinYearId)
					{
						string cmdText4 = fun.select("OpeningBalQty", "tblDG_Item_Master", "FinYearId<='" + FinYearId + "'AND Id='" + text3 + "' And CompId='" + CompId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (Convert.ToDateTime(Openingdate) == Convert.ToDateTime(fun.FromDate(Fdate)))
						{
							num9 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0][0].ToString()).ToString("N3"));
							num10 = num9 + num - (num7 + num8);
						}
						else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(Openingdate) || Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
						{
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								num18 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0][0].ToString()).ToString("N3"));
							}
							TimeSpan value = new TimeSpan(1, 0, 0, 0);
							string text4 = fun.FromDate(Convert.ToDateTime(Convert.ToDateTime(fun.FromDate(Fdate)).Date.Subtract(value)).ToShortDateString().Replace("/", "-"));
							string[] array = text4.Split('-');
							string tDate = Convert.ToInt32(array[0]).ToString("D2") + "-" + Convert.ToInt32(array[2]).ToString("D2") + "-" + Convert.ToInt32(array[1]).ToString("D2");
							num11 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num12 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num13 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num14 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num15 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num16 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num17 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, Openingdate, tDate, text3).ToString()).ToString("N3"));
							num9 = num18 + num11 + num12 + num13 + num16 + num17 - (num14 + num15);
							num10 = num9 + num - (num7 + num8);
						}
					}
					else
					{
						string cmdText5 = fun.select("OpeningQty,OpeningDate", "tblDG_Item_Master_Clone", "ItemId='" + text3 + "' And CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
						SqlCommand selectCommand6 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							if (Convert.ToDateTime(dataSet6.Tables[0].Rows[0]["OpeningDate"]) == Convert.ToDateTime(fun.FromDate(Fdate)))
							{
								num9 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0][0].ToString()).ToString("N3"));
								num10 = num9 + num - (num7 + num8);
							}
							else if (Convert.ToDateTime(fun.FromDate(Fdate)) >= Convert.ToDateTime(dataSet6.Tables[0].Rows[0]["OpeningDate"]) || Convert.ToDateTime(fun.FromDate(Fdate)) <= Convert.ToDateTime(fun.FromDate(Tdate)))
							{
								num18 = Convert.ToDouble(dataSet6.Tables[0].Rows[0][0]);
								TimeSpan value2 = new TimeSpan(1, 0, 0, 0);
								string text5 = fun.FromDate(Convert.ToDateTime(Convert.ToDateTime(fun.FromDate(Fdate)).Date.Subtract(value2)).ToShortDateString().Replace("/", "-"));
								string[] array2 = text5.Split('-');
								string tDate2 = Convert.ToInt32(array2[0]).ToString("D2") + "-" + Convert.ToInt32(array2[2]).ToString("D2") + "-" + Convert.ToInt32(array2[1]).ToString("D2");
								num11 = Convert.ToDouble(decimal.Parse(fun.GQN_SPRQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num12 = Convert.ToDouble(decimal.Parse(fun.GQN_PRQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num13 = Convert.ToDouble(decimal.Parse(fun.MRQN_QTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num14 = Convert.ToDouble(decimal.Parse(fun.MIN_IssuQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num15 = Convert.ToDouble(decimal.Parse(fun.WIS_IssuQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num16 = Convert.ToDouble(decimal.Parse(fun.GSN_PRQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num17 = Convert.ToDouble(decimal.Parse(fun.GSN_SPRQTY(CompId, dataSet6.Tables[0].Rows[0]["OpeningDate"].ToString(), tDate2, text3).ToString()).ToString("N3"));
								num9 = num18;
								num10 = num9 + num - (num7 + num8);
							}
						}
					}
					double num19 = 0.0;
					string field = "";
					string text6 = "";
					switch (RadVal)
					{
					case 0:
						field = " max(Rate-(Rate*(Discount/100))) As rate ";
						break;
					case 1:
						field = " min(Rate-(Rate*(Discount/100))) As rate ";
						break;
					case 2:
						field = " avg(Rate-(Rate*(Discount/100))) As rate ";
						break;
					case 3:
						field = " Rate-(Rate*(Discount/100)) As rate ";
						text6 = " Order by Id Desc ";
						break;
					}
					string cmdText6 = fun.select(field, "tblMM_Rate_Register", "CompId='" + CompId + "'And ItemId='" + text3 + "'" + text6);
					SqlCommand selectCommand7 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7, "tblMM_Rate_Register");
					if (dataSet7.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num19 = Convert.ToDouble(dataSet7.Tables[0].Rows[0][0]);
					}
					dataRow[11] = num19;
					dataRow[9] = num9;
					dataRow[10] = num10;
					switch (RadMovingItemVal)
					{
					case "0":
						if (num > 0.0 || num7 + num8 > 0.0)
						{
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
						break;
					case "1":
						if (num == 0.0 && num7 + num8 == 0.0)
						{
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
						break;
					}
				}
				Moving_NonMoving.Tables.Add(dataTable);
				Moving_NonMoving.AcceptChanges();
				DataSet dataSet8 = new Moving_NonMoving_Items();
				dataSet8.Tables[0].Merge(Moving_NonMoving.Tables[0]);
				dataSet8.AcceptChanges();
				string text7 = base.Server.MapPath("~/Module/Inventory/Reports/Moving_NonMoving_Items.rpt");
				cryRpt.Load(text7);
				cryRpt.SetDataSource(dataSet8);
				string text8 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text8);
				cryRpt.SetParameterValue("Fdate", (object)Fdate);
				cryRpt.SetParameterValue("Tdate", (object)Tdate);
				cryRpt.SetParameterValue("RPTHeader", (object)RPTHeader);
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
				dataTable.Dispose();
				dataSet.Dispose();
				dataSet2.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Moving_NonMoving_Items.aspx?ModId=9");
	}
}

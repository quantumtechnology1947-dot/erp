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

public class Module_Inventory_Reports_ABCAnalysis_Details : Page, IRequiresSessionState
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

	private double TotAmount;

	private double A;

	private double B;

	private double C;

	private string Key = string.Empty;

	private ReportDocument cryRpt = new ReportDocument();

	private DataSet Stock = new DataSet();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_1166: Unknown result type (might be due to invalid IL or missing references)
		//IL_116d: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			try
			{
				CompId = Convert.ToInt32(Session["compid"]);
				FinYearId = Convert.ToInt32(Session["finyear"]);
				CID = Convert.ToInt32(fun.Decrypt(base.Request.QueryString["Cid"].ToString()));
				Key = base.Request.QueryString["Key"].ToString();
				A = Convert.ToDouble(base.Request.QueryString["A"]);
				B = Convert.ToDouble(base.Request.QueryString["B"]);
				C = Convert.ToDouble(base.Request.QueryString["C"]);
				Fdate = fun.Decrypt(base.Request.QueryString["FDate"].ToString());
				Tdate = fun.Decrypt(base.Request.QueryString["TDate"].ToString());
				Openingdate = fun.Decrypt(base.Request.QueryString["OpeningDt"].ToString());
				RadVal = Convert.ToInt32(fun.Decrypt(base.Request.QueryString["RadVal"].ToString()));
				string text = "";
				text = ((CID == 0) ? "" : (" AND CId='" + CID + "'"));
				string cmdText = fun.select("FinYearId", "tblFinancial_master", "CompId='" + CompId + "'Order By FinYearId Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					FinAcc = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
				}
				string text2 = fun.FromDate(Convert.ToDateTime(fun.FromDate(Fdate)).AddDays(-1.0).ToShortDateString()
					.Replace("/", "-"));
				string[] array = text2.Split('-');
				string fD = Convert.ToInt32(array[1]).ToString("D2") + "-" + Convert.ToInt32(array[2]).ToString("D2") + "-" + Convert.ToInt32(array[0]).ToString("D2");
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
				dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("AP", typeof(double)));
				dataTable.Columns.Add(new DataColumn("CP", typeof(double)));
				SqlCommand sqlCommand = new SqlCommand("Get_Stock_Report", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add(new SqlParameter("@x1", SqlDbType.VarChar));
				sqlCommand.Parameters["@x1"].Value = value;
				sqlCommand.Parameters.Add(new SqlParameter("@y1", SqlDbType.VarChar));
				sqlCommand.Parameters["@y1"].Value = value2;
				sqlCommand.Parameters.Add(new SqlParameter("@OpeningDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@OpeningDate"].Value = Openingdate;
				sqlCommand.Parameters.Add(new SqlParameter("@FDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@FDate"].Value = fun.FromDate(Fdate);
				sqlCommand.Parameters.Add(new SqlParameter("@TDate", SqlDbType.VarChar));
				sqlCommand.Parameters["@TDate"].Value = fun.FromDate(Tdate);
				sqlCommand.Parameters.Add(new SqlParameter("@str1", SqlDbType.VarChar));
				sqlCommand.Parameters["@str1"].Value = fun.FromDate(fD);
				sqlCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
				sqlCommand.Parameters["@x"].Value = text;
				string empty = string.Empty;
				string empty2 = string.Empty;
				sqlCommand.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar));
				sqlCommand.Parameters["@p"].Value = empty;
				sqlCommand.Parameters.Add(new SqlParameter("@r", SqlDbType.VarChar));
				sqlCommand.Parameters["@r"].Value = empty2;
				SqlDataReader sqlDataReader = null;
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
					string text3 = sqlDataReader["Id"].ToString();
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
						string cmdText2 = fun.select("OpeningQty,OpeningDate", "tblDG_Item_Master_Clone", "ItemId='" + text3 + "' And CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
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
							num11 = Convert.ToDouble(sqlDataReader["rate"]);
						}
						dataRow[11] = num11;
						dataRow[9] = num2;
						dataRow[10] = num3;
						double num12 = 0.0;
						num12 = Convert.ToDouble(decimal.Parse((num4 * num11).ToString()).ToString("N2"));
						dataRow[12] = num12;
						TotAmount += num12;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num13 = 0.0;
					double num14 = 0.0;
					num14 = Convert.ToDouble(decimal.Parse(dataTable.Rows[i]["Amount"].ToString()).ToString("N2"));
					if (num14 > 0.0)
					{
						num13 = Math.Round(Convert.ToDouble(num14 * 100.0 / TotAmount), 2);
					}
					dataTable.Rows[i]["AP"] = num13;
					dataTable.AcceptChanges();
				}
				DataView dataView = new DataView(dataTable);
				dataView.Sort = "AP DESC";
				Stock.Tables.Add(dataView.ToTable());
				double num15 = 0.0;
				for (int j = 0; j < Stock.Tables[0].Rows.Count; j++)
				{
					num15 += Convert.ToDouble(decimal.Parse(Stock.Tables[0].Rows[j]["AP"].ToString()).ToString("N2"));
					Stock.Tables[0].Rows[j]["CP"] = num15;
					if (num15 <= A)
					{
						Stock.Tables[0].Rows[j]["Type"] = "A";
					}
					else if (num15 <= B + A)
					{
						Stock.Tables[0].Rows[j]["Type"] = "B";
					}
					else
					{
						Stock.Tables[0].Rows[j]["Type"] = "C";
					}
					Stock.AcceptChanges();
				}
				DataSet dataSet2 = new ABCAnalysis();
				dataSet2.Tables[0].Merge(Stock.Tables[0]);
				dataSet2.AcceptChanges();
				string text4 = base.Server.MapPath("~/Module/Inventory/Reports/ABCAnalysis.rpt");
				cryRpt.Load(text4);
				cryRpt.SetDataSource(dataSet2);
				string text5 = fun.CompAdd(CompId);
				cryRpt.SetParameterValue("CompAdd", (object)text5);
				cryRpt.SetParameterValue("Fdate", (object)Fdate);
				cryRpt.SetParameterValue("Tdate", (object)Tdate);
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
				Stock.Clear();
				Stock.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Abcanalysis.aspx?ModId=9");
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

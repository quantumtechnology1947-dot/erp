using System;
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

public class Module_MaterialManagement_Transactions_PR_Items : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private string wono = "";

	private int fyid;

	private string supid = "";

	protected Label lblwo;

	protected Label lbltype;

	protected TextBox txtSupplierId;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected Button btnSearch;

	protected GridView GridView2;

	protected Panel Panel1;

	protected TabPanel TabPanel1;

	protected GridView GridView3;

	protected Panel Panel2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected SqlDataSource SqlDataSource1;

	protected Button btnGenerate;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			wono = base.Request.QueryString["wono"].ToString();
			lblwo.Text = wono;
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				switch (Convert.ToInt32(base.Request.QueryString["c"]))
				{
				case 1:
					lbltype.Text = "Finish Items";
					break;
				case 2:
					lbltype.Text = "Components";
					break;
				case 3:
					lbltype.Text = "Processing Items";
					break;
				}
				fillGrid(supid);
			}
			Fill_PR_Temp_Grid();
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		string text = "";
		try
		{
			if (txtSupplierId.Text != "")
			{
				text = " AND SupplierId='" + fun.getCode(txtSupplierId.Text) + "'";
				fillGrid(text);
			}
			else
			{
				fillGrid(supid);
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid(string supid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurchase", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MINQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AccHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WISQty", typeof(string)));
			string text = "";
			text = ((!(supid != "")) ? "" : (" AND SupplierId='" + fun.getCode(txtSupplierId.Text) + "'"));
			switch (Convert.ToInt32(base.Request.QueryString["c"]))
			{
			case 1:
			{
				string cmdText18 = fun.select("*", "tblMP_Material_Master", "CompId='" + CompId + "'  AND WONo='" + wono + "' AND Type='0'" + text);
				SqlCommand selectCommand18 = new SqlCommand(cmdText18, sqlConnection);
				SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
				DataSet dataSet18 = new DataSet();
				sqlDataAdapter18.Fill(dataSet18);
				for (int m = 0; m < dataSet18.Tables[0].Rows.Count; m++)
				{
					DataRow dataRow = dataTable.NewRow();
					new DataSet();
					string cmdText19 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet18.Tables[0].Rows[m]["ItemId"].ToString() + "'");
					SqlCommand selectCommand19 = new SqlCommand(cmdText19, sqlConnection);
					SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
					DataSet dataSet19 = new DataSet();
					sqlDataAdapter19.Fill(dataSet19);
					if (dataSet19.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet19.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[1] = dataSet19.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					string cmdText20 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + dataSet18.Tables[0].Rows[m]["ItemId"].ToString() + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand20 = new SqlCommand(cmdText20, sqlConnection);
					SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
					DataSet dataSet20 = new DataSet();
					sqlDataAdapter20.Fill(dataSet20);
					double num9 = 0.0;
					if (dataSet20.Tables[0].Rows.Count > 0 && dataSet20.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						num9 = Convert.ToDouble(decimal.Parse(dataSet20.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
					}
					string cmdText21 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet19.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand21 = new SqlCommand(cmdText21, sqlConnection);
					SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
					DataSet dataSet21 = new DataSet();
					sqlDataAdapter21.Fill(dataSet21);
					if (dataSet21.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet21.Tables[0].Rows[0]["Symbol"].ToString();
					}
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					if (Convert.ToInt32(dataSet18.Tables[0].Rows[m]["Type"]) == 0)
					{
						num10 = fun.BOMRecurQty(wono, Convert.ToInt32(dataSet18.Tables[0].Rows[m]["PId"]), Convert.ToInt32(dataSet18.Tables[0].Rows[m]["CId"]), 1.0, CompId, fyid);
						string cmdText22 = fun.select("SUM(tblMM_PR_Details.Qty) As sum_Qty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.WONo='" + wono + "' AND  tblMM_PR_Details.Type='0' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.ItemId='" + dataSet18.Tables[0].Rows[m]["ItemId"].ToString() + "' AND tblMM_PR_Details.PId='" + Convert.ToInt32(dataSet18.Tables[0].Rows[m]["PId"]) + "' AND tblMM_PR_Master.Id = tblMM_PR_Details.MId AND tblMM_PR_Details.CId='" + Convert.ToInt32(dataSet18.Tables[0].Rows[m]["CId"]) + "' Group by tblMM_PR_Details.ItemId");
						SqlCommand selectCommand22 = new SqlCommand(cmdText22, sqlConnection);
						SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
						DataSet dataSet22 = new DataSet();
						sqlDataAdapter22.Fill(dataSet22);
						if (dataSet22.Tables[0].Rows.Count > 0)
						{
							num11 = Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[0]["sum_Qty"].ToString()).ToString("N3"));
							num12 = num10 - num11;
						}
						else
						{
							num12 = num10;
						}
					}
					string cmdText23 = fun.select("sum(IssueQty)As MinQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialIssue_Details.MINNo=tblInv_MaterialIssue_Master.MINNo And tblInv_MaterialRequisition_Details.MRSNo=tblInv_MaterialRequisition_Master.MRSNo and tblInv_MaterialRequisition_Details.ItemId='" + dataSet18.Tables[0].Rows[m]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialIssue_Master.MRSNo =tblInv_MaterialRequisition_Details.MRSNo And tblInv_MaterialRequisition_Details.WONo='" + wono + "' And tblInv_MaterialIssue_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand23 = new SqlCommand(cmdText23, sqlConnection);
					SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
					DataSet dataSet23 = new DataSet();
					sqlDataAdapter23.Fill(dataSet23);
					if (dataSet23.Tables[0].Rows.Count > 0 && dataSet23.Tables[0].Rows[0][0] != DBNull.Value)
					{
						dataRow[11] = Convert.ToDouble(dataSet23.Tables[0].Rows[0][0]);
					}
					else
					{
						dataRow[11] = 0;
					}
					string cmdText24 = fun.select("sum(IssuedQty)As WisQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.WISNo=tblInv_WIS_Details.WISNo AND tblInv_WIS_Details.ItemId='" + dataSet18.Tables[0].Rows[m]["ItemId"].ToString() + "' And tblInv_WIS_Master.WONo='" + wono + "' And tblInv_WIS_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand24 = new SqlCommand(cmdText24, sqlConnection);
					SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand24);
					DataSet dataSet24 = new DataSet();
					sqlDataAdapter24.Fill(dataSet24);
					if (dataSet24.Tables[0].Rows.Count > 0 && dataSet24.Tables[0].Rows[0]["WisQty"] != DBNull.Value)
					{
						dataRow[15] = Convert.ToDouble(dataSet24.Tables[0].Rows[0]["WisQty"]);
					}
					else
					{
						dataRow[15] = 0;
					}
					dataRow[3] = num10;
					dataRow[4] = fun.getSupplierName(dataSet18.Tables[0].Rows[m]["SupplierId"].ToString(), CompId);
					dataRow[5] = fun.FromDateDMY(dataSet18.Tables[0].Rows[m]["CompDate"].ToString());
					dataRow[6] = dataSet18.Tables[0].Rows[m]["ItemId"].ToString();
					dataRow[7] = dataSet18.Tables[0].Rows[m]["Type"].ToString();
					dataRow[8] = num11;
					dataRow[9] = dataSet18.Tables[0].Rows[m]["PId"];
					dataRow[10] = dataSet18.Tables[0].Rows[m]["CId"];
					dataRow[12] = Convert.ToDouble(decimal.Parse((num10 - (num11 + Convert.ToDouble(dataRow[11]) + Convert.ToDouble(dataRow[15]))).ToString()).ToString("N3"));
					dataRow[13] = num9;
					string cmdText25 = fun.select("ItemId", "tblMM_PR_Temp", string.Concat("CompId='", CompId, "' AND WONo='", wono, "' AND ItemId='", dataSet18.Tables[0].Rows[m]["ItemId"].ToString(), "' AND PId='", dataRow[9], "' AND CId='", dataRow[10], "'"));
					SqlCommand selectCommand25 = new SqlCommand(cmdText25, sqlConnection);
					SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand25);
					DataSet dataSet25 = new DataSet();
					sqlDataAdapter25.Fill(dataSet25);
					if (num12 > 0.0 && dataSet25.Tables[0].Rows.Count == 0 && Convert.ToDouble(dataRow[12]) > 0.0)
					{
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				GridView2.DataSource = dataTable;
				GridView2.DataBind();
				break;
			}
			case 2:
			{
				string cmdText9 = fun.select("*", "tblMP_Material_Master", "CompId='" + CompId + "'  AND WONo='" + wono + "' AND Type='1'");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				for (int k = 0; k < dataSet9.Tables[0].Rows.Count; k++)
				{
					new DataSet();
					string cmdText10 = fun.select("*", "tblMP_Material_RawMaterial", "PLNo='" + dataSet9.Tables[0].Rows[k]["PLNo"].ToString() + "'" + text);
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					for (int l = 0; l < dataSet10.Tables[0].Rows.Count; l++)
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText11 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet10.Tables[0].Rows[l]["ItemId"].ToString() + "'");
						SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
						SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
						DataSet dataSet11 = new DataSet();
						sqlDataAdapter11.Fill(dataSet11);
						if (dataSet11.Tables[0].Rows.Count > 0)
						{
							dataRow[0] = dataSet11.Tables[0].Rows[0]["ItemCode"].ToString();
							dataRow[1] = dataSet11.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText12 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet11.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
							SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
							DataSet dataSet12 = new DataSet();
							sqlDataAdapter12.Fill(dataSet12);
							if (dataSet12.Tables[0].Rows.Count > 0)
							{
								dataRow[2] = dataSet12.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
						string cmdText13 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + dataSet10.Tables[0].Rows[l]["ItemId"].ToString() + "' And CompId='" + CompId + "' ");
						SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
						SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
						DataSet dataSet13 = new DataSet();
						sqlDataAdapter13.Fill(dataSet13);
						double num5 = 0.0;
						if (dataSet13.Tables[0].Rows.Count > 0 && dataSet13.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
						{
							num5 = Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
						}
						double num6 = 0.0;
						double num7 = 0.0;
						double num8 = 0.0;
						if (Convert.ToInt32(dataSet9.Tables[0].Rows[k]["Type"]) == 1)
						{
							num6 += fun.BOMRecurQty(wono, Convert.ToInt32(dataSet10.Tables[0].Rows[l]["PId"]), Convert.ToInt32(dataSet10.Tables[0].Rows[l]["CId"]), 1.0, CompId, fyid);
							string cmdText14 = fun.select("SUM(tblMM_PR_Details.Qty) As sum_Qty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.WONo='" + wono + "' AND  tblMM_PR_Details.Type='1' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.ItemId='" + dataSet10.Tables[0].Rows[l]["ItemId"].ToString() + "' AND tblMM_PR_Details.PId='" + Convert.ToInt32(dataSet10.Tables[0].Rows[l]["PId"]) + "' AND tblMM_PR_Master.Id = tblMM_PR_Details.MId AND tblMM_PR_Details.CId='" + Convert.ToInt32(dataSet10.Tables[0].Rows[l]["CId"]) + "' Group by tblMM_PR_Details.ItemId");
							SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
							SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
							DataSet dataSet14 = new DataSet();
							sqlDataAdapter14.Fill(dataSet14);
							if (dataSet14.Tables[0].Rows.Count > 0)
							{
								num7 = Convert.ToDouble(decimal.Parse(dataSet14.Tables[0].Rows[0]["sum_Qty"].ToString()).ToString("N3"));
								num8 = num6 - num7;
							}
							else
							{
								num8 = num6;
							}
						}
						string cmdText15 = fun.select("sum(IssueQty)As MinQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialIssue_Details.MINNo=tblInv_MaterialIssue_Master.MINNo And tblInv_MaterialRequisition_Details.MRSNo=tblInv_MaterialRequisition_Master.MRSNo and tblInv_MaterialRequisition_Details.ItemId='" + dataSet10.Tables[0].Rows[l]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialIssue_Master.MRSNo =tblInv_MaterialRequisition_Details.MRSNo And tblInv_MaterialRequisition_Details.WONo='" + wono + "' And tblInv_MaterialIssue_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand15 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
						DataSet dataSet15 = new DataSet();
						sqlDataAdapter15.Fill(dataSet15);
						if (dataSet15.Tables[0].Rows.Count > 0 && dataSet15.Tables[0].Rows[0][0] != DBNull.Value)
						{
							dataRow[11] = Convert.ToDouble(dataSet15.Tables[0].Rows[0][0]);
						}
						else
						{
							dataRow[11] = 0;
						}
						string cmdText16 = fun.select("sum(IssuedQty)As WisQty", "tblInv_WIS_Master,tblInv_WIS_Details", "tblInv_WIS_Master.WISNo=tblInv_WIS_Details.WISNo AND tblInv_WIS_Details.ItemId='" + dataSet10.Tables[0].Rows[l]["ItemId"].ToString() + "' And tblInv_WIS_Master.WONo='" + wono + "' And tblInv_WIS_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand16 = new SqlCommand(cmdText16, sqlConnection);
						SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
						DataSet dataSet16 = new DataSet();
						sqlDataAdapter16.Fill(dataSet16);
						if (dataSet16.Tables[0].Rows.Count > 0 && dataSet16.Tables[0].Rows[0]["WisQty"] != DBNull.Value)
						{
							dataRow[15] = Convert.ToDouble(decimal.Parse(dataSet16.Tables[0].Rows[0]["WisQty"].ToString()).ToString("N3"));
						}
						else
						{
							dataRow[15] = 0;
						}
						dataRow[3] = num6;
						dataRow[4] = fun.getSupplierName(dataSet10.Tables[0].Rows[l]["SupplierId"].ToString(), CompId);
						dataRow[5] = fun.FromDateDMY(dataSet10.Tables[0].Rows[l]["CompDate"].ToString());
						dataRow[6] = dataSet10.Tables[0].Rows[l]["ItemId"].ToString();
						dataRow[7] = dataSet9.Tables[0].Rows[0]["Type"].ToString();
						dataRow[8] = num7;
						dataRow[9] = dataSet10.Tables[0].Rows[l]["PId"];
						dataRow[10] = dataSet10.Tables[0].Rows[l]["CId"];
						dataRow[12] = num6 - (num7 + Convert.ToDouble(dataRow[11]) + Convert.ToDouble(dataRow[15]));
						dataRow[13] = num5;
						string cmdText17 = fun.select("ItemId", "tblMM_PR_Temp", string.Concat("CompId='", CompId, "' AND WONo='", wono, "' AND ItemId='", dataSet10.Tables[0].Rows[l]["ItemId"].ToString(), "' AND PId='", dataRow[9], "' AND CId='", dataRow[10], "'"));
						SqlCommand selectCommand17 = new SqlCommand(cmdText17, sqlConnection);
						SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
						DataSet dataSet17 = new DataSet();
						sqlDataAdapter17.Fill(dataSet17);
						if (num8 > 0.0 && dataSet17.Tables[0].Rows.Count == 0 && Convert.ToDouble(dataRow[12]) > 0.0)
						{
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
				GridView2.DataSource = dataTable;
				GridView2.DataBind();
				break;
			}
			case 3:
			{
				string cmdText = fun.select("*", "tblMP_Material_Master", "CompId='" + CompId + "'  AND WONo='" + wono + "' AND (Type='1' OR Type='3') ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					new DataSet();
					string cmdText2 = fun.select("*", "tblMP_Material_Process", "PLNo='" + dataSet.Tables[0].Rows[i]["PLNo"].ToString() + "'" + text);
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText3 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[0] = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
							dataRow[1] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet4 = new DataSet();
							sqlDataAdapter4.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								dataRow[2] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							}
						}
						string cmdText5 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "' And CompId='" + CompId + "' ");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						double num = 0.0;
						if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
						{
							num = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
						}
						double num2 = 0.0;
						double num3 = 0.0;
						double num4 = 0.0;
						num2 += fun.BOMRecurQty(wono, Convert.ToInt32(dataSet2.Tables[0].Rows[j]["PId"]), Convert.ToInt32(dataSet2.Tables[0].Rows[j]["CId"]), 1.0, CompId, fyid);
						string cmdText6 = fun.select("SUM(tblMM_PR_Details.Qty) As sum_Qty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.WONo='" + wono + "' AND  tblMM_PR_Details.Type='1' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.ItemId='" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "' AND tblMM_PR_Details.PId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[j]["PId"]) + "' AND tblMM_PR_Master.Id = tblMM_PR_Details.MId AND tblMM_PR_Details.CId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[j]["CId"]) + "' Group by tblMM_PR_Details.ItemId");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							num4 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["sum_Qty"].ToString()).ToString("N3"));
							num3 = num2 - num4;
						}
						else
						{
							num3 = num2;
						}
						string cmdText7 = fun.select("sum(IssueQty)As MinQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialIssue_Details.MINNo=tblInv_MaterialIssue_Master.MINNo And tblInv_MaterialRequisition_Details.MRSNo=tblInv_MaterialRequisition_Master.MRSNo and tblInv_MaterialRequisition_Details.ItemId='" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialIssue_Master.MRSNo =tblInv_MaterialRequisition_Details.MRSNo And tblInv_MaterialRequisition_Details.WONo='" + wono + "' And tblInv_MaterialIssue_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows[0][0] != DBNull.Value)
						{
							dataRow[11] = Convert.ToDouble(dataSet7.Tables[0].Rows[0][0]);
						}
						else
						{
							dataRow[11] = 0;
						}
						dataRow[3] = num2;
						dataRow[4] = fun.getSupplierName(dataSet2.Tables[0].Rows[j]["SupplierId"].ToString(), CompId);
						dataRow[5] = fun.FromDateDMY(dataSet2.Tables[0].Rows[j]["CompDate"].ToString());
						dataRow[6] = dataSet2.Tables[0].Rows[j]["ItemId"].ToString();
						dataRow[7] = dataSet.Tables[0].Rows[i]["Type"].ToString();
						dataRow[8] = num4;
						dataRow[9] = dataSet2.Tables[0].Rows[j]["PId"];
						dataRow[10] = dataSet2.Tables[0].Rows[j]["CId"];
						dataRow[12] = num2 - (num4 + Convert.ToDouble(dataRow[11]));
						dataRow[13] = num;
						string cmdText8 = fun.select("ItemId", "tblMM_PR_Temp", string.Concat("CompId='", CompId, "' AND WONo='", wono, "' AND ItemId='", dataSet2.Tables[0].Rows[j]["ItemId"].ToString(), "' AND PId='", dataRow[9], "' AND CId='", dataRow[10], "'"));
						SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
						DataSet dataSet8 = new DataSet();
						sqlDataAdapter8.Fill(dataSet8);
						if (num3 > 0.0 && dataSet8.Tables[0].Rows.Count == 0 && Convert.ToDouble(dataRow[12]) > 0.0)
						{
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
				GridView2.DataSource = dataTable;
				GridView2.DataBind();
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34");
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillGrid(supid);
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			con.Open();
			if (e.CommandName == "AddMe")
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblitemid")).Text);
				double num2 = 0.0;
				if (((TextBox)gridViewRow.FindControl("ReqQty")).Text != "")
				{
					num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("ReqQty")).Text).ToString("N3"));
				}
				string code = fun.getCode(((TextBox)gridViewRow.FindControl("Supplier")).Text);
				double num3 = 0.0;
				if (((TextBox)gridViewRow.FindControl("Rate")).Text != "")
				{
					num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("Rate")).Text).ToString("N2"));
				}
				int num4 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("AccHead")).SelectedValue);
				string text = fun.FromDate(((TextBox)gridViewRow.FindControl("DelDate")).Text);
				string text2 = ((TextBox)gridViewRow.FindControl("Rmk")).Text;
				int num5 = Convert.ToInt32(((Label)gridViewRow.FindControl("lbltype")).Text);
				double num6 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblReqQty")).Text).ToString("N3"));
				double num7 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("ReqQty")).Text).ToString("N3"));
				int num8 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblpid")).Text);
				int num9 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblcid")).Text);
				string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + num + "' And CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				double num10 = 0.0;
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num10 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
				if (num3 > 0.0 && ((TextBox)gridViewRow.FindControl("DelDate")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("DelDate")).Text))
				{
					if (num10 > 0.0)
					{
						double num11 = 0.0;
						num11 = num10 - num3;
						if (num11 >= 0.0)
						{
							if (text != "" && fun.chkSupplierCode(code) == 1 && num6 >= num7 && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num2.ToString()))
							{
								string cmdText2 = fun.insert("tblMM_PR_Temp", "SessionId,CompId,WONo,PId,CId,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Remarks,Type", "'" + sId + "','" + CompId + "','" + wono + "','" + num8 + "','" + num9 + "','" + num + "','" + num2 + "','" + code + "','" + num3 + "','" + num4 + "','" + text + "','" + text2 + "','" + num5 + "'");
								SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
								sqlCommand.ExecuteNonQuery();
								con.Close();
								Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
							}
							else
							{
								string empty = string.Empty;
								empty = "Entered required qty exceed the limit!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							string cmdText3 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + num + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='0'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								if (text != "" && fun.chkSupplierCode(code) == 1 && num6 >= num7 && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num2.ToString()))
								{
									string cmdText4 = fun.insert("tblMM_PR_Temp", "SessionId,CompId,WONo,PId,CId,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Remarks,Type", "'" + sId + "','" + CompId + "','" + wono + "','" + num8 + "','" + num9 + "','" + num + "','" + num2 + "','" + code + "','" + num3 + "','" + num4 + "','" + text + "','" + text2 + "','" + num5 + "'");
									SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
									sqlCommand2.ExecuteNonQuery();
									con.Close();
									Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
								}
								else
								{
									string empty2 = string.Empty;
									empty2 = "Entered required qty exceed the limit!";
									base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
								}
							}
							else
							{
								string empty3 = string.Empty;
								empty3 = "Entered rate is not acceptable!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
							}
						}
					}
					else if (text != "" && fun.chkSupplierCode(code) == 1 && num6 >= num7 && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num2.ToString()))
					{
						string cmdText5 = fun.insert("tblMM_PR_Temp", "SessionId,CompId,WONo,PId,CId,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Remarks,Type", "'" + sId + "','" + CompId + "','" + wono + "','" + num8 + "','" + num9 + "','" + num + "','" + num2 + "','" + code + "','" + num3 + "','" + num4 + "','" + text + "','" + text2 + "','" + num5 + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
						sqlCommand3.ExecuteNonQuery();
						con.Close();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty4 = string.Empty;
						empty4 = "Entered required qty exceed the limit!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty5 = string.Empty;
					empty5 = "Entered rate is not acceptable!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "rate")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
				int num12 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblitemid")).Text);
				base.Response.Redirect("~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + num12 + "&CompId=" + CompId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnGenerate_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("PRNo", "tblMM_PR_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' order by PRNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblMM_PR_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblMM_PR_Temp", "CompId='" + CompId + "' AND WONo='" + wono + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string cmdText3 = fun.insert("tblMM_PR_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,PRNo", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + fyid + "','" + wono + "','" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText4 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' AND PRNo='" + text + "' Order By Id Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				int num = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"]);
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string cmdText5 = fun.insert("tblMM_PR_Details", "MId,PRNo,PId,CId,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Remarks,Type", string.Concat("  '", num, "','", text, "','", dataSet2.Tables[0].Rows[i]["PId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["CId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["ItemId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Qty"].ToString(), "','", dataSet2.Tables[0].Rows[i]["SupplierId"].ToString(), "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2")), "','", dataSet2.Tables[0].Rows[i]["AHId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["DelDate"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Remarks"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Type"], "'"));
					SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
				}
			}
			string cmdText6 = fun.delete("tblMM_PR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
			sqlCommand3.ExecuteNonQuery();
			base.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34");
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	public void Fill_PR_Temp_Grid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurchase", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			string cmdText = fun.select("*", "tblMM_PR_Temp", "CompId='" + CompId + "' AND WONo='" + wono + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[3] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					dataRow[4] = decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3");
					dataRow[5] = fun.getSupplierName(dataSet.Tables[0].Rows[i]["SupplierId"].ToString(), CompId);
					dataRow[6] = decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2");
					string cmdText4 = fun.select("Symbol as AccHead", "AccHead", "Id='" + dataSet.Tables[0].Rows[i]["AHId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["DelDate"].ToString());
					dataRow[7] = dataSet4.Tables[0].Rows[0]["AccHead"].ToString();
					dataRow[9] = dataSet.Tables[0].Rows[0]["Remarks"].ToString();
					dataTable.Rows.Add(dataRow);
				}
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "AddToMaster")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblitid")).Text;
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.delete("tblMM_PR_Temp", "SessionId='" + sId + "' AND CompId='" + CompId + "' AND WONo='" + wono + "' AND ItemId='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Fill_PR_Temp_Grid();
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
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

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		Fill_PR_Temp_Grid();
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}
}

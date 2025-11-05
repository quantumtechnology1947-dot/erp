using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_BillBooking_Item_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private int GQNId;

	private int GSNId;

	private string SupplierNo = "";

	private double FGT;

	private int PId;

	private int PoId;

	private double GQNAmt;

	private double GSNAmt;

	private int FyId;

	private int ItemId;

	private double bAmt;

	private double TAmt;

	private double vatVal;

	private double CstVal;

	private double vatVal1;

	private double CstVal1;

	private int PfId;

	private int ExStId;

	private int VatCstId;

	private int frieghtId;

	private double GQNQty;

	private double GSNQty;

	private double Rate;

	private double Disc;

	private double Qty;

	private string ItemCode = "";

	private string PurchDesc = "";

	private string UomPurch = "";

	private string Pf = "";

	private string Exst = "";

	private string vat = "";

	private int Isvat;

	private int Iscst;

	private double PfVal;

	private double ExstVal;

	private double basic;

	private double Educess;

	private double shecess;

	private string frieght = "";

	private int ST;

	private int ACHead;

	protected Label lblGNo;

	protected Label lblGqnGsnNo;

	protected Label lblItemcode;

	protected Label lblUnit;

	protected Label lblDiscription;

	protected Label Label2;

	protected TextBox txtTCEntryNo;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected Label Label9;

	protected Label Label10;

	protected Label Label11;

	protected Label lblRate;

	protected Label lblRateAmt;

	protected CheckBox CkRate;

	protected TextBox txtRate;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected RegularExpressionValidator RegularExpressionValidator14;

	protected Label lblDisc;

	protected Label lblDiscAmt;

	protected CheckBox CkDisc;

	protected TextBox txtDisc;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected RegularExpressionValidator RegularExpressionValidator15;

	protected Label lblGQty;

	protected Label lblGqnGsnQty;

	protected Label lblGAmt;

	protected Label lblGqnGsnAmt;

	protected CheckBox CKDebit;

	protected TextBox txtDebit;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected RegularExpressionValidator RegularExpressionValidator16;

	protected DropDownList DrpType;

	protected TextBox txtDebitAmt;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected RegularExpressionValidator RegularExpressionValidator13;

	protected Label Label1;

	protected Label lblPF;

	protected CheckBox CkPf;

	protected DropDownList DDLPF;

	protected SqlDataSource SqlDataSource1;

	protected TextBox txtPF;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected RegularExpressionValidator RegularExpressionValidator5;

	protected Label Label12;

	protected CheckBox CkBCD;

	protected TextBox txtBCD;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected RegularExpressionValidator RegularExpressionValidator17;

	protected DropDownList drpBCD;

	protected TextBox txtCalBCD;

	protected Label Label13;

	protected TextBox txtValCVD;

	protected Label Label3;

	protected Label lblExServiceTax;

	protected CheckBox CkExcise;

	protected DropDownList DDLExcies;

	protected SqlDataSource SqlDataSource2;

	protected Label lblExciseServiceTax;

	protected Label Label4;

	protected Label lblBasicExcise;

	protected TextBox txtBasicExcise;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtBasicExciseAmt;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected Label Label5;

	protected Label lblEDUCess;

	protected TextBox txtEDUCess;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected TextBox txtEDUCessAmt;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected RegularExpressionValidator RegularExpressionValidator8;

	protected Label Label6;

	protected Label lblSHECess;

	protected TextBox txtSHECess;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected TextBox txtSHECessAmt;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected Label Label14;

	protected TextBox txtValEdCessCD;

	protected Label Label15;

	protected CheckBox CkEdCessCD;

	protected TextBox txtEdCessCD;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected RegularExpressionValidator RegularExpressionValidator18;

	protected DropDownList drpEdCessCD;

	protected TextBox txtEdCessOnCD;

	protected Label Label16;

	protected CheckBox CkSHEdCess;

	protected TextBox txtSHEdCess;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected RegularExpressionValidator RegularExpressionValidator19;

	protected DropDownList drpSHEdCess;

	protected TextBox txtSHEdCessAmt;

	protected Label Label17;

	protected TextBox txtTotDuty;

	protected Label Label18;

	protected TextBox txtEDSHED;

	protected Label Label7;

	protected Label lblFreight;

	protected Label txtFreight;

	protected Label Label19;

	protected TextBox txtInsurance;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected RegularExpressionValidator RegularExpressionValidator20;

	protected Label Label20;

	protected TextBox txtValDuty;

	protected Label lblVatCst;

	protected Label lblVat;

	protected CheckBox CkVat;

	protected DropDownList DDLVat;

	protected SqlDataSource SqlDataSource3;

	protected TextBox txtVatCstAmt;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected RegularExpressionValidator RegularExpressionValidator12;

	protected Button Button1;

	protected Button btnAdd;

	protected Button BtnCancel;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			SupplierNo = base.Request.QueryString["SUPId"].ToString();
			GQNId = Convert.ToInt32(base.Request.QueryString["GQNId"].ToString());
			GSNId = Convert.ToInt32(base.Request.QueryString["GSNId"].ToString());
			FGT = Convert.ToDouble(base.Request.QueryString["FGT"].ToString());
			GQNAmt = Convert.ToDouble(base.Request.QueryString["GQNAmt"].ToString());
			GSNAmt = Convert.ToDouble(base.Request.QueryString["GSNAmt"]);
			GQNQty = Convert.ToDouble(base.Request.QueryString["GQNQty"].ToString());
			GSNQty = Convert.ToDouble(base.Request.QueryString["GSNQty"]);
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			PoId = Convert.ToInt32(base.Request.QueryString["POId"]);
			ST = Convert.ToInt32(base.Request.QueryString["ST"]);
			if (GQNQty == 0.0)
			{
				Qty = GSNQty;
			}
			else
			{
				Qty = GQNQty;
			}
			string cmdText = fun.select("tblMM_PO_Details.Id,tblMM_PO_Master.Freight,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Master.PRSPRFlag", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + PoId + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId  AND tblMM_PO_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
			{
				string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + dataSet.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						ItemCode = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
						PurchDesc = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							UomPurch = dataSet4.Tables[0].Rows[0][0].ToString();
						}
					}
				}
				ItemId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
				ACHead = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["AHId"]);
			}
			else if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
			{
				string cmdText5 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[0]["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					string cmdText6 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet5.Tables[0].Rows[0]["ItemId"].ToString() + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						ItemCode = dataSet6.Tables[0].Rows[0]["ItemCode"].ToString();
						PurchDesc = dataSet6.Tables[0].Rows[0]["ManfDesc"].ToString();
						string cmdText7 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet6.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0)
						{
							UomPurch = dataSet7.Tables[0].Rows[0][0].ToString();
						}
					}
				}
				ItemId = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["ItemId"]);
				ACHead = Convert.ToInt32(dataSet5.Tables[0].Rows[0]["AHId"]);
			}
			string cmdText8 = fun.select("Id,Terms,Value", "tblPacking_Master", "tblPacking_Master.Id='" + dataSet.Tables[0].Rows[0]["PF"].ToString() + "'");
			SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
			DataSet dataSet8 = new DataSet();
			sqlDataAdapter8.Fill(dataSet8);
			if (dataSet8.Tables[0].Rows.Count > 0)
			{
				Pf = dataSet8.Tables[0].Rows[0][1].ToString();
				if (!base.IsPostBack)
				{
					DDLPF.SelectedValue = dataSet8.Tables[0].Rows[0][0].ToString();
				}
				PfVal = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[0][2].ToString()).ToString("N2"));
				PfId = Convert.ToInt32(dataSet8.Tables[0].Rows[0][0]);
			}
			string cmdText9 = fun.select("Terms,Value,AccessableValue,EDUCess,SHECess,Id", "tblExciseser_Master", "tblExciseser_Master.Id='" + dataSet.Tables[0].Rows[0]["ExST"].ToString() + "'");
			SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
			SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
			DataSet dataSet9 = new DataSet();
			sqlDataAdapter9.Fill(dataSet9);
			if (dataSet9.Tables[0].Rows.Count > 0)
			{
				Exst = dataSet9.Tables[0].Rows[0][0].ToString();
				if (!base.IsPostBack)
				{
					DDLExcies.SelectedValue = dataSet9.Tables[0].Rows[0][5].ToString();
				}
				ExstVal = Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[0][1].ToString()).ToString("N2"));
				basic = Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[0][2].ToString()).ToString("N2"));
				shecess = Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[0][4].ToString()).ToString("N2"));
				Educess = Convert.ToDouble(decimal.Parse(dataSet9.Tables[0].Rows[0][3].ToString()).ToString("N2"));
				ExStId = Convert.ToInt32(dataSet9.Tables[0].Rows[0][5]);
				if (ExStId == 2 || ExStId == 3)
				{
					txtBasicExcise.Enabled = true;
					txtBasicExciseAmt.Enabled = true;
					txtEDUCess.Enabled = true;
					txtEDUCessAmt.Enabled = true;
					txtSHECess.Enabled = true;
					txtSHECessAmt.Enabled = true;
				}
			}
			string cmdText10 = fun.select("Id,Terms,Value,IsVAT,IsCST", "tblVAT_Master", "tblVAT_Master.Id='" + dataSet.Tables[0].Rows[0]["VAT"].ToString() + "'");
			SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
			SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
			DataSet dataSet10 = new DataSet();
			sqlDataAdapter10.Fill(dataSet10);
			if (dataSet10.Tables[0].Rows.Count > 0)
			{
				vat = dataSet10.Tables[0].Rows[0][1].ToString();
				if (!base.IsPostBack)
				{
					DDLVat.SelectedValue = dataSet10.Tables[0].Rows[0][0].ToString();
				}
				Isvat = Convert.ToInt32(dataSet10.Tables[0].Rows[0][3]);
				Iscst = Convert.ToInt32(dataSet10.Tables[0].Rows[0][4]);
				vatVal = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0][2].ToString()).ToString("N2"));
				VatCstId = Convert.ToInt32(dataSet10.Tables[0].Rows[0][0]);
			}
			string cmdText11 = fun.select("Id,Terms", "tblFreight_Master", "tblFreight_Master.Id='" + dataSet.Tables[0].Rows[0]["Freight"].ToString() + "'");
			SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
			SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
			DataSet dataSet11 = new DataSet();
			sqlDataAdapter11.Fill(dataSet11);
			if (dataSet11.Tables[0].Rows.Count > 0)
			{
				frieght = dataSet11.Tables[0].Rows[0][1].ToString();
				frieghtId = Convert.ToInt32(dataSet11.Tables[0].Rows[0][0]);
			}
			double num = 0.0;
			string cmdText12 = fun.select("sum(GQNAmt+GSNAmt+PFAmt+ExStBasic+ExStEducess+ExStShecess) As Sum_GQN_Excise", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
			SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
			DataSet dataSet12 = new DataSet();
			sqlDataAdapter12.Fill(dataSet12, "tblACC_BillBooking_Details_Temp");
			if (dataSet12.Tables[0].Rows.Count > 0 && dataSet12.Tables[0].Rows[0]["Sum_GQN_Excise"] != DBNull.Value)
			{
				for (int i = 0; i < dataSet12.Tables[0].Rows.Count; i++)
				{
					num += Convert.ToDouble(dataSet12.Tables[0].Rows[0][0].ToString());
				}
			}
			if (GQNId != 0)
			{
				CkVat.Enabled = true;
				string cmdText13 = fun.select("tblQc_MaterialQuality_Master.GQNNo", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + GQNId + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter13.Fill(dataSet13);
				lblGNo.Text = "GQN No";
				if (dataSet13.Tables[0].Rows.Count > 0)
				{
					lblGqnGsnNo.Text = dataSet13.Tables[0].Rows[0]["GQNNo"].ToString();
				}
				lblGQty.Text = "GQN Qty";
				lblGAmt.Text = "GQN Amt";
				lblGqnGsnAmt.Text = GQNAmt.ToString();
				lblGqnGsnQty.Text = GQNQty.ToString();
				txtDebitAmt.Text = GQNAmt.ToString();
				double num2 = 0.0;
				num2 = Convert.ToDouble(txtDebitAmt.Text);
				double num3 = 0.0;
				num3 = Convert.ToDouble(decimal.Parse((num2 * PfVal / 100.0).ToString()).ToString("N2"));
				double num4 = 0.0;
				num4 = Convert.ToDouble(decimal.Parse(((num2 + num3) * ExstVal / 100.0).ToString()).ToString("N2"));
				lblExciseServiceTax.Text = num4.ToString();
				double num5 = 0.0;
				num5 = Convert.ToDouble(decimal.Parse(((num2 + num3) * basic / 100.0).ToString()).ToString("N2"));
				double num6 = 0.0;
				num6 = Convert.ToDouble(decimal.Parse((num5 * Educess / 100.0).ToString()).ToString("N2"));
				double num7 = 0.0;
				num7 = Convert.ToDouble(decimal.Parse((num5 * shecess / 100.0).ToString()).ToString("N2"));
				double num8 = 0.0;
				if (FGT > 0.0 && num > 0.0)
				{
					double num9 = 0.0;
					num9 = Convert.ToDouble(num2 + num3 + num4);
					num8 = Convert.ToDouble(decimal.Parse((FGT * Convert.ToDouble(num9) / (num + num9)).ToString()).ToString("N2"));
				}
				else
				{
					num8 = FGT;
				}
				if (!base.IsPostBack)
				{
					txtFreight.Text = num8.ToString();
					txtPF.Text = num3.ToString();
					txtBasicExciseAmt.Text = num5.ToString();
					txtEDUCessAmt.Text = num6.ToString();
					txtSHECessAmt.Text = num7.ToString();
					txtBasicExcise.Text = basic.ToString();
					txtEDUCess.Text = Educess.ToString();
					txtSHECess.Text = shecess.ToString();
				}
				lblBasicExcise.Text = basic.ToString();
				lblEDUCess.Text = Educess.ToString();
				lblSHECess.Text = shecess.ToString();
				Rate = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Rate"]);
				lblRateAmt.Text = decimal.Parse(Rate.ToString()).ToString("N2");
				Disc = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Discount"]);
				lblDiscAmt.Text = decimal.Parse(Disc.ToString()).ToString("N2");
				lblItemcode.Text = ItemCode;
				lblUnit.Text = UomPurch;
				lblDiscription.Text = PurchDesc;
				lblFreight.Text = frieght;
				lblPF.Text = Pf;
				lblVat.Text = vat;
				lblExServiceTax.Text = Exst;
				if (Isvat == 1)
				{
					lblVatCst.Text = "VAT";
					bAmt = Convert.ToDouble(GQNAmt) + num3 + num4 + num8;
					double num10 = bAmt * vatVal / 100.0;
					TAmt = bAmt + num10;
					txtVatCstAmt.Text = Math.Round(num10, 2).ToString();
					vatVal1 = Convert.ToDouble(decimal.Parse(txtVatCstAmt.Text).ToString("N2"));
				}
				else if (Iscst == 1)
				{
					lblVatCst.Text = "CST";
					bAmt = Convert.ToDouble(GQNAmt) + num3 + num4;
					double num11 = bAmt * vatVal / 100.0;
					double num12 = bAmt + num11;
					TAmt = num12 + num8;
					txtVatCstAmt.Text = Math.Round(num11, 2).ToString();
					CstVal1 = Convert.ToDouble(decimal.Parse(txtVatCstAmt.Text).ToString("N2"));
				}
			}
			else if (GSNId != 0)
			{
				CkVat.Enabled = false;
				string cmdText14 = fun.select("tblinv_MaterialServiceNote_Master.GSNNo", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + GSNId + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
				SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter14.Fill(dataSet14);
				lblGNo.Text = "GSN No :";
				if (dataSet14.Tables[0].Rows.Count > 0)
				{
					lblGqnGsnNo.Text = dataSet14.Tables[0].Rows[0]["GSNNo"].ToString();
				}
				lblGQty.Text = "GSN Qty";
				lblGAmt.Text = "GSN Amt :";
				lblGqnGsnAmt.Text = GSNAmt.ToString();
				lblGqnGsnQty.Text = GSNQty.ToString();
				txtDebitAmt.Text = GSNAmt.ToString();
				double num13 = 0.0;
				num13 = Convert.ToDouble(txtDebitAmt.Text);
				double num14 = 0.0;
				num14 = Convert.ToDouble(decimal.Parse((num13 * PfVal / 100.0).ToString()).ToString("N2"));
				double num15 = 0.0;
				num15 = Convert.ToDouble(decimal.Parse(((num13 + num14) * ExstVal / 100.0).ToString()).ToString("N2"));
				lblExciseServiceTax.Text = num15.ToString();
				double num16 = 0.0;
				num16 = Convert.ToDouble(decimal.Parse(((num13 + num14) * basic / 100.0).ToString()).ToString("N2"));
				double num17 = 0.0;
				num17 = Convert.ToDouble(decimal.Parse((num16 * Educess / 100.0).ToString()).ToString("N2"));
				double num18 = 0.0;
				num18 = Convert.ToDouble(decimal.Parse((num16 * shecess / 100.0).ToString()).ToString("N2"));
				double num19 = 0.0;
				if (FGT > 0.0 && num > 0.0)
				{
					num19 = Convert.ToDouble(decimal.Parse((FGT * (Convert.ToDouble(GSNAmt) / num)).ToString()).ToString("N2"));
					double num20 = 0.0;
					num20 = Convert.ToDouble(GSNAmt + num14 + num15);
					num19 = Convert.ToDouble(decimal.Parse((FGT * Convert.ToDouble(num20) / (num + num20)).ToString()).ToString("N2"));
				}
				else
				{
					num19 = FGT;
				}
				if (!base.IsPostBack)
				{
					txtFreight.Text = num19.ToString();
					txtPF.Text = num14.ToString();
					txtBasicExciseAmt.Text = num16.ToString();
					txtEDUCessAmt.Text = num17.ToString();
					txtSHECessAmt.Text = num18.ToString();
					txtBasicExcise.Text = basic.ToString();
					txtEDUCess.Text = Educess.ToString();
					txtSHECess.Text = shecess.ToString();
				}
				lblBasicExcise.Text = basic.ToString();
				lblEDUCess.Text = Educess.ToString();
				lblSHECess.Text = shecess.ToString();
				txtFreight.Text = num19.ToString();
				Rate = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Rate"]);
				lblRateAmt.Text = decimal.Parse(Rate.ToString()).ToString("N2");
				Disc = Convert.ToDouble(dataSet.Tables[0].Rows[0]["Discount"]);
				lblDiscAmt.Text = decimal.Parse(Disc.ToString()).ToString("N2");
				lblItemcode.Text = ItemCode;
				lblUnit.Text = UomPurch;
				lblDiscription.Text = PurchDesc;
				lblPF.Text = Pf;
				lblVat.Text = vat;
				lblFreight.Text = frieght;
				lblExServiceTax.Text = Exst;
				if (Isvat == 1)
				{
					lblVatCst.Text = "VAT";
					bAmt = Convert.ToDouble(GSNAmt) + num14 + num15 + num19;
					double num21 = bAmt * vatVal / 100.0;
					TAmt = bAmt + num21;
					txtVatCstAmt.Text = Math.Round(num21, 2).ToString();
					vatVal1 = Convert.ToDouble(decimal.Parse(txtVatCstAmt.Text).ToString("N2"));
				}
				else if (Iscst == 1)
				{
					lblVatCst.Text = "CST";
					bAmt = Convert.ToDouble(GSNAmt) + num14 + num15;
					double num22 = bAmt * vatVal / 100.0;
					double tAmt = bAmt + num22;
					TAmt = tAmt;
					txtVatCstAmt.Text = Math.Round(num22, 2).ToString();
					CstVal1 = Convert.ToDouble(decimal.Parse(txtVatCstAmt.Text).ToString("N2"));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BillBooking_ItemGrid.aspx?SUPId=" + SupplierNo + "&POId=" + PoId + "&PId=" + PId + "&FGT=" + FGT + "&FyId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			Calculation();
			if (!(txtVatCstAmt.Text != "") || !(txtPF.Text != "") || !(txtBasicExcise.Text != "") || !(txtEDUCess.Text != "") || !(txtSHECess.Text != "") || !(txtBasicExciseAmt.Text != "") || !(txtEDUCessAmt.Text != "") || !(txtSHECessAmt.Text != "") || !(txtTCEntryNo.Text != "") || !fun.NumberValidationQty(txtPF.Text) || !fun.NumberValidationQty(txtBasicExcise.Text) || !fun.NumberValidationQty(txtEDUCess.Text) || !fun.NumberValidationQty(txtSHECess.Text) || !fun.NumberValidationQty(txtBasicExciseAmt.Text) || !fun.NumberValidationQty(txtEDUCessAmt.Text) || !fun.NumberValidationQty(txtSHECessAmt.Text) || !fun.NumberValidationQty(txtVatCstAmt.Text) || !fun.NumberValidationQty(txtDebit.Text) || !fun.NumberValidationQty(txtDebitAmt.Text) || !fun.NumberValidationQty(txtRate.Text) || !fun.NumberValidationQty(txtDisc.Text))
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			double num12 = 0.0;
			int num13 = 0;
			double num14 = 0.0;
			double num15 = 0.0;
			num15 = FGT;
			if (CkPf.Checked)
			{
				num3 = Convert.ToInt32(DDLPF.SelectedValue);
				num8 = 1;
			}
			else
			{
				num3 = PfId;
				num8 = 0;
			}
			if (CkExcise.Checked)
			{
				num4 = Convert.ToInt32(DDLExcies.SelectedValue);
				num9 = 1;
			}
			else
			{
				num4 = ExStId;
				num9 = 0;
			}
			if (CkVat.Checked)
			{
				num5 = Convert.ToInt32(DDLVat.SelectedValue);
				num10 = 1;
			}
			else
			{
				num5 = VatCstId;
				num10 = 0;
			}
			double num16 = 0.0;
			double num17 = 0.0;
			switch (lblVatCst.Text)
			{
			case "VAT":
				num16 = Convert.ToDouble(txtVatCstAmt.Text);
				break;
			case "CST":
				num17 = Convert.ToDouble(txtVatCstAmt.Text);
				break;
			}
			if (CkRate.Checked)
			{
				num6 = 1;
				num2 = Convert.ToDouble(txtRate.Text);
			}
			if (CkDisc.Checked)
			{
				num7 = 1;
				num = Convert.ToDouble(txtDisc.Text);
			}
			if (CKDebit.Checked)
			{
				num11 = 1;
				num12 = Convert.ToDouble(txtDebit.Text);
				num13 = Convert.ToInt32(DrpType.SelectedValue);
				num14 = Convert.ToDouble(txtDebitAmt.Text);
			}
			int num18 = 0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			int num23 = 0;
			double num24 = 0.0;
			double num25 = 0.0;
			int num26 = 0;
			double num27 = 0.0;
			double num28 = 0.0;
			double num29 = 0.0;
			double num30 = 0.0;
			double num31 = 0.0;
			num31 = Convert.ToDouble(txtInsurance.Text);
			double num32 = 0.0;
			if (CkBCD.Checked)
			{
				num18 = Convert.ToInt32(drpBCD.SelectedValue);
				num19 = Convert.ToDouble(txtBCD.Text);
				num20 = Convert.ToDouble(txtCalBCD.Text);
				num21 = Convert.ToDouble(txtValCVD.Text);
				num22 = Convert.ToDouble(txtValEdCessCD.Text);
				if (CkEdCessCD.Checked)
				{
					num23 = Convert.ToInt32(drpEdCessCD.SelectedValue);
					num24 = Convert.ToDouble(txtEdCessCD.Text);
					num25 = Convert.ToDouble(txtEdCessOnCD.Text);
				}
				if (CkSHEdCess.Checked)
				{
					num26 = Convert.ToInt32(drpSHEdCess.SelectedValue);
					num27 = Convert.ToDouble(txtSHEdCess.Text);
					num28 = Convert.ToDouble(txtSHEdCessAmt.Text);
				}
				num29 = Convert.ToDouble(txtTotDuty.Text);
				num30 = Convert.ToDouble(txtEDSHED.Text);
				num32 = Convert.ToDouble(txtValDuty.Text);
			}
			double num33 = 0.0;
			double num34 = 0.0;
			if (GQNId != 0)
			{
				num34 = Math.Round(Convert.ToDouble(txtDebitAmt.Text), 2);
			}
			else if (GSNId != 0)
			{
				num33 = Math.Round(Convert.ToDouble(txtDebitAmt.Text), 2);
			}
			string cmdText = "SELECT tblMM_PO_Master.Id FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.Id='" + PoId + "'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if ((Isvat == 1 && ST == 0) || (Iscst == 1 && ST == 1) || (Iscst == 0 && Isvat == 0))
			{
				string cmdText2 = fun.insert("tblACC_BillBooking_Details_Temp", "SessionId,CompId,POId,PODId,GQNId,GQNAmt,GSNId,GSNAmt,ItemId,RateOpt,Rate,DiscOpt,Disc,CKDebit,DebitValue,DebitType,DebitAmt,CKPF,PFOpt,PFAmt,CKEX,ExciseOpt,ExStBasicInPer,ExStEducessInPer,ExStShecessInPer,ExStBasic,ExStEducess,ExStShecess,CKVATCST,VATCSTOpt,VAT,CST,TarrifNo,BCDOpt,BCD,BCDValue,ValueForCVD,ValueForEdCessCD,EdCessOnCDOpt,EdCessOnCD,EdCessOnCDValue,SHEDCessOpt,SHEDCess,SHEDCessValue,TotDuty,TotDutyEDSHED,Insurance,ValueWithDuty,ACHead", "'" + SId + "','" + CompId + "','" + Convert.ToInt32(sqlDataReader["Id"]) + "','" + PoId + "','" + GQNId + "','" + num34 + "','" + GSNId + "','" + num33 + "','" + ItemId + "','" + num6 + "','" + num2 + "','" + num7 + "','" + num + "','" + num11 + "','" + num12 + "','" + num13 + "','" + num14 + "','" + num8 + "','" + num3 + "','" + txtPF.Text + "','" + num9 + "','" + num4 + "','" + txtBasicExcise.Text + "','" + txtEDUCess.Text + "','" + txtSHECess.Text + "','" + txtBasicExciseAmt.Text + "','" + txtEDUCessAmt.Text + "','" + txtSHECessAmt.Text + "','" + num10 + "','" + num5 + "','" + num16 + "','" + num17 + "','" + txtTCEntryNo.Text + "','" + num18 + "','" + num19 + "','" + num20 + "','" + num21 + "','" + num22 + "','" + num23 + "','" + num24 + "','" + num25 + "','" + num26 + "','" + num27 + "','" + num28 + "','" + num29 + "','" + num30 + "','" + num31 + "','" + num32 + "','" + ACHead + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				double num35 = 0.0;
				string cmdText3 = fun.select("GQNAmt+GSNAmt As Sum_GQNGSN_Amt,PFAmt,ExStBasic+ExStEducess+ExStShecess As Excise_Amt,DebitType,DebitValue,BCDValue,EdCessOnCDValue,SHEDCessValue", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_BillBooking_Details_Temp");
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					double num36 = 0.0;
					double num37 = 0.0;
					double num38 = 0.0;
					double num39 = 0.0;
					double num40 = 0.0;
					double num41 = 0.0;
					double num42 = 0.0;
					double num43 = 0.0;
					num36 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Sum_GQNGSN_Amt"]);
					num37 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["PFAmt"]);
					num38 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Excise_Amt"]);
					num39 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["DebitValue"]);
					num41 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["BCDValue"]);
					num42 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["EdCessOnCDValue"]);
					num43 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["SHEDCessValue"]);
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["DebitType"]))
					{
					case 1:
						num40 = num36 - num39;
						break;
					case 2:
						num40 = num36 - num36 * num39 / 100.0;
						break;
					case 0:
						num40 = num36;
						break;
					}
					num35 += num40 + num37 + num38 + num41 + num42 + num43;
				}
				string cmdText4 = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblACC_BillBooking_Details_Temp");
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
				{
					for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
					{
						double num44 = 0.0;
						double num45 = 0.0;
						double num46 = 0.0;
						double num47 = 0.0;
						string cmdText5 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + dataSet2.Tables[0].Rows[j]["VATCSTOpt"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						num47 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
						int num48 = 0;
						int num49 = 0;
						num48 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["IsVAT"]);
						num49 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["IsCST"]);
						if (dataSet2.Tables[0].Rows[j]["GQNId"].ToString() != "0")
						{
							double num50 = 0.0;
							double num51 = 0.0;
							num51 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["GQNAmt"].ToString());
							num50 = num51 + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["PFAmt"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStBasic"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStEducess"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStShecess"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["BCDValue"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["EdCessOnCDValue"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["SHEDCessValue"]);
							num44 = ((!(num35 > 0.0)) ? num15 : Math.Round(num15 * num50 / num35, 2));
							if (num48 == 1)
							{
								bAmt = num50 + num44;
								double value = bAmt * num47 / 100.0;
								num45 = Math.Round(value, 2);
							}
							else if (num49 == 1)
							{
								bAmt = num50;
								double value2 = bAmt * num47 / 100.0;
								num46 = Math.Round(value2, 2);
							}
							else
							{
								bAmt = num50 + num44;
							}
						}
						else if (dataSet2.Tables[0].Rows[j]["GSNId"].ToString() != "0")
						{
							double num52 = 0.0;
							double num53 = 0.0;
							num53 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["GSNAmt"].ToString());
							num52 = num53 + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["PFAmt"].ToString()) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStBasic"].ToString()) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStEducess"].ToString()) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStShecess"].ToString()) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["BCDValue"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["EdCessOnCDValue"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[j]["SHEDCessValue"]);
							num44 = ((!(num35 > 0.0)) ? num15 : Math.Round(num15 * num52 / num35, 2));
							if (num48 == 1)
							{
								bAmt = num52 + num44;
								double value3 = bAmt * num47 / 100.0;
								num45 = Math.Round(value3, 2);
							}
							else if (num49 == 1)
							{
								bAmt = num52;
								double num54 = bAmt * num47 / 100.0;
								num46 = Math.Round(num54 + num44, 2);
							}
							else
							{
								bAmt = num52 + num44;
							}
						}
						string cmdText6 = fun.update("tblACC_BillBooking_Details_Temp", "VAT='" + num45 + "',CST='" + num46 + "',Freight='" + num44 + "'", "SessionId='" + SId + "' AND CompId='" + CompId + "' AND Id='" + dataSet2.Tables[0].Rows[j]["Id"].ToString() + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
					}
				}
				base.Response.Redirect("BillBooking_ItemGrid.aspx?SUPId=" + SupplierNo + "&FGT=" + FGT + "&FyId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
			}
			else
			{
				string empty = string.Empty;
				empty = ((ST != 0) ? "OMS" : "within MH");
				string empty2 = string.Empty;
				empty2 = "Invoice is " + empty;
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BillBooking_ItemGrid.aspx?SUPId=" + SupplierNo + "&POId=" + PoId + "&PId=" + PId + "&FGT=" + FGT + "&FyId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
	}

	protected void CkRate_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkRate.Checked)
			{
				txtRate.Enabled = true;
			}
			else
			{
				txtRate.Enabled = false;
				txtRate.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkDisc_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkDisc.Checked)
			{
				txtDisc.Enabled = true;
			}
			else
			{
				txtDisc.Text = "0";
				txtDisc.Enabled = false;
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkPf_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkPf.Checked)
			{
				DDLPF.Enabled = true;
				txtPF.Enabled = true;
			}
			else
			{
				DDLPF.Enabled = false;
				txtPF.Enabled = false;
				DDLPF.SelectedValue = PfId.ToString();
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkExcise_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkExcise.Checked)
			{
				DDLExcies.Enabled = true;
				if (DDLExcies.SelectedValue == "2" || DDLExcies.SelectedValue == "3" || DDLExcies.SelectedValue == "4")
				{
					txtBasicExcise.Enabled = true;
					txtBasicExciseAmt.Enabled = true;
					txtEDUCess.Enabled = true;
					txtEDUCessAmt.Enabled = true;
					txtSHECess.Enabled = true;
					txtSHECessAmt.Enabled = true;
				}
				else
				{
					txtBasicExcise.Enabled = false;
					txtBasicExciseAmt.Enabled = false;
					txtEDUCess.Enabled = false;
					txtEDUCessAmt.Enabled = false;
					txtSHECess.Enabled = false;
					txtSHECessAmt.Enabled = false;
				}
			}
			else
			{
				DDLExcies.SelectedValue = ExStId.ToString();
				DDLExcies.Enabled = false;
				txtBasicExcise.Enabled = false;
				txtBasicExciseAmt.Enabled = false;
				txtEDUCess.Enabled = false;
				txtEDUCessAmt.Enabled = false;
				txtSHECess.Enabled = false;
				txtSHECessAmt.Enabled = false;
				txtBasicExcise.Text = "0";
				txtBasicExciseAmt.Text = "0";
				txtEDUCess.Text = "0";
				txtEDUCessAmt.Text = "0";
				txtSHECess.Text = "0";
				txtSHECessAmt.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void DDLExcies_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DDLExcies.Enabled)
			{
				if (DDLExcies.SelectedValue == "2" || DDLExcies.SelectedValue == "3" || DDLExcies.SelectedValue == "4")
				{
					txtBasicExcise.Enabled = true;
					txtBasicExcise.Text = "0";
					txtBasicExciseAmt.Enabled = true;
					txtBasicExciseAmt.Text = "0";
					txtEDUCess.Enabled = true;
					txtEDUCess.Text = "0";
					txtEDUCessAmt.Enabled = true;
					txtEDUCessAmt.Text = "0";
					txtSHECess.Enabled = true;
					txtSHECess.Text = "0";
					txtSHECessAmt.Enabled = true;
					txtSHECessAmt.Text = "0";
				}
				else
				{
					txtBasicExcise.Enabled = false;
					txtBasicExciseAmt.Enabled = false;
					txtEDUCess.Enabled = false;
					txtEDUCessAmt.Enabled = false;
					txtSHECess.Enabled = false;
					txtSHECessAmt.Enabled = false;
				}
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkVat_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkVat.Checked)
			{
				DDLVat.Enabled = true;
			}
			else
			{
				DDLVat.Enabled = false;
				DDLVat.SelectedValue = VatCstId.ToString();
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void DDLVat_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CKDebit_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CKDebit.Checked)
			{
				txtDebit.Enabled = true;
			}
			else
			{
				txtDebit.Enabled = false;
				txtDebit.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	public double Calculation()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		double result = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
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
		string empty = string.Empty;
		double num19 = 0.0;
		double num20 = 0.0;
		double num21 = 0.0;
		double num22 = 0.0;
		double num23 = 0.0;
		double num24 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		try
		{
			num2 = ((!CkRate.Checked) ? Rate : Convert.ToDouble(txtRate.Text));
			num3 = ((!CkDisc.Checked) ? Disc : Convert.ToDouble(txtDisc.Text));
			double num29 = 0.0;
			if (CKDebit.Checked)
			{
				num29 = Math.Round(Qty * (num2 - num2 * num3 / 100.0), 2);
				switch (DrpType.SelectedValue)
				{
				case "1":
					num = Math.Round(num29 - Convert.ToDouble(txtDebit.Text), 2);
					txtDebitAmt.Text = num.ToString();
					break;
				case "2":
					num = Math.Round(num29 - num29 * Convert.ToDouble(txtDebit.Text) / 100.0, 2);
					txtDebitAmt.Text = num.ToString();
					break;
				}
			}
			else
			{
				num = Math.Round(Qty * (num2 - num2 * num3 / 100.0), 2);
				txtDebitAmt.Text = num.ToString();
			}
			if (CkPf.Checked)
			{
				string cmdText = fun.select("Id,Terms,Value", "tblPacking_Master", "Id='" + DDLPF.SelectedValue.ToString() + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num4 = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0][2]), 2);
				}
			}
			else
			{
				num4 = PfVal;
			}
			if (CkExcise.Checked)
			{
				string cmdText2 = fun.select("Terms,Value,AccessableValue,EDUCess,SHECess,Id", "tblExciseser_Master", "tblExciseser_Master.Id='" + DDLExcies.SelectedValue.ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][1]);
					num6 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][2]);
					num7 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][3]);
					num8 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][4]);
				}
			}
			else
			{
				num5 = ExstVal;
				num6 = basic;
				num7 = Educess;
				num8 = shecess;
			}
			num9 = Convert.ToDouble(txtFreight.Text);
			if (CkVat.Checked)
			{
				string cmdText3 = fun.select("Id,Terms,Value,IsVAT,IsCST", "tblVAT_Master", "tblVAT_Master.Id='" + DDLVat.SelectedValue.ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					num10 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][2]);
					Isvat = Convert.ToInt32(dataSet3.Tables[0].Rows[0][3]);
					Iscst = Convert.ToInt32(dataSet3.Tables[0].Rows[0][4]);
				}
			}
			else
			{
				string cmdText4 = fun.select("Id,Terms,Value,IsVAT,IsCST", "tblVAT_Master", "tblVAT_Master.Id='" + VatCstId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num10 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][2]);
					Isvat = Convert.ToInt32(dataSet4.Tables[0].Rows[0][3]);
					Iscst = Convert.ToInt32(dataSet4.Tables[0].Rows[0][4]);
				}
			}
			num11 = Math.Round(num * num4 / 100.0, 2);
			if (CkBCD.Checked)
			{
				num17 = Convert.ToDouble(txtBCD.Text);
				empty = drpBCD.SelectedValue;
				if (empty == "1")
				{
					num18 = Math.Round(num17, 2);
					txtCalBCD.Text = num18.ToString();
				}
				else if (empty == "2")
				{
					num18 = Math.Round((num + num11) * num17 / 100.0, 2);
					txtCalBCD.Text = num18.ToString();
				}
				num19 = Math.Round(num + num11 + Convert.ToDouble(txtCalBCD.Text), 2);
				txtValCVD.Text = num19.ToString();
				num12 = Math.Round(num19 * num5 / 100.0, 2);
				num13 = Math.Round(num19 * num6 / 100.0, 2);
				num14 = Math.Round(num13 * num7 / 100.0, 2);
				num15 = Math.Round(num13 * num8 / 100.0, 2);
				num20 = num18 + num12;
				txtValEdCessCD.Text = Math.Round(num20, 2).ToString();
				num22 = Math.Round(Convert.ToDouble(txtEdCessCD.Text), 2);
				if (drpEdCessCD.SelectedValue == "1")
				{
					num21 = num22;
					txtEdCessOnCD.Text = num21.ToString();
				}
				else if (drpEdCessCD.SelectedValue == "2")
				{
					num21 = Math.Round(num20 * Convert.ToDouble(txtEdCessCD.Text) / 100.0, 2);
					txtEdCessOnCD.Text = num21.ToString();
				}
				num23 = Math.Round(Convert.ToDouble(txtSHEdCess.Text), 2);
				if (drpSHEdCess.SelectedValue == "1")
				{
					num24 = num23;
					txtSHEdCessAmt.Text = num24.ToString();
				}
				else if (drpSHEdCess.SelectedValue == "2")
				{
					num24 = Math.Round(num20 * num23 / 100.0, 2);
					txtSHEdCessAmt.Text = num24.ToString();
				}
				num25 = Math.Round(num18 + num13, 2);
				txtTotDuty.Text = num25.ToString();
				num26 = Math.Round(num21 + num24 + num14 + num15, 2);
				txtEDSHED.Text = num26.ToString();
				num27 = num25 + num26;
				num28 = num + num11 + num27;
				txtValDuty.Text = num28.ToString();
				if (Isvat == 1)
				{
					num16 = Math.Round((num28 + num9) * num10 / 100.0, 2);
				}
				else if (Iscst == 1)
				{
					num16 = Math.Round(num28 * num10 / 100.0, 2);
				}
			}
			else
			{
				num12 = Math.Round((num + num11) * num5 / 100.0, 2);
				num13 = Math.Round((num + num11) * num6 / 100.0, 2);
				num14 = Math.Round(num13 * num7 / 100.0, 2);
				num15 = Math.Round(num13 * num8 / 100.0, 2);
				if (DDLExcies.SelectedValue == "3" || ExStId == 3)
				{
					num12 = Convert.ToDouble(txtBasicExciseAmt.Text) + Convert.ToDouble(txtEDUCessAmt.Text) + Convert.ToDouble(txtSHECessAmt.Text);
				}
				if (Isvat == 1)
				{
					num16 = Math.Round((num + num11 + num12 + num9) * num10 / 100.0, 2);
				}
				else if (Iscst == 1)
				{
					num16 = Math.Round((num + num11 + num12) * num10 / 100.0, 2);
				}
			}
			lblGqnGsnAmt.Text = (Qty * (num2 - num2 * num3 / 100.0)).ToString();
			txtPF.Text = num11.ToString();
			txtVatCstAmt.Text = num16.ToString();
			if (DDLExcies.SelectedValue == "2" || DDLExcies.SelectedValue == "3" || DDLExcies.SelectedValue == "4")
			{
				if (!base.IsPostBack)
				{
					lblExciseServiceTax.Text = num12.ToString();
					txtBasicExcise.Text = num6.ToString();
					txtBasicExciseAmt.Text = num13.ToString();
					txtEDUCess.Text = num7.ToString();
					txtEDUCessAmt.Text = num14.ToString();
					txtSHECess.Text = num8.ToString();
					txtSHECessAmt.Text = num15.ToString();
				}
			}
			else
			{
				lblExciseServiceTax.Text = num12.ToString();
				txtBasicExcise.Text = num6.ToString();
				txtBasicExciseAmt.Text = num13.ToString();
				txtEDUCess.Text = num7.ToString();
				txtEDUCessAmt.Text = num14.ToString();
				txtSHECess.Text = num8.ToString();
				txtSHECessAmt.Text = num15.ToString();
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DDLPF_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkBCD_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkBCD.Checked)
			{
				txtBCD.Enabled = true;
				drpBCD.Enabled = true;
			}
			else
			{
				txtBCD.Enabled = false;
				drpBCD.Enabled = false;
				txtBCD.Text = "0";
				txtCalBCD.Text = "0";
				txtValCVD.Text = "0";
				txtValEdCessCD.Text = "0";
				txtTotDuty.Text = "0";
				txtEDSHED.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkEdCessCD_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkEdCessCD.Checked)
			{
				txtEdCessCD.Enabled = true;
				drpEdCessCD.Enabled = true;
			}
			else
			{
				txtEdCessCD.Enabled = false;
				drpEdCessCD.Enabled = false;
				txtEdCessCD.Text = "0";
				txtEdCessOnCD.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void CkSHEdCess_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CkSHEdCess.Checked)
			{
				txtSHEdCess.Enabled = true;
				drpSHEdCess.Enabled = true;
			}
			else
			{
				txtSHEdCess.Enabled = false;
				drpSHEdCess.Enabled = false;
				txtSHEdCess.Text = "0";
				txtSHEdCess.Text = "0";
				txtSHEdCessAmt.Text = "0";
			}
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void drpBCD_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void drpEdCessCD_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}

	protected void drpSHEdCess_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Calculation();
		}
		catch (Exception)
		{
		}
	}
}

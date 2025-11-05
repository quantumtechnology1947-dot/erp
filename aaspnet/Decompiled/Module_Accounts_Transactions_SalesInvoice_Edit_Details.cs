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
using MKB.TimePicker;

public class Module_Accounts_Transactions_SalesInvoice_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string Invid = "";

	private string CCode = "";

	private string InvNo = "";

	private SqlConnection con;

	protected Label LblInv;

	protected Label LblInvDate;

	protected Label LblMode;

	protected Label lblmodeid;

	protected SqlDataSource SqlCat;

	protected SqlDataSource SqlCommodity;

	protected Label LblPONo;

	protected Label lblPOdt;

	protected Label LblWONo;

	protected SqlDataSource Sqltransport;

	protected SqlDataSource Sqlnature;

	protected DropDownList DrpCategory;

	protected DropDownList DrpCommodity;

	protected Label lbltrafficNo;

	protected TextBox TxtDutyRate;

	protected RequiredFieldValidator Reqrateofduty;

	protected DropDownList DrpTransport;

	protected TextBox TxtRRGCNo;

	protected RequiredFieldValidator ReqRgcno;

	protected TextBox TxtRegistrationNo;

	protected RequiredFieldValidator ReqregistNo;

	protected DropDownList DrpNatureremovable;

	protected TextBox TxtDateofIssueInvoice;

	protected CalendarExtender TxtDateofIssueInvoice_CalendarExtender;

	protected RequiredFieldValidator ReqDateofinvoce;

	protected RegularExpressionValidator RegEditDateOfIssInvoice;

	protected TimeSelector TimeOfIssue;

	protected TextBox TxtDateRemoval;

	protected CalendarExtender TxtDateRemoval_CalendarExtender;

	protected RequiredFieldValidator ReqDateofremoval;

	protected RegularExpressionValidator RegDateOfRemovalEdit;

	protected TimeSelector TimeOfRemove;

	protected TextBox TxtBYName;

	protected AutoCompleteExtender AutoCompleteExtender2;

	protected RequiredFieldValidator ReqByName;

	protected Button Button1;

	protected TextBox TxtByAddress;

	protected RequiredFieldValidator ReqByAddress;

	protected DropDownList DrpByCountry;

	protected DropDownList DrpByState;

	protected DropDownList DrpByCity;

	protected TextBox TxtByCName;

	protected RequiredFieldValidator ReqByCName;

	protected TextBox TxtByPhone;

	protected RequiredFieldValidator ReqByPhone;

	protected TextBox TxtByMobile;

	protected RequiredFieldValidator ReqByMobile;

	protected TextBox TxtByEmail;

	protected RequiredFieldValidator ReqByEmail;

	protected RegularExpressionValidator RegEmailvalBuyerEdit;

	protected TextBox TxtByFaxNo;

	protected RequiredFieldValidator ReqFaxNo;

	protected TextBox TxtByTINVATNo;

	protected RequiredFieldValidator ReqByTinVatNo;

	protected TextBox TxtByECCNo;

	protected RequiredFieldValidator ReqCustEccNo;

	protected TextBox TxtByTINCSTNo;

	protected RequiredFieldValidator ReqByTInCStNo;

	protected Button BtnBuy;

	protected Button Button2;

	protected TabPanel TabPanel1;

	protected TextBox TxtCName;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator ReqCName;

	protected Button Button4;

	protected Button Button6;

	protected TextBox TxtCAddress;

	protected RequiredFieldValidator ReqCaddress;

	protected DropDownList DrpCoCountry;

	protected DropDownList DrpCoState;

	protected DropDownList DrpCoCity;

	protected TextBox TxtCoPersonName;

	protected RequiredFieldValidator ReqCoperson;

	protected TextBox TxtCoPhoneNo;

	protected RequiredFieldValidator ReqCPhoneno;

	protected TextBox TxtCoMobileNo;

	protected RequiredFieldValidator ReqCMobileno;

	protected TextBox TxtCoEmail;

	protected RequiredFieldValidator ReqCEmail;

	protected RegularExpressionValidator RegEmailvalCoEdit;

	protected TextBox TxtCoFaxNo;

	protected RequiredFieldValidator ReqCFaxNo;

	protected TextBox TxtCoTinVatNo;

	protected RequiredFieldValidator ReqCTinVatno;

	protected TextBox TxtECoCCNo;

	protected RequiredFieldValidator ReqCECCNo;

	protected TextBox TxtCoTinCSTNo;

	protected RequiredFieldValidator ReqCTINcstno;

	protected Button BtnCNext;

	protected Button Button7;

	protected TabPanel TabPanel2;

	protected GridView GridView1;

	protected Panel Panel1;

	protected SqlDataSource SqlUnitQty;

	protected Button Btngoods;

	protected Button Button8;

	protected TabPanel TabPanel3;

	protected TextBox TxtAdd;

	protected RequiredFieldValidator ReqAdd;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected DropDownList DrpAdd;

	protected TextBox TxtOtherAmt;

	protected RequiredFieldValidator ReqTxtOtherAmt;

	protected RegularExpressionValidator RegTxtOtherAmt;

	protected TextBox TxtDeduct;

	protected RequiredFieldValidator ReqDed;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList DrpDed;

	protected TextBox TxtPf;

	protected RequiredFieldValidator ReqPf;

	protected RegularExpressionValidator RegularExpressionValidator12;

	protected DropDownList DrpPAF;

	protected DropDownList DrpServiceTax;

	protected SqlDataSource SqlServiceTax;

	protected SqlDataSource SqlVAT;

	protected TextBox TxtSed;

	protected RequiredFieldValidator ReqSed;

	protected RegularExpressionValidator RegularExpressionValidator6;

	protected DropDownList DrpSED;

	protected TextBox TxtAed;

	protected RequiredFieldValidator ReqAed;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected DropDownList DrpAED;

	protected TextBox Txtfreight;

	protected RequiredFieldValidator Reqfrieght;

	protected RegularExpressionValidator RegularExpressionValidator8;

	protected DropDownList DrpFreight;

	protected Label lblVAT;

	protected DropDownList DrpCst;

	protected DropDownList DrpVAT;

	protected TextBox TxtInsurance;

	protected RequiredFieldValidator ReqInsurance;

	protected RegularExpressionValidator RegularExpressionValidator11;

	protected DropDownList DrpInsurance;

	protected Button BtnUpdate;

	protected Button ButtonCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		con = new SqlConnection(connectionString);
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Invid = fun.Decrypt(base.Request.QueryString["invId"].ToString());
			InvNo = fun.Decrypt(base.Request.QueryString["InvNo"]);
			CCode = fun.Decrypt(base.Request.QueryString["cid"].ToString());
			sId = Session["username"].ToString();
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
			if (base.IsPostBack)
			{
				return;
			}
			fun.dropdownCountry(DrpByCountry, DrpByState);
			fun.dropdownCountry(DrpCoCountry, DrpCoState);
			LoadData();
			string cmdText = fun.select("Id,SysDate, SysTime , CompId , FinYearId , SessionId , InvoiceNo , PONo ,POId, WONo, InvoiceMode  , DateOfIssueInvoice  , DateOfRemoval , TimeOfIssueInvoice  , TimeOfRemoval , NatureOfRemoval  , Commodity  , TariffHeading  , ModeOfTransport  , RRGCNo , VehiRegNo , DutyRate  , CustomerCode  , CustomerCategory  , Buyer_name  , Buyer_add  , Buyer_city  , Buyer_state , Buyer_country  , Buyer_cotper  , Buyer_ph  , Buyer_email , Buyer_ecc  , Buyer_tin  , Buyer_mob  , Buyer_fax  , Buyer_vat , Cong_name, Cong_add  , Cong_city  , Cong_state , Cong_country  , Cong_cotper  , Cong_ph , Cong_email  , Cong_ecc  , Cong_tin  , Cong_mob , Cong_fax  , Cong_vat , AddType  , AddAmt  , DeductionType , Deduction  , PFType  , PF  , CENVAT , SED  , AED  , VAT  , SelectedCST  , CST  , FreightType, Freight , InsuranceType  , Insurance,SEDType,AEDType,OtherAmt", "tblACC_SalesInvoice_Master  ", "CompId='" + CompId + "' And InvoiceNo='" + InvNo + "' AND Id='" + Invid + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			LblInv.Text = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString();
			string cmdText2 = fun.select("Id,Description", "tblACC_SalesInvoice_Master_Type", "Id='" + dataSet.Tables[0].Rows[0]["InvoiceMode"].ToString() + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			lblmodeid.Text = dataSet2.Tables[0].Rows[0]["Id"].ToString();
			LblMode.Text = dataSet2.Tables[0].Rows[0]["Description"].ToString();
			LblPONo.Text = dataSet.Tables[0].Rows[0]["PONo"].ToString();
			string text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
			string[] array = text.Split(',');
			string text2 = "";
			for (int i = 0; i < array.Length - 1; i++)
			{
				string cmdText3 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[i] + "' ANd CompId='" + CompId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					text2 = text2 + dataSet3.Tables[0].Rows[0][0].ToString() + ",";
				}
			}
			LblWONo.Text = text2;
			TxtDateofIssueInvoice.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
			TxtDateRemoval.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfRemoval"].ToString());
			DrpCategory.SelectedValue = dataSet.Tables[0].Rows[0]["CustomerCategory"].ToString();
			DrpNatureremovable.SelectedValue = dataSet.Tables[0].Rows[0]["NatureOfRemoval"].ToString();
			DrpTransport.SelectedValue = dataSet.Tables[0].Rows[0]["ModeOfTransport"].ToString();
			DrpCommodity.SelectedValue = dataSet.Tables[0].Rows[0]["Commodity"].ToString();
			TxtDutyRate.Text = dataSet.Tables[0].Rows[0]["DutyRate"].ToString();
			lbltrafficNo.Text = fun.ExciseCommodity(Convert.ToInt32(dataSet.Tables[0].Rows[0]["Commodity"]));
			TxtRRGCNo.Text = dataSet.Tables[0].Rows[0]["RRGCNo"].ToString();
			TxtRegistrationNo.Text = dataSet.Tables[0].Rows[0]["VehiRegNo"].ToString();
			TxtByCName.Text = dataSet.Tables[0].Rows[0]["Buyer_cotper"].ToString();
			string cmdText4 = fun.select("PODate", "SD_Cust_PO_Master", "POId='" + dataSet.Tables[0].Rows[0]["POId"].ToString() + "' ANd CompId='" + CompId + "'");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				lblPOdt.Text = fun.FromDateDMY(dataSet4.Tables[0].Rows[0][0].ToString());
			}
			string fD = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
			LblInvDate.Text = fun.FromDateDMY(fD);
			TxtByAddress.Text = dataSet.Tables[0].Rows[0]["Buyer_add"].ToString();
			TxtBYName.Text = dataSet.Tables[0].Rows[0]["Buyer_name"].ToString();
			TxtByFaxNo.Text = dataSet.Tables[0].Rows[0]["Buyer_fax"].ToString();
			TxtByPhone.Text = dataSet.Tables[0].Rows[0]["Buyer_ph"].ToString();
			TxtByMobile.Text = dataSet.Tables[0].Rows[0]["Buyer_mob"].ToString();
			TxtByEmail.Text = dataSet.Tables[0].Rows[0]["Buyer_email"].ToString();
			TxtByTINCSTNo.Text = dataSet.Tables[0].Rows[0]["Buyer_tin"].ToString();
			TxtByTINVATNo.Text = dataSet.Tables[0].Rows[0]["Buyer_vat"].ToString();
			TxtByECCNo.Text = dataSet.Tables[0].Rows[0]["Buyer_ecc"].ToString();
			fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["Buyer_country"].ToString() + "'");
			DrpByCountry.SelectedIndex = 0;
			fun.dropdownCountry(DrpByCountry, DrpByState);
			fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
			fun.dropdownStatebyId(DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["Buyer_country"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["Buyer_state"].ToString() + "'");
			DrpByState.SelectedValue = dataSet.Tables[0].Rows[0]["Buyer_state"].ToString();
			fun.dropdownCity(DrpByCity, DrpByState);
			fun.dropdownCitybyId(DrpByCity, "SId='" + dataSet.Tables[0].Rows[0]["Buyer_state"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["Buyer_city"].ToString() + "'");
			DrpByCity.SelectedValue = dataSet.Tables[0].Rows[0]["Buyer_city"].ToString();
			TxtCName.Text = dataSet.Tables[0].Rows[0]["Cong_name"].ToString();
			TxtCAddress.Text = dataSet.Tables[0].Rows[0]["Cong_add"].ToString();
			TxtCoPersonName.Text = dataSet.Tables[0].Rows[0]["Cong_cotper"].ToString();
			TxtCoPhoneNo.Text = dataSet.Tables[0].Rows[0]["Cong_ph"].ToString();
			TxtCoMobileNo.Text = dataSet.Tables[0].Rows[0]["Cong_mob"].ToString();
			TxtCoFaxNo.Text = dataSet.Tables[0].Rows[0]["Cong_fax"].ToString();
			TxtCoEmail.Text = dataSet.Tables[0].Rows[0]["Cong_email"].ToString();
			TxtCoTinCSTNo.Text = dataSet.Tables[0].Rows[0]["Cong_tin"].ToString();
			TxtCoTinVatNo.Text = dataSet.Tables[0].Rows[0]["Cong_vat"].ToString();
			TxtECoCCNo.Text = dataSet.Tables[0].Rows[0]["Cong_ecc"].ToString();
			fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["Cong_country"].ToString() + "'");
			DrpCoCountry.SelectedIndex = 0;
			fun.dropdownCountry(DrpCoCountry, DrpCoState);
			fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
			fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["Cong_country"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["Cong_state"].ToString() + "'");
			DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["Cong_state"].ToString();
			fun.dropdownCity(DrpCoCity, DrpCoState);
			fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["Cong_state"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["Cong_city"].ToString() + "'");
			DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["Cong_city"].ToString();
			DrpAdd.SelectedValue = dataSet.Tables[0].Rows[0]["AddType"].ToString();
			TxtAdd.Text = dataSet.Tables[0].Rows[0]["AddAmt"].ToString();
			DrpDed.SelectedValue = dataSet.Tables[0].Rows[0]["DeductionType"].ToString();
			TxtDeduct.Text = dataSet.Tables[0].Rows[0]["Deduction"].ToString();
			DrpPAF.SelectedValue = dataSet.Tables[0].Rows[0]["PFType"].ToString();
			TxtPf.Text = dataSet.Tables[0].Rows[0]["PF"].ToString();
			DrpServiceTax.SelectedValue = dataSet.Tables[0].Rows[0]["CENVAT"].ToString();
			DrpSED.SelectedValue = dataSet.Tables[0].Rows[0]["SEDType"].ToString();
			DrpAED.SelectedValue = dataSet.Tables[0].Rows[0]["AEDType"].ToString();
			TxtAed.Text = dataSet.Tables[0].Rows[0]["AED"].ToString();
			TxtSed.Text = dataSet.Tables[0].Rows[0]["SED"].ToString();
			DrpInsurance.SelectedValue = dataSet.Tables[0].Rows[0]["InsuranceType"].ToString();
			TxtInsurance.Text = dataSet.Tables[0].Rows[0]["Insurance"].ToString();
			DrpFreight.SelectedValue = dataSet.Tables[0].Rows[0]["FreightType"].ToString();
			Txtfreight.Text = dataSet.Tables[0].Rows[0]["Freight"].ToString();
			if (dataSet.Tables[0].Rows[0]["VAT"].ToString() != "0")
			{
				lblVAT.Text = "VAT";
				DrpCst.Visible = false;
				DrpVAT.SelectedValue = dataSet.Tables[0].Rows[0]["VAT"].ToString();
			}
			else
			{
				lblVAT.Text = "CST";
				DrpCst.Visible = true;
				DrpVAT.SelectedValue = dataSet.Tables[0].Rows[0]["CST"].ToString();
			}
			string cmdText5 = fun.select("Id", "tblExciseser_Master", "Live='1'");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				DrpServiceTax.SelectedValue = dataSet5.Tables[0].Rows[0]["Id"].ToString();
			}
			double num = 0.0;
			if (dataSet.Tables[0].Rows[0]["OtherAmt"] != DBNull.Value)
			{
				num = Convert.ToDouble(dataSet.Tables[0].Rows[0]["OtherAmt"]);
			}
			TxtOtherAmt.Text = num.ToString("0.00");
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("AmtInPer", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(float)));
			dataTable.Columns.Add(new DataColumn("RmnQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol1", typeof(string)));
			string cmdText = fun.select("tblACC_SalesInvoice_Details.Id,tblACC_SalesInvoice_Master.POId,tblACC_SalesInvoice_Details.ItemId,tblACC_SalesInvoice_Details.InvoiceNo,tblACC_SalesInvoice_Details.ItemId,tblACC_SalesInvoice_Details.Unit,tblACC_SalesInvoice_Details.Qty,tblACC_SalesInvoice_Details.ReqQty,tblACC_SalesInvoice_Details.AmtInPer,tblACC_SalesInvoice_Details.Rate", "tblACC_SalesInvoice_Details,tblACC_SalesInvoice_Master", " tblACC_SalesInvoice_Master.Id=tblACC_SalesInvoice_Details.MId AND tblACC_SalesInvoice_Master.Id='" + Invid + "' AND tblACC_SalesInvoice_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.Unit", "SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'AND SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ItemDesc"].ToString();
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["Unit"].ToString() + "' ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[9] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
				}
				double num = 0.0;
				double num2 = 0.0;
				string cmdText5 = fun.select("Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "'   And tblACC_SalesInvoice_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' Group By tblACC_SalesInvoice_Details.ItemId");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				double num3 = 0.0;
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
				}
				num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				num2 = num - num3;
				dataRow[3] = num;
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["AmtInPer"].ToString()).ToString("N2"));
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				dataRow[7] = num2;
				dataRow[8] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void BtnBuy_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			sqlConnection.Open();
			if (DrpByCountry.SelectedIndex != 0 && DrpByState.SelectedIndex != 0 && DrpByCity.SelectedIndex != 0 && DrpCoCountry.SelectedIndex != 0 && DrpCoState.SelectedIndex != 0 && DrpCoCity.SelectedIndex != 0 && TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) && TxtDateRemoval.Text != "" && fun.DateValidation(TxtDateRemoval.Text) && fun.EmailValidation(TxtByEmail.Text) && fun.EmailValidation(TxtCoEmail.Text) && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text) && TxtPf.Text != "" && fun.NumberValidationQty(TxtPf.Text) && TxtSed.Text != "" && fun.NumberValidationQty(TxtSed.Text) && TxtAed.Text != "" && fun.NumberValidationQty(TxtAed.Text) && Txtfreight.Text != "" && fun.NumberValidationQty(Txtfreight.Text) && TxtInsurance.Text != "" && fun.NumberValidationQty(TxtInsurance.Text))
			{
				string text = TimeOfIssue.Hour.ToString("D2") + ":" + TimeOfIssue.Minute.ToString("D2") + ":" + TimeOfIssue.Second.ToString("D2") + " " + TimeOfIssue.AmPm;
				string text2 = TimeOfRemove.Hour.ToString("D2") + ":" + TimeOfRemove.Minute.ToString("D2") + ":" + TimeOfRemove.Second.ToString("D2") + " " + TimeOfRemove.AmPm;
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string text3 = "";
				if (lblmodeid.Text == "2")
				{
					text3 = "VAT=";
				}
				else if (lblmodeid.Text == "3")
				{
					text3 = "CST=";
				}
				double num8 = Math.Round(Convert.ToDouble(TxtOtherAmt.Text), 2);
				string cmdText = fun.update("tblACC_SalesInvoice_Master", " SysDate='" + currDate + "',SysTime='" + currTime + "', SessionId='" + sId + "',DateOfIssueInvoice='" + fun.FromDate(TxtDateofIssueInvoice.Text) + "' ,DateOfRemoval='" + fun.FromDate(TxtDateRemoval.Text) + "',TimeOfIssueInvoice='" + text + "',TimeOfRemoval='" + text2 + "',DutyRate='" + TxtDutyRate.Text + "',CustomerCategory='" + DrpCategory.SelectedValue + "',NatureOfRemoval='" + DrpNatureremovable.SelectedValue + "',Commodity='" + DrpCommodity.SelectedValue + "',TariffHeading='" + lbltrafficNo.Text + "',ModeOfTransport='" + DrpTransport.SelectedValue + "',RRGCNo='" + TxtRRGCNo.Text + "',VehiRegNo='" + TxtRegistrationNo.Text + "',Buyer_name='" + TxtBYName.Text + "',  Buyer_add='" + TxtByAddress.Text + "',Buyer_country='" + DrpByCountry.SelectedValue + "',Buyer_state='" + DrpByState.SelectedValue + "', Buyer_city='" + DrpByCity.SelectedValue + "',Buyer_cotper='" + TxtByCName.Text + "',Buyer_ph='" + TxtByPhone.Text + "',Buyer_email='" + TxtByEmail.Text + "',Buyer_ecc='" + TxtByECCNo.Text + "',Buyer_tin='" + TxtByTINCSTNo.Text + "'  ,Buyer_mob='" + TxtByMobile.Text + "'  ,Buyer_fax='" + TxtByFaxNo.Text + "',Buyer_vat='" + TxtByTINVATNo.Text + "',Cong_name='" + TxtCName.Text + "',Cong_add='" + TxtCAddress.Text + "',Cong_Country='" + DrpCoCountry.SelectedValue + "',Cong_state='" + DrpCoState.SelectedValue + "',Cong_city='" + DrpCoCity.SelectedValue + "',Cong_cotper='" + TxtCoPersonName.Text + "' ,  Cong_ph='" + TxtCoPhoneNo.Text + "',Cong_email='" + TxtCoEmail.Text + "',Cong_ecc='" + TxtECoCCNo.Text + "',Cong_tin='" + TxtCoTinCSTNo.Text + "',Cong_mob='" + TxtCoMobileNo.Text + "',Cong_fax='" + TxtCoFaxNo.Text + "',Cong_vat='" + TxtCoTinVatNo.Text + "',    AddType='" + DrpAdd.SelectedValue + "',AddAmt='" + TxtAdd.Text + "',DeductionType='" + DrpDed.SelectedValue + "',Deduction='" + TxtDeduct.Text + "',PFType='" + DrpPAF.SelectedValue + "' ,PF='" + TxtPf.Text + "',CENVAT='" + DrpServiceTax.SelectedValue + "',SED='" + TxtSed.Text + "',AED='" + TxtAed.Text + "',SelectedCST='" + DrpCst.SelectedValue + "'," + text3 + "'" + DrpVAT.SelectedValue + "',FreightType='" + DrpFreight.SelectedValue + "',Freight='" + Txtfreight.Text + "',InsuranceType='" + DrpInsurance.SelectedValue + "',Insurance='" + TxtInsurance.Text + "',SEDType='" + DrpSED.SelectedValue + "',AEDType='" + DrpAED.SelectedValue + "',OtherAmt='" + num8 + "'", "CompId='" + CompId + "' And InvoiceNo='" + InvNo + "' And Id='" + Invid + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("TxtAmt")).Text != "" && ((TextBox)row.FindControl("TxtReqQty")).Text != "")
				{
					int num9 = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
					num4 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblQty")).Text.ToString()).ToString("N3"));
					num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblReqQty")).Text.ToString()).ToString("N3"));
					num7 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtReqQty")).Text.ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblAmtInPer")).Text.ToString()).ToString("N3"));
					string cmdText2 = fun.select("sum(AmtInPer) As Amt", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' And tblACC_SalesInvoice_Details.ItemId='" + num9 + "'AND tblACC_SalesInvoice_Master.Id='" + Invid + "'   Group By tblACC_SalesInvoice_Details.ItemId ");
					SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					double num10 = 100.0;
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						double num11 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Amt"].ToString()).ToString("N2"));
						num10 = 100.0 - num11;
					}
					num5 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtAmt")).Text.ToString()).ToString("N2"));
					string cmdText3 = fun.select("Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "'  And tblACC_SalesInvoice_Details.ItemId='" + num9 + "' Group By tblACC_SalesInvoice_Details.ItemId");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					double num12 = 0.0;
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num12 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
					}
					num3 = num4 - num12;
					if (num3 + num2 >= num7 && num5 <= num6 + num10)
					{
						int num13 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblRate")).Text.ToString()).ToString("N2"));
						string selectedValue = ((DropDownList)row.FindControl("DrpUnitQty")).SelectedValue;
						string cmdText4 = fun.update("tblACC_SalesInvoice_Details", "ReqQty='" + num7 + "',Unit='" + selectedValue + "',AmtInPer='" + num5 + "'", "Id='" + num13 + "' And MId='" + Invid + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
						sqlCommand2.ExecuteNonQuery();
					}
					else
					{
						num++;
					}
				}
			}
			if (num > 0)
			{
				string empty = string.Empty;
				empty = "Input data is invalid.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			else
			{
				base.Response.Redirect("SalesInvoice_Edit.aspx?ModId=11&SubModId=51");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((TextBox)row.FindControl("TxtReqQty")).Visible = true;
					((TextBox)row.FindControl("TxtAmt")).Visible = true;
					((Label)row.FindControl("lblAmtInPer")).Visible = false;
					((Label)row.FindControl("lblReqQty")).Visible = false;
					((Label)row.FindControl("lblUnitQty")).Visible = false;
					((DropDownList)row.FindControl("DrpUnitQty")).Visible = true;
				}
				else
				{
					((Label)row.FindControl("lblAmtInPer")).Visible = true;
					((Label)row.FindControl("lblReqQty")).Visible = true;
					((TextBox)row.FindControl("TxtReqQty")).Visible = false;
					((TextBox)row.FindControl("TxtAmt")).Visible = false;
					((Label)row.FindControl("lblUnitQty")).Visible = true;
					((DropDownList)row.FindControl("DrpUnitQty")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ButtonCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SalesInvoice_Edit.aspx?ModId=11&SubModId=51");
	}

	protected void Btngoods_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[3];
	}

	protected void BtnCNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void DrpByCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
		TabContainer1.ActiveTab = TabContainer1.Tabs[0];
	}

	protected void DrpByState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DrpByCity, DrpByState);
		TabContainer1.ActiveTab = TabContainer1.Tabs[0];
	}

	protected void DrpCoCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void DrpCoState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DrpCoCity, DrpCoState);
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtBYName.Text);
			string cmdText = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtByAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpByCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpByCountry, DrpByState);
				fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
				fun.dropdownStatebyId(DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpByState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpByCity, DrpByState);
				fun.dropdownCitybyId(DrpByCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpByCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtByFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtByCName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtByPhone.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtByTINCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtByTINVATNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtByMobile.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtByEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtByECCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtBYName.Text = "";
				TxtByAddress.Text = "";
				TxtByFaxNo.Text = "";
				TxtByCName.Text = "";
				TxtByPhone.Text = "";
				TxtByTINCSTNo.Text = "";
				TxtByTINVATNo.Text = "";
				TxtByMobile.Text = "";
				TxtByEmail.Text = "";
				TxtByECCNo.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button4_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtCName.Text);
			string cmdText = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtCAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpCoCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
				fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpCoCity, DrpCoState);
				fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtCoFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtCoPersonName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtCoPhoneNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtCoTinCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtCoTinVatNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtCoMobileNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtCoEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtECoCCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtCName.Text = "";
				TxtCAddress.Text = "";
				TxtCoFaxNo.Text = "";
				TxtCoPersonName.Text = "";
				TxtCoPhoneNo.Text = "";
				TxtCoTinCSTNo.Text = "";
				TxtCoTinVatNo.Text = "";
				TxtCoMobileNo.Text = "";
				TxtCoEmail.Text = "";
				TxtECoCCNo.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button6_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtBYName.Text);
			string cmdText = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtCName.Text = dataSet.Tables[0].Rows[0]["Customer"].ToString();
				TxtCAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpCoCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
				fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpCoCity, DrpCoState);
				fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtCoFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtCoPersonName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtCoPhoneNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtCoTinCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtCoTinVatNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtCoMobileNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtCoEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtECoCCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtCName.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SalesInvoice_Edit.aspx?ModId=11&SubModId=51");
	}

	protected void Button8_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SalesInvoice_Edit.aspx?ModId=11&SubModId=51");
	}

	protected void Button7_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SalesInvoice_Edit.aspx?ModId=11&SubModId=51");
	}

	protected void DrpCommodity_SelectedIndexChanged(object sender, EventArgs e)
	{
		lbltrafficNo.Text = fun.ExciseCommodity(Convert.ToInt32(DrpCommodity.SelectedValue));
	}
}

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

public class Module_Accounts_Transactions_ServiceTaxInvoice_Edit_Details : Page, IRequiresSessionState
{
	protected Label lblSrTaxInvoiceNo;

	protected Label lblInvDate;

	protected Label LblWONo;

	protected SqlDataSource SqlCat;

	protected SqlDataSource SqlTaxableServices;

	protected Label LblPONo;

	protected Label lblPodt;

	protected DropDownList DrpCategory;

	protected TextBox TxtDutyRate;

	protected RequiredFieldValidator Reqrateofduty;

	protected DropDownList DrpTaxableServices;

	protected TextBox TxtDateofIssueInvoice;

	protected CalendarExtender TxtDateofIssueInvoice_CalendarExtender;

	protected RequiredFieldValidator ReqDateofinvoce;

	protected RegularExpressionValidator RegDateOfIssInvoiceEdit;

	protected TimeSelector TimeSelector1;

	protected TextBox TxtBYName;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected RequiredFieldValidator ReqByName;

	protected Button Button2;

	protected TextBox TxtByAddress;

	protected RequiredFieldValidator ReqByAddress;

	protected DropDownList DrpByCountry;

	protected RequiredFieldValidator ReqByCName0;

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

	protected Button Button1;

	protected TabPanel TabPanel1;

	protected TextBox TxtCName;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator ReqCName;

	protected Button Button3;

	protected Button Button5;

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

	protected RegularExpressionValidator RegEmailvalConsigneeEdit;

	protected TextBox TxtCoFaxNo;

	protected RequiredFieldValidator ReqCFaxNo;

	protected TextBox TxtCoTinVatNo;

	protected RequiredFieldValidator ReqCTinVatno;

	protected TextBox TxtECoCCNo;

	protected RequiredFieldValidator ReqCECCNo;

	protected TextBox TxtCoTinCSTNo;

	protected RequiredFieldValidator ReqCTINcstno;

	protected Button BtnCNext;

	protected Button Button4;

	protected TabPanel TabPanel2;

	protected GridView GridView1;

	protected Panel Panel1;

	protected SqlDataSource SqlUnitQty;

	protected SqlDataSource SqlUnit;

	protected Button Btngoods;

	protected Button Button6;

	protected TabPanel TabPanel3;

	protected TextBox TxtAdd;

	protected RequiredFieldValidator ReqAdd;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected DropDownList DrpAdd;

	protected TextBox TxtDeduct;

	protected RequiredFieldValidator ReqDed;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList DrpDed;

	protected DropDownList DrpServiceTax;

	protected SqlDataSource SqlServiceTax;

	protected Button BtnUpdate;

	protected Button BtnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string invId = "";

	private string CCode = "";

	private string InvNo = "";

	private SqlConnection con;

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
			invId = fun.Decrypt(base.Request.QueryString["invid"].ToString());
			InvNo = fun.Decrypt(base.Request.QueryString["InvNo"].ToString());
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
			new DataSet();
			string cmdText = fun.select("Id,SysDate,SysTime,CompId,FinYearId,SessionId,InvoiceNo,POId,PONo,WONo,DateOfIssueInvoice,TimeOfIssueInvoice,DutyRate,CustomerCode,CustomerCategory,Buyer_name,Buyer_add,Buyer_city,Buyer_state,Buyer_country,Buyer_cotper,Buyer_ph,Buyer_email,Buyer_ecc,Buyer_tin,Buyer_mob,Buyer_fax,Buyer_vat,Cong_name,Cong_add,Cong_city,Cong_state,Cong_country,Cong_cotper,Cong_ph,Cong_email,Cong_ecc,Cong_tin,Cong_mob,Cong_fax,Cong_vat,AddType,AddAmt,DeductionType,Deduction,ServiceTax,TaxableServices", "tblACC_ServiceTaxInvoice_Master", " CompId='" + CompId + "'  And Id='" + invId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblSrTaxInvoiceNo.Text = dataSet.Tables[0].Rows[0]["InvoiceNo"].ToString();
				LblPONo.Text = dataSet.Tables[0].Rows[0]["PONo"].ToString();
				string text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
				string[] array = text.Split(',');
				string text2 = "";
				for (int i = 0; i < array.Length - 1; i++)
				{
					string cmdText2 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[i] + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						text2 = text2 + dataSet2.Tables[0].Rows[0][0].ToString() + ",";
					}
					LblWONo.Text = text2;
				}
				string cmdText3 = fun.select("PODate", "SD_Cust_PO_Master", "POId='" + dataSet.Tables[0].Rows[0]["POId"].ToString() + "' ANd CompId='" + CompId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					lblPodt.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0][0].ToString());
				}
				string fD = dataSet.Tables[0].Rows[0]["SysDate"].ToString();
				lblInvDate.Text = fun.FromDateDMY(fD);
				TxtDateofIssueInvoice.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
				TxtDutyRate.Text = dataSet.Tables[0].Rows[0]["DutyRate"].ToString();
				DrpCategory.SelectedValue = dataSet.Tables[0].Rows[0]["CustomerCategory"].ToString();
				DrpTaxableServices.SelectedValue = dataSet.Tables[0].Rows[0]["TaxableServices"].ToString();
				TxtByCName.Text = dataSet.Tables[0].Rows[0]["Buyer_cotper"].ToString();
				TxtByAddress.Text = dataSet.Tables[0].Rows[0]["Buyer_add"].ToString();
				TxtBYName.Text = dataSet.Tables[0].Rows[0]["Buyer_name"].ToString();
				TxtByPhone.Text = dataSet.Tables[0].Rows[0]["Buyer_ph"].ToString();
				TxtByMobile.Text = dataSet.Tables[0].Rows[0]["Buyer_mob"].ToString();
				TxtByFaxNo.Text = dataSet.Tables[0].Rows[0]["Buyer_fax"].ToString();
				TxtByEmail.Text = dataSet.Tables[0].Rows[0]["Buyer_email"].ToString();
				TxtByTINCSTNo.Text = dataSet.Tables[0].Rows[0]["Buyer_tin"].ToString();
				TxtByTINVATNo.Text = dataSet.Tables[0].Rows[0]["Buyer_vat"].ToString();
				TxtByECCNo.Text = dataSet.Tables[0].Rows[0]["Buyer_ecc"].ToString();
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
				TxtAdd.Text = dataSet.Tables[0].Rows[0]["AddAmt"].ToString();
				TxtDeduct.Text = dataSet.Tables[0].Rows[0]["Deduction"].ToString();
				DrpServiceTax.SelectedValue = dataSet.Tables[0].Rows[0]["ServiceTax"].ToString();
				DrpAdd.SelectedValue = dataSet.Tables[0].Rows[0]["AddType"].ToString();
				DrpDed.SelectedValue = dataSet.Tables[0].Rows[0]["DeductionType"].ToString();
				fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["Buyer_country"].ToString() + "'");
				DrpByCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpByCountry, DrpByState);
				fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
				fun.dropdownStatebyId(DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["Buyer_country"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["Buyer_state"].ToString() + "'");
				DrpByState.SelectedValue = dataSet.Tables[0].Rows[0]["Buyer_state"].ToString();
				fun.dropdownCity(DrpByCity, DrpByState);
				fun.dropdownCitybyId(DrpByCity, "SId='" + dataSet.Tables[0].Rows[0]["Buyer_state"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["Buyer_city"].ToString() + "'");
				DrpByCity.SelectedValue = dataSet.Tables[0].Rows[0]["Buyer_city"].ToString();
				fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["Cong_country"].ToString() + "'");
				DrpCoCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
				fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["Cong_country"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["Cong_state"].ToString() + "'");
				DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["Cong_state"].ToString();
				fun.dropdownCity(DrpCoCity, DrpCoState);
				fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["Cong_state"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["Cong_city"].ToString() + "'");
				DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["Cong_city"].ToString();
				string text3 = dataSet.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
				char[] separator = new char[2] { ':', ' ' };
				string[] array2 = text3.Split(separator);
				string tM = array2[3];
				int h = Convert.ToInt32(array2[0]);
				int m = Convert.ToInt32(array2[1]);
				int s = Convert.ToInt32(array2[2]);
				fun.TimeSelector(h, m, s, tM, TimeSelector1);
			}
			fillgrid();
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("AmtInPer", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(float)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RemainingQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Symbol1", typeof(string)));
			string cmdText = fun.select("tblACC_ServiceTaxInvoice_Details.Id,tblACC_ServiceTaxInvoice_Details.InvoiceNo,tblACC_ServiceTaxInvoice_Details.ItemId,tblACC_ServiceTaxInvoice_Details.Unit,tblACC_ServiceTaxInvoice_Details.Qty,tblACC_ServiceTaxInvoice_Details.ReqQty,tblACC_ServiceTaxInvoice_Details.AmtInPer,tblACC_ServiceTaxInvoice_Details.Rate,tblACC_ServiceTaxInvoice_Master.POId", "tblACC_ServiceTaxInvoice_Details,tblACC_ServiceTaxInvoice_Master", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id AND tblACC_ServiceTaxInvoice_Master.Id= '" + invId + "' AND tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", string.Concat(" SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='", CompId, "' AND SD_Cust_PO_Master.POId='", dataSet.Tables[0].Rows[i]["POId"], "'AND SD_Cust_PO_Details.Id='", dataSet.Tables[0].Rows[i]["ItemId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ItemDesc"].ToString();
				}
				string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[2] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["AmtInPer"].ToString()).ToString("N2"));
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				double num = 0.0;
				double num2 = 0.0;
				string cmdText4 = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "' And tblACC_ServiceTaxInvoice_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num3 = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
				}
				num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				num2 = num - num3;
				dataRow[7] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataRow[8] = num2;
				string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["Unit"].ToString() + "' ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[9] = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
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
			int num7 = 0;
			sqlConnection.Open();
			if (DrpByCountry.SelectedIndex == 0 || DrpByState.SelectedIndex == 0 || DrpByCity.SelectedIndex == 0 || DrpCoCountry.SelectedIndex == 0 || DrpCoState.SelectedIndex == 0 || DrpCoCity.SelectedIndex == 0)
			{
				return;
			}
			if (TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) && TxtDutyRate.Text != "" && TxtBYName.Text != "" && TxtByAddress.Text != "" && TxtByCName.Text != "" && TxtByPhone.Text != "" && TxtByEmail.Text != "" && TxtByECCNo.Text != "" && TxtByTINCSTNo.Text != "" && TxtByMobile.Text != "" && TxtByFaxNo.Text != "" && TxtByTINVATNo.Text != "" && TxtCName.Text != "" && TxtCAddress.Text != "" && TxtCoPersonName.Text != "" && TxtCoPhoneNo.Text != "" && TxtCoEmail.Text != "" && TxtECoCCNo.Text != "" && TxtCoTinCSTNo.Text != "" && TxtCoMobileNo.Text != "" && TxtCoFaxNo.Text != "" && TxtCoTinVatNo.Text != "" && TxtAdd.Text != "" && TxtDeduct.Text != "" && fun.EmailValidation(TxtByEmail.Text) && fun.EmailValidation(TxtCoEmail.Text) && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text))
			{
				string text = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm;
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string cmdText = fun.update("tblACC_ServiceTaxInvoice_Master", " SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + sId + "',DateOfIssueInvoice='" + fun.FromDate(TxtDateofIssueInvoice.Text) + "' ,TimeOfIssueInvoice='" + text + "',DutyRate='" + TxtDutyRate.Text + "',CustomerCategory='" + DrpCategory.SelectedValue + "',Buyer_name='" + TxtBYName.Text + "',  Buyer_add='" + TxtByAddress.Text + "',Buyer_country='" + DrpByCountry.SelectedValue + "',Buyer_state='" + DrpByState.SelectedValue + "', Buyer_city='" + DrpByCity.SelectedValue + "',Buyer_cotper='" + TxtByCName.Text + "',Buyer_ph='" + TxtByPhone.Text + "',Buyer_email='" + TxtByEmail.Text + "',Buyer_ecc='" + TxtByECCNo.Text + "',Buyer_tin='" + TxtByTINCSTNo.Text + "'  ,Buyer_mob='" + TxtByMobile.Text + "'  ,Buyer_fax='" + TxtByFaxNo.Text + "',Buyer_vat='" + TxtByTINVATNo.Text + "',Cong_name='" + TxtCName.Text + "',Cong_add='" + TxtCAddress.Text + "',Cong_Country='" + DrpCoCountry.SelectedValue + "',Cong_state='" + DrpCoState.SelectedValue + "',Cong_city='" + DrpCoCity.SelectedValue + "',Cong_cotper='" + TxtCoPersonName.Text + "' ,  Cong_ph='" + TxtCoPhoneNo.Text + "',Cong_email='" + TxtCoEmail.Text + "',Cong_ecc='" + TxtECoCCNo.Text + "',Cong_tin='" + TxtCoTinCSTNo.Text + "',Cong_mob='" + TxtCoMobileNo.Text + "',Cong_fax='" + TxtCoFaxNo.Text + "',Cong_vat='" + TxtCoTinVatNo.Text + "',AddType='" + DrpAdd.SelectedValue + "',AddAmt='" + TxtAdd.Text + "',DeductionType='" + DrpDed.SelectedValue + "',Deduction='" + TxtDeduct.Text + "',ServiceTax='" + DrpServiceTax.SelectedValue + "',TaxableServices= '" + DrpTaxableServices.SelectedValue + "'", "CompId='" + CompId + "' And Id='" + invId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("TxtAmt")).Text != "" && ((TextBox)row.FindControl("TxtReqQty")).Text != "")
				{
					int num8 = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
					num4 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblQty")).Text.ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblReqQty")).Text.ToString()).ToString("N3"));
					num2 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtReqQty")).Text.ToString()).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtAmt")).Text.ToString()).ToString("N2"));
					num7 = Convert.ToInt32(((DropDownList)row.FindControl("DrpUnitQty")).SelectedValue);
					string cmdText2 = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'And tblACC_ServiceTaxInvoice_Details.ItemId='" + num8 + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
					SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					double num9 = 0.0;
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						num9 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
					}
					num3 = num4 - num9;
					if (num3 + num6 >= num2)
					{
						Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblRate")).Text.ToString()).ToString("N2"));
						_ = ((DropDownList)row.FindControl("DrpUnitQty")).SelectedValue;
						int num10 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						string cmdText3 = fun.update("tblACC_ServiceTaxInvoice_Details", "ReqQty='" + num2 + "',Unit='" + num7 + "',AmtInPer='" + num5 + "'", "MId='" + invId + "' AND Id='" + num10 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
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
				base.Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
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
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid();
	}

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((TextBox)row.FindControl("TxtReqQty")).Visible = true;
					((TextBox)row.FindControl("TxtAmt")).Visible = true;
					((Label)row.FindControl("lblAmt")).Visible = false;
					((Label)row.FindControl("lblReqQty")).Visible = false;
					((Label)row.FindControl("lblUnitQty")).Visible = false;
					((DropDownList)row.FindControl("DrpUnitQty")).Visible = true;
				}
				else
				{
					((Label)row.FindControl("lblAmt")).Visible = true;
					((Label)row.FindControl("lblReqQty")).Visible = true;
					((TextBox)row.FindControl("TxtReqQty")).Visible = false;
					((TextBox)row.FindControl("TxtAmt")).Visible = false;
					((DropDownList)row.FindControl("DrpUnitQty")).Visible = false;
					((Label)row.FindControl("lblUnitQty")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
	}

	protected void Button3_Click(object sender, EventArgs e)
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

	protected void Button4_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
	}

	protected void Button5_Click(object sender, EventArgs e)
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

	protected void Button6_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
	}
}

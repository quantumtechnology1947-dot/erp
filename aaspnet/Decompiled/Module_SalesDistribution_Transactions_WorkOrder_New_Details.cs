using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_WorkOrder_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private string pono = "";

	private int enqId;

	private int CompId;

	private string sId = "";

	private string PoId = "";

	private int FinYearId;

	private SqlConnection con;

	private string connStr = "";

	protected Label lblCustomerName;

	protected Label hfCustId;

	protected Label hfPoNo;

	protected Label lblPONo;

	protected Label hfEnqId;

	protected DropDownList DDLTaskWOType;

	protected RequiredFieldValidator ReqWoType;

	protected DropDownList DDLSubcategory;

	protected RequiredFieldValidator ReqWoType0;

	protected TextBox txtWorkOrderDate;

	protected CalendarExtender txtWorkOrderDate_CalendarExtender;

	protected RequiredFieldValidator ReqWoDate;

	protected RegularExpressionValidator RegWorkOrderDate;

	protected TextBox txtProjectTitle;

	protected RequiredFieldValidator ReqProjectTitle;

	protected TextBox txtProjectLeader;

	protected RequiredFieldValidator ReqProLead;

	protected DropDownList DDLBusinessGroup;

	protected RequiredFieldValidator ReqBG;

	protected TextBox txtTaskTargetDAP_FDate;

	protected CalendarExtender txtTaskTargetDAP_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqDapFdt;

	protected RegularExpressionValidator RegTaskTargetDAP_FDate;

	protected TextBox txtTaskTargetDAP_TDate;

	protected CalendarExtender txtTaskTargetDAP_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqDApToDt;

	protected RegularExpressionValidator RegTaskTargetDAP_TDate;

	protected TextBox txtTaskDesignFinalization_FDate;

	protected CalendarExtender txtTaskDesignFinalization_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqFinFDt;

	protected RegularExpressionValidator RegTaskDesignFinalization_FDate;

	protected TextBox txtTaskDesignFinalization_TDate;

	protected CalendarExtender txtTaskDesignFinalization_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqFinToDt;

	protected RegularExpressionValidator RegTaskDesignFinalization_TDate;

	protected TextBox txtTaskTargetManufg_FDate;

	protected CalendarExtender txtTaskTargetManufg_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqMfgFrDt;

	protected RegularExpressionValidator RegTaskTargetManufg_FDate;

	protected TextBox txtTaskTargetManufg_TDate;

	protected CalendarExtender txtTaskTargetManufg_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqMfgToDt;

	protected RegularExpressionValidator RegTaskTargetManufg_TDate;

	protected TextBox txtTaskTargetTryOut_FDate;

	protected CalendarExtender txtTaskTargetTryOut_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqTryOutFrDt;

	protected RegularExpressionValidator RegTaskTargetTryOut_FDate;

	protected TextBox txtTaskTargetTryOut_TDate;

	protected CalendarExtender txtTaskTargetTryOut_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqTryOutTODt;

	protected RegularExpressionValidator RegTaskTargetTryOut_TDate;

	protected TextBox txtTaskTargetDespach_FDate;

	protected CalendarExtender txtTaskTargetDespach_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqDesptFrDt;

	protected RegularExpressionValidator RegTaskTargetDespach_FDate;

	protected TextBox txtTaskTargetDespach_TDate;

	protected CalendarExtender txtTaskTargetDespach_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqDisptToDt;

	protected RegularExpressionValidator RegTaskTargetDespach_TDate;

	protected TextBox txtTaskTargetAssembly_FDate;

	protected CalendarExtender txtTaskTargetAssembly_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqAssFrDt;

	protected RegularExpressionValidator RegTaskTargetAssembly_FDate;

	protected TextBox txtTaskTargetAssembly_TDate;

	protected CalendarExtender txtTaskTargetAssembly_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqAssToDt;

	protected RegularExpressionValidator RegTaskTargetAssembly_TDate;

	protected TextBox txtTaskTargetInstalation_FDate;

	protected CalendarExtender txtTaskTargetInstalation_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqInstallFrDt;

	protected RegularExpressionValidator RegTaskTargetInstalation_FDate;

	protected TextBox txtTaskTargetInstalation_TDate;

	protected CalendarExtender txtTaskTargetInstalation_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqInstalFrDt;

	protected RegularExpressionValidator RegTaskTargetInstalation_TDate;

	protected TextBox txtTaskCustInspection_FDate;

	protected CalendarExtender txtTaskCustInspection_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqInsptFrDt;

	protected RegularExpressionValidator RegTaskCustInspection_FDate;

	protected TextBox txtTaskCustInspection_TDate;

	protected CalendarExtender txtTaskCustInspection_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqInspFrDt;

	protected RegularExpressionValidator RegTaskCustInspection_TDate;

	protected Label lblMaterialProcurement;

	protected TextBox txtManufMaterialDate;

	protected CalendarExtender txtManufMaterialDate_CalendarExtender;

	protected RequiredFieldValidator ReqManufMaterialDate;

	protected RegularExpressionValidator RegManufMaterialDate;

	protected DropDownList DDLBuyer;

	protected RequiredFieldValidator ReqBuyer;

	protected TextBox txtBoughtoutMaterialDate;

	protected CalendarExtender txtBoughtoutMaterialDate_CalendarExtender;

	protected RequiredFieldValidator ReqBoughtoutMaterialDate;

	protected RegularExpressionValidator RegBoughtoutMaterialDate;

	protected Button btnTaskNext;

	protected TabPanel TabPanel1;

	protected TextBox txtShippingAdd;

	protected RequiredFieldValidator ReqShipAdd;

	protected DropDownList DDLShippingCountry;

	protected RequiredFieldValidator ReqShipCountry;

	protected DropDownList DDLShippingState;

	protected RequiredFieldValidator ReqShipState;

	protected DropDownList DDLShippingCity;

	protected RequiredFieldValidator ReqShipCity;

	protected TextBox txtShippingContactPerson1;

	protected RequiredFieldValidator ReqShipContPer;

	protected TextBox txtShippingContactNo1;

	protected RequiredFieldValidator ReqShipContNo1;

	protected TextBox txtShippingEmail1;

	protected RequiredFieldValidator ReqShipMail1;

	protected RegularExpressionValidator RegEmail1;

	protected TextBox txtShippingContactPerson2;

	protected RequiredFieldValidator ReqShipContper2;

	protected TextBox txtShippingContactNo2;

	protected RequiredFieldValidator ReqShipContNo2;

	protected TextBox txtShippingEmail2;

	protected RequiredFieldValidator ReqshipMail2;

	protected RegularExpressionValidator RegEmail2;

	protected TextBox txtShippingFaxNo;

	protected RequiredFieldValidator ReqShipFax;

	protected TextBox txtShippingEccNo;

	protected RequiredFieldValidator ReqShipECC;

	protected TextBox txtShippingTinCstNo;

	protected RequiredFieldValidator ReqShipTinCst;

	protected TextBox txtShippingTinVatNo;

	protected RequiredFieldValidator ReqShipTinVat;

	protected Button btnShippingNext;

	protected TabPanel TabPanel2;

	protected TextBox txtItemCode;

	protected RequiredFieldValidator ReqItemCode;

	protected TextBox txtDescOfItem;

	protected RequiredFieldValidator ReqItemDesc;

	protected TextBox txtQty;

	protected RequiredFieldValidator ReqItemQty;

	protected RegularExpressionValidator RegQty;

	protected Button btnProductSubmit;

	protected Button btnProductNext;

	protected GridView GridView1;

	protected Label lblMessage;

	protected TabPanel TabPanel3;

	protected CheckBox CKInstractionPrimerPainting;

	protected CheckBox CKInstractionPainting;

	protected CheckBox CKInstractionSelfCertRept;

	protected TextBox txtInstractionOther;

	protected RequiredFieldValidator ReqDesptFrDt0;

	protected TextBox txtInstractionExportCaseMark;

	protected RequiredFieldValidator ReqDesptFrDt1;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected Button btnSubmit;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void Page_Load(object sender, EventArgs e)
	{
		try
		{
			hfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = hfCustId.Text;
			hfPoNo.Text = base.Request.QueryString["PONo"].ToString();
			lblPONo.Text = base.Request.QueryString["PONo"].ToString();
			PoId = base.Request.QueryString["PoId"].ToString();
			pono = hfPoNo.Text;
			hfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(hfEnqId.Text);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblMessage.Text = "";
			txtWorkOrderDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetDAP_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetDAP_TDate.Attributes.Add("readonly", "readonly");
			txtTaskDesignFinalization_FDate.Attributes.Add("readonly", "readonly");
			txtTaskDesignFinalization_TDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetManufg_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetManufg_TDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetTryOut_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetTryOut_TDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetDespach_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetDespach_TDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetAssembly_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetAssembly_TDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetInstalation_FDate.Attributes.Add("readonly", "readonly");
			txtTaskTargetInstalation_TDate.Attributes.Add("readonly", "readonly");
			txtTaskCustInspection_FDate.Attributes.Add("readonly", "readonly");
			txtTaskCustInspection_TDate.Attributes.Add("readonly", "readonly");
			txtManufMaterialDate.Attributes.Add("readonly", "readonly");
			txtBoughtoutMaterialDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.dropdownBuyer(DDLBuyer);
				fun.dropdownBG(DDLBusinessGroup);
				fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
				con.Open();
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "Select");
				DDLSubcategory.Items.Insert(0, "Select");
				DataSet dataSet = new DataSet();
				string cmdText2 = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblCustomerName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				}
				con.Close();
			}
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void DDLShippingCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void DDLShippingState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDLShippingCity, DDLShippingState);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void DDLShippingCity_SelectedIndexChanged(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void btnProductSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtDescOfItem.Text != "" && txtItemCode.Text != "" && txtQty.Text != "" && fun.NumberValidationQty(txtQty.Text))
			{
				string cmdText = fun.insert("SD_Cust_WorkOrder_Products_Temp", "SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + txtItemCode.Text + "','" + txtDescOfItem.Text + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text.ToString()).ToString("N3")) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			FillGrid();
			txtDescOfItem.Text = "";
			txtItemCode.Text = "";
			txtQty.Text = "";
		}
		catch (Exception)
		{
		}
		finally
		{
			TabContainer1.ActiveTab = TabContainer1.Tabs[2];
		}
	}

	protected void btnTaskNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void btnShippingNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void btnProductNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[3];
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_New.aspx?ModId=2&SubModId=13");
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		con.Open();
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		int num = 0;
		int num2 = 0;
		try
		{
			string cmdText = fun.select("HasSubCat", "tblSD_WO_Category", "CId='" + DDLTaskWOType.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
			string text = "0";
			if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["HasSubCat"]) == 1)
			{
				text = ((!(DDLSubcategory.SelectedValue != "Select")) ? "Select" : DDLSubcategory.SelectedValue);
			}
			string text2 = "";
			string text3 = "";
			if (text != "Select")
			{
				string wOChar = fun.getWOChar(DDLTaskWOType.SelectedItem.Text);
				if (DDLSubcategory.SelectedValue != "Select")
				{
					fun.getWOChar(DDLSubcategory.SelectedItem.Text);
				}
				string cmdText2 = fun.select("WONo", "SD_Cust_WorkOrder_Master", "CId='" + DDLTaskWOType.SelectedValue + "' AND SCId='" + text + "' order by Id desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(DS, "SD_Cust_WorkOrder_Master");
				text2 = ((DS.Tables[0].Rows.Count <= 0) ? (wOChar + "0001") : (wOChar + (Convert.ToInt32(fun.getWO(DS.Tables[0].Rows[0]["WONo"].ToString())) + 1).ToString("D4")));
			}
			string cmdText3 = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter3.Fill(dataSet2, "SD_Cust_WorkOrder_Products_Temp");
			if (dataSet2.Tables[0].Rows.Count > 0 && text != "Select")
			{
				if (DDLBuyer.SelectedValue != "Select" && DDLTaskWOType.SelectedValue != "Select" && text != "Select" && text2 != "" && txtWorkOrderDate.Text != "" && txtTaskTargetDAP_FDate.Text != "" && txtTaskTargetDAP_TDate.Text != "" && txtTaskDesignFinalization_FDate.Text != "" && txtTaskDesignFinalization_TDate.Text != "" && txtTaskTargetManufg_FDate.Text != "" && txtTaskTargetManufg_TDate.Text != "" && txtTaskTargetTryOut_FDate.Text != "" && txtTaskTargetTryOut_TDate.Text != "" && txtTaskTargetDespach_FDate.Text != "" && txtTaskTargetDespach_TDate.Text != "" && txtTaskTargetAssembly_FDate.Text != "" && txtTaskTargetAssembly_TDate.Text != "" && txtTaskTargetInstalation_FDate.Text != "" && txtTaskTargetInstalation_TDate.Text != "" && txtTaskCustInspection_FDate.Text != "" && txtTaskCustInspection_TDate.Text != "" && CustCode.ToString() != "" && enqId != 0 && pono.ToString() != "" && DDLTaskWOType.SelectedValue != "Select" && txtProjectTitle.Text != "" && txtProjectLeader.Text != "" && DDLBusinessGroup.SelectedValue != "Select" && txtShippingAdd.Text != "" && DDLShippingCountry.SelectedValue != "Select" && DDLShippingState.SelectedValue != "Select" && DDLShippingCity.SelectedValue != "Select" && txtShippingContactPerson1.Text != "" && txtShippingContactNo1.Text != "" && txtShippingEmail1.Text != "" && txtShippingContactPerson2.Text != "" && txtShippingContactNo2.Text != "" && txtShippingEmail2.Text != "" && txtShippingFaxNo.Text != "" && txtShippingEccNo.Text != "" && txtShippingTinCstNo.Text != "" && txtShippingTinVatNo.Text != "" && txtInstractionOther.Text != "" && txtInstractionExportCaseMark.Text != "" && fun.EmailValidation(txtShippingEmail1.Text) && fun.EmailValidation(txtShippingEmail2.Text) && fun.DateValidation(txtWorkOrderDate.Text) && fun.DateValidation(txtTaskTargetDAP_FDate.Text) && fun.DateValidation(txtTaskTargetDAP_TDate.Text) && fun.DateValidation(txtTaskDesignFinalization_FDate.Text) && fun.DateValidation(txtTaskDesignFinalization_TDate.Text) && fun.DateValidation(txtTaskTargetManufg_FDate.Text) && fun.DateValidation(txtTaskTargetManufg_TDate.Text) && fun.DateValidation(txtTaskTargetTryOut_FDate.Text) && fun.DateValidation(txtTaskTargetTryOut_TDate.Text) && fun.DateValidation(txtTaskTargetDespach_FDate.Text) && fun.DateValidation(txtTaskTargetDespach_TDate.Text) && fun.DateValidation(txtTaskTargetAssembly_FDate.Text) && fun.DateValidation(txtTaskTargetAssembly_TDate.Text) && fun.DateValidation(txtTaskTargetInstalation_FDate.Text) && fun.DateValidation(txtTaskTargetInstalation_TDate.Text) && fun.DateValidation(txtTaskCustInspection_FDate.Text) && fun.DateValidation(txtTaskCustInspection_TDate.Text) && fun.DateValidation(txtManufMaterialDate.Text) && fun.DateValidation(txtBoughtoutMaterialDate.Text))
				{
					string text4 = "";
					string text5 = fun.FromDate(txtWorkOrderDate.Text);
					string text6 = fun.FromDate(txtTaskTargetDAP_FDate.Text);
					string text7 = fun.ToDate(txtTaskTargetDAP_TDate.Text);
					string text8 = fun.FromDate(txtTaskDesignFinalization_FDate.Text);
					string text9 = fun.ToDate(txtTaskDesignFinalization_TDate.Text);
					string text10 = fun.FromDate(txtTaskTargetManufg_FDate.Text);
					string text11 = fun.ToDate(txtTaskTargetManufg_TDate.Text);
					string text12 = fun.FromDate(txtTaskTargetTryOut_FDate.Text);
					string text13 = fun.ToDate(txtTaskTargetTryOut_TDate.Text);
					string text14 = fun.FromDate(txtTaskTargetDespach_FDate.Text);
					string text15 = fun.ToDate(txtTaskTargetDespach_TDate.Text);
					string text16 = fun.FromDate(txtTaskTargetAssembly_FDate.Text);
					string text17 = fun.ToDate(txtTaskTargetAssembly_TDate.Text);
					string text18 = fun.FromDate(txtTaskTargetInstalation_FDate.Text);
					string text19 = fun.ToDate(txtTaskTargetInstalation_TDate.Text);
					string text20 = fun.FromDate(txtTaskCustInspection_FDate.Text);
					string text21 = fun.ToDate(txtTaskCustInspection_TDate.Text);
					string text22 = fun.FromDate(txtManufMaterialDate.Text);
					string text23 = fun.FromDate(txtBoughtoutMaterialDate.Text);
					int num3 = (CKInstractionPrimerPainting.Checked ? 1 : 0);
					int num4 = (CKInstractionPainting.Checked ? 1 : 0);
					int num5 = (CKInstractionSelfCertRept.Checked ? 1 : 0);
					string cmdText4 = fun.insert("SD_Cust_WorkOrder_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,EnqId,PONo,WONo,TaskWorkOrderDate,TaskProjectTitle,TaskProjectLeader,CId,SCId,TaskBusinessGroup,TaskTargetDAP_FDate,TaskTargetDAP_TDate,TaskDesignFinalization_FDate,TaskDesignFinalization_TDate,TaskTargetManufg_FDate,TaskTargetManufg_TDate,TaskTargetTryOut_FDate,TaskTargetTryOut_TDate,TaskTargetDespach_FDate,TaskTargetDespach_TDate,TaskTargetAssembly_FDate,TaskTargetAssembly_TDate,TaskTargetInstalation_FDate,TaskTargetInstalation_TDate,TaskCustInspection_FDate,TaskCustInspection_TDate,ShippingAdd,ShippingCountry,ShippingState,ShippingCity,ShippingContactPerson1,ShippingContactNo1,ShippingEmail1,ShippingContactPerson2,ShippingContactNo2,ShippingEmail2,ShippingFaxNo,ShippingEccNo,ShippingTinCstNo,ShippingTinVatNo,InstractionPrimerPainting,InstractionPainting,InstractionSelfCertRept,InstractionOther,InstractionExportCaseMark,InstractionAttachAnnexure,POId,ManufMaterialDate,BoughtoutMaterialDate,Buyer", "'" + currDate.ToString() + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + CustCode + "','" + enqId + "','" + pono + "','" + text2 + "','" + text5 + "','" + txtProjectTitle.Text + "','" + txtProjectLeader.Text + "','" + DDLTaskWOType.SelectedValue + "','" + text + "','" + DDLBusinessGroup.SelectedValue + "','" + text6 + "','" + text7 + "','" + text8 + "','" + text9 + "','" + text10 + "','" + text11 + "','" + text12 + "','" + text13 + "','" + text14 + "','" + text15 + "','" + text16 + "','" + text17 + "','" + text18 + "','" + text19 + "','" + text20 + "','" + text21 + "','" + txtShippingAdd.Text + "','" + DDLShippingCountry.SelectedValue + "','" + DDLShippingState.SelectedValue + "','" + DDLShippingCity.SelectedValue + "','" + txtShippingContactPerson1.Text + "','" + txtShippingContactNo1.Text + "','" + txtShippingEmail1.Text + "','" + txtShippingContactPerson2.Text + "','" + txtShippingContactNo2.Text + "','" + txtShippingEmail2.Text + "','" + txtShippingFaxNo.Text + "','" + txtShippingEccNo.Text + "','" + txtShippingTinCstNo.Text + "','" + txtShippingTinVatNo.Text + "','" + num3.ToString() + "','" + num4.ToString() + "','" + num5.ToString() + "','" + txtInstractionOther.Text + "','" + txtInstractionExportCaseMark.Text + "','" + text4.ToString() + "','" + PoId + "','" + text22.ToString() + "','" + text23.ToString() + "','" + DDLBuyer.SelectedValue + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText4, con);
					sqlCommand.ExecuteNonQuery();
					string cmdText5 = fun.select("Id", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "'Order by Id desc");
					SqlCommand selectCommand4 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter4.Fill(dataSet3, "tblinv_MaterialReceived_Master");
					text3 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					num++;
				}
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string cmdText6 = fun.insert("SD_Cust_WorkOrder_Products_Details", "MId,SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + text3 + "','" + dataSet2.Tables[0].Rows[i]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]) + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FinYearId"]) + "','" + dataSet2.Tables[0].Rows[i]["ItemCode"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Description"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText6, con);
					sqlCommand2.ExecuteNonQuery();
				}
				if (num > 0)
				{
					string cmdText7 = fun.delete("SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText7, con);
					sqlCommand3.ExecuteNonQuery();
					num2++;
				}
			}
			else
			{
				_ = string.Empty;
				string text24 = "Invalid Data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text24 + "');", addScriptTags: true);
			}
			if (num > 0 && (num > 0 || num2 > 0))
			{
				base.Response.Redirect("WorkOrder_New.aspx?ModId=2&SubModId=13&msg=Work order is generated.");
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

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView1.EditIndex = e.NewEditIndex;
		FillGrid();
	}

	private void FillGrid()
	{
		try
		{
			con.Open();
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(fun.select("Id,ItemCode,Description,Qty", "SD_Cust_WorkOrder_Products_Temp", "CompId ='" + CompId + "'AND FinYearId ='" + FinYearId + "' AND SessionId ='" + sId + "' Order by Id desc"), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, " SD_Cust_WorkOrder_Products_Temp");
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtItemCode")).Text.ToString().Trim();
			string text2 = ((TextBox)gridViewRow.FindControl("txtDesc")).Text.ToString().Trim();
			double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtQty")).Text.ToString().Trim());
			if (text != "" && text2 != "" && num2 != 0.0 && fun.NumberValidationQty(num2.ToString()))
			{
				string cmdText = fun.update("SD_Cust_WorkOrder_Products_Temp", "ItemCode='" + text + "',Description='" + text2 + "',Qty='" + decimal.Parse(num2.ToString()).ToString("N3") + "' ", "Id=" + num + " And CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				int num3 = sqlCommand.ExecuteNonQuery();
				con.Close();
				if (num3 == 1)
				{
					lblMessage.Text = "Record updated successfully";
				}
				GridView1.EditIndex = -1;
				FillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_WorkOrder_Products_Temp  WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			int num2 = sqlCommand.ExecuteNonQuery();
			if (num2 == 1)
			{
				lblMessage.Text = "Record deleted successfully";
			}
			con.Close();
			FillGrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		FillGrid();
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		FillGrid();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DDLTaskWOType.SelectedValue != "Select")
			{
				string cmdText = fun.select("HasSubCat", "tblSD_WO_Category", "CId='" + DDLTaskWOType.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["HasSubCat"]) == 0)
				{
					ReqWoType0.Visible = false;
				}
				else
				{
					ReqWoType0.Visible = true;
				}
				string cmdText2 = fun.select("CId,SCId,Symbol+' - '+SCName as SubCategory", " tblSD_WO_SubCategory", "CId=" + DDLTaskWOType.SelectedValue + "And CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblSD_WO_SubCategory");
				DDLSubcategory.DataSource = dataSet2.Tables["tblSD_WO_SubCategory"];
				DDLSubcategory.DataTextField = "SubCategory";
				DDLSubcategory.DataValueField = "SCId";
				DDLSubcategory.DataBind();
				DDLSubcategory.Items.Insert(0, "Select");
			}
			else
			{
				DDLSubcategory.Items.Clear();
				DDLSubcategory.Items.Insert(0, "Select");
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
}

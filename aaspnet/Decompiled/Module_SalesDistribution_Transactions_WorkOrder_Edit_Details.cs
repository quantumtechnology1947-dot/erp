using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_WorkOrder_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private string pono = "";

	private string PoId = "";

	private string WOId = "";

	private int enqId;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected Label lblCustomerName;

	protected Label hfCustId;

	protected Label hfPoNo;

	protected Label lblWONo;

	protected Label lblPONo;

	protected Label hfEnqId;

	protected Label lblCategory;

	protected Label lblSubCategory;

	protected TextBox txtWorkOrderDate;

	protected CalendarExtender txtWorkOrderDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle1;

	protected RegularExpressionValidator RegWorkOrderDate;

	protected TextBox txtProjectTitle;

	protected RequiredFieldValidator ReqProjTitle;

	protected TextBox txtProjectLeader;

	protected RequiredFieldValidator ReqProjTitle2;

	protected DropDownList DDLBusinessGroup;

	protected RequiredFieldValidator ReqProjTitle4;

	protected TextBox txtTaskTargetDAP_FDate;

	protected CalendarExtender txtTaskTargetDAP_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle5;

	protected RegularExpressionValidator RegTaskTargetDAP_FDate;

	protected TextBox txtTaskTargetDAP_TDate;

	protected CalendarExtender txtTaskTargetDAP_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle6;

	protected RegularExpressionValidator RegTaskTargetDAP_TDate;

	protected TextBox txtTaskDesignFinalization_FDate;

	protected CalendarExtender txtTaskDesignFinalization_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle7;

	protected RegularExpressionValidator RegTaskDesignFinalization_FDate;

	protected TextBox txtTaskDesignFinalization_TDate;

	protected CalendarExtender txtTaskDesignFinalization_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle8;

	protected RegularExpressionValidator RegTaskDesignFinalization_TDate;

	protected TextBox txtTaskTargetManufg_FDate;

	protected CalendarExtender txtTaskTargetManufg_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle9;

	protected RegularExpressionValidator RegTaskTargetManufg_FDate;

	protected TextBox txtTaskTargetManufg_TDate;

	protected CalendarExtender txtTaskTargetManufg_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle10;

	protected RegularExpressionValidator RegTaskTargetManufg_TDate;

	protected TextBox txtTaskTargetTryOut_FDate;

	protected CalendarExtender txtTaskTargetTryOut_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle11;

	protected RegularExpressionValidator RegTaskTargetTryOut_FDate;

	protected TextBox txtTaskTargetTryOut_TDate;

	protected CalendarExtender txtTaskTargetTryOut_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle12;

	protected RegularExpressionValidator RegTaskTargetTryOut_TDate;

	protected TextBox txtTaskTargetDespach_FDate;

	protected CalendarExtender txtTaskTargetDespach_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle13;

	protected RegularExpressionValidator RegTaskTargetDespach_FDate;

	protected TextBox txtTaskTargetDespach_TDate;

	protected CalendarExtender txtTaskTargetDespach_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle14;

	protected RegularExpressionValidator RegTaskTargetDespach_TDate;

	protected TextBox txtTaskTargetAssembly_FDate;

	protected CalendarExtender txtTaskTargetAssembly_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle16;

	protected RegularExpressionValidator RegTaskTargetAssembly_FDate;

	protected TextBox txtTaskTargetAssembly_TDate;

	protected CalendarExtender txtTaskTargetAssembly_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle15;

	protected RegularExpressionValidator RegTaskTargetAssembly_TDate;

	protected TextBox txtTaskTargetInstalation_FDate;

	protected CalendarExtender txtTaskTargetInstalation_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle17;

	protected RegularExpressionValidator RegTaskTargetInstalation_FDate;

	protected TextBox txtTaskTargetInstalation_TDate;

	protected CalendarExtender txtTaskTargetInstalation_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle18;

	protected RegularExpressionValidator RegTaskTargetInstalation_TDate;

	protected TextBox txtTaskCustInspection_FDate;

	protected CalendarExtender txtTaskCustInspection_FDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle19;

	protected RegularExpressionValidator RegTaskCustInspection_FDate;

	protected TextBox txtTaskCustInspection_TDate;

	protected CalendarExtender txtTaskCustInspection_TDate_CalendarExtender;

	protected RequiredFieldValidator ReqProjTitle20;

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

	protected Button btnTaskCancel;

	protected TabPanel TabPanel1;

	protected TextBox txtShippingAdd;

	protected RequiredFieldValidator ReqProjTitle26;

	protected DropDownList DDLShippingCountry;

	protected RequiredFieldValidator ReqProjTitle37;

	protected DropDownList DDLShippingState;

	protected RequiredFieldValidator ReqProjTitle38;

	protected DropDownList DDLShippingCity;

	protected RequiredFieldValidator ReqProjTitle39;

	protected TextBox txtShippingContactPerson1;

	protected RequiredFieldValidator ReqProjTitle27;

	protected TextBox txtShippingContactNo1;

	protected RequiredFieldValidator ReqProjTitle33;

	protected TextBox txtShippingEmail1;

	protected RequiredFieldValidator ReqProjTitle28;

	protected RegularExpressionValidator RegEmail1;

	protected TextBox txtShippingContactPerson2;

	protected RequiredFieldValidator ReqProjTitle29;

	protected TextBox txtShippingContactNo2;

	protected RequiredFieldValidator ReqProjTitle34;

	protected TextBox txtShippingEmail2;

	protected RequiredFieldValidator ReqProjTitle30;

	protected RegularExpressionValidator RegEmail2;

	protected TextBox txtShippingFaxNo;

	protected RequiredFieldValidator ReqProjTitle31;

	protected TextBox txtShippingEccNo;

	protected RequiredFieldValidator ReqProjTitle35;

	protected TextBox txtShippingTinCstNo;

	protected RequiredFieldValidator ReqProjTitle32;

	protected TextBox txtShippingTinVatNo;

	protected RequiredFieldValidator ReqProjTitle36;

	protected Button btnShippingNext;

	protected Button btnShippingCancel;

	protected TabPanel TabPanel2;

	protected TextBox txtItemCode;

	protected RequiredFieldValidator ReqProjTitle23;

	protected TextBox txtDescOfItem;

	protected RequiredFieldValidator ReqProjTitle24;

	protected TextBox txtQty;

	protected RequiredFieldValidator ReqProjTitle25;

	protected RegularExpressionValidator RegQty;

	protected Button btnProductSubmit;

	protected Button btnProductNext;

	protected Button btnProductCancel;

	protected GridView GridView1;

	protected Label lblMessage;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected TabPanel TabPanel3;

	protected CheckBox CKInstractionPrimerPainting;

	protected CheckBox CKInstractionPainting;

	protected CheckBox CKInstractionSelfCertRept;

	protected TextBox txtInstractionOther;

	protected RequiredFieldValidator ReqProjTitle21;

	protected TextBox txtInstractionExportCaseMark;

	protected RequiredFieldValidator ReqProjTitle22;

	protected Button btnUpdate;

	protected Button btnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			hfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = hfCustId.Text;
			hfPoNo.Text = base.Request.QueryString["PONo"].ToString();
			lblPONo.Text = base.Request.QueryString["PONo"].ToString();
			pono = hfPoNo.Text;
			PoId = base.Request.QueryString["PoId"].ToString();
			WOId = base.Request.QueryString["Id"].ToString();
			hfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(hfEnqId.Text);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblMessage.Text = "";
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
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
			if (base.IsPostBack)
			{
				return;
			}
			fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
			fun.dropdownBG(DDLBusinessGroup);
			fun.dropdownBuyer(DDLBuyer);
			FillGrid();
			sqlConnection.Open();
			DataSet dataSet = new DataSet();
			string cmdText = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
			lblCustomerName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
			DataSet dataSet2 = new DataSet();
			string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Master", "CustomerId='" + CustCode + "' and Id='" + WOId + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2, "SD_Cust_WorkOrder_Master");
			if (dataSet2.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			fun.dropdownCountrybyId(DDLShippingCountry, DDLShippingState, "CId='" + dataSet2.Tables[0].Rows[0]["ShippingCountry"].ToString() + "'");
			DDLShippingCountry.SelectedIndex = 0;
			fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
			DDLShippingCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["ShippingCountry"].ToString();
			fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
			fun.dropdownStatebyId(DDLShippingState, "CId='" + dataSet2.Tables[0].Rows[0]["ShippingCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["ShippingState"].ToString() + "'");
			DDLShippingState.SelectedValue = dataSet2.Tables[0].Rows[0]["ShippingState"].ToString();
			fun.dropdownCity(DDLShippingCity, DDLShippingState);
			fun.dropdownCitybyId(DDLShippingCity, "SId='" + dataSet2.Tables[0].Rows[0]["ShippingState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["ShippingCity"].ToString() + "'");
			DDLShippingCity.SelectedValue = dataSet2.Tables[0].Rows[0]["ShippingCity"].ToString();
			hfEnqId.Text = dataSet2.Tables[0].Rows[0]["EnqId"].ToString();
			string cmdText3 = fun.select("CId,Symbol+' - '+CName as Category,HasSubCat", "tblSD_WO_Category", "CompId='" + CompId + "' AND CId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["CId"].ToString()) + "' ");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			DataSet dataSet3 = new DataSet();
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3, "tblSD_WO_Category");
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				lblCategory.Text = dataSet3.Tables[0].Rows[0]["Category"].ToString();
				if (dataSet3.Tables[0].Rows[0]["HasSubCat"].ToString() == "1")
				{
					string cmdText4 = fun.select("Symbol+' - '+SCName as SubCategory", " tblSD_WO_SubCategory", string.Concat("CId=", dataSet3.Tables[0].Rows[0]["CId"], "And CompId='", CompId, "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblSD_WO_SubCategory");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						lblSubCategory.Text = dataSet4.Tables[0].Rows[0]["SubCategory"].ToString();
					}
				}
				else
				{
					lblSubCategory.Text = "Not Applicable";
				}
			}
			lblWONo.Text = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
			string text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString());
			txtWorkOrderDate.Text = text;
			txtProjectTitle.Text = dataSet2.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
			txtProjectLeader.Text = dataSet2.Tables[0].Rows[0]["TaskProjectLeader"].ToString();
			DDLBusinessGroup.SelectedValue = dataSet2.Tables[0].Rows[0]["TaskBusinessGroup"].ToString();
			DDLBuyer.SelectedValue = dataSet2.Tables[0].Rows[0]["Buyer"].ToString();
			string text2 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDAP_FDate"].ToString());
			string text3 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDAP_TDate"].ToString());
			txtTaskTargetDAP_FDate.Text = text2;
			txtTaskTargetDAP_TDate.Text = text3;
			string text4 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskDesignFinalization_FDate"].ToString());
			string text5 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskDesignFinalization_TDate"].ToString());
			txtTaskDesignFinalization_FDate.Text = text4;
			txtTaskDesignFinalization_TDate.Text = text5;
			string text6 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetManufg_FDate"].ToString());
			string text7 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetManufg_TDate"].ToString());
			txtTaskTargetManufg_FDate.Text = text6;
			txtTaskTargetManufg_TDate.Text = text7;
			string text8 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
			string text9 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
			txtTaskTargetTryOut_FDate.Text = text8;
			txtTaskTargetTryOut_TDate.Text = text9;
			string text10 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
			string text11 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
			txtTaskTargetDespach_FDate.Text = text10;
			txtTaskTargetDespach_TDate.Text = text11;
			string text12 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetAssembly_FDate"].ToString());
			string text13 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetAssembly_TDate"].ToString());
			txtTaskTargetAssembly_FDate.Text = text12;
			txtTaskTargetAssembly_TDate.Text = text13;
			string text14 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
			string text15 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetInstalation_TDate"].ToString());
			txtTaskTargetInstalation_FDate.Text = text14;
			txtTaskTargetInstalation_TDate.Text = text15;
			string text16 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString());
			string text17 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString());
			txtTaskCustInspection_FDate.Text = text16;
			txtTaskCustInspection_TDate.Text = text17;
			string text18 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["ManufMaterialDate"].ToString());
			string text19 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());
			txtManufMaterialDate.Text = text18;
			txtBoughtoutMaterialDate.Text = text19;
			txtShippingAdd.Text = dataSet2.Tables[0].Rows[0]["ShippingAdd"].ToString();
			txtShippingContactPerson1.Text = dataSet2.Tables[0].Rows[0]["ShippingContactPerson1"].ToString();
			txtShippingContactNo1.Text = dataSet2.Tables[0].Rows[0]["ShippingContactNo1"].ToString();
			txtShippingEmail1.Text = dataSet2.Tables[0].Rows[0]["ShippingEmail1"].ToString();
			txtShippingContactPerson2.Text = dataSet2.Tables[0].Rows[0]["ShippingContactPerson2"].ToString();
			txtShippingContactNo2.Text = dataSet2.Tables[0].Rows[0]["ShippingContactNo2"].ToString();
			txtShippingEmail2.Text = dataSet2.Tables[0].Rows[0]["ShippingEmail2"].ToString();
			txtShippingFaxNo.Text = dataSet2.Tables[0].Rows[0]["ShippingFaxNo"].ToString();
			txtShippingEccNo.Text = dataSet2.Tables[0].Rows[0]["ShippingEccNo"].ToString();
			txtShippingTinCstNo.Text = dataSet2.Tables[0].Rows[0]["ShippingTinCstNo"].ToString();
			txtShippingTinVatNo.Text = dataSet2.Tables[0].Rows[0]["ShippingTinVatNo"].ToString();
			txtInstractionOther.Text = dataSet2.Tables[0].Rows[0]["InstractionOther"].ToString();
			if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionPrimerPainting"]) > 0)
			{
				CKInstractionPrimerPainting.Checked = true;
			}
			else
			{
				CKInstractionPrimerPainting.Checked = false;
			}
			if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionPainting"]) > 0)
			{
				CKInstractionPainting.Checked = true;
			}
			else
			{
				CKInstractionPainting.Checked = false;
			}
			if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionSelfCertRept"]) > 0)
			{
				CKInstractionSelfCertRept.Checked = true;
			}
			else
			{
				CKInstractionSelfCertRept.Checked = false;
			}
			txtInstractionExportCaseMark.Text = dataSet2.Tables[0].Rows[0]["InstractionExportCaseMark"].ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	private void FillGrid()
	{
		DataSet dataSet = new DataSet();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string cmdText = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId ='" + sId + "' AND CompId= '" + CompId + "' ORDER BY Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
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
			sqlConnection.Close();
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
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (txtItemCode.Text != "" && txtDescOfItem.Text != "" && txtQty.Text != "" && fun.NumberValidationQty(txtQty.Text))
			{
				string cmdText = fun.insert("SD_Cust_WorkOrder_Products_Temp", "SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + txtItemCode.Text + "','" + txtDescOfItem.Text + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text.ToString()).ToString("N3")) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				FillGrid();
				txtItemCode.Text = "";
				txtDescOfItem.Text = "";
				txtQty.Text = "";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
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

	protected void btnTaskCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Edit.aspx?ModId=2&SubModId=13");
	}

	protected void btnShippingCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Edit.aspx?ModId=2&SubModId=13");
	}

	protected void btnProductCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Edit.aspx?ModId=2&SubModId=13");
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Edit.aspx?ModId=2&SubModId=13");
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = 0;
		int num2 = 0;
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = "";
			string text2 = fun.FromDate(txtWorkOrderDate.Text);
			string text3 = fun.FromDate(txtTaskTargetDAP_FDate.Text);
			string text4 = fun.ToDate(txtTaskTargetDAP_TDate.Text);
			string text5 = fun.FromDate(txtTaskDesignFinalization_FDate.Text);
			string text6 = fun.ToDate(txtTaskDesignFinalization_TDate.Text);
			string text7 = fun.FromDate(txtTaskTargetManufg_FDate.Text);
			string text8 = fun.ToDate(txtTaskTargetManufg_TDate.Text);
			string text9 = fun.FromDate(txtTaskTargetTryOut_FDate.Text);
			string text10 = fun.ToDate(txtTaskTargetTryOut_TDate.Text);
			string text11 = fun.FromDate(txtTaskTargetDespach_FDate.Text);
			string text12 = fun.ToDate(txtTaskTargetDespach_TDate.Text);
			string text13 = fun.FromDate(txtTaskTargetAssembly_FDate.Text);
			string text14 = fun.ToDate(txtTaskTargetAssembly_TDate.Text);
			string text15 = fun.FromDate(txtTaskTargetInstalation_FDate.Text);
			string text16 = fun.ToDate(txtTaskTargetInstalation_TDate.Text);
			string text17 = fun.FromDate(txtTaskCustInspection_FDate.Text);
			string text18 = fun.ToDate(txtTaskCustInspection_TDate.Text);
			string text19 = fun.FromDate(txtManufMaterialDate.Text);
			string text20 = fun.ToDate(txtBoughtoutMaterialDate.Text);
			int num3 = (CKInstractionPrimerPainting.Checked ? 1 : 0);
			int num4 = (CKInstractionPainting.Checked ? 1 : 0);
			int num5 = (CKInstractionSelfCertRept.Checked ? 1 : 0);
			if (DDLBuyer.SelectedValue != "Select" && txtWorkOrderDate.Text != "" && txtTaskTargetDAP_FDate.Text != "" && txtTaskTargetDAP_TDate.Text != "" && txtTaskDesignFinalization_FDate.Text != "" && txtTaskDesignFinalization_TDate.Text != "" && txtTaskTargetManufg_FDate.Text != "" && txtTaskTargetManufg_TDate.Text != "" && txtTaskTargetTryOut_FDate.Text != "" && txtTaskTargetTryOut_TDate.Text != "" && txtTaskTargetDespach_FDate.Text != "" && txtTaskTargetDespach_TDate.Text != "" && txtTaskTargetAssembly_FDate.Text != "" && txtTaskTargetAssembly_TDate.Text != "" && txtTaskTargetInstalation_FDate.Text != "" && txtTaskTargetInstalation_TDate.Text != "" && txtTaskCustInspection_FDate.Text != "" && txtTaskCustInspection_TDate.Text != "" && CustCode.ToString() != "" && enqId != 0 && pono.ToString() != "" && txtProjectTitle.Text != "" && txtProjectLeader.Text != "" && DDLBusinessGroup.SelectedValue != "Select" && txtShippingAdd.Text != "" && DDLShippingCountry.SelectedValue != "Select" && DDLShippingState.SelectedValue != "Select" && DDLShippingCity.SelectedValue != "Select" && txtShippingContactPerson1.Text != "" && txtShippingContactNo1.Text != "" && txtShippingEmail1.Text != "" && txtShippingContactPerson2.Text != "" && txtShippingContactNo2.Text != "" && txtShippingEmail2.Text != "" && txtShippingFaxNo.Text != "" && txtShippingEccNo.Text != "" && txtShippingTinCstNo.Text != "" && txtShippingTinVatNo.Text != "" && txtInstractionOther.Text != "" && txtInstractionExportCaseMark.Text != "" && fun.EmailValidation(txtShippingEmail1.Text) && fun.EmailValidation(txtShippingEmail2.Text) && fun.DateValidation(txtWorkOrderDate.Text) && fun.DateValidation(txtTaskTargetDAP_FDate.Text) && fun.DateValidation(txtTaskTargetDAP_TDate.Text) && fun.DateValidation(txtTaskDesignFinalization_FDate.Text) && fun.DateValidation(txtTaskDesignFinalization_TDate.Text) && fun.DateValidation(txtTaskTargetManufg_FDate.Text) && fun.DateValidation(txtTaskTargetManufg_TDate.Text) && fun.DateValidation(txtTaskTargetTryOut_FDate.Text) && fun.DateValidation(txtTaskTargetTryOut_TDate.Text) && fun.DateValidation(txtTaskTargetDespach_FDate.Text) && fun.DateValidation(txtTaskTargetDespach_TDate.Text) && fun.DateValidation(txtTaskTargetAssembly_FDate.Text) && fun.DateValidation(txtTaskTargetAssembly_TDate.Text) && fun.DateValidation(txtTaskTargetInstalation_FDate.Text) && fun.DateValidation(txtTaskTargetInstalation_TDate.Text) && fun.DateValidation(txtTaskCustInspection_FDate.Text) && fun.DateValidation(txtTaskCustInspection_TDate.Text) && fun.DateValidation(txtManufMaterialDate.Text) && fun.DateValidation(txtBoughtoutMaterialDate.Text))
			{
				string cmdText = fun.update("SD_Cust_WorkOrder_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',CompId='" + CompId + "',CustomerId='" + CustCode + "',EnqId='" + enqId + "',PONo='" + pono + "',TaskWorkOrderDate='" + text2 + "',TaskProjectTitle='" + txtProjectTitle.Text + "',TaskProjectLeader='" + txtProjectLeader.Text + "',TaskBusinessGroup='" + DDLBusinessGroup.SelectedValue + "',TaskTargetDAP_FDate='" + text3 + "',TaskTargetDAP_TDate='" + text4 + "',TaskDesignFinalization_FDate='" + text5 + "',TaskDesignFinalization_TDate='" + text6 + "',TaskTargetManufg_FDate='" + text7 + "',TaskTargetManufg_TDate='" + text8 + "',TaskTargetTryOut_FDate='" + text9 + "',TaskTargetTryOut_TDate='" + text10 + "',TaskTargetDespach_FDate='" + text11 + "',TaskTargetDespach_TDate='" + text12 + "',TaskTargetAssembly_FDate='" + text13 + "',TaskTargetAssembly_TDate='" + text14 + "',TaskTargetInstalation_FDate='" + text15 + "',TaskTargetInstalation_TDate='" + text16 + "',TaskCustInspection_FDate='" + text17 + "',TaskCustInspection_TDate='" + text18 + "',ShippingAdd='" + txtShippingAdd.Text + "',ShippingCountry='" + DDLShippingCountry.SelectedValue + "',ShippingState='" + DDLShippingState.SelectedValue + "',ShippingCity='" + DDLShippingCity.SelectedValue + "',ShippingContactPerson1='" + txtShippingContactPerson1.Text + "',ShippingContactNo1='" + txtShippingContactNo1.Text + "',ShippingEmail1='" + txtShippingEmail1.Text + "',ShippingContactPerson2='" + txtShippingContactPerson2.Text + "',ShippingContactNo2='" + txtShippingContactNo2.Text + "',ShippingEmail2='" + txtShippingEmail2.Text + "',ShippingFaxNo='" + txtShippingFaxNo.Text + "',ShippingEccNo='" + txtShippingEccNo.Text + "',ShippingTinCstNo='" + txtShippingTinCstNo.Text + "',ShippingTinVatNo='" + txtShippingTinVatNo.Text + "',InstractionPrimerPainting='" + num3.ToString() + "',InstractionPainting='" + num4.ToString() + "',InstractionSelfCertRept='" + num5.ToString() + "',InstractionOther='" + txtInstractionOther.Text + "',InstractionExportCaseMark='" + txtInstractionExportCaseMark.Text + "',InstractionAttachAnnexure='" + text.ToString() + "',ManufMaterialDate='" + text19 + "',BoughtoutMaterialDate='" + text20 + "',Buyer='" + DDLBuyer.SelectedValue + "'", "CustomerId='" + CustCode + "' and Id=" + WOId + " and CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				num++;
			}
			DataSet dataSet = new DataSet();
			string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Products_Temp");
			string text21 = "";
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					text21 = fun.insert("SD_Cust_WorkOrder_Products_Details", "MId,SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + WOId + "','" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["FinYearId"]) + "','" + dataSet.Tables[0].Rows[i]["ItemCode"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Description"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(text21, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
				}
				string cmdText3 = fun.delete("SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				num2++;
			}
			if (num > 0 && (num > 0 || num2 > 0))
			{
				Page.Response.Redirect("~/Module/SalesDistribution/Transactions/WorkOrder_Edit.aspx?ModId=2&SubModId=13");
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

	protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void DDLBusinessGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			string text = ((TextBox)gridViewRow.FindControl("txtDescription0")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtItemCode0")).Text;
			double num = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQty0")).Text).ToString("N3"));
			if (text != "" && text2 != "" && num.ToString() != "" && fun.NumberValidationQty(num.ToString()))
			{
				SqlDataSource1.UpdateParameters["Description"].DefaultValue = text;
				SqlDataSource1.UpdateParameters["ItemCode"].DefaultValue = text2;
				SqlDataSource1.UpdateParameters["Qty"].DefaultValue = num.ToString();
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
	}

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated Successfully";
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

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtItemCode")).Text.ToString().Trim();
			string text2 = ((TextBox)gridViewRow.FindControl("txtDesc")).Text.ToString().Trim();
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQty")).Text).ToString("N3"));
			if (text != "" && text2 != "" && num2.ToString() != "" && fun.NumberValidationQty(num2.ToString()))
			{
				string cmdText = fun.update("SD_Cust_WorkOrder_Products_Temp", "ItemCode='" + text + "',Description='" + text2 + "',Qty='" + num2 + "' ", "Id=" + num + " And CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlConnection.Open();
				int num3 = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
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

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView1.EditIndex = e.NewEditIndex;
		FillGrid();
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		FillGrid();
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_WorkOrder_Products_Temp  WHERE Id=" + num + " And CompId='" + CompId + "'", sqlConnection);
			sqlConnection.Open();
			int num2 = sqlCommand.ExecuteNonQuery();
			if (num2 == 1)
			{
				lblMessage.Text = "Record deleted successfully";
			}
			sqlConnection.Close();
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
}

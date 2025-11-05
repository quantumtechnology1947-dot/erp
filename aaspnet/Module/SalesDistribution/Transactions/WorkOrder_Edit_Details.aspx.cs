using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Module_SalesDistribution_Transactions_WorkOrder_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string CustCode="";
    string pono = "";
    string PoId = "";
    string WOId = "";
    int enqId = 0;
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr1 = fun.Connection();
        SqlConnection con1 = new SqlConnection(connStr1);
        try
        {
            hfCustId.Text = Request.QueryString["CustomerId"].ToString();
            CustCode = hfCustId.Text;
            hfPoNo.Text = Request.QueryString["PONo"].ToString();
            lblPONo.Text = Request.QueryString["PONo"].ToString();
            pono = hfPoNo.Text;
            PoId = Request.QueryString["PoId"].ToString();
            WOId = Request.QueryString["Id"].ToString();
            hfEnqId.Text = Request.QueryString["EnqId"].ToString();
            enqId = Convert.ToInt32(hfEnqId.Text);
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblMessage.Text = "";
            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");

            // For Date 

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

            if (!IsPostBack)
            {

                fun.dropdownCountry(DDLShippingCountry, DDLShippingState); 
                fun.dropdownBG(DDLBusinessGroup);
                fun.dropdownBuyer(DDLBuyer);
                this.FillGrid();
                con1.Open();

                DataSet ds = new DataSet();
                string cn = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
                SqlCommand cmd4 = new SqlCommand(cn, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd4);
                da.Fill(ds, "SD_Cust_master");
                lblCustomerName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();

                DataSet DS = new DataSet();

                string cmdStr = fun.select("*", "SD_Cust_WorkOrder_Master", "CustomerId='" + CustCode + "' and Id='" +WOId+ "' And CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(cmdStr, con1);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS, "SD_Cust_WorkOrder_Master");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    // Regd Country 
                    fun.dropdownCountrybyId(DDLShippingCountry, DDLShippingState, "CId='" + DS.Tables[0].Rows[0]["ShippingCountry"].ToString() + "'");
                    DDLShippingCountry.SelectedIndex = 0;
                    fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
                    DDLShippingCountry.SelectedValue = DS.Tables[0].Rows[0]["ShippingCountry"].ToString();
                    // Regd State
                    fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
                    fun.dropdownStatebyId(DDLShippingState, "CId='" + DS.Tables[0].Rows[0]["ShippingCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["ShippingState"].ToString() + "'");
                    DDLShippingState.SelectedValue = DS.Tables[0].Rows[0]["ShippingState"].ToString();

                    // Regd City
                    fun.dropdownCity(DDLShippingCity, DDLShippingState);
                    fun.dropdownCitybyId(DDLShippingCity, "SId='" + DS.Tables[0].Rows[0]["ShippingState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["ShippingCity"].ToString() + "'");

                    DDLShippingCity.SelectedValue = DS.Tables[0].Rows[0]["ShippingCity"].ToString();
                    hfEnqId.Text = DS.Tables[0].Rows[0]["EnqId"].ToString();


                    //for Cat

                    string StrCat = fun.select("CId,Symbol+' - '+CName as Category,HasSubCat", "tblSD_WO_Category", "CompId='" + CompId + "' AND CId='" + Convert.ToInt32(DS.Tables[0].Rows[0]["CId"].ToString()) + "' ");
                    SqlCommand Cmd = new SqlCommand(StrCat, con1);
                    DataSet DScat = new DataSet();
                    SqlDataAdapter DAcat = new SqlDataAdapter(Cmd);
                    DAcat.Fill(DScat, "tblSD_WO_Category");
                    if (DScat.Tables[0].Rows.Count > 0)
                    {
                        lblCategory.Text = DScat.Tables[0].Rows[0]["Category"].ToString();

                        //for subcat

                        if (DScat.Tables[0].Rows[0]["HasSubCat"].ToString() == "1")
                        {
                            string StrSub = fun.select("Symbol+' - '+SCName as SubCategory", " tblSD_WO_SubCategory", "CId=" + DScat.Tables[0].Rows[0]["CId"] + "And CompId='" + CompId + "'");
                            SqlCommand Cmd1 = new SqlCommand(StrSub, con1);

                            SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
                            DataSet DS2 = new DataSet();
                            DA1.Fill(DS2, "tblSD_WO_SubCategory");

                            if (DS2.Tables[0].Rows.Count > 0)
                            {
                                lblSubCategory.Text = DS2.Tables[0].Rows[0]["SubCategory"].ToString();
                            }
                        }
                        else
                        {
                            lblSubCategory.Text = "Not Applicable";
                        }

                    }

                    lblWONo.Text = DS.Tables[0].Rows[0]["WONo"].ToString();
                    string WorkOrderDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString());
                    txtWorkOrderDate.Text = WorkOrderDate;

                    txtProjectTitle.Text = DS.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
                    txtProjectLeader.Text = DS.Tables[0].Rows[0]["TaskProjectLeader"].ToString();
                    DDLBusinessGroup.SelectedValue = DS.Tables[0].Rows[0]["TaskBusinessGroup"].ToString();
                    DDLBuyer.SelectedValue = DS.Tables[0].Rows[0]["Buyer"].ToString();

                    string TaskTargetDAP_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetDAP_FDate"].ToString());
                    string TaskTargetDAP_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetDAP_TDate"].ToString());
                    txtTaskTargetDAP_FDate.Text = TaskTargetDAP_FDate;
                    txtTaskTargetDAP_TDate.Text = TaskTargetDAP_TDate;

                    string DesignFinalization_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskDesignFinalization_FDate"].ToString());
                    string DesignFinalization_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskDesignFinalization_TDate"].ToString());
                    txtTaskDesignFinalization_FDate.Text = DesignFinalization_FDate;
                    txtTaskDesignFinalization_TDate.Text = DesignFinalization_TDate;

                    string TargetManufg_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetManufg_FDate"].ToString());
                    string TargetManufg_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetManufg_TDate"].ToString());
                    txtTaskTargetManufg_FDate.Text = TargetManufg_FDate;
                    txtTaskTargetManufg_TDate.Text = TargetManufg_TDate;

                    string TargetTryOut_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
                    string TargetTryOut_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
                    txtTaskTargetTryOut_FDate.Text = TargetTryOut_FDate;
                    txtTaskTargetTryOut_TDate.Text = TargetTryOut_TDate;

                    string TargetDespach_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
                    string TargetDespach_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
                    txtTaskTargetDespach_FDate.Text = TargetDespach_FDate;
                    txtTaskTargetDespach_TDate.Text = TargetDespach_TDate;

                    string TargetAssembly_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetAssembly_FDate"].ToString());
                    string TargetAssembly_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetAssembly_TDate"].ToString());
                    txtTaskTargetAssembly_FDate.Text = TargetAssembly_FDate;
                    txtTaskTargetAssembly_TDate.Text = TargetAssembly_TDate;

                    string TargetInstalation_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
                    string TargetInstalation_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskTargetInstalation_TDate"].ToString());
                    txtTaskTargetInstalation_FDate.Text = TargetInstalation_FDate;
                    txtTaskTargetInstalation_TDate.Text = TargetInstalation_TDate;

                    string TaskCustInspection_FDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString());
                    string TaskCustInspection_TDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString());
                    txtTaskCustInspection_FDate.Text = TaskCustInspection_FDate;
                    txtTaskCustInspection_TDate.Text = TaskCustInspection_TDate;


                    string ManufMaterialDate = fun.FromDateDMY(DS.Tables[0].Rows[0]["ManufMaterialDate"].ToString());
                    string BoughtoutMaterialDate = fun.ToDateDMY(DS.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());
                    txtManufMaterialDate.Text = ManufMaterialDate;
                    txtBoughtoutMaterialDate.Text = BoughtoutMaterialDate;

                    txtShippingAdd.Text = DS.Tables[0].Rows[0]["ShippingAdd"].ToString();
                    txtShippingContactPerson1.Text = DS.Tables[0].Rows[0]["ShippingContactPerson1"].ToString();
                    txtShippingContactNo1.Text = DS.Tables[0].Rows[0]["ShippingContactNo1"].ToString();
                    txtShippingEmail1.Text = DS.Tables[0].Rows[0]["ShippingEmail1"].ToString();
                    txtShippingContactPerson2.Text = DS.Tables[0].Rows[0]["ShippingContactPerson2"].ToString();
                    txtShippingContactNo2.Text = DS.Tables[0].Rows[0]["ShippingContactNo2"].ToString();
                    txtShippingEmail2.Text = DS.Tables[0].Rows[0]["ShippingEmail2"].ToString();

                    txtShippingFaxNo.Text = DS.Tables[0].Rows[0]["ShippingFaxNo"].ToString();
                    txtShippingEccNo.Text = DS.Tables[0].Rows[0]["ShippingEccNo"].ToString();
                    txtShippingTinCstNo.Text = DS.Tables[0].Rows[0]["ShippingTinCstNo"].ToString();

                    txtShippingTinVatNo.Text = DS.Tables[0].Rows[0]["ShippingTinVatNo"].ToString();
                    txtInstractionOther.Text = DS.Tables[0].Rows[0]["InstractionOther"].ToString();

                    txtedcri.Text = DS.Tables[0].Rows[0]["Critics"].ToString();




                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["InstractionPrimerPainting"]) > 0)
                    { CKInstractionPrimerPainting.Checked = true; }
                    else { CKInstractionPrimerPainting.Checked = false; }

                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["InstractionPainting"]) > 0)
                    { CKInstractionPainting.Checked = true; }
                    else { CKInstractionPainting.Checked = false; }

                    if (Convert.ToInt32(DS.Tables[0].Rows[0]["InstractionSelfCertRept"]) > 0)
                    { CKInstractionSelfCertRept.Checked = true; }
                    else { CKInstractionSelfCertRept.Checked = false; }

                    txtInstractionExportCaseMark.Text = DS.Tables[0].Rows[0]["InstractionExportCaseMark"].ToString();

                }

            }
        }
        catch (Exception ex) { }
        finally
        { con1.Close(); }

    }

    private void FillGrid()
    {

        DataSet ds = new DataSet();
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            string Str = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId ='" + sId + "' AND CompId= '" + CompId + "' ORDER BY Id DESC");
            SqlCommand cmd = new SqlCommand(Str, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, " SD_Cust_WorkOrder_Products_Temp");
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
        }
       finally
        {
            con.Close();
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

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            con.Open();
            if (txtItemCode.Text != "" && txtDescOfItem.Text != "" && txtQty.Text != "" && fun.NumberValidationQty(txtQty.Text) == true)

            {
            string cmdstr = fun.insert("SD_Cust_WorkOrder_Products_Temp", "SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + sId.ToString() + "','" + CompId + "','" + FinYearId+ "','" + txtItemCode.Text + "','" + txtDescOfItem.Text + "','" + Convert.ToDouble(decimal.Parse((txtQty.Text).ToString()).ToString("N3")) + "'");
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.ExecuteNonQuery();
            this.FillGrid();
                txtItemCode.Text = "" ;
                txtDescOfItem.Text = "" ;
                txtQty.Text = "";
            
            }
            
       }
     catch (Exception ex)
     { }
     finally { con.Close(); }

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
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int k1 = 0;
        int k2 = 0;
        try
        {
        string CDate = fun.getCurrDate();
        string CTime = fun.getCurrTime();       
        
            string InstractionAttachAnnexure = "";
            string WorkOrderDate = fun.FromDate(txtWorkOrderDate.Text);

            string TaskTargetDAP_FDate = fun.FromDate(txtTaskTargetDAP_FDate.Text);
            string TaskTargetDAP_TDate = fun.ToDate(txtTaskTargetDAP_TDate.Text);

            string TaskDesignFinalization_FDate = fun.FromDate(txtTaskDesignFinalization_FDate.Text);
            string TaskDesignFinalization_TDate = fun.ToDate(txtTaskDesignFinalization_TDate.Text);

            string TaskTargetManufg_FDate = fun.FromDate(txtTaskTargetManufg_FDate.Text);
            string TaskTargetManufg_TDate = fun.ToDate(txtTaskTargetManufg_TDate.Text);

            string TaskTargetTryOut_FDate = fun.FromDate(txtTaskTargetTryOut_FDate.Text);
            string TaskTargetTryOut_TDate = fun.ToDate(txtTaskTargetTryOut_TDate.Text);

            string TaskTargetDespach_FDate = fun.FromDate(txtTaskTargetDespach_FDate.Text);
            string TaskTargetDespach_TDate = fun.ToDate(txtTaskTargetDespach_TDate.Text);

            string TaskTargetAssembly_FDate = fun.FromDate(txtTaskTargetAssembly_FDate.Text);
            string TaskTargetAssembly_TDate = fun.ToDate(txtTaskTargetAssembly_TDate.Text);

            string TaskTargetInstalation_FDate = fun.FromDate(txtTaskTargetInstalation_FDate.Text);
            string TaskTargetInstalation_TDate = fun.ToDate(txtTaskTargetInstalation_TDate.Text);

            string TaskCustInspection_FDate = fun.FromDate(txtTaskCustInspection_FDate.Text);
            string TaskCustInspection_TDate = fun.ToDate(txtTaskCustInspection_TDate.Text);

            string MMaterialDate = fun.FromDate(txtManufMaterialDate.Text);
            string BMaterialDate = fun.ToDate(txtBoughtoutMaterialDate.Text);

            int a;
            if (CKInstractionPrimerPainting.Checked == true)
            { a = 1; }
            else { a = 0; }

            int b;
            if (CKInstractionPainting.Checked == true)
            { b = 1; }
            else { b = 0; }

            int c;
            if (CKInstractionSelfCertRept.Checked == true)
            { c = 1; }
            else { c = 0; }


            if (DDLBuyer.SelectedValue != "Select" && txtWorkOrderDate.Text != "" && txtTaskTargetDAP_FDate.Text != "" && txtTaskTargetDAP_TDate.Text != "" && txtTaskDesignFinalization_FDate.Text != "" && txtTaskDesignFinalization_TDate.Text != "" && txtTaskTargetManufg_FDate.Text != "" && txtTaskTargetManufg_TDate.Text != "" && txtTaskTargetTryOut_FDate.Text != "" && txtTaskTargetTryOut_TDate.Text != "" && txtTaskTargetDespach_FDate.Text != "" && txtTaskTargetDespach_TDate.Text != "" && txtTaskTargetAssembly_FDate.Text != "" && txtTaskTargetAssembly_TDate.Text != "" && txtTaskTargetInstalation_FDate.Text != "" && txtTaskTargetInstalation_TDate.Text != "" && txtTaskCustInspection_FDate.Text != "" && txtTaskCustInspection_TDate.Text != "" && CustCode.ToString() != "" && enqId != 0 && pono.ToString() != "" && txtProjectTitle.Text != "" && txtProjectLeader.Text != "" && DDLBusinessGroup.SelectedValue != "Select" && txtedcri.Text!="" && txtShippingAdd.Text != "" && DDLShippingCountry.SelectedValue != "Select" && DDLShippingState.SelectedValue != "Select" && DDLShippingCity.SelectedValue != "Select" && txtShippingContactPerson1.Text != "" && txtShippingContactNo1.Text != "" && txtShippingEmail1.Text != "" && txtShippingContactPerson2.Text != "" && txtShippingContactNo2.Text != "" && txtShippingEmail2.Text != "" && txtShippingFaxNo.Text != "" && txtShippingEccNo.Text != "" && txtShippingTinCstNo.Text != "" && txtShippingTinVatNo.Text != "" && txtInstractionOther.Text != "" && txtInstractionExportCaseMark.Text != "" && fun.EmailValidation(txtShippingEmail1.Text) == true && fun.EmailValidation(txtShippingEmail2.Text) == true && fun.DateValidation(txtWorkOrderDate.Text) == true && fun.DateValidation(txtTaskTargetDAP_FDate.Text) == true && fun.DateValidation(txtTaskTargetDAP_TDate.Text) == true && fun.DateValidation(txtTaskDesignFinalization_FDate.Text) == true && fun.DateValidation(txtTaskDesignFinalization_TDate.Text) == true && fun.DateValidation(txtTaskTargetManufg_FDate.Text) == true && fun.DateValidation(txtTaskTargetManufg_TDate.Text) == true && fun.DateValidation(txtTaskTargetTryOut_FDate.Text) == true && fun.DateValidation(txtTaskTargetTryOut_TDate.Text) == true && fun.DateValidation(txtTaskTargetDespach_FDate.Text) == true && fun.DateValidation(txtTaskTargetDespach_TDate.Text) == true && fun.DateValidation(txtTaskTargetAssembly_FDate.Text) == true && fun.DateValidation(txtTaskTargetAssembly_TDate.Text) == true && fun.DateValidation(txtTaskTargetInstalation_FDate.Text) == true && fun.DateValidation(txtTaskTargetInstalation_TDate.Text) == true && fun.DateValidation(txtTaskCustInspection_FDate.Text) == true && fun.DateValidation(txtTaskCustInspection_TDate.Text) == true && fun.DateValidation(txtManufMaterialDate.Text) == true && fun.DateValidation(txtBoughtoutMaterialDate.Text) == true)
            {
                string cmdstr = fun.update("SD_Cust_WorkOrder_Master",
                   "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',CompId='" + CompId + "',CustomerId='" + CustCode + "',EnqId='" + enqId + "',PONo='" + pono + "',TaskWorkOrderDate='" + WorkOrderDate + "',TaskProjectTitle='" + txtProjectTitle.Text + "',TaskProjectLeader='" + txtProjectLeader.Text + "',TaskBusinessGroup='" + DDLBusinessGroup.SelectedValue + "',TaskTargetDAP_FDate='" + TaskTargetDAP_FDate + "',TaskTargetDAP_TDate='" + TaskTargetDAP_TDate + "',TaskDesignFinalization_FDate='" + TaskDesignFinalization_FDate + "',TaskDesignFinalization_TDate='" + TaskDesignFinalization_TDate + "',TaskTargetManufg_FDate='" + TaskTargetManufg_FDate + "',TaskTargetManufg_TDate='" + TaskTargetManufg_TDate + "',TaskTargetTryOut_FDate='" + TaskTargetTryOut_FDate + "',TaskTargetTryOut_TDate='" + TaskTargetTryOut_TDate + "',TaskTargetDespach_FDate='" + TaskTargetDespach_FDate + "',TaskTargetDespach_TDate='" + TaskTargetDespach_TDate + "',TaskTargetAssembly_FDate='" + TaskTargetAssembly_FDate + "',TaskTargetAssembly_TDate='" + TaskTargetAssembly_TDate + "',TaskTargetInstalation_FDate='" + TaskTargetInstalation_FDate + "',TaskTargetInstalation_TDate='" + TaskTargetInstalation_TDate + "',TaskCustInspection_FDate='" + TaskCustInspection_FDate + "',TaskCustInspection_TDate='" + TaskCustInspection_TDate + "',ShippingAdd='" + txtShippingAdd.Text + "',ShippingCountry='" + DDLShippingCountry.SelectedValue + "',ShippingState='" + DDLShippingState.SelectedValue + "',ShippingCity='" + DDLShippingCity.SelectedValue + "',ShippingContactPerson1='" + txtShippingContactPerson1.Text + "',ShippingContactNo1='" + txtShippingContactNo1.Text + "',ShippingEmail1='" + txtShippingEmail1.Text + "',ShippingContactPerson2='" + txtShippingContactPerson2.Text + "',ShippingContactNo2='" + txtShippingContactNo2.Text + "',ShippingEmail2='" + txtShippingEmail2.Text + "',ShippingFaxNo='" + txtShippingFaxNo.Text + "',ShippingEccNo='" + txtShippingEccNo.Text + "',ShippingTinCstNo='" + txtShippingTinCstNo.Text + "',ShippingTinVatNo='" + txtShippingTinVatNo.Text + "',InstractionPrimerPainting='" + a.ToString() + "',InstractionPainting='" + b.ToString() + "',InstractionSelfCertRept='" + c.ToString() + "',InstractionOther='" + txtInstractionOther.Text + "',InstractionExportCaseMark='" + txtInstractionExportCaseMark.Text + "',InstractionAttachAnnexure='" + InstractionAttachAnnexure.ToString() + "',ManufMaterialDate='" + MMaterialDate + "',BoughtoutMaterialDate='" + BMaterialDate + "',Critics='" + txtedcri.Text + "',Buyer='" + DDLBuyer.SelectedValue + "'", "CustomerId='" + CustCode + "' and Id=" + WOId + " and CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();
                k1++;
            }
            //Code for inserting Details in SD_Cust_WorkOrder_Products_Details table.
            DataSet ds = new DataSet();
            string strselect = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
            SqlCommand cmd1 = new SqlCommand(strselect, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "SD_Cust_WorkOrder_Products_Temp");
            string strInsert="";

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    strInsert = fun.insert("SD_Cust_WorkOrder_Products_Details", "MId,SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + WOId + "','" + ds.Tables[0].Rows[j]["SessionId"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[j]["CompId"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[j]["FinYearId"]) + "','" + ds.Tables[0].Rows[j]["ItemCode"].ToString() + "','" + ds.Tables[0].Rows[j]["Description"].ToString() + "','" + Convert.ToDouble(decimal.Parse(ds.Tables[0].Rows[j]["Qty"].ToString()).ToString("N3")) + "'");

                    SqlCommand cmd2 = new SqlCommand(strInsert, con);
                    cmd2.ExecuteNonQuery();
                }

                //Code for deleting Details in SD_Cust_WorkOrder_Products_Temp table.
                string strDelete = fun.delete("SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "'");
                SqlCommand cmddelete = new SqlCommand(strDelete, con);
                cmddelete.ExecuteNonQuery();
                k2++;
            }
            if (k1 > 0 && (k1 > 0 || k2 > 0))
            {
                Page.Response.Redirect("~/Module/SalesDistribution/Transactions/WorkOrder_Edit.aspx?ModId=2&SubModId=13");
            }
        }
        catch (Exception exs) { }
        finally
        { con.Close(); }
       
    }
    protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
              TabContainer1.ActiveTabIndex= 0;
    }
    protected void DDLBusinessGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
             TabContainer1.ActiveTabIndex= 0;
    }    
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       try
        {            
            int index = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[index];           
            string StrDesc = (((TextBox)row.FindControl("txtDescription0")).Text);
            string StrItemCode = (((TextBox)row.FindControl("txtItemCode0")).Text);
            double  StrQty = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtQty0")).Text).ToString("N3"));
            if (StrDesc != "" && StrItemCode != "" && StrQty.ToString() != "" && fun.NumberValidationQty(StrQty.ToString()) == true)
            {
                SqlDataSource1.UpdateParameters["Description"].DefaultValue = StrDesc;
                SqlDataSource1.UpdateParameters["ItemCode"].DefaultValue = StrItemCode;
                SqlDataSource1.UpdateParameters["Qty"].DefaultValue = StrQty.ToString();
                SqlDataSource1.Update();

            }
        }
       catch (Exception ex) { }
        
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
                LinkButton del = (LinkButton)e.Row.Cells[1].Controls[0];
                del.Attributes.Add("onclick", "return confirmationUpdate();");

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del1 = (LinkButton)e.Row.Cells[2].Controls[0];
                del1.Attributes.Add("onclick", "return confirmationDelete();");
            }
        }
       catch (Exception ex) { }
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
                LinkButton del = (LinkButton)e.Row.Cells[1].Controls[0];
                del.Attributes.Add("onclick", "return confirmationUpdate();");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del1 = (LinkButton)e.Row.Cells[2].Controls[0];
                del1.Attributes.Add("onclick", "return confirmationDelete();");
            }
        }
       catch (Exception ex) { }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);       

      try
        {
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string DescItem = ((TextBox)row.FindControl("txtItemCode")).Text.ToString().Trim();
            string DESC1 = ((TextBox)row.FindControl("txtDesc")).Text.ToString().Trim();
            double rate = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtQty")).Text).ToString("N3"));
            if (DescItem != "" && DESC1 != "" && rate.ToString() != "" && fun.NumberValidationQty(rate.ToString()) == true)
            {
                string sql = fun.update("SD_Cust_WorkOrder_Products_Temp", "ItemCode='" + DescItem + "',Description='" + DESC1 + "',Qty='" + rate + "' ", "Id=" + id + " And CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int temp = cmd.ExecuteNonQuery();
                con.Close();
                if (temp == 1)
                {

                    lblMessage.Text = "Record updated successfully";
                }
                GridView1.EditIndex = -1;
                FillGrid();

            }
        }
        catch (Exception ex)
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
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            int Eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM SD_Cust_WorkOrder_Products_Temp  WHERE Id=" + Eid + " And CompId='" + CompId + "'", con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record deleted successfully";
            }
            con.Close();
            FillGrid();

        }
        catch (Exception ex)
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

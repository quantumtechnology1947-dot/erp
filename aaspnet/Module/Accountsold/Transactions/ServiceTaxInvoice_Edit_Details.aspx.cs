using System;
using System.Collections;
using System.Collections.Generic;
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
using iTextSharp.text;
using MKB.TimePicker;

public partial class Module_Accounts_Transactions_ServiceTaxInvoice_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string invId = "";  
    string CCode = "";
    string  InvNo = "";
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        con = new SqlConnection(connStr);

        try
        {
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            invId = fun.Decrypt(Request.QueryString["invid"].ToString());
            
            InvNo = fun.Decrypt(Request.QueryString["InvNo"].ToString());
            CCode = fun.Decrypt(Request.QueryString["cid"].ToString());
            sId = Session["username"].ToString();

            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");


            if (!IsPostBack)
            {

                fun.dropdownCountry(DrpByCountry, DrpByState);
                fun.dropdownCountry(DrpCoCountry, DrpCoState);             

                
                DataSet ds = new DataSet();
                

                string sqlinv = fun.select("Id,SysDate,SysTime,CompId,FinYearId,SessionId,InvoiceNo,POId,PONo,WONo,DateOfIssueInvoice,TimeOfIssueInvoice,DutyRate,CustomerCode,CustomerCategory,Buyer_name,Buyer_add,Buyer_city,Buyer_state,Buyer_country,Buyer_cotper,Buyer_ph,Buyer_email,Buyer_ecc,Buyer_tin,Buyer_mob,Buyer_fax,Buyer_vat,Cong_name,Cong_add,Cong_city,Cong_state,Cong_country,Cong_cotper,Cong_ph,Cong_email,Cong_ecc,Cong_tin,Cong_mob,Cong_fax,Cong_vat,AddType,AddAmt,DeductionType,Deduction,ServiceTax,TaxableServices", "tblACC_ServiceTaxInvoice_Master",
        " CompId='" + CompId + "'  And Id='" + invId + "' ");
                

                SqlCommand cmdinv = new SqlCommand(sqlinv, con);
                SqlDataAdapter dainv = new SqlDataAdapter(cmdinv);
                DataSet dsinv = new DataSet();
                dainv.Fill(dsinv);
                if (dsinv.Tables[0].Rows.Count > 0)
                {
                    lblSrTaxInvoiceNo.Text = dsinv.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    LblPONo.Text = dsinv.Tables[0].Rows[0]["PONo"].ToString();
                    string WN = dsinv.Tables[0].Rows[0]["WONo"].ToString();

                    string[] split = WN.Split(new Char[] { ',' });
                    string WoNO = "";
                    for (int d = 0; d < split.Length - 1; d++)
                    {

                        string sqlWoNo = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + split[d] + "' AND CompId='" + CompId + "'");
                        SqlCommand cmdWoNo = new SqlCommand(sqlWoNo, con);
                        SqlDataAdapter daWoNo = new SqlDataAdapter(cmdWoNo);
                        DataSet dsWoNo = new DataSet();
                        daWoNo.Fill(dsWoNo);

                        if (dsWoNo.Tables[0].Rows.Count > 0)
                        {
                            WoNO += dsWoNo.Tables[0].Rows[0][0].ToString() + ",";
                        }
                        LblWONo.Text = WoNO;
                    }


                    // To Get PODate

                    string sqlPODt = fun.select("PODate", "SD_Cust_PO_Master", "POId='" + dsinv.Tables[0].Rows[0]["POId"].ToString() + "' ANd CompId='" + CompId + "'");
                    SqlCommand cmdPODt = new SqlCommand(sqlPODt, con);
                    SqlDataAdapter daPODt = new SqlDataAdapter(cmdPODt);
                    DataSet dsPODt = new DataSet();
                    daPODt.Fill(dsPODt);

                    if (dsPODt.Tables[0].Rows.Count > 0)
                    {
                        lblPodt.Text = fun.FromDateDMY(dsPODt.Tables[0].Rows[0][0].ToString());
                    }


                    string dt = dsinv.Tables[0].Rows[0]["SysDate"].ToString();
                    lblInvDate.Text = fun.FromDateDMY(dt);

                    TxtDateofIssueInvoice.Text = fun.FromDateDMY(dsinv.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
                    TxtDutyRate.Text = dsinv.Tables[0].Rows[0]["DutyRate"].ToString();
                    DrpCategory.SelectedValue = dsinv.Tables[0].Rows[0]["CustomerCategory"].ToString();
                    DrpTaxableServices.SelectedValue = dsinv.Tables[0].Rows[0]["TaxableServices"].ToString();
                    TxtByCName.Text = dsinv.Tables[0].Rows[0]["Buyer_cotper"].ToString();
                    TxtByAddress.Text = dsinv.Tables[0].Rows[0]["Buyer_add"].ToString();
                    TxtBYName.Text = dsinv.Tables[0].Rows[0]["Buyer_name"].ToString();
                    TxtByPhone.Text = dsinv.Tables[0].Rows[0]["Buyer_ph"].ToString();
                    TxtByMobile.Text = dsinv.Tables[0].Rows[0]["Buyer_mob"].ToString();
                    TxtByFaxNo.Text = dsinv.Tables[0].Rows[0]["Buyer_fax"].ToString();
                    TxtByEmail.Text = dsinv.Tables[0].Rows[0]["Buyer_email"].ToString();
                    TxtByTINCSTNo.Text = dsinv.Tables[0].Rows[0]["Buyer_tin"].ToString();
                    TxtByTINVATNo.Text = dsinv.Tables[0].Rows[0]["Buyer_vat"].ToString();
                    TxtByECCNo.Text = dsinv.Tables[0].Rows[0]["Buyer_ecc"].ToString();
                    TxtCName.Text = dsinv.Tables[0].Rows[0]["Cong_name"].ToString();
                    TxtCAddress.Text = dsinv.Tables[0].Rows[0]["Cong_add"].ToString();
                    TxtCoPersonName.Text = dsinv.Tables[0].Rows[0]["Cong_cotper"].ToString();
                    TxtCoPhoneNo.Text = dsinv.Tables[0].Rows[0]["Cong_ph"].ToString();
                    TxtCoMobileNo.Text = dsinv.Tables[0].Rows[0]["Cong_mob"].ToString();
                    TxtCoFaxNo.Text = dsinv.Tables[0].Rows[0]["Cong_fax"].ToString();
                    TxtCoEmail.Text = dsinv.Tables[0].Rows[0]["Cong_email"].ToString();
                    TxtCoTinCSTNo.Text = dsinv.Tables[0].Rows[0]["Cong_tin"].ToString();
                    TxtCoTinVatNo.Text = dsinv.Tables[0].Rows[0]["Cong_vat"].ToString();
                    TxtECoCCNo.Text = dsinv.Tables[0].Rows[0]["Cong_ecc"].ToString();
                    TxtAdd.Text = dsinv.Tables[0].Rows[0]["AddAmt"].ToString();
                    TxtDeduct.Text = dsinv.Tables[0].Rows[0]["Deduction"].ToString();
                    DrpServiceTax.SelectedValue = dsinv.Tables[0].Rows[0]["ServiceTax"].ToString();
                    DrpAdd.SelectedValue = dsinv.Tables[0].Rows[0]["AddType"].ToString();
                    DrpDed.SelectedValue = dsinv.Tables[0].Rows[0]["DeductionType"].ToString();

                    //Buyer Country  
                    fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dsinv.Tables[0].Rows[0]["Buyer_country"].ToString() + "'");
                    DrpByCountry.SelectedIndex = 0;
                    fun.dropdownCountry(DrpByCountry, DrpByState);

                    // Buyer State
                    fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
                    fun.dropdownStatebyId(DrpByState, "CId='" + dsinv.Tables[0].Rows[0]["Buyer_country"].ToString() + "' AND SId='" + dsinv.Tables[0].Rows[0]["Buyer_state"].ToString() + "'");
                
                    DrpByState.SelectedValue = dsinv.Tables[0].Rows[0]["Buyer_state"].ToString();
                    // Buyer City
                    fun.dropdownCity(DrpByCity, DrpByState);
                    fun.dropdownCitybyId(DrpByCity, "SId='" + dsinv.Tables[0].Rows[0]["Buyer_state"].ToString() + "' AND CityId='" + dsinv.Tables[0].Rows[0]["Buyer_city"].ToString() + "'");
                 
                    DrpByCity.SelectedValue = dsinv.Tables[0].Rows[0]["Buyer_city"].ToString();
                    //Consignee Country  
                    fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dsinv.Tables[0].Rows[0]["Cong_country"].ToString() + "'");
                    DrpCoCountry.SelectedIndex = 0;
                    fun.dropdownCountry(DrpCoCountry, DrpCoState);

                    // Consignee State
                    fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
                    fun.dropdownStatebyId(DrpCoState, "CId='" + dsinv.Tables[0].Rows[0]["Cong_country"].ToString() + "' AND SId='" + dsinv.Tables[0].Rows[0]["Cong_state"].ToString() + "'");
                    
                    DrpCoState.SelectedValue = dsinv.Tables[0].Rows[0]["Cong_state"].ToString();
                    // Consignee City
                    fun.dropdownCity(DrpCoCity, DrpCoState);
                    fun.dropdownCitybyId(DrpCoCity, "SId='" + dsinv.Tables[0].Rows[0]["Cong_state"].ToString() + "' AND CityId='" + dsinv.Tables[0].Rows[0]["Cong_city"].ToString() + "'");
                  
                    DrpCoCity.SelectedValue = dsinv.Tables[0].Rows[0]["Cong_city"].ToString();
                    string TimeSel = dsinv.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
                    char[] delimiterChars = { ':', ' ' };
                    string[] words = TimeSel.Split(delimiterChars);
                    string TM = words[3];
                    int H = Convert.ToInt32(words[0]);
                    int M = Convert.ToInt32(words[1]);
                    int S = Convert.ToInt32(words[2]);
                    fun.TimeSelector(H, M, S, TM, TimeSelector1);
                }

                this.fillgrid();

            }
        }
        catch (Exception ex) { }
 }

    public void fillgrid()
    {

        try
        {
            string connStr = fun.Connection();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("ItemDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("ReqQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("AmtInPer", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("ItemId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("RemainingQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Symbol1", typeof(string)));
            DataRow dr;

            string sql = fun.select("tblACC_ServiceTaxInvoice_Details.Id,tblACC_ServiceTaxInvoice_Details.InvoiceNo,tblACC_ServiceTaxInvoice_Details.ItemId,tblACC_ServiceTaxInvoice_Details.Unit,tblACC_ServiceTaxInvoice_Details.Qty,tblACC_ServiceTaxInvoice_Details.ReqQty,tblACC_ServiceTaxInvoice_Details.AmtInPer,tblACC_ServiceTaxInvoice_Details.Rate,tblACC_ServiceTaxInvoice_Master.POId", "tblACC_ServiceTaxInvoice_Details,tblACC_ServiceTaxInvoice_Master", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id AND tblACC_ServiceTaxInvoice_Master.Id= '" + invId + "' AND tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'");

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();

                // For Item Desc
               
                string sql1 = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", " SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + DS.Tables[0].Rows[p]["POId"] + "'AND SD_Cust_PO_Details.Id='"+DS.Tables[0].Rows[p]["ItemId"]+"'");

                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                da1.Fill(DS1);
                if (DS1.Tables[0].Rows.Count > 0)
                {
                    dr[1] = DS1.Tables[0].Rows[0]["ItemDesc"].ToString();
                }
                // For Symbol           
                string sql2 = fun.select("Symbol", "Unit_Master", "Id='" + DS.Tables[0].Rows[p]["Unit"].ToString() + "' ");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);
                dr[2] = DS2.Tables[0].Rows[0]["Symbol"].ToString();
                dr[3] = Convert.ToDouble(decimal.Parse((DS.Tables[0].Rows[p]["Qty"]).ToString()).ToString("N3"));
                dr[4] = Convert.ToDouble(decimal.Parse((DS.Tables[0].Rows[p]["ReqQty"]).ToString()).ToString("N3"));
                dr[5] =  Convert.ToDouble(decimal.Parse((DS.Tables[0].Rows[p]["AmtInPer"]).ToString()).ToString("N2"));
                dr[6] = Convert.ToDouble(decimal.Parse((DS.Tables[0].Rows[p]["Rate"]).ToString()).ToString("N2"));
                double Qty = 0;
                double rmnqty = 0;

                string sqlrmn = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "' And tblACC_ServiceTaxInvoice_Details.ItemId='" + DS.Tables[0].Rows[p]["ItemId"].ToString() + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
                SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                DataSet dsrmn = new DataSet();
                darmn.Fill(dsrmn);
                double TotInvQty = 0;
                if (dsrmn.Tables[0].Rows.Count > 0)
                {
                    TotInvQty = Convert.ToDouble(decimal.Parse((dsrmn.Tables[0].Rows[0]["ReqQty"]).ToString()).ToString("N3"));
                }
                Qty =  Convert.ToDouble(decimal.Parse((DS.Tables[0].Rows[p]["Qty"]).ToString()).ToString("N3"));
                rmnqty =Qty - TotInvQty;
                dr[7] = DS.Tables[0].Rows[p]["ItemId"].ToString();
                dr[8] = rmnqty;

                // For Symbol           
                string sql21 = fun.select("Symbol", "Unit_Master", "Id='" + DS1.Tables[0].Rows[0]["Unit"].ToString() + "' ");
                SqlCommand cmd21 = new SqlCommand(sql21, con);
                SqlDataAdapter da21 = new SqlDataAdapter(cmd21);
                DataSet DS21 = new DataSet();
                da21.Fill(DS21);
                dr[9] = DS21.Tables[0].Rows[0]["Symbol"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch(Exception ex){}
      }

    protected void BtnBuy_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            int j = 0;
            double ReqQty = 0;
            double rmnqty = 0;
            double Qty = 0;
            double Amt = 0;
            double ReqQty1 = 0;
            int uni = 0;
            con.Open();

            if (DrpByCountry.SelectedIndex != 0 && DrpByState.SelectedIndex != 0 && DrpByCity.SelectedIndex != 0 && DrpCoCountry.SelectedIndex != 0 && DrpCoState.SelectedIndex != 0 && DrpCoCity.SelectedIndex != 0 )
            {

                if (TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) == true && TxtDutyRate.Text != "" && TxtBYName.Text != "" && TxtByAddress.Text != "" && TxtByCName.Text != "" && TxtByPhone.Text != "" && TxtByEmail.Text != "" && TxtByECCNo.Text != "" && TxtByTINCSTNo.Text != "" && TxtByMobile.Text != "" && TxtByFaxNo.Text != "" && TxtByTINVATNo.Text != "" && TxtCName.Text != "" && TxtCAddress.Text != "" && TxtCoPersonName.Text != "" && TxtCoPhoneNo.Text != "" && TxtCoEmail.Text != "" && TxtECoCCNo.Text != "" && TxtCoTinCSTNo.Text != "" && TxtCoMobileNo.Text != "" && TxtCoFaxNo.Text != "" && TxtCoTinVatNo.Text != "" && TxtAdd.Text != "" && TxtDeduct.Text != "" && fun.EmailValidation(TxtByEmail.Text) == true && fun.EmailValidation(TxtCoEmail.Text) == true && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) == true && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text) == true )
                {
                    string TimeSelector = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm.ToString();

                    string CDate = fun.getCurrDate();
                    string CTime = fun.getCurrTime();

                    string sqlupdate = fun.update("tblACC_ServiceTaxInvoice_Master", " SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',DateOfIssueInvoice='" + fun.FromDate(TxtDateofIssueInvoice.Text) + "' ,TimeOfIssueInvoice='" + TimeSelector + "',DutyRate='" + TxtDutyRate.Text + "',CustomerCategory='" + DrpCategory.SelectedValue + "',Buyer_name='" + TxtBYName.Text + "',  Buyer_add='" + TxtByAddress.Text + "',Buyer_country='" + DrpByCountry.SelectedValue + "',Buyer_state='" + DrpByState.SelectedValue + "', Buyer_city='" + DrpByCity.SelectedValue + "',Buyer_cotper='" + TxtByCName.Text + "',Buyer_ph='" + TxtByPhone.Text + "',Buyer_email='" + TxtByEmail.Text + "',Buyer_ecc='" + TxtByECCNo.Text + "',Buyer_tin='" + TxtByTINCSTNo.Text + "'  ,Buyer_mob='" + TxtByMobile.Text + "'  ,Buyer_fax='" + TxtByFaxNo.Text + "',Buyer_vat='" + TxtByTINVATNo.Text + "',Cong_name='" + TxtCName.Text + "',Cong_add='" + TxtCAddress.Text + "',Cong_Country='" + DrpCoCountry.SelectedValue + "',Cong_state='" + DrpCoState.SelectedValue + "',Cong_city='" + DrpCoCity.SelectedValue + "',Cong_cotper='" + TxtCoPersonName.Text + "' ,  Cong_ph='" + TxtCoPhoneNo.Text + "',Cong_email='" + TxtCoEmail.Text + "',Cong_ecc='" + TxtECoCCNo.Text + "',Cong_tin='" + TxtCoTinCSTNo.Text + "',Cong_mob='" + TxtCoMobileNo.Text + "',Cong_fax='" + TxtCoFaxNo.Text + "',Cong_vat='" + TxtCoTinVatNo.Text + "',AddType='" + DrpAdd.SelectedValue + "',AddAmt='" + TxtAdd.Text + "',DeductionType='" + DrpDed.SelectedValue + "',Deduction='" + TxtDeduct.Text + "',ServiceTax='" + DrpServiceTax.SelectedValue + "',TaxableServices= '" + DrpTaxableServices.SelectedValue + "'", "CompId='" + CompId + "' And Id='" + invId + "'");

                    SqlCommand cmd = new SqlCommand(sqlupdate, con);
                    cmd.ExecuteNonQuery();

                }

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("TxtAmt")).Text != "" && ((TextBox)grv.FindControl("TxtReqQty")).Text != "")
                    {
                        int Item = Convert.ToInt32(((Label)grv.FindControl("lblItemId")).Text);
                        Qty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblQty")).Text).ToString()).ToString("N3"));
                        ReqQty1 = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblReqQty")).Text).ToString()).ToString("N3"));
                        ReqQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtReqQty")).Text).ToString()).ToString("N3"));
                        Amt = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtAmt")).Text).ToString()).ToString("N2"));
                        uni = Convert.ToInt32(((DropDownList)grv.FindControl("DrpUnitQty")).SelectedValue);
                        string sqlrmn = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'And tblACC_ServiceTaxInvoice_Details.ItemId='" + Item + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
                        SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                        SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                        DataSet dsrmn = new DataSet();
                        darmn.Fill(dsrmn); 
                        double TotInvQty = 0;

                        if (dsrmn.Tables[0].Rows.Count > 0)
                        {
                            TotInvQty = Convert.ToDouble(decimal.Parse((dsrmn.Tables[0].Rows[0]["ReqQty"]).ToString()).ToString("N3"));
                        }
                        rmnqty = Qty - TotInvQty;

                        if ((rmnqty + ReqQty1) >= ReqQty)
                        {
                            double rate = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblRate")).Text).ToString()).ToString("N2"));
                            string unit = ((DropDownList)grv.FindControl("DrpUnitQty")).SelectedValue;
                            int Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                            string sqltemp = fun.update("tblACC_ServiceTaxInvoice_Details", "ReqQty='" + ReqQty + "',Unit='" + uni + "',AmtInPer='" + Amt + "'", "MId='" + invId + "' AND Id='" + Id + "'");
                            SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                            cmdtemp.ExecuteNonQuery();
                        }
                        else
                        {
                            j++;
                        }
                    }
                }

                if (j > 0)
                {
                    string mystring = string.Empty;
                    mystring = "Input data is invalid.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
                else
                {

                    Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
                }

            }
        }
         catch (Exception ex) { }

        finally
        {
            con.Close();
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
        this.fillgrid();
    }


    protected void ck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("ck")).Checked == true)
                {
                    ((TextBox)grv.FindControl("TxtReqQty")).Visible = true;
                    ((TextBox)grv.FindControl("TxtAmt")).Visible = true;
                    ((Label)grv.FindControl("lblAmt")).Visible = false;
                    ((Label)grv.FindControl("lblReqQty")).Visible = false;
                    ((Label)grv.FindControl("lblUnitQty")).Visible = false;
                    ((DropDownList)grv.FindControl("DrpUnitQty")).Visible = true;
                }
                else
                {
                    ((Label)grv.FindControl("lblAmt")).Visible = true;
                    ((Label)grv.FindControl("lblReqQty")).Visible = true;
                    ((TextBox)grv.FindControl("TxtReqQty")).Visible = false;
                    ((TextBox)grv.FindControl("TxtAmt")).Visible = false;
                    ((DropDownList)grv.FindControl("DrpUnitQty")).Visible = false;
                    ((Label)grv.FindControl("lblUnitQty")).Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string CustCode = fun.getCode(TxtCName.Text);

            string sqlcus = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");

            SqlCommand cmdcus = new SqlCommand(sqlcus, con);
            SqlDataAdapter dacus = new SqlDataAdapter(cmdcus);
            DataSet dscus = new DataSet();
            dacus.Fill(dscus);

            if (dscus.Tables[0].Rows.Count > 0)
            {
                TxtCAddress.Text = dscus.Tables[0].Rows[0]["MaterialDelAddress"].ToString();

                fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                DrpCoCountry.SelectedIndex = 0;
                fun.dropdownCountry(DrpCoCountry, DrpCoState);

                //State
                fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
                fun.dropdownStatebyId(DrpCoState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
                DrpCoState.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelState"].ToString();

                //City
                fun.dropdownCity(DrpCoCity, DrpCoState);
                fun.dropdownCitybyId(DrpCoCity, "SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");

                DrpCoCity.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString();
                TxtCoFaxNo.Text = dscus.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
                TxtCoPersonName.Text = dscus.Tables[0].Rows[0]["ContactPerson"].ToString();
                TxtCoPhoneNo.Text = dscus.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
                TxtCoTinCSTNo.Text = dscus.Tables[0].Rows[0]["TinCstNo"].ToString();
                TxtCoTinVatNo.Text = dscus.Tables[0].Rows[0]["TinVatNo"].ToString();
                TxtCoMobileNo.Text = dscus.Tables[0].Rows[0]["ContactNo"].ToString();
                TxtCoEmail.Text = dscus.Tables[0].Rows[0]["Email"].ToString();
                TxtECoCCNo.Text = dscus.Tables[0].Rows[0]["EccNo"].ToString();
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

                string mystring = string.Empty;
                mystring = "Invalid selection of Customer data.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception et)
        {

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            string CustCode = fun.getCode(TxtBYName.Text);

            string sqlcus = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
            SqlCommand cmdcus = new SqlCommand(sqlcus, con);
            SqlDataAdapter dacus = new SqlDataAdapter(cmdcus);
            DataSet dscus = new DataSet();
            dacus.Fill(dscus);

            if (dscus.Tables[0].Rows.Count > 0)
            {

                TxtCName.Text = dscus.Tables[0].Rows[0]["Customer"].ToString();
                TxtCAddress.Text = dscus.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
                fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                DrpCoCountry.SelectedIndex = 0;
                fun.dropdownCountry(DrpCoCountry, DrpCoState);

                //State
                fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
                fun.dropdownStatebyId(DrpCoState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
                DrpCoState.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelState"].ToString();

                //City
                fun.dropdownCity(DrpCoCity, DrpCoState);
                fun.dropdownCitybyId(DrpCoCity, "SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");

                DrpCoCity.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString();
                TxtCoFaxNo.Text = dscus.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
                TxtCoPersonName.Text = dscus.Tables[0].Rows[0]["ContactPerson"].ToString();
                TxtCoPhoneNo.Text = dscus.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
                TxtCoTinCSTNo.Text = dscus.Tables[0].Rows[0]["TinCstNo"].ToString();
                TxtCoTinVatNo.Text = dscus.Tables[0].Rows[0]["TinVatNo"].ToString();
                TxtCoMobileNo.Text = dscus.Tables[0].Rows[0]["ContactNo"].ToString();
                TxtCoEmail.Text = dscus.Tables[0].Rows[0]["Email"].ToString();
                TxtECoCCNo.Text = dscus.Tables[0].Rows[0]["EccNo"].ToString();
            }
            else
            {
                TxtCName.Text = "";
                string mystring = string.Empty;
                mystring = "Invalid selection of Customer data.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception et)
        {

        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "SD_Cust_master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string CustCode = fun.getCode(TxtBYName.Text);

            string sqlcus = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");

            SqlCommand cmdcus = new SqlCommand(sqlcus, con);
            SqlDataAdapter dacus = new SqlDataAdapter(cmdcus);
            DataSet dscus = new DataSet();
            dacus.Fill(dscus);

            if (dscus.Tables[0].Rows.Count > 0)
            {
                TxtByAddress.Text = dscus.Tables[0].Rows[0]["MaterialDelAddress"].ToString();

                fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                DrpByCountry.SelectedIndex = 0;
                fun.dropdownCountry(DrpByCountry, DrpByState);

                //State
                fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
                fun.dropdownStatebyId(DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
                DrpByState.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelState"].ToString();

                //City
                fun.dropdownCity(DrpByCity, DrpByState);
                fun.dropdownCitybyId(DrpByCity, "SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");

                DrpByCity.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString();
                TxtByFaxNo.Text = dscus.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
                TxtByCName.Text = dscus.Tables[0].Rows[0]["ContactPerson"].ToString();
                TxtByPhone.Text = dscus.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
                TxtByTINCSTNo.Text = dscus.Tables[0].Rows[0]["TinCstNo"].ToString();
                TxtByTINVATNo.Text = dscus.Tables[0].Rows[0]["TinVatNo"].ToString();
                TxtByMobile.Text = dscus.Tables[0].Rows[0]["ContactNo"].ToString();
                TxtByEmail.Text = dscus.Tables[0].Rows[0]["Email"].ToString();
                TxtByECCNo.Text = dscus.Tables[0].Rows[0]["EccNo"].ToString();
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

                string mystring = string.Empty;
                mystring = "Invalid selection of Customer data.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception et)
        {

        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_Edit.aspx?ModId=11&SubModId=52");
    }
}
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

public partial class Module_Accounts_Transactions_ServiceTaxInvoice_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string CDate = "";
    string CTime = "";
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string WN = "";
    string PN = "";
    string CCode = "";
    string pdate = "";
    string POId = "";
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        con = new SqlConnection(connStr);

        try
        {
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            WN = fun.Decrypt(Request.QueryString["wn"].ToString());
            PN = fun.Decrypt(Request.QueryString["pn"].ToString());
            POId = fun.Decrypt(Request.QueryString["poid"].ToString());
            CCode = fun.Decrypt(Request.QueryString["cid"].ToString());
            pdate = fun.Decrypt(Request.QueryString["date"].ToString());
            string dt = fun.getCurrDate();
            LblInvDate.Text = fun.FromDateDMY(dt);
            LblPODate.Text = pdate;
            LblPONo.Text = PN;            
            DataSet ds = new DataSet();
            
            con.Open();
            string[] split = WN.Split(new Char[] { ',' });
            string WoNO = "";
            for (int d = 0; d < split.Length - 1; d++)
            {

                string sqlWoNo = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + split[d] + "'  AND CompId='" + CompId + "'");
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



            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            if (!IsPostBack)
            {


                string cmdStr = fun.select("InvoiceNo", "tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by InvoiceNo desc");

                SqlCommand cmd11 = new SqlCommand(cmdStr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd11);
                DataSet DS = new DataSet();
                da.Fill(DS, "tblACC_ServiceTaxInvoice_Master");
                string InvNo = "";

                if (DS.Tables[0].Rows.Count > 0)
                {
                    InvNo = (Convert.ToInt32(DS.Tables[0].Rows[0]["InvoiceNo"]) + 1).ToString("D4");
                }
                else
                {
                    InvNo = "0001";
                }
                TxtInvNo.Text = InvNo;



                fun.dropdownCountry(DrpByCountry, DrpByState);
                fun.dropdownCountry(DrpCoCountry, DrpCoState);
                this.fillgrid();

                // For Service Tax
                String sqlServiceTax = fun.select("Id", "tblExciseser_Master", "LiveSerTax='1'");
                SqlCommand cmdServiceTax = new SqlCommand(sqlServiceTax, con);
                SqlDataAdapter daServiceTax = new SqlDataAdapter(cmdServiceTax);
                DataSet dsServiceTax = new DataSet();
                daServiceTax.Fill(dsServiceTax);
                if (dsServiceTax.Tables[0].Rows.Count > 0)
                {
                    DrpServiceTax.SelectedValue = dsServiceTax.Tables[0].Rows[0]["Id"].ToString();
                }

                // For Buyer
                String sqlcus = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CCode + "' And CompId='" + CompId + "'");
                SqlCommand cmdcus = new SqlCommand(sqlcus, con);
                SqlDataAdapter dacus = new SqlDataAdapter(cmdcus);
                DataSet dscus = new DataSet();
                dacus.Fill(dscus);
                if (dscus.Tables[0].Rows.Count > 0)
                {
                    TxtBYName.Text = dscus.Tables[0].Rows[0]["Customer"].ToString();
                    TxtByAddress.Text = dscus.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
                    //Buyer Country  
                    fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                    DrpByCountry.SelectedIndex = 0;
                    fun.dropdownCountry(DrpByCountry, DrpByState);
                    // Buyer State
                    fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
                    fun.dropdownStatebyId(DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
                    //DrpByState.SelectedIndex = DrpByState.Items.Count - 1;
                    DrpByState.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelState"].ToString();
                    // Buyer City
                    fun.dropdownCity(DrpByCity, DrpByState);
                    fun.dropdownCitybyId(DrpByCity, "SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
                    // DrpByCity.SelectedIndex = DrpByCity.Items.Count - 1;
                    DrpByCity.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelCity"].ToString();

                    TxtByCName.Text = dscus.Tables[0].Rows[0]["ContactPerson"].ToString();
                    TxtByPhone.Text = dscus.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
                    TxtByFaxNo.Text = dscus.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
                    TxtByTINCSTNo.Text = dscus.Tables[0].Rows[0]["TinCstNo"].ToString();
                    TxtByTINVATNo.Text = dscus.Tables[0].Rows[0]["TinVatNo"].ToString();
                    TxtByMobile.Text = dscus.Tables[0].Rows[0]["ContactNo"].ToString();
                    TxtByEmail.Text = dscus.Tables[0].Rows[0]["Email"].ToString();
                    TxtByECCNo.Text = dscus.Tables[0].Rows[0]["EccNo"].ToString();
                }

                //// For Consignee
                //String sqlcust1 = fun.select("CustomerId,ShippingAdd,ShippingCountry,ShippingState,ShippingCity,ShippingContactPerson1,ShippingEmail1,ShippingContactNo1,ShippingFaxNo,ShippingEccNo,ShippingTinCstNo,ShippingTinVatNo", "SD_Cust_WorkOrder_Master", "WONo='" + WN + "' And CompId='" + CompId + "'");
                //SqlCommand cmdcust1 = new SqlCommand(sqlcust1, con);
                //SqlDataAdapter dacust1 = new SqlDataAdapter(cmdcust1);
                //DataSet dscust1 = new DataSet();
                //dacust1.Fill(dscust1);
                //if (dscust1.Tables[0].Rows.Count > 0)
                //{
                //    SqlCommand cmcname = new SqlCommand(fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + dscust1.Tables[0].Rows[0]["CustomerId"] + "' And CompId='" + CompId + "'"), con);
                //    SqlDataAdapter dacname = new SqlDataAdapter(cmcname);
                //    DataSet dscname = new DataSet();
                //    dacname.Fill(dscname);

                //    if (dscname.Tables[0].Rows.Count > 0)
                //    {
                //        TxtCName.Text = dscname.Tables[0].Rows[0]["CustomerName"].ToString();
                //    }

                //    TxtCAddress.Text = dscust1.Tables[0].Rows[0]["ShippingAdd"].ToString();
                //    TxtCoPersonName.Text = dscust1.Tables[0].Rows[0]["ShippingContactPerson1"].ToString();
                //    TxtCoPhoneNo.Text = dscust1.Tables[0].Rows[0]["ShippingContactNo1"].ToString();
                //    //  TxtCoMobileNo.Text = dsinv.Tables[0].Rows[0]["Cong_mob"].ToString();
                //    TxtCoFaxNo.Text = dscust1.Tables[0].Rows[0]["ShippingFaxNo"].ToString();
                //    TxtCoEmail.Text = dscust1.Tables[0].Rows[0]["ShippingEmail1"].ToString();
                //    TxtCoTinCSTNo.Text = dscust1.Tables[0].Rows[0]["ShippingTinCstNo"].ToString();
                //    TxtCoTinVatNo.Text = dscust1.Tables[0].Rows[0]["ShippingTinVatNo"].ToString();
                //    TxtECoCCNo.Text = dscust1.Tables[0].Rows[0]["ShippingEccNo"].ToString();

                //    //Consignee Country  
                //    fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dscust1.Tables[0].Rows[0]["ShippingCountry"].ToString() + "'");
                //    DrpCoCountry.SelectedIndex = 0;
                //    fun.dropdownCountry(DrpCoCountry, DrpCoState);
                //    // Consignee State
                //    fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
                //    fun.dropdownStatebyId(DrpCoState, "CId='" + dscust1.Tables[0].Rows[0]["ShippingCountry"].ToString() + "' AND SId='" + dscust1.Tables[0].Rows[0]["ShippingState"].ToString() + "'");
                //    //DrpCoState.SelectedIndex = DrpCoState.Items.Count - 1;
                //    DrpCoState.SelectedValue = dscust1.Tables[0].Rows[0]["ShippingState"].ToString();
                //    // Consignee City
                //    fun.dropdownCity(DrpCoCity, DrpCoState);
                //    fun.dropdownCitybyId(DrpCoCity, "SId='" + dscust1.Tables[0].Rows[0]["ShippingState"].ToString() + "' AND CityId='" + dscust1.Tables[0].Rows[0]["ShippingCity"].ToString() + "'");
                //    //DrpCoCity.SelectedIndex = DrpCoCity.Items.Count - 1;
                //    DrpCoCity.SelectedValue = dscust1.Tables[0].Rows[0]["ShippingCity"].ToString();
                //}

            }
            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
        }
        catch (Exception ex) { }
    }

    public void fillgrid()
    {
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);

        con.Open();
        DataTable dt = new DataTable();
        string sqlpo = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", " SD_Cust_PO_Master.PONo='" + PN + "' AND SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + POId + "'");


        SqlCommand cmdpo = new SqlCommand(sqlpo, con);
        SqlDataAdapter dapo = new SqlDataAdapter(cmdpo);
        DataSet dspo = new DataSet();
        dapo.Fill(dspo);

        dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
        dt.Columns.Add(new System.Data.DataColumn("ItemDesc", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("TotalQty", typeof(float)));
        dt.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(float)));
        dt.Columns.Add(new System.Data.DataColumn("RemainingQty", typeof(float)));

        if (dspo.Tables[0].Rows.Count > 0)
        {
            DataRow dr;
            for (int i = 0; i < dspo.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                double reqty = 0;
                double rmnqty = 0;
                double qty = 0;

                string sqlUnit = fun.select("Id,Symbol", "Unit_Master", "Id='" + dspo.Tables[0].Rows[0]["Unit"].ToString() + "'");
                SqlCommand cmdUnit = new SqlCommand(sqlUnit, con);
                SqlDataAdapter daUnit = new SqlDataAdapter(cmdUnit);
                DataSet dsUnit = new DataSet();
                daUnit.Fill(dsUnit);
                int y1 = 0;
                string sqlrmn = fun.select(" Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details,SD_Cust_PO_Master,SD_Cust_PO_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And tblACC_ServiceTaxInvoice_Details.ItemId=SD_Cust_PO_Details.Id ANd tblACC_ServiceTaxInvoice_Master.POId=SD_Cust_PO_Master.POId  AND tblACC_ServiceTaxInvoice_Master.POId='" + dspo.Tables[0].Rows[i]["POId"].ToString() + "' AND tblACC_ServiceTaxInvoice_Details.ItemId='" + dspo.Tables[0].Rows[i]["Id"].ToString() + "' Group By tblACC_ServiceTaxInvoice_Details.ItemId");
                SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                DataSet dsrmn = new DataSet();
                darmn.Fill(dsrmn);
                if (dsrmn.Tables[0].Rows.Count > 0 && dsrmn.Tables[0].Rows[0]["ReqQty"] != DBNull.Value)
                {
                    reqty = Convert.ToDouble(decimal.Parse((dsrmn.Tables[0].Rows[0]["ReqQty"]).ToString()).ToString("N3"));


                }
                qty = Convert.ToDouble(decimal.Parse((dspo.Tables[0].Rows[i]["TotalQty"]).ToString()).ToString("N3"));
                rmnqty = qty - reqty;
                if (rmnqty > 0)
                {
                    y1++;
                }
                if (y1 > 0)
                {
                    dr[0] = dspo.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = dspo.Tables[0].Rows[i]["ItemDesc"].ToString();
                    dr[2] = dspo.Tables[0].Rows[i]["TotalQty"].ToString();
                    dr[3] = dsUnit.Tables[0].Rows[0]["Symbol"].ToString();
                    dr[4] = dspo.Tables[0].Rows[i]["Rate"].ToString();
                    dr[5] = rmnqty;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void BtnBuy_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            string InvNo = TxtInvNo.Text;
            int j = 1;
            string mid = "";
            double ReqQty = 0;
            double rmnqty = 0;
            double Qty = 0;
            double Amt = 0;
            int Id = 0;
            int z = 1;
            int h = 1;
            con.Open();

            if (DrpByCountry.SelectedIndex != 0 && DrpByState.SelectedIndex != 0 && DrpByCity.SelectedIndex != 0 && DrpCoCountry.SelectedIndex != 0 && DrpCoState.SelectedIndex != 0 && DrpCoCity.SelectedIndex != 0 && TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) == true && fun.EmailValidation(TxtByEmail.Text) == true && fun.EmailValidation(TxtCoEmail.Text) == true && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) == true && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text) == true)
            {

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("TxtAmt")).Text != "" && ((TextBox)grv.FindControl("TxtReqQty")).Text != "" && Convert.ToDouble(((TextBox)grv.FindControl("TxtReqQty")).Text) > 0 && TxtInvNo.Text != "")
                    {
                        Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                        Qty = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblQty")).Text).ToString("N2"));
                        ReqQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtReqQty")).Text).ToString()).ToString("N3"));
                        Amt = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtAmt")).Text).ToString()).ToString("N2"));

                        string sqlrmn = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'  And tblACC_ServiceTaxInvoice_Details.ItemId='" + Id + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");


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

                        if (rmnqty >= ReqQty)//&& Amt <= RemnAmt
                        {
                            z = z * h;
                        }
                        else
                        {
                            h = 0;
                            z = 0;
                        }
                    }
                }

                if (z > 0)
                {

                    foreach (GridViewRow grv in GridView1.Rows)
                    {
                        if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("TxtAmt")).Text != "" && ((TextBox)grv.FindControl("TxtReqQty")).Text != "" && Convert.ToDouble(((TextBox)grv.FindControl("TxtReqQty")).Text) > 0 && TxtInvNo.Text != "")
                        {
                            Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                            Qty = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblQty")).Text).ToString("N3"));
                            ReqQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtReqQty")).Text).ToString()).ToString("N3"));
                            Amt = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtAmt")).Text).ToString()).ToString("N2"));

                            string sqlrmn = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'  And tblACC_ServiceTaxInvoice_Details.ItemId='" + Id + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");
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

                            if (rmnqty >= ReqQty)
                            {
                                if (TxtDateofIssueInvoice.Text != "" && TxtDutyRate.Text != "" && TxtBYName.Text != "" && TxtByAddress.Text != "" && TxtByCName.Text != "" && TxtByPhone.Text != "" && TxtByEmail.Text != "" && TxtByECCNo.Text != "" && TxtByTINCSTNo.Text != "" && TxtByMobile.Text != "" && TxtByFaxNo.Text != "" && TxtByTINVATNo.Text != "" && TxtCName.Text != "" && TxtCAddress.Text != "" && TxtCoPersonName.Text != "" && TxtCoPhoneNo.Text != "" && TxtCoEmail.Text != "" && TxtECoCCNo.Text != "" && TxtCoTinCSTNo.Text != "" && TxtCoMobileNo.Text != "" && TxtCoFaxNo.Text != "" && TxtCoTinVatNo.Text != "" && TxtAdd.Text != "" && TxtDeduct.Text != "")
                                {
                                    if (j > 0)
                                    {
                                        string TimeSelector = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm.ToString();

                                        string sqlsub = fun.insert("tblACC_ServiceTaxInvoice_Master", " SysDate,SysTime,CompId,FinYearId, SessionId,InvoiceNo,POId,PONo,WONo,DateOfIssueInvoice ,TimeOfIssueInvoice,DutyRate,CustomerCode,CustomerCategory,Buyer_name,  Buyer_add,Buyer_country,Buyer_state, Buyer_city,Buyer_cotper,Buyer_ph,Buyer_email,Buyer_ecc,Buyer_tin  ,Buyer_mob  ,Buyer_fax,Buyer_vat,Cong_name ,Cong_add,Cong_Country,Cong_state,Cong_city,Cong_cotper ,  Cong_ph  ,  Cong_email  ,  Cong_ecc  ,Cong_tin,Cong_mob,Cong_fax,Cong_vat,AddType,AddAmt,DeductionType,Deduction,ServiceTax,TaxableServices ", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + InvNo + "','" + POId + "','" + PN + "','" + WN + "','" + fun.FromDate(TxtDateofIssueInvoice.Text) + "','" + TimeSelector + "','" + TxtDutyRate.Text + "','" + CCode + "','" + DrpCategory.SelectedValue + "','" + TxtBYName.Text + "','" + TxtByAddress.Text + "','" + DrpByCountry.SelectedValue + "','" + DrpByState.SelectedValue + "','" + DrpByCity.SelectedValue + "','" + TxtByCName.Text + "','" + TxtByPhone.Text + "','" + TxtByEmail.Text + "','" + TxtByECCNo.Text + "','" + TxtByTINCSTNo.Text + "','" + TxtByMobile.Text + "','" + TxtByFaxNo.Text + "','" + TxtByTINVATNo.Text + "','" + TxtCName.Text + "','" + TxtCAddress.Text + "','" + DrpCoCountry.SelectedValue + "','" + DrpCoState.SelectedValue + "','" + DrpCoCity.SelectedValue + "','" + TxtCoPersonName.Text + "','" + TxtCoPhoneNo.Text + "','" + TxtCoEmail.Text + "','" + TxtECoCCNo.Text + "','" + TxtCoTinCSTNo.Text + "','" + TxtCoMobileNo.Text + "','" + TxtCoFaxNo.Text + "','" + TxtCoTinVatNo.Text + "','" + DrpAdd.SelectedValue + "','" + TxtAdd.Text + "','" + DrpDed.SelectedValue + "','" + TxtDeduct.Text + "','" + DrpServiceTax.SelectedValue + "','" + DrpTaxableServices.SelectedValue + "'");

                                        SqlCommand cmd = new SqlCommand(sqlsub, con);
                                        cmd.ExecuteNonQuery();

                                        string cmdStr2 = fun.select1("Id", "tblACC_ServiceTaxInvoice_Master order by Id desc");
                                        SqlCommand cmd12 = new SqlCommand(cmdStr2, con);
                                        SqlDataAdapter da2 = new SqlDataAdapter(cmd12);
                                        DataSet DS2 = new DataSet();
                                        da2.Fill(DS2, "tblACC_ServiceTaxInvoice_Master");
                                        mid = DS2.Tables[0].Rows[0]["Id"].ToString();

                                    }

                                    double rate = Convert.ToDouble(((Label)grv.FindControl("lblRate")).Text);
                                    string unit = ((DropDownList)grv.FindControl("DrpUnitQty")).SelectedValue;
                                    string sqltemp = fun.insert("tblACC_ServiceTaxInvoice_Details", "MId,InvoiceNo,ItemId,Unit,Qty,ReqQty,AmtInPer,Rate", "'" + mid + "','" + InvNo + "','" + Id + "','" + unit + "','" + Convert.ToDouble(decimal.Parse(Qty.ToString()).ToString("N3")) + "','" + ReqQty + "','" + Amt + "','" + Convert.ToDouble(decimal.Parse(rate.ToString()).ToString("N2")) + "'");
                                    SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                                    cmdtemp.ExecuteNonQuery();
                                    j = 0;
                                }
                            }
                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Goods input data is invalid.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }
                    }


                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Input data is invalid.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
                if (j == 0)
                {
                    Response.Redirect("ServiceTaxInvoice_New.aspx?ModId=11&SubModId=52");
                }
            }
        }
        catch (Exception ex)
        {
        }
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
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_New.aspx?ModId=11&SubModId=52");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_New.aspx?ModId=11&SubModId=52");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_New.aspx?ModId=11&SubModId=52");
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



    protected void Button3_Click(object sender, EventArgs e)
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
    protected void Button4_Click(object sender, EventArgs e)
    {

    }


    protected void Button6_Click(object sender, EventArgs e)
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


}
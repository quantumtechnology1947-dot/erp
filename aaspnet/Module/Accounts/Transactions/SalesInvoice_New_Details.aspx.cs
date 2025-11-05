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

public partial class Module_Accounts_Transactions_SalesInvoice_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string CDate = "";
    string CTime = "";
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string WN = "";
    string PN = "";
    string PId = "";
    string CCode = "";
    string typ = "";
    string pdate = "";
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
            PId = fun.Decrypt(Request.QueryString["poid"].ToString());

            
            CCode = fun.Decrypt(Request.QueryString["cid"].ToString());
            typ = fun.Decrypt(Request.QueryString["ty"].ToString());
            pdate = fun.Decrypt(Request.QueryString["date"].ToString());
            string dt = fun.getCurrDate();
            LblInvDate.Text = fun.FromDateDMY(dt);
            LblPODate.Text = pdate;

            DataSet ds = new DataSet();
            con.Open();
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


            LblPONo.Text = PN;

            string sqltype = fun.select("Id,Description", "tblACC_SalesInvoice_Master_Type", "Id='" + typ + "'");
            SqlCommand cmdtyp = new SqlCommand(sqltype, con);
            SqlDataAdapter datyp = new SqlDataAdapter(cmdtyp);
            DataSet dstyp = new DataSet();
            datyp.Fill(dstyp);
            LblMode.Text = dstyp.Tables[0].Rows[0]["Description"].ToString();

            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");

            this.GetValidate();

            if (!IsPostBack)
            {


                string cmdStr = fun.select("InvoiceNo", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by InvoiceNo desc");
                SqlCommand cmd11 = new SqlCommand(cmdStr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd11);
                DataSet DS = new DataSet();
                da.Fill(DS, "tblACC_SalesInvoice_Master");
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



                if (typ == "2")
                {
                    lblVAT.Text = "SGST";
                    DrpCst.Visible = false;

                }
                else
                {
                    DrpCst.Visible = true;
                    lblVAT.Text = "SGST";
                }
                // For CEN VAT
                string sqlServiceTax = fun.select("Id", "tblExciseser_Master", "Live='1'");
                SqlCommand cmdServiceTax = new SqlCommand(sqlServiceTax, con);
                SqlDataAdapter daServiceTax = new SqlDataAdapter(cmdServiceTax);
                DataSet dsServiceTax = new DataSet();
                daServiceTax.Fill(dsServiceTax);
                if (dsServiceTax.Tables[0].Rows.Count > 0)
                {
                    DrpServiceTax.SelectedValue = dsServiceTax.Tables[0].Rows[0]["Id"].ToString();
                }
                fun.dropdownCountry(DrpByCountry, DrpByState);
                fun.dropdownCountry(DrpCoCountry, DrpCoState);

                string sqlcus = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CCode + "' And CompId='" + CompId + "'");
                SqlCommand cmdcus = new SqlCommand(sqlcus, con);
                SqlDataAdapter dacus = new SqlDataAdapter(cmdcus);
                DataSet dscus = new DataSet();
                dacus.Fill(dscus);

                TxtBYName.Text = dscus.Tables[0].Rows[0]["Customer"].ToString();
                TxtByAddress.Text = dscus.Tables[0].Rows[0]["MaterialDelAddress"].ToString();

                fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                DrpByCountry.SelectedIndex = 0;
                fun.dropdownCountry(DrpByCountry, DrpByState);

                //  State
                fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
                fun.dropdownStatebyId(DrpByState, "CId='" + dscus.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dscus.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");

                DrpByState.SelectedValue = dscus.Tables[0].Rows[0]["MaterialDelState"].ToString();
                //  City
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
                this.fillgrid();
            }

        }
        catch (Exception ex) { }

    }

    public void GetValidate()
    {
        foreach (GridViewRow grv in GridView1.Rows)
        {
            if (((CheckBox)grv.FindControl("ck")).Checked == true)
            {
                ((RequiredFieldValidator)grv.FindControl("ReqQty")).Visible = true;
                ((RequiredFieldValidator)grv.FindControl("ReqAmt")).Visible = true;
            }
            else
            {
                ((RequiredFieldValidator)grv.FindControl("ReqQty")).Visible = false;
                ((RequiredFieldValidator)grv.FindControl("ReqAmt")).Visible = false;
            }
        }

    }
    public void fillgrid()
    {
        //try
        {
            string connStr = fun.Connection();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connStr);

            con.Open();
            DataTable dt = new DataTable();


            string sqlpo = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", " SD_Cust_PO_Master.PONo='" + PN + "' AND SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + PId + "'");


            
            SqlCommand cmdpo = new SqlCommand(sqlpo, con);
            SqlDataAdapter dapo = new SqlDataAdapter(cmdpo);
            DataSet dspo = new DataSet();
            dapo.Fill(dspo);
            dt.Columns.Add(new System.Data.DataColumn("POId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("ItemDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TotalQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("RemainingQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Amt", typeof(double)));
            if (dspo.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < dspo.Tables[0].Rows.Count; i++)
                {
                    double reqty = 0;
                    double rmnqty = 0;
                    double qty = 0;
                    dr = dt.NewRow();
                    string sqlUnit = fun.select("Id,Symbol", "Unit_Master", "Id='" + dspo.Tables[0].Rows[i]["Unit"].ToString() + "'");
                    SqlCommand cmdUnit = new SqlCommand(sqlUnit, con);
                    SqlDataAdapter daUnit = new SqlDataAdapter(cmdUnit);
                    DataSet dsUnit = new DataSet();
                    daUnit.Fill(dsUnit);
                    int y1 = 0;
                    string sqlrmn = fun.select(" Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details,SD_Cust_PO_Master,SD_Cust_PO_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And tblACC_SalesInvoice_Details.ItemId=SD_Cust_PO_Details.Id ANd tblACC_SalesInvoice_Master.POId=SD_Cust_PO_Master.POId  AND tblACC_SalesInvoice_Master.POId='" + dspo.Tables[0].Rows[i]["POId"].ToString() + "' AND tblACC_SalesInvoice_Details.ItemId='" + dspo.Tables[0].Rows[i]["Id"].ToString() + "' Group By tblACC_SalesInvoice_Details.ItemId ");

                    SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                    SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                    DataSet dsrmn = new DataSet();
                    darmn.Fill(dsrmn);



                    if (dsrmn.Tables[0].Rows.Count > 0 && dsrmn.Tables[0].Rows[0]["ReqQty"] != DBNull.Value)
                    {
                        reqty = Convert.ToDouble(decimal.Parse((dsrmn.Tables[0].Rows[0]["ReqQty"]).ToString()).ToString("N3"));

                    }
                    qty = Convert.ToDouble(decimal.Parse((dspo.Tables[0].Rows[i]["TotalQty"]).ToString()).ToString("N3"));
                    rmnqty = Math.Round((qty - reqty), 3);

                    if (rmnqty > 0)
                    {
                        y1++;
                    }

                    if (y1 > 0)
                    {
                        dr[0] = dspo.Tables[0].Rows[i]["POId"].ToString();
                        dr[1] = dspo.Tables[0].Rows[i]["ItemDesc"].ToString();
                        dr[2] = Convert.ToDouble(decimal.Parse((dspo.Tables[0].Rows[i]["TotalQty"]).ToString()).ToString("N3"));
                        dr[3] = dsUnit.Tables[0].Rows[0]["Symbol"].ToString();
                        dr[4] = dspo.Tables[0].Rows[i]["Id"].ToString();
                        dr[5] = Convert.ToDouble(decimal.Parse((dspo.Tables[0].Rows[i]["Rate"]).ToString()).ToString("N2"));
                        dr[6] = rmnqty;
                        dr[7] = 0;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
      //  catch (Exception ex) { }
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
        string InvNo = TxtInvNo.Text;
        string mid = "";
        int z = 1;
        int j = 1;
        int h = 1;
        try
        {
            con.Open();
         
            if (DrpByCountry.SelectedIndex != 0 && DrpByState.SelectedIndex != 0 && DrpByCity.SelectedIndex != 0 && DrpCoCountry.SelectedIndex != 0 && DrpCoState.SelectedIndex != 0 && DrpCoCity.SelectedIndex != 0 && TxtInvNo.Text != "" && TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) == true && TxtDateRemoval.Text != "" && fun.DateValidation(TxtDateRemoval.Text) == true && fun.EmailValidation(TxtByEmail.Text) == true && fun.EmailValidation(TxtCoEmail.Text) == true && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) == true && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text) == true && TxtPf.Text != "" && fun.NumberValidationQty(TxtPf.Text) == true && TxtSed.Text != "" && fun.NumberValidationQty(TxtSed.Text) == true && TxtAed.Text != "" && fun.NumberValidationQty(TxtAed.Text) == true && Txtfreight.Text != "" && fun.NumberValidationQty(Txtfreight.Text) == true && TxtInsurance.Text != "" && fun.NumberValidationQty(TxtInsurance.Text) == true && DrpCommodity.SelectedValue!="0")
            {

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("TxtReqQty")).Text != "" && fun.NumberValidationQty(((TextBox)grv.FindControl("TxtReqQty")).Text) == true && fun.NumberValidationQty(((TextBox)grv.FindControl("TxtAmt")).Text) == true && ((TextBox)grv.FindControl("TxtAmt")).Text != "")
                    {
                        double rmnqty = 0;
                        double Qty = 0;
                        double ReqQty = 0;
                        int Item = Convert.ToInt32(((Label)grv.FindControl("lblPOId")).Text);
                        int Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                        Qty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblQty")).Text).ToString()).ToString("N3"));
                        ReqQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtReqQty")).Text).ToString()).ToString("N3"));
                        string sqlrmn = fun.select("Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' And tblACC_SalesInvoice_Details.ItemId='" + Id + "'  Group By tblACC_SalesInvoice_Details.ItemId");

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
                        if (((CheckBox)grv.FindControl("ck")).Checked == true && ((TextBox)grv.FindControl("TxtReqQty")).Text != "")
                        {
                            double rmnqty = 0;
                            double Qty = 0;
                            double Amt = 0;
                            double ReqQty = 0;

                            int Item = Convert.ToInt32(((Label)grv.FindControl("lblPOId")).Text);
                            int Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                            Qty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblQty")).Text).ToString()).ToString("N3"));

                            ReqQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtReqQty")).Text).ToString()).ToString("N3"));

                            string sqlamt = fun.select("sum(AmtInPer) As Amt", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' And tblACC_SalesInvoice_Details.ItemId='" + Id + "'  Group By tblACC_SalesInvoice_Details.ItemId ");
                            SqlCommand cmdamt = new SqlCommand(sqlamt, con);
                            SqlDataAdapter daamt = new SqlDataAdapter(cmdamt);
                            DataSet dsamt = new DataSet();
                            daamt.Fill(dsamt);

                            double RemnAmt = 100;
                            if (dsamt.Tables[0].Rows.Count > 0 && dsamt.Tables[0].Rows[0][0] != DBNull.Value)
                            {
                                double amt = Convert.ToDouble(decimal.Parse((dsamt.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N2"));
                                RemnAmt = 100 - amt;
                            }

                            Amt = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("TxtAmt")).Text).ToString()).ToString("N2"));

                            string sqlrmn = fun.select("Sum(tblACC_SalesInvoice_Details.ReqQty) as ReqQty", "tblACC_SalesInvoice_Master,tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Details.MId=tblACC_SalesInvoice_Master.Id  And  tblACC_SalesInvoice_Master.CompId='" + CompId + "' And tblACC_SalesInvoice_Details.ItemId='" + Id + "'  Group By tblACC_SalesInvoice_Details.ItemId");

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
                                if (j > 0)
                                {
                                    string Timeofissue = TimeOfIssue.Hour.ToString("D2") + ":" + TimeOfIssue.Minute.ToString("D2") + ":" + TimeOfIssue.Second.ToString("D2") + " " + TimeOfIssue.AmPm.ToString();

                                    string Timeofremove = TimeOfRemove.Hour.ToString("D2") + ":" + TimeOfRemove.Minute.ToString("D2") + ":" + TimeOfRemove.Second.ToString("D2") + " " + TimeOfRemove.AmPm.ToString();

                                    int vat = 0;
                                    int cenvat = 0;
                                    int selectedCST = 0;

                                    if (typ == "2") // Within Mh.
                                    {
                                        vat = Convert.ToInt32(DrpVAT.SelectedValue);
                                    }
                                    else if (typ == "3") // out of Mh.
                                    {
                                        selectedCST = Convert.ToInt32(DrpCst.SelectedValue);
                                        cenvat = Convert.ToInt32(DrpVAT.SelectedValue);
                                    }
                                    double OA = Math.Round(Convert.ToDouble(TxtOtherAmt.Text), 2);
                                    string sqlsub = fun.insert("tblACC_SalesInvoice_Master", "SysDate,SysTime,CompId,FinYearId, SessionId, InvoiceNo,PONo,WONo,InvoiceMode,DateOfIssueInvoice ,DateOfRemoval,TimeOfIssueInvoice,TimeOfRemoval,NatureOfRemoval,Commodity, ModeOfTransport,RRGCNo,VehiRegNo,DutyRate,  CustomerCode,CustomerCategory,Buyer_name,  Buyer_add,Buyer_country,Buyer_state, Buyer_city,Buyer_cotper,Buyer_ph,Buyer_email,Buyer_ecc,Buyer_tin  ,Buyer_mob  ,Buyer_fax,Buyer_vat,Cong_name ,Cong_add,Cong_Country,Cong_state,Cong_city,Cong_cotper ,  Cong_ph  ,  Cong_email  ,  Cong_ecc  ,Cong_tin,Cong_mob,Cong_fax,Cong_vat,AddType,AddAmt,DeductionType,Deduction,PFType,PF,CENVAT,SED,AED,VAT,SelectedCST,CST,FreightType,Freight,InsuranceType,Insurance ,SEDType,AEDType,POId,OtherAmt", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + InvNo + "','" + PN + "','" + WN + "','" + typ + "','" + fun.FromDate(TxtDateofIssueInvoice.Text) + "','" + fun.FromDate(TxtDateRemoval.Text) + "','" + Timeofissue + "','" + Timeofremove + "','" + DrpNatureremovable.SelectedValue + "','" + DrpCommodity.SelectedValue + "','" + DrpTransport.SelectedValue + "','" + TxtRRGCNo.Text + "','" + TxtRegistrationNo.Text + "','" + TxtDutyRate.Text + "','" + CCode + "','" + DrpCategory.SelectedValue + "','" + TxtBYName.Text + "','" + TxtByAddress.Text + "','" + DrpByCountry.SelectedValue + "','" + DrpByState.SelectedValue + "','" + DrpByCity.SelectedValue + "','" + TxtByCName.Text + "','" + TxtByPhone.Text + "','" + TxtByEmail.Text + "','" + TxtByECCNo.Text + "','" + TxtByTINCSTNo.Text + "','" + TxtByMobile.Text + "','" + TxtByFaxNo.Text + "','" + TxtByTINVATNo.Text + "','" + TxtCName.Text + "','" + TxtCAddress.Text + "','" + DrpCoCountry.SelectedValue + "','" + DrpCoState.SelectedValue + "','" + DrpCoCity.SelectedValue + "','" + TxtCoPersonName.Text + "','" + TxtCoPhoneNo.Text + "','" + TxtCoEmail.Text + "','" + TxtECoCCNo.Text + "','" + TxtCoTinCSTNo.Text + "','" + TxtCoMobileNo.Text + "','" + TxtCoFaxNo.Text + "','" + TxtCoTinVatNo.Text + "','" + DrpAdd.SelectedValue + "','" + TxtAdd.Text + "','" + DrpDed.SelectedValue + "','" + TxtDeduct.Text + "','" + DrpPAF.SelectedValue + "','" + TxtPf.Text + "','" + DrpServiceTax.SelectedValue + "','" + TxtSed.Text + "','" + TxtAed.Text + "','" + vat + "','" + selectedCST + "','" + cenvat + "','" + DrpFreight.SelectedValue + "','" + Txtfreight.Text + "','" + DrpInsurance.SelectedValue + "','" + TxtInsurance.Text + "','" + DrpSED.SelectedValue + "','" + DrpAED.SelectedValue + "','" + Item + "','"+OA+"'");

                                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                                    cmd.ExecuteNonQuery();
                                    string cmdStr2 = fun.select("Id", "tblACC_SalesInvoice_Master", " CompId='" + CompId + "' order by Id desc");
                                    SqlCommand cmd12 = new SqlCommand(cmdStr2, con);
                                    SqlDataAdapter da2 = new SqlDataAdapter(cmd12);
                                    DataSet DS2 = new DataSet();

                                    da2.Fill(DS2, "tblACC_SalesInvoice_Master");
                                    mid = DS2.Tables[0].Rows[0]["Id"].ToString();
                                }

                                double rate = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblRate")).Text).ToString()).ToString("N2"));
                                string unit = ((DropDownList)grv.FindControl("DrpUnitQty")).SelectedValue;
                                string sqltemp = fun.insert("tblACC_SalesInvoice_Details", "InvoiceNo,MId,ItemId,Unit,Qty,ReqQty,AmtInPer,Rate", "'" + InvNo + "','" + mid + "','" + Id + "','" + unit + "','" + Qty + "','" + ReqQty + "','" + Amt + "','" + rate + "'");
                                SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                                cmdtemp.ExecuteNonQuery();
                                j = 0;
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

            }
            if (j == 0)
            {
                Response.Redirect("SalesInvoice_New.aspx?ModId=11&SubModId=51");
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
    protected void TxtInsurance_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SalesInvoice_New.aspx?ModId=11&SubModId=51");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SalesInvoice_New.aspx?ModId=11&SubModId=51");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("SalesInvoice_New.aspx?ModId=11&SubModId=51");
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
    protected void Button5_Click(object sender, EventArgs e)
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
    protected void Button4_Click(object sender, EventArgs e)
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
    protected void Button6_Click(object sender, EventArgs e)
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

    protected void DrpCommodity_SelectedIndexChanged(object sender, EventArgs e)
    {
        TxttrafficNo.Text = fun.ExciseCommodity(Convert.ToInt32(DrpCommodity.SelectedValue));
    }

    
}
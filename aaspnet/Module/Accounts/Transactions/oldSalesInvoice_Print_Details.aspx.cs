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
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using System.Globalization;

public partial class Module_Accounts_Transactions_SalesInvoice_Print_Details : System.Web.UI.Page
{
   clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();  
    int CompId = 0;
    int FinYearId = 0;
    string InvId = "";
    string WN = "";
    string CCode = "";
    string  InvNo = "";
    string PrintType = "";
    ReportDocument cryRpt = new ReportDocument();
    string Key = string.Empty;
    string Key1 = string.Empty;
    int Type = 0;

    protected void Page_Init(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        Key = Request.QueryString["Key"].ToString();
       try
        {
            if (!IsPostBack)
            {
                // use US English culture throughout the examples
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                //string wordsIss;
                string wordsRem = string.Empty;
                con.Open();

                FinYearId = Convert.ToInt32(Session["finyear"]);
                CompId = Convert.ToInt32(Session["compid"]);
                InvId = Request.QueryString["InvId"].ToString();
                //PN = Request.QueryString["pn"].ToString();
                InvNo = Request.QueryString["InvNo"];
                CCode = Request.QueryString["cid"].ToString();
                PrintType = Request.QueryString["PT"].ToString();

                SqlCommand Cmdgrid = new SqlCommand(fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "'  And InvoiceNo='" + InvNo + "' And Id='" + InvId + "'"), con);
                SqlDataAdapter dagrid = new SqlDataAdapter(Cmdgrid);
                DataSet dsrs = new DataSet();
                dagrid.Fill(dsrs);

                DataTable dt = new DataTable();

                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("InvoiceNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("InvoiceMode", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DateOfIssueInvoice", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DateOfRemoval", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("TimeOfIssueInvoice", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("TimeOfRemoval", typeof(string)));

                dt.Columns.Add(new System.Data.DataColumn("NatureOfRemoval", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Commodity", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("TariffHeading", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ModeOfTransport", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("RRGCNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("VehiRegNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DutyRate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CustomerCode", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CustomerCategory", typeof(string)));

                dt.Columns.Add(new System.Data.DataColumn("Buyer_name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_cotper", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_ph", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_email", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_ecc", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_tin", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_mob", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_fax", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Buyer_vat", typeof(string)));

                dt.Columns.Add(new System.Data.DataColumn("Cong_name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_cotper", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_ph", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_email", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_ecc", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_tin", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_mob", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_fax", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Cong_vat", typeof(string)));

                dt.Columns.Add(new System.Data.DataColumn("AddType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("AddAmt", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("DeductionType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Deduction", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("PFType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("CENVAT", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SED", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("AED", typeof(double)));

                dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SelectedCST", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("CST", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("FreightType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("InsuranceType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Insurance", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("PODate", typeof(string)));

                dt.Columns.Add(new System.Data.DataColumn("AEDType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SEDType", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("POId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("OtherAmt", typeof(double)));
                DataSet SalesInvoice = new DataSet();
                DataRow dr;

                dr = dt.NewRow();
                if (dsrs.Tables[0].Rows.Count > 0)
                {
                    dr[0] = dsrs.Tables[0].Rows[0]["Id"].ToString();
                    dr[1] = fun.FromDateDMY(dsrs.Tables[0].Rows[0]["SysDate"].ToString());
                    dr[2] = dsrs.Tables[0].Rows[0]["CompId"].ToString();
                    dr[3] = dsrs.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    dr[4] = dsrs.Tables[0].Rows[0]["PONo"].ToString();

                    WN = dsrs.Tables[0].Rows[0]["WONo"].ToString();
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

                    }

                    dr[5] = WoNO;
                    dr[6] = dsrs.Tables[0].Rows[0]["InvoiceMode"].ToString();
                    dr[7] = fun.FromDateDMY(dsrs.Tables[0].Rows[0]["DateOfIssueInvoice"].ToString());
                    dr[8] = fun.FromDateDMY(dsrs.Tables[0].Rows[0]["DateOfRemoval"].ToString());
                    dr[9] = dsrs.Tables[0].Rows[0]["TimeOfIssueInvoice"].ToString();
                    dr[10] = dsrs.Tables[0].Rows[0]["TimeOfRemoval"].ToString();

                    //    Nature Of Removal 
                    string sqlNature = fun.select("Description", "tblACC_Removable_Nature", "Id='" + dsrs.Tables[0].Rows[0]["NatureOfRemoval"] + "'");
                    SqlCommand cmdNature = new SqlCommand(sqlNature, con);
                    SqlDataAdapter DANature = new SqlDataAdapter(cmdNature);
                    DataSet DSNature = new DataSet();
                    DANature.Fill(DSNature);

                    if (DSNature.Tables[0].Rows.Count > 0)
                    {
                        dr[11] = DSNature.Tables[0].Rows[0]["Description"].ToString();
                    }

                    //    Commodity 
                    string sqlCommodity = fun.select("*", "tblExciseCommodity_Master", "Id='" + dsrs.Tables[0].Rows[0]["Commodity"] + "'");
                    SqlCommand cmdCommodity = new SqlCommand(sqlCommodity, con);
                    SqlDataAdapter DACommodity = new SqlDataAdapter(cmdCommodity);
                    DataSet DSCommodity = new DataSet();
                    DACommodity.Fill(DSCommodity);

                    if (DSCommodity.Tables[0].Rows.Count > 0)
                    {
                        dr[12] = DSCommodity.Tables[0].Rows[0]["Terms"].ToString();
                        dr[13] = DSCommodity.Tables[0].Rows[0]["ChapHead"].ToString();
                    }

                    //   Mode Of Transport
                    string sqlTransport = fun.select("Description", "tblACC_TransportMode", "Id='" + dsrs.Tables[0].Rows[0]["ModeOfTransport"] + "'");


                    SqlCommand cmdTransport = new SqlCommand(sqlTransport, con);
                    SqlDataAdapter DATransport = new SqlDataAdapter(cmdTransport);
                    DataSet DSTransport = new DataSet();
                    DATransport.Fill(DSTransport);

                    if (DSTransport.Tables[0].Rows.Count > 0)
                    {
                        dr[14] = DSTransport.Tables[0].Rows[0]["Description"].ToString();
                    }

                    dr[15] = dsrs.Tables[0].Rows[0]["RRGCNo"].ToString();
                    dr[16] = dsrs.Tables[0].Rows[0]["VehiRegNo"].ToString();
                    dr[17] = dsrs.Tables[0].Rows[0]["DutyRate"].ToString();
                    dr[18] = dsrs.Tables[0].Rows[0]["CustomerCode"].ToString();

                    //     Customer Category
                    string sqlConsigneeCat = fun.select("Description", "tblACC_Service_Category", "Id='" + dsrs.Tables[0].Rows[0]["CustomerCategory"] + "'");
                    SqlCommand cmdConsigneeCat = new SqlCommand(sqlConsigneeCat, con);
                    SqlDataAdapter DAConsigneeCat = new SqlDataAdapter(cmdConsigneeCat);
                    DataSet DSConsigneeCat = new DataSet();
                    DAConsigneeCat.Fill(DSConsigneeCat);

                    if (DSConsigneeCat.Tables[0].Rows.Count > 0)
                    {
                        dr[19] = DSConsigneeCat.Tables[0].Rows[0]["Description"].ToString();
                    }

                    dr[20] = dsrs.Tables[0].Rows[0]["Buyer_name"].ToString();
                    dr[21] = dsrs.Tables[0].Rows[0]["Buyer_cotper"].ToString();
                    dr[22] = dsrs.Tables[0].Rows[0]["Buyer_ph"].ToString();
                    dr[23] = dsrs.Tables[0].Rows[0]["Buyer_email"].ToString();
                    dr[24] = dsrs.Tables[0].Rows[0]["Buyer_ecc"].ToString();
                    dr[25] = dsrs.Tables[0].Rows[0]["Buyer_tin"].ToString();
                    dr[26] = dsrs.Tables[0].Rows[0]["Buyer_mob"].ToString();
                    dr[27] = dsrs.Tables[0].Rows[0]["Buyer_fax"].ToString();
                    dr[28] = dsrs.Tables[0].Rows[0]["Buyer_vat"].ToString();
                    dr[29] = dsrs.Tables[0].Rows[0]["Cong_name"].ToString();
                    dr[30] = dsrs.Tables[0].Rows[0]["Cong_cotper"].ToString();
                    dr[31] = dsrs.Tables[0].Rows[0]["Cong_ph"].ToString();
                    dr[32] = dsrs.Tables[0].Rows[0]["Cong_email"].ToString();
                    dr[33] = dsrs.Tables[0].Rows[0]["Cong_ecc"].ToString();
                    dr[34] = dsrs.Tables[0].Rows[0]["Cong_tin"].ToString();
                    dr[35] = dsrs.Tables[0].Rows[0]["Cong_mob"].ToString();
                    dr[36] = dsrs.Tables[0].Rows[0]["Cong_fax"].ToString();
                    dr[37] = dsrs.Tables[0].Rows[0]["Cong_vat"].ToString();
                    dr[38] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["AddType"].ToString());
                    dr[39] = dsrs.Tables[0].Rows[0]["AddAmt"].ToString();
                    dr[40] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["DeductionType"].ToString());
                    dr[41] = dsrs.Tables[0].Rows[0]["Deduction"].ToString();
                    dr[42] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["PFType"].ToString());
                    dr[43] = dsrs.Tables[0].Rows[0]["PF"].ToString();
                    dr[44] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["CENVAT"].ToString());
                    dr[45] = dsrs.Tables[0].Rows[0]["SED"].ToString();
                    dr[46] = dsrs.Tables[0].Rows[0]["AED"].ToString();
                    dr[47] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["VAT"].ToString());
                    dr[48] = dsrs.Tables[0].Rows[0]["SelectedCST"].ToString();
                    dr[49] = dsrs.Tables[0].Rows[0]["CST"].ToString();
                    dr[50] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["FreightType"].ToString());
                    dr[51] = dsrs.Tables[0].Rows[0]["Freight"].ToString();
                    dr[52] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["InsuranceType"].ToString());
                    dr[53] = dsrs.Tables[0].Rows[0]["Insurance"].ToString();

                    //   PO Date
                    string sqlPO = fun.select("PODate", "SD_Cust_PO_Master", "POId='" + dsrs.Tables[0].Rows[0]["POId"] + "' And CompId='" + CompId + "'");
                    SqlCommand cmdPO = new SqlCommand(sqlPO, con);
                    SqlDataAdapter DAPO = new SqlDataAdapter(cmdPO);
                    DataSet DSPO = new DataSet();
                    DAPO.Fill(DSPO);
                    if (DSPO.Tables[0].Rows.Count > 0)
                    {
                        dr[54] = fun.FromDateDMY(DSPO.Tables[0].Rows[0]["PODate"].ToString());
                    }
                    dr[55] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["AEDType"].ToString());
                    dr[56] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["SEDType"].ToString());
                    dr[57] = Convert.ToInt32(dsrs.Tables[0].Rows[0]["POId"]);
                     double OA = 0;
                    if (dsrs.Tables[0].Rows[0]["OtherAmt"] != DBNull.Value)
                    {
                        OA = Convert.ToDouble(dsrs.Tables[0].Rows[0]["OtherAmt"]);
                    }
                    dr[58] =OA;
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();


                SalesInvoice.Tables.Add(dt);
                DataSet xsdds = new SalesInvoice();
                xsdds.Tables[0].Merge(SalesInvoice.Tables[0]);
                xsdds.AcceptChanges();
                cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/Module/Accounts/Reports/OldSalesInvoice.rpt"));
                cryRpt.SetDataSource(xsdds);

                //  For Invoice No

                if (dsrs.Tables[0].Rows.Count > 0)
                {
                    string cmdStr = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + dsrs.Tables[0].Rows[0]["CompId"] + "' And FinYearId='" + dsrs.Tables[0].Rows[0]["FinYearId"].ToString() + "'");
                    SqlCommand cmd = new SqlCommand(cmdStr, con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DA.Fill(DS, "Financial");
                    string fY = "";
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        string FinYearFrD = DS.Tables[0].Rows[0]["FinYearFrom"].ToString();
                        string FDY = fun.FromDateYear(FinYearFrD);
                        string s = FDY.Substring(2);
                        string FinYearToD = DS.Tables[0].Rows[0]["FinYearTo"].ToString();
                        string TDY = fun.ToDateYear(FinYearToD);
                        string g = TDY.Substring(2);
                        fY = string.Concat(s, g);
                        string InvoiceNo = dsrs.Tables[0].Rows[0]["InvoiceNo"].ToString() + "/" + fY;
                        cryRpt.SetParameterValue("InvoiceNo", InvoiceNo);
                    }


                    //   Buyer_Address 
                    string strBuyer_add = dsrs.Tables[0].Rows[0]["Buyer_add"].ToString();
                    string strBuyer_country = fun.select("CountryName", "tblcountry", "CId='" + dsrs.Tables[0].Rows[0]["Buyer_country"] + "'");
                    string strBuyer_state = fun.select("StateName", "tblState", "SId='" + dsrs.Tables[0].Rows[0]["Buyer_state"] + "'");
                    string strBuyer_city = fun.select("CityName", "tblCity", "CityId='" + dsrs.Tables[0].Rows[0]["Buyer_city"] + "'");
                    SqlCommand Cmd1 = new SqlCommand(strBuyer_country, con);
                    SqlCommand Cmd2 = new SqlCommand(strBuyer_state, con);
                    SqlCommand Cmd3 = new SqlCommand(strBuyer_city, con);
                    SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
                    SqlDataAdapter DA2 = new SqlDataAdapter(Cmd2);
                    SqlDataAdapter DA3 = new SqlDataAdapter(Cmd3);
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();
                    DataSet ds3 = new DataSet();
                    DA1.Fill(ds1, "tblCountry");
                    DA2.Fill(ds2, "tblState");
                    DA3.Fill(ds3, "tblcity");

                    string Buyer_Address = strBuyer_add + ",\n" + ds3.Tables[0].Rows[0]["CityName"].ToString() + ", " + ds2.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + ds1.Tables[0].Rows[0]["CountryName"].ToString() + ".";
                    cryRpt.SetParameterValue("Buyer_Address", Buyer_Address);

                    //   Consignee_Address 
                    string strCong_add = dsrs.Tables[0].Rows[0]["Cong_add"].ToString();
                    string strCong_country = fun.select("CountryName", "tblcountry", "CId='" + dsrs.Tables[0].Rows[0]["Cong_country"] + "'");
                    string strCong_state = fun.select("StateName", "tblState", "SId='" + dsrs.Tables[0].Rows[0]["Cong_state"] + "'");
                    string strCong_city = fun.select("CityName", "tblCity", "CityId='" + dsrs.Tables[0].Rows[0]["Cong_city"] + "'");
                    SqlCommand Cmd11 = new SqlCommand(strCong_country, con);
                    SqlCommand Cmd21 = new SqlCommand(strCong_state, con);
                    SqlCommand Cmd31 = new SqlCommand(strCong_city, con);
                    SqlDataAdapter DA11 = new SqlDataAdapter(Cmd11);
                    SqlDataAdapter DA21 = new SqlDataAdapter(Cmd21);
                    SqlDataAdapter DA31 = new SqlDataAdapter(Cmd31);
                    DataSet ds11 = new DataSet();
                    DataSet ds21 = new DataSet();
                    DataSet ds31 = new DataSet();
                    DA11.Fill(ds11, "tblCountry");
                    DA21.Fill(ds21, "tblState");
                    DA31.Fill(ds31, "tblcity");

                    string Consignee_Address = strCong_add + ",\n" + ds31.Tables[0].Rows[0]["CityName"].ToString() + ", " + ds21.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + ds11.Tables[0].Rows[0]["CountryName"].ToString() + ".";
                    cryRpt.SetParameterValue("Consignee_Address", Consignee_Address);

                    //   Company Address     
                    string CompAdd = fun.select("*", "tblCompany_master", "CompId='" + CompId + "'");
                    SqlCommand cmdCompAdd = new SqlCommand(CompAdd, con);
                    SqlDataAdapter daCompAdd = new SqlDataAdapter(cmdCompAdd);
                    DataSet dsCompAdd = new DataSet();
                    daCompAdd.Fill(dsCompAdd, "tblCompany_master");
                    string Address = dsCompAdd.Tables[0].Rows[0]["RegdAddress"].ToString() + ",\n" + fun.getCity(Convert.ToInt32(dsCompAdd.Tables[0].Rows[0]["RegdCity"]), 1) + ", " + fun.getState(Convert.ToInt32(dsCompAdd.Tables[0].Rows[0]["RegdState"]), 1) + ", " + fun.getCountry(Convert.ToInt32(dsCompAdd.Tables[0].Rows[0]["RegdCountry"]), 1) + " PIN No.-" + dsCompAdd.Tables[0].Rows[0]["RegdPinCode"].ToString() + ".\n" + "Ph No.-" + dsCompAdd.Tables[0].Rows[0]["RegdContactNo"].ToString() + ", " + " Fax No.-" + dsCompAdd.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "\n" + "Email No.-" + dsCompAdd.Tables[0].Rows[0]["RegdEmail"].ToString();

                    cryRpt.SetParameterValue("Address", Address);


                    // Calculate Freight,VAT & CST
                    int z = 0;
                    double F = 0;
                    double V = 0;
                    string x = "";
                    string y = "";
                    string m = "";
                    string n = "";
                    string p = "";
                    string type = "";

                    if (dsrs.Tables[0].Rows[0]["FreightType"].ToString() == "0")
                    {
                        type = "Amt(Rs)";
                    }
                    else
                    {
                        type = "Per(%)";
                    }

                    if (dsrs.Tables[0].Rows[0]["InvoiceMode"].ToString() == "2")
                    {
                        x = "Freight";
                        y = "VAT";

                        string SqlVat = fun.select("Terms,Value", "tblVAT_Master", "Id='" + dsrs.Tables[0].Rows[0]["VAT"].ToString() + "'");
                        SqlCommand cmdSqlVat = new SqlCommand(SqlVat, con);
                        SqlDataAdapter daSqlVat = new SqlDataAdapter(cmdSqlVat);
                        DataSet dsSqlVat = new DataSet();

                        daSqlVat.Fill(dsSqlVat, "tblVAT_Master");

                        if (dsSqlVat.Tables[0].Rows.Count > 0)
                        {
                            m = Convert.ToString(Convert.ToDouble(dsrs.Tables[0].Rows[0]["Freight"].ToString())) + "   " + type;
                            n = dsSqlVat.Tables[0].Rows[0]["Terms"].ToString();
                            V = Convert.ToDouble(dsSqlVat.Tables[0].Rows[0]["Value"].ToString());
                        }
                    }
                    else if (dsrs.Tables[0].Rows[0]["InvoiceMode"].ToString() == "3")
                    {
                        x = "CST";
                        y = "Freight";

                        if (dsrs.Tables[0].Rows[0]["SelectedCST"].ToString() == "0")
                        {
                            p = "With C Form";
                        }
                        else
                        {
                            p = "Without C Form";
                        }

                        n = dsrs.Tables[0].Rows[0]["Freight"].ToString() + "  " + type;

                        string SqlCst = fun.select("Terms,Value", "tblVAT_Master", "Id='" + dsrs.Tables[0].Rows[0]["CST"].ToString() + "'");
                        SqlCommand cmdSqlCst = new SqlCommand(SqlCst, con);
                        SqlDataAdapter daSqlCst = new SqlDataAdapter(cmdSqlCst);
                        DataSet dsSqlCst = new DataSet();
                        daSqlCst.Fill(dsSqlCst, "tblVAT_Master");

                        m = dsSqlCst.Tables[0].Rows[0]["Terms"].ToString() + " " + p;

                        V = Convert.ToDouble(dsSqlCst.Tables[0].Rows[0]["Value"].ToString());
                    }

                    F = Convert.ToDouble(dsrs.Tables[0].Rows[0]["Freight"].ToString());

                    if (dsrs.Tables[0].Rows[0]["FreightType"].ToString() == "0")
                    {
                        z = 0;
                    }
                    else
                    {
                        z = 1;
                    }

                    cryRpt.SetParameterValue("x", x);
                    cryRpt.SetParameterValue("y", y);
                    cryRpt.SetParameterValue("m", m);
                    cryRpt.SetParameterValue("n", n);
                    cryRpt.SetParameterValue("F", F);
                    cryRpt.SetParameterValue("V", V);
                    cryRpt.SetParameterValue("z", z);

                    // Date And Time in Text- Date Of Removal &Time Of Removal

                    string DateRemWordRem = fun.FromDateDMY(dsrs.Tables[0].Rows[0]["DateOfRemoval"].ToString());
                    string MDYDateStrRem = fun.FromDateMDY(DateRemWordRem);
                    DateTime dt4 = DateTime.Parse(MDYDateStrRem);
                    wordsRem = fun.DateToText(dt4, false, true);
                    string TimeInWordRem = dsrs.Tables[0].Rows[0]["TimeOfRemoval"].ToString();
                    string wordsRemTime = fun.TimeToText(TimeInWordRem);
                    cryRpt.SetParameterValue("wordsRem", wordsRem);
                    cryRpt.SetParameterValue("wordsRemTime", wordsRemTime);
                }

                cryRpt.SetParameterValue("PrintType", PrintType);
                CrystalReportViewer1.ReportSource = cryRpt;
                Session[Key] = cryRpt;

            }

            else
            {
                ReportDocument doc = (ReportDocument)Session[Key];
                CrystalReportViewer1.ReportSource = doc;
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



    protected void Page_Load(object sender, EventArgs e)
    {
        cryRpt = new ReportDocument();
        Type = Convert.ToInt32(Request.QueryString["T"]);
        Key1 = Request.QueryString["K"].ToString();
        CCode = Request.QueryString["cid"].ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        switch (Type)
        {
            case 0:
                Response.Redirect("SalesInvoice_Print.aspx?ModId=11&SubModId=51");
                break;
            case 1:
                Response.Redirect("~/Module/Accounts/Transactions/Acc_Sundry_Details.aspx?CustId=" + CCode + "&ModId=11&SubModId=&Key=" + Key1 + "");
                break;
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        cryRpt.Close();
        cryRpt.Dispose();
        GC.Collect();
    }
   
}
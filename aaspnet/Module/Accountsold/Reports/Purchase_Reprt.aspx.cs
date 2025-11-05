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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

public partial class Module_Accounts_Reports_Purchase_Reprt : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    int CompId = 0;
    int FinYearId = 0;
    string Fdate = string.Empty;
    string Tdate = string.Empty;
    ReportDocument cryRpt = new ReportDocument();
    ReportDocument cryRpt2 = new ReportDocument();

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DateTime x = fun.FirstDateInCurrMonth();
                string strtDate = x.Date.ToShortDateString().Replace('/', '-');
                TxtFromDate.Text = strtDate;
                DateTime x2 = fun.LastDateInCurrMonth();
                string EndDate = x2.Date.ToShortDateString().Replace('/', '-');
                TxtToDate.Text = EndDate;
                TextBox1.Text = strtDate;
                TextBox2.Text = EndDate;
                TextBox3.Text = strtDate;
                TextBox4.Text = EndDate;
                this.cryrpt_create2();

            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                ReportDocument doc2 = (ReportDocument)Session["ReportDocument2"];
                CrystalReportViewer1.ReportSource = doc;
                CrystalReportViewer2.ReportSource = doc;
                CrystalReportViewer3.ReportSource = doc2;
            }

        }
        catch (Exception ex)
        {
        }
        
    }

    public void cryrpt_create(int flag)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();

        try
        {          

                string wordsRem = string.Empty;
                FinYearId = Convert.ToInt32(Session["finyear"]);
                CompId = Convert.ToInt32(Session["compid"]);
                
                SqlCommand Cmdgrid;
                if (flag == 0)
                {
                    Fdate = TxtFromDate.Text;
                    Tdate = TxtToDate.Text;

                    Cmdgrid = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblQc_MaterialQuality_Details.AcceptedQty) as qty,sum(tblQc_MaterialQuality_Details.AcceptedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", con);

                }
                else
                {
                    Fdate = TextBox1.Text;
                    Tdate = TextBox2.Text;
                    Cmdgrid = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as qty,sum(tblinv_MaterialServiceNote_Details.ReceivedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblinv_MaterialServiceNote_Details ON tblACC_BillBooking_Details.GSNId = tblinv_MaterialServiceNote_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", con);


                }

                SqlDataReader rdr = Cmdgrid.ExecuteReader();                
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));//0 
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//1 
                dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));//2 
                dt.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(double)));//3 
                dt.Columns.Add(new System.Data.DataColumn("PFTerms", typeof(string)));//4
                dt.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));//5               
                dt.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(string)));//6
                dt.Columns.Add(new System.Data.DataColumn("ExciseAmt", typeof(double)));//7
                dt.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(string)));//8
                dt.Columns.Add(new System.Data.DataColumn("EDUValue", typeof(double)));//9
                dt.Columns.Add(new System.Data.DataColumn("SHECess", typeof(string)));//10
                dt.Columns.Add(new System.Data.DataColumn("SHEValue", typeof(double)));//11 
                dt.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));//12 
                dt.Columns.Add(new System.Data.DataColumn("VATCSTAmt", typeof(double)));//13
                dt.Columns.Add(new System.Data.DataColumn("FreightAmt", typeof(double)));//14
                dt.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));//15
                dt.Columns.Add(new System.Data.DataColumn("ExciseBasic", typeof(string)));//16
                dt.Columns.Add(new System.Data.DataColumn("ExBasicAmt", typeof(double)));//17
                dt2.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));//0 
                dt2.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//1 
                dt2.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));//2 
                dt2.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(double)));//3 
                dt2.Columns.Add(new System.Data.DataColumn("PFTerms", typeof(string)));//4
                dt2.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));//5               
                dt2.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(string)));//6
                dt2.Columns.Add(new System.Data.DataColumn("ExciseAmt", typeof(double)));//7
                dt2.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(string)));//8
                dt2.Columns.Add(new System.Data.DataColumn("EDUValue", typeof(double)));//9
                dt2.Columns.Add(new System.Data.DataColumn("SHECess", typeof(string)));//10
                dt2.Columns.Add(new System.Data.DataColumn("SHEValue", typeof(double)));//11 
                dt2.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));//12 
                dt2.Columns.Add(new System.Data.DataColumn("VATCSTAmt", typeof(double)));//13
                dt2.Columns.Add(new System.Data.DataColumn("FreightAmt", typeof(double)));//14
                dt2.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));//15
                dt2.Columns.Add(new System.Data.DataColumn("ExciseBasic", typeof(string)));//16
                dt2.Columns.Add(new System.Data.DataColumn("ExBasicAmt", typeof(double)));//17

                DataSet Purchase_Vat = new DataSet();
                DataRow dr;
                DataRow dr2;
                double VATGrossTotal = 0;
                double CSTGrossTotal = 0;
                double Total = 0;
                double TotalExcise = 0;

                while (rdr.Read())
                {
                    dr = dt.NewRow();
                    dr2 = dt2.NewRow();
                    dr[0] = fun.FromDateDMY(rdr["SysDate"].ToString());
                    dr2[0] = fun.FromDateDMY(rdr["SysDate"].ToString());
                    dr[1] = CompId.ToString();
                    dr2[1] = CompId.ToString();                  
                    dr[2] = rdr["SupplierName"].ToString() + " [" + rdr["SupplierId"].ToString() + "]";
                    dr2[2] = rdr["SupplierName"].ToString() + " [" + rdr["SupplierId"].ToString() + "]";                   

                    dr[3] = Convert.ToDouble(rdr["amt"]);
                    dr2[3] = Convert.ToDouble(rdr["amt"]);

                    string Strpf = fun.select("Value", "tblPacking_Master", "Id='" + rdr["PF"].ToString() + "'");
                    SqlCommand cmdpf = new SqlCommand(Strpf, con);
                    SqlDataAdapter dapf = new SqlDataAdapter(cmdpf);
                    DataSet DSpf = new DataSet();
                    dapf.Fill(DSpf);

                    dr[4] = DSpf.Tables[0].Rows[0]["Value"].ToString();
                    dr2[4] = DSpf.Tables[0].Rows[0]["Value"].ToString();

                    dr[5] = Convert.ToDouble(rdr["pfamt"]);
                    dr2[5] = Convert.ToDouble(rdr["pfamt"]);


                    string Strex = fun.select("Value,AccessableValue,EDUCess,SHECess", "tblExciseser_Master", "Id='" + rdr["ExST"].ToString() + "'");

                    SqlCommand cmdex = new SqlCommand(Strex, con);
                    SqlDataAdapter daex = new SqlDataAdapter(cmdex);
                    DataSet DSx = new DataSet();
                    daex.Fill(DSx);

                    dr[6] = DSx.Tables[0].Rows[0]["Value"].ToString();
                    dr2[6] = DSx.Tables[0].Rows[0]["Value"].ToString();

                    dr[7] = Convert.ToDouble(rdr["exba"]) + Convert.ToDouble(rdr["edu"]) + Convert.ToDouble(rdr["she"]);
                    dr2[7] = Convert.ToDouble(rdr["exba"]) + Convert.ToDouble(rdr["edu"]) + Convert.ToDouble(rdr["she"]);

                    dr[8] = DSx.Tables[0].Rows[0]["EDUCess"].ToString();
                    dr2[8] = DSx.Tables[0].Rows[0]["EDUCess"].ToString();

                    dr[9] = Convert.ToDouble(rdr["edu"]);
                    dr2[9] = Convert.ToDouble(rdr["edu"]);

                    dr[10] = DSx.Tables[0].Rows[0]["SHECess"].ToString();
                    dr2[10] = DSx.Tables[0].Rows[0]["SHECess"].ToString();

                    dr[11] = Convert.ToDouble(rdr["she"]);
                    dr2[11] = Convert.ToDouble(rdr["she"]);

                    string Strvat = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + rdr["VAT"].ToString() + "'");
                    SqlCommand cmdvat = new SqlCommand(Strvat, con);
                    SqlDataAdapter davat = new SqlDataAdapter(cmdvat);
                    DataSet DSvat = new DataSet();
                    davat.Fill(DSvat);

                    dr[12] = DSvat.Tables[0].Rows[0]["Value"].ToString();
                    dr2[12] = DSvat.Tables[0].Rows[0]["Value"].ToString();

                    double VatCst = 0;

                    if (DSvat.Tables[0].Rows[0]["IsVAT"].ToString() == "1")
                    {
                        dr[13] = Convert.ToDouble(rdr["vat1"]);
                        dr2[13] = Convert.ToDouble(rdr["vat1"]);
                        VatCst = Convert.ToDouble(rdr["vat1"]);
                    }
                    else if (DSvat.Tables[0].Rows[0]["IsCST"].ToString() == "1")
                    {
                        dr[13] = Convert.ToDouble(rdr["cst"]);
                        dr2[13] = Convert.ToDouble(rdr["cst"]);
                        VatCst = Convert.ToDouble(rdr["cst"]);
                    }
                    else if (DSvat.Tables[0].Rows[0]["IsVAT"].ToString() == "0" && DSvat.Tables[0].Rows[0]["IsCST"].ToString() == "0")
                    {
                        dr[13] = Convert.ToDouble(rdr["vat1"]);
                        dr2[13] = Convert.ToDouble(rdr["vat1"]);
                        VatCst = Convert.ToDouble(rdr["vat1"]);
                    }

                    dr[14] = Convert.ToDouble(rdr["fr"]);
                    dr2[14] = Convert.ToDouble(rdr["fr"]);

                    dr[15] = Convert.ToDouble(rdr["amt"]) + Convert.ToDouble(rdr["pfamt"]) + Convert.ToDouble(rdr["exba"]) + Convert.ToDouble(rdr["edu"]) + Convert.ToDouble(rdr["she"]) + VatCst + Convert.ToDouble(rdr["fr"]);
                    Total = Convert.ToDouble(rdr["amt"]) + Convert.ToDouble(rdr["pfamt"]) + Convert.ToDouble(rdr["exba"]) + Convert.ToDouble(rdr["edu"]) + Convert.ToDouble(rdr["she"]) + VatCst + Convert.ToDouble(rdr["fr"]);
                    dr2[15] = Total;
                    TotalExcise += Convert.ToDouble(rdr["exba"]) + Convert.ToDouble(rdr["edu"]) + Convert.ToDouble(rdr["she"]);

                    dr[16] = DSx.Tables[0].Rows[0]["AccessableValue"].ToString();
                    dr2[16] = DSx.Tables[0].Rows[0]["AccessableValue"].ToString();
                    dr[17] = rdr["eduBasic"].ToString();
                    dr2[17] = rdr["eduBasic"].ToString();

                    if (DSvat.Tables[0].Rows[0]["IsCST"].ToString() == "0")
                    {
                        VATGrossTotal += Total;

                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    else
                    {
                        CSTGrossTotal += Total;

                        dt2.Rows.Add(dr2);
                        dt2.AcceptChanges();
                    }
                }
                

                DataTable dtGroupedBy = fun.GetGroupedBy(dt, "VATCSTTerms,VATCSTAmt", "VATCSTTerms", "Sum");
                string MAHPurchase = string.Empty;

                for (int rows = 0; rows < dtGroupedBy.Rows.Count; rows++)
                {
                    MAHPurchase += "@ " + dtGroupedBy.Rows[rows][0].ToString() + "    Amt: " + dtGroupedBy.Rows[rows][1].ToString() + ",  ";
                }

                if (dt.Rows.Count > 0 || dt2.Rows.Count > 0)
                {
                   
                    CrystalReportViewer1.Visible = true;
                    CrystalReportViewer2.Visible = true;
                    lblsalemsg.Visible = false;
                    Label1.Visible = false;
                    Purchase_Vat.Tables.Add(dt);
                    Purchase_Vat.Tables.Add(dt2);
                    DataSet xsdds = new Vat_Purchase();
                    xsdds.Tables[0].Merge(Purchase_Vat.Tables[0]);
                    xsdds.Tables[1].Merge(Purchase_Vat.Tables[1]);
                    xsdds.AcceptChanges();
                    cryRpt = new ReportDocument();
                    cryRpt.Load(Server.MapPath("~/Module/Accounts/Reports/Purchase.rpt"));
                    cryRpt.SetDataSource(xsdds);
                    string Address = fun.CompAdd(CompId);                   
                    cryRpt.SetParameterValue("Address", Address);
                    cryRpt.SetParameterValue("FDate", Fdate);
                    cryRpt.SetParameterValue("TDate", Tdate);                   
                    cryRpt.SetParameterValue("VATGrossTotal", VATGrossTotal);
                    cryRpt.SetParameterValue("CSTGrossTotal", CSTGrossTotal);
                    cryRpt.SetParameterValue("TotalExcise", TotalExcise);
                    cryRpt.SetParameterValue("MAHPurchase", MAHPurchase);
                    CrystalReportViewer1.ReportSource = cryRpt;
                    CrystalReportViewer2.ReportSource = cryRpt;
                    Session["ReportDocument"] = cryRpt;
                   
                }
                else
                {
                    lblsalemsg.Visible = true;
                    lblsalemsg.Text = "No record found!";
                    Label1.Visible = true;
                    Label1.Text = "No record found!";
                    CrystalReportViewer1.Visible = false;
                    CrystalReportViewer2.Visible = false;
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

    public void cryrpt_create2()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        try
        {
            
                string wordsRem = string.Empty;
                FinYearId = Convert.ToInt32(Session["finyear"]);
                CompId = Convert.ToInt32(Session["compid"]);
                Fdate = TextBox3.Text;                
                Tdate = TextBox4.Text;                
                SqlCommand Cmdgrid1 = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblQc_MaterialQuality_Details.AcceptedQty) as qty,sum(tblQc_MaterialQuality_Details.AcceptedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblQc_MaterialQuality_Details ON tblACC_BillBooking_Details.GQNId = tblQc_MaterialQuality_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", con);
                SqlDataAdapter dagrid1 = new SqlDataAdapter(Cmdgrid1);
                DataSet dsrs1 = new DataSet();
                dagrid1.Fill(dsrs1);

                SqlCommand Cmdgrid = new SqlCommand("SELECT tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Master.SupplierId,sum(tblinv_MaterialServiceNote_Details.ReceivedQty) as qty,sum(tblinv_MaterialServiceNote_Details.ReceivedQty*(tblMM_PO_Details.Rate-(tblMM_PO_Details.Rate*tblMM_PO_Details.Discount/100))) as amt, sum(tblACC_BillBooking_Details.PFAmt) as pfamt,sum(tblACC_BillBooking_Details.ExStBasic)as exba, sum(tblACC_BillBooking_Details.ExStBasic)as eduBasic, sum(tblACC_BillBooking_Details.ExStEducess)as edu,sum(tblACC_BillBooking_Details.ExStShecess)as she,  sum(tblACC_BillBooking_Details.VAT)as vat1,sum(tblACC_BillBooking_Details.CST)as cst,sum(tblACC_BillBooking_Details.Freight)as fr,SupplierName FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId = tblACC_BillBooking_Master.Id INNER JOIN  tblinv_MaterialServiceNote_Details ON tblACC_BillBooking_Details.GSNId = tblinv_MaterialServiceNote_Details.Id INNER JOIN tblMM_PO_Details ON tblACC_BillBooking_Details.PODId = tblMM_PO_Details.Id inner join tblMM_Supplier_master on tblMM_Supplier_master.SupplierId=tblACC_BillBooking_Master.SupplierId And  tblACC_BillBooking_Master.CompId='" + CompId + "' AND  tblACC_BillBooking_Master.SysDate between '" + fun.FromDate(Fdate) + "'  And '" + fun.FromDate(Tdate) + "' Group by tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.SysDate,tblACC_BillBooking_Details.MId,tblACC_BillBooking_Master.SupplierId,SupplierName", con);
                SqlDataAdapter dagrid = new SqlDataAdapter(Cmdgrid);
                DataSet dsrs = new DataSet();
                dagrid.Fill(dsrs);                
                dsrs.Tables[0].Merge(dsrs1.Tables[0]); 
                dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));//0 
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//1 
                dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));//2 
                dt.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(double)));//3 
                dt.Columns.Add(new System.Data.DataColumn("PFTerms", typeof(string)));//4
                dt.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));//5               
                dt.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(string)));//6
                dt.Columns.Add(new System.Data.DataColumn("ExciseAmt", typeof(double)));//7
                dt.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(string)));//8
                dt.Columns.Add(new System.Data.DataColumn("EDUValue", typeof(double)));//9
                dt.Columns.Add(new System.Data.DataColumn("SHECess", typeof(string)));//10
                dt.Columns.Add(new System.Data.DataColumn("SHEValue", typeof(double)));//11 
                dt.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));//12 
                dt.Columns.Add(new System.Data.DataColumn("VATCSTAmt", typeof(double)));//13
                dt.Columns.Add(new System.Data.DataColumn("FreightAmt", typeof(double)));//14
                dt.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));//15
                dt.Columns.Add(new System.Data.DataColumn("ExciseBasic", typeof(string)));//16
                dt.Columns.Add(new System.Data.DataColumn("ExBasicAmt", typeof(double)));//17
                dt2.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));//0 
                dt2.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//1 
                dt2.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));//2 
                dt2.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(double)));//3 
                dt2.Columns.Add(new System.Data.DataColumn("PFTerms", typeof(string)));//4
                dt2.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));//5               
                dt2.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(string)));//6
                dt2.Columns.Add(new System.Data.DataColumn("ExciseAmt", typeof(double)));//7
                dt2.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(string)));//8
                dt2.Columns.Add(new System.Data.DataColumn("EDUValue", typeof(double)));//9
                dt2.Columns.Add(new System.Data.DataColumn("SHECess", typeof(string)));//10
                dt2.Columns.Add(new System.Data.DataColumn("SHEValue", typeof(double)));//11 
                dt2.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));//12 
                dt2.Columns.Add(new System.Data.DataColumn("VATCSTAmt", typeof(double)));//13
                dt2.Columns.Add(new System.Data.DataColumn("FreightAmt", typeof(double)));//14
                dt2.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));//15
                dt2.Columns.Add(new System.Data.DataColumn("ExciseBasic", typeof(string)));//16
                dt2.Columns.Add(new System.Data.DataColumn("ExBasicAmt", typeof(double)));//17

                DataSet Purchase_Vat = new DataSet();
                DataRow dr;
                DataRow dr2;
                double VATGrossTotal = 0;
                double CSTGrossTotal = 0;
                double Total = 0;
                double TotalExcise = 0;               
                for (int i = 0; i < dsrs.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr2 = dt2.NewRow();
                    dr[0] = fun.FromDateDMY(dsrs.Tables[0].Rows[i]["SysDate"].ToString());
                    dr2[0] = fun.FromDateDMY(dsrs.Tables[0].Rows[i]["SysDate"].ToString());
                    dr[1] = CompId.ToString();
                    dr2[1] = CompId.ToString();
                    dr[2] = dsrs.Tables[0].Rows[i]["SupplierName"].ToString() + " [" + dsrs.Tables[0].Rows[i]["SupplierId"].ToString() + "]";
                    dr2[2] = dsrs.Tables[0].Rows[i]["SupplierName"].ToString() + " [" + dsrs.Tables[0].Rows[i]["SupplierId"].ToString() + "]";                    
                    

                    dr[3] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["amt"]);
                    dr2[3] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["amt"]);

                    string Strpf = fun.select("Value", "tblPacking_Master", "Id='" + dsrs.Tables[0].Rows[i]["PF"].ToString() + "'");
                    SqlCommand cmdpf = new SqlCommand(Strpf, con);
                    SqlDataAdapter dapf = new SqlDataAdapter(cmdpf);
                    DataSet DSpf = new DataSet();
                    dapf.Fill(DSpf);

                    dr[4] = DSpf.Tables[0].Rows[0]["Value"].ToString();
                    dr2[4] = DSpf.Tables[0].Rows[0]["Value"].ToString();

                    dr[5] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["pfamt"]);
                    dr2[5] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["pfamt"]);


                    string Strex = fun.select("Value,AccessableValue,EDUCess,SHECess", "tblExciseser_Master", "Id='" + dsrs.Tables[0].Rows[i]["ExST"].ToString() + "'");

                    SqlCommand cmdex = new SqlCommand(Strex, con);
                    SqlDataAdapter daex = new SqlDataAdapter(cmdex);
                    DataSet DSx = new DataSet();
                    daex.Fill(DSx);

                    dr[6] = DSx.Tables[0].Rows[0]["Value"].ToString();
                    dr2[6] = DSx.Tables[0].Rows[0]["Value"].ToString();

                    dr[7] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);
                    dr2[7] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);

                    dr[8] = DSx.Tables[0].Rows[0]["EDUCess"].ToString();
                    dr2[8] = DSx.Tables[0].Rows[0]["EDUCess"].ToString();

                    dr[9] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]);
                    dr2[9] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]);

                    dr[10] = DSx.Tables[0].Rows[0]["SHECess"].ToString();
                    dr2[10] = DSx.Tables[0].Rows[0]["SHECess"].ToString();

                    dr[11] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);
                    dr2[11] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);

                    string Strvat = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + dsrs.Tables[0].Rows[i]["VAT"].ToString() + "'");
                    SqlCommand cmdvat = new SqlCommand(Strvat, con);
                    SqlDataAdapter davat = new SqlDataAdapter(cmdvat);
                    DataSet DSvat = new DataSet();
                    davat.Fill(DSvat);
                    dr[15] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]) ;
                    Total = Convert.ToDouble(dsrs.Tables[0].Rows[i]["amt"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["pfamt"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);
                    dr2[15] = Total;
                    TotalExcise += Convert.ToDouble(dsrs.Tables[0].Rows[i]["exba"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["edu"]) + Convert.ToDouble(dsrs.Tables[0].Rows[i]["she"]);

                    dr[16] = DSx.Tables[0].Rows[0]["AccessableValue"].ToString();
                    dr2[16] = DSx.Tables[0].Rows[0]["AccessableValue"].ToString();
                    dr[17] = dsrs.Tables[0].Rows[i]["eduBasic"].ToString();
                    dr2[17] = dsrs.Tables[0].Rows[i]["eduBasic"].ToString();

                    if (DSvat.Tables[0].Rows[0]["IsCST"].ToString() == "0")
                    {
                        VATGrossTotal += Total;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    else
                    {
                        CSTGrossTotal += Total;

                        dt2.Rows.Add(dr2);
                        dt2.AcceptChanges();
                    }
                }
               

                DataTable dtGroupedBy = fun.GetGroupedBy(dt, "VATCSTTerms,VATCSTAmt", "VATCSTTerms", "Sum");
                string MAHPurchase = string.Empty;

                for (int rows = 0; rows < dtGroupedBy.Rows.Count; rows++)
                {
                    MAHPurchase += "@ " + dtGroupedBy.Rows[rows][0].ToString() + "    Amt: " + dtGroupedBy.Rows[rows][1].ToString() + ",  ";
                }
               
                if (dt.Rows.Count > 0 || dt2.Rows.Count > 0)
                {

                    CrystalReportViewer3.Visible = true;                   
                    Label2.Visible = false;
                    Purchase_Vat.Tables.Add(dt);
                    Purchase_Vat.Tables.Add(dt2);
                    DataSet xsdds = new Vat_Purchase();
                    xsdds.Tables[0].Merge(Purchase_Vat.Tables[0]);
                    xsdds.Tables[1].Merge(Purchase_Vat.Tables[1]);
                    xsdds.AcceptChanges();
                    cryRpt2 = new ReportDocument();
                    cryRpt2.Load(Server.MapPath("~/Module/Accounts/Reports/Purchase_Excise.rpt"));
                    cryRpt2.SetDataSource(xsdds);
                    string Address = fun.CompAdd(CompId);
                    cryRpt2.SetParameterValue("Address", Address);
                    cryRpt2.SetParameterValue("FDate", Fdate);
                    cryRpt2.SetParameterValue("TDate", Tdate);
                    cryRpt2.SetParameterValue("VATGrossTotal", VATGrossTotal);
                    cryRpt2.SetParameterValue("CSTGrossTotal", CSTGrossTotal);
                    cryRpt2.SetParameterValue("TotalExcise", TotalExcise);
                    cryRpt2.SetParameterValue("MAHPurchase", MAHPurchase);
                    CrystalReportViewer3.ReportSource = cryRpt2;                   
                    Session["ReportDocument2"] = cryRpt2;
                }
                else
                {
                   
                    Label2.Visible = true;
                    Label2.Text = "No record found!";
                    CrystalReportViewer3.Visible = false;
                   
                }
            

        }
        catch (Exception ex)
        {

        }
         finally
        {
            con.Close();
            dt.Dispose();
            dt2.Dispose();
            
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
      cryRpt = new ReportDocument();
      cryRpt2 = new ReportDocument();
      
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {       
        GC.Collect();
    }
    public DateTime LastDateInCurrMonth()
    {
        DateTime FirstDateOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        return FirstDateOfMonth.AddMonths(1).AddDays(-1);
    }

    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        this.cryrpt_create(0);
    }

    protected void Btnsearch2_Click(object sender, EventArgs e)
    {        
        this.cryrpt_create(1);
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {


        if (TabContainer1.ActiveTabIndex == 1)
        {
            this.cryrpt_create(0);
        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            this.cryrpt_create(1);
        }
        else
        {
            this.cryrpt_create2();
        }
    }
    protected void Btnsearch1_Click(object sender, EventArgs e)
    {
        this.cryrpt_create2();
    }
}

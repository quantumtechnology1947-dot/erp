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

public partial class Module_Accounts_Reports_Vat_Register : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    int CompId = 0;
    int FinYearId = 0;
    string Fdate = "";
    string Tdate = "";
    ReportDocument cryRpt = new ReportDocument();
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // use US English culture throughout the examples
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            //string wordsIss;
            string wordsRem = string.Empty;

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
           try
            {
                FinYearId = Convert.ToInt32(Session["finyear"]);
                CompId = Convert.ToInt32(Session["compid"]);
                Fdate = Request.QueryString["FD"].ToString();
                Tdate = Request.QueryString["TD"].ToString();

                SqlCommand Cmdgrid = new SqlCommand(fun.select("*", "tblACC_SalesInvoice_Master", "CompId='" + CompId + "'  And SysDate between '" + fun.FromDate(Fdate) + "' And '" + fun.FromDate(Tdate) + "' "), con);
                SqlDataAdapter dagrid = new SqlDataAdapter(Cmdgrid);
                DataSet dsrs = new DataSet();
                dagrid.Fill(dsrs);
                
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("InvoiceNo", typeof(string)));                
                dt.Columns.Add(new System.Data.DataColumn("CustomerCode", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));


               dt.Columns.Add(new System.Data.DataColumn("Total", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("ExciseTerms", typeof(string)));
               dt.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("PFType", typeof(int)));
               dt.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("AccessableValue", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("SHECess", typeof(double)));


               dt.Columns.Add(new System.Data.DataColumn("FreightType", typeof(int)));
               dt.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));

               dt.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));
               dt.Columns.Add(new System.Data.DataColumn("VATCST", typeof(double)));
               dt.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));


               dt2.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
               dt2.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
               dt2.Columns.Add(new System.Data.DataColumn("InvoiceNo", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("CustomerCode", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("Total", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("ExciseTerms", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("ExciseValues", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("PFType", typeof(int)));
               dt2.Columns.Add(new System.Data.DataColumn("PF", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("AccessableValue", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("EDUCess", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("SHECess", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("FreightType", typeof(int)));
               dt2.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("VATCSTTerms", typeof(string)));
               dt2.Columns.Add(new System.Data.DataColumn("VATCST", typeof(double)));
               dt2.Columns.Add(new System.Data.DataColumn("TotAmt", typeof(double)));


                DataSet Sales_Vat= new DataSet();
                DataRow dr;

                DataRow dr2;

                double vattotal = 0;
                double csttotal = 0;
                double basictotal = 0;
                double excisetotal = 0;
                double ACCtotal = 0;
                double EDUTotal=0;
                double SHETotal = 0;

                if (dsrs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsrs.Tables[0].Rows.Count; i++)
                    {

                        double BasicAmt = 0;
                        double PfAmt = 0;
                        double ExciseAmt = 0;
                        double AccValue = 0;
                        double EDUValue = 0;
                        double SHEValue = 0;
                        double FreightAmt = 0;
                        double VATCSTAmt = 0;
                        double Amount1 = 0;
                        double Amount2 = 0;
                        double Amount3 = 0;
                        double TotAmt = 0;

                        dr = dt.NewRow();
                        dr2 = dt2.NewRow();
                       
                        dr[0] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["Id"]);
                        dr2[0] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["Id"]);
                        dr[1] = fun.FromDateDMY(dsrs.Tables[0].Rows[i]["SysDate"].ToString());
                        dr2[1] = fun.FromDateDMY(dsrs.Tables[0].Rows[i]["SysDate"].ToString());
                        dr[2] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["CompId"]);
                        dr2[2] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["CompId"]);
                        dr[3] = dsrs.Tables[0].Rows[i]["InvoiceNo"].ToString();
                        dr2[3] = dsrs.Tables[0].Rows[i]["InvoiceNo"].ToString();
                        dr[4] = dsrs.Tables[0].Rows[i]["CustomerCode"].ToString();
                        dr2[4] = dsrs.Tables[0].Rows[i]["CustomerCode"].ToString();

                        string StrCust = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dsrs.Tables[0].Rows[i]["CustomerCode"].ToString() + "'");

                        SqlCommand cmdCust = new SqlCommand(StrCust, con);
                        SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
                        DataSet DSCust = new DataSet();
                        daCust.Fill(DSCust);
                       
                        if (DSCust.Tables[0].Rows.Count > 0)
                        {
                            dr[5] = DSCust.Tables[0].Rows[0]["CustomerName"].ToString();
                            dr2[5] = DSCust.Tables[0].Rows[0]["CustomerName"].ToString();
                        }

                        string StrCust1 = fun.select("Sum((Qty*Rate)) As Total", "tblACC_SalesInvoice_Details", "MId='" + Convert.ToInt32(dsrs.Tables[0].Rows[i]["Id"]) + "'");

                        SqlCommand cmdCust1 = new SqlCommand(StrCust1, con);
                        SqlDataAdapter daCust1 = new SqlDataAdapter(cmdCust1);
                        DataSet DSCust1 = new DataSet();
                        daCust1.Fill(DSCust1);
                        dr[6] = Convert.ToDouble(DSCust1.Tables[0].Rows[0]["Total"]);
                        dr2[6] = Convert.ToDouble(DSCust1.Tables[0].Rows[0]["Total"]);


                        string StrEx = fun.select("*", "tblExciseser_Master", "Id='" + dsrs.Tables[0].Rows[i]["CENVAT"].ToString() + "'");
                        SqlCommand CmdEx = new SqlCommand(StrEx, con);
                        SqlDataAdapter DaEx = new SqlDataAdapter(CmdEx);
                        DataSet DSEx = new DataSet();
                        DaEx.Fill(DSEx);

                        dr[7] = DSEx.Tables[0].Rows[0]["Terms"].ToString();

                        dr[8] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["Value"]);





                        dr2[7] = DSEx.Tables[0].Rows[0]["Terms"].ToString();

                        dr2[8] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["Value"]);

                        dr[11] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["AccessableValue"]);
                        dr[12] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["EDUCess"]);
                        dr[13] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["SHECess"]);
                        dr[9] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["PFType"]);
                        dr[10] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["PF"]);
                        dr[14] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["FreightType"]);
                        dr[15] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["Freight"]);

                        dr2[11] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["AccessableValue"]);
                        dr2[12] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["EDUCess"]);
                        dr2[13] = Convert.ToDouble(DSEx.Tables[0].Rows[0]["SHECess"]);
                        dr2[9] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["PFType"]);
                        dr2[10] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["PF"]);
                        dr2[14] = Convert.ToInt32(dsrs.Tables[0].Rows[i]["FreightType"]);
                        dr2[15] = Convert.ToDouble(dsrs.Tables[0].Rows[i]["Freight"]);


                        BasicAmt = Convert.ToDouble(DSCust1.Tables[0].Rows[0]["Total"]);
                        if (Convert.ToInt32(dsrs.Tables[0].Rows[i]["PFType"]) == 0)
                        {
                            PfAmt = Convert.ToDouble(dsrs.Tables[0].Rows[i]["PF"]);
                        }
                        else
                        {
                            PfAmt = (BasicAmt * ((Convert.ToDouble(dsrs.Tables[0].Rows[i]["PF"])) / 100));
                        }

                        Amount1 = BasicAmt + PfAmt;

                        ExciseAmt = (Amount1 * (Convert.ToDouble(DSEx.Tables[0].Rows[0]["Value"]))) / 100;
                        AccValue = ((Amount1 * Convert.ToDouble(DSEx.Tables[0].Rows[0]["AccessableValue"])) / 100);
                        EDUValue = ((AccValue * Convert.ToDouble(DSEx.Tables[0].Rows[0]["EDUCess"])) / 100);
                        SHEValue = ((AccValue * Convert.ToDouble(DSEx.Tables[0].Rows[0]["SHECess"])) / 100); 


                        Amount2 = Amount1 + ExciseAmt;
                      

                        if (Convert.ToInt32(dsrs.Tables[0].Rows[i]["FreightType"]) == 0)
                        {
                            FreightAmt = Convert.ToDouble(dsrs.Tables[0].Rows[i]["Freight"]);
                        }
                        else
                        {
                            FreightAmt = (Amount2 * (Convert.ToDouble(dsrs.Tables[0].Rows[i]["Freight"]))) / 100;
                        }

                        if(dsrs.Tables[0].Rows[i]["VAT"].ToString()!="0")
                        {
                           basictotal += Convert.ToDouble(DSCust1.Tables[0].Rows[0]["Total"]);
                           excisetotal += ExciseAmt;
                           ACCtotal +=AccValue;
                           EDUTotal += EDUValue;
                           SHETotal +=SHEValue;

                        string StrVC = fun.select("*", "tblVAT_Master", "Id='" + dsrs.Tables[0].Rows[i]["VAT"].ToString() + "'");
                        SqlCommand CmdVC = new SqlCommand(StrVC, con);
                        SqlDataAdapter DaVC = new SqlDataAdapter(CmdVC);
                        DataSet DSVC = new DataSet();
                        DaVC.Fill(DSVC, "tblVAT_Master");                                              
                                                  
                            dr[16] = (DSVC.Tables[0].Rows[0]["Value"].ToString() + "%");
                            
                            Amount3 = Amount2 + FreightAmt;
                            VATCSTAmt = ((Amount3 * (Convert.ToDouble(DSVC.Tables[0].Rows[0]["Value"]))) / 100);
                            dr[17] = VATCSTAmt;
                            vattotal += VATCSTAmt;
                            
                            TotAmt = Amount3 + VATCSTAmt;
                            dr[18] = TotAmt;
                           
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        else if (dsrs.Tables[0].Rows[i]["CST"].ToString()!="0")
                        {
                            basictotal += Convert.ToDouble(DSCust1.Tables[0].Rows[0]["Total"]);
                            excisetotal += ExciseAmt;

                            ACCtotal += AccValue;
                            EDUTotal += EDUValue;
                            SHETotal += SHEValue;
                        string StrVC = fun.select("*", "tblVAT_Master", "Id='" + dsrs.Tables[0].Rows[i]["CST"].ToString() + "'");
                        SqlCommand CmdVC = new SqlCommand(StrVC, con);
                        SqlDataAdapter DaVC = new SqlDataAdapter(CmdVC);
                        DataSet DSVC = new DataSet();
                        DaVC.Fill(DSVC, "tblVAT_Master");
                   
                        dr2[16] = (DSVC.Tables[0].Rows[0]["Value"].ToString() + "%");
                            VATCSTAmt = ((Amount2 * (Convert.ToDouble(DSVC.Tables[0].Rows[0]["Value"]))) / 100);

                            TotAmt = Amount2 + VATCSTAmt + FreightAmt;
                            dr2[17] = VATCSTAmt;
                            csttotal += VATCSTAmt;
                            dr2[18] = TotAmt;

                            dt2.Rows.Add(dr2);
                            dt2.AcceptChanges();

                        }
                       
                    }

                }                


                Sales_Vat.Tables.Add(dt);
                Sales_Vat.Tables.Add(dt2);

                DataSet xsdds = new Vat_Sales();
                xsdds.Tables[0].Merge(Sales_Vat.Tables[0]);
                xsdds.Tables[1].Merge(Sales_Vat.Tables[1]);
                xsdds.AcceptChanges();
                cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/Module/Accounts/Reports/Sales_Vat.rpt"));
                cryRpt.SetDataSource(xsdds);
                string Address = fun.CompAdd(CompId);
                cryRpt.SetParameterValue("Address", Address);
                cryRpt.SetParameterValue("FDate", Fdate);
                cryRpt.SetParameterValue("TDate", Tdate);
                cryRpt.SetParameterValue("BasicTotal",Math.Round( basictotal));
                cryRpt.SetParameterValue("ExciseTotal", Math.Round(excisetotal));
                cryRpt.SetParameterValue("VATTotal", Math.Round(vattotal));
                cryRpt.SetParameterValue("CSTTotal", Math.Round(csttotal));

                cryRpt.SetParameterValue("ACCtotal", Math.Round(ACCtotal));
                cryRpt.SetParameterValue("EDUTotal", Math.Round(EDUTotal));
                cryRpt.SetParameterValue("SHETotal", Math.Round(SHETotal));
                CrystalReportViewer1.ReportSource = cryRpt;
                Session["ReportDocument"] = cryRpt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

        }

        else
        {
            ReportDocument doc = (ReportDocument)Session["ReportDocument"];
            CrystalReportViewer1.ReportSource = doc;
        }
    }

    private void If(bool p)
    {
        throw new NotImplementedException();
    }


    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sales_Register.aspx");
    }


}
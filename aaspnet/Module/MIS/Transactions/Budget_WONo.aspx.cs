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

public partial class Module_Accounts_Transactions_Budget_WONo : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    string connStr =string.Empty;
    SqlConnection con ;
    int CompId=0;
    int FinYearId = 0;
    string CDate = string.Empty;
    string CTime = string.Empty;
    string wono = string.Empty;
    string sId = string.Empty;

    public void CalculateBalAmt()
    {       
       try
        {
            string wono = Request.QueryString["WONo"].ToString();
            con.Open();
            {
                double PoAmt = 0;
                double TaxAmt = 0;


                //New 
                double InvAmt = 0;
                double PoInv = 0;
                double InvActAmt = 0;
                double TaxAct = 0;

                // End
                double cashpay = 0;
                double cashrec = 0;
                double BalBudget = 0;
                int prevYear = 0;
                double TotBudget = 0;

                prevYear = (FinYearId - 1);
                DataTable DT = new DataTable();
                DT.Columns.Add(new System.Data.DataColumn("Sr No", typeof(int)));
                DT.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                DT.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
                DT.Columns.Add(new System.Data.DataColumn("Budget Code", typeof(string)));
                DT.Columns.Add(new System.Data.DataColumn("Budget Amount", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("PO Amount", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Cash Pay Amount", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Cash Rec. Amount", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Tax", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Bal Budget Amount", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Invoice", typeof(double)));
                DT.Columns.Add(new System.Data.DataColumn("Actual Amount", typeof(double)));
                int SrNo = 1;
                DataRow dr;

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    dr = DT.NewRow();
                    dr[0] = SrNo++;
                    dr[1] = ((Label)grv.FindControl("lblDesc")).Text;
                    dr[2] = ((Label)grv.FindControl("lblSymbol")).Text;
                    dr[3] = ((Label)grv.FindControl("LblBudgetCode")).Text;
                    int accid = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                    double totalCash = 0;
                    double totalCashRec = 0;
                    double budget = 0;
                    double openingBalOfPrevYear = 0;
                    openingBalOfPrevYear = calbalbud.TotBalBudget_WONO(accid, CompId, prevYear,wono,0);

                    string selectBudget = "select Sum(Amount) As Budget from tblACC_Budget_WO where BudgetCodeId='" + accid + "'   and  WONo='" + wono + "' And FinYearId=" + FinYearId + " group by  BudgetCodeId ";
                    SqlCommand cmdBD = new SqlCommand(selectBudget, con);
                    SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
                    DataSet dsBD = new DataSet();
                    daBD.Fill(dsBD, "tblACC_Budget_WO");

                    ((HyperLink)grv.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_WONo_Details.aspx?WONo=" + wono + "&Id=" + accid + "&ModId=14";

                    if (dsBD.Tables[0].Rows.Count > 0)
                    {
                        budget = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["Budget"]) + openingBalOfPrevYear), 2);                       
                        
                        ((HyperLink)grv.FindControl("HyperLink1")).Visible = true;
                    }
                    else
                    {
                        budget = openingBalOfPrevYear;  
                        ((HyperLink)grv.FindControl("HyperLink1")).Visible = false;
                    }
                    ((Label)grv.FindControl("lblAmount")).Text = budget.ToString();
                   
                    double POPRBasicDiscAmt = 0; 
                    double POSPRBasicDiscAmt = 0;
                    POPRBasicDiscAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 0, 1, wono, 0,  1,FinYearId);
                    POSPRBasicDiscAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, wono, 0,  1,FinYearId);
                    ((Label)grv.FindControl("lblPO")).Text = Convert.ToString(Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2));

                    PoAmt += Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2);
                    double POPRTaxAmt = 0;
                    double POSPRTaxAmt = 0;

                    POPRTaxAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 0, 1, wono, 0,  2,FinYearId);
                    POSPRTaxAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, wono, 0, 2,FinYearId);

                    ((Label)grv.FindControl("lblTax")).Text = Convert.ToString(Math.Round(POPRTaxAmt + POSPRTaxAmt, 2));
                  
                    TaxAmt += Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);

                    string CashAmt = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt  ,tblACC_CashVoucher_Payment_Details.WONo FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.WONo='" + wono + "' And tblACC_CashVoucher_Payment_Master.FinYearId=" + FinYearId + "  And     tblACC_CashVoucher_Payment_Details.BudgetCode='" + accid + "'      GROUP BY tblACC_CashVoucher_Payment_Details.BudgetCode, tblACC_CashVoucher_Payment_Details.WONo";
                   
                    SqlCommand cmdCash = new SqlCommand(CashAmt, con);
                    SqlDataAdapter daCash = new SqlDataAdapter(cmdCash);
                    DataSet dsCash = new DataSet();
                    daCash.Fill(dsCash);
                    if (dsCash.Tables[0].Rows.Count > 0)
                    {
                        totalCash = Convert.ToDouble(dsCash.Tables[0].Rows[0][0]); 
                        cashpay += Math.Round(totalCash, 2);
                    }
                    ((Label)grv.FindControl("lblCashPay")).Text = Convert.ToString(Math.Round(totalCash, 2));

                    string CashAmt1 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt,   tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.WONo='" + wono + "'   And     tblACC_CashVoucher_Receipt_Master.BudgetCode='" + accid + "' And tblACC_CashVoucher_Receipt_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Receipt_Master.BudgetCode, tblACC_CashVoucher_Receipt_Master.WONo";

                    SqlCommand cmdCash1 = new SqlCommand(CashAmt1, con);
                    SqlDataAdapter daCash1 = new SqlDataAdapter(cmdCash1);
                    DataSet dsCash1 = new DataSet();
                    daCash1.Fill(dsCash1);
                  
                    if (dsCash1.Tables[0].Rows.Count > 0)
                    {
                        totalCashRec = Convert.ToDouble(dsCash1.Tables[0].Rows[0][0]);                        
                        cashrec += Math.Round(totalCashRec, 2);
                    }

                    ((Label)grv.FindControl("lblCashRec")).Text = Convert.ToString(Math.Round(totalCashRec, 2));

                    TotBudget += Math.Round(budget, 2);

                    dr[4] = Math.Round(budget, 2);
                    dr[5] = Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2);
                    dr[6] = Math.Round(totalCash, 2);
                    dr[8] = Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);
                    dr[7] = Math.Round(totalCashRec, 2);
                    double TotBalBudget = 0;                    
                    TotBalBudget = Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text) - (Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2) + Math.Round(totalCash, 2)), 2) + Math.Round(totalCashRec, 2);

                    ((Label)grv.FindControl("lblBudget")).Text = TotBalBudget.ToString();
                    dr[9] = Math.Round(TotBalBudget, 2);




                    // New Start

                    

                    double FinInvoice = 0;
                    FinInvoice = Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) - Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);

                    ((Label)grv.FindControl("lblInv")).Text = FinInvoice.ToString();

                    dr[10] = Math.Round(FinInvoice, 2);
                    PoInv += Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) - Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);

                  
                    double FinActAmt = 0;
                    FinActAmt = Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);
                    ((Label)grv.FindControl("lblActAmt")).Text = FinActAmt.ToString();

                    dr[11] = Math.Round(FinActAmt, 2);
                    TaxAct += Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2);

                    //End Here





                    DT.Rows.Add(dr);
                    DT.AcceptChanges();
                    BalBudget += Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text) - (Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2) + Math.Round(totalCash, 2)), 2) + Math.Round(totalCashRec, 2);

                }

                ViewState["dtList"] = DT;

               ((Label)GridView1.FooterRow.FindControl("lblTotalBudAmt")).Text = TotBudget.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblPO1")).Text = PoAmt.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblTax1")).Text = TaxAmt.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblBudget1")).Text = BalBudget.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblCashPay1")).Text = cashpay.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblCashRec1")).Text = cashrec.ToString();


               // New 
               ((Label)GridView1.FooterRow.FindControl("lblInv1")).Text = PoInv.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblActAmt1")).Text = TaxAct.ToString();
                // End




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
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        CDate = fun.getCurrDate();
        CTime = fun.getCurrTime();
        wono = Request.QueryString["WONo"].ToString();
        sId = Session["username"].ToString();
    try
    {
        //if (!Page.IsPostBack)
        {
            this.CalculateBalAmt();

        }

        foreach (GridViewRow grv in GridView1.Rows)
        {
            int accid = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);           
            string Bcode = fun.select("Symbol", "tblMIS_BudgetCode", "Id='" + accid + "'");
            SqlCommand cmd = new SqlCommand(Bcode, con);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet Ds = new DataSet();
            Da.Fill(Ds);
            string symbol = Ds.Tables[0].Rows[0]["Symbol"].ToString();           
            string budgetCode = String.Concat(symbol, wono);
            ((Label)grv.FindControl("LblBudgetCode")).Text = budgetCode;            

        }
    }
    catch (Exception ex)
    {
    }

    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {       
       
    }  

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       
        try
        {
        foreach (GridViewRow grv in GridView1.Rows)
        {
            if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
            {
                ((TextBox)grv.FindControl("TxtAmount")).Visible = true;
               
                ((Label)grv.FindControl("lblAmount")).Visible = false;
               
            }
            else
            {
                ((Label)grv.FindControl("lblAmount")).Visible = true;

                
                ((TextBox)grv.FindControl("TxtAmount")).Visible = false;
            }
        }
        }
        catch (Exception ex)
        {
        }

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Budget_Dist_WONo.aspx?ModId=14");
    }

   

   
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        
        try
        {                     
            con.Open();
            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    double Amt = Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text);

                    if (Amt > 0)
                    {
                        string insert = ("Insert into  tblACC_Budget_WO (SysDate,SysTime,CompId,FinYearId,SessionId,WONo,BudgetCodeId,Amount  ) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + id + "','" + Amt + "')");
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.ExecuteNonQuery();

                    }
                }


            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel ex = new ExportToExcel();
            ex.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_WONO");
        }
        catch (Exception ex1)
        {
            string mystring = string.Empty;
            mystring = "No Records to Export.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
        } 


    }


    //public double getTotal_PO_Budget_Amt(int compid, int accid, int prspr, int wodept, string wono, int dept, int authnon, int BasicTax)
    //{
    //    /* authnon - PO is Auth or Non Auth 
    //       prspr - 0 for PR & 1 for SPR
    //       wodept - 0 do not include any wo or dept, 1 include wo or dept
    //       wono - wo no 
    //       dept - dept id
    //       accid - A/c Id
    //       BasicTax - 0 Basic Amt & 1 Basic Disc Amt & 2 Only Tax Amt & 3 Basic + Disc + Tax Amt
    //       RtnType - 
    //     */

    //    string includeWODept = "";

    //    string connStr = fun.Connection();
    //    SqlConnection con = new SqlConnection(connStr);
    //    con.Open();
    //    double Amt = 0;
    //   try
    //    {
    //        if (prspr == 0)
    //        {
    //            string sqlPO = fun.select("tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Details.BudgetCode='" + accid + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "' AND tblMM_PO_Master.Authorize='" + authnon + "'");
    //            SqlCommand cmd = new SqlCommand(sqlPO, con);
    //            SqlDataAdapter DA = new SqlDataAdapter(cmd);
    //            DataSet DS = new DataSet();
    //            DA.Fill(DS);

                

    //            if (DS.Tables[0].Rows.Count > 0)
    //            {
    //                for (int u = 0; u < DS.Tables[0].Rows.Count; u++)
    //                {
    //                    includeWODept = "";
    //                    if (wodept == 1)
    //                    {
    //                        includeWODept = " AND tblMM_PR_Master.WONo='" + wono + "'";
    //                    }

    //                    string sqlPRSPR = "";

    //                    sqlPRSPR = fun.select("tblMM_PR_Master.WONo", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + DS.Tables[0].Rows[u]["PRNo"].ToString() + "' AND tblMM_PR_Details.Id='" + DS.Tables[0].Rows[u]["PRId"].ToString() + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.CompId='" + compid + "'" + includeWODept + "");

                                               
    //                    SqlCommand cmd2 = new SqlCommand(sqlPRSPR, con);
    //                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
    //                    DataSet DS2 = new DataSet();
    //                    DA2.Fill(DS2);
                        
    //                    if (DS2.Tables[0].Rows.Count > 0)
    //                    {
                           
    //                        {
    //                            if (BasicTax == 0)
    //                            {
    //                                Amt += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 1)
    //                            {
    //                                Amt += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 2)
    //                            {
    //                                string sqlPF = fun.select("tblPacking_Master.Value", "tblPacking_Master", "tblPacking_Master.Id='" + DS.Tables[0].Rows[u]["PF"].ToString() + "'");

    //                                SqlCommand cmd3 = new SqlCommand(sqlPF, con);
    //                                SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
    //                                DataSet DS3 = new DataSet();
    //                                DA3.Fill(DS3);

    //                                double PF = Convert.ToDouble(decimal.Parse(DS3.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));

    //                                string sqlExSer = fun.select("tblExciseser_Master.Value", "tblExciseser_Master", "tblExciseser_Master.Id='" + DS.Tables[0].Rows[u]["ExST"].ToString() + "'");

    //                                SqlCommand cmd4 = new SqlCommand(sqlExSer, con);
    //                                SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
    //                                DataSet DS4 = new DataSet();
    //                                DA4.Fill(DS4);

    //                                double ExSer = Convert.ToDouble(decimal.Parse(DS4.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));


    //                                string sqlvat = fun.select("tblVAT_Master.Value", "tblVAT_Master", "tblVAT_Master.Id='" + DS.Tables[0].Rows[u]["VAT"].ToString() + "'");
    //                                SqlCommand cmd5 = new SqlCommand(sqlvat, con);
    //                                SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
    //                                DataSet DS5 = new DataSet();
    //                                DA5.Fill(DS5);

    //                                double Vat = Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));

    //                                Amt += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")), PF, ExSer, Vat);

    //                            }

    //                            if (BasicTax == 3)
    //                            {
    //                                double CalBasicAmt = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                                double CalOnlyTax = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                Amt += CalBasicAmt + CalOnlyTax;
    //                            }

    //                        }
    //                    }
    //                }
    //            }
    //        }



    //        if (prspr == 1)
    //        {
    //            string sqlPO = fun.select("tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Details.BudgetCode='"+accid+"' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "' AND tblMM_PO_Master.Authorize='" + authnon + "'");
    //            SqlCommand cmd = new SqlCommand(sqlPO, con);
    //            SqlDataAdapter DA = new SqlDataAdapter(cmd);
    //            DataSet DS = new DataSet();
    //            DA.Fill(DS);
                
    //            if (DS.Tables[0].Rows.Count > 0)
    //            {
    //                for (int u = 0; u < DS.Tables[0].Rows.Count; u++)
    //                {
    //                    includeWODept = "";
                        
    //                    if (wodept == 1)
    //                    {
    //                        if (dept == 0)
    //                        {
    //                            includeWODept = " AND tblMM_SPR_Details.WONo='" + wono + "'";
    //                        }
    //                        else
    //                        {
    //                            includeWODept = " AND tblMM_SPR_Details.DeptId='" + dept + "'";
    //                        }
    //                    }


    //                    string sqlPRSPR = "";

    //                    sqlPRSPR = fun.select("tblMM_SPR_Details.DeptId,tblMM_SPR_Details.WONo", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + DS.Tables[0].Rows[u]["SPRNo"].ToString() + "' AND tblMM_SPR_Details.Id='" + DS.Tables[0].Rows[u]["SPRId"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='" + compid + "'" + includeWODept + "");

    //                    SqlCommand cmd2 = new SqlCommand(sqlPRSPR, con);
    //                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
    //                    DataSet DS2 = new DataSet();
    //                    DA2.Fill(DS2);
                        
    //                    if (DS2.Tables[0].Rows.Count > 0)
    //                    {
    //                       // if (Convert.ToInt32(DS2.Tables[0].Rows[0]["DeptId"]) == accid)
    //                        {
    //                            if (BasicTax == 0)
    //                            {
    //                                Amt += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                            }

    //                            if (BasicTax == 1)
    //                            {
    //                                Amt += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 2)
    //                            {
    //                                string sqlPF = fun.select("tblPacking_Master.Value", "tblPacking_Master", "tblPacking_Master.Id='" + DS.Tables[0].Rows[u]["PF"].ToString() + "'");

    //                                SqlCommand cmd3 = new SqlCommand(sqlPF, con);
    //                                SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
    //                                DataSet DS3 = new DataSet();
    //                                DA3.Fill(DS3);

    //                                double PF = Convert.ToDouble(decimal.Parse(DS3.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                string sqlExSer = fun.select("tblExciseser_Master.Value", "tblExciseser_Master", "tblExciseser_Master.Id='" + DS.Tables[0].Rows[u]["ExST"].ToString() + "'");

    //                                SqlCommand cmd4 = new SqlCommand(sqlExSer, con);
    //                                SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
    //                                DataSet DS4 = new DataSet();
    //                                DA4.Fill(DS4);

    //                                double ExSer = Convert.ToDouble(decimal.Parse(DS4.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));


    //                                string sqlvat = fun.select("tblVAT_Master.Value", "tblVAT_Master", "tblVAT_Master.Id='" + DS.Tables[0].Rows[u]["VAT"].ToString() + "'");
    //                                SqlCommand cmd5 = new SqlCommand(sqlvat, con);
    //                                SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
    //                                DataSet DS5 = new DataSet();
    //                                DA5.Fill(DS5);

    //                                double Vat = Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                Amt += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")), PF, ExSer, Vat);



    //                            }

    //                            if (BasicTax == 3)
    //                            {
    //                                double CalBasicAmt = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
                                   
    //                                double CalOnlyTax = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                Amt += CalBasicAmt + CalOnlyTax;
    //                            }

    //                        }

    //                    }
    //                }
    //            }
    //        }
    //    }
    //   catch (Exception ex)
    //    {
    //    }

    //    return Math.Round(Amt, 2);
    //    con.Close();
    //} 
    
    //public double getTotal_PO_Budget_Amt(int compid, int accid, int prspr, int wodept, string wono, int dept, int authnon, int BasicTax)
    //{
    //    /* authnon - PO is Auth or Non Auth 
    //       prspr - 0 for PR & 1 for SPR
    //       wodept - 0 do not include any wo or dept, 1 include wo or dept
    //       wono - wo no 
    //       dept - dept id
    //       accid - A/c Id
    //       BasicTax - 0 Basic Amt & 1 Basic Disc Amt & 2 Only Tax Amt & 3 Basic + Disc + Tax Amt
    //       RtnType - 
    //     */

    //    string includeWODept = "";

    //    string connStr = fun.Connection();
    //    SqlConnection con = new SqlConnection(connStr);
    //    con.Open();
    //    double Amt = 0;
    //    try
    //    {
    //        if (prspr == 0)
    //        {
    //            string sqlPO = fun.select("tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "' AND tblMM_PO_Master.Authorize='" + authnon + "'");
    //            SqlCommand cmd = new SqlCommand(sqlPO, con);
    //            SqlDataAdapter DA = new SqlDataAdapter(cmd);
    //            DataSet DS = new DataSet();
    //            DA.Fill(DS);

    //            if (DS.Tables[0].Rows.Count > 0)
    //            {
    //                for (int u = 0; u < DS.Tables[0].Rows.Count; u++)
    //                {
    //                    includeWODept = "";
    //                    if (wodept == 1)
    //                    {
    //                        includeWODept = " AND tblMM_PR_Details.WONo='" + wono + "'";
    //                    }

    //                    string sqlPRSPR = "";

    //                    sqlPRSPR = fun.select("tblMM_PR_Details.AHId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + DS.Tables[0].Rows[u]["PRNo"].ToString() + "' AND tblMM_PR_Details.Id='" + DS.Tables[0].Rows[u]["PRId"].ToString() + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.CompId='" + compid + "'" + includeWODept + "");
    //                    SqlCommand cmd2 = new SqlCommand(sqlPRSPR, con);
    //                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
    //                    DataSet DS2 = new DataSet();
    //                    DA2.Fill(DS2);

    //                    if (DS2.Tables[0].Rows.Count > 0)
    //                    {
    //                        if (Convert.ToInt32(DS2.Tables[0].Rows[0]["AHId"]) == accid)
    //                        {
    //                            if (BasicTax == 0)
    //                            {
    //                                Amt += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 1)
    //                            {
    //                                Amt += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 2)
    //                            {
    //                                string sqlPF = fun.select("tblPacking_Master.Value", "tblPacking_Master", "tblPacking_Master.Id='" + DS.Tables[0].Rows[u]["PF"].ToString() + "'");

    //                                SqlCommand cmd3 = new SqlCommand(sqlPF, con);
    //                                SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
    //                                DataSet DS3 = new DataSet();
    //                                DA3.Fill(DS3);

    //                                double PF = Convert.ToDouble(decimal.Parse(DS3.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));

    //                                string sqlExSer = fun.select("tblExciseser_Master.Value", "tblExciseser_Master", "tblExciseser_Master.Id='" + DS.Tables[0].Rows[u]["ExST"].ToString() + "'");

    //                                SqlCommand cmd4 = new SqlCommand(sqlExSer, con);
    //                                SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
    //                                DataSet DS4 = new DataSet();
    //                                DA4.Fill(DS4);

    //                                double ExSer = Convert.ToDouble(decimal.Parse(DS4.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));


    //                                string sqlvat = fun.select("tblVAT_Master.Value", "tblVAT_Master", "tblVAT_Master.Id='" + DS.Tables[0].Rows[u]["VAT"].ToString() + "'");
    //                                SqlCommand cmd5 = new SqlCommand(sqlvat, con);
    //                                SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
    //                                DataSet DS5 = new DataSet();
    //                                DA5.Fill(DS5);

    //                                double Vat = Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[0]["Value"].ToString()).ToString("N3"));

    //                                Amt += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")), PF, ExSer, Vat);

    //                            }

    //                            if (BasicTax == 3)
    //                            {
    //                                double CalBasicAmt = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                                double CalOnlyTax = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                Amt += CalBasicAmt + CalOnlyTax;
    //                            }

    //                        }
    //                    }
    //                }
    //            }
    //        }



    //        if (prspr == 1)
    //        {
    //            string sqlPO = fun.select("tblMM_PO_Details.BudgetCode,tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + compid + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.PRSPRFlag='" + prspr + "' AND tblMM_PO_Master.Authorize='" + authnon + "'");
    //            SqlCommand cmd = new SqlCommand(sqlPO, con);
    //            SqlDataAdapter DA = new SqlDataAdapter(cmd);
    //            DataSet DS = new DataSet();
    //            DA.Fill(DS);
    //           // Response.Write(sqlPO);
    //            if (DS.Tables[0].Rows.Count > 0)
    //            {
    //                for (int u = 0; u < DS.Tables[0].Rows.Count; u++)
    //                {
    //                    includeWODept = "";
    //                    if (wodept == 1)
    //                    {
    //                        if (dept == 0)
    //                        {
    //                            includeWODept = " AND tblMM_SPR_Details.WONo='" + wono + "'";
    //                        }
    //                        else
    //                        {
    //                            includeWODept = " AND tblMM_SPR_Details.DeptId='" + dept + "'";
    //                        }
    //                    }



    //                    string sqlPRSPR = "";

    //                    sqlPRSPR = fun.select("tblMM_SPR_Details.DeptId,tblMM_SPR_Details.WONo", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + DS.Tables[0].Rows[u]["SPRNo"].ToString() + "' AND tblMM_SPR_Details.Id='" + DS.Tables[0].Rows[u]["SPRId"].ToString() + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.CompId='" + compid + "'" + includeWODept + "");

    //                    SqlCommand cmd2 = new SqlCommand(sqlPRSPR, con);
    //                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
    //                    DataSet DS2 = new DataSet();
    //                    DA2.Fill(DS2);
    //                    Response.Write(sqlPRSPR);
    //                    if (DS2.Tables[0].Rows.Count > 0)
    //                    {
    //                        if (Convert.ToInt32(DS2.Tables[0].Rows[0]["DeptId"]) == accid)
    //                        {
    //                            if (BasicTax == 0)
    //                            {
    //                                Amt += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                            }

    //                            if (BasicTax == 1)
    //                            {
    //                                Amt += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                            }

    //                            if (BasicTax == 2)
    //                            {
    //                                string sqlPF = fun.select("tblPacking_Master.Value", "tblPacking_Master", "tblPacking_Master.Id='" + DS.Tables[0].Rows[u]["PF"].ToString() + "'");

    //                                SqlCommand cmd3 = new SqlCommand(sqlPF, con);
    //                                SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
    //                                DataSet DS3 = new DataSet();
    //                                DA3.Fill(DS3);

    //                                double PF = Convert.ToDouble(decimal.Parse(DS3.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                string sqlExSer = fun.select("tblExciseser_Master.Value", "tblExciseser_Master", "tblExciseser_Master.Id='" + DS.Tables[0].Rows[u]["ExST"].ToString() + "'");

    //                                SqlCommand cmd4 = new SqlCommand(sqlExSer, con);
    //                                SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
    //                                DataSet DS4 = new DataSet();
    //                                DA4.Fill(DS4);

    //                                double ExSer = Convert.ToDouble(decimal.Parse(DS4.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));


    //                                string sqlvat = fun.select("tblVAT_Master.Value", "tblVAT_Master", "tblVAT_Master.Id='" + DS.Tables[0].Rows[u]["VAT"].ToString() + "'");
    //                                SqlCommand cmd5 = new SqlCommand(sqlvat, con);
    //                                SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
    //                                DataSet DS5 = new DataSet();
    //                                DA5.Fill(DS5);

    //                                double Vat = Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                Amt += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")), PF, ExSer, Vat);



    //                            }

    //                            if (BasicTax == 3)
    //                            {
    //                                double CalBasicAmt = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                                double CalOnlyTax = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                Amt += CalBasicAmt + CalOnlyTax;
    //                            }

    //                        }
                           


    //                           else if ((DS2.Tables[0].Rows[0]["WONo"].ToString()) == wono)
    //                            {
    //                                if (BasicTax == 0)
    //                                {
    //                                    Amt += fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                                }

    //                                if (BasicTax == 1)
    //                                {
    //                                    Amt += fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                }

    //                                if (BasicTax == 2)
    //                                {
    //                                    string sqlPF = fun.select("tblPacking_Master.Value", "tblPacking_Master", "tblPacking_Master.Id='" + DS.Tables[0].Rows[u]["PF"].ToString() + "'");

    //                                    SqlCommand cmd3 = new SqlCommand(sqlPF, con);
    //                                    SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
    //                                    DataSet DS3 = new DataSet();
    //                                    DA3.Fill(DS3);

    //                                    double PF = Convert.ToDouble(decimal.Parse(DS3.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                    string sqlExSer = fun.select("tblExciseser_Master.Value", "tblExciseser_Master", "tblExciseser_Master.Id='" + DS.Tables[0].Rows[u]["ExST"].ToString() + "'");

    //                                    SqlCommand cmd4 = new SqlCommand(sqlExSer, con);
    //                                    SqlDataAdapter DA4 = new SqlDataAdapter(cmd4);
    //                                    DataSet DS4 = new DataSet();
    //                                    DA4.Fill(DS4);

    //                                    double ExSer = Convert.ToDouble(decimal.Parse(DS4.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));


    //                                    string sqlvat = fun.select("tblVAT_Master.Value", "tblVAT_Master", "tblVAT_Master.Id='" + DS.Tables[0].Rows[u]["VAT"].ToString() + "'");
    //                                    SqlCommand cmd5 = new SqlCommand(sqlvat, con);
    //                                    SqlDataAdapter DA5 = new SqlDataAdapter(cmd5);
    //                                    DataSet DS5 = new DataSet();
    //                                    DA5.Fill(DS5);

    //                                    double Vat = Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[0]["Value"].ToString()).ToString("N2"));

    //                                    Amt += fun.CalTaxAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")), PF, ExSer, Vat);



    //                                }

    //                                if (BasicTax == 3)
    //                                {
    //                                    double CalBasicAmt = fun.CalBasicAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")));
    //                                    double CalOnlyTax = fun.CalDiscAmt(Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Qty"].ToString()).ToString("N3")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Rate"].ToString()).ToString("N2")), Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[u]["Discount"].ToString()).ToString("N2")));

    //                                    Amt += CalBasicAmt + CalOnlyTax;
    //                                }

    //                            }








    //                        }





                        
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //    return Math.Round(Amt, 2);
    //    con.Close();
    //} 



}

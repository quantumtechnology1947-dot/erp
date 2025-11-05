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

                    string selectBudget = "select Sum(BudgetAmtHrs) As Budget from tblACC_Budget_WO_Time where BudgetCodeId='" + accid + "'   and  WONo='" + wono + "' And FinYearId=" + FinYearId + " group by  BudgetCodeId ";
                    SqlCommand cmdBD = new SqlCommand(selectBudget, con);
                    SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
                    DataSet dsBD = new DataSet();
                    daBD.Fill(dsBD, "tblACC_Budget_WO_Time");

                    ((HyperLink)grv.FindControl("Link1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_WONo_Details_TimeCopy.aspx?WONo=" + wono + "&Id=" + accid + "&ModId=14";

                    if (dsBD.Tables[0].Rows.Count > 0)
                    {
                        budget = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["Budget"]) + openingBalOfPrevYear), 2);                       
                        
                        ((HyperLink)grv.FindControl("Link1")).Visible = true;
                    }
                    else
                    {
                        budget = openingBalOfPrevYear;  
                        ((HyperLink)grv.FindControl("Link1")).Visible = false;
                    }
                    ((Label)grv.FindControl("lblAmount")).Text = budget.ToString();
                   
                    double POPRBasicDiscAmt = 0; 
                    double POSPRBasicDiscAmt = 0;
                    POPRBasicDiscAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 0, 1, wono, 0,  1,FinYearId);
                    POSPRBasicDiscAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, wono, 0,  1,FinYearId);
                    ((Label)grv.FindControl("lblPO")).Text = Convert.ToString(Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2));

                    PoAmt += Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2);
                    double POPRTaxAmt = 0; double POSPRTaxAmt = 0;

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
                   // TotBalBudget = Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text) - (Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2) + Math.Round(totalCash, 2)), 2) + Math.Round(totalCashRec, 2);

                    TotBalBudget = Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text)); 



                    ((Label)grv.FindControl("lblBudget")).Text = TotBalBudget.ToString();
                    dr[9] = Math.Round(TotBalBudget, 2);
                    DT.Rows.Add(dr);
                    DT.AcceptChanges();
                   // BalBudget += Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text) - (Math.Round(POPRBasicDiscAmt + POSPRBasicDiscAmt, 2) + Math.Round(POPRTaxAmt + POSPRTaxAmt, 2) + Math.Round(totalCash, 2)), 2) + Math.Round(totalCashRec, 2);

                    BalBudget += Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text)) ;


                }

                ViewState["dtList"] = DT;

               ((Label)GridView1.FooterRow.FindControl("lblTotalBudAmt")).Text = TotBudget.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblPO1")).Text = PoAmt.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblTax1")).Text = TaxAmt.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblBudget1")).Text = BalBudget.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblCashPay1")).Text = cashpay.ToString();
               ((Label)GridView1.FooterRow.FindControl("lblCashRec1")).Text = cashrec.ToString();
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
            string Bcode = fun.select("Symbol", "tblMIS_BudgetCode_Time", "Id='" + accid + "'");
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
        Response.Redirect("Budget_Dist_WONo_Time.aspx?ModId=14");
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
                        string insert = ("Insert into  tblACC_Budget_WO_Time (SysDate,SysTime,CompId,FinYearId,SessionId,WONo,BudgetCodeId,BudgetAmtHrs) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + id + "','" + Amt + "')");
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



}

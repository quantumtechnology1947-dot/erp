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

public partial class Module_Accounts_Transactions_Budget_Dist : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    int CompId = 0;
    string SId = "";
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        SId = Session["username"].ToString();
        FinYearId = Convert.ToInt32(Session["finyear"]);
        if (!IsPostBack)
        {
            this.CalculateBalAmt();
           
        }
        TabContainer1.OnClientActiveTabChanged = "OnChanged";
        TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");

    }
    public void CalculateBalAmt()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        
        try
        {
            con.Open();
            int prevYear = 0;
            prevYear = (FinYearId - 1);
            
            double TotBudgetAmt =0;
            double TotPOAmt =0;
            double TotCashPay =0;
            double TotCashRec =0;
            double TotTaxAmt =0;
            double TotBalBudgetAmt = 0;

            DataTable DT = new DataTable();
            DT.Columns.Add(new System.Data.DataColumn("Sr No", typeof(int)));
            DT.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            DT.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
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
                int BGId = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                ((HyperLink)grv.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details.aspx?BGId=" + BGId + "&ModId=14";

                double budget = 0;
                double openingBalOfPrevYear = 0;
                openingBalOfPrevYear = calbalbud.TotBalBudget_BG(BGId, CompId, prevYear, 0);

                string selectBudget = "select Sum(Amount) As Budget from tblACC_Budget_Dept where BGId='" + BGId + "' And FinYearId=" + FinYearId + "  group by  BGId ";
                SqlCommand cmdBD = new SqlCommand(selectBudget, con);
                SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
                DataSet dsBD = new DataSet();
                daBD.Fill(dsBD, "tblACC_Budget_Dept");
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
                dr[3] = Math.Round(budget, 2);
                
                TotBudgetAmt+=Math.Round(budget, 2);

                double POSPRBasicDiscAmt = 0;
                double totalCash = 0;
                double totalCashRec = 0;
                POSPRBasicDiscAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, "0", BGId, 1, FinYearId);

                ((Label)grv.FindControl("lblPO")).Text = Convert.ToString(Math.Round(POSPRBasicDiscAmt, 2));
                dr[4] = Math.Round(POSPRBasicDiscAmt, 2);
                TotPOAmt+=Math.Round(POSPRBasicDiscAmt, 2);
                double POSPRTaxAmt = 0;
                POSPRTaxAmt = PBM.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, "0", BGId, 2, FinYearId);

                ((Label)grv.FindControl("lblTax")).Text = Convert.ToString(Math.Round(POSPRTaxAmt, 2));

                string CashAmt = "SELECT  SUM(tblACC_CashVoucher_Payment_Details.Amount) AS CashAmt, tblACC_CashVoucher_Payment_Details.BGGroup FROM tblACC_CashVoucher_Payment_Details INNER JOIN     tblACC_CashVoucher_Payment_Master ON tblACC_CashVoucher_Payment_Details.MId = tblACC_CashVoucher_Payment_Master.Id   And tblACC_CashVoucher_Payment_Details.BGGroup='" + BGId + "' And tblACC_CashVoucher_Payment_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Payment_Details.BGGroup";
                SqlCommand cmdCash = new SqlCommand(CashAmt, con);
                SqlDataAdapter daCash = new SqlDataAdapter(cmdCash);
                DataSet dsCash = new DataSet();
                daCash.Fill(dsCash);
                if (dsCash.Tables[0].Rows.Count > 0)
                {
                    totalCash = Convert.ToDouble(dsCash.Tables[0].Rows[0][0]);
                }

                ((Label)grv.FindControl("lblCashPay")).Text = Convert.ToString(Math.Round(totalCash, 2));
              
                TotCashPay+=Math.Round(totalCash, 2);

                string CashAmt1 = "SELECT  SUM(tblACC_CashVoucher_Receipt_Master.Amount) AS CashAmt, tblACC_CashVoucher_Receipt_Master.BGGroup,  tblACC_CashVoucher_Receipt_Master.WONo FROM tblACC_CashVoucher_Receipt_Master   where  tblACC_CashVoucher_Receipt_Master.BGGroup='" + BGId + "'And tblACC_CashVoucher_Receipt_Master.FinYearId=" + FinYearId + " GROUP BY tblACC_CashVoucher_Receipt_Master.BGGroup, tblACC_CashVoucher_Receipt_Master.WONo";

                SqlCommand cmdCash1 = new SqlCommand(CashAmt1, con);
                SqlDataAdapter daCash1 = new SqlDataAdapter(cmdCash1);
                DataSet dsCash1 = new DataSet();
                daCash1.Fill(dsCash1);
                if (dsCash1.Tables[0].Rows.Count > 0)
                {
                    totalCashRec = Convert.ToDouble(dsCash1.Tables[0].Rows[0][0]);
                }

                ((Label)grv.FindControl("lblCashRec")).Text = Convert.ToString(Math.Round(totalCashRec, 2));

                TotCashRec += Math.Round(totalCashRec, 2);
                
                dr[7] = Math.Round(POSPRTaxAmt, 2);

                TotTaxAmt+=Math.Round(POSPRTaxAmt, 2);

                dr[5] = Math.Round(totalCash, 2);
                dr[6] = Math.Round(totalCashRec, 2);
                double TotBalBudget = 0;
                TotBalBudget = Math.Round(budget - (POSPRBasicDiscAmt + POSPRTaxAmt + totalCash), 2) + totalCashRec;
                dr[8] = Math.Round(TotBalBudget, 2);
               
                TotBalBudgetAmt+=Math.Round(TotBalBudget, 2);

                ((Label)grv.FindControl("lblBudget")).Text = TotBalBudget.ToString();
                DT.Rows.Add(dr);
                DT.AcceptChanges();

            }
            ViewState["dtList"] = DT;

            ((Label)GridView1.FooterRow.FindControl("TotBudgetAmt")).Text = TotBudgetAmt.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotPOAmt")).Text = TotPOAmt.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotCashPay")).Text = TotCashPay.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotCashRec")).Text = TotCashRec.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotTaxAmt")).Text = TotTaxAmt.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotBalBudgetAmt")).Text = TotBalBudgetAmt.ToString();

        }
       catch (Exception ex)
        {

        }
       finally
        {
            con.Close();
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
                    GridView1.Visible = true;
                   
                }
                else
                {
                    ((Label)grv.FindControl("lblAmount")).Visible = true;
                    ((TextBox)grv.FindControl("TxtAmount")).Visible = false;
                    GridView1.Visible = true;
                   
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?ModId=14&SubModId=");
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }
    protected void BtnInsert_Click(object sender, EventArgs e)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
       try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            int id = 0;
         
                con.Open();

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                    {
                        id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                        double Amt = Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text);


                        if (Amt > 0)
                        {
                            string insert = ("Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,BGId,Amount  ) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + id + "','" + Amt + "')");
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
            ex.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_BG");
        }
        catch (Exception ex1)
        {
            string mystring = string.Empty;
            mystring = "No Records to Export.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
        } 

    }

}

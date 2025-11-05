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

public partial class Module_Accounts_Transactions_Acc_Bal_CurrAssets : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    string SId = "";
    int FinYearId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ACC_CurrentAssets ACA = new ACC_CurrentAssets();
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            con.Open();

            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblClStock.Text = fun.ClStk().ToString();
            
            double TotOp = 0;
            TotOp = fun.DebitorsOpeningBal(CompId, "");

            double TotDr = 0;
            TotDr = Convert.ToDouble(ACA.TotInvQty2(CompId,FinYearId,"").Compute("Sum(TotAmt)", ""));

            lblSD_dr.Text = (TotDr + TotOp).ToString();
            lblSD_cr.Text = fun.getDebitorCredit(CompId, FinYearId, "").ToString();
        }
        catch (Exception st)
        {

        }
        finally 
        {
            con.Close();
        }
    }

   
}

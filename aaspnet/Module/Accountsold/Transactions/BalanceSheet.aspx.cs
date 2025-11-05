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

public partial class Module_Accounts_Transactions_BalanceSheet : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string SId = "";
    ACC_CurrentAssets acc = new ACC_CurrentAssets();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();

            double x = 0;
            
            if (!Page.IsPostBack)
            {
                x = fun.FillGrid_Creditors(CompId, FinYearId, 4, "");
                Amt_CurrentLiab.Text = x.ToString();
                Amt_CurrentLiab0.Text = x.ToString();
                Amt_LoanLiability.Text = acc.TotLoanLiability(CompId, FinYearId).ToString();
                Amt_CapitalGood.Text = acc.TotCapitalGoods(CompId, FinYearId).ToString();
            }
        }
         catch(Exception et)
        {

        }
    }

   

}

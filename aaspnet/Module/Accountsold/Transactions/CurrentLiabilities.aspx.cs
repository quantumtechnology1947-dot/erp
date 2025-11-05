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

public partial class Module_Accounts_Transactions_CurrentLiabilities : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string SId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();

            if (!Page.IsPostBack)
            {
                lblDeb_SuCr.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "")).ToString();
                lblDeb_SuCr0.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "")).ToString();

                lblCrd_SuCr.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 1, "") + fun.FillGrid_Creditors(CompId, FinYearId, 2, "")).ToString();
                lblCrd_SuCr0.Text = (fun.FillGrid_Creditors(CompId, FinYearId, 1, "") + fun.FillGrid_Creditors(CompId, FinYearId, 2, "")).ToString();
            }
        }
        catch (Exception et)
        {

        }       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/BalanceSheet.aspx?ModId=&SubModId=");
    }
}
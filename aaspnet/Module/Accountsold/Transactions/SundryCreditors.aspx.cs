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

public partial class Module_Accounts_Transactions_SundryCreditors : System.Web.UI.Page
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

            double OpTotal = 0;
            double AHCrGrandTotal = 0;
            double AHDrGrandTotal = 0;
            double CrTotal = 0;
            double DrTotal = 0;

            if (!Page.IsPostBack)
            {
                foreach (GridViewRow grv in GridView1.Rows)
                {
                    string SubmoddId = string.Empty;
                    double AHCrTotal = 0;

                    AHCrTotal = fun.FillGrid_Creditors(CompId, FinYearId, 2, ((LinkButton)grv.FindControl("lblCategory")).Text);
                    ((Label)grv.FindControl("lblCredit")).Text = AHCrTotal.ToString();
                    AHCrGrandTotal += AHCrTotal;

                    double AHDrTotal = 0;
                    AHDrTotal = fun.FillGrid_Creditors(CompId, FinYearId, 3, ((LinkButton)grv.FindControl("lblCategory")).Text) + fun.FillGrid_Creditors(CompId, FinYearId, 5, ((LinkButton)grv.FindControl("lblCategory")).Text);
                    ((Label)grv.FindControl("lblDebit")).Text = AHDrTotal.ToString();
                    AHDrGrandTotal += AHDrTotal;                    
                }

                OpTotal = fun.FillGrid_Creditors(CompId, FinYearId, 1, "");
                ((Label)GridView1.FooterRow.FindControl("OpTotal")).Text = OpTotal.ToString();
                ((Label)GridView1.FooterRow.FindControl("CrTotal")).Text = AHCrGrandTotal.ToString();

                DrTotal = fun.FillGrid_Creditors(CompId, FinYearId, 3, "") + fun.FillGrid_Creditors(CompId, FinYearId, 5, "");
                ((Label)GridView1.FooterRow.FindControl("DrTotal")).Text = DrTotal.ToString();
                ((Label)GridView1.FooterRow.FindControl("Clbal")).Text = ((OpTotal + AHCrGrandTotal) - DrTotal).ToString();
            }
        }
        catch (Exception stt)
        {

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/CurrentLiabilities.aspx?ModId=&SubModId=");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="gotoPage")
        {
            GridViewRow grv=(GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Response.Redirect("SundryCreditors_Details.aspx?ModId=&SubModId=&lnkFor=" + ((LinkButton)grv.FindControl("lblCategory")).Text + "");
        }
    }

    


}
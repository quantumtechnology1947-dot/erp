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

public partial class Module_Accounts_Transactions_Acc_Sundry_CustList : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    ACC_CurrentAssets ACA = new ACC_CurrentAssets();
    string sId = "";

    int CompId = 0;
    int FinYearId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();

            DataTable dt = ACA.TotInvQty2(CompId, FinYearId, "");
            
            GridView1.DataSource = dt;
            GridView1.DataBind();

            double Totop = 0;
            double Totdr = 0;
            double Totcr = 0;

            foreach (GridViewRow grv in GridView1.Rows)
            {
                Totdr += Convert.ToDouble(((Label)grv.FindControl("lblDrAmt")).Text);

                double x = 0;
                x = Math.Round(fun.getDebitorCredit(CompId, FinYearId, ((Label)grv.FindControl("lblCustCode")).Text), 2);
                ((Label)grv.FindControl("lblCrAmt")).Text = x.ToString();
                Totcr += x;

                double y = 0;
                y = fun.DebitorsOpeningBal(CompId, ((Label)grv.FindControl("lblCustCode")).Text);
                ((Label)grv.FindControl("lblOpAmt")).Text = y.ToString();
                Totop += y;
            }

            ((Label)GridView1.FooterRow.FindControl("TotOP")).Text = Totop.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotDebit")).Text = Totdr.ToString();
            ((Label)GridView1.FooterRow.FindControl("TotCredit")).Text = Totcr.ToString();
            
        }
        catch
        {

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            string getRandomKey = fun.GetRandomAlphaNumeric();

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string Custid = ((Label)row.FindControl("lblCustCode")).Text;
            Response.Redirect("Acc_Sundry_Details.aspx?CustId=" + Custid + "&ModId=11&SubModId=&Key=" + getRandomKey + "");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Acc_Bal_CurrAssets.aspx??ModId=11&SubModId=");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }


}

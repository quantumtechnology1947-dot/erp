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

public partial class Module_Accounts_Transactions_Acc_Loan_Particulars : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    ACC_Loan_Liab ACA = new ACC_Loan_Liab();
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

            if (!IsPostBack)
            {
                string StrSql = "select Sum(CreditAmt) As loan,tblAcc_LoanMaster.Particulars,tblAcc_LoanMaster.Id from tblAcc_LoanDetails inner join tblAcc_LoanMaster on tblAcc_LoanMaster.Id=tblAcc_LoanDetails.MId And CompId=" + CompId + " AND FinYearId<=" + FinYearId + " group by tblAcc_LoanMaster.Particulars,tblAcc_LoanMaster.Id";
                DataTable dt = ACA.TotFillPart(StrSql);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                double Totdr = 0;
                double Totcr = 0;
                if (dt.Rows.Count > 0)
                {
                    Totcr = Convert.ToDouble(dt.Compute("Sum(TotCrAmt)", ""));
                    Totdr = Convert.ToDouble(dt.Compute("Sum(TotDrAmt)", ""));
                    ((Label)GridView1.FooterRow.FindControl("TotDebit")).Text = Totdr.ToString();
                    ((Label)GridView1.FooterRow.FindControl("TotCredit")).Text = Totcr.ToString();
                }
            }
            
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
            string id = ((Label)row.FindControl("lblId")).Text;
            Response.Redirect("Acc_Loan_Part_Details.aspx?MId=" + id + "&ModId=11&SubModId=");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/BalanceSheet.aspx??ModId=11&SubModId=");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }


}

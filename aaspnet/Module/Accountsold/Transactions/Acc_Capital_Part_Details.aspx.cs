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

public partial class Module_Accounts_Transactions_Acc_Capital_Part_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    ACC_Loan_Liab ACA = new ACC_Loan_Liab();
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    int MId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["MId"]))
            {
                MId = Convert.ToInt32(Request.QueryString["MId"]);
            }
            if (!IsPostBack)
            {
                string StrSql = "select CreditAmt As loan,tblACC_Capital_Details.Particulars,tblACC_Capital_Details.Id from tblACC_Capital_Details inner join tblACC_Capital_Master on tblACC_Capital_Master.Id=tblACC_Capital_Details.MId And CompId=" + CompId + " AND FinYearId<=" + FinYearId + " And MId=" + MId + "";
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
        
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Acc_Capital_Particulars.aspx??ModId=11&SubModId=");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
   

}

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
using CrystalDecisions.CrystalReports.Engine;

public partial class Module_Accounts_Transactions_CreditorsDebitors_InDetailList : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();    
    SqlConnection con;
    ReportDocument cryRpt = new ReportDocument();

    int CompId = 0;
    int FinYearId = 0;
    string SId = string.Empty;
    string connStr = string.Empty;
    string SupId = string.Empty;
    string Key = string.Empty;
    string DTFrm = string.Empty;
    string DTTo = string.Empty;
    string DtFrm = string.Empty;
    string DtTo = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            con.Open();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            SupId = Request.QueryString["SupId"].ToString();            
            Key = Request.QueryString["Key"].ToString();

            Session["SupId"] = SupId;
            Session["Key"] = Key;
            Session["DtFrm"] = DtFrm;
            Session["DtTo"] = DtTo;

            ifrm.Attributes.Add("src", "CreditorsDebitors_InDetailView.aspx");

            con.Close();
        }
        catch(Exception ex)
        {
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtFrmDt.Text != "" && txtToDt.Text != "" && fun.DateValidation(txtFrmDt.Text) == true && fun.DateValidation(txtToDt.Text) == true)
            {
                if (Convert.ToDateTime(fun.FromDate(txtFrmDt.Text)) <= Convert.ToDateTime(fun.FromDate(txtToDt.Text)))
                {
                    DtFrm = fun.FromDate(txtFrmDt.Text);
                    DtTo = fun.FromDate(txtToDt.Text);

                    Session["SupId"] = SupId;
                    Session["Key"] = Key;
                    Session["DtFrm"] = DtFrm;
                    Session["DtTo"] = DtTo;

                    ifrm.Attributes.Add("src", "CreditorsDebitors_InDetailView.aspx");
                }
            }
        }
        catch (Exception et)
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/CreditorsDebitors.aspx?ModId=11&SubModId=135");
    }

}

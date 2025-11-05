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

public partial class Module_Accounts_Transactions_TourVoucher_Print_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";
    string CDate = "";
    string CTime = "";
    int id = 0;
    int TIMid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {

            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            id = Convert.ToInt32(Request.QueryString["Id"]);
            TIMid = Convert.ToInt32(Request.QueryString["TIMId"]);
        }
         catch (Exception ex){}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourVoucher_Print.aspx?ModId=11&SubModId=126");
    }
}

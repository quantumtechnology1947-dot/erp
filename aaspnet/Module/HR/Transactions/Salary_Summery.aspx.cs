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

public partial class Module_HR_Transactions_Salary_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    int MonthId = 4;
    string connStr = string.Empty;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
           
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            if (!String.IsNullOrEmpty(Request.QueryString["MonthId"]))
            {
                MonthId = Convert.ToInt32(Request.QueryString["MonthId"]);
            }
            if (!IsPostBack)
            {
                ddlMonth.Items.Clear();
                fun.GetMonth(ddlMonth, CompId, FinYearId);
                ddlMonth.SelectedValue = MonthId.ToString();
            }
          
        }
        catch (Exception ex) { }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            string EmpId = string.Empty;
          
            string MonthId = string.Empty;
            MonthId = ddlMonth.SelectedValue;
            string EType = string.Empty;
            
            string BGGroupId = string.Empty;
            BGGroupId = ddlBGGroup.SelectedValue;

            string getRandomKey = fun.GetRandomAlphaNumeric(); 
            EType = "3";
            Response.Redirect("Salary_SAPL_Summary.aspx?EType=" + EType + "&MonthId=" + MonthId + "&BGGroupId=" + BGGroupId + "&Key=" + getRandomKey + "");
                 
        }
        catch (Exception ex)
        { 
            
        }

        finally
        {
            con.Close(); 
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
   
}

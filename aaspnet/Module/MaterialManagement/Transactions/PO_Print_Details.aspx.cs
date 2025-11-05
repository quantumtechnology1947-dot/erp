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

public partial class Module_MaterialManagement_Transactions_PO_Print_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SupCode = "";
    string PoNo = "";
    string MId = "";
    string AmdNo = "";
    string Key = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            PoNo = Request.QueryString["pono"].ToString();
            SupCode = Request.QueryString["Code"].ToString();
            MId = Request.QueryString["mid"].ToString();
            AmdNo = Request.QueryString["AmdNo"].ToString();
             Key = Request.QueryString["Key"].ToString();
              myiframe.Attributes.Add("src", "PO_PR_Print_Page.aspx?ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&mid=" + MId + "&AmdNo=" + AmdNo + "&Key=" + Key + "");
        }
        catch (Exception ett)
        {

        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PO_Print.aspx?mid=" + MId + "&Code=" + SupCode + "&ModId=6&SubModId=35");
    }


}

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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class Module_MaterialManagement_Transactions_APO_SPR_View_Print_Details : System.Web.UI.Page
{
    string SupCode = "";
    string PoNo = "";
    string parentPage = "";
    string MId = "";
    string AmdNo = "";
    string Key = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            PoNo = Request.QueryString["pono"].ToString();
            SupCode = Request.QueryString["Code"].ToString();
            parentPage = Request.QueryString["parentPage"].ToString();
            MId = Request.QueryString["mid"].ToString();
            AmdNo = Request.QueryString["AmdNo"].ToString();
            Key = Request.QueryString["Key"].ToString();
            myifram.Attributes.Add("src", "APO_SPR_Print_Page.aspx?mid=" + MId + "&ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + Key + "");

        }
        catch (Exception ett)
        {
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(parentPage + "?Code=" + SupCode + "");
    }
}

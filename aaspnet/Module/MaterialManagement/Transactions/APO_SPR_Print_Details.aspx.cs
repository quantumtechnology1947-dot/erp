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

public partial class Module_MaterialManagement_Transactions_APO_SPR_Print_Details : System.Web.UI.Page
{
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
            myifram.Attributes.Add("src", "APO_SPR_Print_Page.aspx?ModId=20&SubModId=164&pono=" + PoNo + "&Code=" + SupCode + "&mid=" + MId + "&AmdNo=" + AmdNo + "&Key=" + Key + "");


        }
        catch (Exception ett)
        {

        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("APO_Print.aspx?mid=" + MId + "&Code=" + SupCode + "&");
    }
}

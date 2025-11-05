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

public partial class Module_MaterialManagement_Transactions_PO_PR_View_Print_Details : System.Web.UI.Page
{
    string SupCode = "";
    string PoNo = "";
    string parentPage = "";
    string MId = "";
    string AmdNo = string.Empty;
    string SwithctTo = "";
    string Key = string.Empty;
    string Trans = string.Empty;
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
            Trans = Request.QueryString["Trans"].ToString();
            
            if (!String.IsNullOrEmpty(Request.QueryString["Swto"]))
            {
                SwithctTo = Request.QueryString["Swto"].ToString();
            }

          myiframe.Attributes.Add("src", "PO_PR_Print_Page.aspx?mid=" + MId + "&ModId=6&SubModId=35&pono=" + PoNo + "&Code=" + SupCode + "&AmdNo="+AmdNo+"&Key="+Key+"");           
        }
       catch (Exception ett)
        {
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
     Response.Redirect(parentPage + "?Code=" + SupCode + "&SwitchTo=" + SwithctTo + "&Trans=" + Trans + "&ModId=6&SubModId=35");
    }


}

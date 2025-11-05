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
using System;
using System.Collections.Generic;


public partial class ChallanInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void TreasureAmountold_CrystalReport_click(object sender, EventArgs ex)
    //{
    //    Response.Redirect("ChallanPrint.aspx");
    //}

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("Vehical_Info_Print_Details.aspx?VehNo=" + e.CommandArgument);
    }




}
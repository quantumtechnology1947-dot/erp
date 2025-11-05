using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class GatePass_CrystalReport : System.Web.UI.Page

{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
   
    {

    }


    protected void Image1(object sender, EventArgs ex)
    {
        //Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Insert.aspx");

    }


    protected void Image2(object sender, EventArgs ex)
    {
        //Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass.aspx");

    }

    protected void Image3(object sender, EventArgs ex)
    {
       // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Edit.aspx");
    }

    protected void Image4(object sender, EventArgs ex)
    {
       // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Delete.aspx");

    }

     protected void Image5(object sender, EventArgs ex)
    {
       // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_CrystalReport.aspx");

    }

     protected void GatepassReport_click(object sender, EventArgs ex)
     {
         Response.Redirect("~/Module/Inventory/Transactions/GatePass_Report.aspx");
     }

}

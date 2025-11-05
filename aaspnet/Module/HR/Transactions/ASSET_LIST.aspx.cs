using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class Module_HR_Transactions_ASSET_LIST : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }


    protected void DRP_SELECTED(object sender, EventArgs e)
    {
        if (drp1.SelectedItem.Text == "DESKTOP")
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;

        }

        else if (drp1.SelectedItem.Text == "LAPTOP")
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;
        }
        else if (drp1.SelectedItem.Text == "PRINTER")
        {
            GridView3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;
        }
        else if (drp1.SelectedItem.Text=="ROUTER")
        {
            GridView4.Visible = true;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;
        }

        else if (drp1.SelectedItem.Text == "PROJECTOR")
        {
            GridView5.Visible = true;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;
        }
        else if (drp1.SelectedItem.Text == "SWITCHES")
        {
            GridView6.Visible = true;
            GridView5.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;

            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = false;
        }
        else if (drp1.SelectedItem.Text == "PUNCHING MACHINE")
        {
            GridView7.Visible = true;
            GridView8.Visible = false;
            GridView9.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
        }

        else if (drp1.SelectedItem.Text == "CAMERA")
        {
            GridView5.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView6.Visible = false;

            GridView7.Visible = false;
            GridView8.Visible = true;
            GridView9.Visible = false;
        }
        else if (drp1.SelectedItem.Text == "SAPLNAS")
        {
            GridView6.Visible = false;
            GridView5.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;

            GridView7.Visible = false;
            GridView8.Visible = false;
            GridView9.Visible = true;
        }


    }
}
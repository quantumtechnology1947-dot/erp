using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Module_DailyReportingSystem_Reports_test : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        TextBox1.Text = "ht";
        try
        {
            con.Open();
           
            string sql = "select * from tblHR_Departments ";
                SqlCommand CmdFinYear = new SqlCommand(sql, con);
                SqlDataAdapter DAFin = new SqlDataAdapter(CmdFinYear);
                DataTable DSitem = new DataTable();
                DAFin.Fill(DSitem);
                GridView1.DataSource = DSitem;
                GridView1.DataBind();
              
           
        }




        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection();

        try
        {
            con.Open();
            if (DropDownList1.SelectedItem.Text=="h")
            {
                string sql = "select * from tblHR_Departments";
                SqlCommand CmdFinYear = new SqlCommand(sql, con);
                SqlDataAdapter DAFin = new SqlDataAdapter(CmdFinYear);
               DataTable DSitem = new DataTable();
                DAFin.Fill(DSitem);
                GridView1.DataSource = DSitem;
                GridView1.DataBind();
            }
        }




        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();

        }
    }

}

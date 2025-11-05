using System;
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
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

public partial class Challanreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Labeldate.Text = DateTime.Today.ToString("dd/MM/yyyy");
      //  Labeldate.Text=Request.qu

        Label1.Text = Request.QueryString["PRJCTNO"];
        display();
        //display1();

    }
    protected void display()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select distinct PRJCTNO, WONO, GenDate from tblPM_Project_Site_MasterD where" + " PRJCTNO = @PRJCTNO";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@PRJCTNO", Label1.Text);
        
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                Labeldc.Text = sdr["PRJCTNO"].ToString();
                Labeldate.Text = sdr["GenDate"].ToString();
              
                lblwonor.Text = sdr["WONo"].ToString();

                
              
            }
            
        }
        catch (Exception ex)
        {
           // throw ex;
        }
        finally
        {
            con.Close();
        }
       
    }
 


}

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


        Label1.Text = Request.QueryString["VehNo"];
        display();
        //display1();
       

    }
    protected void display()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select Destination,Address,VehNo,Date,Contact,Emp,Vehical_Name,FromKM,FromTo,((FromTo)-(FromKM)) AS Avg,Fluel_Date,Fluel_Rs,Material from tblVeh_Master_Details where" + " VehNo = @VehNo";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@VehNo", Label1.Text);
        
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                LabelType.Text = sdr["Vehical_Name"].ToString();
                Labelto.Text = sdr["Destination"].ToString();
                Labelad.Text = sdr["Address"].ToString();

                Labeldc.Text = sdr["VehNo"].ToString();
                Labeldate.Text = sdr["Date"].ToString();
               
                Labelcn.Text = sdr["Contact"].ToString();


                Labelrm.Text = sdr["Material"].ToString();
                Labeltn.Text = sdr["FromKM"].ToString();
                Labelvn.Text = sdr["FromTo"].ToString();
                Labelln.Text = sdr["Avg"].ToString();

                labelfuelDate.Text = sdr["Fluel_Date"].ToString();
                lblfrs.Text = sdr["Fluel_Rs"].ToString();
                labelemp.Text = sdr["Emp"].ToString();
              
                //Labelack.Text = sdr["Acknowledgement"].ToString();
               
               
                LabelType.Text=LabelType.Text.ToUpper();
            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
       
    }
}

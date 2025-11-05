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
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
    static SqlDataAdapter da;
    static DataTable dt;
    static DataSet ds;
    string query;
    SqlCommand cmd;
    SqlCommand cmd1;

    protected void Page_Load(object sender, EventArgs e)
    {
       // Labeldate.Text = DateTime.Today.ToString("dd/MM/yyyy");
      //  Labeldate.Text=Request.qu

        Label1.Text = Request.QueryString["VendorPlan"];
        display();
        DisplayRecord();
        //display1();

    }
    protected void display()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select distinct VendorPlan, WONO, GenDate from tblPM_Project_Hardware_VendorD where" + " VendorPlan = @VendorPlan";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@VendorPlan", Label1.Text);
        
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                Labeldc.Text = sdr["VendorPlan"].ToString();
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

    public void DisplayRecord()
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 = string.Format("select Id,VendorPlan,ItemCode,Description,UOM,BOMQ,Design,VendorPlanDate,VendorAct from tblPM_Project_Vendor_Plan_Detail where VendorPlan = '" + Labeldc.Text + "'");
       


        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();

        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        
       
    }

    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Boughtout_Report_Info_Edit.aspx?ModId=7&SubModId=154", true);

    }





  
    }
    



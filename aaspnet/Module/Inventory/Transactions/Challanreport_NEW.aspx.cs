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
        

        Label1.Text = Request.QueryString["DCNo"];
        display();
        //display1();
        Calqty();
        Caltotal();

    }
    protected void display()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select  CustomerName,Address,GST,DCNo,DCDate,Attention,Contact,Responsible_By,Type,Gst_per,(((Gst_per)*(TAmt))/100) AS GTotal ,((((Gst_per)*(TAmt))/100) + TAmt) As GrandTotal,Remark,Transport,vehicleNo,LRNo,Acknowledgement,GSTWORDS from Challan_Master where" + " DCNo = @DCNo";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@DCNo", Label1.Text);
        
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                LabelType.Text = sdr["Type"].ToString();
                Labelto.Text = sdr["CustomerName"].ToString();
                Labelad.Text = sdr["Address"].ToString();
                Labelgst.Text = sdr["GST"].ToString();
                Labeldc.Text = sdr["DCNo"].ToString();
                Labeldate.Text = sdr["DCDate"].ToString();
                Labelkn.Text = sdr["Attention"].ToString();
                Labelcn.Text = sdr["Contact"].ToString();
                Labelres.Text = sdr["Responsible_By"].ToString();
               // TQ.Text = sdr["TQty"].ToString();
               // Tot.Text = sdr["TAmt"].ToString();
                GST.Text = sdr["Gst_per"].ToString();
                LabelGT.Text = sdr["GTotal"].ToString();
                Labelrm.Text = sdr["Remark"].ToString();
                Labeltn.Text = sdr["Transport"].ToString();
                Labelvn.Text = sdr["vehicleNo"].ToString();
                Labelln.Text = sdr["LRNo"].ToString();
                lblgrandtotal.Text = sdr["GrandTotal"].ToString();
                //Labelack.Text = sdr["Acknowledgement"].ToString();
                GST0.Text = sdr["GSTWORDS"].ToString();
               
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


    public void Calqty()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(quantity) as qty from Challan_Details where DCNo='" + Labeldc.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            TQ.Text = cmdzs.ExecuteScalar().ToString();
        }

    }




    public void Caltotal()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(amount) as Total from Challan_Details where DCNo='" + Labeldc.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            Tot.Text = cmdzs.ExecuteScalar().ToString();
        }

    }

}

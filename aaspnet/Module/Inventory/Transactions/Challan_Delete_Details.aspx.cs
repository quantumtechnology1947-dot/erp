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
using System.Collections.Generic;

public partial class Challanreport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
    static SqlDataAdapter da;
    static DataTable dt;
    static DataSet ds;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        

        Label1.Text = Request.QueryString["DCNo"];
        display();
        DisplayRecord();
        //display1();

    }



    public void Caltotal()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(amount) as Total from Challan_Master where DCNo='" + Labeldc.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            Tot.Text = cmdzs.ExecuteScalar().ToString();
        }

    }
    public void Calqty()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(quantity) as qty from Challan_Master where DCNo='" + Labeldc.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            TQ.Text = cmdzs.ExecuteScalar().ToString();
        }

    }


    protected void display()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select distinct CustomerName,Address,GST,DCNo,DCDate,Attention,Contact,Responsible_By,Type,TQty,TAmt,Gst_per,GTotal,Remark,Transport,vehicleNo,LRNo,Acknowledgement from Challan_Master where" + " DCNo = @DCNo";
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
                TQ.Text = sdr["TQty"].ToString();
                Tot.Text = sdr["TAmt"].ToString();
                GST.Text = sdr["Gst_per"].ToString();
                LabelGT.Text = sdr["GTotal"].ToString();
                Labelrm.Text = sdr["Remark"].ToString();
                Labeltn.Text = sdr["Transport"].ToString();
                Labelvn.Text = sdr["vehicleNo"].ToString();
                Labelln.Text = sdr["LRNo"].ToString();
                //Labelack.Text = sdr["Acknowledgement"].ToString();
                LabelType.Text = LabelType.Text.ToUpper();
                Calqty();
                Caltotal();
               
                
            }
            
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        finally
        {
            con.Close();
        }
       
    }
 


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int no = Convert.ToInt16(GridView12.DataKeys[e.RowIndex].Values["DCNo"].ToString());
        string i = GridView12.DataKeys[e.RowIndex].Values["ItemCode"].ToString();
        SqlCommand cmd = new SqlCommand("DELETE FROM [Challan_Details] WHERE [DCNo] = @DCNo and [ItemCode] = @ItemCode ", con);
        cmd.Parameters.AddWithValue("@DCNo", no);
        cmd.Parameters.AddWithValue("@ItemCode", i);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        DisplayRecord();
        //total.Text = "";
        //qty.Text = "";
        Calqty();
        Caltotal();
    }
    public void DisplayRecord()
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 = string.Format("select DCNo,ItemCode,Description,HSN,Quantity,Rate,Amount from Challan_Details where DCNo = '" + Labeldc.Text + "'");
       


        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds);
        GridView12.DataSource = ds.Tables[0];
        GridView12.DataBind();

       
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Challan_Delete.aspx?ModId=9&SubModId=147");


    }
    protected void DELETE_Click(object sender, EventArgs e)
    {
        DELETEALL();
    }
    public void DELETEALL()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 = string.Format("Delete  from Challan_Master where DCNo = '" + Labeldc.Text + "'");
        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds);
        Response.Redirect("Challan_Delete.aspx?ModId=9&SubModId=147");

    }
}

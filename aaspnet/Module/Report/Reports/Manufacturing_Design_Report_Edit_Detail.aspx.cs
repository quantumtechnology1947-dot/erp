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

        Label1.Text = Request.QueryString["PRJCTNO"];
        display();
        DisplayRecord();
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

    public void DisplayRecord()
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 = string.Format("select PRJCTNO,ItemCode,Description,UOM,BOMQ,Design from tblPM_Project_Site_Master_Detail where PRJCTNO = '" + Labeldc.Text + "'");
       


        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();

        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow grv in GridView2.Rows)
            {
                //TextBox txtdesign = (grv.Cells[5].FindControl("txtdesign") as TextBox);
                //TextBox txtmanf = (grv.Cells[6].FindControl("txtmanf") as TextBox);
                //TextBox txtbop = (grv.Cells[7].FindControl("txtbop") as TextBox);
                //TextBox txtassemly = (grv.Cells[8].FindControl("txtassemly") as TextBox);

                //CheckBox chkitems = (grv.Cells[0].FindControl("chkitems1") as CheckBox);




               // string txtven1 = (grv.FindControl("txtven1") as TextBox).Text;
              //  string txtven2 = (grv.FindControl("txtven2") as TextBox).Text;
             //   string txtbop = (grv.FindControl("txtbop") as TextBox).Text;
                //  string txthrs = (grv.FindControl("txthrs") as TextBox).Text;
               // string txtassemly = (grv.FindControl("txtassemly") as TextBox).Text;

                CheckBox chkitems = (grv.Cells[0].FindControl("chkitems1") as CheckBox);
                TextBox txtven1 = (grv.Cells[6].FindControl("txtven1") as TextBox);
                  TextBox txtven2 = (grv.Cells[6].FindControl("txtven2") as TextBox);

                if (chkitems.Checked)
                {

                    ////query = "Update tblPM_Project_Hardware_Master_Detail  set Vendor1='" + txtven1.Text + "',Vendor2='" + txtven2.text + "'where  PRJCTNO='" + Labeldc.Text + "'";

                    //SqlCommand cmd1 = new SqlCommand("UPDATE tblPM_Project_Site_Master_Detail SET Design = @Design, Manf = @Manf,BOP=@BOP,Assemly=@Assemly  WHERE PRJCTNO = @PRJCTNO", con);
                    ////cmd1.Parameters.AddWithValue("@Design", txtdesign.Text);
                    ////cmd1.Parameters.AddWithValue("@Manf", txtmanf.Text);
                    ////cmd1.Parameters.AddWithValue("@BOP", txtbop.Text);
                    ////cmd1.Parameters.AddWithValue("@Assemly", txtassemly.Text);
 // cmd = new SqlCommand(query, con);



                    grv.BackColor = System.Drawing.Color.Pink;
                    cmd1 = new SqlCommand("INSERT INTO tblPM_Project_Site_Master_Detail(PRJCTNO,WONo,Vendor1,Vendor2) values(@PRJCTNO,@WONo,@Vendor1,@Vendor2) Where PRJCTNO='" + Labeldc.Text + "'", con);
                cmd1.Parameters.AddWithValue("@Vendor1", txtven1.Text);
                cmd1.Parameters.AddWithValue("@Vendor2", txtven2.Text);



                    cmd1.ExecuteNonQuery();
                }


            }
        }
        catch (Exception ex)
        {

        }
       
    }

    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Boughtout_Report_Info_Edit.aspx?ModId=7&SubModId=154", true);

    }





    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridViewRow grv in GridView2.Rows)
        {
            CheckBox chkitems = (grv.Cells[0].FindControl("chkitems1") as CheckBox);

            TextBox txtdesign1 = (grv.Cells[5].FindControl("txtdesign") as TextBox);
            TextBox txtmanf1 = (grv.Cells[6].FindControl("txtmanf") as TextBox);
            TextBox txtbop1 = (grv.Cells[7].FindControl("txtbop") as TextBox);
            TextBox txtassemly = (grv.Cells[8].FindControl("txtassemly") as TextBox);
          //  TextBox txthrs = (grv.Cells[9].FindControl("txthrs") as TextBox);

            if (chkitems.Checked)
            {
                txtdesign1.Visible = true;
                txtmanf1.Visible = true;
                txtbop1.Visible = true;
                txtassemly.Visible = true;
             //   txthrs.Visible = true;

            }

            else
            {
                txtdesign1.Visible = false;
                txtmanf1.Visible = false;
                txtbop1.Visible = false;
                txtassemly.Visible = false;
               // txthrs.Visible = false;

            }
        }

    }
    }



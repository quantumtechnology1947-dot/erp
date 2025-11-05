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
using Telerik.Web.UI;

public partial class Module_MaterialManagement_Transactions_PR_New_Detail : System.Web.UI.Page
{
    SqlCommand cmd1;
   // string wono = "";
    int CompId = 0;
    string SId = "";
    int fyid = 0;
    string WomfDate = "";
    string SupplierName = string.Empty;
    clsFunctions fun = new clsFunctions();   
    string connStr = "";
    SqlConnection con;
    static SqlDataAdapter da;
    static DataTable dt;
    static DataSet ds;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Display();
      
        display1();
        DisplayRecord();
      
        lblreportdate1.Text = DateTime.Today.ToString("dd/MM/yyyy");
        lblreport.Text = Request.QueryString["PRJCTNO"];
        lblreport1.Text = Request.QueryString["VendorPlan"];
       // lblreportdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
      //  lblWono.Text = Request.QueryString["WONo"];

     try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            fyid = Convert.ToInt32(Session["finyear"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
           // wono = Request.QueryString["WONo"].ToString();
            
          //  lblWono.Text = wono;
          //  WomfDate = this.WOmfgdate(wono, CompId, fyid);            
            if (!Page.IsPostBack)
            {
                
               
            }
            lblreportdate1.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblreport.Text = Request.QueryString["PRJCTNO"];
            lblreport1.Text = Request.QueryString["VendorPlan"];


            Display();
            DisplayRecord();
            //NoDisplay();
            GridColour();
            display1();

           
        }
      catch (Exception ex) { }
    }
    

    public void DisplayRecord()
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 = string.Format("select PRJCTNO,ItemCode,Description,UOM,BOMQ,Design from tblPM_Project_Hardware_Master_Detail where PRJCTNO = '" + lblreport.Text + "'");



        da = new SqlDataAdapter(sql1, con);
        ds = new DataSet();
        da.Fill(ds);
        RadGrid1.DataSource = ds.Tables[0];
        RadGrid1.DataBind();


    }


    
   
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }


   
    public void GridColour()
    {

        try
        {
            foreach (GridDataItem grv2 in RadGrid1.Items)
            {
                CheckBox chkitems = (grv2.Cells[0].FindControl("chkitems") as CheckBox);
                if (chkitems.Checked)
                {
                    grv2.BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    grv2.BackColor = System.Drawing.Color.Transparent;
                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Display()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {


            SqlCommand cmdzs = new SqlCommand("SELECT MAX((VendorPlan) + 1) as VendorPlan FROM tblPM_Project_Hardware_VendorD ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            lblreport1.Text = cmdzs.ExecuteScalar().ToString();
        }

    }


    protected void display1()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select distinct PRJCTNO, WONO, GenDate from tblPM_Project_Hardware_MasterD where" + " PRJCTNO = @PRJCTNO";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
        cmd.Parameters.AddWithValue("@WONO", lblWono.Text);
        cmd.Parameters.AddWithValue("@GenDate", lblreportdate.Text);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                lblreport.Text = sdr["PRJCTNO"].ToString();
                lblreportdate.Text = sdr["GenDate"].ToString();

                lblWono.Text = sdr["WONo"].ToString();



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



   

    protected void RadButton2_Click_Add(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        con.Open();

        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems1") as CheckBox;
            Label lblDesign = grv2.Cells[4].FindControl("lblDesign") as Label;
            //RadioButton rd = grv2.Cells[5].FindControl("rdoemail") as RadioButton;
            Label lblCode = grv2.Cells[0].FindControl("lblCode") as Label;
            Label lblDesc = grv2.Cells[1].FindControl("lblDesc") as Label;
            Label lbluombasic = grv2.Cells[2].FindControl("lbluombasic") as Label;
            Label lblbomqty = grv2.Cells[3].FindControl("lblbomqty") as Label;
            TextBox txtremark = grv2.Cells[7].FindControl("txtremark") as TextBox;
            TextBox txtven1 = grv2.Cells[5].FindControl("txtven1") as TextBox;
            TextBox txtven2 = grv2.Cells[6].FindControl("txtven2") as TextBox;

           


           



            //if (CK.Checked == true)
            {
                if (grv2 != null)
                {

                    grv2.BackColor = System.Drawing.Color.Pink;
                    cmd1 = new SqlCommand("INSERT INTO tblPM_Project_Hardware_Master_Detail(WONo,ItemCode,Description,UOM,BOMQ,Rdesign,Design,Remark,Vendor1,Vendor2) values(@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Rdesign,@Design,@Remark,@Vendor1,@Vendor2)", con);
                    cmd1.Parameters.AddWithValue("@ItemCode", lblCode.Text);
                    cmd1.Parameters.AddWithValue("@Description", lblDesc.Text);
                    cmd1.Parameters.AddWithValue("@UOM", lbluombasic.Text);
                    cmd1.Parameters.AddWithValue("@BOMQ", lblbomqty.Text);
                    cmd1.Parameters.AddWithValue("@Design", lblDesign.Text);
                    //  cmd1.Parameters.AddWithValue("@Rdesign", rd.Text);
                    cmd1.Parameters.AddWithValue("@Rdesign", lblreport1.Text);
                    cmd1.Parameters.AddWithValue("@WONo", lblWono.Text);
                    cmd1.Parameters.AddWithValue("@Remark", txtremark.Text);
                    cmd1.Parameters.AddWithValue("@Vendor1", txtven1.Text);
                    cmd1.Parameters.AddWithValue("@Vendor2", txtven2.Text);



                    cmd1.ExecuteNonQuery();
                    //txtdesign.Enabled = false;
                }
            }
        }
        con.Close();


    }

    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems") as CheckBox;
            TextBox txtven1 = grv2.Cells[6].FindControl("txtven1") as TextBox;
            TextBox txtven2 = grv2.Cells[6].FindControl("txtven2") as TextBox;

            if (CK.Checked == true)
            {
                txtven1.Enabled = true;
                txtven2.Enabled = true;

            }
            else
            {
                txtven1.Enabled = false;
                txtven2.Enabled = false;
            }
        }
    }

    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridViewRow grv in SearchGridView1.Rows)
        {
            CheckBox chkitems = (grv.Cells[0].FindControl("chkitems") as CheckBox);

            TextBox txtdesign1 = (grv.Cells[5].FindControl("txtdesign") as TextBox);
            TextBox txtmanf1 = (grv.Cells[6].FindControl("txtmanf") as TextBox);
            TextBox txtbop1 = (grv.Cells[7].FindControl("txtbop") as TextBox);
            DropDownList drpassemly = (grv.Cells[8].FindControl("drpassemly") as DropDownList);
            TextBox txthrs = (grv.Cells[9].FindControl("txthrs") as TextBox);

            if (chkitems.Checked)
            {


                grv.BackColor = System.Drawing.Color.Pink;

                txtdesign1.Visible = true;
                txtmanf1.Visible = true;
                txtbop1.Visible = true;
                drpassemly.Visible = true;
                txthrs.Visible = true;

            }

            else
            {
                txtdesign1.Visible = false;
                txtmanf1.Visible = false;
                txtbop1.Visible = false;
                drpassemly.Visible = false;
                txthrs.Visible = false;

            }
        }

    }






    protected void RadButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/PR_New.aspx?ModId=7&SubModId=155", true);
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string sqlStatment = "INSERT INTO tblPM_Project_Hardware_MasterD(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,GenDate) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@GenDate)";
            // string sqlStatment = "INSERT INTO tblPM_Project_Site_Master(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,Manf,BOP,Assemly) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@Manf,@BOP,@Assemly)";
            {
                using (SqlCommand cmds = new SqlCommand(sqlStatment, con))
                {
                    cmds.Parameters.AddWithValue("@SysDate", CDate.ToString());
                    cmds.Parameters.AddWithValue("@SysTime", CTime.ToString());
                    cmds.Parameters.AddWithValue("@CompId", CompId);
                    cmds.Parameters.AddWithValue("@SessionId", SId.ToString());
                    cmds.Parameters.AddWithValue("@FinYearId", fyid);
                    cmds.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                    cmds.Parameters.AddWithValue("@WONo", lblWono.Text);
                    cmds.Parameters.AddWithValue("@GenDate", lblreportdate.Text);
                    con.Open();
                    cmds.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/Module/ProjectManagement/Transactions/PR_New.aspx?ModId=7&SubModId=155", true);

                   // Response.Redirect("~/Module/ProjectManagement/Transactions/PR_New.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
   
    

}

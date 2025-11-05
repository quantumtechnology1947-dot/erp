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
    string wono = "";
    int CompId = 0;
    string SId = "";
    int fyid = 0;
    string WomfDate = "";
    string SupplierName = string.Empty;
    clsFunctions fun = new clsFunctions();   
    string connStr = "";
    SqlConnection con;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        MP_Tree1();
        Display();
       

        lblreportdate2.Text = DateTime.Today.ToString("dd/MM/yyyy");
        lblreport1.Text = Request.QueryString["VendorPlan"];
       // lblreport1.Text = Request.QueryString["VendorPlan"];
        display1();
      //  display2();
        
       
     try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            fyid = Convert.ToInt32(Session["finyear"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
         //   wono = Request.QueryString["WONo"].ToString();
            
          
                      
            if (!Page.IsPostBack)
            {
                //fun.MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null"); 
               // this.MP_Tree1( RadGrid1); 

                MP_Tree1();
               // this.FillFIN();
            }


            
        }
      catch (Exception ex) { }
    }


    protected void display1()
    {
        String strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        String strQuery = "select distinct VendorPlan, WONO, GenDate,PRJCTNO from tblPM_Project_Hardware_VendorD where" + " VendorPlan = @VendorPlan";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@VendorPlan", lblreport1.Text);
        cmd.Parameters.AddWithValue("WONO", lblWono.Text);
        cmd.Parameters.AddWithValue("GenDate", lblreportdate1.Text);
        cmd.Parameters.AddWithValue("PRJCTNO", lblreport.Text);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                lblreport1.Text = sdr["VendorPlan"].ToString();
                lblreportdate1.Text = sdr["GenDate"].ToString();

                lblWono.Text = sdr["WONo"].ToString();

                lblreport.Text = sdr["PRJCTNO"].ToString();



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


    


    public void MP_Tree1()
    {


        try
        {
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("BOMQ", typeof(string));

            dt.Columns.Add("Design", typeof(string));

            dt.Columns.Add("VendorPlanDate", typeof(string));
            dt.Columns.Add("VendorAct", typeof(string));
            
            DataRow dr;
            string sql = "select ItemCode,Description,UOM,BOMQ,Design,VendorPlanDate,VendorAct From tblPM_Project_Vendor_Plan_Detail Where VendorPlan='" + lblreport1.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();
                dr[0] = rdr["ItemCode"].ToString();
                dr[1] = rdr["Description"].ToString();
                dr[2] = rdr["UOM"].ToString();
                
                dr[3] = rdr["BOMQ"].ToString();
                dr[4] = rdr["Design"].ToString();
                dr[5] = rdr["VendorPlanDate"].ToString();
                dr[6] = rdr["VendorAct"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
             

            }

            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
            rdr.Close();

            con.Close();

        }
        catch (Exception ch)
        {
        }
        

    }
    
   
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }


    public void Display()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {


            SqlCommand cmdzs = new SqlCommand("SELECT MAX((AssemlyNo) + 1) as AssemlyNo FROM tblPM_Project_Hardware_Assemly_Master ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            lblreport2.Text = cmdzs.ExecuteScalar().ToString();
        }

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



    protected void RadButton2_Click_Cancel(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        con.Open();

        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems") as CheckBox;
            Label txtdesign = grv2.Cells[5].FindControl("txtdesign") as Label;
            //RadioButton rd = grv2.Cells[5].FindControl("rdoemail") as RadioButton;
            Label lblCode=grv2.Cells[1].FindControl("lblCode")as Label;
            Label lblDesc = grv2.Cells[2].FindControl("lblDesc") as Label;
            Label lbluombasic = grv2.Cells[3].FindControl("lbluombasic") as Label;
            Label lblbomqty = grv2.Cells[4].FindControl("lblbomqty") as Label;
            TextBox txtremark = grv2.Cells[6].FindControl("txtremark") as TextBox;
            Label txtven1 = grv2.Cells[7].FindControl("txtven1") as Label;
            Label txtven2 = grv2.Cells[8].FindControl("txtven2") as Label;
            TextBox txtassm = grv2.Cells[9].FindControl("txtassm") as TextBox;

            if (CK.Checked == true)
            {
                grv2.BackColor = System.Drawing.Color.Pink;
                cmd1 = new SqlCommand("INSERT INTO tblPM_Project_Hardware_Assemly_Detail(PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,VendorPlanDate,VendorAct,VendorPlan,AssemlyDate,AssemlyNo) values(@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@VendorPlanDate,@VendorAct,@VendorPlan,@AssemlyDate,@AssemlyNo)", con);
                cmd1.Parameters.AddWithValue("@ItemCode", lblCode.Text);
                cmd1.Parameters.AddWithValue("@Description", lblDesc.Text);
                cmd1.Parameters.AddWithValue("@UOM", lbluombasic.Text);
                cmd1.Parameters.AddWithValue("@BOMQ", lblbomqty.Text);
                cmd1.Parameters.AddWithValue("@Design", txtdesign.Text);
               // cmd1.Parameters.AddWithValue("@Rdesign", rd.Text);
                cmd1.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                cmd1.Parameters.AddWithValue("@WONo", lblWono.Text);
               // cmd1.Parameters.AddWithValue("@Remark", txtremark.Text);
                cmd1.Parameters.AddWithValue("@VendorPlanDate", txtven1.Text);
                cmd1.Parameters.AddWithValue("@VendorAct", txtven2.Text);
                cmd1.Parameters.AddWithValue("@VendorPlan", lblreport1.Text);
                cmd1.Parameters.AddWithValue("@AssemlyDate", txtassm.Text);
                cmd1.Parameters.AddWithValue("@AssemlyNo", lblreport2.Text);

                cmd1.ExecuteNonQuery();
                txtassm.Enabled = false;
            }
        }

        con.Close();


    }

    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems") as CheckBox;
            TextBox txtassm = grv2.Cells[9].FindControl("txtassm") as TextBox;
            //TextBox txtven2 = grv2.Cells[8].FindControl("txtven2") as TextBox;
            
            if (CK.Checked == true)
            {
                txtassm.Enabled = true;
               

            }
            else
            {
                txtassm.Enabled = false;
               
            }
        }
    }
    
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/VendorA_Report_Info.aspx?ModId=7&SubModId=157", true);
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string sqlStatment = "INSERT INTO tblPM_Project_Hardware_Assemly_Master(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,GenDate,VendorPlan,VendorDate,AssemlyNo,AssemlyDate) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@GenDate,@VendorPlan,@VendorDate,@AssemlyNo,@AssemlyDate)";
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
                    cmds.Parameters.AddWithValue("@GenDate", lblreportdate2.Text);
                    cmds.Parameters.AddWithValue("@VendorPlan", lblreport1.Text);
                    cmds.Parameters.AddWithValue("@VendorDate", lblreportdate1.Text);
                    cmds.Parameters.AddWithValue("@AssemlyNo", lblreport2.Text);
                    cmds.Parameters.AddWithValue("@AssemlyDate", lblreportdate2.Text);

                    con.Open();
                    cmds.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/Module/ProjectManagement/Transactions/VendorA_Report_Info.aspx?ModId=7&SubModId=157", true);

                   // Response.Redirect("~/Module/ProjectManagement/Transactions/PR_New.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
   
    

}

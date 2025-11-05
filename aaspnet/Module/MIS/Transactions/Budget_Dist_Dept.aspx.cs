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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Module_Accounts_Transactions_Budget_Dist_Dept : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    int CompId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
            //this.CalculateBalAmt();
            
       }
        
        TabContainer1.OnClientActiveTabChanged = "OnChanged";
        TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");       
 
    }


    //public void CalculateBalAmt()
    //{

    //    string connStr = fun.Connection();
    //    SqlConnection con = new SqlConnection(connStr);

    //   try
    //    {
           

    //        con.Open();

    //        {
    //            foreach (GridViewRow grv in GridView1.Rows)
    //            {
    //                int BGId = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);


    //                string selectBudget = "select Sum(Amount) As Budget from tblACC_Budget_Dept where     BGId='" + BGId + "' group by  BGId ";
    //                SqlCommand cmdBD = new SqlCommand(selectBudget, con);
    //                SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
    //                DataSet dsBD = new DataSet();
    //                daBD.Fill(dsBD, "tblACC_Budget_Dept");

    //                ((HyperLink)grv.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details.aspx?BGId=" + BGId + "&ModId=14";

    //                if (dsBD.Tables[0].Rows.Count > 0)
    //                {
    //                    double budget = Math.Round(Convert.ToDouble(dsBD.Tables[0].Rows[0]["Budget"].ToString()), 2);
    //                    ((Label)grv.FindControl("lblAmount")).Text =budget.ToString();
    //                    ((HyperLink)grv.FindControl("HyperLink1")).Visible = true;
    //                }
    //                else
    //                {
    //                    ((Label)grv.FindControl("lblAmount")).Text = "0";
    //                    ((HyperLink)grv.FindControl("HyperLink1")).Visible = false;
    //                }


    //                double POSPRBasicDiscAmt = 0;

    //                POSPRBasicDiscAmt = fun.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, "0", DeptId, 1, 1);
    //                ((Label)grv.FindControl("lblPO")).Text = Convert.ToString(Math.Round(POSPRBasicDiscAmt, 2));

    //                double POSPRTaxAmt = 0;

    //                POSPRTaxAmt = fun.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId")).Text), 1, 1, "0", DeptId, 1, 2);

    //                ((Label)grv.FindControl("lblTax")).Text = Convert.ToString(Math.Round(POSPRTaxAmt, 2));

    //                ((Label)grv.FindControl("lblBudget")).Text = Convert.ToString(Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text) - (POSPRBasicDiscAmt + POSPRTaxAmt), 2));
                    

    //            }

    //            // to fill Second Grid view 

    //            foreach (GridViewRow grv in GridView2.Rows)
    //            {
    //                int accid = Convert.ToInt32(((Label)grv.FindControl("lblId0")).Text);

                    
    //                ((HyperLink)grv.FindControl("HyperLink2")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details.aspx?DeptId=" + DeptId + "&Id=" + accid + "&ModId=14";
    //                string select1 = "select Sum(Amount) As Budget from tblACC_Budget_Dept where AccId='" + accid + "'   and  DeptId='" + DeptId + "' group by  AccId ";
    //                SqlCommand cmd1 = new SqlCommand(select1, con);

    //                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    //                DataSet ds1 = new DataSet();
    //                da1.Fill(ds1, "tblACC_Budget_Dept");
    //                if (ds1.Tables[0].Rows.Count > 0)
    //                {

    //                    double budget = Math.Round(Convert.ToDouble(ds1.Tables[0].Rows[0]["Budget"]),2);
    //                    ((Label)grv.FindControl("lblAmount0")).Text = budget.ToString();
    //                    ((HyperLink)grv.FindControl("HyperLink2")).Visible = true;

    //                }
    //                else
    //                {
    //                    ((Label)grv.FindControl("lblAmount0")).Text = "0";
    //                    ((HyperLink)grv.FindControl("HyperLink2")).Visible = false;
    //                }

    //                double POSPRBasicDiscAmt = 0;

    //                POSPRBasicDiscAmt = fun.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId0")).Text), 1, 1, "0", DeptId, 1, 1);
    //                ((Label)grv.FindControl("lblPO0")).Text = Convert.ToString(Math.Round(POSPRBasicDiscAmt, 2));

    //                double POSPRTaxAmt = 0;

    //                POSPRTaxAmt = fun.getTotal_PO_Budget_Amt(CompId, Convert.ToInt32(((Label)grv.FindControl("lblId0")).Text), 1, 1, "0", DeptId, 1, 2);

    //                ((Label)grv.FindControl("lblTax0")).Text = Convert.ToString(Math.Round(POSPRTaxAmt, 2));

    //                ((Label)grv.FindControl("lblBudget0")).Text = Convert.ToString(Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount0")).Text) - (POSPRBasicDiscAmt + POSPRTaxAmt), 2));

    //            }

    //        }

    //    }

    //  catch(Exception ex)
    //    {

    //    }
    //  finally
    //    {
    //        con.Close();
    //    }
       

    //}


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

      
        ///--------------------------------------------------------
      
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

             try
            {

                string CDate = fun.getCurrDate();
                string CTime = fun.getCurrTime();
                string sId = Session["username"].ToString();

                int FinYearId = Convert.ToInt32(Session["finyear"]);
                int DeptId = Convert.ToInt32(Request.QueryString["id"]);
                int id = 0;
                if (e.CommandName == "Insert")
                {
                    con.Open();

                    foreach (GridViewRow grv in GridView1.Rows)
                    {
                        if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                        {
                            id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                         
                            double Amt = Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text);


                            if ( Amt > 0)
                            {
                                string insert = ("Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,DeptId,AccId,Amount  ) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + DeptId + "','" + id + "','" + Amt + "')");
                                SqlCommand cmd = new SqlCommand(insert, con);
                                cmd.ExecuteNonQuery();
                                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            }

                        }

                    }

                    

                }
                if (e.CommandName == "export")
                {
                    Response.Redirect("~/Module/MIS/Transactions/Budget_Dept_Print.aspx?ModId=14");
                }


            }

           catch(Exception ex)
            {
            }
           finally
            {
                con.Close();
            }



        }
 


        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
           
            try
            {
                
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();
         
           int FinYearId =Convert.ToInt32( Session["finyear"]);
            int DeptId = Convert.ToInt32(Request.QueryString["id"]);
            int id = 0;
                if (e.CommandName == "Insert")
                {
                    con.Open();

                    foreach (GridViewRow grv in GridView2.Rows)
                    {
                        if (((CheckBox)grv.FindControl("CheckBox2")).Checked == true)
                        {
                            id = Convert.ToInt32(((Label)grv.FindControl("lblId0")).Text);
                            
                          
                            double Amt = Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount0")).Text);
                           

                            if ( Amt>0)
                            {
                                string insert = ("Insert into  tblACC_Budget_Dept (SysDate,SysTime,CompId,FinYearId,SessionId,DeptId,AccId,Amount  ) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + DeptId + "','" + id + "','" + Amt + "')");
                                SqlCommand cmd = new SqlCommand(insert, con);
                                cmd.ExecuteNonQuery();  
                                Page.Response.Redirect(Page.Request.Url.ToString(), true);                                                        
                            }                           
                         
                        }

                    }                 
                    
                }
                if (e.CommandName == "export")
                {
                    Response.Redirect("~/Module/MIS/Transactions/Budget_Dept_Print.aspx?ModId=14");
                }

            }

            catch(Exception ex)
            {
            }
           finally
            {
                con.Close();


            }
        }

      





 
 protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
 {
     try
     {

         foreach (GridViewRow grv in GridView1.Rows)
         {
             if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
             {
                 ((TextBox)grv.FindControl("TxtAmount")).Visible = true;
                 ((Label)grv.FindControl("lblAmount")).Visible = false;
                 GridView1.Visible = true;
                 GridView2.Visible = true;

             }
             else
             {
                 ((Label)grv.FindControl("lblAmount")).Visible = true;
                 ((TextBox)grv.FindControl("TxtAmount")).Visible = false;
                 GridView1.Visible = true;
                 GridView2.Visible = true;
             }
         }
     }
     catch(Exception ex)
     {
     }

 }

 protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
 {

     try
     {

         foreach (GridViewRow grv in GridView2.Rows)
         {
             if (((CheckBox)grv.FindControl("CheckBox2")).Checked == true)
             {
                 ((Label)grv.FindControl("lblAmount0")).Visible = false;
                 ((TextBox)grv.FindControl("TxtAmount0")).Visible = true;
                 GridView1.Visible = true;
                 GridView2.Visible = true;

             }
             else
             {
                 ((Label)grv.FindControl("lblAmount0")).Visible = true;
                 ((TextBox)grv.FindControl("TxtAmount0")).Visible = false;
                 GridView1.Visible = true;
                 GridView2.Visible = true;

             }
         }
     }
     catch(Exception ex)
     {
     }

 }

 protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
 {
     Session.Remove("TabIndex");
 }
}

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

public partial class Module_Accounts_Transactions_Budget_Dist_Dept_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        lblMessage.Text = "";

        if (!IsPostBack)
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string Code = "";
            try
            {
            Code = Request.QueryString["Id"];
            string deptid = Request.QueryString["DeptId"];
            string dept = "Select Description from tblHR_Departments where Id='"+deptid+"'";
            SqlCommand cmddept = new SqlCommand(dept, con);
            SqlDataAdapter dadept = new SqlDataAdapter(cmddept);
            DataSet dsdept = new DataSet();
            dadept.Fill(dsdept);
            lbldept.Text=dsdept.Tables[0].Rows[0]["Description"].ToString();
            
            
                string sel = "Select tblACC_Budget_Dept.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept.SysDate , CHARINDEX('-',tblACC_Budget_Dept.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', tblACC_Budget_Dept.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept.SysTime,AccHead.Description,AccHead.Symbol,tblACC_Budget_Dept.Amount from  tblACC_Budget_Dept ,AccHead where   AccHead.Id=tblACC_Budget_Dept.AccId and tblACC_Budget_Dept.DeptId='" + deptid + "'  and tblACC_Budget_Dept.AccId='" + Code + "' ";
                SqlCommand cmd = new SqlCommand(sel, con); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    lblCode.Text = ds.Tables[0].Rows[0]["Symbol"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            
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
     
     int  FinYearId =Convert.ToInt32( Session["finyear"]);


            if (e.CommandName == "Update")
            {
                con.Open();
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                    {
                        int AcId = Convert.ToInt32(Request.QueryString["Id"]);
                       // double budget = fun.getBudget(AcId, CompId);
                       // double amt = Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text);
                        double Amt =Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text),2);
                        int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                        if (Amt > 0)
                        {
                            string update = ("Update   tblACC_Budget_Dept  set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "'  ,Amount='" + Amt + "'  where Id='" + id + "' ");
                        
                            SqlCommand cmd = new SqlCommand(update, con);
                            cmd.ExecuteNonQuery();
                            lblMessage.Text = "Record Updated";
                        }

                    }

                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }

            if(e.CommandName=="cancel")
            {
               try
                {
                    string deptid = Request.QueryString["DeptId"];
                    Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Dept.aspx?id=" + deptid + "&ModId=14");
                }
                catch (Exception ex)
                {
                }

            }



       }

     catch (Exception ex)
        {
        }
       finally
        {
            con.Close();



        }
   try
        {

            if (e.CommandName == "Deletes")
            {
                con.Open();
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                    {

                        int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                        string delete = (" Delete from tblACC_Budget_Dept where  Id='" + id + "'");
                        SqlCommand cmd = new SqlCommand(delete, con);
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Record Deleted";
                    }

                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
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
   
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

        try
        {

            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {

                    ((TextBox)grv.FindControl("TxtAmount")).Visible = true;
                    ((Label)grv.FindControl("lblAmount")).Visible = false;
                }
                else
                {
                    ((Label)grv.FindControl("lblAmount")).Visible = true;
                    ((TextBox)grv.FindControl("TxtAmount")).Visible = false;

                }

            }
        }

        catch (Exception ex)
        {
        }


    }


    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception ex)
        {
        }

    }
}

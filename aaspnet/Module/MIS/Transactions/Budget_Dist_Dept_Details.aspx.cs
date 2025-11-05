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

public partial class Module_MIS_Transactions_Budget_Dist_Dept_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        lblMessage.Text = "";

      
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string Code = "";
            try
            {
                   Code = Request.QueryString["Id"];
                    string bgid = Request.QueryString["BGId"];
                 if (!IsPostBack)
                  {
                string dept = "Select Name from BusinessGroup where Id='" + bgid + "'";
                SqlCommand cmddept = new SqlCommand(dept, con);
                SqlDataAdapter dadept = new SqlDataAdapter(cmddept);
                DataSet dsdept = new DataSet();
                dadept.Fill(dsdept);
                lbldept.Text = dsdept.Tables[0].Rows[0]["Name"].ToString();

                string sel = "Select tblACC_Budget_Dept.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept.SysDate , CHARINDEX('-',tblACC_Budget_Dept.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', tblACC_Budget_Dept.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept.SysTime,BusinessGroup.Name,BusinessGroup.Symbol,tblACC_Budget_Dept.Amount from  tblACC_Budget_Dept ,BusinessGroup where   BusinessGroup.Id=tblACC_Budget_Dept.BGId and tblACC_Budget_Dept.BGId='" + bgid + "' and tblACC_Budget_Dept.FinYearId=" + FinYearId + "  ";
                SqlCommand cmd = new SqlCommand(sel, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    
                    Response.Redirect("~/Module/MIS/Transactions/Budget_Dist.aspx?ModId=14");
                }

              
               
               }
            }
          catch (Exception ex)
            {
            }


        

    }






    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        

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
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();

            int FinYearId = Convert.ToInt32(Session["finyear"]);



            con.Open();
            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    int AcId = Convert.ToInt32(Request.QueryString["Id"]);
                    // double budget = fun.getBudget(AcId, CompId);
                    // double amt = Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text);
                    double Amt = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
                    int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    if (Amt > 0 )
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
        catch (Exception ex)
        {
        }

            

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        
        con.Open();
        try
        {
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
        catch (Exception ex)
        {

        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
            try
            {
                string deptid = Request.QueryString["BGId"];
                Response.Redirect("~/Module/MIS/Transactions/Budget_Dist.aspx?ModId=14");
            }
            catch (Exception ex)
            {
            }

        
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

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

public partial class Module_Accounts_Transactions_Budget_WithMaterial_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {     lblMessage.Text = "";
    CompId = Convert.ToInt32(Session["compid"]);
        if (!IsPostBack)
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            try
            {
            string Code = Request.QueryString["Id"];
            lblCode.Text = Code;
                SqlCommand cmd = new SqlCommand("Select   tblACC_Budget_Transactions.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Transactions.SysDate , CHARINDEX('-',tblACC_Budget_Transactions.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', tblACC_Budget_Transactions.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Transactions.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Transactions.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Transactions.SysTime,tblACC_Budget_Transactions.BudgetCode,  AccHead.Description+'-'+ AccHead.Symbol  AS Description,tblACC_Budget_Transactions.Amount  from  AccHead ,tblACC_Budget_Transactions where tblACC_Budget_Transactions.BudgetCode=AccHead.Id  and  AccHead.Id='" + Code + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                lblDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
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
                        double Amt = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text),2);
                        int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                        if (Amt > 0)
                        {

                            string update = ("Update   tblACC_Budget_Transactions  set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "'  ,Amount='" + Amt + "'  where Id='" + id + "' ");
                            SqlCommand cmd = new SqlCommand(update, con);
                            cmd.ExecuteNonQuery();
                            lblMessage.Text = "Record Updated";
                        }
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
                        string delete = (" Delete from tblACC_Budget_Transactions where  Id='"+id+"'");
                       
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
    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated";
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    { 
        lblMessage.Text = "Record Updated";

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


    
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        try
        {
        string Code = Request.QueryString["Id"];
        Response.Redirect("~/Module/MIS/Transactions/Budget_WithMaterial_Print.aspx?Id=" + Code + "");
        }
        catch (Exception ex)
        {
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Transactions/Dashboard.aspx?ModId=14");
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

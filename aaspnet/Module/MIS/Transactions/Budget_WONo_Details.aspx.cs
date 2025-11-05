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

public partial class Module_Accounts_Transactions_Budget_WONo_Details : System.Web.UI.Page
{ clsFunctions fun = new clsFunctions();

    int CompId = 0;
    int FinId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        FinId = Convert.ToInt32(Session["finyear"]);
        lblMessage.Text = "";
        if (!IsPostBack)
        {
            this.FillGrid();
        }

    }

    public void FillGrid()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            con.Open();
            string Code = Request.QueryString["Id"];
            string wono = Request.QueryString["WONo"];

            lblWONo.Text = wono;
            string sel = "Select tblACC_Budget_WO.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_WO.SysDate , CHARINDEX('-',tblACC_Budget_WO.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_WO.SysDate , CHARINDEX('-', tblACC_Budget_WO.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_WO.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_WO.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_WO.SysTime,  tblMIS_BudgetCode.Description,tblMIS_BudgetCode.Symbol,tblACC_Budget_WO.Amount  from  tblACC_Budget_WO ,tblMIS_BudgetCode where   tblMIS_BudgetCode.Id=tblACC_Budget_WO.BudgetCodeId and tblACC_Budget_WO.WONo='" + wono + "'and tblACC_Budget_WO.FinYearId=" + FinId + "  and tblACC_Budget_WO.BudgetCodeId='" + Code + "' order by Id Desc ";
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
                Response.Redirect("~/Module/MIS/Transactions/Budget_WONo.aspx?WONo=" + wono + "");
            }
            lblDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            lblCode.Text = String.Concat(ds.Tables[0].Rows[0]["Symbol"].ToString(), wono);


        }
        catch (Exception ex) { }
        finally { con.Close(); }
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
                        int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                        int Code = Convert.ToInt32(Request.QueryString["Id"]);

                        double Amt = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2); if (Amt > 0)
                        {
                            string update = ("Update   tblACC_Budget_WO  set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "'  ,Amount='" + Amt + "'  where Id='" + id + "' ");
                            SqlCommand cmd12 = new SqlCommand(update, con);
                            cmd12.ExecuteNonQuery();
                            lblMessage.Text = "Record Updated";
                        }
                    }
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            

          
        }

        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        
             string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
              
        try
        {
              con.Open();
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                    {

                        int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                        string delete = (" Delete from tblACC_Budget_WO where  Id='" + id + "'");
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
        finally
        {
            con.Close();
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        string wono = Request.QueryString["WONo"];
        Response.Redirect("~/Module/MIS/Transactions/Budget_WONo.aspx?WONo=" + wono + "");
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.FillGrid();
        }
        catch (Exception ex)
        {
        }
    }
}

    


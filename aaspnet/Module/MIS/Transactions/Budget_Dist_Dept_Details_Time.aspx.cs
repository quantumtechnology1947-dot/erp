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

public partial class Module_MIS_Transactions_Budget_Dist_Dept_Details_Time : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    Cal_Used_Hours CUH = new Cal_Used_Hours();
    int CompId = 0;
    int FinYearId = 0;
    string Code = string.Empty;
    int BGId = 0;
    double TotalHr = 0;
    double UsedHr = 0;
    double BalHr = 0;
    string CDate = string.Empty;
    string CTime = string.Empty;
    string sId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        sId = Session["username"].ToString();
        Code = Request.QueryString["Id"];
        BGId = Convert.ToInt32(Request.QueryString["BGId"]);

        lblMessage.Text = "";
        if (!IsPostBack)
        {
            this.FillGrid();
        }

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        int prevYear = 0;
        prevYear = (FinYearId - 1);
        double openingBalOfPrevYear = 0;
       // openingBalOfPrevYear = calbalbud.TotBalBudget_BG(BGId, CompId, prevYear, 0);

        string selectBudget = "select Sum(Hour) As Hour from tblACC_Budget_Dept_Time where BudgetCodeId='" + Code + "'  and  BGGroup='" + BGId + "' And FinYearId=" + FinYearId + "  group by  BudgetCodeId ";

        SqlCommand cmdBD = new SqlCommand(selectBudget, con);
        SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
        DataSet dsBD = new DataSet();
        daBD.Fill(dsBD, "tblACC_Budget_Dept_Time");
        if (dsBD.Tables[0].Rows.Count > 0)
        {
          //  TotalHr = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["Hour"]) + openingBalOfPrevYear), 2);

            TotalHr = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["Hour"])), 2);


        }
        else
        {
            TotalHr = openingBalOfPrevYear;
        }
        UsedHr = Math.Round(Convert.ToDouble(CUH.TotFillPart(Convert.ToInt32(Code), "", BGId,CompId, FinYearId,0)), 2);
        BalHr = Math.Round((TotalHr - UsedHr), 2);

        lblTotalHr.Text = TotalHr.ToString();
        lblUsedHr.Text = UsedHr.ToString();
        lblBalHr.Text = BalHr.ToString();
    }

    public void FillGrid()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {

            string dept = "Select Name,Symbol from BusinessGroup where Id='" + BGId + "'";
            SqlCommand cmddept = new SqlCommand(dept, con);
            SqlDataAdapter dadept = new SqlDataAdapter(cmddept);
            DataSet dsdept = new DataSet();
            dadept.Fill(dsdept);
            lbldept.Text = dsdept.Tables[0].Rows[0]["Name"].ToString();

            string sel = "Select tblACC_Budget_Dept_Time.Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-',tblACC_Budget_Dept_Time.SysDate ) + 1, 2) + '-' + LEFT (tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-', tblACC_Budget_Dept_Time.SysDate ) - 1) + '-' + RIGHT (tblACC_Budget_Dept_Time.SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_Dept_Time.SysDate )) - 1)), 103), '/', '-') AS SysDate,tblACC_Budget_Dept_Time.SysTime, tblHR_Grade.Description,tblHR_Grade.Symbol,tblACC_Budget_Dept_Time.Hour from  tblACC_Budget_Dept_Time ,tblHR_Grade where tblHR_Grade.Id=tblACC_Budget_Dept_Time.BudgetCodeId and tblACC_Budget_Dept_Time.BGGroup='" + BGId + "'  and tblACC_Budget_Dept_Time.BudgetCodeId='" + Code + "' order by Id Desc ";
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
                Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?ModId=14");
            }
            lblCode.Text = String.Concat(ds.Tables[0].Rows[0]["Symbol"].ToString(), dsdept.Tables[0].Rows[0]["Symbol"].ToString());

        }
        catch (Exception ex)
        {
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
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {

             CDate = fun.getCurrDate();
             CTime = fun.getCurrTime();


            con.Open();

            double TUPHR = 0;
            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    TUPHR += Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
                }
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == false)
                {
                    TUPHR += Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text), 2);
                }
            }
            double x = 0;
            x = Math.Round((TUPHR - UsedHr), 2);
            int y = 0;
            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    double Amt = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
                    int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    if (Amt > 0)
                    {
                        if (x >= 0)
                        {
                            string update = ("Update tblACC_Budget_Dept_Time  set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "' ,Hour='" + Amt + "'  where Id='" + id + "' ");

                            SqlCommand cmd = new SqlCommand(update, con);
                            cmd.ExecuteNonQuery();
                            lblMessage.Text = "Record Updated";
                            y++;
                        }
                        else
                        {
                            string myStringVariable = string.Empty;
                            myStringVariable = "Only " + BalHr + " hours are Balanced";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                        }
                    }
                }

            }
            if (y > 0)
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
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
            Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?BGId=" + deptid + "&ModId=14");
        }
        catch (Exception ex)
        {
        }


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

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        try
        {
            if (e.CommandName == "del")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                double Hrs = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text);
                if (BalHr >= Hrs)
                {
                    string delete = ("Delete from tblACC_Budget_Dept_Time where  Id='" + id + "'");
                    SqlCommand cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "You can not delete this record, Because  hours are " + BalHr + " only.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
            }
        }
        catch (Exception ex) { }
    }
}

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

public partial class Module_Accounts_Transactions_Budget_WONo_Details_Time : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    Cal_Used_Hours CUH = new Cal_Used_Hours();

    int CompId = 0;
    int FinYearId = 0;
    string Id = string.Empty;
    string wono= string.Empty;
    double TotalHr = 0;
    double UsedHr = 0;
    double BalHr = 0;
    string CDate = string.Empty;
    string CTime =string.Empty;
    string sId =string.Empty;
    string AllocHrs = string.Empty;
    string UtilHrs = string.Empty;
    string BalHrs = string.Empty;
    string EquipId = string.Empty;
    string CatId = string.Empty;
    string SubCatId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {       
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        sId = Session["username"].ToString();       
        wono = Request.QueryString["WONo"];
        EquipId = Request.QueryString["Eqid"];
        AllocHrs = Request.QueryString["AllocHrs"];
        UtilHrs = Request.QueryString["UtilHrs"];
        BalHrs = Request.QueryString["BalHrs"];
        CatId = Request.QueryString["Cat"];
        SubCatId = Request.QueryString["SubCat"];

        lblWONo.Text = wono;
        lblMessage.Text = "";

        lblTotalHr.Text = AllocHrs.ToString();
        lblUsedHr.Text = UtilHrs.ToString();
        lblBalHr.Text = BalHrs.ToString();

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            if (!IsPostBack)
            {
                this.FillGrid();
            }
            
            con.Open();

            string selHrsBudget = "SELECT tblMIS_BudgetHrs_Field_SubCategory.SubCategory, tblMIS_BudgetHrs_Field_Category.Category, tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc FROM tblMIS_BudgetHrs_Field_Category INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId INNER JOIN  tblACC_Budget_WO_Time ON tblMIS_BudgetHrs_Field_SubCategory.Id = tblACC_Budget_WO_Time.HrsBudgetSubCat AND tblMIS_BudgetHrs_Field_Category.Id = tblACC_Budget_WO_Time.HrsBudgetCat INNER JOIN tblDG_Item_Master ON tblACC_Budget_WO_Time.EquipId = tblDG_Item_Master.Id AND tblACC_Budget_WO_Time.WONo='" + wono + "' AND tblACC_Budget_WO_Time.HrsBudgetCat='" + CatId + "' AND tblACC_Budget_WO_Time.HrsBudgetSubCat='" + SubCatId + "' AND tblACC_Budget_WO_Time.EquipId='" + EquipId + "'";
            SqlCommand cmdselHrsBudget = new SqlCommand(selHrsBudget, con);
            SqlDataReader DSselHrsBudget = cmdselHrsBudget.ExecuteReader();
            DSselHrsBudget.Read();

            lblEquipNo.Text = DSselHrsBudget["ItemCode"].ToString();
            lblDesc.Text = DSselHrsBudget["ManfDesc"].ToString();
            lblCate.Text = DSselHrsBudget["Category"].ToString();
            lblSubCate.Text = DSselHrsBudget["SubCategory"].ToString();

            //int prevYear = 0;
            //prevYear = (FinYearId - 1);

            //double openingBalOfPrevYear = 0;
            //openingBalOfPrevYear = calbalbud.TotBalBudget_WONO(Convert.ToInt32(Code), CompId, prevYear, wono, 0);
            //string selectBudget = "select Sum(Hour) As hours from tblACC_Budget_WO_Time where BudgetCodeId='" + Code + "' and WONo='" + wono + "' And FinYearId=" + FinYearId + " group by BudgetCodeId";
            //SqlCommand cmdBD = new SqlCommand(selectBudget, con);
            //SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
            //DataSet dsBD = new DataSet();
            //daBD.Fill(dsBD);

            //if (dsBD.Tables[0].Rows.Count > 0)
            //{
            //    TotalHr = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["hours"]) + openingBalOfPrevYear), 2);
            //}
            //else
            //{
            //    TotalHr = openingBalOfPrevYear;
            //}

            //UsedHr = Math.Round(Convert.ToDouble(CUH.TotFillPart(Convert.ToInt32(Code), wono, 0,CompId,FinYearId,0)), 2);
            //BalHr = Math.Round((TotalHr - UsedHr), 2);        

        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    public void FillGrid()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            con.Open();

            string sel = "Select Id,REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(SysDate , CHARINDEX('-',SysDate ) + 1, 2) + '-' + LEFT (SysDate , CHARINDEX('-', SysDate ) - 1) + '-' + RIGHT (SysDate , CHARINDEX('-', REVERSE(tblACC_Budget_WO_Time.SysDate )) - 1)), 103), '/', '-') AS SysDate,SysTime, Hour  from  tblACC_Budget_WO_Time where WONo='" + wono + "' AND HrsBudgetCat='" + CatId + "' AND HrsBudgetSubCat='" + SubCatId + "' AND EquipId='" + EquipId + "'";
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
        }
        catch (Exception ex) { }
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

    //protected void BtnUpdate_Click(object sender, EventArgs e)
    //{
    //    string connStr = fun.Connection();
    //    SqlConnection con = new SqlConnection(connStr);
    //   //try
    //    {
    //        CDate = fun.getCurrDate();
    //        CTime = fun.getCurrTime();

    //        con.Open();

    //        double TUPHR = 0;
    //        foreach (GridViewRow grv in GridView2.Rows)
    //        {
    //            if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
    //            {
    //                TUPHR += Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
    //            }
    //            if (((CheckBox)grv.FindControl("CheckBox1")).Checked == false)
    //            {
    //                TUPHR += Math.Round(Convert.ToDouble(((Label)grv.FindControl("lblAmount")).Text), 2);
    //            }
    //        }
    //        double x = 0;
    //        x = Math.Round((TUPHR - UsedHr), 2);
    //        int y = 0;
    //        foreach (GridViewRow grv in GridView2.Rows)
    //        {
    //            if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
    //            {
    //                double Amt = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
    //                int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

    //                if (Amt > 0)
    //                {
    //                    if (x >= 0)
    //                    {
    //                        string update = ("Update tblACC_Budget_WO_Time set SysDate='" + CDate + "'  ,SysTime='" + CTime + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',SessionId='" + sId + "' ,Hour='" + Amt + "'  where Id='" + id + "' ");

    //                        SqlCommand cmd = new SqlCommand(update, con);
    //                        cmd.ExecuteNonQuery();
    //                        lblMessage.Text = "Record Updated";
    //                        y++;
    //                    }
    //                    else
    //                    {
    //                        string myStringVariable = string.Empty;
    //                        myStringVariable = "Only " + BalHr + " hours are Balanced";
    //                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    //                    }
    //                }
    //            }
    //        }
    //        if (y > 0)
    //        {
    //            Page.Response.Redirect(Page.Request.Url.ToString(), true);
    //        }
    //    }

    //    //catch (Exception ex)
    //    {
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();

            con.Open();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    double Hrs = 0;
                    Hrs = Math.Round(Convert.ToDouble(((TextBox)grv.FindControl("TxtAmount")).Text), 2);
                   
                    int id = 0;
                    id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    //if (Hrs > 0)
                    {
                        string update = ("Update tblACC_Budget_WO_Time set SysDate='" + CDate + "', SysTime='" + CTime + "',SessionId='" + sId + "' ,Hour='" + Hrs + "' where Id='" + id + "' ");

                        SqlCommand cmd = new SqlCommand(update, con);
                        cmd.ExecuteNonQuery();
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

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        string wono = Request.QueryString["WONo"];
        Response.Redirect("~/Module/MIS/Transactions/Budget_WONo_Time.aspx?WONo=" + wono + "");
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
                int recid = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
               
                //double Hrs = Convert.ToDouble(((TextBox)row.FindControl("TxtAmount")).Text);
                
                //if (BalHr >= Hrs)
                {
                    string delete = fun.delete("tblACC_Budget_WO_Time", "Id='" + recid + "'");
                    SqlCommand cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();

                    string sel = fun.select("*", "tblACC_Budget_WO_Time", "WONo='" + wono + "' AND HrsBudgetCat='" + CatId + "' AND HrsBudgetSubCat='" + SubCatId + "' AND EquipId='"+EquipId+"'");
                    SqlCommand cmdck = new SqlCommand(sel, con);
                    SqlDataReader DS = cmdck.ExecuteReader();
                    DS.Read();

                    if (DS.HasRows == true)
                    {
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        Response.Redirect("~/Module/MIS/Transactions/Budget_WONo_Time.aspx?WONo=" + wono + "&ModId=14");                        
                    }
                }
                //else
                //{
                //    string myStringVariable = string.Empty;
                //    myStringVariable = "You can not delete this record, Because  hours are " + BalHr + " only.";
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                //}
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


}

    


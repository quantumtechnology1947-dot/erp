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

public partial class Module_SysAdmin_FinancialYear_FinYear_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    int Company = 0;
    string finYr = "";
    string finFrm = "";
    string finDt = "";
    string msg = "";
    string sId = "";
    string CDate = "";
    string CTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
           
            lblmsg.Text = "";
            if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                lblmsg.Text = Request.QueryString["msg"];
               
            }
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);           
            sId = Session["username"].ToString();            
            DateTime dd = DateTime.Now;
            CDate = dd.ToString("yyyy-MM-dd");
            DateTime dt = DateTime.Now;
            CTime = dt.ToString("T");
            if (!String.IsNullOrEmpty(Request.QueryString["finyear"]))
            {
                finYr = Request.QueryString["finyear"].ToString();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["fd"]))
            {
                finFrm = Request.QueryString["fd"].ToString();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["td"]))
            {
                finDt = Request.QueryString["td"].ToString();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["comp"]))
            {
                Company = Convert.ToInt32(Request.QueryString["comp"]);
                
            }

            lblFrmDt.Text = fun.FromDateDMY(finFrm.ToString());
            lblToDt.Text = fun.FromDateDMY(finDt.ToString());
            lblcompNm.Text = fun.getCompany(Company);
            lblfyear.Text = finYr;
        }

        catch (Exception ex)
        {
        }
        finally { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinYrs_New.aspx?ModId=1&SubModId=1");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            con.Open();
            int k = 0;
            string cmdstr1 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + Company + "' and FinYear='" + finYr + "'");           
            SqlCommand cmd2 = new SqlCommand(cmdstr1, con);
            DataSet DS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(DS, "tblFinancial_master");
            if (DS.Tables[0].Rows.Count > 0)
            {
                msg = "Selected financial year already exists.";
                k++;

            }
            else
            {

                if (finFrm != "" && finDt != "")
                {
                    string cmdstr = fun.insert("tblFinancial_master", "SysDate,SysTime,SessionId,CompId,FinYearFrom,FinYearTo,FinYear", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + Company + "','" + finFrm.ToString() + "','" + finDt.ToString() + "','" + finYr.ToString() + "'");
                    SqlCommand cmd = new SqlCommand(cmdstr, con);
                    cmd.ExecuteNonQuery();                    
                    this.shiftQty();
                    msg = "Financial year is entered successfully.";
                    k++;
                }
            }
            if (k > 0)
            {
                Page.Response.Redirect("FinYear_New_Details.aspx?msg=" + msg + "&fd=" + finFrm + "&td=" + finDt + "&finyear=" + finYr + "&comp=" + Company + "&ModId=1&SubModId=1");
            }
            else
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }

        catch (Exception ex) { }

        finally
        {
            con.Close();
        }
    }

    /// <summary>
    /// Shifting of old data to clone table, closing qty to opening qty & new opening date.
    /// </summary>
    
    public void shiftQty()
    {
        try
        {
            int FinAcc = 0;
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            //Copy old data to clone.
            string StrOpBalQty = fun.select("Id,StockQty,FinYearId,OpeningBalDate,OpeningBalQty", "tblDG_Item_Master", "CompId='" + CompId + "'");
            SqlCommand cmdOpBalQty = new SqlCommand(StrOpBalQty, con);
            DataSet DSOpBalQty = new DataSet();
            SqlDataAdapter DAOpBalQty = new SqlDataAdapter(cmdOpBalQty);
            DAOpBalQty.Fill(DSOpBalQty, "tblFinancial_master");

            for (int k = 0; k < DSOpBalQty.Tables[0].Rows.Count; k++)
            {
                string StrInsert = fun.insert("tblDG_Item_Master_Clone", "SysDate,SysTime,SessionId,CompId,FinYearId,ItemId,StockQty,OpeningQty,OpeningDate", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId+ "','" + Convert.ToInt32(DSOpBalQty.Tables[0].Rows[k]["Id"]) + "','" + Convert.ToDouble(DSOpBalQty.Tables[0].Rows[k]["StockQty"]) + "','" + Convert.ToDouble(DSOpBalQty.Tables[0].Rows[k]["OpeningBalQty"]) + "','" + DSOpBalQty.Tables[0].Rows[k]["OpeningBalDate"].ToString() + "'");

                SqlCommand cmdInsert = new SqlCommand(StrInsert, con);
                con.Open();
                cmdInsert.ExecuteNonQuery();
                con.Close();
            }

            // update balance qty & date in Item Master
            string STRUpdate = fun.update("tblDG_Item_Master", "OpeningBalQty=StockQty,OpeningBalDate='" + CDate + "'", "CompId='" + CompId + "'");
            SqlCommand cmdUpdate = new SqlCommand(STRUpdate, con);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();
           
            // to  carry forward Acess to each user for next year
            string StrAcc = fun.select("FinYearId", "tblFinancial_master", "CompId='" + Company + "'Order By FinYearId Desc");

            SqlCommand cmdAcc = new SqlCommand(StrAcc, con);
            DataSet DSAcc = new DataSet();
            SqlDataAdapter daAcc = new SqlDataAdapter(cmdAcc);
            daAcc.Fill(DSAcc, "tblFinancial_master");
            if (DSAcc.Tables[0].Rows.Count > 0)
            {

                FinAcc = Convert.ToInt32(DSAcc.Tables[0].Rows[0]["FinYearId"]);               
            }
            // To get Acess record to asign in next year

            string StrGetAcc = fun.select("*", "tblAccess_Master", "CompId='" + Company + "' AND FinYearId='" + FinYearId + "'");

            SqlCommand cmdGetAcc = new SqlCommand(StrGetAcc, con);
            DataSet DSGetAcc = new DataSet();
            SqlDataAdapter daGetAcc = new SqlDataAdapter(cmdGetAcc);
            daGetAcc.Fill(DSGetAcc, "tblFinancial_master");
            if (DSGetAcc.Tables[0].Rows.Count > 0)
            {

                for (int k = 0; k < DSGetAcc.Tables[0].Rows.Count;k++ )
                {
                    string StrAccInsert = fun.insert("tblAccess_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,ModId,SubModId,AccessType,Access", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinAcc + "','" + DSGetAcc.Tables[0].Rows[k]["EmpId"].ToString() + "','" + Convert.ToInt32(DSGetAcc.Tables[0].Rows[k]["ModId"]) + "','" + Convert.ToInt32(DSGetAcc.Tables[0].Rows[k]["SubModId"]) + "','" + Convert.ToInt32(DSGetAcc.Tables[0].Rows[k]["AccessType"]) + "','" + Convert.ToInt32(DSGetAcc.Tables[0].Rows[k]["Access"]) + "'");

                    SqlCommand cmdAccInsert = new SqlCommand(StrAccInsert, con);
                    con.Open();
                    cmdAccInsert.ExecuteNonQuery();
                    con.Close();
                   
                }

            }
            // update New,Edit,Delete,Print in tblAccess Master
            string AccMUpdate = fun.update("tblAccess_Master", "Access=0", " Access!=4  AND  CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
            SqlCommand cmdAccMUpdate = new SqlCommand(AccMUpdate, con);
            con.Open();
            cmdAccMUpdate.ExecuteNonQuery();
            con.Close();
        }

        catch (Exception ex)
        { }
    }

}

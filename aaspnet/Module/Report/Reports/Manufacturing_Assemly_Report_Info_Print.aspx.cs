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


public partial class ChallanInfo : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    string pr = "";
    string emp = "";
    string FyId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FyId = Session["finyear"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            if (!IsPostBack)
            {
                this.makegrid(pr, emp);
            }
        }
        catch (Exception ex) { }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView2.PageIndex = e.NewPageIndex;
        this.makegrid(pr, emp);
    }
    //protected void TreasureAmountold_CrystalReport_click(object sender, EventArgs ex)
    //{
    //    Response.Redirect("ChallanPrint.aspx");
    //}

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        Response.Redirect("Manufacturing_Assemly_Report_Print_Detail.aspx?AssemlyNo=" + e.CommandArgument);
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
            string getRandomKey = fun.GetRandomAlphaNumeric();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string PRJCTNO = ((Label)row.FindControl("lblPRNo")).Text;
            string Id = ((Label)row.FindControl("lblId")).Text;

            Response.Redirect("Manufacturing_Assemly_Report_Print_Detail.aspx?AssemlyNo=" + e.CommandArgument);

        
    }

    public void makegrid(string prno, string empid)
    {

        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("AssemlyNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            DataRow dr;

            string x = "";

           
            string y = "";


            string sql = fun.select("Id,SessionId,AssemlyNo,WONo,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblPM_Project_Manufacturing_Assemly_Master.SysDate, CHARINDEX('-', tblPM_Project_Manufacturing_Assemly_Master.SysDate) + 1, 2) + '-' + LEFT(tblPM_Project_Manufacturing_Assemly_Master.SysDate,CHARINDEX('-', tblPM_Project_Manufacturing_Assemly_Master.SysDate) - 1) + '-' + RIGHT(tblPM_Project_Manufacturing_Assemly_Master.SysDate, CHARINDEX('-', REVERSE(tblPM_Project_Manufacturing_Assemly_Master.SysDate)) - 1)), 103), '/', '-') AS SysDate,SysTime AS Time", "tblPM_Project_Manufacturing_Assemly_Master", " FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + x + y + "Order by Id Desc");

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND  EmpId='" + DS.Tables[0].Rows[p]["SessionId"] + "'");

                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DS.Tables[0].Rows[p]["AssemlyNo"].ToString();
                    dr[1] = DS.Tables[0].Rows[p]["SysDate"].ToString();
                    dr[2] = DS.Tables[0].Rows[p]["Time"].ToString();
                    dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();
                    dr[4] = DS.Tables[0].Rows[p]["Id"].ToString();
                    

                    string stryr = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND  FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'");
                    SqlCommand cmdyr = new SqlCommand(stryr, con);
                    SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                    DataSet DSyr = new DataSet();
                    dayr.Fill(DSyr);

                    if (DSyr.Tables[0].Rows.Count > 0)
                    {
                        dr[5] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                    }
                    dr[6] = DS.Tables[0].Rows[p]["WONo"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        catch (Exception ex) { }

    }




}
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

public partial class Module_MaterialManagement_Transactions_SPR_Dashboard : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    string spr = "";
    string emp = "";
    string FyId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            FyId = Session["finyear"].ToString();

            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();

            if (!IsPostBack)
            {
                txtSprNo.Visible = false;
                this.makegrid(spr, emp);
                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string delsql = fun.delete("tblMM_SPR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                cmd12.ExecuteNonQuery();
                con.Close();
            }
        }
       catch (Exception ex){}
    }

    public void makegrid(string sprno, string empid)
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str); 
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtSprNo.Text!= "")
                {
                    x = " AND SPRNo='" + txtSprNo.Text + "'";
                }
            }
            string y = "";
            if (drpfield.SelectedValue == "0")
            {
                if (txtEmpName.Text != "")
                {
                    y = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
                }
            }

            string sql = fun.select("*", "tblMM_SPR_Master", "   FinYearId<='" + FyId + "' And   CompId='" + CompId + "'" + x + y + " AND Authorize='0' Order by Id Desc");
           
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);          

            dt.Columns.Add(new System.Data.DataColumn("SPRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CheckedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ApprovedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
           
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            { 
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = DS.Tables[0].Rows[p]["SPRNo"].ToString();
                dr[1] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString());
                dr[2] = DS.Tables[0].Rows[p]["SysTime"].ToString();

                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS.Tables[0].Rows[p]["SessionId"] + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);
                if (DS2.Tables[0].Rows.Count > 0)
                {
                    dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Checked"]) == 1)
                {
                    dr[4] = fun.FromDateDMY(DS.Tables[0].Rows[p]["CheckedDate"].ToString());
                }
                else
                {
                    dr[4] = "NO";
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                {
                    dr[5] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                }
                else
                {
                    dr[5] = "NO";
                }

               // if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                //{
                //    dr[6] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                //}
                //else
                //{
                //    dr[6] = "NO";
                //}

                dr[7] = DS.Tables[0].Rows[p]["Id"].ToString(); ;
                string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'  And CompId='"+CompId+"'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[8] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();
        }
        catch (Exception ess)
        {

        }
    }

    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpfield.SelectedValue == "1")
        {
            txtSprNo.Visible = true;
            txtSprNo.Text = "";
            txtEmpName.Visible = false;
            this.makegrid(spr, emp);
        }
        else
        {
            txtSprNo.Visible = false;
            txtEmpName.Visible = true;
            txtEmpName.Text = "";
            this.makegrid(spr, emp);
        }
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId1 = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId1 + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.makegrid(txtSprNo.Text, txtEmpName.Text);
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
         this.makegrid(spr, emp);
    }


    
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "view")
            {
                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string getRandomKey = fun.GetRandomAlphaNumeric();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string SPRcode = ((Label)row.FindControl("lblsprno")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;
                Response.Redirect("SPR_Print_Details.aspx?SPRNo=" + SPRcode + "&Id=" + Id + "&Key=" + getRandomKey + "&ModId=6&SubModId=31&f=1");
            }
        }
        catch (Exception ex) { }
       
    }
}

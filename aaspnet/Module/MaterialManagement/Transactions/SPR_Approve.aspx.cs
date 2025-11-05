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

public partial class Module_MaterialManagement_Transactions_SPR_Approve : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                txtSprNo.Visible = false;
                this.makegrid(spr, emp);
            }
        }
        catch(Exception ex)
        {
        }
    }

    public void makegrid(string sprno, string empid)
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("SPRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CheckedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ApprovedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));

            DataRow dr;

            CompId = Convert.ToInt32(Session["compid"]);

            string x = "";

            if (drpfield.SelectedValue == "1")
            {
                if (txtSprNo.Text != "")
                {
                    x = " AND SPRNo='" + txtSprNo.Text + "'";
                }
            }
            string y = "";
            if (drpfield.SelectedValue == "0" && txtEmpName.Text != "")
            {
                y = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
            }

            string sql = fun.select("*", "tblMM_SPR_Master", "FinYearId<='" + FyId + "' And  CompId='" + CompId + "' AND Checked='1'" + x + y + " AND Authorize='0' Order by Id Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();



                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + DS.Tables[0].Rows[p]["SessionId"].ToString() + "'  " );
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DS.Tables[0].Rows[p]["SPRNo"].ToString();
                    dr[1] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString());
                    dr[2] = DS.Tables[0].Rows[p]["SysTime"].ToString();

                    dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();

                    if (Convert.ToInt32(DS.Tables[0].Rows[p]["Checked"]) == 1)
                    {
                        dr[4] = fun.FromDateDMY(DS.Tables[0].Rows[p]["CheckedDate"].ToString());
                    }

                    if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                    {
                        dr[5] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                    }

                    if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                    {
                        dr[6] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                    }

                    dr[7] = DS.Tables[0].Rows[p]["Id"].ToString();

                    string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'  AND CompId='"+CompId+"'");
                    SqlCommand cmdyr = new SqlCommand(stryr, con);
                    SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                    DataSet DSyr = new DataSet();
                    dayr.Fill(DSyr);

                    if (DSyr.Tables[0].Rows.Count > 0)
                    {
                        dr[8] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                    }

                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((Label)grv.FindControl("lblApproved")).Text != "")
                {
                    CheckBox chk = (CheckBox)grv.FindControl("CK");
                    chk.Visible = false;
                }
            }

            con.Close();
        }
        catch (Exception ess)
        {

        }
    }

    string parentPage = "SPR_Approve.aspx";

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       try
        {
            
            if (e.CommandName == "view")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string getRandomKey = fun.GetRandomAlphaNumeric();
                Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_View_Print.aspx?ModId=6&SubModId=31&Id=" + ((Label)row.FindControl("lblId")).Text + "&SPRNo=" + ((Label)row.FindControl("lblsprno")).Text + "&Key=" + getRandomKey + "&parentpage=" + parentPage);
               
            }

            
        }
       catch (Exception es)
        {

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        this.makegrid(txtSprNo.Text, txtEmpName.Text);
    }
    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
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

        catch(Exception ex){}
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

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.makegrid(spr, emp);
    }

    protected void App_Click(object sender, EventArgs e)
    {
       try
        {

            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            int i = 0;

            foreach (GridViewRow grv in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)grv.FindControl("CK");

                if (chk.Checked == true)
                {
                    string str = fun.Connection();
                    SqlConnection con = new SqlConnection(str);
                    con.Open();

                    string sprno = ((Label)grv.FindControl("lblsprno")).Text;
                    string id = ((Label)grv.FindControl("lblId")).Text;

                    //New line

                    string sql3 = fun.update("tblMM_SPR_Master", "Authorize='1',AuthorizedBy='" + sId + "',AuthorizeDate='" + CDate + "',AuthorizeTime='" + CTime + "'", "CompId='" + CompId + "' AND SPRNo='" + sprno + "'  AND Id='" + id + "'");

                    //End

                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    i++;
                }
            }

            if (i > 0)
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                string mystring = string.Empty;
                mystring = "No record is found to approved.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception es)
        {

        }
    }


}

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
using System.Collections.Generic;

public partial class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Edit : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    string connStr = "";
    string sid = "";
    int CompId = 0;
    int FinYearId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sid = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);

            connStr = fun.Connection();
            DataSet ds = new DataSet();
            con = new SqlConnection(connStr);

            if (!Page.IsPostBack)
            {
                this.loaddata();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void loaddata()
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);

            string x = "";
            if (drpfield.SelectedValue == "0")
            {
                if (txtSupplier.Text != "")
                {
                    string CustCode = fun.getCode(txtSupplier.Text);
                    x = " AND CustomerId='" + CustCode + "'";
                }
            }

            string y = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtPONo.Text != "")
                {
                    y = " AND WONo='" + txtPONo.Text + "'";
                }
            }

            if (drpfield.SelectedValue == "2")
            {
                if (txtPONo.Text != "")
                {
                    y = " AND TaskProjectTitle Like '%" + txtPONo.Text + "%'";
                }
            }

            string StrSql = fun.select("*", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND CloseOpen='0'" + x + y + " Order by WONo ASC");

            SqlCommand cmdwono = new SqlCommand(StrSql, con);
            SqlDataAdapter DAwono = new SqlDataAdapter(cmdwono);
            DataSet DSwono = new DataSet();
            DAwono.Fill(DSwono);
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("WOId", typeof(int)));//0
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));//1
            dt.Columns.Add(new System.Data.DataColumn("ProjectTitle", typeof(string)));//2
            dt.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));//3
            dt.Columns.Add(new System.Data.DataColumn("Code", typeof(string)));//4
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));//5

            DataRow dr;
            for (int i = 0; i < DSwono.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = Convert.ToInt32(DSwono.Tables[0].Rows[i]["Id"]);
                dr[1] = DSwono.Tables[0].Rows[i]["WONo"].ToString();
                dr[2] = DSwono.Tables[0].Rows[i]["TaskProjectTitle"].ToString();

                string StrCust = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + DSwono.Tables[0].Rows[i]["CustomerId"].ToString() + "'");

                SqlCommand cmdCust = new SqlCommand(StrCust, con);
                SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
                DataSet DSCust = new DataSet();
                daCust.Fill(DSCust);
                if (DSCust.Tables[0].Rows.Count > 0)
                {
                    dr[3] = DSCust.Tables[0].Rows[0]["CustomerName"].ToString();
                    dr[4] = DSCust.Tables[0].Rows[0]["CustomerId"].ToString();
                }
                dr[5] = fun.FromDate (DSwono.Tables[0].Rows[i]["SysDate"].ToString());
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex) { }

    }

    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpfield.SelectedValue == "0")
            {
                txtPONo.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.loaddata();
            }
            if (drpfield.SelectedValue == "1" || drpfield.SelectedValue == "2")
            {
                txtPONo.Visible = true;
                txtPONo.Text = "";
                txtSupplier.Visible = false;
                this.loaddata();
            }

        }
        catch (Exception ex) { }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.loaddata();
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "SD_Cust_master");
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


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.loaddata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "sel")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string woid = ((Label)row.FindControl("lblWOId")).Text;
            string wono = ((LinkButton)row.FindControl("lbtnWONo")).Text;
            Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_Edit_Details.aspx?WOId=" + woid + "&WONo=" + wono + "&ModId=7&SubModId=127");   
        }

    }
}

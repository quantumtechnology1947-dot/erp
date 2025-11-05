using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Module_DailyReportingSystem_Reports_Departmental_Working_Plan_Wo_Wise : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string CId = "";
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;
    string connStr = "";
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);

            if (!Page.IsPostBack)
            {
                this.BindDataCust(ID);
            }
        }
        catch (Exception ex) { }
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            string y = "";
            if (TxtSearchValue.Text != "")
            {
                this.BindDataCust(TxtSearchValue.Text);
            }
            else
            {
                this.BindDataCust(ID);
            }
        }

        catch (Exception ex)
        { }

    }
    public void BindDataCust(string ID)
    {
        try
        {

            DataTable dt = new DataTable();
            con.Open();
           // string x = "";
            if (TxtSearchValue.Text != "")
            {
               // string ID = fun.getCode(TxtSearchValue.Text);
               // x = " AND IdWo='" + ID + "'";
            }

            string StrCust = fun.select("Department,IdWo,IDperc,IdStatus,IdActivity,Idrmk,IdDate", "DRT_Sys_New", "Department='" + department.SelectedItem + "' AND IdWo='" + D_cat.SelectedItem + "' OR  E_name='" + D_cat.SelectedItem + "'OR IdDate='" + D_cat.SelectedItem + "'");

            SqlCommand cmdCust = new SqlCommand(StrCust, con);
            SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
            DataSet DSCust = new DataSet();
            daCust.Fill(DSCust);
            dt.Columns.Add(new System.Data.DataColumn("Department", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("IdWo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("IDperc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("IdStatus", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("IdActivity", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Idrmk", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("IdDate", typeof(string)));
           SearchGridView1.DataSource = dt;
            SearchGridView1.DataBind();
            con.Close();
        }

        catch (Exception ex)
        { }
    }
    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            SearchGridView1.PageIndex = e.NewPageIndex;
            this.BindDataCust(ID);
        }

        catch (Exception ex)
        { }

    }

    protected void department_SelectedIndexChanged(object sender, EventArgs e)
    {
        
           
            
                try
                {

                    DataTable dt1 = new DataTable();
                    con.Open();
                   
                    if (department.SelectedItem.Text != "")
                    {
                       
                   

                    string StrCust = fun.select("Department,IdWo,IDperc,IdStatus,IdActivity,Idrmk,IdDate", "DRT_Sys_New", "Department='" + department.SelectedItem.Text+ "'");

                    SqlCommand cmdCust = new SqlCommand(StrCust, con);
                    SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
                    DataSet DSCust = new DataSet();
                    daCust.Fill(DSCust);
                    dt1.Columns.Add(new System.Data.DataColumn("Department", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("IdWo", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("IDperc", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("IdStatus", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("IdActivity", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("Idrmk", typeof(string)));
                    dt1.Columns.Add(new System.Data.DataColumn("IdDate", typeof(string)));
                    SearchGridView1.DataSource = dt1;
                    SearchGridView1.DataBind();
                    con.Close();
                     }
                 }
        catch (Exception ex)
                { }
            }
           
        

        
    }

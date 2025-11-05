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

public partial class Module_Accounts_Transactions_ContraEntry : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    string Sid = string.Empty;
    int Cid = 0;
    int Fyid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            con = new SqlConnection(connStr);

            Sid = Session["username"].ToString();
            Cid = Convert.ToInt32(Session["compid"]);
            Fyid = Convert.ToInt32(Session["finyear"]);

            if (!IsPostBack)
            {
                this.fillgrid();                
               
            }


            
        }
        catch (Exception er) { }
    }
    public void fillgrid()
    {
        try
        {
            con.Open();
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Cr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Dr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amt", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Narr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CrId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DrId", typeof(string)));

            string sql = fun.select("*", "tblACC_Contra_Entry", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");
            SqlCommand cmdsql = new SqlCommand(sql, con);
            SqlDataAdapter dasql = new SqlDataAdapter(cmdsql);
            DataSet dssql = new DataSet();
            dasql.Fill(dssql);

            DataRow dr;

            for (int d = 0; d < dssql.Tables[0].Rows.Count; d++)
            {
                dr = dt.NewRow();

                dr[0] = dssql.Tables[0].Rows[d]["Id"].ToString();
                dr[1] =fun.FromDateDMY( dssql.Tables[0].Rows[d]["Date"].ToString());

                string sql2 = fun.select("*", "tblACC_Bank", "Id='" + dssql.Tables[0].Rows[d]["Cr"].ToString() + "'");
                SqlCommand cmdsql2 = new SqlCommand(sql2, con);
                SqlDataAdapter dasql2 = new SqlDataAdapter(cmdsql2);
                DataSet dssql2 = new DataSet();
                dasql2.Fill(dssql2);

                dr[2] = dssql2.Tables[0].Rows[0]["Name"].ToString();

                string sql3 = fun.select("*", "tblACC_Bank", "Id='" + dssql.Tables[0].Rows[d]["Dr"].ToString() + "'");
                SqlCommand cmdsql3 = new SqlCommand(sql3, con);
                SqlDataAdapter dasql3 = new SqlDataAdapter(cmdsql3);
                DataSet dssql3 = new DataSet();
                dasql3.Fill(dssql3);

                dr[3] = dssql3.Tables[0].Rows[0]["Name"].ToString();
                dr[4] = dssql.Tables[0].Rows[d]["Amount"].ToString();
                dr[5] = dssql.Tables[0].Rows[d]["Narration"].ToString();
                dr[6] = dssql.Tables[0].Rows[d]["Cr"].ToString();
                dr[7] = dssql.Tables[0].Rows[d]["Dr"].ToString();


                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                DropDownList y1 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr"));
                this.dropdownCrDr2(y1);
                DropDownList y = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListDr"));
                if (y1.SelectedItem.Text != "Select")
                {
                    int x = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr")).SelectedValue);
                    this.dropdownCrDr(y, x);
                }
                else
                {
                    y.Items.Insert(0, "Select");
                }
            }

            else
            {

                DropDownList y1 = ((DropDownList)GridView1.FooterRow.FindControl("DrpListCr"));
                this.dropdownCrDr2(y1);
                DropDownList y = ((DropDownList)GridView1.FooterRow.FindControl("DrpListDr"));
                if (y1.SelectedItem.Text != "Select")
                {
                    int x = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpListCr")).SelectedValue);
                    this.dropdownCrDr(y, x);
                }
                else
                {
                    y.Items.Insert(0, "Select");
                }
            }

            con.Close();

        }
        catch (Exception er) { }
    }
    public void dropdownCrDr(DropDownList DDLCrDr,int SelItem)
    {
        try
        {
            DataSet DS = new DataSet();
            string cmdStr = "";
            //if (SelItem == 4)
            {
                cmdStr = fun.select("*", "tblACC_Bank", "Id!='" + SelItem + "'");

            }
            //else
            {
               // cmdStr = fun.select("*", "tblACC_Bank", "Id='4'");
            }
            
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "tblACC_Bank");
            DDLCrDr.DataSource = DS.Tables["tblACC_Bank"];
            DDLCrDr.DataTextField = "Name";
            DDLCrDr.DataValueField = "Id";
            DDLCrDr.DataBind();
            //DDLCrDr.Items.Insert(0, "Select");

        }
        catch (Exception ex) { }

    }
    public void dropdownCrDr2(DropDownList DDLCr)
    {
        try
        {
            DataSet DS = new DataSet();
            string cmdStr = "";
            {
                cmdStr = fun.select1("*", "tblACC_Bank");
            }
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "tblACC_Bank");
            DDLCr.DataSource = DS.Tables["tblACC_Bank"];
            DDLCr.DataTextField = "Name";
            DDLCr.DataValueField = "Id";
            DDLCr.DataBind();
            DDLCr.Items.Insert(0, "Select");
        }
        catch (Exception ex) { }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string sysDate = fun.getCurrDate();
            string sysTime = fun.getCurrTime();

            if (e.CommandName == "Add")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string date = ((TextBox)row.FindControl("txtDate0")).Text;
                string Cr = ((DropDownList)row.FindControl("DrpListCr0")).SelectedValue;
                string Dr = ((DropDownList)row.FindControl("DrpListDr0")).SelectedValue;
                string Amt = ((TextBox)row.FindControl("txtAmt0")).Text;
                string Narr = ((TextBox)row.FindControl("txtNarr0")).Text;
                string SqlInsert = fun.insert("tblACC_Contra_Entry", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,Cr,Dr,Amount,Narration", "'" + sysDate + "','" + sysTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + fun.FromDate(date) + "','" + Cr + "','" + Dr + "','" + Amt + "','" + Narr + "'");
                SqlCommand cmd = new SqlCommand(SqlInsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            if (e.CommandName == "Add1")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string date = ((TextBox)row.FindControl("txtDate")).Text;
                string Cr = ((DropDownList)row.FindControl("DrpListCr")).SelectedValue;
                string Dr = ((DropDownList)row.FindControl("DrpListDr")).SelectedValue;
                string Amt = ((TextBox)row.FindControl("txtAmt")).Text;
                string Narr = ((TextBox)row.FindControl("txtNarr")).Text;
                if( ((DropDownList)row.FindControl("DrpListDr")).SelectedItem.Text!="Select")
                {
                string SqlInsert = fun.insert("tblACC_Contra_Entry", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,Cr,Dr,Amount,Narration", "'" + sysDate + "','" + sysTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + fun.FromDate(date) + "','" + Cr + "','" + Dr + "','" + Amt + "','" + Narr + "'");
                SqlCommand cmd = new SqlCommand(SqlInsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }

        catch (Exception er) { }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.fillgrid();
        }
        catch (Exception er) { }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.fillgrid();
            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
            ((DropDownList)row.FindControl("DrpListCr0")).SelectedValue = ((Label)row.FindControl("lblCr0")).Text;
            ((DropDownList)row.FindControl("DrpListDr0")).SelectedValue = ((Label)row.FindControl("lblDr0")).Text;
            DropDownList y1 = ((DropDownList)row.FindControl("DrpListCr0"));            
            DropDownList y = ((DropDownList)row.FindControl("DrpListDr0"));
            if (y1.SelectedItem.Text != "Select")
            {
                int x = Convert.ToInt32(((DropDownList)row.FindControl("DrpListCr0")).SelectedValue);
                this.dropdownCrDr(y, x);
            }
            else
            {
                y.Items.Insert(0, "Select");
            }           
        }
        catch (Exception er) { }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index1 = GridView1.EditIndex;
        GridViewRow row = GridView1.Rows[index1];
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        string date = ((TextBox)row.FindControl("txtDate0")).Text;
        string Cr = ((DropDownList)row.FindControl("DrpListCr0")).SelectedValue;
        string Dr = ((DropDownList)row.FindControl("DrpListDr0")).SelectedValue;
        string Amt = ((TextBox)row.FindControl("txtAmt0")).Text;
        string Narr = ((TextBox)row.FindControl("txtNarr0")).Text;

        if (date != "" && Amt != "")
        {
            string sql1 = fun.update("tblACC_Contra_Entry", "Date='" + date + "',Cr='" + Cr + "',Dr='" + Dr + "',Amount='" + Amt + "',Narration='" + Narr + "'", "Id=" + id1 + " And CompId='" + Cid + "'");
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            this.fillgrid();

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_Contra_Entry","Id='" + id + "' And CompId='" + Cid + "'"),con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();            
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception er) { }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.fillgrid();
    }
    protected void DrpListCr_SelectedIndexChanged(object sender, EventArgs e)
    {
       try
        {
        DropDownList y = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListDr"));        
        DropDownList y1 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr")); 
        if (y1.SelectedItem.Text == "Select")
        {
            y.Items.Clear();
            y.Items.Insert(0, "Select");
            y.SelectedValue = "Select";
        }
        else
        {
            int x = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr")).SelectedValue);
            this.dropdownCrDr(y, x);
        }
        }
        catch (Exception er) { }

    }
    protected void DrpListCrF_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList y = ((DropDownList)GridView1.FooterRow.FindControl("DrpListDr"));
            DropDownList y1 = ((DropDownList)GridView1.FooterRow.FindControl("DrpListCr"));
            if (y1.SelectedItem.Text == "Select")
            {
                y.Items.Clear();
                y.Items.Insert(0, "Select");
                y.SelectedValue = "Select";
            }
            else
            {
                int x = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpListCr")).SelectedValue);
                this.dropdownCrDr(y, x);
            }
        }
        catch (Exception er) { }

    }
    protected void DrpListCrE_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            int index1 = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index1];
            DropDownList y = ((DropDownList)row.FindControl("DrpListDr0"));
            DropDownList y1 = ((DropDownList)row.FindControl("DrpListCr0"));
            if (y1.SelectedItem.Text == "Select")
            {
                y.Items.Clear();
                y.Items.Insert(0, "Select");
                y.SelectedValue = "Select";
            }
            else
            {
                int x = Convert.ToInt32(((DropDownList)row.FindControl("DrpListCr0")).SelectedValue);
                this.dropdownCrDr(y, x);
            }
        }
        catch (Exception er) { }

    }

    
}

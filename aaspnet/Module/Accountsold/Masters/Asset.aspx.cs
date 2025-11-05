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

public partial class Module_Accounts_Masters_Asset : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
    
        lblMessage.Text = ""; 
        lblMessage1.Text = "";
    
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated.";
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        lblMessage.Text = "Record Deleted.";
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       try
        {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

            if (e.CommandName == "Add")
            {
                string strCategory = ((TextBox)GridView1.FooterRow.FindControl("txtCategory")).Text;
                string strAbbrivation = (((TextBox)GridView1.FooterRow.FindControl("txtAbbrivation")).Text).ToUpper();

                if (strCategory != "" && strAbbrivation != "")
                {
                    string sql = fun.select("Abbrivation", "tblACC_Asset_Category", " Abbrivation='" + strAbbrivation + "'");
                    SqlCommand cmd1 = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                    LocalSqlServer.InsertParameters["Category"].DefaultValue = strCategory;
                    LocalSqlServer.InsertParameters["Abbrivation"].DefaultValue = strAbbrivation;                 
                    LocalSqlServer.Insert();
                    lblMessage.Text = "Record Inserted.";
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {

                        string mystring = string.Empty;
                        mystring = "Category Abbrivation is already used.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }

            }
            else if (e.CommandName == "Add1")
            {
                string strCategory = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCate")).Text;
                string strAbbrivation = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbb")).Text).ToUpper();

                if (strCategory != "" && strAbbrivation != "")
                {

                    LocalSqlServer.InsertParameters["Category"].DefaultValue = strCategory;
                    LocalSqlServer.InsertParameters["Abbrivation"].DefaultValue = strAbbrivation;
                    LocalSqlServer.Insert();
                    lblMessage.Text = "Record Inserted.";
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }

        catch(Exception ex)
        {
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton edit = (LinkButton)e.Row.Cells[1].Controls[0];
                edit.Attributes.Add("onclick", "return confirmationUpdate();");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[2].Controls[0];
                del.Attributes.Add("onclick", "return confirmationDelete();");
            }
        }
       catch(Exception ex){}

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            int rowIndex = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[rowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string strCategory = ((TextBox)row.FindControl("txtCategory0")).Text;
            string strAbbrivation = (((TextBox)row.FindControl("txtAbbrivation0")).Text).ToUpper();

            if (strCategory != "" && strAbbrivation != "")
            {

                string sql1 = fun.select("Abbrivation", "tblACC_Asset_Category", " Abbrivation='" + strAbbrivation + "'");
                SqlCommand cmd11 = new SqlCommand(sql1, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd11);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    LocalSqlServer.UpdateParameters["Category"].DefaultValue = strCategory;
                    LocalSqlServer.UpdateParameters["Abbrivation"].DefaultValue = strAbbrivation;
                    LocalSqlServer.Update();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                  //  e.Cancel = true;
                    string mystring = string.Empty;
                    mystring = "Category Abbrivation is already used.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
        }
        catch (Exception ex) { }
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            if (e.CommandName == "Add_sb")
            {
                string StrCategory = ((DropDownList)GridView2.FooterRow.FindControl("ddCategory_sb")).SelectedValue;
                string strSubCategory = ((TextBox)GridView2.FooterRow.FindControl("txtSubCategory_sb0")).Text;
                string strAbbrivation = (((TextBox)GridView2.FooterRow.FindControl("txtAbbrivation_sb0")).Text).ToUpper();
                if (StrCategory != "1")
                {
                    if (strSubCategory != "" && strAbbrivation != "")
                    {
                        string sql1s = fun.select("Abbrivation", "tblACC_Asset_SubCategory", " Abbrivation='" + strAbbrivation + "'");
                        SqlCommand cmd11s = new SqlCommand(sql1s, con);
                        SqlDataAdapter da1s = new SqlDataAdapter(cmd11s);
                        DataSet ds1s = new DataSet();
                        da1s.Fill(ds1s);
                        if (ds1s.Tables[0].Rows.Count == 0)
                        {
                        SqlDataSource11.InsertParameters["MId"].DefaultValue = StrCategory;
                        SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = strSubCategory;
                        SqlDataSource11.InsertParameters["Abbrivation"].DefaultValue = strAbbrivation;
                        SqlDataSource11.Insert();
                        lblMessage1.Text = "Record Inserted.";
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Subcategory Abbrivation is already used.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }

                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Please select category.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            else if (e.CommandName == "Add_sb1")
            {
                string StrCategory = ((DropDownList)GridView2.Controls[0].Controls[0].FindControl("ddCategory_sb1")).SelectedValue;
                string strSubCategory = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtCate_sb1")).Text;
                string strAbbrivation = (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAbb_sb1")).Text).ToUpper();

                if (StrCategory != "1")
                {
                    if (strSubCategory != "" && strAbbrivation != "")
                    {
                       

                            SqlDataSource11.InsertParameters["MId"].DefaultValue = StrCategory;
                            SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = strSubCategory;
                            SqlDataSource11.InsertParameters["Abbrivation"].DefaultValue = strAbbrivation;
                            SqlDataSource11.Insert();
                            lblMessage1.Text = "Record Inserted.";
                            Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Please select category.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
        }

        catch (Exception ex)
        {
        }
    }
    protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        lblMessage1.Text = "Record Deleted.";
    }
    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage1.Text = "Record Updated.";
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            int rowIndex = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[rowIndex];
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);

            string StrCategory = ((DropDownList)row.FindControl("ddCategory_sbe")).SelectedValue;
            string strSubCategory = ((TextBox)row.FindControl("txtSubCategory_sb")).Text;
            string strAbbrivation = (((TextBox)row.FindControl("txtAbbrivation_sb")).Text).ToUpper();

            if (StrCategory != "1")
            {
                if (strSubCategory != "" && strAbbrivation != "")
                {
                    string sql4 = fun.select("Abbrivation", "tblACC_Asset_SubCategory", " Abbrivation='" + strAbbrivation + "'");
                    SqlCommand cmd4 = new SqlCommand(sql4, con);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    if (ds4.Tables[0].Rows.Count == 0)
                    {
                        SqlDataSource11.UpdateParameters["MId"].DefaultValue = StrCategory;
                        SqlDataSource11.UpdateParameters["SubCategory"].DefaultValue = strSubCategory;
                        SqlDataSource11.UpdateParameters["Abbrivation"].DefaultValue = strAbbrivation;
                        SqlDataSource11.Update();

                    }
                    else
                    {
                       // e.Cancel = true;
                        string mystring = string.Empty;
                        mystring = "Subcategory Abbrivation is already used.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }               
            }
            else
            {
                e.Cancel = true;
                string mystring = string.Empty;
                mystring = "Please select category.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception ex) { }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton edit = (LinkButton)e.Row.Cells[1].Controls[0];
                edit.Attributes.Add("onclick", "return confirmationUpdate();");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[2].Controls[0];
                del.Attributes.Add("onclick", "return confirmationDelete();");
            }
        }
        catch (Exception ex) { }
    }
}
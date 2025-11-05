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

public partial class Module_MIS_Transaction_BudgetHrsFields : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!Page.IsPostBack)
        {
            lblMessage.Text = "";
            lblMessage1.Text = "";
        }
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
                string strSymbol = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol")).Text;

                if (strCategory != "" && strSymbol != "")
                {
                    LocalSqlServer.InsertParameters["Category"].DefaultValue = strCategory;
                    LocalSqlServer.InsertParameters["Symbol"].DefaultValue = strSymbol;
                    LocalSqlServer.Insert();

                    lblMessage.Text = "Record Inserted.";
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            else if (e.CommandName == "Add1")
            {
                string strCategory = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtCate")).Text;
                string strSymbol = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
                if (strCategory != "" && strSymbol != "")
                {
                    LocalSqlServer.InsertParameters["Category"].DefaultValue = strCategory;
                    LocalSqlServer.InsertParameters["Symbol"].DefaultValue = strSymbol;
                    LocalSqlServer.Insert();
                    lblMessage.Text = "Record Inserted.";
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
            string strSymbol = ((TextBox)row.FindControl("txtSymbol0")).Text;

            if (strCategory != "" && strSymbol != "")
            {
                LocalSqlServer.UpdateParameters["Category"].DefaultValue = strCategory;
                LocalSqlServer.UpdateParameters["Symbol"].DefaultValue = strCategory;
                LocalSqlServer.Update();
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
                string strSymbol = ((TextBox)GridView2.FooterRow.FindControl("txtSymbol0")).Text;

                if (StrCategory != "1")
                {
                    if (strSubCategory != "")
                    {
                        SqlDataSource11.InsertParameters["MId"].DefaultValue = StrCategory;
                        SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = strSubCategory;
                        SqlDataSource11.InsertParameters["Symbol"].DefaultValue = strSymbol;
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
            else if (e.CommandName == "Add_sb1")
            {
                string StrCategory = ((DropDownList)GridView2.Controls[0].Controls[0].FindControl("ddCategory_sb1")).SelectedValue;
                string strSubCategory = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtCate_sb1")).Text;
                string strSymbol = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtSymbol1")).Text;

                if (StrCategory != "1")
                {
                    if (strSubCategory != "")
                    {
                        SqlDataSource11.InsertParameters["MId"].DefaultValue = StrCategory;
                        SqlDataSource11.InsertParameters["SubCategory"].DefaultValue = strSubCategory;
                        SqlDataSource11.InsertParameters["Symbol"].DefaultValue = strSymbol;
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
            string strSymbol = ((TextBox)row.FindControl("txtSymbol")).Text;

            if (StrCategory != "1")
            {
                if (strSubCategory != "")
                {
                    SqlDataSource11.UpdateParameters["MId"].DefaultValue = StrCategory;
                    SqlDataSource11.UpdateParameters["SubCategory"].DefaultValue = strSubCategory;
                    SqlDataSource11.UpdateParameters["SubSymbol"].DefaultValue = strSymbol;
                    SqlDataSource11.Update();
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

    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx?ModId=14&SubModId=");
    }

}
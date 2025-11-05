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

public partial class Module_Accounts_Masters_LoanType : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
    //   //if(!Page.IsPostBack)
    //{
        lblMessage.Text = "";
    //}

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
                string strDescription = ((TextBox)GridView1.FooterRow.FindControl("txtDescription1")).Text;

                if (strDescription != "")
                {

                    LocalSqlServer.InsertParameters["Description"].DefaultValue = strDescription;               
                    LocalSqlServer.Insert();
                    lblMessage.Text = "Record Inserted.";
                  
                }

            }
            else if (e.CommandName == "Add1")
            {
                string strDescription = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDescription")).Text;

                if (strDescription != "")
                {
                    LocalSqlServer.InsertParameters["Description"].DefaultValue = strDescription;
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

            string strDescription = ((TextBox)row.FindControl("txtDescription0")).Text;

            if (strDescription != "" )
            {

                LocalSqlServer.UpdateParameters["Description"].DefaultValue = strDescription;
                LocalSqlServer.Update();

            }
        }
       catch (Exception ex) { }
    }
}


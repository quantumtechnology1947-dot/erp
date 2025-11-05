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
public partial class Module_Accounts_Masters_AccHead : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    //if (((Label)row.FindControl("lblId")).Text == "19")
        //    {
        //        Response.Write(((Label)row.FindControl("lblId")).Text);
        //        //LinkButton del = (LinkButton)row.Cells[1].Controls[0];
        //        //LinkButton edt = (LinkButton)row.Cells[0].Controls[0];
        //        //del.Visible = false;
        //        //edt.Visible = false;
        //    }
        //}
        lblMessage.Text = "";
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        SqlDataSource1.Update();
        lblMessage.Text = "Record Updated";        
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
       lblMessage.Text = "Record Deleted";
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {


                string strCategory = ((DropDownList)GridView1.FooterRow.FindControl("ddCategory2")).SelectedValue;
                string strDesc = ((TextBox)GridView1.FooterRow.FindControl("txtDescription2")).Text;
                string strSymbol = ((TextBox)GridView1.FooterRow.FindControl("txtSymbo2")).Text;
                string strAbb = ((TextBox)GridView1.FooterRow.FindControl("txtAbbrivation2")).Text;

                if (strDesc != "" && strSymbol != "" && strAbb != "")
                {
                    SqlDataSource1.InsertParameters["Category"].DefaultValue = strCategory;
                    SqlDataSource1.InsertParameters["Description"].DefaultValue = strDesc;
                    SqlDataSource1.InsertParameters["Symbol"].DefaultValue = strSymbol;
                    SqlDataSource1.InsertParameters["Abbrivation"].DefaultValue = strAbb;
                    SqlDataSource1.Insert();
                    lblMessage.Text = "Record Inserted";

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);

                }
            }

            if (e.CommandName == "Add1")
            {
                string strCategory = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddCategory3")).SelectedValue;
                string strDesc = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDescription3")).Text;
                string strSymbol = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol3")).Text;
                string strAbb = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAbbrivation3")).Text;

                if (strDesc != "" && strSymbol != "" && strAbb != "")
                {
                    SqlDataSource1.InsertParameters["Category"].DefaultValue = strCategory;
                    SqlDataSource1.InsertParameters["Description"].DefaultValue = strDesc;
                    SqlDataSource1.InsertParameters["Symbol"].DefaultValue = strSymbol;
                    SqlDataSource1.InsertParameters["Abbrivation"].DefaultValue = strAbb;
                    SqlDataSource1.Insert();
                    lblMessage.Text = "Record Inserted";

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }

        catch (Exception er) { }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton edit = (LinkButton)e.Row.Cells[0].Controls[0];
                edit.Attributes.Add("onclick", "return confirmationUpdate();");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[1].Controls[0];
                del.Attributes.Add("onclick", "return confirmationDelete();");
            }


            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((Label)row.FindControl("lblId")).Text == "19" || ((Label)row.FindControl("lblId")).Text == "33")
                {
                   LinkButton del = (LinkButton)row.Cells[1].Controls[0];
                   LinkButton edt = (LinkButton)row.Cells[0].Controls[0];
                    del.Visible = false;
                    edt.Visible = false;
                }
            }
        }
         catch(Exception ex){}

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
   {
     try
      {
          string connStr = fun.Connection();
          DataSet ds = new DataSet();
          SqlConnection con = new SqlConnection(connStr);
          int rowIndex = GridView1.EditIndex;
          GridViewRow row = GridView1.Rows[rowIndex];
          int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
          DropDownList ddl = (DropDownList)row.FindControl("ddCategory1");
          string value = ddl.SelectedValue;
          string strCategory = value;

          string strDesc = ((TextBox)row.FindControl("txtDescription1")).Text;
          string strSymb = ((TextBox)row.FindControl("txtSymbol1")).Text;
          string strAbb = ((TextBox)row.FindControl("txtAbbrivation1")).Text;

          if (strDesc != "" && strSymb != "" && strAbb != "")
          {
              con.Open();
              string upd = "UPDATE AccHead SET Category='" + strCategory + "', Description = '" + strDesc + "', Symbol = '" + strSymb + "', Abbrivation = '" + strAbb + "' WHERE Id ='" + id + "'";
              SqlCommand cmd = new SqlCommand(upd, con);
              cmd.ExecuteNonQuery();
              con.Close();
          }
      }
        catch(Exception ex){}
  }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }


}


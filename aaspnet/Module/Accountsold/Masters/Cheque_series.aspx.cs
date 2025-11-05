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

public partial class Module_Accounts_Masters_Cheque_series : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.FillGrid();
        }

        lblMessage.Text = "";
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
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
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            if (e.CommandName == "Add")
            {
                int Bank = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpBank1")).SelectedValue);
                int StartNo = Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("txtStartNo1")).Text);
                int EndNo = Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("txtEndNo1")).Text);
                if (StartNo.ToString() != "" && EndNo.ToString() != "")
                {

                    string sqlsub = fun.insert("tblACC_ChequeNo", "BankId,StartNo,EndNo", "'" + Bank + "','" + StartNo + "','" + EndNo + "'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //lblMessage.Text = "Record Inserted";
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            if (e.CommandName == "Add1")
            {
                int Bank =Convert.ToInt32( ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpBank2")).SelectedValue);
                int StartNo =Convert.ToInt32( ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtStartNo3")).Text);
                int EndNo =Convert.ToInt32( ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtEndNo3")).Text);
                if (StartNo.ToString() != "" && EndNo.ToString() != "")
                {

                    string sqlsub = fun.insert("tblACC_ChequeNo", "BankId,StartNo,EndNo", "'" + Bank + "','" + StartNo + "','" + EndNo + "'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //lblMessage.Text = "Record Inserted";
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        catch (Exception ex) { }

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
        }
        catch (Exception ex) { }
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
            int Bank = Convert.ToInt32(((DropDownList)row.FindControl("DrpBank")).SelectedValue);
            int StartNo = Convert.ToInt32(((TextBox)row.FindControl("txtStartNo")).Text);
            int EndNo =Convert.ToInt32( ((TextBox)row.FindControl("txtEndNo")).Text);

            if (StartNo.ToString() != "" && EndNo.ToString() != "" )
            {
                con.Open();
                string upd = "UPDATE tblACC_ChequeNo SET BankId ='" + Bank + "',StartNo='" + StartNo + "',EndNo='" + EndNo + "' WHERE Id ='" + id + "'";
               
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
           Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception ex) { }

    }
   
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_ChequeNo", "Id='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception er) { }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.FillGrid();
            int index = GridView1.EditIndex;
            GridViewRow grv = GridView1.Rows[index];
            DropDownList drpcountry = grv.FindControl("DrpBank") as DropDownList;

            string CountryId = ((Label)grv.FindControl("lblBankId")).Text;           
            drpcountry.SelectedValue = CountryId;
           
        }
      catch (Exception er) { }
    }
    public void FillGrid()
    {
         try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter da = new SqlDataAdapter("[GetChequeNo]", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView1.DataSource = DSitem;
            GridView1.DataBind();

        }

         catch (Exception ex)
        { }


    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            this.FillGrid();
        }
        catch (Exception er) { }
    }


}




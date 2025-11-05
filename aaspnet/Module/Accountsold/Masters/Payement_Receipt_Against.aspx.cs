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

public partial class Module_Accounts_Masters_Payement_Receipt_Against : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {
                string strTerms = ((TextBox)
                GridView1.FooterRow.FindControl("txtTerms2")).Text;

                if (strTerms != "")
                {
                    SqlDataSource1.InsertParameters["Description"].DefaultValue = strTerms;
                    SqlDataSource1.Insert();
                    //lblMessage.Text = "Record Inserted";
                }
            }
            if (e.CommandName == "Add1")
            {
                string strTerms = ((TextBox)
                GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
                if (strTerms != "")
                {
                    SqlDataSource1.InsertParameters["Description"].DefaultValue = strTerms;
                    SqlDataSource1.Insert();
                    //lblMessage.Text = "Record Inserted";
                }
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

            string strTerms = ((TextBox)row.FindControl("txtTerms1")).Text;

            if (strTerms != "")
            {
                con.Open();
                string upd = "UPDATE tblACC_PaymentAgainst SET Description ='" + strTerms + "' WHERE Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        catch (Exception ex) { }

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {
                string strTerms = ((TextBox)
                GridView2.FooterRow.FindControl("txtTerms2")).Text;

                if (strTerms != "")
                {
                    SqlDataSource2.InsertParameters["Description"].DefaultValue = strTerms;
                    SqlDataSource2.Insert();
                    //lblMessage.Text = "Record Inserted";
                }
            }
            if (e.CommandName == "Add1")
            {
                string strTerms = ((TextBox)
                GridView2.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
                if (strTerms != "")
                {
                    SqlDataSource2.InsertParameters["Description"].DefaultValue = strTerms;
                    SqlDataSource2.Insert();
                    //lblMessage.Text = "Record Inserted";
                }
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
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connStr);
            int rowIndex = GridView2.EditIndex;
            GridViewRow row = GridView2.Rows[rowIndex];
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);

            string strTerms = ((TextBox)row.FindControl("txtTerms1")).Text;

            if (strTerms != "")
            {
                con.Open();
                string upd = "UPDATE tblACC_ReceiptAgainst SET description ='" + strTerms + "' WHERE Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }
        catch (Exception ex) { }

    }
}

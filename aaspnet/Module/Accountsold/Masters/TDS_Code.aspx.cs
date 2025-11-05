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

public partial class Module_Accounts_Masters_TDS_Code : System.Web.UI.Page
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
                string SectionNo = (((TextBox)GridView1.FooterRow.FindControl("TextFSectionNo")).Text);
                string NatureOfPayment = (((TextBox)GridView1.FooterRow.FindControl("txtFNatureOfPayment")).Text);
                double PaymentRange = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtFPaymentRange")).Text);
                string PayToIndividual = (((TextBox)GridView1.FooterRow.FindControl("txtFPayToIndividual")).Text);
                string Others = (((TextBox)GridView1.FooterRow.FindControl("txtFOthers")).Text);
                string WithOutPAN = (((TextBox)GridView1.FooterRow.FindControl("txtFWithOutPAN")).Text);

                if (SectionNo.ToString() != "" && NatureOfPayment.ToString() != "" && PayToIndividual != "" && Others != "" && PaymentRange.ToString() != "" && WithOutPAN.ToString() != "")
                {
                    string sqlsub = fun.insert("tblAcc_TDSCode_Master", "SectionNo,NatureOfPayment,PaymentRange,PayToIndividual,Others,WithOutPAN", "'" + SectionNo + "','" + NatureOfPayment + "','" + PaymentRange + "','" + PayToIndividual + "','" + Others + "','" + WithOutPAN + "'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //lblMessage.Text = "Record Inserted";
                }

                else
                {
                    string mystringmsg = string.Empty;
                    mystringmsg = "Invalid data input .";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                }

                
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            if (e.CommandName == "Add1")
            {
                string SectionNo = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtESectionNo")).Text);
                string NatureOfPayment = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtENatureOfPayment")).Text);
                double PaymentRange = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEPaymentRange")).Text);
                string PayToIndividual = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEPayToIndividual")).Text);
                string Others = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEOthers")).Text);

                string WithOutPAN0 = (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtFWithOutPAN")).Text);

                if (SectionNo.ToString() != "" && NatureOfPayment.ToString() != "" && PayToIndividual != "" && Others != "" && PaymentRange.ToString() != "")
                {

                    string sqlsub = fun.insert("tblAcc_TDSCode_Master", "SectionNo,NatureOfPayment,PaymentRange,PayToIndividual,Others,WithOutPAN", "'" + SectionNo + "','" + NatureOfPayment + "','" + PaymentRange + "','" + PayToIndividual + "','" + Others + "','" + WithOutPAN0 + "'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //lblMessage.Text = "Record Inserted";
                }
                else
                {
                    string mystringmsg = string.Empty;
                    mystringmsg = "Invalid data input .";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
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

            string SectionNo = ((TextBox)row.FindControl("TextSectionNo")).Text;
            string NatureOfPayment = ((TextBox)row.FindControl("txtNatureOfPayment")).Text;
            double PaymentRange = Convert.ToDouble(((TextBox)row.FindControl("txtPaymentRange")).Text);
            string PayToIndividual = ((TextBox)row.FindControl("txtPayToIndividual")).Text; ;
            string Others = ((TextBox)row.FindControl("txtOthers")).Text; ;
            string WithOutPAN = (((TextBox)row.FindControl("txtWithOutPAN")).Text);

            if (SectionNo.ToString() != "" && NatureOfPayment.ToString() != "")
            {
                con.Open();

                string upd = "UPDATE tblAcc_TDSCode_Master SET SectionNo ='" + SectionNo + "',NatureOfPayment='" + NatureOfPayment + "',PaymentRange='" + PaymentRange + "',PayToIndividual='" + PayToIndividual + "',Others='" + Others + "',WithOutPAN='" + WithOutPAN + "' WHERE Id ='" + id + "'";

                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        catch (Exception ex)
        {

        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblAcc_TDSCode_Master", "Id='" + id + "'"), con);
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
            SqlDataAdapter da = new SqlDataAdapter("[GetTDSCode]", con);
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


    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        GridView1.PageIndex = e.NewPageIndex;
        this.FillGrid();
        }
        catch (Exception er) { }
    }

}




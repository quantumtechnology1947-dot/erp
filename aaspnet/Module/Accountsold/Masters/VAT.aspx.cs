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

public partial class Module_Accounts_Masters_VAT : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
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
            if (e.CommandName == "Add")
            {
                string strTerms = ((TextBox)
                GridView1.FooterRow.FindControl("txtTerms2")).Text;
                string strvalue = ((TextBox)GridView1.FooterRow.FindControl("txtValue2")).Text;
                
                int valVAT = 0;
                int valCST = 0;

                if(((CheckBox)GridView1.FooterRow.FindControl("CKIsVAT")).Checked == true)
                {
                    valVAT =1;   
                }

                if(((CheckBox)GridView1.FooterRow.FindControl("CKIsCST")).Checked == true)
                {
                    valCST =1;
                }

                int live = 0;
                
                if (strTerms != "" && strvalue != "" && fun.NumberValidationQty(strvalue) == true && (((CheckBox)GridView1.FooterRow.FindControl("CKIsCST")).Checked != true || ((CheckBox)GridView1.FooterRow.FindControl("CKIsVAT")).Checked != true))
                {
                    if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox2")).Checked == true)
                    {
                        live = 1;
                        string connStr = fun.Connection();
                        SqlConnection con = new SqlConnection(connStr);
                        string UpDateStr = "update tblVAT_Master Set Live=0";
                        SqlCommand cmd = new SqlCommand(UpDateStr, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    SqlDataSource1.InsertParameters["Terms"].DefaultValue = strTerms;
                    SqlDataSource1.InsertParameters["Value"].DefaultValue = strvalue;
                    SqlDataSource1.InsertParameters["Live"].DefaultValue = live.ToString();
                    SqlDataSource1.InsertParameters["IsVAT"].DefaultValue = valVAT.ToString();
                    SqlDataSource1.InsertParameters["IsCST"].DefaultValue = valCST.ToString();
                    
                    SqlDataSource1.Insert();
                    lblMessage.Text = "Record Inserted";
                }
            }



            if (e.CommandName == "Add1")
            {

                string strTerms = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
                string strvalue = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text;
                int live = 0;

                int valVAT = 0;
                int valCST = 0;

                if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsVAT")).Checked == true)
                {
                    valVAT = 1;
                }

                if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsCST")).Checked == true)
                {
                    valCST = 1;
                }

                
                if (strTerms != "" && strvalue != "" && fun.NumberValidationQty(strvalue) == true && (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsCST")).Checked != true || ((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsVAT")).Checked != true))
                {
                
                if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_2")).Checked == true)
                {
                    live = 1;
                    string connStr = fun.Connection();
                    SqlConnection con = new SqlConnection(connStr);                   
                    string UpDateStr = "update tblVAT_Master Set Live=0";
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }                
                    SqlDataSource1.InsertParameters["Terms"].DefaultValue = strTerms;
                    SqlDataSource1.InsertParameters["Value"].DefaultValue = strvalue;
                    SqlDataSource1.InsertParameters["Live"].DefaultValue = live.ToString();
                    SqlDataSource1.InsertParameters["IsVAT"].DefaultValue = valVAT.ToString();
                    SqlDataSource1.InsertParameters["IsCST"].DefaultValue = valCST.ToString();
                    SqlDataSource1.Insert();
                    lblMessage.Text = "Record Inserted";
                }
            }
        }

        catch (Exception ex)
        {
        }
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
                
                if (((Label)row.FindControl("txtLive")).Text == "1")
                {
                    ((Label)row.FindControl("txtLive")).Text = "Live";
                }
                else if (((Label)row.FindControl("txtLive")).Text == "0")
                {
                    ((Label)row.FindControl("txtLive")).Text = "";
                }
               
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
            string strValue = ((TextBox)row.FindControl("txtValue1")).Text;

            int live = 0;
            if (strTerms != "" && strValue != "" && fun.NumberValidationQty(strValue) == true)
            {
                if (((CheckBox)row.FindControl("CheckBox02")).Checked == true)
                {
                    live = 1;
                    string UpDateStr = fun.update("tblVAT_Master", "Live=0", "Id !='" + id + "'");
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                SqlDataSource1.UpdateParameters["Terms"].DefaultValue = strTerms;
                SqlDataSource1.UpdateParameters["Value"].DefaultValue = strValue;
                SqlDataSource1.UpdateParameters["Live"].DefaultValue = live.ToString();
                SqlDataSource1.Update();
            }

        }
        catch (Exception ex) { }
    }
}

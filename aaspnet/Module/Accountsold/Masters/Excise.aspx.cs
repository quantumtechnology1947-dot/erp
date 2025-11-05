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

public partial class Module_Accounts_Masters_Excise : System.Web.UI.Page
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
                string strTerms = ((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text;
                string strvalue = ((TextBox)GridView1.FooterRow.FindControl("txtValue2")).Text;
                string Accessable = ((TextBox)GridView1.FooterRow.FindControl("TextBox1")).Text;
                string edu = ((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text;
                string she = ((TextBox)GridView1.FooterRow.FindControl("TextBox3")).Text;

                if (fun.NumberValidationQty(strvalue) == true && fun.NumberValidationQty(Accessable) == true && fun.NumberValidationQty(edu) == true && fun.NumberValidationQty(she) == true && Accessable != "" && edu != "" && strTerms != "" && strvalue != "" && she != "")
                {
                int exlive = 0;

                if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox1")).Checked == true)
                {
                    exlive = 1;
                    string connStr = fun.Connection();
                    SqlConnection con = new SqlConnection(connStr);
                    string UpDateStr = "update tblExciseser_Master Set Live=0";
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int serlive = 0;

                if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox2")).Checked == true)
                {
                    serlive = 1;
                    string connStr = fun.Connection();
                    SqlConnection con = new SqlConnection(connStr);
                    string UpDateStr = "update tblExciseser_Master Set LiveSerTax=0";
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }             
               
                    SqlDataSource1.InsertParameters["Terms"].DefaultValue = strTerms;
                    SqlDataSource1.InsertParameters["Value"].DefaultValue = strvalue;
                    SqlDataSource1.InsertParameters["AccessableValue"].DefaultValue = Accessable;
                    SqlDataSource1.InsertParameters["EDUCess"].DefaultValue = edu;
                    SqlDataSource1.InsertParameters["SHECess"].DefaultValue = she;
                    SqlDataSource1.InsertParameters["Live"].DefaultValue = exlive.ToString();
                    SqlDataSource1.InsertParameters["LiveSerTax"].DefaultValue = serlive.ToString();
                    
                    SqlDataSource1.Insert();
                    Page.Response.Redirect(Page.Request.Url.ToString(),true);
                    lblMessage.Text = "Record Inserted";
                
                }

            }

            if (e.CommandName == "Add1")
            {
                string strTerms = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
                string strvalue = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text;
                string Accessable = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_1")).Text;
                string edu = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_2")).Text;
                string she = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_3")).Text;
                int exlive = 0;
                if (fun.NumberValidationQty(strvalue) == true && fun.NumberValidationQty(Accessable) == true && fun.NumberValidationQty(edu) == true && fun.NumberValidationQty(she) == true && Accessable != "" && edu != "" && strTerms != "" && strvalue != "" && she!="")
                {
                    if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_1")).Checked == true)
                    {
                        exlive = 1;

                    }

                    int serlive = 0;

                    if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_2")).Checked == true)
                    {
                        serlive = 1;
                    }

                        SqlDataSource1.InsertParameters["Terms"].DefaultValue = strTerms;
                        SqlDataSource1.InsertParameters["Value"].DefaultValue = strvalue;
                        SqlDataSource1.InsertParameters["AccessableValue"].DefaultValue = Accessable;
                        SqlDataSource1.InsertParameters["EDUCess"].DefaultValue = edu;
                        SqlDataSource1.InsertParameters["SHECess"].DefaultValue = she;
                        SqlDataSource1.InsertParameters["Live"].DefaultValue = exlive.ToString();
                        SqlDataSource1.InsertParameters["LiveSerTax"].DefaultValue = serlive.ToString();
                        SqlDataSource1.Insert();
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        lblMessage.Text = "Record Inserted";
                    
                }
            }
        }

        catch(Exception ex){}
        
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
                else if(((Label)row.FindControl("txtLive")).Text == "0")
                {
                    ((Label)row.FindControl("txtLive")).Text = "";
                }
                if (((Label)row.FindControl("txtLiveSerTax")).Text == "1")
                {
                    ((Label)row.FindControl("txtLiveSerTax")).Text = "Live";
                }
                else if (((Label)row.FindControl("txtLiveSerTax")).Text == "0")
                {
                    ((Label)row.FindControl("txtLiveSerTax")).Text = "";
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
            string Accessable = ((TextBox)row.FindControl("txtAccessableValue0")).Text;
            string edu = ((TextBox)row.FindControl("txtEDUCess0")).Text;
            string she = ((TextBox)row.FindControl("txtSHECess0")).Text;

            if (fun.NumberValidationQty(strValue) == true && fun.NumberValidationQty(Accessable) == true && fun.NumberValidationQty(edu) == true && fun.NumberValidationQty(she) == true && Accessable != "" && edu != "" && strTerms != "" && strValue != "" && she != "")
            {
                int exlive = 0;

                if (((CheckBox)row.FindControl("CheckBox01")).Checked == true)
                {
                    exlive = 1;
                    string UpDateStr = fun.update("tblExciseser_Master", "Live=0", "Id !='" + id + "'");
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                int serlive = 0;

                if (((CheckBox)row.FindControl("CheckBox02")).Checked == true)
                {
                    serlive = 1;
                    string UpDateStr = fun.update("tblExciseser_Master", "LiveSerTax=0", "Id !='" + id + "'");
                    SqlCommand cmd = new SqlCommand(UpDateStr, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                SqlDataSource1.UpdateParameters["Terms"].DefaultValue = strTerms;
                SqlDataSource1.UpdateParameters["Value"].DefaultValue = strValue;
                SqlDataSource1.UpdateParameters["AccessableValue"].DefaultValue = Accessable;
                SqlDataSource1.UpdateParameters["EDUCess"].DefaultValue = edu;
                SqlDataSource1.UpdateParameters["SHECess"].DefaultValue = she;
                SqlDataSource1.UpdateParameters["Live"].DefaultValue = exlive.ToString();
                SqlDataSource1.UpdateParameters["LiveSerTax"].DefaultValue = serlive.ToString();
                SqlDataSource1.Update();
                
            }
        }
  catch (Exception ex) { }

    }
    }


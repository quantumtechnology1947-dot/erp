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

public partial class Module_Accounts_Masters_Currency : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.loadata();
            }
            lblMessage.Text = "";
        }

        catch (Exception ex) { }
    }

    public void getCnt()
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            foreach (GridViewRow row in GridView1.Rows)
            {
                string id = ((Label)row.FindControl("lblId")).Text;
                string StrGetCountry = fun.select("Country", "tblACC_Currency_Master", "Id='" + id + "'");
                SqlCommand cmd = new SqlCommand(StrGetCountry, con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS, "tblACC_Currency_Master");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((DropDownList)row.FindControl("DrpCountry")).SelectedValue = DS.Tables[0].Rows[0][0].ToString();

                }
                //string StrGetDeloff = fun.select("*", "tblCity", "SId='" + Sid + "'");
                //SqlCommand cmdDelOff = new SqlCommand(StrGetDeloff, con);
                //SqlDataAdapter DADelOff = new SqlDataAdapter(cmdDelOff);
                //DataSet DSDelOff = new DataSet();
                //DADelOff.Fill(DSDelOff, "tblCity");
                //if (DSDelOff.Tables[0].Rows.Count > 0)
                //{
                //    ((LinkButton)row.FindControl("btndel")).Visible = false;

                //}
            }
        }

      catch (Exception ex) { }
    }

    public void loadata()
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            string sqlcity = "";
            sqlcity = fun.select1("*", "tblACC_Currency_Master Order By Id Desc");
            SqlCommand cmdcity = new SqlCommand(sqlcity, con);

            SqlDataAdapter dacity = new SqlDataAdapter(cmdcity);
            DataSet dscity = new DataSet();
            dacity.Fill(dscity);
            GridView1.DataSource = dscity;
            GridView1.DataBind();
            this.getCnt();
        }

        catch (Exception ex)
        {

        }

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
                int cid = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpCountry2")).SelectedValue);
                string Name = ((TextBox)GridView1.FooterRow.FindControl("txtName2")).Text;
                string Symbol= ((TextBox)GridView1.FooterRow.FindControl("txtSymbol2")).Text;

                if (Name != "" && Symbol !="")
                {
                    string str = fun.Connection();
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    string strCity = fun.insert("tblACC_Currency_Master", "Country,Name,Symbol", "'" + cid + "','" + Name + "','" + Symbol + "'");
                    SqlCommand cmdcity = new SqlCommand(strCity, con);
                    cmdcity.ExecuteNonQuery();
                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }

            if (e.CommandName == "Add1")
            {
                int cid = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCountry3")).SelectedValue);
         

                string Name = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName3")).Text;
                string Symbol = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol3")).Text;
                if (Name != "" && Symbol !="")
                {
                    string str = fun.Connection();
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    string strCity = fun.insert("tblACC_Currency_Master", "Country,Name,Symbol", "'" + cid + "','" + Name + "','" + Symbol + "'");
                    SqlCommand cmdcity = new SqlCommand(strCity, con);
                    cmdcity.ExecuteNonQuery();
                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }



            //if (e.CommandName == "Del")
            //{
            //    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //    int Id = Convert.ToInt32(((Label)row.FindControl("lblID")).Text);
            //    string str = fun.Connection();
            //    SqlConnection con = new SqlConnection(str);
            //    con.Open();

            //    string del = fun.delete("tblACC_Currency_Master", "Id='" + Id + "' ");
            //    SqlCommand cmd = new SqlCommand(del, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //}
        }

        catch (Exception ex)
        {
        }

    }

    protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblMessage.Text = "Record Inserted";
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
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.loadata();

            // string str = fun.Connection();
            //SqlConnection con = new SqlConnection(str);
            //con.Open();
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    string id = ((Label)row.FindControl("lblId")).Text;
            //    string StrGetCountry = fun.select("Country", "tblACC_Currency_Master", "Id='" + id + "'");
            //    SqlCommand cmd = new SqlCommand(StrGetCountry, con);
            //    SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //    DataSet DS = new DataSet();
            //    DA.Fill(DS, "tblACC_Currency_Master");
            //    if (DS.Tables[0].Rows.Count > 0)
            //    {
            //        ((DropDownList)row.FindControl("DrpCountry")).SelectedValue = DS.Tables[0].Rows[0][0].ToString();

            //    }
            //}
        }
        catch (Exception ex) { }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            this.loadata();
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            string Name = (((TextBox)row.FindControl("txtName1")).Text);
            string Symbol = (((TextBox)row.FindControl("txtSymbol1")).Text);
            int sid = Convert.ToInt32(((DropDownList)row.FindControl("DrpCountry1")).SelectedValue);

            if (Name != "" && Symbol != "")
            {
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);

                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string upd = fun.update("tblACC_Currency_Master", "Country='" + sid + "' ,Name='" + Name + "',Symbol='" + Symbol + "'", "Id='" + id + "' ");
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.loadata();
        }

        catch (Exception ex) { }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}




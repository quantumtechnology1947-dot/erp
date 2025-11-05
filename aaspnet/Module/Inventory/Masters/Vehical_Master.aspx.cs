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

public partial class Module_MaterialPlanning_Masters_ItemProcess : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            if (!IsPostBack)
            {
                this.LoadData();

                //lblmsg.Text = "";
            }
        }

        catch (Exception ex)
        {
        }
    }

    public void LoadData()
    {

        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string sqlqty = fun.select("Id, VehicalName, VehicalNo", "tblVeh_Process_Master", "Id!='0'");
            SqlCommand cmdqty = new SqlCommand(sqlqty, con);
            SqlDataAdapter daqty = new SqlDataAdapter(cmdqty);
            DataSet DSqty = new DataSet();
            daqty.Fill(DSqty);

            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("VehicalName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("VehicalNo", typeof(string)));
            
            DataRow dr;
            for (int i = 0; i < DSqty.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (DSqty.Tables[0].Rows.Count > 0)
                {

                    dr[0] = DSqty.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = DSqty.Tables[0].Rows[i]["VehicalName"].ToString();
                    dr[2] = DSqty.Tables[0].Rows[i]["VehicalNo"].ToString();
                  
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        catch(Exception ex)
        {
        }

    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);

            if (e.CommandName == "Add")
            {
                string strtxtPName1 = ((TextBox)GridView1.FooterRow.FindControl("txtProcessName1")).Text;
                string strSymbol1 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol1")).Text;
               
                if (strtxtPName1 != "" && strSymbol1 != "")
                {
                    con.Open();
                    string add = fun.insert("tblVeh_Process_Master", "VehicalName,VehicalNo", "'" + strtxtPName1 + "','" + strSymbol1 + "'");
                    SqlCommand cmdAdd = new SqlCommand(add, con);
                    cmdAdd.ExecuteNonQuery();
                    con.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }


            if (e.CommandName == "Add1")
            {
                string strtxtPName1 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName")).Text;
                string strSymbol1 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
               
                if (strtxtPName1 != "" && strSymbol1 != "")
                {
                    con.Open();
                    string add = fun.insert("tblVeh_Process_Master", "VehicalName,VehicalNo", "'" + strtxtPName1 + "','" + strSymbol1 + "'");
                    SqlCommand cmdAdd = new SqlCommand(add, con);
                    cmdAdd.ExecuteNonQuery();

                    con.Close();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }

            }
            if (e.CommandName == "Del")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                string upt = fun.delete("tblVeh_Process_Master", "Id='" + id + "'");
                SqlCommand cmd = new SqlCommand(upt, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }

        catch(Exception ex)
        {
        }
    } 




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.LoadData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            this.LoadData();
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.LoadData();
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
            string sqlqty = fun.select("UOMBasic", "tblVeh_Process_Master", "Id='" + id + "'");
            SqlCommand cmdqty = new SqlCommand(sqlqty, con);
            SqlDataAdapter daqty = new SqlDataAdapter(cmdqty);
            DataSet DSqty = new DataSet();
            daqty.Fill(DSqty);

            if (DSqty.Tables[0].Rows.Count > 0)
            {
                ((DropDownList)row.FindControl("DDLBasic")).SelectedValue = DSqty.Tables[0].Rows[0]["UOMBasic"].ToString();

            }

        }

        catch (Exception ex) { }

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            string connStr = fun.Connection();            
            SqlConnection con = new SqlConnection(connStr);
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string strProcessName = ((TextBox)row.FindControl("txtPName")).Text;
            string strSymbol = ((TextBox)row.FindControl("txtSymbol")).Text;
          
            if (strProcessName != "" && strSymbol != "")
            {
                con.Open();
                string upt = fun.update("tblVeh_Process_Master", "VehicalName='" + strProcessName + "',VehicalNo='" + strSymbol + "'", "Id='" + id + "'");
                SqlCommand cmd = new SqlCommand(upt, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        catch (Exception ex)
        {
        }
    }
    

    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[1].Controls[0];
                del.Attributes.Add("onclick", "return confirmationUpdate();");

            }
            
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        //lblmsg.Text = "Record deleted successfuly";
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //lblmsg.Text = "Record updated successfuly";
    }
}



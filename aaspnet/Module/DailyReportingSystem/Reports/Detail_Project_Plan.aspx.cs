using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Module_Project_Planning_Reports_DETAIL_PROJECT_PLAN : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    DataSet DS = new DataSet();
    string fd1 = "";
    string td1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblMessage.Text = "";
            TxtFromDate.Attributes.Add("readonly", "readonly");
            TxtToDate.Attributes.Add("readonly", "readonly");

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string sql = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
            SqlCommand CmdFinYear = new SqlCommand(sql, con);
            SqlDataAdapter DAFin = new SqlDataAdapter(CmdFinYear);
            DataSet DSFin = new DataSet();
            DAFin.Fill(DSFin, "tblFinancial_master");
            if (DSFin.Tables[0].Rows.Count > 0)
            {
                fd1 = fun.FromDateDMY(DSFin.Tables[0].Rows[0][0].ToString());
                td1 = fun.FromDateDMY(DSFin.Tables[0].Rows[0][1].ToString());
            }
            if (!IsPostBack)
            {
                lblFromDate.Text = fd1;
                TxtFromDate.Text = fd1;
                TxtToDate.Text = fun.FromDateDMY(fun.getCurrDate());
                lblToDate.Text = td1;           
                Drpdep.Visible =false;             
                DrpSearchCode.Visible = false;
                txtSearchItemCode.Visible = false;
                Dropwo.Visible = false;
                


            }
           }

        catch (Exception ex) { }

    }
    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    
        string c = DrpSearchCode.SelectedValue;
        string d = txtSearchItemCode.Text;
        string e1 = DrpType.SelectedValue;
        this.Fillgrid(c, d, e1);
    }
    public void Fillgrid(string B, string s, string drptype)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();

        try
        {

            string x = "";
            string p = "";
            string q = "";
            string y = "";
            if (DrpType.SelectedValue != "Select")
            {
                if (DrpType.SelectedValue == "Category")
                {
                    
                     

                        if (B != "Select")
                        {
                            if (B == "tblDG_Item_Master.ItemCode")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
                            }

                            if (B == "tblDG_Item_Master.ManfDesc")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And tblDG_Item_Master.ManfDesc Like '" + s + "%'";
                            }


                            if (B == "tblDG_Item_Master.Location")
                            {
                                txtSearchItemCode.Visible = false;
                                Drpdep.Visible = true;

                                if (Drpdep.SelectedValue != "Select")
                                {
                                    p = " And tblDG_Item_Master.Location='" + Drpdep.SelectedValue + "'";
                                }
                            }


                        }
                       // q = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";

                    
                    else if ( B == "Select")
                    {
                        //y = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";

                    }


                }

                else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
                {

                    if (B != "Select")
                    {
                        if (B == "tblDG_Item_Master.ItemCode")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And tblDG_Item_Master.ItemCode Like '%" + s + "%'";
                        }

                        if (B == "tblDG_Item_Master.ManfDesc")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
                        }
                    }
                    else if (B == "Select" && s != string.Empty)
                    {
                        y = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";

                    }

                }

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter("GetAllItem", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
                //da.SelectCommand.Parameters["@startIndex"].Value = sd;
                da.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@pageSize"].Value = x;
                da.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@startIndex1"].Value = p;
                da.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@pageSize1"].Value = q;
                da.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@drpType"].Value = drptype;
                da.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@drpCode"].Value = B;
                da.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@y"].Value = y;
                DataSet DSitem = new DataSet();
                da.Fill(DSitem);
                GridView1.DataSource = DSitem;
                GridView1.DataBind();
            }

            else
            {

                string myStringVariable = string.Empty;
                myStringVariable = "Please Select Category or WO Items.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex)
        {

        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string id = (((Label)row.FindControl("lblId")).Text);
                string Icode = (((Label)row.FindControl("itemcode")).Text);
                string desc = (((Label)row.FindControl("manfdesc")).Text);
                string uom = (((Label)row.FindControl("uomBasic")).Text);
                string fd = TxtFromDate.Text;

                string td = TxtToDate.Text;

                if (Convert.ToDateTime(fun.FromDate(TxtToDate.Text)) >= Convert.ToDateTime(fun.FromDate(TxtFromDate.Text)) && fun.DateValidation(TxtFromDate.Text) == true && fun.DateValidation(TxtToDate.Text) == true)
                {
                    if (Convert.ToDateTime(fun.FromDate(fd1)) <= Convert.ToDateTime(fun.FromDate(fd)))
                    {
                        Response.Redirect("StockLedger_Details.aspx?Id=" + id + "&FD=" + fd + "&TD=" + td +
                        "");
                    }
                    else
                    {
                        lblMessage.Text = "From date should not be Less than Opening Date!";
                    }

                }

                else
                {
                    lblMessage.Text = "From date should be Less than or Equal to To Opening Date!";
                }

            }


            if (e.CommandName == "downloadImg")
            {

                foreach (GridViewRow grv in GridView1.Rows)
                {

                    int itemid = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
                }
            }


            if (e.CommandName == "downloadSpec")
            {
                foreach (GridViewRow grv in GridView1.Rows)
                {

                    int itemid = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
                }
            }







        }
        catch (Exception ex) { }

    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (DrpType.SelectedValue != "Select")
            {
               
                string c = DrpSearchCode.SelectedValue;
                string d = txtSearchItemCode.Text;
                string e1 = DrpType.SelectedValue;
                this.Fillgrid(c, d, e1);
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Select Name or WONo.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }
        catch (Exception ex) { }

    }
    protected void Drp1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        string c = DrpSearchCode.SelectedValue;
        string d = txtSearchItemCode.Text;
        string e1 = DrpType.SelectedValue;
        this.Fillgrid(c, d, e1);
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpSearchCode.SelectedItem.Text == "Location")
        {
            Drpdep.Visible = true;
            txtSearchItemCode.Visible = false;
            txtSearchItemCode.Text = "";
        }
        else
        {
            Drpdep.Visible = false;
            txtSearchItemCode.Visible = true;
            txtSearchItemCode.Text = "";
        }
    }
    
    protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (DrpType.SelectedValue)
            {
                case "Name":
                    {
                        DrpSearchCode.Visible = true;
                        Drpdep.Visible = true;
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";

                       

                        string connStr = fun.Connection();
                        SqlConnection con = new SqlConnection(connStr);

                        DataSet DS = new DataSet();
                        string StrCat = fun.select("EmployeeName", "tblHR_Offer_Master", "CompId='" + CompId + "'");
                        SqlCommand Cmd = new SqlCommand(StrCat, con);
                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DA.Fill(DS, "tblHR_Offer_Master");             
                        fun.drpLocat(Drpdep);

                        if (DrpSearchCode.SelectedItem.Text == "Location")
                        {
                            Drpdep.Visible = true;
                            txtSearchItemCode.Visible = false;
                            txtSearchItemCode.Text = "";
                        }
                        else
                        {
                            Drpdep.Visible = false;
                            txtSearchItemCode.Visible = true;
                            txtSearchItemCode.Text = "";
                        }

                    }
                    break;

                case "WONo":
                    {
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";


                        DrpSearchCode.Visible = true;
                        Drpdep.Visible = false;
                       // DropDownList3.Items.Clear();
                        Drpdep.Items.Insert(0, "Select");
                    }
                    break;

                case "Select":
                    {
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);

                    }
                    break;
            }
        }
        catch (Exception ex) { }
    }


   

}
        

    


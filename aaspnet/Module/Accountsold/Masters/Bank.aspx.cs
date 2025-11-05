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

public partial class Module_Accounts_Masters_Bank : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    string connStr = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        connStr = fun.Connection();
        con = new SqlConnection(connStr);

        try
        {
            if (!IsPostBack)
            {
                this.FillGrid();
                if (GridView1.Rows.Count > 0)
                {
                    this.fillState1();                   
                }
                else
                {

                    this.fillState2();
                }


               
            } 
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
            string connStr = fun.Connection();
                      SqlConnection con = new SqlConnection(connStr);

            if (e.CommandName == "Add")
            {
                string BankName = ((TextBox)GridView1.FooterRow.FindControl("txtBank1")).Text;
                string Adress = ((TextBox)GridView1.FooterRow.FindControl("txtAddress1")).Text;
                int  Country =Convert.ToInt32( ((DropDownList)GridView1.FooterRow.FindControl("DrpCountry1")).SelectedValue);
                int State = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("Drpstate1")).SelectedValue);
                int City = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpCity1")).SelectedValue); 
                string Pin = ((TextBox)GridView1.FooterRow.FindControl("txtPINNo1")).Text;
                string ContactNo = ((TextBox)GridView1.FooterRow.FindControl("txtContactNo1")).Text;
                string FaxNo = ((TextBox)GridView1.FooterRow.FindControl("txtFaxNo1")).Text;
                string Code = ((TextBox)GridView1.FooterRow.FindControl("txtIFSC1")).Text;
               
                if (BankName != "")
                {

       string sqlsub = fun.insert("tblACC_Bank","Name,  Address, Country ,State,City , PINNo , ContactNo , FaxNo , IFSC ", "'"+BankName+"','"+Adress+"','"+Country+"','"+State+"','"+City+"','"+Pin+"','"+ContactNo+"','"+FaxNo+"','"+Code+"'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Bank.aspx");
                }
            }
            if (e.CommandName == "Add1")
            {

                string BankName = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName2")).Text;
                string Adress = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextAdddress2")).Text;
                int Country = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCountry2")).SelectedValue);
                int State = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("Drpstate2")).SelectedValue);
                int City = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCity2")).SelectedValue);
                string Pin = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextPinNo2")).Text;
                string ContactNo = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextContactNo2")).Text;
                string FaxNo = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextFaxNo2")).Text;
                string Code = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextIFSC2")).Text;


                if (BankName != "" && Adress != "" && Pin != "" && ContactNo != "" && FaxNo != "" && Code!="")
                {
                    string sqlsub = fun.insert("tblACC_Bank","Name,  Address, Country ,State,City , PINNo , ContactNo , FaxNo , IFSC ", "'"+BankName+"','"+Adress+"','"+Country+"','"+State+"','"+City+"','"+Pin+"','"+ContactNo+"','"+FaxNo+"','"+Code+"'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlsub, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Bank.aspx");
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
            string BankName = ((TextBox)row.FindControl("txtBank")).Text;
            string Address = ((TextBox)row.FindControl("txtAddress")).Text;
            int Country = Convert.ToInt32(((DropDownList)row.FindControl("DrpCountry")).SelectedValue);
            int State = Convert.ToInt32(((DropDownList)row.FindControl("Drpstate")).SelectedValue);
            int City = Convert.ToInt32(((DropDownList)row.FindControl("DrpCity")).SelectedValue);
            string Pin = ((TextBox)row.FindControl("txtPINNo")).Text;
            string ContactNo = ((TextBox)row.FindControl("txtContactNo")).Text;
            string FaxNo = ((TextBox)row.FindControl("txtFaxNo")).Text;
            string Code = ((TextBox)row.FindControl("txtIFSC")).Text;
            if (BankName != "" && Address != "" && Pin != "" && ContactNo != "" && FaxNo != "" && Code != "")
            {
                con.Open();
                string upd = "UPDATE tblACC_Bank SET Name='" + BankName + "',  Address='" + Address + "', Country='" + Country + "' ,State='" + State + "',City='" + City + "' , PINNo='" + Pin + "' , ContactNo='" + ContactNo + "' , FaxNo='" + FaxNo + "' , IFSC='" + Code + "' WHERE Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(upd, con);
                cmd.ExecuteNonQuery();
                con.Close();
               

            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        catch (Exception ex) { }

    }
    protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
       try
        {
           
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;           
            DropDownList Drpstate = row.FindControl("Drpstate") as DropDownList;
            DropDownList DrpCity = row.FindControl("DrpCity") as DropDownList;
            fun.dropdownState(Drpstate, DrpCity, ddl);
            DrpCity.Items.Clear();

        }
        catch (Exception ex)
        {
        }

    }
    protected void DrpCountry1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
         this.fillState1();

        }
        catch (Exception ex)
        {
        }

    }
    protected void DrpCountry2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.fillState2();

        }
        catch (Exception ex)
        {
        }

    }
    protected void Drpstate1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
          this.fillCity1();
        }
        catch (Exception ex)
        {
        }

    }
    protected void Drpstate2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
          this.fillCity2();
        }
        catch (Exception ex)
        {
        }

    }

    protected void Drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;           
            DropDownList DrpCity = row.FindControl("DrpCity") as DropDownList;
            fun.dropdownCity(DrpCity, ddl);
        }
        catch (Exception ex)
        {
        }

    }  

    public void fillState1()
    {
        DropDownList drpcountry = GridView1.FooterRow.FindControl("DrpCountry1") as DropDownList;
        DropDownList Drpstate1 = GridView1.FooterRow.FindControl("Drpstate1") as DropDownList;
        DropDownList DrpCity1 = GridView1.FooterRow.FindControl("DrpCity1") as DropDownList;
        fun.dropdownState(Drpstate1, DrpCity1, drpcountry);
        DrpCity1.Items.Clear();

    }

    public void fillCity1()
    {
        DropDownList Drpstate1 = GridView1.FooterRow.FindControl("Drpstate1") as DropDownList;
        DropDownList DrpCity1 = GridView1.FooterRow.FindControl("DrpCity1") as DropDownList;
        fun.dropdownCity(DrpCity1, Drpstate1);
    }

    public void fillState2()
    {

        DropDownList drpcountry2 = GridView1.Controls[0].Controls[0].FindControl("DrpCountry2") as DropDownList;
        DropDownList Drpstate2 = GridView1.Controls[0].Controls[0].FindControl("Drpstate2") as DropDownList;
        DropDownList DrpCity2 = GridView1.Controls[0].Controls[0].FindControl("DrpCity2") as DropDownList;
        fun.dropdownState(Drpstate2, DrpCity2, drpcountry2);
        

    }

    public void fillCity2()
    {
        DropDownList Drpstate2 = GridView1.Controls[0].Controls[0].FindControl("Drpstate2") as DropDownList;
        DropDownList DrpCity2 = GridView1.Controls[0].Controls[0].FindControl("DrpCity2") as DropDownList;
        fun.dropdownCity(DrpCity2, Drpstate2);
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.FillGrid();
            int index = GridView1.EditIndex;
            GridViewRow grv = GridView1.Rows[index];           
            DropDownList drpcountry = grv.FindControl("DrpCountry") as DropDownList;
            DropDownList Drpstate = grv.FindControl("Drpstate") as DropDownList;
            DropDownList DrpCity = grv.FindControl("DrpCity") as DropDownList; 
            string CountryId = ((Label)grv.FindControl("lblCountryE")).Text;
            string StateId = ((Label)grv.FindControl("lblState1")).Text;
            string CityId = ((Label)grv.FindControl("lblCIty1")).Text;
            drpcountry.SelectedValue = CountryId;
            fun.dropdownState(Drpstate, DrpCity, drpcountry);
            Drpstate.SelectedValue = StateId;
            fun.dropdownCity(DrpCity, Drpstate);
            DrpCity.SelectedValue = CityId;         
        }
        catch (Exception er) { }
    }
    public void FillGrid()
    {
       try
        {
            SqlDataAdapter da = new SqlDataAdapter("[GetBank_Details]", con);           
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_Bank", "Id='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception er) { }
    }
}

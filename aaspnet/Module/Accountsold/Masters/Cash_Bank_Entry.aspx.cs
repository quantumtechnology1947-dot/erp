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

public partial class Module_Accounts_Masters_Cash_Bank_Entry : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string CDate = "";
    string CTime = "";
    string SId = "";
    int CompId = 0;
    int FinYearId = 0;
    string connStr =string.Empty;
    SqlConnection con ;
    protected void Page_Load(object sender, EventArgs e)
    {
        CDate = fun.getCurrDate();
        CTime = fun.getCurrTime();
        SId = Session["username"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        if(!IsPostBack)
        {

        this.FillGrid();

        }

    }

    public void FillGrid()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("[GetBank_Entry]", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView1.DataSource = DSitem;
            GridView1.DataBind();
          
        }

        catch (Exception ex)
        { }


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {        
       
        if (txtCashAmt.Text != "" && fun.NumberValidationQty(txtCashAmt.Text) == true)
        {

            string insert = fun.insert("tblACC_CashAmt_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,Amt", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + txtCashAmt.Text + "'");

            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        }
        catch (Exception er) { }
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
            double Amt = Convert.ToDouble(((TextBox)row.FindControl("TextBox1")).Text);


            string UpDateStr = fun.update("tblACC_CashAmt_Master", "[SysDate] ='"+CDate+"', [SysTime] ='"+CTime+"' ", "Id ='" + id + "'");
            SqlCommand cmd = new SqlCommand(UpDateStr, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataSource1.Update();
                

        }
        catch (Exception ex) { }
    }


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

       try
        {           
            DataSet ds = new DataSet();           
            int rowIndex = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[rowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            double Amt = Convert.ToDouble(((TextBox)row.FindControl("TextBox2")).Text);
            int BankId = Convert.ToInt32(((DropDownList)row.FindControl("DrpBankNameE")).SelectedValue);
            string UpDateStr = fun.update("tblACC_BankAmt_Master", "[SysDate] ='" + CDate + "', [SysTime] ='" + CTime + "',[SessionId]='"+SId+"',[CompId] = "+CompId+", [FinYearId] ="+FinYearId+", [Amt] = "+Amt+",BankId="+BankId+" ", "Id ='" + id + "'");
            SqlCommand cmd = new SqlCommand(UpDateStr, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();            
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            
        }
        catch (Exception ex) { }
    }
    protected void btnBankAdd_Click(object sender, EventArgs e)
    {


        if (txtBankAmt.Text != "" && fun.NumberValidationQty(txtBankAmt.Text) == true && txtBankAmt.Text != "0")
        {

            string insert = fun.insert("tblACC_BankAmt_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,Amt,BankId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + txtBankAmt.Text + "','"+DrpBankName.SelectedValue+"'");
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    { 
        try
        {
        GridView1.EditIndex = e.NewEditIndex;
        this.FillGrid();
        int index = GridView1.EditIndex;
        GridViewRow grv = GridView1.Rows[index];
        int id = Convert.ToInt32(((Label)grv.FindControl("lblBankId")).Text);
        ((DropDownList)grv.FindControl("DrpBankNameE")).SelectedValue = id.ToString();
        }
        catch (Exception er) { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_BankAmt_Master", "Id='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        catch (Exception er) { }
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

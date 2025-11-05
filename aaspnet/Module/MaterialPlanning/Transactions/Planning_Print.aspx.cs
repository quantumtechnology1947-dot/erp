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

public partial class Module_MaterialPlanning_Transactions_Planning_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    string No = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
      try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            if (!IsPostBack)
            {               
                this.fillgrid(No);
            }
        }
       catch (Exception ex)
        {

        }

    }
    public void fillgrid(string no)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
     try
        {

            con.Open();
            string x = "";
            if (DrpField.SelectedValue == "1")
            {
                if (Txtsearch.Text != "")
                {
                    x = " AND tblMP_Material_Master.PLNo='" + Txtsearch.Text + "'";
                }
            }
            string y = "";
            if (DrpField.SelectedValue == "0")
            {
                if (Txtsearch.Text != "")
                {
                    y = " AND tblMP_Material_Master.WONo='" + Txtsearch.Text + "'";
                }
                
            }
            SqlDataAdapter da = new SqlDataAdapter("Sp_Plan_WOGrid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@CompId"].Value = CompId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@FinId"].Value = FinYearId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@x"].Value = x;
            da.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@y"].Value = y;            
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView1.DataSource = DSitem;
            GridView1.DataBind();          
           
        }
    catch (Exception ex)
        {

        }
     finally
        {
            con.Close();
        }
    }
    protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
    {

       
        if (DrpField.SelectedValue == "0")
        {
 Txtsearch.Text = "";
            this.fillgrid(No);
           
        }

        else
        {
            Txtsearch.Text = "";
            this.fillgrid(No);
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Txtsearch.Text != "")
            {
                this.fillgrid(Txtsearch.Text);
            }
            else
            {
                this.fillgrid(No);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {

            con.Open();

            if (e.CommandName == "Sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string PlnId = (((Label)row.FindControl("lblId")).Text);
                string pln = (((Label)row.FindControl("lblPLNo")).Text);
                string FinId = (((Label)row.FindControl("lblFinYearId")).Text);
                string Wono = (((Label)row.FindControl("lblWONo")).Text);

                string getRandomKey = fun.GetRandomAlphaNumeric();  
                Response.Redirect("Planning_Print_Details.aspx?MId="+PlnId+"&plno=" + pln + "&FinYearId="+FinId+"&WONo="+Wono+"&Key="+getRandomKey+"&ModId=4&SubModId=33");

            }
          
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.fillgrid(No);
    }
}

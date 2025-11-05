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
using System.IO;

public partial class Module_Accounts_Transactions_Capital : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FyId = 0;
    string SId = "";
    string CDate = "";
    string CTime = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        CompId = Convert.ToInt32(Session["compid"]);
        FyId = Convert.ToInt32(Session["finyear"]);
        SId = Session["username"].ToString();

        CDate = fun.getCurrDate();
        CTime = fun.getCurrTime();

        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        if (!IsPostBack)
        {
            this.FillData();
            Panel3.Visible = true;  
        }
        }
       catch (Exception ex) { }

    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.FillData();           
        }
        catch (Exception ex) { }

    }

    public void FillData()
    {
        try
        {
            con.Open();

            string sql = fun.select("*", "tblACC_Capital_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "' Order by Id DESC");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Perticulars", typeof(string)));
            DataRow dr;
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["Particulars"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();           

            foreach (GridViewRow grv in GridView2.Rows)
            {
                string id = ((Label)grv.FindControl("lblId")).Text;

                string strAss1 = fun.select("MId", "tblACC_Capital_Details", "MId='" +id +"'");
                SqlCommand cmdAss1 = new SqlCommand(strAss1, con);
                SqlDataReader rdrAss1 = cmdAss1.ExecuteReader();
                while (rdrAss1.Read())
                {
                    if (rdrAss1.HasRows)
                    {
                        ((LinkButton)grv.FindControl("LinkBtnDel")).Visible = false;
                    }
                  
                }
            }

          con.Close();
        }
        catch (Exception ex) { }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Add")
            {
                string Perticulars = (((TextBox)GridView2.FooterRow.FindControl("TextPerticulars2")).Text);

                if (Perticulars != "" )
                {
                    string StrIns1 = fun.insert("tblACC_Capital_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, Particulars", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + Perticulars + "'");

                    SqlCommand cmdIns1 = new SqlCommand(StrIns1, con);
                    con.Open();
                    cmdIns1.ExecuteNonQuery();
                    con.Close();
                    this.FillData();
                }
                
            }

            if (e.CommandName == "Add1")
            {
                string Perticulars = (((TextBox)GridView2.Controls[0].Controls[0].FindControl("TextPerticulars1")).Text );

                if (Perticulars != "")
                {
                    string StrIns2 = fun.insert("tblACC_Capital_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, Particulars", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + Perticulars + "'");

                    SqlCommand cmdIns2 = new SqlCommand(StrIns2, con);
                    con.Open();
                    cmdIns2.ExecuteNonQuery();
                    con.Close();
                    this.FillData();
                }               
            }

            if (e.CommandName == "Del")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id1 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                con.Open();
                string sqlDel = fun.delete("tblACC_Capital_Master", "Id='" + id1 + "'");
                SqlCommand cmdDel = new SqlCommand(sqlDel, con);
                cmdDel.ExecuteNonQuery();
                con.Close();
                this.FillData();
                Panel3.Visible = true;
                GridView3.Visible = false;
                
            }

            if (e.CommandName == "HpPerticulars")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id1 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                ViewState["MId"] = id1;
                this.FillDataCredit();               
               this. NODataToDisplay(GridView2);       
            }

        }
        catch (Exception ex) { }
    }

    public void FillDataCredit()
    {
       try
        {
            con.Open();
           
            string sql = fun.select("*", "tblACC_Capital_Details", " MId='" +Convert.ToInt32( ViewState["MId"].ToString()) + "'");

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Perticulars", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CreditAmt", typeof(double )));
            dt.Columns.Add(new System.Data.DataColumn("MId", typeof(string)));

            DataRow dr;

            for (int q = 0; q < DS.Tables[0].Rows.Count; q++)
            {
                dr = dt.NewRow();
                dr[0] = DS.Tables[0].Rows[q]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[q]["Particulars"].ToString();
                dr[2] = DS.Tables[0].Rows[q]["CreditAmt"].ToString();
                dr[3] = ViewState["MId"].ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();             
            }
            GridView3.DataSource = dt;
            GridView3.DataBind();
           
            con.Close();
        }
       catch (Exception ex) { }
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.FillDataCredit();
        }
        catch (Exception ex) { }

    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "Addp")
            {
                string Perticulars = (((TextBox)GridView3.FooterRow.FindControl("TextPerticularsp2")).Text);

                double CreditAmt = 0;

                if (fun.NumberValidationQty(((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text) == true && (((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text) != "")
                {
                    CreditAmt = Convert.ToDouble(((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text);
                }

                if (Perticulars != "" && CreditAmt != 0)
                {
                    string StrIns1 = fun.insert("tblACC_Capital_Details", "MId, Particulars,CreditAmt", "'" + Convert.ToInt32(ViewState["MId"].ToString()) + "','" + Perticulars + "','" + CreditAmt + "'");

                    SqlCommand cmdIns1 = new SqlCommand(StrIns1, con);
                    con.Open();
                    cmdIns1.ExecuteNonQuery();
                    con.Close();
                    this.FillDataCredit();

                }
            }

            if (e.CommandName == "Addp1")
            {
                string Perticulars = (((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextPerticularsp1")).Text);
                double CreditAmt = 0;

                if (fun.NumberValidationQty(((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text) == true && (((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text) != "")
                {
                    CreditAmt = Convert.ToDouble(((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text);
                }


                if (Perticulars != "" && CreditAmt != 0)
                {
                    string StrIns2 = fun.insert("tblACC_Capital_Details", "MId, Particulars,CreditAmt", "'" + Convert.ToInt32(ViewState["MId"].ToString()) + "','" + Perticulars + "','" + CreditAmt + "'");

                    SqlCommand cmdIns2 = new SqlCommand(StrIns2, con);
                    con.Open();
                    cmdIns2.ExecuteNonQuery();
                    con.Close();
                    this.FillDataCredit();
                    this.FillData();
                }

            }

            if (e.CommandName == "Delp")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id1 = Convert.ToInt32(((Label)row.FindControl("lblIdp")).Text);
                con.Open();
                string sqlDel = fun.delete("tblACC_Capital_Details", "Id='" + id1 + "'");
                SqlCommand cmdDel = new SqlCommand(sqlDel, con);
                cmdDel.ExecuteNonQuery();
                con.Close();
                this.FillDataCredit();
                this.FillData();
                this.NODataToDisplay(GridView3);  
            }
        }
        catch (Exception ex){}

    }


    public void NODataToDisplay(GridView grv)
    {
        if (grv.Rows.Count == 0)
        {
            Panel3.Visible = true;
            GridView3.Visible = false;
        }
        else
        {
            Panel3.Visible = false;
            GridView3.Visible = true;
        }
    }
}
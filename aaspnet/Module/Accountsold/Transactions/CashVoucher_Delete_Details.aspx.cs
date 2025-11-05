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

public partial class Module_Accounts_Transactions_CashVoucher_Delete_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SId = "";
    int CompId = 0;
    int FinYearId = 0;
    int id = 0;
    string str = "";
    SqlConnection con; double tamt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SId = Session["username"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        str = fun.Connection();
        con = new SqlConnection(str);
        id = Convert.ToInt32(Request.QueryString["Id"]);
       
        if (!IsPostBack)
        {
            this.FillData();
        } 
        
        ((Label)GridView1.FooterRow.FindControl("LblTotalAmt")).Text ="Total - "+ tamt.ToString();
    }


    public void FillData()
    {
          try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("BillNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PODate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Particulars", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BGGroup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            DataRow dr;
            string sql = fun.select("*", "tblACC_CashVoucher_Payment_Details", "MId='" + id + "'  ");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
           
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();
                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["BillNo"].ToString();
                dr[2] = fun.FromDateDMY(DS.Tables[0].Rows[p]["BillDate"].ToString());
                if (DS.Tables[0].Rows[p]["PONo"] != DBNull.Value)
                {
                    dr[3] = (DS.Tables[0].Rows[p]["PONo"].ToString());
                    dr[4] = fun.FromDateDMY(DS.Tables[0].Rows[p]["PODate"].ToString());
                }

                dr[5] = (DS.Tables[0].Rows[p]["Particulars"].ToString());


                if (DS.Tables[0].Rows[p]["WONo"] != DBNull.Value)
                {
                    dr[6] = DS.Tables[0].Rows[p]["WONo"].ToString();
                }
                if (DS.Tables[0].Rows[p]["BGGroup"] != DBNull.Value)
                {
                    string sql5 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(DS.Tables[0].Rows[p]["BGGroup"]) + "'");

                    SqlCommand cmd5 = new SqlCommand(sql5, con);
                    SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                    DataSet DS5 = new DataSet();
                    da5.Fill(DS5);

                    if (DS5.Tables[0].Rows.Count > 0)
                    {
                        dr[7] = DS5.Tables[0].Rows[0]["Dept"].ToString();
                    }
                }
                

                string sql3 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(DS.Tables[0].Rows[p]["AcHead"]) + "' ");
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet DS3 = new DataSet();
                da3.Fill(DS3);
                dr[8] = DS3.Tables[0].Rows[0]["Head"].ToString();
                dr[9] = DS.Tables[0].Rows[p]["Amount"].ToString();
                tamt +=Convert.ToDouble( DS.Tables[0].Rows[p]["Amount"]);
                dr[10] = DS.Tables[0].Rows[p]["BudgetCode"].ToString();
                dr[11] = DS.Tables[0].Rows[p]["PVEVNo"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ess)
        { }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

        try
        {
            if (e.CommandName == "Del")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id1 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                con.Open();
                string sql = fun.delete("tblACC_CashVoucher_Payment_Details", "Id='" + id1 + "'");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                string Strdel = fun.select("Id", "tblACC_CashVoucher_Payment_Details", "MId='" + id + "'");
                SqlCommand cmddel = new SqlCommand(Strdel, con);
                SqlDataAdapter dadel = new SqlDataAdapter(cmddel);
                DataSet DSdel = new DataSet();
                dadel.Fill(DSdel);

                if (DSdel.Tables[0].Rows.Count == 0)
                {
                    string sqlDelM = fun.delete("tblACC_CashVoucher_Payment_Master", "  Id='" + id + "' AND CompId='" + CompId + "' ");
                    SqlCommand cmdDelM = new SqlCommand(sqlDelM, con);
                    cmdDelM.ExecuteNonQuery();
                    Response.Redirect("CashVoucher_Delete.aspx?ModId=11&SubModId=113");
                }
                con.Close();
                this.FillData();
            }
        }
        catch (Exception ex)
        {
        }



    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.FillData();
        
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("CashVoucher_Delete.aspx?ModId=11&SubModId=113");

    }
}

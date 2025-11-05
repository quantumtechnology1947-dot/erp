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

public partial class Module_Accounts_Transactions_BillBooking_Delete_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;
    int Mid = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            Mid = Convert.ToInt32(Request.QueryString["Id"]);
            if (!IsPostBack)
            {
                this.loadData();
            }
        }
        catch(Exception ex)
        {
        }

    }


    public void loadData()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();

        con.Open();
        try
        {

            string StrSql = fun.select("* ", "tblACC_BillBooking_Details", "MId='" + Mid + "'");
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            DataSet DSSql = new DataSet();
            daSql.Fill(DSSql);


            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GQNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GSNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Descr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("PFAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStBasic", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStEducess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStShecess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CustomDuty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CST", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("TarrifNo", typeof(double)));
            
            DataRow dr;
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (DSSql.Tables[0].Rows.Count > 0)
                {   
                    int Discount = 0;
                    double Amt = 0;
                    double Rate = 0;

                    string StrSql11 = fun.select("tblMM_PO_Details.Rate,tblMM_PO_Details.Discount", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + DSSql.Tables[0].Rows[i]["PODId"].ToString() + "' AND   tblMM_PO_Master.Id=tblMM_PO_Details.MId  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
                    
                    SqlCommand cmdPo11 = new SqlCommand(StrSql11, con);
                    SqlDataAdapter DAPo11 = new SqlDataAdapter(cmdPo11);
                    DataSet DSSql11 = new DataSet();
                    DAPo11.Fill(DSSql11);

                    if (DSSql11.Tables[0].Rows.Count > 0)
                    {
                        Rate = Convert.ToInt32(DSSql11.Tables[0].Rows[0]["Rate"]);
                        Discount = Convert.ToInt32(DSSql11.Tables[0].Rows[0]["Discount"]);
                    }

                    if (DSSql.Tables[0].Rows[i]["GQNId"].ToString() != "0")
                    {
                        string Strgqn = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + DSSql.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
                        SqlCommand cmdgqn = new SqlCommand(Strgqn, con);
                        SqlDataAdapter dagqn = new SqlDataAdapter(cmdgqn);
                        DataSet DSgqn = new DataSet();
                        dagqn.Fill(DSgqn);

                        if (DSgqn.Tables[0].Rows.Count > 0)
                        {
                            dr[1] = DSgqn.Tables[0].Rows[0]["GQNNo"].ToString();
                            double AccQty = Convert.ToDouble(DSgqn.Tables[0].Rows[0]["AcceptedQty"].ToString());
                            Amt = ((Rate - (Rate * Discount) / 100) * AccQty);
                        }
                        else
                        {
                            dr[1] = "NA";
                        }
                    }
                    else
                    {
                        string Strgsn = fun.select("tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + DSSql.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
                        SqlCommand cmdgsn = new SqlCommand(Strgsn, con);
                        SqlDataAdapter dagsn = new SqlDataAdapter(cmdgsn);
                        DataSet DSgsn = new DataSet();
                        dagsn.Fill(DSgsn);

                        if (DSgsn.Tables[0].Rows.Count > 0)
                        {
                            dr[2] = DSgsn.Tables[0].Rows[0]["GSNNo"].ToString();
                            double AccQty = Convert.ToDouble(DSgsn.Tables[0].Rows[0]["ReceivedQty"].ToString());
                            Amt = ((Rate - (Rate * Discount) / 100) * AccQty);
                        }
                        else
                        {
                            dr[2] = "NA";
                        }
                    }

                    dr[0] = DSSql.Tables[0].Rows[i]["Id"].ToString();

                    string StrIcode1 = fun.select("ItemCode,ManfDesc As Descr,UOMBasic ", "tblDG_Item_Master", "Id='" + DSSql.Tables[0].Rows[i]["ItemId"].ToString() + "'");
                    SqlCommand cmdIcode1 = new SqlCommand(StrIcode1, con);
                    SqlDataAdapter daIcode1 = new SqlDataAdapter(cmdIcode1);
                    DataSet DSIcode1 = new DataSet();
                    daIcode1.Fill(DSIcode1);

                    if (DSIcode1.Tables[0].Rows.Count > 0)
                    {
                        dr[3] = DSIcode1.Tables[0].Rows[0]["ItemCode"].ToString();
                        dr[4] = DSIcode1.Tables[0].Rows[0]["Descr"].ToString();
                        // for UOM Basic  from Unit Master table
                        string sqlPurch1 = fun.select("Symbol As UOM ", "Unit_Master", "Id='" + DSIcode1.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
                        SqlCommand cmdPurch1 = new SqlCommand(sqlPurch1, con);
                        SqlDataAdapter daPurch1 = new SqlDataAdapter(cmdPurch1);
                        DataSet DSPurch1 = new DataSet();
                        daPurch1.Fill(DSPurch1);
                       
                        if (DSPurch1.Tables[0].Rows.Count > 0)
                        {
                            dr[5] = DSPurch1.Tables[0].Rows[0][0].ToString();
                        }
                        dr[6] = Amt;

                        dr[7] = DSSql.Tables[0].Rows[i]["PFAmt"].ToString();
                        dr[8] = DSSql.Tables[0].Rows[i]["ExStBasic"].ToString();
                        dr[9] = DSSql.Tables[0].Rows[i]["ExStEducess"].ToString();
                        dr[10] = DSSql.Tables[0].Rows[i]["ExStShecess"].ToString();
                        dr[11] = DSSql.Tables[0].Rows[i]["CustomDuty"].ToString();
                        dr[12] = DSSql.Tables[0].Rows[i]["VAT"].ToString();
                        dr[13] = DSSql.Tables[0].Rows[i]["CST"].ToString();
                        dr[14] = DSSql.Tables[0].Rows[i]["Freight"].ToString();
                        dr[15] = DSSql.Tables[0].Rows[i]["TarrifNo"].ToString();

                    }

                }



                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

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
            this.loadData();

        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       try
        {

            if (e.CommandName == "Del")
            {
                string connStr = fun.Connection();
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                
                string id = ((Label)row.FindControl("lblId")).Text;

                string sql = fun.delete("tblACC_BillBooking_Details", "Id='" + id + "' AND MId='" + Mid + "'");

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                string StrSql1 = fun.select("MId ", "tblACC_BillBooking_Details", "MId='" + Mid + "'");

                SqlCommand cmdSql1 = new SqlCommand(StrSql1, con);
                SqlDataAdapter daSql1 = new SqlDataAdapter(cmdSql1);
                DataSet DSSql1 = new DataSet();
                daSql1.Fill(DSSql1);
               
                if (DSSql1.Tables[0].Rows.Count == 0)
                {
                    string sql1 = fun.delete("tblACC_BillBooking_Master", "Id='" + Mid + "'");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("BillBooking_Delete.aspx?ModId=11&SubModId=62");

                }

                Page.Response.Redirect(Page.Request.Url.ToString(), true);

                con.Close();



            }
        }
      catch (Exception ex) { }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillBooking_Delete.aspx?ModId=11&SubModId=62");
    }
}

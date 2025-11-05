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

public partial class Module_Accounts_Transactions_ServiceTaxInvoice_Delete_Dtails : System.Web.UI.Page
{   
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string invId = "";  
    string CCode = "";
    string InvNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();
            invId = fun.Decrypt(Request.QueryString["invid"].ToString());
            InvNo = fun.Decrypt(Request.QueryString["InvNo"].ToString());
            CCode = fun.Decrypt(Request.QueryString["cid"].ToString());
            if (!IsPostBack)
            {
                this.LoadData();
            }
        }
        catch (Exception ex) { }
    }

    public void LoadData()
    {
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("ItemDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("ReqQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("AmtInPer", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("RmnQty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("ItemId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Unit", typeof(int)));
            DataRow dr;
            string sql = fun.select("tblACC_ServiceTaxInvoice_Details.Id,tblACC_ServiceTaxInvoice_Details.InvoiceNo,tblACC_ServiceTaxInvoice_Details.ItemId,tblACC_ServiceTaxInvoice_Details.Unit,tblACC_ServiceTaxInvoice_Details.Qty,tblACC_ServiceTaxInvoice_Details.ReqQty,tblACC_ServiceTaxInvoice_Details.AmtInPer,tblACC_ServiceTaxInvoice_Details.Rate,tblACC_ServiceTaxInvoice_Master.POId", "tblACC_ServiceTaxInvoice_Details,tblACC_ServiceTaxInvoice_Master", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id AND tblACC_ServiceTaxInvoice_Master.Id= '" + invId + "' AND tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "'");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    dr = dt.NewRow();

                    dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();

                    // For Item Desc                  
                    string sql1 = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", " SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + DS.Tables[0].Rows[p]["POId"] + "'AND SD_Cust_PO_Details.Id='" + DS.Tables[0].Rows[p]["ItemId"] + "'");

                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet DS1 = new DataSet();
                    da1.Fill(DS1);
                    if (DS1.Tables[0].Rows.Count > 0)
                    {
                        dr[1] = DS1.Tables[0].Rows[0]["ItemDesc"].ToString();
                    }

                    // For Symbol 
                    string sql2 = fun.select("Symbol", "Unit_Master", "Id='" + DS.Tables[0].Rows[p]["Unit"].ToString() + "' ");

                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataSet DS2 = new DataSet();
                    da2.Fill(DS2);
                    if (DS2.Tables[0].Rows.Count > 0)
                    {
                        dr[2] = DS2.Tables[0].Rows[0]["Symbol"].ToString();
                    }
                    double Qty = 0;
                    double rmnqty = 0;
                                        
                    string sqlrmn = fun.select("Sum(tblACC_ServiceTaxInvoice_Details.ReqQty) as ReqQty", "tblACC_ServiceTaxInvoice_Master,tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Details.MId=tblACC_ServiceTaxInvoice_Master.Id  And  tblACC_ServiceTaxInvoice_Master.CompId='" + CompId + "' And tblACC_ServiceTaxInvoice_Details.ItemId='" + DS.Tables[0].Rows[p]["ItemId"].ToString() + "' AND tblACC_ServiceTaxInvoice_Master.Id='" + invId + "'  Group By tblACC_ServiceTaxInvoice_Details.ItemId");

                    SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                    SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                    DataSet dsrmn = new DataSet();
                    darmn.Fill(dsrmn);


                    double TotInvQty = 0;
                    if (dsrmn.Tables[0].Rows.Count > 0)
                    {
                        TotInvQty = Convert.ToDouble(decimal.Parse(dsrmn.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
                    }
                    Qty = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[p]["Qty"].ToString()).ToString("N3"));
                    rmnqty = Qty - TotInvQty;
                    dr[3] = Qty;
                    dr[4] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[p]["ReqQty"].ToString()).ToString("N3"));
                    dr[5] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[p]["AmtInPer"].ToString()).ToString("N2"));
                    dr[6] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[p]["Rate"].ToString()).ToString("N2"));
                    dr[7] = rmnqty;
                    dr[8] = DS.Tables[0].Rows[p]["ItemId"].ToString();
                    dr[9] = DS.Tables[0].Rows[p]["Unit"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

      catch (Exception ex) { }
    }
    protected void Btngoods_Click(object sender, EventArgs e)
    { 
        string connStr = fun.Connection();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connStr);
        con.Open();
        try
        {



            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                    string sqltemp = fun.delete("tblACC_ServiceTaxInvoice_Details", "Id='" + id + "'AND MId='" + invId + "'");
                    SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                    cmdtemp.ExecuteNonQuery();

                }
            }

            string sql = fun.select("InvoiceNo", "tblACC_ServiceTaxInvoice_Details", "InvoiceNo='" + InvNo + "' AND MId='" + invId + "'");
            SqlCommand cmdinv = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmdinv);
            DataSet DS = new DataSet();
            da.Fill(DS);

            if (DS.Tables[0].Rows.Count == 0)
            {
                string sqlupdate = fun.delete("tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' And InvoiceNo='" + InvNo + "'AND Id='" + invId + "' ");
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("ServiceTaxInvoice_Delete.aspx?ModId=11&SubModId=52");
            }
            else
            {

                Response.Redirect("ServiceTaxInvoice_Delete_Details.aspx?InvNo=" + Server.UrlEncode(fun.Encrypt(InvNo)) + "&invid=" + Server.UrlEncode(fun.Encrypt(invId)) + "&cid=" + Server.UrlEncode(fun.Encrypt(CCode)) + "&ModId=11&SubModId=52");
            }
        }
        catch (Exception ex) { }
        finally
        {
            con.Close();          
        }
        
    }
    
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceTaxInvoice_Delete.aspx?ModId=11&SubModId=52");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.LoadData();
    }
}

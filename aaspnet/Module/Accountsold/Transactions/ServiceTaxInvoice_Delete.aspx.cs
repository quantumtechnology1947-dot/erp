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

public partial class Module_Accounts_Transactions_ServiceTaxInvoice_Delete : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int FinYearId = 0;
    int CompId = 0;
    string CId = "";
    string WN = "";
    protected void Page_Load(object sender, EventArgs e)
    { 
        try
        {
        string sId = Session["username"].ToString();
        FinYearId = Convert.ToInt32(Session["finyear"]);
        CompId = Convert.ToInt32(Session["compid"]);
            if (!Page.IsPostBack)
            {
                txtpoNo.Visible = false;
                this.bindgrid(CId, WN);
            }
        }
       catch (Exception ex) { }

    }

    public void bindgrid(string Cid, String wn)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
        try
        {
            con.Open();

            if (DropDownList1.SelectedValue == "Select")
            {
                txtpoNo.Visible = true;

                txtCustName.Visible = false;
            }

            string I = "";
            if (DropDownList1.SelectedValue == "0")
            {
                if (txtCustName.Text != "")
                {
                    string Custid = fun.getCode(txtCustName.Text);
                    I = " AND CustomerCode='" + Custid + "'";
                }
            }

            string y = "";
            if (DropDownList1.SelectedValue == "2")
            {
                if (txtpoNo.Text != "")
                {
                    y = " AND PONo='" + txtpoNo.Text + "'";
                }
            }

            string z = "";
            if (DropDownList1.SelectedValue == "3")
            {
                if (txtpoNo.Text != "")
                {
                    z = " AND InvoiceNo='" + txtpoNo.Text + "'";
                }
            }

            string sqlInv = fun.select("Id,FinYearId,SysDate,InvoiceNo,WONo,PONo,CustomerCode", "tblACC_ServiceTaxInvoice_Master", "CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'" + I + y + z + " Order by Id Desc");
            SqlCommand cmdInv = new SqlCommand(sqlInv, con);
            SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
            DataSet DSInv = new DataSet();
            DAInv.Fill(DSInv);


            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("InVoiceNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONO", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CustomerId", typeof(string)));
            if (DSInv.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSInv.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);

                    string Sysdt = fun.FromDateDMY(DSInv.Tables[0].Rows[i]["SysDate"].ToString());

                    string sqlCust = fun.select("CustomerName,CustomerId", "SD_Cust_master", "CustomerId='" + DSInv.Tables[0].Rows[i]["CustomerCode"] + "' And CompId='" + CompId + "'");
                    SqlCommand cmdCust = new SqlCommand(sqlCust, con);
                    SqlDataAdapter DACust = new SqlDataAdapter(cmdCust);
                    DataSet DSCust = new DataSet();
                    DACust.Fill(DSCust);

                    dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                    dr[2] = DSInv.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    dr[3] = Sysdt;
                    dr[4] = DSCust.Tables[0].Rows[0]["CustomerName"].ToString() + "[" + DSCust.Tables[0].Rows[0]["CustomerId"].ToString() + "]";

                    // For WONo 
                    string WN1 = DSInv.Tables[0].Rows[i]["WONo"].ToString();
                    string[] split = WN1.Split(new Char[] { ',' });
                    string WoNO = "";
                    for (int d = 0; d < split.Length - 1; d++)
                    {

                        string sqlWoNo = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + split[d] + "' AND CompId='" + CompId + "'");
                        SqlCommand cmdWoNo = new SqlCommand(sqlWoNo, con);
                        SqlDataAdapter daWoNo = new SqlDataAdapter(cmdWoNo);
                        DataSet dsWoNo = new DataSet();
                        daWoNo.Fill(dsWoNo);

                        if (dsWoNo.Tables[0].Rows.Count > 0)
                        {
                            WoNO += dsWoNo.Tables[0].Rows[0][0].ToString() + ",";
                        }
                    }

                    dr[5] = WoNO;
                    dr[6] = DSInv.Tables[0].Rows[i]["PONo"].ToString();
                    dr[7] = DSCust.Tables[0].Rows[0]["CustomerId"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch(Exception ex){}

        }
     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         if (e.CommandName == "Sel")
         {
             try
             {
                 GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                 string invno = ((Label)row.FindControl("lblInVoiceNo")).Text;
                 string invid = ((Label)row.FindControl("lblId")).Text;                
                 string custcode = ((Label)row.FindControl("lblCustId")).Text;

                 Response.Redirect("ServiceTaxInvoice_Delete_Details.aspx?InvNo=" + Server.UrlEncode(fun.Encrypt(invno ))+ "&invid=" + Server.UrlEncode(fun.Encrypt(invid))+ "&cid=" + Server.UrlEncode(fun.Encrypt(custcode)) + "&ModId=11&SubModId=52");                 

             }
             catch (Exception ex) { }
         }
     }
     protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         GridView1.PageIndex = e.NewPageIndex;
         this.bindgrid(CId,WN);
     }
     protected void btnSearch_Click(object sender, EventArgs e)
     {
         try
         {
             this.bindgrid(txtCustName.Text, txtpoNo.Text);
         }
        catch (Exception ex){} 
     }
     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             if (DropDownList1.SelectedValue == "0")
             {
                 txtpoNo.Visible = false;
                 txtCustName.Visible = true;
                 txtCustName.Text = "";
                 this.bindgrid(CId, WN);
             }

             if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
             {
                 txtpoNo.Visible = true;
                 txtCustName.Visible = false;
                 txtpoNo.Text = "";
                 this.bindgrid(CId, WN);
             }
         }

        catch (Exception ex) { }
     }

     [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
     public static string[] sql(string prefixText, int count, string contextKey)
     {
         clsFunctions fun = new clsFunctions();
         string connStr = fun.Connection();
         DataSet ds = new DataSet();
         SqlConnection con = new SqlConnection(connStr);
         int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
         con.Open();
         string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master","CompId='"+CompId+"'");
         SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
         da.Fill(ds, "SD_Cust_master");
         con.Close();
         string[] main = new string[0];
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
             if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
             {
                 Array.Resize(ref main, main.Length + 1);
                 main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                 //if (main.Length == 10)
                 //    break;
             }
         }
         Array.Sort(main);
         return main;
         
     }
}
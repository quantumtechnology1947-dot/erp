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

public partial class Module_Accounts_Transactions_ProformaInvoice_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    
    int FinYearId = 0;
    int CompId = 0;
    string CId = "";
    string WN="";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {   
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
         
            if (!Page.IsPostBack)
            {
                txtpoNo.Visible = false;
                this.bindgrid(CId, WN);
                this.getWONOInDRP();                
            }

        }
        catch (Exception ex) { }
    }

    public void getWONOInDRP()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        foreach (GridViewRow grv in GridView1.Rows)
        {
            
            ListBox ddl = ((ListBox)grv.FindControl("ListBox1"));
            string PId = ((Label)grv.FindControl("lblPOId")).Text;
            ddl.SelectionMode = ListSelectionMode.Multiple;
            string sqlWOInDrp = fun.select("WONo+'-'+TaskProjectTitle As WoProjectTitle,Id", "SD_Cust_WorkOrder_Master", "POId= '" + PId + "' AND CompId='" + CompId + "'");
               
            SqlCommand cmdWOInDrp = new SqlCommand(sqlWOInDrp, con);
            SqlDataAdapter WOInDrp = new SqlDataAdapter(cmdWOInDrp);
            DataSet DSWOInDrp = new DataSet();
            WOInDrp.Fill(DSWOInDrp);
            for (int k = 0; k < DSWOInDrp.Tables[0].Rows.Count; k++)
            {
                ddl.DataSource = DSWOInDrp.Tables[0];
                ddl.DataTextField = "WoProjectTitle";
                ddl.DataValueField = "Id";
                ddl.DataBind();
            }
        }
    }

    public void bindgrid(string Cid, string wn)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
      try
        {
            con.Open();
            string x = "";
            string z = "";
            if (DropDownList1.SelectedValue == "Select")
            {
                txtpoNo.Visible = true;

                txtCustName.Visible = false;
            }

            string y = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtpoNo.Text != "")
                {
                    y = " AND SD_Cust_PO_Master.PONO='" + txtpoNo.Text + "'";
                } 
            }
                if (DropDownList1.SelectedValue == "0")
                {
                    if (txtCustName.Text != "")
                    {
                        string Custid = fun.getCode(txtCustName.Text);
                        z = " AND SD_Cust_PO_Master.CustomerId='" + Custid + "'";
                    }
                }
                     
            string sqlDA = fun.select("SD_Cust_PO_Master.SysDate,SD_Cust_PO_Master.POId,SD_Cust_PO_Master.PONo,SD_Cust_PO_Master.CustomerId,SD_Cust_PO_Master.PODate,SD_Cust_PO_Master.FinYearId", "SD_Cust_PO_Master", "SD_Cust_PO_Master.CompId='" + CompId + "' And SD_Cust_PO_Master.FinYearId<='" + FinYearId + "'"+y+" "+z+" Order By POId Desc ");
            
            SqlCommand cmdDA = new SqlCommand(sqlDA, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmdDA);
            DataSet DSDA = new DataSet();
            DA.Fill(DSDA);
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));          
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));            
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));           
            dt.Columns.Add(new System.Data.DataColumn("CustomerId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("POId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Count", typeof(string)));

            if (DSDA.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < DSDA.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSDA.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);

                    string Sysdt = fun.FromDateDMY(DSDA.Tables[0].Rows[i]["SysDate"].ToString());
                    
                       
                            string sqlCust = fun.select("CustomerName,CustomerId", "SD_Cust_master", "CustomerId='" + DSDA.Tables[0].Rows[i]["CustomerId"] + "' And CompId='" + CompId + "'");
                            SqlCommand cmdCust = new SqlCommand(sqlCust, con);
                            SqlDataAdapter DACust = new SqlDataAdapter(cmdCust);
                            DataSet DSCust = new DataSet();
                            DACust.Fill(DSCust);

                            string sqlQty = fun.select("SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Id", "SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId AND SD_Cust_PO_Master.POId='" + DSDA.Tables[0].Rows[i]["POId"].ToString() + "' AND SD_Cust_PO_Master.CompId='" + CompId + "'");

                            SqlCommand cmdQty = new SqlCommand(sqlQty, con);
                            SqlDataAdapter daQty = new SqlDataAdapter(cmdQty);
                            DataSet DSQty = new DataSet();
                            daQty.Fill(DSQty);

                            int y1 = 0;
                            for (int k = 0; k < DSQty.Tables[0].Rows.Count; k++)
                            {
                                double reqty = 0;
                                double rmnqty = 0;
                                double qty = 0;

                                qty = Convert.ToDouble(decimal.Parse((DSQty.Tables[0].Rows[k]["TotalQty"]).ToString()).ToString("N3"));
                                                                
                                string sqlrmn = fun.select(" Sum(tblACC_ProformaInvoice_Details.ReqQty) as ReqQty", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details,SD_Cust_PO_Master,SD_Cust_PO_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And tblACC_ProformaInvoice_Details.ItemId=SD_Cust_PO_Details.Id ANd tblACC_ProformaInvoice_Master.POId=SD_Cust_PO_Master.POId  AND tblACC_ProformaInvoice_Master.POId='" + DSDA.Tables[0].Rows[i]["POId"].ToString() + "' AND tblACC_ProformaInvoice_Details.ItemId='" + DSQty.Tables[0].Rows[k]["Id"].ToString() + "' Group By tblACC_ProformaInvoice_Details.ItemId ");

                                SqlCommand cmdmn = new SqlCommand(sqlrmn, con);
                                SqlDataAdapter darmn = new SqlDataAdapter(cmdmn);
                                DataSet dsrmn = new DataSet();
                                darmn.Fill(dsrmn);

                                if (dsrmn.Tables[0].Rows.Count > 0 && dsrmn.Tables[0].Rows[0]["ReqQty"] != DBNull.Value)
                                {
                                    reqty = Convert.ToDouble(decimal.Parse((dsrmn.Tables[0].Rows[0]["ReqQty"]).ToString()).ToString("N3"));
                                   
                                }

                                rmnqty = qty - reqty;

                                if (rmnqty > 0)
                                {
                                    y1++;
                                }
                            }
                            
                            if (y1 > 0)
                            {
                                string sqlrmn1 = fun.select("count(*) as Rcount", "tblACC_ProformaInvoice_Master", "CompId='" + CompId + "' AND POId='" + DSDA.Tables[0].Rows[i]["POId"].ToString() + "'");
                                
                                SqlCommand cmdmn1 = new SqlCommand(sqlrmn1, con);
                                SqlDataAdapter darmn1 = new SqlDataAdapter(cmdmn1);
                                DataSet dsrmn1 = new DataSet();
                                darmn1.Fill(dsrmn1);
                                
                                dr[0] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                                dr[1] = DSCust.Tables[0].Rows[0]["CustomerName"].ToString() + "[" + DSCust.Tables[0].Rows[0]["CustomerId"].ToString() + "]";                               
                                dr[2] = Sysdt;                               
                                dr[3] = DSDA.Tables[0].Rows[i]["PONo"].ToString();                              
                                dr[4] = DSCust.Tables[0].Rows[0]["CustomerId"].ToString();
                                dr[5] = DSDA.Tables[0].Rows[i]["POId"].ToString();
                                dr[6] = dsrmn1.Tables[0].Rows[0]["Rcount"].ToString();

                                dt.Rows.Add(dr);
                                dt.AcceptChanges();
                            } 
                    }
                }           

            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.getWONOInDRP();
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
                
                string pono = ((Label)row.FindControl("lblPONo")).Text;
                string poid = ((Label)row.FindControl("lblPOId")).Text;
                string podate = ((Label)row.FindControl("lblDate")).Text;
               
                // String to pass in QueryString
                string WoNoId=((Label)row.FindControl("hfWOno")).Text;
                string type = ((DropDownList)row.FindControl("drp1")).SelectedValue;
                string custcode = ((Label)row.FindControl("lblCustId")).Text;
                
                if (WoNoId != "")
                {
                    Response.Redirect("ProformaInvoice_New_Details.aspx?poid=" + Server.UrlEncode(fun.Encrypt(poid)) + "&wn=" + Server.UrlEncode(fun.Encrypt(WoNoId)) + "&pn=" + Server.UrlEncode(fun.Encrypt(pono)) + "&date=" + Server.UrlEncode(fun.Encrypt(podate)) + "&ty=" + Server.UrlEncode(fun.Encrypt(type.ToString())) + "&cid=" + Server.UrlEncode(fun.Encrypt(custcode)) + "&ModId=11&SubModId=104");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Select WONo and Against.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }


            }
        }
       catch (Exception ex) { }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindgrid(CId,WN);

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


            if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select")
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {           
            this.bindgrid( txtCustName.Text,txtpoNo.Text);

        }
       catch (Exception ex)
        {
        }
       
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s5 = "";
        string s1 = "";
        foreach (GridViewRow grv in GridView1.Rows)
        {
            ListBox ddl = ((ListBox)grv.FindControl("ListBox1"));
            TextBox txtpf = ((TextBox)grv.FindControl("TxtPF"));
            Label hfwono = ((Label)grv.FindControl("hfWOno"));
            string[] custId2 = { };
            string x = "";
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Selected == true)
                {
                    s5 = ddl.Items[i].Text;
                    string[] b = s5.Split('-');

                    for (int j = 0; j < b.Length; j++)
                    {
                        if (j % 2 == 0)
                        {
                            x += b[j] + ",";
                        }
                    }

                    s1 += ddl.Items[i].Value + ",";
                }

            }           
            txtpf.Text = x;
            hfwono.Text = s1;
        }
    }


}

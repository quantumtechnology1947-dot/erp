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

public partial class Module_Accounts_Transactions_SundryCreditors_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = string.Empty;
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string SId = string.Empty;
    string CDate = string.Empty;
    string CTime = string.Empty;
    string GetCategory = string.Empty;
    double CreditTotal = 0;
    double OpeningAmt = 0;
    double DebitTotal = 0;
    double ClosingTotal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            GetCategory = Request.QueryString["lnkFor"];
            lblOf.Text = GetCategory;
            
            if (!Page.IsPostBack)
            {
                this.FillGrid_Creditors();                
                lblTotal.Text = CreditTotal.ToString();
                lblTotal1.Text = DebitTotal.ToString();
                lblTotal2.Text = (CreditTotal-DebitTotal).ToString();
            }
           
        }
        catch(Exception ex)
        {
            
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "LnkBtn")
            {
                string getRandomKey = fun.GetRandomAlphaNumeric();

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string SupId = string.Empty;
                SupId = ((Label)row.FindControl("lblSupId")).Text;

                Response.Redirect("SundryCreditors_InDetailList.aspx?SupId=" + SupId + "&ModId=11&SubModId=135&Key=" + getRandomKey + "&lnkFor="+GetCategory+"");
            }
        }
        catch (Exception ex) { }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=135");
        
    }

    public void FillGrid_Creditors()
    {
        try
        {
            string CustCode = string.Empty;

            if (TextBox1.Text != string.Empty)
            {
                CustCode = " And tblMM_Supplier_master.SupplierId='" + fun.getCode(TextBox1.Text) + "'";
            }
            
            DataTable dt = new DataTable();
            
            string strCredit = fun.select("SupId,SupplierId,SupplierName+' ['+SupplierId+']' AS SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' order by SupplierId Asc");
            SqlCommand cmdCredit = new SqlCommand(strCredit, con);
            SqlDataReader rdr;
            con.Open();

            rdr = cmdCredit.ExecuteReader();
            DataRow dr;
            
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("OpeningAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("BookBillAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("PaymentAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ClosingAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierId", typeof(string)));

           
            while (rdr.Read())
            {
                dr = dt.NewRow();

                dr[0] = rdr["SupId"].ToString();
                dr[1] = rdr["SupplierName"].ToString();
                
                string strCreditOp = fun.select("OpeningAmt", "tblACC_Creditors_Master", "SupplierId='" + rdr["SupplierId"].ToString() + "'");
                SqlCommand cmdCreditOp = new SqlCommand(strCreditOp, con);
                SqlDataReader rdrOp = cmdCreditOp.ExecuteReader();
                rdrOp.Read();

                double OpeningAmt = 0;
                if (rdrOp.HasRows == true && rdrOp["OpeningAmt"] != DBNull.Value)
                {
                    OpeningAmt = Math.Round(Convert.ToDouble(rdrOp["OpeningAmt"]), 2);                    
                }

                double BookBillAmt = 0;
                BookBillAmt = fun.FillGrid_CreditorsBookedBill(CompId, FinYearId, rdr["SupplierId"].ToString(), GetCategory);               
                dr[3] = Math.Round(BookBillAmt, 2);

                double PaymentAmt = 0;
                PaymentAmt = fun.FillGrid_CreditorsPayment(CompId, FinYearId, rdr["SupplierId"].ToString(), 0, GetCategory);
                double CashPaymentAmt = 0;
                CashPaymentAmt = fun.FillGrid_CreditorsCashPayment(CompId, FinYearId, rdr["SupplierId"].ToString(), 0, GetCategory);
                dr[4] = Math.Round((PaymentAmt+CashPaymentAmt), 2);
            
                dr[6] = rdr["SupplierId"].ToString();

                if (BookBillAmt > 0)
                {
                    CreditTotal += Math.Round((BookBillAmt + OpeningAmt), 2);
                    DebitTotal += Math.Round(PaymentAmt + CashPaymentAmt, 2);

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            ViewState["ToExport"] = dt;
            
         
        }
        catch (Exception ex)
        { 
        
        }
        finally
        {
            con.Close();
        }
    }   

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.FillGrid_Creditors();
        }
       catch (Exception ex) { }
    }
   
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql3(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);

        int CodeType = 0;
        if (contextKey == "key2")
        {
            CodeType = 1;
        }
        else
        {
            CodeType = 2;
        }

        switch (CodeType)
        {
            

            case 1:
                {
                    string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "' Order By CustomerName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "SD_Cust_master");
                }
                break;

            case 2:
                {
                    string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' Order By SupplierName ASC");
                    SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
                    da.Fill(ds, "tblMM_Supplier_master");
                }
                break;

        }
       
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                  
            }
        }
        Array.Sort(main);
        return main;
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        this.FillGrid_Creditors();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SundryCreditors.aspx?ModId=&SubModId=");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        
        dt = (DataTable)ViewState["ToExport"];

        ExportToExcel obj = new ExportToExcel();

        obj.ExportDataToExcel(dt,"Ledger Extracts.");
    }
}

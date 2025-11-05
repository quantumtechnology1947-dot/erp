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

public partial class Module_Accounts_Transactions_CashVoucher_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SId = "";
    int CompId = 0;
    int FinYearId = 0;
    string PaidTo = "";
    string CashRecAgainst = "";
    string str = "";
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            str = fun.Connection();
            con = new SqlConnection(str);
            if (!IsPostBack)
            {
                this.FillData(PaidTo);
                this.FillDataRec(CashRecAgainst);
            }

        }
        catch(Exception ex)
        {
        }
    }
    public void FillData(string paidto )
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("CVPNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PaidTo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CodeType", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Receivedby", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CompId ", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));
            DataRow dr;


             string x = "";
             if (txtPaidto.Text != "")
             {
                 x = " And PaidTo like'%" + paidto + "%'";
             }
             else
             {
                 x = "";             
             }           

            string sql = fun.select("*", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "'"+x+" order by Id Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();
                dr[0] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["CVPNo"].ToString();
                string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'  AND CompId='" + CompId + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);
                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[2] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                }
                dr[3] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString());
                dr[4] = (DS.Tables[0].Rows[p]["PaidTo"].ToString());

                int types = 0;
                types = Convert.ToInt32(DS.Tables[0].Rows[p]["CodeType"].ToString());
                string sql2 = "";
                if (types == 1)
                {
                    dr[5] = "Employee";
                    sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS.Tables[0].Rows[p]["Receivedby"] + "'");
                }
                else if (types == 2)
                {
                    dr[5] = "Customer";
                    sql2 = fun.select("CustomerName+'[ '+CustomerId+']'  As EmpName", "SD_Cust_master", "CompId='" + CompId + "' AND CustomerId='" + DS.Tables[0].Rows[p]["Receivedby"] + "'");
                }
                else if (types == 3)
                {
                    dr[5] = "Supplier";
                    sql2 = fun.select("SupplierName+'[ '+SupplierId+']'  As  EmpName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + DS.Tables[0].Rows[p]["Receivedby"] + "'");
                }
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);
                dr[6] = DS2.Tables[0].Rows[0]["EmpName"].ToString();

                string strAmt = fun.select("Sum(Amount)As Amount", "tblACC_CashVoucher_Payment_Details", "MId='" + DS.Tables[0].Rows[p]["Id"].ToString() + "'");
                SqlCommand cmdAmt = new SqlCommand(strAmt, con);
                SqlDataAdapter daAmt = new SqlDataAdapter(cmdAmt);
                DataSet DSAmt = new DataSet();
                daAmt.Fill(DSAmt);
                if (DSAmt.Tables[0].Rows.Count > 0)
                {
                    dr[8] = DSAmt.Tables[0].Rows[0]["Amount"].ToString();
                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ess)
        { }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            PaidTo = txtPaidto.Text;
            this.FillData(PaidTo);
            TabContainer1.ActiveTabIndex = 0;
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            try
            {
                string getRandomKey = fun.GetRandomAlphaNumeric();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                string CVPId = ((Label)row.FindControl("lblId")).Text;
                Response.Redirect("CashVoucher_Payment_Print_Details.aspx?CVPId=" + CVPId + "&ModId=11&SubModId=113&Key=" + getRandomKey + "");
            }
            catch (Exception ex) { }
        }

    }


    public void FillDataRec(string Cash_recAgainst)
    {
        try
        {

            con.Open();
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//0
            dt.Columns.Add(new System.Data.DataColumn("CVRNo", typeof(string)));//1
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));//2
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string))); //  3       
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedAgainst", typeof(string)));//4
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedAgainstType", typeof(string)));//5
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedBy", typeof(string)));//6
            dt.Columns.Add(new System.Data.DataColumn("CashReceivedByType", typeof(string)));//7
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//8
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(string)));

            DataRow dr;

            string x = "";
            if (TxtCashRecAgainst.Text != "")
            {
                x = " And CashReceivedAgainst like'%"+Cash_recAgainst+"%'";
            }
            else
            {
                x = "";
            }
            string sqlRec = fun.select("*", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "'"+x+" order by Id Desc"); 
            SqlCommand cmdRec = new SqlCommand(sqlRec, con);
            SqlDataAdapter DARec = new SqlDataAdapter(cmdRec);
            DataSet DSRec = new DataSet();
            DARec.Fill(DSRec);
            for (int q = 0; q < DSRec.Tables[0].Rows.Count; q++)
            {
                dr = dt.NewRow();
                dr[0] = DSRec.Tables[0].Rows[q]["Id"].ToString();
                dr[1] = DSRec.Tables[0].Rows[q]["CVRNo"].ToString();

                string stryr1 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSRec.Tables[0].Rows[q]["FinYearId"].ToString() + "'  AND CompId='" + CompId + "'");
                SqlCommand cmdyr1 = new SqlCommand(stryr1, con);
                SqlDataAdapter dayr1 = new SqlDataAdapter(cmdyr1);
                DataSet DSyr1 = new DataSet();
                dayr1.Fill(DSyr1);
                if (DSyr1.Tables[0].Rows.Count > 0)
                {
                    dr[2] = DSyr1.Tables[0].Rows[0]["FinYear"].ToString();
                }

                dr[3] = fun.FromDate(DSRec.Tables[0].Rows[q]["SysDate"].ToString());

                dr[4] = fun.EmpCustSupplierNames(Convert.ToInt32(DSRec.Tables[0].Rows[q]["CodeTypeRA"].ToString()), DSRec.Tables[0].Rows[q]["CashReceivedAgainst"].ToString(), CompId);

                int typesRa = 0;
                typesRa = Convert.ToInt32(DSRec.Tables[0].Rows[q]["CodeTypeRA"].ToString());
                if (typesRa == 1)
                {
                    dr[5] = "Employee";
                }
                else if (typesRa == 2)
                {
                    dr[5] = "Customer";
                }
                else if (typesRa == 3)
                {
                    dr[5] = "Supplier";
                }

                dr[6] = fun.EmpCustSupplierNames(Convert.ToInt32(DSRec.Tables[0].Rows[q]["CodeTypeRB"].ToString()), DSRec.Tables[0].Rows[q]["CashReceivedBy"].ToString(), CompId);

                int typesRb = 0;
                typesRb = Convert.ToInt32(DSRec.Tables[0].Rows[q]["CodeTypeRB"].ToString());
                if (typesRb == 1)
                {
                    dr[7] = "Employee";
                }
                else if (typesRb == 2)
                {
                    dr[7] = "Customer";
                }
                else if (typesRb == 3)
                {
                    dr[7] = "Supplier";
                }
                dr[8] = DSRec.Tables[0].Rows[q]["CompId"].ToString();
                dr[9] = DSRec.Tables[0].Rows[q]["Amount"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
          
        }
        catch (Exception ess)
        { }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            CashRecAgainst = fun.getCode(TxtCashRecAgainst.Text);
            this.FillDataRec(CashRecAgainst);
            TabContainer1.ActiveTabIndex = 1;
        }
        catch (Exception ex) { }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sel_R")
        {
            try
            {
                string getRandomKey = fun.GetRandomAlphaNumeric();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                string CVRId = ((Label)row.FindControl("lblId_R")).Text;
                Response.Redirect("CashVoucher_Receipt_Print_Details.aspx?CVRId=" + CVRId + "&ModId=11&SubModId=113&Key=" + getRandomKey + "");
            }
            catch (Exception ex) { }
        }
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("Distinct PaidTo", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblACC_CashVoucher_Payment_Master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[0].ToString() ;
                //+ " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]"
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql1(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = "Select EmployeeName+'['+EmpId+']' AS AllName  from tblHR_OfficeStaff where CompId='" + CompId + "' union select CustomerName+'['+CustomerId+']' AS AllName from SD_Cust_master where CompId='" + CompId + "' union select SupplierName+'['+SupplierId+']' AS AllName from tblMM_Supplier_master where CompId='" + CompId + "'";

        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds);
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
               
            }
        }
        Array.Sort(main);
        return main;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            PaidTo = txtPaidto.Text;
            this.FillData(PaidTo);
        }
        catch (Exception ex) { }
    }

    protected void btnCashRecAgainst_Click(object sender, EventArgs e)
    {
        try
        {            
            CashRecAgainst = fun.getCode(TxtCashRecAgainst.Text);
            this.FillDataRec(CashRecAgainst);            
        }
        catch (Exception ex) { }
    }
}

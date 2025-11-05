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

public partial class Module_Accounts_Transactions_BankVoucher_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";
    string PaidTo = "";
    string ReceivedFrom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            con.Open();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            if (!Page.IsPostBack)
            {
                this.FillGrid_Creditors(PaidTo);
                //this.Loaddata(ReceivedFrom);
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
    public void FillGrid_Creditors(string paidto)
    {
       try
        {
            string x = "";
            if (txtPaidto.Text != "")
            {
                x = " And PayTo like'%"+paidto+"%'";
            }
            else
            {
                x = "";
            }  
           
            string str = "SELECT Id,BVPNo,Type,NameOnCheque,PaidType,ECSType,PayTo,ChequeDate,ChequeNo,PayAmt,AddAmt,Bank FROM tblACC_BankVoucher_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'" + x + " Order By Id desc"; 
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataReader DSCustWo = cmdCustWo.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("BVPNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeOfVoucher", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PaidTo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Bank", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PayAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("AddAmt", typeof(double)));
            DataRow dr;
            while (DSCustWo.Read())
            {
                dr = dt.NewRow();
                dr[0] = DSCustWo["BVPNo"].ToString();
                int ac = Convert.ToInt32(DSCustWo["Type"]);
                
                switch (ac)
                {
                    case 1:
                        dr[1] = "Advance";
                        break;
                    case 2:
                        dr[1] = "Salary";
                        break;
                    case 3:
                        dr[1] = "Others";

                        break;
                    case 4:
                        dr[1] = "Creditors";
                        break;
                }

                string Abc;
                int num1;
                if (DSCustWo["NameOnCheque"].ToString() == "" || DSCustWo["NameOnCheque"] == DBNull.Value)
                {
                    if (int.TryParse(DSCustWo["PaidType"].ToString(), out num1))
                    {
                        string xyz = fun.ECSNames(Convert.ToInt32(DSCustWo["ECSType"].ToString()), DSCustWo["PayTo"].ToString(), CompId);
                        string stre = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(DSCustWo["PaidType"]) + "'");
                        SqlCommand cmde = new SqlCommand(stre, con);
                        SqlDataReader DSe = cmde.ExecuteReader(CommandBehavior.CloseConnection);
                        DSe.Read();                                               
                        Abc = DSe["Particulars"].ToString()+" - "+xyz;                      

                    }
                    else
                    {

                        Abc = fun.ECSNames(Convert.ToInt32(DSCustWo["ECSType"].ToString()), DSCustWo["PayTo"].ToString(), CompId);
                    }
                }
                else
                {

                    Abc = DSCustWo["NameOnCheque"].ToString();
                }



                dr[2] = Abc;

                dr[3] = DSCustWo["Id"].ToString();
                dr[5] = fun.FromDateDMY(DSCustWo["ChequeDate"].ToString());
                dr[4] = DSCustWo["ChequeNo"].ToString();

                double DtlsAmt = 0;
               
                string sqlAmt2 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + DSCustWo["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type='" + Convert.ToInt32(DSCustWo["Type"]) + "'";
                
                SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                SqlDataReader dsstk6 = cmd6.ExecuteReader(CommandBehavior.CloseConnection);
                dsstk6.Read();               

                if (dsstk6["Amt"]!=DBNull.Value)
                {
                    DtlsAmt = Convert.ToDouble(dsstk6["Amt"].ToString());                    
                }

                double PayAmy_M = 0;
                PayAmy_M = Convert.ToDouble(DSCustWo["PayAmt"]);
                dr[6] = DtlsAmt;

                dr[8] = PayAmy_M;
                double AddAmt = 0;
                if (DSCustWo["AddAmt"] != DBNull.Value)
                {
                  AddAmt = Convert.ToDouble(DSCustWo["AddAmt"]);
                }

                dr[9] = AddAmt;
                string sqlBank = fun.select("Name","tblACC_Bank","Id='" + DSCustWo["Bank"].ToString() + "'");
                SqlCommand cmdBank = new SqlCommand(sqlBank, con);
                SqlDataReader dsBank = cmdBank.ExecuteReader(CommandBehavior.CloseConnection);
                dsBank.Read(); 
                if (dsBank["Name"] != DBNull.Value)
                {
                    dr[7] = dsBank["Name"].ToString();
                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();                
            }            
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        catch (Exception ex)
        { }
        finally
        {
            
        }


    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        con.Open();
        PaidTo = fun.getCode(txtPaidto.Text);
        this.FillGrid_Creditors(PaidTo);
        con.Close();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string getRandomKey = fun.GetRandomAlphaNumeric();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
            if (e.CommandName == "Sel")
            {

                Response.Redirect("BankVoucher_Print_Details.aspx?Id=" + id + "&ModId=11&SubModId=114&Key=" + getRandomKey + "");
            }
            if (e.CommandName == "Adv")
            {

                Response.Redirect("BankVoucher_Advice_print.aspx?Id=" + id + "&ModId=11&SubModId=114&Key=" + getRandomKey + "");
            }
        }
        catch (Exception ex) { }
    }
    public void Loaddata(string receivedfrom)
    {
     try
        {            
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (txtReceivedFrom.Text != "")
            {
                if (fun.getCode(txtReceivedFrom.Text)!=string.Empty)
                {

                    x = " And ReceivedFrom like'%" + receivedfrom + "%'";
                }
                else
                {
                    x = " And ReceivedFrom like'%" + txtReceivedFrom.Text + "%'";
                }
            }
            else
            {
                x = "";
            }

            string StrSql = fun.select("*", "tblACC_BankVoucher_Received_Masters", "FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'" + x + " order by Id Desc");
           
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataReader DSSql = cmdSql.ExecuteReader(CommandBehavior.CloseConnection);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BVRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Types", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ReceivedFrom", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("InvoiceNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeReceivedBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BankName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BankAccNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeClearanceDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Narration", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("WONoBG", typeof(string)));

            DataRow dr;
            while (DSSql.Read())
            {
                dr = dt.NewRow();
                //if (DSSql.Tables[0].Rows.Count > 0)
                {                    
                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSSql["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataReader DSFin = cmdFinYr.ExecuteReader();
                    DSFin.Read();
                    if (DSFin["FinYear"] != DBNull.Value)
                    {
                        dr[1] = DSFin["FinYear"].ToString();
                    }
                    dr[0] = DSSql["Id"].ToString();
                    dr[2] = DSSql["BVRNo"].ToString();
                    string Sqltyp = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + DSSql["Types"].ToString() + "'");
                    SqlCommand cmdtyp = new SqlCommand(Sqltyp, con);
                    SqlDataReader DStyp = cmdtyp.ExecuteReader(CommandBehavior.CloseConnection);
                    DStyp.Read(); 
                    if (DStyp["Description"] != DBNull.Value)
                    {
                        dr[3] = DStyp["Description"].ToString();
                    }

                    int ac1 = Convert.ToInt32(DSSql["ReceiveType"]);
                    string ReceivedFrom = "";

                    if (ac1 == 4)
                    {
                        ReceivedFrom = DSSql["ReceivedFrom"].ToString();
                    }
                    else
                    {
                        string cmdStr = "";
                        switch (ac1)
                        {
                            case 1:
                                cmdStr = fun.select("EmployeeName+' ['+EmpId+ ' ]'", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + DSSql["ReceivedFrom"] + "'   Order By EmployeeName ASC");
                                break;
                            case 2:
                                cmdStr = fun.select("CustomerName+' ['+CustomerId+']'", "SD_Cust_master", "CompId='" + CompId + "'And CustomerId='" + DSSql["ReceivedFrom"] + "' Order By CustomerName ASC");
                                break;
                            case 3:
                                cmdStr = fun.select("SupplierName+' ['+SupplierId+']'", "tblMM_Supplier_master", "CompId='" + CompId + "'And SupplierId='" + DSSql["ReceivedFrom"] + "' Order By SupplierName ASC");
                                break;
                        }

                        SqlCommand cmdDSESC = new SqlCommand(cmdStr, con);
                        SqlDataReader DSESC = cmdDSESC.ExecuteReader(CommandBehavior.CloseConnection);
                        DSESC.Read();
                        ReceivedFrom = DSESC[0].ToString();
                    }

                    dr[4] = ReceivedFrom;


                    //////////////


                    string InvoiceNo = DSSql["InvoiceNo"].ToString();
                    string NFDD = "";
                    string a = InvoiceNo;
                    NFDD = InvoiceNo.Replace(",", ", ");
                   
                    dr[5] = NFDD;
                    dr[6] = DSSql["ChequeNo"].ToString();
                    dr[7] = fun.FromDateDMY(DSSql["ChequeDate"].ToString());
                    dr[8] = fun.EmpCustSupplierNames(1, DSSql["ChequeReceivedBy"].ToString(), CompId);
                    dr[9] = DSSql["BankName"].ToString();
                    dr[10] = DSSql["BankAccNo"].ToString();
                    dr[11] = fun.FromDateDMY(DSSql["ChequeClearanceDate"].ToString());
                    dr[12] = (DSSql["Narration"].ToString());
                    dr[13] = Convert.ToDouble(DSSql["Amount"]);
                    string WONoBG = "";

                    if (DSSql["WONo"] != DBNull.Value && DSSql["BGGroup"] != DBNull.Value)
                    {
                        if (DSSql["WONo"].ToString() == "")
                        {

                            string sqlBG = fun.select("Id,Symbol", "BusinessGroup", "Id='" + DSSql["BGGroup"].ToString() + "'");
                            SqlCommand cmdBG = new SqlCommand(sqlBG, con);
                            SqlDataReader DSBG = cmdBG.ExecuteReader();
                            DSBG.Read();
                            if (DSBG["Symbol"] != DBNull.Value)
                            {
                                WONoBG = DSBG["Symbol"].ToString();
                            }
                        }
                        else
                        {
                            WONoBG = (DSSql["WONo"].ToString());
                        }
                    }

                    dr[14] = WONoBG;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                
            }
            GridView6.DataSource = dt;
            GridView6.DataBind();
        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
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
        string cmdStr = "Select EmployeeName+'['+EmpId+']' AS AllName  from tblHR_OfficeStaff where CompId='" + CompId + "' union select CustomerName+'['+CustomerId+']' AS AllName from SD_Cust_master where CompId='" + CompId + "' union select SupplierName+'['+SupplierId+']' AS AllName from tblMM_Supplier_master where CompId='" + CompId + "'";
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblACC_CashVoucher_Payment_Master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //+ " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]"
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
            con.Open();
            PaidTo = fun.getCode(txtPaidto.Text);
            this.FillGrid_Creditors(PaidTo);
        }
        catch (Exception ex) { }

        finally
        {
            con.Close();
        }
    }
    protected void btnSearchReceivedFrom_Click(object sender, EventArgs e)
    {
        try
        {
           
            ReceivedFrom = fun.getCode(txtReceivedFrom.Text);
            this.Loaddata(ReceivedFrom);
        }
        catch (Exception ex) { }        
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {

        try
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                this.FillGrid_Creditors(PaidTo);
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                this.Loaddata(ReceivedFrom);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            
        }
    }
}




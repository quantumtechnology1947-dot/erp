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

public partial class Module_Accounts_Transactions_BankVoucher_Delete : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";

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
                this.FillGrid_Creditors();
                this.Loaddata();
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
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       try
        {
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_BankVoucher_Payment_Details","MId='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
           
            string str = fun.select("*", "tblACC_BankVoucher_Payment_Details","MId='" + id + "'");
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlDataReader DS1 = cmd1.ExecuteReader();
            DS1.Read(); 
            if (DS1.HasRows!=true)
            {
                SqlCommand cmd2 = new SqlCommand(fun.delete("tblACC_BankVoucher_Payment_Master", "Id='" + id + "'"), con);
                cmd2.ExecuteNonQuery();
            }

            this.FillGrid_Creditors();
            con.Close();
        }
        catch (Exception er) { }

    }
    public void FillGrid_Creditors()
    {
      try
        {
            DataTable dt = new DataTable();
            string x = "";
            if (txtbvp_No.Text != "")
            {
                x = " And BVPNo='" + txtbvp_No.Text + "'";
            }
            string str = "SELECT * FROM tblACC_BankVoucher_Payment_Master where CompId='"+CompId+"' And FinYearId<='"+FinYearId+"'"+x+" Order By Id desc";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataReader DSCustWo = cmdCustWo.ExecuteReader();
            dt.Columns.Add(new System.Data.DataColumn("BVPNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeOfVoucher", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PaidTo", typeof(string)));            
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Bank", typeof(string)));
            DataRow dr;
            
            while(DSCustWo.Read())
            {
                dr = dt.NewRow();

                dr[0] = DSCustWo["BVPNo"].ToString();

                int ac = Convert.ToInt32(DSCustWo["Type"]);
                switch (ac)
                {
                    case 1:
                        dr[1]="Advance";
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

                dr[2] = fun.EmpCustSupplierNames(Convert.ToInt32(DSCustWo["ECSType"].ToString()), DSCustWo["PayTo"].ToString(), CompId);
                dr[3] = DSCustWo["Id"].ToString();
                dr[5] = fun.FromDateDMY(DSCustWo["ChequeDate"].ToString());               
                dr[4] = DSCustWo["ChequeNo"].ToString();               
                
                double DtlsAmt = 0;
                string sqlAmt2 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + DSCustWo["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type='" + Convert.ToInt32(DSCustWo["Type"]) + "'";

                SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                SqlDataReader dsstk6 = cmd6.ExecuteReader();
                dsstk6.Read();

                if (dsstk6["Amt"] != DBNull.Value)
                {
                    DtlsAmt = Convert.ToDouble(dsstk6["Amt"]);
                }

                double PayAmy_M = 0;
                PayAmy_M = Convert.ToDouble(DSCustWo["PayAmt"]);
                dr[6] = DtlsAmt + PayAmy_M;

                string sqlBank = fun.select("Name", "tblACC_Bank", "Id='" + DSCustWo["Bank"].ToString() + "'");
                SqlCommand cmdBank = new SqlCommand(sqlBank, con);
                SqlDataReader dsBank = cmdBank.ExecuteReader();
                dsBank.Read();
                if (dsBank[0] != DBNull.Value)
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


    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex; 
        con.Open();
        this.FillGrid_Creditors();
        con.Close();
    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {

            try
            {
                con.Open();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Id = ((Label)row.FindControl("lblIdR")).Text;
                string Str = fun.delete("tblACC_BankVoucher_Received_Masters", " Id='" + Id + "'");
                SqlCommand cmd = new SqlCommand(Str, con);
                cmd.ExecuteNonQuery();
                this.Loaddata();
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }


    }
    public void Loaddata()
    {
       try
        {
            DataTable dt = new DataTable();

            string x = "";
            if (txtbvr_No.Text != "")
            {
                x = " And BVRNo='" + txtbvr_No.Text + "'";
            }
            string StrSql = fun.select("*", "tblACC_BankVoucher_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'"+x+" Order By Id desc");
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataReader DSSql = cmdSql.ExecuteReader();
          
            //SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            //DataSet DSSql = new DataSet();
            //daSql.Fill(DSSql);

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
                // if (DSSql.Tables[0].Rows.Count > 0)
                {
                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSSql["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataReader DSFin = cmdFinYr.ExecuteReader();
                    DSFin.Read();
                    //SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    //DataSet DSFin = new DataSet();
                    //daFin.Fill(DSFin);

                    dr[0] = DSSql["Id"].ToString();

                    if (DSFin["FinYear"] != DBNull.Value)
                    {
                        dr[1] = DSFin["FinYear"].ToString();
                    }

                    dr[2] = DSSql["BVRNo"].ToString();

                    string Sqltyp = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + DSSql["Types"].ToString() + "'");
                    SqlCommand cmdtyp = new SqlCommand(Sqltyp, con);
                    SqlDataReader DStyp = cmdtyp.ExecuteReader();
                    DStyp.Read();
                    //SqlDataAdapter datyp = new SqlDataAdapter(cmdtyp);
                    //DataSet DStyp = new DataSet();
                    //datyp.Fill(DStyp);

                    if (DStyp["Description"] != DBNull.Value)
                    {
                        dr[3] = DStyp["Description"].ToString();
                    }
                    dr[4] = DSSql["ReceivedFrom"].ToString();
                    //dr[5] = DSSql["InvoiceNo"].ToString();
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
                        if(DSSql["WONo"]== "")
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

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        con.Open();
        this.FillGrid_Creditors();
        con.Close();
    }


    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        con.Open();
        this.Loaddata();
        con.Close();
    }
}

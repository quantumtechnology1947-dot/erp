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

public partial class Module_Accounts_Transactions_Advice_Delete : System.Web.UI.Page
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
    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      try
        {
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblACC_Advice_Payment_Details", "MId='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            string str = fun.select("*", "tblACC_Advice_Payment_Details", "MId='" + id + "'");
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet DS1 = new DataSet();
            da1.Fill(DS1);
            if (DS1.Tables[0].Rows.Count == 0)
            {
                SqlCommand cmd2 = new SqlCommand(fun.delete("tblACC_Advice_Payment_Master", "Id='" + id + "'"), con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }


            this.FillGrid_Creditors();
        }
       catch (Exception er) { }
    }

    public void FillGrid_Creditors()
    {
        try
        {

            DataTable dt = new DataTable();

            string str = "SELECT * FROM tblACC_Advice_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' Order By Id desc";
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            dt.Columns.Add(new System.Data.DataColumn("ADNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeOfVoucher", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PaidTo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChequeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Bank", typeof(string)));
            DataRow dr;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();

                dr[0] = DSCustWo.Tables[0].Rows[i]["ADNo"].ToString();

                int ac = Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["Type"]);
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

                dr[2] = fun.EmpCustSupplierNames(Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["ECSType"].ToString()), DSCustWo.Tables[0].Rows[i]["PayTo"].ToString(), CompId);

                dr[3] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();
                dr[5] = fun.FromDateDMY(DSCustWo.Tables[0].Rows[i]["ChequeDate"].ToString());
                dr[4] = DSCustWo.Tables[0].Rows[i]["ChequeNo"].ToString();

                double DtlsAmt = 0;
                string sqlAmt2 = "Select Sum(Amount)As Amt from tblACC_Advice_Payment_Details inner join tblACC_Advice_Payment_Master on tblACC_Advice_Payment_Details.MId=tblACC_Advice_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_Advice_Payment_Details.MId='" + DSCustWo.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_Advice_Payment_Master.Type='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["Type"]) + "'";
                SqlCommand cmd6 = new SqlCommand(sqlAmt2, con);
                SqlDataAdapter dastk6 = new SqlDataAdapter(cmd6);
                DataSet dsstk6 = new DataSet();
                dastk6.Fill(dsstk6);
                if (dsstk6.Tables[0].Rows.Count > 0 && dsstk6.Tables[0].Rows[0]["Amt"] != DBNull.Value)
                {
                    DtlsAmt = Convert.ToDouble(decimal.Parse((dsstk6.Tables[0].Rows[0]["Amt"]).ToString()).ToString("N3"));
                }

                dr[6] = DtlsAmt;


                string sqlBank = "Select Name from tblACC_Bank inner join tblACC_Advice_Payment_Master on tblACC_Bank.Id=tblACC_Advice_Payment_Master.Bank And tblACC_Advice_Payment_Master.CompId='" + CompId + "'";
                SqlCommand cmdBank = new SqlCommand(sqlBank, con);
                SqlDataAdapter daBank = new SqlDataAdapter(cmdBank);
                DataSet dsBank = new DataSet();
                daBank.Fill(dsBank);
                if (dsBank.Tables[0].Rows.Count > 0 && dsBank.Tables[0].Rows[0][0] != DBNull.Value)
                {
                    dr[7] = dsBank.Tables[0].Rows[0]["Name"].ToString();
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
        this.FillGrid_Creditors();
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
                string Str = fun.delete("tblACC_Advice_Received_Masters", " Id='" + Id + "'");
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
            string StrSql = fun.select("*", "tblACC_Advice_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'");
            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            DataSet DSSql = new DataSet();
            daSql.Fill(DSSql);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ADRNo", typeof(string)));
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

            DataRow dr;
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (DSSql.Tables[0].Rows.Count > 0)
                {

                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSSql.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);
                    dr[0] = DSSql.Tables[0].Rows[i]["Id"].ToString();
                    if (DSFin.Tables[0].Rows.Count > 0)
                    {
                        dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                    }
                    dr[2] = DSSql.Tables[0].Rows[i]["ADRNo"].ToString();

                    string Sqltyp = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + DSSql.Tables[0].Rows[i]["Types"].ToString() + "'");
                    SqlCommand cmdtyp = new SqlCommand(Sqltyp, con);
                    SqlDataAdapter datyp = new SqlDataAdapter(cmdtyp);
                    DataSet DStyp = new DataSet();
                    datyp.Fill(DStyp);
                    if (DStyp.Tables[0].Rows.Count > 0)
                    {
                        dr[3] = DStyp.Tables[0].Rows[0]["Description"].ToString();
                    }
                    dr[4] = DSSql.Tables[0].Rows[i]["ReceivedFrom"].ToString();
                    dr[5] = DSSql.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    dr[6] = DSSql.Tables[0].Rows[i]["ChequeNo"].ToString();
                    dr[7] = fun.FromDateDMY(DSSql.Tables[0].Rows[i]["ChequeDate"].ToString());
                    dr[8] = fun.EmpCustSupplierNames(1, DSSql.Tables[0].Rows[i]["ChequeReceivedBy"].ToString(), CompId);
                    dr[9] = DSSql.Tables[0].Rows[i]["BankName"].ToString();
                    dr[10] = DSSql.Tables[0].Rows[i]["BankAccNo"].ToString();
                    dr[11] = fun.FromDateDMY(DSSql.Tables[0].Rows[i]["ChequeClearanceDate"].ToString());
                    dr[12] = (DSSql.Tables[0].Rows[i]["Narration"].ToString());
                    dr[13] = Convert.ToDouble(DSSql.Tables[0].Rows[i]["Amount"]);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }
            GridView6.DataSource = dt;
            GridView6.DataBind();
        }
        catch (Exception ex) { }

    }
}

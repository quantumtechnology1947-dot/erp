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

public partial class Module_Accounts_Transactions_Advice_Print : System.Web.UI.Page
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

            }
        }
        catch (Exception ex)
        {
        }
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


                string Abc;
                int num1;
                if (DSCustWo.Tables[0].Rows[i]["NameOnCheque"].ToString() == "" || DSCustWo.Tables[0].Rows[i]["NameOnCheque"] == DBNull.Value)
                {
                    if (int.TryParse(DSCustWo.Tables[i].Rows[0]["PaidType"].ToString(), out num1))
                    {

                        string stre = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["PaidType"]) + "'");
                        SqlCommand cmde = new SqlCommand(stre, con);
                        SqlDataAdapter dae = new SqlDataAdapter(cmde);
                        DataSet DSe = new DataSet();
                        dae.Fill(DSe);
                        Abc = DSe.Tables[0].Rows[0]["Particulars"].ToString();

                    }
                    else
                    {

                        Abc = fun.ECSNames(Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["ECSType"].ToString()), DSCustWo.Tables[0].Rows[i]["PayTo"].ToString(), CompId);
                    }


                }


                else
                {

                    Abc = DSCustWo.Tables[0].Rows[i]["NameOnCheque"].ToString();
                }




                dr[2] = Abc;

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
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string getRandomKey = fun.GetRandomAlphaNumeric();

            if (e.CommandName == "Sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                Response.Redirect("Advice_Print_Details.aspx?Id=" + id + "&ModId=11&SubModId=119&Key=" + getRandomKey + "");
            }


            if (e.CommandName == "Adv")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                Response.Redirect("Advice_Print_Advice.aspx?Id=" + id + "&ModId=11&SubModId=119&Key=" + getRandomKey + "");
            }
        }
        catch (Exception ex) { }
    }




}

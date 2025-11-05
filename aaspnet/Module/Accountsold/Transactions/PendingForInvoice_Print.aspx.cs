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

public partial class Module_Accounts_Transactions_PendingForInvoice_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int FinYearId = 0;
    int CompId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            if (!Page.IsPostBack)
            {
                txtpoNo.Visible = false;
                txtCustName.Visible = false;
            }

        }
        catch (Exception ex) { }

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "0")
            {
                txtpoNo.Visible = false;
                txtCustName.Visible = false;
                txtCustName.Text =string.Empty;
                txtpoNo.Text = string.Empty;
                Iframe1.Visible = false;
            }
            if (DropDownList1.SelectedValue == "1")
            {
                txtpoNo.Visible = false;
                txtCustName.Visible = true;
                txtCustName.Text = string.Empty;
                Iframe1.Visible = false;
            }

            if (DropDownList1.SelectedValue == "2")
            {
                txtpoNo.Visible = true;
                txtCustName.Visible = false;
                txtpoNo.Text = string.Empty;
                Iframe1.Visible = false;
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
        string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "'");
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
           string getRandomKey = fun.GetRandomAlphaNumeric();
            string C = "";
            string W = "";
            if (DropDownList1.SelectedValue.ToString() == "0")
            {
                C = string.Empty;
                W = string.Empty;
                Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + C + "&W=" + W + "&Val=" + DropDownList1.SelectedValue + "&Key=" + getRandomKey + "");
                Iframe1.Visible = true;
            }
            if (DropDownList1.SelectedValue.ToString() == "1")
            {
                if (txtCustName.Text != string.Empty)
                {
                    string CustomerId = fun.getCode(txtCustName.Text);
                    int CustomerId1 = fun.chkCustomerCode(CustomerId);
                    if (CustomerId1 == 1) 
                    {
                        C = CustomerId;
                        Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + C + "&W=" + W + "&Val=" + DropDownList1.SelectedValue + "&Key=" + getRandomKey + "");
                        Iframe1.Visible = true;
                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        string myStringVariable2 = "Customer is not valid";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable2 + "');", true);

                    }
                }
                if (txtCustName.Text == string.Empty)
                {
                    string myStringVariable = string.Empty;
                    string myStringVariable2 = "Customer is not valid";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable2 + "');", true);
                }

            }
            if (DropDownList1.SelectedValue.ToString() == "2")
            {
                if (txtpoNo.Text != string.Empty)
                {
                    if (fun.CheckValidWONo(txtpoNo.Text, CompId, FinYearId) == true)
                    {
                        W = txtpoNo.Text;
                        Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + C + "&W=" + W + "&Val=" + DropDownList1.SelectedValue + "&Key=" + getRandomKey + "");
                        Iframe1.Visible = true;
                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        string myStringVariable2 = "WONo is not valid";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable2 + "');", true);
                    }
                }
                if (txtpoNo.Text == string.Empty)
                {
                    string myStringVariable = string.Empty;
                    string myStringVariable2 = "WONo is not valid";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable2 + "');", true);
                }
            }
           
        }
       catch (Exception ex) { }
    }

}

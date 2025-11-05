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

public partial class Module_Accounts_Reports_Search : System.Web.UI.Page
{
   clsFunctions fun = new clsFunctions();    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.AcHead();
            }

            if (Drpoption.SelectedValue == "0")
            {
                txtNo.Enabled = false;
            }
            else
            {
                txtNo.Enabled = true;
            }
            if (radGqn.Checked == true)
            {
                Drpoption.Items[2].Enabled = false;
                Drpoption.Items[1].Enabled = true;
            }
            else
            {
                Drpoption.Items[2].Enabled = true;
                Drpoption.Items[1].Enabled = false;
            }
        }

        catch(Exception ex)
        {
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        try
        {

            int rad = 0;
            int rad2 = 0;
            string no = "";
            if (txtNo.Text != "")
            {
                no = txtNo.Text;

            }
            string Itemcode = "";
            if (CkItem.Checked == true)
            {
                Itemcode = txtItemcode.Text;
            }

            string wono = "";
            if (CKwono.Checked == true)
            {
                wono = txtwono.Text;
            }
            string Spid = "";
            if (CkSupplier.Checked == true)
            {

                Spid = fun.getCode(TxtSearchValue.Text);
            }

            string FDate = "";
            string TDate = "";
            if (textFromDate.Text != "" && TextToDate.Text != "")
            {
                FDate = textFromDate.Text;
                TDate = TextToDate.Text;
            }
            int cnt = 0;
            if (textFromDate.Text != "" && TextToDate.Text == "")
            {
                cnt++;
            }
            if (textFromDate.Text == "" && TextToDate.Text != "")
            {
                cnt++;
            }

            int accval = 0;
            if (CkACCHead.Checked == true)
            {
                accval = Convert.ToInt32(DropDownList1.SelectedValue);
            }
            if (RadGin.Checked == true)
            {
                rad = 1;
            }

            else
            {
                rad = 0;
            }

            if (radGqn.Checked == true)
            {
                rad2 = 1;
            }

            else
            {
                rad2 = 0;
            }

            if (cnt == 0)
            {
                if ((Drpoption.SelectedItem.Text != "All") && (txtNo.Text != "") || (Drpoption.SelectedItem.Text == "All") && (txtNo.Enabled == false))
                {
                    if (CkItem.Checked == true && txtItemcode.Text != "" || CkItem.Checked == false && txtItemcode.Text == "")
                    {
                        if (CKwono.Checked == true && txtwono.Text != "" || CKwono.Checked == false && txtwono.Text == "")
                        {
                            if (CkSupplier.Checked == true && TxtSearchValue.Text != "" || CkSupplier.Checked == false && TxtSearchValue.Text == "")
                            {

                                Response.Redirect("Search_details.aspx?type=" + Drpoption.SelectedValue + "&No=" + no + "&RAd2=" + rad2 + "&RAd=" + rad + "&Code=" + Itemcode + "&WONo=" + wono + "&SupId=" + Spid + "&accval=" + accval + "&FDate=" + FDate + "&TDate=" + TDate + "");
                            }
                            else
                            {
                                string mystring = string.Empty;
                                mystring = "Enter valid  " + CkSupplier.Text + "!";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                            }

                        }
                        else
                        {
                            string mystring = string.Empty;
                            mystring = "Enter valid  " + CKwono.Text + "!";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                        }
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Enter valid  " + CkItem.Text + "!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    if (Drpoption.SelectedValue == "1" || Drpoption.SelectedValue == "2" || Drpoption.SelectedValue == "3" || Drpoption.SelectedValue == "4")
                    {
                        mystring = "Enter valid  " + Drpoption.SelectedItem.Text + "!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Incorrect date entry!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch(Exception ex)
        {
        }
        
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
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_master");
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
    
    public void AcHead()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            string x = "";
            if (RbtnLabour.Checked == true)
            {
                x = "Labour";
            }

            if (RbtnWithMaterial.Checked == true)
            {
                x = "With Material";
            }

            if (RbtnExpenses.Checked == true)
            {
                x = "Expenses";
            }

            if (RbtnServiceProvider.Checked == true)
            {
                x = "Service Provider";
            }

            string cmdStrLabour = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + x + "'");
            SqlCommand cmdLabour = new SqlCommand(cmdStrLabour, con);
            SqlDataAdapter DALabour = new SqlDataAdapter(cmdLabour);
            DataSet DSLabour = new DataSet();
            DALabour.Fill(DSLabour, "AccHead");

            DropDownList1.DataSource = DSLabour;
            DropDownList1.DataTextField = "Head";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
        }
        catch (Exception ex) { }
    }
   
    protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();
    }
    protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();
    }

    protected void RbtnExpenses_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();
    }
    protected void RbtnServiceProvider_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
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
    //--------------------------------------------------------------------------------------------------
    protected void CkItem_CheckedChanged(object sender, EventArgs e)
    {
        if(CkItem.Checked==true)
        {
            txtItemcode.Enabled = true;
        }
        else
        {
            txtItemcode.Enabled = false;
        }
    }
    protected void CKwono_CheckedChanged(object sender, EventArgs e)
    {
        if (CKwono.Checked == true)
        {
            txtwono.Enabled = true;
        }
        else
        {
            txtwono.Enabled = false;
        }
    }
    protected void CkSupplier_CheckedChanged(object sender, EventArgs e)
    {
        if (CkSupplier.Checked == true)
        {
            TxtSearchValue.Enabled = true;
        }
        else
        {
            TxtSearchValue.Enabled = false;
        }

    }
    protected void radGqn_CheckedChanged(object sender, EventArgs e)
    {
        if (radGqn.Checked == true)
        {
            Drpoption.Items[2].Enabled=false;
            Drpoption.Items[1].Enabled = true;
        }
        
    }
    protected void radgsn_CheckedChanged(object sender, EventArgs e)
    {
        if (radgsn.Checked == true)
        {
            Drpoption.Items[1].Enabled = false;
            Drpoption.Items[2].Enabled = true;
        }
    }
}


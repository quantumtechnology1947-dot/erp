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

public partial class Module_Accounts_Transactions_BillBooking_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SupId = "";
    string PONo = "";
    string SId = "";
    int CompId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();

            if (!Page.IsPostBack)
            {
                this.loadData(SupId);
            }
            string DSBN = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
            SqlCommand commanddel = new SqlCommand(DSBN, con);
            commanddel.ExecuteNonQuery();

            string strDelete = fun.delete("tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
            SqlCommand cmddelete = new SqlCommand(strDelete, con);
            cmddelete.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception ex)
        {

        }
    }

    public void loadData(string spid)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            DataTable dt = new DataTable();

            string sId = Session["username"].ToString();
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            int CompId = Convert.ToInt32(Session["compid"]);

            con.Open();

            if (DropDownList1.SelectedValue == "Select")
            {
                txtSupplier.Visible = false;
            }

            string x = "";
            if (DropDownList1.SelectedValue == "0")
            {
                if (txtSupplier.Text != "")
                {
                    x = " And SupplierId='" + spid + "'";
                }
            }

            string StrSql = fun.select("SupId,SupplierName,SupplierId", "tblMM_Supplier_master", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'" + x + " AND SupId!=417 AND SupplierId!='S098' Order by SupplierId ASC");

            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
            DataSet DSSql = new DataSet();
            dasupId.Fill(DSSql);

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Supplier", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupId", typeof(string)));

            DataRow dr;

            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = DSSql.Tables[0].Rows[i]["SupId"].ToString();
                dr[1] = DSSql.Tables[0].Rows[i]["SupplierName"].ToString();
                dr[2] = DSSql.Tables[0].Rows[i]["SupplierId"].ToString();

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();
        }
        catch (Exception et)
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
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
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
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sel")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Supid = ((Label)row.FindControl("lblsupId")).Text;
                string Fgt = ((TextBox)row.FindControl("txtFreight")).Text;
                string StateType = ((DropDownList)row.FindControl("ddlMhOms")).SelectedValue;
                if (((DropDownList)row.FindControl("ddlMhOms")).SelectedValue!="Select")
                {
                    Response.Redirect("BillBooking_New_Details.aspx?SUPId=" + Supid + "&FGT=" + Fgt + "&ST=" + StateType + "&ModId=11&SubModId=62");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Select type of Invoice!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }

            }
        }
        catch (Exception ex) { }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.loadData(SupId);

        }
        catch (Exception ex) { }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Spid = "";
            Spid = fun.getCode(txtSupplier.Text);
            this.loadData(Spid);
        }
        catch (Exception ex) { }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "0")
            {
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.loadData(SupId);
            }
            else
            {
                txtSupplier.Visible = false;
                this.loadData(SupId);
            }
        }
        catch (Exception ex) { }
    }

    protected void ddlMhOms_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

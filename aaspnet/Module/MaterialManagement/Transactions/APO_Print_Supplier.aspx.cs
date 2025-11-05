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

public partial class Module_MaterialManagement_Transactions_APO_Print_Supplier : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    string SupCode = "";
    int CompId = 0;
    string FyId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Session["finyear"].ToString();

            if (!IsPostBack)
            {
                this.LoadData(SupCode);
            }
        }
        catch (Exception est)
        {

        }
    }

    public void LoadData(string supcode) // PO Items
    {

        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("POCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("POSupplier", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("POItems", typeof(int)));

            DataRow dr;
            string x = "";
            if (supcode != "")
            {
                x = " AND SupplierId='" + SupCode + "'";
            }

            string sql = fun.select("SupplierId,SupplierName", "tblMM_Supplier_masterA", "CompId='" + CompId + "'" + x + "Order by SupId Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                // For Supplier Id
                dr[0] = DS.Tables[0].Rows[p]["SupplierId"].ToString();
                dr[1] = DS.Tables[0].Rows[p]["SupplierName"].ToString();

                // for NO .OF Items
                string sql3 = fun.select("*", "tblMM_PO_MasterA", "CompId='" + CompId + "' AND SupplierId='" + DS.Tables[0].Rows[p]["SupplierId"].ToString() + "' AND FinYearId<='" + FyId + "'");

                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet DS3 = new DataSet();
                da3.Fill(DS3);

                dr[2] = DS3.Tables[0].Rows.Count;

                if (DS3.Tables[0].Rows.Count > 0)
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView5.DataSource = dt;
            GridView5.DataBind();
            con.Close();

            foreach (GridViewRow grv in GridView5.Rows)
            {
                if (((Label)grv.FindControl("lblpoitems")).Text == "0")
                {
                    ((LinkButton)grv.FindControl("lnkbutton")).Visible = false;
                }
                else
                {
                    ((LinkButton)grv.FindControl("lnkbutton")).Visible = true;
                }
            }

        }
        catch (Exception ex) { }

        finally
        {

        }
    }

    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string pocode = ((Label)row.FindControl("lblpocode")).Text;
                Response.Redirect("APO_Print.aspx?Code=" + pocode + "");
            }



        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView5.PageIndex = e.NewPageIndex;
        this.LoadData(SupCode);
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SupCode = fun.getCode(txtSearchSupplier.Text);
            this.LoadData(SupCode);
        }
        catch (Exception dtt)
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
        int CompId1 = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_masterA", "CompId='" + CompId1 + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_masterA");
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
}

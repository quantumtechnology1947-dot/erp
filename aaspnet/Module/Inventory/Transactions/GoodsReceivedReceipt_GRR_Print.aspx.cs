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

public partial class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Print : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    string SupId = "";
    string connStr = "";
    SqlConnection con;
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            if (!IsPostBack)
            {
                this.loadData(SupId);
            }
        }
        catch (Exception ex) { }
    }
    public void loadData(string spid)
    {
        try
        {
            con.Open();
            string x = "";
            if (txtSupplier.Text != "")
            {
                spid = fun.getCode(txtSupplier.Text);
                x = " And tblMM_PO_Master.SupplierId='" + spid + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("Sp_GRR_Edit", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@CompId"].Value = CompId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@FinId"].Value = FinYearId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@x"].Value = x;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView2.DataSource = DSitem;
            GridView2.DataBind();
            con.Close();

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
                string GrrNo = ((Label)row.FindControl("lblGrrNo")).Text;
                string GinNo = ((Label)row.FindControl("lblGin")).Text;
                string GinId = ((Label)row.FindControl("lblGinId")).Text;
                string poNo = ((Label)row.FindControl("lblpo")).Text;
                string fyid = ((Label)row.FindControl("lblFinId")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;
                string getRandomKey = fun.GetRandomAlphaNumeric();
                Response.Redirect("GoodsReceivedReceipt_GRR_Print_Details.aspx?Id=" + Id + "&GRRNo=" + GrrNo + "&GINNo=" + GinNo + "&GINId=" + GinId + "&PONo=" + poNo + "&FyId=" + fyid + "&Key=" + getRandomKey + "&ModId=9&SubModId=38");

            }

        }
        catch (Exception ex) { }

    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string sid = "";
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            if (txtSupplier.Text != "")
            {
                sid = fun.getCode(txtSupplier.Text);
                this.loadData(sid);
            }
            else
            {
                this.loadData(SupId);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sid = "";
        try
        {
            if (txtSupplier.Text != "")
            {                
                sid = fun.getCode(txtSupplier.Text);
                this.loadData(sid);
            }
            else
            {

               
                this.loadData(SupId);
            }
        }
        catch (Exception ex)
        { }
    }

}


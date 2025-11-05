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

public partial class Module_MaterialManagement_Transactions_APO_New : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();

    int CompId = 0;
    string SupCode = "";
    string FinYearId = "";
    string constr = string.Empty;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        constr = fun.Connection();
        con = new SqlConnection(constr);

        try
        {
            string sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Session["finyear"].ToString();

            if (!IsPostBack)
            {
                string delsql = fun.delete("tblMM_PR_Po_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' or  SessionId=''   ");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                con.Open();
                cmd12.ExecuteNonQuery();
                string delsql2 = fun.delete("tblMM_SPR_Po_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'   or  SessionId='' ");
                SqlCommand cmd2 = new SqlCommand(delsql2, con);
                cmd2.ExecuteNonQuery();
                con.Close();
                this.LoadPR(SupCode);
            }

        }
        catch (Exception est)
        {
        }
    }
   

    public void LoadData(string supcode) // SPR Items
    {
        try
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string x = string.Empty;
            if (supcode != "")
            {
                x = " AND tblMM_Supplier_masterA.SupplierId='" + SupCode + "'";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetSupplier_PO_SPRA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlParameter SupID = new SqlParameter("@SupId", SqlDbType.VarChar, 50);
            SupID.Value = x;
            SqlParameter CompId2 = new SqlParameter("@CompId", SqlDbType.VarChar, 20);
            CompId2.Value = CompId;
            SqlParameter FinId = new SqlParameter("@FinId", SqlDbType.VarChar, 20);
            FinId.Value = FinYearId;
            //SqlParameter tblName = new SqlParameter("@tblName", SqlDbType.VarChar, 50);
            //tblName.Value = "View_GetSupplier_POSPR";
            cmd.Parameters.Add(SupID);
            cmd.Parameters.Add(CompId2);
            cmd.Parameters.Add(FinId);
            //cmd.Parameters.Add(tblName);
            SqlDataReader prdr1 = cmd.ExecuteReader();
            dt.Load(prdr1);
            GridView5.DataSource = dt.DefaultView;
            GridView5.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }

    }
    public void LoadPR(string supcode) // PR Items
    {
        try
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == con.State)
                con.Open();
            string x = string.Empty;
            if (supcode != "")
            {
                x = " AND tblMM_Supplier_masterA.SupplierId='" + SupCode + "'";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetSupplier_PO_PR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlParameter SupID = new SqlParameter("@SupId", SqlDbType.VarChar, 50);
            SupID.Value = x;
            SqlParameter CompId2 = new SqlParameter("@CompId", SqlDbType.VarChar, 20);
            CompId2.Value = CompId;
            SqlParameter FinId = new SqlParameter("@FinId", SqlDbType.VarChar, 20);
            FinId.Value = FinYearId;
            //SqlParameter tblName = new SqlParameter("@tblName", SqlDbType.VarChar, 50);
            // tblName.Value = "View_GetSupplier_POPR";
            cmd.Parameters.Add(SupID);
            cmd.Parameters.Add(CompId2);
            cmd.Parameters.Add(FinId);
            //cmd.Parameters.Add(tblName);
            SqlDataReader prdr1 = cmd.ExecuteReader();
            dt.Load(prdr1);
            GridView2.DataSource = dt.DefaultView;
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string sprcode = ((Label)row.FindControl("lblsprcode")).Text;
                Response.Redirect("APO_SPR_Items.aspx?Code=" + sprcode + "&ModId=6&SubModId=35");

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
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);

        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_masterA", "CompId='" + CompId + "'");
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

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "selme")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string code = ((Label)row.FindControl("lblcode")).Text;
                Response.Redirect("PO_PR_Items.aspx?Code=" + code + "&ModId=6&SubModId=35");
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SupCode = fun.getCode(txtSupplierPR.Text);
            this.LoadPR(SupCode);

        }
        catch (Exception dtt)
        {

        }

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.LoadPR(SupCode);
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TabContainer1_ActiveTabChanged1(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 1)
        {

            this.LoadData(SupCode);

        }
        else
        {
            this.LoadPR(SupCode);

        }

    }

}

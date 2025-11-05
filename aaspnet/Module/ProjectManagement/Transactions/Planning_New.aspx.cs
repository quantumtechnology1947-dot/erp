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

public partial class Module_MaterialPlanning_Transactions_Plannning_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();    
    int FinYearId = 0;
    int CompId = 0;
    string CId2 = "";
    string Eid = "";
    string sId = "";
    int h = 0;
    string str = "";
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            str = fun.Connection();
            con = new SqlConnection(str);
            if (!Page.IsPostBack)
            {

                string sql2 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + sId + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);
                for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                {

                    string StrTemp2 = "delete from tblMP_Material_Process_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp2 = new SqlCommand(StrTemp2, con);
                    con.Open();
                    cmdTemp2.ExecuteNonQuery();
                    con.Close();

                    string StrTemp3 = "delete from tblMP_Material_RawMaterial_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp3 = new SqlCommand(StrTemp3, con);
                    con.Open();
                    cmdTemp3.ExecuteNonQuery();
                    con.Close();

                    string StrTemp4 = "delete from tblMP_Material_Finish_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp4 = new SqlCommand(StrTemp4, con);
                    con.Open();
                    cmdTemp4.ExecuteNonQuery();
                    con.Close();

                }

                string StrTemp5 = "delete from tblMP_Material_Detail_Temp where SessionId='" + sId + "' ";
                SqlCommand cmdTemp5 = new SqlCommand(StrTemp5, con);
                con.Open();
                cmdTemp5.ExecuteNonQuery();
                con.Close();               
                string StrCat = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
                SqlCommand Cmd = new SqlCommand(StrCat, con);
                DataSet DS = new DataSet();
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "tblSD_WO_Category");
                DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
                DDLTaskWOType.DataTextField = "Category";
                DDLTaskWOType.DataValueField = "CId";
                DDLTaskWOType.DataBind();
                DDLTaskWOType.Items.Insert(0, "WO Category");
                this.BindDataCust(CId2, Eid,h);
            }
        }
        catch (Exception ex) { }
    }

    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchGridView1.PageIndex = e.NewPageIndex;
        try
        {
            this.BindDataCust(CId2, Eid,h);
        }
        catch (Exception ex) { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            this.BindDataCust(CId2, Eid,h);
        }
        catch (Exception ex) { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx?ModId=3&SubModId=23");
    }
    protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "0")
            {
                txtSearchCustomer.Visible = false;
                TxtSearchValue.Visible = true;
                TxtSearchValue.Text = "";
                this.BindDataCust(CId2, Eid,h);
            }
            if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
            {
                txtSearchCustomer.Visible = true;
                TxtSearchValue.Visible = false;
                txtSearchCustomer.Text = "";
                this.BindDataCust(CId2, Eid,h);
            }
        }
        catch (Exception ex)
        { }
    }

    public void BindDataCust(string Cid, string EID, int C)
    {
        try
        {
            
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtSearchCustomer.Text != "")
                {
                    x = " AND EnqId='" + txtSearchCustomer.Text + "'";
                }
            }
            if (DropDownList1.SelectedValue == "2")
            {
                if (txtSearchCustomer.Text != "")
                {
                    x = " AND PONo='" + txtSearchCustomer.Text + "'";
                }
            }

            if (DropDownList1.SelectedValue == "3")
            {
                if (txtSearchCustomer.Text != "")
                {
                    x = " AND WONo='" + txtSearchCustomer.Text + "'";
                }
            }

            if (DropDownList1.SelectedValue == "Select")
            {
                txtSearchCustomer.Visible = true;
                TxtSearchValue.Visible = false;
            }

            string y = "";
            if (DropDownList1.SelectedValue == "0")
            {
                if (TxtSearchValue.Text != "")
                {
                    string Custid = fun.getCode(TxtSearchValue.Text);
                    y = " AND SD_Cust_WorkOrder_Master.CustomerId='" + Custid + "'";
                }
            }
            string Z = "";
            if (DDLTaskWOType.SelectedValue != "WO Category")
            {

                Z = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
            }

            string L = " And SD_Cust_WorkOrder_Master.WONo in (select WONo from tblDG_BOM_Master)";
            SqlDataAdapter da = new SqlDataAdapter("Sp_WONO_NotInBom", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@CompId"].Value = CompId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@FinId"].Value = FinYearId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@x"].Value = x;
            da.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@y"].Value = y;
            da.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@z"].Value = Z;
            da.SelectCommand.Parameters.Add(new SqlParameter("@l", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@l"].Value = L;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            SearchGridView1.DataSource = DSitem;
            SearchGridView1.DataBind();
        }

        catch (Exception ex)
        { }
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
    protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLTaskWOType.SelectedValue != "WO Category")
        {
            int k = Convert.ToInt32(DDLTaskWOType.SelectedValue);
            this.BindDataCust(CId2, Eid, k);
        }
        else
        {
            this.BindDataCust(CId2, Eid, h);
        }
    }
}

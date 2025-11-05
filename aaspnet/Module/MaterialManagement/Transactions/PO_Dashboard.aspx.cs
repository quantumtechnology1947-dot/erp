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

public partial class Module_MaterialManagement_Transactions_PO_Dashboard : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    string spr = "";
    string supcode = "";
    string FyId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();
            FyId = Session["finyear"].ToString();            

            if (!IsPostBack)
            {            
                txtPONo.Visible = false;
                this.makegrid(spr, supcode);              
                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();                

                string delsql = fun.delete("tblMM_PR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                cmd12.ExecuteNonQuery();

                string delsq2 = fun.delete("tblMM_SPR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                SqlCommand cmd13 = new SqlCommand(delsq2, con);
                cmd13.ExecuteNonQuery();
                con.Close();
            }
        }

        catch(Exception ex){}
    }

    public void makegrid(string sprno, string supcode)
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CheckedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ApprovedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Sup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Code", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmendmentNo", typeof(string)));
            DataRow dr;
            
            CompId = Convert.ToInt32(Session["compid"]);

            string x = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtPONo.Text != "")
                {
                    x = "AND PONo='" + txtPONo.Text + "'";
                }
            }

            string sql = fun.select("*", "tblMM_PO_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "'" + x + " AND Authorize='0' Order by Id Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
           
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName,EmpId", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND EmpId='" + DS.Tables[0].Rows[p]["SessionId"].ToString() + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);

                string z = "";

                if (drpfield.SelectedValue == "0")
                {
                    if (txtSupplier.Text != "")
                    {
                        z = " AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'";
                    }
                    else
                    {
                        z = " AND SupplierId='" + DS.Tables[0].Rows[p]["SupplierId"].ToString() + "'";
                    }
                }
                else
                {
                    z = " AND SupplierId='" + DS.Tables[0].Rows[p]["SupplierId"].ToString() + "'";
                }

                string sql3 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + z);
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet DS3 = new DataSet();
                da3.Fill(DS3);

                dr[0] = DS.Tables[0].Rows[p]["PONo"].ToString();
                dr[1] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString());
                dr[2] = DS.Tables[0].Rows[p]["SysTime"].ToString();
                if (DS2.Tables[0].Rows.Count>0)
                {
                dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Checked"]) == 1)
                {
                    dr[4] = fun.FromDateDMY(DS.Tables[0].Rows[p]["CheckedDate"].ToString());
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Approve"]) == 1)
                {
                    dr[5] = fun.FromDateDMY(DS.Tables[0].Rows[p]["ApproveDate"].ToString());
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                {
                    dr[6] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                }

                dr[7] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[8] = DS3.Tables[0].Rows[0]["SupplierName"].ToString();
                dr[9] = DS.Tables[0].Rows[p]["SupplierId"].ToString();

                string stryr = fun.select("FinYear", "tblFinancial_master", "CompId='"+CompId+"' AND FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                dr[10] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                dr[11] = DS.Tables[0].Rows[p]["AmendmentNo"].ToString();
                if (DS.Tables[0].Rows[p]["SupplierId"].ToString() == DS3.Tables[0].Rows[0]["SupplierId"].ToString())
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }

            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            con.Close();
        }
        catch (Exception ess)
        {

        }
    }
    string parentPage = "PO_Dashboard.aspx";
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "view")
            {
                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string pocode = ((Label)row.FindControl("lblsprno")).Text;
                string supcode = ((Label)row.FindControl("lblsupcode")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;
                string AmdNo = ((Label)row.FindControl("lblAmendmentNo")).Text;

                string StrFlag = fun.select("PRSPRFlag", "tblMM_PO_Master", "Id='" + Id + "' AND FinYearId<='" + FyId + "' AND SupplierId='" + supcode + "' And PONo='" + pocode + "' AND CompId='"+CompId+"'");
                SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                DataSet DSFlag = new DataSet();
                daFlag.Fill(DSFlag);
                
                if (DSFlag.Tables[0].Rows.Count>0)
                {
                if (DSFlag.Tables[0].Rows[0][0].ToString() == "0")
                {
                    string Trans = string.Empty;
                    string getRandomKey = fun.GetRandomAlphaNumeric();  
                  Response.Redirect("PO_PR_View_Print_Details.aspx?mid=" + Id + "&pono=" + pocode + "&Code=" + supcode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&Trans=" + Trans + "&ModId=6&SubModId=35&parentpage=" + parentPage);
                   
                }
                else
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("PO_SPR_View_Print_Details.aspx?mid=" + Id + "&pono=" + pocode + "&Code=" + supcode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&ModId=6&SubModId=35&parentpage=" + parentPage);
                   
                }
                }
            }
        }
        catch (Exception ess)
        {

        }
    }
    
    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpfield.SelectedValue == "1")
        {
            txtPONo.Visible = true;
            txtPONo.Text = "";
            txtSupplier.Visible = false;
            this.makegrid(spr, supcode);  
        }

        if (drpfield.SelectedValue == "0")
        {
            txtSupplier.Visible = true;
            txtSupplier.Text = "";
            txtPONo.Visible = false;
            this.makegrid(spr, supcode);  
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.makegrid(txtPONo.Text, txtSupplier.Text);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList2(string prefixText, int count, string contextKey)
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
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.makegrid(spr, supcode);              
        }
        catch (Exception ex) { }

    }
}

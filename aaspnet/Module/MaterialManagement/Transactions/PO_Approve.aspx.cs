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

public partial class Module_MaterialManagement_Transactions_PO_Approve : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    string CDate = "";
    string CTime = "";
    string str = "";
    string FyId = "";

    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FyId = Session["finyear"].ToString();
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            str = fun.Connection();
            con = new SqlConnection(str);
            if (!IsPostBack)
            {
                txtPONo.Visible = false;
                this.makegrid();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void makegrid()
    {
        try
        {            
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmdNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CheckedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ApprovedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Sup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Code", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmendmentNo", typeof(string)));
            DataRow dr;            
            CompId = Convert.ToInt32(Session["compid"]);
            string x = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtPONo.Text != "")
                {
                    x = " AND PONo='" + txtPONo.Text + "'";
                }
            }
            string sql = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "'   And FinYearId<='" + FyId + "' AND Checked='1'" + x + " AND Approve='0' Order by Id Desc");
           
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();                
                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS.Tables[0].Rows[p]["SessionId"] + "'");
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
                dr[2] = DS.Tables[0].Rows[p]["AmendmentNo"].ToString();
                dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();
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

                dr[7] = DS.Tables[0].Rows[p]["Id"].ToString(); ;
                dr[8] = DS3.Tables[0].Rows[0]["SupplierName"].ToString();
                dr[9] = DS.Tables[0].Rows[p]["SupplierId"].ToString();


                string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[10] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                }
                dr[11] = DS.Tables[0].Rows[p]["AmendmentNo"].ToString();
                if (DS.Tables[0].Rows[p]["SupplierId"].ToString() == DS3.Tables[0].Rows[0]["SupplierId"].ToString())
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((Label)grv.FindControl("lblApproved")).Text != "")
                {
                    CheckBox chk = (CheckBox)grv.FindControl("CK");
                    chk.Visible = false;
                }
            }

            con.Close();
        }
      catch (Exception ess)
        {

        }
    }

    string parentPage = "PO_Approve.aspx";

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        try
        {
            con.Open();
            if (e.CommandName == "App")
            {
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    CheckBox chk = (CheckBox)grv.FindControl("CK");

                    if (chk.Checked == true)
                    {
                        string id = ((Label)grv.FindControl("lblId")).Text;
                        string pono = ((Label)grv.FindControl("lblsprno")).Text;
                        string sql3 = fun.update("tblMM_PO_Master", "Approve='1',ApprovedBy='" + sId + "',ApproveDate='" + CDate + "',ApproveTime='" + CTime + "'", "CompId='" + CompId + "'   AND Id='" + id + "'  AND PONo='" + pono + "'");

                        SqlCommand cmd3 = new SqlCommand(sql3, con);
                        cmd3.ExecuteNonQuery();
                       

                    }
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            if (e.CommandName == "view")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string pocode = ((Label)row.FindControl("lblsprno")).Text;
                string supcode = ((Label)row.FindControl("lblsupcode")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;
                string AmdNo = ((Label)row.FindControl("lblAmendmentNo")).Text;


                string StrFlag = fun.select("PRSPRFlag", "tblMM_PO_Master", "SupplierId='" + supcode + "' And PONo='" + pocode + "' AND CompId='" + CompId + "'");

                SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                DataSet DSFlag = new DataSet();
                daFlag.Fill(DSFlag);

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
        catch (Exception es)
        {

        }
        finally
        {
            con.Close();
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
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

    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpfield.SelectedValue == "1")
            {
                txtPONo.Visible = true;
                txtPONo.Text = "";
                txtSupplier.Visible = false;
                this.makegrid();
            }
            else
            {
                txtPONo.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.makegrid();
            }
        }
        catch (Exception ex){}

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.makegrid();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.makegrid();
        }
        catch (Exception ex) { }
       
    }
    protected void App_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            int i = 0;
            foreach (GridViewRow grv in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)grv.FindControl("CK");

                if (chk.Checked == true)
                {
                    string id = ((Label)grv.FindControl("lblId")).Text;
                    string pono = ((Label)grv.FindControl("lblsprno")).Text;
                    string sql3 = fun.update("tblMM_PO_Master", "Approve='1',ApprovedBy='" + sId + "',ApproveDate='" + CDate + "',ApproveTime='" + CTime + "'", "CompId='" + CompId + "'   AND Id='" + id + "'  AND PONo='" + pono + "'");

                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();
                    i++;
                }
            }
            if (i > 0)
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                string mystring = string.Empty;
                mystring = "No record is found to approved.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception es)
        {

        }
        finally
        {
            con.Close();
        }

    }
}

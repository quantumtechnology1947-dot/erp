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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;

public partial class Module_MaterialManagement_Transactions_APO_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    private ReportDocument report = new ReportDocument();
    string SupCode = "";
    int CompId = 0;
    string po = "";
    string emp = "";
    string FyId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SupCode = Request.QueryString["Code"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Session["finyear"].ToString();

            if (!IsPostBack)
            {
                this.LoadData(po, emp);
            }
        }
        catch (Exception stt)
        {

        }
    }

    public void LoadData(string poNo, string empid)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        DataTable dt = new DataTable();
        con.Open();

        try
        {
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmdNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));


            DataRow dr;
            string x = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtpoNo.Text != "")
                {
                    x = " AND PONo='" + txtpoNo.Text + "'";
                }
            }

            string y = "";
            if (drpfield.SelectedValue == "0")
            {
                if (txtEmpName.Text != "")
                {
                    y = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
                }
            }

            string StrSql = fun.select("tblMM_PO_MasterA.Id,tblMM_PO_MasterA.FileName,tblMM_PO_MasterA.FinYearId,tblMM_PO_MasterA.PONo,tblMM_PO_MasterA.SysDate,tblMM_PO_MasterA.SysTime,tblMM_PO_MasterA.SessionId,tblMM_PO_MasterA.AmendmentNo", "tblMM_PO_MasterA", "tblMM_PO_MasterA.SupplierId='" + SupCode + "' AND FinYearId<='" + FyId + "' AND tblMM_PO_MasterA.CompId='" + CompId + "' " + x + y + " Order By tblMM_PO_MasterA.Id Desc");


            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
            DataSet DSSql = new DataSet();
            dasupId.Fill(DSSql);

            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();

                // For Gen. By
                string sqlGenBy = fun.select("tblHR_OfficeStaff.Title+'. '+EmployeeName AS GenBy", "tblHR_OfficeStaff", "EmpId='" + DSSql.Tables[0].Rows[i]["SessionId"].ToString() + "' AND CompId='" + CompId + "'");
                SqlCommand cmdGenBy = new SqlCommand(sqlGenBy, con);
                SqlDataAdapter daGenBy = new SqlDataAdapter(cmdGenBy);
                DataSet DSGenBy = new DataSet();
                daGenBy.Fill(DSGenBy);

                if (DSGenBy.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DSSql.Tables[0].Rows[i]["PONo"].ToString();
                    string Date = fun.FromDate(DSSql.Tables[0].Rows[i]["SysDate"].ToString());
                    dr[1] = Date;
                    dr[2] = DSSql.Tables[0].Rows[i]["AmendmentNo"].ToString();
                    dr[3] = DSGenBy.Tables[0].Rows[0]["GenBy"].ToString();

                    //For Fin Year
                    string sqlFinYear = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + DSSql.Tables[0].Rows[i]["FinYearId"].ToString() + "'");

                    SqlCommand cmdFinYear = new SqlCommand(sqlFinYear, con);
                    SqlDataAdapter daFinYear = new SqlDataAdapter(cmdFinYear);
                    DataSet DSFinYear = new DataSet();
                    daFinYear.Fill(DSFinYear);

                    dr[4] = DSSql.Tables[0].Rows[i]["FinYearId"].ToString();
                    dr[5] = DSFinYear.Tables[0].Rows[0]["FinYear"].ToString();
                    dr[6] = DSSql.Tables[0].Rows[i]["Id"].ToString();
                    dr[7] = DSSql.Tables[0].Rows[i]["FileName"].ToString();

                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }
            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                string Poid = ((Label)grv.FindControl("lblId")).Text;
                string StrSql9 = fun.select("AmendmentNo", "tblMM_PO_MasterA", "Id ='" + Poid + "'");
                SqlCommand cmdsupId9 = new SqlCommand(StrSql9, con);
                SqlDataAdapter dasupId9 = new SqlDataAdapter(cmdsupId9);
                DataSet DSSql9 = new DataSet();
                dasupId9.Fill(DSSql9);

                List<string> L = new List<string>();

                for (int i = Convert.ToInt32(DSSql9.Tables[0].Rows[0][0]); i >= 0; i--)
                {
                    L.Add(i.ToString());
                }

                ((DropDownList)grv.FindControl("AmdDropDown")).DataSource = L;
                ((DropDownList)grv.FindControl("AmdDropDown")).DataBind();

            }

        }
        catch (Exception ex)
        { }
        finally
        {
            con.Close();
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.LoadData(po, emp);
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);

        try
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string pono = ((Label)row.FindControl("lblpono")).Text;
            string mid = ((Label)row.FindControl("lblId")).Text;
            string AmdNo = ((DropDownList)row.FindControl("AmdDropDown")).SelectedItem.Value;

            if (e.CommandName == "sel")
            {
                string StrFlag = fun.select("PRSPRFlag", "tblMM_PO_MasterA", "Id=" + mid + " ");
                //And SupplierId='" + SupCode + "' AND CompId='"+CompId+"' And PONo='" + pono + "' 
                SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                DataSet DSFlag = new DataSet();
                daFlag.Fill(DSFlag);

                if (DSFlag.Tables[0].Rows[0][0].ToString() == "0")
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("APO_Print_Details.aspx?mid=" + mid + "&pono=" + pono + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "");
                }
                else
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("APO_SPR_Print_Details.aspx?mid=" + mid + "&pono=" + pono + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "");
                }
            }

            if (e.CommandName == "Download")
            {
                string StrRef = fun.select("*", "tblMM_PO_MasterA", "CompId='" + CompId + "' AND PONo='" + pono + "' AND Id='" + mid + "'");

                SqlCommand cmdRef = new SqlCommand(StrRef, con);
                SqlDataAdapter DARef = new SqlDataAdapter(cmdRef);
                DataSet DSRef = new DataSet();
                DARef.Fill(DSRef);

                if (DSRef.Tables[0].Rows[0]["FileName"] == DBNull.Value || DSRef.Tables[0].Rows[0]["FileName"].ToString() == "")
                {

                    ((LinkButton)row.FindControl("LinkBtnDownload")).Visible = false;
                }
                else
                {

                    ((LinkButton)row.FindControl("LinkBtnDownload")).Visible = true;
                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + DSRef.Tables[0].Rows[0]["Id"].ToString() + "&tbl=tblMM_PO_MasterA&qfd=FileData&qfn=fileName&qct=ContentType");
                }
            }
            if (e.CommandName == "old")
            {
                string StrFlag = fun.select("PRSPRFlag", "tblMM_PO_MasterA", "Id=" + mid + " ");
                //And SupplierId='" + SupCode + "' AND CompId='"+CompId+"' And PONo='" + pono + "' 
                SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                DataSet DSFlag = new DataSet();
                daFlag.Fill(DSFlag);

                if (DSFlag.Tables[0].Rows[0][0].ToString() == "0")
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("CPO_Print_Details.aspx?mid=" + mid + "&pono=" + pono + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&ModId=6&SubModId=35");
                }
                else
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("CPO_SPR_Print_Details.aspx?mid=" + mid + "&pono=" + pono + "&Code=" + SupCode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&ModId=6&SubModId=35");
                }
            }

            if (e.CommandName == "Download")
            {
                string StrRef = fun.select("*", "tblMM_PO_MasterA", "CompId='" + CompId + "' AND PONo='" + pono + "' AND Id='" + mid + "'");

                SqlCommand cmdRef = new SqlCommand(StrRef, con);
                SqlDataAdapter DARef = new SqlDataAdapter(cmdRef);
                DataSet DSRef = new DataSet();
                DARef.Fill(DSRef);

                if (DSRef.Tables[0].Rows[0]["FileName"] == DBNull.Value || DSRef.Tables[0].Rows[0]["FileName"].ToString() == "")
                {

                    ((LinkButton)row.FindControl("LinkBtnDownload")).Visible = false;
                }
                else
                {

                    ((LinkButton)row.FindControl("LinkBtnDownload")).Visible = true;
                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + DSRef.Tables[0].Rows[0]["Id"].ToString() + "&tbl=tblMM_PO_MasterA&qfd=FileData&qfn=fileName&qct=ContentType");
                }
            }

        }
        catch (Exception ex) { }
        finally
        { con.Close(); }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("APO_Print_Supplier.aspx?");
    }

    protected void GridView2_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.LoadData(po, emp);
    }
    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpfield.SelectedValue == "1")
        {
            txtpoNo.Visible = true;
            txtpoNo.Text = "";
            txtEmpName.Visible = false;
            this.LoadData(po, emp);
        }
        else
        {
            txtpoNo.Visible = false;
            txtEmpName.Visible = true;
            txtEmpName.Text = "";
            this.LoadData(po, emp);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.LoadData(txtpoNo.Text, txtEmpName.Text);
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
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }
}


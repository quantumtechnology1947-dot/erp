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

public partial class Module_ProjectManagement_Reports_ProjectSummary : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string sId = "";
    int CompId = 0;
    string CId = "";
    string Eid = "";
    string connStr = "";
    int FinYearId = 0;
    int h = 0;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            if (!Page.IsPostBack)
            {

                string StrCat = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
                SqlCommand Cmd = new SqlCommand(StrCat, con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS, "tblSD_WO_Category");
                DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
                DDLTaskWOType.DataTextField = "Category";
                DDLTaskWOType.DataValueField = "CId";
                DDLTaskWOType.DataBind();
                DDLTaskWOType.Items.Insert(0, "WO Category");
                TxtSearchValue.Visible = false;
                this.BindDataCust(CId, Eid);
                DDLTaskWOType1.DataSource = DS.Tables["tblSD_WO_Category"];
                DDLTaskWOType1.DataTextField = "Category";
                DDLTaskWOType1.DataValueField = "CId";
                DDLTaskWOType1.DataBind();
                DDLTaskWOType1.Items.Insert(0, "WO Category");

                DDLTaskWOTypeSH.DataSource = DS.Tables["tblSD_WO_Category"];
                DDLTaskWOTypeSH.DataTextField = "Category";
                DDLTaskWOTypeSH.DataValueField = "CId";
                DDLTaskWOTypeSH.DataBind();
                DDLTaskWOTypeSH.Items.Insert(0, "WO Category");


                DropDownSupWO.DataSource = DS.Tables["tblSD_WO_Category"];
                DropDownSupWO.DataTextField = "Category";
                DropDownSupWO.DataValueField = "CId";
                DropDownSupWO.DataBind();
                DropDownSupWO.Items.Insert(0, "WO Category");

                this.loaddata(h);
                this.Bindload(CId, Eid);
                this.BindSup(CId, Eid);
            }


        }
        catch (Exception ex)
        {
        }
    }

    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            SearchGridView1.PageIndex = e.NewPageIndex;
            this.BindDataCust(CId, Eid);
        }
        catch (Exception ex)
        {
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            this.BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
        }
        catch (Exception ex)
        {
        }
    }

    public void BindDataCust(string Cid, string EID)
    {
        try
        {
            string sId = Session["username"].ToString();
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            int CompId = Convert.ToInt32(Session["compid"]);
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtEnqId.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.EnqId='" + txtEnqId.Text + "'";
                }
            }
            if (DropDownList1.SelectedValue == "2")
            {
                if (txtEnqId.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.PONo='" + txtEnqId.Text + "'";
                }
            }

            if (DropDownList1.SelectedValue == "3")
            {
                if (txtEnqId.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.WONo='" + txtEnqId.Text + "'";
                }
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
                Z = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
            }
            string L = " ";
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
            con.Close();
        }

        catch (Exception ex)
        { }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "0")
            {
                txtEnqId.Visible = false;
                TxtSearchValue.Visible = true;
                TxtSearchValue.Text = "";
                this.BindDataCust(CId, Eid);
            }
            if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
            {
                txtEnqId.Visible = true;
                TxtSearchValue.Visible = false;
                txtEnqId.Text = "";
                this.BindDataCust(CId, Eid);
            }
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
    protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string WONo = string.Empty;
            string SwithTo = string.Empty;
            if (e.CommandName == "NavigateTo")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                WONo = ((LinkButton)row.FindControl("BtnWONo")).Text;
                SwithTo = ((DropDownList)row.FindControl("DropDownList2")).SelectedValue;

                if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "3")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Details_Hard.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");
                }
                else if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "2")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");

                }
                else if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "1")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Details_Bought.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");
                }

            }
        }
        catch (Exception ex)
        { }
    }

    protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLTaskWOType.SelectedValue != "WO Category")
        {
            this.BindDataCust(CId, Eid);
        }
        else
        {
            this.BindDataCust(CId, Eid);
        }

    }

    ////////////////////////////////////////////////////// For All WOrk Order............................

    public void loaddata(int c)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            string x = "";
            if (drpfield.SelectedValue == "0")
            {
                if (txtSupplier.Text != "")
                {
                    string CustCode = fun.getCode(txtSupplier.Text);
                    x = " AND SD_Cust_WorkOrder_Master.CustomerId='" + CustCode + "'";
                }
            }

            string y = "";
            if (drpfield.SelectedValue == "1")
            {
                if (txtPONo.Text != "")
                {
                    y = " AND SD_Cust_WorkOrder_Master.WONo='" + txtPONo.Text + "'";
                }
            }

            if (drpfield.SelectedValue == "2")
            {
                if (txtPONo.Text != "")
                {
                    y = " AND SD_Cust_WorkOrder_Master.TaskProjectTitle Like '%" + txtPONo.Text + "%'";
                }
            }

            string Z = "";
            if (DDLTaskWOType1.SelectedValue != "WO Category")
            {
                Z = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOType1.SelectedValue) + "'";
            }

            SqlDataAdapter da = new SqlDataAdapter("Sp_ForeCast", con);
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
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView1.DataSource = DSitem;
            GridView1.DataBind();

        }
        catch (Exception ex) { }

    }
    protected void DDLTaskWOType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLTaskWOType1.SelectedValue != "WO Category")
        {
            int k = Convert.ToInt32(DDLTaskWOType1.SelectedValue);
            this.loaddata(k);
        }
        else
        {
            this.loaddata(h);
        }

    }

    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpfield.SelectedValue == "0")
            {
                txtPONo.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.loaddata(h);
            }
            if (drpfield.SelectedValue == "1" || drpfield.SelectedValue == "2")
            {
                txtPONo.Visible = true;
                txtPONo.Text = "";
                txtSupplier.Visible = false;
                this.loaddata(h);
            }

        }
        catch (Exception ex) { }

    }



    protected void SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (SelectAll.Checked == true)
        {
            foreach (GridViewRow grv in GridView1.Rows)
            {
                ((CheckBox)grv.FindControl("CheckBox1")).Checked = true;
            }
        }
        if (SelectAll.Checked == false)
        {
            foreach (GridViewRow grv in GridView1.Rows)
            {
                ((CheckBox)grv.FindControl("CheckBox1")).Checked = false;
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.loaddata(h);
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






    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.loaddata(h);
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 1)
        {


        }
    }



    protected void Button2_Click1(object sender, EventArgs e)
    {

    }




    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> woidli = new List<string>();

            string strWoid = string.Empty;
            string SwithTo = string.Empty;
            string Transaction = string.Empty;

            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    woidli.Add(Convert.ToString((((Label)grv.FindControl("lblWONo")).Text + ",")));
                }
            }
            for (int k = 0; k < woidli.Count; k++)
            {
                strWoid += woidli[k].ToString();
            }
            Session["Wono"] = strWoid;


            if (Session["Wono"] != null && string.IsNullOrEmpty(Session["Wono"].ToString()) == false)
            {
                Response.Redirect("ProjectSummary_WONo.aspx?ModId=7");
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Select Workorder.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }

        }
        catch (Exception ex)
        {
        }
    }



    //////////////// for short Qty ....



    public void Bindload(string Cid, string EID)
    {
        try
        {
            string sId = Session["username"].ToString();
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            int CompId = Convert.ToInt32(Session["compid"]);
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (DropDownList4.SelectedValue == "1")
            {
                if (txtEnqSH.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.EnqId='" + txtEnqSH.Text + "'";
                }
            }
            if (DropDownList4.SelectedValue == "2")
            {
                if (txtEnqSH.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.PONo='" + txtEnqSH.Text + "'";
                }
            }

            if (DropDownList4.SelectedValue == "3")
            {
                if (txtEnqSH.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.WONo='" + txtEnqSH.Text + "'";
                }
            }

            string y = "";

            if (DropDownList4.SelectedValue == "0")
            {
                if (TxtSearchSH.Text != "")
                {
                    string Custid = fun.getCode(TxtSearchSH.Text);
                    y = " AND SD_Cust_WorkOrder_Master.CustomerId='" + Custid + "'";
                }
            }

            string Z = "";
            if (DDLTaskWOTypeSH.SelectedValue != "WO Category")
            {
                Z = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOTypeSH.SelectedValue) + "'";
            }
            string L = " ";
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
            SearchGridView2.DataSource = DSitem;
            SearchGridView2.DataBind();
            con.Close();
        }

        catch (Exception ex)
        { }
    }


    protected void SearchGridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            SearchGridView2.PageIndex = e.NewPageIndex;
            this.Bindload(CId, Eid);
        }
        catch (Exception ex)
        {
        }
    }
    protected void SearchGridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string WONo = string.Empty;
            string SwithTo = string.Empty;
            if (e.CommandName == "NavigateToSH")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                WONo = ((LinkButton)row.FindControl("BtnWONoSH")).Text;
                SwithTo = ((DropDownList)row.FindControl("DropDownListSH")).SelectedValue;


                if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "3")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Shortage_H.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");

                }
               
                else if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "2")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Shortage_M.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");

                }
                else if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "1")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Shortage_B.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");
                }

            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearchSH_Click(object sender, EventArgs e)
    {
        try
        {
            this.Bindload(TxtSearchSH.Text, txtEnqSH.Text);
        }
        catch (Exception ex)
        {
        }
    }
    protected void DDLTaskWOTypeSH_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLTaskWOTypeSH.SelectedValue != "WO Category")
        {
            this.Bindload(CId, Eid);
        }
        else
        {
            this.Bindload(CId, Eid);
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList4.SelectedValue == "0")
            {
                txtEnqSH.Visible = false;
                TxtSearchSH.Visible = true;
                TxtSearchSH.Text = "";
                this.Bindload(CId, Eid);
            }
            if (DropDownList4.SelectedValue == "1" || DropDownList4.SelectedValue == "2" || DropDownList4.SelectedValue == "3" || DropDownList4.SelectedValue == "Select")
            {
                txtEnqSH.Visible = true;
                TxtSearchSH.Visible = false;
                txtEnqSH.Text = "";
                this.Bindload(CId, Eid);
            }
        }
        catch (Exception ex)
        { }
    }



    //////////////// for Supplier Wise  Qty ....





    public void BindSup(string Cid, string EID)
    {
        try
        {
            string sId = Session["username"].ToString();
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            int CompId = Convert.ToInt32(Session["compid"]);
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (DropDownSup.SelectedValue == "1")
            {
                if (TextSupWONo.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.EnqId='" + TextSupWONo.Text + "'";
                }
            }
            if (DropDownSup.SelectedValue == "2")
            {
                if (TextSupWONo.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.PONo='" + TextSupWONo.Text + "'";
                }
            }

            if (DropDownSup.SelectedValue == "3")
            {
                if (TextSupWONo.Text != "")
                {
                    x = " AND SD_Cust_WorkOrder_Master.WONo='" + TextSupWONo.Text + "'";
                }
            }

            string y = "";

            if (DropDownSup.SelectedValue == "0")
            {
                if (TextSupCust.Text != "")
                {
                    string Custid = fun.getCode(TextSupCust.Text);
                    y = " AND SD_Cust_WorkOrder_Master.CustomerId='" + Custid + "'";
                }
            }

            string Z = "";
            if (DropDownSupWO.SelectedValue != "WO Category")
            {
                Z = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DropDownSupWO.SelectedValue) + "'";
            }
            string L = " ";
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
            GridViewSup.DataSource = DSitem;
            GridViewSup.DataBind();
            con.Close();
        }

        catch (Exception ex)
        { }
    }














    protected void GridViewSup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewSup.PageIndex = e.NewPageIndex;
            this.BindSup(CId, Eid);
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridViewSup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string WONo = string.Empty;
            string SwithTo = string.Empty;
            if (e.CommandName == "Sup")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                WONo = ((LinkButton)row.FindControl("BtnWONoSup")).Text;
                SwithTo = ((DropDownList)row.FindControl("DropDownSuptype")).SelectedValue;
                Response.Write("heloo");
                if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "2")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Sup_M.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");

                }
                else if (WONo != string.Empty && SwithTo != string.Empty && SwithTo == "1")
                {
                    Response.Redirect("~/Module/ProjectManagement/Reports/ProjectSummary_Sup_B.aspx?WONo=" + WONo + "&SwitchTo=" + SwithTo + "&ModId=&SubModId=");
                }

            }
        }
        catch (Exception ex)
        { }
    }
    protected void BtnSup_Click(object sender, EventArgs e)
    {
        try
        {
            this.BindSup(TextSupWONo.Text, TextSupCust.Text);
        }
        catch (Exception ex)
        {
        }
    }
    protected void DropDownSupWO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownSupWO.SelectedValue != "WO Category")
        {
            this.BindSup(CId, Eid);
        }
        else
        {
            this.BindSup(CId, Eid);
        }
    }
    protected void DropDownSup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownSup.SelectedValue == "0")
            {
                TextSupWONo.Visible = false;
                TextSupCust.Visible = true;
                TextSupCust.Text = "";
                this.BindSup(CId, Eid);
            }
            if (DropDownSup.SelectedValue == "1" || DropDownSup.SelectedValue == "2" || DropDownSup.SelectedValue == "3" || DropDownSup.SelectedValue == "Select")
            {
                TextSupWONo.Visible = true;
                TextSupCust.Visible = false;
                TextSupWONo.Text = "";
                this.BindSup(CId, Eid);
            }
        }
        catch (Exception ex)
        { }
    }







}



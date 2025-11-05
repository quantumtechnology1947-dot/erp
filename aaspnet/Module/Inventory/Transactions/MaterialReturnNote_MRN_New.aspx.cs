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

public partial class Module_Inventory_Transactions_MaterialReturnNote_MRN_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    DataSet DS2 = new DataSet();
    string sId = "";
    int CompId = 0;
    string connStr = "";
    SqlConnection con;
    string CDate = "";
    string CTime = "";
    int FinYearId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            this.getval();
            if (!IsPostBack)
            {
                DrpCategory1.Items.Clear();
                DrpCategory1.Items.Insert(0, "Select");
                DropDownList3.Visible = false;
                DrpCategory1.Visible = false;
                DrpSearchCode.Visible = false;
                txtSearchItemCode.Visible = false;
                this.loadgrid();
            }


            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
        }
       catch (Exception ex) { }
    }


    protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpCategory1.SelectedValue != "Select")
            {

                DrpSearchCode.Visible = true;
                txtSearchItemCode.Text = "";
                string sd = DrpCategory1.SelectedValue;
                string c = DrpSearchCode.SelectedValue;
                string d = txtSearchItemCode.Text;
                string e1 = DrpType.SelectedValue;
                this.Fillgrid(sd, c, d, e1);
            }
            else
            {
                DrpSearchCode.SelectedIndex = 0;
                txtSearchItemCode.Visible = true;
                DropDownList3.Visible = false;
                string sd = "";
                string c = "";
                string d = "";               
                string e1 = "";
                this.Fillgrid(sd, c, d, e1);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
    {

        switch (DrpType.SelectedValue)
        {
            case "Category":
                {
                    DrpSearchCode.Visible = true;
                    DropDownList3.Visible = true;
                    txtSearchItemCode.Visible = true;
                    txtSearchItemCode.Text = "";
                    DrpCategory1.Visible = true;

                    string connStr = fun.Connection();
                    SqlConnection con = new SqlConnection(connStr);

                    DataSet DS = new DataSet();
                    string StrCat = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
                    SqlCommand Cmd = new SqlCommand(StrCat, con);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DA.Fill(DS, "tblDG_Category_Master");
                    DrpCategory1.DataSource = DS.Tables["tblDG_Category_Master"];
                    DrpCategory1.DataTextField = "Category";
                    DrpCategory1.DataValueField = "CId";
                    DrpCategory1.DataBind();
                    DrpCategory1.Items.Insert(0, "Select");
                    DrpCategory1.ClearSelection();                   

                    fun.drpLocat(DropDownList3);

                    if (DrpSearchCode.SelectedItem.Text == "Location")
                    {
                        DropDownList3.Visible = true;
                        txtSearchItemCode.Visible = false;
                        txtSearchItemCode.Text = "";
                    }
                    else
                    {
                        DropDownList3.Visible = false;
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";
                    }

                }
                break;

            case "WOItems":
                {
                    txtSearchItemCode.Visible = true;
                    txtSearchItemCode.Text = "";


                    DrpSearchCode.Visible = true;
                    DrpCategory1.Visible = false;
                    DrpCategory1.Items.Clear();
                    DrpCategory1.Items.Insert(0, "Select");

                    DropDownList3.Visible = false;
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Insert(0, "Select");
                }
                break;

            case "Select":
                {
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                break;
        }
    }

    public void Fillgrid(string sd, string B, string s, string drptype)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();

        try
        {

            string x = "";
            string p = "";
            string q = "";
            string y = "";
            if (DrpType.SelectedValue != "Select")
            {
                if (DrpType.SelectedValue == "Category")
                {
                    if (sd != "Select")
                    {

                        x = " AND tblDG_Item_Master.CId='" + sd + "'";

                        if (B != "Select")
                        {
                            if (B == "tblDG_Item_Master.ItemCode")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
                            }

                            if (B == "tblDG_Item_Master.ManfDesc")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
                            }


                            if (B == "tblDG_Item_Master.Location")
                            {
                                txtSearchItemCode.Visible = false;
                                DropDownList3.Visible = true;

                                if (DropDownList3.SelectedValue != "Select")
                                {
                                    p = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
                                }
                            }


                        }
                        q = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";

                    }
                    else if (sd == "Select" && B == "Select" && s != string.Empty)
                    {
                        y = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";

                    }


                }

                else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
                {

                    if (B != "Select")
                    {
                        if (B == "tblDG_Item_Master.ItemCode")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And tblDG_Item_Master.ItemCode Like '%" + s + "%'";
                        }

                        if (B == "tblDG_Item_Master.ManfDesc")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
                        }
                    }
                    else if (B == "Select" && s != string.Empty)
                    {
                        y = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";

                    }

                }

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter("GetAllItem", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@startIndex"].Value = sd;
                da.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@pageSize"].Value = x;
                da.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@startIndex1"].Value = p;
                da.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@pageSize1"].Value = q;
                da.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@drpType"].Value = drptype;
                da.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@drpCode"].Value = B;
                da.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
                da.SelectCommand.Parameters["@y"].Value = y;
                DataSet DSitem = new DataSet();
                da.Fill(DSitem);
                GridView2.DataSource = DSitem;
                GridView2.DataBind();
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Please Select Category or WO Items.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ex)
        {

        }

    }     

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string sd = DrpCategory1.SelectedValue;
            string c = DrpSearchCode.SelectedValue;
            string d = txtSearchItemCode.Text;
            string e1 = DrpType.SelectedValue;
            this.Fillgrid(sd, c, d, e1);
        }
        catch (Exception ch)
        {
        }
    }



    public void getval()
    {
        try
        {
            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((DropDownList)grv.FindControl("DropDownList1")).SelectedValue == "2")
                {
                    ((TextBox)grv.FindControl("txtwono")).Visible = true;                   
                     
                }
                else 
                {
                    ((TextBox)grv.FindControl("txtwono")).Visible = false;
                    
                }
                if (((DropDownList)grv.FindControl("DropDownList1")).SelectedValue == "1")
                {
                    ((DropDownList)grv.FindControl("drpdept")).Visible = true;
                    if (((DropDownList)grv.FindControl("drpdept")).Visible == true)
                    {
                        ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = false;
                    }
                }
                else
                {
                    ((DropDownList)grv.FindControl("drpdept")).Visible = false;
                    if (((DropDownList)grv.FindControl("drpdept")).Visible == false)
                    {
                        ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = true;
                    }
                }

                if (((DropDownList)grv.FindControl("DropDownList1")).Visible == false)
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqty")).Visible = false;
                    ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = false;
                }
                else if (((DropDownList)grv.FindControl("DropDownList1")).Visible ==true)
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqty")).Visible = true;
                    ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = true;
                }

                if (((DropDownList)grv.FindControl("DropDownList1")).SelectedValue != "0")
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqty")).Visible = true;
                    
                }
                else if(((DropDownList)grv.FindControl("DropDownList1")).SelectedValue =="0")
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqty")).Visible = false;                   
                }

                if (((TextBox)grv.FindControl("txtwono")).Visible == true)
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = true;
                }
                else if (((TextBox)grv.FindControl("txtwono")).Visible == false)
                {
                    ((RequiredFieldValidator)grv.FindControl("Reqwono")).Visible = false;

                }

                
            }
        }
        catch (Exception es) { }

    }

   
    
    
    
    
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            con.Open();
            if (e.CommandName == "Add")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string Id = ((Label)row.FindControl("LblId")).Text;
                int deptwo = Convert.ToInt32(((DropDownList)row.FindControl("DropDownList1")).SelectedValue);
                string dept = "";
                string wo = "";
                string sql = "";
                //Checking of selected item
                string StrRateReg = fun.select("Id,ItemId", "tblMM_Rate_Register", "ItemId='" + Id + "' And CompId='" + CompId + "'");
                SqlCommand cmdRateReg = new SqlCommand(StrRateReg, con);
                SqlDataAdapter DARateReg = new SqlDataAdapter(cmdRateReg);
                DataSet DSRateReg = new DataSet();
                DARateReg.Fill(DSRateReg);
                if (DSRateReg.Tables[0].Rows.Count > 0)
                {
                    if (deptwo != 0 && ((TextBox)row.FindControl("txtqty")).Text != "")
                    {
                        double Qty = Convert.ToDouble(decimal.Parse((((TextBox)row.FindControl("txtqty")).Text).ToString()).ToString("N3"));
                        string Rmks = ((TextBox)row.FindControl("txtremarks")).Text;
                        SqlCommand cmdtempcheck = new SqlCommand(fun.select("Id", "tblinv_MaterialReturn_Temp", "ItemId='" + Id + "' And CompId='" + CompId + "' AND SessionId='" + sId + "'"), con);
                        SqlDataAdapter DAtempcheck = new SqlDataAdapter(cmdtempcheck);
                        DataSet DStempcheck = new DataSet();
                        DAtempcheck.Fill(DStempcheck, "tblinv_MaterialReturn_Temp");

                        if (DStempcheck.Tables[0].Rows.Count > 0)
                        {
                            string mystring = string.Empty;
                            mystring = "Item is already selected for MRN.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);

                        }
                        else // Create MRN
                        {
                            if (deptwo == 1 && fun.NumberValidationQty(Qty.ToString()) == true)
                            {
                                if (((DropDownList)row.FindControl("drpdept")).SelectedValue != "0")
                                {
                                    dept = ((DropDownList)row.FindControl("drpdept")).SelectedValue;

                                    sql = fun.insert("tblinv_MaterialReturn_Temp", "CompId,SessionId,ItemId,DeptId,RetQty,Remarks", "'" + CompId + "','" + sId + "','" + Id + "','" + dept + "','" + Qty + "','" + Rmks + "'");
                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    cmd.ExecuteNonQuery();
                                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                                }
                            }
                            else if (deptwo == 2 && fun.NumberValidationQty(Qty.ToString()) == true)
                            {
                                wo = ((TextBox)row.FindControl("txtwono")).Text;

                                if (fun.CheckValidWONo(wo, CompId, FinYearId) == true)
                                {

                                    sql = fun.insert("tblinv_MaterialReturn_Temp", "CompId,SessionId,ItemId,WONo,RetQty,Remarks", "'" + CompId + "','" + sId + "','" + Id + "','" + wo + "','" + Qty + "','" + Rmks + "'");
                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    cmd.ExecuteNonQuery();
                                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                                }
                                else
                                {
                                    string mystring = string.Empty;
                                    mystring = "Invalid WONo found.";
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                                }

                            }

                        }
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Invalid Data input.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Selected item is cancel due to rate is not available in ERP.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
       finally 
        { con.Close(); }
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.getval();
        }
        catch (Exception es)
        {
        }
    }
   
    public void loadgrid()
    {
        try
        {
            
            string StrSql = fun.select("Id,ItemId,DeptId,WONo,RetQty,Remarks", "tblinv_MaterialReturn_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' order by Id desc ");


            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
            DataSet DSSql = new DataSet();
            DataTable dt = new DataTable();

            dasupId.Fill(DSSql);
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("StockQty", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Dept", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("RetQty", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            
            DataRow dr;
           
            string ItemCode = "";
            string ManfDesc = "";
            string UomBasic = "";
            string StockQty = "";
            string Dept = "";
            string wono = "";
            string RetQty = "";
            string Remark = "";
           
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {  

                    dr = dt.NewRow();                    

                    if (DSSql.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
                    {
                        string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + DSSql.Tables[0].Rows[i]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");

                        SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                        SqlDataAdapter daIcode = new SqlDataAdapter(cmdIcode);
                        DataSet DSIcode = new DataSet();
                        daIcode.Fill(DSIcode);
                        if (DSIcode.Tables[0].Rows.Count > 0)
                        {
                            // For ItemCode
                            ItemCode = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSSql.Tables[0].Rows[i]["ItemId"].ToString()));

                            // For Manf Desc
                            ManfDesc = DSIcode.Tables[0].Rows[0]["ManfDesc"].ToString();
                            
                            StockQty = decimal.Parse((DSIcode.Tables[0].Rows[0]["StockQty"]).ToString()).ToString("N3");
                            // for UOM Basic  from Unit Master table
                           
                            string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
                          
                            SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                            SqlDataAdapter daPurch = new SqlDataAdapter(cmdPurch);
                            DataSet DSPurch = new DataSet();
                            daPurch.Fill(DSPurch);
                            if (DSPurch.Tables[0].Rows.Count > 0)
                            {
                                UomBasic = DSPurch.Tables[0].Rows[0][0].ToString();
                            }
                        }
                        // for Department from Dept Master table
                        string sqlDept = fun.select("Symbol", "BusinessGroup", "Id='" + DSSql.Tables[0].Rows[i]["DeptId"].ToString() + "'");
                        SqlCommand cmdDept = new SqlCommand(sqlDept, con);
                        SqlDataAdapter daDept = new SqlDataAdapter(cmdDept);
                        DataSet DSDept = new DataSet();
                        daDept.Fill(DSDept);
                        if (DSDept.Tables[0].Rows.Count > 0)
                        {
                            Dept = DSDept.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            Dept = "NA";
                        }
                    }
                    // For ItemCode
                    dr[0] = ItemCode;
                    // For ManfDesc 
                    dr[1] = ManfDesc;
                    // For UOMBasic 
                    dr[2] = UomBasic;

                    //For StockQty 
                    if (StockQty == "")
                    {
                        dr[3] = "0";
                    }
                    else
                    {
                        dr[3] = StockQty;
                    }

                    dr[4] = Dept;

                    if (DSSql.Tables[0].Rows[i]["WONo"].ToString() != "")
                    {
                        wono = DSSql.Tables[0].Rows[i]["WONo"].ToString();
                        dr[5] = wono;
                    }
                    else
                    {
                        wono = "NA";
                        dr[5] = wono;
                    }
                    RetQty =decimal.Parse(( DSSql.Tables[0].Rows[i]["RetQty"]).ToString()).ToString();
                    dr[6] = RetQty;

                    Remark = DSSql.Tables[0].Rows[i]["Remarks"].ToString();
                    dr[7] = Remark;
                    dr[8] = DSSql.Tables[0].Rows[i]["Id"].ToString();

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }

                GridView3.DataSource = dt;
                GridView3.DataBind();
           
        }
        catch (Exception et)
        {

        }
    }
    
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.loadgrid();
        }
        catch (Exception ex) { }
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       try
        {
            if (e.CommandName == "Del")
            {
                con.Open();
                GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)grv.FindControl("LblId0")).Text);

                string delete = fun.delete("tblinv_MaterialReturn_Temp", "Id='" + id + "' AND SessionId='" + sId + "' AND CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            string cmdAmd = fun.select("MRNNo", "tblInv_MaterialReturn_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRNNo Desc");

            SqlCommand cmd1 = new SqlCommand(cmdAmd, con);
            SqlDataAdapter daAmd = new SqlDataAdapter(cmd1);
            DataSet DSAmd = new DataSet();
            daAmd.Fill(DSAmd, "tblInv_MaterialReturn_Master");

            string MRNno = "";
            if (DSAmd.Tables[0].Rows.Count > 0)
            {
                int PONstr = Convert.ToInt32(DSAmd.Tables[0].Rows[0][0].ToString()) + 1;
                MRNno = PONstr.ToString("D4");
            }
            else
            {
                MRNno = "0001";
            }

            if (e.CommandName == "proceed")
            {
                con.Open();

                int u = 1; string MId = "";
                string getId = fun.select("*", "tblinv_MaterialReturn_Temp", "SessionId='" + sId + "' AND CompId='" + CompId + "'");
                SqlCommand cmd5 = new SqlCommand(getId, con);
                SqlDataAdapter daAmd5 = new SqlDataAdapter(cmd5);
                DataSet DSAmd5 = new DataSet();
                daAmd5.Fill(DSAmd5, "tblinv_MaterialReturn_Temp");

                if (DSAmd5.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DSAmd5.Tables[0].Rows.Count; i++)
                    {

                        if (u == 1)
                        {
                            string insert = ("Insert into tblInv_MaterialReturn_Master(SysDate,SysTime,CompId,FinYearId,SessionId,MRNNo) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + MRNno + "')");
                            SqlCommand cmd = new SqlCommand(insert, con);
                            cmd.ExecuteNonQuery();
                            u = 0;

                            string sel = fun.select("Id", "tblInv_MaterialReturn_Master", "CompId='" + CompId + "' Order by Id desc");
                            SqlCommand cmd23 = new SqlCommand(sel, con);
                            SqlDataAdapter daAmd1 = new SqlDataAdapter(cmd23);
                            DataSet DSAmd1 = new DataSet();
                            daAmd1.Fill(DSAmd1, "tblInv_MaterialReturn_Master");

                            MId = DSAmd1.Tables[0].Rows[0]["Id"].ToString();
                        }

                        string insert2 = ("Insert into tblInv_MaterialReturn_Details(MId,MRNNo,ItemId,DeptId,WONo,RetQty,Remarks) VALUES  ('" + MId + "','" + MRNno + "','" + DSAmd5.Tables[0].Rows[i]["ItemId"].ToString() + "','" + DSAmd5.Tables[0].Rows[i]["DeptId"].ToString() + "','" + DSAmd5.Tables[0].Rows[i]["WONo"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DSAmd5.Tables[0].Rows[i]["RetQty"].ToString()).ToString("N3")) + "','" + DSAmd5.Tables[0].Rows[i]["Remarks"].ToString() + "')");
                        SqlCommand cmd2 = new SqlCommand(insert2, con);
                        cmd2.ExecuteNonQuery();

                    }

                }

                string delTemp = fun.delete("tblinv_MaterialReturn_Temp", "CompId='" + CompId + "'And SessionId='" + sId + "'");
                SqlCommand cmdTemp = new SqlCommand(delTemp, con);
                cmdTemp.ExecuteNonQuery();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }

        }
       catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void DrpSearchCode_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.Location")
            {
                DropDownList3.Visible = true;
                txtSearchItemCode.Visible = false;
            }
            else
            {
                DropDownList3.Visible = false;
                txtSearchItemCode.Visible = true;
            }
        }

        catch (Exception ex) { }
    }
    protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearchItemCode.Text = "";
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string sd = DrpCategory1.SelectedValue;
            string c = DrpSearchCode.SelectedValue;
            string d = txtSearchItemCode.Text;
            string e1 = DrpType.SelectedValue;
            this.Fillgrid(sd, c, d, e1);

        }
        catch (Exception ch)
        {
        }
        finally
        {

        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            string sd = DrpCategory1.SelectedValue;
            string c = DrpSearchCode.SelectedValue;
            string d = txtSearchItemCode.Text;
            string e1 = DrpType.SelectedValue;
            this.Fillgrid(sd, c, d, e1);
        }
        catch (Exception ch) { }
    }

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }
}

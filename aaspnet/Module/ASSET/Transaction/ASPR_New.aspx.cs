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

public partial class Module_MaterialManagement_Transactions_ASPR_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string CDate = "";
    string CTime = "";


    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            lblMessage.Text = "";
            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            if (rddept.Checked == true)
            {
                txtwono.Text = "";
            }
            textDelDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
                fun.drpunit(DDLUnitBasic);
                DrpCategory.Items.Clear();
                DrpCategory.Items.Insert(0, "Select");
                DropDownList3.Visible = false;
                DrpCategory.Visible = false;
                DrpSearchCode.Visible = false;
                txtSearchItemCode.Visible = false;
            }


            if (Request.QueryString["m"] != null)
            {
                TabContainer1.ActiveTabIndex = 1;
                lblMessage.Text = Request.QueryString["m"].ToString();
            }
            this.LoadData();

        }

        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }

    public void Fillgrid(string sd, string B, string s, string drptype)
    {


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


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string sd = DrpCategory.SelectedValue;
            string c = DrpSearchCode.SelectedValue;
            string d = txtSearchItemCode.Text;
            string e1 = DrpType.SelectedValue;
            this.Fillgrid(sd, c, d, e1);
        }
        catch (Exception ch) { }

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            string sd = DrpCategory.SelectedValue;
            string c = DrpSearchCode.SelectedValue;
            string d = txtSearchItemCode.Text;
            string e1 = DrpType.SelectedValue;
            this.Fillgrid(sd, c, d, e1);

        }
        catch (Exception ch)
        {
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sel")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                string connStr = fun.Connection();
                SqlConnection con = new SqlConnection(connStr);
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(fun.select("*", "tblMM_SPR_TempA", "ItemId='" + id + "' And CompId='" + CompId + "' AND SessionId='" + sId + "'"), con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS, "tblMM_SPR_TempA");

                if (DS.Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("~/Module/MaterialManagement/Transactions/ASPR_NoCode.aspx?Id=" + id + "");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Item is already exist.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);

                }
            }
        }
        catch (Exception es)
        {

        }

    }
    // for NOCode Item..............
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string CustCode = fun.getCode(txtAutoSupplierExt.Text);
            con.Open();
            string StrItemid = fun.select(" * ", " tblMM_SPR_TempA ", " NoCode is Not Null AND CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmdItemid = new SqlCommand(StrItemid, con);
            SqlDataAdapter DAItemid = new SqlDataAdapter(cmdItemid);
            DataSet DSItemid = new DataSet();
            DAItemid.Fill(DSItemid);
            int TempNoCode = Convert.ToInt32(DSItemid.Tables[0].Rows.Count);
            int NoCode = TempNoCode + 1;
            string OnWoNo = "";
            string OnDept = "";
            double Rate = 0;
            double Discount = 0;
            Rate = Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2"));
            Discount = Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2"));
            int u = 0;

            if (rdwono.Checked == true && txtwono.Text != "")
            {
                OnWoNo = txtwono.Text;
                u = 1;
            }

            if (rddept.Checked == true)
            {
                OnDept = drpdept.SelectedValue.ToString();
                u = 1;
            }

            int CheckSqupId = fun.chkSupplierCode(CustCode);


            if (CheckSqupId == 1 && Rate > 0 && u == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) == true && fun.NumberValidationQty(txtQty.Text) == true && fun.NumberValidationQty(txtRate.Text) == true && fun.NumberValidationQty(txtDiscount.Text) == true)
            {
                if (fun.CheckValidWONo(txtwono.Text, CompId, FinYearId) == true)
                {
                    string StrAdd = fun.insert("tblMM_SPR_TempA", "SysDate,SysTime,CompId,FinYearId,SessionId,SupplierId,NoCode,ManfDesc,UOMBasic,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + CustCode + "','" + NoCode + "','" + txtManfDesc.Text + "','" + DDLUnitBasic.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + DropDownList1.SelectedValue + "','" + OnWoNo + "','" + OnDept + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + Discount + "'");

                    SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                    cmdAdd.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);

                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid WONo.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Invalid data entry.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                TabContainer1.ActiveTabIndex = 1;
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void txtAutoSupplierExt_TextChanged(object sender, EventArgs e)
    {

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
    {
        fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
    {
        fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
        TabContainer1.ActiveTabIndex = 1;
    }

    public void LoadData()
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("NoCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ManfDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMBasic", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("A/cHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Dept", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("DelDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(string)));
            DataRow dr;
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            string sql = fun.select("*", "tblMM_SPR_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "' Order By Id Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                if (DS.Tables[0].Rows[p]["ItemId"] != DBNull.Value)
                {
                    string sql1 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(DS.Tables[0].Rows[p]["ItemId"]) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");

                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet DS1 = new DataSet();
                    da1.Fill(DS1);

                    dr[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[p]["ItemId"].ToString()));
                    dr[2] = DS1.Tables[0].Rows[0]["ManfDesc"].ToString();
                    dr[3] = DS1.Tables[0].Rows[0]["UOMBasic"].ToString();
                }
                else
                {
                    string sql3 = fun.select("Unit_Master.Symbol As UOMBasic", "tblMM_SPR_TempAA,Unit_Master", " tblMM_SPR_TempAA.NoCode='" + Convert.ToInt32(DS.Tables[0].Rows[p]["NoCode"]) + "' AND Unit_Master.Id=tblMM_SPR_TempA.UOMBasic AND tblMM_SPR_TempA.CompId='" + CompId + "'");

                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataSet DS3 = new DataSet();
                    da3.Fill(DS3);

                    dr[1] = DS.Tables[0].Rows[p]["NoCode"].ToString();
                    dr[2] = DS.Tables[0].Rows[p]["ManfDesc"].ToString();
                    dr[3] = DS3.Tables[0].Rows[0]["UOMBasic"].ToString();
                }

                string sql2 = fun.select("'['+AccHead.Symbol+']'+Description AS Head", "AccHead,tblMM_SPR_TempA", "tblMM_SPR_TempA.AHId=AccHead.Id AND tblMM_SPR_TempA.AHId='" + Convert.ToInt32(DS.Tables[0].Rows[p]["AHId"]) + "' AND tblMM_SPR_TempA.SessionId='" + sId + "'");

                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);

                dr[4] = DS2.Tables[0].Rows[0]["Head"].ToString();
                dr[5] = decimal.Parse(DS.Tables[0].Rows[p]["Qty"].ToString()).ToString("N3");
                dr[6] = decimal.Parse(DS.Tables[0].Rows[p]["Rate"].ToString()).ToString("N2");
                dr[7] = DS.Tables[0].Rows[p]["Remarks"].ToString();


                if (DS.Tables[0].Rows[p]["WONo"].ToString() != "")
                {
                    dr[8] = DS.Tables[0].Rows[p]["WONo"].ToString();
                }
                else
                {
                    dr[8] = "NA";
                }

                if (DS.Tables[0].Rows[p]["DeptId"].ToString() != "0" && DS.Tables[0].Rows[p]["DeptId"].ToString() != "")
                {
                    string sql44 = fun.select("Symbol AS Dept", "BusinessGroup", "Id='" + DS.Tables[0].Rows[p]["DeptId"] + "'");
                    SqlCommand cmd44 = new SqlCommand(sql44, con);
                    SqlDataAdapter da44 = new SqlDataAdapter(cmd44);
                    DataSet DS44 = new DataSet();
                    da44.Fill(DS44);

                    dr[9] = DS44.Tables[0].Rows[0]["Dept"].ToString();
                }
                dr[10] = DS.Tables[0].Rows[p]["Id"].ToString();
                dr[11] = fun.FromDateDMY(DS.Tables[0].Rows[p]["DelDate"].ToString());
                dr[12] = DS.Tables[0].Rows[p]["Discount"].ToString();
                dt.Rows.Add(dr);

            }

            dt.AcceptChanges();
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        catch (Exception ep)
        {

        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        this.LoadData();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            con.Open();
            string sql = fun.delete("tblMM_SPR_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND Id='" + id + "'");
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            this.LoadData();

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        DataSet DS = new DataSet();
        try
        {
            con.Open();
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();
            int CompId = Convert.ToInt32(Session["compid"]);
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            string cmdStr = fun.select("SPRNo", "tblMM_SPR_MasterA", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblMM_SPR_MasterA");
            string SPRIdStr;
            if (DS.Tables[0].Rows.Count > 0)
            {
                int SPRstr = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                SPRIdStr = SPRstr.ToString("D4");
            }
            else
            {
                SPRIdStr = "0001";
            }

            string sql5 = fun.select("*", "tblMM_SPR_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {
                string StrSPRMaster = fun.insert("tblMM_SPR_MasterA", "SysDate,SysTime,SessionId,CompId,FinYearId,SPRNo", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + SPRIdStr + "'");
                SqlCommand cmd11 = new SqlCommand(StrSPRMaster, con);
                //con.Open();
                cmd11.ExecuteNonQuery();
                //con.Close();

                string sqlMId = fun.select("Id", "tblMM_SPR_MasterA", "CompId='" + CompId + "' AND SPRNo='" + SPRIdStr + "' Order By Id Desc");
                SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
                DataSet DSMId = new DataSet();
                DAMId.Fill(DSMId);

                string MId = DSMId.Tables[0].Rows[0]["Id"].ToString();

                for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                {
                    if (DS5.Tables[0].Rows[p]["ItemId"] != DBNull.Value)
                    {
                        string StrSPRDetails = fun.insert("tblMM_SPR_DetailsA", "MId,SPRNo,ItemId,Qty,Rate,SupplierId,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + MId + "','" + SPRIdStr + "','" + DS5.Tables[0].Rows[p]["ItemId"] + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Rate"].ToString()).ToString("N2")) + "','" + DS5.Tables[0].Rows[p]["SupplierId"].ToString() + "','" + DS5.Tables[0].Rows[p]["AHId"].ToString() + "','" + DS5.Tables[0].Rows[p]["WONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["DeptId"].ToString() + "','" + DS5.Tables[0].Rows[p]["Remarks"].ToString() + "','" + DS5.Tables[0].Rows[p]["DelDate"].ToString() + "','" + DS5.Tables[0].Rows[p]["Discount"].ToString() + "'");
                        SqlCommand cmd15 = new SqlCommand(StrSPRDetails, con);
                        //con.Open();
                        cmd15.ExecuteNonQuery();
                        //con.Close();
                        string sqlt = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + SPRIdStr + "' , LockDate='" + CDate + "' ,LockTime='" + CTime + "'", "ItemId='" + DS5.Tables[0].Rows[p]["ItemId"] + "' And  Type='1' AND  CompId='" + CompId + "' ");

                        SqlCommand cmdt = new SqlCommand(sqlt, con);
                        // con.Open();
                        cmdt.ExecuteNonQuery();
                        // con.Close();


                    }
                    else
                    {
                        //  No code Item code Z12-0001-001
                        string FinYear = "";
                        //For Fin Year
                        string sqlFinYear = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
                        SqlCommand cmdFinYear = new SqlCommand(sqlFinYear, con);
                        SqlDataAdapter daFinYear = new SqlDataAdapter(cmdFinYear);
                        DataSet DSFinYear = new DataSet();
                        daFinYear.Fill(DSFinYear);
                        if (DSFinYear.Tables[0].Rows.Count > 0)
                        {
                            FinYear = fun.SPRNoCodeFY(DSFinYear.Tables[0].Rows[0]["FinYear"].ToString());
                        }

                        int NoC = Convert.ToInt32(DS5.Tables[0].Rows[p]["NoCode"].ToString());
                        string NoC1 = NoC.ToString("D3");
                        string ItemCode = FinYear + "-" + SPRIdStr + "-" + NoC1;

                        string sql7 = fun.select("Id", "tblDG_Item_Master", "CompId='" + CompId + "' AND ItemCode='" + ItemCode + "'");
                        SqlCommand cmd7 = new SqlCommand(sql7, con);
                        SqlDataAdapter da7 = new SqlDataAdapter(cmd7);
                        DataSet DS7 = new DataSet();
                        da7.Fill(DS7);

                        string Bdate = fun.select("FinYearFrom", "tblFinancial_master", "CompId='" + CompId + "'  And FinYearId='" + FinYearId + "'");
                        SqlCommand cmddt = new SqlCommand(Bdate, con);
                        SqlDataAdapter dadt = new SqlDataAdapter(cmddt);
                        DataSet dsdt = new DataSet();
                        dadt.Fill(dsdt);
                        string BalDate = "";
                        if (dsdt.Tables[0].Rows.Count > 0)
                        {
                            BalDate = (dsdt.Tables[0].Rows[0]["FinYearFrom"].ToString());
                        }
                        if (DS7.Tables[0].Rows.Count == 0)
                        {
                            string StrItemMaster = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CId,ItemCode,ManfDesc,UOMBasic,MinOrderQty,MinStockQty,StockQty,Absolute,OpeningBalQty,UOMConFact,OpeningBalDate,AHId", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "', 26,'" + ItemCode + "','" + DS5.Tables[0].Rows[p]["ManfDesc"].ToString() + "','" + DS5.Tables[0].Rows[p]["UOMBasic"].ToString() + "',0,0,0,0,0,0,'" + BalDate + "','" + Convert.ToInt32(DS5.Tables[0].Rows[p]["AHId"]) + "'");

                            SqlCommand cmd6 = new SqlCommand(StrItemMaster, con);
                            // con.Open();
                            cmd6.ExecuteNonQuery();
                            // con.Close();
                        }

                        string sql9 = fun.select("Id", "tblDG_Item_Master", "CompId='" + CompId + "' AND ItemCode='" + ItemCode + "'");
                        SqlCommand cmd9 = new SqlCommand(sql9, con);
                        SqlDataAdapter da9 = new SqlDataAdapter(cmd9);
                        DataSet DS9 = new DataSet();
                        da9.Fill(DS9);
                        string ItemId = "";
                        if (DS9.Tables[0].Rows.Count > 0)
                        {
                            ItemId = DS9.Tables[0].Rows[0]["Id"].ToString();
                        }
                        string StrSPRDetails = fun.insert("tblMM_SPR_DetailsA", "MId,SPRNo,ItemId,Qty,Rate,SupplierId,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + MId + "','" + SPRIdStr + "','" + ItemId + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(DS5.Tables[0].Rows[p]["Rate"].ToString()).ToString("N2")) + "','" + DS5.Tables[0].Rows[p]["SupplierId"].ToString() + "','" + DS5.Tables[0].Rows[p]["AHId"].ToString() + "','" + DS5.Tables[0].Rows[p]["WONo"].ToString() + "','" + DS5.Tables[0].Rows[p]["DeptId"].ToString() + "','" + DS5.Tables[0].Rows[p]["Remarks"].ToString() + "','" + DS5.Tables[0].Rows[p]["DelDate"].ToString() + "','" + DS5.Tables[0].Rows[p]["Discount"].ToString() + "'");
                        SqlCommand cmd15 = new SqlCommand(StrSPRDetails, con);
                        //con.Open();
                        cmd15.ExecuteNonQuery();
                        //con.Close();
                        string sqlt = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + SPRIdStr + "' , LockDate='" + CDate + "' ,LockTime='" + CTime + "'", "ItemId='" + ItemId + "' And  Type='1'  ");
                        SqlCommand cmdt = new SqlCommand(sqlt, con);
                        //con.Open();
                        cmdt.ExecuteNonQuery();
                        // con.Close();
                    }
                }

                string delsql = fun.delete("tblMM_SPR_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                // con.Open();
                cmd12.ExecuteNonQuery();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Selected records are not found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }


        }
        catch (Exception es)
        {

        }
        finally
        {
            con.Close();
            con.Dispose();
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

    protected void rdwono_CheckedChanged(object sender, EventArgs e)
    {
        if (rdwono.Checked == true)
        {
            ReqWono.Visible = true;
        }
        else if (rddept.Checked == true)
        {
            ReqWono.Visible = false;
        }
    }
    protected void rddept_CheckedChanged(object sender, EventArgs e)
    {
        if (rdwono.Checked == true)
        {
            ReqWono.Visible = true;
        }
        else if (rddept.Checked == true)
        {
            ReqWono.Visible = false;
        }

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_Dashboard.aspx?ModId=6&SubModId=31");
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
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


    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpCategory.SelectedValue != "Select")
            {
                DrpSearchCode.Visible = true;
                txtSearchItemCode.Text = "";
            }
        }
        catch (Exception ex) { }
    }


    protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (DrpType.SelectedValue)
            {
                case "Category":
                    {
                        DrpSearchCode.Visible = true;
                        DropDownList3.Visible = true;
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";
                        DrpCategory.Visible = true;

                        string connStr = fun.Connection();
                        SqlConnection con = new SqlConnection(connStr);

                        DataSet DS = new DataSet();
                        string StrCat = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
                        SqlCommand Cmd = new SqlCommand(StrCat, con);
                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DA.Fill(DS, "tblDG_Category_Master");
                        DrpCategory.DataSource = DS.Tables["tblDG_Category_Master"];
                        DrpCategory.DataTextField = "Category";
                        DrpCategory.DataValueField = "CId";
                        DrpCategory.DataBind();
                        DrpCategory.Items.Insert(0, "Select");
                        DrpCategory.ClearSelection();

                        //string loc = fun.select1("Id,LocationLabel+'-'+tblDG_Location_Master.LocationNo As Location ", "tblDG_Location_Master");
                        //SqlCommand cmdloc = new SqlCommand(loc, con);
                        //SqlDataAdapter daloc = new SqlDataAdapter(cmdloc);
                        //DataSet dsloc = new DataSet();
                        //daloc.Fill(dsloc, "tblDG_Location_Master");
                        //DropDownList3.DataSource = dsloc.Tables["tblDG_Location_Master"];
                        //DropDownList3.DataTextField = "Location";
                        //DropDownList3.DataValueField = "Id";
                        //DropDownList3.DataBind();
                        //DropDownList3.Items.Insert(0, "Select");
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
                        DrpCategory.Visible = false;
                        DrpCategory.Items.Clear();
                        DrpCategory.Items.Insert(0, "Select");

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
        catch (Exception ex) { }
    }

    protected void RbtnExpenses_CheckedChanged(object sender, EventArgs e)
    {
        fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void RbtnSerProvider_CheckedChanged(object sender, EventArgs e)
    {
        fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
        TabContainer1.ActiveTabIndex = 1;
    }
}


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
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


public partial class Module_Design_Transactions_BOM_WoItems : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string wono = "";
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string SId = "";
    int parentid = 0;
    int childid = 0;
    string AsslyNo = "";
    string EquipNo = "";
    public void CreateNextUnitPartNo()
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);

            string a = lblasslyno.Text;


            string[] b = a.Split('-');
            string un = b[0] + "-" + b[1];

            txtUnitNo.Text = b[1];
            EquipNo = b[0];
            lblEquipNo.Text = EquipNo;
            txtPartNo.Text = (Convert.ToInt32(b[2]) + 1).ToString("D2");

            string StrSql2 = fun.select("PartNo", "tblDG_BOM_Master", "CompId='" + CompId + "' And PartNo is not null AND FinYearId<='" + FinYearId + "' And  PartNo like '" + un + "%' order by PartNo desc");
            SqlCommand cmdEquip2 = new SqlCommand(StrSql2, con);
            SqlDataAdapter daEquip2 = new SqlDataAdapter(cmdEquip2);
            DataSet dsEquip2 = new DataSet();
            daEquip2.Fill(dsEquip2);

            int pn1 = 0;
            string pn2 = "";

            if (dsEquip2.Tables[0].Rows.Count > 0)
            {
                string a1 = dsEquip2.Tables[0].Rows[0]["PartNo"].ToString();
                string[] b1 = a1.Split('-');
                pn1 = Convert.ToInt32(b1[2]) + 1;
                pn2 = pn1.ToString("D2");
            }

            string StrSql3 = fun.select("PartNo", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + un + "%' order by PartNo desc");
            SqlCommand cmdEquip3 = new SqlCommand(StrSql3, con);
            SqlDataAdapter daEquip3 = new SqlDataAdapter(cmdEquip3);
            DataSet dsEquip3 = new DataSet();
            daEquip3.Fill(dsEquip3);

            int pn3 = 0;
            string pn4 = "";
            if (dsEquip3.Tables[0].Rows.Count > 0)
            {
                string a2 = dsEquip3.Tables[0].Rows[0]["PartNo"].ToString();
                string[] b2 = a2.Split('-');
                pn3 = Convert.ToInt32(b2[2]) + 1;
                pn4 = pn3.ToString("D2");

            }

            if (pn1 > pn3)
            {
                txtPartNo.Text = pn2;
            }
            else
            {
                txtPartNo.Text = pn4;
            }

        }
        catch (Exception ett)
        {
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        con.Open();
        try
        {
            lblMsg.Text = "";
            lblMsg1.Text = "";
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            SId = Session["username"].ToString();
            wono = Request.QueryString["WONo"].ToString();
            AsslyNo = Request.QueryString["ItemId"];
            parentid = Convert.ToInt32(Request.QueryString["PId"]);
            childid = Convert.ToInt32(Request.QueryString["CId"]);
            lblwono.Text = wono.ToString();
            // To Show Assembly in which part is to copy.            
            lblasslyno.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(AsslyNo));

            if (!IsPostBack)
            {
                DrpCategory1.Items.Clear();
                DrpCategory1.Items.Insert(0, "Select");
                DropDownList3.Visible = false;
                DrpCategory1.Visible = false;
                DrpSearchCode.Visible = false;
                txtSearchItemCode.Visible = false;
                fun.drpunit(DDLUnitBasic);
                string sd = DrpCategory1.SelectedValue;
                string c = DrpSearchCode.SelectedValue;
                string d = txtSearchItemCode.Text;
                string e1 = DrpType.SelectedValue;
                this.Fillgrid(sd, c, d, e1);

            }
            this.CreateNextUnitPartNo();
            // For Tab Copy
            frm2.Attributes["src"] = "BOM_Design_CopyWo.aspx?WONoDest=" + wono + "&DestPId=" + parentid + "&DestCId=" + childid + "";
            this.FillDataGrid();

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

        }
        catch (Exception ex)
        {

        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            this.loaddata();
        }

        string WODesignDate = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
        SqlCommand CmdDate = new SqlCommand(WODesignDate, con);
        SqlDataAdapter DaDate = new SqlDataAdapter(CmdDate);
        DataSet DsDate = new DataSet();
        DaDate.Fill(DsDate);
        string Designdate = (DsDate.Tables[0].Rows[0][0].ToString());
        string CDate = fun.getCurrDate();
        if (Convert.ToDateTime(Designdate) >= Convert.ToDateTime(CDate))
        {
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
        }
    }

    public void loaddata()
    {
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        string StrSql = fun.select("*", "tblDG_ECN_Reason", "CompId='" + CompId + "'");
        SqlCommand cmdsupId = new SqlCommand(StrSql, con);
        SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
        DataSet DSSql = new DataSet();
        dasupId.Fill(DSSql);
        GridView1.DataSource = DSSql;
        GridView1.DataBind();

    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    public void FillDataGrid()
    {
        try
        {
            SqlCommand cmdgrid = new SqlCommand(fun.select("Id,ItemId,ItemCode,ManfDesc,UOMBasic,Qty,PartNo", "tblDG_BOMItem_Temp", "WONo='" + wono + "' AND Childid='" + childid + "' AND SessionId='" + SId + "' AND CompId='" + CompId + "'Order by Id Desc"), con);

            SqlDataAdapter dagrid = new SqlDataAdapter(cmdgrid);
            DataSet dsgrid = new DataSet();
            dagrid.Fill(dsgrid);
            double AsslyNewqty = fun.RecurQty(wono, parentid, childid, 1, CompId, FinYearId);

            // View Selected Item
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("ItemCode", typeof(string));
            dtNew.Columns.Add("ManfDesc", typeof(string));
            dtNew.Columns.Add("UOMBasic", typeof(string));
            dtNew.Columns.Add("AsslyQty", typeof(string));
            dtNew.Columns.Add("Qty", typeof(double));
            dtNew.Columns.Add("BOMQty", typeof(double));
            dtNew.Columns.Add("Id", typeof(int));
            dtNew.Columns.Add("ItemId", typeof(string));
            DataRow drNew;

            for (int k = 0; k < dsgrid.Tables[0].Rows.Count; k++)
            {
                drNew = dtNew.NewRow();

                string ItemCode = "";
                string MangDesc = "";
                string UOMBasic = "";
                if (dsgrid.Tables[0].Rows[k]["ItemId"] != DBNull.Value)
                {
                    string SqlStr = fun.select("tblDG_Item_Master.CId,tblDG_Item_Master.PartNo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UBasic", "tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id='" + dsgrid.Tables[0].Rows[k]["ItemId"].ToString() + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic And tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'");
                    SqlCommand cmditm = new SqlCommand(SqlStr, con);
                    SqlDataAdapter daitm = new SqlDataAdapter(cmditm);
                    DataSet dsitm = new DataSet();
                    daitm.Fill(dsitm);
                    if (dsitm.Tables[0].Rows.Count > 0)
                    {
                        if (dsitm.Tables[0].Rows[0]["CId"] != DBNull.Value)
                        {
                            ItemCode = dsitm.Tables[0].Rows[0]["ItemCode"].ToString();
                        }

                        else
                        {
                            ItemCode = dsitm.Tables[0].Rows[0]["PartNo"].ToString();
                        }
                        MangDesc = dsitm.Tables[0].Rows[0]["ManfDesc"].ToString();
                        UOMBasic = dsitm.Tables[0].Rows[0]["UBasic"].ToString();
                    }

                }
                else
                {
                    ItemCode = dsgrid.Tables[0].Rows[k]["PartNo"].ToString();
                    MangDesc = dsgrid.Tables[0].Rows[k]["ManfDesc"].ToString();

                    SqlCommand cmduombasic = new SqlCommand(fun.select("Symbol", "Unit_Master", "Id='" + dsgrid.Tables[0].Rows[k]["UOMBasic"].ToString() + "'"), con);
                    SqlDataAdapter dauombasic = new SqlDataAdapter(cmduombasic);
                    DataSet dsuombasic = new DataSet();
                    dauombasic.Fill(dsuombasic);
                    UOMBasic = dsuombasic.Tables[0].Rows[0]["Symbol"].ToString();

                }

                drNew[0] = ItemCode;
                drNew[1] = MangDesc;
                drNew[2] = UOMBasic;
                drNew[3] = Convert.ToDouble(decimal.Parse(AsslyNewqty.ToString()).ToString("N3"));
                drNew[4] = Convert.ToDouble(decimal.Parse(dsgrid.Tables[0].Rows[k]["Qty"].ToString()).ToString("N3"));
                drNew[5] = Convert.ToDouble(decimal.Parse((AsslyNewqty * Convert.ToDouble(dsgrid.Tables[0].Rows[k]["Qty"])).ToString()).ToString("N3"));
                drNew[6] = Convert.ToInt32(dsgrid.Tables[0].Rows[k]["Id"]);
                drNew[7] = (dsgrid.Tables[0].Rows[k]["ItemId"]).ToString();
                dtNew.Rows.Add(drNew);
                dtNew.AcceptChanges();
            }

            GridView3.DataSource = dtNew;
            GridView3.DataBind();
        }
        catch (Exception ex)
        {
        }

    }
    public void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "del")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Id = ((Label)row.FindControl("lblid")).Text;
                string ItemId = ((Label)row.FindControl("lblItemId")).Text;

                string connStr = fun.Connection();
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                string Sqlgrid = fun.delete("tblDG_BOMItem_Temp", "Id='" + Id + "' AND SessionId='" + SId + "' And CompId='" + CompId + "'");
                SqlCommand cmdgrid = new SqlCommand(Sqlgrid, con);
                cmdgrid.ExecuteNonQuery();

                string Sql = fun.select("Id", "tblDG_ECN_Master_Temp", "ItemId='" + ItemId + "'");
                SqlCommand cmdSql = new SqlCommand(Sql, con);
                SqlDataAdapter DaSql = new SqlDataAdapter(cmdSql);
                DataSet DSSql = new DataSet();
                DaSql.Fill(DSSql);
                if (DSSql.Tables[0].Rows.Count > 0 && DSSql.Tables[0].Rows[0][0] != DBNull.Value)
                {

                    SqlCommand cmd1 = new SqlCommand(fun.delete("tblDG_ECN_Details_Temp", "MId='" + DSSql.Tables[0].Rows[0][0].ToString() + "'       "), con);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(fun.delete("tblDG_ECN_Master_Temp", "Id='" + DSSql.Tables[0].Rows[0][0].ToString() + "' and ItemId='" + ItemId + "' AND SessionId='" + SId + "' And CompId='" + CompId + "'"), con);
                    cmd2.ExecuteNonQuery();
                }

                this.FillDataGrid();
                con.Close();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataSet ItemDs = new DataSet();

        try
        {
            if (e.CommandName == "Add")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string txtQty = ((TextBox)row.FindControl("txtQty")).Text;
                string wono = Request.QueryString["WONo"].ToString();
                string WODesignDate = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
                SqlCommand CmdDate = new SqlCommand(WODesignDate, con);
                SqlDataAdapter DaDate = new SqlDataAdapter(CmdDate);
                DataSet DsDate = new DataSet();
                DaDate.Fill(DsDate);
                string Designdate = (DsDate.Tables[0].Rows[0][0].ToString());
                int childid = Convert.ToInt32(Request.QueryString["CId"].ToString());
                int Id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                string ItemId = fun.select("ItemId", "tblDG_BOMItem_Temp", "ItemId='" + Id + "'And CompId='" + CompId + "' And WONo='" + wono.ToString() + "' And ChildId='" + childid + "'");
                SqlCommand itemCmd = new SqlCommand(ItemId, con);
                SqlDataAdapter itemDa = new SqlDataAdapter(itemCmd);
                itemDa.Fill(ItemDs, "tblDG_BOMItem_Temp");
                string ItemId2 = fun.select("ItemId", "tblDG_BOM_Master", "ItemId='" + Id + "'And CompId='" + CompId + "' And WONo='" + wono.ToString() + "' And PId='" + childid + "'");
                SqlCommand itemCmd2 = new SqlCommand(ItemId2, con);
                SqlDataAdapter itemDa2 = new SqlDataAdapter(itemCmd2);
                DataSet ItemDs2 = new DataSet();
                itemDa2.Fill(ItemDs2, "tblDG_BOM_Master");
                con.Open();
                string CDate = fun.getCurrDate();

                if (Convert.ToDateTime(Designdate) >= Convert.ToDateTime(CDate))
                {
                    if (txtQty != "")
                    {
                        if (fun.NumberValidationQty(txtQty) == true)
                        {
                            if (ItemDs.Tables[0].Rows.Count == 0 && ItemDs2.Tables[0].Rows.Count == 0)
                            {
                                if (Convert.ToDouble(txtQty) > 0)
                                {
                                    string strcmd = fun.insert("tblDG_BOMItem_Temp", "CompId,SessionId,WONo,ItemId,Qty,ChildId", "'" + CompId + "','" + SId.ToString() + "','" + wono.ToString() + "','" + Id + "','" + Convert.ToDouble(decimal.Parse(txtQty.ToString()).ToString("N3")) + "','" + childid + "'");
                                    SqlCommand cmdgrid = new SqlCommand(strcmd, con);
                                    cmdgrid.ExecuteNonQuery();
                                    string mystringmsg = string.Empty;
                                    mystringmsg = "Record has been Inserted.";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                                    string sd = DrpCategory1.SelectedValue;
                                    string c = DrpSearchCode.SelectedValue;
                                    string d = txtSearchItemCode.Text;
                                    string e1 = DrpType.SelectedValue;
                                    this.Fillgrid(sd, c, d, e1);


                                }
                                else
                                {
                                    string mystringmsg = string.Empty;
                                    mystringmsg = "Req. Qty must be greater than zero.";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                                }

                            }
                            else
                            {
                                string mystringmsg = string.Empty;
                                mystringmsg = "Record Already Inserted";
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                            }
                        }
                    }
                    else
                    {

                        string mystringmsg = string.Empty;
                        mystringmsg = "Req. Qty should not be blank.";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                    }
                }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // if Design Date is lesser than current Date...


                else
                {


                    if (txtQty != "")
                    {
                        if (fun.NumberValidationQty(txtQty) == true)
                        {
                            if (ItemDs.Tables[0].Rows.Count == 0 && ItemDs2.Tables[0].Rows.Count == 0)
                            {
                                if (Convert.ToDouble(txtQty) > 0)
                                {

                                    Response.Redirect("ECN_Master.aspx?ItemId=" + Id + "&WONo=" + wono + "&CId=" + childid + "&ParentId=" + parentid + "&Qty=" + txtQty + "&asslyNo=" + AsslyNo + "");

                                }
                                else
                                {
                                    string mystringmsg = string.Empty;
                                    mystringmsg = "Req. Qty must be greater than zero.";
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                                }

                            }
                            else
                            {
                                string mystringmsg = string.Empty;
                                mystringmsg = "Record Already Inserted";
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                            }
                        }
                    }
                    else
                    {

                        string mystringmsg = string.Empty;
                        mystringmsg = "Req. Qty should not be blank.";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                    }



                }

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
    public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        catch (Exception ch)
        {
        }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Add New User Define Items

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        try
        {

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string wono = Request.QueryString["WONo"].ToString();
            int childid = Convert.ToInt32(Request.QueryString["CId"].ToString());
            int PId = Convert.ToInt32(Request.QueryString["PId"].ToString());
            string PartNo = txtPartNo.Text;
            string UnitNo = txtUnitNo.Text;
            string ItemCode = string.Concat(EquipNo, '-', UnitNo, '-', PartNo, '0');
            int ECNFlag = 0;


            string P = string.Concat(EquipNo, '-', UnitNo, '-', PartNo);
            int CompItemLength = fun.ItemCodeLimit(CompId);

            DataSet dsict = new DataSet();

            string Fname = "";
            double len = 0;
            string ContentType = "";
            HttpPostedFile mycv1 = FileUpload1.PostedFile;
            Byte[] pic = null;

            if (FileUpload1.PostedFile != null)
            {
                Stream fscv1 = FileUpload1.PostedFile.InputStream;
                BinaryReader brcv1 = new BinaryReader(fscv1);
                pic = brcv1.ReadBytes((Int32)fscv1.Length);
                Fname = Path.GetFileName(mycv1.FileName);
                len = pic.Length;
                ContentType = mycv1.ContentType;
            }
            string AttName = "";
            double AttSize = 0;
            string AttContentType = "";
            HttpPostedFile mycv = FileUpload2.PostedFile;
            Byte[] AttData = null;

            if (FileUpload2.PostedFile != null)
            {
                Stream fscv = FileUpload2.PostedFile.InputStream;
                BinaryReader brcv = new BinaryReader(fscv);
                AttData = brcv.ReadBytes((Int32)fscv.Length);
                AttName = Path.GetFileName(mycv.FileName);
                AttSize = AttData.Length;
                AttContentType = mycv.ContentType;
            }

            string WODesignDate = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
            SqlCommand CmdDate = new SqlCommand(WODesignDate, con);
            SqlDataAdapter DaDate = new SqlDataAdapter(CmdDate);
            DataSet DsDate = new DataSet();
            DaDate.Fill(DsDate);
            string Designdate = (DsDate.Tables[0].Rows[0][0].ToString());

            if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text) == true && DDLUnitBasic.SelectedItem.Text != "Select" && txtManfDescription.Text != "")
            {
                string cmdItemcode = fun.select("*", "tblDG_Item_Master", "PartNo='" + P + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
                SqlCommand sqlCode = new SqlCommand(cmdItemcode, con);
                SqlDataAdapter sqlDaCode = new SqlDataAdapter(sqlCode);
                DataSet sqlDsCode = new DataSet();
                sqlDaCode.Fill(sqlDsCode, "tblDG_Item_Master");

                if (sqlDsCode.Tables[0].Rows.Count == 0 && Convert.ToDouble(txtQuntity.Text) > 0)
                {
                    string StrSql99 = fun.select("PartNo", "tblDG_BOM_Master", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + P + "'");
                    SqlCommand cmdEquip99 = new SqlCommand(StrSql99, con);
                    SqlDataAdapter daEquip99 = new SqlDataAdapter(cmdEquip99);
                    DataSet dsEquip99 = new DataSet();
                    daEquip99.Fill(dsEquip99, "tblDG_BOM_Master");

                    string StrSql98 = fun.select("PartNo", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' And PartNo is not null AND PartNo like '" + P + "'");
                    SqlCommand cmdEquip98 = new SqlCommand(StrSql98, con);
                    SqlDataAdapter daEquip98 = new SqlDataAdapter(cmdEquip98);
                    DataSet dsEquip98 = new DataSet();
                    daEquip98.Fill(dsEquip98, "tblDG_BOMItem_Temp");

                    string cmdItemcode97 = fun.select("*", "tblDG_Item_Master", "PartNo like '" + P + "' And  CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
                    SqlCommand sqlCode97 = new SqlCommand(cmdItemcode97, con);
                    SqlDataAdapter sqlDaCode97 = new SqlDataAdapter(sqlCode97);
                    DataSet sqlDsCode97 = new DataSet();
                    sqlDaCode97.Fill(sqlDsCode97, "tblDG_Item_Master");


                    if (Convert.ToDateTime(Designdate) >= Convert.ToDateTime(CDate))
                    {
                        ECNFlag = 0;
                    }
                    else
                    {
                        ECNFlag = 1;
                    }
                    if (sqlDsCode97.Tables[0].Rows.Count == 0 && dsEquip98.Tables[0].Rows.Count == 0 && dsEquip99.Tables[0].Rows.Count == 0)
                    {
                        string cmdstrItemMaster = fun.insert("tblDG_BOMItem_Temp",
                        "SessionId,CompId,WONo,EquipmentNo,UnitNo,ChildId,PartNo,ItemCode,Process,ManfDesc,UOMBasic,Qty,ImgFile,ImgName,ImgSize,ImgContentType,SpecSheetName,SpecSheetSize,SpecSheetContentType,SpecSheetData,ECNFlag,Material", "'" + SId.ToString() + "','" + CompId + "','" + wono + "','" + EquipNo + "','" + UnitNo + "','" + childid + "','" + P + "','" + ItemCode + "',0,'" + txtManfDescription.Text + "','" + DDLUnitBasic.SelectedValue + "','" + Convert.ToDouble(decimal.Parse((txtQuntity.Text).ToString()).ToString("N3")) + "',@pic,'" + Fname + "','" + len + "','" + ContentType + "','" + AttName + "','" + AttSize + "','" + AttContentType + "',@AttData,'" + ECNFlag + "','" + txtmat.Text + "'");

                        SqlCommand cmd = new SqlCommand(cmdstrItemMaster, con);
                        cmd.Parameters.AddWithValue("@pic", pic);
                        cmd.Parameters.AddWithValue("@AttData", AttData);
                        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
                        txtUnitNo.Text = "";
                        txtPartNo.Text = "";
                        txtQuntity.Text = "";
                        txtManfDescription.Text = "";
                        txtmat.Text = "";

                        fun.drpunit(DDLUnitBasic);
                        if (Convert.ToDateTime(Designdate) < Convert.ToDateTime(CDate))
                        {


                            int u = 1;
                            string MId = "";
                            int y = 0;
                            int x = 0;
                            int itemid = 0;
                            foreach (GridViewRow grv in GridView1.Rows)
                            {
                                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                                {
                                    string Id = ((Label)grv.FindControl("lblId55")).Text;
                                    string remarks = ((TextBox)grv.FindControl("TxtRemarks")).Text;
                                    if (u == 1)
                                    {
                                        cmd.ExecuteNonQuery();
                                        int BOMMId = 0;
                                        string getBomId = fun.select("Id", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' Order by Id Desc");
                                        SqlCommand cmdBOM = new SqlCommand(getBomId, con);
                                        SqlDataAdapter daBOM = new SqlDataAdapter(cmdBOM);
                                        DataSet DSBOM = new DataSet();
                                        daBOM.Fill(DSBOM);
                                        BOMMId = Convert.ToInt32(DSBOM.Tables[0].Rows[0]["Id"]);

                                        string sqlecn = fun.insert("tblDG_ECN_Master_Temp", "MId,SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId,ItemCOde", "'" + BOMMId + "','" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + itemid + "','" + wono + "','" + PId + "','" + childid + "','" + ItemCode + "'");
                                        SqlCommand cmdECN = new SqlCommand(sqlecn, con);
                                        cmdECN.ExecuteNonQuery();
                                        u = 0;
                                        string getId = fun.select("Id", "tblDG_ECN_Master_Temp", "CompId='" + CompId + "' Order by Id Desc");
                                        SqlCommand cmd5 = new SqlCommand(getId, con);
                                        SqlDataAdapter daAmd5 = new SqlDataAdapter(cmd5);
                                        DataSet DSAmd5 = new DataSet();
                                        daAmd5.Fill(DSAmd5);
                                        MId = DSAmd5.Tables[0].Rows[0]["Id"].ToString();
                                    }

                                    string sqlecn1 = fun.insert("tblDG_ECN_Details_Temp", "MId,ECNReason,Remarks", "'" + MId + "','" + Id + "','" + remarks + "'");
                                    SqlCommand cmdECN1 = new SqlCommand(sqlecn1, con);
                                    cmdECN1.ExecuteNonQuery();

                                    y++;
                                }
                                else
                                {
                                    x++;

                                }
                            }

                            if (x > 0)
                            {
                                string myStringVariable = string.Empty;
                                myStringVariable = " Enter reasons in Grid!";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                                this.CreateNextUnitPartNo();
                                TabContainer1.ActiveTabIndex = 1;
                            }
                            if (y > 0)
                            {
                                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                            }

                        }
                        else
                        {
                            cmd.ExecuteNonQuery();

                            Page.Response.Redirect(Page.Request.Url.ToString(), true);

                            this.CreateNextUnitPartNo();
                            TabContainer1.ActiveTabIndex = 1;
                        }

                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        myStringVariable = "Record Already Exists!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    }
                }
                else
                {
                    string mystringmsg = string.Empty;
                    mystringmsg = "Record Already Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mystringmsg + "');", true);
                }
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }
    public void AddToTPLBOM(int cnv)
    {
        try
        {
            string wono = Request.QueryString["WONo"].ToString();
            int parentid = Convert.ToInt32(Request.QueryString["PId"]);
            int childid = Convert.ToInt32(Request.QueryString["CId"]);
            string sysdate = fun.getCurrDate();
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            // string connStr = fun.Connection();
            // SqlConnection con = new SqlConnection(connStr);
            con.Open();
            int ItemIdNocode = 0;
            //To Get Data from Temp Table to Insert Into Item Master, TPL & BOM Table

            string cmdstr = fun.select("*", "tblDG_BOMItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + wono.ToString() + "'");
            SqlCommand sql = new SqlCommand(cmdstr, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sql);
            DataSet sqlDs = new DataSet();
            sqlDa.Fill(sqlDs, "tblDG_BOMItem_Temp");
            if (sqlDs.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < sqlDs.Tables[0].Rows.Count; i++)
                {
                    int NextCid = fun.getBOMCId(wono, CompId, FinYearId);
                    if (sqlDs.Tables[0].Rows[i]["ItemId"] == DBNull.Value) //New Item Created
                    {
                        string cmdItemcode = fun.select("*", "tblDG_Item_Master", "ItemCode='" + sqlDs.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
                        SqlCommand sqlCode = new SqlCommand(cmdItemcode, con);
                        SqlDataAdapter sqlDaCode = new SqlDataAdapter(sqlCode);
                        DataSet sqlDsCode = new DataSet();
                        sqlDaCode.Fill(sqlDsCode, "tblDG_Item_Master");
                        if (sqlDsCode.Tables[0].Rows.Count == 0)
                        {
                            string OpBalDate = fun.FromDate(fun.getOpeningDate(CompId, FinYearId));
                            Byte[] pic = ((Byte[])(sqlDs.Tables[0].Rows[i]["ImgFile"]));
                            Byte[] AttData = ((Byte[])(sqlDs.Tables[0].Rows[i]["SpecSheetData"]));

                            string cmdInsert = fun.insert("tblDG_Item_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,PartNo,ItemCode,ManfDesc,UOMBasic,OpeningBalDate,FileName,FileSize,ContentType,FileData,AttName,AttSize,AttContentType,AttData", "'" + sysdate.ToString() + "','" + CTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + sqlDs.Tables[0].Rows[i]["SessionId"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["PartNo"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ItemCode"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ManfDesc"].ToString() + "','" + Convert.ToInt32(sqlDs.Tables[0].Rows[i]["UOMBasic"]) + "','" + OpBalDate + "','" + sqlDs.Tables[0].Rows[i]["ImgName"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ImgSize"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ImgContentType"].ToString() + "',@pic,'" + sqlDs.Tables[0].Rows[i]["SpecSheetName"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["SpecSheetSize"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["SpecSheetContentType"].ToString() + "',@AttData");
                            SqlCommand sqlInsert = new SqlCommand(cmdInsert, con);
                            sqlInsert.Parameters.AddWithValue("@pic", pic);
                            sqlInsert.Parameters.AddWithValue("@AttData", AttData);
                            sqlInsert.ExecuteNonQuery();
                            string getItemId = fun.select("*", "tblDG_Item_Master", "ItemCode='" + sqlDs.Tables[0].Rows[i]["ItemCode"].ToString() + "'And CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'");
                            SqlCommand sqlget = new SqlCommand(getItemId, con);
                            SqlDataAdapter sqlDaget = new SqlDataAdapter(sqlget);
                            DataSet sqlDsget = new DataSet();
                            sqlDaget.Fill(sqlDsget, "tblDG_Item_Master");
                            ItemIdNocode = Convert.ToInt32(sqlDsget.Tables[0].Rows[0]["Id"]);
                            if (sqlDsget.Tables[0].Rows.Count > 0)
                            {
                                string cmdtplId = fun.select("ItemId", "tblDG_BOM_Master", "CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'And WONo='" + wono.ToString() + "'And PId='" + parentid.ToString() + "'And CId='" + childid.ToString() + "' And ItemId='" + sqlDsget.Tables[0].Rows[0]["Id"].ToString() + "'");
                                SqlCommand sqltplId = new SqlCommand(cmdtplId, con);
                                SqlDataAdapter sqlDatplId = new SqlDataAdapter(sqltplId);
                                DataSet sqlDstplId = new DataSet();
                                sqlDatplId.Fill(sqlDstplId, "tblDG_BOM_Master");

                                if (sqlDstplId.Tables[0].Rows.Count == 0)
                                {
                                    string cmdBOM = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,PartNo,EquipmentNo,UnitNo,ECNFlag,Material", "'" + sysdate.ToString() + "','" + CTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + wono.ToString() + "','" + childid.ToString() + "','" + NextCid + "','" + sqlDsget.Tables[0].Rows[0]["Id"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["Qty"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["PartNo"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["EquipmentNo"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["UnitNo"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ECNFLag"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["Material"].ToString() + "'");
                                    SqlCommand sqlBOM = new SqlCommand(cmdBOM, con);
                                    sqlBOM.ExecuteNonQuery();
                                    ///Updating UpdateWO Field 
                                    string sqlwo = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wono + "' And  CompId='" + CompId + "' ");
                                    SqlCommand cmdwo = new SqlCommand(sqlwo, con);
                                    cmdwo.ExecuteNonQuery();

                                }
                            }
                        }
                    }
                    else //From Item Master
                    {
                        string cmdItemId2 = fun.select("Id", "tblDG_Item_Master", "CompId='" + CompId + "'And FinYearId<='" + FinYearId + "'And Id='" + sqlDs.Tables[0].Rows[i]["ItemId"].ToString() + "' ");
                        SqlCommand sqlId2 = new SqlCommand(cmdItemId2, con);
                        SqlDataAdapter sqlDaId2 = new SqlDataAdapter(sqlId2);
                        DataSet sqlDsId2 = new DataSet();
                        sqlDaId2.Fill(sqlDsId2, "tblDG_Item_Master");

                        if (sqlDsId2.Tables[0].Rows.Count > 0)
                        {
                            string cmdtplId2 = fun.select("ItemId", "tblDG_BOM_Master", "CompId='" + CompId
 + "'And FinYearId<='" + FinYearId + "'And WONo='" + wono.ToString() + "'And PId='" + childid.ToString() + "' And ItemId='" + sqlDsId2.Tables[0].Rows[0]["Id"].ToString() + "' ");
                            SqlCommand sqltplId2 = new SqlCommand(cmdtplId2, con);
                            SqlDataAdapter sqlDatplId2 = new SqlDataAdapter(sqltplId2);
                            DataSet sqlDstplId2 = new DataSet();
                            sqlDatplId2.Fill(sqlDstplId2, "tblDG_BOM_Master");
                            if (sqlDstplId2.Tables[0].Rows.Count == 0)
                            {
                                string cmdBOM2 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,PId,CId,ItemId,Qty,ECNFLag,Material", "'" + sysdate.ToString() + "','" + CTime.ToString() + "','" + CompId + "','" + FinYearId + "','" + SId.ToString() + "','" + wono.ToString() + "','" + childid.ToString() + "','" + NextCid + "','" + sqlDsId2.Tables[0].Rows[0]["Id"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["Qty"].ToString() + "','" + sqlDs.Tables[0].Rows[i]["ECNFLag"].ToString() + "','"+txtmat.Text+"'");
                                SqlCommand sqlBOM2 = new SqlCommand(cmdBOM2, con);
                                sqlBOM2.ExecuteNonQuery();
                                ///Updating UpdateWO Field 
                                string sqlwo = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wono + "' And  CompId='" + CompId + "' ");
                                SqlCommand cmdwo = new SqlCommand(sqlwo, con);
                                cmdwo.ExecuteNonQuery();
                            }
                        }
                    }

                    ///// Enetr Data in ECN Master and Details...            
                    string SqlECN = fun.select("Id,WONo,ItemId,PId,CId,ItemCode", "tblDG_ECN_Master_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + wono.ToString() + "' And MId='" + Convert.ToInt32(sqlDs.Tables[0].Rows[i]["Id"]) + "'");
                    SqlCommand cmdECN = new SqlCommand(SqlECN, con);
                    SqlDataAdapter daECN = new SqlDataAdapter(cmdECN);
                    DataSet dsECN = new DataSet();
                    daECN.Fill(dsECN);
                    int ItemIdECN = 0;
                    for (int s = 0; s < dsECN.Tables[0].Rows.Count; s++)
                    {
                        if (Convert.ToInt32(dsECN.Tables[0].Rows[s]["ItemId"]) == 0)
                        {
                            ItemIdECN = ItemIdNocode;
                        }
                        else
                        {
                            ItemIdECN = Convert.ToInt32(dsECN.Tables[0].Rows[s]["ItemId"]);
                        }
                        string sqlIn = fun.insert("tblDG_ECN_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + ItemIdECN + "','" + dsECN.Tables[0].Rows[s]["WONo"].ToString() + "','" + dsECN.Tables[0].Rows[s]["PId"].ToString() + "','" + dsECN.Tables[0].Rows[s]["CId"].ToString() + "'");
                        SqlCommand cmdIn = new SqlCommand(sqlIn, con);
                        cmdIn.ExecuteNonQuery();
                        string Sqlk = fun.select("Id", "tblDG_ECN_Master", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'And WONo='" + wono.ToString() + "'  order by Id Desc");
                        SqlCommand cmdk = new SqlCommand(Sqlk, con);
                        SqlDataAdapter dak = new SqlDataAdapter(cmdk);
                        DataSet dsk = new DataSet();
                        dak.Fill(dsk);
                        string Sqlecd = fun.select("*", "tblDG_ECN_Details_Temp", "MId='" + dsECN.Tables[0].Rows[0]["Id"].ToString() + "'");
                        SqlCommand cmdecd = new SqlCommand(Sqlecd, con);
                        SqlDataAdapter daecd = new SqlDataAdapter(cmdecd);
                        DataSet dSecd = new DataSet();
                        daecd.Fill(dSecd);
                        for (int l = 0; l < dSecd.Tables[0].Rows.Count; l++)
                        {
                            string sqlInd = fun.insert("tblDG_ECN_Details", "MId,ECNReason,Remarks", "'" + dsk.Tables[0].Rows[0]["Id"].ToString() + "','" + dSecd.Tables[0].Rows[l]["ECNReason"].ToString() + "','" + dSecd.Tables[0].Rows[l]["Remarks"].ToString() + "'");
                            SqlCommand cmdInd = new SqlCommand(sqlInd, con);
                            cmdInd.ExecuteNonQuery();
                        }
                    }


                }
            }


            string Sql = fun.select("Id", "tblDG_ECN_Master_Temp", " SessionId='" + SId + "' And CompId='" + CompId + "'");
            SqlCommand cmdSql = new SqlCommand(Sql, con);
            SqlDataAdapter DaSql = new SqlDataAdapter(cmdSql);
            DataSet DSSql = new DataSet();
            DaSql.Fill(DSSql);
            for (int f = 0; f < DSSql.Tables[0].Rows.Count; f++)
            {
                string delECN_Dtls = fun.delete("tblDG_ECN_Details_Temp", "MId='" + DSSql.Tables[0].Rows[f][0].ToString() + "'");
                SqlCommand cmd1 = new SqlCommand(delECN_Dtls, con);
                cmd1.ExecuteNonQuery();
                string delECN_Mstr = fun.delete("tblDG_ECN_Master_Temp", "Id='" + DSSql.Tables[0].Rows[f][0].ToString() + "'");
                SqlCommand cmd2 = new SqlCommand(delECN_Mstr, con);
                cmd2.ExecuteNonQuery();
            }
            this.clearTempDb(CompId, SId, wono);
            Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    public void clearTempDb(int getCId, string getSId, string getwono)
    {
        try
        {
            //To Empty Temp table After Insert into permanant table
            //connStr = fun.Connection();
            //con = new SqlConnection(connStr);
            //con.Open();
            string strDelete = fun.delete("tblDG_BOMItem_Temp", "CompId='" + getCId + "'And SessionId='" + getSId + "'And WONo='" + getwono + "'"); SqlCommand sqlDelete = new SqlCommand(strDelete, con);
            sqlDelete.ExecuteNonQuery();
            //con.Close();

        }
        catch (Exception ex)
        {

        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
    }
    protected void btnaddtobom_Click(object sender, EventArgs e)
    {
        // Convert to BOM
        this.AddToTPLBOM(1);
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

                        string myStringVariable = string.Empty;
                        myStringVariable = "Please Select Category or WO Items.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    }
                    break;
            }
        }

        catch (Exception ex)
        {
        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.FillDataGrid();
        }
        catch (Exception ex)
        {
        }

    }
    protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpSearchCode.SelectedItem.Text == "Location")
            {

                DropDownList3.Visible = true;
                txtSearchItemCode.Visible = false;
                //string sd = DrpCategory1.SelectedValue;
                //string c = DrpSearchCode.SelectedValue;
                //string d = txtSearchItemCode.Text;
                //string e1 = DrpType.SelectedValue;
                //this.Fillgrid(sd, c, d, e1);

            }
            else
            {
                DropDownList3.Visible = false;
                txtSearchItemCode.Visible = true;
                //string sd = DrpCategory1.SelectedValue;
                //string c = DrpSearchCode.SelectedValue;
                //string d = txtSearchItemCode.Text;
                //string e1 = DrpType.SelectedValue;
                //this.Fillgrid(sd, c, d, e1);
            }
        }

        catch (Exception ex) { }
    }
   
}

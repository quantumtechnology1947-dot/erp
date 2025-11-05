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
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;

public partial class Module_Design_Transactions_BOM_Design_WO_TreeView_Delete : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    int CompId = 0;
    int FinYearId = 0;
    string SId = "";
    String ConnString = "";
    SqlConnection conn;
    string woQueryStr = "";
    public DataTable GetDataTable(int drpValue)
    {

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable myDataTable = new DataTable();
        DataSet DS = new DataSet();
        Label2.Text = woQueryStr;
        try
        {
            conn.Open();
            // Delete Temp TPL 
            string strDelete = fun.delete("tblDG_BOMItem_Temp", "CompId='" + CompId + "'And SessionId='" + SId.ToString() + "'");
            SqlCommand sqlDelete = new SqlCommand(strDelete, conn);
            sqlDelete.ExecuteNonQuery();
            string StrSql = string.Empty;
            DataRow dr;
            // Generate Tree Structure
            myDataTable.Columns.Add(new System.Data.DataColumn("ItemId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("PId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("CId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Item Code", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Unit Qty", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("BOM Qty", typeof(string)));            
            myDataTable.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Revision", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Material", typeof(string)));

            if (drpValue == 1)
            {
                string icSql = string.Empty;
                StrSql = fun.select("PId,tblDG_BOM_Master.CId", "tblDG_BOM_Master,tblDG_Item_Master", "WONo='" + woQueryStr + "'And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'And tblDG_Item_Master.CId Is not null Order By PId ASC");
                adapter.SelectCommand = new SqlCommand(StrSql, conn);
                adapter.Fill(DS, "tblDG_BOM_Master");
                List<string> li = new List<string>();
                for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
                {
                    li = fun.BOMTree_Search(woQueryStr, Convert.ToInt32(DS.Tables[0].Rows[p]["PId"]), Convert.ToInt32(DS.Tables[0].Rows[p]["CId"]));
                }
                for (int i = 0; i < li.Count; i++)
                {

                    dr = myDataTable.NewRow();
                    icSql = fun.select("ItemId,ItemCode,UOMBasic,tblDG_Item_Master.PartNo,ManfDesc,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.Id,tblDG_BOM_Master.Revision,Material", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(li[i]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + woQueryStr + "'");
                    SqlCommand cmditemCode = new SqlCommand(icSql, conn);
                    SqlDataAdapter Dr = new SqlDataAdapter(cmditemCode);
                    DataSet DsIt = new DataSet();
                    Dr.Fill(DsIt, "tblDG_Item_Master");
                    if (DsIt.Tables[0].Rows.Count > 0)
                    {

                        dr[0] = DsIt.Tables[0].Rows[0]["ItemId"];
                        dr[1] = DsIt.Tables[0].Rows[0]["WONo"].ToString();
                        dr[2] = DsIt.Tables[0].Rows[0]["PId"];
                        dr[3] = DsIt.Tables[0].Rows[0]["CId"];
                        dr[7] = decimal.Parse(DsIt.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
                        if (DsIt.Tables[0].Rows[0]["CId"] != DBNull.Value)
                        {
                            dr[4] = DsIt.Tables[0].Rows[0]["ItemCode"].ToString();
                        }
                        else
                        {
                            dr[4] = DsIt.Tables[0].Rows[0]["PartNo"].ToString();
                        }
                        dr[5] = DsIt.Tables[0].Rows[0]["ManfDesc"].ToString();
                        string utSql = fun.select("Symbol", "Unit_Master", "Id='" + Convert.ToInt32(DsIt.Tables[0].Rows[0]["UOMBasic"]) + "'");
                        SqlCommand cmdut = new SqlCommand(utSql, conn);
                        SqlDataAdapter Drut = new SqlDataAdapter(cmdut);
                        DataSet Dsut = new DataSet();
                        Drut.Fill(Dsut, "Unit_Master");
                        if (Dsut.Tables[0].Rows.Count > 0)
                        {
                            dr[6] = Dsut.Tables[0].Rows[0]["Symbol"].ToString();
                        }                        
                        List<double> g = new List<double>();
                        g = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));

                        double h = 1;

                        for (int j = 0; j < g.Count; j++)
                        {
                            h = h * g[j];
                        }

                        dr[8] = decimal.Parse(h.ToString()).ToString("N3");
                        dr[9] = DsIt.Tables[0].Rows[0]["Id"].ToString();
                        dr[10] = DsIt.Tables[0].Rows[0]["Revision"].ToString();
                        dr[11] = DsIt.Tables[0].Rows[0]["Material"].ToString();
                        g.Clear();
                        myDataTable.Rows.Add(dr);
                    }
                }

            }
            else
            {
                string StrCId = string.Empty;
                if (drpValue == 2)
                {
                    StrCId = "And tblDG_Item_Master.CId is null";
                }

                StrSql = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_Item_Master.CId As Cat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,UOMBasic,Symbol,tblDG_BOM_Master.Id,tblDG_BOM_Master.Revision,Material", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And WONo='" + woQueryStr + "'And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'" + StrCId + "  Order By PId ASC");
                adapter.SelectCommand = new SqlCommand(StrSql, conn);
                adapter.Fill(DS, "tblDG_BOM_Master");
                for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
                {
                    dr = myDataTable.NewRow();
                    dr[0] = DS.Tables[0].Rows[p][0];
                    dr[1] = DS.Tables[0].Rows[p][1].ToString();
                    dr[2] = DS.Tables[0].Rows[p][2];
                    dr[3] = DS.Tables[0].Rows[p][3];
                    dr[7] = decimal.Parse(DS.Tables[0].Rows[p][4].ToString()).ToString("N3");
                    if (DS.Tables[0].Rows[p]["Cat"] != DBNull.Value)
                    {
                        dr[4] = DS.Tables[0].Rows[p]["ItemCode"].ToString();
                    }
                    else
                    {
                        dr[4] = DS.Tables[0].Rows[p]["PartNo"].ToString();
                    }
                    dr[5] = DS.Tables[0].Rows[p]["ManfDesc"].ToString();
                    dr[6] = DS.Tables[0].Rows[p]["Symbol"].ToString();
                    List<double> g = new List<double>();
                    g = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));
                    double h = 1;
                    for (int j = 0; j < g.Count; j++)
                    {
                        h = h * g[j];
                    }
                    dr[8] = decimal.Parse(h.ToString()).ToString("N3");                    
                    dr[9] = DS.Tables[0].Rows[p]["Id"].ToString();
                    dr[10] = DS.Tables[0].Rows[p]["Revision"].ToString();
                    dr[11]=DS.Tables[0].Rows[p]["Material"].ToString();
                    g.Clear();
                    myDataTable.Rows.Add(dr);

                }

            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            conn.Close();
            GC.Collect();
        }
        myDataTable.DefaultView.Sort = "Item Code ASC";
        myDataTable = myDataTable.DefaultView.ToTable(true);
        return myDataTable;


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            SId = Session["username"].ToString();
            woQueryStr = Request.QueryString["WONo"].ToString();
            ConnString = fun.Connection(); ;
            conn = new SqlConnection(ConnString);
            if (!IsPostBack)
            {
                RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
                RadTreeList1.DataBind();
                RadTreeList1.ExpandAllItems();
                CheckBox1.Checked = true;
                this.DataBind();
                this.DisableCk();

            }

        }
        catch (Exception ex) { }
    }
    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
        if (e.CommandName == RadTreeList.ExpandCollapseCommandName)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            this.DisableCk();
        }
    }
    protected void RadTreeList1_PageIndexChanged(object source, Telerik.Web.UI.TreeListPageChangedEventArgs e)
    {
        RadTreeList1.CurrentPageIndex = e.NewPageIndex;
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();
        this.DisableCk();
    }
    protected void RadTreeList1_PageSizeChanged(object source, Telerik.Web.UI.TreeListPageSizeChangedEventArgs e)
    {
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();
        this.DisableCk();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    protected void RadTreeList1_AutoGeneratedColumnCreated(object sender, TreeListAutoGeneratedColumnCreatedEventArgs e)
    {

        if (e.Column.HeaderText == "ItemId")
        {
            e.Column.Visible = false;
        }

        if (e.Column.HeaderText == "PId")
        {
            e.Column.Visible = false;
        }
        if (e.Column.HeaderText == "CId")
        {
            e.Column.Visible = false;
        }
        if (e.Column.HeaderText == "ECN")
        {
            e.Column.Visible = false;
        }
        if (e.Column.HeaderText == "WONo")
        {
            e.Column.Visible = false;
        }

        if (e.Column.HeaderText == "Id")
        {
            e.Column.Visible = false;
        }

        if (e.Column.HeaderText == "Item Code")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(100);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Description")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(420);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        }

        if (e.Column.HeaderText == "Unit Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(100);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Column.HeaderText == "BOM Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(100);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "UOM")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(60);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Revision")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(80);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Material")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(110);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();
            this.DisableCk();
        }
        else
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.CollapseAllItems();
            this.DisableCk();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_Delete.aspx?ModId=3&SubModId=26");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {

        try
        {
            if (RadTreeList1.SelectedItems.Count > 0)
            {
                string connStr = fun.Connection();
                SqlConnection con = new SqlConnection(connStr);
                int cid = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
                string wono = RadTreeList1.SelectedItems[0]["WONo"].Text;
                int id = Convert.ToInt32(RadTreeList1.SelectedItems[0]["Id"].Text);
                List<int> li = new List<int>();
                li = fun.getBOMDelNode(cid, wono, CompId, SId, id, "tblDG_BOM_Master");
                for (int i = 0; i < li.Count; i++)
                {
                    string del2 = fun.delete("tblDG_BOM_Master", "WONo='" + wono + "' AND Id='" + li[i] + "' AND CompId='" + CompId + "'");
                    SqlCommand cmddel2 = new SqlCommand(del2, con);
                    con.Open();
                    cmddel2.ExecuteNonQuery();
                    con.Close();
                }

                string getBOM = fun.select("WONo", "tblDG_BOM_Master", "WONo='" + wono + "'And CompId=" + CompId + "And FinYearId=" + FinYearId + "");
                SqlCommand checkBOM = new SqlCommand(getBOM, con);
                SqlDataAdapter dacheckBOM = new SqlDataAdapter(checkBOM);
                DataSet dscheckBOM = new DataSet();
                dacheckBOM.Fill(dscheckBOM);
                if (dscheckBOM.Tables[0].Rows.Count == 0)
                {

                    string getparent = fun.select("Id", "tblDG_Gunrail_Pitch_Master", "WONo='" + wono + "'And CompId=" + CompId + "And FinYearId=" + FinYearId + "");
                    SqlCommand checkparent = new SqlCommand(getparent, con);
                    SqlDataAdapter daparent = new SqlDataAdapter(checkparent);
                    DataSet dsparent = new DataSet();
                    daparent.Fill(dsparent);
                    if (dsparent.Tables[0].Rows.Count > 0)
                    {


                        string del3 = fun.delete("tblDG_Gunrail_LongRail", "MId='" + dsparent.Tables[0].Rows[0][0] + "'");
                        SqlCommand cmddel3 = new SqlCommand(del3, con);
                        con.Open();
                        cmddel3.ExecuteNonQuery();
                        con.Close();
                        string del4 = fun.delete("tblDG_Gunrail_CrossRail", "MId='" + dsparent.Tables[0].Rows[0][0] + "'");
                        SqlCommand cmddel4 = new SqlCommand(del4, con);
                        con.Open();
                        cmddel4.ExecuteNonQuery();
                        con.Close();
                        string del5 = fun.delete("tblDG_Gunrail_Pitch_Master", "Id='" + dsparent.Tables[0].Rows[0][0] + "'");
                        SqlCommand cmddel5 = new SqlCommand(del5, con);
                        con.Open();
                        cmddel5.ExecuteNonQuery();
                        con.Close();

                    }

                    else
                    {

                        string Sqlget = fun.select("Id", "tblDG_Gunrail_Pitch_Dispatch_Master", "WONo='" + wono + "'And CompId=" + CompId + "And FinYearId=" + FinYearId + "");
                        SqlCommand cmdWo = new SqlCommand(Sqlget, con);
                        SqlDataAdapter daWo = new SqlDataAdapter(cmdWo);
                        DataSet dsWo = new DataSet();
                        daWo.Fill(dsWo);
                        if (dsWo.Tables[0].Rows.Count > 0)
                        {
                            string del3 = fun.delete("tblDG_Gunrail_LongRail_Dispatch", "MId='" + dsWo.Tables[0].Rows[0][0] + "'");
                            SqlCommand cmddel3 = new SqlCommand(del3, con);
                            con.Open();
                            cmddel3.ExecuteNonQuery();
                            con.Close();
                            string del4 = fun.delete("tblDG_Gunrail_CrossRail_Dispatch", "MId='" + dsWo.Tables[0].Rows[0][0] + "'");
                            SqlCommand cmddel4 = new SqlCommand(del4, con);
                            con.Open();
                            cmddel4.ExecuteNonQuery();
                            con.Close();

                            string del5 = fun.delete("tblDG_Gunrail_Pitch_Dispatch_Master", "Id='" + dsWo.Tables[0].Rows[0][0] + "'");
                            SqlCommand cmddel5 = new SqlCommand(del5, con);
                            con.Open();
                            cmddel5.ExecuteNonQuery();
                            con.Close();
                        }

                    }

                    Response.Redirect("BOM_Design_Delete.aspx?ModId=3&SubModId=26");
                }
                else
                {
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }

            }
            else
            {
                string mystring = string.Empty;
                mystring = "Please select Node to Delete.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }

        catch (Exception ex) { }
    }

    List<int> BomAssmbly = new List<int>();
    public List<int> getBOMDelNode(int node, string wono, int CompId, int Id, string tblName)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        int BOMId = 0;
        try
        {


            DataSet DS = new DataSet();
            con.Open();
            string getparent = fun.select("Id,PId,CId,ItemId,Qty", "" + tblName + "", "CId=" + node + "And WONo='" + wono + "'And CompId=" + CompId + " And ItemId='" + Id + "' ");
            SqlCommand checkparent = new SqlCommand(getparent, con);
            SqlDataAdapter daparent = new SqlDataAdapter(checkparent);
            DataSet dsparent = new DataSet();
            daparent.Fill(dsparent);
            for (int h = 0; h < dsparent.Tables[0].Rows.Count; h++)
            {

                string cmdStr2 = fun.select("Id,PId,CId,ItemId,Qty", "" + tblName + "", "WONo='" + wono + "'And CompId=" + CompId + " AND CId='" + dsparent.Tables[0].Rows[h]["PId"] + "'");
                SqlCommand cmd2 = new SqlCommand(cmdStr2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);
                for (int j = 0; j < DS2.Tables[0].Rows.Count; j++)
                {

                    BOMId = Convert.ToInt32(DS2.Tables[0].Rows[j]["ItemId"]);
                    this.getBOMDelNode(Convert.ToInt32(DS2.Tables[0].Rows[j]["CId"]), wono, CompId, Convert.ToInt32(DS2.Tables[0].Rows[j]["ItemId"]), tblName);
                }
                BomAssmbly.Add(Convert.ToInt32(BOMId));

            }

        }
        catch (Exception x)
        {
        }
        finally
        {
            con.Close();
        }

        return BomAssmbly;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();
        this.DisableCk();

    }
    public void DisableCk()
    {

        try
        {
            List<int> li = new List<int>();
            foreach (TreeListDataItem item in RadTreeList1.Items)
            {
                int ItemId = Convert.ToInt32(item["ItemId"].Text);
                int Id = Convert.ToInt32(item["Id"].Text);
                int CId = Convert.ToInt32(item["CId"].Text);
                string WONo = item["WONo"].Text;
                string PR = fun.select("tblMM_PR_Details.ItemId", "tblMM_PR_Details,tblMM_PR_Master", "  tblMM_PR_Master.Id=tblMM_PR_Details.MId And      tblMM_PR_Master.WONo='" + WONo + "'And tblMM_PR_Master.CompId=" + CompId + "And tblMM_PR_Master.FinYearId=" + FinYearId + "  And tblMM_PR_Details.ItemId='" + ItemId + "' ");
                SqlCommand cmdPR = new SqlCommand(PR, conn);
                SqlDataAdapter DAPR = new SqlDataAdapter(cmdPR);
                DataSet DSPR = new DataSet();
                DAPR.Fill(DSPR);
                string WIS = fun.select("tblInv_WIS_Details.ItemId", "tblInv_WIS_Master,tblInv_WIS_Details", "  tblInv_WIS_Master.Id=tblInv_WIS_Details.MId And      tblInv_WIS_Master.WONo='" + WONo + "'And tblInv_WIS_Master.CompId=" + CompId + "And tblInv_WIS_Master.FinYearId=" + FinYearId + "  And  tblInv_WIS_Details.ItemId='" + ItemId + "' ");
                SqlCommand cmdWIS = new SqlCommand(WIS, conn);
                SqlDataAdapter DAWIS = new SqlDataAdapter(cmdWIS);
                DataSet DSWIS = new DataSet();
                DAWIS.Fill(DSWIS);
                string PLN = fun.select("tblMP_Material_Detail.ItemId", "tblMP_Material_Detail,tblMP_Material_Master", "  tblMP_Material_Master.Id=tblMP_Material_Detail.MId And tblMP_Material_Master.WONo='" + WONo + "'And tblMP_Material_Master.CompId=" + CompId + "And tblMP_Material_Master.FinYearId=" + FinYearId + "  And tblMP_Material_Detail.ItemId='" + ItemId + "'");
                SqlCommand cmdPLN = new SqlCommand(PLN, conn);
                SqlDataAdapter DAPLN = new SqlDataAdapter(cmdPLN);
                DataSet DSPLN = new DataSet();
                DAPLN.Fill(DSPLN);
                if (DSPR.Tables[0].Rows.Count > 0 || DSWIS.Tables[0].Rows.Count > 0 || DSPLN.Tables[0].Rows.Count > 0)
                {

                    item["ck"].Enabled = false;
                    li = this.getBOMDelNode(CId, WONo, CompId, ItemId, "tblDG_BOM_Master");
                }
            }
            foreach (TreeListDataItem item in RadTreeList1.Items)
            {
                int ItemId = Convert.ToInt32(item["ItemId"].Text);
                for (int i = 0; i < li.Count; i++)
                {
                    if (ItemId == li[i])
                    {
                        item["ck"].Enabled = false;

                    }
                }
            }
        }

        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
    }

}
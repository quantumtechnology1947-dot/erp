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
using Telerik.Web.UI;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

public partial class Module_Design_Transactions_BOM_Design_WO_TreeView : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string woQueryStr = "";
    int CompId = 0;
    int FinYearId = 0;
    string SId = "";
    String ConnString = "";
    SqlConnection conn;
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
            myDataTable.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("AttName", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("uploadImg", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("uploadSpec", typeof(string)));
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
                    icSql = fun.select("ItemId,ItemCode,UOMBasic,FileName,AttName,tblDG_Item_Master.PartNo,ManfDesc,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.Revision,tblDG_BOM_Master.Material", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(li[i]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + woQueryStr + "'");
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

                        if (DsIt.Tables[0].Rows[0]["FileName"].ToString() != "" && DsIt.Tables[0].Rows[0]["FileName"] != DBNull.Value)
                        {

                            dr[9] = "View";
                            dr[11] = "";
                        }

                        else
                        {
                            dr[9] = "";
                            dr[11] = "Upload";
                        }

                        if (DsIt.Tables[0].Rows[0]["AttName"].ToString() != "" && DsIt.Tables[0].Rows[0]["AttName"] != DBNull.Value)
                        {
                            dr[10] = "View";
                            dr[12] = "";
                        }

                        else
                        {
                            dr[10] = "";
                            dr[12] = "Upload";
                        }
                        dr[13] = DsIt.Tables[0].Rows[0]["Revision"];
                        dr[14] = DsIt.Tables[0].Rows[0]["Material"];

                        List<double> g = new List<double>();
                        g = fun.BOMTreeQty(woQueryStr, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));

                        double h = 1;

                        for (int j = 0; j < g.Count; j++)
                        {
                            h = h * g[j];
                        }

                        dr[8] = decimal.Parse(h.ToString()).ToString("N3");
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

                StrSql = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_Item_Master.CId As Cat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,UOMBasic,FileName,AttName,Symbol,tblDG_BOM_Master.Revision,tblDG_BOM_Master.Material", "tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And WONo='" + woQueryStr + "'And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'" + StrCId + "  Order By PId ASC");
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
                    if (DS.Tables[0].Rows[p]["FileName"].ToString() != "" && DS.Tables[0].Rows[p]["FileName"] != DBNull.Value)
                    {
                        dr[9] = "View";
                        dr[11] = "";
                    }
                    else
                    {
                        dr[9] = "";
                        dr[11] = "Upload";
                    }

                    if (DS.Tables[0].Rows[p]["AttName"].ToString() != "" && DS.Tables[0].Rows[p]["AttName"] != DBNull.Value)
                    {
                        dr[10] = "View";
                        dr[12] = "";
                    }
                    else
                    {
                        dr[10] = "";
                        dr[12] = "Upload";
                    }
                    dr[13] = DS.Tables[0].Rows[p]["Revision"];
                    dr[14] = DS.Tables[0].Rows[p]["Material"];
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
        ConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        conn = new SqlConnection(ConnString);
        woQueryStr = Request.QueryString["WONo"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        SId = Session["username"].ToString();
        if (Request.QueryString["Msg"] != "")
        {
            lblmsg.Text = Request.QueryString["Msg"];
        }
        if (!IsPostBack)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();
            CheckBox1.Checked = true;
            this.DataBind();
        }

    }


    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {



        if (e.CommandName == RadTreeList.ExpandCollapseCommandName)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();

        }

        if (e.CommandName == "Sel")
        {
            TreeListDataItem dataitem = e.Item as TreeListDataItem;
            string wono = ((Label)dataitem.FindControl("lblWONo")).Text;
            int pid = Convert.ToInt32(((Label)dataitem.FindControl("lblPId")).Text);
            int cid = Convert.ToInt32(((Label)dataitem.FindControl("lblCId")).Text);
            int itemid = Convert.ToInt32(((Label)dataitem.FindControl("lblItemId")).Text);

            string icSql = fun.select("tblDG_Item_Master.CId", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_Item_Master.Id='" + itemid + "' And tblDG_Item_Master.CId is Null  And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'");
            SqlCommand cmditemCode = new SqlCommand(icSql, conn);
            SqlDataAdapter Dr = new SqlDataAdapter(cmditemCode);
            DataSet DsIt = new DataSet();
            Dr.Fill(DsIt, "tblDG_Item_Master");
            if (DsIt.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("BOM_WoItems.aspx?WONo=" + wono + "&ItemId=" + itemid + "&PId=" + pid + "&CId=" + cid + "&ModId=3&SubModId=26");
            }

            else
            {
                string mystring = string.Empty;
                mystring = "This is Standard Item.It can not be modify.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }

        if (e.CommandName == "downloadImg")
        {
            TreeListDataItem dataitem = e.Item as TreeListDataItem;
            int itemid = Convert.ToInt32(((Label)dataitem.FindControl("lblItemId")).Text);

            Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");

        }

        if (e.CommandName == "uploadImg")
        {
            TreeListDataItem dataitem = e.Item as TreeListDataItem;
            string wono = ((Label)dataitem.FindControl("lblWONo")).Text;
            int itemid = Convert.ToInt32(((Label)dataitem.FindControl("lblItemId")).Text);
            Response.Redirect("~/Module/Design/Transactions/BOM_UploadDrw.aspx?WONo=" + wono + "&Id=" + itemid + "&img=0");
        }


        if (e.CommandName == "downloadSpec")
        {
            TreeListDataItem dataitem = e.Item as TreeListDataItem;
            int itemid = Convert.ToInt32(((Label)dataitem.FindControl("lblItemId")).Text);
            Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
        }

        if (e.CommandName == "uploadSpec")
        {

            TreeListDataItem dataitem = e.Item as TreeListDataItem;
            string wono = ((Label)dataitem.FindControl("lblWONo")).Text;
            int itemid = Convert.ToInt32(((Label)dataitem.FindControl("lblItemId")).Text);
            Response.Redirect("~/Module/Design/Transactions/BOM_UploadDrw.aspx?WONo=" + wono + "&Id=" + itemid + "&img=1");
        }

    }


    protected void RadTreeList1_PageIndexChanged(object source, Telerik.Web.UI.TreeListPageChangedEventArgs e)
    {

        RadTreeList1.CurrentPageIndex = e.NewPageIndex;
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();

    }
    protected void RadTreeList1_PageSizeChanged(object source, Telerik.Web.UI.TreeListPageSizeChangedEventArgs e)
    {

        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();

    }

    protected void btnAssembly_Click(object sender, EventArgs e)
    {
        string woQueryStr2 = Request.QueryString["WONo"].ToString();
        string pgurl = "BOM_Design_WO_TreeView.aspx";
        Response.Redirect("~/Module/Design/Transactions/BOM_Design_Assembly_New.aspx?WONo=" + woQueryStr2 + "&PgUrl=" + pgurl + "&ModId=3&SubModId=26");

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


        if (e.Column.HeaderText == "FileName")
        {
            e.Column.Visible = false;
        }

        if (e.Column.HeaderText == "AttName")
        {
            e.Column.Visible = false;
        }


        if (e.Column.HeaderText == "uploadImg")
        {
            e.Column.Visible = false;
        }


        if (e.Column.HeaderText == "uploadSpec")
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

        if (e.Column.HeaderText == "Item Code")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(80);
            //e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
          //  e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Description")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(250);
          //  e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Unit Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(50);
          //  e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
           // e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Column.HeaderText == "BOM Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(50);
           // e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
          //  e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "UOM")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(40);
           // e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
           // e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Revision")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(40);
            // e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            // e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }


        if (e.Column.HeaderText == "Material")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(60);
            // e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            // e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }



    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();

        }
        else
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.CollapseAllItems();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_WO_Grid.aspx?ModId=3&SubModId=26");
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_Root_Assembly_Copy_WO.aspx?WONoDest=" + woQueryStr + "&ModId=3&SubModId=26");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();
    }

}


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
using Telerik.Web.UI;
using System.Security.Cryptography;
public partial class Module_Design_Transactions_BOM_Design_Print_Tree : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    public int pid = 0;
    public int cid = 0;
    public string wonosrc = "";
    public string wonodest = "";
    int CompId = 0;
    string sId = "";
    int FinYearId = 0;
    string StartDate = "";
    string UpToDate = "";
    string connStr = string.Empty;
    SqlConnection conn;
    string getRandomKey = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            connStr = fun.Connection();
            conn = new SqlConnection(connStr);
            lblasslymsg.Text = "";
           
            if (!string.IsNullOrEmpty(Request.QueryString["WONo"]))
            {
                wonosrc = Request.QueryString["WONo"].ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["SD"]))
            {
                StartDate = Request.QueryString["SD"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["TD"]))
            {
                UpToDate = Request.QueryString["TD"].ToString();
            }
            
            if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                lblasslymsg.Text =Request.QueryString["msg"];
            }

            if (!Page.IsPostBack)
            {   getRandomKey =fun.GetRandomAlphaNumeric();
             //   RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
                RadTreeList1.DataBind();
                RadTreeList1.ExpandAllItems();
               // CheckBox1.Checked = true;
                this.DataBind();
                
            }

        }
        catch (Exception ex)
        {

        }
    }
    public DataTable GetDataTable(int drpValue)
    {

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable myDataTable = new DataTable();
        DataSet DS = new DataSet();
        Label2.Text = wonosrc;
        try
        {
            conn.Open();
            myDataTable.Columns.Add(new System.Data.DataColumn("ItemId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("PId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("CId", typeof(int)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Item Code", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("UnitQty", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("BOMQty", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Download", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("DownloadSpec", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("EntryDate", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Entered by", typeof(string)));
            myDataTable.Columns.Add(new System.Data.DataColumn("Revision", typeof(string)));

            DataRow dr;
    
            if (drpValue == 1)
            {

                string icSql = string.Empty;
                string StrSql = fun.select("PId,tblDG_BOM_Master.CId", "tblDG_BOM_Master,tblDG_Item_Master", "WONo='" + wonosrc + "'And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'And tblDG_Item_Master.CId Is not null And tblDG_BOM_Master.SysDate between '" + fun.FromDate(StartDate) + "' and '" + fun.FromDate(UpToDate) + "' Order By PId ASC");
                adapter.SelectCommand = new SqlCommand(StrSql, conn);
                adapter.Fill(DS, "tblDG_BOM_Master");
                List<string> li = new List<string>();
                for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
                {
                    li = fun.BOMTree_Search(wonosrc, Convert.ToInt32(DS.Tables[0].Rows[p]["PId"]), Convert.ToInt32(DS.Tables[0].Rows[p]["CId"]));
                }
                for (int i = 0; i < li.Count; i++)
                {

                    dr = myDataTable.NewRow();
                    icSql = fun.select("ItemId,WONo,PId,tblDG_BOM_Master.CId,Qty,tblDG_BOM_Master.SysDate,Title+'.'+EmployeeName As EmpLoyeeName,tblDG_Item_Master.CId As ItemCat,ItemCode,tblDG_Item_Master.PartNo,ManfDesc,FileName,AttName,Symbol,tblDG_Item_Master.Revision", "tblDG_Item_Master,tblDG_BOM_Master,tblHR_OfficeStaff,Unit_Master", "tblDG_BOM_Master.ItemId='" + Convert.ToInt32(li[i]) + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId And tblHR_OfficeStaff.EmpId=tblDG_BOM_Master.SessionId And Unit_Master.Id=tblDG_Item_Master.UOMBasic And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And WONo='" + wonosrc + "'");
                    SqlCommand cmditemCode = new SqlCommand(icSql, conn);
                    SqlDataAdapter Dr = new SqlDataAdapter(cmditemCode);
                    DataSet DsIt = new DataSet();
                    Dr.Fill(DsIt, "tblDG_Item_Master");
                    if (DsIt.Tables[0].Rows.Count > 0)
                    {

                        dr[0] = DsIt.Tables[0].Rows[0][0];
                        dr[1] = DsIt.Tables[0].Rows[0][1].ToString();
                        dr[2] = DsIt.Tables[0].Rows[0][2];
                        dr[3] = DsIt.Tables[0].Rows[0][3];
                        dr[7] = decimal.Parse(DsIt.Tables[0].Rows[0][4].ToString()).ToString("N3");
                        if (DsIt.Tables[0].Rows[0]["ItemCat"] != DBNull.Value)
                        {
                            dr[4] = DsIt.Tables[0].Rows[0]["ItemCode"].ToString();
                        }

                        else
                        {
                            dr[4] = DsIt.Tables[0].Rows[0]["PartNo"].ToString();
                        }
                        dr[5] = DsIt.Tables[0].Rows[0]["ManfDesc"].ToString();
                        dr[6] = DsIt.Tables[0].Rows[0]["Symbol"].ToString();
                        if (!string.IsNullOrEmpty(DsIt.Tables[0].Rows[0]["FileName"].ToString()))
                        {
                            dr[9] = "View";
                        }

                        if (!string.IsNullOrEmpty(DsIt.Tables[0].Rows[0]["AttName"].ToString()))
                        {
                            dr[10] = "View";
                        }

                        List<double> g = new List<double>();
                        g = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));

                        double h = 1;

                        for (int j = 0; j < g.Count; j++)
                        {
                            h = h * g[j];
                        }

                        dr[8] = decimal.Parse(h.ToString()).ToString("N3");
                        dr[11] = fun.FromDateDMY(DsIt.Tables[0].Rows[0]["SysDate"].ToString());
                        dr[12] = DsIt.Tables[0].Rows[0]["EmployeeName"].ToString();
                        dr[13] = DsIt.Tables[0].Rows[0]["Revision"].ToString();
                        g.Clear();
                        myDataTable.Rows.Add(dr);
                        myDataTable.AcceptChanges();
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
            adapter = new SqlDataAdapter("Get_BOM_DateWise", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@CompId"].Value = CompId;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@StartDate"].Value = fun.FromDate(StartDate);
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@UpToDate", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@UpToDate"].Value = fun.FromDate(UpToDate);
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@ItemCId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@ItemCId"].Value = StrCId;
            adapter.Fill(DS, "tblDG_BOM_Master");                        
          
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {

                dr = myDataTable.NewRow();
                dr[0] = DS.Tables[0].Rows[p][0];
                dr[1] = DS.Tables[0].Rows[p][1].ToString();
                dr[2] = DS.Tables[0].Rows[p][2];
                dr[3] = DS.Tables[0].Rows[p][3];
                dr[7] = decimal.Parse(DS.Tables[0].Rows[p][4].ToString()).ToString("N3");                
                if (DS.Tables[0].Rows[p]["ItemCat"] != DBNull.Value)
                {
                    dr[4] = DS.Tables[0].Rows[p]["ItemCode"].ToString();
                }

                else
                {
                    dr[4] = DS.Tables[0].Rows[p]["PartNo"].ToString();
                }
                dr[5] = DS.Tables[0].Rows[p]["ManfDesc"].ToString(); 
                dr[6] = DS.Tables[0].Rows[p]["Symbol"].ToString();                    
                if (!string.IsNullOrEmpty(DS.Tables[0].Rows[p]["FileName"].ToString()))
                {
                    dr[9] = "View";
                }

                if (!string.IsNullOrEmpty(DS.Tables[0].Rows[p]["AttName"].ToString()))
                {
                    dr[10] = "View";
                }
            
                List<double> g = new List<double>();
                g = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));

                double h = 1;

                for (int j = 0; j < g.Count; j++)
                {
                    h = h * g[j];
                }

                dr[8] = decimal.Parse(h.ToString()).ToString("N3");
                dr[11] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString()); 
                dr[12] = DS.Tables[0].Rows[p]["EmployeeName"].ToString();
                dr[13] = DS.Tables[0].Rows[p]["Revision"].ToString();
                g.Clear();
                myDataTable.Rows.Add(dr);
                myDataTable.AcceptChanges();
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
        myDataTable.DefaultView.Sort = "Item Code ASC";
        myDataTable = myDataTable.DefaultView.ToTable(true);
        return myDataTable;
    }    

    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
        if (e.CommandName == RadTreeList.ExpandCollapseCommandName)
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
        }

        if (e.Item is TreeListDataItem)
        {
            TreeListDataItem dataItem = e.Item as TreeListDataItem;
            if (e.CommandName == "Download")
            {                          
                    int id = Convert.ToInt32(((Label)dataItem.FindControl("lblItemId")).Text);                    
                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=fileName&qct=ContentType");             
                    
            }


            if (e.CommandName == "DownloadSpec")
            {
                int id = Convert.ToInt32(((Label)dataItem.FindControl("lblItemId")).Text);
                Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");

            }  
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

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (RadTreeList1.SelectedItems.Count > 0)
        {
            string wono = RadTreeList1.SelectedItems[0]["WONo"].Text;
            int pid = Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
            int cid = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
            Response.Redirect("~/Module/Design/Transactions/BOM_Design_Print_Cry.aspx?WONo=" + wono + "&PId=" + pid + "&CId=" + cid + "&SD=" + StartDate + "&TD=" + UpToDate + "&DrpVal=" + Convert.ToInt32(DropDownList1.SelectedValue) + "&Key=" + getRandomKey + "&ModId=3&SubModId=26");
        }       
        
    }

    protected void RadTreeList1_AutoGeneratedColumnCreated(object sender, TreeListAutoGeneratedColumnCreatedEventArgs e)
    {

        if (e.Column.HeaderText == "ItemId")
        {
            e.Column.Visible = false;
        }


        if (e.Column.HeaderText == "EntryDate")
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

        if (e.Column.HeaderText == "Item Code")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(90);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Description")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(300);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            
        }

        if (e.Column.HeaderText == "UnitQty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Column.HeaderText == "BOMQty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "UOM")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(60);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        if (e.Column.HeaderText == "Entry Date")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(100);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "Entered by")
        {
           // e.Column.HeaderStyle.Width = Unit.Pixel(40);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Justify;
        }       
        
        if (e.Column.HeaderText == "Download")
        {
            e.Column.Visible = false;
            e.Column.HeaderStyle.Width = Unit.Pixel(80);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        if (e.Column.HeaderText == "DownloadSpec")
        {
            e.Column.Visible = false;
            e.Column.HeaderStyle.Width = Unit.Pixel(80);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        if (e.Column.HeaderText == "Revision")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
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
        }
        else
        {
            RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
            RadTreeList1.DataBind();
            RadTreeList1.CollapseAllItems();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_PrintWo.aspx?ModId=3&SubModId=26");
    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Design/Transactions/BOM_Design_Print_Cry.aspx?wono=" + wonosrc + "&PId=&CId=&SD=" + StartDate + "&TD=" + UpToDate + "&DrpVal=" + Convert.ToInt32(DropDownList1.SelectedValue) + "&Key=" + getRandomKey + "&ModId=3&SubModId=26");

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadTreeList1.DataSource = GetDataTable(Convert.ToInt32(DropDownList1.SelectedValue));
        RadTreeList1.DataBind();
    } 
}

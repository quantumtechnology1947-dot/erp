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
public partial class Module_Inventory_Transactions_WIS_ActualRun_Assembly : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    public int pid = 0;
    public int cid = 0;
    public string wonosrc = "";
    int CompId = 0;
    string sId = "";
    int FinYearId = 0;
    string CDate = "";
    string CTime = "";
    String ConnString =string.Empty;
    SqlConnection conn;      
        
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            ConnString = fun.Connection();
            conn = new SqlConnection(ConnString);
            CompId = Convert.ToInt32(Session["compid"]);
            wonosrc = Request.QueryString["WONo"].ToString();
            lblmsg.Text = "";
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();

            if (Request.QueryString["msg"] != "")
            {
                lblmsg.Text = Request.QueryString["msg"];
            }

            if (!Page.IsPostBack)
            {
                RadTreeList1.DataSource = GetDataTable();
                RadTreeList1.DataBind();
                RadTreeList1.ExpandAllItems();
                CheckBox1.Checked = true;
               
            }
        }
        catch (Exception ex)
        {

        } 
    }
    public DataTable GetDataTable()
    {       
      
         DataTable myDataTable = new DataTable();
        try
        {
            conn.Open();
           
            Label2.Text = wonosrc;  
            SqlDataAdapter adapter = new SqlDataAdapter("GetSchTime_BOM_Details_Assembly", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@CompId"].Value = CompId;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
            DataSet DS = new DataSet();
            adapter.Fill(DS, "tblDG_BOM_Master");

            myDataTable.Columns.Add(new System.Data.DataColumn("ItemId", typeof(int)));//0
            myDataTable.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));//1
            myDataTable.Columns.Add(new System.Data.DataColumn("PId", typeof(int)));//2
            myDataTable.Columns.Add(new System.Data.DataColumn("CId", typeof(int)));//3
            myDataTable.Columns.Add(new System.Data.DataColumn("Item Code", typeof(string)));//4
            myDataTable.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));//5
            myDataTable.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));//6
            myDataTable.Columns.Add(new System.Data.DataColumn("Unit Qty", typeof(string)));//7
            myDataTable.Columns.Add(new System.Data.DataColumn("BOM Qty", typeof(string)));//8
            myDataTable.Columns.Add(new System.Data.DataColumn("Weld", typeof(string)));//9
            myDataTable.Columns.Add(new System.Data.DataColumn("Stock Qty", typeof(string)));//10
            myDataTable.Columns.Add(new System.Data.DataColumn("Tot. WIS Qty", typeof(string)));   //11 
            myDataTable.Columns.Add(new System.Data.DataColumn("Dry Run Qty", typeof(string)));//12
            myDataTable.Columns.Add(new System.Data.DataColumn("Balance BOM Qty", typeof(string)));//13
            myDataTable.Columns.Add(new System.Data.DataColumn("After Stock Qty", typeof(string)));//14
            
            DataRow dr;

            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = myDataTable.NewRow();
                dr[0] = DS.Tables[0].Rows[p][0];
                dr[1] = DS.Tables[0].Rows[p][1].ToString();
                dr[2] = DS.Tables[0].Rows[p][2];
                dr[3] = DS.Tables[0].Rows[p][3];
                dr[7] = DS.Tables[0].Rows[p][4];
                SqlDataAdapter Dr = new SqlDataAdapter("GetSchTime_Item_Details", conn);
                Dr.SelectCommand.CommandType = CommandType.StoredProcedure;
                Dr.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
                Dr.SelectCommand.Parameters["@CompId"].Value = CompId;
                Dr.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                Dr.SelectCommand.Parameters["@Id"].Value = DS.Tables[0].Rows[p]["ItemId"].ToString();
                DataSet DsIt = new DataSet();
                Dr.Fill(DsIt, "tblDG_Item_Master");
                dr[4] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[p][0].ToString()));
                dr[5] = DsIt.Tables[0].Rows[0]["ManfDesc"].ToString();

                string utSql = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(DsIt.Tables[0].Rows[0]["UOMBasic"]) + "'");
                SqlCommand cmdut = new SqlCommand(utSql, conn);
                SqlDataAdapter Drut = new SqlDataAdapter(cmdut);
                DataSet Dsut = new DataSet();
                Drut.Fill(Dsut, "Unit_Master");

                dr[6] = Dsut.Tables[0].Rows[0]["Symbol"].ToString();

                //Cal. BOM Qty
                List<double> g = new List<double>();
                g = fun.BOMTreeQty(wonosrc, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));

                double h = 1;

                for (int j = 0; j < g.Count; j++)
                {
                    h = h * g[j];
                }

                dr[8] = Convert.ToDouble(decimal.Parse(h.ToString()).ToString("N3"));

                //dr[9] = DS.Tables[0].Rows[p]["Weldments"].ToString();
                dr[10] = Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
                //Cal. Total WIS Issued Qty
                SqlDataAdapter TWISQtyDr = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
                TWISQtyDr.SelectCommand.CommandType = CommandType.StoredProcedure;
                TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
                TWISQtyDr.SelectCommand.Parameters["@CompId"].Value = CompId;
                TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
                TWISQtyDr.SelectCommand.Parameters["@WONo"].Value = wonosrc;
                TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
                TWISQtyDr.SelectCommand.Parameters["@ItemId"].Value = DS.Tables[0].Rows[p]["ItemId"].ToString();
                TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
                TWISQtyDr.SelectCommand.Parameters["@PId"].Value = DS.Tables[0].Rows[p]["PId"].ToString();
                TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
                TWISQtyDr.SelectCommand.Parameters["@CId"].Value = DS.Tables[0].Rows[p]["CId"].ToString();
                DataSet TWISQtyDs = new DataSet();
                TWISQtyDr.Fill(TWISQtyDs);

                double TotWISQty = 0;
                double BalBomQty = 0;

                if (TWISQtyDs.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && TWISQtyDs.Tables[0].Rows.Count > 0)
                {
                    TotWISQty = Convert.ToDouble(decimal.Parse(TWISQtyDs.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
                    dr[11] = TotWISQty;
                   
                }
                else
                {
                    dr[11] = 0;
                }

                //Cal. Bal BOM Qty to Issue

                if (h >= 0)
                {
                    BalBomQty = Convert.ToDouble(decimal.Parse((h - TotWISQty).ToString()).ToString("N3"));
                }

                //Cal. Issue and Stock Qty

                double CalStockQty = 0;
                double CalIssueQty = 0;

                if (Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0 && BalBomQty >= 0)
                {
                    if (Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= BalBomQty)
                    {
                        CalStockQty = Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - BalBomQty;
                        CalIssueQty = BalBomQty;
                    }
                    else if (BalBomQty >= Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
                    {
                        CalStockQty = 0;
                        CalIssueQty = Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
                    }
                }

                if (Convert.ToDouble(decimal.Parse((h - (TotWISQty + CalIssueQty)).ToString()).ToString("N3")) >= 0)
                {
                    dr[13] = Convert.ToDouble(decimal.Parse((h - (TotWISQty + CalIssueQty)).ToString()).ToString("N3"));
                }
                else
                {
                    dr[13] = 0;
                }
                
                dr[12] = CalIssueQty;
                dr[14] = CalStockQty;

                g.Clear();
                myDataTable.Rows.Add(dr);
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }

        return myDataTable;
    }

    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
        if (e.CommandName == RadTreeList.ExpandCollapseCommandName)
        {
            RadTreeList1.DataSource = GetDataTable();
            RadTreeList1.DataBind();
        }
    }
    protected void RadTreeList1_PageIndexChanged(object source, Telerik.Web.UI.TreeListPageChangedEventArgs e)
    {
        RadTreeList1.CurrentPageIndex = e.NewPageIndex;
        RadTreeList1.DataSource = GetDataTable();
        RadTreeList1.DataBind();
    }
    protected void RadTreeList1_PageSizeChanged(object source, Telerik.Web.UI.TreeListPageSizeChangedEventArgs e)
    {
        RadTreeList1.DataSource = GetDataTable();
        RadTreeList1.DataBind();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (RadTreeList1.SelectedItems.Count > 0)
        {
            string wono = RadTreeList1.SelectedItems[0]["WONo"].Text;
            int pid = Convert.ToInt32(RadTreeList1.SelectedItems[0]["PId"].Text);
            int cid = Convert.ToInt32(RadTreeList1.SelectedItems[0]["CId"].Text);
            
            //Response.Redirect("~/Module/Inventory/Transactions/BOM_Design_Print_Cry.aspx?WONo=" + wono + "&PId=" + pid + "&CId=" + cid + "&ModId=9&SubModId=53");
        }

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

        if (e.Column.HeaderText == "Item Code")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(100);
        }

        if (e.Column.HeaderText == "Description")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(360);
        }

        if (e.Column.HeaderText == "Unit Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(60);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Column.HeaderText == "BOM Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "UOM")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(40);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        if (e.Column.HeaderText == "Weld")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(40);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.Visible = false;
        }

        //if (e.Column.HeaderText == "LH")
        //{
        //    e.Column.HeaderStyle.Width = Unit.Pixel(40);
        //    e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        //    e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        //}

        //if (e.Column.HeaderText == "RH")
        //{
        //    e.Column.HeaderStyle.Width = Unit.Pixel(40);
        //    e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        //    e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        //}

        if (e.Column.HeaderText == "Tot. WIS Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "Stock Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(60);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "Dry Run Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "After Stock Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(80);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

        if (e.Column.HeaderText == "Balance BOM Qty")
        {
            e.Column.HeaderStyle.Width = Unit.Pixel(70);
            e.Column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            RadTreeList1.DataSource = GetDataTable();
            RadTreeList1.DataBind();
            RadTreeList1.ExpandAllItems();
        }
        else
        {
            RadTreeList1.DataSource = GetDataTable();
            RadTreeList1.DataBind();
            RadTreeList1.CollapseAllItems();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/WIS_Dry_Actual_Run.aspx?ModId=9&SubModId=53");
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
       // Response.Redirect("~/Module/Design/Transactions/BOM_Design_Print_Cry.aspx?wono=" + wonosrc + "&PId=&CId=&ModId=9&SubModId=53");
    }
    public void WIS_RootAssly()
    { 
        try
        {
            conn.Open();
            
            //New WIS No.
            string WISno = "";
            int Mid = 0;
            SqlDataAdapter dawis = new SqlDataAdapter("GetSchTime_WISNo", conn);
            dawis.SelectCommand.CommandType = CommandType.StoredProcedure;
            dawis.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            dawis.SelectCommand.Parameters["@CompId"].Value = CompId;
            dawis.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
            dawis.SelectCommand.Parameters["@FinYearId"].Value = FinYearId;
            DataSet DSwis = new DataSet();
            dawis.Fill(DSwis);
            if (DSwis.Tables[0].Rows.Count > 0)
            {
                int WISstr = Convert.ToInt32(DSwis.Tables[0].Rows[0]["WISNo"].ToString()) + 1;
                WISno = WISstr.ToString("D4");
            }
            else
            {
                WISno = "0001";
            } 
            SqlDataAdapter adapter = new SqlDataAdapter("GetSchTime_BOM_Details_Assembly", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@CompId"].Value = CompId;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;
            DataSet DS = new DataSet();
            adapter.Fill(DS, "tblDG_BOM_Master");
            int m = 1;
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
               
                DataSet DsIt = new DataSet();
                SqlDataAdapter Dr = new SqlDataAdapter("GetSchTime_Item_Details", conn);
                Dr.SelectCommand.CommandType = CommandType.StoredProcedure;
                Dr.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
                Dr.SelectCommand.Parameters["@CompId"].Value = CompId;
                Dr.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
                Dr.SelectCommand.Parameters["@Id"].Value = DS.Tables[0].Rows[p]["ItemId"].ToString();
                Dr.Fill(DsIt, "tblDG_Item_Master");
                if (DsIt.Tables[0].Rows.Count > 0)
                {
                    //Cal. BOM Qty
                    List<double> g = new List<double>();
                    g = fun.BOMTreeQty(wonosrc, Convert.ToInt32(DS.Tables[0].Rows[p]["PId"]), Convert.ToInt32(DS.Tables[0].Rows[p]["CId"]));

                    double h = 1;

                    for (int j = 0; j < g.Count; j++)
                    {
                        h = h * g[j];
                    }

                    //Cal. Total WIS Issued Qty
                    SqlDataAdapter TWISQtyDr = new SqlDataAdapter("GetSchTime_TWIS_Qty", conn);
                    TWISQtyDr.SelectCommand.CommandType = CommandType.StoredProcedure;
                    TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
                    TWISQtyDr.SelectCommand.Parameters["@CompId"].Value = CompId;
                    TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
                    TWISQtyDr.SelectCommand.Parameters["@WONo"].Value = wonosrc;
                    TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@ItemId", SqlDbType.VarChar));
                    TWISQtyDr.SelectCommand.Parameters["@ItemId"].Value = DS.Tables[0].Rows[p]["ItemId"].ToString();
                    TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@PId", SqlDbType.VarChar));
                    TWISQtyDr.SelectCommand.Parameters["@PId"].Value = DS.Tables[0].Rows[p]["PId"].ToString();
                    TWISQtyDr.SelectCommand.Parameters.Add(new SqlParameter("@CId", SqlDbType.VarChar));
                    TWISQtyDr.SelectCommand.Parameters["@CId"].Value = DS.Tables[0].Rows[p]["CId"].ToString();
                    DataSet TWISQtyDs = new DataSet();
                    TWISQtyDr.Fill(TWISQtyDs);

                    double TotWISQty = 0;
                    double BalBomQty = 0;

                    if (TWISQtyDs.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value && TWISQtyDs.Tables[0].Rows.Count > 0)
                    {
                        TotWISQty = Convert.ToDouble(decimal.Parse(TWISQtyDs.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
                    }

                    //Cal. Bal BOM Qty to Issue

                    if (h >= 0)
                    {
                        BalBomQty = Convert.ToDouble(decimal.Parse((h - TotWISQty).ToString()).ToString("N3"));
                    }

                    //Cal. Issue and Stock Qty

                    double CalStockQty = 0;
                    double CalIssueQty = 0;

                    if (Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= 0 && BalBomQty>= 0)
                    {
                        if (Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) >= BalBomQty)
                        {
                            CalStockQty = Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) - BalBomQty;
                            CalIssueQty = BalBomQty;
                        }
                        else if (BalBomQty >= Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")))
                        {
                            CalStockQty = 0;
                            CalIssueQty = Convert.ToDouble(decimal.Parse(DsIt.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
                        }
                    }

                    //WIS Details record
                    if (CalIssueQty > 0)
                    {                        
                        
                        //WIS Master record
                        if (m == 1)
                        {
                            string WISSql = fun.insert("tblInv_WIS_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WISNo,WONo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + WISno + "','" + wonosrc + "'");
                            SqlCommand WIScmd = new SqlCommand(WISSql, conn);
                            WIScmd.ExecuteNonQuery();
                            m = 0;
                            string StrMid = fun.select1("Id", "tblInv_WIS_Master Order By Id Desc");
                            SqlCommand cmdStrMid = new SqlCommand(StrMid, conn);
                            SqlDataAdapter DrStrMid = new SqlDataAdapter(cmdStrMid);
                            DataSet DsStrMid = new DataSet();
                            DrStrMid.Fill(DsStrMid, "tblDG_Item_Master");
                            if (DsStrMid.Tables[0].Rows.Count>0)
                            {
                                Mid = Convert.ToInt32(DsStrMid.Tables[0].Rows[0][0]);
                            }
                        }                       

                        string WISDetailSql = fun.insert("tblInv_WIS_Details", "WISNo,MId,PId,CId,ItemId,IssuedQty", "'" + WISno + "','"+Mid+"','" + DS.Tables[0].Rows[p]["PId"].ToString() + "','" + DS.Tables[0].Rows[p]["CId"].ToString() + "','" + DS.Tables[0].Rows[p]["ItemId"].ToString() + "','" + CalIssueQty.ToString() + "'");

                        SqlCommand WISDetailcmd = new SqlCommand(WISDetailSql, conn);
                        WISDetailcmd.ExecuteNonQuery();
                       
                        //Stock Qty record
                        string StkQtySql = fun.update("tblDG_Item_Master", "StockQty='" + CalStockQty.ToString() + "'", "CompId='" + CompId + "' AND Id='" + DS.Tables[0].Rows[p]["ItemId"].ToString() + "'");

                        SqlCommand StkQtycmd = new SqlCommand(StkQtySql, conn);
                        StkQtycmd.ExecuteNonQuery();

                        
                    }
                    g.Clear(); // Clear recursive function
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
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {           
            
            //WIS of root Assly.
            this.WIS_RootAssly();
            //Reset Work Order UpdateWO
            string woreset = fun.update("SD_Cust_WorkOrder_Master", "DryActualRun='1'", "WONo='" + wonosrc + "' AND CompId='" + CompId + "'");
            SqlCommand cmdworeset = new SqlCommand(woreset, conn);
            conn.Open();
            cmdworeset.ExecuteNonQuery();
            conn.Close();
            System.Threading.Thread.Sleep(1000);
            Response.Redirect("WIS_ActualRun_Assembly.aspx?WONo="+wonosrc+"&ModId=9&SubModId=53&msg=WIS process is completed.");
        }
       catch (Exception et)
        {

        }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Material.aspx?WONo=" + wonosrc + "&ModId=9&SubModId=53");
    }
}

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

public partial class Module_MaterialManagement_Transactions_PR_New_Detail : System.Web.UI.Page
{
    string wono = "";
    int CompId = 0;
    string SId = "";
    int fyid = 0;
    string WomfDate = "";
    string SupplierName = string.Empty;
    clsFunctions fun = new clsFunctions();   
    string connStr = "";
    SqlConnection con;
    
    protected void Page_Load(object sender, EventArgs e)
    {
     try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            wono = Request.QueryString["WONo"].ToString();
            fyid = Convert.ToInt32(Session["finyear"]);
            lblWono.Text = wono;
            WomfDate = this.WOmfgdate(wono, CompId, fyid);            
            if (!Page.IsPostBack)
            {
                //fun.MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null"); 
                this.MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null"); 
                this.FillFIN();
            }


            foreach (GridDataItem gv1 in RadGrid1.Items)
            {
                GridView RadGrid5 = (GridView)gv1.FindControl("GridView5");
                foreach (GridViewRow gv in RadGrid5.Rows)
                {
                    ((TextBox)gv.FindControl("txtFinDeliDate")).Attributes.Add("readonly", "readonly");
                }
            }
        }
      catch (Exception ex) { }
    }
    public void MP_Tree1(string wono, int CompId, RadGrid GridView2, int finid, string param)
    {


        try
        {
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("ManfDesc", typeof(string));
            dt.Columns.Add("UOMBasic", typeof(string));
            dt.Columns.Add("UnitQty", typeof(string));
            dt.Columns.Add("BOMQty", typeof(string));
            dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AttName", typeof(string)));
            dt.Columns.Add("ItemId", typeof(int));
            dt.Columns.Add("PRQty", typeof(string));
            dt.Columns.Add("WISQty", typeof(string));
            dt.Columns.Add("GQNQty", typeof(string));
            DataRow dr;
            string sql = "select  ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,(SELECT sum(IssuedQty)FROM tblInv_WIS_Details inner join tblInv_WIS_Master on tblInv_WIS_Master.Id=tblInv_WIS_Details.MId And tblInv_WIS_Details.ItemId=tblDG_Item_Master.Id And tblInv_WIS_Master.WONo='" + wono + "')As WISQty,(SELECT sum(Qty) FROM tblMM_PR_Details inner join tblMM_PR_Master on tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id And tblMM_PR_Master.WONo='" + wono + "')As PRQty,(select Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty from tblQc_MaterialQuality_Details,tblinv_MaterialReceived_Details,tblMM_PO_Details,tblMM_PR_Details,tblMM_PR_Master where tblQc_MaterialQuality_Details.GRRId=tblinv_MaterialReceived_Details.Id And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id  And tblMM_PR_Master.Id=tblMM_PR_Details.MId  And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id  And tblMM_PR_Master.WONo='" + wono + "') As GQNQty from tblDG_BOM_Master,tblDG_Item_Master,Unit_Master where WONo='" + wono + "'" + param + " And Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.CompId='" + CompId + "' And tblDG_BOM_Master.FinYearId<='" + finid + "' And ECNFlag=0 AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + wono + "' and CompId='" + CompId + "' And FinYearId<='" + finid + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();
                dr[0] = rdr["ItemCode"].ToString();
                dr[1] = rdr["ManfDesc"].ToString();
                dr[2] = rdr["UOMBasic"].ToString();
                double tqty = 0;
                dr[3] = tqty;
                double liQty = 0;
                liQty = fun.AllComponentBOMQty(CompId, wono, rdr["ItemId"].ToString(), finid);
                dr[4] = liQty;
                dr[7] = rdr["ItemId"].ToString();
                //PR Qty
                double PRQty = 0;
                if (rdr["PRQty"] != DBNull.Value)
                {
                    PRQty = Convert.ToDouble(rdr["PRQty"]);
                }
                dr[8] = PRQty.ToString();
                //WIS Qty
                double WISQty = 0;
                if (rdr["WISQty"] != DBNull.Value)
                {
                    WISQty = Convert.ToDouble(rdr["WISQty"]);
                }
                dr[9] = WISQty.ToString();
                //GQN Qty
                double GQNQty = 0;
                if (rdr["GQNQty"] != DBNull.Value)
                {
                    GQNQty = Convert.ToDouble(rdr["GQNQty"]);
                }
                dr[10] = GQNQty.ToString();
                if (rdr["FileName"].ToString() != "" && rdr["FileName"] != DBNull.Value)
                {
                    dr[5] = "View";
                }
                else
                {
                    dr[5] = "";
                }

                if (rdr["AttName"].ToString() != "" && rdr["AttName"] != DBNull.Value)
                {
                    dr[6] = "View";
                }
                else
                {
                    dr[6] = "";
                }

                if (Math.Round((liQty - PRQty - WISQty + GQNQty), 3) > 0)
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            rdr.Close();

        }
        catch (Exception ch)
        {
        }
        finally
        {
            con.Close();
        }

    }
    public string WOmfgdate(string wono, int compid, int finid)
    {
        string WomfgDt = "";
        try
        {
            string StrSql = fun.select("SD_Cust_WorkOrder_Master.BoughtoutMaterialDate", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Master.WONo='" + wono + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finid + "'And SD_Cust_WorkOrder_Master.CompId='" + compid + "'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(StrSql, con);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
           
            if (dt.Tables[0].Rows.Count > 0 && dt.Tables[0].Rows[0]["BoughtoutMaterialDate"] != DBNull.Value)
            {
                WomfgDt = fun.FromDateDMY(dt.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());

            }
            return WomfgDt;
        }
        catch (Exception ex){}
        return WomfgDt;
    }
    protected void RadGrid1_ColumnCreated(object sender, Telerik.Web.UI.GridColumnCreatedEventArgs e)
    {
    }
    public void FillFIN()
    {
      try
        {

            foreach (GridDataItem grv2 in RadGrid1.Items)
            {
                string itemId = ((Label)grv2.FindControl("lblItemId")).Text;
                double bomQty = Convert.ToDouble(decimal.Parse(((Label)grv2.FindControl("lblbomqty")).Text).ToString("N3"));
                double WisQty = 0;
                double PRQty = 0;
                double PRTempQty = 0;
                double GQnQty = 0;
                PRQty = fun.RMQty_PR(itemId, wono, CompId, "tblMM_PR_Details");
                PRTempQty = fun.RMQty_PR_Temp(itemId, SId, CompId, "tblMM_PLN_PR_Temp");
                WisQty = fun.CalWISQty(CompId.ToString(), wono, itemId.ToString());
                GQnQty = fun.GQNQTY(CompId, wono, itemId.ToString());

                double Rate = 0;
                double Discount = 0;
                string GetRate = fun.select("Discount,Rate,(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "' order by DisRate Asc");
                SqlCommand cmdtempR = new SqlCommand(GetRate, con);
                SqlDataAdapter DAtempR = new SqlDataAdapter(cmdtempR);
                DataSet DStempR = new DataSet();
                DAtempR.Fill(DStempR);
                if (DStempR.Tables[0].Rows.Count > 0)
                {
                    Discount = Convert.ToDouble(decimal.Parse(DStempR.Tables[0].Rows[0][0].ToString()).ToString("N2"));
                    Rate = Convert.ToDouble(decimal.Parse(DStempR.Tables[0].Rows[0][1].ToString()).ToString("N2"));

                }

                string sql2 = fun.select("*", "tblMM_PLN_PR_Temp", "ItemId='" + itemId + "' And SessionId='" + SId + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2); 
                if (DS2.Tables[0].Rows.Count > 0)
                {
                    DataTable dtR = new DataTable();
                    DataRow drR = null;
                    dtR.Columns.Add(new DataColumn("Column111", typeof(string)));
                    dtR.Columns.Add(new DataColumn("Column211", typeof(string)));
                    dtR.Columns.Add(new DataColumn("Column311", typeof(string)));
                    dtR.Columns.Add(new DataColumn("Column411", typeof(string)));
                    dtR.Columns.Add(new DataColumn("Id11", typeof(string)));
                    dtR.Columns.Add(new DataColumn("SessionId", typeof(string)));
                    dtR.Columns.Add(new DataColumn("Column511", typeof(string)));                    
                    for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                    {
                        drR = dtR.NewRow();
                        string sqlSupplier = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + DS2.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
                        SqlCommand cmdSupplier = new SqlCommand(sqlSupplier, con);
                        SqlDataAdapter DASupplier = new SqlDataAdapter(cmdSupplier);
                        DataSet DSSupplier = new DataSet();
                        DASupplier.Fill(DSSupplier);
                        if (DSSupplier.Tables[0].Rows.Count > 0)
                        {
                            drR["Column111"] = DSSupplier.Tables[0].Rows[0]["SupplierName"].ToString();
                        }
                        drR["Column211"] = DS2.Tables[0].Rows[i]["Qty"].ToString();
                        drR["Column311"] = DS2.Tables[0].Rows[i]["Rate"].ToString();
                        drR["Column411"] = fun.FromDateDMY(DS2.Tables[0].Rows[i]["DelDate"].ToString());
                        drR["Id11"] = DS2.Tables[0].Rows[i]["Id"].ToString();
                        drR["SessionId"] = DS2.Tables[0].Rows[i]["SessionId"].ToString();
                        drR["Column511"] = DS2.Tables[0].Rows[i]["Discount"].ToString();                        
                        dtR.Rows.Add(drR);
                        dtR.AcceptChanges();
                    }
                    DataSet xds = new DataSet();
                    xds.Tables.Add(dtR);
                    DataTable dtNewRow = new DataTable();
                    DataRow drNewRow = null;
                    dtNewRow.Columns.Add(new DataColumn("Column111", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column211", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column311", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column411", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Id11", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("SessionId", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column511", typeof(string)));
                    drNewRow = dtNewRow.NewRow();
                    drNewRow["Column111"] = string.Empty;
                    drNewRow["Column211"] = string.Empty;
                    drNewRow["Column311"] = string.Empty;
                    drNewRow["Column411"] = string.Empty;
                    drNewRow["Id11"] = string.Empty;
                    drNewRow["SessionId"] = string.Empty;
                    drNewRow["Column511"] = string.Empty;
                    dtNewRow.Rows.Add(drNewRow);
                    DataSet xds1 = new DataSet();
                    xds1.Tables.Add(dtNewRow);
                    xds.Merge(xds1);
                    ((GridView)grv2.FindControl("GridView5")).DataSource = xds;
                    ((GridView)grv2.FindControl("GridView5")).DataBind();
                    GridView RadGrid5 = (GridView)grv2.FindControl("GridView5");
                    GridViewRow grv3 = RadGrid5.Rows[RadGrid5.Rows.Count - 1];                  
                    if (Math.Round((bomQty - PRQty - PRTempQty - WisQty + GQnQty),5) == 0.000)
                    {                        
                        RadGrid5.Rows[RadGrid5.Rows.Count - 1].Visible = false;
                    }
                    ((ImageButton)grv3.FindControl("ImageButton3")).Visible = false;
                    xds.Clear();
                    CheckBox ck3 = RadGrid5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
                    ck3.Checked = true;                 

                    if (ck3.Checked == true)
                    {
                        foreach (GridViewRow grv4 in RadGrid5.Rows)
                        {                           
                            ((TextBox)grv4.FindControl("txtQtyFin")).Enabled = false;
                            ((TextBox)grv3.FindControl("txtQtyFin")).Enabled = true;

                            ((TextBox)grv4.FindControl("txtFinRate")).Enabled = false;
                            ((TextBox)grv3.FindControl("txtFinRate")).Enabled = true;
                            ((TextBox)grv4.FindControl("txtDiscount")).Enabled = false;
                            ((TextBox)grv3.FindControl("txtDiscount")).Enabled = true;

                            ((TextBox)grv4.FindControl("txtSupplierFin")).Enabled = false;
                            ((TextBox)grv3.FindControl("txtSupplierFin")).Enabled = true;

                            ((TextBox)grv4.FindControl("txtFinDeliDate")).Enabled = false;
                            ((TextBox)grv3.FindControl("txtFinDeliDate")).Enabled = true;
                        }                      

                        ((TextBox)grv3.FindControl("txtQtyFin")).Text = Math.Round((bomQty - PRQty - PRTempQty - WisQty + GQnQty),5).ToString();
                     
                     ((TextBox)grv3.FindControl("txtFinDeliDate")).Text = WomfDate;

                     ((TextBox)grv3.FindControl("txtFinRate")).Text = Rate.ToString();
                     ((TextBox)grv3.FindControl("txtDiscount")).Text =Discount.ToString();

                    }
                }
                else
                {

                    
                    DataTable dtNewRow = new DataTable();
                    DataRow drNewRow = null;
                    dtNewRow.Columns.Add(new DataColumn("Column111", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column211", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column311", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column411", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Id11", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("SessionId", typeof(string)));
                    dtNewRow.Columns.Add(new DataColumn("Column511", typeof(string)));
                    drNewRow = dtNewRow.NewRow();
                    drNewRow["Column111"] = string.Empty;
                    drNewRow["Column211"] = string.Empty;
                    drNewRow["Column311"] = string.Empty;
                    drNewRow["Column411"] = string.Empty;
                    drNewRow["Id11"] = string.Empty;
                    drNewRow["SessionId"] = string.Empty;
                    drNewRow["Column511"] = string.Empty;
                    dtNewRow.Rows.Add(drNewRow);
                    DataSet xds1 = new DataSet();
                    xds1.Tables.Add(dtNewRow);
                    ((GridView)grv2.FindControl("GridView5")).DataSource = xds1;
                    ((GridView)grv2.FindControl("GridView5")).DataBind();
                    GridView RadGrid5 = (GridView)grv2.FindControl("GridView5");
                    GridViewRow grv3 = RadGrid5.Rows[RadGrid5.Rows.Count - 1];
                    ((ImageButton)grv3.FindControl("ImageButton3")).Visible = false;
                    CheckBox ck3 = RadGrid5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;                    
                  if (ck3.Checked == true)
                    {
            
                     ((TextBox)grv3.FindControl("txtQtyFin")).Text = decimal.Parse((bomQty -PRQty-WisQty+GQnQty).ToString()).ToString("N3");
                     ((TextBox)grv3.FindControl("txtFinDeliDate")).Text = WomfDate;

                     ((TextBox)grv3.FindControl("txtFinRate")).Text = decimal.Parse(Rate.ToString()).ToString("N2");
                     ((TextBox)grv3.FindControl("txtDiscount")).Text = decimal.Parse(Discount.ToString()).ToString("N2");
                    }
                }

            }
        }
      catch(Exception ex){}
    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            RadGrid1.CurrentPageIndex = 0;
            RadGrid1.ClientSettings.Scrolling.ScrollLeft = "390";
            GridViewRow grv = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            string Id = ((Label)grv.FindControl("lblFinId")).Text;
            string DMId = ((Label)grv.FindControl("lblFinDMid")).Text;
            if (e.CommandName == "FinDelete")
            {
                string StrTemp1 = fun.delete("tblMM_PLN_PR_Temp", "Id='" + Id + "'");
                SqlCommand cmdTemp1 = new SqlCommand(StrTemp1, con);
                con.Open();
                cmdTemp1.ExecuteNonQuery();
                con.Close();
                this.FillFIN();
            }
        }
        catch (Exception ex){}
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
       try
        {
            GridDataItem grv = (GridDataItem)(((LinkButton)e.CommandSource).NamingContainer);
            string itemId = ((Label)grv.FindControl("lblItemId")).Text;
            double bomQty = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblbomqty")).Text).ToString("N3"));
            GridView RadGrid5 = (GridView)grv.FindControl("GridView5");// Finish               
            CheckBox ck3 = RadGrid5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
            if (e.CommandName == "viewImg")
            {
                Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemId + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
            }

            if (e.CommandName == "viewSpec")
            {
                Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemId + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
            }
            if (e.CommandName == "TempAdd")
            {
               
                string Supplier11 = "";
                string SupId11 = "";
                double FINQty = 0;
                double FINRate = 0;
                double FINDisc = 0;
                string FINDeliDate = "";
                string FINDeliDate1 = "";
                double DiscRate = 0;
                int r = 0;
                double rate = 0;

                string sqlfg = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + CompId + "'   ");
                SqlCommand cmdfg = new SqlCommand(sqlfg, con);
                SqlDataAdapter dafg = new SqlDataAdapter(cmdfg);
                DataSet DSfg = new DataSet();
                dafg.Fill(DSfg);
                if (DSfg.Tables[0].Rows.Count > 0 && DSfg.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                {
                    rate = Convert.ToDouble(decimal.Parse(DSfg.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
                }
                else
                {
                    string sqlrt2 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "' ");
                    SqlCommand cmdrt2 = new SqlCommand(sqlrt2, con);
                    SqlDataAdapter dart2 = new SqlDataAdapter(cmdrt2);
                    DataSet DSrt2 = new DataSet();
                    dart2.Fill(DSrt2);

                    if (DSrt2.Tables[0].Rows.Count > 0 && DSrt2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                    {
                        rate = Convert.ToDouble(decimal.Parse(DSrt2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
                    }
                }


           
                GridViewRow row3 = RadGrid5.Rows[RadGrid5.Rows.Count - 1];
                if (ck3.Checked == true && ((TextBox)row3.FindControl("txtQtyFin")).Text != "" && ((TextBox)row3.FindControl("txtQtyFin")).Text!="0" && ((TextBox)row3.FindControl("txtSupplierFin")).Text != "" && ((TextBox)row3.FindControl("txtFinRate")).Text != "")
                {
                    RadGrid1.CurrentPageIndex = 0;
                    RadGrid1.ClientSettings.Scrolling.ScrollLeft = "390";
                    Supplier11 = ((TextBox)row3.FindControl("txtSupplierFin")).Text;
                    SupId11 = fun.getCode(((TextBox)row3.FindControl("txtSupplierFin")).Text);
                    FINQty = Convert.ToDouble(decimal.Parse(((TextBox)row3.FindControl("txtQtyFin")).Text).ToString("N3"));
                    FINRate = Convert.ToDouble(decimal.Parse(((TextBox)row3.FindControl("txtFinRate")).Text).ToString("N2"));
                    FINDeliDate = fun.FromDateDMY(((TextBox)row3.FindControl("txtFinDeliDate")).Text);
                    FINDeliDate1 = ((TextBox)row3.FindControl("txtFinDeliDate")).Text;
                    FINDisc= Convert.ToDouble(((TextBox)row3.FindControl("txtDiscount")).Text);
                    DiscRate = Convert.ToDouble(decimal.Parse((FINRate - (FINRate * FINDisc / 100)).ToString()).ToString("N2"));
                    double WisQty = 0;
                    double PRQty = 0;
                    double PRTempQty = 0;
                    double GQnQty = 0;
                    PRQty = fun.RMQty_PR(itemId, wono, CompId, "tblMM_PR_Details");
                    PRTempQty = fun.RMQty_PR_Temp(itemId, SId, CompId, "tblMM_PLN_PR_Temp");
                    WisQty = fun.CalWISQty(CompId.ToString(), wono, itemId.ToString());
                    GQnQty = fun.GQNQTY(CompId, wono, itemId.ToString());
                    string sqlCheck = fun.select("*", "tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SupplierId='" + SupId11 + "' And DelDate='" + FINDeliDate + "' AND ItemId='" + itemId + "' AND SessionId='" + SId + "'");
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
                    SqlDataAdapter DACheck = new SqlDataAdapter(cmdCheck);
                    DataSet DSCheck = new DataSet();
                    DACheck.Fill(DSCheck);
                   
                    if (DSCheck.Tables[0].Rows.Count == 0)
                    {
                        
                        if (Math.Round((bomQty - FINQty - PRQty - PRTempQty - WisQty + GQnQty),5) == 0)
                        {                             
                            
                            if (DiscRate > 0)
                            {
                                
                                if (rate > 0)
                                {
                                    double x = 0;
                                    x = Convert.ToDouble(decimal.Parse((rate - DiscRate).ToString()).ToString("N2"));
                                    if (x >= 0 )
                                    {
                                        this.Insfun("tblMM_PLN_PR_Temp",CompId,SId,Convert.ToInt32(itemId),SupId11,FINQty,FINRate,FINDeliDate,FINDisc);

                                    }
                                    else
                                    {
                                        string sqlrate = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemId + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");

                                        SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                                        SqlDataAdapter darate = new SqlDataAdapter(cmdrate);
                                        DataSet dsrate = new DataSet();
                                        darate.Fill(dsrate);

                                        if (dsrate.Tables[0].Rows.Count > 0)
                                        {
                                            this.Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(itemId), SupId11, FINQty, FINRate, FINDeliDate, FINDisc);
                                        }
                                        else
                                        {
                                           
                                            string mystring2 = string.Empty;
                                            mystring2 = "Entered rate is not acceptable!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring2 + "');", true);
                                        }

                                    }
                                }

                                else
                                {

                                    this.Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(itemId), SupId11, FINQty, FINRate, FINDeliDate, FINDisc);

                                }
                                this.FillFIN();
                            }
                            else
                            {
                                string mystring1 = string.Empty;
                                mystring1 = "Entered rate is not acceptable!";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);
                            }
                           
                        }

                       else if (Math.Round((bomQty -FINQty-PRQty - PRTempQty - WisQty + GQnQty),5)  >= 0)
                        {                           

                            if (DiscRate > 0)
                            {
                                if (rate > 0)
                                {
                                    double x = 0;
                                    x = Convert.ToDouble(decimal.Parse((rate - DiscRate).ToString()).ToString("N2")); 
                                    if (x >= 0)
                                    {
                                        this.Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(itemId), SupId11, FINQty, FINRate, FINDeliDate, FINDisc);

                                    }
                                    else
                                    {
                                        string sqlrate = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemId + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");

                                        SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                                        SqlDataAdapter darate = new SqlDataAdapter(cmdrate);
                                        DataSet dsrate = new DataSet();
                                        darate.Fill(dsrate);
                                        if (dsrate.Tables[0].Rows.Count > 0)
                                        {
                                            this.Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(itemId), SupId11, FINQty, FINRate, FINDeliDate, FINDisc);
                                        }
                                        else
                                        {
                                           
                                            string mystring2 = string.Empty;
                                            mystring2 = "Entered rate is not acceptable!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring2 + "');", true);
                                        }

                                    }
                                }

                                else
                                {

                                    this.Insfun("tblMM_PLN_PR_Temp", CompId, SId, Convert.ToInt32(itemId), SupId11, FINQty, FINRate, FINDeliDate, FINDisc);

                                } 
                                this.FillFIN();
                            }
                            else
                            {
                                string mystring1 = string.Empty;
                                mystring1 = "Entered rate is not acceptable!";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);
                            }                           
                        }
                    }
                    else
                    {
                        r++;
                    }
                }

                if (r > 0)
                {
                    string mystring1 = string.Empty;
                    mystring1 = "Invalid data entry ";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);
                }
            }         

        }
     catch (Exception es) { }
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
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

       try
        {
            RadGrid1.CurrentPageIndex = 0;
            RadGrid1.ClientSettings.Scrolling.ScrollLeft = "385";
            CheckBox x = (CheckBox)sender;
            GridViewRow grv = (GridViewRow)x.NamingContainer;
            int RowIndex2 = grv.RowIndex + 1;
            GridView gv = (GridView)grv.NamingContainer;
            TextBox txtSupFin = gv.Rows[RowIndex2].FindControl("txtSupplierFin") as TextBox;
            TextBox txtQtyFin = gv.Rows[RowIndex2].FindControl("txtQtyFin") as TextBox;
            TextBox txtDeliDateFin = gv.Rows[RowIndex2].FindControl("txtFinDeliDate") as TextBox;
            TextBox txtRateFin = gv.Rows[RowIndex2].FindControl("txtFinRate") as TextBox;
            TextBox TxtDiscount = gv.Rows[RowIndex2].FindControl("txtDiscount") as TextBox;
            GridDataItem grvrad = (GridDataItem)gv.NamingContainer;
            RadGrid grvparent = (RadGrid)gv.Parent.Parent.Parent.Parent.Parent;
            int RowIndexMain = grvrad.DataSetIndex;
            Label lblItemId = grvparent.Items[RowIndexMain].FindControl("lblItemId") as Label;
            Label lblBomQty = grvparent.Items[RowIndexMain].FindControl("lblbomqty") as Label;
            int itemId = Convert.ToInt32(lblItemId.Text);
            double bomQty = Convert.ToDouble(lblBomQty.Text);
            double Rate = 0;
            double Discount = 0;
            if (x.Checked == true)
            {
                // Old code for Rate And Discount.

                //string GetRate = fun.select("Discount,Rate,(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "' order by DisRate Asc ");
                //SqlCommand cmdtempR = new SqlCommand(GetRate, con);
                //SqlDataAdapter DAtempR = new SqlDataAdapter(cmdtempR);
                //DataSet DStempR = new DataSet();
                //DAtempR.Fill(DStempR);
                //if (DStempR.Tables[0].Rows.Count > 0)
                //{
                //    Discount = Convert.ToDouble(decimal.Parse(DStempR.Tables[0].Rows[0][0].ToString()).ToString("N2"));
                //    Rate = Convert.ToDouble(decimal.Parse(DStempR.Tables[0].Rows[0][1].ToString()).ToString("N2"));
                //}


               // -Updated by Shridhar -------------------------------------------------------------------------------------------------
                // New Code for Rate And Discount.

                string sqlfg = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + CompId + "'");
                SqlCommand cmdfg = new SqlCommand(sqlfg, con);
                SqlDataAdapter dafg = new SqlDataAdapter(cmdfg);
                DataSet DSfg = new DataSet();
                dafg.Fill(DSfg);
                if (DSfg.Tables[0].Rows.Count > 0 && DSfg.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                {
                    Rate = Convert.ToDouble(decimal.Parse(DSfg.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
                    Discount = Convert.ToDouble(decimal.Parse(DSfg.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
                }

                else
                {
                    string sqlrt = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "'  order by DisRate Asc ");
                    SqlCommand cmdrt = new SqlCommand(sqlrt, con);
                    SqlDataAdapter dart = new SqlDataAdapter(cmdrt);
                    DataSet DSrt = new DataSet();
                    dart.Fill(DSrt);

                    if (DSrt.Tables[0].Rows.Count > 0 && DSrt.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                    {
                        Rate = Convert.ToDouble(decimal.Parse(DSrt.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
                        Discount = Convert.ToDouble(decimal.Parse(DSrt.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
                    }
                }
                //------------------------------------------------------------------------------------------------------------


                if (txtQtyFin.Text == "" && txtDeliDateFin.Text == "")
                {
                    //txtSupFin.Text = SupplierName;
                    txtQtyFin.Text = (bomQty - (fun.RMQty_PR(itemId.ToString(), wono, CompId, "tblMM_PR_Details")) - fun.CalWISQty(CompId.ToString(), wono, itemId.ToString()) + fun.GQNQTY(CompId, wono, itemId.ToString())).ToString();
                    txtDeliDateFin.Text = WomfDate;
                    txtRateFin.Text = Rate.ToString();
                    TxtDiscount.Text = Discount.ToString();
                }

            }

            else
            {

                txtSupFin.Text = string.Empty;
                txtQtyFin.Text = string.Empty;
                txtDeliDateFin.Text = string.Empty;
                txtRateFin.Text = string.Empty;
                TxtDiscount.Text = string.Empty;
                string sql2 = fun.select("*", "tblMM_PLN_PR_Temp", "ItemId='" + itemId + "' AND SessionId='" + SId + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);

                if (DS2.Tables[0].Rows.Count > 0)
                {
                    string StrTemp1 = fun.delete("tblMM_PLN_PR_Temp", "SessionId='" + SId + "' And ItemId='" + itemId + "'");
                    SqlCommand cmdTemp1 = new SqlCommand(StrTemp1, con);
                    con.Open();
                    cmdTemp1.ExecuteNonQuery();
                    con.Close();
                    this.FillFIN();

                }
               
            }
        }
       catch (Exception ex) { }
    }    
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34");
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        //Generate PR

        try
        {
            double BomQty = 0;
            string sql2 = fun.select("*", "tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2, "tblMM_PLN_PR_Temp");
            int v = 0;
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            if (DS2.Tables[0].Rows.Count > 0)
            {

                string cmdStr = fun.select("PRNo", "tblMM_PR_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' order by PRNo desc");
                SqlCommand cmd1 = new SqlCommand(cmdStr, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "tblMM_PR_Master");

                string PRNo = "";

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int PRstr = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString()) + 1;
                    PRNo = PRstr.ToString("D4");
                }
                else
                {
                    PRNo = "0001";
                }


                for (int m = 0; m < DS2.Tables[0].Rows.Count; m++)
                {
                    BomQty = Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, wono, DS2.Tables[0].Rows[m]["ItemId"].ToString(), fyid).ToString()).ToString("N3"));

                    // Calculate Sum of Qty
                    string sqltempR = fun.select("sum(Qty) as FIN_Qty", "tblMM_PLN_PR_Temp", "ItemId='" + DS2.Tables[0].Rows[m]["ItemId"].ToString() + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'");

                    SqlCommand cmdtempR = new SqlCommand(sqltempR, con);
                    SqlDataAdapter DAtempR = new SqlDataAdapter(cmdtempR);
                    DataSet DStempR = new DataSet();
                    DAtempR.Fill(DStempR);

                    if (DStempR.Tables[0].Rows.Count > 0)
                    {
                        if ((BomQty - Convert.ToDouble(decimal.Parse(DStempR.Tables[0].Rows[0]["FIN_Qty"].ToString()).ToString("N3"))) >= 0)
                        {
                            v++;
                        }
                    }
                }

                if (v < 0)
                {
                    string mystring1 = string.Empty;
                    mystring1 = "Invalid data entry found.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);
                }
                else
                {
                    int p1 = 1;
                    int p2 = 0;

                    int FINId = 0;
                    DataSet ds9 = new DataSet();

                    for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                    {
                        if (p1 == 1)
                        {
                            SqlCommand exeme1 = new SqlCommand(fun.insert("tblMM_PR_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WONo,PRNo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + wono + "','" + PRNo + "'"), con);
                            con.Open();
                            exeme1.ExecuteNonQuery();
                            con.Close();

                            string cmdStr1 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' order by Id desc");
                            SqlCommand cmd3 = new SqlCommand(cmdStr1, con);
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                            da2.Fill(ds9, "tblMM_PR_Master");
                            p1 = 0;

                        }

                        FINId = Convert.ToInt32(ds9.Tables[0].Rows[0]["Id"].ToString());

                        SqlCommand exeme = new SqlCommand(fun.insert("tblMM_PR_Details", "MId,PRNo,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Discount", "'" + FINId + "','" + PRNo + "','" + DS2.Tables[0].Rows[i]["ItemId"].ToString() + "','" + Convert.ToDouble(DS2.Tables[0].Rows[i]["Qty"].ToString()) + "','" + DS2.Tables[0].Rows[i]["SupplierId"].ToString() + "','" + Convert.ToDouble(DS2.Tables[0].Rows[i]["Rate"].ToString()) + "','28','" + DS2.Tables[0].Rows[i]["DelDate"].ToString() + "','" + Convert.ToDouble(DS2.Tables[0].Rows[i]["Discount"].ToString()) + "'"), con);

                        con.Open();
                        exeme.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Page.Response.Redirect("PR_New.aspx?ModId=6&SubModId=34&msg=" + PRNo + "");
            }
            else
            {
                string mystring1 = string.Empty;
                mystring1 = "Invalid data entry found.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);
            }
        }
        catch(Exception et)
        {
        }
    }
    public void Insfun(string tbl, int compid, string SId, int itemId, string SupId,double Qty,double Rate, string DelDate, double Discount)
    {
        string StrSql3 = fun.insert(tbl, "CompId,SessionId,ItemId,SupplierId,Qty,Rate,DelDate,Discount", "" + compid + ",'" + SId + "',"+itemId+",'" + SupId + "','" + Qty + "','" + Rate + "','" + DelDate + "','" + Discount + "'");
        SqlCommand cmd3 = new SqlCommand(StrSql3, con);
        con.Open();
        cmd3.ExecuteNonQuery();
        con.Close();
    }
    

}

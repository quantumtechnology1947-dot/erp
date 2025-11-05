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

public partial class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_New : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    //string SupId = "";
    //string FyId = "";
    int FinYearId = 0;
    int CompId = 0;
    string sId = "";
    string connStr = string.Empty;
    SqlConnection con; 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);             
            if (!Page.IsPostBack)
            {
                this.loadData();
            }             
        }
        catch (Exception ett)
        {

        }
    }

    public void loadData()
    {
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            string sid = fun.getCode(txtSupplier.Text);
            string x = "";
            if (sid != string.Empty)
            {
                x = " And tblMM_Supplier_master.SupplierId='" + sid + "'";
            }

            SqlCommand cmd = new SqlCommand("Sp_GRR_New", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            cmd.Parameters["@CompId"].Value = CompId;
            cmd.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
            cmd.Parameters["@FinId"].Value = FinYearId;
            cmd.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            cmd.Parameters["@x"].Value = x;
            SqlDataReader rdr = cmd.ExecuteReader();
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GINNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Supplier", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("ChNO", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChDT", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            DataRow dr;
            while (rdr.Read())
            {
                dr = dt.NewRow();
                int FinYr = Convert.ToInt32(rdr["FinYearId"]);
                string SysDt = fun.FromDateDMY(rdr["GINDate"].ToString());
                int k = 0;
                int z = 0;
                double calbalrecqty = 0;
                double getRecQty = 0;
                double getInvQty = 0;

                if (rdr["GINQty"] != DBNull.Value)
                {
                    getInvQty = Convert.ToDouble(rdr["GINQty"]);

                    if (getInvQty > 0)
                    {
                        k++;
                    }
                }
                if (rdr["GRRQty"] != DBNull.Value)
                {
                    getRecQty = Convert.ToDouble(rdr["GRRQty"]);
                }

                calbalrecqty = Math.Round((getInvQty - getRecQty), 3);

                if (calbalrecqty > 0)
                {
                    z++;
                }

                if (k > 0 && z > 0)
                {
                    dr[0] = rdr["PONo"].ToString();
                    dr[1] = rdr["FinYear"].ToString();
                    dr[2] = rdr["GINNo"].ToString();
                    dr[3] = SysDt;
                    dr[4] = rdr["SupplierName"].ToString();
                    dr[5] = rdr["Id"].ToString();
                    dr[6] = rdr["ChallanNo"].ToString();
                    dr[7] = fun.FromDateDMY(rdr["ChallanDate"].ToString());
                    dr[8] = rdr["SupplierId"].ToString();
                    dr[9] = FinYr;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            rdr.Close();

        }
        catch (Exception et) { }

        finally
        {
            con.Close();
            con.Dispose();
            dt.Dispose();
        }

    }


    //public void loadData(string spid)
    //{
    //    try
    //    {
    //        string connStr = fun.Connection();
    //        SqlConnection con = new SqlConnection(connStr);
    //        string sId = Session["username"].ToString();
    //        int FinYearId = Convert.ToInt32(Session["finyear"]);
    //        int CompId = Convert.ToInt32(Session["compid"]);
    //        con.Open();
    //        string StrSql = fun.select("Id,FinYearId,PONo,GINNo,ChallanNo,ChallanDate,SysDate As GINDate", "tblInv_Inward_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "' Order by Id Desc");            
    //        SqlCommand cmdsupId = new SqlCommand(StrSql, con);           
    //        SqlDataReader rdr = cmdsupId.ExecuteReader();
    //        DataTable dt = new DataTable();            
    //        dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("GINNo", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("Supplier", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
    //        dt.Columns.Add(new System.Data.DataColumn("ChNO", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("ChDT", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("SupId", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
    //        DataRow dr;           
    //        while(rdr.Read())
    //        {  
    //            int FinYr = Convert.ToInt32(rdr["FinYearId"]);
    //            string SysDt = fun.FromDateDMY(rdr["GINDate"].ToString());
    //            string StrSql2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo='" + rdr["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.FinYearId='" + FinYr + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
    //            SqlCommand cmdsupId2 = new SqlCommand(StrSql2, con);
    //            SqlDataReader rdr2 = cmdsupId2.ExecuteReader();                            
    //            int k = 0; int z=0;
    //            while (rdr2.Read())                
    //            {
    //                if (rdr2["PRSPRFlag"].ToString() == "0")
    //                {
    //                    string StrFlag = fun.select("tblMM_PR_Details.AHId", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo='" + rdr2["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + rdr2["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.FinYearId='" + FinYr + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId ");

    //                    SqlCommand cmdStrFlag = new SqlCommand(StrFlag, con);
    //                    SqlDataAdapter daStrFlag = new SqlDataAdapter(cmdStrFlag);
    //                    DataSet DSStrFlag = new DataSet();
    //                    daStrFlag.Fill(DSStrFlag);                       
    //                    if (DSStrFlag.Tables[0].Rows.Count > 0)
    //                    {
    //                        string checkAHId = fun.select("Category", "AccHead", "Id='" + DSStrFlag.Tables[0].Rows[0]["AHId"].ToString() + "'");
    //                        SqlCommand cmdcheckAHId = new SqlCommand(checkAHId, con);
    //                        SqlDataAdapter dacheckAHId = new SqlDataAdapter(cmdcheckAHId);
    //                        DataSet DScheckAHId = new DataSet();
    //                        dacheckAHId.Fill(DScheckAHId);
    //                        if (DScheckAHId.Tables[0].Rows.Count > 0)
    //                        {
    //                            if (DScheckAHId.Tables[0].Rows[0]["Category"].ToString() == "With Material")
    //                            {
    //                                k++;

    //                                string StrSql5 = fun.select("ReceivedQty", "tblInv_Inward_Details", "GINNo='" + rdr["GINNo"].ToString() + "' AND GINId='" + rdr["Id"].ToString() + "' AND POId='" + rdr2["Id"].ToString() + "'");

    //                                SqlCommand cmdsupId5 = new SqlCommand(StrSql5, con);
    //                                SqlDataAdapter dasupId5 = new SqlDataAdapter(cmdsupId5);
    //                                DataSet DSSql5 = new DataSet();
    //                                DataTable dt5 = new DataTable();
    //                                dasupId5.Fill(DSSql5);

    //                                if (DSSql5.Tables[0].Rows.Count > 0)
    //                                {

    //                                    string sqlget = fun.select("sum(tblinv_MaterialReceived_Details.ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Details.POId='" + rdr2["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.GINNo='" + rdr["GINNo"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.GINId='" + rdr["Id"].ToString() + "'");

    //                                    SqlCommand cmdget = new SqlCommand(sqlget, con);
    //                                    SqlDataAdapter daget = new SqlDataAdapter(cmdget);
    //                                    DataSet DSget = new DataSet();
    //                                    daget.Fill(DSget);

    //                                    double calbalrecqty = 0;
    //                                    double getRecQty = 0;

    //                                    if (DSget.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
    //                                    {
    //                                        getRecQty = Convert.ToDouble(DSget.Tables[0].Rows[0]["sum_ReceivedQty"]);
    //                                    }
    //                                    calbalrecqty = (Convert.ToDouble(DSSql5.Tables[0].Rows[0]["ReceivedQty"]) - getRecQty);

    //                                    if (calbalrecqty > 0)
    //                                    {
    //                                        z++;
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                else if (rdr2["PRSPRFlag"].ToString() == "1")
    //                {
    //                    string StrFlag1 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo='" + rdr2["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + rdr2["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.FinYearId='" + FinYr + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
    //                    SqlCommand cmdStrFlag1 = new SqlCommand(StrFlag1, con);
    //                    SqlDataAdapter daStrFlag1 = new SqlDataAdapter(cmdStrFlag1);
    //                    DataSet DSStrFlag1 = new DataSet();
    //                    daStrFlag1.Fill(DSStrFlag1);

    //                    if (DSStrFlag1.Tables[0].Rows.Count > 0)
    //                    {
    //                        string checkAHId1 = fun.select("Category", "AccHead", "Id='" + DSStrFlag1.Tables[0].Rows[0]["AHId"].ToString() + "'");
    //                        SqlCommand cmdcheckAHId1 = new SqlCommand(checkAHId1, con);
    //                        SqlDataAdapter dacheckAHId1 = new SqlDataAdapter(cmdcheckAHId1);
    //                        DataSet DScheckAHId1 = new DataSet();
    //                        dacheckAHId1.Fill(DScheckAHId1);

    //                        if (DScheckAHId1.Tables[0].Rows.Count > 0)
    //                        {
    //                            if (DScheckAHId1.Tables[0].Rows[0]["Category"].ToString() == "With Material")
    //                            {
    //                                k++;

    //                                string StrSql5 = fun.select("POId,ReceivedQty", "tblInv_Inward_Details", " GINNo='" + rdr["GINNo"].ToString() + "' AND GINId='" + rdr["Id"].ToString() + "' AND POId='" + rdr2["Id"].ToString() + "'");
    //                                SqlCommand cmdsupId5 = new SqlCommand(StrSql5, con);
    //                                SqlDataAdapter dasupId5 = new SqlDataAdapter(cmdsupId5);
    //                                DataSet DSSql5 = new DataSet();
    //                                DataTable dt5 = new DataTable();
    //                                dasupId5.Fill(DSSql5);

    //                                if (DSSql5.Tables[0].Rows.Count > 0)
    //                                {

    //                                    string sqlget = fun.select("sum(tblinv_MaterialReceived_Details.ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Details.POId='" + rdr2["Id"].ToString() + "' AND tblinv_MaterialReceived_Master.GINNo='" + rdr["GINNo"].ToString() + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.GINId='" + rdr["Id"].ToString() + "'");

    //                                    SqlCommand cmdget = new SqlCommand(sqlget, con);
    //                                    SqlDataAdapter daget = new SqlDataAdapter(cmdget);
    //                                    DataSet DSget = new DataSet();
    //                                    daget.Fill(DSget);

    //                                    double calbalrecqty = 0;
    //                                    double getRecQty = 0;

    //                                    if (DSget.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
    //                                    {
    //                                        getRecQty = Convert.ToDouble(DSget.Tables[0].Rows[0]["sum_ReceivedQty"]);
    //                                    }
    //                                    calbalrecqty = (Convert.ToDouble(DSSql5.Tables[0].Rows[0]["ReceivedQty"]) - getRecQty);

    //                                    if (calbalrecqty > 0)
    //                                    {
    //                                        z++;
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }                    
    //            }

    //            if (k > 0 && z>0)
    //            {
    //                string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + FinYr + "' AND CompId='" + CompId + "'");
    //                SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
    //                SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
    //                DataSet DSFin = new DataSet();
    //                daFin.Fill(DSFin);

    //                string x = "";
    //                if (spid != "")
    //                {
    //                    x = " And SupplierId='" + spid + "'";
    //                }

    //                string sqlSupId = fun.select("SupplierId", "tblMM_PO_Master", "FinYearId='" + FinYr + "' AND PONo='" + rdr["PONo"].ToString() + "'" + x + " AND CompId='" + CompId + "'");

    //                SqlCommand cmdSup = new SqlCommand(sqlSupId, con);
    //                SqlDataAdapter daSup = new SqlDataAdapter(cmdSup);
    //                DataSet DSSup = new DataSet();
    //                daSup.Fill(DSSup);

    //                if (DSSup.Tables[0].Rows.Count > 0)
    //                {
    //                    dr = dt.NewRow();

    //                    string sqlSup = fun.select("SupplierName+' ['+SupplierId+']'", "tblMM_Supplier_master", "SupplierId='" + DSSup.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");

    //                    SqlCommand cmdSupId = new SqlCommand(sqlSup, con);
    //                    SqlDataAdapter daSupId = new SqlDataAdapter(cmdSupId);
    //                    DataSet DSSupId = new DataSet();
    //                    daSupId.Fill(DSSupId);
    //                    // For PONo
    //                    dr[0] = rdr["PONo"].ToString();
    //                    // For Fin Year
    //                    if (DSFin.Tables[0].Rows.Count > 0)
    //                    {
    //                        dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
    //                    }
    //                    // For GINNO 
    //                    dr[2] = rdr["GINNo"].ToString();

    //                    //For Sys Date 
    //                    dr[3] = SysDt;
    //                    if (DSSupId.Tables[0].Rows.Count > 0)
    //                    {
    //                        dr[4] = DSSupId.Tables[0].Rows[0][0].ToString();
    //                    }
    //                    dr[6] = rdr["ChallanNo"].ToString();
    //                    dr[5] = rdr["Id"].ToString();
    //                    dr[7] = fun.FromDateDMY(rdr["ChallanDate"].ToString());
    //                    dr[8] = DSSup.Tables[0].Rows[0]["SupplierId"].ToString();
    //                    dr[9] = FinYr;
    //                    dt.Rows.Add(dr);
    //                    dt.AcceptChanges();
                        
    //                }
                    
    //            }               

    //        }

    //        GridView2.DataSource = dt;
    //        GridView2.DataBind();
    //        con.Close();
    //    }
    //   catch (Exception et) { }
    //}

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
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


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string Supid = ((Label)row.FindControl("lblsupId")).Text;
                string GinNo = ((Label)row.FindControl("lblGin")).Text;                
                string poNo = ((Label)row.FindControl("lblpo")).Text;
                string fyid = ((Label)row.FindControl("lblFinId")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;

                Response.Redirect("GoodsReceivedReceipt_GRR_New_Details.aspx?Id=" + Id + "&SupId=" + Supid + "&GINNo=" + GinNo + "&PONo=" + poNo + "&FyId=" + fyid + "&ModId=9&SubModId=38");

            }
        }
        catch (Exception ex) { }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        try
        {
                this.loadData();            
        }
        catch (Exception ex)
        { }
    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.loadData();
        }
        catch (Exception ex) { }
    }


}


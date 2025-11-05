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

public partial class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Delete : System.Web.UI.Page
{

    clsFunctions fun=new clsFunctions ();
    string SupId = "";
    string connStr = "";
    SqlConnection con;
    
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            if (!IsPostBack)
            {
                this.loadData(SupId);
            }
        }
        catch(Exception ex)
        {}
             
   }
    public void loadData(string spid)
    {
        try
        {
            con.Open();
            string x = "";
            if (spid != "")
            {
                x = " And tblMM_PO_Master.SupplierId='" + spid + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("Sp_GRR_Edit", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@CompId"].Value = CompId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@FinId"].Value = FinYearId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@x"].Value = x;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView2.DataSource = DSitem;
            GridView2.DataBind();
            con.Close();

        }
        catch (Exception ex) { }
    }

    //public void loadData(string spid)
    //{
    //    try
    //    {
    //        con.Open();
    //        string StrSql = fun.select("Id,FinYearId,GRRNo,GINNo,GINId,SysDate", "tblinv_MaterialReceived_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' Order by Id Desc");
    //        SqlCommand cmdsupId = new SqlCommand(StrSql, con);
    //        SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
    //        DataSet DSSql = new DataSet();

    //        DataTable dt = new DataTable();

    //        dasupId.Fill(DSSql);

    //        dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("GRRNo", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("GINNo", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("SupId", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("Supplier", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("ChNO", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("ChDT", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
    //        dt.Columns.Add(new System.Data.DataColumn("GINId", typeof(string)));

    //        DataRow dr;
    //        for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
    //        {
    //            dr = dt.NewRow();

    //            // For Financial year and GIn date
    //            int FinYr = Convert.ToInt32(DSSql.Tables[0].Rows[i]["FinYearId"]);
    //            string SysDt = fun.FromDateDMY(DSSql.Tables[0].Rows[i]["SysDate"].ToString());
    //            string sqlFin = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + FinYr + "'");

    //            SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
    //            SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
    //            DataSet DSFin = new DataSet();
    //            daFin.Fill(DSFin);

    //            string StrSql2 = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.POId,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate", "tblInv_Inward_Master,tblInv_Inward_Details", "tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.Id='" + DSSql.Tables[0].Rows[i]["GINId"].ToString() + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");

    //            SqlCommand cmdsupId2 = new SqlCommand(StrSql2, con);
    //            SqlDataAdapter dasupId2 = new SqlDataAdapter(cmdsupId2);
    //            DataSet DSSql2 = new DataSet();
    //            dasupId2.Fill(DSSql2);

    //            string x = "";
    //            if (spid != "")
    //            {
    //                x = " And tblMM_PO_Master.SupplierId='" + spid + "'";
    //            }

    //            if (DSSql2.Tables[0].Rows.Count > 0)
    //            {
    //                string StrSql3 = fun.select("tblMM_PO_Master.SupplierId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo='" + DSSql2.Tables[0].Rows[0]["PONo"].ToString() + "' AND tblMM_PO_Details.Id='" + DSSql2.Tables[0].Rows[0]["POId"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "'" + x + " AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");

    //                SqlCommand cmdsupId3 = new SqlCommand(StrSql3, con);
    //                SqlDataAdapter dasupId3 = new SqlDataAdapter(cmdsupId3);
    //                DataSet DSSql3 = new DataSet();
    //                dasupId3.Fill(DSSql3);

    //                if (DSSql3.Tables[0].Rows.Count > 0)
    //                {
    //                    string sqlSup = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + DSSql3.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");

    //                    SqlCommand cmdSupId = new SqlCommand(sqlSup, con);
    //                    SqlDataAdapter daSupId = new SqlDataAdapter(cmdSupId);
    //                    DataSet DSSupId = new DataSet();
    //                    daSupId.Fill(DSSupId);

    //                    dr[0] = DSSql.Tables[0].Rows[i]["FinYearId"].ToString();
    //                    if (DSFin.Tables[0].Rows.Count > 0)
    //                    {
    //                        dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
    //                    }

    //                    dr[2] = DSSql.Tables[0].Rows[i]["GRRNo"].ToString();
    //                    dr[3] = SysDt;
    //                    dr[4] = DSSql.Tables[0].Rows[i]["GINNo"].ToString();
    //                    dr[5] = DSSql2.Tables[0].Rows[0]["PONo"].ToString();
    //                    dr[6] = DSSql3.Tables[0].Rows[0]["SupplierId"].ToString();

    //                    if (DSSupId.Tables[0].Rows.Count > 0)
    //                    {
    //                        dr[7] = DSSupId.Tables[0].Rows[0]["SupplierName"].ToString() + " [" + DSSql3.Tables[0].Rows[0][0].ToString() + "]";
    //                    }

    //                    dr[8] = DSSql2.Tables[0].Rows[0]["ChallanNo"].ToString();
    //                    dr[9] = fun.FromDateDMY(DSSql2.Tables[0].Rows[0]["ChallanDate"].ToString());
    //                    dr[10] = DSSql.Tables[0].Rows[i]["Id"].ToString();
    //                    dr[11] = DSSql.Tables[0].Rows[i]["GINId"].ToString();

    //                    dt.Rows.Add(dr);
    //                    dt.AcceptChanges();
    //                }
    //            }
    //        }

    //        GridView2.DataSource = dt;
    //        GridView2.DataBind();
    //        con.Close();
    //    }
    //    catch (Exception et)
    //    {

    //    }
    //}

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master","CompId='"+CompId+"'");
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
                string GrrNo = ((Label)row.FindControl("lblGrrNo")).Text;
                string GinNo = ((Label)row.FindControl("lblGin")).Text;
                string GinId = ((Label)row.FindControl("lblGinId")).Text;
                string poNo = ((Label)row.FindControl("lblpo")).Text;
                string fyid = ((Label)row.FindControl("lblFinId")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;

                Response.Redirect("GoodsReceivedReceipt_GRR_Delete_Details.aspx?Id=" + Id + "&SupId=" + Supid + "&GRRNo=" + GrrNo + "&GINNo=" + GinNo + "&GINId=" + GinId + "&PONo=" + poNo + "&FyId=" + fyid + "&ModId=9&SubModId=38");
            }
        }
        catch (Exception ex) { }
    }
    
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string sid = "";
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            sid = fun.getCode(txtSupplier.Text);


            if (sid != "")
            {

                this.loadData(sid);
            }

            else
            {
                this.loadData(SupId);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string sid = "";
        try
        {            
            sid = fun.getCode(txtSupplier.Text);


            if (sid != "")
            {

                this.loadData(sid);
            }

            else
            {
                this.loadData(SupId);
            }
        }
        catch (Exception ex)
        { }
    }

}


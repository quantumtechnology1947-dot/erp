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

public partial class Module_MaterialManagement_Transactions_APO_SPR_ItemGrid : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SupCode = string.Empty;
    string FyId = string.Empty;
    string CompId = string.Empty;
    int Id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SupCode = Request.QueryString["Code"].ToString();
            FyId = Session["finyear"].ToString();
            CompId = Session["compid"].ToString();

            this.LoadSPRData();
        }
        catch (Exception ess)
        {
        }
    }
    public void LoadSPRData()
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        DataTable dt = new DataTable();
        con.Open();

        try
        {
            string StrSql = fun.select("tblMM_SPR_MasterA.SysDate,tblMM_SPR_MasterA.SessionId,tblMM_SPR_MasterA.SPRNo,tblMM_SPR_MasterA.FinYearId,tblMM_SPR_DetailsA.WONo,tblMM_SPR_DetailsA.DeptId,tblMM_SPR_DetailsA.Id,tblMM_SPR_DetailsA.ItemId,tblMM_SPR_DetailsA.AHId,tblMM_SPR_DetailsA.Qty,tblMM_SPR_DetailsA.DelDate", "tblMM_SPR_MasterA,tblMM_SPR_DetailsA", "tblMM_SPR_DetailsA.SupplierId='" + SupCode + "' AND tblMM_SPR_MasterA.SPRNo=tblMM_SPR_DetailsA.SPRNo AND tblMM_SPR_MasterA.Id=tblMM_SPR_DetailsA.MId And tblMM_SPR_MasterA.Authorize='0' AND tblMM_SPR_MasterA.FinYearId<='" + FyId + "' AND tblMM_SPR_MasterA.CompId='" + CompId + "'");
            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataReader DSSql = cmdsupId.ExecuteReader();
            /// DSSql.Read();

            dt.Columns.Add(new System.Data.DataColumn("SPRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DeliDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DeptId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("POQty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("RemainQty", typeof(double)));

            while (DSSql.Read())
            {

                DataRow dr;
                string CheckSql = fun.select("*", "tblMM_SPR_PO_TempA", "CompId='" + CompId + "' AND SPRNo='" + DSSql["SPRNo"].ToString() + "' AND SPRId='" + DSSql["Id"].ToString() + "'");

                SqlCommand cmdCheck = new SqlCommand(CheckSql, con);
                SqlDataReader DSCheck = cmdCheck.ExecuteReader();
                DSCheck.Read();

                double RemTempQty = 0;
                double RemQty = 0;
                double SPRQty = 0;
                SPRQty = Convert.ToDouble(DSSql["Qty"].ToString());
                double PoQty = 0;

                string sql4 = fun.select("Sum(tblMM_PO_DetailsA.Qty)As TotPoQty", "tblMM_PO_MasterA,tblMM_PO_DetailsA", "tblMM_PO_DetailsA.SPRId='" + DSSql["Id"].ToString() + "' AND tblMM_PO_MasterA.CompId='" + CompId + "' AND tblMM_PO_MasterA.Id=tblMM_PO_DetailsA.MId ");
                SqlCommand cmd4 = new SqlCommand(sql4, con);
                SqlDataReader DS4 = cmd4.ExecuteReader();
                DS4.Read();

                if (DS4.HasRows == true && DS4[0] != DBNull.Value)
                {
                    PoQty = Convert.ToDouble(DS4[0].ToString());
                }

                RemQty = Math.Round((SPRQty - PoQty), 5);

                if (RemQty > 0 && DSCheck.HasRows == false)
                {
                    dr = dt.NewRow();

                    //For PRNO 
                    dr[0] = DSSql["SPRNo"].ToString();
                    dr[5] = Convert.ToDouble(decimal.Parse(DSSql["Qty"].ToString()).ToString("N3"));
                    dr[9] = DSSql["Id"].ToString();
                    Id = Convert.ToInt32(dr[9]);

                    // For A/c Head
                    string sql3 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(DSSql["AHId"].ToString()) + "' ");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    SqlDataReader DS3 = cmd3.ExecuteReader();
                    DS3.Read();

                    dr[6] = DS3["Head"].ToString();

                    string SysDate = fun.FromDateDMY(DSSql["SysDate"].ToString());
                    dr[1] = SysDate;

                    // for Gen. By
                    string sqlGenBy = fun.select("EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DSSql["SessionId"].ToString() + "'");
                    SqlCommand cmdGenBy = new SqlCommand(sqlGenBy, con);
                    SqlDataReader DSGenBy = cmdGenBy.ExecuteReader();
                    DSGenBy.Read();

                    dr[8] = DSGenBy[0].ToString();

                    // for Item ID  from spr Details table
                    string sqlIid = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + DSSql["ItemId"].ToString() + "'");
                    SqlCommand cmdIid = new SqlCommand(sqlIid, con);
                    SqlDataReader DSIid = cmdIid.ExecuteReader();
                    DSIid.Read();

                    if (DSIid.HasRows == true)
                    {
                        dr[2] = fun.GetItemCode_PartNo(Convert.ToInt32(CompId), Convert.ToInt32(DSSql["ItemId"].ToString()));
                        dr[3] = DSIid[1].ToString();

                        // for UOM Purchase  from Unit Master table
                        string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIid[2].ToString() + "'");
                        SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                        SqlDataReader DSPurch = cmdPurch.ExecuteReader();
                        DSPurch.Read();

                        dr[4] = DSPurch[0].ToString();
                    }
                    string DeptName = "";
                    string WorkONo = "";

                    //For WO No
                    if (DSSql["WONo"].ToString() != "")
                    {
                        WorkONo = DSSql["WONo"].ToString();
                    }
                    else
                    {
                        WorkONo = "NA";
                    }
                    //For Department Name
                    int deptId = Convert.ToInt32(DSSql["DeptId"].ToString());

                    if (deptId > 0)
                    {
                        string sqlDeptName = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(DSSql["DeptId"].ToString()) + "' ");
                        SqlCommand cmdDeptName = new SqlCommand(sqlDeptName, con);
                        SqlDataReader DSDeptName = cmdDeptName.ExecuteReader();
                        DSDeptName.Read();

                        DeptName = DSDeptName["Dept"].ToString();
                    }
                    else
                    {
                        DeptName = "NA";
                    }

                    dr[10] = WorkONo;
                    dr[11] = DeptName;

                    dr[7] = fun.FromDateDMY(DSSql["DelDate"].ToString());

                    string stryr = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + DSSql["FinYearId"].ToString() + "'");
                    SqlCommand cmdyr = new SqlCommand(stryr, con);
                    SqlDataReader DSyr = cmdyr.ExecuteReader();
                    DSyr.Read();

                    dr[12] = DSyr["FinYear"].ToString();

                    dr[13] = Math.Round((Convert.ToDouble(decimal.Parse(DSSql["Qty"].ToString()).ToString("N3")) - RemQty), 5);
                    dr[14] = Convert.ToDouble(RemQty - RemTempQty);

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.LoadSPRData();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string sprno = ((Label)row.FindControl("lblsprno")).Text;
                string sprid = ((Label)row.FindControl("lblId")).Text;
                Response.Redirect("APO_SPR_ItemSelect.aspx?sprno=" + sprno + "&sprid=" + sprid + "&Code=" + SupCode + "&");

            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

}

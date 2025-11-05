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

public partial class Module_Inventory_Transactions_GoodsInwardNote_GIN_Edit_Details : System.Web.UI.Page
{
       clsFunctions fun = new clsFunctions();
    SqlConnection con;
    string connStr = "";
    string po = "";
    string ChNo = "";
    string GINNo = "";
    string ChDt = "";
    string fyid = "";
    int CompId = 0;
    string Sid = "";
    int FyId = 0;
    string supId = "";
    string GINId = "";
    string SessionFyId = "";



    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        try
        {
            con.Open();
            po = Request.QueryString["PoNo"].ToString();
            GINId = Request.QueryString["Id"].ToString();
            supId = Request.QueryString["SupId"].ToString();
            lblChallanNo.Text = Request.QueryString["ChNo"].ToString();
            ChNo = Request.QueryString["ChNo"].ToString();
            fyid = Request.QueryString["fyid"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            Sid = Session["username"].ToString();
            Lblgnno.Text = Request.QueryString["GNo"].ToString();
            GINNo = Request.QueryString["GNo"].ToString();
            LblChallanDate.Text = Request.QueryString["ChDt"].ToString();
            ChDt = fun.FromDate(LblChallanDate.Text);
            SessionFyId = Session["finyear"].ToString();
            TxtGDate.Attributes.Add("readonly", "readonly");
            string Strid = fun.select("FinYearId", "tblFinancial_master", "FinYear='" + fyid + "' AND CompId ='" + CompId + "'");
            SqlCommand cmdid = new SqlCommand(Strid, con);
            SqlDataAdapter daid = new SqlDataAdapter(cmdid);
            DataSet DSid = new DataSet();
            daid.Fill(DSid, "tblFinancial_master");
            if (DSid.Tables[0].Rows.Count > 0)
            {
                FyId = Convert.ToInt32(DSid.Tables[0].Rows[0]["FinYearId"]);
            }
            lblMessage.Text = "";

            if (!Page.IsPostBack)
            {
                this.loadData();

                string StrSql = fun.select("*", "tblInv_Inward_Master", " Id='" + GINId + "' And   FinYearId<='" + FyId + "' AND CompId='" + CompId + "' ");

                SqlCommand cmdsupId = new SqlCommand(StrSql, con);
                SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
                DataSet DSSql = new DataSet();
                DataTable dt = new DataTable();
                dasupId.Fill(DSSql);



                TxtGateentryNo.Text = DSSql.Tables[0].Rows[0]["GateEntryNo"].ToString();
                TxtGDate.Text = fun.FromDateDMY(DSSql.Tables[0].Rows[0]["GDate"].ToString());

                string TimeSel = DSSql.Tables[0].Rows[0]["GTime"].ToString();
                char[] delimiterChars = { ':', ' ' };
                string[] words = TimeSel.Split(delimiterChars);
                string TM = words[3];
                int H = Convert.ToInt32(words[0]);
                int M = Convert.ToInt32(words[1]);
                int S = Convert.ToInt32(words[2]);
                fun.TimeSelector(H, M, S, TM, TimeSelector1);
                TxtModeoftransport.Text = DSSql.Tables[0].Rows[0]["ModeofTransport"].ToString();
                TxtVehicleNo.Text = DSSql.Tables[0].Rows[0]["VehicleNo"].ToString();

            }
        }
        catch (Exception ex) { }

    }

    public void disableEdit()
    {
        try
        {

            foreach (GridViewRow grv in GridView1.Rows)
            {
                string id = ((Label)grv.FindControl("lblId")).Text;
                int PoId = Convert.ToInt32(((Label)grv.FindControl("lblPOId")).Text);

                string SqlGRRcheck = fun.select("tblinv_MaterialReceived_Details.Id", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + GINId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + PoId + "'");

                SqlCommand cmdGRRcheck = new SqlCommand(SqlGRRcheck, con);
                SqlDataAdapter daGRRcheck = new SqlDataAdapter(cmdGRRcheck);
                DataSet DSGRRcheck = new DataSet();
                DataTable dtGRRcheck = new DataTable();
                daGRRcheck.Fill(DSGRRcheck);

                string SqlGSNcheck = fun.select("tblinv_MaterialServiceNote_Details.Id", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "' AND tblinv_MaterialServiceNote_Details.POId='" + PoId + "'");

                SqlCommand cmdGSNcheck = new SqlCommand(SqlGSNcheck, con);
                SqlDataAdapter daGSNcheck = new SqlDataAdapter(cmdGSNcheck);
                DataSet DSGSNcheck = new DataSet();
                DataTable dtGSNcheck = new DataTable();
                daGSNcheck.Fill(DSGSNcheck);

                if (DSGRRcheck.Tables[0].Rows.Count == 0)
                {
                    ((Label)grv.FindControl("lblgrr")).Visible = false;

                }
                else
                {
                    ((Label)grv.FindControl("lblgrr")).Visible = true;

                }

                if (DSGSNcheck.Tables[0].Rows.Count == 0)
                {
                    ((Label)grv.FindControl("lblgsn")).Visible = false;
                }
                else
                {
                    ((Label)grv.FindControl("lblgsn")).Visible = true;
                }

                if (DSGRRcheck.Tables[0].Rows.Count > 0 || DSGSNcheck.Tables[0].Rows.Count > 0)
                {
                    ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;
                }
            }

        }
        catch (Exception ex)
        { }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoodsInwardNote_GIN_Edit.aspx?ModId=9&SubModId=37");
    }

    public void loadData()
    {

        try
        {
            string StrSql = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.Id,tblInv_Inward_Details.ACategoyId,tblInv_Inward_Details.ASubCategoyId,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.Qty,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.FinYearId<='" + SessionFyId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Details.GINId='" + GINId + "' Order by  tblInv_Inward_Master.Id Desc");


            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
            DataSet DSSql = new DataSet();
            DataTable dt = new DataTable();
            dasupId.Fill(DSSql);

            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));//0
            dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));//1
            dt.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));//2
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//3
            dt.Columns.Add(new System.Data.DataColumn("poqty", typeof(double)));//4
            dt.Columns.Add(new System.Data.DataColumn("RecedQty", typeof(double)));//5
            dt.Columns.Add(new System.Data.DataColumn("ChallanQty", typeof(double)));//6
            dt.Columns.Add(new System.Data.DataColumn("TotRecdQty", typeof(double)));//7
            dt.Columns.Add(new System.Data.DataColumn("POId", typeof(int)));//8
            dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));//9
            dt.Columns.Add(new System.Data.DataColumn("AttName", typeof(string)));//10
            dt.Columns.Add(new System.Data.DataColumn("ItemId", typeof(int)));//11

            dt.Columns.Add(new System.Data.DataColumn("Category", typeof(string)));//12
            dt.Columns.Add(new System.Data.DataColumn("SubCategory", typeof(string)));//13
            dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(string)));//14
            dt.Columns.Add(new System.Data.DataColumn("SubCategoryId", typeof(string)));//15
            dt.Columns.Add(new System.Data.DataColumn("AHId", typeof(string)));//16

            DataRow dr;
            string ItemCode = "";
            int Itemid = 0;
            string UOM = "";
            string Description = "";
            double poqty = 0;
            double RecedQty = 0;
            int ahid = 0;

            string WONO = string.Empty;
            string Dept = string.Empty;
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();
                // For PRNO    

                string StrSql2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + DSSql.Tables[0].Rows[i]["PONo"].ToString() + "' AND tblMM_PO_Master.FinYearId <='" + DSSql.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + DSSql.Tables[0].Rows[i]["CompId"].ToString() + "' AND tblMM_PO_Details.Id='" + DSSql.Tables[0].Rows[i]["POId"].ToString() + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");

                SqlCommand cmdsupId2 = new SqlCommand(StrSql2, con);
                SqlDataAdapter dasupId2 = new SqlDataAdapter(cmdsupId2);
                DataSet DSSql2 = new DataSet();
                dasupId2.Fill(DSSql2);

                if (DSSql2.Tables[0].Rows.Count > 0)
                {

                    if (DSSql2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
                    {
                        string StrFlag = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + DSSql2.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + DSSql2.Tables[0].Rows[0]["PRId"].ToString() + "' And tblMM_PR_Master.CompId='" + CompId + "'");

                        SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                        SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                        DataSet DSFlag = new DataSet();
                        daFlag.Fill(DSFlag);
                        if (DSFlag.Tables[0].Rows.Count > 0)
                        {
                            WONO = DSFlag.Tables[0].Rows[0]["WONo"].ToString();
                            Itemid = Convert.ToInt32(DSFlag.Tables[0].Rows[0]["ItemId"]);
                            string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + DSFlag.Tables[0].Rows[0]["ItemId"].ToString() + "'");
                            SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                            SqlDataAdapter daIcode = new SqlDataAdapter(cmdIcode);
                            DataSet DSIcode = new DataSet();
                            daIcode.Fill(DSIcode);
                            // For ItemCode
                            if (DSIcode.Tables[0].Rows.Count > 0)
                            {

                                if (DSIcode.Tables[0].Rows[0]["FileName"].ToString() != "" && DSIcode.Tables[0].Rows[0]["FileName"] != DBNull.Value)
                                {

                                    dr[9] = "View";

                                }

                                else
                                {
                                    dr[9] = "";
                                }


                                if (DSIcode.Tables[0].Rows[0]["AttName"].ToString() != "" && DSIcode.Tables[0].Rows[0]["AttName"] != DBNull.Value)
                                {

                                    dr[10] = "View";

                                }

                                else
                                {
                                    dr[10] = "";
                                }


                                ItemCode = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSFlag.Tables[0].Rows[0]["ItemId"].ToString()));

                                // For Manf. Desc
                                Description = DSIcode.Tables[0].Rows[0]["ManfDesc"].ToString();
                                // for UOM Purchase  from Unit Master table
                                string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
                                SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                                SqlDataAdapter daPurch = new SqlDataAdapter(cmdPurch);
                                DataSet DSPurch = new DataSet();
                                daPurch.Fill(DSPurch);
                                if (DSPurch.Tables[0].Rows.Count > 0)
                                {
                                    UOM = DSPurch.Tables[0].Rows[0][0].ToString();
                                }
                                ahid = Convert.ToInt32(DSFlag.Tables[0].Rows[0]["AHId"]);
                            }
                        }
                    }
                    else if (DSSql2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
                    {
                        string StrFlag1 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + DSSql2.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + DSSql2.Tables[0].Rows[0]["SPRId"].ToString() + "' And tblMM_SPR_Master.CompId='" + CompId + "'");

                        SqlCommand cmdFlag1 = new SqlCommand(StrFlag1, con);
                        SqlDataAdapter daFlag1 = new SqlDataAdapter(cmdFlag1);
                        DataSet DSFlag1 = new DataSet();
                        daFlag1.Fill(DSFlag1);
                        if (DSFlag1.Tables[0].Rows.Count > 0)
                        {
                            Itemid = Convert.ToInt32(DSFlag1.Tables[0].Rows[0]["ItemId"]);
                            string StrIcode1 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + DSFlag1.Tables[0].Rows[0]["ItemId"].ToString() + "'");
                            SqlCommand cmdIcode1 = new SqlCommand(StrIcode1, con);
                            SqlDataAdapter daIcode1 = new SqlDataAdapter(cmdIcode1);
                            DataSet DSIcode1 = new DataSet();
                            daIcode1.Fill(DSIcode1);
                            if (DSIcode1.Tables[0].Rows.Count > 0)
                            {


                                if (DSIcode1.Tables[0].Rows[0]["FileName"].ToString() != "" && DSIcode1.Tables[0].Rows[0]["FileName"] != DBNull.Value)
                                {
                                    dr[9] = "View";
                                }

                                else
                                {
                                    dr[9] = "";
                                }


                                if (DSIcode1.Tables[0].Rows[0]["AttName"].ToString() != "" && DSIcode1.Tables[0].Rows[0]["AttName"] != DBNull.Value)
                                {
                                    dr[10] = "View";
                                }

                                else
                                {
                                    dr[10] = "";
                                }

                                ItemCode = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSFlag1.Tables[0].Rows[0]["ItemId"].ToString()));

                                Description = DSIcode1.Tables[0].Rows[0]["ManfDesc"].ToString();

                                // for UOM Purchase  from Unit Master table
                                string sqlPurch1 = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode1.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
                                SqlCommand cmdPurch1 = new SqlCommand(sqlPurch1, con);
                                SqlDataAdapter daPurch1 = new SqlDataAdapter(cmdPurch1);
                                DataSet DSPurch1 = new DataSet();
                                daPurch1.Fill(DSPurch1);
                                if (DSPurch1.Tables[0].Rows.Count > 0)
                                {
                                    UOM = DSPurch1.Tables[0].Rows[0][0].ToString();
                                }
                                ahid = Convert.ToInt32(DSFlag1.Tables[0].Rows[0]["AHId"]);


                                if (DSFlag1.Tables[0].Rows[0]["WONo"] != DBNull.Value && DSFlag1.Tables[0].Rows[0]["WONo"].ToString() != string.Empty)
                                {
                                    WONO = DSFlag1.Tables[0].Rows[0]["WONo"].ToString();
                                }
                                else
                                {
                                    string StrDept = fun.select("Symbol", "BusinessGroup", "Id='" + DSFlag1.Tables[0].Rows[0]["DeptId"].ToString() + "'");
                                    SqlCommand cmdDept = new SqlCommand(StrDept, con);
                                    SqlDataAdapter daDept = new SqlDataAdapter(cmdDept);
                                    DataSet DSDept = new DataSet();
                                    daDept.Fill(DSDept);
                                    if (DSDept.Tables[0].Rows.Count > 0)
                                    {
                                        Dept = DSDept.Tables[0].Rows[0]["Symbol"].ToString();

                                    }
                                }
                            }
                        }
                    }
                    if (WONO != "")
                    {
                        LblWODept.Text = "WONO";
                        LblWONo.Text = WONO;
                    }
                    else
                    {
                        LblWODept.Text = "Bussiness Group";
                        LblWONo.Text = Dept;

                    }

                    // For ItemCode
                    dr[0] = ItemCode;

                    // For PurchDesc 
                    dr[1] = Description;

                    //For UOMPurch 
                    dr[2] = UOM;

                    //dr[3] = PurchDesc;

                    if (DSSql2.Tables[0].Rows[0]["Qty"] == DBNull.Value)
                    {
                        poqty = 0;
                    }
                    else
                    {
                        poqty = Convert.ToDouble(decimal.Parse((DSSql2.Tables[0].Rows[0]["Qty"]).ToString()).ToString("N3"));
                    }

                    dr[3] = Convert.ToInt32(DSSql.Tables[0].Rows[i]["Id"]);
                    dr[4] = poqty;
                    if (DSSql.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")
                    {
                        RecedQty = 0;
                    }
                    else
                    {
                        RecedQty = Convert.ToDouble(decimal.Parse((DSSql.Tables[0].Rows[i]["ReceivedQty"]).ToString()).ToString("N3"));
                    }
                    dr[5] = RecedQty;
                    dr[6] = Convert.ToDouble(decimal.Parse((DSSql.Tables[0].Rows[i]["Qty"]).ToString()).ToString("N3"));

                    string Str12 = fun.select("sum(tblInv_Inward_Details.ReceivedQty) as sum_ReceivedQty", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.PONo='" + po + "'  and tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo and tblInv_Inward_Details.POId='" + Convert.ToInt32(DSSql.Tables[0].Rows[i]["POId"]) + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.CompId='" + CompId + "'");

                    SqlCommand cmd12 = new SqlCommand(Str12, con);
                    SqlDataAdapter da12 = new SqlDataAdapter(cmd12);
                    DataSet DS12 = new DataSet();
                    da12.Fill(DS12);
                    double totrecqty;
                    if (DS12.Tables[0].Rows.Count > 0)
                    {
                        if (DS12.Tables[0].Rows[0]["sum_ReceivedQty"].ToString() == "")
                        {
                            totrecqty = 0;
                        }
                        else
                        {
                            totrecqty = Convert.ToDouble(decimal.Parse((DS12.Tables[0].Rows[0]["sum_ReceivedQty"]).ToString()).ToString("N3"));
                        }

                        dr[7] = totrecqty;
                        dr[8] = Convert.ToInt32(DSSql.Tables[0].Rows[i]["POId"]);
                        dr[11] = Itemid;
                    }


                    if (DSSql.Tables[0].Rows[i]["ACategoyId"].ToString() != "0" && DSSql.Tables[0].Rows[i]["ACategoyId"] != DBNull.Value)
                    {

                        string strCat = "select Abbrivation from tblACC_Asset_Category where Id='" + DSSql.Tables[0].Rows[i]["ACategoyId"].ToString() + "'";
                        SqlCommand cmdCat = new SqlCommand(strCat, con);
                        SqlDataReader rdrCat = cmdCat.ExecuteReader();
                        while (rdrCat.Read())
                        {
                            if (rdrCat.HasRows)
                            {
                                dr[12] = rdrCat["Abbrivation"].ToString();

                            }
                        }
                    }
                    else
                    {
                        dr[12] = "NA";
                    }

                    if (DSSql.Tables[0].Rows[i]["ASubCategoyId"].ToString() != "0" && DSSql.Tables[0].Rows[i]["ASubCategoyId"] != DBNull.Value)
                    {
                        string strSCat = "select Abbrivation from tblACC_Asset_SubCategory where Id='" + DSSql.Tables[0].Rows[i]["ASubCategoyId"].ToString() + "'";
                        SqlCommand cmdSCat = new SqlCommand(strSCat, con);
                        SqlDataReader rdrSCat = cmdSCat.ExecuteReader();
                        while (rdrSCat.Read())
                        {
                            if (rdrSCat.HasRows)
                            {
                                dr[13] = rdrSCat["Abbrivation"].ToString();
                            }
                        }
                    }
                    else
                    {
                        dr[13] = "NA";
                    }
                    //if (DSSql.Tables[0].Rows[i]["AssetNo"].ToString() != "0" && DSSql.Tables[0].Rows[i]["AssetNo"] != DBNull.Value)
                    //{
                    //    dr[14] = DSSql.Tables[0].Rows[i]["AssetNo"].ToString();
                    //}
                    //else
                    //{
                    //    dr[14] = "NA";
                    //}
                    dr[14] = DSSql.Tables[0].Rows[i]["ACategoyId"].ToString();
                    dr[15] = DSSql.Tables[0].Rows[i]["ASubCategoyId"].ToString();
                    dr[16] = ahid;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.disableEdit();
        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
        GridView1.EditIndex = -1;
        this.loadData();
        }
        catch (Exception ex) { }

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.loadData();
            int index = GridView1.EditIndex;
            GridViewRow grv = GridView1.Rows[index];
            DropDownList ddCategory = grv.FindControl("ddCategory") as DropDownList;
            DropDownList ddSubCategory = grv.FindControl("ddSubCategory") as DropDownList;
            string CategoryId = ((Label)grv.FindControl("lblCategoyId")).Text;
            string SubCategoryId = ((Label)grv.FindControl("lblSubCategoryId")).Text;
            string AHId = ((Label)grv.FindControl("lblAHId")).Text;

            if (AHId != "33")
            {
                ddCategory.Visible = false;
                ddSubCategory.Visible = false;
                ((Label)grv.FindControl("lblCategory1")).Text = "NA";
                ((Label)grv.FindControl("lblSubCategory1")).Text = "NA";
            }
            else
            {
                ((Label)grv.FindControl("lblCategory1")).Visible = false;
                ((Label)grv.FindControl("lblSubCategory1")).Visible = false;
            }
            ddCategory.SelectedValue = CategoryId;
            string cmdStrsubcat1 = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS SubCat", " tblACC_Asset_SubCategory ", "MId='" + ddCategory.SelectedValue + "'");
            SqlCommand cmdsubcat1 = new SqlCommand(cmdStrsubcat1, con);
            SqlDataAdapter DAsubcat1 = new SqlDataAdapter(cmdsubcat1);
            DataSet DSsubcat1 = new DataSet();
            DAsubcat1.Fill(DSsubcat1, "tblACC_Asset_SubCategory");
            ddSubCategory.DataSource = DSsubcat1;
            ddSubCategory.DataTextField = "SubCat";
            ddSubCategory.DataValueField = "Id";
            ddSubCategory.DataBind();
            ddSubCategory.Items.Insert(0, "Select");
            ddSubCategory.SelectedValue = SubCategoryId;

        }
        catch (Exception er) { }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();
            int p = 0;
            int q = 0;
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string AId = ((Label)row.FindControl("lblAHId")).Text;
            int ACategoyId = 0;
            if (((DropDownList)row.FindControl("ddCategory")).SelectedValue != "Select")
            {
                ACategoyId = Convert.ToInt32(((DropDownList)row.FindControl("ddCategory")).SelectedValue);
            }
            int ASubCategoyId = 0;
            if (((DropDownList)row.FindControl("ddSubCategory")).SelectedValue != "Select")
            {
                ASubCategoyId = Convert.ToInt32(((DropDownList)row.FindControl("ddSubCategory")).SelectedValue);
            }
            if (AId != "33")
            {
                p = 0;
            }
            if (AId == "33")
            {
                if (ACategoyId == 0 || ASubCategoyId == 0)
                {
                    q++;
                    p++;
                }
            }

            double poqty = 0;
            poqty = Convert.ToDouble(decimal.Parse((((Label)row.FindControl("lblPOQty")).Text).ToString()).ToString("N3"));
            double InvQty = 0;
            InvQty = Convert.ToDouble(decimal.Parse((((TextBox)row.FindControl("TxtChallanQty")).Text).ToString()).ToString("N3"));
            double RecvQty = 0;
            RecvQty = Convert.ToDouble(decimal.Parse((((TextBox)row.FindControl("TxtRecedQty")).Text).ToString()).ToString("N3"));
            double Challanqty = 0;
            Challanqty = Convert.ToDouble(decimal.Parse((((Label)row.FindControl("lblChnQty")).Text).ToString()).ToString("N3"));
            double recdqty = 0;
            recdqty = Convert.ToDouble(decimal.Parse((((Label)row.FindControl("lblRecQty")).Text).ToString()).ToString());

            if (TxtGateentryNo.Text != "" && TxtModeoftransport.Text != "" && TxtVehicleNo.Text != "" && fun.DateValidation(TxtGDate.Text) == true && TxtGDate.Text != "" && fun.DateValidation(fun.FromDateDMY(ChDt)) == true)
            {
                if (InvQty <= Challanqty && RecvQty <= recdqty && fun.NumberValidationQty(((TextBox)row.FindControl("TxtChallanQty")).Text) == true && fun.NumberValidationQty(((TextBox)row.FindControl("TxtRecedQty")).Text) == true && p == 0 && q == 0)
                {

                    string TimeSelector = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm.ToString();

                    string upd = fun.update("tblInv_Inward_Master", "SysDate='" + CDate + "' ,SysTime='" + CTime + "',SessionId='" + sId + "',ChallanNo='" + ChNo + "',ChallanDate='" + ChDt + "',GateEntryNo='" + TxtGateentryNo.Text + "',GDate='" + fun.FromDate(TxtGDate.Text) + "',GTime='" + TimeSelector + "',ModeofTransport='" + TxtModeoftransport.Text + "',VehicleNo='" + TxtVehicleNo.Text + "'", "CompId='" + CompId + "'  AND  FinYearId='" + FyId + "' AND GINNo='" + GINNo + "'");
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();

                    //string AssetNo = string.Empty;
                    if (AId == "33")
                    {
                        string getAId1 = fun.select("ACategoyId,ASubCategoyId", "tblInv_Inward_Details", "Id='" + id + "' AND GINNo='" + GINNo + "'");
                        SqlCommand cmdAId1 = new SqlCommand(getAId1, con);
                        SqlDataAdapter DAAId1 = new SqlDataAdapter(cmdAId1);
                        DataSet DSAId1 = new DataSet();
                        DAAId1.Fill(DSAId1, "tblInv_Inward_Master");
                        if (DSAId1.Tables[0].Rows.Count > 0)
                        {
                            if (DSAId1.Tables[0].Rows[0]["ACategoyId"].ToString() == ACategoyId.ToString() && DSAId1.Tables[0].Rows[0]["ASubCategoyId"].ToString() == ASubCategoyId.ToString())
                            {

                                ACategoyId = Convert.ToInt32(DSAId1.Tables[0].Rows[0]["ACategoyId"]);
                                ASubCategoyId = Convert.ToInt32(DSAId1.Tables[0].Rows[0]["ASubCategoyId"]);
                               // AssetNo = DSAId1.Tables[0].Rows[0]["AssetNo"].ToString();
                            }
                            //else
                            //{

                            //    string getAId = fun.select("AssetNo", "tblInv_Inward_Details", "ACategoyId='" + ACategoyId + "' And ASubCategoyId='" + ASubCategoyId + "' Order by Id Desc");
                            //    SqlCommand cmdAId = new SqlCommand(getAId, con);
                            //    SqlDataAdapter DAAId = new SqlDataAdapter(cmdAId);
                            //    DataSet DSAId = new DataSet();
                            //    DAAId.Fill(DSAId, "tblInv_Inward_Master");
                            //    if (DSAId.Tables[0].Rows.Count > 0)
                            //    {
                            //        int incstr = Convert.ToInt32(DSAId.Tables[0].Rows[0]["AssetNo"].ToString()) + 1;
                            //        AssetNo = incstr.ToString("D4");
                            //    }
                            //    else
                            //    {
                            //        AssetNo = "0001";
                            //    }

                            //}
                        }
                    }
                    //else
                    //{
                    //    AssetNo = "0";
                    //}

                    string upd1 = fun.update("tblInv_Inward_Details", "Qty='" + decimal.Parse(InvQty.ToString()).ToString("N3") + "',ReceivedQty='" + decimal.Parse(RecvQty.ToString()).ToString("N3") + "',ACategoyId='" + ACategoyId + "',ASubCategoyId='" + ASubCategoyId + "'", "Id='" + id + "' AND GINNo='" + GINNo + "' ");
                    SqlCommand cmd2 = new SqlCommand(upd1, con);
                    cmd2.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    this.loadData();
                }
                else
                {
                    string myStringVariable = string.Empty;

                    if (p > 0 || q > 0)
                    {
                        myStringVariable = "Please Select Category and Subcategory of Asset.";
                    }
                    else
                    {
                        myStringVariable = "Entered qty is exceed the limit!";
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Invalid data.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }

        catch (Exception ex) { }
    }  
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[0].Controls[0];
                del.Attributes.Add("onclick", "return confirmationUpdate();");
            }
        }
       catch(Exception ex) {}

    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated Sucessfully!";
    }

    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.loadData();
        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "downloadImg")
            {

                foreach (GridViewRow grv in GridView1.Rows)
                {

                    int itemid = Convert.ToInt32(((Label)grv.FindControl("lblItemId")).Text);

                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
                }
            }


            if (e.CommandName == "downloadSpec")
            {
                foreach (GridViewRow grv in GridView1.Rows)
                {

                    int itemid = Convert.ToInt32(((Label)grv.FindControl("lblItemId")).Text);
                    Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemid + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
                }
            }
        }
        catch (Exception ex)
        {
        }


    }

    protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            DropDownList dd2 = (DropDownList)sender;
            GridViewRow row2 = (GridViewRow)dd2.Parent.Parent;
            DropDownList ddCategory = ((DropDownList)row2.FindControl("ddCategory"));
            DropDownList ddSubCategory = (DropDownList)row.FindControl("ddSubCategory");
            string cmdStrsubcat = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS SubCat", " tblACC_Asset_SubCategory ", "MId='" + ddCategory.SelectedValue + "'");
            SqlCommand cmdsubcat = new SqlCommand(cmdStrsubcat, con);
            SqlDataAdapter DAsubcat = new SqlDataAdapter(cmdsubcat);
            DataSet DSsubcat = new DataSet();
            DAsubcat.Fill(DSsubcat, "tblACC_Asset_SubCategory");
            ddSubCategory.DataSource = DSsubcat;
            ddSubCategory.DataTextField = "SubCat";
            ddSubCategory.DataValueField = "Id";
            ddSubCategory.DataBind();
            ddSubCategory.Items.Insert(0, "Select");
        }
        catch(Exception ex){}

    }
}
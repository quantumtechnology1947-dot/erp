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

public partial class Module_Accounts_Transactions_BillBooking_ItemGrid : System.Web.UI.Page
{  
    clsFunctions fun = new clsFunctions();
    string SId = "";
    int CompId = 0;
    string PId = "";
    string SupplierNo = "";
    double FGT = 0;
    int FyId = 0;
    double GQNTotalAmount = 0;
    double GSNTotalAmount = 0;
    int DrpValue = 0;
    string TxtValue = string.Empty;
    int ST = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
       
        try
        {
            SupplierNo = Request.QueryString["SUPId"].ToString();
            FGT = Convert.ToDouble(decimal.Parse(Request.QueryString["FGT"]).ToString("N3"));
            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Request.QueryString["FyId"].ToString());
            ST = Convert.ToInt32(Request.QueryString["ST"]);

            con.Open();

            if (!Page.IsPostBack)
            {
                string cmdStrLabour = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", "AccHead ","Id!=0");
                SqlCommand cmdLabour = new SqlCommand(cmdStrLabour, con);
                SqlDataAdapter DALabour = new SqlDataAdapter(cmdLabour);
                DataSet DSLabour = new DataSet();
                DALabour.Fill(DSLabour, "AccHead");

                DropACHeadGqn.DataSource = DSLabour;
                DropACHeadGqn.DataTextField = "Head";
                DropACHeadGqn.DataValueField = "Id";
                DropACHeadGqn.DataBind();
                DropACHeadGqn.Items.Insert(0, "Select");


                string cmdStrLabour1 = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", "AccHead ", "Id!=0");
                SqlCommand cmdLabour1 = new SqlCommand(cmdStrLabour1, con);
                SqlDataAdapter DALabour1 = new SqlDataAdapter(cmdLabour1);
                DataSet DSLabour1 = new DataSet();
                DALabour1.Fill(DSLabour1, "AccHead");

                DropACHeadGsn.DataSource = DSLabour1;
                DropACHeadGsn.DataTextField = "Head";
                DropACHeadGsn.DataValueField = "Id";
                DropACHeadGsn.DataBind();
                DropACHeadGsn.Items.Insert(0, "Select");

                this.loadDataGQN(DrpValue,TxtValue);
                this.loadDataGSN(DrpValue,TxtValue);
            }

            foreach (GridViewRow grv in GridView2.Rows)
            {
                GQNTotalAmount += Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblGQNAmt")).Text).ToString("N3"));
            }

            foreach (GridViewRow grv in GridView1.Rows)
            {
                GSNTotalAmount += Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblGSNAmt")).Text).ToString("N3"));
            }

            lblGqnTotal.Text = GQNTotalAmount.ToString();
            lblGSNTotal.Text = GSNTotalAmount.ToString();

            

            //TabContainer1.OnClientActiveTabChanged = "OnChanged";
            //TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");

        }
        catch (Exception ex) { }
    }

    //-----------------------------------GQN-------------------------------------------------
    
    public void loadDataGQN(int DrpValue, string TxtValue)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();        
        con.Open();
        
       try
        {
            string param = string.Empty;
            string param2 = string.Empty;
            int s = 0;

            switch(DrpValue)
            {
                case 1://DC No
                    param = " AND tblInv_Inward_Master.ChallanNo like '" + TxtValue + "%'";
                    break;

                case 2://GQN No
                    param = " AND tblQc_MaterialQuality_Master.GQNNo='" + TxtValue + "'";
                    break;

                case 3://PO No
                    param = " AND tblMM_PO_Master.PONo='" + TxtValue + "'";
                    break;

                case 4://Item Code
                    param2 = " AND tblDG_Item_Master.ItemCode like '" + TxtValue + "%'";
                    break;
                case 5://Description
                    param2 = " AND tblDG_Item_Master.ManfDesc like '%" + TxtValue + "%'";
                    break;

                case 6://AC Head
                    
                    if (DropACHeadGqn.SelectedValue != "Select")
                    {
                        s = 1;                        
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Please select AC Head.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                    break;           

            }

            string StrSql = fun.select("tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Details.Id,tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Details.AcceptedQty,tblQc_MaterialQuality_Details.Id As GQNId,tblQc_MaterialQuality_Master.GQNNo", "tblMM_PO_Details,tblMM_PO_Master,tblInv_Inward_Details,tblInv_Inward_Master,tblinv_MaterialReceived_Details,tblinv_MaterialReceived_Master,tblQc_MaterialQuality_Details,tblQc_MaterialQuality_Master,tblMM_Supplier_master",
    "tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblMM_PO_Master.PONo=tblInv_Inward_Master.PONo AND tblInv_Inward_Details.POId=tblMM_PO_Details.Id AND tblInv_Inward_Master.GINNo=tblinv_MaterialReceived_Master.GINNo AND tblInv_Inward_Master.Id=tblinv_MaterialReceived_Master.GINId AND tblInv_Inward_Details.POId=tblinv_MaterialReceived_Details.POId AND tblinv_MaterialReceived_Master.Id=tblQc_MaterialQuality_Master.GRRId AND tblinv_MaterialReceived_Master.GRRNo=tblQc_MaterialQuality_Master.GRRNO AND tblinv_MaterialReceived_Details.Id=tblQc_MaterialQuality_Details.GRRId AND tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblMM_Supplier_master.SupplierId=tblMM_PO_Master.SupplierId AND  tblMM_Supplier_master.SupplierId='" + SupplierNo + "' AND tblMM_PO_Master.FinYearId='10' "+param);

            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataReader DSSql = cmdsupId.ExecuteReader();

            dt.Columns.Add(new System.Data.DataColumn("ChallanNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChallanDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ACHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GQNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Total", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("AcceptedQty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GQNAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GQNId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYrs", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ACId", typeof(int)));
            DataRow dr;

            string ItemCode = "";
            string PurchDesc = "";
            string UomPurch = "";
            string ACHead = "";

            while(DSSql.Read())
            {
                dr = dt.NewRow();

                string ItemId = "";
                int ACId =0;         

                if (DSSql["PRSPRFlag"].ToString() == "0")
                {
                    string AcHeadSearchPR = "";

                    if(s==1)
                    {
                        AcHeadSearchPR = " AND tblMM_PR_Details.AHId='" + TxtValue + "'";
                    }

                    string StrFlag = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + DSSql["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + DSSql["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'" + AcHeadSearchPR);
                    SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                    SqlDataReader rdrFlag = cmdFlag.ExecuteReader();
                    rdrFlag.Read();

                    if (rdrFlag.HasRows==true)
                    {
                        string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + rdrFlag["ItemId"].ToString() + "' AND CompId='" + CompId + "'" + param2);

                        SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                        SqlDataReader rdrIcode = cmdIcode.ExecuteReader();
                        rdrIcode.Read();

                        // For ItemCode
                        if (rdrIcode.HasRows == true)
                        {
                            ItemCode = rdrIcode["ItemCode"].ToString();
                            // For Purch Desc
                            PurchDesc = rdrIcode["ManfDesc"].ToString();

                            // for UOM Purchase  from Unit Master table
                            string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + rdrIcode["UOMBasic"].ToString() + "'");
                            SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                            SqlDataReader rdrPurch = cmdPurch.ExecuteReader();
                            rdrPurch.Read();

                            //if (DSPurch.Tables[0].Rows.Count > 0)
                            {
                                UomPurch = rdrPurch[0].ToString();
                            }

                            ItemId = rdrFlag["ItemId"].ToString();
                            ACId = Convert.ToInt32(rdrFlag["AHId"].ToString());

                            string StrAcCat = fun.select("Symbol", " AccHead ", "Id='" + rdrFlag["AHId"].ToString() + "'");
                            SqlCommand cmdAc = new SqlCommand(StrAcCat, con);
                            SqlDataAdapter DAAc = new SqlDataAdapter(cmdAc);
                            DataSet DSAc = new DataSet();
                            DAAc.Fill(DSAc);
                            if (DSAc.Tables[0].Rows.Count > 0)
                            {
                                ACHead = DSAc.Tables[0].Rows[0]["Symbol"].ToString();
                            }

                        }
                    }
                }

                else if (DSSql["PRSPRFlag"].ToString() == "1")
                {
                    string AcHeadSearchSPR = "";

                    if (s == 1)
                    {
                        AcHeadSearchSPR = " AND tblMM_SPR_Details.AHId='" + TxtValue + "'";
                    }

                    string StrFlag1 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + DSSql["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + DSSql["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'" + AcHeadSearchSPR);

                    SqlCommand cmdFlag1 = new SqlCommand(StrFlag1, con);
                    SqlDataReader rdrFlag1 = cmdFlag1.ExecuteReader();
                    rdrFlag1.Read();

                    if (rdrFlag1.HasRows==true)
                    {
                        string StrIcode1 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + rdrFlag1["ItemId"].ToString() + "'" + param2);
                        SqlCommand cmdIcode1 = new SqlCommand(StrIcode1, con);
                        SqlDataReader rdrIcode1 = cmdIcode1.ExecuteReader();
                        rdrIcode1.Read();

                        if (rdrIcode1.HasRows == true)
                        {
                            ItemCode = rdrIcode1["ItemCode"].ToString();

                            // for UOM Purchase from Unit Master table
                            PurchDesc = rdrIcode1["ManfDesc"].ToString();

                            string sqlPurch1 = fun.select("Symbol", "Unit_Master", "Id='" + rdrIcode1["UOMBasic"].ToString() + "' ");
                            SqlCommand cmdPurch1 = new SqlCommand(sqlPurch1, con);
                            SqlDataReader rdrPurch1 = cmdPurch1.ExecuteReader();
                            rdrPurch1.Read();

                            //if (DSPurch1.Tables[0].Rows.Count > 0)
                            {
                                UomPurch = rdrPurch1[0].ToString();
                            }
                            ItemId = rdrFlag1["ItemId"].ToString();
                            ACId = Convert.ToInt32(rdrFlag1["AHId"].ToString());

                            string StrcmdAcCat1 = fun.select("Symbol", " AccHead ", "Id='" + rdrFlag1["AHId"].ToString() + "'");
                            SqlCommand cmdAcCat1 = new SqlCommand(StrcmdAcCat1, con);
                            SqlDataAdapter DAAcCat1 = new SqlDataAdapter(cmdAcCat1);
                            DataSet DSAcCat1 = new DataSet();
                            DAAcCat1.Fill(DSAcCat1);
                            if (DSAcCat1.Tables[0].Rows.Count > 0)
                            {
                                ACHead = DSAcCat1.Tables[0].Rows[0]["Symbol"].ToString();
                            }
                        }
                    }
                }

                //For checked temp.

                string sqltemp = fun.select("GQNId", "tblACC_BillBooking_Details_Temp", "ItemId='" + ItemId + "' AND GQNId='" + DSSql["GQNId"].ToString() + "' AND CompId='" + CompId + "'");
                SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                SqlDataReader DStemp = cmdtemp.ExecuteReader();
                DStemp.Read();               
               
                string sqltemp1 = fun.select("tblACC_BillBooking_Details.GQNId", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", " tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Details.ItemId='" + ItemId + "' AND tblACC_BillBooking_Details.GQNId='" + DSSql["GQNId"].ToString() + "' AND tblACC_BillBooking_Master.CompId='" + CompId + "'");
                
                SqlCommand cmdtemp1 = new SqlCommand(sqltemp1, con);
                SqlDataReader DStemp1 = cmdtemp1.ExecuteReader();
                DStemp1.Read();
                
                if (DStemp.HasRows == false && DStemp1.HasRows == false && ItemId != "")
                {                   
                    double rate = 0;
                    double dis = 0;
                    double poqty = 0;
                    double actqty = 0;
                    double amt = 0;
                    double poamt = 0;

                    rate = Convert.ToDouble(decimal.Parse((DSSql["Rate"]).ToString()).ToString("N2"));
                    dis = Convert.ToDouble(decimal.Parse((DSSql["Discount"]).ToString()).ToString("N2"));
                    poqty = Convert.ToDouble(decimal.Parse((DSSql["Qty"]).ToString()).ToString("N3"));
                    actqty = Convert.ToDouble(decimal.Parse((DSSql["AcceptedQty"]).ToString()).ToString("N3"));

                    dr[0] = DSSql["ChallanNo"].ToString();
                    dr[1] = fun.FromDateDMY(DSSql["ChallanDate"].ToString());
                    dr[2] = ItemCode;
                    dr[3] = PurchDesc;
                    dr[4] = UomPurch;
                    dr[5] = ACHead;
                    dr[6] = Convert.ToDouble(decimal.Parse((DSSql["Qty"]).ToString()).ToString("N3"));
                    dr[7] = Convert.ToDouble(decimal.Parse((DSSql["Rate"]).ToString()).ToString("N2"));
                    dr[8] = Convert.ToDouble(decimal.Parse((DSSql["Discount"]).ToString()).ToString("N2"));

                    amt = Convert.ToDouble(decimal.Parse(((rate - (rate * dis) / 100) * actqty).ToString()).ToString("N2"));
                    poamt = Convert.ToDouble(decimal.Parse(((rate - (rate * dis) / 100) * poqty).ToString()).ToString("N2"));
                    dr[9] = DSSql["GQNNo"].ToString();
                    dr[10] = poamt;
                    dr[11] = Convert.ToDouble(decimal.Parse((DSSql["AcceptedQty"]).ToString()).ToString("N3"));
                    dr[12] = amt;
                    dr[13] = DSSql["GQNId"].ToString();
                    dr[14] = DSSql["Id"].ToString();
                    
                    string sqlfin = fun.select("*", "tblFinancial_master", "FinYearId='" + DSSql["FinYearId"].ToString() + "' AND CompId='"+CompId+"'");
                    SqlCommand cmdfin = new SqlCommand(sqlfin, con);
                    SqlDataReader DSfin = cmdfin.ExecuteReader();
                    DSfin.Read();
                
                    dr[15] = DSfin["FinYear"].ToString();
                    dr[16] = DSSql["PONo"].ToString();
                    dr[17] = fun.FromDateDMY(DSSql["SysDate"].ToString());
                    dr[18] = ACId;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
       catch (Exception ex) { }
    }
     
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.loadDataGQN(DrpValue, TxtValue);
        }
        catch (Exception ex) { }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            if (e.CommandName == "sel")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string GSNId = "0";
                string GQNId = ((Label)row.FindControl("lblgqnId")).Text;
                string POId = ((Label)row.FindControl("lblPoId")).Text;
                //string GQNAmt = ((Label)row.FindControl("lblGQNAmt")).Text;
                string GQNAmt = ((Label)row.FindControl("lblGQNAmt")).Text;
                string GQNQty = ((Label)row.FindControl("lblAcptQty")).Text;
                double GSNAmt = 0;
                string GSNQty = "0";
                int ACId =Convert.ToInt32(((Label)row.FindControl("lblACId")).Text);
                //ACHead
                string StrACHead = fun.select("ACHead", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' And CompId='" + CompId + "'");
                SqlCommand cmdACHead = new SqlCommand(StrACHead, con);
                SqlDataAdapter daACHead = new SqlDataAdapter(cmdACHead);
                DataSet DSACHead = new DataSet();
                daACHead.Fill(DSACHead);
                if (DSACHead.Tables[0].Rows.Count == 0 || DSACHead.Tables[0].Rows.Count > 0 && Convert.ToInt32(DSACHead.Tables[0].Rows[0]["ACHead"]) == ACId)
                {
                    Response.Redirect("BillBooking_Item_Details.aspx?SUPId=" + SupplierNo + "&GSNQty=" + GSNQty + "&GSNAmt=" + GSNAmt + "&FGT=" + FGT + "&PoId=" + POId + "&GQNAmt=" + GQNAmt + "&GQNQty=" + GQNQty + "&GQNId=" + GQNId + "&GSNId=" + GSNId + "&FYId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "AC Head is not match.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }

            }
        }
        catch (Exception ex) { }
    }
        
   //-----------------------------------GSN-------------------------------------------------
    
    public void loadDataGSN(int DrpValue, string TxtValue)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
        con.Open();

        try
        {

            string param = string.Empty;
            string param2 = string.Empty;
            int g = 0;
            switch (DrpValue)
            {
                case 1://DC No
                    param = " AND tblInv_Inward_Master.ChallanNo like '" + TxtValue + "%'";
                    break;

                case 2://GQN No
                    param = " AND tblinv_MaterialServiceNote_Master.GSNNo='" + TxtValue + "'";
                    break;

                case 3://PO No
                    param = " AND tblMM_PO_Master.PONo='" + TxtValue + "'";
                    break;

                case 4://Item Code
                    param2 = " AND tblDG_Item_Master.ItemCode like '" + TxtValue + "%'";
                    break;
                case 5://Description
                    param2 = " AND tblDG_Item_Master.ManfDesc like '%" + TxtValue + "%'";
                    break;

                case 6://AC Head

                    if (DropACHeadGsn.SelectedValue != "Select")
                    {
                        g = 1;
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Please select AC Head.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                    break; 
            }

            string sqlGsn = fun.select("tblMM_PO_Master.FinYearId,tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate,tblMM_PO_Details.Id,tblMM_PO_Details.PRId,tblMM_PO_Details.PRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblInv_Inward_Master.ChallanNo,tblInv_Inward_Master.ChallanDate,tblinv_MaterialServiceNote_Details.ReceivedQty,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.Id As GSNId", "tblMM_PO_Details,tblMM_PO_Master,tblInv_Inward_Details,tblInv_Inward_Master,tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details,tblMM_Supplier_master", "tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblinv_MaterialServiceNote_Master.Id =tblinv_MaterialServiceNote_Details.MId AND tblMM_PO_Master.PONo=tblInv_Inward_Master.PONo AND tblInv_Inward_Details.POId=tblMM_PO_Details.Id AND tblInv_Inward_Master.Id=tblinv_MaterialServiceNote_Master.GINId AND tblInv_Inward_Master.GINNo=tblinv_MaterialServiceNote_Master.GINNo AND tblInv_Inward_Details.POId=tblinv_MaterialServiceNote_Details.POId AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblMM_Supplier_master.SupplierId=tblMM_PO_Master.SupplierId AND  tblMM_Supplier_master.SupplierId='" + SupplierNo + "' AND tblMM_PO_Master.FinYearId<='" + FyId + "'" + param);
           
            SqlCommand cmdGsn = new SqlCommand(sqlGsn, con);
            SqlDataReader DSGsn = cmdGsn.ExecuteReader();
            
            dt.Columns.Add(new System.Data.DataColumn("ChallanNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ChallanDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ACHead1", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GSNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Total", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ReceivedQty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GSNAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GSNId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYrs1", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo1", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date1", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ACId1", typeof(int)));
            DataRow dr;
            
            string ItemCode = "";
            string PurchDesc = "";
            string UomPurch = "";
            string ACHead1 = "";
            int PoId = 0;
            
            while(DSGsn.Read())
            {
                dr = dt.NewRow();

                string ItemId = "";
                int ACId = 0;
                if (DSGsn["PRSPRFlag"].ToString() == "0")
                {

                    string AcHeadSearchPRGsn = "";

                    if (g == 1)
                    {
                        AcHeadSearchPRGsn = " AND tblMM_PR_Details.AHId='" + TxtValue + "'";
                    }

                    string StrFlag = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + DSGsn["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + DSGsn["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'" + AcHeadSearchPRGsn);
                    SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                    SqlDataReader DSFlag = cmdFlag.ExecuteReader();
                    DSFlag.Read();
                    if (DSFlag.HasRows == true)
                    {
                        string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + DSFlag["ItemId"].ToString() + "' AND CompId='" + CompId + "'" + param2);
                        SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                        SqlDataReader DSIcode = cmdIcode.ExecuteReader();
                        DSIcode.Read();

                        //For ItemCode

                        if (DSIcode.HasRows == true)
                        {
                            ItemCode = DSIcode["ItemCode"].ToString();
                            // For Purch Desc
                            PurchDesc = DSIcode["ManfDesc"].ToString();
                            // for UOM Purchase  from Unit Master table
                            string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode["UOMBasic"].ToString() + "'");
                            SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                            SqlDataReader DSPurch = cmdPurch.ExecuteReader();
                            DSPurch.Read();

                            //if (DSPurch.Tables[0].Rows.Count > 0)
                            {
                                UomPurch = DSPurch[0].ToString();
                            }

                            ItemId = DSFlag["ItemId"].ToString();
                            ACId = Convert.ToInt32(DSFlag["AHId"].ToString());                          

                            string StrcmdAcCat = fun.select("Symbol", " AccHead ", "Id='" + DSFlag["AHId"].ToString() + "'");
                            SqlCommand cmdAcCat = new SqlCommand(StrcmdAcCat, con);
                            SqlDataAdapter DAAcCat = new SqlDataAdapter(cmdAcCat);
                            DataSet DSAcCat = new DataSet();
                            DAAcCat.Fill(DSAcCat);
                            if (DSAcCat.Tables[0].Rows.Count > 0)
                            {
                                ACHead1 = DSAcCat.Tables[0].Rows[0]["Symbol"].ToString();
                            }
                        }
                    }
                }

                else if (DSGsn["PRSPRFlag"].ToString() == "1")
                {

                    string AcHeadSearchSPRGsn = "";

                    if (g == 1)
                    {
                        AcHeadSearchSPRGsn = " AND tblMM_SPR_Details.AHId='" + TxtValue + "'";
                    }
                    string StrFlag1 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + DSGsn["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + DSGsn["SPRId"].ToString() + "'  AND  tblMM_SPR_Master.CompId='" + CompId + "'" + AcHeadSearchSPRGsn);

                    SqlCommand cmdFlag1 = new SqlCommand(StrFlag1, con);
                    SqlDataReader DSFlag1 = cmdFlag1.ExecuteReader();
                    DSFlag1.Read();


                    if (DSFlag1.HasRows == true)
                    {
                        string StrIcode1 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + DSFlag1["ItemId"].ToString() + "'" + param2);
                        SqlCommand cmdIcode1 = new SqlCommand(StrIcode1, con);
                        SqlDataReader DSIcode1 = cmdIcode1.ExecuteReader();
                        DSIcode1.Read();

                        if (DSIcode1.HasRows == true)
                        {
                            ItemCode = DSIcode1["ItemCode"].ToString();
                            PurchDesc = DSIcode1["ManfDesc"].ToString();

                            // for UOM Purchase from Unit Master table
                            string sqlPurch1 = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode1["UOMBasic"].ToString() + "' ");
                            SqlCommand cmdPurch1 = new SqlCommand(sqlPurch1, con);
                            SqlDataReader DSPurch1 = cmdPurch1.ExecuteReader();
                            DSPurch1.Read();

                            //if (DSPurch1.Tables[0].Rows.Count > 0)
                            {
                                UomPurch = DSPurch1[0].ToString();
                            }

                            ItemId = DSFlag1["ItemId"].ToString();
                            ACId = Convert.ToInt32(DSFlag1["AHId"].ToString()); 

                            string StrcmdAcCat1 = fun.select("Symbol", " AccHead ", "Id='" + DSFlag1["AHId"].ToString() + "'");
                            SqlCommand cmdAcCat1 = new SqlCommand(StrcmdAcCat1, con);
                            SqlDataAdapter DAAcCat1 = new SqlDataAdapter(cmdAcCat1);
                            DataSet DSAcCat1 = new DataSet();
                            DAAcCat1.Fill(DSAcCat1);
                            if (DSAcCat1.Tables[0].Rows.Count > 0)
                            {
                                ACHead1 = DSAcCat1.Tables[0].Rows[0]["Symbol"].ToString();
                            }

                        }
                    }
                }

                //For checked temp.

                string sqltemp = fun.select("GSNId", "tblACC_BillBooking_Details_Temp", "ItemId='" + ItemId + "' AND GSNId='" + DSGsn["GSNId"].ToString() + "' AND CompId='" + CompId + "'");
                SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                SqlDataReader DStemp = cmdtemp.ExecuteReader();
                DStemp.Read();
                
                string sqltemp1 = fun.select("tblACC_BillBooking_Details.GSNId", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", " tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Details.ItemId='" + ItemId + "' AND tblACC_BillBooking_Details.GSNId='" + DSGsn["GSNId"].ToString() + "' AND tblACC_BillBooking_Master.CompId='" + CompId + "'");
                SqlCommand cmdtemp1 = new SqlCommand(sqltemp1, con);
                SqlDataReader DStemp1 = cmdtemp1.ExecuteReader();
                DStemp1.Read();

                if (DStemp.HasRows ==  false && DStemp1.HasRows == false && ItemId!="")
                {
                    double rate = 0;
                    double dis = 0;
                    double poqty = 0;
                    double actqty = 0;
                    double amt = 0;
                    double poamt = 0;

                    rate = Convert.ToDouble(decimal.Parse((DSGsn["Rate"]).ToString()).ToString("N2"));
                    dis = Convert.ToDouble(decimal.Parse((DSGsn["Discount"]).ToString()).ToString("N2"));
                    poqty = Convert.ToDouble(decimal.Parse((DSGsn["Qty"]).ToString()).ToString("N3"));
                    actqty = Convert.ToDouble(decimal.Parse((DSGsn["ReceivedQty"]).ToString()).ToString("N3"));
                    dr[0] = DSGsn["ChallanNo"].ToString();
                    dr[1] = fun.FromDateDMY(DSGsn["ChallanDate"].ToString());
                    dr[2] = ItemCode;
                    dr[3] = PurchDesc;
                    dr[4] = UomPurch;
                    dr[5] = ACHead1;
                    dr[6] = Convert.ToDouble(decimal.Parse((DSGsn["Qty"]).ToString()).ToString("N3"));
                    dr[7] = Convert.ToDouble(decimal.Parse((DSGsn["Rate"]).ToString()).ToString("N2"));
                    dr[8] = Convert.ToDouble(decimal.Parse((DSGsn["Discount"]).ToString()).ToString("N2"));
                    amt = Convert.ToDouble(decimal.Parse(((rate - (rate * dis) / 100) * actqty).ToString()).ToString("N2"));
                    poamt = Convert.ToDouble(decimal.Parse(((rate - (rate * dis) / 100) * poqty).ToString()).ToString("N2"));
                    dr[9] = DSGsn["GSNNo"].ToString();
                    dr[10] = poamt;
                    dr[11] = Convert.ToDouble(decimal.Parse((DSGsn["ReceivedQty"]).ToString()).ToString("N3"));
                    dr[12] = amt;
                    dr[13] = DSGsn["GSNId"].ToString();
                    dr[14] = DSGsn["Id"].ToString();

                    string sqlfin = fun.select("*", "tblFinancial_master", "FinYearId='" + DSGsn["FinYearId"].ToString() + "' AND CompId='" + CompId + "'");
                    SqlCommand cmdfin = new SqlCommand(sqlfin, con);
                    SqlDataReader rdrfin = cmdfin.ExecuteReader();
                    rdrfin.Read();

                    dr[15] = rdrfin["FinYear"].ToString();
                    dr[16] = DSGsn["PONo"].ToString();
                    dr[17] = fun.FromDateDMY(DSGsn["SysDate"].ToString());
                    dr[18] = ACId;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch(Exception ex){}
       
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            if (e.CommandName == "sel")
            {

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string GQNId = "0";
                string GSNId = ((Label)row.FindControl("lblgsnId")).Text;
                string POId = ((Label)row.FindControl("lblId")).Text;
                string GSNAmt = (decimal.Parse((((Label)row.FindControl("lblGSNAmt")).Text).ToString()).ToString("N2"));
                string GSNQty = ((Label)row.FindControl("lblAcptQty0")).Text;
                double GQNAmt = 0;
                string GQNQty = "0";
                int ACId1 = Convert.ToInt32(((Label)row.FindControl("lblACId1")).Text);
                //ACHead
                string StrACHead = fun.select("ACHead", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' And CompId='" + CompId + "'");
                SqlCommand cmdACHead = new SqlCommand(StrACHead, con);
                SqlDataAdapter daACHead = new SqlDataAdapter(cmdACHead);
                DataSet DSACHead = new DataSet();
                daACHead.Fill(DSACHead);
                if (DSACHead.Tables[0].Rows.Count == 0 || DSACHead.Tables[0].Rows.Count > 0 && Convert.ToInt32(DSACHead.Tables[0].Rows[0]["ACHead"]) == ACId1)
                {
                    Response.Redirect("BillBooking_Item_Details.aspx?SUPId=" + SupplierNo + "&FGT=" + FGT + "&PoId=" + POId + "&GQNQty=" + GQNQty + "&GQNAmt=" + GQNAmt + "&GSNQty=" + GSNQty + "&GSNAmt=" + GSNAmt + "&GSNId=" + GSNId + "&GQNId=" + GQNId + "&FYId=" + FyId + "&ST=" + ST + "&ModId=11&SubModId=62");
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "AC Head is not match.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
              
            }
        }
        catch (Exception ex) { }
    }

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }
    
    protected void btnGQNSearch_Click(object sender, EventArgs e)
    {
        try
        {

            if (DropSearchBy.SelectedValue == "6")
            {
                DrpValue = Convert.ToInt32(DropSearchBy.SelectedValue);
                TxtValue = DropACHeadGqn.SelectedValue.ToString();
            }
            else
            {
                DrpValue = Convert.ToInt32(DropSearchBy.SelectedValue);
                TxtValue = txtSearchValue.Text;
            }

            this.loadDataGQN(DrpValue, TxtValue);
        }
        catch (Exception et)
        {
        }

    }

    protected void btnGSNSearch_Click(object sender, EventArgs e)
    {
        try
        {

            if (DropSearchByGSN.SelectedValue == "6")
            {
                DrpValue = Convert.ToInt32(DropSearchByGSN.SelectedValue);
                TxtValue = DropACHeadGsn.SelectedValue.ToString();
            }
            else
            {
                DrpValue = Convert.ToInt32(DropSearchByGSN.SelectedValue);
                TxtValue = txtSearchValueGSN.Text;
            }
            this.loadDataGSN(DrpValue, TxtValue);
        }
        catch (Exception et)
        {

        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.loadDataGSN(DrpValue, TxtValue);
        }
        catch (Exception ex) { }
    }

    protected void DropSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropSearchBy.SelectedValue == "6")
        {
            DropACHeadGqn.Visible = true;
        }
        else
        {
            DropACHeadGqn.Visible = false;
        }
        if (DropSearchBy.SelectedValue != "6" && DropSearchBy.SelectedValue!="0")
        {
            txtSearchValue.Text = "";
            txtSearchValue.Visible = true;
            DropACHeadGqn.SelectedValue = "Select";
        }
        else
        {
            txtSearchValue.Visible = false;
            txtSearchValue.Text = "";
        }
    }
    protected void DropSearchByGSN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropSearchByGSN.SelectedValue == "6")
        {
            DropACHeadGsn.Visible = true;
        }
        else
        {
            DropACHeadGsn.Visible = false;
        }
        if (DropSearchByGSN.SelectedValue != "6" && DropSearchByGSN.SelectedValue != "0")
        {
            txtSearchValueGSN.Text = "";
            txtSearchValueGSN.Visible = true;
            DropACHeadGsn.SelectedValue="Select";
        }
        else
        {
            txtSearchValueGSN.Visible = false;
            txtSearchValueGSN.Text = "";
        }
        TabContainer1.ActiveTabIndex = 1;
    }
}

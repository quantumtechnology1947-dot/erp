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
using System.IO;
using System.Text;

public partial class Module_MaterialManagement_Transactions_APO_SPR_Items : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    string sId = string.Empty;
    string SupCode = string.Empty;
    int CompId = 0;
    int FinYearId = 0;
    string str = string.Empty;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            SupCode = Request.QueryString["Code"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            str = fun.Connection();
            con = new SqlConnection(str);
            con.Open();

            txtRefDate.Attributes.Add("readonly", "readonly");

            if (!Page.IsPostBack)
            {
                TabContainer1.OnClientActiveTabChanged = "OnChanged";
                TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
                string Address = fun.CompAdd(CompId);
                txtShipTo.Text = Address;
                // For Supplier Name And Code
                //For Supplier Address
                string cn = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_masterA", "SupplierId='" + SupCode + "' And CompId='" + CompId + "'");

                SqlCommand cmd4 = new SqlCommand(cn, con);
                SqlDataReader ds = cmd4.ExecuteReader();
                ds.Read();
                string sname = ds["SupplierName"].ToString();
                txtNewCustomerName.Text = sname + '[' + SupCode + ']';

                string strcmd1 = fun.select("CountryName", "tblcountry", "CId='" + ds["RegdCountry"] + "'");

                string strcmd2 = fun.select("StateName", "tblState", "SId='" + ds["RegdState"] + "'");

                string strcmd3 = fun.select("CityName", "tblCity", "CityId='" + ds["RegdCity"] + "'");

                SqlCommand Cmd1 = new SqlCommand(strcmd1, con);
                SqlDataReader ds1 = Cmd1.ExecuteReader();
                ds1.Read();

                SqlCommand Cmd2 = new SqlCommand(strcmd2, con);
                SqlDataReader ds2 = Cmd2.ExecuteReader();
                ds2.Read();

                SqlCommand Cmd3 = new SqlCommand(strcmd3, con);
                SqlDataReader ds3 = Cmd3.ExecuteReader();
                ds3.Read();

                LblAddress.Text = ds["RegdAddress"].ToString() + ",<br>" + ds3["CityName"].ToString() + "," + ds2["StateName"].ToString() + ", " + ds1["CountryName"].ToString() + ". " + ds["RegdPinNo"].ToString() + ".";
            }

            Iframe1.Attributes.Add("src", "APO_SPR_ItemGrid.aspx?Code=" + SupCode);

            string StrSql = fun.select1("Terms", " tbl_PO_terms");
            SqlCommand Cmdgrid = new SqlCommand(StrSql, con);
            SqlDataReader rdr = Cmdgrid.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    sb.AppendLine(rdr[0].ToString());

                }
            }

            TextBox1.Text = sb.ToString().Replace(Environment.NewLine, Environment.NewLine);

            con.Close();
            this.LoadData();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("APO_new.aspx?ModId=6&SubModId=35");
    }
    public void LoadData()
    {
        try
        {

            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("SPRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AddDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PF", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ExST", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DelDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Dept", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DiscAmt", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TaxAmt", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TotalAmt", typeof(string)));
            DataRow dr;
            string sql = fun.select("*", "tblMM_SPR_PO_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader DS = cmd.ExecuteReader();

            while (DS.Read())
            {
                dr = dt.NewRow();

                // for Item Id And Ac Head
                string sql7 = fun.select("tblMM_SPR_DetailsA.ItemId,tblMM_SPR_DetailsA.DeptId,tblMM_SPR_DetailsA.WONo,tblMM_SPR_DetailsA.AHId", "tblMM_SPR_MasterA,tblMM_SPR_DetailsA", "tblMM_SPR_MasterA.SPRNo=tblMM_SPR_DetailsA.SPRNo AND tblMM_SPR_DetailsA.Id='" + Convert.ToInt32(DS["SPRId"].ToString()) + "'AND tblMM_SPR_MasterA.CompId='" + CompId + "' AND tblMM_SPR_MasterA.Id=tblMM_SPR_DetailsA.MId");
                SqlCommand cmd7 = new SqlCommand(sql7, con);
                SqlDataReader DS7 = cmd7.ExecuteReader();
                DS7.Read();

                // For Item Code
                string sql1 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOM", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(DS7["ItemId"].ToString()) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader DS1 = cmd1.ExecuteReader();
                DS1.Read();

                dr[0] = DS["SPRNo"].ToString();
                dr[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS7["ItemId"].ToString()));
                dr[2] = DS1["ManfDesc"].ToString();
                dr[3] = DS1["UOM"].ToString();
                dr[4] = decimal.Parse(DS["Qty"].ToString()).ToString("N3");
                dr[5] = decimal.Parse(DS["Rate"].ToString()).ToString("N2");

                if (DS7.HasRows == true)
                {
                    //// For A/c Head
                    string sql2 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(DS7["AHId"].ToString()) + "' ");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataReader DS2 = cmd2.ExecuteReader();
                    DS2.Read();

                    if (DS2.HasRows == true)
                    {
                        dr[6] = DS2["Head"].ToString();
                    }
                }

                dr[7] = decimal.Parse(DS["Discount"].ToString()).ToString("N2");
                dr[8] = DS["AddDesc"].ToString();

                // For PF 
                string sql3 = fun.select("tblPacking_Master.Terms AS PF,tblPacking_Master.Value", "tblPacking_Master,tblMM_SPR_PO_TempA", "tblPacking_Master.Id=tblMM_SPR_PO_TempA.PF AND tblMM_SPR_PO_TempA.PF ='" + Convert.ToInt32(DS["PF"].ToString()) + "' AND tblMM_SPR_PO_TempA.SessionId='" + sId + "' AND tblMM_SPR_PO_TempA.CompId='" + CompId + "'");

                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataReader DS3 = cmd3.ExecuteReader();
                DS3.Read();

                dr[9] = DS3["PF"].ToString();

                // For VAT 
                string sql4 = fun.select("Terms AS VAT, Value", "tblVAT_Master", "Id='" + Convert.ToInt32(DS["VAT"].ToString()) + "'");

                SqlCommand cmd4 = new SqlCommand(sql4, con);
                SqlDataReader DS4 = cmd4.ExecuteReader();
                DS4.Read();

                dr[10] = DS4["VAT"].ToString();

                // For Excise/ Service Tax 
                string sql5 = string.Empty;
                sql5 = fun.select("tblExciseser_Master.Terms AS ExST,tblExciseser_Master.Value", "tblExciseser_Master,tblMM_SPR_PO_TempA", "tblExciseser_Master.Id=tblMM_SPR_PO_TempA.ExST AND tblMM_SPR_PO_TempA.ExST ='" + Convert.ToInt32(DS["ExST"].ToString()) + "' AND tblMM_SPR_PO_TempA.SessionId='" + sId + "'");

                SqlCommand cmd5 = new SqlCommand(sql5, con);
                SqlDataReader DS5 = cmd5.ExecuteReader();
                DS5.Read();

                dr[11] = DS5["ExST"].ToString();

                string SDate = string.Empty;

                SDate = fun.FromDateDMY(DS["DelDate"].ToString());
                dr[12] = SDate;
                dr[13] = DS["Id"].ToString();

                string DeptName = string.Empty;
                string WorkONo = string.Empty;

                //For WO No
                if (DS7["WONo"].ToString() != "")
                {
                    WorkONo = DS7["WONo"].ToString();
                }
                else
                {
                    WorkONo = "NA";
                }

                int deptId = Convert.ToInt32(DS7["DeptId"].ToString());

                if (deptId > 0)
                {
                    string sqlDeptName = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + deptId + "' ");
                    SqlCommand cmdDeptName = new SqlCommand(sqlDeptName, con);
                    SqlDataReader DSDeptName = cmdDeptName.ExecuteReader();
                    DSDeptName.Read();
                    DeptName = DSDeptName["Dept"].ToString();
                }
                else
                {
                    DeptName = "NA";
                }

                dr[14] = WorkONo;
                dr[15] = DeptName;
                dr[16] = fun.CalBasicAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5]));
                dr[17] = fun.CalDiscAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5]), Convert.ToDouble(dr[7]));
                dr[18] = fun.CalTaxAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5]), Convert.ToDouble(dr[7]), Convert.ToDouble(DS3["Value"].ToString()), Convert.ToDouble(DS5["Value"].ToString()), Convert.ToDouble(DS4["Value"].ToString()));
                dr[19] = fun.CalTotAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5]), Convert.ToDouble(dr[7]), Convert.ToDouble(DS3["Value"].ToString()), Convert.ToDouble(DS5["Value"].ToString()), Convert.ToDouble(DS4["Value"].ToString()));

                dt.Rows.Add(dr);
            }

            dt.AcceptChanges();
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        catch (Exception ep)
        {

        }

        finally
        {
            con.Close();
        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        this.LoadData();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            try
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                con.Open();
                string sqldel = fun.delete("tblMM_SPR_PO_TempA", "Id='" + id + "' AND CompId='" + CompId + "' AND SessionId='" + sId + "'  ");
                SqlCommand cmddel = new SqlCommand(sqldel, con);
                cmddel.ExecuteNonQuery();
                con.Close();
                this.LoadData();
            }
            catch (Exception eo)
            {

            }
        }

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        try
        {
            con.Open();
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string cmdStr = fun.select("PONo", "tblMM_PO_MasterA", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by PONo desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataReader DS = cmd1.ExecuteReader();
            DS.Read();

            string PONo;
            if (DS.HasRows == true)
            {
                int PONstr = Convert.ToInt32(DS[0].ToString()) + 1;
                PONo = PONstr.ToString("D4");
            }
            else
            {
                PONo = "0001";
            }

            string CustCode = fun.getCode(txtNewCustomerName.Text);
            {
                string RefDate = fun.FromDate(txtRefDate.Text);
                // file upload
                string strcv = "";
                HttpPostedFile mycv = FileUpload1.PostedFile;
                Byte[] mycvdata = null;
                if (FileUpload1.PostedFile != null)
                {
                    Stream fscv = FileUpload1.PostedFile.InputStream;
                    BinaryReader brcv = new BinaryReader(fscv);
                    mycvdata = brcv.ReadBytes((Int32)fscv.Length);
                    strcv = Path.GetFileName(mycv.FileName);
                }

                //===============

                if (txtRefDate.Text != "" && fun.DateValidation(txtRefDate.Text) == true)
                {
                    string Sqlbud = "SELECT(SUM(tblMM_SPR_PO_TempA.Qty * (tblMM_SPR_PO_TempA.Rate - tblMM_SPR_PO_TempA.Rate * tblMM_SPR_PO_TempA.Discount / 100)) )+(SUM(tblMM_SPR_PO_TempA.Qty * (tblMM_SPR_PO_TempA.Rate - tblMM_SPR_PO_TempA.Rate * tblMM_SPR_PO_TempA.Discount / 100)) )* tblExciseser_Master.Value/100+(SUM(tblMM_SPR_PO_TempA.Qty * (tblMM_SPR_PO_TempA.Rate - tblMM_SPR_PO_TempA.Rate * tblMM_SPR_PO_TempA.Discount / 100)) )* tblVAT_Master.Value/100+(SUM(tblMM_SPR_PO_TempA.Qty * (tblMM_SPR_PO_TempA.Rate - tblMM_SPR_PO_TempA.Rate * tblMM_SPR_PO_TempA.Discount / 100)) )* tblPacking_Master.Value/100 AS Amount,DeptId,WONo,BudgetCode FROM tblMM_SPR_PO_TempA INNER JOIN tblMM_SPR_DetailsA ON tblMM_SPR_PO_TempA.SPRId = tblMM_SPR_DetailsA.Id  INNER JOIN tblVAT_Master ON tblMM_SPR_PO_TempA.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_SPR_PO_TempA.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_SPR_PO_TempA.PF = tblPacking_Master.Id GROUP BY  tblExciseser_Master.Value, tblVAT_Master.Value,tblPacking_Master.Value,DeptId,WONo,BudgetCode";

                    SqlCommand cmdAMt = new SqlCommand(Sqlbud, con);
                    SqlDataReader DSAMt = cmdAMt.ExecuteReader();

                    int y = 0;
                    int x = 0;
                    int InsuffAmtbudCode = 0;
                    DataTable dtX = new DataTable();
                    dtX.Columns.Add(new System.Data.DataColumn("WONO/BG", typeof(string)));
                    dtX.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));
                    dtX.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                    dtX.Columns.Add(new System.Data.DataColumn("BalAmt", typeof(double)));
                    DataRow drX;
                    string StrSymb = string.Empty;
                    string StrDesc = string.Empty;
                    while (DSAMt.Read())
                    {
                        x++;
                        double TotBudget = 0;
                        double TotAmt = 0;
                        TotAmt = Convert.ToDouble(DSAMt["Amount"].ToString());
                        string sqlBudget = string.Empty;
                        string wono = string.Empty;
                        InsuffAmtbudCode = Convert.ToInt32(DSAMt["BudgetCode"].ToString());
                        if (Convert.ToInt32(DSAMt["DeptId"].ToString()) == 0)
                        {
                            wono = DSAMt["WONo"].ToString();
                            if (fun.CheckValidWONo(wono, CompId, FinYearId) == true)
                            {
                                TotBudget = calbalbud.TotBalBudget_WONO(InsuffAmtbudCode, CompId, FinYearId, wono, 1);
                            }
                        }
                        else
                        {
                            string sql5 = fun.select("Symbol", "BusinessGroup", "Id='" + DSAMt["DeptId"].ToString() + "'");
                            SqlCommand cmd5 = new SqlCommand(sql5, con);
                            SqlDataReader DS5 = cmd5.ExecuteReader();
                            DS5.Read();
                            string StrBGSymb = string.Empty;
                            if (DS5.HasRows == true)
                            {
                                StrBGSymb = DS5["Symbol"].ToString();
                            }
                            wono = StrBGSymb;
                            StrSymb = "NA";
                            StrDesc = "NA";
                            TotBudget = calbalbud.TotBalBudget_BG(Convert.ToInt32(DSAMt["DeptId"]), CompId, FinYearId, 1);

                        }

                        if (Math.Round((TotBudget - TotAmt), 3) >= 0)
                        {
                            y++;
                        }
                        else
                        {
                            drX = dtX.NewRow();
                            string sql5 = fun.select("Symbol,Description", "tblMIS_BudgetCode", "Id='" + InsuffAmtbudCode + "'");
                            SqlCommand cmd5 = new SqlCommand(sql5, con);
                            SqlDataReader DS5 = cmd5.ExecuteReader();
                            DS5.Read();
                            if (DS5.HasRows == true)
                            {
                                StrSymb = DS5["Symbol"].ToString() + wono;
                                StrDesc = DS5["Description"].ToString();
                            }
                            drX[0] = wono;
                            drX[1] = StrSymb;
                            drX[2] = StrDesc;
                            drX[3] = Math.Round(TotBudget, 3);
                            dtX.Rows.Add(drX);
                            dtX.AcceptChanges();
                            Session["X"] = dtX.DefaultView;
                        }
                    }

                    if (x == y && y > 0)
                    {
                        string StrPoMaster = fun.insert("tblMM_PO_MasterA", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Warrenty,Freight,Octroi,ModeOfDispatch,Inspection,FileName,FileSize,ContentType,FileData,Remarks,ShipTo,Insurance,TC", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','1','" + PONo + "','" + CustCode + "','" + DDLReference.SelectedValue + "','" + RefDate + "','" + txtReferenceDesc.Text + "','" + DDLPaymentTerms.SelectedValue + "','" + drpwarrenty.SelectedValue + "','" + DDLFreight.SelectedValue + "','" + DDLOctroi.SelectedValue + "','" + txtModeOfDispatch.Text + "','" + txtInspection.Text + "','" + strcv + "','" + mycvdata.Length + "','" + mycv.ContentType + "',@Data,'" + txtRemarks.Text + "','" + txtShipTo.Text + "','" + txtInsurance.Text + "','" + TextBox1.Text + "'");
                        SqlCommand cmdPoM = new SqlCommand(StrPoMaster, con);
                        cmdPoM.Parameters.AddWithValue("@Data", mycvdata);
                        cmdPoM.ExecuteNonQuery();

                        string getid = fun.select("Id", "tblMM_PO_MasterA", "CompId='" + CompId + "' AND PONo='" + PONo + "' order by Id desc");
                        SqlCommand cmdgetid = new SqlCommand(getid, con);
                        SqlDataReader DSgetid = cmdgetid.ExecuteReader();
                        DSgetid.Read();

                        string sql5 = fun.select("*", "tblMM_SPR_PO_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                        SqlCommand cmd5 = new SqlCommand(sql5, con);
                        SqlDataReader DS5 = cmd5.ExecuteReader();

                        while (DS5.Read())
                        {
                            string StrPoDetails = fun.insert("tblMM_PO_DetailsA", "MId,PONo,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + DSgetid["Id"].ToString() + "','" + PONo + "','" + DS5["SPRNo"].ToString() + "','" + DS5["SPRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(DS5["Rate"].ToString()).ToString("N2")) + "','" + DS5["Discount"].ToString() + "','" + DS5["AddDesc"].ToString() + "','" + DS5["PF"].ToString() + "','" + DS5["ExST"].ToString() + "','" + DS5["VAT"].ToString() + "','" + DS5["DelDate"].ToString() + "','" + DS5["BudgetCode"].ToString() + "'");
                            SqlCommand cmdPoDetails = new SqlCommand(StrPoDetails, con);
                            cmdPoDetails.ExecuteNonQuery();

                            string Item = fun.select("tblMM_SPR_DetailsA.ItemId", "tblMM_PO_MasterA,tblMM_SPR_MasterA,tblMM_SPR_DetailsA,tblMM_PO_DetailsA ", "tblMM_PO_MasterA.PONo=tblMM_PO_DetailsA.PONo And tblMM_SPR_DetailsA.SPRNo=tblMM_SPR_MasterA.SPRNo And tblMM_PO_DetailsA.SPRId=tblMM_SPR_DetailsA.Id And tblMM_PO_DetailsA.SPRNo=tblMM_SPR_DetailsA.SPRNo And tblMM_SPR_DetailsA.MId=tblMM_SPR_MasterA.Id AND tblMM_PO_MasterA.PONo='" + PONo + "' AND tblMM_PO_MasterA.CompId='" + CompId + "'");
                            SqlCommand Cmdit = new SqlCommand(Item, con);
                            SqlDataReader dsit = Cmdit.ExecuteReader();
                            dsit.Read();

                            if (dsit.HasRows == true)
                            {
                                string sqlt = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + PONo + "' , LockDate='" + CDate + "' ,LockTime='" + CTime + "'", "ItemId='" + dsit["ItemId"].ToString() + "' And  Type='1' AND CompId='" + CompId + "'");
                                SqlCommand cmdt = new SqlCommand(sqlt, con);
                                cmdt.ExecuteNonQuery();

                                string sqlt1 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + PONo + "' , LockDate='" + CDate + "' ,LockTime='" + CTime + "'", "ItemId='" + dsit["ItemId"].ToString() + "' And  Type='2' AND CompId='" + CompId + "'");
                                SqlCommand cmdt1 = new SqlCommand(sqlt1, con);
                                cmdt1.ExecuteNonQuery();
                            }
                        }

                        string delsql = fun.delete("tblMM_SPR_Po_TempA", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                        SqlCommand cmd12 = new SqlCommand(delsql, con);
                        cmd12.ExecuteNonQuery();

                        Response.Redirect("APO_new.aspx?ModId=6&SubModId=35");
                    }
                    else
                    {
                        Response.Redirect("PO_Error.aspx?ModId=6&Code=" + SupCode + "&PRSPR=1");
                    }
                }
            }
        }
        catch (Exception es)
        {

        }
        finally
        {
            con.Close();
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId1 = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_masterA", "CompId='" + CompId1 + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_masterA");

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

}
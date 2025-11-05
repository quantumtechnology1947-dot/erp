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
/*
 Modified by & date
 * 14.01.2014 - Ashish
 
 */
public partial class Module_MaterialManagement_Transactions_PO_PR_Items : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string SupCode = "";
    string str = string.Empty;
    SqlConnection con ;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            str = fun.Connection();
            con = new SqlConnection(str);
            con.Open();
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            SupCode = Request.QueryString["Code"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);

            txtRefDate.Attributes.Add("readonly", "readonly");
        
            if (!Page.IsPostBack)
            {
                TabContainer1.OnClientActiveTabChanged = "OnChanged";
                TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
                string Address = fun.CompAdd(CompId);
                txtShipTo.Text = Address;

                // For Supplier Name And Code                
                //For Supplier Address
                string cn = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_master", "SupplierId='" + SupCode + "' And CompId='" + CompId + "'");
               
                SqlCommand cmd4 = new SqlCommand(cn, con);
                SqlDataReader ds = cmd4.ExecuteReader();
                ds.Read();

                string sname = string.Empty;                 
                sname =ds["SupplierName"].ToString();
                
                // lblSupplierName.Text = sname + '[' + SupCode + ']';
                txtNewCustomerName.Text = sname + '[' + SupCode + ']';

                string strcmd1 = fun.select("CountryName", "tblcountry", "CId='" + ds["RegdCountry"] + "'");
                SqlCommand Cmd1 = new SqlCommand(strcmd1, con);
                SqlDataReader ds1 = Cmd1.ExecuteReader();
                ds1.Read();

                string strcmd2 = fun.select("StateName", "tblState", "SId='" + ds["RegdState"] + "'");
                SqlCommand Cmd2 = new SqlCommand(strcmd2, con);
                SqlDataReader ds2 = Cmd2.ExecuteReader();
                ds2.Read();

                string strcmd3 = fun.select("CityName", "tblCity", "CityId='" + ds["RegdCity"] + "'");
                SqlCommand Cmd3 = new SqlCommand(strcmd3, con);
                SqlDataReader ds3 = Cmd3.ExecuteReader();
                ds3.Read();

                LblAddress.Text = ds["RegdAddress"].ToString() + ",<br>" + ds3["CityName"].ToString() + "," + ds2["StateName"].ToString() + ", " + ds1["CountryName"].ToString() + ". " + ds["RegdPinNo"].ToString() + ".";
            }

            Iframe1.Attributes.Add("src", "PO_PR_ItemGrid.aspx?Code=" + SupCode + "&ModId=6&SubModId=35");
           
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

            TextBox1.Text = sb.ToString().Replace(Environment.NewLine,Environment.NewLine);         

            con.Close();
            this.LoadData();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PO_new.aspx?ModId=6&SubModId=35");
    }
    public void LoadData()
    {
        try
        {
           
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("PRNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("AddDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PF", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ExST", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SheduleDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BasicAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("DiscAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("TaxAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("TotalAmt", typeof(double)));

            DataRow dr;

            double a1 = 0;
            double a2 = 0;
            double a3 = 0;
            double a4 = 0;
            double a5 = 0;
            double a6 = 0;           
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
           
            string sql = fun.select("*", "tblMM_PR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader DS = cmd.ExecuteReader();

            while(DS.Read())
            {               
                dr = dt.NewRow();

                string sql9 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Details.AHId,tblMM_PR_Master.WONo", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.Id='" + Convert.ToInt32(DS["PRId"].ToString()) + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.PRNo='" + DS["PRNo"].ToString() + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId  AND tblMM_PR_Master.CompId='"+CompId+"'");

                SqlCommand cmd9 = new SqlCommand(sql9, con);
                SqlDataReader DS9 = cmd9.ExecuteReader();
                DS9.Read();

                if (DS9.HasRows == true)
                {
                    string sql1 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOM", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + DS9["ItemId"].ToString() + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");

                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader DS1 = cmd1.ExecuteReader();
                    DS1.Read();

                    if (DS1.HasRows == true)
                    {
                        dr[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS9["ItemId"].ToString()));
                        dr[2] = DS1["ManfDesc"].ToString();
                        dr[3] = DS1["UOM"].ToString();
                    }                   

                    string sql2 = fun.select("'['+AccHead.Symbol+'] '+Description AS Head", "AccHead", "Id='" + Convert.ToInt32(DS9["AHId"].ToString()) + "'");

                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataReader DS2 = cmd2.ExecuteReader();
                    DS2.Read();

                    if (DS2.HasRows == true)
                    {
                        dr[6] = DS2["Head"].ToString();
                    }

                    dr[14] = DS9["WONo"].ToString();
                }
                dr[7] =Convert.ToDouble(decimal.Parse(DS["Discount"].ToString()).ToString("N2"));
                a3=Convert.ToDouble(dr[7].ToString());
                dr[8] = DS["AddDesc"].ToString();
                dr[0] = DS["PRNo"].ToString();
                dr[4] = Convert.ToDouble(decimal.Parse(DS["Qty"].ToString()).ToString("N3"));
                a1 = Convert.ToDouble(dr[4].ToString());
                dr[5] = Convert.ToDouble(decimal.Parse(DS["Rate"].ToString()).ToString("N2"));
                a2 = Convert.ToDouble(dr[5].ToString());

                // For VAT 
                string sql4 = fun.select("Terms AS VAT, Value", "tblVAT_Master", "tblVAT_Master.Id='" + Convert.ToInt32(DS["VAT"].ToString()) + "'");

                SqlCommand cmd4 = new SqlCommand(sql4, con);
                SqlDataReader DS4 = cmd4.ExecuteReader();
                DS4.Read();

                if (DS4.HasRows == true)
                {
                    dr[10] = DS4["VAT"].ToString();
                    a6=Convert.ToDouble(DS4["Value"]);
                }

                // For Excise/ Service Tax 
                string sql5 = fun.select("tblExciseser_Master.Terms AS ExST,tblExciseser_Master.Value", "tblExciseser_Master,tblMM_PR_PO_Temp", "tblExciseser_Master.Id=tblMM_PR_PO_Temp.ExST AND tblMM_PR_PO_Temp.ExST ='" + Convert.ToInt32(DS["ExST"].ToString()) + "' AND tblMM_PR_PO_Temp.SessionId='" + sId + "'");

                SqlCommand cmd5 = new SqlCommand(sql5, con);
                SqlDataReader DS5 = cmd5.ExecuteReader();
                DS5.Read();

                if (DS5.HasRows == true)
                {
                    dr[11] = DS5["ExST"].ToString();
                    a5=Convert.ToDouble(DS5["Value"]);
                }

                string SDate = fun.FromDateDMY(DS["DelDate"].ToString());
                dr[12] = SDate;
                dr[13] = DS["Id"].ToString();
                
                dr[15] = Convert.ToDouble(decimal.Parse(fun.CalBasicAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5])).ToString()).ToString("N3"));

                dr[16] = Convert.ToDouble(decimal.Parse(fun.CalDiscAmt(Convert.ToDouble(dr[4]), Convert.ToDouble(dr[5]), Convert.ToDouble(dr[7])).ToString()).ToString("N3"));

                // For PF 
                string sql3 = fun.select("tblPacking_Master.Terms AS PF,tblPacking_Master.Value", "tblPacking_Master,tblMM_PR_PO_Temp", "tblPacking_Master.Id=tblMM_PR_PO_Temp.PF AND tblMM_PR_PO_Temp.PF ='" + Convert.ToInt32(DS["PF"].ToString()) + "' AND tblMM_PR_PO_Temp.SessionId='" + sId + "'");

                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataReader DS3 = cmd3.ExecuteReader();
                DS3.Read();

                if (DS3.HasRows == true)
                {
                    dr[9] = DS3["PF"].ToString();
                    a4=Convert.ToDouble(DS3["Value"]);
                }

                dr[17] = Convert.ToDouble(decimal.Parse(fun.CalTaxAmt(a1, a2, a3, a4, a5, a6).ToString()).ToString("N3"));
                dr[18] = Convert.ToDouble(decimal.Parse(fun.CalTotAmt(a1, a2, a3, a4, a5, a6).ToString()).ToString("N3")); 
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
           
            GridView3.DataSource = dt;
            GridView3.DataBind();

        }
        catch (Exception el)
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
                string sql = fun.delete("tblMM_PR_PO_Temp", "Id='" + id + "'    AND CompId='" + CompId + "' AND SessionId='" + sId + "'  ");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.LoadData();
               
            }
            catch (Exception ea)
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
            string cmdStr = fun.select("PONo", "tblMM_PO_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by PONo desc");
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
            
            if (txtRefDate.Text != "" && fun.DateValidation(txtRefDate.Text) == true)
            {
                string Sqlbud = "SELECT(SUM(tblMM_PR_PO_Temp.Qty * (tblMM_PR_PO_Temp.Rate - tblMM_PR_PO_Temp.Rate * tblMM_PR_PO_Temp.Discount / 100)) )+(SUM(tblMM_PR_PO_Temp.Qty * (tblMM_PR_PO_Temp.Rate - tblMM_PR_PO_Temp.Rate * tblMM_PR_PO_Temp.Discount / 100)) )* tblExciseser_Master.Value/100+(SUM(tblMM_PR_PO_Temp.Qty * (tblMM_PR_PO_Temp.Rate - tblMM_PR_PO_Temp.Rate * tblMM_PR_PO_Temp.Discount / 100)) )* tblVAT_Master.Value/100+(SUM(tblMM_PR_PO_Temp.Qty * (tblMM_PR_PO_Temp.Rate - tblMM_PR_PO_Temp.Rate * tblMM_PR_PO_Temp.Discount / 100)) )* tblPacking_Master.Value/100 AS Amount,WONo,BudgetCode FROM tblMM_PR_PO_Temp INNER JOIN tblMM_PR_Details ON tblMM_PR_PO_Temp.PRId = tblMM_PR_Details.Id INNER JOIN tblMM_PR_Master ON tblMM_PR_Master.Id = tblMM_PR_Details.MId  INNER JOIN tblVAT_Master ON tblMM_PR_PO_Temp.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_PR_PO_Temp.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_PR_PO_Temp.PF = tblPacking_Master.Id GROUP BY  tblExciseser_Master.Value, tblVAT_Master.Value,tblPacking_Master.Value,WONo,BudgetCode";
                SqlCommand cmdAMt = new SqlCommand(Sqlbud, con);
                SqlDataReader DSAMt = cmdAMt.ExecuteReader();
                int y = 0;
                int x = 0;
                string InsuffbudWono = string.Empty;
                int InsuffAmtbudCode = 0;
                DataTable dtX = new DataTable();
                dtX.Columns.Add(new System.Data.DataColumn("WONO", typeof(string)));
                dtX.Columns.Add(new System.Data.DataColumn("BudgetCode", typeof(string)));
                dtX.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                dtX.Columns.Add(new System.Data.DataColumn("BalAmt", typeof(double)));
                DataRow drX;
                while (DSAMt.Read())
                {
                    x++;
                    double TotBudget = 0;
                    double TotAmt = 0;
                    TotAmt = Convert.ToDouble(DSAMt["Amount"].ToString());
                    string wono = string.Empty;
                    wono = DSAMt["WONo"].ToString();
                    InsuffAmtbudCode = Convert.ToInt32(DSAMt["BudgetCode"].ToString());
                    if (DSAMt["WONo"] != DBNull.Value)
                    {
                        if (fun.CheckValidWONo(wono, CompId, FinYearId) == true)
                        {
                            TotBudget = calbalbud.TotBalBudget_WONO(InsuffAmtbudCode, CompId, FinYearId, wono, 1);
                        }
                    }                    
                    
                    if (Math.Round((TotBudget-TotAmt), 3) >= 0)
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
                        string StrSymb = string.Empty;
                        string StrDesc = string.Empty;
                        if (DS5.HasRows==true)
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
                int kk = 0;
                
                if (x == y && y > 0)
                {

                    string sql5 = fun.select("*", "tblMM_PR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                    SqlCommand cmd5 = new SqlCommand(sql5, con);
                    SqlDataReader DS5 = cmd5.ExecuteReader();

                    if (DS5.HasRows == true)
                    {
                        string RefDate = fun.FromDate(txtRefDate.Text);
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
                        string StrPoMaster = fun.insert("tblMM_PO_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Warrenty,Freight,Octroi,ModeOfDispatch,Inspection,ShipTo,Remarks,FileName,FileSize,ContentType,FileData,Insurance,TC", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','0','" + PONo + "','" + CustCode + "','" + DDLReference.SelectedValue + "','" + RefDate + "','" + txtReferenceDesc.Text + "','" + DDLPaymentTerms.SelectedValue + "','" + drpwarrenty.SelectedValue + "','" + DDLFreight.SelectedValue + "','" + DDLOctroi.SelectedValue + "','" + txtModeOfDispatch.Text + "','" + txtInspection.Text + "','" + txtShipTo.Text + "','" + txtRemarks.Text + "','" + strcv + "','" + mycvdata.Length + "','" + mycv.ContentType + "',@Data,'" + txtInsurance.Text + "','"+TextBox1.Text+"'");
                        SqlCommand cmdPoM = new SqlCommand(StrPoMaster, con);
                        cmdPoM.Parameters.AddWithValue("@Data", mycvdata);
                        cmdPoM.ExecuteNonQuery();

                        string getid = fun.select("Id", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + PONo + "' order by Id desc");
                        SqlCommand cmdgetid = new SqlCommand(getid, con);
                        SqlDataReader DSgetid = cmdgetid.ExecuteReader();
                        DSgetid.Read();
                        while (DS5.Read())
                        {
                            string StrPoDetails = fun.insert("tblMM_PO_Details", "MId,PONo,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + DSgetid["Id"].ToString() + "','" + PONo + "','" + DS5["PRNo"].ToString() + "','" + DS5["PRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(DS5["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(DS5["Rate"].ToString()).ToString("N2")) + "','" + DS5["Discount"] + "','" + DS5["AddDesc"].ToString() + "','" + DS5["PF"].ToString() + "','" + DS5["ExST"].ToString() + "','" + DS5["VAT"].ToString() + "','" + DS5["DelDate"].ToString() + "','" + DS5["BudgetCode"].ToString() + "'");
                            SqlCommand cmdPoDetails = new SqlCommand(StrPoDetails, con);
                            cmdPoDetails.ExecuteNonQuery();

                            //Lock & Unlock Items
                            string Item = fun.select("tblMM_PR_Details.ItemId", " tblMM_PO_Master,tblMM_PR_Master,tblMM_PR_Details,tblMM_PO_Details ", " tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_PR_Details.PRNo=tblMM_PR_Master.PRNo And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PO_Details.PRNo=tblMM_PR_Details.PRNo And tblMM_PR_Details.MId=tblMM_PR_Master.Id AND tblMM_PO_Master.PONo='" + PONo + "'  AND tblMM_PO_Master.CompId='" + CompId + "'");
                            SqlCommand Cmdit = new SqlCommand(Item, con);
                            SqlDataReader dsit = Cmdit.ExecuteReader();
                            dsit.Read();
                            if (dsit.HasRows == true)
                            {
                                string sqlt1 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + PONo + "' , LockDate='" + CDate + "' ,LockTime='" + CTime + "'", "ItemId='" + dsit["ItemId"].ToString() + "' And  Type='2'  And  CompId='" + CompId + "' ");
                                SqlCommand cmdt1 = new SqlCommand(sqlt1, con);
                                cmdt1.ExecuteNonQuery();
                            }

                        }
                        string delsql = fun.delete("tblMM_PR_Po_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
                        SqlCommand cmd12 = new SqlCommand(delsql, con);
                        cmd12.ExecuteNonQuery();

                        kk++;
                    }

                }
                if (kk > 0)
                {
                    //System.Threading.Thread.Sleep(1000);
                    Response.Redirect("PO_new.aspx?ModId=6&SubModId=35");
                }
                else
                {
                    Response.Redirect("PO_Error.aspx?ModId=6&Code=" + SupCode + "&PRSPR=0");
                }
            }
        }
        catch (Exception es){ }  
        finally
        {
            con.Close();
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId1 + "'");
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


}


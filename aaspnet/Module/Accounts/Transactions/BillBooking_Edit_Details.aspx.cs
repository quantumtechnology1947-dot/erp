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

public partial class Module_Accounts_Transactions_BillBooking_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    string SId = "";
    int CompId = 0;
    string PId = "";
    string SupplierNo = "";  
    int FyId = 0;
    int PVEVId = 0;
 
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {

            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            PVEVId = Convert.ToInt32(Request.QueryString["Id"].ToString()); 

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            // For Selected Items


            string StrPVEV = fun.select("SysDate, SysTime, SessionId, CompId, FinYearId , PVEVNo, SupplierId , BillNo, BillDate , CENVATEntryNo, CENVATEntryDate , OtherCharges , OtherChaDesc , Narration , DebitAmt, DiscountType, Discount", "tblACC_BillBooking_Master", "Id='" + PVEVId + "'");

            SqlCommand cmdPVEV = new SqlCommand(StrPVEV, con);
            SqlDataAdapter DAPVEV = new SqlDataAdapter(cmdPVEV);
            DataSet DSPVEV = new DataSet();
            DAPVEV.Fill(DSPVEV);
            if (DSPVEV.Tables[0].Rows.Count > 0)
            {
                
                    SupplierNo = DSPVEV.Tables[0].Rows[0]["SupplierId"].ToString();
                    //PId = DSPVEV.Tables[0].Rows[0]["POId"].ToString();
                    FyId = Convert.ToInt32(DSPVEV.Tables[0].Rows[0]["FinYearId"].ToString());
                    if (!IsPostBack)
                    {
                        lblPVEVNo.Text = DSPVEV.Tables[0].Rows[0]["PVEVNo"].ToString();
                        textBillno.Text = DSPVEV.Tables[0].Rows[0]["BillNo"].ToString();
                        textBillDate.Text = fun.FromDateDMY(DSPVEV.Tables[0].Rows[0]["BillDate"].ToString());
                        textCVEntryNo.Text = DSPVEV.Tables[0].Rows[0]["CENVATEntryNo"].ToString();
                        textCVEntryDate.Text = fun.FromDateDMY(DSPVEV.Tables[0].Rows[0]["CENVATEntryDate"].ToString());

                        txtOtherCharges.Text = DSPVEV.Tables[0].Rows[0]["OtherCharges"].ToString();
                        txtOtherChaDesc.Text = DSPVEV.Tables[0].Rows[0]["OtherChaDesc"].ToString();
                        txtNarration.Text = DSPVEV.Tables[0].Rows[0]["Narration"].ToString();
                        txtDebitAmt.Text = DSPVEV.Tables[0].Rows[0]["DebitAmt"].ToString();
                        txtDiscount.Text = DSPVEV.Tables[0].Rows[0]["Discount"].ToString();
                        DrpAdd.SelectedValue = DSPVEV.Tables[0].Rows[0]["DiscountType"].ToString();

                        this.loadData();

                    }

            }

            // For Supplier Details       
            DataSet DS = new DataSet();
            string cmdStr = "Select * from tblMM_Supplier_master where SupplierId='" + SupplierNo + "'And CompId='" + CompId + "'";
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "tblMM_Supplier_master");

            if (DS.Tables[0].Rows.Count > 0)
            {
                //Supplier Name
                lblSupplierName.Text = DS.Tables[0].Rows[0]["SupplierName"].ToString();
                //Supplier Add
                string strcmd1 = fun.select("CountryName", "tblcountry", "CId='" + DS.Tables[0].Rows[0]["RegdCountry"] + "'");
                string strcmd2 = fun.select("StateName", "tblState", "SId='" + DS.Tables[0].Rows[0]["RegdState"] + "'");
                string strcmd3 = fun.select("CityName", "tblCity", "CityId='" + DS.Tables[0].Rows[0]["RegdCity"] + "'");
                SqlCommand Cmd1 = new SqlCommand(strcmd1, con);
                SqlCommand Cmd2 = new SqlCommand(strcmd2, con);
                SqlCommand Cmd3 = new SqlCommand(strcmd3, con);

                SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
                SqlDataAdapter DA2 = new SqlDataAdapter(Cmd2);
                SqlDataAdapter DA3 = new SqlDataAdapter(Cmd3);

                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();

                DA1.Fill(ds1, "tblCountry");
                DA2.Fill(ds2, "tblState");
                DA3.Fill(ds3, "tblcity");

                lblSupplierAdd.Text = DS.Tables[0].Rows[0]["RegdAddress"].ToString() + ",<br>" + ds3.Tables[0].Rows[0]["CityName"].ToString() + "," + ds2.Tables[0].Rows[0]["StateName"].ToString() + ",<br>" + ds1.Tables[0].Rows[0]["CountryName"].ToString() + ".<br>" + DS.Tables[0].Rows[0]["RegdPinNo"].ToString() + "." + "<br>";

                // Supplier Details
                lblECCno.Text = DS.Tables[0].Rows[0]["EccNo"].ToString();
                lblDivision.Text = DS.Tables[0].Rows[0]["Divn"].ToString();
                lblVatNo.Text = DS.Tables[0].Rows[0]["TinVatNo"].ToString();
                lblRange.Text = DS.Tables[0].Rows[0]["Range"].ToString();
                lblComm.Text = DS.Tables[0].Rows[0]["Commissionurate"].ToString();
                lblCSTNo.Text = DS.Tables[0].Rows[0]["TinCstNo"].ToString();
                lblServiceTax.Text = "-";
                lblTDS.Text = DS.Tables[0].Rows[0]["TDSCode"].ToString();
                lblPanNo.Text = DS.Tables[0].Rows[0]["PanNo"].ToString();
            }

            string StrSql = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.PaymentTerms,tblMM_PO_Master.PONo", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.Id='" + PId + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");

            SqlCommand cmdPo = new SqlCommand(StrSql, con);
            SqlDataAdapter DAPo = new SqlDataAdapter(cmdPo);
            DataSet DSSql = new DataSet();
            DAPo.Fill(DSSql);
            if (DSSql.Tables[0].Rows.Count > 0)
            {
                if (DSSql.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
                {
                    string StrFlag = fun.select("tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + DSSql.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + DSSql.Tables[0].Rows[0]["PRId"].ToString() + "'");

                    SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                    SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                    DataSet DSFlag = new DataSet();
                    daFlag.Fill(DSFlag);
                    lblPoNo.Text = DSSql.Tables[0].Rows[0]["PONo"].ToString();

                    // For WO No
                    if (DSFlag.Tables[0].Rows.Count > 0)
                    {
                        lblWoDeptNo.Text = DSFlag.Tables[0].Rows[0]["WONo"].ToString();
                    }
                }

                else if (DSSql.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
                {
                    string StrFlag1 = fun.select("tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + DSSql.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + DSSql.Tables[0].Rows[0]["SPRId"].ToString() + "'");

                    SqlCommand cmdFlag1 = new SqlCommand(StrFlag1, con);
                    SqlDataAdapter daFlag1 = new SqlDataAdapter(cmdFlag1);
                    DataSet DSFlag1 = new DataSet();
                    daFlag1.Fill(DSFlag1);

                    string WoDeptNo = "";
                    if (DSFlag1.Tables[0].Rows.Count > 0)
                    {
                        if (DSFlag1.Tables[0].Rows[0]["DeptId"].ToString() == "0")
                        {
                            // For WO No
                            WoDeptNo = DSFlag1.Tables[0].Rows[0]["WONo"].ToString();
                        }
                        else
                        {
                            // For Dept Name
                            string sqlDeptName = fun.select("Symbol AS Dept", "tblHR_Departments", "Id ='" + Convert.ToInt32(DSFlag1.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
                            SqlCommand cmdDeptName = new SqlCommand(sqlDeptName, con);
                            SqlDataAdapter daDeptName = new SqlDataAdapter(cmdDeptName);
                            DataSet DSDeptName = new DataSet();
                            daDeptName.Fill(DSDeptName);
                            if (DSDeptName.Tables[0].Rows.Count > 0)
                            {
                                WoDeptNo = DSDeptName.Tables[0].Rows[0]["Dept"].ToString();
                            }
                        }
                        lblWoDeptNo.Text = WoDeptNo;
                    }
                }

                //for  Payment Terms

                //string stTerms = fun.select("Terms", "tblPayment_Master", "tblPayment_Master.Id ='" + Convert.ToInt32(DSSql.Tables[0].Rows[0]["PaymentTerms"]) + "' ");
                //SqlCommand cmdTerms = new SqlCommand(stTerms, con);
                //SqlDataAdapter daTerms = new SqlDataAdapter(cmdTerms);
                //DataSet dsTerms = new DataSet();
                //daTerms.Fill(dsTerms, "tblPayment_Master");
                //if (dsTerms.Tables[0].Rows.Count > 0)
                //{
                //    lblPTerms.Text = dsTerms.Tables[0].Rows[0]["Terms"].ToString();
                //}

            }

       }
         catch (Exception ex) { }
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
       try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string BillDate = fun.FromDate(textBillDate.Text);
            string CENVATEntryDate = fun.FromDate(textCVEntryDate.Text);

            if (textBillno.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) == true && fun.DateValidation(textCVEntryDate.Text) == true && textCVEntryNo.Text != "" && textCVEntryDate.Text != "" && txtOtherCharges.Text != "" && txtOtherChaDesc.Text != "" && txtDebitAmt.Text != "" && txtDiscount.Text != "" && fun.NumberValidationQty(txtDebitAmt.Text)==true && fun.NumberValidationQty(txtOtherCharges.Text)==true && fun.NumberValidationQty(txtDiscount.Text)==true)
            {

                string update = fun.update("tblACC_BillBooking_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',BillNo='" + textBillno.Text + "',BillDate='" + BillDate + "', CENVATEntryNo='" + textCVEntryNo.Text + "',CENVATEntryDate='" + CENVATEntryDate + "',OtherCharges='" + (txtOtherCharges.Text) + "',OtherChaDesc='" + txtOtherChaDesc.Text + "',Narration='" + txtNarration.Text + "',DebitAmt='" + Convert.ToDouble(txtDebitAmt.Text) + "',DiscountType='" + DrpAdd.SelectedValue + "',Discount='" + Convert.ToDouble(decimal.Parse((txtDiscount.Text).ToString()).ToString("N2")) + "'", "Id='" + PVEVId + "'");

                SqlCommand cmdupdate = new SqlCommand(update, con);
                cmdupdate.ExecuteNonQuery();
              
            }

            //For File upload
            string cmdget = fun.select("*", "tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND FinYearId ='" + FyId + "' AND SessionId = '" + SId + "'");
            SqlCommand command = new SqlCommand(cmdget, con);
            SqlDataAdapter da2 = new SqlDataAdapter(command);
            DataSet Dsget = new DataSet();
            da2.Fill(Dsget, "tblACC_BillBooking_Attach_Temp");
            command.ExecuteNonQuery();

            // Read uploaded file from the Stream
            if (Dsget.Tables[0].Rows.Count > 0)
            {

                for (int k = 0; k < Dsget.Tables[0].Rows.Count; k++)
                {
                    string strinsert = fun.insert("tblACC_BillBooking_Attach_Master", "MId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", "" + PVEVId + ",'" + Convert.ToInt32(Dsget.Tables[0].Rows[k]["CompId"]) + "','" + Dsget.Tables[0].Rows[k]["SessionId"].ToString() + "','" + Convert.ToInt32(Dsget.Tables[0].Rows[k]["FinYearId"]) + "','" + Dsget.Tables[0].Rows[k]["FileName"] + "','" + Dsget.Tables[0].Rows[k]["FileSize"] + "','" + Dsget.Tables[0].Rows[k]["ContentType"] + "',@TransStr");

                    using (SqlCommand cmdinsert = new SqlCommand(strinsert, con))
                    {
                        cmdinsert.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = Dsget.Tables[0].Rows[k]["FileData"];
                        cmdinsert.ExecuteNonQuery();
                    }
                }
                string DSBN = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND FinYearId ='" + FyId + "' AND SessionId = '" + SId + "'");
                SqlCommand commanddel = new SqlCommand(DSBN, con);
                commanddel.ExecuteNonQuery();

            }

            con.Close();

            Response.Redirect("BillBooking_Edit.aspx?ModId=11&SubModId=62");
        }
       
        catch (Exception ex) { }
      
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillBooking_Edit.aspx?ModId=11&SubModId=62");
    }

    public void loadData()
    {
        try
        {

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            DataTable dt = new DataTable();
            con.Open();

            string StrSql = fun.select("* ", "tblACC_BillBooking_Details", "MId='" + PVEVId + "' ");

            SqlCommand cmdSql = new SqlCommand(StrSql, con);
            SqlDataAdapter daSql = new SqlDataAdapter(cmdSql);
            DataSet DSSql = new DataSet();
            daSql.Fill(DSSql);

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GQNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GSNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Descr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("PFAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStBasic", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStEducess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStShecess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CustomDuty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CST", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("TarrifNo", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStBasicInPer", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStEducessInPer", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStShecessInPer", typeof(double)));

            DataRow dr;
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (DSSql.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DSSql.Tables[0].Rows[i]["Id"].ToString();

                    double Rate = 0;
                    double Discount = 0;
                    double Amt = 0;

                    string StrSql11 = fun.select("tblMM_PO_Details.Rate,tblMM_PO_Details.Discount", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + DSSql.Tables[0].Rows[i]["PODId"].ToString() + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id =tblMM_PO_Details.Mid ");

                    SqlCommand cmdPo11 = new SqlCommand(StrSql11, con);
                    SqlDataAdapter DAPo11 = new SqlDataAdapter(cmdPo11);
                    DataSet DSSql11 = new DataSet();
                    DAPo11.Fill(DSSql11);
                    if (DSSql11.Tables[0].Rows.Count > 0)
                    {
                        Rate = Convert.ToDouble(decimal.Parse((DSSql11.Tables[0].Rows[0]["Rate"]).ToString()).ToString("N2"));
                        Discount = Convert.ToDouble(decimal.Parse((DSSql11.Tables[0].Rows[0]["Discount"]).ToString()).ToString("N2"));
                    }

                    if (DSSql.Tables[0].Rows[i]["GQNId"].ToString() != "0")
                    {
                        string Strgqn = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + DSSql.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
                        SqlCommand cmdgqn = new SqlCommand(Strgqn, con);
                        SqlDataAdapter dagqn = new SqlDataAdapter(cmdgqn);
                        DataSet DSgqn = new DataSet();
                        dagqn.Fill(DSgqn);

                        if (DSgqn.Tables[0].Rows.Count > 0)
                        {
                            dr[1] = DSgqn.Tables[0].Rows[0]["GQNNo"].ToString();
                            double AccQty = Convert.ToDouble(decimal.Parse((DSgqn.Tables[0].Rows[0]["AcceptedQty"]).ToString()).ToString("N3"));
                            Amt = ((Rate - (Rate * Discount) / 100) * AccQty);
                        }
                        else
                        {
                            dr[1] = "NA";
                        }
                    }
                    else
                    {
                        string Strgsn = fun.select("tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + DSSql.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
                        SqlCommand cmdgsn = new SqlCommand(Strgsn, con);
                        SqlDataAdapter dagsn = new SqlDataAdapter(cmdgsn);
                        DataSet DSgsn = new DataSet();
                        dagsn.Fill(DSgsn);

                        if (DSgsn.Tables[0].Rows.Count > 0)
                        {
                            dr[2] = DSgsn.Tables[0].Rows[0]["GSNNo"].ToString();
                            double AccQty = Convert.ToDouble(decimal.Parse((DSgsn.Tables[0].Rows[0]["ReceivedQty"]).ToString()).ToString("N3"));

                            Amt = Convert.ToDouble(decimal.Parse(((Rate - (Rate * Discount) / 100) * AccQty).ToString()).ToString("N2"));
                        }
                        else
                        {
                            dr[2] = "NA";
                        }
                    }

                    string StrIcode1 = fun.select("ItemCode,ManfDesc As Descr,UOMBasic ", "tblDG_Item_Master", "Id='" + DSSql.Tables[0].Rows[i]["ItemId"].ToString() + "'");
                    SqlCommand cmdIcode1 = new SqlCommand(StrIcode1, con);
                    SqlDataAdapter daIcode1 = new SqlDataAdapter(cmdIcode1);
                    DataSet DSIcode1 = new DataSet();
                    daIcode1.Fill(DSIcode1);

                    if (DSIcode1.Tables[0].Rows.Count > 0)
                    {
                        dr[3] = DSIcode1.Tables[0].Rows[0]["ItemCode"].ToString();
                        dr[4] = DSIcode1.Tables[0].Rows[0]["Descr"].ToString();
                        // for UOM Basic  from Unit Master table
                        string sqlPurch1 = fun.select("Symbol As UOM ", "Unit_Master", "Id='" + DSIcode1.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
                        SqlCommand cmdPurch1 = new SqlCommand(sqlPurch1, con);
                        SqlDataAdapter daPurch1 = new SqlDataAdapter(cmdPurch1);
                        DataSet DSPurch1 = new DataSet();
                        daPurch1.Fill(DSPurch1);
                        if (DSPurch1.Tables[0].Rows.Count > 0)
                        {
                            dr[5] = DSPurch1.Tables[0].Rows[0][0].ToString();
                        }
                        dr[6] = Amt;
                        dr[7] = DSSql.Tables[0].Rows[i]["PFAmt"].ToString();
                        dr[8] = DSSql.Tables[0].Rows[i]["ExStBasic"].ToString();
                        dr[9] = DSSql.Tables[0].Rows[i]["ExStEducess"].ToString();
                        dr[10] = DSSql.Tables[0].Rows[i]["ExStShecess"].ToString();
                        dr[11] = DSSql.Tables[0].Rows[i]["CustomDuty"].ToString();
                        dr[12] = DSSql.Tables[0].Rows[i]["VAT"].ToString();
                        dr[13] = DSSql.Tables[0].Rows[i]["CST"].ToString();
                        dr[14] = DSSql.Tables[0].Rows[i]["Freight"].ToString();
                        dr[15] = DSSql.Tables[0].Rows[i]["TarrifNo"].ToString();
                        dr[16] = DSSql.Tables[0].Rows[i]["ExStBasicInPer"].ToString();
                        dr[17] = DSSql.Tables[0].Rows[i]["ExStEducessInPer"].ToString();
                        dr[18] = DSSql.Tables[0].Rows[i]["ExStShecessInPer"].ToString();

                    }
                }

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch(Exception ex){}


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
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
        }
        catch (Exception ex) { }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];


            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string PFAmt = decimal.Parse((((TextBox)row.FindControl("TextBoxpf")).Text).ToString()).ToString("N2");
            string BasicSerTaxInPer =decimal.Parse(( ((TextBox)row.FindControl("TextBoxExStBasicInPer")).Text).ToString()).ToString("N2");
            string EduCessInPer = decimal.Parse((((TextBox)row.FindControl("TextBoxExStEducessInPer")).Text).ToString()).ToString("N2");
            string SheCessInPer = decimal.Parse((((TextBox)row.FindControl("TextBoxExStShecessInPer")).Text).ToString()).ToString("N2");
            string BasicSerTaxAmt = decimal.Parse((((TextBox)row.FindControl("TextBoxExStBasic")).Text).ToString()).ToString("N2");
            string EduCessAmt = decimal.Parse((((TextBox)row.FindControl("TextBoxExStEducess")).Text).ToString()).ToString("N2");
            string SheCessAmt = decimal.Parse((((TextBox)row.FindControl("TextBoxExStShecess")).Text).ToString()).ToString("N2");
            string CustomDuty = decimal.Parse((((TextBox)row.FindControl("TextBoxCustomDuty")).Text).ToString()).ToString("N2");
            string VAT = decimal.Parse((((TextBox)row.FindControl("TextBoxVAT")).Text).ToString()).ToString("N2");
            string CST =decimal.Parse((((TextBox)row.FindControl("TextBoxCST")).Text).ToString()).ToString("N2");
            string Freight = decimal.Parse((((TextBox)row.FindControl("TextBoxFreight")).Text).ToString()).ToString("N2");
            string TarrifNo = ((TextBox)row.FindControl("TextBoxTarrifNo")).Text;


            if (PFAmt != "" && BasicSerTaxInPer != "" && EduCessInPer != "" && SheCessInPer != "" && BasicSerTaxAmt != "" && EduCessAmt != "" && SheCessAmt != "" && CustomDuty != "" && VAT != "" && CST != "" && Freight != "" && TarrifNo != "" && fun.NumberValidationQty(PFAmt) == true && fun.NumberValidationQty(BasicSerTaxInPer) == true && fun.NumberValidationQty(EduCessInPer) == true && fun.NumberValidationQty(SheCessInPer) == true && fun.NumberValidationQty(BasicSerTaxAmt) == true && fun.NumberValidationQty(EduCessAmt) == true && fun.NumberValidationQty(SheCessAmt) == true && fun.NumberValidationQty(CustomDuty) == true && fun.NumberValidationQty(VAT) == true && fun.NumberValidationQty(CST) == true && fun.NumberValidationQty(Freight) == true)
            {
                string StrSqlMId = fun.select("MId", "tblACC_BillBooking_Details", "Id='" + id + "'");
                SqlCommand cmdSqlMId = new SqlCommand(StrSqlMId, con);
                SqlDataAdapter daSqlMId = new SqlDataAdapter(cmdSqlMId);
                DataSet DSSqlMId = new DataSet();
                daSqlMId.Fill(DSSqlMId);
                if (DSSqlMId.Tables[0].Rows.Count > 0)
                {
                    string upd = fun.update("tblACC_BillBooking_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "'", "Id='" + DSSqlMId.Tables[0].Rows[0]["MId"].ToString() + "'");
                    SqlCommand cmd = new SqlCommand(upd, con);
                    cmd.ExecuteNonQuery();

                }

                string upd1 = fun.update("tblACC_BillBooking_Details", "PFAmt='" + Convert.ToDouble(PFAmt) + "', ExStBasicInPer='" + Convert.ToDouble(BasicSerTaxInPer) + "', ExStEducessInPer='" + Convert.ToDouble(EduCessInPer) + "', ExStShecessInPer='" + Convert.ToDouble(SheCessInPer) + "', ExStBasic='" + Convert.ToDouble(BasicSerTaxAmt) + "', ExStEducess='" + Convert.ToDouble(EduCessAmt) + "' , ExStShecess='" + Convert.ToDouble(SheCessAmt) + "', CustomDuty='" + Convert.ToDouble(CustomDuty) + "', VAT='" + Convert.ToDouble(VAT) + "', CST='" + (CST) + "', Freight='" + Convert.ToDouble(Freight) + "' , TarrifNo='" + TarrifNo + "'", "Id='" + id + "'");
                SqlCommand cmd2 = new SqlCommand(upd1, con);

                cmd2.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Page.Request.Url.ToString(), true);

            }
            else
            {
                string mystring = string.Empty;
                mystring = "Input data is invalid.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }

       catch(Exception ex){}
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



    protected void Button1_Click(object sender, EventArgs e) //Upload Image/File
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            string strfilename = "";
            HttpPostedFile myfile = FileUpload1.PostedFile;
            Byte[] mydata = null;

            if (FileUpload1.PostedFile != null)
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                mydata = br.ReadBytes((Int32)fs.Length);
                strfilename = Path.GetFileName(myfile.FileName);
            }
            if (strfilename != "")
            {

                string cmdstr = fun.insert("tblACC_BillBooking_Attach_Master", "MId,SessionId,CompId,FinYearId,FileName,FileSize,ContentType,FileData", "'" + PVEVId + "','" + SId + "','" + CompId + "','" + FyId + "','" + strfilename + "','" + mydata.Length + "','" + myfile.ContentType + "',@Data");


                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.Parameters.AddWithValue("@Data", mydata);
                fun.InsertUpdateData(cmd);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }
        catch (Exception exx)
        {

        }
    }




    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[0].Controls[0];
                del.Attributes.Add("onclick", "return confirmationDelete();");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink del1 = (HyperLink)e.Row.Cells[4].Controls[0];
                del1.Attributes.Add("onclick", "return confirmation();");
            }
        }
        catch (Exception ex) { }
    }



}
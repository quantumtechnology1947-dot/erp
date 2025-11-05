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
using System.Collections.Generic;
using System.Web.Mail;

public partial class Module_Accounts_Transactions_BillBooking_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SId = string.Empty;    
    string PId = string.Empty;
    string SupplierNo = string.Empty;
    string PVEVNo1 = string.Empty;
    double FGT = 0;
    int FyId = 0;
    int CompId = 0;
    int ST = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SupplierNo = Request.QueryString["SUPId"].ToString();
            FGT = Convert.ToDouble(Request.QueryString["FGT"]);
            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Session["finyear"]);
            ST = Convert.ToInt32(Request.QueryString["ST"]);

            Iframe1.Attributes.Add("src", "BillBooking_ItemGrid.aspx?SUPId=" + SupplierNo + "&FGT=" + FGT + "&FyId=" + FyId + "&ST=" + ST + "");
            
            //if (!IsPostBack)
            {
                // For Selected Items
                this.LoadDataSelectedItems();

                // For Supplier Details  
                string cmdStr = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "'And CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                SqlDataReader DS = cmd.ExecuteReader();
                DS.Read();
                
                if (DS.HasRows == true)
                {
                    lblSupplierName.Text = DS["SupplierName"].ToString() + " [" + DS["SupplierId"].ToString() + "]";

                    string strcmd1 = fun.select("CountryName", "tblcountry", "CId='" + DS["RegdCountry"] + "'");
                    SqlCommand Cmd1 = new SqlCommand(strcmd1, con);
                    SqlDataReader ds1 = Cmd1.ExecuteReader();
                    ds1.Read();

                    string strcmd2 = fun.select("StateName", "tblState", "SId='" + DS["RegdState"] + "'");
                    SqlCommand Cmd2 = new SqlCommand(strcmd2, con);                    
                    SqlDataReader ds2 = Cmd2.ExecuteReader();
                    ds2.Read();

                    string strcmd3 = fun.select("CityName", "tblCity", "CityId='" + DS["RegdCity"] + "'");
                    SqlCommand Cmd3 = new SqlCommand(strcmd3, con);
                    SqlDataReader ds3 = Cmd3.ExecuteReader();
                    ds3.Read();

                    lblSupplierAdd.Text = DS["RegdAddress"].ToString() + ",<br>" + ds3["CityName"].ToString() + "," + ds2["StateName"].ToString() + ",<br>" + ds1["CountryName"].ToString() + ".<br>" + DS["RegdPinNo"].ToString() + "." + "<br>";

                    //Supplier Details
                    lblECCno.Text = DS["EccNo"].ToString();
                    lblDivision.Text = DS["Divn"].ToString();
                    lblVatNo.Text = DS["TinVatNo"].ToString();
                    lblRange.Text = DS["Range"].ToString();
                    lblComm.Text = DS["Commissionurate"].ToString();
                    lblCSTNo.Text = DS["TinCstNo"].ToString();
                    lblServiceTax.Text = "-";
                    lblTDS.Text = DS["TDSCode"].ToString();
                    lblPanNo.Text = DS["PanNo"].ToString();
                }
            }

            if (!IsPostBack)
            { 
                this.TDSGrid();  
            }

            con.Close();
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

                string cmdstr = fun.insert("tblACC_BillBooking_Attach_Temp", "SessionId,CompId,FinYearId,FileName,FileSize,ContentType,FileData", "'" + SId + "','" + CompId + "','" + FyId + "','" + strfilename + "','" + mydata.Length + "','" + myfile.ContentType + "',@Data");

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
    protected void BtnNext1_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void BtnNext2_Click1(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 2;
    }
    protected void BtnNext3_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 3;
        this.TDSGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BillBooking_New.aspx?ModId=11&SubModId=62");
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

            // For PVEV No and PoNo
            string Strpvevno1 = fun.select("PVEVNo", "tblACC_BillBooking_Master", "CompId='" + CompId + "' AND FinYearId='" + FyId + "' order by PVEVNo desc");

            SqlCommand cmdpvevno1 = new SqlCommand(Strpvevno1, con);
            SqlDataAdapter DApvevno1 = new SqlDataAdapter(cmdpvevno1);
            DataSet DSpvevno1 = new DataSet();
            DApvevno1.Fill(DSpvevno1, "tblACC_BillBooking_Master");                       

            if (DSpvevno1.Tables[0].Rows.Count > 0)
            {
                PVEVNo1 = (Convert.ToInt32(DSpvevno1.Tables[0].Rows[0]["PVEVNo"]) + 1).ToString("D4");
            }
            else
            {
                PVEVNo1 = "0001";
            }
            
            ///////

            if (textBillno.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) == true && textCVEntryNo.Text != "" && textCVEntryDate.Text != "" && fun.DateValidation(textCVEntryDate.Text) == true && txtOtherCharges.Text != "" && txtOtherChaDesc.Text != "" && txtDebitAmt.Text != "" && txtDiscount.Text != "" && fun.NumberValidationQty(txtOtherCharges.Text) == true && fun.NumberValidationQty(txtDebitAmt.Text) == true && fun.NumberValidationQty(txtDiscount.Text) == true)
            {
                //If GSN Item Check TDS is selection & its deduciton.

                string ckTemp = "SELECT tblACC_BillBooking_Details_Temp.Id,tblACC_BillBooking_Details_Temp.ACHead FROM tblACC_BillBooking_Details_Temp INNER JOIN AccHead ON tblACC_BillBooking_Details_Temp.ACHead = AccHead.Id AND tblACC_BillBooking_Details_Temp.SessionId='" + SId + "' AND tblACC_BillBooking_Details_Temp.CompId='" + CompId + "' AND AccHead.Symbol like 'E%'";

                SqlCommand cmdckTemp = new SqlCommand(ckTemp, con);
                SqlDataReader DSckTemp = cmdckTemp.ExecuteReader();
                DSckTemp.Read();
                                
                int SectionNo = 0;

                if (DSckTemp.HasRows == true)
                {
                    if (((RadioButton)GridView4.Controls[0].Controls[0].FindControl("RadioButton2")).Checked == false)
                    {                        
                        foreach (GridViewRow grv in GridView4.Rows)
                        {
                            if (((RadioButton)grv.FindControl("RadioButton1")).Checked == true)
                            {
                                SectionNo = Convert.ToInt32(((Label)grv.FindControl("Id")).Text);
                            }
                        }
                    }
                }

                string sqltemp = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
                SqlCommand cmdtemp = new SqlCommand(sqltemp, con);
                SqlDataAdapter datemp = new SqlDataAdapter(cmdtemp);
                DataSet DStemp = new DataSet();
                datemp.Fill(DStemp);

                if (DStemp.Tables[0].Rows.Count > 0)
                {
                    string sqlbill = fun.insert("tblACC_BillBooking_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PVEVNo,SupplierId,BillNo,BillDate, CENVATEntryNo,CENVATEntryDate,OtherCharges,OtherChaDesc,Narration,DebitAmt,DiscountType,Discount,InvoiceType,AHId,TDSCode", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FyId + "','" + PVEVNo1 + "','" + SupplierNo + "','" + textBillno.Text + "','" + BillDate + "','" + textCVEntryNo.Text + "','" + CENVATEntryDate + "','" + txtOtherCharges.Text + "','" + txtOtherChaDesc.Text + "','" + txtNarration.Text + "','" + txtDebitAmt.Text + "','" + DrpAdd.SelectedValue + "','" + decimal.Parse((txtDiscount.Text).ToString()).ToString("N2") + "','" + ST + "','" + DStemp.Tables[0].Rows[0]["ACHead"].ToString() + "','" + SectionNo + "'");

                    Response.Write(sqlbill);

                    SqlCommand cmdbill = new SqlCommand(sqlbill, con);
                    cmdbill.ExecuteNonQuery();

                    string sqlMId = fun.select1("Id", "tblACC_BillBooking_Master Order by Id Desc");
                    SqlCommand cmdMId = new SqlCommand(sqlMId, con);
                    SqlDataAdapter daMId = new SqlDataAdapter(cmdMId);
                    DataSet DSMId = new DataSet();
                    daMId.Fill(DSMId);

                    //For File upload
                    string cmdget = fun.select("*", "tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
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
                            string strinsert = fun.insert("tblACC_BillBooking_Attach_Master", "MId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", "" + DSMId.Tables[0].Rows[0][0].ToString() + ",'" + Convert.ToInt32(Dsget.Tables[0].Rows[k]["CompId"]) + "','" + Dsget.Tables[0].Rows[k]["SessionId"].ToString() + "','" + Convert.ToInt32(Dsget.Tables[0].Rows[k]["FinYearId"]) + "','" + Dsget.Tables[0].Rows[k]["FileName"] + "','" + Dsget.Tables[0].Rows[k]["FileSize"] + "','" + Dsget.Tables[0].Rows[k]["ContentType"] + "',@TransStr");

                            using (SqlCommand cmdinsert = new SqlCommand(strinsert, con))
                            {
                                cmdinsert.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = Dsget.Tables[0].Rows[k]["FileData"];
                                cmdinsert.ExecuteNonQuery();
                            }
                        }

                        string DSBN = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
                        SqlCommand commanddel = new SqlCommand(DSBN, con);
                        commanddel.ExecuteNonQuery();
                    }

                    if (DSMId.Tables[0].Rows.Count > 0)
                    {
                        //Code for inserting Details in tblACC_BillBooking_Details table.                        
                        
                        int MId = Convert.ToInt32(DSMId.Tables[0].Rows[0]["Id"].ToString());                        
                        
                        List<int> ListPOId = new List<int>();

                        for (int k = 0; k < DStemp.Tables[0].Rows.Count; k++)
                        {
                            string strdetail = fun.insert("tblACC_BillBooking_Details", "MId,PODId,GQNId , GSNId, ItemId,DebitType,DebitValue,PFAmt,ExStBasicInPer,ExStEducessInPer,ExStShecessInPer, ExStBasic, ExStEducess, ExStShecess, CustomDuty, VAT, CST, Freight, TarrifNo,BCDOpt,BCD,BCDValue,ValueForCVD,ValueForEdCessCD,EdCessOnCDOpt,EdCessOnCD,EdCessOnCDValue,SHEDCessOpt,SHEDCess,SHEDCessValue,TotDuty,TotDutyEDSHED,Insurance,ValueWithDuty", "'" + MId + "','" + DStemp.Tables[0].Rows[k]["PODId"].ToString() + "','" + DStemp.Tables[0].Rows[k]["GQNId"].ToString() + "','" + DStemp.Tables[0].Rows[k]["GSNId"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ItemId"].ToString() + "','" + DStemp.Tables[0].Rows[k]["DebitType"].ToString() + "','" + DStemp.Tables[0].Rows[k]["DebitValue"].ToString() + "','" + DStemp.Tables[0].Rows[k]["PFAmt"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStBasicInPer"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStEducessInPer"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStShecessInPer"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStBasic"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStEducess"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ExStShecess"].ToString() + "','" + DStemp.Tables[0].Rows[k]["CustomDuty"].ToString() + "','" + DStemp.Tables[0].Rows[k]["VAT"].ToString() + "','" + DStemp.Tables[0].Rows[k]["CST"].ToString() + "','" + DStemp.Tables[0].Rows[k]["Freight"].ToString() + "','" + DStemp.Tables[0].Rows[k]["TarrifNo"].ToString() + "','" + DStemp.Tables[0].Rows[k]["BCDOpt"].ToString() + "','" + DStemp.Tables[0].Rows[k]["BCD"].ToString() + "','" + DStemp.Tables[0].Rows[k]["BCDValue"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ValueForCVD"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ValueForEdCessCD"].ToString() + "','" + DStemp.Tables[0].Rows[k]["EdCessOnCDOpt"].ToString() + "','" + DStemp.Tables[0].Rows[k]["EdCessOnCD"].ToString() + "','" + DStemp.Tables[0].Rows[k]["EdCessOnCDValue"].ToString() + "','" + DStemp.Tables[0].Rows[k]["SHEDCessOpt"].ToString() + "','" + DStemp.Tables[0].Rows[k]["SHEDCess"].ToString() + "','" + DStemp.Tables[0].Rows[k]["SHEDCessValue"].ToString() + "','" + DStemp.Tables[0].Rows[k]["TotDuty"].ToString() + "','" + DStemp.Tables[0].Rows[k]["TotDutyEDSHED"].ToString() + "','" + DStemp.Tables[0].Rows[k]["Insurance"].ToString() + "','" + DStemp.Tables[0].Rows[k]["ValueWithDuty"].ToString() + "'");

                            SqlCommand cmddetail = new SqlCommand(strdetail, con);
                            cmddetail.ExecuteNonQuery(); 
                        }
                        
                        ///////////////////////// PO Amendment Process

                        string sqlDist = fun.select("Distinct(POId) as POId", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' AND CKPF>0 OR CKEX>0 OR CKVATCST>0 OR RateOpt>0 OR DiscOpt>0");
                        SqlCommand cmdDist = new SqlCommand(sqlDist, con);
                        SqlDataReader drDist = cmdDist.ExecuteReader();

                        while (drDist.Read())
                        {
                            //Amendment of PO Master/////////////////////////

                            string StrPoM = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND Id='" + drDist["POId"] + "'");
                            SqlCommand cmdPoM = new SqlCommand(StrPoM, con);
                            SqlDataAdapter daPoM = new SqlDataAdapter(cmdPoM);
                            DataSet DSPoM = new DataSet();
                            daPoM.Fill(DSPoM);

                            //Shift PO Master Data to PO Amendment

                            string StrPoAM = fun.insert("tblMM_PO_Amd_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,POId,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Freight,Octroi,ModeOfDispatch,Inspection,Remarks,Checked,CheckedBy,CheckedDate,CheckedTime,Approve,ApprovedBy,ApproveDate,ApproveTime,Authorize,AuthorizedBy,AuthorizeDate,AuthorizeTime,ShipTo,AmendmentNo,Warrenty,Insurance", "'" + DSPoM.Tables[0].Rows[0]["SysDate"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["SysTime"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["SessionId"].ToString() + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["CompId"]) + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["FinYearId"]) + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["PRSPRFlag"]) + "','" + DSPoM.Tables[0].Rows[0]["Id"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["PONo"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["SupplierId"].ToString() + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["Reference"]) + "','" + DSPoM.Tables[0].Rows[0]["ReferenceDate"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["ReferenceDesc"].ToString() + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["PaymentTerms"]) + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["Freight"]) + "','" + Convert.ToInt32(DSPoM.Tables[0].Rows[0]["Octroi"]) + "','" + DSPoM.Tables[0].Rows[0]["ModeOfDispatch"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Inspection"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Remarks"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Checked"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["CheckedBy"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["CheckedDate"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["CheckedTime"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Approve"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["ApprovedBy"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["ApproveDate"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["ApproveTime"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Authorize"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["AuthorizeDate"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["AuthorizeTime"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["ShipTo"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Warrenty"].ToString() + "','" + DSPoM.Tables[0].Rows[0]["Insurance"].ToString() + "'");
                            SqlCommand cmdPoAM = new SqlCommand(StrPoAM, con);
                            cmdPoAM.ExecuteNonQuery();

                            int AmdId = 0;
                            string cmdAmd = fun.select("AmendmentNo,Id", "tblMM_PO_Amd_Master", "CompId='" + CompId + "' order by Id desc");
                            SqlCommand cmd1 = new SqlCommand(cmdAmd, con);
                            SqlDataAdapter daAmd = new SqlDataAdapter(cmd1);
                            DataSet DSAmd = new DataSet();
                            daAmd.Fill(DSAmd);

                            if (DSAmd.Tables[0].Rows.Count > 0)
                            {
                                AmdId = Convert.ToInt32(DSAmd.Tables[0].Rows[0]["Id"]);
                            }

                            //Update PO Master with New Data

                            string AmendmentNo = string.Empty;

                            if (DSPoM.Tables[0].Rows.Count > 0)
                            {
                                int PONstr = Convert.ToInt32(DSPoM.Tables[0].Rows[0]["AmendmentNo"].ToString()) + 1;
                                AmendmentNo = PONstr.ToString();
                            }
                            else
                            {
                                AmendmentNo = "0";
                            }

                            string StrPoMUpdate = fun.update("tblMM_PO_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',AmendmentNo='" + AmendmentNo + "'", "Id='" + drDist["POId"] + "'");

                            SqlCommand cmdPoMU = new SqlCommand(StrPoMUpdate, con);
                            cmdPoMU.ExecuteNonQuery();

                            //Auto Mail
                            MailMessage msg = new MailMessage();                    
                            string sqlmailserverip = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");                            
                            SqlCommand cmd4 = new SqlCommand(sqlmailserverip, con);
                            SqlDataReader rdr4 = cmd4.ExecuteReader();

                            while (rdr4.Read())
                            {
                                SmtpMail.SmtpServer = rdr4["MailServerIp"].ToString();
                                msg.From = rdr4["ErpSysmail"].ToString();
                                msg.To = "sdshinde@sapl.com;monali@sapl.com;";
                                msg.Subject = "Amendment in PO: " + DSPoM.Tables[0].Rows[0]["PONo"].ToString();
                                msg.Body = "<br>PO No." + DSPoM.Tables[0].Rows[0]["PONo"].ToString() + " is Amended at the time of bill booking process, <br><br>This is Auto generated mail from ERP system,please do not reply.<br><br> Thank you.<br>ERP System";
                                msg.BodyFormat = MailFormat.Html;
                                SmtpMail.Send(msg);
                            }
                            
                            //Amedment of PO Details//////////////////////

                            string sql6 = fun.select("*", "tblMM_PO_Details", "MId='" + drDist["POId"] + "'");
                            SqlCommand cmd6 = new SqlCommand(sql6, con);
                            SqlDataReader dr6 = cmd6.ExecuteReader();

                            while (dr6.Read())
                            {
                                string StrPoDetails = fun.insert("tblMM_PO_Amd_Details", "MId,PONo,PRNo,PRId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,AmendmentNo,BudgetCode,PODId", "'" + AmdId + "','" + dr6["PONo"].ToString() + "','" + dr6["PRNo"].ToString() + "','" + dr6["PRId"].ToString() + "','" + dr6["SPRNo"].ToString() + "','" + dr6["SPRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dr6["Qty"].ToString()).ToString("N3")) + "','" + dr6["Rate"].ToString() + "','" + dr6["Discount"].ToString() + "','" + dr6["AddDesc"].ToString() + "','" + dr6["PF"].ToString() + "','" + dr6["ExST"].ToString() + "','" + dr6["VAT"].ToString() + "','" + dr6["DelDate"].ToString() + "','" + dr6["AmendmentNo"].ToString() + "','" + dr6["BudgetCode"].ToString() + "','" + dr6["Id"].ToString() + "'");
                                SqlCommand cmdPoDetails = new SqlCommand(StrPoDetails, con);
                                cmdPoDetails.ExecuteNonQuery();
                            }

                            string sqlAmdPO = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' AND POId='" + drDist["POId"] + "' AND CKPF>0 OR CKEX>0 OR CKVATCST>0 OR RateOpt>0 OR DiscOpt>0");
                            SqlCommand cmdAmdPO = new SqlCommand(sqlAmdPO, con);
                            SqlDataReader drAmdPO = cmdAmdPO.ExecuteReader();

                            while (drAmdPO.Read())
                            {
                                string GetRate = string.Empty;
                                string GetDisc = string.Empty;
                                string GetPF = string.Empty;
                                string GetEx = string.Empty;
                                string GetVatCst = string.Empty;

                                if (drAmdPO["RateOpt"].ToString()=="1")
                                {
                                    GetRate=",Rate='" + drAmdPO["Rate"].ToString() + "'";
                                }

                                if (drAmdPO["DiscOpt"].ToString()=="1")
                                {
                                    GetDisc = ",Discount='" + drAmdPO["Disc"].ToString() + "'";
                                }

                                if (drAmdPO["CKPF"].ToString() == "1")
                                {
                                    GetPF = ",PF='" + drAmdPO["PFOpt"].ToString() + "'";
                                }

                                if (drAmdPO["CKEX"].ToString() == "1")
                                {
                                    GetEx = ",ExST='" + drAmdPO["ExciseOpt"].ToString() + "'";
                                }

                                if (drAmdPO["CKVATCST"].ToString() == "1")
                                {
                                    GetVatCst = ",VAT='" + drAmdPO["VATCSTOpt"].ToString() + "'";
                                }

                                string StrPoDetails_upd = string.Empty;

                                StrPoDetails_upd=fun.update("tblMM_PO_Details", "AmendmentNo='" + AmendmentNo + "'" + GetRate + "" + GetDisc + "" + GetPF + "" + GetEx + "" + GetVatCst + "", "Id='" + drAmdPO["PODId"].ToString() + "'");

                                SqlCommand cmdPo_upd = new SqlCommand(StrPoDetails_upd, con);
                                cmdPo_upd.ExecuteNonQuery();
                                
                                //Update Rate Register

                                if (drAmdPO["RateOpt"].ToString()=="1" || drAmdPO["DiscOpt"].ToString()=="1")
                                {
                                    string podetailsql = "SELECT tblMM_PO_Details.PRId, tblMM_PO_Details.SPRId FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId AND tblMM_PO_Details.Id = '" + drAmdPO["PODId"].ToString() + "'";
                                    SqlCommand cmdpodetailsql = new SqlCommand(podetailsql,con);
                                    SqlDataReader drpodetailsql = cmdpodetailsql.ExecuteReader();
                                    drpodetailsql.Read();

                                    string sql8 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,PRId,SPRId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + DSPoM.Tables[0].Rows[0]["PONo"].ToString() + "','" + drAmdPO["ItemId"].ToString() + "','" + drAmdPO["Rate"].ToString() + "','" + drAmdPO["Disc"].ToString() + "','" + drAmdPO["PFOpt"].ToString() + "','" + drAmdPO["ExciseOpt"].ToString() + "','" + drAmdPO["VATCSTOpt"].ToString() + "','" + AmendmentNo + "','" + drAmdPO["POId"].ToString() + "','" + drpodetailsql["PRId"].ToString() + "','" + drpodetailsql["SPRId"].ToString() + "'");

                                    SqlCommand cmd8 = new SqlCommand(sql8, con);
                                    cmd8.ExecuteNonQuery();
                                }
                            }
                        }

                        //////////////////////////////////////

                        // Code for deleting Details in tblACC_BillBooking_Details_Temp table.
                        string strDelete = fun.delete("tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
                        SqlCommand cmddelete = new SqlCommand(strDelete, con);
                        cmddelete.ExecuteNonQuery();
                        
                        Response.Redirect("BillBooking_New.aspx?ModId=11&SubModId=62");                        
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Please fill the PO Term details.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Input data is invalid.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
       catch (Exception ex) { }    
    }  
    public void LoadDataSelectedItems()
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
        con.Open();

        try
        {           
            double SumCurrentTempQty = 0;           
            double SumTempQty = 0;

            string SqlTemp = fun.select("GQNAmt+GSNAmt As Sum_GQNGSN_Amt,PFAmt,ExStBasic+ExStEducess+ExStShecess As Excise_Amt,DebitType,DebitValue,BCDValue,EdCessOnCDValue,SHEDCessValue", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CompId + "'");
            SqlCommand cmdTemp = new SqlCommand(SqlTemp, con);
            SqlDataReader DSTemp = cmdTemp.ExecuteReader();

            while (DSTemp.Read())
            {
                double xGQNGSNAmt = 0;
                double xPFAmt = 0;
                double xExciseAmt = 0;
                double xDebitValue = 0;
                double Calx = 0;
                double BCDValue = 0;
                double EdCessOnCDValue = 0;
                double SHEDCessValue = 0;

                xGQNGSNAmt = Convert.ToDouble(DSTemp["Sum_GQNGSN_Amt"].ToString());
                xPFAmt = Convert.ToDouble(DSTemp["PFAmt"].ToString());
                xExciseAmt = Convert.ToDouble(DSTemp["Excise_Amt"].ToString());
                xDebitValue = Convert.ToDouble(DSTemp["DebitValue"].ToString());
                BCDValue = Convert.ToDouble(DSTemp["BCDValue"].ToString());
                EdCessOnCDValue = Convert.ToDouble(DSTemp["EdCessOnCDValue"].ToString());
                SHEDCessValue = Convert.ToDouble(DSTemp["SHEDCessValue"].ToString());

                switch (Convert.ToInt32(DSTemp["DebitType"].ToString()))
                {
                    case 1:
                        Calx = xGQNGSNAmt - xDebitValue;
                        break;
                    case 2:
                        Calx = xGQNGSNAmt - (xGQNGSNAmt * xDebitValue / 100);
                        break;
                    case 0:
                        Calx = xGQNGSNAmt;
                        break;
                }

                SumTempQty += Calx + xPFAmt + xExciseAmt + BCDValue + EdCessOnCDValue + SHEDCessValue;
            }         

            dt.Columns.Add(new System.Data.DataColumn("GQNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GQNAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("GSNNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GSNAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMPurch", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PfAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStBasic", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStEducess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ExStShecess", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CustomDuty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("VAT", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("CST", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Freight", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("TarrifNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TotalAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DebitType", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DebitValue", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DebitAmt", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DCNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(double)));
          
            DataRow dr;
            string ItemCode = "";
            string PurchDesc = "";
            string UomPurch = "";
            double totAmt = 0;

            string sqlGsn = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' Order By Id Desc");
            SqlCommand cmdGsn = new SqlCommand(sqlGsn, con);
            SqlDataReader DSGsn = cmdGsn.ExecuteReader();
                        
            double runningtotal = 0;

            while (DSGsn.Read())
            {
                double Freight = 0;
                double bAmt = 0;
                double UpVAT = 0;
                double UpCST = 0;
                dr = dt.NewRow();

                string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + DSGsn["ItemId"].ToString() + "' AND CompId='" + CompId + "' ");

                SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                SqlDataReader DSIcode = cmdIcode.ExecuteReader();
                DSIcode.Read();
                
                // For ItemCode
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

                    if (DSPurch.HasRows == true)
                    {
                        UomPurch = DSPurch["Symbol"].ToString();
                    }
                }

                string Strgqn = fun.select("tblQc_MaterialQuality_Master.GQNNo", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Details.Id='" + DSGsn["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId");
                SqlCommand cmdgqn = new SqlCommand(Strgqn, con);
                SqlDataReader DSgqn = cmdgqn.ExecuteReader();
                DSgqn.Read();

                if (DSgqn.HasRows == true)
                {
                    dr[0] = DSgqn["GQNNo"].ToString();
                }
                else
                {
                    dr[0] = "NA";
                }

                dr[1] = Convert.ToDouble(decimal.Parse((DSGsn["GQNAmt"]).ToString()).ToString("N2"));

                string Strgsn1 = fun.select("tblinv_MaterialServiceNote_Master.GSNNo", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + DSGsn["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");

                SqlCommand cmdgsn1 = new SqlCommand(Strgsn1, con);
                SqlDataReader DSgsn1 = cmdgsn1.ExecuteReader();
                DSgsn1.Read();

                if (DSgsn1.HasRows == true)
                {
                    dr[2] = DSgsn1["GSNNo"].ToString();
                }
                else
                {
                    dr[2] = "NA";
                }

                dr[3] = Convert.ToDouble(decimal.Parse((DSGsn["GSNAmt"]).ToString()).ToString("N2"));
                dr[4] = ItemCode;
                dr[5] = PurchDesc;
                dr[6] = UomPurch;
                dr[7] = Convert.ToDouble(decimal.Parse((DSGsn["PFAmt"]).ToString()).ToString("N2"));
                dr[8] = DSGsn["ExStBasic"].ToString();
                dr[9] = DSGsn["ExStEducess"].ToString();
                dr[10] = DSGsn["ExStShecess"].ToString();
                dr[11] = DSGsn["CustomDuty"].ToString();
                dr[12] = DSGsn["VAT"].ToString();
                dr[13] = DSGsn["CST"].ToString();

                //DSGsn.Tables[0].Rows[i]["Freight"].ToString()

                double UpVATValue = 0;

                string StrVat99 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + DSGsn["VATCSTOpt"].ToString() + "'");
                SqlCommand cmdVat99 = new SqlCommand(StrVat99, con);
                SqlDataReader DSVat99 = cmdVat99.ExecuteReader();
                DSVat99.Read();

                UpVATValue = Convert.ToDouble(DSVat99[0]);

                int IsVat = 0;
                int IsCst = 0;

                IsVat = Convert.ToInt32(DSVat99["IsVAT"]);
                IsCst = Convert.ToInt32(DSVat99["IsCST"]);

                double GQN_GSN_PF_Excise = 0;

                if (DSGsn["GQNId"].ToString() != "0")
                {
                    double a = 0;
                    dr[22] = DSGsn["GQNAmt"].ToString();
                   
                    a = Convert.ToDouble(DSGsn["GQNAmt"].ToString());

                    GQN_GSN_PF_Excise = a + Convert.ToDouble(DSGsn["PFAmt"].ToString()) + Convert.ToDouble(DSGsn["ExStBasic"].ToString()) + Convert.ToDouble(DSGsn["ExStEducess"].ToString()) + Convert.ToDouble(DSGsn["ExStShecess"].ToString()) + Convert.ToDouble(DSGsn["BCDValue"]) + Convert.ToDouble(DSGsn["EdCessOnCDValue"]) + Convert.ToDouble(DSGsn["SHEDCessValue"]);
                    
                    if (SumTempQty > 0)
                    {
                        Freight = Math.Round((FGT * GQN_GSN_PF_Excise / SumTempQty), 2);
                    }
                    else
                    {
                        Freight = FGT;
                    }

                    bAmt = GQN_GSN_PF_Excise;

                    if (IsVat == 1)
                    {
                        //bAmt = GQN_GSN_PF_Excise + Freight;
                        double vat1 = (((bAmt+ Freight) * UpVATValue) / 100);
                        UpVAT = Math.Round(vat1, 2);
                    }
                    else if (IsCst == 1)
                    {
                        //bAmt = GQN_GSN_PF_Excise;
                        double vat2 = ((bAmt * UpVATValue) / 100);
                        UpCST = Math.Round(vat2, 2);
                    }

                    dr[16] = bAmt + UpVAT + UpCST ;
                    runningtotal += bAmt + UpVAT + UpCST;
                   
                }
                else if (DSGsn["GSNId"].ToString() != "0")
                {                    
                    double b = 0;
                    dr[22] = DSGsn["GSNAmt"].ToString();                   
                    b = Convert.ToDouble(DSGsn["GSNAmt"].ToString());

                    GQN_GSN_PF_Excise = b + Convert.ToDouble(DSGsn["PFAmt"].ToString()) + Convert.ToDouble(DSGsn["ExStBasic"].ToString()) + Convert.ToDouble(DSGsn["ExStEducess"].ToString()) + Convert.ToDouble(DSGsn["ExStShecess"].ToString()) + Convert.ToDouble(DSGsn["BCDValue"]) + Convert.ToDouble(DSGsn["EdCessOnCDValue"]) + Convert.ToDouble(DSGsn["SHEDCessValue"]);

                    if (SumTempQty > 0)
                    {
                        Freight = Math.Round((FGT * GQN_GSN_PF_Excise / SumTempQty), 2);
                    }
                    else
                    {
                        Freight = FGT;
                    }
                    
                    bAmt = GQN_GSN_PF_Excise;

                    if (IsVat == 1)
                    {
                        //bAmt = GQN_GSN_PF_Excise + Freight;
                        double vat1 = (((bAmt+Freight) * UpVATValue) / 100);
                        UpVAT = Math.Round(vat1, 2);
                    }
                    else if (IsCst == 1)
                    {
                        //bAmt = GQN_GSN_PF_Excise;
                        double vat2 = ((bAmt * UpVATValue) / 100);
                        UpCST = Math.Round(vat2, 2);
                    }

                    dr[16] = bAmt + UpVAT + UpCST;
                    runningtotal += bAmt + UpVAT + UpCST;
                }

                dr[14] = Freight.ToString();
                dr[15] = DSGsn["TarrifNo"].ToString();
                dr[17] = DSGsn["Id"].ToString();

                string Strpono = fun.select("tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.Id='" + DSGsn["PODId"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
                
                SqlCommand cmdpono = new SqlCommand(Strpono, con);
                SqlDataReader DSpono = cmdpono.ExecuteReader();
                DSpono.Read();

                if (DSpono.HasRows == true)
                {
                    dr[18] = DSpono["PONo"].ToString();
                    dr[19] = fun.FromDateDMY(DSpono["SysDate"].ToString());
                }

                if (DSGsn["DebitType"].ToString() == "2")
                {
                    dr[20] = "%";
                }
                
                dr[21] = DSGsn["DebitValue"].ToString();

                if (Convert.ToInt32(DSGsn["GQNId"].ToString()) != 0)
                {
                    string strGqn1 = " SELECT tblInv_Inward_Master.ChallanNo, tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty FROM  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN   tblinv_MaterialReceived_Master INNER JOIN tblinv_MaterialReceived_Details ON tblinv_MaterialReceived_Master.Id = tblinv_MaterialReceived_Details.MId INNER JOIN tblInv_Inward_Master INNER JOIN  tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND   tblinv_MaterialReceived_Master.GINId = tblInv_Inward_Master.Id AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON   tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Master.GRRNo = tblinv_MaterialReceived_Master.GRRNo AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id AND tblQc_MaterialQuality_Details.Id='" + DSGsn["GQNId"].ToString() + "' ";

                    SqlCommand Cmdgqn1 = new SqlCommand(strGqn1, con);
                    SqlDataReader Dsgqn1 = Cmdgqn1.ExecuteReader();
                    Dsgqn1.Read();

                    if (Dsgqn1.HasRows == true)
                    {
                        dr[23] = Dsgqn1["ChallanNo"].ToString();
                        dr[24] = Dsgqn1["AcceptedQty"].ToString();
                    }
                }

                if (Convert.ToInt32(DSGsn["GSNId"].ToString()) != 0)
                {
                    string strGqn1 = "SELECT  tblInv_Inward_Master.ChallanNo, tblinv_MaterialServiceNote_Details.ReceivedQty, tblinv_MaterialServiceNote_Details.Id AS GSNId FROM tblinv_MaterialServiceNote_Details INNER JOIN  tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id INNER JOIN  tblInv_Inward_Master INNER JOIN  tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId ON tblinv_MaterialServiceNote_Master.GINId = tblInv_Inward_Master.Id AND                     tblinv_MaterialServiceNote_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialServiceNote_Details.POId = tblInv_Inward_Details.POId AND tblinv_MaterialServiceNote_Details.Id='" + DSGsn["GSNId"].ToString() + "' ";
                    SqlCommand Cmdgqn1 = new SqlCommand(strGqn1, con);
                    SqlDataReader Dsgqn1 = Cmdgqn1.ExecuteReader();
                    Dsgqn1.Read();

                    if (Dsgqn1.HasRows == true)
                    {
                        dr[23] = Dsgqn1["ChallanNo"].ToString();
                        dr[24] = Dsgqn1["ReceivedQty"].ToString();
                    }
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();               
            }

            GridView3.DataSource = dt;
            GridView3.DataBind();

            if (GridView3.Rows.Count > 0)
            {
                ((Label)GridView3.FooterRow.FindControl("lblrtotal")).Text = "Total:" + runningtotal.ToString();
            }
        }
      catch (Exception ex) { }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.LoadDataSelectedItems();
        }
        catch (Exception ex) { }

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            try
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                string str = fun.Connection();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string sql = fun.delete("tblACC_BillBooking_Details_Temp", "Id='" + id + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'  ");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (Exception ea)
            {

            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
    public void TDSGrid()
    {
       try
        {
            Panel4.Visible = true;

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            DataTable dt = new DataTable();
            con.Open();

            string SqlTemp = "SELECT tblACC_BillBooking_Details_Temp.Id,tblACC_BillBooking_Details_Temp.ACHead FROM tblACC_BillBooking_Details_Temp INNER JOIN AccHead ON tblACC_BillBooking_Details_Temp.ACHead = AccHead.Id AND tblACC_BillBooking_Details_Temp.SessionId='" + SId + "' AND tblACC_BillBooking_Details_Temp.CompId='" + CompId + "' AND AccHead.Symbol like 'E%'";

            SqlCommand cmdTemp = new SqlCommand(SqlTemp, con);
            SqlDataReader DSTemp = cmdTemp.ExecuteReader();
            DSTemp.Read();

            if (DSTemp.HasRows == true)
            {
                string StrSql = fun.select1("*", "tblACC_TDSCode_Master");
                SqlCommand cmdsupId = new SqlCommand(StrSql, con);
                SqlDataReader DSSql = cmdsupId.ExecuteReader();

                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SectionNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("NatureOfPayment", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("PaymentRange", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("IndividualHUF", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Others", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("TDSAmt", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("WithOutPAN", typeof(string)));

                DataRow dr;

                while (DSSql.Read())
                {
                    dr = dt.NewRow();
                    dr[0] = DSSql["Id"].ToString();
                    dr[1] = DSSql["SectionNo"].ToString();
                    dr[2] = DSSql["NatureOfPayment"].ToString();
                    dr[3] = DSSql["PaymentRange"].ToString();
                    dr[4] = DSSql["PayToIndividual"].ToString();
                    dr[5] = DSSql["Others"].ToString();
                    dr[6] = 0;
                    dr[7] = DSSql["WithOutPAN"].ToString(); ;

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

                GridView4.DataSource = dt;
                GridView4.DataBind();

                foreach (GridViewRow row in GridView4.Rows)
                {
                    int x = 0;
                    x = Convert.ToInt32((((Label)row.FindControl("Id")).Text));
                    ((Label)row.FindControl("TDSAmt")).Text = fun.Check_TDSAmt(CompId, FyId, SupplierNo, x).ToString();
                }
            }
            else
            {
                Panel4.Visible = false;
            }

            con.Close();
        }
        catch (Exception et)
        {

        }
    }
    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        this.TDSGrid();
    }


}
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
using System.Web.Mail;

public partial class Module_HR_Transactions_OfferLetter_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();

    int CompId = 0;
    int FinYearId = 0;
    string OfferId = string.Empty ;
    string valDrpEmpTypeOf = string.Empty;
    string valDrpEmpType = string.Empty;
    string SessionId = string.Empty;
    int OI = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            OfferId = Request.QueryString["offid"];
            SessionId = Session["Username"].ToString();
            OI =Convert.ToInt32(Request.QueryString["OI"]);
            lblOfferId.Text = OfferId;
          
            if (!IsPostBack)
            {
                Label2.Text = "";
                if (Request.QueryString["msg"] != null)
                {
                    Label2.Text = Request.QueryString["msg"].ToString();
                }

                if (OI == 0)
                {
                    lblOfferIncrement.Text = "Offer Letter - Edit";
                    BtnSubmit.Visible = true;
                    BtnIncrement.Visible = false;
                }
                else
                {
                    lblOfferIncrement.Text = "Increment Letter";
                    BtnSubmit.Visible = false;
                    BtnIncrement.Visible = true;
                }

                this.FillAccegrid();

                string sql = fun.select("*", "tblHR_Offer_Master", "OfferId='" + OfferId + "'");
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    DrpDesignation.SelectedValue = ds.Tables[0].Rows[0]["Designation"].ToString();
                    DrpDutyHrs.SelectedValue = ds.Tables[0].Rows[0]["DutyHrs"].ToString();
                    DrpOTHrs.SelectedValue = ds.Tables[0].Rows[0]["OTHrs"].ToString();
                    DrpOvertime.SelectedValue = ds.Tables[0].Rows[0]["OverTime"].ToString();
                    DrpTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
                    DrpEmpType.SelectedValue = ds.Tables[0].Rows[0]["StaffType"].ToString();
                    DrpEmpTypeOf.SelectedValue = ds.Tables[0].Rows[0]["TypeOf"].ToString();
                    TxtName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                    TxtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    TxtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    TxtEmail.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    TxtReferencedby.Text = ds.Tables[0].Rows[0]["ReferenceBy"].ToString();
                    TxtGrossSalry.Text = ds.Tables[0].Rows[0]["salary"].ToString();
                    txtHeader.Text = ds.Tables[0].Rows[0]["HeaderText"].ToString();
                    txtFooter.Text = ds.Tables[0].Rows[0]["FooterText"].ToString();
                    TxtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();


                    string sql2 = fun.select("Title+' '+EmployeeName+' ['+EmpId+']' as Name", "tblHR_OfficeStaff", "EmpId='" + ds.Tables[0].Rows[0]["InterviewedBy"].ToString() + "'");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        Txtinterviewedby.Text = ds2.Tables[0].Rows[0]["Name"].ToString();
                    }

                    string sql3 = fun.select("Title+' '+EmployeeName +' ['+EmpId+']' as Name", "tblHR_OfficeStaff", "EmpId='" + ds.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "'");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        TxtAuthorizedby.Text = ds3.Tables[0].Rows[0]["Name"].ToString();
                    }

                    txtBonus.Text = ds.Tables[0].Rows[0]["Bonus"].ToString();
                    txtAttB1.Text = ds.Tables[0].Rows[0]["AttBonusPer1"].ToString();
                    txtAttB2.Text = ds.Tables[0].Rows[0]["AttBonusPer2"].ToString();
                    TxtGLTA.Text = ds.Tables[0].Rows[0]["LTA"].ToString();
                    TxtGVehAll.Text = ds.Tables[0].Rows[0]["VehicleAllowance"].ToString(); 
                    TxtGGratia.Text = ds.Tables[0].Rows[0]["ExGratia"].ToString();
                    TxtAnnLOYAlty.Text = ds.Tables[0].Rows[0]["Loyalty"].ToString();
                    txtPFEmployee.Text = ds.Tables[0].Rows[0]["PFEmployee"].ToString();
                    txtPFCompany.Text = ds.Tables[0].Rows[0]["PFCompany"].ToString();
                    valDrpEmpTypeOf = ds.Tables[0].Rows[0]["TypeOf"].ToString();
                    valDrpEmpType = ds.Tables[0].Rows[0]["StaffType"].ToString();
                    txtIncrementForTheYear.Text = ds.Tables[0].Rows[0]["IncrementForTheYear"].ToString();
                    txtEffectFrom.Text = ds.Tables[0].Rows[0]["EffectFrom"].ToString();
                    lblesi.Text = ds.Tables[0].Rows[0]["ESI"].ToString();

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Increment"]) == 0 && OI == 0)
                    {
                        txtHeader.Visible = true;
                        txtFooter.Visible = true;
                    }

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Increment"]) == 0 && OI == 1 || Convert.ToInt32(ds.Tables[0].Rows[0]["Increment"]) > 0)
                    {
                        lblEffectFromForTheYeartext.Visible = true;
                        txtIncrementForTheYear.Visible = true;
                        lblIncrementForTheYear.Visible = true;
                        lblEffectFromtext.Visible = true;
                        txtEffectFrom.Visible = true;
                    }
                   
                }
            }
            this.CalSalary(valDrpEmpTypeOf, valDrpEmpType);
            con.Close();
        }
       catch (Exception et)
        {
        }
    }

   
    public void CalSalary(string valDrpEmpTypeOf1, string valDrpEmpType1)
    {
        try
        {
            string constr = fun.Connection();
            SqlConnection con = new SqlConnection(constr);

            if (TxtGrossSalry.Text != "")
            {
                double GrossSalary = Convert.ToDouble(TxtGrossSalry.Text);
                double AnSalary = GrossSalary * 12;

                TxtGSal.Text = GrossSalary.ToString();
                TxtANNualSal.Text = AnSalary.ToString();

                TxtGBasic.Text = fun.Offer_Cal(GrossSalary, 1, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtAnBasic.Text = fun.Offer_Cal(GrossSalary, 1, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtGDA.Text = fun.Offer_Cal(GrossSalary, 2, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtAnDA.Text = fun.Offer_Cal(GrossSalary, 2, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtGHRA.Text = fun.Offer_Cal(GrossSalary, 3, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtANHRA.Text = fun.Offer_Cal(GrossSalary, 3, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtGConvenience.Text = fun.Offer_Cal(GrossSalary, 4, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtANConvenience.Text = fun.Offer_Cal(GrossSalary, 4, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtGEdu.Text = fun.Offer_Cal(GrossSalary, 5, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtANEDU.Text = fun.Offer_Cal(GrossSalary, 5, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtGWash.Text = fun.Offer_Cal(GrossSalary, 6, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtANWash.Text = fun.Offer_Cal(GrossSalary, 6, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();

                double AttBonus1 = 0;
                double AttBonus2 = 0;
                double pfe = 0;
                double pfc = 0;
                double ptax = 0;
              //  double esie = 0;

                //if (DrpEmpType.SelectedItem.Text != "Select")
                {
                    if (valDrpEmpType1 != "5")
                    {
                        AttBonus1 = GrossSalary * Convert.ToDouble(txtAttB1.Text) / 100;
                        AttBonus2 = GrossSalary * Convert.ToDouble(txtAttB2.Text) / 100;
                        TxtGATTBN1.Text = AttBonus1.ToString();
                        TxtGATTBN2.Text = AttBonus2.ToString();
                        pfe = fun.Pf_Cal(GrossSalary, 1, Convert.ToDouble(txtPFEmployee.Text));
                        TxtGEmpPF.Text = pfe.ToString();
                        pfc = fun.Pf_Cal(GrossSalary, 2, Convert.ToDouble(txtPFCompany.Text));
                        TxtGCompPF.Text = pfc.ToString();
                        //PTax = Gross + Att. Bonus 1 + Ex Gratia
                        ptax = fun.PTax_Cal((GrossSalary + AttBonus1 + Convert.ToDouble(TxtGGratia.Text)), "0");
                        TxtGPTax.Text = ptax.ToString();

                        lblesi.Text = ((double.Parse(lblesie.Text) * double.Parse(TxtGrossSalry.Text)) / 100).ToString();



                        txtPFEmployee.Enabled = true;
                        txtPFCompany.Enabled = true;
                        txtBonus.Enabled = true;
                        txtAttB1.Enabled = true;
                        txtAttB2.Enabled = true;
                        txtBonus.Enabled = true;

                      

                        lblGratuaty.Text = fun.Gratuity_Cal(GrossSalary, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                        TxtAnnGratuaty.Text = fun.Gratuity_Cal(GrossSalary, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                    }
                    else
                    {
                        txtBonus.Text = "0";
                        txtBonus.Enabled = false;
                        TxtGATTBN1.Text = "0";
                        txtAttB1.Text = "0";
                        txtAttB1.Enabled = false;
                        TxtGATTBN2.Text = "0";
                        txtAttB2.Text = "0";
                        txtAttB2.Enabled = false;
                        txtBonus.Text = "0";
                        txtBonus.Enabled = false;
                        TxtGEmpPF.Text = "0";
                        TxtGCompPF.Text = "0";
                        txtPFEmployee.Text = "0";
                        txtPFEmployee.Enabled = false;
                        txtPFCompany.Text = "0";
                        txtPFCompany.Enabled = false;
                        TxtGPTax.Text = "0";
                        lblGratuaty.Text = "0";
                        TxtAnnGratuaty.Text = "0";
                    }

                    if (valDrpEmpTypeOf1 == "2")
                    {
                        lblGratuaty.Text = "0";
                        TxtAnnGratuaty.Text = "0";
                    }
                }

                double Bonus = 0;
                Bonus = Convert.ToDouble(txtBonus.Text) * 12;
                TxtAnnBonus.Text = Bonus.ToString();

                // Accessories Amt
                double AccessoriesAmt_CTC = 0;
                double AccessoriesAmt_TakeHome = 0;
                double AccessoriesAmt_Both = 0;
              double  AccessoriesAmt_PER = 0;
                
                string sql98 = fun.select("*", "tblHR_Offer_Accessories", "MId='" + OfferId + "'");
                SqlCommand cmd98 = new SqlCommand(sql98, con);
                SqlDataAdapter da98 = new SqlDataAdapter(cmd98);
                DataSet ds98 = new DataSet();
                da98.Fill(ds98);

                if (ds98.Tables[0].Rows.Count > 0)
                {
                    for (int h = 0; h < ds98.Tables[0].Rows.Count; h++)
                    {
                        switch (ds98.Tables[0].Rows[h]["IncludesIn"].ToString())
                        {
                            case "1":
                                AccessoriesAmt_CTC += Convert.ToDouble(ds98.Tables[0].Rows[h]["Qty"]) * Convert.ToDouble(ds98.Tables[0].Rows[h]["Amount"]);
                                break;
                            case "2":
                                AccessoriesAmt_TakeHome += Convert.ToDouble(ds98.Tables[0].Rows[h]["Qty"]) * Convert.ToDouble(ds98.Tables[0].Rows[h]["Amount"]);
                                break;
                            case "3":
                                AccessoriesAmt_Both += Convert.ToDouble(ds98.Tables[0].Rows[h]["Qty"]) * Convert.ToDouble(ds98.Tables[0].Rows[h]["Amount"]);
                                break;
                            case "4":
                                AccessoriesAmt_PER += Convert.ToDouble(ds98.Tables[0].Rows[h]["Qty"]) * Convert.ToDouble(ds98.Tables[0].Rows[h]["Amount"]);
                                break;
                        }
                    }
                }

                double th = 0;

                //Gross + ExGratia - PFE+PTax

                th = Math.Round((GrossSalary + Convert.ToDouble(TxtGGratia.Text)-Convert.ToDouble(lblesi.Text) + AccessoriesAmt_TakeHome + AccessoriesAmt_Both+AccessoriesAmt_PER) - (pfe + ptax));
                lblTH.Text = decimal.Parse(th.ToString()).ToString("N2");

                double thatt1 = 0;
                thatt1 = Math.Round(th + AttBonus1);
                lblTH1.Text = decimal.Parse(thatt1.ToString()).ToString("N2");

                double thatt2 = 0;
                thatt2 = Math.Round(th + AttBonus2);
                lblTH2.Text = decimal.Parse(thatt2.ToString()).ToString("N2");

                lblTHAnn.Text = decimal.Parse((Math.Round(th * 12)).ToString()).ToString("N2");
                lblTHAnn1.Text = decimal.Parse((Math.Round(thatt1 * 12)).ToString()).ToString("N2");
                lblTHAnn2.Text = decimal.Parse((Math.Round(thatt2 * 12)).ToString()).ToString("N2");

                double ctc = 0;

                ctc = Math.Round(GrossSalary + Convert.ToDouble(txtBonus.Text) + Convert.ToDouble(TxtAnnLOYAlty.Text) + Convert.ToDouble(TxtGLTA.Text) + Convert.ToDouble(lblGratuaty.Text) + pfc + Convert.ToDouble(TxtGGratia.Text)-Convert.ToDouble(lblesi.Text)) + AccessoriesAmt_CTC + AccessoriesAmt_Both+ AccessoriesAmt_PER;

                //fun.Gratuity_Cal(GrossSalary, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue))

                lblCTC.Text = decimal.Parse(ctc.ToString()).ToString("N2");

                double ctcatt1 = 0;
                ctcatt1 = Math.Round(ctc + AttBonus1);
                lblCTC1.Text = decimal.Parse(ctcatt1.ToString()).ToString("N2");

                double ctcatt2 = 0;
                ctcatt2 = Math.Round(ctc + AttBonus2);
                lblCTC2.Text = decimal.Parse(ctcatt2.ToString()).ToString("N2");

                lblCTCAnn.Text = decimal.Parse((Math.Round(ctc * 12)).ToString()).ToString("N2");
                lblCTCAnn1.Text = decimal.Parse((Math.Round(ctcatt1 * 12)).ToString()).ToString("N2");
                lblCTCAnn2.Text = decimal.Parse((Math.Round(ctcatt2 * 12)).ToString()).ToString("N2");


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
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
        }
        catch (Exception ex)
        {

        }
    }

    //------------------------------- Increment --------------------------------------------------------------------

    protected void BtnIncrement_Click(object sender, EventArgs e)
    {
        string constr = fun.Connection();
        SqlConnection con = new SqlConnection(constr);

          try
        {
            con.Open();

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();

            if (txtFooter.Text != "" && txtHeader.Text != "" && TxtGrossSalry.Text != "" && TxtName.Text != "" && TxtAddress.Text != "" && DrpEmpTypeOf.SelectedValue != "0")
            {
                if (txtIncrementForTheYear.Text != "" && txtEffectFrom.Text != "")
                {
                    //-------------------------------In Increment Table ------------------------------------------------------------------


                    string SqlOffer = fun.select("OfferId, SysDate, SysTime, SessionId, CompId, FinYearId, Title, EmployeeName, StaffType, TypeOf, salary, DutyHrs, OTHrs, OverTime, Address, ContactNo, EmailId, InterviewedBy, AuthorizedBy ,ReferenceBy, Designation, ExGratia, VehicleAllowance, LTA , Loyalty, PaidLeaves , Remarks, HeaderText, FooterText, Bonus , AttBonusPer1 , AttBonusPer2, PFEmployee, PFCompany,Increment,IncrementForTheYear,EffectFrom,ESI", "tblHR_Offer_Master", "OfferId='" + OfferId + "'");
                    SqlCommand cmdOffer = new SqlCommand(SqlOffer, con);
                    SqlDataAdapter daOffer = new SqlDataAdapter(cmdOffer);
                    DataSet dsOffer = new DataSet();
                    daOffer.Fill(dsOffer);
                    if (dsOffer.Tables[0].Rows.Count > 0)
                    {
                        int Increment = 0;
                        Increment = Convert.ToInt32(dsOffer.Tables[0].Rows[0]["Increment"]) + 1;

                        string StrIncrement = fun.insert("tblHR_Increment_Master", "SysDate, SysTime, SessionId, CompId, FinYearId,OfferId, Title, EmployeeName, StaffType, TypeOf, salary, DutyHrs, OTHrs, OverTime, Address, ContactNo, EmailId, InterviewedBy, AuthorizedBy ,ReferenceBy, Designation, ExGratia, VehicleAllowance, LTA , Loyalty, PaidLeaves , Remarks, HeaderText, FooterText, Bonus , AttBonusPer1 , AttBonusPer2, PFEmployee, PFCompany,Increment,IncrementForTheYear,EffectFrom,ESI", "'" + dsOffer.Tables[0].Rows[0]["SysDate"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["SysTime"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["SessionId"].ToString() + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["CompId"]) + "', '" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["FinYearId"]) + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["OfferId"]) + "','" + dsOffer.Tables[0].Rows[0]["Title"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["EmployeeName"].ToString() + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["StaffType"]) + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["TypeOf"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["salary"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["DutyHrs"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["OTHrs"]) + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["OverTime"]) + "','" + dsOffer.Tables[0].Rows[0]["Address"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["ContactNo"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["EmailId"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["InterviewedBy"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["ReferenceBy"].ToString() + "','" + Convert.ToInt32(dsOffer.Tables[0].Rows[0]["Designation"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["ExGratia"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["VehicleAllowance"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["LTA"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["Loyalty"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["PaidLeaves"]) + "','" + dsOffer.Tables[0].Rows[0]["Remarks"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["HeaderText"] + "','" + dsOffer.Tables[0].Rows[0]["FooterText"] + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["Bonus"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["AttBonusPer1"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["AttBonusPer2"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["PFEmployee"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["PFCompany"]) + "','" + Convert.ToDouble(dsOffer.Tables[0].Rows[0]["Increment"]) + "','" + dsOffer.Tables[0].Rows[0]["IncrementForTheYear"].ToString() + "','" + dsOffer.Tables[0].Rows[0]["EffectFrom"].ToString() + "','"+dsOffer.Tables[0].Rows[0]["ESI"].ToString()+"'");
                        SqlCommand cmdIncrement = new SqlCommand(StrIncrement, con);
                        cmdIncrement.ExecuteNonQuery();

                        string strp = fun.select("Id", "tblHR_Increment_Master", "CompId='" + CompId + "' order by Id DESC");
                        SqlCommand cmdp = new SqlCommand(strp, con);
                        SqlDataAdapter dap = new SqlDataAdapter(cmdp);
                        DataSet dsp = new DataSet();
                        dap.Fill(dsp, "tblHR_Increment_Master");
                        int MId = 0;
                        if (dsp.Tables[0].Rows.Count > 0)
                        {
                            MId = Convert.ToInt32(dsp.Tables[0].Rows[0]["Id"]);
                            string SqlOfferAcc = fun.select("Id, MId, Perticulars, Qty, Amount, IncludesIn ", "tblHR_Offer_Accessories", "MId='" + OfferId + "'");
                            SqlCommand cmdOfferAcc = new SqlCommand(SqlOfferAcc, con);
                            SqlDataAdapter daOfferAcc = new SqlDataAdapter(cmdOfferAcc);
                            DataSet dsOfferAcc = new DataSet();
                            daOfferAcc.Fill(dsOfferAcc);
                            for (int i = 0; i < dsOfferAcc.Tables[0].Rows.Count; i++)
                            {
                                string StrIncrementAcc = fun.insert("tblHR_Increment_Accessories", "MId , OfferMId , Perticulars, Qty, Amount, IncludesIn ", "'" + MId + "','" + Convert.ToInt32(dsOfferAcc.Tables[0].Rows[i]["MId"]) + "','" + dsOfferAcc.Tables[0].Rows[i]["Perticulars"] + "','" + Convert.ToDouble(dsOfferAcc.Tables[0].Rows[i]["Qty"]) + "','" + Convert.ToDouble(dsOfferAcc.Tables[0].Rows[i]["Amount"]) + "','" + Convert.ToInt32(dsOfferAcc.Tables[0].Rows[i]["IncludesIn"]) + "'");
                                SqlCommand cmdIncrementAcc = new SqlCommand(StrIncrementAcc, con);
                                cmdIncrementAcc.ExecuteNonQuery();

                            }
                        }

                        //-------------------------------In Offer Letter Table -----------------------------------------------------------

                        string strInsert = fun.update("tblHR_Offer_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',Title='" + DrpTitle.SelectedValue + "',EmployeeName='" + TxtName.Text + "',TypeOf='" + DrpEmpTypeOf.SelectedValue + "',StaffType='" + DrpEmpType.SelectedValue + "',salary='" + TxtGrossSalry.Text + "',DutyHrs='" + DrpDutyHrs.SelectedValue + "',OTHrs='" + DrpOTHrs.SelectedValue + "',OverTime='" + DrpOvertime.SelectedValue + "',Address='" + TxtAddress.Text + "',ContactNo='" + TxtContactNo.Text + "',EmailId='" + TxtEmail.Text + "',InterviewedBy='" + fun.getCode(Txtinterviewedby.Text) + "',AuthorizedBy='" + fun.getCode(TxtAuthorizedby.Text) + "',ReferenceBy='" + TxtReferencedby.Text + "',Designation='" + DrpDesignation.SelectedValue + "',ExGratia='" + TxtGGratia.Text + "',VehicleAllowance='" + TxtGVehAll.Text + "',LTA='" + TxtGLTA.Text + "',Loyalty='" + TxtAnnLOYAlty.Text + "',PaidLeaves='" + TxtAnnpaidleaves.Text + "',HeaderText='" + txtHeader.Text + "',FooterText='" + txtFooter.Text + "',Remarks='" + TxtRemarks.Text + "',Bonus='" + txtBonus.Text + "',AttBonusPer1='" + txtAttB1.Text + "',AttBonusPer2='" + txtAttB2.Text + "',PFEmployee='" + txtPFEmployee.Text + "',PFCompany='" + txtPFCompany.Text + "',Increment='" + Increment + "',IncrementForTheYear='" + txtIncrementForTheYear.Text + "',EffectFrom='" + txtEffectFrom.Text + "',ESI='"+lblesi.Text+"'", "OfferId='" + OfferId + "'");

                        SqlCommand cmd1 = new SqlCommand(strInsert, con);
                        cmd1.ExecuteNonQuery();
                        string sql95 = fun.delete("tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
                        SqlCommand cmd95 = new SqlCommand(sql95, con);
                        cmd95.ExecuteNonQuery();
                        con.Close();

                        //------------------------------- Send Mail--------------------------------------------------------------------
                        MailMessage msg = new MailMessage();
                        string ErpMail = "";
                        string EmailId = string.Empty;
                        string ChangeBy = string.Empty;
                        string EmployeeName = string.Empty;
                        string sql21 = "";
                        sql21 = fun.select("Title+'. '+EmployeeName+' ['+EmpId+']' as ChengedByName", "tblHR_OfficeStaff", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And EmpId='" + sId + "'");
                        SqlCommand cmd21 = new SqlCommand(sql21, con);
                        SqlDataAdapter DA21 = new SqlDataAdapter(cmd21);
                        DataSet DS21 = new DataSet();
                        DA21.Fill(DS21);
                        if (DS21.Tables[0].Rows.Count > 0)
                        {
                            ChangeBy = DS21.Tables[0].Rows[0]["ChengedByName"].ToString();
                        }
                        string sql3 = fun.select("Title+'. '+EmployeeName +' ['+EmpId+']' as EmpName", "tblHR_OfficeStaff", "OfferId='" + OfferId + "'");
                        SqlCommand cmd3 = new SqlCommand(sql3, con);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            EmployeeName = ds3.Tables[0].Rows[0]["EmpName"].ToString();
                        }
                        string sqlmailserverip = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
                        SqlCommand cmd4 = new SqlCommand(sqlmailserverip, con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            SmtpMail.SmtpServer = ds4.Tables[0].Rows[0]["MailServerIp"].ToString();
                            ErpMail = ds4.Tables[0].Rows[0]["ErpSysmail"].ToString();
                        }
                        msg.From = ErpMail;
                        msg.To = "shridhar@sapl.com";
                       // msg.To = "dhananjay@sapl.com,narendra@sapl.com,meera@sapl.com";
                       // msg.Bcc = "ashish@sapl.com,shridhar@sapl.com,kumar@sapl.com,shrikrishna@sapl.com";
                        msg.Subject = "Increment Letter";
                        msg.Body = "  The Increment Letter of " + EmployeeName + " is generated by " + ChangeBy + ".<br><br><br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
                        msg.BodyFormat = MailFormat.Html;
                        SmtpMail.Send(msg);

                        //------------------------------------------------------------------------------------------------------------------

                        Response.Redirect("OfferLetter_Edit.aspx?ModId=12&SubModId=25&msg=Employee data is updated.");
                    }
                }
                else
                {
                    string mystring = string.Empty;
                    mystring = "Please fill increment year or effect date properly.";                  
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Please fill Data properly.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
          catch (Exception ex)
        {
        }
    }



    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string constr = fun.Connection();
        SqlConnection con = new SqlConnection(constr);

        try
        {
            con.Open();

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();

            if (txtFooter.Text != "" && txtHeader.Text != "" && TxtGrossSalry.Text != "" && TxtName.Text != "" && TxtAddress.Text != "" && DrpEmpTypeOf.SelectedValue != "0")
            {
                string strInsert = fun.update("tblHR_Offer_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',Title='" + DrpTitle.SelectedValue + "',EmployeeName='" + TxtName.Text + "',TypeOf='" + DrpEmpTypeOf.SelectedValue + "',StaffType='" + DrpEmpType.SelectedValue + "',salary='" + TxtGrossSalry.Text + "',DutyHrs='" + DrpDutyHrs.SelectedValue + "',OTHrs='" + DrpOTHrs.SelectedValue + "',OverTime='" + DrpOvertime.SelectedValue + "',Address='" + TxtAddress.Text + "',ContactNo='" + TxtContactNo.Text + "',EmailId='" + TxtEmail.Text + "',InterviewedBy='" + fun.getCode(Txtinterviewedby.Text) + "',AuthorizedBy='" + fun.getCode(TxtAuthorizedby.Text) + "',ReferenceBy='" + TxtReferencedby.Text + "',Designation='" + DrpDesignation.SelectedValue + "',ExGratia='" + TxtGGratia.Text + "',VehicleAllowance='" + TxtGVehAll.Text + "',LTA='" + TxtGLTA.Text + "',Loyalty='" + TxtAnnLOYAlty.Text + "',PaidLeaves='" + TxtAnnpaidleaves.Text + "',HeaderText='" + txtHeader.Text + "',FooterText='" + txtFooter.Text + "',Remarks='" + TxtRemarks.Text + "',Bonus='" + txtBonus.Text + "',AttBonusPer1='" + txtAttB1.Text + "',AttBonusPer2='" + txtAttB2.Text + "',PFEmployee='" + txtPFEmployee.Text + "',PFCompany='" + txtPFCompany.Text + "',IncrementForTheYear='" + txtIncrementForTheYear.Text + "',EffectFrom='" + txtEffectFrom.Text + "',ESI='"+lblesi.Text+"'", "OfferId='" + OfferId + "'");

                SqlCommand cmd1 = new SqlCommand(strInsert, con);
                cmd1.ExecuteNonQuery();
                string sql95 = fun.delete("tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
                SqlCommand cmd95 = new SqlCommand(sql95, con);
                cmd95.ExecuteNonQuery();
                con.Close();

                //------------------------------- Send Mail--------------------------------------------------------------------

                MailMessage msg = new MailMessage();
                string ErpMail = "";
                string EmailId = string.Empty;
                string ChangeBy = string.Empty;
                string EmployeeName = string.Empty;
                string sql21 = "";
                sql21 = fun.select("Title+'. '+EmployeeName+' ['+EmpId+']' as ChengedByName", "tblHR_OfficeStaff", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And EmpId='" + sId + "'");
                SqlCommand cmd21 = new SqlCommand(sql21, con);
                SqlDataAdapter DA21 = new SqlDataAdapter(cmd21);
                DataSet DS21 = new DataSet();
                DA21.Fill(DS21);
                if (DS21.Tables[0].Rows.Count > 0)
                {
                    ChangeBy = DS21.Tables[0].Rows[0]["ChengedByName"].ToString();
                }
                string sql3 = fun.select("Title+'. '+EmployeeName +' ['+EmpId+']' as EmpName", "tblHR_OfficeStaff", "OfferId='" + OfferId + "'");
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);

                if (ds3.Tables[0].Rows.Count > 0)
                {
                    EmployeeName = ds3.Tables[0].Rows[0]["EmpName"].ToString();
                }
                string sqlmailserverip = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
                SqlCommand cmd4 = new SqlCommand(sqlmailserverip, con);
                SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
    
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    SmtpMail.SmtpServer = ds4.Tables[0].Rows[0]["MailServerIp"].ToString();
                    ErpMail = ds4.Tables[0].Rows[0]["ErpSysmail"].ToString();
                }
                msg.From = ErpMail;
                msg.To = "dhananjay@sapl.com,narendra@sapl.com,meera@sapl.com";
                msg.Bcc = "ashish@sapl.com,shridhar@sapl.com,kumar@sapl.com,shrikrishna@sapl.com";
                msg.Subject = "Offer Letter Change";
                msg.Body = "  The Offer Letter of " + EmployeeName + " is Changed/updated by " + ChangeBy + ".<br><br><br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
                msg.BodyFormat = MailFormat.Html;
                SmtpMail.Send(msg);

                //----------------------------------------------------------------------------------------------------------------------

                Response.Redirect("OfferLetter_Edit.aspx?ModId=12&SubModId=25&msg=Employee data is updated.");
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Please fill Data properly.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception ex)
        {
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                if (main.Length == 10)
                    break;
            }
        }
        Array.Sort(main);
        return main;
    }
    
    protected void DrpEmpTypeOf_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpEmpTypeOf.SelectedValue == "1")
        {
            txtAttB1.Text = "10";
            txtAttB2.Text = "20";
        }
        else if (DrpEmpTypeOf.SelectedValue == "2")
        {
            txtAttB1.Text = "5";
            txtAttB2.Text = "15";
        }

        this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("OfferLetter_Edit.aspx?ModId=12&SubModId=25");
    }

    public void FillAccegrid()
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            string sql = fun.select("[Id],[MId],[Perticulars],[Qty],[Amount],Round(([Qty]*[Amount]),2)As Total,IncludesIn", "tblHR_Offer_Accessories", "MId='" + OfferId + "' Order by Id DESC");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            foreach (GridViewRow grv in GridView1.Rows)
            {
                string id = ((Label)grv.FindControl("lblIncludesInId")).Text;
                string sql1 = fun.select("*", "tblHR_IncludesIn", "Id='" + id + "'");

                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                ((Label)grv.FindControl("lblIncludesIn")).Text = ds1.Tables[0].Rows[0]["IncludesIn"].ToString();
            }


        }
        catch (Exception ex) { }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            string SId = Session["username"].ToString();
            if (e.CommandName == "Add")
            {
                string strPerticulars = string.Empty;
                double strAccQty = 0;
                double strAccAmount = 0;
                string IncludeIn = string.Empty; 

                if (((TextBox)GridView1.FooterRow.FindControl("txtPerticulars")).Text != "" && ((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text != "" && ((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text) == true && fun.NumberValidationQty(((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text) == true)
                {

                    strPerticulars = ((TextBox)GridView1.FooterRow.FindControl("txtPerticulars")).Text;
                    strAccQty = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text).ToString("N2"));
                    strAccAmount = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text).ToString("N2"));
                    IncludeIn = ((DropDownList)GridView1.FooterRow.FindControl("IncludeIn")).SelectedValue;
                    string insert = fun.insert("tblHR_Offer_Accessories", "MId,Perticulars,Qty,Amount,IncludesIn", "'" + OfferId + "','" + strPerticulars + "','" + strAccQty + "','" + strAccAmount + "','" + IncludeIn + "'");

                    SqlCommand cmd = new SqlCommand(insert, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.FillAccegrid();
                }

            }
            else if (e.CommandName == "Add1")
            {

                string strPerticulars1 = string.Empty;
                double strAccQty1 = 0;
                double strAccAmount1 = 0;
                string IncludeIn = string.Empty; 

                if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPerticulars1")).Text != "" && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text != "" && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text) == true && fun.NumberValidationQty(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text) == true)
                {

                    strPerticulars1 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPerticulars1")).Text;
                    strAccQty1 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text).ToString("N2"));
                    strAccAmount1 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text).ToString("N2"));
                    IncludeIn = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("IncludeIn0")).SelectedValue;
                    string insert1 = fun.insert("tblHR_Offer_Accessories", "MId,Perticulars,Qty,Amount,IncludesIn", "'" + OfferId + "','" + strPerticulars1 + "','" + strAccQty1 + "','" + strAccAmount1 + "','" + IncludeIn + "'");
                    SqlCommand cmd1 = new SqlCommand(insert1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    this.FillAccegrid();
                }

            }

            this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
        }
        catch (Exception ex)
        {
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            DataSet ds = new DataSet();
            int rowIndex = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[rowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string strPerticularsE = string.Empty;
            double strAccQtyE = 0;
            double strAccAmountE = 0;

            if (((TextBox)row.FindControl("txtPerticularsE")).Text != "" && ((TextBox)row.FindControl("txtAccAmountE")).Text != "" && ((TextBox)row.FindControl("txtAccQtyE")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtAccAmountE")).Text) == true && fun.NumberValidationQty(((TextBox)row.FindControl("txtAccQtyE")).Text) == true)
            {
                strPerticularsE = ((TextBox)row.FindControl("txtPerticularsE")).Text;
                strAccQtyE = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAccQtyE")).Text).ToString("N2"));
                strAccAmountE = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAccAmountE")).Text).ToString("N2"));
                string UpDateStr = fun.update("tblHR_Offer_Accessories", "[MId] ='" + OfferId + "', [Perticulars] ='" + strPerticularsE + "',[Qty]='" + strAccQtyE + "',[Amount] = " + strAccAmountE + "", "Id ='" + id + "'");
                SqlCommand cmd = new SqlCommand(UpDateStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                this.FillAccegrid();
                this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
            }

        }
        catch (Exception ex) { }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand(fun.delete("tblHR_Offer_Accessories", "Id='" + id + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillAccegrid();
            this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
        }
        catch (Exception er) { }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        this.FillAccegrid();
        this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.FillAccegrid();
        this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillAccegrid();
        this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
    }

    protected void DrpEmpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string constr = fun.Connection();
            SqlConnection con = new SqlConnection(constr);

            double GrossSalary = Convert.ToDouble(TxtGrossSalry.Text);
            double AnSalary = GrossSalary * 12;

            if (DrpEmpType.SelectedItem.Text != "Casuals")
            {
                txtPFEmployee.Enabled = true;
                txtPFCompany.Enabled = true;
                txtBonus.Enabled = true;
                txtAttB1.Enabled = true;
                txtAttB2.Enabled = true;
                txtBonus.Enabled = true;

                string sql = fun.select("*", "tblHR_PF_Slab", "Active=1");
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                txtPFEmployee.Text = ds.Tables[0].Rows[0]["PFEmployee"].ToString();
                txtPFCompany.Text = ds.Tables[0].Rows[0]["PFCompany"].ToString();

                if (DrpEmpTypeOf.SelectedValue == "1")
                {
                    txtAttB1.Text = "10";
                    txtAttB2.Text = "20";
                }
                else if (DrpEmpTypeOf.SelectedValue == "2")
                {
                    txtAttB1.Text = "5";
                    txtAttB2.Text = "15";
                }

                lblGratuaty.Text = fun.Gratuity_Cal(GrossSalary, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
                TxtAnnGratuaty.Text = fun.Gratuity_Cal(GrossSalary, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
            }
            else
            {
                txtBonus.Text = "0";
                txtBonus.Enabled = false;
                TxtGATTBN1.Text = "0";
                txtAttB1.Text = "0";
                txtAttB1.Enabled = false;
                TxtGATTBN2.Text = "0";
                txtAttB2.Text = "0";
                txtAttB2.Enabled = false;
                txtBonus.Text = "0";
                txtBonus.Enabled = false;
                TxtGEmpPF.Text = "0";
                TxtGCompPF.Text = "0";
                txtPFEmployee.Text = "0";
                txtPFEmployee.Enabled = false;
                txtPFCompany.Text = "0";
                txtPFCompany.Enabled = false;
                TxtGPTax.Text = "0";
                lblGratuaty.Text = "0";
                TxtAnnGratuaty.Text = "0";
            }

            this.CalSalary(DrpEmpTypeOf.SelectedValue, DrpEmpType.SelectedValue);
        }
        catch (Exception ex) { }
    }
}

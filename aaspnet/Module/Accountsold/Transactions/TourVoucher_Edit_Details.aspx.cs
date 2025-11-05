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

public partial class Module_Accounts_Transactions_TourVoucher_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string sId = "";
    string CDate = "";
    string CTime = "";
    int id = 0;
    int TIMid = 0;
    double TLab = 0;
    double SLab = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            id = Convert.ToInt32(Request.QueryString["Id"]);
            TIMid = Convert.ToInt32(Request.QueryString["TIMId"]);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            if (!IsPostBack)
            {

                string sql = fun.select("*", "tblACC_TourIntimation_Master", "Id='" + TIMid + "'  And   CompId='" + CompId + "' ");
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string cmdStr = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND EmpId='" + ds.Tables[0].Rows[0]["EmpId"] + "'");
                    SqlDataAdapter daStr = new SqlDataAdapter(cmdStr, con);
                    DataSet DSStr = new DataSet();
                    daStr.Fill(DSStr, "tblHR_OfficeStaff");

                    lblEmpName.Text = DSStr.Tables[0].Rows[0]["EmployeeName"].ToString();

                    if (ds.Tables[0].Rows[0]["WONo"].ToString() == "NA")
                    {
                        lblWONoBGGroup.Text = "BG Group";
                        int BGGroupId = Convert.ToInt32(ds.Tables[0].Rows[0]["BGGroupId"].ToString());

                        string cmdStrGroup = fun.select("Name,Symbol", " BusinessGroup", "Id='" + BGGroupId + "'");
                        SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                        SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                        DataSet DSGroup = new DataSet();
                        DAGroup.Fill(DSGroup, "BusinessGroup");
                        if (DSGroup.Tables[0].Rows.Count > 0)
                        {
                            lblWONoBGGroup1.Text = DSGroup.Tables[0].Rows[0]["Name"].ToString() + " [ " + DSGroup.Tables[0].Rows[0]["Symbol"].ToString() + " ]";
                        }

                    }
                    else
                    {
                        lblWONoBGGroup.Text = "WO No";
                        lblWONoBGGroup1.Text = ds.Tables[0].Rows[0]["WONo"].ToString();
                    }
                    lblProjectName.Text = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                    //PlaceOfTour
                    string selectregCt = fun.select("CityName", "tblCity", "CityId='" + ds.Tables[0].Rows[0]["PlaceOfTourCity"] + "'");
                    SqlCommand myCmdct = new SqlCommand(selectregCt, con);
                    SqlDataAdapter adct = new SqlDataAdapter(myCmdct);
                    DataSet Dsct = new DataSet();
                    adct.Fill(Dsct);

                    string selectregSt = fun.select("StateName", "tblState", "SId='" + ds.Tables[0].Rows[0]["PlaceOfTourState"] + "' ");
                    SqlCommand myCmdst = new SqlCommand(selectregSt, con);
                    SqlDataAdapter adst = new SqlDataAdapter(myCmdst);
                    DataSet Dsst = new DataSet();
                    adst.Fill(Dsst);

                    string selectregCnt = fun.select("CountryName", "tblCountry", "CId='" + ds.Tables[0].Rows[0]["PlaceOfTourCountry"] + "' ");
                    SqlCommand myCmdcnt = new SqlCommand(selectregCnt, con);
                    SqlDataAdapter adcnt = new SqlDataAdapter(myCmdcnt);
                    DataSet Dscnt = new DataSet();
                    adcnt.Fill(Dscnt);
                    string PlaceOfTour = "";

                    if (Dsct.Tables[0].Rows.Count > 0 && Dsst.Tables[0].Rows.Count > 0 && Dscnt.Tables[0].Rows.Count > 0)
                    {
                        PlaceOfTour = Dscnt.Tables[0].Rows[0]["CountryName"].ToString() + ", " + Dsst.Tables[0].Rows[0]["StateName"].ToString() + ", " + Dsct.Tables[0].Rows[0]["CityName"].ToString();
                    }
                    lblPlaceOfTour.Text = PlaceOfTour;

                    lblSDate.Text = fun.FromDateDMY(ds.Tables[0].Rows[0]["TourStartDate"].ToString());
                    lblSTime.Text = ds.Tables[0].Rows[0]["TourStartTime"].ToString();
                    lblEDate.Text = fun.FromDateDMY(ds.Tables[0].Rows[0]["TourEndDate"].ToString());
                    lblETime.Text = ds.Tables[0].Rows[0]["TourEndTime"].ToString();
                    lblNoOfDays.Text = (ds.Tables[0].Rows[0]["NoOfDays"].ToString());
                    lblNameAndAddress.Text = ds.Tables[0].Rows[0]["NameAddressSerProvider"].ToString();
                    lblContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                    lblContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    string sql4 = fun.select("AmtBalTowardsCompany,AmtBalTowardsEmployee", "tblACC_TourVoucher_Master", " Id='" + id + "'");
                    SqlCommand cmd4 = new SqlCommand(sql4, con);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        txtAmtBalTowardsCompany.Text = ds4.Tables[0].Rows[0]["AmtBalTowardsCompany"].ToString();
                        txtAmtBalTowardsEmployee.Text = ds4.Tables[0].Rows[0]["AmtBalTowardsEmployee"].ToString();
                    }
                    this.FillGridAdvanceTo();
                    this.fillgrid();

                    lblTAmt1.Text = TLab.ToString();
                    lblTSAmt1.Text = SLab.ToString();
                }
            }
        }
        catch (Exception ex) { }
    }

    public void fillgrid()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {

            string sqlTET = fun.select1("*", "tblACC_TourExpencessType");
            SqlCommand cmdTET = new SqlCommand(sqlTET, con);
            SqlDataAdapter DATET = new SqlDataAdapter(cmdTET);
            DataSet DSTET = new DataSet();
            DATET.Fill(DSTET);
            DataTable dt = new DataTable();
            dt.Columns.Add(new System.Data.DataColumn("TVADId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Terms", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SanctionedAmount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("SanctionedRemarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TDMId", typeof(int)));

            double TotalAmount = 0;
            double TotalAmount1 = 0;
            for (int i = 0; i < DSTET.Tables[0].Rows.Count; i++)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr[1] = DSTET.Tables[0].Rows[i]["Terms"].ToString();
                string sql1 = fun.select("*", "tblACC_TourAdvance_Details", "ExpencessId='" + Convert.ToInt32(DSTET.Tables[0].Rows[i]["Id"]) + "' AND MId='" + TIMid + "'");
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dr[2] = Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"]);
                    dr[3] = ds1.Tables[0].Rows[0]["Remarks"].ToString();
                    TotalAmount += Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"]);
                }
                string sql2 = fun.select("*", "tblACC_TourVoucherAdvance_Details", "MId='" + id + "' AND TDMId='" + Convert.ToInt32(DSTET.Tables[0].Rows[i]["Id"]) + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    dr[0] = Convert.ToInt32(ds2.Tables[0].Rows[0]["Id"]);
                    dr[4] = Convert.ToDouble(ds2.Tables[0].Rows[0]["SanctionedAmount"]);
                    dr[5] = ds2.Tables[0].Rows[0]["Remarks"].ToString();
                    dr[6] = Convert.ToInt32(ds2.Tables[0].Rows[0]["TDMId"]);
                    TotalAmount1 += Convert.ToDouble(ds2.Tables[0].Rows[0]["SanctionedAmount"]);
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            if (GridView2.Rows.Count > 0)
            {
                ((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text = TotalAmount.ToString();
            }
            TLab += TotalAmount;
            SLab += TotalAmount1;
        }
        catch (Exception ex) { }
    }

    public void FillGridAdvanceTo()
    {
        try
        {

            DataTable dt = new DataTable();
            con.Open();
            string str = fun.select("*", "tblACC_TourVoucherAdvance", "MId='" + id + "' ");
            SqlCommand cmdCustWo = new SqlCommand(str, con);
            SqlDataAdapter daCustWo = new SqlDataAdapter(cmdCustWo);
            DataSet DSCustWo = new DataSet();
            daCustWo.Fill(DSCustWo);
            dt.Columns.Add(new System.Data.DataColumn("TVTId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SanctionedAmount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("SanctionedRemarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TATId", typeof(int)));
            DataRow dr;

            double TotalAmount = 0;
            double TotalAmount1 = 0;
            for (int i = 0; i < DSCustWo.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();

                if (DSCustWo.Tables[0].Rows.Count > 0)
                {
                    string sql1 = fun.select("*", "tblACC_TourAdvance", "Id='" + Convert.ToInt32(DSCustWo.Tables[0].Rows[i]["TAMId"]) + "'");
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dr[0] = DSCustWo.Tables[0].Rows[i]["Id"].ToString();
                        string strEmp = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND EmpId='" + ds1.Tables[0].Rows[0]["EmpId"] + "'");

                        SqlCommand cmdEmp = new SqlCommand(strEmp, con);
                        SqlDataAdapter daEmp = new SqlDataAdapter(cmdEmp);
                        DataSet DSEmp = new DataSet();
                        daEmp.Fill(DSEmp);
                        if (DSEmp.Tables[0].Rows.Count > 0)
                        {
                            dr[1] = DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();

                        }
                        dr[2] = Convert.ToDouble(decimal.Parse(ds1.Tables[0].Rows[0]["Amount"].ToString()).ToString("N3"));
                        dr[3] = ds1.Tables[0].Rows[0]["Remarks"].ToString();
                        dr[4] = Convert.ToDouble(DSCustWo.Tables[0].Rows[i]["SanctionedAmount"]);
                        dr[5] = DSCustWo.Tables[0].Rows[i]["Remarks"].ToString();
                        dr[6] = DSCustWo.Tables[0].Rows[i]["TAMId"].ToString();
                        TotalAmount += Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"]);
                        TotalAmount1 += Convert.ToDouble(DSCustWo.Tables[0].Rows[i]["SanctionedAmount"]);
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                ((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text = TotalAmount.ToString();
            }
            TLab += TotalAmount;
            SLab += TotalAmount1;
        }

        catch (Exception ex)
        { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            con.Open();
            int ADVal = 0;
            int ADValCount = 0;
            foreach (GridViewRow grv2 in GridView2.Rows)
            {
                ADValCount++;
                if (((TextBox)grv2.FindControl("txtAmount")).Text != "")
                {
                    ADVal++;
                }
            }

            int ATVal = 0;
            int ATValCount = 0;
            foreach (GridViewRow grv1 in GridView1.Rows)
            {
                ATValCount++;
                if (((TextBox)grv1.FindControl("txtATAmount")).Text != "")
                {
                    ATVal++;
                }
            }

            if (txtAmtBalTowardsCompany.Text != "" && fun.NumberValidationQty(txtAmtBalTowardsCompany.Text) == true && txtAmtBalTowardsEmployee.Text != "" && fun.NumberValidationQty(txtAmtBalTowardsEmployee.Text) == true && (ADValCount - ADVal) == 0 && (ATValCount - ATVal) == 0)
            {
                double BalAmtCompany = 0;
                double BalAmtEmployee = 0;

                double TotalAmount = 0;
                double a = 0;
                double b = 0;

                if (GridView2.Rows.Count > 0)
                {
                    a = Convert.ToDouble(((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text);
                }
                if (GridView1.Rows.Count > 0)
                {
                    b = Convert.ToDouble(((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text);
                }
                TotalAmount = Math.Round((a + b), 2);

                double AdvanceSanTAmt = 0;
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    AdvanceSanTAmt += Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text);
                }
                double AdvanceToSanTAmt = 0;
                foreach (GridViewRow grv in GridView1.Rows)
                {
                    AdvanceToSanTAmt += Convert.ToDouble(((TextBox)grv.FindControl("txtATAmount")).Text);
                }

                double TotalSanctionedAmount = 0;
                TotalSanctionedAmount = Math.Round((AdvanceSanTAmt + AdvanceToSanTAmt), 2);

                if ((TotalAmount - TotalSanctionedAmount) > 0)
                {
                    txtAmtBalTowardsEmployee.Text = (TotalAmount - TotalSanctionedAmount).ToString();
                    txtAmtBalTowardsCompany.Text = "0";
                }
                else
                {
                    txtAmtBalTowardsCompany.Text = (TotalSanctionedAmount - TotalAmount).ToString();
                    txtAmtBalTowardsEmployee.Text = "0";
                }

                 BalAmtCompany = Convert.ToDouble(decimal.Parse(txtAmtBalTowardsCompany.Text).ToString("N2"));
                 BalAmtEmployee = Convert.ToDouble(decimal.Parse(txtAmtBalTowardsEmployee.Text).ToString("N2"));

                string StrUpdate = fun.update("tblACC_TourVoucher_Master", " SysDate='" + CDate + "',SysTime='" + CTime + "', SessionId='" + sId + "', AmtBalTowardsCompany='" + BalAmtCompany + "', AmtBalTowardsEmployee='" + BalAmtEmployee + "'", "CompId='" + CompId + "' And Id='" + id + "'");

                SqlCommand cmdUpdate = new SqlCommand(StrUpdate, con);
                cmdUpdate.ExecuteNonQuery();
                con.Close();

                // For Advance Details
                foreach (GridViewRow grv in GridView2.Rows)
                {
                    int TDMId = Convert.ToInt32(((Label)grv.FindControl("lblTDMId")).Text);
                    string ExRemarks = ((TextBox)grv.FindControl("txtRemarks")).Text;
                    if (((TextBox)grv.FindControl("txtAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtAmount")).Text).ToString("N2")) >= 0)
                    {
                        double ExAmount = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtAmount")).Text).ToString("N2"));
                        string StrAmt = fun.update("tblACC_TourVoucherAdvance_Details", "SanctionedAmount='" + ExAmount + "',Remarks='" + ExRemarks + "'", "MId='" + id + "' AND TDMId='" + TDMId + "'");
                        SqlCommand cmdAmt = new SqlCommand(StrAmt, con);

                        con.Open();
                        cmdAmt.ExecuteNonQuery();
                        con.Close();
                    }
                }

                // For Advance Trans. To
                foreach (GridViewRow grv in GridView1.Rows)
                {
                    int TATId = Convert.ToInt32(((Label)grv.FindControl("lblTATId")).Text);
                    string ExRemarks = ((TextBox)grv.FindControl("txtATRemarks")).Text;

                    if (((TextBox)grv.FindControl("txtATAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtATAmount")).Text).ToString("N2")) >= 0)
                    {
                        double ExAmount = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtATAmount")).Text).ToString("N2"));
                        string StrAmt = fun.update("tblACC_TourVoucherAdvance", "SanctionedAmount='" + ExAmount + "',Remarks='" + ExRemarks + "'", "MId='" + id + "' AND TAMId='" + TATId + "' ");
                        SqlCommand cmdAmt = new SqlCommand(StrAmt, con);
                        con.Open();
                        cmdAmt.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Response.Redirect("TourVoucher_Edit.aspx?ModId=11&SubModId=126");
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Invalid data entry.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception ex) { }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TourVoucher_Edit.aspx?ModId=11&SubModId=126");
    }

    protected void btnSum_Click(object sender, EventArgs e)
    {
        try
        {
            double TotalAmount = 0;
            double a = 0;
            double b = 0;

            if (GridView2.Rows.Count > 0)
            {
                a = Convert.ToDouble(((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text);
            }

            if (GridView1.Rows.Count > 0)
            {
                b = Convert.ToDouble(((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text);
            }

            TotalAmount = Math.Round((a + b), 2);
            double AdvanceSanTAmt = 0;
            foreach (GridViewRow grv in GridView2.Rows)
            {
                AdvanceSanTAmt += Convert.ToDouble(((TextBox)grv.FindControl("txtAmount")).Text);
            }

            double AdvanceToSanTAmt = 0;
            foreach (GridViewRow grv in GridView1.Rows)
            {
                AdvanceToSanTAmt += Convert.ToDouble(((TextBox)grv.FindControl("txtATAmount")).Text);
            }
            double TotalSanctionedAmount = 0;
            TotalSanctionedAmount = Math.Round((AdvanceSanTAmt + AdvanceToSanTAmt), 2);

            if ((TotalAmount - TotalSanctionedAmount) > 0)
            {
                txtAmtBalTowardsEmployee.Text = (TotalAmount - TotalSanctionedAmount).ToString();
                txtAmtBalTowardsCompany.Text = "0";
            }
            else
            {
                txtAmtBalTowardsCompany.Text = (TotalSanctionedAmount - TotalAmount).ToString();
                txtAmtBalTowardsEmployee.Text = "0";
            }
            lblTSAmt1.Text = TotalSanctionedAmount.ToString();
        }
        catch (Exception ex){}

    }
}

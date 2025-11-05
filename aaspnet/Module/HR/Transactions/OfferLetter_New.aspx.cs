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

public partial class Module_HR_Transactions_OfferLetter_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();

    int CompId = 0;
    int FinYearId = 0;
    string SessionId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            SessionId = Session["username"].ToString();
            string constr = fun.Connection();
            SqlConnection con = new SqlConnection(constr);

            if (!IsPostBack)
            {
                Label2.Text = "";
                if (Request.QueryString["msg"] != null)
                {
                    Label2.Text = Request.QueryString["msg"].ToString();
                }

                string sql = fun.select("*", "tblHR_PF_Slab", "Active=1");
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                txtPFEmployee.Text = ds.Tables[0].Rows[0]["PFEmployee"].ToString();
                txtPFCompany.Text = ds.Tables[0].Rows[0]["PFCompany"].ToString();

                this.FillAccegrid();
            }


        }
        catch (Exception ex) { }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            this.CalSalary();
        }
        catch (Exception ex) { }
    }

    public void CalSalary()
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
               // double esi = 0.75;
                //if (DrpEmpType.SelectedItem.Text != "Select")
                {
                    if (DrpEmpType.SelectedItem.Text != "Casuals")
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
                        ptax = fun.PTax_Cal((GrossSalary + AttBonus1 + Convert.ToDouble(TxtGGratia.Text)  - Convert.ToDouble(txtesi.Text) ), "0");
                        TxtGPTax.Text = ptax.ToString();

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

                    if (DrpEmpTypeOf.SelectedValue == "2")
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
                double AccessoriesAmt_PER = 0;

                string sql98 = fun.select("*", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
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

                th = Math.Round((GrossSalary + Convert.ToDouble(TxtGGratia.Text)  - Convert.ToDouble(txtesi.Text) + AccessoriesAmt_TakeHome + AccessoriesAmt_Both+AccessoriesAmt_PER) - (pfe + ptax));
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

                ctc = Math.Round(GrossSalary + Convert.ToDouble(txtBonus.Text) + Convert.ToDouble(TxtAnnLOYAlty.Text) + Convert.ToDouble(TxtGLTA.Text) + Convert.ToDouble(lblGratuaty.Text) + pfc + Convert.ToDouble(TxtGGratia.Text)) + AccessoriesAmt_CTC + AccessoriesAmt_Both + AccessoriesAmt_PER;

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

                txtesi.Text = ((double.Parse(lblesie.Text) * double.Parse(TxtGrossSalry.Text)) / 100).ToString();

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
                string strInsert = fun.insert("tblHR_Offer_Master", "SysDate,SysTime,FinYearId,CompId,SessionId,Title,EmployeeName,TypeOf,StaffType,salary,DutyHrs,OTHrs,OverTime , Address , ContactNo, EmailId , InterviewedBy  , AuthorizedBy, ReferenceBy  , Designation , ExGratia , VehicleAllowance , LTA  , Loyalty  , PaidLeaves,HeaderText,FooterText,Remarks,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany,ESI", "'" + CDate + "','" + CTime + "','" + FinYearId + "','" + CompId + "','" + sId + "','" + DrpTitle.SelectedValue + "','" + TxtName.Text + "','" + DrpEmpTypeOf.SelectedValue + "','" + DrpEmpType.SelectedValue + "','" + TxtGrossSalry.Text + "','" + DrpDutyHrs.SelectedValue + "','" + DrpOTHrs.SelectedValue + "','" + DrpOvertime.SelectedValue + "','" + TxtAddress.Text + "','" + TxtContactNo.Text + "','" + TxtEmail.Text + "','" + fun.getCode(Txtinterviewedby.Text) + "','" + fun.getCode(TxtAuthorizedby.Text) + "','" + TxtReferencedby.Text + "','" + DrpDesignation.SelectedValue + "','" + TxtGGratia.Text + "','" + TxtGVehAll.Text + "','" + TxtGLTA.Text + "','" + TxtAnnLOYAlty.Text + "','" + TxtAnnpaidleaves.Text + "','" + txtHeader.Text + "','" + txtFooter.Text + "','" + TxtRemarks.Text + "','" + txtBonus.Text + "','" + txtAttB1.Text + "','" + txtAttB2.Text + "','" + txtPFEmployee.Text + "','" + txtPFCompany.Text + "','"+txtesi.Text+"'");

                SqlCommand cmd1 = new SqlCommand(strInsert, con);
                cmd1.ExecuteNonQuery();

                string sql97 = fun.select("OfferId", "tblHR_Offer_Master", "CompId='" + CompId + "' order by OfferId DESC");
                SqlCommand cmd97 = new SqlCommand(sql97, con);
                SqlDataAdapter da97 = new SqlDataAdapter(cmd97);
                DataSet ds97 = new DataSet();
                da97.Fill(ds97);

                string sql98 = fun.select("*", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
                SqlCommand cmd98 = new SqlCommand(sql98, con);
                SqlDataAdapter da98 = new SqlDataAdapter(cmd98);
                DataSet ds98 = new DataSet();
                da98.Fill(ds98);

                for (int i = 0; i < ds98.Tables[0].Rows.Count; i++)
                {
                    string sql96 = fun.insert("tblHR_Offer_Accessories", "MId,Perticulars,Qty,Amount,IncludesIn", "'" + ds97.Tables[0].Rows[0][0].ToString() + "','" + ds98.Tables[0].Rows[i]["Perticulars"].ToString() + "','" + ds98.Tables[0].Rows[i]["Qty"].ToString() + "','" + ds98.Tables[0].Rows[i]["Amount"].ToString() + "','" + ds98.Tables[0].Rows[i]["IncludesIn"].ToString() + "'");

                    SqlCommand cmd96 = new SqlCommand(sql96, con);
                    cmd96.ExecuteNonQuery();
                }


                string sql95 = fun.delete("tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
                SqlCommand cmd95 = new SqlCommand(sql95, con);
                cmd95.ExecuteNonQuery();

                con.Close();

                Response.Redirect("OfferLetter_New.aspx?ModId=12&SubModId=25&msg=Employee data is entered.");
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Please fill Data properly.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception ex) { }
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

        this.CalSalary();
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

                    IncludeIn = ((DropDownList)GridView1.FooterRow.FindControl("IncludeIn")).SelectedValue.ToString();
                    string insert = fun.insert("tblHR_Offer_Accessories_Temp", "SessionId,CompId,Perticulars,Qty,Amount,IncludesIn", "'" + SId + "','" + CompId + "','" + strPerticulars + "','" + strAccQty + "','" + strAccAmount + "','" + IncludeIn + "'");

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
                    strPerticulars1 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPerticulars1")).Text; strAccQty1 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text).ToString("N2"));
                    strAccAmount1 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text).ToString("N2"));

                    IncludeIn = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("IncludeIn0")).SelectedValue;
                    string insert1 = fun.insert("tblHR_Offer_Accessories_Temp", "SessionId,CompId,Perticulars,Qty,Amount,IncludesIn", "'" + SId + "','" + CompId + "','" + strPerticulars1 + "','" + strAccQty1 + "','" + strAccAmount1 + "','" + IncludeIn + "'");
                    SqlCommand cmd1 = new SqlCommand(insert1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    this.FillAccegrid();
                }
            }
            this.CalSalary();
        }

        catch (Exception ex) { }
    }

    public void FillAccegrid()
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            string sql = fun.select("SessionId,CompId,[Id],[Perticulars],[Qty],[Amount],Round(([Qty]*[Amount]),2)As Total,IncludesIn", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "' Order by Id DESC");
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

            this.CalSalary();
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
            SqlCommand cmd = new SqlCommand(fun.delete("tblHR_Offer_Accessories_Temp", "Id='" + id + "' AND SessionId='" + SessionId + "'"), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.FillAccegrid();
            this.CalSalary();
        }
        catch (Exception er) { }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.EditIndex = -1;
            this.FillAccegrid();
            this.CalSalary();
        }
        catch (Exception ex) { }
    }
}

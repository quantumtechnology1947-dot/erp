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

public partial class Module_Inventory_Transactions_Stock_Statement : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;
    string cid = "";
    string scid = "";
    string it = "";
    double OverHeads = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            
            if (txtOverheads.Text != "" && fun.NumberValidationQty(txtOverheads.Text))
            {
                OverHeads = Convert.ToDouble(txtOverheads.Text);
            }
            Txtfromdate.Attributes.Add("readonly", "readonly");
            TxtTodate.Attributes.Add("readonly", "readonly");

            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            lblMessage.Text = "";

            SqlCommand CmdFinYear = new SqlCommand("Select FinYearFrom,FinYearTo From tblFinancial_master Where CompId='" + CompId + "' And FinYearId='" + FinYearId + "'", con);
            SqlDataAdapter DAFin = new SqlDataAdapter(CmdFinYear);
            DataSet DSFin = new DataSet();
            DAFin.Fill(DSFin, "tblFinancial_master");
            if (!IsPostBack)
            {
                if (DSFin.Tables[0].Rows.Count > 0)
                {
                    lblFromDate.Text = fun.FromDateDMY(DSFin.Tables[0].Rows[0][0].ToString());
                    lblToDate.Text = fun.FromDateDMY(DSFin.Tables[0].Rows[0][1].ToString());
                }
                DrpCategory1.Items.Clear();
                DrpCategory1.Items.Insert(0, "Select");
                DropDownList3.Visible = false;
                DrpCategory1.Visible = false;
                DrpSearchCode.Visible = false;
                txtSearchItemCode.Visible = false;
                string StrCat = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
                SqlCommand Cmd = new SqlCommand(StrCat, con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS, "tblDG_Category_Master");
                DrpCategory1.DataSource = DS.Tables["tblDG_Category_Master"];
                DrpCategory1.DataTextField = "Category";
                DrpCategory1.DataValueField = "CId";
                DrpCategory1.DataBind();
                DrpCategory1.Items.Insert(0, "Select");                
                Txtfromdate.Text = lblFromDate.Text;
                TxtTodate.Text = fun.FromDateDMY(fun.getCurrDate());
            }
        }
        catch (Exception ex)
        { }
    }
    protected void BtnView_Click(object sender, EventArgs e)
    {
        try
        {
            if (DrpType.SelectedValue != "Select")
            {
                string sd = DrpCategory1.SelectedValue;         

                string fdate = Txtfromdate.Text;
                string tdate = TxtTodate.Text;

                string x = "";
                string p = "";
                string r= "";
                string q = "";
                string s = txtSearchItemCode.Text;
                if (DrpType.SelectedValue == "Category")
                {
                    if (sd != "Select")
                    {

                        x = " AND CId='" + sd + "'";

                        if (DrpSearchCode.SelectedValue != "Select")
                        {
                            if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ItemCode")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And ItemCode Like '"+s.Trim()+"%'";
                            }

                            if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ManfDesc")
                            {
                                txtSearchItemCode.Visible = true;
                                p = " And Description Like '" + s.Trim() + "%'";
                            }


                            if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.Location")
                            {
                                txtSearchItemCode.Visible = false;
                                DropDownList3.Visible = true;

                                if (DropDownList3.SelectedValue != "Select")
                                {
                                    p = " And Location='" + DropDownList3.SelectedValue + "'";
                                }
                            }


                        }
                        q = "And CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
                        r = " And CId is not null";

                    }
                    else
                    {
                        r = " And CId is not null";
                    }
                }

                else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
                {

                    if (DrpSearchCode.SelectedValue != "Select")
                    {
                        if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ItemCode")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And ItemCode Like '"+s.Trim()+"%'";
                        }

                        if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ManfDesc")
                        {
                            txtSearchItemCode.Visible = true;
                            p = " And Description Like '" + s.Trim() + "%'";
                           
                        }
                    }
                    r = " And CId is null";

                }
                
                int RadVal = Convert.ToInt32(RadRate.SelectedValue);
               
                if (Convert.ToDateTime(fun.FromDate(TxtTodate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) <= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && fun.DateValidation(Txtfromdate.Text) == true && fun.DateValidation(TxtTodate.Text) == true)
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    //Response.Redirect("Stock_Statement_Details.aspx?Cid=" + Server.UrlEncode(fun.Encrypt(x)) + "&RadVal=" + Server.UrlEncode(fun.Encrypt(RadVal.ToString())) + "&FDate=" + Server.UrlEncode(fun.Encrypt(fdate)) + "&TDate=" + Server.UrlEncode(fun.Encrypt(tdate)) + "&OpeningDt=" + Server.UrlEncode(fun.Encrypt(fun.FromDate(lblFromDate.Text))) + "&p=" + Server.UrlEncode(fun.Encrypt(p)) + "&r=" + Server.UrlEncode(fun.Encrypt(r)) + "&Key=" + getRandomKey + "");

                    Response.Redirect("Stock_Statement_Details1.aspx?Cid=" + x + "&RadVal=" + RadVal.ToString() + "&FDate=" + fdate + "&TDate=" + tdate + "&OpeningDt=" + fun.FromDate(lblFromDate.Text) + "&p=" + p + "&r=" + r + "&OverHeads=" + OverHeads + "&Key=" + getRandomKey + "");
                }
                else if (Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)))
                {
                    lblMessage.Text = "From date should not be Less than Opening Date!";
                }
                else
                {
                    lblMessage.Text = "From date should be Less than or Equal to To Date!";
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Select Category or WO Items.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }

        catch (Exception ex) { }

    }

    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }   
   

    protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (DrpType.SelectedValue)
            {
                case "Category":
                    {
                        DrpSearchCode.Visible = true;
                        DropDownList3.Visible = true;
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";
                        DrpCategory1.Visible = true;

                        string connStr = fun.Connection();
                        SqlConnection con = new SqlConnection(connStr);

                        DataSet DS = new DataSet();
                        string StrCat = fun.select("CId,Symbol+'-'+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
                        SqlCommand Cmd = new SqlCommand(StrCat, con);
                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DA.Fill(DS, "tblDG_Category_Master");
                        DrpCategory1.DataSource = DS.Tables["tblDG_Category_Master"];
                        DrpCategory1.DataTextField = "Category";
                        DrpCategory1.DataValueField = "CId";
                        DrpCategory1.DataBind();
                        DrpCategory1.Items.Insert(0, "Select");
                        DrpCategory1.ClearSelection();
                        
                        fun.drpLocat(DropDownList3);

                        if (DrpSearchCode.SelectedItem.Text == "Location")
                        {
                            DropDownList3.Visible = true;
                            txtSearchItemCode.Visible = false;
                            txtSearchItemCode.Text = "";
                        }
                        else
                        {
                            DropDownList3.Visible = false;
                            txtSearchItemCode.Visible = true;
                            txtSearchItemCode.Text = "";
                        }

                    }
                    break;

                case "WOItems":
                    {
                        txtSearchItemCode.Visible = true;
                        txtSearchItemCode.Text = "";


                        DrpSearchCode.Visible = true;
                        DrpCategory1.Visible = false;
                        DrpCategory1.Items.Clear();
                        DrpCategory1.Items.Insert(0, "Select");

                        DropDownList3.Visible = false;
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Insert(0, "Select");
                    }
                    break;

                case "Select":
                    {
                        string myStringVariable = string.Empty;
                        myStringVariable = "Please Select Category or WO Items.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);


                    }
                    break;
            }
        }
        catch (Exception ex) { }
    }

    protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpCategory1.SelectedValue != "Select")
            {
                DrpSearchCode.Visible = true;
                txtSearchItemCode.Text = "";
            }
        }
        catch (Exception ex) { }

    }

    protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpSearchCode.SelectedItem.Text == "Location")
        {
            DropDownList3.Visible = true;
            txtSearchItemCode.Visible = false;
            txtSearchItemCode.Text = "";
        }
        else
        {
            DropDownList3.Visible = false;
            txtSearchItemCode.Visible = true;
            txtSearchItemCode.Text = "";
        }
    }


}

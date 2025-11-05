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

public partial class Module_Inventory_Reports_ABCAnalysis : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;

    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            lblMessage.Text = "";
            Txtfromdate.Attributes.Add("readonly", "readonly");
            TxtTodate.Attributes.Add("readonly", "readonly");

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

                SqlCommand Cmd = new SqlCommand("Select CId,'['+Symbol+'] - '+CName as Category From tblDG_Category_Master", con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS, "tblDG_Category_Master");
                DrpCategory.DataSource = DS.Tables["tblDG_Category_Master"];

                DrpCategory.DataTextField = "Category";
                DrpCategory.DataValueField = "CId";
                DrpCategory.DataBind();
                DrpCategory.Items.Insert(0, "Select");
               
                Txtfromdate.Text = lblFromDate.Text;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void BtnView_Click(object sender, EventArgs e)
    {
        try
        {
            string fdate = Txtfromdate.Text;
            string tdate = TxtTodate.Text;


            string x = "0";            

          //  double a = Convert.ToDouble(decimal.Parse(TxtboxA.Text).ToString("N3"));
          //  double b = Convert.ToDouble(decimal.Parse(TxtboxB.Text).ToString("N3"));
          //  double c = Convert.ToDouble(decimal.Parse(TxtboxC.Text).ToString("N3"));
          //  double D = a + b + c;


            if (DrpCategory.SelectedValue != "Select")
            {
                x = DrpCategory.SelectedValue;
            }

            int RadVal = Convert.ToInt32(RadRate.SelectedValue);
            //if (D ==  && fun.NumberValidationQty(TxtboxA.Text) == true && fun.NumberValidationQty(TxtboxB.Text) == true && fun.NumberValidationQty(TxtboxC.Text) == true)
            {
                if (Convert.ToDateTime(fun.FromDate(TxtTodate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) <= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && fun.DateValidation(Txtfromdate.Text) == true && fun.DateValidation(TxtTodate.Text) == true)
                {

                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("ABCAnalysis_DetailsS.aspx?Cid=" + Server.UrlEncode(fun.Encrypt(x.ToString())) + "&RadVal=" + Server.UrlEncode(fun.Encrypt(RadVal.ToString())) + "&FDate=" + Server.UrlEncode(fun.Encrypt(fdate)) + "&TDate=" + Server.UrlEncode(fun.Encrypt(tdate)) + "&OpeningDt=" + Server.UrlEncode(fun.Encrypt(fun.FromDate(lblFromDate.Text))) + "&Key=" + getRandomKey + "");
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

           // else
           {
              //  lblMessage.Text = "Total Percentage should be 100%ghhg";
            }
        }
        catch (Exception ex) { }

    }
    protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}

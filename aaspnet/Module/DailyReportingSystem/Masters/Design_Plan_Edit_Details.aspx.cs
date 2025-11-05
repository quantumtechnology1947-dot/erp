using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Module_DailyReportingSystem_Masters_Design_Plan_Edit_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string idwono = "";
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;
    string connStr = "";
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);

            if (!Page.IsPostBack)
            {
                this.BindDataCust(idwono);
            }
        }
        catch (Exception ex) { }
    }

    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            SearchGridView1.PageIndex = e.NewPageIndex;
            this.BindDataCust(idwono);
        }

        catch (Exception ex)
        { }

    }

    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            string y = "";
            if (TxtSearchValue.Text != "")
            {
                this.BindDataCust(TxtSearchValue.Text);
            }
            else
            {
                this.BindDataCust(idwono);
            }
        }

        catch (Exception ex)
        { }

    }



    public void BindDataCust(string idwono)
    {
        try
        {

            DataTable dt = new DataTable();
            con.Open();
            string x = "";
            if (TxtSearchValue.Text != "")
            {
                string WoId = fun.getCode(TxtSearchValue.Text);
                x = " AND idwono='" + WoId + "'";
            }

            string StrCust = fun.select("idwono,idsr,idfxn,idconcpd,idintrnrw,iddaps,iddapr,idcrr,Id", "DRTS_Desing_Plan_New", "FinYearId<=" + FinYearId + " AND CompId='" + CompId + "'" + x + "Order By Id Desc");

            SqlCommand cmdCust = new SqlCommand(StrCust, con);
            SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
            DataSet DSCust = new DataSet();
            daCust.Fill(DSCust);
            dt.Columns.Add(new System.Data.DataColumn("idwono", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("idsr", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("idfxn", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("idconcpd", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("idintrnrw", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("iddaps", typeof(string)));
            DataRow dr;
            for (int i = 0; i < DSCust.Tables[0].Rows.Count; i++)
            {

                dr = dt.NewRow();

                string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSCust.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);


                string strEmp = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DSCust.Tables[0].Rows[i]["SessionId"] + "'");

                SqlCommand cmdEmp = new SqlCommand(strEmp, con);
                SqlDataAdapter daEmp = new SqlDataAdapter(cmdEmp);
                DataSet DSEmp = new DataSet();
                daEmp.Fill(DSEmp);
                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[0] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                }
                dr[1] = DSCust.Tables[0].Rows[i]["idwono"].ToString();
                dr[2] = DSCust.Tables[0].Rows[i]["idwono"].ToString();
                dr[3] = DSCust.Tables[0].Rows[i]["SysDate"].ToString();
                if (DSEmp.Tables[0].Rows.Count > 0)
                {
                    dr[4] = DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                }


                string strCong_add = DSCust.Tables[0].Rows[i]["idwono"].ToString();
                //string strCong_country = fun.select("CountryName", "tblcountry", "idwono='" + DSCust.Tables[0].Rows[i]["RegdCountry"] + "'");
               // string strCong_state = fun.select("StateName", "tblState", "SId='" + DSCust.Tables[0].Rows[i]["RegdState"] + "'");
               // string strCong_city = fun.select("CityName", "tblCity", "CityId='" + DSCust.Tables[0].Rows[i]["RegdCity"] + "'");
                //SqlCommand Cmd11 = new SqlCommand(strCong_country, con);
                //SqlCommand Cmd21 = new SqlCommand(strCong_state, con);
                //SqlCommand Cmd31 = new SqlCommand(strCong_city, con);
                //SqlDataAdapter DA11 = new SqlDataAdapter(Cmd11);
               // SqlDataAdapter DA21 = new SqlDataAdapter(Cmd21);
               // SqlDataAdapter DA31 = new SqlDataAdapter(Cmd31);
               // DataSet ds11 = new DataSet();
               // DataSet ds21 = new DataSet();
               // DataSet ds31 = new DataSet();
              //  DA11.Fill(ds11, "tblCountry");
              //  DA21.Fill(ds21, "tblState");
               // DA31.Fill(ds31, "tblcity");

              //  string Consignee_Address = strCong_add + ",\n" + ds31.Tables[0].Rows[0]["CityName"].ToString() + ", " + ds21.Tables[0].Rows[0]["StateName"].ToString() + ",\n" + ds11.Tables[0].Rows[0]["CountryName"].ToString() + ".";
               // dr[5] = Consignee_Address;
                dt.Rows.Add(dr);
                dt.AcceptChanges();


            }
            SearchGridView1.DataSource = dt;
            SearchGridView1.DataBind();
            con.Close();



        }

        catch (Exception ex)
        { }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "SD_Cust_master");
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
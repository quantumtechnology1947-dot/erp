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

public partial class Module_Accounts_Transactions_TourVoucher_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    int CompId = 0; 
    int FyId = 0;
    string co = "";
    string id = "";
  

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FyId = Convert.ToInt32(Session["finyear"].ToString());
            CompId = Convert.ToInt32(Session["compid"]);
            if (!IsPostBack)
            {
                TxtMrs.Visible = false;
                drpGroup.Visible = false;
                this.binddata(co, id);
            }
        }
         catch (Exception ex) { }

    }
    public void binddata(string Search, string EmpId)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {

            string x = "";
            string y = "";
            string z = "";
            if (DrpField.SelectedValue == "1")
            {
                if (TxtEmpName.Text != "")
                {
                    y = " AND EmpId='" + fun.getCode(TxtEmpName.Text) + "'";
                }
            }
            if (DrpField.SelectedValue == "Select")
            {
                TxtMrs.Visible = true;
                TxtEmpName.Visible = false;
            }

            if (DrpField.SelectedValue == "0")
            {
                if (TxtMrs.Text != "")
                {

                    x = " AND TINo='" + TxtMrs.Text + "'";
                }
            }
            if (DrpField.SelectedValue == "2")
            {
                if (TxtMrs.Text != "")
                {
                    x = " AND WONo='" + TxtMrs.Text + "'";
                }
            }
            if (DrpField.SelectedValue == "3")
            {               

                    x = " AND BGGroupId='" + drpGroup.SelectedValue + "'"; 
            }
            if (DrpField.SelectedValue == "4")
            {
                if (TxtMrs.Text != "")
                {

                    x = " AND ProjectName like '%" + TxtMrs.Text + "%'";
                }
            }

            if (DrpField.SelectedValue == "5")
            {
                if (TxtMrs.Text != "")
                {
                    z = " AND TVNo ='" + TxtMrs.Text + "'";
                }
            }


            DataTable dt = new DataTable();
            string sql = fun.select("*", "tblACC_TourVoucher_Master", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'"+z+" Order by Id Desc ");

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//0
            dt.Columns.Add(new System.Data.DataColumn("EmpId", typeof(string)));//1
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));//2
            dt.Columns.Add(new System.Data.DataColumn("EmpName", typeof(string)));//3
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));//4
            dt.Columns.Add(new System.Data.DataColumn("BGgroup", typeof(string)));//5
            dt.Columns.Add(new System.Data.DataColumn("ProjectName", typeof(string)));//6
            dt.Columns.Add(new System.Data.DataColumn("PlaceOfTour", typeof(string)));//7
            dt.Columns.Add(new System.Data.DataColumn("TourStartDate", typeof(string)));//8
            dt.Columns.Add(new System.Data.DataColumn("TourEndDate", typeof(string)));//9
            dt.Columns.Add(new System.Data.DataColumn("TVNo", typeof(string)));//10
            dt.Columns.Add(new System.Data.DataColumn("TINo", typeof(string))); // 11         
            dt.Columns.Add(new System.Data.DataColumn("TIMId", typeof(int)));//12

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr;
                dr = dt.NewRow();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr[0] = ds.Tables[0].Rows[i]["Id"].ToString();
                    dr[10] = ds.Tables[0].Rows[i]["TVNo"].ToString();
                    dr[12] = ds.Tables[0].Rows[i]["TIMId"].ToString();

                    string sql1 = fun.select("*", "tblACC_TourIntimation_Master", "Id='" + ds.Tables[0].Rows[i]["TIMId"].ToString() + "' AND CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + y + x + " Order by Id Desc");

                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                
                    if (ds1.Tables[0].Rows.Count > 0)
                    {                    

                        dr[1] = ds1.Tables[0].Rows[0]["EmpId"].ToString();
                        string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + ds1.Tables[0].Rows[0]["FinyearId"] + "'");
                        SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                        SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                        DataSet DSFin = new DataSet();
                        daFin.Fill(DSFin);
                        if (DSFin.Tables[0].Rows.Count > 0)
                        {
                            dr[2] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                        }


                        string cmdStr = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FyId + "' AND EmpId='" + ds1.Tables[0].Rows[0]["EmpId"] + "'");
                        SqlDataAdapter daStr = new SqlDataAdapter(cmdStr, con);
                        DataSet DSStr = new DataSet();
                        daStr.Fill(DSStr, "tblHR_OfficeStaff");

                        dr[3] = DSStr.Tables[0].Rows[0]["EmployeeName"].ToString();

                        if (ds1.Tables[0].Rows[0]["BGGroupId"].ToString() != "1")
                        {
                            string sqlGrp = fun.select("Symbol AS BGgroup", "BusinessGroup", "Id='" + ds1.Tables[0].Rows[0]["BGGroupId"].ToString() + "'");
                            SqlCommand cmdGrp = new SqlCommand(sqlGrp, con);
                            SqlDataAdapter daGrp = new SqlDataAdapter(cmdGrp);
                            DataSet DSGrp = new DataSet();
                            daGrp.Fill(DSGrp);
                            if (DSGrp.Tables[0].Rows.Count > 0)
                            {
                                dr[5] = DSGrp.Tables[0].Rows[0]["BGgroup"].ToString();
                                dr[4] = "NA";
                            }

                        }
                        else
                        {
                            dr[5] = "NA";
                            dr[4] = ds1.Tables[0].Rows[0]["WONo"].ToString();
                        }

                        dr[6] = ds1.Tables[0].Rows[0]["ProjectName"].ToString();

                        //PlaceOfTour
                        string selectregCt = fun.select("CityName", "tblCity", "CityId='" + ds1.Tables[0].Rows[0]["PlaceOfTourCity"] + "'");
                        SqlCommand myCmdct = new SqlCommand(selectregCt, con);
                        SqlDataAdapter adct = new SqlDataAdapter(myCmdct);
                        DataSet Dsct = new DataSet();
                        adct.Fill(Dsct);

                        string selectregSt = fun.select("StateName", "tblState", "SId='" + ds1.Tables[0].Rows[0]["PlaceOfTourState"] + "' ");
                        SqlCommand myCmdst = new SqlCommand(selectregSt, con);
                        SqlDataAdapter adst = new SqlDataAdapter(myCmdst);
                        DataSet Dsst = new DataSet();
                        adst.Fill(Dsst);

                        string selectregCnt = fun.select("CountryName", "tblCountry", "CId='" + ds1.Tables[0].Rows[0]["PlaceOfTourCountry"] + "' ");
                        SqlCommand myCmdcnt = new SqlCommand(selectregCnt, con);
                        SqlDataAdapter adcnt = new SqlDataAdapter(myCmdcnt);
                        DataSet Dscnt = new DataSet();
                        adcnt.Fill(Dscnt);
                        string PlaceOfTour = "";

                        if (Dsct.Tables[0].Rows.Count > 0 && Dsst.Tables[0].Rows.Count > 0 && Dscnt.Tables[0].Rows.Count > 0)
                        {
                            PlaceOfTour = Dscnt.Tables[0].Rows[0]["CountryName"].ToString() + ", " + Dsst.Tables[0].Rows[0]["StateName"].ToString() + ", " + Dsct.Tables[0].Rows[0]["CityName"].ToString();
                        }
                        dr[7] = PlaceOfTour;
                        dr[8] = fun.FromDateDMY(ds1.Tables[0].Rows[0]["TourStartDate"].ToString());
                        dr[9] = fun.FromDateDMY(ds1.Tables[0].Rows[0]["TourEndDate"].ToString());
                        dr[11] = ds1.Tables[0].Rows[0]["TINo"].ToString();
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();

            con.Close();
        }
        catch (Exception ex) { }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       try
        {
            string CustId = fun.getCode(TxtEmpName.Text);
            this.binddata(TxtMrs.Text, CustId);
        }
        catch (Exception ex){}

    }
    protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            if (DrpField.SelectedValue == "Select")
            {
                drpGroup.Visible = false;
                TxtMrs.Visible = true;
                TxtMrs.Text = "";
                TxtEmpName.Visible = false;
                this.binddata(co, id);
            }
            if (DrpField.SelectedValue == "1")
            {
                drpGroup.Visible = false;
                TxtMrs.Visible = false;
                TxtEmpName.Visible = true;
                TxtEmpName.Text = "";
                this.binddata(co, id);
            }
            if (DrpField.SelectedValue == "0" || DrpField.SelectedValue == "2" || DrpField.SelectedValue == "4" || DrpField.SelectedValue == "5")
            {
                drpGroup.Visible = false;
                TxtMrs.Visible = true;
                TxtMrs.Text = "";
                TxtEmpName.Visible = false;
                this.binddata(co, id);
            }

            if (DrpField.SelectedValue == "3")
            {
                TxtMrs.Visible = false;
                TxtMrs.Text = "";
                TxtEmpName.Visible = false;
                drpGroup.Visible = true;
                string cmdStrGroup = fun.select1("Symbol,Id ", " BusinessGroup");
                SqlCommand cmdGroup = new SqlCommand(cmdStrGroup, con);
                SqlDataAdapter DAGroup = new SqlDataAdapter(cmdGroup);
                DataSet DSGroup = new DataSet();
                DAGroup.Fill(DSGroup, "BusinessGroup");
                drpGroup.DataSource = DSGroup;
                drpGroup.DataTextField = "Symbol";
                drpGroup.DataValueField = "Id";
                drpGroup.DataBind();
                this.binddata(co, id);
            }
        }
        catch (Exception ex){}
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


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sel")
            {
                string getRandomKey = fun.GetRandomAlphaNumeric();
                GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                int TIMId = Convert.ToInt32(((Label)grv.FindControl("lblTIMId")).Text);
                Response.Redirect("TourVoucher_Print_Details.aspx?Id=" + Id + "&TIMId=" + TIMId + "&ModId=11&SubModId=126&Key=" + getRandomKey + "");
            }
        }
        catch (Exception es) { }

    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.binddata(co, id);
    }
}

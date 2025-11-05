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

public partial class Module_Accounts_Transactions_TourVoucher : System.Web.UI.Page
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

            DataTable dt = new DataTable();
            string sql = fun.select("*", "tblACC_TourIntimation_Master", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + y + x + " Order by Id Desc ");

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BGgroup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ProjectName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PlaceOfTour", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TourStartDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TourEndDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TINo", typeof(string)));

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr;
                dr = dt.NewRow();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr[0] = ds.Tables[0].Rows[i]["Id"].ToString();

                    dr[1] = ds.Tables[0].Rows[i]["EmpId"].ToString();
                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + ds.Tables[0].Rows[i]["FinyearId"] + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);
                    if (DSFin.Tables[0].Rows.Count > 0)
                    {
                        dr[2] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                    }


                    string cmdStr = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND FinYearId<='" + FyId + "' AND EmpId='" + ds.Tables[0].Rows[i]["EmpId"] + "'");
                    SqlDataAdapter daStr = new SqlDataAdapter(cmdStr, con);
                    DataSet DSStr = new DataSet();
                    daStr.Fill(DSStr, "tblHR_OfficeStaff");

                    dr[3] = DSStr.Tables[0].Rows[0]["EmployeeName"].ToString();

                    if (ds.Tables[0].Rows[i]["BGGroupId"].ToString() != "1")
                    {
                        string sqlGrp = fun.select("Symbol AS BGgroup", "BusinessGroup", "Id='" + ds.Tables[0].Rows[i]["BGGroupId"].ToString() + "'");
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
                        dr[4] = ds.Tables[0].Rows[i]["WONo"].ToString();
                    }

                    dr[6] = ds.Tables[0].Rows[i]["ProjectName"].ToString();

                    //PlaceOfTour
                    string selectregCt = fun.select("CityName", "tblCity", "CityId='" + ds.Tables[0].Rows[i]["PlaceOfTourCity"] + "'");
                    SqlCommand myCmdct = new SqlCommand(selectregCt, con);
                    SqlDataAdapter adct = new SqlDataAdapter(myCmdct);
                    DataSet Dsct = new DataSet();
                    adct.Fill(Dsct);

                    string selectregSt = fun.select("StateName", "tblState", "SId='" + ds.Tables[0].Rows[i]["PlaceOfTourState"] + "' ");
                    SqlCommand myCmdst = new SqlCommand(selectregSt, con);
                    SqlDataAdapter adst = new SqlDataAdapter(myCmdst);
                    DataSet Dsst = new DataSet();
                    adst.Fill(Dsst);

                    string selectregCnt = fun.select("CountryName", "tblCountry", "CId='" + ds.Tables[0].Rows[i]["PlaceOfTourCountry"] + "' ");
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

                    dr[8] = fun.FromDateDMY(ds.Tables[0].Rows[i]["TourStartDate"].ToString());
                    dr[9] = fun.FromDateDMY(ds.Tables[0].Rows[i]["TourEndDate"].ToString());
                    dr[10] = ds.Tables[0].Rows[i]["TINo"].ToString();

                    string sqlTIMId = fun.select("TIMId", "tblACC_TourVoucher_Master", "TIMId='" + Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()) + "' AND CompId='" + CompId + "' And FinYearId<='" + FyId + "'");
                    SqlCommand cmdTIMId = new SqlCommand(sqlTIMId, con);
                    SqlDataAdapter DATIMId = new SqlDataAdapter(cmdTIMId);
                    DataSet DSTIMId = new DataSet();
                    DATIMId.Fill(DSTIMId);
                    if (DSTIMId.Tables[0].Rows.Count == 0 )
                    {
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
            if (DrpField.SelectedValue == "0" || DrpField.SelectedValue == "2" || DrpField.SelectedValue == "4")
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
                GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int Id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                Response.Redirect("TourVoucher_Details.aspx?Id=" + Id + "&ModId=11&SubModId=126");
            }
        }
        catch (Exception es)
        {

        }
    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.binddata(co, id);
    }
}

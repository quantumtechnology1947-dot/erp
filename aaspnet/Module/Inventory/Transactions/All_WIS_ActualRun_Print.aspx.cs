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
using CrystalDecisions.CrystalReports.Engine;

public partial class Module_Inventory_Transactions_WIS_ActualRun_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    int CompId = 0;
    int FinYearId = 0;
    string SId = "";
    string connStr = "";
    SqlConnection con;
    string CDate = "";
    string CTime = "";
    string Wo = "";
    int h = 0;
    private ReportDocument report = new ReportDocument(); 

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string x = "";
        string z = "";
        string FDate = "";
        string TDate = "";
        double OverHeads =0;

       // if (txtWONo.Text != "")
        //{
        //    x = "  And WONo='" + txtWONo.Text + "'";
       // }

        if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty )
        {
            z = "    And SysDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
        }

        if (txtOverheads.Text != "" && fun.NumberValidationQty(txtOverheads.Text))
        {
           OverHeads = Convert.ToDouble(txtOverheads.Text);
        }

        string getRandomKey = fun.GetRandomAlphaNumeric();
        Iframe1.Attributes.Add("src", "WISWONO_Print_.aspx?z=" + z + "&Key=" + getRandomKey + "&FDate=" + FDate + "&TDate=" + TDate + "&OverHeads=" + OverHeads + "");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            if (!IsPostBack)
            {
                string StrCat = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
                SqlCommand Cmd = new SqlCommand(StrCat, con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS, "tblSD_WO_Category");
                DrpWOType.DataSource = DS.Tables["tblSD_WO_Category"];
                DrpWOType.DataTextField = "Category";
                DrpWOType.DataValueField = "CId";
                DrpWOType.DataBind();
                DrpWOType.Items.Insert(0, "WO Category");
                this.loadgrid(Wo,h);
            }
        }
        catch(Exception ex)
        {
            }
    }

    public void loadgrid(string WO, int C)
    {
        try
        {
            string x = "";
            if (TxtWO.Text != "")
            {
                x = " AND WONo='" + WO + "'";
            }
            string Z = "";
            if (DrpWOType.SelectedValue != "WO Category")
            {

                Z = " AND CId='" + Convert.ToInt32(DrpWOType.SelectedValue) + "'";
            }
            string y = "";
            SqlDataAdapter da = new SqlDataAdapter("Sp_WIS_ActualRun_Grid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@CompId"].Value = CompId;
            da.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@z"].Value = Z;
            da.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@x"].Value = x;
            da.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
            da.SelectCommand.Parameters["@y"].Value = y;
            DataSet DSitem = new DataSet();
            da.Fill(DSitem);
            GridView2.DataSource = DSitem;
            GridView2.DataBind();
            

        }
        catch (Exception st)
        {

        }
        
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {   
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            string wono = ((Label)row.FindControl("lblwono")).Text;
            
            Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Assembly.aspx?WONo=" + wono + "&ModId=9&SubModId=53");
        }

        if (e.CommandName == "view")
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            string wono = ((Label)row.FindControl("lblwono")).Text;
            int typ = Convert.ToInt32(((DropDownList)row.FindControl("drpIssueShortage")).SelectedValue);
            string getRandomKey = fun.GetRandomAlphaNumeric();
            switch (typ)
            {
                case 0:
                    Response.Redirect("~/Module/Inventory/Transactions/WIS_View_TransWise.aspx?WONo=" + wono + "&ModId=9&SubModId=53&Type=" + typ + "&status=1");
                    break;

                case 1:
                    Response.Redirect("~/Module/Inventory/Transactions/TotalIssueAndShortage_Print.aspx?WONo=" + wono + "&Key=" + getRandomKey + "&ModId=9&SubModId=53&Type=" + typ + "&status=1");

                    break;
                case 2:
                    Response.Redirect("~/Module/Inventory/Transactions/TotalShortage_Print.aspx?WONo=" + wono + "&Key=" + getRandomKey + "&ModId=9&SubModId=53&Type=" + typ + "&status=1");

                    break;

            }

        }

    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.loadgrid(Wo,h);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.loadgrid(TxtWO.Text, h);

    }
    protected void DrpWOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpWOType.SelectedValue != "WO Category")
        {
            int k = Convert.ToInt32(DrpWOType.SelectedValue);
            this.loadgrid(Wo, k);
        }
        else
        {
            this.loadgrid(Wo, h);
        }
    }
}

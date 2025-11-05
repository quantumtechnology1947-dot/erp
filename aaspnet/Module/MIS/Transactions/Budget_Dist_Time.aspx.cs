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

public partial class Module_Accounts_Transactions_Budget_Dist_Time : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    Cal_Used_Hours CUH = new Cal_Used_Hours();
    
    int CompId = 0;
    string SId = "";
    int FinYearId = 0;
    string BGid = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        CompId = Convert.ToInt32(Session["compid"]);
        SId = Session["username"].ToString();
        FinYearId = Convert.ToInt32(Session["finyear"]);
        if (!string.IsNullOrEmpty(Request.QueryString["BGId"]))
        {
            BGid = Request.QueryString["BGId"].ToString();
        }
        if (!IsPostBack)
        {
            if (BGid != "")
            {
                string dept = "Select Name,Symbol from BusinessGroup where Id='" + BGid + "'";
                SqlCommand cmddept = new SqlCommand(dept, con);
                SqlDataAdapter dadept = new SqlDataAdapter(cmddept);
                DataSet dsdept = new DataSet();
                dadept.Fill(dsdept);
                lblBGGroup.Text = dsdept.Tables[0].Rows[0]["Name"].ToString();
                HField.Text = BGid;
                ViewState["BGSymbol"] = dsdept.Tables[0].Rows[0]["Symbol"].ToString();
                this.FillGrid();
                btnCancel1.Visible = false;
            }
        }
        TabContainer1.OnClientActiveTabChanged = "OnChanged";
        TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
    }

    public void FillGrid()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        con.Open();

        DataTable dt = new DataTable();
        dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
        dt.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
        dt.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
        DataRow dr;

        string sqlGrade = fun.select("Id,Description AS Name,Symbol", "tblHR_Grade", "Id!=1");
        SqlCommand cmdGrade = new SqlCommand(sqlGrade, con);
        SqlDataAdapter DAGrade = new SqlDataAdapter(cmdGrade);
        DataSet DSGrade = new DataSet();
        DAGrade.Fill(DSGrade);
        GridView1.DataSource = DSGrade.Tables[0];
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow grv in GridView1.Rows)
            {
                int accid = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);
                string Bcode = fun.select("Symbol", "tblHR_Grade", "Id='" + accid + "'");
                SqlCommand cmd = new SqlCommand(Bcode, con);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                ((Label)grv.FindControl("LblBudgetCode")).Text = String.Concat(Ds.Tables[0].Rows[0]["Symbol"].ToString(), ViewState["BGSymbol"].ToString());

            }
        }
        lblBG.Visible = true;
        lblBGGroup.Visible = true;

        this.CalculateBalAmt();
        BtnInsert.Visible = true;
        BtnExport.Visible = true;
        btnCancel.Visible = true;
    }

    public void CalculateBalAmt()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            con.Open();
            int prevYear = 0;
            prevYear = (FinYearId - 1);
            DataTable DT = new DataTable();
            DT.Columns.Add(new System.Data.DataColumn("Sr No", typeof(int)));
            //DT.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
            DT.Columns.Add(new System.Data.DataColumn("Symbol", typeof(string)));
            DT.Columns.Add(new System.Data.DataColumn("Budget Code", typeof(string)));
            DT.Columns.Add(new System.Data.DataColumn("Budget Hour", typeof(double)));
            DT.Columns.Add(new System.Data.DataColumn("Used Hour", typeof(double)));
            DT.Columns.Add(new System.Data.DataColumn("Bal Hour", typeof(double)));

            int SrNo = 1;
            DataRow dr;
            foreach (GridViewRow grv in GridView1.Rows)
            {
                dr = DT.NewRow();
                dr[0] = SrNo++;
                // dr[1] = ((Label)grv.FindControl("lblDesc")).Text;

                dr[1] = ((Label)grv.FindControl("lblSymbol")).Text;
                dr[2] = ((Label)grv.FindControl("LblBudgetCode")).Text;

                int BGId = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);             

                double hours = 0;
                double openingBalOfPrevYear = 0;
                openingBalOfPrevYear = calbalbud.TotBalBudget_BG(BGId, CompId, prevYear, 0);

                string selectBudget = "select Sum(Hour) As Hour from tblACC_Budget_Dept_Time where BudgetCodeId='" + BGId + "'  and  BGGroup='" + HField.Text + "' And FinYearId<=" + FinYearId + "  group by  BudgetCodeId ";

                SqlCommand cmdBD = new SqlCommand(selectBudget, con);
                SqlDataAdapter daBD = new SqlDataAdapter(cmdBD);
                DataSet dsBD = new DataSet();
                daBD.Fill(dsBD, "tblACC_Budget_Dept_Time");
                if (dsBD.Tables[0].Rows.Count > 0)
                {
                    hours = Math.Round((Convert.ToDouble(dsBD.Tables[0].Rows[0]["Hour"]) + openingBalOfPrevYear), 2);
                    ((HyperLink)grv.FindControl("HyperLink1")).Visible = true;
                }
                else
                {
                    hours = openingBalOfPrevYear;
                    ((HyperLink)grv.FindControl("HyperLink1")).Visible = false;
                }

                double UH = 0;
                UH =Math.Round(Convert.ToDouble(CUH.TotFillPart(BGId, "", Convert.ToInt32(HField.Text),CompId,FinYearId,0)),2);
                double BH = 0;
                BH = Math.Round((hours - UH),2);

                ((Label)grv.FindControl("lblHour")).Text = hours.ToString();
                ((Label)grv.FindControl("LblUsedHour")).Text = UH.ToString();
                ((Label)grv.FindControl("LblBalHour")).Text = BH.ToString();
               
                dr[3] = Math.Round(hours, 2);
                dr[4] = UH.ToString();
                dr[5] = BH.ToString();

                ((HyperLink)grv.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_Dist_Dept_Details_Time.aspx?BGId=" + HField.Text + "&Id=" + BGId + "&ModId=14";

                DT.Rows.Add(dr);
                DT.AcceptChanges();
            }
            ViewState["dtList"] = DT;
        }

        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    ((TextBox)grv.FindControl("TxtHour")).Visible = true;
                    ((Label)grv.FindControl("lblHour")).Visible = false;
                }
                else
                {
                    ((Label)grv.FindControl("lblHour")).Visible = true;
                    ((TextBox)grv.FindControl("TxtHour")).Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/MIS/Transactions/Budget_Dist_Time.aspx?BGId=&ModId=14");
    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
         Response.Redirect("Menu.aspx?ModId=14&SubModId=");
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            int id = 0;
            con.Open();
            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                {
                    id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    double Hour = Math.Round ( Convert.ToDouble(((TextBox)grv.FindControl("TxtHour")).Text),2);
                    if (Hour > 0)
                    {
                        string insert = ("Insert into  tblACC_Budget_Dept_Time (SysDate,SysTime,CompId,FinYearId,SessionId,BGGroup,BudgetCodeId,Hour) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + HField.Text + "','" + id + "','" + Hour + "')");
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            this.FillGrid();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel ex = new ExportToExcel();
            ex.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_BG");
        }
        catch (Exception ex1)
        {
            string mystring = string.Empty;
            mystring = "No Records to Export.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
        } 

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            lblBGGroup.Text = ((Label)row.FindControl("lblDesc")).Text;
            HField.Text = ((Label)row.FindControl("lblId")).Text;
            ViewState["BGSymbol"] = ((Label)row.FindControl("lblSymbol")).Text;
            this.FillGrid();
            btnCancel1.Visible = false;
        }
    }
}

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

public partial class Module_Accounts_Transactions_Budget_WONo_Time : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();
    PO_Budget_Amt PBM = new PO_Budget_Amt();
    Cal_Used_Hours CUH = new Cal_Used_Hours();
    string connStr = string.Empty;
    SqlConnection con;
    int CompId = 0;
    int FinYearId = 0;
    string CDate = string.Empty;
    string CTime = string.Empty;
    string wono = string.Empty;
    string sId = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        CDate = fun.getCurrDate();
        CTime = fun.getCurrTime();
        wono = Request.QueryString["WONo"].ToString();
        sId = Session["username"].ToString();
        
        try
        {
            lblWoNo.Text = wono;

            if (!IsPostBack)
            {
                this.FillEquDrp(wono, CompId.ToString());
                this.CalculateBalAmt();
            }

            foreach (GridViewRow grv in GridView1.Rows)
            {
                ((HyperLink)grv.FindControl("HyperLink1")).NavigateUrl = "~/Module/MIS/Transactions/Budget_WONo_Details_Time.aspx?WONo=" + wono + "&AllocHrs=" + ((Label)grv.FindControl("lblHour")).Text + "&UtilHrs=" + ((Label)grv.FindControl("LblUsedHour")).Text + "&BalHrs=" + ((Label)grv.FindControl("LblBalHour")).Text + "&Eqid=" + ((Label)grv.FindControl("lblEquipId")).Text + "&Cat=" + ((Label)grv.FindControl("lblCatId")).Text + "&SubCat=" + ((Label)grv.FindControl("lblSubCatId")).Text + "&ModId=14";
            }           
        }
        catch (Exception ex)
        {

        }
    }
    
    public void CalculateBalAmt()
    {
        try
        {
            con.Open();

            DataTable DT = new DataTable();
            DT.Columns.Add(new System.Data.DataColumn("Equipment No", typeof(string)));//0
            DT.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));//1
            DT.Columns.Add(new System.Data.DataColumn("Category", typeof(string)));//2
            DT.Columns.Add(new System.Data.DataColumn("Sub Category", typeof(string)));//3
            DT.Columns.Add(new System.Data.DataColumn("Budget Hrs", typeof(double)));//4
            DT.Columns.Add(new System.Data.DataColumn("Utilized Hrs", typeof(double)));//5
            DT.Columns.Add(new System.Data.DataColumn("Bal Hrs", typeof(double)));//6
            DT.Columns.Add(new System.Data.DataColumn("EquipId", typeof(string)));//7
            DT.Columns.Add(new System.Data.DataColumn("CatId", typeof(string)));//8
            DT.Columns.Add(new System.Data.DataColumn("SubCatId", typeof(string)));//9
            DT.Columns.Add(new System.Data.DataColumn("Finish", typeof(double)));//10

            DataRow dr;

            string selHrsBudget = fun.select("Distinct EquipId,HrsBudgetCat,HrsBudgetSubCat", "tblACC_Budget_WO_Time", "WONo='" + wono + "'");
                   
            SqlCommand cmdselHrsBudget = new SqlCommand(selHrsBudget, con);
            SqlDataReader DSselHrsBudget = cmdselHrsBudget.ExecuteReader();

            while (DSselHrsBudget.Read())
            {
                dr = DT.NewRow();

                string selHrsBudget2 = "SELECT tblMIS_BudgetHrs_Field_SubCategory.Id as scid,tblMIS_BudgetHrs_Field_SubCategory.SubCategory, tblMIS_BudgetHrs_Field_Category.Category,tblMIS_BudgetHrs_Field_Category.Id as cid, tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc FROM tblMIS_BudgetHrs_Field_Category INNER JOIN tblMIS_BudgetHrs_Field_SubCategory ON tblMIS_BudgetHrs_Field_Category.Id = tblMIS_BudgetHrs_Field_SubCategory.MId INNER JOIN  tblACC_Budget_WO_Time ON tblMIS_BudgetHrs_Field_SubCategory.Id = tblACC_Budget_WO_Time.HrsBudgetSubCat AND tblMIS_BudgetHrs_Field_Category.Id = tblACC_Budget_WO_Time.HrsBudgetCat INNER JOIN tblDG_Item_Master ON tblACC_Budget_WO_Time.EquipId = tblDG_Item_Master.Id AND tblACC_Budget_WO_Time.WONo='" + wono + "' AND tblACC_Budget_WO_Time.HrsBudgetCat='" + DSselHrsBudget["HrsBudgetCat"] + "' AND tblACC_Budget_WO_Time.HrsBudgetSubCat='" + DSselHrsBudget["HrsBudgetSubCat"] + "' AND tblACC_Budget_WO_Time.EquipId='" + DSselHrsBudget["EquipId"] + "'";

                SqlCommand cmdselHrsBudget2 = new SqlCommand(selHrsBudget2, con);
                SqlDataReader DSselHrsBudget2 = cmdselHrsBudget2.ExecuteReader();
                DSselHrsBudget2.Read();

                dr[0] = DSselHrsBudget2["ItemCode"];
                dr[1] = DSselHrsBudget2["ManfDesc"];
                dr[2] = DSselHrsBudget2["Category"];
                dr[3] = DSselHrsBudget2["SubCategory"];
             
                double AllocatedHrs = 0;
                double UtilizedHrs = 0;
                double BalHrs = 0;

                AllocatedHrs = Math.Round(Convert.ToDouble(CUH.AllocatedHrs_WONo(CompId, wono, Convert.ToInt32(DSselHrsBudget["EquipId"]), Convert.ToInt32(DSselHrsBudget2["Cid"]), Convert.ToInt32(DSselHrsBudget2["SCid"]))), 2);

                UtilizedHrs = Math.Round(Convert.ToDouble(CUH.UtilizeHrs_WONo(CompId, wono, Convert.ToInt32(DSselHrsBudget["EquipId"]), Convert.ToInt32(DSselHrsBudget2["Cid"]), Convert.ToInt32(DSselHrsBudget2["SCid"]))), 2);
                                
                BalHrs = Math.Round((AllocatedHrs - UtilizedHrs), 2);
                
                dr[4] = AllocatedHrs.ToString();
                dr[5] = UtilizedHrs.ToString();
                dr[6] = BalHrs.ToString();

                dr[7] = DSselHrsBudget["EquipId"];
                dr[8] = DSselHrsBudget["HrsBudgetCat"];
                dr[9] = DSselHrsBudget["HrsBudgetSubCat"];
                dr[10] = Math.Round(((UtilizedHrs*100)/AllocatedHrs),2);
                
                DT.Rows.Add(dr);
                DT.AcceptChanges();
            }

            GridView1.DataSource = DT;
            GridView1.DataBind();
                                   
            //    double openingBalOfPrevYear = 0;
            //    openingBalOfPrevYear = calbalbud.TotBalBudget_WONO(accid, CompId, prevYear, wono, 0);       
            
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
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
        Response.Redirect("Budget_Dist_WONo_Time.aspx?ModId=14");
    }

    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                { 
                    double Hrs = 0;
                    Hrs = Convert.ToDouble(((TextBox)grv.FindControl("TxtHour")).Text);

                    if (Hrs > 0)
                    {
                        string insert = fun.insert("tblACC_Budget_WO_Time", "SysDate,SysTime,CompId,FinYearId,SessionId,WONo,EquipId,HrsBudgetCat,HrsBudgetSubCat,Hour", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + ((Label)grv.FindControl("lblEquipId")).Text + "','" + ((Label)grv.FindControl("lblCatId")).Text + "','" + ((Label)grv.FindControl("lblSubCatId")).Text + "','" + Hrs + "'");                    
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
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
            ex.ExportDataToExcel((DataTable)ViewState["dtList"], "Budget_WONO");
        }
        catch (Exception ex1)
        {
            string mystring = string.Empty;
            mystring = "No Records to Export.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
        }

    }
    
    protected void drpCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpCat.SelectedValue != "1")
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter("HrsBudgetSubCategory", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add(new SqlParameter("@CatId", SqlDbType.Int));
                da.SelectCommand.Parameters["@CatId"].Value = drpCat.SelectedValue;

                DataSet DSitem = new DataSet();
                da.Fill(DSitem);

                drpSubCat.DataSource = DSitem;
                drpSubCat.DataTextField = "SubCategory";
                drpSubCat.DataValueField = "Id";
                drpSubCat.DataBind();
            }
            else
            {
                drpSubCat.Items.Clear();
            }
        }
        catch (Exception ex1)
        {

        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            string selHrsBudgetCK = fun.select("*","tblACC_Budget_WO_Time","EquipId='" + drpEqNo.SelectedValue + "' AND WONo='" + wono + "' AND HrsBudgetCat='" + drpCat.SelectedValue + "' AND HrsBudgetSubCat='" + drpSubCat.SelectedValue + "'");            
            SqlCommand cmdselHrsBudgetCK = new SqlCommand(selHrsBudgetCK, con);
            SqlDataReader DSselHrsBudgetCK = cmdselHrsBudgetCK.ExecuteReader();
            DSselHrsBudgetCK.Read();
            
            if (DSselHrsBudgetCK.HasRows==false)
            {
                string insert = ("Insert into tblACC_Budget_WO_Time (SysDate,SysTime,CompId,FinYearId,SessionId,WONo,EquipId,HrsBudgetCat,HrsBudgetSubCat,Hour) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + wono + "','" + Convert.ToInt32(drpEqNo.SelectedValue) + "','" + Convert.ToInt32(drpCat.SelectedValue) + "','" + Convert.ToInt32(drpSubCat.SelectedValue) + "','" + Convert.ToDouble(txtHrs.Text) + "')");               
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Budget Hrs is already allocated for selected Category & Sub-Category.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }

    protected void drpEqNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpEqNo.SelectedValue != "Select")
        {
            this.FillCatDrp();
        }
        else
        {
            drpCat.Items.Clear();
        }
    }

    public void FillCatDrp()
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("HrsBudgetCategory", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet DS1 = new DataSet();
            adapter.Fill(DS1);

            drpCat.DataSource = DS1;
            drpCat.DataTextField = "Category";
            drpCat.DataValueField = "Id";
            drpCat.DataBind();
        }
        catch (Exception ex1)
        {

        }
    }

    public void FillEquDrp(string wonosrc, string CompId)
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("HrsBudgetBOMEquipment", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@CompId"].Value = CompId;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
            adapter.SelectCommand.Parameters["@WONo"].Value = wonosrc;

            DataSet DS = new DataSet();
            adapter.Fill(DS);

            drpEqNo.DataSource = DS;
            drpEqNo.DataTextField = "EqDesc";
            drpEqNo.DataValueField = "ItemId";
            drpEqNo.DataBind();
            drpEqNo.Items.Insert(0, "Select");
        }
        catch (Exception ex1)
        {

        }
    }


}
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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class Module_Inventory_Reports_WorkOrder_Shortage_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    private ReportDocument report = new ReportDocument();
    DataTable DT = new DataTable();    
    public string WONo = "";
    int CompId = 0;
    int FinYearId = 0;
    string Key = string.Empty;
    protected void Page_Init(object sender, EventArgs e)
    {
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);
        WONo = Request.QueryString["wono"].ToString();
        Key = Request.QueryString["Key"].ToString();
        DataSet DS9 = new DataSet();
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        if (!IsPostBack)
        {

            try
            {

                if (Request.QueryString["wono"] != "")
                {
                    
                    string sql = "select Distinct tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode from tblDG_BOM_Master,tblDG_Item_Master,Unit_Master where Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId  And tblDG_BOM_Master.WONo='"+WONo+"' And tblDG_BOM_Master.CompId='"+CompId+"'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(DS9, "tblDG_BOM_Master");
                    DT.Columns.Add("ItemCode", typeof(string));
                    DT.Columns.Add("ManfDesc", typeof(string));
                    DT.Columns.Add("UOM", typeof(string));
                    DT.Columns.Add("Qty", typeof(double));
                    DT.Columns.Add("WONo", typeof(string));
                    DT.Columns.Add("CompId", typeof(int));
                    DT.Columns.Add("IssueQty", typeof(double));
                    DT.Columns.Add("Rate", typeof(double));
                    DataRow dr;   
                    for (int i = 0; i < DS9.Tables[0].Rows.Count; i++)
                    {
                        dr = DT.NewRow();
                        dr[0] = DS9.Tables[0].Rows[i]["ItemCode"].ToString();
                        dr[1] = DS9.Tables[0].Rows[i]["ManfDesc"].ToString();
                        dr[2] = DS9.Tables[0].Rows[i]["UOMBasic"].ToString();
                        double liQty = fun.AllComponentBOMQty(CompId, WONo, DS9.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId);
                        dr[3] = liQty;
                        dr[4] = WONo;
                        dr[5] = CompId;
                        double ShortQty = 0;
                        ShortQty= Math.Round((liQty-fun.CalWISQty(CompId.ToString(), WONo, DS9.Tables[0].Rows[i]["ItemId"].ToString())),5);
                        dr[6] = ShortQty;
                        double Rate = 0;
                        string SqlStr = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", "CompId='" + CompId + "'And ItemId='" + DS9.Tables[0].Rows[i]["ItemId"] + "'");
                        SqlCommand CmdRateReg = new SqlCommand(SqlStr, con);
                        SqlDataAdapter DA = new SqlDataAdapter(CmdRateReg);
                        DataSet DSRate = new DataSet();
                        DA.Fill(DSRate);
                        if (DSRate.Tables[0].Rows.Count > 0 && DSRate.Tables[0].Rows[0]["rate"] != DBNull.Value)
                        {
                            Rate = Convert.ToDouble(DSRate.Tables[0].Rows[0]["rate"]);
                        }
                        dr[7] = Rate;
                        if (ShortQty>0)
                        {
                        DT.Rows.Add(dr);
                        DT.AcceptChanges();
                        }
                       
                    } 
                    string Company = fun.getCompany(CompId);                   
                    string Address = fun.CompAdd(CompId);                 
                    string Title = fun.getProjectTitle(WONo);
                    string reportPath = Server.MapPath("~/Module/Inventory/Reports/WorkOrder_Shortage.rpt");
                    report.Load(reportPath);
                    report.SetDataSource(DT);
                    report.SetParameterValue("Company", Company);
                    report.SetParameterValue("Address", Address);
                    report.SetParameterValue("Title", Title);
                    CrystalReportViewer1.ReportSource = report;                    
                    Session[Key] = report;

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DS9.Clear();
                DS9.Dispose();
                DT.Clear();
                DT.Dispose();
                con.Close();
                con.Dispose();
            }
            
        }

        else
        {
            ReportDocument doc = (ReportDocument)Session[Key];
            CrystalReportViewer1.ReportSource = doc;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        report = new ReportDocument();    
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        report.Close();
        report.Dispose();
        GC.Collect();
    }   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkOrder_Issue.aspx");
    }
}

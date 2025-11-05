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
using System.Security.Cryptography;
using System.Collections.Generic;
public partial class Module_Inventory_Reports_WorkOrder_Issue_Details : System.Web.UI.Page
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
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();    
        if (!IsPostBack)
        {
                    
           try
            {
                CompId = Convert.ToInt32(Session["compid"]);
                FinYearId = Convert.ToInt32(Session["finyear"]);
                Key = Request.QueryString["Key"].ToString();
                if (Request.QueryString["wono"] != "")
                {
                    WONo = Request.QueryString["wono"].ToString();                                      
                    DT.Columns.Add("ItemCode", typeof(string));
                    DT.Columns.Add("ManfDesc", typeof(string));
                    DT.Columns.Add("UOM", typeof(string));
                    DT.Columns.Add("Qty", typeof(double));
                    DT.Columns.Add("WONo", typeof(string));
                    DT.Columns.Add("CompId", typeof(int));
                    DT.Columns.Add("IssueQty", typeof(double));
                    DT.Columns.Add("Rate", typeof(double));
                    DataRow dr;                  
                    SqlCommand cmd = new SqlCommand("WIS_WONo_Wise", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompId", CompId);
                    cmd.Parameters.AddWithValue("@WONo", WONo);                   
                    SqlDataReader rdr = cmd.ExecuteReader();                   
                    while (rdr.Read())
                    {

                       
                        dr = DT.NewRow();
                        dr[0] = rdr["ItemCode"].ToString();
                        dr[1] = rdr["ManfDesc"].ToString();
                        dr[2] = rdr["UOMBasic"].ToString();
                        double liQty = fun.AllComponentBOMQty(CompId, WONo, rdr["ItemId"].ToString(), FinYearId);
                        dr[3] = liQty;
                        dr[4] = WONo;
                        dr[5] = CompId;
                        dr[6] = fun.CalWISQty(CompId.ToString(), WONo, rdr["ItemId"].ToString());
                        double Rate = 0;                       
                        string SqlStr = fun.select("max(Rate-(Rate*(Discount/100))) As rate", "tblMM_Rate_Register", "CompId='" + CompId + "'And ItemId='" + rdr["ItemId"] + "'");
                        SqlCommand CmdRateReg = new SqlCommand(SqlStr, con);
                        SqlDataAdapter DA = new SqlDataAdapter(CmdRateReg);
                        DataSet DSRate = new DataSet();
                        DA.Fill(DSRate);                        
                        if (DSRate.Tables[0].Rows.Count > 0 && DSRate.Tables[0].Rows[0]["rate"] != DBNull.Value)
                        {
                            Rate = Convert.ToDouble(DSRate.Tables[0].Rows[0]["rate"]);
                        }                                               
                        dr[7] = Rate;
                        DT.Rows.Add(dr);
                        DT.AcceptChanges();
                    }
                    rdr.Close();
                    string Company = fun.getCompany(CompId);                   
                    string Address = fun.CompAdd(CompId);                  
                    string Title = fun.getProjectTitle(WONo);
                    string reportPath = Server.MapPath("~/Module/Inventory/Reports/WorkOrder_Issue.rpt");
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
                DT.Clear();
                DT.Dispose();                
                con.Close();
                con.Dispose();
            }
            
        }

        else
        {
            Key = Request.QueryString["Key"].ToString();
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

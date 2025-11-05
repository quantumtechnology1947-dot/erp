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

public partial class Module_ProjectManagement_Transactions_GatePass_Report : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    ReportDocument cryRpt = new ReportDocument();
    string Id = "";
   
protected void Page_Init(object sender, EventArgs e)
  
{
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            Id = Convert.ToString("Id");
            Id = Request.QueryString["Key"].ToString();
    
            if (!IsPostBack)
            
            {
                con.Open();
                DataTable dt = new DataTable();
                string StrAsset = fun.select("*", "Returnable_GatePass","Id='" +Id + "'");
                SqlCommand cmdAsset = new SqlCommand(StrAsset, con);
                SqlDataAdapter DAAsset = new SqlDataAdapter(cmdAsset);
                DataSet DSAsset = new DataSet();
                DAAsset.Fill(DSAsset);
                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("ChalanNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("WoNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Des_Name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CodeNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Unit", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Total_qty", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("IssueTo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("AthoriseBy", typeof(int)));
           
                DataRow dr;
                 DataSet AssetRegister = new DataSet();
   
                for (int i = 0; i < DSAsset.Tables[0].Rows.Count; i++)
                
                {
                    dr = dt.NewRow();
                    dr[0] = Convert.ToInt32(DSAsset.Tables[0].Rows[i]["Id"].ToString());
                    dr[1] = DSAsset.Tables[0].Rows[i]["ChalanNo"].ToString();
                    dr[2] = DSAsset.Tables[0].Rows[i]["Date"].ToString();
                    dr[3] = DSAsset.Tables[0].Rows[i]["WoNo"].ToString();
                    dr[4] = DSAsset.Tables[0].Rows[i]["Des_Name"].ToString();
                    dr[5] = DSAsset.Tables[0].Rows[i]["CodeNo"].ToString();
                    dr[6] = DSAsset.Tables[0].Rows[i]["Description"].ToString();
                    dr[7] = DSAsset.Tables[0].Rows[i]["Unit"].ToString();
                    dr[8] = DSAsset.Tables[0].Rows[i]["Qty"].ToString();
                    dr[9] = Convert.ToInt32(DSAsset.Tables[0].Rows[i]["Total_qty"].ToString());
                    dr[10] = DSAsset.Tables[0].Rows[i]["IssueTo"].ToString();
                    dr[11] = DSAsset.Tables[0].Rows[i]["AthoriseBy"].ToString();
                   //TextBox1.Text = "Test";
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
              
                }

                AssetRegister.Tables.Add(dt);
                DataSet xsdds = new AssetRegister();
                xsdds.Tables[0].Merge(AssetRegister.Tables[0]);
                xsdds.AcceptChanges();
                cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/Module/Inventory/Transactions/Reports/ReturnablePass.rpt"));
                cryRpt.SetDataSource(xsdds);
           }
            
            else
           
           {
                ReportDocument doc = (ReportDocument)Session[Id];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
      
        catch (Exception ex)
        { }
        finally
       
        {
            con.Close();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    
    {
        cryRpt = new ReportDocument();
    }

    protected void Page_UnLoad(object sender, EventArgs e)
   
    {
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        cryRpt.Close();
        cryRpt.Dispose();
        GC.Collect();
    }

    protected void cancel(object sender, EventArgs e)
    
    {
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_CrystalReport.aspx");
     }

}
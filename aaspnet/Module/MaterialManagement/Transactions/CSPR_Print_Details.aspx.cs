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

public partial class Module_MaterialManagement_Transactions_SPR_Print_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    private ReportDocument report = new ReportDocument();
    string f = "";
    string MId = "";
    int cId = 0;
    int FyId = 0;
    string Key = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string connStr1 = fun.Connection();
            SqlConnection myConnection = new SqlConnection(connStr1);
            myConnection.Open();

            DataSet xsd = new SPRPrint();
            DataTable dt = new DataTable();

            try
            {
                cId = Convert.ToInt32(Session["compid"]);
                FyId = Convert.ToInt32(Session["finyear"]);
                MId = Request.QueryString["Id"];
                Key = Request.QueryString["Key"].ToString();


                string str = Request.QueryString["SPRNo"].ToString();

                string selectQuery = fun.select("tblMM_SPR_Details.SupplierId,tblMM_SPR_Details.Discount,tblDG_Item_Master.Id,tblMM_SPR_Details.DeptId,tblDG_Item_Master.ItemCode,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As Uom,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.Qty,tblMM_SPR_Details.Rate,tblMM_Supplier_master.SupplierName,tblMM_SPR_Details.WONo,tblMM_SPR_Master.SysDate,tblMM_SPR_Master.CheckedBy,tblMM_SPR_Master.ApprovedBy,tblMM_SPR_Master.AuthorizedBy,tblMM_SPR_Master.CheckedDate,tblMM_SPR_Master.ApproveDate,tblMM_SPR_Master.AuthorizeDate,tblMM_SPR_Master.SPRNo,AccHead.Symbol As AcHead,tblMM_SPR_Details.Remarks", " tblMM_SPR_Master,tblHR_OfficeStaff,tblMM_SPR_Details,AccHead,tblCompany_master,tblDG_Item_Master,tblMM_Supplier_master,Unit_Master", "tblMM_SPR_Master.SPRNo='" + str + "'And tblMM_SPR_Master.CompId='" + cId + "' And tblDG_Item_Master.Id=tblMM_SPR_Details.ItemId And tblDG_Item_Master.UOMBasic=Unit_Master.Id And tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Details.SupplierId=tblMM_Supplier_master.SupplierId And tblMM_SPR_Details.AHId=AccHead.Id And tblMM_SPR_Master.CompId=tblCompany_master.CompId And tblMM_SPR_Master.SessionId=tblHR_OfficeStaff.EmpId AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.MId='" + MId + "' AND tblMM_SPR_Master.FinYearId<='" + FyId + "' ");
                
                SqlCommand myCommand = new SqlCommand(selectQuery, myConnection);
                SqlDataAdapter ad1 = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                ad1.Fill(ds);
                dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("PurchDesc", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("UomPurch", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DelDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("SPRQTY", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("Rate", typeof(double)));
                dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DeptName", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("AcHead", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Intender", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Discount", typeof(double)));
                DataRow dr;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = fun.GetItemCode_PartNo(cId, Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()));
                    dr[1] = ds.Tables[0].Rows[i]["ManfDesc"].ToString();
                    dr[2] = ds.Tables[0].Rows[i]["Uom"].ToString();
                    dr[3] = fun.FromDateDMY(ds.Tables[0].Rows[i]["DelDate"].ToString());
                    dr[4] = Convert.ToDouble(decimal.Parse((ds.Tables[0].Rows[i]["Qty"].ToString())).ToString("N3"));
                    dr[5] = Convert.ToDouble(decimal.Parse((ds.Tables[0].Rows[i]["Rate"].ToString())).ToString("N2"));

                    if (ds.Tables[0].Rows[i]["WONo"].ToString() != "" && Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]) == 0)
                    {
                        dr[6] = "WONo - " + ds.Tables[0].Rows[i]["WONo"].ToString();
                    }
                    else
                    {
                        string sql99 = fun.select("Symbol As Dept", "BusinessGroup", "Id='" + ds.Tables[0].Rows[i]["DeptId"].ToString() + "'");

                        SqlCommand myCommand99 = new SqlCommand(sql99, myConnection);
                        SqlDataAdapter ad99 = new SqlDataAdapter(myCommand99);
                        DataSet ds99 = new DataSet();
                        ad99.Fill(ds99, "BusinessGroup");

                        dr[6] = "BG Group - " + ds99.Tables[0].Rows[0]["Dept"].ToString();
                        dr[8] = ds99.Tables[0].Rows[0]["Dept"].ToString();
                    }

                    dr[7] = ds.Tables[0].Rows[i]["SupplierName"].ToString() + " [ " + ds.Tables[0].Rows[i]["SupplierId"].ToString() + " ]";
                    dr[9] = ds.Tables[0].Rows[i]["AcHead"].ToString();
                    dr[10] = ds.Tables[0].Rows[i]["Remarks"].ToString();
                    dr[11] = cId;
                    dr[12] = ds.Tables[0].Rows[i]["Title"].ToString() + "." + ds.Tables[0].Rows[i]["EmployeeName"].ToString(); dr[13] = Convert.ToDouble(ds.Tables[0].Rows[i]["Discount"]);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }


                xsd.Tables[0].Merge(dt);
                string reportPath = Server.MapPath("~/Module/MaterialManagement/Transactions/Reports/SPR.rpt");
                report.Load(reportPath);
                report.SetDataSource(xsd);
                string CheckedDate = "";
                string CheckedBy = "";
                string ApprovedBy = "";
                string AuthorizedBy = "";
                string ApproveDate = "";
                string AuthorizeDate = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Registration Date 
                    string regdate = ds.Tables[0].Rows[0]["SysDate"].ToString();
                    string RegDate = fun.FromDate(regdate);
                    report.SetParameterValue("RegDate", RegDate);
                    string CheckBy = ds.Tables[0].Rows[0]["CheckedBy"].ToString();
                    string AppBy = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
                    string AuthBy = ds.Tables[0].Rows[0]["AuthorizedBy"].ToString();

                    // For Checked By Emp Name........

                    if (ds.Tables[0].Rows[0]["CheckedBy"] != DBNull.Value)
                    {
                        string StrCheckedBy = fun.select(" Title,EmployeeName ", " tblHR_OfficeStaff ", " EmpId='" + CheckBy + "'And CompId='" + cId + "'");
                        SqlCommand CmdCheckedBy = new SqlCommand(StrCheckedBy, myConnection);
                        SqlDataAdapter DACKBy = new SqlDataAdapter(CmdCheckedBy);
                        DataSet DSCKBy = new DataSet();
                        DACKBy.Fill(DSCKBy, "tblHR_OfficeStaff");
                        CheckedBy = DSCKBy.Tables[0].Rows[0]["Title"].ToString() + ". " + DSCKBy.Tables[0].Rows[0]["EmployeeName"].ToString();
                    }
                    else
                    {
                        CheckedBy = " ";
                    }

                    // For Approved By Emp Name........

                    if (ds.Tables[0].Rows[0]["ApprovedBy"] != DBNull.Value)
                    {
                        string StrAppBy = fun.select("Title,EmployeeName", "tblHR_OfficeStaff ", "  EmpId='" + AppBy + "'And CompId='" + cId + "'");
                        SqlCommand CmdAppBy = new SqlCommand(StrAppBy, myConnection);
                        SqlDataAdapter DAAppBy = new SqlDataAdapter(CmdAppBy);
                        DataSet DSAppBy = new DataSet();
                        DAAppBy.Fill(DSAppBy, "tblHR_OfficeStaff");
                        ApprovedBy = DSAppBy.Tables[0].Rows[0]["Title"].ToString() + ". " + DSAppBy.Tables[0].Rows[0]["EmployeeName"].ToString();
                    }
                    else
                    {
                        ApprovedBy = " ";
                    }

                    // For Authorized By Emp Name........                  

                    if (ds.Tables[0].Rows[0]["AuthorizedBy"] != DBNull.Value)
                    {
                        string StrAuthBy = fun.select("Title,EmployeeName ", "tblHR_OfficeStaff", "EmpId='" + AuthBy + "'And CompId='" + cId + "'");
                        SqlCommand CmdAuthBy = new SqlCommand(StrAuthBy, myConnection);
                        SqlDataAdapter DAAuthBy = new SqlDataAdapter(CmdAuthBy);
                        DataSet DSAuthBy = new DataSet();
                        DAAuthBy.Fill(DSAuthBy, "tblHR_OfficeStaff");
                        AuthorizedBy = DSAuthBy.Tables[0].Rows[0]["Title"].ToString() + ". " + DSAuthBy.Tables[0].Rows[0]["EmployeeName"].ToString();
                    }
                    else
                    {
                        AuthorizedBy = " ";
                    }

                    report.SetParameterValue("CheckedBy", CheckedBy);
                    report.SetParameterValue("ApprovedBy", ApprovedBy);
                    report.SetParameterValue("AuthorizedBy", AuthorizedBy);

                    // For Checked Date........

                    if (ds.Tables[0].Rows[0]["CheckedDate"] != DBNull.Value)
                    {
                        string checkeddate = ds.Tables[0].Rows[0]["CheckedDate"].ToString();
                        CheckedDate = fun.FromDate(checkeddate);
                    }
                    else
                    {
                        CheckedDate = "";
                    }

                    // For Approve Date........

                    if (ds.Tables[0].Rows[0]["ApproveDate"] != DBNull.Value)
                    {
                        string approvedate = ds.Tables[0].Rows[0]["ApproveDate"].ToString();
                        ApproveDate = fun.FromDate(approvedate);
                    }
                    else
                    {
                        ApproveDate = "";
                    }

                    // For Authorize Date........

                    if (ds.Tables[0].Rows[0]["AuthorizeDate"] != DBNull.Value)
                    {
                        string authorizedate = ds.Tables[0].Rows[0]["AuthorizeDate"].ToString();
                        AuthorizeDate = fun.FromDate(authorizedate);
                    }
                    else
                    {
                        AuthorizeDate = "";
                    }
                }


                report.SetParameterValue("SPRNO", str);
                report.SetParameterValue("CheckedDate", CheckedDate);
                report.SetParameterValue("ApproveDate", ApproveDate);
                report.SetParameterValue("AuthorizeDate", AuthorizeDate);
                string Company = fun.getCompany(cId);
                report.SetParameterValue("Company", Company);
                string Address = fun.CompAdd(cId);
                report.SetParameterValue("Address", Address);
                // to load crystal report on page.        
                CrystalReportViewer1.ReportSource = report;
                Session[Key] = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {               
                myConnection.Close();
                myConnection.Dispose();

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
        f = Request.QueryString["f"].ToString();

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        string url="";
        switch (f)
        {
            case "1":
                url = "SPR_Dashboard.aspx?ModId=6&SubModId=31";
                break;
            case "2":
                url = "SPR_Print.aspx?ModId=6&SubModId=31";
                break;
        }

        Response.Redirect(url);

    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        report.Close();
        report.Dispose();
        GC.Collect();
    }
}

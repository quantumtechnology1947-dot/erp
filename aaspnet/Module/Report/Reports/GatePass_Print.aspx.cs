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

public partial class Module_Scheduler_GatePass_Print : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    int CompId = 0;
   // int FinYearId = 0;
    string SId = "";
    string Id = "";
    string DId = "";
    private ReportDocument report = new ReportDocument();

    string Key = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        DataSet MainDS = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            Id = (Request.QueryString["Id"].ToString());
            Key = Request.QueryString["Key"].ToString();

            if (!IsPostBack)
            {
                string sqlInv = fun.select("tblCV_Pass.SessionId,tblCV_Pass.CompId,tblCV_Pass.SysDate,tblCV_Pass.Authorize,tblCV_Pass.EmpId As SelfEId,tblCV_Pass.Id,tblCV_Pass.FinYearId,tblCV_Pass.GPNo,tblCV_Pass.Authorize,tblCV_Pass.AuthorizedBy,tblCV_Pass.AuthorizeDate,tblCV_Pass.AuthorizeTime,tblCV_Details.FromDate,tblCV_Details.Adharcard,tblCV_Details.FromTime,tblCV_Details.ToTime,tblCV_Details.Type,tblCV_Details.TypeFor,tblCV_Details.Reason,tblCV_Details.PAN,tblCV_Details.Id As DId,tblCV_Details.EmpId As OtherEId,tblCV_Details.Place,tblCV_Details.ContactPerson,tblCV_Details.ContactNo", "tblCV_Pass,tblCV_Details", "tblCV_Pass.Id=tblCV_Details.MId And tblCV_Pass.SessionId='" + SId + "' And tblCV_Details.Feedback is null AND  tblCV_Pass.CompId='" + CompId + "' And  tblCV_Pass.Id='" + Id + "'  ");

                SqlCommand cmdInv = new SqlCommand(sqlInv, con);
                SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
                DataSet DSInv = new DataSet();
                DAInv.Fill(DSInv);


                dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("GPNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("FromDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("FromTime", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ToTime", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Type", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("TypeFor", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Reason", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("AuthorizedBy", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("AuthorizeDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("AuthorizeTime", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Feedback", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("DId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("SelfEId", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Authorize", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Place", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ContactPerson", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("ContactNo", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Empother", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("ToDate", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("EmpType", typeof(string)));

                if (DSInv.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;

                    for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                    {

                        dr = dt.NewRow();
                        string AuthBy = "";
                        string AuthDate = "";
                        string AuthTime = "";

                        {

                            string sqlFin = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + DSInv.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                            SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                            SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                            DataSet DSFin = new DataSet();
                            daFin.Fill(DSFin);
                            dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                            dr[1] = fun.FromDateDMY(DSInv.Tables[0].Rows[i]["SysDate"].ToString());
                            dr[2] = DSInv.Tables[0].Rows[i]["GPNo"].ToString();
                            dr[3] = fun.FromDate(DSInv.Tables[0].Rows[i]["FromDate"].ToString());
                            dr[4] = DSInv.Tables[0].Rows[i]["FromTime"].ToString();
                            dr[5] = DSInv.Tables[0].Rows[i]["ToTime"].ToString();
                            dr[7] = DSInv.Tables[0].Rows[i]["TypeFor"].ToString();

                            dr[8] = (DSInv.Tables[0].Rows[i]["Reason"].ToString());

                            string sql1 = fun.select("*", "tblCV_Reason", "Id='" + DSInv.Tables[0].Rows[i]["Type"].ToString() + "'");
                            SqlCommand cmd1 = new SqlCommand(sql1, con);
                            SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                            DataSet DS1 = new DataSet();
                            DA1.Fill(DS1);

                            dr[6] = (DS1.Tables[0].Rows[0]["Reason"].ToString());

                            if (Convert.ToInt32(DSInv.Tables[0].Rows[i]["Authorize"]) == 1)
                            {
                                string StrEmp = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["AuthorizedBy"].ToString() + "'And CompId='" + CompId + "'");
                                SqlCommand CmdEmp = new SqlCommand(StrEmp, con);
                                SqlDataAdapter DAEmp = new SqlDataAdapter(CmdEmp);
                                DataSet DSEmp = new DataSet();
                                DAEmp.Fill(DSEmp);


                                AuthBy = DSEmp.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                                AuthDate = fun.FromDateDMY(DSInv.Tables[0].Rows[i]["AuthorizeDate"].ToString());
                                AuthTime = DSInv.Tables[0].Rows[i]["AuthorizeTime"].ToString();

                            }

                            dr[9] = AuthBy;
                            dr[10] = AuthDate;
                            dr[11] = AuthTime;

                            string feed = "";
                            
                            if(DSInv.Tables[0].Rows[i]["PAN"] != DBNull.Value)
                            {
                                feed = DSInv.Tables[0].Rows[i]["PAN"].ToString();
                            }
                            
                            dr[12] = DSInv.Tables[0].Rows[i]["PAN"].ToString();
                            dr[13] = DSInv.Tables[0].Rows[i]["DId"].ToString();

                            string EmpSelf = string.Empty;
                            string EMOther = string.Empty;
                            string EmpType = string.Empty;

                            if(DSInv.Tables[0].Rows[i]["SelfEId"] != DBNull.Value)
                            {
                                string StrEmpSelf = fun.select("Title,EmployeeName,EmpId,OfferId", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["SelfEId"].ToString() + "'And CompId='" + CompId + "'");
                                SqlCommand CmdEmpSelf = new SqlCommand(StrEmpSelf, con);
                                SqlDataAdapter DAEmpSelf = new SqlDataAdapter(CmdEmpSelf);
                                DataSet DSEmpSelf = new DataSet();
                                DAEmpSelf.Fill(DSEmpSelf);
                                
                                if (DSEmpSelf.Tables[0].Rows.Count > 0)
                                {
                                    EmpSelf = DSEmpSelf.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmpSelf.Tables[0].Rows[0]["EmployeeName"].ToString() + ",";
                                    string StrEmpType = fun.select("TypeOf", "tblHR_Offer_Master", "OfferId='" + DSEmpSelf.Tables[0].Rows[0]["OfferId"].ToString() + "'And CompId='" + CompId + "'");
                                    
                                    SqlCommand CmdEmpType = new SqlCommand(StrEmpType, con);
                                    SqlDataAdapter DAEmpType = new SqlDataAdapter(CmdEmpType);
                                    DataSet DSEmpType = new DataSet();
                                    DAEmpType.Fill(DSEmpType);

                                    if(DSEmpType.Tables[0].Rows[0]["TypeOf"].ToString()=="2")
                                    {
                                        EmpType = "[Neha Enterprises]";
                                    }
                                }
                            }
                            else
                            {
                                string StrOtherEId = fun.select("Title,EmployeeName,EmpId,OfferId", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["OtherEId"].ToString() + "'And CompId='" + CompId + "'");
                                SqlCommand CmdOtherEId = new SqlCommand(StrOtherEId, con);
                                SqlDataAdapter DAOtherEId = new SqlDataAdapter(CmdOtherEId);
                                DataSet DSOtherEId = new DataSet();
                                DAOtherEId.Fill(DSOtherEId);
                            
                                if(DSOtherEId.Tables[0].Rows.Count > 0)
                                {
                                    EMOther = DSOtherEId.Tables[0].Rows[0]["Title"].ToString() + ". " + DSOtherEId.Tables[0].Rows[0]["EmployeeName"].ToString() + ",";
                                    string StrEmpType = fun.select("TypeOf", "tblHR_Offer_Master", "OfferId='" + DSOtherEId.Tables[0].Rows[0]["OfferId"].ToString() + "'And CompId='" + CompId + "'");
                                    
                                    SqlCommand CmdEmpType = new SqlCommand(StrEmpType, con);
                                    SqlDataAdapter DAEmpType = new SqlDataAdapter(CmdEmpType);
                                    DataSet DSEmpType = new DataSet();
                                    DAEmpType.Fill(DSEmpType);
                                    
                                    if (DSEmpType.Tables[0].Rows[0]["TypeOf"].ToString() == "2")
                                    {
                                        EmpType = "[Neha Enterprises]";
                                    }
                                }
                            }

                            dr[14] = EmpSelf + EMOther;
                            dr[15] = DSInv.Tables[0].Rows[i]["Authorize"].ToString();
                            dr[16] = DSInv.Tables[0].Rows[i]["Place"].ToString();
                            dr[17] = DSInv.Tables[0].Rows[i]["ContactPerson"].ToString();
                            dr[18] = DSInv.Tables[0].Rows[i]["ContactNo"].ToString();

                            string StrEmp5 = fun.select("Title,EmployeeName,EmpId", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["Sessionid"].ToString() + "'And CompId='" + CompId + "'");
                            SqlCommand CmdEmp5 = new SqlCommand(StrEmp5, con);
                            SqlDataAdapter DAEmp5 = new SqlDataAdapter(CmdEmp5);
                            DataSet DSEmp5 = new DataSet();
                            DAEmp5.Fill(DSEmp5);
                            dr[19] = DSEmp5.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmp5.Tables[0].Rows[0]["EmployeeName"].ToString();
                            dr[20] = Convert.ToInt32(DSInv.Tables[0].Rows[i]["CompId"]);
                            dr[21] = DSInv.Tables[0].Rows[i]["Adharcard"].ToString();
                            dr[22] = EmpType;

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }
                }

                MainDS.Tables.Add(dt);

                DataSet xsdds = new GatePassPrint();
                xsdds.Tables[0].Merge(MainDS.Tables[0]);

                xsdds.AcceptChanges();

                string reportPath = Server.MapPath("~/Module/Report/Reports/CVCrystalReport.rpt");
                report.Load(reportPath);
                report.SetDataSource(xsdds);

                CrystalReportViewer1.ReportSource = report;
                Session[Key] = report;
            }

            else
            {
                Key = Request.QueryString["Key"].ToString();
                ReportDocument doc = (ReportDocument)Session[Key];
                CrystalReportViewer1.ReportSource = doc;
            }


        }
        catch (Exception ex)
        {
        }
        finally
        {
            MainDS.Clear();
            MainDS.Dispose();
            dt.Clear();
            dt.Dispose();
            con.Close();
            con.Dispose();

        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        report = new ReportDocument();
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Report/Reports/GatePass_New.aspx");
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

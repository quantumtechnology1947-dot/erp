using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;

public class Module_HR_Transactions_OfficeStaff_Print_Details : Page, IRequiresSessionState
{
	protected CrystalReportViewer CrystalReportViewer1;

	protected CrystalReportSource CrystalReportSource2;

	protected Panel Panel1;

	protected Button Cancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private ReportDocument report = new ReportDocument();

	private string Key = string.Empty;

	private string Pageback = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		//IL_191b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1922: Expected O, but got Unknown
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			try
			{
				fun.getCurrDate();
				fun.getCurrTime();
				string text = base.Request.QueryString["EmpId"];
				Key = base.Request.QueryString["Key"].ToString();
				Session["username"].ToString();
				int num = Convert.ToInt32(Session["compid"]);
				Convert.ToInt32(Session["finyear"]);
				dataTable.Columns.Add(new DataColumn("CompanyName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PhotoData", typeof(byte[])));
				dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CardNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Department", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BussinessGroup", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DeptDirector", typeof(string)));
				dataTable.Columns.Add(new DataColumn("DeptHead", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GroupLeader", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Grade", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("extNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("joindate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("birthdate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("resigndate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("martialstatus", typeof(string)));
				dataTable.Columns.Add(new DataColumn("physicalstatus", typeof(string)));
				dataTable.Columns.Add(new DataColumn("padd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("cadd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("email", typeof(string)));
				dataTable.Columns.Add(new DataColumn("gender", typeof(string)));
				dataTable.Columns.Add(new DataColumn("bgp", typeof(string)));
				dataTable.Columns.Add(new DataColumn("height", typeof(string)));
				dataTable.Columns.Add(new DataColumn("weight", typeof(string)));
				dataTable.Columns.Add(new DataColumn("religion", typeof(string)));
				dataTable.Columns.Add(new DataColumn("cast", typeof(string)));
				dataTable.Columns.Add(new DataColumn("edu", typeof(string)));
				dataTable.Columns.Add(new DataColumn("adq", typeof(string)));
				dataTable.Columns.Add(new DataColumn("lc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("wd", typeof(string)));
				dataTable.Columns.Add(new DataColumn("te", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ctc", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ba", typeof(string)));
				dataTable.Columns.Add(new DataColumn("pf", typeof(string)));
				dataTable.Columns.Add(new DataColumn("pa", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ps", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ex", typeof(string)));
				dataTable.Columns.Add(new DataColumn("inf", typeof(string)));
				dataTable.Columns.Add(new DataColumn("LogoImage", typeof(byte[])));
				string text2 = "";
				string value = "";
				string value2 = "";
				sqlConnection.Open();
				string cmdText = fun.select("tblHR_OfficeStaff.EmpId,tblHR_OfficeStaff.CompId,tblHR_OfficeStaff.PhotoData,tblHR_OfficeStaff.Title,tblHR_OfficeStaff.EmployeeName,tblHR_OfficeStaff.SwapCardNo,tblHR_OfficeStaff.PhotoFileName,tblHR_OfficeStaff.Department,tblHR_OfficeStaff.BGGroup,tblHR_OfficeStaff.Designation,tblHR_OfficeStaff.DeptHead,tblHR_OfficeStaff.GroupLeader,tblHR_OfficeStaff.DirectorsName,tblHR_OfficeStaff.Grade,tblHR_OfficeStaff.MobileNo,tblHR_OfficeStaff.ContactNo,tblHR_OfficeStaff.CompanyEmail,tblHR_OfficeStaff.EmailId1,tblHR_OfficeStaff.ExtensionNo,tblHR_OfficeStaff.JoiningDate,tblHR_OfficeStaff.ResignationDate,tblHR_OfficeStaff.PermanentAddress, tblHR_OfficeStaff.CorrespondenceAddress, tblHR_OfficeStaff.EmailId2, tblHR_OfficeStaff.DateOfBirth, tblHR_OfficeStaff.Gender, tblHR_OfficeStaff.MartialStatus, tblHR_OfficeStaff.BloodGroup, tblHR_OfficeStaff.PhysicallyHandycapped,tblHR_OfficeStaff.Height ,tblHR_OfficeStaff.Weight,tblHR_OfficeStaff.Religion, tblHR_OfficeStaff.Cast, tblHR_OfficeStaff.EducationalQualification, tblHR_OfficeStaff.AdditionalQualification, tblHR_OfficeStaff.LastCompanyName, tblHR_OfficeStaff.WorkingDuration, tblHR_OfficeStaff.TotalExperience, tblHR_OfficeStaff.CurrentCTC,tblHR_OfficeStaff.BankAccountNo, tblHR_OfficeStaff.PFNo, tblHR_OfficeStaff.PANNo, tblHR_OfficeStaff.PassPortNo, tblHR_OfficeStaff.ExpiryDate, tblHR_OfficeStaff.AdditionalInformation", "tblHR_OfficeStaff", "tblHR_OfficeStaff.EmpId='" + text + "'and tblHR_OfficeStaff.CompId='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS);
				if (DS.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("SwapCardNo", "tblHR_SwapCard", "Id='" + DS.Tables[0].Rows[0]["SwapCardNo"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					text2 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "NA" : dataSet2.Tables[0].Rows[0][0].ToString());
					string cmdText3 = fun.select("LogoImage", "tblCompany_master", "CompId='" + DS.Tables[0].Rows[0]["CompId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[40] = (byte[])dataSet3.Tables[0].Rows[0][0];
					}
					string cmdText4 = fun.select("Description +' ['+Symbol+']'", "tblHR_Departments", "Id='" + DS.Tables[0].Rows[0]["Department"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value = dataSet4.Tables[0].Rows[0][0].ToString();
					}
					string cmdText5 = fun.select("Name +' ['+Symbol+']'", "BusinessGroup", "Id='" + DS.Tables[0].Rows[0]["BGGroup"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet5.Tables[0].Rows[0][0].ToString();
					}
					string cmdText6 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "UserID='" + DS.Tables[0].Rows[0]["DirectorsName"].ToString() + "' AND (Designation='2' OR Designation='3')");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					string text3 = "";
					text3 = ((dataSet6.Tables[0].Rows.Count <= 0) ? "NA" : (dataSet6.Tables[0].Rows[0][0].ToString() + "." + dataSet6.Tables[0].Rows[0][1].ToString()));
					string value3 = DS.Tables[0].Rows[0]["Title"].ToString() + "." + DS.Tables[0].Rows[0]["EmployeeName"].ToString();
					string cmdText7 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "UserID='" + DS.Tables[0].Rows[0]["DeptHead"].ToString() + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					string text4 = "";
					text4 = ((dataSet7.Tables[0].Rows.Count <= 0) ? "NA" : (dataSet7.Tables[0].Rows[0][0].ToString() + "." + dataSet7.Tables[0].Rows[0][1].ToString()));
					string cmdText8 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "UserID='" + DS.Tables[0].Rows[0]["GroupLeader"].ToString() + "'AND Designation='7'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8);
					string text5 = "";
					text5 = ((dataSet8.Tables[0].Rows.Count <= 0) ? "NA" : (dataSet8.Tables[0].Rows[0][0].ToString() + "." + dataSet8.Tables[0].Rows[0][0].ToString()));
					string cmdText9 = fun.select("Type +' ['+Symbol+']'", "tblHR_Designation", "Id='" + DS.Tables[0].Rows[0]["Designation"].ToString() + "'");
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter9.Fill(dataSet9);
					string value4 = "";
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						value4 = dataSet9.Tables[0].Rows[0][0].ToString();
					}
					string cmdText10 = fun.select("Symbol", "tblHR_Grade", "Id='" + DS.Tables[0].Rows[0]["Grade"].ToString() + "'");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					string value5 = "";
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						value5 = dataSet10.Tables[0].Rows[0]["Symbol"].ToString();
					}
					string cmdText11 = fun.select("MobileNo", "tblHR_CoporateMobileNo", "Id='" + DS.Tables[0].Rows[0]["MobileNo"].ToString() + "'");
					SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
					SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
					DataSet dataSet11 = new DataSet();
					sqlDataAdapter11.Fill(dataSet11);
					string text6 = "";
					text6 = ((dataSet11.Tables[0].Rows.Count <= 0) ? "NA" : dataSet11.Tables[0].Rows[0][0].ToString());
					string cmdText12 = fun.select("ExtNo", "tblHR_IntercomExt", "Id='" + DS.Tables[0].Rows[0]["ExtensionNo"].ToString() + "'");
					SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
					SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
					DataSet dataSet12 = new DataSet();
					sqlDataAdapter12.Fill(dataSet12);
					string text7 = "";
					text7 = ((dataSet12.Tables[0].Rows.Count <= 0) ? "NA" : dataSet12.Tables[0].Rows[0][0].ToString());
					string value6 = DS.Tables[0].Rows[0]["PermanentAddress"].ToString();
					string value7 = DS.Tables[0].Rows[0]["CorrespondenceAddress"].ToString();
					string value8 = DS.Tables[0].Rows[0]["EmailId2"].ToString();
					string value9 = DS.Tables[0].Rows[0]["Gender"].ToString();
					DS.Tables[0].Rows[0]["MartialStatus"].ToString();
					string value10 = DS.Tables[0].Rows[0]["BloodGroup"].ToString();
					string value11 = DS.Tables[0].Rows[0]["Height"].ToString();
					string value12 = DS.Tables[0].Rows[0]["Weight"].ToString();
					string value13 = DS.Tables[0].Rows[0]["Religion"].ToString();
					string value14 = DS.Tables[0].Rows[0]["Cast"].ToString();
					string value15 = DS.Tables[0].Rows[0]["EducationalQualification"].ToString();
					string value16 = DS.Tables[0].Rows[0]["AdditionalQualification"].ToString();
					string value17 = DS.Tables[0].Rows[0]["LastCompanyName"].ToString();
					string value18 = DS.Tables[0].Rows[0]["WorkingDuration"].ToString();
					string value19 = DS.Tables[0].Rows[0]["TotalExperience"].ToString();
					string value20 = DS.Tables[0].Rows[0]["CurrentCTC"].ToString();
					string value21 = DS.Tables[0].Rows[0]["BankAccountNo"].ToString();
					string value22 = DS.Tables[0].Rows[0]["PFNo"].ToString();
					string value23 = DS.Tables[0].Rows[0]["PANNo"].ToString();
					string value24 = DS.Tables[0].Rows[0]["PassPortNo"].ToString();
					string value25 = DS.Tables[0].Rows[0]["AdditionalInformation"].ToString();
					string text8 = DS.Tables[0].Rows[0]["DateOfBirth"].ToString();
					text8 = ((!(text8 == "")) ? fun.FromDateDMY(text8) : "");
					string text9 = DS.Tables[0].Rows[0]["ResignationDate"].ToString();
					string text10 = "";
					text10 = ((!(text9 == "")) ? fun.FromDateDMY(text9) : "");
					string text11 = DS.Tables[0].Rows[0]["Joiningdate"].ToString();
					string text12 = "";
					text12 = ((!(text11 == "")) ? fun.FromDateDMY(text11) : "");
					string text13 = DS.Tables[0].Rows[0]["ExpiryDate"].ToString();
					string text14 = "";
					text14 = ((!(text13 == "")) ? fun.FromDateDMY(text13) : "");
					int num2 = 0;
					num2 = Convert.ToInt32(DS.Tables[0].Rows[0]["MartialStatus"].ToString());
					string text15 = "";
					text15 = ((num2 != 1) ? "Unmarried" : "Married");
					int num3 = Convert.ToInt32(DS.Tables[0].Rows[0]["PhysicallyHandycapped"].ToString());
					string text16 = "";
					text16 = ((num3 != 1) ? "No" : "Yes");
					string value26 = fun.CompAdd(num);
					string company = fun.getCompany(num);
					dataRow[0] = company;
					if (DS.Tables[0].Rows[0]["PhotoData"] != DBNull.Value && DS.Tables[0].Rows[0]["PhotoFileName"].ToString() != "")
					{
						dataRow[1] = (byte[])DS.Tables[0].Rows[0]["PhotoData"];
					}
					else
					{
						dataRow[1] = fun.ImageToBinary(base.Server.MapPath("~/images/User.jpg"));
					}
					dataRow[2] = value26;
					dataRow[3] = text2;
					dataRow[4] = value3;
					dataRow[5] = value;
					dataRow[6] = value2;
					dataRow[7] = text3;
					dataRow[8] = text4;
					dataRow[9] = text5;
					dataRow[10] = value4;
					dataRow[11] = value5;
					dataRow[12] = text6;
					dataRow[13] = text7;
					dataRow[14] = text12;
					dataRow[15] = text8;
					dataRow[16] = text10;
					dataRow[17] = text15;
					dataRow[18] = text16;
					dataRow[19] = value6;
					dataRow[20] = value7;
					dataRow[21] = value8;
					dataRow[22] = value9;
					dataRow[23] = value10;
					dataRow[24] = value11;
					dataRow[25] = value12;
					dataRow[26] = value13;
					dataRow[27] = value14;
					dataRow[28] = value15;
					dataRow[29] = value16;
					dataRow[30] = value17;
					dataRow[31] = value18;
					dataRow[32] = value19;
					dataRow[33] = value20;
					dataRow[34] = value21;
					dataRow[35] = value22;
					dataRow[36] = value23;
					dataRow[37] = value24;
					dataRow[38] = text14;
					dataRow[39] = value25;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				dataSet.Tables.Add(dataTable);
				dataSet.AcceptChanges();
				DataSet dataSet13 = new OfficeStaff();
				dataSet13.Tables[0].Merge(dataSet.Tables[0]);
				dataSet13.AcceptChanges();
				string text17 = base.Server.MapPath("~/Module/HR/Transactions/Reports/Staff.rpt");
				report.Load(text17);
				report.SetDataSource(dataSet13);
				((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = report;
				Session[Key] = report;
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				dataSet.Clear();
				dataSet.Dispose();
				dataTable.Clear();
				dataTable.Dispose();
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		Key = base.Request.QueryString["Key"].ToString();
		ReportDocument reportSource = (ReportDocument)Session[Key];
		((CrystalReportViewerBase)CrystalReportViewer1).ReportSource = reportSource;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		report = new ReportDocument();
		if (base.Request.QueryString["PagePrev"].ToString() == "1")
		{
			Pageback = "~/Module/HR/Transactions/OfficeStaff_Print.aspx?ModId=12&SubModId=24";
		}
		else
		{
			Pageback = "~/Module/HR/Reports/MultipleReports.aspx?ModId=12";
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(Pageback);
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		((Control)(object)CrystalReportViewer1).Dispose();
		CrystalReportViewer1 = null;
		report.Close();
		((Component)(object)report).Dispose();
		GC.Collect();
	}
}

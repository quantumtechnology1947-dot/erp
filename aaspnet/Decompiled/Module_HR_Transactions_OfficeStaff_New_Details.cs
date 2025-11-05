using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_OfficeStaff_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DSPref = new DataSet();

	private int Offid;

	private string Comprefix = "";

	private string custIdStr = "";

	private string a = "";

	protected Label Label2;

	protected Label lblEmpId;

	protected Label Label58;

	protected Label lbloffid;

	protected Label Label4;

	protected DropDownList DrpEmpTitle;

	protected TextBox TxtEmpName;

	protected RequiredFieldValidator ReqEmpName;

	protected Label Label11;

	protected DropDownList DrpDesignation;

	protected SqlDataSource SqlDesignation;

	protected RequiredFieldValidator ReqDesign;

	protected Label Label9;

	protected DropDownList DrpDepartment;

	protected SqlDataSource SqlDept;

	protected RequiredFieldValidator ReqDesign5;

	protected Label Label7;

	protected DropDownList DrpSwapcardNo;

	protected RequiredFieldValidator ReqDesign0;

	protected Label Label13;

	protected DropDownList DrpDirectorName;

	protected SqlDataSource SqlDirectors;

	protected RequiredFieldValidator ReqDesign6;

	protected Label Label10;

	protected DropDownList DrpBGGroup;

	protected SqlDataSource SqlBGGroup;

	protected RequiredFieldValidator ReqDesign1;

	protected Label Label14;

	protected DropDownList DrpGroupLeader;

	protected SqlDataSource Sqlgroup;

	protected RequiredFieldValidator ReqDesign7;

	protected Label Label15;

	protected DropDownList DrpDeptHead;

	protected SqlDataSource SqlDeptHead;

	protected RequiredFieldValidator ReqDesign2;

	protected Label Label12;

	protected DropDownList DrpMobileNo;

	protected RequiredFieldValidator ReqDesign8;

	protected Label Label16;

	protected DropDownList DrpGrade;

	protected SqlDataSource SqlGrade;

	protected RequiredFieldValidator ReqDesign3;

	protected Label Label23;

	protected TextBox TxtContactNo;

	protected RequiredFieldValidator ReqContNO;

	protected Label Label6;

	protected TextBox TxtMail;

	protected RegularExpressionValidator RegEmail;

	protected Label Label24;

	protected TextBox TxtERPMail;

	protected RegularExpressionValidator RegErpEmail;

	protected Label Label18;

	protected DropDownList DrpExtensionNo;

	protected SqlDataSource SqlExtension;

	protected RequiredFieldValidator ReqDesign4;

	protected Label Label25;

	protected TextBox TxtJoinDate;

	protected CalendarExtender TxtJoinDate_CalendarExtender;

	protected RequiredFieldValidator ReqJoinDt;

	protected RegularExpressionValidator RegJODateVal;

	protected Label Label19;

	protected TextBox TxtResignDate;

	protected CalendarExtender TxtResignDate_CalendarExtender;

	protected Label Label59;

	protected Button btnnxt;

	protected Button BtnCancel2;

	protected TabPanel TabPanel1;

	protected Label Label29;

	protected Label Label32;

	protected TextBox TxtPermanentAddress;

	protected RequiredFieldValidator ReqPermantAdd;

	protected TextBox TxtCAddress;

	protected RequiredFieldValidator ReqCorrspoAdd;

	protected Label Label31;

	protected TextBox TxtEmail;

	protected RegularExpressionValidator RegEmail0;

	protected Label Label30;

	protected TextBox TxtDateofBirth;

	protected CalendarExtender TxtDateofBirth_CalendarExtender;

	protected RequiredFieldValidator ReqDOB;

	protected RegularExpressionValidator RegBirthDateVal;

	protected Label Label36;

	protected DropDownList DrpGender;

	protected RequiredFieldValidator ReqGender;

	protected Label Label34;

	protected RadioButton RdbtnMarried;

	protected RadioButton RdbtnUnmarried;

	protected Label Label33;

	protected DropDownList DrpBloodGroup;

	protected RequiredFieldValidator ReqGender0;

	protected Label Label35;

	protected TextBox TxtHeight;

	protected RequiredFieldValidator ReqHeight;

	protected Label Label39;

	protected TextBox TxtWeight;

	protected RequiredFieldValidator ReqWeight;

	protected Label Label41;

	protected RadioButton RdbtnYes;

	protected RadioButton RdbtnNo;

	protected Label Label37;

	protected TextBox TxtReligion;

	protected RequiredFieldValidator ReqReligion;

	protected Label Label38;

	protected TextBox TxtCast;

	protected RequiredFieldValidator ReqCast;

	protected Button btnNext2;

	protected Button BtnCancel1;

	protected TabPanel TabPanel2;

	protected Label Label44;

	protected TextBox TxtEducatinalQualificatin;

	protected RequiredFieldValidator ReqEduQual;

	protected Label Label42;

	protected TextBox TxtAdditionalQualification;

	protected Label Label48;

	protected TextBox TxtLastCompanyName;

	protected Label Label46;

	protected TextBox TxtTotalExperience;

	protected Label Label49;

	protected TextBox TxtWorkingDuration;

	protected Button btnNext3;

	protected Button BtnCancel0;

	protected TabPanel TabPanel3;

	protected Label Label51;

	protected TextBox TxtCurrentCTC;

	protected Label Label54;

	protected TextBox TxtBankAccNo;

	protected Label Label53;

	protected TextBox TxtPFNo;

	protected Label Label55;

	protected TextBox TxtPANNo;

	protected Label Label56;

	protected TextBox TxtPassportNo;

	protected Label Label52;

	protected TextBox TxtExpiryDate;

	protected CalendarExtender TxtExpiryDate_CalendarExtender;

	protected RegularExpressionValidator RegTxtExpiryDate;

	protected Label Label57;

	protected TextBox TxtAdditionalInformation;

	protected Label Label27;

	protected FileUpload FileUploadPhoto;

	protected Label Label28;

	protected FileUpload FileUploadControl;

	protected Button BtnSubmit;

	protected Button BtnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			TxtJoinDate.Attributes.Add("readonly", "readonly");
			TxtResignDate.Attributes.Add("readonly", "readonly");
			TxtDateofBirth.Attributes.Add("readonly", "readonly");
			TxtExpiryDate.Attributes.Add("readonly", "readonly");
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			int num = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("EmpId", "tblHR_OfficeStaff", "CompId='" + num + "'order by EmpId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "tblHR_OfficeStaff");
			string cmdText2 = fun.select("Prefix", "tblCompany_master", "CompId='" + num + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(DSPref, "tblCompany_master");
			if (DSPref.Tables[0].Rows.Count > 0)
			{
				Comprefix = DSPref.Tables[0].Rows[0]["Prefix"].ToString();
			}
			if (DS.Tables[0].Rows.Count > 0)
			{
				string text = DS.Tables[0].Rows[0][0].ToString();
				string text2 = text;
				foreach (char c in text2)
				{
					if (char.IsDigit(c))
					{
						a += c;
					}
				}
				int num2 = Convert.ToInt32(a) + 1;
				custIdStr = Comprefix + num2.ToString("D4");
			}
			else
			{
				custIdStr = Comprefix + "0001";
			}
			Offid = Convert.ToInt32(base.Request.QueryString["OfferId"]);
			lblEmpId.Text = custIdStr;
			lbloffid.Text = Offid.ToString();
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
			if (!base.IsPostBack)
			{
				string cmdText3 = fun.select("Title,EmployeeName", "tblHR_Offer_Master", "OfferId='" + Offid + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet, "tblHR_Offer_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					TxtEmpName.Text = dataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
					DrpEmpTitle.SelectedValue = dataSet.Tables[0].Rows[0]["Title"].ToString();
				}
				string cmdText4 = fun.select("Id,SwapCardNo ", "tblHR_SwapCard", "Id='1' OR Id NOT IN (select SwapCardNo from tblHR_OfficeStaff where SwapCardNo is not null AND CompId='" + num + "')");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter4.Fill(dataSet2, "tblHR_SwapCard");
				DrpSwapcardNo.DataSource = dataSet2.Tables["tblHR_SwapCard"];
				DrpSwapcardNo.DataValueField = "Id";
				DrpSwapcardNo.DataTextField = "SwapCardNo";
				DrpSwapcardNo.DataBind();
				string cmdText5 = fun.select("Id,MobileNo ", "tblHR_CoporateMobileNo", "Id='1' OR Id NOT IN (select MobileNo from tblHR_OfficeStaff where MobileNo is not null AND CompId='" + num + "')");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter5.Fill(dataSet3, "tblHR_CoporateMobileNo");
				DrpMobileNo.DataSource = dataSet3.Tables["tblHR_CoporateMobileNo"];
				DrpMobileNo.DataValueField = "Id";
				DrpMobileNo.DataTextField = "MobileNo";
				DrpMobileNo.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			Offid = Convert.ToInt32(base.Request.QueryString["OfferId"]);
			string text2 = fun.FromDate(TxtJoinDate.Text);
			string text3 = "";
			text3 = ((!(TxtResignDate.Text == "")) ? fun.FromDate(TxtResignDate.Text) : "");
			string text4 = "";
			text4 = ((!(TxtDateofBirth.Text == "")) ? fun.FromDate(TxtDateofBirth.Text) : "");
			string text5 = "";
			text5 = ((!(TxtExpiryDate.Text == "")) ? fun.FromDate(TxtExpiryDate.Text) : "");
			int num3 = 0;
			num3 = (RdbtnMarried.Checked ? 1 : 0);
			int num4 = 0;
			num4 = (RdbtnYes.Checked ? 1 : 0);
			string text6 = "";
			HttpPostedFile postedFile = FileUploadPhoto.PostedFile;
			byte[] array = null;
			if (FileUploadPhoto.PostedFile != null)
			{
				Stream inputStream = FileUploadPhoto.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text6 = Path.GetFileName(postedFile.FileName);
			}
			string text7 = "";
			HttpPostedFile postedFile2 = FileUploadControl.PostedFile;
			byte[] array2 = null;
			if (FileUploadControl.PostedFile != null)
			{
				Stream inputStream2 = FileUploadControl.PostedFile.InputStream;
				BinaryReader binaryReader2 = new BinaryReader(inputStream2);
				array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
				text7 = Path.GetFileName(postedFile2.FileName);
			}
			sqlConnection.Open();
			string cmdText = fun.select("EmpId", "tblHR_OfficeStaff", "CompId='" + num + "'Order by  EmpId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "tblHR_OfficeStaff");
			string cmdText2 = fun.select("Prefix", "tblCompany_master", "CompId='" + num + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(DSPref, "tblCompany_master");
			string text8 = DSPref.Tables[0].Rows[0][0].ToString();
			string text9 = "";
			if (DS.Tables[0].Rows.Count > 0)
			{
				string text10 = DS.Tables[0].Rows[0][0].ToString();
				string text11 = "";
				string text12 = text10;
				foreach (char c in text12)
				{
					if (char.IsDigit(c))
					{
						text11 += c;
					}
				}
				text9 = text8 + (Convert.ToInt32(text11) + 1).ToString("D4");
			}
			else
			{
				text9 = text8 + "0001";
			}
			if (fun.EmailValidation(TxtEmail.Text) && fun.EmailValidation(TxtERPMail.Text) && fun.EmailValidation(TxtMail.Text) && TxtEmpName.Text != "" && TxtContactNo.Text != "" && text2.ToString() != "" && TxtPermanentAddress.Text != "" && TxtCAddress.Text != "" && text4.ToString() != "" && DrpGender.SelectedValue != "Select" && TxtHeight.Text != "" && TxtWeight.Text != "" && TxtReligion.Text != "" && TxtCast.Text != "" && TxtEducatinalQualificatin.Text != "" && text9.ToString() != "" && currDate.ToString() != "" && currTime.ToString() != "" && DrpBloodGroup.SelectedValue != "Select" && fun.DateValidation(TxtJoinDate.Text) && fun.DateValidation(TxtDateofBirth.Text) && fun.DateValidation(TxtExpiryDate.Text))
			{
				string cmdText3 = fun.insert("tblHR_OfficeStaff", "OfferId, EmpId,SysDate,SysTime,FinYearId,CompId,SessionId,Title,EmployeeName,SwapCardNo,Department,BGGroup,DirectorsName,DeptHead,GroupLeader,Designation,Grade,MobileNo,ContactNo,CompanyEmail,EmailId1,ExtensionNo,JoiningDate,ResignationDate,PhotoFileName,PhotoSize,PhotoContentType,PhotoData,PermanentAddress,CorrespondenceAddress,EmailId2,DateOfBirth,Gender,MartialStatus,BloodGroup,Height,Weight,PhysicallyHandycapped,Religion,Cast,EducationalQualification,AdditionalQualification,LastCompanyName,WorkingDuration,TotalExperience,CVFileName,CVSize,CVContentType,CVData,CurrentCTC,BankAccountNo,PFNo,PANNo,PassPortNo,ExpiryDate,AdditionalInformation", string.Concat("'", Offid, "','", text9, "','", currDate, "','", currTime, "','", num2, "','", num, "','", text, "','", DrpEmpTitle.SelectedItem, "','", TxtEmpName.Text, "','", DrpSwapcardNo.SelectedValue, "','", DrpDepartment.SelectedValue, "','", DrpBGGroup.SelectedValue, "','", DrpDirectorName.SelectedValue, "','", DrpDeptHead.SelectedValue, "','", DrpGroupLeader.SelectedValue, "','", DrpDesignation.SelectedValue, "','", DrpGrade.SelectedValue, "','", DrpMobileNo.SelectedValue, "','", TxtContactNo.Text, "','", TxtMail.Text, "','", TxtERPMail.Text, "','", DrpExtensionNo.SelectedValue, "','", text2, "','", text3, "','", text6, "','", array.Length, "','", postedFile.ContentType, "',@Data,'", TxtPermanentAddress.Text, "','", TxtCAddress.Text, "','", TxtEmail.Text, "','", text4, "','", DrpGender.SelectedValue, "','", num3, "','", DrpBloodGroup.SelectedValue, "','", TxtHeight.Text, "','", TxtWeight.Text, "','", num4, "','", TxtReligion.Text, "','", TxtCast.Text, "','", TxtEducatinalQualificatin.Text, "','", TxtAdditionalQualification.Text, "','", TxtLastCompanyName.Text, "','", TxtWorkingDuration.Text, "','", TxtTotalExperience.Text, "','", text7, "','", array2.Length, "','", postedFile2.ContentType, "',@CV,'", TxtCurrentCTC.Text, "','", TxtBankAccNo.Text, "','", TxtPFNo.Text, "','", TxtPANNo.Text, "','", TxtPassportNo.Text, "','", text5, "','", TxtAdditionalInformation.Text, "'"));
				SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				sqlCommand.Parameters.AddWithValue("@CV", array2);
				sqlCommand.ExecuteNonQuery();
				base.Response.Redirect("OfficeStaff_New.aspx?ModId=12&SubModId=24&msg=Staff data is entered.");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void btnnxt_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void btnNext2_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void btnNext3_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[3];
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("OfficeStaff_New.aspx?ModId=12&SubModId=24");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}
}

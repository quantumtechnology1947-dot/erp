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

public class Module_HR_Transactions_OfficeStaff_Edit_Deatails : Page, IRequiresSessionState
{
	protected Label Label2;

	protected Label lblEmpId;

	protected Label Label58;

	protected Label lbloffid;

	protected Label Label4;

	protected DropDownList DrpEmpTitle;

	protected TextBox TxtEmpName;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected Label Label11;

	protected DropDownList DrpDesignation;

	protected SqlDataSource SqlDesignation;

	protected RequiredFieldValidator ReqDesign;

	protected Label Label9;

	protected DropDownList DrpDepartment;

	protected SqlDataSource SqlDept;

	protected RequiredFieldValidator ReqDept;

	protected Label Label7;

	protected DropDownList DrpSwapcardNo;

	protected RequiredFieldValidator ReqSwapNo;

	protected Label Label13;

	protected DropDownList DrpDirectorName;

	protected Label Label10;

	protected DropDownList DrpBGGroup;

	protected SqlDataSource SqlBGGroup;

	protected RequiredFieldValidator ReqBGgroup;

	protected Label lblGRPLDR;

	protected DropDownList DrpGroupLeader;

	protected Label Label15;

	protected DropDownList DrpDeptHead;

	protected Label Label12;

	protected DropDownList DrpMobileNo;

	protected RequiredFieldValidator ReqBGgroup4;

	protected Label Label16;

	protected DropDownList DrpGrade;

	protected SqlDataSource SqlGrade;

	protected RequiredFieldValidator ReqGrade;

	protected Label Label23;

	protected TextBox TxtContactNo;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected Label Label6;

	protected TextBox TxtMail;

	protected RegularExpressionValidator RegEmail;

	protected Label Label24;

	protected TextBox TxtERPMail;

	protected RegularExpressionValidator RegEmail0;

	protected Label Label18;

	protected DropDownList DrpExtensionNo;

	protected SqlDataSource SqlExtension;

	protected RequiredFieldValidator ReqExtNo;

	protected Label Label25;

	protected TextBox TxtJoinDate;

	protected CalendarExtender TxtJoinDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegJoinDateVal;

	protected Label Label19;

	protected TextBox TxtResignDate;

	protected CalendarExtender TxtResignDate_CalendarExtender;

	protected Label Label59;

	protected Button btnNext1;

	protected Button BtnCancel2;

	protected TabPanel TabPanel1;

	protected Label Label29;

	protected Label Label32;

	protected TextBox TxtPermanentAddress;

	protected RequiredFieldValidator ReqPersonalEmail6;

	protected TextBox TxtCAddress;

	protected RequiredFieldValidator ReqPersonalEmail7;

	protected Label Label31;

	protected TextBox TxtEmail;

	protected RegularExpressionValidator RegEmail1;

	protected Label Label30;

	protected TextBox TxtDateofBirth;

	protected CalendarExtender TxtDateofBirth_CalendarExtender;

	protected RequiredFieldValidator ReqDOB;

	protected RegularExpressionValidator RegularBirth;

	protected Label Label36;

	protected DropDownList DrpGender;

	protected RequiredFieldValidator ReqGender;

	protected Label Label34;

	protected RadioButton RdbtnMarried;

	protected RadioButton RdbtnUnmarried;

	protected Label Label33;

	protected DropDownList DrpBloodGroup;

	protected RequiredFieldValidator ReqPersonalEmail0;

	protected Label Label35;

	protected TextBox TxtHeight;

	protected RequiredFieldValidator ReqPersonalEmail4;

	protected Label Label39;

	protected TextBox TxtWeight;

	protected RequiredFieldValidator ReqPersonalEmail1;

	protected Label Label41;

	protected RadioButton RdbtnYes;

	protected RadioButton RdbtnNo;

	protected Label Label37;

	protected TextBox TxtReligion;

	protected RequiredFieldValidator ReqPersonalEmail2;

	protected Label Label38;

	protected TextBox TxtCast;

	protected RequiredFieldValidator ReqPersonalEmail3;

	protected Button btnNext2;

	protected Button Button1;

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

	protected Button btnCancel3;

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

	protected Label lblcv;

	protected ImageButton ImageButton2;

	protected Label Label28;

	protected FileUpload FileUploadControl;

	protected HyperLink HyperLink1;

	protected ImageButton ImageButton1;

	protected Button BtnUpdate;

	protected Button BtnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private int id;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			fun.getCurrDate();
			fun.getCurrTime();
			string text = base.Request.QueryString["EmpId"];
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			Convert.ToInt32(Session["finyear"]);
			TxtJoinDate.Attributes.Add("readonly", "readonly");
			TxtResignDate.Attributes.Add("readonly", "readonly");
			TxtDateofBirth.Attributes.Add("readonly", "readonly");
			TxtExpiryDate.Attributes.Add("readonly", "readonly");
			string text2 = "";
			string text3 = "";
			sqlConnection.Open();
			string cmdText = fun.select("UserID,EmpId,OfferId,FinYearId,CompId,Title,EmployeeName,SwapCardNo,Department,BGGroup,DirectorsName,DeptHead,GroupLeader,Designation,Grade,MobileNo,ContactNo,CompanyEmail,EmailId1,ExtensionNo,JoiningDate,ResignationDate,PhotoFileName,PhotoSize,PhotoContentType,PhotoData,PermanentAddress,CorrespondenceAddress,EmailId2,DateOfBirth,Gender,MartialStatus,BloodGroup,Height,Weight,PhysicallyHandycapped,Religion,Cast,EducationalQualification,AdditionalQualification,LastCompanyName,WorkingDuration,TotalExperience,CurrentCTC,CVFileName,CVSize,CVContentType,CVData, BankAccountNo,PFNo,PANNo,PassPortNo,ExpiryDate,AdditionalInformation,WR ", "tblHR_OfficeStaff", "CompId='" + num + "'  and EmpId='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["UserID"].ToString());
			if (!base.IsPostBack)
			{
				fun.depthead(DrpDeptHead, id);
				fun.filldrp(DrpGroupLeader, 7, id);
				fun.filldrpDirector(DrpDirectorName, id);
				lblEmpId.Text = dataSet.Tables[0].Rows[0]["EmpId"].ToString();
				lbloffid.Text = dataSet.Tables[0].Rows[0]["OfferId"].ToString();
				DrpEmpTitle.SelectedValue = dataSet.Tables[0].Rows[0]["Title"].ToString();
				TxtEmpName.Text = dataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
				if (dataSet.Tables[0].Rows[0]["SwapCardNo"].ToString() != "")
				{
					text2 = dataSet.Tables[0].Rows[0]["SwapCardNo"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["Department"].ToString() != "")
				{
					DrpDepartment.SelectedValue = dataSet.Tables[0].Rows[0]["Department"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["BGGroup"].ToString() != "")
				{
					DrpBGGroup.SelectedValue = dataSet.Tables[0].Rows[0]["BGGroup"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["DirectorsName"].ToString() != "")
				{
					DrpDirectorName.SelectedValue = dataSet.Tables[0].Rows[0]["DirectorsName"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["DeptHead"].ToString() != "")
				{
					DrpDeptHead.SelectedValue = dataSet.Tables[0].Rows[0]["DeptHead"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["GroupLeader"].ToString() != "")
				{
					DrpGroupLeader.SelectedValue = dataSet.Tables[0].Rows[0]["GroupLeader"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["Designation"].ToString() != "")
				{
					DrpDesignation.SelectedValue = dataSet.Tables[0].Rows[0]["Designation"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["MobileNo"].ToString() != "")
				{
					text3 = dataSet.Tables[0].Rows[0]["MobileNo"].ToString();
				}
				if (dataSet.Tables[0].Rows[0]["Grade"].ToString() != "")
				{
					DrpGrade.SelectedValue = dataSet.Tables[0].Rows[0]["Grade"].ToString();
				}
				TxtContactNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtMail.Text = dataSet.Tables[0].Rows[0]["CompanyEmail"].ToString();
				TxtERPMail.Text = dataSet.Tables[0].Rows[0]["EmailId1"].ToString();
				if (dataSet.Tables[0].Rows[0]["ExtensionNo"].ToString() != "")
				{
					DrpExtensionNo.SelectedValue = dataSet.Tables[0].Rows[0]["ExtensionNo"].ToString();
				}
				TxtJoinDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["JoiningDate"].ToString());
				string text4 = dataSet.Tables[0].Rows[0]["ResignationDate"].ToString();
				if (text4 == "")
				{
					TxtResignDate.Text = "";
				}
				else
				{
					TxtResignDate.Text = fun.FromDateDMY(text4);
				}
				string text5 = dataSet.Tables[0].Rows[0]["ExpiryDate"].ToString();
				if (text5 == "")
				{
					TxtExpiryDate.Text = "";
				}
				else
				{
					TxtExpiryDate.Text = fun.FromDateDMY(text5);
				}
				TxtPermanentAddress.Text = dataSet.Tables[0].Rows[0]["PermanentAddress"].ToString();
				TxtCAddress.Text = dataSet.Tables[0].Rows[0]["CorrespondenceAddress"].ToString();
				TxtEmail.Text = dataSet.Tables[0].Rows[0]["EmailId2"].ToString();
				string text6 = dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString();
				if (text6 == "")
				{
					TxtDateofBirth.Text = "";
				}
				else
				{
					TxtDateofBirth.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DateOfBirth"].ToString());
				}
				DrpGender.SelectedValue = dataSet.Tables[0].Rows[0]["Gender"].ToString();
				int num2 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["MartialStatus"].ToString());
				if (num2 == 1)
				{
					RdbtnMarried.Checked = true;
				}
				else
				{
					RdbtnUnmarried.Checked = true;
				}
				DrpBloodGroup.SelectedValue = dataSet.Tables[0].Rows[0]["BloodGroup"].ToString();
				TxtHeight.Text = dataSet.Tables[0].Rows[0]["Height"].ToString();
				TxtWeight.Text = dataSet.Tables[0].Rows[0]["Weight"].ToString();
				int num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PhysicallyHandycapped"].ToString());
				if (num3 == 1)
				{
					RdbtnYes.Checked = true;
				}
				else
				{
					RdbtnNo.Checked = true;
				}
				TxtReligion.Text = dataSet.Tables[0].Rows[0]["Religion"].ToString();
				TxtCast.Text = dataSet.Tables[0].Rows[0]["Cast"].ToString();
				TxtEducatinalQualificatin.Text = dataSet.Tables[0].Rows[0]["EducationalQualification"].ToString();
				TxtAdditionalQualification.Text = dataSet.Tables[0].Rows[0]["AdditionalQualification"].ToString();
				TxtLastCompanyName.Text = dataSet.Tables[0].Rows[0]["LastCompanyName"].ToString();
				TxtWorkingDuration.Text = dataSet.Tables[0].Rows[0]["WorkingDuration"].ToString();
				TxtTotalExperience.Text = dataSet.Tables[0].Rows[0]["TotalExperience"].ToString();
				TxtCurrentCTC.Text = dataSet.Tables[0].Rows[0]["CurrentCTC"].ToString();
				TxtBankAccNo.Text = dataSet.Tables[0].Rows[0]["BankAccountNo"].ToString();
				TxtPFNo.Text = dataSet.Tables[0].Rows[0]["PFNo"].ToString();
				TxtPANNo.Text = dataSet.Tables[0].Rows[0]["PANNo"].ToString();
				TxtPassportNo.Text = dataSet.Tables[0].Rows[0]["PassportNo"].ToString();
				TxtAdditionalInformation.Text = dataSet.Tables[0].Rows[0]["AdditionalInformation"].ToString();
				ImageButton2.Visible = false;
				FileUploadPhoto.Visible = true;
				if (dataSet.Tables[0].Rows[0]["PhotoFileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["PhotoFileName"] != DBNull.Value)
				{
					ImageButton2.Visible = true;
					lblcv.Text = dataSet.Tables[0].Rows[0]["PhotoFileName"].ToString();
					FileUploadPhoto.Visible = false;
				}
				ImageButton1.Visible = false;
				FileUploadControl.Visible = true;
				HyperLink1.Text = "";
				if (dataSet.Tables[0].Rows[0]["CVFileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["CVFileName"] != DBNull.Value)
				{
					ImageButton1.Visible = true;
					HyperLink1.Text = dataSet.Tables[0].Rows[0]["CVFileName"].ToString();
					HyperLink1.NavigateUrl = "~/Controls/DownloadFile.aspx?id=" + id + "&tbl=tblHR_OfficeStaff&qfd=CVData&qfn=CVFileName&qct=CVContentType";
					FileUploadControl.Visible = false;
				}
				string cmdText2 = fun.select("Id,SwapCardNo ", "tblHR_SwapCard", " Id='1' OR  Id='" + text2 + "' OR Id NOT IN (select SwapCardNo from tblHR_OfficeStaff where SwapCardNo is not null AND CompId='" + num + "')");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblHR_SwapCard");
				DrpSwapcardNo.DataSource = dataSet2.Tables["tblHR_SwapCard"];
				DrpSwapcardNo.DataValueField = "Id";
				DrpSwapcardNo.DataTextField = "SwapCardNo";
				DrpSwapcardNo.DataBind();
				DrpSwapcardNo.SelectedValue = text2;
				string cmdText3 = fun.select("Id,MobileNo ", "tblHR_CoporateMobileNo", "Id='1' OR  Id='" + text3 + "' OR  Id NOT IN (select MobileNo from tblHR_OfficeStaff where MobileNo is not null AND CompId='" + num + "')");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblHR_CoporateMobileNo");
				DrpMobileNo.DataSource = dataSet3.Tables["tblHR_CoporateMobileNo"];
				DrpMobileNo.DataValueField = "Id";
				DrpMobileNo.DataTextField = "MobileNo";
				DrpMobileNo.DataBind();
				DrpMobileNo.SelectedValue = text3;
			}
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		string text = base.Request.QueryString["EmpId"];
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			fun.getCurrDate();
			fun.getCurrTime();
			Session["username"].ToString();
			Convert.ToInt32(Session["compid"]);
			string text2 = fun.FromDate(TxtJoinDate.Text);
			string text3 = "";
			text3 = ((!(TxtResignDate.Text == "")) ? fun.FromDate(TxtResignDate.Text) : "");
			string text4 = "";
			text4 = ((!(TxtDateofBirth.Text == "")) ? fun.FromDate(TxtDateofBirth.Text) : "");
			string text5 = "";
			text5 = ((!(TxtExpiryDate.Text == "")) ? fun.FromDate(TxtExpiryDate.Text) : "");
			int num = 0;
			num = (RdbtnMarried.Checked ? 1 : 0);
			int num2 = 0;
			num2 = (RdbtnYes.Checked ? 1 : 0);
			string text6 = "";
			HttpPostedFile postedFile = FileUploadPhoto.PostedFile;
			byte[] array = null;
			if (FileUploadPhoto.PostedFile != null)
			{
				Stream inputStream = FileUploadPhoto.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text6 = Path.GetFileName(postedFile.FileName);
				string cmdText = fun.update("tblHR_OfficeStaff", "PhotoFileName='" + text6 + "',PhotoSize='" + array.Length + "',PhotoContentType='" + postedFile.ContentType + "',PhotoData=@Data", "EmpId='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				sqlCommand.ExecuteNonQuery();
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
				string cmdText2 = fun.update("tblHR_OfficeStaff", "CVFileName='" + text7 + "',CVSize='" + array2.Length + "',CVContentType='" + postedFile2.ContentType + "',CVData=@CV", "EmpId='" + text + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand2.Parameters.AddWithValue("@CV", array2);
				sqlCommand2.ExecuteNonQuery();
			}
			string text8 = "";
			string text9 = "";
			string text10 = "";
			if (DrpDeptHead.SelectedValue != "Select")
			{
				text8 = DrpDeptHead.SelectedValue;
			}
			if (DrpGroupLeader.SelectedValue != "Select")
			{
				text10 = DrpGroupLeader.SelectedValue;
			}
			if (DrpDirectorName.SelectedValue != "Select")
			{
				text9 = DrpDirectorName.SelectedValue;
			}
			if (fun.EmailValidation(TxtEmail.Text) && fun.EmailValidation(TxtERPMail.Text) && fun.EmailValidation(TxtMail.Text) && DrpEmpTitle.SelectedValue != "Select" && TxtEmpName.Text != "" && DrpBGGroup.SelectedValue != "Select" && TxtContactNo.Text != "" && text2.ToString() != "" && TxtPermanentAddress.Text != "" && TxtCAddress.Text != "" && text4.ToString() != "" && DrpGender.SelectedValue != "Select" && TxtHeight.Text != "" && TxtWeight.Text != "" && TxtReligion.Text != "" && TxtCast.Text != "" && TxtEducatinalQualificatin.Text != "" && text.ToString() != "" && DrpBloodGroup.SelectedValue != "Select" && fun.DateValidation(TxtJoinDate.Text) && fun.DateValidation(TxtDateofBirth.Text) && fun.DateValidation(TxtExpiryDate.Text))
			{
				string cmdText3 = fun.update("tblHR_OfficeStaff", "Title='" + DrpEmpTitle.SelectedValue + "', EMployeeName='" + TxtEmpName.Text + "',SwapCardNo='" + DrpSwapcardNo.SelectedValue + "',Department='" + DrpDepartment.SelectedValue + "',BGGroup='" + DrpBGGroup.SelectedValue + "',DirectorsName='" + text9 + "',DeptHead='" + text8 + "',GroupLeader='" + text10 + "',Designation='" + DrpDesignation.SelectedValue + "',Grade='" + DrpGrade.SelectedValue + "',MobileNo='" + DrpMobileNo.SelectedValue + "',ContactNo='" + TxtContactNo.Text + "',CompanyEmail='" + TxtMail.Text + "',EmailId1='" + TxtERPMail.Text + "',ExtensionNo='" + DrpExtensionNo.SelectedValue + "',JoiningDate='" + text2 + "',ResignationDate='" + text3 + "',PermanentAddress='" + TxtPermanentAddress.Text + "',CorrespondenceAddress='" + TxtCAddress.Text + "',EmailId2='" + TxtEmail.Text + "',DateOfBirth='" + text4 + "',Gender='" + DrpGender.SelectedValue + "',MartialStatus='" + num + "',BloodGroup='" + DrpBloodGroup.SelectedValue + "',Height='" + TxtHeight.Text + "',Weight='" + TxtWeight.Text + "',PhysicallyHandycapped='" + num2 + "',Religion='" + TxtReligion.Text + "',Cast='" + TxtCast.Text + "',EducationalQualification='" + TxtEducatinalQualificatin.Text + "',AdditionalQualification='" + TxtAdditionalQualification.Text + "',LastCompanyName='" + TxtLastCompanyName.Text + "',WorkingDuration='" + TxtWorkingDuration.Text + "',TotalExperience='" + TxtTotalExperience.Text + "',CurrentCTC='" + TxtCurrentCTC.Text + "',BankAccountNo='" + TxtBankAccNo.Text + "',PFNo='" + TxtPFNo.Text + "',PANNo='" + TxtPANNo.Text + "',PassPortNo='" + TxtPassportNo.Text + "',ExpiryDate='" + text5 + "',AdditionalInformation='" + TxtAdditionalInformation.Text + "'", "EmpId='" + text + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				base.Response.Redirect("OfficeStaff_Edit.aspx?EmpId=0001&ModId=12&SubModId=24&msg=Staff data is updated.");
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

	protected void btnNext1_Click(object sender, EventArgs e)
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
		Page.Response.Redirect("OfficeStaff_Edit.aspx?EmpId=0001&ModId=12&SubModId=24");
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("OfficeStaff_Edit.aspx?EmpId=0001&ModId=12&SubModId=24");
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("OfficeStaff_Edit.aspx?EmpId=0001&ModId=12&SubModId=24");
	}

	protected void BtnCancel_Click1(object sender, EventArgs e)
	{
		Page.Response.Redirect("OfficeStaff_Edit.aspx?EmpId=0001&ModId=12&SubModId=24");
	}

	protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblHR_OfficeStaff", "PhotoFileName=NULL,PhotoSize=NULL,PhotoContentType=NULL,PhotoData=NULL", "UserId='" + id + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblHR_OfficeStaff", "CVFileName=NULL,CVSize=NULL,CVContentType=NULL,CVData=NULL", "UserId='" + id + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}
}

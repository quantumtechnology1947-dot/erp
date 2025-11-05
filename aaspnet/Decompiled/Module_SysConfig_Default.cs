using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SysConfig_Default : Page, IRequiresSessionState
{
	protected Button btnSave;

	protected Button Button1;

	protected TextBox txtCompanyName;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected FileUpload FileUpload1;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtRegdNewAdd;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected DropDownList DropDownRegdCountry;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtRegdPinCode;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected DropDownList DropDownRegdState;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtRegdFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected DropDownList DropDownRegdCity;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtRegdContactNo;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtRegdEmail;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtIpNew;

	protected TextBox txtPlntAdd;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected DropDownList DropDownPlntCnt;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtPlntPincode;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected DropDownList DropDownPlntSta;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected TextBox txtPlntFax;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected DropDownList DropDownPlntCity;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected TextBox txtPlantContNo;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected TextBox txtPlntEmail;

	protected RequiredFieldValidator RequiredFieldValidator51;

	protected RegularExpressionValidator RegularExpressionValidator6;

	protected TextBox txtItemCodeLimitNew;

	protected RequiredFieldValidator ReqItemCodeLimit0;

	protected RangeValidator RangeValItemCode0;

	protected TextBox txtEccNo;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected TextBox txtComm;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected TextBox txtRange;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected TextBox txtDiv;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected TextBox txtVat;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected TextBox txtCst;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected TextBox txtLicenceNo;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected CheckBox ChknewDefaultComp;

	protected TextBox txtPANNo;

	protected RequiredFieldValidator RequiredFieldValidator53;

	protected TextBox txtPrefix;

	protected RequiredFieldValidator RequiredFieldValidator55;

	protected TextBox txtFDate;

	protected CalendarExtender txtFDate_CalendarExtender;

	protected RequiredFieldValidator ReqFrmDt;

	protected TextBox txtTDate;

	protected CalendarExtender txtTDate_CalendarExtender;

	protected RequiredFieldValidator ReqToDt;

	protected TextBox txterpsysmail;

	protected RequiredFieldValidator reqerpmail;

	protected TextBox txtMobileNo;

	protected RequiredFieldValidator ReqFrmDt0;

	protected TextBox txtPassword;

	protected RequiredFieldValidator ReqFrmDt1;

	protected TextBox txtMailServerIp;

	protected RequiredFieldValidator reqMailServerIp;

	protected TabPanel New;

	protected Button Update;

	protected Button Delete;

	protected DropDownList DropDownEditCompanyName;

	protected RequiredFieldValidator RequiredFieldValidator52;

	protected FileUpload FileUpload2;

	protected Label lblImageUploadEdit;

	protected ImageButton ImageButton1;

	protected TextBox txtEditRegdAdd;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected DropDownList EditDropDownRegdCountry;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtEditRegdPinCode;

	protected RequiredFieldValidator RequiredFieldValidator31;

	protected DropDownList EditDropDownRegdState;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected TextBox txtEditRegdFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator32;

	protected DropDownList EditDropDownRegdCity;

	protected RequiredFieldValidator RequiredFieldValidator30;

	protected TextBox txtEditRegdContactNo;

	protected RequiredFieldValidator RequiredFieldValidator33;

	protected TextBox txtEditRegdEmail;

	protected RequiredFieldValidator RequiredFieldValidator34;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtIpEdit;

	protected TextBox txtEditPlntAdd;

	protected RequiredFieldValidator RequiredFieldValidator35;

	protected DropDownList EditDropDownPlntCountry;

	protected RequiredFieldValidator RequiredFieldValidator37;

	protected TextBox txtEditPlntPinCode;

	protected RequiredFieldValidator RequiredFieldValidator40;

	protected DropDownList EditDropDownPlntState;

	protected RequiredFieldValidator RequiredFieldValidator38;

	protected TextBox txtEditPlntFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator41;

	protected DropDownList EditDropDownPlntCity;

	protected RequiredFieldValidator RequiredFieldValidator39;

	protected TextBox txtEditPlntContNo;

	protected RequiredFieldValidator RequiredFieldValidator42;

	protected TextBox txtEditPlntEmail;

	protected RequiredFieldValidator RequiredFieldValidator36;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected TextBox txtErpMailEdit;

	protected RequiredFieldValidator ReqERPMailEdit;

	protected TextBox txtItemCodeLimitEdit;

	protected RangeValidator RangeValItemCode;

	protected TextBox txtEditEccNo;

	protected RequiredFieldValidator RequiredFieldValidator43;

	protected TextBox txtEditComm;

	protected RequiredFieldValidator RequiredFieldValidator46;

	protected TextBox txtEditRange;

	protected RequiredFieldValidator RequiredFieldValidator48;

	protected TextBox txtEditDiv;

	protected RequiredFieldValidator RequiredFieldValidator44;

	protected TextBox txtEditVat;

	protected RequiredFieldValidator RequiredFieldValidator47;

	protected TextBox txtEditCstNo;

	protected RequiredFieldValidator RequiredFieldValidator49;

	protected TextBox txtEditLicenceNo;

	protected RequiredFieldValidator RequiredFieldValidator50;

	protected CheckBox ChkEditComp;

	protected TextBox txtEditPANNo;

	protected RequiredFieldValidator RequiredFieldValidator54;

	protected TextBox txtPrefixEdit;

	protected RequiredFieldValidator RequiredFieldValidator56;

	protected TextBox txtupMobileNo;

	protected RequiredFieldValidator RequiredFieldValidator57;

	protected TextBox txtupPassword;

	protected RequiredFieldValidator RequiredFieldValidator58;

	protected TextBox txtMailServerIpEdit;

	protected RequiredFieldValidator ReqMailServerIPedit;

	protected TabPanel Edit;

	protected LinkButton linkAddRoles;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int gbselindex;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			lblImageUploadEdit.Text = "";
			if (!base.IsPostBack)
			{
				sqlConnection.Open();
				fun.dropdownCompany(DropDownEditCompanyName);
				fun.dropdownCountry(DropDownRegdCountry, DropDownRegdState);
				fun.dropdownCountry(DropDownPlntCnt, DropDownPlntSta);
				fun.dropdownCountry(EditDropDownRegdCountry, EditDropDownRegdState);
				fun.dropdownCountry(EditDropDownPlntCountry, EditDropDownPlntState);
			}
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			int num = 0;
			int num2 = 0;
			string text = fun.FromDate(txtFDate.Text);
			string text2 = fun.ToDate(txtTDate.Text);
			string text3 = fun.fYear(txtFDate.Text);
			string text4 = fun.tYear(txtTDate.Text);
			string text5 = text3 + text4;
			int num3 = 0;
			string text6 = "";
			string text7 = "";
			if (FileUpload1.PostedFile == null)
			{
				return;
			}
			int contentLength = FileUpload1.PostedFile.ContentLength;
			System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
			int height = image.Height;
			int width = image.Width;
			int num4 = 135;
			height = 62;
			width = num4;
			Bitmap bitmap = new Bitmap(image, width, height);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Jpeg);
			memoryStream.Position = 0L;
			byte[] array = new byte[contentLength];
			memoryStream.Read(array, 0, contentLength);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num5 = 0;
			if (ChknewDefaultComp.Checked)
			{
				num5 = 1;
				string cmdText = fun.update("tblCompany_master", "DefaultComp=0", "DefaultComp=1");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
			int num6 = 2;
			int num7 = num6 + Convert.ToInt32(txtItemCodeLimitNew.Text);
			string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(txtPlntEmail.Text) && txtPlntEmail.Text != "" && regex.IsMatch(txtRegdEmail.Text) && txtRegdEmail.Text != "")
			{
				string cmdText2 = fun.insert("tblCompany_master", "SysDate,SysTime,CompanyName,RegdAddress,RegdCity,RegdState,RegdCountry,RegdPinCode,RegdContactNo,RegdFaxNo,RegdEmail,PlantAddress,PlantCity,PlantState,PlantCountry,PlantPinCode,PlantContactNo,PlantFaxNo,PlantEmail,ECCNo,Commissionerate,Range,Division,VAT,CSTNo,PANNo,LogoImage,LogoFileName,Prefix,LicenceNos,DefaultComp,ServerIp,ItemCodeLimit,MobileNo,Password,ErpSysmail,MailServerIp", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + txtCompanyName.Text + "','" + txtRegdNewAdd.Text + "','" + DropDownRegdCity.SelectedValue + "','" + DropDownRegdState.SelectedValue + "','" + DropDownRegdCountry.SelectedValue + "','" + txtRegdPinCode.Text + "','" + txtRegdContactNo.Text + "','" + txtRegdFaxNo.Text + "','" + txtRegdEmail.Text + "','" + txtPlntAdd.Text + "','" + DropDownPlntCity.SelectedValue + "','" + DropDownPlntSta.SelectedValue + "','" + DropDownPlntCnt.SelectedValue + "','" + txtPlntPincode.Text + "','" + txtPlantContNo.Text + "','" + txtPlntFax.Text + "','" + txtPlntEmail.Text + "','" + txtEccNo.Text + "','" + txtComm.Text + "','" + txtRange.Text + "','" + txtDiv.Text + "','" + txtVat.Text + "','" + txtCst.Text + "','" + txtPANNo.Text + "',@pic,'" + fileNameWithoutExtension + "','" + txtPrefix.Text + "','" + txtLicenceNo.Text + "','" + num5 + "','" + txtIpNew.Text + "','" + num7 + "','" + txtMobileNo.Text + "','" + txtPassword.Text + "','" + txterpsysmail.Text + "','" + txtMailServerIpEdit.Text + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand2.Parameters.AddWithValue("@pic", array);
				sqlCommand2.ExecuteNonQuery();
			}
			string cmdText3 = fun.select1("CompId,Prefix", "tblCompany_master Order By CompId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblCompany_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
				text7 = dataSet.Tables[0].Rows[0][1].ToString() + "0001";
			}
			string cmdText4 = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + num3 + "' and FinYear='" + text5 + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
			DataSet dataSet2 = new DataSet();
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2, "tblFinancial_master");
			if (dataSet2.Tables[0].Rows.Count == 0)
			{
				if (text != "" && text2 != "")
				{
					string cmdText5 = fun.insert("tblFinancial_master", "SysDate,SysTime,SessionId,CompId,FinYearFrom,FinYearTo,FinYear", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + text7.ToString() + "','" + num3 + "','" + text.ToString() + "','" + text2.ToString() + "','" + text5.ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Record Already Inserted";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
			}
			string cmdText6 = fun.insert("tblHR_Offer_Master", "EmployeeName,StaffType", "'Erp System',1");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
			sqlCommand4.ExecuteNonQuery();
			string cmdText7 = fun.select("OfferId,EmployeeName", "tblHR_Offer_Master", "EmployeeName='Erp System' order By OfferId Desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText7, sqlConnection);
			DataSet dataSet3 = new DataSet();
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3, "tblHR_Offer_Master");
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				num = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0]);
				text6 = dataSet3.Tables[0].Rows[0][1].ToString();
			}
			string cmdText8 = fun.select("FinYearId", "tblFinancial_master", "FinYear='" + text5 + "' AND CompId='" + num3 + "' order By FinYearId Desc");
			SqlCommand selectCommand4 = new SqlCommand(cmdText8, sqlConnection);
			DataSet dataSet4 = new DataSet();
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			sqlDataAdapter4.Fill(dataSet4, "tblFinancial_master");
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				num2 = Convert.ToInt32(dataSet4.Tables[0].Rows[0][0]);
			}
			string text8 = "";
			string cmdText9 = fun.insert("tblHR_OfficeStaff", "OfferId,EmpId,SysDate,SysTime,FinYearId,CompId,SessionId,Title,EmployeeName,ResignationDate,MartialStatus,PhysicallyHandycapped,Gender", "'" + num + "','" + text7 + "','" + currDate + "','" + currTime + "','" + num2 + "','" + num3 + "','" + text7 + "','','" + text6 + "','" + text8 + "','0','0','M'");
			SqlCommand sqlCommand5 = new SqlCommand(cmdText9, sqlConnection);
			sqlCommand5.ExecuteNonQuery();
			string cmdText10 = fun.insert("Room", "Name", "'" + txtPrefix.Text + "'");
			SqlCommand sqlCommand6 = new SqlCommand(cmdText10, sqlConnection);
			sqlCommand6.ExecuteNonQuery();
			string cmdText11 = fun.select1("*", "tblAccess_Master_Clone");
			SqlCommand selectCommand5 = new SqlCommand(cmdText11, sqlConnection);
			DataSet dataSet5 = new DataSet();
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			sqlDataAdapter5.Fill(dataSet5, "tblAccess_Master_Clone");
			for (int i = 0; i < dataSet5.Tables[0].Rows.Count; i++)
			{
				string cmdText12 = fun.insert("tblAccess_Master", "SysDate,SysTime,FinYearId,CompId,SessionId,ModId,SubModId,AccessType,Access,EmpId", "'" + currDate + "','" + currTime + "','" + num2 + "','" + num3 + "','" + text7 + "','" + dataSet5.Tables[0].Rows[i][0].ToString() + "','" + dataSet5.Tables[0].Rows[i][1].ToString() + "','" + dataSet5.Tables[0].Rows[i][2].ToString() + "','" + dataSet5.Tables[0].Rows[i][3].ToString() + "','" + text7 + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText12, sqlConnection);
				sqlCommand7.ExecuteNonQuery();
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void Update_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string text = "";
			HttpPostedFile postedFile = FileUpload2.PostedFile;
			byte[] array = null;
			if (FileUpload2.PostedFile != null)
			{
				Stream inputStream = FileUpload2.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text = Path.GetFileName(postedFile.FileName);
				string cmdText = fun.update("tblCompany_master", "LogoFileName='" + text + "',LogoImage=@Data", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				sqlCommand.ExecuteNonQuery();
			}
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string cmdText2 = fun.select("DefaultComp", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "tblCompany_master");
			int num;
			if (Convert.ToInt32(DS.Tables[0].Rows[0]["DefaultComp"]) == 0)
			{
				if (ChkEditComp.Checked)
				{
					num = 1;
					string cmdText3 = fun.update("tblCompany_master", "DefaultComp=0", "DefaultComp=1");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
				}
				else
				{
					num = 0;
				}
			}
			else
			{
				num = Convert.ToInt32(DS.Tables[0].Rows[0]["DefaultComp"]);
			}
			string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(txtEditPlntEmail.Text) && txtEditPlntEmail.Text != "" && regex.IsMatch(txtEditRegdEmail.Text) && txtEditRegdEmail.Text != "")
			{
				string cmdText4 = fun.update("tblCompany_master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',RegdAddress='" + txtEditRegdAdd.Text + "',RegdCity='" + EditDropDownRegdCity.SelectedValue + "',RegdState='" + EditDropDownRegdState.SelectedValue + "',RegdCountry='" + EditDropDownRegdCountry.SelectedValue + "',RegdPinCode='" + txtEditRegdPinCode.Text + "',RegdContactNo='" + txtEditRegdContactNo.Text + "',RegdFaxNo='" + txtEditRegdFaxNo.Text + "',RegdEmail='" + txtEditRegdEmail.Text + "',PlantAddress='" + txtEditPlntAdd.Text + "',PlantCity='" + EditDropDownPlntCity.SelectedValue + "',PlantState='" + EditDropDownPlntState.SelectedValue + "',PlantCountry='" + EditDropDownPlntCountry.SelectedValue + "',PlantPinCode='" + txtEditPlntPinCode.Text + "',PlantContactNo='" + txtEditPlntContNo.Text + "',PlantFaxNo='" + txtEditPlntFaxNo.Text + "',PlantEmail='" + txtEditPlntEmail.Text + "',ECCNo='" + txtEditEccNo.Text + "',Commissionerate='" + txtEditComm.Text + "',Range='" + txtEditRange.Text + "',Division='" + txtEditDiv.Text + "',VAT='" + txtEditVat.Text + "',CSTNo='" + txtEditCstNo.Text + "',PANNo='" + txtEditPANNo.Text + "',Prefix='" + txtPrefixEdit.Text + "',LicenceNos='" + txtEditLicenceNo.Text + "',DefaultComp='" + num + "',ServerIp='" + txtIpEdit.Text + "',ItemCodeLimit='" + txtItemCodeLimitEdit.Text + "',MobileNo='" + txtupMobileNo.Text + "',Password='" + txtupPassword.Text + "',ErpSysmail='" + txtErpMailEdit.Text + "',MailServerIp='" + txtMailServerIpEdit.Text + "'", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void Delete_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.delete("tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void fillForm()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex != 0)
			{
				sqlConnection.Open();
				string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "company");
				if (DS.Tables[0].Rows.Count > 0)
				{
					ImageButton1.Visible = false;
					FileUpload2.Visible = true;
					if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
					{
						ImageButton1.Visible = true;
						lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
						FileUpload2.Visible = false;
					}
					DS.Tables[0].Rows[0]["CompanyName"].ToString();
					fun.dropdownCountrybyId(EditDropDownRegdCountry, EditDropDownRegdState, "CId='" + DS.Tables[0].Rows[0]["RegdCountry"].ToString() + "'");
					EditDropDownRegdCountry.SelectedIndex = 0;
					fun.dropdownCountry(EditDropDownRegdCountry, EditDropDownRegdState);
					fun.dropdownState(EditDropDownRegdState, EditDropDownRegdCity, EditDropDownRegdCountry);
					fun.dropdownStatebyId(EditDropDownRegdState, "CId='" + DS.Tables[0].Rows[0]["RegdCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["RegdState"].ToString() + "'");
					EditDropDownRegdState.SelectedValue = DS.Tables[0].Rows[0]["RegdState"].ToString();
					fun.dropdownCity(EditDropDownRegdCity, EditDropDownRegdState);
					fun.dropdownCitybyId(EditDropDownRegdCity, "SId='" + DS.Tables[0].Rows[0]["RegdState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["RegdCity"].ToString() + "'");
					EditDropDownRegdCity.SelectedValue = DS.Tables[0].Rows[0]["RegdCity"].ToString();
					fun.dropdownCountrybyId(EditDropDownPlntCountry, EditDropDownPlntState, "CId='" + DS.Tables[0].Rows[0]["PlantCountry"].ToString() + "'");
					EditDropDownPlntCountry.SelectedIndex = 0;
					fun.dropdownCountry(EditDropDownPlntCountry, EditDropDownPlntState);
					fun.dropdownState(EditDropDownPlntState, EditDropDownPlntCity, EditDropDownPlntCountry);
					fun.dropdownStatebyId(EditDropDownPlntState, "CId='" + DS.Tables[0].Rows[0]["PlantCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["PlantState"].ToString() + "'");
					EditDropDownPlntState.SelectedValue = DS.Tables[0].Rows[0]["PlantState"].ToString();
					fun.dropdownCity(EditDropDownPlntCity, EditDropDownPlntState);
					fun.dropdownCitybyId(EditDropDownPlntCity, "SId='" + DS.Tables[0].Rows[0]["PlantState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["PlantCity"].ToString() + "'");
					EditDropDownPlntCity.SelectedValue = DS.Tables[0].Rows[0]["PlantCity"].ToString();
					txtItemCodeLimitEdit.Text = DS.Tables[0].Rows[0]["ItemCodeLimit"].ToString();
					txtEditRegdAdd.Text = DS.Tables[0].Rows[0]["RegdAddress"].ToString();
					txtEditRegdPinCode.Text = DS.Tables[0].Rows[0]["RegdPinCode"].ToString();
					txtEditRegdFaxNo.Text = DS.Tables[0].Rows[0]["RegdFaxNo"].ToString();
					txtEditRegdContactNo.Text = DS.Tables[0].Rows[0]["RegdContactNo"].ToString();
					txtEditRegdEmail.Text = DS.Tables[0].Rows[0]["RegdEmail"].ToString();
					txtEditPlntAdd.Text = DS.Tables[0].Rows[0]["PlantAddress"].ToString();
					txtEditPlntPinCode.Text = DS.Tables[0].Rows[0]["PlantPinCode"].ToString();
					txtEditPlntFaxNo.Text = DS.Tables[0].Rows[0]["PlantFaxNo"].ToString();
					txtEditPlntContNo.Text = DS.Tables[0].Rows[0]["PlantContactNo"].ToString();
					txtEditPlntEmail.Text = DS.Tables[0].Rows[0]["PlantEmail"].ToString();
					txtEditEccNo.Text = DS.Tables[0].Rows[0]["ECCNO"].ToString();
					txtEditDiv.Text = DS.Tables[0].Rows[0]["Division"].ToString();
					txtPrefixEdit.Text = DS.Tables[0].Rows[0]["Prefix"].ToString();
					txtEditLicenceNo.Text = DS.Tables[0].Rows[0]["LicenceNos"].ToString();
					txtEditComm.Text = DS.Tables[0].Rows[0]["Commissionerate"].ToString();
					txtEditRange.Text = DS.Tables[0].Rows[0]["Range"].ToString();
					txtEditVat.Text = DS.Tables[0].Rows[0]["VAT"].ToString();
					txtEditCstNo.Text = DS.Tables[0].Rows[0]["CSTNo"].ToString();
					txtEditPANNo.Text = DS.Tables[0].Rows[0]["PANNo"].ToString();
					txtIpEdit.Text = DS.Tables[0].Rows[0]["ServerIp"].ToString();
					txtPrefixEdit.Text = DS.Tables[0].Rows[0]["Prefix"].ToString();
					txtupMobileNo.Text = DS.Tables[0].Rows[0]["MobileNo"].ToString();
					txtupPassword.Text = DS.Tables[0].Rows[0]["Password"].ToString();
					txtMailServerIpEdit.Text = DS.Tables[0].Rows[0]["MailServerIp"].ToString();
					txtErpMailEdit.Text = DS.Tables[0].Rows[0]["ErpSysmail"].ToString();
				}
				TabContainer1.ActiveTabIndex = 1;
			}
			else
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void DropDownEditCompanyName_SelectedIndexChanged(object sender, EventArgs e)
	{
		fillForm();
	}

	protected void DropDownRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownRegdCountry.SelectedValue != "Select")
		{
			fun.dropdownState(DropDownRegdState, DropDownRegdCity, DropDownRegdCountry);
		}
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void DropDownRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownRegdState.SelectedValue != "Select")
		{
			fun.dropdownCity(DropDownRegdCity, DropDownRegdState);
		}
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void DropDownRegdCity_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void DropDownPlntCnt_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownPlntCnt.SelectedValue != "Select")
		{
			fun.dropdownState(DropDownPlntSta, DropDownPlntCity, DropDownPlntCnt);
		}
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void DropDownPlntSta_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownPlntSta.SelectedValue != "Select")
		{
			fun.dropdownCity(DropDownPlntCity, DropDownPlntSta);
		}
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void DropDownPlntCity_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void EditDropDownRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex != 0)
			{
				sqlConnection.Open();
				string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "company");
				if (DS.Tables[0].Rows.Count > 0)
				{
					ImageButton1.Visible = false;
					FileUpload2.Visible = true;
					if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
					{
						ImageButton1.Visible = true;
						lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
						FileUpload2.Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		if (EditDropDownRegdCountry.SelectedValue != "Select")
		{
			fun.dropdownState(EditDropDownRegdState, EditDropDownRegdCity, EditDropDownRegdCountry);
		}
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void EditDropDownRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex != 0)
			{
				sqlConnection.Open();
				string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "company");
				if (DS.Tables[0].Rows.Count > 0)
				{
					ImageButton1.Visible = false;
					FileUpload2.Visible = true;
					if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
					{
						ImageButton1.Visible = true;
						lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
						FileUpload2.Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		if (EditDropDownRegdState.SelectedValue != "Select")
		{
			fun.dropdownCity(EditDropDownRegdCity, EditDropDownRegdState);
		}
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void EditDropDownPlntCnt_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex != 0)
			{
				sqlConnection.Open();
				string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "company");
				if (DS.Tables[0].Rows.Count > 0)
				{
					ImageButton1.Visible = false;
					FileUpload2.Visible = true;
					if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
					{
						ImageButton1.Visible = true;
						lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
						FileUpload2.Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		if (EditDropDownPlntCountry.SelectedValue != "Select")
		{
			fun.dropdownState(EditDropDownPlntState, EditDropDownPlntCity, EditDropDownPlntCountry);
		}
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void EditDropDownPlntSta_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex != 0)
			{
				sqlConnection.Open();
				string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "company");
				if (DS.Tables[0].Rows.Count > 0)
				{
					ImageButton1.Visible = false;
					FileUpload2.Visible = true;
					if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
					{
						ImageButton1.Visible = true;
						lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
						FileUpload2.Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		if (EditDropDownPlntState.SelectedValue != "State")
		{
			fun.dropdownCity(EditDropDownPlntCity, EditDropDownPlntState);
		}
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Admin/Menu.aspx");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblCompany_master", "LogoFileName=NULL,LogoImage=NULL", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void EditDropDownRegdCity_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex == 0)
			{
				return;
			}
			sqlConnection.Open();
			string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "company");
			if (DS.Tables[0].Rows.Count > 0)
			{
				ImageButton1.Visible = false;
				FileUpload2.Visible = true;
				if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
				{
					ImageButton1.Visible = true;
					lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
					FileUpload2.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void EditDropDownPlntCity_SelectedIndexChanged(object sender, EventArgs e)
	{
		gbselindex = DropDownEditCompanyName.SelectedIndex;
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DropDownEditCompanyName.SelectedIndex == 0)
			{
				return;
			}
			sqlConnection.Open();
			string cmdText = fun.select("*", "tblCompany_master", "CompId='" + DropDownEditCompanyName.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "company");
			if (DS.Tables[0].Rows.Count > 0)
			{
				ImageButton1.Visible = false;
				FileUpload2.Visible = true;
				if (DS.Tables[0].Rows[0]["LogoFileName"].ToString() != "" && DS.Tables[0].Rows[0]["LogoFileName"] != DBNull.Value)
				{
					ImageButton1.Visible = true;
					lblImageUploadEdit.Text = DS.Tables[0].Rows[0]["LogoFileName"].ToString();
					FileUpload2.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void linkAddRoles_Click(object sender, EventArgs e)
	{
	}
}

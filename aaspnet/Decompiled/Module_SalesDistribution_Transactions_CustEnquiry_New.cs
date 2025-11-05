using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_CustEnquiry_New : Page, IRequiresSessionState
{
	protected RadioButton RadioBtnNew;

	protected TextBox txtNewnewCustName;

	protected RequiredFieldValidator ReqCustNM;

	protected RadioButton RadioBtnExisting;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected RequiredFieldValidator ReqExistCust;

	protected Button btnView;

	protected TextBox txtNewRegdAdd;

	protected RequiredFieldValidator ReqRegdAdd;

	protected TextBox txtNewWorkAdd;

	protected RequiredFieldValidator ReqWorkAdd;

	protected TextBox txtNewMaterialDelAdd;

	protected RequiredFieldValidator ReqMateAdd;

	protected DropDownList DDListNewRegdCountry;

	protected RequiredFieldValidator ReqRegdCountry;

	protected DropDownList DDListNewWorkCountry;

	protected RequiredFieldValidator ReqWorkCountry;

	protected DropDownList DDListNewMaterialDelCountry;

	protected RequiredFieldValidator ReqMateCountry;

	protected DropDownList DDListNewRegdState;

	protected RequiredFieldValidator ReqRegdState;

	protected DropDownList DDListNewWorkState;

	protected RequiredFieldValidator ReqWorkState;

	protected DropDownList DDListNewMaterialDelState;

	protected RequiredFieldValidator ReqMateState;

	protected DropDownList DDListNewRegdCity;

	protected RequiredFieldValidator ReqRegdCity;

	protected DropDownList DDListNewWorkCity;

	protected RequiredFieldValidator ReqWorkCity;

	protected DropDownList DDListNewMaterialDelCity;

	protected RequiredFieldValidator ReqMateCity;

	protected TextBox txtNewRegdPinNo;

	protected RequiredFieldValidator ReqRegdPin;

	protected TextBox txtNewWorkPinNo;

	protected RequiredFieldValidator ReqWorkPin;

	protected TextBox txtNewMaterialDelPinNo;

	protected RequiredFieldValidator ReqMatePin;

	protected TextBox txtNewRegdContactNo;

	protected RequiredFieldValidator ReqRegdContNo;

	protected TextBox txtNewWorkContactNo;

	protected RequiredFieldValidator ReqWorkContNo;

	protected TextBox txtNewMaterialDelContactNo;

	protected RequiredFieldValidator ReqMateContNo;

	protected TextBox txtNewRegdFaxNo;

	protected RequiredFieldValidator ReqRegdFax;

	protected TextBox txtNewWorkFaxNo;

	protected RequiredFieldValidator ReqWorkFax;

	protected TextBox txtNewMaterialDelFaxNo;

	protected RequiredFieldValidator ReqMateFaxNo;

	protected TextBox txtNewContactPerson;

	protected RequiredFieldValidator ReqContPerson;

	protected TextBox txtNewEmail;

	protected RequiredFieldValidator ReqEmail;

	protected RegularExpressionValidator RegEmail;

	protected TextBox txtNewContactNo;

	protected RequiredFieldValidator ReqContNo;

	protected TextBox txtNewJuridictionCode;

	protected RequiredFieldValidator ReqJuridCode;

	protected TextBox txtNewEccNo;

	protected RequiredFieldValidator ReqECCNO;

	protected TextBox txtNewRange;

	protected RequiredFieldValidator ReqRange;

	protected TextBox txtNewCommissionurate;

	protected RequiredFieldValidator ReqCommisunurate;

	protected TextBox txtNewDivn;

	protected RequiredFieldValidator ReqDivn;

	protected TextBox txtNewPanNo;

	protected RequiredFieldValidator ReqPanNo;

	protected TextBox txtNewTinVatNo;

	protected RequiredFieldValidator ReqTinVat;

	protected TextBox txtNewTinCstNo;

	protected RequiredFieldValidator ReqTinCSt;

	protected TextBox txtNewTdsCode;

	protected RequiredFieldValidator ReqTDS;

	protected TextBox txtNewEnquiryFor;

	protected RequiredFieldValidator ReqEnqFor;

	protected TextBox txtNewRemark;

	protected TabPanel TabPanel1;

	protected FileUpload FileUpload1;

	protected RequiredFieldValidator ReqFileUpload;

	protected Button Button1;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected Button Submit;

	protected Button btncancel;

	protected Label lblmsg;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string strConnString = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private int EnqId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	private bool InsertUpdateData(SqlCommand cmd)
	{
		cmd.CommandType = CommandType.Text;
		cmd.Connection = con;
		try
		{
			con.Open();
			cmd.ExecuteNonQuery();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			con.Close();
			con.Dispose();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			strConnString = fun.Connection();
			con = new SqlConnection(strConnString);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
				fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
				fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);
				if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
				{
					string empty = string.Empty;
					empty = base.Request.QueryString["msg"];
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (RadioBtnExisting.Checked)
			{
				ReqExistCust.Visible = true;
			}
			else if (RadioBtnNew.Checked)
			{
				ReqCustNM.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		if (RadioBtnNew.Checked)
		{
			try
			{
				con.Open();
				if (txtNewnewCustName.Text != "" && txtNewRegdAdd.Text != "" && DDListNewRegdCountry.SelectedValue != "Select" && DDListNewRegdState.SelectedValue != "Select" && DDListNewRegdCity.SelectedValue != "Select" && txtNewRegdPinNo.Text != "" && txtNewRegdContactNo.Text != "" && txtNewRegdFaxNo.Text != "" && txtNewWorkAdd.Text != "" && DDListNewWorkCountry.SelectedValue != "Select" && DDListNewWorkState.SelectedValue != "" && DDListNewWorkCity.SelectedValue != "Select" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && DDListNewMaterialDelCountry.SelectedValue != "Select" && DDListNewMaterialDelState.SelectedValue != "Select" && DDListNewMaterialDelCity.SelectedValue != "Select" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && fun.EmailValidation(txtNewEmail.Text) && txtNewEmail.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text != "" && txtNewEnquiryFor.Text != "")
				{
					string cmdText = fun.insert("SD_Cust_Enquiry_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark,EnquiryFor,Flag", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + txtNewnewCustName.Text.ToUpper() + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "','" + txtNewEnquiryFor.Text + "',0");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					num++;
				}
				string cmdText2 = fun.select("EnqId", "SD_Cust_Enquiry_Master", " CompId='" + CompId + "' Order By EnqId Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_Enquiry_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					EnqId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EnqId"]);
				}
				string cmdText3 = fun.select("*", "tblFile_Attachment", "CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND SessionId = '" + sId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblFile_Attachment");
				sqlCommand2.ExecuteNonQuery();
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText4 = fun.insert("SD_Cust_Enquiry_Attach_Master", "EnqId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", string.Concat(EnqId, ",'", Convert.ToInt32(dataSet2.Tables[0].Rows[i]["CompId"]), "','", dataSet2.Tables[0].Rows[i]["SessionId"].ToString(), "','", Convert.ToInt32(dataSet2.Tables[0].Rows[i]["FinYearId"]), "','", dataSet2.Tables[0].Rows[i]["FileName"], "','", dataSet2.Tables[0].Rows[i]["FileSize"], "','", dataSet2.Tables[0].Rows[i]["ContentType"], "',@TransStr"));
						using SqlCommand sqlCommand3 = new SqlCommand(cmdText4, con);
						sqlCommand3.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = dataSet2.Tables[0].Rows[i]["FileData"];
						sqlCommand3.ExecuteNonQuery();
					}
					string cmdText5 = fun.delete("tblFile_Attachment", "CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND SessionId = '" + sId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText5, con);
					sqlCommand4.ExecuteNonQuery();
					num2++;
				}
				if (num > 0 && (num > 0 || num2 > 0))
				{
					Page.Response.Redirect("CustEnquiry_New.aspx?msg=Enquiry is generated&ModId=2&SubModId=10");
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
			finally
			{
				con.Close();
			}
		}
		if (!RadioBtnExisting.Checked)
		{
			return;
		}
		try
		{
			con.Open();
			string code = fun.getCode(txtNewCustomerName.Text);
			string cmdText6 = fun.select("CustomerId", "SD_Cust_Master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText6, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter3.Fill(DS, "SD_Cust_master");
			string text = DS.Tables[0].Rows[0][0].ToString();
			string text2 = txtNewCustomerName.Text;
			string[] array = text2.Split('[');
			string text3 = array[0];
			if (txtNewCustomerName.Text != "" && txtNewRegdAdd.Text != "" && DDListNewRegdCountry.SelectedValue != "Select" && DDListNewRegdState.SelectedValue != "Select" && DDListNewRegdCity.SelectedValue != "Select" && txtNewRegdPinNo.Text != "" && txtNewRegdContactNo.Text != "" && txtNewRegdFaxNo.Text != "" && txtNewWorkAdd.Text != "" && DDListNewWorkCountry.SelectedValue != "Select" && DDListNewWorkState.SelectedValue != "" && DDListNewWorkCity.SelectedValue != "Select" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && DDListNewMaterialDelCountry.SelectedValue != "Select" && DDListNewMaterialDelState.SelectedValue != "Select" && DDListNewMaterialDelCity.SelectedValue != "Select" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && fun.EmailValidation(txtNewEmail.Text) && txtNewEmail.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text != "" && txtNewEnquiryFor.Text != "" && DS.Tables[0].Rows.Count > 0)
			{
				string cmdText7 = fun.insert("SD_Cust_Enquiry_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark,EnquiryFor,Flag", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + text + "','" + text3 + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "','" + txtNewEnquiryFor.Text + "',1");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText7, con);
				sqlCommand5.ExecuteNonQuery();
				num++;
			}
			string cmdText8 = fun.select("EnqId", "SD_Cust_Enquiry_Master", " CompId='" + CompId + "' Order By EnqId Desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText8, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter4.Fill(dataSet3, "SD_Cust_Enquiry_Master");
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				EnqId = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["EnqId"]);
			}
			string cmdText9 = fun.select("*", "tblFile_Attachment", "CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND SessionId = '" + sId + "'");
			SqlCommand sqlCommand6 = new SqlCommand(cmdText9, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand6);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter5.Fill(dataSet4, "tblFile_Attachment");
			sqlCommand6.ExecuteNonQuery();
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
				{
					string cmdText10 = fun.insert("SD_Cust_Enquiry_Attach_Master", "EnqId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", string.Concat(EnqId, ",'", Convert.ToInt32(dataSet4.Tables[0].Rows[j]["CompId"]), "','", dataSet4.Tables[0].Rows[j]["SessionId"].ToString(), "','", Convert.ToInt32(dataSet4.Tables[0].Rows[j]["FinYearId"]), "','", dataSet4.Tables[0].Rows[j]["FileName"], "','", dataSet4.Tables[0].Rows[j]["FileSize"], "','", dataSet4.Tables[0].Rows[j]["ContentType"], "',@TransStr"));
					using SqlCommand sqlCommand7 = new SqlCommand(cmdText10, con);
					sqlCommand7.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = dataSet4.Tables[0].Rows[j]["FileData"];
					sqlCommand7.ExecuteNonQuery();
				}
				string cmdText11 = fun.delete("tblFile_Attachment", "CompId ='" + CompId + "' AND FinYearId ='" + FinYearId + "' AND SessionId = '" + sId + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText11, con);
				sqlCommand8.ExecuteNonQuery();
				num2++;
			}
			if (num > 0 && (num > 0 || num2 > 0))
			{
				Page.Response.Redirect("CustEnquiry_New.aspx?msg=Enquiry is generated&ModId=2&SubModId=10");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void DDListNewRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
	}

	protected void DDListNewRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
	}

	protected void DDListNewWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewWorkState, DDListNewWorkCity, DDListNewWorkCountry);
	}

	protected void DDListNewWorkState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListNewWorkCity, DDListNewWorkState);
	}

	protected void DDListNewMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewMaterialDelState, DDListNewMaterialDelCity, DDListNewMaterialDelCountry);
	}

	protected void DDListNewMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListNewMaterialDelCity, DDListNewMaterialDelState);
	}

	protected void btnView_Click(object sender, EventArgs e)
	{
		try
		{
			if (RadioBtnExisting.Checked)
			{
				DataSet dataSet = new DataSet();
				string code = fun.getCode(txtNewCustomerName.Text);
				string cmdText = "Select * from SD_Cust_master where CustomerId='" + code + "' And CompId='" + CompId + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					txtNewRegdAdd.Text = dataSet.Tables[0].Rows[0]["RegdAddress"].ToString();
					fun.dropdownCountrybyId(DDListNewRegdCountry, DDListNewRegdState, "CId='" + dataSet.Tables[0].Rows[0]["RegdCountry"].ToString() + "'");
					DDListNewRegdCountry.SelectedValue = dataSet.Tables[0].Rows[0]["RegdCountry"].ToString();
					fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
					fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
					fun.dropdownStatebyId(DDListNewRegdState, "CId='" + dataSet.Tables[0].Rows[0]["RegdCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["RegdState"].ToString() + "'");
					DDListNewRegdState.SelectedValue = dataSet.Tables[0].Rows[0]["RegdState"].ToString();
					fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
					fun.dropdownCitybyId(DDListNewRegdCity, "SId='" + dataSet.Tables[0].Rows[0]["RegdState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["RegdCity"].ToString() + "'");
					DDListNewRegdCity.SelectedValue = dataSet.Tables[0].Rows[0]["RegdCity"].ToString();
					txtNewRegdPinNo.Text = dataSet.Tables[0].Rows[0]["RegdPinNo"].ToString();
					txtNewRegdContactNo.Text = dataSet.Tables[0].Rows[0]["RegdContactNo"].ToString();
					txtNewRegdFaxNo.Text = dataSet.Tables[0].Rows[0]["RegdFaxNo"].ToString();
					txtNewWorkAdd.Text = dataSet.Tables[0].Rows[0]["WorkAddress"].ToString();
					fun.dropdownCountrybyId(DDListNewWorkCountry, DDListNewWorkState, "CId='" + dataSet.Tables[0].Rows[0]["WorkCountry"].ToString() + "'");
					DDListNewWorkCountry.SelectedValue = dataSet.Tables[0].Rows[0]["WorkCountry"].ToString();
					fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
					fun.dropdownState(DDListNewWorkState, DDListNewWorkCity, DDListNewWorkCountry);
					fun.dropdownStatebyId(DDListNewWorkState, "CId='" + dataSet.Tables[0].Rows[0]["WorkCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["WorkState"].ToString() + "'");
					DDListNewWorkState.SelectedValue = dataSet.Tables[0].Rows[0]["WorkState"].ToString();
					fun.dropdownCity(DDListNewWorkCity, DDListNewWorkState);
					fun.dropdownCitybyId(DDListNewWorkCity, "SId='" + dataSet.Tables[0].Rows[0]["WorkState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["WorkCity"].ToString() + "'");
					DDListNewWorkCity.SelectedValue = dataSet.Tables[0].Rows[0]["WorkCity"].ToString();
					txtNewWorkPinNo.Text = dataSet.Tables[0].Rows[0]["WorkPinNo"].ToString();
					txtNewWorkContactNo.Text = dataSet.Tables[0].Rows[0]["WorkContactNo"].ToString();
					txtNewWorkFaxNo.Text = dataSet.Tables[0].Rows[0]["WorkFaxNo"].ToString();
					txtNewMaterialDelAdd.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
					fun.dropdownCountrybyId(DDListNewMaterialDelCountry, DDListNewMaterialDelState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
					DDListNewMaterialDelCountry.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
					fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);
					fun.dropdownState(DDListNewMaterialDelState, DDListNewMaterialDelCity, DDListNewMaterialDelCountry);
					fun.dropdownStatebyId(DDListNewMaterialDelState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
					DDListNewMaterialDelState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
					fun.dropdownCity(DDListNewMaterialDelCity, DDListNewMaterialDelState);
					fun.dropdownCitybyId(DDListNewMaterialDelCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
					DDListNewMaterialDelCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
					txtNewMaterialDelPinNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelPinNo"].ToString();
					txtNewMaterialDelContactNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
					txtNewMaterialDelFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
					txtNewContactPerson.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
					txtNewJuridictionCode.Text = dataSet.Tables[0].Rows[0]["JuridictionCode"].ToString();
					txtNewCommissionurate.Text = dataSet.Tables[0].Rows[0]["Commissionurate"].ToString();
					txtNewTinVatNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
					txtNewEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
					txtNewEccNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
					txtNewDivn.Text = dataSet.Tables[0].Rows[0]["Divn"].ToString();
					txtNewTinCstNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
					txtNewContactNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
					txtNewRange.Text = dataSet.Tables[0].Rows[0]["Range"].ToString();
					txtNewPanNo.Text = dataSet.Tables[0].Rows[0]["PanNo"].ToString();
					txtNewTdsCode.Text = dataSet.Tables[0].Rows[0]["TDSCode"].ToString();
				}
				Submit.Enabled = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadioBtnNew_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			txtNewCustomerName.Enabled = false;
			txtNewCustomerName.Text = "";
			txtNewnewCustName.Enabled = true;
			btnView.Enabled = false;
			Submit.Enabled = true;
			if (RadioBtnNew.Checked)
			{
				ReqExistCust.Visible = false;
				ReqCustNM.Visible = true;
			}
			if (!RadioBtnExisting.Checked)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadioBtnExisting_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			txtNewCustomerName.Enabled = true;
			txtNewnewCustName.Enabled = false;
			txtNewnewCustName.Text = "";
			btnView.Enabled = true;
			if (RadioBtnExisting.Checked)
			{
				ReqCustNM.Visible = false;
				ReqExistCust.Visible = true;
			}
			Submit.Enabled = false;
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_Master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_Enquiry_Master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile != null)
			{
				Stream inputStream = FileUpload1.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text = Path.GetFileName(postedFile.FileName);
			}
			if (text != "")
			{
				string cmdText = fun.insert("tblFile_Attachment", "SessionId,CompId,FinYearId,FileName,FileSize,ContentType,FileData", "'" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + text + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				fun.InsertUpdateData(sqlCommand);
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Dashboard.aspx?ModId=2&SubModId=10");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink hyperLink = (HyperLink)e.Row.Cells[4].Controls[0];
				hyperLink.Attributes.Add("onclick", "return confirmation();");
			}
		}
		catch (Exception)
		{
		}
	}
}

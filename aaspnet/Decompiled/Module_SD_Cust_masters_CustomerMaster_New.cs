using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SD_Cust_masters_CustomerMaster_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected TextBox txtNewCustName;

	protected RequiredFieldValidator ReqCustNM;

	protected Button Submit;

	protected TextBox txtNewRegdAdd;

	protected RequiredFieldValidator ReqRegdAdd;

	protected TextBox txtNewWorkAdd;

	protected RequiredFieldValidator ReqworkAdd;

	protected TextBox txtNewMaterialDelAdd;

	protected RequiredFieldValidator ReqMaterialAdd;

	protected DropDownList DDListNewRegdCountry;

	protected RequiredFieldValidator ReqRegdCountry;

	protected DropDownList DDListNewWorkCountry;

	protected RequiredFieldValidator ReqworkCountry;

	protected DropDownList DDListNewMaterialDelCountry;

	protected RequiredFieldValidator ReqMaterialCountry;

	protected DropDownList DDListNewRegdState;

	protected RequiredFieldValidator ReqRegdState;

	protected DropDownList DDListNewWorkState;

	protected RequiredFieldValidator ReqWorkState;

	protected DropDownList DDListNewMaterialDelState;

	protected RequiredFieldValidator ReqMaterialState;

	protected DropDownList DDListNewRegdCity;

	protected RequiredFieldValidator ReqRegdCity;

	protected DropDownList DDListNewWorkCity;

	protected RequiredFieldValidator ReqWorkCity;

	protected DropDownList DDListNewMaterialDelCity;

	protected RequiredFieldValidator ReqMaterialCity;

	protected TextBox txtNewRegdPinNo;

	protected RequiredFieldValidator ReqRegdPin;

	protected TextBox txtNewWorkPinNo;

	protected RequiredFieldValidator ReqWorkPin;

	protected TextBox txtNewMaterialDelPinNo;

	protected RequiredFieldValidator ReqMaterialPin;

	protected TextBox txtNewRegdContactNo;

	protected RequiredFieldValidator ReqRegdContact;

	protected TextBox txtNewWorkContactNo;

	protected RequiredFieldValidator ReqWorkContact;

	protected TextBox txtNewMaterialDelContactNo;

	protected RequiredFieldValidator ReqMaterialContact;

	protected TextBox txtNewRegdFaxNo;

	protected RequiredFieldValidator ReqRegdFax;

	protected TextBox txtNewWorkFaxNo;

	protected RequiredFieldValidator ReqWorkFax;

	protected TextBox txtNewMaterialDelFaxNo;

	protected RequiredFieldValidator ReqNMaterialFax;

	protected TextBox txtNewContactPerson;

	protected RequiredFieldValidator ReqContPerson;

	protected TextBox txtNewEmail;

	protected RequiredFieldValidator ReqEmail;

	protected RegularExpressionValidator RegularEmail;

	protected TextBox txtNewContactNo;

	protected RequiredFieldValidator ReqContact;

	protected TextBox txtNewJuridictionCode;

	protected RequiredFieldValidator ReqJuridCode;

	protected TextBox txtNewEccNo;

	protected RequiredFieldValidator ReqECCNO;

	protected TextBox txtNewRange;

	protected RequiredFieldValidator ReqRange;

	protected TextBox txtNewCommissionurate;

	protected RequiredFieldValidator ReqCommissinurate;

	protected TextBox txtNewDivn;

	protected RequiredFieldValidator ReqDivn;

	protected TextBox txtNewPanNo;

	protected RequiredFieldValidator ReqPanNo;

	protected TextBox txtNewTinVatNo;

	protected RequiredFieldValidator ReqTinVat;

	protected TextBox txtNewTinCstNo;

	protected RequiredFieldValidator ReqTinCST;

	protected TextBox txtNewTdsCode;

	protected RequiredFieldValidator ReqTDS;

	protected TextBox txtNewRemark;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		sId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		if (!base.IsPostBack)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				string empty = string.Empty;
				empty = base.Request.QueryString["msg"].ToString();
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
			fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
			fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);
		}
	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string custChar = fun.getCustChar(txtNewCustName.Text);
			string cmdText = fun.select("CustomerId", "SD_Cust_master", "CustomerName like '" + custChar + "%' And CompId='" + CompId + "' order by CustomerId desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "SD_Cust_master");
			string text2;
			if (DS.Tables[0].Rows.Count > 0)
			{
				string text = DS.Tables[0].Rows[0][0].ToString();
				string value = text.Substring(1);
				text2 = custChar + (Convert.ToInt32(value) + 1).ToString("D3");
			}
			else
			{
				text2 = custChar + "001";
			}
			string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(txtNewEmail.Text) && txtNewEmail.Text != "" && currDate.ToString() != "" && currTime.ToString() != "" && sId.ToString() != "" && CompId != 0 && FinYearId != 0 && text2.ToString() != "" && txtNewCustName.Text != "" && txtNewRegdAdd.Text != "" && DDListNewRegdCountry.SelectedValue != "Select" && DDListNewRegdState.SelectedValue != "Select" && DDListNewRegdCity.SelectedValue != "Select" && txtNewRegdPinNo.Text != "" && txtNewRegdContactNo.Text != "" && txtNewRegdFaxNo.Text != "" && txtNewWorkAdd.Text != "" && DDListNewWorkCountry.SelectedValue != "Select" && DDListNewWorkState.SelectedValue != "Select" && DDListNewWorkCity.SelectedValue != "Select" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && DDListNewMaterialDelCountry.SelectedValue != "Select" && DDListNewMaterialDelState.SelectedValue != "Select" && DDListNewMaterialDelCity.SelectedValue != "Select" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text != "")
			{
				string cmdText2 = fun.insert("SD_Cust_master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + text2.ToUpper() + "','" + txtNewCustName.Text.ToUpper() + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				Page.Response.Redirect("CustomerMaster_New.aspx?msg=Customer is registered sucessfuly&ModId=2&SubModId=7");
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

	protected void DDListNewRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
	}

	protected void DDListNewRegdCity_SelectedIndexChanged(object sender, EventArgs e)
	{
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
}

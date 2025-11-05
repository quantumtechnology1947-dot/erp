using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Masters_SupplierMaster_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	protected TextBox txtNewSupplierName;

	protected RequiredFieldValidator ReqSupNM;

	protected Button Submit;

	protected TextBox txtScopeofSupply;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtNewRegdAdd;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtNewWorkAdd;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtNewMaterialDelAdd;

	protected RequiredFieldValidator RequiredFieldValidator4;

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

	protected RequiredFieldValidator ReqWorkCity0;

	protected DropDownList DDListNewMaterialDelCity;

	protected RequiredFieldValidator ReqMaterialCity;

	protected TextBox txtNewRegdPinNo;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtNewWorkPinNo;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtNewMaterialDelPinNo;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtNewRegdContactNo;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtNewWorkContactNo;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtNewMaterialDelContactNo;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected TextBox txtNewRegdFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtNewWorkFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtNewMaterialDelFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected TextBox txtNewContactPerson;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected TextBox txtNewEmail;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtNewContactNo;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected TextBox txtNewJuridictionCode;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected TextBox txtNewEccNo;

	protected RequiredFieldValidator RequiredFieldValidator18;

	protected TextBox txtNewRange;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected TextBox txtNewCommissionurate;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected TextBox txtNewDivn;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected TextBox txtNewPanNo;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected TextBox txtNewTinVatNo;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected TextBox txtNewTinCstNo;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected TextBox txtNewTdsCode;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected RadioButton rbMVAYes;

	protected RadioButton rbMVANo;

	protected RadioButton rbMVIYes;

	protected RadioButton rbMVINo;

	protected TextBox txtBankAccNo;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtBankName;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtBankBranch;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtBankAddress;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected TextBox txtBankAccType;

	protected RequiredFieldValidator RequiredFieldValidator30;

	protected DropDownList DDLServiceCoverage;

	protected Label Label2;

	protected DropDownList DDLPF;

	protected SqlDataSource SqlDataSourcePF;

	protected Label Label3;

	protected DropDownList DDLExcies;

	protected SqlDataSource SqlDataSourceExSer;

	protected Label Label4;

	protected DropDownList DDLVat;

	protected SqlDataSource SqlDataSourceAsh;

	protected CheckBoxList CBLBusinessNature;

	protected Panel Panel1;

	protected CheckBoxList CBLBusinessType;

	protected Panel Panel2;

	protected TextBox txtNewRemark;

	protected RequiredFieldValidator RequiredFieldValidator31;

	protected Label hfBusinessNature;

	protected Label hfBusinessType;

	protected SqlDataSource SqlDataSource3;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
				fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
				fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);
				if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
				{
					string empty = string.Empty;
					empty = base.Request.QueryString["msg"].ToString();
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
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
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string custChar = fun.getCustChar(txtNewSupplierName.Text);
			string cmdText = fun.select("SupplierId", "tblMM_Supplier_master", "SupplierName like '" + custChar + "%' And CompId='" + num + "' order by SupplierId desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "tblMM_Supplier_master");
			string text3;
			if (DS.Tables[0].Rows.Count > 0)
			{
				string text2 = DS.Tables[0].Rows[0][0].ToString();
				string value = text2.Substring(1);
				text3 = custChar + (Convert.ToInt32(value) + 1).ToString("D3");
			}
			else
			{
				text3 = custChar + "001";
			}
			int num3 = 0;
			num3 = (rbMVAYes.Checked ? 1 : 0);
			int num4 = 0;
			num4 = (rbMVIYes.Checked ? 1 : 0);
			if (txtNewSupplierName.Text != "" && txtScopeofSupply.Text != "" && txtNewRegdAdd.Text != "" && txtNewWorkAdd.Text != "" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && txtNewEmail.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text != "" && txtNewRemark.Text != "" && txtBankAccNo.Text != "" && txtBankName.Text != "" && txtBankBranch.Text != "" && txtBankAddress.Text != "" && txtBankAccType.Text != "" && fun.EmailValidation(txtNewEmail.Text))
			{
				string cmdText2 = fun.insert("tblMM_Supplier_master", "SysDate,SysTime,SessionId,CompId,FinYearId,SupplierId,SupplierName,ScopeOfSupply,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark,ModVatApplicable,ModVatInvoice,BankAccNo,BankName,BankBranch,BankAddress,BankAccType,BusinessType,BusinessNature,ServiceCoverage,PF,ExST,VAT", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + text.ToString() + "','" + num + "','" + num2 + "','" + text3.ToUpper() + "','" + txtNewSupplierName.Text.ToUpper() + "','" + txtScopeofSupply.Text + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "','" + num3 + "','" + num4 + "','" + txtBankAccNo.Text + "','" + txtBankName.Text + "','" + txtBankBranch.Text + "','" + txtBankAddress.Text + "','" + txtBankAccType.Text + "','" + hfBusinessType.Text + "','" + hfBusinessNature.Text + "','" + DDLServiceCoverage.SelectedValue + "','" + Convert.ToInt32(DDLPF.SelectedValue) + "','" + Convert.ToInt32(DDLExcies.SelectedValue) + "','" + Convert.ToInt32(DDLVat.SelectedValue) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				Page.Response.Redirect("SupplierMaster_New.aspx?msg=Supplier is registered sucessfuly&ModId=6&SubModId=22");
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

	protected void CBLBusinessNature_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			hfBusinessNature.Text = string.Empty;
			foreach (ListItem item in CBLBusinessNature.Items)
			{
				if (item.Selected)
				{
					Label label = hfBusinessNature;
					label.Text = label.Text + item.Value + ",";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CBLBusinessType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			hfBusinessType.Text = string.Empty;
			foreach (ListItem item in CBLBusinessType.Items)
			{
				if (item.Selected)
				{
					Label label = hfBusinessType;
					label.Text = label.Text + item.Value + ",";
				}
			}
		}
		catch (Exception)
		{
		}
	}
}

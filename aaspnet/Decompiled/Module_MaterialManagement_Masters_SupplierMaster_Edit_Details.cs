using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Masters_SupplierMaster_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int cId;

	protected TextBox txtSupplierName;

	protected RequiredFieldValidator ReqtxtSupplierName;

	protected Label lblSupName;

	protected Label hfSupplierId;

	protected Button Update;

	protected Button Button1;

	protected TextBox txtEditScopeofSupply;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtEditRegdAdd;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtEditWorkAdd;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtEditMaterialDelAdd;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected DropDownList DDListEditRegdCountry;

	protected RequiredFieldValidator ReqRegdCountry;

	protected DropDownList DDListEditWorkCountry;

	protected RequiredFieldValidator ReqworkCountry;

	protected DropDownList DDListEditMaterialDelCountry;

	protected RequiredFieldValidator ReqMaterialCountry;

	protected DropDownList DDListEditRegdState;

	protected RequiredFieldValidator ReqRegdState;

	protected DropDownList DDListEditWorkState;

	protected RequiredFieldValidator ReqWorkState;

	protected DropDownList DDListEditMaterialDelState;

	protected RequiredFieldValidator ReqMaterialState;

	protected DropDownList DDListEditRegdCity;

	protected RequiredFieldValidator ReqRegdCity;

	protected DropDownList DDListEditWorkCity;

	protected RequiredFieldValidator ReqWorkCity0;

	protected DropDownList DDListEditMaterialDelCity;

	protected RequiredFieldValidator ReqMaterialCity;

	protected TextBox txtEditRegdPinNo;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtEditWorkPinNo;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtEditMaterialDelPinNo;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtEditRegdContactNo;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtEditWorkContactNo;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtEditMaterialDelContactNo;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected TextBox txtEditRegdFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtEditWorkFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtEditMaterialDelFaxNo;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected TextBox txtEditContactPerson;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected TextBox txtEditEmail;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected TextBox txtEditContactNo;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtEditJuridictionCode;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected TextBox txtEditEccNo;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected TextBox txtEditRange;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtEditCommissionurate;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected TextBox txtEditDivn;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected TextBox txtEditPanNo;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtEditTinVatNo;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected TextBox txtEditTinCstNo;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected TextBox txtEditTdsCode;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected RadioButton rbMVAYes;

	protected RadioButton rbMVANo;

	protected RadioButton rbMVIYes;

	protected RadioButton rbMVINo;

	protected TextBox txtBankAccNo;

	protected RequiredFieldValidator RequiredFieldValidator18;

	protected TextBox txtBankName;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected TextBox txtBankBranch;

	protected RequiredFieldValidator RequiredFieldValidator30;

	protected TextBox txtBankAddress;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected TextBox txtBankAccType;

	protected RequiredFieldValidator RequiredFieldValidator25;

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

	protected TextBox txtEditRemark;

	protected RequiredFieldValidator RequiredFieldValidator31;

	protected SqlDataSource SqlDataSource3;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			cId = Convert.ToInt32(Session["compid"]);
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + base.Request.QueryString["SupplierId"].ToString() + "' And CompId='" + cId + "'");
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblSupName.Text = dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
			}
			hfSupplierId.Text = base.Request.QueryString["SupplierId"].ToString();
			CustCode = hfSupplierId.Text;
		}
		catch (Exception)
		{
		}
		if (base.IsPostBack)
		{
			return;
		}
		fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
		fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
		fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);
		try
		{
			string connectionString2 = fun.Connection();
			new SqlConnection(connectionString2);
			DataSet dataSet2 = new DataSet();
			string connectionString3 = fun.Connection();
			SqlConnection connection2 = new SqlConnection(connectionString3);
			string cmdText2 = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + CustCode + "'And CompId='" + cId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection2);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2, "tblMM_Supplier_master");
			if (dataSet2.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			txtSupplierName.Text = dataSet2.Tables[0].Rows[0]["SupplierName"].ToString();
			txtEditScopeofSupply.Text = dataSet2.Tables[0].Rows[0]["ScopeOfSupply"].ToString();
			txtEditRegdAdd.Text = dataSet2.Tables[0].Rows[0]["RegdAddress"].ToString();
			fun.dropdownCountrybyId(DDListEditRegdCountry, DDListEditRegdState, "CId='" + dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString() + "'");
			DDListEditRegdCountry.SelectedIndex = 0;
			fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
			DDListEditRegdCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString();
			fun.dropdownState(DDListEditRegdState, DDListEditRegdCity, DDListEditRegdCountry);
			fun.dropdownStatebyId(DDListEditRegdState, "CId='" + dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["RegdState"].ToString() + "'");
			DDListEditRegdState.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdState"].ToString();
			fun.dropdownCity(DDListEditRegdCity, DDListEditRegdState);
			fun.dropdownCitybyId(DDListEditRegdCity, "SId='" + dataSet2.Tables[0].Rows[0]["RegdState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["RegdCity"].ToString() + "'");
			DDListEditRegdCity.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdCity"].ToString();
			txtEditRegdPinNo.Text = dataSet2.Tables[0].Rows[0]["RegdPinNo"].ToString();
			txtEditRegdContactNo.Text = dataSet2.Tables[0].Rows[0]["RegdContactNo"].ToString();
			txtEditRegdFaxNo.Text = dataSet2.Tables[0].Rows[0]["RegdFaxNo"].ToString();
			txtEditWorkAdd.Text = dataSet2.Tables[0].Rows[0]["WorkAddress"].ToString();
			fun.dropdownCountrybyId(DDListEditWorkCountry, DDListEditWorkState, "CId='" + dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString() + "'");
			DDListEditWorkCountry.SelectedIndex = 0;
			fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
			DDListEditWorkCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString();
			fun.dropdownState(DDListEditWorkState, DDListEditWorkCity, DDListEditWorkCountry);
			fun.dropdownStatebyId(DDListEditWorkState, "CId='" + dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["WorkState"].ToString() + "'");
			DDListEditWorkState.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkState"].ToString();
			fun.dropdownCity(DDListEditWorkCity, DDListEditWorkState);
			fun.dropdownCitybyId(DDListEditWorkCity, "SId='" + dataSet2.Tables[0].Rows[0]["WorkState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["WorkCity"].ToString() + "'");
			DDListEditWorkCity.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkCity"].ToString();
			txtEditWorkPinNo.Text = dataSet2.Tables[0].Rows[0]["WorkPinNo"].ToString();
			txtEditWorkContactNo.Text = dataSet2.Tables[0].Rows[0]["WorkContactNo"].ToString();
			txtEditWorkFaxNo.Text = dataSet2.Tables[0].Rows[0]["WorkFaxNo"].ToString();
			txtEditMaterialDelAdd.Text = dataSet2.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
			fun.dropdownCountrybyId(DDListEditMaterialDelCountry, DDListEditMaterialDelState, "CId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
			DDListEditMaterialDelCountry.SelectedIndex = 0;
			fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);
			DDListEditMaterialDelCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
			fun.dropdownState(DDListEditMaterialDelState, DDListEditMaterialDelCity, DDListEditMaterialDelCountry);
			fun.dropdownStatebyId(DDListEditMaterialDelState, "CId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
			DDListEditMaterialDelState.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString();
			fun.dropdownCity(DDListEditMaterialDelCity, DDListEditMaterialDelState);
			fun.dropdownCitybyId(DDListEditMaterialDelCity, "SId='" + dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
			DDListEditMaterialDelCity.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelCity"].ToString();
			DDLPF.SelectedValue = dataSet2.Tables[0].Rows[0]["PF"].ToString();
			DDLExcies.SelectedValue = dataSet2.Tables[0].Rows[0]["ExST"].ToString();
			DDLVat.SelectedValue = dataSet2.Tables[0].Rows[0]["VAT"].ToString();
			txtEditMaterialDelPinNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelPinNo"].ToString();
			txtEditMaterialDelContactNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
			txtEditMaterialDelFaxNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
			txtEditContactPerson.Text = dataSet2.Tables[0].Rows[0]["ContactPerson"].ToString();
			txtEditJuridictionCode.Text = dataSet2.Tables[0].Rows[0]["JuridictionCode"].ToString();
			txtEditCommissionurate.Text = dataSet2.Tables[0].Rows[0]["Commissionurate"].ToString();
			txtEditTinVatNo.Text = dataSet2.Tables[0].Rows[0]["TinVatNo"].ToString();
			txtEditEmail.Text = dataSet2.Tables[0].Rows[0]["Email"].ToString();
			txtEditEccNo.Text = dataSet2.Tables[0].Rows[0]["EccNo"].ToString();
			txtEditDivn.Text = dataSet2.Tables[0].Rows[0]["Divn"].ToString();
			txtEditTinCstNo.Text = dataSet2.Tables[0].Rows[0]["TinCstNo"].ToString();
			txtEditContactNo.Text = dataSet2.Tables[0].Rows[0]["ContactNo"].ToString();
			txtEditRange.Text = dataSet2.Tables[0].Rows[0]["Range"].ToString();
			txtEditPanNo.Text = dataSet2.Tables[0].Rows[0]["PanNo"].ToString();
			txtEditTdsCode.Text = dataSet2.Tables[0].Rows[0]["TDSCode"].ToString();
			txtEditRemark.Text = dataSet2.Tables[0].Rows[0]["Remark"].ToString();
			if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ModVatApplicable"]) > 0)
			{
				rbMVAYes.Checked = true;
			}
			else
			{
				rbMVANo.Checked = true;
			}
			if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ModVatInvoice"]) > 0)
			{
				rbMVIYes.Checked = true;
			}
			else
			{
				rbMVINo.Checked = true;
			}
			txtBankAccNo.Text = dataSet2.Tables[0].Rows[0]["BankAccNo"].ToString();
			txtBankName.Text = dataSet2.Tables[0].Rows[0]["BankName"].ToString();
			txtBankBranch.Text = dataSet2.Tables[0].Rows[0]["BankBranch"].ToString();
			txtBankAddress.Text = dataSet2.Tables[0].Rows[0]["BankAddress"].ToString();
			txtBankAccType.Text = dataSet2.Tables[0].Rows[0]["BankAccType"].ToString();
			DDLServiceCoverage.SelectedValue = dataSet2.Tables[0].Rows[0]["ServiceCoverage"].ToString();
			DataSet dataSet3 = new DataSet();
			string cmdText3 = fun.select1("*", "tblMM_Supplier_BusinessType");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection2);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3, "tblMM_Supplier_BusinessType");
			CBLBusinessType.DataSource = dataSet3;
			CBLBusinessType.DataTextField = "Type";
			CBLBusinessType.DataValueField = "Id";
			CBLBusinessType.DataBind();
			string text = dataSet2.Tables[0].Rows[0]["BusinessType"].ToString();
			string[] array = text.Split(',');
			for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (CBLBusinessType.Items[i].Value == array[j])
					{
						CBLBusinessType.Items[i].Selected = true;
					}
				}
			}
			DataSet dataSet4 = new DataSet();
			string cmdText4 = fun.select1("*", "tblMM_Supplier_BusinessNature");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection2);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			sqlDataAdapter4.Fill(dataSet4, "tblMM_Supplier_BusinessNature");
			CBLBusinessNature.DataSource = dataSet4;
			CBLBusinessNature.DataTextField = "Nature";
			CBLBusinessNature.DataValueField = "Id";
			CBLBusinessNature.DataBind();
			string text2 = dataSet2.Tables[0].Rows[0]["BusinessNature"].ToString();
			string[] array2 = text2.Split(',');
			for (int k = 0; k < dataSet4.Tables[0].Rows.Count; k++)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					if (CBLBusinessNature.Items[k].Value == array2[l])
					{
						CBLBusinessNature.Items[k].Selected = true;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Update_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			for (int i = 0; i < CBLBusinessType.Items.Count; i++)
			{
				if (CBLBusinessType.Items[i].Selected)
				{
					text = text + CBLBusinessType.Items[i].Value + ",";
				}
			}
			string text2 = "";
			for (int j = 0; j < CBLBusinessNature.Items.Count; j++)
			{
				if (CBLBusinessNature.Items[j].Selected)
				{
					text2 = text2 + CBLBusinessNature.Items[j].Value + ",";
				}
			}
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = Convert.ToInt32(Session["compid"]);
			string text3 = Session["username"].ToString();
			int num2 = 0;
			num2 = (rbMVAYes.Checked ? 1 : 0);
			int num3 = 0;
			num3 = (rbMVIYes.Checked ? 1 : 0);
			string text4 = txtSupplierName.Text.Substring(0, 1).ToUpper();
			if (text4 == CustCode.Substring(0, 1))
			{
				if (txtEditScopeofSupply.Text != "" && txtEditEmail.Text != "" && txtEditRegdAdd.Text != "" && txtEditRegdPinNo.Text != "" && txtEditRegdContactNo.Text != "" && txtEditRegdFaxNo.Text != "" && txtEditWorkAdd.Text != "" && txtEditWorkPinNo.Text != "" && txtEditWorkContactNo.Text != "" && txtEditWorkFaxNo.Text != "" && txtEditMaterialDelAdd.Text != "" && txtEditMaterialDelPinNo.Text != "" && txtEditMaterialDelContactNo.Text != "" && txtEditMaterialDelFaxNo.Text != "" && txtEditContactPerson.Text != "" && txtEditJuridictionCode.Text != "" && txtEditCommissionurate.Text != "" && txtEditTinVatNo.Text != "" && txtEditEccNo.Text != "" && txtEditDivn.Text != "" && txtEditTinCstNo.Text != "" && txtEditContactNo.Text != "" && txtEditRange.Text != "" && txtEditPanNo.Text != "" && txtEditTdsCode.Text != "" && txtEditRemark.Text != "" && txtBankAccNo.Text != "" && txtBankName.Text != "" && txtBankBranch.Text != "" && txtBankAddress.Text != "" && txtBankAccType.Text != "" && DDListEditRegdCountry.SelectedValue != "Select" && DDListEditRegdState.SelectedValue != "Select" && DDListEditRegdCity.SelectedValue != "Select" && DDListEditWorkCountry.SelectedValue != "Select" && DDListEditWorkState.SelectedValue != "Select" && DDListEditWorkCity.SelectedValue != "Select" && DDListEditMaterialDelCountry.SelectedValue != "Select" && DDListEditMaterialDelState.SelectedValue != "Select" && DDListEditMaterialDelCity.SelectedValue != "Select" && DDLServiceCoverage.SelectedValue != "Select" && fun.EmailValidation(txtEditEmail.Text) && txtSupplierName.Text != "")
				{
					string cmdText = fun.update("tblMM_Supplier_master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text3 + "',SupplierName='" + txtSupplierName.Text.ToUpper() + "',ScopeOfSupply='" + txtEditScopeofSupply.Text + "',RegdAddress='" + txtEditRegdAdd.Text + "',RegdCountry='" + DDListEditRegdCountry.SelectedValue + "',RegdState='" + DDListEditRegdState.SelectedValue + "',RegdCity='" + DDListEditRegdCity.SelectedValue + "',RegdPinNo='" + txtEditRegdPinNo.Text + "',RegdContactNo='" + txtEditRegdContactNo.Text + "',RegdFaxNo='" + txtEditRegdFaxNo.Text + "',WorkAddress='" + txtEditWorkAdd.Text + "',WorkCountry='" + DDListEditWorkCountry.SelectedValue + "',WorkState='" + DDListEditWorkState.SelectedValue + "',WorkCity='" + DDListEditWorkCity.SelectedValue + "',WorkPinNo='" + txtEditWorkPinNo.Text + "',WorkContactNo='" + txtEditWorkContactNo.Text + "',WorkFaxNo='" + txtEditWorkFaxNo.Text + "',MaterialDelAddress='" + txtEditMaterialDelAdd.Text + "' ,MaterialDelCountry='" + DDListEditMaterialDelCountry.SelectedValue + "',MaterialDelState='" + DDListEditMaterialDelState.SelectedValue + "',MaterialDelCity='" + DDListEditMaterialDelCity.SelectedValue + "',MaterialDelPinNo='" + txtEditMaterialDelPinNo.Text + "',MaterialDelContactNo='" + txtEditMaterialDelContactNo.Text + "',MaterialDelFaxNo='" + txtEditMaterialDelFaxNo.Text + "',ContactPerson='" + txtEditContactPerson.Text + "',JuridictionCode='" + txtEditJuridictionCode.Text + "',Commissionurate='" + txtEditCommissionurate.Text + "',TinVatNo='" + txtEditTinVatNo.Text + "',Email='" + txtEditEmail.Text + "',EccNo='" + txtEditEccNo.Text + "',Divn='" + txtEditDivn.Text + "',TinCstNo='" + txtEditTinCstNo.Text + "',ContactNo='" + txtEditContactNo.Text + "',Range='" + txtEditRange.Text + "',PanNo='" + txtEditPanNo.Text + "',TDSCode='" + txtEditTdsCode.Text + "',Remark='" + txtEditRemark.Text + "',ModVatApplicable='" + num2 + "',ModVatInvoice='" + num3 + "',BankAccNo='" + txtBankAccNo.Text + "',BankName='" + txtBankName.Text + "',BankBranch='" + txtBankBranch.Text + "',BankAddress='" + txtBankAddress.Text + "',BankAccType='" + txtBankAccType.Text + "',BusinessType='" + text + "',BusinessNature='" + text2 + "',ServiceCoverage='" + DDLServiceCoverage.SelectedValue + "',PF='" + Convert.ToInt32(DDLPF.SelectedValue) + "',ExST='" + Convert.ToInt32(DDLExcies.SelectedValue) + "',VAT='" + Convert.ToInt32(DDLVat.SelectedValue) + "'", "SupplierId='" + CustCode + "' And CompId='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					base.Response.Redirect("SupplierMaster_Edit.aspx?ModId=6&SubModId=22");
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Supplier name must start with letter " + CustCode.Substring(0, 1);
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
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

	protected void DDListEditRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListEditRegdState, DDListEditRegdCity, DDListEditRegdCountry);
	}

	protected void DDListEditWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListEditWorkState, DDListEditWorkCity, DDListEditWorkCountry);
	}

	protected void DDListEditWorkState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListEditWorkCity, DDListEditWorkState);
	}

	protected void DDListEditRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListEditRegdCity, DDListEditRegdState);
	}

	protected void DDListEditMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListEditMaterialDelState, DDListEditMaterialDelCity, DDListEditMaterialDelCountry);
	}

	protected void DDListEditMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListEditMaterialDelCity, DDListEditMaterialDelState);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SupplierMaster_Edit.aspx?ModId=6&SubModId=22");
	}
}

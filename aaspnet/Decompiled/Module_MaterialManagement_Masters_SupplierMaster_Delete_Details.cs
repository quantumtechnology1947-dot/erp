using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Masters_SupplierMaster_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int cId;

	protected Label lblSupName;

	protected Label hfSupplierId;

	protected Button Delete;

	protected Button Button1;

	protected TextBox txtEditScopeofSupply;

	protected TextBox txtEditRegdAdd;

	protected TextBox txtEditWorkAdd;

	protected TextBox txtEditMaterialDelAdd;

	protected DropDownList DDListEditRegdCountry;

	protected DropDownList DDListEditWorkCountry;

	protected DropDownList DDListEditMaterialDelCountry;

	protected DropDownList DDListEditRegdState;

	protected DropDownList DDListEditWorkState;

	protected DropDownList DDListEditMaterialDelState;

	protected DropDownList DDListEditRegdCity;

	protected DropDownList DDListEditWorkCity;

	protected DropDownList DDListEditMaterialDelCity;

	protected TextBox txtEditRegdPinNo;

	protected TextBox txtEditWorkPinNo;

	protected TextBox txtEditMaterialDelPinNo;

	protected TextBox txtEditRegdContactNo;

	protected TextBox txtEditWorkContactNo;

	protected TextBox txtEditMaterialDelContactNo;

	protected TextBox txtEditRegdFaxNo;

	protected TextBox txtEditWorkFaxNo;

	protected TextBox txtEditMaterialDelFaxNo;

	protected TextBox txtEditContactPerson;

	protected TextBox txtEditEmail;

	protected TextBox txtEditContactNo;

	protected TextBox txtEditJuridictionCode;

	protected TextBox txtEditEccNo;

	protected TextBox txtEditRange;

	protected TextBox txtEditCommissionurate;

	protected TextBox txtEditDivn;

	protected TextBox txtEditPanNo;

	protected TextBox txtEditTinVatNo;

	protected TextBox txtEditTinCstNo;

	protected TextBox txtEditTdsCode;

	protected RadioButton rbMVAYes;

	protected RadioButton rbMVANo;

	protected RadioButton rbMVIYes;

	protected RadioButton rbMVINo;

	protected TextBox txtBankAccNo;

	protected TextBox txtBankName;

	protected TextBox txtBankBranch;

	protected TextBox txtBankAddress;

	protected TextBox txtBankAccType;

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
			string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + base.Request.QueryString["SupplierId"].ToString() + "' And CompId='" + cId + "'");
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			lblSupName.Text = dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
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

	protected void Delete_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(Session["compid"]);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("tblMM_SPR_Details.SupplierId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.SupplierId='" + CustCode + "' And tblMM_SPR_Master.CompId='" + num + "'  And tblMM_SPR_Master.Id = tblMM_SPR_Details.MId");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string cmdText2 = fun.select("tblMM_PR_Details.SupplierId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Details.SupplierId='" + CustCode + "' And tblMM_PR_Master.CompId='" + num + "'  And tblMM_PR_Master.Id=tblMM_PR_Details.MId ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			string cmdText3 = fun.select("tblMP_Material_Master.SupplierId", "tblMP_Material_Master", "tblMP_Material_Master.SupplierId='" + CustCode + "' And tblMP_Material_Master.CompId='" + num + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter.Fill(dataSet3);
			string cmdText4 = fun.select("tblMP_Material_Process.SupplierId", "tblMP_Material_Process,tblMP_Material_Master", "tblMP_Material_Process.SupplierId='" + CustCode + "'   ");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter3.Fill(dataSet4);
			string cmdText5 = fun.select("tblMP_Material_RawMaterial.SupplierId", "tblMP_Material_RawMaterial,tblMP_Material_Master", "tblMP_Material_RawMaterial.SupplierId='" + CustCode + "'  ");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter4.Fill(dataSet5);
			if (dataSet.Tables[0].Rows.Count > 0 || dataSet3.Tables[0].Rows.Count > 0 || dataSet4.Tables[0].Rows.Count > 0 || dataSet5.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
			{
				string empty = string.Empty;
				empty = "Supplier is in Use. you can not delete this Supplier !";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				return;
			}
			string cmdText6 = fun.delete("tblMM_Supplier_master", "SupplierId='" + CustCode + "' And CompId='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText6, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			base.Response.Redirect("SupplierMaster_Delete.aspx?ModId=6&SubModId=22");
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
		base.Response.Redirect("SupplierMaster_Delete.aspx?ModId=6&SubModId=22");
	}
}

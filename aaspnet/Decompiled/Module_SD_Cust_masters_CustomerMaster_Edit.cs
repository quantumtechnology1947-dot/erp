using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SD_Cust_masters_CustomerMaster_Edit : Page, IRequiresSessionState
{
	protected Label lblCustName;

	protected Label hfCustomerId;

	protected Button Update;

	protected Button btnCancel;

	protected TextBox txtEditRegdAdd;

	protected RequiredFieldValidator ReqregdAdd;

	protected TextBox txtEditWorkAdd;

	protected RequiredFieldValidator ReqworkAdd;

	protected TextBox txtEditMaterialDelAdd;

	protected RequiredFieldValidator ReqMaterialAdd;

	protected DropDownList DDListEditRegdCountry;

	protected RequiredFieldValidator ReqregdCountry;

	protected DropDownList DDListEditWorkCountry;

	protected RequiredFieldValidator ReqWorkCountry;

	protected DropDownList DDListEditMaterialDelCountry;

	protected RequiredFieldValidator ReqMaterialCountry;

	protected DropDownList DDListEditRegdState;

	protected RequiredFieldValidator ReqregdState;

	protected DropDownList DDListEditWorkState;

	protected RequiredFieldValidator ReqWorkState;

	protected DropDownList DDListEditMaterialDelState;

	protected RequiredFieldValidator ReqMaterialState;

	protected DropDownList DDListEditRegdCity;

	protected RequiredFieldValidator ReqregdCity;

	protected DropDownList DDListEditWorkCity;

	protected RequiredFieldValidator ReqWorkCity;

	protected DropDownList DDListEditMaterialDelCity;

	protected RequiredFieldValidator ReqMaterialCity;

	protected TextBox txtEditRegdPinNo;

	protected RequiredFieldValidator ReqregdPIN;

	protected TextBox txtEditWorkPinNo;

	protected RequiredFieldValidator Reqworkpin;

	protected TextBox txtEditMaterialDelPinNo;

	protected RequiredFieldValidator ReqMaterialPIN;

	protected TextBox txtEditRegdContactNo;

	protected RequiredFieldValidator ReqregdContNO;

	protected TextBox txtEditWorkContactNo;

	protected RequiredFieldValidator ReqWorkContNo;

	protected TextBox txtEditMaterialDelContactNo;

	protected RequiredFieldValidator ReqMateContNo;

	protected TextBox txtEditRegdFaxNo;

	protected RequiredFieldValidator ReqregdFaxNo;

	protected TextBox txtEditWorkFaxNo;

	protected RequiredFieldValidator ReqWorkFaxNo;

	protected TextBox txtEditMaterialDelFaxNo;

	protected RequiredFieldValidator ReqMaterialFax;

	protected TextBox txtEditContactPerson;

	protected RequiredFieldValidator ReqContactPerson;

	protected TextBox txtEditEmail;

	protected RequiredFieldValidator ReqEmail;

	protected RegularExpressionValidator RegEmail;

	protected TextBox txtEditContactNo;

	protected RequiredFieldValidator ReqContNo;

	protected TextBox txtEditJuridictionCode;

	protected RequiredFieldValidator ReqjuridctNo;

	protected TextBox txtEditEccNo;

	protected RequiredFieldValidator ReqEcc;

	protected TextBox txtEditRange;

	protected RequiredFieldValidator ReqRange;

	protected TextBox txtEditCommissionurate;

	protected RequiredFieldValidator ReqCommisnurate;

	protected TextBox txtEditDivn;

	protected RequiredFieldValidator ReqDivn;

	protected TextBox txtEditPanNo;

	protected RequiredFieldValidator ReqPanNO;

	protected TextBox txtEditTinVatNo;

	protected RequiredFieldValidator ReqTinVat;

	protected TextBox txtEditTinCstNo;

	protected RequiredFieldValidator ReqTINCST;

	protected TextBox txtEditTdsCode;

	protected RequiredFieldValidator ReqTDS;

	protected TextBox txtEditRemark;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int cId;

	private string sId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			sId = Session["username"].ToString();
			cId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string cmdText = fun.select("CustomerName", "SD_Cust_Master", "CustomerId='" + base.Request.QueryString["CustomerId"].ToString() + "' And CompId='" + cId + "'");
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblCustName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
			}
			hfCustomerId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = hfCustomerId.Text;
		}
		catch (Exception)
		{
		}
		if (!base.IsPostBack)
		{
			fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
			fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
			fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);
			try
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = "Select * from SD_Cust_master where CustomerId='" + CustCode + "'And CompId='" + cId + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_master");
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
			}
			catch (Exception)
			{
			}
		}
	}

	protected void Update_Click(object sender, EventArgs e)
	{
		try
		{
			string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			Regex regex = new Regex(pattern);
			con.Open();
			if (regex.IsMatch(txtEditEmail.Text) && txtEditEmail.Text != "" && CDate.ToString() != "" && CTime.ToString() != "" && sId.ToString() != "" && txtEditRegdAdd.Text != "" && DDListEditRegdCountry.SelectedValue != "Select" && DDListEditRegdState.SelectedValue != "Select" && DDListEditRegdCity.SelectedValue != "Select" && txtEditRegdPinNo.Text != "" && txtEditRegdContactNo.Text != "" && txtEditRegdFaxNo.Text != "" && txtEditWorkAdd.Text != "" && DDListEditWorkCountry.SelectedValue != "Select" && DDListEditWorkState.SelectedValue != "Select" && DDListEditWorkCity.SelectedValue != "Select" && txtEditWorkPinNo.Text != "" && txtEditWorkContactNo.Text != "" && txtEditWorkFaxNo.Text != "" && txtEditMaterialDelAdd.Text != "" && DDListEditMaterialDelCountry.SelectedValue != "Select" && DDListEditMaterialDelState.SelectedValue != "Select" && DDListEditMaterialDelCity.SelectedValue != "Select" && txtEditMaterialDelPinNo.Text != "" && txtEditMaterialDelContactNo.Text != "" && txtEditMaterialDelFaxNo.Text != "" && txtEditContactPerson.Text != "" && txtEditJuridictionCode.Text != "" && txtEditCommissionurate.Text != "" && txtEditTinVatNo.Text != "" && txtEditEccNo.Text != "" && txtEditDivn.Text != "" && txtEditTinCstNo.Text != "" && txtEditContactNo.Text != "" && txtEditRange.Text != "" && txtEditPanNo.Text != "" && txtEditTdsCode.Text != "" && cId != 0 && CustCode.ToString() != "")
			{
				string cmdText = fun.update("SD_Cust_master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',RegdAddress='" + txtEditRegdAdd.Text + "',RegdCountry='" + DDListEditRegdCountry.SelectedValue + "',RegdState='" + DDListEditRegdState.SelectedValue + "',RegdCity='" + DDListEditRegdCity.SelectedValue + "',RegdPinNo='" + txtEditRegdPinNo.Text + "',RegdContactNo='" + txtEditRegdContactNo.Text + "',RegdFaxNo='" + txtEditRegdFaxNo.Text + "',WorkAddress='" + txtEditWorkAdd.Text + "',WorkCountry='" + DDListEditWorkCountry.SelectedValue + "',WorkState='" + DDListEditWorkState.SelectedValue + "',WorkCity='" + DDListEditWorkCity.SelectedValue + "',WorkPinNo='" + txtEditWorkPinNo.Text + "',WorkContactNo='" + txtEditWorkContactNo.Text + "',WorkFaxNo='" + txtEditWorkFaxNo.Text + "',MaterialDelAddress='" + txtEditMaterialDelAdd.Text + "' ,MaterialDelCountry='" + DDListEditMaterialDelCountry.SelectedValue + "',MaterialDelState='" + DDListEditMaterialDelState.SelectedValue + "',MaterialDelCity='" + DDListEditMaterialDelCity.SelectedValue + "',MaterialDelPinNo='" + txtEditMaterialDelPinNo.Text + "',MaterialDelContactNo='" + txtEditMaterialDelContactNo.Text + "',MaterialDelFaxNo='" + txtEditMaterialDelFaxNo.Text + "',ContactPerson='" + txtEditContactPerson.Text + "',JuridictionCode='" + txtEditJuridictionCode.Text + "',Commissionurate='" + txtEditCommissionurate.Text + "',TinVatNo='" + txtEditTinVatNo.Text + "',Email='" + txtEditEmail.Text + "',EccNo='" + txtEditEccNo.Text + "',Divn='" + txtEditDivn.Text + "',TinCstNo='" + txtEditTinCstNo.Text + "',ContactNo='" + txtEditContactNo.Text + "',Range='" + txtEditRange.Text + "',PanNo='" + txtEditPanNo.Text + "',TDSCode='" + txtEditTdsCode.Text + "',Remark='" + txtEditRemark.Text + "'", "CustomerId='" + CustCode + "' And CompId='" + cId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				base.Response.Redirect("CustomerMaster_Edit.aspx?ModId=2&SubModId=7");
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerMaster_Edit.aspx?ModId=2&SubModId=7");
	}
}

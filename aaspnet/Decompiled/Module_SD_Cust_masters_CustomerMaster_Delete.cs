using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SD_Cust_masters_CustomerMaster_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private string connStr = "";

	private SqlConnection con;

	private int cId;

	protected Label lblCustName;

	protected Label hfCustomerId;

	protected Button Delete;

	protected Button btnCancel;

	protected TextBox txtDeleteRegdAdd;

	protected TextBox txtDeleteWorkAdd;

	protected TextBox txtDeleteMaterialDelAdd;

	protected DropDownList DDListDeleteRegdCountry;

	protected DropDownList DDListDeleteWorkCountry;

	protected DropDownList DDListDeleteMaterialDelCountry;

	protected DropDownList DDListDeleteRegdState;

	protected DropDownList DDListDeleteWorkState;

	protected DropDownList DDListDeleteMaterialDelState;

	protected DropDownList DDListDeleteRegdCity;

	protected DropDownList DDListDeleteWorkCity;

	protected DropDownList DDListDeleteMaterialDelCity;

	protected TextBox txtDeleteRegdPinNo;

	protected TextBox txtDeleteWorkPinNo;

	protected TextBox txtDeleteMaterialDelPinNo;

	protected TextBox txtDeleteRegdContactNo;

	protected TextBox txtDeleteWorkContactNo;

	protected TextBox txtDeleteMaterialDelContactNo;

	protected TextBox txtDeleteRegdFaxNo;

	protected TextBox txtDeleteWorkFaxNo;

	protected TextBox txtDeleteMaterialDelFaxNo;

	protected TextBox txtDeleteContactPerson;

	protected TextBox txtDeleteEmail;

	protected TextBox txtDeleteContactNo;

	protected TextBox txtDeleteJuridictionCode;

	protected TextBox txtDeleteEccNo;

	protected TextBox txtDeleteRange;

	protected TextBox txtDeleteCommissionurate;

	protected TextBox txtDeleteDivn;

	protected TextBox txtDeletePanNo;

	protected TextBox txtDeleteTinVatNo;

	protected TextBox txtDeleteTinCstNo;

	protected TextBox txtDeleteTdsCode;

	protected TextBox txtDeleteRemark;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			cId = Convert.ToInt32(Session["compid"]);
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
			fun.dropdownCountry(DDListDeleteRegdCountry, DDListDeleteRegdState);
			fun.dropdownCountry(DDListDeleteWorkCountry, DDListDeleteWorkState);
			fun.dropdownCountry(DDListDeleteMaterialDelCountry, DDListDeleteMaterialDelState);
			try
			{
				DataSet dataSet2 = new DataSet();
				string cmdText2 = "Select * from SD_Cust_master where CustomerId='" + CustCode + "' And CompId='" + cId + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_master");
				txtDeleteRegdAdd.Text = dataSet2.Tables[0].Rows[0]["RegdAddress"].ToString();
				fun.dropdownCountrybyId(DDListDeleteRegdCountry, DDListDeleteRegdState, "CId='" + dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString() + "'");
				DDListDeleteRegdCountry.SelectedIndex = 0;
				fun.dropdownCountry(DDListDeleteRegdCountry, DDListDeleteRegdState);
				DDListDeleteRegdCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString();
				fun.dropdownState(DDListDeleteRegdState, DDListDeleteRegdCity, DDListDeleteRegdCountry);
				fun.dropdownStatebyId(DDListDeleteRegdState, "CId='" + dataSet2.Tables[0].Rows[0]["RegdCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["RegdState"].ToString() + "'");
				DDListDeleteRegdState.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdState"].ToString();
				fun.dropdownCity(DDListDeleteRegdCity, DDListDeleteRegdState);
				fun.dropdownCitybyId(DDListDeleteRegdCity, "SId='" + dataSet2.Tables[0].Rows[0]["RegdState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["RegdCity"].ToString() + "'");
				DDListDeleteRegdCity.SelectedValue = dataSet2.Tables[0].Rows[0]["RegdCity"].ToString();
				txtDeleteRegdPinNo.Text = dataSet2.Tables[0].Rows[0]["RegdPinNo"].ToString();
				txtDeleteRegdContactNo.Text = dataSet2.Tables[0].Rows[0]["RegdContactNo"].ToString();
				txtDeleteRegdFaxNo.Text = dataSet2.Tables[0].Rows[0]["RegdFaxNo"].ToString();
				txtDeleteWorkAdd.Text = dataSet2.Tables[0].Rows[0]["WorkAddress"].ToString();
				fun.dropdownCountrybyId(DDListDeleteWorkCountry, DDListDeleteWorkState, "CId='" + dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString() + "'");
				DDListDeleteWorkCountry.SelectedIndex = 0;
				fun.dropdownCountry(DDListDeleteWorkCountry, DDListDeleteWorkState);
				DDListDeleteWorkCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString();
				fun.dropdownState(DDListDeleteWorkState, DDListDeleteWorkCity, DDListDeleteWorkCountry);
				fun.dropdownStatebyId(DDListDeleteWorkState, "CId='" + dataSet2.Tables[0].Rows[0]["WorkCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["WorkState"].ToString() + "'");
				DDListDeleteWorkState.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkState"].ToString();
				fun.dropdownCity(DDListDeleteWorkCity, DDListDeleteWorkState);
				fun.dropdownCitybyId(DDListDeleteWorkCity, "SId='" + dataSet2.Tables[0].Rows[0]["WorkState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["WorkCity"].ToString() + "'");
				DDListDeleteWorkCity.SelectedValue = dataSet2.Tables[0].Rows[0]["WorkCity"].ToString();
				txtDeleteWorkPinNo.Text = dataSet2.Tables[0].Rows[0]["WorkPinNo"].ToString();
				txtDeleteWorkContactNo.Text = dataSet2.Tables[0].Rows[0]["WorkContactNo"].ToString();
				txtDeleteWorkFaxNo.Text = dataSet2.Tables[0].Rows[0]["WorkFaxNo"].ToString();
				txtDeleteMaterialDelAdd.Text = dataSet2.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DDListDeleteMaterialDelCountry, DDListDeleteMaterialDelState, "CId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DDListDeleteMaterialDelCountry.SelectedIndex = 0;
				fun.dropdownCountry(DDListDeleteMaterialDelCountry, DDListDeleteMaterialDelState);
				DDListDeleteMaterialDelCountry.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
				fun.dropdownState(DDListDeleteMaterialDelState, DDListDeleteMaterialDelCity, DDListDeleteMaterialDelCountry);
				fun.dropdownStatebyId(DDListDeleteMaterialDelState, "CId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DDListDeleteMaterialDelState.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DDListDeleteMaterialDelCity, DDListDeleteMaterialDelState);
				fun.dropdownCitybyId(DDListDeleteMaterialDelCity, "SId='" + dataSet2.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DDListDeleteMaterialDelCity.SelectedValue = dataSet2.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				txtDeleteMaterialDelPinNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelPinNo"].ToString();
				txtDeleteMaterialDelContactNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				txtDeleteMaterialDelFaxNo.Text = dataSet2.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				txtDeleteContactPerson.Text = dataSet2.Tables[0].Rows[0]["ContactPerson"].ToString();
				txtDeleteJuridictionCode.Text = dataSet2.Tables[0].Rows[0]["JuridictionCode"].ToString();
				txtDeleteCommissionurate.Text = dataSet2.Tables[0].Rows[0]["Commissionurate"].ToString();
				txtDeleteTinVatNo.Text = dataSet2.Tables[0].Rows[0]["TinVatNo"].ToString();
				txtDeleteEmail.Text = dataSet2.Tables[0].Rows[0]["Email"].ToString();
				txtDeleteEccNo.Text = dataSet2.Tables[0].Rows[0]["EccNo"].ToString();
				txtDeleteDivn.Text = dataSet2.Tables[0].Rows[0]["Divn"].ToString();
				txtDeleteTinCstNo.Text = dataSet2.Tables[0].Rows[0]["TinCstNo"].ToString();
				txtDeleteContactNo.Text = dataSet2.Tables[0].Rows[0]["ContactNo"].ToString();
				txtDeleteRange.Text = dataSet2.Tables[0].Rows[0]["Range"].ToString();
				txtDeletePanNo.Text = dataSet2.Tables[0].Rows[0]["PanNo"].ToString();
				txtDeleteTdsCode.Text = dataSet2.Tables[0].Rows[0]["TDSCode"].ToString();
				txtDeleteRemark.Text = dataSet2.Tables[0].Rows[0]["Remark"].ToString();
			}
			catch (Exception)
			{
			}
		}
	}

	protected void DDListDeleteRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteRegdState, DDListDeleteRegdCity, DDListDeleteRegdCountry);
	}

	protected void DDListDeleteRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteRegdCity, DDListDeleteRegdState);
	}

	protected void DDListDeleteWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteWorkState, DDListDeleteWorkCity, DDListDeleteWorkCountry);
	}

	protected void DDListDeleteWorkState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteWorkCity, DDListDeleteWorkState);
	}

	protected void DDListDeleteMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteMaterialDelState, DDListDeleteMaterialDelCity, DDListDeleteMaterialDelCountry);
	}

	protected void DDListDeleteMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteMaterialDelCity, DDListDeleteMaterialDelState);
	}

	protected void Delete_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string cmdText = fun.delete("SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + cId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			base.Response.Redirect("CustomerMaster_Delete.aspx?ModId=2&SubModId=7");
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerMaster_Delete.aspx?ModId=2&SubModId=7");
	}
}

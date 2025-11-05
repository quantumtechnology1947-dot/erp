using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Transactions_CustEnquiry_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int EnqId;

	private int CId;

	protected Label hfEnqId;

	protected Button Delete;

	protected Button Button1;

	protected Label lblCustName;

	protected Label hfCustId;

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

	protected TextBox txtDeleteEnquiryFor;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			hfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CId = Convert.ToInt32(Session["compid"]);
			hfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			CustCode = hfCustId.Text;
			EnqId = Convert.ToInt32(hfEnqId.Text);
			string cmdText = fun.select("CustomerName", "SD_Cust_Enquiry_Master", "CompId='" + CId + "' And EnqId='" + EnqId + "'");
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_Enquiry_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblCustName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
			}
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DDListDeleteRegdCountry, DDListDeleteRegdState);
				fun.dropdownCountry(DDListDeleteWorkCountry, DDListDeleteWorkState);
				fun.dropdownCountry(DDListDeleteMaterialDelCountry, DDListDeleteMaterialDelState);
				DataSet dataSet2 = new DataSet();
				hfCustId.Text = CustCode;
				string cmdText2 = fun.select("*", "SD_Cust_Enquiry_Master", "CompId='" + CId + "' And EnqId='" + EnqId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_Enquiry_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
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
					txtDeleteEnquiryFor.Text = dataSet2.Tables[0].Rows[0]["EnquiryFor"].ToString();
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
		try
		{
			sqlConnection.Open();
			string cmdText = fun.delete("SD_Cust_Enquiry_Master", "CustomerId='" + CustCode + "' and EnqId='" + EnqId + "' and CompId='" + CId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			base.Response.Redirect("CustEnquiry_Delete.aspx?ModId=2&SubModId=10");
		}
		catch (SqlException)
		{
			string empty = string.Empty;
			empty = "You Cannot delete this Enquiry. This is in use. ";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DDListDeleteRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteRegdState, DDListDeleteRegdCity, DDListDeleteRegdCountry);
	}

	protected void DDListDeleteWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteWorkState, DDListDeleteWorkCity, DDListDeleteWorkCountry);
	}

	protected void DDListDeleteWorkState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteWorkCity, DDListDeleteWorkState);
	}

	protected void DDListDeleteRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteRegdCity, DDListDeleteRegdState);
	}

	protected void DDListDeleteMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListDeleteMaterialDelState, DDListDeleteMaterialDelCity, DDListDeleteMaterialDelCountry);
	}

	protected void DDListDeleteMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListDeleteMaterialDelCity, DDListDeleteMaterialDelState);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustEnquiry_Delete.aspx?ModId=2&SubModId=10");
	}
}

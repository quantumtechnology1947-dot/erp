using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Transactions_CustEnquiry_Edit_Details : Page, IRequiresSessionState
{
	protected Label hfEnqId;

	protected Button Update;

	protected Button btncancel;

	protected Label lblCustName;

	protected Label hfCustId;

	protected TextBox txtEditRegdAdd;

	protected RequiredFieldValidator ReqRegdAdd;

	protected TextBox txtEditWorkAdd;

	protected RequiredFieldValidator ReqworkAdd;

	protected TextBox txtEditMaterialDelAdd;

	protected RequiredFieldValidator ReqMateAdd;

	protected DropDownList DDListEditRegdCountry;

	protected RequiredFieldValidator ReqRegdCountry;

	protected DropDownList DDListEditWorkCountry;

	protected RequiredFieldValidator ReqWorkContry;

	protected DropDownList DDListEditMaterialDelCountry;

	protected RequiredFieldValidator ReqMateCountry;

	protected DropDownList DDListEditRegdState;

	protected RequiredFieldValidator ReqRegdState;

	protected DropDownList DDListEditWorkState;

	protected RequiredFieldValidator ReqWorkState;

	protected DropDownList DDListEditMaterialDelState;

	protected RequiredFieldValidator ReqMaterialState;

	protected DropDownList DDListEditRegdCity;

	protected RequiredFieldValidator ReqRegdCity;

	protected DropDownList DDListEditWorkCity;

	protected RequiredFieldValidator ReqWorkCity;

	protected DropDownList DDListEditMaterialDelCity;

	protected RequiredFieldValidator ReqMateCity;

	protected TextBox txtEditRegdPinNo;

	protected RequiredFieldValidator ReqRegdPin;

	protected TextBox txtEditWorkPinNo;

	protected RequiredFieldValidator ReqWorkPIN;

	protected TextBox txtEditMaterialDelPinNo;

	protected RequiredFieldValidator ReqMatePIN;

	protected TextBox txtEditRegdContactNo;

	protected RequiredFieldValidator ReqRegdContNo;

	protected TextBox txtEditWorkContactNo;

	protected RequiredFieldValidator ReqWorkContNo;

	protected TextBox txtEditMaterialDelContactNo;

	protected RequiredFieldValidator ReqMateContNo;

	protected TextBox txtEditRegdFaxNo;

	protected RequiredFieldValidator ReqRegdFaxNO;

	protected TextBox txtEditWorkFaxNo;

	protected RequiredFieldValidator ReqWorkFax;

	protected TextBox txtEditMaterialDelFaxNo;

	protected RequiredFieldValidator ReqFaxNo;

	protected TextBox txtEditContactPerson;

	protected RequiredFieldValidator ReqContPerson;

	protected TextBox txtEditEmail;

	protected RequiredFieldValidator ReqEmail;

	protected RegularExpressionValidator RegEmail;

	protected TextBox txtEditContactNo;

	protected RequiredFieldValidator ReqContNo;

	protected TextBox txtEditJuridictionCode;

	protected RequiredFieldValidator ReqJuriCode;

	protected TextBox txtEditEccNo;

	protected RequiredFieldValidator ReqEcc;

	protected TextBox txtEditRange;

	protected RequiredFieldValidator ReqRange;

	protected TextBox txtEditCommissionurate;

	protected RequiredFieldValidator ReqCommisunerate;

	protected TextBox txtEditDivn;

	protected RequiredFieldValidator ReqDiv;

	protected TextBox txtEditPanNo;

	protected RequiredFieldValidator ReqPanNo;

	protected TextBox txtEditTinVatNo;

	protected RequiredFieldValidator ReqTinVat;

	protected TextBox txtEditTinCstNo;

	protected RequiredFieldValidator ReqTinCst;

	protected TextBox txtEditTdsCode;

	protected RequiredFieldValidator ReqTds;

	protected TextBox txtEditRemark;

	protected TextBox txtEditEnquiryFor;

	protected RequiredFieldValidator ReqEnqFor;

	protected FileUpload FileUpload1;

	protected RequiredFieldValidator ReqAttach;

	protected Button Button1;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int EnqId;

	private int CId;

	private string sId = "";

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string connStr = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			hfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = hfCustId.Text;
			hfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			EnqId = Convert.ToInt32(hfEnqId.Text);
			DataSet dataSet = new DataSet();
			string cmdText = fun.select("CustomerName", "SD_Cust_Enquiry_Master", "CompId='" + CId + "'AND EnqId='" + EnqId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_Enquiry_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblCustName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
			}
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
				fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
				fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);
				DataSet dataSet2 = new DataSet();
				string cmdText2 = fun.select("*", "SD_Cust_Enquiry_Master", "CompId='" + CId + "' AND EnqId='" + EnqId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_Enquiry_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
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
					txtEditEnquiryFor.Text = dataSet2.Tables[0].Rows[0]["EnquiryFor"].ToString();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Update_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			if (txtEditRegdAdd.Text != "" && DDListEditRegdCountry.SelectedValue != "Select" && DDListEditRegdState.SelectedValue != "Select" && DDListEditRegdCity.SelectedValue != "Select" && txtEditRegdPinNo.Text != "" && txtEditRegdContactNo.Text != "" && txtEditRegdFaxNo.Text != "" && txtEditWorkAdd.Text != "" && DDListEditWorkCountry.SelectedValue != "Select" && DDListEditWorkState.SelectedValue != "" && DDListEditWorkCity.SelectedValue != "Select" && txtEditWorkPinNo.Text != "" && txtEditWorkContactNo.Text != "" && txtEditWorkFaxNo.Text != "" && txtEditMaterialDelAdd.Text != "" && DDListEditMaterialDelCountry.SelectedValue != "Select" && DDListEditMaterialDelState.SelectedValue != "Select" && DDListEditMaterialDelCity.SelectedValue != "Select" && txtEditMaterialDelPinNo.Text != "" && txtEditMaterialDelContactNo.Text != "" && txtEditMaterialDelFaxNo.Text != "" && txtEditContactPerson.Text != "" && txtEditJuridictionCode.Text != "" && txtEditCommissionurate.Text != "" && txtEditTinVatNo.Text != "" && fun.EmailValidation(txtEditEmail.Text) && txtEditEmail.Text != "" && txtEditEccNo.Text != "" && txtEditDivn.Text != "" && txtEditTinCstNo.Text != "" && txtEditContactNo.Text != "" && txtEditRange.Text != "" && txtEditPanNo.Text != "" && txtEditTdsCode.Text != "" && txtEditEnquiryFor.Text != "")
			{
				string cmdText = fun.update("SD_Cust_Enquiry_Master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',RegdAddress='" + txtEditRegdAdd.Text + "',RegdCountry='" + DDListEditRegdCountry.SelectedValue + "',RegdState='" + DDListEditRegdState.SelectedValue + "',RegdCity='" + DDListEditRegdCity.SelectedValue + "',RegdPinNo='" + txtEditRegdPinNo.Text + "',RegdContactNo='" + txtEditRegdContactNo.Text + "',RegdFaxNo='" + txtEditRegdFaxNo.Text + "',WorkAddress='" + txtEditWorkAdd.Text + "',WorkCountry='" + DDListEditWorkCountry.SelectedValue + "',WorkState='" + DDListEditWorkState.SelectedValue + "',WorkCity='" + DDListEditWorkCity.SelectedValue + "',WorkPinNo='" + txtEditWorkPinNo.Text + "',WorkContactNo='" + txtEditWorkContactNo.Text + "',WorkFaxNo='" + txtEditWorkFaxNo.Text + "',MaterialDelAddress='" + txtEditMaterialDelAdd.Text + "' ,MaterialDelCountry='" + DDListEditMaterialDelCountry.SelectedValue + "',MaterialDelState='" + DDListEditMaterialDelState.SelectedValue + "',MaterialDelCity='" + DDListEditMaterialDelCity.SelectedValue + "',MaterialDelPinNo='" + txtEditMaterialDelPinNo.Text + "',MaterialDelContactNo='" + txtEditMaterialDelContactNo.Text + "',MaterialDelFaxNo='" + txtEditMaterialDelFaxNo.Text + "',ContactPerson='" + txtEditContactPerson.Text + "',JuridictionCode='" + txtEditJuridictionCode.Text + "',Commissionurate='" + txtEditCommissionurate.Text + "',TinVatNo='" + txtEditTinVatNo.Text + "',Email='" + txtEditEmail.Text + "',EccNo='" + txtEditEccNo.Text + "',Divn='" + txtEditDivn.Text + "',TinCstNo='" + txtEditTinCstNo.Text + "',ContactNo='" + txtEditContactNo.Text + "',Range='" + txtEditRange.Text + "',PanNo='" + txtEditPanNo.Text + "',TDSCode='" + txtEditTdsCode.Text + "',Remark='" + txtEditRemark.Text + "',EnquiryFor='" + txtEditEnquiryFor.Text + "'", "CustomerId='" + CustCode + "' and EnqId=" + EnqId + " and CompId=" + CId);
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				base.Response.Redirect("CustEnquiry_Edit.aspx?ModId=2&SubModId=10");
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

	protected void DDListEditRegdCity_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile == null)
			{
				return;
			}
			Stream inputStream = FileUpload1.PostedFile.InputStream;
			BinaryReader binaryReader = new BinaryReader(inputStream);
			array = binaryReader.ReadBytes((int)inputStream.Length);
			text = Path.GetFileName(postedFile.FileName);
			if (text != "")
			{
				string cmdText = fun.insert("SD_Cust_Enquiry_Attach_Master", "EnqId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", EnqId + ",'" + CId + "','" + sId + "','" + FinYearId + "','" + text + "','" + array.Length + "','" + postedFile.ContentType + "',@TransStr");
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, con))
				{
					sqlCommand.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = array;
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustEnquiry_Edit.aspx?ModId=2&SubModId=10");
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
				HyperLink hyperLink = (HyperLink)e.Row.Cells[5].Controls[0];
				hyperLink.Attributes.Add("onclick", "return confirmation();");
			}
		}
		catch (Exception)
		{
		}
	}
}

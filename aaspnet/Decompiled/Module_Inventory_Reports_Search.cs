using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Reports_Search : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	protected DropDownList Drpoption;

	protected TextBox txtNo;

	protected RadioButton RadPO;

	protected RadioButton RadGin;

	protected RadioButton RadGRR;

	protected RadioButton RadGQN;

	protected RadioButton RadGSn;

	protected CheckBox CkItem;

	protected TextBox txtItemcode;

	protected CheckBox CKwono;

	protected TextBox txtwono;

	protected CheckBox CkSupplier;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected CheckBox CkACCHead;

	protected RadioButton RbtnLabour;

	protected RadioButton RbtnWithMaterial;

	protected DropDownList DropDownList1;

	protected Label Label2;

	protected TextBox textFromDate;

	protected CalendarExtender textFromDate_CalendarExtender;

	protected RegularExpressionValidator ReqTDate;

	protected TextBox TextToDate;

	protected CalendarExtender cd1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected CompareValidator CompareValidator1;

	protected Button BtnSearch;

	protected TabPanel GIN;

	protected DropDownList ddlEnterNoMRS;

	protected TextBox txtEnterNoMRS;

	protected CheckBox CheBoxItemCatMRS;

	protected DropDownList DrpCategory;

	protected CheckBox CheBoxItemCodeMRS;

	protected TextBox txtItemCodeMRS;

	protected CheckBox CheBoxEmployeeNameMRS;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected CheckBox CheBoxBGGroupMRS;

	protected DropDownList ddlDeptMRS;

	protected CheckBox CheBoxWONoMRS;

	protected TextBox txtWONoMRS;

	protected RadioButtonList RadMRSMIN;

	protected TextBox txtFromDateMRS;

	protected CalendarExtender CalendarExtender1;

	protected RegularExpressionValidator RegtxtFromDateMRS;

	protected TextBox txtToDateMRS;

	protected CalendarExtender CalendarExtender2;

	protected RegularExpressionValidator RegtxtToDateMRS;

	protected Button btnSearchMRS;

	protected SqlDataSource SqlDataSourceMRS;

	protected TabPanel MRS;

	protected DropDownList ddlEnterNoMRN;

	protected TextBox txtEnterNoMRN;

	protected CheckBox CheBoxItemCodeMRN;

	protected TextBox txtItemCodeMRN;

	protected CheckBox CheBoxEmployeeNameMRN;

	protected TextBox TxtEmpName1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected CheckBox CheBoxBGGroupMRN;

	protected DropDownList ddlDeptMRN;

	protected CheckBox CheBoxWONoMRN;

	protected TextBox txtWONoMRN;

	protected RadioButtonList RadMRNMRQN;

	protected TextBox txtFromDateMRN;

	protected CalendarExtender CalendarExtender3;

	protected RegularExpressionValidator RegtxtFromDateMRN;

	protected TextBox txtToDateMRN;

	protected CalendarExtender CalendarExtender4;

	protected RegularExpressionValidator RegtxtToDateMRN;

	protected Label Label3;

	protected RadioButtonList PORate;

	protected Button btnSearchMRN;

	protected SqlDataSource SqlDataSourceMRN;

	protected TabPanel MRN;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		CompId = Convert.ToInt32(Session["compid"]);
		if (!base.IsPostBack)
		{
			AcHead();
			txtEnterNoMRS.Enabled = false;
			TxtEmpName.Enabled = false;
			ddlDeptMRS.Enabled = false;
			txtWONoMRS.Enabled = false;
			txtItemCodeMRS.Enabled = false;
			DrpCategory.Enabled = false;
			txtEnterNoMRN.Enabled = false;
			TxtEmpName1.Enabled = false;
			ddlDeptMRN.Enabled = false;
			txtWONoMRN.Enabled = false;
			txtItemCodeMRN.Enabled = false;
			string cmdText = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			DrpCategory.DataSource = dataSet.Tables["tblDG_Category_Master"];
			DrpCategory.DataTextField = "Category";
			DrpCategory.DataValueField = "CId";
			DrpCategory.DataBind();
			DrpCategory.Items.Insert(0, "Select");
		}
		if (Drpoption.SelectedValue == "0")
		{
			txtNo.Enabled = false;
		}
		else
		{
			txtNo.Enabled = true;
		}
		textFromDate.Attributes.Add("readonly", "readonly");
		TextToDate.Attributes.Add("readonly", "readonly");
		txtFromDateMRS.Attributes.Add("readonly", "readonly");
		txtToDateMRS.Attributes.Add("readonly", "readonly");
		txtFromDateMRN.Attributes.Add("readonly", "readonly");
		txtToDateMRN.Attributes.Add("readonly", "readonly");
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		int num = 0;
		string text = "";
		if (txtNo.Text != "")
		{
			text = txtNo.Text;
		}
		string text2 = "";
		if (CkItem.Checked)
		{
			text2 = txtItemcode.Text;
		}
		string text3 = "";
		if (CKwono.Checked)
		{
			text3 = txtwono.Text;
		}
		string text4 = "";
		if (CkSupplier.Checked)
		{
			text4 = fun.getCode(TxtSearchValue.Text);
		}
		string text5 = "";
		string text6 = "";
		if (textFromDate.Text != "" && TextToDate.Text != "")
		{
			text5 = textFromDate.Text;
			text6 = TextToDate.Text;
		}
		int num2 = 0;
		if (textFromDate.Text != "" && TextToDate.Text == "")
		{
			num2++;
		}
		if (textFromDate.Text == "" && TextToDate.Text != "")
		{
			num2++;
		}
		int num3 = 0;
		if (CkACCHead.Checked)
		{
			num3 = Convert.ToInt32(DropDownList1.SelectedValue);
		}
		num = (RadGin.Checked ? 1 : (RadGRR.Checked ? 2 : (RadGQN.Checked ? 3 : (RadGSn.Checked ? 4 : 0))));
		if (num2 == 0)
		{
			if ((Drpoption.SelectedItem.Text != "All" && txtNo.Text != "") || (Drpoption.SelectedItem.Text == "All" && !txtNo.Enabled))
			{
				if ((CkItem.Checked && txtItemcode.Text != "") || (!CkItem.Checked && txtItemcode.Text == ""))
				{
					if ((CKwono.Checked && txtwono.Text != "") || (!CKwono.Checked && txtwono.Text == ""))
					{
						if ((CkSupplier.Checked && TxtSearchValue.Text != "") || (!CkSupplier.Checked && TxtSearchValue.Text == ""))
						{
							base.Response.Redirect("Search_details.aspx?type=" + Drpoption.SelectedValue + "&No=" + text + "&RAd=" + num + "&Code=" + text2 + "&WONo=" + text3 + "&SupId=" + text4 + "&accval=" + num3 + "&FDate=" + text5 + "&TDate=" + text6);
						}
						else
						{
							string empty = string.Empty;
							empty = "Enter valid  " + CkSupplier.Text + "!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Enter valid  " + CKwono.Text + "!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Enter valid  " + CkItem.Text + "!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				if (Drpoption.SelectedValue == "1" || Drpoption.SelectedValue == "2" || Drpoption.SelectedValue == "3" || Drpoption.SelectedValue == "4" || Drpoption.SelectedValue == "5")
				{
					empty4 = "Enter valid  " + Drpoption.SelectedItem.Text + "!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
				}
			}
		}
		else
		{
			string empty5 = string.Empty;
			empty5 = "Incorrect date entry!";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void Drpoption_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Drpoption.SelectedValue == "0" || Drpoption.SelectedValue == "5")
		{
			RadPO.Checked = true;
		}
		else
		{
			RadPO.Checked = false;
		}
		if (Drpoption.SelectedValue == "1")
		{
			RadGin.Checked = true;
		}
		else
		{
			RadGin.Checked = false;
		}
		if (Drpoption.SelectedValue == "2")
		{
			RadGRR.Checked = true;
		}
		else
		{
			RadGRR.Checked = false;
		}
		if (Drpoption.SelectedValue == "3")
		{
			RadGQN.Checked = true;
		}
		else
		{
			RadGQN.Checked = false;
		}
		if (Drpoption.SelectedValue == "4")
		{
			RadGSn.Checked = true;
		}
		else
		{
			RadGSn.Checked = false;
		}
	}

	public void AcHead()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (RbtnLabour.Checked)
			{
				text = "Labour";
			}
			if (RbtnWithMaterial.Checked)
			{
				text = "With Material";
			}
			string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			DropDownList1.DataSource = dataSet;
			DropDownList1.DataTextField = "Head";
			DropDownList1.DataValueField = "Id";
			DropDownList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void btnSearchMRS_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			int num = 0;
			int num2 = 1;
			if (ddlEnterNoMRS.SelectedValue == "1" || ddlEnterNoMRS.SelectedValue == "2")
			{
				if (txtEnterNoMRS.Text != "")
				{
					text = txtEnterNoMRS.Text;
				}
				else
				{
					num = 1;
				}
			}
			if (ddlEnterNoMRS.SelectedValue == "3")
			{
				num2 = 1;
			}
			string text2 = "";
			int num3 = 0;
			if (CheBoxItemCatMRS.Checked)
			{
				if (DrpCategory.SelectedValue != "Select")
				{
					text2 = DrpCategory.SelectedValue;
				}
				else
				{
					num3 = 1;
				}
			}
			string text3 = "";
			if (CheBoxItemCodeMRS.Checked)
			{
				text3 = txtItemCodeMRS.Text;
			}
			string text4 = "";
			int num4 = 0;
			if (CheBoxEmployeeNameMRS.Checked && TxtEmpName.Text != "")
			{
				string code = fun.getCode(TxtEmpName.Text);
				int num5 = fun.chkEmpCode(code, CompId);
				if (num5 == 1 && TxtEmpName.Text != string.Empty)
				{
					text4 = code;
					num4 = 1;
				}
			}
			string text5 = "";
			if (CheBoxBGGroupMRS.Checked)
			{
				text5 = ddlDeptMRS.SelectedValue.ToString();
			}
			string text6 = "";
			int num6 = 0;
			if (CheBoxWONoMRS.Checked && txtWONoMRS.Text != "" && fun.CheckValidWONo(txtWONoMRS.Text, CompId, FinYearId))
			{
				text6 = txtWONoMRS.Text;
				num6 = 1;
			}
			string text7 = "";
			string text8 = "";
			int num7 = 1;
			int num8 = 0;
			if (txtFromDateMRS.Text != "" && txtToDateMRS.Text != "")
			{
				if (fun.DateValidation(txtFromDateMRS.Text) && fun.DateValidation(txtToDateMRS.Text))
				{
					if (Convert.ToDateTime(fun.FromDate(txtFromDateMRS.Text)) <= Convert.ToDateTime(fun.FromDate(txtToDateMRS.Text)))
					{
						text7 = txtFromDateMRS.Text;
						text8 = txtToDateMRS.Text;
						num7 = 0;
					}
					else
					{
						num7 = 1;
					}
				}
				else
				{
					num7 = 1;
				}
			}
			else if (txtFromDateMRS.Text == "" && txtToDateMRS.Text == "")
			{
				num8 = 1;
			}
			if ((CheBoxWONoMRS.Checked && num6 == 0) || (CheBoxEmployeeNameMRS.Checked && num4 == 0) || (num == 1 && num2 == 1) || (num8 != 1 && num7 == 1) || num3 == 1)
			{
				string text9 = string.Empty;
				if (CheBoxWONoMRS.Checked && num6 == 0)
				{
					text9 = "Work Order is not valid !";
				}
				else if (CheBoxEmployeeNameMRS.Checked && num4 == 0)
				{
					text9 = "Employee Name is not valid !";
				}
				else if (num == 1 && num2 == 1)
				{
					text9 = "Enter MRS or MIN number !";
				}
				else if (num8 != 1 && num7 == 1)
				{
					text9 = "Invalid Date !";
				}
				else if (num3 == 1)
				{
					text9 = "Please select Item Category !";
				}
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text9 + "');", addScriptTags: true);
			}
			else
			{
				base.Response.Redirect("SearchViewFieldMRS.aspx?MRSType=" + ddlEnterNoMRS.SelectedValue + "&MRSno=" + text + "&ICode=" + text3 + "&EmpidMRS=" + text4 + "&BGGroupMRS=" + text5 + "&WONoMRS=" + text6 + "&FDateMRS=" + text7 + "&TDateMRS=" + text8 + "&Rbtn=" + RadMRSMIN.SelectedValue + "&ICategory=" + text2);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
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

	protected void CheBoxWONoMRS_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxWONoMRS.Checked)
			{
				txtWONoMRS.Enabled = true;
			}
			if (!CheBoxWONoMRS.Checked)
			{
				txtWONoMRS.Enabled = false;
				txtWONoMRS.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxEmployeeNameMRS_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxEmployeeNameMRS.Checked)
			{
				TxtEmpName.Enabled = true;
			}
			if (!CheBoxEmployeeNameMRS.Checked)
			{
				TxtEmpName.Enabled = false;
				TxtEmpName.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxBGGroupMRS_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxBGGroupMRS.Checked)
			{
				ddlDeptMRS.Enabled = true;
			}
			if (!CheBoxBGGroupMRS.Checked)
			{
				ddlDeptMRS.Enabled = false;
				ddlDeptMRS.SelectedValue = "1";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlEnterNoMRS_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (ddlEnterNoMRS.SelectedValue == "3")
			{
				txtEnterNoMRS.Enabled = false;
				txtEnterNoMRS.Text = string.Empty;
				TxtEmpName.Enabled = false;
				TxtEmpName.Text = string.Empty;
				ddlDeptMRS.Enabled = false;
				ddlDeptMRS.SelectedValue = "1";
				txtWONoMRS.Enabled = false;
				txtWONoMRS.Text = string.Empty;
				txtItemCodeMRS.Enabled = false;
				txtItemCodeMRS.Text = string.Empty;
				CheBoxItemCodeMRS.Checked = false;
				CheBoxEmployeeNameMRS.Checked = false;
				CheBoxBGGroupMRS.Checked = false;
				CheBoxWONoMRS.Checked = false;
			}
			if (ddlEnterNoMRS.SelectedValue == "1")
			{
				txtEnterNoMRS.Enabled = true;
			}
			if (ddlEnterNoMRS.SelectedValue == "2")
			{
				txtEnterNoMRS.Enabled = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxItemCodeMRS_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxItemCodeMRS.Checked)
			{
				txtItemCodeMRS.Enabled = true;
			}
			if (!CheBoxItemCodeMRS.Checked)
			{
				txtItemCodeMRS.Enabled = false;
				txtItemCodeMRS.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlEnterNoMRN_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (ddlEnterNoMRN.SelectedValue == "3")
			{
				txtEnterNoMRN.Enabled = false;
				txtEnterNoMRN.Text = string.Empty;
				TxtEmpName1.Enabled = false;
				TxtEmpName.Text = string.Empty;
				ddlDeptMRN.Enabled = false;
				ddlDeptMRN.SelectedValue = "1";
				txtWONoMRN.Enabled = false;
				txtWONoMRN.Text = string.Empty;
				txtItemCodeMRN.Enabled = false;
				txtItemCodeMRN.Text = string.Empty;
				CheBoxItemCodeMRN.Checked = false;
				CheBoxEmployeeNameMRN.Checked = false;
				CheBoxBGGroupMRN.Checked = false;
				CheBoxWONoMRN.Checked = false;
			}
			if (ddlEnterNoMRN.SelectedValue == "1")
			{
				txtEnterNoMRN.Enabled = true;
			}
			if (ddlEnterNoMRN.SelectedValue == "2")
			{
				txtEnterNoMRN.Enabled = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxItemCodeMRN_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxItemCodeMRN.Checked)
			{
				txtItemCodeMRN.Enabled = true;
			}
			if (!CheBoxItemCodeMRN.Checked)
			{
				txtItemCodeMRN.Enabled = false;
				txtItemCodeMRN.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxEmployeeNameMRN_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxEmployeeNameMRN.Checked)
			{
				TxtEmpName1.Enabled = true;
			}
			if (!CheBoxEmployeeNameMRN.Checked)
			{
				TxtEmpName1.Enabled = false;
				TxtEmpName1.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxBGGroupMRN_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxBGGroupMRN.Checked)
			{
				ddlDeptMRN.Enabled = true;
			}
			if (!CheBoxBGGroupMRN.Checked)
			{
				ddlDeptMRN.Enabled = false;
				ddlDeptMRN.SelectedValue = "1";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheBoxWONoMRN_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxWONoMRN.Checked)
			{
				txtWONoMRN.Enabled = true;
			}
			if (!CheBoxWONoMRN.Checked)
			{
				txtWONoMRN.Enabled = false;
				txtWONoMRN.Text = string.Empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearchMRN_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			int num = 0;
			int num2 = 1;
			string empty = string.Empty;
			empty = PORate.SelectedValue.ToString();
			if (ddlEnterNoMRN.SelectedValue == "1" || ddlEnterNoMRN.SelectedValue == "2")
			{
				if (txtEnterNoMRN.Text != "")
				{
					text = txtEnterNoMRN.Text;
				}
				else
				{
					num = 1;
				}
			}
			if (ddlEnterNoMRN.SelectedValue == "3")
			{
				num2 = 1;
			}
			string text2 = "";
			if (CheBoxItemCodeMRN.Checked)
			{
				text2 = txtItemCodeMRN.Text;
			}
			string text3 = "";
			int num3 = 0;
			if (CheBoxEmployeeNameMRN.Checked && TxtEmpName1.Text != "")
			{
				string code = fun.getCode(TxtEmpName1.Text);
				int num4 = fun.chkEmpCode(code, CompId);
				if (num4 == 1 && TxtEmpName1.Text != string.Empty)
				{
					text3 = code;
					num3 = 1;
				}
			}
			string text4 = "";
			if (CheBoxBGGroupMRN.Checked)
			{
				text4 = ddlDeptMRN.SelectedValue.ToString();
			}
			string text5 = "";
			int num5 = 0;
			if (CheBoxWONoMRN.Checked && txtWONoMRN.Text != "" && fun.CheckValidWONo(txtWONoMRN.Text, CompId, FinYearId))
			{
				text5 = txtWONoMRN.Text;
				num5 = 1;
			}
			string text6 = "";
			string text7 = "";
			int num6 = 1;
			int num7 = 0;
			if (txtFromDateMRN.Text != "" && txtToDateMRN.Text != "")
			{
				if (fun.DateValidation(txtFromDateMRN.Text) && fun.DateValidation(txtToDateMRN.Text))
				{
					if (Convert.ToDateTime(fun.FromDate(txtFromDateMRN.Text)) <= Convert.ToDateTime(fun.FromDate(txtToDateMRN.Text)))
					{
						text6 = txtFromDateMRN.Text;
						text7 = txtToDateMRN.Text;
						num6 = 0;
					}
					else
					{
						num6 = 1;
					}
				}
				else
				{
					num6 = 1;
				}
			}
			else if (txtFromDateMRN.Text == "" && txtToDateMRN.Text == "")
			{
				num7 = 1;
			}
			if ((CheBoxWONoMRN.Checked && num5 == 0) || (CheBoxEmployeeNameMRN.Checked && num3 == 0) || (num == 1 && num2 == 1) || (num7 != 1 && num6 == 1))
			{
				string text8 = string.Empty;
				if (CheBoxWONoMRN.Checked && num5 == 0)
				{
					text8 = "Work Order is not valid !";
				}
				else if (CheBoxEmployeeNameMRN.Checked && num3 == 0)
				{
					text8 = "Employee Name is not valid !";
				}
				else if (num == 1 && num2 == 1)
				{
					text8 = "Enter MRN or MRQN number !";
				}
				else if (num7 != 1 && num6 == 1)
				{
					text8 = "Invalid Date !";
				}
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text8 + "');", addScriptTags: true);
			}
			else
			{
				base.Response.Redirect("SearchViewFieldMRN.aspx?MRNType=" + ddlEnterNoMRN.SelectedValue + "&MRNno=" + text + "&ICode=" + text2 + "&EmpidMRN=" + text3 + "&BGGroupMRN=" + text4 + "&WONoMRN=" + text5 + "&FDateMRN=" + text6 + "&TDateMRN=" + text7 + "&Rbtn=" + RadMRNMRQN.SelectedValue + "&GetPORate=" + empty);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CkItem_CheckedChanged(object sender, EventArgs e)
	{
		if (CkItem.Checked)
		{
			txtItemcode.Enabled = true;
		}
		else
		{
			txtItemcode.Enabled = false;
		}
	}

	protected void CKwono_CheckedChanged(object sender, EventArgs e)
	{
		if (CKwono.Checked)
		{
			txtwono.Enabled = true;
		}
		else
		{
			txtwono.Enabled = false;
		}
	}

	protected void CkSupplier_CheckedChanged(object sender, EventArgs e)
	{
		if (CkSupplier.Checked)
		{
			TxtSearchValue.Enabled = true;
		}
		else
		{
			TxtSearchValue.Enabled = false;
		}
	}

	protected void CheBoxItemCatMRS_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			if (CheBoxItemCatMRS.Checked)
			{
				DrpCategory.Enabled = true;
			}
			if (!CheBoxItemCatMRS.Checked)
			{
				DrpCategory.Enabled = false;
				DrpCategory.SelectedIndex = 0;
			}
		}
		catch (Exception)
		{
		}
	}
}

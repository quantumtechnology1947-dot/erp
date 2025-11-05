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

public class Module_MaterialManagement_Reports_Search : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected DropDownList Drpoption;

	protected TextBox txtNo;

	protected TextBox TxtSuplier;

	protected AutoCompleteExtender TxtSuplier_AutoCompleteExtender;

	protected RadioButton RadPO;

	protected RadioButton RadPR;

	protected RadioButton RadSPR;

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

	protected CheckBox CkExcise;

	protected DropDownList DDLExcies;

	protected SqlDataSource SqlDataSource2;

	protected CheckBox CheckBox8;

	protected CheckBox CheckBox9;

	protected TextBox textFromDate;

	protected CalendarExtender textFromDate_CalendarExtender;

	protected RegularExpressionValidator ReqTDate;

	protected TextBox TextToDate;

	protected CalendarExtender cd1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button BtnSearch;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			AcHead();
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		int num = 0;
		string text = "";
		if (Drpoption.SelectedValue == "1" || Drpoption.SelectedValue == "2" || Drpoption.SelectedValue == "3" || Drpoption.SelectedValue == "4" || Drpoption.SelectedValue == "5" || Drpoption.SelectedValue == "7")
		{
			if (txtNo.Text != "")
			{
				text = txtNo.Text;
			}
		}
		else
		{
			text = fun.getCode(TxtSuplier.Text);
		}
		num = (RadPO.Checked ? 1 : (RadPR.Checked ? 2 : (RadSPR.Checked ? 3 : 0)));
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
		int num2 = Convert.ToInt32(DDLExcies.SelectedValue);
		int num3 = 0;
		if (CkACCHead.Checked)
		{
			num3 = Convert.ToInt32(DropDownList1.SelectedValue);
		}
		string text7 = string.Empty;
		if (CheckBox8.Checked)
		{
			text7 = "0";
		}
		else if (CheckBox9.Checked)
		{
			text7 = "1";
		}
		if (num != 0)
		{
			base.Response.Redirect("SearchViewField.aspx?type=" + Drpoption.SelectedValue + "&No=" + text + "&RAd=" + num + "&Code=" + text2 + "&WONo=" + text3 + "&SupId=" + text4 + "&EX=" + num2 + "&accval=" + num3 + "&FDate=" + text5 + "&TDate=" + text6 + "&Status=" + text7);
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
		if (Drpoption.SelectedValue == "4")
		{
			txtwono.Enabled = false;
			txtItemcode.Enabled = true;
			TxtSearchValue.Enabled = true;
		}
		if (Drpoption.SelectedValue == "5")
		{
			txtItemcode.Enabled = false;
			txtwono.Enabled = true;
			TxtSearchValue.Enabled = true;
		}
		if (Drpoption.SelectedValue == "6")
		{
			TxtSearchValue.Enabled = false;
			TxtSearchValue.Text = string.Empty;
			txtwono.Enabled = true;
			txtItemcode.Enabled = true;
			TxtSuplier.Visible = true;
			txtNo.Visible = false;
		}
		else
		{
			TxtSuplier.Visible = false;
			txtNo.Visible = true;
		}
	}

	public void AcHead()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
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

	protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox8.Checked)
		{
			CheckBox9.Enabled = false;
		}
		else
		{
			CheckBox9.Enabled = true;
		}
	}

	protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox9.Checked)
		{
			CheckBox8.Enabled = false;
		}
		else
		{
			CheckBox8.Enabled = true;
		}
	}
}

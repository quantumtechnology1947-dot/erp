using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SysAdmin_FinancialYear_FinYrs_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	protected DropDownList DropDownNewFYCName;

	protected RequiredFieldValidator ReqCompName;

	protected ListBox ListBoxFinYear;

	protected TextBox txtFDate;

	protected CalendarExtender txtFDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtTDate;

	protected CalendarExtender txtTDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected Button btnNewSubmit;

	protected Label Label1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			fun.dropdownCompany(DropDownNewFYCName);
		}
		txtFDate.Attributes.Add("readonly", "readonly");
		txtTDate.Attributes.Add("readonly", "readonly");
	}

	protected void btnNewSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			Label1.Text = "";
			string text = fun.FromDate(txtFDate.Text);
			string text2 = fun.ToDate(txtTDate.Text);
			string text3 = fun.fYear(txtFDate.Text);
			string text4 = fun.tYear(txtTDate.Text);
			string text5 = text3 + text4;
			string selectedValue = DropDownNewFYCName.SelectedValue;
			if (txtFDate.Text != "" && txtTDate.Text != "" && DropDownNewFYCName.SelectedValue != "Select" && fun.DateValidation(txtFDate.Text) && fun.DateValidation(txtTDate.Text))
			{
				base.Response.Redirect("FinYear_New_Details.aspx?finyear=" + text5 + "&comp=" + selectedValue + "&fd=" + text + "&td=" + text2);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownNewFYCName_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Label1.Text = "";
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "Select * from tblFinancial_master where CompId=" + DropDownNewFYCName.SelectedValue.ToString();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Financial");
			ListBoxFinYear.Items.Clear();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string fDY = dataSet.Tables[0].Rows[i]["FinYearFrom"].ToString();
				string text = fun.FromDateYear(fDY);
				string tDY = dataSet.Tables[0].Rows[i]["FinYearTo"].ToString();
				string text2 = fun.ToDateYear(tDY);
				string item = text + text2;
				ListBoxFinYear.Items.Add(item);
			}
		}
		catch (Exception)
		{
		}
	}
}

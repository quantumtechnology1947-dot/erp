using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SysAdmin_FinancialYear_Update : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string msg = "";

	protected DropDownList DropDownUpFYCName;

	protected RequiredFieldValidator ReqCompName;

	protected ListBox ListBoxUpFinYear;

	protected RequiredFieldValidator ReqFinYr;

	protected TextBox txtFDate;

	protected CalendarExtender txtFDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtTDate;

	protected CalendarExtender txtTDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected Label Label1;

	protected Button Update;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				fun.dropdownCompany(DropDownUpFYCName);
			}
			Label1.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label1.Text = base.Request.QueryString["msg"];
			}
			txtFDate.Attributes.Add("readonly", "readonly");
			txtTDate.Attributes.Add("readonly", "readonly");
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
			Label1.Text = "";
			sqlConnection.Open();
			string text = DateTime.Now.ToString("yyyy-MM-dd");
			string text2 = DateTime.Now.ToString("T");
			string text3 = Session["username"].ToString();
			string text4 = fun.FromDate(txtFDate.Text);
			string text5 = fun.ToDate(txtTDate.Text);
			string text6 = fun.fYear(txtFDate.Text);
			string text7 = fun.tYear(txtTDate.Text);
			string text8 = text6 + text7;
			if (ListBoxUpFinYear.SelectedValue != "" && DropDownUpFYCName.SelectedValue != "Select" && txtFDate.Text != "" && txtTDate.Text != "" && fun.DateValidation(txtFDate.Text) && fun.DateValidation(txtTDate.Text))
			{
				string cmdText = fun.update("tblFinancial_master", "SysDate='" + text.ToString() + "',SysTime='" + text2.ToString() + "',SessionId='" + text3.ToString() + "',FinYearFrom='" + text4.ToString() + "',FinYearTo='" + text5.ToString() + "',FinYear='" + text8.ToString() + "'", "CompId='" + DropDownUpFYCName.SelectedValue + "'and FinYearId='" + ListBoxUpFinYear.SelectedValue + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				msg = "Financial year is Updated successfully.";
				Page.Response.Redirect("FinYrs_Update.aspx?msg=" + msg + "&ModId=1&SubModId=1");
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

	protected void ListBoxUpFinYear_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			msg = "";
			Label1.Text = "";
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "Select * from tblFinancial_master where CompId=" + DropDownUpFYCName.SelectedValue.ToString() + " AND FinYearId=" + ListBoxUpFinYear.SelectedValue + " ";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Financial");
			string fD = dataSet.Tables[0].Rows[0]["FinYearFrom"].ToString();
			string tD = dataSet.Tables[0].Rows[0]["FinYearTo"].ToString();
			string text = fun.FromDate(fD);
			string text2 = fun.ToDate(tD);
			txtFDate.Text = text;
			txtTDate.Text = text2;
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownUpFYCName_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			msg = "";
			Label1.Text = "";
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "Select * from tblFinancial_master where CompId=" + DropDownUpFYCName.SelectedValue.ToString();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Financial");
			ListBoxUpFinYear.Items.Clear();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string fDY = dataSet.Tables[0].Rows[i]["FinYearFrom"].ToString();
				string text = fun.FromDateYear(fDY);
				string tDY = dataSet.Tables[0].Rows[i]["FinYearTo"].ToString();
				string text2 = fun.ToDateYear(tDY);
				string text3 = text + text2;
				string value = dataSet.Tables[0].Rows[i][0].ToString();
				ListItem listItem = new ListItem();
				listItem.Text = text3;
				listItem.Value = value;
				ListBoxUpFinYear.Items.Add(listItem);
			}
		}
		catch (Exception)
		{
		}
	}
}

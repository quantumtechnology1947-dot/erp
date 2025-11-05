using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_FinancialYear_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string msg = "";

	protected DropDownList DropDownDelFYCName;

	protected RequiredFieldValidator ReqCompName;

	protected ListBox ListBoxDelFinYear;

	protected RequiredFieldValidator ReqFinYr;

	protected Label Label1;

	protected Button Delete;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		Label1.Text = "";
		if (!base.IsPostBack)
		{
			fun.dropdownCompany(DropDownDelFYCName);
		}
		if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
		{
			Label1.Text = base.Request.QueryString["msg"];
		}
		else
		{
			Label1.Text = "";
		}
	}

	protected void DropDownDelFYCName_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			Label1.Text = "";
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = "Select * from tblFinancial_master where CompId=" + DropDownDelFYCName.SelectedValue.ToString();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "Financial");
			ListBoxDelFinYear.Items.Clear();
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
				ListBoxDelFinYear.Items.Add(listItem);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ListBoxDelFinYear_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void Delete_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		msg = "";
		try
		{
			sqlConnection.Open();
			if (ListBoxDelFinYear.SelectedValue != "" && DropDownDelFYCName.SelectedValue != "Select")
			{
				string cmdText = "delete from tblFinancial_master where FinYearId='" + ListBoxDelFinYear.SelectedValue + "' AND CompId=" + DropDownDelFYCName.SelectedValue;
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				msg = "Financial year is deleted successfully.";
				Page.Response.Redirect("FinYrs_Delete.aspx?msg=" + msg + "&ModId=1&SubModId=1");
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
}

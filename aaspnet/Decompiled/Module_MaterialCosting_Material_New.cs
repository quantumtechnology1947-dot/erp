using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialCosting_Material_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected DropDownList DropDownList1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblUOM;

	protected TextBox TxtCost;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegTxtCost;

	protected TextBox TxtDate;

	protected CalendarExtender TxtDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegTxtDate;

	protected Button BtnInsert;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void BtnInsert_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		try
		{
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string text2 = fun.FromDate(TxtDate.Text);
			sqlConnection.Open();
			if (text2 != "" && TxtCost.Text != "" && fun.NumberValidationQty(TxtCost.Text) && fun.DateValidation(TxtDate.Text))
			{
				string cmdText = fun.insert("tblMLC_LiveCost", "SySDate,SysTime,CompId,FinYearId,SessionId,Material,EffDate,LiveCost", "'" + currDate + "','" + currTime + "','" + num + "','" + num2 + "','" + text + "','" + DropDownList1.SelectedValue + "','" + text2 + "','" + TxtCost.Text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		getUnitName();
	}

	protected void getUnitName()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string cmdText = fun.select("Unit_Master.Symbol,tblDG_Material.Unit", "Unit_Master,tblDG_Material", "tblDG_Material.Id=" + DropDownList1.SelectedValue + " AND Unit_Master.Id=tblDG_Material.Unit");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblUOM.Text = dataSet.Tables[0].Rows[0]["Symbol"].ToString();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_DataBound(object sender, EventArgs e)
	{
		DropDownList1.SelectedIndex = 0;
		getUnitName();
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_Moving_NonMoving_Items : Page, IRequiresSessionState
{
	protected Label lblFromDate;

	protected Label lblToDate;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RequiredFieldValidator ReqFrDate;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected RequiredFieldValidator ReqTODate;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList DrpCategory;

	protected RadioButtonList RadRate;

	protected RadioButtonList RadMovingItem;

	protected Button BtnView;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			lblMessage.Text = "";
			Txtfromdate.Attributes.Add("readonly", "readonly");
			TxtTodate.Attributes.Add("readonly", "readonly");
			SqlCommand selectCommand = new SqlCommand("Select FinYearFrom,FinYearTo From tblFinancial_master Where CompId='" + CompId + "' And FinYearId='" + FinYearId + "'", connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (!base.IsPostBack)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblFromDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0][0].ToString());
					lblToDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0][1].ToString());
				}
				SqlCommand selectCommand2 = new SqlCommand("Select CId,'['+Symbol+'] - '+CName as Category From tblDG_Category_Master", connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Category_Master");
				DrpCategory.DataSource = dataSet2.Tables["tblDG_Category_Master"];
				DrpCategory.DataTextField = "Category";
				DrpCategory.DataValueField = "CId";
				DrpCategory.DataBind();
				DrpCategory.Items.Insert(0, "Select");
				Txtfromdate.Text = lblFromDate.Text;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnView_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Txtfromdate.Text;
			string text2 = TxtTodate.Text;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			string text3 = "0";
			if (DrpCategory.SelectedValue != "Select")
			{
				text3 = DrpCategory.SelectedValue;
			}
			int num = Convert.ToInt32(RadMovingItem.SelectedValue);
			int num2 = Convert.ToInt32(RadRate.SelectedValue);
			if (Convert.ToDateTime(fun.FromDate(TxtTodate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) <= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)))
			{
				base.Response.Redirect("Moving_NonMoving_Items_Details.aspx?Cid=" + base.Server.UrlEncode(fun.Encrypt(text3.ToString())) + "&RadVal=" + base.Server.UrlEncode(fun.Encrypt(num2.ToString())) + "&FDate=" + base.Server.UrlEncode(fun.Encrypt(text)) + "&TDate=" + base.Server.UrlEncode(fun.Encrypt(text2)) + "&OpeningDt=" + base.Server.UrlEncode(fun.Encrypt(fun.FromDate(lblFromDate.Text))) + "&RPTHeader=" + num + "&Key=" + randomAlphaNumeric);
			}
			else if (Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)))
			{
				lblMessage.Text = "From date should not be Less than Opening Date!";
			}
			else
			{
				lblMessage.Text = "From date should be Less than or Equal to To Date!";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}

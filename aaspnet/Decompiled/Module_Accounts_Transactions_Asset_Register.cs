using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Asset_Register : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected DropDownList ddlCategory;

	protected DropDownList ddlSubCategory;

	protected Button btnSearch;

	protected HtmlGenericControl ifrm;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!Page.IsPostBack)
			{
				ddlCategory.Visible = false;
				ddlSubCategory.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			if (DropDownList1.SelectedValue == "1")
			{
				if (ddlCategory.SelectedValue != "0")
				{
					if (ddlCategory.SelectedValue != "0")
					{
						text = ddlCategory.SelectedValue;
					}
					if (ddlSubCategory.SelectedValue != "0")
					{
						text2 = ddlSubCategory.SelectedValue;
					}
					ifrm.Attributes.Add("src", "AssetRegister_Report.aspx?CAT=" + text + "&SCAT=" + text2 + "&Key=" + randomAlphaNumeric);
				}
				else
				{
					string empty = string.Empty;
					empty = "Please select Category";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
					ifrm.Attributes.Add("src", "AssetRegister_Report.aspx?CAT=0&SCAT=0&Key=" + randomAlphaNumeric);
				}
			}
			if (DropDownList1.SelectedValue == "0")
			{
				ifrm.Attributes.Add("src", "AssetRegister_Report.aspx?CAT=&SCAT=&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				ddlCategory.ClearSelection();
				ddlSubCategory.ClearSelection();
				ddlCategory.Visible = false;
				ddlSubCategory.Visible = false;
			}
			if (DropDownList1.SelectedValue == "1")
			{
				ddlCategory.Visible = true;
				ddlSubCategory.Visible = true;
				DataSet dataSet = new DataSet();
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS Abbrivation", "tblACC_Asset_SubCategory", "MId='0'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblACC_Asset_SubCategory");
				ddlSubCategory.DataSource = dataSet.Tables["tblACC_Asset_SubCategory"];
				ddlSubCategory.DataTextField = "Abbrivation";
				ddlSubCategory.DataValueField = "Id";
				ddlSubCategory.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (ddlCategory.SelectedIndex != 0)
			{
				DataSet dataSet = new DataSet();
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS Abbrivation", "tblACC_Asset_SubCategory", "MId='" + ddlCategory.SelectedValue + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblACC_Asset_SubCategory");
				ddlSubCategory.DataSource = dataSet.Tables["tblACC_Asset_SubCategory"];
				ddlSubCategory.DataTextField = "Abbrivation";
				ddlSubCategory.DataValueField = "Id";
				ddlSubCategory.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}
}

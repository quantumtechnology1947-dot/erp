using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Masters_ItemHistory_TPL : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private int CompId;

	private int FYId;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSubCategory;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FYId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				fun.drpDesignCategory(DrpCategory, DrpSubCategory);
			}
			fun.SearchData(DrpCategory, DrpSubCategory, DrpSearchCode, txtSearchItemCode, GridView2, CompId, FYId);
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			fun.SearchData(DrpCategory, DrpSubCategory, DrpSearchCode, txtSearchItemCode, GridView2, CompId, FYId);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			fun.SearchData(DrpCategory, DrpSubCategory, DrpSearchCode, txtSearchItemCode, GridView2, CompId, FYId);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (DrpCategory.SelectedValue != "Select Category")
			{
				string cmdText = fun.select("CId,SCId,Symbol", "tblDG_SubCategory_Master", "CId=" + DrpCategory.SelectedValue + " AND CompId='" + CompId + "'And FinYearId<='" + FYId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblDG_SubCategory_Master");
				DrpSubCategory.DataSource = dataSet.Tables["tblDG_SubCategory_Master"];
				DrpSubCategory.DataTextField = "Symbol";
				DrpSubCategory.DataValueField = "SCId";
				DrpSubCategory.DataBind();
				DrpSubCategory.Items.Insert(0, "Select SubCategory");
				fun.SearchData(DrpCategory, DrpSubCategory, DrpSearchCode, txtSearchItemCode, GridView2, CompId, FYId);
			}
			txtSearchItemCode.Text = "";
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DrpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fun.SearchData(DrpCategory, DrpSubCategory, DrpSearchCode, txtSearchItemCode, GridView2, CompId, FYId);
		}
		catch (Exception)
		{
		}
	}
}

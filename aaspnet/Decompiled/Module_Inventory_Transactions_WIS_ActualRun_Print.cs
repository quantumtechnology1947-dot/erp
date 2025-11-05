using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;

public class Module_Inventory_Transactions_WIS_ActualRun_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string Wo = "";

	private int h;

	private ReportDocument report = new ReportDocument();

	protected DropDownList DrpWOType;

	protected TextBox TxtWO;

	protected Button Button1;

	protected GridView GridView2;

	protected TabPanel TabPanel1;

	protected TextBox txtFromDate;

	protected CalendarExtender txtFromDate_CalendarExtender;

	protected TextBox txtToDate;

	protected CalendarExtender txtToDate_CalendarExtender;

	protected TextBox txtWONo;

	protected TextBox txtOverheads;

	protected RegularExpressionValidator RegtxtOverheads;

	protected RequiredFieldValidator ReqtxtOverheads;

	protected Button BtnSearch;

	protected HtmlGenericControl Iframe1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected UpdatePanel UpdatePanel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		double num = 0.0;
		if (txtWONo.Text != "")
		{
			text = "  And WONo='" + txtWONo.Text + "'";
		}
		if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
		{
			text2 = "    And SysDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
		}
		if (txtOverheads.Text != "" && fun.NumberValidationQty(txtOverheads.Text))
		{
			num = Convert.ToDouble(txtOverheads.Text);
		}
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		Iframe1.Attributes.Add("src", "WISWONO_Print_.aspx?z=" + text2 + "&Key=" + randomAlphaNumeric + "&x=" + text + "&FDate=" + text3 + "&TDate=" + text4 + "&OverHeads=" + num);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DrpWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DrpWOType.DataTextField = "Category";
				DrpWOType.DataValueField = "CId";
				DrpWOType.DataBind();
				DrpWOType.Items.Insert(0, "WO Category");
				loadgrid(Wo, h);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid(string WO, int C)
	{
		try
		{
			string value = "";
			if (TxtWO.Text != "")
			{
				value = " AND WONo='" + WO + "'";
			}
			string value2 = "";
			if (DrpWOType.SelectedValue != "WO Category")
			{
				value2 = " AND CId='" + Convert.ToInt32(DrpWOType.SelectedValue) + "'";
			}
			string value3 = "";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WIS_ActualRun_Grid", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value3;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "add")
		{
			GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblwono")).Text;
			base.Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Assembly.aspx?WONo=" + text + "&ModId=9&SubModId=53");
		}
		if (e.CommandName == "view")
		{
			GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
			string text2 = ((Label)gridViewRow2.FindControl("lblwono")).Text;
			int num = Convert.ToInt32(((DropDownList)gridViewRow2.FindControl("drpIssueShortage")).SelectedValue);
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			switch (num)
			{
			case 0:
				base.Response.Redirect("~/Module/Inventory/Transactions/WIS_View_TransWise.aspx?WONo=" + text2 + "&ModId=9&SubModId=53&Type=" + num + "&status=1");
				break;
			case 1:
				base.Response.Redirect("~/Module/Inventory/Transactions/TotalIssueAndShortage_Print.aspx?WONo=" + text2 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=53&Type=" + num + "&status=1");
				break;
			case 2:
				base.Response.Redirect("~/Module/Inventory/Transactions/TotalShortage_Print.aspx?WONo=" + text2 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=53&Type=" + num + "&status=1");
				break;
			}
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		loadgrid(Wo, h);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loadgrid(TxtWO.Text, h);
	}

	protected void DrpWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DrpWOType.SelectedValue);
			loadgrid(Wo, c);
		}
		else
		{
			loadgrid(Wo, h);
		}
	}
}

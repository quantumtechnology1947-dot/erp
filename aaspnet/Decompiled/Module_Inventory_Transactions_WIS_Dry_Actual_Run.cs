using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_WIS_Dry_Actual_Run : Page, IRequiresSessionState
{
	protected DropDownList DrpWOType;

	protected TextBox TxtWONo;

	protected Button Button1;

	protected GridView GridView2;

	protected UpdatePanel UpdatePanel1;

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

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

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
				if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
				{
					string empty = string.Empty;
					empty = "No records found.";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
					base.Request.QueryString["msg"] = "";
				}
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
			if (TxtWONo.Text != "")
			{
				value = " AND WONo='" + WO + "'";
			}
			string value2 = "";
			if (DrpWOType.SelectedValue != "WO Category")
			{
				value2 = " AND CId='" + Convert.ToInt32(DrpWOType.SelectedValue) + "'";
			}
			string value3 = " AND CloseOpen=0";
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
				base.Response.Redirect("~/Module/Inventory/Transactions/WIS_View_TransWise.aspx?WONo=" + text2 + "&ModId=9&SubModId=53&Type=" + num + "&status=0");
				break;
			case 1:
				base.Response.Redirect("~/Module/Inventory/Transactions/TotalIssueAndShortage_Print.aspx?WONo=" + text2 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=53&Type=" + num + "&status=0");
				break;
			case 2:
				base.Response.Redirect("~/Module/Inventory/Transactions/TotalShortage_Print.aspx?WONo=" + text2 + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=53&Type=" + num + "&status=0");
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
		loadgrid(TxtWONo.Text, h);
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

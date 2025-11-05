using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_WIS_View_TransWise : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

	private string connStr = "";

	private string CDate = "";

	private string CTime = "";

	private int type;

	private string Wono = "";

	private int Status;

	protected Label LblWONo;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button Cancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Status = Convert.ToInt32(base.Request.QueryString["status"]);
			SId = Session["username"].ToString();
			type = Convert.ToInt32(base.Request.QueryString["Type"]);
			Wono = base.Request.QueryString["WONo"].ToString();
			LblWONo.Text = Wono;
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				loadgrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WIS_Trans_Grid", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = Wono;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
			}
			else if (Status == 0)
			{
				base.Response.Redirect("WIS_Dry_Actual_Run.aspx?msg='1'&ModId=9&SubModId=53");
			}
			else
			{
				base.Response.Redirect("WIS_ActualRun_Print.aspx?msg='1'&ModId=9&SubModId=53");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			string text = ((Label)gridViewRow.FindControl("LblWISNo")).Text;
			string text2 = ((Label)gridViewRow.FindControl("LblId")).Text;
			base.Response.Redirect("~/Module/Inventory/Transactions/WIS_View_TransWise_print.aspx?WISNo=" + text + "&Key=" + randomAlphaNumeric + "&WISId=" + text2 + "&wn=" + Wono + "&ModId=9&SubModId=53&status=" + Status);
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		loadgrid();
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		switch (Status)
		{
		case 0:
			base.Response.Redirect("~/Module/Inventory/Transactions/WIS_Dry_Actual_Run.aspx?ModId=9&SubModId=53");
			break;
		case 1:
			base.Response.Redirect("~/Module/Inventory/Transactions/WIS_ActualRun_Print.aspx?ModId=9&SubModId=53");
			break;
		}
	}
}

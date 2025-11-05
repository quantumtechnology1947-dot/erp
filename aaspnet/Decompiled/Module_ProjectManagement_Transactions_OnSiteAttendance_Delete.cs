using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Transactions_OnSiteAttendance_Delete : Page, IRequiresSessionState
{
	protected Label Label3;

	protected TextBox textChequeDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected DropDownList drpGroupF;

	protected Button btnProceed;

	protected Panel Panel1;

	protected GridView GridView4;

	protected Panel Panel5;

	protected SqlDataSource SqlDataBG;

	private string connStr = "";

	private SqlConnection con;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			Label3.Text = textChequeDate.Text;
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			textChequeDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				FillGrid(0);
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid(int value)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetOnSiteEmp", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@BG", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@OnSiteDate", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@BG"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@OnSiteDate"].Value = fun.FromDate(textChequeDate.Text).ToString();
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView4.DataSource = dataSet;
			GridView4.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
	}

	protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView4.PageIndex = e.NewPageIndex;
		FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
	}

	protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblOnSiteAttendance_Master WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid(Convert.ToInt32(drpGroupF.SelectedValue));
		}
		catch (Exception)
		{
		}
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Cash_Bank_Entry : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string CDate = "";

	private string CTime = "";

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string connStr = string.Empty;

	private SqlConnection con;

	protected TextBox txtCashAmt;

	protected RequiredFieldValidator RequiredFieldValtxtCashAmt;

	protected RegularExpressionValidator RegularReqAmt;

	protected Button btnAdd;

	protected Label lblBank;

	protected DropDownList DrpBankName;

	protected TextBox txtBankAmt;

	protected RequiredFieldValidator RequiredFieldtxtBankAmt;

	protected RegularExpressionValidator RegularExpressiontxtBankAmt;

	protected Button btnBankAdd;

	protected GridView GridView2;

	protected Panel Panel1;

	protected GridView GridView1;

	protected Panel Panel2;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource3;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CDate = fun.getCurrDate();
		CTime = fun.getCurrTime();
		SId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		if (!base.IsPostBack)
		{
			FillGrid();
		}
	}

	public void FillGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[GetBank_Entry]", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtCashAmt.Text != "" && fun.NumberValidationQty(txtCashAmt.Text))
			{
				string cmdText = fun.insert("tblACC_CashAmt_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,Amt", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + txtCashAmt.Text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			Convert.ToDouble(((TextBox)gridViewRow.FindControl("TextBox1")).Text);
			string cmdText = fun.update("tblACC_CashAmt_Master", "[SysDate] ='" + CDate + "', [SysTime] ='" + CTime + "' ", "Id ='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			SqlDataSource1.Update();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			new DataSet();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TextBox2")).Text);
			int num3 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpBankNameE")).SelectedValue);
			string cmdText = fun.update("tblACC_BankAmt_Master", "[SysDate] ='" + CDate + "', [SysTime] ='" + CTime + "',[SessionId]='" + SId + "',[CompId] = " + CompId + ", [FinYearId] =" + FinYearId + ", [Amt] = " + num2 + ",BankId=" + num3 + " ", "Id ='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void btnBankAdd_Click(object sender, EventArgs e)
	{
		if (txtBankAmt.Text != "" && fun.NumberValidationQty(txtBankAmt.Text) && txtBankAmt.Text != "0")
		{
			string cmdText = fun.insert("tblACC_BankAmt_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,Amt,BankId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + txtBankAmt.Text + "','" + DrpBankName.SelectedValue + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			FillGrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblBankId")).Text);
			((DropDownList)gridViewRow.FindControl("DrpBankNameE")).SelectedValue = num.ToString();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_BankAmt_Master", "Id='" + num + "'"), con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			FillGrid();
		}
		catch (Exception)
		{
		}
	}
}

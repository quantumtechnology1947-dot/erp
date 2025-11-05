using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private SqlConnection con;

	private int CompId;

	private int FyId;

	private int FinYearId;

	private string MinNo = "";

	private string MrsNo = "";

	private string Emp = "";

	private string Mrs = "";

	private string connStr = "";

	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				TxtEmpName.Visible = false;
				loaddata(Mrs, Emp);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			FyId = Convert.ToInt32(((Label)gridViewRow.FindControl("lblFyId")).Text);
			MinNo = ((Label)gridViewRow.FindControl("lblMINNo")).Text;
			MrsNo = ((Label)gridViewRow.FindControl("lblMRSNo")).Text;
			string text = ((Label)gridViewRow.FindControl("Id")).Text;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("MaterialIssueNote_MIN_Print_Details.aspx?Id=" + text + "&MINNo=" + MinNo + "&MRSNo=" + MrsNo + "&FYId=" + FyId + "&Key=" + randomAlphaNumeric + "&ModId=9&SubModId=41");
			}
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpField.SelectedValue == "2")
			{
				TxtMrs.Visible = false;
				TxtEmpName.Visible = true;
				TxtEmpName.Text = "";
				loaddata(Mrs, Emp);
			}
			else
			{
				TxtMrs.Visible = true;
				TxtMrs.Text = "";
				TxtEmpName.Visible = false;
				loaddata(Mrs, Emp);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loaddata(TxtMrs.Text, TxtEmpName.Text);
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loaddata(Mrs, Emp);
		}
		catch (Exception)
		{
		}
	}

	public void loaddata(string mrsno, string empname)
	{
		try
		{
			string value = "";
			if (DrpField.SelectedValue == "0" && TxtMrs.Text != "")
			{
				value = " AND tblInv_MaterialIssue_Master.MRSNo='" + TxtMrs.Text + "'";
			}
			if (DrpField.SelectedValue == "1" && TxtMrs.Text != "")
			{
				value = " AND tblInv_MaterialIssue_Master.MINNo='" + TxtMrs.Text + "'";
			}
			string value2 = "";
			if (DrpField.SelectedValue == "2" && TxtEmpName.Text != "")
			{
				value2 = " AND tblInv_MaterialIssue_Master.SessionId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_MIN_FillGrid", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}
}

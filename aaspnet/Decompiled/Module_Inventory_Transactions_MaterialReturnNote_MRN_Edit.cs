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

public class Module_Inventory_Transactions_MaterialReturnNote_MRN_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FyId;

	private string MrnNo = "";

	private string sId = "";

	private int FinYearId;

	private string mrn = "";

	private string emp = "";

	protected DropDownList DrpField;

	protected TextBox TxtMrn;

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
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!Page.IsPostBack)
			{
				TxtMrn.Visible = false;
				fillgrid(mrn, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid(string MrnNo, string EmpName)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		new DataTable();
		try
		{
			sqlConnection.Open();
			string value = "";
			if (DrpField.SelectedValue == "1" && TxtMrn.Text != "")
			{
				value = " AND MRNNo='" + TxtMrn.Text + "'";
			}
			string value2 = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				value2 = " AND tblInv_MaterialReturn_Master.SessionId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_MRN_FillGrid", sqlConnection);
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
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			FyId = Convert.ToInt32(((Label)gridViewRow.FindControl("lblFyId")).Text);
			MrnNo = ((Label)gridViewRow.FindControl("lblMRNNo")).Text;
			string text = ((Label)gridViewRow.FindControl("Id")).Text;
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("MaterialReturnNote_MRN_Edit_Details.aspx?Id=" + text + "&MRNNo=" + MrnNo + "&FYId=" + FyId + "&ModId=9&SubModId=48");
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			fillgrid(mrn, emp);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpField.SelectedValue == "1")
			{
				TxtMrn.Visible = true;
				TxtMrn.Text = "";
				TxtEmpName.Visible = false;
				fillgrid(mrn, emp);
			}
			else
			{
				TxtMrn.Visible = false;
				TxtEmpName.Visible = true;
				TxtEmpName.Text = "";
				fillgrid(mrn, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			fillgrid(TxtMrn.Text, TxtEmpName.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			fillgrid(mrn, emp);
		}
		catch (Exception)
		{
		}
	}
}

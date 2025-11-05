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

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Delete : Page, IRequiresSessionState
{
	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtMqnNo;

	protected Button Button1;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FyId;

	private string MrnNo = "";

	private string MrqNo = "";

	private string mrqn = "";

	private string mrn = "";

	private string emp = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FinYearId = Convert.ToInt32(Session["finyear"]);
		if (!base.IsPostBack)
		{
			loadData(mrqn, mrn, emp);
		}
	}

	public void loadData(string mrqn, string mrn, string empid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string text = "";
			if (drpfield.SelectedValue == "0" && txtMqnNo.Text != "")
			{
				text = " AND  MRQNNo='" + txtMqnNo.Text + "'";
			}
			if (drpfield.SelectedValue == "Select")
			{
				txtMqnNo.Visible = true;
				txtEmpName.Visible = false;
			}
			string text2 = "";
			if (drpfield.SelectedValue == "1" && txtMqnNo.Text != "")
			{
				text2 = " AND  MRNNo='" + txtMqnNo.Text + "'";
			}
			string text3 = "";
			if (drpfield.SelectedValue == "2" && txtEmpName.Text != "")
			{
				text3 = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			SqlCommand sqlCommand = new SqlCommand(fun.select("Id,SysDate,MRNNo,MRQNNo,FinYearId,SessionId", "tblQc_MaterialReturnQuality_Master ", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "'" + text + text2 + text3 + " Order By Id Desc"), sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num = Convert.ToInt32(sqlDataReader["FinYearId"]);
				string cmdText = fun.select("FinYear,FinYearId", "tblFinancial_master", "FinYearId='" + num + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
				dataRow[3] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				if (sqlDataReader2.HasRows)
				{
					dataRow[1] = sqlDataReader2["FinYearId"].ToString();
					dataRow[2] = sqlDataReader2["FinYear"].ToString();
				}
				dataRow[5] = sqlDataReader["MRNNo"].ToString();
				dataRow[4] = sqlDataReader["MRQNNo"].ToString();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", sqlDataReader["SessionId"], "'"));
				SqlCommand sqlCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3.HasRows)
				{
					dataRow[6] = sqlDataReader3["EmpName"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			sqlConnection.Close();
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
			MrnNo = ((Label)gridViewRow.FindControl("lblMRNNo")).Text;
			MrqNo = ((Label)gridViewRow.FindControl("lblMRQNNo")).Text;
			string text = ((Label)gridViewRow.FindControl("Id")).Text;
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("MaterialReturnQualityNote_MRQN_Delete_Details.aspx?Id=" + text + "&MRNNo=" + MrnNo + "&FYId=" + FyId + "&MRQNNo=" + MrqNo + "&ModId=10&SubModId=49");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loadData(txtMqnNo.Text, txtMqnNo.Text, txtEmpName.Text);
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData(mrqn, mrn, emp);
		}
		catch (Exception)
		{
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0" || drpfield.SelectedValue == "1" || drpfield.SelectedValue == "Select")
			{
				txtMqnNo.Visible = true;
				txtMqnNo.Text = "";
				txtEmpName.Visible = false;
			}
			if (drpfield.SelectedValue == "2")
			{
				txtMqnNo.Visible = false;
				txtEmpName.Visible = true;
				txtEmpName.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
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
}

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

public class Module_QualityControl_Reports_ScrapMaterial_Report : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FyId;

	private string MrnNo = string.Empty;

	private string ScrapNo = string.Empty;

	private string MrqNo = string.Empty;

	private int FinYearId;

	private string mrqn = string.Empty;

	private string emp = string.Empty;

	protected DropDownList drpfield;

	protected TextBox txtEmpName;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected TextBox txtMqnNo;

	protected Button Button1;

	protected GridView GridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!Page.IsPostBack)
			{
				loadData(mrqn, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string mrqn, string empid)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string text = string.Empty;
			if (drpfield.SelectedValue == "0" && txtMqnNo.Text != "")
			{
				text = " AND MRQNNo='" + txtMqnNo.Text + "'";
			}
			if (drpfield.SelectedValue == "Select")
			{
				txtMqnNo.Visible = true;
				txtEmpName.Visible = false;
			}
			string text2 = string.Empty;
			if (drpfield.SelectedValue == "1" && txtMqnNo.Text != "")
			{
				text2 = " AND MRNNo='" + txtMqnNo.Text + "'";
			}
			string text3 = string.Empty;
			if (drpfield.SelectedValue == "2" && txtEmpName.Text != "")
			{
				text3 = " AND SessionId='" + fun.getCode(txtEmpName.Text) + "'";
			}
			string text4 = string.Empty;
			if (drpfield.SelectedValue == "3" && txtMqnNo.Text != "")
			{
				text4 = " AND ScrapNo='" + txtMqnNo.Text + "'";
			}
			string cmdText = fun.select(" Distinct(ScrapNo ),SysDate ,CompId  ,FinYearId  ,SessionId  ,MRQNId ", "tblQC_Scrapregister", "FinYearId<='" + FinYearId + "' And CompId='" + CompId + "' " + text4);
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRQNDATE", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ScrapNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRNDate", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				SqlCommand sqlCommand2 = new SqlCommand(fun.select("SysDate As MRQNDATE,MRNNo,MRNId,MRQNNo,FinYearId,SessionId", "tblQc_MaterialReturnQuality_Master ", " Id='" + sqlDataReader["MRQNId"].ToString() + "'" + text + text2 + text3), sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2.HasRows)
				{
					dataRow[4] = sqlDataReader2["MRNNo"].ToString();
					dataRow[3] = sqlDataReader2["MRQNNo"].ToString();
					dataRow[2] = fun.FromDateDMY(sqlDataReader2["MRQNDATE"].ToString());
					SqlCommand sqlCommand3 = new SqlCommand(fun.select("Id,SysDate As MRNDATE", "tblInv_MaterialReturn_Master ", "  Id='" + sqlDataReader2["MRNId"].ToString() + "' "), sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					if (sqlDataReader3.HasRows)
					{
						dataRow[8] = fun.FromDateDMY(sqlDataReader3["MRNDate"].ToString());
					}
					int num = Convert.ToInt32(sqlDataReader["FinYearId"]);
					string cmdText2 = fun.select("FinYear,FinYearId", "tblFinancial_master", "FinYearId='" + num + "' AND CompId='" + CompId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					string cmdText3 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", sqlDataReader["SessionId"], "'"));
					SqlCommand sqlCommand5 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader4.HasRows)
					{
						dataRow[0] = sqlDataReader4["FinYearId"].ToString();
						dataRow[1] = sqlDataReader4["FinYear"].ToString();
					}
					if (sqlDataReader5.HasRows)
					{
						dataRow[5] = sqlDataReader5["EmpName"].ToString();
					}
					if (sqlDataReader.HasRows)
					{
						dataRow[6] = sqlDataReader["ScrapNo"].ToString();
						dataRow[7] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView1.DataSource = dataTable;
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
			MrqNo = ((Label)gridViewRow.FindControl("lblMRQNNo")).Text;
			ScrapNo = ((Label)gridViewRow.FindControl("lblScrapNo")).Text;
			if (e.CommandName == "Sel")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("ScrapMaterial_Report_Details.aspx?MRNNo=" + MrnNo + "&ScrapNo=" + ScrapNo + "&FYId=" + FyId + "&MRQNNo=" + MrqNo + " &Key=" + randomAlphaNumeric + "&ModId=10&SubModId=");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData(mrqn, emp);
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtEmpName.Text);
			loadData(txtMqnNo.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0" || drpfield.SelectedValue == "1" || drpfield.SelectedValue == "3" || drpfield.SelectedValue == "Select")
			{
				loadData(mrqn, emp);
				txtMqnNo.Visible = true;
				txtMqnNo.Text = "";
				txtEmpName.Visible = false;
			}
			if (drpfield.SelectedValue == "2")
			{
				loadData(mrqn, emp);
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

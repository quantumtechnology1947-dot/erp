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

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_New : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox TxtMrn;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string mrn = "";

	private string emp = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = string.Empty;

	private SqlConnection con;

	private DataTable dt = new DataTable();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		sId = Session["username"].ToString();
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		if (!Page.IsPostBack)
		{
			fillgrid(mrn, emp);
		}
	}

	public void fillgrid(string MrnNo, string EmpName)
	{
		try
		{
			con.Open();
			string text = "";
			if (DrpField.SelectedValue == "0" && TxtMrn.Text != "")
			{
				text = " AND tblInv_MaterialReturn_Master.MRNNo='" + TxtMrn.Text + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				TxtMrn.Visible = true;
				TxtEmpName.Visible = false;
			}
			string text2 = "";
			if (DrpField.SelectedValue == "1" && TxtEmpName.Text != "")
			{
				text2 = " AND tblInv_MaterialReturn_Master.SessionId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			string cmdText = fun.select("tblInv_MaterialReturn_Master.Id,tblInv_MaterialReturn_Master.SysDate,tblInv_MaterialReturn_Master.FinYearId,tblInv_MaterialReturn_Master.MRNNo,(select Sum(tblInv_MaterialReturn_Details.RetQty) from tblInv_MaterialReturn_Details where  tblInv_MaterialReturn_Details.MId=tblInv_MaterialReturn_Master.Id) As RetQty,(select sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_AcceptedQty from tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details where tblQc_MaterialReturnQuality_Master.MRNId=tblInv_MaterialReturn_Master.Id AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId)As QAQty,FinYear,Title+'. '+EmployeeName As EmpName", "tblInv_MaterialReturn_Master,tblFinancial_master,tblHR_OfficeStaff", "tblInv_MaterialReturn_Master.FinYearId<='" + FinYearId + "' And tblHR_OfficeStaff.EmpId=tblInv_MaterialReturn_Master.SessionId And tblInv_MaterialReturn_Master.FinYearId=tblFinancial_master.FinYearId  And tblInv_MaterialReturn_Master.CompId='" + CompId + "'" + text + text2 + " Order by tblInv_MaterialReturn_Master.MRNNo Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dt.Columns.Add(new DataColumn("Id", typeof(string)));
			dt.Columns.Add(new DataColumn("FinYrsId", typeof(string)));
			dt.Columns.Add(new DataColumn("FinYrs", typeof(string)));
			dt.Columns.Add(new DataColumn("MRNNo", typeof(string)));
			dt.Columns.Add(new DataColumn("Date", typeof(string)));
			dt.Columns.Add(new DataColumn("GenBy", typeof(string)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dt.NewRow();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader["FinYearId"].ToString();
				dataRow[2] = sqlDataReader["FinYear"].ToString();
				dataRow[3] = sqlDataReader["MRNNo"].ToString();
				dataRow[4] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[5] = sqlDataReader["EmpName"].ToString();
				if (sqlDataReader["QAQty"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(decimal.Parse(sqlDataReader["QAQty"].ToString()).ToString("N3"));
				}
				if (sqlDataReader["RetQty"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(sqlDataReader["RetQty"].ToString()).ToString("N3"));
				}
				num = Math.Round(num2 - num3, 3);
				if (num > 0.0)
				{
					dt.Rows.Add(dataRow);
					dt.AcceptChanges();
				}
			}
			GridView2.DataSource = dt;
			GridView2.DataBind();
			sqlDataReader.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			dt.Clear();
			dt.Dispose();
			GC.Collect();
			con.Close();
			con.Dispose();
			GridView2.Dispose();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Sel")
		{
			try
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblfinyrsid")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblmrnno")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("MaterialReturnQualityNote_MRQN_New_Details.aspx?Id=" + text3 + "&ModId=10&SubModId=49&MRNNo=" + text2 + "&FYId=" + text);
			}
			catch (Exception)
			{
			}
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
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
			if (DrpField.SelectedValue == "0" || DrpField.SelectedValue == "Select")
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
}

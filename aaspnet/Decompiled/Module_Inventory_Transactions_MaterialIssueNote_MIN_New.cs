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

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string MRS = "";

	private string Emp = "";

	private int FinYearId;

	private int CompId;

	private string sId = "";

	private string connStr = string.Empty;

	private SqlConnection con;

	protected DropDownList DrpField;

	protected TextBox TxtMrs;

	protected TextBox TxtEmpName;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				TxtMrs.Visible = false;
				fillgrid(MRS, Emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid(string MrsNo, string EmpName)
	{
		DataTable dataTable = new DataTable();
		try
		{
			con.Open();
			string text = "";
			if (DrpField.SelectedValue == "1" && TxtMrs.Text != "")
			{
				text = " AND tblInv_MaterialRequisition_Master.MRSNo='" + TxtMrs.Text + "'";
			}
			string text2 = "";
			if (DrpField.SelectedValue == "0" && TxtEmpName.Text != "")
			{
				text2 = " AND tblInv_MaterialRequisition_Master.SessionId='" + fun.getCode(TxtEmpName.Text) + "'";
			}
			string cmdText = fun.select("tblInv_MaterialRequisition_Master.Id,tblInv_MaterialRequisition_Master.SysDate,tblInv_MaterialRequisition_Master.FinYearId,tblInv_MaterialRequisition_Master.MRSNo,FinYear,Title+'. '+EmployeeName As EmpName,(select Sum(ReqQty) from tblInv_MaterialRequisition_Details where tblInv_MaterialRequisition_Details.MId=tblInv_MaterialRequisition_Master.Id)As MRSQty,(select sum(IssueQty) from  tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details where tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.MRSId=tblInv_MaterialRequisition_Master.Id)as IssuedQty", "tblInv_MaterialRequisition_Master,tblFinancial_master,tblHR_OfficeStaff", "tblInv_MaterialRequisition_Master.FinYearId<='" + FinYearId + "' And tblFinancial_master.FinYearId=tblInv_MaterialRequisition_Master.FinYearId And tblHR_OfficeStaff.EmpId=tblInv_MaterialRequisition_Master.SessionId AND tblInv_MaterialRequisition_Master.CompId='" + CompId + "'" + text + text2 + " Order by MRSNo Desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYrsId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MRSNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			while (sqlDataReader.Read())
			{
				int num = 0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				if (sqlDataReader["IssuedQty"] != DBNull.Value)
				{
					num4 = Convert.ToDouble(decimal.Parse(sqlDataReader["IssuedQty"].ToString()).ToString("N3"));
				}
				if (sqlDataReader["MRSQty"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(decimal.Parse(sqlDataReader["MRSQty"].ToString()).ToString("N3"));
				}
				num2 = num3 - num4;
				if (num2 > 0.0)
				{
					num++;
				}
				if (num > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = sqlDataReader["Id"].ToString();
					dataRow[1] = sqlDataReader["FinYearId"].ToString();
					dataRow[2] = sqlDataReader["FinYear"].ToString();
					dataRow[3] = sqlDataReader["MRSNo"].ToString();
					dataRow[4] = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[5] = sqlDataReader["EmpName"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlDataReader.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			dataTable.Dispose();
			con.Close();
			GC.Collect();
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
				string text2 = ((Label)gridViewRow.FindControl("lblmrsno")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("MaterialIssueNote_MIN_New_Details.aspx?Id=" + text3 + "&ModId=9&SubModId=41&MRSNo=" + text2 + "&FYId=" + text);
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
			fillgrid(MRS, Emp);
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpField.SelectedValue == "0")
			{
				TxtMrs.Visible = false;
				TxtEmpName.Visible = true;
				TxtEmpName.Text = "";
				fillgrid(MRS, Emp);
			}
			else
			{
				TxtMrs.Visible = true;
				TxtMrs.Text = "";
				TxtEmpName.Visible = false;
				fillgrid(MRS, Emp);
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
			fillgrid(TxtMrs.Text, TxtEmpName.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}

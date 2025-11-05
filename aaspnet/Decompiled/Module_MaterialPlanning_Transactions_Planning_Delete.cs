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

public class Module_MaterialPlanning_Transactions_Planning_Delete : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox Txtsearch;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected Button Button1;

	protected Label lblmsg;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string No = "";

	private string Cuid = "";

	private string SId = "";

	private string str = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				txtCustName.Visible = false;
				BindData(No, Cuid);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				string text = base.Request.QueryString["msg"].ToString();
				string empty = string.Empty;
				empty = "Plan No:" + text + " has been generated";
				lblmsg.Text = empty;
			}
			else
			{
				lblmsg.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpField.SelectedValue == "0")
		{
			Txtsearch.Visible = false;
			txtCustName.Visible = true;
			txtCustName.Text = "";
			BindData(No, Cuid);
		}
		else
		{
			Txtsearch.Visible = true;
			Txtsearch.Text = "";
			txtCustName.Visible = false;
			BindData(No, Cuid);
		}
	}

	public void BindData(string no, string CuId)
	{
		try
		{
			con.Open();
			string text = "";
			if (DrpField.SelectedValue == "1" && Txtsearch.Text != "")
			{
				text = " AND WONo='" + Txtsearch.Text + "'";
			}
			if (DrpField.SelectedValue == "2" && Txtsearch.Text != "")
			{
				text = " AND PONo='" + Txtsearch.Text + "'";
			}
			if (DrpField.SelectedValue == "3" && Txtsearch.Text != "")
			{
				text = " AND EnqId='" + Txtsearch.Text + "'";
			}
			if (DrpField.SelectedValue == "Select")
			{
				Txtsearch.Visible = true;
				txtCustName.Visible = false;
			}
			string text2 = "";
			if (DrpField.SelectedValue == "0" && txtCustName.Text != "")
			{
				text2 = " AND CustomerId='" + fun.getCode(txtCustName.Text) + "'";
			}
			string cmdText = fun.select("Id,CustomerId,SessionId,EnqId,WONo,PONo,FinYearId,SysDate", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' and FinYearId<='" + FinYearId + "'" + text + text2 + "Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("Title+'. '+EmployeeName As EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'AND EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"], "' AND CompId='", CompId, "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
				}
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["CustomerId"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[7] = value;
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				string cmdText5 = fun.select("Id,WONo", "tblDG_BOM_Master", "WONo='" + dataSet.Tables[0].Rows[i]["WONO"].ToString() + "' And CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					string cmdText6 = fun.select("Id", "tblMP_Material_Master", "CompId='" + CompId + "' and FinYearId<='" + FinYearId + "' And WONo='" + dataSet5.Tables[0].Rows[0]["WONo"].ToString() + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
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
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtCustName.Text);
			BindData(Txtsearch.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		BindData(No, Cuid);
	}
}

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

public class Module_SalesDistribution_Transactions_SalesOrder_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CId = "";

	private string Eid = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	private int h;

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid, h);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindDataCust(CId, Eid, h);
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID, int C)
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				text = " AND EnqId='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtEnqId.Text != "")
			{
				text = " AND PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtEnqId.Text != "")
			{
				text = " AND WONo='" + txtEnqId.Text + "'";
			}
			string text2 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				text2 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string text3 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text3 = " AND CustomerId='" + code + "'";
			}
			string cmdText = fun.select("EnqId,Id,CustomerId,WONo,PONo,SessionId,FinYearId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_WorkOrder_Master.SysDate,CHARINDEX('-', SD_Cust_WorkOrder_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_WorkOrder_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_WorkOrder_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_WorkOrder_Master", "FinYearId<='" + FinYearId + "'   AND CloseOpen='0'  AND CompId='" + CompId + "'" + text + text3 + text2 + "Order by WONo ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[i]["CustomerId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
					}
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0]["CustomerId"].ToString();
					}
					dataRow[3] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					dataRow[8] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			SearchGridView1.DataSource = dataTable;
			SearchGridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DropDownList1.SelectedValue == "0")
		{
			txtEnqId.Visible = false;
			TxtSearchValue.Visible = true;
			TxtSearchValue.Text = "";
			BindDataCust(CId, Eid, h);
		}
		if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
		{
			txtEnqId.Visible = true;
			TxtSearchValue.Visible = false;
			txtEnqId.Text = "";
			BindDataCust(CId, Eid, h);
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
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

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("LblId")).Text);
				string text = ((Label)gridViewRow.FindControl("LblWONo")).Text;
				con.Open();
				string cmdText = fun.select("tblMM_SPR_Details.WONo", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.WONo='" + text + "' And tblMM_SPR_Master.CompId='" + CompId + "'  And tblMM_SPR_Master.Id = tblMM_SPR_Details.MId");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string cmdText2 = fun.select("tblDG_BOM_Master.WONo", "tblDG_BOM_Master", "tblDG_BOM_Master.WONo='" + text + "' And tblDG_BOM_Master.CompId='" + CompId + "'   ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("tblDG_TPL_Master.WONo", "tblDG_TPL_Master", "tblDG_TPL_Master.WONo='" + text + "' And tblDG_TPL_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter.Fill(dataSet3);
				string cmdText4 = fun.select("tblInv_MaterialReturn_Details.WONo", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Details.WONo='" + text + "' AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'  And  tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter3.Fill(dataSet4);
				string cmdText5 = fun.select("tblInv_MaterialRequisition_Details.WONo", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Details.WONo='" + text + "'   And tblInv_MaterialRequisition_Master.CompId='" + CompId + "'    And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter4.Fill(dataSet5);
				int num2 = 0;
				if (dataSet.Tables[0].Rows.Count > 0 || dataSet3.Tables[0].Rows.Count > 0 || dataSet4.Tables[0].Rows.Count > 0 || dataSet5.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
				{
					string empty = string.Empty;
					empty = "WONo is in Use. you can not delete this WONo !";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				else
				{
					string cmdText6 = fun.delete("SD_Cust_WorkOrder_Products_Details", "CompId='" + CompId + "' And MId='" + num + "' ");
					SqlCommand sqlCommand = new SqlCommand(cmdText6, con);
					sqlCommand.ExecuteNonQuery();
					string cmdText7 = fun.delete("SD_Cust_WorkOrder_Master", "Id='" + num + "' And CompId='" + CompId + "' ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText7, con);
					sqlCommand2.ExecuteNonQuery();
					num2++;
					con.Close();
				}
				if (num2 > 0)
				{
					BindDataCust(CId, Eid, h);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			BindDataCust(CId, Eid, c);
		}
		else
		{
			BindDataCust(CId, Eid, h);
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text, h);
		}
		catch (Exception)
		{
		}
	}
}

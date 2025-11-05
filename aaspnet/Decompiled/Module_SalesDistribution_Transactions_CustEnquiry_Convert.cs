using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_CustEnquiry_Convert : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CId;

	private string CId1 = "";

	private string Eid = "";

	private int FinYearId;

	private string constr = "";

	private SqlConnection con;

	protected HtmlLink Link1;

	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected ScriptManager ScriptManager1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			constr = fun.Connection();
			con = new SqlConnection(constr);
			if (!Page.IsPostBack)
			{
				txtEnqId.Visible = false;
				BindDataCust(CId1, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	public void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindDataCust(CId1, Eid);
		}
		catch (Exception)
		{
		}
	}

	public void chkStatus_OnCheckedChanged(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string text = "";
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			string text2 = gridViewRow.Cells[2].Text;
			_ = checkBox.Checked;
			string cmdText = fun.select("*", "SD_Cust_Enquiry_Master", "EnqId='" + text2 + "' and CompId='" + CId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS, "SD_Cust_Enquiry_Master");
			if (DS.Tables[0].Rows.Count > 0)
			{
				text = fun.getCustChar(DS.Tables[0].Rows[0]["CustomerName"].ToString());
				string cmdText2 = fun.select("CustomerId", "SD_Cust_master", "CustomerName like '" + text + "%' And  CompId='" + CId + "' order by CustomerId desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet = new DataSet();
				sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
				string text4;
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string text3 = dataSet.Tables[0].Rows[0][0].ToString();
					string value = text3.Substring(1);
					text4 = text + (Convert.ToInt32(value) + 1).ToString("D3");
				}
				else
				{
					text4 = text + "001";
				}
				string cmdText3 = fun.insert("SD_Cust_master", "SysDate,SysTime,SessionId,CompId,FinYearId,EnqId,CustomerId,CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark", "'" + DS.Tables[0].Rows[0]["SysDate"].ToString() + "','" + DS.Tables[0].Rows[0]["SysTime"].ToString() + "','" + DS.Tables[0].Rows[0]["SessionId"].ToString() + "','" + Convert.ToInt32(DS.Tables[0].Rows[0]["CompId"]) + "','" + Convert.ToInt32(DS.Tables[0].Rows[0]["FinYearId"]) + "','" + text2 + "','" + text4 + "','" + DS.Tables[0].Rows[0]["CustomerName"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdAddress"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdCountry"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdState"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdCity"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdPinNo"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdContactNo"].ToString() + "','" + DS.Tables[0].Rows[0]["RegdFaxNo"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkAddress"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkCountry"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkState"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkCity"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkPinNo"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkContactNo"].ToString() + "','" + DS.Tables[0].Rows[0]["WorkFaxNo"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelAddress"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelState"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelPinNo"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelContactNo"].ToString() + "','" + DS.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString() + "','" + DS.Tables[0].Rows[0]["ContactPerson"].ToString() + "','" + DS.Tables[0].Rows[0]["JuridictionCode"].ToString() + "','" + DS.Tables[0].Rows[0]["Commissionurate"].ToString() + "','" + DS.Tables[0].Rows[0]["TinVatNo"].ToString() + "','" + DS.Tables[0].Rows[0]["Email"].ToString() + "','" + DS.Tables[0].Rows[0]["EccNo"].ToString() + "','" + DS.Tables[0].Rows[0]["Divn"].ToString() + "','" + DS.Tables[0].Rows[0]["TinCstNo"].ToString() + "','" + DS.Tables[0].Rows[0]["ContactNo"].ToString() + "','" + DS.Tables[0].Rows[0]["Range"].ToString() + "','" + DS.Tables[0].Rows[0]["PanNo"].ToString() + "','" + DS.Tables[0].Rows[0]["TDSCode"].ToString() + "','" + DS.Tables[0].Rows[0]["Remark"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText4 = "UPDATE SD_Cust_Enquiry_Master SET CustomerId='" + text4 + "',Flag=1 WHERE EnqId =@EnqId And CompId='" + CId + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
				sqlCommand2.Parameters.Add("@EnqId", SqlDbType.Int).Value = text2;
				sqlCommand2.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				BindDataCust(CId1, Eid);
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

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
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

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string text = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				text = " AND CustomerId='" + code + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				text = " AND EnqId='" + txtEnqId.Text + "'";
			}
			string cmdText = fun.select("Flag,EnqId,FinYearId ,CustomerName,CustomerId,SessionId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) + 1, 2) + '-' + LEFT(SD_Cust_Enquiry_Master.SysDate,CHARINDEX('-', SD_Cust_Enquiry_Master.SysDate) - 1) + '-' + RIGHT(SD_Cust_Enquiry_Master.SysDate, CHARINDEX('-', REVERSE(SD_Cust_Enquiry_Master.SysDate)) - 1)), 103), '/', '-')AS SysDate", "SD_Cust_Enquiry_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CId + "'" + text + " And SD_Cust_Enquiry_Master.Flag=0 Order by EnqId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CustomerId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EnqId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Flag", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("Title+'.'+EmployeeName As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[1] = dataSet.Tables[0].Rows[i]["CustomerName"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["CustomerId"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["EnqId"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataRow[6] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Flag"].ToString());
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
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtEnqId.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
				txtEnqId.Text = "";
				BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}

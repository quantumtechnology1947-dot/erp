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

public class Module_Accounts_Transactions_Debit_Note : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string Sid = string.Empty;

	private int Cid;

	private int Fyid;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			Sid = Session["username"].ToString();
			Cid = Convert.ToInt32(Session["compid"]);
			Fyid = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				fillgrid();
			}
			string text = "";
			string cmdText = fun.select("*", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpList3")).SelectedValue : ((DropDownList)GridView1.FooterRow.FindControl("DrpList2")).SelectedValue);
			Session["val1"] = text;
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DebitNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Types", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SCE", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Refrence", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("typ", typeof(string)));
			string cmdText = fun.select("*", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Date"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["DebitNo"].ToString();
				string cmdText2 = fun.select("*", "tblACC_DebitType", "Id='" + dataSet.Tables[0].Rows[i]["Types"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[3] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
				dataRow[4] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["Types"].ToString()), dataSet.Tables[0].Rows[i]["SCE"].ToString(), Cid);
				dataRow[5] = dataSet.Tables[0].Rows[i]["Refrence"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["Types"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (e.CommandName == "Add")
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text = ((TextBox)gridViewRow.FindControl("txtDate2")).Text;
				int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpList2")).SelectedValue);
				string code = fun.getCode(((TextBox)gridViewRow.FindControl("txtDebitto2")).Text);
				string text2 = ((TextBox)gridViewRow.FindControl("txtReference2")).Text;
				string text3 = ((TextBox)gridViewRow.FindControl("txtParticulars2")).Text;
				string text4 = ((TextBox)gridViewRow.FindControl("txtAmt2")).Text;
				string cmdText = fun.select("DebitNo", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId='" + Fyid + "' order by DebitNo desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblACC_DebitNote");
				string text5 = "";
				text5 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["DebitNo"]) + 1).ToString("D4"));
				int num2 = fun.chkEmpCustSupplierCode(code, num, Cid);
				if (num2 == 1 && ((DropDownList)gridViewRow.FindControl("DrpList2")).SelectedValue != "0" && ((TextBox)gridViewRow.FindControl("txtDebitto2")).Text != "" && ((TextBox)gridViewRow.FindControl("txtDate2")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("txtDate2")).Text) && text4 != "" && fun.NumberValidationQty(text4))
				{
					string cmdText2 = fun.insert("tblACC_DebitNote", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,DebitNo,SCE,Amount,Refrence,Particulars,Types", "'" + currDate + "','" + currTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + text + "','" + text5 + "','" + code + "','" + Convert.ToDouble(decimal.Parse(text4).ToString("N2")) + "','" + text2 + "','" + text3 + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text6 = ((TextBox)gridViewRow2.FindControl("txtDate3")).Text;
				int num3 = Convert.ToInt32(((DropDownList)gridViewRow2.FindControl("DrpList3")).SelectedValue);
				string code2 = fun.getCode(((TextBox)gridViewRow2.FindControl("TxtSCE")).Text);
				string text7 = ((TextBox)gridViewRow2.FindControl("TxtRefrence")).Text;
				string text8 = ((TextBox)gridViewRow2.FindControl("TxtParticulars")).Text;
				string text9 = ((TextBox)gridViewRow2.FindControl("txtAmt3")).Text;
				string cmdText3 = fun.select("DebitNo", "tblACC_DebitNote", "CompId='" + Cid + "' AND FinYearId='" + Fyid + "' order by DebitNo desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string text10 = "";
				text10 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["DebitNo"]) + 1).ToString("D4"));
				int num4 = fun.chkEmpCustSupplierCode(code2, num3, Cid);
				if (num4 == 1 && ((DropDownList)gridViewRow2.FindControl("DrpList3")).SelectedValue != "0" && ((TextBox)gridViewRow2.FindControl("TxtSCE")).Text != "" && ((TextBox)gridViewRow2.FindControl("txtDate3")).Text != "" && fun.DateValidation(((TextBox)gridViewRow2.FindControl("txtDate3")).Text) && text9 != "" && fun.NumberValidationQty(text9))
				{
					string cmdText4 = fun.insert("tblACC_DebitNote", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,DebitNo,SCE,Amount,Refrence,Particulars,Types", "'" + currDate + "','" + currTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + text6 + "','" + text10 + "','" + code2 + "','" + Convert.ToDouble(decimal.Parse(text9).ToString("N2")) + "','" + text7 + "','" + text8 + "','" + num3 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
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
			fillgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			fillgrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			((DropDownList)gridViewRow.FindControl("DrpList1")).SelectedValue = ((Label)gridViewRow.FindControl("lblType1")).Text;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtDate1")).Text;
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpList1")).SelectedValue);
			string code = fun.getCode(((TextBox)gridViewRow.FindControl("txtDebitto1")).Text);
			string text2 = ((TextBox)gridViewRow.FindControl("txtReference1")).Text;
			string text3 = ((TextBox)gridViewRow.FindControl("txtParticulars1")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("txtAmt1")).Text;
			int num3 = fun.chkEmpCustSupplierCode(code, num2, Cid);
			if (num3 == 1 && ((DropDownList)gridViewRow.FindControl("DrpList1")).SelectedValue != "0" && ((TextBox)gridViewRow.FindControl("txtDebitto1")).Text != "" && ((TextBox)gridViewRow.FindControl("txtDate1")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("txtDate1")).Text) && text4 != "" && fun.NumberValidationQty(text4))
			{
				string cmdText = fun.update("tblACC_DebitNote", "Date='" + text + "',SCE='" + code + "',Amount='" + Convert.ToDouble(decimal.Parse(text4).ToString("N2")) + "',Refrence='" + text2 + "',Particulars='" + text3 + "',Types='" + num2 + "'", "Id=" + num + " And CompId='" + Cid + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView1.EditIndex = -1;
				fillgrid();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
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
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_DebitNote", "Id='" + num + "' And CompId='" + Cid + "'"), con);
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
		GridView1.EditIndex = -1;
		fillgrid();
	}

	protected void DrpList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		DropDownList dropDownList = (DropDownList)sender;
		GridViewRow gridViewRow = (GridViewRow)dropDownList.NamingContainer;
		((TextBox)gridViewRow.FindControl("txtDebitto1")).Text = "";
		string selectedValue = dropDownList.SelectedValue;
		Session["valE1"] = selectedValue;
	}

	protected void DrpList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtSCE")).Text = "";
	}

	protected void DrpList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		((TextBox)GridView1.FooterRow.FindControl("txtDebitto2")).Text = "";
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
		string selectCommandText = "";
		switch (HttpContext.Current.Session["Val1"].ToString())
		{
		case "1":
			selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' Order by EmployeeName");
			break;
		case "2":
			selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order by CustomerName");
			break;
		case "3":
			selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "' Order by SupplierName");
			break;
		}
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet);
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

	[ScriptMethod]
	[WebMethod]
	public static string[] sql2(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = "";
		switch (HttpContext.Current.Session["ValE1"].ToString())
		{
		case "1":
			selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' Order by EmployeeName");
			break;
		case "2":
			selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order by CustomerName");
			break;
		case "3":
			selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "' Order by SupplierName");
			break;
		}
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet);
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

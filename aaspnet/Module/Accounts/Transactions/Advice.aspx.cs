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

public class Module_Accounts_Transactions_Advice : Page, IRequiresSessionState
{
	protected DropDownList drptype;

	protected TextBox TextBox1;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected RequiredFieldValidator ReqEmpEdit;

	protected TextBox txtDDNo;

	protected RequiredFieldValidator ReqDDNo;

	protected TextBox textChequeDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected DropDownList DropDownList1;

	protected TextBox txtPayAt;

	protected RequiredFieldValidator ReqPayableAt;

	protected Panel Panel3;

	protected GridView GridView1;

	protected Panel Panel8;

	protected Button btnProceed;

	protected TabPanel TabPanel11;

	protected TextBox txtPayTo_Credit;

	protected AutoCompleteExtender AutoCompleteExtender3;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected Button btnSearch;

	protected Button btnRefresh;

	protected TextBox txtChequeNo_Credit;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected TextBox txtChequeDate_Credit;

	protected CalendarExtender CalendarExtender3;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected DropDownList DropDownList4;

	protected TextBox txtPayAt_Credit;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected Panel Panel4;

	protected GridView GridView4;

	protected Panel Panel5;

	protected GridView GridView5;

	protected Panel Panel10;

	protected Button btnProceed_Creditor;

	protected TabPanel TabPanel21;

	protected TextBox txtPayTo_Sal;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox TxtChequeNo_Sal;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox TxtChequeDate_Sal;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected DropDownList DropDownList2;

	protected TextBox txtPayAt_Sal;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected Panel plnSalary;

	protected GridView GridView2;

	protected Panel Panel9;

	protected Button btnProceed_Sal;

	protected TabPanel TabPanel_Sal;

	protected DropDownList drptypeOther;

	protected TextBox txtPayTo_Others;

	protected AutoCompleteExtender AutoCompleteExtender2;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtChqNo;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtChq_Date;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList DropDownList3;

	protected TextBox txtpayAt_oth;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected Panel Panel6;

	protected GridView GridView3;

	protected Panel Panel7;

	protected Button btnProceed_Oth;

	protected TabPanel TabPanel_Others;

	protected TabContainer TabContainer2;

	protected Panel Panel1;

	protected TabPanel Add;

	protected DropDownList DrpTypes;

	protected RequiredFieldValidator ReqDrpType;

	protected TextBox TxtFrom;

	protected RequiredFieldValidator ReqFrom;

	protected TextBox TxtInvoiceNo;

	protected TextBox TxtAmount;

	protected RequiredFieldValidator ReqAmount;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected TextBox TxtChequeNo;

	protected RequiredFieldValidator ReqChequeNo;

	protected TextBox TxtChequeDate;

	protected CalendarExtender TxtChequeDate_CalendarExtender;

	protected RequiredFieldValidator ReqChequeDate;

	protected RegularExpressionValidator RegBillDate0;

	protected CompareValidator CompareValidator1;

	protected TextBox TxtReceived;

	protected AutoCompleteExtender AutoCompleteExtenderR;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected TextBox TxtBank;

	protected RequiredFieldValidator ReqReceived;

	protected TextBox TxtBankAccNo;

	protected RequiredFieldValidator ReqBankAccNo;

	protected TextBox TxtClearanceDate;

	protected CalendarExtender TxtClearanceDate_CalendarExtender;

	protected RequiredFieldValidator ReqClearanceDate;

	protected RegularExpressionValidator RegBillDate;

	protected TextBox TxtNarration;

	protected Button TxtSubmit;

	protected GridView GridView6;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource3;

	protected SqlDataSource SqlDataSource5;

	protected SqlDataSource SqlDataSource6;

	protected SqlDataSource SqlDataBG;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!Page.IsPostBack)
			{
				SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				SqlCommand sqlCommand2 = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Creditor_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				FillGrid_Other();
				FillGrid_Creditors_Temp();
				FillGrid_Salary();
				FillGrid_Creditors();
				dropdownCompany(DrpTypes);
				Loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView4.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("Req16")).Visible = true;
					((RequiredFieldValidator)row.FindControl("ReqBillAgainst")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("Req16")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqBillAgainst")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string code = fun.getCode(TextBox1.Text);
			string cmdText = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_Advice_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, Convert.ToInt32(drptype.SelectedValue), CompId);
			string cmdText2 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='1'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num == 1 && TextBox1.Text != "" && txtDDNo.Text != "" && txtPayAt.Text != "" && textChequeDate.Text != "" && fun.DateValidation(textChequeDate.Text) && drptype.SelectedValue != "0")
				{
					string cmdText3 = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','1','" + code + "','" + txtDDNo.Text + "','" + fun.FromDate(textChequeDate.Text) + "','" + txtPayAt.Text + "','" + DropDownList1.SelectedValue + "','" + Convert.ToInt32(drptype.SelectedValue) + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_Advice_Payment_Details", "MId ,ProformaInvNo ,InvDate,PONo,Particular,Amount", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["ProformaInvNo"].ToString() + "','" + fun.FromDate(dataSet2.Tables[0].Rows[i]["InvDate"].ToString()) + "','" + dataSet2.Tables[0].Rows[i]["PONo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='1'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		switch (Convert.ToInt32(HttpContext.Current.Session["codetype1"]))
		{
		case 1:
		{
			string selectCommandText3 = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' Order By EmployeeName ASC");
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, sqlConnection);
			sqlDataAdapter3.Fill(dataSet, "tblHR_OfficeStaff");
			break;
		}
		case 2:
		{
			string selectCommandText2 = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order By CustomerName ASC");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			break;
		}
		case 3:
		{
			string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "' Order By SupplierName ASC");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
			break;
		}
		}
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			double num = 0.0;
			string text4 = "";
			if (e.CommandName == "Add" && ((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text != "")
			{
				text = ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Text;
				text2 = ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Text;
				text3 = ((TextBox)GridView1.FooterRow.FindControl("txtPoNoFoot")).Text;
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
				text4 = ((TextBox)GridView1.FooterRow.FindControl("txtParticularsFoot")).Text;
				SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
				SqlDataSource2.InsertParameters["SessionId"].DefaultValue = sId;
				SqlDataSource2.InsertParameters["ProformaInvNo"].DefaultValue = text;
				SqlDataSource2.InsertParameters["InvDate"].DefaultValue = text2;
				SqlDataSource2.InsertParameters["PONo"].DefaultValue = text3;
				SqlDataSource2.InsertParameters["Amount"].DefaultValue = num.ToString();
				SqlDataSource2.InsertParameters["Particular"].DefaultValue = text4;
				SqlDataSource2.InsertParameters["Types"].DefaultValue = "1";
				SqlDataSource2.Insert();
			}
			if (e.CommandName == "Add1" && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text != "")
			{
				text = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Text;
				text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Text;
				text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPo")).Text;
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
				text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtparticul")).Text;
				SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
				SqlDataSource2.InsertParameters["SessionId"].DefaultValue = sId;
				SqlDataSource2.InsertParameters["ProformaInvNo"].DefaultValue = text;
				SqlDataSource2.InsertParameters["InvDate"].DefaultValue = text2;
				SqlDataSource2.InsertParameters["PONo"].DefaultValue = text3;
				SqlDataSource2.InsertParameters["Amount"].DefaultValue = num.ToString();
				SqlDataSource2.InsertParameters["Particular"].DefaultValue = text4;
				SqlDataSource2.InsertParameters["Types"].DefaultValue = "1";
				SqlDataSource2.Insert();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = "";
			string text2 = "";
			string text3 = "";
			double num = 0.0;
			string text4 = "";
			if (((TextBox)gridViewRow.FindControl("txtAmount")).Text != "" && ((TextBox)gridViewRow.FindControl("txtAmount")).Text != "0" && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtAmount")).Text))
			{
				text = ((TextBox)gridViewRow.FindControl("txtProforInvNo")).Text;
				num = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmount")).Text).ToString("N3"));
				text2 = ((TextBox)gridViewRow.FindControl("textDate")).Text;
				text3 = ((TextBox)gridViewRow.FindControl("txtPoNo")).Text;
				text4 = ((TextBox)gridViewRow.FindControl("txtParticulars")).Text;
				SqlDataSource2.UpdateParameters["CompId"].DefaultValue = CompId.ToString();
				SqlDataSource2.UpdateParameters["SessionId"].DefaultValue = sId;
				SqlDataSource2.UpdateParameters["ProformaInvNo"].DefaultValue = text;
				SqlDataSource2.UpdateParameters["InvDate"].DefaultValue = text2;
				SqlDataSource2.UpdateParameters["PONo"].DefaultValue = text3;
				SqlDataSource2.UpdateParameters["Amount"].DefaultValue = num.ToString();
				SqlDataSource2.UpdateParameters["Particular"].DefaultValue = text4;
				SqlDataSource2.Update();
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			double num = 0.0;
			string text = "";
			if (e.CommandName == "Add" && ((TextBox)GridView2.FooterRow.FindControl("txtAmountFoot")).Text != "")
			{
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView2.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
				text = ((TextBox)GridView2.FooterRow.FindControl("txtParticularsFoot")).Text;
				string cmdText = fun.insert("tblACC_Advice_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + num + "','" + text + "','" + CompId + "','" + sId + "','2'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillGrid_Salary();
			}
			if (e.CommandName == "Add1" && ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAmt")).Text != "")
			{
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
				text = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtparticul")).Text;
				string cmdText2 = fun.insert("tblACC_Advice_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + num + "','" + text + "','" + CompId + "','" + sId + "','2'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				FillGrid_Salary();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			double num2 = 0.0;
			string text = "";
			if (((TextBox)gridViewRow.FindControl("txtAmount")).Text != "" && ((TextBox)gridViewRow.FindControl("txtAmount")).Text != "0" && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtAmount")).Text))
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmount")).Text).ToString("N3"));
				text = ((TextBox)gridViewRow.FindControl("txtParticulars")).Text;
				string cmdText = fun.update("tblACC_Advice_Payment_Temp", "Amount='" + num2 + "', Particular='" + text + "',CompId='" + CompId + "',SessionId='" + sId + "'", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView2.EditIndex = -1;
				FillGrid_Salary();
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

	protected void btnProceed_Sal_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string code = fun.getCode(txtPayTo_Sal.Text);
			string cmdText = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_Advice_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, 1, CompId);
			string cmdText2 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='2'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num == 1 && TxtChequeNo_Sal.Text != "" && TxtChequeDate_Sal.Text != "" && txtPayAt_Sal.Text != "" && txtPayTo_Sal.Text != "" && fun.DateValidation(TxtChequeDate_Sal.Text))
				{
					string cmdText3 = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','2','" + code + "','" + TxtChequeNo_Sal.Text + "','" + fun.FromDate(TxtChequeDate_Sal.Text) + "','" + txtPayAt_Sal.Text + "','" + DropDownList2.SelectedValue + "','1'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_Advice_Payment_Details", "MId,Particular,Amount", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='2'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			double num = 0.0;
			string text = "";
			string text2 = "";
			string text3 = "";
			int num2 = 1;
			if (e.CommandName == "Add")
			{
				int num3 = 0;
				if (((RadioButtonList)GridView3.FooterRow.FindControl("RadioButtonWONoGroupF")).SelectedValue == "0")
				{
					if (fun.CheckValidWONo(((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text, CompId, FinYearId) && ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text != "")
					{
						text3 = ((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Text;
					}
					else
					{
						num3++;
					}
				}
				else
				{
					num2 = Convert.ToInt32(((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).SelectedValue);
				}
				if (((TextBox)GridView3.FooterRow.FindControl("txtAmountFoot")).Text != "" && ((TextBox)GridView3.FooterRow.FindControl("txtwithingrFt")).Text != "" && num3 == 0)
				{
					num = Convert.ToDouble(decimal.Parse(((TextBox)GridView3.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
					text2 = ((TextBox)GridView3.FooterRow.FindControl("txtwithingrFt")).Text;
					text = ((TextBox)GridView3.FooterRow.FindControl("txtParticularsFoot")).Text;
					string cmdText = fun.insert("tblACC_Advice_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + num + "','" + text + "','" + text3 + "','" + num2 + "','" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillGrid_Other();
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid WONo.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			int num4 = 0;
			if (((RadioButtonList)GridView3.Controls[0].Controls[0].FindControl("RadioButtonWONoGroup")).SelectedValue == "0")
			{
				if (fun.CheckValidWONo(((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text, CompId, FinYearId) && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text != "")
				{
					text3 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Text;
				}
				else
				{
					num4++;
				}
			}
			else
			{
				num2 = Convert.ToInt32(((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).SelectedValue);
			}
			if (((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text != "" && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text != "" && num4 == 0)
			{
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
				text = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtparticul")).Text;
				text2 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtwithinGr")).Text;
				string cmdText2 = fun.insert("tblACC_Advice_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + num + "','" + text + "','" + text3 + "','" + num2 + "','" + text2 + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				FillGrid_Other();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView3.EditIndex;
			GridViewRow gridViewRow = GridView3.Rows[editIndex];
			int num = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
			double num2 = 0.0;
			string text = "";
			string text2 = "";
			string text3 = "";
			int num3 = 1;
			int num4 = 0;
			if (((RadioButtonList)gridViewRow.FindControl("RadioButtonWONoGroupE")).SelectedValue == "0")
			{
				if (((TextBox)gridViewRow.FindControl("txtWONoE")).Text != "")
				{
					if (fun.CheckValidWONo(((TextBox)gridViewRow.FindControl("txtWONoE")).Text, CompId, FinYearId))
					{
						text3 = ((TextBox)gridViewRow.FindControl("txtWONoE")).Text;
					}
					else
					{
						num4++;
					}
				}
				else
				{
					num4++;
				}
			}
			else
			{
				num3 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("drpGroupE")).SelectedValue);
			}
			if (((TextBox)gridViewRow.FindControl("txtAmount")).Text != "" && ((TextBox)gridViewRow.FindControl("txtwithGr")).Text != "" && num4 == 0)
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmount")).Text).ToString("N3"));
				text = ((TextBox)gridViewRow.FindControl("txtParticulars")).Text;
				text2 = ((TextBox)gridViewRow.FindControl("txtwithGr")).Text;
				string cmdText = "UPDATE [tblACC_Advice_Payment_Temp] SET [Amount] = '" + num2 + "', [Particular] = '" + text + "', [CompId] ='" + CompId + "', [SessionId] ='" + sId + "',[WONo]='" + text3 + "' ,[BG]='" + num3 + "',[WithinGroup]='" + text2 + "' WHERE [Id] = '" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView3.EditIndex = -1;
				FillGrid_Other();
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid Input.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
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

	protected void RadioButtonWONoGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((RadioButtonList)GridView3.Controls[0].Controls[0].FindControl("RadioButtonWONoGroup")).SelectedValue == "0")
		{
			((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Visible = true;
			((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).Visible = false;
		}
		else
		{
			((TextBox)GridView3.Controls[0].Controls[0].FindControl("txtWONo")).Visible = false;
			((DropDownList)GridView3.Controls[0].Controls[0].FindControl("drpGroup")).Visible = true;
		}
	}

	protected void btnProceed_Oth_Click(object sender, EventArgs e)
	{
		try
		{
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string code = fun.getCode(txtPayTo_Others.Text);
			string cmdText = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = Convert.ToInt32(drptypeOther.SelectedValue);
			int num2 = fun.chkEmpCustSupplierCode(code, num, CompId);
			string cmdText2 = fun.select("*", "tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='3'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num2 == 1 && txtChqNo.Text != "" && txtChq_Date.Text != "" && txtpayAt_oth.Text != "" && txtPayTo_Others.Text != "" && fun.DateValidation(txtChq_Date.Text) && num != 0)
				{
					string cmdText3 = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','3','" + code + "','" + txtChqNo.Text + "','" + fun.FromDate(txtChq_Date.Text) + "','" + txtpayAt_oth.Text + "','" + DropDownList3.SelectedValue + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText4 = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_Advice_Payment_Details", "MId,Particular,Amount,WONo,BG,WithinGroup", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "','" + dataSet2.Tables[0].Rows[i]["WONo"].ToString() + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["BG"].ToString()) + "','" + dataSet2.Tables[0].Rows[i]["WithinGroup"].ToString() + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
					string cmdText6 = fun.delete("tblACC_Advice_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='3'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
					FillGrid_Other();
					txtPayTo_Others.Text = string.Empty;
					txtChqNo.Text = string.Empty;
					txtpayAt_oth.Text = string.Empty;
					txtChq_Date.Text = string.Empty;
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonWONoGroupF_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((RadioButtonList)GridView3.FooterRow.FindControl("RadioButtonWONoGroupF")).SelectedValue == "0")
		{
			((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Visible = true;
			((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).Visible = false;
		}
		else
		{
			((TextBox)GridView3.FooterRow.FindControl("txtWONoF")).Visible = false;
			((DropDownList)GridView3.FooterRow.FindControl("drpGroupF")).Visible = true;
		}
	}

	protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView3.EditIndex = e.NewEditIndex;
			FillGrid_Other();
			int editIndex = GridView3.EditIndex;
			GridViewRow gridViewRow = GridView3.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblIdE")).Text);
			string cmdText = fun.select("BG,WONo", "tblACC_Advice_Payment_Temp", "Id='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["WONo"].ToString() != "" && dataSet.Tables[0].Rows[0]["WONo"] != DBNull.Value)
				{
					((RadioButtonList)gridViewRow.FindControl("RadioButtonWONoGroupE")).SelectedValue = "0";
					((TextBox)gridViewRow.FindControl("txtWONoE")).Text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
					return;
				}
				((RadioButtonList)gridViewRow.FindControl("RadioButtonWONoGroupE")).SelectedValue = "1";
				((DropDownList)gridViewRow.FindControl("drpGroupE")).Visible = true;
				((TextBox)gridViewRow.FindControl("txtWONoE")).Visible = false;
				((DropDownList)gridViewRow.FindControl("drpGroupE")).SelectedValue = dataSet.Tables[0].Rows[0]["BG"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonWONoGroupE_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			RadioButtonList radioButtonList = (RadioButtonList)sender;
			GridViewRow gridViewRow = (GridViewRow)radioButtonList.NamingContainer;
			if (((RadioButtonList)gridViewRow.FindControl("RadioButtonWONoGroupE")).SelectedValue == "0")
			{
				((TextBox)gridViewRow.FindControl("txtWONoE")).Visible = true;
				((DropDownList)gridViewRow.FindControl("drpGroupE")).Visible = false;
			}
			else
			{
				((TextBox)gridViewRow.FindControl("txtWONoE")).Visible = false;
				((DropDownList)gridViewRow.FindControl("drpGroupE")).Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Other()
	{
		try
		{
			new DataTable();
			string cmdText = "SELECT [tblACC_Advice_Payment_Temp].Id,Amount,Particular, (Case When WONo!='' then WONo Else 'NA' END)As WONo, [BusinessGroup].Symbol As BG,WithinGroup FROM [tblACC_BankVoucher_Payment_Temp] Inner Join [BusinessGroup] on [tblACC_BankVoucher_Payment_Temp].BG=[BusinessGroup].Id And ([SessionId] ='" + sId + "') AND ([CompId] ='" + CompId + "') And ([Types]=3)";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView3.DataSource = dataSet;
			GridView3.DataBind();
			foreach (GridViewRow row in GridView3.Rows)
			{
				string text = ((Label)row.FindControl("lblWONo")).Text;
				string text2 = ((Label)row.FindControl("lblBG")).Text;
				if (text != "NA" && text2 != "NA")
				{
					((RadioButtonList)row.FindControl("RadioButtonWONoGroup1")).SelectedValue = "0";
				}
				else if (text == "NA")
				{
					((RadioButtonList)row.FindControl("RadioButtonWONoGroup1")).SelectedValue = "1";
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Salary()
	{
		try
		{
			new DataTable();
			string cmdText = "SELECT * FROM tblACC_Advice_Payment_Temp WHERE SessionId ='" + sId + "'AND CompId = '" + CompId + "' And Types=2";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Creditors()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string code = fun.getCode(txtPayTo_Credit.Text);
			string cmdText = "SELECT tblACC_BillBooking_Master.PVEVNo, tblACC_BillBooking_Master.BillNo,tblACC_BillBooking_Master.Id ,tblACC_BillBooking_Master.BillDate,tblMM_PO_Master.PONo, tblACC_BillBooking_Details.GQNId, tblACC_BillBooking_Details.GSNId FROM tblACC_BillBooking_Details INNER JOIN tblACC_BillBooking_Master ON tblACC_BillBooking_Details.MId =tblACC_BillBooking_Master.Id INNER JOIN tblMM_PO_Master ON tblACC_BillBooking_Master.POId = tblMM_PO_Master.Id And tblACC_BillBooking_Master.SupplierId='" + code + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ActAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PaidAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BalAmt", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
				double num = 0.0;
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["GQNId"]) != 0)
				{
					string cmdText2 = "SELECT tblQc_MaterialQuality_Details.AcceptedQty FROM         tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id And tblQc_MaterialQuality_Details.MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["GQNId"]) + "' ";
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["GSNId"]) != 0)
				{
					string cmdText3 = "SELECT tblinv_MaterialServiceNote_Details.ReceivedQty FROM         tblinv_MaterialServiceNote_Details INNER JOIN tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id And tblinv_MaterialServiceNote_Details.MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["GSNId"]) + "' ";
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
				}
				dataRow[1] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
				dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
				dataRow[5] = num;
				dataRow[3] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText4 = fun.select("Sum(Amount)As Amt", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND PVEVNO='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[6] = 0;
				}
				double num2 = 0.0;
				string cmdText5 = " Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.PVEVNO='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type=4";
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				dataRow[7] = num - (Convert.ToDouble(dataRow[6]) + num2);
				if (num - (Convert.ToDouble(dataRow[6]) + num2) > 0.0)
				{
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView4.DataSource = dataTable;
			GridView4.DataBind();
			GetValidate();
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Creditors_Temp()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("*", "tblACC_Advice_Payment_Creditor_Temp", "SessionId='" + sId + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BillAgainst", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ActAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BalAmt", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				double num = 0.0;
				double num2 = 0.0;
				string cmdText2 = "SELECT tblACC_BillBooking_Master.PVEVNo,tblACC_BillBooking_Details.GQNId, tblACC_BillBooking_Details.GSNId FROM tblACC_BillBooking_Master INNER JOIN tblACC_BillBooking_Details ON tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId And tblACC_BillBooking_Master.Id='" + dataSet.Tables[0].Rows[i]["PVEVNO"].ToString() + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet2.Tables[0].Rows[0]["PVEVNo"].ToString();
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["GQNId"]) != 0)
					{
						string cmdText3 = "SELECT tblQc_MaterialQuality_Details.AcceptedQty FROM         tblQc_MaterialQuality_Details INNER JOIN tblQc_MaterialQuality_Master ON tblQc_MaterialQuality_Details.MId = tblQc_MaterialQuality_Master.Id And tblQc_MaterialQuality_Details.MId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["GQNId"]) + "' ";
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0][0].ToString()).ToString("N3"));
						}
					}
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["GSNId"]) != 0)
					{
						string cmdText4 = "SELECT tblinv_MaterialServiceNote_Details.ReceivedQty FROM         tblinv_MaterialServiceNote_Details INNER JOIN tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id And tblinv_MaterialServiceNote_Details.MId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["GSNId"]) + "' ";
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							num = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0][0].ToString()).ToString("N3"));
						}
					}
					string cmdText5 = fun.select("Sum(Amount)As Amt", "tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND PVEVNO='" + dataSet.Tables[0].Rows[i]["PVEVNo"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["Amt"] != DBNull.Value)
					{
						num2 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
					}
				}
				double num3 = 0.0;
				string cmdText6 = " Select Sum(Amount)As Amt from tblACC_Advice_Payment_Details inner join tblACC_Advice_Payment_Master on tblACC_Advice_Payment_Details.MId=tblACC_Advice_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_Advice_Payment_Details.PVEVNO='" + dataSet.Tables[0].Rows[i]["PVEVNO"].ToString() + "' And tblACC_Advice_Payment_Master.Type=4";
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num3 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				dataRow[1] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["BillAgainst"].ToString();
				dataRow[3] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"].ToString());
				dataRow[4] = num;
				dataRow[5] = num - (num2 + num3);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView5.DataSource = dataTable;
			GridView5.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid_Other();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView3.EditIndex = -1;
			FillGrid_Other();
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Creditor_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string code = fun.getCode(txtPayTo_Credit.Text);
			string cmdText = fun.select("ADNo", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, 3, CompId);
			string cmdText2 = fun.select("*", "tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num == 1 && txtPayTo_Credit.Text != "" && txtChequeNo_Credit.Text != "" && txtPayAt_Credit.Text != "" && txtChequeDate_Credit.Text != "" && fun.DateValidation(txtChequeDate_Credit.Text))
				{
					string cmdText3 = fun.insert("tblACC_Advice_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ADNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','4','" + code + "','" + txtChequeNo_Credit.Text + "','" + fun.FromDate(txtChequeDate_Credit.Text) + "','" + txtPayAt_Credit.Text + "','" + DropDownList4.SelectedValue + "','3'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_Advice_Payment_Master", "CompId='" + CompId + "' AND ADNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_Advice_Payment_Details", "MId ,PVEVNO ,BillAgainst,Amount", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["PVEVNO"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["BillAgainst"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_Advice_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					FillGrid_Creditors();
					FillGrid_Creditors_Temp();
					txtPayTo_Credit.Text = string.Empty;
					txtChequeNo_Credit.Text = string.Empty;
					txtPayAt_Credit.Text = string.Empty;
					txtChequeDate_Credit.Text = string.Empty;
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			FillGrid_Creditors();
			btnSearch.Visible = false;
			txtPayTo_Credit.Enabled = false;
			btnRefresh.Visible = true;
			Panel5.Visible = true;
			FillGrid_Creditors_Temp();
		}
		catch (Exception)
		{
		}
	}

	protected void btnRefresh_Click(object sender, EventArgs e)
	{
		FillGrid_Creditors();
		btnSearch.Visible = true;
		txtPayTo_Credit.Enabled = true;
		txtPayTo_Credit.Text = "";
		btnRefresh.Visible = false;
		Panel5.Visible = false;
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] Sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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
	public static string[] Sql2(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
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

	protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (!(e.CommandName == "AddToTemp"))
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (GridViewRow row in GridView4.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtBill_Against")).Text != "" && ((TextBox)row.FindControl("txtAmount")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtAmount")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text) != 0.0)
				{
					double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N3"));
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblBalAmt")).Text).ToString("N3"));
					if (num5 >= num4)
					{
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				foreach (GridViewRow row2 in GridView4.Rows)
				{
					if (((CheckBox)row2.FindControl("ck")).Checked && ((TextBox)row2.FindControl("txtBill_Against")).Text != "" && ((TextBox)row2.FindControl("txtAmount")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtAmount")).Text))
					{
						double num6 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtAmount")).Text).ToString("N3"));
						double num7 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblBalAmt")).Text).ToString("N3"));
						string text = ((TextBox)row2.FindControl("txtBill_Against")).Text;
						int num8 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						if (num7 >= num6)
						{
							SqlCommand sqlCommand = new SqlCommand(fun.insert("tblACC_Advice_Payment_Creditor_Temp", "CompId,SessionId,PVEVNO,BillAgainst,Amount", "'" + CompId + "','" + sId + "','" + num8 + "','" + text + "','" + num6 + "'"), sqlConnection);
							sqlCommand.ExecuteNonQuery();
							num3++;
						}
					}
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num3 > 0)
			{
				FillGrid_Creditors();
				FillGrid_Creditors_Temp();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView5.PageIndex = e.NewPageIndex;
		FillGrid_Creditors_Temp();
	}

	protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView5.EditIndex = e.NewEditIndex;
		FillGrid_Creditors_Temp();
	}

	protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView5.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Creditor_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid_Creditors_Temp();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView5_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView5.EditIndex = -1;
			FillGrid_Creditors_Temp();
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql3(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		switch (Convert.ToInt32(HttpContext.Current.Session["codetype"]))
		{
		case 1:
		{
			string selectCommandText3 = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "' Order By EmployeeName ASC");
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, sqlConnection);
			sqlDataAdapter3.Fill(dataSet, "tblHR_OfficeStaff");
			break;
		}
		case 2:
		{
			string selectCommandText2 = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order By CustomerName ASC");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			break;
		}
		case 3:
		{
			string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "' Order By SupplierName ASC");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
			sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
			break;
		}
		}
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

	protected void drptype_SelectedIndexChanged1(object sender, EventArgs e)
	{
		Session["codetype"] = drptype.SelectedValue;
		TextBox1.Text = string.Empty;
	}

	protected void drptypeOther_SelectedIndexChanged(object sender, EventArgs e)
	{
		Session["codetype1"] = drptypeOther.SelectedValue;
		txtPayTo_Others.Text = string.Empty;
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_Advice_Payment_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid_Salary();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView2.EditIndex = e.NewEditIndex;
		FillGrid_Salary();
	}

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView2.EditIndex = -1;
			FillGrid_Salary();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		FillGrid_Salary();
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		FillGrid_Other();
	}

	public void dropdownCompany(DropDownList dpdlCompany)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select1("Id,Description", "tblACC_ReceiptAgainst");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_ReceiptAgainst");
			dpdlCompany.DataSource = dataSet.Tables[0];
			dpdlCompany.DataTextField = "Description";
			dpdlCompany.DataValueField = "Id";
			dpdlCompany.DataBind();
			dpdlCompany.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	public void Loaddata()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("*", "tblACC_Advice_Received_Masters", " FinYearId<='" + FinYearId + "'  And  CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ADRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Types", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReceivedFrom", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeReceivedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BankAccNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeClearanceDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Narration", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
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
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					}
					dataRow[2] = dataSet.Tables[0].Rows[i]["ADRNo"].ToString();
					string cmdText3 = fun.select("Description", "tblACC_ReceiptAgainst", "Id='" + dataSet.Tables[0].Rows[i]["Types"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet3.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[4] = dataSet.Tables[0].Rows[i]["ReceivedFrom"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["InvoiceNo"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ChequeNo"].ToString();
					dataRow[7] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeDate"].ToString());
					dataRow[8] = fun.EmpCustSupplierNames(1, dataSet.Tables[0].Rows[i]["ChequeReceivedBy"].ToString(), CompId);
					dataRow[9] = dataSet.Tables[0].Rows[i]["BankName"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["BankAccNo"].ToString();
					dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeClearanceDate"].ToString());
					dataRow[12] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
					dataRow[13] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView6.DataSource = dataTable;
			GridView6.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void TxtSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string cmdText = fun.select("ADRNo", "tblACC_Advice_Received_Masters", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by ADRNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_Advice_Received_Masters");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["ADRNo"]) + 1).ToString("D4"));
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string code = fun.getCode(TxtReceived.Text);
			int num = fun.chkEmpCustSupplierCode(code, 1, CompId);
			con.Open();
			if (num == 1 && fun.DateValidation(TxtChequeDate.Text) && fun.DateValidation(TxtClearanceDate.Text) && fun.NumberValidationQty(TxtAmount.Text) && DrpTypes.SelectedValue != "0")
			{
				string cmdText2 = fun.insert("tblACC_Advice_Received_Masters", "SysDate,SysTime,SessionId,CompId,FinYearId, ADRNo, Types , ReceivedFrom  ,InvoiceNo , ChequeNo, ChequeDate, ChequeReceivedBy, BankName, BankAccNo , ChequeClearanceDate , Narration, Amount ", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + DrpTypes.SelectedValue + "','" + TxtFrom.Text + "','" + TxtInvoiceNo.Text + "','" + TxtChequeNo.Text + "','" + fun.FromDate(TxtChequeDate.Text) + "','" + code + "','" + TxtBank.Text + "','" + TxtBankAccNo.Text + "','" + fun.FromDate(TxtClearanceDate.Text) + "','" + TxtNarration.Text + "','" + Convert.ToDouble(decimal.Parse(TxtAmount.Text.ToString()).ToString("N2")) + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				TxtChequeDate.Text = string.Empty;
				TxtClearanceDate.Text = string.Empty;
				TxtAmount.Text = string.Empty;
				TxtNarration.Text = string.Empty;
				TxtBank.Text = string.Empty;
				TxtReceived.Text = string.Empty;
				TxtFrom.Text = string.Empty;
				TxtBankAccNo.Text = string.Empty;
				TxtInvoiceNo.Text = string.Empty;
				TxtChequeNo.Text = string.Empty;
				DrpTypes.SelectedIndex = 0;
				Loaddata();
			}
			else
			{
				string empty = string.Empty;
				empty = "Input data is invalid.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpTypes_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpTypes.SelectedValue == "5")
		{
			TxtInvoiceNo.Visible = false;
		}
		else
		{
			TxtInvoiceNo.Visible = true;
		}
	}

	protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Del")
		{
			try
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string cmdText = fun.delete("tblACC_Advice_Received_Masters", " Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				Loaddata();
				con.Close();
			}
			catch (Exception)
			{
			}
		}
	}
}

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

public class Module_Accounts_Transactions_CashVoucher_New : Page, IRequiresSessionState
{
	protected TextBox txtPaidTo;

	protected RequiredFieldValidator RequiredFieldtxtPaidTo;

	protected DropDownList ddlCodeType;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtBillNo;

	protected RequiredFieldValidator RequiredFieldBillNo;

	protected TextBox textBillDate;

	protected CalendarExtender textBillDate_CalendarExtender;

	protected RequiredFieldValidator ReqtextBillDate;

	protected RegularExpressionValidator RegtextBillDate;

	protected TextBox txtPONo;

	protected TextBox textPODate;

	protected CalendarExtender textPODate_CalendarExtender;

	protected RegularExpressionValidator RegtextPODate;

	protected TextBox txtAmount;

	protected RequiredFieldValidator RequiredFieldtxtAmount;

	protected RegularExpressionValidator RegtxtAmount;

	protected RadioButtonList RadioButtonWONoGroup;

	protected TextBox txtWONo;

	protected RequiredFieldValidator RequiredFieldtxtWONo;

	protected DropDownList drpGroup;

	protected Label LBlBudget;

	protected DropDownList drpBudgetcode;

	protected TextBox txtParticulars;

	protected RequiredFieldValidator RequiredFieldtxtParticulars;

	protected RadioButtonList RadioButtonAcHead;

	protected DropDownList drpAcHead;

	protected RequiredFieldValidator RequiredFielddrpAcHead;

	protected TextBox txtPVEVNO;

	protected Button btnPaymentAdd;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnPayProceed;

	protected TabPanel TabPanel1;

	protected TextBox txtAmountRec;

	protected RequiredFieldValidator RequiredFieldtxtAmountRec;

	protected RegularExpressionValidator RegtxtAmountRec;

	protected DropDownList ddlCodeTypeRA;

	protected TextBox txtNewCustomerNameRA;

	protected AutoCompleteExtender txtNewCustomerNameRA_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected DropDownList ddlCodeTypeRB;

	protected TextBox txtNewCustomerNameRB;

	protected AutoCompleteExtender txtNewCustomerNameRB_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected RadioButtonList RadioButtonWONoGroupRec;

	protected TextBox txtWONoRec;

	protected RequiredFieldValidator RequiredFieldtxtWONoRec;

	protected DropDownList drpGroupRec;

	protected Label LblBudget1;

	protected DropDownList drpBudgetcode1;

	protected RadioButtonList RadioButtonAcHeadRec;

	protected DropDownList drpAcHeadRec;

	protected RequiredFieldValidator RequiredFielddrpAcHeadRec;

	protected TextBox txtOthers;

	protected RequiredFieldValidator RequiredFieldtxtOthers;

	protected Button btnReceiptProceed;

	protected GridView GridView2;

	protected Panel Panel2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private string wono = "";

	private string wono1 = "";

	private string CDate = "";

	private string CTime = "";

	private string str = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				AcHead();
				WONoGroup();
				AcHeadR();
				WONoGroupR();
				FillData();
				FillDataRec();
				txtNewCustomerName.Visible = false;
				txtNewCustomerNameRA.Visible = false;
				txtNewCustomerNameRB.Visible = false;
				con.Open();
				string cmdText = fun.delete("tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnPaymentAdd_Click(object sender, EventArgs e)
	{
		con.Open();
		string text = "NA";
		string value = "1";
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		if (RadioButtonWONoGroup.SelectedValue.ToString() == "0" && txtWONo.Text != "")
		{
			if (fun.CheckValidWONo(txtWONo.Text, CompId, FinYearId))
			{
				text = txtWONo.Text;
				if (drpBudgetcode.SelectedItem.Text != "Select")
				{
					num2 = Convert.ToInt32(drpBudgetcode.SelectedValue);
					num3 = calbalbud.TotBalBudget_WONO(num2, CompId, FinYearId, text, 1);
				}
				else
				{
					string empty = string.Empty;
					empty = "Please select BudgetCode!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				num++;
			}
		}
		if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
		{
			value = drpGroup.SelectedValue.ToString();
			num3 = calbalbud.TotBalBudget_BG(Convert.ToInt32(drpGroup.SelectedValue), CompId, FinYearId, 1);
			num2 = 0;
		}
		string cmdText = fun.select("Sum(Amount) As Amt", "tblACC_CashVoucher_Payment_Temp", "SessionId='" + SId + "'  ");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double num4 = 0.0;
		if (dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num4 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
		}
		string cmdText2 = fun.select("Amount", "tblACC_CashAmtLimit", " Active='1'");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2);
		double num5 = 0.0;
		DataSet dataSet3 = new DataSet();
		num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
		double num6 = Convert.ToDouble(txtAmount.Text);
		string text2 = "";
		int num7 = 0;
		text2 = txtPVEVNO.Text;
		if (txtPVEVNO.Text != "")
		{
			string cmdText3 = fun.select("Id", "tblACC_BillBooking_Master", "CompId='" + CompId + "' And  FinYearId='" + FinYearId + "'   And PVEVNo='" + txtPVEVNO.Text + "'     ");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3);
			num7 = ((dataSet3.Tables[0].Rows.Count > 0) ? 1 : 0);
		}
		else
		{
			num7 = 1;
		}
		if (num7 == 1)
		{
			if (num3 >= num4 + num6)
			{
				if (num5 >= num4 + num6)
				{
					if (num == 0 && txtBillNo.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) && txtParticulars.Text != "" && txtAmount.Text != "" && txtAmount.Text != "0" && fun.NumberValidationQty(txtAmount.Text))
					{
						string cmdText4 = fun.insert("tblACC_CashVoucher_Payment_Temp", "CompId,SessionId,BillNo,BillDate,PONo,PODate,Particulars,WONo,BGGroup,AcHead,Amount,BudgetCode,PVEVNo", "'" + CompId + "','" + SId + "','" + txtBillNo.Text + "','" + fun.FromDate(textBillDate.Text) + "','" + txtPONo.Text + "','" + fun.FromDate(textPODate.Text) + "','" + txtParticulars.Text + "','" + text + "','" + Convert.ToInt32(value) + "','" + drpAcHead.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtAmount.Text).ToString("N2")) + "','" + num2 + "','" + text2 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText4, con);
						sqlCommand.ExecuteNonQuery();
						con.Close();
						FillData();
						txtBillNo.Text = "";
						textBillDate.Text = "";
						txtPONo.Text = "";
						textPODate.Text = "";
						txtParticulars.Text = "";
						txtAmount.Text = "";
						txtWONo.Text = "";
						txtPVEVNO.Text = "";
						RadioButtonWONoGroup.SelectedValue = "0";
						RadioButtonAcHead.SelectedValue = "0";
						WONoGroup();
						AcHead();
						TabContainer1.ActiveTabIndex = 0;
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Invalid input data";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Cash voucher Amt exceeds The Cash Limit!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Amt exceeds the balanced budget Amt!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		else
		{
			string empty5 = string.Empty;
			empty5 = "Enter correct PVEV No.!";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
		}
	}

	public void WONoGroup()
	{
		try
		{
			if (RadioButtonWONoGroup.SelectedValue.ToString() == "0")
			{
				wono = txtWONo.Text;
				drpGroup.Visible = false;
				txtWONo.Visible = true;
				RequiredFieldtxtWONo.Visible = true;
				drpBudgetcode.Visible = true;
				LBlBudget.Visible = true;
				string cmdText = fun.select1("Description+'['+Symbol+']'  As Description,Id ", " tblMIS_BudgetCode");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblMIS_BudgetCode");
				drpBudgetcode.DataSource = dataSet;
				drpBudgetcode.DataTextField = "Description";
				drpBudgetcode.DataValueField = "Id";
				drpBudgetcode.DataBind();
				drpBudgetcode.Items.Insert(0, "Select");
			}
			if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
			{
				LBlBudget.Visible = false;
				drpBudgetcode.Visible = false;
				drpGroup.Visible = true;
				txtWONo.Visible = false;
				txtWONo.Text = "";
				RequiredFieldtxtWONo.Visible = false;
				string cmdText2 = fun.select1("Symbol,Id ", " BusinessGroup");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "BusinessGroup");
				drpGroup.DataSource = dataSet2;
				drpGroup.DataTextField = "Symbol";
				drpGroup.DataValueField = "Id";
				drpGroup.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	public void AcHead()
	{
		try
		{
			string text = "";
			if (RadioButtonAcHead.SelectedValue.ToString() == "0")
			{
				text = "Labour";
			}
			if (RadioButtonAcHead.SelectedValue.ToString() == "1")
			{
				text = "With Material";
			}
			if (RadioButtonAcHead.SelectedValue.ToString() == "2")
			{
				text = "Expenses";
			}
			if (RadioButtonAcHead.SelectedValue.ToString() == "3")
			{
				text = "Service Provider";
			}
			string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			drpAcHead.DataSource = dataSet;
			drpAcHead.DataTextField = "Head";
			drpAcHead.DataValueField = "Id";
			drpAcHead.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonAcHead_SelectedIndexChanged(object sender, EventArgs e)
	{
		AcHead();
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void RadioButtonWONoGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		WONoGroup();
		TabContainer1.ActiveTabIndex = 0;
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
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

	[ScriptMethod]
	[WebMethod]
	public static string[] sql1(string prefixText, int count, string contextKey)
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

	[ScriptMethod]
	[WebMethod]
	public static string[] sql2(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		switch (Convert.ToInt32(HttpContext.Current.Session["codetype2"]))
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

	protected void btnPayProceed_Click(object sender, EventArgs e)
	{
		try
		{
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string code = fun.getCode(txtNewCustomerName.Text);
			string cmdText = fun.select("CVPNo", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_CashVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				int num = Convert.ToInt32(ddlCodeType.SelectedValue);
				int num2 = fun.chkEmpCustSupplierCode(code, num, CompId);
				if (num2 == 1 && txtNewCustomerName.Text != "" && txtPaidTo.Text != "" && ddlCodeType.SelectedValue != "0")
				{
					string cmdText3 = fun.insert("tblACC_CashVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CVPNo,PaidTo,ReceivedBy,CodeType", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + txtPaidTo.Text + "','" + code + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText4 = fun.select("Id", "tblACC_CashVoucher_Payment_Master", "CompId='" + CompId + "' AND CVPNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_CashVoucher_Payment_Details", "MId ,BillNo ,BillDate,PONo,PODate ,Particulars,WONo,BGGroup ,AcHead ,Amount,BudgetCode,PVEVNo", string.Concat("'", text2, "','", dataSet2.Tables[0].Rows[i]["BillNo"].ToString(), "','", dataSet2.Tables[0].Rows[i]["BillDate"].ToString(), "','", dataSet2.Tables[0].Rows[i]["PONo"].ToString(), "','", dataSet2.Tables[0].Rows[i]["PODate"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Particulars"].ToString(), "','", dataSet2.Tables[0].Rows[i]["WONo"].ToString(), "','", dataSet2.Tables[0].Rows[i]["BGGroup"], "','", dataSet2.Tables[0].Rows[i]["AcHead"], "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")), "','", dataSet2.Tables[0].Rows[i]["BudgetCode"].ToString(), "','", dataSet2.Tables[0].Rows[i]["PVEVNo"].ToString(), "'"));
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
					string cmdText6 = fun.delete("tblACC_CashVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					TabContainer1.ActiveTabIndex = 0;
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

	public void FillData()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SessionId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			string cmdText = "SELECT tblACC_CashVoucher_Payment_Temp.PVEVNo,tblACC_CashVoucher_Payment_Temp.BudgetCode, [tblACC_CashVoucher_Payment_Temp].[Id],[tblACC_CashVoucher_Payment_Temp].[CompId],[tblACC_CashVoucher_Payment_Temp].[SessionId] ,[tblACC_CashVoucher_Payment_Temp].[BillNo],[tblACC_CashVoucher_Payment_Temp].[PONo],[tblACC_CashVoucher_Payment_Temp].[BillDate],tblACC_CashVoucher_Payment_Temp.PODate,[tblACC_CashVoucher_Payment_Temp].[Particulars],[tblACC_CashVoucher_Payment_Temp].[WONo] ,[BusinessGroup].[Symbol] AS [BGGroup], '['+AccHead.Symbol+'] '+AccHead.Description AS AcHead,[Amount]FROM [tblACC_CashVoucher_Payment_Temp]inner join [AccHead] on [tblACC_CashVoucher_Payment_Temp].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on [tblACC_CashVoucher_Payment_Temp].[BGGroup]=[BusinessGroup].[Id]      AND [tblACC_CashVoucher_Payment_Temp].[SessionId]='" + SId + "'  Order by [tblACC_CashVoucher_Payment_Temp].[Id] Desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["SessionId"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
				dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
				if (dataSet.Tables[0].Rows[i]["PONo"] != DBNull.Value)
				{
					dataRow[5] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				}
				if (dataSet.Tables[0].Rows[i]["PODate"] != DBNull.Value)
				{
					dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["PODate"].ToString());
				}
				else
				{
					dataRow[5] = "NA";
					dataRow[6] = "NA";
				}
				dataRow[7] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["BGGroup"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["AcHead"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				dataRow[13] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["BudgetCode"]) != 0)
				{
					string cmdText2 = fun.select("tblMIS_BudgetCode.Description+'['+tblMIS_BudgetCode.Symbol+']'  As Description ", " tblMIS_BudgetCode", "Id='" + Convert.ToDouble(dataSet.Tables[0].Rows[i]["BudgetCode"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[12] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
				}
				else
				{
					dataRow[12] = "NA";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Del")
		{
			try
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string cmdText = fun.delete("tblACC_CashVoucher_Payment_Temp", "Id='" + text + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillData();
			}
			catch (Exception)
			{
			}
		}
	}

	protected void btnReceiptProceed_Click(object sender, EventArgs e)
	{
		try
		{
			DataSet dataSet = new DataSet();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string cmdText = fun.select("CVRNo", "tblACC_CashVoucher_Receipt_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_CashVoucher_Receipt_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string code = fun.getCode(txtNewCustomerNameRA.Text);
			int num = Convert.ToInt32(ddlCodeTypeRA.SelectedValue);
			int num2 = fun.chkEmpCustSupplierCode(code, num, CompId);
			string code2 = fun.getCode(txtNewCustomerNameRB.Text);
			int num3 = Convert.ToInt32(ddlCodeTypeRB.SelectedValue);
			int num4 = fun.chkEmpCustSupplierCode(code2, num3, CompId);
			string text2 = "NA";
			string value = "1";
			int num5 = 0;
			int num6 = 0;
			if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "0" && txtWONoRec.Text != "")
			{
				if (fun.CheckValidWONo(txtWONoRec.Text, CompId, FinYearId))
				{
					text2 = txtWONoRec.Text;
					num6 = Convert.ToInt32(drpBudgetcode1.SelectedValue);
				}
				else
				{
					num5++;
				}
			}
			if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "1")
			{
				value = drpGroupRec.SelectedValue.ToString();
			}
			if (num2 == 1 && num4 == 1 && num5 == 0 && txtAmountRec.Text != "" && txtOthers.Text != "" && txtNewCustomerNameRA.Text != "" && txtNewCustomerNameRB.Text != "" && fun.NumberValidationQty(txtAmountRec.Text))
			{
				string cmdText2 = fun.insert("tblACC_CashVoucher_Receipt_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CVRNo,CashReceivedAgainst,CashReceivedBy,WONo,BGGroup,AcHead,Amount,Others,CodeTypeRA,CodeTypeRB,BudgetCode", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + code + "','" + code2 + "','" + text2 + "','" + Convert.ToInt32(value) + "','" + drpAcHeadRec.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtAmountRec.Text).ToString("N2")) + "','" + txtOthers.Text + "','" + num + "','" + num3 + "','" + num6 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillDataRec();
				txtAmountRec.Text = "";
				txtOthers.Text = "";
				txtNewCustomerNameRA.Text = "";
				txtNewCustomerNameRB.Text = "";
				txtWONoRec.Text = "";
				RadioButtonWONoGroupRec.SelectedValue = "0";
				RadioButtonAcHeadRec.SelectedValue = "0";
				WONoGroupR();
				AcHeadR();
				TabContainer1.ActiveTabIndex = 1;
			}
			else
			{
				string empty = string.Empty;
				empty = "Entered WO No is not valid!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void WONoGroupR()
	{
		try
		{
			if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "0")
			{
				wono1 = txtWONoRec.Text;
				drpGroupRec.Visible = false;
				txtWONoRec.Visible = true;
				RequiredFieldtxtWONoRec.Visible = true;
				drpBudgetcode1.Visible = true;
				LblBudget1.Visible = true;
				string cmdText = fun.select1("Description+'['+Symbol+']'  As Description,Id ", " tblMIS_BudgetCode");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblMIS_BudgetCode");
				drpBudgetcode1.DataSource = dataSet;
				drpBudgetcode1.DataTextField = "Description";
				drpBudgetcode1.DataValueField = "Id";
				drpBudgetcode1.DataBind();
				drpBudgetcode1.Items.Insert(0, "Select");
			}
			if (RadioButtonWONoGroupRec.SelectedValue.ToString() == "1")
			{
				drpBudgetcode1.Visible = false;
				LblBudget1.Visible = false;
				drpGroupRec.Visible = true;
				txtWONoRec.Visible = false;
				txtWONoRec.Text = "";
				RequiredFieldtxtWONoRec.Visible = false;
				string cmdText2 = fun.select1("Symbol,Id ", " BusinessGroup");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "BusinessGroup");
				drpGroupRec.DataSource = dataSet2;
				drpGroupRec.DataTextField = "Symbol";
				drpGroupRec.DataValueField = "Id";
				drpGroupRec.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	public void AcHeadR()
	{
		try
		{
			string text = "";
			if (RadioButtonAcHeadRec.SelectedValue.ToString() == "0")
			{
				text = "Labour";
			}
			if (RadioButtonAcHeadRec.SelectedValue.ToString() == "1")
			{
				text = "With Material";
			}
			if (RadioButtonAcHeadRec.SelectedValue.ToString() == "2")
			{
				text = "Expenses";
			}
			if (RadioButtonAcHeadRec.SelectedValue.ToString() == "3")
			{
				text = "Service Provider";
			}
			string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			drpAcHeadRec.DataSource = dataSet;
			drpAcHeadRec.DataTextField = "Head";
			drpAcHeadRec.DataValueField = "Id";
			drpAcHeadRec.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonWONoGroupRec_SelectedIndexChanged(object sender, EventArgs e)
	{
		WONoGroupR();
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void RadioButtonAcHeadRec_SelectedIndexChanged(object sender, EventArgs e)
	{
		AcHeadR();
		TabContainer1.ActiveTabIndex = 1;
	}

	public void FillDataRec()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SessionId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CVRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedAgainst", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CashReceivedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BGGroup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Others", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CodeTypeRA", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CodeTypeRB", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
			string cmdText = "SELECT tblACC_CashVoucher_Receipt_Master.BudgetCode,[tblACC_CashVoucher_Receipt_Master].[Id],REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblACC_CashVoucher_Receipt_Master].[SysDate] , CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate] ) + 1, 2) + '-' + LEFT([tblACC_CashVoucher_Receipt_Master].[SysDate],CHARINDEX('-',[tblACC_CashVoucher_Receipt_Master].[SysDate]) - 1) + '-' + RIGHT([tblACC_CashVoucher_Receipt_Master].[SysDate], CHARINDEX('-', REVERSE([tblACC_CashVoucher_Receipt_Master].[SysDate])) - 1)), 103), '/', '-') AS  [SysDate],[tblACC_CashVoucher_Receipt_Master].[SysTime],[tblACC_CashVoucher_Receipt_Master].[CompId],[tblACC_CashVoucher_Receipt_Master].[FinYearId],[tblACC_CashVoucher_Receipt_Master].[SessionId],[tblACC_CashVoucher_Receipt_Master].[CVRNo],[tblACC_CashVoucher_Receipt_Master].[CashReceivedAgainst],[tblACC_CashVoucher_Receipt_Master].[CashReceivedBy],[tblACC_CashVoucher_Receipt_Master].[WONo],[BusinessGroup].[Symbol] AS [BGGroup],'['+AccHead.Symbol+'] '+AccHead.Description AS [AcHead],[tblACC_CashVoucher_Receipt_Master].[Amount],[tblACC_CashVoucher_Receipt_Master].[Others],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRA],[tblACC_CashVoucher_Receipt_Master].[CodeTypeRB] FROM [tblACC_CashVoucher_Receipt_Master]inner join [AccHead] on [tblACC_CashVoucher_Receipt_Master].[AcHead]=[AccHead].[Id] inner join [BusinessGroup] on[tblACC_CashVoucher_Receipt_Master].[BGGroup]=[BusinessGroup].[Id] Order by [tblACC_CashVoucher_Receipt_Master].[Id] Desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["SysDate"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["SessionId"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["SessionId"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["CompId"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["CVRNo"].ToString();
				dataRow[7] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRA"].ToString()), dataSet.Tables[0].Rows[i]["CashReceivedAgainst"].ToString(), CompId);
				dataRow[8] = fun.EmpCustSupplierNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["CodeTypeRB"].ToString()), dataSet.Tables[0].Rows[i]["CashReceivedBy"].ToString(), CompId);
				dataRow[9] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["BGGroup"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["AcHead"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				dataRow[13] = dataSet.Tables[0].Rows[i]["Others"].ToString();
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["BudgetCode"]) != 0)
				{
					string cmdText2 = fun.select("tblMIS_BudgetCode.Description+'['+tblMIS_BudgetCode.Symbol+']'  As Description ", " tblMIS_BudgetCode", "Id='" + Convert.ToDouble(dataSet.Tables[0].Rows[i]["BudgetCode"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[16] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
				}
				else
				{
					dataRow[16] = "NA";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
	{
		Session["codetype"] = ddlCodeType.SelectedValue;
		if (ddlCodeType.SelectedValue == "0")
		{
			txtNewCustomerName.Visible = false;
			txtNewCustomerName.Text = "";
		}
		else
		{
			txtNewCustomerName.Visible = true;
			txtNewCustomerName.Text = "";
		}
		TabContainer1.ActiveTabIndex = 0;
	}

	protected void ddlCodeTypeRA_SelectedIndexChanged(object sender, EventArgs e)
	{
		Session["codetype1"] = ddlCodeTypeRA.SelectedValue;
		if (ddlCodeTypeRA.SelectedValue == "0")
		{
			txtNewCustomerNameRA.Visible = false;
			txtNewCustomerNameRA.Text = "";
		}
		else
		{
			txtNewCustomerNameRA.Visible = true;
			txtNewCustomerNameRA.Text = "";
		}
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void ddlCodeTypeRB_SelectedIndexChanged(object sender, EventArgs e)
	{
		Session["codetype2"] = ddlCodeTypeRB.SelectedValue;
		if (ddlCodeTypeRB.SelectedValue == "0")
		{
			txtNewCustomerNameRB.Visible = false;
			txtNewCustomerNameRB.Text = "";
		}
		else
		{
			txtNewCustomerNameRB.Visible = true;
			txtNewCustomerNameRB.Text = "";
		}
		TabContainer1.ActiveTabIndex = 1;
	}
}

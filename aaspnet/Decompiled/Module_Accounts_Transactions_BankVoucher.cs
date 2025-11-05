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

public class Module_Accounts_Transactions_BankVoucher : Page, IRequiresSessionState
{
	protected TextBox textChequeDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected DropDownList DropDownList1;

	protected DropDownList drptype;

	protected TextBox TextBox1;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected RequiredFieldValidator ReqEmpEdit;

	protected Button BtnSearch_Adv;

	protected TextBox txtDDNo;

	protected AutoCompleteExtender txtEmpName_AutoCompleteExtender;

	protected RequiredFieldValidator ReqDDNo;

	protected DropDownList DDListNewRegdCountry_Adv;

	protected RequiredFieldValidator ReqCountry_Adv;

	protected DropDownList DDListNewRegdState_Adv;

	protected RequiredFieldValidator ReqStat_Adv;

	protected DropDownList DDListNewRegdCity_Adv;

	protected RequiredFieldValidator ReqCity_Adv;

	protected TextBox Txtaddcharg_Adv;

	protected RegularExpressionValidator RegularReqAdd_Adv;

	protected RadioButtonList Rdbtncrtrtype_Adv;

	protected Label Label9;

	protected RadioButton Rdbtncheck_Adv;

	protected TextBox txtNameOnchq_Adv;

	protected RadioButton Rdbtncheck1_Adv;

	protected DropDownList DrpPaid_Adv;

	protected Button btnProceed;

	protected Label Lblsupid_Adv;

	protected Panel Panel3;

	protected GridView GridView1;

	protected Panel Panel8;

	protected TabPanel TabPanel11;

	protected TextBox txtPayTo_Credit;

	protected AutoCompleteExtender AutoCompleteExtender3;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected Button btnSearch;

	protected Button btnRefresh;

	protected DropDownList DropDownList4;

	protected TextBox txtChequeDate_Credit;

	protected CalendarExtender CalendarExtender3;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected TextBox txtChequeNo_Credit;

	protected AutoCompleteExtender AutoCompleteExtender4;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected DropDownList DDListNewRegdCountry;

	protected RequiredFieldValidator ReqRegdCountry;

	protected DropDownList DDListNewRegdState;

	protected RequiredFieldValidator ReqRegdState;

	protected DropDownList DDListNewRegdCity;

	protected RequiredFieldValidator ReqRegdCity;

	protected Label Lblsupid;

	protected Label lblOpeningBal;

	protected Label lblgetbal;

	protected Label Label3;

	protected Label lblPaid;

	protected Label Label6;

	protected Label lblClosingAmt;

	protected Label Label4;

	protected TextBox txtPayment;

	protected RegularExpressionValidator RegularReqAmt;

	protected TextBox Txtaddcharges;

	protected RegularExpressionValidator RegularReqAmt1;

	protected RadioButtonList Rdbtncrtrtype;

	protected Label Label8;

	protected RadioButton Rdbtncheck;

	protected TextBox Txtnameoncheque;

	protected RadioButton Rdbtncheck1;

	protected DropDownList DrpPaid;

	protected Panel Panel4;

	protected GridView GridView4;

	protected Panel Panel5;

	protected Button btnCalculate;

	protected Label lbltotActAmt;

	protected Label totActAmt;

	protected Label lbltotBalAmt;

	protected Label totbalAmt;

	protected Label Label7;

	protected Label lblPayamt;

	protected Button btnAddTemp;

	protected TabPanel TabPanel2;

	protected GridView GridView5;

	protected Panel Panel10;

	protected TabPanel TabPanel1;

	protected TabContainer TabContainer3;

	protected Button btnProceed_Creditor;

	protected TabPanel TabPanel21;

	protected TextBox txtPayTo_Sal;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList DropDownList2;

	protected TextBox TxtChequeDate_Sal;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtChequeNo_Sal;

	protected AutoCompleteExtender AutoCompleteExtender5;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtPayAt_Sal;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected Panel plnSalary;

	protected Button btnProceed_Sal;

	protected GridView GridView2;

	protected Panel Panel9;

	protected TabPanel TabPanel_Sal;

	protected DropDownList drptypeOther;

	protected TextBox txtPayTo_Others;

	protected AutoCompleteExtender AutoCompleteExtender2;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected DropDownList DropDownList3;

	protected TextBox txtChq_Date;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtChqNo;

	protected AutoCompleteExtender AutoCompleteExtender6;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtpayAt_oth;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected Panel Panel6;

	protected Button btnProceed_Oth;

	protected GridView GridView3;

	protected Panel Panel7;

	protected TabPanel TabPanel_Others;

	protected TabContainer TabContainer2;

	protected Panel Panel1;

	protected TabPanel Add;

	protected DropDownList DrpTypes;

	protected RequiredFieldValidator ReqDrpType;

	protected DropDownList drptypeReceipt;

	protected TextBox TxtFrom;

	protected AutoCompleteExtender TxtFrom_AutoCompleteExtender;

	protected RequiredFieldValidator ReqFrom;

	protected TextBox TxtInvoiceNo;

	protected TextBox TxtBank;

	protected AutoCompleteExtender AutoCompleteExtender7;

	protected RequiredFieldValidator ReqReceived;

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

	protected TextBox TxtAmount;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected RequiredFieldValidator ReqAmount;

	protected TextBox TxtBankAccNo;

	protected RequiredFieldValidator ReqBankAccNo;

	protected TextBox TxtClearanceDate;

	protected CalendarExtender TxtClearanceDate_CalendarExtender;

	protected RequiredFieldValidator ReqClearanceDate;

	protected RegularExpressionValidator RegBillDate;

	protected RadioButtonList Rdbtncrtrtype_Rec;

	protected RadioButton rdwono;

	protected TextBox txtwono;

	protected RadioButton rddept;

	protected DropDownList drpdept;

	protected TextBox TxtNarration;

	protected DropDownList DrpBankName;

	protected Button TxtSubmit;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource3;

	protected SqlDataSource SqlDataSource5;

	protected SqlDataSource SqlDataSource6;

	protected SqlDataSource SqlDataBG;

	protected SqlDataSource SqlDataSource7;

	protected SqlDataSource SqlDataSource14;

	protected SqlDataSource SqlDataSourcePOList;

	protected SqlDataSource SqlDataSource15;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	private string GetSupCode = "";

	private double actamt;

	private double balamt;

	private int bankAdvId = 1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			GetSupCode = fun.getCode(txtPayTo_Credit.Text);
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select1("Particulars,Id ", "tblACC_PaidType");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DrpPaid.DataSource = dataSet;
				DrpPaid.DataTextField = "Particulars";
				DrpPaid.DataValueField = "Id";
				DrpPaid.DataBind();
				DrpPaid.Items.Insert(0, "Select");
				DrpPaid_Adv.DataSource = dataSet;
				DrpPaid_Adv.DataTextField = "Particulars";
				DrpPaid_Adv.DataValueField = "Id";
				DrpPaid_Adv.DataBind();
				DrpPaid_Adv.Items.Insert(0, "Select");
				lblgetbal.Text = "0";
				SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				SqlCommand sqlCommand2 = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Creditor_Temp WHERE SessionId='" + sId + "' And CompId='" + CompId + "'", con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				FillGrid_Other();
				FillGrid_Creditors_Temp();
				FillGrid_Salary();
				FillGrid_Creditors();
				dropdownCompany(DrpTypes);
				FillGridTemp_Adv();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGridTemp_Adv()
	{
		try
		{
			new DataTable();
			string cmdText = "SELECT * FROM [tblACC_BankVoucher_Payment_Temp] WHERE (([SessionId] ='" + sId + "') AND ([CompId] ='" + CompId + "') And ([Types]=1)) order by Id Desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			EnableDisable();
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
			string cmdText = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, Convert.ToInt32(drptype.SelectedValue), CompId);
			string cmdText2 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='1'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string text2 = string.Empty;
				Lblsupid_Adv.Text = fun.getCode(TextBox1.Text);
				if (Lblsupid_Adv.Text != string.Empty && DrpPaid_Adv.SelectedValue == "Select")
				{
					text2 = Lblsupid_Adv.Text;
				}
				else if (DrpPaid_Adv.SelectedValue != "Select")
				{
					text2 = DrpPaid_Adv.SelectedValue;
				}
				string text3 = "";
				if (Rdbtncheck_Adv.Checked)
				{
					if (txtNameOnchq_Adv.Text != "")
					{
						text3 = txtNameOnchq_Adv.Text;
					}
					else
					{
						string empty = string.Empty;
						empty = "please fill the textbox name on cheque .";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else if (Rdbtncheck1_Adv.Checked)
				{
					text3 = "";
				}
				if (num == 1 && TextBox1.Text != "" && txtDDNo.Text != "" && textChequeDate.Text != "" && fun.DateValidation(textChequeDate.Text) && drptype.SelectedValue != "0")
				{
					string cmdText3 = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAtCountry,PayAtState,PayAtCity,Bank,ECSType,AddAmt,TransactionType,PaidType,NameOnCheque", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','1','" + code + "','" + txtDDNo.Text + "','" + fun.FromDate(textChequeDate.Text) + "','" + DDListNewRegdCountry_Adv.SelectedValue + "','" + DDListNewRegdState_Adv.SelectedValue + "','" + DDListNewRegdCity_Adv.SelectedValue + "','" + DropDownList1.SelectedValue + "','" + Convert.ToInt32(drptype.SelectedValue) + "','" + Txtaddcharg_Adv.Text + "','" + Rdbtncrtrtype_Adv.SelectedValue + "','" + text2 + "','" + text3 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text4 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_BankVoucher_Payment_Details", "MId ,ProformaInvNo ,InvDate,PONo,Particular,Amount", "'" + text4 + "','" + dataSet2.Tables[0].Rows[i]["ProformaInvNo"].ToString() + "','" + fun.FromDate(dataSet2.Tables[0].Rows[i]["InvDate"].ToString()) + "','" + dataSet2.Tables[0].Rows[i]["PONo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='1'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
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
			double num = 0.0;
			string text3 = "";
			if (e.CommandName == "Add" && ((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text != "")
			{
				text = ((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Text;
				text2 = ((TextBox)GridView1.FooterRow.FindControl("textDateF")).Text;
				string text4 = string.Empty;
				CheckBoxList checkBoxList = (CheckBoxList)GridView1.FooterRow.FindControl("CBLPOList2");
				foreach (ListItem item in checkBoxList.Items)
				{
					if (item.Selected)
					{
						text4 = text4 + item.Text + ",";
					}
				}
				num = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAmountFoot")).Text).ToString("N3"));
				text3 = ((TextBox)GridView1.FooterRow.FindControl("txtParticularsFoot")).Text;
				SqlCommand sqlCommand = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo,InvDate,PONo,Amount,Particular,SessionId,CompId,Types", "'" + text + "','" + text2 + "','" + text4 + "','" + num + "','" + text3 + "','" + sId + "','" + CompId + "',1"), con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillGridTemp_Adv();
			}
			if (!(e.CommandName == "Add1") || !(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text != ""))
			{
				return;
			}
			text = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Text;
			text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Text;
			string text5 = string.Empty;
			CheckBoxList checkBoxList2 = (CheckBoxList)GridView1.Controls[0].Controls[0].FindControl("CBLPOList");
			foreach (ListItem item2 in checkBoxList2.Items)
			{
				if (item2.Selected)
				{
					text5 = text5 + item2.Text + ",";
				}
			}
			num = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAmt")).Text).ToString("N3"));
			text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtparticul")).Text;
			SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo,InvDate,PONo,Amount,Particular,SessionId,CompId,Types", "'" + text + "','" + text2 + "','" + text5 + "','" + num + "','" + text3 + "','" + sId + "','" + CompId + "',1"), con);
			con.Open();
			sqlCommand2.ExecuteNonQuery();
			con.Close();
			FillGridTemp_Adv();
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
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = "";
			string text2 = "";
			string text3 = "";
			double num2 = 0.0;
			string text4 = "";
			if (((TextBox)gridViewRow.FindControl("txtAmount")).Text != "" && ((TextBox)gridViewRow.FindControl("txtAmount")).Text != "0" && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtAmount")).Text))
			{
				text = ((TextBox)gridViewRow.FindControl("txtProforInvNo")).Text;
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmount")).Text).ToString("N3"));
				text2 = ((TextBox)gridViewRow.FindControl("textDate")).Text;
				text3 = ((TextBox)gridViewRow.FindControl("txtPoNo")).Text;
				text4 = ((TextBox)gridViewRow.FindControl("txtParticulars")).Text;
				SqlCommand sqlCommand = new SqlCommand(fun.update("tblACC_BankVoucher_Payment_Temp", "ProformaInvNo='" + text + "',InvDate='" + text2 + "',PONo='" + text3 + "',Amount='" + num2 + "',Particular='" + text4 + "',SessionId='" + sId + "'", "Id='" + num + "'"), con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView1.EditIndex = -1;
				FillGridTemp_Adv();
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
				string cmdText = fun.insert("tblACC_BankVoucher_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + num + "','" + text + "','" + CompId + "','" + sId + "','2'");
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
				string cmdText2 = fun.insert("tblACC_BankVoucher_Payment_Temp", "Amount, Particular, CompId,SessionId,Types", "'" + num + "','" + text + "','" + CompId + "','" + sId + "','2'");
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
				string cmdText = fun.update("tblACC_BankVoucher_Payment_Temp", "Amount='" + num2 + "', Particular='" + text + "',CompId='" + CompId + "',SessionId='" + sId + "'", "Id='" + num + "'");
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
			string cmdText = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, 1, CompId);
			string cmdText2 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='2'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num == 1 && TxtChequeNo_Sal.Text != "" && TxtChequeDate_Sal.Text != "" && txtPayAt_Sal.Text != "" && txtPayTo_Sal.Text != "" && fun.DateValidation(TxtChequeDate_Sal.Text))
				{
					string cmdText3 = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','2','" + code + "','" + TxtChequeNo_Sal.Text + "','" + fun.FromDate(TxtChequeDate_Sal.Text) + "','" + txtPayAt_Sal.Text + "','" + DropDownList2.SelectedValue + "','1'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_BankVoucher_Payment_Details", "MId,Particular,Amount", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='2'");
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
					string cmdText = fun.insert("tblACC_BankVoucher_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + num + "','" + text + "','" + text3 + "','" + num2 + "','" + text2 + "'");
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
				string cmdText2 = fun.insert("tblACC_BankVoucher_Payment_Temp", "SessionId,CompId,Types,Amount,Particular,WONo,BG,WithinGroup", "'" + sId + "','" + CompId + "','3','" + num + "','" + text + "','" + text3 + "','" + num2 + "','" + text2 + "'");
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
				string cmdText = "UPDATE [tblACC_BankVoucher_Payment_Temp] SET [Amount] = '" + num2 + "', [Particular] = '" + text + "', [CompId] ='" + CompId + "', [SessionId] ='" + sId + "',[WONo]='" + text3 + "' ,[BG]='" + num3 + "',[WithinGroup]='" + text2 + "' WHERE [Id] = '" + num + "'";
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
			string cmdText = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = Convert.ToInt32(drptypeOther.SelectedValue);
			int num2 = fun.chkEmpCustSupplierCode(code, num, CompId);
			string cmdText2 = fun.select("*", "tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And Types='3'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				if (num2 == 1 && txtChqNo.Text != "" && txtChq_Date.Text != "" && txtpayAt_oth.Text != "" && txtPayTo_Others.Text != "" && fun.DateValidation(txtChq_Date.Text) && num != 0)
				{
					string cmdText3 = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,PayAt,Bank,ECSType", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','3','" + code + "','" + txtChqNo.Text + "','" + fun.FromDate(txtChq_Date.Text) + "','" + txtpayAt_oth.Text + "','" + DropDownList3.SelectedValue + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText4 = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_BankVoucher_Payment_Details", "MId,Particular,Amount,WONo,BG,WithinGroup", "'" + text2 + "','" + dataSet2.Tables[0].Rows[i]["Particular"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "','" + dataSet2.Tables[0].Rows[i]["WONo"].ToString() + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["BG"].ToString()) + "','" + dataSet2.Tables[0].Rows[i]["WithinGroup"].ToString() + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
					string cmdText6 = fun.delete("tblACC_BankVoucher_Payment_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'And Types='3'");
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
			string cmdText = fun.select("BG,WONo", "tblACC_BankVoucher_Payment_Temp", "Id='" + num + "'");
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
			string cmdText = "SELECT [tblACC_BankVoucher_Payment_Temp].Id,Amount,Particular, (Case When WONo!='' then WONo Else 'NA' END)As WONo, [BusinessGroup].Symbol As BG,WithinGroup FROM [tblACC_BankVoucher_Payment_Temp] Inner Join [BusinessGroup] on [tblACC_BankVoucher_Payment_Temp].BG=[BusinessGroup].Id And ([SessionId] ='" + sId + "') AND ([CompId] ='" + CompId + "') And ([Types]=3)";
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
			string cmdText = "SELECT * FROM tblACC_BankVoucher_Payment_Temp WHERE SessionId ='" + sId + "'AND CompId = '" + CompId + "' And Types=2";
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
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			DataTable dataTable = new DataTable();
			new DataTable();
			sqlConnection.Open();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PVEVNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BillDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ActAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PaidAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BalAmt", typeof(string)));
			string cmdText = fun.select("tblACC_BillBooking_Master.Id ,tblACC_BillBooking_Master.SessionId ,tblACC_BillBooking_Master.AuthorizeBy,tblACC_BillBooking_Master.AuthorizeDate, tblACC_BillBooking_Master.SysDate , tblACC_BillBooking_Master.SysTime  , tblACC_BillBooking_Master.SessionId, tblACC_BillBooking_Master.CompId , tblACC_BillBooking_Master.FinYearId, tblACC_BillBooking_Master.PVEVNo, tblACC_BillBooking_Master.SupplierId,tblACC_BillBooking_Master.BillNo, tblACC_BillBooking_Master.BillDate , tblACC_BillBooking_Master.CENVATEntryNo, tblACC_BillBooking_Master.CENVATEntryDate, tblACC_BillBooking_Master.OtherCharges, tblACC_BillBooking_Master.OtherChaDesc, tblACC_BillBooking_Master.Narration , tblACC_BillBooking_Master.DebitAmt , tblACC_BillBooking_Master.DiscountType, tblACC_BillBooking_Master.Discount", "tblACC_BillBooking_Master", "tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "' And tblACC_BillBooking_Master.CompId='" + num2 + "' And tblACC_BillBooking_Master.FinYearId<='" + num + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			new DataSet();
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select(" tblACC_BillBooking_Details.PODId, tblACC_BillBooking_Details.GQNId,tblACC_BillBooking_Details.GSNId, tblACC_BillBooking_Details.ItemId,tblACC_BillBooking_Details.PFAmt,tblACC_BillBooking_Details.ExStBasicInPer ,tblACC_BillBooking_Details.ExStEducessInPer ,tblACC_BillBooking_Details.ExStShecessInPer,tblACC_BillBooking_Details.ExStBasic ,tblACC_BillBooking_Details.ExStEducess ,tblACC_BillBooking_Details.ExStShecess ,tblACC_BillBooking_Details.CustomDuty ,tblACC_BillBooking_Details.VAT ,tblACC_BillBooking_Details.CST ,tblACC_BillBooking_Details.Freight ,tblACC_BillBooking_Details.TarrifNo,tblACC_BillBooking_Details.DebitType,tblACC_BillBooking_Details.DebitValue,tblACC_BillBooking_Details.BCDValue,tblACC_BillBooking_Details.EdCessOnCDValue,tblACC_BillBooking_Details.SHEDCessValue", "tblACC_BillBooking_Master,tblACC_BillBooking_Details", string.Concat("tblACC_BillBooking_Master.CompId='", num2, "' And tblACC_BillBooking_Details.MId='", dataSet.Tables[0].Rows[i]["Id"], "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='", num, "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string text = string.Empty;
				double num3 = 0.0;
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					string cmdText3 = fun.select("tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + dataSet2.Tables[0].Rows[j]["PODId"].ToString() + "' AND   tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.CompId='" + num2 + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						num13 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
						num4 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					}
					if (dataSet2.Tables[0].Rows[j]["GQNId"].ToString() != "0")
					{
						string cmdText4 = fun.select("Sum(tblQc_MaterialQuality_Details.AcceptedQty) As AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + dataSet2.Tables[0].Rows[j]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + num2 + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							num14 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["AcceptedQty"]);
							num12 = (num13 - num13 * num4 / 100.0) * num14;
						}
					}
					else if (dataSet2.Tables[0].Rows[j]["GSNId"].ToString() != "0")
					{
						string cmdText5 = fun.select("Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As ReceivedQty ", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + dataSet2.Tables[0].Rows[j]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + num2 + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							num14 = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["ReceivedQty"]);
							num12 = (num13 - num13 * num4 / 100.0) * num14;
						}
					}
					num5 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["PFAmt"]);
					num7 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStBasic"]);
					num8 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStEducess"]);
					num9 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["ExStShecess"]);
					num10 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["VAT"]);
					num11 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["CST"]);
					num6 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["Freight"]);
					string cmdText6 = fun.select("distinct(tblMM_PO_Master.PONo)", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + num2 + "' And tblMM_PO_Details.Id='" + dataSet2.Tables[0].Rows[j]["PODId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						text = text + dataSet6.Tables[0].Rows[0][0].ToString() + ", ";
					}
					double num18 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["DebitAmt"]);
					double num19 = 0.0;
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["DiscountType"]))
					{
					case 0:
						num19 = num12 - num18;
						break;
					case 1:
						num19 = num12 - num12 * num18 / 100.0;
						break;
					case 2:
						num19 = num12;
						break;
					}
					num15 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["BCDValue"]);
					num16 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["EdCessOnCDValue"]);
					num17 = Convert.ToDouble(dataSet2.Tables[0].Rows[j]["SHEDCessValue"]);
					num3 += num19 + num5 + num10 + num11 + num6 + num9 + num8 + num7 + num15 + num16 + num17;
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["PVEVNo"].ToString();
				dataRow[2] = text;
				actamt += num3;
				dataRow[3] = dataSet.Tables[0].Rows[i]["BillNo"].ToString();
				dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["BillDate"].ToString());
				dataRow[5] = num3;
				double num20 = 0.0;
				string cmdText7 = fun.select("Sum(Amount)As Amt", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + num2 + "' AND PVEVNO='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0 && dataSet7.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num20 = Convert.ToDouble(decimal.Parse(dataSet7.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[6] = 0;
				}
				double num21 = 0.0;
				string cmdText8 = " Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + num2 + "' AND tblACC_BankVoucher_Payment_Details.PVEVNO='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_BankVoucher_Payment_Master.Type=4";
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				if (dataSet8.Tables[0].Rows.Count > 0 && dataSet8.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num21 = Convert.ToDouble(decimal.Parse(dataSet8.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				dataRow[6] = Math.Round(num20 + num21, 5);
				double num22 = 0.0;
				num22 = Math.Round(num3 - (num20 + num21), 5);
				dataRow[7] = num22;
				balamt += num22;
				if (num22 > 0.0)
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
		finally
		{
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	public void FillGrid_Creditors_Temp()
	{
		try
		{
			string cmdText = fun.select("tblACC_BankVoucher_Payment_Creditor_Temp.Id,BillAgainst,Amount,tblACC_BillBooking_Master.PVEVNo", "tblACC_BankVoucher_Payment_Creditor_Temp,tblACC_BillBooking_Master", "tblACC_BankVoucher_Payment_Creditor_Temp.SessionId='" + sId + "' And tblACC_BankVoucher_Payment_Creditor_Temp.CompId='" + CompId + "' And tblACC_BankVoucher_Payment_Creditor_Temp.PVEVNo=tblACC_BillBooking_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView5.DataSource = dataSet;
			GridView5.DataBind();
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGridTemp_Adv();
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
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
			string cmdText = fun.select("BVPNo", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = fun.chkEmpCustSupplierCode(code, 3, CompId);
			string cmdText2 = fun.select("*", "tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0 || Convert.ToDouble(txtPayment.Text) > 0.0)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				string text2 = "";
				num2 = Convert.ToDouble(lblgetbal.Text);
				num3 = fun.getTotPay(CompId, GetSupCode, FinYearId);
				num4 = Convert.ToDouble(txtPayment.Text);
				if (Lblsupid.Text != string.Empty && DrpPaid.SelectedValue == "Select")
				{
					text2 = Lblsupid.Text;
				}
				else if (DrpPaid.SelectedValue != "Select")
				{
					text2 = DrpPaid.SelectedValue;
				}
				string text3 = "";
				if (Rdbtncheck.Checked && Txtnameoncheque.Text != "")
				{
					text3 = Txtnameoncheque.Text;
				}
				if (num == 1 && txtPayTo_Credit.Text != "" && txtChequeNo_Credit.Text != "" && txtChequeDate_Credit.Text != "" && fun.DateValidation(txtChequeDate_Credit.Text) && num2 >= num3 + num4)
				{
					string cmdText3 = fun.insert("tblACC_BankVoucher_Payment_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,BVPNo,Type,PayTo,ChequeNo,ChequeDate,Bank,ECSType,PayAtCountry,PayAtState,PayAtCity,PayAmt,AddAmt,TransactionType,PaidType,NameOnCheque", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','4','" + code + "','" + txtChequeNo_Credit.Text + "','" + fun.FromDate(txtChequeDate_Credit.Text) + "','" + DropDownList4.SelectedValue + "','3','" + Convert.ToInt32(DDListNewRegdCountry.SelectedValue) + "','" + Convert.ToInt32(DDListNewRegdState.SelectedValue) + "','" + Convert.ToInt32(DDListNewRegdCity.SelectedValue) + "','" + Convert.ToDouble(txtPayment.Text) + "','" + Txtaddcharges.Text + "','" + Rdbtncrtrtype.SelectedValue + "','" + text2 + "','" + text3 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					string cmdText4 = fun.select("Id", "tblACC_BankVoucher_Payment_Master", "CompId='" + CompId + "' AND BVPNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string text4 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("tblACC_BankVoucher_Payment_Details", "MId ,PVEVNO ,BillAgainst,Amount", "'" + text4 + "','" + dataSet2.Tables[0].Rows[i]["PVEVNO"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["BillAgainst"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
						sqlConnection.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection.Close();
					}
					string cmdText6 = fun.delete("tblACC_BankVoucher_Payment_Creditor_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					GetSupCode = string.Empty;
					FillGrid_Creditors();
					FillGrid_Creditors_Temp();
					txtPayTo_Credit.Text = string.Empty;
					txtChequeNo_Credit.Text = string.Empty;
					txtChequeDate_Credit.Text = string.Empty;
					txtPayment.Text = "0";
					lblPaid.Text = "0";
					lblgetbal.Text = "0";
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
		Lblsupid.Text = fun.getCode(txtPayTo_Credit.Text);
		string cmdText = "SELECT tblACC_Creditors_Master.OpeningAmt FROM tblACC_Creditors_Master where tblACC_Creditors_Master.SupplierId ='" + GetSupCode + "' And tblACC_Creditors_Master.CompId='" + CompId + "' And tblACC_Creditors_Master.FinYearId<='" + FinYearId + "'";
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		double num = 0.0;
		double num2 = 0.0;
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			num = Convert.ToDouble(dataSet.Tables[0].Rows[0]["OpeningAmt"]);
			lblgetbal.Text = num.ToString();
		}
		else
		{
			lblgetbal.Text = num.ToString();
		}
		lblPaid.Text = fun.getTotPay(CompId, GetSupCode, FinYearId).ToString();
		num2 = num - fun.getTotPay(CompId, GetSupCode, FinYearId);
		lblClosingAmt.Text = (num - fun.getTotPay(CompId, GetSupCode, FinYearId)).ToString();
		FillGrid_Creditors();
		btnSearch.Visible = false;
		txtPayTo_Credit.Enabled = false;
		btnRefresh.Visible = true;
		Panel5.Visible = true;
		FillGrid_Creditors_Temp();
		totActAmt.Text = (num + actamt).ToString();
		totbalAmt.Text = (num2 + balamt).ToString();
	}

	protected void btnRefresh_Click(object sender, EventArgs e)
	{
		Lblsupid.Text = string.Empty;
		FillGrid_Creditors();
		btnSearch.Visible = true;
		txtPayTo_Credit.Enabled = true;
		txtPayTo_Credit.Text = "";
		btnRefresh.Visible = false;
		lblgetbal.Text = "0";
		lblPaid.Text = "0";
		lblPayamt.Text = "0";
		Panel5.Visible = false;
		totActAmt.Text = "0";
		totbalAmt.Text = "0";
	}

	[WebMethod]
	[ScriptMethod]
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Creditor_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid_Creditors_Temp();
			FillGrid_Creditors();
			if (GridView5.Rows.Count > 0)
			{
				TabContainer3.ActiveTabIndex = 1;
			}
			else
			{
				TabContainer3.ActiveTabIndex = 0;
			}
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
		int num2 = 0;
		switch ((!(contextKey == "key2")) ? Convert.ToInt32(HttpContext.Current.Session["codetype2"]) : Convert.ToInt32(HttpContext.Current.Session["codetype"]))
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
		if (drptype.SelectedValue == "3")
		{
			BtnSearch_Adv.Visible = true;
		}
		else
		{
			BtnSearch_Adv.Visible = false;
		}
		EnableDisable();
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_BankVoucher_Payment_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
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

	protected void TxtSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			int num = 0;
			if (rdwono.Checked && txtwono.Text != "" && fun.CheckValidWONo(txtwono.Text, CompId, FinYearId))
			{
				text = txtwono.Text;
				num = 1;
			}
			if (rddept.Checked)
			{
				text2 = drpdept.SelectedValue.ToString();
				num = 1;
			}
			if (rddept.Checked)
			{
				txtwono.Text = "";
			}
			string cmdText = fun.select("BVRNo", "tblACC_BankVoucher_Received_Masters", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by BVRNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Received_Masters");
			string text3 = "";
			text3 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["BVRNo"]) + 1).ToString("D4"));
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string code = fun.getCode(TxtReceived.Text);
			int num2 = fun.chkEmpCustSupplierCode(code, 1, CompId);
			con.Open();
			string text4 = "";
			text4 = ((!(drptypeReceipt.SelectedValue != "0") || !(drptypeReceipt.SelectedValue == "4")) ? fun.getCode(TxtFrom.Text) : TxtFrom.Text);
			if (num == 1)
			{
				if (num2 == 1 && fun.DateValidation(TxtChequeDate.Text) && fun.DateValidation(TxtClearanceDate.Text) && fun.NumberValidationQty(TxtAmount.Text) && DrpTypes.SelectedValue != "0" && drptypeReceipt.SelectedValue != "0")
				{
					string cmdText2 = fun.insert("tblACC_BankVoucher_Received_Masters", "SysDate,SysTime,SessionId,CompId,FinYearId, BVRNo, Types, ReceiveType , ReceivedFrom  ,InvoiceNo , ChequeNo, ChequeDate, ChequeReceivedBy, BankName, BankAccNo , ChequeClearanceDate , Narration, Amount,DrawnAt,TransactionType,WONo,BGGroup ", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text3 + "','" + DrpTypes.SelectedValue + "','" + drptypeReceipt.SelectedValue + "','" + text4 + "','" + TxtInvoiceNo.Text + "','" + TxtChequeNo.Text + "','" + fun.FromDate(TxtChequeDate.Text) + "','" + code + "','" + TxtBank.Text + "','" + TxtBankAccNo.Text + "','" + fun.FromDate(TxtClearanceDate.Text) + "','" + TxtNarration.Text + "','" + Convert.ToDouble(decimal.Parse(TxtAmount.Text.ToString()).ToString("N2")) + "','" + DrpBankName.SelectedValue + "','" + Rdbtncrtrtype_Rec.SelectedValue + "','" + text + "','" + text2 + "'");
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
					txtwono.Text = "";
				}
				else
				{
					string empty = string.Empty;
					empty = "Input data is invalid.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "WONo or Dept is not found!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
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
				string cmdText = fun.delete("tblACC_BankVoucher_Received_Masters", " Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	protected void DDListNewRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
		fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
	}

	protected void DDListNewRegdState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
	}

	protected void DDListNewRegdCountry_Adv_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDListNewRegdState_Adv, DDListNewRegdCity_Adv, DDListNewRegdCountry_Adv);
		fun.dropdownCity(DDListNewRegdCity_Adv, DDListNewRegdState_Adv);
	}

	protected void DDListNewRegdState_Adv_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDListNewRegdCity_Adv, DDListNewRegdState_Adv);
	}

	protected void drptypeReceipt_SelectedIndexChanged(object sender, EventArgs e)
	{
		Session["codetype2"] = drptypeReceipt.SelectedValue;
		TxtFrom.Text = string.Empty;
	}

	protected void btnAddTemp_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 0.0;
			double num5 = 0.0;
			foreach (GridViewRow row in GridView4.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtBill_Against")).Text != "" && ((TextBox)row.FindControl("txtAmount")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtAmount")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text) != 0.0)
				{
					double num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N3"));
					double num7 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblBalAmt")).Text).ToString("N3"));
					if (num7 >= num6)
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
						double num8 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtAmount")).Text).ToString("N3"));
						double num9 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblBalAmt")).Text).ToString("N3"));
						num4 += Convert.ToDouble(((Label)row2.FindControl("lblActAmt")).Text);
						num5 += Convert.ToDouble(((Label)row2.FindControl("lblBalAmt")).Text);
						string text = ((TextBox)row2.FindControl("txtBill_Against")).Text;
						int num10 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						if (num9 >= num8)
						{
							SqlCommand sqlCommand = new SqlCommand(fun.insert("tblACC_BankVoucher_Payment_Creditor_Temp", "CompId,SessionId,PVEVNO,BillAgainst,Amount", "'" + CompId + "','" + sId + "','" + num10 + "','" + text + "','" + num8 + "'"), sqlConnection);
							sqlCommand.ExecuteNonQuery();
							num3++;
							totActAmt.Text = Math.Round(num4 + Convert.ToDouble(lblgetbal.Text), 2).ToString();
							totbalAmt.Text = Math.Round(num5 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();
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

	protected void btnCalculate_Click(object sender, EventArgs e)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		foreach (GridViewRow row in GridView4.Rows)
		{
			num += Convert.ToDouble(((Label)row.FindControl("lblActAmt")).Text);
			num2 += Convert.ToDouble(((Label)row.FindControl("lblBalAmt")).Text);
			if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtAmount")).Text != "" && Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text) > 0.0)
			{
				num3 += Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text);
			}
		}
		totActAmt.Text = Math.Round(num + Convert.ToDouble(lblgetbal.Text), 2).ToString();
		totbalAmt.Text = Math.Round(num2 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();
		num4 = Convert.ToDouble(txtPayment.Text) + num3;
		lblPayamt.Text = num4.ToString();
	}

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		foreach (GridViewRow row in GridView4.Rows)
		{
			num += Convert.ToDouble(((Label)row.FindControl("lblActAmt")).Text);
			num2 += Convert.ToDouble(((Label)row.FindControl("lblBalAmt")).Text);
			if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtAmount")).Text != "" && Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text) > 0.0)
			{
				num3 += Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text);
			}
		}
		totActAmt.Text = Math.Round(num + Convert.ToDouble(lblgetbal.Text), 2).ToString();
		totbalAmt.Text = Math.Round(num2 + Convert.ToDouble(lblClosingAmt.Text), 2).ToString();
		num4 = Convert.ToDouble(txtPayment.Text) + num3;
		lblPayamt.Text = num4.ToString();
	}

	protected void Rdbtncheck_CheckedChanged(object sender, EventArgs e)
	{
		if (Rdbtncheck.Checked)
		{
			DrpPaid.Enabled = false;
			Txtnameoncheque.Enabled = true;
		}
	}

	protected void Rdbtncheck1_CheckedChanged(object sender, EventArgs e)
	{
		if (Rdbtncheck1.Checked)
		{
			DrpPaid.Enabled = true;
			Txtnameoncheque.Enabled = false;
			Txtnameoncheque.Text = string.Empty;
		}
	}

	protected void Rdbtncheck_Adv_CheckedChanged(object sender, EventArgs e)
	{
		if (Rdbtncheck_Adv.Checked)
		{
			DrpPaid_Adv.Enabled = false;
			txtNameOnchq_Adv.Enabled = true;
		}
	}

	protected void Rdbtncheck1_Adv_CheckedChanged(object sender, EventArgs e)
	{
		if (Rdbtncheck1_Adv.Checked)
		{
			DrpPaid_Adv.Enabled = true;
			txtNameOnchq_Adv.Enabled = false;
			txtNameOnchq_Adv.Text = string.Empty;
		}
	}

	protected void BtnSearch_Adv_Click(object sender, EventArgs e)
	{
		string code = fun.getCode(TextBox1.Text);
		SqlDataSourcePOList.SelectParameters["SupplierId"].DefaultValue = code;
	}

	public void EnableDisable()
	{
		if (drptype.SelectedValue == "0")
		{
			GridView1.Visible = false;
		}
		else if (drptype.SelectedValue == "3")
		{
			GridView1.Visible = true;
			if (GridView1.Rows.Count == 0)
			{
				((Panel)GridView1.Controls[0].Controls[0].FindControl("Panel2")).Visible = true;
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Enabled = true;
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Enabled = true;
			}
			else
			{
				((Panel)GridView1.FooterRow.FindControl("Panel21")).Visible = true;
				((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Enabled = true;
				((TextBox)GridView1.FooterRow.FindControl("textDateF")).Enabled = true;
			}
		}
		else if (drptype.SelectedValue == "1" || drptype.SelectedValue == "2")
		{
			GridView1.Visible = true;
			if (GridView1.Rows.Count == 0)
			{
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtProInv")).Enabled = false;
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtDate1")).Enabled = false;
				((Panel)GridView1.Controls[0].Controls[0].FindControl("Panel2")).Visible = false;
			}
			else
			{
				((Panel)GridView1.FooterRow.FindControl("Panel21")).Visible = false;
				((TextBox)GridView1.FooterRow.FindControl("txtProforInvNoFoot")).Enabled = false;
				((TextBox)GridView1.FooterRow.FindControl("textDateF")).Enabled = false;
			}
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			FillGridTemp_Adv();
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
			FillGridTemp_Adv();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			DataSet dataSet = new DataSet();
			con.Open();
			string selectCommandText = fun.select("ProformaInvNo,InvDate,PONo", "tblACC_BankVoucher_Payment_Temp", "Id='" + num + "'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
			sqlDataAdapter.Fill(dataSet, "tblACC_BankVoucher_Payment_Temp");
			con.Close();
			if (dataSet.Tables[0].Rows[0][0].ToString() != "" && dataSet.Tables[0].Rows[0][1].ToString() != "" && dataSet.Tables[0].Rows[0][2].ToString() != "")
			{
				((TextBox)gridViewRow.FindControl("txtPoNo")).Enabled = true;
				((TextBox)gridViewRow.FindControl("txtProforInvNo")).Enabled = true;
				((TextBox)gridViewRow.FindControl("textDate")).Enabled = true;
			}
			else
			{
				((TextBox)gridViewRow.FindControl("txtPoNo")).Enabled = false;
				((TextBox)gridViewRow.FindControl("txtProforInvNo")).Enabled = false;
				((TextBox)gridViewRow.FindControl("textDate")).Enabled = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		bankAdvId = Convert.ToInt32(DropDownList1.SelectedValue);
		Session["bankAdvId1"] = bankAdvId;
		txtDDNo.Text = string.Empty;
	}

	protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
	{
		bankAdvId = Convert.ToInt32(DropDownList4.SelectedValue);
		Session["bankAdvId1"] = bankAdvId;
		txtChequeNo_Credit.Text = string.Empty;
	}

	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		bankAdvId = Convert.ToInt32(DropDownList2.SelectedValue);
		Session["bankAdvId1"] = bankAdvId;
		txtChequeNo_Credit.Text = string.Empty;
	}

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		bankAdvId = Convert.ToInt32(DropDownList3.SelectedValue);
		Session["bankAdvId1"] = bankAdvId;
		txtChequeNo_Credit.Text = string.Empty;
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList1(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		int num2 = Convert.ToInt32(HttpContext.Current.Session["bankAdvId1"]);
		string cmdText = clsFunctions2.select("StartNo,(EndNo-StartNo)As range", "tblACC_ChequeNo", " BankId='" + num2 + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, connection);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		int num3 = 0;
		string[] array = new string[0];
		for (int i = 0; i <= Convert.ToInt32(dataSet.Tables[0].Rows[0]["Range"]); i++)
		{
			num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StartNo"]) + i;
			string cmdText2 = clsFunctions2.select("ChequeNo", "tblACC_BankVoucher_Payment_Master", " CompId='" + num + "' And Bank='" + num2 + "' And  ChequeNo='" + num3 + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count == 0 && num3.ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = num3.ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] Getbank(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select1("Id,Bank", "tblACC_BankReceived_Master");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void rddept_CheckedChanged(object sender, EventArgs e)
	{
		txtwono.Text = "";
	}

	protected void rdwono_CheckedChanged(object sender, EventArgs e)
	{
		drpdept.SelectedValue = "1";
	}
}

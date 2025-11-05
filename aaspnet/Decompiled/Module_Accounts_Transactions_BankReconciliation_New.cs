using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_BankReconciliation_New : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Panel Panel2;

	protected CheckBox chkCheckAll;

	protected CheckBox chkShowAll;

	protected Label Label4;

	protected TextBox txtFromDate;

	protected CalendarExtender txtFromDate_CalendarExtender;

	protected RegularExpressionValidator RegtxtFromDate;

	protected Label lblToDate;

	protected TextBox txtToDate;

	protected CalendarExtender txtToDate_CalendarExtender;

	protected RegularExpressionValidator RegtxtToDate;

	protected Button btnSearch;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button btnSubmit;

	protected Label Label2;

	protected Label lblTotal;

	protected TabPanel Add;

	protected CheckBox chkCheckAll_rec;

	protected CheckBox chkshowAll_rec;

	protected Label Label5;

	protected TextBox txtFromDate_rec;

	protected CalendarExtender CalendarExtender1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Label Label6;

	protected TextBox txtToDate_rec;

	protected CalendarExtender CalendarExtender2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected Button btnSearch_rec;

	protected GridView GridView3;

	protected Panel Panel3;

	protected Button btnSubmitRec;

	protected Label Label7;

	protected Label LabelREc;

	protected TabPanel TabPanel1;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string CDate = "";

	private string CTime = "";

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			con.Open();
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!Page.IsPostBack)
			{
				FillGrid();
				loadData();
				fillData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
			string text = "";
			string text2 = "";
			if (txtFromDate.Text != "" && txtToDate.Text != "")
			{
				text2 = " And ChequeDate between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "'";
			}
			text = ((!chkShowAll.Checked) ? ("select * from tblACC_BankVoucher_Payment_Master where tblACC_BankVoucher_Payment_Master.Id not in( Select  tblACC_BankRecanciliation.BVPId  from tblACC_BankRecanciliation)" + text2) : fun.select("*", "tblACC_BankVoucher_Payment_Master", "CompId='" + num2 + "'  And FinYearId<='" + num + "' " + text2));
			SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BVPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TransactionType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InstrumentNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InstrumentDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Debit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Credit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			double num3 = 0.0;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string value;
				if (int.TryParse(sqlDataReader["PaidType"].ToString(), out var _))
				{
					string cmdText = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(sqlDataReader["PaidType"]) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					value = sqlDataReader2["Particulars"].ToString();
				}
				else
				{
					value = fun.ECSNames(Convert.ToInt32(sqlDataReader["ECSType"].ToString()), sqlDataReader["PayTo"].ToString(), num2);
				}
				dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
				dataRow[1] = sqlDataReader["BVPNo"].ToString();
				dataRow[2] = value;
				dataRow[3] = "Payment";
				string value2 = "";
				switch (sqlDataReader["TransactionType"].ToString())
				{
				case "1":
					value2 = "RTGS";
					break;
				case "2":
					value2 = "NEFT";
					break;
				case "3":
					value2 = "DD";
					break;
				case "4":
					value2 = "Cheque";
					break;
				}
				dataRow[4] = value2;
				dataRow[5] = sqlDataReader["ChequeNo"].ToString();
				dataRow[6] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				double num4 = 0.0;
				double num5 = 0.0;
				string cmdText2 = "SELECT tblACC_BankVoucher_Payment_Details.Amount   FROM tblACC_BankVoucher_Payment_Details,tblACC_BankVoucher_Payment_Master where  tblACC_BankVoucher_Payment_Details.MId =tblACC_BankVoucher_Payment_Master.Id And tblACC_BankVoucher_Payment_Master.Id='" + Convert.ToInt32(sqlDataReader["Id"]) + "' ";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				double num6 = 0.0;
				while (sqlDataReader3.Read())
				{
					num6 += Convert.ToDouble(decimal.Parse(sqlDataReader3["Amount"].ToString()).ToString("N3"));
				}
				double num7 = 0.0;
				double num8 = 0.0;
				num7 = Convert.ToDouble(sqlDataReader["PayAmt"].ToString());
				num8 = Convert.ToDouble(sqlDataReader["AddAmt"].ToString());
				num5 = ((!int.TryParse(sqlDataReader["PaidType"].ToString(), out var _)) ? (num6 + num7) : (num6 + num7 + num8));
				dataRow[7] = num4;
				dataRow[8] = num5;
				string cmdText3 = fun.select("*", "tblACC_Bank", "Id=" + sqlDataReader["Bank"].ToString());
				SqlCommand sqlCommand4 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				dataRow[9] = sqlDataReader4["Name"].ToString();
				num3 += num5;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			lblTotal.Text = num3.ToString();
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			if (!chkShowAll.Checked)
			{
				return;
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num9 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText4 = " Select  *  from tblACC_BankRecanciliation where CompId='" + num2 + "'  And FinYearId<='" + num + "'  And BVPId='" + num9 + "'";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				while (sqlDataReader5.Read())
				{
					((CheckBox)row.FindControl("chk")).Visible = false;
					((TextBox)row.FindControl("txtBankDate")).Visible = false;
					((TextBox)row.FindControl("txtAddCharg")).Visible = false;
					((TextBox)row.FindControl("txtRemarks")).Visible = false;
					((Label)row.FindControl("Labeldate")).Visible = true;
					((Label)row.FindControl("Labeldate")).Text = fun.FromDateDMY(sqlDataReader5["BankDate"].ToString());
					((Label)row.FindControl("LabelAddCharg")).Visible = true;
					((Label)row.FindControl("LabelAddCharg")).Text = sqlDataReader5["AddCharges"].ToString();
					((Label)row.FindControl("LabelRemarks")).Visible = true;
					((Label)row.FindControl("LabelRemarks")).Text = sqlDataReader5["Remarks"].ToString();
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

	protected void chkCheckAll_CheckedChanged(object sender, EventArgs e)
	{
		if (chkCheckAll.Checked)
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				((CheckBox)row.FindControl("chk")).Checked = true;
			}
			return;
		}
		foreach (GridViewRow row2 in GridView2.Rows)
		{
			((CheckBox)row2.FindControl("chk")).Checked = false;
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = 0;
			int num2 = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("chk")).Checked)
				{
					num++;
					if (((TextBox)row.FindControl("txtBankDate")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtBankDate")).Text))
					{
						num2++;
					}
				}
			}
			if (num2 > 0 && num == num2)
			{
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (((CheckBox)row2.FindControl("chk")).Checked && ((TextBox)row2.FindControl("txtBankDate")).Text != "" && fun.DateValidation(((TextBox)row2.FindControl("txtBankDate")).Text))
					{
						int num3 = 0;
						num3 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						int num4 = 0;
						string empty = string.Empty;
						empty = ((TextBox)row2.FindControl("txtBankDate")).Text;
						double num5 = 0.0;
						num5 = Convert.ToDouble(((TextBox)row2.FindControl("txtAddCharg")).Text);
						string empty2 = string.Empty;
						empty2 = ((TextBox)row2.FindControl("txtRemarks")).Text;
						string cmdText = fun.insert("tblACC_BankRecanciliation", "SysDate,SysTime,CompId,FinYearId,SessionId,BVPId,BVRId,BankDate,AddCharges,Remarks", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + num3 + "','" + num4 + "','" + fun.FromDate(empty) + "','" + num5 + "','" + empty2 + "'");
						sqlConnection.Open();
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Invalid data input .";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void chkShowAll_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			loadData();
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = fun.select1("Id,Name", "tblACC_Bank order by OrdNo Asc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Trans", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ClAmt", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Name"].ToString();
				if (dataSet.Tables[0].Rows[i]["Name"].ToString() == "Cash")
				{
					dataRow[2] = fun.getCashOpBalAmt("<", fun.getCurrDate(), CompId, FinYearId).ToString();
					dataRow[3] = fun.getCashClBalAmt("=", fun.getCurrDate(), CompId, FinYearId).ToString();
				}
				else
				{
					dataRow[2] = fun.getBankOpBalAmt("<", fun.getCurrDate(), CompId, FinYearId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"])).ToString();
					dataRow[3] = fun.getBankClBalAmt("=", fun.getCurrDate(), CompId, FinYearId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"])).ToString();
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

	public void fillData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
			string text = "";
			string text2 = "";
			if (txtFromDate_rec.Text != "" && txtToDate_rec.Text != "")
			{
				text2 = " And ChequeDate between '" + fun.FromDate(txtFromDate_rec.Text) + "' And '" + fun.FromDate(txtToDate_rec.Text) + "'";
			}
			text = ((!chkshowAll_rec.Checked) ? ("select * from tblACC_BankVoucher_Received_Masters where tblACC_BankVoucher_Received_Masters.Id not in( Select  tblACC_BankRecanciliation.BVRId  from tblACC_BankRecanciliation)" + text2) : fun.select("*", "tblACC_BankVoucher_Received_Masters", "CompId='" + num2 + "'  And FinYearId<='" + num + "' " + text2));
			SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BVRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Particulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VchType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TransactionType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InstrumentNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InstrumentDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Debit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Credit", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BankName", typeof(string)));
			double num3 = 0.0;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string value = ((Convert.ToInt32(sqlDataReader["ReceiveType"]) != 4) ? fun.ECSNames(Convert.ToInt32(sqlDataReader["ReceiveType"].ToString()), sqlDataReader["ReceivedFrom"].ToString(), num2) : sqlDataReader["ReceivedFrom"].ToString());
				dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
				dataRow[1] = sqlDataReader["BVRNo"].ToString();
				dataRow[2] = value;
				dataRow[3] = "Receipt";
				string value2 = "";
				if (Convert.ToInt32(sqlDataReader["TransactionType"]) == 1)
				{
					value2 = "RTGS";
				}
				else if (Convert.ToInt32(sqlDataReader["TransactionType"]) == 2)
				{
					value2 = "NEFT";
				}
				else if (Convert.ToInt32(sqlDataReader["TransactionType"]) == 3)
				{
					value2 = "DD";
				}
				else if (Convert.ToInt32(sqlDataReader["TransactionType"]) == 4)
				{
					value2 = "Cheque";
				}
				dataRow[4] = value2;
				dataRow[5] = sqlDataReader["ChequeNo"].ToString();
				dataRow[6] = fun.FromDateDMY(sqlDataReader["ChequeDate"].ToString());
				double num4 = 0.0;
				double num5 = 0.0;
				num4 = Convert.ToDouble(sqlDataReader["Amount"]);
				dataRow[7] = num4;
				dataRow[8] = num5;
				dataRow[9] = sqlDataReader["BankName"].ToString();
				num3 += num4;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			LabelREc.Text = num3.ToString();
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			if (!chkshowAll_rec.Checked)
			{
				return;
			}
			foreach (GridViewRow row in GridView3.Rows)
			{
				int num6 = Convert.ToInt32(((Label)row.FindControl("lblId_Rec")).Text);
				string cmdText = " Select  *  from tblACC_BankRecanciliation where CompId='" + num2 + "'  And FinYearId<='" + num + "'  And BVRId='" + num6 + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					((CheckBox)row.FindControl("chk_Rec")).Visible = false;
					((TextBox)row.FindControl("txtBankDate_Rec")).Visible = false;
					((TextBox)row.FindControl("txtAddCharg_Rec")).Visible = false;
					((TextBox)row.FindControl("txtRemarks_Rec")).Visible = false;
					((Label)row.FindControl("Labeldate_Rec")).Visible = true;
					((Label)row.FindControl("Labeldate_Rec")).Text = fun.FromDateDMY(sqlDataReader2["BankDate"].ToString());
					((Label)row.FindControl("LabelAddCharg_Rec")).Visible = true;
					((Label)row.FindControl("LabelAddCharg_Rec")).Text = sqlDataReader2["AddCharges"].ToString();
					((Label)row.FindControl("LabelRemarks_Rec")).Visible = true;
					((Label)row.FindControl("LabelRemarks_Rec")).Text = sqlDataReader2["Remarks"].ToString();
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

	protected void btnSearch_rec_Click(object sender, EventArgs e)
	{
		try
		{
			fillData();
		}
		catch (Exception)
		{
		}
	}

	protected void chkCheckAll_rec_CheckedChanged(object sender, EventArgs e)
	{
		if (chkCheckAll_rec.Checked)
		{
			foreach (GridViewRow row in GridView3.Rows)
			{
				((CheckBox)row.FindControl("chk_Rec")).Checked = true;
			}
			return;
		}
		foreach (GridViewRow row2 in GridView3.Rows)
		{
			((CheckBox)row2.FindControl("chk_Rec")).Checked = false;
		}
	}

	protected void btnSubmitRec_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = 0;
			int num2 = 0;
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (((CheckBox)row.FindControl("chk_Rec")).Checked)
				{
					num++;
					if (((TextBox)row.FindControl("txtBankDate_Rec")).Text != "" && fun.DateValidation(((TextBox)row.FindControl("txtBankDate_Rec")).Text))
					{
						num2++;
					}
				}
			}
			if (num2 > 0 && num == num2)
			{
				foreach (GridViewRow row2 in GridView3.Rows)
				{
					if (((CheckBox)row2.FindControl("chk_Rec")).Checked && ((TextBox)row2.FindControl("txtBankDate_Rec")).Text != "" && fun.DateValidation(((TextBox)row2.FindControl("txtBankDate_Rec")).Text))
					{
						int num3 = 0;
						num3 = Convert.ToInt32(((Label)row2.FindControl("lblId_Rec")).Text);
						int num4 = 0;
						string empty = string.Empty;
						empty = ((TextBox)row2.FindControl("txtBankDate_Rec")).Text;
						double num5 = 0.0;
						num5 = Convert.ToDouble(((TextBox)row2.FindControl("txtAddCharg_Rec")).Text);
						string empty2 = string.Empty;
						empty2 = ((TextBox)row2.FindControl("txtRemarks_Rec")).Text;
						string cmdText = fun.insert("tblACC_BankRecanciliation", "SysDate,SysTime,CompId,FinYearId,SessionId,BVPId,BVRId,BankDate,AddCharges,Remarks", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + SId + "','" + num4 + "','" + num3 + "','" + fun.FromDate(empty) + "','" + num5 + "','" + empty2 + "'");
						sqlConnection.Open();
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Invalid data input .";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void chkshowAll_rec_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			fillData();
		}
		catch (Exception)
		{
		}
	}
}

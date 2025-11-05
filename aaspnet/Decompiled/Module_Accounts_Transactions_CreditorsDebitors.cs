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

public class Module_Accounts_Transactions_CreditorsDebitors : Page, IRequiresSessionState
{
	protected TextBox TextBox1;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected Button btn_Search;

	protected GridView GridView1;

	protected Label lblMessage;

	protected TabPanel Creditors;

	protected TextBox TextBox2;

	protected AutoCompleteExtender TextBox2_AutoCompleteExtender;

	protected Button btn_deb_search;

	protected GridView GridView2;

	protected Label lblMessage2;

	protected SqlDataSource SqlDataSource2;

	protected TabPanel Debitors;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string SId = "";

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
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			lblMessage.Text = "";
			lblMessage2.Text = "";
			if (!Page.IsPostBack)
			{
				FillGrid_Creditors();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = string.Empty;
				if (((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text != "")
				{
					string code = fun.getCode(((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text);
					int num = fun.chkSupplierCode(code);
					if (num == 1 && ((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text != string.Empty)
					{
						text = code;
					}
					else
					{
						((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text = string.Empty;
					}
				}
				string cmdText = fun.select("SupplierId", "tblACC_Creditors_Master", "SupplierId='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					double num2 = 0.0;
					if (((TextBox)GridView1.FooterRow.FindControl("txtOpeningAmt2")).Text != "")
					{
						num2 = Math.Round(Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtOpeningAmt2")).Text), 2);
					}
					if (((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text != "" && text != "")
					{
						if (((TextBox)GridView1.FooterRow.FindControl("txtOpeningAmt2")).Text != "" && num2 != 0.0)
						{
							string cmdText2 = fun.insert("tblACC_Creditors_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,SupplierId,OpeningAmt", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + num2 + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							lblMessage.Text = "Record Inserted";
							FillGrid_Creditors();
						}
					}
					else
					{
						_ = string.Empty;
						string text2 = "Supplier is not valid";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text2 + "');", addScriptTags: true);
					}
				}
				else
				{
					_ = string.Empty;
					string text3 = "Supplier is already exist";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text3 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Add1")
			{
				string text4 = string.Empty;
				if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text != "")
				{
					string code2 = fun.getCode(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text);
					int num3 = fun.chkSupplierCode(code2);
					if (num3 == 1 && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text != string.Empty)
					{
						text4 = code2;
					}
					else
					{
						((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text = string.Empty;
					}
				}
				double num4 = 0.0;
				if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text != "")
				{
					num4 = Math.Round(Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text), 2);
				}
				if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text != "" && text4 != "")
				{
					if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text != "" && num4 != 0.0)
					{
						string cmdText3 = fun.insert("tblACC_Creditors_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,SupplierId,OpeningAmt", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text4 + "','" + num4 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
						lblMessage.Text = "Record Inserted";
						FillGrid_Creditors();
					}
				}
				else
				{
					_ = string.Empty;
					string text5 = "Supplier is not valid";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text5 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text6 = ((Label)gridViewRow.FindControl("lblId")).Text;
				SqlCommand sqlCommand3 = new SqlCommand("DELETE FROM [tblACC_Creditors_Master] WHERE [Id] = '" + text6 + "'", con);
				con.Open();
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				lblMessage.Text = "Record Deleted";
				FillGrid_Creditors();
			}
			if (e.CommandName == "LnkBtn")
			{
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string empty = string.Empty;
				empty = ((Label)gridViewRow2.FindControl("lblSupId")).Text;
				base.Response.Redirect("CreditorsDebitors_InDetailList.aspx?SupId=" + empty + "&ModId=11&SubModId=135&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "AddD")
			{
				string text = string.Empty;
				if (((TextBox)GridView2.FooterRow.FindControl("txtCustomerId2")).Text != "")
				{
					string code = fun.getCode(((TextBox)GridView2.FooterRow.FindControl("txtCustomerId2")).Text);
					int num = fun.chkCustomerCode(code);
					if (num == 1 && ((TextBox)GridView2.FooterRow.FindControl("txtCustomerId2")).Text != string.Empty)
					{
						text = code;
					}
					else
					{
						((TextBox)GridView2.FooterRow.FindControl("txtCustomerId2")).Text = string.Empty;
					}
				}
				double num2 = 0.0;
				num2 = ((!(((TextBox)GridView2.FooterRow.FindControl("txtOpeningAmtD2")).Text != "")) ? 0.0 : Math.Round(Convert.ToDouble(((TextBox)GridView2.FooterRow.FindControl("txtOpeningAmtD2")).Text), 2));
				string cmdText = fun.select("CustomerId", "tblACC_Debitors_Master", "CustomerId='" + text + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					if (((TextBox)GridView2.FooterRow.FindControl("txtCustomerId2")).Text != "" && text != "")
					{
						if (((TextBox)GridView2.FooterRow.FindControl("txtOpeningAmtD2")).Text != "" && num2 != 0.0)
						{
							string cmdText2 = fun.insert("tblACC_Debitors_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,OpeningAmt", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + num2 + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							lblMessage2.Text = "Record Inserted";
							FillGrid_Debitors();
						}
					}
					else
					{
						_ = string.Empty;
						string text2 = "Customer is not valid";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text2 + "');", addScriptTags: true);
					}
				}
				else
				{
					_ = string.Empty;
					string text3 = "Customer is already exist";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text3 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "AddD1")
			{
				string text4 = string.Empty;
				if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTermsD3")).Text != "")
				{
					string code2 = fun.getCode(((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTermsD3")).Text);
					int num3 = fun.chkCustomerCode(code2);
					if (num3 == 1 && ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTermsD3")).Text != string.Empty)
					{
						text4 = code2;
					}
					else
					{
						((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTermsD3")).Text = string.Empty;
					}
				}
				double num4 = 0.0;
				if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtValueD3")).Text != "")
				{
					num4 = Math.Round(Convert.ToDouble(((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtValueD3")).Text), 2);
				}
				if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTermsD3")).Text != "" && text4 != "")
				{
					if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtValueD3")).Text != "" && num4 != 0.0)
					{
						string cmdText3 = fun.insert("tblACC_Debitors_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,OpeningAmt", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text4 + "','" + num4 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
						lblMessage2.Text = "Record Inserted";
						FillGrid_Debitors();
					}
				}
				else
				{
					_ = string.Empty;
					string text5 = "Customer is not valid";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text5 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "DelD")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text6 = ((Label)gridViewRow.FindControl("lblIdD")).Text;
				SqlCommand sqlCommand3 = new SqlCommand("DELETE FROM [tblACC_Debitors_Master] WHERE [Id] = '" + text6 + "'", con);
				con.Open();
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				lblMessage2.Text = "Record Deleted";
				FillGrid_Debitors();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Accounts/Transactions/Dashboard.aspx?ModId=11&SubModId=135");
	}

	public void FillGrid_Creditors()
	{
		try
		{
			TotalTdsDeduct totalTdsDeduct = new TotalTdsDeduct();
			string text = string.Empty;
			if (TextBox1.Text != string.Empty)
			{
				text = " And tblMM_Supplier_master.SupplierId='" + fun.getCode(TextBox1.Text) + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT tblACC_Creditors_Master.Id,tblMM_Supplier_master.SupplierId,tblMM_Supplier_master.SupplierName+' ['+tblMM_Supplier_master.SupplierId+']' AS SupplierName,tblMM_Supplier_master.SupplierId,tblACC_Creditors_Master.OpeningAmt FROM tblACC_Creditors_Master INNER JOIN tblMM_Supplier_master ON tblACC_Creditors_Master.SupplierId = tblMM_Supplier_master.SupplierId" + text + " And tblACC_Creditors_Master.CompId='" + CompId + "'  order by tblMM_Supplier_master.SupplierId Asc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("BookBillAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PaymentAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ClosingAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TDSAmt", typeof(double)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader["SupplierName"].ToString();
				double num = 0.0;
				if (sqlDataReader["OpeningAmt"] != DBNull.Value)
				{
					num = Math.Round(Convert.ToDouble(sqlDataReader["OpeningAmt"]), 2);
				}
				dataRow[2] = num;
				double num2 = 0.0;
				num2 = FillGrid_CreditorsBookedBill(sqlDataReader["SupplierId"].ToString());
				dataRow[3] = Math.Round(num2, 2);
				double num3 = 0.0;
				num3 = FillGrid_CreditorsPayment(sqlDataReader["SupplierId"].ToString());
				dataRow[4] = Math.Round(num3, 2);
				double num4 = 0.0;
				num4 = totalTdsDeduct.Check_TDSAmt(CompId, FinYearId, sqlDataReader["SupplierId"].ToString());
				double num5 = 0.0;
				num5 = Math.Round(num + num2 - (num4 + num3), 2);
				dataRow[5] = num5;
				dataRow[6] = sqlDataReader["SupplierId"].ToString();
				dataRow[7] = num4;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				_ = string.Empty;
				_ = ((Label)row.FindControl("lblSupId")).Text;
				double num6 = 0.0;
				num6 = Convert.ToDouble(((Label)row.FindControl("lblBookBill")).Text);
				double num7 = 0.0;
				num7 = Convert.ToDouble(((Label)row.FindControl("lblPayment")).Text);
				if (num6 != 0.0 || num7 != 0.0)
				{
					((Label)row.FindControl("lblTerms2")).Visible = false;
					((LinkButton)row.FindControl("lblTerms")).Visible = true;
				}
				else
				{
					((Label)row.FindControl("lblTerms2")).Visible = true;
					((LinkButton)row.FindControl("lblTerms")).Visible = false;
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

	public void FillGrid_Debitors()
	{
		try
		{
			string text = string.Empty;
			if (TextBox2.Text != string.Empty)
			{
				text = " And tblACC_Debitors_Master.CustomerId='" + fun.getCode(TextBox2.Text) + "'";
			}
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT tblACC_Debitors_Master.Id,SD_Cust_master.CustomerId,SD_Cust_master.CustomerName+' ['+SD_Cust_master.CustomerId+']' AS CustomerName,tblACC_Debitors_Master.OpeningAmt FROM tblACC_Debitors_Master INNER JOIN SD_Cust_master ON tblACC_Debitors_Master.CustomerId = SD_Cust_master.CustomerId" + text + " And tblACC_Debitors_Master.CompId='" + CompId + "' order by SD_Cust_master.CustomerId Asc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("SalesInvAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ServiceInvAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PerformaInvAmt", typeof(double)));
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["Id"].ToString();
				dataRow[1] = sqlDataReader["CustomerName"].ToString();
				double num = 0.0;
				if (sqlDataReader["OpeningAmt"] != DBNull.Value)
				{
					num = Convert.ToDouble(sqlDataReader["OpeningAmt"]);
				}
				dataRow[2] = num;
				double num2 = 0.0;
				num2 = Cal_SalesInvoice(sqlDataReader["CustomerId"].ToString());
				dataRow[3] = num2;
				dataRow[4] = Cal_ServiceInvoice(sqlDataReader["CustomerId"].ToString());
				dataRow[5] = Cal_PerformaInvoice(sqlDataReader["CustomerId"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			FillGrid_Creditors();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			FillGrid_Debitors();
		}
		catch (Exception)
		{
		}
	}

	public double FillGrid_CreditorsBookedBill(string GetSupCode)
	{
		double num = 0.0;
		try
		{
			string cmdText = "select (Case When GQNId !=0 then (Select Sum(tblQc_MaterialQuality_Details.AcceptedQty) from tblQc_MaterialQuality_Details where tblQc_MaterialQuality_Details.Id=tblACC_BillBooking_Details.GQNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100) Else (Select Sum(tblinv_MaterialServiceNote_Details.ReceivedQty) As AcceptedQty from tblinv_MaterialServiceNote_Details where tblinv_MaterialServiceNote_Details.Id=tblACC_BillBooking_Details.GSNId)*(tblMM_PO_Details.Rate - (tblMM_PO_Details.Rate * tblMM_PO_Details.Discount) / 100)End) +PFAmt+ExStBasic+ExStEducess+ExStShecess+tblACC_BillBooking_Details.VAT+CST+tblACC_BillBooking_Details.Freight+tblACC_BillBooking_Details.BCDValue+tblACC_BillBooking_Details.EdCessOnCDValue+tblACC_BillBooking_Details.SHEDCessValue As TotalBookedBill,tblACC_BillBooking_Master.Discount,tblACC_BillBooking_Master.DiscountType,tblACC_BillBooking_Master.DebitAmt,tblACC_BillBooking_Master.OtherCharges from tblACC_BillBooking_Master,tblACC_BillBooking_Details,tblMM_PO_Details,tblMM_PO_Master where tblACC_BillBooking_Master.CompId='" + CompId + "' And tblACC_BillBooking_Master.SupplierId='" + GetSupCode + "' And tblACC_BillBooking_Master.Id=tblACC_BillBooking_Details.MId AND tblACC_BillBooking_Master.FinYearId<='" + FinYearId + "' And tblMM_PO_Details.Id=tblACC_BillBooking_Details.PODId AND tblMM_PO_Master.Id=tblMM_PO_Details.MId";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			while (sqlDataReader.Read())
			{
				num += Convert.ToDouble(sqlDataReader["TotalBookedBill"]);
				num2 = Convert.ToDouble(sqlDataReader["OtherCharges"]);
				num3 = Convert.ToDouble(sqlDataReader["DiscountType"]);
				num4 = Convert.ToDouble(sqlDataReader["Discount"]);
				num5 = Convert.ToDouble(sqlDataReader["DebitAmt"]);
			}
			num += num2;
			if (num3 == 0.0)
			{
				num -= num4;
			}
			else if (num3 == 1.0)
			{
				num -= num * num4 / 100.0;
			}
			num -= num5;
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}

	public double FillGrid_CreditorsPayment(string GetSupCode)
	{
		double num = 0.0;
		try
		{
			string cmdText = fun.select("Id,PayAmt ", " tblACC_BankVoucher_Payment_Master ", " CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND PayTo='" + GetSupCode + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				double num2 = 0.0;
				string cmdText2 = "Select Sum(Amount)As Amt from tblACC_BankVoucher_Payment_Details inner join tblACC_BankVoucher_Payment_Master on tblACC_BankVoucher_Payment_Details.MId=tblACC_BankVoucher_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_BankVoucher_Payment_Details.MId='" + sqlDataReader["Id"].ToString() + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					if (sqlDataReader2["Amt"] != DBNull.Value)
					{
						num2 = Convert.ToDouble(decimal.Parse(sqlDataReader2["Amt"].ToString()).ToString("N3"));
					}
				}
				double num3 = 0.0;
				num3 = Convert.ToDouble(sqlDataReader["PayAmt"]);
				num += Math.Round(num2 + num3, 2);
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	public double Cal_SalesInvoice(string CustCode)
	{
		new DataSet();
		double num = 0.0;
		try
		{
			string cmdText = "Select sum ((ReqQty*AmtInPer/100)*Rate) as Amt,Pf,PFType,FreightType,Freight,CENVAT,VAT,CST,AddType,AddAmt,DeductionType,Deduction from tblACC_SalesInvoice_Details inner join tblACC_SalesInvoice_Master on tblACC_SalesInvoice_Master.Id=tblACC_SalesInvoice_Details.MId  And  CustomerCode='" + CustCode + "' And CompId='" + CompId + "' group by Pf,PFType,FreightType,Freight,CENVAT,VAT,CST,AddType,AddAmt,DeductionType,Deduction ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				num7 = Convert.ToDouble(sqlDataReader["Amt"]);
				num5 = ((Convert.ToInt32(sqlDataReader["AddType"]) != 0) ? (num7 * Convert.ToDouble(sqlDataReader["AddAmt"]) / 100.0) : Convert.ToDouble(sqlDataReader["AddAmt"]));
				num6 = ((Convert.ToInt32(sqlDataReader["DeductionType"]) != 0) ? (num7 * Convert.ToDouble(sqlDataReader["Deduction"]) / 100.0) : Convert.ToDouble(sqlDataReader["Deduction"]));
				num2 = Math.Round(num7 + num5 - num6, 3);
				num3 = ((Convert.ToInt32(sqlDataReader["PFType"]) != 0) ? (num2 * Convert.ToDouble(sqlDataReader["PF"]) / 100.0) : Convert.ToDouble(sqlDataReader["PF"]));
				num4 = ((Convert.ToInt32(sqlDataReader["FreightType"]) != 0) ? (num2 * Convert.ToDouble(sqlDataReader["Freight"]) / 100.0) : Convert.ToDouble(sqlDataReader["Freight"]));
				string cmdText2 = fun.select("Value", "tblExciseser_Master", string.Concat("Id='", sqlDataReader["CENVAT"], "'"));
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				double num8 = 0.0;
				double num9 = 0.0;
				num9 = num2 + num3;
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num8 = num9 * Convert.ToDouble(dataSet.Tables[0].Rows[0]["Value"]) / 100.0;
				}
				double num10 = 0.0;
				double num11 = 0.0;
				num10 = num9 + num8;
				if (sqlDataReader["VAT"].ToString() != "0")
				{
					string cmdText3 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader["VAT"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblVAT_Master");
					num11 = num10 + (num10 + num4) * Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Value"]) / 100.0;
				}
				else if (sqlDataReader["CST"].ToString() != "0")
				{
					string cmdText4 = fun.select("Value", "tblVAT_Master", "Id='" + sqlDataReader["CST"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "tblVAT_Master");
					num11 = num10 + num10 * Convert.ToDouble(dataSet3.Tables[0].Rows[0]["Value"]) / 100.0 + num4;
				}
				else if (sqlDataReader["CST"].ToString() == "0" && sqlDataReader["VAT"].ToString() == "0")
				{
					num11 = num10 + num4;
				}
				num += num11;
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}

	public double Cal_ServiceInvoice(string CustCode)
	{
		double num = 0.0;
		try
		{
			string cmdText = "Select((sum ((ReqQty*AmtInPer/100)*Rate))+(Case When AddType =0 then AddAmt  Else (sum ((ReqQty*AmtInPer/100)*Rate)*AddAmt/100) END)-(Case When DeductionType =0 then Deduction  Else (sum ((ReqQty*AmtInPer/100)*Rate)*Deduction/100) END))+(( (sum ((ReqQty*AmtInPer/100)*Rate))+(Case When AddType =0 then AddAmt  Else (sum ((ReqQty*AmtInPer/100)*Rate)*AddAmt/100) END)-(Case When DeductionType =0 then Deduction  Else (sum ((ReqQty*AmtInPer/100)*Rate)*Deduction/100) END))* value/100) As TotBasic from tblACC_ServiceTaxInvoice_Details inner join tblACC_ServiceTaxInvoice_Master on tblACC_ServiceTaxInvoice_Master.Id=tblACC_ServiceTaxInvoice_Details.MId  inner join tblExciseser_Master on tblExciseser_Master.Id=tblACC_ServiceTaxInvoice_Master.ServiceTax And CustomerCode='" + CustCode + "' And CompId='" + CompId + "' group by AddType,AddAmt,DeductionType,Deduction,Value ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num += Convert.ToDouble(sqlDataReader["TotBasic"]);
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
	}

	public double Cal_PerformaInvoice(string CustCode)
	{
		double num = 0.0;
		try
		{
			string cmdText = "Select (case when  Unit_Master.EffectOnInvoice=1 then  sum ((ReqQty*AmtInPer/100)*Rate)+(Case When AddType =0 then AddAmt  Else (sum ((ReqQty*AmtInPer/100)*Rate)*AddAmt/100) END)-(Case When DeductionType =0 then Deduction  Else (sum ((ReqQty*AmtInPer/100)*Rate)*Deduction/100) END) else  sum (ReqQty*Rate)+(Case When AddType =0 then AddAmt  Else (sum ((ReqQty)*Rate)*AddAmt/100) END)-(Case When DeductionType =0 then Deduction  Else (sum ((ReqQty)*Rate)*Deduction/100) END) End) As TotBal from tblACC_ProformaInvoice_Details inner join tblACC_ProformaInvoice_Master on tblACC_ProformaInvoice_Master.Id=tblACC_ProformaInvoice_Details.MId inner join Unit_Master on Unit_Master.Id=tblACC_ProformaInvoice_Details.Unit And CustomerCode='" + CustCode + "' And CompId='" + CompId + "' group by AddType,AddAmt,DeductionType,Deduction,EffectOnInvoice ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				num += Convert.ToDouble(sqlDataReader["TotBal"]);
			}
		}
		catch (Exception)
		{
		}
		return Math.Round(num, 2);
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
		switch ((contextKey == "key2") ? 1 : 2)
		{
		case 1:
		{
			string selectCommandText2 = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "' Order By CustomerName ASC");
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection);
			sqlDataAdapter2.Fill(dataSet, "SD_Cust_master");
			break;
		}
		case 2:
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

	protected void btn_Search_Click(object sender, EventArgs e)
	{
		FillGrid_Creditors();
	}

	protected void btn_deb_search_Click(object sender, EventArgs e)
	{
		FillGrid_Debitors();
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			FillGrid_Debitors();
		}
		else
		{
			FillGrid_Creditors();
		}
	}
}

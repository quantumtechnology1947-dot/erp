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

public class Module_Accounts_Transactions_ProformaInvoice_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string CDate = "";

	private string CTime = "";

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string WN = "";

	private string PN = "";

	private string PId = "";

	private string CCode = "";

	private string typ = "";

	private string pdate = "";

	private SqlConnection con;

	protected TextBox TxtInvNo;

	protected RequiredFieldValidator ReqInVNo;

	protected RegularExpressionValidator RegularExpressionValidatorInv;

	protected Label LblInvDate;

	protected Label LblMode;

	protected SqlDataSource SqlCommodity;

	protected SqlDataSource SqlCat;

	protected Label LblPONo;

	protected Label LblPODate;

	protected Label LblWONo;

	protected SqlDataSource Sqltransport;

	protected SqlDataSource Sqlnature;

	protected TextBox TxtDateofIssueInvoice;

	protected CalendarExtender TxtDateofIssueInvoice_CalendarExtender;

	protected RequiredFieldValidator ReqDateofinvoce;

	protected RegularExpressionValidator RegDateOfIssInvoice;

	protected TextBox TxtBYName;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected RequiredFieldValidator ReqByName;

	protected Button Button5;

	protected TextBox TxtByAddress;

	protected RequiredFieldValidator ReqByAddress;

	protected DropDownList DrpByCountry;

	protected DropDownList DrpByState;

	protected DropDownList DrpByCity;

	protected TextBox TxtByCName;

	protected RequiredFieldValidator ReqByCName;

	protected TextBox TxtByPhone;

	protected RequiredFieldValidator ReqByPhone;

	protected TextBox TxtByMobile;

	protected RequiredFieldValidator ReqByMobile;

	protected TextBox TxtByEmail;

	protected RequiredFieldValidator ReqByEmail;

	protected RegularExpressionValidator RegEmailvalBuyer;

	protected TextBox TxtByFaxNo;

	protected RequiredFieldValidator ReqFaxNo;

	protected TextBox TxtByTINVATNo;

	protected RequiredFieldValidator ReqByTinVatNo;

	protected TextBox TxtByECCNo;

	protected RequiredFieldValidator ReqCustEccNo;

	protected TextBox TxtByTINCSTNo;

	protected RequiredFieldValidator ReqByTInCStNo;

	protected Button BtnBuy;

	protected Button Button1;

	protected TabPanel TabPanel1;

	protected TextBox TxtCName;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator ReqCName;

	protected Button Button4;

	protected Button Button6;

	protected TextBox TxtCAddress;

	protected RequiredFieldValidator ReqCaddress;

	protected DropDownList DrpCoCountry;

	protected DropDownList DrpCoState;

	protected DropDownList DrpCoCity;

	protected TextBox TxtCoPersonName;

	protected RequiredFieldValidator ReqCoperson;

	protected TextBox TxtCoPhoneNo;

	protected RequiredFieldValidator ReqCPhoneno;

	protected TextBox TxtCoMobileNo;

	protected RequiredFieldValidator ReqCMobileno;

	protected TextBox TxtCoEmail;

	protected RequiredFieldValidator ReqCEmail;

	protected RegularExpressionValidator RegEmailvalConsignee;

	protected TextBox TxtCoFaxNo;

	protected RequiredFieldValidator ReqCFaxNo;

	protected TextBox TxtCoTinVatNo;

	protected RequiredFieldValidator ReqCTinVatno;

	protected TextBox TxtECoCCNo;

	protected RequiredFieldValidator ReqCECCNo;

	protected TextBox TxtCoTinCSTNo;

	protected RequiredFieldValidator ReqCTINcstno;

	protected Button BtnCNext;

	protected Button Button2;

	protected TabPanel TabPanel2;

	protected GridView GridView1;

	protected Panel Panel1;

	protected SqlDataSource SqlUnitQty;

	protected Button Btngoods;

	protected Button Button3;

	protected TabPanel TabPanel3;

	protected TextBox TxtAdd;

	protected RequiredFieldValidator ReqAdd;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected DropDownList DrpAdd;

	protected TextBox TxtDeduct;

	protected RequiredFieldValidator ReqDed;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList DrpDed;

	protected Button BtnSubmit;

	protected Button BtnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		con = new SqlConnection(connectionString);
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			WN = fun.Decrypt(base.Request.QueryString["wn"].ToString());
			PN = fun.Decrypt(base.Request.QueryString["pn"].ToString());
			PId = fun.Decrypt(base.Request.QueryString["poid"].ToString());
			CCode = fun.Decrypt(base.Request.QueryString["cid"].ToString());
			typ = fun.Decrypt(base.Request.QueryString["ty"].ToString());
			pdate = fun.Decrypt(base.Request.QueryString["date"].ToString());
			string currDate = fun.getCurrDate();
			LblInvDate.Text = fun.FromDateDMY(currDate);
			LblPODate.Text = pdate;
			new DataSet();
			con.Open();
			string[] array = WN.Split(',');
			string text = "";
			for (int i = 0; i < array.Length - 1; i++)
			{
				string cmdText = fun.select("WONo", "SD_Cust_WorkOrder_Master", "Id='" + array[i] + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					text = text + dataSet.Tables[0].Rows[0][0].ToString() + ",";
				}
				LblWONo.Text = text;
			}
			LblPONo.Text = PN;
			string cmdText2 = fun.select("Against", "tblACC_InvoiceAgainst", "Id='" + typ + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblACC_InvoiceAgainst");
			LblMode.Text = dataSet2.Tables[0].Rows[0][0].ToString();
			string cmdText3 = fun.select("InvoiceNo", "tblACC_ProformaInvoice_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by InvoiceNo desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3, "tblACC_ProformaInvoice_Master");
			string text2 = "";
			text2 = ((dataSet3.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet3.Tables[0].Rows[0]["InvoiceNo"]) + 1).ToString("D4"));
			TxtInvNo.Text = text2;
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
			GetValidate();
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DrpByCountry, DrpByState);
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				string cmdText4 = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + CCode + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				TxtBYName.Text = dataSet4.Tables[0].Rows[0]["Customer"].ToString();
				TxtByAddress.Text = dataSet4.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dataSet4.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpByCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpByCountry, DrpByState);
				fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
				fun.dropdownStatebyId(DrpByState, "CId='" + dataSet4.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet4.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpByState.SelectedValue = dataSet4.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpByCity, DrpByState);
				fun.dropdownCitybyId(DrpByCity, "SId='" + dataSet4.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet4.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpByCity.SelectedValue = dataSet4.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtByFaxNo.Text = dataSet4.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtByCName.Text = dataSet4.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtByPhone.Text = dataSet4.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtByTINCSTNo.Text = dataSet4.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtByTINVATNo.Text = dataSet4.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtByMobile.Text = dataSet4.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtByEmail.Text = dataSet4.Tables[0].Rows[0]["Email"].ToString();
				TxtByECCNo.Text = dataSet4.Tables[0].Rows[0]["EccNo"].ToString();
				fillgrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("ck")).Checked)
			{
				((RequiredFieldValidator)row.FindControl("ReqQty")).Visible = true;
				((RequiredFieldValidator)row.FindControl("ReqAmt")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)row.FindControl("ReqQty")).Visible = false;
				((RequiredFieldValidator)row.FindControl("ReqAmt")).Visible = false;
			}
		}
	}

	public void fillgrid()
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			string cmdText = fun.select("SD_Cust_PO_Master.POId,SD_Cust_PO_Details.Id,SD_Cust_PO_Details.ItemDesc,SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Unit,SD_Cust_PO_Details.Rate", "SD_Cust_PO_Master,SD_Cust_PO_Details", " SD_Cust_PO_Master.PONo='" + PN + "' AND SD_Cust_PO_Details.POId=SD_Cust_PO_Master.POId And SD_Cust_PO_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId='" + PId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotalQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(float)));
			dataTable.Columns.Add(new DataColumn("RemainingQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Amt", typeof(double)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					DataRow dataRow = dataTable.NewRow();
					string cmdText2 = fun.select("Id,Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					int num4 = 0;
					string cmdText3 = fun.select(" Sum(tblACC_ProformaInvoice_Details.ReqQty) as ReqQty", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details,SD_Cust_PO_Master,SD_Cust_PO_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "' AND SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId  And tblACC_ProformaInvoice_Details.ItemId=SD_Cust_PO_Details.Id ANd tblACC_ProformaInvoice_Master.POId=SD_Cust_PO_Master.POId  AND tblACC_ProformaInvoice_Master.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblACC_ProformaInvoice_Details.ItemId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' Group By tblACC_ProformaInvoice_Details.ItemId ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["ReqQty"] != DBNull.Value)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
					}
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["TotalQty"].ToString()).ToString("N3"));
					num2 = Math.Round(num3 - num, 3);
					if (num2 > 0.0)
					{
						num4++;
					}
					if (num4 > 0)
					{
						dataRow[0] = dataSet.Tables[0].Rows[i]["POId"].ToString();
						dataRow[1] = dataSet.Tables[0].Rows[i]["ItemDesc"].ToString();
						dataRow[2] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["TotalQty"].ToString()).ToString("N3"));
						dataRow[3] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
						dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
						dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
						dataRow[6] = num2;
						dataRow[7] = 0;
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

	protected void BtnBuy_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		string text = TxtInvNo.Text;
		string text2 = "";
		int num = 1;
		int num2 = 1;
		int num3 = 1;
		try
		{
			sqlConnection.Open();
			if (DrpByCountry.SelectedIndex != 0 && DrpByState.SelectedIndex != 0 && DrpByCity.SelectedIndex != 0 && DrpCoCountry.SelectedIndex != 0 && DrpCoState.SelectedIndex != 0 && DrpCoCity.SelectedIndex != 0 && TxtInvNo.Text != "" && TxtDateofIssueInvoice.Text != "" && fun.DateValidation(TxtDateofIssueInvoice.Text) && fun.EmailValidation(TxtByEmail.Text) && fun.EmailValidation(TxtCoEmail.Text) && TxtAdd.Text != "" && fun.NumberValidationQty(TxtAdd.Text) && TxtDeduct.Text != "" && fun.NumberValidationQty(TxtDeduct.Text))
			{
				foreach (GridViewRow row in GridView1.Rows)
				{
					if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("TxtReqQty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("TxtReqQty")).Text) && fun.NumberValidationQty(((TextBox)row.FindControl("TxtAmt")).Text) && ((TextBox)row.FindControl("TxtAmt")).Text != "")
					{
						double num4 = 0.0;
						double num5 = 0.0;
						double num6 = 0.0;
						Convert.ToInt32(((Label)row.FindControl("lblPOId")).Text);
						int num7 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblQty")).Text.ToString()).ToString("N3"));
						num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtReqQty")).Text.ToString()).ToString("N3"));
						string cmdText = fun.select("Sum(tblACC_ProformaInvoice_Details.ReqQty) as ReqQty", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "' And tblACC_ProformaInvoice_Details.ItemId='" + num7 + "'  Group By tblACC_ProformaInvoice_Details.ItemId");
						SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						double num8 = 0.0;
						if (dataSet.Tables[0].Rows.Count > 0)
						{
							num8 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
						}
						num4 = num5 - num8;
						if (num4 >= num6)
						{
							num *= num3;
							continue;
						}
						num3 = 0;
						num = 0;
					}
				}
				if (num > 0)
				{
					foreach (GridViewRow row2 in GridView1.Rows)
					{
						if (((CheckBox)row2.FindControl("ck")).Checked && ((TextBox)row2.FindControl("TxtReqQty")).Text != "")
						{
							double num9 = 0.0;
							double num10 = 0.0;
							double num11 = 0.0;
							double num12 = 0.0;
							int num13 = Convert.ToInt32(((Label)row2.FindControl("lblPOId")).Text);
							int num14 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
							num10 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblQty")).Text.ToString()).ToString("N3"));
							num12 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtReqQty")).Text.ToString()).ToString("N3"));
							string cmdText2 = fun.select("sum(AmtInPer) As Amt", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "' And tblACC_ProformaInvoice_Details.ItemId='" + num14 + "'  Group By tblACC_ProformaInvoice_Details.ItemId ");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
							{
								double num15 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Amt"].ToString()).ToString("N2"));
							}
							num11 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtAmt")).Text.ToString()).ToString("N2"));
							string cmdText3 = fun.select("Sum(tblACC_ProformaInvoice_Details.ReqQty) as ReqQty", "tblACC_ProformaInvoice_Master,tblACC_ProformaInvoice_Details", "tblACC_ProformaInvoice_Details.MId=tblACC_ProformaInvoice_Master.Id  And  tblACC_ProformaInvoice_Master.CompId='" + CompId + "' And tblACC_ProformaInvoice_Details.ItemId='" + num14 + "'  Group By tblACC_ProformaInvoice_Details.ItemId");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter3.Fill(dataSet3);
							double num16 = 0.0;
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								num16 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
							}
							num9 = num10 - num16;
							if (num9 >= num12)
							{
								if (num2 > 0)
								{
									string cmdText4 = fun.insert("tblACC_ProformaInvoice_Master", "SysDate,SysTime,CompId,FinYearId, SessionId, InvoiceNo,PONo,WONo,InvoiceMode,DateOfIssueInvoice ,CustomerCode,Buyer_name,  Buyer_add,Buyer_country,Buyer_state, Buyer_city,Buyer_cotper,Buyer_ph,Buyer_email,Buyer_ecc,Buyer_tin  ,Buyer_mob  ,Buyer_fax,Buyer_vat,Cong_name ,Cong_add,Cong_Country,Cong_state,Cong_city,Cong_cotper ,  Cong_ph  ,  Cong_email  ,  Cong_ecc  ,Cong_tin,Cong_mob,Cong_fax,Cong_vat,AddType,AddAmt,DeductionType,Deduction,POId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text + "','" + PN + "','" + WN + "','" + typ + "','" + fun.FromDate(TxtDateofIssueInvoice.Text) + "','" + CCode + "','" + TxtBYName.Text + "','" + TxtByAddress.Text + "','" + DrpByCountry.SelectedValue + "','" + DrpByState.SelectedValue + "','" + DrpByCity.SelectedValue + "','" + TxtByCName.Text + "','" + TxtByPhone.Text + "','" + TxtByEmail.Text + "','" + TxtByECCNo.Text + "','" + TxtByTINCSTNo.Text + "','" + TxtByMobile.Text + "','" + TxtByFaxNo.Text + "','" + TxtByTINVATNo.Text + "','" + TxtCName.Text + "','" + TxtCAddress.Text + "','" + DrpCoCountry.SelectedValue + "','" + DrpCoState.SelectedValue + "','" + DrpCoCity.SelectedValue + "','" + TxtCoPersonName.Text + "','" + TxtCoPhoneNo.Text + "','" + TxtCoEmail.Text + "','" + TxtECoCCNo.Text + "','" + TxtCoTinCSTNo.Text + "','" + TxtCoMobileNo.Text + "','" + TxtCoFaxNo.Text + "','" + TxtCoTinVatNo.Text + "','" + DrpAdd.SelectedValue + "','" + TxtAdd.Text + "','" + DrpDed.SelectedValue + "','" + TxtDeduct.Text + "','" + num13 + "'");
									SqlCommand sqlCommand = new SqlCommand(cmdText4, sqlConnection);
									sqlCommand.ExecuteNonQuery();
									string cmdText5 = fun.select("Id", "tblACC_ProformaInvoice_Master", " CompId='" + CompId + "' order by Id desc");
									SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
									SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
									DataSet dataSet4 = new DataSet();
									sqlDataAdapter4.Fill(dataSet4, "tblACC_ProformaInvoice_Master");
									text2 = dataSet4.Tables[0].Rows[0]["Id"].ToString();
								}
								double num17 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblRate")).Text.ToString()).ToString("N2"));
								string selectedValue = ((DropDownList)row2.FindControl("DrpUnitQty")).SelectedValue;
								string cmdText6 = fun.insert("tblACC_ProformaInvoice_Details", "InvoiceNo,MId,ItemId,Unit,Qty,ReqQty,AmtInPer,Rate", "'" + text + "','" + text2 + "','" + num14 + "','" + selectedValue + "','" + num10 + "','" + num12 + "','" + num11 + "','" + num17 + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText6, sqlConnection);
								sqlCommand2.ExecuteNonQuery();
								num2 = 0;
							}
						}
						else
						{
							string empty = string.Empty;
							empty = "Goods input data is invalid.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Input data is invalid.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			if (num2 == 0)
			{
				base.Response.Redirect("ProformaInvoice_New.aspx?ModId=11&SubModId=104");
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

	protected void Btngoods_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[3];
	}

	protected void BtnCNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void DrpByCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
		TabContainer1.ActiveTab = TabContainer1.Tabs[0];
	}

	protected void DrpByState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DrpByCity, DrpByState);
		TabContainer1.ActiveTab = TabContainer1.Tabs[0];
	}

	protected void DrpCoCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void DrpCoState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DrpCoCity, DrpCoState);
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void TxtInsurance_TextChanged(object sender, EventArgs e)
	{
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProformaInvoice_New.aspx?ModId=11&SubModId=104");
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProformaInvoice_New.aspx?ModId=11&SubModId=104");
	}

	protected void Button3_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProformaInvoice_New.aspx?ModId=11&SubModId=104");
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

	protected void Button5_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtBYName.Text);
			string cmdText = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtByAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpByCountry, DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpByCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpByCountry, DrpByState);
				fun.dropdownState(DrpByState, DrpByCity, DrpByCountry);
				fun.dropdownStatebyId(DrpByState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpByState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpByCity, DrpByState);
				fun.dropdownCitybyId(DrpByCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpByCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtByFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtByCName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtByPhone.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtByTINCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtByTINVATNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtByMobile.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtByEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtByECCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtBYName.Text = "";
				TxtByAddress.Text = "";
				TxtByFaxNo.Text = "";
				TxtByCName.Text = "";
				TxtByPhone.Text = "";
				TxtByTINCSTNo.Text = "";
				TxtByTINVATNo.Text = "";
				TxtByMobile.Text = "";
				TxtByEmail.Text = "";
				TxtByECCNo.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button4_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtCName.Text);
			string cmdText = fun.select("MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtCAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpCoCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
				fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpCoCity, DrpCoState);
				fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtCoFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtCoPersonName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtCoPhoneNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtCoTinCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtCoTinVatNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtCoMobileNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtCoEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtECoCCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtCName.Text = "";
				TxtCAddress.Text = "";
				TxtCoFaxNo.Text = "";
				TxtCoPersonName.Text = "";
				TxtCoPhoneNo.Text = "";
				TxtCoTinCSTNo.Text = "";
				TxtCoTinVatNo.Text = "";
				TxtCoMobileNo.Text = "";
				TxtCoEmail.Text = "";
				TxtECoCCNo.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button6_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(TxtBYName.Text);
			string cmdText = fun.select("CustomerName+' ['+CustomerId+']' As Customer,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,Email,TinVatNo,EccNo,ContactNo,TinCstNo", "SD_Cust_master", "CustomerId='" + code + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				TxtCName.Text = dataSet.Tables[0].Rows[0]["Customer"].ToString();
				TxtCAddress.Text = dataSet.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
				fun.dropdownCountrybyId(DrpCoCountry, DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
				DrpCoCountry.SelectedIndex = 0;
				fun.dropdownCountry(DrpCoCountry, DrpCoState);
				fun.dropdownState(DrpCoState, DrpCoCity, DrpCoCountry);
				fun.dropdownStatebyId(DrpCoState, "CId='" + dataSet.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
				DrpCoState.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString();
				fun.dropdownCity(DrpCoCity, DrpCoState);
				fun.dropdownCitybyId(DrpCoCity, "SId='" + dataSet.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
				DrpCoCity.SelectedValue = dataSet.Tables[0].Rows[0]["MaterialDelCity"].ToString();
				TxtCoFaxNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();
				TxtCoPersonName.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				TxtCoPhoneNo.Text = dataSet.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
				TxtCoTinCSTNo.Text = dataSet.Tables[0].Rows[0]["TinCstNo"].ToString();
				TxtCoTinVatNo.Text = dataSet.Tables[0].Rows[0]["TinVatNo"].ToString();
				TxtCoMobileNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				TxtCoEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				TxtECoCCNo.Text = dataSet.Tables[0].Rows[0]["EccNo"].ToString();
			}
			else
			{
				TxtCName.Text = "";
				string empty = string.Empty;
				empty = "Invalid selection of Customer data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}

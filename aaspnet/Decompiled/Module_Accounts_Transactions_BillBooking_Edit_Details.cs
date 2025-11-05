using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_BillBooking_Edit_Details : Page, IRequiresSessionState
{
	protected Label lblPVEVNo;

	protected Label lblPoNo;

	protected TextBox textBillno;

	protected RequiredFieldValidator ReqBillno;

	protected Label lblSupplierName;

	protected TextBox textBillDate;

	protected CalendarExtender textBillDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegEditBillDate;

	protected TextBox textCVEntryNo;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected Label lblSupplierAdd;

	protected TextBox textCVEntryDate;

	protected CalendarExtender textCVEntryDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected RegularExpressionValidator RegEntryDtEd;

	protected Label lblWoDeptNo;

	protected Label lblECCno;

	protected Label lblRange;

	protected Label lblServiceTax;

	protected Label lblDivision;

	protected Label lblComm;

	protected Label lblTDS;

	protected Label lblVatNo;

	protected Label lblCSTNo;

	protected Label lblPanNo;

	protected FileUpload FileUpload1;

	protected RequiredFieldValidator ReqFileUpload;

	protected Button Button1;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView2;

	protected Panel Panel1;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected TabPanel TabPanel2;

	protected TextBox txtOtherCharges;

	protected RequiredFieldValidator ReqOtherCharges;

	protected RegularExpressionValidator RegOtherCharges;

	protected TextBox txtOtherChaDesc;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtDebitAmt;

	protected RequiredFieldValidator ReqDebitAmt;

	protected RegularExpressionValidator RegDebitAmt;

	protected TextBox txtDiscount;

	protected RequiredFieldValidator ReqDiscount;

	protected RegularExpressionValidator RegDiscount;

	protected DropDownList DrpAdd;

	protected TextBox txtNarration;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected Button btnProceed;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string SId = "";

	private int CompId;

	private string PId = "";

	private string SupplierNo = "";

	private int FyId;

	private int PVEVId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			PVEVId = Convert.ToInt32(base.Request.QueryString["Id"].ToString());
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("SysDate, SysTime, SessionId, CompId, FinYearId , PVEVNo, SupplierId , BillNo, BillDate , CENVATEntryNo, CENVATEntryDate , OtherCharges , OtherChaDesc , Narration , DebitAmt, DiscountType, Discount", "tblACC_BillBooking_Master", "Id='" + PVEVId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				SupplierNo = dataSet.Tables[0].Rows[0]["SupplierId"].ToString();
				FyId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"].ToString());
				if (!base.IsPostBack)
				{
					lblPVEVNo.Text = dataSet.Tables[0].Rows[0]["PVEVNo"].ToString();
					textBillno.Text = dataSet.Tables[0].Rows[0]["BillNo"].ToString();
					textBillDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["BillDate"].ToString());
					textCVEntryNo.Text = dataSet.Tables[0].Rows[0]["CENVATEntryNo"].ToString();
					textCVEntryDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["CENVATEntryDate"].ToString());
					txtOtherCharges.Text = dataSet.Tables[0].Rows[0]["OtherCharges"].ToString();
					txtOtherChaDesc.Text = dataSet.Tables[0].Rows[0]["OtherChaDesc"].ToString();
					txtNarration.Text = dataSet.Tables[0].Rows[0]["Narration"].ToString();
					txtDebitAmt.Text = dataSet.Tables[0].Rows[0]["DebitAmt"].ToString();
					txtDiscount.Text = dataSet.Tables[0].Rows[0]["Discount"].ToString();
					DrpAdd.SelectedValue = dataSet.Tables[0].Rows[0]["DiscountType"].ToString();
					loadData();
				}
			}
			DataSet dataSet2 = new DataSet();
			string cmdText2 = "Select * from tblMM_Supplier_master where SupplierId='" + SupplierNo + "'And CompId='" + CompId + "'";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2, "tblMM_Supplier_master");
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblSupplierName.Text = dataSet2.Tables[0].Rows[0]["SupplierName"].ToString();
				string cmdText3 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet2.Tables[0].Rows[0]["RegdCountry"], "'"));
				string cmdText4 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet2.Tables[0].Rows[0]["RegdState"], "'"));
				string cmdText5 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet2.Tables[0].Rows[0]["RegdCity"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet3 = new DataSet();
				DataSet dataSet4 = new DataSet();
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblCountry");
				sqlDataAdapter4.Fill(dataSet4, "tblState");
				sqlDataAdapter5.Fill(dataSet5, "tblcity");
				lblSupplierAdd.Text = dataSet2.Tables[0].Rows[0]["RegdAddress"].ToString() + ",<br>" + dataSet5.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet4.Tables[0].Rows[0]["StateName"].ToString() + ",<br>" + dataSet3.Tables[0].Rows[0]["CountryName"].ToString() + ".<br>" + dataSet2.Tables[0].Rows[0]["RegdPinNo"].ToString() + ".<br>";
				lblECCno.Text = dataSet2.Tables[0].Rows[0]["EccNo"].ToString();
				lblDivision.Text = dataSet2.Tables[0].Rows[0]["Divn"].ToString();
				lblVatNo.Text = dataSet2.Tables[0].Rows[0]["TinVatNo"].ToString();
				lblRange.Text = dataSet2.Tables[0].Rows[0]["Range"].ToString();
				lblComm.Text = dataSet2.Tables[0].Rows[0]["Commissionurate"].ToString();
				lblCSTNo.Text = dataSet2.Tables[0].Rows[0]["TinCstNo"].ToString();
				lblServiceTax.Text = "-";
				lblTDS.Text = dataSet2.Tables[0].Rows[0]["TDSCode"].ToString();
				lblPanNo.Text = dataSet2.Tables[0].Rows[0]["PanNo"].ToString();
			}
			string cmdText6 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.PaymentTerms,tblMM_PO_Master.PONo", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.Id='" + PId + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
			SqlCommand selectCommand6 = new SqlCommand(cmdText6, connection);
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
			DataSet dataSet6 = new DataSet();
			sqlDataAdapter6.Fill(dataSet6);
			if (dataSet6.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			if (dataSet6.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
			{
				string cmdText7 = fun.select("tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet6.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet6.Tables[0].Rows[0]["PRId"].ToString() + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, connection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				lblPoNo.Text = dataSet6.Tables[0].Rows[0]["PONo"].ToString();
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					lblWoDeptNo.Text = dataSet7.Tables[0].Rows[0]["WONo"].ToString();
				}
			}
			else
			{
				if (!(dataSet6.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1"))
				{
					return;
				}
				string cmdText8 = fun.select("tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet6.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet6.Tables[0].Rows[0]["SPRId"].ToString() + "'");
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, connection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				string text = "";
				if (dataSet8.Tables[0].Rows.Count <= 0)
				{
					return;
				}
				if (dataSet8.Tables[0].Rows[0]["DeptId"].ToString() == "0")
				{
					text = dataSet8.Tables[0].Rows[0]["WONo"].ToString();
				}
				else
				{
					string cmdText9 = fun.select("Symbol AS Dept", "tblHR_Departments", "Id ='" + Convert.ToInt32(dataSet8.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, connection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter9.Fill(dataSet9);
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						text = dataSet9.Tables[0].Rows[0]["Dept"].ToString();
					}
				}
				lblWoDeptNo.Text = text;
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
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = fun.FromDate(textBillDate.Text);
			string text2 = fun.FromDate(textCVEntryDate.Text);
			if (textBillno.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) && fun.DateValidation(textCVEntryDate.Text) && textCVEntryNo.Text != "" && textCVEntryDate.Text != "" && txtOtherCharges.Text != "" && txtOtherChaDesc.Text != "" && txtDebitAmt.Text != "" && txtDiscount.Text != "" && fun.NumberValidationQty(txtDebitAmt.Text) && fun.NumberValidationQty(txtOtherCharges.Text) && fun.NumberValidationQty(txtDiscount.Text))
			{
				string cmdText = fun.update("tblACC_BillBooking_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + SId + "',BillNo='" + textBillno.Text + "',BillDate='" + text + "', CENVATEntryNo='" + textCVEntryNo.Text + "',CENVATEntryDate='" + text2 + "',OtherCharges='" + txtOtherCharges.Text + "',OtherChaDesc='" + txtOtherChaDesc.Text + "',Narration='" + txtNarration.Text + "',DebitAmt='" + Convert.ToDouble(txtDebitAmt.Text) + "',DiscountType='" + DrpAdd.SelectedValue + "',Discount='" + Convert.ToDouble(decimal.Parse(txtDiscount.Text.ToString()).ToString("N2")) + "'", "Id='" + PVEVId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
			}
			string cmdText2 = fun.select("*", "tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND FinYearId ='" + FyId + "' AND SessionId = '" + SId + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_BillBooking_Attach_Temp");
			sqlCommand2.ExecuteNonQuery();
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText3 = fun.insert("tblACC_BillBooking_Attach_Master", "MId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", string.Concat(PVEVId, ",'", Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]), "','", dataSet.Tables[0].Rows[i]["SessionId"].ToString(), "','", Convert.ToInt32(dataSet.Tables[0].Rows[i]["FinYearId"]), "','", dataSet.Tables[0].Rows[i]["FileName"], "','", dataSet.Tables[0].Rows[i]["FileSize"], "','", dataSet.Tables[0].Rows[i]["ContentType"], "',@TransStr"));
					using SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand3.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = dataSet.Tables[0].Rows[i]["FileData"];
					sqlCommand3.ExecuteNonQuery();
				}
				string cmdText4 = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND FinYearId ='" + FyId + "' AND SessionId = '" + SId + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection.Close();
			base.Response.Redirect("BillBooking_Edit.aspx?ModId=11&SubModId=62");
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BillBooking_Edit.aspx?ModId=11&SubModId=62");
	}

	public void loadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			string cmdText = fun.select("* ", "tblACC_BillBooking_Details", "MId='" + PVEVId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Descr", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PFAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStBasic", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStEducess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStShecess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CustomDuty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TarrifNo", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStBasicInPer", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStEducessInPer", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStShecessInPer", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					string cmdText2 = fun.select("tblMM_PO_Details.Rate,tblMM_PO_Details.Discount", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["PODId"].ToString() + "'  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id =tblMM_PO_Details.Mid ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2"));
						num2 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					}
					if (dataSet.Tables[0].Rows[i]["GQNId"].ToString() != "0")
					{
						string cmdText3 = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + dataSet.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[1] = dataSet3.Tables[0].Rows[0]["GQNNo"].ToString();
							double num4 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["AcceptedQty"].ToString()).ToString("N3"));
							num3 = (num - num * num2 / 100.0) * num4;
						}
						else
						{
							dataRow[1] = "NA";
						}
					}
					else
					{
						string cmdText4 = fun.select("tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + dataSet.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet4.Tables[0].Rows[0]["GSNNo"].ToString();
							double num5 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["ReceivedQty"].ToString()).ToString("N3"));
							num3 = Convert.ToDouble(decimal.Parse(((num - num * num2 / 100.0) * num5).ToString()).ToString("N2"));
						}
						else
						{
							dataRow[2] = "NA";
						}
					}
					string cmdText5 = fun.select("ItemCode,ManfDesc As Descr,UOMBasic ", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet5.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[4] = dataSet5.Tables[0].Rows[0]["Descr"].ToString();
						string cmdText6 = fun.select("Symbol As UOM ", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet6.Tables[0].Rows[0][0].ToString();
						}
						dataRow[6] = num3;
						dataRow[7] = dataSet.Tables[0].Rows[i]["PFAmt"].ToString();
						dataRow[8] = dataSet.Tables[0].Rows[i]["ExStBasic"].ToString();
						dataRow[9] = dataSet.Tables[0].Rows[i]["ExStEducess"].ToString();
						dataRow[10] = dataSet.Tables[0].Rows[i]["ExStShecess"].ToString();
						dataRow[11] = dataSet.Tables[0].Rows[i]["CustomDuty"].ToString();
						dataRow[12] = dataSet.Tables[0].Rows[i]["VAT"].ToString();
						dataRow[13] = dataSet.Tables[0].Rows[i]["CST"].ToString();
						dataRow[14] = dataSet.Tables[0].Rows[i]["Freight"].ToString();
						dataRow[15] = dataSet.Tables[0].Rows[i]["TarrifNo"].ToString();
						dataRow[16] = dataSet.Tables[0].Rows[i]["ExStBasicInPer"].ToString();
						dataRow[17] = dataSet.Tables[0].Rows[i]["ExStEducessInPer"].ToString();
						dataRow[18] = dataSet.Tables[0].Rows[i]["ExStShecessInPer"].ToString();
					}
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData();
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
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text2 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxpf")).Text.ToString()).ToString("N2");
			string text3 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStBasicInPer")).Text.ToString()).ToString("N2");
			string text4 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStEducessInPer")).Text.ToString()).ToString("N2");
			string text5 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStShecessInPer")).Text.ToString()).ToString("N2");
			string text6 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStBasic")).Text.ToString()).ToString("N2");
			string text7 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStEducess")).Text.ToString()).ToString("N2");
			string text8 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxExStShecess")).Text.ToString()).ToString("N2");
			string text9 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxCustomDuty")).Text.ToString()).ToString("N2");
			string text10 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxVAT")).Text.ToString()).ToString("N2");
			string text11 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxCST")).Text.ToString()).ToString("N2");
			string text12 = decimal.Parse(((TextBox)gridViewRow.FindControl("TextBoxFreight")).Text.ToString()).ToString("N2");
			string text13 = ((TextBox)gridViewRow.FindControl("TextBoxTarrifNo")).Text;
			if (text2 != "" && text3 != "" && text4 != "" && text5 != "" && text6 != "" && text7 != "" && text8 != "" && text9 != "" && text10 != "" && text11 != "" && text12 != "" && text13 != "" && fun.NumberValidationQty(text2) && fun.NumberValidationQty(text3) && fun.NumberValidationQty(text4) && fun.NumberValidationQty(text5) && fun.NumberValidationQty(text6) && fun.NumberValidationQty(text7) && fun.NumberValidationQty(text8) && fun.NumberValidationQty(text9) && fun.NumberValidationQty(text10) && fun.NumberValidationQty(text11) && fun.NumberValidationQty(text12))
			{
				string cmdText = fun.select("MId", "tblACC_BillBooking_Details", "Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.update("tblACC_BillBooking_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text + "'", "Id='" + dataSet.Tables[0].Rows[0]["MId"].ToString() + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
				string cmdText3 = fun.update("tblACC_BillBooking_Details", "PFAmt='" + Convert.ToDouble(text2) + "', ExStBasicInPer='" + Convert.ToDouble(text3) + "', ExStEducessInPer='" + Convert.ToDouble(text4) + "', ExStShecessInPer='" + Convert.ToDouble(text5) + "', ExStBasic='" + Convert.ToDouble(text6) + "', ExStEducess='" + Convert.ToDouble(text7) + "' , ExStShecess='" + Convert.ToDouble(text8) + "', CustomDuty='" + Convert.ToDouble(text9) + "', VAT='" + Convert.ToDouble(text10) + "', CST='" + text11 + "', Freight='" + Convert.ToDouble(text12) + "' , TarrifNo='" + text13 + "'", "Id='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
				base.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile != null)
			{
				Stream inputStream = FileUpload1.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text = Path.GetFileName(postedFile.FileName);
			}
			if (text != "")
			{
				string cmdText = fun.insert("tblACC_BillBooking_Attach_Master", "MId,SessionId,CompId,FinYearId,FileName,FileSize,ContentType,FileData", "'" + PVEVId + "','" + SId + "','" + CompId + "','" + FyId + "','" + text + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
				SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
				sqlCommand.Parameters.AddWithValue("@Data", array);
				fun.InsertUpdateData(sqlCommand);
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink hyperLink = (HyperLink)e.Row.Cells[4].Controls[0];
				hyperLink.Attributes.Add("onclick", "return confirmation();");
			}
		}
		catch (Exception)
		{
		}
	}
}

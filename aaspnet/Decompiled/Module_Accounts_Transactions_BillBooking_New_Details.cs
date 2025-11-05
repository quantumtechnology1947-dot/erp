using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_BillBooking_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SId = string.Empty;

	private string PId = string.Empty;

	private string SupplierNo = string.Empty;

	private string PVEVNo1 = string.Empty;

	private double FGT;

	private int FyId;

	private int CompId;

	private int ST;

	protected Label lblSupplierName;

	protected Label lblSupplierAdd;

	protected TextBox textBillno;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox textBillDate;

	protected CalendarExtender textBillDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegBillDate;

	protected TextBox textCVEntryNo;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox textCVEntryDate;

	protected CalendarExtender textCVEntryDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected RegularExpressionValidator RegCenVatEntryDt;

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

	protected Button BtnNext1;

	protected Button btnCancel1;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView1;

	protected Panel Panel3;

	protected TabPanel TabPanel1;

	protected HtmlGenericControl Iframe1;

	protected Button BtnNext2;

	protected Button btnCancel0;

	protected TabPanel TabPanel2;

	protected GridView GridView3;

	protected Button BtnNext3;

	protected Button btnCancel2;

	protected TabPanel TabPanel3;

	protected GridView GridView4;

	protected Panel Panel4;

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

	protected Button btnProceed;

	protected Button btnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			SupplierNo = base.Request.QueryString["SUPId"].ToString();
			FGT = Convert.ToDouble(base.Request.QueryString["FGT"]);
			SId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			ST = Convert.ToInt32(base.Request.QueryString["ST"]);
			Iframe1.Attributes.Add("src", "BillBooking_ItemGrid.aspx?SUPId=" + SupplierNo + "&FGT=" + FGT + "&FyId=" + FyId + "&ST=" + ST);
			LoadDataSelectedItems();
			string cmdText = fun.select("*", "tblMM_Supplier_master", "SupplierId='" + SupplierNo + "'And CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				lblSupplierName.Text = sqlDataReader["SupplierName"].ToString() + " [" + sqlDataReader["SupplierId"].ToString() + "]";
				string cmdText2 = fun.select("CountryName", "tblcountry", string.Concat("CId='", sqlDataReader["RegdCountry"], "'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				string cmdText3 = fun.select("StateName", "tblState", string.Concat("SId='", sqlDataReader["RegdState"], "'"));
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				string cmdText4 = fun.select("CityName", "tblCity", string.Concat("CityId='", sqlDataReader["RegdCity"], "'"));
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				lblSupplierAdd.Text = sqlDataReader["RegdAddress"].ToString() + ",<br>" + sqlDataReader4["CityName"].ToString() + "," + sqlDataReader3["StateName"].ToString() + ",<br>" + sqlDataReader2["CountryName"].ToString() + ".<br>" + sqlDataReader["RegdPinNo"].ToString() + ".<br>";
				lblECCno.Text = sqlDataReader["EccNo"].ToString();
				lblDivision.Text = sqlDataReader["Divn"].ToString();
				lblVatNo.Text = sqlDataReader["TinVatNo"].ToString();
				lblRange.Text = sqlDataReader["Range"].ToString();
				lblComm.Text = sqlDataReader["Commissionurate"].ToString();
				lblCSTNo.Text = sqlDataReader["TinCstNo"].ToString();
				lblServiceTax.Text = "-";
				lblTDS.Text = sqlDataReader["TDSCode"].ToString();
				lblPanNo.Text = sqlDataReader["PanNo"].ToString();
			}
			if (!base.IsPostBack)
			{
				TDSGrid();
			}
			sqlConnection.Close();
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
				string cmdText = fun.insert("tblACC_BillBooking_Attach_Temp", "SessionId,CompId,FinYearId,FileName,FileSize,ContentType,FileData", "'" + SId + "','" + CompId + "','" + FyId + "','" + text + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
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

	protected void BtnNext1_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void BtnNext2_Click1(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void BtnNext3_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 3;
		TDSGrid();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BillBooking_New.aspx?ModId=11&SubModId=62");
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
			string cmdText = fun.select("PVEVNo", "tblACC_BillBooking_Master", "CompId='" + CompId + "' AND FinYearId='" + FyId + "' order by PVEVNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_BillBooking_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				PVEVNo1 = (Convert.ToInt32(dataSet.Tables[0].Rows[0]["PVEVNo"]) + 1).ToString("D4");
			}
			else
			{
				PVEVNo1 = "0001";
			}
			if (textBillno.Text != "" && textBillDate.Text != "" && fun.DateValidation(textBillDate.Text) && textCVEntryNo.Text != "" && textCVEntryDate.Text != "" && fun.DateValidation(textCVEntryDate.Text) && txtOtherCharges.Text != "" && txtOtherChaDesc.Text != "" && txtDebitAmt.Text != "" && txtDiscount.Text != "" && fun.NumberValidationQty(txtOtherCharges.Text) && fun.NumberValidationQty(txtDebitAmt.Text) && fun.NumberValidationQty(txtDiscount.Text))
			{
				string cmdText2 = "SELECT tblACC_BillBooking_Details_Temp.Id,tblACC_BillBooking_Details_Temp.ACHead FROM tblACC_BillBooking_Details_Temp INNER JOIN AccHead ON tblACC_BillBooking_Details_Temp.ACHead = AccHead.Id AND tblACC_BillBooking_Details_Temp.SessionId='" + SId + "' AND tblACC_BillBooking_Details_Temp.CompId='" + CompId + "' AND AccHead.Symbol like 'E%'";
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				int num = 0;
				if (sqlDataReader.HasRows && !((RadioButton)GridView4.Controls[0].Controls[0].FindControl("RadioButton2")).Checked)
				{
					foreach (GridViewRow row in GridView4.Rows)
					{
						if (((RadioButton)row.FindControl("RadioButton1")).Checked)
						{
							num = Convert.ToInt32(((Label)row.FindControl("Id")).Text);
						}
					}
				}
				string cmdText3 = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string text3 = fun.insert("tblACC_BillBooking_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PVEVNo,SupplierId,BillNo,BillDate, CENVATEntryNo,CENVATEntryDate,OtherCharges,OtherChaDesc,Narration,DebitAmt,DiscountType,Discount,InvoiceType,AHId,TDSCode", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + FyId + "','" + PVEVNo1 + "','" + SupplierNo + "','" + textBillno.Text + "','" + text + "','" + textCVEntryNo.Text + "','" + text2 + "','" + txtOtherCharges.Text + "','" + txtOtherChaDesc.Text + "','" + txtNarration.Text + "','" + txtDebitAmt.Text + "','" + DrpAdd.SelectedValue + "','" + decimal.Parse(txtDiscount.Text.ToString()).ToString("N2") + "','" + ST + "','" + dataSet2.Tables[0].Rows[0]["ACHead"].ToString() + "','" + num + "'");
					base.Response.Write(text3);
					SqlCommand sqlCommand2 = new SqlCommand(text3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					string cmdText4 = fun.select1("Id", "tblACC_BillBooking_Master Order by Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText5 = fun.select("*", "tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand3);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblACC_BillBooking_Attach_Temp");
					sqlCommand3.ExecuteNonQuery();
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						for (int i = 0; i < dataSet4.Tables[0].Rows.Count; i++)
						{
							string cmdText6 = fun.insert("tblACC_BillBooking_Attach_Master", "MId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", string.Concat(dataSet3.Tables[0].Rows[0][0].ToString(), ",'", Convert.ToInt32(dataSet4.Tables[0].Rows[i]["CompId"]), "','", dataSet4.Tables[0].Rows[i]["SessionId"].ToString(), "','", Convert.ToInt32(dataSet4.Tables[0].Rows[i]["FinYearId"]), "','", dataSet4.Tables[0].Rows[i]["FileName"], "','", dataSet4.Tables[0].Rows[i]["FileSize"], "','", dataSet4.Tables[0].Rows[i]["ContentType"], "',@TransStr"));
							using SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
							sqlCommand4.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = dataSet4.Tables[0].Rows[i]["FileData"];
							sqlCommand4.ExecuteNonQuery();
						}
						string cmdText7 = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText7, sqlConnection);
						sqlCommand5.ExecuteNonQuery();
					}
					if (dataSet3.Tables[0].Rows.Count <= 0)
					{
						return;
					}
					int num2 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"].ToString());
					new List<int>();
					for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
					{
						string cmdText8 = fun.insert("tblACC_BillBooking_Details", "MId,PODId,GQNId , GSNId, ItemId,DebitType,DebitValue,PFAmt,ExStBasicInPer,ExStEducessInPer,ExStShecessInPer, ExStBasic, ExStEducess, ExStShecess, CustomDuty, VAT, CST, Freight, TarrifNo,BCDOpt,BCD,BCDValue,ValueForCVD,ValueForEdCessCD,EdCessOnCDOpt,EdCessOnCD,EdCessOnCDValue,SHEDCessOpt,SHEDCess,SHEDCessValue,TotDuty,TotDutyEDSHED,Insurance,ValueWithDuty", "'" + num2 + "','" + dataSet2.Tables[0].Rows[j]["PODId"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["GQNId"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["GSNId"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ItemId"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["DebitType"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["DebitValue"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["PFAmt"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStBasicInPer"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStEducessInPer"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStShecessInPer"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStBasic"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStEducess"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExStShecess"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["CustomDuty"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["VAT"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["CST"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["Freight"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["TarrifNo"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["BCDOpt"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["BCD"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["BCDValue"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ValueForCVD"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ValueForEdCessCD"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["EdCessOnCDOpt"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["EdCessOnCD"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["EdCessOnCDValue"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["SHEDCessOpt"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["SHEDCess"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["SHEDCessValue"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["TotDuty"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["TotDutyEDSHED"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["Insurance"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ValueWithDuty"].ToString() + "'");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText8, sqlConnection);
						sqlCommand6.ExecuteNonQuery();
					}
					string cmdText9 = fun.select("Distinct(POId) as POId", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' AND CKPF>0 OR CKEX>0 OR CKVATCST>0 OR RateOpt>0 OR DiscOpt>0");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand7.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						string cmdText10 = fun.select("*", "tblMM_PO_Master", string.Concat("CompId='", CompId, "' AND Id='", sqlDataReader2["POId"], "'"));
						SqlCommand selectCommand4 = new SqlCommand(cmdText10, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						string cmdText11 = fun.insert("tblMM_PO_Amd_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,POId,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Freight,Octroi,ModeOfDispatch,Inspection,Remarks,Checked,CheckedBy,CheckedDate,CheckedTime,Approve,ApprovedBy,ApproveDate,ApproveTime,Authorize,AuthorizedBy,AuthorizeDate,AuthorizeTime,ShipTo,AmendmentNo,Warrenty,Insurance", "'" + dataSet5.Tables[0].Rows[0]["SysDate"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["SysTime"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["CompId"]) + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["FinYearId"]) + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["PRSPRFlag"]) + "','" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["PONo"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["SupplierId"].ToString() + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Reference"]) + "','" + dataSet5.Tables[0].Rows[0]["ReferenceDate"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["ReferenceDesc"].ToString() + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["PaymentTerms"]) + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Freight"]) + "','" + Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Octroi"]) + "','" + dataSet5.Tables[0].Rows[0]["ModeOfDispatch"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Inspection"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Remarks"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Checked"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["CheckedBy"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["CheckedDate"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["CheckedTime"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Approve"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["ApprovedBy"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["ApproveDate"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["ApproveTime"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Authorize"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["AuthorizeDate"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["AuthorizeTime"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["ShipTo"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Warrenty"].ToString() + "','" + dataSet5.Tables[0].Rows[0]["Insurance"].ToString() + "'");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText11, sqlConnection);
						sqlCommand8.ExecuteNonQuery();
						int num3 = 0;
						string cmdText12 = fun.select("AmendmentNo,Id", "tblMM_PO_Amd_Master", "CompId='" + CompId + "' order by Id desc");
						SqlCommand selectCommand5 = new SqlCommand(cmdText12, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							num3 = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["Id"]);
						}
						string empty = string.Empty;
						empty = ((dataSet5.Tables[0].Rows.Count <= 0) ? "0" : (Convert.ToInt32(dataSet5.Tables[0].Rows[0]["AmendmentNo"].ToString()) + 1).ToString());
						string cmdText13 = fun.update("tblMM_PO_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + SId + "',AmendmentNo='" + empty + "'", string.Concat("Id='", sqlDataReader2["POId"], "'"));
						SqlCommand sqlCommand9 = new SqlCommand(cmdText13, sqlConnection);
						sqlCommand9.ExecuteNonQuery();
						MailMessage mailMessage = new MailMessage();
						string cmdText14 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
						SqlCommand sqlCommand10 = new SqlCommand(cmdText14, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand10.ExecuteReader();
						while (sqlDataReader3.Read())
						{
							SmtpMail.SmtpServer = sqlDataReader3["MailServerIp"].ToString();
							mailMessage.From = sqlDataReader3["ErpSysmail"].ToString();
							mailMessage.To = "sdshinde@sapl.com;monali@sapl.com;";
							mailMessage.Subject = "Amendment in PO: " + dataSet5.Tables[0].Rows[0]["PONo"].ToString();
							mailMessage.Body = "<br>PO No." + dataSet5.Tables[0].Rows[0]["PONo"].ToString() + " is Amended at the time of bill booking process, <br><br>This is Auto generated mail from ERP system,please do not reply.<br><br> Thank you.<br>ERP System";
							mailMessage.BodyFormat = MailFormat.Html;
							SmtpMail.Send(mailMessage);
						}
						string cmdText15 = fun.select("*", "tblMM_PO_Details", string.Concat("MId='", sqlDataReader2["POId"], "'"));
						SqlCommand sqlCommand11 = new SqlCommand(cmdText15, sqlConnection);
						SqlDataReader sqlDataReader4 = sqlCommand11.ExecuteReader();
						while (sqlDataReader4.Read())
						{
							string cmdText16 = fun.insert("tblMM_PO_Amd_Details", "MId,PONo,PRNo,PRId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,AmendmentNo,BudgetCode,PODId", "'" + num3 + "','" + sqlDataReader4["PONo"].ToString() + "','" + sqlDataReader4["PRNo"].ToString() + "','" + sqlDataReader4["PRId"].ToString() + "','" + sqlDataReader4["SPRNo"].ToString() + "','" + sqlDataReader4["SPRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(sqlDataReader4["Qty"].ToString()).ToString("N3")) + "','" + sqlDataReader4["Rate"].ToString() + "','" + sqlDataReader4["Discount"].ToString() + "','" + sqlDataReader4["AddDesc"].ToString() + "','" + sqlDataReader4["PF"].ToString() + "','" + sqlDataReader4["ExST"].ToString() + "','" + sqlDataReader4["VAT"].ToString() + "','" + sqlDataReader4["DelDate"].ToString() + "','" + sqlDataReader4["AmendmentNo"].ToString() + "','" + sqlDataReader4["BudgetCode"].ToString() + "','" + sqlDataReader4["Id"].ToString() + "'");
							SqlCommand sqlCommand12 = new SqlCommand(cmdText16, sqlConnection);
							sqlCommand12.ExecuteNonQuery();
						}
						string cmdText17 = fun.select("*", "tblACC_BillBooking_Details_Temp", string.Concat("SessionId='", SId, "' and CompId='", CompId, "' AND POId='", sqlDataReader2["POId"], "' AND CKPF>0 OR CKEX>0 OR CKVATCST>0 OR RateOpt>0 OR DiscOpt>0"));
						SqlCommand sqlCommand13 = new SqlCommand(cmdText17, sqlConnection);
						SqlDataReader sqlDataReader5 = sqlCommand13.ExecuteReader();
						while (sqlDataReader5.Read())
						{
							string text4 = string.Empty;
							string text5 = string.Empty;
							string text6 = string.Empty;
							string text7 = string.Empty;
							string text8 = string.Empty;
							if (sqlDataReader5["RateOpt"].ToString() == "1")
							{
								text4 = ",Rate='" + sqlDataReader5["Rate"].ToString() + "'";
							}
							if (sqlDataReader5["DiscOpt"].ToString() == "1")
							{
								text5 = ",Discount='" + sqlDataReader5["Disc"].ToString() + "'";
							}
							if (sqlDataReader5["CKPF"].ToString() == "1")
							{
								text6 = ",PF='" + sqlDataReader5["PFOpt"].ToString() + "'";
							}
							if (sqlDataReader5["CKEX"].ToString() == "1")
							{
								text7 = ",ExST='" + sqlDataReader5["ExciseOpt"].ToString() + "'";
							}
							if (sqlDataReader5["CKVATCST"].ToString() == "1")
							{
								text8 = ",VAT='" + sqlDataReader5["VATCSTOpt"].ToString() + "'";
							}
							string empty2 = string.Empty;
							empty2 = fun.update("tblMM_PO_Details", "AmendmentNo='" + empty + "'" + text4 + text5 + text6 + text7 + text8, "Id='" + sqlDataReader5["PODId"].ToString() + "'");
							SqlCommand sqlCommand14 = new SqlCommand(empty2, sqlConnection);
							sqlCommand14.ExecuteNonQuery();
							if (sqlDataReader5["RateOpt"].ToString() == "1" || sqlDataReader5["DiscOpt"].ToString() == "1")
							{
								string cmdText18 = "SELECT tblMM_PO_Details.PRId, tblMM_PO_Details.SPRId FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId AND tblMM_PO_Details.Id = '" + sqlDataReader5["PODId"].ToString() + "'";
								SqlCommand sqlCommand15 = new SqlCommand(cmdText18, sqlConnection);
								SqlDataReader sqlDataReader6 = sqlCommand15.ExecuteReader();
								sqlDataReader6.Read();
								string cmdText19 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,PRId,SPRId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + dataSet5.Tables[0].Rows[0]["PONo"].ToString() + "','" + sqlDataReader5["ItemId"].ToString() + "','" + sqlDataReader5["Rate"].ToString() + "','" + sqlDataReader5["Disc"].ToString() + "','" + sqlDataReader5["PFOpt"].ToString() + "','" + sqlDataReader5["ExciseOpt"].ToString() + "','" + sqlDataReader5["VATCSTOpt"].ToString() + "','" + empty + "','" + sqlDataReader5["POId"].ToString() + "','" + sqlDataReader6["PRId"].ToString() + "','" + sqlDataReader6["SPRId"].ToString() + "'");
								SqlCommand sqlCommand16 = new SqlCommand(cmdText19, sqlConnection);
								sqlCommand16.ExecuteNonQuery();
							}
						}
					}
					string cmdText20 = fun.delete("tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
					SqlCommand sqlCommand17 = new SqlCommand(cmdText20, sqlConnection);
					sqlCommand17.ExecuteNonQuery();
					base.Response.Redirect("BillBooking_New.aspx?ModId=11&SubModId=62");
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Please fill the PO Term details.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Input data is invalid.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadDataSelectedItems()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			double num = 0.0;
			string cmdText = fun.select("GQNAmt+GSNAmt As Sum_GQNGSN_Amt,PFAmt,ExStBasic+ExStEducess+ExStShecess As Excise_Amt,DebitType,DebitValue,BCDValue,EdCessOnCDValue,SHEDCessValue", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				num2 = Convert.ToDouble(sqlDataReader["Sum_GQNGSN_Amt"].ToString());
				num3 = Convert.ToDouble(sqlDataReader["PFAmt"].ToString());
				num4 = Convert.ToDouble(sqlDataReader["Excise_Amt"].ToString());
				num5 = Convert.ToDouble(sqlDataReader["DebitValue"].ToString());
				num7 = Convert.ToDouble(sqlDataReader["BCDValue"].ToString());
				num8 = Convert.ToDouble(sqlDataReader["EdCessOnCDValue"].ToString());
				num9 = Convert.ToDouble(sqlDataReader["SHEDCessValue"].ToString());
				switch (Convert.ToInt32(sqlDataReader["DebitType"].ToString()))
				{
				case 1:
					num6 = num2 - num5;
					break;
				case 2:
					num6 = num2 - num2 * num5 / 100.0;
					break;
				case 0:
					num6 = num2;
					break;
				}
				num += num6 + num3 + num4 + num7 + num8 + num9;
			}
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GSNAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PfAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStBasic", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStEducess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStShecess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CustomDuty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TarrifNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotalAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DebitType", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DebitValue", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DebitAmt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DCNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string cmdText2 = fun.select("*", "tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' Order By Id Desc");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			double num10 = 0.0;
			while (sqlDataReader2.Read())
			{
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = 0.0;
				DataRow dataRow = dataTable.NewRow();
				string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader2["ItemId"].ToString() + "' AND CompId='" + CompId + "' ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3.HasRows)
				{
					value = sqlDataReader3["ItemCode"].ToString();
					value2 = sqlDataReader3["ManfDesc"].ToString();
					string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader3["UOMBasic"].ToString() + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					if (sqlDataReader4.HasRows)
					{
						value3 = sqlDataReader4["Symbol"].ToString();
					}
				}
				string cmdText5 = fun.select("tblQc_MaterialQuality_Master.GQNNo", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Details.Id='" + sqlDataReader2["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				if (sqlDataReader5.HasRows)
				{
					dataRow[0] = sqlDataReader5["GQNNo"].ToString();
				}
				else
				{
					dataRow[0] = "NA";
				}
				dataRow[1] = Convert.ToDouble(decimal.Parse(sqlDataReader2["GQNAmt"].ToString()).ToString("N2"));
				string cmdText6 = fun.select("tblinv_MaterialServiceNote_Master.GSNNo", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + sqlDataReader2["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6.HasRows)
				{
					dataRow[2] = sqlDataReader6["GSNNo"].ToString();
				}
				else
				{
					dataRow[2] = "NA";
				}
				dataRow[3] = Convert.ToDouble(decimal.Parse(sqlDataReader2["GSNAmt"].ToString()).ToString("N2"));
				dataRow[4] = value;
				dataRow[5] = value2;
				dataRow[6] = value3;
				dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader2["PFAmt"].ToString()).ToString("N2"));
				dataRow[8] = sqlDataReader2["ExStBasic"].ToString();
				dataRow[9] = sqlDataReader2["ExStEducess"].ToString();
				dataRow[10] = sqlDataReader2["ExStShecess"].ToString();
				dataRow[11] = sqlDataReader2["CustomDuty"].ToString();
				dataRow[12] = sqlDataReader2["VAT"].ToString();
				dataRow[13] = sqlDataReader2["CST"].ToString();
				double num15 = 0.0;
				string cmdText7 = fun.select("Value,IsVAT,IsCST", "tblVAT_Master", "Id='" + sqlDataReader2["VATCSTOpt"].ToString() + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				num15 = Convert.ToDouble(sqlDataReader7[0]);
				int num16 = 0;
				int num17 = 0;
				num16 = Convert.ToInt32(sqlDataReader7["IsVAT"]);
				num17 = Convert.ToInt32(sqlDataReader7["IsCST"]);
				double num18 = 0.0;
				if (sqlDataReader2["GQNId"].ToString() != "0")
				{
					double num19 = 0.0;
					dataRow[22] = sqlDataReader2["GQNAmt"].ToString();
					num19 = Convert.ToDouble(sqlDataReader2["GQNAmt"].ToString());
					num18 = num19 + Convert.ToDouble(sqlDataReader2["PFAmt"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStBasic"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStEducess"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStShecess"].ToString()) + Convert.ToDouble(sqlDataReader2["BCDValue"]) + Convert.ToDouble(sqlDataReader2["EdCessOnCDValue"]) + Convert.ToDouble(sqlDataReader2["SHEDCessValue"]);
					num11 = ((!(num > 0.0)) ? FGT : Math.Round(FGT * num18 / num, 2));
					num12 = num18;
					if (num16 == 1)
					{
						double value4 = (num12 + num11) * num15 / 100.0;
						num13 = Math.Round(value4, 2);
					}
					else if (num17 == 1)
					{
						double value5 = num12 * num15 / 100.0;
						num14 = Math.Round(value5, 2);
					}
					dataRow[16] = num12 + num13 + num14;
					num10 += num12 + num13 + num14;
				}
				else if (sqlDataReader2["GSNId"].ToString() != "0")
				{
					double num20 = 0.0;
					dataRow[22] = sqlDataReader2["GSNAmt"].ToString();
					num20 = Convert.ToDouble(sqlDataReader2["GSNAmt"].ToString());
					num18 = num20 + Convert.ToDouble(sqlDataReader2["PFAmt"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStBasic"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStEducess"].ToString()) + Convert.ToDouble(sqlDataReader2["ExStShecess"].ToString()) + Convert.ToDouble(sqlDataReader2["BCDValue"]) + Convert.ToDouble(sqlDataReader2["EdCessOnCDValue"]) + Convert.ToDouble(sqlDataReader2["SHEDCessValue"]);
					num11 = ((!(num > 0.0)) ? FGT : Math.Round(FGT * num18 / num, 2));
					num12 = num18;
					if (num16 == 1)
					{
						double value6 = (num12 + num11) * num15 / 100.0;
						num13 = Math.Round(value6, 2);
					}
					else if (num17 == 1)
					{
						double value7 = num12 * num15 / 100.0;
						num14 = Math.Round(value7, 2);
					}
					dataRow[16] = num12 + num13 + num14;
					num10 += num12 + num13 + num14;
				}
				dataRow[14] = num11.ToString();
				dataRow[15] = sqlDataReader2["TarrifNo"].ToString();
				dataRow[17] = sqlDataReader2["Id"].ToString();
				string cmdText8 = fun.select("tblMM_PO_Master.PONo,tblMM_PO_Master.SysDate", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.Id='" + sqlDataReader2["PODId"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				if (sqlDataReader8.HasRows)
				{
					dataRow[18] = sqlDataReader8["PONo"].ToString();
					dataRow[19] = fun.FromDateDMY(sqlDataReader8["SysDate"].ToString());
				}
				if (sqlDataReader2["DebitType"].ToString() == "2")
				{
					dataRow[20] = "%";
				}
				dataRow[21] = sqlDataReader2["DebitValue"].ToString();
				if (Convert.ToInt32(sqlDataReader2["GQNId"].ToString()) != 0)
				{
					string cmdText9 = " SELECT tblInv_Inward_Master.ChallanNo, tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty FROM  tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId INNER JOIN   tblinv_MaterialReceived_Master INNER JOIN tblinv_MaterialReceived_Details ON tblinv_MaterialReceived_Master.Id = tblinv_MaterialReceived_Details.MId INNER JOIN tblInv_Inward_Master INNER JOIN  tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId ON tblinv_MaterialReceived_Master.GINNo = tblInv_Inward_Master.GINNo AND   tblinv_MaterialReceived_Master.GINId = tblInv_Inward_Master.Id AND tblinv_MaterialReceived_Details.POId = tblInv_Inward_Details.POId ON   tblQc_MaterialQuality_Master.GRRId = tblinv_MaterialReceived_Master.Id AND tblQc_MaterialQuality_Master.GRRNo = tblinv_MaterialReceived_Master.GRRNo AND tblQc_MaterialQuality_Details.GRRId = tblinv_MaterialReceived_Details.Id AND tblQc_MaterialQuality_Details.Id='" + sqlDataReader2["GQNId"].ToString() + "' ";
					SqlCommand sqlCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
					sqlDataReader9.Read();
					if (sqlDataReader9.HasRows)
					{
						dataRow[23] = sqlDataReader9["ChallanNo"].ToString();
						dataRow[24] = sqlDataReader9["AcceptedQty"].ToString();
					}
				}
				if (Convert.ToInt32(sqlDataReader2["GSNId"].ToString()) != 0)
				{
					string cmdText10 = "SELECT  tblInv_Inward_Master.ChallanNo, tblinv_MaterialServiceNote_Details.ReceivedQty, tblinv_MaterialServiceNote_Details.Id AS GSNId FROM tblinv_MaterialServiceNote_Details INNER JOIN  tblinv_MaterialServiceNote_Master ON tblinv_MaterialServiceNote_Details.MId = tblinv_MaterialServiceNote_Master.Id INNER JOIN  tblInv_Inward_Master INNER JOIN  tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId ON tblinv_MaterialServiceNote_Master.GINId = tblInv_Inward_Master.Id AND                     tblinv_MaterialServiceNote_Master.GINNo = tblInv_Inward_Master.GINNo AND tblinv_MaterialServiceNote_Details.POId = tblInv_Inward_Details.POId AND tblinv_MaterialServiceNote_Details.Id='" + sqlDataReader2["GSNId"].ToString() + "' ";
					SqlCommand sqlCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataReader sqlDataReader10 = sqlCommand10.ExecuteReader();
					sqlDataReader10.Read();
					if (sqlDataReader10.HasRows)
					{
						dataRow[23] = sqlDataReader10["ChallanNo"].ToString();
						dataRow[24] = sqlDataReader10["ReceivedQty"].ToString();
					}
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			if (GridView3.Rows.Count > 0)
			{
				((Label)GridView3.FooterRow.FindControl("lblrtotal")).Text = "Total:" + num10;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			LoadDataSelectedItems();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "del")
		{
			try
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				string cmdText = fun.delete("tblACC_BillBooking_Details_Temp", "Id='" + num + "' AND CompId='" + CompId + "' AND SessionId='" + SId + "'  ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			catch (Exception)
			{
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

	public void TDSGrid()
	{
		try
		{
			Panel4.Visible = true;
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			string cmdText = "SELECT tblACC_BillBooking_Details_Temp.Id,tblACC_BillBooking_Details_Temp.ACHead FROM tblACC_BillBooking_Details_Temp INNER JOIN AccHead ON tblACC_BillBooking_Details_Temp.ACHead = AccHead.Id AND tblACC_BillBooking_Details_Temp.SessionId='" + SId + "' AND tblACC_BillBooking_Details_Temp.CompId='" + CompId + "' AND AccHead.Symbol like 'E%'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				string cmdText2 = fun.select1("*", "tblACC_TDSCode_Master");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
				dataTable.Columns.Add(new DataColumn("SectionNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("NatureOfPayment", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PaymentRange", typeof(string)));
				dataTable.Columns.Add(new DataColumn("IndividualHUF", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Others", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TDSAmt", typeof(double)));
				dataTable.Columns.Add(new DataColumn("WithOutPAN", typeof(string)));
				while (sqlDataReader2.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = sqlDataReader2["Id"].ToString();
					dataRow[1] = sqlDataReader2["SectionNo"].ToString();
					dataRow[2] = sqlDataReader2["NatureOfPayment"].ToString();
					dataRow[3] = sqlDataReader2["PaymentRange"].ToString();
					dataRow[4] = sqlDataReader2["PayToIndividual"].ToString();
					dataRow[5] = sqlDataReader2["Others"].ToString();
					dataRow[6] = 0;
					dataRow[7] = sqlDataReader2["WithOutPAN"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
				GridView4.DataSource = dataTable;
				GridView4.DataBind();
				foreach (GridViewRow row in GridView4.Rows)
				{
					int num = 0;
					num = Convert.ToInt32(((Label)row.FindControl("Id")).Text);
					((Label)row.FindControl("TDSAmt")).Text = fun.Check_TDSAmt(CompId, FyId, SupplierNo, num).ToString();
				}
			}
			else
			{
				Panel4.Visible = false;
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		TDSGrid();
	}
}

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

public class Module_SalesDistribution_Transactions_CustPO_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet ds = new DataSet();

	private string CustCode = "";

	private int CId;

	private string SId = "";

	private int FYId;

	private int enqId;

	private string poid = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string podate = "";

	private string poRecdate = "";

	private string constr = "";

	private int QuotNo;

	protected Label LblName;

	protected Label Lblpoid;

	protected Label LblCustId;

	protected Label LblAddress;

	protected Label LblEnquiry;

	protected DropDownList drpQuotNO;

	protected TextBox TxtPORecDate;

	protected CalendarExtender TxtPORecDate_CalendarExtender;

	protected RequiredFieldValidator ReqPoRecDate;

	protected RegularExpressionValidator RegPORecDate;

	protected TextBox TxtPODate;

	protected CalendarExtender TxtPODate_CalendarExtender;

	protected RequiredFieldValidator ReqPODate;

	protected RegularExpressionValidator RegPODateVal;

	protected TextBox TxtPONo;

	protected RequiredFieldValidator ReqPONO;

	protected TextBox TxtVendorCode;

	protected RequiredFieldValidator ReqVendorCode;

	protected Button BtnCustomerNext;

	protected Button BtnCustomerCancel;

	protected TabPanel TabPanel2;

	protected TextBox TxtDesc;

	protected RequiredFieldValidator ReqDesc1;

	protected TextBox TxtQty;

	protected RequiredFieldValidator ReqTotQty;

	protected RegularExpressionValidator RegQty;

	protected TextBox TxtRate;

	protected RequiredFieldValidator ReqRate;

	protected RegularExpressionValidator RegRate;

	protected TextBox TxtDiscount;

	protected RequiredFieldValidator ReqDiscount;

	protected RegularExpressionValidator RegDisc;

	protected DropDownList DrpUnit;

	protected RequiredFieldValidator ReqDesc4;

	protected Button BtnSubmit;

	protected Button BtnGoodsNext;

	protected Button BtnGoodsCancel;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource12;

	protected Label lblMessage;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Label Label1;

	protected TabPanel TabPanel1;

	protected ListBox lstTitles;

	protected SqlDataSource SqlDataSource21;

	protected Panel Panel2;

	protected TextBox TxtPayments;

	protected DropDownExtender TxtPayments_DropDownExtender;

	protected RequiredFieldValidator ReqPayment;

	protected ListBox ListBox1;

	protected SqlDataSource SqlDataSource3;

	protected Panel Panel3;

	protected TextBox TxtPF;

	protected DropDownExtender TxtPF_DropDownExtender;

	protected RequiredFieldValidator ReqPf;

	protected ListBox ListBox3;

	protected SqlDataSource SqlDataSource5;

	protected Panel Panel5;

	protected TextBox TxtExcise;

	protected DropDownExtender TxtExcise_DropDownExtender;

	protected RequiredFieldValidator ReqExcise;

	protected ListBox ListBox2;

	protected SqlDataSource SqlDataSource4;

	protected Panel Panel4;

	protected TextBox TxtVAT;

	protected DropDownExtender txtVAT_DropDownExtender;

	protected RequiredFieldValidator ReqVat;

	protected ListBox ListBox4;

	protected SqlDataSource SqlDataSource6;

	protected Panel Panel6;

	protected TextBox TxtOctroi;

	protected DropDownExtender TxtOctroi_DropDownExtender;

	protected RequiredFieldValidator ReqOctri;

	protected ListBox ListBox5;

	protected SqlDataSource SqlDataSource7;

	protected Panel Panel7;

	protected TextBox TxtWarrenty;

	protected DropDownExtender TxtWarrenty_DropDownExtender;

	protected RequiredFieldValidator Reqwarranty;

	protected ListBox ListBox6;

	protected SqlDataSource SqlDataSource8;

	protected Panel Panel8;

	protected TextBox TxtInsurance;

	protected DropDownExtender TxtInsurance_DropDownExtender;

	protected RequiredFieldValidator ReqInsurance;

	protected ListBox ListBox7;

	protected SqlDataSource SqlDataSource9;

	protected Panel Panel9;

	protected TextBox TxtTransPort;

	protected DropDownExtender TxtTransPort_DropDownExtender;

	protected RequiredFieldValidator ReqTransport;

	protected TextBox TxtNoteNo;

	protected DropDownExtender TxtNoteNo_DropDownExtender;

	protected RequiredFieldValidator ReqGCNo;

	protected TextBox TxtRegdNo;

	protected RequiredFieldValidator ReqRegnNo;

	protected ListBox ListBox11;

	protected SqlDataSource SqlDataSource11;

	protected Panel Panel12;

	protected TextBox TxtFreight;

	protected DropDownExtender TxtFreight_DropDownExtender;

	protected RequiredFieldValidator Reqfrieght;

	protected TextBox Txtcst;

	protected RequiredFieldValidator ReqCST;

	protected TextBox Txtvalidity;

	protected RequiredFieldValidator ReqValidity;

	protected TextBox Txtocharges;

	protected RequiredFieldValidator ReqoCharges;

	protected HyperLink HyperLink1;

	protected ImageButton ImageCross;

	protected FileUpload FileUpload1;

	protected TextBox TxtRemarks;

	protected Button BtnUpdate;

	protected Button BtnTermsCancel;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			LblCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = LblCustId.Text;
			CId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			FYId = Convert.ToInt32(Session["finyear"]);
			LblEnquiry.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(LblEnquiry.Text);
			Lblpoid.Text = base.Request.QueryString["POId"].ToString();
			poid = Lblpoid.Text;
			constr = fun.Connection();
			con = new SqlConnection(constr);
			lblMessage.Text = "";
			TxtPORecDate.Attributes.Add("readonly", "readonly");
			TxtPODate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.dropdownUnit(DrpUnit);
				filldrpQuot();
				FillGrid2();
				FillGrid();
				DataSet dataSet = new DataSet();
				con.Open();
				string cmdText = fun.select("CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "SD_Cust_master", "CustomerId='" + CustCode + "'And CompId='" + CId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LblName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
					string cmdText2 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["RegdCountry"], "'"));
					string cmdText3 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["RegdState"], "'"));
					string cmdText4 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["RegdCity"], "'"));
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet2 = new DataSet();
					DataSet dataSet3 = new DataSet();
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblCountry");
					sqlDataAdapter3.Fill(dataSet3, "tblState");
					sqlDataAdapter4.Fill(dataSet4, "tblcity");
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows.Count > 0)
					{
						LblAddress.Text = dataSet.Tables[0].Rows[0]["RegdAddress"].ToString() + ",<br>&nbsp&nbsp" + dataSet4.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet3.Tables[0].Rows[0]["StateName"].ToString() + ",<br>&nbsp&nbsp" + dataSet2.Tables[0].Rows[0]["CountryName"].ToString() + ".<br>&nbsp&nbsp" + dataSet.Tables[0].Rows[0]["RegdPinNo"].ToString() + "<br>";
					}
				}
				string cmdText5 = fun.select("*", " SD_Cust_PO_Master", "CustomerId='" + CustCode + "'and POId='" + poid + "' and  CompId='" + CId + "'");
				string cmdText6 = fun.select("*", "SD_Cust_PO_Details", "POId='" + poid + "' and  CompId='" + CId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				sqlDataAdapter6.Fill(dataSet5, "SD_Cust_PO_Details");
				sqlDataAdapter5.Fill(DS, "SD_Cust_PO_Master");
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					string text = dataSet5.Tables[0].Rows[0]["Unit"].ToString();
					string cmdText7 = fun.select("Symbol", "Unit_Master", "Id='" + text + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
					DataSet dataSet6 = new DataSet();
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					sqlDataAdapter7.Fill(dataSet6, "unit");
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						DrpUnit.Items.Add(dataSet6.Tables[0].Rows[0]["Symbol"].ToString());
					}
				}
				if (DS.Tables[0].Rows.Count > 0)
				{
					string text2 = fun.FromDateDMY(DS.Tables[0].Rows[0]["PODate"].ToString());
					string text3 = fun.FromDateDMY(DS.Tables[0].Rows[0]["POReceivedDate"].ToString());
					TxtPONo.Text = DS.Tables[0].Rows[0]["PONo"].ToString();
					TxtPODate.Text = text2;
					TxtPORecDate.Text = text3;
					TxtVendorCode.Text = DS.Tables[0].Rows[0]["VendorCode"].ToString();
					TxtPayments.Text = DS.Tables[0].Rows[0]["PaymentTerms"].ToString();
					TxtPF.Text = DS.Tables[0].Rows[0]["PF"].ToString();
					TxtVAT.Text = DS.Tables[0].Rows[0]["VAT"].ToString();
					TxtTransPort.Text = DS.Tables[0].Rows[0]["TransPort"].ToString();
					TxtExcise.Text = DS.Tables[0].Rows[0]["Excise"].ToString();
					TxtWarrenty.Text = DS.Tables[0].Rows[0]["Warrenty"].ToString();
					TxtOctroi.Text = DS.Tables[0].Rows[0]["Octroi"].ToString();
					TxtInsurance.Text = DS.Tables[0].Rows[0]["Insurance"].ToString();
					TxtNoteNo.Text = DS.Tables[0].Rows[0]["NoteNo"].ToString();
					TxtRegdNo.Text = DS.Tables[0].Rows[0]["RegistrationNo"].ToString();
					TxtFreight.Text = DS.Tables[0].Rows[0]["Freight"].ToString();
					TxtRemarks.Text = DS.Tables[0].Rows[0]["Remarks"].ToString();
					drpQuotNO.SelectedValue = DS.Tables[0].Rows[0]["QuotationNo"].ToString();
					Txtcst.Text = DS.Tables[0].Rows[0]["CST"].ToString();
					Txtvalidity.Text = DS.Tables[0].Rows[0]["Validity"].ToString();
					Txtocharges.Text = DS.Tables[0].Rows[0]["OtherCharges"].ToString();
					if (DS.Tables[0].Rows[0]["FileName"].ToString() == "")
					{
						FileUpload1.Visible = true;
						ImageCross.Visible = false;
						HyperLink1.Visible = false;
					}
					else
					{
						FileUpload1.Visible = false;
						ImageCross.Visible = true;
						HyperLink1.Text = DS.Tables[0].Rows[0]["FileName"].ToString();
					}
				}
			}
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			if (TxtDesc.Text != "" && TxtQty.Text != "" && DrpUnit.SelectedValue != "Select" && TxtRate.Text != "" && fun.NumberValidationQty(TxtQty.Text) && fun.NumberValidationQty(TxtRate.Text) && fun.NumberValidationQty(TxtDiscount.Text))
			{
				con.Open();
				double num = 0.0;
				num = Convert.ToDouble(decimal.Parse(TxtDiscount.Text.ToString()).ToString("N3"));
				string cmdText = fun.insert("SD_Cust_PO_Details_Temp", "SessionId,CompId,FinYearId, ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId + "','" + CId + "' ,'" + FYId + "' ,'" + TxtDesc.Text + "','" + Convert.ToDouble(decimal.Parse(TxtQty.Text.ToString()).ToString("N3")) + "','" + DrpUnit.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(TxtRate.Text.ToString()).ToString("N3")) + "','" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				FillGrid();
				TxtDesc.Text = "";
				TxtQty.Text = "";
				DrpUnit.SelectedValue = "Select";
				TxtRate.Text = "";
				TxtDiscount.Text = "";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			TabContainer1.ActiveTab = TabContainer1.Tabs[1];
		}
	}

	protected void BtnCustomerNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void BtnCustomerCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Edit.aspx?ModId=2&SubModId=11");
	}

	protected void BtnGoodsNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void BtnGoodsCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Edit.aspx?ModId=2&SubModId=11");
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			if (drpQuotNO.SelectedItem.Text != "Select")
			{
				QuotNo = Convert.ToInt32(drpQuotNO.SelectedValue);
			}
			else
			{
				QuotNo = 0;
			}
			if (!(CustCode != "") || !(TxtPONo.Text != "") || !(TxtPODate.Text != "") || !(TxtPORecDate.Text != "") || !fun.DateValidation(TxtPODate.Text) || !fun.DateValidation(TxtPORecDate.Text) || !(TxtVendorCode.Text != "") || !(TxtPayments.Text != "") || !(TxtPF.Text != "") || !(TxtVAT.Text != "") || !(TxtExcise.Text != "") || !(TxtOctroi.Text != "") || !(TxtWarrenty.Text != "") || !(TxtInsurance.Text != "") || !(TxtTransPort.Text != "") || !(TxtNoteNo.Text != "") || !(TxtRegdNo.Text != "") || !(TxtFreight.Text != "") || !(poid != "") || !(Txtcst.Text != "") || !(Txtvalidity.Text != "") || !(Txtocharges.Text != ""))
			{
				return;
			}
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			podate = fun.FromDate(TxtPODate.Text);
			poRecdate = fun.FromDate(TxtPORecDate.Text);
			con.Open();
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
			string cmdText = fun.update("SD_Cust_PO_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',CompId='" + CId + "',FinYearId='" + FYId + "',CustomerId='" + CustCode + "',QuotationNo='" + QuotNo + "',PONo='" + TxtPONo.Text + "',PODate='" + podate + "',POReceivedDate='" + poRecdate + "',VendorCode='" + TxtVendorCode.Text + "',PaymentTerms='" + TxtPayments.Text + "',PF='" + TxtPF.Text + "',VAT='" + TxtVAT.Text + "',Excise='" + TxtExcise.Text + "',Octroi='" + TxtOctroi.Text + "',Warrenty='" + TxtWarrenty.Text + "',Insurance='" + TxtInsurance.Text + "',Transport='" + TxtTransPort.Text + "',NoteNo='" + TxtNoteNo.Text + "',RegistrationNo='" + TxtRegdNo.Text + "',Freight='" + TxtFreight.Text + "',Remarks='" + TxtRemarks.Text + "',CST='" + Txtcst.Text + "',Validity='" + Txtvalidity.Text + "',OtherCharges='" + Txtocharges.Text + "',FileName='" + text + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData=@Data", "POId='" + poid + "' AND  CompId='" + CId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.Parameters.AddWithValue("@Data", array);
			fun.InsertUpdateData(sqlCommand);
			DataSet dataSet = new DataSet();
			string cmdText2 = fun.select("*", "SD_Cust_PO_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CId + "' AND FinYearId ='" + FYId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_PO_Details_Temp");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText3 = fun.insert("SD_Cust_PO_Details", "ItemDesc,TotalQty,Unit,Rate,SessionId,CompId,FinYearId,POId,Discount", "'" + dataSet.Tables[0].Rows[i]["ItemDesc"].ToString() + "','" + dataSet.Tables[0].Rows[i]["TotalQty"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "','" + dataSet.Tables[0].Rows[i]["Rate"].ToString() + "','" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]) + "','" + FYId + "','" + poid + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2")) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
				}
			}
			base.Response.Redirect("CustPO_Edit.aspx?ModId=2&SubModId=11&msg=Customer PO is updated.");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void BtnTermsCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Edit.aspx?ModId=2&SubModId=11");
	}

	protected void lstTitles_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtPayments.Text = lstTitles.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtPF.Text = ListBox1.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtVAT.Text = ListBox2.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtExcise.Text = ListBox3.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtOctroi.Text = ListBox4.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtWarrenty.Text = ListBox5.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtInsurance.Text = ListBox6.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox7_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtTransPort.Text = ListBox7.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox11_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtFreight.Text = ListBox11.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView1.EditIndex = e.NewEditIndex;
		FillGrid();
		int editIndex = GridView1.EditIndex;
		GridViewRow gridViewRow = GridView1.Rows[editIndex];
		string text = ((Label)gridViewRow.FindControl("lblUniit1")).Text;
		((DropDownList)gridViewRow.FindControl("ddlunit")).SelectedValue = text;
	}

	private void FillGrid()
	{
		DataSet dataSet = new DataSet();
		try
		{
			SqlCommand selectCommand = new SqlCommand("SELECT SD_Cust_PO_Details_Temp.Id,Unit_Master.Symbol,SD_Cust_PO_Details_Temp.ItemDesc, SD_Cust_PO_Details_Temp.TotalQty,Unit_Master.Id As UnitId,SD_Cust_PO_Details_Temp.Discount,SD_Cust_PO_Details_Temp.Rate,SD_Cust_PO_Details_Temp.TotalQty *( SD_Cust_PO_Details_Temp.Rate- (SD_Cust_PO_Details_Temp.Rate *SD_Cust_PO_Details_Temp.Discount/100)) As Amount From SD_Cust_PO_Details_Temp INNER JOIN Unit_Master ON SD_Cust_PO_Details_Temp.Unit=Unit_Master.Id And SD_Cust_PO_Details_Temp.CompId ='" + CId + "'AND SD_Cust_PO_Details_Temp.FinYearId ='" + FYId + "' AND SD_Cust_PO_Details_Temp.SessionId ='" + SId + "'", con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, " SD_Cust_PO_Details_Temp");
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtDesc")).Text.ToString().Trim();
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtTotalQty")).Text).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate")).Text).ToString("N2"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount")).Text).ToString("N2"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (text != "" && num2.ToString() != "" && num3.ToString() != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = fun.update("SD_Cust_PO_Details_Temp", "ItemDesc='" + text + "',TotalQty=" + num2 + ",Unit=" + num5 + ",Rate=" + num3 + ",Discount=" + num4, "Id=" + num + " And CompId='" + CId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				GridView1.EditIndex = -1;
				FillGrid();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_PO_Details_Temp WHERE Id=" + num + " And CompId='" + CId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		FillGrid();
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		FillGrid();
	}

	private void FillGrid2()
	{
		DataSet dataSet = new DataSet();
		try
		{
			string cmdText = fun.select("SD_Cust_PO_Details.Id,Unit_Master.Symbol,SD_Cust_PO_Details.Discount,SD_Cust_PO_Details.ItemDesc,Unit_Master.Id As UnitId, SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Rate,SD_Cust_PO_Details.TotalQty *( SD_Cust_PO_Details.Rate- (SD_Cust_PO_Details.Rate *SD_Cust_PO_Details.Discount/100)) As Amount", "Unit_Master,SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Details.Unit=Unit_Master.Id And SD_Cust_PO_Details.CompId ='" + CId + "' And SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId And SD_Cust_PO_Details.POId='" + poid + "'  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView2.EditIndex = e.NewEditIndex;
		FillGrid2();
		int editIndex = GridView2.EditIndex;
		GridViewRow gridViewRow = GridView2.Rows[editIndex];
		string text = ((Label)gridViewRow.FindControl("lblUniit4")).Text;
		((DropDownList)gridViewRow.FindControl("ddlunit3")).SelectedValue = text;
	}

	public void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtDesc1")).Text.ToString().Trim();
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtTotalQty1")).Text).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate1")).Text).ToString("N2"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount1")).Text).ToString("N2"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit3");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (text != "" && num2.ToString() != "" && num3.ToString() != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = "UPDATE SD_Cust_PO_Details SET ItemDesc='" + text + "',TotalQty='" + num2 + "',Unit='" + num5 + "',Rate='" + num3 + "', Discount='" + num4 + "' WHERE Id=" + num + " And CompId='" + CId + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				GridView2.EditIndex = -1;
				FillGrid2();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_PO_Details WHERE Id=" + num + " And CompId='" + CId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			FillGrid2();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		GridView2.EditIndex = -1;
		FillGrid2();
	}

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView2.EditIndex = -1;
		FillGrid2();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
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
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	public void filldrpQuot()
	{
		try
		{
			DataSet dataSet = new DataSet();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("Id,QuotationNo+'['+REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-', SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-',SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-')+']'AS QuatNo", "SD_Cust_Quotation_Master", "CompId='" + CId + "' And FinYearId<='" + FYId + "' AND EnqId='" + enqId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_Quotation_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				drpQuotNO.DataSource = dataSet.Tables["SD_Cust_Quotation_Master"];
				drpQuotNO.DataTextField = "QuatNo";
				drpQuotNO.DataValueField = "Id";
				drpQuotNO.DataBind();
				drpQuotNO.Items.Insert(0, "Select");
			}
			else
			{
				drpQuotNO.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record updated successfully";
	}

	protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record updated successfully";
	}

	protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted successfully";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted successfully";
	}

	protected void ImageCross_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string text = "";
			text = fun.update("SD_Cust_PO_Master", "FileName='',FileSize='0',ContentType=''", "POId='" + poid + "'AND CompId='" + CId + "'");
			SqlCommand cmd = new SqlCommand(text, connection);
			fun.InsertUpdateData(cmd);
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}

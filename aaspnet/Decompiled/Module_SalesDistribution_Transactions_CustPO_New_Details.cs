using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_CustPO_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int enqId;

	private string SId = "";

	private int CId;

	private int FYId;

	private SqlConnection con;

	private string constr = "";

	protected Label LblName;

	protected Label HfCustId;

	protected Label HfEnqId;

	protected Label LblAddress;

	protected Label LblEnqNo;

	protected DropDownList drpQuotNO;

	protected TextBox TxtPONo;

	protected RequiredFieldValidator ReqPoNo;

	protected TextBox TxtPODate;

	protected CalendarExtender TxtPODate_CalendarExtender;

	protected RequiredFieldValidator ReqPoDate;

	protected RegularExpressionValidator RegPODate;

	protected TextBox TxtPORecDate;

	protected CalendarExtender TxtPORecDate_CalendarExtender;

	protected RequiredFieldValidator ReqRecDate;

	protected RegularExpressionValidator RegPORecDate;

	protected TextBox TxtVendorCode;

	protected RequiredFieldValidator ReqVendorCode;

	protected Button Button1;

	protected Button Button2;

	protected TabPanel TabPanel1;

	protected TextBox TxtItemDesc;

	protected RequiredFieldValidator ReqDesc;

	protected TextBox TxtQty;

	protected RequiredFieldValidator ReqTotQty;

	protected RegularExpressionValidator RegQty;

	protected TextBox TxtRate;

	protected RequiredFieldValidator ReqRate;

	protected RegularExpressionValidator Regrate;

	protected TextBox TxtDiscount;

	protected RequiredFieldValidator Reqdiscount;

	protected RegularExpressionValidator RegDisc;

	protected DropDownList DrpUnit;

	protected RequiredFieldValidator ReqDesc0;

	protected Button Button5;

	protected Button Button3;

	protected Button Button4;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource12;

	protected Label lblMessage;

	protected TabPanel TabPanel2;

	protected ListBox lstTitles;

	protected SqlDataSource SqlDataSource2;

	protected Panel Panel2;

	protected TextBox TxtPayments;

	protected DropDownExtender TxtPayments_DropDownExtender;

	protected RequiredFieldValidator ReqPayTerm;

	protected ListBox ListBox1;

	protected SqlDataSource SqlDataSource3;

	protected Panel Panel3;

	protected TextBox TxtPF;

	protected DropDownExtender TxtPF_DropDownExtender;

	protected RequiredFieldValidator ReqPF;

	protected ListBox ListBox3;

	protected SqlDataSource SqlDataSource5;

	protected Panel Panel5;

	protected TextBox TxtExcise;

	protected DropDownExtender TxtExcise_DropDownExtender;

	protected RequiredFieldValidator ReqExcise;

	protected ListBox ListBox2;

	protected SqlDataSource SqlDataSource4;

	protected Panel Panel4;

	protected TextBox txtVAT;

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

	protected RequiredFieldValidator ReqWarranty;

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

	protected RequiredFieldValidator ReqModTrans;

	protected TextBox TxtNoteNo;

	protected DropDownExtender TxtNoteNo_DropDownExtender;

	protected RequiredFieldValidator ReqGcNote;

	protected TextBox TxtRegdNo;

	protected RequiredFieldValidator ReqRegNo;

	protected ListBox ListBox11;

	protected SqlDataSource SqlDataSource11;

	protected Panel Panel12;

	protected TextBox TxtFreight;

	protected DropDownExtender TxtFreight_DropDownExtender;

	protected RequiredFieldValidator Reqfreight;

	protected TextBox Txtcst;

	protected RequiredFieldValidator ReqCST;

	protected TextBox Txtvalidity;

	protected RequiredFieldValidator ReqValidity;

	protected TextBox Txtocharges;

	protected RequiredFieldValidator ReqoCharges;

	protected FileUpload FileUpload1;

	protected TextBox TxtRemarks;

	protected Button Button6;

	protected Button BtnTermCancel;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		constr = fun.Connection();
		con = new SqlConnection(constr);
		try
		{
			SId = Session["username"].ToString();
			CId = Convert.ToInt32(Session["compid"]);
			FYId = Convert.ToInt32(Session["finyear"]);
			LblEnqNo.Text = base.Request.QueryString["EnqId"].ToString();
			HfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = HfCustId.Text;
			HfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(HfEnqId.Text);
			lblMessage.Text = "";
			TxtPORecDate.Attributes.Add("readonly", "readonly");
			TxtPODate.Attributes.Add("readonly", "readonly");
			if (base.IsPostBack)
			{
				return;
			}
			fun.dropdownUnit(DrpUnit);
			filldrpQuot();
			FillGrid();
			DataSet dataSet = new DataSet();
			con.Open();
			string cmdText = fun.select("CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CId + "'");
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
			drpQuotNO.DataSource = dataSet.Tables["SD_Cust_Quotation_Master"];
			drpQuotNO.DataTextField = "QuatNo";
			drpQuotNO.DataValueField = "Id";
			drpQuotNO.DataBind();
			drpQuotNO.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	protected void Button6_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (!(TxtPODate.Text != "") || !(TxtPORecDate.Text != "") || !fun.DateValidation(TxtPODate.Text) || !fun.DateValidation(TxtPORecDate.Text))
			{
				return;
			}
			string text = fun.FromDate(TxtPODate.Text);
			string text2 = fun.FromDate(TxtPORecDate.Text);
			int num = 0;
			num = ((drpQuotNO.SelectedItem.Text != "Select") ? Convert.ToInt32(drpQuotNO.SelectedValue) : 0);
			con.Open();
			if (!(TxtPayments.Text != "") || !(TxtVendorCode.Text != "") || !(Txtocharges.Text != "") || !(Txtvalidity.Text != "") || !(Txtcst.Text != "") || !(TxtFreight.Text != "") || !(TxtFreight.Text != "") || !(TxtRegdNo.Text != "") || !(TxtNoteNo.Text != "") || !(TxtTransPort.Text != "") || !(TxtInsurance.Text != "") || !(TxtWarrenty.Text != "") || !(TxtOctroi.Text != "") || !(TxtExcise.Text != "") || !(txtVAT.Text != "") || !(TxtPF.Text != "") || !(TxtPayments.Text != ""))
			{
				return;
			}
			string text3 = "";
			HttpPostedFile postedFile = FileUpload1.PostedFile;
			byte[] array = null;
			if (FileUpload1.PostedFile != null)
			{
				Stream inputStream = FileUpload1.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array = binaryReader.ReadBytes((int)inputStream.Length);
				text3 = Path.GetFileName(postedFile.FileName);
			}
			string cmdText = fun.insert("SD_Cust_PO_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,EnqId,QuotationNo,PONo,PODate,POReceivedDate,VendorCode,PaymentTerms,PF,VAT,Excise,Octroi,Warrenty,Insurance,Transport,NoteNo,RegistrationNo,Freight,Remarks,CST,Validity,OtherCharges,FileName,FileSize,ContentType,FileData", "'" + currDate + "','" + currTime + "','" + SId + "','" + CId + "','" + FYId + "','" + CustCode + "','" + enqId + "','" + num + "','" + TxtPONo.Text + "','" + text + "','" + text2 + "','" + TxtVendorCode.Text + "','" + TxtPayments.Text + "','" + TxtPF.Text + "','" + txtVAT.Text + "','" + TxtExcise.Text + "','" + TxtOctroi.Text + "','" + TxtWarrenty.Text + "','" + TxtInsurance.Text + "','" + TxtTransPort.Text + "','" + TxtNoteNo.Text + "','" + TxtRegdNo.Text + "','" + TxtFreight.Text + "','" + TxtRemarks.Text + "','" + Txtcst.Text + "','" + Txtvalidity.Text + "','" + Txtocharges.Text + "','" + text3 + "','" + array.Length + "','" + postedFile.ContentType + "',@Data");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.Parameters.AddWithValue("@Data", array);
			fun.InsertUpdateData(sqlCommand);
			string cmdText2 = fun.select("POId", "SD_Cust_PO_Master", "CompId='" + CId + "' order by POId DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SD_Cust_PO_Master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				DataSet dataSet2 = new DataSet();
				string cmdText3 = fun.select("*", "SD_Cust_PO_Details_Temp", "SessionId='" + SId + "' and CompId='" + CId + "' and FinYearId ='" + FYId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_PO_Details_Temp");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText4 = fun.insert("SD_Cust_PO_Details", "SessionId,CompId,FinYearId,POId,ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId.ToString() + "','" + CId + "','" + FYId + "','" + dataSet.Tables[0].Rows[0]["POId"].ToString() + "' ,'" + dataSet2.Tables[0].Rows[i]["ItemDesc"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["TotalQty"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Unit"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Rate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Discount"].ToString() + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
						sqlCommand2.ExecuteNonQuery();
					}
				}
			}
			string cmdText5 = fun.delete("SD_Cust_PO_Details_Temp", "SessionId='" + SId + "' and CompId='" + CId + "' and FinYearId ='" + FYId + "' ");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
			sqlCommand3.ExecuteNonQuery();
			string cmdText6 = fun.update("SD_Cust_Enquiry_Master", "POStatus=1", "EnqId='" + enqId + "' and CompId='" + CId + "' and FinYearId ='" + FYId + "' ");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText6, con);
			sqlCommand4.ExecuteNonQuery();
			base.Response.Redirect("CustPO_New.aspx?ModId=2&SubModId=11&msg=Customer PO is generated.");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void Button5_Click(object sender, EventArgs e)
	{
		try
		{
			if (TxtItemDesc.Text != "" && TxtQty.Text != "" && DrpUnit.SelectedValue != "Select" && TxtRate.Text != "" && TxtDiscount.Text != "" && fun.NumberValidationQty(TxtQty.Text) && fun.NumberValidationQty(TxtRate.Text) && fun.NumberValidationQty(TxtDiscount.Text))
			{
				double num = 0.0;
				num = Convert.ToDouble(decimal.Parse(TxtDiscount.Text).ToString("N2"));
				string cmdText = fun.insert("SD_Cust_PO_Details_Temp", "SessionId,CompId,FinYearId, ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId + "','" + CId + "' ,'" + FYId + "' ,'" + TxtItemDesc.Text + "','" + Convert.ToDouble(decimal.Parse(TxtQty.Text.ToString()).ToString("N3")) + "','" + DrpUnit.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(TxtRate.Text.ToString()).ToString("N2")) + "','" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillGrid();
				TxtItemDesc.Text = "";
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
			TabContainer1.ActiveTab = TabContainer1.Tabs[1];
		}
	}

	protected void TxtQty_TextChanged(object sender, EventArgs e)
	{
	}

	[ScriptMethod]
	[WebMethod]
	public static string GetDynamicContent(string contextKey)
	{
		return null;
	}

	protected void lstTitles_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtPayments.Text = lstTitles.SelectedItem.Text;
	}

	protected void Button3_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("CustPO_New.aspx?ModId=2&SubModId=11");
	}

	protected void Button4_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("CustPO_New.aspx?ModId=2&SubModId=11");
	}

	protected void Button7_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("CustPO_New.aspx?ModId=2&SubModId=11");
	}

	protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		TxtPF.Text = ListBox1.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		txtVAT.Text = ListBox2.SelectedItem.Text;
		TabContainer1.ActiveTabIndex = 2;
	}

	public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
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
		string text = ((Label)gridViewRow.FindControl("lblUniit2")).Text;
		((DropDownList)gridViewRow.FindControl("ddlunit")).SelectedValue = text;
	}

	private void FillGrid()
	{
		DataSet dataSet = new DataSet();
		try
		{
			con.Open();
			SqlCommand selectCommand = new SqlCommand("SELECT SD_Cust_PO_Details_Temp.Id,SD_Cust_PO_Details_Temp.Discount,Unit_Master.Symbol,SD_Cust_PO_Details_Temp.ItemDesc, Unit_Master.Id As UnitId,SD_Cust_PO_Details_Temp.TotalQty,SD_Cust_PO_Details_Temp.Rate,SD_Cust_PO_Details_Temp.TotalQty *( SD_Cust_PO_Details_Temp.Rate- (SD_Cust_PO_Details_Temp.Rate *SD_Cust_PO_Details_Temp.Discount/100)) As Amount From SD_Cust_PO_Details_Temp INNER JOIN Unit_Master ON SD_Cust_PO_Details_Temp.Unit=Unit_Master.Id And SD_Cust_PO_Details_Temp.CompId ='" + CId + "'AND SD_Cust_PO_Details_Temp.FinYearId ='" + FYId + "' AND SD_Cust_PO_Details_Temp.SessionId ='" + SId + "'Order by Id Desc ", con);
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

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_PO_Details_Temp WHERE Id=" + num + " And CompId='" + CId + "'", con);
			con.Open();
			int num2 = sqlCommand.ExecuteNonQuery();
			if (num2 == 1)
			{
				lblMessage.Text = "Record deleted successfully";
			}
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

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	[WebMethod]
	[ScriptMethod]
	public static string GetDynamicContent2(string contextKey)
	{
		return null;
	}

	protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtDesc")).Text.ToString();
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQty")).Text).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate")).Text).ToString("N2"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount")).Text).ToString("N2"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (((TextBox)gridViewRow.FindControl("txtDesc")).Text != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = "UPDATE SD_Cust_PO_Details_Temp SET ItemDesc='" + text + "',TotalQty=" + num2 + ",Unit=" + num5 + ",Rate=" + num3 + ",Discount=" + num4 + " WHERE Id=" + num + " And CompId='" + CId + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				int num6 = sqlCommand.ExecuteNonQuery();
				con.Close();
				if (num6 == 1)
				{
					lblMessage.Text = "Record updated successfully";
				}
				GridView1.EditIndex = -1;
				FillGrid();
			}
		}
		catch (Exception)
		{
		}
	}
}

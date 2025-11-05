using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_Quotation_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet ds = new DataSet();

	private string CustCode = "";

	private int CId;

	private string SId = "";

	private int FYId;

	private int enqId;

	private int id;

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string constr = "";

	private string QuotNo = "";

	protected Label LblQuoteNo;

	protected Label LblEnquiry;

	protected Label LblName;

	protected Label Lblpoid;

	protected Label LblCustId;

	protected Label LblAddress;

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

	protected TextBox TxtPayments;

	protected RequiredFieldValidator ReqPayment;

	protected TextBox TxtPF;

	protected RequiredFieldValidator ReqPf;

	protected RegularExpressionValidator RegPf;

	protected DropDownList DrpPFType;

	protected DropDownList DrpExcise;

	protected DropDownList DrpVat;

	protected TextBox TxtOctroi;

	protected RequiredFieldValidator ReqOctri;

	protected RegularExpressionValidator RegOctri;

	protected DropDownList DrpOctroiType;

	protected TextBox TxtWarrenty;

	protected RequiredFieldValidator Reqwarranty;

	protected TextBox TxtInsurance;

	protected RequiredFieldValidator ReqInsurance;

	protected RegularExpressionValidator RegInsurance;

	protected TextBox TxtTransPort;

	protected RequiredFieldValidator ReqTransport;

	protected TextBox TxtNoteNo;

	protected RequiredFieldValidator ReqGCNo;

	protected TextBox TxtRegdNo;

	protected TextBox TxtFreight;

	protected RequiredFieldValidator Reqfrieght;

	protected RegularExpressionValidator RegFright;

	protected DropDownList DrpFreightType;

	protected TextBox TxtDueDate;

	protected CalendarExtender TxtDueDate_CalendarExtender;

	protected RegularExpressionValidator RegDueDate;

	protected TextBox Txtvalidity;

	protected RequiredFieldValidator ReqValidity;

	protected TextBox Txtocharges;

	protected RequiredFieldValidator ReqoCharges;

	protected RegularExpressionValidator RegOthCharge;

	protected DropDownList DrpOChargeType;

	protected TextBox TxtDelTerms;

	protected RequiredFieldValidator ReqDelTerms;

	protected TextBox TxtRemarks;

	protected Button BtnUpdate;

	protected Button BtnTermsCancel;

	protected SqlDataSource SqlVAT;

	protected SqlDataSource SqlCST;

	protected SqlDataSource SqlExcise;

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
			QuotNo = base.Request.QueryString["QuotationNo"].ToString();
			LblQuoteNo.Text = QuotNo;
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			constr = fun.Connection();
			con = new SqlConnection(constr);
			lblMessage.Text = "";
			TxtDueDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.dropdownUnit(DrpUnit);
				FillGrid();
				FillGrid2();
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
				string cmdText5 = fun.select("*", " SD_Cust_Quotation_Master", "CustomerId='" + CustCode + "'and Id='" + id + "' and  CompId='" + CId + "'");
				string cmdText6 = fun.select("*", "SD_Cust_Quotation_Details", "Id='" + id + "' and  CompId='" + CId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				sqlDataAdapter6.Fill(dataSet5, "SD_Cust_Quotation_Details");
				sqlDataAdapter5.Fill(DS, "SD_Cust_Quotation_Master");
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
					TxtPayments.Text = DS.Tables[0].Rows[0]["PaymentTerms"].ToString();
					TxtPF.Text = DS.Tables[0].Rows[0]["PF"].ToString();
					DrpPFType.SelectedValue = DS.Tables[0].Rows[0]["PFType"].ToString();
					DrpVat.SelectedValue = DS.Tables[0].Rows[0]["VATCST"].ToString();
					TxtTransPort.Text = DS.Tables[0].Rows[0]["TransPort"].ToString();
					DrpExcise.SelectedValue = DS.Tables[0].Rows[0]["Excise"].ToString();
					TxtWarrenty.Text = DS.Tables[0].Rows[0]["Warrenty"].ToString();
					TxtOctroi.Text = DS.Tables[0].Rows[0]["Octroi"].ToString();
					DrpOctroiType.SelectedValue = DS.Tables[0].Rows[0]["OctroiType"].ToString();
					TxtInsurance.Text = DS.Tables[0].Rows[0]["Insurance"].ToString();
					TxtNoteNo.Text = DS.Tables[0].Rows[0]["NoteNo"].ToString();
					TxtRegdNo.Text = DS.Tables[0].Rows[0]["RegistrationNo"].ToString();
					DrpFreightType.SelectedValue = DS.Tables[0].Rows[0]["FreightType"].ToString();
					TxtFreight.Text = DS.Tables[0].Rows[0]["Freight"].ToString();
					TxtRemarks.Text = DS.Tables[0].Rows[0]["Remarks"].ToString();
					TxtDueDate.Text = fun.FromDateDMY(DS.Tables[0].Rows[0]["DueDate"].ToString());
					Txtvalidity.Text = DS.Tables[0].Rows[0]["Validity"].ToString();
					Txtocharges.Text = DS.Tables[0].Rows[0]["OtherCharges"].ToString();
					DrpOChargeType.SelectedValue = DS.Tables[0].Rows[0]["OtherChargesType"].ToString();
					TxtDelTerms.Text = DS.Tables[0].Rows[0]["DeliveryTerms"].ToString();
					TxtDueDate.Text = fun.FromDateDMY(DS.Tables[0].Rows[0]["DueDate"].ToString());
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
				num = Convert.ToDouble(decimal.Parse(TxtDiscount.Text.ToString()).ToString("N2"));
				string cmdText = fun.insert("SD_Cust_Quotation_Details_Temp", "SessionId,CompId,FinYearId, ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId + "','" + CId + "' ,'" + FYId + "' ,'" + TxtDesc.Text + "','" + Convert.ToDouble(decimal.Parse(TxtQty.Text.ToString()).ToString("N3")) + "','" + DrpUnit.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(TxtRate.Text.ToString()).ToString("N2")) + "','" + num + "'");
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
		base.Response.Redirect("Quotation_Edit.aspx?ModId=2&SubModId=63");
	}

	protected void BtnGoodsNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void BtnGoodsCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Quotation_Edit.aspx?ModId=2&SubModId=63");
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		try
		{
			if (!(CustCode != "") || !(TxtPayments.Text != "") || !(TxtPF.Text != "") || !(TxtOctroi.Text != "") || !(TxtWarrenty.Text != "") || !(TxtInsurance.Text != "") || !(TxtTransPort.Text != "") || !(TxtNoteNo.Text != "") || !(TxtFreight.Text != "") || !(Txtvalidity.Text != "") || !(Txtocharges.Text != "") || !(TxtDelTerms.Text != "") || !fun.DateValidation(TxtDueDate.Text) || !fun.NumberValidationQty(TxtPF.Text) || !fun.NumberValidationQty(Txtocharges.Text) || !fun.NumberValidationQty(TxtOctroi.Text) || !fun.NumberValidationQty(TxtFreight.Text) || !fun.NumberValidationQty(TxtInsurance.Text))
			{
				return;
			}
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			con.Open();
			string cmdText = fun.update("SD_Cust_Quotation_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + SId + "',CompId='" + CId + "',FinYearId='" + FYId + "',CustomerId='" + CustCode + "',QuotationNo='" + QuotNo + "',PaymentTerms='" + TxtPayments.Text + "',PF='" + TxtPF.Text + "',VATCST='" + DrpVat.SelectedValue + "',Excise='" + DrpExcise.SelectedValue + "',Octroi='" + TxtOctroi.Text + "',Warrenty='" + TxtWarrenty.Text + "',Insurance='" + TxtInsurance.Text + "',Transport='" + TxtTransPort.Text + "',NoteNo='" + TxtNoteNo.Text + "',RegistrationNo='" + TxtRegdNo.Text + "',Freight='" + TxtFreight.Text + "',Remarks='" + TxtRemarks.Text + "',Validity='" + Txtvalidity.Text + "',OtherCharges='" + Txtocharges.Text + "',DeliveryTerms='" + TxtDelTerms.Text + "',PFType='" + DrpPFType.SelectedValue + "',OctroiType='" + DrpOctroiType.SelectedValue + "',OtherChargesType='" + DrpOChargeType.SelectedValue + "',FreightType='" + DrpFreightType.SelectedValue + "', DueDate='" + fun.FromDate(TxtDueDate.Text) + "'", "Id='" + id + "' AND  CompId='" + CId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			DataSet dataSet = new DataSet();
			string cmdText2 = fun.select("*", "SD_Cust_Quotation_Details_Temp", "SessionId='" + SId + "' AND CompId='" + CId + "' AND FinYearId ='" + FYId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "SD_Cust_Quotation_Details_Temp");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText3 = fun.insert("SD_Cust_Quotation_Details", "ItemDesc,TotalQty,Unit,Rate,SessionId,CompId,FinYearId,MId,Discount", "'" + dataSet.Tables[0].Rows[i]["ItemDesc"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["TotalQty"].ToString()).ToString("N3")) + "','" + dataSet.Tables[0].Rows[i]["Unit"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2")) + "','" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]) + "','" + FYId + "','" + id + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2")) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
				}
			}
			base.Response.Redirect("Quotation_Edit.aspx?ModId=2&SubModId=63&msg=Quotation is updated.");
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
		base.Response.Redirect("Quotation_Edit.aspx?ModId=2&SubModId=63");
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
			SqlCommand selectCommand = new SqlCommand("SELECT SD_Cust_Quotation_Details_Temp.Id,Unit_Master.Symbol,Unit_Master.Id as UnitId ,SD_Cust_Quotation_Details_Temp.ItemDesc, SD_Cust_Quotation_Details_Temp.TotalQty,SD_Cust_Quotation_Details_Temp.Discount,SD_Cust_Quotation_Details_Temp.Rate From SD_Cust_Quotation_Details_Temp INNER JOIN Unit_Master ON SD_Cust_Quotation_Details_Temp.Unit=Unit_Master.Id And SD_Cust_Quotation_Details_Temp.CompId ='" + CId + "'AND SD_Cust_Quotation_Details_Temp.FinYearId ='" + FYId + "' AND SD_Cust_Quotation_Details_Temp.SessionId ='" + SId + "' order by Id Desc", con);
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_Quotation_Details_Temp WHERE Id=" + num + " And CompId='" + CId + "'", con);
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

	private void FillGrid2()
	{
		DataSet dataSet = new DataSet();
		try
		{
			string cmdText = fun.select("SD_Cust_Quotation_Details.Id,Unit_Master.Symbol,Unit_Master.Id As UnitId,SD_Cust_Quotation_Details.Discount,SD_Cust_Quotation_Details.ItemDesc, SD_Cust_Quotation_Details.TotalQty,SD_Cust_Quotation_Details.Rate", "Unit_Master,SD_Cust_Quotation_Details,SD_Cust_Quotation_Master", "SD_Cust_Quotation_Details.Unit=Unit_Master.Id And SD_Cust_Quotation_Details.CompId ='" + CId + "'AND SD_Cust_Quotation_Master.Id=SD_Cust_Quotation_Details.MId And SD_Cust_Quotation_Details.MId='" + id + "'order by Id Desc  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, " SD_Cust_Quotation_Details");
			GridView2.DataSource = dataSet;
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

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridView2.EditIndex = e.NewEditIndex;
		FillGrid2();
		int editIndex = GridView2.EditIndex;
		GridViewRow gridViewRow = GridView2.Rows[editIndex];
		string text = ((Label)gridViewRow.FindControl("lblUniit2")).Text;
		((DropDownList)gridViewRow.FindControl("ddlunit1")).SelectedValue = text;
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
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate")).Text).ToString("N3"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount")).Text).ToString("N3"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (text.ToString() != "" && num2.ToString() != "" && num3.ToString() != "" && num4.ToString() != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = fun.update("SD_Cust_Quotation_Details_Temp", "ItemDesc='" + text + "',TotalQty=" + num2 + ",Unit=" + num5 + ",Rate=" + num3 + ",Discount=" + num4, "Id=" + num + " And CompId='" + CId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				int num6 = sqlCommand.ExecuteNonQuery();
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
		finally
		{
			con.Close();
		}
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
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate1")).Text).ToString("N3"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount1")).Text).ToString("N3"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit1");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (text.ToString() != "" && num2.ToString() != "" && num3.ToString() != "" && num4.ToString() != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = "UPDATE SD_Cust_Quotation_Details SET ItemDesc='" + text + "',TotalQty='" + num2 + "',Unit='" + num5 + "',Rate='" + num3 + "', Discount='" + num4 + "' WHERE Id=" + num + " And CompId='" + CId + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				int num6 = sqlCommand.ExecuteNonQuery();
				if (num6 == 1)
				{
					lblMessage.Text = "Record updated successfully";
				}
			}
			GridView2.EditIndex = -1;
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

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_Quotation_Details WHERE Id=" + num + " And CompId='" + CId + "'", con);
			con.Open();
			int num2 = sqlCommand.ExecuteNonQuery();
			if (num2 == 1)
			{
				lblMessage.Text = "Record deleted successfully";
			}
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
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_Quotation_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private int enqId;

	private string SId = "";

	private int CompId;

	private int FinYearId;

	private SqlConnection con;

	private string constr = "";

	protected Label LblName;

	protected Label HfCustId;

	protected Label HfEnqId;

	protected Label LblEnqNo;

	protected Label LblAddress;

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

	protected RegularExpressionValidator RegRate;

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

	protected TextBox TxtPayments;

	protected RequiredFieldValidator ReqPayTerm;

	protected TextBox TxtPF;

	protected RequiredFieldValidator ReqPF;

	protected RegularExpressionValidator RegRate0;

	protected DropDownList DrpPFType;

	protected DropDownList DrpExcise;

	protected DropDownList DrpVat;

	protected TextBox TxtOctroi;

	protected RequiredFieldValidator ReqOctri;

	protected RegularExpressionValidator RegRate2;

	protected DropDownList DrpOctroiType;

	protected TextBox TxtWarrenty;

	protected RequiredFieldValidator ReqWarranty;

	protected TextBox TxtInsurance;

	protected RequiredFieldValidator ReqInsurance;

	protected RegularExpressionValidator RegRate3;

	protected TextBox TxtTransPort;

	protected RequiredFieldValidator ReqModTrans;

	protected TextBox TxtNoteNo;

	protected RequiredFieldValidator ReqGcNote;

	protected TextBox TxtRegdNo;

	protected RequiredFieldValidator ReqRegNo;

	protected TextBox TxtFreight;

	protected RequiredFieldValidator Reqfreight;

	protected RegularExpressionValidator RegRate4;

	protected DropDownList DrpFreightType;

	protected TextBox TxtDueDate;

	protected CalendarExtender TxtDueDate_CalendarExtender;

	protected RegularExpressionValidator RegDueDate;

	protected TextBox Txtvalidity;

	protected RequiredFieldValidator ReqValidity;

	protected TextBox Txtocharges;

	protected RequiredFieldValidator ReqoCharges;

	protected RegularExpressionValidator RegRate1;

	protected DropDownList DrpOChargeType;

	protected TextBox TxtDelTerms;

	protected RequiredFieldValidator ReqDelTerms;

	protected TextBox TxtRemarks;

	protected SqlDataSource SqlCST;

	protected Button Button6;

	protected Button BtnTermCancel;

	protected SqlDataSource SqlExcise;

	protected SqlDataSource SqlVAT;

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
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			LblEnqNo.Text = base.Request.QueryString["EnqId"].ToString();
			HfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = HfCustId.Text;
			HfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(HfEnqId.Text);
			lblMessage.Text = "";
			TxtDueDate.Attributes.Add("readonly", "readonly");
			if (base.IsPostBack)
			{
				return;
			}
			fun.dropdownUnit(DrpUnit);
			FillGrid();
			DataSet dataSet = new DataSet();
			con.Open();
			string cmdText = fun.select("CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
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
				TabContainer1.OnClientActiveTabChanged = "OnChanged";
				TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
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

	protected void Button6_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			con.Open();
			string cmdText = fun.select("QuotationNo", "SD_Cust_Quotation_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by QuotationNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SD_Cust_Quotation_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			if (!(TxtPayments.Text != "") || !(TxtPF.Text != "") || !(TxtOctroi.Text != "") || !(TxtWarrenty.Text != "") || !(TxtInsurance.Text != "") || !(TxtTransPort.Text != "") || !(TxtNoteNo.Text != "") || !(TxtFreight.Text != "") || !(Txtvalidity.Text != "") || !(Txtocharges.Text != "") || !(TxtDelTerms.Text != "") || !fun.DateValidation(TxtDueDate.Text) || !fun.NumberValidationQty(TxtPF.Text) || !fun.NumberValidationQty(Txtocharges.Text) || !fun.NumberValidationQty(TxtOctroi.Text) || !fun.NumberValidationQty(TxtFreight.Text) || !fun.NumberValidationQty(TxtInsurance.Text))
			{
				return;
			}
			string cmdText2 = fun.insert("SD_Cust_Quotation_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,EnqId,QuotationNo,PaymentTerms,PF,VATCST,Excise,Octroi,Warrenty,Insurance,Transport,NoteNo,RegistrationNo,Freight,Remarks,Validity,OtherCharges,DeliveryTerms,PFType,OctroiType,OtherChargesType,FreightType,DueDate", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + CustCode + "','" + enqId + "','" + text + "','" + TxtPayments.Text + "','" + TxtPF.Text + "','" + DrpVat.SelectedValue + "','" + DrpExcise.SelectedValue + "','" + TxtOctroi.Text + "','" + TxtWarrenty.Text + "','" + TxtInsurance.Text + "','" + TxtTransPort.Text + "','" + TxtNoteNo.Text + "','" + TxtRegdNo.Text + "','" + TxtFreight.Text + "','" + TxtRemarks.Text + "','" + Txtvalidity.Text + "','" + Txtocharges.Text + "','" + TxtDelTerms.Text + "','" + DrpPFType.SelectedValue + "','" + DrpOctroiType.SelectedValue + "','" + DrpOChargeType.SelectedValue + "','" + DrpFreightType.SelectedValue + "','" + fun.FromDate(TxtDueDate.Text) + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = fun.select("Id", "SD_Cust_Quotation_Master", "CompId='" + CompId + "' order by Id DESC");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "SD_Cust_Quotation_Master");
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				DataSet dataSet3 = new DataSet();
				string cmdText4 = fun.select("*", "SD_Cust_Quotation_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3, "SD_Cust_Quotation_Details_Temp");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
					{
						string cmdText5 = fun.insert("SD_Cust_Quotation_Details", "SessionId,CompId,FinYearId,MId,ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId.ToString() + "','" + CompId + "','" + FinYearId + "','" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "' ,'" + dataSet3.Tables[0].Rows[i]["ItemDesc"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["TotalQty"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["Unit"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2")) + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
						sqlCommand2.ExecuteNonQuery();
					}
				}
			}
			string cmdText6 = fun.delete("SD_Cust_Quotation_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
			sqlCommand3.ExecuteNonQuery();
			string cmdText7 = fun.update("SD_Cust_Enquiry_Master", "POStatus=1", "EnqId='" + enqId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText7, con);
			sqlCommand4.ExecuteNonQuery();
			base.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63&msg=Quotation is generated.");
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
				num = Convert.ToDouble(decimal.Parse(TxtDiscount.Text.ToString()).ToString("N2"));
				string cmdText = fun.insert("SD_Cust_Quotation_Details_Temp", "SessionId,CompId,FinYearId, ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId + "','" + CompId + "' ,'" + FinYearId + "' ,'" + TxtItemDesc.Text + "','" + Convert.ToDouble(decimal.Parse(TxtQty.Text.ToString()).ToString("N3")) + "','" + DrpUnit.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(TxtRate.Text.ToString()).ToString("N2")) + "','" + num + "'");
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
		Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");
	}

	protected void Button4_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");
	}

	protected void Button7_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");
	}

	public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
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
			SqlCommand selectCommand = new SqlCommand("SELECT SD_Cust_Quotation_Details_Temp.Id,SD_Cust_Quotation_Details_Temp.Discount,Unit_Master.Symbol,Unit_Master.Id As UnitId,SD_Cust_Quotation_Details_Temp.ItemDesc, SD_Cust_Quotation_Details_Temp.TotalQty,SD_Cust_Quotation_Details_Temp.Rate From SD_Cust_Quotation_Details_Temp INNER JOIN Unit_Master ON SD_Cust_Quotation_Details_Temp.Unit=Unit_Master.Id And SD_Cust_Quotation_Details_Temp.CompId ='" + CompId + "'AND SD_Cust_Quotation_Details_Temp.FinYearId ='" + FinYearId + "' AND SD_Cust_Quotation_Details_Temp.SessionId ='" + SId + "'Order by Id Desc ", con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, " SD_Cust_Quotation_Details_Temp");
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
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQty")).Text).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRate")).Text).ToString("N3"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtDiscount")).Text).ToString("N3"));
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddlunit");
			string selectedValue = dropDownList.SelectedValue;
			int num5 = Convert.ToInt32(selectedValue);
			if (text.ToString() != "" && num2.ToString() != "" && num3.ToString() != "" && num4.ToString() != "" && fun.NumberValidationQty(num2.ToString()) && fun.NumberValidationQty(num3.ToString()) && fun.NumberValidationQty(num4.ToString()))
			{
				string cmdText = "UPDATE SD_Cust_Quotation_Details_Temp SET ItemDesc='" + text + "',TotalQty=" + num2 + ",Unit=" + num5 + ",Rate=" + num3 + ",Discount=" + num4 + " WHERE Id=" + num + " And CompId='" + CompId + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				int num6 = sqlCommand.ExecuteNonQuery();
				con.Close();
				if (num6 == 1)
				{
					lblMessage.Text = "Record updated successfully";
				}
			}
			GridView1.EditIndex = -1;
			FillGrid();
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM SD_Cust_Quotation_Details_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
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
}

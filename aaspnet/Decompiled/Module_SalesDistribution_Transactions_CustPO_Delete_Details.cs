using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_CustPO_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet ds = new DataSet();

	private string CustCode = "";

	private int enqId;

	private string poid = "";

	private int CId;

	private string constr = "";

	private SqlConnection con;

	protected Label LblName;

	protected Label Lblpoid;

	protected Label LblCustId;

	protected Label LblAddress;

	protected Label LblEnquiry;

	protected Label lblquoteNo;

	protected TextBox TxtPONo;

	protected TextBox TxtPODate;

	protected TextBox TxtPORecDate;

	protected TextBox TxtVendorCode;

	protected Button BtnCustomerNext;

	protected Button BtnCustomerCancel;

	protected TabPanel TabPanel2;

	protected GridView GridView1;

	protected TabPanel TabPanel1;

	protected TextBox TxtPayments;

	protected DropDownExtender TxtPayments_DropDownExtender;

	protected TextBox TxtPF;

	protected DropDownExtender TxtPF_DropDownExtender;

	protected TextBox TxtExcise;

	protected DropDownExtender TxtExcise_DropDownExtender;

	protected TextBox TxtVAT;

	protected DropDownExtender TxtVAT_DropDownExtender;

	protected TextBox TxtOctroi;

	protected DropDownExtender TxtOctroi_DropDownExtender;

	protected TextBox TxtWarrenty;

	protected DropDownExtender TxtWarrenty_DropDownExtender;

	protected TextBox TxtInsurance;

	protected DropDownExtender TxtInsurance_DropDownExtender;

	protected TextBox TxtTransPort;

	protected DropDownExtender TxtTransPort_DropDownExtender;

	protected TextBox TxtNoteNo;

	protected DropDownExtender TxtNoteNo_DropDownExtender;

	protected TextBox TxtRegdNo;

	protected DropDownExtender TxtRegdNo_DropDownExtender;

	protected TextBox TxtFreight;

	protected DropDownExtender TxtFreight_DropDownExtender;

	protected TextBox Txtcst;

	protected TextBox Txtvalidity;

	protected TextBox Txtocharges;

	protected TextBox TxtRemarks;

	protected Button BtnDelete;

	protected Button BtnTermsCancel;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CId = Convert.ToInt32(Session["compid"]);
			LblCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = LblCustId.Text;
			LblEnquiry.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(LblEnquiry.Text);
			Lblpoid.Text = base.Request.QueryString["POId"].ToString();
			poid = Lblpoid.Text;
			constr = fun.Connection();
			con = new SqlConnection(constr);
			FillGrid2();
			if (!base.IsPostBack)
			{
				con.Open();
				DataSet dataSet = new DataSet();
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
				string cmdText5 = fun.select("*", " SD_Cust_PO_Master", "CustomerId='" + CustCode + "'and POId='" + poid + "' And CompId='" + CId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				sqlDataAdapter5.Fill(DS, "SD_Cust_PO_Master");
				if (DS.Tables[0].Rows.Count > 0)
				{
					string text = fun.FromDateDMY(DS.Tables[0].Rows[0]["PODate"].ToString());
					string text2 = fun.FromDateDMY(DS.Tables[0].Rows[0]["POReceivedDate"].ToString());
					TxtPONo.Text = base.Request.QueryString["PONo"].ToString();
					TxtPODate.Text = text;
					TxtPORecDate.Text = text2;
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
					string cmdText6 = fun.select("QuotationNo", " SD_Cust_Quotation_Master", "Id='" + DS.Tables[0].Rows[0]["QuotationNo"].ToString() + "' And CompId='" + CId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter6.Fill(dataSet5, "SD_Cust_Quotation_Master");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						lblquoteNo.Text = dataSet5.Tables[0].Rows[0]["QuotationNo"].ToString();
					}
					else
					{
						lblquoteNo.Text = "NA";
					}
					Txtcst.Text = DS.Tables[0].Rows[0]["CST"].ToString();
					Txtvalidity.Text = DS.Tables[0].Rows[0]["Validity"].ToString();
					Txtocharges.Text = DS.Tables[0].Rows[0]["OtherCharges"].ToString();
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

	private void FillGrid2()
	{
		DataSet dataSet = new DataSet();
		try
		{
			con.Open();
			string cmdText = fun.select("SD_Cust_PO_Details.Id,SD_Cust_PO_Details.Discount,Unit_Master.Symbol,SD_Cust_PO_Details.ItemDesc, SD_Cust_PO_Details.TotalQty,SD_Cust_PO_Details.Rate,SD_Cust_PO_Details.TotalQty *( SD_Cust_PO_Details.Rate- (SD_Cust_PO_Details.Rate *SD_Cust_PO_Details.Discount/100)) As Amount", "Unit_Master,SD_Cust_PO_Details,SD_Cust_PO_Master", "SD_Cust_PO_Details.Unit=Unit_Master.Id And SD_Cust_PO_Details.CompId ='" + CId + "' And SD_Cust_PO_Master.POId=SD_Cust_PO_Details.POId And SD_Cust_PO_Details.POId='" + poid + "'  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
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

	protected void BtnCustomerNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void BtnCustomerCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Delete.aspx?ModId=2&SubModId=11");
	}

	protected void BtnGoodsNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void BtnGoodsCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Delete.aspx?ModId=2&SubModId=11");
	}

	protected void BtnTermsCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustPO_Delete.aspx?ModId=2&SubModId=11");
	}

	protected void BtnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string cmdText = fun.delete("SD_Cust_PO_Master", "POId='" + poid + "' and CompId='" + CId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = fun.delete("SD_Cust_PO_Details", "POId='" + poid + "' and CompId='" + CId + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			sqlCommand2.ExecuteNonQuery();
			base.Response.Redirect("CustPO_Delete.aspx?ModId=2&SubModId=11&msg=Customer PO is deleted.");
		}
		catch (SqlException)
		{
			string empty = string.Empty;
			empty = "You Cannot delete this PO. This is in use. ";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillGrid2();
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_SalesDistribution_Transactions_WorkOrder_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CustCode = "";

	private string pono = "";

	private string wono = "";

	private int enqId;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string connStr = "";

	private SqlConnection con;

	protected Label lblCustomerName;

	protected Label hfCustId;

	protected Label hfPoNo;

	protected Label lblWONo;

	protected Label hfEnqId;

	protected DropDownList DDLTaskWOType;

	protected SqlDataSource SqlDataSource2;

	protected TextBox txtWorkOrderDate;

	protected CalendarExtender txtWorkOrderDate_CalendarExtender;

	protected TextBox txtProjectTitle;

	protected TextBox txtProjectLeader;

	protected DropDownList DDLCategory;

	protected DropDownList DDLBusinessGroup;

	protected TextBox txtTaskTargetDAP_FDate;

	protected CalendarExtender txtTaskTargetDAP_FDate_CalendarExtender;

	protected TextBox txtTaskTargetDAP_TDate;

	protected CalendarExtender txtTaskTargetDAP_TDate_CalendarExtender;

	protected TextBox txtTaskDesignFinalization_FDate;

	protected CalendarExtender txtTaskDesignFinalization_FDate_CalendarExtender;

	protected TextBox txtTaskDesignFinalization_TDate;

	protected CalendarExtender txtTaskDesignFinalization_TDate_CalendarExtender;

	protected TextBox txtTaskTargetManufg_FDate;

	protected CalendarExtender txtTaskTargetManufg_FDate_CalendarExtender;

	protected TextBox txtTaskTargetManufg_TDate;

	protected CalendarExtender txtTaskTargetManufg_TDate_CalendarExtender;

	protected TextBox txtTaskTargetTryOut_FDate;

	protected CalendarExtender txtTaskTargetTryOut_FDate_CalendarExtender;

	protected TextBox txtTaskTargetTryOut_TDate;

	protected CalendarExtender txtTaskTargetTryOut_TDate_CalendarExtender;

	protected TextBox txtTaskTargetDespach_FDate;

	protected CalendarExtender txtTaskTargetDespach_FDate_CalendarExtender;

	protected TextBox txtTaskTargetDespach_TDate;

	protected CalendarExtender txtTaskTargetDespach_TDate_CalendarExtender;

	protected TextBox txtTaskTargetAssembly_FDate;

	protected CalendarExtender txtTaskTargetAssembly_FDate_CalendarExtender;

	protected TextBox txtTaskTargetAssembly_TDate;

	protected CalendarExtender txtTaskTargetAssembly_TDate_CalendarExtender;

	protected TextBox txtTaskTargetInstalation_FDate;

	protected CalendarExtender txtTaskTargetInstalation_FDate_CalendarExtender;

	protected TextBox txtTaskTargetInstalation_TDate;

	protected CalendarExtender txtTaskTargetInstalation_TDate_CalendarExtender;

	protected TextBox txtTaskCustInspection_FDate;

	protected CalendarExtender txtTaskCustInspection_FDate_CalendarExtender;

	protected TextBox txtTaskCustInspection_TDate;

	protected CalendarExtender txtTaskCustInspection_TDate_CalendarExtender;

	protected Button btnTaskNext;

	protected Button btnTaskCancel;

	protected TabPanel TabPanel1;

	protected TextBox txtShippingAdd;

	protected DropDownList DDLShippingCountry;

	protected DropDownList DDLShippingState;

	protected DropDownList DDLShippingCity;

	protected TextBox txtShippingContactPerson1;

	protected TextBox txtShippingContactNo1;

	protected TextBox txtShippingEmail1;

	protected TextBox txtShippingContactPerson2;

	protected TextBox txtShippingContactNo2;

	protected TextBox txtShippingEmail2;

	protected TextBox txtShippingFaxNo;

	protected TextBox txtShippingEccNo;

	protected TextBox txtShippingTinCstNo;

	protected TextBox txtShippingTinVatNo;

	protected Button btnShippingNext;

	protected Button btnShippingCancel;

	protected TabPanel TabPanel2;

	protected GridView GridView1;

	protected Button btnProductNext;

	protected Button btnProductCancel;

	protected Label lblmsg;

	protected SqlDataSource SqlDataSource1;

	protected TabPanel TabPanel3;

	protected CheckBox CKInstractionPrimerPainting;

	protected CheckBox CKInstractionPainting;

	protected CheckBox CKInstractionSelfCertRept;

	protected TextBox txtInstractionOther;

	protected TextBox txtInstractionExportCaseMark;

	protected Button btnDelete;

	protected Button btnCancel;

	protected TabPanel TabPanel4;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			hfCustId.Text = base.Request.QueryString["CustomerId"].ToString();
			CustCode = hfCustId.Text;
			lblWONo.Text = base.Request.QueryString["WONo"].ToString();
			wono = lblWONo.Text;
			hfPoNo.Text = base.Request.QueryString["PONo"].ToString();
			pono = hfPoNo.Text;
			hfEnqId.Text = base.Request.QueryString["EnqId"].ToString();
			enqId = Convert.ToInt32(hfEnqId.Text);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblmsg.Text = "";
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
				fun.dropdownCategory(DDLCategory);
				fun.dropdownBG(DDLBusinessGroup);
				con.Open();
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblCustomerName.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				}
				DataSet dataSet2 = new DataSet();
				string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Master", "CustomerId='" + CustCode + "' and WONo='" + wono + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "SD_Cust_WorkOrder_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					fun.dropdownCountrybyId(DDLShippingCountry, DDLShippingState, "CId='" + dataSet2.Tables[0].Rows[0]["ShippingCountry"].ToString() + "'");
					DDLShippingCountry.SelectedIndex = 0;
					fun.dropdownCountry(DDLShippingCountry, DDLShippingState);
					fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
					fun.dropdownStatebyId(DDLShippingState, "CId='" + dataSet2.Tables[0].Rows[0]["ShippingCountry"].ToString() + "' AND SId='" + dataSet2.Tables[0].Rows[0]["ShippingState"].ToString() + "'");
					DDLShippingState.SelectedValue = dataSet2.Tables[0].Rows[0]["ShippingState"].ToString();
					fun.dropdownCity(DDLShippingCity, DDLShippingState);
					fun.dropdownCitybyId(DDLShippingCity, "SId='" + dataSet2.Tables[0].Rows[0]["ShippingState"].ToString() + "' AND CityId='" + dataSet2.Tables[0].Rows[0]["ShippingCity"].ToString() + "'");
					DDLShippingCity.SelectedValue = dataSet2.Tables[0].Rows[0]["ShippingCity"].ToString();
					hfEnqId.Text = dataSet2.Tables[0].Rows[0]["EnqId"].ToString();
					DDLTaskWOType.SelectedValue = dataSet2.Tables[0].Rows[0]["TaskWorkOrderType"].ToString();
					string text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString());
					txtWorkOrderDate.Text = text;
					txtProjectTitle.Text = dataSet2.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
					txtProjectLeader.Text = dataSet2.Tables[0].Rows[0]["TaskProjectLeader"].ToString();
					DDLCategory.SelectedValue = dataSet2.Tables[0].Rows[0]["TaskCategory"].ToString();
					DDLBusinessGroup.SelectedValue = dataSet2.Tables[0].Rows[0]["TaskBusinessGroup"].ToString();
					string text2 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDAP_FDate"].ToString());
					string text3 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDAP_TDate"].ToString());
					txtTaskTargetDAP_FDate.Text = text2;
					txtTaskTargetDAP_TDate.Text = text3;
					string text4 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskDesignFinalization_FDate"].ToString());
					string text5 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskDesignFinalization_TDate"].ToString());
					txtTaskDesignFinalization_FDate.Text = text4;
					txtTaskDesignFinalization_TDate.Text = text5;
					string text6 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetManufg_FDate"].ToString());
					string text7 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetManufg_TDate"].ToString());
					txtTaskTargetManufg_FDate.Text = text6;
					txtTaskTargetManufg_TDate.Text = text7;
					string text8 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
					string text9 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
					txtTaskTargetTryOut_FDate.Text = text8;
					txtTaskTargetTryOut_TDate.Text = text9;
					string text10 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
					string text11 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
					txtTaskTargetDespach_FDate.Text = text10;
					txtTaskTargetDespach_TDate.Text = text11;
					string text12 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetAssembly_FDate"].ToString());
					string text13 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetAssembly_TDate"].ToString());
					txtTaskTargetAssembly_FDate.Text = text12;
					txtTaskTargetAssembly_TDate.Text = text13;
					string text14 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
					string text15 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskTargetInstalation_TDate"].ToString());
					txtTaskTargetInstalation_FDate.Text = text14;
					txtTaskTargetInstalation_TDate.Text = text15;
					string text16 = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString());
					string text17 = fun.ToDateDMY(dataSet2.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString());
					txtTaskCustInspection_FDate.Text = text16;
					txtTaskCustInspection_TDate.Text = text17;
					txtShippingAdd.Text = dataSet2.Tables[0].Rows[0]["ShippingAdd"].ToString();
					txtShippingContactPerson1.Text = dataSet2.Tables[0].Rows[0]["ShippingContactPerson1"].ToString();
					txtShippingContactNo1.Text = dataSet2.Tables[0].Rows[0]["ShippingContactNo1"].ToString();
					txtShippingEmail1.Text = dataSet2.Tables[0].Rows[0]["ShippingEmail1"].ToString();
					txtShippingContactPerson2.Text = dataSet2.Tables[0].Rows[0]["ShippingContactPerson2"].ToString();
					txtShippingContactNo2.Text = dataSet2.Tables[0].Rows[0]["ShippingContactNo2"].ToString();
					txtShippingEmail2.Text = dataSet2.Tables[0].Rows[0]["ShippingEmail2"].ToString();
					txtShippingFaxNo.Text = dataSet2.Tables[0].Rows[0]["ShippingFaxNo"].ToString();
					txtShippingEccNo.Text = dataSet2.Tables[0].Rows[0]["ShippingEccNo"].ToString();
					txtShippingTinCstNo.Text = dataSet2.Tables[0].Rows[0]["ShippingTinCstNo"].ToString();
					txtShippingTinVatNo.Text = dataSet2.Tables[0].Rows[0]["ShippingTinVatNo"].ToString();
					txtInstractionOther.Text = dataSet2.Tables[0].Rows[0]["InstractionOther"].ToString();
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionPrimerPainting"]) > 0)
					{
						CKInstractionPrimerPainting.Checked = true;
					}
					else
					{
						CKInstractionPrimerPainting.Checked = false;
					}
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionPainting"]) > 0)
					{
						CKInstractionPainting.Checked = true;
					}
					else
					{
						CKInstractionPainting.Checked = false;
					}
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["InstractionSelfCertRept"]) > 0)
					{
						CKInstractionSelfCertRept.Checked = true;
					}
					else
					{
						CKInstractionSelfCertRept.Checked = false;
					}
					txtInstractionExportCaseMark.Text = dataSet2.Tables[0].Rows[0]["InstractionExportCaseMark"].ToString();
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

	public void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		TabContainer1.ActiveTabIndex = 2;
	}

	protected void DDLShippingCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void DDLShippingState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(DDLShippingCity, DDLShippingState);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void DDLShippingCity_SelectedIndexChanged(object sender, EventArgs e)
	{
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void btnTaskNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[1];
	}

	protected void btnShippingNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[2];
	}

	protected void btnProductNext_Click(object sender, EventArgs e)
	{
		TabContainer1.ActiveTab = TabContainer1.Tabs[3];
	}

	protected void btnTaskCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Delete.aspx?ModId=2&SubModId=13");
	}

	protected void btnShippingCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Delete.aspx?ModId=2&SubModId=13");
	}

	protected void btnProductCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Delete.aspx?ModId=2&SubModId=13");
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("WorkOrder_Delete.aspx?ModId=2&SubModId=13");
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string cmdText = fun.select("tblMM_SPR_Details.WONo", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.WONo='" + wono + "' And tblMM_SPR_Master.CompId='" + CompId + "'  And tblMM_SPR_Master.Id = tblMM_SPR_Details.MId");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string cmdText2 = fun.select("tblDG_BOM_Master.WONo", "tblDG_BOM_Master", "tblDG_BOM_Master.WONo='" + wono + "' And tblDG_BOM_Master.CompId='" + CompId + "'   ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			string cmdText3 = fun.select("tblDG_TPL_Master.WONo", "tblDG_TPL_Master", "tblDG_TPL_Master.WONo='" + wono + "' And tblDG_TPL_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter.Fill(dataSet3);
			string cmdText4 = fun.select("tblInv_MaterialReturn_Details.WONo", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Details.WONo='" + wono + "' AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'  And  tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter3.Fill(dataSet4);
			string cmdText5 = fun.select("tblInv_MaterialRequisition_Details.WONo", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Details.WONo='" + wono + "'   And tblInv_MaterialRequisition_Master.CompId='" + CompId + "'    And tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter4.Fill(dataSet5);
			if (dataSet.Tables[0].Rows.Count > 0 || dataSet3.Tables[0].Rows.Count > 0 || dataSet4.Tables[0].Rows.Count > 0 || dataSet5.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
			{
				string empty = string.Empty;
				empty = "WONo is in Use. you can not delete this WONo !";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				return;
			}
			string cmdText6 = fun.delete("SD_Cust_WorkOrder_Master", "WONo='" + wono + "' And CompId='" + CompId + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText6, con);
			sqlCommand.ExecuteNonQuery();
			string cmdText7 = fun.delete("SD_Cust_WorkOrder_Products_Details", "WONo='" + wono + "' And CompId='" + CompId + "' ");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText7, con);
			sqlCommand2.ExecuteNonQuery();
			Page.Response.Redirect("WorkOrder_Delete.aspx?ModId=2&SubModId=13");
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			string text = ((TextBox)gridViewRow.FindControl("txtDescription1")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtItemCode1")).Text;
			string text3 = ((TextBox)gridViewRow.FindControl("txtQty1")).Text;
			if (text != "" && text2 != "" && text3 != "")
			{
				SqlDataSource1.UpdateParameters["Description"].DefaultValue = text;
				SqlDataSource1.UpdateParameters["ItemCode"].DefaultValue = text2;
				SqlDataSource1.UpdateParameters["Qty"].DefaultValue = text3;
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblmsg.Text = "Record Updated Successfully";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblmsg.Text = "Record Deleted Successfully";
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}
}

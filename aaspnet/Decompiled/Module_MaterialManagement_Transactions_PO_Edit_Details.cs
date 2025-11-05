using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_PO_Edit_Details : Page, IRequiresSessionState
{
	protected Label lblpono;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected DropDownList DDLReference;

	protected Label LblAddress;

	protected TextBox txtRefDate;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtReferenceDesc;

	protected HtmlGenericControl Iframe1;

	protected TabPanel TabPanel1;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel TabPanel2;

	protected DropDownList DDLPaymentTerms;

	protected DropDownList DDLFreight;

	protected DropDownList DDLOctroi;

	protected DropDownList DDLWarrenty;

	protected TextBox txtInsurance;

	protected TextBox txtRemarks;

	protected TextBox TextBox1;

	protected TextBox txtShipTo;

	protected TextBox txtModeOfDispatch;

	protected TextBox txtInspection;

	protected FileUpload FileUpload1;

	protected Label lbldownload;

	protected ImageButton ImageButton1;

	protected SqlDataSource SqlDataSource1;

	protected Button btnProceed;

	protected Panel Panel2;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected Button Button2;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string SupCode = "";

	private string poNo = "";

	private string finyrsid = "";

	private string MId = "";

	private string itemid = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			SupCode = base.Request.QueryString["Code"].ToString();
			poNo = base.Request.QueryString["pono"].ToString();
			finyrsid = base.Request.QueryString["finyrsid"].ToString();
			MId = base.Request.QueryString["mid"].ToString();
			lblpono.Text = poNo;
			txtRefDate.Attributes.Add("readonly", "readonly");
			if (!Page.IsPostBack)
			{
				string connectionString = fun.Connection();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				string cmdText = "select * from tblMM_PO_Reference";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblMM_PO_Reference");
				DDLReference.DataSource = dataSet.Tables["tblMM_PO_Reference"];
				DDLReference.DataTextField = "RefDesc";
				DDLReference.DataValueField = "Id";
				DDLReference.DataBind();
				DDLReference.Items.Insert(0, "Select");
				string cmdText2 = "SELECT * FROM tblFreight_Master";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblFreight_Master");
				DDLFreight.DataSource = dataSet2.Tables["tblFreight_Master"];
				DDLFreight.DataTextField = "Terms";
				DDLFreight.DataValueField = "Id";
				DDLFreight.DataBind();
				DDLFreight.Items.Insert(0, "Select");
				string cmdText3 = "SELECT * FROM tblOctroi_Master";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblOctroi_Master");
				DDLOctroi.DataSource = dataSet3.Tables["tblOctroi_Master"];
				DDLOctroi.DataTextField = "Terms";
				DDLOctroi.DataValueField = "Id";
				DDLOctroi.DataBind();
				DDLOctroi.Items.Insert(0, "Select");
				string cmdText4 = "select Id,SUBSTRING(Terms, 1, 60) AS Terms from tblPayment_Master";
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblPayment_Master");
				DDLPaymentTerms.DataSource = dataSet4.Tables["tblPayment_Master"];
				DDLPaymentTerms.DataTextField = "Terms";
				DDLPaymentTerms.DataValueField = "Id";
				DDLPaymentTerms.DataBind();
				DDLPaymentTerms.Items.Insert(0, "Select");
				TabContainer1.OnClientActiveTabChanged = "OnChanged";
				TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
				Iframe1.Attributes.Add("src", "PO_Edit_Details_PO_Grid.aspx?mid=" + MId + "&pono=" + poNo + "&Code=" + SupCode);
				sqlConnection.Open();
				string cmdText5 = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + poNo + "' AND Id='" + MId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				DDLReference.SelectedValue = dataSet5.Tables[0].Rows[0]["Reference"].ToString();
				DDLPaymentTerms.SelectedValue = dataSet5.Tables[0].Rows[0]["PaymentTerms"].ToString();
				DDLFreight.SelectedValue = dataSet5.Tables[0].Rows[0]["Freight"].ToString();
				DDLOctroi.SelectedValue = dataSet5.Tables[0].Rows[0]["Octroi"].ToString();
				DDLWarrenty.SelectedValue = dataSet5.Tables[0].Rows[0]["Warrenty"].ToString();
				txtRefDate.Text = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["ReferenceDate"].ToString());
				txtReferenceDesc.Text = dataSet5.Tables[0].Rows[0]["ReferenceDesc"].ToString();
				txtShipTo.Text = dataSet5.Tables[0].Rows[0]["ShipTo"].ToString();
				txtInspection.Text = dataSet5.Tables[0].Rows[0]["Inspection"].ToString();
				txtModeOfDispatch.Text = dataSet5.Tables[0].Rows[0]["ModeOfDispatch"].ToString();
				txtRemarks.Text = dataSet5.Tables[0].Rows[0]["Remarks"].ToString();
				txtInsurance.Text = dataSet5.Tables[0].Rows[0]["Insurance"].ToString();
				StringBuilder stringBuilder = new StringBuilder();
				if (dataSet5.Tables[0].Rows[0]["TC"] != DBNull.Value)
				{
					stringBuilder.AppendLine(dataSet5.Tables[0].Rows[0]["TC"].ToString());
					TextBox1.Text = stringBuilder.ToString().Replace(Environment.NewLine, Environment.NewLine);
				}
				else
				{
					TextBox1.Text = "";
				}
				if (dataSet5.Tables[0].Rows[0]["FileName"] == DBNull.Value || dataSet5.Tables[0].Rows[0]["FileName"].ToString() == "")
				{
					FileUpload1.Visible = true;
					lbldownload.Visible = false;
					ImageButton1.Visible = false;
				}
				else
				{
					FileUpload1.Visible = false;
					lbldownload.Visible = true;
					ImageButton1.Visible = true;
					lbldownload.Text = "&nbsp;<a href='../../../Controls/DownloadFile.aspx?Id=" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "&tbl=tblMM_PO_Master&qfd=FileData&qfn=FileName&qct=ContentType'>" + dataSet5.Tables[0].Rows[0]["FileName"].ToString() + "</a>";
				}
				string cmdText6 = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_master", "SupplierId='" + SupCode + "' And CompId='" + CompId + "'");
				DataSet dataSet6 = new DataSet();
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				sqlDataAdapter6.Fill(dataSet6, "tblMM_Supplier_master");
				string text = dataSet6.Tables[0].Rows[0]["SupplierName"].ToString();
				txtNewCustomerName.Text = text + '[' + SupCode + ']';
				string cmdText7 = fun.select("CountryName", "tblcountry", string.Concat("CId='", dataSet6.Tables[0].Rows[0]["RegdCountry"], "'"));
				string cmdText8 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet6.Tables[0].Rows[0]["RegdState"], "'"));
				string cmdText9 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet6.Tables[0].Rows[0]["RegdCity"], "'"));
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet7 = new DataSet();
				DataSet dataSet8 = new DataSet();
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7, "tblCountry");
				sqlDataAdapter8.Fill(dataSet8, "tblState");
				sqlDataAdapter9.Fill(dataSet9, "tblcity");
				LblAddress.Text = dataSet6.Tables[0].Rows[0]["RegdAddress"].ToString() + ",<br>" + dataSet9.Tables[0].Rows[0]["CityName"].ToString() + "," + dataSet8.Tables[0].Rows[0]["StateName"].ToString() + ", " + dataSet7.Tables[0].Rows[0]["CountryName"].ToString() + ". " + dataSet6.Tables[0].Rows[0]["RegdPinNo"].ToString() + ".";
			}
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_Edit.aspx?Code=" + SupCode + "&ModId=6&SubModId=35");
	}

	public void LoadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AddDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PF", typeof(string)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExST", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblMM_PO_Amd_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND PONo='" + poNo + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string cmdText2 = fun.select("PRSPRFlag", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + poNo + "' AND Id='" + MId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText3 = fun.select("tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.PONo='" + poNo + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						string cmdText4 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Details.Qty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.Id='" + dataSet3.Tables[0].Rows[0]["PRId"].ToString() + "' AND tblMM_PR_Master.PRNo='" + dataSet3.Tables[0].Rows[0]["PRNo"].ToString() + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							itemid = dataSet4.Tables[0].Rows[0]["ItemId"].ToString();
						}
					}
				}
				else if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText5 = fun.select("tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.PONo='" + poNo + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "'AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.Qty", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Details.Id='" + dataSet5.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.SPRNo='" + dataSet5.Tables[0].Rows[0]["SPRNo"].ToString() + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							itemid = dataSet6.Tables[0].Rows[0]["ItemId"].ToString();
						}
					}
				}
				string cmdText7 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + itemid + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(itemid));
					dataRow[3] = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[4] = dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString();
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Rate"].ToString();
				string cmdText8 = fun.select("AccHead.Symbol AS Head", "AccHead", "AccHead.Id ='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["AHId"]) + "' ");
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				if (dataSet8.Tables[0].Rows.Count > 0)
				{
					dataRow[7] = dataSet8.Tables[0].Rows[0]["Head"].ToString();
				}
				dataRow[8] = decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N3");
				dataRow[9] = dataSet.Tables[0].Rows[i]["AddDesc"].ToString();
				string cmdText9 = fun.select("Terms", "tblPacking_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PF"]) + "'");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				if (dataSet9.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = dataSet9.Tables[0].Rows[0]["Terms"].ToString();
				}
				string cmdText10 = fun.select("Terms", "tblVAT_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["VAT"]) + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					dataRow[11] = dataSet10.Tables[0].Rows[0]["Terms"].ToString();
				}
				string cmdText11 = fun.select("Terms", "tblExciseser_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ExST"]) + "'");
				SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
				SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
				DataSet dataSet11 = new DataSet();
				sqlDataAdapter11.Fill(dataSet11);
				if (dataSet11.Tables[0].Rows.Count > 0)
				{
					dataRow[12] = dataSet11.Tables[0].Rows[0]["Terms"].ToString();
				}
				string value = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["DelDate"].ToString());
				dataRow[13] = value;
				dataTable.Rows.Add(dataRow);
			}
			dataTable.AcceptChanges();
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		LoadData();
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
				string cmdText = fun.delete("tblMM_PO_Amd_Temp", "Id='" + num + "' AND CompId='" + CompId + "' AND SessionId='" + sId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				LoadData();
			}
			catch (Exception)
			{
			}
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		new DataSet();
		try
		{
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			Convert.ToInt32(Session["finyear"]);
			string code = fun.getCode(txtNewCustomerName.Text);
			int num = 0;
			if (!(txtRefDate.Text != "") || !fun.DateValidation(txtRefDate.Text) || !(txtNewCustomerName.Text != ""))
			{
				return;
			}
			string cmdText = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + poNo + "' AND FinYearId='" + finyrsid + "' AND Id='" + MId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text = "";
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				text = (Convert.ToInt32(dataSet.Tables[0].Rows[0]["AmendmentNo"].ToString()) + 1).ToString();
				num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString());
			}
			else
			{
				text = "0";
			}
			int num2 = 0;
			string cmdText2 = fun.insert("tblMM_PO_Amd_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,POId,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Freight,Octroi,ModeOfDispatch,Inspection,Remarks,Checked,CheckedBy,CheckedDate,CheckedTime,Approve,ApprovedBy,ApproveDate,ApproveTime,Authorize,AuthorizedBy,AuthorizeDate,AuthorizeTime,ShipTo,AmendmentNo,Warrenty,Insurance,TC", "'" + dataSet.Tables[0].Rows[0]["SysDate"].ToString() + "','" + dataSet.Tables[0].Rows[0]["SysTime"].ToString() + "','" + dataSet.Tables[0].Rows[0]["SessionId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["CompId"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PRSPRFlag"]) + "','" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PONo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["SupplierId"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["Reference"]) + "','" + dataSet.Tables[0].Rows[0]["ReferenceDate"].ToString() + "','" + dataSet.Tables[0].Rows[0]["ReferenceDesc"].ToString() + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["PaymentTerms"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["Freight"]) + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["Octroi"]) + "','" + dataSet.Tables[0].Rows[0]["ModeOfDispatch"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Inspection"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Remarks"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Checked"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CheckedBy"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CheckedDate"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CheckedTime"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Approve"].ToString() + "','" + dataSet.Tables[0].Rows[0]["ApprovedBy"].ToString() + "','" + dataSet.Tables[0].Rows[0]["ApproveDate"].ToString() + "','" + dataSet.Tables[0].Rows[0]["ApproveTime"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Authorize"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AuthorizedBy"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AuthorizeDate"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AuthorizeTime"].ToString() + "','" + dataSet.Tables[0].Rows[0]["ShipTo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Warrenty"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Insurance"].ToString() + "','" + dataSet.Tables[0].Rows[0]["TC"].ToString() + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText3 = fun.select("AmendmentNo,Id", "tblMM_PO_Amd_Master", "CompId='" + CompId + "' order by Id desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				num2 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]);
			}
			if (FileUpload1.Visible)
			{
				string text2 = "";
				HttpPostedFile postedFile = FileUpload1.PostedFile;
				byte[] array = null;
				if (FileUpload1.PostedFile != null)
				{
					Stream inputStream = FileUpload1.PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array = binaryReader.ReadBytes((int)inputStream.Length);
					text2 = Path.GetFileName(postedFile.FileName);
					string cmdText4 = fun.update("tblMM_PO_Master", "FileName='" + text2 + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData=@Data", "CompId='" + CompId + "' AND FinYearId='" + finyrsid + "' AND PONo='" + poNo + "' AND Id='" + num + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand2.Parameters.AddWithValue("@Data", array);
					sqlCommand2.ExecuteNonQuery();
				}
			}
			string text3 = fun.FromDate(txtRefDate.Text);
			string cmdText5 = fun.update("tblMM_PO_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + sId + "',Reference='" + DDLReference.SelectedValue + "',ReferenceDate='" + text3 + "',ReferenceDesc='" + txtReferenceDesc.Text + "',PaymentTerms='" + DDLPaymentTerms.SelectedValue + "',Freight='" + DDLFreight.SelectedValue + "',Octroi='" + DDLOctroi.SelectedValue + "',Warrenty='" + DDLWarrenty.SelectedValue + "',ModeOfDispatch='" + txtModeOfDispatch.Text + "',Inspection='" + txtInspection.Text + "',Remarks='" + txtRemarks.Text + "',ShipTo='" + txtShipTo.Text + "',AmendmentNo='" + text + "',Authorize ='0',AuthorizedBy =NULL,AuthorizeDate=NULL,AuthorizeTime=NULL,SupplierId='" + code + "',Insurance='" + txtInsurance.Text + "',TC='" + TextBox1.Text + "'", "CompId='" + CompId + "' AND FinYearId='" + finyrsid + "' AND PONo='" + poNo + "' AND Id='" + num + "'");
			SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
			sqlCommand3.ExecuteNonQuery();
			string cmdText6 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.BudgetCode,tblMM_PO_Details.PONo,tblMM_PO_Details.MId,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.AddDesc,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Details.DelDate,tblMM_PO_Details.AmendmentNo", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Master.Id='" + MId + "' AND  CompId='" + CompId + "' AND FinYearId='" + finyrsid + "' ");
			SqlCommand selectCommand3 = new SqlCommand(cmdText6, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
			{
				string cmdText7 = fun.select("*", "tblMM_PO_Amd_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND POId='" + Convert.ToInt32(dataSet3.Tables[0].Rows[i]["Id"]) + "' ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string empty = string.Empty;
				string cmdText8 = fun.insert("tblMM_PO_Amd_Details", "MId,PONo,PRNo,PRId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,AmendmentNo,BudgetCode,PODId", "'" + num2 + "','" + dataSet3.Tables[0].Rows[i]["PONo"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["PRNo"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["PRId"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["SPRNo"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["SPRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "','" + dataSet3.Tables[0].Rows[i]["Rate"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["Discount"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["AddDesc"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["PF"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["ExST"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["VAT"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["DelDate"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["AmendmentNo"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["BudgetCode"].ToString() + "','" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText8, sqlConnection);
				sqlCommand4.ExecuteNonQuery();
				if (dataSet4.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText9 = "";
				if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					cmdText9 = fun.update("tblMM_PR_Details", "AHId='" + dataSet4.Tables[0].Rows[0]["AHId"].ToString() + "'", " Id='" + dataSet3.Tables[0].Rows[i]["PRId"].ToString() + "'");
					if (Convert.ToInt32(dataSet4.Tables[0].Rows[0]["RateFlag"]) == 1)
					{
						string cmdText10 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,PONo,POId,PRId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + finyrsid + "','" + sId + "','" + itemid + "','" + dataSet4.Tables[0].Rows[0]["Rate"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["Discount"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["PF"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["ExST"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["VAT"].ToString() + "','" + text + "','" + dataSet3.Tables[0].Rows[i]["PONo"].ToString() + "','" + num + "','" + dataSet3.Tables[0].Rows[i]["PRId"].ToString() + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText10, sqlConnection);
						sqlCommand5.ExecuteNonQuery();
						string cmdText11 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2',LockedbyTranaction='" + sId + "',LockDate='" + currDate + "',LockTime='" + currTime + "'", "ItemId='" + itemid + "' AND CompId='" + CompId + "'");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText11, sqlConnection);
						sqlCommand6.ExecuteNonQuery();
					}
				}
				else if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					cmdText9 = fun.update("tblMM_SPR_Details", "AHId='" + dataSet4.Tables[0].Rows[0]["AHId"].ToString() + "'", "Id='" + dataSet3.Tables[0].Rows[i]["SPRId"].ToString() + "'");
					if (Convert.ToInt32(dataSet4.Tables[0].Rows[0]["RateFlag"]) == 1)
					{
						string cmdText12 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,PONo,POId,SPRId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + finyrsid + "','" + sId + "','" + itemid + "','" + dataSet4.Tables[0].Rows[0]["Rate"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["Discount"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["PF"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["ExST"].ToString() + "','" + dataSet4.Tables[0].Rows[0]["VAT"].ToString() + "','" + text + "','" + dataSet3.Tables[0].Rows[i]["PONo"].ToString() + "','" + num + "','" + dataSet3.Tables[0].Rows[i]["SPRId"].ToString() + "'");
						SqlCommand sqlCommand7 = new SqlCommand(cmdText12, sqlConnection);
						sqlCommand7.ExecuteNonQuery();
						string cmdText13 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2',LockedbyTranaction='" + sId + "',LockDate='" + currDate + "',LockTime='" + currTime + "'", "ItemId='" + itemid + "' AND CompId='" + CompId + "'");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText13, sqlConnection);
						sqlCommand8.ExecuteNonQuery();
					}
				}
				SqlCommand sqlCommand9 = new SqlCommand(cmdText9, sqlConnection);
				sqlCommand9.ExecuteNonQuery();
				empty = fun.update("tblMM_PO_Details", "Qty='" + dataSet4.Tables[0].Rows[0]["Qty"].ToString() + "',Rate='" + dataSet4.Tables[0].Rows[0]["Rate"].ToString() + "',Discount='" + dataSet4.Tables[0].Rows[0]["Discount"].ToString() + "',AddDesc='" + dataSet4.Tables[0].Rows[0]["AddDesc"].ToString() + "',PF='" + dataSet4.Tables[0].Rows[0]["PF"].ToString() + "',ExST='" + dataSet4.Tables[0].Rows[0]["ExST"].ToString() + "',VAT='" + dataSet4.Tables[0].Rows[0]["VAT"].ToString() + "',DelDate='" + dataSet4.Tables[0].Rows[0]["DelDate"].ToString() + "',AmendmentNo='" + text + "',BudgetCode='" + dataSet4.Tables[0].Rows[0]["BudgetCode"].ToString() + "'", "PONo='" + poNo + "' AND Id='" + dataSet3.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand sqlCommand10 = new SqlCommand(empty, sqlConnection);
				sqlCommand10.ExecuteNonQuery();
			}
			string cmdText14 = fun.delete("tblMM_PO_Amd_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand sqlCommand11 = new SqlCommand(cmdText14, sqlConnection);
			sqlCommand11.ExecuteNonQuery();
			sqlConnection.Close();
			base.Response.Redirect("PO_Edit.aspx?Code=" + SupCode + "&ModId=6&SubModId=35");
		}
		catch (Exception)
		{
		}
	}

	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblMM_PO_Master", "FileName=NULL,FileSize=NULL,ContentType=NULL,FileData=NULL", "CompId='" + CompId + "' AND FinYearId='" + finyrsid + "' AND PONo='" + poNo + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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
}

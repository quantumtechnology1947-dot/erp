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

public class Module_Machinery_Masters_Machinery_Edit_Details : Page, IRequiresSessionState
{
	protected Label lblItemCode;

	protected Label lblunit;

	protected Label lblManfDesc;

	protected TextBox txtModel;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtMake;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected TextBox txtPurchaseDate;

	protected CalendarExtender txtPurchaseDate_CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtCapacity;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtCost;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected RegularExpressionValidator RegularExpressionValidator6;

	protected TextBox txtSupplierName;

	protected AutoCompleteExtender txtSupplierName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtLifeDate;

	protected CalendarExtender txtLifeDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegLifeDate;

	protected TextBox txtWarrantyExpireson;

	protected CalendarExtender txtWarrantyExpireson_CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected RegularExpressionValidator RegularExpressionValidator3;

	protected RadioButtonList RadiobtnInsurance;

	protected Label lblInsuranceExpireson;

	protected Label lblcolon;

	protected TextBox txtInsuranceExpiresOn;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator ReqInsuranceExpire;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected TextBox txtPutToUse;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected RegularExpressionValidator RegularExpressionValidator5;

	protected TextBox txtReceivedDate;

	protected CalendarExtender txtReceivedDate_CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtIncharge;

	protected AutoCompleteExtender txtIncharge_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtLocation;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected FileUpload FileUpload1;

	protected Label lbldownload;

	protected ImageButton ImageButton1;

	protected TextBox txtPreMaintInDays;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected UpdatePanel Up;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected GridView GridView4;

	protected GridView GridView6;

	protected Button btnProcessAdd;

	protected Label lblprocessmsg;

	protected UpdatePanel pnlData;

	protected TabPanel TabPanel2;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSubCategory;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected GridView GridView3;

	protected GridView GridView5;

	protected Button btnSpareAdd;

	protected Label lblsparemsg;

	protected UpdatePanel UpdatePanel2;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected Button btnProceed;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int itemId;

	private int FYId;

	private int MasterId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string value = base.Request.QueryString["Id"];
			itemId = Convert.ToInt32(value);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			con.Open();
			string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic, tblDG_Item_Master.ItemCode ", " tblDG_Category_Master,tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId AND Unit_Master.Id=tblDG_Item_Master.UOMBasic  AND tblDG_Item_Master.Id='" + itemId + "' AND tblDG_Item_Master.CompId='" + CompId + "'  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblItemCode.Text = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				lblunit.Text = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
				lblManfDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
			}
			EnableDisableInsurance();
			ValidateTextBox();
			string cmdText2 = fun.select("Id,FinYearId", "tblMS_Master", "CompId='" + CompId + "' AND ItemId='" + itemId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				MasterId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]);
				FYId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["FinYearId"]);
			}
			if (!base.IsPostBack)
			{
				fun.drpDesignCategory(DrpCategory, DrpSubCategory);
				fillProcess();
				string selectedValue = DrpCategory.SelectedValue;
				string selectedValue2 = DrpSubCategory.SelectedValue;
				string selectedValue3 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
				ValidateTextBox();
				LoadDataSpare();
				LoadDataSpareMaster();
				LoadProcess();
				LoadProcessMaster();
				string cmdText3 = fun.select("*", "tblMS_Master", " ItemId='" + itemId + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'  ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					txtModel.Text = dataSet3.Tables[0].Rows[0]["Model"].ToString();
					txtPurchaseDate.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["PurchaseDate"].ToString());
					txtLifeDate.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["LifeDate"].ToString());
					txtPutToUse.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["Puttouse"].ToString());
					txtWarrantyExpireson.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["WarrantyExpiryDate"].ToString());
					txtReceivedDate.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["ReceivedDate"].ToString());
					txtInsuranceExpiresOn.Text = "";
					txtCost.Text = dataSet3.Tables[0].Rows[0]["Cost"].ToString();
					string cmdText4 = fun.select("EmployeeName+' ['+EmpId+']' ", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet3.Tables[0].Rows[0]["Incharge"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					DataSet dataSet4 = new DataSet();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					sqlDataAdapter4.Fill(dataSet4, "tblHR_OfficeStaff");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						txtIncharge.Text = dataSet4.Tables[0].Rows[0][0].ToString();
					}
					txtMake.Text = dataSet3.Tables[0].Rows[0]["Make"].ToString();
					txtCapacity.Text = dataSet3.Tables[0].Rows[0]["Capacity"].ToString();
					string cmdText5 = fun.select("SupplierName +' ['+SupplierId+']'", "tblMM_Supplier_master", "CompId='" + CompId + "' And SupplierId='" + dataSet3.Tables[0].Rows[0]["SupplierName"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					DataSet dataSet5 = new DataSet();
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					sqlDataAdapter5.Fill(dataSet5, "tblMM_Supplier_master");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						txtSupplierName.Text = dataSet5.Tables[0].Rows[0][0].ToString();
					}
					txtLocation.Text = dataSet3.Tables[0].Rows[0]["Location"].ToString();
					txtPreMaintInDays.Text = dataSet3.Tables[0].Rows[0]["PMDays"].ToString();
					RadiobtnInsurance.SelectedValue = dataSet3.Tables[0].Rows[0]["Insurance"].ToString();
					if (RadiobtnInsurance.SelectedValue == "1")
					{
						EnableDisableInsurance();
						txtInsuranceExpiresOn.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["InsuranceExpiryDate"].ToString());
					}
					if (dataSet3.Tables[0].Rows[0]["FileName"] == DBNull.Value || dataSet3.Tables[0].Rows[0]["FileName"].ToString() == "")
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
						lbldownload.Text = "&nbsp;<a href='../../../Controls/DownloadFile.aspx?Id=" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "&tbl=tblMS_Master&qfd=FileData&qfn=FileName&qct=ContentType'>" + dataSet3.Tables[0].Rows[0]["FileName"].ToString() + "</a>";
					}
				}
			}
			if (base.Request.QueryString["m"] != null)
			{
				TabContainer1.ActiveTabIndex = 1;
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

	public void LoadDataSpare()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblMS_Spares_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' Order By Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master,vw_Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[2] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void LoadDataSpareMaster()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("tblMS_Spares.Id,tblMS_Spares.MId,tblMS_Spares.ItemId,tblMS_Spares.Qty", "tblMS_Spares,tblMS_Master", " tblMS_Spares.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' order By tblMS_Spares.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master,vw_Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[2] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView5.DataSource = dataTable;
			GridView5.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void LoadProcess()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblMS_Process_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' Order By Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["PId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("'['+Symbol+'] '+ProcessName As Pro,Id", "tblPln_Process_Master", "Symbol!='0' And Id='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["Pro"].ToString();
					}
				}
				dataRow[1] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView4.DataSource = dataTable;
			GridView4.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void LoadProcessMaster()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("tblMS_Process.PId,tblMS_Process.Id", "tblMS_Process,tblMS_Master", "tblMS_Master.CompId='" + CompId + "' AND tblMS_Master.SessionId='" + sId + "' And tblMS_Process.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' Order By tblMS_Process.Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["PId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("'['+Symbol+'] '+ProcessName As Pro,Id", "tblPln_Process_Master", "Symbol!='0' And Id='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet2.Tables[0].Rows[0]["Pro"].ToString();
					}
				}
				dataRow[1] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView6.DataSource = dataTable;
			GridView6.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		LoadDataSpare();
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				con.Open();
				string cmdText = fun.delete("tblMS_Spares_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				LoadDataSpare();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView4.PageIndex = e.NewPageIndex;
		LoadProcess();
	}

	protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				con.Open();
				string cmdText = fun.delete("tblMS_Process_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				LoadProcess();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Masters/Machinery_Edit.aspx?ModId=15&SubModId=67");
	}

	public void fillProcess()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("'['+Symbol+'] '+ProcessName As Pro,Id", "tblPln_Process_Master", "Symbol!='0'");
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void uncheckBox()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			((CheckBox)row.FindControl("chk")).Checked = false;
		}
	}

	public void uncheckBoxSpare()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			((CheckBox)row.FindControl("chkSpare")).Checked = false;
			((TextBox)row.FindControl("txtQty")).Text = "";
		}
	}

	public void Fillgridview(string sd, string A, string B, string s)
	{
		try
		{
			string text = "";
			string text2 = "";
			if (sd != "Select Category")
			{
				string text3 = "";
				if (A != "Select SubCategory")
				{
					text3 = "  And tblDG_Item_Master.SCId='" + A + "'";
				}
				text2 = " AND  tblDG_Item_Master.CId='" + sd + "'";
				string text4 = "";
				txtSearchItemCode.Visible = true;
				if (B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						text4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				text = fun.select("tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", " tblDG_Category_Master,tblDG_Item_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId " + text2 + text3 + text4 + " AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1' And tblDG_Item_Master.Id!='" + itemId + "' Order By tblDG_Item_Master.Id Desc");
			}
			else
			{
				text = fun.select(" tblDG_Item_Master.Id,SUBSTRING(tblDG_Item_Master.ManfDesc,0,80)+'...' AS ManfDesc ,tblDG_Item_Master.StockQty, tblDG_Item_Master.ItemCode,tblDG_Item_Master.Location,tblDG_Item_Master.UOMBasic", "tblDG_Category_Master,tblDG_Item_Master", "tblDG_Item_Master.CId=tblDG_Category_Master.CId AND tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.Absolute!='1'And tblDG_Item_Master.Id!='" + itemId + "' Order By tblDG_Item_Master.Id Desc");
			}
			fillGrid(text, GridView2);
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid(string sql, GridView GridView2)
	{
		string connectionString = fun.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(string));
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("Location", typeof(string));
			dataTable.Columns.Add("Qty", typeof(string));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				string cmdText = fun.select("Symbol ", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[i]["UOMBasic"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				}
				int num = 0;
				if (dataSet.Tables[0].Rows[i]["Location"] != DBNull.Value && dataSet.Tables[0].Rows[i]["Location"].ToString() != "")
				{
					num = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Location"]);
					string cmdText2 = fun.select("LocationLabel+'-'+LocationNo As Loc ", " tblDG_Location_Master ", " Id='" + num + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						if (dataSet3.Tables[0].Rows[0]["Loc"] != DBNull.Value && dataSet3.Tables[0].Rows[0]["Loc"].ToString() != "")
						{
							dataRow[4] = dataSet3.Tables[0].Rows[0]["Loc"].ToString();
						}
						else
						{
							dataRow[4] = "NA";
						}
					}
					else
					{
						dataRow[4] = "NA";
					}
					dataRow[5] = dataSet.Tables[0].Rows[i]["StockQty"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory.SelectedValue != "Select Category")
			{
				SqlCommand selectCommand = new SqlCommand(fun.select(" CId,SCId,Symbol+' - '+SCName As SubCatName ", "tblDG_SubCategory_Master ", " CId=" + DrpCategory.SelectedValue), con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblDG_SubCategory_Master");
				DrpSubCategory.DataSource = dataSet.Tables["tblDG_SubCategory_Master"];
				DrpSubCategory.DataTextField = "SubCatName";
				DrpSubCategory.DataValueField = "SCId";
				DrpSubCategory.DataBind();
				DrpSubCategory.Items.Insert(0, "Select SubCategory");
				string selectedValue = DrpCategory.SelectedValue;
				string selectedValue2 = DrpSubCategory.SelectedValue;
				string selectedValue3 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
				DrpSubCategory.SelectedIndex = 0;
				DrpSearchCode.SelectedIndex = 0;
				txtSearchItemCode.Text = "";
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			DrpSearchCode.SelectedValue = "Select";
		}
	}

	protected void DrpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
		}
		catch (Exception)
		{
		}
		finally
		{
			DrpSearchCode.SelectedValue = "Select";
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSubCategory.SelectedValue;
			string selectedValue3 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			Fillgridview(selectedValue, selectedValue2, selectedValue3, text);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSpareAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		ValidateTextBox();
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((CheckBox)row.FindControl("chkSpare")).Checked && ((TextBox)row.FindControl("txtQty")).Text != "" && fun.NumberValidation(((TextBox)row.FindControl("txtQty")).Text))
			{
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				double num3 = Convert.ToDouble(((TextBox)row.FindControl("txtQty")).Text);
				string cmdText = fun.insert("tblMS_Spares_Temp", "CompId,SessionId,ItemId,Qty", "'" + CompId + "','" + sId + "','" + num2 + "','" + num3 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				num++;
			}
		}
		if (num > 0)
		{
			uncheckBoxSpare();
			LoadDataSpare();
			lblsparemsg.Visible = false;
		}
	}

	protected void btnProcessAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("chk")).Checked)
			{
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblProId")).Text);
				string cmdText = fun.insert("tblMS_Process_Temp", "CompId,SessionId,PId", "'" + CompId + "','" + sId + "','" + num2 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				num++;
			}
		}
		if (num > 0)
		{
			uncheckBox();
			LoadProcess();
			lblprocessmsg.Visible = false;
		}
	}

	public void ValidateTextBox()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((CheckBox)row.FindControl("chkSpare")).Checked && ((TextBox)row.FindControl("txtQty")).Text == "")
			{
				((RequiredFieldValidator)row.FindControl("ReqQty")).Visible = true;
			}
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
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

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = 0;
			string code = fun.getCode(txtIncharge.Text);
			string code2 = fun.getCode(txtSupplierName.Text);
			if (FileUpload1.Visible)
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
					string cmdText = fun.update("tblMS_Master", "FileName='" + text + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData=@Data", "CompId='" + CompId + "' AND FinYearId='" + FYId + "' AND ItemId='" + itemId + "' AND Id='" + MasterId + "' ");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@Data", array);
					sqlCommand.ExecuteNonQuery();
				}
			}
			string cmdText2 = fun.select("*", "tblMS_Spares_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string cmdText3 = fun.select("*", "tblMS_Process_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			string cmdText4 = fun.select("tblMS_Spares.Id,tblMS_Spares.MId,tblMS_Spares.ItemId,tblMS_Spares.Qty", "tblMS_Spares,tblMS_Master", " tblMS_Spares.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			string cmdText5 = fun.select("tblMS_Process.PId,tblMS_Process.Id", "tblMS_Process,tblMS_Master", "tblMS_Master.CompId='" + CompId + "' AND tblMS_Master.SessionId='" + sId + "' And tblMS_Process.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' Order By tblMS_Process.Id desc");
			SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			if ((dataSet2.Tables[0].Rows.Count > 0 || dataSet4.Tables[0].Rows.Count > 0) && (dataSet.Tables[0].Rows.Count > 0 || dataSet3.Tables[0].Rows.Count > 0))
			{
				if (RadiobtnInsurance.SelectedValue == "1")
				{
					if (txtModel.Text != "" && txtPurchaseDate.Text != "" && fun.DateValidation(txtPurchaseDate.Text) && txtLifeDate.Text != "" && fun.DateValidation(txtLifeDate.Text) && txtPutToUse.Text != "" && fun.DateValidation(txtPutToUse.Text) && txtWarrantyExpireson.Text != "" && fun.DateValidation(txtWarrantyExpireson.Text) && txtReceivedDate.Text != "" && fun.DateValidation(txtReceivedDate.Text) && txtInsuranceExpiresOn.Text != "" && fun.DateValidation(txtInsuranceExpiresOn.Text) && txtCost.Text != "" && txtIncharge.Text != "" && txtMake.Text != "" && txtCapacity.Text != "" && txtSupplierName.Text != "" && txtLocation.Text != "" && txtPreMaintInDays.Text != "")
					{
						string cmdText6 = fun.update("tblMS_Master", "SysDate='" + currDate + "', SysTime='" + currTime + "', SessionId='" + sId + "', Make='" + txtMake.Text + "' , Model='" + txtModel.Text + "' , Capacity='" + txtCapacity.Text + "' , PurchaseDate='" + fun.FromDate(txtPurchaseDate.Text) + "', SupplierName='" + code2 + "' , Cost='" + Convert.ToDouble(txtCost.Text) + "', WarrantyExpiryDate='" + fun.FromDate(txtWarrantyExpireson.Text) + "', LifeDate='" + fun.FromDate(txtLifeDate.Text) + "', ReceivedDate='" + fun.FromDate(txtReceivedDate.Text) + "', Insurance='" + RadiobtnInsurance.SelectedValue + "', InsuranceExpiryDate='" + fun.FromDate(txtInsuranceExpiresOn.Text) + "' , Puttouse='" + fun.FromDate(txtPutToUse.Text) + "', Incharge='" + code + "', Location='" + txtLocation.Text + "', PMDays='" + txtPreMaintInDays.Text + "' ", " ItemId='" + itemId + "' AND Id='" + MasterId + "' AND CompId='" + CompId + "' AND  FinYearId='" + FYId + "' ");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText6, sqlConnection);
						sqlCommand2.ExecuteNonQuery();
						for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
						{
							string cmdText7 = fun.insert("tblMS_Process", "MId,PId", "'" + MasterId + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["PId"]) + "'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText7, sqlConnection);
							sqlCommand3.ExecuteNonQuery();
						}
						for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
						{
							string cmdText8 = fun.insert("tblMS_Spares", "MId,ItemId,Qty", "'" + MasterId + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[j]["ItemId"]) + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[j]["Qty"]) + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText8, sqlConnection);
							sqlCommand4.ExecuteNonQuery();
						}
						string cmdText9 = " delete from  tblMS_Process_Temp ";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText9, sqlConnection);
						sqlCommand5.ExecuteNonQuery();
						string cmdText10 = "delete from tblMS_Spares_Temp";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText10, sqlConnection);
						sqlCommand6.ExecuteNonQuery();
						num++;
					}
				}
				else if (txtModel.Text != "" && txtPurchaseDate.Text != "" && fun.DateValidation(txtPurchaseDate.Text) && txtLifeDate.Text != "" && fun.DateValidation(txtLifeDate.Text) && txtPutToUse.Text != "" && fun.DateValidation(txtPutToUse.Text) && txtWarrantyExpireson.Text != "" && fun.DateValidation(txtWarrantyExpireson.Text) && txtReceivedDate.Text != "" && fun.DateValidation(txtReceivedDate.Text) && fun.DateValidation(txtInsuranceExpiresOn.Text) && txtCost.Text != "" && txtIncharge.Text != "" && txtMake.Text != "" && txtCapacity.Text != "" && txtSupplierName.Text != "" && txtLocation.Text != "" && txtPreMaintInDays.Text != "")
				{
					string text2 = "";
					string cmdText11 = fun.update("tblMS_Master", "SysDate='" + currDate + "', SysTime='" + currTime + "', SessionId='" + sId + "', Make='" + txtMake.Text + "' , Model='" + txtModel.Text + "' , Capacity='" + txtCapacity.Text + "' , PurchaseDate='" + fun.FromDate(txtPurchaseDate.Text) + "', SupplierName='" + code2 + "' , Cost='" + Convert.ToDouble(txtCost.Text) + "', WarrantyExpiryDate='" + fun.FromDate(txtWarrantyExpireson.Text) + "', LifeDate='" + fun.FromDate(txtLifeDate.Text) + "', ReceivedDate='" + fun.FromDate(txtReceivedDate.Text) + "', Insurance='" + RadiobtnInsurance.SelectedValue + "', InsuranceExpiryDate='" + text2 + "' , Puttouse='" + fun.FromDate(txtPutToUse.Text) + "', Incharge='" + code + "', Location='" + txtLocation.Text + "', PMDays='" + txtPreMaintInDays.Text + "' ", " ItemId='" + itemId + "' AND Id='" + MasterId + "' AND CompId='" + CompId + "' AND  FinYearId='" + FYId + "' ");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText11, sqlConnection);
					sqlCommand7.ExecuteNonQuery();
					for (int k = 0; k < dataSet2.Tables[0].Rows.Count; k++)
					{
						string cmdText12 = fun.insert("tblMS_Process", "MId,PId", "'" + MasterId + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[k]["PId"]) + "'");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText12, sqlConnection);
						sqlCommand8.ExecuteNonQuery();
					}
					for (int l = 0; l < dataSet.Tables[0].Rows.Count; l++)
					{
						string cmdText13 = fun.insert("tblMS_Spares", "MId,ItemId,Qty", "'" + MasterId + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[l]["ItemId"]) + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[l]["Qty"]) + "'");
						SqlCommand sqlCommand9 = new SqlCommand(cmdText13, sqlConnection);
						sqlCommand9.ExecuteNonQuery();
					}
					string cmdText14 = " delete from  tblMS_Process_Temp ";
					SqlCommand sqlCommand10 = new SqlCommand(cmdText14, sqlConnection);
					sqlCommand10.ExecuteNonQuery();
					string cmdText15 = "delete from tblMS_Spares_Temp";
					SqlCommand sqlCommand11 = new SqlCommand(cmdText15, sqlConnection);
					sqlCommand11.ExecuteNonQuery();
					num++;
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Functionality and spare details are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num > 0)
			{
				base.Response.Redirect("~/Module/Machinery/Masters/Machinery_Edit.aspx?ModId=15&SubModId=67");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadiobtnInsurance_SelectedIndexChanged(object sender, EventArgs e)
	{
		EnableDisableInsurance();
	}

	public void EnableDisableInsurance()
	{
		if (RadiobtnInsurance.SelectedValue == "1")
		{
			ReqInsuranceExpire.Visible = true;
			lblInsuranceExpireson.Visible = true;
			lblcolon.Visible = true;
			txtInsuranceExpiresOn.Visible = true;
		}
		else
		{
			ReqInsuranceExpire.Visible = false;
			lblInsuranceExpireson.Visible = false;
			lblcolon.Visible = false;
			txtInsuranceExpiresOn.Visible = false;
		}
	}

	protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView5.PageIndex = e.NewPageIndex;
		LoadDataSpareMaster();
	}

	protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				con.Open();
				string cmdText = fun.select("tblMS_Spares.Id,tblMS_Spares.MId,tblMS_Spares.ItemId,tblMS_Spares.Qty", "tblMS_Spares,tblMS_Master", " tblMS_Spares.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' order By tblMS_Spares.Id Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 1)
				{
					string cmdText2 = fun.delete("tblMS_Spares", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					sqlCommand.ExecuteNonQuery();
					con.Close();
					LoadDataSpareMaster();
				}
				else
				{
					lblsparemsg.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView6.PageIndex = e.NewPageIndex;
		LoadProcessMaster();
	}

	protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				sId = Session["username"].ToString();
				CompId = Convert.ToInt32(Session["compid"]);
				con.Open();
				string cmdText = fun.select("tblMS_Process.PId,tblMS_Process.Id", "tblMS_Process,tblMS_Master", "tblMS_Master.CompId='" + CompId + "' AND tblMS_Master.SessionId='" + sId + "' And tblMS_Process.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' Order By tblMS_Process.Id desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 1)
				{
					string cmdText2 = fun.delete("tblMS_Process", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					sqlCommand.ExecuteNonQuery();
					con.Close();
					LoadProcessMaster();
				}
				else
				{
					lblprocessmsg.Visible = true;
				}
			}
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
			string cmdText = fun.update("tblMS_Master", "FileName=NULL,FileSize=NULL,ContentType=NULL,FileData=NULL", "CompId='" + CompId + "' AND FinYearId='" + FYId + "' AND ItemId='" + itemId + "'");
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

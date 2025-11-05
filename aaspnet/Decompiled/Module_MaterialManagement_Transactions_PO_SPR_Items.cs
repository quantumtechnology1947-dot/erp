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

public class Module_MaterialManagement_Transactions_PO_SPR_Items : Page, IRequiresSessionState
{
	protected Label lblSupplierName;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected DropDownList DDLReference;

	protected SqlDataSource SqlDataSource4;

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

	protected SqlDataSource SqlDataSource2;

	protected DropDownList DDLFreight;

	protected SqlDataSource SqlDataSource5;

	protected DropDownList DDLOctroi;

	protected SqlDataSource SqlDataSource3;

	protected DropDownList drpwarrenty;

	protected SqlDataSource SqlDataSource1;

	protected TextBox txtInsurance;

	protected TextBox txtRemarks;

	protected TextBox TextBox1;

	protected TextBox txtShipTo;

	protected TextBox txtModeOfDispatch;

	protected TextBox txtInspection;

	protected FileUpload FileUpload1;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected Button btnProceed;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private CalBalBudgetAmt calbalbud = new CalBalBudgetAmt();

	private string sId = string.Empty;

	private string SupCode = string.Empty;

	private int CompId;

	private int FinYearId;

	private string str = string.Empty;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			SupCode = base.Request.QueryString["Code"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			con.Open();
			txtRefDate.Attributes.Add("readonly", "readonly");
			if (!Page.IsPostBack)
			{
				TabContainer1.OnClientActiveTabChanged = "OnChanged";
				TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
				string text = fun.CompAdd(CompId);
				txtShipTo.Text = text;
				string cmdText = fun.select("SupplierName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "tblMM_Supplier_master", "SupplierId='" + SupCode + "' And CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				string text2 = sqlDataReader["SupplierName"].ToString();
				txtNewCustomerName.Text = text2 + '[' + SupCode + ']';
				string cmdText2 = fun.select("CountryName", "tblcountry", string.Concat("CId='", sqlDataReader["RegdCountry"], "'"));
				string cmdText3 = fun.select("StateName", "tblState", string.Concat("SId='", sqlDataReader["RegdState"], "'"));
				string cmdText4 = fun.select("CityName", "tblCity", string.Concat("CityId='", sqlDataReader["RegdCity"], "'"));
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				LblAddress.Text = sqlDataReader["RegdAddress"].ToString() + ",<br>" + sqlDataReader4["CityName"].ToString() + "," + sqlDataReader3["StateName"].ToString() + ", " + sqlDataReader2["CountryName"].ToString() + ". " + sqlDataReader["RegdPinNo"].ToString() + ".";
			}
			Iframe1.Attributes.Add("src", "PO_SPR_ItemGrid.aspx?Code=" + SupCode);
			string cmdText5 = fun.select1("Terms", " tbl_PO_terms");
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
			SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
			StringBuilder stringBuilder = new StringBuilder();
			while (sqlDataReader5.Read())
			{
				if (sqlDataReader5.HasRows)
				{
					stringBuilder.AppendLine(sqlDataReader5[0].ToString());
				}
			}
			TextBox1.Text = stringBuilder.ToString().Replace(Environment.NewLine, Environment.NewLine);
			con.Close();
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_new.aspx?ModId=6&SubModId=35");
	}

	public void LoadData()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SPRNo", typeof(string)));
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
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BasicAmt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DiscAmt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TaxAmt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotalAmt", typeof(string)));
			string cmdText = fun.select("*", "tblMM_SPR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.AHId", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + Convert.ToInt32(sqlDataReader["SPRId"].ToString()) + "'AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				string cmdText3 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOM", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(sqlDataReader2["ItemId"].ToString()) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				dataRow[0] = sqlDataReader["SPRNo"].ToString();
				dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader2["ItemId"].ToString()));
				dataRow[2] = sqlDataReader3["ManfDesc"].ToString();
				dataRow[3] = sqlDataReader3["UOM"].ToString();
				dataRow[4] = decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3");
				dataRow[5] = decimal.Parse(sqlDataReader["Rate"].ToString()).ToString("N2");
				if (sqlDataReader2.HasRows)
				{
					string cmdText4 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(sqlDataReader2["AHId"].ToString()) + "' ");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					if (sqlDataReader4.HasRows)
					{
						dataRow[6] = sqlDataReader4["Head"].ToString();
					}
				}
				dataRow[7] = decimal.Parse(sqlDataReader["Discount"].ToString()).ToString("N2");
				dataRow[8] = sqlDataReader["AddDesc"].ToString();
				string cmdText5 = fun.select("tblPacking_Master.Terms AS PF,tblPacking_Master.Value", "tblPacking_Master,tblMM_SPR_PO_Temp", "tblPacking_Master.Id=tblMM_SPR_PO_Temp.PF AND tblMM_SPR_PO_Temp.PF ='" + Convert.ToInt32(sqlDataReader["PF"].ToString()) + "' AND tblMM_SPR_PO_Temp.SessionId='" + sId + "' AND tblMM_SPR_PO_Temp.CompId='" + CompId + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				dataRow[9] = sqlDataReader5["PF"].ToString();
				string cmdText6 = fun.select("Terms AS VAT, Value", "tblVAT_Master", "Id='" + Convert.ToInt32(sqlDataReader["VAT"].ToString()) + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				dataRow[10] = sqlDataReader6["VAT"].ToString();
				string empty = string.Empty;
				empty = fun.select("tblExciseser_Master.Terms AS ExST,tblExciseser_Master.Value", "tblExciseser_Master,tblMM_SPR_PO_Temp", "tblExciseser_Master.Id=tblMM_SPR_PO_Temp.ExST AND tblMM_SPR_PO_Temp.ExST ='" + Convert.ToInt32(sqlDataReader["ExST"].ToString()) + "' AND tblMM_SPR_PO_Temp.SessionId='" + sId + "'");
				SqlCommand sqlCommand7 = new SqlCommand(empty, con);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				dataRow[11] = sqlDataReader7["ExST"].ToString();
				string empty2 = string.Empty;
				empty2 = fun.FromDateDMY(sqlDataReader["DelDate"].ToString());
				dataRow[12] = empty2;
				dataRow[13] = sqlDataReader["Id"].ToString();
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				empty4 = ((!(sqlDataReader2["WONo"].ToString() != "")) ? "NA" : sqlDataReader2["WONo"].ToString());
				int num = Convert.ToInt32(sqlDataReader2["DeptId"].ToString());
				if (num > 0)
				{
					string cmdText7 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + num + "' ");
					SqlCommand sqlCommand8 = new SqlCommand(cmdText7, con);
					SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
					sqlDataReader8.Read();
					empty3 = sqlDataReader8["Dept"].ToString();
				}
				else
				{
					empty3 = "NA";
				}
				dataRow[14] = empty4;
				dataRow[15] = empty3;
				dataRow[16] = fun.CalBasicAmt(Convert.ToDouble(dataRow[4]), Convert.ToDouble(dataRow[5]));
				dataRow[17] = fun.CalDiscAmt(Convert.ToDouble(dataRow[4]), Convert.ToDouble(dataRow[5]), Convert.ToDouble(dataRow[7]));
				dataRow[18] = fun.CalTaxAmt(Convert.ToDouble(dataRow[4]), Convert.ToDouble(dataRow[5]), Convert.ToDouble(dataRow[7]), Convert.ToDouble(sqlDataReader5["Value"].ToString()), Convert.ToDouble(sqlDataReader7["Value"].ToString()), Convert.ToDouble(sqlDataReader6["Value"].ToString()));
				dataRow[19] = fun.CalTotAmt(Convert.ToDouble(dataRow[4]), Convert.ToDouble(dataRow[5]), Convert.ToDouble(dataRow[7]), Convert.ToDouble(sqlDataReader5["Value"].ToString()), Convert.ToDouble(sqlDataReader7["Value"].ToString()), Convert.ToDouble(sqlDataReader6["Value"].ToString()));
				dataTable.Rows.Add(dataRow);
			}
			dataTable.AcceptChanges();
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
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
				con.Open();
				string cmdText = fun.delete("tblMM_SPR_PO_Temp", "Id='" + num + "' AND CompId='" + CompId + "' AND SessionId='" + sId + "'  ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				LoadData();
			}
			catch (Exception)
			{
			}
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string cmdText = fun.select("PONo", "tblMM_PO_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by PONo desc");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			string text = ((!sqlDataReader.HasRows) ? "0001" : (Convert.ToInt32(sqlDataReader[0].ToString()) + 1).ToString("D4"));
			string code = fun.getCode(txtNewCustomerName.Text);
			string text2 = fun.FromDate(txtRefDate.Text);
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
			if (!(txtRefDate.Text != "") || !fun.DateValidation(txtRefDate.Text))
			{
				return;
			}
			string cmdText2 = "SELECT(SUM(tblMM_SPR_PO_Temp.Qty * (tblMM_SPR_PO_Temp.Rate - tblMM_SPR_PO_Temp.Rate * tblMM_SPR_PO_Temp.Discount / 100)) )+(SUM(tblMM_SPR_PO_Temp.Qty * (tblMM_SPR_PO_Temp.Rate - tblMM_SPR_PO_Temp.Rate * tblMM_SPR_PO_Temp.Discount / 100)) )* tblExciseser_Master.Value/100+(SUM(tblMM_SPR_PO_Temp.Qty * (tblMM_SPR_PO_Temp.Rate - tblMM_SPR_PO_Temp.Rate * tblMM_SPR_PO_Temp.Discount / 100)) )* tblVAT_Master.Value/100+(SUM(tblMM_SPR_PO_Temp.Qty * (tblMM_SPR_PO_Temp.Rate - tblMM_SPR_PO_Temp.Rate * tblMM_SPR_PO_Temp.Discount / 100)) )* tblPacking_Master.Value/100 AS Amount,DeptId,WONo,BudgetCode FROM tblMM_SPR_PO_Temp INNER JOIN tblMM_SPR_Details ON tblMM_SPR_PO_Temp.SPRId = tblMM_SPR_Details.Id  INNER JOIN tblVAT_Master ON tblMM_SPR_PO_Temp.VAT = tblVAT_Master.Id INNER JOIN tblExciseser_Master ON tblMM_SPR_PO_Temp.ExST = tblExciseser_Master.Id INNER JOIN tblPacking_Master ON tblMM_SPR_PO_Temp.PF = tblPacking_Master.Id GROUP BY  tblExciseser_Master.Value, tblVAT_Master.Value,tblPacking_Master.Value,DeptId,WONo,BudgetCode";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("WONO/BG", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BudgetCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BalAmt", typeof(double)));
			string value = string.Empty;
			string value2 = string.Empty;
			while (sqlDataReader2.Read())
			{
				num2++;
				double num4 = 0.0;
				double num5 = 0.0;
				num5 = Convert.ToDouble(sqlDataReader2["Amount"].ToString());
				_ = string.Empty;
				string empty = string.Empty;
				num3 = Convert.ToInt32(sqlDataReader2["BudgetCode"].ToString());
				if (Convert.ToInt32(sqlDataReader2["DeptId"].ToString()) == 0)
				{
					empty = sqlDataReader2["WONo"].ToString();
					if (fun.CheckValidWONo(empty, CompId, FinYearId))
					{
						num4 = calbalbud.TotBalBudget_WONO(num3, CompId, FinYearId, empty, 1);
					}
				}
				else
				{
					string cmdText3 = fun.select("Symbol", "BusinessGroup", "Id='" + sqlDataReader2["DeptId"].ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					string text4 = string.Empty;
					if (sqlDataReader3.HasRows)
					{
						text4 = sqlDataReader3["Symbol"].ToString();
					}
					empty = text4;
					value = "NA";
					value2 = "NA";
					num4 = calbalbud.TotBalBudget_BG(Convert.ToInt32(sqlDataReader2["DeptId"]), CompId, FinYearId, 1);
				}
				if (Math.Round(num4 - num5, 3) >= 0.0)
				{
					num++;
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				string cmdText4 = fun.select("Symbol,Description", "tblMIS_BudgetCode", "Id='" + num3 + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				if (sqlDataReader4.HasRows)
				{
					value = sqlDataReader4["Symbol"].ToString() + empty;
					value2 = sqlDataReader4["Description"].ToString();
				}
				dataRow[0] = empty;
				dataRow[1] = value;
				dataRow[2] = value2;
				dataRow[3] = Math.Round(num4, 3);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
				Session["X"] = dataTable.DefaultView;
			}
			if (num2 == num && num > 0)
			{
				string cmdText5 = fun.insert("tblMM_PO_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PRSPRFlag,PONo,SupplierId,Reference,ReferenceDate,ReferenceDesc,PaymentTerms,Warrenty,Freight,Octroi,ModeOfDispatch,Inspection,FileName,FileSize,ContentType,FileData,Remarks,ShipTo,Insurance,TC", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','1','" + text + "','" + code + "','" + DDLReference.SelectedValue + "','" + text2 + "','" + txtReferenceDesc.Text + "','" + DDLPaymentTerms.SelectedValue + "','" + drpwarrenty.SelectedValue + "','" + DDLFreight.SelectedValue + "','" + DDLOctroi.SelectedValue + "','" + txtModeOfDispatch.Text + "','" + txtInspection.Text + "','" + text3 + "','" + array.Length + "','" + postedFile.ContentType + "',@Data,'" + txtRemarks.Text + "','" + txtShipTo.Text + "','" + txtInsurance.Text + "','" + TextBox1.Text + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
				sqlCommand5.Parameters.AddWithValue("@Data", array);
				sqlCommand5.ExecuteNonQuery();
				string cmdText6 = fun.select("Id", "tblMM_PO_Master", "CompId='" + CompId + "' AND PONo='" + text + "' order by Id desc");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
				SqlDataReader sqlDataReader5 = sqlCommand6.ExecuteReader();
				sqlDataReader5.Read();
				string cmdText7 = fun.select("*", "tblMM_SPR_PO_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
				SqlDataReader sqlDataReader6 = sqlCommand7.ExecuteReader();
				while (sqlDataReader6.Read())
				{
					string cmdText8 = fun.insert("tblMM_PO_Details", "MId,PONo,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + sqlDataReader5["Id"].ToString() + "','" + text + "','" + sqlDataReader6["SPRNo"].ToString() + "','" + sqlDataReader6["SPRId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(sqlDataReader6["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(sqlDataReader6["Rate"].ToString()).ToString("N2")) + "','" + sqlDataReader6["Discount"].ToString() + "','" + sqlDataReader6["AddDesc"].ToString() + "','" + sqlDataReader6["PF"].ToString() + "','" + sqlDataReader6["ExST"].ToString() + "','" + sqlDataReader6["VAT"].ToString() + "','" + sqlDataReader6["DelDate"].ToString() + "','" + sqlDataReader6["BudgetCode"].ToString() + "'");
					SqlCommand sqlCommand8 = new SqlCommand(cmdText8, con);
					sqlCommand8.ExecuteNonQuery();
					string cmdText9 = fun.select("tblMM_SPR_Details.ItemId", "tblMM_PO_Master,tblMM_SPR_Master,tblMM_SPR_Details,tblMM_PO_Details ", "tblMM_PO_Master.PONo=tblMM_PO_Details.PONo And tblMM_SPR_Details.SPRNo=tblMM_SPR_Master.SPRNo And tblMM_PO_Details.SPRId=tblMM_SPR_Details.Id And tblMM_PO_Details.SPRNo=tblMM_SPR_Details.SPRNo And tblMM_SPR_Details.MId=tblMM_SPR_Master.Id AND tblMM_PO_Master.PONo='" + text + "' AND tblMM_PO_Master.CompId='" + CompId + "'");
					SqlCommand sqlCommand9 = new SqlCommand(cmdText9, con);
					SqlDataReader sqlDataReader7 = sqlCommand9.ExecuteReader();
					sqlDataReader7.Read();
					if (sqlDataReader7.HasRows)
					{
						string cmdText10 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + text + "' , LockDate='" + currDate + "' ,LockTime='" + currTime + "'", "ItemId='" + sqlDataReader7["ItemId"].ToString() + "' And  Type='1' AND CompId='" + CompId + "'");
						SqlCommand sqlCommand10 = new SqlCommand(cmdText10, con);
						sqlCommand10.ExecuteNonQuery();
						string cmdText11 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + text + "' , LockDate='" + currDate + "' ,LockTime='" + currTime + "'", "ItemId='" + sqlDataReader7["ItemId"].ToString() + "' And  Type='2' AND CompId='" + CompId + "'");
						SqlCommand sqlCommand11 = new SqlCommand(cmdText11, con);
						sqlCommand11.ExecuteNonQuery();
					}
				}
				string cmdText12 = fun.delete("tblMM_SPR_Po_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
				SqlCommand sqlCommand12 = new SqlCommand(cmdText12, con);
				sqlCommand12.ExecuteNonQuery();
				base.Response.Redirect("PO_new.aspx?ModId=6&SubModId=35");
			}
			else
			{
				base.Response.Redirect("PO_Error.aspx?ModId=6&Code=" + SupCode + "&PRSPR=1");
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
}

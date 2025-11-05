using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_SPR_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	protected DropDownList DrpType;

	protected DropDownList DrpCategory;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected GridView GridView2;

	protected TabPanel TabPanel1;

	protected TextBox txtManfDesc;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList DDLUnitBasic;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected RadioButton rdwono;

	protected TextBox txtwono;

	protected RequiredFieldValidator ReqWono;

	protected RadioButton rddept;

	protected DropDownList drpdept;

	protected TextBox textDelDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected TextBox txtRemark;

	protected Button btnAdd;

	protected TextBox txtQty;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected RegularExpressionValidator RegQty;

	protected TextBox txtRate;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected RegularExpressionValidator RegQty0;

	protected TextBox txtDiscount;

	protected RegularExpressionValidator RegDiscount;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtAutoSupplierExt;

	protected AutoCompleteExtender txtAutoSupplierExt_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected RadioButton RbtnLabour;

	protected RadioButton RbtnWithMaterial;

	protected RadioButton RbtnExpenses;

	protected RadioButton RbtnSerProvider;

	protected DropDownList DropDownList1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected Panel Panel2;

	protected TabPanel TabPanel2;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	protected Button Button1;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			lblMessage.Text = "";
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (rddept.Checked)
			{
				txtwono.Text = "";
			}
			textDelDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
				fun.drpunit(DDLUnitBasic);
				DrpCategory.Items.Clear();
				DrpCategory.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
			}
			if (base.Request.QueryString["m"] != null)
			{
				TabContainer1.ActiveTabIndex = 1;
				lblMessage.Text = base.Request.QueryString["m"].ToString();
			}
			LoadData();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void Fillgrid(string sd, string B, string s, string drptype)
	{
		new DataTable();
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			if (DrpType.SelectedValue != "Select")
			{
				if (DrpType.SelectedValue == "Category")
				{
					if (sd != "Select")
					{
						value = " AND tblDG_Item_Master.CId='" + sd + "'";
						if (B != "Select")
						{
							if (B == "tblDG_Item_Master.ItemCode")
							{
								txtSearchItemCode.Visible = true;
								value2 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
							}
							if (B == "tblDG_Item_Master.ManfDesc")
							{
								txtSearchItemCode.Visible = true;
								value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
							}
							if (B == "tblDG_Item_Master.Location")
							{
								txtSearchItemCode.Visible = false;
								DropDownList3.Visible = true;
								if (DropDownList3.SelectedValue != "Select")
								{
									value2 = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
								}
							}
						}
						value3 = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
					}
					else if (sd == "Select" && B == "Select" && s != string.Empty)
					{
						value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
				{
					if (B != "Select")
					{
						if (B == "tblDG_Item_Master.ItemCode")
						{
							txtSearchItemCode.Visible = true;
							value2 = " And tblDG_Item_Master.ItemCode Like '%" + s + "%'";
						}
						if (B == "tblDG_Item_Master.ManfDesc")
						{
							txtSearchItemCode.Visible = true;
							value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
						}
					}
					else if (B == "Select" && s != string.Empty)
					{
						value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				new SqlCommand();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAllItem", con);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex"].Value = sd;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize"].Value = value;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex1"].Value = value2;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize1"].Value = value3;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpType"].Value = drptype;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpCode"].Value = B;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value4;
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
			}
			else
			{
				string empty = string.Empty;
				empty = "Please Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
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
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DataSet dataSet = new DataSet();
				SqlCommand selectCommand = new SqlCommand(fun.select("*", "tblMM_SPR_Temp", "ItemId='" + num + "' And CompId='" + CompId + "' AND SessionId='" + sId + "'"), connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblMM_SPR_Temp");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					base.Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_NoCode.aspx?Id=" + num + "&ModId=6&SubModId=31");
					return;
				}
				string empty = string.Empty;
				empty = "Item is already exist.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtAutoSupplierExt.Text);
			con.Open();
			string cmdText = fun.select(" * ", " tblMM_SPR_Temp ", " NoCode is Not Null AND CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			int num = Convert.ToInt32(dataSet.Tables[0].Rows.Count);
			int num2 = num + 1;
			string text = "";
			string text2 = "";
			double num3 = 0.0;
			double num4 = 0.0;
			num3 = Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2"));
			num4 = Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2"));
			int num5 = 0;
			if (rdwono.Checked && txtwono.Text != "")
			{
				text = txtwono.Text;
				num5 = 1;
			}
			if (rddept.Checked)
			{
				text2 = drpdept.SelectedValue.ToString();
				num5 = 1;
			}
			int num6 = fun.chkSupplierCode(code);
			if (num6 == 1 && num3 > 0.0 && num5 == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) && fun.NumberValidationQty(txtQty.Text) && fun.NumberValidationQty(txtRate.Text) && fun.NumberValidationQty(txtDiscount.Text))
			{
				if (fun.CheckValidWONo(txtwono.Text, CompId, FinYearId))
				{
					string cmdText2 = fun.insert("tblMM_SPR_Temp", "SysDate,SysTime,CompId,FinYearId,SessionId,SupplierId,NoCode,ManfDesc,UOMBasic,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + code + "','" + num2 + "','" + txtManfDesc.Text + "','" + DDLUnitBasic.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + DropDownList1.SelectedValue + "','" + text + "','" + text2 + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + num4 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					sqlCommand.ExecuteNonQuery();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid WONo.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid data entry.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				TabContainer1.ActiveTabIndex = 1;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void txtAutoSupplierExt_TextChanged(object sender, EventArgs e)
	{
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
		TabContainer1.ActiveTabIndex = 1;
	}

	public void LoadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("NoCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("A/cHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(string)));
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("*", "tblMM_SPR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic", "tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[2] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[3] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
				}
				else
				{
					string cmdText3 = fun.select("Unit_Master.Symbol As UOMBasic", "tblMM_SPR_Temp,Unit_Master", " tblMM_SPR_Temp.NoCode='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["NoCode"]) + "' AND Unit_Master.Id=tblMM_SPR_Temp.UOMBasic AND tblMM_SPR_Temp.CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[1] = dataSet.Tables[0].Rows[i]["NoCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
					dataRow[3] = dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString();
				}
				string cmdText4 = fun.select("'['+AccHead.Symbol+']'+Description AS Head", "AccHead,tblMM_SPR_Temp", "tblMM_SPR_Temp.AHId=AccHead.Id AND tblMM_SPR_Temp.AHId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["AHId"]) + "' AND tblMM_SPR_Temp.SessionId='" + sId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				dataRow[4] = dataSet4.Tables[0].Rows[0]["Head"].ToString();
				dataRow[5] = decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3");
				dataRow[6] = decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2");
				dataRow[7] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				if (dataSet.Tables[0].Rows[i]["WONo"].ToString() != "")
				{
					dataRow[8] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				}
				else
				{
					dataRow[8] = "NA";
				}
				if (dataSet.Tables[0].Rows[i]["DeptId"].ToString() != "0" && dataSet.Tables[0].Rows[i]["DeptId"].ToString() != "")
				{
					string cmdText5 = fun.select("Symbol AS Dept", "BusinessGroup", string.Concat("Id='", dataSet.Tables[0].Rows[i]["DeptId"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					dataRow[9] = dataSet5.Tables[0].Rows[0]["Dept"].ToString();
				}
				dataRow[10] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["DelDate"].ToString());
				dataRow[12] = dataSet.Tables[0].Rows[i]["Discount"].ToString();
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
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			con.Open();
			string cmdText = fun.delete("tblMM_SPR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND Id='" + num + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			con.Close();
			LoadData();
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		DataSet dataSet = new DataSet();
		try
		{
			con.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string cmdText = fun.select("SPRNo", "tblMM_SPR_Master", "CompId='" + num + "' AND FinYearId='" + num2 + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblMM_SPR_Master");
			string text2 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblMM_SPR_Temp", "CompId='" + num + "' AND SessionId='" + text + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string cmdText3 = fun.insert("tblMM_SPR_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,SPRNo", "'" + currDate + "','" + currTime + "','" + text + "','" + num + "','" + num2 + "','" + text2 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText4 = fun.select("Id", "tblMM_SPR_Master", "CompId='" + num + "' AND SPRNo='" + text2 + "' Order By Id Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string text3 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					if (dataSet2.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
					{
						string cmdText5 = fun.insert("tblMM_SPR_Details", "MId,SPRNo,ItemId,Qty,Rate,SupplierId,AHId,WONo,DeptId,Remarks,DelDate,Discount", string.Concat("'", text3, "','", text2, "','", dataSet2.Tables[0].Rows[i]["ItemId"], "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")), "','", Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2")), "','", dataSet2.Tables[0].Rows[i]["SupplierId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["AHId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["WONo"].ToString(), "','", dataSet2.Tables[0].Rows[i]["DeptId"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Remarks"].ToString(), "','", dataSet2.Tables[0].Rows[i]["DelDate"].ToString(), "','", dataSet2.Tables[0].Rows[i]["Discount"].ToString(), "'"));
						SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
						sqlCommand2.ExecuteNonQuery();
						string cmdText6 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + text2 + "' , LockDate='" + currDate + "' ,LockTime='" + currTime + "'", string.Concat("ItemId='", dataSet2.Tables[0].Rows[i]["ItemId"], "' And  Type='1' AND  CompId='", num, "' "));
						SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
						sqlCommand3.ExecuteNonQuery();
						continue;
					}
					string text4 = "";
					string cmdText7 = fun.select("FinYear", "tblFinancial_master", "CompId='" + num + "' AND FinYearId='" + num2 + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText7, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						text4 = fun.SPRNoCodeFY(dataSet4.Tables[0].Rows[0]["FinYear"].ToString());
					}
					string text5 = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["NoCode"].ToString()).ToString("D3");
					string text6 = text4 + "-" + text2 + "-" + text5;
					string cmdText8 = fun.select("Id", "tblDG_Item_Master", "CompId='" + num + "' AND ItemCode='" + text6 + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText8, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					string cmdText9 = fun.select("FinYearFrom", "tblFinancial_master", "CompId='" + num + "'  And FinYearId='" + num2 + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText9, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					string text7 = "";
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						text7 = dataSet6.Tables[0].Rows[0]["FinYearFrom"].ToString();
					}
					if (dataSet5.Tables[0].Rows.Count == 0)
					{
						string cmdText10 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CId,ItemCode,ManfDesc,UOMBasic,MinOrderQty,MinStockQty,StockQty,Absolute,OpeningBalQty,UOMConFact,OpeningBalDate,AHId", "'" + currDate + "','" + currTime + "','" + text + "','" + num + "','" + num2 + "', 26,'" + text6 + "','" + dataSet2.Tables[0].Rows[i]["ManfDesc"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["UOMBasic"].ToString() + "',0,0,0,0,0,0,'" + text7 + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["AHId"]) + "'");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText10, con);
						sqlCommand4.ExecuteNonQuery();
					}
					string cmdText11 = fun.select("Id", "tblDG_Item_Master", "CompId='" + num + "' AND ItemCode='" + text6 + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText11, con);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter7.Fill(dataSet7);
					string text8 = "";
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						text8 = dataSet7.Tables[0].Rows[0]["Id"].ToString();
					}
					string cmdText12 = fun.insert("tblMM_SPR_Details", "MId,SPRNo,ItemId,Qty,Rate,SupplierId,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + text3 + "','" + text2 + "','" + text8 + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2")) + "','" + dataSet2.Tables[0].Rows[i]["SupplierId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["AHId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["WONo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["DeptId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Remarks"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["DelDate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Discount"].ToString() + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText12, con);
					sqlCommand5.ExecuteNonQuery();
					string cmdText13 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + text2 + "' , LockDate='" + currDate + "' ,LockTime='" + currTime + "'", "ItemId='" + text8 + "' And  Type='1'  ");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText13, con);
					sqlCommand6.ExecuteNonQuery();
				}
				string cmdText14 = fun.delete("tblMM_SPR_Temp", "CompId='" + num + "' AND SessionId='" + text + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText14, con);
				sqlCommand7.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "Selected records are not found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
			con.Dispose();
		}
	}

	protected void DrpSearchCode_SelectedIndexChanged1(object sender, EventArgs e)
	{
		try
		{
			if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.Location")
			{
				DropDownList3.Visible = true;
				txtSearchItemCode.Visible = false;
			}
			else
			{
				DropDownList3.Visible = false;
				txtSearchItemCode.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void rdwono_CheckedChanged(object sender, EventArgs e)
	{
		if (rdwono.Checked)
		{
			ReqWono.Visible = true;
		}
		else if (rddept.Checked)
		{
			ReqWono.Visible = false;
		}
	}

	protected void rddept_CheckedChanged(object sender, EventArgs e)
	{
		if (rdwono.Checked)
		{
			ReqWono.Visible = true;
		}
		else if (rddept.Checked)
		{
			ReqWono.Visible = false;
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MaterialManagement/Transactions/SPR_Dashboard.aspx?ModId=6&SubModId=31");
	}

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpSearchCode.SelectedItem.Text == "Location")
		{
			DropDownList3.Visible = true;
			txtSearchItemCode.Visible = false;
			txtSearchItemCode.Text = "";
		}
		else
		{
			DropDownList3.Visible = false;
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory.SelectedValue != "Select")
			{
				DrpSearchCode.Visible = true;
				txtSearchItemCode.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			switch (DrpType.SelectedValue)
			{
			case "Category":
			{
				DrpSearchCode.Visible = true;
				DropDownList3.Visible = true;
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpCategory.Visible = true;
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
				DrpCategory.DataSource = dataSet.Tables["tblDG_Category_Master"];
				DrpCategory.DataTextField = "Category";
				DrpCategory.DataValueField = "CId";
				DrpCategory.DataBind();
				DrpCategory.Items.Insert(0, "Select");
				DrpCategory.ClearSelection();
				fun.drpLocat(DropDownList3);
				if (DrpSearchCode.SelectedItem.Text == "Location")
				{
					DropDownList3.Visible = true;
					txtSearchItemCode.Visible = false;
					txtSearchItemCode.Text = "";
				}
				else
				{
					DropDownList3.Visible = false;
					txtSearchItemCode.Visible = true;
					txtSearchItemCode.Text = "";
				}
				break;
			}
			case "WOItems":
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpSearchCode.Visible = true;
				DrpCategory.Visible = false;
				DrpCategory.Items.Clear();
				DrpCategory.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DropDownList3.Items.Clear();
				DropDownList3.Items.Insert(0, "Select");
				break;
			case "Select":
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RbtnExpenses_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void RbtnSerProvider_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DropDownList1, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnSerProvider);
		TabContainer1.ActiveTabIndex = 1;
	}
}

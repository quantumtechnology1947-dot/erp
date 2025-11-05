using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_MaterialRequisitionSlip_MRS_New : Page, IRequiresSessionState
{
	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView2;

	protected Panel Panel2;

	protected TabPanel TabPanel1;

	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private string sId = "";

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			getval();
			if (!base.IsPostBack)
			{
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
				loadgrid();
			}
			TabContainer1.OnClientActiveTabChanged = "OnChanged";
			TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory1.SelectedValue != "Select")
			{
				DrpSearchCode.Visible = true;
				txtSearchItemCode.Text = "";
				string selectedValue = DrpCategory1.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
			}
			else
			{
				DrpSearchCode.SelectedIndex = 0;
				txtSearchItemCode.Visible = true;
				DropDownList3.Visible = false;
				string sd = "";
				string b = "";
				string s = "";
				string drptype = "";
				Fillgrid(sd, b, s, drptype);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (DrpType.SelectedValue)
		{
		case "Category":
		{
			DrpSearchCode.Visible = true;
			DropDownList3.Visible = true;
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
			DrpCategory1.Visible = true;
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			DataSet dataSet = new DataSet();
			string cmdText = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			DrpCategory1.DataSource = dataSet.Tables["tblDG_Category_Master"];
			DrpCategory1.DataTextField = "Category";
			DrpCategory1.DataValueField = "CId";
			DrpCategory1.DataBind();
			DrpCategory1.Items.Insert(0, "Select");
			DrpCategory1.ClearSelection();
			string cmdText2 = fun.select1("Id,LocationLabel+'-'+tblDG_Location_Master.LocationNo As Location ", "tblDG_Location_Master");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_Location_Master");
			DropDownList3.DataSource = dataSet2.Tables["tblDG_Location_Master"];
			DropDownList3.DataTextField = "Location";
			DropDownList3.DataValueField = "Id";
			DropDownList3.DataBind();
			DropDownList3.Items.Insert(0, "Select");
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
			DrpCategory1.Visible = false;
			DrpCategory1.Items.Clear();
			DrpCategory1.Items.Insert(0, "Select");
			DropDownList3.Visible = false;
			DropDownList3.Items.Clear();
			DropDownList3.Items.Insert(0, "Select");
			break;
		case "Select":
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			break;
		}
	}

	public void Fillgrid(string sd, string B, string s, string drptype)
	{
		string connectionString = fun.Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
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
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAllItem", selectConnection);
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

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory1.SelectedValue;
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
		con.Open();
		try
		{
			if (!(e.CommandName == "Add"))
			{
				return;
			}
			GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("LblId")).Text;
			int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue);
			string text2 = "";
			string text3 = "";
			double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtqty")).Text.ToString()).ToString("N3"));
			string text4 = ((TextBox)gridViewRow.FindControl("txtremarks")).Text;
			SqlCommand selectCommand = new SqlCommand(fun.select("Id", "tblinv_MaterialRequisition_Temp", "ItemId='" + text + "' And CompId='" + CompId + "' AND SessionId='" + sId + "'"), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblinv_MaterialRequisition_Temp");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string empty = string.Empty;
				empty = "Item is already selected for MRS.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				return;
			}
			SqlCommand selectCommand2 = new SqlCommand(fun.select("StockQty", "tblDG_Item_Master", "Id='" + text + "' And CompId='" + CompId + "'"), con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblDG_SubCategory_Master");
			double num3 = 0.0;
			num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
			if (Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) > 0.0 && num3 >= num2)
			{
				string text5 = "";
				if (num == 1 && fun.NumberValidationQty(num2.ToString()))
				{
					if (((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue != "0" && decimal.Parse(((TextBox)gridViewRow.FindControl("txtqty")).Text.ToString()).ToString("N3") != "")
					{
						text2 = ((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue;
						text5 = fun.insert("tblinv_MaterialRequisition_Temp", "CompId,SessionId,ItemId,DeptId,ReqQty,Remarks", "'" + CompId + "','" + sId + "','" + text + "','" + text2 + "','" + num2 + "','" + text4 + "'");
						SqlCommand sqlCommand = new SqlCommand(text5, con);
						sqlCommand.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					if (num != 2 || !fun.NumberValidationQty(num2.ToString()))
					{
						return;
					}
					text3 = ((TextBox)gridViewRow.FindControl("txtwono")).Text;
					if (text3 != "" && decimal.Parse(((TextBox)gridViewRow.FindControl("txtqty")).Text.ToString()).ToString("N3") != "")
					{
						if (fun.CheckValidWONo(text3, CompId, FinYearId))
						{
							text5 = fun.insert("tblinv_MaterialRequisition_Temp", "CompId,SessionId,ItemId,WONo,DeptId,ReqQty,Remarks", "'" + CompId + "','" + sId + "','" + text + "','" + text3 + "','1','" + num2 + "','" + text4 + "'");
							SqlCommand sqlCommand2 = new SqlCommand(text5, con);
							sqlCommand2.ExecuteNonQuery();
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "WONo or Dept is not found!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "ReqQty should be less than Stock Qty. ";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
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

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		getval();
	}

	public void getval()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "2")
				{
					((TextBox)row.FindControl("txtwono")).Visible = true;
				}
				else
				{
					((TextBox)row.FindControl("txtwono")).Visible = false;
				}
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "1")
				{
					((DropDownList)row.FindControl("drpdept")).Visible = true;
					if (((DropDownList)row.FindControl("drpdept")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = false;
					}
				}
				else
				{
					((DropDownList)row.FindControl("drpdept")).Visible = false;
					if (!((DropDownList)row.FindControl("drpdept")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = true;
					}
				}
				if (!((DropDownList)row.FindControl("DropDownList1")).Visible)
				{
					((RequiredFieldValidator)row.FindControl("Reqty")).Visible = false;
					((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = false;
				}
				else if (((DropDownList)row.FindControl("DropDownList1")).Visible)
				{
					((RequiredFieldValidator)row.FindControl("Reqty")).Visible = true;
					((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = true;
				}
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue != "0")
				{
					((RequiredFieldValidator)row.FindControl("Reqty")).Visible = true;
				}
				else if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "0")
				{
					((RequiredFieldValidator)row.FindControl("Reqty")).Visible = false;
				}
				if (((TextBox)row.FindControl("txtwono")).Visible)
				{
					((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = true;
				}
				else if (!((TextBox)row.FindControl("txtwono")).Visible)
				{
					((RequiredFieldValidator)row.FindControl("Reqwono")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("LblId0")).Text);
				string cmdText = fun.delete("tblinv_MaterialRequisition_Temp", "Id='" + num + "' AND SessionId='" + sId + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			string cmdText2 = fun.select("MRSNo", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRSNo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblInv_MaterialRequisition_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			if (!(e.CommandName == "proceed"))
			{
				return;
			}
			con.Open();
			int num2 = 1;
			string cmdText3 = fun.select("*", "tblinv_MaterialRequisition_Temp", "SessionId='" + sId + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblinv_MaterialRequisition_Temp");
			string text2 = "";
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					if (num2 == 1)
					{
						string cmdText4 = "Insert into tblInv_MaterialRequisition_Master(SysDate,SysTime,CompId,FinYearId,SessionId,MRSNo) VALUES  ('" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text + "')";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
						sqlCommand2.ExecuteNonQuery();
						num2 = 0;
						string cmdText5 = fun.select("Id", "tblInv_MaterialRequisition_Master", "CompId='" + CompId + "' Order by Id desc");
						SqlCommand selectCommand3 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3, "tblInv_MaterialRequisition_Master");
						text2 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					}
					string cmdText6 = "Insert into tblInv_MaterialRequisition_Details(MId,MRSNo,ItemId,DeptId,WONo,ReqQty,Remarks) VALUES  ('" + text2 + "','" + text + "','" + dataSet2.Tables[0].Rows[i]["ItemId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["DeptId"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["WONo"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3")) + "','" + dataSet2.Tables[0].Rows[i]["Remarks"].ToString() + "')";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
					sqlCommand3.ExecuteNonQuery();
				}
			}
			string cmdText7 = fun.delete("tblinv_MaterialRequisition_Temp", "CompId='" + CompId + "'And SessionId='" + sId + "'");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText7, con);
			sqlCommand4.ExecuteNonQuery();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			loadgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpSearchCode.SelectedItem.Text == "Location")
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

	public void loadgrid()
	{
		try
		{
			string cmdText = fun.select("tblinv_MaterialRequisition_Temp.Id,tblinv_MaterialRequisition_Temp.ItemId,tblinv_MaterialRequisition_Temp.DeptId,tblinv_MaterialRequisition_Temp.WONo,tblinv_MaterialRequisition_Temp.ReqQty,tblinv_MaterialRequisition_Temp.Remarks", "tblinv_MaterialRequisition_Temp", "tblinv_MaterialRequisition_Temp.CompId='" + CompId + "' AND tblinv_MaterialRequisition_Temp.SessionId='" + sId + "' order by tblinv_MaterialRequisition_Temp.Id desc ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			string value = "";
			string value2 = "";
			string value3 = "";
			double num = 0.0;
			string value4 = "";
			string text = "";
			double num2 = 0.0;
			string text2 = "";
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
						value2 = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
						num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
						string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							value3 = dataSet3.Tables[0].Rows[0][0].ToString();
						}
					}
					string cmdText4 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet.Tables[0].Rows[i]["DeptId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					value4 = ((dataSet4.Tables[0].Rows.Count <= 0) ? "NA" : dataSet4.Tables[0].Rows[0][0].ToString());
				}
				dataRow[0] = value;
				dataRow[1] = value2;
				dataRow[2] = value3;
				if (num == 0.0)
				{
					dataRow[3] = 0;
				}
				else
				{
					dataRow[3] = num;
				}
				dataRow[4] = value4;
				if (dataSet.Tables[0].Rows[i]["WONo"].ToString() != "")
				{
					text = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[5] = text;
				}
				else
				{
					text = "NA";
					dataRow[5] = text;
				}
				num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[6] = num2;
				text2 = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[7] = text2;
				dataRow[8] = dataSet.Tables[0].Rows[i]["Id"].ToString();
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

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory1.SelectedValue;
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
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
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
